// Decompiled with JetBrains decompiler
// Type: MackinawCPS.CommandLineCPS.Cruncher
// Assembly: APXFamilyCPS, Version=36.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 9359335E-041C-4B12-9409-F4E6E7D93299
// Assembly location: C:\Program Files (x86)\Motorola\ApxFamilyCPS R36.00\APXFamilyCPS1.exe

using AcpBusinessLayer;
using AcpCommonLib;
using AcpFileHandlerLib;
using Common;
using CommonResources;
using CommonUtility;
using ConstraintHelper;
using Motorola.Common.CommonLib;
using Motorola.Common.Communication.CommonUtil;
using Motorola.Common.Communication.Pba;
using Motorola.Common.CustomException;
using Motorola.CommonCPS.Common.CommonUtility;
using Motorola.CommonCPS.Server.CommonDBConstants;
using Motorola.CommonCPS.Server.EntityModel;
using Motorola.MackinawCPS.CoreFeatures.PackExec;
using Motorola.MackinawCPS.CoreFeatures.TrunkingSystem;
using SpecialFeatures.CloneWizard;
using SpecialFeatures.CodeplugCreation;
using SpecialFeatures.Comms;
using SpecialFeatures.DVRSFiles;
using SpecialFeatures.DVRSXML;
using SpecialFeatures.Flashport;
using SpecialFeatures.Flashport.FlashRadio;
using SpecialFeatures.Model_Configuration;
using SpecialFeatures.RadioLanguagePack;
using SpecialFeatures.ReadWritePassword;
using SpecialFeatures.ReadWriteTlsPsk;
using SpecialFeatures.SystemCertificates;
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
  private static Cruncher theInstance = new Cruncher();
  private readonly ReadWritePasswordApp _readWritePasswordApp;
  private CruncherOperation operation;
  private object tempSender;
  private RoutedEventArgs tempArgs;
  private string folderName;
  private const string archiveExtention = ".mc";
  private const string pbaExtention = ".xpba";
  private bool legalCommandLine;
  private TextWriterTraceListener traceListener;
  private BooleanSwitch LoggingSwitch;
  private string createSerialNumber;
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
    this._readWritePasswordApp = ReadWritePasswordApp.GetInstance();
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
        string str = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Motorola\\CommonCPS\\Log\\");
        if (!Directory.Exists(str))
          Directory.CreateDirectory(str);
        using (StreamWriter streamWriter = new StreamWriter(Path.Combine(str, DateTime.Now.ToString("yyyy-MM-dd") + ".log"), true))
        {
          streamWriter.WriteLine($"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff")}]\r\n{message}");
          streamWriter.WriteLine("----------------------------------------");
        }
      }
    }
    catch (Exception ex)
    {
    }
  }

  private void FireError(Cruncher.Error errCode)
  {
    this.Report("[Cruncher][Error][FireError]: " + errCode.ToString());
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
      ObjectSerializeUtility.DataContract_SerializeToFile(inputFile, (object) this.operation.cruncherData);
      if (this.operation.sourceFile != null && System.IO.File.Exists(this.operation.sourceFile))
        System.IO.File.Delete(this.operation.sourceFile);
      if (this.operation.targetFile != null)
      {
        if (System.IO.File.Exists(this.operation.targetFile))
          System.IO.File.Delete(this.operation.targetFile);
      }
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
      ObjectSerializeUtility.DataContract_SerializeToFile(Path.Combine(this.folderName, id.ToString() + ".cruncher"), (object) this.operation.cruncherData);
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
    try
    {
      if (!this.IsCommandLineCPS(args))
        return this.legalCommandLine = false;
      if (args.Length >= 3)
      {
        this.operation.inputFile = args[2];
        if (string.Compare(args[1], "version", true) == 0)
        {
          ObjectSerializeUtility.DataContract_SerializeToFile(this.operation.inputFile, (object) RMVersioningUtilities.GetClientVersion());
          Environment.Exit(0);
        }
        CruncherData cruncherData = (CruncherData) null;
        if (this.legalCommandLine && string.Compare(args[1], "import", true) == 0)
        {
          this.operation.Type = CruncherOperation.Operation.IMPORT;
          this.operation.targetFile = args[3];
        }
        else if (this.legalCommandLine && string.Compare(args[1], "convert", true) == 0)
        {
          this.operation.Type = CruncherOperation.Operation.CONVERTCXF;
          this.operation.inputFile = args[2];
          this.operation.targetFile = args[3];
          this.operation.password = Encoding.UTF8.GetString(Convert.FromBase64String(args[4]));
        }
        else
          cruncherData = ObjectSerializeUtility.DataContract_DeserializeFromFile<CruncherData>(this.operation.inputFile);
        if (!System.IO.File.Exists(this.operation.inputFile))
          this.legalCommandLine = false;
        if (cruncherData != null)
        {
          this.Report("[Cruncher][Information][ParseCommandLineParameters]: Starting Write Job");
          this.operation.Type = CruncherOperation.Operation.WRITE;
          this.operation.cruncherData = cruncherData;
          if (this.legalCommandLine && string.Compare(args[1], "write", true) == 0)
          {
            this.operation.Type = CruncherOperation.Operation.WRITE;
            if (cruncherData.Codeplug != null)
            {
              if (cruncherData.Codeplug.ChangeIndicator.HasValue)
              {
                int? changeIndicator1 = cruncherData.Codeplug.ChangeIndicator;
                int? nullable1 = changeIndicator1.HasValue ? new int?(changeIndicator1.GetValueOrDefault() & 16 /*0x10*/) : new int?();
                int num1 = 0;
                if (nullable1.GetValueOrDefault() == num1 & nullable1.HasValue)
                {
                  int? changeIndicator2 = cruncherData.Codeplug.ChangeIndicator;
                  int? nullable2 = changeIndicator2.HasValue ? new int?(changeIndicator2.GetValueOrDefault() & 2) : new int?();
                  int num2 = 0;
                  if (nullable2.GetValueOrDefault() == num2 & nullable2.HasValue)
                    goto label_31;
                }
                this.operation.Type = CruncherOperation.Operation.UPGRADE;
                if (!(cruncherData.Codeplug is APXCodeplug))
                  throw new CommonException(CommonErrorCode.AstroCruncherUpgradeFail);
                ASTROFirmware astroFirmware = (cruncherData.Codeplug as APXCodeplug).ASTROFirmware;
                if (astroFirmware == null)
                  throw new CommonException(CommonErrorCode.AstroCruncherUpgradeFail);
                if (!astroFirmware.FileUuid.HasValue)
                  throw new CommonException(CommonErrorCode.AstroCruncherUpgradeFail);
                this.operation.fwPackagePath = astroFirmware.FileUuid.Value.ToString();
                this.operation.fwPackageDesc = astroFirmware;
                if (cruncherData.pbaFile == null)
                {
                  this.operation.sourceFile = Path.Combine(this.folderName, Guid.NewGuid().ToString() + ".mc");
                  using (FileStream fileStream = System.IO.File.Create(this.operation.sourceFile))
                    fileStream.Write(cruncherData.ctFile, 0, cruncherData.ctFile.Length);
                }
              }
label_31:
              if (cruncherData.pbaFile == null)
              {
                this.operation.sourceFile = Path.Combine(this.folderName, Guid.NewGuid().ToString() + ".mc");
                using (FileStream fileStream = System.IO.File.Create(this.operation.sourceFile))
                  fileStream.Write(cruncherData.ctFile, 0, cruncherData.ctFile.Length);
              }
              else
              {
                this.operation.targetArchive = Path.Combine(this.folderName, Guid.NewGuid().ToString() + ".mc");
                using (FileStream fileStream = System.IO.File.Create(this.operation.targetArchive))
                  fileStream.Write(cruncherData.arvFile, 0, cruncherData.arvFile.Length);
              }
            }
            else
            {
              this.Report("[Cruncher][Error][ParseCommandLineParameters][Write]: Invalid operation source file");
              this.operation.sourceFile = (string) null;
              this.legalCommandLine = false;
            }
            if (cruncherData.pbaFile != null)
            {
              this.Report("[Cruncher][Information][ParseCommandLineParameters][Write]: Get device information");
              if (CombineTool.IsPbaPlus_enhanced(cruncherData.pbaFile))
              {
                List<byte[]> numArrayList = CombineTool.Decode(cruncherData.pbaFile);
                this.operation.deviceInfo = (AstroDeviceInfo) CombineTool.ByteArrayToObject(numArrayList[1]);
                try
                {
                  this.operation.IsEncryptedPwd = ParseDataHelper.ReadEncryptPasswordFlag(PbaObject.DeserializeFromBytes(numArrayList[0]));
                }
                catch
                {
                }
                this.operation.targetFile = Path.Combine(this.folderName, Guid.NewGuid().ToString() + ".xpba");
                using (FileStream fileStream = System.IO.File.Create(this.operation.targetFile))
                  fileStream.Write(numArrayList[0], 0, numArrayList[0].Length);
              }
              else
              {
                this.Report("[Cruncher][Error][ParseCommandLineParameters][Write]: Encoding error");
                this.legalCommandLine = false;
                this.operation.targetFile = (string) null;
              }
            }
            else
            {
              this.Report("[Cruncher][Information][ParseCommandLineParameters][Write]: Ignore device information");
              if (this.operation.sourceFile != null)
              {
                this.operation.Type = CruncherOperation.Operation.ARCHIVECLONE;
                this.operation.targetArchive = Path.Combine(this.folderName, Guid.NewGuid().ToString() + ".mc");
                using (FileStream fileStream = System.IO.File.Create(this.operation.targetArchive))
                  fileStream.Write(cruncherData.arvFile, 0, cruncherData.arvFile.Length);
                this.operation.deviceInfo = new AstroDeviceInfo();
                this.operation.targetFile = Path.Combine(this.folderName, Guid.NewGuid().ToString() + ".xpba");
                this.legalCommandLine = true;
              }
              else
              {
                this.legalCommandLine = false;
                this.operation.targetFile = (string) null;
              }
            }
          }
          else if (this.legalCommandLine && string.Compare(args[1], "read", true) == 0)
          {
            this.operation.Type = CruncherOperation.Operation.READ;
            this.Report("[Cruncher][Information][ParseCommandLineParameters][Read]: Get device information");
            if (CombineTool.IsPbaPlus_enhanced(cruncherData.pbaFile))
            {
              this.operation.targetFile = Path.Combine(this.folderName, Guid.NewGuid().ToString() + ".xpba");
              List<byte[]> numArrayList = CombineTool.Decode(cruncherData.pbaFile);
              this.operation.deviceInfo = (AstroDeviceInfo) CombineTool.ByteArrayToObject(numArrayList[1]);
              try
              {
                this.operation.IsEncryptedPwd = ParseDataHelper.ReadEncryptPasswordFlag(PbaObject.DeserializeFromBytes(numArrayList[0]));
              }
              catch
              {
              }
              using (FileStream fileStream = System.IO.File.Create(this.operation.targetFile))
                fileStream.Write(numArrayList[0], 0, numArrayList[0].Length);
            }
            else
            {
              this.Report("[Cruncher][Error][ParseCommandLineParameters][Read]: Encoding error");
              this.legalCommandLine = false;
              this.operation.targetFile = (string) null;
            }
          }
          else if (this.legalCommandLine && string.Compare(args[1], "create", true) == 0)
          {
            if (args.Length >= 4)
              this.createSerialNumber = args[3];
            this.operation.Type = CruncherOperation.Operation.CREATE;
            if (cruncherData.Codeplug != null && cruncherData.Template != null && this.operation.cruncherData.arvFile != null && this.operation.cruncherData.pbaFile == null)
            {
              this.operation.sourceFile = Path.Combine(this.folderName, Guid.NewGuid().ToString() + ".mc");
              using (FileStream fileStream = System.IO.File.Create(this.operation.sourceFile))
                fileStream.Write(this.operation.cruncherData.arvFile, 0, this.operation.cruncherData.arvFile.Length);
              this.operation.targetArchive = Path.Combine(this.folderName, Guid.NewGuid().ToString() + ".mc");
              using (FileStream fileStream = System.IO.File.Create(this.operation.targetArchive))
                fileStream.Write(this.operation.cruncherData.arvFile, 0, this.operation.cruncherData.arvFile.Length);
              this.operation.deviceInfo = new AstroDeviceInfo();
              this.operation.targetFile = Path.Combine(this.folderName, Guid.NewGuid().ToString() + ".xpba");
              this.legalCommandLine = true;
            }
            else if (cruncherData != null && cruncherData.Codeplug != null && this.operation.cruncherData.arvFile == null && this.operation.cruncherData.pbaFile != null)
            {
              this.Report("[Cruncher][Information][ParseCommandLineParameters][Create]: Create Job on PBA");
              if (CombineTool.IsPbaPlus_enhanced(this.operation.cruncherData.pbaFile))
              {
                this.operation.targetFile = Path.Combine(this.folderName, Guid.NewGuid().ToString() + ".xpba");
                List<byte[]> numArrayList = CombineTool.Decode(this.operation.cruncherData.pbaFile);
                this.operation.deviceInfo = (AstroDeviceInfo) CombineTool.ByteArrayToObject(numArrayList[1]);
                using (FileStream fileStream = System.IO.File.Create(this.operation.targetFile))
                  fileStream.Write(numArrayList[0], 0, numArrayList[0].Length);
              }
              else
              {
                this.Report("[Cruncher][Error][ParseCommandLineParameters][Create]: Encoding error");
                this.legalCommandLine = false;
                this.operation.targetFile = (string) null;
              }
            }
            else
            {
              this.legalCommandLine = false;
              this.Report("[Cruncher][Error][ParseCommandLineParameters]: Invalid Input");
              this.operation.Type = CruncherOperation.Operation.NONE;
              this.operation.targetFile = (string) null;
              this.operation.sourceFile = (string) null;
            }
            int num = this.legalCommandLine ? 1 : 0;
          }
          if (this.operation.Type == CruncherOperation.Operation.READ || this.operation.Type == CruncherOperation.Operation.WRITE || this.operation.Type == CruncherOperation.Operation.UPGRADE || this.operation.Type == CruncherOperation.Operation.CREATE)
          {
            if (this.legalCommandLine && this.operation.targetFile != null && this.operation.deviceInfo != null)
              this.SetupVirtualDevice(this.operation.targetFile, this.operation.deviceInfo);
            else
              this.legalCommandLine = false;
          }
        }
      }
      else
      {
        this.legalCommandLine = false;
        this.Report("[Cruncher][Error][ParseCommandLineParameters]: Invalid command");
      }
      if (!this.legalCommandLine)
      {
        if (this.operation.inputFile != null && System.IO.File.Exists(this.operation.inputFile))
          this.CreateErrorOutput(this.operation.inputFile, 22004);
        else
          this.CreateErrorOutput(22002);
        this.FireError(Cruncher.Error.Parameter);
      }
    }
    catch (CommonException ex)
    {
      this.legalCommandLine = false;
      this.Report("[Cruncher][Exception][ParseCommandLineParameters]: " + ex.Message);
      if (this.operation.inputFile != null)
        this.CreateErrorOutput(this.operation.inputFile, (int) ex.ErrorCode);
      else
        this.CreateErrorOutput(22002);
      this.FireError(Cruncher.Error.Parameter);
    }
    catch (Exception ex)
    {
      this.legalCommandLine = false;
      this.Report("[Cruncher][Exception][ParseCommandLineParameters]: " + ex.Message);
      if (this.operation.inputFile != null)
        this.CreateErrorOutput(this.operation.inputFile, 22011);
      else
        this.CreateErrorOutput(22002);
      this.FireError(Cruncher.Error.Parameter);
    }
    this.Report("[Cruncher][Information][End][ParseCommandLineParameters]: " + this.legalCommandLine.ToString());
    return this.legalCommandLine;
  }

  internal void LaunchOperations(object sender, RoutedEventArgs e)
  {
    this.Report($"[Cruncher][Information][Begin][LaunchOperations]: [{DateTime.Now.ToString()} - {this.operation.Type.ToString()}]");
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
          case CruncherOperation.Operation.CONVERTCXF:
            this.CruncherConvert(this.operation);
            break;
        }
        this.EndExecuteCommand(this.operation.cruncherData);
      }
      catch (Exception ex)
      {
        this.Report("[Cruncher][Exception][LaunchOperations]: " + ex.Message);
        this.FireError(Cruncher.Error.Fail);
      }
      this.Report($"[Cruncher][Information][End][LaunchOperations]: [{DateTime.Now.ToString()} - {this.operation.Type.ToString()}]");
      this.CloseLogging();
      Application.Current.Shutdown();
    }
  }

  private bool SetupVirtualDevice(string deviceFile, AstroDeviceInfo deviceInfo)
  {
    this.Report("[Cruncher][Information][Begin][SetupVirtualDevice]");
    int num = FileProxyFactory.Instance.SetupVirtualProxy(deviceFile, deviceInfo) ? 1 : 0;
    if (num != 0)
      this.Report("[Cruncher][Success][SetupVirtualDevice]: Success");
    else
      this.Report("[Cruncher][Error][SetupVirtualDevice]: Failed");
    this.Report("[Cruncher][Information][End][SetupVirtualDevice]");
    return num != 0;
  }

  private bool CruncherImport(CruncherOperation operation)
  {
    this.Report("[Cruncher][Information][Begin][CruncherImport]");
    CruncherData cruncherData = new CruncherData();
    try
    {
      WindowMain mainWindow = (WindowMain) Application.Current.MainWindow;
      string empty = string.Empty;
      string fullPath = Path.GetFullPath(operation.inputFile);
      ref string local = ref empty;
      if (!mainWindow.OpenCodeplug(fullPath, ref local))
      {
        this.Report("[Cruncher][Error][CruncherImport]: " + operation.inputFile);
        cruncherData.ErrorCode = new int?(22018);
        this.FireError(Cruncher.Error.Fail);
        return false;
      }
      (FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation).General.RadInfoGeneralCodeplugVersion_A7683.Value = AppInfoManager.AppVersion;
      if (AppInfoManager.InvalidFieldsReport.UiHasFields)
        throw new CommonException(new CommonExceptionData(CommonErrorCode.RMC_The_codeplug_contains_invalid_fields));
      Motorola.MackinawCPS.CoreFeatures.DVRSWide.DVRSWide dvrsWide = FeatureManager.GetFeature(4142)[0] as Motorola.MackinawCPS.CoreFeatures.DVRSWide.DVRSWide;
      if (dvrsWide.General.RadErgoWideDigitalVehicularRepeaterSystemDVRSHardwareEnable_A7911.Value)
      {
        uint hashCode = new DvrsMsuDataSync().CalculateHashCode();
        dvrsWide.General.DVRSWideLabtoolDVRSSyncFieldsHash_A41811.SetValue((long) hashCode);
      }
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
      ObjectSerializeUtility.DataContract_SerializeToFile(operation.targetFile, (object) cruncherData);
      this.Report("[Cruncher][Information][End][CruncherImport]");
    }
    return true;
  }

  private bool CruncherConvert(CruncherOperation operation)
  {
    WindowMain mainWindow = (WindowMain) Application.Current.MainWindow;
    this.Report("[Cruncher][Information][Begin][CruncherConvert]");
    operation.cruncherData = new CruncherData();
    try
    {
      string empty = string.Empty;
      if (!mainWindow.OpenCodeplugNonGUI(Path.GetFullPath(operation.inputFile), operation.password, true))
      {
        this.Report("[Cruncher][Error][CruncherConvert]: " + operation.inputFile);
        operation.cruncherData.ErrorCode = new int?(22018);
        Environment.Exit(22018);
      }
      this.Report("[Cruncher][Success][CruncherConvert]: Codeplug opening completed");
      if (AppInfoManager.InvalidFieldsReport.HasFields)
        this.Report("[Cruncher][Warning][CruncherConvert]: Codeplug contains invalid fields");
      AcpFileHeader header = WindowMain.GetHeader();
      ((App) Application.Current).TheDocument.FileSaveAsSafely(operation.targetFile, header);
      operation.cruncherData.ErrorCode = new int?(0);
      this.Report("[Cruncher][Success][CruncherConvert]: Codeplug conversion completed");
    }
    catch (CommonException ex)
    {
      this.Report($"[Cruncher][Exception][CruncherConvert]: {ex.Message}, {string.Join(" ", ex.CommonExceptionData.Paramters)}");
      operation.cruncherData.ErrorCode = new int?((int) ex.ErrorCode);
      Environment.Exit((int) ex.ErrorCode);
    }
    catch (Exception ex)
    {
      this.Report("[Cruncher][Exception][CruncherConvert]: " + ex.Message);
      operation.cruncherData.ErrorCode = new int?(20007);
      Environment.Exit(20007);
    }
    return true;
  }

  private void DeleteTempFile(string filePath)
  {
    this.Report("[Cruncher][Information][Begin][DeleteTempFile]");
    if (filePath != null)
    {
      if (System.IO.File.Exists(filePath))
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
    }
    this.Report("[Cruncher][Information][End][DeleteTempFile]");
  }

  private bool CruncherWrite(string inputFile)
  {
    this.Report("[Cruncher][Information][Begin][CruncherWrite]");
    string str = Path.Combine(this.folderName, Guid.NewGuid().ToString() + ".mc");
    try
    {
      this.operation.cruncherData.pbaFile = CombineTool.Encode(this.operation.targetFile, !this.operation.cruncherData.IsRestoreJob ? (int) this.WriteJobProcess_OtherTypesOfJob(inputFile, str) : (int) this.WriteJobProcess_RestoreJob(), (object) this.operation.deviceInfo);
      this.operation.cruncherData.ErrorCode = new int?();
      this.EndExecuteCommand(this.operation.cruncherData);
      ObjectSerializeUtility.DataContract_SerializeToFile(inputFile, (object) this.operation.cruncherData);
      this.Report("[Cruncher][Success][CruncherWrite]: Clone radio express completed");
    }
    catch (CommonException ex)
    {
      if (ex.Message == AppResources.Codeplug_Exceeds_Size_Limit_On_Write)
        this.CreateErrorOutput(inputFile, 22025);
      else
        this.CreateErrorOutput(inputFile, (int) ex.ErrorCode);
    }
    catch (Exception ex)
    {
      this.Report("[Cruncher][Exception][CruncherWrite]: " + ex.Message);
      if (ex.Message == "Failed to apply codeplug columns")
        this.CreateErrorOutput(inputFile, 22010);
      else if (ex.Message == "Failed to open template archive")
        this.CreateErrorOutput(inputFile, 22012);
      else if (ex.Message == "Compatibility error.")
        this.CreateErrorOutput(inputFile, 22023);
      else if (ex.Message == AcgResources.ID_ADPCLONINGINCOMPATIBILITY)
        this.CreateErrorOutput(inputFile, 22024);
      else if (ex.Message == AppResources.Codeplug_Exceeds_Size_Limit_On_Write)
        this.CreateErrorOutput(inputFile, 22025);
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

  private long WriteJobProcess_RestoreJob()
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
    return pbaObject_HandleLP.Serialize(this.operation.targetFile);
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

  private long WriteJobProcess_OtherTypesOfJob(string inputFile, string outputArchive)
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
    int? changeIndicator1 = this.operation.cruncherData.Codeplug.ChangeIndicator;
    int? nullable1 = changeIndicator1.HasValue ? new int?(changeIndicator1.GetValueOrDefault() & 16 /*0x10*/) : new int?();
    int num1 = 0;
    int num2;
    if (nullable1.GetValueOrDefault() == num1 & nullable1.HasValue)
    {
      int? changeIndicator2 = this.operation.cruncherData.Codeplug.ChangeIndicator;
      nullable1 = changeIndicator2.HasValue ? new int?(changeIndicator2.GetValueOrDefault() & 2) : new int?();
      int num3 = 0;
      num2 = !(nullable1.GetValueOrDefault() == num3 & nullable1.HasValue) ? 1 : 0;
    }
    else
      num2 = 0;
    bool flag1 = num2 != 0;
    UpgradeRadio upgrade = new UpgradeRadio((BackgroundWorker) null, flag1, this.operation.deviceInfo, this.operation.fwPackageDesc, this.operation.fwPackagePath);
    if (this.operation.Type == CruncherOperation.Operation.UPGRADE)
    {
      upgrade.fileHostVersion = this.operation.fwPackageDesc.SoftwareVersion;
      if (this.operation.fwPackageDesc.IsFreonFirmwareUpgradeFile.GetValueOrDefault() || this.operation.fwPackageDesc.IsOMAPFirmwareUpgradeFile.GetValueOrDefault())
      {
        upgrade.BBFBundleVersion = this.operation.fwPackageDesc.BPSoftwareVersion;
        upgrade.IsRadioTakesBBF = true;
      }
      else
        upgrade.IsRadioTakesBBF = false;
      upgrade.RadioHostVersion = this.operation.deviceInfo.SoftwareVersion;
      if (pbaObject1 == null)
        pbaObject1 = PbaObject.DeserializeFrom(this.operation.targetFile);
      upgrade.Connect();
      upgrade.BeginFlashUpgrade();
      using (ModelTiering modelTiering = new ModelTiering(this.operation.cruncherData.Radio.ModelNumber, ""))
        modelTiering.UpdateUtilityMackModelType();
      IshItemCollection radioCodeplug = upgrade.ReadCodeplug();
      AppInfoManager.DragOperation = true;
      ((WindowMain) Application.Current.MainWindow).DocumentOperations.InitDocument();
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
      int? changeIndicator3 = this.operation.cruncherData.Codeplug.ChangeIndicator;
      int? nullable2 = changeIndicator3.HasValue ? new int?(changeIndicator3.GetValueOrDefault() & 16 /*0x10*/) : new int?();
      int num4 = 0;
      if (!(nullable2.GetValueOrDefault() == num4 & nullable2.HasValue))
      {
        byte[] purchasedFlashCode = (this.operation.cruncherData.Codeplug as APXCodeplug).AstroPurchasedFlashCode;
        str = SpecialFeatures.Flashport.FlashRadio.FlashcodeFormatter.FormatFlashcodeString(purchasedFlashCode, purchasedFlashCode.Length);
        ibtnSerialNumber = (this.operation.cruncherData.Codeplug as APXCodeplug).iButtonSerialNumber;
        if (!flashCodeplug.UpgradeCodeplug(modelNumber, str, IsModelNumberUpgrade, false))
          throw new ApplicationException("Codeplug upgrade failed.");
      }
      if (UtilityMack.IsAPXNextOrAloha)
        upgrade.fileHostVersion = this.operation.fwPackageDesc.BPSoftwareVersion;
      upgrade.PostUpgradeCodeplugHandler(str);
      upgrade.ApplyModelTiering();
      ConstraintManager.Suspend();
      flashCodeplug.SetPostFlashCodeplugFields(ibtnSerialNumber);
      this.SaveXPBA(this.operation.targetFile);
    }
    if (!this.ReadMC(this.operation.targetArchive))
      throw new ApplicationException("Failed to open template archive");
    PageCloneWizard pageCloneWizard = new PageCloneWizard(false);
    CloneParameters.CloneWriteType = COMMS_OP.USB_CLONE;
    RadioIdInfo TempRadioIds = this.ApplyCodeplugAndDeviceColumnsInWrite(this.operation.cruncherData.Radio as APXRadio, this.operation.cruncherData.Codeplug as APXCodeplug, this.operation.cruncherData.Template as APXTemplate);
    if (this.operation.Type == CruncherOperation.Operation.UPGRADE)
      TempRadioIds.IsManagedUpgrade = true;
    pageCloneWizard.SaveRadioIdsInCruncher(TempRadioIds);
    if (AppInfoManager.InvalidFieldsReport.HasFields)
      throw new ApplicationException("Failed to apply codeplug columns");
    bool flag2 = false;
    if (this.operation.Type == CruncherOperation.Operation.WRITE || this.operation.Type == CruncherOperation.Operation.ARCHIVECLONE || this.operation.Type == CruncherOperation.Operation.UPGRADE)
    {
      if (newValue != null)
        (FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation).General.RadInfoGeneralSerialNumber_A9122.SetValue(newValue);
      try
      {
        flag2 = pageCloneWizard.CommandLineCPSCloneProcedure();
      }
      catch (Exception ex)
      {
        if (ex.Message == AppResources.Codeplug_Exceeds_Size_Limit_On_Write)
        {
          AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, ex.Message);
          throw new ApplicationException(AppResources.Codeplug_Exceeds_Size_Limit_On_Write);
        }
      }
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
    {
      if (pageCloneWizard.StatusOfClone == AppResources.Codeplug_Exceeds_Size_Limit_On_Clone || pageCloneWizard.StatusOfClone == AppResources.Codeplug_Exceeds_Size_Limit_On_Write)
        throw new CommonException(AppResources.Codeplug_Exceeds_Size_Limit_On_Write);
      string forCloneWriteRadio = AppResources.PCI_Compatibility_Error_For_Clone_Write_Radio;
      string str1 = "{0}";
      int num5 = forCloneWriteRadio.IndexOf(str1);
      if (num5 == -1)
        throw new ApplicationException("Write or Clone radio failed");
      string str2 = forCloneWriteRadio.Substring(num5 + str1.Length);
      string statusOfClone = pageCloneWizard.StatusOfClone;
      if (statusOfClone.Contains(str2))
      {
        string adpcloningincompatibility = AcgResources.ID_ADPCLONINGINCOMPATIBILITY;
        if (statusOfClone.Contains(adpcloningincompatibility))
          throw new ApplicationException(adpcloningincompatibility);
        throw new ApplicationException("Compatibility error.");
      }
    }
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
    long num6 = pbaObject_HandleLP.Serialize(this.operation.targetFile);
    if (updatedDeviceInfo != null)
      this.operation.deviceInfo = updatedDeviceInfo;
    if (pbaObject1 != null)
      this.operation.deviceInfo.ConnectionInfo.SessionID = pbaObject1.CodeplugData.ArchiveSessionID;
    MackinawCPS.CommonUtility.PopulatecpAndDeviceColumnsFromDatabaseLayerForCruncherWrite(this.operation.cruncherData, this.operation.Type);
    return num6;
  }

  public void SetRequiredFirmwareVersion(CruncherOperation operation, UpgradeRadio upgrade)
  {
    try
    {
      Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide radioWide = FeatureManager.GetFeature(2045)[0] as Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide;
      radioWide.Labtool.RadioWideReqFWVersion_A42872.SetValue("");
      if (operation == null || upgrade == null)
        return;
      int? changeIndicator = operation.cruncherData.Codeplug.ChangeIndicator;
      int? nullable = changeIndicator.HasValue ? new int?(changeIndicator.GetValueOrDefault() & 2) : new int?();
      int num = 0;
      if (nullable.GetValueOrDefault() == num & nullable.HasValue || operation.fwPackageDesc == null || string.IsNullOrEmpty(operation.fwPackageDesc.SoftwareVersion))
        return;
      AstroDeviceInfo updatedDeviceInfo = (AstroDeviceInfo) null;
      if (!upgrade.BuildUpdateDataForCruncher(out updatedDeviceInfo).MemoryImages.Any<RadioImage>())
        return;
      radioWide.Labtool.RadioWideReqFWVersion_A42872.SetValue(operation.fwPackageDesc.SoftwareVersion);
    }
    catch (Exception ex)
    {
      throw new ApplicationException("Failed to set Required Firmware Version.");
    }
  }

  private void HandleLP(PbaObject oldPBAObject, PbaObject pbaObject_HandleLP)
  {
    bool flag = this.operation.cruncherData.pbaFile == null;
    int num = this.operation.cruncherData.Codeplug.ChangeIndicator.Value;
    Guid? nullable = new Guid?();
    if ((num & 8) != 0 | flag)
    {
      ASTROLanguagePack astroLanguagePack = (this.operation.cruncherData.Codeplug as APXCodeplug).ASTROLanguagePack;
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
          AstroFilePackInfo astroFilePackInfo = new AstroFilePackInfo();
          astroFilePackInfo.sourceFilePath = nullable.Value.ToString();
          astroFilePackInfo.isFlashPortUpgradeLP = true;
          languagePacks.Add((LanguagePackBase) astroFilePackInfo);
        }
      }
      else if (this.operation.Type != CruncherOperation.Operation.UPGRADE && (this.operation.Type == CruncherOperation.Operation.WRITE || this.operation.Type == CruncherOperation.Operation.ARCHIVECLONE))
      {
        if (nullable.HasValue)
        {
          pbaObject_HandleLP.ValidationInfos = RadioOperationValidator.PopulateLPValidationInfos(oldPBAObject, this.operation.cruncherData.LastCodeplug as APXCodeplug);
          List<LanguagePackBase> languagePacks = languagePackData.LanguagePacks;
          AstroFilePackInfo astroFilePackInfo = new AstroFilePackInfo();
          astroFilePackInfo.sourceFilePath = nullable.Value.ToString();
          astroFilePackInfo.isFlashPortUpgradeLP = false;
          languagePacks.Add((LanguagePackBase) astroFilePackInfo);
        }
        else if (!nullable.HasValue && astroLanguagePack != null)
        {
          this.ValidateLanguageSetting(oldPBAObject, pbaObject_HandleLP);
        }
        else
        {
          List<LanguagePackBase> languagePacks = languagePackData.LanguagePacks;
          AstroFilePackInfo astroFilePackInfo = new AstroFilePackInfo();
          astroFilePackInfo.sourceFilePath = string.Empty;
          astroFilePackInfo.isFlashPortUpgradeLP = false;
          languagePacks.Add((LanguagePackBase) astroFilePackInfo);
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
      this.ValidateLanguageSetting(oldPBAObject, pbaObject_HandleLP);
    }
  }

  private void ValidateLanguageSetting(PbaObject oldPBAObject, PbaObject pbaObject_HandleLP)
  {
    if ((this.operation.cruncherData.Template as APXTemplate).LanguageIndex.Value == 0)
      return;
    if (pbaObject_HandleLP.ValidationInfos == null)
      pbaObject_HandleLP.ValidationInfos = new List<ValidationInfo>();
    pbaObject_HandleLP.ValidationInfos.AddRange((IEnumerable<ValidationInfo>) RadioOperationValidator.PopulateValidationInfosForRegularWrite(oldPBAObject, this.operation.cruncherData.LastCodeplug as APXCodeplug));
    string firmwareVersion = (this.operation.cruncherData.Codeplug as APXCodeplug).FirmwareVersion;
    if (!new Regex("(\\d+\\.\\d+\\.\\d+)").Match(firmwareVersion).Success || !LanguagePackHelper.IsNeedBindingServerLanguagePack(firmwareVersion))
      return;
    ValidationField validationField = RadioOperationValidator.PopulateLanguageSettingValidationField(oldPBAObject);
    if (validationField == null)
      return;
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
        RMCWnd.AnalysisFirmwarePackage(codeplug.ASTROFirmware.RMFile.Url, ref astroFirmware);
        codeplug.FirmwareVersion = firmwareVersion;
        PbaObject xpbaCodeplug = PbaObject.DeserializeFrom(this.operation.targetFile);
        xpbaCodeplug.ValidationFields = RadioOperationValidator.PopulateUpgradeValidationFields(xpbaCodeplug);
        xpbaCodeplug.ValidationInfos = RadioOperationValidator.PopulateUpgradeValidationInfos(xpbaCodeplug, this.operation.cruncherData.Codeplug as APXCodeplug, true);
        xpbaCodeplug.Serialize(this.operation.targetFile);
      }
      this.operation.cruncherData.pbaFile = CombineTool.Encode(EnDecryptStreamHelper.Instance.DecryptAndUnzipByteArray(System.IO.File.ReadAllBytes(this.operation.targetFile)), (object) this.operation.deviceInfo);
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
      if (template.ASTROCACertificates == null)
        template.ASTROCACertificates = new List<ASTROCACertificates>();
      else
        template.ASTROCACertificates.Clear();
      ASTROCACertificates[] certificatePackageData = CACertificatesHelper.GenerateNewCACertificatePackageData(new List<Package>().ToArray(), this.folderName);
      if (certificatePackageData != null)
      {
        foreach (ASTROCACertificates astrocaCertificates in certificatePackageData)
          template.ASTROCACertificates.Add(astrocaCertificates);
      }
      if (template.ASTRODVRSFiles == null)
        template.ASTRODVRSFiles = new List<ASTRODVRSFiles>();
      else
        template.ASTRODVRSFiles.Clear();
      ASTRODVRSFiles[] dvrsFilePackageData = DVRSFilesHelper.GenerateNewDVRSFilePackageData(new List<Package>().ToArray(), this.folderName);
      if (dvrsFilePackageData != null)
      {
        foreach (ASTRODVRSFiles astrodvrsFiles in dvrsFilePackageData)
          template.ASTRODVRSFiles.Add(astrodvrsFiles);
      }
      ObjectSerializeUtility.DataContract_SerializeToFile(inputFile, (object) this.operation.cruncherData);
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
      this.SetOOBEFieldToFalse();
      ReadWriteTlsPskHelper.SetTlsPskFromCodeplugPassword();
      this.Report("[Cruncher][Information][Begin][ApplyCodeplugAndDeviceColumnsInWrite] Check if needed and apply DVRS file to Codeplug");
      DVRSFilesHelper.ApplyDVRSFileDataFromTemplateUsingCruncherData(currentTpl, this.operation.cruncherData);
      Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide radioWide = (Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide) FeatureManager.GetFeature(2045)[0];
      bool? nullable1 = currentcp.DisableWriteProtect;
      if (nullable1.HasValue)
      {
        int num1 = radioWide.Depot.AdvancedExternalMicOnly.Value ? 1 : 0;
        nullable1 = currentcp.DisableWriteProtect;
        int num2 = nullable1.GetValueOrDefault() ? 1 : 0;
        if (!(num1 == num2 & nullable1.HasValue))
        {
          AcpField<bool> advancedExternalMicOnly = radioWide.Depot.AdvancedExternalMicOnly;
          nullable1 = currentcp.DisableWriteProtect;
          int num3 = nullable1.Value ? 1 : 0;
          advancedExternalMicOnly.SetValue(num3 != 0);
        }
      }
      int? nullable2;
      if (currentcp.OwnerAdvKeyType.HasValue)
      {
        int num = radioWide.General.RadWideGeneralOwnerAdvancedKeyType_A38663.Value;
        nullable2 = currentcp.OwnerAdvKeyType;
        int valueOrDefault = nullable2.GetValueOrDefault();
        if (!(num == valueOrDefault & nullable2.HasValue))
        {
          AcpListField advancedKeyTypeA38663 = radioWide.General.RadWideGeneralOwnerAdvancedKeyType_A38663;
          nullable2 = currentcp.OwnerAdvKeyType;
          int newValue = nullable2.Value;
          advancedKeyTypeA38663.SetValue(newValue);
        }
      }
      nullable2 = currentcp.OwnerWacnId;
      if (nullable2.HasValue)
      {
        int num = radioWide.General.RadWideGeneralOwnerWACNID_A38656.Value;
        nullable2 = currentcp.OwnerWacnId;
        int valueOrDefault = nullable2.GetValueOrDefault();
        if (!(num == valueOrDefault & nullable2.HasValue))
        {
          AcpSimpleRangeField ownerWacnidA38656 = radioWide.General.RadWideGeneralOwnerWACNID_A38656;
          nullable2 = currentcp.OwnerWacnId;
          int newValue = nullable2.Value;
          ownerWacnidA38656.SetValue(newValue);
        }
      }
      nullable2 = currentcp.HomeSystemId;
      if (nullable2.HasValue)
      {
        int num = radioWide.General.RadWideGeneralOwnerSystemID_A37153.Value;
        nullable2 = currentcp.HomeSystemId;
        int valueOrDefault = nullable2.GetValueOrDefault();
        if (!(num == valueOrDefault & nullable2.HasValue))
        {
          AcpSimpleRangeField ownerSystemIdA37153 = radioWide.General.RadWideGeneralOwnerSystemID_A37153;
          nullable2 = currentcp.HomeSystemId;
          int newValue = nullable2.Value;
          ownerSystemIdA37153.SetValue(newValue);
        }
      }
      nullable1 = currentcp.AskRequired;
      if (nullable1.HasValue)
      {
        int num4 = radioWide.General.RadWideGeneralASKRequired_A37152.Value ? 1 : 0;
        nullable1 = currentcp.AskRequired;
        int num5 = nullable1.GetValueOrDefault() ? 1 : 0;
        if (!(num4 == num5 & nullable1.HasValue))
        {
          AcpField<bool> askRequiredA37152 = radioWide.General.RadWideGeneralASKRequired_A37152;
          nullable1 = currentcp.AskRequired;
          int num6 = nullable1.Value ? 1 : 0;
          askRequiredA37152.SetValue(num6 != 0);
        }
      }
      if (UtilityMack.IsAPXNextOrAloha)
        radioWide.Labtool.RadWideLabtoolDeviceMgmtEnterpriseWifiCodeplugId.SetValue(Guid.NewGuid().ToString("N").ToUpper());
      TrunkingSystemRecset feature1 = FeatureManager.GetFeature(2064) as TrunkingSystemRecset;
      APXRadioSystem[] apxRadioSystemArray = new APXRadioSystem[0];
      if (currentcp.APXRadioSystems.Count > 0)
        apxRadioSystemArray = currentcp.APXRadioSystems.OrderBy<APXRadioSystem, int?>((Func<APXRadioSystem, int?>) (sys => sys.OrderId)).ToArray<APXRadioSystem>();
      APXDataProfile[] apxDataProfileArray = new APXDataProfile[0];
      if (currentcp.APXDataProfiles.Count > 0)
        apxDataProfileArray = currentcp.APXDataProfiles.OrderBy<APXDataProfile, int?>((Func<APXDataProfile, int?>) (prf => prf.OrderId)).ToArray<APXDataProfile>();
      foreach (APXRadioSystem apxRadioSystem in apxRadioSystemArray)
      {
        if (apxRadioSystem.SystemType.GetValueOrDefault() != AstroSystemType.CONVENTIONAL)
        {
          foreach (Motorola.MackinawCPS.CoreFeatures.TrunkingSystem.TrunkingSystem trunkingSystem in (Collection<AcpBusinessLayer.FeatureNode>) feature1)
          {
            if (trunkingSystem.General.TrkSysGeneralKeyofTrunkingSystem_A12658.Value == apxRadioSystem.SystemName && trunkingSystem.TypeIIChannelSetup.TrkSysTypeIIChannelSetupShuffledBandPlan_A9128.IsVisible((IAcpFeatureSection) trunkingSystem.TypeIIChannelSetup))
            {
              int num7 = (bool) trunkingSystem.TypeIIChannelSetup.TrkSysTypeIIChannelSetupShuffledBandPlan_A9128 ? 1 : 0;
              nullable1 = apxRadioSystem.ShuffeledBandPlan;
              int num8 = nullable1.GetValueOrDefault() ? 1 : 0;
              if (!(num7 == num8 & nullable1.HasValue))
              {
                AcpField<bool> shuffledBandPlanA9128 = trunkingSystem.TypeIIChannelSetup.TrkSysTypeIIChannelSetupShuffledBandPlan_A9128;
                nullable1 = apxRadioSystem.ShuffeledBandPlan;
                int num9 = nullable1.GetValueOrDefault() ? 1 : 0;
                shuffledBandPlanA9128.SetValue(num9 != 0);
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
      AcpSimpleRangeField labtoolVrIdA43727 = (FeatureManager.GetFeature(4142)[0] as Motorola.MackinawCPS.CoreFeatures.DVRSWide.DVRSWide).General.DVRSWideLabtoolVrId_A43727;
      nullable2 = currentcp.VRID;
      int num10;
      if (!nullable2.HasValue)
      {
        num10 = 0;
      }
      else
      {
        nullable2 = currentcp.VRID;
        num10 = nullable2.Value;
      }
      labtoolVrIdA43727.Value = num10;
      if (this.operation.deviceInfo.ESN != null)
      {
        radioIdInfo.ESerialNumber = new byte[this.operation.deviceInfo.ESN.Length];
        Array.Copy((Array) this.operation.deviceInfo.ESN, (Array) radioIdInfo.ESerialNumber, this.operation.deviceInfo.ESN.Length);
      }
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
      AstroSystemSubType? systemSubType;
      foreach (APXRadioSystem apxRadioSystem in apxRadioSystemArray)
      {
        if (apxRadioSystem.SystemType.GetValueOrDefault() == AstroSystemType.CONVENTIONAL)
        {
          int num11 = 0;
          systemSubType = apxRadioSystem.SystemSubType;
          AstroSystemSubType astroSystemSubType = AstroSystemSubType.ASTRO;
          if (systemSubType.GetValueOrDefault() == astroSystemSubType & systemSubType.HasValue)
          {
            num11 = 0;
          }
          else
          {
            systemSubType = apxRadioSystem.SystemSubType;
            if (systemSubType.GetValueOrDefault() == AstroSystemSubType.MDC)
            {
              num11 = 1;
            }
            else
            {
              systemSubType = apxRadioSystem.SystemSubType;
              if (systemSubType.GetValueOrDefault() == AstroSystemSubType.DVRS)
                num11 = 2;
            }
          }
          Dictionary<string, int[]> cnvSysIds = radioIdInfo.CnvSysIds;
          string systemName = apxRadioSystem.SystemName;
          int[] numArray = new int[2]{ num11, 0 };
          nullable2 = apxRadioSystem.RadioId;
          numArray[1] = nullable2.Value;
          cnvSysIds.Add(systemName, numArray);
        }
        else
        {
          int num12 = 0;
          systemSubType = apxRadioSystem.SystemSubType;
          if (systemSubType.GetValueOrDefault() == AstroSystemSubType.TYPEII)
          {
            num12 = 2;
          }
          else
          {
            systemSubType = apxRadioSystem.SystemSubType;
            if (systemSubType.GetValueOrDefault() == AstroSystemSubType.ASTRO25)
              num12 = 3;
          }
          Dictionary<string, int[]> trkSysIds = radioIdInfo.TrkSysIds;
          string systemName = apxRadioSystem.SystemName;
          int[] numArray = new int[2]{ num12, 0 };
          nullable2 = apxRadioSystem.RadioId;
          numArray[1] = nullable2.Value;
          trkSysIds.Add(systemName, numArray);
        }
      }
      bool flag1 = currentcp.APXOtarProfiles != null && currentcp.APXOtarProfiles.Any<APXOtarProfile>();
      nullable2 = currentcp.OtarID;
      if (nullable2.HasValue)
      {
        nullable2 = currentcp.OtarID;
        if (!string.IsNullOrEmpty(nullable2.ToString()) && !flag1)
        {
          IAcpRecordset feature3 = FeatureManager.GetFeature(2055);
          for (int index = 0; index < feature3.Count; ++index)
          {
            Dictionary<string, int> astroOtarRadioIds = radioIdInfo.AstroOtarRadioIds;
            string kmfProfileA12663 = (string) (AcpField<string>) (feature3[index] as Motorola.MackinawCPS.CoreFeatures.SecureKMFProfile.SecureKMFProfile).ASTROOTARInformation.SecKmfProfASTROOTARInformationKeyofSecureKMFProfile_A12663;
            nullable2 = currentcp.OtarID;
            int num13 = nullable2.Value;
            astroOtarRadioIds.Add(kmfProfileA12663, num13);
          }
        }
      }
      if (flag1)
      {
        IAcpRecordset feature4 = FeatureManager.GetFeature(2055);
        List<APXOtarProfile> apxOtarProfiles = currentcp.APXOtarProfiles;
        // ISSUE: explicit non-virtual call
        bool flag2 = (apxOtarProfiles != null ? (__nonvirtual (apxOtarProfiles.Count) == 1 ? 1 : 0) : 0) != 0 && currentcp.APXOtarProfiles?[0].Profile == string.Empty;
        for (int index = 0; index < feature4.Count; ++index)
        {
          Dictionary<string, int> astroOtarRadioIds = radioIdInfo.AstroOtarRadioIds;
          string kmfProfileA12663 = (string) (AcpField<string>) (feature4[index] as Motorola.MackinawCPS.CoreFeatures.SecureKMFProfile.SecureKMFProfile).ASTROOTARInformation.SecKmfProfASTROOTARInformationKeyofSecureKMFProfile_A12663;
          nullable2 = currentcp.APXOtarProfiles[flag2 ? 0 : index].OtarID;
          int num14 = nullable2.Value;
          astroOtarRadioIds.Add(kmfProfileA12663, num14);
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
    int passwordPolicy = (int) codeplug.PasswordPolicy;
    bool newValue1 = (passwordPolicy & 1) != 0;
    bool newValue2 = (passwordPolicy & 2) != 0;
    bool newValue3 = (passwordPolicy & 4) != 0;
    Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide radioWide = (Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide) FeatureManager.GetFeature(2045)[0];
    radioWide.Labtool.RadWideLabtoolRadioReadPasswordEnable_A8869.SetValue(newValue1);
    radioWide.Labtool.RadWideLabtoolRadioWritePasswordEnable_A8889.SetValue(newValue2);
    radioWide.Labtool.RadWideLabtoolArchiveReadPasswordEnable_A7462.SetValue(newValue3);
    string str = newValue1 || newValue2 || newValue3 ? codeplug.CodeplugPassword : string.Empty;
    radioWide.Labtool.RadWideLabtoolRadioPassword_A8837.SetValue(string.IsNullOrEmpty(str) ? string.Empty : new ReadWriteUtil().encryptMesg(str));
    AcpStringField generalTlsPsk44841 = radioWide.General.RadWideGeneralTlsPsk_44841;
    string newValue4 = string.IsNullOrEmpty(str) ? generalTlsPsk44841.DefaultValue : TlsPskHashManager.Hash(str);
    generalTlsPsk44841.SetValue(newValue4);
  }

  private void SetOOBEFieldToFalse()
  {
    (FeatureManager.GetFeature(2045)[0] as Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide).Labtool.RadWideLabtoolSeamlessUpdateOutOfBoxExperience.Value = false;
  }

  private bool CruncherRead(string inputFile)
  {
    this.Report("[Cruncher][Information][Begin][CruncherRead]");
    string str1 = Path.Combine(this.folderName, Guid.NewGuid().ToString() + ".mc");
    try
    {
      if (this.operation.cruncherData.Radio != null)
      {
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
            if (!this._readWritePasswordApp.ValidateOKToUserPassword(readPassword, radioWide.Labtool.RadWideLabtoolRadioPassword_A8837Value, numberA9122Value))
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
      APXCodeplug codeplug1 = this.operation.cruncherData.Codeplug as APXCodeplug;
      codeplug1.ASTROVoiceAnnouncements = template.ASTROVoiceAnnouncements;
      Package[] vaPackages = this.operation.cruncherData.VAPackages;
      List<ASTROVoiceAnnouncement> existPackageData1 = VAHelper.GetExistPackageData(vaPackages);
      if (existPackageData1 != null)
      {
        foreach (ASTROVoiceAnnouncement voiceAnnouncement in existPackageData1)
          template.ASTROVoiceAnnouncements.Add(voiceAnnouncement);
      }
      this.operation.cruncherData.VAPackages = (Package[]) VAHelper.GenerateNewVAPackageData(vaPackages, this.folderName);
      if (template.ASTROCACertificates == null)
        template.ASTROCACertificates = new List<ASTROCACertificates>();
      else
        template.ASTROCACertificates.Clear();
      codeplug1.ASTROCACertificates = template.ASTROCACertificates;
      Package[] certificatePackages = this.operation.cruncherData.CACertificatePackages;
      List<ASTROCACertificates> existPackageData2 = CACertificatesHelper.GetExistPackageData(certificatePackages);
      if (existPackageData2 != null)
      {
        foreach (ASTROCACertificates astrocaCertificates in existPackageData2)
          template.ASTROCACertificates.Add(astrocaCertificates);
      }
      this.operation.cruncherData.CACertificatePackages = (Package[]) CACertificatesHelper.GenerateNewCACertificatePackageData(certificatePackages, this.folderName);
      if (template.ASTRODVRSFiles == null)
        template.ASTRODVRSFiles = new List<ASTRODVRSFiles>();
      else
        template.ASTRODVRSFiles.Clear();
      codeplug1.ASTRODVRSFiles = template.ASTRODVRSFiles;
      Package[] dvrsFilesPackages = this.operation.cruncherData.DVRSFilesPackages;
      List<ASTRODVRSFiles> existingPackageData = DVRSFilesHelper.GetExistingPackageData(dvrsFilesPackages);
      if (existingPackageData != null)
      {
        foreach (ASTRODVRSFiles astrodvrsFiles in existingPackageData)
          template.ASTRODVRSFiles.Add(astrodvrsFiles);
      }
      this.operation.cruncherData.DVRSFilesPackages = (Package[]) DVRSFilesHelper.GenerateNewDVRSFilePackageData(dvrsFilesPackages, this.folderName);
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
          long serializedPbaDataLength = pbaObject.Serialize(str3);
          this.operation.cruncherData.pbaFile = CombineTool.Encode(str3, (int) serializedPbaDataLength, (object) deviceInfo);
          System.IO.File.Delete(str3);
        }
        if (pbaObject.LanguagePackData != null && pbaObject.LanguagePackData.LanguagePacks != null && pbaObject.LanguagePackData.LanguagePacks.Count > 0)
        {
          foreach (LanguagePackBase languagePack in pbaObject.LanguagePackData.LanguagePacks)
            this.ApplyLanguagePack(languagePack, deviceInfo, this.operation.cruncherData.Template as APXTemplate, this.operation.cruncherData.Codeplug as APXCodeplug);
        }
        else if (pbaObject.LanguagePackData == null)
        {
          if (selectionA8386Value != 0)
          {
            ASTROLanguagePack fakeLanguagePackage = ASTROLanguageUtility.Instance.CreateFakeLanguagePackage(selectionA8386Value.ToString());
            (this.operation.cruncherData.Template as APXTemplate).ASTROLanguagePack = fakeLanguagePackage;
            (this.operation.cruncherData.Codeplug as APXCodeplug).ASTROLanguagePack = fakeLanguagePackage;
          }
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
      APXCodeplug codeplug2 = this.operation.cruncherData.Codeplug as APXCodeplug;
      APXRadio radio = this.operation.cruncherData.Radio as APXRadio;
      this.UpdateAPXRRadioType(radio);
      MackinawCPS.CommonUtility.PopulatecpAndDeviceColumnsFromDatabaseLayerForCruncherRead(codeplug2, (Radio) radio);
      codeplug2.UpgradeAbility = new bool?(true);
      codeplug2.BBFBundleVersion = str2;
      codeplug2.Template.BBFBundleVersion = str2;
      MackinawCPS.CommonUtility.SetFeatureSet(this.operation.cruncherData.Radio, radio.Uuid);
      this.operation.cruncherData.ErrorCode = new int?();
      this.EndExecuteCommand(this.operation.cruncherData);
      ObjectSerializeUtility.DataContract_SerializeToFile(inputFile, (object) this.operation.cruncherData);
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
      this._readWritePasswordApp.ClearCachedPasswordValidation();
      this.Report("[Cruncher][Information][End][CruncherRead]");
    }
    return true;
  }

  private void UpdateAPXRRadioType(APXRadio dev)
  {
    dev.APXRadioType = new APXRadioType?(UtilityMack.IsPortable() ? APXRadioType.Portable : APXRadioType.Mobile);
  }

  private void ApplyLanguagePack(
    LanguagePackBase package,
    AstroDeviceInfo deviceInfo,
    APXTemplate template,
    APXCodeplug codeplug)
  {
    AstroFilePackInfo astroFilePackInfo = package as AstroFilePackInfo;
    string packID;
    string version;
    if (string.IsNullOrEmpty(astroFilePackInfo.radioFilePath) || !ASTROLanguageUtility.Instance.ParseLanguageIDAndVersion(astroFilePackInfo.radioFilePath, out packID, out version))
      return;
    ASTROLanguagePack astroLanguagePack1 = new ASTROLanguagePack();
    astroLanguagePack1.PackageName = string.Empty;
    astroLanguagePack1.LpID = packID;
    astroLanguagePack1.PackageVersion = version;
    ASTROLanguagePack astroLanguagePack2 = astroLanguagePack1;
    ASTROLanguagePack astroLanguagePack3 = astroLanguagePack1;
    DateTime? nullable1 = new DateTime?(DateTime.UtcNow);
    DateTime? nullable2 = nullable1;
    astroLanguagePack3.CreatedDate = nullable2;
    DateTime? nullable3 = nullable1;
    astroLanguagePack2.ModifiedDate = nullable3;
    astroLanguagePack1.PackageLanguage = Motorola.CommonCPS.ResourceRepository.ResourceHelper.GetCommonErrorMessageByID(packID.Replace('-', '_'));
    astroLanguagePack1.CompatibleVersion = deviceInfo.SoftwareVersion;
    template.LanguagePackUuid = new Guid?(astroLanguagePack1.Uuid);
    template.ASTROLanguagePack = codeplug.ASTROLanguagePack = astroLanguagePack1;
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

  internal bool UnpackXPBA(byte[] pbaBytes, string modelNumber = "")
  {
    this.Report("[Cruncher][Information][Begin][UnpackXPBA-1]");
    try
    {
      CodeplugFormatHelper.UnpackXpba(pbaBytes, modelNumber);
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
    int length = partitionArr.Length;
    int index = 0 + 1 + 22;
    string str = Encoding.BigEndianUnicode.GetString(partitionArr, index, 34);
    return str.Substring(0, str.IndexOf(char.MinValue));
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
                comms.UnpackFromRadio(ishItemCollection);
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
    IshItemCollection ishItemCollection1 = new IshItemCollection();
    try
    {
      new PackUnpackExecutor().PrePackHandler();
      using (SpecialFeatures.Comms.Comms comms = new SpecialFeatures.Comms.Comms())
      {
        comms.m_readRadioParams = new RadioParams();
        comms.m_readRadioParams.ModelNumber = modelNumber;
        IshItemCollection ishItemCollection2 = comms.PackToCodeplug().Item1;
        PbaObject xpbaCodeplug = new PbaObject();
        xpbaCodeplug.SetCodeplug(ishItemCollection2);
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
      if (ex is CommonException commonException && commonException.Message == AppResources.Codeplug_Exceeds_Size_Limit_On_Write)
      {
        AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, ex.Message);
        this.Report("[Cruncher][Exception][PackXPBA]: " + ex.Message);
        throw new CommonException(AppResources.Codeplug_Exceeds_Size_Limit_On_Write);
      }
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
        IshItemCollection ishItemCollection = comms.PackToCodeplug().Item1;
        PbaObject xpbaCodeplug = new PbaObject();
        xpbaCodeplug.SetCodeplug(ishItemCollection);
        try
        {
          xpbaCodeplug.ValidationFields = RadioOperationValidator.PopulateWriteValidationFields(xpbaCodeplug);
        }
        catch
        {
        }
        xpbaCodeplug.CodeplugData.CPVersion = AppInfoManager.AppVersion;
        long serializedPbaDataLength = xpbaCodeplug.Serialize(Path.GetFullPath(tempFileName));
        cruncherData.arvFile = CombineTool.Encode(tempFileName, (int) serializedPbaDataLength, (object) deviceInfo);
      }
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
    IAcpFeatureNode acpFeatureNode = FeatureManager.GetFeature(2010)[0];
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
