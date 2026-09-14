// Decompiled with JetBrains decompiler
// Type: MackinawCPS.WindowMain
// Assembly: APXFamilyCPS, Version=36.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 9359335E-041C-4B12-9409-F4E6E7D93299
// Assembly location: C:\Program Files (x86)\Motorola\ApxFamilyCPS R36.00\APXFamilyCPS1.exe

using AcpASKLib;
using AcpBusinessLayer;
using AcpBusinessLayer.UndoRedo;
using AcpCommonLib;
using AcpCommonLib.FieldsReport;
using AcpCommonLib.FindResult;
using AcpCommonLib.StatusMessage;
using AcpCommonLib.UndoRedo;
using AcpCommonResources;
using AcpFileHandlerLib;
using AcpUI;
using AcpUI.Common;
using AcpUI.Comparator;
using AcpUI.CustomView;
using AcpUI.ImportExport;
using AcpUI.Mru;
using AcpUILib;
using AcpUtility;
using CodeplugExchangeLibrary;
using Common;
using CommonResources;
using CommonUtility;
using ConstraintHelper;
using DevComponents.WpfDock;
using DevComponents.WpfRibbon;
using Features.Common;
using Gibraltar.Agent;
using MackinawCPS.CloudNative;
using MackinawCPS.CommandLineCPS;
using MackinawCPS.HomeBase;
using MackinawCPS.Log;
using MackinawCPS.Properties;
using MackinawCPS.themes;
using Motorola.Acp.PackUnpack.Ish;
using Motorola.Common.BinarySerializer;
using Motorola.Common.Communication.CommonUtil;
using Motorola.Common.CustomException;
using Motorola.CommonCPS.RadioManagement.CommonBase.Utility;
using Motorola.CommonCPS.RadioManagement.SharedServices;
using Motorola.CommonCPS.Server.CommonDBConstants;
using Motorola.CommonCPS.Server.EntityModel;
using Motorola.CommonCPS.Server.EntityModel.GenericModel;
using Motorola.MackinawCPS.CoreFeatures.ActionConsolidation;
using Motorola.MackinawCPS.CoreFeatures.ASTROTalkgroupList;
using Motorola.MackinawCPS.CoreFeatures.Buttons;
using Motorola.MackinawCPS.CoreFeatures.ControlHeadE5;
using Motorola.MackinawCPS.CoreFeatures.ControlHeadO2;
using Motorola.MackinawCPS.CoreFeatures.ControlHeadO3;
using Motorola.MackinawCPS.CoreFeatures.ControlHeadO5;
using Motorola.MackinawCPS.CoreFeatures.ControlHeadO7;
using Motorola.MackinawCPS.CoreFeatures.ControlHeadO9;
using Motorola.MackinawCPS.CoreFeatures.ConventionalAliasLists;
using Motorola.MackinawCPS.CoreFeatures.ConventionalEmergencyProfiles;
using Motorola.MackinawCPS.CoreFeatures.ConventionalPersonality;
using Motorola.MackinawCPS.CoreFeatures.ConventionalSystem;
using Motorola.MackinawCPS.CoreFeatures.ConventionalWide;
using Motorola.MackinawCPS.CoreFeatures.DataProfiles;
using Motorola.MackinawCPS.CoreFeatures.DataWide;
using Motorola.MackinawCPS.CoreFeatures.DEK;
using Motorola.MackinawCPS.CoreFeatures.DisplayAndMenu;
using Motorola.MackinawCPS.CoreFeatures.EmergencyWide;
using Motorola.MackinawCPS.CoreFeatures.ExternalMicNoiseReductionProfile;
using Motorola.MackinawCPS.CoreFeatures.GlobalNoiseReductionList;
using Motorola.MackinawCPS.CoreFeatures.InternalMicNoiseReductionProfile;
using Motorola.MackinawCPS.CoreFeatures.Keypad;
using Motorola.MackinawCPS.CoreFeatures.KeypadMicAndAccessories;
using Motorola.MackinawCPS.CoreFeatures.MPLConfiguration;
using Motorola.MackinawCPS.CoreFeatures.PackExec;
using Motorola.MackinawCPS.CoreFeatures.RadioErgonomicsWide;
using Motorola.MackinawCPS.CoreFeatures.RadioInformation;
using Motorola.MackinawCPS.CoreFeatures.RadioProfiles;
using Motorola.MackinawCPS.CoreFeatures.RadioVIPs;
using Motorola.MackinawCPS.CoreFeatures.RadioWide;
using Motorola.MackinawCPS.CoreFeatures.RemoteSpeakerMic;
using Motorola.MackinawCPS.CoreFeatures.ScanList;
using Motorola.MackinawCPS.CoreFeatures.SecureKMFProfile;
using Motorola.MackinawCPS.CoreFeatures.SecureWide;
using Motorola.MackinawCPS.CoreFeatures.Shepherds;
using Motorola.MackinawCPS.CoreFeatures.SmartKeyFob;
using Motorola.MackinawCPS.CoreFeatures.Switches;
using Motorola.MackinawCPS.CoreFeatures.ToneSignalingList;
using Motorola.MackinawCPS.CoreFeatures.TrunkingEmergencyProfiles;
using Motorola.MackinawCPS.CoreFeatures.TrunkingPersonality;
using Motorola.MackinawCPS.CoreFeatures.TrunkingSystem;
using Motorola.MackinawCPS.CoreFeatures.VirtualPartnerAlert;
using Motorola.MackinawCPS.CoreFeatures.ZoneChannelAssignment;
using Org.BouncyCastle.Crypto;
using RFResourceRepository;
using SpecialFeatures;
using SpecialFeatures.AcpReportManagerLib;
using SpecialFeatures.CBISerialNum;
using SpecialFeatures.Clone_Configuration.Common;
using SpecialFeatures.CloneExpress;
using SpecialFeatures.CloneWizard;
using SpecialFeatures.CloudNativeTemplateName;
using SpecialFeatures.CodeplugCreation;
using SpecialFeatures.Comms;
using SpecialFeatures.CxfHandler;
using SpecialFeatures.DVRSFiles;
using SpecialFeatures.DVRSXML;
using SpecialFeatures.FileOperations;
using SpecialFeatures.Flashport;
using SpecialFeatures.Flashport.FlashkeyConfiguration;
using SpecialFeatures.Flashport.FlashRadio;
using SpecialFeatures.Flashport.RadioConfiguration;
using SpecialFeatures.Model_Configuration;
using SpecialFeatures.MultiCodeplug;
using SpecialFeatures.PasswordResetFile;
using SpecialFeatures.POP25BatchProgrammer;
using SpecialFeatures.Programming;
using SpecialFeatures.RadioFeatureSet;
using SpecialFeatures.RadioLanguagePack;
using SpecialFeatures.ReadWritePassword;
using SpecialFeatures.ReadWriteTlsPsk;
using SpecialFeatures.Security;
using SpecialFeatures.SystemCertificates;
using SpecialFeatures.UCL.CallListUpdate;
using SpecialFeatures.Ucl.Contact;
using SpecialFeatures.Utilites;
using SpecialFeatures.Utilities;
using SpecialFeatures.VoiceAnnouncements;
using SpecialFeatures.VoiceAnnouncements.List;
using SpecialFeatures.VoiceAnnouncements.SiteSelectableAlertList;
using SSLAdminTool;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Threading;
using System.Xml;

#nullable disable
namespace MackinawCPS;

public partial class WindowMain : 
  RibbonWindow,
  INotifyPropertyChanged,
  IDisposable,
  IAcpBatchOperation,
  IComponentConnector
{
  private readonly ReadWritePasswordApp _readWritePasswordApp;
  private readonly ReadWriteTlsPskHelper _tlsPskHelper;
  private readonly ReadWriteUtil _readWriteUtil;
  private string lastOpenCodePlugPath = string.Empty;
  private string defaulfBTPANIP = "192.168.132.1";
  private Thread m_DHGeneration;
  private DvrsMsuDataSync dvrsMsuDataSync;
  private string resetFilePath;
  private string mcTempFileNameFilePath;
  private APXTemplate templateFromServer;
  private APXRadio deviceFromServer;
  private bool _isCxfEditingMode;
  private RMCWnd rMCWnd;
  internal ProgressUpdate progressPage;
  internal Semaphore test;
  internal Semaphore testOTAP;
  internal Semaphore QueryRadio;
  public string MyModelNumber;
  public ModelTiering objModelTiering;
  private AcpIuiPage pageIUI;
  private bool cpgOpenFlag;
  private bool isFreonProduct;
  private bool defaultCpgOpenFlag;
  private bool customViewOpenFlag;
  private PaneItem selectedNavigationMode;
  private Dictionary<eAcpColorScheme, ResourceDictionary> AppColorSchemes;
  private eAcpColorScheme currentColorTheme;
  private eRibbonVisualStyle currentRibbonColor;
  private eDockVisualStyle currentDockColor;
  private object currentAppViewInfo;
  private string customVwPath;
  private AcpUndoHelper undoHelper;
  internal Settings settingsSavedOnAppExit = new Settings();
  private string cpgFileName;
  private string cpsVersion;
  private MultiCodeplugInfo MultiCodeplugInfo;
  private bool _shouldResetRadio;
  private bool bCloseSplashScreen = true;
  private bool bSaveCpgSuccessful;
  internal DifferentiatedUserViewType SavedCurrentViewType = DifferentiatedUserViewType.Full;
  internal string defaultKeyFilesLocation;
  internal string defaultDVRSFileLocation;
  private static string defaultLogoPath = "../../images/Mix3.jpg";
  private static string defaultVertexLogoPath = "../../images/Mix4.jpg";
  private bool bUnlimitedKeyLoaded;
  private bool isDnDorImpDoneBeforeTheOper;
  public static readonly DependencyProperty ReadWriteTransportProperty = DependencyProperty.Register(nameof (ReadWriteTransport), typeof (int), typeof (WindowMain), new PropertyMetadata((object) 0));
  public static readonly DependencyProperty CloneTransportProperty = DependencyProperty.Register(nameof (CloneTransport), typeof (int), typeof (WindowMain), new PropertyMetadata((object) 0));
  private object commsLastUserState;
  internal static readonly DependencyProperty OTAPKeyLoadedProperty = DependencyProperty.Register(nameof (OTAPKeyLoaded), typeof (bool), typeof (WindowMain), new PropertyMetadata((object) false));
  private bool ribbonBarRtdPageRestoreAllIsEnabled;
  private bool ribbonBarShowRtdButtonsIsEnabled;
  private bool storedRtdButtonsStatus;
  private string upgradeFile = "";
  private bool otapEnabledCodeplug;
  private bool readWriteInProgress;
  internal BackgroundWorker bgReadWorker;
  internal BackgroundWorker bgWriteWorker;
  private static BooleanSwitch BlockPackOnInvalids = new BooleanSwitch(nameof (BlockPackOnInvalids), AppResources.Block_packing_if_codeplug_has_invalid_fields);
  private static BooleanSwitch SuppressPackInvalidsPopup = new BooleanSwitch(nameof (SuppressPackInvalidsPopup), AppResources.Suppress_packing_with_invalid_fields_popup);
  private bool pop25Enabled;
  private bool specKeyLoaded;
  private bool labtoolKeyLoaded = true;
  private bool depotKeyLoaded;
  public static WindowMain _appMainFrame = (WindowMain) null;
  private const int SW_SHOWNORMAL = 1;
  private const int SW_SHOWMINIMIZED = 2;
  private string dvrsExportPath = string.Empty;
  private Key[] AllowedKeys = new Key[31 /*0x1F*/]
  {
    Key.D0,
    Key.D1,
    Key.D2,
    Key.D3,
    Key.D4,
    Key.D5,
    Key.D6,
    Key.D7,
    Key.D8,
    Key.D9,
    Key.NumPad0,
    Key.NumPad1,
    Key.NumPad2,
    Key.NumPad3,
    Key.NumPad4,
    Key.NumPad5,
    Key.NumPad6,
    Key.NumPad7,
    Key.NumPad8,
    Key.NumPad9,
    Key.OemPeriod,
    Key.Back,
    Key.Delete,
    Key.Delete,
    Key.Home,
    Key.End,
    Key.NumLock,
    Key.Tab,
    Key.Left,
    Key.Right,
    Key.Decimal
  };
  internal DockPanel WindowMainDockPanel;
  internal Ribbon WindowMainRibbonControl;
  internal Image imgRibbonAppMenu;
  internal ButtonDropDown AppMenuItemExitRibbonPad;
  internal AcpListBoxMruFiles AppMruList;
  internal ButtonDropDown AppMenuOpen;
  internal ButtonDropDown AppMenuSave;
  internal ButtonDropDown AppMenuPublish;
  internal ButtonDropDown AppMenuSaveAs;
  internal ButtonDropDown AppMenuImport;
  internal ButtonDropDown AppMenuExport;
  internal ButtonDropDown AppMenuRMC;
  internal ButtonDropDown AppMenuPrint;
  internal ButtonDropDown RadioInfo;
  internal ButtonDropDown RadioHandOut;
  internal ButtonDropDown RadioHandOutO2;
  internal ButtonDropDown RadioHandOutO3;
  internal ButtonDropDown RadioHandOutE5;
  internal ButtonDropDown RadioHandOutO5;
  internal ButtonDropDown RadioHandOutO7;
  internal ButtonDropDown RadioHandOutO9;
  internal ButtonDropDown RadioPrintChoices;
  internal ButtonDropDown AppMenuClose;
  internal ButtonDropDown AppMenuOptions;
  internal ButtonDropDown AppMenuExit;
  internal ButtonDropDown QATDummy;
  internal ButtonDropDown QATOpen;
  internal ButtonDropDown QATSave;
  internal ButtonDropDown QATRMC;
  internal RibbonTab ribbonTabCodeplug;
  internal RibbonBarPanel ribbonBarPanelCodeplug;
  internal ButtonDropDown RibbonBarSave;
  internal ButtonDropDown RibbonBarPublish;
  internal RibbonBar ribbonBarEdit;
  internal ButtonDropDown QATUndo;
  internal ButtonDropDown QATRedo;
  internal RibbonBar ribbonBarRestore;
  internal ButtonDropDown RibbonBarRtd;
  internal ButtonDropDown ribbonBarShowRtdButtons;
  internal ButtonDropDown RibbonBarRtdPageRestoreAll;
  internal ButtonDropDown RibbonBarRtdInvalidsRestoreAll;
  internal RibbonBar RibbonBarSearch;
  internal System.Windows.Controls.TextBox FindToken;
  internal ButtonDropDown RibbonBarEditingFind;
  internal ButtonDropDown RibbonBarEditingFindFieldName;
  internal ButtonDropDown RibbonBarEditingFindFieldNameAndValue;
  internal ButtonDropDown RibbonBarCompCodeplugStartEnd;
  internal Image RibbonBarCompCodeplugStartEndImage;
  internal ButtonDropDown RibbonBarCompOptions;
  internal ButtonDropDown RibbonBarCompCodeplugHideUnideFlds;
  internal ButtonDropDown RibbonBarCompCodeplugPageCopyAll;
  internal ButtonDropDown RibbonBarShowFS;
  internal RibbonBar ribbonBarToolsPassword;
  internal ButtonDropDown ReadWritePassword;
  internal RibbonBar ribbonBarDVRS;
  internal ButtonDropDown DVRSExport;
  internal RibbonBar ribbonBarUpdateUCL;
  internal ButtonDropDown UpdateCallList;
  internal RibbonTab ribbonTabCustomViewCfgMode;
  internal RibbonBarPanel ribbonBarCustomViewPanel;
  internal RibbonBar ribbonBarCustomView;
  internal ButtonDropDown ribbonBarCustomViewOpen;
  internal ButtonDropDown ribbonBarCustomViewNew;
  internal ButtonDropDown ribbonBarCustomViewSaveAs;
  internal ButtonDropDown ribbonBarCustomViewClose;
  internal ButtonDropDown ribbonBarCustomHowTo;
  internal RibbonTab ribbonTabAppSettings;
  internal RibbonBar ribbonBarThemes;
  internal ButtonDropDown RibbonBarBarThemes;
  internal ButtonDropDown ClassicTheme;
  internal ButtonDropDown SilverTheme;
  internal ButtonDropDown BlackTheme;
  internal ButtonDropDown PoliceTheme;
  internal ButtonDropDown FiremanTheme;
  internal ButtonDropDown MilitaryTheme;
  internal ButtonDropDown FullColorTheme;
  internal RibbonBar ribbonBarWindows;
  internal ButtonDropDown RibbonBarBarWindows;
  internal ButtonDropDown wndNavigation;
  internal AcpCheckBox wndNavigationHideCB;
  internal ButtonDropDown wndErrorList;
  internal AcpCheckBox wndErrorListHideCB;
  internal AcpCheckBox wndErrorListAutoRiseCB;
  internal ButtonDropDown wndInvalidFieldsReport;
  internal AcpCheckBox wndInvalidFieldsHideCB;
  internal AcpCheckBox wndInvalidFieldsAutoRiseCB;
  internal ButtonDropDown wndDnDReport;
  internal AcpCheckBox wndDnDReportHideCB;
  internal AcpCheckBox wndDnDReportAutoRiseCB;
  internal ButtonDropDown wndImpExpReport;
  internal AcpCheckBox wndImpExpReportHideCB;
  internal AcpCheckBox wndImpExpReportAutoRiseCB;
  internal ButtonDropDown wndComparatorReport;
  internal AcpCheckBox wndComparatorReportHideCB;
  internal AcpCheckBox wndComparatorReportAutoRiseCB;
  internal ButtonDropDown wndFillUpFillDownReport;
  internal AcpCheckBox wndFillUpFillDownReportHideCB;
  internal AcpCheckBox wndFillUpFillDownReportAutoRiseCB;
  internal ButtonDropDown wndFindResults;
  internal AcpCheckBox wndFindResultsHideCB;
  internal AcpCheckBox wndFindResultsAutoRiseCB;
  internal ButtonDropDown wndFieldInfo;
  internal AcpCheckBox wndFieldInfoHideCB;
  internal ButtonDropDown wndSysKeyRpt;
  internal AcpCheckBox wndSysKeyRptHideCB;
  internal AcpCheckBox wndSysKeyRptAutoRiseCB;
  internal RibbonBar ribbonBarView;
  internal System.Windows.Controls.ComboBox DiffViewType;
  internal RibbonTab ribbonTabDeviceMgmtMode;
  internal RibbonBarPanel ribbonBarDevicePanel;
  internal RibbonBar ribbonBarDeviceReadWrite;
  internal ButtonDropDown ribbonBarDeviceRead;
  internal ButtonDropDown ribbonBarDeviceWrite;
  internal System.Windows.Controls.ComboBox DeviceTransportComboBox;
  internal AcpLabel labBTIPAddressForWR;
  internal System.Windows.Controls.TextBox txtBTIPAddressForWR;
  internal RibbonBar ribbonBarDeviceCloning;
  internal ButtonDropDown ribbonBarCloneWizard;
  internal ButtonDropDown ribbonBarCloneExpress;
  internal System.Windows.Controls.ComboBox CloneransportComboBox;
  internal AcpLabel labBTIPAddressForClone;
  internal System.Windows.Controls.TextBox txtBTIPAddressForClone;
  internal RibbonBar ribbonBarDeviceFlashport;
  internal ButtonDropDown ribbonBarReadRadCfg;
  internal ButtonDropDown ribbonBarFlashRadio;
  internal ButtonDropDown ribbonBarReadFlashKeyCfg;
  internal ButtonDropDown ribbonBarRefreshRadio;
  internal RibbonBar ribbonBarDisableWP;
  internal ButtonDropDown AppMenuWriteProtect;
  internal ButtonDropDown RibbonBarShowMultiCodeplug;
  internal RibbonTab ribbonTabSecurity;
  internal RibbonTab ribbonTabTools;
  internal RibbonBar ribbonBarSysKey;
  internal ButtonDropDown ribbonBarLoadASK;
  internal ButtonDropDown ribbonBarLoadSWKey;
  internal RibbonBar ribbonBarToolsReports;
  internal ButtonDropDown RibbonRadioInformation;
  internal ButtonDropDown RibbonRadioHandOut;
  internal ButtonDropDown RibbonRadioHandOutO2;
  internal ButtonDropDown RibbonRadioHandOutO3;
  internal ButtonDropDown RibbonRadioHandOutE5;
  internal ButtonDropDown RibbonRadioHandOutO5;
  internal ButtonDropDown RibbonRadioHandOutO7;
  internal ButtonDropDown RibbonRadioHandOutO9;
  internal ButtonDropDown RibbonRadioPrintChoices;
  internal RibbonBar ribbonBarToolsVoiceAnnouncement;
  internal ButtonDropDown VAConvertUtil;
  internal ButtonDropDown VACpgUsage;
  internal ButtonDropDown VADownldUtil;
  internal RibbonBar ribbonBarToolsPOP25Scheduler;
  internal ButtonDropDown POP25RadioList;
  internal ButtonDropDown POP25BatchScheduler;
  internal RibbonBar ribbonBarRadioManagement;
  internal ButtonDropDown RadioManagement;
  internal RibbonBar ribbonBarToolsOptions;
  internal ButtonDropDown Options;
  internal RibbonBar ribbonBarToolsLoadCertificate;
  internal ButtonDropDown ribbonBarLoadTxmCertificate;
  internal RibbonBar ribbonBarToolsPasswordReset;
  internal ButtonDropDown ribbonBarResetPasswordBtn;
  internal RibbonTab ribbonTabHelp;
  internal RibbonBar ribbonBarHelpContent;
  internal ButtonDropDown ribbonBarCPSHelp;
  internal ButtonDropDown ribbonBarAboutCPS;
  internal ButtonDropDown ribbonBarTutorials;
  internal ButtonDropDown ribbonBarSpecKeyReport;
  internal System.Windows.Controls.ListView specKeyListView;
  internal GridView SpecKeyReport;
  internal GridViewColumn specKeyType;
  internal GridViewColumn SerialNum;
  internal ButtonDropDown ribbonBarHelpButton;
  internal ButtonDropDown AppClose;
  internal System.Windows.Controls.Frame WindowMainFrame;
  private bool _contentLoaded;

  public event WindowMain.ReadRadioCompleted readRadioComplete;

  private Version CodeplugVersion => FeatureManager.GetCodeplugVersion();

  protected virtual void Dispose(bool disposing)
  {
    if (!disposing)
      return;
    if (this.objModelTiering != null)
    {
      this.objModelTiering.Dispose();
      this.objModelTiering = (ModelTiering) null;
    }
    if (this.progressPage != null)
    {
      this.progressPage.Dispose();
      this.progressPage = (ProgressUpdate) null;
    }
    if (this.test != null)
    {
      this.test.Dispose();
      this.test = (Semaphore) null;
    }
    if (this.testOTAP != null)
    {
      this.testOTAP.Dispose();
      this.testOTAP = (Semaphore) null;
    }
    if (this.QueryRadio != null)
    {
      this.QueryRadio.Dispose();
      this.QueryRadio = (Semaphore) null;
    }
    if (this.bgReadWorker != null)
    {
      this.bgReadWorker.Dispose();
      this.bgReadWorker = (BackgroundWorker) null;
    }
    if (this.bgWriteWorker != null)
    {
      this.bgWriteWorker.Dispose();
      this.bgWriteWorker = (BackgroundWorker) null;
    }
    if (this._readWritePasswordApp == null)
      return;
    this._readWritePasswordApp.Dispose();
  }

  public void Dispose()
  {
    this.Dispose(true);
    GC.SuppressFinalize((object) this);
  }

  public bool IsMobileModel
  {
    set
    {
      this.SetTitleBar(((App) System.Windows.Application.Current).TheDocument.docFileName, (string) null, (Radio) this.deviceFromServer);
      if (this.PropertyChanged == null)
        return;
      this.PropertyChanged((object) this, new PropertyChangedEventArgs(nameof (IsMobileModel)));
    }
    get => UtilityMack.IsMobile();
  }

  public bool IsPortableModel
  {
    set
    {
      this.SetTitleBar(((App) System.Windows.Application.Current).TheDocument.docFileName, (string) null, (Radio) this.deviceFromServer);
      if (this.PropertyChanged == null)
        return;
      this.PropertyChanged((object) this, new PropertyChangedEventArgs(nameof (IsPortableModel)));
    }
    get => UtilityMack.IsPortable();
  }

  public bool IsMobileModelAndSupportedO9
  {
    set
    {
      if (this.PropertyChanged == null)
        return;
      this.PropertyChanged((object) this, new PropertyChangedEventArgs(nameof (IsMobileModelAndSupportedO9)));
    }
    get
    {
      return this.CpgOpenFlag && FeatureManager.GetFeature(4003)[0] is Motorola.MackinawCPS.CoreFeatures.ControlHeadO9.ControlHeadO9 controlHeadO9 && controlHeadO9.General.EmbeddedRecset[0] is O9Inner o9Inner && !o9Inner.O9InnerSection.CHO9EmergencyButtonName_A36680.HiddenStatic;
    }
  }

  public bool IsMobileModelAndSupportedO7
  {
    set
    {
      if (this.PropertyChanged == null)
        return;
      this.PropertyChanged((object) this, new PropertyChangedEventArgs(nameof (IsMobileModelAndSupportedO7)));
    }
    get
    {
      return this.cpgOpenFlag && FeatureManager.GetFeature(4114)[0] is Motorola.MackinawCPS.CoreFeatures.ControlHeadO7.ControlHeadO7 controlHeadO7 && controlHeadO7.O7GeneralExpander.EmbeddedRecset[0] is O7Inner o7Inner && !o7Inner.O7InnerSection.CHO7EmergencyButtonName_A41289.HiddenStatic;
    }
  }

  public bool IsMobileModelAndSupportedO3
  {
    set
    {
      if (this.PropertyChanged == null)
        return;
      this.PropertyChanged((object) this, new PropertyChangedEventArgs(nameof (IsMobileModelAndSupportedO3)));
    }
    get
    {
      return this.cpgOpenFlag && FeatureManager.GetFeature(2127)[0] is Motorola.MackinawCPS.CoreFeatures.ControlHeadO3.ControlHeadO3 controlHeadO3 && controlHeadO3.General.EmbeddedRecset[0] is O3HHCHButtonInner o3HhchButtonInner && !o3HhchButtonInner.O3HHCHButtonInnerSection.CntrlHeadO3HHCHButtonName_A22523.HiddenStatic;
    }
  }

  public bool IsMobileModelAndSupportedO2
  {
    set
    {
      if (this.PropertyChanged == null)
        return;
      this.PropertyChanged((object) this, new PropertyChangedEventArgs(nameof (IsMobileModelAndSupportedO2)));
    }
    get
    {
      return this.cpgOpenFlag && FeatureManager.GetFeature(4115)[0] is Motorola.MackinawCPS.CoreFeatures.ControlHeadO2.ControlHeadO2 controlHeadO2 && controlHeadO2.O2GeneralExpander.EmbeddedRecset[0] is O2Inner o2Inner && !o2Inner.O2InnerSection.CHO2EmergencyButtonName_A41270.HiddenStatic;
    }
  }

  public bool IsMobileModelAndSupportedE5
  {
    set
    {
      if (this.PropertyChanged == null)
        return;
      this.PropertyChanged((object) this, new PropertyChangedEventArgs(nameof (IsMobileModelAndSupportedE5)));
    }
    get
    {
      return this.cpgOpenFlag && FeatureManager.GetFeature(4236)[0] is Motorola.MackinawCPS.CoreFeatures.ControlHeadE5.ControlHeadE5 controlHeadE5 && controlHeadE5.E5GeneralExpander.EmbeddedRecset[0] is E5Inner e5Inner && !e5Inner.E5InnerSection.CHE5EmergencyButtonName_43766.HiddenStatic;
    }
  }

  public bool IsMobileModelAndSupportedO5
  {
    set
    {
      if (this.PropertyChanged == null)
        return;
      this.PropertyChanged((object) this, new PropertyChangedEventArgs(nameof (IsMobileModelAndSupportedO5)));
    }
    get
    {
      return this.CpgOpenFlag && FeatureManager.GetFeature(2130)[0] is Motorola.MackinawCPS.CoreFeatures.ControlHeadO5.ControlHeadO5 controlHeadO5 && controlHeadO5.General.EmbeddedRecset[0] is O5Inner o5Inner && !o5Inner.O5InnerSection.CntrlHeadO5SignalIndependentO5M5MXChiefCHButtonName_A22520.HiddenStatic;
    }
  }

  public bool IsDVRSHoptionEnabled
  {
    set
    {
      if (this.PropertyChanged == null)
        return;
      this.PropertyChanged((object) this, new PropertyChangedEventArgs(nameof (IsDVRSHoptionEnabled)));
    }
    get => UtilityMack.IsDVRSHoptionEnabled;
  }

  public bool IsRmAvailable
  {
    get
    {
      return this.IsNotVertexRadio && !CpsVersionResolver.Instance.IsItCpsWithoutAnRm && !this.IsCloudNativeMode;
    }
  }

  public bool IsNotVertexRadio
  {
    set
    {
      if (this.PropertyChanged == null)
        return;
      this.PropertyChanged((object) this, new PropertyChangedEventArgs(nameof (IsNotVertexRadio)));
    }
    get => !VersionInfoHelper.IsDFlagExisted(DFlagType.DASTRO);
  }

  public bool IsDVRSHwEnabled
  {
    set
    {
      if (this.PropertyChanged == null)
        return;
      this.PropertyChanged((object) this, new PropertyChangedEventArgs(nameof (IsDVRSHwEnabled)));
    }
    get => UtilityMack.IsDVRSHwEnabled;
  }

  public bool IsCpgConvOnly
  {
    set
    {
      if (this.PropertyChanged == null)
        return;
      this.PropertyChanged((object) this, new PropertyChangedEventArgs(nameof (IsCpgConvOnly)));
    }
    get
    {
      bool isCpgConvOnly = false;
      if (this.CpgOpenFlag && FeatureManager.GetFeature(2049)[0] is Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation radioInformation)
        isCpgConvOnly = RadioAccessValidator.IsConvOnly(radioInformation.General.RadInfoGeneralModelNumber_A8539.Value, radioInformation.FLASHport.RadInfoFLASHportFLASHcode_A8132Value, true);
      return isCpgConvOnly;
    }
  }

  public APXTemplate TemplateFromServer
  {
    get => this.templateFromServer;
    set
    {
      this.templateFromServer = value;
      if (this.PropertyChanged == null)
        return;
      this.PropertyChanged((object) this, new PropertyChangedEventArgs(nameof (TemplateFromServer)));
      this.PropertyChanged((object) this, new PropertyChangedEventArgs("BlockFlashReadRadioFromRMC"));
      this.PropertyChanged((object) this, new PropertyChangedEventArgs("BlockReadFlashKeyCfgFromRMC"));
    }
  }

  public APXRadio DeviceFromServer
  {
    get => this.deviceFromServer;
    set
    {
      this.deviceFromServer = value;
      if (this.PropertyChanged == null)
        return;
      this.PropertyChanged((object) this, new PropertyChangedEventArgs(nameof (DeviceFromServer)));
      this.PropertyChanged((object) this, new PropertyChangedEventArgs("BlockFlashReadRadioFromRMC"));
      this.PropertyChanged((object) this, new PropertyChangedEventArgs("BlockReadFlashKeyCfgFromRMC"));
    }
  }

  public bool IsCxfEditingMode
  {
    get => this._isCxfEditingMode;
    set
    {
      this._isCxfEditingMode = value;
      if (this.PropertyChanged == null)
        return;
      this.PropertyChanged((object) this, new PropertyChangedEventArgs(nameof (IsCxfEditingMode)));
    }
  }

  internal DocumentOperations DocumentOperations => new DocumentOperations();

  internal string CPS_Version => this.cpsVersion;

  internal System.Windows.Controls.Frame FrameLeft => this.pageIUI.GetFrameLeft;

  internal System.Windows.Controls.Frame FrameCenterTop => this.pageIUI.GetFrameCenterTop;

  internal System.Windows.Controls.Frame FrameRight => this.pageIUI.GetFrameRight;

  internal System.Windows.Controls.Frame FrameStatusBar => this.pageIUI.GetStatusBar;

  internal AcpIuiPage GetPageIUI => this.pageIUI;

  public bool CpgOpenFlag
  {
    get => this.cpgOpenFlag;
    set
    {
      this.cpgOpenFlag = value;
      this.CanOpenCpgFlag = !value;
      this.PropertiesChanged();
    }
  }

  public void PropertiesChanged()
  {
    if (this.PropertyChanged == null)
      return;
    this.PropertyChanged((object) this, new PropertyChangedEventArgs("CpgOpenFlag"));
    this.PropertyChanged((object) this, new PropertyChangedEventArgs("CanOpenCpgFlag"));
    this.PropertyChanged((object) this, new PropertyChangedEventArgs("BlockRadioIO"));
    this.PropertyChanged((object) this, new PropertyChangedEventArgs("DeviceFromServer"));
    this.PropertyChanged((object) this, new PropertyChangedEventArgs("TemplateFromServer"));
    this.PropertyChanged((object) this, new PropertyChangedEventArgs("BlockFlashIO"));
    this.PropertyChanged((object) this, new PropertyChangedEventArgs("OtapEnabledCodeplug"));
    this.PropertyChanged((object) this, new PropertyChangedEventArgs("IsVAPossibleInCodeplug"));
    this.PropertyChanged((object) this, new PropertyChangedEventArgs("IsCxfEditingMode"));
  }

  public bool IsVAPossibleInCodeplug => this.cpgOpenFlag && !UtilityMack.IsAPX8000CBP;

  public bool IsFreonProduct
  {
    get => this.isFreonProduct;
    set
    {
      this.isFreonProduct = value;
      if (this.PropertyChanged == null)
        return;
      this.PropertyChanged((object) this, new PropertyChangedEventArgs(nameof (IsFreonProduct)));
    }
  }

  public bool CanOpenCpgFlag { get; set; }

  public bool CanSaveCpgFlag
  {
    get
    {
      bool canSaveCpgFlag = true;
      if (AcpSecurityLib.SecurityManager.IsSpecialKeyLoaded)
        canSaveCpgFlag = AcpSecurityLib.SecurityManager.CheckIfSpecialKeyIsAttached();
      return canSaveCpgFlag;
    }
  }

  public bool DefaultCpgOpenFlag
  {
    get => this.defaultCpgOpenFlag;
    set => this.defaultCpgOpenFlag = value;
  }

  public bool CustomViewOpenFlag
  {
    get => this.customViewOpenFlag;
    set
    {
      this.customViewOpenFlag = value;
      UtilityMack.ConfigureViewFlag = !value;
      if (this.PropertyChanged == null)
        return;
      this.PropertyChanged((object) this, new PropertyChangedEventArgs(nameof (CustomViewOpenFlag)));
    }
  }

  internal DifferentiatedUserViewType PrevPreDefView { get; set; }

  internal static string DefaultLogoPath
  {
    get
    {
      return !VersionInfoHelper.IsDFlagExisted(DFlagType.DASTRO) ? WindowMain.defaultLogoPath : WindowMain.defaultVertexLogoPath;
    }
  }

  public int ReadWriteTransport
  {
    get => (int) this.GetValue(WindowMain.ReadWriteTransportProperty);
    set => this.SetValue(WindowMain.ReadWriteTransportProperty, (object) value);
  }

  public int CloneTransport
  {
    get => (int) this.GetValue(WindowMain.CloneTransportProperty);
    set => this.SetValue(WindowMain.CloneTransportProperty, (object) value);
  }

  internal bool OTAPKeyLoaded
  {
    get => (bool) this.GetValue(WindowMain.OTAPKeyLoadedProperty);
    set => this.SetValue(WindowMain.OTAPKeyLoadedProperty, (object) value);
  }

  internal System.Windows.Controls.Frame getWindowMainFrame => this.WindowMainFrame;

  internal void OnAppMenuOpen(object sender, RoutedEventArgs e) => this.AlwaysOpen(sender, e);

  internal void OnQATOpen(object sender, RoutedEventArgs e) => this.AlwaysOpen(sender, e);

  internal void AlwaysOpen(object sender, RoutedEventArgs e)
  {
    if (this.CpgOpenFlag)
    {
      this.OnAppMenuClose(sender, e);
      if (!this.CanOpenCpgFlag)
        return;
      this.OpenCodeplug((string) null);
    }
    else
      this.OpenCodeplug((string) null);
  }

  internal bool OpenCodeplug(string fileName, APXRadio d = null, APXTemplate t = null)
  {
    this.AllowDrop = false;
    string empty = string.Empty;
    int num = this.OpenCodeplug(fileName, d, t, ref empty) ? 1 : 0;
    if (num != 0)
      this.HandleInValidFieldBackwardCompatibilityForMCFile();
    this.WindowMain_AllowDrop((object) null, (System.Windows.Input.MouseEventArgs) null);
    return num != 0;
  }

  internal bool OpenCodeplug(
    string fileName,
    ref string errorMessage,
    bool isForExport = false,
    string password = null)
  {
    string empty = string.Empty;
    int num = this.OpenCodeplug(fileName, (APXRadio) null, (APXTemplate) null, ref empty, true, isForExport, password) ? 1 : 0;
    errorMessage = empty;
    return num != 0;
  }

  private bool IsSuppotedCodePlugType(string cpFilePath)
  {
    if (VersionInfoHelper.IsDFlagExisted(DFlagType.ALL))
      return true;
    AcpFileHandler acpFileHandler = new AcpFileHandler();
    try
    {
      AcpFileHeader acpFileHeader = acpFileHandler.ReadHeaderSafely(cpFilePath);
      if ((!VersionInfoHelper.IsDFlagExisted(DFlagType.DASTRO) || acpFileHeader.ModelNumber.StartsWith("H93")) && (VersionInfoHelper.IsDFlagExisted(DFlagType.DASTRO) || !acpFileHeader.ModelNumber.StartsWith("H93")))
        return true;
      AppInfoManager.StatusMsgReport.PostMessage(StatusMsgType.Error, AppResources.File_colon_could_not_be_opened.AcpStringFormat((object) cpFilePath));
      return false;
    }
    catch (Exception ex)
    {
      AppInfoManager.StatusMsgReport.PostMessage(StatusMsgType.Error, AppResources.File_colon_could_not_be_opened.AcpStringFormat((object) cpFilePath));
      return false;
    }
  }

  private bool OpenCodeplug(
    string sFileName,
    APXRadio d,
    APXTemplate t,
    ref string errorMsg,
    bool isNonGuiOpen = false,
    bool isForExport = false,
    string password = null)
  {
    this.AllowDrop = false;
    this.DeviceFromServer = d;
    this.TemplateFromServer = t;
    bool fileOpened = false;
    System.Windows.Input.Cursor overrideCursor = Mouse.OverrideCursor;
    MemoryCleaner.CleanGarbageFromMemory();
    string initialDirectory = AcpFileDialog.InitialDirectory;
    try
    {
      WindowMain mainWindow = (WindowMain) System.Windows.Application.Current.MainWindow;
      AcpOpenFileDialog acpOpenFileDialog = new AcpOpenFileDialog();
      if (VersionInfoHelper.IsDFlagExisted(DFlagType.DASTRO))
        acpOpenFileDialog.Filter = AppResources.Vertex_Codeplug_Filter;
      else
        acpOpenFileDialog.Filter = AppResources.Motorola_Codeplug_Filter;
      acpOpenFileDialog.MultiSelect = false;
      bool flag = true;
      AcpFileHeader fileHeader = (AcpFileHeader) null;
      if (string.IsNullOrEmpty(sFileName))
      {
        fileHeader = new AcpFileHeader();
        AcpFileDialog.InitialDirectory = ((App) System.Windows.Application.Current).TheDocument.docFilePath != null || !(this.lastOpenCodePlugPath != string.Empty) ? ((App) System.Windows.Application.Current).TheDocument.docFilePath : this.lastOpenCodePlugPath;
        char directorySeparatorChar;
        if (acpOpenFileDialog.ShowDialogSafely(fileHeader).GetValueOrDefault())
        {
          sFileName = acpOpenFileDialog.FileName;
          this.cpgFileName = sFileName;
          this.lastOpenCodePlugPath = Path.GetDirectoryName(acpOpenFileDialog.FileName);
          if ((int) this.lastOpenCodePlugPath[this.lastOpenCodePlugPath.Length - 1] != (int) Path.DirectorySeparatorChar)
          {
            string openCodePlugPath = this.lastOpenCodePlugPath;
            directorySeparatorChar = Path.DirectorySeparatorChar;
            string str = directorySeparatorChar.ToString();
            this.lastOpenCodePlugPath = openCodePlugPath + str;
          }
          if (!this.IsSuppotedCodePlugType(sFileName))
            flag = false;
          if (mainWindow.CpgOpenFlag)
            throw SpecialFeatures.CommonExceptionHelper.CreateCommonException(CommonErrorCode.RMC_OpenCodeplug_Fail_HasOpened, Motorola.CommonCPS.ResourceRepository.Resources.RMC_OpenCodeplug_Fail_HasOpened);
        }
        else
          flag = false;
        if (flag)
        {
          this.cpgFileName = sFileName;
          this.lastOpenCodePlugPath = Path.GetDirectoryName(sFileName);
          if ((int) this.lastOpenCodePlugPath[this.lastOpenCodePlugPath.Length - 1] != (int) Path.DirectorySeparatorChar)
          {
            string openCodePlugPath = this.lastOpenCodePlugPath;
            directorySeparatorChar = Path.DirectorySeparatorChar;
            string str = directorySeparatorChar.ToString();
            this.lastOpenCodePlugPath = openCodePlugPath + str;
          }
          if (!this.IsSuppotedCodePlugType(sFileName))
            flag = false;
          if (mainWindow.CpgOpenFlag)
            throw SpecialFeatures.CommonExceptionHelper.CreateCommonException(CommonErrorCode.RMC_OpenCodeplug_Fail_HasOpened, Motorola.CommonCPS.ResourceRepository.Resources.RMC_OpenCodeplug_Fail_HasOpened);
        }
      }
      else
      {
        try
        {
          if (!this.IsSuppotedCodePlugType(sFileName))
            flag = false;
          fileHeader = new AcpFileHandler().ReadHeaderSafely(sFileName);
        }
        catch (Exception ex)
        {
          fileHeader = new AcpFileHeader();
        }
        finally
        {
          this.cpgFileName = sFileName;
        }
      }
      if (flag)
      {
        Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
        if (sFileName.EndsWith(".mc"))
        {
          AppInfoManager.AppVersion = this.cpsVersion;
          fileOpened = ((App) System.Windows.Application.Current).TheDocument.FileOpenSafely(sFileName, (IEnumerable<BinarySerializerTypeInfo>) AllowedTypes.AllowedTypesList);
          if (fileOpened)
            this.DocumentOperations.UclTemplateNodeInit();
        }
        else if (sFileName.EndsWith(".cxf", StringComparison.OrdinalIgnoreCase))
        {
          using (CodeplugExchangeFile cxfFile = CxfFileHandler.OpenFileAndValidatePassword(sFileName, password))
          {
            if (cxfFile != null && cxfFile.IsFileValid)
            {
              this.InitCodeplugOpen();
              fileOpened = CxfFileHandler.OpenCodeplugFile(cxfFile.GetCodeplugBytes());
              CxfFileHandler.AssignFirmwareVersionToRadioInfo(cxfFile);
            }
            if (fileOpened)
            {
              this.IsCxfEditingMode = true;
              CodeplugVersionUpdater.SetCodeplugVersion();
              this.ResolveUnpack();
              ((App) System.Windows.Application.Current).TheDocument.docFileName = Path.GetFileName(sFileName);
              ((App) System.Windows.Application.Current).TheDocument.docFilePath = Path.GetFullPath(sFileName);
            }
          }
        }
        else if (sFileName.EndsWith(".xpba"))
        {
          this.InitCodeplugOpen();
          fileOpened = Cruncher.Instance.UnpackXPBA(sFileName);
          if (fileOpened)
          {
            CodeplugVersionUpdater.SetCodeplugVersion();
            this.ResolveUnpack();
            ((App) System.Windows.Application.Current).TheDocument.docFileName = Path.GetFileName(sFileName);
            ((App) System.Windows.Application.Current).TheDocument.docFilePath = Path.GetFullPath(sFileName);
          }
        }
        Mouse.OverrideCursor = overrideCursor;
        this.HandleFileOpening(sFileName, ref errorMsg, isNonGuiOpen, isForExport, ref fileOpened, mainWindow, fileHeader);
      }
    }
    catch (Exception ex)
    {
      WindowMain.HandleException(out errorMsg, isNonGuiOpen, out fileOpened, ex);
    }
    finally
    {
      this.HandleFinally(overrideCursor, initialDirectory);
    }
    this.WindowMain_AllowDrop((object) null, (System.Windows.Input.MouseEventArgs) null);
    return fileOpened;
  }

  public static void HandleException(
    out string errorMsg,
    bool isNonGuiOpen,
    out bool fileOpened,
    Exception ex)
  {
    fileOpened = false;
    errorMsg = ex.Message;
    if (isNonGuiOpen)
      return;
    AppInfoManager.StatusMsgReport.PostMessage(StatusMsgType.Error, ex.Message);
  }

  public void HandleFinally(System.Windows.Input.Cursor originalCursor, string InitialDirectorySnapShot)
  {
    Mouse.OverrideCursor = originalCursor;
    this._readWritePasswordApp.ClearCachedPasswordValidation();
    if (InitialDirectorySnapShot != AcpFileDialog.InitialDirectory)
      AcpFileDialog.InitialDirectory = InitialDirectorySnapShot;
    UndoManager.Reset();
  }

  public void HandleFileOpening(
    string sFileName,
    ref string errorMsg,
    bool isNonGuiOpen,
    bool isForExport,
    ref bool fileOpened,
    WindowMain winMain,
    AcpFileHeader fileHeader)
  {
    if (fileOpened)
    {
      if (this.AuthenticateCpgForRWPassword(((App) System.Windows.Application.Current).TheDocument, (string) null, isNonGuiOpen, isForExport))
      {
        ASKConstraints.Initialize();
        if (!isNonGuiOpen)
        {
          UndoManager.Reset();
          AppInfoManager.ClearNavigationHistory = true;
          Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
          winMain.CpgOpenFlag = true;
          UtilityMack.bOpenFromRMC = this.deviceFromServer != null || this.templateFromServer != null;
          if (this.IsCxfEditingMode)
            UtilityMack.isInCxfEditingMode = true;
          PageNavPaneButtons content = (PageNavPaneButtons) winMain.FrameLeft.Content;
          content.ButtonCpgNav.IsSelected = true;
          content.FrameCodeplug.Navigate(new Uri("PageTreeView.xaml", UriKind.RelativeOrAbsolute));
          winMain.FrameCenterTop.Navigate(new Uri(FeatureManager.GetFeature(2049).UIPagePath, UriKind.RelativeOrAbsolute));
          if (this.IsCloudNativeMode)
          {
            content.FrameHome.Visibility = Visibility.Hidden;
            content.ButtonHome.Visibility = Visibility.Hidden;
            content.FrameCustView.Visibility = Visibility.Hidden;
            content.ButtonCustomViewMode.Visibility = Visibility.Hidden;
            content.ButtonCpgNav.Visibility = Visibility.Hidden;
          }
          AppInfoManager.AppMode = ApplicationMode.CodeplugConfigurationMode;
          if (AppInfoManager.AppView == DifferentiatedUserViewType.Custom)
          {
            string customVwPath = this.customVwPath;
            try
            {
              if (!string.IsNullOrEmpty(customVwPath))
              {
                if (File.Exists(customVwPath))
                  ((App) System.Windows.Application.Current).TheDocument.ImportFromXml(customVwPath, XmlFileType.CustomView);
              }
            }
            catch (Exception ex)
            {
              AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, $"{AppResources.Error_loading_Custom_View} {customVwPath} {AppResources.Not_a_Valid_Custom_View_File}");
              this.DiffViewType.SelectedIndex = 2;
            }
          }
        }
        try
        {
          Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation radioInformation = FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation;
          string numberA8539Value = radioInformation.General.RadInfoGeneralModelNumber_A8539Value;
          if (numberA8539Value != null || numberA8539Value != "")
            this.MyModelNumber = numberA8539Value;
          this.PostUpgradeCodeplugProccessing(radioInformation.General.RadInfoGeneralCodeplugVersion_A7683.Value, AppInfoManager.AppVersion);
          this.IsFreonProduct = UtilityMack.IsFreonCodeplug(numberA8539Value);
        }
        catch (Exception ex)
        {
        }
        DateTime now1 = DateTime.Now;
        DateTime now2 = DateTime.Now;
        this.objModelTiering = new ModelTiering(this.MyModelNumber, ModelTiering.ActionTypes.OPEN, ModelTiering.TargetTypes.ALL);
        this.objModelTiering.UpdateUtilityMackModelType();
        if (!isNonGuiOpen)
        {
          this.IsPortableModel = UtilityMack.IsPortablePro;
          this.IsMobileModel = UtilityMack.IsMobilePro;
        }
        if (this.IsCloudNativeMode)
          this.SetTitleBar(CloudNativeParameters.CloudNativeJobWrapper.TemplateDetails.TemplateName, (string) null);
        ConstraintManager.Suspend();
        this.objModelTiering.ApplyTiering();
        if (UtilityMack.bOpenFromRMC)
        {
          if (this.deviceFromServer != null)
          {
            (FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation).General.RadInfoGeneralFirmwareVersion_A8124.Value = (this.deviceFromServer.WorkingCodeplug as APXCodeplug).FirmwareVersion;
            (FeatureManager.GetFeature(2010)[0] as Motorola.MackinawCPS.CoreFeatures.DisplayAndMenu.DisplayAndMenu).Advanced.DispMenuAdvancedLanguageSelection_A8386Value = (this.deviceFromServer.WorkingCodeplug.Template as APXTemplate).LanguageIndex.Value;
          }
          else if (this.templateFromServer != null)
          {
            (FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation).General.RadInfoGeneralFirmwareVersion_A8124.Value = this.templateFromServer.FirmwareVersion;
            (FeatureManager.GetFeature(2010)[0] as Motorola.MackinawCPS.CoreFeatures.DisplayAndMenu.DisplayAndMenu).Advanced.DispMenuAdvancedLanguageSelection_A8386Value = this.templateFromServer.LanguageIndex.Value;
          }
          LanguagePackHelper.BindingLanguageSections();
        }
        ConstraintManager.Resume();
        this.SetProductModelIdentifierField();
        this.PropertiesChanged();
        this.SetDVRSHoptionEnabledField();
        this.SetDVRSHwEnabledField();
        this.IsCpgConvOnly = false;
        if (!isNonGuiOpen)
        {
          PageStatusBar content = (PageStatusBar) winMain.FrameStatusBar.Content;
          if (this.MultiCodeplugInfo != null)
            this.SetMultiCodeplugInfoInProgressBar(content);
          content.RadioModel = fileHeader.ModelNumber;
          content.SerialNum = fileHeader.SerialNumber;
          content.Status = AppResources.READY_ID;
        }
        foreach (IAcpConstraints feature in FeatureManager.Features)
          feature.CalculateVisibility(true);
        this.IsMobileModelSupportedControlHeads();
        if (AppInfoManager.AppMode == ApplicationMode.CodeplugConfigurationMode)
          this.AppMenuWriteProtect.IsEnabled = false;
        this.SecureADPKeyDataFixup();
        this.ScanListFixup();
        this.CnvPerTalkgroupListFixUp();
        this.LimitedPatienceTimeFixup();
        this.InitASKProgHistoryRecSet();
        this.InitTrkPerAnnGroup();
        if (this.IsPortableModel)
          this.TxPowerTableInit();
        this.MFKTableInit();
        this.ShepherdsInitForFob();
        this.TriggerMuteToneRefresh();
        if (this.IsMobileModel)
        {
          this.TxPowerTableInitForMobile();
          this.TxPowerNewTableInitForMobile();
          this.BandSplitOverRidingInit();
          this.FixupOneTouchTrunkingSystem();
        }
        int num = this.O9TableInit() ? 1 : 0;
        this.DEKVipTableInit();
        this.PresetZoneChannelTableInit();
        this.BookmarkQuickAccessListInit();
        this.KeypadRecsetAndTableInit();
        this.O2MFKTableInit();
        this.O7MFKTableInit();
        this.O2NavigationControlsTableInit();
        this.O7NavigationControlsTableInit();
        this.E5NavigationControlsTableInit();
        this.O3NavigationControlsTableInit();
        this.O5NavigationControlsTableInit();
        this.O9NavigationControlsTableInit();
        this.KMANavigationControlsTableInit();
        this.SmartKeyFobTableInit();
        this.SideArrowTableInit();
        this.DataButtonInit();
        this.SiteSelectableAlertTableInit();
        this.AlertListTableInit();
        this.FixupAccyButton();
        this.FixUpTrunkingNotificationButtonForMahalo();
        this.FixUpViqiSecureClearStrapping();
        this.AddQC2DefaultRecord();
        CodeplugFixups.SetTxPowerLevelMediumAndMediumHighValueSameAsLow(this.CodeplugVersion, this.MyModelNumber);
        this.expandFlashcode();
        this.SyncASTROOTARAndOTARProfileIndex(FeatureManager.ActiveDocument);
        this.SyncAstroOtarInhibit();
        this.FixUpSecureHardwareEncryptionIndependentKeyList();
        this.FixUpMPLVisiblityOnTrukingButton();
        this.FixUpMPLVisiblityOnTrukingAccyButton();
        this.FixUpChannelSearchVisiblityOnPortableButtons();
        this.FixUpChannelSearchVisiblityOnRSMButton();
        this.SyncAstroInfiniteUKEKRetention(FeatureManager.ActiveDocument);
        this.SyncASTROUserSelectable(FeatureManager.ActiveDocument);
        this.SyncAstroEraseOnPreviousChange(FeatureManager.ActiveDocument);
        ((App) System.Windows.Application.Current).TheDocument.Initialized(false);
        ConstraintManager.Suspend();
        this.SyncE5BottomButton();
        this.updateUnpackedFields(false, (RadioParams) null);
        if (num != 0)
          this.AddO9PhephedRecord();
        this.SyncO9PASirenButtons();
        this.O9DirectionalButtonsFixup();
        this.UpdateAuxControlTable();
        ConstraintManager.Resume();
        this.RefreshScanlistMap();
        this.DataProfileTrunkingGroupIDFixup();
        this.ValidateE5EmergencyOrangeButton();
        if (this.deviceFromServer == null && this.templateFromServer == null && !isNonGuiOpen && !(bool) System.Windows.Application.Current.Properties[(object) "CommandLineCPS"] && !this.IsCloudNativeMode)
          MruFiles.UpdateMRU(sFileName);
        if (this.deviceFromServer != null)
          this.UpdateFieldsWithServerValues(this.deviceFromServer);
        if (UtilityMack.bOpenFromRMC)
        {
          APXTemplate currentTpl = (APXTemplate) null;
          if (this.deviceFromServer != null)
            currentTpl = (this.deviceFromServer.WorkingCodeplug as APXCodeplug).Template as APXTemplate;
          else if (this.templateFromServer != null)
            currentTpl = this.templateFromServer;
          if (!isForExport && currentTpl != null)
            DVRSFilesHelper.ApplyDVRSFileDataFromTemplate(currentTpl);
        }
        else
          this.FixupViQiKeySelect();
        this.FixUpUnlockPasswordUNKNOWNValueToEmptyString();
        this.FixUpConventionalDynamicIDWithPasswordWrongValueToEmptyString();
        this.FixUpSetCodeplugNameToDefaultValueIfEmpty();
        this.FixUpVIQIVirtualPartnerValueSetToDisabledIfLMR();
        this.FixUpSwitchesValueSetToBlankIfUnprogrammed();
        this.ZoneToZoneCloneFixup();
        this.FixupSystemProtocolType();
        this.FixupTtsZoneVoiceAnnouncementCommandIsEmptyOrConfusable();
        this.expandFlashcode();
        this.SyncRadioInhibitViaAstroOtar();
        this.FixupCertficateDisplayName();
        this.RunTMSConstraints();
        this.URLTableFixup();
        this.FixUpSetNFPACompliantToTrueIfNFPARadio();
        this.SetVisibilityForOwnerSystemID();
      }
      else
      {
        AppInfoManager.StatusMsgReport.Clear();
        AppInfoManager.InvalidFieldsReport.Clear();
        errorMsg = AppResources.Incorrect_Password;
        fileOpened = false;
        if (!this.IsCloudNativeMode)
          return;
        Environment.Exit(0);
      }
    }
    else
    {
      string message;
      if (AppInfoManager.NonEngOldCodeplug)
      {
        message = AppResources.File_colon_Cannot_Open_Old_CP_NonEng.AcpStringFormat((object) sFileName);
      }
      else
      {
        message = AppResources.File_colon_could_not_be_opened.AcpStringFormat((object) sFileName);
        if (AcpDocument.CpgVersionErrStr != "")
          message = $"{message} {AcpDocument.CpgVersionErrStr}";
      }
      ((App) System.Windows.Application.Current).TheDocument.FileClose();
      if (!isNonGuiOpen)
      {
        AppInfoManager.StatusMsgReport.PostMessage(StatusMsgType.Error, message);
        ((PageStatusBar) winMain.FrameStatusBar.Content).Status = AppResources.Open_Failed;
      }
      errorMsg = message;
    }
  }

  private void SetVisibilityForOwnerSystemID()
  {
    if (!this.IsCloudNativeMode)
      return;
    Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide radioWide = FeatureManager.GetFeature(2045)[0] as Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide;
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    radioWide.General.RadWideGeneralOwnerSystemID_A37153.IsVisible = WindowMain.\u003C\u003EO.\u003C0\u003E__SetIsVisibleToFalseInCloudNativeMode ?? (WindowMain.\u003C\u003EO.\u003C0\u003E__SetIsVisibleToFalseInCloudNativeMode = new StateConstraint(WindowMain.SetIsVisibleToFalseInCloudNativeMode));
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    radioWide.General.RadWideGeneralOwnerAdvancedKeyType_A38663.IsVisible = WindowMain.\u003C\u003EO.\u003C0\u003E__SetIsVisibleToFalseInCloudNativeMode ?? (WindowMain.\u003C\u003EO.\u003C0\u003E__SetIsVisibleToFalseInCloudNativeMode = new StateConstraint(WindowMain.SetIsVisibleToFalseInCloudNativeMode));
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    radioWide.General.RadWideGeneralOwnerWACNID_A38656.IsVisible = WindowMain.\u003C\u003EO.\u003C0\u003E__SetIsVisibleToFalseInCloudNativeMode ?? (WindowMain.\u003C\u003EO.\u003C0\u003E__SetIsVisibleToFalseInCloudNativeMode = new StateConstraint(WindowMain.SetIsVisibleToFalseInCloudNativeMode));
    radioWide.General.CalculateVisibility();
  }

  private static bool SetIsVisibleToFalseInCloudNativeMode(IAcpFeatureSection self) => false;

  private void SetMultiCodeplugInfoInProgressBar(PageStatusBar pgSB)
  {
    string str = (FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation).General.RadInfoGeneralCodeplugName.Value;
    if (this.MultiCodeplugInfo.ActiveCodeplugIndex == 0)
      pgSB.CodeplugIdentifier = $"{AppResources.MultiCodeplug_Progress_Bar_Default} {AppResources.MultiCodeplug_Progress_Bar_Primary}";
    else
      pgSB.CodeplugIdentifier = $"{AppResources.MultiCodeplug_Progress_Bar_Default} {AppResources.MultiCodeplug_Progress_Bar_Secondary} - {str}";
  }

  public void ResolveUnpack()
  {
    this.ResolveUCLReferenceAfterUnpack();
    this.ResolvedMFKTimerUnpack();
  }

  public void InitCodeplugOpen()
  {
    this.DocumentOperations.InitDocument();
    ((App) System.Windows.Application.Current).TheDocument.FileNew();
    UndoManager.StopUndoRedo();
    UndoManager.Reset();
    ConstraintManager.Suspend();
  }

  public void IsMobileModelSupportedControlHeads(bool supported = false)
  {
    this.IsMobileModelAndSupportedO2 = supported;
    this.IsMobileModelAndSupportedO3 = supported;
    this.IsMobileModelAndSupportedE5 = supported;
    this.IsMobileModelAndSupportedO5 = supported;
    this.IsMobileModelAndSupportedO7 = supported;
    this.IsMobileModelAndSupportedO9 = supported;
  }

  internal void FixupViQiKeySelect()
  {
    IAcpRecordset feature = FeatureManager.GetFeature(2064);
    if (feature == null)
      return;
    for (int index = 0; index < feature.Count; ++index)
    {
      Motorola.MackinawCPS.CoreFeatures.TrunkingSystem.TrunkingSystem trunkingSystem = feature[index] as Motorola.MackinawCPS.CoreFeatures.TrunkingSystem.TrunkingSystem;
      if (trunkingSystem.SecureMultikey.TrkSysSecureMultikeyVirtualPartnerKeySelect_A43669 != null)
      {
        trunkingSystem.SecureMultikey.TrkSysSecureMultikeyVirtualPartnerKeySelect_A43669.CalculateValidity();
        trunkingSystem.SecureMultikey.TrkSysSecureMultikeyVirtualPartnerKeySelect_A43669.CalculateApplicability();
      }
    }
  }

  private void FixUpViqiSecureClearStrapping()
  {
    IAcpRecordset feature = FeatureManager.GetFeature(2064);
    if (feature == null)
      return;
    for (int index = 0; index < feature.Count; ++index)
    {
      AcpListField clearStrappingA43670 = feature[index] is Motorola.MackinawCPS.CoreFeatures.TrunkingSystem.TrunkingSystem trunkingSystem ? trunkingSystem.SecureMultikey?.TrkSysSecureMultikeyVirtualPartnerSecureClearStrapping_A43670 : (AcpListField) null;
      if (clearStrappingA43670 != null && clearStrappingA43670.HiddenStatic && clearStrappingA43670.Value != 0)
        clearStrappingA43670.Value = 0;
    }
  }

  internal void FixupSystemProtocolType()
  {
    IAcpRecordset feature = FeatureManager.GetFeature(2072);
    if (feature == null)
      return;
    for (int index = 0; index < feature.Count; ++index)
    {
      Motorola.MackinawCPS.CoreFeatures.TrunkingPersonality.TrunkingPersonality trunkingPersonality = feature[index] as Motorola.MackinawCPS.CoreFeatures.TrunkingPersonality.TrunkingPersonality;
      if (trunkingPersonality.General.TrkPerGeneralProtocolType_A8767 != null)
      {
        trunkingPersonality.General.TrkPerGeneralProtocolType_A8767.CalculateValidity();
        trunkingPersonality.General.TrkPerGeneralProtocolType_A8767.CalculateApplicability();
      }
    }
  }

  private void FixupTtsZoneVoiceAnnouncementCommandIsEmptyOrConfusable()
  {
    Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation radioInformation = FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation;
    string versionA7683UiValue = radioInformation.General.RadInfoGeneralCodeplugVersion_A7683_UIValue;
    if (versionA7683UiValue.Length < 3 || !(versionA7683UiValue.Substring(1, 2) == "26") || !radioInformation.Labtool.RadInfoLabtoolQA09028ViQi_VoiceControlValue)
      return;
    IAcpRecordset feature = FeatureManager.GetFeature(2051);
    int index1 = 0;
    while (true)
    {
      int num1 = index1;
      int? count1 = feature?.Count;
      int valueOrDefault1 = count1.GetValueOrDefault();
      if (num1 < valueOrDefault1 & count1.HasValue)
      {
        if (feature[index1] is Motorola.MackinawCPS.CoreFeatures.ZoneChannelAssignment.ZoneChannelAssignment channelAssignment)
          channelAssignment.Zone?.VCZoneAnnouncement_A21515?.CalculateValidity();
        IAcpRecordset embeddedRecset = channelAssignment?.Channels?.EmbeddedRecset;
        int index2 = 0;
        while (true)
        {
          int num2 = index2;
          int? count2 = embeddedRecset?.Count;
          int valueOrDefault2 = count2.GetValueOrDefault();
          if (num2 < valueOrDefault2 & count2.HasValue)
          {
            if (embeddedRecset[index2] is ChannelAssignmentListInner assignmentListInner)
              assignmentListInner.ChannelAssignmentListInnerSection?.VCChannelAnnouncement_A20176?.CalculateValidity();
            ++index2;
          }
          else
            break;
        }
        ++index1;
      }
      else
        break;
    }
  }

  internal void UpdateFieldsWithServerValues(APXRadio device)
  {
    this.UpdateFieldsWithServerValues(device, false);
  }

  internal void UpdateFieldsWithServerValues(APXRadio device, bool isForExport)
  {
    APXCodeplug apxCodeplug = !isForExport ? device.WorkingCodeplug as APXCodeplug : device.CurrentCodeplug as APXCodeplug;
    Motorola.MackinawCPS.CoreFeatures.DataWide.DataWide dataWide = FeatureManager.GetFeature(2028)[0] as Motorola.MackinawCPS.CoreFeatures.DataWide.DataWide;
    Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation radioInformation = FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation;
    Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide radioWide = FeatureManager.GetFeature(2045)[0] as Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide;
    Motorola.MackinawCPS.CoreFeatures.SecureWide.SecureWide secureWide = FeatureManager.GetFeature(2021)[0] as Motorola.MackinawCPS.CoreFeatures.SecureWide.SecureWide;
    radioInformation.General.RadInfoGeneralSerialNumber_A9122.Value = device.SerialNumber;
    if (!string.IsNullOrEmpty(apxCodeplug.BluetoothDUNPeerIP))
      dataWide.General.DataWideGeneralBTDUNPeerIPAddress_A41123.UIValue = apxCodeplug.BluetoothDUNPeerIP;
    if (!string.IsNullOrEmpty(apxCodeplug.BluetoothDUNSubscriberIP))
      dataWide.General.DataWideGeneralBTDUNSUIPAddress_A41120.UIValue = apxCodeplug.BluetoothDUNSubscriberIP;
    if (!string.IsNullOrEmpty(apxCodeplug.PeerIP))
      dataWide.General.DataWideGeneralPeerIPAddress1_A8524.UIValue = apxCodeplug.PeerIP;
    if (!string.IsNullOrEmpty(apxCodeplug.SubscriberIP))
      dataWide.General.DataWideGeneralSubscriberIPAddress1_A9222.UIValue = apxCodeplug.SubscriberIP;
    if (isForExport)
      radioInformation.General.RadInfoGeneralSerialNumber_A9122.Value = device.SerialNumber;
    radioInformation.General.RadInfoGeneralFirmwareVersion_A8124.Value = apxCodeplug.FirmwareVersion;
    MultipleFieldsXML multipleFieldsXml = MultipleFieldsXML.DeserializeFromXML(apxCodeplug.DeviceInfoFields);
    if (multipleFieldsXml != null)
    {
      Dictionary<string, object> dictionary = multipleFieldsXml.ConvertToDictionary();
      if (dictionary != null)
      {
        if (dictionary["RadInfoGeneralUCMVersion_A9591"] != null && !string.IsNullOrEmpty(dictionary["RadInfoGeneralUCMVersion_A9591"].ToString()))
          radioInformation.General.RadInfoGeneralUCMVersion_A9591.Value = dictionary["RadInfoGeneralUCMVersion_A9591"].ToString();
        if (dictionary["RadInfoOptionExpansionBoardBoardName_A37549"] != null && !string.IsNullOrEmpty(dictionary["RadInfoOptionExpansionBoardBoardName_A37549"].ToString()))
          radioInformation.OptionExpansionBoard.RadInfoOptionExpansionBoardBoardName_A37549.Value = dictionary["RadInfoOptionExpansionBoardBoardName_A37549"].ToString();
        if (!string.IsNullOrEmpty(radioInformation.OptionExpansionBoard.RadInfoOptionExpansionBoardBoardName_A37549.Value) && radioInformation.OptionExpansionBoard.RadInfoOptionExpansionBoardBoardName_A37549.Value != AcgResources.ID_NA)
        {
          if (dictionary["RadInfoOptionExpansionBoardBoardFirmwareVersion_A37048"] != null && !string.IsNullOrEmpty(dictionary["RadInfoOptionExpansionBoardBoardFirmwareVersion_A37048"].ToString()))
            radioInformation.OptionExpansionBoard.RadInfoOptionExpansionBoardBoardFirmwareVersion_A37048.Value = dictionary["RadInfoOptionExpansionBoardBoardFirmwareVersion_A37048"].ToString();
          if (dictionary["RadInfoOptionExpansionBoardBoardType_A37049"] != null && !string.IsNullOrEmpty(dictionary["RadInfoOptionExpansionBoardBoardType_A37049"].ToString()))
            radioInformation.OptionExpansionBoard.RadInfoOptionExpansionBoardBoardType_A37049.Value = dictionary["RadInfoOptionExpansionBoardBoardType_A37049"].ToString();
        }
        if (dictionary["RadInfoGeneralDSPVersion_A7892"] != null && !string.IsNullOrEmpty(dictionary["RadInfoGeneralDSPVersion_A7892"].ToString()))
          radioInformation.General.RadInfoGeneralDSPVersion_A7892.Value = dictionary["RadInfoGeneralDSPVersion_A7892"].ToString();
        if (dictionary["RadInfoGeneralPSDTVersion_A8768"] != null && !string.IsNullOrEmpty(dictionary["RadInfoGeneralPSDTVersion_A8768"].ToString()))
          radioInformation.General.RadInfoGeneralPSDTVersion_A8768.Value = dictionary["RadInfoGeneralPSDTVersion_A8768"].ToString();
        if (dictionary["RadInfoGeneralSecureHardwareType"] != null && !string.IsNullOrEmpty(dictionary["RadInfoGeneralSecureHardwareType"].ToString()))
          radioInformation.General.RadInfoGeneralSecureHardwareType.Value = dictionary["RadInfoGeneralSecureHardwareType"].ToString();
        if (dictionary["RadInfoGeneralSecureHardwareVersion"] != null && !string.IsNullOrEmpty(dictionary["RadInfoGeneralSecureHardwareVersion"].ToString()))
          radioInformation.General.RadInfoGeneralSecureHardwareVersion.Value = dictionary["RadInfoGeneralSecureHardwareVersion"].ToString();
        if (dictionary["RadInfoGeneralTuningVersion_A9509"] != null && !string.IsNullOrEmpty(dictionary["RadInfoGeneralTuningVersion_A9509"].ToString()))
          radioInformation.General.RadInfoGeneralTuningVersion_A9509.Value = dictionary["RadInfoGeneralTuningVersion_A9509"].ToString();
        if (dictionary["RadInfoGeneralBootloaderVersion_A7567"] != null && !string.IsNullOrEmpty(dictionary["RadInfoGeneralBootloaderVersion_A7567"].ToString()))
          radioInformation.General.RadInfoGeneralBootloaderVersion_A7567.Value = dictionary["RadInfoGeneralBootloaderVersion_A7567"].ToString();
      }
    }
    DateTime? lastProgrammedDate = apxCodeplug.LastProgrammedDate;
    if (lastProgrammedDate.HasValue)
    {
      AcpFieldX<long, string> dateDbValueA8411 = radioInformation.Tracking.RadInfoLabtoolLastProgrammedDateDBValue_A8411;
      lastProgrammedDate = apxCodeplug.LastProgrammedDate;
      DateTime universalTime = lastProgrammedDate.Value;
      universalTime = universalTime.ToUniversalTime();
      long ticks = universalTime.Ticks;
      dateDbValueA8411.Value = ticks;
    }
    radioWide.Bluetooth.RadWideBluetoothFriendlyName_A41181.Value = apxCodeplug.BluetoothFriendlyName != null ? apxCodeplug.BluetoothFriendlyName : string.Empty;
    AcpSimpleRangeField labtoolVrIdA43727 = (FeatureManager.GetFeature(4142)[0] as Motorola.MackinawCPS.CoreFeatures.DVRSWide.DVRSWide).General.DVRSWideLabtoolVrId_A43727;
    int? nullable1;
    int num1;
    if (!apxCodeplug.VRID.HasValue)
    {
      num1 = 0;
    }
    else
    {
      nullable1 = apxCodeplug.VRID;
      num1 = nullable1.Value;
    }
    labtoolVrIdA43727.Value = num1;
    AcpField<bool> advancedExternalMicOnly = radioWide.Depot.AdvancedExternalMicOnly;
    bool? nullable2 = apxCodeplug.DisableWriteProtect;
    int num2 = nullable2.GetValueOrDefault() ? 1 : 0;
    advancedExternalMicOnly.SetValue(num2 != 0);
    nullable2 = apxCodeplug.AskRequired;
    if (nullable2.HasValue)
    {
      AcpField<bool> askRequiredA37152 = radioWide.General.RadWideGeneralASKRequired_A37152;
      nullable2 = apxCodeplug.AskRequired;
      int num3 = nullable2.Value ? 1 : 0;
      askRequiredA37152.Value = num3 != 0;
    }
    nullable1 = apxCodeplug.OwnerAdvKeyType;
    if (nullable1.HasValue)
    {
      AcpListField advancedKeyTypeA38663 = radioWide.General.RadWideGeneralOwnerAdvancedKeyType_A38663;
      nullable1 = apxCodeplug.OwnerAdvKeyType;
      int num4 = nullable1.Value;
      advancedKeyTypeA38663.Value = num4;
    }
    nullable1 = apxCodeplug.HomeSystemId;
    if (nullable1.HasValue)
    {
      AcpSimpleRangeField ownerSystemIdA37153 = radioWide.General.RadWideGeneralOwnerSystemID_A37153;
      nullable1 = apxCodeplug.HomeSystemId;
      int num5 = nullable1.Value;
      ownerSystemIdA37153.Value = num5;
    }
    nullable1 = apxCodeplug.OwnerWacnId;
    if (nullable1.HasValue)
    {
      AcpSimpleRangeField ownerWacnidA38656 = radioWide.General.RadWideGeneralOwnerWACNID_A38656;
      nullable1 = apxCodeplug.OwnerWacnId;
      int num6 = nullable1.Value;
      ownerWacnidA38656.Value = num6;
    }
    nullable2 = apxCodeplug.RadioInhibitedTrunking;
    if (nullable2.HasValue)
    {
      AcpField<bool> radioInhibitedA19483 = radioWide.Labtool.TrunkingRadioInhibited_A19483;
      nullable2 = apxCodeplug.RadioInhibitedTrunking;
      int num7 = nullable2.Value ? 1 : 0;
      radioInhibitedA19483.Value = num7 != 0;
    }
    if (!string.IsNullOrEmpty(apxCodeplug.UserPIN))
      radioWide.UserInformationAndPasswords.RadWideUserInformationandPINPassword_41303.Value = apxCodeplug.UserPIN;
    radioWide.UserInformationAndPasswords.RadWideUserInformationandUserLoginUnitID_41306.Value = apxCodeplug.UserLoginUnitID != null ? apxCodeplug.UserLoginUnitID : string.Empty;
    radioWide.UserInformationAndPasswords.RadWideUserInformationandPasswordsRadioAlias_A8829.Value = apxCodeplug.RadioAlias != null ? apxCodeplug.RadioAlias : string.Empty;
    radioWide.UserInformationAndPasswords.RadWideUserInformationandPasswordsSoftIDUsername_A9169.Value = apxCodeplug.UserName != null ? apxCodeplug.UserName : string.Empty;
    int num8 = 1;
    int? nullable3 = apxCodeplug.APXOtarProfiles.Where<APXOtarProfile>((Func<APXOtarProfile, bool>) (p =>
    {
      bool? independentList = p.IndependentList;
      bool flag = false;
      return independentList.GetValueOrDefault() == flag & independentList.HasValue && p.OtarID.HasValue;
    })).Select<APXOtarProfile, int?>((Func<APXOtarProfile, int?>) (p => p.OtarID)).FirstOrDefault<int?>();
    if (nullable3.HasValue)
    {
      secureWide.ASTROOTAR.SecWideASTROOTARIndividualASTROOTARRadioID_A8284.SetValue(nullable3.Value);
    }
    else
    {
      AcpSimpleRangeField astrootarRadioIdA8284 = secureWide.ASTROOTAR.SecWideASTROOTARIndividualASTROOTARRadioID_A8284;
      nullable1 = apxCodeplug.OtarID;
      int newValue;
      if (!nullable1.HasValue)
      {
        newValue = num8;
      }
      else
      {
        nullable1 = apxCodeplug.OtarID;
        newValue = nullable1.Value;
      }
      astrootarRadioIdA8284.SetValue(newValue);
    }
    AcpField<bool> astrootarastrootarEnableA7496 = secureWide.ASTROOTAR.SecWideASTROOTARASTROOTAREnable_A7496;
    nullable2 = apxCodeplug.AstroOtarEnable;
    int num9 = nullable2.Value ? 1 : 0;
    astrootarastrootarEnableA7496.Value = num9 != 0;
    APXDataProfile[] apxDataProfileArray = new APXDataProfile[0];
    if (apxCodeplug.APXDataProfiles.Count > 0)
      apxDataProfileArray = apxCodeplug.APXDataProfiles.OrderBy<APXDataProfile, int?>((Func<APXDataProfile, int?>) (prf => prf.OrderId)).ToArray<APXDataProfile>();
    IAcpRecordset feature1 = FeatureManager.GetFeature(2054);
    for (int index = 0; index < feature1.Count; ++index)
    {
      Motorola.MackinawCPS.CoreFeatures.DataProfiles.DataProfiles RefDataProfile = feature1[index] as Motorola.MackinawCPS.CoreFeatures.DataProfiles.DataProfiles;
      foreach (APXDataProfile apxDataProfile in apxDataProfileArray)
      {
        if (apxDataProfile.Name == RefDataProfile.General.DataProfGeneralkeyofDataProfiles_A19446.Value)
        {
          RefDataProfile.General.DataProfGeneralMobileComputerIPAddress_A8523.UIValue = apxDataProfile.PeerIP;
          RefDataProfile.General.DataProfGeneralSubscriberIPAddress_A21157.UIValue = apxDataProfile.SubscriberIP;
          RefDataProfile.General.DataProfGeneralSubscriberAirInterfaceIPAddress_A9220.UIValue = apxDataProfile.AirInterfaceAddress;
          RefDataProfile.General.DataProfilesGeneralBTDUNPeerIPAddress_A41127.UIValue = apxDataProfile.AstroBluetoothDunPeerIp;
          RefDataProfile.General.DataProfilesGeneralBTDUNSUIPAddress_A41126.UIValue = apxDataProfile.AstroBluetoothDunSubscriberIp;
          RMUtilities.PopulateAstroCpsTrunkingGroupIDs(ref RefDataProfile, apxDataProfile.TrunkingGroupIds);
          break;
        }
      }
    }
    APXRadioSystem[] apxRadioSystemArray = new APXRadioSystem[0];
    if (apxCodeplug.APXRadioSystems.Count > 0)
      apxRadioSystemArray = apxCodeplug.APXRadioSystems.OrderBy<APXRadioSystem, int?>((Func<APXRadioSystem, int?>) (sys => sys.OrderId)).ToArray<APXRadioSystem>();
    IAcpRecordset feature2 = FeatureManager.GetFeature(2053);
    AstroSystemType? systemType;
    if (isForExport)
    {
      for (int index = 0; index < feature2.Count; ++index)
      {
        Motorola.MackinawCPS.CoreFeatures.ConventionalSystem.ConventionalSystem conventionalSystem = feature2[index] as Motorola.MackinawCPS.CoreFeatures.ConventionalSystem.ConventionalSystem;
        foreach (APXRadioSystem apxRadioSystem in apxRadioSystemArray)
        {
          if (apxRadioSystem.SystemName == conventionalSystem.General.CnvSysGeneralKeyofConventionalSystem_A20482.Value)
          {
            systemType = apxRadioSystem.SystemType;
            if (systemType.GetValueOrDefault() == AstroSystemType.CONVENTIONAL)
            {
              AstroSystemSubType? systemSubType = apxRadioSystem.SystemSubType;
              AstroSystemSubType astroSystemSubType = AstroSystemSubType.ASTRO;
              if (!(systemSubType.GetValueOrDefault() == astroSystemSubType & systemSubType.HasValue))
              {
                systemSubType = apxRadioSystem.SystemSubType;
                if (systemSubType.GetValueOrDefault() != AstroSystemSubType.DVRS)
                {
                  systemSubType = apxRadioSystem.SystemSubType;
                  if (systemSubType.GetValueOrDefault() == AstroSystemSubType.MDC)
                  {
                    AcpRangeField<int, string> mdcPrimaryIdA8744 = conventionalSystem.General.CnvSysGeneralMDCPrimaryID_A8744;
                    nullable1 = apxRadioSystem.RadioId;
                    int num10 = nullable1.Value;
                    mdcPrimaryIdA8744.Value = num10;
                    break;
                  }
                  break;
                }
              }
              AcpSimpleRangeField individualIdA8287 = conventionalSystem.General.CnvSysGeneralIndividualID_A8287;
              nullable1 = apxRadioSystem.RadioId;
              int num11 = nullable1.Value;
              individualIdA8287.Value = num11;
              break;
            }
          }
        }
      }
    }
    IAcpRecordset feature3 = FeatureManager.GetFeature(2064);
    for (int index = 0; index < feature3.Count; ++index)
    {
      Motorola.MackinawCPS.CoreFeatures.TrunkingSystem.TrunkingSystem trunkingSystem = feature3[index] as Motorola.MackinawCPS.CoreFeatures.TrunkingSystem.TrunkingSystem;
      foreach (APXRadioSystem apxRadioSystem in apxRadioSystemArray)
      {
        if (apxRadioSystem.SystemName == trunkingSystem.General.TrkSysGeneralKeyofTrunkingSystem_A12658.Value)
        {
          systemType = apxRadioSystem.SystemType;
          AstroSystemType astroSystemType = AstroSystemType.TRUNCKING;
          if (systemType.GetValueOrDefault() == astroSystemType & systemType.HasValue)
          {
            AcpListField coverageTypeA7782 = trunkingSystem.General.TrkSysGeneralCoverageType_A7782;
            nullable1 = apxRadioSystem.CoverageType;
            int num12 = nullable1.Value;
            coverageTypeA7782.Value = num12;
            AcpSimpleRangeField generalHomeWacnidA8205 = trunkingSystem.General.TrkSysGeneralHomeWACNID_A8205;
            nullable1 = apxRadioSystem.WacnId;
            int num13 = nullable1.Value;
            generalHomeWacnidA8205.Value = num13;
            if (isForExport)
            {
              AcpSimpleRangeField generalUnitIdA12651 = trunkingSystem.General.TrkSysGeneralUnitID_A12651;
              nullable1 = apxRadioSystem.RadioId;
              int num14 = nullable1.Value;
              generalUnitIdA12651.Value = num14;
            }
            AcpField<bool> shuffledBandPlanA9128 = trunkingSystem.TypeIIChannelSetup.TrkSysTypeIIChannelSetupShuffledBandPlan_A9128;
            nullable2 = apxRadioSystem.ShuffeledBandPlan;
            int num15 = nullable2.Value ? 1 : 0;
            shuffledBandPlanA9128.Value = num15 != 0;
            break;
          }
        }
      }
    }
    System.Collections.Generic.List<APXOtarProfile> apxOtarProfileList = new System.Collections.Generic.List<APXOtarProfile>();
    if (apxCodeplug.APXOtarProfiles != null && apxCodeplug.APXOtarProfiles.Any<APXOtarProfile>())
    {
      IAcpRecordset feature4 = FeatureManager.GetFeature(2055);
      System.Collections.Generic.List<APXOtarProfile> apxOtarProfiles = apxCodeplug.APXOtarProfiles;
      for (int index = 0; index < feature4.Count; ++index)
      {
        Motorola.MackinawCPS.CoreFeatures.SecureKMFProfile.SecureKMFProfile otarProfile = feature4[index] as Motorola.MackinawCPS.CoreFeatures.SecureKMFProfile.SecureKMFProfile;
        APXOtarProfile apxOtarProfile = apxCodeplug.APXOtarProfiles.SingleOrDefault<APXOtarProfile>((Func<APXOtarProfile, bool>) (p => p.Profile == (string) (AcpField<string>) otarProfile.ASTROOTARInformation.SecKmfProfASTROOTARInformationKeyofSecureKMFProfile_A12663));
        if (apxOtarProfile != null)
        {
          AcpSimpleRangeField astrootarRadioIdA8285 = otarProfile.ASTROOTARInformation.SecKmfProfASTROOTARInformationIndividualASTROOTARRadioID_A8285;
          nullable1 = apxOtarProfile.OtarID;
          int num16 = nullable1.Value;
          astrootarRadioIdA8285.Value = num16;
        }
      }
    }
    RMUtilities.PopulateAstroCpsASKProgrammingHistoryRecset(apxCodeplug.AstroSysKeyLog);
  }

  private void UpdateAuxControlTable()
  {
    foreach (AcpBusinessLayer.FeatureNode featureNode in (Collection<AcpBusinessLayer.FeatureNode>) (((FeatureManager.GetFeature(2033) as RadioErgonomicsWideRecset)[0][10633] as AuxControl).EmbeddedRecset as AuxControlTableInnerRecset))
    {
      AuxControlTableInnerSection tableInnerSection = (featureNode as AuxControlTableInner).AuxControlTableInnerSection;
      if (tableInnerSection.RadErgoWideAuxControlAbbrAuxOnAlias_A37612.Value.Length < 1)
        tableInnerSection.RadErgoWideAuxControlAbbrAuxOnAlias_A37612.SetValue(tableInnerSection.RadErgoWideAuxControlAbbrAuxOnAlias_A37612.DefaultValue);
      if (tableInnerSection.RadErgoWideAuxControlAuxOffAlias_A37252.Value.Length < 1)
        tableInnerSection.RadErgoWideAuxControlAuxOffAlias_A37252.SetValue(tableInnerSection.RadErgoWideAuxControlAuxOffAlias_A37252.DefaultValue);
      if (tableInnerSection.RadErgoWideAuxControlAuxOnAlias_A37250.Value.Length < 1)
        tableInnerSection.RadErgoWideAuxControlAuxOnAlias_A37250.SetValue(tableInnerSection.RadErgoWideAuxControlAuxOnAlias_A37250.DefaultValue);
    }
  }

  private void RestoreProfileBluetoothIPToDefaultValue()
  {
    foreach (Motorola.MackinawCPS.CoreFeatures.DataProfiles.DataProfiles dataProfiles in (Collection<AcpBusinessLayer.FeatureNode>) (FeatureManager.GetFeature(2054) as DataProfilesRecset))
    {
      long num = dataProfiles.General.DataProfilesGeneralBTDUNSUIPAddress_A41126.Value;
      if (num.Equals(0L))
        dataProfiles.General.DataProfilesGeneralBTDUNSUIPAddress_A41126.SetValue(25340096L);
      num = dataProfiles.General.DataProfilesGeneralBTDUNPeerIPAddress_A41127.Value;
      if (num.Equals(0L))
        dataProfiles.General.DataProfilesGeneralBTDUNPeerIPAddress_A41127.SetValue(42117312L);
    }
  }

  private void OnAppMruFileOpen(object sender, RoutedEventArgs e)
  {
    if (!(sender is AcpListBoxMruFiles))
      return;
    WindowMain mainWindow = (WindowMain) System.Windows.Application.Current.MainWindow;
    PageNavPaneButtons content = (PageNavPaneButtons) mainWindow.FrameLeft.Content;
    bool flag = false;
    if (this.CpgOpenFlag)
    {
      this.OnAppMenuClose(sender, e);
      if (this.CpgOpenFlag && !this.CanOpenCpgFlag)
        return;
      flag = true;
    }
    string filePath = ((SelectedMruFileEventArgs) e).FilePath;
    if (string.IsNullOrEmpty(filePath) || !this.OpenCodeplug(filePath) || !flag)
      return;
    content.FrameCodeplug.NavigationService.Refresh();
    if (!(mainWindow.FrameCenterTop.Content is PageRadioInformation))
      return;
    mainWindow.FrameCenterTop.NavigationService.Refresh();
  }

  internal bool SaveCodeplug() => this.SaveCodeplug(false);

  private bool SaveCodeplug(bool isServerArchive)
  {
    MemoryCleaner.CleanGarbageFromMemory();
    bool flag = true;
    TtsDataTreeUpdater.AddTtsToFeatureManager();
    if (this.cpsVersion.Length != 0 && this.cpsVersion.Substring(0, 1) != "R")
    {
      string versionA7683UiValue = (FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation).General.RadInfoGeneralCodeplugVersion_A7683_UIValue;
      if (versionA7683UiValue.Length != 0 && versionA7683UiValue.Substring(0, 1) == "R" && !(bool) System.Windows.Application.Current.Properties[(object) "CommandLineCPS"])
      {
        if (!isServerArchive)
        {
          string caption = this.IsCloudNativeMode ? AppResources.Publishing_Codeplug : AppResources.Saving_Codeplug_;
          flag = MyMessageBox.Show(this.IsCloudNativeMode ? AppResources.Warning_you_are_about_to_publish_a_Release : AppResources.Warning_you_are_about_to_save_a_Release, caption, MessageBoxButton.YesNo, MessageBoxImage.Exclamation, MessageBoxResult.Yes) == MessageBoxResult.Yes;
        }
      }
      else if (versionA7683UiValue.Length == 0)
      {
        AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, AppResources.Unable_to_save_Codeplug_Invalid_or_empty_Codeplug_version);
        flag = false;
      }
    }
    else if (this.cpsVersion.Length == 0)
      AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Info, AppResources.CPS_version_is_not_current);
    MemoryCleaner.CleanGarbageFromMemory();
    return flag;
  }

  internal void OnAppMenuSaveAs(object sender, RoutedEventArgs e)
  {
    Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation radioInformation = (Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation) null;
    this.bSaveCpgSuccessful = false;
    string docFilePath = ((App) System.Windows.Application.Current).TheDocument.docFilePath;
    string newValue = "";
    this.dvrsMsuDataSync = (DvrsMsuDataSync) null;
    try
    {
      AcpUI.Common.Utility.SaveFieldWithFocus();
      if (this.CanSaveCpgFlag)
      {
        if (!this.SaveCodeplug())
          return;
        bool flag = UndoManager.StopUndoRedo();
        AcpSaveFileDialog acpSaveFileDialog = new AcpSaveFileDialog();
        if (VersionInfoHelper.IsDFlagExisted(DFlagType.DASTRO))
          acpSaveFileDialog.Filter = AppResources.Vertex_Codeplug_Filter;
        else if (this.IsCxfEditingMode)
          acpSaveFileDialog.Filter = AppResources.Motorola_Cloud_Exchange_Format;
        else
          acpSaveFileDialog.Filter = AppResources.Motorola_Codeplug_Filter;
        acpSaveFileDialog.FileName = this.cpgFileName;
        AcpFileHeader header = WindowMain.GetHeader();
        if (acpSaveFileDialog.ShowDialog(header).GetValueOrDefault())
        {
          string fileName = acpSaveFileDialog.FileName;
          if (fileName != null)
          {
            radioInformation = FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation;
            newValue = radioInformation.General.RadInfoGeneralCodeplugVersion_A7683_UIValue;
            Motorola.MackinawCPS.CoreFeatures.DVRSWide.DVRSWide dvrsWide = FeatureManager.GetFeature(4142)[0] as Motorola.MackinawCPS.CoreFeatures.DVRSWide.DVRSWide;
            if (dvrsWide.General.RadErgoWideDigitalVehicularRepeaterSystemDVRSHardwareEnable_A7911.Value)
            {
              if (!AppInfoManager.InvalidFieldsReport.UiHasFields)
              {
                this.dvrsMsuDataSync = new DvrsMsuDataSync();
                uint hashCode = this.dvrsMsuDataSync.CalculateHashCode();
                dvrsWide.General.DVRSWideLabtoolDVRSSyncFieldsHash_A41811.SetValue((long) hashCode);
              }
              else
                AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, AppResources.Export_DVRS_MSU_Data_Failed_The_Codeplug_Contains_Invalid_Fields);
            }
            this.ResetOOBEField();
            if (fileName.EndsWith(".mc"))
            {
              radioInformation.General.RadInfoGeneralCodeplugVersion_A7683.SetValue(this.cpsVersion);
              radioInformation.Labtool.RadInfoLabtoolSecurePartitionVersionNumber_A9076.SetValue(this.cpsVersion);
              header.VersionNumber = this.cpsVersion;
              this.bSaveCpgSuccessful = ((App) System.Windows.Application.Current).TheDocument.FileSaveAsSafely(fileName, header);
              this.cpgFileName = fileName;
            }
            else if (fileName.EndsWith(".cxf", StringComparison.OrdinalIgnoreCase))
            {
              if (this.PromptQuitOnInvalids().Result)
              {
                int num = (int) System.Windows.MessageBox.Show(AppResources.The_codeplug_contains_invalid_fields_Please_correct_them_and_try_again, AppResources.Invalid_Fields_Error, MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
              }
              SecureString filePassword = CxfFileHandler.InitializePassword(this.IsCxfEditingMode);
              if (filePassword != null)
              {
                radioInformation.General.RadInfoGeneralCodeplugVersion_A7683.SetValue(this.cpsVersion);
                radioInformation.Labtool.RadInfoLabtoolSecurePartitionVersionNumber_A9076.SetValue(this.cpsVersion);
                header.VersionNumber = this.cpsVersion;
                this.bSaveCpgSuccessful = SaveCxfHandler.SaveCodeplugFile(fileName, filePassword, radioInformation.General.RadInfoGeneralModelNumber_A8539.Value, this.cpsVersion, radioInformation.General.RadInfoGeneralFirmwareVersion_A8124.Value);
                if (this.bSaveCpgSuccessful && this.IsCxfEditingMode)
                {
                  this.cpgFileName = fileName;
                  ((MackCPSDocument) ((App) System.Windows.Application.Current).TheDocument).resetDirty();
                }
                else
                {
                  radioInformation.General.RadInfoGeneralCodeplugVersion_A7683.SetValue(newValue);
                  radioInformation.Labtool.RadInfoLabtoolSecurePartitionVersionNumber_A9076.SetValue(newValue);
                  if (!flag)
                    return;
                  UndoManager.StartUndoRedo();
                  return;
                }
              }
            }
            if (this.bSaveCpgSuccessful)
            {
              if (this.deviceFromServer != null || this.templateFromServer != null)
              {
                this.DeviceFromServer = (APXRadio) null;
                this.TemplateFromServer = (APXTemplate) null;
                File.Delete(docFilePath);
                UtilityMack.bOpenFromRMC = false;
                this.CalculateEditabilityforNonEditableFieldsinRMC();
                ((App) System.Windows.Application.Current).TheDocument.FileSaveAsSafely(fileName, header);
                this.FrameCenterTop.Navigate(new Uri(FeatureManager.GetFeature(2049).UIPagePath, UriKind.RelativeOrAbsolute));
              }
              if (!(bool) System.Windows.Application.Current.Properties[(object) "CommandLineCPS"])
                MruFiles.UpdateMRU(fileName);
              UndoManager.Reset();
              this.SetTitleBar(new FileInfo(fileName).Name, (string) null);
              ((App) System.Windows.Application.Current).TheDocument.docFilePath = fileName;
              if (this.dvrsMsuDataSync != null)
                this.dvrsMsuDataSync.ExportToXmlDoc($"{this.defaultDVRSFileLocation}\\{this.dvrsMsuDataSync.BuildFileName()}");
            }
          }
        }
        if (!flag)
          return;
        UndoManager.StartUndoRedo();
      }
      else
        AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, AppResources.Unable_to_save_Codeplug_Permission_denied);
    }
    catch (Exception ex)
    {
      if (newValue != "")
        radioInformation.General.RadInfoGeneralCodeplugVersion_A7683_UIValue = newValue;
      AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, ex.Message);
      UndoManager.StartUndoRedo();
    }
  }

  public void OnAppMenuSaveAsNonGUI(object sender, RoutedEventArgs e, string sFileName)
  {
    string str = "";
    Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation radioInformation = (Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation) null;
    try
    {
      if (!this.SaveCodeplug(true))
        return;
      AcpFileHeader header = WindowMain.GetHeader();
      if (sFileName == null)
        return;
      radioInformation = FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation;
      str = radioInformation.General.RadInfoGeneralCodeplugVersion_A7683_UIValue;
      Motorola.MackinawCPS.CoreFeatures.DVRSWide.DVRSWide dvrsWide = FeatureManager.GetFeature(4142)[0] as Motorola.MackinawCPS.CoreFeatures.DVRSWide.DVRSWide;
      if (dvrsWide.General.RadErgoWideDigitalVehicularRepeaterSystemDVRSHardwareEnable_A7911.Value)
      {
        if (!AppInfoManager.InvalidFieldsReport.UiHasFields)
        {
          this.dvrsMsuDataSync = new DvrsMsuDataSync();
          uint hashCode = this.dvrsMsuDataSync.CalculateHashCode();
          dvrsWide.General.DVRSWideLabtoolDVRSSyncFieldsHash_A41811.SetValue((long) hashCode);
        }
        else
          AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, AppResources.Export_DVRS_MSU_Data_Failed_The_Codeplug_Contains_Invalid_Fields);
      }
      this.ResetOOBEField();
      if (!sFileName.EndsWith(".mc"))
        return;
      radioInformation.General.RadInfoGeneralCodeplugVersion_A7683.SetValue(this.cpsVersion);
      radioInformation.Labtool.RadInfoLabtoolSecurePartitionVersionNumber_A9076.SetValue(this.cpsVersion);
      header.VersionNumber = this.cpsVersion;
      ((App) System.Windows.Application.Current).TheDocument.FileSaveAsSafely(sFileName, header);
    }
    catch (Exception ex)
    {
      if (str != "")
        radioInformation.General.RadInfoGeneralCodeplugVersion_A7683_UIValue = str;
      AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, ex.Message);
    }
  }

  public void SavePBAFileNonGUI(object sender, RoutedEventArgs e, string sFileName)
  {
    string str = "";
    Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation radioInformation = (Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation) null;
    try
    {
      if (!this.SaveCodeplug(true))
        return;
      WindowMain.GetHeader();
      if (sFileName == null)
        return;
      radioInformation = FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation;
      str = radioInformation.General.RadInfoGeneralCodeplugVersion_A7683_UIValue;
      this.ResetOOBEField();
      if (!sFileName.EndsWith(".xpba"))
        return;
      radioInformation.General.RadInfoGeneralCodeplugVersion_A7683.SetValue(this.cpsVersion);
      radioInformation.Labtool.RadInfoLabtoolSecurePartitionVersionNumber_A9076.SetValue(this.cpsVersion);
      this.bSaveCpgSuccessful = Cruncher.Instance.PackXPBA(sFileName, radioInformation.General.RadInfoGeneralModelNumber_A8539_UIValue);
    }
    catch (Exception ex)
    {
      if (str != "")
        radioInformation.General.RadInfoGeneralCodeplugVersion_A7683_UIValue = str;
      AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, ex.Message);
      if (ex.Message == AppResources.Codeplug_Exceeds_Size_Limit_On_Write)
        throw new CommonException(AppResources.Codeplug_Exceeds_Size_Limit_On_Write);
    }
  }

  public void OnFPSAppMenuSaveAs(object sender, RoutedEventArgs e, string sFileName)
  {
    string str = "";
    Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation radioInformation = (Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation) null;
    try
    {
      AcpUI.Common.Utility.SaveFieldWithFocus();
      if (!this.SaveCodeplug())
        return;
      AcpFileHeader header = WindowMain.GetHeader();
      if (sFileName == null)
        return;
      radioInformation = FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation;
      str = radioInformation.General.RadInfoGeneralCodeplugVersion_A7683_UIValue;
      if (sFileName.EndsWith(".mc"))
      {
        radioInformation.General.RadInfoGeneralCodeplugVersion_A7683.SetValue(this.cpsVersion);
        radioInformation.Labtool.RadInfoLabtoolSecurePartitionVersionNumber_A9076.SetValue(this.cpsVersion);
        ((App) System.Windows.Application.Current).TheDocument.FileSaveAsSafely(sFileName, header);
      }
      MruFiles.UpdateMRU(sFileName);
    }
    catch (Exception ex)
    {
      if (str != "")
        radioInformation.General.RadInfoGeneralCodeplugVersion_A7683_UIValue = str;
      AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, ex.Message);
    }
  }

  internal void OnAppMenuSave(object sender, RoutedEventArgs e)
  {
    string origCpgVersion = "";
    Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation radioInfo = (Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation) null;
    this.dvrsMsuDataSync = (DvrsMsuDataSync) null;
    try
    {
      AcpUI.Common.Utility.SaveFieldWithFocus();
      if (this.CanSaveCpgFlag)
      {
        string docFileName = ((App) System.Windows.Application.Current).TheDocument.docFileName;
        if (string.IsNullOrEmpty(docFileName))
          this.OnAppMenuSaveAs(sender, e);
        else if ((this.deviceFromServer != null || this.templateFromServer != null || this.IsCxfEditingMode) && this.PromptQuitOnInvalids().Result && !(sender is RMCWnd))
        {
          int num1 = (int) System.Windows.MessageBox.Show(AppResources.The_codeplug_contains_invalid_fields_Please_correct_them_and_try_again, AppResources.Invalid_Fields_Error, MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }
        else
        {
          this.CalculateHashCodeForDVRS();
          this.ResetOOBEField();
          APXCodeplug cp = (APXCodeplug) null;
          bool flag1 = false;
          if (!(sender is RMCWnd))
          {
            if (this.deviceFromServer != null)
            {
              if (this.deviceFromServer.WorkingCodeplug != null)
                cp = this.deviceFromServer.WorkingCodeplug as APXCodeplug;
              MackinawCPS.CommonUtility.PopulatecpAndDeviceColumnsFromDatabaseLayer(cp, (Radio) this.deviceFromServer, PopulateOpeartion.Save);
              flag1 = true;
            }
            else if (this.templateFromServer != null)
            {
              MackinawCPS.CommonUtility.PopulateTemplateColumnsFromDatabaseLayer(this.templateFromServer);
              flag1 = true;
            }
          }
          if ((this.deviceFromServer != null || this.templateFromServer != null) && ((this.deviceFromServer != null ? 1 : (this.templateFromServer != null ? 1 : 0)) & (flag1 ? 1 : 0)) == 0 && !(sender is RMCWnd))
            return;
          if ((this.deviceFromServer != null || this.templateFromServer != null) && !(sender is RMCWnd))
          {
            APXTemplate apxTemplate = new APXTemplate();
            APXTemplate template = this.deviceFromServer == null ? this.templateFromServer : this.deviceFromServer.WorkingCodeplug.Template as APXTemplate;
            System.Collections.Generic.List<ASTROVoiceAnnouncement> templateVoiceFiles = new System.Collections.Generic.List<ASTROVoiceAnnouncement>();
            foreach (ASTROVoiceAnnouncement voiceAnnouncement in template.ASTROVoiceAnnouncements)
              templateVoiceFiles.Add(voiceAnnouncement);
            VAHelper.UpdateVAContent(templateVoiceFiles, template);
            System.Collections.Generic.List<ASTROCACertificates> templateCACertificateFiles = new System.Collections.Generic.List<ASTROCACertificates>();
            foreach (ASTROCACertificates astrocaCertificate in template.ASTROCACertificates)
              templateCACertificateFiles.Add(astrocaCertificate);
            CACertificatesHelper.UpdateCACertificateContent(templateCACertificateFiles, template);
            System.Collections.Generic.List<ASTRODVRSFiles> templateDVRSFiles = new System.Collections.Generic.List<ASTRODVRSFiles>();
            foreach (ASTRODVRSFiles astrodvrsFile in template.ASTRODVRSFiles)
              templateDVRSFiles.Add(astrodvrsFile);
            DVRSFilesHelper.UpdateDVRSFilesContent(templateDVRSFiles, template);
            LanguagePackHelper.UpdateLanguageRefence(template);
            if ((this.deviceFromServer != null || this.templateFromServer != null) && this.PromptQuitOnInvalids().Result && !(sender is RMCWnd))
            {
              int num2 = (int) System.Windows.MessageBox.Show(AppResources.The_codeplug_contains_invalid_fields_Please_correct_them_and_try_again, AppResources.Invalid_Fields_Error, MessageBoxButton.OK, MessageBoxImage.Exclamation);
              return;
            }
          }
          if (!this.SaveCodeplug(sender is RMCWnd))
            return;
          bool flag2 = UndoManager.StopUndoRedo();
          string docFilePath = ((App) System.Windows.Application.Current).TheDocument.docFilePath;
          AcpFileHeader header = WindowMain.GetHeader();
          if (docFilePath != null)
          {
            radioInfo = FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation;
            origCpgVersion = radioInfo.General.RadInfoGeneralCodeplugVersion_A7683_UIValue;
            this.CalculateHashCodeForDVRS();
            this.ResetOOBEField();
            if (docFilePath.EndsWith(".mc"))
            {
              radioInfo.General.RadInfoGeneralCodeplugVersion_A7683.SetValue(this.cpsVersion);
              radioInfo.Labtool.RadInfoLabtoolSecurePartitionVersionNumber_A9076.SetValue(this.cpsVersion);
              header.VersionNumber = this.cpsVersion;
              this.bSaveCpgSuccessful = ((App) System.Windows.Application.Current).TheDocument.FileSaveAsSafely(docFilePath, header);
              if (this.bSaveCpgSuccessful)
              {
                if (sender is RMCWnd && this.deviceFromServer == null && this.templateFromServer == null)
                {
                  int num3 = UtilityMack.bOpenFromRMC ? 1 : 0;
                  UtilityMack.bOpenFromRMC = false;
                  this.CalculateValidityforNonEditableFieldsinRMC();
                  UtilityMack.bOpenFromRMC = num3 != 0;
                  ((App) System.Windows.Application.Current).TheDocument.FileSaveAsSafely(docFilePath, header);
                }
                else if (this.deviceFromServer != null || this.templateFromServer != null)
                {
                  if (!(sender is RMCWnd))
                  {
                    try
                    {
                      byte[] fileContent;
                      using (FileStream input = new FileStream(docFilePath, FileMode.Open))
                      {
                        using (BinaryReader binaryReader = new BinaryReader((Stream) input))
                          fileContent = binaryReader.ReadBytes(Convert.ToInt32(input.Length));
                      }
                      if (RMCExportInterface.GetInstance().SaveCodeplugToServer(fileContent, (Radio) this.deviceFromServer, (Motorola.CommonCPS.Server.EntityModel.Template) this.templateFromServer) is APXTemplate server)
                      {
                        this.deviceFromServer = (APXRadio) null;
                        this.templateFromServer = server;
                        string str1 = "Server Archive - ";
                        string str2 = this.deviceFromServer == null ? str1 + $"{this.templateFromServer.ModelNumber}.{Guid.NewGuid()}" : str1 + $"{this.deviceFromServer.SerialNumber}.{Guid.NewGuid()}";
                        string str3 = $"{Path.GetTempPath()}{str2}.mc";
                        if (File.Exists(docFilePath))
                        {
                          File.Delete(docFilePath);
                          ((App) System.Windows.Application.Current).TheDocument.FileSaveAsSafely(str3, header);
                        }
                        this.SetTitleBar(new FileInfo(str3).Name, (string) null);
                        ((App) System.Windows.Application.Current).TheDocument.docFilePath = str3;
                      }
                    }
                    catch (Exception ex)
                    {
                      this.bSaveCpgSuccessful = false;
                      throw;
                    }
                  }
                }
              }
            }
            else if (docFileName.EndsWith(".xpba"))
            {
              radioInfo.General.RadInfoGeneralCodeplugVersion_A7683.SetValue(this.cpsVersion);
              radioInfo.Labtool.RadInfoLabtoolSecurePartitionVersionNumber_A9076.SetValue(this.cpsVersion);
              this.bSaveCpgSuccessful = Cruncher.Instance.PackXPBA(docFilePath, radioInfo.General.RadInfoGeneralModelNumber_A8539_UIValue);
            }
            else if (docFileName.EndsWith(".cxf", StringComparison.OrdinalIgnoreCase))
            {
              radioInfo.General.RadInfoGeneralCodeplugVersion_A7683.SetValue(this.cpsVersion);
              radioInfo.Labtool.RadInfoLabtoolSecurePartitionVersionNumber_A9076.SetValue(this.cpsVersion);
              header.VersionNumber = this.cpsVersion;
              this.bSaveCpgSuccessful = SaveCxfHandler.SaveCodeplugFile(docFilePath, CxfFileHandler.currentlyOpenedCxfFilePass, radioInfo.General.RadInfoGeneralModelNumber_A8539.Value, this.cpsVersion, radioInfo.General.RadInfoGeneralFirmwareVersion_A8124.Value);
              if (this.bSaveCpgSuccessful)
                ((MackCPSDocument) ((App) System.Windows.Application.Current).TheDocument).resetDirty();
            }
            if (this.bSaveCpgSuccessful && !(bool) System.Windows.Application.Current.Properties[(object) "CommandLineCPS"])
            {
              UndoManager.Reset();
              if (this.dvrsMsuDataSync != null)
                this.dvrsMsuDataSync.ExportToXmlDoc($"{this.defaultDVRSFileLocation}\\{this.dvrsMsuDataSync.BuildFileName()}");
            }
          }
          if (!flag2)
            return;
          UndoManager.StartUndoRedo();
        }
      }
      else
        AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, AppResources.Unable_to_save_Codeplug_Permission_denied);
    }
    catch (Exception ex)
    {
      WindowMain.HandleSaveCodeplugException(origCpgVersion, radioInfo, ex);
    }
    finally
    {
      UndoManager.StartUndoRedo();
    }
  }

  private Motorola.MackinawCPS.CoreFeatures.DVRSWide.DVRSWide CalculateHashCodeForDVRS()
  {
    Motorola.MackinawCPS.CoreFeatures.DVRSWide.DVRSWide hashCodeForDvrs = FeatureManager.GetFeature(4142)[0] as Motorola.MackinawCPS.CoreFeatures.DVRSWide.DVRSWide;
    if (hashCodeForDvrs.General.RadErgoWideDigitalVehicularRepeaterSystemDVRSHardwareEnable_A7911.Value)
    {
      if (!AppInfoManager.InvalidFieldsReport.UiHasFields)
      {
        this.dvrsMsuDataSync = new DvrsMsuDataSync();
        uint hashCode = this.dvrsMsuDataSync.CalculateHashCode();
        hashCodeForDvrs.General.DVRSWideLabtoolDVRSSyncFieldsHash_A41811.SetValue((long) hashCode);
      }
      else
        AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, AppResources.Export_DVRS_MSU_Data_Failed_The_Codeplug_Contains_Invalid_Fields);
    }
    else
      hashCodeForDvrs.General.DVRSWideLabtoolDVRSSyncFieldsHash_A41811.ResetToDefault();
    return hashCodeForDvrs;
  }

  private static void HandleSaveCodeplugException(
    string origCpgVersion,
    Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation radioInfo,
    Exception ex)
  {
    if (origCpgVersion != "")
      radioInfo.General.RadInfoGeneralCodeplugVersion_A7683_UIValue = origCpgVersion;
    if (ex is CommonException commonException)
    {
      if (commonException.ErrorCode == SpecialFeatures.CommonExceptionHelper.DirectMsgCode)
      {
        AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, commonException.Message);
      }
      else
      {
        if (commonException.Message == AppResources.Codeplug_Exceeds_Size_Limit_On_Write)
        {
          AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, ex.Message);
          throw new CommonException(AppResources.Codeplug_Exceeds_Size_Limit_On_Write);
        }
        AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, Motorola.CommonCPS.ResourceRepository.ResourceHelper.GetCommonErrorMessageByID(commonException.ErrorCode.ToString()));
      }
    }
    else
      AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, ex.Message);
  }

  internal void OnPublish(object sender, RoutedEventArgs e)
  {
    string origCpgVersion = "";
    Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation radioInfo = (Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation) null;
    this.dvrsMsuDataSync = (DvrsMsuDataSync) null;
    try
    {
      AcpUI.Common.Utility.SaveFieldWithFocus();
      if (this.CanSaveCpgFlag)
      {
        string docFileName = ((App) System.Windows.Application.Current).TheDocument.docFileName;
        if (this.PromptQuitOnInvalids().Result)
        {
          int num = (int) System.Windows.MessageBox.Show(AppResources.The_codeplug_contains_invalid_fields_Please_correct_them_and_try_again, AppResources.Invalid_Fields_Error, MessageBoxButton.OK, MessageBoxImage.Exclamation);
          return;
        }
        if (this.SaveCodeplug(sender is RMCWnd))
        {
          int num = UndoManager.StopUndoRedo() ? 1 : 0;
          string docFilePath = ((App) System.Windows.Application.Current).TheDocument.docFilePath;
          AcpFileHeader header = WindowMain.GetHeader();
          if (docFilePath != null)
          {
            radioInfo = FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation;
            origCpgVersion = radioInfo.General.RadInfoGeneralCodeplugVersion_A7683_UIValue;
            this.CalculateHashCodeForDVRS();
            this.ResetOOBEField();
            if (this.IsCloudNativeMode)
            {
              radioInfo.General.RadInfoGeneralCodeplugVersion_A7683.SetValue(this.cpsVersion);
              radioInfo.Labtool.RadInfoLabtoolSecurePartitionVersionNumber_A9076.SetValue(this.cpsVersion);
              header.VersionNumber = this.cpsVersion;
              this.bSaveCpgSuccessful = App.CloudNativeUtility.SaveCodeplugBytes(radioInfo.General.RadInfoGeneralModelNumber_A8539.Value, this.cpsVersion, radioInfo.General.RadInfoGeneralFirmwareVersion_A8124.Value);
              if (this.bSaveCpgSuccessful)
                ((MackCPSDocument) ((App) System.Windows.Application.Current).TheDocument).resetDirty();
            }
            if (this.bSaveCpgSuccessful && !(bool) System.Windows.Application.Current.Properties[(object) "CommandLineCPS"])
            {
              UndoManager.Reset();
              if (this.dvrsMsuDataSync != null)
                this.dvrsMsuDataSync.ExportToXmlDoc($"{this.defaultDVRSFileLocation}\\{this.dvrsMsuDataSync.BuildFileName()}");
            }
          }
          if (num != 0)
            UndoManager.StartUndoRedo();
        }
      }
      else
        AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, AppResources.Unable_to_save_Codeplug_Permission_denied);
      if (!this.bSaveCpgSuccessful || !this.IsCloudNativeMode)
        return;
      WindowMain.Publish();
      if (string.IsNullOrEmpty(CloudNativeParameters.CloudNativeJobWrapper.NewTemplateName))
        return;
      this.SetTitleBar(CloudNativeParameters.CloudNativeJobWrapper.NewTemplateName, (string) null);
    }
    catch (Exception ex)
    {
      WindowMain.HandleSaveCodeplugException(origCpgVersion, radioInfo, ex);
    }
    finally
    {
      UndoManager.StartUndoRedo();
    }
  }

  private static void Publish()
  {
    try
    {
      if (!WindowMain.PostToRcCpsBridge())
        return;
      WindowMain.LaunchBrowser();
    }
    catch
    {
      int num = (int) System.Windows.MessageBox.Show(AppResources.RcCpsPublishFailed);
    }
  }

  private static bool PostToRcCpsBridge()
  {
    NewTemplateName newTemplateName = new NewTemplateName(CloudNativeParameters.CloudNativeJobWrapper.NewTemplateName);
    newTemplateName.ShowDialog();
    if (newTemplateName.UserCanceled)
      return false;
    string encryptedPassword = (string) null;
    try
    {
      encryptedPassword = CloudNativeCipher.Encrypt(CloudNativeParameters.CloudNativeJobWrapper.CxfPassword);
    }
    catch (InvalidCipherTextException ex)
    {
      throw ex;
    }
    CloudNativeParameters.CloudNativeJobWrapper.NewTemplateName = newTemplateName.UserEnteredNewTemplateName;
    Task<bool> task = System.Threading.Tasks.Task.Run<bool>((Func<Task<bool>>) (() => App.CloudNativeUtility.PostResultAsync(encryptedPassword)));
    task.Wait();
    if (task.Result)
      return true;
    throw new Exception("Failed to communicate with RC-CPS Bridge");
  }

  private static bool LaunchBrowser()
  {
    string callbackUrl = CloudNativeParameters.CloudNativeJobWrapper.TemplateDetails.CallbackUrl;
    string sessionId = CloudNativeParameters.CloudNativeJobWrapper.SessionId;
    if (Process.Start(new ProcessStartInfo()
    {
      UseShellExecute = false,
      CreateNoWindow = true,
      FileName = "cmd",
      Arguments = $"/c start {callbackUrl}?cpsImport={sessionId}"
    }) != null)
      return true;
    throw new Exception("Failed to launch browser window");
  }

  internal static AcpFileHeader GetHeader()
  {
    AcpFileHeader header = new AcpFileHeader();
    if (FeatureManager.GetFeature(2049) is RadioInformationRecset feature)
    {
      Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation radioInformation = feature[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation;
      header.ModelNumber = radioInformation.General.RadInfoGeneralModelNumber_A8539.ToString();
      header.SerialNumber = radioInformation.General.RadInfoGeneralSerialNumber_A9122.ToString();
      header.FlashCode = radioInformation.FLASHport.RadInfoFLASHportFLASHcode_A8132.ToString();
      header.VersionNumber = radioInformation.General.RadInfoGeneralCodeplugVersion_A7683.ToString();
    }
    return header;
  }

  private bool ContainsZoneAssignementsWithZoneCloneEnabled()
  {
    return this.GetZoneCloneEnabledFields().Count<IAcpField>() > 0;
  }

  private bool XmlContainsZoneCloneEnabledZones(XmlDocument doc)
  {
    XmlNode lastChild = doc.ChildNodes[1].LastChild;
    string str = "true";
    string xpath = $"//Recset[@Name='{AcgResources.ID_ZONECHANNELASSIGNMENT}']";
    XmlNode xmlNode = lastChild.SelectSingleNode(xpath);
    if (xmlNode != null)
    {
      foreach (object selectNode in xmlNode.SelectNodes($"//Field[@Name='{AcgResources.ID_CLONEENABLE}']"))
      {
        string innerText = (selectNode as XmlElement).InnerText;
        if (innerText != null && str.Equals(innerText.ToLower()))
          return true;
      }
    }
    return false;
  }

  private IEnumerable<IAcpField> GetZoneCloneEnabledFields()
  {
    System.Collections.Generic.List<IAcpField> cloneEnabledFields = new System.Collections.Generic.List<IAcpField>();
    if (!(FeatureManager.GetFeature(2051) is ZoneChannelAssignmentRecset feature))
      return (IEnumerable<IAcpField>) cloneEnabledFields;
    foreach (AcpBusinessLayer.FeatureNode featureNode in (Collection<AcpBusinessLayer.FeatureNode>) feature)
    {
      Zone zone = (featureNode as Motorola.MackinawCPS.CoreFeatures.ZoneChannelAssignment.ZoneChannelAssignment).Zone;
      if (zone.ZnChanCfgZoneZoneCloningEnable_43119.Value)
        cloneEnabledFields.Add((IAcpField) zone.ZnChanCfgZoneZoneCloningEnable_43119);
    }
    return (IEnumerable<IAcpField>) cloneEnabledFields;
  }

  internal void OnAppMenuImport(object sender, RoutedEventArgs e)
  {
    AcpUI.Common.Utility.SaveFieldWithFocus();
    if (AppInfoManager.ImportExportFieldsReport != null)
      AppInfoManager.ImportExportFieldsReport.Clear();
    if (this.cpgOpenFlag)
    {
      if (this.CanSaveCpgFlag)
      {
        AcpUI.Common.Utility.SaveFieldWithFocus();
        AcpOpenFileDialog acpOpenFileDialog = new AcpOpenFileDialog();
        acpOpenFileDialog.Filter = AppResources.Xml_files_Filter;
        acpOpenFileDialog.MultiSelect = false;
        if (!acpOpenFileDialog.ShowDialog().GetValueOrDefault())
          return;
        string fileName = acpOpenFileDialog.FileName;
        if (fileName == null)
          return;
        if (fileName.EndsWith(".xml"))
        {
          AppInfoManager.InvalidFieldsReport.SuppressReportDisplay = true;
          AcpUIDialogWindow<string> acpUiDialogWindow = (AcpUIDialogWindow<string>) null;
          try
          {
            XmlDocument xmlDocument = ((App) System.Windows.Application.Current).TheDocument.GetXmlDocument(fileName);
            int num = this.ContainsZoneAssignementsWithZoneCloneEnabled() ? 1 : 0;
            ZoneChannelAssignmentRecset assignmentRecset = (ZoneChannelAssignmentRecset) null;
            bool flag = false;
            if (num != 0)
            {
              assignmentRecset = FeatureManager.GetFeature(2051) as ZoneChannelAssignmentRecset;
              flag = assignmentRecset.HiddenStatic;
              assignmentRecset.HiddenStatic = true;
            }
            bool isClonableZone = this.XmlContainsZoneCloneEnabledZones(xmlDocument);
            if (isClonableZone)
              WindowMain.BlockNodesIfImportFileHasClonableZone(xmlDocument);
            PageFunctionImportExport page = new PageFunctionImportExport(xmlDocument);
            page.SetImportProcess((IAcpBatchOperation) this);
            page.InitializeElemetsForClonableZones(isClonableZone);
            page.Background = (Brush) this.TryFindResource((object) new ComponentResourceKey(this.FrameCenterTop.GetType(), (object) AcpColorKeys.FrameContentAreaPopupDialogueBackground));
            acpUiDialogWindow = new AcpUIDialogWindow<string>((PageFunction<string>) page, (string) null);
            acpUiDialogWindow.Width = 500.0;
            acpUiDialogWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            acpUiDialogWindow.ResizeMode = ResizeMode.NoResize;
            acpUiDialogWindow.Show();
            acpUiDialogWindow.Focus();
            acpUiDialogWindow.Hide();
            acpUiDialogWindow.ShowDialog();
            if (num != 0)
            {
              assignmentRecset.HiddenStatic = flag;
              foreach (IAcpField cloneEnabledField in this.GetZoneCloneEnabledFields())
                AppInfoManager.ImportExportFieldsReport.RegisterFieldInReport(cloneEnabledField, AppResources.Current_Codeplug_Contains_Zone_Clone_Enabled, false);
              AppInfoManager.ImportExportFieldsReport.FieldsReportChanged = true;
            }
            if (isClonableZone)
            {
              AppInfoManager.ImportExportFieldsReport.RegisterFieldInReport((IAcpField) null, AppResources.Imported_Xml_Cointains_Zone_Clone_Enabled, false);
              AppInfoManager.ImportExportFieldsReport.FieldsReportChanged = true;
            }
            if (FeatureManager.GetFeature(2033)[0] is Motorola.MackinawCPS.CoreFeatures.RadioErgonomicsWide.RadioErgonomicsWide radioErgonomicsWide)
            {
              radioErgonomicsWide.Advanced.RadErgoWideAdvancedLongKeypressDurationforEmergencyms_A8451.CalculateEditability();
              radioErgonomicsWide.Advanced.RadErgoWideAdvancedShortKeypressDurationforEmergencyms_A9126.CalculateEditability();
            }
            this.ImportFixUpForRadWideBluetoothPairingType(xmlDocument);
          }
          catch (Exception ex)
          {
            AppInfoManager.ImportExportFieldsReport.RegisterFieldInReport((IAcpField) null, AppResources.Cannot_import_file + fileName, false);
            AppInfoManager.ImportExportFieldsReport.FieldsReportChanged = true;
            acpUiDialogWindow?.Close();
          }
          AppInfoManager.InvalidFieldsReport.SuppressReportDisplay = false;
        }
        else
        {
          AppInfoManager.ImportExportFieldsReport.RegisterFieldInReport((IAcpField) null, $"{AppResources.Cannot_import_file} {fileName} {AppResources._InValid_file_type}", false);
          AppInfoManager.ImportExportFieldsReport.FieldsReportChanged = true;
        }
      }
      else
      {
        AppInfoManager.ImportExportFieldsReport.RegisterFieldInReport((IAcpField) null, AppResources.Import_failed_Permission_denied, false);
        AppInfoManager.ImportExportFieldsReport.FieldsReportChanged = true;
      }
    }
    else
    {
      AppInfoManager.ImportExportFieldsReport.RegisterFieldInReport((IAcpField) null, AppResources.Open_Codeplug_First, false);
      AppInfoManager.ImportExportFieldsReport.FieldsReportChanged = true;
    }
  }

  private static void BlockNodesIfImportFileHasClonableZone(XmlDocument document)
  {
    XmlNode lastChild = document.ChildNodes[1].LastChild;
    WindowMain.BlockSpecificNode(lastChild, AcgResources.ID_RADIOWIDE);
    WindowMain.BlockSpecificNode(lastChild, AcgResources.ID_MPLCONFIGURATION);
    WindowMain.BlockSpecificNode(lastChild, AcgResources.ID_ASTROTALKGROUPLIST);
    WindowMain.BlockSpecificNode(lastChild, AcgResources.ID_ZONECHANNELASSIGNMENT);
    WindowMain.BlockSpecificNode(lastChild, AcgResources.ID_CONVENTIONALSYSTEM);
    WindowMain.BlockSpecificNode(lastChild, AcgResources.ID_CONVENTIONALPERSONALITY);
  }

  private static void BlockSpecificNode(XmlNode root, string nodeName)
  {
    XmlNode oldChild = root.SelectSingleNode($"//Recset[@Name='{nodeName}']");
    if (oldChild == null)
      return;
    root.RemoveChild(oldChild);
  }

  internal void OnAppMenuExport(object sender, RoutedEventArgs e)
  {
    AcpUI.Common.Utility.SaveFieldWithFocus();
    PageFunctionImportExport page = new PageFunctionImportExport();
    AcpUIDialogWindow<string> acpUiDialogWindow = new AcpUIDialogWindow<string>((PageFunction<string>) page, (string) null);
    page.Background = (Brush) this.TryFindResource((object) new ComponentResourceKey(this.FrameCenterTop.GetType(), (object) AcpColorKeys.FrameContentAreaPopupDialogueBackground));
    acpUiDialogWindow.Width = 500.0;
    acpUiDialogWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
    acpUiDialogWindow.ResizeMode = ResizeMode.NoResize;
    acpUiDialogWindow.Show();
    acpUiDialogWindow.Focus();
    acpUiDialogWindow.Hide();
    acpUiDialogWindow.ShowDialog();
  }

  internal void OnAppMenuClose(object sender, RoutedEventArgs e)
  {
    AcpUI.Common.Utility.SaveFieldWithFocus();
    AcpDocument theDocument = ((App) System.Windows.Application.Current).TheDocument;
    if (AppInfoManager.AppMode == ApplicationMode.CodeplugComparisonMode)
      this.OnRibbonBarCompCodeplug(sender, (RoutedEventArgs) null);
    bool flag = true;
    MessageBoxResult messageBoxResult = MessageBoxResult.None;
    string docFilePath = ((App) System.Windows.Application.Current).TheDocument.docFilePath;
    theDocument.docFileName = Path.GetFileName(docFilePath);
    string docFileName = ((App) System.Windows.Application.Current).TheDocument.docFileName;
    if (theDocument.IsDirty)
    {
      messageBoxResult = MyMessageBox.Show(AppResources.Save_changes_to_file.AcpStringFormat((object) docFileName), AppResources.APX_CPS, MessageBoxButton.YesNoCancel, MessageBoxImage.Exclamation, MessageBoxResult.Yes);
      switch (messageBoxResult)
      {
        case MessageBoxResult.Cancel:
          flag = false;
          break;
        case MessageBoxResult.Yes:
          this.bSaveCpgSuccessful = false;
          if (docFilePath != null && (File.GetAttributes(docFilePath) & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
            this.OnAppMenuSaveAs(sender, e);
          else
            this.OnAppMenuSave(sender, e);
          if (this.bSaveCpgSuccessful)
          {
            this.CloseFile();
            break;
          }
          flag = false;
          break;
        case MessageBoxResult.No:
          this.CloseFile();
          break;
      }
    }
    else
      this.CloseFile();
    if (this.IsCxfEditingMode && !flag)
      return;
    if (FlashDataManager.FlashDoc != null & flag)
      FlashDataManager.FlashDoc.Clear();
    if (messageBoxResult != MessageBoxResult.Cancel)
      this.SetTitleBar((string) null, (string) null);
    this.WindowMain_AllowDrop((object) null, (System.Windows.Input.MouseEventArgs) null);
  }

  internal void CloseFile()
  {
    AcpDocument theDocument = ((App) System.Windows.Application.Current).TheDocument;
    string path = string.Empty;
    this.isDnDorImpDoneBeforeTheOper = false;
    if (theDocument != null)
    {
      theDocument.ModificationLogEnabled = false;
      theDocument.FileClose();
      if (((App) System.Windows.Application.Current).TheDocument.docFilePath != null)
      {
        path = ((App) System.Windows.Application.Current).TheDocument.docFilePath;
        try
        {
          if ((Path.GetPathRoot(path) + Path.GetFileName(path)).Equals(path))
          {
            this.lastOpenCodePlugPath = Path.GetPathRoot(path);
          }
          else
          {
            this.lastOpenCodePlugPath = Path.GetDirectoryName(((App) System.Windows.Application.Current).TheDocument.docFilePath);
            if (this.lastOpenCodePlugPath != null)
            {
              if ((int) this.lastOpenCodePlugPath[this.lastOpenCodePlugPath.Length - 1] != (int) Path.DirectorySeparatorChar)
                this.lastOpenCodePlugPath += Path.DirectorySeparatorChar.ToString();
            }
          }
        }
        catch
        {
        }
      }
      ((App) System.Windows.Application.Current).TheDocument.docFileName = (string) null;
      ((App) System.Windows.Application.Current).TheDocument.docFilePath = (string) null;
    }
    WindowMain mainWindow = (WindowMain) System.Windows.Application.Current.MainWindow;
    mainWindow.CpgOpenFlag = false;
    this.IsFreonProduct = false;
    WiFiPasswordUtil.ResetSessionTimer();
    UndoManager.Reset();
    AcpExpStatusManager.Clear();
    this.ribbonBarPanelCodeplug.RestoreAllCollapsed();
    AppInfoManager.ClearNavigationHistory = true;
    mainWindow.FrameCenterTop.Navigate(new Uri("HomeBase/PageWelcome.xaml", UriKind.RelativeOrAbsolute));
    PageNavPaneButtons content = (PageNavPaneButtons) mainWindow.FrameLeft.Content;
    content.FrameCodeplug.Content = (object) null;
    content.ButtonHome.IsSelected = true;
    this.FindToken.Text = string.Empty;
    AppInfoManager.ClearNavigationHistory = true;
    this.ClearEventWindows();
    this.objModelTiering = (ModelTiering) null;
    if (this.deviceFromServer != null || this.templateFromServer != null)
    {
      try
      {
        File.Delete(path);
      }
      catch
      {
      }
      this.DeviceFromServer = (APXRadio) null;
      this.TemplateFromServer = (APXTemplate) null;
      UtilityMack.bOpenFromRMC = false;
    }
    if (this.IsCxfEditingMode)
    {
      UtilityMack.isInCxfEditingMode = false;
      this.IsCxfEditingMode = false;
    }
    if (AppInfoManager.AppMode == ApplicationMode.CodeplugConfigurationMode && this.bUnlimitedKeyLoaded)
      this.AppMenuWriteProtect.IsEnabled = true;
    MemoryCleaner.CleanGarbageFromMemory();
  }

  private void ClearEventWindows()
  {
    PageStatusBar content = (PageStatusBar) ((WindowMain) System.Windows.Application.Current.MainWindow).FrameStatusBar.Content;
    content.CodeplugIdentifier = (string) null;
    content.RadioModel = (string) null;
    content.SerialNum = (string) null;
    content.Status = AppResources.READY_ID;
    this.MultiCodeplugInfo = (MultiCodeplugInfo) null;
    if (AppInfoManager.FindResultReport != null)
      AppInfoManager.FindResultReport.Clear();
    if (AppInfoManager.ImportExportFieldsReport != null)
      AppInfoManager.ImportExportFieldsReport.Clear();
    if (AppInfoManager.DragAndDropFieldsReport != null)
      AppInfoManager.DragAndDropFieldsReport.Clear();
    if (AppInfoManager.StatusMsgReport != null)
      AppInfoManager.StatusMsgReport.Clear();
    this.pageIUI.RefreshSelectedEventWindow();
  }

  internal void OnAppMenuExit(object sender, RoutedEventArgs e)
  {
    WindowMain.WINDOWPLACEMENT lpwndpl = new WindowMain.WINDOWPLACEMENT();
    WindowMain.NativeMethods.GetWindowPlacement(new WindowInteropHelper((Window) this).Handle, out lpwndpl);
    Settings.Default.WindowPlacement = lpwndpl;
    Settings.Default.SizeStored = true;
    Settings.Default.Save();
    this.onExitApp((object) this, new CancelEventArgs());
  }

  internal void OnQATUndo(object sender, RoutedEventArgs e)
  {
    if (!UndoManager.CanUndo || !AppInfoManager.CurrentModeSupportsUndo)
      return;
    AcpUI.Common.Utility.SaveFieldWithFocus();
    if (!UndoManager.Undo())
    {
      int num = (int) System.Windows.MessageBox.Show(AppResources.Unexpected_error_Operation_cannot_be_undone);
    }
    if (Environment.OSVersion.Version.Major != 5)
      ((UIElement) ((WindowMain) System.Windows.Application.Current.MainWindow).FrameLeft.Content).UpdateLayout();
    if (this.isDnDorImpDoneBeforeTheOper)
      this.RefreshZoneChannelRecordsetToolBar();
    this.RefreshURLTable();
  }

  internal void OnQATRedo(object sender, RoutedEventArgs e)
  {
    if (!UndoManager.CanRedo || !AppInfoManager.CurrentModeSupportsUndo)
      return;
    if (!UndoManager.Redo())
    {
      int num = (int) System.Windows.MessageBox.Show(AppResources.Unexpected_Error_Operation_Cannot_Redone);
    }
    this.RefreshURLTable();
  }

  internal void OnRibbonBarWndHideClick(object sender, RoutedEventArgs e)
  {
    AcpCheckBox acpCheckBox = (AcpCheckBox) sender;
    DockWndType dockWindow = this.GetDockWindow(acpCheckBox.Name);
    if (dockWindow == DockWndType.UnKnown)
      return;
    WindowMain mainWindow = (WindowMain) System.Windows.Application.Current.MainWindow;
    bool? isChecked = acpCheckBox.IsChecked;
    bool flag = false;
    if (isChecked.GetValueOrDefault() == flag & isChecked.HasValue)
      mainWindow.pageIUI.OpenDockWindow(dockWindow);
    else
      mainWindow.pageIUI.CloseDockWindow(dockWindow);
  }

  private DockWndType GetDockWindow(string eventName)
  {
    DockWndType dockWindow = DockWndType.UnKnown;
    if (eventName.StartsWith("wndNavigation"))
      dockWindow = DockWndType.Naviagtion;
    else if (eventName.StartsWith("wndErrorList"))
      dockWindow = DockWndType.Output;
    else if (eventName.StartsWith("wndInvalidFields"))
      dockWindow = DockWndType.InvalidFields;
    else if (eventName.StartsWith("wndDnD"))
      dockWindow = DockWndType.DnD;
    else if (eventName.StartsWith("wndImpExp"))
      dockWindow = DockWndType.ImpExp;
    else if (eventName.StartsWith("wndComparator"))
      dockWindow = DockWndType.Comparator;
    else if (eventName.StartsWith("wndFindResults"))
      dockWindow = DockWndType.FindResults;
    else if (eventName.StartsWith("wndFieldInfo"))
      dockWindow = DockWndType.HelpInfo;
    else if (eventName.StartsWith("wndSysKeyRpt"))
      dockWindow = DockWndType.SysKeyRpt;
    else if (eventName.StartsWith("wndFillUpFillDown"))
      dockWindow = DockWndType.FillUpFillDown;
    return dockWindow;
  }

  internal void OnRibbonBarWndAutoRiseClick(object sender, RoutedEventArgs e)
  {
    AcpCheckBox acpCheckBox = (AcpCheckBox) sender;
    DockWndType dockWindow = this.GetDockWindow(acpCheckBox.Name);
    if (dockWindow == DockWndType.UnKnown)
      return;
    WindowMain mainWindow = (WindowMain) System.Windows.Application.Current.MainWindow;
    bool? isChecked = acpCheckBox.IsChecked;
    if (!isChecked.HasValue)
      return;
    AcpIuiPage pageIui = mainWindow.pageIUI;
    int dwType = (int) dockWindow;
    isChecked = acpCheckBox.IsChecked;
    int num = isChecked.Value ? 1 : 0;
    pageIui.SetDockWindowAutoRise((DockWndType) dwType, num != 0);
  }

  internal void OnRibbonBarShowRtdButtons(object sender, RoutedEventArgs e)
  {
    if (this.CpgOpenFlag)
    {
      if (AppInfoManager.ShowRtdButtons)
      {
        AppInfoManager.ShowRtdButtons = false;
        this.RibbonBarRtdPageRestoreAll.IsEnabled = false;
      }
      else
      {
        AppInfoManager.ShowRtdButtons = true;
        this.RibbonBarRtdPageRestoreAll.IsEnabled = true;
      }
      this.ribbonBarRtdPageRestoreAllIsEnabled = this.RibbonBarRtdPageRestoreAll.IsEnabled;
    }
    else
    {
      int num = (int) System.Windows.MessageBox.Show(AppResources.Open_Codeplug_First);
    }
  }

  internal void OnRibbonBarPageRestoreAll(object sender, RoutedEventArgs e)
  {
    Page content = (Page) ((WindowMain) System.Windows.Application.Current.MainWindow).FrameCenterTop.Content;
    if (!(content is AcpPageFeature))
      return;
    AcpUI.Common.Utility.SaveFieldWithFocus();
    AcpUI.Common.Utility.RestoreAllFields((AcpPageFeature) content);
  }

  internal void OnRibbonBarPageRestoreAllInvalids(object sender, RoutedEventArgs e)
  {
    AcpUI.Common.Utility.RestoreAllInvalidFields();
  }

  private void OnRibbonBarRestoreButtonsGotFoucs(object sender, RoutedEventArgs e)
  {
    this.ribbonBarShowRtdButtonsIsEnabled = this.ribbonBarShowRtdButtons.IsEnabled;
    this.ribbonBarRtdPageRestoreAllIsEnabled = this.RibbonBarRtdPageRestoreAll.IsEnabled;
    Page content = (Page) ((WindowMain) System.Windows.Application.Current.MainWindow).FrameCenterTop.Content;
    this.storedRtdButtonsStatus = false;
    if ((this.ribbonBarShowRtdButtons.IsEnabled || this.RibbonBarRtdPageRestoreAll.IsEnabled) && content != null)
    {
      IAcpRecordset dataContext = (IAcpRecordset) content.DataContext;
      if (dataContext != null && (dataContext.RecsetId == 2300 || AppInfoManager.AppMode == ApplicationMode.CodeplugComparisonMode))
      {
        this.ribbonBarShowRtdButtonsIsEnabled = this.ribbonBarShowRtdButtons.IsEnabled;
        this.ribbonBarRtdPageRestoreAllIsEnabled = this.RibbonBarRtdPageRestoreAll.IsEnabled;
        this.storedRtdButtonsStatus = true;
        this.ribbonBarShowRtdButtons.IsEnabled = false;
        this.RibbonBarRtdPageRestoreAll.IsEnabled = false;
      }
    }
    if (content == null)
      return;
    this.RibbonBarRtdInvalidsRestoreAll.IsEnabled = false;
    IAcpRecordset dataContext1 = (IAcpRecordset) content.DataContext;
    if (dataContext1 == null || AppInfoManager.InvalidFieldsReport == null || !AppInfoManager.InvalidFieldsReport.UiHasFields || dataContext1.RecsetId == 2300)
      return;
    foreach (FieldsReportInfo uiField in AppInfoManager.InvalidFieldsReport.UiFields)
    {
      if (uiField.Field != null && uiField.FieldType == FieldInfoType.Field && ((AcpFieldBase) uiField.Field).AllowsRestore())
      {
        this.RibbonBarRtdInvalidsRestoreAll.IsEnabled = true;
        break;
      }
    }
  }

  private void OnRibbonBarResetPassword(object sender, RoutedEventArgs e)
  {
    ((WindowMain) System.Windows.Application.Current.MainWindow).ResetPassword();
  }

  private void OnRibbonBarRestoreButtonsLostFocus(object sender, RoutedEventArgs e)
  {
    if (!this.storedRtdButtonsStatus)
      return;
    this.ribbonBarShowRtdButtons.IsEnabled = this.ribbonBarShowRtdButtonsIsEnabled;
    this.RibbonBarRtdPageRestoreAll.IsEnabled = this.ribbonBarRtdPageRestoreAllIsEnabled;
    this.storedRtdButtonsStatus = false;
  }

  internal void OnRibbonBarUserViewSelChg(object sender, RoutedEventArgs e)
  {
    if (!(sender is System.Windows.Controls.ComboBox))
      return;
    System.Windows.Controls.ComboBox comboBox = (System.Windows.Controls.ComboBox) sender;
    ComboBoxItem selectedItem = (ComboBoxItem) comboBox.SelectedItem;
    int int32 = Convert.ToInt32(selectedItem.Tag);
    comboBox.ToolTip = (object) null;
    switch (int32)
    {
      case 0:
        AppInfoManager.AppView = DifferentiatedUserViewType.Basic;
        this.currentAppViewInfo = (object) selectedItem;
        break;
      case 1:
        AppInfoManager.AppView = DifferentiatedUserViewType.Intermediate;
        this.currentAppViewInfo = (object) selectedItem;
        break;
      case 2:
        AppInfoManager.AppView = DifferentiatedUserViewType.Full;
        this.currentAppViewInfo = (object) selectedItem;
        break;
      case 3:
        AppInfoManager.AppView = DifferentiatedUserViewType.Secret;
        this.currentAppViewInfo = (object) selectedItem;
        break;
      case 4:
        AppInfoManager.AppView = DifferentiatedUserViewType.Depot;
        this.currentAppViewInfo = (object) selectedItem;
        break;
      case 5:
        AppInfoManager.AppView = DifferentiatedUserViewType.Labtool;
        this.currentAppViewInfo = (object) selectedItem;
        break;
      case 6:
        string sFileName = (string) null;
        if (this.OnRibbonBarBtnLoadCustView(out sFileName))
        {
          AppInfoManager.AppView = DifferentiatedUserViewType.Custom;
          this.customVwPath = sFileName;
          selectedItem.ToolTip = (object) sFileName;
          break;
        }
        this.DiffViewType.SelectedItem = this.currentAppViewInfo;
        break;
    }
    this.URLTableFixup();
  }

  internal bool OnRibbonBarBtnLoadCustView(out string sFileName)
  {
    sFileName = (string) null;
    bool flag = false;
    AcpOpenFileDialog acpOpenFileDialog = new AcpOpenFileDialog();
    acpOpenFileDialog.Filter = AppResources.Custom_Views_Filter;
    acpOpenFileDialog.MultiSelect = false;
    if (acpOpenFileDialog.ShowDialog().GetValueOrDefault())
    {
      sFileName = acpOpenFileDialog.FileName;
      if (sFileName != null)
      {
        if (((App) System.Windows.Application.Current).TheDocument != null)
        {
          if (sFileName.EndsWith(".xml"))
          {
            try
            {
              flag = ((App) System.Windows.Application.Current).TheDocument.ImportFromXml(sFileName, XmlFileType.CustomView);
            }
            catch (Exception ex)
            {
            }
            if (!flag)
            {
              if (AppInfoManager.IsCustomViewLanguageMismatch)
                AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, $"{AppResources.Error_Opening_Custom_View}{sFileName} {AppResources.Not_a_Valid_Custom_View_FileLanguage}");
              else
                AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, $"{AppResources.Error_Opening_Custom_View}{sFileName} {AppResources.Not_a_Valid_Custom_View_File}");
            }
          }
          else
            AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, $"{AppResources.Error_loading_Custom_View}{sFileName} {AppResources.Not_a_Valid_Custom_View_File}");
        }
        else
          AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, AppResources.Error_loading_Custom_View_file_The_codeplug_document_is_not_initalized);
      }
    }
    return flag;
  }

  internal void OnRibbonBarSaveCodeplug(object sender, RoutedEventArgs e)
  {
    this.OnAppMenuSave(sender, e);
  }

  private void OnFindTokenKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
  {
    if (e.Key != Key.Return)
      return;
    this.Find(SearchMode.UINamesOnly);
  }

  internal void OnFindFieldName(object sender, RoutedEventArgs e)
  {
    this.Find(SearchMode.UINamesOnly);
  }

  internal void OnFindFieldNameAndValue(object sender, RoutedEventArgs e)
  {
    this.Find(SearchMode.UINamesAndUIValues);
  }

  private bool FilterSpecialFieldInFindResultReport(IAcpField field)
  {
    return FieldFilters.FilterSpecialFieldInReport(field) || field.Parent.FeatureSectionId == 10115 && field.Name == "ChannelsActiveChannel" && AppInfoManager.AppView != DifferentiatedUserViewType.Labtool;
  }

  internal void Find(SearchMode mode)
  {
    if (this.cpgOpenFlag)
    {
      if (string.IsNullOrEmpty(this.FindToken.Text))
        return;
      AppInfoManager.FindResultReport.Clear();
      bool flag = false;
      Document.SearchMode = mode;
      foreach (IAcpField field in ((App) System.Windows.Application.Current).TheDocument.Search(this.FindToken.Text))
      {
        if ((AppInfoManager.AppView != DifferentiatedUserViewType.Custom || field.DifferentiatedUserView != DifferentiatedUserViewType.Depot && field.DifferentiatedUserView != DifferentiatedUserViewType.Labtool) && (field.DifferentiatedUserView != DifferentiatedUserViewType.Depot && field.DifferentiatedUserView != DifferentiatedUserViewType.Labtool || field.DifferentiatedUserView <= AppInfoManager.AppView) && !this.FilterSpecialFieldInFindResultReport(field))
        {
          AppInfoManager.FindResultReport.RegisterResult(field);
          flag = true;
        }
      }
      if (flag)
        return;
      ((WindowMain) System.Windows.Application.Current.MainWindow).pageIUI.OpenDockWindow(DockWndType.FindResults);
    }
    else
    {
      int num = (int) System.Windows.MessageBox.Show(AppResources.Codeplug_must_be_opened_in_order_to_perform_search_operation, AppResources.Find_Id, MessageBoxButton.OK, MessageBoxImage.Exclamation);
    }
  }

  internal WindowMain.CodeplugFileType GetCodeplugFileType(string filePath)
  {
    WindowMain.CodeplugFileType codeplugFileType;
    switch (Path.GetExtension(filePath).ToLower())
    {
      case ".mc":
        codeplugFileType = WindowMain.CodeplugFileType.Mc;
        break;
      case ".cxf":
        codeplugFileType = WindowMain.CodeplugFileType.Cxf;
        break;
      default:
        codeplugFileType = WindowMain.CodeplugFileType.None;
        break;
    }
    return codeplugFileType;
  }

  internal async Task<bool> TryOpenDocumentToCompare(
    WindowMain.CodeplugFileType codeplugFileType,
    string filePath)
  {
    switch (codeplugFileType)
    {
      case WindowMain.CodeplugFileType.None:
        return false;
      case WindowMain.CodeplugFileType.Mc:
        return ((AcpDocument) AppInfoManager.ComparatorDocument).FileOpenSafely(filePath, (IEnumerable<BinarySerializerTypeInfo>) AllowedTypes.AllowedTypesList);
      case WindowMain.CodeplugFileType.Cxf:
        string path3 = Guid.NewGuid().ToString() + ".mc";
        this.mcTempFileNameFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Temp", path3);
        if (await CxfFileHandler.ValidateCxfPasswordAndRunConversionProcess(filePath, this.mcTempFileNameFilePath, AppDomain.CurrentDomain.BaseDirectory))
          return ((AcpDocument) AppInfoManager.ComparatorDocument).FileOpenSafely(this.mcTempFileNameFilePath, (IEnumerable<BinarySerializerTypeInfo>) AllowedTypes.AllowedTypesList);
        break;
    }
    return false;
  }

  internal async void OnRibbonBarCompCodeplug(object sender, RoutedEventArgs e)
  {
    WindowMain sender1 = this;
    string InitialDirectorySnapShot = AcpFileDialog.InitialDirectory;
    if (!sender1.CpgOpenFlag)
    {
      int num = (int) System.Windows.MessageBox.Show(AppResources.Open_Codeplug_First);
      InitialDirectorySnapShot = (string) null;
    }
    else
    {
      try
      {
        AcpUI.Common.Utility.SaveFieldWithFocus();
        NotifyFieldsReportChangedEventHandler changedEventHandler = new NotifyFieldsReportChangedEventHandler(sender1.ComparatorFieldsReport_NotifyFieldsReportChangedEvent);
        AppInfoManager.BackgroundDeserializeOpertaion = true;
        if (AppInfoManager.AppMode != ApplicationMode.CodeplugComparisonMode)
        {
          AcpOpenFileDialog acpOpenFileDialog = new AcpOpenFileDialog();
          acpOpenFileDialog.Filter = VersionInfoHelper.IsDFlagExisted(DFlagType.DASTRO) ? AppResources.Vertex_Codeplug_All_files : AppResources.Motorola_Codeplug_All_files;
          acpOpenFileDialog.MultiSelect = false;
          AcpFileHeader fileHeader = new AcpFileHeader();
          AcpFileDialog.InitialDirectory = ((App) System.Windows.Application.Current).TheDocument.docFilePath;
          if (acpOpenFileDialog.ShowDialogSafely(fileHeader).GetValueOrDefault())
          {
            string sFileName = acpOpenFileDialog.FileName;
            WindowMain.CodeplugFileType codeplugFileType = sender1.GetCodeplugFileType(sFileName);
            if (codeplugFileType != WindowMain.CodeplugFileType.None)
            {
              AppInfoManager.ComparatorDocument = (Document) new AcpDocument(true, DocumentType.Comparator);
              AppInfoManager.ComparatorFieldsReport.NotifyFieldsReportChangedEvent += changedEventHandler;
              try
              {
                AppInfoManager.ComparatorFieldsReport.Clear();
                if (await sender1.TryOpenDocumentToCompare(codeplugFileType, sFileName))
                {
                  if (sender1.AuthenticateCpgForRWPassword((AcpDocument) AppInfoManager.ComparatorDocument, (string) null, false))
                  {
                    AppInfoManager.AppMode = ApplicationMode.CodeplugComparisonMode;
                    sender1.CurrentAppMode = ApplicationMode.CodeplugComparisonMode;
                    string strModelNumber = string.Empty;
                    try
                    {
                      Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation radioInformation = AppInfoManager.ComparatorDocument.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation;
                      strModelNumber = radioInformation.General.RadInfoGeneralModelNumber_A8539Value;
                      AppInfoManager.SetActiveComparatorDocumentCodeplugVersion(radioInformation.General.RadInfoGeneralCodeplugVersion_A7683.Value);
                    }
                    catch (Exception ex)
                    {
                    }
                    ModelTiering modelTiering = new ModelTiering(strModelNumber, ModelTiering.ActionTypes.OPEN, ModelTiering.TargetTypes.ALL, true);
                    ConstraintManager.Suspend();
                    modelTiering.ApplyTieringForComparedMC();
                    ConstraintManager.Resume();
                    bool isCompareCpgPortable = UtilityMack.IsPortableOnly();
                    new ModelTiering(sender1.MyModelNumber, "").UpdateUtilityMackModelType();
                    sender1.InitFCCNarrowBandSplit();
                    ((IAcpPageFeature) ((WindowMain) System.Windows.Application.Current.MainWindow).FrameCenterTop.Content)?.RefreshComparatorOdp();
                    sender1.DocumentOperations.UclTemplateNodeInit();
                    sender1.SyncQC2Code();
                    sender1.InitTrkPerAnnGroup();
                    sender1.DEKVipTableInit();
                    sender1.SyncO9PASirenButtons(isCompareCpgPortable);
                    sender1.RefreshForCnvPer();
                    sender1.RefreshForTrkSys();
                    sender1.RefreshDynChannelName();
                    sender1.RefreshScanlistMap();
                    sender1.TriggerMuteToneRefresh();
                    sender1.RefreshBroadbandFields();
                    sender1.RefreshUserSelectablePL();
                    sender1.SyncASTROUserSelectable(AppInfoManager.ComparatorDocument);
                    sender1.SyncAstroEraseOnPreviousChange(AppInfoManager.ComparatorDocument);
                    sender1.SyncAstroInfiniteUKEKRetention(AppInfoManager.ComparatorDocument);
                    sender1.SyncASTROOTARAndOTARProfileIndex(AppInfoManager.ComparatorDocument);
                    sender1.ComparatorFixUpForRadWideBluetoothPairingType(AppInfoManager.ComparatorDocument);
                    sender1.ChangeLegacyDINCFieldsFromLowerToUpperCase();
                    sender1.modifySoftIDUserNameForCompare();
                    sender1.expandFlashcode();
                    sender1.RunTMSConstraints();
                    sender1.URLTableFixup();
                    sender1.FixUpVIQIVirtualPartnerValueSetToDisabledIfLMR();
                    sender1.FixUpSwitchesValueSetToBlankIfUnprogrammed();
                    sender1.FixUpSetNFPACompliantToTrueIfNFPARadio();
                    ComparatorManager.CompareDocuments(FeatureManager.ActiveDocument, AppInfoManager.ComparatorDocument);
                    if (sender1.ribbonBarShowRtdButtons.IsEnabled)
                    {
                      sender1.ribbonBarShowRtdButtons.IsEnabled = false;
                      sender1.ribbonBarShowRtdButtonsIsEnabled = sender1.ribbonBarShowRtdButtons.IsEnabled;
                    }
                  }
                  else
                  {
                    AppInfoManager.AppMode = ApplicationMode.CodeplugConfigurationMode;
                    sender1.CurrentAppMode = ApplicationMode.CodeplugConfigurationMode;
                    AppInfoManager.ComparatorFieldsReport.Clear();
                  }
                }
                else
                {
                  AppInfoManager.AppMode = ApplicationMode.CodeplugConfigurationMode;
                  sender1.CurrentAppMode = ApplicationMode.CodeplugConfigurationMode;
                  AppInfoManager.ComparatorDocument.Clear();
                  if (AppInfoManager.NonEngOldCodeplug)
                    AppInfoManager.ComparatorFieldsReport.RegisterFieldInReport((IAcpField) null, AppResources.File_colon_Cannot_Open_Old_CP_NonEng.AcpStringFormat((object) sFileName), false);
                  else
                    AppInfoManager.ComparatorFieldsReport.RegisterFieldInReport((IAcpField) null, AppResources.File_colon_could_not_be_opened.AcpStringFormat((object) sFileName), false);
                  AppInfoManager.ComparatorFieldsReport.FieldsReportChanged = true;
                }
              }
              catch
              {
                AppInfoManager.AppMode = ApplicationMode.CodeplugConfigurationMode;
                sender1.CurrentAppMode = ApplicationMode.CodeplugConfigurationMode;
                if (!UndoManager.MarkForUndo)
                  UndoManager.StartUndoRedo();
                if (AppInfoManager.NonEngOldCodeplug)
                  AppInfoManager.ComparatorFieldsReport.RegisterFieldInReport((IAcpField) null, AppResources.File_colon_Cannot_Open_Old_CP_NonEng.AcpStringFormat((object) sFileName), false);
                else
                  AppInfoManager.ComparatorFieldsReport.RegisterFieldInReport((IAcpField) null, AppResources.File_colon_could_not_be_opened.AcpStringFormat((object) sFileName), false);
                AppInfoManager.ComparatorFieldsReport.FieldsReportChanged = true;
              }
            }
            else
            {
              AppInfoManager.ComparatorFieldsReport.RegisterFieldInReport((IAcpField) null, AppResources.File_colon_could_not_be_opened.AcpStringFormat((object) sFileName), false);
              AppInfoManager.ComparatorFieldsReport.FieldsReportChanged = true;
            }
            sFileName = (string) null;
          }
        }
        else
        {
          if (AppInfoManager.AppHideMatches)
            sender1.OnRibbonBarHideMatches((object) sender1, new RoutedEventArgs());
          ((AcpDocument) AppInfoManager.ComparatorDocument).FileClose();
          AppInfoManager.ComparatorFieldsReport.Clear();
          AppInfoManager.ComparatorFieldsReport.NotifyFieldsReportChangedEvent -= changedEventHandler;
          AppInfoManager.AppMode = ApplicationMode.CodeplugConfigurationMode;
          sender1.CurrentAppMode = ApplicationMode.CodeplugConfigurationMode;
          if (!string.IsNullOrEmpty(sender1.mcTempFileNameFilePath))
          {
            try
            {
              File.Delete(sender1.mcTempFileNameFilePath);
              sender1.mcTempFileNameFilePath = (string) null;
            }
            catch (Exception ex)
            {
            }
          }
          sender1.modifySoftIDUserNameForCompare();
          if (!sender1.ribbonBarShowRtdButtons.IsEnabled)
          {
            sender1.ribbonBarShowRtdButtons.IsEnabled = true;
            sender1.ribbonBarShowRtdButtonsIsEnabled = sender1.ribbonBarShowRtdButtons.IsEnabled;
          }
          sender1.pageIUI.RefreshSelectedEventWindow();
        }
        ((IAcpPageFeature) ((WindowMain) System.Windows.Application.Current.MainWindow).FrameCenterTop.Content)?.SetDataContext();
        ComparatorManager.RefreshTree((Page) ((PageNavPaneButtons) ((WindowMain) System.Windows.Application.Current.MainWindow).FrameLeft.Content).GetSelectedItemContent());
        AppInfoManager.BackgroundDeserializeOpertaion = false;
        InitialDirectorySnapShot = (string) null;
      }
      finally
      {
        sender1._readWritePasswordApp.ClearCachedPasswordValidation();
        if (InitialDirectorySnapShot != AcpFileDialog.InitialDirectory)
          AcpFileDialog.InitialDirectory = InitialDirectorySnapShot;
      }
    }
  }

  private void ChangeLegacyDINCFieldsFromLowerToUpperCase()
  {
    try
    {
      IAcpRecordset feature1;
      IAcpRecordset feature2;
      IAcpRecordset feature3;
      if (AppInfoManager.AppMode == ApplicationMode.CodeplugComparisonMode)
      {
        feature1 = AppInfoManager.ComparatorDocument.GetFeature(2086);
        feature2 = AppInfoManager.ComparatorDocument.GetFeature(2087);
        feature3 = AppInfoManager.ComparatorDocument.GetFeature(2131);
      }
      else
      {
        feature1 = FeatureManager.GetFeature(2086);
        feature2 = FeatureManager.GetFeature(2087);
        feature3 = FeatureManager.GetFeature(2131);
      }
      if (feature1 != null && feature1.Count > 0)
      {
        foreach (Motorola.MackinawCPS.CoreFeatures.InternalMicNoiseReductionProfile.InternalMicNoiseReductionProfile reductionProfile in (Collection<AcpBusinessLayer.FeatureNode>) (feature1 as InternalMicNoiseReductionProfileRecset))
        {
          reductionProfile.General.RadErgoCfgGeneralMAXSVECTOR_A21565.Value = reductionProfile.General.RadErgoCfgGeneralMAXSVECTOR_A21565.Value.ToUpper();
          reductionProfile.General.IntMicNsRdGenDINCOUTPUTEQVECTOR_A37718.Value = reductionProfile.General.IntMicNsRdGenDINCOUTPUTEQVECTOR_A37718.Value.ToUpper();
          reductionProfile.General.IntMicNsRdGenDINCEPVECTOR_A37719.Value = reductionProfile.General.IntMicNsRdGenDINCEPVECTOR_A37719.Value.ToUpper();
        }
      }
      if (feature2 != null && feature2.Count > 0)
      {
        foreach (Motorola.MackinawCPS.CoreFeatures.ExternalMicNoiseReductionProfile.ExternalMicNoiseReductionProfile reductionProfile in (Collection<AcpBusinessLayer.FeatureNode>) (feature2 as ExternalMicNoiseReductionProfileRecset))
        {
          reductionProfile.General.RadErgoCfgGeneralMAXSVECTOR_A22297.Value = reductionProfile.General.RadErgoCfgGeneralMAXSVECTOR_A22297.Value.ToUpper();
          reductionProfile.General.ExtMicNsRdGenDINCOUTPUTEQVECTOR_A37720.Value = reductionProfile.General.ExtMicNsRdGenDINCOUTPUTEQVECTOR_A37720.Value.ToUpper();
          reductionProfile.General.ExtMicNsRdGenDINCEPVECTOR_A37721.Value = reductionProfile.General.ExtMicNsRdGenDINCEPVECTOR_A37721.Value.ToUpper();
        }
      }
      if (feature3 == null || feature3.Count <= 0)
        return;
      foreach (Motorola.MackinawCPS.CoreFeatures.GlobalNoiseReductionList.GlobalNoiseReductionList noiseReductionList in (Collection<AcpBusinessLayer.FeatureNode>) (feature3 as GlobalNoiseReductionListRecset))
      {
        noiseReductionList.General.DINCSPATIALEQ1VECTOR_A21553.Value = noiseReductionList.General.DINCSPATIALEQ1VECTOR_A21553.Value.ToUpper();
        noiseReductionList.General.DINCSPATIALEQ1VECTORCONT_A37716.Value = noiseReductionList.General.DINCSPATIALEQ1VECTORCONT_A37716.Value.ToUpper();
        noiseReductionList.General.DINCSPATIALEQ2VECTOR_A21556.Value = noiseReductionList.General.DINCSPATIALEQ2VECTOR_A21556.Value.ToUpper();
        noiseReductionList.General.DINCSPATIALEQ2VECTORCONT_A37717.Value = noiseReductionList.General.DINCSPATIALEQ2VECTORCONT_A37717.Value.ToUpper();
        noiseReductionList.General.DINCBFEQVECTOR_A21557.Value = noiseReductionList.General.DINCBFEQVECTOR_A21557.Value.ToUpper();
        noiseReductionList.General.DINCOUTPUTEQVECTOR_A21558.Value = noiseReductionList.General.DINCOUTPUTEQVECTOR_A21558.Value.ToUpper();
        noiseReductionList.General.DINCELKOVECTOR_A21561.Value = noiseReductionList.General.DINCELKOVECTOR_A21561.Value.ToUpper();
      }
    }
    catch (Exception ex)
    {
    }
  }

  private void modifySoftIDUserNameForCompare()
  {
    RadioWideRecset feature1 = FeatureManager.GetFeature(2045) as RadioWideRecset;
    AcpFieldX<string, string> softIdUsernameA9169 = (feature1[0][10102] as UserInformationAndPasswords).RadWideUserInformationandPasswordsSoftIDUsername_A9169;
    string str1 = softIdUsernameA9169.Value;
    if (AppInfoManager.AppMode == ApplicationMode.CodeplugComparisonMode)
    {
      if (str1.Length > str1.TrimEnd().Length && feature1 != null && feature1.Count >= 1)
        (feature1[0][10102] as UserInformationAndPasswords).RadWideUserInformationandPasswordsSoftIDUsername_A9169.SetValue(str1.TrimEnd());
      RadioWideRecset feature2 = AppInfoManager.ComparatorDocument.GetFeature(2045) as RadioWideRecset;
      string str2 = (feature2[0][10102] as UserInformationAndPasswords).RadWideUserInformationandPasswordsSoftIDUsername_A9169.Value;
      if (str2.Length <= str2.TrimEnd().Length)
        return;
      (feature2[0][10102] as UserInformationAndPasswords).RadWideUserInformationandPasswordsSoftIDUsername_A9169.SetValue(str2.TrimEnd());
    }
    else
    {
      AcpSimpleRangeField displayTextSizeA23453 = (feature1[0][10102] as UserInformationAndPasswords).RadWideUserInformationandPasswordsSoftIDUsernameDisplayTextSize_A23453;
      string newValue = Convert.ToString(str1).TrimEnd();
      int length = newValue.Length;
      int num1 = displayTextSizeA23453.Value;
      if (length < num1)
      {
        int num2 = num1 - length;
        for (int index = 0; index < num2; ++index)
          newValue += " ";
      }
      softIdUsernameA9169.SetValue(newValue);
    }
  }

  private void ComparatorFieldsReport_NotifyFieldsReportChangedEvent(
    object sender,
    NotifyFieldsReportChangedEventArgs e)
  {
    ComparatorManager.RefreshTree((Page) ((PageNavPaneButtons) ((WindowMain) System.Windows.Application.Current.MainWindow).FrameLeft.Content).GetSelectedItemContent());
  }

  internal void OnRibbonBarHideMatches(object sender, RoutedEventArgs e)
  {
    if (!((Page) ((WindowMain) System.Windows.Application.Current.MainWindow).FrameCenterTop.Content is IAcpPageFeature))
      return;
    AppInfoManager.AppHideMatches = !AppInfoManager.AppHideMatches;
    if (AppInfoManager.AppHideMatches)
      this.RibbonBarCompCodeplugHideUnideFlds.Header = (object) AppResources.UnHide_Matches;
    else
      this.RibbonBarCompCodeplugHideUnideFlds.Header = (object) AppResources.Hide_Matches;
  }

  internal void OnRibbonBarPageCopyAll(object sender, RoutedEventArgs e)
  {
    Page content = (Page) ((WindowMain) System.Windows.Application.Current.MainWindow).FrameCenterTop.Content;
    if (!(content is IAcpPageFeature))
      return;
    ComparatorManager.CopyAllFields((IAcpPageFeature) content);
  }

  internal void OnRibbonBarOpenCustomView(object sender, RoutedEventArgs e)
  {
    AcpOpenFileDialog acpOpenFileDialog = new AcpOpenFileDialog();
    acpOpenFileDialog.Filter = AppResources.Custom_Views_Filter;
    acpOpenFileDialog.MultiSelect = false;
    if (!acpOpenFileDialog.ShowDialog().GetValueOrDefault())
      return;
    string fileName = acpOpenFileDialog.FileName;
    if (fileName == null)
      return;
    if (fileName.EndsWith(".xml"))
    {
      if (!this.DefaultCpgOpenFlag)
      {
        if (AppInfoManager.DefaultDocument == null)
          AppInfoManager.DefaultDocument = (Document) new AcpDocument(true, DocumentType.Default);
        this.DocumentOperations.InitDocument(AppInfoManager.DefaultDocument);
        ConstraintManager.Suspend();
        this.DefaultCpgOpenFlag = true;
      }
      try
      {
        if (AppInfoManager.DefaultDocument.ImportFromXml(fileName, XmlFileType.CustomView))
        {
          WindowMain mainWindow = (WindowMain) System.Windows.Application.Current.MainWindow;
          ((PageNavPaneButtons) mainWindow.FrameLeft.Content).FrameCustView.Navigate(new Uri("PageTreeView.xaml", UriKind.RelativeOrAbsolute));
          mainWindow.FrameCenterTop.Navigate(new Uri(AppInfoManager.DefaultDocument.GetFeature(2049).UIPagePath, UriKind.RelativeOrAbsolute));
          this.InitTablesWithDefaultRecords(AppInfoManager.DefaultDocument);
          this.CustomViewOpenFlag = true;
          this.SetTitleBar(new FileInfo(fileName).Name, (string) null);
        }
        else if (AppInfoManager.IsCustomViewLanguageMismatch)
          AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, $"{AppResources.Error_Opening_Custom_View}{fileName} {AppResources.Not_a_Valid_Custom_View_FileLanguage}");
        else
          AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, $"{AppResources.Error_Opening_Custom_View}{fileName} {AppResources.Not_a_Valid_Custom_View_File}");
      }
      catch (Exception ex)
      {
        AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, AppResources.Error_Opening_Custom_View_file + ex.Message);
      }
    }
    else
      AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, $"{AppResources.Error_Opening_Custom_View}{fileName} {AppResources.Not_a_Valid_Custom_View_File}");
  }

  internal void OnRibbonBarNewCustomView(object sender, RoutedEventArgs e)
  {
    if (!this.DefaultCpgOpenFlag)
    {
      if (AppInfoManager.DefaultDocument == null)
        AppInfoManager.DefaultDocument = (Document) new AcpDocument(true, DocumentType.Default);
      this.DocumentOperations.InitDocument(AppInfoManager.DefaultDocument);
      ConstraintManager.Suspend();
      this.DefaultCpgOpenFlag = true;
    }
    try
    {
      CustomViewCreationInfo viewCreationInfo = new CustomViewCreationInfo(string.Empty, string.Empty);
      PageFunctionCustomViewWizard page = new PageFunctionCustomViewWizard(viewCreationInfo);
      AcpUIDialogWindow<CustomViewCreationInfo> acpUiDialogWindow = new AcpUIDialogWindow<CustomViewCreationInfo>((PageFunction<CustomViewCreationInfo>) page, viewCreationInfo);
      page.Background = (Brush) this.TryFindResource((object) new ComponentResourceKey(this.FrameCenterTop.GetType(), (object) AcpColorKeys.FrameContentAreaPopupDialogueBackground));
      acpUiDialogWindow.Height = 250.0;
      acpUiDialogWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
      acpUiDialogWindow.ResizeMode = ResizeMode.NoResize;
      acpUiDialogWindow.Show();
      acpUiDialogWindow.Focus();
      acpUiDialogWindow.Hide();
      if (!acpUiDialogWindow.ShowDialog().GetValueOrDefault())
        return;
      CustomViewCreationInfo dialogData = (CustomViewCreationInfo) acpUiDialogWindow.DialogData;
      string customViewFileName = dialogData.CustomViewFileName;
      string viewFileBaseline = dialogData.CustomViewFileBaseline;
      WindowMain mainWindow = (WindowMain) System.Windows.Application.Current.MainWindow;
      ((PageNavPaneButtons) mainWindow.FrameLeft.Content).FrameCustView.Navigate(new Uri("PageTreeView.xaml", UriKind.RelativeOrAbsolute));
      mainWindow.FrameCenterTop.Navigate(new Uri(AppInfoManager.DefaultDocument.GetFeature(2049).UIPagePath, UriKind.RelativeOrAbsolute));
      this.InitTablesWithDefaultRecords(AppInfoManager.DefaultDocument);
      this.CustomViewOpenFlag = true;
    }
    catch (Exception ex)
    {
      AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, AppResources.Error_Creating_Custom_View + ex.Message);
    }
  }

  internal void OnRibbonBarSaveAsCustomView(object sender, RoutedEventArgs e)
  {
    AcpSaveFileDialog acpSaveFileDialog = new AcpSaveFileDialog();
    acpSaveFileDialog.Filter = AppResources.Custom_Views_Filter;
    if (!acpSaveFileDialog.ShowDialog().GetValueOrDefault())
      return;
    string fileName = acpSaveFileDialog.FileName;
    if (fileName == null)
      return;
    if (fileName.EndsWith(".xml"))
    {
      if (File.Exists(fileName) && (File.GetAttributes(fileName) & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
        AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, AppResources.Error_saving_Custom_View_file_should_not_have_Read_only_Attribute);
      else if (File.Exists(fileName) && (File.GetAttributes(fileName) & FileAttributes.Hidden) == FileAttributes.Hidden)
      {
        AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, AppResources.Error_saving_Custom_View_file_should_not_have_Hidden_Attribute);
      }
      else
      {
        try
        {
          if (!AppInfoManager.DefaultDocument.ExportToXml(fileName, XmlFileType.CustomView))
            AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, AppResources.Error_saving_Custom_View_file + fileName);
          else
            this.SetTitleBar(new FileInfo(fileName).Name, (string) null);
        }
        catch (Exception ex)
        {
          AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, AppResources.Error_saving_Custom_View_file + fileName);
        }
      }
    }
    else
      AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, AppResources.Error_saving_Custom_View_file_must_have_xml_extension);
  }

  internal void OnRibbonBarCloseCustomView(object sender, RoutedEventArgs e)
  {
    AcpUI.Common.Utility.SaveFieldWithFocus();
    if (System.Windows.MessageBox.Show(AppResources.Are_you_sure_you_exit_Custom_View_Mode_Unsaved_changes_will_lost_pls_ensure_save, AppResources.Custom_View_Configuration_Mode_Warning, MessageBoxButton.YesNo) != MessageBoxResult.Yes)
      return;
    WindowMain mainWindow = (WindowMain) System.Windows.Application.Current.MainWindow;
    AppInfoManager.DefaultDocument.Clear();
    this.DefaultCpgOpenFlag = false;
    PageNavPaneButtons content = (PageNavPaneButtons) mainWindow.FrameLeft.Content;
    content.FrameCodeplug.Content = (object) null;
    content.FrameCustView.Content = (object) null;
    content.ButtonHome.IsSelected = true;
    this.CustomViewOpenFlag = false;
    this.SetTitleBar((string) null, (string) null);
    AppInfoManager.ClearNavigationHistory = true;
    this.ClearEventWindows();
  }

  internal void OnRibbonBarCustomViewHelp(object sender, RoutedEventArgs e)
  {
    try
    {
      ACPBrowser.Utility.DisplayCPSHelpDITA("#2c216158");
    }
    catch (Exception ex)
    {
    }
  }

  private void OnRibbonBarLoadASK(object sender, RoutedEventArgs e)
  {
    AppInfoManager.InvalidFieldsReport.SuppressReportDisplay = true;
    try
    {
      if (AcpSecurityLib.SecurityManager.LoadAllAttachedKeys(false) > 0)
      {
        this.pageIUI.OpenDockWindow(DockWndType.SysKeyRpt);
        if (!this.CpgOpenFlag)
          this.CheckForUnlimited();
      }
      else
        AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Warning, AppResources.No_Advanced_System_Key_loaded_Attach_IButton);
    }
    catch (AccessViolationException ex)
    {
      AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Warning, AppResources.One_Wire_Bus_Busy);
    }
    AppInfoManager.InvalidFieldsReport.SuppressReportDisplay = false;
  }

  private void CheckForUnlimited()
  {
    this.AppMenuWriteProtect.IsEnabled = false;
    this.bUnlimitedKeyLoaded = false;
    foreach (SystemKeyData loadedAsK in (Collection<SystemKeyData>) AcpSecurityLib.SecurityManager.LoadedASKs)
    {
      switch (loadedAsK.AccessLevel.GetKeyAccessLevelType())
      {
        case KeyAccessLevelType.UNLM_ACC:
        case KeyAccessLevelType.UNLM_ACC_WITHOUT_WP:
          if (loadedAsK.Type != KeyType.ADVANCED_CONV_SYSTEM_KEY && (loadedAsK.SystemID != 1 || loadedAsK.Type != KeyType.ADVANCED_SYSTEM_KEY))
          {
            this.AppMenuWriteProtect.IsEnabled = true;
            this.bUnlimitedKeyLoaded = true;
            return;
          }
          continue;
        default:
          continue;
      }
    }
  }

  private void OnRibbonBarLoadSWKey(object sender, RoutedEventArgs e)
  {
    string path = this.defaultKeyFilesLocation;
    if (!Directory.Exists(path))
      path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
    System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
    openFileDialog.InitialDirectory = path;
    openFileDialog.Filter = AppResources.key_files_Filter;
    openFileDialog.Multiselect = true;
    openFileDialog.RestoreDirectory = true;
    if (openFileDialog.ShowDialog() != System.Windows.Forms.DialogResult.OK)
      return;
    string[] fileNames = openFileDialog.FileNames;
    if (fileNames.Length == 0)
      return;
    AppInfoManager.InvalidFieldsReport.SuppressReportDisplay = true;
    if (AcpSecurityLib.SecurityManager.LoadSelectedSwKeyFiles(fileNames, false) > 0)
      this.pageIUI.OpenDockWindow(DockWndType.SysKeyRpt);
    else
      AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Warning, AppResources.No_System_Key_Was_Loaded);
    AppInfoManager.InvalidFieldsReport.SuppressReportDisplay = false;
  }

  private void InitASKProgHistoryRecSet()
  {
    Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation radioInformation = (Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation) FeatureManager.GetFeature(2049)[0];
    if (radioInformation == null)
      return;
    ASKProgrammingHistoryInnerRecset embeddedRecset = (ASKProgrammingHistoryInnerRecset) radioInformation.AdvancedSystemKeyInfo.EmbeddedRecset;
    embeddedRecset.SetMax(embeddedRecset.Count);
    ASKProgrammingHistoryInnerRecset._Min = embeddedRecset.Count;
  }

  private void OnAppMenuQuerySetRadio(object sender, RoutedEventArgs e)
  {
    AcpUIDialogWindow<string> acpUiDialogWindow = new AcpUIDialogWindow<string>((PageFunction<string>) new WriteProtect(this, (Collection<SystemKeyData>) AcpSecurityLib.SecurityManager.LoadedASKs), (string) null);
    acpUiDialogWindow.ShowInTaskbar = false;
    acpUiDialogWindow.Owner = (Window) this;
    acpUiDialogWindow.ResizeMode = ResizeMode.NoResize;
    acpUiDialogWindow.Show();
    acpUiDialogWindow.Focus();
    acpUiDialogWindow.Hide();
    acpUiDialogWindow.ShowDialog();
  }

  private void OnRibbonBarReadFlashKeyCfg(object sender, RoutedEventArgs e)
  {
    Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
    if (new ReadFlashkeyConfiguration().ReadFlashkey())
    {
      Mouse.OverrideCursor = (System.Windows.Input.Cursor) null;
      Window sender1 = new Window();
      sender1.Content = (object) new PageFlashkeyConfiguration();
      sender1.ResizeMode = ResizeMode.CanResize;
      sender1.MinHeight = 200.0;
      sender1.MinWidth = 600.0;
      sender1.MaxWidth = 800.0;
      sender1.MaxHeight = Math.Max(sender1.MinHeight, this.ActualHeight);
      sender1.SizeToContent = SizeToContent.WidthAndHeight;
      sender1.ShowInTaskbar = false;
      sender1.Owner = (Window) this;
      sender1.WindowStartupLocation = WindowStartupLocation.CenterOwner;
      sender1.ShowInTaskbar = false;
      sender1.Background = (Brush) this.TryFindResource((object) new ComponentResourceKey(this.FrameCenterTop.GetType(), (object) AcpColorKeys.FrameContentAreaBackground));
      sender1.Title = AppResources.FLASHkey_Configuration;
      AcpUI.Common.Utility.SetDirection((FrameworkElement) sender1);
      sender1.Show();
      sender1.Focus();
      sender1.Hide();
      sender1.ShowDialog();
      AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Info, AppResources.FLASHkey_Configuration_read_successfully);
    }
    else
      AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, AppResources.Unable_to_find_a_valid_flashkey);
    Mouse.OverrideCursor = (System.Windows.Input.Cursor) null;
  }

  private void OnRibbonBarReadRadCfg(object sender, RoutedEventArgs e)
  {
    AppInfoManager.StatusMsgReport.Clear();
    Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
    if (new ReadRadioConfiguration().ReadRadio())
    {
      Mouse.OverrideCursor = (System.Windows.Input.Cursor) null;
      Window sender1 = new Window();
      sender1.Content = (object) new PageRadioConfiguration();
      sender1.SizeToContent = SizeToContent.WidthAndHeight;
      sender1.Owner = (Window) this;
      sender1.WindowStartupLocation = WindowStartupLocation.CenterOwner;
      sender1.ResizeMode = ResizeMode.NoResize;
      sender1.ShowInTaskbar = false;
      sender1.Background = (Brush) this.TryFindResource((object) new ComponentResourceKey(this.FrameCenterTop.GetType(), (object) AcpColorKeys.FrameContentAreaBackground));
      sender1.Title = AppResources.Radio_Configuration;
      AcpUI.Common.Utility.SetDirection((FrameworkElement) sender1);
      sender1.Show();
      sender1.Focus();
      sender1.Hide();
      sender1.ShowDialog();
      AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Info, AppResources.Radio_Configuration_read_successfully);
    }
    else
      AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, AppResources.Unable_to_read_radio_configuration);
    Mouse.OverrideCursor = (System.Windows.Input.Cursor) null;
  }

  private void OnRibbonBarFlashRadio(object sender, RoutedEventArgs e)
  {
    bool bRefresh = true;
    if (sender == this.ribbonBarFlashRadio)
      bRefresh = false;
    this.FlashRadio(bRefresh);
  }

  public void FlashRadio(bool bRefresh)
  {
    try
    {
      this.FlashRadioInternal(bRefresh);
    }
    finally
    {
      this._readWritePasswordApp.ClearCachedPasswordValidation();
    }
  }

  private void FlashRadioInternal(bool bRefresh)
  {
    if (((WindowMain) System.Windows.Application.Current.MainWindow).CpgOpenFlag)
    {
      AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, AppResources.The_FLASHport_upgrade);
    }
    else
    {
      AppInfoManager.DragOperation = true;
      Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
      this.DocumentOperations.InitDocument();
      ((App) System.Windows.Application.Current).TheDocument.FileNew();
      UndoManager.StopUndoRedo();
      UndoManager.Reset();
      ConstraintManager.Suspend();
      Mouse.OverrideCursor = (System.Windows.Input.Cursor) null;
      Action<BrowseForFilePage> action = (Action<BrowseForFilePage>) (p =>
      {
        if (!string.IsNullOrEmpty(p.FileOperationData.FilePath) && File.Exists(p.FileOperationData.FilePath))
        {
          PageUpgradeRadioProgress root = new PageUpgradeRadioProgress(p.FileOperationData);
          Window window = Window.GetWindow((DependencyObject) this);
          window.WindowStartupLocation = WindowStartupLocation.Manual;
          window.Top = 200.0;
          window.Left = 300.0;
          root.Return += new ReturnEventHandler<SpecialFeatures.FileOperations.DialogResult>(p.OnPageReturn);
          p.NavigationService.Navigate((object) root);
        }
        else
          new MessageWindow(AppResources.Select_Valid_Upgrade_File)
          {
            Owner = Window.GetWindow((DependencyObject) this)
          }.ShowDialog();
      });
      FileOperationData fileOperationData = new FileOperationData()
      {
        FilePath = this.upgradeFile,
        Refresh = bRefresh,
        InitialDirectory = Settings.Default.Refresh_Radio_Default_Folder,
        HeadingTitleContent = AppResources.Select_Radio_Software_File,
        Filter = AppResources.FLASHport_Upgrade_Files.AcpStringFormat((object) " (*.bbf)|*.bbf|FLASHport APXNext Upgrade Files (*.zip)|*.zip|All files (*.*)|*.*")
      };
      if (bRefresh)
      {
        fileOperationData.BrowseDialogTitleContent = AppResources.Radio_Software_Refresh;
        fileOperationData.BrowseDialogActionButtonContent = AppResources.Refresh_Radio;
        fileOperationData.BrowseDialogHelpTopicId = "#e68e0ccb";
        fileOperationData.ProgressDialogTitleContent = AppResources.Radio_Software_Refresh_Progress;
        fileOperationData.ProgressDialogHelpTopicId = "#1eba4e7c";
      }
      else
      {
        fileOperationData.BrowseDialogTitleContent = AppResources.FLASHport_Upgrade;
        fileOperationData.BrowseDialogActionButtonContent = AppResources.Flash_Radio;
        fileOperationData.BrowseDialogHelpTopicId = "#cd725484";
        fileOperationData.ProgressDialogTitleContent = AppResources.FLASHport_Upgrade_Progress;
        fileOperationData.ProgressDialogHelpTopicId = "#ffeb2da5";
      }
      BrowseForFileDialogBox forFileDialogBox = new BrowseForFileDialogBox(action, fileOperationData, typeof (PageUpgradeRadioProgress));
      forFileDialogBox.Owner = (Window) this;
      forFileDialogBox.Show();
      forFileDialogBox.Focus();
      forFileDialogBox.Hide();
      if (forFileDialogBox.ShowDialog().Value)
        this.upgradeFile = forFileDialogBox.FileOperationData.FilePath;
      Settings.Default.Refresh_Radio_Default_Folder = forFileDialogBox.FileOperationData.InitialDirectory;
      Settings.Default.Save();
      ((App) System.Windows.Application.Current).TheDocument?.FileClose();
      AppInfoManager.DragOperation = false;
    }
  }

  public void ResetPassword()
  {
    BrowseForFileDialogBox forFileDialogBox = new BrowseForFileDialogBox((Action<BrowseForFilePage>) (p =>
    {
      if (!string.IsNullOrEmpty(p.FileOperationData.FilePath) && File.Exists(p.FileOperationData.FilePath))
      {
        PageResetRadioPasswordProgress root = new PageResetRadioPasswordProgress(p.FileOperationData, this._readWritePasswordApp);
        Window window = Window.GetWindow((DependencyObject) this);
        window.WindowStartupLocation = WindowStartupLocation.Manual;
        window.Top = 200.0;
        window.Left = 300.0;
        root.Return += new ReturnEventHandler<SpecialFeatures.FileOperations.DialogResult>(p.OnPageReturn);
        p.NavigationService.Navigate((object) root);
      }
      else
        new MessageWindow(AppResources.Select_Valid_Password_Reset_File)
        {
          Owner = Window.GetWindow((DependencyObject) this)
        }.ShowDialog();
    }), new FileOperationData()
    {
      FilePath = this.resetFilePath,
      Refresh = false,
      InitialDirectory = Settings.Default.Refresh_Radio_Default_Folder,
      HeadingTitleContent = AppResources.Select_Radio_Password_Reset_File,
      BrowseDialogTitleContent = AppResources.Radio_Password_Reset,
      BrowseDialogActionButtonContent = AppResources.Reset_Password_Button_Text,
      BrowseDialogHelpTopicId = "#e5591b3e",
      ProgressDialogTitleContent = AppResources.Password_Reset,
      ProgressDialogHelpTopicId = "#e5591b3e",
      Filter = AppResources.Password_Reset_Files.AcpStringFormat((object) " (*.bin)|*.bin")
    }, typeof (PageResetRadioPasswordProgress));
    forFileDialogBox.Owner = (Window) this;
    forFileDialogBox.Show();
    forFileDialogBox.Focus();
    forFileDialogBox.Hide();
    if (forFileDialogBox.ShowDialog().Value)
      this.resetFilePath = forFileDialogBox.FileOperationData.FilePath;
    Settings.Default.Refresh_Radio_Default_Folder = forFileDialogBox.FileOperationData.InitialDirectory;
    Settings.Default.Save();
    AppInfoManager.DragOperation = false;
  }

  private void RibbonBarShowFS_Click(object sender, RoutedEventArgs e)
  {
    Window sender1 = new Window();
    sender1.Content = (object) new PageRadioFeatureSet();
    sender1.ResizeMode = ResizeMode.CanResize;
    sender1.MinHeight = 200.0;
    sender1.MinWidth = 600.0;
    sender1.MaxWidth = 800.0;
    sender1.MaxHeight = Math.Max(sender1.MinHeight, this.ActualHeight);
    sender1.SizeToContent = SizeToContent.WidthAndHeight;
    sender1.ShowInTaskbar = false;
    sender1.Owner = (Window) this;
    sender1.WindowStartupLocation = WindowStartupLocation.CenterOwner;
    sender1.Background = (Brush) this.TryFindResource((object) new ComponentResourceKey(this.FrameCenterTop.GetType(), (object) AcpColorKeys.FrameContentAreaBackground));
    sender1.Title = AppResources.Codeplug_Feature_Set;
    AcpUI.Common.Utility.SetDirection((FrameworkElement) sender1);
    sender1.Show();
    sender1.Focus();
    sender1.Hide();
    sender1.ShowDialog();
  }

  private void RibbonBarShowMultiCodeplug_Click(object sender, RoutedEventArgs e)
  {
    if (this.CpgOpenFlag)
    {
      int num = (int) System.Windows.MessageBox.Show(AppResources.MultiCodeplug_Codeplug_Is_Opened, AppResources.APX_CPS, MessageBoxButton.OK, MessageBoxImage.Exclamation);
    }
    else
    {
      MultiCodeplugManagement codeplugManagement = new MultiCodeplugManagement(new UninitializeCodeplugDelegate(this.UninitializeCodeplug));
      codeplugManagement.Content = (object) new MultiCodeplugManagementPage(new GenerateCodeplugDelegate(this.GenerateConfigurationForMultiCodeplug), new UninitializeCodeplugDelegate(this.UninitializeMultiCodeplug), new InitializeMultiCodeplugDelegate(this.InitCodeplugOpen));
      AppInfoManager.DragOperation = true;
      codeplugManagement.Owner = (Window) this;
      codeplugManagement.WindowStartupLocation = WindowStartupLocation.CenterOwner;
      codeplugManagement.Show();
      codeplugManagement.Focus();
      codeplugManagement.Hide();
      codeplugManagement.ShowDialog();
      ((App) System.Windows.Application.Current).TheDocument?.FileClose();
      AppInfoManager.DragOperation = false;
    }
  }

  private void OnRibbonBarPassword(object sender, RoutedEventArgs e)
  {
    this._readWritePasswordApp.ShowReadWritePasswordWindow();
  }

  private void OnRibbonBarCodeplugData(object sender, RoutedEventArgs e)
  {
    if (this.PromptQuitOnInvalids().Result)
    {
      int num = (int) System.Windows.MessageBox.Show(AppResources.The_codeplug_contains_invalid_fields_Please_correct_them_and_try_again, AppResources.Invalid_Fields_Error, MessageBoxButton.OK, MessageBoxImage.Exclamation);
    }
    else
    {
      SpecialFeatures.CodeplugSizeIndicator.CodeplugSizeIndicator codeplugSizeIndicator = new SpecialFeatures.CodeplugSizeIndicator.CodeplugSizeIndicator();
      codeplugSizeIndicator.ResizeMode = ResizeMode.NoResize;
      codeplugSizeIndicator.WindowStartupLocation = WindowStartupLocation.CenterOwner;
      codeplugSizeIndicator.Show();
      codeplugSizeIndicator.Focus();
      codeplugSizeIndicator.Hide();
      codeplugSizeIndicator.ShowDialog();
    }
  }

  private void OnRibbonBarRunConfusability(object sender, RoutedEventArgs e)
  {
    DisplayAndMenuConstraints.runConfusabilityCheck();
  }

  private void OnRibbonBarConvertVoiceAnnouncementFiles(object sender, RoutedEventArgs e)
  {
    AcpUIDialogWindow<string> acpUiDialogWindow = new AcpUIDialogWindow<string>((PageFunction<string>) new ACPVoiceAnnouncementImportUI(), (string) null);
    acpUiDialogWindow.ShowInTaskbar = false;
    acpUiDialogWindow.Owner = (Window) this;
    acpUiDialogWindow.Width = 605.0;
    acpUiDialogWindow.MinWidth = 605.0;
    acpUiDialogWindow.MaxWidth = 605.0;
    acpUiDialogWindow.Height = 630.0;
    acpUiDialogWindow.MinHeight = 630.0;
    acpUiDialogWindow.MaxHeight = 630.0;
    acpUiDialogWindow.SizeToContent = SizeToContent.WidthAndHeight;
    acpUiDialogWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
    acpUiDialogWindow.ResizeMode = ResizeMode.NoResize;
    acpUiDialogWindow.Show();
    acpUiDialogWindow.Focus();
    acpUiDialogWindow.Hide();
    acpUiDialogWindow.ShowDialog();
  }

  private void OnRibbonBarCalculateVoiceAnnouncementSize(object sender, RoutedEventArgs e)
  {
    AcpUIDialogWindow<string> acpUiDialogWindow = new AcpUIDialogWindow<string>((PageFunction<string>) new ACPVoiceAnnouncementUsageMeter(), (string) null);
    acpUiDialogWindow.Owner = (Window) this;
    acpUiDialogWindow.ShowInTaskbar = false;
    acpUiDialogWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
    acpUiDialogWindow.ResizeMode = ResizeMode.NoResize;
    acpUiDialogWindow.Show();
    acpUiDialogWindow.Focus();
    acpUiDialogWindow.Hide();
    acpUiDialogWindow.ShowDialog();
  }

  private void OnRibbonBarDownLoadVoiceFile(object sender, RoutedEventArgs e)
  {
    AcpUIDialogWindow<string> acpUiDialogWindow = new AcpUIDialogWindow<string>((PageFunction<string>) new VoiceAnnouncementUtilities(), (string) null);
    acpUiDialogWindow.ShowInTaskbar = false;
    acpUiDialogWindow.Owner = (Window) this;
    acpUiDialogWindow.Width = 450.0;
    acpUiDialogWindow.MinWidth = 450.0;
    acpUiDialogWindow.MaxWidth = 450.0;
    acpUiDialogWindow.Height = 600.0;
    acpUiDialogWindow.MinHeight = 600.0;
    acpUiDialogWindow.MaxHeight = 600.0;
    acpUiDialogWindow.SizeToContent = SizeToContent.WidthAndHeight;
    acpUiDialogWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
    acpUiDialogWindow.ResizeMode = ResizeMode.NoResize;
    acpUiDialogWindow.Show();
    acpUiDialogWindow.Focus();
    acpUiDialogWindow.Hide();
    acpUiDialogWindow.ShowDialog();
  }

  public bool OtapEnabledCodeplug
  {
    get
    {
      if (!this.CpgOpenFlag)
        return false;
      if (FeatureManager.GetFeature(2049)[0] is Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation radioInformation)
        this.otapEnabledCodeplug = radioInformation.Labtool.RadInfoLabtoolG966OTAP_A22740Value;
      return this.otapEnabledCodeplug;
    }
  }

  private void OnRibbonBarCreateRadioList(object sender, RoutedEventArgs e)
  {
    POP25BatchProgrammerRadioList programmerRadioList = new POP25BatchProgrammerRadioList();
    programmerRadioList.ShowInTaskbar = false;
    programmerRadioList.Owner = (Window) this;
    programmerRadioList.ResizeMode = ResizeMode.NoResize;
    programmerRadioList.Show();
    programmerRadioList.Focus();
    programmerRadioList.Hide();
    programmerRadioList.ShowDialog();
  }

  private void OnRibbonBarOpenPOP25BatchScheduler(object sender, RoutedEventArgs e)
  {
    AcpUI.Common.Utility.SaveFieldWithFocus();
    if (AppInfoManager.InvalidFieldsReport.HasFields)
    {
      int num = (int) System.Windows.MessageBox.Show(AppResources.The_codeplug_contains_invalid_fields_Please_correct_them_and_try_again, AppResources.Invalid_Fields_Error, MessageBoxButton.OK, MessageBoxImage.Exclamation);
    }
    else
    {
      Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
      POP25BatchProgrammerScheduler programmerScheduler = new POP25BatchProgrammerScheduler();
      Mouse.OverrideCursor = (System.Windows.Input.Cursor) null;
      programmerScheduler.ShowInTaskbar = false;
      programmerScheduler.ResizeMode = ResizeMode.NoResize;
      programmerScheduler.Owner = (Window) this;
      COMMS_OP cloneWriteType = CloneParameters.CloneWriteType;
      if (this.commsLastUserState != null)
        CloneParameters.LastCloneOTAPUserState = this.commsLastUserState;
      CloneParameters.CloneWriteType = COMMS_OP.OTAP_CLONE;
      CloneParameters.BlockNewSystemCheck = this.settingsSavedOnAppExit.BlockNewSysCheck;
      programmerScheduler.Show();
      programmerScheduler.Focus();
      programmerScheduler.Hide();
      programmerScheduler.ShowDialog();
      CloneParameters.CloneWriteType = cloneWriteType;
    }
  }

  private void OnRibbonBarCloneWizard(object sender, RoutedEventArgs e)
  {
    AcpUI.Common.Utility.SaveFieldWithFocus();
    this.ribbonBarCloneWizard.Focus();
    if (this.CloneTransport == 2 && !BluetoothPANIPAddressRule.IsValidBluetoothPANIPAddress(this.txtBTIPAddressForClone.Text))
      AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, $"{AppResources.Invalid_IP_Address}: {this.txtBTIPAddressForClone.Text}");
    else
      this.CloneRadio();
  }

  private void OnRibbonBarCloneExpress(object sender, RoutedEventArgs e)
  {
    AcpUI.Common.Utility.SaveFieldWithFocus();
    this.ribbonBarCloneExpress.Focus();
    if (this.CloneTransport == 2 && !BluetoothPANIPAddressRule.IsValidBluetoothPANIPAddress(this.txtBTIPAddressForClone.Text))
    {
      AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, $"{AppResources.Invalid_IP_Address}: {this.txtBTIPAddressForClone.Text}");
    }
    else
    {
      if (this.PromptQuitOnInvalids().Result)
        return;
      this.ReadWriteInProgress = true;
      if (this.CpgOpenFlag)
      {
        this.NATListFixup();
        this.ResetOOBEField();
        COMMS_OP commsOp = COMMS_OP.USB_CLONE;
        if (this.CloneTransport == 1)
          commsOp = COMMS_OP.OTAP_CLONE;
        if (this.CloneTransport == 2)
          commsOp = COMMS_OP.BLUETOOTH_CLONE;
        if (this.commsLastUserState != null)
          CloneParameters.LastCloneOTAPUserState = this.commsLastUserState;
        CloneParameters.CloneWriteType = commsOp;
        CloneParameters.BlockNewSystemCheck = this.settingsSavedOnAppExit.BlockNewSysCheck;
        Window sender1 = new Window();
        PageCloneExpress pageCloneExpress = new PageCloneExpress(this._shouldResetRadio);
        sender1.Title = AppResources.Clone_Express;
        sender1.Content = (object) pageCloneExpress;
        sender1.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        sender1.Background = (Brush) this.TryFindResource((object) new ComponentResourceKey(this.FrameCenterTop.GetType(), (object) AcpColorKeys.FrameContentAreaBackground));
        AcpUI.Common.Utility.SetDirection((FrameworkElement) sender1);
        sender1.Show();
        sender1.Focus();
        sender1.Hide();
        sender1.ShowDialog();
      }
      else
        AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, AppResources.codeplug_must_open_before_Clone_Express_use);
      this.ReadWriteInProgress = false;
    }
  }

  internal void CloneRadio()
  {
    if (this.CpgOpenFlag)
    {
      if (this.PromptQuitOnInvalids().Result)
        return;
      this.ReadWriteInProgress = true;
      string path = "";
      DifferentiatedUserViewType appView = AppInfoManager.AppView;
      switch (AppInfoManager.AppView)
      {
        case DifferentiatedUserViewType.Full:
          this.NATListFixup();
          this.ResetOOBEField();
          AcpUI.Common.Utility.SaveFieldWithFocus();
          COMMS_OP commsOp = COMMS_OP.USB_CLONE;
          if (this.CloneTransport == 1)
            commsOp = COMMS_OP.OTAP_CLONE;
          if (this.CloneTransport == 2)
            commsOp = COMMS_OP.BLUETOOTH_CLONE;
          if (this.commsLastUserState != null)
            CloneParameters.LastCloneOTAPUserState = this.commsLastUserState;
          CloneParameters.CloneWriteType = commsOp;
          Window sender = new Window();
          PageCloneWizard pageCloneWizard = new PageCloneWizard(this._shouldResetRadio);
          sender.Title = AppResources.Clone_Radio;
          sender.Content = (object) pageCloneWizard;
          sender.WindowStartupLocation = WindowStartupLocation.CenterScreen;
          sender.Background = (Brush) this.TryFindResource((object) new ComponentResourceKey(this.FrameCenterTop.GetType(), (object) AcpColorKeys.FrameContentAreaBackground));
          AcpUI.Common.Utility.SetDirection((FrameworkElement) sender);
          sender.Show();
          sender.Focus();
          sender.Hide();
          sender.ShowDialog();
          this.ReadWriteInProgress = false;
          if (AppInfoManager.AppView == appView)
            break;
          if (appView == DifferentiatedUserViewType.Custom && !string.IsNullOrEmpty(path) && File.Exists(path))
            ((App) System.Windows.Application.Current).TheDocument.ImportFromXml(path, XmlFileType.CustomView);
          AppInfoManager.AppView = appView;
          break;
        case DifferentiatedUserViewType.Custom:
          path = this.customVwPath;
          goto default;
        default:
          AppInfoManager.AppView = DifferentiatedUserViewType.Full;
          goto case DifferentiatedUserViewType.Full;
      }
    }
    else
      AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, AppResources.codeplug_must_open_before_Clone_Radio_use);
  }

  private void OnRibbonBarOpenUpdateUCL(object sender, RoutedEventArgs e)
  {
    UpdateUCL updateUcl = new UpdateUCL();
    updateUcl.ShowInTaskbar = false;
    updateUcl.ResizeMode = ResizeMode.NoResize;
    updateUcl.Owner = (Window) this;
    updateUcl.Show();
    updateUcl.Focus();
    updateUcl.Hide();
    updateUcl.ShowDialog();
  }

  private void UpdateRibbon()
  {
    if (AppInfoManager.AppMode == ApplicationMode.CodeplugComparisonMode)
    {
      this.RibbonBarCompCodeplugStartEnd.Header = (object) AppResources.End_Comparator;
      BitmapImage bitmapImage = new BitmapImage();
      bitmapImage.BeginInit();
      bitmapImage.UriSource = new Uri("../../icons/StopIcon.png", UriKind.Relative);
      bitmapImage.EndInit();
      this.RibbonBarCompCodeplugStartEndImage.Source = (ImageSource) bitmapImage;
      this.RibbonBarCompCodeplugHideUnideFlds.IsEnabled = true;
      this.RibbonBarCompCodeplugPageCopyAll.IsEnabled = true;
    }
    else
    {
      this.RibbonBarCompCodeplugStartEnd.Header = (object) AppResources.Start_Comparator;
      BitmapImage bitmapImage = new BitmapImage();
      bitmapImage.BeginInit();
      bitmapImage.UriSource = new Uri("../../icons/StartIcon.png", UriKind.Relative);
      bitmapImage.EndInit();
      this.RibbonBarCompCodeplugStartEndImage.Source = (ImageSource) bitmapImage;
      this.RibbonBarCompCodeplugHideUnideFlds.IsEnabled = false;
      this.RibbonBarCompCodeplugPageCopyAll.IsEnabled = false;
    }
    if (AppInfoManager.AppMode != ApplicationMode.CodeplugConfigurationMode)
      return;
    this.ribbonBarLoadASK.IsEnabled = true;
    this.ribbonBarLoadSWKey.IsEnabled = true;
  }

  private void UpdateQAT()
  {
    if (AppInfoManager.AppMode == ApplicationMode.CodeplugConfigurationMode)
      this.QATOpen.IsEnabled = true;
    else
      this.QATOpen.IsEnabled = false;
  }

  private void F1HelpCommandCanExcute(object sender, CanExecuteRoutedEventArgs e)
  {
    e.CanExecute = true;
  }

  private void OnClickRibbonBarCPSHelp(object sender, RoutedEventArgs e)
  {
    try
    {
      ACPBrowser.Utility.DisplayCPSHelpDITA((string) null);
    }
    catch (Exception ex)
    {
    }
  }

  private void OnClickRibbonBarAboutCPS(object sender, RoutedEventArgs e)
  {
    new HelpAboutCPSWnd().ShowDialog();
  }

  private void OnClickRibbonBarWhatsNew(object sender, RoutedEventArgs e)
  {
    try
    {
      ACPBrowser.Utility.CloseHelpWindowIfOpen();
      ACPBrowser.Utility.DisplayCPSHelpDITA((string) null);
    }
    catch (Exception ex)
    {
    }
  }

  private void OnClickRibbonBarAboutTutorials(object sender, RoutedEventArgs e)
  {
    try
    {
      ACPBrowser.Utility.CloseHelpWindowIfOpen();
      ACPBrowser.Utility.DisplayCPSHelpDITA((string) null);
    }
    catch (Exception ex)
    {
    }
  }

  private void AppInfoHelper_PropertyChanged(object sender, PropertyChangedEventArgs e)
  {
    if (e.PropertyName == "AppMode")
    {
      this.CurrentAppMode = AppInfoManager.AppMode;
      this.UpdateRibbon();
      this.UpdateQAT();
      this.TriggerConstraintsDependentOnAppMode();
    }
    if ((!(e.PropertyName == "ImportOperationCompleted") || !AppInfoManager.ImportOperationCompleted) && (!(e.PropertyName == "DndOperationCompleted") || !AppInfoManager.DndOperationCompleted))
      return;
    this.RefreshZoneChannelRecordsetToolBar();
    this.ChangeLegacyDINCFieldsFromLowerToUpperCase();
    this.RefreshDynChannelName();
    this.ClearWiFiPassword();
    this.RefreshMPLAfterDnDImport();
    this.isDnDorImpDoneBeforeTheOper = true;
  }

  private void TriggerConstraintsDependentOnAppMode()
  {
    if (FeatureManager.GetFeature(2051) is ZoneChannelAssignmentRecset feature1)
    {
      foreach (AcpBusinessLayer.FeatureNode featureNode in (Collection<AcpBusinessLayer.FeatureNode>) feature1)
      {
        Zone zone = (featureNode as Motorola.MackinawCPS.CoreFeatures.ZoneChannelAssignment.ZoneChannelAssignment).Zone;
        zone.ZnChanCfgZoneDynamicZoneEnable_A41257.CalculateEditability();
        zone.ZnChanCfgZoneZoneCloningEnable_43119.CalculateEditability();
      }
    }
    if (!(FeatureManager.GetFeature(2045) is Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide feature2))
      return;
    feature2.Features.RadWideFeaturesZoneCloneEnable_43130.CalculateEditability();
  }

  private void RefreshMPLAfterDnDImport()
  {
    if (AppInfoManager.UndoRedoInProgress)
      return;
    if (!(FeatureManager.GetFeature(2059) is ConventionalPersonalityRecset feature))
      return;
    foreach (AcpBusinessLayer.FeatureNode featureNode in (Collection<AcpBusinessLayer.FeatureNode>) feature)
    {
      Motorola.MackinawCPS.CoreFeatures.ConventionalPersonality.ConventionalPersonality conventionalPersonality = featureNode as Motorola.MackinawCPS.CoreFeatures.ConventionalPersonality.ConventionalPersonality;
      FrequencyOptionsInnerRecset embeddedRecset = conventionalPersonality.Features.Parent[10148].EmbeddedRecset as FrequencyOptionsInnerRecset;
      if (conventionalPersonality != null && embeddedRecset != null)
      {
        foreach (FrequencyOptionsInner frequencyOptionsInner in (Collection<AcpBusinessLayer.FeatureNode>) embeddedRecset)
        {
          if (frequencyOptionsInner != null && frequencyOptionsInner.FrequencyOptionsInnerSection.CnvPerConventionalChannelOptionsUserSelectablePLMPLEnhance_43029.Value == 0 && frequencyOptionsInner.FrequencyOptionsInnerSection.CnvPerConventionalChannelOptionsUserSelectablePLMPL_A9606.Value)
            frequencyOptionsInner.FrequencyOptionsInnerSection.CnvPerConventionalChannelOptionsUserSelectablePLMPLEnhance_43029.SetValue(7);
          else if (frequencyOptionsInner != null && frequencyOptionsInner.FrequencyOptionsInnerSection.CnvPerConventionalChannelOptionsUserSelectablePLMPLEnhance_43029.Value != 0 && !frequencyOptionsInner.FrequencyOptionsInnerSection.CnvPerConventionalChannelOptionsUserSelectablePLMPL_A9606.Value)
            frequencyOptionsInner.FrequencyOptionsInnerSection.CnvPerConventionalChannelOptionsUserSelectablePLMPLEnhance_43029.SetValue(0);
        }
      }
    }
  }

  private void ClearWiFiPassword()
  {
    if (AppInfoManager.UndoRedoInProgress || !AppInfoManager.DndAndImportSection.Contains(typeof (WIFI)) || !(FeatureManager.GetFeature(2028)[0] is Motorola.MackinawCPS.CoreFeatures.DataWide.DataWide dataWide) || !(dataWide.WIFI.EmbeddedRecset is ConfiguredNetworksListInnerRecset embeddedRecset))
      return;
    foreach (AcpBusinessLayer.FeatureNode featureNode in (Collection<AcpBusinessLayer.FeatureNode>) embeddedRecset)
    {
      if (featureNode is ConfiguredNetworksListInner networksListInner && AppInfoManager.DndAndImportTask != null && !string.IsNullOrEmpty(networksListInner.ConfiguredNetworksListInnerSection.DataWideWiFiNetworkEncryptedNetworkPassword_42517.UIValue))
        AppInfoManager.DndAndImportTask.AddTask((UndoableTask) new ModifyDataTask<string>((AcpField<string>) networksListInner.ConfiguredNetworksListInnerSection.DataWideWiFiNetworkEncryptedNetworkPassword_42517, networksListInner.ConfiguredNetworksListInnerSection.DataWideWiFiNetworkEncryptedNetworkPassword_42517.DefaultValue));
    }
  }

  private void RefreshZoneChannelRecordsetToolBar()
  {
    try
    {
      if (!(FeatureManager.GetFeature(2051) is ZoneChannelAssignmentRecset feature))
        return;
      foreach (AcpBusinessLayer.FeatureNode featureNode in (Collection<AcpBusinessLayer.FeatureNode>) feature)
      {
        if ((featureNode as Motorola.MackinawCPS.CoreFeatures.ZoneChannelAssignment.ZoneChannelAssignment).Zone.Parent is Motorola.MackinawCPS.CoreFeatures.ZoneChannelAssignment.ZoneChannelAssignment parent && parent.Channels.EmbeddedRecset is ChannelAssignmentListInnerRecset embeddedRecset)
          embeddedRecset.RefreshRecordsetToolBarNonACPMethod();
      }
      feature.RefreshRecordsetToolBarNonACPMethod();
    }
    catch (Exception ex)
    {
    }
  }

  public ApplicationMode CurrentAppMode
  {
    get => AppInfoManager.AppMode;
    set
    {
      if (this.PropertyChanged == null)
        return;
      this.PropertyChanged((object) this, new PropertyChangedEventArgs(nameof (CurrentAppMode)));
    }
  }

  public bool IsCloudNativeMode => Startup.IsCloudNativeMode;

  public PaneItem SelectedNavigationMode
  {
    get => this.selectedNavigationMode;
    set
    {
      this.selectedNavigationMode = value;
      if (this.PropertyChanged == null)
        return;
      this.PropertyChanged((object) this, new PropertyChangedEventArgs(nameof (SelectedNavigationMode)));
    }
  }

  private void OnSystemKeyLoaded(object sender, SystemKeyLoadedEventArgs e)
  {
    if (e.LoadedSpecialKeys.Count > 0)
    {
      this.SpecialKeyLoaded = true;
      this.Pop25Enabled = true;
    }
    else
    {
      foreach (SystemKeyData loadedSystemKey in (Collection<SystemKeyData>) e.LoadedSystemKeys)
      {
        if (loadedSystemKey.OtapEnabled)
        {
          this.Pop25Enabled = true;
          break;
        }
      }
    }
  }

  internal void Init()
  {
    this.SetCPSVersion();
    AcpDocument.RadInfoFeatureID = 2049;
    AcpDocument.RadInfoGenSectionId = 10108;
    AppInfoManager.AppMode = ApplicationMode.CodeplugConfigurationMode;
    AppInfoManager.ClonePageNotLoaded = true;
    this.pageIUI = new AcpIuiPage();
    this.WindowMainFrame.Content = (object) this.pageIUI;
    this.FrameCenterTop.Navigated += new NavigatedEventHandler(this.WinMain_FrameCenterTop_Navigated);
    this.FrameLeft.Navigate(new Uri("PageNavPaneButtons.xaml", UriKind.RelativeOrAbsolute));
    this.FrameStatusBar.Navigate(new Uri("PageStatusBar.xaml", UriKind.RelativeOrAbsolute));
    AppInfoManager.AppInfoHelper.PropertyChanged += new PropertyChangedEventHandler(this.AppInfoHelper_PropertyChanged);
    AcpUI.Common.Utility.FieldReportItemSelectionEvent += new FieldReportItemSelectionEventHandler(this.OnFieldReportItemSelected);
    AcpUI.Common.Utility.DockWindowVisibilityChangedEvent += new DockWindowVisibilityChangedEventHandler(this.OnDockWindowVisibilityChanged);
    AcpUI.Common.Utility.DockWindowAutoRiseChangedEvent += new DockWindowAutoRiseChangedEventHandler(this.OnDockWindowAutoRiseChanged);
    AppInfoManager.StatusMsgReport = new StatusMessagesManager();
    AppInfoManager.FindResultReport = new FindResultsManager();
    AppInfoManager.DndVersionManager = (DragDropVersionManager) new DragDropVersionManagerImp();
    AcpSecurityLib.SecurityManager.SystemKeyLoadedEvent += new SystemKeyLoadedEventHandler(this.OnSystemKeyLoaded);
    this.progressPage = new ProgressUpdate();
    this.commsLastUserState = (object) null;
    MainUIDispatcher.MainDispatcher = this.Dispatcher;
    this.UpdateRibbon();
    this.WindowMainRibbonControl.IsMinimized = !Settings.Default.Ribbon_Maximized;
  }

  public WindowMain()
  {
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    Gibraltar.Agent.Log.Initializing += WindowMain.\u003C\u003EO.\u003C1\u003E__Log_Initializing ?? (WindowMain.\u003C\u003EO.\u003C1\u003E__Log_Initializing = new Gibraltar.Agent.Log.InitializingEventHandler(WindowMain.Log_Initializing));
    Gibraltar.Agent.Log.StartSession();
    if (!(bool) System.Windows.Application.Current.Properties[(object) "CommandLineCPS"])
    {
      this.test = new Semaphore(0, 1, "CBIDisplayWait");
      this.testOTAP = new Semaphore(0, 1, "OTAPDisplayWait");
      this.QueryRadio = new Semaphore(0, 1, "RadioWriteRet");
    }
    this.InitializeComponent();
    this.DataContext = (object) this;
    this.undoHelper = new AcpUndoHelper();
    this.QATUndo.DataContext = (object) this.undoHelper;
    this.QATRedo.DataContext = (object) this.undoHelper;
    this.Init();
    AcpUI.Common.Utility.SetDirection((FrameworkElement) this);
    this.InitAppFlags();
    this.RibbonBarRtdPageRestoreAll.IsEnabled = false;
    this.InitAppView();
    this.CpgOpenFlag = false;
    this.IsFreonProduct = false;
    this.CustomViewOpenFlag = false;
    this.InitDockWindowsStates();
    this.AppColorSchemes = new Dictionary<eAcpColorScheme, ResourceDictionary>();
    this.AppColorSchemes.Add(eAcpColorScheme.ClassicSkin, (ResourceDictionary) new AcpClassicSkin());
    this.AppColorSchemes.Add(eAcpColorScheme.SilverSkin, (ResourceDictionary) new AcpSilverSkin());
    this.AppColorSchemes.Add(eAcpColorScheme.BlackSkin, (ResourceDictionary) new AcpBlackSkin());
    this.AppColorSchemes.Add(eAcpColorScheme.PoliceSkin, (ResourceDictionary) new AcpPoliceSkin());
    this.AppColorSchemes.Add(eAcpColorScheme.FireSkin, (ResourceDictionary) new AcpFiremanSkin());
    this.AppColorSchemes.Add(eAcpColorScheme.MilitarySkin, (ResourceDictionary) new AcpMilitarySkin());
    this.AppColorSchemes.Add(eAcpColorScheme.FullColorSkin, (ResourceDictionary) new AcpFullColorSkin());
    switch (VersionInfoHelper.IsDFlagExisted(DFlagType.DASTRO) ? "MackinawCPS.themes.AcpFullColorSkin" : this.settingsSavedOnAppExit.Color_Theme)
    {
      case "MackinawCPS.themes.AcpClassicSkin":
        this.ChangeControlColorScheme(eAcpColorScheme.ClassicSkin);
        this.ChangeMainFrameColorScheme(eRibbonVisualStyle.Office2007Classic, eDockVisualStyle.Office2007Classic, Colors.Transparent);
        break;
      case "MackinawCPS.themes.AcpSilverSkin":
        this.ChangeControlColorScheme(eAcpColorScheme.SilverSkin);
        this.ChangeMainFrameColorScheme(eRibbonVisualStyle.Office2007Silver, eDockVisualStyle.Office2007Silver, Colors.Transparent);
        break;
      case "MackinawCPS.themes.AcpBlackSkin":
        this.ChangeControlColorScheme(eAcpColorScheme.BlackSkin);
        this.ChangeMainFrameColorScheme(eRibbonVisualStyle.Office2007Black, eDockVisualStyle.Office2007Black, Colors.Transparent);
        break;
      case "MackinawCPS.themes.AcpPoliceSkin":
        this.ChangeControlColorScheme(eAcpColorScheme.PoliceSkin);
        this.ChangeMainFrameColorScheme(eRibbonVisualStyle.Office2007Police, eDockVisualStyle.Office2007Police, Colors.Transparent);
        break;
      case "MackinawCPS.themes.AcpFiremanSkin":
        this.ChangeControlColorScheme(eAcpColorScheme.FireSkin);
        this.ChangeMainFrameColorScheme(eRibbonVisualStyle.Office2007Fireman, eDockVisualStyle.Office2007Fireman, Colors.Transparent);
        break;
      case "MackinawCPS.themes.AcpMilitarySkin":
        this.ChangeControlColorScheme(eAcpColorScheme.MilitarySkin);
        this.ChangeMainFrameColorScheme(eRibbonVisualStyle.Office2007Military, eDockVisualStyle.Office2007Military, Colors.Transparent);
        break;
      case "MackinawCPS.themes.AcpFullColorSkin":
        this.ChangeControlColorScheme(eAcpColorScheme.FullColorSkin);
        this.ChangeMainFrameColorScheme(eRibbonVisualStyle.Office2007FullColor, eDockVisualStyle.Office2007FullColor, Colors.Transparent);
        break;
      default:
        this.ChangeControlColorScheme(eAcpColorScheme.ClassicSkin);
        this.ChangeMainFrameColorScheme(eRibbonVisualStyle.Office2007Classic, eDockVisualStyle.Office2007Classic, Colors.Transparent);
        break;
    }
    if (string.IsNullOrEmpty(this.settingsSavedOnAppExit.KeyFiles_Default_Folder))
    {
      this.defaultKeyFilesLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Motorola\\SysKeys");
      if (!Directory.Exists(this.defaultKeyFilesLocation))
        this.defaultKeyFilesLocation = Directory.GetCurrentDirectory();
    }
    else
      this.defaultKeyFilesLocation = this.settingsSavedOnAppExit.KeyFiles_Default_Folder;
    this.defaultDVRSFileLocation = !string.IsNullOrEmpty(this.settingsSavedOnAppExit.DVRS_Export_Default_Folder) ? this.settingsSavedOnAppExit.DVRS_Export_Default_Folder : Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Motorola\\ApxFamilyCPS\\Common\\DVRS");
    UtilityMack.fireDVRSXMLProperty = new UtilityMack.FireDVRSXMLPropertychanged(this.FirePropertyChanged);
    UtilityMack.DVRSExportPath = this.defaultDVRSFileLocation;
    ACPBrowser.Utility.HelpRootDirRelative = !string.IsNullOrEmpty(this.settingsSavedOnAppExit.SelectedHelpLanguage_RootDir) ? this.settingsSavedOnAppExit.SelectedHelpLanguage_RootDir : $"Help\\{App.AdditionalCPSLanguages.DefaultCPSLanguage}\\";
    ACPBrowser.Utility.HelpRootDir = AppDomain.CurrentDomain.BaseDirectory + ACPBrowser.Utility.HelpRootDirRelative;
    string path = this.settingsSavedOnAppExit.OpenCodeplugFilePath;
    if (string.IsNullOrEmpty(path) || !Directory.Exists(path))
      path = AppDomain.CurrentDomain.BaseDirectory;
    try
    {
      ((App) System.Windows.Application.Current).TheDocument.docFileName = Path.GetFileName(path);
      ((App) System.Windows.Application.Current).TheDocument.docFilePath = Path.GetFullPath(path);
    }
    catch (ArgumentException ex)
    {
      ((App) System.Windows.Application.Current).TheDocument.docFileName = string.Empty;
      ((App) System.Windows.Application.Current).TheDocument.docFilePath = AppDomain.CurrentDomain.BaseDirectory;
    }
    catch (PathTooLongException ex)
    {
      ((App) System.Windows.Application.Current).TheDocument.docFileName = string.Empty;
      ((App) System.Windows.Application.Current).TheDocument.docFilePath = AppDomain.CurrentDomain.BaseDirectory;
    }
    catch (NotSupportedException ex)
    {
      ((App) System.Windows.Application.Current).TheDocument.docFileName = string.Empty;
      ((App) System.Windows.Application.Current).TheDocument.docFilePath = AppDomain.CurrentDomain.BaseDirectory;
    }
    string commandLineArgument = ((App) System.Windows.Application.Current).CommandLineArgument;
    if (!string.IsNullOrEmpty(commandLineArgument) && commandLineArgument == "-init")
      System.Windows.Application.Current.Shutdown();
    if (!this.IsNotVertexRadio)
    {
      this.ribbonBarReadFlashKeyCfg.IsEnabled = false;
      this.ribbonBarFlashRadio.IsEnabled = false;
    }
    LanguagePackHelper.UpgradRadioLangSetting = this.settingsSavedOnAppExit.UpgradeRadioLang <= -1 || this.settingsSavedOnAppExit.UpgradeRadioLang >= 3 ? 0 : this.settingsSavedOnAppExit.UpgradeRadioLang;
    string lower = Thread.CurrentThread.CurrentCulture.Name.ToLower();
    if (lower.StartsWith("ar"))
    {
      this.AppMruList.FlowDirection = System.Windows.FlowDirection.LeftToRight;
      this.AppMruList.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Right;
      this.FindToken.Language = XmlLanguage.GetLanguage(lower);
    }
    if (VersionInfoHelper.IsDFlagExisted(DFlagType.DASTRO))
    {
      BitmapImage bitmapImage = new BitmapImage();
      bitmapImage.BeginInit();
      bitmapImage.UriSource = new Uri("../../icons/vertexBatwings.png", UriKind.Relative);
      bitmapImage.EndInit();
      this.imgRibbonAppMenu.Source = (ImageSource) bitmapImage;
      this.imgRibbonAppMenu.Height = 37.0;
      this.imgRibbonAppMenu.Width = 37.0;
      this.imgRibbonAppMenu.Margin = new Thickness(1.0, 0.0, 0.0, 0.0);
      (this.DiffViewType.Items[3] as ComboBoxItem).ToolTip = (object) AppResources.Vertex_Should_only_be_selected_under_guidance;
    }
    this._readWritePasswordApp = ReadWritePasswordApp.GetInstance();
    this._tlsPskHelper = new ReadWriteTlsPskHelper();
    this._readWriteUtil = new ReadWriteUtil();
  }

  private static void Log_Initializing(object sender, LogInitializingEventArgs e)
  {
    WindowMain mainWindow = (WindowMain) System.Windows.Application.Current.MainWindow;
    if (!(bool) System.Windows.Application.Current.Properties[(object) "CommandLineCPS"] && mainWindow.settingsSavedOnAppExit.UploadToServer)
      return;
    e.Cancel = true;
  }

  private void InitAppFlags()
  {
    AppInfoManager.GuiVersion = 0;
    AppInfoManager.AppHideMatches = false;
    AppInfoManager.ShowRtdButtons = false;
  }

  private void InitAppView()
  {
    AppInfoManager.AppView = DifferentiatedUserViewType.Full;
    this.DiffViewType.SelectedIndex = 2;
    this.currentAppViewInfo = this.DiffViewType.SelectedItem;
  }

  protected override void OnContentRendered(EventArgs e)
  {
    base.OnContentRendered(e);
    App current = (App) System.Windows.Application.Current;
    if (this.bCloseSplashScreen)
    {
      this.bCloseSplashScreen = false;
      if (current.Properties.Contains((object) "splashScreen"))
      {
        if (current.Properties[(object) "splashScreen"] is MackinawCPS.InitializationScreen.SplashScreen property)
        {
          property.CloseWindow(false);
          this.Activate();
        }
        current.Properties.Remove((object) "splashScreen");
      }
    }
    if (!(bool) System.Windows.Application.Current.Properties[(object) "CommandLineCPS"] && !(bool) System.Windows.Application.Current.Properties[(object) "AutoTestMode"] && !this.IsCloudNativeMode)
    {
      LogSetting logSetting = new LogSetting();
      logSetting.RestartOption = RestartOptions.Now;
      logSetting.HideDialogChecked = this.settingsSavedOnAppExit.HideLogUploadDialog;
      logSetting.UploadToServer = this.settingsSavedOnAppExit.UploadToServer;
      if (!logSetting.UploadToServer && !logSetting.HideDialogChecked)
        this.ShowUpdateLogSetting(logSetting);
    }
    try
    {
      if (AcpSecurityLib.SecurityManager.LoadAllKeys(this.defaultKeyFilesLocation, false) > 0)
      {
        this.AppMenuWriteProtect.IsEnabled = false;
        if (!this.settingsSavedOnAppExit.BottomPanelAutoHide)
          this.pageIUI.OpenDockWindow(DockWndType.SysKeyRpt);
        if (!this.CpgOpenFlag)
          this.CheckForUnlimited();
      }
    }
    catch (AccessViolationException ex)
    {
      AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Warning, AppResources.One_Wire_Bus_Busy);
    }
    string commandLineArgument = current.CommandLineArgument;
    if (!string.IsNullOrEmpty(commandLineArgument))
      this.ProcessCommandLine(commandLineArgument);
    if (!(bool) System.Windows.Application.Current.Properties[(object) "CommandLineCPS"])
    {
      try
      {
        IDeviceManager instance = DeviceManagerSingleTon.Instance;
      }
      catch (CommonException ex)
      {
        int num = (int) System.Windows.MessageBox.Show(Motorola.CommonCPS.ResourceRepository.ResourceHelper.GetCommonErrorMessageByID(ex.ErrorCode.ToString()), AppResources.APX_CPS);
      }
      catch (Exception ex)
      {
        int num = (int) System.Windows.MessageBox.Show(Motorola.CommonCPS.ResourceRepository.ResourceHelper.GetCommonErrorMessageByID(CommonErrorCode.CommunicationServiceNotAvailabe.ToString()), AppResources.APX_CPS);
      }
    }
    this.WindowMain_AllowDrop((object) null, (System.Windows.Input.MouseEventArgs) null);
    Keyboard.Focus((IInputElement) this);
    WindowMain mainWindow = (WindowMain) System.Windows.Application.Current.MainWindow;
    if (!this.settingsSavedOnAppExit.FieldInfoWindowAutoHidden && this.settingsSavedOnAppExit.FieldInfoVisible)
      mainWindow.pageIUI.PopupDockWindow(DockWndType.HelpInfo);
    this.pageIUI.GetDockWindow(DockWndType.SysKeyRpt).IsAutoHide = true;
    if (!this.IsCloudNativeMode || App.CloudNativeUtility == null)
      return;
    this.AllowDrop = false;
    App.CloudNativeUtility.OpenCodeplugForCloudNativeMode();
    if (!this.CpgOpenFlag)
      return;
    this.pageIUI.OpenDockWindow(DockWndType.Naviagtion);
  }

  private void SetCPSVersion()
  {
    try
    {
      this.cpsVersion = "R36.00.01";
      object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof (AssemblyDescriptionAttribute), false);
      if (customAttributes != null && customAttributes.Length != 0 && customAttributes[0] is AssemblyDescriptionAttribute descriptionAttribute && descriptionAttribute.Description != null && descriptionAttribute.Description.Length > 0)
        this.cpsVersion = descriptionAttribute.Description;
      HelpAboutCPSWnd.CPS_Version = this.cpsVersion;
      AppInfoManager.AppVersion = this.cpsVersion;
    }
    catch (Exception ex)
    {
      int num = (int) System.Windows.MessageBox.Show(AppResources.Invalid_CPS_version);
      throw;
    }
  }

  private void ProcessCommandLine(string arg1)
  {
    if (string.IsNullOrEmpty(arg1) || arg1.StartsWith("/") || arg1.StartsWith("-") || !arg1.EndsWith(".mc") && !arg1.EndsWith(".cxf", StringComparison.OrdinalIgnoreCase))
      return;
    this.OpenCodeplug(Path.GetFullPath(arg1));
  }

  internal void onExitApp(object sender, CancelEventArgs e)
  {
    AcpDocument theDocument = ((App) System.Windows.Application.Current).TheDocument;
    bool flag = true;
    string docFileName = ((App) System.Windows.Application.Current).TheDocument.docFileName;
    string docFilePath = ((App) System.Windows.Application.Current).TheDocument.docFilePath;
    AcpReportMgrLib.CleanReportsTempFiles();
    if (AppInfoManager.AppMode == ApplicationMode.CustomViewConfigurationMode)
    {
      if (System.Windows.MessageBox.Show(AppResources.Are_you_sure_you_exit_Custom_View_Mode_Unsaved_changes_will_lost_pls_ensure_save, AppResources.Custom_View_Configuration_Mode_Warning, MessageBoxButton.YesNo) == MessageBoxResult.Yes)
      {
        this.SaveCurrentColorTheme();
        Gibraltar.Agent.Log.EndSession();
        System.Windows.Application.Current.Shutdown();
        Environment.Exit(0);
      }
      else
      {
        e.Cancel = true;
        return;
      }
    }
    if (this.IsCloudNativeMode)
    {
      AcpUI.Common.Utility.SaveFieldWithFocus();
      if (theDocument.IsDirty)
      {
        if (MyMessageBox.Show(AppResources.Close_Without_Publish, AppResources.APX_CPS, MessageBoxButton.YesNo, MessageBoxImage.Exclamation, MessageBoxResult.Yes) == MessageBoxResult.Yes)
          this.CloseFile();
        else
          e.Cancel = true;
      }
      else
        this.CloseFile();
    }
    if (theDocument.IsDirty && !(bool) System.Windows.Application.Current.Properties[(object) "CommandLineCPS"] && !App.ExportXMLCommandMode && !this.IsCloudNativeMode)
    {
      switch (MyMessageBox.Show(AppResources.Save_changes_to_file.AcpStringFormat((object) docFileName), AppResources.APX_CPS, MessageBoxButton.YesNoCancel, MessageBoxImage.Exclamation, MessageBoxResult.Yes))
      {
        case MessageBoxResult.Cancel:
          e.Cancel = true;
          break;
        case MessageBoxResult.Yes:
          RoutedEventArgs e1 = new RoutedEventArgs();
          this.bSaveCpgSuccessful = false;
          if (docFilePath != null && (File.GetAttributes(docFilePath) & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
            this.OnAppMenuSaveAs(sender, e1);
          else
            this.OnAppMenuSave(sender, e1);
          if (!this.bSaveCpgSuccessful)
          {
            flag = false;
            e.Cancel = true;
            break;
          }
          break;
      }
    }
    if (!(!e.Cancel & flag))
      return;
    try
    {
      string path = string.Empty;
      if (((App) System.Windows.Application.Current).TheDocument.docFilePath != null)
        path = Path.GetDirectoryName(((App) System.Windows.Application.Current).TheDocument.docFilePath);
      else if (this.lastOpenCodePlugPath != string.Empty)
        path = this.lastOpenCodePlugPath;
      if (!string.IsNullOrEmpty(path))
      {
        if (Directory.Exists(path))
        {
          if ((int) path[path.Length - 1] != (int) Path.DirectorySeparatorChar)
            path += Path.DirectorySeparatorChar.ToString();
          this.settingsSavedOnAppExit.OpenCodeplugFilePath = path;
        }
      }
    }
    catch (ArgumentException ex)
    {
      this.settingsSavedOnAppExit.OpenCodeplugFilePath = AppDomain.CurrentDomain.BaseDirectory;
    }
    catch (PathTooLongException ex)
    {
      this.settingsSavedOnAppExit.OpenCodeplugFilePath = AppDomain.CurrentDomain.BaseDirectory;
    }
    catch (NotSupportedException ex)
    {
      this.settingsSavedOnAppExit.OpenCodeplugFilePath = AppDomain.CurrentDomain.BaseDirectory;
    }
    if (!(bool) System.Windows.Application.Current.Properties[(object) "CommandLineCPS"])
    {
      this.SaveCurrentColorTheme();
      this.SaveKeyFileLocation();
      this.SaveDockWindowsState();
    }
    Gibraltar.Agent.Log.EndSession();
    System.Windows.Application.Current.Shutdown();
    Environment.Exit(0);
  }

  internal void SaveCurrentColorTheme()
  {
    this.settingsSavedOnAppExit.Color_Theme = this.AppColorSchemes[this.currentColorTheme].ToString();
    try
    {
      this.settingsSavedOnAppExit.Save();
    }
    catch (Exception ex)
    {
      AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, ex.Message);
    }
  }

  private void SaveKeyFileLocation()
  {
    this.settingsSavedOnAppExit.KeyFiles_Default_Folder = this.defaultKeyFilesLocation;
    try
    {
      this.settingsSavedOnAppExit.Save();
    }
    catch (Exception ex)
    {
      AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, ex.Message);
    }
  }

  private void InitDockWindowsStates()
  {
    try
    {
      this.pageIUI.InitDockWindowState(DockWndType.Output, this.settingsSavedOnAppExit.OutputWindowVisible, this.settingsSavedOnAppExit.OutputWindowAutoRise);
      this.pageIUI.InitDockWindowState(DockWndType.InvalidFields, this.settingsSavedOnAppExit.InvalidFieldWindowVisible, this.settingsSavedOnAppExit.InvalidFieldWindowAutoRise);
      this.pageIUI.InitDockWindowState(DockWndType.DnD, this.settingsSavedOnAppExit.DnDWindowVisible, this.settingsSavedOnAppExit.DnDWindowAutoRise);
      this.pageIUI.InitDockWindowState(DockWndType.Comparator, this.settingsSavedOnAppExit.ComparatorWindowVisible, this.settingsSavedOnAppExit.ComparatorWindowAutoRise);
      this.pageIUI.InitDockWindowState(DockWndType.ImpExp, this.settingsSavedOnAppExit.ImpExpWindowVisible, this.settingsSavedOnAppExit.ImpExpWindowAutoRise);
      this.pageIUI.InitDockWindowState(DockWndType.SysKeyRpt, this.settingsSavedOnAppExit.SystemKeyWindowVisible, this.settingsSavedOnAppExit.SystemKeyWindowAutoRise);
      this.pageIUI.InitDockWindowState(DockWndType.FindResults, this.settingsSavedOnAppExit.FindResultWindowVisible, this.settingsSavedOnAppExit.FindResultWindowAutoRise);
      if (this.IsCloudNativeMode)
        this.pageIUI.InitDockWindowState(DockWndType.Naviagtion, false, false);
      else
        this.pageIUI.InitDockWindowState(DockWndType.Naviagtion, this.settingsSavedOnAppExit.NavigationWindowVisible, true);
      this.pageIUI.InitDockWindowState(DockWndType.HelpInfo, this.settingsSavedOnAppExit.FieldInfoVisible, true);
      this.pageIUI.InitDockWindowState(DockWndType.FillUpFillDown, this.settingsSavedOnAppExit.FillUpFillDownWindowVisible, this.settingsSavedOnAppExit.FillUpFillDownWindowAutoRise);
    }
    catch (Exception ex)
    {
    }
  }

  private void SaveDockWindowsState()
  {
    bool bVisibile = true;
    bool bAutoRise = true;
    bool bAutoHide = true;
    try
    {
      this.pageIUI.GetDockWindowState(DockWndType.Output, out bVisibile, out bAutoRise, out bAutoHide);
      this.settingsSavedOnAppExit.OutputWindowVisible = bVisibile;
      this.settingsSavedOnAppExit.OutputWindowAutoRise = bAutoRise;
      this.settingsSavedOnAppExit.BottomPanelAutoHide = bAutoHide;
      this.pageIUI.GetDockWindowState(DockWndType.InvalidFields, out bVisibile, out bAutoRise, out bAutoHide);
      this.settingsSavedOnAppExit.InvalidFieldWindowVisible = bVisibile;
      this.settingsSavedOnAppExit.InvalidFieldWindowAutoRise = bAutoRise;
      this.pageIUI.GetDockWindowState(DockWndType.DnD, out bVisibile, out bAutoRise, out bAutoHide);
      this.settingsSavedOnAppExit.DnDWindowVisible = bVisibile;
      this.settingsSavedOnAppExit.DnDWindowAutoRise = bAutoRise;
      this.pageIUI.GetDockWindowState(DockWndType.Comparator, out bVisibile, out bAutoRise, out bAutoHide);
      this.settingsSavedOnAppExit.ComparatorWindowVisible = bVisibile;
      this.settingsSavedOnAppExit.ComparatorWindowAutoRise = bAutoRise;
      this.pageIUI.GetDockWindowState(DockWndType.ImpExp, out bVisibile, out bAutoRise, out bAutoHide);
      this.settingsSavedOnAppExit.ImpExpWindowVisible = bVisibile;
      this.settingsSavedOnAppExit.ImpExpWindowAutoRise = bAutoRise;
      this.pageIUI.GetDockWindowState(DockWndType.SysKeyRpt, out bVisibile, out bAutoRise, out bAutoHide);
      this.settingsSavedOnAppExit.SystemKeyWindowVisible = bVisibile;
      this.settingsSavedOnAppExit.SystemKeyWindowAutoRise = bAutoRise;
      this.pageIUI.GetDockWindowState(DockWndType.FindResults, out bVisibile, out bAutoRise, out bAutoHide);
      this.settingsSavedOnAppExit.FindResultWindowVisible = bVisibile;
      this.settingsSavedOnAppExit.FindResultWindowAutoRise = bAutoRise;
      if (!this.IsCloudNativeMode)
      {
        this.pageIUI.GetDockWindowState(DockWndType.Naviagtion, out bVisibile, out bAutoRise, out bAutoHide);
        this.settingsSavedOnAppExit.NavigationWindowVisible = bVisibile;
      }
      this.pageIUI.GetDockWindowState(DockWndType.HelpInfo, out bVisibile, out bAutoRise, out bAutoHide);
      this.settingsSavedOnAppExit.FieldInfoVisible = bVisibile;
      this.pageIUI.GetDockWindowState(DockWndType.FillUpFillDown, out bVisibile, out bAutoRise, out bAutoHide);
      this.settingsSavedOnAppExit.FillUpFillDownWindowVisible = bVisibile;
      this.settingsSavedOnAppExit.FillUpFillDownWindowAutoRise = bAutoRise;
      this.settingsSavedOnAppExit.FieldInfoWindowAutoHidden = this.pageIUI.IsDockWindowAutoHide(DockWndType.HelpInfo);
    }
    catch
    {
    }
    try
    {
      this.settingsSavedOnAppExit.Save();
    }
    catch
    {
    }
  }

  internal void OnDockWindowAutoRiseChanged(object sender, DockWindowAutoRiseChangedEventArgs e)
  {
    AcpCheckBox acpCheckBox = (AcpCheckBox) null;
    switch (((FrameworkElement) sender).Name)
    {
      case "OutputDockWnd":
        acpCheckBox = this.wndErrorListAutoRiseCB;
        break;
      case "InvalidFieldsDockWnd":
        acpCheckBox = this.wndInvalidFieldsAutoRiseCB;
        break;
      case "DnDDockWnd":
        acpCheckBox = this.wndDnDReportAutoRiseCB;
        break;
      case "ImpExpDockWnd":
        acpCheckBox = this.wndImpExpReportAutoRiseCB;
        break;
      case "ComparatorDockWnd":
        acpCheckBox = this.wndComparatorReportAutoRiseCB;
        break;
      case "FindResultsDockWnd":
        acpCheckBox = this.wndFindResultsAutoRiseCB;
        break;
      case "SysKeyReportWnd":
        acpCheckBox = this.wndSysKeyRptAutoRiseCB;
        break;
      case "FillUpFillDownDockWnd":
        acpCheckBox = this.wndFillUpFillDownReportAutoRiseCB;
        break;
    }
    if (acpCheckBox == null)
      return;
    if (!e.IsAutoRiseEnabled)
      acpCheckBox.IsChecked = new bool?(false);
    else
      acpCheckBox.IsChecked = new bool?(true);
  }

  internal void OnDockWindowVisibilityChanged(object sender, DockWindowVisibilityChangedEventArgs e)
  {
    AcpCheckBox acpCheckBox = (AcpCheckBox) null;
    switch (((FrameworkElement) sender).Name)
    {
      case "NavWindowDockWnd":
        acpCheckBox = this.wndNavigationHideCB;
        break;
      case "OutputDockWnd":
        acpCheckBox = this.wndErrorListHideCB;
        break;
      case "InvalidFieldsDockWnd":
        acpCheckBox = this.wndInvalidFieldsHideCB;
        break;
      case "DnDDockWnd":
        acpCheckBox = this.wndDnDReportHideCB;
        break;
      case "ImpExpDockWnd":
        acpCheckBox = this.wndImpExpReportHideCB;
        break;
      case "ComparatorDockWnd":
        acpCheckBox = this.wndComparatorReportHideCB;
        break;
      case "FindResultsDockWnd":
        acpCheckBox = this.wndFindResultsHideCB;
        break;
      case "SysKeyReportWnd":
        acpCheckBox = this.wndSysKeyRptHideCB;
        break;
      case "TaskWindowDockWnd":
        acpCheckBox = this.wndFieldInfoHideCB;
        break;
      case "FillUpFillDownDockWnd":
        acpCheckBox = this.wndFillUpFillDownReportHideCB;
        break;
    }
    if (acpCheckBox == null)
      return;
    if (e.IsVisible)
      acpCheckBox.IsChecked = new bool?(false);
    else
      acpCheckBox.IsChecked = new bool?(true);
  }

  internal void OnFieldReportItemSelected(object sender, FieldItemSelectionEventArgs e)
  {
    if (e.Field.FieldType == FieldInfoType.Field)
    {
      if (e.Field == null || e.Field.Field == null || e.Field.Field is AcpFieldBase && ((AcpFieldBase) e.Field.Field).HiddenStatic)
        return;
      if (e.Field.Field is AcpFieldBase && ((AcpFieldBase) e.Field.Field).HiddenDynamic)
      {
        switch (e.Field.Field.DifferentiatedUserView)
        {
          case DifferentiatedUserViewType.Basic:
            this.DiffViewType.SelectedIndex = 0;
            this.currentAppViewInfo = this.DiffViewType.SelectedItem;
            break;
          case DifferentiatedUserViewType.Intermediate:
            this.DiffViewType.SelectedIndex = 1;
            this.currentAppViewInfo = this.DiffViewType.SelectedItem;
            break;
          case DifferentiatedUserViewType.Full:
            this.DiffViewType.SelectedIndex = 2;
            this.currentAppViewInfo = this.DiffViewType.SelectedItem;
            break;
          case DifferentiatedUserViewType.Secret:
            this.DiffViewType.SelectedIndex = 3;
            this.currentAppViewInfo = this.DiffViewType.SelectedItem;
            break;
          case DifferentiatedUserViewType.Depot:
            return;
          case DifferentiatedUserViewType.Labtool:
            if (AppInfoManager.AppType == AcpCommonLib.ApplicationType.LABTOOL)
            {
              this.DiffViewType.SelectedIndex = 4;
              this.currentAppViewInfo = this.DiffViewType.SelectedItem;
              break;
            }
            break;
          default:
            return;
        }
      }
      IAcpFeatureSection section = e.Field.Field.Parent;
      if (e.Field.Field.NewParent != null && e.Field.Field.Parent.Parent != null)
      {
        foreach (IAcpFeatureSection featureSections in e.Field.Field.Parent.Parent.FeatureSectionsCollection)
        {
          if (featureSections == e.Field.Field.NewParent)
          {
            section = featureSections;
            break;
          }
        }
      }
      if (section.ParentRecset.IsEmbeddedRecset)
        section = section.ParentRecset.ParentSection;
      if (section is URLTableInnerSection)
        section = (IAcpFeatureSection) (FeatureManager.GetFeature(2028)[0] as Motorola.MackinawCPS.CoreFeatures.DataWide.DataWide).WebBrowser;
      this.LaunchSection(section);
    }
    else
    {
      if (e.Field.FieldType != FieldInfoType.Record || e.Field == null || e.Field.Node == null)
        return;
      if (e.Field.Node.Parent.IsEmbeddedRecset)
        this.LaunchSection(e.Field.Node.Parent.ParentSection);
      else
        this.LaunchParentPage(e.Field.Node);
    }
  }

  internal void LaunchSection(IAcpFeatureSection section)
  {
    PageNavPaneButtons content = (PageNavPaneButtons) ((WindowMain) System.Windows.Application.Current.MainWindow).FrameLeft.Content;
    content.ButtonCpgNav.IsSelected = true;
    ((AcpTreeView) ((Page) content.GetSelectedItemContent()).Content).LaunchSection(section);
  }

  internal void LaunchParentPage(IAcpFeatureNode node)
  {
    if (node == null || node.Parent.IsEmbeddedRecset)
      return;
    string uiPagePath = node.Parent.UIPagePath;
    if (uiPagePath == null)
      return;
    PageNavPaneButtons content = (PageNavPaneButtons) ((WindowMain) System.Windows.Application.Current.MainWindow).FrameLeft.Content;
    content.ButtonCpgNav.IsSelected = true;
    ((AcpTreeView) ((Page) content.GetSelectedItemContent()).Content).LaunchPage(uiPagePath);
  }

  public void OnPrtRadioInfoReports(object sender, RoutedEventArgs e)
  {
    ReportsDialog repDia = new ReportsDialog(this);
    this.DisableAllReportsDialogClick(repDia);
    repDia.Is_RadioInfo_Clicked = true;
    this.GenerateReportByReportType(repDia, reportType.RadioInfo);
  }

  public void OnPrtHandOutReports(object sender, RoutedEventArgs e)
  {
    ReportsDialog repDia = new ReportsDialog(this);
    this.DisableAllReportsDialogClick(repDia);
    repDia.Is_PorHandout_Clicked = true;
    if (!UtilityMack.IsPortable())
      return;
    this.GenerateReportByReportType(repDia, reportType.HandOut);
  }

  public void OnPrtHandOutReportsO2(object sender, RoutedEventArgs e)
  {
    ReportsDialog repDia = new ReportsDialog(this);
    this.DisableAllReportsDialogClick(repDia);
    repDia.Is_O2Handout_Clicked = true;
    if (!UtilityMack.IsMobile())
      return;
    this.GenerateReportByReportType(repDia, reportType.HandOutO2);
  }

  private void DisableAllReportsDialogClick(ReportsDialog repDia)
  {
    repDia.Is_RadioInfo_Clicked = false;
    repDia.Is_PorHandout_Clicked = false;
    repDia.Is_O2Handout_Clicked = false;
    repDia.Is_O3Handout_Clicked = false;
    repDia.Is_O7Handout_Clicked = false;
    repDia.Is_E5Handout_Clicked = false;
    repDia.Is_O5Handout_Clicked = false;
    repDia.Is_O9Handout_Clicked = false;
  }

  private void GenerateReportByReportType(ReportsDialog repDia, reportType repType)
  {
    AcpReportMgrLib acpReportMgrLib = new AcpReportMgrLib();
    string empty = string.Empty;
    if (this.settingsSavedOnAppExit.ReportLangDia)
    {
      repDia.ShowInTaskbar = false;
      repDia.Owner = (Window) this;
      repDia.ResizeMode = ResizeMode.NoResize;
      repDia.ShowDialog();
    }
    else
    {
      AppInfoManager.ReportsLangSelection = string.IsNullOrEmpty(this.settingsSavedOnAppExit.UserSelectedReportsLanguage) ? "en" : this.settingsSavedOnAppExit.UserSelectedReportsLanguage;
      acpReportMgrLib.GenerateReport(repType);
    }
  }

  public void OnPrtHandOutReportsO3(object sender, RoutedEventArgs e)
  {
    ReportsDialog repDia = new ReportsDialog(this);
    this.DisableAllReportsDialogClick(repDia);
    repDia.Is_O3Handout_Clicked = true;
    if (!UtilityMack.IsMobile())
      return;
    this.GenerateReportByReportType(repDia, reportType.HandOutO3);
  }

  public void OnPrtHandOutReportsO7(object sender, RoutedEventArgs e)
  {
    ReportsDialog repDia = new ReportsDialog(this);
    this.DisableAllReportsDialogClick(repDia);
    repDia.Is_O7Handout_Clicked = true;
    if (!UtilityMack.IsMobile())
      return;
    this.GenerateReportByReportType(repDia, reportType.HandOutO7);
  }

  public void OnPrtHandOutReportsE5(object sender, RoutedEventArgs e)
  {
    ReportsDialog repDia = new ReportsDialog(this);
    this.DisableAllReportsDialogClick(repDia);
    repDia.Is_E5Handout_Clicked = true;
    if (!UtilityMack.IsMobile())
      return;
    this.GenerateReportByReportType(repDia, reportType.HandOutE5);
  }

  public void OnPrtHandOutReportsO5(object sender, RoutedEventArgs e)
  {
    ReportsDialog repDia = new ReportsDialog(this);
    this.DisableAllReportsDialogClick(repDia);
    repDia.Is_O5Handout_Clicked = true;
    if (!UtilityMack.IsMobile())
      return;
    this.GenerateReportByReportType(repDia, reportType.HandOutO5);
  }

  public void OnPrtHandOutReportsO9(object sender, RoutedEventArgs e)
  {
    ReportsDialog repDia = new ReportsDialog(this);
    this.DisableAllReportsDialogClick(repDia);
    repDia.Is_O9Handout_Clicked = true;
    if (!UtilityMack.IsMobile())
      return;
    this.GenerateReportByReportType(repDia, reportType.HandOutO9);
  }

  public void OnPrtChoicesReports(object sender, RoutedEventArgs e)
  {
    AcpUI.Common.Utility.SaveFieldWithFocus();
    foreach (IAcpConstraints feature in FeatureManager.Features)
      feature.CalculateVisibility(true);
    new AcpReportMgrLib() { ParentWnd = ((Window) this) }.GenerateReport(reportType.Choices);
  }

  private bool ValidCodeplugVersion(byte[] partitionArr)
  {
    bool flag = false;
    int length = partitionArr.Length;
    int num1 = 1025;
    int num2;
    int num3;
    for (int index1 = 0; index1 < length; index1 = num2 + num3)
    {
      byte[] numArray1 = partitionArr;
      int index2 = index1;
      int num4 = index2 + 1;
      int num5 = (int) numArray1[index2] << 8;
      byte[] numArray2 = partitionArr;
      int index3 = num4;
      int num6 = index3 + 1;
      int num7 = (int) numArray2[index3];
      int num8 = num5 | num7;
      int num9 = num6 + 2;
      byte[] numArray3 = partitionArr;
      int index4 = num9;
      int num10 = index4 + 1;
      int num11 = (int) numArray3[index4] << 8;
      byte[] numArray4 = partitionArr;
      int index5 = num10;
      num2 = index5 + 1;
      int num12 = (int) numArray4[index5];
      num3 = num11 | num12;
      int num13 = num1;
      if (num8 == num13)
      {
        int index6 = num2 + 1 + 74;
        flag = AcpDocument.ValidCodeplugVersion(Encoding.BigEndianUnicode.GetString(partitionArr, index6, 26).Trim(new char[1]));
        break;
      }
    }
    return flag;
  }

  internal bool OpenByteArray(string sFileName, bool decrypt)
  {
    string str = "";
    bool flag1 = false;
    byte[] sourceArray = (byte[]) null;
    AcpFileHandler acpFileHandler = new AcpFileHandler();
    string modelNumber = string.Empty;
    ref byte[] local = ref sourceArray;
    string filePath = sFileName;
    int num1 = decrypt ? 1 : 0;
    acpFileHandler.ReadFile(out local, filePath, num1 != 0, (string) null);
    if (sourceArray != null && sourceArray.GetLength(0) > 0)
    {
      bool flag2 = false;
      Dictionary<int, byte[]> rawPartitions = new Dictionary<int, byte[]>();
      int int32;
      for (int sourceIndex = 0; sourceIndex < sourceArray.Length; sourceIndex = sourceIndex + 14 + int32 - 1 + 1)
      {
        byte[] numArray1 = new byte[9];
        Array.Copy((Array) sourceArray, sourceIndex, (Array) numArray1, 0, numArray1.Length);
        if (new ASCIIEncoding().GetString(numArray1) != "PARTITION")
        {
          flag2 = true;
          break;
        }
        int key = (int) sourceArray[sourceIndex + 9];
        switch (key)
        {
          case 0:
          case 1:
          case 2:
            byte[] destinationArray = new byte[4];
            Array.Copy((Array) sourceArray, sourceIndex + 10, (Array) destinationArray, 0, destinationArray.Length);
            if (BitConverter.IsLittleEndian)
              Array.Reverse((Array) destinationArray);
            int32 = BitConverter.ToInt32(destinationArray, 0);
            if (int32 > sourceArray.Length || int32 <= 0)
            {
              flag2 = true;
              goto label_16;
            }
            byte[] numArray2 = new byte[int32];
            Array.Copy((Array) sourceArray, sourceIndex + 14, (Array) numArray2, 0, numArray2.Length);
            if (key == 2)
              modelNumber = this.GetModelNumber(numArray2);
            if (key == 0 && !this.ValidCodeplugVersion(numArray2))
            {
              flag2 = true;
              str = AppResources.Error_Opening_pba_file + AcpDocument.CpgVersionErrStr;
              goto label_16;
            }
            rawPartitions.Add(key, numArray2);
            continue;
          default:
            flag2 = true;
            goto label_16;
        }
      }
label_16:
      if (!flag2)
      {
        try
        {
          new PackUnpackExecutor().Unpack(rawPartitions, modelNumber);
          flag1 = true;
        }
        catch (Exception ex)
        {
          int num2 = (int) System.Windows.MessageBox.Show(AppResources.Unable_to_unpack_codeplug_image, AppResources.Open_Byte_Array_File, MessageBoxButton.OK);
          AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, AppResources.Unable_to_unpack_codeplug_image);
        }
      }
      else
      {
        if (str == "")
        {
          string selectedIsNotValid = AppResources.The_pba_file_selected_is_not_valid;
        }
        int num3 = (int) System.Windows.MessageBox.Show(AppResources.The_pba_file_selected_is_not_valid, AppResources.Open_Byte_Array_File, MessageBoxButton.OK);
        flag1 = false;
      }
    }
    return flag1;
  }

  internal bool SavePackedByteArray(string sFilePath, AcpFileHeader fileHeader, bool encrypt)
  {
    bool flag = false;
    if (sFilePath != null)
    {
      if (this.CpgOpenFlag)
      {
        if (this.PromptQuitOnInvalids().Result)
          return false;
        Motorola.Acp.PackUnpack.Ish.Codeplug codeplug = (Motorola.Acp.PackUnpack.Ish.Codeplug) null;
        try
        {
          PackUnpackExecutor packUnpackExecutor = new PackUnpackExecutor();
          packUnpackExecutor.PrePackHandler();
          codeplug = packUnpackExecutor.Pack((FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation).General.RadInfoGeneralModelNumber_A8539Value);
        }
        catch (Exception ex)
        {
          AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, AppResources.Unable_to_pack_codeplug_image);
        }
        if (codeplug != null)
        {
          if (codeplug.Partitions.Count != 0)
          {
            if (File.Exists(sFilePath))
              File.Delete(sFilePath);
            byte[] array = new byte[0];
            foreach (Partition partition in codeplug.Partitions)
            {
              byte[] numArray1 = new byte[14];
              byte[] bytes1 = new ASCIIEncoding().GetBytes("PARTITION");
              Array.Copy((Array) bytes1, (Array) numArray1, bytes1.Length);
              numArray1[bytes1.Length] = Convert.ToByte((object) partition.PartitionType);
              byte[] bytes2 = BitConverter.GetBytes((int) partition.Image.Length);
              if (BitConverter.IsLittleEndian)
                Array.Reverse((Array) bytes2);
              Array.Copy((Array) bytes2, 0, (Array) numArray1, bytes1.Length + 1, 4);
              byte[] numArray2 = new byte[(long) numArray1.Length + partition.Image.Length];
              Array.Copy((Array) numArray1, (Array) numArray2, numArray1.Length);
              Array.Copy((Array) partition.Image.GetBuffer(), 0L, (Array) numArray2, (long) numArray1.Length, partition.Image.Length);
              int length = array.GetLength(0);
              Array.Resize<byte>(ref array, array.GetLength(0) + numArray2.Length);
              Array.Copy((Array) numArray2, 0, (Array) array, length, numArray2.Length);
              Array.Clear((Array) numArray2, 0, numArray2.Length);
            }
            new AcpFileHandler().WriteFile(array, sFilePath, encrypt, FileMode.Create);
            flag = true;
            int num = (int) System.Windows.MessageBox.Show(AppResources.ByteArray_file_successfully_created, AppResources.Save_Codeplug_as_ByteArray, MessageBoxButton.OK);
          }
          else
          {
            int num1 = (int) System.Windows.MessageBox.Show(AppResources.Unable_to_save_Codeplug_Invalid_codeplug_image, AppResources.Save_Codeplug_as_ByteArray, MessageBoxButton.OK);
          }
        }
        else
        {
          int num2 = (int) System.Windows.MessageBox.Show(AppResources.Unable_to_pack_codeplug_image, AppResources.Save_Codeplug_as_ByteArray, MessageBoxButton.OK);
        }
      }
      else
      {
        int num3 = (int) System.Windows.MessageBox.Show(AppResources.A_codeplug_must_be_opened_before_this_function_can_be_used, AppResources.Save_Codeplug_as_ByteArray, MessageBoxButton.OK);
      }
    }
    else
    {
      int num4 = (int) System.Windows.MessageBox.Show(AppResources.Unable_to_save_Codeplug_Invalid_Filename, AppResources.Save_Codeplug_as_ByteArray, MessageBoxButton.OK);
    }
    return flag;
  }

  internal void OnFPSSaveCpgAsBBF(
    object sender,
    RoutedEventArgs e,
    string sFileName,
    string currentFlashcode)
  {
    if (this.CpgOpenFlag)
    {
      AcpUI.Common.Utility.SaveFieldWithFocus();
      this.NATListFixup();
      if (!this.SaveCodeplug())
        return;
      try
      {
        CodeplugFormatHelper.SaveCpgAsBbf(sFileName, currentFlashcode, this.CPS_Version, this.MyModelNumber);
      }
      catch (CodeplugCreationException ex)
      {
        int num = (int) System.Windows.MessageBox.Show(ex.MessageBoxText, ex.Caption, MessageBoxButton.OK);
      }
    }
    else
    {
      int num1 = (int) System.Windows.MessageBox.Show(AppResources.codeplug_must_open_before_this_function_use, AppResources.Save_Codeplug_as_Srecord, MessageBoxButton.OK);
    }
  }

  internal void OnFPSSaveCpgAsSrec(object sender, RoutedEventArgs e, string sFileName)
  {
    if (this.CpgOpenFlag)
    {
      AcpUI.Common.Utility.SaveFieldWithFocus();
      this.NATListFixup();
      if (!this.SaveCodeplug())
        return;
      try
      {
        CodeplugFormatHelper.SaveCpgAsSrec(sFileName, this.cpsVersion);
      }
      catch (CodeplugCreationException ex)
      {
        int num = (int) System.Windows.MessageBox.Show(ex.MessageBoxText, ex.Caption, MessageBoxButton.OK);
      }
    }
    else
    {
      int num1 = (int) System.Windows.MessageBox.Show(AppResources.codeplug_must_open_before_this_function_use, AppResources.Save_Codeplug_as_Srecord, MessageBoxButton.OK);
    }
  }

  internal void OnAppCustomizeOpen(object sender, RoutedEventArgs e)
  {
    AcpOpenFileDialog acpOpenFileDialog = new AcpOpenFileDialog();
    acpOpenFileDialog.Filter = AppResources.All_image_types_Filter;
    acpOpenFileDialog.MultiSelect = false;
    if (!acpOpenFileDialog.ShowDialog().GetValueOrDefault())
      return;
    string lower = acpOpenFileDialog.FileName.ToLower();
    WindowMain mainWindow = (WindowMain) System.Windows.Application.Current.MainWindow;
    if (lower.EndsWith(".png") || lower.EndsWith(".gif") || lower.EndsWith(".bmp") || lower.EndsWith(".jpg") || lower.EndsWith(".jpeg") || lower.EndsWith(".jpe") || lower.EndsWith(".jfif") || lower.EndsWith(".tiff") || lower.EndsWith(".tif") || lower.EndsWith(".ico"))
    {
      if (mainWindow.FrameCenterTop.Content is PageWelcome)
        ((PageWelcome) mainWindow.FrameCenterTop.Content).SetBackground(lower);
      else if (mainWindow.FrameCenterTop.Content is PageCustomViewWelcome)
      {
        ((PageCustomViewWelcome) mainWindow.FrameCenterTop.Content).SetBackground(lower);
      }
      else
      {
        Settings.Default.CustomBackgroudPath = lower;
        Settings.Default.Save();
      }
    }
    else
    {
      AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, $"{AppResources.File_colon}{lower} {AppResources.could_not_be_used_Please_select_an_image_file_in_one_of_the_supported_formats}");
      ((PageStatusBar) mainWindow.FrameStatusBar.Content).Status = AppResources.Open_Failed;
      if (!(mainWindow.FrameCenterTop.Content is PageWelcome))
        return;
      ((PageWelcome) mainWindow.FrameCenterTop.Content).LoadDefaultLogo();
    }
  }

  internal void OnAppRestoreToDefault(object sender, RoutedEventArgs e)
  {
    WindowMain mainWindow = (WindowMain) System.Windows.Application.Current.MainWindow;
    if (mainWindow.FrameCenterTop.Content is PageWelcome)
      ((PageWelcome) mainWindow.FrameCenterTop.Content).LoadDefaultLogo();
    else if (mainWindow.FrameCenterTop.Content is PageCustomViewWelcome)
    {
      ((PageCustomViewWelcome) mainWindow.FrameCenterTop.Content).LoadDefaultLogo();
    }
    else
    {
      Settings.Default.CustomBackgroudPath = WindowMain.DefaultLogoPath;
      Settings.Default.Save();
    }
  }

  internal void OnRibbonBarThemeItemClick(object sender, RoutedEventArgs e)
  {
    ButtonDropDown buttonDropDown = (ButtonDropDown) sender;
    if (buttonDropDown.Name == "ClassicTheme")
    {
      this.ChangeControlColorScheme(eAcpColorScheme.ClassicSkin);
      this.ChangeMainFrameColorScheme(eRibbonVisualStyle.Office2007Classic, eDockVisualStyle.Office2007Classic, Colors.Transparent);
    }
    else if (buttonDropDown.Name == "SilverTheme")
    {
      this.ChangeControlColorScheme(eAcpColorScheme.SilverSkin);
      this.ChangeMainFrameColorScheme(eRibbonVisualStyle.Office2007Silver, eDockVisualStyle.Office2007Silver, Colors.Transparent);
    }
    else if (buttonDropDown.Name == "BlueTheme")
    {
      this.ChangeControlColorScheme(eAcpColorScheme.SilverSkin);
      this.ChangeMainFrameColorScheme(eRibbonVisualStyle.Office2007Blue, eDockVisualStyle.Office2007Blue, Colors.Transparent);
    }
    else if (buttonDropDown.Name == "BlackTheme")
    {
      this.ChangeControlColorScheme(eAcpColorScheme.BlackSkin);
      this.ChangeMainFrameColorScheme(eRibbonVisualStyle.Office2007Black, eDockVisualStyle.Office2007Black, Colors.Transparent);
    }
    else if (buttonDropDown.Name == "PoliceTheme")
    {
      this.ChangeControlColorScheme(eAcpColorScheme.PoliceSkin);
      this.ChangeMainFrameColorScheme(eRibbonVisualStyle.Office2007Police, eDockVisualStyle.Office2007Police, Colors.Transparent);
    }
    else if (buttonDropDown.Name == "FiremanTheme")
    {
      this.ChangeControlColorScheme(eAcpColorScheme.FireSkin);
      this.ChangeMainFrameColorScheme(eRibbonVisualStyle.Office2007Fireman, eDockVisualStyle.Office2007Fireman, Colors.Transparent);
    }
    else if (buttonDropDown.Name == "MilitaryTheme")
    {
      this.ChangeControlColorScheme(eAcpColorScheme.MilitarySkin);
      this.ChangeMainFrameColorScheme(eRibbonVisualStyle.Office2007Military, eDockVisualStyle.Office2007Military, Colors.Transparent);
    }
    else if (buttonDropDown.Name == "FullColorTheme")
    {
      this.ChangeControlColorScheme(eAcpColorScheme.FullColorSkin);
      this.ChangeMainFrameColorScheme(eRibbonVisualStyle.Office2007FullColor, eDockVisualStyle.Office2007FullColor, Colors.Transparent);
    }
    AcpUI.Common.Utility.OnThemeChanged((object) this, buttonDropDown.Name);
  }

  private void ChangeControlColorScheme(eAcpColorScheme ctrlColor)
  {
    if (System.Windows.Application.Current.Resources.MergedDictionaries.Count > 0)
      System.Windows.Application.Current.Resources.MergedDictionaries.Remove(this.AppColorSchemes[this.currentColorTheme]);
    System.Windows.Application.Current.Resources.MergedDictionaries.Add(this.AppColorSchemes[ctrlColor]);
    this.currentColorTheme = ctrlColor;
  }

  private void ChangeMainFrameColorScheme(
    eRibbonVisualStyle ribbonColor,
    eDockVisualStyle dockColor,
    System.Windows.Media.Color customBaseColor)
  {
    this.currentRibbonColor = ribbonColor;
    this.currentDockColor = dockColor;
    if (customBaseColor != Colors.Transparent)
      this.WindowMainRibbonControl.ChangeColorScheme(ribbonColor, customBaseColor);
    else
      this.WindowMainRibbonControl.ChangeColorScheme(ribbonColor);
    this.pageIUI.ChangeColorScheme(dockColor, customBaseColor);
  }

  public bool BlockFlashReadRadio
  {
    get => !this.readWriteInProgress;
    set => this.BlockFlashReadRadio = value;
  }

  public bool BlockFlashReadRadioFromRMC
  {
    get => !this.readWriteInProgress && this.deviceFromServer == null;
    set => this.BlockFlashReadRadioFromRMC = value;
  }

  public bool BlockReadFlashKeyCfgFromRMC
  {
    get => this.deviceFromServer == null;
    set => this.BlockReadFlashKeyCfgFromRMC = value;
  }

  public bool BlockFlashIO
  {
    get => !this.readWriteInProgress && this.CanOpenCpgFlag;
    set => this.BlockFlashIO = value;
  }

  public bool BlockRadioIO
  {
    get => !this.readWriteInProgress && this.CpgOpenFlag && !this.InRMCEditSession;
    set => this.BlockRadioIO = value;
  }

  public bool ReadWriteInProgress
  {
    get => this.readWriteInProgress;
    set
    {
      this.readWriteInProgress = value;
      if (this.PropertyChanged == null)
        return;
      this.PropertyChanged((object) this, new PropertyChangedEventArgs("BlockRadioIO"));
      this.PropertyChanged((object) this, new PropertyChangedEventArgs("BlockFlashIO"));
      this.PropertyChanged((object) this, new PropertyChangedEventArgs("BlockFlashReadRadio"));
      this.PropertyChanged((object) this, new PropertyChangedEventArgs(nameof (ReadWriteInProgress)));
      this.PropertyChanged((object) this, new PropertyChangedEventArgs("BlockFlashReadRadioFromRMC"));
    }
  }

  internal bool InRMCEditSession
  {
    get
    {
      if (!this.CpgOpenFlag)
        return false;
      return this.DeviceFromServer != null || this.TemplateFromServer != null;
    }
  }

  internal void HandleUpdateIsMobileModel(bool isMobile) => this.IsMobileModel = isMobile;

  internal void HandleUpdateIsPortableModel(bool isPortable) => this.IsPortableModel = isPortable;

  internal void HandleAbortFileOpen() => this.CloseFile();

  internal bool LaunchReadRadio(int myTransport)
  {
    string empty = string.Empty;
    return this.LaunchReadRadio(myTransport, ref empty);
  }

  internal bool LaunchReadRadio(
    int myTransport,
    ref string errorMsg,
    bool isCruncherWriteCheckPBA = false,
    bool isCruncherMode = false)
  {
    bool status = false;
    bool flag1 = false;
    string str = "";
    IshItemCollection radioCodeplug = (IshItemCollection) null;
    SpecialFeatures.Comms.Comms ReadRadio = new SpecialFeatures.Comms.Comms();
    SpecialFeatures.Comms.Comms.updateStatus += new SpecialFeatures.Comms.Comms.DisplayUpdateStatus(this.ReadRadio_updateStatus);
    SpecialFeatures.Comms.Comms.displayCBI += new SpecialFeatures.Comms.Comms.MainUIDisplayCBI(this.WindowMain_DisplayCBI);
    SpecialFeatures.Comms.Comms.displayOTAP += new SpecialFeatures.Comms.Comms.MainUIDisplayOTAP(this.WindowMain_DisplayOTAP);
    if (myTransport == 0)
    {
      if (!isCruncherMode)
        this.MultiCodeplugInfo = MultiCodeplugUtility.TryGetMultiCodeplugInfo(ref this._shouldResetRadio);
      if (!MultiCodeplugUtility.IsActiveCodeplugFirmwareCompatible(this.MultiCodeplugInfo))
      {
        str = AppResources.Active_Codeplug_Is_Invalid;
        this.ReadRadio_updateStatus(0.0, str);
      }
      else
        radioCodeplug = ReadRadio.ReadRadio(COMMS_OP.USB_READ_WRITE, this._shouldResetRadio, ref errorMsg, isCruncherWriteCheckPBA, isCruncherMode);
    }
    if (myTransport == 1 && this.Pop25Enabled)
    {
      radioCodeplug = ReadRadio.ReadRadio(COMMS_OP.OTAP_READ_WRITE, this._shouldResetRadio, this.commsLastUserState);
      this.commsLastUserState = ReadRadio.GetLastCommsOTAPUserState();
    }
    if (myTransport == 2)
    {
      radioCodeplug = ReadRadio.ReadRadio(COMMS_OP.BLUETOOTH_READ_WRITE, this._shouldResetRadio, this.commsLastUserState);
      this.commsLastUserState = ReadRadio.GetLastCommsOTAPUserState();
    }
    if (myTransport == 1 && !this.Pop25Enabled)
    {
      str = AppResources.Please_attach_and_load_the_hardware_Key_to_proceed_with_Otap_Read_Write;
      this.ReadRadio_updateStatus(0.0, str);
    }
    bool flag2;
    if (radioCodeplug != null && radioCodeplug.Count > 0)
    {
      RadioParams radioParams = ReadRadio.GetRadioParams();
      if (AcpDocument.ValidCodeplugVersion(radioParams.CodeplugVersion))
      {
        this.ReadRadio_updateStatus(0.1, AppResources.Read_Radio_Verification_Start);
        bool read = false;
        bool write = false;
        bool archive = false;
        string empty = string.Empty;
        ReadRadio.GetReadWritePassword(ref read, ref write, ref archive, ref empty);
        if ((bool) System.Windows.Application.Current.Properties[(object) "CommandLineCPS"])
          read = false;
        string serialNumber = ParseDataHelper.RadioSNToString(ReadRadio.GetRadioParams().SerialNumber);
        if (read && !this._readWritePasswordApp.ValidateOKToReadWrite((Window) this, empty, serialNumber, ReadWritePasswordApp.ValidType.Read))
        {
          AppInfoManager.StatusMsgReport.Clear();
          ((App) System.Windows.Application.Current).TheDocument.Clear();
          this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Delegate) new WindowMain.CloseProgressWindow(this.WindowMain_CloseProgressWindow));
          flag2 = false;
        }
        else
        {
          this.MyModelNumber = radioParams.ModelNumber;
          new ModelTiering(this.MyModelNumber, "").UpdateUtilityMackModelType();
          WindowMain.UpdateIsMobileModel method = new WindowMain.UpdateIsMobileModel(this.HandleUpdateIsMobileModel);
          if (UtilityMack.IsPortablePro)
          {
            if (!(bool) System.Windows.Application.Current.Properties[(object) "CommandLineCPS"])
              this.Dispatcher.Invoke((Delegate) method, (object) false);
            else
              method(false);
          }
          else if (!(bool) System.Windows.Application.Current.Properties[(object) "CommandLineCPS"])
            this.Dispatcher.Invoke((Delegate) method, (object) true);
          else
            method(true);
          try
          {
            ReadRadio.UnpackFromRadio(radioCodeplug);
            if (radioCodeplug.Count > 1)
              status = true;
          }
          catch (Exception ex)
          {
            ((App) System.Windows.Application.Current).TheDocument.Initialized(false);
            status = false;
            flag1 = true;
          }
          if (status)
          {
            this.SetCodeplugVersionAfterSuccessfulRead();
            flag2 = this.ReadRadioComplete(status, ReadRadio, radioParams);
            this.PostUpgradeCodeplugProccessing(radioParams.CodeplugVersion, AppInfoManager.AppVersion);
          }
          else
          {
            str = AppResources.Read_Radio_Verification_Fail;
            flag2 = false;
          }
        }
      }
      else
      {
        str = $"{AppResources.Unable_to_read_radio}\n{AcpDocument.CpgVersionErrStr}";
        this.ReadRadio_updateStatus(0.0, str);
        flag2 = false;
      }
    }
    else
      flag2 = false;
    if (!flag2 || flag1 && ((App) System.Windows.Application.Current).TheDocument.IsOpen)
    {
      if (!(bool) System.Windows.Application.Current.Properties[(object) "CommandLineCPS"])
        this.Dispatcher.Invoke((Delegate) new WindowMain.AbortFileOpen(this.HandleAbortFileOpen), DispatcherPriority.Normal);
      else
        this.HandleAbortFileOpen();
      if (flag1)
        this.ReadRadio_updateStatus(0.0, str);
    }
    if (!(bool) System.Windows.Application.Current.Properties[(object) "CommandLineCPS"])
      this.Dispatcher.Invoke(DispatcherPriority.Normal, (Delegate) new WindowMain.ReadComplete(this.WindowMain_ReadRadioFinished), (object) flag2, (object) str, null, (object) ReadRadio.GetRadioParams());
    else
      this.WindowMain_ReadRadioFinished(flag2, str, (string) null, ReadRadio.GetRadioParams());
    if (this.readRadioComplete != null)
      this.readRadioComplete(flag2);
    this.ReadWriteInProgress = false;
    SpecialFeatures.Comms.Comms.updateStatus -= new SpecialFeatures.Comms.Comms.DisplayUpdateStatus(this.ReadRadio_updateStatus);
    SpecialFeatures.Comms.Comms.displayCBI -= new SpecialFeatures.Comms.Comms.MainUIDisplayCBI(this.WindowMain_DisplayCBI);
    SpecialFeatures.Comms.Comms.displayOTAP -= new SpecialFeatures.Comms.Comms.MainUIDisplayOTAP(this.WindowMain_DisplayOTAP);
    ReadRadio.Dispose();
    this._readWritePasswordApp.ClearCachedPasswordValidation();
    UndoManager.Reset();
    return flag2;
  }

  private void SetCodeplugVersionAfterSuccessfulRead()
  {
    FeatureManager.SetActiveDocumentCodeplugVersion((FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation).General.RadInfoGeneralCodeplugVersion_A7683.Value);
  }

  internal void WindowMain_CloseProgressWindow()
  {
    this.progressPage.Hide();
    this.progressPage.SetCloseBtnEnable(true);
    this.progressPage.Close();
    this.progressPage.Dispose();
  }

  public void PostUpgradeCodeplugProccessing(string codeplugVersion, string appVersion)
  {
    try
    {
      int num1 = int.Parse(codeplugVersion.Substring(1, 2));
      int num2 = int.Parse(appVersion.Substring(1, 2));
      if (num1 < 3 && num2 > 2 && num2 > num1)
      {
        foreach (Motorola.MackinawCPS.CoreFeatures.DataProfiles.DataProfiles dataProfiles in (Collection<AcpBusinessLayer.FeatureNode>) (FeatureManager.GetFeature(2054) as DataProfilesRecset))
        {
          dataProfiles.General.DataConfigDataProfRandomHoldOffTime_A36552.Value = dataProfiles.General.DataConfigDataProfRandomHoldOffTime_A36552.DefaultValue;
          this.SetFixedNumRecords(dataProfiles.DAC.EmbeddedRecset as AcpBusinessLayer.Recordset, 16 /*0x10*/);
          this.SetFixedNumRecords(dataProfiles.TrunkingGroupID.EmbeddedRecset as AcpBusinessLayer.Recordset, 8);
        }
      }
      if (FeatureManager.GetFeature(2045)[0] is Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide radioWide && num1 < 13 && num2 >= 13 && num2 > num1)
        radioWide.Location.GPSFailToneInterval_42329.Value = radioWide.Location.GPSFailToneInterval_42329.DefaultValue;
      ConventionalSystemRecset feature = FeatureManager.GetFeature(2053) as ConventionalSystemRecset;
      if (!Permission.Have(Permissions.RefernceDisabled, feature[0].Permissions) || !(FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation).Labtool.RadInfoLabtoolQ806IMBE_A8191.Value)
        return;
      ((Motorola.MackinawCPS.CoreFeatures.ConventionalSystem.General) feature[0][10118]).CnvSysGeneralSystemType_A13262Value = 0;
    }
    catch (Exception ex)
    {
    }
  }

  private void SetFixedNumRecords(AcpBusinessLayer.Recordset recordset, int FixedTableRecordNumber)
  {
    recordset.Max = FixedTableRecordNumber;
    recordset.Min = FixedTableRecordNumber;
    while (recordset.Count < FixedTableRecordNumber)
      recordset.AddRecord(recordset.CreateDefaultRecord());
  }

  private bool IsValidFileName(string fileName)
  {
    if (string.IsNullOrWhiteSpace(fileName))
      return false;
    FileInfo fileInfo = (FileInfo) null;
    FileStream fileStream = (FileStream) null;
    try
    {
      fileInfo = new FileInfo(fileName);
      if (fileInfo != null)
        fileStream = fileInfo.Create();
      return fileStream != null;
    }
    catch (Exception ex)
    {
      return false;
    }
    finally
    {
      if (fileStream != null)
      {
        fileStream.Close();
        fileInfo?.Delete();
      }
    }
  }

  private bool ReadRadioComplete(bool status, SpecialFeatures.Comms.Comms ReadRadio, RadioParams currentRadio)
  {
    this.ResolvedMFKTimerUnpack();
    this.InitTrkPerFeaturesPriorityDispatchTimeOutTimer43598AfterUnpack();
    this.InitCnvEmerProfGeneralTxPeriodsec2_A43600AterUnpack();
    this.InitTrkEmerProfGeneralTxPeriodsec2_A43601AfterUnpack();
    this.ResolveUCLReferenceAfterUnpack();
    this.ReadRadio_updateStatus(0.2, AppResources.Read_Radio_Verification_);
    try
    {
      Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation radioInformation = FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation;
      Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide radioWide = FeatureManager.GetFeature(2045)[0] as Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide;
      string numberA8539Value = radioInformation.General.RadInfoGeneralModelNumber_A8539Value;
      string radioAliasA8829Value = radioWide.UserInformationAndPasswords.RadWideUserInformationandPasswordsRadioAlias_A8829Value;
      string numberA9122Value = radioInformation.General.RadInfoGeneralSerialNumber_A9122Value;
      if (numberA8539Value != null || numberA8539Value != "")
        this.MyModelNumber = numberA8539Value;
      this.cpgFileName = !this.IsValidFileName(radioAliasA8829Value) ? numberA9122Value : radioAliasA8829Value;
    }
    catch (Exception ex)
    {
    }
    this.objModelTiering = new ModelTiering(this.MyModelNumber, ModelTiering.ActionTypes.OPEN, ModelTiering.TargetTypes.ALL);
    this.objModelTiering.UpdateUtilityMackModelType();
    ConstraintManager.Suspend();
    this.objModelTiering.ApplyTiering();
    ConstraintManager.Resume();
    this.ReadRadio_updateStatus(0.3, AppResources.Read_Radio_Verification_);
    this.ReadRadio_updateStatus(0.4, AppResources.Read_Radio_Verification_);
    this.ReadRadio_updateStatus(0.6, AppResources.Read_Radio_Verification_);
    ReadRadio.SetCodeplugVersions(currentRadio);
    this.ReadRadio_updateStatus(0.7, AppResources.Read_Radio_Verification_);
    this.SetProductModelIdentifierField();
    this.SetDVRSHoptionEnabledField();
    this.SetDVRSHwEnabledField();
    this.IsMobileModelSupportedControlHeads();
    this.IsCpgConvOnly = false;
    return status;
  }

  internal void WindowMain_ReadRadioFinished(
    bool stat,
    string strErrorMessage,
    string infoMsg,
    RadioParams currentRadioParams)
  {
    WriteProtect.readInProgress = false;
    StatusMsgType type = StatusMsgType.Error;
    string message = strErrorMessage;
    if (stat)
    {
      this.ReadRadio_updateStatus(0.8, AppResources.Read_Radio_Verification_);
      ASKConstraints.Initialize();
      ((WindowMain) System.Windows.Application.Current.MainWindow).CpgOpenFlag = true;
      this.IsFreonProduct = UtilityMack.IsFreonCodeplug(currentRadioParams.ModelNumber);
      PageNavPaneButtons content1 = (PageNavPaneButtons) ((WindowMain) System.Windows.Application.Current.MainWindow).FrameLeft.Content;
      content1.ButtonCpgNav.IsSelected = true;
      content1.FrameCodeplug.Navigate(new Uri("PageTreeView.xaml", UriKind.RelativeOrAbsolute));
      ((WindowMain) System.Windows.Application.Current.MainWindow).FrameCenterTop.Navigate(new Uri(FeatureManager.GetFeature(2049).UIPagePath, UriKind.RelativeOrAbsolute));
      AppInfoManager.AppMode = ApplicationMode.CodeplugConfigurationMode;
      this.ReadRadio_updateStatus(0.9, AppResources.Read_Radio_Verification_);
      PageStatusBar content2 = (PageStatusBar) ((WindowMain) System.Windows.Application.Current.MainWindow).FrameStatusBar.Content;
      if (this.MultiCodeplugInfo != null)
        this.SetMultiCodeplugInfoInProgressBar(content2);
      content2.RadioModel = currentRadioParams.ModelNumber;
      string radioSN = ParseDataHelper.RadioSNToString(currentRadioParams.SerialNumber);
      content2.SerialNum = radioSN;
      content2.Status = AppResources.READY_ID;
      foreach (IAcpConstraints feature in FeatureManager.Features)
        feature.CalculateVisibility(true);
      this.SetTitleBar((string) null, radioSN);
      this.InitASKProgHistoryRecSet();
      if (AppInfoManager.AppMode == ApplicationMode.CodeplugConfigurationMode)
        this.AppMenuWriteProtect.IsEnabled = false;
      int num = this.O9TableInit() ? 1 : 0;
      this.MFKTableInit();
      this.ShepherdsInitForFob();
      this.TriggerMuteToneRefresh();
      this.DEKVipTableInit();
      this.O2MFKTableInit();
      this.O7MFKTableInit();
      this.O2NavigationControlsTableInit();
      this.O7NavigationControlsTableInit();
      this.E5NavigationControlsTableInit();
      this.O3NavigationControlsTableInit();
      this.O5NavigationControlsTableInit();
      this.O9NavigationControlsTableInit();
      this.KMANavigationControlsTableInit();
      this.PresetZoneChannelTableInit();
      this.BookmarkQuickAccessListInit();
      this.KeypadRecsetAndTableInit();
      this.SmartKeyFobTableInit();
      this.SideArrowTableInit();
      this.DataButtonInit();
      this.SiteSelectableAlertTableInit();
      this.AlertListTableInit();
      this.FixupAccyButton();
      this.FixupConfigurablePresetZoneChannel();
      CodeplugFixups.SetTxPowerLevelMediumAndMediumHighValueSameAsLow(this.CodeplugVersion, this.MyModelNumber);
      this.FixUpTrunkingNotificationButtonForMahalo();
      this.FixUpViqiSecureClearStrapping();
      if (this.IsPortableModel)
        this.TxPowerTableInit();
      if (this.IsMobileModel)
      {
        this.TxPowerTableInitForMobile();
        this.TxPowerNewTableInitForMobile();
        this.BandSplitOverRidingInit();
        this.FixupOneTouchTrunkingSystem();
      }
      this.ResetRadioKilledBit();
      this.AddQC2DefaultRecord();
      this.SyncASTROOTARAndOTARProfileIndex(FeatureManager.ActiveDocument);
      this.SyncAstroOtarInhibit();
      this.FixUpSecureHardwareEncryptionIndependentKeyList();
      this.FixUpMPLVisiblityOnTrukingButton();
      this.FixUpMPLVisiblityOnTrukingAccyButton();
      this.FixUpChannelSearchVisiblityOnPortableButtons();
      this.FixUpChannelSearchVisiblityOnRSMButton();
      ((App) System.Windows.Application.Current).TheDocument.Initialized(true);
      ConstraintManager.Suspend();
      this.SyncE5BottomButton();
      this.updateUnpackedFields(true, currentRadioParams);
      this.hideADPKeyData();
      if (num != 0)
        this.AddO9PhephedRecord();
      this.SyncO9PASirenButtons();
      this.O9DirectionalButtonsFixup();
      this.UpdateAuxControlTable();
      ConstraintManager.Resume();
      this.RefreshScanlistMap();
      this.VoiceAnnListFixup();
      this.ScanListFixup();
      this.CnvPerTalkgroupListFixUp();
      this.DataProfileTrunkingGroupIDFixup();
      this.FixupViQiKeySelect();
      this.ZoneToZoneCloneFixup();
      this.FixupSystemProtocolType();
      this.FixupTtsZoneVoiceAnnouncementCommandIsEmptyOrConfusable();
      this.AttemptsAllowedDefaultValueFixUp();
      this.SyncRadioInhibitViaAstroOtar();
      this.ReadRadio_updateStatus(1.0, AppResources.Read_Radio_Verification_Complete);
      message = AppResources.Read_Radio_Verification_Complete;
      type = StatusMsgType.Info;
      this.progressPage.SetCloseBtnEnable(true);
      this.progressPage.Close();
      this.RunTMSConstraints();
      this.URLTableFixup();
      this.FixUpSetCodeplugNameToDefaultValueIfEmpty();
      this.FixUpSetNFPACompliantToTrueIfNFPARadio();
      this.FixUpVIQIVirtualPartnerValueSetToDisabledIfLMR();
      this.FixUpSwitchesValueSetToBlankIfUnprogrammed();
    }
    if (this.SavedCurrentViewType == DifferentiatedUserViewType.Custom)
    {
      AppInfoManager.AppView = this.SavedCurrentViewType;
      if (!string.IsNullOrEmpty(this.customVwPath) && File.Exists(this.customVwPath) && ((WindowMain) System.Windows.Application.Current.MainWindow).CpgOpenFlag)
        ((App) System.Windows.Application.Current).TheDocument.ImportFromXml(this.customVwPath, XmlFileType.CustomView);
    }
    if (message.Length <= 0)
      return;
    AppInfoManager.StatusMsgReport.RegisterMessage(type, message);
  }

  private void FixUpVIQIVirtualPartnerValueSetToDisabledIfLMR()
  {
    switch (FeatureManager.GetFeature(2045)[0] is Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide radioWide ? radioWide.Features?.RadCfgVirtualPartnerMode_UIValue : (string) null)
    {
      case "LMR":
        radioWide.Features.RadCfgVirtualPartnerMode_UIValue = "Disabled";
        break;
    }
  }

  private void FixUpSwitchesValueSetToBlankIfUnprogrammed()
  {
    if (this.CodeplugVersion.Major >= 36)
      return;
    this.ChangeConcentricSwitchValueToBlankIfUnprogrammed();
    this.ChangeToggleSwitchValueToBlankIfUnprogrammed();
  }

  private void ChangeConcentricSwitchValueToBlankIfUnprogrammed()
  {
    if (!(FeatureManager.GetFeature(2038)[0] is Motorola.MackinawCPS.CoreFeatures.Switches.Switches switches))
      return;
    ConventionalSwitchTableInnerSection tableInnerSection1 = switches.ConventionalSwitchTable?.EmbeddedRecset[0] is ConventionalSwitchTableInner switchTableInner1 ? switchTableInner1.ConventionalSwitchTableInnerSection : (ConventionalSwitchTableInnerSection) null;
    if (tableInnerSection1 != null)
    {
      this.ChangeSwitchValueToBlankIfUnprogrammed(tableInnerSection1.SwitchConventionalSwitchTablePosition1Feature_A19655Value, 35, 38, tableInnerSection1.SwitchConventionalSwitchTablePosition1Feature_A19655);
      this.ChangeSwitchValueToBlankIfUnprogrammed(tableInnerSection1.SwitchConventionalSwitchTablePosition2Feature_A19656Value, 35, 38, tableInnerSection1.SwitchConventionalSwitchTablePosition1Feature_A19655);
      this.ChangeSwitchValueToBlankIfUnprogrammed(tableInnerSection1.SwitchConventionalSwitchTablePosition3Feature_A19657Value, 35, 38, tableInnerSection1.SwitchConventionalSwitchTablePosition3Feature_A19657);
      this.ChangeSwitchValueToBlankIfUnprogrammed(tableInnerSection1.SwitchConventionalSwitchTablePosition4Feature_A19658Value, 35, 38, tableInnerSection1.SwitchConventionalSwitchTablePosition4Feature_A19658);
      this.ChangeSwitchValueToBlankIfUnprogrammed(tableInnerSection1.SwitchConventionalSwitchTablePosition5Feature_A19717Value, 35, 38, tableInnerSection1.SwitchConventionalSwitchTablePosition5Feature_A19717);
    }
    TrunkingSwitchTableInnerSection tableInnerSection2 = switches.TrunkingSwitchTable?.EmbeddedRecset[0] is TrunkingSwitchTableInner switchTableInner2 ? switchTableInner2.TrunkingSwitchTableInnerSection : (TrunkingSwitchTableInnerSection) null;
    if (tableInnerSection2 == null)
      return;
    this.ChangeSwitchValueToBlankIfUnprogrammed(tableInnerSection2.SwitchTrunkingSwitchTablePosition1Feature_A21004Value, 35, 38, tableInnerSection2.SwitchTrunkingSwitchTablePosition1Feature_A21004);
    this.ChangeSwitchValueToBlankIfUnprogrammed(tableInnerSection2.SwitchTrunkingSwitchTablePosition2Feature_A21005Value, 35, 38, tableInnerSection2.SwitchTrunkingSwitchTablePosition2Feature_A21005);
    this.ChangeSwitchValueToBlankIfUnprogrammed(tableInnerSection2.SwitchTrunkingSwitchTablePosition3Feature_A21006Value, 35, 38, tableInnerSection2.SwitchTrunkingSwitchTablePosition3Feature_A21006);
    this.ChangeSwitchValueToBlankIfUnprogrammed(tableInnerSection2.SwitchTrunkingSwitchTablePosition4Feature_A21007Value, 35, 38, tableInnerSection2.SwitchTrunkingSwitchTablePosition4Feature_A21007);
    this.ChangeSwitchValueToBlankIfUnprogrammed(tableInnerSection2.SwitchTrunkingSwitchTablePosition5Feature_A21008Value, 35, 38, tableInnerSection2.SwitchTrunkingSwitchTablePosition5Feature_A21008);
  }

  private void ChangeToggleSwitchValueToBlankIfUnprogrammed()
  {
    if (!(FeatureManager.GetFeature(2038) is SwitchesRecset feature))
      return;
    AcpBusinessLayer.FeatureNode featureNode = feature[0] as AcpBusinessLayer.FeatureNode;
    ConventionalSwitches conventionalSwitches = featureNode is Motorola.MackinawCPS.CoreFeatures.Switches.Switches switches1 ? switches1.ConventionalSwitches : (ConventionalSwitches) null;
    if (conventionalSwitches != null)
    {
      this.ChangeSwitchValueToBlankIfUnprogrammed(conventionalSwitches.SwitchConventionalSwitchesPosition1_A7734Value, 35, 38, conventionalSwitches.SwitchConventionalSwitchesPosition1_A7734);
      this.ChangeSwitchValueToBlankIfUnprogrammed(conventionalSwitches.SwitchConventionalSwitchesPosition2_A7735Value, 35, 38, conventionalSwitches.SwitchConventionalSwitchesPosition2_A7735);
      this.ChangeSwitchValueToBlankIfUnprogrammed(conventionalSwitches.SwitchConventionalSwitchesPosition3_A7737Value, 35, 38, conventionalSwitches.SwitchConventionalSwitchesPosition3_A7737);
      this.ChangeSwitchValueToBlankIfUnprogrammed(conventionalSwitches.SwitchConventionalSwitchesPosition4_A21530Value, 35, 38, conventionalSwitches.SwitchConventionalSwitchesPosition4_A21530);
      this.ChangeSwitchValueToBlankIfUnprogrammed(conventionalSwitches.SwitchConventionalSwitchesPosition5_A21531Value, 35, 38, conventionalSwitches.SwitchConventionalSwitchesPosition5_A21531);
    }
    TrunkingSwitches trunkingSwitches = featureNode is Motorola.MackinawCPS.CoreFeatures.Switches.Switches switches2 ? switches2.TrunkingSwitches : (TrunkingSwitches) null;
    if (trunkingSwitches == null)
      return;
    this.ChangeSwitchValueToBlankIfUnprogrammed(trunkingSwitches.SwitchTrunkingSwitchesPosition1_A9466Value, 35, 38, trunkingSwitches.SwitchTrunkingSwitchesPosition1_A9466);
    this.ChangeSwitchValueToBlankIfUnprogrammed(trunkingSwitches.SwitchTrunkingSwitchesPosition2_A9467Value, 35, 38, trunkingSwitches.SwitchTrunkingSwitchesPosition2_A9467);
    this.ChangeSwitchValueToBlankIfUnprogrammed(trunkingSwitches.SwitchTrunkingSwitchesPosition3_A9468Value, 35, 38, trunkingSwitches.SwitchTrunkingSwitchesPosition3_A9468);
    this.ChangeSwitchValueToBlankIfUnprogrammed(trunkingSwitches.SwitchTrunkingSwitchesPosition4_A21534Value, 35, 38, trunkingSwitches.SwitchTrunkingSwitchesPosition4_A21534);
    this.ChangeSwitchValueToBlankIfUnprogrammed(trunkingSwitches.SwitchTrunkingSwitchesPosition5_A21535Value, 35, 38, trunkingSwitches.SwitchTrunkingSwitchesPosition5_A21535);
  }

  private void ChangeSwitchValueToBlankIfUnprogrammed(
    int currentValue,
    int unprogrammedValue,
    int blankValue,
    AcpListField switches)
  {
    if (currentValue != unprogrammedValue || switches == null)
      return;
    switches.SetValue(blankValue);
  }

  private void URLTableFixup()
  {
    if (!(FeatureManager.GetFeature(4237) is URLTableRecset feature) || feature.Count <= 0)
      return;
    foreach (AcpBusinessLayer.FeatureNode featureNode in (Collection<AcpBusinessLayer.FeatureNode>) feature)
      featureNode.CallConstraints();
  }

  private void RefreshURLTable()
  {
    if (!(FeatureManager.GetFeature(4237) is URLTableRecset feature))
      return;
    feature.Refresh();
  }

  private void SyncAstroInfiniteUKEKRetention(Document doc)
  {
    if (this.VersionSupportsMultiOTAR(doc) || !(doc.GetFeature(2021)[0] is Motorola.MackinawCPS.CoreFeatures.SecureWide.SecureWide secureWide) || secureWide.Features.SecWideInfiniteUKEKRetention_A41551.Value == secureWide.General.SecWideInfiniteUKEKRetention_A41551.Value)
      return;
    secureWide.General.SecWideInfiniteUKEKRetention_A41551.Value = secureWide.Features.SecWideInfiniteUKEKRetention_A41551.Value;
  }

  private void SyncASTROUserSelectable(Document doc)
  {
    if (this.VersionSupportsMultiOTAR(doc) || !(doc.GetFeature(2021)[0] is Motorola.MackinawCPS.CoreFeatures.SecureWide.SecureWide secureWide) || secureWide.Multikey.SecWideMultikeyUserSelectable_A9604.Value == secureWide.General.SecWideMultikeyUserSelectable_A9604.Value)
      return;
    secureWide.General.SecWideMultikeyUserSelectable_A9604.Value = secureWide.Multikey.SecWideMultikeyUserSelectable_A9604.Value;
  }

  private void SyncAstroEraseOnPreviousChange(Document doc)
  {
    if (this.VersionSupportsMultiOTAR(doc) || !(doc.GetFeature(2021)[0] is Motorola.MackinawCPS.CoreFeatures.SecureWide.SecureWide secureWide) || (bool) secureWide.Multikey.SecWideMultikeyErasePreviousOnUserChange_A8373 == secureWide.General.SecWideMultikeyErasePreviousOnUserChange_A8373.Value)
      return;
    secureWide.General.SecWideMultikeyErasePreviousOnUserChange_A8373.Value = (bool) secureWide.Multikey.SecWideMultikeyErasePreviousOnUserChange_A8373;
  }

  private bool VersionSupportsMultiOTAR(Document doc)
  {
    int result = 0;
    if (doc.GetFeature(2049)[0] is Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation radioInformation)
    {
      string versionA7683UiValue = radioInformation.General.RadInfoGeneralCodeplugVersion_A7683_UIValue;
      if (versionA7683UiValue.Length > 2 && int.TryParse(versionA7683UiValue.Substring(1, 2).ToString(), out result))
        return result >= 20;
    }
    return true;
  }

  private void SyncAstroOtarInhibit(ASTROOTAR astroOtarRec = null)
  {
    ASTROOTAR astrootar = astroOtarRec ?? (FeatureManager.GetFeature(2021)[0] as Motorola.MackinawCPS.CoreFeatures.SecureWide.SecureWide).ASTROOTAR;
    foreach (Motorola.MackinawCPS.CoreFeatures.SecureKMFProfile.SecureKMFProfile secureKmfProfile in (Collection<AcpBusinessLayer.FeatureNode>) (FeatureManager.GetFeature(2055) as SecureKMFProfileRecset))
    {
      if (!secureKmfProfile.General.SecKmfProfGenIndependentKeyList_43597.Value)
        secureKmfProfile.ASTROOTARInformation.SecKmfProfRadioInhibitViaASTROOTAR_43690.Value = astrootar.SecWideASTROOTARRadioInhibitviaASTROOTAR_A8834.Value;
    }
  }

  private void FixUpSecureHardwareEncryptionIndependentKeyList()
  {
    if (!(FeatureManager.GetFeature(2055) is SecureKMFProfileRecset feature))
      return;
    for (int index = 0; index < feature.Count; ++index)
    {
      if (feature[index][10881].EmbeddedRecset is SecureHardwareEncryptionIndependentKeyListInnerRecset embeddedRecset && embeddedRecset.Count == 0)
        embeddedRecset.AddRecord(embeddedRecset.CreateDefaultRecord());
    }
  }

  private void FixUpMPLVisiblityOnTrukingButton()
  {
    if (!(FeatureManager.GetFeature(2042) is ButtonsRecset feature) || feature.Count <= 0 || !(feature[0][10091].EmbeddedRecset is PortableButtonInnerRecset embeddedRecset) || embeddedRecset.Count <= 0)
      return;
    foreach (PortableButtonInner portableButtonInner in (Collection<AcpBusinessLayer.FeatureNode>) embeddedRecset)
    {
      if (portableButtonInner.PortableButtonInnerSection.BtnTrunkingPortableButtonFeature_A19546.Value == 63 /*0x3F*/)
        portableButtonInner.PortableButtonInnerSection.BtnTrunkingPortableButtonFeature_A19546.Value = 35;
    }
  }

  private void FixUpUnlockPasswordUNKNOWNValueToEmptyString()
  {
    switch ((FeatureManager.GetFeature(2045) as RadioWideRecset)[0][10102] is UserInformationAndPasswords informationAndPasswords ? informationAndPasswords.RadWideUserInformationandPasswordsUnlockPassword_A8690Value : (string) null)
    {
      case "UNKNOWN!":
        informationAndPasswords.RadWideUserInformationandPasswordsUnlockPassword_A8690Value = "";
        break;
    }
  }

  private void FixUpConventionalDynamicIDWithPasswordWrongValueToEmptyString()
  {
    switch ((FeatureManager.GetFeature(2045) as RadioWideRecset)[0][10102] is UserInformationAndPasswords informationAndPasswords ? informationAndPasswords.RadWideConventionalDynamicIDWithPassword_A43705Value : (string) null)
    {
      case "****":
        informationAndPasswords.RadWideConventionalDynamicIDWithPassword_A43705Value = "";
        break;
    }
  }

  private void FixUpSetCodeplugNameToDefaultValueIfEmpty()
  {
    string str = FeatureManager.GetFeature(2049)[0] is Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation radioInformation ? radioInformation.General?.RadInfoGeneralCodeplugName?.Value : (string) null;
    if (str == null || !str.Equals(string.Empty))
      return;
    radioInformation.General.RadInfoGeneralCodeplugNameValue = "My Codeplug";
  }

  private void FixUpSetNFPACompliantToTrueIfNFPARadio()
  {
    if (this.CodeplugVersion.Major >= 36 || !UtilityMack.IsNFPARadio)
      return;
    Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide radioWide = FeatureManager.GetFeature(2045)[0] as Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide;
    bool? nullable = radioWide.Features?.RadWideFeaturesNFPACompliant?.Value;
    bool flag = false;
    if (!(nullable.GetValueOrDefault() == flag & nullable.HasValue))
      return;
    radioWide.Features.RadWideFeaturesNFPACompliant.Value = true;
  }

  private void FixUpMPLVisiblityOnTrukingAccyButton()
  {
    if (!(FeatureManager.GetFeature(2036) is RemoteSpeakerMicRecset feature) || feature.Count <= 0 || !(feature[0][10079].EmbeddedRecset is RSMButtonInnerRecset embeddedRecset) || embeddedRecset.Count <= 0)
      return;
    foreach (RSMButtonInner rsmButtonInner in (Collection<AcpBusinessLayer.FeatureNode>) embeddedRecset)
    {
      if (rsmButtonInner.RSMButtonInnerSection.RadErgoCfgRSMlTrunkingFeature_A19742.Value == 63 /*0x3F*/)
        rsmButtonInner.RSMButtonInnerSection.RadErgoCfgRSMlTrunkingFeature_A19742.Value = 35;
    }
  }

  private void FixUpChannelSearchVisiblityOnPortableButtons()
  {
    if (!UtilityMack.IsAlohaRadio || !(FeatureManager.GetFeature(2042) is ButtonsRecset feature) || feature.Count <= 0 || !(feature[0][10091].EmbeddedRecset is PortableButtonInnerRecset embeddedRecset) || embeddedRecset.Count <= 0)
      return;
    foreach (PortableButtonInner portableButtonInner in (Collection<AcpBusinessLayer.FeatureNode>) embeddedRecset)
    {
      if (portableButtonInner.PortableButtonInnerSection.BtnGeneralConventionalFeature_A19544.Value == 219)
        portableButtonInner.PortableButtonInnerSection.BtnGeneralConventionalFeature_A19544.Value = 35;
      if (portableButtonInner.PortableButtonInnerSection.BtnTrunkingPortableButtonFeature_A19546.Value == 219)
        portableButtonInner.PortableButtonInnerSection.BtnTrunkingPortableButtonFeature_A19546.Value = 35;
    }
  }

  private void FixUpChannelSearchVisiblityOnRSMButton()
  {
    if (!UtilityMack.IsAlohaRadio || !(FeatureManager.GetFeature(2036) is RemoteSpeakerMicRecset feature) || feature.Count <= 0 || !(feature[0][10079].EmbeddedRecset is RSMButtonInnerRecset embeddedRecset) || embeddedRecset.Count <= 0)
      return;
    foreach (RSMButtonInner rsmButtonInner in (Collection<AcpBusinessLayer.FeatureNode>) embeddedRecset)
    {
      if (rsmButtonInner.RSMButtonInnerSection.RadErgoCfgRSMlConventionalFeature_A19640.Value == 219)
        rsmButtonInner.RSMButtonInnerSection.RadErgoCfgRSMlConventionalFeature_A19640.Value = 35;
      if (rsmButtonInner.RSMButtonInnerSection.RadErgoCfgRSMlTrunkingFeature_A19742.Value == 219)
        rsmButtonInner.RSMButtonInnerSection.RadErgoCfgRSMlTrunkingFeature_A19742.Value = 35;
    }
  }

  internal void WindowMain_ProgressUpdate(ProgressChangedEventArgs progress)
  {
    this.progressPage.ProgressUpdat((object) this, progress);
  }

  internal void WindowMain_DisplayCBI(SpecialFeatures.Comms.Comms.CBIReturn CbiSN)
  {
    this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Delegate) new WindowMain.MainUIDisplayCBI(this.DisplayCBI), (object) CbiSN);
  }

  internal void DisplayCBI(SpecialFeatures.Comms.Comms.CBIReturn CbiSN)
  {
    if ((bool) System.Windows.Application.Current.Properties[(object) "CommandLineCPS"])
      return;
    CbiSerNumWind cbiSerNumWind = new CbiSerNumWind();
    cbiSerNumWind.ShowDialog();
    CbiSN(cbiSerNumWind.SerNum);
    Semaphore.OpenExisting("CBIDisplayWait").Release(1);
  }

  internal void WindowMain_DisplayOTAP(
    ProgrammingOperation ProgOp,
    OTAPProgrammingParameters LastCommsOTAPUserState,
    SpecialFeatures.Comms.Comms.RadioOTAPObject RadioObject)
  {
    this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Delegate) new WindowMain.MainUIDisplayOTAP(this.DisplayOTAP), (object) ProgOp, (object) LastCommsOTAPUserState, (object) RadioObject);
  }

  internal void DisplayOTAP(
    ProgrammingOperation ProgOp,
    OTAPProgrammingParameters LastCommsOTAPUserState,
    SpecialFeatures.Comms.Comms.RadioOTAPObject RadioObject)
  {
    if ((bool) System.Windows.Application.Current.Properties[(object) "CommandLineCPS"])
      return;
    OTAPProgrammingWindow programmingWindow = new OTAPProgrammingWindow(ProgOp, LastCommsOTAPUserState);
    Window mainWindow = System.Windows.Application.Current.MainWindow;
    programmingWindow.Owner = mainWindow;
    bool? otapDialogResult = programmingWindow.ShowDialog();
    RadioObject(otapDialogResult, programmingWindow.OTAPProgrammingLastState, programmingWindow.PrescenceResult);
    Semaphore.OpenExisting("OTAPDisplayWait").Release(1);
  }

  internal void WindowMain_DisplayRadioQuery(SpecialFeatures.Comms.Comms.RadioRtn RadioRtn)
  {
    this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Delegate) new WindowMain.WriteRadioQuery(this.DisplayRadioQuery), (object) RadioRtn);
  }

  internal void DisplayRadioQuery(SpecialFeatures.Comms.Comms.RadioRtn RadioRtn)
  {
    if ((bool) System.Windows.Application.Current.Properties[(object) "CommandLineCPS"])
      return;
    MessageBoxResult RadioRtn1 = System.Windows.MessageBox.Show(AppResources.Warning_You_are_about_to_write_protect_the_attached_radio, AppResources.Radio_Write_Protect_Warning, MessageBoxButton.OKCancel, MessageBoxImage.Exclamation);
    RadioRtn(RadioRtn1);
    Semaphore.OpenExisting("RadioWriteRet").Release(1);
  }

  internal void LaunchWriteRadio(int myTransport, bool updateWriteProtect = false)
  {
    bool flag1 = false;
    string errorMessage = "";
    this.dvrsMsuDataSync = (DvrsMsuDataSync) null;
    UndoManager.StopUndoRedo();
    SpecialFeatures.Comms.Comms comms = new SpecialFeatures.Comms.Comms();
    bool wp;
    bool askReq;
    int ownerKeyType;
    int ownerSysId;
    int ownerWacnId;
    ASKProgrammingHistoryInnerRecset askProgRecset;
    int programmingPath;
    bool flag2 = RadioAccessValidator.CacheCodeplugSecurityFields(out wp, out askReq, out ownerKeyType, out ownerSysId, out ownerWacnId, out askProgRecset, out programmingPath);
    Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation radioInfo = FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation;
    string newValue = "";
    COMMS_OP commsOp1;
    switch (myTransport)
    {
      case 0:
        commsOp1 = COMMS_OP.USB_READ_WRITE;
        break;
      case 1:
        commsOp1 = COMMS_OP.OTAP_READ_WRITE;
        break;
      case 2:
        commsOp1 = COMMS_OP.BLUETOOTH_READ_WRITE;
        break;
      default:
        commsOp1 = COMMS_OP.USB_READ_WRITE;
        break;
    }
    COMMS_OP commsOp2 = commsOp1;
    try
    {
      bool flag3 = true;
      SpecialFeatures.Comms.Comms.updateStatus += new SpecialFeatures.Comms.Comms.DisplayUpdateStatus(this.ReadRadio_updateStatus);
      SpecialFeatures.Comms.Comms.displayCBI += new SpecialFeatures.Comms.Comms.MainUIDisplayCBI(this.WindowMain_DisplayCBI);
      SpecialFeatures.Comms.Comms.displayOTAP += new SpecialFeatures.Comms.Comms.MainUIDisplayOTAP(this.WindowMain_DisplayOTAP);
      if (commsOp2 == COMMS_OP.USB_READ_WRITE)
      {
        MultiCodeplugInfo multiCodeplugInfo = MultiCodeplugUtility.TryGetMultiCodeplugInfo(ref this._shouldResetRadio);
        flag3 = this.ValidateCodeplugNamesBeforeWrite(radioInfo, multiCodeplugInfo, ref errorMessage) || this.ValidateSecondaryCodeplugLanguagePacks(multiCodeplugInfo, ref errorMessage);
        if (!flag3)
          flag3 = comms.blockRadioWrite(commsOp2, this._shouldResetRadio, updateWriteProtect: updateWriteProtect);
      }
      if (commsOp2 == COMMS_OP.OTAP_READ_WRITE && this.Pop25Enabled)
      {
        flag3 = comms.blockRadioWrite(commsOp2, this._shouldResetRadio, this.commsLastUserState);
        this.commsLastUserState = comms.GetLastCommsOTAPUserState();
      }
      if (commsOp2 == COMMS_OP.BLUETOOTH_READ_WRITE)
        flag3 = comms.blockRadioWrite(commsOp2, this._shouldResetRadio, this.commsLastUserState);
      if (commsOp2 == COMMS_OP.OTAP_READ_WRITE && !this.Pop25Enabled)
      {
        errorMessage = AppResources.Please_attach_and_load_the_hardware_Key_to_proceed_with_Otap_Read_Write;
        this.ReadRadio_updateStatus(0.0, errorMessage);
      }
      if (!flag3)
      {
        bool read = false;
        bool write = false;
        bool archive = false;
        string empty = string.Empty;
        comms.GetReadWritePassword(ref read, ref write, ref archive, ref empty);
        if ((bool) System.Windows.Application.Current.Properties[(object) "CommandLineCPS"])
          write = false;
        string serialNumber = ParseDataHelper.RadioSNToString(comms.GetRadioParams().SerialNumber);
        if (write && !this._readWritePasswordApp.ValidateOKToReadWrite((Window) this, empty, serialNumber, ReadWritePasswordApp.ValidType.Write))
        {
          this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Delegate) new WindowMain.CloseProgressWindow(this.WindowMain_CloseProgressWindow));
          comms.ForceClose();
        }
        else
        {
          newValue = radioInfo.General.RadInfoGeneralCodeplugVersion_A7683_UIValue;
          radioInfo.General.RadInfoGeneralCodeplugVersion_A7683.SetValue(this.cpsVersion);
          LastSetJobUuidHelper.SetLastSetJobUuidField();
          if (UtilityMack.IsAPXNextOrAloha)
            (FeatureManager.GetFeature(2045)[0] as Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide).Labtool.RadWideLabtoolDeviceMgmtEnterpriseWifiCodeplugIdValue = Guid.NewGuid().ToString("N").ToUpper();
          Motorola.MackinawCPS.CoreFeatures.DVRSWide.DVRSWide dvrsWide = FeatureManager.GetFeature(4142)[0] as Motorola.MackinawCPS.CoreFeatures.DVRSWide.DVRSWide;
          if (dvrsWide.General.RadErgoWideDigitalVehicularRepeaterSystemDVRSHardwareEnable_A7911.Value)
          {
            this.dvrsMsuDataSync = new DvrsMsuDataSync();
            uint hashCode = this.dvrsMsuDataSync.CalculateHashCode();
            dvrsWide.General.DVRSWideLabtoolDVRSSyncFieldsHash_A41811.SetValue((long) hashCode);
          }
          comms.UpdatePINPasswordBeforeWrite();
          this.UpdateCodeplugPSKField();
          this.ResetOOBEField();
          (IshItemCollection radioCodeplug, long codeplugPackedSize) = comms.PackToCodeplug();
          if (radioCodeplug != null)
          {
            if (radioCodeplug.Count > 0)
            {
              switch (commsOp2)
              {
                case COMMS_OP.USB_READ_WRITE:
                  flag1 = comms.WriteRadio(radioCodeplug, codeplugPackedSize, commsOp2, shouldResetRadio: this._shouldResetRadio);
                  break;
                case COMMS_OP.OTAP_READ_WRITE:
                  flag1 = comms.WriteRadio(radioCodeplug, codeplugPackedSize, commsOp2, this.commsLastUserState, this._shouldResetRadio);
                  this.commsLastUserState = comms.GetLastCommsOTAPUserState();
                  break;
                case COMMS_OP.BLUETOOTH_READ_WRITE:
                  flag1 = comms.WriteRadio(radioCodeplug, codeplugPackedSize, commsOp2, this.commsLastUserState, this._shouldResetRadio);
                  break;
              }
            }
            else
            {
              errorMessage = AppResources.A_problem_was_encountered_Unable_to_write_to_the_radio;
              this.ReadRadio_updateStatus(0.0, errorMessage);
            }
          }
          else
          {
            errorMessage = AppResources.A_problem_was_encountered_Unable_to_write_to_the_radio;
            this.ReadRadio_updateStatus(0.0, errorMessage);
          }
          if (!flag1)
          {
            if (radioCodeplug == null)
              comms.ForceClose();
            if (newValue != "")
              radioInfo.General.RadInfoGeneralCodeplugVersion_A7683.SetValue(newValue);
          }
        }
      }
      else if (string.IsNullOrEmpty(errorMessage))
        errorMessage = AppResources.A_problem_was_encountered_Unable_to_write_to_the_radio;
      if (flag2)
        RadioAccessValidator.RestoreCachedCodeplugSecurityFields(wp, askReq, ownerKeyType, ownerSysId, ownerWacnId, askProgRecset, programmingPath);
      this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Delegate) new WindowMain.ReadComplete(this.WindowMain_WriteRadioFinished), (object) flag1, (object) errorMessage, (object) comms.m_LastLPKUserState, (object) comms.GetRadioParams());
      SpecialFeatures.Comms.Comms.updateStatus -= new SpecialFeatures.Comms.Comms.DisplayUpdateStatus(this.ReadRadio_updateStatus);
      SpecialFeatures.Comms.Comms.displayCBI -= new SpecialFeatures.Comms.Comms.MainUIDisplayCBI(this.WindowMain_DisplayCBI);
      SpecialFeatures.Comms.Comms.displayOTAP -= new SpecialFeatures.Comms.Comms.MainUIDisplayOTAP(this.WindowMain_DisplayOTAP);
    }
    catch (Exception ex)
    {
      UndoManager.StartUndoRedo();
      if (!(ex.Message == AppResources.Codeplug_Exceeds_Size_Limit_On_Write))
        return;
      if (!flag1 && newValue != "")
        radioInfo.General.RadInfoGeneralCodeplugVersion_A7683.SetValue(newValue);
      if (flag2)
        RadioAccessValidator.RestoreCachedCodeplugSecurityFields(wp, askReq, ownerKeyType, ownerSysId, ownerWacnId, askProgRecset, programmingPath);
      this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Delegate) new WindowMain.ReadComplete(this.WindowMain_WriteRadioFinished), (object) flag1, (object) errorMessage, (object) comms.m_LastLPKUserState, (object) comms.GetRadioParams());
      SpecialFeatures.Comms.Comms.updateStatus -= new SpecialFeatures.Comms.Comms.DisplayUpdateStatus(this.ReadRadio_updateStatus);
      SpecialFeatures.Comms.Comms.displayCBI -= new SpecialFeatures.Comms.Comms.MainUIDisplayCBI(this.WindowMain_DisplayCBI);
      SpecialFeatures.Comms.Comms.displayOTAP -= new SpecialFeatures.Comms.Comms.MainUIDisplayOTAP(this.WindowMain_DisplayOTAP);
      comms.ResetApRadioIfPossible(commsOp2, radioInfo.General.RadInfoGeneralModelNumber_A8539.Value, this._shouldResetRadio);
    }
    finally
    {
      comms.Dispose();
      this._readWritePasswordApp.ClearCachedPasswordValidation();
      this.ReadWriteInProgress = false;
    }
  }

  private bool ValidateCodeplugNamesBeforeWrite(
    Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation radioInfo,
    MultiCodeplugInfo currentRadioCodeplugInfo,
    ref string errorMessage)
  {
    if (currentRadioCodeplugInfo == null)
      return false;
    string currentCodeplugName = radioInfo.General.RadInfoGeneralCodeplugName.Value;
    if (MultiCodeplugUtility.ValidateCodeplugNames(currentRadioCodeplugInfo, currentCodeplugName))
      return false;
    errorMessage = AppResources.Provided_Codeplug_Name_already_used;
    this.ReadRadio_updateStatus(0.0, errorMessage);
    return true;
  }

  private bool ValidateSecondaryCodeplugLanguagePacks(
    MultiCodeplugInfo currentRadioCodeplugInfo,
    ref string errorMessage)
  {
    if (currentRadioCodeplugInfo == null || currentRadioCodeplugInfo.ActiveCodeplugIndex == 0)
      return false;
    int num = (FeatureManager.GetFeature(2010)[0] as Motorola.MackinawCPS.CoreFeatures.DisplayAndMenu.DisplayAndMenu).Advanced.DispMenuAdvancedLanguageSelection_A8386.Value;
    if (currentRadioCodeplugInfo.PrimaryCodeplugLanguagePack == (ASTROLanguageSelection) num)
      return false;
    errorMessage = AppResources.MultiCodeplug_LanguagePack_ShouldMatch_PrimaryCodeplug;
    this.ReadRadio_updateStatus(0.0, errorMessage);
    return true;
  }

  private void UpdateCodeplugPSKField()
  {
    Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide radioWide = FeatureManager.GetFeature(2045)[0] as Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide;
    string passwordA8837Value = radioWide.Labtool.RadWideLabtoolRadioPassword_A8837Value;
    if (ReadWriteTlsPskHelper.IsPasswordEnabled(radioWide.Labtool.RadWideLabtoolRadioReadPasswordEnable_A8869Value, radioWide.Labtool.RadWideLabtoolRadioWritePasswordEnable_A8889Value, passwordA8837Value))
      this._tlsPskHelper.SetTlsPskHashInCodeplug(this._readWriteUtil.decryptMesg(passwordA8837Value));
    else
      this._tlsPskHelper.ResetTlsPskFields();
  }

  internal void WindowMain_WriteRadioFinished(
    bool stat,
    string strErrorMessage,
    string infoMsg,
    RadioParams radioPara)
  {
    StatusMsgType type = StatusMsgType.Error;
    string message = strErrorMessage;
    if (stat)
    {
      type = StatusMsgType.Info;
      message = AppResources.Write_Complete;
      this.progressPage.SetCloseBtnEnable(true);
      this.progressPage.Close();
      UndoManager.Reset();
      if (this.dvrsMsuDataSync != null)
        this.dvrsMsuDataSync.ExportToXmlDoc($"{this.defaultDVRSFileLocation}\\{this.dvrsMsuDataSync.BuildFileName()}");
    }
    if (message.Length > 0)
    {
      AppInfoManager.StatusMsgReport.RegisterMessage(type, message);
      if (infoMsg != null)
      {
        if (infoMsg == AppResources.LP_Radio_display_Language_Not_Supported_By_this_radio || !string.IsNullOrEmpty(LanguagePackHelper.warningOTAPMessage))
        {
          type = StatusMsgType.Warning;
          LanguagePackHelper.warningOTAPMessage = string.Empty;
        }
        AppInfoManager.StatusMsgReport.RegisterMessage(type, infoMsg);
      }
    }
    UndoManager.StartUndoRedo();
  }

  internal void ReadRadio_updateStatus(double n, string stat)
  {
    if ((bool) System.Windows.Application.Current.Properties[(object) "CommandLineCPS"])
      return;
    int progressPercentage = (int) (n * 100.0);
    SpecialFeatures.Flashport.FlashRadio.ProgressUserState userState = (SpecialFeatures.Flashport.FlashRadio.ProgressUserState) null;
    if (stat == AppResources.Opening_Port)
      userState = new SpecialFeatures.Flashport.FlashRadio.ProgressUserState(SpecialFeatures.Flashport.FlashRadio.UserState.ConnectStart, SpecialFeatures.Flashport.FlashRadio.UserState.None, AppResources.Opening_Connection_To_Radio);
    else if (stat == AppResources.Open_Port_Complete)
      userState = new SpecialFeatures.Flashport.FlashRadio.ProgressUserState(SpecialFeatures.Flashport.FlashRadio.UserState.ConnectDone, SpecialFeatures.Flashport.FlashRadio.UserState.None, AppResources.Connecting_opened_to_radio);
    else if (stat == AppResources.Read_Radio_Info)
      userState = new SpecialFeatures.Flashport.FlashRadio.ProgressUserState(SpecialFeatures.Flashport.FlashRadio.UserState.ReadRadInfoStart, SpecialFeatures.Flashport.FlashRadio.UserState.None, AppResources.Read_radio_info_start_);
    else if (stat == AppResources.Read_Radio_Info_Complete)
      userState = new SpecialFeatures.Flashport.FlashRadio.ProgressUserState(SpecialFeatures.Flashport.FlashRadio.UserState.ReadRadInfoDone, SpecialFeatures.Flashport.FlashRadio.UserState.None, AppResources.Read_radio_info_complete_);
    else if (stat == AppResources.ReadRadio_Calling_End_Read_Radio)
      userState = new SpecialFeatures.Flashport.FlashRadio.ProgressUserState(SpecialFeatures.Flashport.FlashRadio.UserState.CodeplugDone, SpecialFeatures.Flashport.FlashRadio.UserState.None, AppResources.Read_radio_codeplug_complete);
    else if (stat == AppResources.Reading_radio_codeplug_completed)
      userState = new SpecialFeatures.Flashport.FlashRadio.ProgressUserState(SpecialFeatures.Flashport.FlashRadio.UserState.None, SpecialFeatures.Flashport.FlashRadio.UserState.None, AppResources.Reading_radio_codeplug_);
    else if (stat == AppResources.Reading_radio_codeplug_)
      userState = new SpecialFeatures.Flashport.FlashRadio.ProgressUserState(SpecialFeatures.Flashport.FlashRadio.UserState.None, SpecialFeatures.Flashport.FlashRadio.UserState.None, AppResources.Reading_radio_codeplug_);
    else if (stat == AppResources.ReadRadio_Reading_codeplug_from_radio)
      userState = new SpecialFeatures.Flashport.FlashRadio.ProgressUserState(SpecialFeatures.Flashport.FlashRadio.UserState.CodeplugStart, SpecialFeatures.Flashport.FlashRadio.UserState.None, AppResources.Begin_read_codeplug);
    else if (stat == AppResources.Read_Radio_Verification_Start)
      userState = new SpecialFeatures.Flashport.FlashRadio.ProgressUserState(SpecialFeatures.Flashport.FlashRadio.UserState.FinalValidationStart, SpecialFeatures.Flashport.FlashRadio.UserState.None, AppResources.Read_Radio_Verification_Start_);
    else if (stat == AppResources.Read_Radio_Verification_)
      userState = new SpecialFeatures.Flashport.FlashRadio.ProgressUserState(SpecialFeatures.Flashport.FlashRadio.UserState.None, SpecialFeatures.Flashport.FlashRadio.UserState.None, AppResources.Read_Radio_Verification_);
    else if (stat == AppResources.Read_Radio_Verification_Complete)
      userState = new SpecialFeatures.Flashport.FlashRadio.ProgressUserState(SpecialFeatures.Flashport.FlashRadio.UserState.FinalValidationDone, SpecialFeatures.Flashport.FlashRadio.UserState.None, AppResources.Read_Radio_Verification_Complete);
    else if (stat == AppResources.Read_Radio_Verification_Fail)
      userState = new SpecialFeatures.Flashport.FlashRadio.ProgressUserState(SpecialFeatures.Flashport.FlashRadio.UserState.FinalValidationError, SpecialFeatures.Flashport.FlashRadio.UserState.None, AppResources.Read_Radio_Verification_Fail);
    else if (stat == AppResources.Unpack_failure_during_read)
      userState = new SpecialFeatures.Flashport.FlashRadio.ProgressUserState(SpecialFeatures.Flashport.FlashRadio.UserState.FinalValidationError, SpecialFeatures.Flashport.FlashRadio.UserState.None, AppResources.Read_radio_unpack_failure);
    else if (stat == AppResources.Writing_radio_codeplug)
      userState = new SpecialFeatures.Flashport.FlashRadio.ProgressUserState(SpecialFeatures.Flashport.FlashRadio.UserState.None, SpecialFeatures.Flashport.FlashRadio.UserState.None, AppResources.Write_to_radio_in_progress);
    else if (stat == AppResources.WriteRadio_Writing_codeplug_to_radio)
      userState = new SpecialFeatures.Flashport.FlashRadio.ProgressUserState(SpecialFeatures.Flashport.FlashRadio.UserState.FlashingComponentStart, SpecialFeatures.Flashport.FlashRadio.UserState.None, AppResources.Begin_write_to_radio);
    else if (stat == AppResources.Writing_radio_codeplug_completed)
      userState = new SpecialFeatures.Flashport.FlashRadio.ProgressUserState(SpecialFeatures.Flashport.FlashRadio.UserState.FlashingComponentDone, SpecialFeatures.Flashport.FlashRadio.UserState.None, AppResources.Write_to_radio_complete);
    else if (stat == AppResources.WriteRadio_eject_radio)
      userState = new SpecialFeatures.Flashport.FlashRadio.ProgressUserState(SpecialFeatures.Flashport.FlashRadio.UserState.FinalValidationStart, SpecialFeatures.Flashport.FlashRadio.UserState.None, AppResources.Write_radio_releasing_radio);
    else if (!(stat == AppResources.Wait_For_Radio_Eject))
    {
      if (stat == AppResources.A_problem_was_encountered_Unable_to_write_to_the_radio)
        userState = new SpecialFeatures.Flashport.FlashRadio.ProgressUserState(SpecialFeatures.Flashport.FlashRadio.UserState.ReadRadInfoError, SpecialFeatures.Flashport.FlashRadio.UserState.None, stat);
      else if (stat == AppResources.WriteRadio_Close_Port)
        userState = new SpecialFeatures.Flashport.FlashRadio.ProgressUserState(SpecialFeatures.Flashport.FlashRadio.UserState.FinalValidationDone, SpecialFeatures.Flashport.FlashRadio.UserState.None, AppResources.Write_radio_release_complete);
      else if (stat == AppResources.Radio_Erase_in_Progress_please_wait)
        userState = new SpecialFeatures.Flashport.FlashRadio.ProgressUserState(SpecialFeatures.Flashport.FlashRadio.UserState.None, SpecialFeatures.Flashport.FlashRadio.UserState.None, AppResources.Radio_Erasing_please_wait);
      else if (stat == AppResources.Radio_Serial_Number_updated)
        userState = new SpecialFeatures.Flashport.FlashRadio.ProgressUserState(SpecialFeatures.Flashport.FlashRadio.UserState.ReadRadInfoDone, SpecialFeatures.Flashport.FlashRadio.UserState.None, AppResources.Radio_Serial_Number_updated);
      else if (stat == AppResources.Radio_Serial_Number_update_failed)
        userState = new SpecialFeatures.Flashport.FlashRadio.ProgressUserState(SpecialFeatures.Flashport.FlashRadio.UserState.ReadRadInfoError, SpecialFeatures.Flashport.FlashRadio.UserState.None, AppResources.Radio_Serial_Number_update_failed);
      else if (stat == AppResources.Please_Read_CBI_initialized_radio_first)
        userState = new SpecialFeatures.Flashport.FlashRadio.ProgressUserState(SpecialFeatures.Flashport.FlashRadio.UserState.ReadRadInfoError, SpecialFeatures.Flashport.FlashRadio.UserState.None, stat);
      else if (stat == AppResources.Failed_Radio_Serial_Number_read)
        userState = new SpecialFeatures.Flashport.FlashRadio.ProgressUserState(SpecialFeatures.Flashport.FlashRadio.UserState.ReadRadInfoError, SpecialFeatures.Flashport.FlashRadio.UserState.None, stat);
      else if (stat == AppResources.Failure_when_attempting_opening_connection)
        userState = new SpecialFeatures.Flashport.FlashRadio.ProgressUserState(SpecialFeatures.Flashport.FlashRadio.UserState.ConnectError, SpecialFeatures.Flashport.FlashRadio.UserState.None, stat);
      else if (stat == AppResources.OperationCanceled)
        userState = new SpecialFeatures.Flashport.FlashRadio.ProgressUserState(SpecialFeatures.Flashport.FlashRadio.UserState.ConnectError, SpecialFeatures.Flashport.FlashRadio.UserState.None, stat);
      else if (stat == AppResources.Provided_Codeplug_Name_already_used)
        userState = new SpecialFeatures.Flashport.FlashRadio.ProgressUserState(SpecialFeatures.Flashport.FlashRadio.UserState.CodeplugError, SpecialFeatures.Flashport.FlashRadio.UserState.None, stat);
      else if (stat == AppResources.MultiCodeplug_LanguagePack_ShouldMatch_PrimaryCodeplug)
        userState = new SpecialFeatures.Flashport.FlashRadio.ProgressUserState(SpecialFeatures.Flashport.FlashRadio.UserState.CodeplugError, SpecialFeatures.Flashport.FlashRadio.UserState.None, stat);
      else if (stat == AppResources.Active_Codeplug_Is_Invalid)
        userState = new SpecialFeatures.Flashport.FlashRadio.ProgressUserState(SpecialFeatures.Flashport.FlashRadio.UserState.CodeplugError, SpecialFeatures.Flashport.FlashRadio.UserState.None, stat);
      else if (stat == AppResources.Codeplug_Exceeds_Size_Limit_On_Write)
        userState = new SpecialFeatures.Flashport.FlashRadio.ProgressUserState(SpecialFeatures.Flashport.FlashRadio.UserState.CodeplugError, SpecialFeatures.Flashport.FlashRadio.UserState.None, stat);
      else if (stat == AppResources.LP_Language_Pack_Update_Success)
        userState = new SpecialFeatures.Flashport.FlashRadio.ProgressUserState(SpecialFeatures.Flashport.FlashRadio.UserState.None, SpecialFeatures.Flashport.FlashRadio.UserState.None, stat);
      else if (stat == AppResources.LP_Begin_Language_Pack_Update)
        userState = new SpecialFeatures.Flashport.FlashRadio.ProgressUserState(SpecialFeatures.Flashport.FlashRadio.UserState.CodeplugStart, SpecialFeatures.Flashport.FlashRadio.UserState.None, stat);
      else if (stat == AppResources.LP_Cannot_Determine_Host_Version)
        userState = new SpecialFeatures.Flashport.FlashRadio.ProgressUserState(SpecialFeatures.Flashport.FlashRadio.UserState.None, SpecialFeatures.Flashport.FlashRadio.UserState.None, stat);
      else if (!(stat == AppResources.LP_Radio_display_Language_Not_Supported_By_this_radio))
        userState = new SpecialFeatures.Flashport.FlashRadio.ProgressUserState(SpecialFeatures.Flashport.FlashRadio.UserState.CodeplugError, SpecialFeatures.Flashport.FlashRadio.UserState.None, stat);
    }
    if (userState == null)
      return;
    ProgressChangedEventArgs changedEventArgs = new ProgressChangedEventArgs(progressPercentage, (object) userState);
    stat += Convert.ToString(n * 100.0);
    this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Delegate) new WindowMain.UpdateProgress(this.WindowMain_ProgressUpdate), (object) changedEventArgs);
  }

  private void Device_TransportComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
  {
    foreach (ContentControl addedItem in (IEnumerable) e.AddedItems)
    {
      string content = addedItem.Content as string;
      if (content.Contains(AppResources.USB_ID))
      {
        this.ReadWriteTransport = 0;
        if (this.labBTIPAddressForWR != null && this.txtBTIPAddressForWR != null)
          this.SetNonBluetoothProgrammingMode((UIElement) this.labBTIPAddressForWR, (UIElement) this.txtBTIPAddressForWR);
      }
      else if (content.Contains(AppResources.POP25_Id))
      {
        this.ReadWriteTransport = 1;
        if (this.labBTIPAddressForWR != null && this.txtBTIPAddressForWR != null)
          this.SetNonBluetoothProgrammingMode((UIElement) this.labBTIPAddressForWR, (UIElement) this.txtBTIPAddressForWR);
      }
      else if (content.Contains(AppResources.Bluetooth_Id))
      {
        this.ReadWriteTransport = 2;
        if (this.labBTIPAddressForWR != null && this.txtBTIPAddressForWR != null)
          this.SetBluetoothProgrammingMode((UIElement) this.labBTIPAddressForWR, (UIElement) this.txtBTIPAddressForWR);
      }
      else
      {
        this.ReadWriteTransport = 0;
        if (this.labBTIPAddressForWR != null && this.txtBTIPAddressForWR != null)
          this.SetNonBluetoothProgrammingMode((UIElement) this.labBTIPAddressForWR, (UIElement) this.txtBTIPAddressForWR);
      }
    }
  }

  private void Device_CloneTransport_SelectionChanged(object sender, SelectionChangedEventArgs e)
  {
    foreach (ContentControl addedItem in (IEnumerable) e.AddedItems)
    {
      string content = addedItem.Content as string;
      if (content.Contains(AppResources.USB_ID))
      {
        this.CloneTransport = 0;
        if (this.labBTIPAddressForClone != null && this.txtBTIPAddressForClone != null)
          this.SetNonBluetoothProgrammingMode((UIElement) this.labBTIPAddressForClone, (UIElement) this.txtBTIPAddressForClone);
      }
      else if (content.Contains(AppResources.POP25_Id))
      {
        this.CloneTransport = 1;
        if (this.labBTIPAddressForClone != null && this.txtBTIPAddressForClone != null)
          this.SetNonBluetoothProgrammingMode((UIElement) this.labBTIPAddressForClone, (UIElement) this.txtBTIPAddressForClone);
      }
      else if (content.Contains(AppResources.Bluetooth_Id))
      {
        this.CloneTransport = 2;
        if (this.labBTIPAddressForClone != null && this.txtBTIPAddressForClone != null)
          this.SetBluetoothProgrammingMode((UIElement) this.labBTIPAddressForClone, (UIElement) this.txtBTIPAddressForClone);
      }
      else
      {
        this.ReadWriteTransport = 0;
        if (this.labBTIPAddressForClone != null && this.txtBTIPAddressForClone != null)
          this.SetNonBluetoothProgrammingMode((UIElement) this.labBTIPAddressForClone, (UIElement) this.txtBTIPAddressForClone);
      }
    }
  }

  private void SetBluetoothProgrammingMode(UIElement btLabel, UIElement btControl)
  {
    btLabel.Visibility = Visibility.Visible;
    btControl.Visibility = Visibility.Visible;
    btControl.Focus();
    this.ribbonBarDevicePanel.Height = 95.0;
  }

  private void SetNonBluetoothProgrammingMode(UIElement btLabel, UIElement btControl)
  {
    btLabel.Visibility = Visibility.Collapsed;
    btControl.Visibility = Visibility.Collapsed;
    if (this.CloneTransport == 2 || this.ReadWriteTransport == 2)
      return;
    this.ribbonBarDevicePanel.Height = 70.0;
  }

  private void AddQC2DefaultRecord()
  {
    IAcpRecordset feature = FeatureManager.GetFeature(2053);
    if (feature == null)
      return;
    foreach (AcpBusinessLayer.FeatureNode featureNode in (Collection<AcpBusinessLayer.FeatureNode>) feature)
    {
      if (featureNode is Motorola.MackinawCPS.CoreFeatures.ConventionalSystem.ConventionalSystem && featureNode[10785].EmbeddedRecset is IndividualIDTonesInnerRecset embeddedRecset && embeddedRecset.Count == 1)
      {
        while (embeddedRecset.Count < 4)
          embeddedRecset.AddRecord(embeddedRecset.CreateDefaultRecord());
        (embeddedRecset[0] as IndividualIDTonesInner).IndividualIDTonesInnerSection.CnvSysGeneralQc2Name_A42231.Value = AppResources.QC2_Tone_A;
        IndividualIDTonesInnerSection tonesInnerSection1 = (embeddedRecset[1] as IndividualIDTonesInner).IndividualIDTonesInnerSection;
        tonesInnerSection1.CnvSysGeneralQc2Name_A42231.Value = AppResources.QC2_Tone_B;
        tonesInnerSection1.CnvSysGeneralQc2Freq_A42232.Value = 9032;
        tonesInnerSection1.CnvSysGeneralQc2Code_A42234.Value = 94;
        IndividualIDTonesInnerSection tonesInnerSection2 = (embeddedRecset[2] as IndividualIDTonesInner).IndividualIDTonesInnerSection;
        tonesInnerSection2.CnvSysGeneralQc2Name_A42231.Value = AppResources.QC2_Tone_C;
        tonesInnerSection2.CnvSysGeneralQc2Freq_A42232.Value = 2885;
        tonesInnerSection2.CnvSysGeneralQc2Code_A42234.Value = 1;
        IndividualIDTonesInnerSection tonesInnerSection3 = (embeddedRecset[3] as IndividualIDTonesInner).IndividualIDTonesInnerSection;
        tonesInnerSection3.CnvSysGeneralQc2Name_A42231.Value = AppResources.QC2_Tone_D;
        tonesInnerSection3.CnvSysGeneralQc2Freq_A42232.Value = 2885;
        tonesInnerSection3.CnvSysGeneralQc2Code_A42234.Value = 1;
      }
    }
  }

  private int FindCodeBasedonFreq(string UIValue)
  {
    double[] numArray = new double[138]
    {
      288.5,
      296.5,
      304.7,
      313.0,
      321.7,
      330.5,
      339.6,
      346.7,
      349.0,
      358.6,
      358.9,
      368.5,
      371.5,
      378.6,
      384.6,
      389.0,
      398.1,
      399.8,
      410.8,
      412.1,
      422.1,
      426.6,
      433.7,
      441.6,
      445.7,
      457.1,
      457.9,
      470.5,
      473.2,
      483.5,
      489.8,
      496.8,
      507.0,
      510.5,
      517.5,
      524.6,
      524.8,
      532.5,
      539.0,
      543.3,
      547.5,
      553.9,
      562.3,
      562.5,
      569.1,
      577.5,
      582.1,
      584.8,
      592.5,
      600.9,
      602.6,
      607.5,
      617.4,
      622.5,
      623.7,
      634.5,
      637.5,
      645.7,
      651.9,
      652.5,
      667.5,
      668.3,
      669.9,
      682.5,
      688.3,
      691.8,
      697.5,
      707.3,
      712.5,
      716.7,
      726.8,
      727.5,
      741.3,
      746.8,
      757.5,
      767.4,
      772.5,
      787.5,
      788.5,
      794.3,
      802.5,
      810.2,
      817.5,
      822.2,
      832.5,
      847.5,
      851.1,
      855.5,
      862.5,
      877.5,
      879.0,
      881.0,
      892.5,
      903.2,
      907.5,
      912.0,
      922.5,
      928.1,
      937.5,
      944.1,
      952.5,
      953.7,
      967.5,
      979.9,
      1006.9,
      1034.7,
      1063.2,
      1092.4,
      1122.5,
      1153.4,
      1185.2,
      1217.8,
      1251.4,
      1285.8,
      1321.2,
      1357.6,
      1395.0,
      1433.4,
      1472.9,
      1513.5,
      1555.2,
      1598.0,
      1642.0,
      1687.2,
      1733.7,
      1781.5,
      1830.5,
      1881.0,
      1930.2,
      1989.1,
      2043.8,
      2094.5,
      2155.6,
      2212.2,
      2271.7,
      2334.6,
      2401.0,
      2468.2
    };
    int num = -1;
    for (int index = 0; index < numArray.GetLength(0); ++index)
    {
      if (UIValue == numArray[index].ToString())
      {
        num = index;
        break;
      }
    }
    return num == -1 ? 0 : num + 1;
  }

  private void SyncQC2Code()
  {
    IAcpRecordset acpRecordset = AppInfoManager.AppMode != ApplicationMode.CodeplugConfigurationMode ? AppInfoManager.ComparatorDocument.GetFeature(2053) : FeatureManager.GetFeature(2053);
    if (acpRecordset == null)
      return;
    foreach (AcpBusinessLayer.FeatureNode featureNode in (Collection<AcpBusinessLayer.FeatureNode>) acpRecordset)
    {
      if (featureNode is Motorola.MackinawCPS.CoreFeatures.ConventionalSystem.ConventionalSystem)
      {
        IndividualIDTonesInnerRecset embeddedRecset = featureNode[10785].EmbeddedRecset as IndividualIDTonesInnerRecset;
        IndividualIDTonesInnerSection tonesInnerSection1 = (embeddedRecset[0] as IndividualIDTonesInner).IndividualIDTonesInnerSection;
        tonesInnerSection1.CnvSysGeneralQc2Code_A42234.Value = this.FindCodeBasedonFreq(tonesInnerSection1.CnvSysGeneralQc2Freq_A42232.UIValue);
        IndividualIDTonesInnerSection tonesInnerSection2 = (embeddedRecset[1] as IndividualIDTonesInner).IndividualIDTonesInnerSection;
        tonesInnerSection2.CnvSysGeneralQc2Code_A42234.Value = this.FindCodeBasedonFreq(tonesInnerSection2.CnvSysGeneralQc2Freq_A42232.UIValue);
        IndividualIDTonesInnerSection tonesInnerSection3 = (embeddedRecset[2] as IndividualIDTonesInner).IndividualIDTonesInnerSection;
        tonesInnerSection3.CnvSysGeneralQc2Code_A42234.Value = this.FindCodeBasedonFreq(tonesInnerSection3.CnvSysGeneralQc2Freq_A42232.UIValue);
        IndividualIDTonesInnerSection tonesInnerSection4 = (embeddedRecset[3] as IndividualIDTonesInner).IndividualIDTonesInnerSection;
        tonesInnerSection4.CnvSysGeneralQc2Code_A42234.Value = this.FindCodeBasedonFreq(tonesInnerSection4.CnvSysGeneralQc2Freq_A42232.UIValue);
      }
    }
  }

  private void AddO9DefaultDirLightBar()
  {
    DirectionalButtonsListInnerRecset embeddedRecset = (FeatureManager.GetFeature(4003) as ControlHeadO9Recset)[0][10609].EmbeddedRecset as DirectionalButtonsListInnerRecset;
    (embeddedRecset[0] as DirectionalButtonsListInner).DirectionalButtonsListInnerSection.RadErgCtrlHeadO9DirLightBarIndex_A36601.UIValue = AppResources.Pattern_1;
    (embeddedRecset[1] as DirectionalButtonsListInner).DirectionalButtonsListInnerSection.RadErgCtrlHeadO9DirLightBarIndex_A36601.UIValue = AppResources.Pattern_2;
    (embeddedRecset[2] as DirectionalButtonsListInner).DirectionalButtonsListInnerSection.RadErgCtrlHeadO9DirLightBarIndex_A36601.UIValue = AppResources.Pattern_3;
  }

  private void AddO9PhephedRecord()
  {
    SignalIndependentProductIndependentNonProgrammableButtonListInnerRecset embeddedRecset = (FeatureManager.GetFeature(2013) as ShepherdsRecset)[0][10031].EmbeddedRecset as SignalIndependentProductIndependentNonProgrammableButtonListInnerRecset;
    SignalIndependentProductIndependentNonProgrammableButtonListInner programmableButtonListInner1 = embeddedRecset[24] as SignalIndependentProductIndependentNonProgrammableButtonListInner;
    programmableButtonListInner1.SignalIndependentProductIndependentNonProgrammableButtonListInnerSection.RadErgoCfgSignalIndependentProductIndependentNonProgrammableButtonBCO_A19777.Value = 117;
    programmableButtonListInner1.SignalIndependentProductIndependentNonProgrammableButtonListInnerSection.RadErgoCfgSignalIndependentProductIndependentNonProgrammableButtonFeature_A19778.Value = 38;
    SignalIndependentProductIndependentNonProgrammableButtonListInner programmableButtonListInner2 = embeddedRecset[25] as SignalIndependentProductIndependentNonProgrammableButtonListInner;
    programmableButtonListInner2.SignalIndependentProductIndependentNonProgrammableButtonListInnerSection.RadErgoCfgSignalIndependentProductIndependentNonProgrammableButtonBCO_A19777.Value = 112 /*0x70*/;
    programmableButtonListInner2.SignalIndependentProductIndependentNonProgrammableButtonListInnerSection.RadErgoCfgSignalIndependentProductIndependentNonProgrammableButtonFeature_A19778.Value = 38;
    SignalIndependentProductIndependentNonProgrammableButtonListInner programmableButtonListInner3 = embeddedRecset[26] as SignalIndependentProductIndependentNonProgrammableButtonListInner;
    programmableButtonListInner3.SignalIndependentProductIndependentNonProgrammableButtonListInnerSection.RadErgoCfgSignalIndependentProductIndependentNonProgrammableButtonBCO_A19777.Value = 114;
    programmableButtonListInner3.SignalIndependentProductIndependentNonProgrammableButtonListInnerSection.RadErgoCfgSignalIndependentProductIndependentNonProgrammableButtonFeature_A19778.Value = 38;
    SignalIndependentProductIndependentNonProgrammableButtonListInner programmableButtonListInner4 = embeddedRecset[27] as SignalIndependentProductIndependentNonProgrammableButtonListInner;
    programmableButtonListInner4.SignalIndependentProductIndependentNonProgrammableButtonListInnerSection.RadErgoCfgSignalIndependentProductIndependentNonProgrammableButtonBCO_A19777.Value = 115;
    programmableButtonListInner4.SignalIndependentProductIndependentNonProgrammableButtonListInnerSection.RadErgoCfgSignalIndependentProductIndependentNonProgrammableButtonFeature_A19778.Value = 38;
    SignalIndependentProductIndependentNonProgrammableButtonListInner programmableButtonListInner5 = embeddedRecset[28] as SignalIndependentProductIndependentNonProgrammableButtonListInner;
    programmableButtonListInner5.SignalIndependentProductIndependentNonProgrammableButtonListInnerSection.RadErgoCfgSignalIndependentProductIndependentNonProgrammableButtonBCO_A19777.Value = 113;
    programmableButtonListInner5.SignalIndependentProductIndependentNonProgrammableButtonListInnerSection.RadErgoCfgSignalIndependentProductIndependentNonProgrammableButtonFeature_A19778.Value = 38;
    SignalIndependentProductIndependentNonProgrammableButtonListInner programmableButtonListInner6 = embeddedRecset[29] as SignalIndependentProductIndependentNonProgrammableButtonListInner;
    programmableButtonListInner6.SignalIndependentProductIndependentNonProgrammableButtonListInnerSection.RadErgoCfgSignalIndependentProductIndependentNonProgrammableButtonBCO_A19777.Value = 116;
    programmableButtonListInner6.SignalIndependentProductIndependentNonProgrammableButtonListInnerSection.RadErgoCfgSignalIndependentProductIndependentNonProgrammableButtonFeature_A19778.Value = 204;
    SignalIndependentProductIndependentNonProgrammableButtonListInner programmableButtonListInner7 = embeddedRecset[30] as SignalIndependentProductIndependentNonProgrammableButtonListInner;
    programmableButtonListInner7.SignalIndependentProductIndependentNonProgrammableButtonListInnerSection.RadErgoCfgSignalIndependentProductIndependentNonProgrammableButtonBCO_A19777.Value = 87;
    programmableButtonListInner7.SignalIndependentProductIndependentNonProgrammableButtonListInnerSection.RadErgoCfgSignalIndependentProductIndependentNonProgrammableButtonFeature_A19778.Value = 196;
    SignalIndependentProductIndependentNonProgrammableButtonListInner programmableButtonListInner8 = embeddedRecset[31 /*0x1F*/] as SignalIndependentProductIndependentNonProgrammableButtonListInner;
    programmableButtonListInner8.SignalIndependentProductIndependentNonProgrammableButtonListInnerSection.RadErgoCfgSignalIndependentProductIndependentNonProgrammableButtonBCO_A19777.Value = 88;
    programmableButtonListInner8.SignalIndependentProductIndependentNonProgrammableButtonListInnerSection.RadErgoCfgSignalIndependentProductIndependentNonProgrammableButtonFeature_A19778.Value = 197;
    SignalIndependentProductIndependentNonProgrammableButtonListInner programmableButtonListInner9 = embeddedRecset[32 /*0x20*/] as SignalIndependentProductIndependentNonProgrammableButtonListInner;
    programmableButtonListInner9.SignalIndependentProductIndependentNonProgrammableButtonListInnerSection.RadErgoCfgSignalIndependentProductIndependentNonProgrammableButtonBCO_A19777.Value = 89;
    programmableButtonListInner9.SignalIndependentProductIndependentNonProgrammableButtonListInnerSection.RadErgoCfgSignalIndependentProductIndependentNonProgrammableButtonFeature_A19778.Value = 208 /*0xD0*/;
    SignalIndependentProductIndependentNonProgrammableButtonListInner programmableButtonListInner10 = embeddedRecset[33] as SignalIndependentProductIndependentNonProgrammableButtonListInner;
    programmableButtonListInner10.SignalIndependentProductIndependentNonProgrammableButtonListInnerSection.RadErgoCfgSignalIndependentProductIndependentNonProgrammableButtonBCO_A19777.Value = 90;
    programmableButtonListInner10.SignalIndependentProductIndependentNonProgrammableButtonListInnerSection.RadErgoCfgSignalIndependentProductIndependentNonProgrammableButtonFeature_A19778.Value = 198;
    ((FeatureManager.GetFeature(2033) as RadioErgonomicsWideRecset)[0][10225] as PASiren).RadErgoWidePASirenHiLoAirhornTones_A8200.Value = true;
  }

  private void O9DirectionalButtonsFixup()
  {
    if (!UtilityMack.IsMobileOnly() || int.Parse(((string) (FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation).General.RadInfoGeneralCodeplugVersion_A7683).Substring(1, 2)) >= 9)
      return;
    IAcpRecordset feature = FeatureManager.GetFeature(2045);
    if (feature == null || !(feature[0][10604] is LightbarPattern lightbarPattern) || lightbarPattern.RadWideUniversalRelayControllerEquipped_A37191.Value)
      return;
    DirectionalButtonsListInnerRecset embeddedRecset = (FeatureManager.GetFeature(4003) as ControlHeadO9Recset)[0][10609].EmbeddedRecset as DirectionalButtonsListInnerRecset;
    DirectionalButtonsListInnerSection listInnerSection1 = (embeddedRecset[0] as DirectionalButtonsListInner).DirectionalButtonsListInnerSection;
    listInnerSection1.RadErgCtrlHeadO9DirLightBarFeature_A36597.SetValue(38);
    listInnerSection1.RadErgCtrlHeadO9DirLightBarFeature_A36597.Valid = true;
    DirectionalButtonsListInnerSection listInnerSection2 = (embeddedRecset[1] as DirectionalButtonsListInner).DirectionalButtonsListInnerSection;
    listInnerSection2.RadErgCtrlHeadO9DirLightBarFeature_A36597.SetValue(38);
    listInnerSection2.RadErgCtrlHeadO9DirLightBarFeature_A36597.Valid = true;
    DirectionalButtonsListInnerSection listInnerSection3 = (embeddedRecset[2] as DirectionalButtonsListInner).DirectionalButtonsListInnerSection;
    listInnerSection3.RadErgCtrlHeadO9DirLightBarFeature_A36597.SetValue(38);
    listInnerSection3.RadErgCtrlHeadO9DirLightBarFeature_A36597.Valid = true;
  }

  private void MPLCloneFixUp()
  {
    ContainerTask containerTask = new ContainerTask("Update MPL Clone");
    if (!(FeatureManager.GetFeature(2078) is MPLConfigurationRecset feature) || feature.Count <= 0 || feature.Count >= 2)
      return;
    Motorola.MackinawCPS.CoreFeatures.RadioWide.Features features = FeatureManager.GetFeature(2045)[0][10105] as Motorola.MackinawCPS.CoreFeatures.RadioWide.Features;
    if (features.RadWideFeaturesZoneCloneEnable_43130 == null || !features.RadWideFeaturesZoneCloneEnable_43130.Value)
      return;
    AcpBusinessLayer.FeatureNode defaultRecord = feature.CreateDefaultRecord();
    defaultRecord.FeatureName = AcgResources.MPL_Clone_Configuration;
    containerTask.AddTask((UndoableTask) new ChangePermissionsTask((IAcpFeatureNode) defaultRecord, Permissions.Undeletable | Permissions.DragDisabled | Permissions.DropBeforeDisabled | Permissions.InsertBeforeDisabeled));
    if (AppInfoManager.DndOperation || AppInfoManager.ImportCopyOperation)
      defaultRecord.KeyField.Editable = false;
    containerTask.AddTask((UndoableTask) new AddRecordTask(defaultRecord));
    MPLConfigurationRecset._Min = 2;
    MPLConfigurationRecset._Max = 2;
    if (!AppInfoManager.DndOperation && !AppInfoManager.ImportCopyOperation)
      return;
    defaultRecord.KeyField.Editable = true;
  }

  private void CnvPerTalkgroupTextListFixup()
  {
    if (int.Parse((FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation).General.RadInfoGeneralCodeplugVersion_A7683.Value.Substring(1, 2)) > 32 /*0x20*/)
      return;
    ContainerTask containerTask = new ContainerTask("Resync Talkgroup Text List Recref");
    if (!(FeatureManager.GetFeature(2059) is ConventionalPersonalityRecset feature) || feature.Count <= 0)
      return;
    AcpField<bool> cloneEnable43130 = (FeatureManager.GetFeature(2045)[0] as Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide).Features.RadWideFeaturesZoneCloneEnable_43130;
    if (cloneEnable43130 == null || !cloneEnable43130.Value)
      return;
    foreach (Motorola.MackinawCPS.CoreFeatures.ConventionalPersonality.ConventionalPersonality conventionalPersonality in (Collection<AcpBusinessLayer.FeatureNode>) feature)
    {
      AcpRecRefField talkgroupTextListA19822 = conventionalPersonality.General.CnvPerGeneralTalkgroupTextList_A19822;
      AcpRecRefField talkgroupListA9283 = conventionalPersonality.ASTROTalkgroup.CnvPerASTROTalkgroupOptionsTalkgroupList_A9283;
      if (talkgroupTextListA19822.UIValue != talkgroupListA9283.UIValue)
        containerTask.AddTask((UndoableTask) new ModifyRecRefDataTask(talkgroupTextListA19822, talkgroupListA9283.UIValue));
    }
  }

  private void SoftPowerOffFixUp()
  {
    IAcpRecordset feature = FeatureManager.GetFeature(2038);
    if (feature == null || feature.Count == 0)
      return;
    AcpBusinessLayer.FeatureNode featureNode = (FeatureManager.GetFeature(2038) as SwitchesRecset)[0] as AcpBusinessLayer.FeatureNode;
    ConventionalSwitches conventionalSwitches = (featureNode as Motorola.MackinawCPS.CoreFeatures.Switches.Switches).ConventionalSwitches;
    TrunkingSwitches trunkingSwitches = (featureNode as Motorola.MackinawCPS.CoreFeatures.Switches.Switches).TrunkingSwitches;
    if (conventionalSwitches.SwitchConventionalSwitchesPosition1_A7734Value == 45)
      conventionalSwitches.SwitchConventionalSwitchesPosition1_A7734.SetValue(38);
    if (conventionalSwitches.SwitchConventionalSwitchesPosition2_A7735Value == 45)
      conventionalSwitches.SwitchConventionalSwitchesPosition2_A7735.SetValue(38);
    if (conventionalSwitches.SwitchConventionalSwitchesPosition3_A7737Value == 45)
      conventionalSwitches.SwitchConventionalSwitchesPosition3_A7737.SetValue(38);
    if (conventionalSwitches.SwitchConventionalSwitchesPosition4_A21530Value == 45)
      conventionalSwitches.SwitchConventionalSwitchesPosition4_A21530.SetValue(38);
    if (conventionalSwitches.SwitchConventionalSwitchesPosition5_A21531Value == 45)
      conventionalSwitches.SwitchConventionalSwitchesPosition5_A21531.SetValue(38);
    if (trunkingSwitches.SwitchTrunkingSwitchesPosition1_A9466Value == 45)
      trunkingSwitches.SwitchTrunkingSwitchesPosition1_A9466.SetValue(38);
    if (trunkingSwitches.SwitchTrunkingSwitchesPosition2_A9467Value == 45)
      trunkingSwitches.SwitchTrunkingSwitchesPosition2_A9467.SetValue(38);
    if (trunkingSwitches.SwitchTrunkingSwitchesPosition3_A9468Value == 45)
      trunkingSwitches.SwitchTrunkingSwitchesPosition3_A9468.SetValue(38);
    if (trunkingSwitches.SwitchTrunkingSwitchesPosition4_A21534Value == 45)
      trunkingSwitches.SwitchTrunkingSwitchesPosition4_A21534.SetValue(38);
    if (trunkingSwitches.SwitchTrunkingSwitchesPosition5_A21535Value != 45)
      return;
    trunkingSwitches.SwitchTrunkingSwitchesPosition5_A21535.SetValue(38);
  }

  private void FixupSirenButtons()
  {
    if (int.Parse(((string) (FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation).General.RadInfoGeneralCodeplugVersion_A7683).Substring(1, 2)) >= 9)
      return;
    PASiren paSiren = (FeatureManager.GetFeature(2033) as RadioErgonomicsWideRecset)[0][10225] as PASiren;
    if (paSiren.RadErgoWidePASirenSirenOperation_A9139.Value != 2)
      return;
    SignalIndependentProductIndependentNonProgrammableButtonListInnerRecset embeddedRecset = (FeatureManager.GetFeature(2013) as ShepherdsRecset)[0][10031].EmbeddedRecset as SignalIndependentProductIndependentNonProgrammableButtonListInnerRecset;
    if (!paSiren.RadErgoWidePASirenHiLoAirhornTones_A8200.Value)
      (embeddedRecset[24] as SignalIndependentProductIndependentNonProgrammableButtonListInner).SignalIndependentProductIndependentNonProgrammableButtonListInnerSection.RadErgoCfgSignalIndependentProductIndependentNonProgrammableButtonFeature_A19778.Value = 199;
    (embeddedRecset[25] as SignalIndependentProductIndependentNonProgrammableButtonListInner).SignalIndependentProductIndependentNonProgrammableButtonListInnerSection.RadErgoCfgSignalIndependentProductIndependentNonProgrammableButtonFeature_A19778.Value = 200;
    (embeddedRecset[26] as SignalIndependentProductIndependentNonProgrammableButtonListInner).SignalIndependentProductIndependentNonProgrammableButtonListInnerSection.RadErgoCfgSignalIndependentProductIndependentNonProgrammableButtonFeature_A19778.Value = 202;
    if (!paSiren.RadErgoWidePASirenHiLoAirhornTones_A8200.Value)
      (embeddedRecset[27] as SignalIndependentProductIndependentNonProgrammableButtonListInner).SignalIndependentProductIndependentNonProgrammableButtonListInnerSection.RadErgoCfgSignalIndependentProductIndependentNonProgrammableButtonFeature_A19778.Value = 203;
    (embeddedRecset[28] as SignalIndependentProductIndependentNonProgrammableButtonListInner).SignalIndependentProductIndependentNonProgrammableButtonListInnerSection.RadErgoCfgSignalIndependentProductIndependentNonProgrammableButtonFeature_A19778.Value = 201;
  }

  private void SyncO9PASirenButtons(bool isCompareCpgPortable = true)
  {
    try
    {
      ShepherdsRecset feature1;
      ControlHeadO9Recset feature2;
      if (AppInfoManager.AppMode == ApplicationMode.CodeplugComparisonMode)
      {
        if (isCompareCpgPortable)
          return;
        feature1 = AppInfoManager.ComparatorDocument.GetFeature(2013) as ShepherdsRecset;
        feature2 = AppInfoManager.ComparatorDocument.GetFeature(4003) as ControlHeadO9Recset;
      }
      else
      {
        if (!UtilityMack.IsMobileOnly())
          return;
        feature1 = FeatureManager.GetFeature(2013) as ShepherdsRecset;
        feature2 = FeatureManager.GetFeature(4003) as ControlHeadO9Recset;
        this.FixupSirenButtons();
      }
      SignalIndependentProductIndependentNonProgrammableButtonListInnerRecset embeddedRecset1 = feature1[0][10031].EmbeddedRecset as SignalIndependentProductIndependentNonProgrammableButtonListInnerRecset;
      PASirenButtonsListInnerRecset embeddedRecset2 = feature2[0][10743].EmbeddedRecset as PASirenButtonsListInnerRecset;
      (embeddedRecset2[0] as PASirenButtonsListInner).PASirenButtonsListInnerSection.CHO9PASirenButtonsFeature_A41540.SetValue((embeddedRecset1[24] as SignalIndependentProductIndependentNonProgrammableButtonListInner).SignalIndependentProductIndependentNonProgrammableButtonListInnerSection.RadErgoCfgSignalIndependentProductIndependentNonProgrammableButtonFeature_A19778.Value);
      (embeddedRecset2[1] as PASirenButtonsListInner).PASirenButtonsListInnerSection.CHO9PASirenButtonsFeature_A41540.SetValue((embeddedRecset1[25] as SignalIndependentProductIndependentNonProgrammableButtonListInner).SignalIndependentProductIndependentNonProgrammableButtonListInnerSection.RadErgoCfgSignalIndependentProductIndependentNonProgrammableButtonFeature_A19778.Value);
      (embeddedRecset2[2] as PASirenButtonsListInner).PASirenButtonsListInnerSection.CHO9PASirenButtonsFeature_A41540.SetValue((embeddedRecset1[28] as SignalIndependentProductIndependentNonProgrammableButtonListInner).SignalIndependentProductIndependentNonProgrammableButtonListInnerSection.RadErgoCfgSignalIndependentProductIndependentNonProgrammableButtonFeature_A19778.Value);
      (embeddedRecset2[3] as PASirenButtonsListInner).PASirenButtonsListInnerSection.CHO9PASirenButtonsFeature_A41540.SetValue((embeddedRecset1[26] as SignalIndependentProductIndependentNonProgrammableButtonListInner).SignalIndependentProductIndependentNonProgrammableButtonListInnerSection.RadErgoCfgSignalIndependentProductIndependentNonProgrammableButtonFeature_A19778.Value);
      (embeddedRecset2[4] as PASirenButtonsListInner).PASirenButtonsListInnerSection.CHO9PASirenButtonsFeature_A41540.SetValue((embeddedRecset1[27] as SignalIndependentProductIndependentNonProgrammableButtonListInner).SignalIndependentProductIndependentNonProgrammableButtonListInnerSection.RadErgoCfgSignalIndependentProductIndependentNonProgrammableButtonFeature_A19778.Value);
      (embeddedRecset2[5] as PASirenButtonsListInner).PASirenButtonsListInnerSection.CHO9PASirenButtonsFeature_A41540.SetValue((embeddedRecset1[29] as SignalIndependentProductIndependentNonProgrammableButtonListInner).SignalIndependentProductIndependentNonProgrammableButtonListInnerSection.RadErgoCfgSignalIndependentProductIndependentNonProgrammableButtonFeature_A19778.Value);
    }
    catch (Exception ex)
    {
    }
  }

  private void TriggerMuteToneRefresh()
  {
    Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide radioWide = AppInfoManager.AppMode != ApplicationMode.CodeplugConfigurationMode ? AppInfoManager.ComparatorDocument.GetFeature(2045)[0] as Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide : FeatureManager.GetFeature(2045)[0] as Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide;
    if (radioWide == null || radioWide.AlertTones == null)
      return;
    Motorola.MackinawCPS.CoreFeatures.RadioWide.AlertTones alertTones = radioWide.AlertTones;
    AcpListField tonesOperationA8562 = alertTones.RadProfAlertTonesMuteTonesOperation_A8562;
    AcpListField tonesOperationA42149 = alertTones.RadProfAlertTonesNewMuteTonesOperation_A42149;
    AcpListField tonesOperationA42150 = alertTones.RadProfAlertTonesEnhancedMuteTonesOperation_A42150;
    if (tonesOperationA8562 == null || tonesOperationA42149 == null || tonesOperationA42150 == null)
      return;
    if (tonesOperationA42149.Value == 0)
    {
      switch (tonesOperationA8562.Value)
      {
        case 0:
          tonesOperationA42150.SetValue(0);
          break;
        case 1:
          tonesOperationA42150.SetValue(1);
          break;
        case 3:
          tonesOperationA42150.SetValue(3);
          tonesOperationA42149.SetValue(15);
          break;
      }
    }
    else
    {
      switch (tonesOperationA42149.Value)
      {
        case 1:
          tonesOperationA8562.SetValue(0);
          tonesOperationA42150.SetValue(2);
          break;
        case 15:
          tonesOperationA8562.SetValue(3);
          tonesOperationA42150.SetValue(3);
          break;
      }
    }
  }

  private void SetValuesForShepherdsCnvKeyfob(
    IAcpFeatureNode shepherds,
    int innerRecordIndex,
    int typeId)
  {
    if (!(shepherds[10035]?.EmbeddedRecset is ConventionalShepherdListInnerRecset embeddedRecset))
      return;
    while (embeddedRecset.Count < innerRecordIndex + 1)
      embeddedRecset.AddRecord(embeddedRecset.CreateDefaultRecord());
    if (!(embeddedRecset[innerRecordIndex][10036] is ConventionalShepherdListInnerSection listInnerSection))
      return;
    listInnerSection.RadErgoCfgCnvBtnListType_A21164.SetValue(typeId);
  }

  private void SetValuesForShepherdsTrkKeyfob(
    IAcpFeatureNode shepherds,
    int innerRecordIndex,
    int typeId)
  {
    if (!(shepherds[10037]?.EmbeddedRecset is TrunkingShepherdListInnerRecset embeddedRecset))
      return;
    while (embeddedRecset.Count < innerRecordIndex + 1)
      embeddedRecset.AddRecord(embeddedRecset.CreateDefaultRecord());
    if (!(embeddedRecset[innerRecordIndex][10038] is TrunkingShepherdListInnerSection listInnerSection))
      return;
    listInnerSection.RadErgoCfgTrkBtnListType_A21167.SetValue(typeId);
  }

  private void ShepherdsInitForFob()
  {
    if (!(FeatureManager.GetFeature(2013) is ShepherdsRecset feature) || feature.Count <= 0)
      return;
    if (UtilityMack.IsPortable())
    {
      this.SetValuesForShepherdsCnvKeyfob(feature[0], 3, 1148);
      this.SetValuesForShepherdsTrkKeyfob(feature[0], 3, 1149);
    }
    if (!UtilityMack.IsMobile())
      return;
    this.SetValuesForShepherdsCnvKeyfob(feature[0], 4, 1148);
    this.SetValuesForShepherdsTrkKeyfob(feature[0], 4, 1149);
  }

  private bool O9TableInit()
  {
    bool flag1 = false;
    if (!UtilityMack.IsMobileOnly())
      return flag1;
    IAcpRecordset feature1 = FeatureManager.GetFeature(2045);
    if (feature1 != null && feature1[0][10606].EmbeddedRecset is RelockTimerInnerRecset embeddedRecset1)
    {
      while (embeddedRecset1.Count < 3)
        embeddedRecset1.AddRecord(embeddedRecset1.CreateDefaultRecord());
    }
    if (FeatureManager.GetFeature(4003) is ControlHeadO9Recset feature2)
    {
      BottomFunctionProgrammableButtonInnerRecset embeddedRecset2 = feature2[0][10618].EmbeddedRecset as BottomFunctionProgrammableButtonInnerRecset;
      if (feature2[0][10628].EmbeddedRecset is BottomFunctionButtonBCOListInnerRecset embeddedRecset3)
      {
        bool flag2 = false;
        while (embeddedRecset3.Count < 6)
        {
          embeddedRecset3.AddRecord(embeddedRecset3.CreateDefaultRecord());
          flag2 = true;
        }
        if (flag2)
        {
          (embeddedRecset3[0] as BottomFunctionButtonBCOListInner).BottomFunctionButtonBCOListInnerSection.CHO9BottomFunctionButtonBCO_A36827.Value = 165;
          (embeddedRecset3[1] as BottomFunctionButtonBCOListInner).BottomFunctionButtonBCOListInnerSection.CHO9BottomFunctionButtonBCO_A36827.Value = 166;
          (embeddedRecset3[2] as BottomFunctionButtonBCOListInner).BottomFunctionButtonBCOListInnerSection.CHO9BottomFunctionButtonBCO_A36827.Value = 167;
          (embeddedRecset3[3] as BottomFunctionButtonBCOListInner).BottomFunctionButtonBCOListInnerSection.CHO9BottomFunctionButtonBCO_A36827.Value = 168;
          (embeddedRecset3[4] as BottomFunctionButtonBCOListInner).BottomFunctionButtonBCOListInnerSection.CHO9BottomFunctionButtonBCO_A36827.Value = 169;
          BottomFunctionButtonBCOListInnerSection listInnerSection = (embeddedRecset3[5] as BottomFunctionButtonBCOListInner).BottomFunctionButtonBCOListInnerSection;
          listInnerSection.CHO9BottomFunctionButtonBCO_A36827.Value = 10;
          listInnerSection.CHO9BottomFunctionButtonFeature_A36826.Value = 205;
        }
      }
      if (embeddedRecset2 != null)
      {
        bool flag3 = false;
        while (embeddedRecset2.Count < 5)
        {
          embeddedRecset2.AddRecord(embeddedRecset2.CreateDefaultRecord());
          flag3 = true;
        }
        if (flag3)
        {
          BottomFunctionProgrammableButtonInnerSection buttonInnerSection1 = (embeddedRecset2[0] as BottomFunctionProgrammableButtonInner).BottomFunctionProgrammableButtonInnerSection;
          BottomFunctionButtonBCOListInnerSection listInnerSection1 = (embeddedRecset3[0] as BottomFunctionButtonBCOListInner).BottomFunctionButtonBCOListInnerSection;
          buttonInnerSection1.CHO9BottomFunctionButtonBCO_A36660.Value = 165;
          buttonInnerSection1.CHO9BottomFunctionButtonName_A36657.Value = AcgResources.ID_P1;
          buttonInnerSection1.CHO9BottomFunctionButtonFeature_A36664.SetValue(listInnerSection1.CHO9BottomFunctionButtonFeature_A36826.Value);
          BottomFunctionProgrammableButtonInnerSection buttonInnerSection2 = (embeddedRecset2[1] as BottomFunctionProgrammableButtonInner).BottomFunctionProgrammableButtonInnerSection;
          BottomFunctionButtonBCOListInnerSection listInnerSection2 = (embeddedRecset3[1] as BottomFunctionButtonBCOListInner).BottomFunctionButtonBCOListInnerSection;
          buttonInnerSection2.CHO9BottomFunctionButtonBCO_A36660.Value = 166;
          buttonInnerSection2.CHO9BottomFunctionButtonName_A36657.Value = AppResources.P2_Id;
          buttonInnerSection2.CHO9BottomFunctionButtonFeature_A36664.SetValue(listInnerSection2.CHO9BottomFunctionButtonFeature_A36826.Value);
          BottomFunctionProgrammableButtonInnerSection buttonInnerSection3 = (embeddedRecset2[2] as BottomFunctionProgrammableButtonInner).BottomFunctionProgrammableButtonInnerSection;
          BottomFunctionButtonBCOListInnerSection listInnerSection3 = (embeddedRecset3[2] as BottomFunctionButtonBCOListInner).BottomFunctionButtonBCOListInnerSection;
          buttonInnerSection3.CHO9BottomFunctionButtonBCO_A36660.Value = 167;
          buttonInnerSection3.CHO9BottomFunctionButtonName_A36657.Value = AppResources.P3_Id;
          buttonInnerSection3.CHO9BottomFunctionButtonFeature_A36664.SetValue(listInnerSection3.CHO9BottomFunctionButtonFeature_A36826.Value);
          BottomFunctionProgrammableButtonInnerSection buttonInnerSection4 = (embeddedRecset2[3] as BottomFunctionProgrammableButtonInner).BottomFunctionProgrammableButtonInnerSection;
          BottomFunctionButtonBCOListInnerSection listInnerSection4 = (embeddedRecset3[3] as BottomFunctionButtonBCOListInner).BottomFunctionButtonBCOListInnerSection;
          buttonInnerSection4.CHO9BottomFunctionButtonBCO_A36660.Value = 168;
          buttonInnerSection4.CHO9BottomFunctionButtonName_A36657.Value = AppResources.P4_Id;
          buttonInnerSection4.CHO9BottomFunctionButtonFeature_A36664.SetValue(listInnerSection4.CHO9BottomFunctionButtonFeature_A36826.Value);
          BottomFunctionProgrammableButtonInnerSection buttonInnerSection5 = (embeddedRecset2[4] as BottomFunctionProgrammableButtonInner).BottomFunctionProgrammableButtonInnerSection;
          BottomFunctionButtonBCOListInnerSection listInnerSection5 = (embeddedRecset3[4] as BottomFunctionButtonBCOListInner).BottomFunctionButtonBCOListInnerSection;
          buttonInnerSection5.CHO9BottomFunctionButtonBCO_A36660.Value = 169;
          buttonInnerSection5.CHO9BottomFunctionButtonName_A36657.Value = AppResources.P5_Id;
          buttonInnerSection5.CHO9BottomFunctionButtonFeature_A36664.SetValue(listInnerSection5.CHO9BottomFunctionButtonFeature_A36826.Value);
        }
      }
    }
    if (feature1 != null && feature1[0][10604].EmbeddedRecset is GeneralLightbarPatternInnerRecset embeddedRecset4 && embeddedRecset4.Count < 3)
    {
      bool flag4 = false;
      while (embeddedRecset4.Count < 3)
      {
        embeddedRecset4.AddRecord(embeddedRecset4.CreateDefaultRecord());
        flag4 = true;
        flag1 = true;
      }
      int num = flag4 ? 1 : 0;
    }
    if (feature2 != null && feature2[0][10609].EmbeddedRecset is DirectionalButtonsListInnerRecset embeddedRecset5)
    {
      bool flag5 = false;
      while (embeddedRecset5.Count < 3)
      {
        embeddedRecset5.AddRecord(embeddedRecset5.CreateDefaultRecord());
        flag5 = true;
      }
      if (flag5)
      {
        DirectionalButtonsListInnerSection listInnerSection6 = (embeddedRecset5[0] as DirectionalButtonsListInner).DirectionalButtonsListInnerSection;
        listInnerSection6.RadErgCtrlHeadO9DirLightBarBCO_A36559.Value = 118;
        listInnerSection6.RadErgCtrlHeadO9DirLightBarName_A36558.Value = AppResources.Top_Center;
        DirectionalButtonsListInnerSection listInnerSection7 = (embeddedRecset5[1] as DirectionalButtonsListInner).DirectionalButtonsListInnerSection;
        listInnerSection7.RadErgCtrlHeadO9DirLightBarBCO_A36559.Value = 120;
        listInnerSection7.RadErgCtrlHeadO9DirLightBarName_A36558.Value = AppResources.Left_Id;
        DirectionalButtonsListInnerSection listInnerSection8 = (embeddedRecset5[2] as DirectionalButtonsListInner).DirectionalButtonsListInnerSection;
        listInnerSection8.RadErgCtrlHeadO9DirLightBarBCO_A36559.Value = 119;
        listInnerSection8.RadErgCtrlHeadO9DirLightBarName_A36558.Value = AppResources.Right_ID;
      }
    }
    if (feature2 != null && feature2[0][10620].EmbeddedRecset is RelayPatternBCOListListInnerRecset embeddedRecset6)
    {
      bool flag6 = false;
      while (embeddedRecset6.Count < 3)
      {
        embeddedRecset6.AddRecord(embeddedRecset6.CreateDefaultRecord());
        flag6 = true;
      }
      if (flag6)
      {
        (embeddedRecset6[0] as RelayPatternBCOListListInner).RelayPatternBCOListListInnerSection.RdEgoO9DirLtbarPatternBcoListBco_A36661.Value = 118;
        (embeddedRecset6[1] as RelayPatternBCOListListInner).RelayPatternBCOListListInnerSection.RdEgoO9DirLtbarPatternBcoListBco_A36661.Value = 120;
        (embeddedRecset6[2] as RelayPatternBCOListListInner).RelayPatternBCOListListInnerSection.RdEgoO9DirLtbarPatternBcoListBco_A36661.Value = 119;
      }
    }
    if (FeatureManager.GetFeature(2013) is ShepherdsRecset feature3)
    {
      if (feature3[0][10033].EmbeddedRecset is GlobalShepherdListInnerRecset embeddedRecset7)
      {
        while (embeddedRecset7.Count < 10)
          embeddedRecset7.AddRecord(embeddedRecset7.CreateDefaultRecord());
      }
      if (feature3[0][10035].EmbeddedRecset is ConventionalShepherdListInnerRecset embeddedRecset8)
      {
        while (embeddedRecset8.Count < 4)
          embeddedRecset8.AddRecord(embeddedRecset8.CreateDefaultRecord());
      }
      if (feature3[0][10037].EmbeddedRecset is TrunkingShepherdListInnerRecset embeddedRecset9)
      {
        while (embeddedRecset9.Count < 4)
          embeddedRecset9.AddRecord(embeddedRecset9.CreateDefaultRecord());
      }
      if (feature3[0][10031].EmbeddedRecset is SignalIndependentProductIndependentNonProgrammableButtonListInnerRecset embeddedRecset10)
      {
        while (embeddedRecset10.Count < 34)
          embeddedRecset10.AddRecord(embeddedRecset10.CreateDefaultRecord());
      }
      if (feature2 != null && feature2[0][10743].EmbeddedRecset is PASirenButtonsListInnerRecset embeddedRecset11)
      {
        bool flag7 = false;
        while (embeddedRecset11.Count < 6)
        {
          embeddedRecset11.AddRecord(embeddedRecset11.CreateDefaultRecord());
          flag7 = true;
        }
        PASirenButtonsListInnerSection listInnerSection9 = (embeddedRecset11[0] as PASirenButtonsListInner).PASirenButtonsListInnerSection;
        PASirenButtonsListInnerSection listInnerSection10 = (embeddedRecset11[1] as PASirenButtonsListInner).PASirenButtonsListInnerSection;
        PASirenButtonsListInnerSection listInnerSection11 = (embeddedRecset11[2] as PASirenButtonsListInner).PASirenButtonsListInnerSection;
        PASirenButtonsListInnerSection listInnerSection12 = (embeddedRecset11[3] as PASirenButtonsListInner).PASirenButtonsListInnerSection;
        PASirenButtonsListInnerSection listInnerSection13 = (embeddedRecset11[4] as PASirenButtonsListInner).PASirenButtonsListInnerSection;
        PASirenButtonsListInnerSection listInnerSection14 = (embeddedRecset11[5] as PASirenButtonsListInner).PASirenButtonsListInnerSection;
        if (flag7)
        {
          listInnerSection9.CHO9PASirenButtonsBCO_A41538.Value = 117;
          listInnerSection9.CHO9PASirenButtonsName_A41537.Value = AppResources.O9_Siren_Airhorn;
          listInnerSection10.CHO9PASirenButtonsBCO_A41538.Value = 112 /*0x70*/;
          listInnerSection10.CHO9PASirenButtonsName_A41537.Value = AppResources.O9_Siren_Manual;
          listInnerSection11.CHO9PASirenButtonsBCO_A41538.Value = 113;
          listInnerSection11.CHO9PASirenButtonsName_A41537.Value = AppResources.O9_Siren_Wail;
          listInnerSection12.CHO9PASirenButtonsBCO_A41538.Value = 114;
          listInnerSection12.CHO9PASirenButtonsName_A41537.Value = AppResources.O9_Siren_Yelp;
          listInnerSection13.CHO9PASirenButtonsBCO_A41538.Value = 115;
          listInnerSection13.CHO9PASirenButtonsName_A41537.Value = AppResources.O9_Siren_Hilo;
          listInnerSection14.CHO9PASirenButtonsBCO_A41538.Value = 116;
          listInnerSection14.CHO9PASirenButtonsName_A41537.Value = AppResources.O9_Siren_PA;
        }
      }
    }
    if (FeatureManager.GetFeature(4003) is ControlHeadO9Recset feature4 && feature4[0][10616].EmbeddedRecset is TopFunctionProgrammableButtonListInnerRecset embeddedRecset12 && embeddedRecset12.Count < 5)
    {
      bool flag8 = false;
      while (embeddedRecset12.Count < 5)
      {
        embeddedRecset12.AddRecord(embeddedRecset12.CreateDefaultRecord());
        flag8 = true;
      }
      if (flag8)
      {
        TopFunctionProgrammableButtonListInnerSection listInnerSection15 = (embeddedRecset12[0] as TopFunctionProgrammableButtonListInner).TopFunctionProgrammableButtonListInnerSection;
        listInnerSection15.O9CHTrkTopFunctionButtonBCO_A36636.Value = 160 /*0xA0*/;
        listInnerSection15.CnvTopFunctionButtonBCO_A36628.Value = 160 /*0xA0*/;
        listInnerSection15.CHO9TopFunctionButton_A36618.Value = AppResources.Button_1;
        TopFunctionProgrammableButtonListInnerSection listInnerSection16 = (embeddedRecset12[1] as TopFunctionProgrammableButtonListInner).TopFunctionProgrammableButtonListInnerSection;
        listInnerSection16.O9CHTrkTopFunctionButtonBCO_A36636.Value = 161;
        listInnerSection16.CnvTopFunctionButtonBCO_A36628.Value = 161;
        listInnerSection16.CHO9TopFunctionButton_A36618.Value = AppResources.Button_2;
        TopFunctionProgrammableButtonListInnerSection listInnerSection17 = (embeddedRecset12[2] as TopFunctionProgrammableButtonListInner).TopFunctionProgrammableButtonListInnerSection;
        listInnerSection17.O9CHTrkTopFunctionButtonBCO_A36636.Value = 162;
        listInnerSection17.CnvTopFunctionButtonBCO_A36628.Value = 162;
        listInnerSection17.CHO9TopFunctionButton_A36618.Value = AppResources.Button_3;
        TopFunctionProgrammableButtonListInnerSection listInnerSection18 = (embeddedRecset12[3] as TopFunctionProgrammableButtonListInner).TopFunctionProgrammableButtonListInnerSection;
        listInnerSection18.O9CHTrkTopFunctionButtonBCO_A36636.Value = 163;
        listInnerSection18.CnvTopFunctionButtonBCO_A36628.Value = 163;
        listInnerSection18.CHO9TopFunctionButton_A36618.Value = AppResources.Button_4;
        TopFunctionProgrammableButtonListInnerSection listInnerSection19 = (embeddedRecset12[4] as TopFunctionProgrammableButtonListInner).TopFunctionProgrammableButtonListInnerSection;
        listInnerSection19.O9CHTrkTopFunctionButtonBCO_A36636.Value = 164;
        listInnerSection19.CnvTopFunctionButtonBCO_A36628.Value = 164;
        listInnerSection19.CHO9TopFunctionButton_A36618.Value = AppResources.Button_5;
      }
    }
    if (feature4 != null && feature4[0][10624].EmbeddedRecset is ResponseSelectorListInnerRecset embeddedRecset13 && embeddedRecset13.Count < 4)
    {
      bool flag9 = false;
      while (embeddedRecset13.Count < 4)
      {
        embeddedRecset13.AddRecord(embeddedRecset13.CreateDefaultRecord());
        flag9 = true;
      }
      if (flag9)
      {
        ResponseSelectorListInnerSection listInnerSection = (embeddedRecset13[0] as ResponseSelectorListInner).ResponseSelectorListInnerSection;
        listInnerSection.CHO9PursuitKnobMode_A36683.Value = AppResources.Mode_0;
        listInnerSection.CHO9PursuitKnobIndex_A36685.ReferencedIndex = 1;
        (embeddedRecset13[1] as ResponseSelectorListInner).ResponseSelectorListInnerSection.CHO9PursuitKnobMode_A36683.Value = AppResources.Mode_1;
        (embeddedRecset13[2] as ResponseSelectorListInner).ResponseSelectorListInnerSection.CHO9PursuitKnobMode_A36683.Value = AppResources.Mode_2;
        (embeddedRecset13[3] as ResponseSelectorListInner).ResponseSelectorListInnerSection.CHO9PursuitKnobMode_A36683.Value = AppResources.Mode_3;
      }
    }
    if (feature1 != null && feature1[0][10604].EmbeddedRecset is GeneralLightbarPatternInnerRecset embeddedRecset14 && embeddedRecset14.Count < 3)
    {
      bool flag10 = false;
      while (embeddedRecset14.Count < 3)
      {
        embeddedRecset14.AddRecord(embeddedRecset14.CreateDefaultRecord());
        flag10 = true;
      }
      int num = flag10 ? 1 : 0;
    }
    return flag1;
  }

  private void MFKTableInit()
  {
    if (FeatureManager.GetFeature(2038) is SwitchesRecset feature && feature[0][10637].EmbeddedRecset is MFKAssignmentControlInnerRecset embeddedRecset1 && embeddedRecset1.Count < 2)
    {
      while (embeddedRecset1.Count < 2)
        embeddedRecset1.AddRecord(embeddedRecset1.CreateDefaultRecord());
      MFKAssignmentControlInner assignmentControlInner1 = embeddedRecset1[0] as MFKAssignmentControlInner;
      MFKAssignmentControlInnerSection controlInnerSection = assignmentControlInner1.MFKAssignmentControlInnerSection;
      if (assignmentControlInner1 != null)
        controlInnerSection.RadErgoControlSwitchsMFKFeatureAssignment_A38514.SetValue(23);
      if (embeddedRecset1[1] is MFKAssignmentControlInner assignmentControlInner2)
        assignmentControlInner2.MFKAssignmentControlInnerSection.SwitchMFKAssignmentControlName_A38529.SetValue(AppResources.Secondary_Function);
    }
    if (!UtilityMack.IsPortableOnly() || !((FeatureManager.GetFeature(2013) as ShepherdsRecset)[0][10031].EmbeddedRecset is SignalIndependentProductIndependentNonProgrammableButtonListInnerRecset embeddedRecset2) || embeddedRecset2.Count >= 26)
      return;
    while (embeddedRecset2.Count < 26)
      embeddedRecset2.AddRecord(embeddedRecset2.CreateDefaultRecord());
    SignalIndependentProductIndependentNonProgrammableButtonListInner programmableButtonListInner1 = embeddedRecset2[24] as SignalIndependentProductIndependentNonProgrammableButtonListInner;
    SignalIndependentProductIndependentNonProgrammableButtonListInner programmableButtonListInner2 = embeddedRecset2[25] as SignalIndependentProductIndependentNonProgrammableButtonListInner;
    if (programmableButtonListInner1 != null)
    {
      programmableButtonListInner1.SignalIndependentProductIndependentNonProgrammableButtonListInnerSection.RadErgoCfgSignalIndependentProductIndependentNonProgrammableButtonBCO_A19777.SetValue(11);
      programmableButtonListInner1.SignalIndependentProductIndependentNonProgrammableButtonListInnerSection.RadErgoCfgSignalIndependentProductIndependentNonProgrammableButtonFeature_A19778.SetValue(38);
    }
    if (programmableButtonListInner2 == null)
      return;
    programmableButtonListInner2.SignalIndependentProductIndependentNonProgrammableButtonListInnerSection.RadErgoCfgSignalIndependentProductIndependentNonProgrammableButtonBCO_A19777.SetValue(91);
    programmableButtonListInner2.SignalIndependentProductIndependentNonProgrammableButtonListInnerSection.RadErgoCfgSignalIndependentProductIndependentNonProgrammableButtonFeature_A19778.SetValue(38);
  }

  private void O2TableInit_For_CustomViewInit(Document document)
  {
    if (!(document.GetFeature(4115) is ControlHeadO2Recset feature))
      return;
    if (feature[0][10721].EmbeddedRecset is O2MFKAssignmentControlInnerRecset embeddedRecset1 && embeddedRecset1.Count < 2)
    {
      while (embeddedRecset1.Count < 2)
        embeddedRecset1.AddRecord(embeddedRecset1.CreateDefaultRecord());
    }
    if (!(feature[0][10722].EmbeddedRecset is O2NavigationControlsTableInnerRecset embeddedRecset2) || embeddedRecset2.Count >= 2)
      return;
    while (embeddedRecset2.Count < 2)
      embeddedRecset2.AddRecord(embeddedRecset2.CreateDefaultRecord());
  }

  private void O7TableInit_For_CustomViewInit(Document document)
  {
    if (document.GetFeature(4114) is ControlHeadO7Recset feature && feature[0][10718].EmbeddedRecset is O7MFKAssignmentControlInnerRecset embeddedRecset1 && embeddedRecset1.Count < 2)
    {
      while (embeddedRecset1.Count < 2)
        embeddedRecset1.AddRecord(embeddedRecset1.CreateDefaultRecord());
    }
    if (!(feature[0][10727].EmbeddedRecset is O7NavigationControlsTableInnerRecset embeddedRecset2) || embeddedRecset2.Count >= 2)
      return;
    while (embeddedRecset2.Count < 2)
      embeddedRecset2.AddRecord(embeddedRecset2.CreateDefaultRecord());
  }

  private void E5TableInit_For_CustomViewInit(Document document)
  {
    if (!((document.GetFeature(4236) as ControlHeadE5Recset)[0][10896].EmbeddedRecset is E5NavigationControlsTableInnerRecset embeddedRecset) || embeddedRecset.Count >= 2)
      return;
    while (embeddedRecset.Count < 2)
      embeddedRecset.AddRecord(embeddedRecset.CreateDefaultRecord());
  }

  private void O3TableInit_For_CustomViewInit(Document document)
  {
    if (document.GetFeature(2127) is ControlHeadO3Recset feature && feature[0][10235].EmbeddedRecset is O3HHCHButtonInnerRecset embeddedRecset1)
    {
      while (embeddedRecset1.Count < 5)
        embeddedRecset1.AddRecord(embeddedRecset1.CreateDefaultRecord());
    }
    if (feature == null || !(feature[0][10732].EmbeddedRecset is O3NavigationControlsTableInnerRecset embeddedRecset2) || embeddedRecset2.Count >= 2)
      return;
    while (embeddedRecset2.Count < 2)
      embeddedRecset2.AddRecord(embeddedRecset2.CreateDefaultRecord());
  }

  private void O5TableInit_For_CustomViewInit(Document document)
  {
    if (!(document.GetFeature(2130) is ControlHeadO5Recset feature) || !(feature[0][10735].EmbeddedRecset is O5NavigationControlsTableInnerRecset embeddedRecset) || embeddedRecset.Count >= 2)
      return;
    while (embeddedRecset.Count < 2)
      embeddedRecset.AddRecord(embeddedRecset.CreateDefaultRecord());
  }

  private void KMATableInit_For_CustomViewInit(Document document)
  {
    if (!(document.GetFeature(2128) is KeypadMicAndAccessoriesRecset feature) || !(feature[0][10753].EmbeddedRecset is KMANavigationControlsTableInnerRecset embeddedRecset) || embeddedRecset.Count >= 2)
      return;
    while (embeddedRecset.Count < 2)
      embeddedRecset.AddRecord(embeddedRecset.CreateDefaultRecord());
  }

  private void O9TableInit_For_CustomViewInit(Document document)
  {
    if (document.GetFeature(4003) is ControlHeadO9Recset feature1)
    {
      BottomFunctionProgrammableButtonInnerRecset embeddedRecset1 = feature1[0][10618].EmbeddedRecset as BottomFunctionProgrammableButtonInnerRecset;
      IAcpRecordset embeddedRecset2 = feature1[0][10628].EmbeddedRecset;
      if (embeddedRecset1 != null)
      {
        while (embeddedRecset1.Count < 5)
          embeddedRecset1.AddRecord(embeddedRecset1.CreateDefaultRecord());
      }
    }
    if (feature1 != null && feature1[0][10609].EmbeddedRecset is DirectionalButtonsListInnerRecset embeddedRecset3)
    {
      while (embeddedRecset3.Count < 3)
        embeddedRecset3.AddRecord(embeddedRecset3.CreateDefaultRecord());
    }
    if (document.GetFeature(4003) is ControlHeadO9Recset feature2 && feature2[0][10616].EmbeddedRecset is TopFunctionProgrammableButtonListInnerRecset embeddedRecset4 && embeddedRecset4.Count < 5)
    {
      while (embeddedRecset4.Count < 5)
        embeddedRecset4.AddRecord(embeddedRecset4.CreateDefaultRecord());
    }
    if (feature2 != null && feature2[0][10624].EmbeddedRecset is ResponseSelectorListInnerRecset embeddedRecset5 && embeddedRecset5.Count < 4)
    {
      while (embeddedRecset5.Count < 4)
        embeddedRecset5.AddRecord(embeddedRecset5.CreateDefaultRecord());
    }
    if (feature2 != null && feature2[0][10731].EmbeddedRecset is O9NavigationControlsTableInnerRecset embeddedRecset6 && embeddedRecset6.Count < 2)
    {
      while (embeddedRecset6.Count < 2)
        embeddedRecset6.AddRecord(embeddedRecset6.CreateDefaultRecord());
    }
    if (feature2 == null || !(feature2[0][10743].EmbeddedRecset is PASirenButtonsListInnerRecset embeddedRecset7) || embeddedRecset7.Count >= 6)
      return;
    while (embeddedRecset7.Count < 6)
      embeddedRecset7.AddRecord(embeddedRecset7.CreateDefaultRecord());
  }

  private void SmartKeyFobsTableInit_For_CustomViewInit(Document document)
  {
    if (!(document.GetFeature(4130) is SmartKeyFobRecset feature) || !(feature[0][10747].EmbeddedRecset is SmartKeyFobButtonTableInnerRecset embeddedRecset) || embeddedRecset.Count >= 6)
      return;
    while (embeddedRecset.Count < 6)
      embeddedRecset.AddRecord(embeddedRecset.CreateDefaultRecord());
  }

  private void KeypadMicAndAccessoriesTableInit_For_CustomViewInit(Document document)
  {
    if (document.GetFeature(2128) is KeypadMicAndAccessoriesRecset feature1 && feature1[0][10231].EmbeddedRecset is KMButtonInnerRecset embeddedRecset1 && embeddedRecset1.Count < 3)
    {
      while (embeddedRecset1.Count < 3)
        embeddedRecset1.AddRecord(embeddedRecset1.CreateDefaultRecord());
    }
    if (document.GetFeature(2128) is KeypadMicAndAccessoriesRecset feature2 && feature2[0][10753].EmbeddedRecset is KMANavigationControlsTableInnerRecset embeddedRecset2 && embeddedRecset2.Count < 2)
    {
      while (embeddedRecset2.Count < 2)
        embeddedRecset2.AddRecord(embeddedRecset2.CreateDefaultRecord());
    }
    if (!(document.GetFeature(2128) is KeypadMicAndAccessoriesRecset feature3) || !(feature3[0][10228].EmbeddedRecset is Motorola.MackinawCPS.CoreFeatures.KeypadMicAndAccessories.DataButtonInnerRecset embeddedRecset3) || embeddedRecset3.Count >= 1)
      return;
    while (embeddedRecset3.Count < 1)
      embeddedRecset3.AddRecord(embeddedRecset3.CreateDefaultRecord());
  }

  private void KeypadTableInit_For_CustomViewInit(Document document)
  {
    if (!(document.GetFeature(4109) is KeypadRecset feature) || !(feature[0][10710].EmbeddedRecset is KeypadButtonInnerRecset embeddedRecset) || embeddedRecset.Count >= 12)
      return;
    while (embeddedRecset.Count < 12)
      embeddedRecset.AddRecord(embeddedRecset.CreateDefaultRecord());
  }

  private void DEKTableInit_For_CustomViewInit(Document document)
  {
    if (!(document.GetFeature(2129) is DEKRecset feature) || !(feature[0][10232].EmbeddedRecset is DEKButtonInnerRecset embeddedRecset) || embeddedRecset.Count >= 24)
      return;
    while (embeddedRecset.Count < 24)
      embeddedRecset.AddRecord(embeddedRecset.CreateDefaultRecord());
  }

  private void InitTablesWithDefaultRecords(Document document)
  {
    this.O9TableInit_For_CustomViewInit(document);
    this.O3TableInit_For_CustomViewInit(document);
    this.O5TableInit_For_CustomViewInit(document);
    this.O2TableInit_For_CustomViewInit(document);
    this.O7TableInit_For_CustomViewInit(document);
    this.E5TableInit_For_CustomViewInit(document);
    this.KMATableInit_For_CustomViewInit(document);
    this.KeypadMicAndAccessoriesTableInit_For_CustomViewInit(document);
    this.KeypadTableInit_For_CustomViewInit(document);
    this.DEKTableInit_For_CustomViewInit(document);
    this.SmartKeyFobsTableInit_For_CustomViewInit(document);
  }

  private void SetAudioSettingGroupSettingValueToCustom()
  {
    if (this.CodeplugVersion.Major >= 13 && (this.CodeplugVersion.Major != 13 || this.CodeplugVersion.Minor >= 1) || !(FeatureManager.GetFeature(2077) is RadioProfilesRecset feature))
      return;
    foreach (IAcpFeatureNode acpFeatureNode in (Collection<AcpBusinessLayer.FeatureNode>) feature)
    {
      foreach (IAcpFeatureSection featureSections in acpFeatureNode.FeatureSectionsCollection)
      {
        if (featureSections is AudioSettings audioSettings)
        {
          audioSettings.NoiseReductionGroupSettingRadio_42584.Value = 4;
          audioSettings.NoiseReductionGroupSettingAccessory_42585.Value = 4;
          audioSettings.GainSensitivityGroupSettingRadio_42608.Value = 4;
          audioSettings.GainSensitivityGroupSettingAccessory_42610.Value = 4;
          audioSettings.AudioEqualizationGroupSettingRadio_42604.Value = 4;
          audioSettings.AudioEqualizationGroupSettingAccessory_42605.Value = 4;
          audioSettings.AudioEqualizationGroupSettingRadio_42613.Value = 4;
          audioSettings.AudioEqualizationGroupSettingAccessory_42614.Value = 4;
          break;
        }
      }
    }
  }

  private void SetAudioConfigurationLevelToBasic()
  {
    IAcpRecordset feature = FeatureManager.GetFeature(2045);
    if ((feature[0][10093] as Motorola.MackinawCPS.CoreFeatures.RadioWide.Labtool).RadWideLabtoolAudioEnhancement_A42736.Value)
      return;
    (feature[0][10101] as DigitalAudioOptions).RadWideAudioConfigurationLevel_42740.Value = 0;
  }

  private void SyncValueForAccessoryFieldsForAudioEnhancementFeature()
  {
    if (this.CodeplugVersion.Major >= 13 && (this.CodeplugVersion.Major != 13 || this.CodeplugVersion.Minor >= 1) || !(FeatureManager.GetFeature(2077) is RadioProfilesRecset feature))
      return;
    foreach (AcpBusinessLayer.FeatureNode featureNode in (Collection<AcpBusinessLayer.FeatureNode>) feature)
    {
      AudioSettings audioSettings = (AudioSettings) null;
      LabtoolRAD_PROF_CDA labtoolRadProfCda = (LabtoolRAD_PROF_CDA) null;
      foreach (IAcpFeatureSection featureSections in featureNode.FeatureSectionsCollection)
      {
        if (featureSections.GetType().Equals(typeof (AudioSettings)))
          audioSettings = featureSections as AudioSettings;
        if (featureSections.GetType().Equals(typeof (LabtoolRAD_PROF_CDA)))
          labtoolRadProfCda = featureSections as LabtoolRAD_PROF_CDA;
      }
      if (audioSettings != null && labtoolRadProfCda != null)
      {
        audioSettings.AGCGainControlOutputAccessory_42644.Value = audioSettings.RadProfAudioSettingsOutput_A8679.Value;
        audioSettings.AGCGainControlTotalAccessory_42645.Value = audioSettings.RadProfAudioSettingsTotal_A9394.Value;
        audioSettings.RadioProfileAudioSettingsDigitalAnalogBalanceAccessory_42661.Value = audioSettings.RadioProfileAudioSettingsTxDigitalAnalogBalance_A37715.Value;
        audioSettings.AnalogHighFrequencyBandAccessory_42650.Value = audioSettings.RadProfAudioSettingsAnalog_A7438.Value;
        audioSettings.DigitalHighFrequencyBandAccessory_42655.Value = audioSettings.RadProfAudioSettingsDigital_A7850.Value;
        audioSettings.SecurenetHighFrequencyBandAccessory_42660.Value = audioSettings.RadProfAudioSettingsSecurenet_A9097.Value;
        audioSettings.AnalogLowFrequencyBandAccessory_42647.Value = labtoolRadProfCda.RadProfLabtoolAnalogBassControl_A19506.Value;
        audioSettings.DigitalLowFrequencyBandAccessory_42652.Value = labtoolRadProfCda.RadProfLabtoolDigitalBassControl_A19507.Value;
        audioSettings.SecurenetLowFrequencyBandAccessory_42657.Value = labtoolRadProfCda.RadProfLabtoolSecurenetBassControl_A19508.Value;
      }
    }
  }

  private void UnpackFixupForFPPProtectedZonePassword()
  {
    Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide radioWide = FeatureManager.GetFeature(2045)[0] as Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide;
    if (!(bool) (FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation).Labtool.RadInfoLabtoolQ53NonFEDFPPAndZoneClone_A8799 || !((string) radioWide.UserInformationAndPasswords.RadWideUserInformationandPasswordsProtectedZonePassword_A8766 == string.Empty) || !(bool) radioWide.Features.ZnChanCfgFPPProtectionFPPEnable_A8142)
      return;
    radioWide.Features.ZnChanCfgFPPProtectionFPPEnable_A8142.Value = false;
  }

  private void UnpackFixupForDataWideLTEHWEnable()
  {
    if (!UtilityMack.IsAPXNEXT || this.CodeplugVersion.Major >= 33 || !(FeatureManager.GetFeature(2028)[0] is Motorola.MackinawCPS.CoreFeatures.DataWide.DataWide dataWide) || dataWide.LTE.DataWideLTEHWEnable == null)
      return;
    dataWide.LTE.DataWideLTEHWEnable.Value = true;
  }

  private void UnpackFixupForDataWideLTEDisablementEnable()
  {
    if (!UtilityMack.IsAlohaRadio || this.CodeplugVersion.Major >= 33 || !(FeatureManager.GetFeature(2028)[0] is Motorola.MackinawCPS.CoreFeatures.DataWide.DataWide dataWide) || dataWide.LTE.DataWideLTEDisablementEnable == null)
      return;
    dataWide.LTE.DataWideLTEDisablementEnable.Value = true;
  }

  private void UnpackFixupForRadErgoWideAdvancedPowerUpInHazardZoneMode()
  {
    if (!UtilityMack.IsNFPARadio || this.CodeplugVersion.Major >= 33 || !(FeatureManager.GetFeature(2033)[0] is Motorola.MackinawCPS.CoreFeatures.RadioErgonomicsWide.RadioErgonomicsWide radioErgonomicsWide) || radioErgonomicsWide.Advanced.RadErgoWideAdvancedPowerUpInHazardZoneModeValue)
      return;
    radioErgonomicsWide.Advanced.RadErgoWideAdvancedPowerUpInHazardZoneModeValue = true;
  }

  private void RadErgoWideExternalAccEnableFixup()
  {
    if (int.Parse((FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation).General.RadInfoGeneralCodeplugVersion_A7683.Value.Substring(1, 2)) > 32 /*0x20*/ || !UtilityMack.IsMahaloRadio || !(FeatureManager.GetFeature(2033)[0] is Motorola.MackinawCPS.CoreFeatures.RadioErgonomicsWide.RadioErgonomicsWide radioErgonomicsWide))
      return;
    AcpField<bool> accessoryEnableA36198 = radioErgonomicsWide.Advanced.RadioErgoCfgExternalAccessoryEnable_A36198;
    if (accessoryEnableA36198 == null || !accessoryEnableA36198.Value)
      return;
    accessoryEnableA36198.Value = false;
  }

  private void UpdateValidityOfAdvancedPowerUpOnLastSelectedZoneAndChannel()
  {
    IAcpRecordset feature = FeatureManager.GetFeature(2033);
    if (feature == null)
      return;
    (feature[0] as Motorola.MackinawCPS.CoreFeatures.RadioErgonomicsWide.RadioErgonomicsWide).Advanced.RadErgoWideAdvancedPowerUpOnLastSelectedZoneandChannel_A8787.CalculateValidity();
  }

  private void SetStatusAutoExitToAlwaysAndUpdateConStatusAliasNumber()
  {
    if (!UtilityMack.IsPortablePro || this.CodeplugVersion.Major >= 12 && (this.CodeplugVersion.Major != 12 || this.CodeplugVersion.Minor >= 1) || !(FeatureManager.GetFeature(2033)[0] is Motorola.MackinawCPS.CoreFeatures.RadioErgonomicsWide.RadioErgonomicsWide radioErgonomicsWide) || !radioErgonomicsWide.HomeMode.RadErgoWideHomeModeHomeModeSelection_A8202.HiddenStatic)
      return;
    if (FeatureManager.GetFeature(2010)[0] is Motorola.MackinawCPS.CoreFeatures.DisplayAndMenu.DisplayAndMenu displayAndMenu)
      displayAndMenu.Advanced.RadioErgDispAdvanceStatusAutoExit_42158.SetValue(1);
    if (!(FeatureManager.GetFeature(2007)[0] is Motorola.MackinawCPS.CoreFeatures.ConventionalAliasLists.ConventionalAliasLists conventionalAliasLists) || !(conventionalAliasLists.StatusAliasList.EmbeddedRecset is StatusAliasTableInnerRecset embeddedRecset))
      return;
    int num = 1;
    foreach (AcpBusinessLayer.FeatureNode featureNode in (Collection<AcpBusinessLayer.FeatureNode>) embeddedRecset)
    {
      if (featureNode is StatusAliasTableInner statusAliasTableInner)
        statusAliasTableInner.StatusAliasTableInnerSection.CnvAlsLstStatusAliasListStatusAliasNumber_A9191.SetValue(num++);
    }
  }

  public void SetActionTypeAfterUpgrade()
  {
    if (!UtilityMack.IsPortable())
      return;
    bool flag1 = false;
    bool flag2 = false;
    if (FeatureManager.GetFeature(2049)[0] is Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation radioInformation)
      flag2 = radioInformation.Labtool.RadInfoLabtoolMissionCriticalGeofencing_A43013.Value;
    if (FeatureManager.GetFeature(2045)[0] is Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide radioWide && radioInformation != null)
      flag1 = radioWide.Labtool.RadWideLabtoolPAAlertCapability_A42944.Value && radioInformation.Labtool.RadInfoLabtoolQ445FiregroundSupport_A8796.Value;
    if (!(FeatureManager.GetFeature(4008) is ActionConsolidationRecset feature))
      return;
    foreach (Motorola.MackinawCPS.CoreFeatures.ActionConsolidation.ActionConsolidation actionConsolidation in (Collection<AcpBusinessLayer.FeatureNode>) feature)
    {
      if (actionConsolidation.General.RadioErgoConfigACActionType_A42871.Value == 0)
      {
        if (flag2)
          actionConsolidation.General.RadioErgoConfigACActionType_A42871.SetValue(1);
        else if (flag1)
          actionConsolidation.General.RadioErgoConfigACActionType_A42871.SetValue(3);
      }
    }
  }

  public void SyncActiveMicForBTPTT()
  {
    if (!UtilityMack.IsPortable() || this.CodeplugVersion.Major >= 15)
      return;
    Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide radioWide = FeatureManager.GetFeature(2045)[0] as Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide;
    Motorola.MackinawCPS.CoreFeatures.RadioErgonomicsWide.RadioErgonomicsWide radioErgonomicsWide = FeatureManager.GetFeature(2033)[0] as Motorola.MackinawCPS.CoreFeatures.RadioErgonomicsWide.RadioErgonomicsWide;
    if (radioWide.Bluetooth.RadWideBluetoothActiveRSMInternalMicIfNotBtMic_A41576.Value)
      radioErgonomicsWide.Advanced.RadErgoWideAdvancedActiveMicForBTPTT_43051.SetValue(2);
    else
      radioErgonomicsWide.Advanced.RadErgoWideAdvancedActiveMicForBTPTT_43051.SetValue(3);
  }

  private void RefreshForTrkSys()
  {
  }

  private void RefreshForCnvPer()
  {
    IAcpRecordset acpRecordset = AppInfoManager.AppMode != ApplicationMode.CodeplugConfigurationMode ? AppInfoManager.ComparatorDocument.GetFeature(2059) : FeatureManager.GetFeature(2059);
    if (acpRecordset == null || acpRecordset.Count == 0)
      return;
    foreach (AcpBusinessLayer.FeatureNode featureNode1 in (Collection<AcpBusinessLayer.FeatureNode>) acpRecordset)
    {
      foreach (AcpBusinessLayer.FeatureNode featureNode2 in (Collection<AcpBusinessLayer.FeatureNode>) (featureNode1 as Motorola.MackinawCPS.CoreFeatures.ConventionalPersonality.ConventionalPersonality).FrequencyOptions.EmbeddedRecset)
      {
        FrequencyOptionsInnerSection optionsInnerSection = (featureNode2 as FrequencyOptionsInner).FrequencyOptionsInnerSection;
        optionsInnerSection.CnvPerConventionalChannelOptionsTAPLFreq_A9264.SetValue(optionsInnerSection.CnvPerConventionalChannelOptionsTAPLCode_A9261.Value);
        optionsInnerSection.CnvPerConventionalChannelOptionsRxPLFreq_A8918.SetValue(optionsInnerSection.CnvPerConventionalChannelOptionsRxPLCode_A8917.Value);
        optionsInnerSection.CnvPerConventionalChannelOptionsTxPLFreq_A9419.SetValue(optionsInnerSection.CnvPerConventionalChannelOptionsTxPLCode_A9418.Value);
      }
    }
  }

  private void PresetZoneChannelTableInit()
  {
    IAcpRecordset feature = FeatureManager.GetFeature(2033);
    if (feature == null || !(feature[0][10640].EmbeddedRecset is PresetZoneAndChannelTableInnerRecset embeddedRecset))
      return;
    while (embeddedRecset.Count < 13)
      embeddedRecset.AddRecord(embeddedRecset.CreateDefaultRecord());
  }

  private void BookmarkQuickAccessListInit()
  {
    if (this.CodeplugVersion.Major >= 35)
      return;
    IAcpRecordset feature = FeatureManager.GetFeature(2028);
    if (feature == null || !(feature[0][10910].EmbeddedRecset is BookmarkQuickAccessListInnerRecset embeddedRecset))
      return;
    while (embeddedRecset.Count < 2)
      embeddedRecset.AddRecord(embeddedRecset.CreateDefaultRecord());
  }

  private void KeypadRecsetAndTableInit()
  {
    if (!(FeatureManager.GetFeature(4109) is KeypadRecset feature))
      return;
    bool flag = false;
    KeypadButtonInnerRecset embeddedRecset = feature[0][10710].EmbeddedRecset as KeypadButtonInnerRecset;
    if (embeddedRecset.Count < 12)
      flag = true;
    while (embeddedRecset.Count < 12)
      embeddedRecset.AddRecord(embeddedRecset.CreateDefaultRecord());
    if (!flag)
      return;
    string[] strArray = new string[12]
    {
      AcgResources.ID_ZERO0,
      MTFResources.One1_Id,
      MTFResources.Two2_Id,
      MTFResources.Three3_Id,
      MTFResources.Four4_Id,
      MTFResources.Five5_Id,
      MTFResources.Six6_Id,
      MTFResources.Seven7_Id,
      MTFResources.Eight8_Id,
      MTFResources.Nine9_Id,
      MTFResources.Star_Id,
      MTFResources.PoundHash_Id
    };
    for (int index = 0; index < 12; ++index)
    {
      (embeddedRecset[index] as KeypadButtonInner).KeypadButtonInnerSection.RadErgCtrlKeypadGeneralKeypadButtonName_A41069.SetValue(strArray[index]);
      (embeddedRecset[index] as KeypadButtonInner).KeypadButtonInnerSection.RadErgCtrlKeypadGeneralKeypadBCO_A41070.SetValue(Motorola.MackinawCPS.CoreFeatures.Keypad.LOVs.indexRadErgCtrlKeypadGeneralKeypadBCO_A41070LovStrs[index]);
    }
  }

  private void ResolvedMFKTimerUnpack()
  {
    if (this.CodeplugVersion.Major != 6 && this.CodeplugVersion.Major != 5)
      return;
    Motorola.MackinawCPS.CoreFeatures.RadioErgonomicsWide.RadioErgonomicsWide radioErgonomicsWide = FeatureManager.GetFeature(2033)[0] as Motorola.MackinawCPS.CoreFeatures.RadioErgonomicsWide.RadioErgonomicsWide;
    if (radioErgonomicsWide.Advanced.RadErgoWideAdvancedLongKeypressDurationforMFK_A38506.Value == 0)
      radioErgonomicsWide.Advanced.RadErgoWideAdvancedLongKeypressDurationforMFK_A38506.ResetToDefault();
    if (radioErgonomicsWide.Advanced.RadErgoWideAdvancedMFKInactivityTimeout_A38507.Value == 0)
      radioErgonomicsWide.Advanced.RadErgoWideAdvancedMFKInactivityTimeout_A38507.ResetToDefault();
    if (radioErgonomicsWide.Advanced.RadErgoWideAdvancedShortKeypressDurationforMFK_A38505.Value != 0)
      return;
    radioErgonomicsWide.Advanced.RadErgoWideAdvancedShortKeypressDurationforMFK_A38505.ResetToDefault();
  }

  private void DataProfileTrunkingGroupIDFixup()
  {
    IAcpRecordset feature = FeatureManager.GetFeature(2054);
    if (feature == null)
      return;
    for (int index1 = 0; index1 < feature.Count; ++index1)
    {
      if (feature[index1] is Motorola.MackinawCPS.CoreFeatures.DataProfiles.DataProfiles dataProfiles && dataProfiles.TrunkingGroupID != null && dataProfiles.TrunkingGroupID.EmbeddedRecset != null)
      {
        for (int index2 = 0; index2 < dataProfiles.TrunkingGroupID.EmbeddedRecset.Count; ++index2)
        {
          if (dataProfiles.TrunkingGroupID.EmbeddedRecset[index2] is TrunkingGroupIDListInner groupIdListInner && groupIdListInner.TrunkingGroupIDListInnerSection.DataProfilesTrunkingGroupID_ASTRO25DataGroupID_A36204.HiddenStatic)
            groupIdListInner.TrunkingGroupIDListInnerSection.DataProfilesTrunkingGroupID_ASTRO25DataGroupID_A36204.Valid = true;
          if (groupIdListInner != null && this.CodeplugVersion.Major <= 2 && groupIdListInner.TrunkingGroupIDListInnerSection.DataProfilesTrunkingGroupID_ASTRO25DataGroupID_A36204Value == groupIdListInner.TrunkingGroupIDListInnerSection.DataProfilesTrunkingGroupID_ASTRO25DataGroupID_A36204.DefaultValue)
            groupIdListInner.TrunkingGroupIDListInnerSection.DataProfilesTrunkingGroupID_ASTRO25DataGroupID_A36204.SetValue(groupIdListInner.TrunkingGroupIDListInnerSection.DataProfilesTrunkingGroupID_ASTRO25DataGroupID_A36204.DefaultValue + index2);
        }
      }
    }
  }

  private void ToneSignalingListToneAliasFixup()
  {
    if (this.CodeplugVersion.Major >= 14)
      return;
    foreach (AcpBusinessLayer.FeatureNode featureNode1 in (Collection<AcpBusinessLayer.FeatureNode>) (FeatureManager.GetFeature(4156) as ToneSignalingListRecset))
    {
      if (featureNode1 is Motorola.MackinawCPS.CoreFeatures.ToneSignalingList.ToneSignalingList toneSignalingList && toneSignalingList.AstroAlertingToneListExpander != null && toneSignalingList.AstroAlertingToneListExpander.EmbeddedRecset != null && toneSignalingList.AstroAlertingToneListExpander.EmbeddedRecset is AstroAlertingToneTableInnerRecset embeddedRecset)
      {
        int num = 1;
        foreach (AcpBusinessLayer.FeatureNode featureNode2 in (Collection<AcpBusinessLayer.FeatureNode>) embeddedRecset)
        {
          (featureNode2 as AstroAlertingToneTableInner).AstroAlertingToneTableInnerSection.RadErgoAstroAlertingToneTableToneAliasText_42533.SetValue($"Tone Alias {num}");
          ++num;
        }
      }
    }
  }

  private void DEKVipTableInit()
  {
    if (!UtilityMack.IsMobileOnly())
      return;
    DEKRecset feature1;
    RadioVIPsRecset feature2;
    if (AppInfoManager.AppMode == ApplicationMode.CodeplugConfigurationMode)
    {
      feature1 = FeatureManager.GetFeature(2129) as DEKRecset;
      feature2 = FeatureManager.GetFeature(2125) as RadioVIPsRecset;
    }
    else
    {
      feature1 = AppInfoManager.ComparatorDocument.GetFeature(2129) as DEKRecset;
      feature2 = AppInfoManager.ComparatorDocument.GetFeature(2125) as RadioVIPsRecset;
    }
    if (feature1 == null || feature2 == null)
      return;
    DEKVIPInnerRecset embeddedRecset1 = feature1[0][10233].EmbeddedRecset as DEKVIPInnerRecset;
    Motorola.MackinawCPS.CoreFeatures.DEK.General parentSection = (feature1[0][10232].EmbeddedRecset as DEKButtonInnerRecset).ParentSection as Motorola.MackinawCPS.CoreFeatures.DEK.General;
    RadioVIPInnerRecset embeddedRecset2 = feature2[0][10218].EmbeddedRecset as RadioVIPInnerRecset;
    int num = parentSection.DEKNumberofDEKBoxes_A8579.Value;
    if (num == 0)
    {
      for (int index = 0; index < 9 && embeddedRecset1 != null; ++index)
      {
        if (embeddedRecset1[index] is DEKVIPInner dekvipInner)
        {
          if (dekvipInner.DEKVIPInnerSection.DEKVIPInputFeature_A21338.Value != 38)
            dekvipInner.DEKVIPInnerSection.DEKVIPInputFeature_A21338.SetValue(38);
          if (dekvipInner.DEKVIPInnerSection.DEKVIPOutputFeature_A21346.Value != 0)
            dekvipInner.DEKVIPInnerSection.DEKVIPOutputFeature_A21346.SetValue(0);
        }
      }
    }
    else
    {
      if (num == 0 || embeddedRecset2 == null)
        return;
      for (int index = 0; index < embeddedRecset2.Count; ++index)
      {
        if (embeddedRecset2[index] is RadioVIPInner radioVipInner)
        {
          if (radioVipInner.RadioVIPInnerSection.RadVipInputFeature_A21329.Value != 38)
            radioVipInner.RadioVIPInnerSection.RadVipInputFeature_A21329.SetValue(38);
          if (radioVipInner.RadioVIPInnerSection.RadVipOutputFeature_A20947.Value != 0)
            radioVipInner.RadioVIPInnerSection.RadVipOutputFeature_A20947.SetValue(0);
        }
      }
    }
  }

  private void RestoreScanZoneChannelWhenCNVTalkGroupIsDVNOrATG()
  {
    if (!(FeatureManager.GetFeature(2049)[0] is Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation radioInformation) || radioInformation.Labtool == null || radioInformation.Labtool.RadioInfoLabToolQA00631DvrsPsuActivation_A40166 == null || !radioInformation.Labtool.RadioInfoLabToolQA00631DvrsPsuActivation_A40166.Value || !(FeatureManager.GetFeature(2057) is ScanListRecset feature))
      return;
    for (int index1 = 0; index1 < feature.Count; ++index1)
    {
      if (feature[index1] is Motorola.MackinawCPS.CoreFeatures.ScanList.ScanList scanList && scanList.ScanListMembers != null && scanList.ScanListMembers.EmbeddedRecset != null)
      {
        for (int index2 = 0; index2 < scanList.ScanListMembers.EmbeddedRecset.Count; ++index2)
        {
          if (scanList.ScanListMembers.EmbeddedRecset[index2] is ScanListInner scanListInner && scanListInner.ScanListInnerSection != null && scanListInner.ScanListInnerSection.ScanLstScanListChannel_A7620 != null && scanListInner.ScanListInnerSection.ScanLstScanListChannel_A7620.Value != 0)
          {
            AcpRecRefField listChannelA7620 = scanListInner.ScanListInnerSection.ScanLstScanListChannel_A7620;
            if (listChannelA7620.ReferencedNode != null && listChannelA7620.ReferencedNode is ChannelAssignmentListInner referencedNode1 && referencedNode1.ChannelAssignmentListInnerSection != null && referencedNode1.ChannelAssignmentListInnerSection.ZnChanCfgChannelsChannelType_A22241 != null && referencedNode1.ChannelAssignmentListInnerSection.ZnChanCfgChannelsChannelType_A22241.Value == 0 && referencedNode1.ChannelAssignmentListInnerSection.ZnChanCfgChannelsPersonality_A8698 != null && referencedNode1.ChannelAssignmentListInnerSection.ZnChanCfgChannelsPersonality_A8698.ReferencedNode != null && referencedNode1.ChannelAssignmentListInnerSection.ZnChanCfgChannelsPersonality_A8698.ReferencedNode is Motorola.MackinawCPS.CoreFeatures.ConventionalPersonality.ConventionalPersonality referencedNode2 && referencedNode2.RxOptions != null && referencedNode2.RxOptions.CnvPerRxOptionsRxVoiceSignalType_A9044 != null && referencedNode2.ASTROTalkgroup != null && referencedNode2.ASTROTalkgroup.CnvPerASTROTalkgroupOptionsTalkGroupEnable_A9272 != null && referencedNode2.RxOptions.CnvPerRxOptionsRxVoiceSignalType_A9044.Value != 0 && referencedNode2.ASTROTalkgroup.CnvPerASTROTalkgroupOptionsTalkGroupEnable_A9272.Value && referencedNode1.ChannelAssignmentListInnerSection.ZnChanCfgChannelsConventionalChannelReference_A20560 != null && referencedNode1.ChannelAssignmentListInnerSection.ZnChanCfgChannelsConventionalChannelReference_A20560.ReferencedNode is FrequencyOptionsInner referencedNode3 && referencedNode3.FrequencyOptionsInnerSection != null && referencedNode3.FrequencyOptionsInnerSection.CnvPerConventionalChannelOptionsASTROTalkgroupID_A9281 != null && (referencedNode3.FrequencyOptionsInnerSection.CnvPerConventionalChannelOptionsASTROTalkgroupID_A9281.Value == (int) ushort.MaxValue || referencedNode3.FrequencyOptionsInnerSection.CnvPerConventionalChannelOptionsASTROTalkgroupID_A9281.Value == 65534))
            {
              scanListInner.ScanListInnerSection.ScanLstScanListChannel_A7620.SetValue(0);
              scanListInner.ScanListInnerSection.ScanLstScanListZone_A9718.SetValue(0);
            }
          }
        }
      }
    }
  }

  private void InitFCCNarrowBandSplit()
  {
    IAcpRecordset acpRecordset = AppInfoManager.AppMode != ApplicationMode.CodeplugComparisonMode ? FeatureManager.GetFeature(2045) : AppInfoManager.ComparatorDocument.GetFeature(2045);
    if (acpRecordset == null)
      return;
    AcpBusinessLayer.FeatureNode parent = acpRecordset[0] as AcpBusinessLayer.FeatureNode;
    FCCNarrowBandingFrequencySplit bandingFrequencySplit = parent[10636] as FCCNarrowBandingFrequencySplit;
    bool flag1 = false;
    if (bandingFrequencySplit == null)
    {
      parent.AddFeatureSection((IAcpFeatureSection) new FCCNarrowBandingFrequencySplit(parent));
      bandingFrequencySplit = parent[10636] as FCCNarrowBandingFrequencySplit;
      flag1 = true;
    }
    if (!(bandingFrequencySplit.EmbeddedRecset is FCCNarrowBandingFrequencySplitInnerRecset embeddedRecset))
      return;
    bool flag2 = false;
    if (embeddedRecset.Count < 3)
      flag2 = true;
    while (embeddedRecset.Count < 3)
      embeddedRecset.AddRecord(embeddedRecset.CreateDefaultRecord());
    if (!(flag2 | flag1))
      return;
    FCCNarrowBandingFrequencySplitInnerSection splitInnerSection1 = ((FCCNarrowBandingFrequencySplitInner) embeddedRecset[0]).FCCNarrowBandingFrequencySplitInnerSection;
    splitInnerSection1.RadWideLabtoolFCCNarrowBandStartFrequency_A38270.Value = 30160000;
    splitInnerSection1.RadWideLabtoolFCCNarrowBandEndFrequency_A38271.Value = 32402500;
    FCCNarrowBandingFrequencySplitInnerSection splitInnerSection2 = ((FCCNarrowBandingFrequencySplitInner) embeddedRecset[1]).FCCNarrowBandingFrequencySplitInnerSection;
    splitInnerSection2.RadWideLabtoolFCCNarrowBandStartFrequency_A38270.Value = 34640000;
    splitInnerSection2.RadWideLabtoolFCCNarrowBandEndFrequency_A38271.Value = 34680000;
    FCCNarrowBandingFrequencySplitInnerSection splitInnerSection3 = ((FCCNarrowBandingFrequencySplitInner) embeddedRecset[2]).FCCNarrowBandingFrequencySplitInnerSection;
    splitInnerSection3.RadWideLabtoolFCCNarrowBandStartFrequency_A38270.Value = 84200000;
    splitInnerSection3.RadWideLabtoolFCCNarrowBandEndFrequency_A38271.Value = 94000000;
  }

  private void InitTrkPerAnnGroup()
  {
    foreach (Motorola.MackinawCPS.CoreFeatures.TrunkingPersonality.TrunkingPersonality trunkingPersonality in AppInfoManager.AppMode != ApplicationMode.CodeplugConfigurationMode ? (Collection<AcpBusinessLayer.FeatureNode>) (AppInfoManager.ComparatorDocument.GetFeature(2072) as TrunkingPersonalityRecset) : (Collection<AcpBusinessLayer.FeatureNode>) (FeatureManager.GetFeature(2072) as TrunkingPersonalityRecset))
    {
      if (trunkingPersonality.General.TrkPerGeneralProtocolType_A8767.Value == 2)
      {
        AcpCustomRangeField announcementGroupA7444 = trunkingPersonality.AnnouncementGroup.TrkPerAnnouncementGroupAnnouncementGroup_A7444;
        if (announcementGroupA7444.Value == 0)
          announcementGroupA7444.SetValue(4095 /*0x0FFF*/);
        announcementGroupA7444.ReplaceCustomValue(4095 /*0x0FFF*/, AppResources.None_Id);
      }
    }
  }

  private void InitTrkPerFeaturesPriorityDispatchTimeOutTimer43598AfterUnpack()
  {
    foreach (Motorola.MackinawCPS.CoreFeatures.TrunkingPersonality.TrunkingPersonality trunkingPersonality in AppInfoManager.AppMode != ApplicationMode.CodeplugConfigurationMode ? (Collection<AcpBusinessLayer.FeatureNode>) (AppInfoManager.ComparatorDocument.GetFeature(2072) as TrunkingPersonalityRecset) : (Collection<AcpBusinessLayer.FeatureNode>) (FeatureManager.GetFeature(2072) as TrunkingPersonalityRecset))
    {
      int num = trunkingPersonality.Features.TrkPerFeaturesPriorityDispatchTimeOutTimersec_43598.Value;
      if (num < trunkingPersonality.Features.TrkPerFeaturesPriorityDispatchTimeOutTimersec_43598.Min || num > trunkingPersonality.Features.TrkPerFeaturesPriorityDispatchTimeOutTimersec_43598.Max)
        trunkingPersonality.Features.TrkPerFeaturesPriorityDispatchTimeOutTimersec_43598.ResetToDefault();
    }
  }

  private void BandSplitOverRidingInit()
  {
    Motorola.MackinawCPS.CoreFeatures.RadioWide.Features features = FeatureManager.GetFeature(2045)[0][10105] as Motorola.MackinawCPS.CoreFeatures.RadioWide.Features;
    if (features.RadWideTransmitPowerLevelsBandSplitOverride_A41064Value != 0)
      return;
    Motorola.MackinawCPS.CoreFeatures.RadioInformation.Labtool labtool = FeatureManager.GetFeature(2049)[0][10107] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.Labtool;
    int newValue = 0;
    if (!labtool.RadInfoLabtoolDualBandEnable_A23986Value)
    {
      if (labtool.RadInfoLabtoolPrimaryBands_A23987Value == 4 && labtool.RadInfoLabtoolSecondaryBands_A23988Value == 8 || labtool.RadInfoLabtoolPrimaryBands_A23987Value == 5 && labtool.RadInfoLabtoolSecondaryBands_A23988Value == 8)
        newValue = 1;
      else if (labtool.RadInfoLabtoolPrimaryBands_A23987Value == 8 && labtool.RadInfoLabtoolSecondaryBands_A23988Value == 4 || labtool.RadInfoLabtoolPrimaryBands_A23987Value == 8 && labtool.RadInfoLabtoolSecondaryBands_A23988Value == 5)
        newValue = 2;
    }
    else if (labtool.RadInfoLabtoolPrimaryBands_A23987Value == 4 && labtool.RadInfoLabtoolSecondaryBands_A23988Value == 8 || labtool.RadInfoLabtoolPrimaryBands_A23987Value == 8 && labtool.RadInfoLabtoolSecondaryBands_A23988Value == 4)
      newValue = 2;
    else if (labtool.RadInfoLabtoolPrimaryBands_A23987Value == 5 && labtool.RadInfoLabtoolSecondaryBands_A23988Value == 8 || labtool.RadInfoLabtoolPrimaryBands_A23987Value == 8 && labtool.RadInfoLabtoolSecondaryBands_A23988Value == 5)
      newValue = 1;
    features.RadWideTransmitPowerLevelsBandSplitOverride_A41064.SetValue(newValue);
  }

  private void TxPowerTableInit()
  {
    if (FeatureManager.GetFeature(2045)[0][10103].EmbeddedRecset is TxPowerLevelsByFrequencyRangeInnerRecset embeddedRecset && embeddedRecset.Count < 6)
    {
      int count = embeddedRecset.Count;
      while (embeddedRecset.Count < 6)
        embeddedRecset.AddRecord(embeddedRecset.CreateDefaultRecord());
      if (embeddedRecset[3][10104] is TxPowerLevelsByFrequencyRangeInnerSection rangeInnerSection1 && count < 4)
      {
        if (this.IsExtendedUHFR1CPG())
        {
          rangeInnerSection1.RadWideTransmitPowerLevelsFrequencyRangeEndMHz_A20037.SetValue(94400000);
        }
        else
        {
          rangeInnerSection1.RadWideTransmitPowerLevelsFrequencyRangeEndMHz_A20037.SetValue(94000000);
          rangeInnerSection1.RadWideTransmitPowerLevelsFrequencyRangeStartMHz_A19994.SetValue(76000000);
          rangeInnerSection1.RadWideTransmitPowerLevelsTxPowerLevelLowW_A8153.SetValue(30792);
          if (!this.IsULPCPG())
          {
            rangeInnerSection1.RadWideTransmitPowerLevelsTxPowerLevelMaximumW_A20039.SetValue(37243);
            rangeInnerSection1.RadWideTransmitPowerLevelsTxPowerLevelHighW_A8152.SetValue(37243);
          }
        }
      }
      if (embeddedRecset[4][10104] is TxPowerLevelsByFrequencyRangeInnerSection rangeInnerSection2 && count < 5)
      {
        rangeInnerSection2.RadWideTransmitPowerLevelsFrequencyRangeEndMHz_A20037.SetValue(104000000);
        rangeInnerSection2.RadWideTransmitPowerLevelsFrequencyRangeStartMHz_A19994.SetValue(90000000);
        rangeInnerSection2.RadWideTransmitPowerLevelsTxPowerLevelMaximumW_A20039.SetValue(37243);
        rangeInnerSection2.RadWideTransmitPowerLevelsTxPowerLevelLowW_A8153.SetValue(30792);
        rangeInnerSection2.RadWideTransmitPowerLevelsTxPowerLevelHighW_A8152.SetValue(37243);
      }
      if (embeddedRecset[5][10104] is TxPowerLevelsByFrequencyRangeInnerSection rangeInnerSection3 && count < 6)
      {
        rangeInnerSection3.RadWidePowerLevelBandFrequency_A41063.SetValue(AcgResources.ID_P_900MHZ);
        rangeInnerSection3.RadWideTransmitPowerLevelsFrequencyRangeEndMHz_A20037.SetValue(188200000);
        rangeInnerSection3.RadWideTransmitPowerLevelsFrequencyRangeStartMHz_A19994.SetValue(179200000);
        rangeInnerSection3.RadWideTransmitPowerLevelsTxPowerLevelHighW_A8152.SetValue(34393);
        rangeInnerSection3.RadWideTransmitPowerLevelsTxPowerLevelMaximumW_A20039.SetValue(34393);
      }
    }
    try
    {
      Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation radioInformation = FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation;
      string str = radioInformation.General.RadInfoGeneralCodeplugVersion_A7683.Value;
      int num = radioInformation.Labtool.RadInfoLabtoolProductModelIdentifier_A37178.Value;
      if (str != null)
      {
        if (str.Length > 3)
        {
          if (int.Parse(str.Substring(1, 2)) < 8)
          {
            if (num != 6)
            {
              if (num != 5)
                goto label_22;
            }
            TxPowerLevelsByFrequencyRangeInnerSection rangeInnerSection = embeddedRecset[0][10104] as TxPowerLevelsByFrequencyRangeInnerSection;
            rangeInnerSection.RadWideTransmitPowerLevelsTxPowerLevelHighW_A8152.SetValue(37404);
            rangeInnerSection.RadWideTransmitPowerLevelsTxPowerLevelMaximumW_A20039.SetValue(37404);
          }
        }
      }
    }
    catch
    {
    }
label_22:
    try
    {
      Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation radioInformation = FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation;
      string str = radioInformation.General.RadInfoGeneralCodeplugVersion_A7683.Value;
      int num = radioInformation.Labtool.RadInfoLabtoolProductModelIdentifier_A37178.Value;
      if (str == null || str.Length <= 3 || int.Parse(str.Substring(1, 2)) >= 8 || num != 6 && num != 5)
        return;
      TxPowerLevelsByFrequencyRangeInnerSection rangeInnerSection = embeddedRecset[0][10104] as TxPowerLevelsByFrequencyRangeInnerSection;
      rangeInnerSection.RadWideTransmitPowerLevelsTxPowerLevelHighW_A8152.SetValue(37404);
      rangeInnerSection.RadWideTransmitPowerLevelsTxPowerLevelMaximumW_A20039.SetValue(37404);
    }
    catch
    {
    }
  }

  private void ResetRadioKilledBit()
  {
    if (!(FeatureManager.GetFeature(2045)[0] is Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide radioWide))
      return;
    radioWide.Labtool.RadWideRadioKilled_A41559.Value = false;
  }

  private bool IsExtendedUHFR1CPG()
  {
    if (FeatureManager.GetFeature(2049)[0] is Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation radioInformation)
    {
      bool flag1 = radioInformation.FrequencyRanges.RadInfoFrequencyRangesExtendedUHFR1Capable_A41443.Value;
      int num1 = radioInformation.Labtool.RadInfoLabtoolPrimaryBands_A23987.Value;
      int num2 = radioInformation.Labtool.RadInfoLabtoolSecondaryBands_A23988.Value;
      bool flag2 = !UtilityMack.IsFreonRadio ? num1 == 5 || num1 == 4 || num2 == 5 || num2 == 4 : radioInformation.General.RadInfoGeneralPrimaryFrequencyBandUHF1_A42546.Value;
      if (flag1 & flag2)
        return true;
    }
    return false;
  }

  private bool IsULPCPG()
  {
    try
    {
      return (FeatureManager.GetFeature(2045)[0] as Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide).Labtool.RadWideLabtoolUltraLowPowerSoldierMacCapable_A41710Value;
    }
    catch
    {
      return false;
    }
  }

  private void TxPowerNewTableInitForMobile()
  {
    IAcpRecordset feature = FeatureManager.GetFeature(2045);
    TxPowerLevelsByFrequencyRangeInnerRecset embeddedRecset1 = feature[0][10103].EmbeddedRecset as TxPowerLevelsByFrequencyRangeInnerRecset;
    if (embeddedRecset1.Count < 16 /*0x10*/ || !(feature[0][10761].EmbeddedRecset is TxPowerLevelsByFrequencyRangeNewBandPlanInnerRecset embeddedRecset2) || embeddedRecset2.Count >= 19)
      return;
    while (embeddedRecset2 != null && embeddedRecset2.Count < 19)
      embeddedRecset2.AddRecord(embeddedRecset2.CreateDefaultRecord());
    int[] numArray1 = new int[19]
    {
      27200000,
      152400000,
      153800000,
      153815001,
      154985000,
      155000001,
      159800000,
      159815001,
      160985000,
      161000000,
      161200000,
      76000000,
      90000000,
      97000000,
      102400000,
      179200000,
      180200000,
      187000000,
      188000000
    };
    int[] numArray2 = new int[19]
    {
      34800000,
      153799999,
      153815000,
      154984999,
      155000000,
      159799999,
      159815000,
      160984999,
      160999999,
      161199999,
      174000000,
      94000000,
      96999999,
      102399999,
      104000000,
      180199999,
      180400000,
      187999999,
      188200000
    };
    if (this.IsExtendedUHFR1CPG())
      numArray2[11] = 94400000;
    for (int index = 0; index < 19; ++index)
    {
      TxPowerLevelsByFrequencyRangeNewBandPlanInnerSection planInnerSection = embeddedRecset2[index][10762] as TxPowerLevelsByFrequencyRangeNewBandPlanInnerSection;
      TxPowerLevelsByFrequencyRangeInnerSection rangeInnerSection = index >= 9 ? (index != 9 ? embeddedRecset1[index - 1][10104] as TxPowerLevelsByFrequencyRangeInnerSection : embeddedRecset1[7][10104] as TxPowerLevelsByFrequencyRangeInnerSection) : embeddedRecset1[index][10104] as TxPowerLevelsByFrequencyRangeInnerSection;
      planInnerSection.RadWidePowerLevelBandFrequency_A41864.SetValue(rangeInnerSection.RadWidePowerLevelBandFrequency_A41063.Value);
      planInnerSection.RadWideTransmitPowerLevelsFrequencyRangeStartMHz_A41856.SetValue(numArray1[index]);
      planInnerSection.RadWideTransmitPowerLevelsFrequencyRangeEndMHz_A41857.SetValue(numArray2[index]);
      planInnerSection.RadWideTransmitPowerLevelsTxPowerLevelMinimumW_A41858.SetValue(rangeInnerSection.RadWideTransmitPowerLevelsTxPowerLevelMinimumW_A20038.Value);
      planInnerSection.RadWideTransmitPowerLevelsTxPowerLevelLowW_A41855.SetValue(rangeInnerSection.RadWideTransmitPowerLevelsTxPowerLevelLowW_A8153.Value);
      planInnerSection.RadWideTransmitPowerLevelsTxPowerLevelHighW_A41854.SetValue(rangeInnerSection.RadWideTransmitPowerLevelsTxPowerLevelHighW_A8152.Value);
      planInnerSection.RadWideTransmitPowerLevelsTxPowerLevelMaximumW_A41859.SetValue(rangeInnerSection.RadWideTransmitPowerLevelsTxPowerLevelMaximumW_A20039.Value);
      planInnerSection.RadWideTransmitPowerLevelsConvTxPowerLevelMinimumW_A41863.SetValue(rangeInnerSection.RadWideTransmitPowerLevelsConvTxPowerLevelMinimumW_A41173.Value);
      planInnerSection.RadWideTransmitPowerLevelsTrkTxPowerLevelMinimumW_A41862.SetValue(rangeInnerSection.RadWideTransmitPowerLevelsTrkTxPowerLevelMinimumW_A41174.Value);
      planInnerSection.RadWideTransmitPowerLevelsConvTxPowerLevelLowW_A41861.SetValue(rangeInnerSection.RadWideTransmitPowerLevelsConvTxPowerLevelLowW_A41175.Value);
      planInnerSection.RadWideTransmitPowerLevelsTrkTxPowerLevelLowW_A41860.SetValue(rangeInnerSection.RadWideTransmitPowerLevelsTrkTxPowerLevelLowW_A41176.Value);
    }
  }

  private void TxPowerTableInitForMobile()
  {
    TxPowerLevelsByFrequencyRangeInnerRecset embeddedRecset = FeatureManager.GetFeature(2045)[0][10103].EmbeddedRecset as TxPowerLevelsByFrequencyRangeInnerRecset;
    Motorola.MackinawCPS.CoreFeatures.RadioInformation.Labtool labtool = FeatureManager.GetFeature(2049)[0][10107] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.Labtool;
    if (embeddedRecset != null && embeddedRecset.Count < 18)
    {
      int count = embeddedRecset.Count;
      while (embeddedRecset.Count < 18)
        embeddedRecset.AddRecord(embeddedRecset.CreateDefaultRecord());
      TxPowerLevelsByFrequencyRangeInnerSection rangeInnerSection = embeddedRecset[0][10104] as TxPowerLevelsByFrequencyRangeInnerSection;
      for (int index = 10; index < 18; ++index)
      {
        if (index >= count && embeddedRecset[index][10104] is TxPowerLevelsByFrequencyRangeInnerSection txPowerLevel && labtool != null)
        {
          switch (index)
          {
            case 10:
              txPowerLevel.RadWidePowerLevelBandFrequency_A41063.SetValue(AcgResources.ID_UHF1);
              if (this.IsExtendedUHFR1CPG())
                txPowerLevel.RadWideTransmitPowerLevelsFrequencyRangeEndMHz_A20037.SetValue(94400000);
              else
                txPowerLevel.RadWideTransmitPowerLevelsFrequencyRangeEndMHz_A20037.SetValue(94000000);
              txPowerLevel.RadWideTransmitPowerLevelsFrequencyRangeStartMHz_A19994.SetValue(76000000);
              break;
            case 11:
              txPowerLevel.RadWidePowerLevelBandFrequency_A41063.SetValue(AcgResources.ID_UHF2);
              txPowerLevel.RadWideTransmitPowerLevelsFrequencyRangeEndMHz_A20037.SetValue(96999999);
              txPowerLevel.RadWideTransmitPowerLevelsFrequencyRangeStartMHz_A19994.SetValue(90000000);
              break;
            case 12:
              txPowerLevel.RadWidePowerLevelBandFrequency_A41063.SetValue(AcgResources.ID_UHF2);
              txPowerLevel.RadWideTransmitPowerLevelsFrequencyRangeEndMHz_A20037.SetValue(102399999);
              txPowerLevel.RadWideTransmitPowerLevelsFrequencyRangeStartMHz_A19994.SetValue(97000000);
              break;
            case 13:
              txPowerLevel.RadWidePowerLevelBandFrequency_A41063.SetValue(AcgResources.ID_UHF2);
              txPowerLevel.RadWideTransmitPowerLevelsFrequencyRangeEndMHz_A20037.SetValue(104000000);
              txPowerLevel.RadWideTransmitPowerLevelsFrequencyRangeStartMHz_A19994.SetValue(102400000);
              break;
            case 14:
              txPowerLevel.RadWidePowerLevelBandFrequency_A41063.SetValue(AcgResources.ID_P_900MHZ);
              txPowerLevel.RadWideTransmitPowerLevelsFrequencyRangeEndMHz_A20037.SetValue(180199999);
              txPowerLevel.RadWideTransmitPowerLevelsFrequencyRangeStartMHz_A19994.SetValue(179200000);
              break;
            case 15:
              txPowerLevel.RadWidePowerLevelBandFrequency_A41063.SetValue(AcgResources.ID_P_900MHZ);
              txPowerLevel.RadWideTransmitPowerLevelsFrequencyRangeEndMHz_A20037.SetValue(180400000);
              txPowerLevel.RadWideTransmitPowerLevelsFrequencyRangeStartMHz_A19994.SetValue(180200000);
              break;
            case 16 /*0x10*/:
              txPowerLevel.RadWidePowerLevelBandFrequency_A41063.SetValue(AcgResources.ID_P_900MHZ);
              txPowerLevel.RadWideTransmitPowerLevelsFrequencyRangeEndMHz_A20037.SetValue(187999999);
              txPowerLevel.RadWideTransmitPowerLevelsFrequencyRangeStartMHz_A19994.SetValue(187000000);
              break;
            case 17:
              txPowerLevel.RadWidePowerLevelBandFrequency_A41063.SetValue(AcgResources.ID_P_900MHZ);
              txPowerLevel.RadWideTransmitPowerLevelsFrequencyRangeEndMHz_A20037.SetValue(188200000);
              txPowerLevel.RadWideTransmitPowerLevelsFrequencyRangeStartMHz_A19994.SetValue(188000000);
              break;
          }
          if (rangeInnerSection.RadWideTransmitPowerLevelsTxPowerLevelMaximumW_A20039.Value == 43424 && rangeInnerSection.RadWideTransmitPowerLevelsTxPowerLevelMinimumW_A20038.Value == 40000)
          {
            switch (index)
            {
              case 10:
              case 11:
              case 12:
              case 13:
                this.SetTransmitPowerLevels(txPowerLevel, 36021, 40414, 43424, 43424);
                continue;
              case 14:
                this.SetTransmitPowerLevels(txPowerLevel, 30000, 42175, 45185, 45185);
                continue;
              case 15:
                this.SetTransmitPowerLevels(txPowerLevel, 30000, 33010, 35441, 35441);
                continue;
              case 16 /*0x10*/:
                this.SetTransmitPowerLevels(txPowerLevel, 30000, 42175, 45185, 45185);
                continue;
              case 17:
                this.SetTransmitPowerLevels(txPowerLevel, 30000, 33010, 35441, 35441);
                continue;
              default:
                continue;
            }
          }
          else if (rangeInnerSection.RadWideTransmitPowerLevelsTxPowerLevelMaximumW_A20039.Value == 44393 && rangeInnerSection.RadWideTransmitPowerLevelsTxPowerLevelMinimumW_A20038.Value == 40000)
          {
            switch (index)
            {
              case 10:
              case 11:
              case 12:
              case 13:
                this.SetTransmitPowerLevels(txPowerLevel, 36021, 41461, 44393, 44393);
                continue;
              case 14:
                this.SetTransmitPowerLevels(txPowerLevel, 30000, 42175, 45185, 45185);
                continue;
              case 15:
                this.SetTransmitPowerLevels(txPowerLevel, 30000, 33010, 35441, 35441);
                continue;
              case 16 /*0x10*/:
                this.SetTransmitPowerLevels(txPowerLevel, 30000, 42175, 45185, 45185);
                continue;
              case 17:
                this.SetTransmitPowerLevels(txPowerLevel, 30000, 33010, 35441, 35441);
                continue;
              default:
                continue;
            }
          }
          else if (labtool.RadInfoLabtoolG138MotorcycleRadio_A24684.Value)
          {
            switch (index)
            {
              case 10:
              case 11:
              case 12:
              case 13:
                this.SetTransmitPowerLevels(txPowerLevel, 36021, 39031, 42175, 42175);
                continue;
              case 14:
                this.SetTransmitPowerLevels(txPowerLevel, 30000, 42175, 45185, 45185);
                continue;
              case 15:
                this.SetTransmitPowerLevels(txPowerLevel, 30000, 33010, 35441, 35441);
                continue;
              case 16 /*0x10*/:
                this.SetTransmitPowerLevels(txPowerLevel, 30000, 42175, 45185, 45185);
                continue;
              case 17:
                this.SetTransmitPowerLevels(txPowerLevel, 30000, 33010, 35441, 35441);
                continue;
              default:
                continue;
            }
          }
          else if (labtool.RadInfoLabtoolPrimaryBands_A23987.Value == 1 && labtool.RadInfoLabtoolSecondaryBands_A23988.Value == 0 || labtool.RadInfoLabtoolPrimaryBands_A23987.Value == 1 && labtool.RadInfoLabtoolSecondaryBands_A23988.Value == 2 || labtool.RadInfoLabtoolPrimaryBands_A23987.Value == 2 || labtool.RadInfoLabtoolPrimaryBands_A23987.Value == 4 || labtool.RadInfoLabtoolPrimaryBands_A23987.Value == 8)
          {
            switch (index)
            {
              case 10:
                this.SetTransmitPowerLevels(txPowerLevel, 36021, 43424, 46435, 46435);
                continue;
              case 11:
                this.SetTransmitPowerLevels(txPowerLevel, 36021, 43979, 46946, 46946);
                continue;
              case 12:
                this.SetTransmitPowerLevels(txPowerLevel, 36021, 43424, 46435, 46435);
                continue;
              case 13:
                this.SetTransmitPowerLevels(txPowerLevel, 36021, 41461, 44393, 44393);
                continue;
              case 14:
                this.SetTransmitPowerLevels(txPowerLevel, 30000, 42175, 45185, 45185);
                continue;
              case 15:
                this.SetTransmitPowerLevels(txPowerLevel, 30000, 33010, 35441, 35441);
                continue;
              case 16 /*0x10*/:
                this.SetTransmitPowerLevels(txPowerLevel, 30000, 42175, 45185, 45185);
                continue;
              case 17:
                this.SetTransmitPowerLevels(txPowerLevel, 30000, 33010, 35441, 35441);
                continue;
              default:
                continue;
            }
          }
          else if (labtool.RadInfoLabtoolPrimaryBands_A23987.Value == 1 && labtool.RadInfoLabtoolSecondaryBands_A23988.Value == 3 || labtool.RadInfoLabtoolPrimaryBands_A23987.Value == 3 || labtool.RadInfoLabtoolPrimaryBands_A23987.Value == 5)
          {
            switch (index)
            {
              case 10:
                this.SetTransmitPowerLevels(txPowerLevel, 43979, 47404, 50414, 50414);
                continue;
              case 11:
                this.SetTransmitPowerLevels(txPowerLevel, 36021, 43979, 46946, 46946);
                continue;
              case 12:
                this.SetTransmitPowerLevels(txPowerLevel, 36021, 43424, 46435, 46435);
                continue;
              case 13:
                this.SetTransmitPowerLevels(txPowerLevel, 36021, 41461, 44393, 44393);
                continue;
              case 14:
                this.SetTransmitPowerLevels(txPowerLevel, 30000, 42175, 45185, 45185);
                continue;
              case 15:
                this.SetTransmitPowerLevels(txPowerLevel, 30000, 33010, 35441, 35441);
                continue;
              case 16 /*0x10*/:
                this.SetTransmitPowerLevels(txPowerLevel, 30000, 42175, 45185, 45185);
                continue;
              case 17:
                this.SetTransmitPowerLevels(txPowerLevel, 30000, 33010, 35441, 35441);
                continue;
              default:
                continue;
            }
          }
        }
      }
    }
    try
    {
      switch ((FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation).Labtool.RadInfoLabtoolProductModelIdentifier_A37178.Value)
      {
        case 14:
        case 15:
        case 17:
        case 22:
          (embeddedRecset[10][10104] as TxPowerLevelsByFrequencyRangeInnerSection).RadWideTransmitPowerLevelsTxPowerLevelMinimumW_A20038.SetValue(30000);
          (embeddedRecset[11][10104] as TxPowerLevelsByFrequencyRangeInnerSection).RadWideTransmitPowerLevelsTxPowerLevelMinimumW_A20038.SetValue(30000);
          (embeddedRecset[12][10104] as TxPowerLevelsByFrequencyRangeInnerSection).RadWideTransmitPowerLevelsTxPowerLevelMinimumW_A20038.SetValue(30000);
          (embeddedRecset[13][10104] as TxPowerLevelsByFrequencyRangeInnerSection).RadWideTransmitPowerLevelsTxPowerLevelMinimumW_A20038.SetValue(30000);
          break;
      }
    }
    catch
    {
    }
    if ((FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation).Labtool.RadInfoLabtoolProductModelIdentifier_A37178.Value != 27)
      return;
    this.UpdatePowerLevelMinimumForAPX8500(embeddedRecset);
  }

  private void SetTransmitPowerLevels(
    TxPowerLevelsByFrequencyRangeInnerSection txPowerLevel,
    int min,
    int low,
    int high,
    int max)
  {
    txPowerLevel.RadWideTransmitPowerLevelsTxPowerLevelMinimumW_A20038.SetValue(min);
    txPowerLevel.RadWideTransmitPowerLevelsTxPowerLevelLowW_A8153.SetValue(low);
    txPowerLevel.RadWideTransmitPowerLevelsTxPowerLevelHighW_A8152.SetValue(high);
    txPowerLevel.RadWideTransmitPowerLevelsTxPowerLevelMaximumW_A20039.SetValue(max);
  }

  private void ResetMotionSensitivityDefaultValue()
  {
    if (!((FeatureManager.GetFeature(2032) as EmergencyWideRecset)[0][10639] is ManDown manDown))
      return;
    manDown.EmerWideManDownMotionlessSensitivity_A40002.SetValue(1);
  }

  private void ResetEmergencyAlarmRetryRateDefaultValue()
  {
    TPS tps = (FeatureManager.GetFeature(2045) as RadioWideRecset)[0][10749] as TPS;
    int major = this.CodeplugVersion.Major;
    if (tps == null || major >= 9)
      return;
    tps.RadWideTPSFiregroundEmergencyAlarmRetryRatesec_A7929.Value = 4;
  }

  public void ResolveUCLReferenceAfterUnpack()
  {
    foreach (IAcpFeatureNode acpFeatureNode1 in (Collection<AcpBusinessLayer.FeatureNode>) FeatureManager.GetFeature(2200))
    {
      foreach (IAcpRecordset embeddedRecordset in acpFeatureNode1.EmbeddedRecordsets)
      {
        foreach (IAcpFeatureNode acpFeatureNode2 in (Collection<AcpBusinessLayer.FeatureNode>) embeddedRecordset)
        {
          if (embeddedRecordset.ParentSection.FeatureSectionId == 10401)
            ((TrunkingCallListCallListSection) acpFeatureNode2[10402]).ResolveReferenceAfterUnpack();
          else if (embeddedRecordset.ParentSection.FeatureSectionId == 10411)
            ((TrunkingT2CallListCallListSection) acpFeatureNode2[10412]).ResolveReferenceAfterUnpack();
          else if (embeddedRecordset.ParentSection.FeatureSectionId == 10403)
            ((AstroCallListCallListSection) acpFeatureNode2[10404]).ResolveReferenceAfterUnpack();
          else if (embeddedRecordset.ParentSection.FeatureSectionId == 10405)
            ((MDCCallListCallListSection) acpFeatureNode2[10406]).ResolveReferenceAfterUnpack();
        }
      }
    }
  }

  public event PropertyChangedEventHandler PropertyChanged;

  public void FirePropertyChanged(string name)
  {
    if (this.PropertyChanged == null)
      return;
    this.PropertyChanged((object) this, new PropertyChangedEventArgs(name));
  }

  internal ResultStatus PromptQuitOnInvalids()
  {
    ResultStatus resultStatus = new ResultStatus();
    this.NATListFixup();
    this.UCLInvalidKeyFiledFixup();
    string str = AppInfoManager.AppVersion.Substring(0, 1);
    bool flag = false;
    if (!UndoManager.CanRedo && !UndoManager.CanUndo)
      flag = UndoManager.StopUndoRedo();
    this.DualRadioTrunkingRealtedFieldFixup();
    this.UnregisterHiddenStaicInvalidRecrefFields();
    if (!AppInfoManager.InvalidFieldsReport.UiHasFields && AppInfoManager.InvalidFieldsReport.HasFields && WindowMain.BlockPackOnInvalids.Enabled)
    {
      System.Collections.Generic.List<FieldsReportInfo> fieldsReportInfoList = new System.Collections.Generic.List<FieldsReportInfo>(AppInfoManager.InvalidFieldsReport.Fields);
      this.DualRadioO9NodeFixup();
      foreach (FieldsReportInfo fieldsReportInfo in fieldsReportInfoList)
      {
        if (!str.Equals("R") && !str.Equals("B") || AppInfoManager.AppType == AcpCommonLib.ApplicationType.LABTOOL)
          AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Warning, AppResources.The_following_orphaned_invisible_invalid_field + fieldsReportInfo.Field.Path("\\"));
        if (!fieldsReportInfo.Field.Valid)
        {
          if (fieldsReportInfo.Field.Name == "ZnChanCfgZoneTopDisplayZone_A19772")
          {
            if (fieldsReportInfo.Field is AcpStringField field1)
              field1.SetValue(string.Empty);
          }
          else if (fieldsReportInfo.Field.Name == "ZnChanCfgChannelsTopDisplayChannel_A19774")
          {
            if (fieldsReportInfo.Field is AcpStringField field2)
              field2.SetValue(string.Empty);
          }
          else
            fieldsReportInfo.Field.ResetToDefault();
        }
      }
    }
    if (flag)
      UndoManager.StartUndoRedo();
    if (AppInfoManager.InvalidFieldsReport.UiHasFields)
    {
      resultStatus.ResultMessage = AppResources.The_codeplug_contains_invalid_fields_Please_correct_them_and_try_again;
      if (WindowMain.BlockPackOnInvalids.Enabled)
      {
        AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, resultStatus.ResultMessage);
        resultStatus.Result = true;
        return resultStatus;
      }
      if (!WindowMain.SuppressPackInvalidsPopup.Enabled)
      {
        resultStatus.Result = System.Windows.MessageBox.Show(AppResources.Invalid_fields_found_in_archive, AppResources.Mackinaw_CPS, MessageBoxButton.YesNo, MessageBoxImage.Hand, MessageBoxResult.No) != MessageBoxResult.Yes;
        return resultStatus;
      }
    }
    if (AppInfoManager.InvalidFieldsReport.UiHasFields || !AppInfoManager.InvalidFieldsReport.HasFields || !WindowMain.BlockPackOnInvalids.Enabled)
      return resultStatus;
    resultStatus.ResultMessage = !VersionInfoHelper.IsDFlagExisted(DFlagType.DASTRO) ? AppResources.The_Application_has_encountered_invalid_field_Please_contact_Motorola_Support_for_assistance : AppResources.The_Application_has_encountered_invalid_field_Please_contact_Vertex_Standard_Support_for_assistance;
    AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, resultStatus.ResultMessage);
    resultStatus.Result = true;
    return resultStatus;
  }

  private void DualRadioO9NodeFixup()
  {
    TopFunctionProgrammableButtonListInnerRecset buttonListInnerRecset = (TopFunctionProgrammableButtonListInnerRecset) null;
    BottomFunctionProgrammableButtonInnerRecset buttonInnerRecset = (BottomFunctionProgrammableButtonInnerRecset) null;
    DirectionalButtonsListInnerRecset buttonsListInnerRecset = (DirectionalButtonsListInnerRecset) null;
    ConsolidatedActionBCOListInnerRecset bcoListInnerRecset = (ConsolidatedActionBCOListInnerRecset) null;
    RelayPatternBCOListListInnerRecset listListInnerRecset = (RelayPatternBCOListListInnerRecset) null;
    System.Collections.Generic.List<AcpListField> acpListFieldList = new System.Collections.Generic.List<AcpListField>();
    if (!(FeatureManager.GetFeature(2045)[0] is Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide radioWide) || radioWide.DualRadio.RadWideDualRadioSelection_A42236 == null || radioWide.DualRadio.RadWideDualRadioSelection_A42236.Value == 0)
      return;
    if (FeatureManager.GetFeature(4003) is ControlHeadO9Recset feature)
    {
      buttonListInnerRecset = feature[0][10616].EmbeddedRecset as TopFunctionProgrammableButtonListInnerRecset;
      buttonInnerRecset = feature[0][10618].EmbeddedRecset as BottomFunctionProgrammableButtonInnerRecset;
      buttonsListInnerRecset = feature[0][10609].EmbeddedRecset as DirectionalButtonsListInnerRecset;
      bcoListInnerRecset = feature[0][10622].EmbeddedRecset as ConsolidatedActionBCOListInnerRecset;
      listListInnerRecset = feature[0][10620].EmbeddedRecset as RelayPatternBCOListListInnerRecset;
    }
    if (buttonListInnerRecset == null || buttonInnerRecset == null || buttonsListInnerRecset == null)
      return;
    int count1 = bcoListInnerRecset.Count;
    for (int index = 0; index < count1; ++index)
    {
      ConsolidatedActionBCOListInnerSection listInnerSection = (bcoListInnerRecset[index] as ConsolidatedActionBCOListInner).ConsolidatedActionBCOListInnerSection;
      foreach (TopFunctionProgrammableButtonListInner programmableButtonListInner in (Collection<AcpBusinessLayer.FeatureNode>) buttonListInnerRecset)
      {
        if (programmableButtonListInner.TopFunctionProgrammableButtonListInnerSection.CnvTopFunctionButtonBCO_A36628.Value == listInnerSection.RadErgoControlO9ACBCOListBco_A36666.Value && listInnerSection.ActionConsolidationForRadErgoControlO9ACBCOListIndex_A36668 == null)
        {
          acpListFieldList.Add(programmableButtonListInner.TopFunctionProgrammableButtonListInnerSection.O9CHCnvTopFunctionButtonFeature_A36629);
          break;
        }
      }
      foreach (BottomFunctionProgrammableButtonInner programmableButtonInner in (Collection<AcpBusinessLayer.FeatureNode>) buttonInnerRecset)
      {
        if (programmableButtonInner.BottomFunctionProgrammableButtonInnerSection.CHO9BottomFunctionButtonBCO_A36660.Value == listInnerSection.RadErgoControlO9ACBCOListBco_A36666.Value && listInnerSection.ActionConsolidationForRadErgoControlO9ACBCOListIndex_A36668 == null)
        {
          acpListFieldList.Add(programmableButtonInner.BottomFunctionProgrammableButtonInnerSection.CHO9BottomFunctionButtonFeature_A36664);
          break;
        }
      }
    }
    int count2 = listListInnerRecset.Count;
    for (int index = 0; index < count2; ++index)
    {
      RelayPatternBCOListListInnerSection listInnerSection = (listListInnerRecset[index] as RelayPatternBCOListListInner).RelayPatternBCOListListInnerSection;
      foreach (TopFunctionProgrammableButtonListInner programmableButtonListInner in (Collection<AcpBusinessLayer.FeatureNode>) buttonListInnerRecset)
      {
        if (programmableButtonListInner.TopFunctionProgrammableButtonListInnerSection.CnvTopFunctionButtonBCO_A36628.Value == listInnerSection.RdEgoO9DirLtbarPatternBcoListBco_A36661.Value && listInnerSection.GeneralLightbarPatternInnerSectionForRdEgoO9DirLtbarPatternBcoListIndex_A36707 == null)
        {
          acpListFieldList.Add(programmableButtonListInner.TopFunctionProgrammableButtonListInnerSection.O9CHCnvTopFunctionButtonFeature_A36629);
          break;
        }
      }
      foreach (BottomFunctionProgrammableButtonInner programmableButtonInner in (Collection<AcpBusinessLayer.FeatureNode>) buttonInnerRecset)
      {
        if (programmableButtonInner.BottomFunctionProgrammableButtonInnerSection.CHO9BottomFunctionButtonBCO_A36660.Value == listInnerSection.RdEgoO9DirLtbarPatternBcoListBco_A36661.Value && listInnerSection.GeneralLightbarPatternInnerSectionForRdEgoO9DirLtbarPatternBcoListIndex_A36707 == null)
        {
          acpListFieldList.Add(programmableButtonInner.BottomFunctionProgrammableButtonInnerSection.CHO9BottomFunctionButtonFeature_A36664);
          break;
        }
      }
      foreach (DirectionalButtonsListInner buttonsListInner in (Collection<AcpBusinessLayer.FeatureNode>) buttonsListInnerRecset)
      {
        if (buttonsListInner.DirectionalButtonsListInnerSection.RadErgCtrlHeadO9DirLightBarBCO_A36559.Value == listInnerSection.RdEgoO9DirLtbarPatternBcoListBco_A36661.Value && listInnerSection.GeneralLightbarPatternInnerSectionForRdEgoO9DirLtbarPatternBcoListIndex_A36707 == null)
        {
          acpListFieldList.Add(buttonsListInner.DirectionalButtonsListInnerSection.RadErgCtrlHeadO9DirLightBarFeature_A36597);
          break;
        }
      }
    }
    if (acpListFieldList.Count <= 0)
      return;
    foreach (AcpFieldBase acpFieldBase in acpListFieldList)
      acpFieldBase.ResetToDefault();
  }

  private void DualRadioTrunkingRealtedFieldFixup()
  {
    O7DataButtonInnerRecset buttonInnerRecset1 = (O7DataButtonInnerRecset) null;
    KMButtonInnerRecset buttonInnerRecset2 = (KMButtonInnerRecset) null;
    try
    {
      if (!UtilityMack.IsMobile() || !(FeatureManager.GetFeature(2045)[0] is Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide radioWide) || radioWide.DualRadio.RadWideDualRadioSelection_A42236 == null || radioWide.DualRadio.RadWideDualRadioSelection_A42236.Value == 0)
        return;
      ControlHeadO7Recset feature1 = FeatureManager.GetFeature(4114) as ControlHeadO7Recset;
      KeypadMicAndAccessoriesRecset feature2 = FeatureManager.GetFeature(2128) as KeypadMicAndAccessoriesRecset;
      if (feature1 != null)
        buttonInnerRecset1 = feature1[0][10717].EmbeddedRecset as O7DataButtonInnerRecset;
      if (feature2 != null)
        buttonInnerRecset2 = feature2[0][10231].EmbeddedRecset as KMButtonInnerRecset;
      foreach (IAcpFeatureNode acpFeatureNode in (Collection<AcpBusinessLayer.FeatureNode>) buttonInnerRecset1)
      {
        O7DataButtonInnerSection buttonInnerSection = acpFeatureNode[10713] as O7DataButtonInnerSection;
        AcpListField cnvFeatureA41299 = buttonInnerSection.RadErgCtrlHeadO7DataButtonCnvFeature_A41299;
        AcpListField trkFeatureA41297 = buttonInnerSection.RadErgCtrlHeadO7DataButtonTrkFeature_A41297;
        if (trkFeatureA41297.HiddenStatic && (cnvFeatureA41299.Value == 228 || cnvFeatureA41299.Value == 140) && cnvFeatureA41299.Value != trkFeatureA41297.Value)
          trkFeatureA41297.Value = cnvFeatureA41299.Value;
        if (trkFeatureA41297.HiddenStatic && (trkFeatureA41297.Value == 228 || cnvFeatureA41299.Value == 140) && cnvFeatureA41299.Value != trkFeatureA41297.Value)
          trkFeatureA41297.ResetToDefault();
      }
      foreach (IAcpFeatureNode acpFeatureNode in (Collection<AcpBusinessLayer.FeatureNode>) buttonInnerRecset2)
      {
        KMButtonInnerSection buttonInnerSection = acpFeatureNode[10239] as KMButtonInnerSection;
        AcpListField buttonFeatureA19646 = buttonInnerSection.RadErgoCfgKMConventionalKMButtonFeature_A19646;
        AcpListField buttonFeatureA19746 = buttonInnerSection.RadErgoCfgKMTrunkingKMButtonFeature_A19746;
        if (buttonFeatureA19746.HiddenStatic && (buttonFeatureA19646.Value == 140 || buttonFeatureA19646.Value == 70 || buttonFeatureA19646.Value == 124 || buttonFeatureA19646.Value == 125 || buttonFeatureA19646.Value == 126 || buttonFeatureA19646.Value == 228) && buttonFeatureA19746.Value != buttonFeatureA19646.Value)
          buttonFeatureA19746.Value = buttonFeatureA19646.Value;
        if (buttonFeatureA19746.HiddenStatic && (buttonFeatureA19746.Value == 140 || buttonFeatureA19746.Value == 70 || buttonFeatureA19746.Value == 124 || buttonFeatureA19746.Value == 125 || buttonFeatureA19746.Value == 126 || buttonFeatureA19746.Value == 228) && buttonFeatureA19746.Value != buttonFeatureA19646.Value)
          buttonFeatureA19746.ResetToDefault();
      }
    }
    catch (Exception ex)
    {
    }
  }

  private void UnregisterHiddenStaicInvalidRecrefFields()
  {
    ResponseSelectorListInnerRecset selectorListInnerRecset = (ResponseSelectorListInnerRecset) null;
    DirectionalButtonsListInnerRecset buttonsListInnerRecset = (DirectionalButtonsListInnerRecset) null;
    RelayPatternBCOListListInnerRecset listListInnerRecset = (RelayPatternBCOListListInnerRecset) null;
    try
    {
      if (AppInfoManager.InvalidFieldsReport.HasFields)
      {
        if (FeatureManager.GetFeature(4003) is ControlHeadO9Recset feature)
        {
          selectorListInnerRecset = feature[0][10624].EmbeddedRecset as ResponseSelectorListInnerRecset;
          buttonsListInnerRecset = feature[0][10609].EmbeddedRecset as DirectionalButtonsListInnerRecset;
          listListInnerRecset = feature[0][10620].EmbeddedRecset as RelayPatternBCOListListInnerRecset;
        }
        if (selectorListInnerRecset != null)
        {
          foreach (IAcpFeatureNode acpFeatureNode in (Collection<AcpBusinessLayer.FeatureNode>) selectorListInnerRecset)
          {
            AcpRecRefField pursuitKnobIndexA36685 = (acpFeatureNode[10625] as ResponseSelectorListInnerSection).CHO9PursuitKnobIndex_A36685;
            if (pursuitKnobIndexA36685.HiddenStatic)
            {
              pursuitKnobIndexA36685.SetValue(0);
              AppInfoManager.InvalidFieldsReport.UnregisterFieldInReport((IAcpField) pursuitKnobIndexA36685);
            }
            else
              break;
          }
        }
      }
      if (!UtilityMack.IsMobile() || !AppInfoManager.InvalidFieldsReport.HasFields)
        return;
      if (FeatureManager.GetFeature(2127) is ControlHeadO3Recset feature1 && feature1[0][10234].EmbeddedRecset is Motorola.MackinawCPS.CoreFeatures.ControlHeadO3.DataButtonInnerRecset embeddedRecset)
      {
        foreach (IAcpFeatureNode acpFeatureNode in (Collection<AcpBusinessLayer.FeatureNode>) embeddedRecset)
        {
          Motorola.MackinawCPS.CoreFeatures.ControlHeadO3.DataButtonInnerSection buttonInnerSection = acpFeatureNode[10212] as Motorola.MackinawCPS.CoreFeatures.ControlHeadO3.DataButtonInnerSection;
          AcpListField buttonFeatureA22597 = buttonInnerSection.CntrlHeadO3TrunkingO3DatatButtonFeature_A22597;
          AcpRecRefField buttonTrkIndexA41420 = buttonInnerSection.CHO3DataButtonTrkIndex_A41420;
          if (buttonFeatureA22597.HiddenStatic && !buttonFeatureA22597.Valid)
            buttonFeatureA22597.ResetToDefault();
          if (buttonTrkIndexA41420.HiddenStatic && !buttonTrkIndexA41420.Valid)
            buttonTrkIndexA41420.ResetToDefaultWithUndo();
        }
      }
      if (buttonsListInnerRecset != null)
      {
        foreach (IAcpFeatureNode acpFeatureNode in (Collection<AcpBusinessLayer.FeatureNode>) buttonsListInnerRecset)
        {
          AcpRecRefField lightBarIndexA36601 = (acpFeatureNode[10610] as DirectionalButtonsListInnerSection).RadErgCtrlHeadO9DirLightBarIndex_A36601;
          if (lightBarIndexA36601.HiddenStatic)
          {
            if (!lightBarIndexA36601.Valid)
            {
              lightBarIndexA36601.ResetToDefault();
              AppInfoManager.InvalidFieldsReport.UnregisterFieldInReport((IAcpField) lightBarIndexA36601);
            }
            else
              break;
          }
          else
            break;
        }
      }
      if (listListInnerRecset != null)
      {
        foreach (IAcpFeatureNode acpFeatureNode in (Collection<AcpBusinessLayer.FeatureNode>) listListInnerRecset)
        {
          AcpRecRefField bcoListIndexA36707 = (acpFeatureNode[10621] as RelayPatternBCOListListInnerSection).RdEgoO9DirLtbarPatternBcoListIndex_A36707;
          if (bcoListIndexA36707.HiddenStatic && !bcoListIndexA36707.Valid)
          {
            bcoListIndexA36707.ResetToDefault();
            AppInfoManager.InvalidFieldsReport.UnregisterFieldInReport((IAcpField) bcoListIndexA36707);
          }
        }
      }
      this.UnregisterDefaultProfileFromInvalidFieldReport();
    }
    catch (Exception ex)
    {
    }
  }

  private void UnregisterDefaultProfileFromInvalidFieldReport()
  {
    AcpRecRefField defaultProfileA43136 = FeatureManager.GetFeature(2033)[0] is Motorola.MackinawCPS.CoreFeatures.RadioErgonomicsWide.RadioErgonomicsWide radioErgonomicsWide ? radioErgonomicsWide.LogicalProfileConfiguration?.RadErgoWideLogicalProfileConfigurationDefaultProfile_A43136 : (AcpRecRefField) null;
    if (defaultProfileA43136 == null || !defaultProfileA43136.HiddenStatic || defaultProfileA43136.Valid)
      return;
    defaultProfileA43136.ResetToDefault();
    AppInfoManager.InvalidFieldsReport.UnregisterFieldInReport((IAcpField) defaultProfileA43136);
  }

  private void hideADPKeyData()
  {
    IAcpRecordset feature1 = FeatureManager.GetFeature(2021);
    if (feature1 != null && feature1.Count != 0)
    {
      Motorola.MackinawCPS.CoreFeatures.SecureWide.SecureWide secureWide = feature1[0] as Motorola.MackinawCPS.CoreFeatures.SecureWide.SecureWide;
      if (secureWide.EncryptionKeyList.EmbeddedRecset != null)
      {
        foreach (AcpBusinessLayer.FeatureNode featureNode in (Collection<AcpBusinessLayer.FeatureNode>) secureWide.EncryptionKeyList.EmbeddedRecset)
        {
          EncryptionKeyListInnerSection listInnerSection = (featureNode as EncryptionKeyListInner).EncryptionKeyListInnerSection;
          if (listInnerSection.SecWideMultikeyListSelectableADPKeyData_A9106.Value != listInnerSection.SecWideMultikeyListSelectableADPKeyData_A9106.DefaultValue)
            listInnerSection.SecWideMultikeyListSelectableADPKeyData_A9106.Value = listInnerSection.SecWideMultikeyListSelectableADPKeyData_A9106.DefaultValue;
        }
      }
    }
    IAcpRecordset feature2 = FeatureManager.GetFeature(2055);
    if (feature2 == null || feature2.Count == 0)
      return;
    for (int index = 0; index < feature2.Count; ++index)
    {
      Motorola.MackinawCPS.CoreFeatures.SecureKMFProfile.SecureKMFProfile secureKmfProfile = feature2[index] as Motorola.MackinawCPS.CoreFeatures.SecureKMFProfile.SecureKMFProfile;
      if (secureKmfProfile.SecureHardwareEncryptionIndependentKeyList.EmbeddedRecset != null)
      {
        foreach (AcpBusinessLayer.FeatureNode featureNode in (Collection<AcpBusinessLayer.FeatureNode>) secureKmfProfile.SecureHardwareEncryptionIndependentKeyList.EmbeddedRecset)
        {
          SecureHardwareEncryptionIndependentKeyListInnerSection listInnerSection = (featureNode as SecureHardwareEncryptionIndependentKeyListInner).SecureHardwareEncryptionIndependentKeyListInnerSection;
          if (listInnerSection.SecProfIndependMultikeyListSelectableADPKeyData.Value != listInnerSection.SecProfIndependMultikeyListSelectableADPKeyData.DefaultValue)
            listInnerSection.SecProfIndependMultikeyListSelectableADPKeyData.Value = listInnerSection.SecProfIndependMultikeyListSelectableADPKeyData.DefaultValue;
        }
      }
    }
  }

  private void RefreshPowerLevelForSRX2200()
  {
    if ((FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation).Labtool.RadInfoLabtoolProductModelIdentifier_A37178.Value != 8 || !(FeatureManager.GetFeature(2045)[0] is Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide radioWide) || radioWide.Labtool == null || radioWide.Labtool.RadWideLabtoolUltraLowPowerSoldierMacCapable_A41710 == null)
      return;
    if (radioWide.TransmitPowerLevels != null && radioWide.TransmitPowerLevels.EmbeddedRecset != null)
    {
      for (int index = 0; index < radioWide.TransmitPowerLevels.EmbeddedRecset.Count; ++index)
      {
        if (radioWide.TransmitPowerLevels.EmbeddedRecset[index] is TxPowerLevelsByFrequencyRangeInner frequencyRangeInner && frequencyRangeInner.TxPowerLevelsByFrequencyRangeInnerSection != null && (MTFResources.P_7800_mhz.Trim() == frequencyRangeInner.TxPowerLevelsByFrequencyRangeInnerSection.RadWidePowerLevelBandFrequency_A41063.Value.Trim() || AcgResources.ID_UHF1.Trim() == frequencyRangeInner.TxPowerLevelsByFrequencyRangeInnerSection.RadWidePowerLevelBandFrequency_A41063.Value.Trim() && !radioWide.Labtool.RadWideLabtoolUltraLowPowerSoldierMacCapable_A41710.Value))
          frequencyRangeInner.TxPowerLevelsByFrequencyRangeInnerSection.RadWideTransmitPowerLevelsTrkTxPowerLevelMinimumW_A41174.SetValue(23979);
      }
    }
    if (radioWide.TxPowerLevelsNewBandPlan == null || radioWide.TxPowerLevelsNewBandPlan.EmbeddedRecset == null)
      return;
    for (int index = 0; index < radioWide.TxPowerLevelsNewBandPlan.EmbeddedRecset.Count; ++index)
    {
      if (radioWide.TxPowerLevelsNewBandPlan.EmbeddedRecset[index] is TxPowerLevelsByFrequencyRangeNewBandPlanInner newBandPlanInner && newBandPlanInner.TxPowerLevelsByFrequencyRangeNewBandPlanInnerSection != null && (MTFResources.P_7800_mhz.Trim() == newBandPlanInner.TxPowerLevelsByFrequencyRangeNewBandPlanInnerSection.RadWidePowerLevelBandFrequency_A41864.Value.Trim() || AcgResources.ID_UHF1.Trim() == newBandPlanInner.TxPowerLevelsByFrequencyRangeNewBandPlanInnerSection.RadWidePowerLevelBandFrequency_A41864.Value.Trim() && !radioWide.Labtool.RadWideLabtoolUltraLowPowerSoldierMacCapable_A41710.Value))
        newBandPlanInner.TxPowerLevelsByFrequencyRangeNewBandPlanInnerSection.RadWideTransmitPowerLevelsTrkTxPowerLevelMinimumW_A41862.SetValue(23979);
    }
  }

  private void SetControlHeadAliasList()
  {
    Motorola.MackinawCPS.CoreFeatures.RadioErgonomicsWide.RadioErgonomicsWide radioErgonomicsWide = FeatureManager.GetFeature(2033)[0] as Motorola.MackinawCPS.CoreFeatures.RadioErgonomicsWide.RadioErgonomicsWide;
    ControlHeadAliasListInnerRecset embeddedRecset = radioErgonomicsWide.ControlHead.EmbeddedRecset as ControlHeadAliasListInnerRecset;
    if (radioErgonomicsWide == null || embeddedRecset == null || radioErgonomicsWide.ControlHead.RadErgoWideControlHeadExpectedNumofControlHeads_A7982.HiddenStatic)
      return;
    int num = 0;
    foreach (AcpBusinessLayer.ListItem listItem in (Collection<AcpBusinessLayer.ListItem>) radioErgonomicsWide.ControlHead.RadErgoWideControlHeadExpectedNumofControlHeads_A7982.Items)
    {
      if (listItem.ItemVisibility)
        ++num;
    }
    int count = embeddedRecset.Count;
    while (embeddedRecset.Count < num)
    {
      embeddedRecset.AddDefaultRecord();
      ++count;
      if (!(embeddedRecset[count - 1] is ControlHeadAliasListInner headAliasListInner))
        break;
      switch (count)
      {
        case 1:
          headAliasListInner.ControlHeadAliasListInnerSection.RadErgoWideControlHeadControlHead1Alias_A7718.SetValue(MTFResources.Control_head_1);
          continue;
        case 2:
          headAliasListInner.ControlHeadAliasListInnerSection.RadErgoWideControlHeadControlHead1Alias_A7718.SetValue(MTFResources.Control_head_2);
          continue;
        case 3:
          headAliasListInner.ControlHeadAliasListInnerSection.RadErgoWideControlHeadControlHead1Alias_A7718.SetValue(MTFResources.Control_head_3);
          continue;
        case 4:
          headAliasListInner.ControlHeadAliasListInnerSection.RadErgoWideControlHeadControlHead1Alias_A7718.SetValue(MTFResources.Control_head_4);
          continue;
        default:
          continue;
      }
    }
  }

  private void SetGCAITable()
  {
    IAcpRecordset feature = FeatureManager.GetFeature(2125);
    if (feature == null || feature.Count <= 0 || !(feature[0] is Motorola.MackinawCPS.CoreFeatures.RadioVIPs.RadioVIPs radioViPs) || radioViPs.GCAI == null || radioViPs.GCAI.EmbeddedRecset == null || !(radioViPs.GCAI.EmbeddedRecset is GCAIVIPInnerRecset embeddedRecset) || embeddedRecset.Count >= 2)
      return;
    while (embeddedRecset.Count < 2)
      embeddedRecset.AddDefaultRecord();
    for (int index = 0; index < embeddedRecset.Count; ++index)
    {
      GCAIVIPInner gcaivipInner = embeddedRecset[index] as GCAIVIPInner;
      switch (index)
      {
        case 0:
          gcaivipInner.GCAIVIPInnerSection.RadioGCAIVipName_42622.SetValue(MTFResources.P_1);
          gcaivipInner.GCAIVIPInnerSection.GCAIVipInputBCO_42620.SetValue(224 /*0xE0*/);
          gcaivipInner.GCAIVIPInnerSection.RadioGCAIVIPKey_42621.SetValue(string.Format(AppResources.GCAI_VIP_ID, (object) "1"));
          break;
        case 1:
          gcaivipInner.GCAIVIPInnerSection.RadioGCAIVipName_42622.SetValue(MTFResources.P_2);
          gcaivipInner.GCAIVIPInnerSection.GCAIVipInputBCO_42620.SetValue(225);
          gcaivipInner.GCAIVIPInnerSection.RadioGCAIVIPKey_42621.SetValue(string.Format(AppResources.GCAI_VIP_ID, (object) "2"));
          break;
      }
    }
  }

  private void ResetASTROOTARRadioID()
  {
    if (!(FeatureManager.GetFeature(2021)[0][10042] is ASTROOTAR astrootar))
      return;
    AcpSimpleRangeField astrootarRadioIdA8284 = astrootar.SecWideASTROOTARIndividualASTROOTARRadioID_A8284;
    if (astrootarRadioIdA8284.IsValid(astrootarRadioIdA8284.Parent))
      return;
    astrootarRadioIdA8284.ResetToDefault();
  }

  private void ResetOOBEField()
  {
    if (!(FeatureManager.GetFeature(2045)[0] is Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide radioWide) || !radioWide.Labtool.RadWideLabtoolSeamlessUpdateOutOfBoxExperience.Value)
      return;
    radioWide.Labtool.RadWideLabtoolSeamlessUpdateOutOfBoxExperience.SetValue(false);
  }

  private void updateUnpackedFields(bool isReadingRadio, RadioParams currentRadioParams)
  {
    UndoManager.StopUndoRedo();
    this.SyncQC2Code();
    this.InitTrkPerAnnGroup();
    this.RefreshForTrkSys();
    this.ResetMotionSensitivityDefaultValue();
    this.ResetEmergencyAlarmRetryRateDefaultValue();
    this.RestoreScanZoneChannelWhenCNVTalkGroupIsDVNOrATG();
    this.SetStatusAutoExitToAlwaysAndUpdateConStatusAliasNumber();
    this.SetAudioConfigurationLevelToBasic();
    this.SetAudioSettingGroupSettingValueToCustom();
    this.SyncValueForAccessoryFieldsForAudioEnhancementFeature();
    this.RefreshAudioEnhancementForConsolette();
    this.SetActionTypeAfterUpgrade();
    this.SyncActiveMicForBTPTT();
    this.RefreshPowerLevelForSRX2200();
    this.SetControlHeadAliasList();
    this.SetGCAITable();
    this.RefreshDynChannelName();
    this.RefreshBroadbandFields();
    this.RefreshUserSelectablePL();
    this.RefreshRemoteFreqMonitorOption();
    this.RefreshActionConsolidation();
    this.RefreshToneSignalingList();
    this.FixPassword();
    this.FixRSISiteNumber();
    this.UnpackFixupForFPPProtectedZonePassword();
    this.UnpackFixupForDataWideLTEHWEnable();
    this.UnpackFixupForDataWideLTEDisablementEnable();
    this.UnpackFixupForRadErgoWideAdvancedPowerUpInHazardZoneMode();
    this.UnpackFixupForRadWideBluetoothPairingType();
    this.RefreshAESFields();
    this.SynPreAmp();
    this.SetValueForNewCnvHotMicTxPeriodField();
    this.SetValueForNewTrkHotMicTxPeriodField();
    this.AttemptsAllowedDefaultValueFixUp();
    this.InitCnvEmerProfGeneralTxPeriodsec2_A43600AterUnpack();
    this.InitTrkEmerProfGeneralTxPeriodsec2_A43601AfterUnpack();
    this.InitTrkPerFeaturesPriorityDispatchTimeOutTimer43598AfterUnpack();
    this.UpdateValidityOfAdvancedPowerUpOnLastSelectedZoneAndChannel();
    this.SetValueForWiFiRegulatoryRegion_A43772AfterUnpack();
    this.ResetASTROOTARRadioID();
    this.MPLCloneFixUp();
    this.CnvPerTalkgroupTextListFixup();
    this.RadErgoWideExternalAccEnableFixup();
    UpgradeRadio.SetWindNoiseReductionLevelForAccessories();
    WindowMain.KMButtonConventionalFeatureFixup();
    this.SynchronizePointerValuesForTrunkingPersonality();
    if (UtilityMack.IsMobileOnly())
    {
      DEKRecset feature1 = FeatureManager.GetFeature(2129) as DEKRecset;
      if ((feature1[0][10232] as Motorola.MackinawCPS.CoreFeatures.DEK.General).DEKNumberofDEKBoxes_A8579.Value > 0)
      {
        DEKButtonInnerRecset embeddedRecset1 = feature1[0][10232].EmbeddedRecset as DEKButtonInnerRecset;
        DirectMessageListInnerRecset embeddedRecset2 = feature1[0][10229].EmbeddedRecset as DirectMessageListInnerRecset;
        DirectStatusBCOListInnerRecset embeddedRecset3 = feature1[0][10219].EmbeddedRecset as DirectStatusBCOListInnerRecset;
        DirectModeBCOListInnerRecset embeddedRecset4 = feature1[0][10220].EmbeddedRecset as DirectModeBCOListInnerRecset;
        int count1 = embeddedRecset2.Count;
        for (int index = 0; index < count1; ++index)
        {
          DirectMessageListInnerSection listInnerSection = (embeddedRecset2[index] as DirectMessageListInner).DirectMessageListInnerSection;
          if (listInnerSection.DEKDirectMessageBCO_A8506.Value != 0)
          {
            foreach (DEKButtonInner dekButtonInner in (Collection<AcpBusinessLayer.FeatureNode>) embeddedRecset1)
            {
              if (dekButtonInner.DEKButtonInnerSection.DEKButtonBCO_A21352.Value == listInnerSection.DEKDirectMessageBCO_A8506.Value)
              {
                dekButtonInner.DEKButtonInnerSection.DEKButtonIndex_A22570.SetValue(index + 1);
                break;
              }
            }
          }
        }
        int count2 = embeddedRecset3.Count;
        for (int index = 0; index < count2; ++index)
        {
          DirectStatusBCOListInnerSection listInnerSection = (embeddedRecset3[index] as DirectStatusBCOListInner).DirectStatusBCOListInnerSection;
          if (listInnerSection.DEKDirectStatusBCO_A9196.Value != 0)
          {
            foreach (DEKButtonInner dekButtonInner in (Collection<AcpBusinessLayer.FeatureNode>) embeddedRecset1)
            {
              if (dekButtonInner.DEKButtonInnerSection.DEKButtonBCO_A21352.Value == listInnerSection.DEKDirectStatusBCO_A9196.Value)
              {
                dekButtonInner.DEKButtonInnerSection.DEKButtonIndex_A22570.SetValue(index + 1);
                break;
              }
            }
          }
        }
        int count3 = embeddedRecset4.Count;
        for (int index = 0; index < count3; ++index)
        {
          DirectModeBCOListInnerSection listInnerSection = (embeddedRecset4[index] as DirectModeBCOListInner).DirectModeBCOListInnerSection;
          if (listInnerSection.DEKDirectModeBCO_A8534.Value != 0)
          {
            foreach (DEKButtonInner dekButtonInner in (Collection<AcpBusinessLayer.FeatureNode>) embeddedRecset1)
            {
              if (dekButtonInner.DEKButtonInnerSection.DEKButtonBCO_A21352.Value == listInnerSection.DEKDirectModeBCO_A8534.Value)
              {
                dekButtonInner.DEKButtonInnerSection.DEKZone_A22566.UIValue = listInnerSection.DEKDirectModeZone_A8538.UIValue;
                dekButtonInner.DEKButtonInnerSection.DEKChannel_A22565.UIValue = listInnerSection.DEKDirectModeChannel_A8535.UIValue;
                break;
              }
            }
          }
        }
      }
      ControlHeadO9Recset feature2 = FeatureManager.GetFeature(4003) as ControlHeadO9Recset;
      TopFunctionProgrammableButtonListInnerRecset embeddedRecset5 = feature2[0][10616].EmbeddedRecset as TopFunctionProgrammableButtonListInnerRecset;
      DirectMessageListInnerRecset embeddedRecset6 = feature1[0][10229].EmbeddedRecset as DirectMessageListInnerRecset;
      int count4 = embeddedRecset6.Count;
      for (int index = 0; index < count4; ++index)
      {
        DirectMessageListInnerSection listInnerSection = (embeddedRecset6[index] as DirectMessageListInner).DirectMessageListInnerSection;
        if (listInnerSection.DEKDirectMessageBCO_A8506.Value != 0)
        {
          foreach (TopFunctionProgrammableButtonListInner programmableButtonListInner in (Collection<AcpBusinessLayer.FeatureNode>) embeddedRecset5)
          {
            if (programmableButtonListInner.TopFunctionProgrammableButtonListInnerSection.CnvTopFunctionButtonBCO_A36628.Value == listInnerSection.DEKDirectMessageBCO_A8506.Value)
            {
              programmableButtonListInner.TopFunctionProgrammableButtonListInnerSection.O9CHCnvTopFunctionButtonStsMsgIndex_A36781.SetValue(index + 1);
              programmableButtonListInner.TopFunctionProgrammableButtonListInnerSection.O9CHTrkTopFunctionButtonStsMsgIndex_A36782.SetValue(index + 1);
              break;
            }
          }
        }
      }
      DirectStatusBCOListInnerRecset embeddedRecset7 = feature1[0][10219].EmbeddedRecset as DirectStatusBCOListInnerRecset;
      int count5 = embeddedRecset7.Count;
      for (int index = 0; index < count5; ++index)
      {
        DirectStatusBCOListInnerSection listInnerSection = (embeddedRecset7[index] as DirectStatusBCOListInner).DirectStatusBCOListInnerSection;
        if (listInnerSection.DEKDirectStatusBCO_A9196.Value != 0)
        {
          foreach (TopFunctionProgrammableButtonListInner programmableButtonListInner in (Collection<AcpBusinessLayer.FeatureNode>) embeddedRecset5)
          {
            if (programmableButtonListInner.TopFunctionProgrammableButtonListInnerSection.CnvTopFunctionButtonBCO_A36628.Value == listInnerSection.DEKDirectStatusBCO_A9196.Value)
            {
              programmableButtonListInner.TopFunctionProgrammableButtonListInnerSection.O9CHCnvTopFunctionButtonStsMsgIndex_A36781.SetValue(index + 1);
              programmableButtonListInner.TopFunctionProgrammableButtonListInnerSection.O9CHTrkTopFunctionButtonStsMsgIndex_A36782.SetValue(index + 1);
              break;
            }
          }
        }
      }
      BottomFunctionProgrammableButtonInnerRecset embeddedRecset8 = feature2[0][10618].EmbeddedRecset as BottomFunctionProgrammableButtonInnerRecset;
      IAcpRecordset embeddedRecset9 = feature2[0][10628].EmbeddedRecset;
      O9InnerRecset embeddedRecset10 = feature2[0][10626].EmbeddedRecset as O9InnerRecset;
      O9DataButtonInnerRecset embeddedRecset11 = feature2[0][10611].EmbeddedRecset as O9DataButtonInnerRecset;
      O5InnerRecset embeddedRecset12 = (FeatureManager.GetFeature(2130) as ControlHeadO5Recset)[0][10227].EmbeddedRecset as O5InnerRecset;
      Motorola.MackinawCPS.CoreFeatures.Buttons.DataButtonInnerRecset embeddedRecset13 = (FeatureManager.GetFeature(2042) as ButtonsRecset)[0][10089].EmbeddedRecset as Motorola.MackinawCPS.CoreFeatures.Buttons.DataButtonInnerRecset;
      O9Inner o9Inner = embeddedRecset10[0] as O9Inner;
      O9DataButtonInner o9DataButtonInner = embeddedRecset11[0] as O9DataButtonInner;
      O5Inner o5Inner = embeddedRecset12[0] as O5Inner;
      Motorola.MackinawCPS.CoreFeatures.Buttons.DataButtonInner dataButtonInner = embeddedRecset13[0] as Motorola.MackinawCPS.CoreFeatures.Buttons.DataButtonInner;
      o9Inner.O9InnerSection.CHO9EmergencyButtonFeature_A36682.SetValue(o5Inner.O5InnerSection.CntrlHeadO5SignalIndependentO5M5MXChiefCHButtonButtonFeature_A19754.Value);
      o9DataButtonInner.O9DataButtonInnerSection.RadErgCtrlHeadO9DataButtonCnvFeature_A36528.SetValue(dataButtonInner.DataButtonInnerSection.BtnConventionalButtonDatatButtonFeature_A22610.Value);
      o9DataButtonInner.O9DataButtonInnerSection.RadErgCtrlHeadO9DataButtonTrkFeature_A36526.SetValue(dataButtonInner.DataButtonInnerSection.BtnTrunkingButtonDatatButtonFeature_A22608.Value);
      ConsolidatedActionBCOListInnerRecset embeddedRecset14 = feature2[0][10622].EmbeddedRecset as ConsolidatedActionBCOListInnerRecset;
      System.Collections.Generic.List<string> stringList = new System.Collections.Generic.List<string>();
      System.Collections.Generic.List<AcpBusinessLayer.FeatureNode> featureNodeList = new System.Collections.Generic.List<AcpBusinessLayer.FeatureNode>();
      foreach (ConsolidatedActionBCOListInner actionBcoListInner in (Collection<AcpBusinessLayer.FeatureNode>) embeddedRecset14)
      {
        if (!stringList.Contains(actionBcoListInner.ConsolidatedActionBCOListInnerSection.RadErgoControlO9ACBCOListBco_A36666.UIValue))
          stringList.Add(actionBcoListInner.ConsolidatedActionBCOListInnerSection.RadErgoControlO9ACBCOListBco_A36666.UIValue);
        else
          featureNodeList.Add((AcpBusinessLayer.FeatureNode) actionBcoListInner);
      }
      foreach (AcpBusinessLayer.FeatureNode rec in featureNodeList)
        new DeleteRecordTask(rec).Do();
      foreach (AcpBusinessLayer.FeatureNode featureNode in (Collection<AcpBusinessLayer.FeatureNode>) embeddedRecset14)
      {
        bool flag = false;
        ConsolidatedActionBCOListInnerSection listInnerSection = ((ConsolidatedActionBCOListInner) featureNode).ConsolidatedActionBCOListInnerSection;
        foreach (TopFunctionProgrammableButtonListInner programmableButtonListInner in (Collection<AcpBusinessLayer.FeatureNode>) embeddedRecset5)
        {
          if (programmableButtonListInner.TopFunctionProgrammableButtonListInnerSection.CnvTopFunctionButtonBCO_A36628.Value == listInnerSection.RadErgoControlO9ACBCOListBco_A36666.Value)
          {
            programmableButtonListInner.TopFunctionProgrammableButtonListInnerSection.O9CHCnvTopFunctionButtonIndex_A36634.UIValue = listInnerSection.RadErgoControlO9ACBCOListIndex_A36668.UIValue;
            programmableButtonListInner.TopFunctionProgrammableButtonListInnerSection.O9CHTrkTopFunctionButtonIndex_A36639.SetValue(listInnerSection.RadErgoControlO9ACBCOListIndex_A36668.Value);
            flag = true;
            break;
          }
        }
        if (!flag)
        {
          foreach (BottomFunctionProgrammableButtonInner programmableButtonInner in (Collection<AcpBusinessLayer.FeatureNode>) embeddedRecset8)
          {
            if (programmableButtonInner.BottomFunctionProgrammableButtonInnerSection.CHO9BottomFunctionButtonBCO_A36660.Value == listInnerSection.RadErgoControlO9ACBCOListBco_A36666.Value)
            {
              programmableButtonInner.BottomFunctionProgrammableButtonInnerSection.CHO9BottomFunctionButtonIndex_A36665.UIValue = listInnerSection.RadErgoControlO9ACBCOListIndex_A36668.UIValue;
              flag = true;
              break;
            }
          }
          if (!flag)
          {
            E5BottomFunctionButtonInnerSection buttonInnerSection = (((FeatureManager.GetFeature(4236) as ControlHeadE5Recset)[0][10903].EmbeddedRecset as E5BottomFunctionButtonInnerRecset)[0] as E5BottomFunctionButtonInner).E5BottomFunctionButtonInnerSection;
            if (buttonInnerSection.E5BottomFunctionButtonBCO_43757.Value == listInnerSection.RadErgoControlO9ACBCOListBco_A36666.Value)
            {
              buttonInnerSection.E5BottomFunctionButtonIndex_43759.UIValue = listInnerSection.RadErgoControlO9ACBCOListIndex_A36668.UIValue;
              buttonInnerSection.E5BottomFunctionButtonIndex_43759.CalculateValidity();
            }
          }
        }
      }
      RelayPatternBCOListListInnerRecset embeddedRecset15 = feature2[0][10620].EmbeddedRecset as RelayPatternBCOListListInnerRecset;
      stringList.Clear();
      featureNodeList.Clear();
      foreach (RelayPatternBCOListListInner bcoListListInner in (Collection<AcpBusinessLayer.FeatureNode>) embeddedRecset15)
      {
        if (!stringList.Contains(bcoListListInner.RelayPatternBCOListListInnerSection.RdEgoO9DirLtbarPatternBcoListBco_A36661.UIValue))
          stringList.Add(bcoListListInner.RelayPatternBCOListListInnerSection.RdEgoO9DirLtbarPatternBcoListBco_A36661.UIValue);
        else
          featureNodeList.Add((AcpBusinessLayer.FeatureNode) bcoListListInner);
      }
      foreach (AcpBusinessLayer.FeatureNode rec in featureNodeList)
        new DeleteRecordTask(rec).Do();
      foreach (AcpBusinessLayer.FeatureNode featureNode in (Collection<AcpBusinessLayer.FeatureNode>) embeddedRecset15)
      {
        bool flag = false;
        RelayPatternBCOListListInnerSection listInnerSection = ((RelayPatternBCOListListInner) featureNode).RelayPatternBCOListListInnerSection;
        foreach (TopFunctionProgrammableButtonListInner programmableButtonListInner in (Collection<AcpBusinessLayer.FeatureNode>) embeddedRecset5)
        {
          if (programmableButtonListInner.TopFunctionProgrammableButtonListInnerSection.CnvTopFunctionButtonBCO_A36628.Value == listInnerSection.RdEgoO9DirLtbarPatternBcoListBco_A36661.Value)
          {
            programmableButtonListInner.TopFunctionProgrammableButtonListInnerSection.O9CHCnvTopFunctionButtonIndex_A36634.UIValue = listInnerSection.RdEgoO9DirLtbarPatternBcoListIndex_A36707.UIValue;
            programmableButtonListInner.TopFunctionProgrammableButtonListInnerSection.O9CHTrkTopFunctionButtonIndex_A36639.SetValue(listInnerSection.RdEgoO9DirLtbarPatternBcoListIndex_A36707.Value);
            flag = true;
            break;
          }
        }
        if (!flag)
        {
          foreach (BottomFunctionProgrammableButtonInner programmableButtonInner in (Collection<AcpBusinessLayer.FeatureNode>) embeddedRecset8)
          {
            if (programmableButtonInner.BottomFunctionProgrammableButtonInnerSection.CHO9BottomFunctionButtonBCO_A36660.Value == listInnerSection.RdEgoO9DirLtbarPatternBcoListBco_A36661.Value)
            {
              programmableButtonInner.BottomFunctionProgrammableButtonInnerSection.CHO9BottomFunctionButtonIndex_A36665.UIValue = listInnerSection.RdEgoO9DirLtbarPatternBcoListIndex_A36707.UIValue;
              flag = true;
              break;
            }
          }
          if (!flag)
          {
            foreach (DirectionalButtonsListInner buttonsListInner in (Collection<AcpBusinessLayer.FeatureNode>) (feature2[0][10609].EmbeddedRecset as DirectionalButtonsListInnerRecset))
            {
              if (buttonsListInner.DirectionalButtonsListInnerSection.RadErgCtrlHeadO9DirLightBarBCO_A36559.Value == listInnerSection.RdEgoO9DirLtbarPatternBcoListBco_A36661.Value)
              {
                buttonsListInner.DirectionalButtonsListInnerSection.RadErgCtrlHeadO9DirLightBarIndex_A36601.UIValue = listInnerSection.RdEgoO9DirLtbarPatternBcoListIndex_A36707.UIValue;
                flag = true;
                break;
              }
            }
            if (!flag)
            {
              foreach (KeypadButtonInner keypadButtonInner in (Collection<AcpBusinessLayer.FeatureNode>) ((FeatureManager.GetFeature(4109) as KeypadRecset)[0][10710].EmbeddedRecset as KeypadButtonInnerRecset))
              {
                if (keypadButtonInner.KeypadButtonInnerSection.RadErgCtrlKeypadGeneralKeypadBCO_A41070.Value == listInnerSection.RdEgoO9DirLtbarPatternBcoListBco_A36661.Value)
                {
                  keypadButtonInner.KeypadButtonInnerSection.RadErgCtrlKeypadGeneralKeypadButtonIndex_41415.UIValue = listInnerSection.RdEgoO9DirLtbarPatternBcoListIndex_A36707.UIValue;
                  flag = true;
                  break;
                }
              }
              if (!flag)
              {
                E5BottomFunctionButtonInnerSection buttonInnerSection = (((FeatureManager.GetFeature(4236) as ControlHeadE5Recset)[0][10903].EmbeddedRecset as E5BottomFunctionButtonInnerRecset)[0] as E5BottomFunctionButtonInner).E5BottomFunctionButtonInnerSection;
                if (buttonInnerSection.E5BottomFunctionButtonBCO_43757.Value == listInnerSection.RdEgoO9DirLtbarPatternBcoListBco_A36661.Value)
                  buttonInnerSection.E5BottomFunctionButtonIndex_43759.UIValue = listInnerSection.RdEgoO9DirLtbarPatternBcoListIndex_A36707.UIValue;
              }
            }
          }
        }
      }
      DirectModeBCOListInnerRecset embeddedRecset16 = feature1[0][10220].EmbeddedRecset as DirectModeBCOListInnerRecset;
      int count6 = embeddedRecset16.Count;
      for (int index = 0; index < count6; ++index)
      {
        DirectModeBCOListInnerSection listInnerSection = (embeddedRecset16[index] as DirectModeBCOListInner).DirectModeBCOListInnerSection;
        if (listInnerSection.DEKDirectModeBCO_A8534.Value != 0)
        {
          foreach (TopFunctionProgrammableButtonListInner programmableButtonListInner in (Collection<AcpBusinessLayer.FeatureNode>) embeddedRecset5)
          {
            if (programmableButtonListInner.TopFunctionProgrammableButtonListInnerSection.CnvTopFunctionButtonBCO_A36628.Value == listInnerSection.DEKDirectModeBCO_A8534.Value)
            {
              programmableButtonListInner.TopFunctionProgrammableButtonListInnerSection.TopFunctionBtnCnvZone_A36942.UIValue = listInnerSection.DEKDirectModeZone_A8538.UIValue;
              programmableButtonListInner.TopFunctionProgrammableButtonListInnerSection.TopFunctionBtnCnvChannel_A36943.UIValue = listInnerSection.DEKDirectModeChannel_A8535.UIValue;
              programmableButtonListInner.TopFunctionProgrammableButtonListInnerSection.TopFunctionBtnTrkZone_A36944.UIValue = listInnerSection.DEKDirectModeZone_A8538.UIValue;
              programmableButtonListInner.TopFunctionProgrammableButtonListInnerSection.TopFunctionBtnTrkChannel_A36945.UIValue = listInnerSection.DEKDirectModeChannel_A8535.UIValue;
              break;
            }
          }
        }
      }
    }
    UndoManager.Reset();
    ((MackCPSDocument) ((App) System.Windows.Application.Current).TheDocument).resetDirty();
    Motorola.MackinawCPS.CoreFeatures.Buttons.DataButtonInnerRecset embeddedRecset17 = (FeatureManager.GetFeature(2042) as ButtonsRecset)[0][10089].EmbeddedRecset as Motorola.MackinawCPS.CoreFeatures.Buttons.DataButtonInnerRecset;
    Motorola.MackinawCPS.CoreFeatures.ControlHeadO3.DataButtonInnerRecset embeddedRecset18 = (FeatureManager.GetFeature(2127) as ControlHeadO3Recset)[0][10234].EmbeddedRecset as Motorola.MackinawCPS.CoreFeatures.ControlHeadO3.DataButtonInnerRecset;
    Motorola.MackinawCPS.CoreFeatures.KeypadMicAndAccessories.DataButtonInnerRecset embeddedRecset19 = (FeatureManager.GetFeature(2128) as KeypadMicAndAccessoriesRecset)[0][10228].EmbeddedRecset as Motorola.MackinawCPS.CoreFeatures.KeypadMicAndAccessories.DataButtonInnerRecset;
    Motorola.MackinawCPS.CoreFeatures.Buttons.DataButtonInnerSection buttonInnerSection1 = embeddedRecset17[0][10090] as Motorola.MackinawCPS.CoreFeatures.Buttons.DataButtonInnerSection;
    Motorola.MackinawCPS.CoreFeatures.ControlHeadO3.DataButtonInnerSection buttonInnerSection2 = embeddedRecset18[0][10212] as Motorola.MackinawCPS.CoreFeatures.ControlHeadO3.DataButtonInnerSection;
    Motorola.MackinawCPS.CoreFeatures.KeypadMicAndAccessories.DataButtonInnerSection buttonInnerSection3 = embeddedRecset19[0][10209] as Motorola.MackinawCPS.CoreFeatures.KeypadMicAndAccessories.DataButtonInnerSection;
    buttonInnerSection2.CntrlHeadO3ConventionalO3DatatButtonFeature_A22595.SetValue(buttonInnerSection1.BtnConventionalButtonDatatButtonFeature_A22610.Value);
    buttonInnerSection2.CntrlHeadO3TrunkingO3DatatButtonFeature_A22597.SetValue(buttonInnerSection1.BtnTrunkingButtonDatatButtonFeature_A22608.Value);
    buttonInnerSection3.RadErgoCfgKMConventionalKMDatatButtonFeature_A22603.SetValue(buttonInnerSection1.BtnConventionalButtonDatatButtonFeature_A22610.Value);
    buttonInnerSection3.RadErgoCfgKMTrunkingKMDatatButtonFeature_A22605.SetValue(buttonInnerSection1.BtnTrunkingButtonDatatButtonFeature_A22608.Value);
    WindowMain.UnpackMPLListRecordsFixUp(FeatureManager.GetFeature(2078));
    IAcpRecordset feature3 = FeatureManager.GetFeature(2059);
    if (feature3 != null && feature3.Count != 0)
    {
      foreach (AcpBusinessLayer.FeatureNode featureNode1 in (Collection<AcpBusinessLayer.FeatureNode>) feature3)
      {
        foreach (AcpBusinessLayer.FeatureNode featureNode2 in (Collection<AcpBusinessLayer.FeatureNode>) (featureNode1 as Motorola.MackinawCPS.CoreFeatures.ConventionalPersonality.ConventionalPersonality).FrequencyOptions.EmbeddedRecset)
        {
          FrequencyOptionsInnerSection optionsInnerSection = (featureNode2 as FrequencyOptionsInner).FrequencyOptionsInnerSection;
          optionsInnerSection.CnvPerConventionalChannelOptionsTAPLFreq_A9264.SetValue(optionsInnerSection.CnvPerConventionalChannelOptionsTAPLCode_A9261.Value);
          optionsInnerSection.CnvPerConventionalChannelOptionsRxPLFreq_A8918.SetValue(optionsInnerSection.CnvPerConventionalChannelOptionsRxPLCode_A8917.Value);
          optionsInnerSection.CnvPerConventionalChannelOptionsTxPLFreq_A9419.SetValue(optionsInnerSection.CnvPerConventionalChannelOptionsTxPLCode_A9418.Value);
        }
      }
    }
    IAcpRecordset feature4 = FeatureManager.GetFeature(4109);
    KeypadButtonInnerRecset embeddedRecset20 = (feature4 as KeypadRecset)[0][10710].EmbeddedRecset as KeypadButtonInnerRecset;
    if (feature4 != null && feature4.Count != 0)
    {
      SignalIndependentProductIndependentProgrammableButtonListInnerRecset embeddedRecset21 = (FeatureManager.GetFeature(2013) as ShepherdsRecset)[0][10029].EmbeddedRecset as SignalIndependentProductIndependentProgrammableButtonListInnerRecset;
      for (int index = 0; index < embeddedRecset20.Count; ++index)
      {
        AcpListField buttonFeatureA41071 = (embeddedRecset20[index] as KeypadButtonInner).KeypadButtonInnerSection.RadErgCtrlKeypadGeneralKeypadButtonFeature_A41071;
        foreach (SignalIndependentProductIndependentProgrammableButtonListInner programmableButtonListInner in (Collection<AcpBusinessLayer.FeatureNode>) embeddedRecset21)
        {
          if ((embeddedRecset20[index] as KeypadButtonInner).KeypadButtonInnerSection.RadErgCtrlKeypadGeneralKeypadBCO_A41070.Value == programmableButtonListInner.SignalIndependentProductIndependentProgrammableButtonListInnerSection.RadErgoCfgSignalIndependentProductIndependentProgrammableButtonBCO_A19757.Value)
          {
            buttonFeatureA41071.SetValue(programmableButtonListInner.SignalIndependentProductIndependentProgrammableButtonListInnerSection.RadErgoCfgSignalIndependentProductIndependentProgrammableButtonFeature_A19758.Value);
            break;
          }
        }
      }
    }
    IAcpRecordset feature5 = FeatureManager.GetFeature(2038);
    if (feature5 != null && feature5.Count != 0 && this.IsPortableModel)
    {
      Motorola.MackinawCPS.CoreFeatures.Switches.Switches switches = feature5[0] as Motorola.MackinawCPS.CoreFeatures.Switches.Switches;
      if (switches.ConventionalSwitchTable.EmbeddedRecset != null)
      {
        ConventionalSwitchTableInner switchTableInner1 = switches.ConventionalSwitchTable.EmbeddedRecset[0] as ConventionalSwitchTableInner;
        switches.ConventionalSwitches.SwitchConventionalSwitchesPosition1_A7734.SetValue(switchTableInner1.ConventionalSwitchTableInnerSection.SwitchConventionalSwitchTablePosition1Feature_A19655.Value);
        switches.ConventionalSwitches.SwitchConventionalSwitchesPosition2_A7735.SetValue(switchTableInner1.ConventionalSwitchTableInnerSection.SwitchConventionalSwitchTablePosition2Feature_A19656.Value);
        ConventionalSwitchTableInner switchTableInner2 = switches.ConventionalSwitchTable.EmbeddedRecset[3] as ConventionalSwitchTableInner;
        switches.ConventionalSwitches.SwitchConventionalSwitchesPosition3_A7737.SetValue(switchTableInner2.ConventionalSwitchTableInnerSection.SwitchConventionalSwitchTablePosition1Feature_A19655.Value);
        switches.ConventionalSwitches.SwitchConventionalSwitchesPosition4_A21530.SetValue(switchTableInner2.ConventionalSwitchTableInnerSection.SwitchConventionalSwitchTablePosition2Feature_A19656.Value);
        switches.ConventionalSwitches.SwitchConventionalSwitchesPosition5_A21531.SetValue(switchTableInner2.ConventionalSwitchTableInnerSection.SwitchConventionalSwitchTablePosition3Feature_A19657.Value);
        TrunkingSwitchTableInner switchTableInner3 = switches.TrunkingSwitchTable.EmbeddedRecset[0] as TrunkingSwitchTableInner;
        switches.TrunkingSwitches.SwitchTrunkingSwitchesPosition1_A9466.SetValue(switchTableInner3.TrunkingSwitchTableInnerSection.SwitchTrunkingSwitchTablePosition1Feature_A21004.Value);
        switches.TrunkingSwitches.SwitchTrunkingSwitchesPosition2_A9467.SetValue(switchTableInner3.TrunkingSwitchTableInnerSection.SwitchTrunkingSwitchTablePosition2Feature_A21005.Value);
        TrunkingSwitchTableInner switchTableInner4 = switches.TrunkingSwitchTable.EmbeddedRecset[3] as TrunkingSwitchTableInner;
        switches.TrunkingSwitches.SwitchTrunkingSwitchesPosition3_A9468.SetValue(switchTableInner4.TrunkingSwitchTableInnerSection.SwitchTrunkingSwitchTablePosition1Feature_A21004.Value);
        switches.TrunkingSwitches.SwitchTrunkingSwitchesPosition4_A21534.SetValue(switchTableInner4.TrunkingSwitchTableInnerSection.SwitchTrunkingSwitchTablePosition2Feature_A21005.Value);
        switches.TrunkingSwitches.SwitchTrunkingSwitchesPosition5_A21535.SetValue(switchTableInner4.TrunkingSwitchTableInnerSection.SwitchTrunkingSwitchTablePosition3Feature_A21006.Value);
      }
    }
    IAcpRecordset feature6 = FeatureManager.GetFeature(2045);
    IAcpRecordset feature7 = FeatureManager.GetFeature(2038);
    IAcpRecordset feature8 = FeatureManager.GetFeature(2033);
    if (feature7 != null && feature7.Count != 0 && this.IsMobileModel)
    {
      Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide radioWide = feature6[0] as Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide;
      Motorola.MackinawCPS.CoreFeatures.Switches.Switches switches = feature7[0] as Motorola.MackinawCPS.CoreFeatures.Switches.Switches;
      Motorola.MackinawCPS.CoreFeatures.RadioErgonomicsWide.RadioErgonomicsWide radioErgonomicsWide = feature8[0] as Motorola.MackinawCPS.CoreFeatures.RadioErgonomicsWide.RadioErgonomicsWide;
      if (switches.ConventionalSwitchTable.EmbeddedRecset != null)
      {
        ConventionalSwitchTableInner switchTableInner5 = switches.ConventionalSwitchTable.EmbeddedRecset[0] as ConventionalSwitchTableInner;
        radioWide.Features.SwitchConventionalSwitchesPosition1_A12643.SetValue(switchTableInner5.ConventionalSwitchTableInnerSection.SwitchConventionalSwitchTablePosition1Feature_A19655.Value);
        if (this.IsMobileModel && switches.TrunkingSwitchTable.EmbeddedRecset.Count >= 3)
        {
          ConventionalSwitchTableInner switchTableInner6 = switches.ConventionalSwitchTable.EmbeddedRecset[2] as ConventionalSwitchTableInner;
          if (switchTableInner6.ConventionalSwitchTableInnerSection.SwitchConventionalSwitchTablePosition1Feature_A19655.Value == 42 && switchTableInner6.ConventionalSwitchTableInnerSection.SwitchConventionalSwitchTablePosition2Feature_A19656.Value == 38 && switchTableInner6.ConventionalSwitchTableInnerSection.SwitchConventionalSwitchTablePosition3Feature_A19657.Value == 38)
            radioErgonomicsWide.Advanced.RadErgoWideAdvancedLogicalSwitch2_A7756.SetValue(0);
          else if (switchTableInner6.ConventionalSwitchTableInnerSection.SwitchConventionalSwitchTablePosition1Feature_A19655.Value == 38 && switchTableInner6.ConventionalSwitchTableInnerSection.SwitchConventionalSwitchTablePosition2Feature_A19656.Value == 42 && switchTableInner6.ConventionalSwitchTableInnerSection.SwitchConventionalSwitchTablePosition3Feature_A19657.Value == 38)
            radioErgonomicsWide.Advanced.RadErgoWideAdvancedLogicalSwitch2_A7756.SetValue(1);
          else if (switchTableInner6.ConventionalSwitchTableInnerSection.SwitchConventionalSwitchTablePosition1Feature_A19655.Value == 38 && switchTableInner6.ConventionalSwitchTableInnerSection.SwitchConventionalSwitchTablePosition2Feature_A19656.Value == 38 && switchTableInner6.ConventionalSwitchTableInnerSection.SwitchConventionalSwitchTablePosition3Feature_A19657.Value == 38)
            radioErgonomicsWide.Advanced.RadErgoWideAdvancedLogicalSwitch2_A7756.SetValue(2);
        }
      }
      if (switches.TrunkingSwitchTable.EmbeddedRecset != null)
      {
        TrunkingSwitchTableInner switchTableInner7 = switches.TrunkingSwitchTable.EmbeddedRecset[0] as TrunkingSwitchTableInner;
        radioWide.Features.SwitchConventionalSwitchesPosition1_A12643.SetValue(switchTableInner7.TrunkingSwitchTableInnerSection.SwitchTrunkingSwitchTablePosition1Feature_A21004.Value);
        if (this.IsMobileModel && switches.TrunkingSwitchTable.EmbeddedRecset.Count >= 3)
        {
          TrunkingSwitchTableInner switchTableInner8 = switches.TrunkingSwitchTable.EmbeddedRecset[2] as TrunkingSwitchTableInner;
          if (switchTableInner8.TrunkingSwitchTableInnerSection.SwitchTrunkingSwitchTablePosition1Feature_A21004.Value == 42 && switchTableInner8.TrunkingSwitchTableInnerSection.SwitchTrunkingSwitchTablePosition2Feature_A21005.Value == 38 && switchTableInner8.TrunkingSwitchTableInnerSection.SwitchTrunkingSwitchTablePosition3Feature_A21006.Value == 38)
            radioErgonomicsWide.Advanced.RadErgoWideAdvancedLogicalSwitch2_A7756.SetValue(0);
          else if (switchTableInner8.TrunkingSwitchTableInnerSection.SwitchTrunkingSwitchTablePosition1Feature_A21004.Value == 38 && switchTableInner8.TrunkingSwitchTableInnerSection.SwitchTrunkingSwitchTablePosition2Feature_A21005.Value == 42 && switchTableInner8.TrunkingSwitchTableInnerSection.SwitchTrunkingSwitchTablePosition3Feature_A21006.Value == 38)
            radioErgonomicsWide.Advanced.RadErgoWideAdvancedLogicalSwitch2_A7756.SetValue(1);
          else if (switchTableInner8.TrunkingSwitchTableInnerSection.SwitchTrunkingSwitchTablePosition1Feature_A21004.Value == 38 && switchTableInner8.TrunkingSwitchTableInnerSection.SwitchTrunkingSwitchTablePosition2Feature_A21005.Value == 38 && switchTableInner8.TrunkingSwitchTableInnerSection.SwitchTrunkingSwitchTablePosition3Feature_A21006.Value == 38)
            radioErgonomicsWide.Advanced.RadErgoWideAdvancedLogicalSwitch2_A7756.SetValue(2);
        }
      }
    }
    IAcpRecordset feature9 = FeatureManager.GetFeature(2064);
    if (feature9 != null && feature9.Count != 0)
    {
      foreach (AcpBusinessLayer.FeatureNode featureNode in (Collection<AcpBusinessLayer.FeatureNode>) feature9)
      {
        Motorola.MackinawCPS.CoreFeatures.TrunkingSystem.TrunkingSystem trunkingSystem = featureNode as Motorola.MackinawCPS.CoreFeatures.TrunkingSystem.TrunkingSystem;
        trunkingSystem.General.TrkSysLabtoolNetworkID_A8565.SetValue(trunkingSystem.General.TrkSysGeneralSystemType_A9252.Value != 3 ? ((trunkingSystem.General.TrkSysGeneralSystemID_A9239.Value & (int) byte.MaxValue) << 4) + trunkingSystem.General.TrkSysGeneralConnectToneHz_A7710.Value : 0);
      }
    }
    IAcpRecordset feature10 = FeatureManager.GetFeature(4174);
    if (feature10 != null && feature10.Count != 0)
    {
      foreach (AcpBusinessLayer.FeatureNode featureNode in (Collection<AcpBusinessLayer.FeatureNode>) feature10)
      {
        Motorola.MackinawCPS.CoreFeatures.MissionCriticalGeofence.MissionCriticalGeofence criticalGeofence = featureNode as Motorola.MackinawCPS.CoreFeatures.MissionCriticalGeofence.MissionCriticalGeofence;
        if (criticalGeofence.General.McGeofencePriority_42879.Valid)
        {
          criticalGeofence.General.McGeofencePriority_42879.CalculateApplicability();
          criticalGeofence.General.McGeofencePriority_42879.CalculateValidity();
        }
      }
    }
    IAcpRecordset feature11 = FeatureManager.GetFeature(2055);
    if (feature11 != null && feature11.Count != 0)
    {
      Motorola.MackinawCPS.CoreFeatures.SecureWide.SecureWide secureWide = FeatureManager.GetFeature(2021)[0] as Motorola.MackinawCPS.CoreFeatures.SecureWide.SecureWide;
      foreach (Motorola.MackinawCPS.CoreFeatures.SecureKMFProfile.SecureKMFProfile secureKmfProfile in (Collection<AcpBusinessLayer.FeatureNode>) (feature11 as SecureKMFProfileRecset))
      {
        if (!secureKmfProfile.General.SecKmfProfGenIndependentKeyList_43597.Value)
        {
          int newValue = secureKmfProfile.ASTROOTARInformation.SecKmfProfASTROOTARInformationIndividualASTROOTARRadioID_A8285.Value;
          secureWide.ASTROOTAR.SecWideASTROOTARIndividualASTROOTARRadioID_A8284.SetValue(newValue);
          break;
        }
      }
    }
    this.InitFCCNarrowBandSplit();
    IAcpRecordset feature12 = FeatureManager.GetFeature(2021);
    if (feature12 != null && feature12.Count != 0)
    {
      Motorola.MackinawCPS.CoreFeatures.SecureWide.SecureWide secureWide = feature12[0] as Motorola.MackinawCPS.CoreFeatures.SecureWide.SecureWide;
      if (secureWide.EncryptionKeyList.EmbeddedRecset != null)
      {
        int newValue = -1;
        foreach (AcpBusinessLayer.FeatureNode featureNode in (Collection<AcpBusinessLayer.FeatureNode>) secureWide.EncryptionKeyList.EmbeddedRecset)
        {
          EncryptionKeyListInnerSection listInnerSection = (featureNode as EncryptionKeyListInner).EncryptionKeyListInnerSection;
          if (newValue < 15)
          {
            if (listInnerSection.SecWideMultikeyListIndexed_A8282.Value)
            {
              int num;
              listInnerSection.SecWideMultikeyListSlotA_A9155.SetValue(num = newValue + 1);
              listInnerSection.SecWideMultikeyListSlotB_A9158.SetValue(newValue = num + 1);
            }
            else
            {
              ++newValue;
              listInnerSection.SecWideMultikeyListSlotA_A9155.SetValue(newValue);
              listInnerSection.SecWideMultikeyListSlotB_A9158.SetValue(newValue);
            }
          }
          else
          {
            listInnerSection.SecWideMultikeyListSlotA_A9155.SetValue(1);
            listInnerSection.SecWideMultikeyListSlotB_A9158.SetValue(1);
          }
        }
      }
    }
    if (UtilityMack.IsPortablePro && FeatureManager.GetFeature(2010)[0] is Motorola.MackinawCPS.CoreFeatures.DisplayAndMenu.DisplayAndMenu displayAndMenu)
    {
      IAcpRecordset embeddedRecset22 = displayAndMenu.BacklightColorControl.EmbeddedRecset;
      int num = 0;
      foreach (AcpBusinessLayer.FeatureNode featureNode in (Collection<AcpBusinessLayer.FeatureNode>) embeddedRecset22)
      {
        ++num;
        if (featureNode is BacklightColorsInner backlightColorsInner && backlightColorsInner.BacklightColorsInnerSection.DispMenuLabtoolColorText1_A7689.Value.Length > 14)
          backlightColorsInner.BacklightColorsInnerSection.DispMenuLabtoolColorText1_A7689.Value = AppResources.Color_Id + num.ToString();
      }
    }
    this.CombinePinPartsToPinPassword(isReadingRadio, currentRadioParams);
    this.ChangeLegacyDINCFieldsFromLowerToUpperCase();
    this.RemoveTheRecordOfCallAlertIDDisplay();
    IAcpRecordset feature13 = (IAcpRecordset) (FeatureManager.GetFeature(2200) as UclContactRecset);
    if (feature13.Count != 0 && feature13 != null)
    {
      for (int index1 = 0; index1 < feature13.Count; ++index1)
      {
        UclContact uclContact = feature13[index1] as UclContact;
        if (uclContact.PhoneCallList.HasEmbeddedRecset)
        {
          AcpBusinessLayer.Recordset embeddedRecset23 = (AcpBusinessLayer.Recordset) (uclContact.PhoneCallList.EmbeddedRecset as PhoneCallListRecset);
          if (embeddedRecset23.Count != 0 && embeddedRecset23 != null)
          {
            for (int index2 = 0; index2 < embeddedRecset23.Count; ++index2)
            {
              PhoneCallList phoneCallList = embeddedRecset23[index2] as PhoneCallList;
              if (phoneCallList.CallListPhone.UclPhone_PhoneNumber_A00033Value == "")
                phoneCallList.CallListPhone.UclPhone_PhoneNumber_A00033Value = "F";
            }
          }
        }
      }
    }
    this.SynO2O7MFK();
    this.UpdateControlHeadEmergencyBtns();
    this.SyncDataButton();
    this.SyncO2O3O7O5O9NavigationControls();
    Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation radioInformation = FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation;
    string codeplugVersionA7683 = (string) radioInformation.General.RadInfoGeneralCodeplugVersion_A7683;
    bool dispatchA38638Value = radioInformation.Labtool.RadInfoLabtoolExtendedDispatch_A38638Value;
    int num1 = int.Parse(codeplugVersionA7683.Substring(1, 2));
    ConventionalSystemRecset feature14 = FeatureManager.GetFeature(2053) as ConventionalSystemRecset;
    if (num1 < 9)
    {
      foreach (Motorola.MackinawCPS.CoreFeatures.ConventionalSystem.ConventionalSystem conventionalSystem in (Collection<AcpBusinessLayer.FeatureNode>) feature14)
      {
        if (dispatchA38638Value)
        {
          if (conventionalSystem.Features.CnvSysFeaturesExtendedDispatchEn_A37220.Value)
            conventionalSystem.Features.CnvSysFeaturesEmergencyAckEn_A41546.SetValue(true);
          else
            conventionalSystem.Features.CnvSysFeaturesEmergencyAckEn_A41546.SetValue(false);
        }
        else
          conventionalSystem.Features.CnvSysFeaturesEmergencyAckEn_A41546.SetValue(false);
      }
    }
    if (FeatureManager.GetFeature(2054) is DataProfilesRecset feature15 && this.CodeplugVersion.Major < 9)
    {
      foreach (Motorola.MackinawCPS.CoreFeatures.DataProfiles.DataProfiles dataProfiles in (Collection<AcpBusinessLayer.FeatureNode>) feature15)
      {
        if (dataProfiles.General.DataProfGeneralDataProfileType_A21320.Value == 0 && dataProfiles.General.DataProfGeneralPacketDataMode_A8689.Value == 0 && dataProfiles.Features.DataProfFeaturesARSMode_A7465.Value == 3)
          dataProfiles.Features.DataProfFeaturesARSMode_A7465.SetValue(0);
      }
    }
    if (FeatureManager.GetFeature(2059) is ConventionalPersonalityRecset feature16)
    {
      foreach (AcpBusinessLayer.FeatureNode featureNode in (Collection<AcpBusinessLayer.FeatureNode>) feature16)
      {
        if (featureNode is Motorola.MackinawCPS.CoreFeatures.ConventionalPersonality.ConventionalPersonality conventionalPersonality && conventionalPersonality.Secure.CnvPerSecureOTARTx_A8675.HiddenStatic && conventionalPersonality.Secure.CnvPerSecureOTARTx_A8675.Value)
          conventionalPersonality.Secure.CnvPerSecureOTARTx_A8675.SetValue(false);
      }
    }
    this.UpdatePaddingSpacesForSoftIDUsername();
    this.ConsolidatedActionBCOTableInit();
    if (UtilityMack.IsMobileOnly())
    {
      foreach (AcpBusinessLayer.FeatureNode featureNode in (Collection<AcpBusinessLayer.FeatureNode>) (FeatureManager.GetFeature(4008) as ActionConsolidationRecset))
      {
        ConsolidatedActionsInnerRecset embeddedRecset24 = ((Motorola.MackinawCPS.CoreFeatures.ActionConsolidation.ActionConsolidation) featureNode).General.EmbeddedRecset as ConsolidatedActionsInnerRecset;
        if (embeddedRecset24.Count != 0)
        {
          if (embeddedRecset24.ParentSection != null)
          {
            AcpFieldX<bool, string> actionAllowedA36579 = ((Motorola.MackinawCPS.CoreFeatures.ActionConsolidation.ActionConsolidation) featureNode).General.RadioErgoConfigACGeneralActionAllowed_A36579;
            bool flag = false;
            int num2 = 0;
            foreach (IAcpFeatureNode acpFeatureNode in (Collection<AcpBusinessLayer.FeatureNode>) embeddedRecset24)
            {
              if ((acpFeatureNode[10614] as ConsolidatedActionsInnerSection).RadioErgoConfigACActionID_A36590.Value == 74)
              {
                actionAllowedA36579.Value = false;
                flag = true;
                break;
              }
              if ((acpFeatureNode[10614] as ConsolidatedActionsInnerSection).RadioErgoConfigACActionID_A36590.Value == 75)
                ++num2;
            }
            if (!flag & num2 <= 1)
              actionAllowedA36579.Value = true;
            else
              actionAllowedA36579.Value = false;
          }
        }
        else
          (embeddedRecset24.ParentSection.Parent as Motorola.MackinawCPS.CoreFeatures.ActionConsolidation.ActionConsolidation).General.RadioErgoConfigACGeneralActionAllowed_A36579.Value = true;
      }
      if ((FeatureManager.GetFeature(2127) as ControlHeadO3Recset)[0][10234].EmbeddedRecset is Motorola.MackinawCPS.CoreFeatures.ControlHeadO3.DataButtonInnerRecset embeddedRecset25)
      {
        foreach (AcpBusinessLayer.FeatureNode featureNode in (Collection<AcpBusinessLayer.FeatureNode>) embeddedRecset25)
        {
          (featureNode[10212] as Motorola.MackinawCPS.CoreFeatures.ControlHeadO3.DataButtonInnerSection).CHO3DataButtonConvIndex_A41419.CalculateApplicability();
          (featureNode[10212] as Motorola.MackinawCPS.CoreFeatures.ControlHeadO3.DataButtonInnerSection).CHO3DataButtonConvIndex_A41419.CalculateValidity();
          (featureNode[10212] as Motorola.MackinawCPS.CoreFeatures.ControlHeadO3.DataButtonInnerSection).CHO3DataButtonTrkIndex_A41420.CalculateApplicability();
          (featureNode[10212] as Motorola.MackinawCPS.CoreFeatures.ControlHeadO3.DataButtonInnerSection).CHO3DataButtonTrkIndex_A41420.CalculateValidity();
        }
      }
      if ((FeatureManager.GetFeature(4114) as ControlHeadO7Recset)[0][10717].EmbeddedRecset is O7DataButtonInnerRecset embeddedRecset26)
      {
        foreach (AcpBusinessLayer.FeatureNode featureNode in (Collection<AcpBusinessLayer.FeatureNode>) embeddedRecset26)
        {
          (featureNode[10713] as O7DataButtonInnerSection).CHO7DataButtonConvIndex_A41417.CalculateApplicability();
          (featureNode[10713] as O7DataButtonInnerSection).CHO7DataButtonConvIndex_A41417.CalculateValidity();
          (featureNode[10713] as O7DataButtonInnerSection).CHO7DataButtonTrkIndex_A41418.CalculateApplicability();
          (featureNode[10713] as O7DataButtonInnerSection).CHO7DataButtonTrkIndex_A41418.CalculateValidity();
        }
      }
      ControlHeadO9Recset feature17 = FeatureManager.GetFeature(4003) as ControlHeadO9Recset;
      ResponseSelectorListInnerRecset embeddedRecset27 = feature17[0][10624].EmbeddedRecset as ResponseSelectorListInnerRecset;
      O9DataButtonInnerRecset embeddedRecset28 = feature17[0][10611].EmbeddedRecset as O9DataButtonInnerRecset;
      if (embeddedRecset27 != null)
      {
        foreach (AcpBusinessLayer.FeatureNode featureNode in (Collection<AcpBusinessLayer.FeatureNode>) embeddedRecset27)
        {
          (featureNode[10625] as ResponseSelectorListInnerSection).CHO9PursuitKnobIndex_A36685.CalculateApplicability();
          (featureNode[10625] as ResponseSelectorListInnerSection).CHO9PursuitKnobIndex_A36685.CalculateValidity();
        }
      }
      if (embeddedRecset28 != null)
      {
        foreach (AcpBusinessLayer.FeatureNode featureNode in (Collection<AcpBusinessLayer.FeatureNode>) embeddedRecset28)
        {
          (featureNode[10608] as O9DataButtonInnerSection).CHO9DataButtonConvIndex_A41414.CalculateApplicability();
          (featureNode[10608] as O9DataButtonInnerSection).CHO9DataButtonConvIndex_A41414.CalculateValidity();
          (featureNode[10608] as O9DataButtonInnerSection).CHO9DataButtonTrkIndex_A41416.CalculateApplicability();
          (featureNode[10608] as O9DataButtonInnerSection).CHO9DataButtonTrkIndex_A41416.CalculateValidity();
        }
      }
      if ((FeatureManager.GetFeature(2128) as KeypadMicAndAccessoriesRecset)[0][10228].EmbeddedRecset is Motorola.MackinawCPS.CoreFeatures.KeypadMicAndAccessories.DataButtonInnerRecset embeddedRecset29)
      {
        foreach (AcpBusinessLayer.FeatureNode featureNode in (Collection<AcpBusinessLayer.FeatureNode>) embeddedRecset29)
        {
          (featureNode[10209] as Motorola.MackinawCPS.CoreFeatures.KeypadMicAndAccessories.DataButtonInnerSection).RadErgoCfgKMConventionalKMDatatButtonIndex_A41423.CalculateApplicability();
          (featureNode[10209] as Motorola.MackinawCPS.CoreFeatures.KeypadMicAndAccessories.DataButtonInnerSection).RadErgoCfgKMConventionalKMDatatButtonIndex_A41423.CalculateValidity();
          (featureNode[10209] as Motorola.MackinawCPS.CoreFeatures.KeypadMicAndAccessories.DataButtonInnerSection).RadErgoCfgKMTrunkingKMDatatButtonIndex_A41424.CalculateApplicability();
          (featureNode[10209] as Motorola.MackinawCPS.CoreFeatures.KeypadMicAndAccessories.DataButtonInnerSection).RadErgoCfgKMTrunkingKMDatatButtonIndex_A41424.CalculateValidity();
        }
      }
    }
    this.RefreshMaxChangeRecords();
    this.SetInitialKMFProfileRecsetMaxSize();
    if (UtilityMack.IsMobile())
    {
      bool flag = false;
      if (FeatureManager.GetFeature(2045)[0] is Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide radioWide && radioWide.Labtool.RadWideLabtoolMFKEmergencyAccess_A42216 != null)
        flag = radioWide.Labtool.RadWideLabtoolMFKEmergencyAccess_A42216.Value;
      AcpListField acpListField1 = (AcpListField) null;
      AcpListField acpListField2 = (AcpListField) null;
      if (FeatureManager.GetFeature(4115) is ControlHeadO2Recset feature18 && feature18[0] != null && feature18[0][10721] is O2MultiFunctionKnob multiFunctionKnob1)
        acpListField1 = multiFunctionKnob1.RadErgoControlO2MFKButtonPress_A42217;
      if (FeatureManager.GetFeature(4114) is ControlHeadO7Recset feature19 && feature19[0] != null && feature19[0][10718] is O7MultiFunctionKnob multiFunctionKnob2)
        acpListField2 = multiFunctionKnob2.RadErgoControlO7MFKButtonPress_A42218;
      if (FeatureManager.GetFeature(2013) is ShepherdsRecset feature20 && feature20[0] != null && feature20[0][10031].EmbeddedRecset is SignalIndependentProductIndependentNonProgrammableButtonListInnerRecset embeddedRecset30)
      {
        if (embeddedRecset30.Count < 36)
        {
          while (embeddedRecset30.Count < 36)
            embeddedRecset30.AddRecord(embeddedRecset30.CreateDefaultRecord());
          if (embeddedRecset30[34][10032] is SignalIndependentProductIndependentNonProgrammableButtonListInnerSection listInnerSection1)
          {
            listInnerSection1.RadErgoCfgSignalIndependentProductIndependentNonProgrammableButtonBCO_A19777.SetValue(11);
            listInnerSection1.RadErgoCfgSignalIndependentProductIndependentNonProgrammableButtonFeature_A19778.SetValue(216);
          }
          if (embeddedRecset30[35][10032] is SignalIndependentProductIndependentNonProgrammableButtonListInnerSection listInnerSection2)
          {
            listInnerSection2.RadErgoCfgSignalIndependentProductIndependentNonProgrammableButtonBCO_A19777.SetValue(91);
            if (flag)
              listInnerSection2.RadErgoCfgSignalIndependentProductIndependentNonProgrammableButtonFeature_A19778.SetValue(31 /*0x1F*/);
            else
              listInnerSection2.RadErgoCfgSignalIndependentProductIndependentNonProgrammableButtonFeature_A19778.SetValue(215);
          }
        }
        if (flag)
        {
          foreach (IAcpFeatureNode acpFeatureNode in (Collection<AcpBusinessLayer.FeatureNode>) embeddedRecset30)
          {
            SignalIndependentProductIndependentNonProgrammableButtonListInnerSection listInnerSection = acpFeatureNode[10032] as SignalIndependentProductIndependentNonProgrammableButtonListInnerSection;
            if (listInnerSection.RadErgoCfgSignalIndependentProductIndependentNonProgrammableButtonBCO_A19777.Value == 91)
            {
              if (listInnerSection.RadErgoCfgSignalIndependentProductIndependentNonProgrammableButtonFeature_A19778.Value == 31 /*0x1F*/)
              {
                acpListField1?.SetValue(31 /*0x1F*/);
                if (acpListField2 != null)
                {
                  acpListField2.SetValue(31 /*0x1F*/);
                  break;
                }
                break;
              }
              acpListField1?.SetValue(215);
              if (acpListField2 != null)
              {
                acpListField2.SetValue(215);
                break;
              }
              break;
            }
          }
        }
      }
    }
    this.ToneSignalingListToneAliasFixup();
    this.SoftPowerOffFixUp();
    this.expandFlashcode();
    this.CalculateValidityForVoiceAnnouncementNames();
    UndoManager.StartUndoRedo();
  }

  private static void UnpackMPLListRecordsFixUp(IAcpRecordset recset)
  {
    if (recset == null || recset.Count != 1 && recset.Count != 2)
      return;
    MPLConfigurationRecset._Min = recset.Count;
    MPLConfigurationRecset._Max = recset.Count;
    if (recset.Count == 2)
      (recset[1] as Motorola.MackinawCPS.CoreFeatures.MPLConfiguration.MPLConfiguration).FeatureName = AcgResources.MPL_Clone_Configuration;
    for (int index = 0; index < recset.Count; ++index)
    {
      foreach (AcpBusinessLayer.FeatureNode featureNode in (Collection<AcpBusinessLayer.FeatureNode>) (recset[index] as Motorola.MackinawCPS.CoreFeatures.MPLConfiguration.MPLConfiguration).MPLList.EmbeddedRecset)
      {
        MPLListInner mplListInner = featureNode as MPLListInner;
        mplListInner.MPLListInnerSection.MplCfgMPLListTxPLFreq_A9556.SetValue(mplListInner.MPLListInnerSection.MplCfgMPLListTxPLCode_A9555.Value);
        mplListInner.MPLListInnerSection.MplCfgMPLListRxPLFreq_A9027.SetValue(mplListInner.MPLListInnerSection.MplCfgMPLListRxPLCode_A9026.Value);
        mplListInner.MPLListInnerSection.MplCfgMPLListTAPLFreq_A9263.SetValue(mplListInner.MPLListInnerSection.MplCfgMPLListTAPLCode_A9262.Value);
      }
    }
  }

  private void CalculateValidityForVoiceAnnouncementNames()
  {
    IAcpRecordset feature = FeatureManager.GetFeature(2300);
    if (feature == null)
      return;
    for (int index = 0; index < feature.Count; ++index)
    {
      VoiceAnnouncementList announcementList = feature[index] as VoiceAnnouncementList;
      if (announcementList.General != null)
        announcementList.General.VoiceFileName_A21220Object.CalculateValidity();
    }
  }

  private void SetValueForWiFiRegulatoryRegion_A43772AfterUnpack()
  {
    Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation radioInformation = AppInfoManager.AppMode != ApplicationMode.CodeplugConfigurationMode ? AppInfoManager.ComparatorDocument.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation : FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation;
    bool? nullable = radioInformation?.Labtool?.RadInfoLabtoolQA08157ETSIRegulatoryRegionEnabled_43771?.Value;
    AcpFieldX<string, string> regulatoryRegionA43772 = radioInformation?.General?.RadInfoGeneralWiFiRegulatoryRegion_A43772;
    if (!nullable.HasValue || regulatoryRegionA43772 == null)
      return;
    string str1 = "00";
    string str2 = "01";
    if (nullable.GetValueOrDefault())
      regulatoryRegionA43772.Value = str2;
    else
      regulatoryRegionA43772.Value = str1;
  }

  private void ValidateE5EmergencyOrangeButton()
  {
    E5InnerRecset e5InnerRecset = (E5InnerRecset) null;
    if (FeatureManager.GetFeature(4236) is ControlHeadE5Recset feature)
      e5InnerRecset = feature[0][10902].EmbeddedRecset as E5InnerRecset;
    if (e5InnerRecset == null)
      return;
    foreach (IAcpFeatureNode acpFeatureNode in (Collection<AcpBusinessLayer.FeatureNode>) e5InnerRecset)
      (acpFeatureNode[10901] as E5InnerSection).CalculateValidity();
  }

  private void SynchronizePointerValuesForTrunkingPersonality()
  {
    foreach (Motorola.MackinawCPS.CoreFeatures.TrunkingPersonality.TrunkingPersonality trunkingPersonality in (Collection<AcpBusinessLayer.FeatureNode>) (FeatureManager.GetFeature(2072) as TrunkingPersonalityRecset))
    {
      trunkingPersonality?.General?.TrkPerGeneralUnitID_A9593?.CalculateEditability();
      trunkingPersonality?.General?.TrkPerGeneralSystemID_A9238?.CalculateApplicability();
    }
  }

  private static void KMButtonConventionalFeatureFixup()
  {
    (((FeatureManager.GetFeature(2128) as KeypadMicAndAccessoriesRecset)[0] as Motorola.MackinawCPS.CoreFeatures.KeypadMicAndAccessories.KeypadMicAndAccessories).General.EmbeddedRecset[0] as KMButtonInner).KMButtonInnerSection.RadErgoCfgKMConventionalKMButtonFeature_A19646.CalculateValidity();
  }

  private void FixPassword()
  {
    Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide radioWide = FeatureManager.GetFeature(2045)[0] as Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide;
    radioWide.UserInformationAndPasswords.RadWideUserInformationandPINPassword_41303.CalculateValidity();
    if (radioWide.UserInformationAndPasswords.RadWideUserInformationandPINPassword_41303.HiddenStatic && !radioWide.UserInformationAndPasswords.RadWideUserInformationandPINPassword_41303.Valid)
    {
      radioWide.UserInformationAndPasswords.RadWideUserInformationandPINPassword_41303.SetValue(radioWide.UserInformationAndPasswords.RadWideUserInformationandPINPassword_41303.DefaultValue);
      radioWide.UserInformationAndPasswords.RadWideUserInformationandPINPassword_41303.CalculateValidity();
    }
    Motorola.MackinawCPS.CoreFeatures.DataWide.DataWide dataWide = FeatureManager.GetFeature(2028)[0] as Motorola.MackinawCPS.CoreFeatures.DataWide.DataWide;
    ConfiguredNetworksListInnerRecset embeddedRecset = dataWide.WIFI.EmbeddedRecset as ConfiguredNetworksListInnerRecset;
    if (embeddedRecset.HiddenStatic)
    {
      foreach (AcpBusinessLayer.FeatureNode featureNode in (Collection<AcpBusinessLayer.FeatureNode>) embeddedRecset)
      {
        ConfiguredNetworksListInner networksListInner = featureNode as ConfiguredNetworksListInner;
        networksListInner.ConfiguredNetworksListInnerSection.DataWideWiFiNetworkEncryptedNetworkPassword_42517.CalculateValidity();
        if (!networksListInner.ConfiguredNetworksListInnerSection.DataWideWiFiNetworkEncryptedNetworkPassword_42517.Valid)
        {
          networksListInner.ConfiguredNetworksListInnerSection.DataWideWiFiNetworkSecurityType_42516.SetValue(networksListInner.ConfiguredNetworksListInnerSection.DataWideWiFiNetworkSecurityType_42516.DefaultValue);
          networksListInner.ConfiguredNetworksListInnerSection.DataWideWiFiNetworkEncryptedNetworkPassword_42517.SetValue(networksListInner.ConfiguredNetworksListInnerSection.DataWideWiFiNetworkEncryptedNetworkPassword_42517.DefaultValue);
          networksListInner.ConfiguredNetworksListInnerSection.DataWideWiFiNetworkEncryptedNetworkPassword_42517.CalculateValidity();
        }
      }
    }
    dataWide.ExternalDataModem.DataWideDataModemPassword_A42848.CalculateValidity();
    if (!dataWide.ExternalDataModem.DataWideDataModemPassword_A42848.HiddenStatic || dataWide.ExternalDataModem.DataWideDataModemPassword_A42848.Valid)
      return;
    dataWide.ExternalDataModem.DataWideDataModemPassword_A42848.SetValue(dataWide.ExternalDataModem.DataWideDataModemPassword_A42848.DefaultValue);
    dataWide.ExternalDataModem.DataWideDataModemPassword_A42848.CalculateValidity();
  }

  private void RefreshDynChannelName()
  {
    if (!(FeatureManager.GetFeature(2045)[0] is Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide radioWide) || !radioWide.Labtool.RadWideLabtoolDynamicZoneScanCapability_42749.Value)
      return;
    IAcpRecordset acpRecordset = AppInfoManager.AppMode != ApplicationMode.CodeplugComparisonMode ? FeatureManager.GetFeature(2051) : AppInfoManager.ComparatorDocument.GetFeature(2051);
    if (acpRecordset == null)
      return;
    foreach (Motorola.MackinawCPS.CoreFeatures.ZoneChannelAssignment.ZoneChannelAssignment channelAssignment in (Collection<AcpBusinessLayer.FeatureNode>) acpRecordset)
    {
      if (channelAssignment.Zone.ZnChanCfgZoneDynamicZoneEnable_A41257.Value)
      {
        if (channelAssignment.Channels.EmbeddedRecset is ChannelAssignmentListInnerRecset embeddedRecset)
        {
          int num = 1;
          foreach (ChannelAssignmentListInner assignmentListInner in (Collection<AcpBusinessLayer.FeatureNode>) embeddedRecset)
          {
            if (!assignmentListInner.ChannelAssignmentListInnerSection.ChannelsActiveChannel.UIValue)
              assignmentListInner.ChannelAssignmentListInnerSection.ZnChanCfgChannelsChannelName_A7659.SetValue(" ");
            ++num;
          }
        }
        embeddedRecset.RefreshKeyMap();
      }
    }
  }

  private void RefreshUserSelectablePL()
  {
    ConventionalPersonalityRecset personalityRecset = AppInfoManager.AppMode != ApplicationMode.CodeplugConfigurationMode ? AppInfoManager.ComparatorDocument.GetFeature(2059) as ConventionalPersonalityRecset : FeatureManager.GetFeature(2059) as ConventionalPersonalityRecset;
    if (personalityRecset == null)
      return;
    foreach (AcpBusinessLayer.FeatureNode featureNode in (Collection<AcpBusinessLayer.FeatureNode>) personalityRecset)
    {
      Motorola.MackinawCPS.CoreFeatures.ConventionalPersonality.ConventionalPersonality conventionalPersonality = featureNode as Motorola.MackinawCPS.CoreFeatures.ConventionalPersonality.ConventionalPersonality;
      FrequencyOptionsInnerRecset embeddedRecset = conventionalPersonality.Features.Parent[10148].EmbeddedRecset as FrequencyOptionsInnerRecset;
      if (conventionalPersonality != null && embeddedRecset != null)
      {
        foreach (FrequencyOptionsInner frequencyOptionsInner in (Collection<AcpBusinessLayer.FeatureNode>) embeddedRecset)
        {
          if (frequencyOptionsInner != null && frequencyOptionsInner.FrequencyOptionsInnerSection.CnvPerConventionalChannelOptionsUserSelectablePLMPLEnhance_43029.Value == 0 && frequencyOptionsInner.FrequencyOptionsInnerSection.CnvPerConventionalChannelOptionsUserSelectablePLMPL_A9606.Value)
            frequencyOptionsInner.FrequencyOptionsInnerSection.CnvPerConventionalChannelOptionsUserSelectablePLMPLEnhance_43029.SetValue(7);
        }
      }
    }
  }

  private void RefreshRemoteFreqMonitorOption()
  {
    ConventionalPersonalityRecset personalityRecset = AppInfoManager.AppMode != ApplicationMode.CodeplugConfigurationMode ? AppInfoManager.ComparatorDocument.GetFeature(2059) as ConventionalPersonalityRecset : FeatureManager.GetFeature(2059) as ConventionalPersonalityRecset;
    if (personalityRecset == null)
      return;
    foreach (AcpBusinessLayer.FeatureNode featureNode in (Collection<AcpBusinessLayer.FeatureNode>) personalityRecset)
    {
      Motorola.MackinawCPS.CoreFeatures.ConventionalPersonality.ConventionalPersonality conventionalPersonality = featureNode as Motorola.MackinawCPS.CoreFeatures.ConventionalPersonality.ConventionalPersonality;
      if (conventionalPersonality.ASTROCall.CnvPerASTROCallRemotemonitorfrequencyoption.ReferencedNode == null)
        conventionalPersonality.ASTROCall.CnvPerASTROCallRemotemonitorfrequencyoption.ResetToDefaultWithUndo();
    }
  }

  private void RefreshBroadbandFields()
  {
    DataProfilesRecset feature;
    Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation radioInformation;
    Motorola.MackinawCPS.CoreFeatures.DataWide.DataWide dataWide;
    if (AppInfoManager.AppMode == ApplicationMode.CodeplugConfigurationMode)
    {
      feature = FeatureManager.GetFeature(2054) as DataProfilesRecset;
      radioInformation = FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation;
      dataWide = FeatureManager.GetFeature(2028)[0] as Motorola.MackinawCPS.CoreFeatures.DataWide.DataWide;
    }
    else
    {
      feature = AppInfoManager.ComparatorDocument.GetFeature(2054) as DataProfilesRecset;
      radioInformation = AppInfoManager.ComparatorDocument.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation;
      dataWide = AppInfoManager.ComparatorDocument.GetFeature(2028)[0] as Motorola.MackinawCPS.CoreFeatures.DataWide.DataWide;
    }
    bool flag = false;
    if (radioInformation != null)
      flag = radioInformation.Labtool.RadInfoLabtoolLTEOperation_A41923.Value;
    if (feature != null & flag)
    {
      foreach (AcpBusinessLayer.FeatureNode featureNode in (Collection<AcpBusinessLayer.FeatureNode>) feature)
      {
        Motorola.MackinawCPS.CoreFeatures.DataProfiles.DataProfiles dataProfiles = featureNode as Motorola.MackinawCPS.CoreFeatures.DataProfiles.DataProfiles;
        if (dataProfiles.LTE.DataProfLTEEnabled_A42075.Value && ((int) (AcpField<int>) dataProfiles.General.DataProfGeneralDataProfileType_A21320 == 3 || (int) (AcpField<int>) dataProfiles.General.DataProfGeneralDataProfileType_A21320 == 4 || (int) (AcpField<int>) dataProfiles.General.DataProfGeneralDataProfileType_A21320 == 2))
          dataProfiles.LTE.DataProfBroadbandSource_A42858.SetValue(1);
      }
    }
    dataWide?.General.DataWideGeneralBroadbandCheckbackTime_A42862.SetValue(dataWide.LTE.DataWideLTELTECheckbackTime_A42205.Value);
  }

  private void RefreshActionConsolidation()
  {
    ActionConsolidationRecset feature = FeatureManager.GetFeature(4008) as ActionConsolidationRecset;
    for (int index = 0; index < feature.Count; ++index)
    {
      ConsolidatedActionsInnerSection actionsInnerSection = ((feature[index][10615].EmbeddedRecset as ConsolidatedActionsInnerRecset).TemplateNode as ConsolidatedActionsInner).ConsolidatedActionsInnerSection;
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      actionsInnerSection.RadioErgoConfigACGeneralIndex_A36591.IsVisible = WindowMain.\u003C\u003EO.\u003C2\u003E__ConActionTypeIsGeneralOrExitOrControlOrInvalidSim ?? (WindowMain.\u003C\u003EO.\u003C2\u003E__ConActionTypeIsGeneralOrExitOrControlOrInvalidSim = new StateConstraint(ActionConsolidationConstraints.ConActionTypeIsGeneralOrExitOrControlOrInvalidSim));
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      actionsInnerSection.RadioErgoConfigACGeneralZone_A36592.IsVisible = WindowMain.\u003C\u003EO.\u003C3\u003E__ConActionTypeIsGeneralOrControlOrInvalidSim ?? (WindowMain.\u003C\u003EO.\u003C3\u003E__ConActionTypeIsGeneralOrControlOrInvalidSim = new StateConstraint(ActionConsolidationConstraints.ConActionTypeIsGeneralOrControlOrInvalidSim));
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      actionsInnerSection.RadioErgoConfigACGeneralChannel_A36593.IsVisible = WindowMain.\u003C\u003EO.\u003C3\u003E__ConActionTypeIsGeneralOrControlOrInvalidSim ?? (WindowMain.\u003C\u003EO.\u003C3\u003E__ConActionTypeIsGeneralOrControlOrInvalidSim = new StateConstraint(ActionConsolidationConstraints.ConActionTypeIsGeneralOrControlOrInvalidSim));
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      actionsInnerSection.RadioErgoConfigACGeneralTEXTMESSAGE_42913.IsVisible = WindowMain.\u003C\u003EO.\u003C4\u003E__ConActionTypeIsGeneralOrExit ?? (WindowMain.\u003C\u003EO.\u003C4\u003E__ConActionTypeIsGeneralOrExit = new StateConstraint(ActionConsolidationConstraints.ConActionTypeIsGeneralOrExit));
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      actionsInnerSection.RadioErgoConfigACGeneralTxPowerChange__42916.IsVisible = WindowMain.\u003C\u003EO.\u003C5\u003E__ConActionTypeIsGeneral ?? (WindowMain.\u003C\u003EO.\u003C5\u003E__ConActionTypeIsGeneral = new StateConstraint(ActionConsolidationConstraints.ConActionTypeIsGeneral));
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      actionsInnerSection.RadioErgoConfigACGeneralMuteSSA__42917.IsVisible = WindowMain.\u003C\u003EO.\u003C5\u003E__ConActionTypeIsGeneral ?? (WindowMain.\u003C\u003EO.\u003C5\u003E__ConActionTypeIsGeneral = new StateConstraint(ActionConsolidationConstraints.ConActionTypeIsGeneral));
      actionsInnerSection.CalculateVisibility();
    }
  }

  private void RefreshToneSignalingList()
  {
    if (!(FeatureManager.GetFeature(2059) is ConventionalPersonalityRecset feature))
      return;
    foreach (AcpBusinessLayer.FeatureNode featureNode in (Collection<AcpBusinessLayer.FeatureNode>) feature)
    {
      if (featureNode is Motorola.MackinawCPS.CoreFeatures.ConventionalPersonality.ConventionalPersonality conventionalPersonality)
      {
        conventionalPersonality.RAC.CnvPerRACCodeType1_A7680.CalculateApplicability();
        conventionalPersonality.RAC.CnvPerRACCodeType1_A7680.CalculateValidity();
        conventionalPersonality.RAC.CnvPerRACCodeType2_A8817.CalculateApplicability();
        conventionalPersonality.RAC.CnvPerRACCodeType2_A8817.CalculateValidity();
      }
    }
  }

  private void RefreshAudioEnhancementForConsolette()
  {
    if (this.CodeplugVersion.Major >= 15 || !(FeatureManager.GetFeature(2049)[0] is Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation radioInformation))
      return;
    string numberA8539Value = radioInformation.General.RadInfoGeneralModelNumber_A8539Value;
    if (numberA8539Value == null || !numberA8539Value.StartsWith("L30") || !(FeatureManager.GetFeature(2077) is RadioProfilesRecset feature))
      return;
    foreach (IAcpFeatureNode acpFeatureNode in (Collection<AcpBusinessLayer.FeatureNode>) feature)
    {
      foreach (IAcpFeatureSection featureSections in acpFeatureNode.FeatureSectionsCollection)
      {
        if (featureSections is AudioSettings audioSettings)
        {
          if ((audioSettings.NoiseReductionGroupSettingRadio_42584.Value == 0 || audioSettings.NoiseReductionGroupSettingRadio_42584.Value == 2 || audioSettings.NoiseReductionGroupSettingRadio_42584.Value == 3) && audioSettings.RadProfAudioSettingsInternalMicWindNoiseReductionLevelSelection_A22194.Value == 0)
            audioSettings.NoiseReductionGroupSettingRadio_42584.Value = 4;
          if (audioSettings.GainSensitivityGroupSettingRadio_42608.Value == 0 && !audioSettings.RadProfAudioSettingsAnalogAGC1_A7440.Value)
            audioSettings.GainSensitivityGroupSettingRadio_42608.Value = 4;
          if ((audioSettings.NoiseReductionGroupSettingAccessory_42585.Value == 0 || audioSettings.NoiseReductionGroupSettingAccessory_42585.Value == 2 || audioSettings.NoiseReductionGroupSettingAccessory_42585.Value == 3) && audioSettings.RadProfExternalMicWindNoiseReductionLevelSelection_A21511.Value == 0)
            audioSettings.NoiseReductionGroupSettingAccessory_42585.Value = 4;
          if (audioSettings.GainSensitivityGroupSettingAccessory_42610.Value == 0 && !audioSettings.RadProfAudioSettingsAnalogAGC2_A7439.Value)
            audioSettings.GainSensitivityGroupSettingAccessory_42610.Value = 4;
        }
      }
    }
  }

  private void RefreshAESFields()
  {
    string str = (FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation).General.RadInfoGeneralCodeplugVersion_A7683.Value;
    if (str == null || str.Length <= 3 || int.Parse(str.Substring(1, 2)) >= 16 /*0x10*/)
      return;
    Motorola.MackinawCPS.CoreFeatures.SecureWide.SecureWide secureWide = FeatureManager.GetFeature(2021)[0] as Motorola.MackinawCPS.CoreFeatures.SecureWide.SecureWide;
    if (secureWide.General.SecWideGeneralSecureOperation_A9067.Value != 3)
      return;
    secureWide.General.SecureWideADPAlgorithmEnable_43200.SetValue(true);
    secureWide.General.SecureWideKeyloadingSource_43204.SetValue(0);
  }

  private void SynPreAmp()
  {
    bool flag = UtilityMack.ProductModelId.Equals("APX8500");
    if (!(FeatureManager.GetFeature(2045)[0] is Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide radioWide) || !UtilityMack.IsMobile() || flag)
      return;
    if (radioWide.Features.RadWideAdvancedPreAmp_A8733.Value != radioWide.Features.RadWideFeaturePreAmpVHF_A42960.Value)
      radioWide.Features.RadWideFeaturePreAmpVHF_A42960.SetValue(radioWide.Features.RadWideAdvancedPreAmp_A8733.Value);
    if (radioWide.Features.RadWideAdvancedPreAmp_A8733.Value == radioWide.Features.RadWideFeaturePreAmpUHF_A42962.Value)
      return;
    radioWide.Features.RadWideFeaturePreAmpUHF_A42962.SetValue(radioWide.Features.RadWideAdvancedPreAmp_A8733.Value);
  }

  private void RefreshMaxChangeRecords()
  {
    ConventionalPersonalityRecset feature1 = FeatureManager.GetFeature(2059) as ConventionalPersonalityRecset;
    if (feature1 != null)
    {
      foreach (AcpBusinessLayer.FeatureNode featureNode in (Collection<AcpBusinessLayer.FeatureNode>) feature1)
      {
        Motorola.MackinawCPS.CoreFeatures.ConventionalPersonality.ConventionalPersonality conventionalPersonality = featureNode as Motorola.MackinawCPS.CoreFeatures.ConventionalPersonality.ConventionalPersonality;
        FrequencyOptionsInnerRecset embeddedRecset = conventionalPersonality.Features.Parent[10148].EmbeddedRecset as FrequencyOptionsInnerRecset;
        if (conventionalPersonality != null && embeddedRecset != null && conventionalPersonality.Features.CnvPerFeaturesMixedVoteScanEnable_A38723 != null)
        {
          if (conventionalPersonality.Features.CnvPerFeaturesMixedVoteScanEnable_A38723.Value)
            embeddedRecset.SetMax(15);
          else
            embeddedRecset.SetMax(FrequencyOptionsInnerRecset._Max);
        }
      }
    }
    ScanListRecset feature2 = FeatureManager.GetFeature(2057) as ScanListRecset;
    if (feature1 != null)
    {
      foreach (AcpBusinessLayer.FeatureNode featureNode in (Collection<AcpBusinessLayer.FeatureNode>) feature2)
      {
        if (featureNode is Motorola.MackinawCPS.CoreFeatures.ScanList.ScanList scanList && scanList.General.ScanLstGeneralScanType_A9058 != null)
          scanList.General.ScanLstGeneralScanType_A9058.CalculateApplicability();
      }
    }
    if (!(FeatureManager.GetFeature(2064) is TrunkingSystemRecset feature3))
      return;
    foreach (AcpBusinessLayer.FeatureNode featureNode in (Collection<AcpBusinessLayer.FeatureNode>) feature3)
    {
      if (featureNode is Motorola.MackinawCPS.CoreFeatures.TrunkingSystem.TrunkingSystem trunkingSystem && trunkingSystem.StatusAlias.TrkSysStatusAliasStatusAliasEnable_A9195 != null)
        trunkingSystem.StatusAlias.TrkSysStatusAliasStatusAliasEnable_A9195.CalculateApplicability();
    }
  }

  private void SetInitialKMFProfileRecsetMaxSize()
  {
    SecureKMFProfileRecset.TriggerKMFProfileTableSizeCheck();
  }

  private void RemoveTheRecordOfCallAlertIDDisplay()
  {
    if (!(FeatureManager.GetFeature(2010) is DisplayAndMenuRecset feature) || feature.Count <= 0 || !((feature[0] as Motorola.MackinawCPS.CoreFeatures.DisplayAndMenu.DisplayAndMenu).IDDisplay.EmbeddedRecset is IDDisplayTableInnerRecset embeddedRecset) || embeddedRecset.Count <= 2)
      return;
    for (int index = 2; index < embeddedRecset.Count; ++index)
      new DeleteRecordTask((AcpBusinessLayer.FeatureNode) (embeddedRecset[index] as IDDisplayTableInner)).Do();
    IDDisplayTableInnerRecset._Min = embeddedRecset.Count;
    IDDisplayTableInnerRecset._MaxPool = embeddedRecset.Count;
    embeddedRecset.DefaultRecordCount = embeddedRecset.Count;
    embeddedRecset.Max = embeddedRecset.Count;
  }

  private void UpdatePaddingSpacesForSoftIDUsername()
  {
    if (!(FeatureManager.GetFeature(2045) is RadioWideRecset feature1) || feature1.Count < 1)
      return;
    UserInformationAndPasswords informationAndPasswords = feature1[0][10102] as UserInformationAndPasswords;
    if (!(FeatureManager.GetFeature(2024) is ConventionalWideRecset feature2) || feature2.Count < 1)
      return;
    if ((feature2[0][10057] as Motorola.MackinawCPS.CoreFeatures.ConventionalWide.Features).CnvWideFeaturesSoftIDFeature_A9168.Value)
    {
      if (informationAndPasswords.RadWideUserInformationandPasswordsSoftIDUsernameDisplayTextSize_A23453.Value != 8)
        informationAndPasswords.RadWideUserInformationandPasswordsSoftIDUsernameDisplayTextSize_A23453.SetValue(8);
    }
    else if (informationAndPasswords.RadWideUserInformationandPasswordsSoftIDUsernameDisplayTextSize_A23453.Value != 20)
      informationAndPasswords.RadWideUserInformationandPasswordsSoftIDUsernameDisplayTextSize_A23453.SetValue(20);
    AcpFieldX<string, string> softIdUsernameA9169 = (feature1[0][10102] as UserInformationAndPasswords).RadWideUserInformationandPasswordsSoftIDUsername_A9169;
    string str = softIdUsernameA9169.Value;
    AcpSimpleRangeField displayTextSizeA23453 = (feature1[0][10102] as UserInformationAndPasswords).RadWideUserInformationandPasswordsSoftIDUsernameDisplayTextSize_A23453;
    string newValue = Convert.ToString(str).TrimEnd();
    int length = newValue.Length;
    int num1 = displayTextSizeA23453.Value;
    if (length < num1)
    {
      int num2 = num1 - length;
      for (int index = 0; index < num2; ++index)
        newValue += " ";
    }
    softIdUsernameA9169.SetValue(newValue);
  }

  private void CombinePinPartsToPinPassword(bool isReadingRadio, RadioParams currentRadioParams)
  {
    IAcpRecordset acpRecordset = AppInfoManager.AppMode != ApplicationMode.CodeplugComparisonMode ? FeatureManager.GetFeature(2045) : AppInfoManager.ComparatorDocument.GetFeature(2045);
    if (acpRecordset == null || acpRecordset.Count <= 0)
      return;
    Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide radioWide = acpRecordset[0] as Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide;
    bool flag = radioWide.Labtool.RadWideLabtoolEncryptPassword_A41695.Value;
    string empty1 = string.Empty;
    string empty2 = string.Empty;
    string empty3 = string.Empty;
    string str = radioWide.UserInformationAndPasswords.RadWideUserInformationandPasswordsPIN_A8705Value;
    string passwordPart241304Value = radioWide.UserInformationAndPasswords.RadWideUserInformationandPINPasswordPart2_41304Value;
    if (str.Length > 4)
      str = str.Substring(0, 4);
    string newValue = !flag ? AESCryptoUtil.AESEncryptWithDefKey(str + passwordPart241304Value) : radioWide.Labtool.RadWideLabtoolEncryptedPINPassword_A41702Value;
    radioWide.UserInformationAndPasswords.RadWideUserInformationandPINPassword_41303.SetValue(newValue);
    radioWide.Labtool.RadWideLabtoolEncryptedPINPassword_A41702.SetValue(newValue);
    radioWide.UserInformationAndPasswords.RadWideUserInformationandPasswordsPIN_A8705.SetValue(string.Empty);
    radioWide.UserInformationAndPasswords.RadWideUserInformationandPINPasswordPart2_41304.SetValue(string.Empty);
    radioWide.Labtool.RadWideLabtoolEncryptPassword_A41695.SetValue(true);
  }

  private void VoiceAnnListFixup()
  {
    if (!(FeatureManager.GetFeature(2300) is VoiceAnnouncementListRecSet feature) || feature.Count <= 0)
      return;
    foreach (VoiceAnnouncementList record in (Collection<AcpBusinessLayer.FeatureNode>) feature)
      feature.IncrementCumulativeMax((IAcpFeatureNode) record);
  }

  private void UCLInvalidKeyFiledFixup()
  {
    foreach (FieldsReportInfo fieldsReportInfo in new System.Collections.Generic.List<FieldsReportInfo>(AppInfoManager.InvalidFieldsReport.Fields))
    {
      if (fieldsReportInfo != null && fieldsReportInfo.Field != null && fieldsReportInfo.Field.Name != null && (fieldsReportInfo.Field.Name == "UclAstroCnv_CallID_A00026" || fieldsReportInfo.Field.Name == "UclAstro25Trk_CombinedID_A00014" || fieldsReportInfo.Field.Name == "UclT2Trk_CombinedID_A00020" || fieldsReportInfo.Field.Name == "UclMDCCnv_CallID_A00031"))
        fieldsReportInfo.Field.Valid = true;
    }
  }

  private void NATListFixup()
  {
    bool flag = true;
    RadioInformationRecset feature = FeatureManager.GetFeature(2049) as RadioInformationRecset;
    if ((feature[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation).Labtool.RadInfoLabtoolH868W968OtarAndMultikey_A8192.Value || (feature[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation).Labtool.RadInfoLabtoolQ947W947APCOPacketData_8804.Value)
      flag = false;
    if (!flag || !(FeatureManager.GetFeature(2028)[0] is Motorola.MackinawCPS.CoreFeatures.DataWide.DataWide dataWide) || !(dataWide.NATList.EmbeddedRecset is NATListInnerRecset embeddedRecset))
      return;
    embeddedRecset.Clear();
  }

  private void SecureADPKeyDataFixup()
  {
    if (int.Parse(((FeatureManager.GetFeature(2049) as RadioInformationRecset)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation).General.RadInfoGeneralCodeplugVersion_A7683.Value.Substring(1, 2)) >= 8)
      return;
    Motorola.MackinawCPS.CoreFeatures.SecureWide.SecureWide secureWide = FeatureManager.GetFeature(2021)[0] as Motorola.MackinawCPS.CoreFeatures.SecureWide.SecureWide;
    if (secureWide.General.SecWideGeneralSecureOperation_A9067.Value != 3 || !(secureWide.EncryptionKeyList.EmbeddedRecset is EncryptionKeyListInnerRecset embeddedRecset) || embeddedRecset.Count == 0)
      return;
    foreach (IAcpFeatureNode acpFeatureNode in (Collection<AcpBusinessLayer.FeatureNode>) embeddedRecset)
    {
      AcpField<string> selectableAdpKeyDataA9106 = (acpFeatureNode[10041] as EncryptionKeyListInnerSection).SecWideMultikeyListSelectableADPKeyData_A9106;
      long result = 0;
      if (!long.TryParse(selectableAdpKeyDataA9106.Value, NumberStyles.HexNumber, (IFormatProvider) null, out result) && !selectableAdpKeyDataA9106.Value.Contains("**********"))
        selectableAdpKeyDataA9106.Valid = false;
    }
  }

  private void ScanListFixup()
  {
    IAcpRecordset feature = FeatureManager.GetFeature(2057);
    if (feature == null || feature.Count == 0)
      return;
    foreach (Motorola.MackinawCPS.CoreFeatures.ScanList.ScanList scanList in (Collection<AcpBusinessLayer.FeatureNode>) feature)
    {
      AcpListField generalScanTypeA9058 = scanList.General.ScanLstGeneralScanType_A9058;
      AcpListField priority1TypeA8745 = scanList.General.ScanLstGeneralPriority1Type_A8745;
      AcpRecRefField priorityMember1A8747 = scanList.General.ScanLstGeneralPriorityMember1_A8747;
      if (generalScanTypeA9058.Value == 0 || generalScanTypeA9058.Value == 2)
      {
        int referencedIndex = priorityMember1A8747.ReferencedIndex;
        if (priority1TypeA8745.Value == 1 && referencedIndex == 0)
          priorityMember1A8747.Valid = false;
        if (priorityMember1A8747.RefRecset != null && referencedIndex >= 1 && referencedIndex <= priorityMember1A8747.RefRecset.Count)
        {
          ScanListInner scanListInner = priorityMember1A8747.RefRecset[referencedIndex - 1] as ScanListInner;
          if ((priority1TypeA8745.Value == 1 || priority1TypeA8745.Value == 3) && (scanListInner.ScanListInnerSection.ScanLstScanListZone_A9718.Value == 0 || scanListInner.ScanListInnerSection.ScanLstScanListChannel_A7620.Value == 0))
            priorityMember1A8747.Valid = false;
        }
      }
    }
  }

  private void CnvPerTalkgroupListFixUp()
  {
    IAcpRecordset feature = FeatureManager.GetFeature(2059);
    if (feature == null || feature.Count == 0)
      return;
    foreach (Motorola.MackinawCPS.CoreFeatures.ConventionalPersonality.ConventionalPersonality conventionalPersonality in (Collection<AcpBusinessLayer.FeatureNode>) feature)
    {
      if (conventionalPersonality.RxOptions.CnvPerRxOptionsRxVoiceSignalType_A9044.Value != 0 && conventionalPersonality.ASTROTalkgroup.CnvPerASTROTalkgroupOptionsTalkGroupEnable_A9272.Value && conventionalPersonality.Secure.CnvPerSecureASTROOTAR_A7493.Value && conventionalPersonality.Secure.CnvPerSecureASTROOTAR_A7493.Applicable)
      {
        AcpRecRefField profileIndexA8381 = conventionalPersonality.Secure.CnvPerSecureKMFProfileIndex_A8381;
        AcpRecRefField talkgroupListA9283 = conventionalPersonality.ASTROTalkgroup.CnvPerASTROTalkgroupOptionsTalkgroupList_A9283;
        if (talkgroupListA9283.ReferencedNode is Motorola.MackinawCPS.CoreFeatures.ASTROTalkgroupList.ASTROTalkgroupList referencedNode && referencedNode.General.AstTlkgrpLstGeneralKMFProfileIndex_A8380.ReferencedIndex != profileIndexA8381.ReferencedIndex)
          talkgroupListA9283.Valid = false;
      }
    }
  }

  private void LimitedPatienceTimeFixup()
  {
    ConventionalWideRecset feature = FeatureManager.GetFeature(2024) as ConventionalWideRecset;
    if ((feature[0] as Motorola.MackinawCPS.CoreFeatures.ConventionalWide.ConventionalWide).ASTROData.CnvWideASTRODataTxLimitedPatienceSec_A9544.Value != 1)
      return;
    (feature[0] as Motorola.MackinawCPS.CoreFeatures.ConventionalWide.ConventionalWide).ASTROData.CnvWideASTRODataTxLimitedPatienceSec_A9544.Valid = false;
  }

  private void RefreshScanlistMap()
  {
    IAcpRecordset acpRecordset = AppInfoManager.AppMode != ApplicationMode.CodeplugComparisonMode ? FeatureManager.GetFeature(2057) : AppInfoManager.ComparatorDocument.GetFeature(2057);
    if (acpRecordset == null || acpRecordset.Count == 0)
      return;
    foreach (Motorola.MackinawCPS.CoreFeatures.ScanList.ScanList scanList in (Collection<AcpBusinessLayer.FeatureNode>) acpRecordset)
      ((AcpBusinessLayer.Recordset) scanList.ScanListMembers.EmbeddedRecset).RefreshKeyMap();
  }

  private void AttemptsAllowedDefaultValueFixUp()
  {
    RadioWideRecset feature = FeatureManager.GetFeature(2045) as RadioWideRecset;
    if ((feature[0] as Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide).UserInformationAndPasswords.RadWideUserInformationandPasswordsRadioLockAttemptsAllowed_A3582.Value != 0)
      return;
    (feature[0] as Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide).UserInformationAndPasswords.RadWideUserInformationandPasswordsRadioLockAttemptsAllowed_A3582.Value = 3;
  }

  public bool Pop25Enabled
  {
    get => this.pop25Enabled;
    private set
    {
      if (this.pop25Enabled == value)
        return;
      this.pop25Enabled = value;
      this.FirePropertyChanged(nameof (Pop25Enabled));
    }
  }

  public bool SpecialKeyLoaded
  {
    get => this.specKeyLoaded;
    private set
    {
      if (this.specKeyLoaded == value)
        return;
      this.specKeyLoaded = value;
      this.FirePropertyChanged(nameof (SpecialKeyLoaded));
    }
  }

  internal bool LabToolKeyLoaded
  {
    get => this.labtoolKeyLoaded;
    private set
    {
      if (this.labtoolKeyLoaded == value)
        return;
      this.labtoolKeyLoaded = value;
      this.FirePropertyChanged(nameof (LabToolKeyLoaded));
    }
  }

  internal bool DepotKeyLoaded
  {
    get => this.depotKeyLoaded;
    private set
    {
      if (this.depotKeyLoaded == value)
        return;
      this.depotKeyLoaded = value;
      this.FirePropertyChanged(nameof (DepotKeyLoaded));
    }
  }

  private void WinMain_FrameCenterTop_Navigated(object sender, NavigationEventArgs e)
  {
    System.Windows.Controls.Frame frame = (System.Windows.Controls.Frame) sender;
    if (frame.CanGoBack && frame.BackStack != null)
    {
      IEnumerator enumerator = frame.BackStack.GetEnumerator();
      enumerator.MoveNext();
      JournalEntry current = (JournalEntry) enumerator.Current;
      if (current != null && current.Source != (Uri) null)
        frame.RemoveBackEntry();
    }
    if (AppInfoManager.AppMode != ApplicationMode.CodeplugConfigurationMode)
      return;
    PageNavPaneButtons content = (PageNavPaneButtons) this.FrameLeft.Content;
    if (content == null)
      return;
    if (e.Content is PageWelcome)
      content.SetSelectedItem(content.ButtonHome, false);
    else
      content.SetSelectedItem(content.ButtonCpgNav, false);
  }

  internal void SetDVRSHoptionEnabledField()
  {
    try
    {
      if (!(FeatureManager.GetFeature(2049)[0] is Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation radioInformation))
        return;
      UtilityMack.IsDVRSHoptionEnabled = radioInformation.Labtool.RadioInfoLabToolGA00631DvrsMsuOperation_A41827.Value;
    }
    catch (Exception ex)
    {
    }
  }

  public void SetDVRSHwEnabledField()
  {
    try
    {
      if (!(FeatureManager.GetFeature(4142)[0] is Motorola.MackinawCPS.CoreFeatures.DVRSWide.DVRSWide dvrsWide))
        return;
      UtilityMack.IsDVRSHwEnabled = dvrsWide.General.RadErgoWideDigitalVehicularRepeaterSystemDVRSHardwareEnable_A7911.Value;
    }
    catch (Exception ex)
    {
    }
  }

  public void SetProductModelIdentifierField()
  {
    try
    {
      UtilityMack.ProductModelId = (FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation).Labtool.RadInfoLabtoolProductModelIdentifier_A37178Value.ToString();
    }
    catch (Exception ex)
    {
    }
  }

  internal void SetTitleBar(string fName, string radioSN, Radio d)
  {
    string apxCps = AppResources.APX_CPS;
    string str = !UtilityMack.IsMobileOnly() ? (!UtilityMack.IsPortableOnly() ? AppResources._Unknown_Model_ : AppResources._Portable_) : AppResources._Mobile_;
    if (fName != null && fName != "" && radioSN == null)
    {
      if (fName.EndsWith("xml"))
        this.Title = $"{apxCps} - {fName}";
      else
        this.Title = $"{apxCps} {str} - {fName}";
    }
    else if (fName == null && radioSN != null && radioSN != "")
      this.Title = $"{apxCps} {str} - Device {radioSN}";
    else if (fName == null || fName == "" || radioSN == null)
      this.Title = apxCps;
    this.Title = this.Title.Replace("_", "__");
  }

  internal void SetTitleBar(string fName, string radioSN)
  {
    this.SetTitleBar(fName, radioSN, (Radio) null);
  }

  private void OnAppMenuOptions(object sender, RoutedEventArgs e)
  {
    AcpUIDialogWindow<string> acpUiDialogWindow = new AcpUIDialogWindow<string>((PageFunction<string>) new MackinawCPS.Options(this), (string) null);
    acpUiDialogWindow.ShowInTaskbar = false;
    acpUiDialogWindow.Owner = (Window) this;
    acpUiDialogWindow.ResizeMode = ResizeMode.NoResize;
    acpUiDialogWindow.Show();
    acpUiDialogWindow.Focus();
    acpUiDialogWindow.Hide();
    acpUiDialogWindow.ShowDialog();
  }

  private void OnRibbonBarLoadTxmCertificate(object sender, RoutedEventArgs e)
  {
    UndoManager.StopUndoRedo();
    SpecialFeatures.Comms.Comms comms = new SpecialFeatures.Comms.Comms();
    COMMS_OP WriteType = COMMS_OP.USB_READ_WRITE;
    if (!comms.VerifyTxmRadio(WriteType, out RadioParams _))
      return;
    string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
    LoadTxmCertificateMenu txmCertificateMenu = new LoadTxmCertificateMenu(((App) System.Windows.Application.Current).TheDocument.docFilePath == null ? folderPath : ((App) System.Windows.Application.Current).TheDocument.docFilePath);
    comms.ForceClose();
    txmCertificateMenu.ShowDialog();
  }

  public bool AuthenticateCpgForRWPassword(
    AcpDocument document,
    string password,
    bool isNonGuiOpen,
    bool isForExport = false)
  {
    bool flag1 = false;
    try
    {
      if (document.GetFeature(2045)[0] is Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide radioWide)
      {
        bool flag2 = true;
        if (isForExport || this.deviceFromServer != null || this.templateFromServer != null || (bool) System.Windows.Application.Current.Properties[(object) "CommandLineCPS"])
          flag2 = false;
        flag1 = !flag2 || !radioWide.Labtool.RadWideLabtoolArchiveReadPasswordEnable_A7462Value || (!isNonGuiOpen ? this._readWritePasswordApp.ValidateOKToArchiveFile(radioWide.Labtool.RadWideLabtoolRadioPassword_A8837Value) : this._readWritePasswordApp.ValidateOKToUserPassword(password, radioWide.Labtool.RadWideLabtoolRadioPassword_A8837Value, (string) null));
      }
    }
    catch (Exception ex)
    {
    }
    if (!flag1)
    {
      document.docFilePath = (string) null;
      document.docFileName = (string) null;
      document.FileClose();
    }
    return flag1;
  }

  internal void OnLoad(object sender, RoutedEventArgs e)
  {
    if ((bool) System.Windows.Application.Current.Properties[(object) "CommandLineCPS"])
    {
      this.Visibility = Visibility.Hidden;
      DockWindow.isCPSWindowHidden = true;
      Cruncher.Instance.LaunchOperations(sender, e);
    }
    else
    {
      try
      {
        bool flag = false;
        IDataStoreDecryptHandler storeDecryptHandler = (IDataStoreDecryptHandler) new DataStoreDecryptHandler();
        if (storeDecryptHandler.XStoreAvailable)
        {
          System.Collections.Generic.List<PNServer> pnServerList1 = new System.Collections.Generic.List<PNServer>();
          System.Collections.Generic.List<PNServer> pnServerList2 = storeDecryptHandler.XStoreRead();
          if (pnServerList2 != null)
          {
            foreach (PNServer pnServer in pnServerList2)
            {
              if (pnServer.SecureConn)
              {
                flag = true;
                break;
              }
            }
          }
        }
        if (flag)
        {
          if (storeDecryptHandler.isDHkeyExpired())
          {
            this.m_DHGeneration = new Thread(new ThreadStart(storeDecryptHandler.dhUpdateEventThread));
            this.m_DHGeneration.Start();
          }
        }
      }
      catch
      {
      }
      WindowMain._appMainFrame = this;
    }
  }

  private void ShowUpdateLogSetting(LogSetting logSetting)
  {
    AcpUIDialogWindow<string> acpUiDialogWindow = new AcpUIDialogWindow<string>((PageFunction<string>) new UpdateLogSettingView(logSetting), (string) null);
    acpUiDialogWindow.ShowInTaskbar = false;
    acpUiDialogWindow.Owner = (Window) this;
    acpUiDialogWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
    acpUiDialogWindow.ResizeMode = ResizeMode.NoResize;
    acpUiDialogWindow.Focus();
    acpUiDialogWindow.ShowDialog();
  }

  protected override void OnSourceInitialized(EventArgs e)
  {
    base.OnSourceInitialized(e);
    try
    {
      WindowMain.WINDOWPLACEMENT windowPlacement = Settings.Default.WindowPlacement with
      {
        length = Marshal.SizeOf(typeof (WindowMain.WINDOWPLACEMENT)),
        flags = 0
      };
      windowPlacement.showCmd = windowPlacement.showCmd == 2 ? 1 : windowPlacement.showCmd;
      IntPtr handle = new WindowInteropHelper((Window) this).Handle;
      if (Settings.Default.SizeStored)
        WindowMain.NativeMethods.SetWindowPlacement(handle, ref windowPlacement);
    }
    catch (Exception ex)
    {
      Console.WriteLine(ex.Message);
    }
    if (this.settingsSavedOnAppExit.BottomPanelAutoHide)
      return;
    bool bVisibile;
    this.pageIUI.GetDockWindowState(DockWndType.DnD, out bVisibile, out bool _, out bool _);
    if (bVisibile)
    {
      this.pageIUI.CloseDockWindow(DockWndType.DnD);
      this.pageIUI.OpenDockWindow(DockWndType.DnD);
    }
    else
    {
      this.pageIUI.OpenDockWindow(DockWndType.DnD);
      this.pageIUI.CloseDockWindow(DockWndType.DnD);
    }
  }

  protected override void OnClosing(CancelEventArgs e)
  {
    if (this.m_DHGeneration != null)
      this.m_DHGeneration.Abort();
    if (!(bool) System.Windows.Application.Current.Properties[(object) "CommandLineCPS"])
    {
      WindowMain.WINDOWPLACEMENT lpwndpl = new WindowMain.WINDOWPLACEMENT();
      WindowMain.NativeMethods.GetWindowPlacement(new WindowInteropHelper((Window) this).Handle, out lpwndpl);
      Settings.Default.WindowPlacement = lpwndpl;
      Settings.Default.SizeStored = true;
      Settings.Default.Ribbon_Maximized = !this.WindowMainRibbonControl.IsMinimized;
      Settings.Default.Save();
    }
    if (this.rMCWnd != null && this.rMCWnd.RadioManagementControl != null && this.rMCWnd.RadioManagementControl.OnShuttingDown())
      e.Cancel = true;
    base.OnClosing(e);
  }

  internal void OnRibbonBarReadRadio(object sender, RoutedEventArgs e)
  {
    this.ribbonBarDeviceRead.Focus();
    if (this.ReadWriteTransport == 2 && !BluetoothPANIPAddressRule.IsValidBluetoothPANIPAddress(this.txtBTIPAddressForWR.Text))
    {
      AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, $"{AppResources.Invalid_IP_Address}: {this.txtBTIPAddressForWR.Text}");
    }
    else
    {
      int readWriteTransport = this.ReadWriteTransport;
      AppInfoManager.StatusMsgReport.Clear();
      this.ReadWriteInProgress = true;
      if (!this.progressPage.bCommSuccess)
      {
        this.progressPage.Hide();
        this.progressPage.Close();
      }
      this.progressPage = new ProgressUpdate();
      this.progressPage.ClearStatus();
      this.progressPage.Title = AppResources.Read_Radio;
      if (!(bool) System.Windows.Application.Current.Properties[(object) "CommandLineCPS"])
        this.progressPage.Show();
      this.InitializeOpeningConnectionMessageInProgressUpdate();
      if (AppInfoManager.AppView == DifferentiatedUserViewType.Custom)
      {
        this.SavedCurrentViewType = DifferentiatedUserViewType.Custom;
        AppInfoManager.AppView = DifferentiatedUserViewType.Full;
      }
      this.DocumentOperations.InitDocument();
      ((App) System.Windows.Application.Current).TheDocument.FileNew();
      UndoManager.StopUndoRedo();
      UndoManager.Reset();
      ConstraintManager.Suspend();
      if ((bool) System.Windows.Application.Current.Properties[(object) "CommandLineCPS"])
      {
        this.LaunchReadRadio(readWriteTransport);
      }
      else
      {
        this.bgReadWorker = new BackgroundWorker();
        this.bgReadWorker.DoWork += (DoWorkEventHandler) ((s, arg) => this.LaunchReadRadio((int) arg.Argument));
        this.bgReadWorker.RunWorkerAsync((object) readWriteTransport);
      }
    }
  }

  private void InitializeOpeningConnectionMessageInProgressUpdate()
  {
    this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Delegate) new WindowMain.UpdateProgress(this.WindowMain_ProgressUpdate), (object) new ProgressChangedEventArgs(0, (object) new SpecialFeatures.Flashport.FlashRadio.ProgressUserState(SpecialFeatures.Flashport.FlashRadio.UserState.ConnectStart, SpecialFeatures.Flashport.FlashRadio.UserState.None, AppResources.Opening_Connection_To_Radio)));
  }

  internal bool CruncherReadRadio(int myTransport, bool isCruncherWriteCheckPBA = false)
  {
    this.ReadWriteInProgress = true;
    this.DocumentOperations.InitDocument();
    ((App) System.Windows.Application.Current).TheDocument.FileNew();
    UndoManager.StopUndoRedo();
    UndoManager.Reset();
    ConstraintManager.Suspend();
    string empty = string.Empty;
    bool flag = this.LaunchReadRadio(myTransport, ref empty, isCruncherWriteCheckPBA, true);
    if (!string.IsNullOrEmpty(empty) && (empty == AppResources.The_radio_being_read_is_INHIBITED || empty == AppResources.The_radio_being_read_is_KILLED))
      throw new ApplicationException(empty);
    return flag ? flag : throw new ApplicationException("Cannot read the pba file");
  }

  internal void OnRibbonBarWriteRadio(object sender, RoutedEventArgs e)
  {
    AcpUI.Common.Utility.SaveFieldWithFocus();
    this.ribbonBarDeviceWrite.Focus();
    if (this.ReadWriteTransport == 2 && !BluetoothPANIPAddressRule.IsValidBluetoothPANIPAddress(this.txtBTIPAddressForWR.Text))
      AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, $"{AppResources.Invalid_IP_Address}: {this.txtBTIPAddressForWR.Text}");
    else if (this.CpgOpenFlag)
    {
      if (this.PromptQuitOnInvalids().Result)
      {
        SpecialFeatures.Comms.Logger.Log("Codeplug is invalid.");
      }
      else
      {
        if (!this.SaveCodeplug())
          return;
        AppInfoManager.StatusMsgReport.Clear();
        this.ReadWriteInProgress = true;
        if (!this.progressPage.bCommSuccess)
        {
          this.progressPage.Hide();
          this.progressPage.Close();
        }
        this.progressPage = new ProgressUpdate();
        this.progressPage.ClearStatus();
        this.progressPage.Title = AppResources.Write_Radio;
        this.progressPage.Show();
        this.progressPage.Activate();
        this.InitializeOpeningConnectionMessageInProgressUpdate();
        new PackUnpackExecutor().PrePackHandler();
        this.bgWriteWorker = new BackgroundWorker();
        this.bgWriteWorker.DoWork += (DoWorkEventHandler) ((s, arg) => this.LaunchWriteRadio((int) arg.Argument));
        this.bgWriteWorker.RunWorkerAsync((object) this.ReadWriteTransport);
      }
    }
    else
      AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, AppResources.codeplug_must_open_before_writing_radio);
  }

  private void OnRibbonBarIT(object sender, RoutedEventArgs e)
  {
  }

  private void OnRibbonBarAutoIT(object sender, RoutedEventArgs e)
  {
  }

  internal void OnAppMenuRadioManagement(object sender, RoutedEventArgs e)
  {
    try
    {
      if (this.rMCWnd == null)
        this.rMCWnd = new RMCWnd(true);
      this.rMCWnd.Connect();
    }
    catch (CommonException ex)
    {
      throw;
    }
    catch (Exception ex)
    {
      throw SpecialFeatures.CommonExceptionHelper.CreateCommonException(CommonErrorCode.RMC_UnableToInitializeRMC, Motorola.CommonCPS.ResourceRepository.Resources.RMC_UnableToInitializeRMC);
    }
  }

  internal bool OpenCodeplugNonGUI(string sFileName, ref string errorMessage)
  {
    return this.OpenCodeplugNonGUI(sFileName, ref errorMessage, false);
  }

  internal bool OpenCodeplugNonGUI(
    string sFileName,
    string password,
    bool isNonGuiOpen = false,
    bool isSkipPasswordCheck = false)
  {
    bool flag = false;
    MemoryCleaner.CleanGarbageFromMemory();
    try
    {
      try
      {
        try
        {
          new AcpFileHandler().ReadHeaderSafely(sFileName);
          this.cpgFileName = sFileName;
          if (!this.IsSuppotedCodePlugType(sFileName))
            return false;
        }
        catch (Exception ex)
        {
          AcpFileHeader acpFileHeader = new AcpFileHeader();
        }
        if (sFileName.EndsWith(".mc"))
        {
          AppInfoManager.AppVersion = this.cpsVersion;
          flag = ((App) System.Windows.Application.Current).TheDocument.FileOpenSafely(sFileName, (IEnumerable<BinarySerializerTypeInfo>) AllowedTypes.AllowedTypesList);
          int num = (FeatureManager.GetFeature(2045)[0] as Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide).UserInformationAndPasswords.RadWideUserInformationandUserLoginUnitIDEnable_41305_UIValue ? 1 : 0;
          if (flag)
            this.DocumentOperations.UclTemplateNodeInit();
        }
        else if (sFileName.EndsWith(".cxf", StringComparison.OrdinalIgnoreCase))
        {
          using (CodeplugExchangeFile cxfFile = CxfFileHandler.OpenFileAndValidatePassword(sFileName, password))
          {
            if (cxfFile != null && cxfFile.IsFileValid)
            {
              this.DocumentOperations.InitDocument();
              ((App) System.Windows.Application.Current).TheDocument.FileNew();
              UndoManager.StopUndoRedo();
              UndoManager.Reset();
              ConstraintManager.Suspend();
              flag = CxfFileHandler.OpenCodeplugFile(cxfFile.GetCodeplugBytes());
              CxfFileHandler.AssignFirmwareVersionToRadioInfo(cxfFile);
            }
            if (flag)
            {
              this.IsCxfEditingMode = true;
              CodeplugVersionUpdater.SetCodeplugVersion();
              this.ResolveUCLReferenceAfterUnpack();
              this.ResolvedMFKTimerUnpack();
              ((App) System.Windows.Application.Current).TheDocument.docFileName = Path.GetFileName(sFileName);
              ((App) System.Windows.Application.Current).TheDocument.docFilePath = Path.GetFullPath(sFileName);
            }
          }
        }
        else if (sFileName.EndsWith(".xpba"))
        {
          this.DocumentOperations.InitDocument();
          ((App) System.Windows.Application.Current).TheDocument.FileNew();
          UndoManager.StopUndoRedo();
          UndoManager.Reset();
          ConstraintManager.Suspend();
          flag = Cruncher.Instance.UnpackXPBA(sFileName);
          if (flag)
          {
            CodeplugVersionUpdater.SetCodeplugVersion();
            this.ResolveUCLReferenceAfterUnpack();
            this.ResolvedMFKTimerUnpack();
            ((App) System.Windows.Application.Current).TheDocument.docFileName = Path.GetFileName(sFileName);
            ((App) System.Windows.Application.Current).TheDocument.docFilePath = Path.GetFullPath(sFileName);
          }
        }
      }
      catch
      {
        flag = false;
        throw new CommonException(new CommonExceptionData(CommonErrorCode.RMC_File_colon_could_not_be_opened, new string[2]
        {
          Path.GetFileName(sFileName),
          AcpDocument.CpgVersionErrStr
        }));
      }
      if (flag)
      {
        if (!isSkipPasswordCheck && !this.AuthenticateCpgForRWPassword(((App) System.Windows.Application.Current).TheDocument, password, isNonGuiOpen))
        {
          ((App) System.Windows.Application.Current).TheDocument.Clear();
          AppInfoManager.StatusMsgReport.Clear();
          AppInfoManager.InvalidFieldsReport.Clear();
          throw new CommonException(CommonErrorCode.RMC_Invalid_Incorrect_Password);
        }
        ASKConstraints.Initialize();
        try
        {
          Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation radioInformation = FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation;
          string numberA8539Value = radioInformation.General.RadInfoGeneralModelNumber_A8539Value;
          if (numberA8539Value != null || numberA8539Value != "")
            this.MyModelNumber = numberA8539Value;
          this.PostUpgradeCodeplugProccessing(radioInformation.General.RadInfoGeneralCodeplugVersion_A7683.Value, AppInfoManager.AppVersion);
        }
        catch (Exception ex)
        {
        }
        DateTime now1 = DateTime.Now;
        DateTime now2 = DateTime.Now;
        this.objModelTiering = new ModelTiering(this.MyModelNumber, ModelTiering.ActionTypes.OPEN, ModelTiering.TargetTypes.ALL);
        this.objModelTiering.UpdateUtilityMackModelType();
        ConstraintManager.Suspend();
        this.objModelTiering.ApplyTiering();
        if (UtilityMack.bOpenFromRMC)
          LanguagePackHelper.BindingLanguageSections();
        ConstraintManager.Resume();
        this.SetProductModelIdentifierField();
        this.SetDVRSHoptionEnabledField();
        this.SetDVRSHwEnabledField();
        foreach (IAcpConstraints feature in FeatureManager.Features)
          feature.CalculateVisibility(true);
        this.SecureADPKeyDataFixup();
        this.ScanListFixup();
        this.CnvPerTalkgroupListFixUp();
        this.LimitedPatienceTimeFixup();
        this.InitASKProgHistoryRecSet();
        this.InitTrkPerAnnGroup();
        if (this.IsPortableModel)
          this.TxPowerTableInit();
        this.MFKTableInit();
        this.ShepherdsInitForFob();
        this.TriggerMuteToneRefresh();
        if (this.IsMobileModel)
        {
          this.TxPowerTableInitForMobile();
          this.TxPowerNewTableInitForMobile();
          this.BandSplitOverRidingInit();
          this.FixupOneTouchTrunkingSystem();
        }
        int num = this.O9TableInit() ? 1 : 0;
        this.DEKVipTableInit();
        this.PresetZoneChannelTableInit();
        this.BookmarkQuickAccessListInit();
        this.KeypadRecsetAndTableInit();
        this.O2MFKTableInit();
        this.O7MFKTableInit();
        this.O2NavigationControlsTableInit();
        this.O7NavigationControlsTableInit();
        this.E5NavigationControlsTableInit();
        this.O3NavigationControlsTableInit();
        this.O5NavigationControlsTableInit();
        this.O9NavigationControlsTableInit();
        this.KMANavigationControlsTableInit();
        this.SmartKeyFobTableInit();
        this.SideArrowTableInit();
        this.DataButtonInit();
        this.SiteSelectableAlertTableInit();
        this.AlertListTableInit();
        this.FixupAccyButton();
        CodeplugFixups.SetTxPowerLevelMediumAndMediumHighValueSameAsLow(this.CodeplugVersion, this.MyModelNumber);
        this.FixUpTrunkingNotificationButtonForMahalo();
        this.FixUpViqiSecureClearStrapping();
        this.AddQC2DefaultRecord();
        this.expandFlashcode();
        this.SyncASTROOTARAndOTARProfileIndex(FeatureManager.ActiveDocument);
        this.SyncAstroOtarInhibit();
        this.SyncRadioInhibitViaAstroOtar();
        this.SyncAstroInfiniteUKEKRetention(FeatureManager.ActiveDocument);
        this.SyncASTROUserSelectable(FeatureManager.ActiveDocument);
        this.SyncAstroEraseOnPreviousChange(FeatureManager.ActiveDocument);
        ((App) System.Windows.Application.Current).TheDocument.Initialized(false);
        ConstraintManager.Suspend();
        this.SyncE5BottomButton();
        this.updateUnpackedFields(false, (RadioParams) null);
        if (num != 0)
          this.AddO9PhephedRecord();
        this.SyncO9PASirenButtons();
        this.O9DirectionalButtonsFixup();
        this.UpdateAuxControlTable();
        ConstraintManager.Resume();
        this.RefreshScanlistMap();
        this.DataProfileTrunkingGroupIDFixup();
        this.ZoneToZoneCloneFixup();
        this.RunTMSConstraints();
        this.URLTableFixup();
        this.FixUpVIQIVirtualPartnerValueSetToDisabledIfLMR();
        this.FixUpSwitchesValueSetToBlankIfUnprogrammed();
        this.FixUpSetNFPACompliantToTrueIfNFPARadio();
      }
      else
      {
        ((App) System.Windows.Application.Current).TheDocument.FileClose();
        string pattern = "\\b[RBD]\\d{2}\\.\\d{2}\\.\\d{2,3}\\b";
        if (AppInfoManager.NonEngOldCodeplug)
          throw new CommonException(new CommonExceptionData(CommonErrorCode.RMC_File_colon_Cannot_Open_Old_CP_NonEng, new string[1]
          {
            Path.GetFileName(sFileName)
          }));
        if (Regex.Replace(AcpDocument.CpgVersionErrStr, pattern, "{0}").Contains(AcpResources.Codeplug_Req))
          throw new CommonException(new CommonExceptionData(CommonErrorCode.ServiceNotCompatibleWithClientVersion, new string[1]
          {
            AcpDocument.CpgVersionErrStr
          }));
        throw new CommonException(new CommonExceptionData(CommonErrorCode.RMC_File_colon_could_not_be_opened, new string[2]
        {
          Path.GetFileName(sFileName),
          AcpDocument.CpgVersionErrStr
        }));
      }
    }
    catch (Exception ex)
    {
      string message = ex.Message;
      flag = false;
      throw;
    }
    finally
    {
      this._readWritePasswordApp.ClearCachedPasswordValidation();
      UndoManager.Reset();
    }
    return flag;
  }

  internal bool OpenCodeplugNonGUI(
    string sFileName,
    ref string errorMessage,
    bool isSkipPasswordCheck,
    AstroDeviceInfo deviceInfo = null)
  {
    bool flag1 = false;
    MemoryCleaner.CleanGarbageFromMemory();
    string initialDirectory = AcpFileDialog.InitialDirectory;
    try
    {
      AcpOpenFileDialog acpOpenFileDialog = new AcpOpenFileDialog();
      if (VersionInfoHelper.IsDFlagExisted(DFlagType.DASTRO))
        acpOpenFileDialog.Filter = AppResources.Vertex_Codeplug_Filter;
      else
        acpOpenFileDialog.Filter = AppResources.Motorola_Codeplug_Filter;
      acpOpenFileDialog.MultiSelect = false;
      bool flag2 = true;
      AcpFileHeader acpFileHeader = (AcpFileHeader) null;
      if (string.IsNullOrEmpty(sFileName))
      {
        AcpFileHeader fileHeader = new AcpFileHeader();
        AcpFileDialog.InitialDirectory = ((App) System.Windows.Application.Current).TheDocument.docFilePath != null || !(this.lastOpenCodePlugPath != string.Empty) ? ((App) System.Windows.Application.Current).TheDocument.docFilePath : this.lastOpenCodePlugPath;
        if (acpOpenFileDialog.ShowDialogSafely(fileHeader).GetValueOrDefault())
        {
          sFileName = acpOpenFileDialog.FileName;
          this.cpgFileName = sFileName;
          this.lastOpenCodePlugPath = Path.GetDirectoryName(acpOpenFileDialog.FileName);
          if ((int) this.lastOpenCodePlugPath[this.lastOpenCodePlugPath.Length - 1] != (int) Path.DirectorySeparatorChar)
            this.lastOpenCodePlugPath += Path.DirectorySeparatorChar.ToString();
        }
        else
          flag2 = false;
      }
      else
      {
        try
        {
          acpFileHeader = new AcpFileHandler().ReadHeaderSafely(sFileName);
          this.cpgFileName = sFileName;
        }
        catch (Exception ex)
        {
          acpFileHeader = new AcpFileHeader();
        }
      }
      if (flag2)
      {
        if (sFileName.EndsWith(".mc"))
        {
          AppInfoManager.AppVersion = this.cpsVersion;
          flag1 = ((App) System.Windows.Application.Current).TheDocument.FileOpenSafely(sFileName, (IEnumerable<BinarySerializerTypeInfo>) AllowedTypes.AllowedTypesList);
          if (flag1)
            this.DocumentOperations.UclTemplateNodeInit();
        }
        else if (sFileName.EndsWith(".xpba"))
        {
          this.DocumentOperations.InitDocument();
          ((App) System.Windows.Application.Current).TheDocument.FileNew();
          UndoManager.StopUndoRedo();
          UndoManager.Reset();
          ConstraintManager.Suspend();
          flag1 = Cruncher.Instance.UnpackXPBA(sFileName);
          if (flag1)
          {
            this.ResolveUCLReferenceAfterUnpack();
            CodeplugVersionUpdater.SetCodeplugVersion();
            ((App) System.Windows.Application.Current).TheDocument.docFileName = Path.GetFileName(sFileName);
            ((App) System.Windows.Application.Current).TheDocument.docFilePath = Path.GetFullPath(sFileName);
          }
        }
        if (flag1)
        {
          bool passedAuthentication = false;
          try
          {
            Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide codeplgRadioWide = FeatureManager.GetFeature(2045)[0] as Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide;
            if (codeplgRadioWide != null)
            {
              bool flag3 = true;
              if ((bool) System.Windows.Application.Current.Properties[(object) "CommandLineCPS"] | isSkipPasswordCheck)
                flag3 = false;
              if (flag3 && codeplgRadioWide.Labtool.RadWideLabtoolArchiveReadPasswordEnable_A7462Value)
                this.Dispatcher.Invoke((Action) (() => passedAuthentication = this._readWritePasswordApp.ValidateOKToArchiveFile(codeplgRadioWide.Labtool.RadWideLabtoolRadioPassword_A8837Value)));
              else
                passedAuthentication = true;
            }
          }
          catch (Exception ex)
          {
          }
          if (!passedAuthentication)
          {
            ((App) System.Windows.Application.Current).TheDocument.Clear();
            flag1 = false;
          }
          else
          {
            ASKConstraints.Initialize();
            try
            {
              Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation radioInformation = FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation;
              string numberA8539Value = radioInformation.General.RadInfoGeneralModelNumber_A8539Value;
              if (deviceInfo != null)
              {
                radioInformation.General.RadInfoGeneralBootloaderVersion_A7567.Value = deviceInfo.BootloaderVersion;
                radioInformation.General.RadInfoGeneralDSPVersion_A7892.Value = deviceInfo.DspVersion;
                radioInformation.General.RadInfoGeneralFirmwareVersion_A8124.Value = deviceInfo.SoftwareVersion;
                radioInformation.General.RadInfoGeneralPSDTVersion_A8768.Value = deviceInfo.PsdtVersion;
                radioInformation.General.RadInfoGeneralTuningVersion_A9509.Value = deviceInfo.TuneVersion;
                if (!string.IsNullOrEmpty(deviceInfo.MaceFlashVersion))
                  radioInformation.General.RadInfoGeneralUCMVersion_A9591Value = deviceInfo.MaceFlashVersion;
                if (!string.IsNullOrEmpty(deviceInfo.OptionBoardHardwareHostVersion))
                  radioInformation.OptionExpansionBoard.RadInfoOptionExpansionBoardBoardFirmwareVersion_A37048Value = deviceInfo.OptionBoardHardwareHostVersion;
                if (!string.IsNullOrEmpty(deviceInfo.OptionBoardName))
                  radioInformation.OptionExpansionBoard.RadInfoOptionExpansionBoardBoardName_A37549Value = deviceInfo.OptionBoardName;
                if (!string.IsNullOrEmpty(deviceInfo.OptionBoardHardwareType))
                  radioInformation.OptionExpansionBoard.RadInfoOptionExpansionBoardBoardType_A37049Value = deviceInfo.OptionBoardHardwareType;
                if (!string.IsNullOrEmpty(deviceInfo.MaceSecureHardwareType))
                  radioInformation.General.RadInfoGeneralSecureHardwareTypeValue = deviceInfo.MaceSecureHardwareType;
                if (!string.IsNullOrEmpty(deviceInfo.MaceSecureHardwareVersion))
                  radioInformation.General.RadInfoGeneralSecureHardwareVersionValue = deviceInfo.MaceSecureHardwareVersion;
              }
              if (numberA8539Value != null || numberA8539Value != "")
                this.MyModelNumber = numberA8539Value;
              this.PostUpgradeCodeplugProccessing(radioInformation.General.RadInfoGeneralCodeplugVersion_A7683.Value, AppInfoManager.AppVersion);
            }
            catch (Exception ex)
            {
            }
            DateTime now1 = DateTime.Now;
            DateTime now2 = DateTime.Now;
            this.objModelTiering = new ModelTiering(this.MyModelNumber, ModelTiering.ActionTypes.OPEN, ModelTiering.TargetTypes.ALL);
            this.objModelTiering.UpdateUtilityMackModelType();
            ConstraintManager.Suspend();
            this.objModelTiering.ApplyTiering();
            ConstraintManager.Resume();
            this.SetProductModelIdentifierField();
            this.SetDVRSHoptionEnabledField();
            this.SetDVRSHwEnabledField();
            foreach (IAcpConstraints feature in FeatureManager.Features)
              feature.CalculateVisibility(true);
            this.ScanListFixup();
            this.AlertListTableInit();
            this.FixupAccyButton();
            this.FixUpTrunkingNotificationButtonForMahalo();
            this.FixUpViqiSecureClearStrapping();
            CodeplugFixups.SetTxPowerLevelMediumAndMediumHighValueSameAsLow(this.CodeplugVersion, this.MyModelNumber);
            this.CnvPerTalkgroupListFixUp();
            this.InitASKProgHistoryRecSet();
            this.InitTrkPerAnnGroup();
            if (UtilityMack.IsPortablePro)
              this.TxPowerTableInit();
            this.MFKTableInit();
            this.ShepherdsInitForFob();
            this.TriggerMuteToneRefresh();
            if (UtilityMack.IsMobilePro)
            {
              this.TxPowerTableInitForMobile();
              this.TxPowerNewTableInitForMobile();
              this.BandSplitOverRidingInit();
              this.FixupOneTouchTrunkingSystem();
            }
            int num = this.O9TableInit() ? 1 : 0;
            this.DEKVipTableInit();
            this.PresetZoneChannelTableInit();
            this.BookmarkQuickAccessListInit();
            this.KeypadRecsetAndTableInit();
            this.AddQC2DefaultRecord();
            this.expandFlashcode();
            this.SyncASTROOTARAndOTARProfileIndex(FeatureManager.ActiveDocument);
            this.SyncAstroOtarInhibit();
            this.SyncRadioInhibitViaAstroOtar();
            this.SyncAstroInfiniteUKEKRetention(FeatureManager.ActiveDocument);
            this.SyncASTROUserSelectable(FeatureManager.ActiveDocument);
            this.SyncAstroEraseOnPreviousChange(FeatureManager.ActiveDocument);
            ((App) System.Windows.Application.Current).TheDocument.Initialized(false);
            ConstraintManager.Suspend();
            this.SyncE5BottomButton();
            this.updateUnpackedFields(false, (RadioParams) null);
            if (num != 0)
              this.AddO9PhephedRecord();
            this.SyncO9PASirenButtons();
            this.O9DirectionalButtonsFixup();
            this.UpdateAuxControlTable();
            ConstraintManager.Resume();
            this.RefreshScanlistMap();
            this.DataProfileTrunkingGroupIDFixup();
            this.RunTMSConstraints();
            this.URLTableFixup();
            this.FixUpVIQIVirtualPartnerValueSetToDisabledIfLMR();
            this.FixUpSwitchesValueSetToBlankIfUnprogrammed();
            this.FixUpSetNFPACompliantToTrueIfNFPARadio();
          }
        }
        else
        {
          ((App) System.Windows.Application.Current).TheDocument.Clear();
          if (AppInfoManager.NonEngOldCodeplug)
          {
            errorMessage = AppResources.File_colon_Cannot_Open_Old_CP_NonEng.AcpStringFormat((object) Path.GetFileName(sFileName));
          }
          else
          {
            errorMessage = AppResources.File_colon_could_not_be_opened.AcpStringFormat((object) Path.GetFileName(sFileName));
            if (AcpDocument.CpgVersionErrStr != "")
              errorMessage = $"{errorMessage} {AcpDocument.CpgVersionErrStr}";
          }
        }
      }
    }
    catch (Exception ex)
    {
      flag1 = false;
      errorMessage = ex.Message;
    }
    finally
    {
      this._readWritePasswordApp.ClearCachedPasswordValidation();
      if (initialDirectory != AcpFileDialog.InitialDirectory)
        AcpFileDialog.InitialDirectory = initialDirectory;
    }
    return flag1;
  }

  private void DisposeDocumentFeatures(AcpDocument doc)
  {
    foreach (IAcpRecordset feature in doc.Features)
      feature?.Dispose();
  }

  internal void CloseFileNonGUI(bool isForExport = true)
  {
    AcpDocument theDocument = ((App) System.Windows.Application.Current).TheDocument;
    if (theDocument != null)
    {
      theDocument.ModificationLogEnabled = false;
      this.DisposeDocumentFeatures(theDocument);
      theDocument.FileClose();
      if (((App) System.Windows.Application.Current).TheDocument.docFilePath != null)
      {
        this.lastOpenCodePlugPath = Path.GetDirectoryName(((App) System.Windows.Application.Current).TheDocument.docFilePath);
        if ((int) this.lastOpenCodePlugPath[this.lastOpenCodePlugPath.Length - 1] != (int) Path.DirectorySeparatorChar)
          this.lastOpenCodePlugPath += Path.DirectorySeparatorChar.ToString();
        if (this.deviceFromServer != null || this.templateFromServer != null)
        {
          try
          {
            File.Delete(((App) System.Windows.Application.Current).TheDocument.docFilePath);
          }
          catch
          {
          }
          this.DeviceFromServer = (APXRadio) null;
          this.TemplateFromServer = (APXTemplate) null;
        }
      }
      ((App) System.Windows.Application.Current).TheDocument.docFileName = (string) null;
      ((App) System.Windows.Application.Current).TheDocument.docFilePath = (string) null;
    }
    UndoManager.Reset();
    this.objModelTiering = (ModelTiering) null;
    this.Dispatcher.Invoke((Action) (() =>
    {
      if (FlashDataManager.FlashDoc == null)
        return;
      FlashDataManager.FlashDoc.Clear();
    }));
    MemoryCleaner.CleanGarbageFromMemory();
  }

  private void CalculateEditabilityforNonEditableFieldsinRMC()
  {
    Motorola.MackinawCPS.CoreFeatures.DataWide.DataWide dataWide = FeatureManager.GetFeature(2028)[0] as Motorola.MackinawCPS.CoreFeatures.DataWide.DataWide;
    Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide radioWide = FeatureManager.GetFeature(2045)[0] as Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide;
    Motorola.MackinawCPS.CoreFeatures.SecureWide.SecureWide secureWide = FeatureManager.GetFeature(2021)[0] as Motorola.MackinawCPS.CoreFeatures.SecureWide.SecureWide;
    dataWide.General.DataWideGeneralPeerIPAddress1_A8524.CalculateEditability();
    dataWide.General.DataWideGeneralSubscriberIPAddress1_A9222.CalculateEditability();
    dataWide.General.DataWideGeneralBTDUNPeerIPAddress_A41123.CalculateEditability();
    dataWide.General.DataWideGeneralBTDUNSUIPAddress_A41120.CalculateEditability();
    radioWide.Bluetooth.RadWideBluetoothBluetoothEnable_A37028.CalculateEditability();
    radioWide.General.RadWideGeneralASKRequired_A37152.CalculateEditability();
    radioWide.UserInformationAndPasswords.RadWideUserInformationandPINPassword_41303.CalculateEditability();
    radioWide.UserInformationAndPasswords.RadWideUserInformationandUserLoginUnitID_41306.CalculateEditability();
    radioWide.UserInformationAndPasswords.RadWideUserInformationandPasswordsRadioAlias_A8829.CalculateEditability();
    radioWide.UserInformationAndPasswords.RadWideUserInformationandPasswordsSoftIDUsername_A9169.CalculateEditability();
    radioWide.UserInformationAndPasswords.RadWideUserInformationandPasswordsRadioAliasEnable_A8830.CalculateEditability();
    radioWide.UserInformationAndPasswords.RadWideUserInformationandPasswordsSoftIDUsername_A9169.CalculateValidity();
    secureWide.ASTROOTAR.SecWideASTROOTARIndividualASTROOTARRadioID_A8284.CalculateEditability();
    dataWide.General.DataWideGeneralPeerIPAddress1_A8524.CalculateApplicability();
    dataWide.General.DataWideGeneralPeerIPAddress1_A8524.CalculateValidity();
    dataWide.General.DataWideGeneralSubscriberIPAddress1_A9222.CalculateApplicability();
    dataWide.General.DataWideGeneralSubscriberIPAddress1_A9222.CalculateValidity();
    dataWide.General.DataWideGeneralBTDUNPeerIPAddress_A41123.CalculateApplicability();
    dataWide.General.DataWideGeneralBTDUNPeerIPAddress_A41123.CalculateValidity();
    dataWide.General.DataWideGeneralBTDUNSUIPAddress_A41120.CalculateApplicability();
    dataWide.General.DataWideGeneralBTDUNSUIPAddress_A41120.CalculateValidity();
    IAcpRecordset feature1 = FeatureManager.GetFeature(2054);
    for (int index = 0; index < feature1.Count; ++index)
    {
      Motorola.MackinawCPS.CoreFeatures.DataProfiles.DataProfiles dataProfiles = feature1[index] as Motorola.MackinawCPS.CoreFeatures.DataProfiles.DataProfiles;
      if (UtilityMack.bOpenFromRMC)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        dataProfiles.General.DataProfGeneralMobileComputerIPAddress_A8523.IsEditable = WindowMain.\u003C\u003EO.\u003C6\u003E__conNonEditableWhenOpenFromRMC ?? (WindowMain.\u003C\u003EO.\u003C6\u003E__conNonEditableWhenOpenFromRMC = new StateConstraint(DataProfilesConstraints.conNonEditableWhenOpenFromRMC));
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        dataProfiles.General.DataProfGeneralSubscriberIPAddress_A21157.IsEditable = WindowMain.\u003C\u003EO.\u003C6\u003E__conNonEditableWhenOpenFromRMC ?? (WindowMain.\u003C\u003EO.\u003C6\u003E__conNonEditableWhenOpenFromRMC = new StateConstraint(DataProfilesConstraints.conNonEditableWhenOpenFromRMC));
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        dataProfiles.General.DataProfilesGeneralBTDUNSUIPAddress_A41126.IsEditable = WindowMain.\u003C\u003EO.\u003C6\u003E__conNonEditableWhenOpenFromRMC ?? (WindowMain.\u003C\u003EO.\u003C6\u003E__conNonEditableWhenOpenFromRMC = new StateConstraint(DataProfilesConstraints.conNonEditableWhenOpenFromRMC));
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        dataProfiles.General.DataProfilesGeneralBTDUNPeerIPAddress_A41127.IsEditable = WindowMain.\u003C\u003EO.\u003C6\u003E__conNonEditableWhenOpenFromRMC ?? (WindowMain.\u003C\u003EO.\u003C6\u003E__conNonEditableWhenOpenFromRMC = new StateConstraint(DataProfilesConstraints.conNonEditableWhenOpenFromRMC));
      }
      else
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        dataProfiles.General.DataProfGeneralMobileComputerIPAddress_A8523.IsEditable = WindowMain.\u003C\u003EO.\u003C7\u003E__conDataProfileTypeIsConventionalAndAutoGenIpAddrDisabledEditbl ?? (WindowMain.\u003C\u003EO.\u003C7\u003E__conDataProfileTypeIsConventionalAndAutoGenIpAddrDisabledEditbl = new StateConstraint(DataProfilesConstraints.conDataProfileTypeIsConventionalAndAutoGenIpAddrDisabledEditbl));
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        dataProfiles.General.DataProfGeneralSubscriberIPAddress_A21157.IsEditable = WindowMain.\u003C\u003EO.\u003C7\u003E__conDataProfileTypeIsConventionalAndAutoGenIpAddrDisabledEditbl ?? (WindowMain.\u003C\u003EO.\u003C7\u003E__conDataProfileTypeIsConventionalAndAutoGenIpAddrDisabledEditbl = new StateConstraint(DataProfilesConstraints.conDataProfileTypeIsConventionalAndAutoGenIpAddrDisabledEditbl));
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        dataProfiles.General.DataProfilesGeneralBTDUNSUIPAddress_A41126.IsEditable = WindowMain.\u003C\u003EO.\u003C7\u003E__conDataProfileTypeIsConventionalAndAutoGenIpAddrDisabledEditbl ?? (WindowMain.\u003C\u003EO.\u003C7\u003E__conDataProfileTypeIsConventionalAndAutoGenIpAddrDisabledEditbl = new StateConstraint(DataProfilesConstraints.conDataProfileTypeIsConventionalAndAutoGenIpAddrDisabledEditbl));
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        dataProfiles.General.DataProfilesGeneralBTDUNPeerIPAddress_A41127.IsEditable = WindowMain.\u003C\u003EO.\u003C7\u003E__conDataProfileTypeIsConventionalAndAutoGenIpAddrDisabledEditbl ?? (WindowMain.\u003C\u003EO.\u003C7\u003E__conDataProfileTypeIsConventionalAndAutoGenIpAddrDisabledEditbl = new StateConstraint(DataProfilesConstraints.conDataProfileTypeIsConventionalAndAutoGenIpAddrDisabledEditbl));
      }
      dataProfiles.General.DataProfGeneralMobileComputerIPAddress_A8523.CalculateEditability();
      dataProfiles.General.DataProfGeneralSubscriberIPAddress_A21157.CalculateEditability();
      dataProfiles.General.DataProfGeneralSubscriberAirInterfaceIPAddress_A9220.CalculateEditability();
      dataProfiles.General.DataProfilesGeneralBTDUNSUIPAddress_A41126.CalculateEditability();
      dataProfiles.General.DataProfilesGeneralBTDUNPeerIPAddress_A41127.CalculateEditability();
      dataProfiles.General.DataProfGeneralMobileComputerIPAddress_A8523.CalculateApplicability();
      dataProfiles.General.DataProfGeneralMobileComputerIPAddress_A8523.CalculateValidity();
      dataProfiles.General.DataProfGeneralSubscriberIPAddress_A21157.CalculateApplicability();
      dataProfiles.General.DataProfGeneralSubscriberIPAddress_A21157.CalculateValidity();
      dataProfiles.General.DataProfGeneralSubscriberAirInterfaceIPAddress_A9220.CalculateApplicability();
      dataProfiles.General.DataProfGeneralSubscriberAirInterfaceIPAddress_A9220.CalculateValidity();
      dataProfiles.General.DataProfilesGeneralBTDUNSUIPAddress_A41126.CalculateApplicability();
      dataProfiles.General.DataProfilesGeneralBTDUNSUIPAddress_A41126.CalculateValidity();
      dataProfiles.General.DataProfilesGeneralBTDUNPeerIPAddress_A41127.CalculateApplicability();
      dataProfiles.General.DataProfilesGeneralBTDUNPeerIPAddress_A41127.CalculateValidity();
    }
    IAcpRecordset feature2 = FeatureManager.GetFeature(2053);
    for (int index = 0; index < feature2.Count; ++index)
    {
      Motorola.MackinawCPS.CoreFeatures.ConventionalSystem.ConventionalSystem conventionalSystem = feature2[index] as Motorola.MackinawCPS.CoreFeatures.ConventionalSystem.ConventionalSystem;
      conventionalSystem.General.CnvSysGeneralIndividualID_A8287.CalculateEditability();
      conventionalSystem.General.CnvSysGeneralMDCPrimaryID_A8744.CalculateEditability();
    }
    IAcpRecordset feature3 = FeatureManager.GetFeature(2064);
    for (int index = 0; index < feature3.Count; ++index)
      (feature3[index] as Motorola.MackinawCPS.CoreFeatures.TrunkingSystem.TrunkingSystem).General.TrkSysGeneralUnitID_A12651.CalculateEditability();
  }

  private void CalculateValidityforNonEditableFieldsinRMC()
  {
    Motorola.MackinawCPS.CoreFeatures.DataWide.DataWide dataWide = FeatureManager.GetFeature(2028)[0] as Motorola.MackinawCPS.CoreFeatures.DataWide.DataWide;
    Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide radioWide = FeatureManager.GetFeature(2045)[0] as Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide;
    dataWide.General.DataWideGeneralPeerIPAddress1_A8524.CalculateApplicability();
    dataWide.General.DataWideGeneralPeerIPAddress1_A8524.CalculateValidity();
    dataWide.General.DataWideGeneralSubscriberIPAddress1_A9222.CalculateApplicability();
    dataWide.General.DataWideGeneralSubscriberIPAddress1_A9222.CalculateValidity();
    dataWide.General.DataWideGeneralBTDUNPeerIPAddress_A41123.CalculateApplicability();
    dataWide.General.DataWideGeneralBTDUNPeerIPAddress_A41123.CalculateValidity();
    dataWide.General.DataWideGeneralBTDUNSUIPAddress_A41120.CalculateApplicability();
    dataWide.General.DataWideGeneralBTDUNSUIPAddress_A41120.CalculateValidity();
    radioWide.UserInformationAndPasswords.RadWideUserInformationandPasswordsSoftIDUsername_A9169.CalculateValidity();
    IAcpRecordset feature = FeatureManager.GetFeature(2054);
    for (int index = 0; index < feature.Count; ++index)
    {
      Motorola.MackinawCPS.CoreFeatures.DataProfiles.DataProfiles dataProfiles = feature[index] as Motorola.MackinawCPS.CoreFeatures.DataProfiles.DataProfiles;
      dataProfiles.General.DataProfGeneralMobileComputerIPAddress_A8523.CalculateApplicability();
      dataProfiles.General.DataProfGeneralMobileComputerIPAddress_A8523.CalculateValidity();
      dataProfiles.General.DataProfGeneralSubscriberIPAddress_A21157.CalculateApplicability();
      dataProfiles.General.DataProfGeneralSubscriberIPAddress_A21157.CalculateValidity();
      dataProfiles.General.DataProfGeneralSubscriberAirInterfaceIPAddress_A9220.CalculateApplicability();
      dataProfiles.General.DataProfGeneralSubscriberAirInterfaceIPAddress_A9220.CalculateValidity();
      dataProfiles.General.DataProfilesGeneralBTDUNSUIPAddress_A41126.CalculateApplicability();
      dataProfiles.General.DataProfilesGeneralBTDUNSUIPAddress_A41126.CalculateValidity();
      dataProfiles.General.DataProfilesGeneralBTDUNPeerIPAddress_A41127.CalculateApplicability();
      dataProfiles.General.DataProfilesGeneralBTDUNPeerIPAddress_A41127.CalculateValidity();
    }
  }

  private void setKeypadIndexDefaultValue()
  {
    try
    {
      foreach (KeyValuePair<string, string> keyValuePair in new Dictionary<string, string>()
      {
        {
          AcgResources.ID_KEYPADBUTTONONE,
          AppResources.Pattern_1
        },
        {
          AcgResources.ID_KEYPADBUTTONTWO,
          AppResources.Pattern_2
        },
        {
          AcgResources.ID_KEYPADBUTTONTHREE,
          AppResources.Pattern_3
        },
        {
          AcgResources.ID_KEYPADBUTTONSTAR,
          AppResources.Pattern_4
        },
        {
          AcgResources.ID_KEYPADBUTTONZERO,
          AppResources.Pattern_5
        },
        {
          AcgResources.ID_KEYPADBUTTONPOUND,
          AppResources.Pattern_6
        }
      })
      {
        string key = keyValuePair.Key;
        string str = keyValuePair.Value;
        foreach (RelayPatternBCOListListInner bcoListListInner in (Collection<AcpBusinessLayer.FeatureNode>) ((FeatureManager.GetFeature(4003) as ControlHeadO9Recset)[0][10620].EmbeddedRecset as RelayPatternBCOListListInnerRecset))
        {
          if (key == bcoListListInner.RelayPatternBCOListListInnerSection.RdEgoO9DirLtbarPatternBcoListBco_A36661.UIValue)
            bcoListListInner.RelayPatternBCOListListInnerSection.RdEgoO9DirLtbarPatternBcoListIndex_A36707.UIValue = str;
        }
        foreach (KeypadButtonInner keypadButtonInner in (Collection<AcpBusinessLayer.FeatureNode>) ((FeatureManager.GetFeature(4109) as KeypadRecset)[0][10710].EmbeddedRecset as KeypadButtonInnerRecset))
        {
          if (key == keypadButtonInner.KeypadButtonInnerSection.RadErgCtrlKeypadGeneralKeypadBCO_A41070.UIValue)
            keypadButtonInner.KeypadButtonInnerSection.RadErgCtrlKeypadGeneralKeypadButtonIndex_41415.UIValue = str;
        }
      }
    }
    catch (Exception ex)
    {
    }
  }

  private void O2NavigationControlsTableInit()
  {
    if (!(FeatureManager.GetFeature(4115) is ControlHeadO2Recset feature) || !(feature[0][10722].EmbeddedRecset is O2NavigationControlsTableInnerRecset embeddedRecset) || embeddedRecset.Count >= 2)
      return;
    while (embeddedRecset.Count < 2)
      embeddedRecset.AddRecord(embeddedRecset.CreateDefaultRecord());
    if (!(embeddedRecset[1] is O2NavigationControlsTableInner controlsTableInner))
      return;
    O2NavigationControlsTableInnerSection tableInnerSection = controlsTableInner.O2NavigationControlsTableInnerSection;
    tableInnerSection.RadErgoControlO2UpDownButton_A41278.SetValue(144 /*0x90*/);
    tableInnerSection.O2UpDownButtonName_A41277.SetValue(AppResources.Down_Button);
  }

  private void O7NavigationControlsTableInit()
  {
    if (!(FeatureManager.GetFeature(4114) is ControlHeadO7Recset feature) || !(feature[0][10727].EmbeddedRecset is O7NavigationControlsTableInnerRecset embeddedRecset) || embeddedRecset.Count >= 2)
      return;
    while (embeddedRecset.Count < 2)
      embeddedRecset.AddRecord(embeddedRecset.CreateDefaultRecord());
    if (!(embeddedRecset[1] is O7NavigationControlsTableInner controlsTableInner))
      return;
    O7NavigationControlsTableInnerSection tableInnerSection = controlsTableInner.O7NavigationControlsTableInnerSection;
    tableInnerSection.RadErgoControlO7UpDownButton_A41293.SetValue(144 /*0x90*/);
    tableInnerSection.O7UpDownButtonName_A41292.SetValue(AppResources.Down_Button);
  }

  private void E5NavigationControlsTableInit()
  {
    if (!(FeatureManager.GetFeature(4236) is ControlHeadE5Recset feature) || !(feature[0][10896].EmbeddedRecset is E5NavigationControlsTableInnerRecset embeddedRecset) || embeddedRecset.Count >= 2)
      return;
    while (embeddedRecset.Count < 2)
      embeddedRecset.AddRecord(embeddedRecset.CreateDefaultRecord());
    if (!(embeddedRecset[1] is E5NavigationControlsTableInner controlsTableInner))
      return;
    E5NavigationControlsTableInnerSection tableInnerSection = controlsTableInner.E5NavigationControlsTableInnerSection;
    tableInnerSection.RadErgoControlE5UpDownButton_43752.SetValue(144 /*0x90*/);
    tableInnerSection.E5UpDownButtonName_43753.SetValue(AppResources.Down_Button);
  }

  private void O3NavigationControlsTableInit()
  {
    if (!(FeatureManager.GetFeature(2127) is ControlHeadO3Recset feature) || !(feature[0][10732].EmbeddedRecset is O3NavigationControlsTableInnerRecset embeddedRecset) || embeddedRecset.Count >= 2)
      return;
    while (embeddedRecset.Count < 2)
      embeddedRecset.AddRecord(embeddedRecset.CreateDefaultRecord());
    if (!(embeddedRecset[1] is O3NavigationControlsTableInner controlsTableInner))
      return;
    O3NavigationControlsTableInnerSection tableInnerSection = controlsTableInner.O3NavigationControlsTableInnerSection;
    tableInnerSection.RadErgoControlO3NaviControlFeature_A41375.SetValue(144 /*0x90*/);
    tableInnerSection.RadErgoControlO3NaviControlName_A41374.SetValue(AppResources.Down_Button);
  }

  private void O5NavigationControlsTableInit()
  {
    if (!(FeatureManager.GetFeature(2130) is ControlHeadO5Recset feature) || !(feature[0][10735].EmbeddedRecset is O5NavigationControlsTableInnerRecset embeddedRecset) || embeddedRecset.Count >= 2)
      return;
    while (embeddedRecset.Count < 2)
      embeddedRecset.AddRecord(embeddedRecset.CreateDefaultRecord());
    if (!(embeddedRecset[1] is O5NavigationControlsTableInner controlsTableInner))
      return;
    O5NavigationControlsTableInnerSection tableInnerSection = controlsTableInner.O5NavigationControlsTableInnerSection;
    tableInnerSection.RadErgoControlO5NaviControlFeature_A41379.SetValue(144 /*0x90*/);
    tableInnerSection.RadErgoControlO5NaviControlName_A41378.SetValue(AppResources.Down_Button);
  }

  private void KMANavigationControlsTableInit()
  {
    if (!(FeatureManager.GetFeature(2128) is KeypadMicAndAccessoriesRecset feature) || !(feature[0][10753].EmbeddedRecset is KMANavigationControlsTableInnerRecset embeddedRecset) || embeddedRecset.Count >= 2)
      return;
    while (embeddedRecset.Count < 2)
      embeddedRecset.AddRecord(embeddedRecset.CreateDefaultRecord());
    if (!(embeddedRecset[1] is KMANavigationControlsTableInner controlsTableInner))
      return;
    KMANavigationControlsTableInnerSection tableInnerSection = controlsTableInner.KMANavigationControlsTableInnerSection;
    tableInnerSection.RadErgoControlKMAUpDownButton_41760.SetValue(144 /*0x90*/);
    tableInnerSection.RadErgoControlKMANaviControlName_41759.SetValue(AppResources.Down_Button);
  }

  private void O9NavigationControlsTableInit()
  {
    if (!(FeatureManager.GetFeature(4003) is ControlHeadO9Recset feature) || !(feature[0][10731].EmbeddedRecset is O9NavigationControlsTableInnerRecset embeddedRecset) || embeddedRecset.Count >= 2)
      return;
    while (embeddedRecset.Count < 2)
      embeddedRecset.AddRecord(embeddedRecset.CreateDefaultRecord());
    if (!(embeddedRecset[1] is O9NavigationControlsTableInner controlsTableInner))
      return;
    O9NavigationControlsTableInnerSection tableInnerSection = controlsTableInner.O9NavigationControlsTableInnerSection;
    tableInnerSection.RadErgoControlO9NaviControlFeature_A41371.SetValue(144 /*0x90*/);
    tableInnerSection.RadErgoControlO9NaviControlName_A41370.SetValue(AppResources.Down_Button);
  }

  private void SyncO2O3O7O5O9NavigationControls()
  {
    int num1 = 135;
    int num2 = 136;
    if (!(FeatureManager.GetFeature(2013) is ShepherdsRecset feature))
      return;
    foreach (IAcpFeatureNode acpFeatureNode1 in (Collection<AcpBusinessLayer.FeatureNode>) (feature[0][10031].EmbeddedRecset as SignalIndependentProductIndependentNonProgrammableButtonListInnerRecset))
    {
      int num3 = (acpFeatureNode1[10032] as SignalIndependentProductIndependentNonProgrammableButtonListInnerSection).RadErgoCfgSignalIndependentProductIndependentNonProgrammableButtonBCO_A19777.Value;
      if (num3 == num1 || num3 == num2)
      {
        int newValue = (acpFeatureNode1[10032] as SignalIndependentProductIndependentNonProgrammableButtonListInnerSection).RadErgoCfgSignalIndependentProductIndependentNonProgrammableButtonFeature_A19778.Value;
        O2NavigationControlsTableInnerRecset embeddedRecset1 = (FeatureManager.GetFeature(4115) as ControlHeadO2Recset)[0][10722].EmbeddedRecset as O2NavigationControlsTableInnerRecset;
        int num4 = 0;
        foreach (IAcpFeatureNode acpFeatureNode2 in (Collection<AcpBusinessLayer.FeatureNode>) embeddedRecset1)
        {
          ++num4;
          if ((num3 == num1 && num4 == 1 || num3 == num2 && num4 == 2) && (acpFeatureNode2[10725] as O2NavigationControlsTableInnerSection).RadErgoControlO2UpDownButton_A41278.Value != newValue)
            (acpFeatureNode2[10725] as O2NavigationControlsTableInnerSection).RadErgoControlO2UpDownButton_A41278.SetValue(newValue);
        }
        O3NavigationControlsTableInnerRecset embeddedRecset2 = (FeatureManager.GetFeature(2127) as ControlHeadO3Recset)[0][10732].EmbeddedRecset as O3NavigationControlsTableInnerRecset;
        int num5 = 0;
        foreach (IAcpFeatureNode acpFeatureNode3 in (Collection<AcpBusinessLayer.FeatureNode>) embeddedRecset2)
        {
          ++num5;
          if ((num3 == num1 && num5 == 1 || num3 == num2 && num5 == 2) && (acpFeatureNode3[10733] as O3NavigationControlsTableInnerSection).RadErgoControlO3NaviControlFeature_A41375.Value != newValue)
            (acpFeatureNode3[10733] as O3NavigationControlsTableInnerSection).RadErgoControlO3NaviControlFeature_A41375.SetValue(newValue);
        }
        O7NavigationControlsTableInnerRecset embeddedRecset3 = (FeatureManager.GetFeature(4114) as ControlHeadO7Recset)[0][10727].EmbeddedRecset as O7NavigationControlsTableInnerRecset;
        int num6 = 0;
        foreach (IAcpFeatureNode acpFeatureNode4 in (Collection<AcpBusinessLayer.FeatureNode>) embeddedRecset3)
        {
          ++num6;
          if ((num3 == num1 && num6 == 1 || num3 == num2 && num6 == 2) && (acpFeatureNode4[10728] as O7NavigationControlsTableInnerSection).RadErgoControlO7UpDownButton_A41293.Value != newValue)
            (acpFeatureNode4[10728] as O7NavigationControlsTableInnerSection).RadErgoControlO7UpDownButton_A41293.SetValue(newValue);
        }
        O5NavigationControlsTableInnerRecset embeddedRecset4 = (FeatureManager.GetFeature(2130) as ControlHeadO5Recset)[0][10735].EmbeddedRecset as O5NavigationControlsTableInnerRecset;
        int num7 = 0;
        foreach (IAcpFeatureNode acpFeatureNode5 in (Collection<AcpBusinessLayer.FeatureNode>) embeddedRecset4)
        {
          ++num7;
          if ((num3 == num1 && num7 == 1 || num3 == num2 && num7 == 2) && (acpFeatureNode5[10736] as O5NavigationControlsTableInnerSection).RadErgoControlO5NaviControlFeature_A41379.Value != newValue)
            (acpFeatureNode5[10736] as O5NavigationControlsTableInnerSection).RadErgoControlO5NaviControlFeature_A41379.SetValue(newValue);
        }
        KMANavigationControlsTableInnerRecset embeddedRecset5 = (FeatureManager.GetFeature(2128) as KeypadMicAndAccessoriesRecset)[0][10753].EmbeddedRecset as KMANavigationControlsTableInnerRecset;
        int num8 = 0;
        foreach (IAcpFeatureNode acpFeatureNode6 in (Collection<AcpBusinessLayer.FeatureNode>) embeddedRecset5)
        {
          ++num8;
          if ((num3 == num1 && num8 == 1 || num3 == num2 && num8 == 2) && (acpFeatureNode6[10754] as KMANavigationControlsTableInnerSection).RadErgoControlKMAUpDownButton_41760.Value != newValue)
            (acpFeatureNode6[10754] as KMANavigationControlsTableInnerSection).RadErgoControlKMAUpDownButton_41760.SetValue(newValue);
        }
        O9NavigationControlsTableInnerRecset embeddedRecset6 = (FeatureManager.GetFeature(4003) as ControlHeadO9Recset)[0][10731].EmbeddedRecset as O9NavigationControlsTableInnerRecset;
        int num9 = 0;
        foreach (IAcpFeatureNode acpFeatureNode7 in (Collection<AcpBusinessLayer.FeatureNode>) embeddedRecset6)
        {
          ++num9;
          if ((num3 == num1 && num9 == 1 || num3 == num2 && num9 == 2) && (acpFeatureNode7[10734] as O9NavigationControlsTableInnerSection).RadErgoControlO9NaviControlFeature_A41371.Value != newValue)
            (acpFeatureNode7[10734] as O9NavigationControlsTableInnerSection).RadErgoControlO9NaviControlFeature_A41371.SetValue(newValue);
        }
        E5NavigationControlsTableInnerRecset embeddedRecset7 = (FeatureManager.GetFeature(4236) as ControlHeadE5Recset)[0][10896].EmbeddedRecset as E5NavigationControlsTableInnerRecset;
        int num10 = 0;
        foreach (IAcpFeatureNode acpFeatureNode8 in (Collection<AcpBusinessLayer.FeatureNode>) embeddedRecset7)
        {
          ++num10;
          if ((num3 == num1 && num10 == 1 || num3 == num2 && num10 == 2) && (acpFeatureNode8[10897] as E5NavigationControlsTableInnerSection).RadErgoControlE5UpDownButton_43752.Value != newValue)
            (acpFeatureNode8[10897] as E5NavigationControlsTableInnerSection).RadErgoControlE5UpDownButton_43752.SetValue(newValue);
        }
      }
    }
  }

  private void O2MFKTableInit()
  {
    if (!(FeatureManager.GetFeature(4115) is ControlHeadO2Recset feature) || !(feature[0][10721].EmbeddedRecset is O2MFKAssignmentControlInnerRecset embeddedRecset) || embeddedRecset.Count >= 2)
      return;
    while (embeddedRecset.Count < 2)
      embeddedRecset.AddRecord(embeddedRecset.CreateDefaultRecord());
    O2MFKAssignmentControlInnerSection controlInnerSection = (embeddedRecset[1] as O2MFKAssignmentControlInner).O2MFKAssignmentControlInnerSection;
    if (controlInnerSection == null)
      return;
    controlInnerSection.RadErgoControlO2MFKFeatureAssignment_A41275.SetValue(29);
    controlInnerSection.O2MFKAssignmentControlName_A41274.SetValue(AppResources.Secondary_Function);
  }

  private void O7MFKTableInit()
  {
    if (!(FeatureManager.GetFeature(4114) is ControlHeadO7Recset feature) || !(feature[0][10718].EmbeddedRecset is O7MFKAssignmentControlInnerRecset embeddedRecset) || embeddedRecset.Count >= 2)
      return;
    while (embeddedRecset.Count < 2)
      embeddedRecset.AddRecord(embeddedRecset.CreateDefaultRecord());
    O7MFKAssignmentControlInnerSection controlInnerSection = (embeddedRecset[1] as O7MFKAssignmentControlInner).O7MFKAssignmentControlInnerSection;
    if (controlInnerSection == null)
      return;
    controlInnerSection.RadErgoControlO7MFKFeatureAssignment_A41295.SetValue(29);
    controlInnerSection.O7MFKAssignmentControlName_A41294.SetValue(AppResources.Secondary_Function);
  }

  private void SynO2O7MFK()
  {
    IAcpRecordset feature = FeatureManager.GetFeature(2038);
    if (feature == null)
      return;
    foreach (MFKAssignmentControlInner assignmentControlInner in (Collection<AcpBusinessLayer.FeatureNode>) ((feature[0] as Motorola.MackinawCPS.CoreFeatures.Switches.Switches).MultiFunctionKnob.EmbeddedRecset as MFKAssignmentControlInnerRecset))
      this.updateO2O7MFK(assignmentControlInner.MFKAssignmentControlInnerSection.SwitchMFKAssignmentControlName_A38529.Value, assignmentControlInner.MFKAssignmentControlInnerSection.RadErgoControlSwitchsMFKFeatureAssignment_A38514.Value);
  }

  internal void updateO2O7MFK(string name, int curConfigureFeature)
  {
    IAcpRecordset feature = FeatureManager.GetFeature(4114);
    if (feature != null)
    {
      foreach (O7MFKAssignmentControlInner assignmentControlInner in (Collection<AcpBusinessLayer.FeatureNode>) ((feature[0] as Motorola.MackinawCPS.CoreFeatures.ControlHeadO7.ControlHeadO7).O7MultiFunctionKnob.EmbeddedRecset as O7MFKAssignmentControlInnerRecset))
      {
        if (assignmentControlInner.O7MFKAssignmentControlInnerSection.O7MFKAssignmentControlName_A41294Value == name && assignmentControlInner.O7MFKAssignmentControlInnerSection.RadErgoControlO7MFKFeatureAssignment_A41295Value != curConfigureFeature)
        {
          assignmentControlInner.O7MFKAssignmentControlInnerSection.RadErgoControlO7MFKFeatureAssignment_A41295.SetValue(curConfigureFeature);
          break;
        }
      }
    }
    IAcpRecordset acpRecordset = AppInfoManager.AppMode != ApplicationMode.CodeplugComparisonMode ? FeatureManager.GetFeature(4115) : AppInfoManager.ComparatorDocument.GetFeature(4115);
    if (feature == null)
      return;
    foreach (O2MFKAssignmentControlInner assignmentControlInner in (Collection<AcpBusinessLayer.FeatureNode>) ((acpRecordset[0] as Motorola.MackinawCPS.CoreFeatures.ControlHeadO2.ControlHeadO2).O2MultiFunctionKnob.EmbeddedRecset as O2MFKAssignmentControlInnerRecset))
    {
      if (assignmentControlInner.O2MFKAssignmentControlInnerSection.O2MFKAssignmentControlName_A41274Value == name && assignmentControlInner.O2MFKAssignmentControlInnerSection.RadErgoControlO2MFKFeatureAssignment_A41275Value != curConfigureFeature)
      {
        assignmentControlInner.O2MFKAssignmentControlInnerSection.RadErgoControlO2MFKFeatureAssignment_A41275.SetValue(curConfigureFeature);
        break;
      }
    }
  }

  private void SyncDataButton()
  {
    if (!(FeatureManager.GetFeature(2042) is ButtonsRecset feature1))
      return;
    Motorola.MackinawCPS.CoreFeatures.Buttons.DataButtonInnerRecset embeddedRecset1 = feature1[0][10089].EmbeddedRecset as Motorola.MackinawCPS.CoreFeatures.Buttons.DataButtonInnerRecset;
    if (!(FeatureManager.GetFeature(2127) is ControlHeadO3Recset feature2))
      return;
    Motorola.MackinawCPS.CoreFeatures.ControlHeadO3.DataButtonInnerRecset embeddedRecset2 = feature2[0][10234].EmbeddedRecset as Motorola.MackinawCPS.CoreFeatures.ControlHeadO3.DataButtonInnerRecset;
    if (!(FeatureManager.GetFeature(2128) is KeypadMicAndAccessoriesRecset feature3))
      return;
    Motorola.MackinawCPS.CoreFeatures.KeypadMicAndAccessories.DataButtonInnerRecset embeddedRecset3 = feature3[0][10228].EmbeddedRecset as Motorola.MackinawCPS.CoreFeatures.KeypadMicAndAccessories.DataButtonInnerRecset;
    Motorola.MackinawCPS.CoreFeatures.Buttons.DataButtonInnerSection buttonInnerSection1 = embeddedRecset1[0][10090] as Motorola.MackinawCPS.CoreFeatures.Buttons.DataButtonInnerSection;
    Motorola.MackinawCPS.CoreFeatures.ControlHeadO3.DataButtonInnerSection buttonInnerSection2 = embeddedRecset2[0][10212] as Motorola.MackinawCPS.CoreFeatures.ControlHeadO3.DataButtonInnerSection;
    Motorola.MackinawCPS.CoreFeatures.KeypadMicAndAccessories.DataButtonInnerSection buttonInnerSection3 = embeddedRecset3[0][10209] as Motorola.MackinawCPS.CoreFeatures.KeypadMicAndAccessories.DataButtonInnerSection;
    buttonInnerSection2.CntrlHeadO3ConventionalO3DatatButtonFeature_A22595.SetValue(buttonInnerSection1.BtnConventionalButtonDatatButtonFeature_A22610.Value);
    buttonInnerSection2.CntrlHeadO3TrunkingO3DatatButtonFeature_A22597.SetValue(buttonInnerSection1.BtnTrunkingButtonDatatButtonFeature_A22608.Value);
    buttonInnerSection3.RadErgoCfgKMConventionalKMDatatButtonFeature_A22603.SetValue(buttonInnerSection1.BtnConventionalButtonDatatButtonFeature_A22610.Value);
    buttonInnerSection3.RadErgoCfgKMTrunkingKMDatatButtonFeature_A22605.SetValue(buttonInnerSection1.BtnTrunkingButtonDatatButtonFeature_A22608.Value);
    if (!(FeatureManager.GetFeature(4114) is ControlHeadO7Recset feature4))
      return;
    O7DataButtonInnerSection buttonInnerSection4 = (feature4[0][10717].EmbeddedRecset as O7DataButtonInnerRecset)[0][10713] as O7DataButtonInnerSection;
    buttonInnerSection4.RadErgCtrlHeadO7DataButtonCnvFeature_A41299.SetValue(buttonInnerSection1.BtnConventionalButtonDatatButtonFeature_A22610.Value);
    buttonInnerSection4.RadErgCtrlHeadO7DataButtonTrkFeature_A41297.SetValue(buttonInnerSection1.BtnTrunkingButtonDatatButtonFeature_A22608.Value);
  }

  private void UpdateControlHeadEmergencyBtns()
  {
    if (!(FeatureManager.GetFeature(2130) is ControlHeadO5Recset feature))
      return;
    int? nullable = (feature[0][10227].EmbeddedRecset as O5InnerRecset)[0] is O5Inner o5Inner ? o5Inner.O5InnerSection?.CntrlHeadO5SignalIndependentO5M5MXChiefCHButtonButtonFeature_A19754?.Value : new int?();
    if (!nullable.HasValue)
      return;
    this.Update02EmergencyButton(nullable.Value);
    this.Update07EmergencyButton(nullable.Value);
    this.UpdateE5EmergencyButton(nullable.Value);
  }

  private void UpdateE5EmergencyButton(int newValue)
  {
    if (!(FeatureManager.GetFeature(4236) is ControlHeadE5Recset feature) || !((feature[0][10902].EmbeddedRecset as E5InnerRecset)[0][10901] is E5InnerSection e5InnerSection))
      return;
    e5InnerSection.CHE5EmergencyButtonFeature_43768?.SetValue(newValue);
  }

  private void Update07EmergencyButton(int newValue)
  {
    if (!(FeatureManager.GetFeature(4114) is ControlHeadO7Recset feature) || !((feature[0][10719].EmbeddedRecset as O7InnerRecset)[0][10715] is O7InnerSection o7InnerSection))
      return;
    o7InnerSection.CHO7EmergencyButtonFeature_A41291?.SetValue(newValue);
  }

  private void Update02EmergencyButton(int newValue)
  {
    if (!(FeatureManager.GetFeature(4115) is ControlHeadO2Recset feature) || !((feature[0][10723].EmbeddedRecset as O2InnerRecset)[0][10716] is O2InnerSection o2InnerSection))
      return;
    o2InnerSection.CHO2EmergencyButtonFeature_A41272?.SetValue(newValue);
  }

  private void ChangeACAsAllOff()
  {
    try
    {
      if (!(FeatureManager.GetFeature(4008) is ActionConsolidationRecset feature) || feature.Count < 2)
        return;
      Motorola.MackinawCPS.CoreFeatures.ActionConsolidation.General general = (feature[1] as Motorola.MackinawCPS.CoreFeatures.ActionConsolidation.ActionConsolidation).General;
      if (general == null)
        return;
      general.RadioErgoConfigACRelayPattern_A36582.UIValue = MTFResources.All_off;
      general.RadioErgoConfigACSirenType_A36584.UIValue = AcgResources.ID_OFF;
    }
    catch (Exception ex)
    {
    }
  }

  private void SetALLOFFRecord4PursuitButton()
  {
    if (!(FeatureManager.GetFeature(4003) is ControlHeadO9Recset feature) || !(feature[0][10622].EmbeddedRecset is ConsolidatedActionBCOListInnerRecset embeddedRecset))
      return;
    foreach (IAcpFeatureNode acpFeatureNode in (Collection<AcpBusinessLayer.FeatureNode>) embeddedRecset)
    {
      if (134 == (acpFeatureNode[10623] as ConsolidatedActionBCOListInnerSection).RadErgoControlO9ACBCOListBco_A36666.Value)
      {
        (acpFeatureNode[10623] as ConsolidatedActionBCOListInnerSection).RadErgoControlO9ACBCOListIndex_A36668.UIValue = MTFResources.Ac_all_off;
        break;
      }
    }
  }

  private void ConsolidatedActionBCOTableInit()
  {
    if (!(FeatureManager.GetFeature(4003) is ControlHeadO9Recset feature) || !(feature[0][10622].EmbeddedRecset is ConsolidatedActionBCOListInnerRecset embeddedRecset))
      return;
    foreach (IAcpFeatureNode acpFeatureNode in (Collection<AcpBusinessLayer.FeatureNode>) embeddedRecset)
    {
      if (134 == (acpFeatureNode[10623] as ConsolidatedActionBCOListInnerSection).RadErgoControlO9ACBCOListBco_A36666.Value)
      {
        WindowMain.SyncO9ACBCODataButtonIndexToOtherDataButtonIndex((AcpListField) (acpFeatureNode[10623] as ConsolidatedActionBCOListInnerSection).RadErgoControlO9ACBCOListIndex_A36668);
        break;
      }
    }
  }

  internal static void SyncO9ACBCODataButtonIndexToOtherDataButtonIndex(AcpListField srcField)
  {
    Motorola.MackinawCPS.CoreFeatures.KeypadMicAndAccessories.DataButtonInnerRecset buttonInnerRecset1 = (Motorola.MackinawCPS.CoreFeatures.KeypadMicAndAccessories.DataButtonInnerRecset) null;
    if (FeatureManager.GetFeature(2128) is KeypadMicAndAccessoriesRecset feature1)
      buttonInnerRecset1 = feature1[0][10228].EmbeddedRecset as Motorola.MackinawCPS.CoreFeatures.KeypadMicAndAccessories.DataButtonInnerRecset;
    Motorola.MackinawCPS.CoreFeatures.ControlHeadO3.DataButtonInnerRecset buttonInnerRecset2 = (Motorola.MackinawCPS.CoreFeatures.ControlHeadO3.DataButtonInnerRecset) null;
    if (FeatureManager.GetFeature(2127) is ControlHeadO3Recset feature2)
      buttonInnerRecset2 = feature2[0][10234].EmbeddedRecset as Motorola.MackinawCPS.CoreFeatures.ControlHeadO3.DataButtonInnerRecset;
    O7DataButtonInnerRecset buttonInnerRecset3 = (O7DataButtonInnerRecset) null;
    if (FeatureManager.GetFeature(4114) is ControlHeadO7Recset feature3)
      buttonInnerRecset3 = feature3[0][10717].EmbeddedRecset as O7DataButtonInnerRecset;
    O9DataButtonInnerRecset buttonInnerRecset4 = (O9DataButtonInnerRecset) null;
    if (FeatureManager.GetFeature(4003) is ControlHeadO9Recset feature4)
      buttonInnerRecset4 = feature4[0][10611].EmbeddedRecset as O9DataButtonInnerRecset;
    if (buttonInnerRecset1 != null)
    {
      foreach (IAcpFeatureNode acpFeatureNode in (Collection<AcpBusinessLayer.FeatureNode>) buttonInnerRecset1)
      {
        if (srcField.Value != (acpFeatureNode[10209] as Motorola.MackinawCPS.CoreFeatures.KeypadMicAndAccessories.DataButtonInnerSection).RadErgoCfgKMConventionalKMDatatButtonIndex_A41423.Value)
          (acpFeatureNode[10209] as Motorola.MackinawCPS.CoreFeatures.KeypadMicAndAccessories.DataButtonInnerSection).RadErgoCfgKMConventionalKMDatatButtonIndex_A41423.UIValue = srcField.UIValue;
        if (srcField.Value != (acpFeatureNode[10209] as Motorola.MackinawCPS.CoreFeatures.KeypadMicAndAccessories.DataButtonInnerSection).RadErgoCfgKMTrunkingKMDatatButtonIndex_A41424.Value)
          (acpFeatureNode[10209] as Motorola.MackinawCPS.CoreFeatures.KeypadMicAndAccessories.DataButtonInnerSection).RadErgoCfgKMTrunkingKMDatatButtonIndex_A41424.UIValue = srcField.UIValue;
      }
    }
    if (buttonInnerRecset2 != null)
    {
      foreach (IAcpFeatureNode acpFeatureNode in (Collection<AcpBusinessLayer.FeatureNode>) buttonInnerRecset2)
      {
        if (srcField.Value != (acpFeatureNode[10212] as Motorola.MackinawCPS.CoreFeatures.ControlHeadO3.DataButtonInnerSection).CHO3DataButtonConvIndex_A41419.Value)
          (acpFeatureNode[10212] as Motorola.MackinawCPS.CoreFeatures.ControlHeadO3.DataButtonInnerSection).CHO3DataButtonConvIndex_A41419.UIValue = srcField.UIValue;
        if (srcField.Value != (acpFeatureNode[10212] as Motorola.MackinawCPS.CoreFeatures.ControlHeadO3.DataButtonInnerSection).CHO3DataButtonTrkIndex_A41420.Value)
          (acpFeatureNode[10212] as Motorola.MackinawCPS.CoreFeatures.ControlHeadO3.DataButtonInnerSection).CHO3DataButtonTrkIndex_A41420.UIValue = srcField.UIValue;
      }
    }
    if (buttonInnerRecset3 != null)
    {
      foreach (IAcpFeatureNode acpFeatureNode in (Collection<AcpBusinessLayer.FeatureNode>) buttonInnerRecset3)
      {
        if (srcField.Value != (acpFeatureNode[10713] as O7DataButtonInnerSection).CHO7DataButtonConvIndex_A41417.Value)
          (acpFeatureNode[10713] as O7DataButtonInnerSection).CHO7DataButtonConvIndex_A41417.UIValue = srcField.UIValue;
        if (srcField.Value != (acpFeatureNode[10713] as O7DataButtonInnerSection).CHO7DataButtonTrkIndex_A41418.Value)
          (acpFeatureNode[10713] as O7DataButtonInnerSection).CHO7DataButtonTrkIndex_A41418.UIValue = srcField.UIValue;
      }
    }
    if (buttonInnerRecset4 == null)
      return;
    foreach (IAcpFeatureNode acpFeatureNode in (Collection<AcpBusinessLayer.FeatureNode>) buttonInnerRecset4)
    {
      if (srcField.Value != (acpFeatureNode[10608] as O9DataButtonInnerSection).CHO9DataButtonConvIndex_A41414.Value)
        (acpFeatureNode[10608] as O9DataButtonInnerSection).CHO9DataButtonConvIndex_A41414.UIValue = srcField.UIValue;
      if (srcField.Value != (acpFeatureNode[10608] as O9DataButtonInnerSection).CHO9DataButtonTrkIndex_A41416.Value)
        (acpFeatureNode[10608] as O9DataButtonInnerSection).CHO9DataButtonTrkIndex_A41416.UIValue = srcField.UIValue;
    }
  }

  private void WindowMain_Drop(object sender, System.Windows.DragEventArgs e)
  {
    if (e == null || e.Data == null || (Array) e.Data.GetData(System.Windows.DataFormats.FileDrop) == null)
      return;
    string fileName = ((Array) e.Data.GetData(System.Windows.DataFormats.FileDrop)).GetValue(0).ToString();
    FocusManager.SetFocusedElement((DependencyObject) this, (IInputElement) this);
    if ((fileName.EndsWith(".mc") || fileName.EndsWith(".cxf", StringComparison.OrdinalIgnoreCase)) && this.Focus())
      this.OpenCodeplug(fileName);
    else
      AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, AppResources.could_not_be_opened);
  }

  public void WindowMain_AllowDrop(object sender, System.Windows.Input.MouseEventArgs e)
  {
    this.AllowDrop = AppInfoManager.AppMode == ApplicationMode.CodeplugConfigurationMode && !this.CpgOpenFlag && this.BlockFlashReadRadio;
  }

  public bool WindowMainAllowDrop
  {
    get
    {
      this.WindowMain_AllowDrop((object) null, (System.Windows.Input.MouseEventArgs) null);
      return this.AllowDrop;
    }
  }

  public void HandleInValidFieldBackwardCompatibilityForMCFile()
  {
    System.Collections.Generic.List<IAcpField> acpFieldList = new System.Collections.Generic.List<IAcpField>();
    foreach (IAcpField allField in AppInfoManager.InvalidFieldsReport.AllFields)
      acpFieldList.Add(allField);
    foreach (IAcpConstraints acpConstraints in acpFieldList)
      acpConstraints.CalculateValidity();
  }

  private void SmartKeyFobTableInit()
  {
    if (!(FeatureManager.GetFeature(4130) is SmartKeyFobRecset feature) || feature.Count <= 0 || !(feature[0][10747].EmbeddedRecset is SmartKeyFobButtonTableInnerRecset embeddedRecset) || embeddedRecset.Count >= 6)
      return;
    while (embeddedRecset.Count < 6)
      embeddedRecset.AddRecord(embeddedRecset.CreateDefaultRecord());
    string[] strArray = new string[6]
    {
      MTFResources.Lock_up,
      MTFResources.Lock_down,
      MTFResources.Unlock_up,
      MTFResources.Unlock_down,
      MTFResources.Unlock_trunk,
      AcgResources.ID_ALARM
    };
    int[] numArray1 = new int[6]
    {
      87,
      88,
      64 /*0x40*/,
      65,
      211,
      35
    };
    int[] numArray2 = new int[6]
    {
      87,
      88,
      64 /*0x40*/,
      65,
      211,
      35
    };
    Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation radioInformation = FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation;
    bool flag1 = radioInformation.Labtool.RadInfoLabtoolFrontDisplayFullKeypad_A23985.Value;
    bool flag2 = radioInformation.Labtool.RadInfoLabtoolQA01768EnhancedZoneBank_A37209.Value;
    if ((this.MyModelNumber.Equals("H99QDD9PW5AN") || this.MyModelNumber.Equals("H99KGD9PW5AN") || this.MyModelNumber.Equals("H99UCD9PW5AN") || this.MyModelNumber.Equals("H98UCD9PW5AN") || this.MyModelNumber.Equals("H98QDD9PW5AN") || this.MyModelNumber.Equals("H98SDD9PW5AN") || this.MyModelNumber.Equals("H98KGD9PW5AN") || this.MyModelNumber.Equals("H49TGD9PW1AN") && !flag1) && !flag2)
    {
      numArray1[0] = 87;
      numArray1[1] = 88;
      numArray1[2] = 35;
      numArray1[3] = 35;
      numArray1[4] = 211;
      numArray1[5] = 35;
      numArray2[0] = 87;
      numArray2[1] = 88;
      numArray2[2] = 35;
      numArray2[3] = 35;
      numArray2[4] = 211;
      numArray2[5] = 35;
    }
    for (int index = 0; index < 6; ++index)
    {
      SmartKeyFobButtonTableInnerSection tableInnerSection = (embeddedRecset[index] as SmartKeyFobButtonTableInner).SmartKeyFobButtonTableInnerSection;
      tableInnerSection.RadErgoCfgFobButtonName_A41573.SetValue(strArray[index]);
      tableInnerSection.RadErgoCfgFobConventionalBCO_A41577.SetValue(Motorola.MackinawCPS.CoreFeatures.SmartKeyFob.LOVs.indexRadErgoCfgFobConventionalBCO_A41577LovStrs[index]);
      tableInnerSection.RadErgoCfgFobTrunkingBCO_A41578.SetValue(Motorola.MackinawCPS.CoreFeatures.SmartKeyFob.LOVs.indexRadErgoCfgFobTrunkingBCO_A41578LovStrs[index]);
      tableInnerSection.RadErgoCfgFobConventionalFeature_A41574.SetValue(numArray1[index]);
      tableInnerSection.RadErgoCfgFobTrunkingFeature_A41575.SetValue(numArray2[index]);
    }
  }

  private void SideArrowTableInit()
  {
    if (FeatureManager.GetFeature(2042) is ButtonsRecset feature && feature.Count > 0 && feature[0][10745].EmbeddedRecset is PortableSideUpDownArrowButtonInnerRecset embeddedRecset1 && embeddedRecset1.Count < 2)
    {
      while (embeddedRecset1.Count < 2)
        embeddedRecset1.AddRecord(embeddedRecset1.CreateDefaultRecord());
      PortableSideUpDownArrowButtonInnerSection buttonInnerSection1 = (embeddedRecset1[0] as PortableSideUpDownArrowButtonInner).PortableSideUpDownArrowButtonInnerSection;
      buttonInnerSection1.BtnSideArrowButtonName_A41567.SetValue(AcgResources.ID_UPARROW);
      buttonInnerSection1.BtnSideUpDownArrowButtonMFBBCO_A41633.SetValue(99);
      buttonInnerSection1.BtnSideUpDownArrowButtonPrimaryFunction_A41568.SetValue(64 /*0x40*/);
      buttonInnerSection1.BtnSideUpDownArrowButtonSecondaryFunction_A41592.SetValue(87);
      PortableSideUpDownArrowButtonInnerSection buttonInnerSection2 = (embeddedRecset1[1] as PortableSideUpDownArrowButtonInner).PortableSideUpDownArrowButtonInnerSection;
      buttonInnerSection2.BtnSideArrowButtonName_A41567.SetValue(AcgResources.ID_DOWNARROW);
      buttonInnerSection2.BtnSideUpDownArrowButtonMFBBCO_A41633.SetValue(100);
      buttonInnerSection2.BtnSideUpDownArrowButtonPrimaryFunction_A41568.SetValue(65);
      buttonInnerSection2.BtnSideUpDownArrowButtonSecondaryFunction_A41592.SetValue(88);
    }
    if (!UtilityMack.IsPortableOnly() || !((FeatureManager.GetFeature(2013) as ShepherdsRecset)[0][10031].EmbeddedRecset is SignalIndependentProductIndependentNonProgrammableButtonListInnerRecset embeddedRecset2) || embeddedRecset2.Count >= 29)
      return;
    while (embeddedRecset2.Count < 29)
      embeddedRecset2.AddRecord(embeddedRecset2.CreateDefaultRecord());
    SignalIndependentProductIndependentNonProgrammableButtonListInner programmableButtonListInner1 = embeddedRecset2[26] as SignalIndependentProductIndependentNonProgrammableButtonListInner;
    SignalIndependentProductIndependentNonProgrammableButtonListInner programmableButtonListInner2 = embeddedRecset2[27] as SignalIndependentProductIndependentNonProgrammableButtonListInner;
    SignalIndependentProductIndependentNonProgrammableButtonListInner programmableButtonListInner3 = embeddedRecset2[28] as SignalIndependentProductIndependentNonProgrammableButtonListInner;
    if (programmableButtonListInner1 != null)
    {
      programmableButtonListInner1.SignalIndependentProductIndependentNonProgrammableButtonListInnerSection.RadErgoCfgSignalIndependentProductIndependentNonProgrammableButtonBCO_A19777.SetValue(99);
      if (UtilityMack.ProductModelId.Equals("APX3000"))
        programmableButtonListInner1.SignalIndependentProductIndependentNonProgrammableButtonListInnerSection.RadErgoCfgSignalIndependentProductIndependentNonProgrammableButtonFeature_A19778.SetValue(230);
      else
        programmableButtonListInner1.SignalIndependentProductIndependentNonProgrammableButtonListInnerSection.RadErgoCfgSignalIndependentProductIndependentNonProgrammableButtonFeature_A19778.SetValue(38);
    }
    if (programmableButtonListInner2 != null)
    {
      programmableButtonListInner2.SignalIndependentProductIndependentNonProgrammableButtonListInnerSection.RadErgoCfgSignalIndependentProductIndependentNonProgrammableButtonBCO_A19777.SetValue(100);
      if (UtilityMack.ProductModelId.Equals("APX3000"))
        programmableButtonListInner2.SignalIndependentProductIndependentNonProgrammableButtonListInnerSection.RadErgoCfgSignalIndependentProductIndependentNonProgrammableButtonFeature_A19778.SetValue(230);
      else
        programmableButtonListInner2.SignalIndependentProductIndependentNonProgrammableButtonListInnerSection.RadErgoCfgSignalIndependentProductIndependentNonProgrammableButtonFeature_A19778.SetValue(38);
    }
    if (programmableButtonListInner3 == null)
      return;
    programmableButtonListInner3.SignalIndependentProductIndependentNonProgrammableButtonListInnerSection.RadErgoCfgSignalIndependentProductIndependentNonProgrammableButtonBCO_A19777.SetValue(46);
    programmableButtonListInner3.SignalIndependentProductIndependentNonProgrammableButtonListInnerSection.RadErgoCfgSignalIndependentProductIndependentNonProgrammableButtonFeature_A19778.SetValue(231);
  }

  private void DataButtonInit()
  {
    string numberA8539UiValue = (FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation).General.RadInfoGeneralModelNumber_A8539_UIValue;
    if (!UtilityMack.IsPortableOnly() || !((FeatureManager.GetFeature(2013) as ShepherdsRecset)[0][10031].EmbeddedRecset is SignalIndependentProductIndependentNonProgrammableButtonListInnerRecset embeddedRecset) || embeddedRecset.Count >= 30)
      return;
    while (embeddedRecset.Count < 30)
      embeddedRecset.AddRecord(embeddedRecset.CreateDefaultRecord());
    if (!(embeddedRecset[29] is SignalIndependentProductIndependentNonProgrammableButtonListInner programmableButtonListInner))
      return;
    programmableButtonListInner.SignalIndependentProductIndependentNonProgrammableButtonListInnerSection.RadErgoCfgSignalIndependentProductIndependentNonProgrammableButtonBCO_A19777.SetValue(141);
    if (UtilityMack.IsAPX1000With2Knobs && (numberA8539UiValue.Equals("H92UCF9PW6AN") || numberA8539UiValue.Equals("H92QDF9PW6AN") || numberA8539UiValue.Equals("H92SDF9PW6AN") || numberA8539UiValue.Equals("H92KDF9PW6AN") || numberA8539UiValue.Equals("H92WCF9PW6AN") || numberA8539UiValue.Equals("H92UCH9PW7AN") || numberA8539UiValue.Equals("H92QDH9PW7AN") || numberA8539UiValue.Equals("H92SDH9PW7AN") || numberA8539UiValue.Equals("H92KDH9PW7AN") || numberA8539UiValue.Equals("H92WCH9PW7AN")))
      programmableButtonListInner.SignalIndependentProductIndependentNonProgrammableButtonListInnerSection.RadErgoCfgSignalIndependentProductIndependentNonProgrammableButtonFeature_A19778.SetValue(263);
    else if (numberA8539UiValue.StartsWith("H93KDF9PW6AN") || numberA8539UiValue.StartsWith("H93QDF9PW6AN") || numberA8539UiValue.StartsWith("H93SDF9PW6AN") || numberA8539UiValue.StartsWith("H93KDH9PW7AN") || numberA8539UiValue.StartsWith("H93QDH9PW7AN") || numberA8539UiValue.StartsWith("H93SDH9PW7AN"))
      programmableButtonListInner.SignalIndependentProductIndependentNonProgrammableButtonListInnerSection.RadErgoCfgSignalIndependentProductIndependentNonProgrammableButtonFeature_A19778.SetValue(263);
    else
      programmableButtonListInner.SignalIndependentProductIndependentNonProgrammableButtonListInnerSection.RadErgoCfgSignalIndependentProductIndependentNonProgrammableButtonFeature_A19778.SetValue(38);
  }

  private void ZoneToZoneCloneFixup(ContainerTask Task = null)
  {
    if (AppInfoManager.AppMode == ApplicationMode.CodeplugComparisonMode)
      return;
    Motorola.MackinawCPS.CoreFeatures.RadioWide.Features features = FeatureManager.GetFeature(2045)[0][10105] as Motorola.MackinawCPS.CoreFeatures.RadioWide.Features;
    ZoneChannelAssignmentRecset feature1 = FeatureManager.GetFeature(2051) as ZoneChannelAssignmentRecset;
    Motorola.MackinawCPS.CoreFeatures.ZoneChannelAssignment.ZoneChannelAssignment featureNode1 = feature1[0] as Motorola.MackinawCPS.CoreFeatures.ZoneChannelAssignment.ZoneChannelAssignment;
    bool flag1 = features.RadWideFeaturesZoneCloneEnable_43130.Value;
    bool flag2 = false;
    foreach (Motorola.MackinawCPS.CoreFeatures.ZoneChannelAssignment.ZoneChannelAssignment channelAssignment in (Collection<AcpBusinessLayer.FeatureNode>) feature1)
    {
      if (channelAssignment.Zone.ZnChanCfgZoneZoneCloningEnable_43119.Value)
      {
        flag2 = true;
        break;
      }
    }
    if (flag1 | flag2)
    {
      if (FeatureManager.GetFeature(2062) is ASTROTalkgroupListRecset feature2 && feature2.Count > 0)
      {
        Permissions newValue = Permissions.Undeletable | Permissions.DragDisabled | Permissions.DropBeforeDisabled | Permissions.InsertBeforeDisabeled | Permissions.RefernceDisabled;
        if (Task != null)
        {
          Task.AddTask((UndoableTask) new ChangePermissionsTask(feature2[0], newValue));
          Task.AddTask((UndoableTask) new ChangeMinTask((IAcpRecordset) feature2, 2));
        }
        else
        {
          feature2[0].Permissions = newValue;
          feature2.Min = 2;
        }
      }
      if (FeatureManager.GetFeature(2053) is ConventionalSystemRecset feature3 && feature3.Count > 0)
      {
        Permissions newValue = Permissions.Undeletable | Permissions.DragDisabled | Permissions.DropBeforeDisabled | Permissions.InsertBeforeDisabeled | Permissions.RefernceDisabled;
        if (Task != null)
        {
          Task.AddTask((UndoableTask) new ChangePermissionsTask(feature3[0], newValue));
          Task.AddTask((UndoableTask) new ChangeMinTask((IAcpRecordset) feature3, 2));
        }
        else
        {
          feature3[0].Permissions = newValue;
          feature3.Min = 2;
        }
      }
    }
    else
    {
      if (FeatureManager.GetFeature(2062) is ASTROTalkgroupListRecset feature4 && feature4.Count > 0)
      {
        Permissions newValue = Permissions.None;
        if (Task != null)
        {
          Task.AddTask((UndoableTask) new ChangePermissionsTask(feature4[0], newValue));
          Task.AddTask((UndoableTask) new ChangeMinTask((IAcpRecordset) feature4, 1));
          Task.AddTask((UndoableTask) new ChangePermissionsTask((IAcpFeatureNode) featureNode1, newValue));
        }
        else
        {
          feature4[0].Permissions = newValue;
          feature4.Min = 1;
          featureNode1.Permissions = newValue;
        }
      }
      if (FeatureManager.GetFeature(2053) is ConventionalSystemRecset feature5 && feature5.Count > 0)
      {
        Permissions newValue = Permissions.None;
        if (Task != null)
        {
          Task.AddTask((UndoableTask) new ChangePermissionsTask(feature5[0], newValue));
          Task.AddTask((UndoableTask) new ChangeMinTask((IAcpRecordset) feature5, 1));
        }
        else
        {
          feature5[0].Permissions = newValue;
          feature5.Min = 1;
        }
      }
    }
    int num1 = 0;
    int num2 = 0;
    for (int index1 = 0; index1 < feature1.Count; ++index1)
    {
      Zone zone = (feature1[index1] as Motorola.MackinawCPS.CoreFeatures.ZoneChannelAssignment.ZoneChannelAssignment).Zone;
      if (zone.ZnChanCfgZoneZoneCloningEnable_43119.Value)
      {
        ++num2;
        Permissions newValue1 = Permissions.Undeletable | Permissions.RefernceDisabled | Permissions.CopyDisabled | Permissions.AddCurrentDisabled;
        if (Task != null)
          Task.AddTask((UndoableTask) new ChangePermissionsTask(feature1[index1], newValue1));
        else
          feature1[index1].Permissions = newValue1;
        if (zone.ZnChanCfgZoneDynamicZoneEnable_A41257.Value)
          ++num1;
        else if ((feature1[index1] as Motorola.MackinawCPS.CoreFeatures.ZoneChannelAssignment.ZoneChannelAssignment).Channels.EmbeddedRecset is ChannelAssignmentListInnerRecset embeddedRecset1)
        {
          Permissions newValue2 = Permissions.AddDefaultDisabled | Permissions.AddCurrentDisabled;
          if (Task != null)
            Task.AddTask((UndoableTask) new ChangePermissionsTask((IAcpRecordset) embeddedRecset1, newValue2));
          else
            embeddedRecset1.Permissions = newValue2;
          for (int index2 = 0; index2 < embeddedRecset1.Count; ++index2)
          {
            if (embeddedRecset1[index2] is ChannelAssignmentListInner featureNode2)
            {
              Permissions newValue3 = Permissions.Undeletable | Permissions.DragDisabled | Permissions.DropBeforeDisabled | Permissions.InsertBeforeDisabeled;
              if (Task != null)
                Task.AddTask((UndoableTask) new ChangePermissionsTask((IAcpFeatureNode) featureNode2, newValue3));
              else
                featureNode2.Permissions = newValue3;
              AcpBusinessLayer.FeatureNode referencedNode = featureNode2.ChannelAssignmentListInnerSection.ZnChanCfgChannelsPersonality_A8698.ReferencedNode;
              if (referencedNode != null)
              {
                Permissions newValue4 = Permissions.Undeletable | Permissions.DragDisabled | Permissions.DropBeforeDisabled | Permissions.InsertBeforeDisabeled | Permissions.RefernceDisabled;
                if (Task != null)
                  Task.AddTask((UndoableTask) new ChangePermissionsTask((IAcpFeatureNode) referencedNode, newValue4));
                else
                  referencedNode.Permissions = newValue4;
                FrequencyOptionsInnerRecset embeddedRecset = (referencedNode as Motorola.MackinawCPS.CoreFeatures.ConventionalPersonality.ConventionalPersonality).FrequencyOptions.EmbeddedRecset as FrequencyOptionsInnerRecset;
                Permissions newValue5 = Permissions.AddDefaultDisabled | Permissions.AddCurrentDisabled;
                if (Task != null)
                  Task.AddTask((UndoableTask) new ChangePermissionsTask((IAcpRecordset) embeddedRecset, newValue5));
                else
                  embeddedRecset.Permissions = newValue5;
              }
            }
          }
        }
      }
    }
    IAcpRecordset feature6 = FeatureManager.GetFeature(2059);
    int newValue6 = 1 + num2 * 16 /*0x10*/;
    int newValue7 = feature6.Max - num1 * 16 /*0x10*/;
    if (Task != null)
    {
      Task.AddTask((UndoableTask) new ChangeMinTask(feature6, newValue6));
      Task.AddTask((UndoableTask) new ChangeMaxTask(feature6, newValue7));
    }
    else
    {
      ConventionalPersonalityRecset._Min = newValue6;
      ConventionalPersonalityRecset._Max = newValue7;
    }
    if (!flag1)
      return;
    if (!(FeatureManager.GetFeature(2051) is ZoneChannelAssignmentRecset feature7))
      return;
    foreach (IAcpFeatureNode acpFeatureNode in (Collection<AcpBusinessLayer.FeatureNode>) feature7)
    {
      if (acpFeatureNode != null && (acpFeatureNode as Motorola.MackinawCPS.CoreFeatures.ZoneChannelAssignment.ZoneChannelAssignment).Zone != null && (acpFeatureNode as Motorola.MackinawCPS.CoreFeatures.ZoneChannelAssignment.ZoneChannelAssignment).Zone.ZnChanCfgZoneZoneCloningEnable_43119 != null)
        (acpFeatureNode as Motorola.MackinawCPS.CoreFeatures.ZoneChannelAssignment.ZoneChannelAssignment).Zone.ZnChanCfgZoneZoneCloningEnable_43119.CallConstraints();
    }
  }

  private void FixupAccyButton()
  {
    if (!(FeatureManager.GetFeature(2036) is RemoteSpeakerMicRecset feature) || feature.Count <= 0 || !(feature[0][10079].EmbeddedRecset is RSMButtonInnerRecset embeddedRecset) || embeddedRecset.Count <= 0)
      return;
    if (embeddedRecset.Count < 5)
    {
      System.Collections.Generic.List<int> intList = new System.Collections.Generic.List<int>();
      for (int index = 0; index < embeddedRecset.Count; ++index)
      {
        int num = (embeddedRecset[index] as RSMButtonInner).RSMButtonInnerSection.RadErgoCfgRSMConventionalBCO_A19639.Value;
        intList.Add(num);
      }
      if (intList.IndexOf(102) != -1)
        return;
      embeddedRecset.AddRecord(embeddedRecset.CreateDefaultRecord());
      (embeddedRecset[embeddedRecset.Count - 1] as RSMButtonInner).RSMButtonInnerSection.RadErgoCfgRSMButtonName_A22527Value = MTFResources.Accy_3Dot;
      (embeddedRecset[embeddedRecset.Count - 1] as RSMButtonInner).RSMButtonInnerSection.RadErgoCfgRSMConventionalBCO_A19639.SetValue(102);
      (embeddedRecset[embeddedRecset.Count - 1] as RSMButtonInner).RSMButtonInnerSection.RadErgoCfgRSMlConventionalFeature_A19640.SetValue(35);
      (embeddedRecset[embeddedRecset.Count - 1] as RSMButtonInner).RSMButtonInnerSection.RadErgoCfgRSMTrunkingBCO_A19741.SetValue(102);
      (embeddedRecset[embeddedRecset.Count - 1] as RSMButtonInner).RSMButtonInnerSection.RadErgoCfgRSMlTrunkingFeature_A19742.SetValue(35);
    }
    else
    {
      if ((embeddedRecset[4] as RSMButtonInner).RSMButtonInnerSection.RadErgoCfgRSMConventionalBCO_A19639.Value == 151)
      {
        (embeddedRecset[4] as RSMButtonInner).RSMButtonInnerSection.RadErgoCfgRSMConventionalBCO_A19639.SetValue(102);
        (embeddedRecset[4] as RSMButtonInner).RSMButtonInnerSection.RadErgoCfgRSMlConventionalFeature_A19640.SetValue(35);
      }
      if ((embeddedRecset[4] as RSMButtonInner).RSMButtonInnerSection.RadErgoCfgRSMTrunkingBCO_A19741.Value != 151)
        return;
      (embeddedRecset[4] as RSMButtonInner).RSMButtonInnerSection.RadErgoCfgRSMTrunkingBCO_A19741.SetValue(102);
      (embeddedRecset[4] as RSMButtonInner).RSMButtonInnerSection.RadErgoCfgRSMlTrunkingFeature_A19742.SetValue(35);
    }
  }

  private void FixupConfigurablePresetZoneChannel()
  {
    string versionA7683UiValue = (FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation).General.RadInfoGeneralCodeplugVersion_A7683_UIValue;
    if (versionA7683UiValue.Length < 3 || !(versionA7683UiValue.Substring(1, 2) == "28") && !(versionA7683UiValue.Substring(1, 2) == "29") && !(versionA7683UiValue.Substring(1, 2) == "30") || !(FeatureManager.GetFeature(2033)[0] is Motorola.MackinawCPS.CoreFeatures.RadioErgonomicsWide.RadioErgonomicsWide radioErgonomicsWide) || radioErgonomicsWide.PresetZoneAndChannel.RadWideGeneralConfigurablePresetZoneAndChannel_A44917Value)
      return;
    radioErgonomicsWide.PresetZoneAndChannel.RadWideGeneralConfigurablePresetZoneAndChannel_A44917Value = true;
  }

  private void FixUpTrunkingNotificationButtonForMahalo()
  {
    if (!UtilityMack.IsMahaloRadio || !(FeatureManager.GetFeature(2042) is ButtonsRecset feature) || feature.Count == 0 || !(feature[0][10091].EmbeddedRecset is PortableButtonInnerRecset embeddedRecset) || embeddedRecset.Count == 0)
      return;
    AcpListField trunkingBcoA19545 = (embeddedRecset[4] as PortableButtonInner).PortableButtonInnerSection.BtnTrunkingPortableTrunkingBCO_A19545;
    if (trunkingBcoA19545.Value != 101)
      return;
    trunkingBcoA19545.SetValue(230);
  }

  private void FixupOneTouchTrunkingSystem()
  {
    IAcpRecordset feature = FeatureManager.GetFeature(2064);
    if (feature == null)
      return;
    for (int index = 0; index < feature.Count; ++index)
    {
      if (feature[index][10165] is Motorola.MackinawCPS.CoreFeatures.TrunkingSystem.OneTouch oneTouch && oneTouch.EmbeddedRecset is Motorola.MackinawCPS.CoreFeatures.TrunkingSystem.OneTouchInnerRecset embeddedRecset && embeddedRecset.Count < 16 /*0x10*/)
      {
        while (embeddedRecset.Count < 16 /*0x10*/)
          embeddedRecset.AddRecord(embeddedRecset.CreateDefaultRecord());
      }
    }
  }

  private void AlertListTableInit()
  {
    VirtualPartnerAlertRecset feature = FeatureManager.GetFeature(4231) as VirtualPartnerAlertRecset;
    if (feature == null || feature.Count <= 0 || !(feature[0][10891].EmbeddedRecset is AlertListInnerRecset embeddedRecset))
      return;
    string[] strArray = new string[16 /*0x10*/]
    {
      AppResources.ID_Alert_0,
      AppResources.ID_Alert_1,
      AppResources.ID_Alert_2,
      AppResources.ID_Alert_3,
      AppResources.ID_Alert_4,
      AppResources.ID_Alert_5,
      AppResources.ID_Alert_6,
      AppResources.ID_Alert_7,
      AppResources.ID_Alert_8,
      AppResources.ID_Alert_9,
      AppResources.ID_Alert_10,
      AppResources.ID_Alert_11,
      AppResources.ID_Alert_12,
      AppResources.ID_Alert_13,
      AppResources.ID_Alert_14,
      AppResources.ID_Alert_15
    };
    for (int index = 0; index < 16 /*0x10*/; ++index)
    {
      if (index >= embeddedRecset.Count)
        embeddedRecset.AddRecord(embeddedRecset.CreateDefaultRecord());
      (embeddedRecset[index] as AlertListInner).AlertListInnerSection.VirtualPartnerAlertListResultCode_43682.SetValue(index);
      AcpField<string> alertAliasA43683 = (embeddedRecset[index] as AlertListInner).AlertListInnerSection.VirtualPartnerAlertAlias_A43683;
      if (string.IsNullOrEmpty(alertAliasA43683.Value))
        alertAliasA43683.SetValue(strArray[index]);
    }
  }

  private void SiteSelectableAlertTableInit()
  {
    SiteSelectableAlertListRecset feature = FeatureManager.GetFeature(4145) as SiteSelectableAlertListRecset;
    if (feature == null || feature.Count <= 0 || !(feature[0][10765].EmbeddedRecset is SiteSelectableAlertTableInnerRecset embeddedRecset) || embeddedRecset.Count >= 15)
      return;
    while (embeddedRecset.Count < 15)
      embeddedRecset.AddRecord(embeddedRecset.CreateDefaultRecord());
    string[] strArray = new string[15]
    {
      AppResources.ID_Alert_1,
      AppResources.ID_Alert_2,
      AppResources.ID_Alert_3,
      AppResources.ID_Alert_4,
      AppResources.ID_Alert_5,
      AppResources.ID_Alert_6,
      AppResources.ID_Alert_7,
      AppResources.ID_Alert_8,
      AppResources.ID_Alert_9,
      AppResources.ID_Alert_10,
      AppResources.ID_Alert_11,
      AppResources.ID_Alert_12,
      AppResources.ID_Alert_13,
      AppResources.ID_Alert_14,
      AppResources.ID_Alert_15
    };
    for (int index = 0; index < 15 && embeddedRecset != null && index < embeddedRecset.Count; ++index)
      (embeddedRecset[index] as SiteSelectableAlertTableInner).SiteSelectableAlertTableInnerSection.SSAFrontDisplayAlertAlias_A41987.SetValue(strArray[index]);
  }

  private void OnRibbonBarDVRSExport(object sender, RoutedEventArgs e)
  {
    AcpUI.Common.Utility.SaveFieldWithFocus();
    Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();
    saveFileDialog.InitialDirectory = this.dvrsExportPath == string.Empty ? this.defaultDVRSFileLocation : this.dvrsExportPath;
    saveFileDialog.RestoreDirectory = true;
    saveFileDialog.Filter = "Xml files (*.xml)|*.xml";
    this.dvrsMsuDataSync = new DvrsMsuDataSync();
    saveFileDialog.FileName = this.dvrsMsuDataSync.BuildFileName();
    if (!saveFileDialog.ShowDialog().GetValueOrDefault())
      return;
    string fileName = saveFileDialog.FileName;
    if (fileName == null || !fileName.EndsWith(".xml"))
      return;
    Motorola.MackinawCPS.CoreFeatures.DVRSWide.DVRSWide dvrsWide = FeatureManager.GetFeature(4142)[0] as Motorola.MackinawCPS.CoreFeatures.DVRSWide.DVRSWide;
    if (!AppInfoManager.InvalidFieldsReport.UiHasFields)
    {
      uint hashCode = this.dvrsMsuDataSync.CalculateHashCode();
      dvrsWide.General.DVRSWideLabtoolDVRSSyncFieldsHash_A41811.SetValue((long) hashCode);
      this.dvrsMsuDataSync.ExportToXmlDoc(fileName);
      this.dvrsExportPath = Path.GetDirectoryName(fileName);
    }
    else
      AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, AppResources.Export_DVRS_MSU_Data_Failed_The_Codeplug_Contains_Invalid_Fields);
  }

  public void ExportDVRSFromRMC(string archiveFilePath, string exportFilePath)
  {
    string empty = string.Empty;
    if (!File.Exists(archiveFilePath))
      throw new CommonException(AppResources.Export_DVRS_MSU_Data_Failed_Intermediate_File_Corrupted);
    try
    {
      this.OpenCodeplug(archiveFilePath, ref empty, true);
    }
    catch
    {
      throw new CommonException(AppResources.Export_DVRS_MSU_Data_Failed_Intermediate_File_Corrupted);
    }
    this.dvrsMsuDataSync = new DvrsMsuDataSync();
    AcpDocument theDocument = ((App) System.Windows.Application.Current).TheDocument;
    if (exportFilePath.EndsWith(".xml"))
    {
      Motorola.MackinawCPS.CoreFeatures.DVRSWide.DVRSWide dvrsWide = FeatureManager.GetFeature(4142)[0] as Motorola.MackinawCPS.CoreFeatures.DVRSWide.DVRSWide;
      if ((bool) dvrsWide.General.RadErgoWideDigitalVehicularRepeaterSystemDVRSHardwareEnable_A7911)
      {
        if (!AppInfoManager.InvalidFieldsReport.UiHasFields)
        {
          uint hashCode = this.dvrsMsuDataSync.CalculateHashCode();
          dvrsWide.General.DVRSWideLabtoolDVRSSyncFieldsHash_A41811.SetValue((long) hashCode);
          this.dvrsMsuDataSync.ExportToXmlDoc(exportFilePath);
          this.dvrsExportPath = Path.GetDirectoryName(exportFilePath);
        }
        else
        {
          if (theDocument != null)
          {
            theDocument.ModificationLogEnabled = false;
            theDocument.FileClose();
          }
          throw new CommonException(AppResources.Export_DVRS_MSU_Data_Failed_The_Codeplug_Contains_Invalid_Fields);
        }
      }
      else
      {
        if (theDocument != null)
        {
          theDocument.ModificationLogEnabled = false;
          theDocument.FileClose();
        }
        throw new CommonException(AppResources.Export_DVRS_MSU_Data_Failed_DVRS_Disabled);
      }
    }
    if (theDocument == null)
      return;
    theDocument.ModificationLogEnabled = false;
    theDocument.FileClose();
  }

  public string MyBluetoothPANIPForWR
  {
    get
    {
      if (string.IsNullOrEmpty(BluetoothPANProgramming.BluetoothPANIPForWR))
        BluetoothPANProgramming.BluetoothPANIPForWR = this.defaulfBTPANIP;
      return BluetoothPANProgramming.BluetoothPANIPForWR;
    }
    set => BluetoothPANProgramming.BluetoothPANIPForWR = value;
  }

  public string MyBluetoothPANIPForClone
  {
    get
    {
      if (string.IsNullOrEmpty(BluetoothPANProgramming.BluetoothPANIPForClone))
        BluetoothPANProgramming.BluetoothPANIPForClone = this.defaulfBTPANIP;
      return BluetoothPANProgramming.BluetoothPANIPForClone;
    }
    set => BluetoothPANProgramming.BluetoothPANIPForClone = value;
  }

  private void OnPreviewKeyDown_BTIPAddressForWR(object sender, System.Windows.Input.KeyEventArgs e)
  {
    if (((IEnumerable<Key>) this.AllowedKeys).ToList<Key>().Contains(e.Key))
      return;
    e.Handled = true;
  }

  private void OnPreviewKeyDown_BTIPAddressForClone(object sender, System.Windows.Input.KeyEventArgs e)
  {
    if (((IEnumerable<Key>) this.AllowedKeys).ToList<Key>().Contains(e.Key))
      return;
    e.Handled = true;
  }

  private string GetModelNumber(byte[] partitionArr)
  {
    string modelNumber = (string) null;
    int length1 = partitionArr.Length;
    int num1 = 900;
    int num2;
    int num3;
    for (int index1 = 0; index1 < length1; index1 = num2 + num3)
    {
      byte[] numArray1 = partitionArr;
      int index2 = index1;
      int num4 = index2 + 1;
      int num5 = (int) numArray1[index2] << 8;
      byte[] numArray2 = partitionArr;
      int index3 = num4;
      int num6 = index3 + 1;
      int num7 = (int) numArray2[index3];
      int num8 = num5 | num7;
      int num9 = num6 + 2;
      byte[] numArray3 = partitionArr;
      int index4 = num9;
      int num10 = index4 + 1;
      int num11 = (int) numArray3[index4] << 8;
      byte[] numArray4 = partitionArr;
      int index5 = num10;
      num2 = index5 + 1;
      int num12 = (int) numArray4[index5];
      num3 = num11 | num12;
      int num13 = num1;
      if (num8 == num13)
      {
        int index6 = num2 + 1 + 22;
        string str = Encoding.BigEndianUnicode.GetString(partitionArr, index6, 34);
        int length2 = str.IndexOf(char.MinValue);
        return str.Substring(0, length2);
      }
    }
    return modelNumber;
  }

  public object Data { get; set; }

  public void PreProcess(ContainerTask Task)
  {
    if (AppInfoManager.DndOperation && this.Data is Dictionary<string, object> data)
    {
      object obj;
      data.TryGetValue(2045.ToString((IFormatProvider) CultureInfo.InvariantCulture), out obj);
      RadioWideRecset radioWideRecset = obj as RadioWideRecset;
      if (data.TryGetValue(2059.ToString((IFormatProvider) CultureInfo.InvariantCulture), out obj))
        this.SyncDndCnvPerASTROOTARAndOTARProfileIndex((object) (obj as ConventionalPersonalityRecset));
      if (data.TryGetValue(2064.ToString((IFormatProvider) CultureInfo.InvariantCulture), out obj))
        this.SyncDndTrkSysASTROOTARAndOTARProfileIndex(obj);
      if (data.TryGetValue(2021.ToString((IFormatProvider) CultureInfo.InvariantCulture), out obj))
        this.SyncDndSecureWide((obj as SecureWideRecset)[0] as Motorola.MackinawCPS.CoreFeatures.SecureWide.SecureWide);
      data.TryGetValue(2051.ToString((IFormatProvider) CultureInfo.InvariantCulture), out obj);
      ZoneChannelAssignmentRecset assignmentRecset = obj as ZoneChannelAssignmentRecset;
      AppInfoManager.SkipValueSetter = false;
      if (radioWideRecset != null && (radioWideRecset[0] as Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide).Features.RadWideFeaturesZoneCloneEnable_43130.HiddenStatic)
      {
        Motorola.MackinawCPS.CoreFeatures.RadioWide.Features self = FeatureManager.GetFeature(2045)[0][10105] as Motorola.MackinawCPS.CoreFeatures.RadioWide.Features;
        Task.AddTask((UndoableTask) new ModifyDataTask<bool>(self.RadWideFeaturesZoneCloneEnable_43130, false));
        self.RadWideFeaturesZoneCloneEnable_43130.ValueSetter((IAcpFeatureSection) self, Task);
      }
      if (assignmentRecset != null && (assignmentRecset[0] as Motorola.MackinawCPS.CoreFeatures.ZoneChannelAssignment.ZoneChannelAssignment).Zone.ZnChanCfgZoneZoneCloningEnable_43119.HiddenStatic)
      {
        ZoneChannelAssignmentRecset feature = FeatureManager.GetFeature(2051) as ZoneChannelAssignmentRecset;
        for (int index = feature.Count - 1; index >= 0; --index)
        {
          Zone zone = (feature[index] as Motorola.MackinawCPS.CoreFeatures.ZoneChannelAssignment.ZoneChannelAssignment).Zone;
          if (zone.ZnChanCfgZoneZoneCloningEnable_43119.Value && Task != null)
          {
            Task.AddTask((UndoableTask) new ModifyDataTask<bool>(zone.ZnChanCfgZoneZoneCloningEnable_43119, false));
            zone.ZnChanCfgZoneZoneCloningEnable_43119.ValueSetter((IAcpFeatureSection) zone, Task);
          }
        }
      }
      this.DnDFixUpForRadWideBluetoothPairingType(data, Task);
      this.DnDFixUpForURLTable(data, Task);
    }
    if (!AppInfoManager.ImportCopyOperation)
      return;
    IList list = (this.Data as IList)[0] as IList;
    bool flag1 = false;
    bool flag2 = false;
    bool flag3 = false;
    bool flag4 = false;
    bool flag5 = false;
    bool flag6 = false;
    bool flag7 = false;
    bool flag8 = false;
    foreach (object obj in (IEnumerable) list)
    {
      if (obj is ImportExportItem importExportItem)
      {
        if (importExportItem.RecsetName == RFResources.Zone_Channel_Assignment)
          flag1 = true;
        if (importExportItem.RecsetName == RFResources.ID_CONVENTIONALPERSONALITY)
          flag2 = true;
        if (importExportItem.RecsetName == RFResources.ID_RADIOWIDE)
          flag3 = true;
        if (importExportItem.RecsetName == RFResources.ID_ASTROTALKGROUPLIST)
          flag4 = true;
        if (importExportItem.RecsetName == RFResources.ID_CONVENTIONALSYSTEM)
          flag5 = true;
        if (importExportItem.recsetName == RFResources.ID_DATAWIDE)
          flag8 = true;
        flag6 = flag6 || importExportItem.RecsetName == RFResources.ID_TRUNKINGSYSTEM;
        flag7 = flag7 || importExportItem.RecsetName == RFResources.ID_SECUREWIDE;
      }
    }
    XmlDocument doc = (this.Data as IList)[1] as XmlDocument;
    if (flag2)
      this.SyncImportCnvPerASTROOTARAndOTARProfileIndex(doc);
    if (flag6)
      this.SyncImportTrkSysASTROOTARAndOTARProfileIndex(doc);
    if (flag7)
      this.SyncImportSecureWide(doc);
    if (flag8)
      this.ImportFixupForUrlTable(doc, Task);
    this.RenameLegacyKMFProfileIndex(doc);
    Motorola.MackinawCPS.CoreFeatures.RadioWide.Features self1 = FeatureManager.GetFeature(2045)[0][10105] as Motorola.MackinawCPS.CoreFeatures.RadioWide.Features;
    AppInfoManager.SkipValueSetter = true;
    if (flag1 & flag2 || flag3 & flag4 || flag3 & flag5)
    {
      AppInfoManager.SkipValueSetter = false;
      if (!this.XmlContainsZoneCloneEnabledZones(doc) && !this.ContainsZoneAssignementsWithZoneCloneEnabled())
      {
        ZoneChannelAssignmentRecset feature = FeatureManager.GetFeature(2051) as ZoneChannelAssignmentRecset;
        for (int index = feature.Count - 1; index >= 0; --index)
        {
          Zone zone = (feature[index] as Motorola.MackinawCPS.CoreFeatures.ZoneChannelAssignment.ZoneChannelAssignment).Zone;
          if (zone.ZnChanCfgZoneZoneCloningEnable_43119.Value && Task != null)
          {
            Task.AddTask((UndoableTask) new ModifyDataTask<bool>(zone.ZnChanCfgZoneZoneCloningEnable_43119, false));
            zone.ZnChanCfgZoneZoneCloningEnable_43119.ValueSetter((IAcpFeatureSection) zone, Task);
          }
        }
      }
      if (flag3 && !this.IsRadiowideZoneCloneEnableExistedInImportedXml(doc))
      {
        Task.AddTask((UndoableTask) new ModifyDataTask<bool>(self1.RadWideFeaturesZoneCloneEnable_43130, false));
        self1.RadWideFeaturesZoneCloneEnable_43130.ValueSetter((IAcpFeatureSection) self1, Task);
      }
      AppInfoManager.SkipValueSetter = true;
    }
    if (!flag3 || flag4 && flag5 && flag2 || !this.IsRadioWideZoneCloneEnableInImportedXml(doc) || (bool) self1.RadWideFeaturesZoneCloneEnable_43130)
      return;
    AppInfoManager.SkipValueSetter = false;
  }

  private void ImportFixupForUrlTable(XmlDocument doc, ContainerTask task)
  {
    XmlNode xmlNode = doc.ChildNodes[1].LastChild.SelectSingleNode($"//Recset[@Name='{AcgResources.ID_URL_TABLE}']");
    if (xmlNode == null)
      return;
    XmlNode selectNode = xmlNode.SelectNodes($"//Section[@Name='{AcgResources.ID_URL_TABLE}']")[0];
    XmlNodeList xmlNodeList1 = selectNode.SelectNodes($"//Field[@Name='{AcgResources.ID_BOOKMARK_URL}']");
    XmlNodeList xmlNodeList2 = selectNode.SelectNodes($"//Field[@Name='{AcgResources.ID_BOOKMARK_NAME}']");
    if (!(FeatureManager.GetFeature(4237) is URLTableRecset feature))
      return;
    this.CheckAndDeleteRedundantEntries(task, xmlNodeList1.Count, feature);
    int i = 0;
    foreach (URLTableInner urlTableInner in (Collection<AcpBusinessLayer.FeatureNode>) feature)
    {
      byte[] buffer = Convert.FromBase64String(xmlNodeList1[i].InnerText);
      this.SetURLTableValues(task, urlTableInner.URLTableInnerSection, xmlNodeList2[i++].InnerText, new AcpVoiceFileStruct()
      {
        voiceData = new MemoryStream(buffer, 0, buffer.Length, true, true)
      });
    }
  }

  private void DnDFixUpForURLTable(Dictionary<string, object> producerData, ContainerTask task)
  {
    bool flag1 = producerData.ContainsKey(2028.ToString());
    bool flag2 = producerData.ContainsKey(2049.ToString());
    if (!(AppInfoManager.ProducerVersion >= 35 & flag1) || flag2)
      return;
    object obj;
    producerData.TryGetValue(4237.ToString((IFormatProvider) CultureInfo.InvariantCulture), out obj);
    if (!(obj is URLTableRecset urlTableRecset) || task == null || !(FeatureManager.GetFeature(4237) is URLTableRecset feature))
      return;
    this.CheckAndDeleteRedundantEntries(task, urlTableRecset.Count, feature);
    int num = 0;
    foreach (URLTableInner urlTableInner1 in (Collection<AcpBusinessLayer.FeatureNode>) feature)
    {
      URLTableInner urlTableInner2 = urlTableRecset[num++] as URLTableInner;
      this.SetURLTableValues(task, urlTableInner1.URLTableInnerSection, urlTableInner2.URLTableInnerSection.BookmarkNameValue, urlTableInner2.URLTableInnerSection.BookmarkURLValue);
    }
  }

  private void CheckAndDeleteRedundantEntries(
    ContainerTask task,
    int producerCount,
    URLTableRecset urlTable)
  {
    if (producerCount >= urlTable.Count)
      return;
    for (int index = producerCount; index < urlTable.Count; ++index)
      task.AddTask((UndoableTask) new DeleteRecordTask((AcpBusinessLayer.FeatureNode) (urlTable[index] as URLTableInner)));
  }

  private void SetURLTableValues(
    ContainerTask task,
    URLTableInnerSection entry,
    string newName,
    AcpVoiceFileStruct newUrl)
  {
    task.AddTask((UndoableTask) new ModifyDataTask<string>((AcpField<string>) entry.BookmarkName, newName));
    task.AddTask((UndoableTask) new ModifyDataTask<AcpVoiceFileStruct>((AcpField<AcpVoiceFileStruct>) entry.BookmarkURL, newUrl));
    entry.BookmarkURL.CallConstraints();
  }

  private void UnpackFixupForRadWideBluetoothPairingType()
  {
    if (this.CodeplugVersion.Major >= 34)
      return;
    this.SyncStandardAndMppPairingTypeFieldsBasedOnPairingType();
  }

  private void ImportFixUpForRadWideBluetoothPairingType(XmlDocument document)
  {
    XmlNode xmlNode = this.XmlContainsBluetoothPairingType(document);
    if (xmlNode == null)
      return;
    this.SetBluetoothPairingTypeConfiguration(xmlNode.InnerText);
  }

  private void ComparatorFixUpForRadWideBluetoothPairingType(Document doc)
  {
    if (doc == null || doc.CodeplugVersion.Major >= 34 || !(doc.GetFeature(2045)[0] is Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide radioWide) || radioWide.Bluetooth == null || radioWide.Bluetooth.RadWideBluetoothBluetoothPairingType_A37036 == null)
      return;
    int pairingTypeA37036Value = radioWide.Bluetooth.RadWideBluetoothBluetoothPairingType_A37036Value;
    radioWide.Bluetooth.RadWideBluetoothStandardPairingValue = WindowMain.IsStandartPairingValueChecked(new int?(pairingTypeA37036Value));
    radioWide.Bluetooth.RadWideBluetoothSecureMPPTouchPairingValue = WindowMain.IsLfmppPairingValueChecked(new int?(pairingTypeA37036Value));
  }

  private void DnDFixUpForRadWideBluetoothPairingType(
    Dictionary<string, object> producerData,
    ContainerTask task)
  {
    if (AppInfoManager.ProducerVersion >= 34)
      return;
    object obj;
    producerData.TryGetValue(2045.ToString((IFormatProvider) CultureInfo.InvariantCulture), out obj);
    if (!((obj as RadioWideRecset)[0] is Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide radioWide1) || radioWide1.Bluetooth == null || radioWide1.Bluetooth.RadWideBluetoothBluetoothPairingType_A37036 == null || task == null)
      return;
    int pairingTypeA37036Value = radioWide1.Bluetooth.RadWideBluetoothBluetoothPairingType_A37036Value;
    if (FeatureManager.GetFeature(2045)[0] is Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide radioWide2 && radioWide2.Bluetooth != null && radioWide2.Bluetooth.RadWideBluetoothBluetoothPairingType_A37036 != null)
    {
      task.AddTask((UndoableTask) new ModifyDataTask<bool>(radioWide2.Bluetooth.RadWideBluetoothStandardPairing, WindowMain.IsStandartPairingValueChecked(new int?(pairingTypeA37036Value))));
      radioWide2.Bluetooth.RadWideBluetoothStandardPairing.ValueSetter((IAcpFeatureSection) radioWide2.Bluetooth, task);
      task.AddTask((UndoableTask) new ModifyDataTask<bool>(radioWide2.Bluetooth.RadWideBluetoothSecureMPPTouchPairing, WindowMain.IsLfmppPairingValueChecked(new int?(pairingTypeA37036Value))));
      radioWide2.Bluetooth.RadWideBluetoothSecureMPPTouchPairing.ValueSetter((IAcpFeatureSection) radioWide2.Bluetooth, task);
    }
    this.FixUpSetValuesForPairingTypeRegardingModels();
  }

  private XmlNode XmlContainsBluetoothPairingType(XmlDocument doc)
  {
    XmlNode xmlNode = doc.ChildNodes[1].LastChild.SelectSingleNode($"//Recset[@Name='{AcgResources.ID_RADIOWIDE}']");
    if (xmlNode == null)
      return (XmlNode) null;
    return xmlNode.SelectSingleNode($"//Field[@Name='{AcgResources.ID_BLUETOOTH_SECURE_MPP_PAIRING}']") != null || xmlNode.SelectSingleNode($"//Field[@Name='{AcgResources.ID_BLUETOOTH_STANDARD_PAIRING}']") != null ? (XmlNode) null : xmlNode.SelectSingleNode($"//Field[@Name='{AcgResources.ID_BLUETOOTHPAIRINGTYPE}']");
  }

  private void SetBluetoothPairingTypeConfiguration(string value)
  {
    int num;
    if (!new Dictionary<string, int>()
    {
      {
        AcgResources.ID_NONE,
        0
      },
      {
        AcgResources.ID_STANDARD,
        2
      },
      {
        AcgResources.ID_LFMPP,
        1
      },
      {
        AcgResources.ID_LFMPPSTANDARD,
        3
      }
    }.TryGetValue(value, out num))
      return;
    this.SyncStandardAndMppPairingTypeFieldsBasedOnPairingType(new int?(num));
    this.FixUpSetValuesForPairingTypeRegardingModels();
  }

  private void SyncStandardAndMppPairingTypeFieldsBasedOnPairingType(
    int? externalBluetoothPairingTypeValue = null)
  {
    if (!(FeatureManager.GetFeature(2045)[0] is Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide radioWide) || radioWide.Bluetooth == null || radioWide.Bluetooth.RadWideBluetoothBluetoothPairingType_A37036 == null)
      return;
    if (!externalBluetoothPairingTypeValue.HasValue)
      externalBluetoothPairingTypeValue = new int?(radioWide.Bluetooth.RadWideBluetoothBluetoothPairingType_A37036Value);
    radioWide.Bluetooth.RadWideBluetoothStandardPairingValue = WindowMain.IsStandartPairingValueChecked(externalBluetoothPairingTypeValue);
    radioWide.Bluetooth.RadWideBluetoothSecureMPPTouchPairingValue = WindowMain.IsLfmppPairingValueChecked(externalBluetoothPairingTypeValue);
  }

  private static bool IsStandartPairingValueChecked(int? externalBluetoothPairingTypeValue)
  {
    return externalBluetoothPairingTypeValue.GetValueOrDefault() == 2 || externalBluetoothPairingTypeValue.GetValueOrDefault() == 3;
  }

  private static bool IsLfmppPairingValueChecked(int? externalBluetoothPairingTypeValue)
  {
    return externalBluetoothPairingTypeValue.GetValueOrDefault() == 1 || externalBluetoothPairingTypeValue.GetValueOrDefault() == 3;
  }

  private void FixUpSetValuesForPairingTypeRegardingModels()
  {
    if (!(FeatureManager.GetFeature(2045)[0] is Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide radioWide) || radioWide.Bluetooth == null)
      return;
    if (UtilityMack.IsAPXNextOrAloha || UtilityMack.IsMahaloRadio || UtilityMack.IsAPX100Radio)
      radioWide.Bluetooth.RadWideBluetoothSecureMPPTouchPairingValue = false;
    if (UtilityMack.IsAPXNextOrAloha)
      return;
    radioWide.Bluetooth.RadWideStandardNFCTouchPairing_A44928Value = false;
    radioWide.Bluetooth.RadWideSecureNFCTouchPairing_A44931Value = false;
  }

  public void PostProcess(ContainerTask Task)
  {
    if (!this.ContainsZoneAssignementsWithZoneCloneEnabled())
    {
      if (AppInfoManager.ImportCopyOperation && this.Data != null && this.IsRadioWideZoneCloneEnableInCurrentCodeplug())
      {
        this.MoveASTROTalkgroup(Task);
        this.MoveConventionalSystem(Task);
        this.MovePersonality(Task);
      }
      this.PostFixUp(Task);
      this.ZoneToZoneCloneFixup(Task);
    }
    this.EnableAdvancedDigitalPrivacyADPWhenSecureOperationIsAdvancedDigitalPrivacy(Task);
    if (AppInfoManager.ImportCopyOperation)
    {
      this.SyncImportIndividualRadioOtarId();
      this.SyncImportRadioInhibitViaAstroOtar();
      this.SetInitialKMFProfileRecsetMaxSize();
    }
    AppInfoManager.SkipValueSetter = false;
  }

  private void SyncImportIndividualRadioOtarId()
  {
    XmlNode xmlNode1 = ((this.Data as IList)[1] as XmlDocument).SelectSingleNode($"//Node[@Name='{AcgResources.ID_SECUREWIDE}']");
    if (xmlNode1 == null)
      return;
    XmlNode xmlNode2 = xmlNode1.SelectSingleNode($".//Field[@Name='{AcgResources.ID_INDIVIDUALASTROOTARRADIOID}']");
    int result;
    if (xmlNode2 == null || !int.TryParse(xmlNode2.InnerText, out result) || !(FeatureManager.GetFeature(2055) is SecureKMFProfileRecset feature))
      return;
    foreach (Motorola.MackinawCPS.CoreFeatures.SecureKMFProfile.SecureKMFProfile secureKmfProfile in (Collection<AcpBusinessLayer.FeatureNode>) feature)
    {
      AcpSimpleRangeField astrootarRadioIdA8285 = secureKmfProfile.ASTROOTARInformation.SecKmfProfASTROOTARInformationIndividualASTROOTARRadioID_A8285;
      if (astrootarRadioIdA8285.AllowsDataTransfer() && !secureKmfProfile.General.SecKmfProfGenIndependentKeyList_43597.Value)
        astrootarRadioIdA8285.Value = result;
    }
  }

  private void MoveConventionalSystem(ContainerTask Task)
  {
    XmlDocument doc = (this.Data as IList)[1] as XmlDocument;
    ConventionalSystemRecset feature = FeatureManager.GetFeature(2053) as ConventionalSystemRecset;
    doc.SelectNodes("/import_export_doc/Root/Recset");
    XmlNode recsetNode = this.GetRecsetNode(doc, 2053);
    int newIndex = 0;
    bool flag = this.IsRadioWideZoneCloneEnableInImportedXml(doc);
    if (!(recsetNode != null & flag))
      return;
    XmlNodeList conventional = recsetNode.ChildNodes;
    if (feature.Where<AcpBusinessLayer.FeatureNode>((Func<AcpBusinessLayer.FeatureNode, bool>) (dd => dd.ReferenceKey == conventional.Item(0).Attributes["ReferenceKey"].Value)).Count<AcpBusinessLayer.FeatureNode>() <= 0)
      return;
    AcpBusinessLayer.FeatureNode featureNode = feature.Where<AcpBusinessLayer.FeatureNode>((Func<AcpBusinessLayer.FeatureNode, bool>) (dd => dd.ReferenceKey == conventional.Item(0).Attributes["ReferenceKey"].Value)).First<AcpBusinessLayer.FeatureNode>();
    int oldIndex = feature.IndexOf((IAcpFeatureNode) featureNode);
    if (oldIndex != newIndex)
      feature.MoveRecord(oldIndex, newIndex, Task);
    Task.AddTask((UndoableTask) new ChangePermissionsTask((IAcpFeatureNode) featureNode, featureNode.Permissions | Permissions.Undeletable));
  }

  private void MoveASTROTalkgroup(ContainerTask Task)
  {
    XmlDocument doc = (this.Data as IList)[1] as XmlDocument;
    ASTROTalkgroupListRecset feature = FeatureManager.GetFeature(2062) as ASTROTalkgroupListRecset;
    doc.SelectNodes("/import_export_doc/Root/Recset");
    XmlNode recsetNode = this.GetRecsetNode(doc, 2062);
    int newIndex = 0;
    bool flag = this.IsRadioWideZoneCloneEnableInImportedXml(doc);
    if (!(recsetNode != null & flag))
      return;
    XmlNodeList talkgroup = recsetNode.ChildNodes;
    if (feature.Where<AcpBusinessLayer.FeatureNode>((Func<AcpBusinessLayer.FeatureNode, bool>) (dd => dd.ReferenceKey == talkgroup.Item(0).Attributes["ReferenceKey"].Value)).Count<AcpBusinessLayer.FeatureNode>() <= 0)
      return;
    AcpBusinessLayer.FeatureNode featureNode = feature.Where<AcpBusinessLayer.FeatureNode>((Func<AcpBusinessLayer.FeatureNode, bool>) (dd => dd.ReferenceKey == talkgroup.Item(0).Attributes["ReferenceKey"].Value)).First<AcpBusinessLayer.FeatureNode>();
    int oldIndex = feature.IndexOf((IAcpFeatureNode) featureNode);
    if (oldIndex != newIndex)
      feature.MoveRecord(oldIndex, newIndex, Task);
    Task.AddTask((UndoableTask) new ChangePermissionsTask((IAcpFeatureNode) featureNode, featureNode.Permissions | Permissions.Undeletable));
  }

  private bool IsRadioWideZoneCloneEnableInImportedXml(XmlDocument doc)
  {
    XmlNode recsetNode = this.GetRecsetNode(doc, 2045);
    if (recsetNode != null)
    {
      foreach (XmlNode selectNode in recsetNode.SelectNodes("Node/Section"))
      {
        if (selectNode.Attributes["Name"].Value == RFResources.ID_FEATURES)
        {
          foreach (XmlNode childNode in selectNode.ChildNodes)
          {
            if (childNode.Attributes["Name"].Value == AcgResources.ID_ZONECLONEENABLE)
            {
              try
              {
                if (Convert.ToBoolean(childNode.InnerText))
                  return true;
              }
              catch
              {
              }
            }
          }
        }
      }
    }
    return false;
  }

  private bool IsRadioWideZoneCloneEnableInCurrentCodeplug()
  {
    return (FeatureManager.GetFeature(2045)[0][10105] as Motorola.MackinawCPS.CoreFeatures.RadioWide.Features).RadWideFeaturesZoneCloneEnable_43130.Value;
  }

  private bool IsRadiowideZoneCloneEnableExistedInImportedXml(XmlDocument doc)
  {
    XmlNode recsetNode = this.GetRecsetNode(doc, 2045);
    if (recsetNode != null)
    {
      foreach (XmlNode selectNode in recsetNode.SelectNodes("Node/Section"))
      {
        if (selectNode.Attributes["Name"].Value == RFResources.ID_FEATURES)
        {
          foreach (XmlNode childNode in selectNode.ChildNodes)
          {
            if (childNode.Attributes["Name"].Value == AcgResources.ID_ZONECLONEENABLE)
              return true;
          }
        }
      }
    }
    return false;
  }

  private bool IsZCAZoneCloneEnableExistedInImportedXml(XmlDocument doc)
  {
    XmlNode recsetNode = this.GetRecsetNode(doc, 2051);
    if (recsetNode != null)
    {
      foreach (XmlNode selectNode in recsetNode.SelectNodes("Node/Section"))
      {
        if (selectNode.Attributes["Name"].Value == RFResources.ID_ZONE)
        {
          foreach (XmlNode childNode in selectNode.ChildNodes)
          {
            if (childNode.Attributes["Name"].Value == AcgResources.ID_CLONEENABLE)
            {
              try
              {
                return Convert.ToBoolean(childNode.InnerText);
              }
              catch
              {
                return false;
              }
            }
          }
        }
      }
    }
    return false;
  }

  private bool IsSecureOperationinSecureWideSetAsSoftware(Motorola.MackinawCPS.CoreFeatures.SecureWide.SecureWide secureWide)
  {
    return secureWide.General.SecWideGeneralSecureOperation_A9067.Value == 3;
  }

  private bool IsFieldSecureWideADPAlgorithmEnableVisibleInUI(Motorola.MackinawCPS.CoreFeatures.SecureWide.SecureWide secureWide)
  {
    return secureWide != null && secureWide.General.SecureWideADPAlgorithmEnable_43200 != null && secureWide.General.SecureWideADPAlgorithmEnable_43200.Visible;
  }

  private int GetZoneCloneEnableCountInImportedXml(XmlDocument doc)
  {
    XmlNode recsetNode = this.GetRecsetNode(doc, 2051);
    int countInImportedXml = 0;
    if (recsetNode != null)
    {
      foreach (XmlNode selectNode in recsetNode.SelectNodes("Node/Section"))
      {
        if (selectNode.Attributes["Name"].Value == RFResources.ID_ZONE)
        {
          foreach (XmlNode childNode in selectNode.ChildNodes)
          {
            if (childNode.Attributes["Name"].Value == AcgResources.ID_CLONEENABLE)
            {
              try
              {
                if (Convert.ToBoolean(childNode.InnerText))
                {
                  ++countInImportedXml;
                  break;
                }
              }
              catch
              {
              }
            }
          }
        }
      }
    }
    return countInImportedXml;
  }

  private int GetZoneCloneEnableCountInCurrentCodeplug()
  {
    ZoneChannelAssignmentRecset feature = FeatureManager.GetFeature(2051) as ZoneChannelAssignmentRecset;
    int inCurrentCodeplug = 0;
    for (int index = 0; index < feature.Count && index != 15 && (feature[index] as Motorola.MackinawCPS.CoreFeatures.ZoneChannelAssignment.ZoneChannelAssignment).Zone.ZnChanCfgZoneZoneCloningEnable_43119.Value; ++index)
      ++inCurrentCodeplug;
    return inCurrentCodeplug;
  }

  private XmlNode GetRecsetNode(XmlDocument doc, int FeatureID)
  {
    foreach (XmlNode selectNode in doc.SelectNodes("/import_export_doc/Root/Recset"))
    {
      if (selectNode.Attributes["Id"].Value == FeatureID.ToString())
        return selectNode;
    }
    return (XmlNode) null;
  }

  private void MovePersonality(ContainerTask Task)
  {
    XmlDocument doc = (this.Data as IList)[1] as XmlDocument;
    ConventionalPersonalityRecset feature = FeatureManager.GetFeature(2059) as ConventionalPersonalityRecset;
    doc.SelectNodes("/import_export_doc/Root/Recset");
    XmlNode recsetNode = this.GetRecsetNode(doc, 2059);
    int newIndex = 0;
    int countInImportedXml = this.GetZoneCloneEnableCountInImportedXml(doc);
    if (recsetNode == null)
      return;
    foreach (XmlNode childNode in recsetNode.ChildNodes)
    {
      XmlNode node = childNode;
      if (feature.Where<AcpBusinessLayer.FeatureNode>((Func<AcpBusinessLayer.FeatureNode, bool>) (dd => dd.ReferenceKey == node.Attributes["ReferenceKey"].Value)).Count<AcpBusinessLayer.FeatureNode>() != 0)
      {
        int oldIndex = feature.IndexOf((IAcpFeatureNode) feature.Where<AcpBusinessLayer.FeatureNode>((Func<AcpBusinessLayer.FeatureNode, bool>) (dd => dd.ReferenceKey == node.Attributes["ReferenceKey"].Value)).First<AcpBusinessLayer.FeatureNode>());
        if (oldIndex == newIndex)
        {
          ++newIndex;
        }
        else
        {
          feature.MoveRecord(oldIndex, newIndex, Task);
          if (newIndex >= countInImportedXml * 16 /*0x10*/)
            break;
          ++newIndex;
        }
      }
    }
  }

  private void PostFixUp(ContainerTask Task)
  {
    if (AppInfoManager.AppMode == ApplicationMode.CodeplugComparisonMode)
      return;
    Motorola.MackinawCPS.CoreFeatures.RadioWide.Features features = FeatureManager.GetFeature(2045)[0][10105] as Motorola.MackinawCPS.CoreFeatures.RadioWide.Features;
    ZoneChannelAssignmentRecset feature1 = FeatureManager.GetFeature(2051) as ZoneChannelAssignmentRecset;
    int num1 = features.RadWideFeaturesZoneCloneEnable_43130.Value ? 1 : 0;
    ConventionalPersonalityRecset feature2 = FeatureManager.GetFeature(2059) as ConventionalPersonalityRecset;
    int num2 = 0;
    for (int index1 = 0; index1 < feature1.Count; ++index1)
    {
      if (!(feature1[index1] as Motorola.MackinawCPS.CoreFeatures.ZoneChannelAssignment.ZoneChannelAssignment).Zone.ZnChanCfgZoneZoneCloningEnable_43119.Value)
      {
        Task?.AddTask((UndoableTask) new ChangePermissionsTask(feature1[index1], Permissions.None));
        if ((feature1[index1] as Motorola.MackinawCPS.CoreFeatures.ZoneChannelAssignment.ZoneChannelAssignment).Channels.EmbeddedRecset is ChannelAssignmentListInnerRecset embeddedRecset)
        {
          Task?.AddTask((UndoableTask) new ChangePermissionsTask((IAcpRecordset) embeddedRecset, Permissions.None));
          for (int index2 = 0; index2 < embeddedRecset.Count; ++index2)
          {
            if (embeddedRecset[index2] is ChannelAssignmentListInner featureNode && Task != null)
              Task.AddTask((UndoableTask) new ChangePermissionsTask((IAcpFeatureNode) featureNode, Permissions.None));
          }
        }
      }
      else
      {
        ++num2;
        if ((feature1[index1] as Motorola.MackinawCPS.CoreFeatures.ZoneChannelAssignment.ZoneChannelAssignment).Channels.EmbeddedRecset is ChannelAssignmentListInnerRecset embeddedRecset)
        {
          for (int index3 = 0; index3 < embeddedRecset.Count; ++index3)
          {
            if (embeddedRecset[index3] is ChannelAssignmentListInner assignmentListInner)
            {
              int index4 = index1 * 16 /*0x10*/ + index3;
              Task?.AddTask((UndoableTask) new ModifyRecRefDataTask(assignmentListInner.ChannelAssignmentListInnerSection.ZnChanCfgChannelsPersonality_A8698, feature2[index4].ReferenceKey));
            }
          }
        }
      }
    }
    for (int index = num2 * 16 /*0x10*/; index < feature2.Count; ++index)
    {
      IAcpFeatureNode featureNode = feature2[index];
      if (featureNode != null)
      {
        Task?.AddTask((UndoableTask) new ChangePermissionsTask(featureNode, Permissions.None));
        FrequencyOptionsInnerRecset embeddedRecset = (featureNode as Motorola.MackinawCPS.CoreFeatures.ConventionalPersonality.ConventionalPersonality).FrequencyOptions.EmbeddedRecset as FrequencyOptionsInnerRecset;
        Task?.AddTask((UndoableTask) new ChangePermissionsTask((IAcpRecordset) embeddedRecset, Permissions.None));
      }
    }
    for (int index5 = 0; index5 < feature1.Count; ++index5)
    {
      if (!(feature1[index5] as Motorola.MackinawCPS.CoreFeatures.ZoneChannelAssignment.ZoneChannelAssignment).Zone.ZnChanCfgZoneZoneCloningEnable_43119.Value && (feature1[index5] as Motorola.MackinawCPS.CoreFeatures.ZoneChannelAssignment.ZoneChannelAssignment).Channels.EmbeddedRecset is ChannelAssignmentListInnerRecset embeddedRecset)
      {
        for (int index6 = 0; index6 < embeddedRecset.Count; ++index6)
        {
          if (embeddedRecset[index6] is ChannelAssignmentListInner assignmentListInner)
            assignmentListInner.ChannelAssignmentListInnerSection.ZnChanCfgChannelsPersonality_A8698.CallConstraints();
        }
      }
    }
    ASTROTalkgroupListRecset feature3 = FeatureManager.GetFeature(2062) as ASTROTalkgroupListRecset;
    if (feature3[0].EmbeddedRecordsets.Count<IAcpRecordset>() == 240 /*0xF0*/ || !feature3.HiddenStatic || !AppInfoManager.SkipValueSetter || Permission.Have(Permissions.Undeletable, feature3[0].Permissions))
      return;
    AcpBusinessLayer.FeatureNode defaultRecord1 = feature3.CreateDefaultRecord();
    (defaultRecord1 as Motorola.MackinawCPS.CoreFeatures.ASTROTalkgroupList.ASTROTalkgroupList).General.AstTlkgrpLstGeneralKeyofASTROTalkgroupList_A12665Value = AppResources.Zone_Reserved;
    defaultRecord1.KeyField.Editable = false;
    Task.AddTask((UndoableTask) new AddRecordTask(defaultRecord1));
    defaultRecord1.KeyField.Editable = true;
    feature3.MoveRecord(feature3.Count - 1, 0, Task);
    Task.AddTask((UndoableTask) new ChangePermissionsTask((IAcpFeatureNode) defaultRecord1, Permissions.Undeletable | Permissions.DragDisabled | Permissions.DropBeforeDisabled | Permissions.InsertBeforeDisabeled | Permissions.RefernceDisabled));
    TalkgroupTableInnerRecset embeddedRecset1 = (feature3[0] as Motorola.MackinawCPS.CoreFeatures.ASTROTalkgroupList.ASTROTalkgroupList).TalkgroupList.EmbeddedRecset as TalkgroupTableInnerRecset;
    Task.AddTask((UndoableTask) new ChangePermissionsTask((IAcpRecordset) embeddedRecset1, Permissions.AddDefaultDisabled | Permissions.AddCurrentDisabled));
    IAcpFeatureNode featureNode1 = embeddedRecset1[0];
    Task.AddTask((UndoableTask) new ChangePermissionsTask(featureNode1, Permissions.Undeletable | Permissions.DragDisabled | Permissions.DropBeforeDisabled | Permissions.InsertBeforeDisabeled));
    while (embeddedRecset1.Count < 240 /*0xF0*/)
    {
      AcpBusinessLayer.FeatureNode defaultRecord2 = embeddedRecset1.CreateDefaultRecord();
      Task.AddTask((UndoableTask) new ChangePermissionsTask((IAcpFeatureNode) defaultRecord2, Permissions.Undeletable | Permissions.DragDisabled | Permissions.DropBeforeDisabled | Permissions.InsertBeforeDisabeled));
      defaultRecord2.KeyField.Editable = false;
      Task.AddTask((UndoableTask) new AddRecordTask(defaultRecord2));
      defaultRecord2.KeyField.Editable = true;
    }
  }

  private void EnableAdvancedDigitalPrivacyADPWhenSecureOperationIsAdvancedDigitalPrivacy(
    ContainerTask Task)
  {
    if (!(this.Data is Dictionary<string, object> data))
      return;
    string key = 2021.ToString((IFormatProvider) CultureInfo.InvariantCulture);
    object obj;
    ref object local = ref obj;
    data.TryGetValue(key, out local);
    if (!(obj is SecureWideRecset secureWideRecset) || !this.IsSecureOperationinSecureWideSetAsSoftware(secureWideRecset[0] as Motorola.MackinawCPS.CoreFeatures.SecureWide.SecureWide))
      return;
    Motorola.MackinawCPS.CoreFeatures.SecureWide.SecureWide secureWide = FeatureManager.GetFeature(2021)[0] as Motorola.MackinawCPS.CoreFeatures.SecureWide.SecureWide;
    if (!this.IsFieldSecureWideADPAlgorithmEnableVisibleInUI(secureWide) || !this.IsSecureOperationinSecureWideSetAsSoftware(secureWide))
      return;
    Task.AddTask((UndoableTask) new ModifyDataTask<bool>(secureWide.General.SecureWideADPAlgorithmEnable_43200, true));
  }

  private ConventionalEmergencyProfilesRecset GetConventionalEmergencyProfiles()
  {
    return AppInfoManager.AppMode == ApplicationMode.CodeplugConfigurationMode ? FeatureManager.GetFeature(2075) as ConventionalEmergencyProfilesRecset : AppInfoManager.ComparatorDocument.GetFeature(2075) as ConventionalEmergencyProfilesRecset;
  }

  private TrunkingEmergencyProfilesRecset GetTrunkingEmergencyProfiles()
  {
    return AppInfoManager.AppMode == ApplicationMode.CodeplugConfigurationMode ? FeatureManager.GetFeature(2076) as TrunkingEmergencyProfilesRecset : AppInfoManager.ComparatorDocument.GetFeature(2076) as TrunkingEmergencyProfilesRecset;
  }

  private void SetValueForNewCnvHotMicTxPeriodField()
  {
    if (this.GetConventionalEmergencyProfiles() == null || this.CodeplugVersion.Major >= 19)
      return;
    foreach (Motorola.MackinawCPS.CoreFeatures.ConventionalEmergencyProfiles.ConventionalEmergencyProfiles emergencyProfile in (Collection<AcpBusinessLayer.FeatureNode>) this.GetConventionalEmergencyProfiles())
    {
      emergencyProfile.General.CnvEmerProfGeneralTxPeriodsec2_A43600.ResetToDefault();
      emergencyProfile.General.CnvEmerProfGeneralTxPeriodsec2_A43600.SetValue((int) (AcpField<int>) emergencyProfile.General.CnvEmerProfGeneralTxPeriodsec1_A8212 * 10);
    }
  }

  private void SetValueForNewTrkHotMicTxPeriodField()
  {
    if (this.GetTrunkingEmergencyProfiles() == null || this.CodeplugVersion.Major >= 19)
      return;
    foreach (Motorola.MackinawCPS.CoreFeatures.TrunkingEmergencyProfiles.TrunkingEmergencyProfiles emergencyProfile in (Collection<AcpBusinessLayer.FeatureNode>) this.GetTrunkingEmergencyProfiles())
    {
      emergencyProfile.General.TrkEmerProfGeneralTxPeriodsec2_A43601.ResetToDefault();
      emergencyProfile.General.TrkEmerProfGeneralTxPeriodsec2_A43601.SetValue((int) (AcpField<int>) emergencyProfile.General.TrkEmerProfGeneralTxPeriodsec1_A7939 * 10);
    }
  }

  private void InitCnvEmerProfGeneralTxPeriodsec2_A43600AterUnpack()
  {
    if (this.GetConventionalEmergencyProfiles() == null)
      return;
    foreach (Motorola.MackinawCPS.CoreFeatures.ConventionalEmergencyProfiles.ConventionalEmergencyProfiles emergencyProfile in (Collection<AcpBusinessLayer.FeatureNode>) this.GetConventionalEmergencyProfiles())
    {
      if (this.CheckIfValueCnvEmerProfGeneralTxPeriodsec2_A43600OutOfRange(emergencyProfile))
      {
        emergencyProfile.General.CnvEmerProfGeneralTxPeriodsec2_A43600.ResetToDefault();
        emergencyProfile.General.CnvEmerProfGeneralTxPeriodsec2_A43600.SetValue((int) (AcpField<int>) emergencyProfile.General.CnvEmerProfGeneralTxPeriodsec1_A8212 * 10);
      }
    }
  }

  private bool CheckIfValueCnvEmerProfGeneralTxPeriodsec2_A43600OutOfRange(
    Motorola.MackinawCPS.CoreFeatures.ConventionalEmergencyProfiles.ConventionalEmergencyProfiles item)
  {
    return item.General.CnvEmerProfGeneralTxPeriodsec2_A43600.Value < item.General.CnvEmerProfGeneralTxPeriodsec2_A43600.Min || item.General.CnvEmerProfGeneralTxPeriodsec2_A43600.Value > item.General.CnvEmerProfGeneralTxPeriodsec2_A43600.Max;
  }

  private void InitTrkEmerProfGeneralTxPeriodsec2_A43601AfterUnpack()
  {
    if (this.GetTrunkingEmergencyProfiles() == null)
      return;
    foreach (Motorola.MackinawCPS.CoreFeatures.TrunkingEmergencyProfiles.TrunkingEmergencyProfiles emergencyProfile in (Collection<AcpBusinessLayer.FeatureNode>) this.GetTrunkingEmergencyProfiles())
    {
      if (this.CheckIfValueTrkEmerProfGeneralTxPeriodsec2_A43601OutOfRange(emergencyProfile))
      {
        emergencyProfile.General.TrkEmerProfGeneralTxPeriodsec2_A43601.ResetToDefault();
        emergencyProfile.General.TrkEmerProfGeneralTxPeriodsec2_A43601.SetValue((int) (AcpField<int>) emergencyProfile.General.TrkEmerProfGeneralTxPeriodsec1_A7939 * 10);
      }
    }
  }

  private bool CheckIfValueTrkEmerProfGeneralTxPeriodsec2_A43601OutOfRange(
    Motorola.MackinawCPS.CoreFeatures.TrunkingEmergencyProfiles.TrunkingEmergencyProfiles item)
  {
    return item.General.TrkEmerProfGeneralTxPeriodsec2_A43601.Value < item.General.TrkEmerProfGeneralTxPeriodsec2_A43601.Min || item.General.TrkEmerProfGeneralTxPeriodsec2_A43601.Value > item.General.TrkEmerProfGeneralTxPeriodsec2_A43601.Max;
  }

  private void expandFlashcode()
  {
    Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation radioInformation = AppInfoManager.AppMode != ApplicationMode.CodeplugComparisonMode ? FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation : AppInfoManager.ComparatorDocument.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation;
    string flasHcodeA8132Value = radioInformation.FLASHport.RadInfoFLASHportFLASHcode_A8132Value;
    string str = "-000000-000000";
    if (flasHcodeA8132Value == null || flasHcodeA8132Value.Length > 15)
      return;
    radioInformation.FLASHport.RadInfoFLASHportFLASHcode_A8132Value = flasHcodeA8132Value + str;
  }

  private void SyncRadioInhibitViaAstroOtar()
  {
    AcpField<bool> inhibitviaAstrootarA8834 = (FeatureManager.GetFeature(2021)[0] as Motorola.MackinawCPS.CoreFeatures.SecureWide.SecureWide).ASTROOTAR.SecWideASTROOTARRadioInhibitviaASTROOTAR_A8834;
    foreach (Motorola.MackinawCPS.CoreFeatures.SecureKMFProfile.SecureKMFProfile secureKmfProfile in (Collection<AcpBusinessLayer.FeatureNode>) (FeatureManager.GetFeature(2055) as SecureKMFProfileRecset))
    {
      if (!(bool) secureKmfProfile.General.SecKmfProfGenIndependentKeyList_43597 && secureKmfProfile.ASTROOTARInformation.SecKmfProfRadioInhibitViaASTROOTAR_43690.Valid)
      {
        inhibitviaAstrootarA8834.Value = secureKmfProfile.ASTROOTARInformation.SecKmfProfRadioInhibitViaASTROOTAR_43690.Value;
        return;
      }
    }
    inhibitviaAstrootarA8834.Value = false;
  }

  private void FixupCertficateDisplayName()
  {
    Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation radioInformation = FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation;
    string numberA8539UiValue = radioInformation.General.RadInfoGeneralModelNumber_A8539_UIValue;
    if (!UtilityMack.IsTXM3000)
      return;
    radioInformation.General.RadInfoGeneralInstalledTxmCertificate_UIValue = AcgResources.ID_NA;
  }

  private void RunTMSConstraints()
  {
    if (this.CodeplugVersion.Major < 30)
    {
      foreach (Motorola.MackinawCPS.CoreFeatures.ConventionalSystem.ConventionalSystem tmpConventionalSystem in (Collection<AcpBusinessLayer.FeatureNode>) (FeatureManager.GetFeature(2053) as ConventionalSystemRecset))
      {
        int index = tmpConventionalSystem.Features.DataProfFeaturesTextMessagingService_A9372.Value;
        if (index != 0 && tmpConventionalSystem.Features.DataProfFeaturesTextMessagingService_A9372.Visible && !ConventionalSystemConstraints.ValidateTMSField(tmpConventionalSystem, tmpConventionalSystem.Features, index))
          tmpConventionalSystem.Features.DataProfFeaturesTextMessagingService_A9372.CalculateValidity();
      }
    }
    foreach (Motorola.MackinawCPS.CoreFeatures.TrunkingSystem.TrunkingSystem trunkingSystem in (Collection<AcpBusinessLayer.FeatureNode>) (FeatureManager.GetFeature(2064) as TrunkingSystemRecset))
      trunkingSystem.Features.TrkSysFeaturesTextMessagingService_A9373.CalculateValidity();
  }

  private void SyncASTROOTARAndOTARProfileIndex(Document doc)
  {
    ConventionalPersonalityRecset feature1 = doc.GetFeature(2059) as ConventionalPersonalityRecset;
    TrunkingSystemRecset feature2 = doc.GetFeature(2064) as TrunkingSystemRecset;
    if (feature1 != null)
    {
      foreach (Motorola.MackinawCPS.CoreFeatures.ConventionalPersonality.ConventionalPersonality conventionalPersonality in (Collection<AcpBusinessLayer.FeatureNode>) feature1)
      {
        AcpField<bool> secureAstrootarA7493 = conventionalPersonality.Secure.CnvPerSecureASTROOTAR_A7493;
        AcpRecRefField profileIndexA8381 = conventionalPersonality.Secure.CnvPerSecureKMFProfileIndex_A8381;
        if (!secureAstrootarA7493.Value)
        {
          profileIndexA8381.Value = 0;
          profileIndexA8381.DefaultValue = 0;
        }
      }
    }
    if (feature2 == null)
      return;
    foreach (Motorola.MackinawCPS.CoreFeatures.TrunkingSystem.TrunkingSystem trunkingSystem in (Collection<AcpBusinessLayer.FeatureNode>) feature2)
    {
      AcpField<bool> multikeyAstrootarA7494 = trunkingSystem.SecureMultikey.TrkSysSecureMultikeyASTROOTAR_A7494;
      AcpRecRefField profileIndexA8382 = trunkingSystem.SecureMultikey.TrkSysSecureMultikeyKMFProfileIndex_A8382;
      if (!multikeyAstrootarA7494.Value)
      {
        profileIndexA8382.Value = 0;
        profileIndexA8382.DefaultValue = 0;
      }
    }
  }

  private void SyncDndCnvPerASTROOTARAndOTARProfileIndex(object personalities)
  {
    switch (personalities)
    {
      case ConventionalPersonalityRecset _:
        using (IEnumerator<AcpBusinessLayer.FeatureNode> enumerator = (personalities as ConventionalPersonalityRecset).GetEnumerator())
        {
          while (enumerator.MoveNext())
            this.SyncCnvPersAstroOtarProfileIndex((Motorola.MackinawCPS.CoreFeatures.ConventionalPersonality.ConventionalPersonality) enumerator.Current);
          break;
        }
      case Motorola.MackinawCPS.CoreFeatures.ConventionalPersonality.ConventionalPersonality _:
        this.SyncCnvPersAstroOtarProfileIndex(personalities as Motorola.MackinawCPS.CoreFeatures.ConventionalPersonality.ConventionalPersonality);
        break;
    }
  }

  private void SyncCnvPersAstroOtarProfileIndex(Motorola.MackinawCPS.CoreFeatures.ConventionalPersonality.ConventionalPersonality cnvPersonality)
  {
    Motorola.MackinawCPS.CoreFeatures.ConventionalPersonality.Secure secure = cnvPersonality.Secure;
    if (secure.CnvPerSecureASTROOTAR_A7493.Value || secure.CnvPerSecureKMFProfileIndex_A8381.Value == 0)
      return;
    secure.CnvPerSecureKMFProfileIndex_A8381.Value = 0;
  }

  private void SyncDndTrkSysASTROOTARAndOTARProfileIndex(object systems)
  {
    switch (systems)
    {
      case TrunkingSystemRecset _:
        using (IEnumerator<AcpBusinessLayer.FeatureNode> enumerator = (systems as TrunkingSystemRecset).GetEnumerator())
        {
          while (enumerator.MoveNext())
            this.SyncTrkSystemAstroOtarProfileIndex((Motorola.MackinawCPS.CoreFeatures.TrunkingSystem.TrunkingSystem) enumerator.Current);
          break;
        }
      case Motorola.MackinawCPS.CoreFeatures.TrunkingSystem.TrunkingSystem _:
        this.SyncTrkSystemAstroOtarProfileIndex(systems as Motorola.MackinawCPS.CoreFeatures.TrunkingSystem.TrunkingSystem);
        break;
    }
  }

  private void SyncTrkSystemAstroOtarProfileIndex(Motorola.MackinawCPS.CoreFeatures.TrunkingSystem.TrunkingSystem trkSystem)
  {
    SecureMultikey secureMultikey = trkSystem.SecureMultikey;
    if (secureMultikey.TrkSysSecureMultikeyASTROOTAR_A7494.Value || secureMultikey.TrkSysSecureMultikeyKMFProfileIndex_A8382.Value == 0)
      return;
    secureMultikey.TrkSysSecureMultikeyKMFProfileIndex_A8382.Value = 0;
  }

  private void SyncDndSecureWide(Motorola.MackinawCPS.CoreFeatures.SecureWide.SecureWide secureWide)
  {
    if (secureWide.General.SecWideGeneralOTAROperation_43700 == null)
    {
      Motorola.MackinawCPS.CoreFeatures.SecureWide.SecureWide secureWide1 = FeatureManager.GetFeature(2021)[0] as Motorola.MackinawCPS.CoreFeatures.SecureWide.SecureWide;
      AcpListField otarOperation43700 = secureWide1.General.SecWideGeneralOTAROperation_43700;
      if (otarOperation43700.AllowsDataTransfer())
      {
        int num = secureWide.General.SecWideGeneralOTAREnable_A7966.Value ? 1 : 0;
        bool flag1 = secureWide.ASTROOTAR.SecWideASTROOTARASTROOTAREnable_A7496.Value;
        bool flag2 = secureWide.MDCOTAR.SecWideMDCOTARMDCOTAREnable_A8488.Value;
        if (num == 0)
          otarOperation43700.Value = 0;
        else if (!flag1)
          otarOperation43700.Value = 1;
        else if (!flag2)
          otarOperation43700.Value = 2;
        else
          otarOperation43700.Value = 3;
      }
      if (secureWide.General.SecWideInfiniteUKEKRetention_A41551 == null)
        secureWide1.General.SecWideInfiniteUKEKRetention_A41551.Value = secureWide.Features.SecWideInfiniteUKEKRetention_A41551.Value;
      if (secureWide.General.SecWideMultikeyErasePreviousOnUserChange_A8373 == null)
        secureWide1.General.SecWideMultikeyErasePreviousOnUserChange_A8373.Value = secureWide.Multikey.SecWideMultikeyErasePreviousOnUserChange_A8373.Value;
      if (secureWide.General.SecWideMultikeyUserSelectable_A9604 == null)
        secureWide1.General.SecWideMultikeyUserSelectable_A9604.Value = secureWide.Multikey.SecWideMultikeyUserSelectable_A9604.Value;
    }
    if (secureWide.ASTROOTAR.SecWideASTROOTARRadioInhibitviaASTROOTAR_A8834.HiddenStatic)
      return;
    this.SyncAstroOtarInhibit(secureWide.ASTROOTAR);
  }

  private void SyncImportRadioInhibitViaAstroOtar()
  {
    XmlDocument xmlDocument = (this.Data as IList)[1] as XmlDocument;
    XmlNode xmlNode1 = xmlDocument.SelectSingleNode($"//Node[@Name='{AcgResources.ID_SECUREWIDE}']");
    if (xmlNode1 != null)
    {
      XmlNode xmlNode2 = xmlNode1.SelectSingleNode($".//Field[@Name='{AcgResources.ID_RADIOINHIBITVIAASTROOTAR}']");
      if (xmlNode2 != null)
      {
        AcpField<bool> inhibitviaAstrootarA8834 = (FeatureManager.GetFeature(2021)[0] as Motorola.MackinawCPS.CoreFeatures.SecureWide.SecureWide).ASTROOTAR.SecWideASTROOTARRadioInhibitviaASTROOTAR_A8834;
        bool result;
        if (bool.TryParse(xmlNode2.InnerText, out result))
        {
          inhibitviaAstrootarA8834.Value = result;
          WindowMain.SyncImportOldRadioInhibitViaAstroOtar();
        }
      }
    }
    if (xmlDocument.SelectSingleNode($"//Recset[@Name='{AcgResources.ID_ASTROOTARPROFILE}']") == null)
      return;
    this.SyncRadioInhibitViaAstroOtar();
  }

  private static void SyncImportOldRadioInhibitViaAstroOtar()
  {
    AcpField<bool> inhibitviaAstrootarA8834 = (FeatureManager.GetFeature(2021)[0] as Motorola.MackinawCPS.CoreFeatures.SecureWide.SecureWide).ASTROOTAR.SecWideASTROOTARRadioInhibitviaASTROOTAR_A8834;
    foreach (Motorola.MackinawCPS.CoreFeatures.SecureKMFProfile.SecureKMFProfile secureKmfProfile in (Collection<AcpBusinessLayer.FeatureNode>) (FeatureManager.GetFeature(2055) as SecureKMFProfileRecset))
    {
      if (!(bool) secureKmfProfile.General.SecKmfProfGenIndependentKeyList_43597)
        secureKmfProfile.ASTROOTARInformation.SecKmfProfRadioInhibitViaASTROOTAR_43690.Value = inhibitviaAstrootarA8834.Value;
    }
  }

  private void SyncImportCnvPerASTROOTARAndOTARProfileIndex(XmlDocument doc)
  {
    XmlNode lastChild = doc.ChildNodes[1].LastChild;
    string str1 = "False";
    string str2 = "<Disabled>";
    string xpath = $"//Recset[@Name='{AcgResources.ID_CONVENTIONALPERSONALITY}']";
    XmlNode xmlNode1 = lastChild.SelectSingleNode(xpath);
    if (xmlNode1 == null)
      return;
    foreach (XmlNode selectNode in xmlNode1.SelectNodes($"//Section[@Name='{AcgResources.ID_SECURE}']"))
    {
      XmlNode xmlNode2 = selectNode.SelectSingleNode($".//Field[@Name='{AcgResources.ID_ASTROOTAR}']");
      XmlNode xmlNode3 = selectNode.SelectSingleNode($".//Field[@Name='{AcgResources.ID_ASTROOTARPROFILEINDEX}']") ?? selectNode.SelectSingleNode($".//Field[@Name='{AcgResources.ID_KMFPROFILEINDEX}']");
      if (xmlNode2 != null && xmlNode3 != null)
      {
        xmlNode3.Attributes["Name"].Value = AcgResources.ID_ASTROOTARPROFILEINDEX;
        string innerText1 = xmlNode2.InnerText;
        string innerText2 = xmlNode3.InnerText;
        if (str1.Equals(innerText1) && !str2.Equals(innerText2))
          xmlNode3.InnerText = str2;
      }
    }
  }

  private void SyncImportTrkSysASTROOTARAndOTARProfileIndex(XmlDocument doc)
  {
    XmlNode lastChild = doc.ChildNodes[1].LastChild;
    string str1 = "False";
    string str2 = "<Disabled>";
    string xpath = $"//Recset[@Name='{AcgResources.ID_TRUNKINGSYSTEM}']";
    XmlNode xmlNode1 = lastChild.SelectSingleNode(xpath);
    if (xmlNode1 == null)
      return;
    foreach (XmlNode selectNode in xmlNode1.SelectNodes($"//Section[@Name='{AcgResources.ID_SECUREMULTIKEY}']"))
    {
      XmlNode xmlNode2 = selectNode.SelectSingleNode($".//Field[@Name='{AcgResources.ID_OTARASTROOTAR}']");
      XmlNode xmlNode3 = selectNode.SelectSingleNode($".//Field[@Name='{AcgResources.ID_OTARASTROOTARPROFILEINDEX}']") ?? selectNode.SelectSingleNode($".//Field[@Name='{AcgResources.ID_OTARKMFPROFILEINDEX}']");
      if (xmlNode2 != null && xmlNode3 != null)
      {
        string innerText1 = xmlNode2.InnerText;
        string innerText2 = xmlNode3.InnerText;
        if (str1.Equals(innerText1) && !str2.Equals(innerText2))
          xmlNode3.InnerText = str2;
      }
    }
  }

  private XmlNode ExtractNode(XmlNode parentNode, params string[] nodeNamePath)
  {
    XmlNode parentNode1 = (XmlNode) null;
    foreach (XmlNode childNode in parentNode.ChildNodes)
    {
      if (childNode.Attributes["Name"] != null && childNode.Attributes["Name"].Value.Equals(nodeNamePath[0]))
        parentNode1 = childNode;
    }
    if (nodeNamePath.Length > 1 && parentNode1 != null)
      parentNode1 = this.ExtractNode(parentNode1, ((IEnumerable<string>) nodeNamePath).Skip<string>(1).ToArray<string>());
    return parentNode1;
  }

  private void SyncImportSecureWide(XmlDocument doc)
  {
    XmlNode lastChild = doc.ChildNodes[1].LastChild;
    XmlNode xmlNode1 = lastChild.SelectSingleNode($"//Field[@Name='{AcgResources.ID_OTAROPERATION}']");
    XmlNode parentNode = lastChild.SelectSingleNode($"//Node[@Name='{AcgResources.ID_SECUREWIDE}']");
    if (parentNode == null)
      return;
    Motorola.MackinawCPS.CoreFeatures.SecureWide.SecureWide secureWide = FeatureManager.GetFeature(2021)[0] as Motorola.MackinawCPS.CoreFeatures.SecureWide.SecureWide;
    XmlNode node1 = this.ExtractNode(parentNode, AcgResources.ID_FEATURES, AcgResources.ID_INFINITEUKEKRETENTION);
    XmlNode node2 = this.ExtractNode(parentNode, AcgResources.ID_MULTIKEY, AcgResources.ID_KEYSETUSERSELECTABLE);
    XmlNode node3 = this.ExtractNode(parentNode, AcgResources.ID_MULTIKEY, AcgResources.ID_KEYSETERASEPREVIOUSONUSERCHANGE);
    if (xmlNode1 == null)
    {
      AcpListField otarOperation43700 = secureWide.General.SecWideGeneralOTAROperation_43700;
      if (otarOperation43700.AllowsDataTransfer())
      {
        XmlNode xmlNode2 = parentNode.SelectSingleNode($".//Field[@Name='{AcgResources.ID_OTARENABLE}']");
        XmlNode xmlNode3 = parentNode.SelectSingleNode($".//Field[@Name='{AcgResources.ID_ASTROOTARENABLE}']");
        XmlNode xmlNode4 = parentNode.SelectSingleNode($".//Field[@Name='{AcgResources.ID_MDCOTARENABLE}']");
        if (xmlNode2 == null || xmlNode3 == null || xmlNode4 == null || !bool.Parse(xmlNode2.InnerText))
          otarOperation43700.Value = 0;
        else if (!bool.Parse(xmlNode3.InnerText))
          otarOperation43700.Value = 1;
        else if (!bool.Parse(xmlNode4.InnerText))
          otarOperation43700.Value = 2;
        else
          otarOperation43700.Value = 3;
      }
    }
    bool result1;
    if (node1 != null && bool.TryParse(node1.InnerText, out result1) && secureWide.General.SecWideInfiniteUKEKRetention_A41551.AllowsDataTransfer())
      secureWide.General.SecWideInfiniteUKEKRetention_A41551.Value = result1;
    bool result2;
    if (node3 != null && bool.TryParse(node3.InnerText, out result2) && secureWide.General.SecWideMultikeyErasePreviousOnUserChange_A8373.AllowsDataTransfer())
      secureWide.General.SecWideMultikeyErasePreviousOnUserChange_A8373.Value = result2;
    bool result3;
    if (node2 == null || !bool.TryParse(node2.InnerText, out result3) || !secureWide.General.SecWideMultikeyUserSelectable_A9604.AllowsDataTransfer())
      return;
    secureWide.General.SecWideMultikeyUserSelectable_A9604.Value = result3;
  }

  private void RenameLegacyKMFProfileIndex(XmlDocument doc)
  {
    foreach (XmlNode selectNode in doc.ChildNodes[1].LastChild.SelectNodes($"//Field[@Name='{AcgResources.ID_KMFPROFILEINDEX}']"))
      selectNode.Attributes["Name"].Value = AcgResources.ID_ASTROOTARPROFILEINDEX;
  }

  private void UpdatePowerLevelMinimumForAPX8500(
    TxPowerLevelsByFrequencyRangeInnerRecset powerLevelsRecset)
  {
    IAcpRecordset feature = FeatureManager.GetFeature(2045);
    TxPowerLevelsByFrequencyRangeInnerRecset embeddedRecset1 = feature[0][10103].EmbeddedRecset as TxPowerLevelsByFrequencyRangeInnerRecset;
    for (int index = 0; index < embeddedRecset1.Count; ++index)
    {
      TxPowerLevelsByFrequencyRangeInnerSection rangeInnerSection = embeddedRecset1[index][10104] as TxPowerLevelsByFrequencyRangeInnerSection;
      if (rangeInnerSection.RadWideTransmitPowerLevelsTxPowerLevelMinimumW_A20038.Value != 33010)
        rangeInnerSection.RadWideTransmitPowerLevelsTxPowerLevelMinimumW_A20038.Value = 30000;
    }
    TxPowerLevelsByFrequencyRangeNewBandPlanInnerRecset embeddedRecset2 = feature[0][10761].EmbeddedRecset as TxPowerLevelsByFrequencyRangeNewBandPlanInnerRecset;
    for (int index = 0; index < embeddedRecset2.Count; ++index)
    {
      TxPowerLevelsByFrequencyRangeNewBandPlanInnerSection planInnerSection = embeddedRecset2[index][10762] as TxPowerLevelsByFrequencyRangeNewBandPlanInnerSection;
      if (planInnerSection.RadWideTransmitPowerLevelsTxPowerLevelMinimumW_A41858.Value != 33010)
        planInnerSection.RadWideTransmitPowerLevelsTxPowerLevelMinimumW_A41858.Value = 30000;
    }
  }

  private void SyncE5BottomButton()
  {
    if (!UtilityMack.IsMobileOnly())
      return;
    // ISSUE: explicit non-virtual call
    // ISSUE: explicit non-virtual call
    E5BottomFunctionButtonInnerSection buttonInnerSection = ((FeatureManager.GetFeature(4236) is ControlHeadE5Recset feature1 ? __nonvirtual (feature1[0])[10903].EmbeddedRecset : (IAcpRecordset) null) is E5BottomFunctionButtonInnerRecset embeddedRecset1 ? __nonvirtual (embeddedRecset1[0]) : (IAcpFeatureNode) null) is E5BottomFunctionButtonInner functionButtonInner ? functionButtonInner.E5BottomFunctionButtonInnerSection : (E5BottomFunctionButtonInnerSection) null;
    // ISSUE: explicit non-virtual call
    BottomFunctionButtonBCOListInnerRecset embeddedRecset2 = (FeatureManager.GetFeature(4003) is ControlHeadO9Recset feature2 ? __nonvirtual (feature2[0])[10628].EmbeddedRecset : (IAcpRecordset) null) as BottomFunctionButtonBCOListInnerRecset;
    AcpListField functionButtonBco43757 = buttonInnerSection?.E5BottomFunctionButtonBCO_43757;
    if (embeddedRecset2 == null || buttonInnerSection == null)
      return;
    foreach (BottomFunctionButtonBCOListInner buttonBcoListInner in (Collection<AcpBusinessLayer.FeatureNode>) embeddedRecset2)
    {
      if (buttonBcoListInner.BottomFunctionButtonBCOListInnerSection.CHO9BottomFunctionButtonBCO_A36827.Value == functionButtonBco43757.Value)
      {
        buttonInnerSection.E5BottomFunctionButtonFeature_43758.Value = buttonBcoListInner.BottomFunctionButtonBCOListInnerSection.CHO9BottomFunctionButtonFeature_A36826.Value;
        break;
      }
    }
  }

  private void FixRSISiteNumber()
  {
    IAcpRecordset feature = FeatureManager.GetFeature(2051);
    for (int index = 0; index < feature.Count; ++index)
    {
      Motorola.MackinawCPS.CoreFeatures.ZoneChannelAssignment.ZoneChannelAssignment channelAssignment = feature[index] as Motorola.MackinawCPS.CoreFeatures.ZoneChannelAssignment.ZoneChannelAssignment;
      if (channelAssignment.RSI != null)
      {
        if (channelAssignment.RSI.ZoneChannelAssignmentRSIMode_A41831Value == 2)
        {
          channelAssignment.RSI.ZoneChannelAssignmentRSISiteNumber_A41833Max = 96 /*0x60*/;
        }
        else
        {
          if (channelAssignment.RSI.ZoneChannelAssignmentRSISiteNumber_A41833Value > 62)
            channelAssignment.RSI.ZoneChannelAssignmentRSISiteNumber_A41833Value = 1;
          channelAssignment.RSI.ZoneChannelAssignmentRSISiteNumber_A41833Max = 62;
        }
      }
      channelAssignment.RSI.ZoneChannelAssignmentRSISiteNumber_A41833.CalculateValidity();
    }
  }

  public Motorola.Acp.PackUnpack.Ish.Codeplug GenerateConfigurationForMultiCodeplug(
    string modelNumber,
    string flashCode)
  {
    if (((App) System.Windows.Application.Current).TheDocument != null)
      this.UninitializeCodeplug();
    System.Collections.Generic.List<string> onlyFPSOptions = new System.Collections.Generic.List<string>();
    FlashcodeTable fcodeTable = this.InitDocModelTieringAndFcodeTable(modelNumber);
    System.Collections.Generic.List<string> optionsFromFlashCode = FlashcodeTable.GetOrderedOptionsFromFLASHCode(flashCode, fcodeTable);
    fcodeTable.ResolveHoptionFieldsForCpGeneration(fcodeTable, optionsFromFlashCode, onlyFPSOptions, "1");
    this.SetFieldsOnCodeplugInitialization(onlyFPSOptions);
    this.CpgOpenFlag = true;
    this.ReadWriteInProgress = true;
    AppInfoManager.AppMode = ApplicationMode.CodeplugConfigurationMode;
    UndoManager.Reset();
    ((App) System.Windows.Application.Current).TheDocument.Initialized(false);
    this.SetFieldsAndCalculateFlashCodeOnInitialized(onlyFPSOptions);
    if (this.PromptQuitOnInvalids().Result)
    {
      this.UninitializeCodeplug();
      return (Motorola.Acp.PackUnpack.Ish.Codeplug) null;
    }
    PINPasswordUtil.UpdatePasswordsToClear();
    DataModemPasswordUtil.UpdateCipherPasswordsToPlain();
    AcpUI.Common.Utility.SaveFieldWithFocus();
    this.NATListFixup();
    MemoryCleaner.CleanGarbageFromMemory();
    TtsDataTreeUpdater.AddTtsToFeatureManager();
    MemoryCleaner.CleanGarbageFromMemory();
    PackUnpackExecutor packUnpackExecutor = new PackUnpackExecutor();
    packUnpackExecutor.PrePackHandler();
    return packUnpackExecutor.Pack(this.MyModelNumber);
  }

  private void UninitializeCodeplug()
  {
    ((App) System.Windows.Application.Current).TheDocument.FileClose();
    this.CpgOpenFlag = false;
    this.ReadWriteInProgress = false;
  }

  private void UninitializeMultiCodeplug() => ((App) System.Windows.Application.Current).TheDocument.FileClose();

  private FlashcodeTable InitDocModelTieringAndFcodeTable(string modelNumber)
  {
    this.DocumentOperations.InitDocument();
    ((App) System.Windows.Application.Current).TheDocument.FileNew();
    this.MyModelNumber = modelNumber;
    if (this.MyModelNumber.Trim().Length == 13 && this.MyModelNumber.Trim().ToUpper().EndsWith("I"))
      this.MyModelNumber = this.MyModelNumber.Trim().Substring(0, 12);
    this.objModelTiering = new ModelTiering(this.MyModelNumber, ModelTiering.ActionTypes.NEW, ModelTiering.TargetTypes.ALL);
    this.objModelTiering.UpdateUtilityMackModelType();
    this.IsMobileModel = UtilityMack.IsMobilePro;
    this.IsPortableModel = UtilityMack.IsPortablePro;
    FlashcodeTable flashcodeTable = new FlashcodeTable();
    flashcodeTable.InitTable(true, this.MyModelNumber);
    return flashcodeTable;
  }

  private void SetFieldsOnCodeplugInitialization(System.Collections.Generic.List<string> onlyFPSOptions)
  {
    if (!onlyFPSOptions.Contains("PCI_ADP_FLASHCODE_GATING"))
      onlyFPSOptions.Add("PCI_ADP_FLASHCODE_GATING");
    CodeplugFixups.AllowO3ControlHeadFixup(onlyFPSOptions);
    this.objModelTiering.FPSCustomizationOptions = onlyFPSOptions;
    this.objModelTiering.FPSInitializeOrderedOptions();
    ConstraintManager.Suspend();
    this.objModelTiering.ApplyTiering();
    ConstraintManager.Resume();
    Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation radioInformation = FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation;
    radioInformation.Tracking.RadInfoTrackingCodeplugVersion_A7688_UIValue = this.CPS_Version;
    radioInformation.General.RadInfoGeneralCodeplugVersion_A7683_UIValue = this.CPS_Version;
    radioInformation.Labtool.RadInfoLabtoolSecurePartitionVersionNumber_A9076_UIValue = this.CPS_Version;
    radioInformation.Labtool.RadInfoLabtoolOriginalSecurePartitionVersion_A8626_UIValue = this.CPS_Version;
    radioInformation.Labtool.RadInfoLabtoolQA09802CloudServicesDisablement.Value = onlyFPSOptions.Contains("QA09802");
    DateTime now = DateTime.Now;
    radioInformation.Tracking.RadInfoLabtoolBornOnDateDBValue_A7568Value = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, 0).ToUniversalTime().Ticks;
    this.SetProductModelIdentifierField();
    this.SetDVRSHoptionEnabledField();
    this.SetDVRSHwEnabledField();
    this.IsCpgConvOnly = false;
    CodeplugFixups.SetVoiceAnnouncementPath(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Motorola\\ApxFamilyCPS\\Common\\VoiceAnnouncementMvaFiles"));
    CodeplugFixups.SetVoiceAnnouncementDefaults();
    this.UpdatePaddingSpacesForSoftIDUsername();
  }

  private string SetFieldsAndCalculateFlashCodeOnInitialized(System.Collections.Generic.List<string> onlyFPSOptions)
  {
    string str = "GA00806";
    if (onlyFPSOptions.Contains(str))
    {
      this.ChangeACAsAllOff();
      this.SetALLOFFRecord4PursuitButton();
      this.setKeypadIndexDefaultValue();
      this.AddO9DefaultDirLightBar();
    }
    this.UpdateAuxControlTable();
    foreach (IAcpConstraints feature in FeatureManager.Features)
      feature.CallConstraints();
    this.objModelTiering.RecrefFixup();
    this.IsMobileModelSupportedControlHeads();
    string flashcodeResult = "";
    FlashcodeGenerator.CalculateFlashcode(ref flashcodeResult, this.MyModelNumber);
    (FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation).FLASHport.RadInfoFLASHportFLASHcode_A8132Value = flashcodeResult;
    return flashcodeResult;
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "8.0.8.0")]
  public void InitializeComponent()
  {
    if (this._contentLoaded)
      return;
    this._contentLoaded = true;
    System.Windows.Application.LoadComponent((object) this, new Uri("/APXFamilyCPS;component/windowmain.xaml", UriKind.Relative));
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "8.0.8.0")]
  [EditorBrowsable(EditorBrowsableState.Never)]
  void IComponentConnector.Connect(int connectionId, object target)
  {
    switch (connectionId)
    {
      case 1:
        ((FrameworkElement) target).Loaded += new RoutedEventHandler(this.OnLoad);
        ((Window) target).Closing += new CancelEventHandler(this.onExitApp);
        ((UIElement) target).Drop += new System.Windows.DragEventHandler(this.WindowMain_Drop);
        ((UIElement) target).MouseEnter += new System.Windows.Input.MouseEventHandler(this.WindowMain_AllowDrop);
        ((UIElement) target).MouseLeave += new System.Windows.Input.MouseEventHandler(this.WindowMain_AllowDrop);
        break;
      case 2:
        ((CommandBinding) target).Executed += new ExecutedRoutedEventHandler(this.OnClickRibbonBarCPSHelp);
        ((CommandBinding) target).CanExecute += new CanExecuteRoutedEventHandler(this.F1HelpCommandCanExcute);
        break;
      case 3:
        this.WindowMainDockPanel = (DockPanel) target;
        break;
      case 4:
        this.WindowMainRibbonControl = (Ribbon) target;
        break;
      case 5:
        this.imgRibbonAppMenu = (Image) target;
        break;
      case 6:
        this.AppMenuItemExitRibbonPad = (ButtonDropDown) target;
        break;
      case 7:
        this.AppMruList = (AcpListBoxMruFiles) target;
        this.AppMruList.FileClick += new RoutedEventHandler(this.OnAppMruFileOpen);
        break;
      case 8:
        this.AppMenuOpen = (ButtonDropDown) target;
        this.AppMenuOpen.Click += new RoutedEventHandler(this.OnAppMenuOpen);
        break;
      case 9:
        this.AppMenuSave = (ButtonDropDown) target;
        this.AppMenuSave.Click += new RoutedEventHandler(this.OnAppMenuSave);
        break;
      case 10:
        this.AppMenuPublish = (ButtonDropDown) target;
        this.AppMenuPublish.Click += new RoutedEventHandler(this.OnPublish);
        break;
      case 11:
        this.AppMenuSaveAs = (ButtonDropDown) target;
        this.AppMenuSaveAs.Click += new RoutedEventHandler(this.OnAppMenuSaveAs);
        break;
      case 12:
        this.AppMenuImport = (ButtonDropDown) target;
        this.AppMenuImport.Click += new RoutedEventHandler(this.OnAppMenuImport);
        break;
      case 13:
        this.AppMenuExport = (ButtonDropDown) target;
        this.AppMenuExport.Click += new RoutedEventHandler(this.OnAppMenuExport);
        break;
      case 14:
        this.AppMenuRMC = (ButtonDropDown) target;
        this.AppMenuRMC.Click += new RoutedEventHandler(this.OnAppMenuRadioManagement);
        break;
      case 15:
        this.AppMenuPrint = (ButtonDropDown) target;
        break;
      case 16 /*0x10*/:
        this.RadioInfo = (ButtonDropDown) target;
        this.RadioInfo.Click += new RoutedEventHandler(this.OnPrtRadioInfoReports);
        break;
      case 17:
        this.RadioHandOut = (ButtonDropDown) target;
        this.RadioHandOut.Click += new RoutedEventHandler(this.OnPrtHandOutReports);
        break;
      case 18:
        this.RadioHandOutO2 = (ButtonDropDown) target;
        this.RadioHandOutO2.Click += new RoutedEventHandler(this.OnPrtHandOutReportsO2);
        break;
      case 19:
        this.RadioHandOutO3 = (ButtonDropDown) target;
        this.RadioHandOutO3.Click += new RoutedEventHandler(this.OnPrtHandOutReportsO3);
        break;
      case 20:
        this.RadioHandOutE5 = (ButtonDropDown) target;
        this.RadioHandOutE5.Click += new RoutedEventHandler(this.OnPrtHandOutReportsE5);
        break;
      case 21:
        this.RadioHandOutO5 = (ButtonDropDown) target;
        this.RadioHandOutO5.Click += new RoutedEventHandler(this.OnPrtHandOutReportsO5);
        break;
      case 22:
        this.RadioHandOutO7 = (ButtonDropDown) target;
        this.RadioHandOutO7.Click += new RoutedEventHandler(this.OnPrtHandOutReportsO7);
        break;
      case 23:
        this.RadioHandOutO9 = (ButtonDropDown) target;
        this.RadioHandOutO9.Click += new RoutedEventHandler(this.OnPrtHandOutReportsO9);
        break;
      case 24:
        this.RadioPrintChoices = (ButtonDropDown) target;
        this.RadioPrintChoices.Click += new RoutedEventHandler(this.OnPrtChoicesReports);
        break;
      case 25:
        this.AppMenuClose = (ButtonDropDown) target;
        this.AppMenuClose.Click += new RoutedEventHandler(this.OnAppMenuClose);
        break;
      case 26:
        this.AppMenuOptions = (ButtonDropDown) target;
        this.AppMenuOptions.Click += new RoutedEventHandler(this.OnAppMenuOptions);
        break;
      case 27:
        this.AppMenuExit = (ButtonDropDown) target;
        this.AppMenuExit.Click += new RoutedEventHandler(this.OnAppMenuExit);
        break;
      case 28:
        this.QATDummy = (ButtonDropDown) target;
        break;
      case 29:
        this.QATOpen = (ButtonDropDown) target;
        this.QATOpen.Click += new RoutedEventHandler(this.OnQATOpen);
        break;
      case 30:
        this.QATSave = (ButtonDropDown) target;
        this.QATSave.Click += new RoutedEventHandler(this.OnAppMenuSave);
        break;
      case 31 /*0x1F*/:
        this.QATRMC = (ButtonDropDown) target;
        this.QATRMC.Click += new RoutedEventHandler(this.OnAppMenuRadioManagement);
        break;
      case 32 /*0x20*/:
        this.ribbonTabCodeplug = (RibbonTab) target;
        break;
      case 33:
        this.ribbonBarPanelCodeplug = (RibbonBarPanel) target;
        break;
      case 34:
        this.RibbonBarSave = (ButtonDropDown) target;
        this.RibbonBarSave.Click += new RoutedEventHandler(this.OnRibbonBarSaveCodeplug);
        break;
      case 35:
        this.RibbonBarPublish = (ButtonDropDown) target;
        this.RibbonBarPublish.Click += new RoutedEventHandler(this.OnPublish);
        break;
      case 36:
        this.ribbonBarEdit = (RibbonBar) target;
        break;
      case 37:
        this.QATUndo = (ButtonDropDown) target;
        this.QATUndo.Click += new RoutedEventHandler(this.OnQATUndo);
        break;
      case 38:
        this.QATRedo = (ButtonDropDown) target;
        this.QATRedo.Click += new RoutedEventHandler(this.OnQATRedo);
        break;
      case 39:
        this.ribbonBarRestore = (RibbonBar) target;
        this.ribbonBarRestore.GotFocus += new RoutedEventHandler(this.OnRibbonBarRestoreButtonsGotFoucs);
        this.ribbonBarRestore.LostFocus += new RoutedEventHandler(this.OnRibbonBarRestoreButtonsLostFocus);
        break;
      case 40:
        this.RibbonBarRtd = (ButtonDropDown) target;
        break;
      case 41:
        this.ribbonBarShowRtdButtons = (ButtonDropDown) target;
        this.ribbonBarShowRtdButtons.Click += new RoutedEventHandler(this.OnRibbonBarShowRtdButtons);
        break;
      case 42:
        this.RibbonBarRtdPageRestoreAll = (ButtonDropDown) target;
        this.RibbonBarRtdPageRestoreAll.Click += new RoutedEventHandler(this.OnRibbonBarPageRestoreAll);
        break;
      case 43:
        this.RibbonBarRtdInvalidsRestoreAll = (ButtonDropDown) target;
        this.RibbonBarRtdInvalidsRestoreAll.Click += new RoutedEventHandler(this.OnRibbonBarPageRestoreAllInvalids);
        break;
      case 44:
        this.RibbonBarSearch = (RibbonBar) target;
        break;
      case 45:
        this.FindToken = (System.Windows.Controls.TextBox) target;
        this.FindToken.KeyDown += new System.Windows.Input.KeyEventHandler(this.OnFindTokenKeyDown);
        break;
      case 46:
        this.RibbonBarEditingFind = (ButtonDropDown) target;
        break;
      case 47:
        this.RibbonBarEditingFindFieldName = (ButtonDropDown) target;
        this.RibbonBarEditingFindFieldName.Click += new RoutedEventHandler(this.OnFindFieldName);
        break;
      case 48 /*0x30*/:
        this.RibbonBarEditingFindFieldNameAndValue = (ButtonDropDown) target;
        this.RibbonBarEditingFindFieldNameAndValue.Click += new RoutedEventHandler(this.OnFindFieldNameAndValue);
        break;
      case 49:
        this.RibbonBarCompCodeplugStartEnd = (ButtonDropDown) target;
        this.RibbonBarCompCodeplugStartEnd.Click += new RoutedEventHandler(this.OnRibbonBarCompCodeplug);
        break;
      case 50:
        this.RibbonBarCompCodeplugStartEndImage = (Image) target;
        break;
      case 51:
        this.RibbonBarCompOptions = (ButtonDropDown) target;
        break;
      case 52:
        this.RibbonBarCompCodeplugHideUnideFlds = (ButtonDropDown) target;
        this.RibbonBarCompCodeplugHideUnideFlds.Click += new RoutedEventHandler(this.OnRibbonBarHideMatches);
        break;
      case 53:
        this.RibbonBarCompCodeplugPageCopyAll = (ButtonDropDown) target;
        this.RibbonBarCompCodeplugPageCopyAll.Click += new RoutedEventHandler(this.OnRibbonBarPageCopyAll);
        break;
      case 54:
        this.RibbonBarShowFS = (ButtonDropDown) target;
        this.RibbonBarShowFS.Click += new RoutedEventHandler(this.RibbonBarShowFS_Click);
        break;
      case 55:
        this.ribbonBarToolsPassword = (RibbonBar) target;
        break;
      case 56:
        this.ReadWritePassword = (ButtonDropDown) target;
        this.ReadWritePassword.Click += new RoutedEventHandler(this.OnRibbonBarPassword);
        break;
      case 57:
        this.ribbonBarDVRS = (RibbonBar) target;
        this.ribbonBarDVRS.LaunchDialog += new RoutedEventHandler(this.OnAppMenuOptions);
        break;
      case 58:
        this.DVRSExport = (ButtonDropDown) target;
        this.DVRSExport.Click += new RoutedEventHandler(this.OnRibbonBarDVRSExport);
        break;
      case 59:
        this.ribbonBarUpdateUCL = (RibbonBar) target;
        break;
      case 60:
        this.UpdateCallList = (ButtonDropDown) target;
        this.UpdateCallList.Click += new RoutedEventHandler(this.OnRibbonBarOpenUpdateUCL);
        break;
      case 61:
        this.ribbonTabCustomViewCfgMode = (RibbonTab) target;
        break;
      case 62:
        this.ribbonBarCustomViewPanel = (RibbonBarPanel) target;
        break;
      case 63 /*0x3F*/:
        this.ribbonBarCustomView = (RibbonBar) target;
        break;
      case 64 /*0x40*/:
        this.ribbonBarCustomViewOpen = (ButtonDropDown) target;
        this.ribbonBarCustomViewOpen.Click += new RoutedEventHandler(this.OnRibbonBarOpenCustomView);
        break;
      case 65:
        this.ribbonBarCustomViewNew = (ButtonDropDown) target;
        this.ribbonBarCustomViewNew.Click += new RoutedEventHandler(this.OnRibbonBarNewCustomView);
        break;
      case 66:
        this.ribbonBarCustomViewSaveAs = (ButtonDropDown) target;
        this.ribbonBarCustomViewSaveAs.Click += new RoutedEventHandler(this.OnRibbonBarSaveAsCustomView);
        break;
      case 67:
        this.ribbonBarCustomViewClose = (ButtonDropDown) target;
        this.ribbonBarCustomViewClose.Click += new RoutedEventHandler(this.OnRibbonBarCloseCustomView);
        break;
      case 68:
        this.ribbonBarCustomHowTo = (ButtonDropDown) target;
        this.ribbonBarCustomHowTo.Click += new RoutedEventHandler(this.OnRibbonBarCustomViewHelp);
        break;
      case 69:
        this.ribbonTabAppSettings = (RibbonTab) target;
        break;
      case 70:
        this.ribbonBarThemes = (RibbonBar) target;
        break;
      case 71:
        this.RibbonBarBarThemes = (ButtonDropDown) target;
        break;
      case 72:
        this.ClassicTheme = (ButtonDropDown) target;
        this.ClassicTheme.Click += new RoutedEventHandler(this.OnRibbonBarThemeItemClick);
        break;
      case 73:
        this.SilverTheme = (ButtonDropDown) target;
        this.SilverTheme.Click += new RoutedEventHandler(this.OnRibbonBarThemeItemClick);
        break;
      case 74:
        this.BlackTheme = (ButtonDropDown) target;
        this.BlackTheme.Click += new RoutedEventHandler(this.OnRibbonBarThemeItemClick);
        break;
      case 75:
        this.PoliceTheme = (ButtonDropDown) target;
        this.PoliceTheme.Click += new RoutedEventHandler(this.OnRibbonBarThemeItemClick);
        break;
      case 76:
        this.FiremanTheme = (ButtonDropDown) target;
        this.FiremanTheme.Click += new RoutedEventHandler(this.OnRibbonBarThemeItemClick);
        break;
      case 77:
        this.MilitaryTheme = (ButtonDropDown) target;
        this.MilitaryTheme.Click += new RoutedEventHandler(this.OnRibbonBarThemeItemClick);
        break;
      case 78:
        this.FullColorTheme = (ButtonDropDown) target;
        this.FullColorTheme.Click += new RoutedEventHandler(this.OnRibbonBarThemeItemClick);
        break;
      case 79:
        this.ribbonBarWindows = (RibbonBar) target;
        break;
      case 80 /*0x50*/:
        this.RibbonBarBarWindows = (ButtonDropDown) target;
        break;
      case 81:
        this.wndNavigation = (ButtonDropDown) target;
        break;
      case 82:
        this.wndNavigationHideCB = (AcpCheckBox) target;
        this.wndNavigationHideCB.Click += new RoutedEventHandler(this.OnRibbonBarWndHideClick);
        break;
      case 83:
        this.wndErrorList = (ButtonDropDown) target;
        break;
      case 84:
        this.wndErrorListHideCB = (AcpCheckBox) target;
        this.wndErrorListHideCB.Click += new RoutedEventHandler(this.OnRibbonBarWndHideClick);
        break;
      case 85:
        this.wndErrorListAutoRiseCB = (AcpCheckBox) target;
        this.wndErrorListAutoRiseCB.Click += new RoutedEventHandler(this.OnRibbonBarWndAutoRiseClick);
        break;
      case 86:
        this.wndInvalidFieldsReport = (ButtonDropDown) target;
        break;
      case 87:
        this.wndInvalidFieldsHideCB = (AcpCheckBox) target;
        this.wndInvalidFieldsHideCB.Click += new RoutedEventHandler(this.OnRibbonBarWndHideClick);
        break;
      case 88:
        this.wndInvalidFieldsAutoRiseCB = (AcpCheckBox) target;
        this.wndInvalidFieldsAutoRiseCB.Click += new RoutedEventHandler(this.OnRibbonBarWndAutoRiseClick);
        break;
      case 89:
        this.wndDnDReport = (ButtonDropDown) target;
        break;
      case 90:
        this.wndDnDReportHideCB = (AcpCheckBox) target;
        this.wndDnDReportHideCB.Click += new RoutedEventHandler(this.OnRibbonBarWndHideClick);
        break;
      case 91:
        this.wndDnDReportAutoRiseCB = (AcpCheckBox) target;
        this.wndDnDReportAutoRiseCB.Click += new RoutedEventHandler(this.OnRibbonBarWndAutoRiseClick);
        break;
      case 92:
        this.wndImpExpReport = (ButtonDropDown) target;
        break;
      case 93:
        this.wndImpExpReportHideCB = (AcpCheckBox) target;
        this.wndImpExpReportHideCB.Click += new RoutedEventHandler(this.OnRibbonBarWndHideClick);
        break;
      case 94:
        this.wndImpExpReportAutoRiseCB = (AcpCheckBox) target;
        this.wndImpExpReportAutoRiseCB.Click += new RoutedEventHandler(this.OnRibbonBarWndAutoRiseClick);
        break;
      case 95:
        this.wndComparatorReport = (ButtonDropDown) target;
        break;
      case 96 /*0x60*/:
        this.wndComparatorReportHideCB = (AcpCheckBox) target;
        this.wndComparatorReportHideCB.Click += new RoutedEventHandler(this.OnRibbonBarWndHideClick);
        break;
      case 97:
        this.wndComparatorReportAutoRiseCB = (AcpCheckBox) target;
        this.wndComparatorReportAutoRiseCB.Click += new RoutedEventHandler(this.OnRibbonBarWndAutoRiseClick);
        break;
      case 98:
        this.wndFillUpFillDownReport = (ButtonDropDown) target;
        break;
      case 99:
        this.wndFillUpFillDownReportHideCB = (AcpCheckBox) target;
        this.wndFillUpFillDownReportHideCB.Click += new RoutedEventHandler(this.OnRibbonBarWndHideClick);
        break;
      case 100:
        this.wndFillUpFillDownReportAutoRiseCB = (AcpCheckBox) target;
        this.wndFillUpFillDownReportAutoRiseCB.Click += new RoutedEventHandler(this.OnRibbonBarWndAutoRiseClick);
        break;
      case 101:
        this.wndFindResults = (ButtonDropDown) target;
        break;
      case 102:
        this.wndFindResultsHideCB = (AcpCheckBox) target;
        this.wndFindResultsHideCB.Click += new RoutedEventHandler(this.OnRibbonBarWndHideClick);
        break;
      case 103:
        this.wndFindResultsAutoRiseCB = (AcpCheckBox) target;
        this.wndFindResultsAutoRiseCB.Click += new RoutedEventHandler(this.OnRibbonBarWndAutoRiseClick);
        break;
      case 104:
        this.wndFieldInfo = (ButtonDropDown) target;
        break;
      case 105:
        this.wndFieldInfoHideCB = (AcpCheckBox) target;
        this.wndFieldInfoHideCB.Click += new RoutedEventHandler(this.OnRibbonBarWndHideClick);
        break;
      case 106:
        this.wndSysKeyRpt = (ButtonDropDown) target;
        break;
      case 107:
        this.wndSysKeyRptHideCB = (AcpCheckBox) target;
        this.wndSysKeyRptHideCB.Click += new RoutedEventHandler(this.OnRibbonBarWndHideClick);
        break;
      case 108:
        this.wndSysKeyRptAutoRiseCB = (AcpCheckBox) target;
        this.wndSysKeyRptAutoRiseCB.Click += new RoutedEventHandler(this.OnRibbonBarWndAutoRiseClick);
        break;
      case 109:
        this.ribbonBarView = (RibbonBar) target;
        break;
      case 110:
        this.DiffViewType = (System.Windows.Controls.ComboBox) target;
        this.DiffViewType.SelectionChanged += new SelectionChangedEventHandler(this.OnRibbonBarUserViewSelChg);
        break;
      case 111:
        this.ribbonTabDeviceMgmtMode = (RibbonTab) target;
        break;
      case 112 /*0x70*/:
        this.ribbonBarDevicePanel = (RibbonBarPanel) target;
        break;
      case 113:
        this.ribbonBarDeviceReadWrite = (RibbonBar) target;
        break;
      case 114:
        this.ribbonBarDeviceRead = (ButtonDropDown) target;
        this.ribbonBarDeviceRead.Click += new RoutedEventHandler(this.OnRibbonBarReadRadio);
        break;
      case 115:
        this.ribbonBarDeviceWrite = (ButtonDropDown) target;
        this.ribbonBarDeviceWrite.Click += new RoutedEventHandler(this.OnRibbonBarWriteRadio);
        break;
      case 116:
        this.DeviceTransportComboBox = (System.Windows.Controls.ComboBox) target;
        this.DeviceTransportComboBox.SelectionChanged += new SelectionChangedEventHandler(this.Device_TransportComboBox_SelectionChanged);
        break;
      case 117:
        this.labBTIPAddressForWR = (AcpLabel) target;
        break;
      case 118:
        this.txtBTIPAddressForWR = (System.Windows.Controls.TextBox) target;
        this.txtBTIPAddressForWR.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.OnPreviewKeyDown_BTIPAddressForWR);
        break;
      case 119:
        this.ribbonBarDeviceCloning = (RibbonBar) target;
        break;
      case 120:
        this.ribbonBarCloneWizard = (ButtonDropDown) target;
        this.ribbonBarCloneWizard.Click += new RoutedEventHandler(this.OnRibbonBarCloneWizard);
        break;
      case 121:
        this.ribbonBarCloneExpress = (ButtonDropDown) target;
        this.ribbonBarCloneExpress.Click += new RoutedEventHandler(this.OnRibbonBarCloneExpress);
        break;
      case 122:
        this.CloneransportComboBox = (System.Windows.Controls.ComboBox) target;
        this.CloneransportComboBox.SelectionChanged += new SelectionChangedEventHandler(this.Device_CloneTransport_SelectionChanged);
        break;
      case 123:
        this.labBTIPAddressForClone = (AcpLabel) target;
        break;
      case 124:
        this.txtBTIPAddressForClone = (System.Windows.Controls.TextBox) target;
        this.txtBTIPAddressForClone.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.OnPreviewKeyDown_BTIPAddressForClone);
        break;
      case 125:
        this.ribbonBarDeviceFlashport = (RibbonBar) target;
        break;
      case 126:
        this.ribbonBarReadRadCfg = (ButtonDropDown) target;
        this.ribbonBarReadRadCfg.Click += new RoutedEventHandler(this.OnRibbonBarReadRadCfg);
        break;
      case (int) sbyte.MaxValue:
        this.ribbonBarFlashRadio = (ButtonDropDown) target;
        this.ribbonBarFlashRadio.Click += new RoutedEventHandler(this.OnRibbonBarFlashRadio);
        break;
      case 128 /*0x80*/:
        this.ribbonBarReadFlashKeyCfg = (ButtonDropDown) target;
        this.ribbonBarReadFlashKeyCfg.Click += new RoutedEventHandler(this.OnRibbonBarReadFlashKeyCfg);
        break;
      case 129:
        this.ribbonBarRefreshRadio = (ButtonDropDown) target;
        this.ribbonBarRefreshRadio.Click += new RoutedEventHandler(this.OnRibbonBarFlashRadio);
        break;
      case 130:
        this.ribbonBarDisableWP = (RibbonBar) target;
        break;
      case 131:
        this.AppMenuWriteProtect = (ButtonDropDown) target;
        this.AppMenuWriteProtect.Click += new RoutedEventHandler(this.OnAppMenuQuerySetRadio);
        break;
      case 132:
        this.RibbonBarShowMultiCodeplug = (ButtonDropDown) target;
        this.RibbonBarShowMultiCodeplug.Click += new RoutedEventHandler(this.RibbonBarShowMultiCodeplug_Click);
        break;
      case 133:
        this.ribbonTabSecurity = (RibbonTab) target;
        break;
      case 134:
        this.ribbonTabTools = (RibbonTab) target;
        break;
      case 135:
        this.ribbonBarSysKey = (RibbonBar) target;
        this.ribbonBarSysKey.LaunchDialog += new RoutedEventHandler(this.OnAppMenuOptions);
        break;
      case 136:
        this.ribbonBarLoadASK = (ButtonDropDown) target;
        this.ribbonBarLoadASK.Click += new RoutedEventHandler(this.OnRibbonBarLoadASK);
        break;
      case 137:
        this.ribbonBarLoadSWKey = (ButtonDropDown) target;
        this.ribbonBarLoadSWKey.Click += new RoutedEventHandler(this.OnRibbonBarLoadSWKey);
        break;
      case 138:
        this.ribbonBarToolsReports = (RibbonBar) target;
        break;
      case 139:
        this.RibbonRadioInformation = (ButtonDropDown) target;
        this.RibbonRadioInformation.Click += new RoutedEventHandler(this.OnPrtRadioInfoReports);
        break;
      case 140:
        this.RibbonRadioHandOut = (ButtonDropDown) target;
        this.RibbonRadioHandOut.Click += new RoutedEventHandler(this.OnPrtHandOutReports);
        break;
      case 141:
        this.RibbonRadioHandOutO2 = (ButtonDropDown) target;
        this.RibbonRadioHandOutO2.Click += new RoutedEventHandler(this.OnPrtHandOutReportsO2);
        break;
      case 142:
        this.RibbonRadioHandOutO3 = (ButtonDropDown) target;
        this.RibbonRadioHandOutO3.Click += new RoutedEventHandler(this.OnPrtHandOutReportsO3);
        break;
      case 143:
        this.RibbonRadioHandOutE5 = (ButtonDropDown) target;
        this.RibbonRadioHandOutE5.Click += new RoutedEventHandler(this.OnPrtHandOutReportsE5);
        break;
      case 144 /*0x90*/:
        this.RibbonRadioHandOutO5 = (ButtonDropDown) target;
        this.RibbonRadioHandOutO5.Click += new RoutedEventHandler(this.OnPrtHandOutReportsO5);
        break;
      case 145:
        this.RibbonRadioHandOutO7 = (ButtonDropDown) target;
        this.RibbonRadioHandOutO7.Click += new RoutedEventHandler(this.OnPrtHandOutReportsO7);
        break;
      case 146:
        this.RibbonRadioHandOutO9 = (ButtonDropDown) target;
        this.RibbonRadioHandOutO9.Click += new RoutedEventHandler(this.OnPrtHandOutReportsO9);
        break;
      case 147:
        this.RibbonRadioPrintChoices = (ButtonDropDown) target;
        this.RibbonRadioPrintChoices.Click += new RoutedEventHandler(this.OnPrtChoicesReports);
        break;
      case 148:
        this.ribbonBarToolsVoiceAnnouncement = (RibbonBar) target;
        break;
      case 149:
        this.VAConvertUtil = (ButtonDropDown) target;
        this.VAConvertUtil.Click += new RoutedEventHandler(this.OnRibbonBarConvertVoiceAnnouncementFiles);
        break;
      case 150:
        this.VACpgUsage = (ButtonDropDown) target;
        this.VACpgUsage.Click += new RoutedEventHandler(this.OnRibbonBarCalculateVoiceAnnouncementSize);
        break;
      case 151:
        this.VADownldUtil = (ButtonDropDown) target;
        this.VADownldUtil.Click += new RoutedEventHandler(this.OnRibbonBarDownLoadVoiceFile);
        break;
      case 152:
        this.ribbonBarToolsPOP25Scheduler = (RibbonBar) target;
        break;
      case 153:
        this.POP25RadioList = (ButtonDropDown) target;
        this.POP25RadioList.Click += new RoutedEventHandler(this.OnRibbonBarCreateRadioList);
        break;
      case 154:
        this.POP25BatchScheduler = (ButtonDropDown) target;
        this.POP25BatchScheduler.Click += new RoutedEventHandler(this.OnRibbonBarOpenPOP25BatchScheduler);
        break;
      case 155:
        this.ribbonBarRadioManagement = (RibbonBar) target;
        break;
      case 156:
        this.RadioManagement = (ButtonDropDown) target;
        this.RadioManagement.Click += new RoutedEventHandler(this.OnAppMenuRadioManagement);
        break;
      case 157:
        this.ribbonBarToolsOptions = (RibbonBar) target;
        break;
      case 158:
        this.Options = (ButtonDropDown) target;
        this.Options.Click += new RoutedEventHandler(this.OnAppMenuOptions);
        break;
      case 159:
        this.ribbonBarToolsLoadCertificate = (RibbonBar) target;
        break;
      case 160 /*0xA0*/:
        this.ribbonBarLoadTxmCertificate = (ButtonDropDown) target;
        this.ribbonBarLoadTxmCertificate.Click += new RoutedEventHandler(this.OnRibbonBarLoadTxmCertificate);
        break;
      case 161:
        this.ribbonBarToolsPasswordReset = (RibbonBar) target;
        break;
      case 162:
        this.ribbonBarResetPasswordBtn = (ButtonDropDown) target;
        this.ribbonBarResetPasswordBtn.Click += new RoutedEventHandler(this.OnRibbonBarResetPassword);
        break;
      case 163:
        this.ribbonTabHelp = (RibbonTab) target;
        break;
      case 164:
        this.ribbonBarHelpContent = (RibbonBar) target;
        break;
      case 165:
        this.ribbonBarCPSHelp = (ButtonDropDown) target;
        this.ribbonBarCPSHelp.Click += new RoutedEventHandler(this.OnClickRibbonBarCPSHelp);
        break;
      case 166:
        this.ribbonBarAboutCPS = (ButtonDropDown) target;
        this.ribbonBarAboutCPS.Click += new RoutedEventHandler(this.OnClickRibbonBarAboutCPS);
        break;
      case 167:
        this.ribbonBarTutorials = (ButtonDropDown) target;
        this.ribbonBarTutorials.Click += new RoutedEventHandler(this.OnClickRibbonBarAboutTutorials);
        break;
      case 168:
        this.ribbonBarSpecKeyReport = (ButtonDropDown) target;
        break;
      case 169:
        this.specKeyListView = (System.Windows.Controls.ListView) target;
        break;
      case 170:
        this.SpecKeyReport = (GridView) target;
        break;
      case 171:
        this.specKeyType = (GridViewColumn) target;
        break;
      case 172:
        this.SerialNum = (GridViewColumn) target;
        break;
      case 173:
        this.ribbonBarHelpButton = (ButtonDropDown) target;
        this.ribbonBarHelpButton.Click += new RoutedEventHandler(this.OnClickRibbonBarCPSHelp);
        break;
      case 174:
        this.AppClose = (ButtonDropDown) target;
        this.AppClose.Click += new RoutedEventHandler(this.OnAppMenuClose);
        break;
      case 175:
        this.WindowMainFrame = (System.Windows.Controls.Frame) target;
        break;
      default:
        this._contentLoaded = true;
        break;
    }
  }

  public delegate void ReadRadioCompleted(bool status);

  public delegate void ReadComplete(
    bool stat,
    string strErrorMessage,
    string infoMsg,
    RadioParams radioPara);

  private delegate void ErrorStatus(string err);

  private delegate void UpdateProgress(ProgressChangedEventArgs progress);

  public delegate void MainUIDisplayCBI(SpecialFeatures.Comms.Comms.CBIReturn CbiSN);

  public delegate void MainUIDisplayOTAP(
    ProgrammingOperation ProgOp,
    OTAPProgrammingParameters LastCommsOTAPUserState,
    SpecialFeatures.Comms.Comms.RadioOTAPObject radioObject);

  public delegate void WriteRadioQuery(SpecialFeatures.Comms.Comms.RadioRtn info);

  public delegate void UpdateIsMobileModel(bool Mobile);

  public delegate void UpdateIsPortableModel(bool Portable);

  public delegate void AbortFileOpen();

  private delegate void CloseProgressWindow();

  internal enum CodeplugFileType
  {
    None,
    Mc,
    Cxf,
  }

  private class NativeMethods
  {
    [DllImport("user32.dll")]
    public static extern bool SetWindowPlacement(
      IntPtr hWnd,
      [In] ref WindowMain.WINDOWPLACEMENT lpwndpl);

    [DllImport("user32.dll")]
    public static extern bool GetWindowPlacement(
      IntPtr hWnd,
      out WindowMain.WINDOWPLACEMENT lpwndpl);
  }

  [Serializable]
  public struct WINDOWPLACEMENT
  {
    public int length;
    public int flags;
    public int showCmd;
    public WindowMain.CPSLocation minPosition;
    public WindowMain.CPSLocation maxPosition;
    public WindowMain.CPSSize normalPosition;
  }

  [Serializable]
  public struct CPSSize(int left, int top, int right, int bottom)
  {
    public int Left = left;
    public int Top = top;
    public int Right = right;
    public int Bottom = bottom;
  }

  [Serializable]
  public struct CPSLocation(int x, int y)
  {
    public int X = x;
    public int Y = y;
  }
}
