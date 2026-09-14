// Decompiled with JetBrains decompiler
// Type: MackinawCPS.CommandLineCPS.Cruncher
// Assembly: APXFamilyCPS, Version=15.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 7983BD42-76AB-479D-8966-B7B635E0E28A
// Assembly location: C:\Program Files (x86)\Motorola\APX Dpt 25\APXFamilyCPS.exe

using AcpBusinessLayer;
using AcpCommonLib;
using Common;
using CommonResources;
using CommonUtility;
using ConstraintHelper;
using Motorola.Common.CommonLib;
using Motorola.Common.Communication.CommonUtil;
using Motorola.Common.Communication.Pba;
using Motorola.Common.CustomException;
using Motorola.CommonCPS.Server.EntityModel;
using Motorola.MackinawCPS.CoreFeatures.PackExec;
using Motorola.MackinawCPS.CoreFeatures.TrunkingSystem;
using SpecialFeatures.CloneWizard;
using SpecialFeatures.Comms;
using SpecialFeatures.Flashport;
using SpecialFeatures.Flashport.FlashRadio;
using SpecialFeatures.RadioLanguagePack;
using SpecialFeatures.ReadWritePassword;
using SpecialFeatures.Utilities;
using SpecialFeatures.VoiceAnnouncements;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;

#nullable disable
namespace MackinawCPS.CommandLineCPS;

public class Cruncher : IDisposable
{
  private const string backSlash = "\\";
  private const string archiveExtention = ".mc";
  private const string pbaExtention = ".xpba";
  private static Cruncher theInstance = new Cruncher();
  private CruncherOperation operation;
  private object tempSender;
  private RoutedEventArgs tempArgs;
  private string folderName;
  private bool legalCommandLine;
  private TextWriterTraceListener traceListener;
  private BooleanSwitch LoggingSwitch;
  private string createSerialNumber = (string) null;
  private object locker = new object();

  internal static Cruncher Instance => Cruncher.theInstance;

  private Cruncher()
  {
    this.InitLogging();
    this.Report("[Cruncher][Information][Begin][Cruncher(ctor)]");
    this.legalCommandLine = true;
    this.tempSender = (object) null;
    this.tempArgs = (RoutedEventArgs) null;
    this.operation = new CruncherOperation();
    this.folderName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Motorola\\ApxFamilyCPS\\Cruncher");
    if (!Directory.Exists(this.folderName))
      Directory.CreateDirectory(this.folderName);
    this.Report("[Cruncher][Information][End][Cruncher(ctor)]");
  }

  private void InitLogging()
  {
    this.LoggingSwitch = new BooleanSwitch("CommandLineOperation", "Enable/Disable logging of command line cps operation");
    if (!this.LoggingSwitch.Enabled)
      return;
    this.traceListener = new TextWriterTraceListener("CMD-" + Guid.NewGuid().ToString());
    Trace.Listeners.Add((TraceListener) this.traceListener);
  }

  private void CloseLogging()
  {
    if (this.LoggingSwitch == null || !this.LoggingSwitch.Enabled || this.traceListener == null)
      return;
    Trace.Flush();
    this.traceListener.Flush();
    this.traceListener.Close();
  }

  private void Report(string message)
  {
    Trace.WriteLine(message);
    try
    {
      lock (this.locker)
      {
        string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Motorola\\CommonCPS\\Log\\");
        if (!Directory.Exists(path))
          Directory.CreateDirectory(path);
        string path1 = path;
        DateTime now = DateTime.Now;
        string path2 = now.ToString("yyyy-MM-dd") + ".log";
        using (StreamWriter streamWriter1 = new StreamWriter(Path.Combine(path1, path2), true))
        {
          StreamWriter streamWriter2 = streamWriter1;
          now = DateTime.Now;
          string str = $"[{now.ToString("yyyy-MM-dd HH:mm:ss fff")}]\r\n{message}";
          streamWriter2.WriteLine(str);
          streamWriter1.WriteLine("----------------------------------------");
        }
      }
    }
    catch (Exception ex)
    {
    }
  }

  private void FireError(Cruncher.Error errCode)
  {
    this.Report("[Cruncher][Error][FireError]: " + (object) errCode);
    this.CloseLogging();
    Application.Current.Shutdown((int) errCode);
  }

  private void CreateErrorOutput(string inputFile, int errorCode = 22001)
  {
    this.Report("[Cruncher][Information][Begin][CreateErrorOutput-1]");
    if (this.operation.cruncherData == null)
      this.operation.cruncherData = new CruncherData();
    ReadWriteJob readWriteJob = new ReadWriteJob();
    this.operation.cruncherData.ErrorCode = new int?(errorCode);
    try
    {
      ObjectSerializer.DataContract_SerializeToFile(inputFile, (object) this.operation.cruncherData);
      if (this.operation.sourceFile != null && System.IO.File.Exists(this.operation.sourceFile))
        System.IO.File.Delete(this.operation.sourceFile);
      if (this.operation.targetFile != null && System.IO.File.Exists(this.operation.targetFile))
        System.IO.File.Delete(this.operation.targetFile);
    }
    catch (Exception ex)
    {
      this.Report("[Cruncher][Exception][CreateErrorOutput-1]: " + ex.Message);
      this.CreateErrorOutput();
      this.FireError(Cruncher.Error.File);
    }
    this.Report("[Cruncher][Information][End][CreateErrorOutput-1]");
  }

  private void CreateErrorOutput(int errorCode = 22003)
  {
    this.Report("[Cruncher][Information][Begin][CreateErrorOutput-2]");
    ReadWriteJob readWriteJob = new ReadWriteJob();
    int id = Process.GetCurrentProcess().Id;
    this.operation.cruncherData.ErrorCode = new int?(errorCode);
    try
    {
      ObjectSerializer.DataContract_SerializeToFile(Path.Combine(this.folderName, id.ToString() + ".cruncher"), (object) this.operation.cruncherData);
    }
    catch (Exception ex)
    {
      this.Report("[Cruncher][Exception][CreateErrorOutput-2]: " + ex.Message);
      this.FireError(Cruncher.Error.File);
    }
    this.Report("[Cruncher][Information][End][CreateErrorOutput-2]");
  }

  internal bool IsCommandLineCPS(string[] args)
  {
    this.Report("[Cruncher][Information][Begin][IsCommandLineCPS]");
    Application current = Application.Current;
    if (string.Compare(args[0], "/cruncher", true) == 0)
    {
      if (current != null)
        current.Properties[(object) "CommandLineCPS"] = (object) true;
    }
    else if (current != null)
      current.Properties[(object) "CommandLineCPS"] = (object) false;
    this.Report("[Cruncher][Information][End][IsCommandLineCPS]: " + ((bool) current.Properties[(object) "CommandLineCPS"]).ToString());
    return (bool) current.Properties[(object) "CommandLineCPS"];
  }

  public bool ParseCommandLineParameters(string[] args)
  {
    this.Report("[Cruncher][Information][Begin][ParseCommandLineParameters]");
    this.legalCommandLine = true;
    Application.Current.Properties[(object) "CommandLineCPS"] = (object) false;
    return false;
  }

  internal void LaunchOperations(object sender, RoutedEventArgs e)
  {
    this.Report($"[Cruncher][Information][Begin][LaunchOperations]: [{(object) DateTime.Now} - {this.operation.Type.ToString()}]");
    if (!this.legalCommandLine)
    {
      this.Report("[Cruncher][Error][LaunchOperations]: Invalid command");
    }
    else
    {
      this.tempSender = sender;
      this.tempArgs = e;
      try
      {
        this.BeginExecuteCommand(this.operation.cruncherData);
        switch (this.operation.Type)
        {
          case CruncherOperation.Operation.READ:
            this.CruncherRead(this.operation.inputFile);
            break;
          case CruncherOperation.Operation.WRITE:
          case CruncherOperation.Operation.ARCHIVECLONE:
          case CruncherOperation.Operation.NONECLONEWRITE:
          case CruncherOperation.Operation.UPGRADE:
            this.CruncherWrite(this.operation.inputFile);
            break;
          case CruncherOperation.Operation.CREATE:
            this.CruncherCreate(this.operation.inputFile);
            break;
          case CruncherOperation.Operation.IMPORT:
            this.CruncherImport(this.operation);
            break;
        }
        this.EndExecuteCommand(this.operation.cruncherData);
      }
      catch (Exception ex)
      {
        this.Report("[Cruncher][Exception][LaunchOperations]: " + ex.Message);
        this.FireError(Cruncher.Error.Fail);
      }
      finally
      {
      }
      this.Report($"[Cruncher][Information][End][LaunchOperations]: [{(object) DateTime.Now} - {this.operation.Type.ToString()}]");
      this.CloseLogging();
      Application.Current.Shutdown();
    }
  }

  private bool SetupVirtualDevice(string deviceFile, AstroDeviceInfo deviceInfo)
  {
    this.Report("[Cruncher][Information][Begin][SetupVirtualDevice]");
    bool flag = FileProxyFactory.Instance.SetupVirtualProxy(deviceFile, deviceInfo);
    if (flag)
      this.Report("[Cruncher][Success][SetupVirtualDevice]: Success");
    else
      this.Report("[Cruncher][Error][SetupVirtualDevice]: Failed");
    this.Report("[Cruncher][Information][End][SetupVirtualDevice]");
    return flag;
  }

  private bool CruncherImport(CruncherOperation operation)
  {
    this.Report("[Cruncher][Information][Begin][CruncherImport]");
    CruncherData cruncherData = new CruncherData();
    try
    {
      WindowMain mainWindow = (WindowMain) Application.Current.MainWindow;
      string empty = string.Empty;
      if (!mainWindow.OpenCodeplug(Path.GetFullPath(operation.inputFile), ref empty))
      {
        this.Report("[Cruncher][Error][CruncherImport]: " + operation.inputFile);
        cruncherData.ErrorCode = new int?(22018);
        this.FireError(Cruncher.Error.Fail);
        return false;
      }
      (FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation).General.RadInfoGeneralCodeplugVersion_A7683.Value = AppInfoManager.AppVersion;
      AppInfoManager.InvalidFieldsReport.Clear();
      this.PackImportXPBA(ref cruncherData);
      cruncherData.ErrorCode = new int?();
      this.Report("[Cruncher][Success][CruncherImport]: Archive Import completed");
    }
    catch (CommonException ex)
    {
      this.Report("[Cruncher][Exception][CruncherImport]: " + ex.Message);
      cruncherData.ErrorCode = new int?((int) ex.ErrorCode);
      this.FireError(Cruncher.Error.Fail);
    }
    catch (Exception ex)
    {
      this.Report("[Cruncher][Exception][CruncherImport]: " + ex.Message);
      cruncherData.ErrorCode = new int?(22017);
      this.FireError(Cruncher.Error.Fail);
    }
    finally
    {
      ObjectSerializer.DataContract_SerializeToFile(operation.targetFile, (object) cruncherData);
      this.Report("[Cruncher][Information][End][CruncherImport]");
    }
    return true;
  }

  private void DeleteTempFile(string filePath)
  {
    this.Report("[Cruncher][Information][Begin][DeleteTempFile]");
    if (filePath != null && System.IO.File.Exists(filePath))
    {
      try
      {
        System.IO.File.Delete(filePath);
      }
      catch (Exception ex)
      {
        this.Report("[Cruncher][Exception][DeleteTempFile]: " + ex.Message);
      }
    }
    this.Report("[Cruncher][Information][End][DeleteTempFile]");
  }

  private bool CruncherWrite(string inputFile)
  {
    this.Report("[Cruncher][Information][Begin][CruncherWrite]");
    string str = Path.Combine(this.folderName, Guid.NewGuid().ToString() + ".mc");
    try
    {
      if (this.operation.cruncherData.IsRestoreJob)
        this.WriteJobProcess_RestoreJob();
      else
        this.WriteJobProcess_OtherTypesOfJob(inputFile, str);
      this.operation.cruncherData.pbaFile = CombineTool.Encode(this.operation.targetFile, (object) this.operation.deviceInfo);
      this.operation.cruncherData.ErrorCode = new int?();
      this.EndExecuteCommand(this.operation.cruncherData);
      ObjectSerializer.DataContract_SerializeToFile(inputFile, (object) this.operation.cruncherData);
      this.Report("[Cruncher][Success][CruncherWrite]: Clone radio express completed");
    }
    catch (CommonException ex)
    {
      this.CreateErrorOutput(inputFile, (int) ex.ErrorCode);
    }
    catch (Exception ex)
    {
      this.Report("[Cruncher][Exception][CruncherWrite]: " + ex.Message);
      if (ex.Message == "Failed to apply codeplug columns")
        this.CreateErrorOutput(inputFile, 22010);
      else if (ex.Message == "Failed to open template archive")
        this.CreateErrorOutput(inputFile, 22012);
      else
        this.CreateErrorOutput(inputFile, 22005);
      this.FireError(Cruncher.Error.Fail);
    }
    finally
    {
      this.DeleteTempFile(str);
      this.DeleteTempFile(this.operation.sourceFile);
      this.DeleteTempFile(this.operation.targetFile);
      this.DeleteTempFile(this.operation.targetArchive);
      this.Report("[Cruncher][Information][End][CruncherWrite]");
    }
    return true;
  }

  private void WriteJobProcess_RestoreJob()
  {
    List<byte[]> numArrayList1 = CombineTool.Decode(this.operation.cruncherData.RestoreTargetPbaFile);
    AstroDeviceInfo astroDeviceInfo1 = (AstroDeviceInfo) CombineTool.ByteArrayToObject(numArrayList1[1]);
    PbaObject pbaObject_HandleLP = PbaObject.DeserializeFromBytes(numArrayList1[0]);
    List<byte[]> numArrayList2 = CombineTool.Decode(this.operation.cruncherData.pbaFile);
    AstroDeviceInfo astroDeviceInfo2 = (AstroDeviceInfo) CombineTool.ByteArrayToObject(numArrayList2[1]);
    PbaObject pbaObject = PbaObject.DeserializeFromBytes(numArrayList2[0]);
    Codeplug lastCodeplug = this.operation.cruncherData.LastCodeplug;
    if (!this.ReadMC(this.operation.targetArchive))
      throw new ApplicationException("Failed to open template archive");
    List<ValidationField> validationFields = RadioOperationValidator.PopulateWriteValidationFields(pbaObject);
    this.UpdatePasswordValidationFields(validationFields);
    pbaObject_HandleLP.ValidationFields = validationFields;
    this.HandleLP(pbaObject, pbaObject_HandleLP);
    if (pbaObject_HandleLP.ValidationInfos == null)
      pbaObject_HandleLP.ValidationInfos = new List<ValidationInfo>();
    pbaObject_HandleLP.ValidationInfos.Add(new ValidationInfo("SoftwareVersion", lastCodeplug.FirmwareVersion, ValidationMethod.Equal));
    pbaObject_HandleLP.IsRetoreJob = true;
    pbaObject_HandleLP.Serialize(this.operation.targetFile);
  }

  private void UpdatePasswordValidationFields(List<ValidationField> validationFields)
  {
    List<ValidationField> list1 = validationFields.Where<ValidationField>((Func<ValidationField, bool>) (a => a.BlockType == (ushort) 1029 && a.OffsetInBits == 9U && a.LengthInBits == 1U)).ToList<ValidationField>();
    if (list1 == null || list1.Count == 0 || 1 != ((int) list1[0].Content[0] & 64 /*0x40*/) >> 6)
      return;
    List<ValidationField> list2 = validationFields.Where<ValidationField>((Func<ValidationField, bool>) (a => a.BlockType == (ushort) 1029 && a.OffsetInBits == 16U /*0x10*/ && a.LengthInBits == 528U)).ToList<ValidationField>();
    string readPassword = (this.operation.cruncherData.Radio as APXRadio).ReadPassword;
    string s = !string.IsNullOrEmpty(readPassword) ? new ReadWriteUtil().encryptMesg(readPassword) : string.Empty;
    byte[] numArray = new byte[66];
    byte[] bytes = Encoding.ASCII.GetBytes(s);
    bytes.CopyTo((Array) numArray, 0);
    byte num = 0;
    for (int length = bytes.Length; length < numArray.Length; ++length)
      numArray[length] = num;
    list2[0].ErrorToThrow = CommonErrorCode.PasswordValidationFails;
    list2[0].Content = numArray;
  }

  private void WriteJobProcess_OtherTypesOfJob(string inputFile, string outputArchive)
  {
    string newValue = (string) null;
    if (this.operation.Type == CruncherOperation.Operation.ARCHIVECLONE)
    {
      if (!this.ReadMC(this.operation.sourceFile))
        throw new ApplicationException("Failed to open template archive");
      Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation radioInformation = FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation;
      Motorola.MackinawCPS.CoreFeatures.DataWide.DataWide dataWide = FeatureManager.GetFeature(2028)[0] as Motorola.MackinawCPS.CoreFeatures.DataWide.DataWide;
      radioInformation.General.RadInfoGeneralSerialNumber_A9122.SetValue(this.operation.cruncherData.Radio.SerialNumber);
      this.operation.deviceInfo.CodeplugVersion = AppInfoManager.AppVersion;
      this.operation.deviceInfo.Family = Motorola.Common.Communication.CommonUtil.ProductFamily.AstroRadio;
      this.operation.deviceInfo.ModelNumber = radioInformation.General.RadInfoGeneralModelNumber_A8539.Value;
      this.operation.deviceInfo.SerialNumber = Convert.ToBase64String(Encoding.ASCII.GetBytes(radioInformation.General.RadInfoGeneralSerialNumber_A9122.Value));
      this.operation.deviceInfo.ConnectionInfo = new ConnectionInfo();
      this.operation.deviceInfo.ConnectionInfo.UniqueAddress = dataWide.General.DataWideGeneralSubscriberIPAddress1_A9222.UIValue;
      this.operation.deviceInfo.SoftwareVersion = radioInformation.General.RadInfoGeneralFirmwareVersion_A8124.Value;
      this.operation.deviceInfo.ESN = AESCryptoUtil.CIPHER_DEF_KEY;
      newValue = radioInformation.General.RadInfoGeneralSerialNumber_A9122Value;
      if (!this.SaveXPBA(this.operation.targetFile))
        throw new ApplicationException("Write or Clone radio failed");
      ((WindowMain) Application.Current.MainWindow).CloseFile();
      if (FlashDataManager.FlashDoc != null)
        FlashDataManager.FlashDoc.Clear();
      if (!this.legalCommandLine || this.operation.targetFile == null || this.operation.deviceInfo == null)
        throw new ApplicationException("Failed to open template archive");
      this.SetupVirtualDevice(this.operation.targetFile, this.operation.deviceInfo);
    }
    PbaObject pbaObject1 = PbaObject.DeserializeFrom(this.operation.targetFile);
    int? nullable1 = this.operation.cruncherData.Codeplug.ChangeIndicator;
    nullable1 = nullable1.HasValue ? new int?(nullable1.GetValueOrDefault() & 16 /*0x10*/) : new int?();
    int num1;
    if ((nullable1.GetValueOrDefault() != 0 ? 0 : (nullable1.HasValue ? 1 : 0)) != 0)
    {
      nullable1 = this.operation.cruncherData.Codeplug.ChangeIndicator;
      nullable1 = nullable1.HasValue ? new int?(nullable1.GetValueOrDefault() & 2) : new int?();
      num1 = nullable1.GetValueOrDefault() != 0 ? 1 : (!nullable1.HasValue ? 1 : 0);
    }
    else
      num1 = 0;
    bool flag1 = num1 != 0;
    UpgradeRadio upgrade = new UpgradeRadio((BackgroundWorker) null, flag1, this.operation.deviceInfo, this.operation.fwPackageDesc, this.operation.fwPackagePath);
    if (this.operation.Type == CruncherOperation.Operation.UPGRADE)
    {
      upgrade.fileHostVersion = this.operation.fwPackageDesc.SoftwareVersion;
      bool? firmwareUpgradeFile = this.operation.fwPackageDesc.IsFreonFirmwareUpgradeFile;
      int num2;
      if ((!firmwareUpgradeFile.GetValueOrDefault() ? 0 : (firmwareUpgradeFile.HasValue ? 1 : 0)) == 0)
      {
        firmwareUpgradeFile = this.operation.fwPackageDesc.IsOMAPFirmwareUpgradeFile;
        num2 = (!firmwareUpgradeFile.GetValueOrDefault() ? 0 : (firmwareUpgradeFile.HasValue ? 1 : 0)) == 0 ? 1 : 0;
      }
      else
        num2 = 0;
      if (num2 == 0)
      {
        upgrade.BBFBundleVersion = this.operation.fwPackageDesc.SoftwareVersion;
        upgrade.IsRadioTakesBBF = true;
      }
      else
        upgrade.IsRadioTakesBBF = false;
      upgrade.RadioHostVersion = this.operation.deviceInfo.SoftwareVersion;
      if (pbaObject1 == null)
        pbaObject1 = PbaObject.DeserializeFrom(this.operation.targetFile);
      upgrade.Connect();
      upgrade.BeginFlashUpgrade();
      IshItemCollection radioCodeplug = upgrade.ReadCodeplug();
      AppInfoManager.DragOperation = true;
      ((WindowMain) Application.Current.MainWindow).InitDocument();
      ((App) Application.Current).TheDocument.FileNew();
      upgrade.UnpackCodeplug(radioCodeplug);
      FlashCodeplug flashCodeplug = new FlashCodeplug();
      flashCodeplug.postCodeplugInitialization();
      string modelNumber = "";
      try
      {
        modelNumber = (FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation).General.RadInfoGeneralModelNumber_A8539Value;
      }
      catch (Exception ex)
      {
      }
      upgrade.PreUpgradeCodeplugHandler();
      this.SetRequiredFirmwareVersion(this.operation, upgrade);
      string str = "";
      bool IsModelNumberUpgrade = false;
      string ibtnSerialNumber = "";
      int? nullable2 = this.operation.cruncherData.Codeplug.ChangeIndicator;
      nullable2 = nullable2.HasValue ? new int?(nullable2.GetValueOrDefault() & 16 /*0x10*/) : new int?();
      if ((nullable2.GetValueOrDefault() != 0 ? 1 : (!nullable2.HasValue ? 1 : 0)) != 0)
      {
        byte[] purchasedFlashCode = (this.operation.cruncherData.Codeplug as APXCodeplug).AstroPurchasedFlashCode;
        str = FlashcodeFormatter.FormatFlashcodeString(purchasedFlashCode, purchasedFlashCode.Length);
        ibtnSerialNumber = (this.operation.cruncherData.Codeplug as APXCodeplug).iButtonSerialNumber;
        if (!flashCodeplug.UpgradeCodeplug(modelNumber, str, IsModelNumberUpgrade, false))
          throw new ApplicationException("Codeplug upgrade failed.");
      }
      upgrade.PostUpgradeCodeplugHandler(str);
      upgrade.ApplyModelTiering();
      ConstraintManager.Suspend();
      flashCodeplug.SetPostFlashCodeplugFields(ibtnSerialNumber);
      this.SaveXPBA(this.operation.targetFile);
    }
    if (!this.ReadMC(this.operation.targetArchive))
      throw new ApplicationException("Failed to open template archive");
    PageCloneWizard pageCloneWizard = new PageCloneWizard();
    CloneParameters.CloneWriteType = COMMS_OP.USB_CLONE;
    RadioIdInfo TempRadioIds = this.ApplyCodeplugAndDeviceColumnsInWrite(this.operation.cruncherData.Radio as APXRadio, this.operation.cruncherData.Codeplug as APXCodeplug, this.operation.cruncherData.Template as APXTemplate);
    if (this.operation.Type == CruncherOperation.Operation.UPGRADE)
      TempRadioIds.IsManagedUpgrade = true;
    pageCloneWizard.SaveRadioIdsInCruncher(TempRadioIds);
    if (AppInfoManager.InvalidFieldsReport.HasFields)
      throw new ApplicationException("Failed to apply codeplug columns");
    bool flag2;
    if (this.operation.Type == CruncherOperation.Operation.WRITE || this.operation.Type == CruncherOperation.Operation.ARCHIVECLONE || this.operation.Type == CruncherOperation.Operation.UPGRADE)
    {
      if (newValue != null)
        (FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation).General.RadInfoGeneralSerialNumber_A9122.SetValue(newValue);
      flag2 = pageCloneWizard.CommandLineCPSCloneProcedure();
      if (flag2)
      {
        WindowMain mainWindow = (WindowMain) Application.Current.MainWindow;
        mainWindow.CloseFile();
        if (FlashDataManager.FlashDoc != null)
          FlashDataManager.FlashDoc.Clear();
        if (!mainWindow.CruncherReadRadio(0, true))
          throw new ApplicationException("Cannot read the pba file");
      }
    }
    else
      flag2 = false;
    if (!flag2)
      throw new ApplicationException("Write or Clone radio failed");
    this.SaveMC(outputArchive);
    using (FileStream fileStream = System.IO.File.OpenRead(outputArchive))
    {
      this.operation.cruncherData.arvFile = new byte[fileStream.Length];
      fileStream.Read(this.operation.cruncherData.arvFile, 0, this.operation.cruncherData.arvFile.Length);
    }
    AstroDeviceInfo updatedDeviceInfo = (AstroDeviceInfo) null;
    if (this.operation.Type == CruncherOperation.Operation.UPGRADE)
    {
      PbaObject pbaObject2 = PbaObject.DeserializeFrom(this.operation.targetFile);
      pbaObject2.ValidationFields = flag1 ? RadioOperationValidator.PopulateWriteValidationFields(pbaObject1) : RadioOperationValidator.PopulateUpgradeValidationFields(pbaObject1);
      pbaObject2.ValidationInfos = RadioOperationValidator.PopulateUpgradeValidationInfos(pbaObject1, this.operation.cruncherData.Codeplug as APXCodeplug, flag1);
      pbaObject2.UpdateData = upgrade.BuildUpdateDataForCruncher(out updatedDeviceInfo);
      pbaObject2.Serialize(this.operation.targetFile);
    }
    if (!this.operation.cruncherData.Codeplug.ChangeIndicator.HasValue)
      throw new CommonException(CommonErrorCode.AstroCruncherInputfileError);
    PbaObject pbaObject_HandleLP = PbaObject.DeserializeFrom(this.operation.targetFile);
    this.HandleLP(pbaObject1, pbaObject_HandleLP);
    this.UpdatePasswordValidationFields(pbaObject_HandleLP.ValidationFields);
    pbaObject_HandleLP.Serialize(this.operation.targetFile);
    if (updatedDeviceInfo != null)
      this.operation.deviceInfo = updatedDeviceInfo;
    if (pbaObject1 != null)
      this.operation.deviceInfo.ConnectionInfo.SessionID = pbaObject1.CodeplugData.ArchiveSessionID;
    MackinawCPS.CommonUtility.PopulatecpAndDeviceColumnsFromDatabaseLayerForCruncherWrite(this.operation.cruncherData, this.operation.Type);
  }

  public void SetRequiredFirmwareVersion(CruncherOperation operation, UpgradeRadio upgrade)
  {
    try
    {
      Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide radioWide = FeatureManager.GetFeature(2045)[0] as Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide;
      radioWide.Labtool.RadioWideReqFWVersion_A42872.SetValue("");
      if (operation == null || upgrade == null)
        return;
      int? nullable = operation.cruncherData.Codeplug.ChangeIndicator;
      nullable = nullable.HasValue ? new int?(nullable.GetValueOrDefault() & 2) : new int?();
      if ((nullable.GetValueOrDefault() != 0 ? 1 : (!nullable.HasValue ? 1 : 0)) != 0 && operation.fwPackageDesc != null && !string.IsNullOrEmpty(operation.fwPackageDesc.SoftwareVersion))
      {
        AstroDeviceInfo updatedDeviceInfo = (AstroDeviceInfo) null;
        if (upgrade.BuildUpdateDataForCruncher(out updatedDeviceInfo).MemoryImages.Any<RadioImage>())
          radioWide.Labtool.RadioWideReqFWVersion_A42872.SetValue(operation.fwPackageDesc.SoftwareVersion);
      }
    }
    catch (Exception ex)
    {
      throw new ApplicationException("Failed to set Required Firmware Version.");
    }
  }

  private void HandleLP(PbaObject oldPBAObject, PbaObject pbaObject_HandleLP)
  {
    int num = this.operation.cruncherData.Codeplug.ChangeIndicator.Value;
    Guid? nullable = new Guid?();
    if ((num & 8) != 0)
    {
      ASTROLanguagePack astroLanguagePack = (this.operation.cruncherData.Template as APXTemplate).ASTROLanguagePack;
      if (astroLanguagePack != null)
        nullable = astroLanguagePack.FileUuid;
      if (oldPBAObject != null)
      {
        pbaObject_HandleLP.GenerateDifferetialCodeplug(oldPBAObject);
        pbaObject_HandleLP.CodeplugData.ArchiveSessionID = oldPBAObject.CodeplugData.ArchiveSessionID;
      }
      else
        pbaObject_HandleLP.CodeplugData.ArchiveSessionID = (ushort) 0;
      LanguagePackData languagePackData = new LanguagePackData();
      languagePackData.ModelType = UtilityMack.IsPortablePro ? ModelType.Portable : ModelType.Mobile;
      if (this.operation.Type == CruncherOperation.Operation.UPGRADE && LanguagePackHelper.IsRadioUpgradeHostGreaterThan_7_12(this.operation.cruncherData.LastCodeplug.FirmwareVersion, this.operation.fwPackageDesc.SoftwareVersion))
      {
        pbaObject_HandleLP.ValidationInfos.AddRange((IEnumerable<ValidationInfo>) RadioOperationValidator.PopulateLPValidationInfos(oldPBAObject, this.operation.cruncherData.LastCodeplug as APXCodeplug));
        if (nullable.HasValue)
        {
          List<LanguagePackBase> languagePacks = languagePackData.LanguagePacks;
          AstroFilePackInfo astroFilePackInfo1 = new AstroFilePackInfo();
          astroFilePackInfo1.sourceFilePath = nullable.Value.ToString();
          astroFilePackInfo1.isFlashPortUpgradeLP = true;
          AstroFilePackInfo astroFilePackInfo2 = astroFilePackInfo1;
          languagePacks.Add((LanguagePackBase) astroFilePackInfo2);
        }
      }
      else if (this.operation.Type != CruncherOperation.Operation.UPGRADE && (this.operation.Type == CruncherOperation.Operation.WRITE || this.operation.Type == CruncherOperation.Operation.ARCHIVECLONE))
      {
        if (nullable.HasValue)
        {
          pbaObject_HandleLP.ValidationInfos = RadioOperationValidator.PopulateLPValidationInfos(oldPBAObject, this.operation.cruncherData.LastCodeplug as APXCodeplug);
          List<LanguagePackBase> languagePacks = languagePackData.LanguagePacks;
          AstroFilePackInfo astroFilePackInfo3 = new AstroFilePackInfo();
          astroFilePackInfo3.sourceFilePath = nullable.Value.ToString();
          astroFilePackInfo3.isFlashPortUpgradeLP = false;
          AstroFilePackInfo astroFilePackInfo4 = astroFilePackInfo3;
          languagePacks.Add((LanguagePackBase) astroFilePackInfo4);
        }
        else
        {
          List<LanguagePackBase> languagePacks = languagePackData.LanguagePacks;
          AstroFilePackInfo astroFilePackInfo5 = new AstroFilePackInfo();
          astroFilePackInfo5.sourceFilePath = string.Empty;
          astroFilePackInfo5.isFlashPortUpgradeLP = false;
          AstroFilePackInfo astroFilePackInfo6 = astroFilePackInfo5;
          languagePacks.Add((LanguagePackBase) astroFilePackInfo6);
        }
      }
      else
        languagePackData = (LanguagePackData) null;
      pbaObject_HandleLP.LanguagePackData = languagePackData;
    }
    else
    {
      if (oldPBAObject != null)
      {
        pbaObject_HandleLP.GenerateDifferetialCodeplug(oldPBAObject);
        pbaObject_HandleLP.CodeplugData.ArchiveSessionID = oldPBAObject.CodeplugData.ArchiveSessionID;
      }
      else
        pbaObject_HandleLP.CodeplugData.ArchiveSessionID = (ushort) 0;
      pbaObject_HandleLP.LanguagePackData = (LanguagePackData) null;
      if ((this.operation.cruncherData.Template as APXTemplate).LanguageIndex.Value != 0)
      {
        if (pbaObject_HandleLP.ValidationInfos == null)
          pbaObject_HandleLP.ValidationInfos = new List<ValidationInfo>();
        pbaObject_HandleLP.ValidationInfos.AddRange((IEnumerable<ValidationInfo>) RadioOperationValidator.PopulateValidationInfosForRegularWrite(oldPBAObject, this.operation.cruncherData.LastCodeplug as APXCodeplug));
        string firmwareVersion = (this.operation.cruncherData.Codeplug as APXCodeplug).FirmwareVersion;
        if (new Regex("(\\d+\\.\\d+\\.\\d+)").Match(firmwareVersion).Success && LanguagePackHelper.IsNeedBindingServerLanguagePack(firmwareVersion))
        {
          ValidationField validationField = RadioOperationValidator.PopulateLanguageSettingValidationField(oldPBAObject);
          if (validationField != null)
          {
            if (pbaObject_HandleLP.ValidationFields != null)
            {
              pbaObject_HandleLP.ValidationFields.Add(validationField);
            }
            else
            {
              pbaObject_HandleLP.ValidationFields = new List<ValidationField>();
              pbaObject_HandleLP.ValidationFields.Add(validationField);
            }
          }
        }
      }
    }
  }

  private bool CruncherCreate(string inputFile)
  {
    this.Report("[Cruncher][Information][Begin][CruncherCreate]");
    string str = Path.Combine(this.folderName, Guid.NewGuid().ToString() + ".mc");
    try
    {
      if (this.operation.targetArchive != null && this.operation.targetArchive.EndsWith(".mc"))
      {
        if (!this.ReadMC(this.operation.targetArchive))
          throw new ApplicationException("Failed to open template archive");
      }
      else if (this.operation.targetFile != null && this.operation.targetFile.EndsWith(".xpba"))
        ((WindowMain) Application.Current.MainWindow).CruncherReadRadio(0);
      Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation radioInformation = FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation;
      Motorola.MackinawCPS.CoreFeatures.DataWide.DataWide dataWide = FeatureManager.GetFeature(2028)[0] as Motorola.MackinawCPS.CoreFeatures.DataWide.DataWide;
      if (this.createSerialNumber != null)
        radioInformation.General.RadInfoGeneralSerialNumber_A9122.Value = this.createSerialNumber;
      this.operation.deviceInfo.CodeplugVersion = AppInfoManager.AppVersion;
      this.operation.deviceInfo.Family = Motorola.Common.Communication.CommonUtil.ProductFamily.AstroRadio;
      this.operation.deviceInfo.ModelNumber = radioInformation.General.RadInfoGeneralModelNumber_A8539.Value;
      this.operation.deviceInfo.SerialNumber = Convert.ToBase64String(Encoding.ASCII.GetBytes(radioInformation.General.RadInfoGeneralSerialNumber_A9122.Value));
      this.operation.deviceInfo.ConnectionInfo = new ConnectionInfo();
      this.operation.deviceInfo.ConnectionInfo.UniqueAddress = dataWide.General.DataWideGeneralSubscriberIPAddress1_A9222.UIValue;
      this.operation.deviceInfo.SoftwareVersion = radioInformation.General.RadInfoGeneralFirmwareVersion_A8124.Value;
      this.operation.deviceInfo.ESN = Encoding.ASCII.GetBytes("ABCD1234");
      if (!this.SaveXPBA(this.operation.targetFile))
        throw new ApplicationException("Write or Clone radio failed");
      if (FlashDataManager.FlashDoc != null)
        FlashDataManager.FlashDoc.Clear();
      this.SaveMC(str);
      using (FileStream fileStream = System.IO.File.OpenRead(str))
      {
        this.operation.cruncherData.arvFile = new byte[fileStream.Length];
        fileStream.Read(this.operation.cruncherData.arvFile, 0, this.operation.cruncherData.arvFile.Length);
      }
      APXCodeplug codeplug = this.operation.cruncherData.Codeplug as APXCodeplug;
      if (this.operation.cruncherData.Radio == null)
        this.operation.cruncherData.Radio = (Radio) new APXRadio();
      Radio radio = this.operation.cruncherData.Radio;
      string firmwareVersion = codeplug.FirmwareVersion;
      MackinawCPS.CommonUtility.PopulatecpAndDeviceColumnsFromDatabaseLayer(codeplug, radio, PopulateOpeartion.Import);
      if (codeplug.ASTROFirmware != null && codeplug.ASTROFirmware.RMFile.Url != null)
      {
        ASTROFirmware astroFirmware = codeplug.ASTROFirmware;
        RMCWnd.AnaysisFirmwarePackage(codeplug.ASTROFirmware.RMFile.Url, ref astroFirmware);
        codeplug.FirmwareVersion = firmwareVersion;
        PbaObject xpbaCodeplug = PbaObject.DeserializeFrom(this.operation.targetFile);
        xpbaCodeplug.ValidationFields = RadioOperationValidator.PopulateUpgradeValidationFields(xpbaCodeplug);
        xpbaCodeplug.ValidationInfos = RadioOperationValidator.PopulateUpgradeValidationInfos(xpbaCodeplug, this.operation.cruncherData.Codeplug as APXCodeplug, true);
        xpbaCodeplug.Serialize(this.operation.targetFile);
      }
      this.operation.cruncherData.pbaFile = CombineTool.Encode(this.operation.targetFile, (object) this.operation.deviceInfo);
      if (this.operation.cruncherData.Template is APXTemplate template && template.ASTROLanguagePack != null && template.ASTROLanguagePack.RMFile.Url != null && System.IO.File.Exists(template.ASTROLanguagePack.RMFile.Url))
        LanguagePackHelper.ParseLanguagePackage(template.ASTROLanguagePack.RMFile.Url);
      if (template.ASTROVoiceAnnouncements == null)
        template.ASTROVoiceAnnouncements = new List<ASTROVoiceAnnouncement>();
      else
        template.ASTROVoiceAnnouncements.Clear();
      ASTROVoiceAnnouncement[] newVaPackageData = VAHelper.GenerateNewVAPackageData(new List<Package>().ToArray(), this.folderName);
      if (newVaPackageData != null)
      {
        foreach (ASTROVoiceAnnouncement voiceAnnouncement in newVaPackageData)
          template.ASTROVoiceAnnouncements.Add(voiceAnnouncement);
      }
      ObjectSerializer.DataContract_SerializeToFile(inputFile, (object) this.operation.cruncherData);
      this.Report("[Cruncher][Success][CruncherCreate]: Clone radio express completed");
    }
    catch (Exception ex)
    {
      this.Report("[Cruncher][Exception][CruncherCreate]: " + ex.Message);
      if (ex.Message == "Failed to apply codeplug columns")
        this.CreateErrorOutput(inputFile, 22010);
      else if (ex.Message == "Failed to open template archive")
        this.CreateErrorOutput(inputFile, 22012);
      else
        this.CreateErrorOutput(inputFile, 22005);
      this.FireError(Cruncher.Error.Fail);
    }
    finally
    {
      this.DeleteTempFile(str);
      this.DeleteTempFile(this.operation.sourceFile);
      this.DeleteTempFile(this.operation.targetFile);
      this.DeleteTempFile(this.operation.targetArchive);
      this.Report("[Cruncher][Information][End][CruncherCreate]");
    }
    return true;
  }

  private RadioIdInfo ApplyCodeplugAndDeviceColumnsInWrite(
    APXRadio radio,
    APXCodeplug currentcp,
    APXTemplate currentTpl)
  {
    this.Report("[Cruncher][Information][Begin][ApplyCodeplugAndDeviceColumnsInWrite]");
    RadioIdInfo radioIdInfo = new RadioIdInfo();
    try
    {
      (FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation).General.RadInfoGeneralSerialNumber_A9122.Value = radio.SerialNumber;
      (FeatureManager.GetFeature(2010)[0] as Motorola.MackinawCPS.CoreFeatures.DisplayAndMenu.DisplayAndMenu).Advanced.DispMenuAdvancedLanguageSelection_A8386Value = currentTpl.LanguageIndex.Value;
      Motorola.MackinawCPS.CoreFeatures.DataWide.DataWide dataWide = FeatureManager.GetFeature(2028)[0] as Motorola.MackinawCPS.CoreFeatures.DataWide.DataWide;
      if (!string.IsNullOrEmpty(currentcp.PeerIP))
        dataWide.General.DataWideGeneralPeerIPAddress1_A8524.SetValue(IPAddress.Parse(currentcp.PeerIP).Address);
      if (!string.IsNullOrEmpty(currentcp.SubscriberIP))
        dataWide.General.DataWideGeneralSubscriberIPAddress1_A9222.SetValue(IPAddress.Parse(currentcp.SubscriberIP).Address);
      if (!string.IsNullOrEmpty(currentcp.BluetoothDUNPeerIP))
        dataWide.General.DataWideGeneralBTDUNPeerIPAddress_A41123.SetValue(IPAddress.Parse(currentcp.BluetoothDUNPeerIP).Address);
      if (!string.IsNullOrEmpty(currentcp.BluetoothDUNSubscriberIP))
        dataWide.General.DataWideGeneralBTDUNSUIPAddress_A41120.SetValue(IPAddress.Parse(currentcp.BluetoothDUNSubscriberIP).Address);
      this.ApplyPasswordToBLDoc(currentcp);
      Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide radioWide = (Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide) FeatureManager.GetFeature(2045)[0];
      bool? nullable1 = currentcp.DisableWriteProtect;
      int num1;
      if (nullable1.HasValue)
      {
        bool flag = radioWide.Depot.AdvancedExternalMicOnly.Value;
        nullable1 = currentcp.DisableWriteProtect;
        num1 = (flag != nullable1.GetValueOrDefault() ? 1 : (!nullable1.HasValue ? 1 : 0)) == 0 ? 1 : 0;
      }
      else
        num1 = 1;
      if (num1 == 0)
      {
        AcpField<bool> advancedExternalMicOnly = radioWide.Depot.AdvancedExternalMicOnly;
        nullable1 = currentcp.DisableWriteProtect;
        int num2 = nullable1.Value ? 1 : 0;
        advancedExternalMicOnly.SetValue(num2 != 0);
      }
      int? nullable2 = currentcp.OwnerAdvKeyType;
      int num3;
      if (nullable2.HasValue)
      {
        int num4 = radioWide.General.RadWideGeneralOwnerAdvancedKeyType_A38663.Value;
        nullable2 = currentcp.OwnerAdvKeyType;
        num3 = (num4 != nullable2.GetValueOrDefault() ? 1 : (!nullable2.HasValue ? 1 : 0)) == 0 ? 1 : 0;
      }
      else
        num3 = 1;
      if (num3 == 0)
      {
        AcpListField advancedKeyTypeA38663 = radioWide.General.RadWideGeneralOwnerAdvancedKeyType_A38663;
        nullable2 = currentcp.OwnerAdvKeyType;
        int newValue = nullable2.Value;
        advancedKeyTypeA38663.SetValue(newValue);
      }
      nullable2 = currentcp.OwnerWacnId;
      int num5;
      if (nullable2.HasValue)
      {
        int num6 = radioWide.General.RadWideGeneralOwnerWACNID_A38656.Value;
        nullable2 = currentcp.OwnerWacnId;
        num5 = (num6 != nullable2.GetValueOrDefault() ? 1 : (!nullable2.HasValue ? 1 : 0)) == 0 ? 1 : 0;
      }
      else
        num5 = 1;
      if (num5 == 0)
      {
        AcpSimpleRangeField ownerWacnidA38656 = radioWide.General.RadWideGeneralOwnerWACNID_A38656;
        nullable2 = currentcp.OwnerWacnId;
        int newValue = nullable2.Value;
        ownerWacnidA38656.SetValue(newValue);
      }
      nullable2 = currentcp.HomeSystemId;
      int num7;
      if (nullable2.HasValue)
      {
        int num8 = radioWide.General.RadWideGeneralOwnerSystemID_A37153.Value;
        nullable2 = currentcp.HomeSystemId;
        num7 = (num8 != nullable2.GetValueOrDefault() ? 1 : (!nullable2.HasValue ? 1 : 0)) == 0 ? 1 : 0;
      }
      else
        num7 = 1;
      if (num7 == 0)
      {
        AcpSimpleRangeField ownerSystemIdA37153 = radioWide.General.RadWideGeneralOwnerSystemID_A37153;
        nullable2 = currentcp.HomeSystemId;
        int newValue = nullable2.Value;
        ownerSystemIdA37153.SetValue(newValue);
      }
      nullable1 = currentcp.AskRequired;
      int num9;
      if (nullable1.HasValue)
      {
        bool flag = radioWide.General.RadWideGeneralASKRequired_A37152.Value;
        nullable1 = currentcp.AskRequired;
        num9 = (flag != nullable1.GetValueOrDefault() ? 1 : (!nullable1.HasValue ? 1 : 0)) == 0 ? 1 : 0;
      }
      else
        num9 = 1;
      if (num9 == 0)
      {
        AcpField<bool> askRequiredA37152 = radioWide.General.RadWideGeneralASKRequired_A37152;
        nullable1 = currentcp.AskRequired;
        int num10 = nullable1.Value ? 1 : 0;
        askRequiredA37152.SetValue(num10 != 0);
      }
      TrunkingSystemRecset feature1 = FeatureManager.GetFeature(2064) as TrunkingSystemRecset;
      APXRadioSystem[] apxRadioSystemArray = new APXRadioSystem[0];
      if (currentcp.APXRadioSystems.Count > 0)
        apxRadioSystemArray = currentcp.APXRadioSystems.OrderBy<APXRadioSystem, int?>((Func<APXRadioSystem, int?>) (sys => sys.OrderId)).ToArray<APXRadioSystem>();
      APXDataProfile[] apxDataProfileArray = new APXDataProfile[0];
      if (currentcp.APXDataProfiles.Count > 0)
        apxDataProfileArray = currentcp.APXDataProfiles.OrderBy<APXDataProfile, int?>((Func<APXDataProfile, int?>) (prf => prf.OrderId)).ToArray<APXDataProfile>();
      foreach (APXRadioSystem apxRadioSystem in apxRadioSystemArray)
      {
        AstroSystemType? systemType = apxRadioSystem.SystemType;
        if ((systemType.GetValueOrDefault() != AstroSystemType.CONVENTIONAL ? 0 : (systemType.HasValue ? 1 : 0)) == 0)
        {
          foreach (Motorola.MackinawCPS.CoreFeatures.TrunkingSystem.TrunkingSystem trunkingSystem in (Collection<AcpBusinessLayer.FeatureNode>) feature1)
          {
            if (trunkingSystem.General.TrkSysGeneralKeyofTrunkingSystem_A12658.Value == apxRadioSystem.SystemName && trunkingSystem.TypeIIChannelSetup.TrkSysTypeIIChannelSetupShuffledBandPlan_A9128.IsVisible((IAcpFeatureSection) trunkingSystem.TypeIIChannelSetup))
            {
              bool shuffledBandPlanA9128_1 = (bool) trunkingSystem.TypeIIChannelSetup.TrkSysTypeIIChannelSetupShuffledBandPlan_A9128;
              nullable1 = apxRadioSystem.ShuffeledBandPlan;
              if ((shuffledBandPlanA9128_1 != nullable1.GetValueOrDefault() ? 1 : (!nullable1.HasValue ? 1 : 0)) != 0)
              {
                AcpField<bool> shuffledBandPlanA9128_2 = trunkingSystem.TypeIIChannelSetup.TrkSysTypeIIChannelSetupShuffledBandPlan_A9128;
                nullable1 = apxRadioSystem.ShuffeledBandPlan;
                int num11 = !nullable1.GetValueOrDefault() ? 0 : (nullable1.HasValue ? 1 : 0);
                shuffledBandPlanA9128_2.SetValue(num11 != 0);
                break;
              }
              break;
            }
          }
        }
      }
      RMUtilities.PopulateAstroCpsASKProgrammingHistoryRecset(currentcp.AstroSysKeyLog);
      IAcpRecordset feature2 = FeatureManager.GetFeature(2054);
      for (int index = 0; index < feature2.Count; ++index)
      {
        Motorola.MackinawCPS.CoreFeatures.DataProfiles.DataProfiles RefDataProfile = feature2[index] as Motorola.MackinawCPS.CoreFeatures.DataProfiles.DataProfiles;
        if (apxDataProfileArray.Length > index)
          RMUtilities.PopulateAstroCpsTrunkingGroupIDs(ref RefDataProfile, apxDataProfileArray[index].TrunkingGroupIds);
      }
      radioIdInfo.TrkSysIds = new Dictionary<string, int[]>();
      radioIdInfo.CnvSysIds = new Dictionary<string, int[]>();
      radioIdInfo.AstroOtarRadioIds = new Dictionary<string, int>();
      radioIdInfo.DataProfIps = new DataProfIP[apxDataProfileArray.Length];
      radioIdInfo.RadioAlias = currentcp.RadioAlias != null ? currentcp.RadioAlias : string.Empty;
      radioIdInfo.BluetoothFriendlyName = currentcp.BluetoothFriendlyName != null ? currentcp.BluetoothFriendlyName : string.Empty;
      radioIdInfo.ESerialNumber = new byte[this.operation.deviceInfo.ESN.Length];
      Array.Copy((Array) this.operation.deviceInfo.ESN, (Array) radioIdInfo.ESerialNumber, this.operation.deviceInfo.ESN.Length);
      byte[] pbaBytes = this.GetPbaBytes(this.operation.cruncherData);
      if (pbaBytes != null)
      {
        PbaObject pba = PbaObject.DeserializeFromBytes(pbaBytes);
        radioIdInfo.IsEncryptedPwd = ParseDataHelper.ReadEncryptPasswordFlag(pba);
      }
      else
        radioIdInfo.IsEncryptedPwd = radioWide.Labtool.RadWideLabtoolEncryptPassword_A41695.Value;
      if (string.IsNullOrEmpty(currentcp.UserPIN))
      {
        currentcp.UserPIN = string.Empty;
        currentcp.UserPIN = AESCryptoUtil.AESEncryptWithDefKey(currentcp.UserPIN);
      }
      string str = AESCryptoUtil.AESDecryptWithDefKey(currentcp.UserPIN);
      radioIdInfo.EncryptedPwd = currentcp.UserPIN;
      radioIdInfo.SoftIds = new string[4]
      {
        currentcp.UserName != null ? currentcp.UserName : string.Empty,
        str.Length > 4 ? str.Substring(0, 4) : str.Substring(0, str.Length),
        str.Length > 4 ? str.Substring(4) : "",
        currentcp.UserLoginUnitID != null ? currentcp.UserLoginUnitID : string.Empty
      };
      foreach (APXRadioSystem apxRadioSystem in apxRadioSystemArray)
      {
        AstroSystemType? systemType = apxRadioSystem.SystemType;
        AstroSystemSubType? systemSubType;
        if ((systemType.GetValueOrDefault() != AstroSystemType.CONVENTIONAL ? 0 : (systemType.HasValue ? 1 : 0)) != 0)
        {
          int num12 = 0;
          systemSubType = apxRadioSystem.SystemSubType;
          if ((systemSubType.GetValueOrDefault() != AstroSystemSubType.ASTRO ? 0 : (systemSubType.HasValue ? 1 : 0)) != 0)
          {
            num12 = 0;
          }
          else
          {
            systemSubType = apxRadioSystem.SystemSubType;
            if ((systemSubType.GetValueOrDefault() != AstroSystemSubType.MDC ? 0 : (systemSubType.HasValue ? 1 : 0)) != 0)
            {
              num12 = 1;
            }
            else
            {
              systemSubType = apxRadioSystem.SystemSubType;
              if ((systemSubType.GetValueOrDefault() != AstroSystemSubType.DVRS ? 0 : (systemSubType.HasValue ? 1 : 0)) != 0)
                num12 = 2;
            }
          }
          Dictionary<string, int[]> cnvSysIds = radioIdInfo.CnvSysIds;
          string systemName = apxRadioSystem.SystemName;
          int[] numArray1 = new int[2]{ num12, 0 };
          int[] numArray2 = numArray1;
          nullable2 = apxRadioSystem.RadioId;
          int num13 = nullable2.Value;
          numArray2[1] = num13;
          int[] numArray3 = numArray1;
          cnvSysIds.Add(systemName, numArray3);
        }
        else
        {
          int num14 = 0;
          systemSubType = apxRadioSystem.SystemSubType;
          if ((systemSubType.GetValueOrDefault() != AstroSystemSubType.TYPEII ? 0 : (systemSubType.HasValue ? 1 : 0)) != 0)
          {
            num14 = 2;
          }
          else
          {
            systemSubType = apxRadioSystem.SystemSubType;
            if ((systemSubType.GetValueOrDefault() != AstroSystemSubType.ASTRO25 ? 0 : (systemSubType.HasValue ? 1 : 0)) != 0)
              num14 = 3;
          }
          Dictionary<string, int[]> trkSysIds = radioIdInfo.TrkSysIds;
          string systemName = apxRadioSystem.SystemName;
          int[] numArray4 = new int[2]{ num14, 0 };
          int[] numArray5 = numArray4;
          nullable2 = apxRadioSystem.RadioId;
          int num15 = nullable2.Value;
          numArray5[1] = num15;
          int[] numArray6 = numArray4;
          trkSysIds.Add(systemName, numArray6);
        }
      }
      nullable2 = currentcp.OtarID;
      int num16;
      if (nullable2.HasValue)
      {
        nullable2 = currentcp.OtarID;
        num16 = string.IsNullOrEmpty(nullable2.ToString()) ? 1 : 0;
      }
      else
        num16 = 1;
      if (num16 == 0)
      {
        IAcpRecordset feature3 = FeatureManager.GetFeature(2055);
        for (int index = 0; index < feature3.Count; ++index)
        {
          Dictionary<string, int> astroOtarRadioIds = radioIdInfo.AstroOtarRadioIds;
          string kmfProfileA12663 = (string) (AcpField<string>) (feature3[index] as Motorola.MackinawCPS.CoreFeatures.SecureKMFProfile.SecureKMFProfile).ASTROOTARInformation.SecKmfProfASTROOTARInformationKeyofSecureKMFProfile_A12663;
          nullable2 = currentcp.OtarID;
          int num17 = nullable2.Value;
          astroOtarRadioIds.Add(kmfProfileA12663, num17);
        }
      }
      for (int index = 0; index < apxDataProfileArray.Length; ++index)
      {
        radioIdInfo.DataProfIps[index].DataProfName = apxDataProfileArray[index].Name;
        radioIdInfo.DataProfIps[index].PeerIP = IPAddress.Parse(apxDataProfileArray[index].PeerIP);
        radioIdInfo.DataProfIps[index].SubIP = IPAddress.Parse(apxDataProfileArray[index].SubscriberIP);
        radioIdInfo.DataProfIps[index].SubAirInterfaceIP = IPAddress.Parse(apxDataProfileArray[index].AirInterfaceAddress);
        radioIdInfo.DataProfIps[index].BTPeerIP = IPAddress.Parse(apxDataProfileArray[index].AstroBluetoothDunPeerIp);
        radioIdInfo.DataProfIps[index].BTSubIP = IPAddress.Parse(apxDataProfileArray[index].AstroBluetoothDunSubscriberIp);
      }
    }
    catch (Exception ex)
    {
      this.Report("[Cruncher][Exception][ApplyCodeplugAndDeviceColumnsInWrite]: " + ex.Message);
      throw new ApplicationException("Failed to apply codeplug columns");
    }
    this.Report("[Cruncher][Information][End][ApplyCodeplugAndDeviceColumnsInWrite]");
    return radioIdInfo;
  }

  private void ApplyPasswordToBLDoc(APXCodeplug codeplug)
  {
    if (!codeplug.PasswordPerDevice)
      return;
    ASTROPasswordPolicy passwordPolicy = codeplug.PasswordPolicy;
    bool newValue1 = (passwordPolicy & ASTROPasswordPolicy.Read) != ASTROPasswordPolicy.None;
    bool newValue2 = (passwordPolicy & ASTROPasswordPolicy.Write) != ASTROPasswordPolicy.None;
    bool newValue3 = (passwordPolicy & ASTROPasswordPolicy.Open) != ASTROPasswordPolicy.None;
    Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide radioWide = FeatureManager.GetFeature(2045)[0] as Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide;
    radioWide.Labtool.RadWideLabtoolRadioReadPasswordEnable_A8869.SetValue(newValue1);
    radioWide.Labtool.RadWideLabtoolRadioWritePasswordEnable_A8889.SetValue(newValue2);
    radioWide.Labtool.RadWideLabtoolArchiveReadPasswordEnable_A7462.SetValue(newValue3);
    if (!newValue1 && !newValue2 && !newValue3)
      radioWide.Labtool.RadWideLabtoolRadioPassword_A8837.SetValue(string.Empty);
    else if (string.IsNullOrEmpty(codeplug.CodeplugPassword))
      radioWide.Labtool.RadWideLabtoolRadioPassword_A8837.SetValue(string.Empty);
    else
      radioWide.Labtool.RadWideLabtoolRadioPassword_A8837.SetValue(new ReadWriteUtil().encryptMesg(codeplug.CodeplugPassword));
  }

  private bool CruncherRead(string inputFile)
  {
    this.Report("[Cruncher][Information][Begin][CruncherRead]");
    string str1 = Path.Combine(this.folderName, Guid.NewGuid().ToString() + ".mc");
    try
    {
      if (this.operation.cruncherData.Radio != null)
      {
        bool isUserPasswordEncrypted = false;
        WindowMain mainWindow = (WindowMain) Application.Current.MainWindow;
        string readPassword = (this.operation.cruncherData.Radio as APXRadio).ReadPassword;
        mainWindow.CruncherReadRadio(0);
        if (!this.operation.cruncherData.IsMigrationJob)
        {
          Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide radioWide = FeatureManager.GetFeature(2045)[0] as Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide;
          if (radioWide.Labtool.RadWideLabtoolRadioReadPasswordEnable_A8869Value)
          {
            if (readPassword == string.Empty)
            {
              Trace.WriteLine("[Cruncher][Exception][CruncherRead]: user password is empty");
              throw new ApplicationException("Read/Write password validation failed");
            }
            this.Report("[Cruncher][Information][CruncherRead][ValidateOKToUserPassword]");
            string numberA9122Value = (FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation).General.RadInfoGeneralSerialNumber_A9122Value;
            if (!ReadWritePasswordApp.ValidateOKToUserPassword(readPassword, radioWide.Labtool.RadWideLabtoolRadioPassword_A8837Value, isUserPasswordEncrypted, numberA9122Value))
            {
              Trace.WriteLine("[Cruncher][Exception][CruncherRead]: ValidateOKToUserPassword fail");
              throw new ApplicationException("Read/Write password validation failed");
            }
          }
        }
      }
      this.operation.sourceFile = str1;
      this.SaveMC(str1);
      if (this.operation.cruncherData.Codeplug == null)
        this.operation.cruncherData.Codeplug = (Codeplug) new APXCodeplug();
      if (this.operation.cruncherData.Template == null)
      {
        this.operation.cruncherData.Codeplug.Template = (Template) new APXTemplate();
        this.operation.cruncherData.Template = this.operation.cruncherData.Codeplug.Template;
      }
      APXTemplate template = this.operation.cruncherData.Template as APXTemplate;
      if (template.ASTROVoiceAnnouncements == null)
        template.ASTROVoiceAnnouncements = new List<ASTROVoiceAnnouncement>();
      else
        template.ASTROVoiceAnnouncements.Clear();
      Package[] vaPackages = this.operation.cruncherData.VAPackages;
      List<ASTROVoiceAnnouncement> existPackageData = VAHelper.GetExistPackageData(vaPackages);
      if (existPackageData != null)
      {
        foreach (ASTROVoiceAnnouncement voiceAnnouncement in existPackageData)
          template.ASTROVoiceAnnouncements.Add(voiceAnnouncement);
      }
      this.operation.cruncherData.VAPackages = (Package[]) VAHelper.GenerateNewVAPackageData(vaPackages, this.folderName);
      string str2 = string.Empty;
      try
      {
        List<byte[]> numArrayList = CombineTool.Decode(this.operation.cruncherData.pbaFile);
        AstroDeviceInfo deviceInfo = (AstroDeviceInfo) CombineTool.ByteArrayToObject(numArrayList[1]);
        PbaObject pbaObject = PbaObject.DeserializeFromBytes(numArrayList[0]);
        str2 = deviceInfo.RadioBBFSuiteVersion;
        int selectionA8386Value = (FeatureManager.GetFeature(2010)[0] as Motorola.MackinawCPS.CoreFeatures.DisplayAndMenu.DisplayAndMenu).Advanced.DispMenuAdvancedLanguageSelection_A8386Value;
        if (selectionA8386Value == 0 || !LanguagePackHelper.IsFirmwareLPCompatible(deviceInfo.SoftwareVersion, selectionA8386Value))
        {
          pbaObject.LanguagePackData = (LanguagePackData) null;
          string str3 = Path.Combine(this.folderName, Guid.NewGuid().ToString() + ".xpba");
          pbaObject.Serialize(str3);
          this.operation.cruncherData.pbaFile = CombineTool.Encode(str3, (object) deviceInfo);
          System.IO.File.Delete(str3);
        }
        if (pbaObject.LanguagePackData != null && pbaObject.LanguagePackData.LanguagePacks != null && pbaObject.LanguagePackData.LanguagePacks.Count > 0)
        {
          foreach (LanguagePackBase languagePack in pbaObject.LanguagePackData.LanguagePacks)
            this.ApplyLanguagePack(languagePack, deviceInfo, this.operation.cruncherData.Template as APXTemplate);
        }
      }
      catch
      {
      }
      using (FileStream fileStream = System.IO.File.OpenRead(str1))
      {
        this.operation.cruncherData.arvFile = new byte[fileStream.Length];
        fileStream.Read(this.operation.cruncherData.arvFile, 0, this.operation.cruncherData.arvFile.Length);
      }
      if (this.operation.cruncherData.Radio == null)
        this.operation.cruncherData.Radio = (Radio) new APXRadio();
      APXCodeplug codeplug = this.operation.cruncherData.Codeplug as APXCodeplug;
      APXRadio radio = this.operation.cruncherData.Radio as APXRadio;
      MackinawCPS.CommonUtility.PopulatecpAndDeviceColumnsFromDatabaseLayerForCruncherRead(codeplug, (Radio) radio);
      codeplug.UpgradeAbility = new bool?(true);
      codeplug.BBFBundleVersion = str2;
      codeplug.Template.BBFBundleVersion = str2;
      MackinawCPS.CommonUtility.SetFeatureSet(this.operation.cruncherData.Radio, radio.Uuid);
      this.operation.cruncherData.ErrorCode = new int?();
      this.EndExecuteCommand(this.operation.cruncherData);
      ObjectSerializer.DataContract_SerializeToFile(inputFile, (object) this.operation.cruncherData);
    }
    catch (Exception ex)
    {
      this.Report("[Cruncher][Exception][CruncherRead]: " + ex.Message);
      if (ex.Message == "Populate codeplug and device columns fails")
        this.CreateErrorOutput(inputFile, 22008);
      else if (ex.Message == "Cannot read the pba file")
        this.CreateErrorOutput(inputFile, 22009);
      else if (ex.Message == AppResources.The_radio_being_read_is_INHIBITED)
        this.CreateErrorOutput(inputFile, 22021);
      else if (ex.Message == AppResources.The_radio_being_read_is_KILLED)
        this.CreateErrorOutput(inputFile, 22022);
      else if (ex.Message == "Read/Write password validation failed")
        this.CreateErrorOutput(inputFile, 22013);
      else
        this.CreateErrorOutput(inputFile, 22006);
      this.FireError(Cruncher.Error.Fail);
    }
    finally
    {
      this.DeleteTempFile(str1);
      this.DeleteTempFile(this.operation.targetFile);
      this.Report("[Cruncher][Information][End][CruncherRead]");
    }
    return true;
  }

  private void ApplyLanguagePack(
    LanguagePackBase package,
    AstroDeviceInfo deviceInfo,
    APXTemplate template)
  {
    AstroFilePackInfo astroFilePackInfo = package as AstroFilePackInfo;
    string packID;
    string version;
    if (string.IsNullOrEmpty(astroFilePackInfo.radioFilePath) || !ASTROLanguageUtility.Instance.ParseLanguageIDAndVersion(astroFilePackInfo.radioFilePath, out packID, out version))
      return;
    ASTROLanguagePack astroLanguagePack = new ASTROLanguagePack();
    astroLanguagePack.PackageName = string.Empty;
    astroLanguagePack.LpID = packID;
    astroLanguagePack.PackageVersion = version;
    astroLanguagePack.ModifiedDate = astroLanguagePack.CreatedDate = new DateTime?(DateTime.UtcNow);
    astroLanguagePack.PackageLanguage = Motorola.CommonCPS.ResourceRepository.ResourceHelper.GetCommonErrorMessageByID(packID.Replace('-', '_'));
    astroLanguagePack.CompatibleVersion = deviceInfo.SoftwareVersion;
    template.LanguagePackUuid = new Guid?(astroLanguagePack.Uuid);
    template.ASTROLanguagePack = astroLanguagePack;
  }

  private bool ParseLanguageIDAndVersion(string source, out string packID, out string version)
  {
    if ("dat_" == source.Substring(0, 4))
    {
      source = source.Substring(4);
      packID = source.Substring(0, source.IndexOf('_'));
      source = source.Substring(source.IndexOf('_') + 1);
      version = source.Substring(0, source.LastIndexOf('.'));
      return true;
    }
    packID = string.Empty;
    version = string.Empty;
    return false;
  }

  private bool ReadMC(string fileName)
  {
    this.Report("[Cruncher][Information][Begin][ReadMC]");
    try
    {
      if (!((WindowMain) Application.Current.MainWindow).OpenCodeplug(Path.GetFullPath(fileName)))
      {
        this.Report("[Cruncher][Error][ReadMC]: " + fileName);
        return false;
      }
      AppInfoManager.InvalidFieldsReport.Clear();
      this.Report("[Cruncher][Success][ReadMC]: " + fileName);
    }
    catch (Exception ex)
    {
      this.Report("Cruncher][Exception][ReadMC]: " + ex.Message);
      this.FireError(Cruncher.Error.Fail);
    }
    this.Report("[Cruncher][Information][End][ReadMC]");
    return true;
  }

  private bool SaveMC(string fileName)
  {
    this.Report("[Cruncher][Information][Begin][SaveMC]");
    try
    {
      if (!System.IO.File.Exists(fileName))
        System.IO.File.Create(fileName).Close();
      App current = (App) Application.Current;
      current.TheDocument.docFileName = Path.GetFileName(fileName);
      current.TheDocument.docFilePath = Path.GetFullPath(fileName);
      ((WindowMain) Application.Current.MainWindow).OnAppMenuSave(this.tempSender, this.tempArgs);
      this.Report("[Cruncher][Success][SaveMC]: " + fileName);
    }
    catch (Exception ex)
    {
      this.Report("[Cruncher][Exception][SaveMC]: " + ex.Message);
      return false;
    }
    this.Report("[Cruncher][Information][End][SaveMC]");
    return true;
  }

  private bool ReadXPBA(string fileName)
  {
    this.Report("[Cruncher][Information][Begin][ReadXPBA]");
    try
    {
      if (!((WindowMain) Application.Current.MainWindow).OpenCodeplug(Path.GetFullPath(fileName)))
      {
        this.Report("[Cruncher][Error][ReadXPBA]: " + fileName);
        return false;
      }
      this.Report("[Cruncher][Success][ReadXPBA]: " + fileName);
    }
    catch (Exception ex)
    {
      this.Report("[Cruncher][Exception][ReadXPBA]: " + ex.Message);
      this.FireError(Cruncher.Error.Fail);
    }
    this.Report("[Cruncher][Information][End][ReadXPBA]");
    return true;
  }

  private bool SaveXPBA(string fileName)
  {
    this.Report("[Cruncher][Information][Begin][SaveXPBA]");
    try
    {
      if (!System.IO.File.Exists(fileName))
        System.IO.File.Create(fileName).Close();
      App current = (App) Application.Current;
      current.TheDocument.docFileName = fileName;
      current.TheDocument.docFilePath = fileName;
      ((WindowMain) Application.Current.MainWindow).OnAppMenuSave(this.tempSender, this.tempArgs);
      this.Report("[Cruncher][Success][SaveXPBA]: " + fileName);
    }
    catch (Exception ex)
    {
      this.Report("[Cruncher][Exception][SaveXPBA]: " + ex.Message);
      return false;
    }
    this.Report("[Cruncher][Information][End][SaveXPBA]");
    return true;
  }

  internal bool UnpackXPBA(byte[] pbaByte)
  {
    this.Report("[Cruncher][Information][Begin][UnpackXPBA-1]");
    try
    {
      IshItemCollection ishItemCollection = ObjectSerializer.XmlDeserialize<PbaObject>(pbaByte).GetCodeplugInIshItemCollection();
      using (SpecialFeatures.Comms.Comms comms = new SpecialFeatures.Comms.Comms())
        comms.unpackFromRadio(ishItemCollection);
    }
    catch (Exception ex)
    {
      this.Report("[Cruncher][Exception][UnpackXPBA]: " + ex.Message);
      return false;
    }
    this.Report("[Cruncher][Information][End][UnpackXPBA-1]");
    return true;
  }

  private string GetModelNumber(byte[] partitionArr)
  {
    int length1 = partitionArr.Length;
    int index = 0 + 1 + 22;
    string str = Encoding.BigEndianUnicode.GetString(partitionArr, index, 34);
    int length2 = str.IndexOf(char.MinValue);
    return str.Substring(0, length2);
  }

  public bool UnpackXPBA(string fileName)
  {
    this.Report("[Cruncher][Information][Begin][UnpackXPBA-2]");
    try
    {
      PbaObject pbaObject = PbaObject.DeserializeFrom(Path.GetFullPath(fileName));
      IshItemCollection ishItemCollection = pbaObject.GetCodeplugInIshItemCollection();
      using (SpecialFeatures.Comms.Comms comms = new SpecialFeatures.Comms.Comms())
      {
        foreach (DataPartition dataPartition in pbaObject.CodeplugData.DataPartitions)
        {
          if (dataPartition.PartitionID == (byte) 212)
          {
            foreach (DataBlock dataBlock in dataPartition.DataBlocks)
            {
              if (dataBlock.BlockType == (ushort) 900)
              {
                comms.m_readRadioParams = new RadioParams();
                comms.m_readRadioParams.ModelNumber = this.GetModelNumber(dataBlock.PacketValue);
                comms.unpackFromRadio(ishItemCollection);
              }
            }
          }
        }
      }
    }
    catch (Exception ex)
    {
      this.Report("[Cruncher][Exception][UnpackXPBA]: " + ex.Message);
      return false;
    }
    this.Report("[Cruncher][Information][End][UnpackXPBA-2]");
    return true;
  }

  internal bool PackXPBA(string fileName, string modelNumber)
  {
    this.Report("[Cruncher][Information][Begin][PackXPBA]");
    try
    {
      new PackUnpackExecutor().PrePackHandler();
      using (SpecialFeatures.Comms.Comms comms = new SpecialFeatures.Comms.Comms())
      {
        comms.m_readRadioParams = new RadioParams();
        comms.m_readRadioParams.ModelNumber = modelNumber;
        IshItemCollection codeplug = comms.packToCodeplug();
        PbaObject xpbaCodeplug = new PbaObject();
        xpbaCodeplug.SetCodeplug(codeplug);
        try
        {
          xpbaCodeplug.ValidationFields = RadioOperationValidator.PopulateWriteValidationFields(xpbaCodeplug);
        }
        catch
        {
        }
        xpbaCodeplug.CodeplugData.CPVersion = AppInfoManager.AppVersion;
        xpbaCodeplug.Serialize(Path.GetFullPath(fileName));
      }
    }
    catch (Exception ex)
    {
      this.Report("[Cruncher][Exception][PackXPBA]: " + ex.Message);
      return false;
    }
    this.Report("[Cruncher][Information][End][PackXPBA]");
    return true;
  }

  internal void PackImportXPBA(ref CruncherData cruncherData)
  {
    this.Report("[Cruncher][Information][Begin][PackImportXPBA]");
    AstroDeviceInfo deviceInfo = this.CreateDeviceInfo();
    string tempFileName = Path.GetTempFileName();
    try
    {
      new PackUnpackExecutor().PrePackHandler();
      using (SpecialFeatures.Comms.Comms comms = new SpecialFeatures.Comms.Comms())
      {
        comms.m_readRadioParams = new RadioParams();
        comms.m_readRadioParams.ModelNumber = deviceInfo.ModelNumber;
        IshItemCollection codeplug = comms.packToCodeplug();
        PbaObject xpbaCodeplug = new PbaObject();
        xpbaCodeplug.SetCodeplug(codeplug);
        try
        {
          xpbaCodeplug.ValidationFields = RadioOperationValidator.PopulateWriteValidationFields(xpbaCodeplug);
        }
        catch
        {
        }
        xpbaCodeplug.CodeplugData.CPVersion = AppInfoManager.AppVersion;
        xpbaCodeplug.Serialize(Path.GetFullPath(tempFileName));
      }
      cruncherData.arvFile = CombineTool.Encode(tempFileName, (object) deviceInfo);
    }
    catch (Exception ex)
    {
      this.Report("[Cruncher][Exception][PackImportXPBA]: " + ex.Message);
      throw;
    }
    finally
    {
      if (System.IO.File.Exists(tempFileName))
        System.IO.File.Delete(tempFileName);
    }
    this.Report("[Cruncher][Information][End][PackImportXPBA]");
  }

  private AstroDeviceInfo CreateDeviceInfo()
  {
    AstroDeviceInfo deviceInfo = new AstroDeviceInfo();
    Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation radioInformation = FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation;
    Motorola.MackinawCPS.CoreFeatures.DisplayAndMenu.DisplayAndMenu displayAndMenu = FeatureManager.GetFeature(2010)[0] as Motorola.MackinawCPS.CoreFeatures.DisplayAndMenu.DisplayAndMenu;
    Motorola.MackinawCPS.CoreFeatures.DataWide.DataWide dataWide = FeatureManager.GetFeature(2028)[0] as Motorola.MackinawCPS.CoreFeatures.DataWide.DataWide;
    deviceInfo.CodeplugVersion = AppInfoManager.AppVersion;
    deviceInfo.Family = Motorola.Common.Communication.CommonUtil.ProductFamily.AstroRadio;
    deviceInfo.ModelNumber = radioInformation.General.RadInfoGeneralModelNumber_A8539.Value;
    deviceInfo.SerialNumber = Convert.ToBase64String(Encoding.ASCII.GetBytes(radioInformation.General.RadInfoGeneralSerialNumber_A9122.Value));
    deviceInfo.ConnectionInfo = new ConnectionInfo();
    deviceInfo.ConnectionInfo.UniqueAddress = dataWide.General.DataWideGeneralSubscriberIPAddress1_A9222.UIValue;
    deviceInfo.SoftwareVersion = radioInformation.General.RadInfoGeneralFirmwareVersion_A8124.Value;
    deviceInfo.ESN = AESCryptoUtil.CIPHER_DEF_KEY;
    return deviceInfo;
  }

  private byte[] GetPbaBytes(CruncherData cruncherData)
  {
    byte[] pbaBytes = (byte[]) null;
    if (cruncherData.pbaFile != null && CombineTool.IsPbaPlus_enhanced(cruncherData.pbaFile))
      pbaBytes = CombineTool.Decode(cruncherData.pbaFile)[0];
    return pbaBytes;
  }

  private void EndExecuteCommand(CruncherData cruncherData)
  {
    if (cruncherData == null || cruncherData.Codeplug == null)
      return;
    cruncherData.Codeplug.Template = (Template) null;
  }

  private void BeginExecuteCommand(CruncherData cruncherData)
  {
    if (cruncherData == null || cruncherData.Codeplug == null)
      return;
    cruncherData.Codeplug.Template = cruncherData.Template;
  }

  protected virtual void Dispose(bool disposing)
  {
    if (!disposing || this.traceListener == null)
      return;
    this.traceListener.Dispose();
    this.traceListener = (TextWriterTraceListener) null;
  }

  public void Dispose()
  {
    this.Dispose(true);
    GC.SuppressFinalize((object) this);
  }

  private enum Error
  {
    Fail = 1,
    Parameter = 2,
    File = 3,
    Device = 4,
    ColumnObject = 5,
    Clone = 6,
  }
}
