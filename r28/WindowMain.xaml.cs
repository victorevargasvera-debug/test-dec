// Decompiled with JetBrains decompiler
// Type: MackinawCPS.WindowMain
// Assembly: APXFamilyCPS, Version=15.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 7983BD42-76AB-479D-8966-B7B635E0E28A
// Assembly location: C:\Program Files (x86)\Motorola\ApxFamilyDepot R28\APXdepotR28.exe

using AcpASKLib;
using AcpBusinessLayer;
using AcpBusinessLayer.UndoRedo;
using AcpCommonLib;
using AcpCommonLib.FieldsReport;
using AcpCommonLib.FindResult;
using AcpCommonLib.StatusMessage;
using AcpCommonLib.UndoRedo;
using AcpFileHandlerLib;
using AcpKeyValidatorLib;
using AcpSecurityLib;
using AcpUI;
using AcpUI.Common;
using AcpUI.Comparator;
using AcpUI.CustomView;
using AcpUI.ImportExport;
using AcpUI.Mru;
using AcpUILib;
using AcpUtility;
using Common;
using CommonResources;
using ConstraintHelper;
using DevComponents.WpfDock;
using DevComponents.WpfRibbon;
using MackinawCPS.CommandLineCPS;
using MackinawCPS.HomeBase;
using MackinawCPS.Properties;
using MackinawCPS.themes;
using Motorola.Acp.PackUnpack.Ish;
using Motorola.Acp.PackUnpack.Ish.Collections;
using Motorola.Common.Communication.CommonUtil;
using Motorola.Common.CustomException;
using Motorola.CommonCPS.RadioManagement.Core;
using Motorola.CommonCPS.RadioManagement.Global;
using Motorola.CommonCPS.RadioManagement.SharedServices;
using Motorola.CommonCPS.Server.EntityModel;
using Motorola.CommonCPS.Server.EntityModel.GenericModel;
using Motorola.MackinawCPS.CoreFeatures.ActionConsolidation;
using Motorola.MackinawCPS.CoreFeatures.ASTROTalkgroupList;
using Motorola.MackinawCPS.CoreFeatures.Buttons;
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
using Motorola.MackinawCPS.CoreFeatures.DVRSProfiles;
using Motorola.MackinawCPS.CoreFeatures.DVRSWide;
using Motorola.MackinawCPS.CoreFeatures.EmergencyWide;
using Motorola.MackinawCPS.CoreFeatures.EnhancedDataPortList;
using Motorola.MackinawCPS.CoreFeatures.ExternalMicNoiseReductionProfile;
using Motorola.MackinawCPS.CoreFeatures.FactoryOverrides;
using Motorola.MackinawCPS.CoreFeatures.GlobalNoiseReductionList;
using Motorola.MackinawCPS.CoreFeatures.InternalMicNoiseReductionProfile;
using Motorola.MackinawCPS.CoreFeatures.Keypad;
using Motorola.MackinawCPS.CoreFeatures.KeypadMicAndAccessories;
using Motorola.MackinawCPS.CoreFeatures.MenuItems;
using Motorola.MackinawCPS.CoreFeatures.MissionCriticalGeofence;
using Motorola.MackinawCPS.CoreFeatures.MPLConfiguration;
using Motorola.MackinawCPS.CoreFeatures.NonGUIFeature;
using Motorola.MackinawCPS.CoreFeatures.PackExec;
using Motorola.MackinawCPS.CoreFeatures.PersonnelAccountability;
using Motorola.MackinawCPS.CoreFeatures.PhoneWide;
using Motorola.MackinawCPS.CoreFeatures.RadioErgonomicsWide;
using Motorola.MackinawCPS.CoreFeatures.RadioInformation;
using Motorola.MackinawCPS.CoreFeatures.RadioProfiles;
using Motorola.MackinawCPS.CoreFeatures.RadioVIPs;
using Motorola.MackinawCPS.CoreFeatures.RadioWide;
using Motorola.MackinawCPS.CoreFeatures.RemoteSpeakerMic;
using Motorola.MackinawCPS.CoreFeatures.RepeaterIDList;
using Motorola.MackinawCPS.CoreFeatures.ScanList;
using Motorola.MackinawCPS.CoreFeatures.ScanWide;
using Motorola.MackinawCPS.CoreFeatures.SecureKMFProfile;
using Motorola.MackinawCPS.CoreFeatures.SecureWide;
using Motorola.MackinawCPS.CoreFeatures.Shepherds;
using Motorola.MackinawCPS.CoreFeatures.SmartKeyFob;
using Motorola.MackinawCPS.CoreFeatures.Switches;
using Motorola.MackinawCPS.CoreFeatures.ToneSignalingList;
using Motorola.MackinawCPS.CoreFeatures.TrunkingEmergencyProfiles;
using Motorola.MackinawCPS.CoreFeatures.TrunkingPersonality;
using Motorola.MackinawCPS.CoreFeatures.TrunkingSystem;
using Motorola.MackinawCPS.CoreFeatures.TrunkingWide;
using Motorola.MackinawCPS.CoreFeatures.ZoneChannelAssignment;
using SpecialFeatures;
using SpecialFeatures.AcpReportManagerLib;
using SpecialFeatures.CBISerialNum;
using SpecialFeatures.Clone_Configuration.Common;
using SpecialFeatures.CloneExpress;
using SpecialFeatures.CloneWizard;
using SpecialFeatures.Comms;
using SpecialFeatures.DepotLabtool;
using SpecialFeatures.DVRSXML;
using SpecialFeatures.Flashport;
using SpecialFeatures.Flashport.FlashkeyConfiguration;
using SpecialFeatures.Flashport.FlashRadio;
using SpecialFeatures.Flashport.RadioConfiguration;
using SpecialFeatures.Model_Configuration;
using SpecialFeatures.POP25BatchProgrammer;
using SpecialFeatures.Programming;
using SpecialFeatures.RadioFeatureSet;
using SpecialFeatures.RadioLanguagePack;
using SpecialFeatures.ReadWritePassword;
using SpecialFeatures.Security;
using SpecialFeatures.UCL.CallListUpdate;
using SpecialFeatures.Ucl.Contact;
using SpecialFeatures.Ucl.HotList;
using SpecialFeatures.Ucl.UclWide;
using SpecialFeatures.Utilites;
using SpecialFeatures.Utilities;
using SpecialFeatures.VoiceAnnouncements;
using SpecialFeatures.VoiceAnnouncements.List;
using SpecialFeatures.VoiceAnnouncements.SiteSelectableAlertList;
using SpecialFeatures.VoiceAnnouncements.Wide;
using SSLAdminTool;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Threading;

#nullable disable
namespace MackinawCPS;

public partial class WindowMain : 
  RibbonWindow,
  INotifyPropertyChanged,
  IDisposable,
  IComponentConnector
{
  internal const int byte64 = 64 /*0x40*/;
  internal const int byte256 = 256 /*0x0100*/;
  internal const int byte512 = 512 /*0x0200*/;
  private const int SW_SHOWNORMAL = 1;
  private const int SW_SHOWMINIMIZED = 2;
  private string lastOpenCodePlugPath = string.Empty;
  private string defaulfBTPANIP = "192.168.132.1";
  private DeviceOperationInProgressWindow OperationInProgressWindow;
  private Thread m_DHGeneration = (Thread) null;
  private DvrsMsuDataSync dvrsMsuDataSync = (DvrsMsuDataSync) null;
  private APXTemplate templateFromServer = (APXTemplate) null;
  private APXRadio deviceFromServer = (APXRadio) null;
  private RMCWnd rMCWnd = (RMCWnd) null;
  internal ProgressUpdate progressPage = (ProgressUpdate) null;
  internal Semaphore test;
  internal Semaphore testOTAP;
  internal Semaphore QueryRadio;
  private AcpIuiPage pageIUI = (AcpIuiPage) null;
  private bool cpgOpenFlag = false;
  private bool isFreonProduct = false;
  private bool defaultCpgOpenFlag = false;
  private bool customViewOpenFlag = false;
  private PaneItem selectedNavigationMode = (PaneItem) null;
  private ModelTiering objModelTiering;
  private string MyModelNumber = (string) null;
  private Dictionary<eAcpColorScheme, ResourceDictionary> AppColorSchemes = (Dictionary<eAcpColorScheme, ResourceDictionary>) null;
  private eAcpColorScheme currentColorTheme;
  private eRibbonVisualStyle currentRibbonColor;
  private eDockVisualStyle currentDockColor;
  private object currentAppViewInfo;
  private string customVwPath = (string) null;
  private AcpUndoHelper undoHelper = (AcpUndoHelper) null;
  internal Settings settingsSavedOnAppExit = new Settings();
  private string cpgFileName = (string) null;
  private string cpsVersion = (string) null;
  private bool bCloseSplashScreen = true;
  private bool bSaveCpgSuccessful = false;
  internal DifferentiatedUserViewType SavedCurrentViewType = DifferentiatedUserViewType.Full;
  internal string defaultKeyFilesLocation = (string) null;
  internal string defaultDVRSFileLocation = (string) null;
  private static string defaultLogoPath = "../../images/Mix3.jpg";
  private bool bUnlimitedKeyLoaded = false;
  private bool isDnDorImpDoneBeforeTheOper = false;
  public static readonly DependencyProperty ReadWriteTransportProperty = DependencyProperty.Register(nameof (ReadWriteTransport), typeof (int), typeof (WindowMain), new PropertyMetadata((object) 0));
  public static readonly DependencyProperty CloneTransportProperty = DependencyProperty.Register(nameof (CloneTransport), typeof (int), typeof (WindowMain), new PropertyMetadata((object) 0));
  private object commsLastUserState = (object) null;
  internal static readonly DependencyProperty OTAPKeyLoadedProperty = DependencyProperty.Register(nameof (OTAPKeyLoaded), typeof (bool), typeof (WindowMain), new PropertyMetadata((object) false));
  private bool ribbonBarRtdPageRestoreAllIsEnabled;
  private bool ribbonBarShowRtdButtonsIsEnabled;
  private bool storedRtdButtonsStatus;
  private string upgradeFile = "";
  private bool otapEnabledCodeplug = false;
  private bool readWriteInProgress = false;
  internal BackgroundWorker bgReadWorker = (BackgroundWorker) null;
  internal BackgroundWorker bgWriteWorker = (BackgroundWorker) null;
  private static BooleanSwitch BlockPackOnInvalids = new BooleanSwitch(nameof (BlockPackOnInvalids), AppResources.Block_packing_if_codeplug_has_invalid_fields);
  private static BooleanSwitch SuppressPackInvalidsPopup = new BooleanSwitch(nameof (SuppressPackInvalidsPopup), AppResources.Suppress_packing_with_invalid_fields_popup);
  private bool pop25Enabled = false;
  private bool specKeyLoaded = false;
  private bool labtoolKeyLoaded = true;
  private bool depotKeyLoaded = false;
  public static WindowMain _appMainFrame = (WindowMain) null;
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
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal DockPanel WindowMainDockPanel;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal Ribbon WindowMainRibbonControl;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal Image imgRibbonAppMenu;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown AppMenuItemExitRibbonPad;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal AcpListBoxMruFiles AppMruList;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown AppMenuOpen;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown AppMenuSave;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown AppMenuSaveAs;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown AppMenuImport;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown AppMenuExport;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown AppMenuRMC;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal Separator AppMenuRMCSep;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown AppMenuPrint;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown RadioInfo;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown RadioHandOut;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown RadioHandOutO2;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown RadioHandOutO3;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown RadioHandOutO5;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown RadioHandOutO7;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown RadioHandOutO9;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown RadioUserDefined;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown RadioPrintChoices;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown AppMenuClose;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown AppMenuOptions;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown AppMenuExit;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown QATDummy;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown QATOpen;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown QATSave;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown QATRMC;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal RibbonTab ribbonTabCodeplug;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal RibbonBarPanel ribbonBarPanelCodeplug;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown RibbonBarSave;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal RibbonBar ribbonBarEdit;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown QATUndo;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown QATRedo;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal RibbonBar ribbonBarRestore;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown RibbonBarRtd;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown ribbonBarShowRtdButtons;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown RibbonBarRtdPageRestoreAll;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown RibbonBarRtdInvalidsRestoreAll;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal RibbonBar RibbonBarSearch;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal System.Windows.Controls.TextBox FindToken;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown RibbonBarEditingFind;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown RibbonBarEditingFindFieldName;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown RibbonBarEditingFindFieldNameAndValue;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown RibbonBarCompCodeplugStartEnd;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal Image RibbonBarCompCodeplugStartEndImage;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown RibbonBarCompOptions;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown RibbonBarCompCodeplugHideUnideFlds;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown RibbonBarCompCodeplugPageCopyAll;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown RibbonBarShowFS;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal RibbonBar ribbonBarToolsPassword;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown ReadWritePassword;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal RibbonBar ribbonBarDVRS;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown DVRSExport;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal RibbonBar ribbonBarUpdateUCL;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown UpdateCallList;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal RibbonTab ribbonTabCustomViewCfgMode;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal RibbonBarPanel ribbonBarCustomViewPanel;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal RibbonBar ribbonBarCustomView;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown ribbonBarCustomViewOpen;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown ribbonBarCustomViewNew;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown ribbonBarCustomViewSaveAs;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown ribbonBarCustomViewClose;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown ribbonBarCustomHowTo;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal RibbonTab ribbonTabAppSettings;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal RibbonBar ribbonBarThemes;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown RibbonBarBarThemes;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown ClassicTheme;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown SilverTheme;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown BlackTheme;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown PoliceTheme;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown FiremanTheme;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown MilitaryTheme;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown FullColorTheme;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal RibbonBar ribbonBarWindows;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown RibbonBarBarWindows;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown wndNavigation;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal AcpCheckBox wndNavigationHideCB;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown wndErrorList;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal AcpCheckBox wndErrorListHideCB;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal AcpCheckBox wndErrorListAutoRiseCB;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown wndInvalidFieldsReport;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal AcpCheckBox wndInvalidFieldsHideCB;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal AcpCheckBox wndInvalidFieldsAutoRiseCB;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown wndDnDReport;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal AcpCheckBox wndDnDReportHideCB;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal AcpCheckBox wndDnDReportAutoRiseCB;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown wndImpExpReport;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal AcpCheckBox wndImpExpReportHideCB;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal AcpCheckBox wndImpExpReportAutoRiseCB;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown wndComparatorReport;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal AcpCheckBox wndComparatorReportHideCB;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal AcpCheckBox wndComparatorReportAutoRiseCB;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown wndFillUpFillDownReport;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal AcpCheckBox wndFillUpFillDownReportHideCB;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal AcpCheckBox wndFillUpFillDownReportAutoRiseCB;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown wndFindResults;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal AcpCheckBox wndFindResultsHideCB;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal AcpCheckBox wndFindResultsAutoRiseCB;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown wndFieldInfo;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal AcpCheckBox wndFieldInfoHideCB;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown wndSysKeyRpt;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal AcpCheckBox wndSysKeyRptHideCB;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal AcpCheckBox wndSysKeyRptAutoRiseCB;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal RibbonBar ribbonBarView;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal System.Windows.Controls.ComboBox DiffViewType;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal RibbonTab ribbonTabDeviceMgmtMode;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal RibbonBarPanel ribbonBarDevicePanel;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal RibbonBar ribbonBarDeviceReadWrite;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown ribbonBarDeviceRead;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown ribbonBarDeviceWrite;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal System.Windows.Controls.ComboBox DeviceTransportComboBox;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal AcpLabel labBTIPAddressForWR;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal System.Windows.Controls.TextBox txtBTIPAddressForWR;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal RibbonBar ribbonBarDeviceCloning;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown ribbonBarCloneWizard;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown ribbonBarCloneExpress;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal System.Windows.Controls.ComboBox CloneransportComboBox;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal AcpLabel labBTIPAddressForClone;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal System.Windows.Controls.TextBox txtBTIPAddressForClone;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal RibbonBar ribbonBarDeviceFlashport;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown ribbonBarReadRadCfg;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown ribbonBarFlashRadio;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown ribbonBarReadFlashKeyCfg;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown ribbonBarRefreshRadio;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal RibbonBar ribbonBarDisableWP;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown AppMenuWriteProtect;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal RibbonTab ribbonTabSecurity;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal RibbonTab ribbonTabTools;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal RibbonBar ribbonBarSysKey;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown ribbonBarLoadASK;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown ribbonBarLoadSWKey;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal RibbonBar ribbonBarToolsReports;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown RibbonRadioInformation;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown RibbonRadioHandOut;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown RibbonRadioHandOutO2;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown RibbonRadioHandOutO3;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown RibbonRadioHandOutO5;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown RibbonRadioHandOutO7;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown RibbonRadioHandOutO9;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown RibbonRadioUserDefined;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown RibbonRadioPrintChoices;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal RibbonBar ribbonBarToolsVoiceAnnouncement;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown VAConvertUtil;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown VACpgUsage;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown VADownldUtil;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal RibbonBar ribbonBarToolsPOP25Scheduler;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown POP25RadioList;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown POP25BatchScheduler;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal RibbonBar ribbonBarRadioManagement;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown RadioManagement;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal RibbonBar ribbonBarToolsOptions;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown Options;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal RibbonBar ribbonBarToolsDepot;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown ribbonBarToolsCreateCp;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown ribbonBarToolsUpgradeCodeplug;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown ribbonBarToolsForceWriteRadio;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown ribbonBarToolsUpgradeRadio;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown ribbonBarToolsCbiProgram;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal RibbonTab ribbonTabHelp;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal RibbonBar ribbonBarHelpContent;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown ribbonBarCPSHelp;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown ribbonBarAboutCPS;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown ribbonBarWhatsNew;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown ribbonBarTutorials;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown ribbonBarSpecKeyReport;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal System.Windows.Controls.ListView specKeyListView;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal GridView SpecKeyReport;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal GridViewColumn specKeyType;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal GridViewColumn SerialNum;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown ribbonBarHelpButton;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ButtonDropDown AppClose;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal System.Windows.Controls.Frame WindowMainFrame;
  private bool _contentLoaded;

  public event WindowMain.ReadRadioCompleted readRadioComplete;

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
    if (this.OperationInProgressWindow != null)
    {
      this.OperationInProgressWindow.Dispose();
      this.OperationInProgressWindow = (DeviceOperationInProgressWindow) null;
    }
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
      if (this.PropertyChanged == null)
        return;
      this.PropertyChanged((object) this, new PropertyChangedEventArgs(nameof (CpgOpenFlag)));
      this.PropertyChanged((object) this, new PropertyChangedEventArgs("CanOpenCpgFlag"));
      this.PropertyChanged((object) this, new PropertyChangedEventArgs("BlockRadioIO"));
      this.PropertyChanged((object) this, new PropertyChangedEventArgs("DeviceFromServer"));
      this.PropertyChanged((object) this, new PropertyChangedEventArgs("TemplateFromServer"));
      this.PropertyChanged((object) this, new PropertyChangedEventArgs("BlockFlashIO"));
      this.PropertyChanged((object) this, new PropertyChangedEventArgs("OtapEnabledCodeplug"));
    }
  }

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
      if (SecurityManager.IsSpecialKeyLoaded)
        canSaveCpgFlag = SecurityManager.CheckIfSpecialKeyIsAttached();
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

  internal static string DefaultLogoPath => WindowMain.defaultLogoPath;

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
    bool flag = this.OpenCodeplug(fileName, d, t, ref empty);
    if (flag)
      this.HandleInValidFieldBackwardCompatibilityForMCFile();
    this.WindowMain_AllowDrop((object) null, (System.Windows.Input.MouseEventArgs) null);
    return flag;
  }

  internal bool OpenCodeplug(string fileName, ref string errorMessage, bool isForExport = false)
  {
    string empty = string.Empty;
    bool flag = this.OpenCodeplug(fileName, (APXRadio) null, (APXTemplate) null, ref empty, true, isForExport);
    errorMessage = empty;
    return flag;
  }

  private bool OpenCodeplug(
    string sFileName,
    APXRadio d,
    APXTemplate t,
    ref string errorMsg,
    bool isNonGuiOpen = false,
    bool isForExport = false)
  {
    this.AllowDrop = false;
    this.DeviceFromServer = d;
    this.TemplateFromServer = t;
    bool flag1 = false;
    System.Windows.Input.Cursor overrideCursor = Mouse.OverrideCursor;
    GC.Collect();
    GC.WaitForPendingFinalizers();
    GC.Collect();
    string initialDirectory = AcpFileDialog.InitialDirectory;
    try
    {
      WindowMain mainWindow = (WindowMain) System.Windows.Application.Current.MainWindow;
      AcpOpenFileDialog acpOpenFileDialog = new AcpOpenFileDialog();
      acpOpenFileDialog.Filter = AppResources.Motorola_Codeplug_Filter;
      acpOpenFileDialog.MultiSelect = false;
      bool flag2 = true;
      AcpFileHeader fileHeader;
      if (string.IsNullOrEmpty(sFileName))
      {
        fileHeader = new AcpFileHeader();
        AcpFileDialog.InitialDirectory = ((App) System.Windows.Application.Current).TheDocument.docFilePath != null || !(this.lastOpenCodePlugPath != string.Empty) ? ((App) System.Windows.Application.Current).TheDocument.docFilePath : this.lastOpenCodePlugPath;
        bool? nullable = acpOpenFileDialog.ShowDialog(fileHeader);
        if ((!nullable.GetValueOrDefault() ? 0 : (nullable.HasValue ? 1 : 0)) != 0)
        {
          sFileName = acpOpenFileDialog.FileName;
          this.cpgFileName = sFileName;
          this.lastOpenCodePlugPath = Path.GetDirectoryName(acpOpenFileDialog.FileName);
          if ((int) this.lastOpenCodePlugPath[this.lastOpenCodePlugPath.Length - 1] != (int) Path.DirectorySeparatorChar)
            this.lastOpenCodePlugPath += (string) (object) Path.DirectorySeparatorChar;
          if (mainWindow.CpgOpenFlag)
            throw CommonExceptionHelper.CreateCommonException(CommonErrorCode.RMC_OpenCodeplug_Fail_HasOpened, Motorola.CommonCPS.ResourceRepository.Resources.RMC_OpenCodeplug_Fail_HasOpened);
        }
        else
          flag2 = false;
      }
      else
      {
        try
        {
          fileHeader = new AcpFileHandler().ReadHeader(sFileName);
          this.cpgFileName = sFileName;
        }
        catch (Exception ex)
        {
          fileHeader = new AcpFileHeader();
        }
      }
      if (flag2)
      {
        Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
        if (sFileName.EndsWith(".mc"))
        {
          AppInfoManager.AppVersion = this.cpsVersion;
          flag1 = ((App) System.Windows.Application.Current).TheDocument.FileOpen(sFileName);
          if (flag1)
            this.UclTemplateNodeInit();
          else
            AppInfoManager.InvalidFieldsReport.Clear();
        }
        else if (sFileName.EndsWith(".xpba"))
        {
          this.InitDocument();
          ((App) System.Windows.Application.Current).TheDocument.FileNew();
          UndoManager.StopUndoRedo();
          UndoManager.Reset();
          ConstraintManager.Suspend();
          flag1 = Cruncher.Instance.UnpackXPBA(sFileName);
          if (flag1)
          {
            this.ResolveUCLReferenceAfterUnpack();
            this.ResolvedMFKTimerUnpack();
            ((App) System.Windows.Application.Current).TheDocument.docFileName = Path.GetFileName(sFileName);
            ((App) System.Windows.Application.Current).TheDocument.docFilePath = Path.GetFullPath(sFileName);
          }
        }
        Mouse.OverrideCursor = overrideCursor;
        if (flag1)
        {
          if (this.authenticateCpgForRWPassword(((App) System.Windows.Application.Current).TheDocument, (string) null, isNonGuiOpen, isForExport))
          {
            ASKConstraints.Initialize();
            if (!isNonGuiOpen)
            {
              UndoManager.Reset();
              AppInfoManager.ClearNavigationHistory = true;
              Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
              mainWindow.CpgOpenFlag = true;
              UtilityMack.bOpenFromRMC = this.deviceFromServer != null || this.templateFromServer != null;
              PageNavPaneButtons content = (PageNavPaneButtons) mainWindow.FrameLeft.Content;
              content.ButtonCpgNav.IsSelected = true;
              content.FrameCodeplug.Navigate(new Uri("PageTreeView.xaml", UriKind.RelativeOrAbsolute));
              mainWindow.FrameCenterTop.Navigate(new Uri(FeatureManager.GetFeature(2049).UIPagePath, UriKind.RelativeOrAbsolute));
              AppInfoManager.AppMode = ApplicationMode.CodeplugConfigurationMode;
              if (AppInfoManager.AppView == DifferentiatedUserViewType.Custom)
              {
                string customVwPath = this.customVwPath;
                try
                {
                  if (!string.IsNullOrEmpty(customVwPath) && File.Exists(customVwPath))
                    ((App) System.Windows.Application.Current).TheDocument.ImportFromXml(customVwPath, XmlFileType.CustomView);
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
            DateTime now = DateTime.Now;
            now = DateTime.Now;
            this.objModelTiering = new ModelTiering(this.MyModelNumber, ModelTiering.ActionTypes.OPEN, ModelTiering.TargetTypes.ALL);
            this.objModelTiering.UpdateUtilityMackModelType();
            if (!isNonGuiOpen)
            {
              this.IsPortableModel = UtilityMack.IsPortablePro;
              this.IsMobileModel = UtilityMack.IsMobilePro;
            }
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
            this.SetDVRSHoptionEnabledField();
            this.SetDVRSHwEnabledField();
            this.IsCpgConvOnly = false;
            if (!isNonGuiOpen)
            {
              PageStatusBar content = (PageStatusBar) mainWindow.FrameStatusBar.Content;
              content.RadioModel = fileHeader.ModelNumber;
              content.SerialNum = fileHeader.SerialNumber;
              content.Status = AppResources.READY_ID;
            }
            foreach (IAcpConstraints feature in FeatureManager.Features)
              feature.CalculateVisibility(true);
            this.IsMobileModelAndSupportedO9 = false;
            this.IsMobileModelAndSupportedO3 = false;
            this.IsMobileModelAndSupportedO5 = false;
            this.IsMobileModelAndSupportedO7 = false;
            this.IsMobileModelAndSupportedO2 = false;
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
            }
            bool flag3 = this.O9TableInit();
            this.DEKVipTableInit();
            this.PresetZoneChannelTableInit();
            this.KeypadRecsetAndTableInit();
            this.O2MFKTableInit();
            this.O7MFKTableInit();
            this.O2NavigationControlsTableInit();
            this.O7NavigationControlsTableInit();
            this.O3NavigationControlsTableInit();
            this.O5NavigationControlsTableInit();
            this.O9NavigationControlsTableInit();
            this.KMANavigationControlsTableInit();
            this.SmartKeyFobTableInit();
            this.SideArrowTableInit();
            this.SiteSelectableAlertTableInit();
            this.AddQC2DefaultRecord();
            ((App) System.Windows.Application.Current).TheDocument.Initialized(false);
            ConstraintManager.Suspend();
            this.updateUnpackedFields(false, (RadioParams) null);
            if (flag3)
              this.AddO9PhephedRecord();
            this.SyncO9PASirenButtons();
            this.O9DirectionalButtonsFixup();
            this.UpdateAuxControlTable();
            ConstraintManager.Resume();
            this.RefreshScanlistMap();
            this.DataProfileTrunkingGroupIDFixup();
            if (this.deviceFromServer == null && this.templateFromServer == null && !isNonGuiOpen && !(bool) System.Windows.Application.Current.Properties[(object) "CommandLineCPS"])
              MruFiles.UpdateMRU(sFileName);
            if (this.deviceFromServer != null)
              this.UpdateFieldsWithServerValues(this.deviceFromServer);
          }
          else
          {
            AppInfoManager.StatusMsgReport.Clear();
            AppInfoManager.InvalidFieldsReport.Clear();
            errorMsg = AppResources.Incorrect_Password;
            flag1 = false;
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
            ((PageStatusBar) mainWindow.FrameStatusBar.Content).Status = AppResources.Open_Failed;
          }
          errorMsg = message;
        }
      }
    }
    catch (Exception ex)
    {
      flag1 = false;
      errorMsg = ex.Message;
      if (!isNonGuiOpen)
        AppInfoManager.StatusMsgReport.PostMessage(StatusMsgType.Error, ex.Message);
    }
    finally
    {
      Mouse.OverrideCursor = overrideCursor;
      if (initialDirectory != AcpFileDialog.InitialDirectory)
        AcpFileDialog.InitialDirectory = initialDirectory;
      UndoManager.Reset();
    }
    this.WindowMain_AllowDrop((object) null, (System.Windows.Input.MouseEventArgs) null);
    return flag1;
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
    if (apxCodeplug.LastProgrammedDate.HasValue)
    {
      AcpFieldX<long, string> dateDbValueA8411 = radioInformation.Tracking.RadInfoLabtoolLastProgrammedDateDBValue_A8411;
      DateTime universalTime = apxCodeplug.LastProgrammedDate.Value;
      universalTime = universalTime.ToUniversalTime();
      long ticks = universalTime.Ticks;
      dateDbValueA8411.Value = ticks;
    }
    radioWide.Bluetooth.RadWideBluetoothFriendlyName_A41181.Value = apxCodeplug.BluetoothFriendlyName != null ? apxCodeplug.BluetoothFriendlyName : string.Empty;
    AcpField<bool> advancedExternalMicOnly = radioWide.Depot.AdvancedExternalMicOnly;
    bool? nullable1 = apxCodeplug.DisableWriteProtect;
    int num1 = !nullable1.GetValueOrDefault() ? 0 : (nullable1.HasValue ? 1 : 0);
    advancedExternalMicOnly.SetValue(num1 != 0);
    nullable1 = apxCodeplug.AskRequired;
    if (nullable1.HasValue)
    {
      AcpField<bool> askRequiredA37152 = radioWide.General.RadWideGeneralASKRequired_A37152;
      nullable1 = apxCodeplug.AskRequired;
      int num2 = nullable1.Value ? 1 : 0;
      askRequiredA37152.Value = num2 != 0;
    }
    int? nullable2;
    if (apxCodeplug.OwnerAdvKeyType.HasValue)
    {
      AcpListField advancedKeyTypeA38663 = radioWide.General.RadWideGeneralOwnerAdvancedKeyType_A38663;
      nullable2 = apxCodeplug.OwnerAdvKeyType;
      int num3 = nullable2.Value;
      advancedKeyTypeA38663.Value = num3;
    }
    nullable2 = apxCodeplug.HomeSystemId;
    if (nullable2.HasValue)
    {
      AcpSimpleRangeField ownerSystemIdA37153 = radioWide.General.RadWideGeneralOwnerSystemID_A37153;
      nullable2 = apxCodeplug.HomeSystemId;
      int num4 = nullable2.Value;
      ownerSystemIdA37153.Value = num4;
    }
    nullable2 = apxCodeplug.OwnerWacnId;
    if (nullable2.HasValue)
    {
      AcpSimpleRangeField ownerWacnidA38656 = radioWide.General.RadWideGeneralOwnerWACNID_A38656;
      nullable2 = apxCodeplug.OwnerWacnId;
      int num5 = nullable2.Value;
      ownerWacnidA38656.Value = num5;
    }
    nullable1 = apxCodeplug.RadioInhibitedTrunking;
    if (nullable1.HasValue)
    {
      AcpField<bool> radioInhibitedA19483 = radioWide.Labtool.TrunkingRadioInhibited_A19483;
      nullable1 = apxCodeplug.RadioInhibitedTrunking;
      int num6 = nullable1.Value ? 1 : 0;
      radioInhibitedA19483.Value = num6 != 0;
    }
    if (!string.IsNullOrEmpty(apxCodeplug.UserPIN))
      radioWide.UserInformationAndPasswords.RadWideUserInformationandPINPassword_41303.Value = apxCodeplug.UserPIN;
    radioWide.UserInformationAndPasswords.RadWideUserInformationandUserLoginUnitID_41306.Value = apxCodeplug.UserLoginUnitID != null ? apxCodeplug.UserLoginUnitID : string.Empty;
    radioWide.UserInformationAndPasswords.RadWideUserInformationandPasswordsRadioAlias_A8829.Value = apxCodeplug.RadioAlias != null ? apxCodeplug.RadioAlias : string.Empty;
    radioWide.UserInformationAndPasswords.RadWideUserInformationandPasswordsSoftIDUsername_A9169.Value = apxCodeplug.UserName != null ? apxCodeplug.UserName : string.Empty;
    nullable2 = apxCodeplug.OtarID;
    int num7;
    if (nullable2.HasValue)
    {
      nullable2 = apxCodeplug.OtarID;
      num7 = string.IsNullOrEmpty(nullable2.ToString()) ? 1 : 0;
    }
    else
      num7 = 1;
    if (num7 == 0)
    {
      AcpSimpleRangeField astrootarRadioIdA8284 = secureWide.ASTROOTAR.SecWideASTROOTARIndividualASTROOTARRadioID_A8284;
      nullable2 = apxCodeplug.OtarID;
      int num8 = nullable2.Value;
      astrootarRadioIdA8284.Value = num8;
    }
    AcpField<bool> astrootarastrootarEnableA7496 = secureWide.ASTROOTAR.SecWideASTROOTARASTROOTAREnable_A7496;
    nullable1 = apxCodeplug.AstroOtarEnable;
    int num9 = nullable1.Value ? 1 : 0;
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
          int num10;
          if (apxRadioSystem.SystemName == conventionalSystem.General.CnvSysGeneralKeyofConventionalSystem_A20482.Value)
          {
            systemType = apxRadioSystem.SystemType;
            num10 = (systemType.GetValueOrDefault() != AstroSystemType.CONVENTIONAL ? 0 : (systemType.HasValue ? 1 : 0)) == 0 ? 1 : 0;
          }
          else
            num10 = 1;
          if (num10 == 0)
          {
            AstroSystemSubType? systemSubType = apxRadioSystem.SystemSubType;
            int num11;
            if ((systemSubType.GetValueOrDefault() != AstroSystemSubType.ASTRO ? 0 : (systemSubType.HasValue ? 1 : 0)) == 0)
            {
              systemSubType = apxRadioSystem.SystemSubType;
              num11 = (systemSubType.GetValueOrDefault() != AstroSystemSubType.DVRS ? 0 : (systemSubType.HasValue ? 1 : 0)) == 0 ? 1 : 0;
            }
            else
              num11 = 0;
            if (num11 == 0)
            {
              AcpSimpleRangeField individualIdA8287 = conventionalSystem.General.CnvSysGeneralIndividualID_A8287;
              nullable2 = apxRadioSystem.RadioId;
              int num12 = nullable2.Value;
              individualIdA8287.Value = num12;
              break;
            }
            systemSubType = apxRadioSystem.SystemSubType;
            if ((systemSubType.GetValueOrDefault() != AstroSystemSubType.MDC ? 0 : (systemSubType.HasValue ? 1 : 0)) != 0)
            {
              AcpRangeField<int, string> mdcPrimaryIdA8744 = conventionalSystem.General.CnvSysGeneralMDCPrimaryID_A8744;
              nullable2 = apxRadioSystem.RadioId;
              int num13 = nullable2.Value;
              mdcPrimaryIdA8744.Value = num13;
              break;
            }
            break;
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
        int num14;
        if (apxRadioSystem.SystemName == trunkingSystem.General.TrkSysGeneralKeyofTrunkingSystem_A12658.Value)
        {
          systemType = apxRadioSystem.SystemType;
          num14 = (systemType.GetValueOrDefault() != AstroSystemType.TRUNCKING ? 0 : (systemType.HasValue ? 1 : 0)) == 0 ? 1 : 0;
        }
        else
          num14 = 1;
        if (num14 == 0)
        {
          AcpListField coverageTypeA7782 = trunkingSystem.General.TrkSysGeneralCoverageType_A7782;
          nullable2 = apxRadioSystem.CoverageType;
          int num15 = nullable2.Value;
          coverageTypeA7782.Value = num15;
          AcpSimpleRangeField generalHomeWacnidA8205 = trunkingSystem.General.TrkSysGeneralHomeWACNID_A8205;
          nullable2 = apxRadioSystem.WacnId;
          int num16 = nullable2.Value;
          generalHomeWacnidA8205.Value = num16;
          if (isForExport)
          {
            AcpSimpleRangeField generalUnitIdA12651 = trunkingSystem.General.TrkSysGeneralUnitID_A12651;
            nullable2 = apxRadioSystem.RadioId;
            int num17 = nullable2.Value;
            generalUnitIdA12651.Value = num17;
          }
          AcpField<bool> shuffledBandPlanA9128 = trunkingSystem.TypeIIChannelSetup.TrkSysTypeIIChannelSetupShuffledBandPlan_A9128;
          nullable1 = apxRadioSystem.ShuffeledBandPlan;
          int num18 = nullable1.Value ? 1 : 0;
          shuffledBandPlanA9128.Value = num18 != 0;
          break;
        }
      }
    }
    RMUtilities.PopulateAstroCpsASKProgrammingHistoryRecset(apxCodeplug.AstroSysKeyLog);
  }

  private void UpdateAuxControlTable()
  {
    foreach (IAcpFeatureNode acpFeatureNode in (Collection<AcpBusinessLayer.FeatureNode>) (((FeatureManager.GetFeature(2033) as RadioErgonomicsWideRecset)[0][10633] as AuxControl).EmbeddedRecset as AuxControlTableInnerRecset))
    {
      AuxControlTableInnerSection tableInnerSection = (acpFeatureNode as AuxControlTableInner).AuxControlTableInnerSection;
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
    if (!string.IsNullOrEmpty(filePath) && this.OpenCodeplug(filePath) && flag)
    {
      content.FrameCodeplug.NavigationService.Refresh();
      if (mainWindow.FrameCenterTop.Content is PageRadioInformation)
        mainWindow.FrameCenterTop.NavigationService.Refresh();
    }
  }

  internal bool SaveCodeplug() => this.SaveCodeplug(false);

  private bool SaveCodeplug(bool isServerArchive)
  {
    bool flag = true;
    if (this.cpsVersion.Length != 0 && this.cpsVersion.Substring(0, 1) != "R")
    {
      string versionA7683UiValue = (FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation).General.RadInfoGeneralCodeplugVersion_A7683_UIValue;
      if (versionA7683UiValue.Length != 0 && versionA7683UiValue.Substring(0, 1) == "R" && !(bool) System.Windows.Application.Current.Properties[(object) "CommandLineCPS"])
      {
        if (!isServerArchive)
          flag = MyMessageBox.Show(AppResources.Warning_you_are_about_to_save_a_Release, AppResources.Saving_Codeplug_, MessageBoxButton.YesNo, MessageBoxImage.Exclamation, MessageBoxResult.Yes) == MessageBoxResult.Yes;
      }
      else if (versionA7683UiValue.Length == 0)
      {
        AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, AppResources.Unable_to_save_Codeplug_Invalid_or_empty_Codeplug_version);
        flag = false;
      }
    }
    else if (this.cpsVersion.Length == 0)
      AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Info, AppResources.CPS_version_is_not_current);
    return flag;
  }

  internal void OnAppMenuSaveAs(object sender, RoutedEventArgs e)
  {
    Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation radioInformation = (Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation) null;
    this.bSaveCpgSuccessful = false;
    string docFilePath = ((App) System.Windows.Application.Current).TheDocument.docFilePath;
    string str = "";
    this.dvrsMsuDataSync = (DvrsMsuDataSync) null;
    try
    {
      string statusMsg = (string) null;
      if (!RadioAccessValidator.IsCpgOwnerSystemIDValid(out statusMsg))
      {
        AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, statusMsg);
      }
      else
      {
        AcpUI.Common.Utility.SaveFieldWithFocus();
        if (this.CanSaveCpgFlag)
        {
          if (this.SaveCodeplug())
          {
            bool flag = UndoManager.StopUndoRedo();
            AcpSaveFileDialog acpSaveFileDialog = new AcpSaveFileDialog();
            acpSaveFileDialog.Filter = AppResources.Motorola_Codeplug_Filter;
            acpSaveFileDialog.FileName = this.cpgFileName;
            AcpFileHeader header = WindowMain.GetHeader();
            bool? nullable = acpSaveFileDialog.ShowDialog(header);
            if ((!nullable.GetValueOrDefault() ? 0 : (nullable.HasValue ? 1 : 0)) != 0)
            {
              string fileName = acpSaveFileDialog.FileName;
              if (fileName != null)
              {
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
                if (fileName.EndsWith(".mc"))
                {
                  radioInformation.General.RadInfoGeneralCodeplugVersion_A7683.SetValue(this.cpsVersion);
                  radioInformation.Labtool.RadInfoLabtoolSecurePartitionVersionNumber_A9076.SetValue(this.cpsVersion);
                  header.VersionNumber = this.cpsVersion;
                  this.bSaveCpgSuccessful = ((App) System.Windows.Application.Current).TheDocument.FileSaveAs(fileName, header);
                  this.cpgFileName = fileName;
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
                    ((App) System.Windows.Application.Current).TheDocument.FileSaveAs(fileName, header);
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
            if (flag)
              UndoManager.StartUndoRedo();
          }
        }
        else
          AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, AppResources.Unable_to_save_Codeplug_Permission_denied);
      }
    }
    catch (Exception ex)
    {
      if (str != "")
        radioInformation.General.RadInfoGeneralCodeplugVersion_A7683_UIValue = str;
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
      if (sFileName != null)
      {
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
        if (sFileName.EndsWith(".mc"))
        {
          radioInformation.General.RadInfoGeneralCodeplugVersion_A7683.SetValue(this.cpsVersion);
          radioInformation.Labtool.RadInfoLabtoolSecurePartitionVersionNumber_A9076.SetValue(this.cpsVersion);
          header.VersionNumber = this.cpsVersion;
          ((App) System.Windows.Application.Current).TheDocument.FileSaveAs(sFileName, header);
        }
      }
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
      if (sFileName != null)
      {
        radioInformation = FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation;
        str = radioInformation.General.RadInfoGeneralCodeplugVersion_A7683_UIValue;
        if (sFileName.EndsWith(".xpba"))
        {
          radioInformation.General.RadInfoGeneralCodeplugVersion_A7683.SetValue(this.cpsVersion);
          radioInformation.Labtool.RadInfoLabtoolSecurePartitionVersionNumber_A9076.SetValue(this.cpsVersion);
          this.bSaveCpgSuccessful = Cruncher.Instance.PackXPBA(sFileName, radioInformation.General.RadInfoGeneralModelNumber_A8539_UIValue);
        }
      }
    }
    catch (Exception ex)
    {
      if (str != "")
        radioInformation.General.RadInfoGeneralCodeplugVersion_A7683_UIValue = str;
      AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, ex.Message);
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
      if (sFileName != null)
      {
        radioInformation = FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation;
        str = radioInformation.General.RadInfoGeneralCodeplugVersion_A7683_UIValue;
        if (sFileName.EndsWith(".mc"))
        {
          radioInformation.General.RadInfoGeneralCodeplugVersion_A7683.SetValue(this.cpsVersion);
          radioInformation.Labtool.RadInfoLabtoolSecurePartitionVersionNumber_A9076.SetValue(this.cpsVersion);
          ((App) System.Windows.Application.Current).TheDocument.FileSaveAs(sFileName, header);
        }
        MruFiles.UpdateMRU(sFileName);
      }
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
    string str1 = "";
    Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation radioInformation = (Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation) null;
    this.dvrsMsuDataSync = (DvrsMsuDataSync) null;
    try
    {
      string statusMsg = (string) null;
      if (!RadioAccessValidator.IsCpgOwnerSystemIDValid(out statusMsg))
      {
        AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, statusMsg);
      }
      else
      {
        AcpUI.Common.Utility.SaveFieldWithFocus();
        if (this.CanSaveCpgFlag)
        {
          string docFileName = ((App) System.Windows.Application.Current).TheDocument.docFileName;
          if (string.IsNullOrEmpty(docFileName))
            this.OnAppMenuSaveAs(sender, e);
          else if ((this.deviceFromServer != null || this.templateFromServer != null) && this.PromptQuitOnInvalids() && !(sender is RMCWnd))
          {
            int num1 = (int) System.Windows.MessageBox.Show(AppResources.The_codeplug_contains_invalid_fields_Please_correct_them_and_try_again, AppResources.Invalid_Fields_Error, MessageBoxButton.OK, MessageBoxImage.Exclamation);
          }
          else
          {
            APXCodeplug cp = (APXCodeplug) null;
            bool flag1 = false;
            if (!(sender is RMCWnd))
            {
              if (this.deviceFromServer != null)
              {
                if (this.deviceFromServer.WorkingCodeplug != null)
                  cp = this.deviceFromServer.WorkingCodeplug as APXCodeplug;
                CommonUtility.PopulatecpAndDeviceColumnsFromDatabaseLayer(cp, (Radio) this.deviceFromServer, PopulateOpeartion.Save);
                flag1 = true;
              }
              else if (this.templateFromServer != null)
              {
                CommonUtility.PopulateTemplateColumnsFromDatabaseLayer(this.templateFromServer);
                flag1 = true;
              }
            }
            if (this.deviceFromServer == null && this.templateFromServer == null || (this.deviceFromServer != null || this.templateFromServer != null) && flag1 || sender is RMCWnd)
            {
              if ((this.deviceFromServer != null || this.templateFromServer != null) && !(sender is RMCWnd))
              {
                APXTemplate apxTemplate = new APXTemplate();
                APXTemplate template = this.deviceFromServer == null ? this.templateFromServer : this.deviceFromServer.WorkingCodeplug.Template as APXTemplate;
                System.Collections.Generic.List<ASTROVoiceAnnouncement> templateVoiceFiles = new System.Collections.Generic.List<ASTROVoiceAnnouncement>();
                foreach (ASTROVoiceAnnouncement voiceAnnouncement in template.ASTROVoiceAnnouncements)
                  templateVoiceFiles.Add(voiceAnnouncement);
                VAHelper.UpdateVAContent(templateVoiceFiles, template);
                LanguagePackHelper.UpdateLanguageRefence(template);
                if ((this.deviceFromServer != null || this.templateFromServer != null) && this.PromptQuitOnInvalids() && !(sender is RMCWnd))
                {
                  int num2 = (int) System.Windows.MessageBox.Show(AppResources.The_codeplug_contains_invalid_fields_Please_correct_them_and_try_again, AppResources.Invalid_Fields_Error, MessageBoxButton.OK, MessageBoxImage.Exclamation);
                  return;
                }
              }
              if (this.SaveCodeplug(sender is RMCWnd))
              {
                bool flag2 = UndoManager.StopUndoRedo();
                string docFilePath = ((App) System.Windows.Application.Current).TheDocument.docFilePath;
                AcpFileHeader header = WindowMain.GetHeader();
                if (docFilePath != null)
                {
                  radioInformation = FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation;
                  str1 = radioInformation.General.RadInfoGeneralCodeplugVersion_A7683_UIValue;
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
                  if (docFilePath.EndsWith(".mc"))
                  {
                    radioInformation.General.RadInfoGeneralCodeplugVersion_A7683.SetValue(this.cpsVersion);
                    radioInformation.Labtool.RadInfoLabtoolSecurePartitionVersionNumber_A9076.SetValue(this.cpsVersion);
                    header.VersionNumber = this.cpsVersion;
                    this.bSaveCpgSuccessful = ((App) System.Windows.Application.Current).TheDocument.FileSaveAs(docFilePath, header);
                    if (this.bSaveCpgSuccessful)
                    {
                      if (sender is RMCWnd && this.deviceFromServer == null && this.templateFromServer == null)
                      {
                        bool bOpenFromRmc = UtilityMack.bOpenFromRMC;
                        UtilityMack.bOpenFromRMC = false;
                        this.CalculateValidityforNonEditableFieldsinRMC();
                        UtilityMack.bOpenFromRMC = bOpenFromRmc;
                        ((App) System.Windows.Application.Current).TheDocument.FileSaveAs(docFilePath, header);
                      }
                      else if ((this.deviceFromServer != null || this.templateFromServer != null) && !(sender is RMCWnd))
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
                            string str2 = "Server Archive - ";
                            string str3 = this.deviceFromServer == null ? str2 + $"{this.templateFromServer.ModelNumber}.{Guid.NewGuid()}" : str2 + $"{this.deviceFromServer.SerialNumber}.{Guid.NewGuid()}";
                            string str4 = $"{Path.GetTempPath()}{str3}.mc";
                            if (File.Exists(docFilePath))
                            {
                              File.Delete(docFilePath);
                              ((App) System.Windows.Application.Current).TheDocument.FileSaveAs(str4, header);
                            }
                            this.SetTitleBar(new FileInfo(str4).Name, (string) null);
                            ((App) System.Windows.Application.Current).TheDocument.docFilePath = str4;
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
                  else if (docFileName.EndsWith(".xpba"))
                  {
                    radioInformation.General.RadInfoGeneralCodeplugVersion_A7683.SetValue(this.cpsVersion);
                    radioInformation.Labtool.RadInfoLabtoolSecurePartitionVersionNumber_A9076.SetValue(this.cpsVersion);
                    this.bSaveCpgSuccessful = Cruncher.Instance.PackXPBA(docFilePath, radioInformation.General.RadInfoGeneralModelNumber_A8539_UIValue);
                  }
                  if (this.bSaveCpgSuccessful && !(bool) System.Windows.Application.Current.Properties[(object) "CommandLineCPS"])
                  {
                    UndoManager.Reset();
                    if (this.dvrsMsuDataSync != null)
                      this.dvrsMsuDataSync.ExportToXmlDoc($"{this.defaultDVRSFileLocation}\\{this.dvrsMsuDataSync.BuildFileName()}");
                  }
                }
                if (flag2)
                  UndoManager.StartUndoRedo();
              }
            }
          }
        }
        else
          AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, AppResources.Unable_to_save_Codeplug_Permission_denied);
      }
    }
    catch (Exception ex)
    {
      if (str1 != "")
        radioInformation.General.RadInfoGeneralCodeplugVersion_A7683_UIValue = str1;
      if (ex is CommonException commonException)
      {
        if (commonException.ErrorCode == CommonExceptionHelper.DirectMsgCode)
          AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, commonException.Message);
        else
          AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, Motorola.CommonCPS.ResourceRepository.ResourceHelper.GetCommonErrorMessageByID(commonException.ErrorCode.ToString()));
      }
      else
        AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, ex.Message);
      UndoManager.StartUndoRedo();
    }
  }

  private static AcpFileHeader GetHeader()
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
        bool? nullable = acpOpenFileDialog.ShowDialog();
        if ((!nullable.GetValueOrDefault() ? 0 : (nullable.HasValue ? 1 : 0)) == 0)
          return;
        string fileName = acpOpenFileDialog.FileName;
        if (fileName != null)
        {
          if (fileName.EndsWith(".xml"))
          {
            AppInfoManager.InvalidFieldsReport.SuppressReportDisplay = true;
            AcpUIDialogWindow<string> acpUiDialogWindow = (AcpUIDialogWindow<string>) null;
            try
            {
              PageFunctionImportExport page = new PageFunctionImportExport(((App) System.Windows.Application.Current).TheDocument.GetXmlDocument(fileName));
              ComponentResourceKey resourceKey = new ComponentResourceKey(this.FrameCenterTop.GetType(), (object) AcpColorKeys.FrameContentAreaPopupDialogueBackground);
              page.Background = (Brush) this.TryFindResource((object) resourceKey);
              acpUiDialogWindow = new AcpUIDialogWindow<string>((PageFunction<string>) page, (string) null);
              acpUiDialogWindow.Width = 500.0;
              acpUiDialogWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
              acpUiDialogWindow.ResizeMode = ResizeMode.NoResize;
              acpUiDialogWindow.Show();
              acpUiDialogWindow.Focus();
              acpUiDialogWindow.Hide();
              acpUiDialogWindow.ShowDialog();
              if (FeatureManager.GetFeature(2033)[0] is Motorola.MackinawCPS.CoreFeatures.RadioErgonomicsWide.RadioErgonomicsWide radioErgonomicsWide)
              {
                radioErgonomicsWide.Advanced.RadErgoWideAdvancedLongKeypressDurationforEmergencyms_A8451.CalculateEditability();
                radioErgonomicsWide.Advanced.RadErgoWideAdvancedShortKeypressDurationforEmergencyms_A9126.CalculateEditability();
              }
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

  internal void OnAppMenuExport(object sender, RoutedEventArgs e)
  {
    AcpUI.Common.Utility.SaveFieldWithFocus();
    PageFunctionImportExport page = new PageFunctionImportExport();
    AcpUIDialogWindow<string> acpUiDialogWindow = new AcpUIDialogWindow<string>((PageFunction<string>) page, (string) null);
    ComponentResourceKey resourceKey = new ComponentResourceKey(this.FrameCenterTop.GetType(), (object) AcpColorKeys.FrameContentAreaPopupDialogueBackground);
    page.Background = (Brush) this.TryFindResource((object) resourceKey);
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
    string docFileName = ((App) System.Windows.Application.Current).TheDocument.docFileName;
    string docFilePath = ((App) System.Windows.Application.Current).TheDocument.docFilePath;
    if (theDocument.IsDirty)
    {
      messageBoxResult = MyMessageBox.Show(AppResources.Save_changes_to_file.AcpStringFormat((object) docFileName), AppResources.APX_DEPOT, MessageBoxButton.YesNoCancel, MessageBoxImage.Exclamation, MessageBoxResult.Yes);
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
    if (FlashDataManager.FlashDoc != null && flag)
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
            if (this.lastOpenCodePlugPath != null && (int) this.lastOpenCodePlugPath[this.lastOpenCodePlugPath.Length - 1] != (int) Path.DirectorySeparatorChar)
              this.lastOpenCodePlugPath += (string) (object) Path.DirectorySeparatorChar;
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
    if (AppInfoManager.AppMode != ApplicationMode.CodeplugConfigurationMode || !this.bUnlimitedKeyLoaded)
      return;
    this.AppMenuWriteProtect.IsEnabled = true;
  }

  private void ClearEventWindows()
  {
    PageStatusBar content = (PageStatusBar) ((WindowMain) System.Windows.Application.Current.MainWindow).FrameStatusBar.Content;
    content.RadioModel = (string) null;
    content.SerialNum = (string) null;
    content.Status = AppResources.READY_ID;
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

  internal void InitDocument()
  {
    AcpDocument theDocument = ((App) System.Windows.Application.Current).TheDocument;
    if (theDocument == null)
      return;
    theDocument.FileClose();
    FeatureManager.BeginAddFeatures();
    WindowMain.AddAllFeatures();
    FeatureManager.EndAddFeatures();
    this.UclTemplateNodeInit();
    theDocument.ModificationLogEnabled = false;
  }

  internal void InitDocument(Document doc)
  {
    if (doc == null)
      return;
    FeatureManager.BeginAddFeatures(doc);
    WindowMain.AddAllFeatures(doc);
    FeatureManager.EndAddFeatures(doc);
    this.UclTemplateNodeInit();
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
  }

  internal void OnQATRedo(object sender, RoutedEventArgs e)
  {
    if (!UndoManager.CanRedo || !AppInfoManager.CurrentModeSupportsUndo || UndoManager.Redo())
      return;
    int num = (int) System.Windows.MessageBox.Show(AppResources.Unexpected_Error_Operation_Cannot_Redone);
  }

  internal void OnRibbonBarWndHideClick(object sender, RoutedEventArgs e)
  {
    AcpCheckBox acpCheckBox = (AcpCheckBox) sender;
    DockWndType dockWindow = this.GetDockWindow(acpCheckBox.Name);
    if (dockWindow == DockWndType.UnKnown)
      return;
    WindowMain mainWindow = (WindowMain) System.Windows.Application.Current.MainWindow;
    bool? isChecked = acpCheckBox.IsChecked;
    if ((isChecked.GetValueOrDefault() ? 0 : (isChecked.HasValue ? 1 : 0)) != 0)
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
    if (isChecked.HasValue)
    {
      AcpIuiPage pageIui = mainWindow.pageIUI;
      int dwType = (int) dockWindow;
      isChecked = acpCheckBox.IsChecked;
      int num = isChecked.Value ? 1 : 0;
      pageIui.SetDockWindowAutoRise((DockWndType) dwType, num != 0);
    }
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
    if (dataContext1 != null && AppInfoManager.InvalidFieldsReport != null && AppInfoManager.InvalidFieldsReport.UiHasFields && dataContext1.RecsetId != 2300)
    {
      foreach (FieldsReportInfo uiField in AppInfoManager.InvalidFieldsReport.UiFields)
      {
        if (uiField.Field != null && uiField.FieldType == FieldInfoType.Field && ((AcpFieldBase) uiField.Field).AllowsRestore())
        {
          this.RibbonBarRtdInvalidsRestoreAll.IsEnabled = true;
          break;
        }
      }
    }
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
  }

  internal bool OnRibbonBarBtnLoadCustView(out string sFileName)
  {
    sFileName = (string) null;
    bool flag = false;
    AcpOpenFileDialog acpOpenFileDialog = new AcpOpenFileDialog();
    acpOpenFileDialog.Filter = AppResources.Custom_Views_Filter;
    acpOpenFileDialog.MultiSelect = false;
    bool? nullable = acpOpenFileDialog.ShowDialog();
    if ((!nullable.GetValueOrDefault() ? 0 : (nullable.HasValue ? 1 : 0)) != 0)
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
      if (!flag)
        ((WindowMain) System.Windows.Application.Current.MainWindow).pageIUI.OpenDockWindow(DockWndType.FindResults);
    }
    else
    {
      int num = (int) System.Windows.MessageBox.Show(AppResources.Codeplug_must_be_opened_in_order_to_perform_search_operation, AppResources.Find_Id, MessageBoxButton.OK, MessageBoxImage.Exclamation);
    }
  }

  internal void OnRibbonBarCompCodeplug(object sender, RoutedEventArgs e)
  {
    string initialDirectory = AcpFileDialog.InitialDirectory;
    try
    {
      if (this.CpgOpenFlag)
      {
        AcpUI.Common.Utility.SaveFieldWithFocus();
        NotifyFieldsReportChangedEventHandler changedEventHandler = new NotifyFieldsReportChangedEventHandler(this.ComparatorFieldsReport_NotifyFieldsReportChangedEvent);
        AppInfoManager.BackgroundDeserializeOpertaion = true;
        if (AppInfoManager.AppMode != ApplicationMode.CodeplugComparisonMode)
        {
          AcpOpenFileDialog acpOpenFileDialog = new AcpOpenFileDialog();
          acpOpenFileDialog.Filter = AppResources.Motorola_Codeplug_All_files;
          acpOpenFileDialog.MultiSelect = false;
          AcpFileHeader fileHeader = new AcpFileHeader();
          AcpFileDialog.InitialDirectory = ((App) System.Windows.Application.Current).TheDocument.docFilePath;
          bool? nullable = acpOpenFileDialog.ShowDialog(fileHeader);
          if ((!nullable.GetValueOrDefault() ? 0 : (nullable.HasValue ? 1 : 0)) != 0)
          {
            string fileName = acpOpenFileDialog.FileName;
            if (fileName != null & fileName.EndsWith(".mc"))
            {
              AppInfoManager.ComparatorDocument = (Document) new AcpDocument(true, DocumentType.Comparator);
              AppInfoManager.ComparatorFieldsReport.NotifyFieldsReportChangedEvent += changedEventHandler;
              try
              {
                AppInfoManager.ComparatorFieldsReport.Clear();
                if (((AcpDocument) AppInfoManager.ComparatorDocument).FileOpen(fileName))
                {
                  if (this.authenticateCpgForRWPassword((AcpDocument) AppInfoManager.ComparatorDocument, (string) null, false))
                  {
                    AppInfoManager.AppMode = ApplicationMode.CodeplugComparisonMode;
                    this.CurrentAppMode = ApplicationMode.CodeplugComparisonMode;
                    string strModelNumber = string.Empty;
                    try
                    {
                      strModelNumber = (AppInfoManager.ComparatorDocument.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation).General.RadInfoGeneralModelNumber_A8539Value;
                    }
                    catch (Exception ex)
                    {
                    }
                    ModelTiering modelTiering = new ModelTiering(strModelNumber, ModelTiering.ActionTypes.OPEN, ModelTiering.TargetTypes.ALL, true);
                    ConstraintManager.Suspend();
                    modelTiering.ApplyTieringForComparedMC();
                    ConstraintManager.Resume();
                    bool isCompareCpgPortable = UtilityMack.IsPortableOnly();
                    new ModelTiering(this.MyModelNumber, "").UpdateUtilityMackModelType();
                    this.InitFCCNarrowBandSplit();
                    ((IAcpPageFeature) ((WindowMain) System.Windows.Application.Current.MainWindow).FrameCenterTop.Content)?.RefreshComparatorOdp();
                    this.UclTemplateNodeInit();
                    this.InitTrkPerAnnGroup();
                    this.DEKVipTableInit();
                    this.SyncO9PASirenButtons(isCompareCpgPortable);
                    this.RefreshForCnvPer();
                    this.RefreshForTrkSys();
                    this.RefreshDynChannelName();
                    this.RefreshScanlistMap();
                    this.TriggerMuteToneRefresh();
                    this.RefreshBroadbandFields();
                    this.RefreshUserSelectablePL();
                    this.ChangeLegacyDINCFieldsFromLowerToUpperCase();
                    this.modifySoftIDUserNameForCompare();
                    ComparatorManager.CompareDocuments(FeatureManager.ActiveDocument, AppInfoManager.ComparatorDocument);
                    if (this.ribbonBarShowRtdButtons.IsEnabled)
                    {
                      this.ribbonBarShowRtdButtons.IsEnabled = false;
                      this.ribbonBarShowRtdButtonsIsEnabled = this.ribbonBarShowRtdButtons.IsEnabled;
                    }
                  }
                  else
                  {
                    AppInfoManager.AppMode = ApplicationMode.CodeplugConfigurationMode;
                    this.CurrentAppMode = ApplicationMode.CodeplugConfigurationMode;
                    AppInfoManager.ComparatorFieldsReport.Clear();
                  }
                }
                else
                {
                  AppInfoManager.AppMode = ApplicationMode.CodeplugConfigurationMode;
                  this.CurrentAppMode = ApplicationMode.CodeplugConfigurationMode;
                  AppInfoManager.ComparatorDocument.Clear();
                  if (AppInfoManager.NonEngOldCodeplug)
                    AppInfoManager.ComparatorFieldsReport.RegisterFieldInReport((IAcpField) null, AppResources.File_colon_Cannot_Open_Old_CP_NonEng.AcpStringFormat((object) fileName), false);
                  else
                    AppInfoManager.ComparatorFieldsReport.RegisterFieldInReport((IAcpField) null, AppResources.File_colon_could_not_be_opened.AcpStringFormat((object) fileName), false);
                  AppInfoManager.ComparatorFieldsReport.FieldsReportChanged = true;
                }
              }
              catch
              {
                AppInfoManager.AppMode = ApplicationMode.CodeplugConfigurationMode;
                this.CurrentAppMode = ApplicationMode.CodeplugConfigurationMode;
                if (!UndoManager.MarkForUndo)
                  UndoManager.StartUndoRedo();
                if (AppInfoManager.NonEngOldCodeplug)
                  AppInfoManager.ComparatorFieldsReport.RegisterFieldInReport((IAcpField) null, AppResources.File_colon_Cannot_Open_Old_CP_NonEng.AcpStringFormat((object) fileName), false);
                else
                  AppInfoManager.ComparatorFieldsReport.RegisterFieldInReport((IAcpField) null, AppResources.File_colon_could_not_be_opened.AcpStringFormat((object) fileName), false);
                AppInfoManager.ComparatorFieldsReport.FieldsReportChanged = true;
              }
            }
            else
            {
              AppInfoManager.ComparatorFieldsReport.RegisterFieldInReport((IAcpField) null, AppResources.File_colon_could_not_be_opened.AcpStringFormat((object) fileName), false);
              AppInfoManager.ComparatorFieldsReport.FieldsReportChanged = true;
            }
          }
        }
        else
        {
          if (AppInfoManager.AppHideMatches)
            this.OnRibbonBarHideMatches((object) this, new RoutedEventArgs());
          ((AcpDocument) AppInfoManager.ComparatorDocument).FileClose();
          AppInfoManager.ComparatorFieldsReport.Clear();
          AppInfoManager.ComparatorFieldsReport.NotifyFieldsReportChangedEvent -= changedEventHandler;
          AppInfoManager.AppMode = ApplicationMode.CodeplugConfigurationMode;
          this.CurrentAppMode = ApplicationMode.CodeplugConfigurationMode;
          this.modifySoftIDUserNameForCompare();
          if (!this.ribbonBarShowRtdButtons.IsEnabled)
          {
            this.ribbonBarShowRtdButtons.IsEnabled = true;
            this.ribbonBarShowRtdButtonsIsEnabled = this.ribbonBarShowRtdButtons.IsEnabled;
          }
          this.pageIUI.RefreshSelectedEventWindow();
        }
        ((IAcpPageFeature) ((WindowMain) System.Windows.Application.Current.MainWindow).FrameCenterTop.Content)?.SetDataContext();
        ComparatorManager.RefreshTree((Page) ((PageNavPaneButtons) ((WindowMain) System.Windows.Application.Current.MainWindow).FrameLeft.Content).GetSelectedItemContent());
        AppInfoManager.BackgroundDeserializeOpertaion = false;
      }
      else
      {
        int num = (int) System.Windows.MessageBox.Show(AppResources.Open_Codeplug_First);
      }
    }
    finally
    {
      if (initialDirectory != AcpFileDialog.InitialDirectory)
        AcpFileDialog.InitialDirectory = initialDirectory;
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
          newValue += (string) (object) ' ';
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
    bool? nullable = acpOpenFileDialog.ShowDialog();
    if ((!nullable.GetValueOrDefault() ? 0 : (nullable.HasValue ? 1 : 0)) == 0)
      return;
    string fileName = acpOpenFileDialog.FileName;
    if (fileName != null)
    {
      if (fileName.EndsWith(".xml"))
      {
        if (!this.DefaultCpgOpenFlag)
        {
          if (AppInfoManager.DefaultDocument == null)
            AppInfoManager.DefaultDocument = (Document) new AcpDocument(true, DocumentType.Default);
          this.InitDocument(AppInfoManager.DefaultDocument);
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
            this.O9TableInit_For_CustomViewInit();
            this.O3TableInit_For_CustomViewInit();
            this.O5TableInit_For_CustomViewInit();
            this.O2TableInit_For_CustomViewInit();
            this.O7TableInit_For_CustomViewInit();
            this.KMATableInit_For_CustomViewInit();
            this.KeypadMicAndAccessoriesTableInit_For_CustomViewInit();
            this.KeypadTableInit_For_CustomViewInit();
            this.DEKTableInit_For_CustomViewInit();
            this.SmartKeyFobsTableInit_For_CustomViewInit();
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
  }

  internal void OnRibbonBarNewCustomView(object sender, RoutedEventArgs e)
  {
    if (!this.DefaultCpgOpenFlag)
    {
      if (AppInfoManager.DefaultDocument == null)
        AppInfoManager.DefaultDocument = (Document) new AcpDocument(true, DocumentType.Default);
      this.InitDocument(AppInfoManager.DefaultDocument);
      ConstraintManager.Suspend();
      this.DefaultCpgOpenFlag = true;
    }
    try
    {
      CustomViewCreationInfo viewCreationInfo = new CustomViewCreationInfo(string.Empty, string.Empty);
      PageFunctionCustomViewWizard page = new PageFunctionCustomViewWizard(viewCreationInfo);
      AcpUIDialogWindow<CustomViewCreationInfo> acpUiDialogWindow = new AcpUIDialogWindow<CustomViewCreationInfo>((PageFunction<CustomViewCreationInfo>) page, viewCreationInfo);
      ComponentResourceKey resourceKey = new ComponentResourceKey(this.FrameCenterTop.GetType(), (object) AcpColorKeys.FrameContentAreaPopupDialogueBackground);
      page.Background = (Brush) this.TryFindResource((object) resourceKey);
      acpUiDialogWindow.Height = 250.0;
      acpUiDialogWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
      acpUiDialogWindow.ResizeMode = ResizeMode.NoResize;
      acpUiDialogWindow.Show();
      acpUiDialogWindow.Focus();
      acpUiDialogWindow.Hide();
      bool? nullable = acpUiDialogWindow.ShowDialog();
      if ((!nullable.GetValueOrDefault() ? 0 : (nullable.HasValue ? 1 : 0)) == 0)
        return;
      CustomViewCreationInfo dialogData = (CustomViewCreationInfo) acpUiDialogWindow.DialogData;
      string customViewFileName = dialogData.CustomViewFileName;
      string viewFileBaseline = dialogData.CustomViewFileBaseline;
      WindowMain mainWindow = (WindowMain) System.Windows.Application.Current.MainWindow;
      ((PageNavPaneButtons) mainWindow.FrameLeft.Content).FrameCustView.Navigate(new Uri("PageTreeView.xaml", UriKind.RelativeOrAbsolute));
      mainWindow.FrameCenterTop.Navigate(new Uri(AppInfoManager.DefaultDocument.GetFeature(2049).UIPagePath, UriKind.RelativeOrAbsolute));
      this.O9TableInit_For_CustomViewInit();
      this.O3TableInit_For_CustomViewInit();
      this.O5TableInit_For_CustomViewInit();
      this.O2TableInit_For_CustomViewInit();
      this.O7TableInit_For_CustomViewInit();
      this.KMATableInit_For_CustomViewInit();
      this.KeypadMicAndAccessoriesTableInit_For_CustomViewInit();
      this.KeypadTableInit_For_CustomViewInit();
      this.DEKTableInit_For_CustomViewInit();
      this.SmartKeyFobsTableInit_For_CustomViewInit();
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
    bool? nullable = acpSaveFileDialog.ShowDialog();
    if ((!nullable.GetValueOrDefault() ? 0 : (nullable.HasValue ? 1 : 0)) == 0)
      return;
    string fileName = acpSaveFileDialog.FileName;
    if (fileName != null)
    {
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
      AcpUI.Help.Utility.DisplayCPSHelp("zzNavigation\\CustomView\\Custom_View_Config_Mode_Navigation.htm");
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
      if (SecurityManager.LoadAllAttachedKeys(false) > 0)
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
    foreach (SystemKeyData loadedAsK in (Collection<SystemKeyData>) SecurityManager.LoadedASKs)
    {
      int num;
      switch (loadedAsK.AccessLevel.GetKeyAccessLevelType())
      {
        case KeyAccessLevelType.UNLM_ACC:
        case KeyAccessLevelType.UNLM_ACC_WITHOUT_WP:
          if (loadedAsK.Type != KeyType.ADVANCED_CONV_SYSTEM_KEY)
          {
            num = loadedAsK.SystemID != 1 ? 0 : (loadedAsK.Type == KeyType.ADVANCED_SYSTEM_KEY ? 1 : 0);
            break;
          }
          goto default;
        default:
          num = 1;
          break;
      }
      if (num == 0)
      {
        this.AppMenuWriteProtect.IsEnabled = true;
        this.bUnlimitedKeyLoaded = true;
        break;
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
    if (fileNames.Length > 0)
    {
      AppInfoManager.InvalidFieldsReport.SuppressReportDisplay = true;
      if (SecurityManager.LoadSelectedSwKeyFiles(fileNames, false) > 0)
        this.pageIUI.OpenDockWindow(DockWndType.SysKeyRpt);
      else
        AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Warning, AppResources.No_System_Key_Was_Loaded);
      AppInfoManager.InvalidFieldsReport.SuppressReportDisplay = false;
    }
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
    AcpUIDialogWindow<string> acpUiDialogWindow = new AcpUIDialogWindow<string>((PageFunction<string>) new WriteProtect(this, (Collection<SystemKeyData>) SecurityManager.LoadedASKs), (string) null);
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
      PageFlashkeyConfiguration flashkeyConfiguration = new PageFlashkeyConfiguration();
      sender1.Content = (object) flashkeyConfiguration;
      sender1.SizeToContent = SizeToContent.Height;
      sender1.Owner = (Window) this;
      sender1.WindowStartupLocation = WindowStartupLocation.CenterOwner;
      sender1.ResizeMode = ResizeMode.NoResize;
      sender1.ShowInTaskbar = false;
      ComponentResourceKey resourceKey = new ComponentResourceKey(this.FrameCenterTop.GetType(), (object) AcpColorKeys.FrameContentAreaBackground);
      sender1.Background = (Brush) this.TryFindResource((object) resourceKey);
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
      PageRadioConfiguration radioConfiguration = new PageRadioConfiguration();
      sender1.Content = (object) radioConfiguration;
      sender1.SizeToContent = SizeToContent.Height;
      sender1.Owner = (Window) this;
      sender1.WindowStartupLocation = WindowStartupLocation.CenterOwner;
      sender1.ResizeMode = ResizeMode.NoResize;
      sender1.ShowInTaskbar = false;
      ComponentResourceKey resourceKey = new ComponentResourceKey(this.FrameCenterTop.GetType(), (object) AcpColorKeys.FrameContentAreaBackground);
      sender1.Background = (Brush) this.TryFindResource((object) resourceKey);
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
    if (((WindowMain) System.Windows.Application.Current.MainWindow).CpgOpenFlag)
    {
      AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, AppResources.The_FLASHport_upgrade);
    }
    else
    {
      AppInfoManager.DragOperation = true;
      Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
      this.InitDocument();
      ((App) System.Windows.Application.Current).TheDocument.FileNew();
      UndoManager.StopUndoRedo();
      UndoManager.Reset();
      ConstraintManager.Suspend();
      Mouse.OverrideCursor = (System.Windows.Input.Cursor) null;
      FlashportDialogBox flashportDialogBox = new FlashportDialogBox();
      flashportDialogBox.FlashportData.UpgradeFile = this.upgradeFile;
      flashportDialogBox.FlashportData.Refresh = bRefresh;
      flashportDialogBox.FlashportData.InitialDirectory = Settings.Default.Refresh_Radio_Default_Folder;
      flashportDialogBox.Owner = (Window) this;
      if (flashportDialogBox.ShowDialog().Value)
        this.upgradeFile = flashportDialogBox.FlashportData.UpgradeFile;
      Settings.Default.Refresh_Radio_Default_Folder = flashportDialogBox.FlashportData.InitialDirectory;
      Settings.Default.Save();
      ((App) System.Windows.Application.Current).TheDocument?.FileClose();
      AppInfoManager.DragOperation = false;
    }
  }

  private void RibbonBarShowFS_Click(object sender, RoutedEventArgs e)
  {
    Window sender1 = new Window();
    PageRadioFeatureSet pageRadioFeatureSet = new PageRadioFeatureSet();
    sender1.Content = (object) pageRadioFeatureSet;
    sender1.ResizeMode = ResizeMode.CanResize;
    sender1.MinHeight = 200.0;
    sender1.MinWidth = 600.0;
    sender1.MaxWidth = 800.0;
    sender1.MaxHeight = (double) Screen.PrimaryScreen.WorkingArea.Height;
    sender1.SizeToContent = SizeToContent.Height;
    sender1.ShowInTaskbar = false;
    sender1.Owner = (Window) this;
    sender1.WindowStartupLocation = WindowStartupLocation.CenterOwner;
    ComponentResourceKey resourceKey = new ComponentResourceKey(this.FrameCenterTop.GetType(), (object) AcpColorKeys.FrameContentAreaBackground);
    sender1.Background = (Brush) this.TryFindResource((object) resourceKey);
    sender1.Title = AppResources.Codeplug_Feature_Set;
    AcpUI.Common.Utility.SetDirection((FrameworkElement) sender1);
    sender1.Show();
    sender1.Focus();
    sender1.Hide();
    sender1.ShowDialog();
  }

  private void OnRibbonBarPassword(object sender, RoutedEventArgs e)
  {
    ReadWritePasswordApp.ReadWritePassword();
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
    acpUiDialogWindow.SizeToContent = SizeToContent.Height;
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
    acpUiDialogWindow.SizeToContent = SizeToContent.Height;
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
      if (this.PromptQuitOnInvalids())
        return;
      this.ReadWriteInProgress = true;
      if (this.CpgOpenFlag)
      {
        this.NATListFixup();
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
        PageCloneExpress pageCloneExpress = new PageCloneExpress();
        sender1.Title = AppResources.Clone_Express;
        sender1.Content = (object) pageCloneExpress;
        sender1.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        ComponentResourceKey resourceKey = new ComponentResourceKey(this.FrameCenterTop.GetType(), (object) AcpColorKeys.FrameContentAreaBackground);
        sender1.Background = (Brush) this.TryFindResource((object) resourceKey);
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
      if (this.PromptQuitOnInvalids())
        return;
      this.ReadWriteInProgress = true;
      string path = "";
      DifferentiatedUserViewType appView = AppInfoManager.AppView;
      switch (AppInfoManager.AppView)
      {
        case DifferentiatedUserViewType.Full:
          this.NATListFixup();
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
          PageCloneWizard pageCloneWizard = new PageCloneWizard();
          sender.Title = AppResources.Clone_Radio;
          sender.Content = (object) pageCloneWizard;
          sender.WindowStartupLocation = WindowStartupLocation.CenterScreen;
          ComponentResourceKey resourceKey = new ComponentResourceKey(this.FrameCenterTop.GetType(), (object) AcpColorKeys.FrameContentAreaBackground);
          sender.Background = (Brush) this.TryFindResource((object) resourceKey);
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
    this.ribbonBarLoadASK.IsEnabled = false;
    this.ribbonBarLoadSWKey.IsEnabled = false;
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
      AcpUI.Help.Utility.DisplayCPSHelp((string) null);
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
      AcpUI.Help.Utility.CloseHelpWindowIfOpen();
      AcpUI.Help.Utility.DisplayCPSHelp("zzTutorials\\zWhatsNewTopics\\WhatsNewNow.htm");
    }
    catch (Exception ex)
    {
    }
  }

  private void OnClickRibbonBarAboutTutorials(object sender, RoutedEventArgs e)
  {
    try
    {
      AcpUI.Help.Utility.CloseHelpWindowIfOpen();
      AcpUI.Help.Utility.DisplayCPSHelp("zzTutorials\\yMenus\\TutorialsMenu.htm");
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
    if (!(FeatureManager.GetFeature(2051) is ZoneChannelAssignmentRecset feature))
      return;
    foreach (IAcpFeatureNode acpFeatureNode in (Collection<AcpBusinessLayer.FeatureNode>) feature)
      (acpFeatureNode as Motorola.MackinawCPS.CoreFeatures.ZoneChannelAssignment.ZoneChannelAssignment).Zone.ZnChanCfgZoneDynamicZoneEnable_A41257.CalculateEditability();
  }

  private void RefreshMPLAfterDnDImport()
  {
    if (AppInfoManager.UndoRedoInProgress)
      return;
    if (!(FeatureManager.GetFeature(2059) is ConventionalPersonalityRecset feature))
      return;
    foreach (IAcpFeatureNode acpFeatureNode in (Collection<AcpBusinessLayer.FeatureNode>) feature)
    {
      Motorola.MackinawCPS.CoreFeatures.ConventionalPersonality.ConventionalPersonality conventionalPersonality = acpFeatureNode as Motorola.MackinawCPS.CoreFeatures.ConventionalPersonality.ConventionalPersonality;
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
      foreach (IAcpFeatureNode acpFeatureNode in (Collection<AcpBusinessLayer.FeatureNode>) feature)
      {
        if ((acpFeatureNode as Motorola.MackinawCPS.CoreFeatures.ZoneChannelAssignment.ZoneChannelAssignment).Zone.Parent is Motorola.MackinawCPS.CoreFeatures.ZoneChannelAssignment.ZoneChannelAssignment parent && parent.Channels.EmbeddedRecset is ChannelAssignmentListInnerRecset embeddedRecset)
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
    SecurityManager.SystemKeyLoadedEvent += new SystemKeyLoadedEventHandler(this.OnSystemKeyLoaded);
    this.progressPage = new ProgressUpdate();
    this.commsLastUserState = (object) null;
    MainUIDispatcher.MainDispatcher = this.Dispatcher;
    this.UpdateRibbon();
    this.WindowMainRibbonControl.IsMinimized = !Settings.Default.Ribbon_Maximized;
  }

  public WindowMain()
  {
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
    switch (this.settingsSavedOnAppExit.Color_Theme)
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
    this.defaultKeyFilesLocation = !string.IsNullOrEmpty(this.settingsSavedOnAppExit.KeyFiles_Default_Folder) ? this.settingsSavedOnAppExit.KeyFiles_Default_Folder : Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Motorola\\SysKeys");
    this.defaultDVRSFileLocation = !string.IsNullOrEmpty(this.settingsSavedOnAppExit.DVRS_Export_Default_Folder) ? this.settingsSavedOnAppExit.DVRS_Export_Default_Folder : Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Motorola\\ApxFamilyCPS\\Common\\DVRS");
    UtilityMack.fireDVRSXMLProperty = new UtilityMack.FireDVRSXMLPropertychanged(this.FirePropertyChanged);
    UtilityMack.DVRSExportPath = this.defaultDVRSFileLocation;
    AcpUI.Help.Utility.HelpRootDirRelative = !string.IsNullOrEmpty(this.settingsSavedOnAppExit.SelectedHelpLanguage_RootDir) ? this.settingsSavedOnAppExit.SelectedHelpLanguage_RootDir : $"Help\\{App.AdditionalCPSLanguages.DefaultCPSLanguage}\\FlashHelp\\";
    AcpUI.Help.Utility.HelpRootDir = AppDomain.CurrentDomain.BaseDirectory + AcpUI.Help.Utility.HelpRootDirRelative;
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
    this.Title = AppResources.APX_CPS_DEPOT;
    this.ribbonBarRadioManagement.Visibility = Visibility.Collapsed;
    this.AppMenuRMC.Visibility = Visibility.Collapsed;
    this.QATRMC.Visibility = Visibility.Collapsed;
    this.AppMenuRMCSep.Visibility = Visibility.Collapsed;
    this.ribbonBarDisableWP.Visibility = Visibility.Collapsed;
    LanguagePackHelper.UpgradRadioLangSetting = this.settingsSavedOnAppExit.UpgradeRadioLang <= -1 || this.settingsSavedOnAppExit.UpgradeRadioLang >= 3 ? 0 : this.settingsSavedOnAppExit.UpgradeRadioLang;
    string lower = Thread.CurrentThread.CurrentCulture.Name.ToLower();
    if (!lower.StartsWith("ar"))
      return;
    this.AppMruList.FlowDirection = System.Windows.FlowDirection.LeftToRight;
    this.AppMruList.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Right;
    this.FindToken.Language = XmlLanguage.GetLanguage(lower);
  }

  private void InitAppFlags()
  {
    AppInfoManager.GuiVersion = 0;
    AppInfoManager.AppHideMatches = false;
    AppInfoManager.ShowRtdButtons = false;
  }

  private void InitAppView()
  {
    AppInfoManager.AppView = DifferentiatedUserViewType.Depot;
    this.DiffViewType.SelectedIndex = 4;
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
    try
    {
      if (SecurityManager.LoadAllKeys(this.defaultKeyFilesLocation, false) > 0)
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
  }

  private void SetCPSVersion()
  {
    try
    {
      this.cpsVersion = "R15.00.01";
      object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof (AssemblyDescriptionAttribute), false);
      if (customAttributes != null && customAttributes.Length > 0 && customAttributes[0] is AssemblyDescriptionAttribute descriptionAttribute && descriptionAttribute.Description != null && descriptionAttribute.Description.Length > 0)
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
    if (string.IsNullOrEmpty(arg1) || arg1.StartsWith("/") || arg1.StartsWith("-") || !arg1.EndsWith(".mc"))
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
        Environment.Exit(0);
      }
      else
      {
        e.Cancel = true;
        return;
      }
    }
    if (theDocument.IsDirty && !(bool) System.Windows.Application.Current.Properties[(object) "CommandLineCPS"] && !App.ExportXMLCommandMode)
    {
      switch (MyMessageBox.Show(AppResources.Save_changes_to_file.AcpStringFormat((object) docFileName), AppResources.APX_DEPOT, MessageBoxButton.YesNoCancel, MessageBoxImage.Exclamation, MessageBoxResult.Yes))
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
    if (e.Cancel || !flag)
      return;
    try
    {
      string path = string.Empty;
      if (((App) System.Windows.Application.Current).TheDocument.docFilePath != null)
        path = Path.GetDirectoryName(((App) System.Windows.Application.Current).TheDocument.docFilePath);
      else if (this.lastOpenCodePlugPath != string.Empty)
        path = this.lastOpenCodePlugPath;
      if (!string.IsNullOrEmpty(path) && Directory.Exists(path))
      {
        if ((int) path[path.Length - 1] != (int) Path.DirectorySeparatorChar)
          path += (string) (object) Path.DirectorySeparatorChar;
        this.settingsSavedOnAppExit.OpenCodeplugFilePath = path;
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
      this.pageIUI.GetDockWindowState(DockWndType.Naviagtion, out bVisibile, out bAutoRise, out bAutoHide);
      this.settingsSavedOnAppExit.NavigationWindowVisible = bVisibile;
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
            if (AppInfoManager.AppType == ApplicationType.LABTOOL)
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
    if (uiPagePath != null)
    {
      PageNavPaneButtons content = (PageNavPaneButtons) ((WindowMain) System.Windows.Application.Current.MainWindow).FrameLeft.Content;
      content.ButtonCpgNav.IsSelected = true;
      ((AcpTreeView) ((Page) content.GetSelectedItemContent()).Content).LaunchPage(uiPagePath);
    }
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

  public void OnPrtCustomTplReports(object sender, RoutedEventArgs e)
  {
    AcpUI.Common.Utility.SaveFieldWithFocus();
    new AcpReportMgrLib() { ParentWnd = ((Window) this) }.GenerateReport(reportType.CustomTpl);
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
      if (num8 == num1)
      {
        int index6 = num2 + 1 + 74;
        flag = AcpDocument.ValidCodeplugVersion(Encoding.BigEndianUnicode.GetString(partitionArr, index6, 26));
        break;
      }
    }
    return flag;
  }

  internal bool OpenByteArray(string sFileName, bool decrypt)
  {
    string str = "";
    bool flag1 = false;
    byte[] readBuffer = (byte[]) null;
    AcpFileHandler acpFileHandler = new AcpFileHandler();
    string modelNumber = string.Empty;
    acpFileHandler.ReadFile(out readBuffer, sFileName, decrypt);
    if (readBuffer != null && readBuffer.GetLength(0) > 0)
    {
      bool flag2 = false;
      Dictionary<int, byte[]> rawPartitions = new Dictionary<int, byte[]>();
      int int32;
      for (int sourceIndex = 0; sourceIndex < readBuffer.Length; sourceIndex = sourceIndex + 14 + int32 - 1 + 1)
      {
        byte[] numArray1 = new byte[9];
        Array.Copy((Array) readBuffer, sourceIndex, (Array) numArray1, 0, numArray1.Length);
        if (new ASCIIEncoding().GetString(numArray1) != "PARTITION")
        {
          flag2 = true;
          break;
        }
        int key = (int) readBuffer[sourceIndex + 9];
        int num;
        switch (key)
        {
          case 0:
          case 1:
            num = 1;
            break;
          default:
            num = key == 2 ? 1 : 0;
            break;
        }
        if (num == 0)
        {
          flag2 = true;
          break;
        }
        byte[] destinationArray = new byte[4];
        Array.Copy((Array) readBuffer, sourceIndex + 10, (Array) destinationArray, 0, destinationArray.Length);
        if (BitConverter.IsLittleEndian)
          Array.Reverse((Array) destinationArray);
        int32 = BitConverter.ToInt32(destinationArray, 0);
        if (int32 > readBuffer.Length || int32 <= 0)
        {
          flag2 = true;
          break;
        }
        byte[] numArray2 = new byte[int32];
        Array.Copy((Array) readBuffer, sourceIndex + 14, (Array) numArray2, 0, numArray2.Length);
        if (key == 2)
          modelNumber = this.GetModelNumber(numArray2);
        if (key == 0 && !this.ValidCodeplugVersion(numArray2))
        {
          flag2 = true;
          str = AppResources.Error_Opening_pba_file + AcpDocument.CpgVersionErrStr;
          break;
        }
        rawPartitions.Add(key, numArray2);
      }
      if (!flag2)
      {
        try
        {
          new PackUnpackExecutor().Unpack(rawPartitions, modelNumber);
          flag1 = true;
        }
        catch (Exception ex)
        {
          int num = (int) System.Windows.MessageBox.Show(AppResources.Unable_to_unpack_codeplug_image, AppResources.Open_Byte_Array_File, MessageBoxButton.OK);
          AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, AppResources.Unable_to_unpack_codeplug_image);
        }
      }
      else
      {
        if (str == "")
        {
          string selectedIsNotValid = AppResources.The_pba_file_selected_is_not_valid;
        }
        int num = (int) System.Windows.MessageBox.Show(AppResources.The_pba_file_selected_is_not_valid, AppResources.Open_Byte_Array_File, MessageBoxButton.OK);
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
        if (this.PromptQuitOnInvalids())
          return false;
        Motorola.Acp.PackUnpack.Ish.Codeplug codeplug = (Motorola.Acp.PackUnpack.Ish.Codeplug) null;
        try
        {
          PackUnpackExecutor packUnpackExecutor = new PackUnpackExecutor();
          packUnpackExecutor.PrePackHandler();
          string numberA8539Value = (FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation).General.RadInfoGeneralModelNumber_A8539Value;
          codeplug = packUnpackExecutor.Pack(numberA8539Value);
        }
        catch (Exception ex)
        {
          AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, AppResources.Unable_to_pack_codeplug_image);
        }
        if (codeplug != null)
        {
          if (codeplug.Partitions.Count != 0)
          {
            int num1 = 6;
            int num2 = num1 - 2;
            int num3 = num1 - 2;
            if (File.Exists(sFilePath))
              File.Delete(sFilePath);
            byte[] array = new byte[0];
            foreach (Partition partition in codeplug.Partitions)
            {
              num2 = num1 - 2;
              num3 = num1 - 2;
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
            new AcpFileHandler().WriteFile(array, (AcpFileHeader) null, sFilePath, encrypt, FileMode.Create);
            flag = true;
            int num4 = (int) System.Windows.MessageBox.Show(AppResources.ByteArray_file_successfully_created, AppResources.Save_Codeplug_as_ByteArray, MessageBoxButton.OK);
          }
          else
          {
            int num5 = (int) System.Windows.MessageBox.Show(AppResources.Unable_to_save_Codeplug_Invalid_codeplug_image, AppResources.Save_Codeplug_as_ByteArray, MessageBoxButton.OK);
          }
        }
        else
        {
          int num6 = (int) System.Windows.MessageBox.Show(AppResources.Unable_to_pack_codeplug_image, AppResources.Save_Codeplug_as_ByteArray, MessageBoxButton.OK);
        }
      }
      else
      {
        int num7 = (int) System.Windows.MessageBox.Show(AppResources.A_codeplug_must_be_opened_before_this_function_can_be_used, AppResources.Save_Codeplug_as_ByteArray, MessageBoxButton.OK);
      }
    }
    else
    {
      int num8 = (int) System.Windows.MessageBox.Show(AppResources.Unable_to_save_Codeplug_Invalid_Filename, AppResources.Save_Codeplug_as_ByteArray, MessageBoxButton.OK);
    }
    return flag;
  }

  private string GetApplicationVersion()
  {
    Version version = Assembly.GetExecutingAssembly().GetName().Version;
    int num = version.Major;
    string str1 = num.ToString("D2");
    num = version.Minor;
    string str2 = num.ToString("D2");
    num = version.Build;
    string str3 = num.ToString("D2");
    num = version.Revision;
    string str4 = num.ToString("D2");
    return str1 + str2 + str3 + str4;
  }

  private string GetPartitionID(PartitionType partType)
  {
    switch (partType)
    {
      case PartitionType.Application:
        return "CPGA";
      case PartitionType.ExtendedUcl:
        return "UCLA";
      case PartitionType.Security:
        return "SECA";
      default:
        return "";
    }
  }

  internal byte[] CalculateCheckSum(byte[] totalData)
  {
    byte[] checkSum = new byte[4];
    try
    {
      Crc32 crc32 = new Crc32();
      int index = 0;
      foreach (byte num in crc32.ComputeHash(totalData))
      {
        checkSum[index] = num;
        ++index;
      }
    }
    catch (Exception ex)
    {
      AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, AppResources.Unable_to_pack_codeplug_image_bbf);
    }
    return checkSum;
  }

  internal byte[] CreatePBA()
  {
    Motorola.Acp.PackUnpack.Ish.Codeplug codeplug = (Motorola.Acp.PackUnpack.Ish.Codeplug) null;
    byte[] array = new byte[0];
    try
    {
      PackUnpackExecutor packUnpackExecutor = new PackUnpackExecutor();
      packUnpackExecutor.PrePackHandler();
      string numberA8539Value = (FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation).General.RadInfoGeneralModelNumber_A8539Value;
      codeplug = packUnpackExecutor.Pack(numberA8539Value);
    }
    catch (Exception ex)
    {
      AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, AppResources.Unable_to_pack_codeplug_image);
    }
    if (codeplug != null)
    {
      if (codeplug.Partitions.Count != 0)
      {
        int num1 = 6;
        int num2 = num1 - 2;
        int num3 = num1 - 2;
        foreach (Partition partition in codeplug.Partitions)
        {
          num2 = num1 - 2;
          num3 = num1 - 2;
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
      }
    }
    else
    {
      int num = (int) System.Windows.MessageBox.Show(AppResources.Unable_to_pack_codeplug_image, AppResources.Save_Codeplug_as_ByteArray, MessageBoxButton.OK);
    }
    return array;
  }

  internal byte[] FPSReadBlock(string currentFlashcode, string serialNumber, bool isFPS = true)
  {
    byte[] totalData = (byte[]) null;
    try
    {
      byte[] pba = this.CreatePBA();
      string str = Environment.CurrentDirectory + "\\DefaultCodeplugs\\CPS_generated_cpg.pba";
      if (isFPS)
      {
        if (File.Exists(str))
          File.Delete(str);
        try
        {
          new AcpFileHandler().WriteFile(pba, (AcpFileHeader) null, str, false, FileMode.Create);
        }
        catch
        {
          int num = (int) System.Windows.MessageBox.Show(AppResources.Unable_to_save_Codeplug_Invalid_codeplug_image, AppResources.Save_Codeplug_as_ByteArray, MessageBoxButton.OK);
        }
      }
      int length = pba.Length;
      int num1 = pba.Length % 16 /*0x10*/;
      int num2 = 0;
      if (num1 > 0)
        num2 = 16 /*0x10*/ - num1;
      System.Collections.Generic.List<byte> byteList = new System.Collections.Generic.List<byte>();
      byteList.AddRange((IEnumerable<byte>) Encoding.ASCII.GetBytes("@BBFhdr@"));
      byteList.Add((byte) 1);
      byteList.Add((byte) 0);
      byteList.Add((byte) 0);
      byteList.Add((byte) 0);
      byteList.Add((byte) 0);
      byteList.Add((byte) 2);
      byteList.Add((byte) 0);
      byteList.Add((byte) 0);
      byteList.Add((byte) 0);
      byteList.Add((byte) 0);
      byteList.Add((byte) 0);
      byteList.Add((byte) 0);
      byteList.Add((byte) 2);
      byteList.Add((byte) 0);
      byteList.Add((byte) 0);
      byteList.Add((byte) 0);
      string s = this.MyModelNumber + currentFlashcode;
      if (s.Length > 64 /*0x40*/)
        throw new Exception();
      byteList.AddRange((IEnumerable<byte>) Encoding.ASCII.GetBytes(s));
      for (int byteCount = Encoding.ASCII.GetByteCount(s); byteCount < 64 /*0x40*/; ++byteCount)
        byteList.Add((byte) 0);
      if (this.CPS_Version.Length > 16 /*0x10*/)
        throw new Exception();
      byteList.AddRange((IEnumerable<byte>) Encoding.ASCII.GetBytes(this.CPS_Version));
      for (int byteCount = Encoding.ASCII.GetByteCount(this.CPS_Version); byteCount < 16 /*0x10*/; ++byteCount)
        byteList.Add((byte) 0);
      int num3 = 832 + length + num2;
      byte[] numArray1 = new byte[4];
      byte[] bytes1 = BitConverter.GetBytes(num3);
      byteList.AddRange((IEnumerable<byte>) bytes1);
      numArray1 = (byte[]) null;
      int num4 = 320 + length + num2;
      byte[] numArray2 = new byte[4];
      byte[] bytes2 = BitConverter.GetBytes(num4);
      byteList.AddRange((IEnumerable<byte>) bytes2);
      numArray2 = (byte[]) null;
      for (int index = 0; index < 12; ++index)
        byteList.Add((byte) 0);
      for (int index = 0; index < 144 /*0x90*/; ++index)
        byteList.Add(byte.MaxValue);
      for (int index = 0; index < 244; ++index)
        byteList.Add(byte.MaxValue);
      byteList.AddRange((IEnumerable<byte>) Encoding.ASCII.GetBytes("@BBFimg@"));
      byteList.Add((byte) 64 /*0x40*/);
      byteList.Add((byte) 0);
      byteList.Add((byte) 0);
      byteList.Add((byte) 0);
      byteList.Add((byte) 0);
      byteList.Add((byte) 0);
      byteList.Add((byte) 3);
      byteList.Add((byte) 0);
      for (int index = 0; index < 8; ++index)
        byteList.Add((byte) 0);
      byte[] numArray3 = new byte[4];
      byte[] bytes3 = BitConverter.GetBytes(256 /*0x0100*/ + length);
      byteList.AddRange((IEnumerable<byte>) bytes3);
      numArray3 = (byte[]) null;
      byteList.Add(byte.MaxValue);
      byteList.Add(byte.MaxValue);
      byteList.Add(byte.MaxValue);
      byteList.Add(byte.MaxValue);
      if (Encoding.ASCII.GetByteCount("CPG") > 8)
        throw new Exception();
      byteList.AddRange((IEnumerable<byte>) Encoding.ASCII.GetBytes("CPG"));
      for (int byteCount = Encoding.ASCII.GetByteCount("CPG"); byteCount < 8; ++byteCount)
        byteList.Add((byte) 0);
      if (this.CPS_Version.Length > 16 /*0x10*/)
        throw new Exception();
      byteList.AddRange((IEnumerable<byte>) Encoding.ASCII.GetBytes(this.CPS_Version));
      for (int byteCount = Encoding.ASCII.GetByteCount(this.CPS_Version); byteCount < 16 /*0x10*/; ++byteCount)
        byteList.Add((byte) 0);
      byteList.Add((byte) 0);
      byteList.Add((byte) 0);
      byteList.Add((byte) 0);
      byteList.Add((byte) 0);
      byteList.Add(byte.MaxValue);
      byteList.Add(byte.MaxValue);
      byteList.Add(byte.MaxValue);
      byteList.Add(byte.MaxValue);
      if (Encoding.ASCII.GetByteCount("CODEPLUG/codeplug.pba") > 256 /*0x0100*/)
        throw new Exception();
      byteList.AddRange((IEnumerable<byte>) Encoding.ASCII.GetBytes("CODEPLUG/codeplug.pba"));
      for (int byteCount = Encoding.ASCII.GetByteCount("CODEPLUG/codeplug.pba"); byteCount < 256 /*0x0100*/; ++byteCount)
        byteList.Add((byte) 0);
      byteList.AddRange((IEnumerable<byte>) pba);
      if (num1 > 0)
      {
        for (int index = 0; index < num2; ++index)
          byteList.Add((byte) 0);
      }
      byteList.AddRange((IEnumerable<byte>) Encoding.ASCII.GetBytes("@BBFimg@"));
      byteList.Add((byte) 64 /*0x40*/);
      byteList.Add((byte) 0);
      byteList.Add((byte) 0);
      byteList.Add((byte) 0);
      byteList.Add((byte) 0);
      byteList.Add((byte) 0);
      byteList.Add((byte) 236);
      byteList.Add((byte) 0);
      for (int index = 0; index < 8; ++index)
        byteList.Add(byte.MaxValue);
      byteList.Add((byte) 144 /*0x90*/);
      byteList.Add((byte) 0);
      byteList.Add((byte) 0);
      byteList.Add((byte) 0);
      byteList.Add(byte.MaxValue);
      byteList.Add(byte.MaxValue);
      byteList.Add(byte.MaxValue);
      byteList.Add(byte.MaxValue);
      for (int index = 0; index < 28; ++index)
        byteList.Add((byte) 0);
      byteList.Add(byte.MaxValue);
      byteList.Add(byte.MaxValue);
      byteList.Add(byte.MaxValue);
      byteList.Add(byte.MaxValue);
      byteList.Add((byte) 0);
      byteList.Add((byte) 0);
      byteList.Add((byte) 0);
      byteList.Add((byte) 0);
      for (int index = 0; index < 104; ++index)
        byteList.Add((byte) 0);
      for (int index = 0; index < 32 /*0x20*/; ++index)
        byteList.Add(byte.MaxValue);
      totalData = byteList.ToArray();
      byte[] numArray4 = new byte[4];
      byte[] checkSum = this.CalculateCheckSum(totalData);
      totalData = (byte[]) null;
      byteList.AddRange((IEnumerable<byte>) checkSum);
      totalData = byteList.ToArray();
    }
    catch (Exception ex)
    {
      AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, AppResources.Unable_to_pack_codeplug_image_bbf);
    }
    return totalData;
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
      string numberA9122Value = (FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation).General.RadInfoGeneralSerialNumber_A9122Value;
      byte[] writeBuffer = this.FPSReadBlock(currentFlashcode, numberA9122Value);
      if (writeBuffer != null && writeBuffer.GetLength(0) > 0)
      {
        if (File.Exists(sFileName))
          File.Delete(sFileName);
        new AcpFileHandler().WriteFile(writeBuffer, (AcpFileHeader) null, sFileName, false, FileMode.Create);
      }
    }
    else
    {
      int num = (int) System.Windows.MessageBox.Show(AppResources.codeplug_must_open_before_this_function_use, AppResources.Save_Codeplug_as_Srecord, MessageBoxButton.OK);
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
      bool flag1 = false;
      Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation radioInformation = FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation;
      string versionA7683UiValue = radioInformation.General.RadInfoGeneralCodeplugVersion_A7683_UIValue;
      radioInformation.General.RadInfoGeneralCodeplugVersion_A7683.SetValue(this.cpsVersion);
      radioInformation.Labtool.RadInfoLabtoolSecurePartitionVersionNumber_A9076.SetValue(this.cpsVersion);
      Motorola.Acp.PackUnpack.Ish.Codeplug codeplug = (Motorola.Acp.PackUnpack.Ish.Codeplug) null;
      try
      {
        PackUnpackExecutor packUnpackExecutor = new PackUnpackExecutor();
        packUnpackExecutor.PrePackHandler();
        string numberA8539Value = radioInformation.General.RadInfoGeneralModelNumber_A8539Value;
        codeplug = packUnpackExecutor.Pack(numberA8539Value);
      }
      catch (Exception ex)
      {
        AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, AppResources.Unable_to_pack_codeplug_image);
      }
      if (codeplug != null)
      {
        PartitionCollection partitions = codeplug.Partitions;
        if (partitions.Count != 0)
        {
          if (sFileName != null)
          {
            foreach (Partition partition in partitions)
            {
              byte[] buffer = partition.Image.GetBuffer();
              if (buffer != null && buffer.GetLength(0) > 0)
              {
                string filePath = "";
                string str = "";
                if (partition.PartitionType == PartitionType.Application)
                {
                  filePath = sFileName.Insert(sFileName.IndexOf(".srec"), "_application");
                  str = System.Windows.Forms.Application.StartupPath + "\\Srecord\\Apx_external.cfg";
                }
                else if (partition.PartitionType == PartitionType.Security)
                {
                  filePath = sFileName.Insert(sFileName.IndexOf(".srec"), "_security");
                  str = System.Windows.Forms.Application.StartupPath + "\\Srecord\\Apx_security.cfg";
                }
                else if (partition.PartitionType == PartitionType.ExtendedUcl)
                {
                  filePath = sFileName.Insert(sFileName.IndexOf(".srec"), "_UCL");
                  str = System.Windows.Forms.Application.StartupPath + "\\Srecord\\Apx_UCL.cfg";
                }
                if (File.Exists(str))
                {
                  AcpPbtSrec acpPbtSrec = new AcpPbtSrec();
                  byte[] writeBuffer = new byte[0];
                  byte[] numArray = new byte[partition.Image.Length];
                  Array.Copy((Array) buffer, (Array) numArray, partition.Image.Length);
                  acpPbtSrec.ConvertPackedImageToSrec(numArray, str, ref writeBuffer);
                  if (writeBuffer != null && writeBuffer.GetLength(0) > 0)
                  {
                    bool flag2;
                    try
                    {
                      string version = this.GetApplicationVersion().PadRight(10);
                      string partitionId = this.GetPartitionID(partition.PartitionType);
                      string fixedStr = "SWINFO";
                      flag2 = acpPbtSrec.prependS0Line(ref writeBuffer, fixedStr, partitionId, "", version);
                    }
                    catch (Exception ex)
                    {
                      flag2 = false;
                    }
                    if (!flag2)
                      AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, AppResources.Unable_to_preprend_S0_line_to_srec_file_for_0_partition.AcpStringFormat((object) partition.PartitionType.ToString()));
                    new AcpFileHandler().WriteFile(writeBuffer, (AcpFileHeader) null, filePath, false, FileMode.Create);
                  }
                  else
                  {
                    int num = (int) System.Windows.MessageBox.Show(AppResources.Unable_to_save_Partition_as_Srecord.AcpStringFormat((object) partition.PartitionType.ToString()), AppResources.Save_Codeplug_as_Srecord, MessageBoxButton.OK);
                  }
                }
                else
                {
                  int num1 = (int) System.Windows.MessageBox.Show(AppResources.Required_config_file_missing + str, AppResources.Save_Codeplug_as_Srecord, MessageBoxButton.OK);
                }
              }
              else
              {
                int num2 = (int) System.Windows.MessageBox.Show(AppResources.Unable_to_save_Codeplug_as_Srecord_codeplug_image, AppResources.Save_Codeplug_as_Srecord, MessageBoxButton.OK);
              }
            }
          }
          else
          {
            int num3 = (int) System.Windows.MessageBox.Show(AppResources.Unable_to_save_Codeplug_as_Srecord_Invalid_Filename, AppResources.Save_Codeplug_as_Srecord, MessageBoxButton.OK);
          }
        }
        else
        {
          int num4 = (int) System.Windows.MessageBox.Show(AppResources.Unable_to_save_Codeplug_as_Srecord_codeplug_image, AppResources.Save_Codeplug_as_Srecord, MessageBoxButton.OK);
        }
      }
      else
      {
        int num5 = (int) System.Windows.MessageBox.Show(AppResources.Unable_to_pack_codeplug_image, AppResources.Save_Codeplug_as_Srecord, MessageBoxButton.OK);
      }
      if (!flag1)
      {
        radioInformation.General.RadInfoGeneralCodeplugVersion_A7683.SetValue(versionA7683UiValue);
        radioInformation.Labtool.RadInfoLabtoolSecurePartitionVersionNumber_A9076.SetValue(versionA7683UiValue);
      }
    }
    else
    {
      int num6 = (int) System.Windows.MessageBox.Show(AppResources.codeplug_must_open_before_this_function_use, AppResources.Save_Codeplug_as_Srecord, MessageBoxButton.OK);
    }
  }

  internal void OnAppCustomizeOpen(object sender, RoutedEventArgs e)
  {
    AcpOpenFileDialog acpOpenFileDialog = new AcpOpenFileDialog();
    acpOpenFileDialog.Filter = AppResources.All_image_types_Filter;
    acpOpenFileDialog.MultiSelect = false;
    bool? nullable = acpOpenFileDialog.ShowDialog();
    if ((!nullable.GetValueOrDefault() ? 0 : (nullable.HasValue ? 1 : 0)) == 0)
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
      if (mainWindow.FrameCenterTop.Content is PageWelcome)
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
    get => this.CpgOpenFlag && (this.DeviceFromServer != null || this.TemplateFromServer != null);
  }

  internal void HandleUpdateIsMobileModel(bool isMobile) => this.IsMobileModel = isMobile;

  internal void HandleUpdateIsPortableModel(bool isPortable) => this.IsPortableModel = isPortable;

  internal void HandleAbortFileOpen() => this.CloseFile();

  internal bool LaunchReadRadio(int myTransport)
  {
    string empty = string.Empty;
    return this.LaunchReadRadio(myTransport, ref empty);
  }

  internal bool LaunchReadRadio(int myTransport, ref string errorMsg, bool isCruncherWriteCheckPBA = false)
  {
    bool status = false;
    bool flag1 = false;
    string str = "";
    Motorola.Common.Communication.CommonUtil.IshItemCollection radioCodeplug = (Motorola.Common.Communication.CommonUtil.IshItemCollection) null;
    SpecialFeatures.Comms.Comms ReadRadio = new SpecialFeatures.Comms.Comms();
    SpecialFeatures.Comms.Comms.updateStatus += new SpecialFeatures.Comms.Comms.DisplayUpdateStatus(this.ReadRadio_updateStatus);
    SpecialFeatures.Comms.Comms.displayCBI += new SpecialFeatures.Comms.Comms.MainUIDisplayCBI(this.WindowMain_DisplayCBI);
    SpecialFeatures.Comms.Comms.displayOTAP += new SpecialFeatures.Comms.Comms.MainUIDisplayOTAP(this.WindowMain_DisplayOTAP);
    if (myTransport == 0)
      radioCodeplug = ReadRadio.ReadRadio(COMMS_OP.USB_READ_WRITE, ref errorMsg, isCruncherWriteCheckPBA);
    if (myTransport == 1 && this.Pop25Enabled)
    {
      radioCodeplug = ReadRadio.ReadRadio(COMMS_OP.OTAP_READ_WRITE, this.commsLastUserState);
      this.commsLastUserState = ReadRadio.GetLastCommsOTAPUserState();
    }
    if (myTransport == 2)
    {
      radioCodeplug = ReadRadio.ReadRadio(COMMS_OP.BLUETOOTH_READ_WRITE, this.commsLastUserState);
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
        read = false;
        if ((bool) System.Windows.Application.Current.Properties[(object) "CommandLineCPS"])
          read = false;
        string serialNumber = ParseDataHelper.RadioSNToString(ReadRadio.GetRadioParams().SerialNumber);
        if (read && !ReadWritePasswordApp.ValidateOKToRead((Window) this, empty, serialNumber))
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
            ReadRadio.unpackFromRadio(radioCodeplug);
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
    if (flag1 && ((App) System.Windows.Application.Current).TheDocument.IsOpen)
    {
      if (!(bool) System.Windows.Application.Current.Properties[(object) "CommandLineCPS"])
        this.Dispatcher.Invoke((Delegate) new WindowMain.AbortFileOpen(this.HandleAbortFileOpen), DispatcherPriority.Normal);
      else
        this.HandleAbortFileOpen();
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
    UndoManager.Reset();
    return flag2;
  }

  internal void WindowMain_CloseProgressWindow()
  {
    this.progressPage.Hide();
    this.progressPage.SetCloseBtnEnable(true);
    this.progressPage.Close();
    this.progressPage.Dispose();
  }

  private void PostUpgradeCodeplugProccessing(string codeplugVersion, string appVersion)
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
      if (!(FeatureManager.GetFeature(2045)[0] is Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide radioWide) || num1 >= 13 || num2 < 13 || num2 <= num1)
        return;
      radioWide.Location.GPSFailToneInterval_42329.Value = radioWide.Location.GPSFailToneInterval_42329.DefaultValue;
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
    bool flag = false;
    FileInfo fileInfo = (FileInfo) null;
    FileStream fileStream = (FileStream) null;
    try
    {
      fileInfo = new FileInfo(fileName);
      if (fileInfo != null)
        fileStream = fileInfo.Create();
      flag = fileStream != null;
    }
    catch (Exception ex)
    {
      flag = false;
    }
    finally
    {
      if (fileStream != null)
      {
        fileStream.Close();
        fileInfo?.Delete();
      }
    }
    return flag;
  }

  private bool ReadRadioComplete(bool status, SpecialFeatures.Comms.Comms ReadRadio, RadioParams currentRadio)
  {
    this.ResolvedMFKTimerUnpack();
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
    this.IsMobileModelAndSupportedO9 = false;
    this.IsMobileModelAndSupportedO3 = false;
    this.IsMobileModelAndSupportedO5 = false;
    this.IsMobileModelAndSupportedO7 = false;
    this.IsMobileModelAndSupportedO2 = false;
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
      bool flag = this.O9TableInit();
      this.MFKTableInit();
      this.ShepherdsInitForFob();
      this.TriggerMuteToneRefresh();
      this.DEKVipTableInit();
      this.O2MFKTableInit();
      this.O7MFKTableInit();
      this.O2NavigationControlsTableInit();
      this.O7NavigationControlsTableInit();
      this.O3NavigationControlsTableInit();
      this.O5NavigationControlsTableInit();
      this.O9NavigationControlsTableInit();
      this.KMANavigationControlsTableInit();
      this.PresetZoneChannelTableInit();
      this.KeypadRecsetAndTableInit();
      this.SmartKeyFobTableInit();
      this.SideArrowTableInit();
      this.SiteSelectableAlertTableInit();
      if (this.IsPortableModel)
      {
        this.TxPowerTableInit();
        this.ResetRadioKilledBit();
      }
      if (this.IsMobileModel)
      {
        this.TxPowerTableInitForMobile();
        this.TxPowerNewTableInitForMobile();
        this.BandSplitOverRidingInit();
      }
      this.AddQC2DefaultRecord();
      ((App) System.Windows.Application.Current).TheDocument.Initialized(true);
      ConstraintManager.Suspend();
      this.updateUnpackedFields(true, currentRadioParams);
      this.hideADPKeyData();
      if (flag)
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
      this.ReadRadio_updateStatus(1.0, AppResources.Read_Radio_Verification_Complete);
      message = AppResources.Read_Radio_Verification_Complete;
      type = StatusMsgType.Info;
      this.progressPage.SetCloseBtnEnable(true);
      this.progressPage.Close();
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
    string stat = "";
    this.dvrsMsuDataSync = (DvrsMsuDataSync) null;
    UndoManager.StopUndoRedo();
    SpecialFeatures.Comms.Comms comms = new SpecialFeatures.Comms.Comms();
    try
    {
      RadioParams codeplgParams = new RadioParams();
      COMMS_OP WriteType = COMMS_OP.USB_READ_WRITE;
      if (myTransport == 1)
        WriteType = COMMS_OP.OTAP_READ_WRITE;
      if (myTransport == 2)
        WriteType = COMMS_OP.BLUETOOTH_READ_WRITE;
      bool flag2 = true;
      SpecialFeatures.Comms.Comms.updateStatus += new SpecialFeatures.Comms.Comms.DisplayUpdateStatus(this.ReadRadio_updateStatus);
      SpecialFeatures.Comms.Comms.displayCBI += new SpecialFeatures.Comms.Comms.MainUIDisplayCBI(this.WindowMain_DisplayCBI);
      SpecialFeatures.Comms.Comms.displayOTAP += new SpecialFeatures.Comms.Comms.MainUIDisplayOTAP(this.WindowMain_DisplayOTAP);
      bool wp;
      bool askReq;
      int ownerKeyType;
      int ownerSysId;
      int ownerWacnId;
      ASKProgrammingHistoryInnerRecset askProgRecset;
      bool flag3 = RadioAccessValidator.CacheCodeplugSecurityFields(out wp, out askReq, out ownerKeyType, out ownerSysId, out ownerWacnId, out askProgRecset);
      if (myTransport == 0)
        flag2 = comms.blockRadioWrite(WriteType, updateWriteProtect: updateWriteProtect);
      if (myTransport == 1 && this.Pop25Enabled)
      {
        flag2 = comms.blockRadioWrite(WriteType, this.commsLastUserState);
        this.commsLastUserState = comms.GetLastCommsOTAPUserState();
      }
      if (myTransport == 2)
        flag2 = comms.blockRadioWrite(WriteType, this.commsLastUserState);
      if (myTransport == 1 && !this.Pop25Enabled)
      {
        stat = AppResources.Please_attach_and_load_the_hardware_Key_to_proceed_with_Otap_Read_Write;
        this.ReadRadio_updateStatus(0.0, stat);
      }
      if (!flag2)
      {
        bool read = false;
        bool write = false;
        bool archive = false;
        string empty = string.Empty;
        comms.GetReadWritePassword(ref read, ref write, ref archive, ref empty);
        write = false;
        if ((bool) System.Windows.Application.Current.Properties[(object) "CommandLineCPS"])
          write = false;
        string serialNumber = ParseDataHelper.RadioSNToString(comms.GetRadioParams().SerialNumber);
        if (write && !ReadWritePasswordApp.ValidateOKToWrite((Window) this, empty, serialNumber))
        {
          this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Delegate) new WindowMain.CloseProgressWindow(this.WindowMain_CloseProgressWindow));
          comms.ForceClose();
        }
        else
        {
          Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation radioInformation = FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation;
          string versionA7683UiValue = radioInformation.General.RadInfoGeneralCodeplugVersion_A7683_UIValue;
          radioInformation.General.RadInfoGeneralCodeplugVersion_A7683.SetValue(this.cpsVersion);
          Motorola.MackinawCPS.CoreFeatures.DVRSWide.DVRSWide dvrsWide = FeatureManager.GetFeature(4142)[0] as Motorola.MackinawCPS.CoreFeatures.DVRSWide.DVRSWide;
          if (dvrsWide.General.RadErgoWideDigitalVehicularRepeaterSystemDVRSHardwareEnable_A7911.Value)
          {
            this.dvrsMsuDataSync = new DvrsMsuDataSync();
            uint hashCode = this.dvrsMsuDataSync.CalculateHashCode();
            dvrsWide.General.DVRSWideLabtoolDVRSSyncFieldsHash_A41811.SetValue((long) hashCode);
          }
          comms.UpdatePINPasswordBeforeWrite();
          comms.ResetTrunkingRadioInhibit();
          Motorola.Common.Communication.CommonUtil.IshItemCollection codeplug = comms.packToCodeplug();
          if (codeplug != null)
          {
            if (codeplug.Count > 0)
            {
              switch (myTransport)
              {
                case 0:
                  flag1 = comms.WriteRadio(codeplug, COMMS_OP.USB_READ_WRITE, codeplgParams);
                  break;
                case 1:
                  flag1 = comms.WriteRadio(codeplug, COMMS_OP.OTAP_READ_WRITE, codeplgParams, this.commsLastUserState);
                  this.commsLastUserState = comms.GetLastCommsOTAPUserState();
                  break;
                case 2:
                  flag1 = comms.WriteRadio(codeplug, COMMS_OP.BLUETOOTH_READ_WRITE, codeplgParams, this.commsLastUserState);
                  break;
              }
            }
            else
            {
              stat = AppResources.problem_dot_unable_to_write_radio;
              this.ReadRadio_updateStatus(0.0, stat);
            }
          }
          else
          {
            stat = AppResources.problem_dot_unable_to_write_radio;
            this.ReadRadio_updateStatus(0.0, stat);
          }
          if (!flag1)
          {
            if (codeplug == null)
              comms.ForceClose();
            if (versionA7683UiValue != "")
              radioInformation.General.RadInfoGeneralCodeplugVersion_A7683.SetValue(versionA7683UiValue);
          }
        }
      }
      else
        stat = AppResources.problem_dot_unable_to_write_radio;
      if (flag3)
        RadioAccessValidator.RestoreCachedCodeplugSecurityFields(wp, askReq, ownerKeyType, ownerSysId, ownerWacnId, askProgRecset);
      this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Delegate) new WindowMain.ReadComplete(this.WindowMain_WriteRadioFinished), (object) flag1, (object) stat, (object) comms.m_LastLPKUserState, (object) comms.GetRadioParams());
      SpecialFeatures.Comms.Comms.updateStatus -= new SpecialFeatures.Comms.Comms.DisplayUpdateStatus(this.ReadRadio_updateStatus);
      SpecialFeatures.Comms.Comms.displayCBI -= new SpecialFeatures.Comms.Comms.MainUIDisplayCBI(this.WindowMain_DisplayCBI);
      SpecialFeatures.Comms.Comms.displayOTAP -= new SpecialFeatures.Comms.Comms.MainUIDisplayOTAP(this.WindowMain_DisplayOTAP);
      this.ReadWriteInProgress = false;
    }
    catch (Exception ex)
    {
      UndoManager.StartUndoRedo();
    }
    finally
    {
      comms.Dispose();
    }
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
    ProgressUserState userState = (ProgressUserState) null;
    if (stat == AppResources.Opening_Port)
      userState = new ProgressUserState(UserState.ConnectStart, UserState.None, AppResources.Opening_Connection_To_Radio);
    else if (stat == AppResources.Open_Port_Complete)
      userState = new ProgressUserState(UserState.ConnectDone, UserState.None, AppResources.Connecting_opened_to_radio);
    else if (stat == AppResources.Read_Radio_Info)
      userState = new ProgressUserState(UserState.ReadRadInfoStart, UserState.None, AppResources.Read_radio_info_start_);
    else if (stat == AppResources.Read_Radio_Info_Complete)
      userState = new ProgressUserState(UserState.ReadRadInfoDone, UserState.None, AppResources.Read_radio_info_complete_);
    else if (stat == AppResources.ReadRadio_Calling_End_Read_Radio)
      userState = new ProgressUserState(UserState.CodeplugDone, UserState.None, AppResources.Read_radio_codeplug_complete);
    else if (stat == AppResources.Reading_radio_codeplug_completed)
      userState = new ProgressUserState(UserState.None, UserState.None, AppResources.Reading_radio_codeplug_);
    else if (stat == AppResources.Reading_radio_codeplug_)
      userState = new ProgressUserState(UserState.None, UserState.None, AppResources.Reading_radio_codeplug_);
    else if (stat == AppResources.ReadRadio_Reading_codeplug_from_radio)
      userState = new ProgressUserState(UserState.CodeplugStart, UserState.None, AppResources.Begin_read_codeplug);
    else if (stat == AppResources.Read_Radio_Verification_Start)
      userState = new ProgressUserState(UserState.FinalValidationStart, UserState.None, AppResources.Read_Radio_Verification_Start_);
    else if (stat == AppResources.Read_Radio_Verification_)
      userState = new ProgressUserState(UserState.None, UserState.None, AppResources.Read_Radio_Verification_);
    else if (stat == AppResources.Read_Radio_Verification_Complete)
      userState = new ProgressUserState(UserState.FinalValidationDone, UserState.None, AppResources.Read_Radio_Verification_Complete);
    else if (stat == AppResources.Read_Radio_Verification_Fail)
      userState = new ProgressUserState(UserState.FinalValidationError, UserState.None, AppResources.Read_Radio_Verification_Fail);
    else if (stat == AppResources.Unpack_failure_during_read)
      userState = new ProgressUserState(UserState.FinalValidationError, UserState.None, AppResources.Read_radio_unpack_failure);
    else if (stat == AppResources.Writing_radio_codeplug)
      userState = new ProgressUserState(UserState.None, UserState.None, AppResources.Write_to_radio_in_progress);
    else if (stat == AppResources.WriteRadio_Writing_codeplug_to_radio)
      userState = new ProgressUserState(UserState.FlashingComponentStart, UserState.None, AppResources.Begin_write_to_radio);
    else if (stat == AppResources.Writing_radio_codeplug_completed)
      userState = new ProgressUserState(UserState.FlashingComponentDone, UserState.None, AppResources.Write_to_radio_complete);
    else if (stat == AppResources.WriteRadio_eject_radio)
      userState = new ProgressUserState(UserState.FinalValidationStart, UserState.None, AppResources.Write_radio_releasing_radio);
    else if (!(stat == AppResources.Wait_For_Radio_Eject))
    {
      if (stat == AppResources.A_problem_was_encountered_Unable_to_write_to_the_radio)
        userState = new ProgressUserState(UserState.ReadRadInfoError, UserState.None, stat);
      else if (stat == AppResources.WriteRadio_Close_Port)
        userState = new ProgressUserState(UserState.FinalValidationDone, UserState.None, AppResources.Write_radio_release_complete);
      else if (stat == AppResources.Radio_Erase_in_Progress_please_wait)
        userState = new ProgressUserState(UserState.None, UserState.None, AppResources.Radio_Erasing_please_wait);
      else if (stat == AppResources.Radio_Serial_Number_updated)
        userState = new ProgressUserState(UserState.ReadRadInfoDone, UserState.None, AppResources.Radio_Serial_Number_updated);
      else if (stat == AppResources.Radio_Serial_Number_update_failed)
        userState = new ProgressUserState(UserState.ReadRadInfoError, UserState.None, AppResources.Radio_Serial_Number_update_failed);
      else if (stat == AppResources.Please_Read_CBI_initialized_radio_first)
        userState = new ProgressUserState(UserState.ReadRadInfoError, UserState.None, stat);
      else if (stat == AppResources.Failed_Radio_Serial_Number_read)
        userState = new ProgressUserState(UserState.ReadRadInfoError, UserState.None, stat);
      else if (stat == AppResources.Failure_when_attempting_opening_connection)
        userState = new ProgressUserState(UserState.ConnectError, UserState.None, stat);
      else if (stat == AppResources.LP_Language_Pack_Update_Success)
        userState = new ProgressUserState(UserState.None, UserState.None, stat);
      else if (stat == AppResources.LP_Begin_Language_Pack_Update)
        userState = new ProgressUserState(UserState.CodeplugStart, UserState.None, stat);
      else if (stat == AppResources.LP_Cannot_Determine_Host_Version)
        userState = new ProgressUserState(UserState.None, UserState.None, stat);
      else if (!(stat == AppResources.LP_Radio_display_Language_Not_Supported_By_this_radio))
        userState = new ProgressUserState(UserState.CodeplugError, UserState.None, stat);
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
    IAcpRecordset feature = FeatureManager.GetFeature(2053);
    if (feature == null)
      return;
    foreach (AcpBusinessLayer.FeatureNode featureNode in (Collection<AcpBusinessLayer.FeatureNode>) feature)
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
    if (feature != null && feature[0][10604] is LightbarPattern lightbarPattern && !lightbarPattern.RadWideUniversalRelayControllerEquipped_A37191.Value)
    {
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
  }

  private void FixupSirenButtons()
  {
    if (int.Parse(((string) (FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation).General.RadInfoGeneralCodeplugVersion_A7683).Substring(1, 2)) >= 9)
      return;
    PASiren paSiren = (FeatureManager.GetFeature(2033) as RadioErgonomicsWideRecset)[0][10225] as PASiren;
    if (paSiren.RadErgoWidePASirenSirenOperation_A9139.Value == 2)
    {
      SignalIndependentProductIndependentNonProgrammableButtonListInnerRecset embeddedRecset = (FeatureManager.GetFeature(2013) as ShepherdsRecset)[0][10031].EmbeddedRecset as SignalIndependentProductIndependentNonProgrammableButtonListInnerRecset;
      if (!paSiren.RadErgoWidePASirenHiLoAirhornTones_A8200.Value)
        (embeddedRecset[24] as SignalIndependentProductIndependentNonProgrammableButtonListInner).SignalIndependentProductIndependentNonProgrammableButtonListInnerSection.RadErgoCfgSignalIndependentProductIndependentNonProgrammableButtonFeature_A19778.Value = 199;
      (embeddedRecset[25] as SignalIndependentProductIndependentNonProgrammableButtonListInner).SignalIndependentProductIndependentNonProgrammableButtonListInnerSection.RadErgoCfgSignalIndependentProductIndependentNonProgrammableButtonFeature_A19778.Value = 200;
      (embeddedRecset[26] as SignalIndependentProductIndependentNonProgrammableButtonListInner).SignalIndependentProductIndependentNonProgrammableButtonListInnerSection.RadErgoCfgSignalIndependentProductIndependentNonProgrammableButtonFeature_A19778.Value = 202;
      if (!paSiren.RadErgoWidePASirenHiLoAirhornTones_A8200.Value)
        (embeddedRecset[27] as SignalIndependentProductIndependentNonProgrammableButtonListInner).SignalIndependentProductIndependentNonProgrammableButtonListInnerSection.RadErgoCfgSignalIndependentProductIndependentNonProgrammableButtonFeature_A19778.Value = 203;
      (embeddedRecset[28] as SignalIndependentProductIndependentNonProgrammableButtonListInner).SignalIndependentProductIndependentNonProgrammableButtonListInnerSection.RadErgoCfgSignalIndependentProductIndependentNonProgrammableButtonFeature_A19778.Value = 201;
    }
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
      SignalIndependentProductIndependentNonProgrammableButtonListInner programmableButtonListInner1 = embeddedRecset1[24] as SignalIndependentProductIndependentNonProgrammableButtonListInner;
      (embeddedRecset2[0] as PASirenButtonsListInner).PASirenButtonsListInnerSection.CHO9PASirenButtonsFeature_A41540.SetValue(programmableButtonListInner1.SignalIndependentProductIndependentNonProgrammableButtonListInnerSection.RadErgoCfgSignalIndependentProductIndependentNonProgrammableButtonFeature_A19778.Value);
      SignalIndependentProductIndependentNonProgrammableButtonListInner programmableButtonListInner2 = embeddedRecset1[25] as SignalIndependentProductIndependentNonProgrammableButtonListInner;
      (embeddedRecset2[1] as PASirenButtonsListInner).PASirenButtonsListInnerSection.CHO9PASirenButtonsFeature_A41540.SetValue(programmableButtonListInner2.SignalIndependentProductIndependentNonProgrammableButtonListInnerSection.RadErgoCfgSignalIndependentProductIndependentNonProgrammableButtonFeature_A19778.Value);
      SignalIndependentProductIndependentNonProgrammableButtonListInner programmableButtonListInner3 = embeddedRecset1[28] as SignalIndependentProductIndependentNonProgrammableButtonListInner;
      (embeddedRecset2[2] as PASirenButtonsListInner).PASirenButtonsListInnerSection.CHO9PASirenButtonsFeature_A41540.SetValue(programmableButtonListInner3.SignalIndependentProductIndependentNonProgrammableButtonListInnerSection.RadErgoCfgSignalIndependentProductIndependentNonProgrammableButtonFeature_A19778.Value);
      SignalIndependentProductIndependentNonProgrammableButtonListInner programmableButtonListInner4 = embeddedRecset1[26] as SignalIndependentProductIndependentNonProgrammableButtonListInner;
      (embeddedRecset2[3] as PASirenButtonsListInner).PASirenButtonsListInnerSection.CHO9PASirenButtonsFeature_A41540.SetValue(programmableButtonListInner4.SignalIndependentProductIndependentNonProgrammableButtonListInnerSection.RadErgoCfgSignalIndependentProductIndependentNonProgrammableButtonFeature_A19778.Value);
      SignalIndependentProductIndependentNonProgrammableButtonListInner programmableButtonListInner5 = embeddedRecset1[27] as SignalIndependentProductIndependentNonProgrammableButtonListInner;
      (embeddedRecset2[4] as PASirenButtonsListInner).PASirenButtonsListInnerSection.CHO9PASirenButtonsFeature_A41540.SetValue(programmableButtonListInner5.SignalIndependentProductIndependentNonProgrammableButtonListInnerSection.RadErgoCfgSignalIndependentProductIndependentNonProgrammableButtonFeature_A19778.Value);
      SignalIndependentProductIndependentNonProgrammableButtonListInner programmableButtonListInner6 = embeddedRecset1[29] as SignalIndependentProductIndependentNonProgrammableButtonListInner;
      (embeddedRecset2[5] as PASirenButtonsListInner).PASirenButtonsListInnerSection.CHO9PASirenButtonsFeature_A41540.SetValue(programmableButtonListInner6.SignalIndependentProductIndependentNonProgrammableButtonListInnerSection.RadErgoCfgSignalIndependentProductIndependentNonProgrammableButtonFeature_A19778.Value);
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

  private void ShepherdsInitForFob()
  {
    if (!UtilityMack.IsPortable() || !(FeatureManager.GetFeature(2013) is ShepherdsRecset feature))
      return;
    if (feature[0][10035].EmbeddedRecset is ConventionalShepherdListInnerRecset embeddedRecset1)
    {
      while (embeddedRecset1.Count < 4)
        embeddedRecset1.AddRecord(embeddedRecset1.CreateDefaultRecord());
      if (embeddedRecset1[3][10036] is ConventionalShepherdListInnerSection listInnerSection)
        listInnerSection.RadErgoCfgCnvBtnListType_A21164.SetValue(1148);
    }
    if (feature[0][10037].EmbeddedRecset is TrunkingShepherdListInnerRecset embeddedRecset2)
    {
      while (embeddedRecset2.Count < 4)
        embeddedRecset2.AddRecord(embeddedRecset2.CreateDefaultRecord());
      if (embeddedRecset2[3][10038] is TrunkingShepherdListInnerSection listInnerSection)
        listInnerSection.RadErgoCfgTrkBtnListType_A21167.SetValue(1149);
    }
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
      if (!flag4)
        ;
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
      if (!flag10)
        ;
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
    if (programmableButtonListInner2 != null)
    {
      programmableButtonListInner2.SignalIndependentProductIndependentNonProgrammableButtonListInnerSection.RadErgoCfgSignalIndependentProductIndependentNonProgrammableButtonBCO_A19777.SetValue(91);
      programmableButtonListInner2.SignalIndependentProductIndependentNonProgrammableButtonListInnerSection.RadErgoCfgSignalIndependentProductIndependentNonProgrammableButtonFeature_A19778.SetValue(38);
    }
  }

  private void O2TableInit_For_CustomViewInit()
  {
    if (!(AppInfoManager.DefaultDocument.GetFeature(4115) is ControlHeadO2Recset feature))
      return;
    if (feature[0][10721].EmbeddedRecset is O2MFKAssignmentControlInnerRecset embeddedRecset1 && embeddedRecset1.Count < 2)
    {
      while (embeddedRecset1.Count < 2)
        embeddedRecset1.AddRecord(embeddedRecset1.CreateDefaultRecord());
    }
    if (feature[0][10722].EmbeddedRecset is O2NavigationControlsTableInnerRecset embeddedRecset2 && embeddedRecset2.Count < 2)
    {
      while (embeddedRecset2.Count < 2)
        embeddedRecset2.AddRecord(embeddedRecset2.CreateDefaultRecord());
    }
  }

  private void O7TableInit_For_CustomViewInit()
  {
    if (AppInfoManager.DefaultDocument.GetFeature(4114) is ControlHeadO7Recset feature && feature[0][10718].EmbeddedRecset is O7MFKAssignmentControlInnerRecset embeddedRecset1 && embeddedRecset1.Count < 2)
    {
      while (embeddedRecset1.Count < 2)
        embeddedRecset1.AddRecord(embeddedRecset1.CreateDefaultRecord());
    }
    if (!(feature[0][10727].EmbeddedRecset is O7NavigationControlsTableInnerRecset embeddedRecset2) || embeddedRecset2.Count >= 2)
      return;
    while (embeddedRecset2.Count < 2)
      embeddedRecset2.AddRecord(embeddedRecset2.CreateDefaultRecord());
  }

  private void O3TableInit_For_CustomViewInit()
  {
    if (AppInfoManager.DefaultDocument.GetFeature(2127) is ControlHeadO3Recset feature && feature[0][10235].EmbeddedRecset is O3HHCHButtonInnerRecset embeddedRecset1)
    {
      while (embeddedRecset1.Count < 5)
        embeddedRecset1.AddRecord(embeddedRecset1.CreateDefaultRecord());
    }
    if (feature == null || !(feature[0][10732].EmbeddedRecset is O3NavigationControlsTableInnerRecset embeddedRecset2) || embeddedRecset2.Count >= 2)
      return;
    while (embeddedRecset2.Count < 2)
      embeddedRecset2.AddRecord(embeddedRecset2.CreateDefaultRecord());
  }

  private void O5TableInit_For_CustomViewInit()
  {
    if (!(AppInfoManager.DefaultDocument.GetFeature(2130) is ControlHeadO5Recset feature) || !(feature[0][10735].EmbeddedRecset is O5NavigationControlsTableInnerRecset embeddedRecset) || embeddedRecset.Count >= 2)
      return;
    while (embeddedRecset.Count < 2)
      embeddedRecset.AddRecord(embeddedRecset.CreateDefaultRecord());
  }

  private void KMATableInit_For_CustomViewInit()
  {
    if (!(AppInfoManager.DefaultDocument.GetFeature(2128) is KeypadMicAndAccessoriesRecset feature) || !(feature[0][10753].EmbeddedRecset is KMANavigationControlsTableInnerRecset embeddedRecset) || embeddedRecset.Count >= 2)
      return;
    while (embeddedRecset.Count < 2)
      embeddedRecset.AddRecord(embeddedRecset.CreateDefaultRecord());
  }

  private void O9TableInit_For_CustomViewInit()
  {
    if (AppInfoManager.DefaultDocument.GetFeature(4003) is ControlHeadO9Recset feature1)
    {
      BottomFunctionProgrammableButtonInnerRecset embeddedRecset1 = feature1[0][10618].EmbeddedRecset as BottomFunctionProgrammableButtonInnerRecset;
      BottomFunctionButtonBCOListInnerRecset embeddedRecset2 = feature1[0][10628].EmbeddedRecset as BottomFunctionButtonBCOListInnerRecset;
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
    if (AppInfoManager.DefaultDocument.GetFeature(4003) is ControlHeadO9Recset feature2 && feature2[0][10616].EmbeddedRecset is TopFunctionProgrammableButtonListInnerRecset embeddedRecset4 && embeddedRecset4.Count < 5)
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

  private void SmartKeyFobsTableInit_For_CustomViewInit()
  {
    if (!(AppInfoManager.DefaultDocument.GetFeature(4130) is SmartKeyFobRecset feature) || !(feature[0][10747].EmbeddedRecset is SmartKeyFobButtonTableInnerRecset embeddedRecset) || embeddedRecset.Count >= 6)
      return;
    while (embeddedRecset.Count < 6)
      embeddedRecset.AddRecord(embeddedRecset.CreateDefaultRecord());
  }

  private void KeypadMicAndAccessoriesTableInit_For_CustomViewInit()
  {
    if (AppInfoManager.DefaultDocument.GetFeature(2128) is KeypadMicAndAccessoriesRecset feature1 && feature1[0][10231].EmbeddedRecset is KMButtonInnerRecset embeddedRecset1 && embeddedRecset1.Count < 3)
    {
      while (embeddedRecset1.Count < 3)
        embeddedRecset1.AddRecord(embeddedRecset1.CreateDefaultRecord());
    }
    if (AppInfoManager.DefaultDocument.GetFeature(2128) is KeypadMicAndAccessoriesRecset feature2 && feature2[0][10753].EmbeddedRecset is KMANavigationControlsTableInnerRecset embeddedRecset2 && embeddedRecset2.Count < 2)
    {
      while (embeddedRecset2.Count < 2)
        embeddedRecset2.AddRecord(embeddedRecset2.CreateDefaultRecord());
    }
    if (!(AppInfoManager.DefaultDocument.GetFeature(2128) is KeypadMicAndAccessoriesRecset feature3) || !(feature3[0][10228].EmbeddedRecset is Motorola.MackinawCPS.CoreFeatures.KeypadMicAndAccessories.DataButtonInnerRecset embeddedRecset3) || embeddedRecset3.Count >= 1)
      return;
    while (embeddedRecset3.Count < 1)
      embeddedRecset3.AddRecord(embeddedRecset3.CreateDefaultRecord());
  }

  private void KeypadTableInit_For_CustomViewInit()
  {
    if (!(AppInfoManager.DefaultDocument.GetFeature(4109) is KeypadRecset feature) || !(feature[0][10710].EmbeddedRecset is KeypadButtonInnerRecset embeddedRecset) || embeddedRecset.Count >= 12)
      return;
    while (embeddedRecset.Count < 12)
      embeddedRecset.AddRecord(embeddedRecset.CreateDefaultRecord());
  }

  private void DEKTableInit_For_CustomViewInit()
  {
    if (!(AppInfoManager.DefaultDocument.GetFeature(2129) is DEKRecset feature) || !(feature[0][10232].EmbeddedRecset is DEKButtonInnerRecset embeddedRecset) || embeddedRecset.Count >= 24)
      return;
    while (embeddedRecset.Count < 24)
      embeddedRecset.AddRecord(embeddedRecset.CreateDefaultRecord());
  }

  private void SetAudioSettingGroupSettingValueToCustom()
  {
    if (this.GetCodeplugMainVersion() >= 13 && (this.GetCodeplugMainVersion() != 13 || this.GetCodeplugMiddleVersion() >= 1) || !(FeatureManager.GetFeature(2077) is RadioProfilesRecset feature))
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
    if (this.GetCodeplugMainVersion() >= 13 && (this.GetCodeplugMainVersion() != 13 || this.GetCodeplugMiddleVersion() >= 1) || !(FeatureManager.GetFeature(2077) is RadioProfilesRecset feature))
      return;
    foreach (IAcpFeatureNode acpFeatureNode in (Collection<AcpBusinessLayer.FeatureNode>) feature)
    {
      AudioSettings audioSettings = (AudioSettings) null;
      LabtoolRAD_PROF_CDA labtoolRadProfCda = (LabtoolRAD_PROF_CDA) null;
      foreach (IAcpFeatureSection featureSections in acpFeatureNode.FeatureSectionsCollection)
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

  private void SetStatusAutoExitToAlwaysAndUpdateConStatusAliasNumber()
  {
    if (!UtilityMack.IsPortablePro || this.GetCodeplugMainVersion() >= 12 && (this.GetCodeplugMainVersion() != 12 || this.GetCodeplugMiddleVersion() >= 1) || !(FeatureManager.GetFeature(2033)[0] is Motorola.MackinawCPS.CoreFeatures.RadioErgonomicsWide.RadioErgonomicsWide radioErgonomicsWide) || !radioErgonomicsWide.HomeMode.RadErgoWideHomeModeHomeModeSelection_A8202.HiddenStatic)
      return;
    if (FeatureManager.GetFeature(2010)[0] is Motorola.MackinawCPS.CoreFeatures.DisplayAndMenu.DisplayAndMenu displayAndMenu)
      displayAndMenu.Advanced.RadioErgDispAdvanceStatusAutoExit_42158.SetValue(1);
    if (FeatureManager.GetFeature(2007)[0] is Motorola.MackinawCPS.CoreFeatures.ConventionalAliasLists.ConventionalAliasLists conventionalAliasLists && conventionalAliasLists.StatusAliasList.EmbeddedRecset is StatusAliasTableInnerRecset embeddedRecset)
    {
      int num = 1;
      foreach (IAcpFeatureNode acpFeatureNode in (Collection<AcpBusinessLayer.FeatureNode>) embeddedRecset)
      {
        if (acpFeatureNode is StatusAliasTableInner statusAliasTableInner)
          statusAliasTableInner.StatusAliasTableInnerSection.CnvAlsLstStatusAliasListStatusAliasNumber_A9191.SetValue(num++);
      }
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
    if (FeatureManager.GetFeature(4008) is ActionConsolidationRecset feature)
    {
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
  }

  public void SyncActiveMicForBTPTT()
  {
    if (!UtilityMack.IsPortable() || this.GetCodeplugMainVersion() >= 15)
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
    foreach (IAcpFeatureNode acpFeatureNode1 in (Collection<AcpBusinessLayer.FeatureNode>) acpRecordset)
    {
      foreach (IAcpFeatureNode acpFeatureNode2 in (Collection<AcpBusinessLayer.FeatureNode>) (acpFeatureNode1 as Motorola.MackinawCPS.CoreFeatures.ConventionalPersonality.ConventionalPersonality).FrequencyOptions.EmbeddedRecset)
      {
        FrequencyOptionsInnerSection optionsInnerSection = (acpFeatureNode2 as FrequencyOptionsInner).FrequencyOptionsInnerSection;
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
    if (flag)
    {
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
  }

  private void ResolvedMFKTimerUnpack()
  {
    int codeplugMainVersion = this.GetCodeplugMainVersion();
    if (codeplugMainVersion != 6 && codeplugMainVersion != 5)
      return;
    Motorola.MackinawCPS.CoreFeatures.RadioErgonomicsWide.RadioErgonomicsWide radioErgonomicsWide = FeatureManager.GetFeature(2033)[0] as Motorola.MackinawCPS.CoreFeatures.RadioErgonomicsWide.RadioErgonomicsWide;
    if (radioErgonomicsWide.Advanced.RadErgoWideAdvancedLongKeypressDurationforMFK_A38506.Value == 0)
      radioErgonomicsWide.Advanced.RadErgoWideAdvancedLongKeypressDurationforMFK_A38506.ResetToDefault();
    if (radioErgonomicsWide.Advanced.RadErgoWideAdvancedMFKInactivityTimeout_A38507.Value == 0)
      radioErgonomicsWide.Advanced.RadErgoWideAdvancedMFKInactivityTimeout_A38507.ResetToDefault();
    if (radioErgonomicsWide.Advanced.RadErgoWideAdvancedShortKeypressDurationforMFK_A38505.Value == 0)
      radioErgonomicsWide.Advanced.RadErgoWideAdvancedShortKeypressDurationforMFK_A38505.ResetToDefault();
  }

  private void DataProfileTrunkingGroupIDFixup()
  {
    int codeplugMainVersion = this.GetCodeplugMainVersion();
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
          if (groupIdListInner != null && codeplugMainVersion <= 2 && groupIdListInner.TrunkingGroupIDListInnerSection.DataProfilesTrunkingGroupID_ASTRO25DataGroupID_A36204Value == groupIdListInner.TrunkingGroupIDListInnerSection.DataProfilesTrunkingGroupID_ASTRO25DataGroupID_A36204.DefaultValue)
            groupIdListInner.TrunkingGroupIDListInnerSection.DataProfilesTrunkingGroupID_ASTRO25DataGroupID_A36204.SetValue(groupIdListInner.TrunkingGroupIDListInnerSection.DataProfilesTrunkingGroupID_ASTRO25DataGroupID_A36204.DefaultValue + index2);
        }
      }
    }
  }

  private void ToneSignalingListToneAliasFixup()
  {
    if (this.GetCodeplugMainVersion() >= 14)
      return;
    foreach (IAcpFeatureNode acpFeatureNode1 in (Collection<AcpBusinessLayer.FeatureNode>) (FeatureManager.GetFeature(4156) as ToneSignalingListRecset))
    {
      if (acpFeatureNode1 is Motorola.MackinawCPS.CoreFeatures.ToneSignalingList.ToneSignalingList toneSignalingList && toneSignalingList.AstroAlertingToneListExpander != null && toneSignalingList.AstroAlertingToneListExpander.EmbeddedRecset != null && toneSignalingList.AstroAlertingToneListExpander.EmbeddedRecset is AstroAlertingToneTableInnerRecset embeddedRecset)
      {
        int num = 1;
        foreach (IAcpFeatureNode acpFeatureNode2 in (Collection<AcpBusinessLayer.FeatureNode>) embeddedRecset)
        {
          (acpFeatureNode2 as AstroAlertingToneTableInner).AstroAlertingToneTableInnerSection.RadErgoAstroAlertingToneTableToneAliasText_42533.SetValue($"Tone Alias {num}");
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
    if (bandingFrequencySplit.EmbeddedRecset is FCCNarrowBandingFrequencySplitInnerRecset embeddedRecset)
    {
      bool flag2 = false;
      if (embeddedRecset.Count < 3)
        flag2 = true;
      while (embeddedRecset.Count < 3)
        embeddedRecset.AddRecord(embeddedRecset.CreateDefaultRecord());
      if (flag2 || flag1)
      {
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
    }
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
      if (str != null && str.Length > 3)
      {
        if (int.Parse(str.Substring(1, 2)) < 8 && (num == 6 || num == 5))
        {
          TxPowerLevelsByFrequencyRangeInnerSection rangeInnerSection = embeddedRecset[0][10104] as TxPowerLevelsByFrequencyRangeInnerSection;
          rangeInnerSection.RadWideTransmitPowerLevelsTxPowerLevelHighW_A8152.SetValue(37404);
          rangeInnerSection.RadWideTransmitPowerLevelsTxPowerLevelMaximumW_A20039.SetValue(37404);
        }
      }
    }
    catch
    {
    }
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
      if (flag1 && flag2)
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
                break;
              case 14:
                this.SetTransmitPowerLevels(txPowerLevel, 30000, 42175, 45185, 45185);
                break;
              case 15:
                this.SetTransmitPowerLevels(txPowerLevel, 30000, 33010, 35441, 35441);
                break;
              case 16 /*0x10*/:
                this.SetTransmitPowerLevels(txPowerLevel, 30000, 42175, 45185, 45185);
                break;
              case 17:
                this.SetTransmitPowerLevels(txPowerLevel, 30000, 33010, 35441, 35441);
                break;
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
                break;
              case 14:
                this.SetTransmitPowerLevels(txPowerLevel, 30000, 42175, 45185, 45185);
                break;
              case 15:
                this.SetTransmitPowerLevels(txPowerLevel, 30000, 33010, 35441, 35441);
                break;
              case 16 /*0x10*/:
                this.SetTransmitPowerLevels(txPowerLevel, 30000, 42175, 45185, 45185);
                break;
              case 17:
                this.SetTransmitPowerLevels(txPowerLevel, 30000, 33010, 35441, 35441);
                break;
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
                break;
              case 14:
                this.SetTransmitPowerLevels(txPowerLevel, 30000, 42175, 45185, 45185);
                break;
              case 15:
                this.SetTransmitPowerLevels(txPowerLevel, 30000, 33010, 35441, 35441);
                break;
              case 16 /*0x10*/:
                this.SetTransmitPowerLevels(txPowerLevel, 30000, 42175, 45185, 45185);
                break;
              case 17:
                this.SetTransmitPowerLevels(txPowerLevel, 30000, 33010, 35441, 35441);
                break;
            }
          }
          else if (labtool.RadInfoLabtoolPrimaryBands_A23987.Value == 1 && labtool.RadInfoLabtoolSecondaryBands_A23988.Value == 0 || labtool.RadInfoLabtoolPrimaryBands_A23987.Value == 1 && labtool.RadInfoLabtoolSecondaryBands_A23988.Value == 2 || labtool.RadInfoLabtoolPrimaryBands_A23987.Value == 2 || labtool.RadInfoLabtoolPrimaryBands_A23987.Value == 4 || labtool.RadInfoLabtoolPrimaryBands_A23987.Value == 8)
          {
            switch (index)
            {
              case 10:
                this.SetTransmitPowerLevels(txPowerLevel, 36021, 43424, 46435, 46435);
                break;
              case 11:
                this.SetTransmitPowerLevels(txPowerLevel, 36021, 43979, 46946, 46946);
                break;
              case 12:
                this.SetTransmitPowerLevels(txPowerLevel, 36021, 43424, 46435, 46435);
                break;
              case 13:
                this.SetTransmitPowerLevels(txPowerLevel, 36021, 41461, 44393, 44393);
                break;
              case 14:
                this.SetTransmitPowerLevels(txPowerLevel, 30000, 42175, 45185, 45185);
                break;
              case 15:
                this.SetTransmitPowerLevels(txPowerLevel, 30000, 33010, 35441, 35441);
                break;
              case 16 /*0x10*/:
                this.SetTransmitPowerLevels(txPowerLevel, 30000, 42175, 45185, 45185);
                break;
              case 17:
                this.SetTransmitPowerLevels(txPowerLevel, 30000, 33010, 35441, 35441);
                break;
            }
          }
          else if (labtool.RadInfoLabtoolPrimaryBands_A23987.Value == 1 && labtool.RadInfoLabtoolSecondaryBands_A23988.Value == 3 || labtool.RadInfoLabtoolPrimaryBands_A23987.Value == 3 || labtool.RadInfoLabtoolPrimaryBands_A23987.Value == 5)
          {
            switch (index)
            {
              case 10:
                this.SetTransmitPowerLevels(txPowerLevel, 43979, 47404, 50414, 50414);
                break;
              case 11:
                this.SetTransmitPowerLevels(txPowerLevel, 36021, 43979, 46946, 46946);
                break;
              case 12:
                this.SetTransmitPowerLevels(txPowerLevel, 36021, 43424, 46435, 46435);
                break;
              case 13:
                this.SetTransmitPowerLevels(txPowerLevel, 36021, 41461, 44393, 44393);
                break;
              case 14:
                this.SetTransmitPowerLevels(txPowerLevel, 30000, 42175, 45185, 45185);
                break;
              case 15:
                this.SetTransmitPowerLevels(txPowerLevel, 30000, 33010, 35441, 35441);
                break;
              case 16 /*0x10*/:
                this.SetTransmitPowerLevels(txPowerLevel, 30000, 42175, 45185, 45185);
                break;
              case 17:
                this.SetTransmitPowerLevels(txPowerLevel, 30000, 33010, 35441, 35441);
                break;
            }
          }
        }
      }
    }
    try
    {
      int num1 = (FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation).Labtool.RadInfoLabtoolProductModelIdentifier_A37178.Value;
      int num2;
      switch (num1)
      {
        case 14:
        case 15:
          num2 = 0;
          break;
        default:
          num2 = num1 != 17 ? 1 : 0;
          break;
      }
      if (num2 == 0)
      {
        (embeddedRecset[10][10104] as TxPowerLevelsByFrequencyRangeInnerSection).RadWideTransmitPowerLevelsTxPowerLevelMinimumW_A20038.SetValue(30000);
        (embeddedRecset[11][10104] as TxPowerLevelsByFrequencyRangeInnerSection).RadWideTransmitPowerLevelsTxPowerLevelMinimumW_A20038.SetValue(30000);
        (embeddedRecset[12][10104] as TxPowerLevelsByFrequencyRangeInnerSection).RadWideTransmitPowerLevelsTxPowerLevelMinimumW_A20038.SetValue(30000);
        (embeddedRecset[13][10104] as TxPowerLevelsByFrequencyRangeInnerSection).RadWideTransmitPowerLevelsTxPowerLevelMinimumW_A20038.SetValue(30000);
      }
    }
    catch
    {
    }
    try
    {
      int num3 = (FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation).Labtool.RadInfoLabtoolProductModelIdentifier_A37178.Value;
      int num4;
      switch (num3)
      {
        case 14:
        case 15:
        case 17:
          num4 = 0;
          break;
        default:
          num4 = num3 != 22 ? 1 : 0;
          break;
      }
      if (num4 != 0)
        return;
      (embeddedRecset[10][10104] as TxPowerLevelsByFrequencyRangeInnerSection).RadWideTransmitPowerLevelsTxPowerLevelMinimumW_A20038.SetValue(30000);
      (embeddedRecset[11][10104] as TxPowerLevelsByFrequencyRangeInnerSection).RadWideTransmitPowerLevelsTxPowerLevelMinimumW_A20038.SetValue(30000);
      (embeddedRecset[12][10104] as TxPowerLevelsByFrequencyRangeInnerSection).RadWideTransmitPowerLevelsTxPowerLevelMinimumW_A20038.SetValue(30000);
      (embeddedRecset[13][10104] as TxPowerLevelsByFrequencyRangeInnerSection).RadWideTransmitPowerLevelsTxPowerLevelMinimumW_A20038.SetValue(30000);
    }
    catch
    {
    }
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
    int codeplugMainVersion = this.GetCodeplugMainVersion();
    if (tps == null || codeplugMainVersion >= 9)
      return;
    tps.RadWideTPSFiregroundEmergencyAlarmRetryRatesec_A7929.Value = 4;
  }

  private int GetCodeplugMainVersion()
  {
    int codeplugMainVersion = 0;
    try
    {
      if (FeatureManager.GetFeature(2049)[0] is Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation radioInformation)
      {
        string versionA7683UiValue = radioInformation.General.RadInfoGeneralCodeplugVersion_A7683_UIValue;
        if (versionA7683UiValue.Length > 2)
          codeplugMainVersion = int.Parse(versionA7683UiValue.Substring(1, 2).ToString());
      }
    }
    catch
    {
    }
    return codeplugMainVersion;
  }

  private int GetCodeplugMiddleVersion()
  {
    int codeplugMiddleVersion = 0;
    try
    {
      if (FeatureManager.GetFeature(2049)[0] is Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation radioInformation)
      {
        string versionA7683UiValue = radioInformation.General.RadInfoGeneralCodeplugVersion_A7683_UIValue;
        if (versionA7683UiValue.Length > 5)
          codeplugMiddleVersion = int.Parse(versionA7683UiValue.Substring(4, 2).ToString());
      }
    }
    catch
    {
    }
    return codeplugMiddleVersion;
  }

  public void UclTemplateNodeInit()
  {
    bool flag = false;
    IAcpRecordset feature;
    switch (AppInfoManager.AppMode)
    {
      case ApplicationMode.CodeplugComparisonMode:
        flag = UndoManager.StopUndoRedo();
        feature = AppInfoManager.ComparatorDocument.GetFeature(2200);
        break;
      case ApplicationMode.CustomViewConfigurationMode:
        feature = AppInfoManager.DefaultDocument.GetFeature(2200);
        break;
      default:
        feature = FeatureManager.GetFeature(2200);
        break;
    }
    AcpBusinessLayer.FeatureNode templateNode = ((AcpBusinessLayer.Recordset) feature).TemplateNode;
    foreach (IAcpFeatureSection featureSections in templateNode.FeatureSectionsCollection)
    {
      if (featureSections.HasEmbeddedRecset)
      {
        AcpBusinessLayer.Recordset embeddedRecset = (AcpBusinessLayer.Recordset) featureSections.EmbeddedRecset;
        if (embeddedRecset.Count == 0)
        {
          embeddedRecset.AddRecord(embeddedRecset.CreateDefaultRecord());
          foreach (IAcpFeatureNode acpFeatureNode in (Collection<AcpBusinessLayer.FeatureNode>) embeddedRecset)
          {
            if (embeddedRecset.ParentSection.FeatureSectionId == 10401)
            {
              TrunkingCallListCallListSection listCallListSection = (TrunkingCallListCallListSection) acpFeatureNode[10402];
              listCallListSection.UclAstro25Trk_HomeSystemID_A00012Object.PointedField = (IAcpField) null;
              listCallListSection.UclAstro25Trk_WACNID_A00011Object.PointedField = (IAcpField) null;
            }
            else if (embeddedRecset.ParentSection.FeatureSectionId == 10411)
              ((TrunkingT2CallListCallListSection) acpFeatureNode[10412]).UclT2Trk_SystemID_A00018Object.PointedField = (IAcpField) null;
            else if (embeddedRecset.ParentSection.FeatureSectionId == 10403)
              ((AstroCallListCallListSection) acpFeatureNode[10404]).UclAstroCnv_SystemGroupNumber_A00023Object.PointedField = (IAcpField) null;
            else if (embeddedRecset.ParentSection.FeatureSectionId == 10405)
              ((MDCCallListCallListSection) acpFeatureNode[10406]).UclMDCCnv_SystemGroupNumber_A00029Object.PointedField = (IAcpField) null;
          }
        }
      }
    }
    templateNode.KeyField.Value = (string) null;
    if (!flag)
      return;
    UndoManager.StartUndoRedo();
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

  internal bool PromptQuitOnInvalids()
  {
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
        if (!str.Equals("R") && !str.Equals("B"))
          AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Warning, AppResources.The_following_orphaned_invisible_invalid_field + fieldsReportInfo.Field.Path("\\"));
        if (!fieldsReportInfo.Field.Valid)
          fieldsReportInfo.Field.ResetToDefault();
      }
    }
    if (flag)
      UndoManager.StartUndoRedo();
    if (AppInfoManager.InvalidFieldsReport.UiHasFields)
    {
      if (WindowMain.BlockPackOnInvalids.Enabled)
      {
        AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, AppResources.The_codeplug_contains_invalid_fields_Please_correct_them_and_try_again);
        return true;
      }
      if (!WindowMain.SuppressPackInvalidsPopup.Enabled)
        return System.Windows.MessageBox.Show(AppResources.Invalid_fields_found_in_archive, AppResources.Mackinaw_CPS, MessageBoxButton.YesNo, MessageBoxImage.Hand, MessageBoxResult.No) != MessageBoxResult.Yes;
    }
    if (AppInfoManager.InvalidFieldsReport.UiHasFields || !AppInfoManager.InvalidFieldsReport.HasFields || !WindowMain.BlockPackOnInvalids.Enabled)
      return false;
    AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, AppResources.The_Application_has_encountered_invalid_field_Please_contact_Motorola_Support_for_assistance);
    return true;
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
    if (acpListFieldList.Count > 0)
    {
      foreach (AcpFieldBase acpFieldBase in acpListFieldList)
        acpFieldBase.ResetToDefault();
    }
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
      if (FeatureManager.GetFeature(4003) is ControlHeadO9Recset feature2)
      {
        selectorListInnerRecset = feature2[0][10624].EmbeddedRecset as ResponseSelectorListInnerRecset;
        buttonsListInnerRecset = feature2[0][10609].EmbeddedRecset as DirectionalButtonsListInnerRecset;
        listListInnerRecset = feature2[0][10620].EmbeddedRecset as RelayPatternBCOListListInnerRecset;
      }
      if (selectorListInnerRecset != null)
      {
        foreach (IAcpFeatureNode acpFeatureNode in (Collection<AcpBusinessLayer.FeatureNode>) selectorListInnerRecset)
        {
          AcpRecRefField pursuitKnobIndexA36685 = (acpFeatureNode[10625] as ResponseSelectorListInnerSection).CHO9PursuitKnobIndex_A36685;
          if (pursuitKnobIndexA36685.HiddenStatic)
          {
            pursuitKnobIndexA36685.ResetToDefault();
            AppInfoManager.InvalidFieldsReport.UnregisterFieldInReport((IAcpField) pursuitKnobIndexA36685);
          }
          else
            break;
        }
      }
      if (buttonsListInnerRecset != null)
      {
        foreach (IAcpFeatureNode acpFeatureNode in (Collection<AcpBusinessLayer.FeatureNode>) buttonsListInnerRecset)
        {
          AcpRecRefField lightBarIndexA36601 = (acpFeatureNode[10610] as DirectionalButtonsListInnerSection).RadErgCtrlHeadO9DirLightBarIndex_A36601;
          if (lightBarIndexA36601.HiddenStatic && !lightBarIndexA36601.Valid)
          {
            lightBarIndexA36601.ResetToDefault();
            AppInfoManager.InvalidFieldsReport.UnregisterFieldInReport((IAcpField) lightBarIndexA36601);
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
    }
    catch (Exception ex)
    {
    }
  }

  private void hideADPKeyData()
  {
    IAcpRecordset feature = FeatureManager.GetFeature(2021);
    if (feature == null || feature.Count == 0)
      return;
    Motorola.MackinawCPS.CoreFeatures.SecureWide.SecureWide secureWide = feature[0] as Motorola.MackinawCPS.CoreFeatures.SecureWide.SecureWide;
    if (secureWide.EncryptionKeyList.EmbeddedRecset != null)
    {
      foreach (IAcpFeatureNode acpFeatureNode in (Collection<AcpBusinessLayer.FeatureNode>) secureWide.EncryptionKeyList.EmbeddedRecset)
      {
        EncryptionKeyListInnerSection listInnerSection = (acpFeatureNode as EncryptionKeyListInner).EncryptionKeyListInnerSection;
        if (listInnerSection.SecWideMultikeyListSelectableADPKeyData_A9106.Value != listInnerSection.SecWideMultikeyListSelectableADPKeyData_A9106.DefaultValue)
          listInnerSection.SecWideMultikeyListSelectableADPKeyData_A9106.Value = listInnerSection.SecWideMultikeyListSelectableADPKeyData_A9106.DefaultValue;
      }
    }
  }

  private void RefreshPowerLevelForSRX2200()
  {
    if (!this.MyModelNumber.Equals("H99QDD9PW5AN") && !this.MyModelNumber.Equals("H99KGD9PW5AN") && !this.MyModelNumber.Equals("H99UCD9PW5AN") && !this.MyModelNumber.Equals("H99QDH9PW7AN") && !this.MyModelNumber.Equals("H99KGH9PW7AN") && !this.MyModelNumber.Equals("H99UCH9PW7AN") || !(FeatureManager.GetFeature(2045)[0] is Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide radioWide) || radioWide.Labtool == null || radioWide.Labtool.RadWideLabtoolUltraLowPowerSoldierMacCapable_A41710 == null)
      return;
    if (radioWide.TransmitPowerLevels != null && radioWide.TransmitPowerLevels.EmbeddedRecset != null)
    {
      for (int index = 0; index < radioWide.TransmitPowerLevels.EmbeddedRecset.Count; ++index)
      {
        if (radioWide.TransmitPowerLevels.EmbeddedRecset[index] is TxPowerLevelsByFrequencyRangeInner frequencyRangeInner && frequencyRangeInner.TxPowerLevelsByFrequencyRangeInnerSection != null && (MTFResources.P_7800_mhz.Trim() == frequencyRangeInner.TxPowerLevelsByFrequencyRangeInnerSection.RadWidePowerLevelBandFrequency_A41063.Value.Trim() || AcgResources.ID_UHF1.Trim() == frequencyRangeInner.TxPowerLevelsByFrequencyRangeInnerSection.RadWidePowerLevelBandFrequency_A41063.Value.Trim() && !radioWide.Labtool.RadWideLabtoolUltraLowPowerSoldierMacCapable_A41710.Value))
          frequencyRangeInner.TxPowerLevelsByFrequencyRangeInnerSection.RadWideTransmitPowerLevelsTrkTxPowerLevelMinimumW_A41174.SetValue(23979);
      }
    }
    if (radioWide.TxPowerLevelsNewBandPlan != null && radioWide.TxPowerLevelsNewBandPlan.EmbeddedRecset != null)
    {
      for (int index = 0; index < radioWide.TxPowerLevelsNewBandPlan.EmbeddedRecset.Count; ++index)
      {
        if (radioWide.TxPowerLevelsNewBandPlan.EmbeddedRecset[index] is TxPowerLevelsByFrequencyRangeNewBandPlanInner newBandPlanInner && newBandPlanInner.TxPowerLevelsByFrequencyRangeNewBandPlanInnerSection != null && (MTFResources.P_7800_mhz.Trim() == newBandPlanInner.TxPowerLevelsByFrequencyRangeNewBandPlanInnerSection.RadWidePowerLevelBandFrequency_A41864.Value.Trim() || AcgResources.ID_UHF1.Trim() == newBandPlanInner.TxPowerLevelsByFrequencyRangeNewBandPlanInnerSection.RadWidePowerLevelBandFrequency_A41864.Value.Trim() && !radioWide.Labtool.RadWideLabtoolUltraLowPowerSoldierMacCapable_A41710.Value))
          newBandPlanInner.TxPowerLevelsByFrequencyRangeNewBandPlanInnerSection.RadWideTransmitPowerLevelsTrkTxPowerLevelMinimumW_A41862.SetValue(23979);
      }
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
          break;
        case 2:
          headAliasListInner.ControlHeadAliasListInnerSection.RadErgoWideControlHeadControlHead1Alias_A7718.SetValue(MTFResources.Control_head_2);
          break;
        case 3:
          headAliasListInner.ControlHeadAliasListInnerSection.RadErgoWideControlHeadControlHead1Alias_A7718.SetValue(MTFResources.Control_head_3);
          break;
        case 4:
          headAliasListInner.ControlHeadAliasListInnerSection.RadErgoWideControlHeadControlHead1Alias_A7718.SetValue(MTFResources.Control_head_4);
          break;
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
    this.RefreshActionConsolidation();
    this.RefreshToneSignalingList();
    this.FixPinPassword();
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
      ConsolidatedActionBCOListInnerRecset embeddedRecset9 = feature2[0][10622].EmbeddedRecset as ConsolidatedActionBCOListInnerRecset;
      BottomFunctionButtonBCOListInnerRecset embeddedRecset10 = feature2[0][10628].EmbeddedRecset as BottomFunctionButtonBCOListInnerRecset;
      O9InnerRecset embeddedRecset11 = feature2[0][10626].EmbeddedRecset as O9InnerRecset;
      O9DataButtonInnerRecset embeddedRecset12 = feature2[0][10611].EmbeddedRecset as O9DataButtonInnerRecset;
      O5InnerRecset embeddedRecset13 = (FeatureManager.GetFeature(2130) as ControlHeadO5Recset)[0][10227].EmbeddedRecset as O5InnerRecset;
      Motorola.MackinawCPS.CoreFeatures.Buttons.DataButtonInnerRecset embeddedRecset14 = (FeatureManager.GetFeature(2042) as ButtonsRecset)[0][10089].EmbeddedRecset as Motorola.MackinawCPS.CoreFeatures.Buttons.DataButtonInnerRecset;
      O9Inner o9Inner = embeddedRecset11[0] as O9Inner;
      O9DataButtonInner o9DataButtonInner = embeddedRecset12[0] as O9DataButtonInner;
      O5Inner o5Inner = embeddedRecset13[0] as O5Inner;
      Motorola.MackinawCPS.CoreFeatures.Buttons.DataButtonInner dataButtonInner = embeddedRecset14[0] as Motorola.MackinawCPS.CoreFeatures.Buttons.DataButtonInner;
      o9Inner.O9InnerSection.CHO9EmergencyButtonFeature_A36682.SetValue(o5Inner.O5InnerSection.CntrlHeadO5SignalIndependentO5M5MXChiefCHButtonButtonFeature_A19754.Value);
      o9DataButtonInner.O9DataButtonInnerSection.RadErgCtrlHeadO9DataButtonCnvFeature_A36528.SetValue(dataButtonInner.DataButtonInnerSection.BtnConventionalButtonDatatButtonFeature_A22610.Value);
      o9DataButtonInner.O9DataButtonInnerSection.RadErgCtrlHeadO9DataButtonTrkFeature_A36526.SetValue(dataButtonInner.DataButtonInnerSection.BtnTrunkingButtonDatatButtonFeature_A22608.Value);
      int count6 = embeddedRecset9.Count;
      for (int index = 0; index < count6; ++index)
      {
        ConsolidatedActionBCOListInnerSection listInnerSection = (embeddedRecset9[index] as ConsolidatedActionBCOListInner).ConsolidatedActionBCOListInnerSection;
        foreach (TopFunctionProgrammableButtonListInner programmableButtonListInner in (Collection<AcpBusinessLayer.FeatureNode>) embeddedRecset5)
        {
          if (programmableButtonListInner.TopFunctionProgrammableButtonListInnerSection.CnvTopFunctionButtonBCO_A36628.Value == listInnerSection.RadErgoControlO9ACBCOListBco_A36666.Value)
          {
            programmableButtonListInner.TopFunctionProgrammableButtonListInnerSection.O9CHCnvTopFunctionButtonIndex_A36634.UIValue = listInnerSection.RadErgoControlO9ACBCOListIndex_A36668.UIValue;
            programmableButtonListInner.TopFunctionProgrammableButtonListInnerSection.O9CHTrkTopFunctionButtonIndex_A36639.SetValue(listInnerSection.RadErgoControlO9ACBCOListIndex_A36668.Value);
            break;
          }
        }
        foreach (BottomFunctionProgrammableButtonInner programmableButtonInner in (Collection<AcpBusinessLayer.FeatureNode>) embeddedRecset8)
        {
          if (programmableButtonInner.BottomFunctionProgrammableButtonInnerSection.CHO9BottomFunctionButtonBCO_A36660.Value == listInnerSection.RadErgoControlO9ACBCOListBco_A36666.Value)
          {
            programmableButtonInner.BottomFunctionProgrammableButtonInnerSection.CHO9BottomFunctionButtonIndex_A36665.UIValue = listInnerSection.RadErgoControlO9ACBCOListIndex_A36668.UIValue;
            break;
          }
        }
      }
      RelayPatternBCOListListInnerRecset embeddedRecset15 = feature2[0][10620].EmbeddedRecset as RelayPatternBCOListListInnerRecset;
      DirectionalButtonsListInnerRecset embeddedRecset16 = feature2[0][10609].EmbeddedRecset as DirectionalButtonsListInnerRecset;
      int count7 = embeddedRecset15.Count;
      for (int index = 0; index < count7; ++index)
      {
        RelayPatternBCOListListInnerSection listInnerSection = (embeddedRecset15[index] as RelayPatternBCOListListInner).RelayPatternBCOListListInnerSection;
        foreach (TopFunctionProgrammableButtonListInner programmableButtonListInner in (Collection<AcpBusinessLayer.FeatureNode>) embeddedRecset5)
        {
          if (programmableButtonListInner.TopFunctionProgrammableButtonListInnerSection.CnvTopFunctionButtonBCO_A36628.Value == listInnerSection.RdEgoO9DirLtbarPatternBcoListBco_A36661.Value)
          {
            programmableButtonListInner.TopFunctionProgrammableButtonListInnerSection.O9CHCnvTopFunctionButtonIndex_A36634.UIValue = listInnerSection.RdEgoO9DirLtbarPatternBcoListIndex_A36707.UIValue;
            programmableButtonListInner.TopFunctionProgrammableButtonListInnerSection.O9CHTrkTopFunctionButtonIndex_A36639.SetValue(listInnerSection.RdEgoO9DirLtbarPatternBcoListIndex_A36707.Value);
            break;
          }
        }
        foreach (BottomFunctionProgrammableButtonInner programmableButtonInner in (Collection<AcpBusinessLayer.FeatureNode>) embeddedRecset8)
        {
          if (programmableButtonInner.BottomFunctionProgrammableButtonInnerSection.CHO9BottomFunctionButtonBCO_A36660.Value == listInnerSection.RdEgoO9DirLtbarPatternBcoListBco_A36661.Value)
          {
            programmableButtonInner.BottomFunctionProgrammableButtonInnerSection.CHO9BottomFunctionButtonIndex_A36665.UIValue = listInnerSection.RdEgoO9DirLtbarPatternBcoListIndex_A36707.UIValue;
            break;
          }
        }
        foreach (DirectionalButtonsListInner buttonsListInner in (Collection<AcpBusinessLayer.FeatureNode>) embeddedRecset16)
        {
          if (buttonsListInner.DirectionalButtonsListInnerSection.RadErgCtrlHeadO9DirLightBarBCO_A36559.Value == listInnerSection.RdEgoO9DirLtbarPatternBcoListBco_A36661.Value)
          {
            buttonsListInner.DirectionalButtonsListInnerSection.RadErgCtrlHeadO9DirLightBarIndex_A36601.UIValue = listInnerSection.RdEgoO9DirLtbarPatternBcoListIndex_A36707.UIValue;
            break;
          }
        }
        foreach (KeypadButtonInner keypadButtonInner in (Collection<AcpBusinessLayer.FeatureNode>) ((FeatureManager.GetFeature(4109) as KeypadRecset)[0][10710].EmbeddedRecset as KeypadButtonInnerRecset))
        {
          if (keypadButtonInner.KeypadButtonInnerSection.RadErgCtrlKeypadGeneralKeypadBCO_A41070.Value == listInnerSection.RdEgoO9DirLtbarPatternBcoListBco_A36661.Value)
          {
            keypadButtonInner.KeypadButtonInnerSection.RadErgCtrlKeypadGeneralKeypadButtonIndex_41415.UIValue = listInnerSection.RdEgoO9DirLtbarPatternBcoListIndex_A36707.UIValue;
            break;
          }
        }
      }
      DirectModeBCOListInnerRecset embeddedRecset17 = feature1[0][10220].EmbeddedRecset as DirectModeBCOListInnerRecset;
      int count8 = embeddedRecset17.Count;
      for (int index = 0; index < count8; ++index)
      {
        DirectModeBCOListInnerSection listInnerSection = (embeddedRecset17[index] as DirectModeBCOListInner).DirectModeBCOListInnerSection;
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
    Motorola.MackinawCPS.CoreFeatures.Buttons.DataButtonInnerRecset embeddedRecset18 = (FeatureManager.GetFeature(2042) as ButtonsRecset)[0][10089].EmbeddedRecset as Motorola.MackinawCPS.CoreFeatures.Buttons.DataButtonInnerRecset;
    Motorola.MackinawCPS.CoreFeatures.ControlHeadO3.DataButtonInnerRecset embeddedRecset19 = (FeatureManager.GetFeature(2127) as ControlHeadO3Recset)[0][10234].EmbeddedRecset as Motorola.MackinawCPS.CoreFeatures.ControlHeadO3.DataButtonInnerRecset;
    Motorola.MackinawCPS.CoreFeatures.KeypadMicAndAccessories.DataButtonInnerRecset embeddedRecset20 = (FeatureManager.GetFeature(2128) as KeypadMicAndAccessoriesRecset)[0][10228].EmbeddedRecset as Motorola.MackinawCPS.CoreFeatures.KeypadMicAndAccessories.DataButtonInnerRecset;
    Motorola.MackinawCPS.CoreFeatures.Buttons.DataButtonInnerSection buttonInnerSection1 = embeddedRecset18[0][10090] as Motorola.MackinawCPS.CoreFeatures.Buttons.DataButtonInnerSection;
    Motorola.MackinawCPS.CoreFeatures.ControlHeadO3.DataButtonInnerSection buttonInnerSection2 = embeddedRecset19[0][10212] as Motorola.MackinawCPS.CoreFeatures.ControlHeadO3.DataButtonInnerSection;
    Motorola.MackinawCPS.CoreFeatures.KeypadMicAndAccessories.DataButtonInnerSection buttonInnerSection3 = embeddedRecset20[0][10209] as Motorola.MackinawCPS.CoreFeatures.KeypadMicAndAccessories.DataButtonInnerSection;
    buttonInnerSection2.CntrlHeadO3ConventionalO3DatatButtonFeature_A22595.SetValue(buttonInnerSection1.BtnConventionalButtonDatatButtonFeature_A22610.Value);
    buttonInnerSection2.CntrlHeadO3TrunkingO3DatatButtonFeature_A22597.SetValue(buttonInnerSection1.BtnTrunkingButtonDatatButtonFeature_A22608.Value);
    buttonInnerSection3.RadErgoCfgKMConventionalKMDatatButtonFeature_A22603.SetValue(buttonInnerSection1.BtnConventionalButtonDatatButtonFeature_A22610.Value);
    buttonInnerSection3.RadErgoCfgKMTrunkingKMDatatButtonFeature_A22605.SetValue(buttonInnerSection1.BtnTrunkingButtonDatatButtonFeature_A22608.Value);
    IAcpRecordset feature3 = FeatureManager.GetFeature(2078);
    if (feature3 != null && feature3.Count != 0)
    {
      foreach (IAcpFeatureNode acpFeatureNode in (Collection<AcpBusinessLayer.FeatureNode>) (feature3[0] as Motorola.MackinawCPS.CoreFeatures.MPLConfiguration.MPLConfiguration).MPLList.EmbeddedRecset)
      {
        MPLListInner mplListInner = acpFeatureNode as MPLListInner;
        mplListInner.MPLListInnerSection.MplCfgMPLListTxPLFreq_A9556.SetValue(mplListInner.MPLListInnerSection.MplCfgMPLListTxPLCode_A9555.Value);
        mplListInner.MPLListInnerSection.MplCfgMPLListRxPLFreq_A9027.SetValue(mplListInner.MPLListInnerSection.MplCfgMPLListRxPLCode_A9026.Value);
        mplListInner.MPLListInnerSection.MplCfgMPLListTAPLFreq_A9263.SetValue(mplListInner.MPLListInnerSection.MplCfgMPLListTAPLCode_A9262.Value);
      }
    }
    IAcpRecordset feature4 = FeatureManager.GetFeature(2059);
    if (feature4 != null && feature4.Count != 0)
    {
      foreach (IAcpFeatureNode acpFeatureNode1 in (Collection<AcpBusinessLayer.FeatureNode>) feature4)
      {
        foreach (IAcpFeatureNode acpFeatureNode2 in (Collection<AcpBusinessLayer.FeatureNode>) (acpFeatureNode1 as Motorola.MackinawCPS.CoreFeatures.ConventionalPersonality.ConventionalPersonality).FrequencyOptions.EmbeddedRecset)
        {
          FrequencyOptionsInnerSection optionsInnerSection = (acpFeatureNode2 as FrequencyOptionsInner).FrequencyOptionsInnerSection;
          optionsInnerSection.CnvPerConventionalChannelOptionsTAPLFreq_A9264.SetValue(optionsInnerSection.CnvPerConventionalChannelOptionsTAPLCode_A9261.Value);
          optionsInnerSection.CnvPerConventionalChannelOptionsRxPLFreq_A8918.SetValue(optionsInnerSection.CnvPerConventionalChannelOptionsRxPLCode_A8917.Value);
          optionsInnerSection.CnvPerConventionalChannelOptionsTxPLFreq_A9419.SetValue(optionsInnerSection.CnvPerConventionalChannelOptionsTxPLCode_A9418.Value);
        }
      }
    }
    IAcpRecordset feature5 = FeatureManager.GetFeature(4109);
    KeypadButtonInnerRecset embeddedRecset21 = (feature5 as KeypadRecset)[0][10710].EmbeddedRecset as KeypadButtonInnerRecset;
    if (feature5 != null && feature5.Count != 0)
    {
      SignalIndependentProductIndependentProgrammableButtonListInnerRecset embeddedRecset22 = (FeatureManager.GetFeature(2013) as ShepherdsRecset)[0][10029].EmbeddedRecset as SignalIndependentProductIndependentProgrammableButtonListInnerRecset;
      for (int index = 0; index < embeddedRecset21.Count; ++index)
      {
        AcpListField buttonFeatureA41071 = (embeddedRecset21[index] as KeypadButtonInner).KeypadButtonInnerSection.RadErgCtrlKeypadGeneralKeypadButtonFeature_A41071;
        foreach (SignalIndependentProductIndependentProgrammableButtonListInner programmableButtonListInner in (Collection<AcpBusinessLayer.FeatureNode>) embeddedRecset22)
        {
          if ((embeddedRecset21[index] as KeypadButtonInner).KeypadButtonInnerSection.RadErgCtrlKeypadGeneralKeypadBCO_A41070.Value == programmableButtonListInner.SignalIndependentProductIndependentProgrammableButtonListInnerSection.RadErgoCfgSignalIndependentProductIndependentProgrammableButtonBCO_A19757.Value)
          {
            buttonFeatureA41071.SetValue(programmableButtonListInner.SignalIndependentProductIndependentProgrammableButtonListInnerSection.RadErgoCfgSignalIndependentProductIndependentProgrammableButtonFeature_A19758.Value);
            break;
          }
        }
      }
    }
    IAcpRecordset feature6 = FeatureManager.GetFeature(2038);
    if (feature6 != null && feature6.Count != 0 && this.IsPortableModel)
    {
      Motorola.MackinawCPS.CoreFeatures.Switches.Switches switches = feature6[0] as Motorola.MackinawCPS.CoreFeatures.Switches.Switches;
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
    IAcpRecordset feature7 = FeatureManager.GetFeature(2045);
    IAcpRecordset feature8 = FeatureManager.GetFeature(2038);
    IAcpRecordset feature9 = FeatureManager.GetFeature(2033);
    if (feature8 != null && feature8.Count != 0 && this.IsMobileModel)
    {
      Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide radioWide = feature7[0] as Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide;
      Motorola.MackinawCPS.CoreFeatures.Switches.Switches switches = feature8[0] as Motorola.MackinawCPS.CoreFeatures.Switches.Switches;
      Motorola.MackinawCPS.CoreFeatures.RadioErgonomicsWide.RadioErgonomicsWide radioErgonomicsWide = feature9[0] as Motorola.MackinawCPS.CoreFeatures.RadioErgonomicsWide.RadioErgonomicsWide;
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
    IAcpRecordset feature10 = FeatureManager.GetFeature(2064);
    if (feature10 != null && feature10.Count != 0)
    {
      foreach (IAcpFeatureNode acpFeatureNode in (Collection<AcpBusinessLayer.FeatureNode>) feature10)
      {
        Motorola.MackinawCPS.CoreFeatures.TrunkingSystem.TrunkingSystem trunkingSystem = acpFeatureNode as Motorola.MackinawCPS.CoreFeatures.TrunkingSystem.TrunkingSystem;
        trunkingSystem.General.TrkSysLabtoolNetworkID_A8565.SetValue(trunkingSystem.General.TrkSysGeneralSystemType_A9252.Value != 3 ? ((trunkingSystem.General.TrkSysGeneralSystemID_A9239.Value & (int) byte.MaxValue) << 4) + trunkingSystem.General.TrkSysGeneralConnectToneHz_A7710.Value : 0);
      }
    }
    IAcpRecordset feature11 = FeatureManager.GetFeature(4174);
    if (feature11 != null && feature11.Count != 0)
    {
      foreach (IAcpFeatureNode acpFeatureNode in (Collection<AcpBusinessLayer.FeatureNode>) feature11)
      {
        Motorola.MackinawCPS.CoreFeatures.MissionCriticalGeofence.MissionCriticalGeofence criticalGeofence = acpFeatureNode as Motorola.MackinawCPS.CoreFeatures.MissionCriticalGeofence.MissionCriticalGeofence;
        if (criticalGeofence.General.McGeofencePriority_42879.Valid)
        {
          criticalGeofence.General.McGeofencePriority_42879.CalculateApplicability();
          criticalGeofence.General.McGeofencePriority_42879.CalculateValidity();
        }
      }
    }
    IAcpRecordset feature12 = FeatureManager.GetFeature(2055);
    if (feature12 != null && feature12.Count != 0)
    {
      int newValue = (feature12[0] as Motorola.MackinawCPS.CoreFeatures.SecureKMFProfile.SecureKMFProfile).ASTROOTARInformation.SecKmfProfASTROOTARInformationIndividualASTROOTARRadioID_A8285.Value;
      IAcpRecordset feature13 = FeatureManager.GetFeature(2021);
      if (feature13 != null && feature13.Count != 0)
        (feature13[0] as Motorola.MackinawCPS.CoreFeatures.SecureWide.SecureWide).ASTROOTAR.SecWideASTROOTARIndividualASTROOTARRadioID_A8284.SetValue(newValue);
    }
    this.InitFCCNarrowBandSplit();
    IAcpRecordset feature14 = FeatureManager.GetFeature(2021);
    if (feature14 != null && feature14.Count != 0)
    {
      Motorola.MackinawCPS.CoreFeatures.SecureWide.SecureWide secureWide = feature14[0] as Motorola.MackinawCPS.CoreFeatures.SecureWide.SecureWide;
      if (secureWide.EncryptionKeyList.EmbeddedRecset != null)
      {
        int newValue = -1;
        foreach (IAcpFeatureNode acpFeatureNode in (Collection<AcpBusinessLayer.FeatureNode>) secureWide.EncryptionKeyList.EmbeddedRecset)
        {
          EncryptionKeyListInnerSection listInnerSection = (acpFeatureNode as EncryptionKeyListInner).EncryptionKeyListInnerSection;
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
      IAcpRecordset embeddedRecset23 = displayAndMenu.BacklightColorControl.EmbeddedRecset;
      int num = 0;
      foreach (AcpBusinessLayer.FeatureNode featureNode in (Collection<AcpBusinessLayer.FeatureNode>) embeddedRecset23)
      {
        ++num;
        if (featureNode is BacklightColorsInner backlightColorsInner && backlightColorsInner.BacklightColorsInnerSection.DispMenuLabtoolColorText1_A7689.Value.Length > 14)
          backlightColorsInner.BacklightColorsInnerSection.DispMenuLabtoolColorText1_A7689.Value = AppResources.Color_Id + num.ToString();
      }
    }
    this.CombinePinPartsToPinPassword(isReadingRadio, currentRadioParams);
    this.ChangeLegacyDINCFieldsFromLowerToUpperCase();
    this.RemoveTheRecordOfCallAlertIDDisplay();
    IAcpRecordset feature15 = (IAcpRecordset) (FeatureManager.GetFeature(2200) as UclContactRecset);
    if (feature15.Count != 0 && feature15 != null)
    {
      for (int index1 = 0; index1 < feature15.Count; ++index1)
      {
        UclContact uclContact = feature15[index1] as UclContact;
        if (uclContact.PhoneCallList.HasEmbeddedRecset)
        {
          AcpBusinessLayer.Recordset embeddedRecset24 = (AcpBusinessLayer.Recordset) (uclContact.PhoneCallList.EmbeddedRecset as PhoneCallListRecset);
          if (embeddedRecset24.Count != 0 && embeddedRecset24 != null)
          {
            for (int index2 = 0; index2 < embeddedRecset24.Count; ++index2)
            {
              PhoneCallList phoneCallList = embeddedRecset24[index2] as PhoneCallList;
              if (phoneCallList.CallListPhone.UclPhone_PhoneNumber_A00033Value == "")
                phoneCallList.CallListPhone.UclPhone_PhoneNumber_A00033Value = "F";
            }
          }
        }
      }
    }
    this.SynO2O7MFK();
    this.UpdateO2O7Emergency();
    this.SyncDataButton();
    this.SyncO2O3O7O5O9NavigationControls();
    Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation radioInformation = FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation;
    string codeplugVersionA7683 = (string) radioInformation.General.RadInfoGeneralCodeplugVersion_A7683;
    bool dispatchA38638Value = radioInformation.Labtool.RadInfoLabtoolExtendedDispatch_A38638Value;
    int num1 = int.Parse(codeplugVersionA7683.Substring(1, 2));
    ConventionalSystemRecset feature16 = FeatureManager.GetFeature(2053) as ConventionalSystemRecset;
    if (num1 < 9)
    {
      foreach (Motorola.MackinawCPS.CoreFeatures.ConventionalSystem.ConventionalSystem conventionalSystem in (Collection<AcpBusinessLayer.FeatureNode>) feature16)
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
    DataProfilesRecset feature17 = FeatureManager.GetFeature(2054) as DataProfilesRecset;
    int codeplugMainVersion = this.GetCodeplugMainVersion();
    if (feature17 != null && codeplugMainVersion < 9)
    {
      foreach (Motorola.MackinawCPS.CoreFeatures.DataProfiles.DataProfiles dataProfiles in (Collection<AcpBusinessLayer.FeatureNode>) feature17)
      {
        if (dataProfiles.General.DataProfGeneralDataProfileType_A21320.Value == 0 && dataProfiles.General.DataProfGeneralPacketDataMode_A8689.Value == 0 && dataProfiles.Features.DataProfFeaturesARSMode_A7465.Value == 3)
          dataProfiles.Features.DataProfFeaturesARSMode_A7465.SetValue(0);
      }
    }
    if (FeatureManager.GetFeature(2059) is ConventionalPersonalityRecset feature18)
    {
      foreach (IAcpFeatureNode acpFeatureNode in (Collection<AcpBusinessLayer.FeatureNode>) feature18)
      {
        if (acpFeatureNode is Motorola.MackinawCPS.CoreFeatures.ConventionalPersonality.ConventionalPersonality conventionalPersonality && conventionalPersonality.Secure.CnvPerSecureOTARTx_A8675.HiddenStatic && conventionalPersonality.Secure.CnvPerSecureOTARTx_A8675.Value)
          conventionalPersonality.Secure.CnvPerSecureOTARTx_A8675.SetValue(false);
      }
    }
    this.UpdatePaddingSpacesForSoftIDUsername();
    this.ConsolidatedActionBCOTableInit();
    if (UtilityMack.IsMobileOnly())
    {
      foreach (AcpBusinessLayer.FeatureNode featureNode in (Collection<AcpBusinessLayer.FeatureNode>) (FeatureManager.GetFeature(4008) as ActionConsolidationRecset))
      {
        ConsolidatedActionsInnerRecset embeddedRecset25 = ((Motorola.MackinawCPS.CoreFeatures.ActionConsolidation.ActionConsolidation) featureNode).General.EmbeddedRecset as ConsolidatedActionsInnerRecset;
        if (embeddedRecset25.Count != 0)
        {
          if (embeddedRecset25.ParentSection != null)
          {
            AcpFieldX<bool, string> actionAllowedA36579 = ((Motorola.MackinawCPS.CoreFeatures.ActionConsolidation.ActionConsolidation) featureNode).General.RadioErgoConfigACGeneralActionAllowed_A36579;
            bool flag = false;
            int num2 = 0;
            foreach (IAcpFeatureNode acpFeatureNode in (Collection<AcpBusinessLayer.FeatureNode>) embeddedRecset25)
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
          (embeddedRecset25.ParentSection.Parent as Motorola.MackinawCPS.CoreFeatures.ActionConsolidation.ActionConsolidation).General.RadioErgoConfigACGeneralActionAllowed_A36579.Value = true;
      }
      if ((FeatureManager.GetFeature(2127) as ControlHeadO3Recset)[0][10234].EmbeddedRecset is Motorola.MackinawCPS.CoreFeatures.ControlHeadO3.DataButtonInnerRecset embeddedRecset26)
      {
        foreach (IAcpFeatureNode acpFeatureNode in (Collection<AcpBusinessLayer.FeatureNode>) embeddedRecset26)
        {
          (acpFeatureNode[10212] as Motorola.MackinawCPS.CoreFeatures.ControlHeadO3.DataButtonInnerSection).CHO3DataButtonConvIndex_A41419.CalculateApplicability();
          (acpFeatureNode[10212] as Motorola.MackinawCPS.CoreFeatures.ControlHeadO3.DataButtonInnerSection).CHO3DataButtonConvIndex_A41419.CalculateValidity();
          (acpFeatureNode[10212] as Motorola.MackinawCPS.CoreFeatures.ControlHeadO3.DataButtonInnerSection).CHO3DataButtonTrkIndex_A41420.CalculateApplicability();
          (acpFeatureNode[10212] as Motorola.MackinawCPS.CoreFeatures.ControlHeadO3.DataButtonInnerSection).CHO3DataButtonTrkIndex_A41420.CalculateValidity();
        }
      }
      if ((FeatureManager.GetFeature(4114) as ControlHeadO7Recset)[0][10717].EmbeddedRecset is O7DataButtonInnerRecset embeddedRecset27)
      {
        foreach (IAcpFeatureNode acpFeatureNode in (Collection<AcpBusinessLayer.FeatureNode>) embeddedRecset27)
        {
          (acpFeatureNode[10713] as O7DataButtonInnerSection).CHO7DataButtonConvIndex_A41417.CalculateApplicability();
          (acpFeatureNode[10713] as O7DataButtonInnerSection).CHO7DataButtonConvIndex_A41417.CalculateValidity();
          (acpFeatureNode[10713] as O7DataButtonInnerSection).CHO7DataButtonTrkIndex_A41418.CalculateApplicability();
          (acpFeatureNode[10713] as O7DataButtonInnerSection).CHO7DataButtonTrkIndex_A41418.CalculateValidity();
        }
      }
      ControlHeadO9Recset feature19 = FeatureManager.GetFeature(4003) as ControlHeadO9Recset;
      ResponseSelectorListInnerRecset embeddedRecset28 = feature19[0][10624].EmbeddedRecset as ResponseSelectorListInnerRecset;
      O9DataButtonInnerRecset embeddedRecset29 = feature19[0][10611].EmbeddedRecset as O9DataButtonInnerRecset;
      if (embeddedRecset28 != null)
      {
        foreach (IAcpFeatureNode acpFeatureNode in (Collection<AcpBusinessLayer.FeatureNode>) embeddedRecset28)
        {
          (acpFeatureNode[10625] as ResponseSelectorListInnerSection).CHO9PursuitKnobIndex_A36685.CalculateApplicability();
          (acpFeatureNode[10625] as ResponseSelectorListInnerSection).CHO9PursuitKnobIndex_A36685.CalculateValidity();
        }
      }
      if (embeddedRecset29 != null)
      {
        foreach (IAcpFeatureNode acpFeatureNode in (Collection<AcpBusinessLayer.FeatureNode>) embeddedRecset29)
        {
          (acpFeatureNode[10608] as O9DataButtonInnerSection).CHO9DataButtonConvIndex_A41414.CalculateApplicability();
          (acpFeatureNode[10608] as O9DataButtonInnerSection).CHO9DataButtonConvIndex_A41414.CalculateValidity();
          (acpFeatureNode[10608] as O9DataButtonInnerSection).CHO9DataButtonTrkIndex_A41416.CalculateApplicability();
          (acpFeatureNode[10608] as O9DataButtonInnerSection).CHO9DataButtonTrkIndex_A41416.CalculateValidity();
        }
      }
      if ((FeatureManager.GetFeature(2128) as KeypadMicAndAccessoriesRecset)[0][10228].EmbeddedRecset is Motorola.MackinawCPS.CoreFeatures.KeypadMicAndAccessories.DataButtonInnerRecset embeddedRecset30)
      {
        foreach (IAcpFeatureNode acpFeatureNode in (Collection<AcpBusinessLayer.FeatureNode>) embeddedRecset30)
        {
          (acpFeatureNode[10209] as Motorola.MackinawCPS.CoreFeatures.KeypadMicAndAccessories.DataButtonInnerSection).RadErgoCfgKMConventionalKMDatatButtonIndex_A41423.CalculateApplicability();
          (acpFeatureNode[10209] as Motorola.MackinawCPS.CoreFeatures.KeypadMicAndAccessories.DataButtonInnerSection).RadErgoCfgKMConventionalKMDatatButtonIndex_A41423.CalculateValidity();
          (acpFeatureNode[10209] as Motorola.MackinawCPS.CoreFeatures.KeypadMicAndAccessories.DataButtonInnerSection).RadErgoCfgKMTrunkingKMDatatButtonIndex_A41424.CalculateApplicability();
          (acpFeatureNode[10209] as Motorola.MackinawCPS.CoreFeatures.KeypadMicAndAccessories.DataButtonInnerSection).RadErgoCfgKMTrunkingKMDatatButtonIndex_A41424.CalculateValidity();
        }
      }
    }
    this.RefreshMaxChangeRecords();
    if (UtilityMack.IsMobile())
    {
      bool flag = false;
      if (FeatureManager.GetFeature(2045)[0] is Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide radioWide && radioWide.Labtool.RadWideLabtoolMFKEmergencyAccess_A42216 != null)
        flag = radioWide.Labtool.RadWideLabtoolMFKEmergencyAccess_A42216.Value;
      AcpListField acpListField1 = (AcpListField) null;
      AcpListField acpListField2 = (AcpListField) null;
      if (FeatureManager.GetFeature(4115) is ControlHeadO2Recset feature20 && feature20[0] != null && feature20[0][10721] is O2MultiFunctionKnob multiFunctionKnob1)
        acpListField1 = multiFunctionKnob1.RadErgoControlO2MFKButtonPress_A42217;
      if (FeatureManager.GetFeature(4114) is ControlHeadO7Recset feature21 && feature21[0] != null && feature21[0][10718] is O7MultiFunctionKnob multiFunctionKnob2)
        acpListField2 = multiFunctionKnob2.RadErgoControlO7MFKButtonPress_A42218;
      if (FeatureManager.GetFeature(2013) is ShepherdsRecset feature22 && feature22[0] != null && feature22[0][10031].EmbeddedRecset is SignalIndependentProductIndependentNonProgrammableButtonListInnerRecset embeddedRecset31)
      {
        if (embeddedRecset31.Count < 36)
        {
          while (embeddedRecset31.Count < 36)
            embeddedRecset31.AddRecord(embeddedRecset31.CreateDefaultRecord());
          if (embeddedRecset31[34][10032] is SignalIndependentProductIndependentNonProgrammableButtonListInnerSection listInnerSection1)
          {
            listInnerSection1.RadErgoCfgSignalIndependentProductIndependentNonProgrammableButtonBCO_A19777.SetValue(11);
            listInnerSection1.RadErgoCfgSignalIndependentProductIndependentNonProgrammableButtonFeature_A19778.SetValue(216);
          }
          if (embeddedRecset31[35][10032] is SignalIndependentProductIndependentNonProgrammableButtonListInnerSection listInnerSection2)
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
          foreach (IAcpFeatureNode acpFeatureNode in (Collection<AcpBusinessLayer.FeatureNode>) embeddedRecset31)
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
              acpListField2?.SetValue(215);
              break;
            }
          }
        }
      }
    }
    this.ToneSignalingListToneAliasFixup();
    UndoManager.StartUndoRedo();
  }

  private void FixPinPassword()
  {
    Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide radioWide = FeatureManager.GetFeature(2045)[0] as Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide;
    radioWide.UserInformationAndPasswords.RadWideUserInformationandPINPassword_41303.CalculateValidity();
    if (!radioWide.UserInformationAndPasswords.RadWideUserInformationandPINPassword_41303.HiddenStatic || radioWide.UserInformationAndPasswords.RadWideUserInformationandPINPassword_41303.Valid)
      return;
    radioWide.UserInformationAndPasswords.RadWideUserInformationandPINPassword_41303.SetValue(radioWide.UserInformationAndPasswords.RadWideUserInformationandPINPassword_41303.DefaultValue);
  }

  private void RefreshDynChannelName()
  {
    if (!(FeatureManager.GetFeature(2045)[0] is Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide radioWide) || !radioWide.Labtool.RadWideLabtoolDynamicZoneScanCapability_42749.Value)
      return;
    IAcpRecordset acpRecordset = AppInfoManager.AppMode != ApplicationMode.CodeplugComparisonMode ? FeatureManager.GetFeature(2051) : AppInfoManager.ComparatorDocument.GetFeature(2051);
    if (acpRecordset != null)
    {
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
  }

  private void RefreshUserSelectablePL()
  {
    ConventionalPersonalityRecset personalityRecset = AppInfoManager.AppMode != ApplicationMode.CodeplugConfigurationMode ? AppInfoManager.ComparatorDocument.GetFeature(2059) as ConventionalPersonalityRecset : FeatureManager.GetFeature(2059) as ConventionalPersonalityRecset;
    if (personalityRecset == null)
      return;
    foreach (IAcpFeatureNode acpFeatureNode in (Collection<AcpBusinessLayer.FeatureNode>) personalityRecset)
    {
      Motorola.MackinawCPS.CoreFeatures.ConventionalPersonality.ConventionalPersonality conventionalPersonality = acpFeatureNode as Motorola.MackinawCPS.CoreFeatures.ConventionalPersonality.ConventionalPersonality;
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
    if (feature != null && flag)
    {
      foreach (IAcpFeatureNode acpFeatureNode in (Collection<AcpBusinessLayer.FeatureNode>) feature)
      {
        Motorola.MackinawCPS.CoreFeatures.DataProfiles.DataProfiles dataProfiles = acpFeatureNode as Motorola.MackinawCPS.CoreFeatures.DataProfiles.DataProfiles;
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
      actionsInnerSection.RadioErgoConfigACGeneralIndex_A36591.IsVisible = new StateConstraint(ActionConsolidationConstraints.ConActionTypeIsGeneralOrExitOrControl);
      actionsInnerSection.RadioErgoConfigACGeneralZone_A36592.IsVisible = new StateConstraint(ActionConsolidationConstraints.ConActionTypeIsGeneralOrControl);
      actionsInnerSection.RadioErgoConfigACGeneralChannel_A36593.IsVisible = new StateConstraint(ActionConsolidationConstraints.ConActionTypeIsGeneralOrControl);
      actionsInnerSection.RadioErgoConfigACAlertAudioFile_A42875.IsVisible = new StateConstraint(ActionConsolidationConstraints.ConActionTypeIsGeneralOrExitOrPA);
      actionsInnerSection.RadioErgoConfigACAlertInterval_A42877.IsVisible = new StateConstraint(ActionConsolidationConstraints.ConActionTypeIsGeneralOrExitOrPA);
      actionsInnerSection.RadioErgoConfigACGeneralTEXTMESSAGE_42913.IsVisible = new StateConstraint(ActionConsolidationConstraints.ConActionTypeIsGeneralOrExit);
      actionsInnerSection.RadioErgoConfigACGeneralTxPowerChange__42916.IsVisible = new StateConstraint(ActionConsolidationConstraints.ConActionTypeIsGeneral);
      actionsInnerSection.RadioErgoConfigACGeneralMuteSSA__42917.IsVisible = new StateConstraint(ActionConsolidationConstraints.ConActionTypeIsGeneral);
      actionsInnerSection.CalculateVisibility();
    }
  }

  private void RefreshToneSignalingList()
  {
    if (!(FeatureManager.GetFeature(2059) is ConventionalPersonalityRecset feature))
      return;
    foreach (IAcpFeatureNode acpFeatureNode in (Collection<AcpBusinessLayer.FeatureNode>) feature)
    {
      if (acpFeatureNode is Motorola.MackinawCPS.CoreFeatures.ConventionalPersonality.ConventionalPersonality conventionalPersonality)
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
    if (this.GetCodeplugMainVersion() >= 15 || !(FeatureManager.GetFeature(2049)[0] is Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation radioInformation))
      return;
    string numberA8539Value = radioInformation.General.RadInfoGeneralModelNumber_A8539Value;
    if (numberA8539Value != null && numberA8539Value.StartsWith("L30") && FeatureManager.GetFeature(2077) is RadioProfilesRecset feature)
    {
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
  }

  private void RefreshMaxChangeRecords()
  {
    ConventionalPersonalityRecset feature1 = FeatureManager.GetFeature(2059) as ConventionalPersonalityRecset;
    if (feature1 != null)
    {
      foreach (IAcpFeatureNode acpFeatureNode in (Collection<AcpBusinessLayer.FeatureNode>) feature1)
      {
        Motorola.MackinawCPS.CoreFeatures.ConventionalPersonality.ConventionalPersonality conventionalPersonality = acpFeatureNode as Motorola.MackinawCPS.CoreFeatures.ConventionalPersonality.ConventionalPersonality;
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
      foreach (IAcpFeatureNode acpFeatureNode in (Collection<AcpBusinessLayer.FeatureNode>) feature2)
      {
        if (acpFeatureNode is Motorola.MackinawCPS.CoreFeatures.ScanList.ScanList scanList && scanList.General.ScanLstGeneralScanType_A9058 != null)
          scanList.General.ScanLstGeneralScanType_A9058.CalculateApplicability();
      }
    }
    if (!(FeatureManager.GetFeature(2064) is TrunkingSystemRecset feature3))
      return;
    foreach (IAcpFeatureNode acpFeatureNode in (Collection<AcpBusinessLayer.FeatureNode>) feature3)
    {
      if (acpFeatureNode is Motorola.MackinawCPS.CoreFeatures.TrunkingSystem.TrunkingSystem trunkingSystem && trunkingSystem.StatusAlias.TrkSysStatusAliasStatusAliasEnable_A9195 != null)
        trunkingSystem.StatusAlias.TrkSysStatusAliasStatusAliasEnable_A9195.CalculateApplicability();
    }
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
        newValue += (string) (object) ' ';
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
    if (content != null)
    {
      if (e.Content is PageWelcome)
        content.SetSelectedItem(content.ButtonHome, false);
      else
        content.SetSelectedItem(content.ButtonCpgNav, false);
    }
  }

  internal void OnAppMenuDepotCreateCodeplug(object sender, RoutedEventArgs e)
  {
    AcpKeyValidator acpKeyValidator = new AcpKeyValidator();
    if (!acpKeyValidator.IsDepotKeyAttached())
    {
      int num1 = (int) System.Windows.MessageBox.Show(AppResources.This_function_can_only_be_accessed, AppResources.Error_excalmatory_mark, MessageBoxButton.OK, MessageBoxImage.Hand);
    }
    else
    {
      AcpUI.Common.Utility.SaveFieldWithFocus();
      AcpDocument theDocument = ((App) System.Windows.Application.Current).TheDocument;
      if (this.CpgOpenFlag)
      {
        if (theDocument.IsDirty)
        {
          if (System.Windows.MessageBox.Show(AppResources.Your_currently_have_unsaved_continue, AppResources.Document_being_Modified, MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.No)
            return;
          if (AppInfoManager.AppMode == ApplicationMode.CodeplugComparisonMode)
            this.OnRibbonBarCompCodeplug(sender, (RoutedEventArgs) null);
          this.CloseFile();
          if (FlashDataManager.FlashDoc != null)
            FlashDataManager.FlashDoc.Clear();
        }
        else
        {
          if (AppInfoManager.AppMode == ApplicationMode.CodeplugComparisonMode)
            this.OnRibbonBarCompCodeplug(sender, (RoutedEventArgs) null);
          this.CloseFile();
          if (FlashDataManager.FlashDoc != null)
            FlashDataManager.FlashDoc.Clear();
        }
      }
      this.ribbonTabTools.Focus();
      DepotCreateCodeplugWnd createCodeplugWnd = new DepotCreateCodeplugWnd();
      createCodeplugWnd.Owner = (Window) this;
      if (!createCodeplugWnd.ShowDialog().Value)
        return;
      this.InitDocument();
      ((App) System.Windows.Application.Current).TheDocument.FileNew();
      DateTime now1 = DateTime.Now;
      now1 = DateTime.Now;
      this.MyModelNumber = createCodeplugWnd.ModelNum;
      ModelTiering.DepotCustomizationOptions = createCodeplugWnd.DepotOptions;
      string modelNumber = createCodeplugWnd.ModelNum.Length > 12 ? createCodeplugWnd.ModelNum.Substring(0, 12) : createCodeplugWnd.ModelNum;
      try
      {
        new FlashCodeplugForDepot().UpgradeCodeplugForDepot(modelNumber, createCodeplugWnd.FlashCode, createCodeplugWnd.SerNum, false);
      }
      catch
      {
        int num2 = (int) System.Windows.MessageBox.Show(AppResources.not_supported_H_Option_not_updated.AcpStringFormat((object) createCodeplugWnd.FlashCode, (object) modelNumber));
        return;
      }
      this.objModelTiering = new ModelTiering(this.MyModelNumber, ModelTiering.ActionTypes.DEPOT, ModelTiering.TargetTypes.ALL);
      ModelTiering.DepotCustomizationOptions = (System.Collections.Generic.List<string>) null;
      this.objModelTiering.UpdateUtilityMackModelType();
      this.IsMobileModel = UtilityMack.IsMobilePro;
      this.IsPortableModel = UtilityMack.IsPortablePro;
      ConstraintManager.Suspend();
      this.objModelTiering.ApplyTiering();
      ConstraintManager.Resume();
      this.MyModelNumber = modelNumber;
      Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation radioInformation1 = FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation;
      radioInformation1.Tracking.RadInfoTrackingCodeplugVersion_A7688_UIValue = this.CPS_Version;
      radioInformation1.General.RadInfoGeneralCodeplugVersion_A7683_UIValue = this.CPS_Version;
      radioInformation1.Labtool.RadInfoLabtoolSecurePartitionVersionNumber_A9076_UIValue = this.CPS_Version;
      radioInformation1.Labtool.RadInfoLabtoolOriginalSecurePartitionVersion_A8626_UIValue = this.CPS_Version;
      radioInformation1.Tracking.RadInfoTrackingSource2_A8625_UIValue = AppResources.Depot_ID;
      radioInformation1.Tracking.RadInfoTrackingSource1_A9171_UIValue = AppResources.Depot_ID;
      string depotKeySerialNum = new DepotCommon().GetDepotKeySerialNum(acpKeyValidator);
      radioInformation1.DepotKeyInfo.RadInfoDepotKeySerialNumber_42793.SetValue(depotKeySerialNum);
      DateTime now2 = DateTime.Now;
      long ticks = new DateTime(now2.Year, now2.Month, now2.Day, now2.Hour, now2.Minute, 0).ToUniversalTime().Ticks;
      radioInformation1.Tracking.RadInfoLabtoolBornOnDateDBValue_A7568Value = ticks;
      this.SetVoiceAnnouncementDefaults();
      string flashcodeResult = (string) null;
      FlashcodeGenerator.CalculateFlashcode(ref flashcodeResult, this.MyModelNumber);
      Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation radioInformation2 = FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation;
      if (flashcodeResult != createCodeplugWnd.FlashCode)
      {
        AppInfoManager.InvalidFieldsReport.Clear();
        int num3 = (int) System.Windows.MessageBox.Show(AppResources.not_supported_H_Option_not_updated.AcpStringFormat((object) createCodeplugWnd.FlashCode, (object) createCodeplugWnd.ModelNum));
      }
      else
      {
        this.SetProductModelIdentifierField();
        this.SetDVRSHoptionEnabledField();
        this.SetDVRSHwEnabledField();
        this.IsCpgConvOnly = false;
        if (AppInfoManager.AppView == DifferentiatedUserViewType.Custom)
        {
          string customVwPath = this.customVwPath;
          if (!string.IsNullOrEmpty(customVwPath) && File.Exists(customVwPath))
            ((App) System.Windows.Application.Current).TheDocument.ImportFromXml(customVwPath, XmlFileType.CustomView);
          else
            this.DiffViewType.SelectedIndex = 2;
        }
        WindowMain mainWindow = (WindowMain) System.Windows.Application.Current.MainWindow;
        mainWindow.CpgOpenFlag = true;
        this.cpgFileName = (string) null;
        AppInfoManager.ClearNavigationHistory = true;
        PageNavPaneButtons content = (PageNavPaneButtons) mainWindow.FrameLeft.Content;
        content.ButtonCpgNav.IsSelected = true;
        content.FrameCodeplug.Navigate(new Uri("PageTreeView.xaml", UriKind.RelativeOrAbsolute));
        mainWindow.FrameCenterTop.Navigate(new Uri(FeatureManager.GetFeature(2049).UIPagePath, UriKind.RelativeOrAbsolute));
        AppInfoManager.AppMode = ApplicationMode.CodeplugConfigurationMode;
        this.InitASKProgHistoryRecSet();
        UndoManager.Reset();
        ((App) System.Windows.Application.Current).TheDocument.Initialized(false);
        if (this.IsMobileModel)
          this.AddO9DefaultDirLightBar();
        this.UpdateAuxControlTable();
        foreach (IAcpConstraints feature in FeatureManager.Features)
          feature.CallConstraints();
        this.objModelTiering.RecrefFixup();
        this.IsMobileModelAndSupportedO9 = false;
        this.IsMobileModelAndSupportedO3 = false;
        this.IsMobileModelAndSupportedO5 = false;
        this.IsMobileModelAndSupportedO7 = false;
        this.IsMobileModelAndSupportedO2 = false;
        ((PageStatusBar) mainWindow.FrameStatusBar.Content).Status = AppResources.READY_ID;
        radioInformation2.FLASHport.RadInfoFLASHportFLASHcode_A8132Value = flashcodeResult;
        UndoManager.Reset();
        if (!UndoManager.MarkForUndo)
          UndoManager.StartUndoRedo();
      }
    }
  }

  internal void OnAppMenuDepotUpgradeRadio(object sender, RoutedEventArgs e)
  {
    if (!new AcpKeyValidator().IsDepotKeyAttached())
    {
      int num1 = (int) System.Windows.MessageBox.Show(AppResources.This_function_can_only_be_accessed, AppResources.Error_excalmatory_mark, MessageBoxButton.OK, MessageBoxImage.Hand);
    }
    else
    {
      AcpUI.Common.Utility.SaveFieldWithFocus();
      AcpDocument theDocument = ((App) System.Windows.Application.Current).TheDocument;
      if (this.CpgOpenFlag)
      {
        if (theDocument.IsDirty)
        {
          if (System.Windows.MessageBox.Show(AppResources.Your_currently_have_unsaved_continue, AppResources.Document_being_Modified, MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.No)
            return;
          if (AppInfoManager.AppMode == ApplicationMode.CodeplugComparisonMode)
            this.OnRibbonBarCompCodeplug(sender, (RoutedEventArgs) null);
          this.CloseFile();
          if (FlashDataManager.FlashDoc != null)
            FlashDataManager.FlashDoc.Clear();
        }
        else
        {
          if (AppInfoManager.AppMode == ApplicationMode.CodeplugComparisonMode)
            this.OnRibbonBarCompCodeplug(sender, (RoutedEventArgs) null);
          this.CloseFile();
          if (FlashDataManager.FlashDoc != null)
            FlashDataManager.FlashDoc.Clear();
        }
      }
      this.ribbonTabTools.Focus();
      if (System.Windows.MessageBox.Show(AppResources.Are_you_sure_you_want_to_upgrade_the_radio, AppResources.Confirm_Id, MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
        return;
      ReadRadioConfiguration radioConfiguration = new ReadRadioConfiguration();
      radioConfiguration.ReadRadio();
      if (radioConfiguration.RadioRecset == null)
      {
        int num2 = (int) System.Windows.MessageBox.Show(AppResources.Failed_to_communicate_with_Devices, AppResources.Communication_Error, MessageBoxButton.OK, MessageBoxImage.Hand);
      }
      else
      {
        AppInfoManager.DragOperation = true;
        Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
        this.InitDocument();
        ((App) System.Windows.Application.Current).TheDocument.FileNew();
        UndoManager.StopUndoRedo();
        UndoManager.Reset();
        ConstraintManager.Suspend();
        Mouse.OverrideCursor = (System.Windows.Input.Cursor) null;
        DepotUpgradeRadioWnd depotUpgradeRadioWnd = new DepotUpgradeRadioWnd();
        depotUpgradeRadioWnd.Owner = (Window) this;
        depotUpgradeRadioWnd.ModelNumber = (radioConfiguration.RadioRecset[0] as SpecialFeatures.Flashport.RadioConfiguration.RadioConfiguration).General.RadioConfigCurrentModelNumberValue;
        depotUpgradeRadioWnd.FlashCode = (radioConfiguration.RadioRecset[0] as SpecialFeatures.Flashport.RadioConfiguration.RadioConfiguration).General.RadioConfigCurrentFlashcodeValue;
        depotUpgradeRadioWnd.NewFlashCode = (radioConfiguration.RadioRecset[0] as SpecialFeatures.Flashport.RadioConfiguration.RadioConfiguration).General.RadioConfigCurrentFlashcodeValue;
        this.MyModelNumber = (radioConfiguration.RadioRecset[0] as SpecialFeatures.Flashport.RadioConfiguration.RadioConfiguration).General.RadioConfigCurrentModelNumberValue;
        if (depotUpgradeRadioWnd.ShowDialog().Value)
        {
          int num3 = (int) System.Windows.MessageBox.Show(AppResources.Upgrade_Radio_completed_successfully, AppResources.Upgrade_Radio, MessageBoxButton.OK, MessageBoxImage.Asterisk);
        }
        AppInfoManager.DragOperation = false;
      }
    }
  }

  internal void OnAppMenuDepotUpgradeCodeplug(object sender, RoutedEventArgs e)
  {
    AcpKeyValidator acpKeyValidator = new AcpKeyValidator();
    if (!acpKeyValidator.IsDepotKeyAttached())
    {
      int num1 = (int) System.Windows.MessageBox.Show(AppResources.This_function_can_only_be_accessed, AppResources.Error_excalmatory_mark, MessageBoxButton.OK, MessageBoxImage.Hand);
    }
    else
    {
      AcpUI.Common.Utility.SaveFieldWithFocus();
      AcpDocument theDocument = ((App) System.Windows.Application.Current).TheDocument;
      if (!this.CpgOpenFlag)
        return;
      if (AppInfoManager.AppMode == ApplicationMode.CodeplugComparisonMode)
        this.OnRibbonBarCompCodeplug(sender, (RoutedEventArgs) null);
      if (FlashDataManager.FlashDoc != null)
        FlashDataManager.FlashDoc.Clear();
      this.ribbonTabTools.Focus();
      AppInfoManager.DragOperation = true;
      Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
      UndoManager.StopUndoRedo();
      UndoManager.Reset();
      ConstraintManager.Suspend();
      Mouse.OverrideCursor = (System.Windows.Input.Cursor) null;
      DepotUpgradeCodeplugWnd upgradeCodeplugWnd = new DepotUpgradeCodeplugWnd();
      upgradeCodeplugWnd.Owner = (Window) this;
      Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation radioInformation = FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation;
      string numberA8539Value = radioInformation.General.RadInfoGeneralModelNumber_A8539Value;
      if (numberA8539Value != null || numberA8539Value != "")
        upgradeCodeplugWnd.ModelNumber = numberA8539Value;
      string numberA9122Value = radioInformation.General.RadInfoGeneralSerialNumber_A9122Value;
      if (numberA9122Value != null || numberA9122Value != "")
        upgradeCodeplugWnd.SerialNumber = numberA9122Value;
      string flasHcodeA8132Value = radioInformation.FLASHport.RadInfoFLASHportFLASHcode_A8132Value;
      if (flasHcodeA8132Value != null || flasHcodeA8132Value != "")
        upgradeCodeplugWnd.FlashCode = flasHcodeA8132Value;
      if (upgradeCodeplugWnd.ShowDialog().Value)
      {
        this.MyModelNumber = upgradeCodeplugWnd.ModelNumber;
        ModelTiering.DepotCustomizationOptions = upgradeCodeplugWnd.DepotOptions;
        try
        {
          FlashCodeplug flashCodeplug = new FlashCodeplug();
          flashCodeplug.postCodeplugInitialization();
          flashCodeplug.UpgradeCodeplug(this.MyModelNumber, upgradeCodeplugWnd.FlashCode, false);
        }
        catch
        {
          int num2 = (int) System.Windows.MessageBox.Show(AppResources.not_supported_H_Option_not_updated.AcpStringFormat((object) upgradeCodeplugWnd.FlashCode, (object) this.MyModelNumber));
          return;
        }
        string flashcodeResult = (string) null;
        FlashcodeGenerator.CalculateFlashcode(ref flashcodeResult, this.MyModelNumber);
        if (flashcodeResult != upgradeCodeplugWnd.FlashCode)
          throw new UpgradeRadioException(AppResources.Codeplug_upgrade_failed);
        radioInformation.Tracking.RadInfoTrackingCodeplugVersion_A7688_UIValue = AppInfoManager.AppVersion;
        radioInformation.General.RadInfoGeneralCodeplugVersion_A7683_UIValue = AppInfoManager.AppVersion;
        radioInformation.Labtool.RadInfoLabtoolSecurePartitionVersionNumber_A9076_UIValue = AppInfoManager.AppVersion;
        radioInformation.Labtool.RadInfoLabtoolOriginalSecurePartitionVersion_A8626_UIValue = AppInfoManager.AppVersion;
        radioInformation.Tracking.RadInfoTrackingSource2_A8625_UIValue = AppResources.Depot_ID;
        radioInformation.Tracking.RadInfoTrackingSource1_A9171_UIValue = AppResources.Depot_ID;
        radioInformation.FLASHport.RadInfoFLASHportFLASHcode_A8132Value = flashcodeResult;
        radioInformation.General.RadInfoGeneralSerialNumber_A9122_UIValue = upgradeCodeplugWnd.SerialNumber;
        string depotKeySerialNum = new DepotCommon().GetDepotKeySerialNum(acpKeyValidator);
        radioInformation.DepotKeyInfo.RadInfoDepotKeySerialNumber_42793.SetValue(depotKeySerialNum);
        new UpgradeRadio().SetCodeplugFields(flashcodeResult);
        theDocument.Initialized(true);
        int num3 = (int) System.Windows.MessageBox.Show(AppResources.Upgrade_Codeplug_Completed_Successfully, AppResources.Upgrade_Codeplug, MessageBoxButton.OK, MessageBoxImage.Asterisk);
      }
      AppInfoManager.DragOperation = false;
    }
  }

  internal void OnAppMenuDepotForceWriteRadio(object sender, RoutedEventArgs e)
  {
    AcpKeyValidator acpKeyValidator = new AcpKeyValidator();
    if (!acpKeyValidator.IsDepotKeyAttached())
    {
      int num1 = (int) System.Windows.MessageBox.Show(AppResources.This_function_can_only_be_accessed, AppResources.Error_excalmatory_mark, MessageBoxButton.OK, MessageBoxImage.Hand);
    }
    else
    {
      IAcpRecordset feature = FeatureManager.GetFeature(2045);
      Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide radioWide = feature[0] as Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide;
      AcpUI.Common.Utility.SaveFieldWithFocus();
      bool flag1 = false;
      bool flag2 = false;
      string message = "";
      string messageBoxText = "";
      SpecialFeatures.Comms.Comms comms = new SpecialFeatures.Comms.Comms();
      if (this.CpgOpenFlag)
      {
        if (System.Windows.MessageBox.Show(AppResources.You_are_about_to_Continue, AppResources.Force_Write_Radio, MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.No || this.PromptQuitOnInvalids())
          return;
        if (this.SaveCodeplug())
        {
          AppInfoManager.StatusMsgReport.Clear();
          RadioParams codeplgParams = new RadioParams();
          bool flag3 = false;
          this.OperationInProgressWindow = new DeviceOperationInProgressWindow();
          flag2 = true;
          string statusMsg = (string) null;
          if (!RadioAccessValidator.IsCpgOwnerSystemIDValid(out statusMsg))
          {
            message = statusMsg;
            AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, message);
            flag3 = true;
          }
          if (!flag3)
          {
            this.OperationInProgressWindow.ShowWindow(AppResources.Writing_device_Please_be_patient);
            Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation radioInformation = FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation;
            string versionA7683UiValue = radioInformation.General.RadInfoGeneralCodeplugVersion_A7683_UIValue;
            radioInformation.General.RadInfoGeneralCodeplugVersion_A7683_UIValue = this.cpsVersion;
            string source1A9171UiValue = radioInformation.Tracking.RadInfoTrackingSource1_A9171_UIValue;
            radioInformation.Tracking.RadInfoTrackingSource1_A9171_UIValue = AppResources.Depot_ID;
            string depotKeySerialNum = new DepotCommon().GetDepotKeySerialNum(acpKeyValidator);
            radioInformation.DepotKeyInfo.RadInfoDepotKeySerialNumber_42793.SetValue(depotKeySerialNum);
            string MacAddr = "";
            string WifiMacAddr = "";
            string BtAddr = "";
            bool flag4 = RadioAccessValidator.CacheDepotSecurityFields(out MacAddr, out WifiMacAddr, out BtAddr);
            try
            {
              comms.UpdatePINPasswordBeforeForceWrite();
              comms.UpdateWifiPwdBeforeForceWrite();
              comms.UpdatePCIFieldBeforeForceWrite();
              comms.ResetTrunkingRadioInhibit();
              comms.UpdateMacAddressBeforeForceWrite();
            }
            catch (Exception ex)
            {
              this.OperationInProgressWindow.CloseWindow();
              int num2 = (int) System.Windows.MessageBox.Show(AppResources.problem_unable_to_write_radio, AppResources.Device_Operation_Status);
              return;
            }
            Motorola.Common.Communication.CommonUtil.IshItemCollection codeplug = comms.packToCodeplug();
            if (codeplug != null)
            {
              if (codeplug.Count > 0)
              {
                if (this.ReadWriteTransport == 0)
                  flag1 = comms.WriteRadioForDepot(codeplug, COMMS_OP.USB_READ_WRITE, codeplgParams);
                else if (this.ReadWriteTransport == 1)
                {
                  flag1 = comms.WriteRadioForDepot(codeplug, COMMS_OP.OTAP_READ_WRITE, codeplgParams, this.commsLastUserState);
                  this.commsLastUserState = comms.GetLastCommsOTAPUserState();
                }
              }
              else
                message = AppResources.problem_dot_unable_to_write_radio;
            }
            else
              message = AppResources.problem_dot_unable_to_write_radio;
            if (!flag1)
            {
              if (codeplug == null)
                comms.ForceClose();
              if (versionA7683UiValue != "")
                radioInformation.General.RadInfoGeneralCodeplugVersion_A7683_UIValue = versionA7683UiValue;
              if (source1A9171UiValue != "")
                radioInformation.Tracking.RadInfoTrackingSource1_A9171_UIValue = source1A9171UiValue;
            }
            if (flag4)
              RadioAccessValidator.RestoreCachedDepotSecurityFields(MacAddr, WifiMacAddr, BtAddr);
          }
          else
            message = AppResources.problem_dot_unable_to_write_radio;
        }
        else
          flag1 = true;
        if (flag2)
        {
          this.OperationInProgressWindow.CloseWindow();
          if (flag1)
          {
            try
            {
              messageBoxText = AppResources.Write_Radio_Operation_Successful;
              if ((FeatureManager.GetFeature(2010)[0] as Motorola.MackinawCPS.CoreFeatures.DisplayAndMenu.DisplayAndMenu).Advanced.DispMenuAdvancedLanguageSelection_A8386.Value != 0)
              {
                string hostVersion = comms.GetRadioParams().HostVersion;
                short result = 0;
                short.TryParse(hostVersion.Substring(1, 2), out result);
                if (hostVersion.StartsWith("R") && result >= (short) 8 || (hostVersion.StartsWith("D") || hostVersion.StartsWith("B")) && result >= (short) 7)
                  messageBoxText = AppResources.LP_Write_Radio_After_Write_Radio_Operation_Successful;
              }
            }
            catch
            {
            }
          }
          else
          {
            string radioOperationFailed = AppResources.Write_Radio_Operation_Failed;
            StatusMessagesManager statusMsgReport = AppInfoManager.StatusMsgReport;
            messageBoxText = AppResources.Operation_Failed;
          }
          comms.RestoreWiFiPwdAfterForceWrite();
          comms.Dispose();
          if (feature != null && feature.Count > 0)
          {
            string newValue = radioWide.UserInformationAndPasswords.RadWideUserInformationandPINPassword_41303.Value;
            radioWide.Labtool.RadWideLabtoolEncryptedPINPassword_A41702.SetValue(newValue);
            radioWide.UserInformationAndPasswords.RadWideUserInformationandPasswordsPIN_A8705.SetValue(string.Empty);
            radioWide.UserInformationAndPasswords.RadWideUserInformationandPINPasswordPart2_41304.SetValue(string.Empty);
            radioWide.Labtool.RadWideLabtoolEncryptPassword_A41695.SetValue(true);
          }
          int num3 = (int) System.Windows.MessageBox.Show(System.Windows.Application.Current.MainWindow, messageBoxText, AppResources.Device_Operation_Status);
        }
        if (flag1)
          return;
        if (message == "")
          message = AppResources.problem_unable_to_write_radio;
        if (!flag2)
        {
          int num4 = (int) System.Windows.MessageBox.Show(AppResources.Operation_Failed_LowCase, AppResources.Device_Operation_Status);
        }
        AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, message);
      }
      else
      {
        int num5 = (int) System.Windows.MessageBox.Show(AppResources.No_Codeplug_loaded, AppResources.Force_Write_Radio_Status, MessageBoxButton.OK, MessageBoxImage.Hand);
        AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, AppResources.codeplug_must_open_before_writing_radio);
      }
    }
  }

  internal void OnAppMenuDepotCBIProgram(object sender, RoutedEventArgs e)
  {
    if (!new AcpKeyValidator().IsDepotKeyAttached())
    {
      int num1 = (int) System.Windows.MessageBox.Show(AppResources.This_function_can_only_be_accessed, AppResources.Error_excalmatory_mark, MessageBoxButton.OK, MessageBoxImage.Hand);
    }
    else
    {
      AcpUI.Common.Utility.SaveFieldWithFocus();
      AcpDocument theDocument = ((App) System.Windows.Application.Current).TheDocument;
      if (this.CpgOpenFlag)
      {
        if (theDocument.IsDirty)
        {
          if (System.Windows.MessageBox.Show(AppResources.Your_currently_have_unsaved_continue, AppResources.Document_being_Modified, MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.No)
            return;
          if (AppInfoManager.AppMode == ApplicationMode.CodeplugComparisonMode)
            this.OnRibbonBarCompCodeplug(sender, (RoutedEventArgs) null);
          this.CloseFile();
          if (FlashDataManager.FlashDoc != null)
            FlashDataManager.FlashDoc.Clear();
        }
        else
        {
          if (AppInfoManager.AppMode == ApplicationMode.CodeplugComparisonMode)
            this.OnRibbonBarCompCodeplug(sender, (RoutedEventArgs) null);
          this.CloseFile();
          if (FlashDataManager.FlashDoc != null)
            FlashDataManager.FlashDoc.Clear();
        }
      }
      this.ribbonTabTools.Focus();
      if (System.Windows.MessageBox.Show(AppResources.Are_you_sure_you_want_to_CBI_Program_the_radio, AppResources.CBI_Program, MessageBoxButton.YesNo) != MessageBoxResult.Yes)
        return;
      SpecialFeatures.Comms.Comms comms = new SpecialFeatures.Comms.Comms();
      if (this.ReadWriteTransport == 0)
      {
        if (comms.CbiProgram(COMMS_OP.USB_READ_WRITE))
        {
          int num2 = (int) System.Windows.MessageBox.Show(AppResources.Complete_CBI_Programming, AppResources.CBI_Programming, MessageBoxButton.OK, MessageBoxImage.Asterisk);
        }
        else
        {
          int num3 = (int) System.Windows.MessageBox.Show(AppResources.Radio_CBI_Programming_failed, AppResources.CBI_Programming, MessageBoxButton.OK, MessageBoxImage.Asterisk);
        }
      }
      else
      {
        int num4 = (int) System.Windows.MessageBox.Show(AppResources.Radio_CBI_Programming_failed, AppResources.CBI_Programming, MessageBoxButton.OK, MessageBoxImage.Asterisk);
      }
    }
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

  internal void SetVoiceAnnouncementDefaults()
  {
    Exception exception;
    try
    {
      if (!(FeatureManager.GetFeature(2300) is VoiceAnnouncementListRecSet feature1))
        return;
      string str1 = Environment.CurrentDirectory + "\\VoiceAnnouncement\\channelone.mva";
      string str2 = Environment.CurrentDirectory + "\\VoiceAnnouncement\\zoneone.mva";
      string str3 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Motorola\\ApxFamilyCPS\\Common\\VoiceAnnouncementMvaFiles");
      string str4 = str3 + "\\channelone.mva";
      string str5 = str3 + "\\zoneone.mva";
      bool flag1 = false;
      bool flag2 = false;
      if (File.Exists(str4) && File.Exists(str5))
      {
        feature1.AddMultipleDefaultRecords(2);
        foreach (VoiceAnnouncementList announcementList in (Collection<AcpBusinessLayer.FeatureNode>) feature1)
        {
          if (announcementList.Position == 1)
          {
            AcpVoiceFileStruct newValue = new AcpVoiceFileStruct(str5);
            announcementList.General.VoiceAnnouncementEncodeType_A22264.SetValue(1);
            announcementList.General.VoiceAnnouncementFileHashcode_A24563.SetValue(newValue.hashcode);
            announcementList.General.VoiceFileDataInfo_A21213.SetValue(newValue);
            announcementList.General.VoiceFileName_A21220Object.Value = Path.GetFileNameWithoutExtension(str5);
            flag1 = announcementList.General.VoiceFileName_A21220Object.Valid;
          }
          else if (announcementList.Position == 2)
          {
            AcpVoiceFileStruct newValue = new AcpVoiceFileStruct(str4);
            announcementList.General.VoiceAnnouncementEncodeType_A22264.SetValue(1);
            announcementList.General.VoiceAnnouncementFileHashcode_A24563.SetValue(newValue.hashcode);
            announcementList.General.VoiceFileDataInfo_A21213.SetValue(newValue);
            announcementList.General.VoiceFileName_A21220Object.Value = Path.GetFileNameWithoutExtension(str4);
            flag2 = announcementList.General.VoiceFileName_A21220Object.Valid;
          }
        }
        if (flag1 && flag2)
        {
          try
          {
            if (FeatureManager.GetFeature(2051) is ZoneChannelAssignmentRecset feature2)
            {
              foreach (Motorola.MackinawCPS.CoreFeatures.ZoneChannelAssignment.ZoneChannelAssignment channelAssignment in (Collection<AcpBusinessLayer.FeatureNode>) feature2)
              {
                channelAssignment.Zone.ZoneVoiceAnnouncementID_A21514.SetRecset((IAcpRecordset) feature1);
                if (channelAssignment.Zone.ZoneVoiceAnnouncementID_A21514.Items.Count > 1 && channelAssignment.Zone.ZoneVoiceAnnouncementID_A21514.Items.Count < 4)
                {
                  channelAssignment.Zone.ZoneVoiceAnnouncementID_A21514.ReferencedIndex = 1;
                  if (channelAssignment.Channels.HasEmbeddedRecset && channelAssignment.Channels.EmbeddedRecset.Count > 0)
                  {
                    foreach (IAcpFeatureSection featureSections in channelAssignment.Channels.EmbeddedRecset[0].FeatureSectionsCollection)
                    {
                      if (featureSections.HasVisibleObjects && featureSections.FeatureSectionId == 10115)
                      {
                        ChannelAssignmentListInnerSection listInnerSection = featureSections as ChannelAssignmentListInnerSection;
                        listInnerSection.ChannelAnnouncementID_A20175.SetRecset((IAcpRecordset) feature1);
                        if (listInnerSection.ChannelAnnouncementID_A20175.Items.Count > 1 && listInnerSection.ChannelAnnouncementID_A20175.Items.Count < 4)
                          listInnerSection.ChannelAnnouncementID_A20175.ReferencedIndex = 2;
                      }
                    }
                  }
                }
              }
            }
          }
          catch (Exception ex)
          {
            exception = ex;
          }
        }
        else
        {
          while (feature1.Count > 0)
            feature1.RemoveRecordAt(0);
        }
      }
    }
    catch (Exception ex)
    {
      exception = ex;
    }
  }

  internal void SetTitleBar(string fName, string radioSN, Radio d)
  {
    string apxCpsDepot = AppResources.APX_CPS_DEPOT;
    string str = !UtilityMack.IsMobileOnly() ? (!UtilityMack.IsPortableOnly() ? AppResources._Unknown_Model_ : AppResources._Portable_) : AppResources._Mobile_;
    if (fName != null && fName != "" && radioSN == null)
    {
      if (fName.EndsWith("xml"))
        this.Title = $"{apxCpsDepot} - {fName}";
      else
        this.Title = $"{apxCpsDepot} {str} - {fName}";
    }
    else if (fName == null && radioSN != null && radioSN != "")
      this.Title = $"{apxCpsDepot} {str} - Device {radioSN}";
    else if (fName == null || fName == "" || radioSN == null)
      this.Title = apxCpsDepot;
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

  private bool authenticateCpgForRWPassword(
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
        bool flag2 = false;
        if (isForExport || this.deviceFromServer != null || this.templateFromServer != null || (bool) System.Windows.Application.Current.Properties[(object) "CommandLineCPS"])
          flag2 = false;
        flag1 = !flag2 || !radioWide.Labtool.RadWideLabtoolArchiveReadPasswordEnable_A7462Value || (!isNonGuiOpen ? ReadWritePasswordApp.ValidateOKToArchiveFile(radioWide.Labtool.RadWideLabtoolRadioPassword_A8837Value) : ReadWritePasswordApp.ValidateOKToUserPassword(password, radioWide.Labtool.RadWideLabtoolRadioPassword_A8837Value, false, (string) null));
      }
    }
    catch (Exception ex)
    {
    }
    if (!flag1)
    {
      document.docFilePath = (string) null;
      document.docFileName = (string) null;
      document.Clear();
    }
    return flag1;
  }

  public static void InjectRunCases()
  {
    if (WindowMain._appMainFrame == null)
      return;
    WindowMain._appMainFrame.RunCases();
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
        DataStoreDecryptHandler storeDecryptHandler = new DataStoreDecryptHandler();
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
        if (flag && storeDecryptHandler.isDHkeyExpired())
        {
          this.m_DHGeneration = new Thread(new ThreadStart(storeDecryptHandler.dhUpdateEventThread));
          this.m_DHGeneration.Start();
        }
      }
      catch
      {
      }
      try
      {
        TestCaseLauncher testCaseLauncher = new TestCaseLauncher();
        RuntimeInfo.ModeIdentifier = ModeIdentifier.Template;
        if (testCaseLauncher.ShallRunTestCase())
        {
          testCaseLauncher.OnTestFinished += new EventHandler(this.launcher_OnTestFinished);
          System.Windows.Application.Current.Dispatcher.BeginInvoke((Delegate) new Action(testCaseLauncher.Launch));
        }
      }
      catch
      {
      }
      WindowMain._appMainFrame = this;
    }
  }

  private void launcher_OnTestFinished(object sender, EventArgs e) => Environment.Exit(0);

  public void RunCases()
  {
    string[] casesfiles = Directory.GetFiles(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "*.cases");
    if (casesfiles.Length <= 0)
      return;
    new RMCWnd().ToString();
    if (RadioManagementBootstrapper.Connect())
      RadioManagementBootstrapper.LanuchForTestCase(PACIdentifier.ASTRO, "ASTROCPS_RMSERVER_RM");
    else
      Environment.Exit(1);
    BackgroundWorker backgroundWorker = new BackgroundWorker();
    backgroundWorker.RunWorkerCompleted += (RunWorkerCompletedEventHandler) ((sender, e) =>
    {
      if (e.Error != null)
        Environment.Exit(1);
      else
        Environment.Exit(0);
    });
    backgroundWorker.DoWork += (DoWorkEventHandler) ((sender, e) => TestCaseLauncher2.RunCases(casesfiles[0]));
    backgroundWorker.RunWorkerAsync();
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
      if (AppInfoManager.AppView == DifferentiatedUserViewType.Custom)
      {
        this.SavedCurrentViewType = DifferentiatedUserViewType.Custom;
        AppInfoManager.AppView = DifferentiatedUserViewType.Full;
      }
      this.InitDocument();
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

  internal bool CruncherReadRadio(int myTransport, bool isCruncherWriteCheckPBA = false)
  {
    this.ReadWriteInProgress = true;
    this.InitDocument();
    ((App) System.Windows.Application.Current).TheDocument.FileNew();
    UndoManager.StopUndoRedo();
    UndoManager.Reset();
    ConstraintManager.Suspend();
    string empty = string.Empty;
    bool flag = this.LaunchReadRadio(myTransport, ref empty, isCruncherWriteCheckPBA);
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
      if (this.PromptQuitOnInvalids())
        Logger.Log("Codeplug is invalid.");
      else if (this.SaveCodeplug())
      {
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
      throw CommonExceptionHelper.CreateCommonException(CommonErrorCode.RMC_UnableToInitializeRMC, Motorola.CommonCPS.ResourceRepository.Resources.RMC_UnableToInitializeRMC);
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
    bool flag1 = false;
    GC.Collect();
    GC.WaitForPendingFinalizers();
    GC.Collect();
    try
    {
      try
      {
        AcpFileHeader acpFileHeader = (AcpFileHeader) null;
        try
        {
          acpFileHeader = new AcpFileHandler().ReadHeader(sFileName);
          this.cpgFileName = sFileName;
        }
        catch (Exception ex)
        {
          acpFileHeader = new AcpFileHeader();
        }
        if (sFileName.EndsWith(".mc"))
        {
          AppInfoManager.AppVersion = this.cpsVersion;
          flag1 = ((App) System.Windows.Application.Current).TheDocument.FileOpen(sFileName);
          bool enable41305UiValue = (FeatureManager.GetFeature(2045)[0] as Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide).UserInformationAndPasswords.RadWideUserInformationandUserLoginUnitIDEnable_41305_UIValue;
          if (flag1)
            this.UclTemplateNodeInit();
        }
        else if (sFileName.EndsWith(".xpba"))
        {
          this.InitDocument();
          ((App) System.Windows.Application.Current).TheDocument.FileNew();
          UndoManager.StopUndoRedo();
          UndoManager.Reset();
          ConstraintManager.Suspend();
          flag1 = Cruncher.Instance.UnpackXPBA(sFileName);
          if (flag1)
          {
            this.ResolveUCLReferenceAfterUnpack();
            this.ResolvedMFKTimerUnpack();
            ((App) System.Windows.Application.Current).TheDocument.docFileName = Path.GetFileName(sFileName);
            ((App) System.Windows.Application.Current).TheDocument.docFilePath = Path.GetFullPath(sFileName);
          }
        }
      }
      catch
      {
        flag1 = false;
        throw new CommonException(new CommonExceptionData(CommonErrorCode.RMC_File_colon_could_not_be_opened, new string[2]
        {
          Path.GetFileName(sFileName),
          AcpDocument.CpgVersionErrStr
        }));
      }
      if (flag1)
      {
        if (!isSkipPasswordCheck && !this.authenticateCpgForRWPassword(((App) System.Windows.Application.Current).TheDocument, password, isNonGuiOpen))
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
        DateTime now = DateTime.Now;
        now = DateTime.Now;
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
        }
        bool flag2 = this.O9TableInit();
        this.DEKVipTableInit();
        this.PresetZoneChannelTableInit();
        this.KeypadRecsetAndTableInit();
        this.O2MFKTableInit();
        this.O7MFKTableInit();
        this.O2NavigationControlsTableInit();
        this.O7NavigationControlsTableInit();
        this.O3NavigationControlsTableInit();
        this.O5NavigationControlsTableInit();
        this.O9NavigationControlsTableInit();
        this.KMANavigationControlsTableInit();
        this.SmartKeyFobTableInit();
        this.SideArrowTableInit();
        this.SiteSelectableAlertTableInit();
        this.AddQC2DefaultRecord();
        ((App) System.Windows.Application.Current).TheDocument.Initialized(false);
        ConstraintManager.Suspend();
        this.updateUnpackedFields(false, (RadioParams) null);
        if (flag2)
          this.AddO9PhephedRecord();
        this.SyncO9PASirenButtons();
        this.O9DirectionalButtonsFixup();
        this.UpdateAuxControlTable();
        ConstraintManager.Resume();
        this.RefreshScanlistMap();
        this.DataProfileTrunkingGroupIDFixup();
      }
      else
      {
        ((App) System.Windows.Application.Current).TheDocument.FileClose();
        if (AppInfoManager.NonEngOldCodeplug)
          throw new CommonException(new CommonExceptionData(CommonErrorCode.RMC_File_colon_Cannot_Open_Old_CP_NonEng, new string[1]
          {
            Path.GetFileName(sFileName)
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
      flag1 = false;
      throw;
    }
    finally
    {
      UndoManager.Reset();
    }
    return flag1;
  }

  internal bool OpenCodeplugNonGUI(
    string sFileName,
    ref string errorMessage,
    bool isSkipPasswordCheck,
    AstroDeviceInfo deviceInfo = null)
  {
    bool flag1 = false;
    GC.Collect();
    GC.WaitForPendingFinalizers();
    GC.Collect();
    string initialDirectory = AcpFileDialog.InitialDirectory;
    try
    {
      AcpOpenFileDialog acpOpenFileDialog = new AcpOpenFileDialog();
      acpOpenFileDialog.Filter = AppResources.Motorola_Codeplug_Filter;
      acpOpenFileDialog.MultiSelect = false;
      bool flag2 = true;
      AcpFileHeader acpFileHeader = (AcpFileHeader) null;
      if (string.IsNullOrEmpty(sFileName))
      {
        AcpFileHeader fileHeader = new AcpFileHeader();
        AcpFileDialog.InitialDirectory = ((App) System.Windows.Application.Current).TheDocument.docFilePath != null || !(this.lastOpenCodePlugPath != string.Empty) ? ((App) System.Windows.Application.Current).TheDocument.docFilePath : this.lastOpenCodePlugPath;
        bool? nullable = acpOpenFileDialog.ShowDialog(fileHeader);
        if ((!nullable.GetValueOrDefault() ? 0 : (nullable.HasValue ? 1 : 0)) != 0)
        {
          sFileName = acpOpenFileDialog.FileName;
          this.cpgFileName = sFileName;
          this.lastOpenCodePlugPath = Path.GetDirectoryName(acpOpenFileDialog.FileName);
          if ((int) this.lastOpenCodePlugPath[this.lastOpenCodePlugPath.Length - 1] != (int) Path.DirectorySeparatorChar)
            this.lastOpenCodePlugPath += (string) (object) Path.DirectorySeparatorChar;
        }
        else
          flag2 = false;
      }
      else
      {
        try
        {
          acpFileHeader = new AcpFileHandler().ReadHeader(sFileName);
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
          flag1 = ((App) System.Windows.Application.Current).TheDocument.FileOpen(sFileName);
          if (flag1)
            this.UclTemplateNodeInit();
        }
        else if (sFileName.EndsWith(".xpba"))
        {
          this.InitDocument();
          ((App) System.Windows.Application.Current).TheDocument.FileNew();
          UndoManager.StopUndoRedo();
          UndoManager.Reset();
          ConstraintManager.Suspend();
          flag1 = Cruncher.Instance.UnpackXPBA(sFileName);
          if (flag1)
          {
            this.ResolveUCLReferenceAfterUnpack();
            ((App) System.Windows.Application.Current).TheDocument.docFileName = Path.GetFileName(sFileName);
            ((App) System.Windows.Application.Current).TheDocument.docFilePath = Path.GetFullPath(sFileName);
          }
        }
        if (flag1)
        {
          bool passedAuthentication = false;
          Exception exception;
          try
          {
            Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide codeplgRadioWide = FeatureManager.GetFeature(2045)[0] as Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide;
            if (codeplgRadioWide != null)
            {
              bool flag3 = true;
              if ((bool) System.Windows.Application.Current.Properties[(object) "CommandLineCPS"] || isSkipPasswordCheck)
                flag3 = false;
              if (flag3 && codeplgRadioWide.Labtool.RadWideLabtoolArchiveReadPasswordEnable_A7462Value)
                this.Dispatcher.Invoke((Action) (() => passedAuthentication = ReadWritePasswordApp.ValidateOKToArchiveFile(codeplgRadioWide.Labtool.RadWideLabtoolRadioPassword_A8837Value)));
              else
                passedAuthentication = true;
            }
          }
          catch (Exception ex)
          {
            exception = ex;
          }
          finally
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
              exception = ex;
            }
            DateTime now = DateTime.Now;
            now = DateTime.Now;
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
            }
            bool flag4 = this.O9TableInit();
            this.DEKVipTableInit();
            this.PresetZoneChannelTableInit();
            this.KeypadRecsetAndTableInit();
            this.AddQC2DefaultRecord();
            ((App) System.Windows.Application.Current).TheDocument.Initialized(false);
            ConstraintManager.Suspend();
            this.updateUnpackedFields(false, (RadioParams) null);
            if (flag4)
              this.AddO9PhephedRecord();
            this.SyncO9PASirenButtons();
            this.O9DirectionalButtonsFixup();
            this.UpdateAuxControlTable();
            ConstraintManager.Resume();
            this.RefreshScanlistMap();
            this.DataProfileTrunkingGroupIDFixup();
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
            {
              ref string local = ref errorMessage;
              local = $"{local} {AcpDocument.CpgVersionErrStr}";
            }
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
      if (initialDirectory != AcpFileDialog.InitialDirectory)
        AcpFileDialog.InitialDirectory = initialDirectory;
    }
    return flag1;
  }

  internal void CloseFileNonGUI(bool isForExport = true)
  {
    AcpDocument theDocument = ((App) System.Windows.Application.Current).TheDocument;
    if (theDocument != null)
    {
      theDocument.ModificationLogEnabled = false;
      theDocument.FileClose();
      if (((App) System.Windows.Application.Current).TheDocument.docFilePath != null)
      {
        this.lastOpenCodePlugPath = Path.GetDirectoryName(((App) System.Windows.Application.Current).TheDocument.docFilePath);
        if ((int) this.lastOpenCodePlugPath[this.lastOpenCodePlugPath.Length - 1] != (int) Path.DirectorySeparatorChar)
          this.lastOpenCodePlugPath += (string) (object) Path.DirectorySeparatorChar;
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
        dataProfiles.General.DataProfGeneralMobileComputerIPAddress_A8523.IsEditable = new StateConstraint(DataProfilesConstraints.conNonEditableWhenOpenFromRMC);
        dataProfiles.General.DataProfGeneralSubscriberIPAddress_A21157.IsEditable = new StateConstraint(DataProfilesConstraints.conNonEditableWhenOpenFromRMC);
        dataProfiles.General.DataProfilesGeneralBTDUNSUIPAddress_A41126.IsEditable = new StateConstraint(DataProfilesConstraints.conNonEditableWhenOpenFromRMC);
        dataProfiles.General.DataProfilesGeneralBTDUNPeerIPAddress_A41127.IsEditable = new StateConstraint(DataProfilesConstraints.conNonEditableWhenOpenFromRMC);
      }
      else
      {
        dataProfiles.General.DataProfGeneralMobileComputerIPAddress_A8523.IsEditable = new StateConstraint(DataProfilesConstraints.conDataProfileTypeIsConventionalAndAutoGenIpAddrDisabledEditbl);
        dataProfiles.General.DataProfGeneralSubscriberIPAddress_A21157.IsEditable = new StateConstraint(DataProfilesConstraints.conDataProfileTypeIsConventionalAndAutoGenIpAddrDisabledEditbl);
        dataProfiles.General.DataProfilesGeneralBTDUNSUIPAddress_A41126.IsEditable = new StateConstraint(DataProfilesConstraints.conDataProfileTypeIsConventionalAndAutoGenIpAddrDisabledEditbl);
        dataProfiles.General.DataProfilesGeneralBTDUNPeerIPAddress_A41127.IsEditable = new StateConstraint(DataProfilesConstraints.conDataProfileTypeIsConventionalAndAutoGenIpAddrDisabledEditbl);
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
    if (embeddedRecset[1] is O2NavigationControlsTableInner controlsTableInner)
    {
      O2NavigationControlsTableInnerSection tableInnerSection = controlsTableInner.O2NavigationControlsTableInnerSection;
      tableInnerSection.RadErgoControlO2UpDownButton_A41278.SetValue(144 /*0x90*/);
      tableInnerSection.O2UpDownButtonName_A41277.SetValue(AppResources.Down_Button);
    }
  }

  private void O7NavigationControlsTableInit()
  {
    if (!(FeatureManager.GetFeature(4114) is ControlHeadO7Recset feature) || !(feature[0][10727].EmbeddedRecset is O7NavigationControlsTableInnerRecset embeddedRecset) || embeddedRecset.Count >= 2)
      return;
    while (embeddedRecset.Count < 2)
      embeddedRecset.AddRecord(embeddedRecset.CreateDefaultRecord());
    if (embeddedRecset[1] is O7NavigationControlsTableInner controlsTableInner)
    {
      O7NavigationControlsTableInnerSection tableInnerSection = controlsTableInner.O7NavigationControlsTableInnerSection;
      tableInnerSection.RadErgoControlO7UpDownButton_A41293.SetValue(144 /*0x90*/);
      tableInnerSection.O7UpDownButtonName_A41292.SetValue(AppResources.Down_Button);
    }
  }

  private void O3NavigationControlsTableInit()
  {
    if (!(FeatureManager.GetFeature(2127) is ControlHeadO3Recset feature) || !(feature[0][10732].EmbeddedRecset is O3NavigationControlsTableInnerRecset embeddedRecset) || embeddedRecset.Count >= 2)
      return;
    while (embeddedRecset.Count < 2)
      embeddedRecset.AddRecord(embeddedRecset.CreateDefaultRecord());
    if (embeddedRecset[1] is O3NavigationControlsTableInner controlsTableInner)
    {
      O3NavigationControlsTableInnerSection tableInnerSection = controlsTableInner.O3NavigationControlsTableInnerSection;
      tableInnerSection.RadErgoControlO3NaviControlFeature_A41375.SetValue(144 /*0x90*/);
      tableInnerSection.RadErgoControlO3NaviControlName_A41374.SetValue(AppResources.Down_Button);
    }
  }

  private void O5NavigationControlsTableInit()
  {
    if (!(FeatureManager.GetFeature(2130) is ControlHeadO5Recset feature) || !(feature[0][10735].EmbeddedRecset is O5NavigationControlsTableInnerRecset embeddedRecset) || embeddedRecset.Count >= 2)
      return;
    while (embeddedRecset.Count < 2)
      embeddedRecset.AddRecord(embeddedRecset.CreateDefaultRecord());
    if (embeddedRecset[1] is O5NavigationControlsTableInner controlsTableInner)
    {
      O5NavigationControlsTableInnerSection tableInnerSection = controlsTableInner.O5NavigationControlsTableInnerSection;
      tableInnerSection.RadErgoControlO5NaviControlFeature_A41379.SetValue(144 /*0x90*/);
      tableInnerSection.RadErgoControlO5NaviControlName_A41378.SetValue(AppResources.Down_Button);
    }
  }

  private void KMANavigationControlsTableInit()
  {
    if (!(FeatureManager.GetFeature(2128) is KeypadMicAndAccessoriesRecset feature) || !(feature[0][10753].EmbeddedRecset is KMANavigationControlsTableInnerRecset embeddedRecset) || embeddedRecset.Count >= 2)
      return;
    while (embeddedRecset.Count < 2)
      embeddedRecset.AddRecord(embeddedRecset.CreateDefaultRecord());
    if (embeddedRecset[1] is KMANavigationControlsTableInner controlsTableInner)
    {
      KMANavigationControlsTableInnerSection tableInnerSection = controlsTableInner.KMANavigationControlsTableInnerSection;
      tableInnerSection.RadErgoControlKMAUpDownButton_41760.SetValue(144 /*0x90*/);
      tableInnerSection.RadErgoControlKMANaviControlName_41759.SetValue(AppResources.Down_Button);
    }
  }

  private void O9NavigationControlsTableInit()
  {
    if (!(FeatureManager.GetFeature(4003) is ControlHeadO9Recset feature) || !(feature[0][10731].EmbeddedRecset is O9NavigationControlsTableInnerRecset embeddedRecset) || embeddedRecset.Count >= 2)
      return;
    while (embeddedRecset.Count < 2)
      embeddedRecset.AddRecord(embeddedRecset.CreateDefaultRecord());
    if (embeddedRecset[1] is O9NavigationControlsTableInner controlsTableInner)
    {
      O9NavigationControlsTableInnerSection tableInnerSection = controlsTableInner.O9NavigationControlsTableInnerSection;
      tableInnerSection.RadErgoControlO9NaviControlFeature_A41371.SetValue(144 /*0x90*/);
      tableInnerSection.RadErgoControlO9NaviControlName_A41370.SetValue(AppResources.Down_Button);
    }
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
    if (controlInnerSection != null)
    {
      controlInnerSection.RadErgoControlO2MFKFeatureAssignment_A41275.SetValue(29);
      controlInnerSection.O2MFKAssignmentControlName_A41274.SetValue(AppResources.Secondary_Function);
    }
  }

  private void O7MFKTableInit()
  {
    if (!(FeatureManager.GetFeature(4114) is ControlHeadO7Recset feature) || !(feature[0][10718].EmbeddedRecset is O7MFKAssignmentControlInnerRecset embeddedRecset) || embeddedRecset.Count >= 2)
      return;
    while (embeddedRecset.Count < 2)
      embeddedRecset.AddRecord(embeddedRecset.CreateDefaultRecord());
    O7MFKAssignmentControlInnerSection controlInnerSection = (embeddedRecset[1] as O7MFKAssignmentControlInner).O7MFKAssignmentControlInnerSection;
    if (controlInnerSection != null)
    {
      controlInnerSection.RadErgoControlO7MFKFeatureAssignment_A41295.SetValue(29);
      controlInnerSection.O7MFKAssignmentControlName_A41294.SetValue(AppResources.Secondary_Function);
    }
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

  private void UpdateO2O7Emergency()
  {
    if (!(FeatureManager.GetFeature(2130) is ControlHeadO5Recset feature1))
      return;
    O5Inner o5Inner = (feature1[0][10227].EmbeddedRecset as O5InnerRecset)[0] as O5Inner;
    if (FeatureManager.GetFeature(4115) is ControlHeadO2Recset feature2)
      ((feature2[0][10723].EmbeddedRecset as O2InnerRecset)[0][10716] as O2InnerSection).CHO2EmergencyButtonFeature_A41272.SetValue(o5Inner.O5InnerSection.CntrlHeadO5SignalIndependentO5M5MXChiefCHButtonButtonFeature_A19754.Value);
    if (FeatureManager.GetFeature(4114) is ControlHeadO7Recset feature3)
      ((feature3[0][10719].EmbeddedRecset as O7InnerRecset)[0][10715] as O7InnerSection).CHO7EmergencyButtonFeature_A41291.SetValue(o5Inner.O5InnerSection.CntrlHeadO5SignalIndependentO5M5MXChiefCHButtonButtonFeature_A19754.Value);
  }

  private void ChangeACAsAllOff()
  {
    try
    {
      if (!(FeatureManager.GetFeature(4008) is ActionConsolidationRecset feature) || feature.Count < 2)
        return;
      Motorola.MackinawCPS.CoreFeatures.ActionConsolidation.General general = (feature[1] as Motorola.MackinawCPS.CoreFeatures.ActionConsolidation.ActionConsolidation).General;
      if (general != null)
      {
        general.RadioErgoConfigACRelayPattern_A36582.UIValue = MTFResources.All_off;
        general.RadioErgoConfigACSirenType_A36584.UIValue = AcgResources.ID_OFF;
      }
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
    if (fileName.EndsWith(".mc") && this.Focus())
      this.OpenCodeplug(fileName);
    else
      AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, AppResources.could_not_be_opened);
  }

  private void WindowMain_AllowDrop(object sender, System.Windows.Input.MouseEventArgs e)
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

  private void HandleInValidFieldBackwardCompatibilityForMCFile()
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
    if ((this.MyModelNumber.Equals("H99QDD9PW5AN") || this.MyModelNumber.Equals("H99KGD9PW5AN") || this.MyModelNumber.Equals("H99UCD9PW5AN") || this.MyModelNumber.Equals("H98UCD9PW5AN") || this.MyModelNumber.Equals("H98QDD9PW5AN") || this.MyModelNumber.Equals("H98SDD9PW5AN") || this.MyModelNumber.Equals("H98KGD9PW5AN") || this.MyModelNumber.Equals("H49TGD9PW1AN") && !flag1) && !flag2 || UtilityMack.IsMobile())
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
    if (programmableButtonListInner3 != null)
    {
      programmableButtonListInner3.SignalIndependentProductIndependentNonProgrammableButtonListInnerSection.RadErgoCfgSignalIndependentProductIndependentNonProgrammableButtonBCO_A19777.SetValue(46);
      programmableButtonListInner3.SignalIndependentProductIndependentNonProgrammableButtonListInnerSection.RadErgoCfgSignalIndependentProductIndependentNonProgrammableButtonFeature_A19778.SetValue(231);
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
    bool? nullable = saveFileDialog.ShowDialog();
    if ((!nullable.GetValueOrDefault() ? 0 : (nullable.HasValue ? 1 : 0)) == 0)
      return;
    string fileName = saveFileDialog.FileName;
    if (fileName != null && fileName.EndsWith(".xml"))
    {
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
      if (num8 == num1)
      {
        int index6 = num2 + 1 + 22;
        string str = Encoding.BigEndianUnicode.GetString(partitionArr, index6, 34);
        int length2 = str.IndexOf(char.MinValue);
        return str.Substring(0, length2);
      }
    }
    return modelNumber;
  }

  internal static void AddAllFeatures()
  {
    CodeplugStatusManager.Status = CodeplugStatus.Opening;
    ConstraintManager.Suspend();
    FeatureManager.AddFeature((IAcpRecordset) new NonGUIFeatureRecset());
    FeatureManager.AddFeature((IAcpRecordset) new PhoneWideRecset());
    FeatureManager.AddFeature((IAcpRecordset) new FactoryOverridesRecset());
    FeatureManager.AddFeature((IAcpRecordset) new ConventionalAliasListsRecset());
    FeatureManager.AddFeature((IAcpRecordset) new DisplayAndMenuRecset());
    FeatureManager.AddFeature((IAcpRecordset) new ShepherdsRecset());
    FeatureManager.AddFeature((IAcpRecordset) new SecureWideRecset());
    FeatureManager.AddFeature((IAcpRecordset) new ScanWideRecset());
    FeatureManager.AddFeature((IAcpRecordset) new ConventionalWideRecset());
    FeatureManager.AddFeature((IAcpRecordset) new TrunkingWideRecset());
    FeatureManager.AddFeature((IAcpRecordset) new DataWideRecset());
    FeatureManager.AddFeature((IAcpRecordset) new EmergencyWideRecset());
    FeatureManager.AddFeature((IAcpRecordset) new RadioErgonomicsWideRecset());
    FeatureManager.AddFeature((IAcpRecordset) new RepeaterIDListRecset());
    FeatureManager.AddFeature((IAcpRecordset) new RemoteSpeakerMicRecset());
    FeatureManager.AddFeature((IAcpRecordset) new SwitchesRecset());
    FeatureManager.AddFeature((IAcpRecordset) new ButtonsRecset());
    FeatureManager.AddFeature((IAcpRecordset) new RadioWideRecset());
    FeatureManager.AddFeature((IAcpRecordset) new RadioInformationRecset());
    FeatureManager.AddFeature((IAcpRecordset) new ZoneChannelAssignmentRecset());
    FeatureManager.AddFeature((IAcpRecordset) new ConventionalSystemRecset());
    FeatureManager.AddFeature((IAcpRecordset) new DataProfilesRecset());
    FeatureManager.AddFeature((IAcpRecordset) new SecureKMFProfileRecset());
    FeatureManager.AddFeature((IAcpRecordset) new ScanListRecset());
    FeatureManager.AddFeature((IAcpRecordset) new ConventionalPersonalityRecset());
    FeatureManager.AddFeature((IAcpRecordset) new ASTROTalkgroupListRecset());
    FeatureManager.AddFeature((IAcpRecordset) new TrunkingSystemRecset());
    FeatureManager.AddFeature((IAcpRecordset) new TrunkingPersonalityRecset());
    FeatureManager.AddFeature((IAcpRecordset) new ConventionalEmergencyProfilesRecset());
    FeatureManager.AddFeature((IAcpRecordset) new TrunkingEmergencyProfilesRecset());
    FeatureManager.AddFeature((IAcpRecordset) new RadioProfilesRecset());
    FeatureManager.AddFeature((IAcpRecordset) new MPLConfigurationRecset());
    FeatureManager.AddFeature((IAcpRecordset) new InternalMicNoiseReductionProfileRecset());
    FeatureManager.AddFeature((IAcpRecordset) new ExternalMicNoiseReductionProfileRecset());
    FeatureManager.AddFeature((IAcpRecordset) new MenuItemsRecset());
    FeatureManager.AddFeature((IAcpRecordset) new RadioVIPsRecset());
    FeatureManager.AddFeature((IAcpRecordset) new ControlHeadO3Recset());
    FeatureManager.AddFeature((IAcpRecordset) new KeypadMicAndAccessoriesRecset());
    FeatureManager.AddFeature((IAcpRecordset) new DEKRecset());
    FeatureManager.AddFeature((IAcpRecordset) new ControlHeadO5Recset());
    FeatureManager.AddFeature((IAcpRecordset) new GlobalNoiseReductionListRecset());
    FeatureManager.AddFeature((IAcpRecordset) new ControlHeadO9Recset());
    FeatureManager.AddFeature((IAcpRecordset) new ActionConsolidationRecset());
    FeatureManager.AddFeature((IAcpRecordset) new KeypadRecset());
    FeatureManager.AddFeature((IAcpRecordset) new ControlHeadO7Recset());
    FeatureManager.AddFeature((IAcpRecordset) new ControlHeadO2Recset());
    FeatureManager.AddFeature((IAcpRecordset) new SmartKeyFobRecset());
    FeatureManager.AddFeature((IAcpRecordset) new DVRSWideRecset());
    FeatureManager.AddFeature((IAcpRecordset) new DVRSProfilesRecset());
    FeatureManager.AddFeature((IAcpRecordset) new EnhancedDataPortListRecset());
    FeatureManager.AddFeature((IAcpRecordset) new ToneSignalingListRecset());
    FeatureManager.AddFeature((IAcpRecordset) new MissionCriticalGeofenceRecset());
    FeatureManager.AddFeature((IAcpRecordset) new PersonnelAccountabilityRecset());
    FeatureManager.AddFeature((IAcpRecordset) new UclWideRecset());
    FeatureManager.AddFeature((IAcpRecordset) new UclContactRecset());
    FeatureManager.AddFeature((IAcpRecordset) new UclTrunkingCallHotListRecset());
    FeatureManager.AddFeature((IAcpRecordset) new UclTrunkingT2CallHotListRecset());
    FeatureManager.AddFeature((IAcpRecordset) new UclAstroCallHotListRecset());
    FeatureManager.AddFeature((IAcpRecordset) new UclMDCCallHotListRecset());
    FeatureManager.AddFeature((IAcpRecordset) new UclPhoneCallHotListRecset());
    FeatureManager.AddFeature((IAcpRecordset) new VoiceAnnouncementListRecSet());
    FeatureManager.AddFeature((IAcpRecordset) new VoiceAnnouncementWideRecSet());
    FeatureManager.AddFeature((IAcpRecordset) new SiteSelectableAlertListRecset());
    ConstraintManager.Resume();
    CodeplugStatusManager.Status = CodeplugStatus.Opened;
  }

  internal static void AddAllFeatures(Document doc)
  {
    FeatureManager.AddFeature(doc, (IAcpRecordset) new NonGUIFeatureRecset());
    FeatureManager.AddFeature(doc, (IAcpRecordset) new PhoneWideRecset());
    FeatureManager.AddFeature(doc, (IAcpRecordset) new FactoryOverridesRecset());
    FeatureManager.AddFeature(doc, (IAcpRecordset) new ConventionalAliasListsRecset());
    FeatureManager.AddFeature(doc, (IAcpRecordset) new DisplayAndMenuRecset());
    FeatureManager.AddFeature(doc, (IAcpRecordset) new ShepherdsRecset());
    FeatureManager.AddFeature(doc, (IAcpRecordset) new SecureWideRecset());
    FeatureManager.AddFeature(doc, (IAcpRecordset) new ScanWideRecset());
    FeatureManager.AddFeature(doc, (IAcpRecordset) new ConventionalWideRecset());
    FeatureManager.AddFeature(doc, (IAcpRecordset) new TrunkingWideRecset());
    FeatureManager.AddFeature(doc, (IAcpRecordset) new DataWideRecset());
    FeatureManager.AddFeature(doc, (IAcpRecordset) new EmergencyWideRecset());
    FeatureManager.AddFeature(doc, (IAcpRecordset) new RadioErgonomicsWideRecset());
    FeatureManager.AddFeature(doc, (IAcpRecordset) new RepeaterIDListRecset());
    FeatureManager.AddFeature(doc, (IAcpRecordset) new RemoteSpeakerMicRecset());
    FeatureManager.AddFeature(doc, (IAcpRecordset) new SwitchesRecset());
    FeatureManager.AddFeature(doc, (IAcpRecordset) new ButtonsRecset());
    FeatureManager.AddFeature(doc, (IAcpRecordset) new RadioWideRecset());
    FeatureManager.AddFeature(doc, (IAcpRecordset) new RadioInformationRecset());
    FeatureManager.AddFeature(doc, (IAcpRecordset) new ZoneChannelAssignmentRecset());
    FeatureManager.AddFeature(doc, (IAcpRecordset) new ConventionalSystemRecset());
    FeatureManager.AddFeature(doc, (IAcpRecordset) new DataProfilesRecset());
    FeatureManager.AddFeature(doc, (IAcpRecordset) new SecureKMFProfileRecset());
    FeatureManager.AddFeature(doc, (IAcpRecordset) new ScanListRecset());
    FeatureManager.AddFeature(doc, (IAcpRecordset) new ConventionalPersonalityRecset());
    FeatureManager.AddFeature(doc, (IAcpRecordset) new ASTROTalkgroupListRecset());
    FeatureManager.AddFeature(doc, (IAcpRecordset) new TrunkingSystemRecset());
    FeatureManager.AddFeature(doc, (IAcpRecordset) new TrunkingPersonalityRecset());
    FeatureManager.AddFeature(doc, (IAcpRecordset) new ConventionalEmergencyProfilesRecset());
    FeatureManager.AddFeature(doc, (IAcpRecordset) new TrunkingEmergencyProfilesRecset());
    FeatureManager.AddFeature(doc, (IAcpRecordset) new RadioProfilesRecset());
    FeatureManager.AddFeature(doc, (IAcpRecordset) new MPLConfigurationRecset());
    FeatureManager.AddFeature(doc, (IAcpRecordset) new InternalMicNoiseReductionProfileRecset());
    FeatureManager.AddFeature(doc, (IAcpRecordset) new ExternalMicNoiseReductionProfileRecset());
    FeatureManager.AddFeature(doc, (IAcpRecordset) new MenuItemsRecset());
    FeatureManager.AddFeature(doc, (IAcpRecordset) new RadioVIPsRecset());
    FeatureManager.AddFeature(doc, (IAcpRecordset) new ControlHeadO3Recset());
    FeatureManager.AddFeature(doc, (IAcpRecordset) new KeypadMicAndAccessoriesRecset());
    FeatureManager.AddFeature(doc, (IAcpRecordset) new DEKRecset());
    FeatureManager.AddFeature(doc, (IAcpRecordset) new ControlHeadO5Recset());
    FeatureManager.AddFeature(doc, (IAcpRecordset) new GlobalNoiseReductionListRecset());
    FeatureManager.AddFeature(doc, (IAcpRecordset) new ControlHeadO9Recset());
    FeatureManager.AddFeature(doc, (IAcpRecordset) new ActionConsolidationRecset());
    FeatureManager.AddFeature(doc, (IAcpRecordset) new KeypadRecset());
    FeatureManager.AddFeature(doc, (IAcpRecordset) new ControlHeadO7Recset());
    FeatureManager.AddFeature(doc, (IAcpRecordset) new ControlHeadO2Recset());
    FeatureManager.AddFeature(doc, (IAcpRecordset) new SmartKeyFobRecset());
    FeatureManager.AddFeature(doc, (IAcpRecordset) new DVRSWideRecset());
    FeatureManager.AddFeature(doc, (IAcpRecordset) new DVRSProfilesRecset());
    FeatureManager.AddFeature(doc, (IAcpRecordset) new EnhancedDataPortListRecset());
    FeatureManager.AddFeature(doc, (IAcpRecordset) new ToneSignalingListRecset());
    FeatureManager.AddFeature(doc, (IAcpRecordset) new MissionCriticalGeofenceRecset());
    FeatureManager.AddFeature(doc, (IAcpRecordset) new PersonnelAccountabilityRecset());
    FeatureManager.AddFeature(doc, (IAcpRecordset) new UclWideRecset());
    FeatureManager.AddFeature(doc, (IAcpRecordset) new UclContactRecset());
    FeatureManager.AddFeature(doc, (IAcpRecordset) new UclTrunkingCallHotListRecset());
    FeatureManager.AddFeature(doc, (IAcpRecordset) new UclTrunkingT2CallHotListRecset());
    FeatureManager.AddFeature(doc, (IAcpRecordset) new UclAstroCallHotListRecset());
    FeatureManager.AddFeature(doc, (IAcpRecordset) new UclMDCCallHotListRecset());
    FeatureManager.AddFeature(doc, (IAcpRecordset) new UclPhoneCallHotListRecset());
    FeatureManager.AddFeature(doc, (IAcpRecordset) new VoiceAnnouncementListRecSet());
    FeatureManager.AddFeature(doc, (IAcpRecordset) new VoiceAnnouncementWideRecSet());
    FeatureManager.AddFeature(doc, (IAcpRecordset) new SiteSelectableAlertListRecset());
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
  public void InitializeComponent()
  {
    if (this._contentLoaded)
      return;
    this._contentLoaded = true;
    System.Windows.Application.LoadComponent((object) this, new Uri("/APXFamilyCPS;component/windowmain.xaml", UriKind.Relative));
  }

  [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
  [SuppressMessage("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
  [EditorBrowsable(EditorBrowsableState.Never)]
  [SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
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
        this.AppMenuSaveAs = (ButtonDropDown) target;
        this.AppMenuSaveAs.Click += new RoutedEventHandler(this.OnAppMenuSaveAs);
        break;
      case 11:
        this.AppMenuImport = (ButtonDropDown) target;
        this.AppMenuImport.Click += new RoutedEventHandler(this.OnAppMenuImport);
        break;
      case 12:
        this.AppMenuExport = (ButtonDropDown) target;
        this.AppMenuExport.Click += new RoutedEventHandler(this.OnAppMenuExport);
        break;
      case 13:
        this.AppMenuRMC = (ButtonDropDown) target;
        this.AppMenuRMC.Click += new RoutedEventHandler(this.OnAppMenuRadioManagement);
        break;
      case 14:
        this.AppMenuRMCSep = (Separator) target;
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
        this.RadioHandOutO5 = (ButtonDropDown) target;
        this.RadioHandOutO5.Click += new RoutedEventHandler(this.OnPrtHandOutReportsO5);
        break;
      case 21:
        this.RadioHandOutO7 = (ButtonDropDown) target;
        this.RadioHandOutO7.Click += new RoutedEventHandler(this.OnPrtHandOutReportsO7);
        break;
      case 22:
        this.RadioHandOutO9 = (ButtonDropDown) target;
        this.RadioHandOutO9.Click += new RoutedEventHandler(this.OnPrtHandOutReportsO9);
        break;
      case 23:
        this.RadioUserDefined = (ButtonDropDown) target;
        this.RadioUserDefined.Click += new RoutedEventHandler(this.OnPrtCustomTplReports);
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
        this.ribbonBarEdit = (RibbonBar) target;
        break;
      case 36:
        this.QATUndo = (ButtonDropDown) target;
        this.QATUndo.Click += new RoutedEventHandler(this.OnQATUndo);
        break;
      case 37:
        this.QATRedo = (ButtonDropDown) target;
        this.QATRedo.Click += new RoutedEventHandler(this.OnQATRedo);
        break;
      case 38:
        this.ribbonBarRestore = (RibbonBar) target;
        this.ribbonBarRestore.GotFocus += new RoutedEventHandler(this.OnRibbonBarRestoreButtonsGotFoucs);
        this.ribbonBarRestore.LostFocus += new RoutedEventHandler(this.OnRibbonBarRestoreButtonsLostFocus);
        break;
      case 39:
        this.RibbonBarRtd = (ButtonDropDown) target;
        break;
      case 40:
        this.ribbonBarShowRtdButtons = (ButtonDropDown) target;
        this.ribbonBarShowRtdButtons.Click += new RoutedEventHandler(this.OnRibbonBarShowRtdButtons);
        break;
      case 41:
        this.RibbonBarRtdPageRestoreAll = (ButtonDropDown) target;
        this.RibbonBarRtdPageRestoreAll.Click += new RoutedEventHandler(this.OnRibbonBarPageRestoreAll);
        break;
      case 42:
        this.RibbonBarRtdInvalidsRestoreAll = (ButtonDropDown) target;
        this.RibbonBarRtdInvalidsRestoreAll.Click += new RoutedEventHandler(this.OnRibbonBarPageRestoreAllInvalids);
        break;
      case 43:
        this.RibbonBarSearch = (RibbonBar) target;
        break;
      case 44:
        this.FindToken = (System.Windows.Controls.TextBox) target;
        this.FindToken.KeyDown += new System.Windows.Input.KeyEventHandler(this.OnFindTokenKeyDown);
        break;
      case 45:
        this.RibbonBarEditingFind = (ButtonDropDown) target;
        break;
      case 46:
        this.RibbonBarEditingFindFieldName = (ButtonDropDown) target;
        this.RibbonBarEditingFindFieldName.Click += new RoutedEventHandler(this.OnFindFieldName);
        break;
      case 47:
        this.RibbonBarEditingFindFieldNameAndValue = (ButtonDropDown) target;
        this.RibbonBarEditingFindFieldNameAndValue.Click += new RoutedEventHandler(this.OnFindFieldNameAndValue);
        break;
      case 48 /*0x30*/:
        this.RibbonBarCompCodeplugStartEnd = (ButtonDropDown) target;
        this.RibbonBarCompCodeplugStartEnd.Click += new RoutedEventHandler(this.OnRibbonBarCompCodeplug);
        break;
      case 49:
        this.RibbonBarCompCodeplugStartEndImage = (Image) target;
        break;
      case 50:
        this.RibbonBarCompOptions = (ButtonDropDown) target;
        break;
      case 51:
        this.RibbonBarCompCodeplugHideUnideFlds = (ButtonDropDown) target;
        this.RibbonBarCompCodeplugHideUnideFlds.Click += new RoutedEventHandler(this.OnRibbonBarHideMatches);
        break;
      case 52:
        this.RibbonBarCompCodeplugPageCopyAll = (ButtonDropDown) target;
        this.RibbonBarCompCodeplugPageCopyAll.Click += new RoutedEventHandler(this.OnRibbonBarPageCopyAll);
        break;
      case 53:
        this.RibbonBarShowFS = (ButtonDropDown) target;
        this.RibbonBarShowFS.Click += new RoutedEventHandler(this.RibbonBarShowFS_Click);
        break;
      case 54:
        this.ribbonBarToolsPassword = (RibbonBar) target;
        break;
      case 55:
        this.ReadWritePassword = (ButtonDropDown) target;
        this.ReadWritePassword.Click += new RoutedEventHandler(this.OnRibbonBarPassword);
        break;
      case 56:
        this.ribbonBarDVRS = (RibbonBar) target;
        this.ribbonBarDVRS.LaunchDialog += new RoutedEventHandler(this.OnAppMenuOptions);
        break;
      case 57:
        this.DVRSExport = (ButtonDropDown) target;
        this.DVRSExport.Click += new RoutedEventHandler(this.OnRibbonBarDVRSExport);
        break;
      case 58:
        this.ribbonBarUpdateUCL = (RibbonBar) target;
        break;
      case 59:
        this.UpdateCallList = (ButtonDropDown) target;
        this.UpdateCallList.Click += new RoutedEventHandler(this.OnRibbonBarOpenUpdateUCL);
        break;
      case 60:
        this.ribbonTabCustomViewCfgMode = (RibbonTab) target;
        break;
      case 61:
        this.ribbonBarCustomViewPanel = (RibbonBarPanel) target;
        break;
      case 62:
        this.ribbonBarCustomView = (RibbonBar) target;
        break;
      case 63 /*0x3F*/:
        this.ribbonBarCustomViewOpen = (ButtonDropDown) target;
        this.ribbonBarCustomViewOpen.Click += new RoutedEventHandler(this.OnRibbonBarOpenCustomView);
        break;
      case 64 /*0x40*/:
        this.ribbonBarCustomViewNew = (ButtonDropDown) target;
        this.ribbonBarCustomViewNew.Click += new RoutedEventHandler(this.OnRibbonBarNewCustomView);
        break;
      case 65:
        this.ribbonBarCustomViewSaveAs = (ButtonDropDown) target;
        this.ribbonBarCustomViewSaveAs.Click += new RoutedEventHandler(this.OnRibbonBarSaveAsCustomView);
        break;
      case 66:
        this.ribbonBarCustomViewClose = (ButtonDropDown) target;
        this.ribbonBarCustomViewClose.Click += new RoutedEventHandler(this.OnRibbonBarCloseCustomView);
        break;
      case 67:
        this.ribbonBarCustomHowTo = (ButtonDropDown) target;
        this.ribbonBarCustomHowTo.Click += new RoutedEventHandler(this.OnRibbonBarCustomViewHelp);
        break;
      case 68:
        this.ribbonTabAppSettings = (RibbonTab) target;
        break;
      case 69:
        this.ribbonBarThemes = (RibbonBar) target;
        break;
      case 70:
        this.RibbonBarBarThemes = (ButtonDropDown) target;
        break;
      case 71:
        this.ClassicTheme = (ButtonDropDown) target;
        this.ClassicTheme.Click += new RoutedEventHandler(this.OnRibbonBarThemeItemClick);
        break;
      case 72:
        this.SilverTheme = (ButtonDropDown) target;
        this.SilverTheme.Click += new RoutedEventHandler(this.OnRibbonBarThemeItemClick);
        break;
      case 73:
        this.BlackTheme = (ButtonDropDown) target;
        this.BlackTheme.Click += new RoutedEventHandler(this.OnRibbonBarThemeItemClick);
        break;
      case 74:
        this.PoliceTheme = (ButtonDropDown) target;
        this.PoliceTheme.Click += new RoutedEventHandler(this.OnRibbonBarThemeItemClick);
        break;
      case 75:
        this.FiremanTheme = (ButtonDropDown) target;
        this.FiremanTheme.Click += new RoutedEventHandler(this.OnRibbonBarThemeItemClick);
        break;
      case 76:
        this.MilitaryTheme = (ButtonDropDown) target;
        this.MilitaryTheme.Click += new RoutedEventHandler(this.OnRibbonBarThemeItemClick);
        break;
      case 77:
        this.FullColorTheme = (ButtonDropDown) target;
        this.FullColorTheme.Click += new RoutedEventHandler(this.OnRibbonBarThemeItemClick);
        break;
      case 78:
        this.ribbonBarWindows = (RibbonBar) target;
        break;
      case 79:
        this.RibbonBarBarWindows = (ButtonDropDown) target;
        break;
      case 80 /*0x50*/:
        this.wndNavigation = (ButtonDropDown) target;
        break;
      case 81:
        this.wndNavigationHideCB = (AcpCheckBox) target;
        this.wndNavigationHideCB.Click += new RoutedEventHandler(this.OnRibbonBarWndHideClick);
        break;
      case 82:
        this.wndErrorList = (ButtonDropDown) target;
        break;
      case 83:
        this.wndErrorListHideCB = (AcpCheckBox) target;
        this.wndErrorListHideCB.Click += new RoutedEventHandler(this.OnRibbonBarWndHideClick);
        break;
      case 84:
        this.wndErrorListAutoRiseCB = (AcpCheckBox) target;
        this.wndErrorListAutoRiseCB.Click += new RoutedEventHandler(this.OnRibbonBarWndAutoRiseClick);
        break;
      case 85:
        this.wndInvalidFieldsReport = (ButtonDropDown) target;
        break;
      case 86:
        this.wndInvalidFieldsHideCB = (AcpCheckBox) target;
        this.wndInvalidFieldsHideCB.Click += new RoutedEventHandler(this.OnRibbonBarWndHideClick);
        break;
      case 87:
        this.wndInvalidFieldsAutoRiseCB = (AcpCheckBox) target;
        this.wndInvalidFieldsAutoRiseCB.Click += new RoutedEventHandler(this.OnRibbonBarWndAutoRiseClick);
        break;
      case 88:
        this.wndDnDReport = (ButtonDropDown) target;
        break;
      case 89:
        this.wndDnDReportHideCB = (AcpCheckBox) target;
        this.wndDnDReportHideCB.Click += new RoutedEventHandler(this.OnRibbonBarWndHideClick);
        break;
      case 90:
        this.wndDnDReportAutoRiseCB = (AcpCheckBox) target;
        this.wndDnDReportAutoRiseCB.Click += new RoutedEventHandler(this.OnRibbonBarWndAutoRiseClick);
        break;
      case 91:
        this.wndImpExpReport = (ButtonDropDown) target;
        break;
      case 92:
        this.wndImpExpReportHideCB = (AcpCheckBox) target;
        this.wndImpExpReportHideCB.Click += new RoutedEventHandler(this.OnRibbonBarWndHideClick);
        break;
      case 93:
        this.wndImpExpReportAutoRiseCB = (AcpCheckBox) target;
        this.wndImpExpReportAutoRiseCB.Click += new RoutedEventHandler(this.OnRibbonBarWndAutoRiseClick);
        break;
      case 94:
        this.wndComparatorReport = (ButtonDropDown) target;
        break;
      case 95:
        this.wndComparatorReportHideCB = (AcpCheckBox) target;
        this.wndComparatorReportHideCB.Click += new RoutedEventHandler(this.OnRibbonBarWndHideClick);
        break;
      case 96 /*0x60*/:
        this.wndComparatorReportAutoRiseCB = (AcpCheckBox) target;
        this.wndComparatorReportAutoRiseCB.Click += new RoutedEventHandler(this.OnRibbonBarWndAutoRiseClick);
        break;
      case 97:
        this.wndFillUpFillDownReport = (ButtonDropDown) target;
        break;
      case 98:
        this.wndFillUpFillDownReportHideCB = (AcpCheckBox) target;
        this.wndFillUpFillDownReportHideCB.Click += new RoutedEventHandler(this.OnRibbonBarWndHideClick);
        break;
      case 99:
        this.wndFillUpFillDownReportAutoRiseCB = (AcpCheckBox) target;
        this.wndFillUpFillDownReportAutoRiseCB.Click += new RoutedEventHandler(this.OnRibbonBarWndAutoRiseClick);
        break;
      case 100:
        this.wndFindResults = (ButtonDropDown) target;
        break;
      case 101:
        this.wndFindResultsHideCB = (AcpCheckBox) target;
        this.wndFindResultsHideCB.Click += new RoutedEventHandler(this.OnRibbonBarWndHideClick);
        break;
      case 102:
        this.wndFindResultsAutoRiseCB = (AcpCheckBox) target;
        this.wndFindResultsAutoRiseCB.Click += new RoutedEventHandler(this.OnRibbonBarWndAutoRiseClick);
        break;
      case 103:
        this.wndFieldInfo = (ButtonDropDown) target;
        break;
      case 104:
        this.wndFieldInfoHideCB = (AcpCheckBox) target;
        this.wndFieldInfoHideCB.Click += new RoutedEventHandler(this.OnRibbonBarWndHideClick);
        break;
      case 105:
        this.wndSysKeyRpt = (ButtonDropDown) target;
        break;
      case 106:
        this.wndSysKeyRptHideCB = (AcpCheckBox) target;
        this.wndSysKeyRptHideCB.Click += new RoutedEventHandler(this.OnRibbonBarWndHideClick);
        break;
      case 107:
        this.wndSysKeyRptAutoRiseCB = (AcpCheckBox) target;
        this.wndSysKeyRptAutoRiseCB.Click += new RoutedEventHandler(this.OnRibbonBarWndAutoRiseClick);
        break;
      case 108:
        this.ribbonBarView = (RibbonBar) target;
        break;
      case 109:
        this.DiffViewType = (System.Windows.Controls.ComboBox) target;
        this.DiffViewType.SelectionChanged += new SelectionChangedEventHandler(this.OnRibbonBarUserViewSelChg);
        break;
      case 110:
        this.ribbonTabDeviceMgmtMode = (RibbonTab) target;
        break;
      case 111:
        this.ribbonBarDevicePanel = (RibbonBarPanel) target;
        break;
      case 112 /*0x70*/:
        this.ribbonBarDeviceReadWrite = (RibbonBar) target;
        break;
      case 113:
        this.ribbonBarDeviceRead = (ButtonDropDown) target;
        this.ribbonBarDeviceRead.Click += new RoutedEventHandler(this.OnRibbonBarReadRadio);
        break;
      case 114:
        this.ribbonBarDeviceWrite = (ButtonDropDown) target;
        this.ribbonBarDeviceWrite.Click += new RoutedEventHandler(this.OnRibbonBarWriteRadio);
        break;
      case 115:
        this.DeviceTransportComboBox = (System.Windows.Controls.ComboBox) target;
        this.DeviceTransportComboBox.SelectionChanged += new SelectionChangedEventHandler(this.Device_TransportComboBox_SelectionChanged);
        break;
      case 116:
        this.labBTIPAddressForWR = (AcpLabel) target;
        break;
      case 117:
        this.txtBTIPAddressForWR = (System.Windows.Controls.TextBox) target;
        this.txtBTIPAddressForWR.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.OnPreviewKeyDown_BTIPAddressForWR);
        break;
      case 118:
        this.ribbonBarDeviceCloning = (RibbonBar) target;
        break;
      case 119:
        this.ribbonBarCloneWizard = (ButtonDropDown) target;
        this.ribbonBarCloneWizard.Click += new RoutedEventHandler(this.OnRibbonBarCloneWizard);
        break;
      case 120:
        this.ribbonBarCloneExpress = (ButtonDropDown) target;
        this.ribbonBarCloneExpress.Click += new RoutedEventHandler(this.OnRibbonBarCloneExpress);
        break;
      case 121:
        this.CloneransportComboBox = (System.Windows.Controls.ComboBox) target;
        this.CloneransportComboBox.SelectionChanged += new SelectionChangedEventHandler(this.Device_CloneTransport_SelectionChanged);
        break;
      case 122:
        this.labBTIPAddressForClone = (AcpLabel) target;
        break;
      case 123:
        this.txtBTIPAddressForClone = (System.Windows.Controls.TextBox) target;
        this.txtBTIPAddressForClone.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.OnPreviewKeyDown_BTIPAddressForClone);
        break;
      case 124:
        this.ribbonBarDeviceFlashport = (RibbonBar) target;
        break;
      case 125:
        this.ribbonBarReadRadCfg = (ButtonDropDown) target;
        this.ribbonBarReadRadCfg.Click += new RoutedEventHandler(this.OnRibbonBarReadRadCfg);
        break;
      case 126:
        this.ribbonBarFlashRadio = (ButtonDropDown) target;
        this.ribbonBarFlashRadio.Click += new RoutedEventHandler(this.OnRibbonBarFlashRadio);
        break;
      case (int) sbyte.MaxValue:
        this.ribbonBarReadFlashKeyCfg = (ButtonDropDown) target;
        this.ribbonBarReadFlashKeyCfg.Click += new RoutedEventHandler(this.OnRibbonBarReadFlashKeyCfg);
        break;
      case 128 /*0x80*/:
        this.ribbonBarRefreshRadio = (ButtonDropDown) target;
        this.ribbonBarRefreshRadio.Click += new RoutedEventHandler(this.OnRibbonBarFlashRadio);
        break;
      case 129:
        this.ribbonBarDisableWP = (RibbonBar) target;
        break;
      case 130:
        this.AppMenuWriteProtect = (ButtonDropDown) target;
        this.AppMenuWriteProtect.Click += new RoutedEventHandler(this.OnAppMenuQuerySetRadio);
        break;
      case 131:
        this.ribbonTabSecurity = (RibbonTab) target;
        break;
      case 132:
        this.ribbonTabTools = (RibbonTab) target;
        break;
      case 133:
        this.ribbonBarSysKey = (RibbonBar) target;
        this.ribbonBarSysKey.LaunchDialog += new RoutedEventHandler(this.OnAppMenuOptions);
        break;
      case 134:
        this.ribbonBarLoadASK = (ButtonDropDown) target;
        this.ribbonBarLoadASK.Click += new RoutedEventHandler(this.OnRibbonBarLoadASK);
        break;
      case 135:
        this.ribbonBarLoadSWKey = (ButtonDropDown) target;
        this.ribbonBarLoadSWKey.Click += new RoutedEventHandler(this.OnRibbonBarLoadSWKey);
        break;
      case 136:
        this.ribbonBarToolsReports = (RibbonBar) target;
        break;
      case 137:
        this.RibbonRadioInformation = (ButtonDropDown) target;
        this.RibbonRadioInformation.Click += new RoutedEventHandler(this.OnPrtRadioInfoReports);
        break;
      case 138:
        this.RibbonRadioHandOut = (ButtonDropDown) target;
        this.RibbonRadioHandOut.Click += new RoutedEventHandler(this.OnPrtHandOutReports);
        break;
      case 139:
        this.RibbonRadioHandOutO2 = (ButtonDropDown) target;
        this.RibbonRadioHandOutO2.Click += new RoutedEventHandler(this.OnPrtHandOutReportsO2);
        break;
      case 140:
        this.RibbonRadioHandOutO3 = (ButtonDropDown) target;
        this.RibbonRadioHandOutO3.Click += new RoutedEventHandler(this.OnPrtHandOutReportsO3);
        break;
      case 141:
        this.RibbonRadioHandOutO5 = (ButtonDropDown) target;
        this.RibbonRadioHandOutO5.Click += new RoutedEventHandler(this.OnPrtHandOutReportsO5);
        break;
      case 142:
        this.RibbonRadioHandOutO7 = (ButtonDropDown) target;
        this.RibbonRadioHandOutO7.Click += new RoutedEventHandler(this.OnPrtHandOutReportsO7);
        break;
      case 143:
        this.RibbonRadioHandOutO9 = (ButtonDropDown) target;
        this.RibbonRadioHandOutO9.Click += new RoutedEventHandler(this.OnPrtHandOutReportsO9);
        break;
      case 144 /*0x90*/:
        this.RibbonRadioUserDefined = (ButtonDropDown) target;
        this.RibbonRadioUserDefined.Click += new RoutedEventHandler(this.OnPrtCustomTplReports);
        break;
      case 145:
        this.RibbonRadioPrintChoices = (ButtonDropDown) target;
        this.RibbonRadioPrintChoices.Click += new RoutedEventHandler(this.OnPrtChoicesReports);
        break;
      case 146:
        this.ribbonBarToolsVoiceAnnouncement = (RibbonBar) target;
        break;
      case 147:
        this.VAConvertUtil = (ButtonDropDown) target;
        this.VAConvertUtil.Click += new RoutedEventHandler(this.OnRibbonBarConvertVoiceAnnouncementFiles);
        break;
      case 148:
        this.VACpgUsage = (ButtonDropDown) target;
        this.VACpgUsage.Click += new RoutedEventHandler(this.OnRibbonBarCalculateVoiceAnnouncementSize);
        break;
      case 149:
        this.VADownldUtil = (ButtonDropDown) target;
        this.VADownldUtil.Click += new RoutedEventHandler(this.OnRibbonBarDownLoadVoiceFile);
        break;
      case 150:
        this.ribbonBarToolsPOP25Scheduler = (RibbonBar) target;
        break;
      case 151:
        this.POP25RadioList = (ButtonDropDown) target;
        this.POP25RadioList.Click += new RoutedEventHandler(this.OnRibbonBarCreateRadioList);
        break;
      case 152:
        this.POP25BatchScheduler = (ButtonDropDown) target;
        this.POP25BatchScheduler.Click += new RoutedEventHandler(this.OnRibbonBarOpenPOP25BatchScheduler);
        break;
      case 153:
        this.ribbonBarRadioManagement = (RibbonBar) target;
        break;
      case 154:
        this.RadioManagement = (ButtonDropDown) target;
        this.RadioManagement.Click += new RoutedEventHandler(this.OnAppMenuRadioManagement);
        break;
      case 155:
        this.ribbonBarToolsOptions = (RibbonBar) target;
        break;
      case 156:
        this.Options = (ButtonDropDown) target;
        this.Options.Click += new RoutedEventHandler(this.OnAppMenuOptions);
        break;
      case 157:
        this.ribbonBarToolsDepot = (RibbonBar) target;
        break;
      case 158:
        this.ribbonBarToolsCreateCp = (ButtonDropDown) target;
        this.ribbonBarToolsCreateCp.Click += new RoutedEventHandler(this.OnAppMenuDepotCreateCodeplug);
        break;
      case 159:
        this.ribbonBarToolsUpgradeCodeplug = (ButtonDropDown) target;
        this.ribbonBarToolsUpgradeCodeplug.Click += new RoutedEventHandler(this.OnAppMenuDepotUpgradeCodeplug);
        break;
      case 160 /*0xA0*/:
        this.ribbonBarToolsForceWriteRadio = (ButtonDropDown) target;
        this.ribbonBarToolsForceWriteRadio.Click += new RoutedEventHandler(this.OnAppMenuDepotForceWriteRadio);
        break;
      case 161:
        this.ribbonBarToolsUpgradeRadio = (ButtonDropDown) target;
        this.ribbonBarToolsUpgradeRadio.Click += new RoutedEventHandler(this.OnAppMenuDepotUpgradeRadio);
        break;
      case 162:
        this.ribbonBarToolsCbiProgram = (ButtonDropDown) target;
        this.ribbonBarToolsCbiProgram.Click += new RoutedEventHandler(this.OnAppMenuDepotCBIProgram);
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
        this.ribbonBarWhatsNew = (ButtonDropDown) target;
        this.ribbonBarWhatsNew.Click += new RoutedEventHandler(this.OnClickRibbonBarWhatsNew);
        break;
      case 168:
        this.ribbonBarTutorials = (ButtonDropDown) target;
        this.ribbonBarTutorials.Click += new RoutedEventHandler(this.OnClickRibbonBarAboutTutorials);
        break;
      case 169:
        this.ribbonBarSpecKeyReport = (ButtonDropDown) target;
        break;
      case 170:
        this.specKeyListView = (System.Windows.Controls.ListView) target;
        break;
      case 171:
        this.SpecKeyReport = (GridView) target;
        break;
      case 172:
        this.specKeyType = (GridViewColumn) target;
        break;
      case 173:
        this.SerialNum = (GridViewColumn) target;
        break;
      case 174:
        this.ribbonBarHelpButton = (ButtonDropDown) target;
        this.ribbonBarHelpButton.Click += new RoutedEventHandler(this.OnClickRibbonBarCPSHelp);
        break;
      case 175:
        this.AppClose = (ButtonDropDown) target;
        this.AppClose.Click += new RoutedEventHandler(this.OnAppMenuClose);
        break;
      case 176 /*0xB0*/:
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
