// Decompiled with JetBrains decompiler
// Type: MackinawCPS.RMCWnd
// Assembly: APXFamilyCPS, Version=36.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 9359335E-041C-4B12-9409-F4E6E7D93299
// Assembly location: C:\Program Files (x86)\Motorola\ApxFamilyCPS R36.00\APXFamilyCPS1.exe

using AcpASKLib;
using AcpCommonLib;
using AcpSecurityLib;
using AcpUI;
using AcpUtility;
using ASK.Interface;
using Common;
using commonLicensing;
using CommonResources;
using CommonUtility;
using ConstraintHelper;
using Features.Common;
using Motorola.Common.CommonLib;
using Motorola.Common.Communication.CommonUtil;
using Motorola.Common.Communication.Pba;
using Motorola.Common.CustomException;
using Motorola.CommonCPS.RadioManagement.Core;
using Motorola.CommonCPS.RadioManagement.Global;
using Motorola.CommonCPS.RadioManagement.Infrastructure.Services.RMCExportToCPS;
using Motorola.CommonCPS.RadioManagement.SharedServices;
using Motorola.CommonCPS.RadioManagement.UIModels;
using Motorola.CommonCPS.Server.CommonDBConstants;
using Motorola.CommonCPS.Server.EntityModel;
using SpecialFeatures;
using SpecialFeatures.Clone_Configuration.Common;
using SpecialFeatures.Comms;
using SpecialFeatures.Comms.Util;
using SpecialFeatures.DVRSFiles;
using SpecialFeatures.Flashport;
using SpecialFeatures.Flashport.FlashRadio;
using SpecialFeatures.Flashport.FlashRadio.ApxNext;
using SpecialFeatures.Model_Configuration;
using SpecialFeatures.RadioLanguagePack;
using SpecialFeatures.Security;
using SpecialFeatures.SystemCertificates;
using SpecialFeatures.VoiceAnnouncements;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Navigation;

#nullable disable
namespace MackinawCPS;

public partial class RMCWnd : Window, IComponentConnector
{
  private bool _isMockVersion;
  private byte[] _lastCPModifiedTimestamp;
  private bool _isOpenCodeplug;
  private readonly FirmwareFileValidator _firmwareFileValidator;
  internal Grid mainGrid;
  internal ContentControl ctcRadioManagementControl;
  private bool _contentLoaded;

  public RMCWnd()
    : this(false)
  {
  }

  public RMCWnd(bool isMockVersion)
  {
    this.InitializeComponent();
    this._isMockVersion = isMockVersion;
    RMCExportInterface.GetInstance().ImportDeviceEvtHandler += new EventHandler<OpenFileEventArgs>(this.ExportInterfaceForCPS_ImportDeviceEvtHandler);
    RMCExportInterface.GetInstance().ParseAchiveEvtHandler += new EventHandler<OpenFileEventArgs>(this.ExportInterfaceForCPS_ParseAchiveEvtHandler);
    RMCExportInterface.GetInstance().EditTemplateEvtHandler += new EventHandler<Motorola.CommonCPS.RadioManagement.SharedServices.DeviceEventArgs>(this.ExportInterfaceForCPS_ExportEditCodeplugEvtHandler);
    RMCExportInterface.GetInstance().ImportTemplateEvtHandler += new EventHandler<OpenFileEventArgs>(this.RMCWnd_ImportTemplateEvtHandler);
    RMCExportInterface.GetInstance().ExportDeviceEvtHandler += new EventHandler<ExportDeviceEventArgs>(this.RMCWnd_ExportDeviceEvtHandler);
    RMCExportInterface.GetInstance().ExportDVRSEvtHandler += new EventHandler<ExportDVRSEventArgs>(this.RMCWnd_ExportDVRSEvtHandler);
    RMCExportInterface.GetInstance().AstroUpgradeCodeplugEvtHandler += new EventHandler<AstroUpgradeCodeplugEventArgs>(this.RMCWnd_AstroUpgradeCodeplugEvtHandler);
    RMCExportInterface.GetInstance().AstroCheckHoptionEnableEvtHandler += new EventHandler<ASTROHoptionEnableEventArgs>(this.RMCWnd_AstroCheckHoptionEnableEvtHandler);
    RMCExportInterface.GetInstance().AstroCheckIsConvOnlyEvtHandler += new EventHandler<ASTROHoptionEnableEventArgs>(this.RMCWnd_AstroCheckIsConvOnlyEvtHandler);
    RMCExportInterface.GetInstance().AnalysisPackageEvtHandler += new EventHandler<AnalysisPackageEventArgs>(this.RMCWnd_AnalysisPackageEvtHandler);
    RMCExportInterface.GetInstance().LanguagePackInfosEvtHandler += new EventHandler<ListLpPackageEventArgs>(this.RMCWnd_LanguagePackInfosEvtHandler);
    RMCExportInterface.GetInstance().AstroDecodeLangageIndexToLpIDEvtHandler += new EventHandler<AstroDecodeLanguageIndexToLPIDEventArgs>(this.RMCWnd_AstroDecodeLangageIndexToLpIDEvtHandler);
    RMCExportInterface.GetInstance().AstroLanguagePackCompatibleCheckEvtHandler += new EventHandler<AstroLanguageCompatibleCheckEventArgs>(this.RMCWnd_AstroLanguagePackCompatibleCheckEvtHandler);
    RMCExportInterface.GetInstance().AstroUpgradeWithLanugagePackIsSupportedCheckEvtHandler += new EventHandler<AstroUpgradeWithLanugagePackIsSupportedCheckEventArgs>(this.RMCWnd_AstroUpgradeWithLanugagePackIsSupportedCheckEvtHandler);
    RMCExportInterface.GetInstance().AstroUpgradeFWVerCompatibleCheckEvtHandler += new EventHandler<AstroUpgradeFWCompatibleCheckEventArgs>(this.RMCWnd_AstroUpgradeFWVerCompatibleCheckEvtHandler);
    RMCExportInterface.GetInstance().AstroDecodeFlashCodeEvtHandler += new EventHandler<AstroDecodeFlashCodeEventArgs>(this.RMCWnd_AstroDecodeFlashCodeEvtHandler);
    RMCExportInterface.GetInstance().AstroReadFlashKeyEvtHandler += new EventHandler<AstroFlashKeyEventArgs>(this.RMCWnd_AstroReadFlashKeyEvtHandler);
    RMCExportInterface.GetInstance().AstroDecraseFlashKeyEvtHandler += new EventHandler<AstroDecreaseKeyCountEventArgs>(this.RMCWnd_AstroDecraseFlashKeyEvtHandler);
    RMCExportInterface.GetInstance().AstroPINPasswordConvertEventHandler += new EventHandler<AstroPINPasswordConvertEventArgs>(this.RMCWnd_AstroPINPasswordConvertEventHandler);
    RMCExportInterface.GetInstance().AstroValidateFlashKeyEvtHandler += new EventHandler<AstroFlashKeyEventArgs>(this.RMCWnd_AstroValidateFlashKeyEvtHandler);
    RMCExportInterface.GetInstance().AstroReleaseFlashKeyEvtHandler += new EventHandler(this.RMCWnd_AstroReleaseFlashKeyEvtHandler);
    RMCExportInterface.GetInstance().AstroASKRequirementEditingCheckEvtHandler += new EventHandler<AstroASKRequirementEventArgs>(this.ExportInterfaceForCPS_AstroASKRequirementEditingCheckEvtHandler);
    RMCExportInterface.GetInstance().ASTROIndividualIdEditingCheckEvtHandler += new EventHandler<ASTROIndividualIdEditingEventArgs>(this.ExportInterfaceForCPS_AstroIndividualIdEditingCheckEvtHandler);
    RMCExportInterface.GetInstance().AstroWritingCheckEvtHandler += new EventHandler<AstroWritingEventArgs>(this.ExportInterfaceForCPS_AstroWritingCheckEvtHandler);
    RMCExportInterface.GetInstance().AstroCompatibilityCheckEvtHandler += new EventHandler<AstroCompatibilityEventArgs>(this.ExportInterfaceForCPS_AstroCompatibilityCheckEvtHandler);
    RMCExportInterface.GetInstance().AstroPop25EnabledEvtHandler += new EventHandler<AstroPop25EnabledEventArgs>(this.AstroPOP25EnabledCheckEvtHandler);
    RMCExportInterface.GetInstance().AstroEncodeFlashCodeEvtHandler += new EventHandler<AstroEncodeFlashCodeEventArgs>(this.RMCWnd_AstroEncodeFlashCodeEvtHandler);
    RMCExportInterface.GetInstance().ParseFeatureCodeEvtHandler += new EventHandler<ParseFeatureCodeEventArgs>(this.RMCWnd_ParseFeatureCodeEvtHandler);
    RMCExportInterface.GetInstance().AstroParseFlashCodeEvtHandler += new EventHandler<AstroParseFlashCodeEventArgs>(this.RMCWnd_AstroParseFlashCodeEvtHandler);
    RMCExportInterface.GetInstance().ParseFeatureStatusEvtHandler += new EventHandler<ParseFeatureStatusEventArgs>(this.RMCWnd_ParseFeatureStatusEvtHandler);
    RMCExportInterface.GetInstance().PopulateRadioFeaturesFromCodeplugEvtHandler += new EventHandler<PopulateRadioFeaturesFromCodeplugEventArgs>(this.RMCWnd_PopulateRadioFeaturesFromCodeplugEvtHandler);
    RMCExportInterface.GetInstance().PopulateRadioFeaturesFromFlashCodeEvtHandler += new EventHandler<PopulateRadioFeaturesFromFlashCodeEventArgs>(this.RMCWnd_PopulateRadioFeaturesFromFlashCodeEvtHandler);
    RMCExportInterface.GetInstance().QueryUpdateRadioEvtHandler += new EventHandler<QueryUpdateRadioEventArgs>(this.RMCWnd_QueryUpdateRadioEvtHandler);
    RMCExportInterface.GetInstance().AstroCheckIsConvOnlyEvtHandler += new EventHandler<ASTROHoptionEnableEventArgs>(this.RMCWnd_RadioIsConvOnlyEvtHandler);
    RMCExportInterface.GetInstance().BindingServerLanguagePackEvtHandler += new EventHandler<BindingServerLanguagePackEventArgs>(this.RMCWnd_BindingServerLanguagePackEvtHandler);
    RMCExportInterface.GetInstance().IsFreonEvtHandler += new EventHandler<IsFreonEventArgs>(this.RMCWnd_IsFreonEvtHandler);
    RMCExportInterface.GetInstance().AstroGetLoadedSysKeysEvtHandler += new EventHandler<AstroSystemKeyDataEventArgs>(this.RMCWnd_AstroGetLoadedSysKeysEvtHandlerEvtHandler);
    RMCExportInterface.GetInstance().AstroFinalFWSupportedVersionsEvtHandler += new EventHandler<AstroFinalFWSupportedVersionsEventArgs>(this.RCWnd_GetFinalSupportedFWVersion);
    this._firmwareFileValidator = new FirmwareFileValidator((IIOCompressionHelper) new IOCompressionHelper());
    if (Thread.CurrentThread.CurrentUICulture.TextInfo.IsRightToLeft)
      this.FlowDirection = FlowDirection.RightToLeft;
    else
      this.FlowDirection = FlowDirection.LeftToRight;
  }

  private void RMCWnd_IsFreonEvtHandler(object sender, IsFreonEventArgs e)
  {
    if (string.IsNullOrEmpty(e.ModelNumber))
    {
      e.IsFreon = false;
    }
    else
    {
      string str1 = e.ModelNumber.ToUpper().Trim();
      foreach (string str2 in MTFAliasList.Instance.GetFreonModelNumber())
      {
        if (str2 == str1)
        {
          e.IsFreon = true;
          break;
        }
      }
    }
  }

  internal RadioManagementControl RadioManagementControl
  {
    get => this.ctcRadioManagementControl.Content as RadioManagementControl;
  }

  private void RMCWnd_ImportTemplateEvtHandler(object sender, OpenFileEventArgs e)
  {
    if (this._isOpenCodeplug)
      throw new CommonException(CommonErrorCode.RMC_HasCodeplugOpened);
    ApplicationMode CPSMode = AppInfoManager.AppMode;
    APXTemplate template = new APXTemplate();
    WindowMain windowMain = this.GetWindowMain();
    if (!windowMain.CanOpenCpgFlag || windowMain.ReadWriteInProgress)
      throw new CommonException(new CommonExceptionData(CommonErrorCode.RMC_HasCodeplugOpened));
    string str = string.Empty;
    try
    {
      this._isOpenCodeplug = true;
      str = Path.GetTempPath() + Path.GetFileName(e.FilePath);
      if (str.Length >= 260)
        str = str.Remove(250) + ".mc";
      if (File.Exists(str))
      {
        File.SetAttributes(str, FileAttributes.Normal);
        File.Delete(str);
      }
      File.Copy(e.FilePath, str);
      File.SetAttributes(str, FileAttributes.Normal);
      string empty = string.Empty;
      string password = e.Password;
      if (!windowMain.OpenCodeplugNonGUI(str, password, true, e.IgnorePassword))
        return;
      if (windowMain.PromptQuitOnInvalids().Result)
        throw new CommonException(new CommonExceptionData(CommonErrorCode.RMC_The_codeplug_contains_invalid_fields));
      windowMain.OnAppMenuSaveAsNonGUI((object) this, (RoutedEventArgs) null, str);
      MackinawCPS.CommonUtility.PopulateTemplateColumnsFromDatabaseLayer(template);
      VAHelper.AttachVoiceAnnouncemnetReference(template);
      CACertificatesHelper.AttachCACertificateReference(template);
      DVRSFilesHelper.AttachDVRSFileReference(template);
      LanguagePackHelper.AttachLanguagePackagesReference(template);
      e.ImportingTemplate = (Motorola.CommonCPS.Server.EntityModel.Template) template;
    }
    catch (PathTooLongException ex)
    {
      throw new CommonException(CommonErrorCode.RMC_FilePathTooLong_Error);
    }
    catch (IOException ex)
    {
      throw new CommonException(new CommonExceptionData(CommonErrorCode.RMC_UnableToReadTheFollowingArchive, new string[1]
      {
        e.FilePath
      }));
    }
    catch (CommonException ex)
    {
      throw;
    }
    catch (Exception ex)
    {
      throw new CommonException(new CommonExceptionData(CommonErrorCode.RMC_ImportCodeplug_Error));
    }
    finally
    {
      if (windowMain.CanOpenCpgFlag)
        windowMain.CloseFileNonGUI(false);
      try
      {
        if (File.Exists(str))
        {
          File.SetAttributes(str, FileAttributes.Normal);
          File.Delete(str);
        }
      }
      catch
      {
      }
      this.Dispatcher.Invoke((Action) (() => AppInfoManager.AppMode = CPSMode));
      this._isOpenCodeplug = false;
    }
  }

  public bool Connect()
  {
    RuntimeInfo.ModeIdentifier = ModeIdentifier.Template;
    RuntimeInfo.ProductFamily = Motorola.CommonCPS.Server.CommonDBConstants.ProductFamily.APX;
    if (!this.IsVisible)
    {
      RuntimeInfo.ConnectionFailureReason = ConnectionFailureReasonID.None;
      RadioManagementBootstrapper.Connect();
      if (this.ctcRadioManagementControl.Content != null)
      {
        RadioManagementControl content = this.ctcRadioManagementControl.Content as RadioManagementControl;
        if (RuntimeInfo.IsConnected)
        {
          this.Show();
          Cursor overrideCursor = Mouse.OverrideCursor;
          Mouse.OverrideCursor = Cursors.Wait;
          try
          {
            Motorola.CommonCPS.RadioManagement.CommonBase.Global.RMCWindow = (Window) this;
            this.Activate();
            this.Focus();
            content.Refresh();
          }
          finally
          {
            Mouse.OverrideCursor = overrideCursor;
          }
          return true;
        }
        content.HandleConnectResults();
        if (!RuntimeInfo.IsConnected)
          return false;
        this.Show();
        this.Activate();
        content.Refresh();
        return true;
      }
      WindowInteropHelper windowInteropHelper = new WindowInteropHelper((Window) this);
      string logOutputDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Motorola\\CommonCPS\\RMC\\Log");
      CommonLicenseInterface.InitializeLicensing(HostID.getNewHostID("RMC"), commonLicensing.ApplicationType.RMC, logOutputDir);
      if (!RadioManagementBootstrapper.Launch((object) this.ctcRadioManagementControl, "ASTROCPS_RMSERVER_RM"))
        return false;
      Motorola.CommonCPS.RadioManagement.CommonBase.Global.RMCWindow = (Window) this;
      this.Show();
      this.Activate();
      return true;
    }
    this.Activate();
    this.Focus();
    return true;
  }

  private void RMCWnd_ExportDeviceEvtHandler(object sender, ExportDeviceEventArgs e)
  {
    if (this._isOpenCodeplug)
      throw new CommonException(CommonErrorCode.RMC_HasCodeplugOpened);
    try
    {
      this._isOpenCodeplug = true;
      if (AppInfoManager.AppMode == ApplicationMode.CustomViewConfigurationMode)
        throw CommonExceptionHelper.CreateCommonException(CommonErrorCode.RMC_HasCustomViewSelected, Motorola.CommonCPS.ResourceRepository.Resources.RMC_HasCustomViewSelected);
      WindowMain windowMain = this.GetWindowMain();
      if (windowMain.ReadWriteInProgress || windowMain.CpgOpenFlag)
        throw CommonExceptionHelper.CreateCommonException(CommonErrorCode.RMC_HasCodeplugOpened, Motorola.CommonCPS.ResourceRepository.Resources.RMC_HasCodeplugOpened);
      if (e.ExportFileType == FileType.PbaFile)
      {
        this.ExportPbaFile(e, windowMain);
      }
      else
      {
        if (e.ExportFileType != FileType.CpdFile)
          return;
        this.ExportCpsFile(e, windowMain);
      }
    }
    finally
    {
      this._isOpenCodeplug = false;
    }
  }

  private void ExportPbaFile(ExportDeviceEventArgs e, WindowMain winMain)
  {
    try
    {
      List<byte[]> numArrayList = CombineTool.IsPbaPlus_enhanced(e.FileContent) ? CombineTool.Decode(e.FileContent) : throw CommonExceptionHelper.CreateCommonException(CommonErrorCode.RMC_ExportCodeplug_Error, Motorola.CommonCPS.ResourceRepository.Resources.RMC_ExportCodeplug_Error);
      AstroDeviceInfo deviceInfo = (AstroDeviceInfo) CombineTool.ByteArrayToObject(numArrayList[1]);
      if (!e.IsForRestore)
        this.UpdateDeviceInfo(deviceInfo, e.FirmwareVersion);
      this.RunActionOnTempFile("xpba", numArrayList[0], winMain, (Action) (() => winMain.OnAppMenuSaveAsNonGUI((object) this, (RoutedEventArgs) null, e.FilePathName)), deviceInfo);
    }
    catch (Exception ex)
    {
      throw CommonExceptionHelper.CreateCommonException(CommonErrorCode.GenericError, Motorola.CommonCPS.ResourceRepository.Resources.GenericError, ex);
    }
  }

  private void ExportCpsFile(ExportDeviceEventArgs e, WindowMain winMain)
  {
    this.RunActionOnSavedFile(e.FilePathName, e.FileContent, winMain, (Action) (() =>
    {
      winMain.UpdateFieldsWithServerValues((APXRadio) e.ExportRadio, true);
      winMain.OnAppMenuSaveAsNonGUI((object) this, (RoutedEventArgs) null, e.FilePathName);
    }));
  }

  private void UpdateDeviceInfo(AstroDeviceInfo deviceInfo, string firmwareVersion)
  {
    if (deviceInfo.SoftwareVersion.Equals(firmwareVersion))
      return;
    this.ResetSoftwareVersionInDeviceInfo(deviceInfo, firmwareVersion);
  }

  private void ResetSoftwareVersionInDeviceInfo(AstroDeviceInfo deviceInfo, string softwareVersion)
  {
    deviceInfo.SoftwareVersion = softwareVersion;
    deviceInfo.DspVersion = AcgResources.ID_NA;
    deviceInfo.PsdtVersion = AcgResources.ID_NA;
    deviceInfo.TuneVersion = AcgResources.ID_NA;
    deviceInfo.BootloaderVersion = AcgResources.ID_NA;
    deviceInfo.MaceFlashVersion = this.ResetDeviceInfoField(deviceInfo.MaceFlashVersion);
    deviceInfo.MaceSecureHardwareVersion = this.ResetDeviceInfoField(deviceInfo.MaceSecureHardwareVersion);
    deviceInfo.MaceSecureHardwareType = this.ResetDeviceInfoField(deviceInfo.MaceSecureHardwareType);
    deviceInfo.OptionBoardHardwareHostVersion = this.ResetDeviceInfoField(deviceInfo.OptionBoardHardwareHostVersion);
    deviceInfo.OptionBoardHardwareType = this.ResetDeviceInfoField(deviceInfo.OptionBoardHardwareType);
    deviceInfo.OptionBoardName = this.ResetDeviceInfoField(deviceInfo.OptionBoardName);
  }

  private string ResetDeviceInfoField(string value)
  {
    return string.IsNullOrEmpty(value) ? value : AcgResources.ID_NA;
  }

  private void RMCWnd_ExportDVRSEvtHandler(object sender, ExportDVRSEventArgs e)
  {
    if (AppInfoManager.AppMode == ApplicationMode.CustomViewConfigurationMode)
      throw CommonExceptionHelper.CreateCommonException(CommonErrorCode.RMC_HasCustomViewSelected, Motorola.CommonCPS.ResourceRepository.Resources.RMC_HasCustomViewSelected);
    WindowMain winMain = this.GetWindowMain();
    if (winMain.ReadWriteInProgress || winMain.CpgOpenFlag)
      throw CommonExceptionHelper.CreateCommonException(CommonErrorCode.RMC_HasCodeplugOpened, Motorola.CommonCPS.ResourceRepository.Resources.RMC_HasCodeplugOpened);
    if (File.Exists(e.FilePathName))
      File.Delete(e.FilePathName);
    string archiveFileName = e.FilePathName.Replace(".xml", "_xml.mc");
    this.SaveCpsFile(archiveFileName, e.FileContent);
    try
    {
      this.Dispatcher.Invoke((Action) (() => winMain.ExportDVRSFromRMC(archiveFileName, e.FilePathName)));
    }
    finally
    {
      if (File.Exists(archiveFileName))
        File.Delete(archiveFileName);
    }
  }

  private void RMCWindow_Loaded(object sender, RoutedEventArgs e)
  {
  }

  private void ExportInterfaceForCPS_AstroASKRequirementEditingCheckEvtHandler(
    object sender,
    AstroASKRequirementEventArgs e)
  {
    string stsMsg = (string) null;
    try
    {
      if (!RMCRadioAccessValidator.AstroASKRequirementEventHandler(e.Codeplug, e.TargetModelNumber, out stsMsg))
        throw CommonExceptionHelper.CreateDirectMessageCommonException(stsMsg);
    }
    catch (CommonException ex)
    {
      throw;
    }
    catch (Exception ex)
    {
      throw CommonExceptionHelper.CreateCommonException(CommonErrorCode.GenericError, Motorola.CommonCPS.ResourceRepository.Resources.GenericError, ex);
    }
  }

  private void AstroPOP25EnabledCheckEvtHandler(object sender, AstroPop25EnabledEventArgs e)
  {
    WindowMain windowMain = this.GetWindowMain();
    e.Pop25Enabled = windowMain != null && windowMain.Pop25Enabled;
  }

  private void RMCWnd_AstroEncodeFlashCodeEvtHandler(object sender, AstroEncodeFlashCodeEventArgs e)
  {
    byte[] decoded = new byte[25];
    if (e.FlashCode.Length > 15 && FlashcodeValidator.Validate(e.FlashCode))
      SpecialFeatures.Flashport.FlashRadio.FlashcodeDecoder.Decode(e.FlashCode, ref decoded);
    else if (e.FlashCode.Length <= 15 && FlashcodeValidator.ValidateOldFlashcode(e.FlashCode))
      SpecialFeatures.Flashport.FlashRadio.FlashcodeDecoder.DecodeOldFlashcode(e.FlashCode, ref decoded);
    else
      throw CommonExceptionHelper.CreateDirectMessageCommonException(AppResources.is_an_invalid_flashcode.AcpStringFormat((object) e.FlashCode));
    e.EncodeFlashCode = decoded;
  }

  private void RMCWnd_ParseFeatureCodeEvtHandler(object sender, ParseFeatureCodeEventArgs e)
  {
    try
    {
      bool isPortable = false;
      if (!string.IsNullOrEmpty(e.ModelNumber))
      {
        try
        {
          new ModelTiering(e.ModelNumber, ModelTiering.ActionTypes.NONE, ModelTiering.TargetTypes.ALL).UpdateUtilityMackModelType();
        }
        catch (Exception ex)
        {
          throw CommonExceptionHelper.CreateDirectMessageCommonException(AppResources.Invalid_radio_model_number.AcpStringFormat((object) e.ModelNumber));
        }
        isPortable = UtilityMack.IsPortablePro;
      }
      OptionIDs featureCode = (OptionIDs) e.FeatureCode;
      string str = string.Empty;
      bool flag = false;
      using (FlashcodeTable flashcodeTable = new FlashcodeTable(isPortable, true))
      {
        flashcodeTable.InitTable(false, e.ModelNumber);
        foreach (Option option in flashcodeTable.FLASHcode)
        {
          if (option.OptionID == featureCode)
          {
            str = option.Description;
            flag = true;
            break;
          }
        }
      }
      if (string.IsNullOrEmpty(e.ModelNumber) && !flag)
      {
        using (FlashcodeTable flashcodeTable = new FlashcodeTable(!isPortable, true))
        {
          flashcodeTable.InitTable(false, e.ModelNumber);
          foreach (Option option in flashcodeTable.FLASHcode)
          {
            if (option.OptionID == featureCode)
            {
              str = option.Description;
              flag = true;
              break;
            }
          }
        }
      }
      if (!flag)
        throw CommonExceptionHelper.CreateDirectMessageCommonException(AppResources.Not_a_Valid_Option_for_Model.AcpStringFormat((object) featureCode.ToString(), (object) e.ModelNumber));
      e.FeatureNameTag = str;
    }
    catch (CommonException ex)
    {
      throw;
    }
    catch (Exception ex)
    {
      throw CommonExceptionHelper.CreateCommonException(CommonErrorCode.GenericError, Motorola.CommonCPS.ResourceRepository.Resources.GenericError, ex);
    }
  }

  private void RMCWnd_ParseFeatureStatusEvtHandler(object sender, ParseFeatureStatusEventArgs e)
  {
    e.FeatureStatusDescription = "";
    switch (e.FeatureStatus)
    {
      case FeatureStatus.Active:
        e.FeatureStatusDescription = AppResources.Purchased;
        break;
      case FeatureStatus.PendingActive:
        e.FeatureStatusDescription = AppResources.Pending;
        break;
      default:
        throw CommonExceptionHelper.CreateCommonException(CommonErrorCode.GenericError, Motorola.CommonCPS.ResourceRepository.Resources.GenericError);
    }
  }

  private void RMCWnd_AstroParseFlashCodeEvtHandler(object sender, AstroParseFlashCodeEventArgs e)
  {
    try
    {
      Dictionary<int, string> dictionary = new Dictionary<int, string>();
      bool isPortable;
      try
      {
        isPortable = !ModelTiering.IsModelMobileByModelNumber(e.ModelNumber);
      }
      catch (Exception ex)
      {
        throw CommonExceptionHelper.CreateDirectMessageCommonException(AppResources.Invalid_radio_model_number.AcpStringFormat((object) e.ModelNumber));
      }
      using (FlashcodeTable flashcodeTable = new FlashcodeTable(isPortable, true))
      {
        flashcodeTable.InitTable(false, e.ModelNumber);
        foreach (Option opt in flashcodeTable.FLASHcode)
        {
          if (flashcodeTable.IsOptionEnabledInFlashcode(opt, e.FlashCode))
            dictionary.Add((int) opt.OptionID, opt.Description);
        }
      }
      e.FeatureTagNameList = dictionary;
    }
    catch (CommonException ex)
    {
      throw;
    }
    catch (Exception ex)
    {
      throw CommonExceptionHelper.CreateDirectMessageCommonException(AppResources.is_an_invalid_flashcode.AcpStringFormat((object) e.FlashCode));
    }
  }

  private void ExportInterfaceForCPS_AstroCompatibilityCheckEvtHandler(
    object sender,
    AstroCompatibilityEventArgs e)
  {
    try
    {
      CompatibilityChecks compatibilityChecks = new CompatibilityChecks(e.TemplateCodeplug, e.DeviceCodeplug, e.TargetModelnumber);
      string empty = string.Empty;
      ref string local = ref empty;
      if (compatibilityChecks.PerfomChecks(ref local))
        return;
      if (empty.Contains(AppResources.Unable_to_clone_due_to_the_incompatibility_between_source_and_models))
        throw CommonExceptionHelper.CreateDirectMessageCommonException(empty);
      throw CommonExceptionHelper.CreateCommonException(CommonErrorCode.Failure_due_to_mismatch_of_Codeplug_Used_FLASHcode_and_Radio_FLASHcode, empty);
    }
    catch (CommonException ex)
    {
      throw;
    }
    catch (Exception ex)
    {
      throw CommonExceptionHelper.CreateCommonException(CommonErrorCode.GenericError, Motorola.CommonCPS.ResourceRepository.Resources.GenericError, ex);
    }
  }

  private void ExportInterfaceForCPS_AstroIndividualIdEditingCheckEvtHandler(
    object sender,
    ASTROIndividualIdEditingEventArgs e)
  {
    string stsMsg = (string) null;
    try
    {
      if (!RMCRadioAccessValidator.AstroIndividualIdEditingEventHandler(e.ASTRORadioSystem, e.CodeplugObject, out stsMsg, e.TargetModelNumber))
        throw CommonExceptionHelper.CreateDirectMessageCommonException(stsMsg);
    }
    catch (CommonException ex)
    {
      throw;
    }
    catch (Exception ex)
    {
      throw CommonExceptionHelper.CreateCommonException(CommonErrorCode.GenericError, Motorola.CommonCPS.ResourceRepository.Resources.GenericError, ex);
    }
  }

  private void ExportInterfaceForCPS_AstroWritingCheckEvtHandler(
    object sender,
    AstroWritingEventArgs e)
  {
    bool bUpdated = false;
    string stsMsg = (string) null;
    Collection<AcpASKLib.SystemKeyData> attachedASKs = (Collection<AcpASKLib.SystemKeyData>) null;
    bool? specialKeyAttached = e.IsSpecialKeyAttached;
    if (e.AttachedASKs != null)
    {
      attachedASKs = (Collection<AcpASKLib.SystemKeyData>) new ObservableCollection<AcpASKLib.SystemKeyData>();
      foreach (ISystemKeyData attachedAsK in e.AttachedASKs)
      {
        AcpASKLib.SystemKeyData systemKeyData = RMCWnd.ConvertACPKeyDataToSystemKeyData(attachedAsK);
        attachedASKs.Add(systemKeyData);
      }
    }
    try
    {
      bool flag = RMCRadioAccessValidator.AstroWritingEventHandler((Radio) e.Device, e.TransportPreference, out bUpdated, out stsMsg, e.IsBatch, e.IsWritingProtect, e.IsRestoreJob, ref attachedASKs, ref specialKeyAttached);
      e.IsUpdated = bUpdated;
      if (!e.IsSpecialKeyAttached.HasValue)
        e.IsSpecialKeyAttached = specialKeyAttached;
      if (e.AttachedASKs == null && attachedASKs != null)
      {
        ObservableCollection<ISystemKeyData> observableCollection = new ObservableCollection<ISystemKeyData>();
        foreach (AcpASKLib.SystemKeyData ACPKeyData in attachedASKs)
        {
          ISystemKeyData systemKeyData = RMCWnd.ACPKeyDataConvertToSystemKeyData(ACPKeyData);
          observableCollection.Add(systemKeyData);
        }
        e.AttachedASKs = (Collection<ISystemKeyData>) observableCollection;
      }
      if (!flag)
        throw CommonExceptionHelper.CreateDirectMessageCommonException(stsMsg);
    }
    catch (CommonException ex)
    {
      throw;
    }
    catch (Exception ex)
    {
      throw CommonExceptionHelper.CreateCommonException(CommonErrorCode.GenericError, Motorola.CommonCPS.ResourceRepository.Resources.GenericError, ex);
    }
  }

  private void ExportInterfaceForCPS_ExportEditCodeplugEvtHandler(object sender, Motorola.CommonCPS.RadioManagement.SharedServices.DeviceEventArgs e)
  {
    if (this._isOpenCodeplug)
      throw new CommonException(CommonErrorCode.RMC_HasCodeplugOpened);
    try
    {
      this._isOpenCodeplug = true;
      if (AppInfoManager.AppMode == ApplicationMode.CustomViewConfigurationMode)
        throw CommonExceptionHelper.CreateCommonException(CommonErrorCode.RMC_HasCustomViewSelected, Motorola.CommonCPS.ResourceRepository.Resources.RMC_HasCustomViewSelected);
      WindowMain mainWindow = (WindowMain) Application.Current.MainWindow;
      byte[] fileContent = e.FileContent;
      string str1 = "Server Archive - ";
      string str2 = e.TempalteObj == null ? str1 + $"{e.DeviceObj.SerialNumber}.{e.DeviceObj.WorkingCodeplug.Template.FileUuid}" : str1 + $"{e.TempalteObj.ModelNumber}.{e.TempalteObj.FileUuid}";
      string str3 = $"{Path.GetTempPath()}{str2}.mc";
      if (!mainWindow.ReadWriteInProgress)
      {
        if (!mainWindow.CpgOpenFlag)
        {
          try
          {
            this.SaveCpsFile(str3, e.FileContent);
            if (mainWindow.WindowState == WindowState.Minimized)
              mainWindow.WindowState = WindowState.Normal;
            if (e.DeviceObj != null)
              this._lastCPModifiedTimestamp = e.DeviceObj.WorkingCodeplug.Timestamp;
            mainWindow.Activate();
            mainWindow.OpenCodeplug(str3, (APXRadio) e.DeviceObj, (APXTemplate) e.TempalteObj);
            mainWindow.OnAppMenuSave((object) this, (RoutedEventArgs) null);
            return;
          }
          catch (Exception ex)
          {
            if (File.Exists(str3))
              File.Delete(str3);
            throw CommonExceptionHelper.CreateCommonException(CommonErrorCode.GenericError, Motorola.CommonCPS.ResourceRepository.Resources.GenericError, ex);
          }
        }
      }
      if (!(str3 == ((App) Application.Current).TheDocument.docFilePath))
        throw CommonExceptionHelper.CreateCommonException(CommonErrorCode.RMC_HasCodeplugOpened, Motorola.CommonCPS.ResourceRepository.Resources.RMC_HasCodeplugOpened);
      if (e.TempalteObj == null)
      {
        Guid? workingCodeplugUuid = e.DeviceObj.WorkingCodeplugUuid;
        Guid? currentCodeplugUuid = e.DeviceObj.CurrentCodeplugUuid;
        if ((workingCodeplugUuid.HasValue == currentCodeplugUuid.HasValue ? (workingCodeplugUuid.HasValue ? (workingCodeplugUuid.GetValueOrDefault() == currentCodeplugUuid.GetValueOrDefault() ? 1 : 0) : 1) : 0) != 0 && !this.IsEquals(this._lastCPModifiedTimestamp, e.DeviceObj.WorkingCodeplug.Timestamp))
          throw CommonExceptionHelper.CreateCommonException(CommonErrorCode.RMC_HasCodeplugOpened, Motorola.CommonCPS.ResourceRepository.Resources.RMC_HasCodeplugOpened);
      }
      if (mainWindow.CurrentAppMode == ApplicationMode.CodeplugComparisonMode)
        AppInfoManager.ComparatorFieldsReport.Clear();
      AppInfoManager.AppMode = ApplicationMode.CodeplugConfigurationMode;
      if (mainWindow.WindowState == WindowState.Minimized)
        mainWindow.WindowState = WindowState.Normal;
      mainWindow.Activate();
      if (e.DeviceObj != null)
        mainWindow.UpdateFieldsWithServerValues((APXRadio) e.DeviceObj);
      if (e.DeviceObj != null)
        (FeatureManager.GetFeature(2010)[0] as Motorola.MackinawCPS.CoreFeatures.DisplayAndMenu.DisplayAndMenu).Advanced.DispMenuAdvancedLanguageSelection_A8386Value = (e.DeviceObj.WorkingCodeplug.Template as APXTemplate).LanguageIndex.Value;
      else if (e.TempalteObj != null)
        (FeatureManager.GetFeature(2010)[0] as Motorola.MackinawCPS.CoreFeatures.DisplayAndMenu.DisplayAndMenu).Advanced.DispMenuAdvancedLanguageSelection_A8386Value = (e.TempalteObj as APXTemplate).LanguageIndex.Value;
      LanguagePackHelper.BindingLanguageSections();
      Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation radioInformation = FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation;
      mainWindow.LaunchSection((IAcpFeatureSection) radioInformation.General);
    }
    finally
    {
      this._isOpenCodeplug = false;
    }
  }

  private bool IsEquals(byte[] b1, byte[] b2)
  {
    return b1 != null && b2 != null && b1.Length == b2.Length && ((IEnumerable<byte>) b1).SequenceEqual<byte>((IEnumerable<byte>) b2);
  }

  public void ExportInterfaceForCPS_ParseAchiveEvtHandler(object sender, OpenFileEventArgs e)
  {
    ApplicationMode CPSMode = AppInfoManager.AppMode;
    APXRadio apxRadio = new APXRadio();
    WindowMain windowMain = this.GetWindowMain();
    string filePath = e.FilePath;
    string password = e.Password;
    if (!string.IsNullOrEmpty(filePath) && (!windowMain.CanOpenCpgFlag || windowMain.ReadWriteInProgress))
      throw new CommonException(new CommonExceptionData(CommonErrorCode.RMC_HasCodeplugOpened));
    string str1 = string.Empty;
    string str2 = string.Empty;
    try
    {
      str1 = Path.GetTempPath() + Path.GetFileName(filePath);
      if (File.Exists(str1))
      {
        File.SetAttributes(str1, FileAttributes.Normal);
        File.Delete(str1);
      }
      File.Copy(filePath, str1);
      File.SetAttributes(str1, FileAttributes.Normal);
      if (!windowMain.OpenCodeplugNonGUI(str1, password, true))
        return;
      if (!windowMain.PromptQuitOnInvalids().Result)
      {
        str2 = Path.ChangeExtension(str1, ".xpba");
        windowMain.SavePBAFileNonGUI((object) this, (RoutedEventArgs) null, str2);
        PbaObject pbaObject = PbaObject.DeserializeFrom(str2);
        e.PBAObject = (object) pbaObject;
      }
      else
      {
        AppInfoManager.InvalidFieldsReport.Clear();
        throw new CommonException(new CommonExceptionData(CommonErrorCode.RMC_The_codeplug_contains_invalid_fields));
      }
    }
    catch (IOException ex)
    {
      throw new CommonException(new CommonExceptionData(CommonErrorCode.RMC_UnableToReadTheFollowingArchive, new string[1]
      {
        filePath
      }));
    }
    catch (CommonException ex)
    {
      throw;
    }
    catch (Exception ex)
    {
      throw new CommonException(new CommonExceptionData(CommonErrorCode.RMC_ImportCodeplug_Error));
    }
    finally
    {
      if (windowMain.CanOpenCpgFlag)
        windowMain.CloseFileNonGUI(false);
      try
      {
        if (File.Exists(str1))
        {
          File.SetAttributes(str1, FileAttributes.Normal);
          File.Delete(str1);
        }
        if (File.Exists(str2))
        {
          File.SetAttributes(str2, FileAttributes.Normal);
          File.Delete(str2);
        }
      }
      catch
      {
      }
      this.Dispatcher.Invoke((Action) (() => AppInfoManager.AppMode = CPSMode));
    }
  }

  private void ExportInterfaceForCPS_ImportDeviceEvtHandler(object sender, OpenFileEventArgs e)
  {
    ApplicationMode CPSMode = AppInfoManager.AppMode;
    APXRadio apxRadio = new APXRadio();
    WindowMain windowMain = this.GetWindowMain();
    string filePath = e.FilePath;
    string password = e.Password;
    bool ignorePassword = e.IgnorePassword;
    if (!string.IsNullOrEmpty(filePath) && (!windowMain.CanOpenCpgFlag || windowMain.ReadWriteInProgress))
      throw new CommonException(new CommonExceptionData(CommonErrorCode.RMC_HasCodeplugOpened));
    if (this._isOpenCodeplug)
      throw new CommonException(CommonErrorCode.RMC_HasCodeplugOpened);
    string str = string.Empty;
    try
    {
      this._isOpenCodeplug = true;
      str = Path.GetTempPath() + Path.GetFileName(filePath);
      if (str.Length >= 260)
        str = str.Remove(250) + ".mc";
      if (File.Exists(str))
      {
        File.SetAttributes(str, FileAttributes.Normal);
        File.Delete(str);
      }
      File.Copy(filePath, str);
      File.SetAttributes(str, FileAttributes.Normal);
      if (!windowMain.OpenCodeplugNonGUI(str, password, true, ignorePassword))
        return;
      if (!windowMain.PromptQuitOnInvalids().Result)
      {
        windowMain.OnAppMenuSaveAsNonGUI((object) this, (RoutedEventArgs) null, str);
        this.PrepareDevice(apxRadio);
        MackinawCPS.CommonUtility.SetFeatureSet((Radio) apxRadio, apxRadio.Uuid);
        e.ImportingRadio = (Radio) apxRadio;
      }
      else
      {
        AppInfoManager.InvalidFieldsReport.Clear();
        throw new CommonException(new CommonExceptionData(CommonErrorCode.RMC_The_codeplug_contains_invalid_fields));
      }
    }
    catch (PathTooLongException ex)
    {
      throw new CommonException(CommonErrorCode.RMC_FilePathTooLong_Error);
    }
    catch (IOException ex)
    {
      throw new CommonException(new CommonExceptionData(CommonErrorCode.RMC_UnableToReadTheFollowingArchive, new string[1]
      {
        filePath
      }));
    }
    catch (CommonException ex)
    {
      throw;
    }
    catch (Exception ex)
    {
      throw new CommonException(new CommonExceptionData(CommonErrorCode.RMC_ImportCodeplug_Error));
    }
    finally
    {
      if (windowMain.CanOpenCpgFlag)
        windowMain.CloseFileNonGUI(false);
      try
      {
        if (File.Exists(str))
        {
          File.SetAttributes(str, FileAttributes.Normal);
          File.Delete(str);
        }
      }
      catch
      {
      }
      this.Dispatcher.Invoke((Action) (() => AppInfoManager.AppMode = CPSMode));
      this._isOpenCodeplug = false;
    }
  }

  private void PrepareDevice(APXRadio device)
  {
    APXCodeplug apxCodeplug = new APXCodeplug();
    APXTemplate template = new APXTemplate();
    apxCodeplug.Template = (Motorola.CommonCPS.Server.EntityModel.Template) template;
    MackinawCPS.CommonUtility.PopulatecpAndDeviceColumnsFromDatabaseLayer(apxCodeplug, (Radio) device, PopulateOpeartion.Import);
    VAHelper.AttachVoiceAnnouncemnetReference(template);
    CACertificatesHelper.AttachCACertificateReference(template);
    DVRSFilesHelper.AttachDVRSFileReference(template);
    this.AddLanguagePackInformation(apxCodeplug, template);
    this.CopyVaFromTemplateToCp(apxCodeplug, template);
    this.CopyCACertsFromTemplateToCp(apxCodeplug, template);
    this.CopyDVRSFilesFromTemplateToCp(apxCodeplug, template);
    device.WorkingCodeplug = (Codeplug) apxCodeplug;
    device.ProductFamily = new int?(UtilityMack.IsAPXNextOrAloha ? 4096 /*0x1000*/ : 1);
    apxCodeplug.Template.ProductFamily = new int?(UtilityMack.IsAPXNextOrAloha ? 4096 /*0x1000*/ : 1);
  }

  private void CopyVaFromTemplateToCp(APXCodeplug codeplug, APXTemplate template)
  {
    codeplug.ASTROVoiceAnnouncements = template.ASTROVoiceAnnouncements;
  }

  private void CopyCACertsFromTemplateToCp(APXCodeplug codeplug, APXTemplate template)
  {
    codeplug.ASTROCACertificates = template.ASTROCACertificates;
  }

  private void CopyDVRSFilesFromTemplateToCp(APXCodeplug codeplug, APXTemplate template)
  {
    codeplug.ASTRODVRSFiles = template.ASTRODVRSFiles;
  }

  private void AddLanguagePackInformation(APXCodeplug codeplug, APXTemplate template)
  {
    int? languageIndex = template.LanguageIndex;
    int num = 0;
    if (!(languageIndex.GetValueOrDefault() == num & languageIndex.HasValue))
    {
      ASTROLanguagePack fakeLanguagePackage = ASTROLanguageUtility.Instance.CreateFakeLanguagePackage(template.LanguageIndex.ToString());
      codeplug.ASTROLanguagePack = fakeLanguagePackage;
      template.ASTROLanguagePack = fakeLanguagePackage;
    }
    codeplug.LanguageSetting = ASTROLanguageUtility.Instance.GetLanguageSettingInfoForRadio(template);
  }

  private void Window_Closing(object sender, CancelEventArgs e)
  {
    WindowMain windowMain = this.GetWindowMain();
    e.Cancel = true;
    if (windowMain != null && windowMain.InRMCEditSession)
    {
      int num = (int) MessageBox.Show(Motorola.CommonCPS.ResourceRepository.Resources.RMC_HasCodeplugOpened);
    }
    else
    {
      RadioManagementBootstrapper.Disconnect();
      RuntimeInfo.IsConnected = false;
      RuntimeInfo.IsCurrentSessionConnected = false;
      RuntimeInfo.UserName = string.Empty;
      if (RuntimeInfo.SecurePassword != null)
        RuntimeInfo.SecurePassword.Clear();
      RuntimeInfo.WorkingUserName = string.Empty;
      if (RuntimeInfo.WorkingSecurePassword != null)
        RuntimeInfo.WorkingSecurePassword.Clear();
      this.Hide();
    }
  }

  private void RMCWnd_AstroCheckHoptionEnableEvtHandler(
    object sender,
    ASTROHoptionEnableEventArgs e)
  {
    e.IsEnable = RMCRadioAccessValidator.AstroHoptionEnableEventHandler(e.Flashcode, e.Hoption, e.Modelnumber);
  }

  private void RMCWnd_AstroCheckIsConvOnlyEvtHandler(object sender, ASTROHoptionEnableEventArgs e)
  {
    e.IsEnable = RMCRadioAccessValidator.AstrCheckIsConvOnlyEvtHandler(e.Flashcode, e.Modelnumber);
  }

  private void RMCWnd_AstroUpgradeCodeplugEvtHandler(object sender, AstroUpgradeCodeplugEventArgs e)
  {
    if (this._isOpenCodeplug)
      throw new CommonException(CommonErrorCode.RMC_HasCodeplugOpened);
    ResultStatus resultStatus1 = new ResultStatus();
    string str1 = $"{Path.GetTempPath()}{Guid.NewGuid().ToString()}.mc";
    ApplicationMode CPSMode = AppInfoManager.AppMode;
    try
    {
      this._isOpenCodeplug = true;
      this.SaveCpsFile(str1, e.Syncdata.CpFileContent);
      HOptionAdvancedKeyIDS keyIDS = (HOptionAdvancedKeyIDS) null;
      string str2 = SpecialFeatures.Flashport.FlashRadio.FlashcodeFormatter.FormatFlashcodeString(e.Syncdata.FlashCode, e.Syncdata.FlashCode.Length);
      OwnerSystemData systemID = (OwnerSystemData) null;
      if (e.SelectedSystemID != null)
        systemID = new OwnerSystemData(e.SelectedSystemID.SystemID, this.ConvertASKInterfaceKeyType2AcpASKLibKeyType(e.SelectedSystemID.Type));
      ResultStatus resultStatus2 = this.UpdateCodeplug(e.Syncdata.SourceTemplate, str1, str2, e.Syncdata.ModelNumber, e.Syncdata.IButtonSerialNumber, e.Syncdata.RadioHostVersion, e.Syncdata.FirmwareVersion, e.Syncdata.bRefresh, systemID, out keyIDS, e.Syncdata.Firmware);
      if (!resultStatus2.Result)
        throw CommonExceptionHelper.CreateCommonException(CommonErrorCode.RMC_PM_UpgradeCodeplugFailed, resultStatus2.ResultMessage);
      byte[] numArray;
      using (FileStream input = new FileStream(str1, FileMode.Open, FileAccess.Read))
      {
        using (BinaryReader binaryReader = new BinaryReader((Stream) input))
          numArray = binaryReader.ReadBytes(Convert.ToInt32(input.Length));
      }
      e.Syncdata.CpFileContent = numArray;
      e.Syncdata.hOptionAdvancedKeyIDS = keyIDS;
      e.Syncdata.RadioFeaturesRequest = this.ListFeatureSet(str2, e.Syncdata.ModelNumber);
    }
    catch (IOException ex)
    {
      throw new CommonException(new CommonExceptionData(CommonErrorCode.RMC_UnableToReadTheFollowingArchive, new string[1]
      {
        str1
      }));
    }
    catch (CommonException ex)
    {
      throw;
    }
    catch (Exception ex)
    {
      throw CommonExceptionHelper.CreateCommonException(CommonErrorCode.RMC_PM_UpgradeCodeplugFailed, Motorola.CommonCPS.ResourceRepository.Resources.RMC_PM_UpgradeCodeplugFailed);
    }
    finally
    {
      this.Dispatcher.Invoke((Action) (() => AppInfoManager.AppMode = CPSMode));
      if (File.Exists(str1))
        File.Delete(str1);
      this._isOpenCodeplug = false;
    }
  }

  private void RMCWnd_AnalysisPackageEvtHandler(object sender, AnalysisPackageEventArgs e)
  {
    try
    {
      if (!File.Exists(e.filePath))
        return;
      if (BundleNameUtility.IsCVNFile(e.filePath) || BundleNameUtility.IsBBFFile(e.filePath) || BundleNameUtility.IsZIPFile(e.filePath))
      {
        e.AstroFWPackageInfos = (IList<Package>) this.AnaysisListFirmwarePackage(e.filePath).Select<ASTROFirmware, Package>((Func<ASTROFirmware, Package>) (x => (Package) x)).ToList<Package>();
        e.PackageInfo = e.AstroFWPackageInfos.FirstOrDefault<Package>();
      }
      else if (e.filePath.EndsWith(".wav") || e.filePath.EndsWith(".mva"))
        e.PackageInfo = (Package) VAHelper.AnaysisVAPackageInfo(e.filePath);
      else if (e.filePath.EndsWith(".dcd", StringComparison.CurrentCultureIgnoreCase))
        e.PackageInfo = (Package) DVRSFilesHelper.AnalysisDVRSFilePackageInfo(e.filePath);
      else
        e.PackageInfo = (Package) CACertificatesHelper.AnalysisCACertificatePackageInfo(e.filePath);
    }
    catch (CommonException ex)
    {
      throw;
    }
    catch (Exception ex)
    {
      throw CommonExceptionHelper.CreateDirectMessageCommonException(Motorola.CommonCPS.ResourceRepository.Resources.AnaysisPackageFailed);
    }
  }

  private void RMCWnd_LanguagePackInfosEvtHandler(object sender, ListLpPackageEventArgs e)
  {
    try
    {
      string[] strArray = Directory.Exists(LanguagePackHelper.LanguagePackFolderPath) ? Directory.GetFiles(LanguagePackHelper.LanguagePackFolderPath, "*.lpk") : throw CommonExceptionHelper.CreateDirectMessageCommonException(Motorola.CommonCPS.ResourceRepository.Resources.Astro_CPS_LP_NotFound);
      e.LanguagePacks = new List<Package>();
      foreach (string packagePath in strArray)
      {
        try
        {
          e.LanguagePacks.Add((Package) LanguagePackHelper.ParseLanguagePackage(packagePath));
        }
        catch (Exception ex)
        {
        }
      }
    }
    catch (CommonException ex)
    {
      throw;
    }
    catch (Exception ex)
    {
      throw CommonExceptionHelper.CreateDirectMessageCommonException(Motorola.CommonCPS.ResourceRepository.Resources.AnaysisPackageFailed);
    }
  }

  private void RMCWnd_AstroDecodeLangageIndexToLpIDEvtHandler(
    object sender,
    AstroDecodeLanguageIndexToLPIDEventArgs e)
  {
    e.LanguagePackageID = LanguagePackHelper.GetAstroLanugagePackID(e.LanguageIndex);
  }

  private void RMCWnd_AstroLanguagePackCompatibleCheckEvtHandler(
    object sender,
    AstroLanguageCompatibleCheckEventArgs e)
  {
    try
    {
      if (!e.Detailed)
      {
        e.IsCompatible = LanguagePackHelper.IsFirmwareLPCompatible(e.FirmwareVersion, e.LanguageIndex);
      }
      else
      {
        string stat = (string) null;
        e.IsCompatible = LanguagePackHelper.IsFirmwareLPCompatible(e.FirmwareVersion, ref stat, e.LanguageIndex, UtilityMack.IsPortablePro);
        e.Stat = stat;
      }
    }
    catch
    {
      e.IsCompatible = false;
    }
  }

  private void RMCWnd_BindingServerLanguagePackEvtHandler(
    object sender,
    BindingServerLanguagePackEventArgs e)
  {
    try
    {
      e.IsNeedBinding = LanguagePackHelper.IsNeedBindingServerLanguagePack(e.FirmwareVersion);
    }
    catch
    {
      e.IsNeedBinding = false;
    }
  }

  private void RMCWnd_AstroUpgradeWithLanugagePackIsSupportedCheckEvtHandler(
    object sender,
    AstroUpgradeWithLanugagePackIsSupportedCheckEventArgs e)
  {
    try
    {
      e.IsSupported = LanguagePackHelper.IsRadioUpgradeHostGreaterThan_7_12(e.RadioFirmwareVersion, e.CVNFirmwareVersion);
    }
    catch
    {
      e.IsSupported = false;
    }
  }

  private void RMCWnd_AstroUpgradeFWVerCompatibleCheckEvtHandler(
    object sender,
    AstroUpgradeFWCompatibleCheckEventArgs e)
  {
    try
    {
      e.IsCompatible = !UpgradeRadioValidator.IsCPSVersionLowerThanFirmwareUpgradeVersion(e.CVNHostVersion, AppInfoManager.AppVersion);
    }
    catch
    {
      e.IsCompatible = false;
    }
  }

  private void RCWnd_GetFinalSupportedFWVersion(
    object sender,
    AstroFinalFWSupportedVersionsEventArgs e)
  {
    e.FinalFWVersions = UpgradeRadioValidator.AllSupportedFirmwareVersions;
  }

  private void RMCWnd_AstroReadFlashKeyEvtHandler(object sender, AstroFlashKeyEventArgs e)
  {
    RMCFlashkey rmcFlashkey = new RMCFlashkey();
    try
    {
      if (rmcFlashkey.Open(e.KeyInfo.OldModelNumber, SpecialFeatures.Flashport.FlashRadio.FlashcodeFormatter.FormatFlashcodeString(e.KeyInfo.OldFlashCode, e.KeyInfo.OldFlashCode.Length)))
      {
        e.KeyInfo.NewModelNumber = rmcFlashkey.NewModelNumber;
        byte[] decoded = new byte[0];
        SpecialFeatures.Flashport.FlashRadio.FlashcodeDecoder.Decode(rmcFlashkey.NewFlashcode, ref decoded);
        e.KeyInfo.NewFlashCode = decoded;
        e.KeyInfo.iButtonSerialNumber = rmcFlashkey.SerialNumber;
        e.KeyInfo.DateCode = rmcFlashkey.DateCode;
        e.KeyInfo.FactoryOrderNumber = rmcFlashkey.FactoryOrderNumber;
        e.KeyInfo.UpgradesPurchased = rmcFlashkey.UpgradesPurchased;
        e.KeyInfo.UpgradesRemaining = rmcFlashkey.UpgradesRemaining;
      }
      else
        e.KeyInfo = (FlashKeyInfo) null;
    }
    catch (CommonException ex)
    {
      throw;
    }
    catch (Exception ex)
    {
      throw CommonExceptionHelper.CreateCommonException(CommonErrorCode.GenericError, Motorola.CommonCPS.ResourceRepository.Resources.GenericError, ex);
    }
    finally
    {
      rmcFlashkey.Close();
    }
  }

  private void RMCWnd_AstroDecraseFlashKeyEvtHandler(
    object sender,
    AstroDecreaseKeyCountEventArgs e)
  {
    RMCFlashkey rmcFlashkey = new RMCFlashkey();
    try
    {
      if (!rmcFlashkey.Open(e.OldModelNumber, SpecialFeatures.Flashport.FlashRadio.FlashcodeFormatter.FormatFlashcodeString(e.OldFlashCode, e.OldFlashCode.Length)))
        throw CommonExceptionHelper.CreateCommonException(CommonErrorCode.RMC_FlashKey_NotFound, Motorola.CommonCPS.ResourceRepository.Resources.RMC_FlashKey_NotFound);
      if (rmcFlashkey.UpgradesRemaining < e.DecreaseKeyCount)
        throw CommonExceptionHelper.CreateCommonException(CommonErrorCode.RMC_FlashKeyReminingCountNotEnough, Motorola.CommonCPS.ResourceRepository.Resources.RMC_FlashKeyReminingCountNotEnough);
      rmcFlashkey.DecrementFlashkeyCounter(e.DecreaseKeyCount);
    }
    catch (CommonException ex)
    {
      throw;
    }
    catch (Exception ex)
    {
      throw CommonExceptionHelper.CreateCommonException(CommonErrorCode.RMC_FlashKeyDecraseFailed, Motorola.CommonCPS.ResourceRepository.Resources.GenericError, ex);
    }
    finally
    {
      rmcFlashkey.Close();
    }
  }

  private void RMCWnd_AstroValidateFlashKeyEvtHandler(object sender, AstroFlashKeyEventArgs e)
  {
    RMCFlashkey rmcFlashkey = new RMCFlashkey();
    e.IsValid = rmcFlashkey.ValidateFlashKey();
  }

  private void RMCWnd_AstroReleaseFlashKeyEvtHandler(object sender, EventArgs e)
  {
    FlashKeyManagerSingleTon.ReleaseFlashKeyManager();
  }

  private void RMCWnd_AstroDecodeFlashCodeEvtHandler(object sender, AstroDecodeFlashCodeEventArgs e)
  {
    e.DecodeFlashCode = SpecialFeatures.Flashport.FlashRadio.FlashcodeFormatter.FormatFlashcodeString(e.FlashCode, e.FlashCode.Length);
  }

  private void RMCWnd_AstroPINPasswordConvertEventHandler(
    object sender,
    AstroPINPasswordConvertEventArgs e)
  {
    if (e.IsEncrypt)
      e.Target = AESCryptoUtil.AESEncryptWithDefKey(e.Source);
    else
      e.Target = AESCryptoUtil.AESDecryptWithDefKey(e.Source);
  }

  private void RMCWnd_AstroGetLoadedSysKeysEvtHandlerEvtHandler(
    object sender,
    AstroSystemKeyDataEventArgs e)
  {
    ObservableCollection<AcpASKLib.SystemKeyData> observableCollection1 = new ObservableCollection<AcpASKLib.SystemKeyData>();
    if (e.IsAttached)
    {
      Collection<AcpASKLib.SystemKeyData> loadedAndAttachedAsKs = SecurityManager.GetSysKeysFromLoadedAndAttachedASKs();
      if (loadedAndAttachedAsKs != null && loadedAndAttachedAsKs.Count > 0)
        observableCollection1 = new ObservableCollection<AcpASKLib.SystemKeyData>((IEnumerable<AcpASKLib.SystemKeyData>) loadedAndAttachedAsKs);
    }
    else
      observableCollection1 = SecurityManager.LoadedASKs;
    ObservableCollection<ISystemKeyData> observableCollection2 = new ObservableCollection<ISystemKeyData>();
    foreach (AcpASKLib.SystemKeyData ACPKeyData in (Collection<AcpASKLib.SystemKeyData>) observableCollection1)
    {
      ISystemKeyData systemKeyData = RMCWnd.ACPKeyDataConvertToSystemKeyData(ACPKeyData);
      observableCollection2.Add(systemKeyData);
    }
    e.LoadedSysKeys = observableCollection2;
  }

  public static void AnalysisFirmwarePackage(string upgradeFilePath, ref ASTROFirmware packageInfo)
  {
    FlashportUpgradeFile flashportUpgradeFile = new FlashportUpgradeFile(upgradeFilePath);
    try
    {
      if (flashportUpgradeFile == null)
        throw CommonExceptionHelper.CreateDirectMessageCommonException(AppResources.Failed_to_open.AcpStringFormat((object) flashportUpgradeFile.UpgradeFilePath));
      if (BundleNameUtility.IsCVNFile(upgradeFilePath))
      {
        if (flashportUpgradeFile.OpenUpgradeFile())
        {
          if (flashportUpgradeFile.ComponentPresent("HFWS"))
          {
            packageInfo.SoftwareVersion = flashportUpgradeFile.GetFileComponentVersion("HFWS", false);
            packageInfo.DspVersion = flashportUpgradeFile.GetFileComponentVersion("DFWD", false);
            if (string.IsNullOrEmpty(packageInfo.DspVersion))
              packageInfo.DspVersion = packageInfo.SoftwareVersion;
            packageInfo.HfwsFlag = new int?(1);
          }
          else
          {
            packageInfo.HfwsFlag = new int?(0);
            packageInfo.SoftwareVersion = flashportUpgradeFile.GetFileComponentVersion("HFWA", false);
            packageInfo.DspVersion = flashportUpgradeFile.GetFileComponentVersion("DFWA");
            packageInfo.PsdtVersion = flashportUpgradeFile.GetFileComponentVersion("PDTA");
          }
          RMFile rmFile = new RMFile()
          {
            Url = upgradeFilePath
          };
          packageInfo.RMFile = rmFile;
          packageInfo.MaceFlashVersion = flashportUpgradeFile.GetFileComponentVersion("CFWI", false);
          packageInfo.PackageVersion = packageInfo.SoftwareVersion;
          packageInfo.PackageName = Path.GetFileName(upgradeFilePath);
          packageInfo.ConBrdHwHostVersion = flashportUpgradeFile.GetFileComponentVersion("CON1", false);
          packageInfo.OptBrdHwHostVersion = flashportUpgradeFile.GetFileComponentVersion("OB01", false);
          packageInfo.TargetModel = flashportUpgradeFile.GetFileTargetModelNumber();
          packageInfo.LTEOptBrdHwHostVersion = flashportUpgradeFile.GetFileComponentVersion("OB02", false);
          packageInfo.IsFreonFirmwareUpgradeFile = new bool?(false);
          packageInfo.IsOMAPFirmwareUpgradeFile = new bool?(false);
          packageInfo.IsVirtualSummaryFirmware = new bool?(false);
        }
        else
          throw CommonExceptionHelper.CreateDirectMessageCommonException(AppResources.Failed_to_open.AcpStringFormat((object) flashportUpgradeFile.UpgradeFilePath));
      }
      else if (BundleNameUtility.IsBBFFile(upgradeFilePath))
      {
        bool flag = false;
        string modelNumberForBbf = flashportUpgradeFile.GetFileTargetModelNumberForBBF();
        if (!BundleNameUtility.IsBBFBundle(modelNumberForBbf))
          throw CommonExceptionHelper.CreateDirectMessageCommonException(AppResources.UpgradeRadio_UFcanv.AcpStringFormat((object) flashportUpgradeFile));
        int num = flashportUpgradeFile.verifyBBFMagicNumber() ? 1 : 0;
        if (num != 0)
          flag = flashportUpgradeFile.verifyChecksum();
        packageInfo.SoftwareVersion = flashportUpgradeFile.GetBBFSuiteVersion();
        if (num == 0 || !flag)
          throw CommonExceptionHelper.CreateDirectMessageCommonException(AppResources.UpgradeRadio_UFcanv.AcpStringFormat((object) flashportUpgradeFile));
        RMFile rmFile = new RMFile()
        {
          Url = upgradeFilePath
        };
        packageInfo.RMFile = rmFile;
        packageInfo.PackageVersion = packageInfo.SoftwareVersion;
        packageInfo.PackageName = Path.GetFileName(upgradeFilePath);
        packageInfo.TargetModel = modelNumberForBbf;
        packageInfo.IsVirtualSummaryFirmware = new bool?(false);
        if (BundleNameUtility.IsOMAPBundle(modelNumberForBbf))
        {
          packageInfo.IsOMAPFirmwareUpgradeFile = new bool?(true);
          packageInfo.IsFreonFirmwareUpgradeFile = new bool?(false);
        }
        else if (BundleNameUtility.IsFreonBundle(modelNumberForBbf))
        {
          packageInfo.IsOMAPFirmwareUpgradeFile = new bool?(false);
          packageInfo.IsFreonFirmwareUpgradeFile = new bool?(true);
        }
      }
      else
        throw CommonExceptionHelper.CreateDirectMessageCommonException(AppResources.Failed_to_open.AcpStringFormat((object) flashportUpgradeFile.UpgradeFilePath));
      packageInfo.IsCompatible = !UpgradeRadioValidator.IsCPSVersionLowerThanFirmwareUpgradeVersion(packageInfo.PackageVersion, AppInfoManager.AppVersion);
    }
    catch (Exception ex)
    {
      throw CommonExceptionHelper.CreateDirectMessageCommonException(AppResources.Failed_to_open.AcpStringFormat((object) flashportUpgradeFile.UpgradeFilePath));
    }
    finally
    {
      GC.Collect();
    }
  }

  public void AnalyzeZipFirmwarePackage(string upgradeFilePath, ref ASTROFirmware packageInfo)
  {
    FlashportUpgradeFile flashportUpgradeFile = new FlashportUpgradeFile(upgradeFilePath);
    try
    {
      if (flashportUpgradeFile == null)
        throw CommonExceptionHelper.CreateDirectMessageCommonException(AppResources.Failed_to_open.AcpStringFormat((object) flashportUpgradeFile.UpgradeFilePath));
      this._firmwareFileValidator.VerifyFirmwareContent(upgradeFilePath);
      string metadata1 = MetadataFileParser.ExtractMetadata(upgradeFilePath);
      MetadataFile metadata2 = MetadataFileParser.ParseMetadata(metadata1);
      MetadataFileValidator.VerifyMetadataFileContent(metadata2);
      RMFile rmFile = new RMFile() { Url = upgradeFilePath };
      packageInfo.RMFile = rmFile;
      packageInfo.PackageVersion = metadata2.PostBuildIncremental;
      packageInfo.SoftwareVersion = metadata2.PostBuildIncremental;
      packageInfo.BPSoftwareVersion = metadata2.BpFirmware;
      packageInfo.BaseSoftwareVersion = metadata2.PreBuildIncremental;
      long result1;
      packageInfo.BuildTimestamp = long.TryParse(metadata2.PostTimestamp, out result1) ? new long?(result1) : new long?();
      packageInfo.PackageName = Path.GetFileName(upgradeFilePath);
      packageInfo.TargetModel = metadata2.TargetDevice;
      packageInfo.IsFreonFirmwareUpgradeFile = new bool?(true);
      packageInfo.IsOMAPFirmwareUpgradeFile = new bool?(false);
      packageInfo.IsVirtualSummaryFirmware = new bool?(false);
      packageInfo.TargetRelease = metadata2.TargetRelease;
      packageInfo.MaxCodeplugVersion = ReleaseToCodeplugMapper.GetMaxSupportedCodeplug(metadata2.TargetRelease);
      packageInfo.Metadata = metadata1;
      packageInfo.TargetReleaseType = new int?();
      TargetReleaseType result2;
      if (Enum.TryParse<TargetReleaseType>(metadata2.TargetReleaseType, true, out result2))
        packageInfo.TargetReleaseType = new int?((int) result2);
      string cvnHostVersion = packageInfo.MaxCodeplugVersion ?? "R00.00.000";
      if (MetadataFileValidator.VerifyIsTargetDevice(metadata2, "aloha"))
      {
        MetadataFileValidator.VerifyAllowedTargetDevice(metadata2, "aloha");
        packageInfo.IsCompatible = !UpgradeRadioValidator.IsCPSVersionLowerThanFirmwareUpgradeVersion(cvnHostVersion, AppInfoManager.AppVersion);
      }
      else if (MetadataFileValidator.VerifyIsTargetDevice(metadata2, "amp"))
      {
        MetadataFileValidator.VerifyAllowedTargetDevice(metadata2, "amp");
        packageInfo.IsCompatible = !UpgradeRadioValidator.IsCPSVersionLowerThanFirmwareUpgradeVersion(cvnHostVersion, AppInfoManager.AppVersion);
      }
      else
        throw CommonExceptionHelper.CreateDirectMessageCommonException(AppResources.Failed_to_open.AcpStringFormat((object) flashportUpgradeFile.UpgradeFilePath));
    }
    catch (Exception ex)
    {
      throw CommonExceptionHelper.CreateDirectMessageCommonException(AppResources.Failed_to_open.AcpStringFormat((object) flashportUpgradeFile.UpgradeFilePath));
    }
  }

  public IList<ASTROFirmware> AnaysisListFirmwarePackage(string upgradeFilePath)
  {
    IList<ASTROFirmware> astroFirmwareList = (IList<ASTROFirmware>) new List<ASTROFirmware>();
    FlashportUpgradeFile flashportUpgradeFile = new FlashportUpgradeFile(upgradeFilePath);
    try
    {
      if (flashportUpgradeFile == null)
        throw CommonExceptionHelper.CreateDirectMessageCommonException(AppResources.Failed_to_open.AcpStringFormat((object) flashportUpgradeFile.UpgradeFilePath));
      if (BundleNameUtility.IsCVNFile(upgradeFilePath))
      {
        ASTROFirmware packageInfo = new ASTROFirmware();
        RMCWnd.AnalysisFirmwarePackage(upgradeFilePath, ref packageInfo);
        astroFirmwareList.Add(packageInfo);
      }
      else if (BundleNameUtility.IsBBFFile(upgradeFilePath))
      {
        string modelNumberForBbf = flashportUpgradeFile.GetFileTargetModelNumberForBBF();
        string bbfSuiteVersion = flashportUpgradeFile.GetBBFSuiteVersion();
        if (BundleNameUtility.IsBBFBundle(modelNumberForBbf))
        {
          ASTROFirmware packageInfo = new ASTROFirmware();
          RMCWnd.AnalysisFirmwarePackage(upgradeFilePath, ref packageInfo);
          astroFirmwareList.Add(packageInfo);
        }
        else if (BundleNameUtility.IsMegaBundle(modelNumberForBbf))
        {
          IList<string> stringList = RMCWnd.SeparateMegaBBF(upgradeFilePath);
          if (stringList != null && stringList.Count > 0)
          {
            foreach (string upgradeFilePath1 in (IEnumerable<string>) stringList)
            {
              ASTROFirmware astroFirmware = new ASTROFirmware();
              ref ASTROFirmware local = ref astroFirmware;
              RMCWnd.AnalysisFirmwarePackage(upgradeFilePath1, ref local);
              astroFirmware.IsSubFirmware = new bool?(true);
              astroFirmwareList.Add(astroFirmware);
            }
            foreach (ASTROFirmware astroFirmware in (IEnumerable<ASTROFirmware>) astroFirmwareList)
            {
              if (!bbfSuiteVersion.Equals(astroFirmware.PackageVersion))
                throw new Exception("CommonRFResources.Failed_to_open: " + flashportUpgradeFile.UpgradeFilePath);
            }
            ASTROFirmware astroFirmware1 = new ASTROFirmware()
            {
              SoftwareVersion = bbfSuiteVersion
            };
            astroFirmware1.PackageVersion = astroFirmware1.SoftwareVersion;
            astroFirmware1.PackageName = Path.GetFileName(upgradeFilePath);
            astroFirmware1.TargetModel = "apx_cps";
            astroFirmware1.IsOMAPFirmwareUpgradeFile = new bool?(true);
            astroFirmware1.IsFreonFirmwareUpgradeFile = new bool?(true);
            astroFirmware1.IsVirtualSummaryFirmware = new bool?(true);
            astroFirmware1.IsSubFirmware = new bool?(false);
            astroFirmwareList.Add(astroFirmware1);
          }
          else
            throw CommonExceptionHelper.CreateDirectMessageCommonException(AppResources.Failed_to_open.AcpStringFormat((object) flashportUpgradeFile.UpgradeFilePath));
        }
        else
          throw CommonExceptionHelper.CreateDirectMessageCommonException(AppResources.Failed_to_open.AcpStringFormat((object) flashportUpgradeFile.UpgradeFilePath));
      }
      else if (BundleNameUtility.IsZIPFile(upgradeFilePath))
      {
        ASTROFirmware packageInfo = new ASTROFirmware();
        this.AnalyzeZipFirmwarePackage(upgradeFilePath, ref packageInfo);
        astroFirmwareList.Add(packageInfo);
      }
      else
        throw CommonExceptionHelper.CreateDirectMessageCommonException(AppResources.Failed_to_open.AcpStringFormat((object) flashportUpgradeFile.UpgradeFilePath));
    }
    catch (Exception ex)
    {
      throw CommonExceptionHelper.CreateDirectMessageCommonException(AppResources.Failed_to_open.AcpStringFormat((object) flashportUpgradeFile.UpgradeFilePath));
    }
    return astroFirmwareList;
  }

  private static IList<string> SeparateMegaBBF(string upgradeFilePath)
  {
    IList<string> stringList = (IList<string>) new List<string>();
    FlashportUpgradeFile flashportUpgradeFile = new FlashportUpgradeFile(upgradeFilePath);
    bool flag = false;
    int num = flashportUpgradeFile.verifyBBFMagicNumber() ? 1 : 0;
    if (num != 0)
      flag = flashportUpgradeFile.verifyChecksum();
    if (num == 0 || !flag)
      throw CommonExceptionHelper.CreateDirectMessageCommonException(AppResources.Failed_to_open.AcpStringFormat((object) flashportUpgradeFile.UpgradeFilePath));
    Dictionary<string, byte[]> allSectionsData = flashportUpgradeFile.GetAllSectionsData();
    if (allSectionsData != null && allSectionsData.Keys.Count > 0)
    {
      foreach (string key in allSectionsData.Keys)
      {
        string path1 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Motorola\\CommonCPS\\Mega");
        string path2 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Motorola\\CommonCPS\\Mega", key);
        if (!Directory.Exists(path1))
          Directory.CreateDirectory(path1);
        if (File.Exists(path2))
          File.Delete(path2);
        File.WriteAllBytes(path2, allSectionsData[key]);
        stringList.Add(path2);
      }
      return stringList;
    }
    throw CommonExceptionHelper.CreateDirectMessageCommonException(AppResources.Failed_to_open.AcpStringFormat((object) flashportUpgradeFile.UpgradeFilePath));
  }

  private ResultStatus UpdateCodeplug(
    APXTemplate targetTemplate,
    string sFileName,
    string flashcode,
    string modelNumber,
    string iButtonSerialNumber,
    string radioHostVersion,
    string cvnHostVersion,
    bool bRefresh,
    OwnerSystemData systemID,
    out HOptionAdvancedKeyIDS keyIDS,
    ASTROFirmware astroFirmware)
  {
    ResultStatus resultStatus = new ResultStatus();
    keyIDS = (HOptionAdvancedKeyIDS) null;
    ApplicationMode CPSMode = AppInfoManager.AppMode;
    WindowMain windowMain = this.GetWindowMain();
    if (windowMain.CanOpenCpgFlag)
    {
      if (!windowMain.ReadWriteInProgress)
      {
        try
        {
          if (windowMain.OpenCodeplugNonGUI(sFileName, (string) null, true, true))
          {
            UtilityMack.bOpenFromRMC = true;
            FlashCodeplug flashCodeplug = new FlashCodeplug();
            flashCodeplug.postCodeplugInitialization();
            UpgradeRadio upgradeRadio = new UpgradeRadio((BackgroundWorker) null, bRefresh, modelNumber, radioHostVersion, cvnHostVersion, astroFirmware);
            upgradeRadio.PreUpgradeCodeplugHandler();
            upgradeRadio.SetDeviceInfoField();
            if (!bRefresh)
            {
              resultStatus.Result = flashCodeplug.UpgradeCodeplug(modelNumber, flashcode, false, ownerSystemData: systemID);
              keyIDS = flashCodeplug.keyIDS;
            }
            else
              resultStatus.Result = true;
            if (!string.IsNullOrEmpty(cvnHostVersion))
            {
              if (UtilityMack.IsAPXNextOrAloha)
                upgradeRadio.fileHostVersion = astroFirmware.BPSoftwareVersion;
              upgradeRadio.PostUpgradeCodeplugHandler(flashcode);
              upgradeRadio.ApplyModelTiering();
              ConstraintManager.Suspend();
            }
            else
            {
              upgradeRadio.SetActionTypeAfterUpgrade();
              upgradeRadio.SyncActiveMicForBTPTT();
              upgradeRadio.RefreshAESFields();
            }
            upgradeRadio.ApplyModelTiering();
            flashCodeplug.SetPostFlashCodeplugFields(iButtonSerialNumber);
            if (resultStatus.Result)
            {
              resultStatus = windowMain.PromptQuitOnInvalids();
              resultStatus.Result = !resultStatus.Result;
              if (resultStatus.Result)
              {
                windowMain.OnAppMenuSaveAsNonGUI((object) this, (RoutedEventArgs) null, sFileName);
              }
              else
              {
                int num = (int) MessageBox.Show(resultStatus.ResultMessage, Motorola.CommonCPS.ResourceRepository.Resources.RMC_PM_UpgradeCodeplugFailed, MessageBoxButton.OK);
              }
            }
            if (!bRefresh)
              MackinawCPS.CommonUtility.PopulateTemplateColumnsFromDatabaseLayer(targetTemplate);
          }
        }
        catch (IOException ex)
        {
          throw new CommonException(new CommonExceptionData(CommonErrorCode.RMC_UnableToReadTheFollowingArchive, new string[1]
          {
            sFileName
          }));
        }
        catch (CommonException ex)
        {
          throw;
        }
        catch (UpgradeRadioException ex)
        {
          if (ex.Message.Contains(string.Format(AppResources.is_an_invalid_flashcode, (object) flashcode)))
            throw new CommonException(new CommonExceptionData(CommonErrorCode.RMC_invalid_flashcode, new string[1]
            {
              flashcode
            }));
          throw CommonExceptionHelper.CreateCommonException(CommonErrorCode.RMC_PM_UpgradeCodeplugFailed, Motorola.CommonCPS.ResourceRepository.Resources.RMC_PM_UpgradeCodeplugFailed);
        }
        catch (Exception ex)
        {
          throw CommonExceptionHelper.CreateCommonException(CommonErrorCode.RMC_PM_UpgradeCodeplugFailed, Motorola.CommonCPS.ResourceRepository.Resources.RMC_PM_UpgradeCodeplugFailed);
        }
        finally
        {
          if (windowMain.CanOpenCpgFlag)
            windowMain.CloseFileNonGUI();
          this.Dispatcher.Invoke((Action) (() => AppInfoManager.AppMode = CPSMode));
        }
        return resultStatus;
      }
    }
    throw CommonExceptionHelper.CreateCommonException(CommonErrorCode.RMC_HasCodeplugOpened, Motorola.CommonCPS.ResourceRepository.Resources.RMC_HasCodeplugOpened);
  }

  private void RMCWnd_PopulateRadioFeaturesFromCodeplugEvtHandler(
    object sender,
    PopulateRadioFeaturesFromCodeplugEventArgs e)
  {
    string flashCode = "";
    try
    {
      flashCode = SpecialFeatures.Flashport.FlashRadio.FlashcodeFormatter.FormatFlashcodeString(e.AstroPurchasedFlashCode, e.AstroPurchasedFlashCode.Length);
      List<RadioFeatureRequest> radioFeatureRequestList = this.ListFeatureSet(flashCode, e.ModelNumber);
      e.featuresRequest = radioFeatureRequestList;
    }
    catch (CommonException ex)
    {
      throw;
    }
    catch (Exception ex)
    {
      throw CommonExceptionHelper.CreateDirectMessageCommonException(AppResources.is_an_invalid_flashcode.AcpStringFormat((object) flashCode));
    }
  }

  private void RMCWnd_PopulateRadioFeaturesFromFlashCodeEvtHandler(
    object sender,
    PopulateRadioFeaturesFromFlashCodeEventArgs e)
  {
    string flashCode = "";
    try
    {
      flashCode = SpecialFeatures.Flashport.FlashRadio.FlashcodeFormatter.FormatFlashcodeString(e.FlashCode, e.FlashCode.Length);
      e.RadioFeaturesRequest = this.ListFeatureSet(flashCode, e.ModelNumber);
    }
    catch (CommonException ex)
    {
      throw;
    }
    catch (Exception ex)
    {
      throw CommonExceptionHelper.CreateDirectMessageCommonException(AppResources.is_an_invalid_flashcode.AcpStringFormat((object) flashCode));
    }
  }

  private List<RadioFeatureRequest> ListFeatureSet(string flashCode, string modelNumber)
  {
    try
    {
      new ModelTiering(modelNumber, ModelTiering.ActionTypes.NONE, ModelTiering.TargetTypes.ALL).UpdateUtilityMackModelType();
    }
    catch (Exception ex)
    {
      throw CommonExceptionHelper.CreateDirectMessageCommonException(AppResources.Invalid_radio_model_number.AcpStringFormat((object) modelNumber));
    }
    int num = UtilityMack.IsPortablePro ? 1 : 0;
    List<RadioFeatureRequest> radioFeatureRequestList = new List<RadioFeatureRequest>();
    using (FlashcodeTable flashcodeTable = new FlashcodeTable(num != 0, true))
    {
      flashcodeTable.InitTable(false, modelNumber);
      foreach (Option opt in flashcodeTable.FLASHcode)
      {
        if (flashcodeTable.IsOptionEnabledInFlashcode(opt, flashCode))
        {
          RadioFeatureRequest radioFeatureRequest = new RadioFeatureRequest((int) opt.OptionID, FeatureStatus.Active);
          radioFeatureRequestList.Add(radioFeatureRequest);
        }
      }
    }
    return radioFeatureRequestList;
  }

  private void RMCWnd_QueryUpdateRadioEvtHandler(object sender, QueryUpdateRadioEventArgs e)
  {
    WindowMain windowMain = this.GetWindowMain();
    UtilityMack.bOpenFromRMC = true;
    ObservableCollection<AcpASKLib.SystemKeyData> loadedAsKs = SecurityManager.LoadedASKs;
    ObservableCollection<ASTRORadio> devices = e.Devices;
    ObservableCollection<bool> systemIdSupported = e.IsOwnerSystemIDSupported;
    AcpUIDialogWindow<string> acpUiDialogWindow = new AcpUIDialogWindow<string>((PageFunction<string>) new WriteProtect(windowMain, (Collection<AcpASKLib.SystemKeyData>) loadedAsKs, true, devices, systemIdSupported), (string) null);
    acpUiDialogWindow.ShowInTaskbar = false;
    acpUiDialogWindow.Owner = (Window) this;
    acpUiDialogWindow.ResizeMode = ResizeMode.NoResize;
    acpUiDialogWindow.Show();
    acpUiDialogWindow.Focus();
    acpUiDialogWindow.Hide();
    acpUiDialogWindow.ShowDialog();
  }

  private void RMCWnd_RadioIsConvOnlyEvtHandler(object sender, ASTROHoptionEnableEventArgs e)
  {
    e.IsEnable = RadioOperationValidator.IsRadioConvOnly(e.Modelnumber, e.Flashcode, false);
  }

  private AcpASKLib.KeyType ConvertASKInterfaceKeyType2AcpASKLibKeyType(ASK.Interface.KeyType keytype)
  {
    AcpASKLib.KeyType keyType = AcpASKLib.KeyType.UNDEFINED_KEY;
    if (keytype == ASK.Interface.KeyType.ADVANCED_CONV_SYSTEM_KEY)
      keyType = AcpASKLib.KeyType.ADVANCED_CONV_SYSTEM_KEY;
    if (keytype == ASK.Interface.KeyType.ADVANCED_SYSTEM_KEY)
      keyType = AcpASKLib.KeyType.ADVANCED_SYSTEM_KEY;
    if (keytype == ASK.Interface.KeyType.ADVANCED_WACN_KEY)
      keyType = AcpASKLib.KeyType.ADVANCED_WACN_KEY;
    if (keytype == ASK.Interface.KeyType.NONE)
      keyType = AcpASKLib.KeyType.NONE;
    return keyType;
  }

  private static ISystemKeyData ACPKeyDataConvertToSystemKeyData(AcpASKLib.SystemKeyData ACPKeyData)
  {
    ASK.Interface.KeyAccessLevelType aclvl = ASK.Interface.KeyAccessLevelType.LIMITED_ACC;
    if (ACPKeyData.AccessLevelType == AcpASKLib.KeyAccessLevelType.LIMITED_ACC)
      aclvl = ASK.Interface.KeyAccessLevelType.LIMITED_ACC;
    else if (ACPKeyData.AccessLevelType == AcpASKLib.KeyAccessLevelType.UNLM_ACC)
      aclvl = ASK.Interface.KeyAccessLevelType.UNLM_ACC;
    else if (ACPKeyData.AccessLevelType == AcpASKLib.KeyAccessLevelType.UNLM_ACC_WITHOUT_WP)
      aclvl = ASK.Interface.KeyAccessLevelType.UNLM_ACC_WITHOUT_WP;
    ASK.Interface.KeySource src = ASK.Interface.KeySource.HARDWARE;
    if (ACPKeyData.Source == AcpASKLib.KeySource.HARDWARE)
      src = ASK.Interface.KeySource.HARDWARE;
    else if (ACPKeyData.Source == AcpASKLib.KeySource.LEGACY_KEY_FILE)
      src = ASK.Interface.KeySource.LEGACY_KEY_FILE;
    ASK.Interface.KeyType type = ASK.Interface.KeyType.ADVANCED_CONV_SYSTEM_KEY;
    if (ACPKeyData.Type == AcpASKLib.KeyType.ADVANCED_CONV_SYSTEM_KEY)
      type = ASK.Interface.KeyType.ADVANCED_CONV_SYSTEM_KEY;
    else if (ACPKeyData.Type == AcpASKLib.KeyType.ADVANCED_SYSTEM_KEY)
      type = ASK.Interface.KeyType.ADVANCED_SYSTEM_KEY;
    else if (ACPKeyData.Type == AcpASKLib.KeyType.ADVANCED_WACN_KEY)
      type = ASK.Interface.KeyType.ADVANCED_WACN_KEY;
    else if (ACPKeyData.Type == AcpASKLib.KeyType.UNDEFINED_KEY)
      type = ASK.Interface.KeyType.UNDEFINED_KEY;
    else if (ACPKeyData.Type == AcpASKLib.KeyType.NONE)
      type = ASK.Interface.KeyType.NONE;
    string iBtnSerialNum = ACPKeyData.iBtnSerialNum;
    bool otapEnabled = ACPKeyData.OtapEnabled;
    int systemId = ACPKeyData.SystemID;
    string systemIdHex = ACPKeyData.SystemIDHex;
    string empty = string.Empty;
    bool writeProtectEnabled = ACPKeyData.WriteProtectEnabled;
    return (ISystemKeyData) new CommonASK.SystemKeyData(aclvl, iBtnSerialNum, otapEnabled, src, systemId, type, empty, writeProtectEnabled);
  }

  private static AcpASKLib.SystemKeyData ConvertACPKeyDataToSystemKeyData(ISystemKeyData keyData)
  {
    AcpASKLib.KeySource src = AcpASKLib.KeySource.HARDWARE;
    if (keyData.Source == ASK.Interface.KeySource.HARDWARE)
      src = AcpASKLib.KeySource.HARDWARE;
    else if (keyData.Source == ASK.Interface.KeySource.LEGACY_KEY_FILE)
      src = AcpASKLib.KeySource.LEGACY_KEY_FILE;
    AcpASKLib.KeyType keyType = AcpASKLib.KeyType.ADVANCED_CONV_SYSTEM_KEY;
    if (keyData.Type == ASK.Interface.KeyType.ADVANCED_CONV_SYSTEM_KEY)
      keyType = AcpASKLib.KeyType.ADVANCED_CONV_SYSTEM_KEY;
    else if (keyData.Type == ASK.Interface.KeyType.ADVANCED_SYSTEM_KEY)
      keyType = AcpASKLib.KeyType.ADVANCED_SYSTEM_KEY;
    else if (keyData.Type == ASK.Interface.KeyType.ADVANCED_WACN_KEY)
      keyType = AcpASKLib.KeyType.ADVANCED_WACN_KEY;
    else if (keyData.Type == ASK.Interface.KeyType.UNDEFINED_KEY)
      keyType = AcpASKLib.KeyType.UNDEFINED_KEY;
    else if (keyData.Type == ASK.Interface.KeyType.NONE)
      keyType = AcpASKLib.KeyType.NONE;
    string iBtnSerialNum = keyData.iBtnSerialNum;
    bool otapEnabled = keyData.OtapEnabled;
    int systemId = keyData.SystemID;
    bool writeProtectEnabled = keyData.WriteProtectEnabled;
    AccessRecord systemAccessLevel = SecurityManager.GetSystemAccessLevel(systemId, keyType);
    return new AcpASKLib.SystemKeyData(src, iBtnSerialNum, systemId, keyType, otapEnabled, writeProtectEnabled, systemAccessLevel);
  }

  private WindowMain GetWindowMain()
  {
    WindowMain winMain = (WindowMain) null;
    this.Dispatcher.Invoke((Action) (() => winMain = (WindowMain) Application.Current.MainWindow));
    return winMain;
  }

  private void SaveCpsFile(string filePath, byte[] fileContent)
  {
    if (File.Exists(filePath))
      File.Delete(filePath);
    using (FileStream fileStream = File.Create(filePath))
      fileStream.Write(fileContent, 0, fileContent.Length);
  }

  private void RunActionOnSavedFile(
    string filePath,
    byte[] fileContent,
    WindowMain winMain,
    Action action,
    AstroDeviceInfo deviceInfo = null)
  {
    this.SaveCpsFile(filePath, fileContent);
    string empty = string.Empty;
    if (!winMain.OpenCodeplugNonGUI(filePath, ref empty, true, deviceInfo))
      throw CommonExceptionHelper.CreateDirectMessageCommonException(empty);
    action();
    winMain.CloseFileNonGUI();
  }

  private void RunActionOnTempFile(
    string fileExt,
    byte[] fileContent,
    WindowMain winMain,
    Action action,
    AstroDeviceInfo deviceInfo = null)
  {
    string str = $"{Path.GetTempPath()}{Guid.NewGuid().ToString("D")}.{fileExt}";
    try
    {
      this.RunActionOnSavedFile(str, fileContent, winMain, action, deviceInfo);
    }
    finally
    {
      if (File.Exists(str))
        File.Delete(str);
    }
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "8.0.8.0")]
  public void InitializeComponent()
  {
    if (this._contentLoaded)
      return;
    this._contentLoaded = true;
    Application.LoadComponent((object) this, new Uri("/APXFamilyCPS;component/rmcwnd.xaml", UriKind.Relative));
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "8.0.8.0")]
  [EditorBrowsable(EditorBrowsableState.Never)]
  void IComponentConnector.Connect(int connectionId, object target)
  {
    switch (connectionId)
    {
      case 1:
        ((FrameworkElement) target).Loaded += new RoutedEventHandler(this.RMCWindow_Loaded);
        ((Window) target).Closing += new CancelEventHandler(this.Window_Closing);
        break;
      case 2:
        this.mainGrid = (Grid) target;
        break;
      case 3:
        this.ctcRadioManagementControl = (ContentControl) target;
        break;
      default:
        this._contentLoaded = true;
        break;
    }
  }
}
