// Decompiled with JetBrains decompiler
// Type: MackinawCPS.FieldAccessor
// Assembly: APXFamilyCPS, Version=36.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 9359335E-041C-4B12-9409-F4E6E7D93299
// Assembly location: C:\Program Files (x86)\Motorola\ApxFamilyCPS R36.00\APXFamilyCPS1.exe

using AcpBusinessLayer;
using AcpCommonLib;
using AcpCommonLib.UndoRedo;
using CommonResources;
using ConstraintHelper;
using Features.Common;
using Motorola.Common.BinarySerializer;
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
using Motorola.MackinawCPS.CoreFeatures.VirtualPartnerAlert;
using Motorola.MackinawCPS.CoreFeatures.ZoneChannelAssignment;
using SpecialFeatures.DVRSFiles.List;
using SpecialFeatures.Model_Configuration;
using SpecialFeatures.SystemCertificates.List;
using SpecialFeatures.Ucl.Contact;
using SpecialFeatures.Ucl.HotList;
using SpecialFeatures.Ucl.UclWide;
using SpecialFeatures.VoiceAnnouncements.List;
using SpecialFeatures.VoiceAnnouncements.SiteSelectableAlertList;
using SpecialFeatures.VoiceAnnouncements.Wide;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

#nullable disable
namespace MackinawCPS;

internal class FieldAccessor
{
  private static FieldAccessor _fieldAccessor;
  public Dictionary<string, IAcpField> Field = new Dictionary<string, IAcpField>();
  private Motorola.MackinawCPS.CoreFeatures.RemoteSpeakerMic.RemoteSpeakerMic _remoteSpeakerMic;
  private RSMButtonInner _RSMButtonInner;
  private Motorola.MackinawCPS.CoreFeatures.ActionConsolidation.ActionConsolidation _actionConsolidation;
  private ConsolidatedActionsInner _consolidatedActionsInner;
  private TrunkingCallHotList _trunkingCallHotList;
  private PortableSideUpDownArrowButtonInner _portableSideUpDownArrowButtonInner;
  private Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation _radioInformation;
  private Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide _radioWide;
  private Motorola.MackinawCPS.CoreFeatures.Buttons.Buttons _buttions;
  private PortableButtonInner _portableButtonInner;
  private Motorola.MackinawCPS.CoreFeatures.Buttons.DataButtonInner _dataButtonInner;
  private Motorola.MackinawCPS.CoreFeatures.MenuItems.MenuItems _menuItems;
  private Motorola.MackinawCPS.CoreFeatures.SecureWide.SecureWide _secureWide;
  private Motorola.MackinawCPS.CoreFeatures.DataWide.DataWide _dataWide;
  private DataModemTableInner _dataModemTableInner;
  private VoiceAnnouncementWide _voiceAnnouncementsWide;
  private Motorola.MackinawCPS.CoreFeatures.DataProfiles.DataProfiles _dataProfiles;
  private DACListInner _DACListInner;
  private TrunkingGroupIDListInner _trunkingGroupIDListInner;
  private EIDBypassListInner _eidBypassListInner;
  private Motorola.MackinawCPS.CoreFeatures.DisplayAndMenu.DisplayAndMenu _displayAndMenu;
  private Motorola.MackinawCPS.CoreFeatures.ConventionalSystem.ConventionalSystem _conventionalSystem;
  private Motorola.MackinawCPS.CoreFeatures.ConventionalPersonality.ConventionalPersonality _conventionalPersonality;
  private Motorola.MackinawCPS.CoreFeatures.ZoneChannelAssignment.ZoneChannelAssignment _zoneChannelAssignment;
  private ChannelAssignmentListInner _channelAssignmentListInner;
  private Motorola.MackinawCPS.CoreFeatures.ScanList.ScanList _scanList;
  private ScanListInner _scanListInner;
  private TxPowerLevelsByFrequencyRangeInner _txPowerLevelsByFrequencyRangeInner;
  private TxPowerLevelsByFrequencyRangeNewBandPlanInner _txPowerLevelsByFrequencyRangeNewBandPlanInner;
  private RxFrequencySplitFPPInner _rxFrequencySplitFPPInner;
  private TxFrequencySplitFPPInner _txFrequencySplitFPPInner;
  private FCCNarrowBandingFrequencySplitInner _FCCNarrowBandingFrequencySplitInner;
  private GeneralLightbarPatternInner _generalLightbarPatternInner;
  private RelockTimerInner _relockTimerInner;
  private UclTrunkingCallHotList _uclTrunkingCallHotList;
  private UclAstroCallHotList _uclAstroCallHotList;
  private Motorola.MackinawCPS.CoreFeatures.ASTROTalkgroupList.ASTROTalkgroupList _ASTROTalkgroupList;
  private TalkgroupTableInner _talkgroupTableInner;
  private Motorola.MackinawCPS.CoreFeatures.ControlHeadO2.ControlHeadO2 _controlHeadO2;
  private Motorola.MackinawCPS.CoreFeatures.ControlHeadO3.ControlHeadO3 _controlHeadO3;
  private Motorola.MackinawCPS.CoreFeatures.ControlHeadO5.ControlHeadO5 _controlHeadO5;
  private Motorola.MackinawCPS.CoreFeatures.ControlHeadO7.ControlHeadO7 _controlHeadO7;
  private Motorola.MackinawCPS.CoreFeatures.ControlHeadO9.ControlHeadO9 _controlHeadO9;
  private Motorola.MackinawCPS.CoreFeatures.ControlHeadE5.ControlHeadE5 _controlHeadE5;
  private O2Inner _O2Inner;
  private O3HHCHButtonInner _O3HHCHButtonInner;
  private E5Inner _E5Inner;
  private O5Inner _O5Inner;
  private O7Inner _O7Inner;
  private O9Inner _O9Inner;
  private O2MFKAssignmentControlInner _O2MFKAssignmentControlInner;
  private O2MFKAssignmentControlInner _O2MFKAssignmentControlInner_1;
  private O2NavigationControlsTableInner _O2NavigationControlsTableInner;
  private O2NavigationControlsTableInner _O2NavigationControlsTableInner_Down;
  private Motorola.MackinawCPS.CoreFeatures.ControlHeadO3.DataButtonInner _O3DataButtonInner;
  private O3NavigationControlsTableInner _O3NavigationControlsTableInner;
  private O3NavigationControlsTableInner _O3NavigationControlsTableInner_Down;
  private O5NavigationControlsTableInner _O5NavigationControlsTableInner;
  private O5NavigationControlsTableInner _O5NavigationControlsTableInner_Down;
  private O7DataButtonInner _O7DataButtonInner;
  private O7MFKAssignmentControlInner _O7MFKAssignmentControlInner;
  private O7MFKAssignmentControlInner _O7MFKAssignmentControlInner_1;
  private O7NavigationControlsTableInner _O7NavigationControlsTableInner;
  private O7NavigationControlsTableInner _O7NavigationControlsTableInner_Down;
  private E5BottomFunctionButtonInner _E5bottomFunctionButtonInner;
  private E5NavigationControlsTableInner _E5NavigationControlsTableInner;
  private E5NavigationControlsTableInner _E5NavigationControlsTableInner_Down;
  private O9DataButtonInner _O9DataButtonInner;
  private TopFunctionProgrammableButtonListInner _topFunctionProgrammableButtonListInner;
  private BottomFunctionProgrammableButtonInner _bottomFunctionProgrammableButtonInner;
  private ResponseSelectorListInner _responseSelectorListInner;
  private DirectionalButtonsListInner _directionalButtonsListInner;
  private PASirenButtonsListInner _PASirenButtonsListInner;
  private RelayPatternBCOListListInner _relayPatternBCOListListInner;
  private ConsolidatedActionBCOListInner _consolidatedActionBCOListInner;
  private O9NavigationControlsTableInner _O9NavigationControlsTableInner;
  private O9NavigationControlsTableInner _O9NavigationControlsTableInner_Down;
  private BottomFunctionButtonBCOListInner _bottomFunctionButtonBCOListInner;
  private Motorola.MackinawCPS.CoreFeatures.ConventionalAliasLists.ConventionalAliasLists _conventionalAliasLists;
  private MessageAliasTableInner _messageAliasTableInner;
  private StatusAliasTableInner _statusAliasTableInner;
  private Motorola.MackinawCPS.CoreFeatures.ConventionalEmergencyProfiles.ConventionalEmergencyProfiles _conventionalEmergencyProfiles;
  private EmergencyToneTableInner _emergencyToneTableInner;
  private FrequencyOptionsInner _frequencyOptionsInner;
  private Motorola.MackinawCPS.CoreFeatures.ConventionalPersonality.OneTouchInner _cnvOneTouchInner;
  private Motorola.MackinawCPS.CoreFeatures.ConventionalWide.ConventionalWide _conventionalWide;
  private ASTROGroupIDListInner _ASTROGroupIDListInner;
  private OTACInner _OTACInner;
  private NATListInner _NATListInner;
  private ConfiguredNetworksListInner _ConfiguredNetworksListInner;
  private DataUserListInner _dataUserListInner;
  private QuickTextMessageListInner _quickTextMessageListInner;
  private Motorola.MackinawCPS.CoreFeatures.DEK.DEK _DEK;
  private DEKButtonInner _DEKButtonInner;
  private DEKVIPInner _DEKVIPInner;
  private DirectMessageListInner _directMessageListInner;
  private DirectStatusBCOListInner _directStatusBCOListInner;
  private DirectModeBCOListInner _directModeBCOListInner;
  private IDDisplayTableInner _IDDisplayTableInner;
  private BacklightColorsInner _backlightColorsInner;
  private Motorola.MackinawCPS.CoreFeatures.DVRSProfiles.DVRSProfiles _DVRSProfiles;
  private Motorola.MackinawCPS.CoreFeatures.DVRSWide.DVRSWide _DVRSWide;
  private Motorola.MackinawCPS.CoreFeatures.EmergencyWide.EmergencyWide _emergencyWide;
  private Motorola.MackinawCPS.CoreFeatures.EnhancedDataPortList.EnhancedDataPortList _enhancedDataPortList;
  private EnhancedDataPortTableInner _enhancedDataPortTableInner;
  private Motorola.MackinawCPS.CoreFeatures.ExternalMicNoiseReductionProfile.ExternalMicNoiseReductionProfile _externalMicNoiseReductionProfile;
  private Motorola.MackinawCPS.CoreFeatures.FactoryOverrides.FactoryOverrides _factoryOverrides;
  private SecondLOInjectionFrequencyListInner _secondLOInjectionFrequencyListInner;
  private RxFrequencyListInner _rxFrequencyListInner;
  private RxSynthesizerReferenceDividerListInner _rxSynthesizerReferenceDividerListInner;
  private TxSynthesizerReferenceDividerListInner _txSynthesizerReferenceDividerListInner;
  private TxSSIClockRateListInner _txSSIClockRateListInner;
  private Motorola.MackinawCPS.CoreFeatures.GlobalNoiseReductionList.GlobalNoiseReductionList _globalNoiseReductionList;
  private Motorola.MackinawCPS.CoreFeatures.InternalMicNoiseReductionProfile.InternalMicNoiseReductionProfile _internalMicNoiseReductionProfile;
  private Motorola.MackinawCPS.CoreFeatures.Keypad.Keypad _keypad;
  private KeypadButtonInner _keypadButtonInner;
  private Motorola.MackinawCPS.CoreFeatures.KeypadMicAndAccessories.KeypadMicAndAccessories _keypadMicAndAccessories;
  private KMButtonInner _KMButtonInner;
  private Motorola.MackinawCPS.CoreFeatures.KeypadMicAndAccessories.DataButtonInner _keyPadMicDataButtonInner;
  private KMANavigationControlsTableInner _KMANavigationControlsTableInner;
  private KMANavigationControlsTableInner _KMANavigationControlsTableInner_Down;
  private UclContact _uclContact;
  private UclMDCCallHotList _uclMDCCallHotList;
  private MDCCallHotList _MDCCallHotList;
  private ASKProgrammingHistoryInner _ASKProgrammingHistoryInner;
  private Motorola.MackinawCPS.CoreFeatures.MPLConfiguration.MPLConfiguration _mplConfiguration;
  private MPLListInner _mplListInner;
  private Motorola.MackinawCPS.CoreFeatures.PhoneWide.PhoneWide _phoneWide;
  private DTMFTimingInner _dtmfTimingInner;
  private DTMFCodesInner _dtmfCodesInner;
  private Motorola.MackinawCPS.CoreFeatures.RadioErgonomicsWide.RadioErgonomicsWide _radioErgonomicsWide;
  private ControlHeadAliasListInner _controlHeadAliasListInner;
  private AuxControlTableInner _auxControlTableInner;
  private PresetZoneAndChannelTableInner _presetZoneAndChannelTableInner;
  private Motorola.MackinawCPS.CoreFeatures.ToneSignalingList.ToneSignalingList _astroAlertingToneListChildNode;
  private AstroAlertingToneTableInner _astroAlertingToneTableInner;
  private Motorola.MackinawCPS.CoreFeatures.RadioProfiles.RadioProfiles _radioProfiles;
  private Motorola.MackinawCPS.CoreFeatures.RadioVIPs.RadioVIPs _radioVIPs;
  private RadioVIPInner _radioVIPInner;
  private MDCRepeaterIDTableInner _mdcRepeaterIDTableInner;
  private SingletoneFrequencyTableInner _singletoneFrequencyTableInner;
  private Motorola.MackinawCPS.CoreFeatures.RepeaterIDList.RepeaterIDList _repeaterIDList;
  private Motorola.MackinawCPS.CoreFeatures.ScanWide.ScanWide _scanWide;
  private Motorola.MackinawCPS.CoreFeatures.SecureKMFProfile.SecureKMFProfile _secureKMFProfile;
  private SecureHardwareEncryptionKeyReferencesListInner _secureHardwareEncryptionKeyReferencesListInner;
  private SecureHardwareEncryptionIndependentKeyListInner _secureHardwareEncryptionIndependentKeyListInner;
  private EncryptionKeyListInner _encryptionKeyListInner;
  private Motorola.MackinawCPS.CoreFeatures.Shepherds.Shepherds _shepherds;
  private ConventionalProductIndependentButtonListInner _conventionalProductIndependentButtonListInner;
  private TrunkingProductIndependentButtonListInner _trunkingProductIndependentButtonListInner;
  private GlobalShepherdListInner _globalShepherdListInner;
  private ConventionalShepherdListInner _conventionalShepherdListInner;
  private TrunkingShepherdListInner _trunkingShepherdListInner;
  private SignalIndependentProductIndependentNonProgrammableButtonListInner _signalIndependentProductIndependentNonProgrammableButtonListInner;
  private SignalIndependentProductIndependentProgrammableButtonListInner _signalIndependentProductIndependentProgrammableButtonListInner;
  private SpecialFeatures.VoiceAnnouncements.SiteSelectableAlertList.SiteSelectableAlertList _siteSelectableAlertList;
  private SiteSelectableAlertTableInner _siteSelectableAlertTableInner;
  private Motorola.MackinawCPS.CoreFeatures.SmartKeyFob.SmartKeyFob _smartKeyFob;
  private SmartKeyFobButtonTableInner _smartKeyFobButtonTableInner;
  private Motorola.MackinawCPS.CoreFeatures.Switches.Switches _switches;
  private RotaryControlInner _rotaryControlInner;
  private ConventionalSwitchTableInner _conventionalSwitchTableInner;
  private TrunkingSwitchTableInner _trunkingSwitchTableInner;
  private MFKAssignmentControlInner _MFKAssignmentControlInner;
  private MFKAssignmentControlInner _MFKAssignmentControlInner_1;
  private Motorola.MackinawCPS.CoreFeatures.TrunkingEmergencyProfiles.TrunkingEmergencyProfiles _trunkingEmergencyProfiles;
  private TrunkingEmergencyToneTableInner _trunkingEmergencyToneTableInner;
  private Motorola.MackinawCPS.CoreFeatures.TrunkingPersonality.TrunkingPersonality _trunkingPersonality;
  private TalkgroupInner _talkgroupInner;
  private PreferredSitesInner _preferredSitesInner;
  private Motorola.MackinawCPS.CoreFeatures.TrunkingSystem.TrunkingSystem _trunkingSystem;
  private ChannelRangesMHzInner _channelRangesMHzInner;
  private ControlChannelsInner _controlChannelsInner;
  private ASTRO25ChannelIDInner _ASTRO25ChannelIDInner;
  private StatusAliasInner _statusAliasInner;
  private SiteAliasInner _siteAliasInner;
  private Motorola.MackinawCPS.CoreFeatures.TrunkingSystem.OneTouchInner _trkOneTouchInner;
  private Motorola.MackinawCPS.CoreFeatures.TrunkingWide.TrunkingWide _trunkingWide;
  private UclTrunkingT2CallHotList _UclTrunkingT2CallHotList;
  private VoiceAnnouncementList _VoiceAnnouncementList;
  private MessageAliasInner _messageAliasInner;
  private Motorola.MackinawCPS.CoreFeatures.PersonnelAccountability.PersonnelAccountability _personnelAccountability;
  private PerAccListTableInner _perAccListTableInner;
  private Motorola.MackinawCPS.CoreFeatures.MissionCriticalGeofence.MissionCriticalGeofence _missionCriticalGeofence;
  private Motorola.MackinawCPS.CoreFeatures.VirtualPartnerAlert.VirtualPartnerAlert _virtualPartnerAlert;
  private AlertListInner _vpAlertListInnerSection;
  private SystemCertificateList _systemCertificateList;
  private DVRSFileList _dvrsFileList;
  private URLTableInner _urlTableInner;
  private BookmarkQuickAccessListInner _bookmarkQuickAccessListInner;

  public MackCPSDocument CpsDocument { get; private set; }

  public bool IsLoaded { get; private set; }

  public static bool IsCpsApiTest { get; private set; }

  public Motorola.MackinawCPS.CoreFeatures.ToneSignalingList.ToneSignalingList AstroAlertingToneListChildNode
  {
    get
    {
      if (this._astroAlertingToneListChildNode == null)
        this._astroAlertingToneListChildNode = FeatureManager.GetFeature(4156)[0] as Motorola.MackinawCPS.CoreFeatures.ToneSignalingList.ToneSignalingList;
      return this._astroAlertingToneListChildNode;
    }
  }

  public AstroAlertingToneTableInner AstroAlertingToneTableInner
  {
    get
    {
      if (this._astroAlertingToneTableInner == null)
        this._astroAlertingToneTableInner = this.AstroAlertingToneListChildNode.AstroAlertingToneListExpander.EmbeddedRecset[0] as AstroAlertingToneTableInner;
      return this._astroAlertingToneTableInner;
    }
  }

  public Motorola.MackinawCPS.CoreFeatures.RemoteSpeakerMic.RemoteSpeakerMic RemoteSpeakerMic
  {
    get
    {
      if (this._remoteSpeakerMic == null)
        this._remoteSpeakerMic = FeatureManager.GetFeature(2036)[0] as Motorola.MackinawCPS.CoreFeatures.RemoteSpeakerMic.RemoteSpeakerMic;
      return this._remoteSpeakerMic;
    }
  }

  public RSMButtonInner RSMButtonInner
  {
    get
    {
      if (this._RSMButtonInner == null)
        this._RSMButtonInner = (this.RemoteSpeakerMic.General.EmbeddedRecset as RSMButtonInnerRecset)[0] as RSMButtonInner;
      return this._RSMButtonInner;
    }
  }

  public URLTableInner URLTableInner
  {
    get
    {
      if (this._urlTableInner == null)
        this._urlTableInner = FeatureManager.GetFeature(4237)[0] as URLTableInner;
      return this._urlTableInner;
    }
  }

  public Motorola.MackinawCPS.CoreFeatures.ActionConsolidation.ActionConsolidation ActionConsolidation
  {
    get
    {
      if (this._actionConsolidation == null)
        this._actionConsolidation = FeatureManager.GetFeature(4008)[0] as Motorola.MackinawCPS.CoreFeatures.ActionConsolidation.ActionConsolidation;
      return this._actionConsolidation;
    }
  }

  public ConsolidatedActionsInner ConsolidatedActionsInner
  {
    get
    {
      if (this._consolidatedActionsInner == null)
      {
        if (this.ActionConsolidation.General.EmbeddedRecset.Count == 0 && !FieldAccessor.IsCpsApiTest)
          this.ActionConsolidation.General.EmbeddedRecset.AddDefaultRecord();
        this._consolidatedActionsInner = (this.ActionConsolidation.General.EmbeddedRecset as ConsolidatedActionsInnerRecset)[0] as ConsolidatedActionsInner;
      }
      return this._consolidatedActionsInner;
    }
  }

  public Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation RadioInformation
  {
    get
    {
      if (this._radioInformation == null)
        this._radioInformation = FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation;
      return this._radioInformation;
    }
  }

  public Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide RadioWide
  {
    get
    {
      if (this._radioWide == null)
        this._radioWide = FeatureManager.GetFeature(2045)[0] as Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide;
      return this._radioWide;
    }
  }

  public Motorola.MackinawCPS.CoreFeatures.Buttons.Buttons Buttions
  {
    get
    {
      if (this._buttions == null)
        this._buttions = FeatureManager.GetFeature(2042)[0] as Motorola.MackinawCPS.CoreFeatures.Buttons.Buttons;
      return this._buttions;
    }
  }

  public Motorola.MackinawCPS.CoreFeatures.Buttons.DataButtonInner DataButtonInner
  {
    get
    {
      if (this._dataButtonInner == null)
        this._dataButtonInner = (this.Buttions.DataButton.EmbeddedRecset as Motorola.MackinawCPS.CoreFeatures.Buttons.DataButtonInnerRecset)[0] as Motorola.MackinawCPS.CoreFeatures.Buttons.DataButtonInner;
      return this._dataButtonInner;
    }
  }

  public PortableButtonInner PortableButtonInner
  {
    get
    {
      if (this._portableButtonInner == null)
        this._portableButtonInner = (this.Buttions.General.EmbeddedRecset as PortableButtonInnerRecset)[0] as PortableButtonInner;
      return this._portableButtonInner;
    }
  }

  public PortableSideUpDownArrowButtonInner PortableSideUpDownArrowButtonInner
  {
    get
    {
      if (this.Buttions.SideArrowButtons.EmbeddedRecset.Count == 0)
        this.Buttions.SideArrowButtons.EmbeddedRecset.AddDefaultRecord();
      if (this._portableSideUpDownArrowButtonInner == null)
        this._portableSideUpDownArrowButtonInner = (this.Buttions.SideArrowButtons.EmbeddedRecset as PortableSideUpDownArrowButtonInnerRecset)[0] as PortableSideUpDownArrowButtonInner;
      return this._portableSideUpDownArrowButtonInner;
    }
  }

  public Motorola.MackinawCPS.CoreFeatures.MenuItems.MenuItems MenuItems
  {
    get
    {
      if (this._menuItems == null)
        this._menuItems = FeatureManager.GetFeature(2088)[0] as Motorola.MackinawCPS.CoreFeatures.MenuItems.MenuItems;
      return this._menuItems;
    }
  }

  public Motorola.MackinawCPS.CoreFeatures.DisplayAndMenu.DisplayAndMenu DisplayAndMenu
  {
    get
    {
      if (this._displayAndMenu == null)
        this._displayAndMenu = FeatureManager.GetFeature(2010)[0] as Motorola.MackinawCPS.CoreFeatures.DisplayAndMenu.DisplayAndMenu;
      return this._displayAndMenu;
    }
  }

  public Motorola.MackinawCPS.CoreFeatures.SecureWide.SecureWide SecureWide
  {
    get
    {
      if (this._secureWide == null)
        this._secureWide = FeatureManager.GetFeature(2021)[0] as Motorola.MackinawCPS.CoreFeatures.SecureWide.SecureWide;
      return this._secureWide;
    }
  }

  public Motorola.MackinawCPS.CoreFeatures.DataWide.DataWide DataWide
  {
    get
    {
      if (this._dataWide == null)
        this._dataWide = FeatureManager.GetFeature(2028)[0] as Motorola.MackinawCPS.CoreFeatures.DataWide.DataWide;
      return this._dataWide;
    }
  }

  public VoiceAnnouncementWide VoiceAnnouncementWide
  {
    get
    {
      if (this._voiceAnnouncementsWide == null)
        this._voiceAnnouncementsWide = FeatureManager.GetFeature(2301)[0] as VoiceAnnouncementWide;
      return this._voiceAnnouncementsWide;
    }
  }

  public Motorola.MackinawCPS.CoreFeatures.DataProfiles.DataProfiles DataProfiles
  {
    get
    {
      if (this._dataProfiles == null)
        this._dataProfiles = FeatureManager.GetFeature(2054)[0] as Motorola.MackinawCPS.CoreFeatures.DataProfiles.DataProfiles;
      return this._dataProfiles;
    }
  }

  public DACListInner DACListInner
  {
    get
    {
      if (this._DACListInner == null)
        this._DACListInner = (this.DataProfiles.DAC.EmbeddedRecset as DACListInnerRecset)[0] as DACListInner;
      return this._DACListInner;
    }
  }

  public EIDBypassListInner EIDBypassListInner
  {
    get
    {
      if (this._eidBypassListInner == null)
      {
        if (this.DataProfiles.EIDBypassList.EmbeddedRecset.Count == 0)
          this.DataProfiles.EIDBypassList.EmbeddedRecset.AddDefaultRecord();
        this._eidBypassListInner = (this.DataProfiles.EIDBypassList.EmbeddedRecset as EIDBypassListInnerRecset)[0] as EIDBypassListInner;
      }
      return this._eidBypassListInner;
    }
  }

  public TrunkingGroupIDListInner TrunkingGroupIDListInner
  {
    get
    {
      if (this._trunkingGroupIDListInner == null)
        this._trunkingGroupIDListInner = (this.DataProfiles.TrunkingGroupID.EmbeddedRecset as TrunkingGroupIDListInnerRecset)[0] as TrunkingGroupIDListInner;
      return this._trunkingGroupIDListInner;
    }
  }

  public Motorola.MackinawCPS.CoreFeatures.ConventionalSystem.ConventionalSystem ConventionalSystem
  {
    get
    {
      if (this._conventionalSystem == null)
        this._conventionalSystem = FeatureManager.GetFeature(2053)[0] as Motorola.MackinawCPS.CoreFeatures.ConventionalSystem.ConventionalSystem;
      return this._conventionalSystem;
    }
  }

  public Motorola.MackinawCPS.CoreFeatures.ConventionalPersonality.ConventionalPersonality ConventionalPersonality
  {
    get
    {
      this._conventionalPersonality = FeatureManager.GetFeature(2059)[0] as Motorola.MackinawCPS.CoreFeatures.ConventionalPersonality.ConventionalPersonality;
      return this._conventionalPersonality;
    }
  }

  public Motorola.MackinawCPS.CoreFeatures.ConventionalWide.ConventionalWide ConventionalWide
  {
    get
    {
      if (this._conventionalWide == null)
        this._conventionalWide = FeatureManager.GetFeature(2024)[0] as Motorola.MackinawCPS.CoreFeatures.ConventionalWide.ConventionalWide;
      return this._conventionalWide;
    }
  }

  public Motorola.MackinawCPS.CoreFeatures.DEK.DEK DEK
  {
    get
    {
      if (this._DEK == null)
        this._DEK = FeatureManager.GetFeature(2129)[0] as Motorola.MackinawCPS.CoreFeatures.DEK.DEK;
      return this._DEK;
    }
  }

  public Motorola.MackinawCPS.CoreFeatures.DVRSProfiles.DVRSProfiles DVRSProfiles
  {
    get
    {
      if (this._DVRSProfiles == null)
        this._DVRSProfiles = FeatureManager.GetFeature(4143)[0] as Motorola.MackinawCPS.CoreFeatures.DVRSProfiles.DVRSProfiles;
      return this._DVRSProfiles;
    }
  }

  public Motorola.MackinawCPS.CoreFeatures.DVRSWide.DVRSWide DVRSWide
  {
    get
    {
      if (this._DVRSWide == null)
        this._DVRSWide = FeatureManager.GetFeature(4142)[0] as Motorola.MackinawCPS.CoreFeatures.DVRSWide.DVRSWide;
      return this._DVRSWide;
    }
  }

  public Motorola.MackinawCPS.CoreFeatures.EmergencyWide.EmergencyWide EmergencyWide
  {
    get
    {
      if (this._emergencyWide == null)
        this._emergencyWide = FeatureManager.GetFeature(2032)[0] as Motorola.MackinawCPS.CoreFeatures.EmergencyWide.EmergencyWide;
      return this._emergencyWide;
    }
  }

  public Motorola.MackinawCPS.CoreFeatures.EnhancedDataPortList.EnhancedDataPortList EnhancedDataPortList
  {
    get
    {
      if (this._enhancedDataPortList == null)
        this._enhancedDataPortList = FeatureManager.GetFeature(4148)[0] as Motorola.MackinawCPS.CoreFeatures.EnhancedDataPortList.EnhancedDataPortList;
      return this._enhancedDataPortList;
    }
  }

  public Motorola.MackinawCPS.CoreFeatures.ExternalMicNoiseReductionProfile.ExternalMicNoiseReductionProfile ExternalMicNoiseReductionProfile
  {
    get
    {
      if (this._externalMicNoiseReductionProfile == null)
        this._externalMicNoiseReductionProfile = FeatureManager.GetFeature(2087)[0] as Motorola.MackinawCPS.CoreFeatures.ExternalMicNoiseReductionProfile.ExternalMicNoiseReductionProfile;
      return this._externalMicNoiseReductionProfile;
    }
  }

  public Motorola.MackinawCPS.CoreFeatures.FactoryOverrides.FactoryOverrides FactoryOverrides
  {
    get
    {
      if (this._factoryOverrides == null)
        this._factoryOverrides = FeatureManager.GetFeature(2003)[0] as Motorola.MackinawCPS.CoreFeatures.FactoryOverrides.FactoryOverrides;
      return this._factoryOverrides;
    }
  }

  public Motorola.MackinawCPS.CoreFeatures.GlobalNoiseReductionList.GlobalNoiseReductionList GlobalNoiseReductionList
  {
    get
    {
      if (this._globalNoiseReductionList == null)
        this._globalNoiseReductionList = FeatureManager.GetFeature(2131)[0] as Motorola.MackinawCPS.CoreFeatures.GlobalNoiseReductionList.GlobalNoiseReductionList;
      return this._globalNoiseReductionList;
    }
  }

  public Motorola.MackinawCPS.CoreFeatures.InternalMicNoiseReductionProfile.InternalMicNoiseReductionProfile InternalMicNoiseReductionProfile
  {
    get
    {
      if (this._internalMicNoiseReductionProfile == null)
        this._internalMicNoiseReductionProfile = FeatureManager.GetFeature(2086)[0] as Motorola.MackinawCPS.CoreFeatures.InternalMicNoiseReductionProfile.InternalMicNoiseReductionProfile;
      return this._internalMicNoiseReductionProfile;
    }
  }

  public Motorola.MackinawCPS.CoreFeatures.Keypad.Keypad Keypad
  {
    get
    {
      if (this._keypad == null)
        this._keypad = FeatureManager.GetFeature(4109)[0] as Motorola.MackinawCPS.CoreFeatures.Keypad.Keypad;
      return this._keypad;
    }
  }

  public Motorola.MackinawCPS.CoreFeatures.KeypadMicAndAccessories.KeypadMicAndAccessories KeypadMicAndAccessories
  {
    get
    {
      if (this._keypadMicAndAccessories == null)
        this._keypadMicAndAccessories = FeatureManager.GetFeature(2128)[0] as Motorola.MackinawCPS.CoreFeatures.KeypadMicAndAccessories.KeypadMicAndAccessories;
      return this._keypadMicAndAccessories;
    }
  }

  public KMButtonInner KMButtonInner
  {
    get
    {
      if (this._KMButtonInner == null)
        this._KMButtonInner = (this.KeypadMicAndAccessories.General.EmbeddedRecset as KMButtonInnerRecset)[0] as KMButtonInner;
      return this._KMButtonInner;
    }
  }

  public Motorola.MackinawCPS.CoreFeatures.KeypadMicAndAccessories.DataButtonInner KeyPadMicDataButtonInner
  {
    get
    {
      if (this._keyPadMicDataButtonInner == null)
        this._keyPadMicDataButtonInner = (this.KeypadMicAndAccessories.Data.EmbeddedRecset as Motorola.MackinawCPS.CoreFeatures.KeypadMicAndAccessories.DataButtonInnerRecset)[0] as Motorola.MackinawCPS.CoreFeatures.KeypadMicAndAccessories.DataButtonInner;
      return this._keyPadMicDataButtonInner;
    }
  }

  public KMANavigationControlsTableInner KMANavigationControlsTableInner
  {
    get
    {
      if (this._KMANavigationControlsTableInner == null)
        this._KMANavigationControlsTableInner = (this.KeypadMicAndAccessories.KMANavigationControlsExpander.EmbeddedRecset as KMANavigationControlsTableInnerRecset)[0] as KMANavigationControlsTableInner;
      return this._KMANavigationControlsTableInner;
    }
  }

  public KMANavigationControlsTableInner KMANavigationControlsTableInner_Down
  {
    get
    {
      if (this._KMANavigationControlsTableInner_Down == null)
        this._KMANavigationControlsTableInner_Down = (this.KeypadMicAndAccessories.KMANavigationControlsExpander.EmbeddedRecset as KMANavigationControlsTableInnerRecset)[1] as KMANavigationControlsTableInner;
      return this._KMANavigationControlsTableInner_Down;
    }
  }

  public KeypadButtonInner KeypadButtonInner
  {
    get
    {
      if (this._keypadButtonInner == null)
        this._keypadButtonInner = (this.Keypad.General.EmbeddedRecset as KeypadButtonInnerRecset)[0] as KeypadButtonInner;
      return this._keypadButtonInner;
    }
  }

  public SecondLOInjectionFrequencyListInner SecondLOInjectionFrequencyListInner
  {
    get
    {
      if (this._secondLOInjectionFrequencyListInner == null)
      {
        if (this.FactoryOverrides.SecondLOInjectionFrequency.EmbeddedRecset.Count == 0)
          this.FactoryOverrides.SecondLOInjectionFrequency.EmbeddedRecset.AddDefaultRecord();
        this._secondLOInjectionFrequencyListInner = (this.FactoryOverrides.SecondLOInjectionFrequency.EmbeddedRecset as SecondLOInjectionFrequencyListInnerRecset)[0] as SecondLOInjectionFrequencyListInner;
      }
      return this._secondLOInjectionFrequencyListInner;
    }
  }

  public RxFrequencyListInner RxFrequencyListInner
  {
    get
    {
      if (this._rxFrequencyListInner == null && this.FactoryOverrides.RxFrequency != null)
      {
        if (this.FactoryOverrides.RxFrequency.EmbeddedRecset.Count == 0)
          this.FactoryOverrides.RxFrequency.EmbeddedRecset.AddDefaultRecord();
        this._rxFrequencyListInner = (this.FactoryOverrides.RxFrequency.EmbeddedRecset as RxFrequencyListInnerRecset)[0] as RxFrequencyListInner;
      }
      return this._rxFrequencyListInner;
    }
  }

  public RxSynthesizerReferenceDividerListInner RxSynthesizerReferenceDividerListInner
  {
    get
    {
      if (this._rxSynthesizerReferenceDividerListInner == null)
      {
        if (this.FactoryOverrides.RxSynthesizerReferenceDividerList.EmbeddedRecset.Count == 0)
          this.FactoryOverrides.RxSynthesizerReferenceDividerList.EmbeddedRecset.AddDefaultRecord();
        this._rxSynthesizerReferenceDividerListInner = (this.FactoryOverrides.RxSynthesizerReferenceDividerList.EmbeddedRecset as RxSynthesizerReferenceDividerListInnerRecset)[0] as RxSynthesizerReferenceDividerListInner;
      }
      return this._rxSynthesizerReferenceDividerListInner;
    }
  }

  public TxSynthesizerReferenceDividerListInner TxSynthesizerReferenceDividerListInner
  {
    get
    {
      if (this._txSynthesizerReferenceDividerListInner == null)
      {
        if (this.FactoryOverrides.TxSynthesizerReferenceDividerList.EmbeddedRecset.Count == 0)
          this.FactoryOverrides.TxSynthesizerReferenceDividerList.EmbeddedRecset.AddDefaultRecord();
        this._txSynthesizerReferenceDividerListInner = (this.FactoryOverrides.TxSynthesizerReferenceDividerList.EmbeddedRecset as TxSynthesizerReferenceDividerListInnerRecset)[0] as TxSynthesizerReferenceDividerListInner;
      }
      return this._txSynthesizerReferenceDividerListInner;
    }
  }

  public TxSSIClockRateListInner TxSSIClockRateListInner
  {
    get
    {
      if (this._txSSIClockRateListInner == null)
      {
        if (this.FactoryOverrides.TxSSIClockRateList.EmbeddedRecset.Count == 0)
          this.FactoryOverrides.TxSSIClockRateList.EmbeddedRecset.AddDefaultRecord();
        this._txSSIClockRateListInner = (this.FactoryOverrides.TxSSIClockRateList.EmbeddedRecset as TxSSIClockRateListInnerRecset)[0] as TxSSIClockRateListInner;
      }
      return this._txSSIClockRateListInner;
    }
  }

  public EnhancedDataPortTableInner EnhancedDataPortTableInner
  {
    get
    {
      if (this._enhancedDataPortTableInner == null)
        this._enhancedDataPortTableInner = (this.EnhancedDataPortList.EnhancedDataPortList42005.EmbeddedRecset as EnhancedDataPortTableInnerRecset)[0] as EnhancedDataPortTableInner;
      return this._enhancedDataPortTableInner;
    }
  }

  public IDDisplayTableInner IDDisplayTableInner
  {
    get
    {
      if (this._IDDisplayTableInner == null)
        this._IDDisplayTableInner = (this.DisplayAndMenu.IDDisplay.EmbeddedRecset as IDDisplayTableInnerRecset)[0] as IDDisplayTableInner;
      return this._IDDisplayTableInner;
    }
  }

  public BacklightColorsInner BacklightColorsInner
  {
    get
    {
      if (this._backlightColorsInner == null)
        this._backlightColorsInner = (this.DisplayAndMenu.BacklightColorControl.EmbeddedRecset as BacklightColorsInnerRecset)[0] as BacklightColorsInner;
      return this._backlightColorsInner;
    }
  }

  public DEKButtonInner DEKButtonInner
  {
    get
    {
      if (this._DEKButtonInner == null)
        this._DEKButtonInner = (this.DEK.General.EmbeddedRecset as DEKButtonInnerRecset)[0] as DEKButtonInner;
      return this._DEKButtonInner;
    }
  }

  public DEKVIPInner DEKVIPInner
  {
    get
    {
      if (this._DEKVIPInner == null)
        this._DEKVIPInner = (this.DEK.DEKVIP.EmbeddedRecset as DEKVIPInnerRecset)[0] as DEKVIPInner;
      return this._DEKVIPInner;
    }
  }

  public DirectMessageListInner DirectMessageListInner
  {
    get
    {
      if (this._directMessageListInner == null)
        this._directMessageListInner = (this.DEK.DirectMessage.EmbeddedRecset as DirectMessageListInnerRecset)[0] as DirectMessageListInner;
      return this._directMessageListInner;
    }
  }

  public DirectStatusBCOListInner DirectStatusBCOListInner
  {
    get
    {
      if (this._directStatusBCOListInner == null)
        this._directStatusBCOListInner = (this.DEK.DirectStatus.EmbeddedRecset as DirectStatusBCOListInnerRecset)[0] as DirectStatusBCOListInner;
      return this._directStatusBCOListInner;
    }
  }

  public DirectModeBCOListInner DirectModeBCOListInner
  {
    get
    {
      if (this._directModeBCOListInner == null)
      {
        if (this.DEK.DirectMode.EmbeddedRecset.Count == 0)
          this.DEK.DirectMode.EmbeddedRecset.AddDefaultRecord();
        this._directModeBCOListInner = (this.DEK.DirectMode.EmbeddedRecset as DirectModeBCOListInnerRecset)[0] as DirectModeBCOListInner;
      }
      return this._directModeBCOListInner;
    }
  }

  public ASTROGroupIDListInner ASTROGroupIDListInner
  {
    get
    {
      if (this._ASTROGroupIDListInner == null)
        this._ASTROGroupIDListInner = (this.ConventionalWide.ASTROGroupID.EmbeddedRecset as ASTROGroupIDListInnerRecset)[0] as ASTROGroupIDListInner;
      return this._ASTROGroupIDListInner;
    }
  }

  public OTACInner OTACInner
  {
    get
    {
      if (this._OTACInner == null)
        this._OTACInner = (this.ConventionalWide.ASTROOTAC.EmbeddedRecset as OTACInnerRecset)[0] as OTACInner;
      return this._OTACInner;
    }
  }

  public NATListInner NATListInner
  {
    get
    {
      if (this._NATListInner == null)
      {
        if (this.DataWide.NATList.EmbeddedRecset.Count == 0 && !FieldAccessor.IsCpsApiTest)
          this.DataWide.NATList.EmbeddedRecset.AddDefaultRecord();
        this._NATListInner = (this.DataWide.NATList.EmbeddedRecset as NATListInnerRecset)[0] as NATListInner;
      }
      return this._NATListInner;
    }
  }

  public ConfiguredNetworksListInner ConfiguredNetworksListInner
  {
    get
    {
      if (this._ConfiguredNetworksListInner == null)
      {
        if (this.DataWide.WIFI.EmbeddedRecset.Count == 0)
          this.DataWide.WIFI.EmbeddedRecset.AddDefaultRecord();
        this._ConfiguredNetworksListInner = (this.DataWide.WIFI.EmbeddedRecset as ConfiguredNetworksListInnerRecset)[0] as ConfiguredNetworksListInner;
      }
      return this._ConfiguredNetworksListInner;
    }
  }

  public DataUserListInner DataUserListInner
  {
    get
    {
      if (this._dataUserListInner == null)
        this._dataUserListInner = (this.DataWide.DataUserList.EmbeddedRecset as DataUserListInnerRecset)[0] as DataUserListInner;
      return this._dataUserListInner;
    }
  }

  public QuickTextMessageListInner QuickTextMessageListInner
  {
    get
    {
      if (this._quickTextMessageListInner == null)
        this._quickTextMessageListInner = (this.DataWide.QuickTextMessageList.EmbeddedRecset as QuickTextMessageListInnerRecset)[0] as QuickTextMessageListInner;
      return this._quickTextMessageListInner;
    }
  }

  public FrequencyOptionsInner FrequencyOptionsInner
  {
    get
    {
      if (this._frequencyOptionsInner == null)
        this._frequencyOptionsInner = (this.ConventionalPersonality.FrequencyOptions.EmbeddedRecset as FrequencyOptionsInnerRecset)[0] as FrequencyOptionsInner;
      return this._frequencyOptionsInner;
    }
  }

  public Motorola.MackinawCPS.CoreFeatures.ConventionalPersonality.OneTouchInner CnvOneTouchInner
  {
    get
    {
      if (this._cnvOneTouchInner == null)
        this._cnvOneTouchInner = (this.ConventionalPersonality.OneTouch.EmbeddedRecset as Motorola.MackinawCPS.CoreFeatures.ConventionalPersonality.OneTouchInnerRecset)[0] as Motorola.MackinawCPS.CoreFeatures.ConventionalPersonality.OneTouchInner;
      return this._cnvOneTouchInner;
    }
  }

  public Motorola.MackinawCPS.CoreFeatures.ScanList.ScanList ScanList
  {
    get
    {
      if (this._scanList == null)
        this._scanList = FeatureManager.GetFeature(2057)[0] as Motorola.MackinawCPS.CoreFeatures.ScanList.ScanList;
      return this._scanList;
    }
  }

  public ScanListInner ScanListInner
  {
    get
    {
      if (this._scanListInner == null)
        this._scanListInner = (this.ScanList.ScanListMembers.EmbeddedRecset as ScanListInnerRecset)[0] as ScanListInner;
      return this._scanListInner;
    }
  }

  public Motorola.MackinawCPS.CoreFeatures.ZoneChannelAssignment.ZoneChannelAssignment ZoneChannelAssignment
  {
    get
    {
      if (this._zoneChannelAssignment == null)
        this._zoneChannelAssignment = FeatureManager.GetFeature(2051)[0] as Motorola.MackinawCPS.CoreFeatures.ZoneChannelAssignment.ZoneChannelAssignment;
      return this._zoneChannelAssignment;
    }
  }

  public ChannelAssignmentListInner ChannelAssignmentListInner
  {
    get
    {
      if (this._channelAssignmentListInner == null)
        this._channelAssignmentListInner = (this.ZoneChannelAssignment.Channels.EmbeddedRecset as ChannelAssignmentListInnerRecset)[0] as ChannelAssignmentListInner;
      return this._channelAssignmentListInner;
    }
  }

  public TxPowerLevelsByFrequencyRangeInner TxPowerLevelsByFrequencyRangeInner
  {
    get
    {
      if (this._txPowerLevelsByFrequencyRangeInner == null)
        this._txPowerLevelsByFrequencyRangeInner = (this.RadioWide.TransmitPowerLevels.EmbeddedRecset as TxPowerLevelsByFrequencyRangeInnerRecset)[0] as TxPowerLevelsByFrequencyRangeInner;
      return this._txPowerLevelsByFrequencyRangeInner;
    }
  }

  public TxPowerLevelsByFrequencyRangeNewBandPlanInner TxPowerLevelsByFrequencyRangeNewBandPlanInner
  {
    get
    {
      if (this._txPowerLevelsByFrequencyRangeNewBandPlanInner == null)
        this._txPowerLevelsByFrequencyRangeNewBandPlanInner = (this.RadioWide.TxPowerLevelsNewBandPlan.EmbeddedRecset as TxPowerLevelsByFrequencyRangeNewBandPlanInnerRecset)[0] as TxPowerLevelsByFrequencyRangeNewBandPlanInner;
      return this._txPowerLevelsByFrequencyRangeNewBandPlanInner;
    }
  }

  public RxFrequencySplitFPPInner RxFrequencySplitFPPInner
  {
    get
    {
      if (this._rxFrequencySplitFPPInner == null)
        this._rxFrequencySplitFPPInner = (this.RadioWide.RxFrequencySplit.EmbeddedRecset as RxFrequencySplitFPPInnerRecset)[0] as RxFrequencySplitFPPInner;
      return this._rxFrequencySplitFPPInner;
    }
  }

  public TxFrequencySplitFPPInner TxFrequencySplitFPPInner
  {
    get
    {
      if (this._txFrequencySplitFPPInner == null)
        this._txFrequencySplitFPPInner = (this.RadioWide.TxFrequencySplit.EmbeddedRecset as TxFrequencySplitFPPInnerRecset)[0] as TxFrequencySplitFPPInner;
      return this._txFrequencySplitFPPInner;
    }
  }

  public FCCNarrowBandingFrequencySplitInner FCCNarrowBandingFrequencySplitInner
  {
    get
    {
      if (this._FCCNarrowBandingFrequencySplitInner == null)
        this._FCCNarrowBandingFrequencySplitInner = (this.RadioWide.FCCNarrowBandingFrequencySplit.EmbeddedRecset as FCCNarrowBandingFrequencySplitInnerRecset)[0] as FCCNarrowBandingFrequencySplitInner;
      return this._FCCNarrowBandingFrequencySplitInner;
    }
  }

  public GeneralLightbarPatternInner GeneralLightbarPatternInner
  {
    get
    {
      if (this._generalLightbarPatternInner == null)
        this._generalLightbarPatternInner = (this.RadioWide.LightbarPattern.EmbeddedRecset as GeneralLightbarPatternInnerRecset)[0] as GeneralLightbarPatternInner;
      return this._generalLightbarPatternInner;
    }
  }

  public RelockTimerInner RelockTimerInner
  {
    get
    {
      if (this._relockTimerInner == null)
        this._relockTimerInner = (this.RadioWide.GunLock.EmbeddedRecset as RelockTimerInnerRecset)[0] as RelockTimerInner;
      return this._relockTimerInner;
    }
  }

  public TrunkingCallHotList TrunkingCallHotList
  {
    get
    {
      if (this._trunkingCallHotList == null)
        this._trunkingCallHotList = (this.UclTrunkingCallHotList.TrunkingCallHotList.EmbeddedRecset as TrunkingCallHotListRecset)[0] as TrunkingCallHotList;
      return this._trunkingCallHotList;
    }
  }

  public UclContact UclContact
  {
    get
    {
      if (this._uclContact == null)
        this._uclContact = FeatureManager.GetFeature(2200)[0] as UclContact;
      return this._uclContact;
    }
  }

  public UclMDCCallHotList UclMDCCallHotList
  {
    get
    {
      if (this._uclMDCCallHotList == null)
        this._uclMDCCallHotList = FeatureManager.GetFeature(2212)[0] as UclMDCCallHotList;
      return this._uclMDCCallHotList;
    }
  }

  public MDCCallHotList MDCCallHotList
  {
    get
    {
      if (this._MDCCallHotList == null)
        this._MDCCallHotList = (this.UclMDCCallHotList.MDCCallHotList.EmbeddedRecset as MDCCallHotListRecset)[0] as MDCCallHotList;
      return this._MDCCallHotList;
    }
  }

  public UclTrunkingCallHotList UclTrunkingCallHotList
  {
    get
    {
      if (this._uclTrunkingCallHotList == null)
        this._uclTrunkingCallHotList = FeatureManager.GetFeature(2208)[0] as UclTrunkingCallHotList;
      return this._uclTrunkingCallHotList;
    }
  }

  public UclAstroCallHotList UclAstroCallHotList
  {
    get
    {
      if (this._uclAstroCallHotList == null)
        this._uclAstroCallHotList = FeatureManager.GetFeature(2210)[0] as UclAstroCallHotList;
      return this._uclAstroCallHotList;
    }
  }

  public Motorola.MackinawCPS.CoreFeatures.ASTROTalkgroupList.ASTROTalkgroupList ASTROTalkgroupList
  {
    get
    {
      if (this._ASTROTalkgroupList == null)
        this._ASTROTalkgroupList = FeatureManager.GetFeature(2062)[0] as Motorola.MackinawCPS.CoreFeatures.ASTROTalkgroupList.ASTROTalkgroupList;
      return this._ASTROTalkgroupList;
    }
  }

  public TalkgroupTableInner TalkgroupTableInner
  {
    get
    {
      if (this._talkgroupTableInner == null)
        this._talkgroupTableInner = (this.ASTROTalkgroupList.TalkgroupList.EmbeddedRecset as TalkgroupTableInnerRecset)[0] as TalkgroupTableInner;
      return this._talkgroupTableInner;
    }
  }

  public Motorola.MackinawCPS.CoreFeatures.ControlHeadO2.ControlHeadO2 ControlHeadO2
  {
    get
    {
      if (this._controlHeadO2 == null)
        this._controlHeadO2 = FeatureManager.GetFeature(4115)[0] as Motorola.MackinawCPS.CoreFeatures.ControlHeadO2.ControlHeadO2;
      return this._controlHeadO2;
    }
  }

  public O2Inner O2Inner
  {
    get
    {
      if (this._O2Inner == null)
        this._O2Inner = (this.ControlHeadO2.O2GeneralExpander.EmbeddedRecset as O2InnerRecset)[0] as O2Inner;
      return this._O2Inner;
    }
  }

  public O2MFKAssignmentControlInner O2MFKAssignmentControlInner
  {
    get
    {
      if (this._O2MFKAssignmentControlInner == null)
        this._O2MFKAssignmentControlInner = (this.ControlHeadO2.O2MultiFunctionKnob.EmbeddedRecset as O2MFKAssignmentControlInnerRecset)[0] as O2MFKAssignmentControlInner;
      return this._O2MFKAssignmentControlInner;
    }
  }

  public O2MFKAssignmentControlInner O2MFKAssignmentControlInner_1
  {
    get
    {
      if (this._O2MFKAssignmentControlInner_1 == null)
        this._O2MFKAssignmentControlInner_1 = (this.ControlHeadO2.O2MultiFunctionKnob.EmbeddedRecset as O2MFKAssignmentControlInnerRecset)[1] as O2MFKAssignmentControlInner;
      return this._O2MFKAssignmentControlInner_1;
    }
  }

  public O2NavigationControlsTableInner O2NavigationControlsTableInner
  {
    get
    {
      if (this._O2NavigationControlsTableInner == null)
        this._O2NavigationControlsTableInner = (this.ControlHeadO2.O2NavigationControlsExpander.EmbeddedRecset as O2NavigationControlsTableInnerRecset)[0] as O2NavigationControlsTableInner;
      return this._O2NavigationControlsTableInner;
    }
  }

  public O2NavigationControlsTableInner O2NavigationControlsTableInner_Down
  {
    get
    {
      if (this._O2NavigationControlsTableInner_Down == null)
        this._O2NavigationControlsTableInner_Down = (this.ControlHeadO2.O2NavigationControlsExpander.EmbeddedRecset as O2NavigationControlsTableInnerRecset)[1] as O2NavigationControlsTableInner;
      return this._O2NavigationControlsTableInner_Down;
    }
  }

  public Motorola.MackinawCPS.CoreFeatures.ControlHeadO3.ControlHeadO3 ControlHeadO3
  {
    get
    {
      if (this._controlHeadO3 == null)
        this._controlHeadO3 = FeatureManager.GetFeature(2127)[0] as Motorola.MackinawCPS.CoreFeatures.ControlHeadO3.ControlHeadO3;
      return this._controlHeadO3;
    }
  }

  public O3HHCHButtonInner O3HHCHButtonInner
  {
    get
    {
      if (this._O3HHCHButtonInner == null)
        this._O3HHCHButtonInner = (this.ControlHeadO3.General.EmbeddedRecset as O3HHCHButtonInnerRecset)[0] as O3HHCHButtonInner;
      return this._O3HHCHButtonInner;
    }
  }

  public Motorola.MackinawCPS.CoreFeatures.ControlHeadO5.ControlHeadO5 ControlHeadO5
  {
    get
    {
      if (this._controlHeadO5 == null)
        this._controlHeadO5 = FeatureManager.GetFeature(2130)[0] as Motorola.MackinawCPS.CoreFeatures.ControlHeadO5.ControlHeadO5;
      return this._controlHeadO5;
    }
  }

  public O5Inner O5Inner
  {
    get
    {
      if (this._O5Inner == null)
        this._O5Inner = (this.ControlHeadO5.General.EmbeddedRecset as O5InnerRecset)[0] as O5Inner;
      return this._O5Inner;
    }
  }

  public O5NavigationControlsTableInner O5NavigationControlsTableInner
  {
    get
    {
      if (this._O5NavigationControlsTableInner == null)
        this._O5NavigationControlsTableInner = (this.ControlHeadO5.O5NavigationControlsExpander.EmbeddedRecset as O5NavigationControlsTableInnerRecset)[0] as O5NavigationControlsTableInner;
      return this._O5NavigationControlsTableInner;
    }
  }

  public O5NavigationControlsTableInner O5NavigationControlsTableInner_Down
  {
    get
    {
      if (this._O5NavigationControlsTableInner_Down == null)
        this._O5NavigationControlsTableInner_Down = (this.ControlHeadO5.O5NavigationControlsExpander.EmbeddedRecset as O5NavigationControlsTableInnerRecset)[1] as O5NavigationControlsTableInner;
      return this._O5NavigationControlsTableInner_Down;
    }
  }

  public Motorola.MackinawCPS.CoreFeatures.ControlHeadO7.ControlHeadO7 ControlHeadO7
  {
    get
    {
      if (this._controlHeadO7 == null)
        this._controlHeadO7 = FeatureManager.GetFeature(4114)[0] as Motorola.MackinawCPS.CoreFeatures.ControlHeadO7.ControlHeadO7;
      return this._controlHeadO7;
    }
  }

  public O7Inner O7Inner
  {
    get
    {
      if (this._O7Inner == null)
        this._O7Inner = (this.ControlHeadO7.O7GeneralExpander.EmbeddedRecset as O7InnerRecset)[0] as O7Inner;
      return this._O7Inner;
    }
  }

  public O7DataButtonInner O7DataButtonInner
  {
    get
    {
      if (this._O7DataButtonInner == null)
        this._O7DataButtonInner = (this.ControlHeadO7.O7DataButton.EmbeddedRecset as O7DataButtonInnerRecset)[0] as O7DataButtonInner;
      return this._O7DataButtonInner;
    }
  }

  public O7MFKAssignmentControlInner O7MFKAssignmentControlInner
  {
    get
    {
      if (this._O7MFKAssignmentControlInner == null)
        this._O7MFKAssignmentControlInner = (this.ControlHeadO7.O7MultiFunctionKnob.EmbeddedRecset as O7MFKAssignmentControlInnerRecset)[0] as O7MFKAssignmentControlInner;
      return this._O7MFKAssignmentControlInner;
    }
  }

  public O7MFKAssignmentControlInner O7MFKAssignmentControlInner_1
  {
    get
    {
      if (this._O7MFKAssignmentControlInner_1 == null)
        this._O7MFKAssignmentControlInner_1 = (this.ControlHeadO7.O7MultiFunctionKnob.EmbeddedRecset as O7MFKAssignmentControlInnerRecset)[1] as O7MFKAssignmentControlInner;
      return this._O7MFKAssignmentControlInner_1;
    }
  }

  public O7NavigationControlsTableInner O7NavigationControlsTableInner
  {
    get
    {
      if (this._O7NavigationControlsTableInner == null)
        this._O7NavigationControlsTableInner = (this.ControlHeadO7.O7NavigationControlsExpander.EmbeddedRecset as O7NavigationControlsTableInnerRecset)[0] as O7NavigationControlsTableInner;
      return this._O7NavigationControlsTableInner;
    }
  }

  public O7NavigationControlsTableInner O7NavigationControlsTableInner_Down
  {
    get
    {
      if (this._O7NavigationControlsTableInner_Down == null)
        this._O7NavigationControlsTableInner_Down = (this.ControlHeadO7.O7NavigationControlsExpander.EmbeddedRecset as O7NavigationControlsTableInnerRecset)[1] as O7NavigationControlsTableInner;
      return this._O7NavigationControlsTableInner_Down;
    }
  }

  public Motorola.MackinawCPS.CoreFeatures.ControlHeadE5.ControlHeadE5 ControlHeadE5
  {
    get
    {
      if (this._controlHeadE5 == null)
        this._controlHeadE5 = FeatureManager.GetFeature(4236)[0] as Motorola.MackinawCPS.CoreFeatures.ControlHeadE5.ControlHeadE5;
      return this._controlHeadE5;
    }
  }

  public E5Inner E5Inner
  {
    get
    {
      if (this._E5Inner == null)
        this._E5Inner = (this.ControlHeadE5.E5GeneralExpander.EmbeddedRecset as E5InnerRecset)[0] as E5Inner;
      return this._E5Inner;
    }
  }

  public E5BottomFunctionButtonInner E5BottomFunctionButtonInner
  {
    get
    {
      if (this._E5bottomFunctionButtonInner == null)
        this._E5bottomFunctionButtonInner = (this.ControlHeadE5.E5BottomFunctionButtonExpander.EmbeddedRecset as E5BottomFunctionButtonInnerRecset)[0] as E5BottomFunctionButtonInner;
      return this._E5bottomFunctionButtonInner;
    }
  }

  public E5NavigationControlsTableInner E5NavigationControlsTableInner
  {
    get
    {
      if (this._E5NavigationControlsTableInner == null)
      {
        E5NavigationControlsTableInnerRecset embeddedRecset = this.ControlHeadE5.E5NavigationControlsExpander.EmbeddedRecset as E5NavigationControlsTableInnerRecset;
        this.E5NavigationControlsTableInit(embeddedRecset);
        this._E5NavigationControlsTableInner = embeddedRecset[0] as E5NavigationControlsTableInner;
      }
      return this._E5NavigationControlsTableInner;
    }
  }

  public E5NavigationControlsTableInner E5NavigationControlsTableInner_Down
  {
    get
    {
      if (this._E5NavigationControlsTableInner_Down == null)
      {
        E5NavigationControlsTableInnerRecset embeddedRecset = this.ControlHeadE5.E5NavigationControlsExpander.EmbeddedRecset as E5NavigationControlsTableInnerRecset;
        this.E5NavigationControlsTableInit(embeddedRecset);
        this._E5NavigationControlsTableInner_Down = embeddedRecset[1] as E5NavigationControlsTableInner;
      }
      return this._E5NavigationControlsTableInner_Down;
    }
  }

  private void E5NavigationControlsTableInit(E5NavigationControlsTableInnerRecset recset)
  {
    if (recset == null || recset.Count >= 2)
      return;
    while (recset.Count < 2)
      recset.AddDefaultRecord();
    E5NavigationControlsTableInner controlsTableInner = recset[1] as E5NavigationControlsTableInner;
    E5NavigationControlsTableInnerSection tableInnerSection1 = controlsTableInner.E5NavigationControlsTableInnerSection;
    O7NavigationControlsTableInnerRecset parent = this.O7NavigationControlsTableInner.Parent as O7NavigationControlsTableInnerRecset;
    if (controlsTableInner != null && parent != null && parent.Count > 1)
    {
      O7NavigationControlsTableInnerSection tableInnerSection2 = (parent[1] as O7NavigationControlsTableInner).O7NavigationControlsTableInnerSection;
      tableInnerSection1.RadErgoControlE5UpDownButton_43752.SetValue(tableInnerSection2.RadErgoControlO7UpDownButton_A41293.Value);
    }
    tableInnerSection1.E5UpDownButtonName_43753.SetValue(AppResources.Down_Button);
  }

  public Motorola.MackinawCPS.CoreFeatures.ControlHeadO9.ControlHeadO9 ControlHeadO9
  {
    get
    {
      if (this._controlHeadO9 == null)
        this._controlHeadO9 = FeatureManager.GetFeature(4003)[0] as Motorola.MackinawCPS.CoreFeatures.ControlHeadO9.ControlHeadO9;
      return this._controlHeadO9;
    }
  }

  public O9Inner O9Inner
  {
    get
    {
      if (this._O9Inner == null)
        this._O9Inner = (this.ControlHeadO9.General.EmbeddedRecset as O9InnerRecset)[0] as O9Inner;
      return this._O9Inner;
    }
  }

  public O9DataButtonInner O9DataButtonInner
  {
    get
    {
      if (this._O9DataButtonInner == null)
        this._O9DataButtonInner = (this.ControlHeadO9.ControlHeadO9Data.EmbeddedRecset as O9DataButtonInnerRecset)[0] as O9DataButtonInner;
      return this._O9DataButtonInner;
    }
  }

  public TopFunctionProgrammableButtonListInner TopFunctionProgrammableButtonListInner
  {
    get
    {
      if (this._topFunctionProgrammableButtonListInner == null)
        this._topFunctionProgrammableButtonListInner = (this.ControlHeadO9.TopFunctionProgrammableButton.EmbeddedRecset as TopFunctionProgrammableButtonListInnerRecset)[0] as TopFunctionProgrammableButtonListInner;
      return this._topFunctionProgrammableButtonListInner;
    }
  }

  public BottomFunctionProgrammableButtonInner BottomFunctionProgrammableButtonInner
  {
    get
    {
      if (this._bottomFunctionProgrammableButtonInner == null)
        this._bottomFunctionProgrammableButtonInner = (this.ControlHeadO9.BottomFunctionProgrammableButton.EmbeddedRecset as BottomFunctionProgrammableButtonInnerRecset)[0] as BottomFunctionProgrammableButtonInner;
      return this._bottomFunctionProgrammableButtonInner;
    }
  }

  public ResponseSelectorListInner ResponseSelectorListInner
  {
    get
    {
      if (this._responseSelectorListInner == null)
        this._responseSelectorListInner = (this.ControlHeadO9.ResponseSelector.EmbeddedRecset as ResponseSelectorListInnerRecset)[0] as ResponseSelectorListInner;
      return this._responseSelectorListInner;
    }
  }

  public DirectionalButtonsListInner DirectionalButtonsListInner
  {
    get
    {
      if (this._directionalButtonsListInner == null)
        this._directionalButtonsListInner = (this.ControlHeadO9.DirectionalButtons.EmbeddedRecset as DirectionalButtonsListInnerRecset)[0] as DirectionalButtonsListInner;
      return this._directionalButtonsListInner;
    }
  }

  public PASirenButtonsListInner PASirenButtonsListInner
  {
    get
    {
      if (this._PASirenButtonsListInner == null)
        this._PASirenButtonsListInner = (this.ControlHeadO9.PASirenButtons.EmbeddedRecset as PASirenButtonsListInnerRecset)[0] as PASirenButtonsListInner;
      return this._PASirenButtonsListInner;
    }
  }

  public RelayPatternBCOListListInner RelayPatternBCOListListInner
  {
    get
    {
      if (this._relayPatternBCOListListInner == null)
        this._relayPatternBCOListListInner = (this.ControlHeadO9.RelayPatternBCOList.EmbeddedRecset as RelayPatternBCOListListInnerRecset)[0] as RelayPatternBCOListListInner;
      return this._relayPatternBCOListListInner;
    }
  }

  public ConsolidatedActionBCOListInner ConsolidatedActionBCOListInner
  {
    get
    {
      if (this._consolidatedActionBCOListInner == null)
      {
        if (this.ControlHeadO9.ConsolidatedActionBCOList.EmbeddedRecset.Count == 0)
          this.ControlHeadO9.ConsolidatedActionBCOList.EmbeddedRecset.AddDefaultRecord();
        this._consolidatedActionBCOListInner = (this.ControlHeadO9.ConsolidatedActionBCOList.EmbeddedRecset as ConsolidatedActionBCOListInnerRecset)[0] as ConsolidatedActionBCOListInner;
      }
      return this._consolidatedActionBCOListInner;
    }
  }

  public O9NavigationControlsTableInner O9NavigationControlsTableInner
  {
    get
    {
      if (this._O9NavigationControlsTableInner == null)
        this._O9NavigationControlsTableInner = (this.ControlHeadO9.O9NavigationControlsExpander.EmbeddedRecset as O9NavigationControlsTableInnerRecset)[0] as O9NavigationControlsTableInner;
      return this._O9NavigationControlsTableInner;
    }
  }

  public O9NavigationControlsTableInner O9NavigationControlsTableInner_Down
  {
    get
    {
      if (this._O9NavigationControlsTableInner_Down == null)
        this._O9NavigationControlsTableInner_Down = (this.ControlHeadO9.O9NavigationControlsExpander.EmbeddedRecset as O9NavigationControlsTableInnerRecset)[1] as O9NavigationControlsTableInner;
      return this._O9NavigationControlsTableInner_Down;
    }
  }

  public BottomFunctionButtonBCOListInner BottomFunctionButtonBCOListInner
  {
    get
    {
      if (this._bottomFunctionButtonBCOListInner == null)
        this._bottomFunctionButtonBCOListInner = (this.ControlHeadO9.Labtool.EmbeddedRecset as BottomFunctionButtonBCOListInnerRecset)[0] as BottomFunctionButtonBCOListInner;
      return this._bottomFunctionButtonBCOListInner;
    }
  }

  public Motorola.MackinawCPS.CoreFeatures.ControlHeadO3.DataButtonInner O3DataButtonInner
  {
    get
    {
      if (this._O3DataButtonInner == null)
        this._O3DataButtonInner = (this.ControlHeadO3.Data.EmbeddedRecset as Motorola.MackinawCPS.CoreFeatures.ControlHeadO3.DataButtonInnerRecset)[0] as Motorola.MackinawCPS.CoreFeatures.ControlHeadO3.DataButtonInner;
      return this._O3DataButtonInner;
    }
  }

  public O3NavigationControlsTableInner O3NavigationControlsTableInner
  {
    get
    {
      if (this._O3NavigationControlsTableInner == null)
        this._O3NavigationControlsTableInner = (this.ControlHeadO3.O3NavigationControlsExpander.EmbeddedRecset as O3NavigationControlsTableInnerRecset)[0] as O3NavigationControlsTableInner;
      return this._O3NavigationControlsTableInner;
    }
  }

  public O3NavigationControlsTableInner O3NavigationControlsTableInner_Down
  {
    get
    {
      if (this._O3NavigationControlsTableInner_Down == null)
        this._O3NavigationControlsTableInner_Down = (this.ControlHeadO3.O3NavigationControlsExpander.EmbeddedRecset as O3NavigationControlsTableInnerRecset)[1] as O3NavigationControlsTableInner;
      return this._O3NavigationControlsTableInner_Down;
    }
  }

  public Motorola.MackinawCPS.CoreFeatures.ConventionalAliasLists.ConventionalAliasLists ConventionalAliasLists
  {
    get
    {
      if (this._conventionalAliasLists == null)
        this._conventionalAliasLists = FeatureManager.GetFeature(2007)[0] as Motorola.MackinawCPS.CoreFeatures.ConventionalAliasLists.ConventionalAliasLists;
      return this._conventionalAliasLists;
    }
  }

  public MessageAliasTableInner MessageAliasTableInner
  {
    get
    {
      if (this._messageAliasTableInner == null)
        this._messageAliasTableInner = (this.ConventionalAliasLists.MessageAliasList.EmbeddedRecset as MessageAliasTableInnerRecset)[0] as MessageAliasTableInner;
      return this._messageAliasTableInner;
    }
  }

  public StatusAliasTableInner StatusAliasTableInner
  {
    get
    {
      if (this._statusAliasTableInner == null)
        this._statusAliasTableInner = (this.ConventionalAliasLists.StatusAliasList.EmbeddedRecset as StatusAliasTableInnerRecset)[0] as StatusAliasTableInner;
      return this._statusAliasTableInner;
    }
  }

  public Motorola.MackinawCPS.CoreFeatures.ConventionalEmergencyProfiles.ConventionalEmergencyProfiles ConventionalEmergencyProfiles
  {
    get
    {
      if (this._conventionalEmergencyProfiles == null)
        this._conventionalEmergencyProfiles = FeatureManager.GetFeature(2075)[0] as Motorola.MackinawCPS.CoreFeatures.ConventionalEmergencyProfiles.ConventionalEmergencyProfiles;
      return this._conventionalEmergencyProfiles;
    }
  }

  public EmergencyToneTableInner EmergencyToneTableInner
  {
    get
    {
      if (this._emergencyToneTableInner == null)
        this._emergencyToneTableInner = (this.ConventionalEmergencyProfiles.EmergencyToneList.EmbeddedRecset as EmergencyToneTableInnerRecset)[0] as EmergencyToneTableInner;
      return this._emergencyToneTableInner;
    }
  }

  public ASKProgrammingHistoryInner ASKProgrammingHistoryInner
  {
    get
    {
      if (this._ASKProgrammingHistoryInner == null)
        this._ASKProgrammingHistoryInner = (this.RadioInformation.AdvancedSystemKeyInfo.EmbeddedRecset as ASKProgrammingHistoryInnerRecset)[0] as ASKProgrammingHistoryInner;
      return this._ASKProgrammingHistoryInner;
    }
  }

  public Motorola.MackinawCPS.CoreFeatures.MPLConfiguration.MPLConfiguration MPLConfiguration
  {
    get
    {
      if (this._mplConfiguration == null)
        this._mplConfiguration = FeatureManager.GetFeature(2078)[0] as Motorola.MackinawCPS.CoreFeatures.MPLConfiguration.MPLConfiguration;
      return this._mplConfiguration;
    }
  }

  public MPLListInner MPLListInner
  {
    get
    {
      if (this._mplListInner == null)
        this._mplListInner = (this.MPLConfiguration.MPLList.EmbeddedRecset as MPLListInnerRecset)[0] as MPLListInner;
      return this._mplListInner;
    }
  }

  public Motorola.MackinawCPS.CoreFeatures.PhoneWide.PhoneWide PhoneWide
  {
    get
    {
      if (this._phoneWide == null)
        this._phoneWide = FeatureManager.GetFeature(2000)[0] as Motorola.MackinawCPS.CoreFeatures.PhoneWide.PhoneWide;
      return this._phoneWide;
    }
  }

  public DTMFTimingInner DTMFTimingInner
  {
    get
    {
      if (this._dtmfTimingInner == null)
        this._dtmfTimingInner = (this.PhoneWide.DTMFTiming.EmbeddedRecset as DTMFTimingInnerRecset)[0] as DTMFTimingInner;
      return this._dtmfTimingInner;
    }
  }

  public DTMFCodesInner DTMFCodesInner
  {
    get
    {
      if (this._dtmfCodesInner == null)
        this._dtmfCodesInner = (this.PhoneWide.DTMFCodes.EmbeddedRecset as DTMFCodesInnerRecset)[0] as DTMFCodesInner;
      return this._dtmfCodesInner;
    }
  }

  public Motorola.MackinawCPS.CoreFeatures.RadioErgonomicsWide.RadioErgonomicsWide RadioErgonomicsWide
  {
    get
    {
      if (this._radioErgonomicsWide == null)
        this._radioErgonomicsWide = FeatureManager.GetFeature(2033)[0] as Motorola.MackinawCPS.CoreFeatures.RadioErgonomicsWide.RadioErgonomicsWide;
      return this._radioErgonomicsWide;
    }
  }

  public ControlHeadAliasListInner ControlHeadAliasListInner
  {
    get
    {
      if (this._controlHeadAliasListInner == null)
        this._controlHeadAliasListInner = (this.RadioErgonomicsWide.ControlHead.EmbeddedRecset as ControlHeadAliasListInnerRecset)[0] as ControlHeadAliasListInner;
      return this._controlHeadAliasListInner;
    }
  }

  public AuxControlTableInner AuxControlTableInner
  {
    get
    {
      if (this._auxControlTableInner == null)
        this._auxControlTableInner = (this.RadioErgonomicsWide.AuxControl.EmbeddedRecset as AuxControlTableInnerRecset)[0] as AuxControlTableInner;
      return this._auxControlTableInner;
    }
  }

  public PresetZoneAndChannelTableInner PresetZoneAndChannelTableInner
  {
    get
    {
      if (this._presetZoneAndChannelTableInner == null)
        this._presetZoneAndChannelTableInner = (this.RadioErgonomicsWide.PresetZoneAndChannel.EmbeddedRecset as PresetZoneAndChannelTableInnerRecset)[0] as PresetZoneAndChannelTableInner;
      return this._presetZoneAndChannelTableInner;
    }
  }

  public Motorola.MackinawCPS.CoreFeatures.RadioProfiles.RadioProfiles RadioProfiles
  {
    get
    {
      if (this._radioProfiles == null)
        this._radioProfiles = FeatureManager.GetFeature(2077)[0] as Motorola.MackinawCPS.CoreFeatures.RadioProfiles.RadioProfiles;
      return this._radioProfiles;
    }
  }

  public Motorola.MackinawCPS.CoreFeatures.RadioVIPs.RadioVIPs RadioVIPs
  {
    get
    {
      if (this._radioVIPs == null)
        this._radioVIPs = FeatureManager.GetFeature(2125)[0] as Motorola.MackinawCPS.CoreFeatures.RadioVIPs.RadioVIPs;
      return this._radioVIPs;
    }
  }

  public RadioVIPInner RadioVIPInner
  {
    get
    {
      if (this._radioVIPInner == null)
        this._radioVIPInner = (this.RadioVIPs.General.EmbeddedRecset as RadioVIPInnerRecset)[0] as RadioVIPInner;
      return this._radioVIPInner;
    }
  }

  public MDCRepeaterIDTableInner MDCRepeaterIDTableInner
  {
    get
    {
      if (this._mdcRepeaterIDTableInner == null)
        this._mdcRepeaterIDTableInner = (this.RepeaterIDList.MDCRepeaterIDList.EmbeddedRecset as MDCRepeaterIDTableInnerRecset)[0] as MDCRepeaterIDTableInner;
      return this._mdcRepeaterIDTableInner;
    }
  }

  public SingletoneFrequencyTableInner SingletoneFrequencyTableInner
  {
    get
    {
      if (this._singletoneFrequencyTableInner == null)
        this._singletoneFrequencyTableInner = (this.RepeaterIDList.SingletoneFrequencyList.EmbeddedRecset as SingletoneFrequencyTableInnerRecset)[0] as SingletoneFrequencyTableInner;
      return this._singletoneFrequencyTableInner;
    }
  }

  public Motorola.MackinawCPS.CoreFeatures.RepeaterIDList.RepeaterIDList RepeaterIDList
  {
    get
    {
      if (this._repeaterIDList == null)
        this._repeaterIDList = FeatureManager.GetFeature(2034)[0] as Motorola.MackinawCPS.CoreFeatures.RepeaterIDList.RepeaterIDList;
      return this._repeaterIDList;
    }
  }

  public Motorola.MackinawCPS.CoreFeatures.ScanWide.ScanWide ScanWide
  {
    get
    {
      if (this._scanWide == null)
        this._scanWide = FeatureManager.GetFeature(2023)[0] as Motorola.MackinawCPS.CoreFeatures.ScanWide.ScanWide;
      return this._scanWide;
    }
  }

  public Motorola.MackinawCPS.CoreFeatures.SecureKMFProfile.SecureKMFProfile SecureKMFProfile
  {
    get
    {
      if (this._secureKMFProfile == null)
        this._secureKMFProfile = FeatureManager.GetFeature(2055)[0] as Motorola.MackinawCPS.CoreFeatures.SecureKMFProfile.SecureKMFProfile;
      return this._secureKMFProfile;
    }
  }

  public SecureHardwareEncryptionKeyReferencesListInner SecureHardwareEncryptionKeyReferencesListInner
  {
    get
    {
      if (this._secureHardwareEncryptionKeyReferencesListInner == null)
        this._secureHardwareEncryptionKeyReferencesListInner = (this.SecureKMFProfile.SecureHardwareEncryptionKeyReferencesList.EmbeddedRecset as SecureHardwareEncryptionKeyReferencesListInnerRecset)[0] as SecureHardwareEncryptionKeyReferencesListInner;
      return this._secureHardwareEncryptionKeyReferencesListInner;
    }
  }

  public SecureHardwareEncryptionIndependentKeyListInner SecureHardwareEncryptionIndependentKeyListInner
  {
    get
    {
      if (this._secureHardwareEncryptionIndependentKeyListInner == null)
      {
        if (this.SecureKMFProfile.SecureHardwareEncryptionIndependentKeyList.EmbeddedRecset.Count == 0)
          this.SecureKMFProfile.SecureHardwareEncryptionIndependentKeyList.EmbeddedRecset.AddDefaultRecord();
        this._secureHardwareEncryptionIndependentKeyListInner = (this.SecureKMFProfile.SecureHardwareEncryptionIndependentKeyList.EmbeddedRecset as SecureHardwareEncryptionIndependentKeyListInnerRecset)[0] as SecureHardwareEncryptionIndependentKeyListInner;
      }
      return this._secureHardwareEncryptionIndependentKeyListInner;
    }
  }

  public EncryptionKeyListInner EncryptionKeyListInner
  {
    get
    {
      if (this._encryptionKeyListInner == null)
        this._encryptionKeyListInner = (this.SecureWide.EncryptionKeyList.EmbeddedRecset as EncryptionKeyListInnerRecset)[0] as EncryptionKeyListInner;
      return this._encryptionKeyListInner;
    }
  }

  public Motorola.MackinawCPS.CoreFeatures.Shepherds.Shepherds Shepherds
  {
    get
    {
      if (this._shepherds == null)
        this._shepherds = FeatureManager.GetFeature(2013)[0] as Motorola.MackinawCPS.CoreFeatures.Shepherds.Shepherds;
      return this._shepherds;
    }
  }

  public ConventionalProductIndependentButtonListInner ConventionalProductIndependentButtonListInner
  {
    get
    {
      if (this._conventionalProductIndependentButtonListInner == null)
        this._conventionalProductIndependentButtonListInner = (this.Shepherds.ConventionalProductIndependentButton.EmbeddedRecset as ConventionalProductIndependentButtonListInnerRecset)[0] as ConventionalProductIndependentButtonListInner;
      return this._conventionalProductIndependentButtonListInner;
    }
  }

  public TrunkingProductIndependentButtonListInner TrunkingProductIndependentButtonListInner
  {
    get
    {
      if (this._trunkingProductIndependentButtonListInner == null)
        this._trunkingProductIndependentButtonListInner = (this.Shepherds.TrunkingProductIndependentButton.EmbeddedRecset as TrunkingProductIndependentButtonListInnerRecset)[0] as TrunkingProductIndependentButtonListInner;
      return this._trunkingProductIndependentButtonListInner;
    }
  }

  public GlobalShepherdListInner GlobalShepherdListInner
  {
    get
    {
      if (this._globalShepherdListInner == null)
        this._globalShepherdListInner = (this.Shepherds.GlobalShepherd.EmbeddedRecset as GlobalShepherdListInnerRecset)[0] as GlobalShepherdListInner;
      return this._globalShepherdListInner;
    }
  }

  public ConventionalShepherdListInner ConventionalShepherdListInner
  {
    get
    {
      if (this._conventionalShepherdListInner == null)
        this._conventionalShepherdListInner = (this.Shepherds.ConventionalShepherd.EmbeddedRecset as ConventionalShepherdListInnerRecset)[0] as ConventionalShepherdListInner;
      return this._conventionalShepherdListInner;
    }
  }

  public TrunkingShepherdListInner TrunkingShepherdListInner
  {
    get
    {
      if (this._trunkingShepherdListInner == null)
        this._trunkingShepherdListInner = (this.Shepherds.TrunkingShepherd.EmbeddedRecset as TrunkingShepherdListInnerRecset)[0] as TrunkingShepherdListInner;
      return this._trunkingShepherdListInner;
    }
  }

  public SignalIndependentProductIndependentNonProgrammableButtonListInner SignalIndependentProductIndependentNonProgrammableButtonListInner
  {
    get
    {
      if (this._signalIndependentProductIndependentNonProgrammableButtonListInner == null)
        this._signalIndependentProductIndependentNonProgrammableButtonListInner = (this.Shepherds.SignalIndependentProductIndependentNonProgrammableButton.EmbeddedRecset as SignalIndependentProductIndependentNonProgrammableButtonListInnerRecset)[0] as SignalIndependentProductIndependentNonProgrammableButtonListInner;
      return this._signalIndependentProductIndependentNonProgrammableButtonListInner;
    }
  }

  public SignalIndependentProductIndependentProgrammableButtonListInner SignalIndependentProductIndependentProgrammableButtonListInner
  {
    get
    {
      if (this._signalIndependentProductIndependentProgrammableButtonListInner == null)
        this._signalIndependentProductIndependentProgrammableButtonListInner = (this.Shepherds.SignalIndependentProductIndependentProgrammableButton.EmbeddedRecset as SignalIndependentProductIndependentProgrammableButtonListInnerRecset)[0] as SignalIndependentProductIndependentProgrammableButtonListInner;
      return this._signalIndependentProductIndependentProgrammableButtonListInner;
    }
  }

  public SpecialFeatures.VoiceAnnouncements.SiteSelectableAlertList.SiteSelectableAlertList SiteSelectableAlertList
  {
    get
    {
      if (this._siteSelectableAlertList == null)
        this._siteSelectableAlertList = FeatureManager.GetFeature(4145)[0] as SpecialFeatures.VoiceAnnouncements.SiteSelectableAlertList.SiteSelectableAlertList;
      return this._siteSelectableAlertList;
    }
  }

  public SiteSelectableAlertTableInner SiteSelectableAlertTableInner
  {
    get
    {
      if (this._siteSelectableAlertTableInner == null)
        this._siteSelectableAlertTableInner = (this.SiteSelectableAlertList.SiteSelectableAlertList41985.EmbeddedRecset as SiteSelectableAlertTableInnerRecset)[0] as SiteSelectableAlertTableInner;
      return this._siteSelectableAlertTableInner;
    }
  }

  public AlertListInner AlertListInner
  {
    get
    {
      if (this._vpAlertListInnerSection == null)
        this._vpAlertListInnerSection = (this.VirtualPartnerAlert.General.EmbeddedRecset as AlertListInnerRecset)[0] as AlertListInner;
      return this._vpAlertListInnerSection;
    }
  }

  public Motorola.MackinawCPS.CoreFeatures.SmartKeyFob.SmartKeyFob SmartKeyFob
  {
    get
    {
      if (this._smartKeyFob == null)
        this._smartKeyFob = FeatureManager.GetFeature(4130)[0] as Motorola.MackinawCPS.CoreFeatures.SmartKeyFob.SmartKeyFob;
      return this._smartKeyFob;
    }
  }

  public SmartKeyFobButtonTableInner SmartKeyFobButtonTableInner
  {
    get
    {
      if (this._smartKeyFobButtonTableInner == null)
        this._smartKeyFobButtonTableInner = (this.SmartKeyFob.General.EmbeddedRecset as SmartKeyFobButtonTableInnerRecset)[0] as SmartKeyFobButtonTableInner;
      return this._smartKeyFobButtonTableInner;
    }
  }

  public Motorola.MackinawCPS.CoreFeatures.Switches.Switches Switches
  {
    get
    {
      if (this._switches == null)
        this._switches = FeatureManager.GetFeature(2038)[0] as Motorola.MackinawCPS.CoreFeatures.Switches.Switches;
      return this._switches;
    }
  }

  public RotaryControlInner RotaryControlInner
  {
    get
    {
      if (this._rotaryControlInner == null)
        this._rotaryControlInner = (this.Switches.General.EmbeddedRecset as RotaryControlInnerRecset)[0] as RotaryControlInner;
      return this._rotaryControlInner;
    }
  }

  public ConventionalSwitchTableInner ConventionalSwitchTableInner
  {
    get
    {
      if (this._conventionalSwitchTableInner == null)
        this._conventionalSwitchTableInner = (this.Switches.ConventionalSwitchTable.EmbeddedRecset as ConventionalSwitchTableInnerRecset)[0] as ConventionalSwitchTableInner;
      return this._conventionalSwitchTableInner;
    }
  }

  public TrunkingSwitchTableInner TrunkingSwitchTableInner
  {
    get
    {
      if (this._trunkingSwitchTableInner == null)
        this._trunkingSwitchTableInner = (this.Switches.TrunkingSwitchTable.EmbeddedRecset as TrunkingSwitchTableInnerRecset)[0] as TrunkingSwitchTableInner;
      return this._trunkingSwitchTableInner;
    }
  }

  public MFKAssignmentControlInner MFKAssignmentControlInner
  {
    get
    {
      if (this._MFKAssignmentControlInner == null)
        this._MFKAssignmentControlInner = (this.Switches.MultiFunctionKnob.EmbeddedRecset as MFKAssignmentControlInnerRecset)[0] as MFKAssignmentControlInner;
      return this._MFKAssignmentControlInner;
    }
  }

  public MFKAssignmentControlInner MFKAssignmentControlInner_1
  {
    get
    {
      if (this._MFKAssignmentControlInner_1 == null)
      {
        if (this.Switches.MultiFunctionKnob.EmbeddedRecset.Count == 1 && UtilityMack.IsPortable())
          this.Switches.MultiFunctionKnob.EmbeddedRecset.AddDefaultRecord();
        this._MFKAssignmentControlInner_1 = (this.Switches.MultiFunctionKnob.EmbeddedRecset as MFKAssignmentControlInnerRecset)[1] as MFKAssignmentControlInner;
      }
      return this._MFKAssignmentControlInner_1;
    }
  }

  public Motorola.MackinawCPS.CoreFeatures.TrunkingEmergencyProfiles.TrunkingEmergencyProfiles TrunkingEmergencyProfiles
  {
    get
    {
      if (this._trunkingEmergencyProfiles == null)
        this._trunkingEmergencyProfiles = FeatureManager.GetFeature(2076)[0] as Motorola.MackinawCPS.CoreFeatures.TrunkingEmergencyProfiles.TrunkingEmergencyProfiles;
      return this._trunkingEmergencyProfiles;
    }
  }

  public TrunkingEmergencyToneTableInner TrunkingEmergencyToneTableInner
  {
    get
    {
      if (this._trunkingEmergencyToneTableInner == null)
        this._trunkingEmergencyToneTableInner = (this.TrunkingEmergencyProfiles.TrunkingEmergencyToneList.EmbeddedRecset as TrunkingEmergencyToneTableInnerRecset)[0] as TrunkingEmergencyToneTableInner;
      return this._trunkingEmergencyToneTableInner;
    }
  }

  public Motorola.MackinawCPS.CoreFeatures.TrunkingPersonality.TrunkingPersonality TrunkingPersonality
  {
    get
    {
      if (this._trunkingPersonality == null)
        this._trunkingPersonality = FeatureManager.GetFeature(2072)[0] as Motorola.MackinawCPS.CoreFeatures.TrunkingPersonality.TrunkingPersonality;
      return this._trunkingPersonality;
    }
  }

  public TalkgroupInner TalkgroupInner
  {
    get
    {
      if (this._talkgroupInner == null)
        this._talkgroupInner = (this.TrunkingPersonality.Talkgroup.EmbeddedRecset as TalkgroupInnerRecset)[0] as TalkgroupInner;
      return this._talkgroupInner;
    }
  }

  public PreferredSitesInner PreferredSitesInner
  {
    get
    {
      if (this._preferredSitesInner == null)
        this._preferredSitesInner = (this.TrunkingPersonality.PreferredSites.EmbeddedRecset as PreferredSitesInnerRecset)[0] as PreferredSitesInner;
      return this._preferredSitesInner;
    }
  }

  public Motorola.MackinawCPS.CoreFeatures.TrunkingSystem.TrunkingSystem TrunkingSystem
  {
    get
    {
      if (this._trunkingSystem == null)
        this._trunkingSystem = FeatureManager.GetFeature(2064)[0] as Motorola.MackinawCPS.CoreFeatures.TrunkingSystem.TrunkingSystem;
      return this._trunkingSystem;
    }
  }

  public ChannelRangesMHzInner ChannelRangesMHzInner
  {
    get
    {
      if (this._channelRangesMHzInner == null)
        this._channelRangesMHzInner = (this.TrunkingSystem.OBTChannelAssignment.EmbeddedRecset as ChannelRangesMHzInnerRecset)[0] as ChannelRangesMHzInner;
      return this._channelRangesMHzInner;
    }
  }

  public ControlChannelsInner ControlChannelsInner
  {
    get
    {
      if (this._controlChannelsInner == null)
        this._controlChannelsInner = (this.TrunkingSystem.ControlChannels.EmbeddedRecset as ControlChannelsInnerRecset)[0] as ControlChannelsInner;
      return this._controlChannelsInner;
    }
  }

  public ASTRO25ChannelIDInner ASTRO25ChannelIDInner
  {
    get
    {
      if (this._ASTRO25ChannelIDInner == null)
        this._ASTRO25ChannelIDInner = (this.TrunkingSystem.ASTRO25ChannelID.EmbeddedRecset as ASTRO25ChannelIDInnerRecset)[0] as ASTRO25ChannelIDInner;
      return this._ASTRO25ChannelIDInner;
    }
  }

  public StatusAliasInner StatusAliasInner
  {
    get
    {
      if (this._statusAliasInner == null)
        this._statusAliasInner = (this.TrunkingSystem.StatusAlias.EmbeddedRecset as StatusAliasInnerRecset)[0] as StatusAliasInner;
      return this._statusAliasInner;
    }
  }

  public SiteAliasInner SiteAliasInner
  {
    get
    {
      if (this._siteAliasInner == null)
        this._siteAliasInner = (this.TrunkingSystem.SiteAlias.EmbeddedRecset as SiteAliasInnerRecset)[0] as SiteAliasInner;
      return this._siteAliasInner;
    }
  }

  public DataModemTableInner DataModemTableInner
  {
    get
    {
      if (this._dataModemTableInner == null)
        this._dataModemTableInner = (this.DataWide.ExternalDataModem.EmbeddedRecset as DataModemTableInnerRecset)[0] as DataModemTableInner;
      return this._dataModemTableInner;
    }
  }

  public Motorola.MackinawCPS.CoreFeatures.TrunkingSystem.OneTouchInner TrkOneTouchInner
  {
    get
    {
      if (this._trkOneTouchInner == null)
        this._trkOneTouchInner = (this.TrunkingSystem.OneTouch.EmbeddedRecset as Motorola.MackinawCPS.CoreFeatures.TrunkingSystem.OneTouchInnerRecset)[0] as Motorola.MackinawCPS.CoreFeatures.TrunkingSystem.OneTouchInner;
      return this._trkOneTouchInner;
    }
  }

  public Motorola.MackinawCPS.CoreFeatures.TrunkingWide.TrunkingWide TrunkingWide
  {
    get
    {
      if (this._trunkingWide == null)
        this._trunkingWide = FeatureManager.GetFeature(2027)[0] as Motorola.MackinawCPS.CoreFeatures.TrunkingWide.TrunkingWide;
      return this._trunkingWide;
    }
  }

  public UclTrunkingT2CallHotList UclTrunkingT2CallHotList
  {
    get
    {
      if (this._UclTrunkingT2CallHotList == null)
        this._UclTrunkingT2CallHotList = FeatureManager.GetFeature(2214)[0] as UclTrunkingT2CallHotList;
      return this._UclTrunkingT2CallHotList;
    }
  }

  public VoiceAnnouncementList VoiceAnnouncementList
  {
    get
    {
      if (this._VoiceAnnouncementList == null)
        this._VoiceAnnouncementList = FeatureManager.GetFeature(2300)[0] as VoiceAnnouncementList;
      return this._VoiceAnnouncementList;
    }
  }

  public MessageAliasInner MessageAliasInner
  {
    get
    {
      if (this._messageAliasInner == null)
        this._messageAliasInner = (this.TrunkingSystem.MessageAlias.EmbeddedRecset as MessageAliasInnerRecset)[0] as MessageAliasInner;
      return this._messageAliasInner;
    }
  }

  public Motorola.MackinawCPS.CoreFeatures.PersonnelAccountability.PersonnelAccountability PersonnelAccountability
  {
    get
    {
      if (this._personnelAccountability == null)
        this._personnelAccountability = FeatureManager.GetFeature(4176)[0] as Motorola.MackinawCPS.CoreFeatures.PersonnelAccountability.PersonnelAccountability;
      return this._personnelAccountability;
    }
  }

  public PerAccListTableInner PerAccListTableInner
  {
    get
    {
      if (this._perAccListTableInner == null)
      {
        if (this.PersonnelAccountability.General.EmbeddedRecset.Count == 0)
          this.PersonnelAccountability.General.EmbeddedRecset.AddDefaultRecord();
        this._perAccListTableInner = (this.PersonnelAccountability.General.EmbeddedRecset as PerAccListTableInnerRecset)[0] as PerAccListTableInner;
      }
      return this._perAccListTableInner;
    }
  }

  public Motorola.MackinawCPS.CoreFeatures.MissionCriticalGeofence.MissionCriticalGeofence MissionCriticalGeofence
  {
    get
    {
      if (this._missionCriticalGeofence == null)
        this._missionCriticalGeofence = FeatureManager.GetFeature(4174)[0] as Motorola.MackinawCPS.CoreFeatures.MissionCriticalGeofence.MissionCriticalGeofence;
      return this._missionCriticalGeofence;
    }
  }

  public Motorola.MackinawCPS.CoreFeatures.VirtualPartnerAlert.VirtualPartnerAlert VirtualPartnerAlert
  {
    get
    {
      if (this._virtualPartnerAlert == null)
        this._virtualPartnerAlert = FeatureManager.GetFeature(4231)[0] as Motorola.MackinawCPS.CoreFeatures.VirtualPartnerAlert.VirtualPartnerAlert;
      return this._virtualPartnerAlert;
    }
  }

  public SystemCertificateList SystemCertificateList
  {
    get
    {
      if (this._systemCertificateList == null)
        this._systemCertificateList = FeatureManager.GetFeature(4228)[0] as SystemCertificateList;
      return this._systemCertificateList;
    }
  }

  public DVRSFileList DVRSFileList
  {
    get
    {
      if (this._dvrsFileList == null)
        this._dvrsFileList = FeatureManager.GetFeature(4234)[0] as DVRSFileList;
      return this._dvrsFileList;
    }
  }

  public BookmarkQuickAccessListInner BookmarkQuickAccessListInner
  {
    get
    {
      if (this._bookmarkQuickAccessListInner == null)
      {
        if (this.DataWide.BookmarkQuickAccess.EmbeddedRecset.Count == 0)
          this.DataWide.BookmarkQuickAccess.EmbeddedRecset.AddDefaultRecord();
        this._bookmarkQuickAccessListInner = (this.DataWide.BookmarkQuickAccess.EmbeddedRecset as BookmarkQuickAccessListInnerRecset)[0] as BookmarkQuickAccessListInner;
      }
      return this._bookmarkQuickAccessListInner;
    }
  }

  private FieldAccessor()
  {
    this.CpsDocument = new MackCPSDocument();
    FieldAccessor.IsCpsApiTest = new StackTrace().GetFrame(2).GetMethod().ReflectedType.FullName.Contains("CPS.API");
  }

  public static FieldAccessor Instance
  {
    get
    {
      if (FieldAccessor._fieldAccessor == null)
        FieldAccessor._fieldAccessor = new FieldAccessor();
      return FieldAccessor._fieldAccessor;
    }
  }

  public bool Load(string codeplugPath)
  {
    this.IsLoaded = this.CpsDocument.FileOpenSafely(codeplugPath, (IEnumerable<BinarySerializerTypeInfo>) AllowedTypes.AllowedTypesList);
    return this.IsLoaded;
  }

  public bool LoadAndMapFields(string codeplugPath)
  {
    try
    {
      this.IsLoaded = this.CpsDocument.FileOpenSafely(codeplugPath, (IEnumerable<BinarySerializerTypeInfo>) AllowedTypes.AllowedTypesList);
      if (!this.IsLoaded)
        throw new Exception($"Cannot load:\"{codeplugPath}\" file. Probably codeplug structure differs");
    }
    catch (Exception ex)
    {
      throw new Exception($"Error during load:\"{codeplugPath}\" file.", ex);
    }
    this.Init();
    return this.IsLoaded;
  }

  private void Fixup()
  {
    using (ModelTiering modelTiering = new ModelTiering("H97TGD9PW1AN", ModelTiering.ActionTypes.NONE, ModelTiering.TargetTypes.NONE))
      modelTiering.LoadAliasList();
    if (this.RadioInformation.General.RadInfoGeneralModelNumber_A8539.Value.Contains("H"))
      UtilityMack.ReinitializeAndSetFlagsBasedOnModel("PORTABLE", this.RadioInformation.General.RadInfoGeneralModelNumber_A8539.Value);
    else
      UtilityMack.ReinitializeAndSetFlagsBasedOnModel("MOBILE", this.RadioInformation.General.RadInfoGeneralModelNumber_A8539.Value);
  }

  public void Init()
  {
    this.CpsDocument.Init();
    this.Fixup();
    this.RegisterFields();
    UndoManager.StartUndoRedo();
  }

  private void RegisterFields()
  {
    this.Field.Clear();
    this.AddRemoteSpeakerMic();
    this.AddActionConsolidation();
    this.AddASTRO25TrunkingHotList();
    this.AddASTROConventionalHotList();
    this.AddTypeIITrunkingHotList();
    this.AddASTROTalkgroupList();
    this.AddButtons();
    this.AddControlHeadO2();
    this.AddControlHeadO3();
    this.AddControlHeadO5();
    this.AddControlHeadO7();
    this.AddControlHeadO9();
    this.AddControlHeadE5();
    this.AddConventionalAliasLists();
    this.AddConventionalEmergencyProfiles();
    this.AddConventionalPersonality();
    this.AddConventionalSystem();
    this.AddMissionCriticalGeofence();
    this.AddConventionalWide();
    this.AddDataWide();
    this.AddVoiceAnnouncementWide();
    this.AddDEK();
    this.AddDisplay();
    this.AddDVRSProfiles();
    this.AddDVRSWide();
    this.AddEmergencyWide();
    this.AddEnhancedDataPortList();
    this.AddExternalMicNoiseReductionProfile();
    this.AddFactoryOverrides();
    this.AddGlobalNoiseReductionList();
    this.AddInternalMicNoiseReductionProfile();
    this.AddKeypad();
    this.AddKeypadMicAndAccessories();
    this.AddMDCConventionalHotList();
    this.AddMenuItems();
    this.AddRadioWide();
    this.AddDataProfile();
    this.AddRadioInfomation();
    this.AddZoneChannelAssigement();
    this.AddScanList();
    this.AddMPLConfiguration();
    this.AddPhoneWide();
    this.AddRadioErgonomicsWide();
    this.AddRadioProfiles();
    this.AddRadioVIPs();
    this.AddRepeaterIDList();
    this.AddScanWide();
    this.AddSecureKMFProfile();
    this.AddSecureWide();
    this.AddShepherds();
    this.AddSiteSelectableAlertList();
    this.AddSmartKeyFobButtons();
    this.AddSwitches();
    this.AddTrunkingEmergencyProfiles();
    this.AddTrunkingPersonality();
    this.AddTrunkingSystem();
    this.AddTrunkingWide();
    this.AddDigitalToneSignaling();
    this.AddPersonnelAccountability();
    this.AddVirtualPartnerAlert();
    this.AddVirtualPartnerAlertListInnerSection();
  }

  public void Unload()
  {
    if (!this.IsLoaded)
      return;
    this.CpsDocument.FileClose();
    UndoManager.Reset();
    this.Field.Clear();
    FieldAccessor._fieldAccessor = (FieldAccessor) null;
    this.IsLoaded = false;
  }

  public void InitNew()
  {
    this.CpsDocument.FileClose();
    FeatureManager.BeginAddFeatures();
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
    FeatureManager.AddFeature((IAcpRecordset) new ControlHeadE5Recset());
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
    FeatureManager.AddFeature((IAcpRecordset) new TTSVoiceAnnouncementListRecSet());
    FeatureManager.AddFeature((IAcpRecordset) new VirtualPartnerAlertRecset());
    FeatureManager.AddFeature((IAcpRecordset) new SystemCertificateListRecSet());
    FeatureManager.AddFeature((IAcpRecordset) new DVRSFileListRecSet());
    FeatureManager.AddFeature((IAcpRecordset) new URLTableRecset());
    FeatureManager.EndAddFeatures();
    this.CpsDocument.FileNew();
    UndoManager.StopUndoRedo();
    UndoManager.Reset();
    this.IsLoaded = true;
    this.UclTemplateNodeInit();
  }

  private void UclTemplateNodeInit()
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
    FeatureNode templateNode = ((Recordset) feature).TemplateNode;
    foreach (IAcpFeatureSection featureSections in templateNode.FeatureSectionsCollection)
    {
      if (featureSections.HasEmbeddedRecset)
      {
        Recordset embeddedRecset = (Recordset) featureSections.EmbeddedRecset;
        if (embeddedRecset.Count == 0)
        {
          embeddedRecset.AddRecord(embeddedRecset.CreateDefaultRecord());
          foreach (IAcpFeatureNode acpFeatureNode in (Collection<FeatureNode>) embeddedRecset)
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

  public System.Collections.Generic.List<string> ListAllAcpFieldsNames()
  {
    System.Collections.Generic.List<string> stringList = new System.Collections.Generic.List<string>();
    foreach (IAcpRecordset feature in this.CpsDocument.Features)
    {
      foreach (IAcpField acpField in feature.SearchAll(""))
      {
        if (!stringList.Contains(acpField.Name))
          stringList.Add(acpField.Name);
      }
    }
    return stringList;
  }

  public Dictionary<string, AcpField<string>> ListAllAcpStringFields()
  {
    Dictionary<string, AcpField<string>> dictionary = new Dictionary<string, AcpField<string>>();
    foreach (IAcpRecordset feature in this.CpsDocument.Features)
    {
      foreach (IAcpField acpField in feature.SearchAll(""))
      {
        if (!dictionary.ContainsKey(acpField.Name) && acpField.DataType == typeof (string))
          dictionary.Add(acpField.Name, (AcpField<string>) acpField);
      }
    }
    return dictionary;
  }

  public Dictionary<string, AcpField<bool>> ListAllAcpBooleanFields()
  {
    Dictionary<string, AcpField<bool>> dictionary = new Dictionary<string, AcpField<bool>>();
    foreach (IAcpRecordset feature in this.CpsDocument.Features)
    {
      foreach (IAcpField acpField in feature.SearchAll(""))
      {
        if (!dictionary.ContainsKey(acpField.Name) && acpField.DataType == typeof (bool))
          dictionary.Add(acpField.Name, (AcpField<bool>) acpField);
      }
    }
    return dictionary;
  }

  public Dictionary<string, AcpField<int>> ListAllAcpIntegerFields()
  {
    Dictionary<string, AcpField<int>> dictionary = new Dictionary<string, AcpField<int>>();
    foreach (IAcpRecordset feature in this.CpsDocument.Features)
    {
      foreach (IAcpField acpField in feature.SearchAll(""))
      {
        if (!dictionary.ContainsKey(acpField.Name) && acpField.DataType == typeof (int))
          dictionary.Add(acpField.Name, (AcpField<int>) acpField);
      }
    }
    return dictionary;
  }

  private void AddDigitalToneSignaling()
  {
    this.Field.Add("RadErgoAstroAlertingToneTableToneAliasText_42533", (IAcpField) this.AstroAlertingToneTableInner.AstroAlertingToneTableInnerSection.RadErgoAstroAlertingToneTableToneAliasText_42533);
    this.Field.Add("RadErgoAstroAlertingToneTableTone1Freq", (IAcpField) this.AstroAlertingToneTableInner.AstroAlertingToneTableInnerSection.RadErgoAstroAlertingToneTableTone1Freq);
    this.Field.Add("RadErgoAstroAlertingToneTableTone2Freq", (IAcpField) this.AstroAlertingToneTableInner.AstroAlertingToneTableInnerSection.RadErgoAstroAlertingToneTableTone2Freq);
    this.Field.Add("RadErgoAstroAlertingToneTableUnmuteEnable", (IAcpField) this.AstroAlertingToneTableInner.AstroAlertingToneTableInnerSection.RadErgoAstroAlertingToneTableUnmuteEnable);
    this.Field.Add("RadErgoAstroAlertingToneTableAlertTone", (IAcpField) this.AstroAlertingToneTableInner.AstroAlertingToneTableInnerSection.RadErgoAstroAlertingToneTableAlertTone);
    this.Field.Add("RadErgoAstroAlertingToneTableExternalControl", (IAcpField) this.AstroAlertingToneTableInner.AstroAlertingToneTableInnerSection.RadErgoAstroAlertingToneTableExternalControl);
  }

  private void AddRemoteSpeakerMic()
  {
    this.Field.Add("RadErgoCfgRSMButtonName_A22527", (IAcpField) this.RSMButtonInner.RSMButtonInnerSection.RadErgoCfgRSMButtonName_A22527);
    this.Field.Add("RadErgoCfgRSMConventionalBCO_A19639", (IAcpField) this.RSMButtonInner.RSMButtonInnerSection.RadErgoCfgRSMConventionalBCO_A19639);
    this.Field.Add("RadErgoCfgRSMlConventionalFeature_A19640", (IAcpField) this.RSMButtonInner.RSMButtonInnerSection.RadErgoCfgRSMlConventionalFeature_A19640);
    this.Field.Add("RadErgoCfgRSMTrunkingBCO_A19741", (IAcpField) this.RSMButtonInner.RSMButtonInnerSection.RadErgoCfgRSMTrunkingBCO_A19741);
    this.Field.Add("RadErgoCfgRSMlTrunkingFeature_A19742", (IAcpField) this.RSMButtonInner.RSMButtonInnerSection.RadErgoCfgRSMlTrunkingFeature_A19742);
    this.Field.Add("RadErgoCfgRSMButtonKey_A22526", (IAcpField) this.RSMButtonInner.RSMButtonInnerSection.RadErgoCfgRSMButtonKey_A22526);
    this.Field.Add("RadErgoCfgRSMlTopButtonLongPressTime", (IAcpField) this.RSMButtonInner.RSMButtonInnerSection.RadErgoCfgRSMlTopButtonLongPressTime);
  }

  private void AddActionConsolidation()
  {
    this.Field.Add("RadioErgoConfigACGeneralActionAllowed_A36579", (IAcpField) this.ActionConsolidation.General.RadioErgoConfigACGeneralActionAllowed_A36579);
    this.Field.Add("RadioErgoConfigACName_A36581", (IAcpField) this.ActionConsolidation.General.RadioErgoConfigACName_A36581);
    this.Field.Add("RadioErgoConfigACRelayPattern_A36582", (IAcpField) this.ActionConsolidation.General.RadioErgoConfigACRelayPattern_A36582);
    this.Field.Add("RadioErgoConfigACRelayPatternErrStrategy_A36583", (IAcpField) this.ActionConsolidation.General.RadioErgoConfigACRelayPatternErrStrategy_A36583);
    this.Field.Add("RadioErgoConfigACSirenType_A36584", (IAcpField) this.ActionConsolidation.General.RadioErgoConfigACSirenType_A36584);
    this.Field.Add("RadioErgoConfigACSirenTypeErrStrategy_A36585", (IAcpField) this.ActionConsolidation.General.RadioErgoConfigACSirenTypeErrStrategy_A36585);
    this.Field.Add("RadioErgoConfigAC3rdPartyNotification_A41510", (IAcpField) this.ActionConsolidation.General.RadioErgoConfigAC3rdPartyNotification_A41510);
    this.Field.Add("RadioErgoConfigAC3rdPartyNotificationErrorStategy_A41516", (IAcpField) this.ActionConsolidation.General.RadioErgoConfigAC3rdPartyNotificationErrorStategy_A41516);
    this.Field.Add("RadioErgoConfigACGpsReport_A36587", (IAcpField) this.ActionConsolidation.General.RadioErgoConfigACGpsReport_A36587);
    this.Field.Add("RadioErgoConfigACGpsReportErrStrategy_A36588", (IAcpField) this.ActionConsolidation.General.RadioErgoConfigACGpsReportErrStrategy_A36588);
    this.Field.Add("RadioErgoConfigACActionType_A42871", (IAcpField) this.ActionConsolidation.General.RadioErgoConfigACActionType_A42871);
    if (this.ConsolidatedActionsInner == null)
      return;
    this.Field.Add("RadioErgoConfigACActionID_A36590", (IAcpField) this.ConsolidatedActionsInner.ConsolidatedActionsInnerSection.RadioErgoConfigACActionID_A36590);
    this.Field.Add("RadioErgoConfigACGeneralIndex_A36591", (IAcpField) this.ConsolidatedActionsInner.ConsolidatedActionsInnerSection.RadioErgoConfigACGeneralIndex_A36591);
    this.Field.Add("RadioErgoConfigACGeneralZone_A36592", (IAcpField) this.ConsolidatedActionsInner.ConsolidatedActionsInnerSection.RadioErgoConfigACGeneralZone_A36592);
    this.Field.Add("RadioErgoConfigACGeneralChannel_A36593", (IAcpField) this.ConsolidatedActionsInner.ConsolidatedActionsInnerSection.RadioErgoConfigACGeneralChannel_A36593);
    this.Field.Add("RadioErgoConfigACGeneralErrStrategy_A36594", (IAcpField) this.ConsolidatedActionsInner.ConsolidatedActionsInnerSection.RadioErgoConfigACGeneralErrStrategy_A36594);
    this.Field.Add("RadioErgoConfigACAlertInterval_A42877", (IAcpField) this.ConsolidatedActionsInner.ConsolidatedActionsInnerSection.RadioErgoConfigACAlertInterval_A42877);
    this.Field.Add("RadioErgoConfigACGeneralTxPowerChange__42916", (IAcpField) this.ConsolidatedActionsInner.ConsolidatedActionsInnerSection.RadioErgoConfigACGeneralTxPowerChange__42916);
  }

  private void AddASTRO25TrunkingHotList()
  {
    this.Field.Add("UclAstro25TrkHotList_HotListAlias_A00036", (IAcpField) this.UclTrunkingCallHotList.TrunkingCallHotList.UclAstro25TrkHotList_HotListAlias_A00036Object);
  }

  private void AddTypeIITrunkingHotList()
  {
    this.Field.Add("UclT2TrkHotList_HotListAlias_A00039", (IAcpField) this.UclTrunkingT2CallHotList.TrunkingT2CallHotList.UclT2TrkHotList_HotListAlias_A00039Object);
  }

  private void AddASTROConventionalHotList()
  {
    this.Field.Add("UclAstroCnvHotList_HotListAlias_A00042", (IAcpField) this.UclAstroCallHotList.AstroCallHotList.UclAstroCnvHotList_HotListAlias_A00042Object);
  }

  private void AddASTROTalkgroupList()
  {
    this.Field.Add("AstTlkgrpLstGeneralKeyofASTROTalkgroupList_A12665", (IAcpField) this.ASTROTalkgroupList.General.AstTlkgrpLstGeneralKeyofASTROTalkgroupList_A12665);
    this.Field.Add("AstTlkgrpLstGeneralASTROTalkgroupLastUserIndex_A19780", (IAcpField) this.ASTROTalkgroupList.General.AstTlkgrpLstGeneralASTROTalkgroupLastUserIndex_A19780);
    this.Field.Add("AstTlkgrpLstGeneralTalkgroupAlias_A9277", (IAcpField) this.ASTROTalkgroupList.General.AstTlkgrpLstGeneralTalkgroupAlias_A9277);
    this.Field.Add("AstTlkgrpLstGeneralKMFProfileIndex_A8380", (IAcpField) this.ASTROTalkgroupList.General.AstTlkgrpLstGeneralKMFProfileIndex_A8380);
    this.Field.Add("AstTlkgrpLstTalkgroupListTalkgroupAliasText_A9278", (IAcpField) this.TalkgroupTableInner.TalkgroupTableInnerSection.AstTlkgrpLstTalkgroupListTalkgroupAliasText_A9278);
    this.Field.Add("AstTlkgrpLstTalkgroupListDVRSWACNID_A40163", (IAcpField) this.TalkgroupTableInner.TalkgroupTableInnerSection.AstTlkgrpLstTalkgroupListDVRSWACNID_A40163);
    this.Field.Add("AstTlkgrpLstTalkgroupListDVRSSystemID_A40162", (IAcpField) this.TalkgroupTableInner.TalkgroupTableInnerSection.AstTlkgrpLstTalkgroupListDVRSSystemID_A40162);
    this.Field.Add("AstTlkgrpLstTalkgroupListTalkgroupID_A9282", (IAcpField) this.TalkgroupTableInner.TalkgroupTableInnerSection.AstTlkgrpLstTalkgroupListTalkgroupID_A9282);
    this.Field.Add("AstTlkgrpLstTalkgroupListVoiceSecureClearStrapping_A9654", (IAcpField) this.TalkgroupTableInner.TalkgroupTableInnerSection.AstTlkgrpLstTalkgroupListVoiceSecureClearStrapping_A9654);
    this.Field.Add("AstTlkgrpLstTalkgroupListKeySelectReference_A8366", (IAcpField) this.TalkgroupTableInner.TalkgroupTableInnerSection.AstTlkgrpLstTalkgroupListKeySelectReference_A8366);
  }

  private void AddButtons()
  {
    this.Field.Add("BtnPortableButtonName_A22558", (IAcpField) this.PortableButtonInner.PortableButtonInnerSection.BtnPortableButtonName_A22558);
    this.Field.Add("BtnGeneralConventionalBCO_A19543", (IAcpField) this.PortableButtonInner.PortableButtonInnerSection.BtnGeneralConventionalBCO_A19543);
    this.Field.Add("BtnGeneralConventionalFeature_A19544", (IAcpField) this.PortableButtonInner.PortableButtonInnerSection.BtnGeneralConventionalFeature_A19544);
    this.Field.Add("BtnTrunkingPortableTrunkingBCO_A19545", (IAcpField) this.PortableButtonInner.PortableButtonInnerSection.BtnTrunkingPortableTrunkingBCO_A19545);
    this.Field.Add("BtnTrunkingPortableButtonFeature_A19546", (IAcpField) this.PortableButtonInner.PortableButtonInnerSection.BtnTrunkingPortableButtonFeature_A19546);
    this.Field.Add("BtnPortableButtonKey_A22557", (IAcpField) this.PortableButtonInner.PortableButtonInnerSection.BtnPortableButtonKey_A22557);
    this.Field.Add("BtnTopButtonShortPressTime", (IAcpField) this.PortableButtonInner.PortableButtonInnerSection.BtnTopButtonShortPressTime);
    this.Field.Add("BtnButtonDataButtonName_A22612", (IAcpField) this.DataButtonInner.DataButtonInnerSection.BtnButtonDataButtonName_A22612);
    this.Field.Add("BtnConventionalButtonDataButtonBCO_A22611", (IAcpField) this.DataButtonInner.DataButtonInnerSection.BtnConventionalButtonDataButtonBCO_A22611);
    this.Field.Add("BtnConventionalButtonDatatButtonFeature_A22610", (IAcpField) this.DataButtonInner.DataButtonInnerSection.BtnConventionalButtonDatatButtonFeature_A22610);
    this.Field.Add("BtnTrunkingButtonDataButtonBCO_A22609", (IAcpField) this.DataButtonInner.DataButtonInnerSection.BtnTrunkingButtonDataButtonBCO_A22609);
    this.Field.Add("BtnPortableTopButtonLongPressTime", (IAcpField) this.PortableButtonInner.PortableButtonInnerSection.BtnPortableTopButtonLongPressTime);
    this.Field.Add("BtnTrunkingButtonDatatButtonFeature_A22608", (IAcpField) this.DataButtonInner.DataButtonInnerSection.BtnTrunkingButtonDatatButtonFeature_A22608);
    this.Field.Add("BtnButtonDataButtonKey_A22613", (IAcpField) this.DataButtonInner.DataButtonInnerSection.BtnButtonDataButtonKey_A22613);
    this.Field.Add("BtnPortableDataButtonShortPressTime", (IAcpField) this.DataButtonInner.DataButtonInnerSection.BtnPortableDataButtonShortPressTime);
    this.Field.Add("BtnButtonDataButtonLongPressTime", (IAcpField) this.DataButtonInner.DataButtonInnerSection.BtnButtonDataButtonLongPressTime);
    this.Field.Add("BtnSideArrowButtonName_A41567", (IAcpField) this.PortableSideUpDownArrowButtonInner.PortableSideUpDownArrowButtonInnerSection.BtnSideArrowButtonName_A41567);
    this.Field.Add("BtnSideUpDownArrowButtonPrimaryFunction_A41568", (IAcpField) this.PortableSideUpDownArrowButtonInner.PortableSideUpDownArrowButtonInnerSection.BtnSideUpDownArrowButtonPrimaryFunction_A41568);
    this.Field.Add("BtnSideUpDownArrowButtonSecondaryFunction_A41592", (IAcpField) this.PortableSideUpDownArrowButtonInner.PortableSideUpDownArrowButtonInnerSection.BtnSideUpDownArrowButtonSecondaryFunction_A41592);
    this.Field.Add("BtnSideUpDownArrowButtonMFBBCO_A41633", (IAcpField) this.PortableSideUpDownArrowButtonInner.PortableSideUpDownArrowButtonInnerSection.BtnSideUpDownArrowButtonMFBBCO_A41633);
  }

  private void AddControlHeadO2()
  {
    this.Field.Add("CHO2EmergencyButtonName_A41270", (IAcpField) this.O2Inner.O2InnerSection.CHO2EmergencyButtonName_A41270);
    this.Field.Add("CHO2EmergencyButtonBCO_A41271", (IAcpField) this.O2Inner.O2InnerSection.CHO2EmergencyButtonBCO_A41271);
    this.Field.Add("CHO2EmergencyButtonFeature_A41272", (IAcpField) this.O2Inner.O2InnerSection.CHO2EmergencyButtonFeature_A41272);
    this.Field.Add("RadErgoControlO2MFKButtonPress_A42217", (IAcpField) this.ControlHeadO2.O2MultiFunctionKnob.RadErgoControlO2MFKButtonPress_A42217);
    this.Field.Add("O2MFKAssignmentControlName_A41274", (IAcpField) this.O2MFKAssignmentControlInner.O2MFKAssignmentControlInnerSection.O2MFKAssignmentControlName_A41274);
    this.Field.Add("RadErgoControlO2MFKFeatureAssignment_A41275", (IAcpField) this.O2MFKAssignmentControlInner.O2MFKAssignmentControlInnerSection.RadErgoControlO2MFKFeatureAssignment_A41275);
    if (!FieldAccessor.IsCpsApiTest)
      this.Field.Add("RadErgoControlO2MFKFeatureAssignment_A41275_1", (IAcpField) this.O2MFKAssignmentControlInner_1.O2MFKAssignmentControlInnerSection.RadErgoControlO2MFKFeatureAssignment_A41275);
    this.Field.Add("O2UpDownButtonName_A41277", (IAcpField) this.O2NavigationControlsTableInner.O2NavigationControlsTableInnerSection.O2UpDownButtonName_A41277);
    this.Field.Add("RadErgoControlO2UpDownButton_A41278", (IAcpField) this.O2NavigationControlsTableInner.O2NavigationControlsTableInnerSection.RadErgoControlO2UpDownButton_A41278);
  }

  private void AddControlHeadO3()
  {
    this.Field.Add("CntrlHeadO3HHCHButtonName_A22523", (IAcpField) this.O3HHCHButtonInner.O3HHCHButtonInnerSection.CntrlHeadO3HHCHButtonName_A22523);
    this.Field.Add("CntrlHeadO3ConventionalO3HHCHButtonBCO_A19649", (IAcpField) this.O3HHCHButtonInner.O3HHCHButtonInnerSection.CntrlHeadO3ConventionalO3HHCHButtonBCO_A19649);
    this.Field.Add("CntrlHeadO3ConventionalO3HHCHButtonFeature_A19650", (IAcpField) this.O3HHCHButtonInner.O3HHCHButtonInnerSection.CntrlHeadO3ConventionalO3HHCHButtonFeature_A19650);
    this.Field.Add("CntrlHeadO3TrunkingO3HHCHButtonBCO_A19749", (IAcpField) this.O3HHCHButtonInner.O3HHCHButtonInnerSection.CntrlHeadO3TrunkingO3HHCHButtonBCO_A19749);
    this.Field.Add("CntrlHeadO3TrunkingO3HHCHButtonFeature_A19750", (IAcpField) this.O3HHCHButtonInner.O3HHCHButtonInnerSection.CntrlHeadO3TrunkingO3HHCHButtonFeature_A19750);
    this.Field.Add("CntrlHeadO3HHCHButtonKey_A22522", (IAcpField) this.O3HHCHButtonInner.O3HHCHButtonInnerSection.CntrlHeadO3HHCHButtonKey_A22522);
    this.Field.Add("CntrlHeadO3DataButtonName_A22591", (IAcpField) this.O3DataButtonInner.DataButtonInnerSection.CntrlHeadO3DataButtonName_A22591);
    this.Field.Add("CntrlHeadO3ConventionalO3DataButtonBCO_A22592", (IAcpField) this.O3DataButtonInner.DataButtonInnerSection.CntrlHeadO3ConventionalO3DataButtonBCO_A22592);
    this.Field.Add("CntrlHeadO3ConventionalO3DatatButtonFeature_A22595", (IAcpField) this.O3DataButtonInner.DataButtonInnerSection.CntrlHeadO3ConventionalO3DatatButtonFeature_A22595);
    this.Field.Add("CHO3DataButtonConvIndex_A41419", (IAcpField) this.O3DataButtonInner.DataButtonInnerSection.CHO3DataButtonConvIndex_A41419);
    this.Field.Add("CntrlHeadO3TrunkingO3DataButtonBCO_A22596", (IAcpField) this.O3DataButtonInner.DataButtonInnerSection.CntrlHeadO3TrunkingO3DataButtonBCO_A22596);
    this.Field.Add("CntrlHeadO3TrunkingO3DatatButtonFeature_A22597", (IAcpField) this.O3DataButtonInner.DataButtonInnerSection.CntrlHeadO3TrunkingO3DatatButtonFeature_A22597);
    this.Field.Add("CHO3DataButtonTrkIndex_A41420", (IAcpField) this.O3DataButtonInner.DataButtonInnerSection.CHO3DataButtonTrkIndex_A41420);
    this.Field.Add("CntrlHeadO3DataButtonKey_A22590", (IAcpField) this.O3DataButtonInner.DataButtonInnerSection.CntrlHeadO3DataButtonKey_A22590);
    this.Field.Add("RadErgoControlO3NaviControlName_A41374", (IAcpField) this.O3NavigationControlsTableInner.O3NavigationControlsTableInnerSection.RadErgoControlO3NaviControlName_A41374);
    this.Field.Add("RadErgoControlO3NaviControlFeature_A41375", (IAcpField) this.O3NavigationControlsTableInner.O3NavigationControlsTableInnerSection.RadErgoControlO3NaviControlFeature_A41375);
    this.Field.Add("RadErgCtrlHeadO3GeneralShortKeyPressTime", (IAcpField) this.O3HHCHButtonInner.O3HHCHButtonInnerSection.RadErgCtrlHeadO3GeneralShortKeyPressTime);
    this.Field.Add("RadErgCtrlHeadO3GeneralLongKeyPressTime", (IAcpField) this.O3HHCHButtonInner.O3HHCHButtonInnerSection.RadErgCtrlHeadO3GeneralLongKeyPressTime);
    if (FieldAccessor.IsCpsApiTest && !UtilityMack.IsMobile())
      return;
    this.Field.Add("RadErgoControlO3NaviControlFeature_A41375_Down", (IAcpField) this.O3NavigationControlsTableInner_Down.O3NavigationControlsTableInnerSection.RadErgoControlO3NaviControlFeature_A41375);
  }

  private void AddControlHeadO5()
  {
    this.Field.Add("CntrlHeadO5SignalIndependentO5M5MXChiefCHButtonName_A22520", (IAcpField) this.O5Inner.O5InnerSection.CntrlHeadO5SignalIndependentO5M5MXChiefCHButtonName_A22520);
    this.Field.Add("CntrlHeadO5SignalIndependentO5M5MXChiefCHButtonButtonBCO_A19753", (IAcpField) this.O5Inner.O5InnerSection.CntrlHeadO5SignalIndependentO5M5MXChiefCHButtonButtonBCO_A19753);
    this.Field.Add("CntrlHeadO5SignalIndependentO5M5MXChiefCHButtonButtonFeature_A19754", (IAcpField) this.O5Inner.O5InnerSection.CntrlHeadO5SignalIndependentO5M5MXChiefCHButtonButtonFeature_A19754);
    this.Field.Add("CntrlHeadO5SignalIndependentO5M5MXChiefCHButtonKey_A21193", (IAcpField) this.O5Inner.O5InnerSection.CntrlHeadO5SignalIndependentO5M5MXChiefCHButtonKey_A21193);
    this.Field.Add("RadErgCtrlHeadO5ButtonShortKeyPressTime", (IAcpField) this.O5Inner.O5InnerSection.RadErgCtrlHeadO5ShortKeyPressTime);
    this.Field.Add("RadErgCtrlHeadO5DataButtonLongKeyPressTime", (IAcpField) this.O5Inner.O5InnerSection.RadErgCtrlHeadO5LongKeyPressTime);
    this.Field.Add("RadErgoControlO5NaviControlName_A41378", (IAcpField) this.O5NavigationControlsTableInner.O5NavigationControlsTableInnerSection.RadErgoControlO5NaviControlName_A41378);
    this.Field.Add("RadErgoControlO5NaviControlFeature_A41379", (IAcpField) this.O5NavigationControlsTableInner.O5NavigationControlsTableInnerSection.RadErgoControlO5NaviControlFeature_A41379);
    if (FieldAccessor.IsCpsApiTest && !UtilityMack.IsMobile())
      return;
    this.Field.Add("RadErgoControlO5NaviControlFeature_A41379_Down", (IAcpField) this.O5NavigationControlsTableInner_Down.O5NavigationControlsTableInnerSection.RadErgoControlO5NaviControlFeature_A41379);
  }

  private void AddControlHeadO7()
  {
    this.Field.Add("CHO7EmergencyButtonName_A41289", (IAcpField) this.O7Inner.O7InnerSection.CHO7EmergencyButtonName_A41289);
    this.Field.Add("CHO7EmergencyButtonBCO_A41290", (IAcpField) this.O7Inner.O7InnerSection.CHO7EmergencyButtonBCO_A41290);
    this.Field.Add("CHO7EmergencyButtonFeature_A41291", (IAcpField) this.O7Inner.O7InnerSection.CHO7EmergencyButtonFeature_A41291);
    this.Field.Add("RadErgCtrlHeadO7DataButtonName_A41296", (IAcpField) this.O7DataButtonInner.O7DataButtonInnerSection.RadErgCtrlHeadO7DataButtonName_A41296);
    this.Field.Add("RadErgCtrlHeadO7DataButtonCnvBCO_A41300", (IAcpField) this.O7DataButtonInner.O7DataButtonInnerSection.RadErgCtrlHeadO7DataButtonCnvBCO_A41300);
    this.Field.Add("RadErgCtrlHeadO7DataButtonCnvFeature_A41299", (IAcpField) this.O7DataButtonInner.O7DataButtonInnerSection.RadErgCtrlHeadO7DataButtonCnvFeature_A41299);
    this.Field.Add("CHO7DataButtonConvIndex_A41417", (IAcpField) this.O7DataButtonInner.O7DataButtonInnerSection.CHO7DataButtonConvIndex_A41417);
    this.Field.Add("RadErgCtrlHeadO7DataButtonTrkBCO_A41298", (IAcpField) this.O7DataButtonInner.O7DataButtonInnerSection.RadErgCtrlHeadO7DataButtonTrkBCO_A41298);
    this.Field.Add("RadErgCtrlHeadO7DataButtonTrkFeature_A41297", (IAcpField) this.O7DataButtonInner.O7DataButtonInnerSection.RadErgCtrlHeadO7DataButtonTrkFeature_A41297);
    this.Field.Add("CHO7DataButtonTrkIndex_A41418", (IAcpField) this.O7DataButtonInner.O7DataButtonInnerSection.CHO7DataButtonTrkIndex_A41418);
    this.Field.Add("RadErgoControlO7MFKButtonPress_A42218", (IAcpField) this.ControlHeadO7.O7MultiFunctionKnob.RadErgoControlO7MFKButtonPress_A42218);
    this.Field.Add("O7MFKAssignmentControlName_A41294", (IAcpField) this.O7MFKAssignmentControlInner.O7MFKAssignmentControlInnerSection.O7MFKAssignmentControlName_A41294);
    this.Field.Add("RadErgoControlO7MFKFeatureAssignment_A41295", (IAcpField) this.O7MFKAssignmentControlInner.O7MFKAssignmentControlInnerSection.RadErgoControlO7MFKFeatureAssignment_A41295);
    if (!FieldAccessor.IsCpsApiTest || UtilityMack.IsMobile())
    {
      this.Field.Add("RadErgoControlO7MFKFeatureAssignment_A41295_1", (IAcpField) this.O7MFKAssignmentControlInner_1.O7MFKAssignmentControlInnerSection.RadErgoControlO7MFKFeatureAssignment_A41295);
      this.Field.Add("RadErgoControlO7UpDownButton_A41293_Down", (IAcpField) this.O7NavigationControlsTableInner_Down.O7NavigationControlsTableInnerSection.RadErgoControlO7UpDownButton_A41293);
    }
    this.Field.Add("O7UpDownButtonName_A41292", (IAcpField) this.O7NavigationControlsTableInner.O7NavigationControlsTableInnerSection.O7UpDownButtonName_A41292);
    this.Field.Add("RadErgoControlO7UpDownButton_A41293", (IAcpField) this.O7NavigationControlsTableInner.O7NavigationControlsTableInnerSection.RadErgoControlO7UpDownButton_A41293);
  }

  private void AddControlHeadE5()
  {
    if (!FieldAccessor.IsCpsApiTest || UtilityMack.IsMobile())
    {
      this.Field.Add("E5UpDownButtonName_43753", (IAcpField) this.E5NavigationControlsTableInner.E5NavigationControlsTableInnerSection.E5UpDownButtonName_43753);
      this.Field.Add("RadErgoControlE5UpDownButton_43752", (IAcpField) this.E5NavigationControlsTableInner.E5NavigationControlsTableInnerSection.RadErgoControlE5UpDownButton_43752);
      this.Field.Add("RadErgoControlE5UpDownButton_43752_Down", (IAcpField) this.E5NavigationControlsTableInner_Down.E5NavigationControlsTableInnerSection.RadErgoControlE5UpDownButton_43752);
    }
    this.Field.Add("CHE5EmergencyButtonFeature_43768", (IAcpField) this.E5Inner.E5InnerSection.CHE5EmergencyButtonFeature_43768);
    this.Field.Add("E5BottomFunctionButtonIndex_43759", (IAcpField) this.E5BottomFunctionButtonInner.E5BottomFunctionButtonInnerSection.E5BottomFunctionButtonIndex_43759);
    this.Field.Add("E5BottomFunctionButtonFeature_43758", (IAcpField) this.E5BottomFunctionButtonInner.E5BottomFunctionButtonInnerSection.E5BottomFunctionButtonFeature_43758);
    this.Field.Add("E5BottomFunctionButtonBCO_43757", (IAcpField) this.E5BottomFunctionButtonInner.E5BottomFunctionButtonInnerSection.E5BottomFunctionButtonBCO_43757);
  }

  private void AddControlHeadO9()
  {
    this.Field.Add("CHO9EmergencyButtonName_A36680", (IAcpField) this.O9Inner.O9InnerSection.CHO9EmergencyButtonName_A36680);
    this.Field.Add("CHO9EmergencyButtonBCO_A36681", (IAcpField) this.O9Inner.O9InnerSection.CHO9EmergencyButtonBCO_A36681);
    this.Field.Add("CHO9EmergencyButtonFeature_A36682", (IAcpField) this.O9Inner.O9InnerSection.CHO9EmergencyButtonFeature_A36682);
    this.Field.Add("RadErgCtrlHeadO9DataButtonName_A36523", (IAcpField) this.O9DataButtonInner.O9DataButtonInnerSection.RadErgCtrlHeadO9DataButtonName_A36523);
    this.Field.Add("RadErgCtrlHeadO9DataButtonCnvBCO_A36529", (IAcpField) this.O9DataButtonInner.O9DataButtonInnerSection.RadErgCtrlHeadO9DataButtonCnvBCO_A36529);
    this.Field.Add("RadErgCtrlHeadO9DataButtonCnvFeature_A36528", (IAcpField) this.O9DataButtonInner.O9DataButtonInnerSection.RadErgCtrlHeadO9DataButtonCnvFeature_A36528);
    this.Field.Add("CHO9DataButtonConvIndex_A41414", (IAcpField) this.O9DataButtonInner.O9DataButtonInnerSection.CHO9DataButtonConvIndex_A41414);
    this.Field.Add("RadErgCtrlHeadO9DataButtonTrkBCO_A36527", (IAcpField) this.O9DataButtonInner.O9DataButtonInnerSection.RadErgCtrlHeadO9DataButtonTrkBCO_A36527);
    this.Field.Add("RadErgCtrlHeadO9DataButtonTrkFeature_A36526", (IAcpField) this.O9DataButtonInner.O9DataButtonInnerSection.RadErgCtrlHeadO9DataButtonTrkFeature_A36526);
    this.Field.Add("CHO9DataButtonTrkIndex_A41416", (IAcpField) this.O9DataButtonInner.O9DataButtonInnerSection.CHO9DataButtonTrkIndex_A41416);
    this.Field.Add("CHO9TopFunctionButton_A36618", (IAcpField) this.TopFunctionProgrammableButtonListInner.TopFunctionProgrammableButtonListInnerSection.CHO9TopFunctionButton_A36618);
    this.Field.Add("CHO9CnvTopFunctionButtonLabelLine1_A36626", (IAcpField) this.TopFunctionProgrammableButtonListInner.TopFunctionProgrammableButtonListInnerSection.CHO9CnvTopFunctionButtonLabelLine1_A36626);
    this.Field.Add("CHO9CnvTopFunctionButtonLabelLine2_A36627", (IAcpField) this.TopFunctionProgrammableButtonListInner.TopFunctionProgrammableButtonListInnerSection.CHO9CnvTopFunctionButtonLabelLine2_A36627);
    this.Field.Add("CnvTopFunctionButtonBCO_A36628", (IAcpField) this.TopFunctionProgrammableButtonListInner.TopFunctionProgrammableButtonListInnerSection.CnvTopFunctionButtonBCO_A36628);
    this.Field.Add("O9CHCnvTopFunctionButtonFeature_A36629", (IAcpField) this.TopFunctionProgrammableButtonListInner.TopFunctionProgrammableButtonListInnerSection.O9CHCnvTopFunctionButtonFeature_A36629);
    this.Field.Add("O9CHCnvTopFunctionButtonIndex_A36634", (IAcpField) this.TopFunctionProgrammableButtonListInner.TopFunctionProgrammableButtonListInnerSection.O9CHCnvTopFunctionButtonIndex_A36634);
    this.Field.Add("O9CHCnvTopFunctionButtonStsMsgIndex_A36781", (IAcpField) this.TopFunctionProgrammableButtonListInner.TopFunctionProgrammableButtonListInnerSection.O9CHCnvTopFunctionButtonStsMsgIndex_A36781);
    this.Field.Add("TopFunctionBtnCnvZone_A36942", (IAcpField) this.TopFunctionProgrammableButtonListInner.TopFunctionProgrammableButtonListInnerSection.TopFunctionBtnCnvZone_A36942);
    this.Field.Add("TopFunctionBtnCnvChannel_A36943", (IAcpField) this.TopFunctionProgrammableButtonListInner.TopFunctionProgrammableButtonListInnerSection.TopFunctionBtnCnvChannel_A36943);
    this.Field.Add("CHO9TrkTopFunctionButtonLabelLine1_A36650", (IAcpField) this.TopFunctionProgrammableButtonListInner.TopFunctionProgrammableButtonListInnerSection.CHO9TrkTopFunctionButtonLabelLine1_A36650);
    this.Field.Add("CHO9TrkTopFunctionButtonLabelLine2_A36651", (IAcpField) this.TopFunctionProgrammableButtonListInner.TopFunctionProgrammableButtonListInnerSection.CHO9TrkTopFunctionButtonLabelLine2_A36651);
    this.Field.Add("O9CHTrkTopFunctionButtonBCO_A36636", (IAcpField) this.TopFunctionProgrammableButtonListInner.TopFunctionProgrammableButtonListInnerSection.O9CHTrkTopFunctionButtonBCO_A36636);
    this.Field.Add("O9CHTrkTopFunctionButtonFeature_A36637", (IAcpField) this.TopFunctionProgrammableButtonListInner.TopFunctionProgrammableButtonListInnerSection.O9CHTrkTopFunctionButtonFeature_A36637);
    this.Field.Add("O9CHTrkTopFunctionButtonIndex_A36639", (IAcpField) this.TopFunctionProgrammableButtonListInner.TopFunctionProgrammableButtonListInnerSection.O9CHTrkTopFunctionButtonIndex_A36639);
    this.Field.Add("O9CHTrkTopFunctionButtonStsMsgIndex_A36782", (IAcpField) this.TopFunctionProgrammableButtonListInner.TopFunctionProgrammableButtonListInnerSection.O9CHTrkTopFunctionButtonStsMsgIndex_A36782);
    this.Field.Add("TopFunctionBtnTrkZone_A36944", (IAcpField) this.TopFunctionProgrammableButtonListInner.TopFunctionProgrammableButtonListInnerSection.TopFunctionBtnTrkZone_A36944);
    this.Field.Add("TopFunctionBtnTrkChannel_A36945", (IAcpField) this.TopFunctionProgrammableButtonListInner.TopFunctionProgrammableButtonListInnerSection.TopFunctionBtnTrkChannel_A36945);
    this.Field.Add("O9CHTopFunctionProgrammableButtonShortKeyPressTime", (IAcpField) this.TopFunctionProgrammableButtonListInner.TopFunctionProgrammableButtonListInnerSection.O9CHTopFunctionProgrammableButtonShortKeyPressTime);
    this.Field.Add("O9CHTopFunctionProgrammableButtonLongKeyPressTime", (IAcpField) this.TopFunctionProgrammableButtonListInner.TopFunctionProgrammableButtonListInnerSection.O9CHTopFunctionProgrammableButtonLongKeyPressTime);
    this.Field.Add("CHO9BottomFunctionButtonName_A36657", (IAcpField) this.BottomFunctionProgrammableButtonInner.BottomFunctionProgrammableButtonInnerSection.CHO9BottomFunctionButtonName_A36657);
    this.Field.Add("CHO9BottomFunctionButtonBCO_A36660", (IAcpField) this.BottomFunctionProgrammableButtonInner.BottomFunctionProgrammableButtonInnerSection.CHO9BottomFunctionButtonBCO_A36660);
    this.Field.Add("CHO9BottomFunctionButtonFeature_A36664", (IAcpField) this.BottomFunctionProgrammableButtonInner.BottomFunctionProgrammableButtonInnerSection.CHO9BottomFunctionButtonFeature_A36664);
    this.Field.Add("CHO9BottomFunctionButtonIndex_A36665", (IAcpField) this.BottomFunctionProgrammableButtonInner.BottomFunctionProgrammableButtonInnerSection.CHO9BottomFunctionButtonIndex_A36665);
    this.Field.Add("CHO9PursuitKnobMode_A36683", (IAcpField) this.ResponseSelectorListInner.ResponseSelectorListInnerSection.CHO9PursuitKnobMode_A36683);
    this.Field.Add("CHO9PursuitKnobAction_A36684", (IAcpField) this.ResponseSelectorListInner.ResponseSelectorListInnerSection.CHO9PursuitKnobAction_A36684);
    this.Field.Add("CHO9PursuitKnobIndex_A36685", (IAcpField) this.ResponseSelectorListInner.ResponseSelectorListInnerSection.CHO9PursuitKnobIndex_A36685);
    this.Field.Add("CHO9PursuitKnobSecondaryIndex_A36823", (IAcpField) this.ResponseSelectorListInner.ResponseSelectorListInnerSection.CHO9PursuitKnobSecondaryIndex_A36823);
    this.Field.Add("CHO9PursuitKnobTertiaryIndex_A37025", (IAcpField) this.ResponseSelectorListInner.ResponseSelectorListInnerSection.CHO9PursuitKnobTertiaryIndex_A37025);
    this.Field.Add("RadErgCtrlHeadO9DirLightBarName_A36558", (IAcpField) this.DirectionalButtonsListInner.DirectionalButtonsListInnerSection.RadErgCtrlHeadO9DirLightBarName_A36558);
    this.Field.Add("RadErgCtrlHeadO9DirLightBarBCO_A36559", (IAcpField) this.DirectionalButtonsListInner.DirectionalButtonsListInnerSection.RadErgCtrlHeadO9DirLightBarBCO_A36559);
    this.Field.Add("RadErgCtrlHeadO9DirLightBarFeature_A36597", (IAcpField) this.DirectionalButtonsListInner.DirectionalButtonsListInnerSection.RadErgCtrlHeadO9DirLightBarFeature_A36597);
    this.Field.Add("RadErgCtrlHeadO9DirLightBarIndex_A36601", (IAcpField) this.DirectionalButtonsListInner.DirectionalButtonsListInnerSection.RadErgCtrlHeadO9DirLightBarIndex_A36601);
    this.Field.Add("PGRMBLEO9DiretionShortPressTime", (IAcpField) this.DirectionalButtonsListInner.DirectionalButtonsListInnerSection.PGRMBLEO9DiretionShortPressTime);
    this.Field.Add("PGRMBLEO9DiretionLongPressTime", (IAcpField) this.DirectionalButtonsListInner.DirectionalButtonsListInnerSection.PGRMBLEO9DiretionLongPressTime);
    this.Field.Add("CHO9PASirenButtonsName_A41537", (IAcpField) this.PASirenButtonsListInner.PASirenButtonsListInnerSection.CHO9PASirenButtonsName_A41537);
    this.Field.Add("CHO9PASirenButtonsBCO_A41538", (IAcpField) this.PASirenButtonsListInner.PASirenButtonsListInnerSection.CHO9PASirenButtonsBCO_A41538);
    this.Field.Add("CHO9PASirenButtonsFeature_A41540", (IAcpField) this.PASirenButtonsListInner.PASirenButtonsListInnerSection.CHO9PASirenButtonsFeature_A41540);
    this.Field.Add("RdEgoO9DirLtbarPatternBcoListBco_A36661", (IAcpField) this.RelayPatternBCOListListInner.RelayPatternBCOListListInnerSection.RdEgoO9DirLtbarPatternBcoListBco_A36661);
    this.Field.Add("RdEgoO9DirLtbarPatternBcoListIndex_A36707", (IAcpField) this.RelayPatternBCOListListInner.RelayPatternBCOListListInnerSection.RdEgoO9DirLtbarPatternBcoListIndex_A36707);
    this.Field.Add("RadErgoControlO9ACBCOListBco_A36666", (IAcpField) this.ConsolidatedActionBCOListInner.ConsolidatedActionBCOListInnerSection.RadErgoControlO9ACBCOListBco_A36666);
    this.Field.Add("RadErgoControlO9ACBCOListIndex_A36668", (IAcpField) this.ConsolidatedActionBCOListInner.ConsolidatedActionBCOListInnerSection.RadErgoControlO9ACBCOListIndex_A36668);
    this.Field.Add("RadErgoControlO9NaviControlName_A41370", (IAcpField) this.O9NavigationControlsTableInner.O9NavigationControlsTableInnerSection.RadErgoControlO9NaviControlName_A41370);
    this.Field.Add("RadErgoControlO9NaviControlFeature_A41371", (IAcpField) this.O9NavigationControlsTableInner.O9NavigationControlsTableInnerSection.RadErgoControlO9NaviControlFeature_A41371);
    if (!FieldAccessor.IsCpsApiTest || UtilityMack.IsMobile())
      this.Field.Add("RadErgoControlO9NaviControlFeature_A41371_Down", (IAcpField) this.O9NavigationControlsTableInner_Down.O9NavigationControlsTableInnerSection.RadErgoControlO9NaviControlFeature_A41371);
    this.Field.Add("CHO9BottomFunctionButtonBCO_A36827", (IAcpField) this.BottomFunctionButtonBCOListInner.BottomFunctionButtonBCOListInnerSection.CHO9BottomFunctionButtonBCO_A36827);
    this.Field.Add("CHO9BottomFunctionButtonFeature_A36826", (IAcpField) this.BottomFunctionButtonBCOListInner.BottomFunctionButtonBCOListInnerSection.CHO9BottomFunctionButtonFeature_A36826);
    this.Field.Add("PGRMBLEO9BottomShortPressTime", (IAcpField) this.BottomFunctionButtonBCOListInner.BottomFunctionButtonBCOListInnerSection.PGRMBLEO9BottomShortPressTime);
    this.Field.Add("PGRMBLEO9BottomLongPressTime", (IAcpField) this.BottomFunctionButtonBCOListInner.BottomFunctionButtonBCOListInnerSection.PGRMBLEO9BottomLongPressTime);
  }

  private void AddConventionalAliasLists()
  {
    this.Field.Add("CnvAlsLstMessageAliasListMessageAliasNumber_A8501", (IAcpField) this.MessageAliasTableInner.MessageAliasTableInnerSection.CnvAlsLstMessageAliasListMessageAliasNumber_A8501);
    this.Field.Add("CnvAlsLstMessageAliasListMessageAliasText_A8502", (IAcpField) this.MessageAliasTableInner.MessageAliasTableInnerSection.CnvAlsLstMessageAliasListMessageAliasText_A8502);
    this.Field.Add("CnvAlsLstStatusAliasListStatusAliasNumber_A9191", (IAcpField) this.StatusAliasTableInner.StatusAliasTableInnerSection.CnvAlsLstStatusAliasListStatusAliasNumber_A9191);
    this.Field.Add("CnvAlsLstStatusAliasListStatusAliasText_A9192", (IAcpField) this.StatusAliasTableInner.StatusAliasTableInnerSection.CnvAlsLstStatusAliasListStatusAliasText_A9192);
  }

  private void AddConventionalEmergencyProfiles()
  {
    this.Field.Add("CnvEmerProfGeneralkeyofConventionalEmergencyProfiles_A19418", (IAcpField) this.ConventionalEmergencyProfiles.General.CnvEmerProfGeneralkeyofConventionalEmergencyProfiles_A19418);
    this.Field.Add("CnvEmerProfGeneralEmergencyType_A7960", (IAcpField) this.ConventionalEmergencyProfiles.General.CnvEmerProfGeneralEmergencyType_A7960);
    this.Field.Add("CnvEmerProfGeneralConsoleAckRequired_A40167", (IAcpField) this.ConventionalEmergencyProfiles.General.CnvEmerProfGeneralConsoleAckRequired_A40167);
    this.Field.Add("CnvEmerProfGeneralAcknowledgeAlertTone_A7394", (IAcpField) this.ConventionalEmergencyProfiles.General.CnvEmerProfGeneralAcknowledgeAlertTone_A7394);
    this.Field.Add("CnvEmerProfGeneralPoliteRetries_A8712", (IAcpField) this.ConventionalEmergencyProfiles.General.CnvEmerProfGeneralPoliteRetries_A8712);
    this.Field.Add("CnvEmerProfGeneralImpoliteRetries_A8242", (IAcpField) this.ConventionalEmergencyProfiles.General.CnvEmerProfGeneralImpoliteRetries_A8242);
    this.Field.Add("CnvPerManDownEnable_42038", (IAcpField) this.ConventionalEmergencyProfiles.General.CnvPerManDownEnable_42038);
    this.Field.Add("ConEmerProEmergencyAutoTransmitMode_A22532", (IAcpField) this.ConventionalEmergencyProfiles.General.ConEmerProEmergencyAutoTransmitMode_A22532);
    this.Field.Add("CnvEmerProfGeneralTxPeriodsec1_A8212", (IAcpField) this.ConventionalEmergencyProfiles.General.CnvEmerProfGeneralTxPeriodsec1_A8212);
    this.Field.Add("CnvEmerProfGeneralTxPeriodsec2_A43600", (IAcpField) this.ConventionalEmergencyProfiles.General.CnvEmerProfGeneralTxPeriodsec2_A43600);
    this.Field.Add("CnvEmerProfGeneralTxPeriodsec2_A9131", (IAcpField) this.ConventionalEmergencyProfiles.General.CnvEmerProfGeneralTxPeriodsec2_A9131);
    this.Field.Add("CnvEmerProfGeneralEnable3_A8171", (IAcpField) this.ConventionalEmergencyProfiles.General.CnvEmerProfGeneralEnable3_A8171);
    this.Field.Add("CnvEmerProfGeneralFactor_A9548", (IAcpField) this.ConventionalEmergencyProfiles.General.CnvEmerProfGeneralFactor_A9548);
    this.Field.Add("CnvEmerProfMDCEmergencyPTTIDSidetone_A7946", (IAcpField) this.ConventionalEmergencyProfiles.MDC.CnvEmerProfMDCEmergencyPTTIDSidetone_A7946);
    this.Field.Add("CnvEmerProfMDCTxBaseTimeSec_A9514", (IAcpField) this.ConventionalEmergencyProfiles.MDC.CnvEmerProfMDCTxBaseTimeSec_A9514);
    this.Field.Add("CnvEmerProfMDCRxBaseTimesec_A8999", (IAcpField) this.ConventionalEmergencyProfiles.MDC.CnvEmerProfMDCRxBaseTimesec_A8999);
    this.Field.Add("CnvEmerProfMDCEnable2_A7924", (IAcpField) this.ConventionalEmergencyProfiles.MDC.CnvEmerProfMDCEnable2_A7924);
    this.Field.Add("EmergencyToneTrigger_42045", (IAcpField) this.EmergencyToneTableInner.EmergencyToneTableInnerSection.EmergencyToneTrigger_42045);
    this.Field.Add("EmerTone_42046", (IAcpField) this.EmergencyToneTableInner.EmergencyToneTableInnerSection.EmerTone_42046);
    this.Field.Add("EmerToneMinimumVolumn_42047", (IAcpField) this.EmergencyToneTableInner.EmergencyToneTableInnerSection.EmerToneMinimumVolumn_42047);
    this.Field.Add("EmerTonePeriodSec_42048", (IAcpField) this.EmergencyToneTableInner.EmergencyToneTableInnerSection.EmerTonePeriodSec_42048);
    this.Field.Add("EmerAudioRouting_42049", (IAcpField) this.EmergencyToneTableInner.EmergencyToneTableInnerSection.EmerAudioRouting_42049);
    this.Field.Add("CnvEmergencyToneSelection_42053", (IAcpField) this.ConventionalEmergencyProfiles.Labtool.CnvEmergencyToneSelection_42053);
    if (this.ConventionalEmergencyProfiles.EmergencyCompatibilityOptionsConventional == null)
      return;
    this.Field.Add("EmergencyExitControl_43344", (IAcpField) this.ConventionalEmergencyProfiles.EmergencyCompatibilityOptionsConventional.EmergencyExitControl_43344);
    this.Field.Add("EmergencyHotMicReStart_43343", (IAcpField) this.ConventionalEmergencyProfiles.EmergencyCompatibilityOptionsConventional.EmergencyHotMicReStart_43343);
  }

  private void AddConventionalPersonality()
  {
    this.Field.Add("CnvPerGeneralConventionalPersonalityName_A12660", (IAcpField) this.ConventionalPersonality.General.CnvPerGeneralConventionalPersonalityName_A12660);
    this.Field.Add("CnvPerFeaturesDVRSProf_A41794", (IAcpField) this.ConventionalPersonality.General.CnvPerFeaturesDVRSProf_A41794);
    this.Field.Add("CnvPerGeneralTalkgroupTextList_A19822", (IAcpField) this.ConventionalPersonality.General.CnvPerGeneralTalkgroupTextList_A19822);
    this.Field.Add("CnvPerRxOptionsReceiveOnlyPersonality_A8916", (IAcpField) this.ConventionalPersonality.RxOptions.CnvPerRxOptionsReceiveOnlyPersonality_A8916);
    this.Field.Add("CnvPerRxOptionsRxVoiceSignalType_A9044", (IAcpField) this.ConventionalPersonality.RxOptions.CnvPerRxOptionsRxVoiceSignalType_A9044);
    this.Field.Add("CnvPerRxOptionsUnmuteMuteType_A9602", (IAcpField) this.ConventionalPersonality.RxOptions.CnvPerRxOptionsUnmuteMuteType_A9602);
    this.Field.Add("CnvPerRxOptionsRxUnmuteDelayms_A9033", (IAcpField) this.ConventionalPersonality.RxOptions.CnvPerRxOptionsRxUnmuteDelayms_A9033);
    this.Field.Add("CnvPerRxOptionsSquelchFineTune_A9176", (IAcpField) this.ConventionalPersonality.RxOptions.CnvPerRxOptionsSquelchFineTune_A9176);
    this.Field.Add("CnvPerRxOptionsBusyLED_A7570", (IAcpField) this.ConventionalPersonality.RxOptions.CnvPerRxOptionsBusyLED_A7570);
    this.Field.Add("CnvPerRxOptionsRxDeEmphasis_A9010", (IAcpField) this.ConventionalPersonality.RxOptions.CnvPerRxOptionsRxDeEmphasis_A9010);
    this.Field.Add("CnvPerRxOptionsHearClear_A36408", (IAcpField) this.ConventionalPersonality.RxOptions.CnvPerRxOptionsHearClear_A36408);
    this.Field.Add("CnvPerRxOptionsConcurrentRXEnable", (IAcpField) this.ConventionalPersonality.RxOptions.CnvPerRxOptionsRxDeEmphasis_A9010);
    this.Field.Add("CnvPerTxOptionsTxVoiceSignalType_A9574", (IAcpField) this.ConventionalPersonality.TxOptions.CnvPerTxOptionsTxVoiceSignalType_A9574);
    this.Field.Add("CnvPerTxOptionsTimeOutTimersec_A9378", (IAcpField) this.ConventionalPersonality.TxOptions.CnvPerTxOptionsTimeOutTimersec_A9378);
    this.Field.Add("CnvPerTxOptionsTransmitPreEmphasis_A9411", (IAcpField) this.ConventionalPersonality.TxOptions.CnvPerTxOptionsTransmitPreEmphasis_A9411);
    this.Field.Add("CnvPerTxOptionsReverseBurstTurnOffCode_A8952", (IAcpField) this.ConventionalPersonality.TxOptions.CnvPerTxOptionsReverseBurstTurnOffCode_A8952);
    this.Field.Add("CnvPerTxOptionsTransmitPowerLevel_A9420", (IAcpField) this.ConventionalPersonality.TxOptions.CnvPerTxOptionsTransmitPowerLevel_A9420);
    this.Field.Add("CnvPerTxOptionsAdaptivePower_A7405", (IAcpField) this.ConventionalPersonality.TxOptions.CnvPerTxOptionsAdaptivePower_A7405);
    this.Field.Add("CnvPerTxOptionsTalkPermitTone", (IAcpField) this.ConventionalPersonality.TxOptions.CnvPerTxOptionsTalkPermitTone);
    this.Field.Add("CnvPerConventionalChannelOptionsKeyofConventionalChannelOptions_A20745", (IAcpField) this.FrequencyOptionsInner.FrequencyOptionsInnerSection.CnvPerConventionalChannelOptionsKeyofConventionalChannelOptions_A20745);
    this.Field.Add("CnvPerConventionalChannelOptionsRxFrequency_A8911", (IAcpField) this.FrequencyOptionsInner.FrequencyOptionsInnerSection.CnvPerConventionalChannelOptionsRxFrequency_A8911);
    this.Field.Add("CnvPerConventionalChannelOptionsTxFrequency_A9414", (IAcpField) this.FrequencyOptionsInner.FrequencyOptionsInnerSection.CnvPerConventionalChannelOptionsTxFrequency_A9414);
    this.Field.Add("CnvPerConventionalChannelOptionsItinerantChannelFrequency_A8359", (IAcpField) this.FrequencyOptionsInner.FrequencyOptionsInnerSection.CnvPerConventionalChannelOptionsItinerantChannelFrequency_A8359);
    this.Field.Add("CnvPerConventionalChannelOptionsDirectTalkaround_A9255", (IAcpField) this.FrequencyOptionsInner.FrequencyOptionsInnerSection.CnvPerConventionalChannelOptionsDirectTalkaround_A9255);
    this.Field.Add("CnvPerConventionalChannelOptionsTAFrequency_A9260", (IAcpField) this.FrequencyOptionsInner.FrequencyOptionsInnerSection.CnvPerConventionalChannelOptionsTAFrequency_A9260);
    this.Field.Add("CnvPerConventionalChannelOptionsTxDevChanSpacing_A23192", (IAcpField) this.FrequencyOptionsInner.FrequencyOptionsInnerSection.CnvPerConventionalChannelOptionsTxDevChanSpacing_A23192);
    this.Field.Add("CnvPerConventionalChannelOptionsRxNetworkID_A9023", (IAcpField) this.FrequencyOptionsInner.FrequencyOptionsInnerSection.CnvPerConventionalChannelOptionsRxNetworkID_A9023);
    this.Field.Add("CnvPerConventionalChannelOptionsTxNetworkID_A9550", (IAcpField) this.FrequencyOptionsInner.FrequencyOptionsInnerSection.CnvPerConventionalChannelOptionsTxNetworkID_A9550);
    this.Field.Add("CnvPerConventionalChannelOptionsTANetworkID_A7863", (IAcpField) this.FrequencyOptionsInner.FrequencyOptionsInnerSection.CnvPerConventionalChannelOptionsTANetworkID_A7863);
    this.Field.Add("CnvPerConventionalChannelOptionsASTROTalkgroupID_A9281", (IAcpField) this.FrequencyOptionsInner.FrequencyOptionsInnerSection.CnvPerConventionalChannelOptionsASTROTalkgroupID_A9281);
    this.Field.Add("CnvPerConventionalChannelOptionsUserSelectablePLMPL_A9606", (IAcpField) this.FrequencyOptionsInner.FrequencyOptionsInnerSection.CnvPerConventionalChannelOptionsUserSelectablePLMPL_A9606);
    this.Field.Add("CnvPerConventionalChannelOptionsUserSelectablePLMPLEnhance_43029", (IAcpField) this.FrequencyOptionsInner.FrequencyOptionsInnerSection.CnvPerConventionalChannelOptionsUserSelectablePLMPLEnhance_43029);
    this.Field.Add("CnvPerConventionalChannelOptionsRxSquelchType_A8919", (IAcpField) this.FrequencyOptionsInner.FrequencyOptionsInnerSection.CnvPerConventionalChannelOptionsRxSquelchType_A8919);
    this.Field.Add("CnvPerConventionalChannelOptionsRxPLFreq_A8918", (IAcpField) this.FrequencyOptionsInner.FrequencyOptionsInnerSection.CnvPerConventionalChannelOptionsRxPLFreq_A8918);
    this.Field.Add("CnvPerConventionalChannelOptionsRxPLCode_A8917", (IAcpField) this.FrequencyOptionsInner.FrequencyOptionsInnerSection.CnvPerConventionalChannelOptionsRxPLCode_A8917);
    this.Field.Add("CnvPerConventionalChannelOptionsRxDPLCode_A8908", (IAcpField) this.FrequencyOptionsInner.FrequencyOptionsInnerSection.CnvPerConventionalChannelOptionsRxDPLCode_A8908);
    this.Field.Add("CnvPerConventionalChannelOptionsRxDPLInvert_A8909", (IAcpField) this.FrequencyOptionsInner.FrequencyOptionsInnerSection.CnvPerConventionalChannelOptionsRxDPLInvert_A8909);
    this.Field.Add("CnvPerConventionalChannelOptionsTxSquelchType_A9426", (IAcpField) this.FrequencyOptionsInner.FrequencyOptionsInnerSection.CnvPerConventionalChannelOptionsTxSquelchType_A9426);
    this.Field.Add("CnvPerConventionalChannelOptionsTxPLFreq_A9419", (IAcpField) this.FrequencyOptionsInner.FrequencyOptionsInnerSection.CnvPerConventionalChannelOptionsTxPLFreq_A9419);
    this.Field.Add("CnvPerConventionalChannelOptionsTxPLCode_A9418", (IAcpField) this.FrequencyOptionsInner.FrequencyOptionsInnerSection.CnvPerConventionalChannelOptionsTxPLCode_A9418);
    this.Field.Add("CnvPerConventionalChannelOptionsTxDPLCode_A9409", (IAcpField) this.FrequencyOptionsInner.FrequencyOptionsInnerSection.CnvPerConventionalChannelOptionsTxDPLCode_A9409);
    this.Field.Add("CnvPerConventionalChannelOptionsTxDPLInvert_A9410", (IAcpField) this.FrequencyOptionsInner.FrequencyOptionsInnerSection.CnvPerConventionalChannelOptionsTxDPLInvert_A9410);
    this.Field.Add("CnvPerConventionalChannelOptionsTASquelchType_A9265", (IAcpField) this.FrequencyOptionsInner.FrequencyOptionsInnerSection.CnvPerConventionalChannelOptionsTASquelchType_A9265);
    this.Field.Add("CnvPerConventionalChannelOptionsTAPLFreq_A9264", (IAcpField) this.FrequencyOptionsInner.FrequencyOptionsInnerSection.CnvPerConventionalChannelOptionsTAPLFreq_A9264);
    this.Field.Add("CnvPerConventionalChannelOptionsTAPLCode_A9261", (IAcpField) this.FrequencyOptionsInner.FrequencyOptionsInnerSection.CnvPerConventionalChannelOptionsTAPLCode_A9261);
    this.Field.Add("CnvPerConventionalChannelOptionsTADPLCode_A9256", (IAcpField) this.FrequencyOptionsInner.FrequencyOptionsInnerSection.CnvPerConventionalChannelOptionsTADPLCode_A9256);
    this.Field.Add("CnvPerConventionalChannelOptionsTADPLInvert_A9259", (IAcpField) this.FrequencyOptionsInner.FrequencyOptionsInnerSection.CnvPerConventionalChannelOptionsTADPLInvert_A9259);
    this.Field.Add("CnvPerConventionalChannelOptionsPLDeviation_A8708", (IAcpField) this.FrequencyOptionsInner.FrequencyOptionsInnerSection.CnvPerConventionalChannelOptionsPLDeviation_A8708);
    this.Field.Add("CnvPerConventionalChannelOptionsTalkaround_A19837", (IAcpField) this.FrequencyOptionsInner.FrequencyOptionsInnerSection.CnvPerConventionalChannelOptionsTalkaround_A19837);
    this.Field.Add("CnvPerConventionalFrqncyOptnsMixVSPersistentMember_A38726", (IAcpField) this.FrequencyOptionsInner.FrequencyOptionsInnerSection.CnvPerConventionalFrqncyOptnsMixVSPersistentMember_A38726);
    this.Field.Add("CnvPerSignalingASTROSystem_A7498", (IAcpField) this.ConventionalPersonality.Signaling.CnvPerSignalingASTROSystem_A7498);
    this.Field.Add("CnvPerSignalingDigitalModulatorType_A7857", (IAcpField) this.ConventionalPersonality.Signaling.CnvPerSignalingDigitalModulatorType_A7857);
    this.Field.Add("CnvPerSignalingASTRORxUnmuteRule_A9042", (IAcpField) this.ConventionalPersonality.Signaling.CnvPerSignalingASTRORxUnmuteRule_A9042);
    this.Field.Add("CnvPerSignalingLateEntryFastUnmute_A8423", (IAcpField) this.ConventionalPersonality.Signaling.CnvPerSignalingLateEntryFastUnmute_A8423);
    this.Field.Add("CnvPerSignalingSignalingType_A9129", (IAcpField) this.ConventionalPersonality.Signaling.CnvPerSignalingSignalingType_A9129);
    this.Field.Add("CnvPerSignalingSystemNumber_A9243", (IAcpField) this.ConventionalPersonality.Signaling.CnvPerSignalingSystemNumber_A9243);
    this.Field.Add("CnvPerSignalingPTTID_A8770", (IAcpField) this.ConventionalPersonality.Signaling.CnvPerSignalingPTTID_A8770);
    this.Field.Add("CnvPerSignalingEmergencyPTTID_A7944", (IAcpField) this.ConventionalPersonality.Signaling.CnvPerSignalingEmergencyPTTID_A7944);
    this.Field.Add("CnvPerSignalingRevertType_A8953", (IAcpField) this.ConventionalPersonality.Signaling.CnvPerSignalingRevertType_A8953);
    this.Field.Add("CnvPerSignalingRevertZone_A13269", (IAcpField) this.ConventionalPersonality.Signaling.CnvPerSignalingRevertZone_A13269);
    this.Field.Add("CnvPerSignalingRevertChannel_A13267", (IAcpField) this.ConventionalPersonality.Signaling.CnvPerSignalingRevertChannel_A13267);
    this.Field.Add("CnvPerSignalingRevertTGWACNID_A40150", (IAcpField) this.ConventionalPersonality.Signaling.CnvPerSignalingRevertTGWACNID_A40150);
    this.Field.Add("CnvPerSignalingRevertTGSYSID_A40151", (IAcpField) this.ConventionalPersonality.Signaling.CnvPerSignalingRevertTGSYSID_A40151);
    this.Field.Add("CnvPerSignalingRevertTG_A40152", (IAcpField) this.ConventionalPersonality.Signaling.CnvPerSignalingRevertTG_A40152);
    this.Field.Add("CnvPerSignalingRevertTGSecClearStrap_A40153", (IAcpField) this.ConventionalPersonality.Signaling.CnvPerSignalingRevertTGSecClearStrap_A40153);
    this.Field.Add("CnvPerSignalingRevertTGKeySel_A40154", (IAcpField) this.ConventionalPersonality.Signaling.CnvPerSignalingRevertTGKeySel_A40154);
    this.Field.Add("CnvPerAGAGWACNID_A40155", (IAcpField) this.ConventionalPersonality.DVRS.CnvPerAGAGWACNID_A40155);
    this.Field.Add("CnvPerAGAGSysID_A40156", (IAcpField) this.ConventionalPersonality.DVRS.CnvPerAGAGSysID_A40156);
    this.Field.Add("CnvPerAGAGTalkgroupID_A40157", (IAcpField) this.ConventionalPersonality.DVRS.CnvPerAGAGTalkgroupID_A40157);
    this.Field.Add("CnvPerAGAGSecStrap_A40158", (IAcpField) this.ConventionalPersonality.DVRS.CnvPerAGAGSecStrap_A40158);
    this.Field.Add("CnvPerAGAGKeySel_A40159", (IAcpField) this.ConventionalPersonality.DVRS.CnvPerAGAGKeySel_A40159);
    this.Field.Add("CnvPerNonASTROCallSelectiveCallRxTx_A9116", (IAcpField) this.ConventionalPersonality.NonASTROCall.CnvPerNonASTROCallSelectiveCallRxTx_A9116);
    this.Field.Add("CnvPerNonASTROCallUnmuteType_A9601", (IAcpField) this.ConventionalPersonality.NonASTROCall.CnvPerNonASTROCallUnmuteType_A9601);
    this.Field.Add("CnvPerNonASTROCallCallAlertRxTx_A7588", (IAcpField) this.ConventionalPersonality.NonASTROCall.CnvPerNonASTROCallCallAlertRxTx_A7588);
    this.Field.Add("CnvPerNonASTROCallInCallUserAlertEnable_A8252", (IAcpField) this.ConventionalPersonality.NonASTROCall.CnvPerNonASTROCallInCallUserAlertEnable_A8252);
    this.Field.Add("CnvPerNonASTROCallRTTButtonAccess_A8493", (IAcpField) this.ConventionalPersonality.NonASTROCall.CnvPerNonASTROCallRTTButtonAccess_A8493);
    this.Field.Add("CnvPerNonASTROCallAutoSelectCallTransmit_A7520", (IAcpField) this.ConventionalPersonality.NonASTROCall.CnvPerNonASTROCallAutoSelectCallTransmit_A7520);
    this.Field.Add("CnvPerNonASTROCallUnlimitedCalling_A9597", (IAcpField) this.ConventionalPersonality.NonASTROCall.CnvPerNonASTROCallUnlimitedCalling_A9597);
    this.Field.Add("CnvPerLabtoolAnalogHotListItemID_A21918", (IAcpField) this.ConventionalPersonality.NonASTROCall.CnvPerLabtoolAnalogHotListItemID_A21918);
    this.Field.Add("CnvPerASTROCallSelectiveCallRxTx_A9114", (IAcpField) this.ConventionalPersonality.ASTROCall.CnvPerASTROCallSelectiveCallRxTx_A9114);
    this.Field.Add("CnvPerASTROCallAutoSelectiveCallTransmit_A7518", (IAcpField) this.ConventionalPersonality.ASTROCall.CnvPerASTROCallAutoSelectiveCallTransmit_A7518);
    this.Field.Add("CnvPerASTROCallCallAlertRxTx_A7586", (IAcpField) this.ConventionalPersonality.ASTROCall.CnvPerASTROCallCallAlertRxTx_A7586);
    this.Field.Add("CnvPerASTROCallInCallUserAlertEnable_A8250", (IAcpField) this.ConventionalPersonality.ASTROCall.CnvPerASTROCallInCallUserAlertEnable_A8250);
    this.Field.Add("CnvPerTacticalInhibitKillOperation_A41553", (IAcpField) this.ConventionalPersonality.ASTROCall.CnvPerTacticalInhibitKillOperation_A41553);
    this.Field.Add("CnvPerTacticalInhibitStunOperation_A41557", (IAcpField) this.ConventionalPersonality.ASTROCall.CnvPerTacticalInhibitStunOperation_A41557);
    this.Field.Add("CnvPerASTROCallASTROUnlimitedCalling_A7501", (IAcpField) this.ConventionalPersonality.ASTROCall.CnvPerASTROCallASTROUnlimitedCalling_A7501);
    this.Field.Add("CnvPerASTROCallASTROCallHotList_A7488", (IAcpField) this.ConventionalPersonality.ASTROCall.CnvPerASTROCallASTROCallHotList_A7488);
    this.Field.Add("CnvPerASTROCallRadioUninhibitDecodeAction_A9045", (IAcpField) this.ConventionalPersonality.ASTROCall.CnvPerASTROCallRadioUninhibitDecodeAction_A9045);
    this.Field.Add("CnvPerASTROCallRemoteMonitorTxRxTime", (IAcpField) this.ConventionalPersonality.ASTROCall.CnvPerASTROCallRemoteMonitorTxRxTime);
    this.Field.Add("CnvPerASTROCallTacticalServicesOperation", (IAcpField) this.ConventionalPersonality.ASTROCall.CnvPerASTROCallTacticalServicesOperation);
    this.Field.Add("CnvPerFeaturesAstroAlertingToneTable", (IAcpField) this.ConventionalPersonality.Signaling.CnvPerFeaturesAstroAlertingToneTable);
    this.Field.Add("CnvPerASTROTalkgroupOptionsTalkGroupEnable_A9272", (IAcpField) this.ConventionalPersonality.ASTROTalkgroup.CnvPerASTROTalkgroupOptionsTalkGroupEnable_A9272);
    this.Field.Add("CnvPerASTROTalkgroupOptionsTalkgroupList_A9283", (IAcpField) this.ConventionalPersonality.ASTROTalkgroup.CnvPerASTROTalkgroupOptionsTalkgroupList_A9283);
    this.Field.Add("CnvPerASTROTalkgroupOptionsSelectionType_A9112", (IAcpField) this.ConventionalPersonality.ASTROTalkgroup.CnvPerASTROTalkgroupOptionsSelectionType_A9112);
    this.Field.Add("CnvPerRACRepeaterAccess_A8939", (IAcpField) this.ConventionalPersonality.RAC.CnvPerRACRepeaterAccess_A8939);
    this.Field.Add("CnvPerRACAccessType_A7388", (IAcpField) this.ConventionalPersonality.RAC.CnvPerRACAccessType_A7388);
    this.Field.Add("CnvPerRACCodeType1_A7680", (IAcpField) this.ConventionalPersonality.RAC.CnvPerRACCodeType1_A7680);
    this.Field.Add("CnvPerRACMDCRepeaterID1_A8783", (IAcpField) this.ConventionalPersonality.RAC.CnvPerRACMDCRepeaterID1_A8783);
    this.Field.Add("CnvPerRACCodeType2_A8817", (IAcpField) this.ConventionalPersonality.RAC.CnvPerRACCodeType2_A8817);
    this.Field.Add("CnvPerRACMDCRepeaterID2_A8814", (IAcpField) this.ConventionalPersonality.RAC.CnvPerRACMDCRepeaterID2_A8814);
    this.Field.Add("CnvPerLabtoolOTACROTACSMessaging_A8663", (IAcpField) this.ConventionalPersonality.Features.CnvPerLabtoolOTACROTACSMessaging_A8663);
    this.Field.Add("CnvPerFeaturesTacticalRekeyEnable_A19309", (IAcpField) this.ConventionalPersonality.Features.CnvPerFeaturesTacticalRekeyEnable_A19309);
    this.Field.Add("CnvPerLabtoolHotKeypad_A8208", (IAcpField) this.ConventionalPersonality.Features.CnvPerLabtoolHotKeypad_A8208);
    this.Field.Add("CnvPerLabtoolScanListSelection_A9054", (IAcpField) this.ConventionalPersonality.Features.CnvPerLabtoolScanListSelection_A9054);
    this.Field.Add("CnvPerLabtoolAutomaticScan_A7527", (IAcpField) this.ConventionalPersonality.Features.CnvPerLabtoolAutomaticScan_A7527);
    this.Field.Add("CnvPerFeaturesMixedVoteScanEnable_A38723", (IAcpField) this.ConventionalPersonality.Features.CnvPerFeaturesMixedVoteScanEnable_A38723);
    this.Field.Add("CnvPerFeaturesMixedVoteScanTxSteering_A38878", (IAcpField) this.ConventionalPersonality.Features.CnvPerFeaturesMixedVoteScanTxSteering_A38878);
    this.Field.Add("CnvPerLabtoolSmartPTTType_A9164", (IAcpField) this.ConventionalPersonality.Features.CnvPerLabtoolSmartPTTType_A9164);
    this.Field.Add("CnvPerLabtoolQuickKeyOverride_A8808", (IAcpField) this.ConventionalPersonality.Features.CnvPerLabtoolQuickKeyOverride_A8808);
    this.Field.Add("CnvPerFeaturesPoliteDVRSInboundPTTRequest_44913", (IAcpField) this.ConventionalPersonality.Features.CnvPerFeaturesPoliteDVRSInboundPTTRequest_44913);
    this.Field.Add("ConPerFeatureIncidentSignalingType_A41507", (IAcpField) this.ConventionalPersonality.Features.ConPerFeatureIncidentSignalingType_A41507);
    this.Field.Add("CnvPerTPSTPSUIEnable_A9400", (IAcpField) this.ConventionalPersonality.Features.CnvPerTPSTPSUIEnable_A9400);
    this.Field.Add("CnvPerFeaturesFiregroundRegistration_A33242", (IAcpField) this.ConventionalPersonality.Features.CnvPerFeaturesFiregroundRegistration_A33242);
    this.Field.Add("CnvPerFeaturesTxVoiceType_A9573", (IAcpField) this.ConventionalPersonality.Features.CnvPerFeaturesTxVoiceType_A9573);
    this.Field.Add("CnvPerPhonePhoneOperation_A8703", (IAcpField) this.ConventionalPersonality.Phone.CnvPerPhonePhoneOperation_A8703);
    this.Field.Add("CnvPerPhoneAccessTimingTable_A7387", (IAcpField) this.ConventionalPersonality.Phone.CnvPerPhoneAccessTimingTable_A7387);
    this.Field.Add("CnvPerPhoneAutoAccessCodeSelect_A7503", (IAcpField) this.ConventionalPersonality.Phone.CnvPerPhoneAutoAccessCodeSelect_A7503);
    this.Field.Add("CnvPerOneTouchButton_A19765", (IAcpField) this.CnvOneTouchInner.OneTouchInnerSection.CnvPerOneTouchButton_A19765);
    this.Field.Add("CnvPerOneTouchFeature_A19662", (IAcpField) this.CnvOneTouchInner.OneTouchInnerSection.CnvPerOneTouchFeature_A19662);
    this.Field.Add("CnvPerOneTouchIndex_A19663", (IAcpField) this.CnvOneTouchInner.OneTouchInnerSection.CnvPerOneTouchIndex_A19663);
    this.Field.Add("CnvPerSecureSecureVoiceSignalType_A9086", (IAcpField) this.ConventionalPersonality.Secure.CnvPerSecureSecureVoiceSignalType_A9086);
    this.Field.Add("CnvPerSecureXLTransmit_A9683", (IAcpField) this.ConventionalPersonality.Secure.CnvPerSecureXLTransmit_A9683);
    this.Field.Add("CnvPerSecureDESXLTxDefault_A7831", (IAcpField) this.ConventionalPersonality.Secure.CnvPerSecureDESXLTxDefault_A7831);
    this.Field.Add("CnvPerSecureSecureClearStrapping1_A9090", (IAcpField) this.ConventionalPersonality.Secure.CnvPerSecureSecureClearStrapping1_A9090);
    this.Field.Add("CnvPerSecureKeyStrapping_A8370", (IAcpField) this.ConventionalPersonality.Secure.CnvPerSecureKeyStrapping_A8370);
    this.Field.Add("CnvPerSecureKeySelection2_A8369", (IAcpField) this.ConventionalPersonality.Secure.CnvPerSecureKeySelection2_A8369);
    this.Field.Add("CnvPerIgnoreRxClearVoice_A41617", (IAcpField) this.ConventionalPersonality.Secure.CnvPerIgnoreRxClearVoice_A41617);
    this.Field.Add("CnvPerSecureSecureClearStrapping2_A9091", (IAcpField) this.ConventionalPersonality.Secure.CnvPerSecureSecureClearStrapping2_A9091);
    this.Field.Add("CnvPerSecureKeySelection1_A8368", (IAcpField) this.ConventionalPersonality.Secure.CnvPerSecureKeySelection1_A8368);
    this.Field.Add("CnvPerSecureIgnoreRxClearPacketData_A19310", (IAcpField) this.ConventionalPersonality.Secure.CnvPerSecureIgnoreRxClearPacketData_A19310);
    this.Field.Add("CnvPerSecureProperCodeDetect_A8762", (IAcpField) this.ConventionalPersonality.Secure.CnvPerSecureProperCodeDetect_A8762);
    this.Field.Add("CnvPerSecureOTARTx_A8675", (IAcpField) this.ConventionalPersonality.Secure.CnvPerSecureOTARTx_A8675);
    this.Field.Add("CnvPerSecureASTROOTAR_A7493", (IAcpField) this.ConventionalPersonality.Secure.CnvPerSecureASTROOTAR_A7493);
    this.Field.Add("CnvPerSecureKMFProfileIndex_A8381", (IAcpField) this.ConventionalPersonality.Secure.CnvPerSecureKMFProfileIndex_A8381);
    this.Field.Add("CnvPerSecureBroadbandASTROOTAR", (IAcpField) this.ConventionalPersonality.Secure.CnvPerSecureBroadbandASTROOTAR);
    this.Field.Add("CnvPerSecureEchoMuteTimems_A7919", (IAcpField) this.ConventionalPersonality.Secure.CnvPerSecureEchoMuteTimems_A7919);
    this.Field.Add("CnvPerSecureScanSelect_A9056", (IAcpField) this.ConventionalPersonality.Secure.CnvPerSecureScanSelect_A9056);
    this.Field.Add("CnvPerSecureScanHoldoffStrapping_A9050", (IAcpField) this.ConventionalPersonality.Secure.CnvPerSecureScanHoldoffStrapping_A9050);
    this.Field.Add("CnvPerSecureKeyID_A8361", (IAcpField) this.ConventionalPersonality.Secure.CnvPerSecureKeyID_A8361);
    this.Field.Add("CnvPerSecureXLDelayFollowingKeyID_A9680", (IAcpField) this.ConventionalPersonality.Secure.CnvPerSecureXLDelayFollowingKeyID_A9680);
    this.Field.Add("CnvPerAdvancedAdvancedRFAGC_A7408", (IAcpField) this.ConventionalPersonality.Advanced.CnvPerAdvancedAdvancedRFAGC_A7408);
    this.Field.Add("CnvPerAdvanceBroadbandProtection", (IAcpField) this.ConventionalPersonality.Advanced.CnvPerAdvanceBroadbandProtection);
    this.Field.Add("CnvPerAdvancedSecondLOSideInjection_A9063", (IAcpField) this.ConventionalPersonality.Advanced.CnvPerAdvancedSecondLOSideInjection_A9063);
    this.Field.Add("CnvPerAdvancedAnalogFlatAudio_A7443", (IAcpField) this.ConventionalPersonality.Advanced.CnvPerAdvancedAnalogFlatAudio_A7443);
    this.Field.Add("CnvPerAdvancedDisableHighPassFilter_A7864", (IAcpField) this.ConventionalPersonality.Advanced.CnvPerAdvancedDisableHighPassFilter_A7864);
    this.Field.Add("ConPerMDCRunMDCDemodulator_A8494", (IAcpField) this.ConventionalPersonality.Labtool.ConPerMDCRunMDCDemodulator_A8494);
    this.Field.Add("CnvPerLabtoolSyncMode_A19308", (IAcpField) this.ConventionalPersonality.Labtool.CnvPerLabtoolSyncMode_A19308);
    this.Field.Add("CnvPerLabtoolConventionalPersonalityOneTouchListItemID_A22630", (IAcpField) this.ConventionalPersonality.Labtool.CnvPerLabtoolConventionalPersonalityOneTouchListItemID_A22630);
    this.Field.Add("CnvPerLabtoolConventionalPersonalityChannelOptionsListItemID_A20474", (IAcpField) this.ConventionalPersonality.Labtool.CnvPerLabtoolConventionalPersonalityChannelOptionsListItemID_A20474);
    this.Field.Add("CnvPerFeatureRFModem_42485", (IAcpField) this.ConventionalPersonality.Features.CnvPerFeatureRFModem_42485);
    this.Field.Add("CnvPerFeaturesOTARadioAliasType_42784", (IAcpField) this.ConventionalPersonality.Features.CnvPerFeaturesOTARadioAliasType_42784);
    this.Field.Add("CnvPerFeaturesOTARadioAliasUpdateEnable_A43059", (IAcpField) this.ConventionalPersonality.Features.CnvPerFeaturesOTARadioAliasUpdateEnable_A43059);
    this.Field.Add("CnvPerASTROCallRemotemonitorfrequencyoption", (IAcpField) this.ConventionalPersonality.ASTROCall.CnvPerASTROCallRemotemonitorfrequencyoption);
  }

  private void AddConventionalSystem()
  {
    this.Field.Add("CnvSysGeneralKeyofConventionalSystem_A20482", (IAcpField) this.ConventionalSystem.General.CnvSysGeneralKeyofConventionalSystem_A20482);
    this.Field.Add("CnvSysGeneralSystemType_A13262", (IAcpField) this.ConventionalSystem.General.CnvSysGeneralSystemType_A13262);
    this.Field.Add("ConvConfigConvSystemFeatRSISys_A41838", (IAcpField) this.ConventionalSystem.General.ConvConfigConvSystemFeatRSISys_A41838);
    this.Field.Add("CnvSysGeneralSystemGroupNumber_A21960", (IAcpField) this.ConventionalSystem.General.CnvSysGeneralSystemGroupNumber_A21960);
    this.Field.Add("AstTlkgrpLstGeneralSystemWideTalkgroupHangTimesec_A9279", (IAcpField) this.ConventionalSystem.General.AstTlkgrpLstGeneralSystemWideTalkgroupHangTimesec_A9279);
    this.Field.Add("CnvSysGeneralSystemKeyPresent_A40120", (IAcpField) this.ConventionalSystem.General.CnvSysGeneralSystemKeyPresent_A40120);
    this.Field.Add("CnvSysGeneralHomeWACNID_A40121", (IAcpField) this.ConventionalSystem.General.CnvSysGeneralHomeWACNID_A40121);
    this.Field.Add("CnvSysGeneralSystemID_A40122", (IAcpField) this.ConventionalSystem.General.CnvSysGeneralSystemID_A40122);
    this.Field.Add("CnvSysGeneralIndividualID_A8287", (IAcpField) this.ConventionalSystem.General.CnvSysGeneralIndividualID_A8287);
    this.Field.Add("CnvSysGeneralPreambleLength_A8721", (IAcpField) this.ConventionalSystem.General.CnvSysGeneralPreambleLength_A8721);
    this.Field.Add("CnvSysGeneralMDCPrimaryID_A8744", (IAcpField) this.ConventionalSystem.General.CnvSysGeneralMDCPrimaryID_A8744);
    this.Field.Add("CnvSysGeneralSecondaryID_A9065", (IAcpField) this.ConventionalSystem.General.CnvSysGeneralSecondaryID_A9065);
    this.Field.Add("CnvSysGeneralVariableID_A9612", (IAcpField) this.ConventionalSystem.General.CnvSysGeneralVariableID_A9612);
    this.Field.Add("CnvSysGeneralAdditionalMDCPID_A41761", (IAcpField) this.ConventionalSystem.General.CnvSysGeneralAdditionalMDCPID_A41761);
    this.Field.Add("CnvSysGeneralPTTID_A8427", (IAcpField) this.ConventionalSystem.General.CnvSysGeneralPTTID_A8427);
    this.Field.Add("CnvSysGeneralSidetones_A8774", (IAcpField) this.ConventionalSystem.General.CnvSysGeneralSidetones_A8774);
    this.Field.Add("CnvSysGeneralSystemPretimems2_A9246", (IAcpField) this.ConventionalSystem.General.CnvSysGeneralSystemPretimems2_A9246);
    this.Field.Add("CnvSysGeneralAckPretimems_A7393", (IAcpField) this.ConventionalSystem.General.CnvSysGeneralAckPretimems_A7393);
    this.Field.Add("CnvSysGeneralInterPacketTimems_A8312", (IAcpField) this.ConventionalSystem.General.CnvSysGeneralInterPacketTimems_A8312);
    this.Field.Add("CnvSysGeneralLimitedPatiencesec_A8433", (IAcpField) this.ConventionalSystem.General.CnvSysGeneralLimitedPatiencesec_A8433);
    this.Field.Add("CnvSysGeneralEmergencyProfileSelection_A19421", (IAcpField) this.ConventionalSystem.General.CnvSysGeneralEmergencyProfileSelection_A19421);
    this.Field.Add("CnvSysGeneralDataProfileSelection_A13266", (IAcpField) this.ConventionalSystem.General.CnvSysGeneralDataProfileSelection_A13266);
    this.Field.Add("CnvSysGeneralRepeaterAccessPretimems_A8741", (IAcpField) this.ConventionalSystem.General.CnvSysGeneralRepeaterAccessPretimems_A8741);
    this.Field.Add("CnvSysLabtoolPreambleEnable_A19576", (IAcpField) this.ConventionalSystem.General.CnvSysLabtoolPreambleEnable_A19576);
    this.Field.Add("CnvSysGeneralPreambles_A8731", (IAcpField) this.ConventionalSystem.General.CnvSysGeneralPreambles_A8731);
    this.Field.Add("CnvSysDVRSTalkPermitTone_A40124", (IAcpField) this.ConventionalSystem.DVRS.CnvSysDVRSTalkPermitTone_A40124);
    this.Field.Add("CnvSysDVRSDVRSyncNACMatching_44811", (IAcpField) this.ConventionalSystem.DVRS.CnvSysDVRSDVRSyncNACMatching_44811);
    this.Field.Add("CnvSysDVRSEmerBlockInFS_A40143", (IAcpField) this.ConventionalSystem.DVRS.CnvSysDVRSEmerBlockInFS_A40143);
    this.Field.Add("CnvSysFeatureCallType_A40147", (IAcpField) this.ConventionalSystem.DVRS.CnvSysFeatureCallType_A40147);
    this.Field.Add("CnvSysDVRSPreferTalkaroundInNoComms_44810", (IAcpField) this.ConventionalSystem.DVRS.CnvSysDVRSPreferTalkaroundInNoComms_44810);
    this.Field.Add("CnvSysTalkaroundAudioModes_44812", (IAcpField) this.ConventionalSystem.DVRS.CnvSysTalkaroundAudioModes_44812);
    this.Field.Add("CnvSysDVRSTAAfterDVRSNoCommAttempts_A40125", (IAcpField) this.ConventionalSystem.DVRS.CnvSysDVRSTAAfterDVRSNoCommAttempts_A40125);
    this.Field.Add("CnvSysDVRSOutOfDVRSRangeTime_A40127", (IAcpField) this.ConventionalSystem.DVRS.CnvSysDVRSOutOfDVRSRangeTime_A40127);
    this.Field.Add("CnvSysDVRSEndOutOfRangeOnAnalogRx_A40143", (IAcpField) this.ConventionalSystem.DVRS.CnvSysDVRSEndOutOfRangeOnAnalogRx_A40143);
    this.Field.Add("CnvSysDVRSAttachRetryTime_A40141", (IAcpField) this.ConventionalSystem.DVRS.CnvSysDVRSAttachRetryTime_A40141);
    this.Field.Add("CnvSysDVRSAttachRetries_A40142", (IAcpField) this.ConventionalSystem.DVRS.CnvSysDVRSAttachRetries_A40142);
    this.Field.Add("CnvSysFeatureDynRegroupEn_A40146", (IAcpField) this.ConventionalSystem.DVRS.CnvSysFeatureDynRegroupEn_A40146);
    this.Field.Add("CnvSysFeatureDynRegroupZone_A40145", (IAcpField) this.ConventionalSystem.DVRS.CnvSysFeatureDynRegroupZone_A40145);
    this.Field.Add("CnvSysFeatureDynRegroupChannel_A40144", (IAcpField) this.ConventionalSystem.DVRS.CnvSysFeatureDynRegroupChannel_A40144);
    this.Field.Add("CnvSysDVRSIndCallMaxTargetRingTime_A40139", (IAcpField) this.ConventionalSystem.DVRS.CnvSysDVRSIndCallMaxTargetRingTime_A40139);
    this.Field.Add("CnvSysDVRSPrivateCallMaxInitRingTime_A40140", (IAcpField) this.ConventionalSystem.DVRS.CnvSysDVRSPrivateCallMaxInitRingTime_A40140);
    this.Field.Add("CnvSysDVRSForceUnmuteTime_A40138", (IAcpField) this.ConventionalSystem.DVRS.CnvSysDVRSForceUnmuteTime_A40138);
    this.Field.Add("CnvSysDVRSPTTWarningTime_A40131", (IAcpField) this.ConventionalSystem.DVRS.CnvSysDVRSPTTWarningTime_A40131);
    this.Field.Add("CnvSysDVRSBusyUpdateTime_A40130", (IAcpField) this.ConventionalSystem.DVRS.CnvSysDVRSBusyUpdateTime_A40130);
    this.Field.Add("CnvSysDVRSRespPendingTime_A40129", (IAcpField) this.ConventionalSystem.DVRS.CnvSysDVRSRespPendingTime_A40129);
    this.Field.Add("CnvSysFeaturesRadioInhibit_A8831", (IAcpField) this.ConventionalSystem.Features.CnvSysFeaturesRadioInhibit_A8831);
    this.Field.Add("CnvSysFeaturesRadioCheck_A8826", (IAcpField) this.ConventionalSystem.Features.CnvSysFeaturesRadioCheck_A8826);
    this.Field.Add("CnvSysFeaturesStatus_A9186", (IAcpField) this.ConventionalSystem.Features.CnvSysFeaturesStatus_A9186);
    this.Field.Add("CnvSysFeaturesStatusRequest_A9198", (IAcpField) this.ConventionalSystem.Features.CnvSysFeaturesStatusRequest_A9198);
    this.Field.Add("CnvSysFeaturesMessage_A8497", (IAcpField) this.ConventionalSystem.Features.CnvSysFeaturesMessage_A8497);
    this.Field.Add("CnvSysFeaturesDynamicIDEnable_A40100", (IAcpField) this.ConventionalSystem.Features.CnvSysFeaturesDynamicIDEnable_A40100);
    this.Field.Add("CnvSysFeaturesEmergencyAlarmRxIndicator_A7930", (IAcpField) this.ConventionalSystem.Features.CnvSysFeaturesEmergencyAlarmRxIndicator_A7930);
    this.Field.Add("CnvSysFeaturesEmergencyAckEn_A41546", (IAcpField) this.ConventionalSystem.Features.CnvSysFeaturesEmergencyAckEn_A41546);
    this.Field.Add("CnvSysDVRSPOP25Enable_A40126", (IAcpField) this.ConventionalSystem.Features.CnvSysDVRSPOP25Enable_A40126);
    this.Field.Add("CnvSysFeaturesCAIDataRegistration_A7585", (IAcpField) this.ConventionalSystem.Features.CnvSysFeaturesCAIDataRegistration_A7585);
    this.Field.Add("DataProfFeaturesTextMessagingService_A9372", (IAcpField) this.ConventionalSystem.Features.DataProfFeaturesTextMessagingService_A9372);
    this.Field.Add("CnvSysFeaturesSelectCallInCallReset_A9102", (IAcpField) this.ConventionalSystem.Features.CnvSysFeaturesSelectCallInCallReset_A9102);
    this.Field.Add("CnvSysFeaturesAutoResetTimesec_A7511", (IAcpField) this.ConventionalSystem.Features.CnvSysFeaturesAutoResetTimesec_A7511);
    this.Field.Add("CnvSysFeaturesRemoteRadioMode_A8935", (IAcpField) this.ConventionalSystem.Features.CnvSysFeaturesRemoteRadioMode_A8935);
    this.Field.Add("CnvSysFeaturesTxBaseTimeSec_A9513", (IAcpField) this.ConventionalSystem.Features.CnvSysFeaturesTxBaseTimeSec_A9513);
    this.Field.Add("CnvSysFeaturesExtendedDispatchEn_A37220", (IAcpField) this.ConventionalSystem.Features.CnvSysFeaturesExtendedDispatchEn_A37220);
    this.Field.Add("CnvSysFeaturesDataOperatedSquelchDOS_A7796", (IAcpField) this.ConventionalSystem.Features.CnvSysFeaturesDataOperatedSquelchDOS_A7796);
    this.Field.Add("CnvSysFeaturesDOSOperation_A7891", (IAcpField) this.ConventionalSystem.Features.CnvSysFeaturesDOSOperation_A7891);
    this.Field.Add("CnvSysFeaturesDOSCoastTimems_A7890", (IAcpField) this.ConventionalSystem.Features.CnvSysFeaturesDOSCoastTimems_A7890);
    this.Field.Add("CnvSysSecureKMFProfIndex_A40132", (IAcpField) this.ConventionalSystem.Secure.CnvSysSecureKMFProfIndex_A40132);
    this.Field.Add("CnvSysSecurePatchKeySel_A40136", (IAcpField) this.ConventionalSystem.Secure.CnvSysSecurePatchKeySel_A40136);
    this.Field.Add("CnvSysSecureFSKeySel_A40134", (IAcpField) this.ConventionalSystem.Secure.CnvSysSecureFSKeySel_A40134);
    this.Field.Add("CnvSysSecurePrivateCallKeySel_A40137", (IAcpField) this.ConventionalSystem.Secure.CnvSysSecurePrivateCallKeySel_A40137);
    this.Field.Add("CnvSysSecureInterConnectKeySel_A40135", (IAcpField) this.ConventionalSystem.Secure.CnvSysSecureInterConnectKeySel_A40135);
    this.Field.Add("CnvSysSecureDynTGKeySel_A40133", (IAcpField) this.ConventionalSystem.Secure.CnvSysSecureDynTGKeySel_A40133);
    this.Field.Add("CnvSysLabtoolRACSidetone_A8820", (IAcpField) this.ConventionalSystem.Labtool.CnvSysLabtoolRACSidetone_A8820);
    this.Field.Add("CnvSysLabtoolPreambles_A8730", (IAcpField) this.ConventionalSystem.Labtool.CnvSysLabtoolPreambles_A8730);
    this.Field.Add("CnvSysLabtoolCPTotalPretimeMDC_A7789", (IAcpField) this.ConventionalSystem.Labtool.CnvSysLabtoolCPTotalPretimeMDC_A7789);
    this.Field.Add("CnvSysLabtoolAckPreambles_A7392", (IAcpField) this.ConventionalSystem.Labtool.CnvSysLabtoolAckPreambles_A7392);
    this.Field.Add("CnvSysLabtoolInterPacketPreambles_A8311", (IAcpField) this.ConventionalSystem.Labtool.CnvSysLabtoolInterPacketPreambles_A8311);
    this.Field.Add("ConSysCPTotalPretime_A20162", (IAcpField) this.ConventionalSystem.Labtool.ConSysCPTotalPretime_A20162);
    this.Field.Add("CnvSysLabtoolRetryConstrant_A8950", (IAcpField) this.ConventionalSystem.Labtool.CnvSysLabtoolRetryConstrant_A8950);
    this.Field.Add("CnvSysFeaturesSendLocationToPeer_42427", (IAcpField) this.ConventionalSystem.Features.CnvSysFeaturesSendLocationToPeer_42427);
    this.Field.Add("CnvSysFeaturesGroupTMSEable_42809", (IAcpField) this.ConventionalSystem.Features.CnvSysFeaturesGroupTMSEable_42809);
    this.Field.Add("CnvSysFeaturesPASelection_A42880", (IAcpField) this.ConventionalSystem.Features.CnvSysFeaturesPASelection_A42880);
  }

  private void AddMissionCriticalGeofence()
  {
    this.Field.Add("GeofenceAliasName_42867", (IAcpField) this.MissionCriticalGeofence.General.GeofenceAliasName_42867);
    this.Field.Add("McGeofencePriority_42879", (IAcpField) this.MissionCriticalGeofence.General.McGeofencePriority_42879);
    this.Field.Add("McGeofenceRadiusInMeters_42890", (IAcpField) this.MissionCriticalGeofence.General.McGeofenceRadiusInMeters_42890);
    this.Field.Add("McGeofenceEntryAction_42887", (IAcpField) this.MissionCriticalGeofence.General.McGeofenceEntryAction_42887);
    this.Field.Add("McGeofenceExitAction_42888", (IAcpField) this.MissionCriticalGeofence.General.McGeofenceExitAction_42888);
  }

  private void AddVirtualPartnerAlert()
  {
    this.Field.Add("VirtualPartnerAlertListName_43679", (IAcpField) this.VirtualPartnerAlert.General.VirtualPartnerAlertListName_43679);
  }

  private void AddConventionalWide()
  {
    this.Field.Add("CnvWideGeneralMonitorType_A8544", (IAcpField) this.ConventionalWide.General.CnvWideGeneralMonitorType_A8544);
    this.Field.Add("CnvWideGeneralDirectFrequency_A7860", (IAcpField) this.ConventionalWide.General.CnvWideGeneralDirectFrequency_A7860);
    this.Field.Add("CnvWideGeneralHUBDefeatsPL_A8215", (IAcpField) this.ConventionalWide.General.CnvWideGeneralHUBDefeatsPL_A8215);
    this.Field.Add("CnvWideGeneralSquelchPerPersonality_A19313", (IAcpField) this.ConventionalWide.General.CnvWideGeneralSquelchPerPersonality_A19313);
    this.Field.Add("CnvWideGeneralLatchEnableTone_A8422", (IAcpField) this.ConventionalWide.General.CnvWideGeneralLatchEnableTone_A8422);
    this.Field.Add("CnvWideGeneralLatchEnableTime_A8421", (IAcpField) this.ConventionalWide.General.CnvWideGeneralLatchEnableTime_A8421);
    this.Field.Add("CnvWideGeneralMplRecallMode_A41698", (IAcpField) this.ConventionalWide.General.CnvWideGeneralMplRecallMode_A41698);
    this.Field.Add("CnvWideFeaturesSmartPTTQuickKeyTimerms_A9162", (IAcpField) this.ConventionalWide.Features.CnvWideFeaturesSmartPTTQuickKeyTimerms_A9162);
    this.Field.Add("CnvWideFeaturesSmartPTTRetryTimerms_A9163", (IAcpField) this.ConventionalWide.Features.CnvWideFeaturesSmartPTTRetryTimerms_A9163);
    this.Field.Add("CnvWideFeaturesSoftIDFeature_A9168", (IAcpField) this.ConventionalWide.Features.CnvWideFeaturesSoftIDFeature_A9168);
    this.Field.Add("ConventionlWideFeaturesStatusNumOfAttempts_42156", (IAcpField) this.ConventionalWide.Features.ConventionlWideFeaturesStatusNumOfAttempts_42156);
    this.Field.Add("CnvWideFeaturesRadioInhibitRevertEnable", (IAcpField) this.ConventionalWide.Features.CnvWideFeaturesRadioInhibitRevertEnable);
    this.Field.Add("CnvWideFeaturesRadioInhibitRevertZone", (IAcpField) this.ConventionalWide.Features.CnvWideFeaturesRadioInhibitRevertZone);
    this.Field.Add("CnvWideFeaturesRadioInhibitRevertChannel", (IAcpField) this.ConventionalWide.Features.CnvWideFeaturesRadioInhibitRevertChannel);
    this.Field.Add("CnvWideASTRODataMaxTxAttempts_A8474", (IAcpField) this.ConventionalWide.ASTROData.CnvWideASTRODataMaxTxAttempts_A8474);
    this.Field.Add("CnvWideASTRODataResponseTimerms_A8948", (IAcpField) this.ConventionalWide.ASTROData.CnvWideASTRODataResponseTimerms_A8948);
    this.Field.Add("CnvWideASTRODataMinResponseTimerms_A8514", (IAcpField) this.ConventionalWide.ASTROData.CnvWideASTRODataMinResponseTimerms_A8514);
    this.Field.Add("CnvWideASTRODataMaxPacketSizebytes_A8471", (IAcpField) this.ConventionalWide.ASTROData.CnvWideASTRODataMaxPacketSizebytes_A8471);
    this.Field.Add("CnvWideASTRODataFrameSyncSeekPeriodms_A8145", (IAcpField) this.ConventionalWide.ASTROData.CnvWideASTRODataFrameSyncSeekPeriodms_A8145);
    this.Field.Add("CnvWideASTRODataTxShortRandomRangeMs_A9565", (IAcpField) this.ConventionalWide.ASTROData.CnvWideASTRODataTxShortRandomRangeMs_A9565);
    this.Field.Add("CnvWideASTRODataTxLongRandomRangeMs_A9546", (IAcpField) this.ConventionalWide.ASTROData.CnvWideASTRODataTxLongRandomRangeMs_A9546);
    this.Field.Add("CnvWideASTRODataTxRespRandomRangeMs_A9563", (IAcpField) this.ConventionalWide.ASTROData.CnvWideASTRODataTxRespRandomRangeMs_A9563);
    this.Field.Add("CnvWideASTRODataTxLimitedPatienceSec_A9544", (IAcpField) this.ConventionalWide.ASTROData.CnvWideASTRODataTxLimitedPatienceSec_A9544);
    this.Field.Add("CnvWideASTRODataARPCacheDepth_A7463", (IAcpField) this.ConventionalWide.ASTROData.CnvWideASTRODataARPCacheDepth_A7463);
    this.Field.Add("CnvWideASTRODataARPCacheTimehrs_A7464", (IAcpField) this.ConventionalWide.ASTROData.CnvWideASTRODataARPCacheTimehrs_A7464);
    this.Field.Add("CnvWideConventionalCustomerID_41558", (IAcpField) this.ConventionalWide.ASTROData.CnvWideConventionalCustomerID_41558);
    this.Field.Add("CnvWideASTROGroupIDGroupID1_A7480", (IAcpField) this.ASTROGroupIDListInner.ASTROGroupIDListInnerSection.CnvWideASTROGroupIDGroupID1_A7480);
    this.Field.Add("CnvWideASTROOTACPosition_A19768", (IAcpField) this.OTACInner.OTACInnerSection.CnvWideASTROOTACPosition_A19768);
    this.Field.Add("CnvWideASTROOTACOTACSFeature_A8667", (IAcpField) this.ConventionalWide.ASTROOTAC.CnvWideASTROOTACOTACSFeature_A8667);
    this.Field.Add("CnvWideASTROOTACOTACRFeature_A8662", (IAcpField) this.ConventionalWide.ASTROOTAC.CnvWideASTROOTACOTACRFeature_A8662);
    this.Field.Add("CnvWideASTROOTACZone_A8645", (IAcpField) this.OTACInner.OTACInnerSection.CnvWideASTROOTACZone_A8645);
    this.Field.Add("CnvWideASTROOTACChannel_A8629", (IAcpField) this.OTACInner.OTACInnerSection.CnvWideASTROOTACChannel_A8629);
    this.Field.Add("CnvWideLabtoolUserSelectableSquelch_A9610", (IAcpField) this.ConventionalWide.Labtool.CnvWideLabtoolUserSelectableSquelch_A9610);
    this.Field.Add("CnvWideLabtoolManufacturerID_A19439", (IAcpField) this.ConventionalWide.Labtool.CnvWideLabtoolManufacturerID_A19439);
    this.Field.Add("CnvWideLabtoolExpandedMDCID_A41790", (IAcpField) this.ConventionalWide.Labtool.CnvWideLabtoolExpandedMDCID_A41790);
  }

  private void AddDataWide()
  {
    this.Field.Add("DataWideGeneralSNMPTraps_A9166", (IAcpField) this.DataWide.General.DataWideGeneralSNMPTraps_A9166);
    this.Field.Add("LabtoolContextRenewalTimerMin", (IAcpField) this.DataWide.LabtoolDATA_CFG.LabtoolContextRenewalTimerMin);
    this.Field.Add("DataWideGeneralContextDeactivationAlertTone_A7715", (IAcpField) this.DataWide.General.DataWideGeneralContextDeactivationAlertTone_A7715);
    this.Field.Add("DataWideLabtoolDATA_CFGPacketDataActivateWaitTimerSec_A8686", (IAcpField) this.DataWide.LabtoolDATA_CFG.DataWideLabtoolDATA_CFGPacketDataActivateWaitTimerSec_A8686);
    this.Field.Add("DataWideGeneralICMPEcho_A8219", (IAcpField) this.DataWide.General.DataWideGeneralICMPEcho_A8219);
    this.Field.Add("DataWideGeneralSubscriberIPAddress1_A9222", (IAcpField) this.DataWide.General.DataWideGeneralSubscriberIPAddress1_A9222);
    this.Field.Add("DataWideGeneralPeerIPAddress1_A8524", (IAcpField) this.DataWide.General.DataWideGeneralPeerIPAddress1_A8524);
    this.Field.Add("DataWideGeneralPeerIPAddressAssignmentType1_A22376", (IAcpField) this.DataWide.General.DataWideGeneralPeerIPAddressAssignmentType1_A22376);
    this.Field.Add("DataWideGeneralBTDUNSUIPAddress_A41120", (IAcpField) this.DataWide.General.DataWideGeneralBTDUNSUIPAddress_A41120);
    this.Field.Add("DataWideGeneralBTDUNPeerIPAddress_A41123", (IAcpField) this.DataWide.General.DataWideGeneralBTDUNPeerIPAddress_A41123);
    this.Field.Add("DataWideGeneralBTDUNPeerIPAddressAssignmentType_A41124", (IAcpField) this.DataWide.General.DataWideGeneralBTDUNPeerIPAddressAssignmentType_A41124);
    this.Field.Add("DataWideGeneralDeleteMessagesOnSessionEnd_41308", (IAcpField) this.DataWide.General.DataWideGeneralDeleteMessagesOnSessionEnd_41308);
    this.Field.Add("DataWideGeneralMobileSubIPAddress_A41819", (IAcpField) this.DataWide.General.DataWideGeneralMobileSubIPAddress_A41819);
    this.Field.Add("DataWideGeneralDVRIPAddress_A41818", (IAcpField) this.DataWide.General.DataWideGeneralDVRIPAddress_A41818);
    this.Field.Add("DataWideGeneralPeerIPAddressAssignmentType2_A22377", (IAcpField) this.DataWide.General.DataWideGeneralPeerIPAddressAssignmentType2_A22377);
    this.Field.Add("DataWideGeneralInternalRadioSubnet_A42073", (IAcpField) this.DataWide.General.DataWideGeneralInternalRadioSubnet_A42073);
    this.Field.Add("DataWideLabtoolDATA_CFGOTAPDefaultInactivityTimer_A8668", (IAcpField) this.DataWide.LabtoolDATA_CFG.DataWideLabtoolDATA_CFGOTAPDefaultInactivityTimer_A8668);
    this.Field.Add("LabtoolDefaultReadyTimerSec", (IAcpField) this.DataWide.LabtoolDATA_CFG.LabtoolDefaultReadyTimerSec);
    this.Field.Add("LabtoolContextActivationHoldoffTimerSec", (IAcpField) this.DataWide.LabtoolDATA_CFG.LabtoolContextActivationHoldoffTimerSec);
    this.Field.Add("DataWideDVRSActWaitTime_A40128", (IAcpField) this.DataWide.LabtoolDATA_CFG.DataWideDVRSActWaitTime_A40128);
    this.Field.Add("RandomAccessAckTimerMsec_42016", (IAcpField) this.DataWide.LabtoolDATA_CFG.RandomAccessAckTimerMsec_42016);
    this.Field.Add("DataWidePOP25OTAPRejectEnable_A8671", (IAcpField) this.DataWide.POP25.DataWidePOP25OTAPRejectEnable_A8671);
    this.Field.Add("DataWidePOP25OTAPIndications_A8670", (IAcpField) this.DataWide.POP25.DataWidePOP25OTAPIndications_A8670);
    this.Field.Add("DataWidePOP25AutoResetEnable_A37221", (IAcpField) this.DataWide.POP25.DataWidePOP25AutoResetEnable_A37221);
    this.Field.Add("DataWideLTELTECheckbackTime_A42205", (IAcpField) this.DataWide.LTE.DataWideLTELTECheckbackTime_A42205);
    this.Field.Add("DataWideLTEOutOfRangeThresholdTime_A42206", (IAcpField) this.DataWide.LTE.DataWideLTEOutOfRangeThresholdTime_A42206);
    this.Field.Add("DataWideLTEOffMaxDetachTime_A42207", (IAcpField) this.DataWide.LTE.DataWideLTEOffMaxDetachTime_A42207);
    this.Field.Add("DataWideLTEModeChangeMaxDetachTime_A42208", (IAcpField) this.DataWide.LTE.DataWideLTEModeChangeMaxDetachTime_A42208);
    this.Field.Add("DataWideLTE", (IAcpField) this.DataWide.LTE.DataWideLTEOperation_A42215);
    this.Field.Add("DataWideDataOnRoaming", (IAcpField) this.DataWide.LTE.DataWideDataOnRoaming_A42216);
    if (this.NATListInner != null)
    {
      this.Field.Add("DataWideNATListLANPort_A8385", (IAcpField) this.NATListInner.NATListInnerSection.DataWideNATListLANPort_A8385);
      this.Field.Add("DataWideNATListStaticNATIPAddress_A9181", (IAcpField) this.NATListInner.NATListInnerSection.DataWideNATListStaticNATIPAddress_A9181);
      this.Field.Add("DataWideNATListWANPort_A9677", (IAcpField) this.NATListInner.NATListInnerSection.DataWideNATListWANPort_A9677);
    }
    this.Field.Add("DataWideLTEHWEnable", (IAcpField) this.DataWide.LTE.DataWideLTEHWEnable);
    this.Field.Add("DataWideWIFIEnable_42506", (IAcpField) this.DataWide.WIFI.DataWideWIFIEnable_42506);
    this.Field.Add("DataWideWiFiNetworkPriority_42512", (IAcpField) this.ConfiguredNetworksListInner.ConfiguredNetworksListInnerSection.DataWideWiFiNetworkPriority_42512);
    this.Field.Add("DataWideWiFiNetworkSSID_42519", (IAcpField) this.ConfiguredNetworksListInner.ConfiguredNetworksListInnerSection.DataWideWiFiNetworkSSID_42519);
    this.Field.Add("DataWideWiFiNetworkSecurityType_42516", (IAcpField) this.ConfiguredNetworksListInner.ConfiguredNetworksListInnerSection.DataWideWiFiNetworkSecurityType_42516);
    this.Field.Add("DataWideWiFiNetworkEncryptedNetworkPassword_42517", (IAcpField) this.ConfiguredNetworksListInner.ConfiguredNetworksListInnerSection.DataWideWiFiNetworkEncryptedNetworkPassword_42517);
    this.Field.Add("DataWideWIFINetworkHidden", (IAcpField) this.ConfiguredNetworksListInner.ConfiguredNetworksListInnerSection.DataWideWIFINetworkHidden);
    this.Field.Add("DataWideDataUserListDataUserInformation_A7800", (IAcpField) this.DataUserListInner.DataUserListInnerSection.DataWideDataUserListDataUserInformation_A7800);
    this.Field.Add("DataWideQuickTextMessageListQuickTextMessage_A8810", (IAcpField) this.QuickTextMessageListInner.QuickTextMessageListInnerSection.DataWideQuickTextMessageListQuickTextMessage_A8810);
    this.Field.Add("DataConfigDataWideMaxNumofNonTCPIPHCContexts_A36192", (IAcpField) this.DataWide.DataProtocolConfiguration.DataConfigDataWideMaxNumofNonTCPIPHCContexts_A36192);
    this.Field.Add("DataConfigDataWideMaxNumofTCPIPHCContexts_A36194", (IAcpField) this.DataWide.DataProtocolConfiguration.DataConfigDataWideMaxNumofTCPIPHCContexts_A36194);
    this.Field.Add("DataConfigDataWideMaxNumOfCompreHeadersBetweenFullHeaders_A36205", (IAcpField) this.DataWide.DataProtocolConfiguration.DataConfigDataWideMaxNumOfCompreHeadersBetweenFullHeaders_A36205);
    this.Field.Add("DataConfigDataWideMaxHeaderSizeAllowedForCompression_A36206", (IAcpField) this.DataWide.DataProtocolConfiguration.DataConfigDataWideMaxHeaderSizeAllowedForCompression_A36206);
    this.Field.Add("DataConfigDataWideMaxTimeBetweenFullHeaders_A36200", (IAcpField) this.DataWide.DataProtocolConfiguration.DataConfigDataWideMaxTimeBetweenFullHeaders_A36200);
    this.Field.Add("DataCfgDataWideMaxSetupTimeAllowedforCCA_A36193", (IAcpField) this.DataWide.DataProtocolConfiguration.DataCfgDataWideMaxSetupTimeAllowedforCCA_A36193);
    this.Field.Add("DataCfgDataWideTimeSourceVar_A36196", (IAcpField) this.DataWide.DataProtocolConfiguration.DataCfgDataWideTimeSourceVar_A36196);
    this.Field.Add("DataConfDataWidePortConAuthenticationUDPPort_A37608", (IAcpField) this.DataWide.PortConfiguration.DataConfDataWidePortConAuthenticationUDPPort_A37608);
    this.Field.Add("DataWideP25LocationReportingUDPPort_42413", (IAcpField) this.DataWide.PortConfiguration.DataWideP25LocationReportingUDPPort_42413);
    this.Field.Add("SensorMeasurementReportingUDPPort_A43022", (IAcpField) this.DataWide.PortConfiguration.SensorMeasurementReportingUDPPort_A43022);
    this.Field.Add("SensorMeasurementReporting_A43021", (IAcpField) this.DataWide.General.SensorMeasurementReporting_A43021);
    this.Field.Add("ModemConnectionType_43350", (IAcpField) this.DataWide.ExternalDataModem.ModemConnectionType_43350);
    if (this.DataModemTableInner != null)
    {
      this.Field.Add("DataWideExternalDataModemType_43362", (IAcpField) this.DataModemTableInner.DataModemTableInnerSection.DataWideExternalDataModemType_43362);
      this.Field.Add("DataWideExternalDataModemSecurityType_43360", (IAcpField) this.DataModemTableInner.DataModemTableInnerSection.DataWideExternalDataModemSecurityType_43360);
      this.Field.Add("DataWideEncryptedNetworkPassword_43361", (IAcpField) this.DataModemTableInner.DataModemTableInnerSection.DataWideEncryptedNetworkPassword_43361);
      this.Field.Add("DataWideEncryptedModemPassword_43361", (IAcpField) this.DataModemTableInner.DataModemTableInnerSection.DataWideEncryptedModemPassword_43361);
      this.Field.Add("DataWideExternalDataModemNetworkSsid_43358", (IAcpField) this.DataModemTableInner.DataModemTableInnerSection.DataWideExternalDataModemNetworkSsid_43358);
      this.Field.Add("dataWideExternalDataModemHiddenNetwork_44814", (IAcpField) this.DataModemTableInner.DataModemTableInnerSection.DataWideExternalDataModemHiddenNetwork_44814);
      this.Field.Add("DataWideMG90WirelessVPNFriendlyName_43785", (IAcpField) this.DataModemTableInner.DataModemTableInnerSection.DataWideMG90WirelessVPNFriendlyName_43785);
      this.Field.Add("DataWideMG90WirelessLTEFriendlyName_43786", (IAcpField) this.DataModemTableInner.DataModemTableInnerSection.DataWideMG90WirelessLTEFriendlyName_43786);
      this.Field.Add("DataWideMG90WirelessSatelliteFriendlyName_43787", (IAcpField) this.DataModemTableInner.DataModemTableInnerSection.DataWideMG90WirelessSatelliteFriendlyName_43787);
    }
    this.Field.Add("DataWideExternalDataModemType_42843", (IAcpField) this.DataWide.ExternalDataModem.DataWideExternalDataModemType_42843);
    this.Field.Add("DataWideExternalDataModemMG90SatelliteEnabled_43777", (IAcpField) this.DataWide.ExternalDataModem.DataWideExternalDataModemMG90SatelliteEnabled_43777);
    this.Field.Add("DataWideExternalDataModemVPNFriendlyName_43774", (IAcpField) this.DataWide.ExternalDataModem.DataWideExternalDataModemVPNFriendlyName_43774);
    this.Field.Add("DataWideExternalDataModemLTEFriendlyName_43775", (IAcpField) this.DataWide.ExternalDataModem.DataWideExternalDataModemLTEFriendlyName_43775);
    this.Field.Add("DataWideExternalDataModemMG90SatelliteFriendlyName_43776", (IAcpField) this.DataWide.ExternalDataModem.DataWideExternalDataModemMG90SatelliteFriendlyName_43776);
    this.Field.Add("DataWideWebBrowserEnableFld", (IAcpField) this.DataWide.WebBrowser.DataWideWebBrowserEnableFld);
    if (this.BookmarkQuickAccessListInner != null)
      this.Field.Add("BookmarkSelection", (IAcpField) this.BookmarkQuickAccessListInner.BookmarkQuickAccessListInnerSection.BookmarkSelection);
    if (this.URLTableInner == null)
      return;
    this.Field.Add("BookmarkName", (IAcpField) this.URLTableInner.URLTableInnerSection.BookmarkName);
    this.Field.Add("BookmarkURL", (IAcpField) this.URLTableInner.URLTableInnerSection.BookmarkURL);
  }

  private void AddVoiceAnnouncementWide()
  {
    this.Field.Add("ScanOnAnnouncementID_A22250", (IAcpField) this.VoiceAnnouncementWide.General.ScanOnAnnouncementID_A22250);
    this.Field.Add("RadErgoScanOnAnnouncementVoiceCommand", (IAcpField) this.VoiceAnnouncementWide.General.RadErgoScanOnAnnouncementVoiceCommand);
  }

  private void AddDEK()
  {
    this.Field.Add("DEKNumberofDEKBoxes_A8579", (IAcpField) this.DEK.General.DEKNumberofDEKBoxes_A8579);
    this.Field.Add("DEKVIPName_A22574", (IAcpField) this.DEKVIPInner.DEKVIPInnerSection.DEKVIPName_A22574);
    this.Field.Add("DEKVIPInputBCO_A21337", (IAcpField) this.DEKVIPInner.DEKVIPInnerSection.DEKVIPInputBCO_A21337);
    this.Field.Add("DEKVIPInputFeature_A21338", (IAcpField) this.DEKVIPInner.DEKVIPInnerSection.DEKVIPInputFeature_A21338);
    this.Field.Add("DEKVIPOutputBCO_A21347", (IAcpField) this.DEKVIPInner.DEKVIPInnerSection.DEKVIPOutputBCO_A21347);
    this.Field.Add("DEKVIPOutputFeature_A21346", (IAcpField) this.DEKVIPInner.DEKVIPInnerSection.DEKVIPOutputFeature_A21346);
    this.Field.Add("DEKVIPButtonShortPressTime", (IAcpField) this.DEKVIPInner.DEKVIPInnerSection.DEKVIPButtonShortPressTime);
    this.Field.Add("DEKVIPButtonLongPressTime", (IAcpField) this.DEKVIPInner.DEKVIPInnerSection.DEKVIPButtonLongPressTime);
    this.Field.Add("DEKVIPKey_A22573", (IAcpField) this.DEKVIPInner.DEKVIPInnerSection.DEKVIPKey_A22573);
    this.Field.Add("DEKDirectMessageBCO_A8506", (IAcpField) this.DirectMessageListInner.DirectMessageListInnerSection.DEKDirectMessageBCO_A8506);
    this.Field.Add("DEKDirectMessageBCOKey_A21292", (IAcpField) this.DirectMessageListInner.DirectMessageListInnerSection.DEKDirectMessageBCOKey_A21292);
    if (!FieldAccessor.IsCpsApiTest)
    {
      this.Field.Add("DEKDirectModeZone_A8538", (IAcpField) this.DirectModeBCOListInner.DirectModeBCOListInnerSection.DEKDirectModeZone_A8538);
      this.Field.Add("DEKDirectModeBCO_A8534", (IAcpField) this.DirectModeBCOListInner.DirectModeBCOListInnerSection.DEKDirectModeBCO_A8534);
      this.Field.Add("DEKDirectModeChannel_A8535", (IAcpField) this.DirectModeBCOListInner.DirectModeBCOListInnerSection.DEKDirectModeChannel_A8535);
    }
    if (!FieldAccessor.IsCpsApiTest || UtilityMack.IsMobile())
    {
      this.Field.Add("DEKButtonName_A22568", (IAcpField) this.DEKButtonInner.DEKButtonInnerSection.DEKButtonName_A22568);
      this.Field.Add("DEKButtonBCO_A21352", (IAcpField) this.DEKButtonInner.DEKButtonInnerSection.DEKButtonBCO_A21352);
      this.Field.Add("DEKButtonFeature_A21353", (IAcpField) this.DEKButtonInner.DEKButtonInnerSection.DEKButtonFeature_A21353);
      this.Field.Add("DEKButtonIndex_A22570", (IAcpField) this.DEKButtonInner.DEKButtonInnerSection.DEKButtonIndex_A22570);
      this.Field.Add("DEKButtonShortPressTime", (IAcpField) this.DEKButtonInner.DEKButtonInnerSection.DEKButtonShortPressTime);
      this.Field.Add("DEKButtonLongPressTime", (IAcpField) this.DEKButtonInner.DEKButtonInnerSection.DEKButtonLongPressTime);
      this.Field.Add("DEKZone_A22566", (IAcpField) this.DEKButtonInner.DEKButtonInnerSection.DEKZone_A22566);
      this.Field.Add("DEKChannel_A22565", (IAcpField) this.DEKButtonInner.DEKButtonInnerSection.DEKChannel_A22565);
      this.Field.Add("DEKButtonKey_A22569", (IAcpField) this.DEKButtonInner.DEKButtonInnerSection.DEKButtonKey_A22569);
      this.Field.Add("DEKDirectModeKey_A21200", (IAcpField) this.DirectModeBCOListInner.DirectModeBCOListInnerSection.DEKDirectModeKey_A21200);
    }
    this.Field.Add("DEKDirectStatusBCO_A9196", (IAcpField) this.DirectStatusBCOListInner.DirectStatusBCOListInnerSection.DEKDirectStatusBCO_A9196);
    this.Field.Add("DEKDirectStatusBCOKey_A21270", (IAcpField) this.DirectStatusBCOListInner.DirectStatusBCOListInnerSection.DEKDirectStatusBCOKey_A21270);
  }

  private void AddDisplay()
  {
    this.Field.Add("DispMenuGeneralZoneTextSize_A8167", (IAcpField) this.DisplayAndMenu.General.DispMenuGeneralZoneTextSize_A8167);
    this.Field.Add("DispMenuGeneralChannelTextSize_A7663", (IAcpField) this.DisplayAndMenu.General.DispMenuGeneralChannelTextSize_A7663);
    this.Field.Add("DispMenuGeneralTopZoneTextSize_A19769", (IAcpField) this.DisplayAndMenu.General.DispMenuGeneralTopZoneTextSize_A19769);
    this.Field.Add("DispMenuTopChannelTextSize_A19504", (IAcpField) this.DisplayAndMenu.General.DispMenuTopChannelTextSize_A19504);
    this.Field.Add("FlipDisplayState_A19471", (IAcpField) this.DisplayAndMenu.General.FlipDisplayState_A19471);
    this.Field.Add("DRSMFlipDisplayState_A24778", (IAcpField) this.DisplayAndMenu.General.DRSMFlipDisplayState_A24778);
    this.Field.Add("DispMenuGeneralSlowScrollRatems_A9161", (IAcpField) this.DisplayAndMenu.General.DispMenuGeneralSlowScrollRatems_A9161);
    this.Field.Add("DispMenuGeneralFastScrollRatems_A8014", (IAcpField) this.DisplayAndMenu.General.DispMenuGeneralFastScrollRatems_A8014);
    this.Field.Add("DispMenuGeneralSlowScrollCount_A9160", (IAcpField) this.DisplayAndMenu.General.DispMenuGeneralSlowScrollCount_A9160);
    this.Field.Add("DispMenuGeneralOutofRangeIndicator_A8678", (IAcpField) this.DisplayAndMenu.General.DispMenuGeneralOutofRangeIndicator_A8678);
    this.Field.Add("DispMenuGeneralImbalancedCoverageIndicator_A8240", (IAcpField) this.DisplayAndMenu.General.DispMenuGeneralImbalancedCoverageIndicator_A8240);
    this.Field.Add("DispMenuGeneralSiteTrunkingIndicator_A7426", (IAcpField) this.DisplayAndMenu.General.DispMenuGeneralSiteTrunkingIndicator_A7426);
    this.Field.Add("RadErgoWideStealthSaveDayNightMode_A36492", (IAcpField) this.DisplayAndMenu.General.RadErgoWideStealthSaveDayNightMode_A36492);
    this.Field.Add("RadErgoDisGeneralSysRegIndicator_A37603", (IAcpField) this.DisplayAndMenu.General.RadErgoDisGeneralSysRegIndicator_A37603);
    this.Field.Add("RadErgoCfgDisplayGeneralLocalOnlyIndicator_A40160", (IAcpField) this.DisplayAndMenu.General.RadErgoCfgDisplayGeneralLocalOnlyIndicator_A40160);
    this.Field.Add("DispMenuAdvancedLanguageSelection_A8386", (IAcpField) this.DisplayAndMenu.Advanced.DispMenuAdvancedLanguageSelection_A8386);
    this.Field.Add("AdvancedAutoLight", (IAcpField) this.DisplayAndMenu.Advanced.AdvancedAutoLight);
    this.Field.Add("RadWideAdvancedBacklightWhileinVA_A7536", (IAcpField) this.DisplayAndMenu.Advanced.RadWideAdvancedBacklightWhileinVA_A7536);
    this.Field.Add("AdvancedDisplayLightTimeSec_A7875", (IAcpField) this.DisplayAndMenu.Advanced.AdvancedDisplayLightTimeSec_A7875);
    this.Field.Add("DispMenuAdvancedAlternatingDisplayTimems_A7436", (IAcpField) this.DisplayAndMenu.Advanced.DispMenuAdvancedAlternatingDisplayTimems_A7436);
    this.Field.Add("DispMenuAdvancedTemporaryMessageDisplayTimems_A9287", (IAcpField) this.DisplayAndMenu.Advanced.DispMenuAdvancedTemporaryMessageDisplayTimems_A9287);
    this.Field.Add("DisplMenuAdvancedTopLightColorPerChannel_A43171", (IAcpField) this.DisplayAndMenu.Advanced.DisplMenuAdvancedTopLightColorPerChannel_A43171);
    this.Field.Add("AdvancedIndependentRotaryLight_A8254", (IAcpField) this.DisplayAndMenu.Advanced.AdvancedIndependentRotaryLight_A8254);
    this.Field.Add("DispMenuAdvancedFeatureInactivityTimeoutSec_A20011", (IAcpField) this.DisplayAndMenu.Advanced.DispMenuAdvancedFeatureInactivityTimeoutSec_A20011);
    this.Field.Add("RadErgoWideDispMenu_A21430", (IAcpField) this.DisplayAndMenu.Advanced.RadErgoWideDispMenu_A21430);
    this.Field.Add("RadioErgDispAdvanceStatusAutoExit_42158", (IAcpField) this.DisplayAndMenu.Advanced.RadioErgDispAdvanceStatusAutoExit_42158);
    this.Field.Add("RadioErgDispAdvanceChannelColorBacklight_43747", (IAcpField) this.DisplayAndMenu.Advanced.RadioErgDispAdvanceChannelColorBacklight_43747);
    this.Field.Add("Prefix_A23035", (IAcpField) this.IDDisplayTableInner.IDDisplayTableInnerSection.Prefix_A23035);
    this.Field.Add("DispMenuIDDisplayPTTIDDisplay_A8221", (IAcpField) this.DisplayAndMenu.IDDisplay.DispMenuIDDisplayPTTIDDisplay_A8221);
    this.Field.Add("DispMenuIDDisplayEndOfVoiceTimerSec_A7973", (IAcpField) this.DisplayAndMenu.IDDisplay.DispMenuIDDisplayEndOfVoiceTimerSec_A7973);
    this.Field.Add("DispMenuIDDisplayID_A8738", (IAcpField) this.IDDisplayTableInner.IDDisplayTableInnerSection.DispMenuIDDisplayID_A8738);
    this.Field.Add("PrefixIDTextSize_A22465", (IAcpField) this.DisplayAndMenu.IDDisplay.PrefixIDTextSize_A22465);
    this.Field.Add("DispMenuIDDisplayDisplayOnPTT_A7878", (IAcpField) this.DisplayAndMenu.IDDisplay.DispMenuIDDisplayDisplayOnPTT_A7878);
    this.Field.Add("DispMenuIDDisplayDisplayOnModeChange_A7876", (IAcpField) this.DisplayAndMenu.IDDisplay.DispMenuIDDisplayDisplayOnModeChange_A7876);
    this.Field.Add("DispMenuIDDisplayDisplayOnReceive_A7880", (IAcpField) this.DisplayAndMenu.IDDisplay.DispMenuIDDisplayDisplayOnReceive_A7880);
    this.Field.Add("RadProfBacklightColorControlDefaultBacklightColor_A7811", (IAcpField) this.DisplayAndMenu.BacklightColorControl.RadProfBacklightColorControlDefaultBacklightColor_A7811);
    this.Field.Add("DispMenuLabtoolColorText1_A7689", (IAcpField) this.BacklightColorsInner.BacklightColorsInnerSection.DispMenuLabtoolColorText1_A7689);
    this.Field.Add("DispMenuLabtoolRed1_A8923", (IAcpField) this.BacklightColorsInner.BacklightColorsInnerSection.DispMenuLabtoolRed1_A8923);
    this.Field.Add("DispMenuLabtoolGreen1_A8172", (IAcpField) this.BacklightColorsInner.BacklightColorsInnerSection.DispMenuLabtoolGreen1_A8172);
    this.Field.Add("DispMenuLabtoolBlue1_A7565", (IAcpField) this.BacklightColorsInner.BacklightColorsInnerSection.DispMenuLabtoolBlue1_A7565);
    this.Field.Add("DispMenuLabtoolConfigurable1_A7700", (IAcpField) this.BacklightColorsInner.BacklightColorsInnerSection.DispMenuLabtoolConfigurable1_A7700);
    this.Field.Add("DispMenuTestModeTestModePasswordEnabled_A4971", (IAcpField) this.DisplayAndMenu.TestMode.DispMenuTestModeTestModePasswordEnabled_A4971);
    this.Field.Add("DispMenuTestModePassword_A4973", (IAcpField) this.DisplayAndMenu.TestMode.DispMenuTestModePassword_A4973);
    this.Field.Add("DispMenuLabtoolCharacterEncodingType_A21738", (IAcpField) this.DisplayAndMenu.Labtool.DispMenuLabtoolCharacterEncodingType_A21738);
    this.Field.Add("DispMenuGeneralOutOfRangeEarlyDetection", (IAcpField) this.DisplayAndMenu.General.DispMenuGeneralOutOfRangeEarlyDetection);
  }

  private void AddDVRSProfiles()
  {
    this.Field.Add("DVRSProfGeneralDVRSProfName_A41809", (IAcpField) this.DVRSProfiles.General.DVRSProfGeneralDVRSProfName_A41809);
    this.Field.Add("DVRSProfGeneralDVRSRemoteActivation_A41800", (IAcpField) this.DVRSProfiles.General.DVRSProfGeneralDVRSRemoteActivation_A41800);
    this.Field.Add("DVRSProfGeneralGenStsOnDVRSModChg_A41801", (IAcpField) this.DVRSProfiles.General.DVRSProfGeneralGenStsOnDVRSModChg_A41801);
    this.Field.Add("DVRSProfGeneralGenStsOnDVRSModChgHoldoff_A41869", (IAcpField) this.DVRSProfiles.General.DVRSProfGeneralGenStsOnDVRSModChgHoldoff_A41869);
    this.Field.Add("DVRSProfGeneralICMAllowed_A41802", (IAcpField) this.DVRSProfiles.General.DVRSProfGeneralICMAllowed_A41802);
    this.Field.Add("DVRSProfGeneralOutSysRepLocalMode_A41804", (IAcpField) this.DVRSProfiles.General.DVRSProfGeneralOutSysRepLocalMode_A41804);
    this.Field.Add("DVRSProfGeneralMSUSysPTTInLocalMode_A41803", (IAcpField) this.DVRSProfiles.General.DVRSProfGeneralMSUSysPTTInLocalMode_A41803);
    this.Field.Add("DVRSProfGeneralRouteMSUPTTMicAudToDVR_A41805", (IAcpField) this.DVRSProfiles.General.DVRSProfGeneralRouteMSUPTTMicAudToDVR_A41805);
    this.Field.Add("DVRSProfGeneralLocalTxFallback_A41806", (IAcpField) this.DVRSProfiles.General.DVRSProfGeneralLocalTxFallback_A41806);
    this.Field.Add("DVRSProfGeneralProxyTimeOutTimer_A41807", (IAcpField) this.DVRSProfiles.General.DVRSProfGeneralProxyTimeOutTimer_A41807);
    this.Field.Add("DVRSProfGeneralProxyLimitPatienceTimer_A41808", (IAcpField) this.DVRSProfiles.General.DVRSProfGeneralProxyLimitPatienceTimer_A41808);
    this.Field.Add("DVRSProfGeneralProxyRFSSReponseTimer_A41810", (IAcpField) this.DVRSProfiles.General.DVRSProfGeneralProxyRFSSReponseTimer_A41810);
  }

  private void AddDVRSWide()
  {
    this.Field.Add("RadErgoWideDigitalVehicularRepeaterSystemDVRSHardwareEnable_A7911", (IAcpField) this.DVRSWide.General.RadErgoWideDigitalVehicularRepeaterSystemDVRSHardwareEnable_A7911);
    this.Field.Add("DVRSWideGeneralVIPCtrlofDVRS_A41798", (IAcpField) this.DVRSWide.General.DVRSWideGeneralVIPCtrlofDVRS_A41798);
    this.Field.Add("DVRSWideGeneralInCarMonitor_A41799", (IAcpField) this.DVRSWide.General.DVRSWideGeneralInCarMonitor_A41799);
    this.Field.Add("DVRSWideLabtoolDVRSSyncFieldsHash_A41811", (IAcpField) this.DVRSWide.General.DVRSWideLabtoolDVRSSyncFieldsHash_A41811);
    this.Field.Add("RadWideLabtoolDVRSFatalError_A7910", (IAcpField) this.DVRSWide.General.RadWideLabtoolDVRSFatalError_A7910);
    this.Field.Add("DVRSWideGeneralChannelOnlyDisplay_A41811", (IAcpField) this.DVRSWide.General.DVRSWideGeneralChannelOnlyDisplay_A41811);
  }

  private void AddEmergencyWide()
  {
    this.Field.Add("EmerWideGeneralEmergencyAlarmRxIndicatorType_A7933", (IAcpField) this.EmergencyWide.General.EmerWideGeneralEmergencyAlarmRxIndicatorType_A7933);
    this.Field.Add("EmerWideGeneralKeepAlive_A8360", (IAcpField) this.EmergencyWide.General.EmerWideGeneralKeepAlive_A8360);
    this.Field.Add("EmerWideGeneralSilentAlarm_A9130", (IAcpField) this.EmergencyWide.General.EmerWideGeneralSilentAlarm_A9130);
    this.Field.Add("EmerWideGeneralSuppressEmergencyCall_A42142", (IAcpField) this.EmergencyWide.General.EmerWideGeneralSuppressEmergencyCall_A42142);
    this.Field.Add("EmerWideGeneralUnmuteOption_A9598", (IAcpField) this.EmergencyWide.General.EmerWideGeneralUnmuteOption_A9598);
    this.Field.Add("EmerWideGeneralChannelDelaysec_A7657", (IAcpField) this.EmergencyWide.General.EmerWideGeneralChannelDelaysec_A7657);
    this.Field.Add("EmerWideGeneralEmergencyPowerUp_A7942", (IAcpField) this.EmergencyWide.General.EmerWideGeneralEmergencyPowerUp_A7942);
    this.Field.Add("EmerWideGeneralEmergencyCallReceive_A7937", (IAcpField) this.EmergencyWide.General.EmerWideGeneralEmergencyCallReceive_A7937);
    this.Field.Add("EmerWideManDownTrigger_A40001", (IAcpField) this.EmergencyWide.ManDown.EmerWideManDownTrigger_A40001);
    this.Field.Add("EmerWideManDownMotionlessSensitivity_A40002", (IAcpField) this.EmergencyWide.ManDown.EmerWideManDownMotionlessSensitivity_A40002);
    this.Field.Add("EmerWideManDownPreAlertTimer_A40003", (IAcpField) this.EmergencyWide.ManDown.EmerWideManDownPreAlertTimer_A40003);
    this.Field.Add("EmerWideManDownPostAlertTimer_A40004", (IAcpField) this.EmergencyWide.ManDown.EmerWideManDownPostAlertTimer_A40004);
    this.Field.Add("EmerWidePostAlertTone_A41191", (IAcpField) this.EmergencyWide.ManDown.EmerWidePostAlertTone_A41191);
    this.Field.Add("ManDownConfigurabilityGranularityLevel_42057", (IAcpField) this.EmergencyWide.ManDown.ManDownConfigurabilityGranularityLevel_42057);
    this.Field.Add("TriggedByManDown_42135", (IAcpField) this.EmergencyWide.EmergencyToneTrigger.TriggedByManDown_42135);
  }

  private void AddEnhancedDataPortList()
  {
    this.Field.Add("DataCfgEnhDataPortListAlias_A42007", (IAcpField) this.EnhancedDataPortList.EnhancedDataPortList42005.DataCfgEnhDataPortListAlias_A42007);
    this.Field.Add("DataWideEnhDataPortListPortNum_A42008", (IAcpField) this.EnhancedDataPortTableInner.EnhancedDataPortTableInnerSection.DataWideEnhDataPortListPortNum_A42008);
  }

  private void AddExternalMicNoiseReductionProfile()
  {
    this.Field.Add("ExternalMicNoiseReductionProfileName_A22536", (IAcpField) this.ExternalMicNoiseReductionProfile.General.ExternalMicNoiseReductionProfileName_A22536);
    this.Field.Add("RadErgoCfgGeneralDINCEWINDNBANDS_A22301", (IAcpField) this.ExternalMicNoiseReductionProfile.General.RadErgoCfgGeneralDINCEWINDNBANDS_A22301);
    this.Field.Add("RadErgoCfgGeneralMAXSVECTOR_A22297", (IAcpField) this.ExternalMicNoiseReductionProfile.General.RadErgoCfgGeneralMAXSVECTOR_A22297);
    this.Field.Add("RadErgoCfgGeneralDINCABFSS_A22300", (IAcpField) this.ExternalMicNoiseReductionProfile.General.RadErgoCfgGeneralDINCABFSS_A22300);
    this.Field.Add("RadErgoCfgGeneralMINGAIN_A22298", (IAcpField) this.ExternalMicNoiseReductionProfile.General.RadErgoCfgGeneralMINGAIN_A22298);
    this.Field.Add("RadErgoCfgGeneralEXPANSIONDEGREE_A22299", (IAcpField) this.ExternalMicNoiseReductionProfile.General.RadErgoCfgGeneralEXPANSIONDEGREE_A22299);
    this.Field.Add("RadErgoCfgGeneralHOTBEAMDETTHRESHDBQ8_A22302", (IAcpField) this.ExternalMicNoiseReductionProfile.General.RadErgoCfgGeneralHOTBEAMDETTHRESHDBQ8_A22302);
    this.Field.Add("RadErgoCfgGeneralVADDETTHRESHDBQ8_A22303", (IAcpField) this.ExternalMicNoiseReductionProfile.General.RadErgoCfgGeneralVADDETTHRESHDBQ8_A22303);
    this.Field.Add("RadErgoCfgGeneralVADDETCOUNT_A22304", (IAcpField) this.ExternalMicNoiseReductionProfile.General.RadErgoCfgGeneralVADDETCOUNT_A22304);
    this.Field.Add("RadErgoCfgGeneralINACTIVETHRESHDBQ8_A22305", (IAcpField) this.ExternalMicNoiseReductionProfile.General.RadErgoCfgGeneralINACTIVETHRESHDBQ8_A22305);
    this.Field.Add("RadErgoCfgGeneralSDIFFTHRESHDBQ8_A22306", (IAcpField) this.ExternalMicNoiseReductionProfile.General.RadErgoCfgGeneralSDIFFTHRESHDBQ8_A22306);
    this.Field.Add("RadErgoCfgGeneralNDIFFTHRESHDBQ8_A22307", (IAcpField) this.ExternalMicNoiseReductionProfile.General.RadErgoCfgGeneralNDIFFTHRESHDBQ8_A22307);
    this.Field.Add("RadErgoCfgGeneralRTHRESHDBQ8_A22308", (IAcpField) this.ExternalMicNoiseReductionProfile.General.RadErgoCfgGeneralRTHRESHDBQ8_A22308);
    this.Field.Add("ExtMicNsRdGenDINCOUTPUTEQVECTOR_A37720", (IAcpField) this.ExternalMicNoiseReductionProfile.General.ExtMicNsRdGenDINCOUTPUTEQVECTOR_A37720);
    this.Field.Add("ExtMicNsRdGenDINCEPVECTOR_A37721", (IAcpField) this.ExternalMicNoiseReductionProfile.General.ExtMicNsRdGenDINCEPVECTOR_A37721);
  }

  private void AddFactoryOverrides()
  {
    this.Field.Add("FctOrdsSecondLOInjectionFrequencySecondLOInjectionFrequency_A9062", (IAcpField) this.SecondLOInjectionFrequencyListInner.SecondLOInjectionFrequencyListInnerSection.FctOrdsSecondLOInjectionFrequencySecondLOInjectionFrequency_A9062);
    this.Field.Add("RadWideAdvancedFactoryOverrides_A8004", (IAcpField) this.FactoryOverrides.General.RadWideAdvancedFactoryOverrides_A8004);
    this.Field.Add("FctOrdsRxSynthesizerReferenceDividerListRxFreqMHz_A9017", (IAcpField) this.RxSynthesizerReferenceDividerListInner.RxSynthesizerReferenceDividerListInnerSection.FctOrdsRxSynthesizerReferenceDividerListRxFreqMHz_A9017);
    this.Field.Add("FctOrdsRxSynthesizerReferenceDividerListRxRefDivMHz_A8925", (IAcpField) this.RxSynthesizerReferenceDividerListInner.RxSynthesizerReferenceDividerListInnerSection.FctOrdsRxSynthesizerReferenceDividerListRxRefDivMHz_A8925);
    this.Field.Add("FctOrdsTxSynthesizerReferenceDividerListTxFreqMHz_A9534", (IAcpField) this.TxSynthesizerReferenceDividerListInner.TxSynthesizerReferenceDividerListInnerSection.FctOrdsTxSynthesizerReferenceDividerListTxFreqMHz_A9534);
    this.Field.Add("FctOrdsRxSynthesizerReferenceDividerListTxRefDivMHz_A8924", (IAcpField) this.TxSynthesizerReferenceDividerListInner.TxSynthesizerReferenceDividerListInnerSection.FctOrdsRxSynthesizerReferenceDividerListTxRefDivMHz_A8924);
    this.Field.Add("FctOrdsTxSSIClockRateListTxFrequencyMHz_A36577", (IAcpField) this.TxSSIClockRateListInner.TxSSIClockRateListInnerSection.FctOrdsTxSSIClockRateListTxFrequencyMHz_A36577);
    this.Field.Add("FctOrdsTxSSIClockRateListTxSSIClockRateMHz_A36578", (IAcpField) this.TxSSIClockRateListInner.TxSSIClockRateListInnerSection.FctOrdsTxSSIClockRateListTxSSIClockRateMHz_A36578);
    this.Field.Add("FctOrdsRxFrequencyListRxFrequency", (IAcpField) this.RxFrequencyListInner.RxFrequencyListInnerSection.FctOrdsRxFrequencyListRxFrequency);
  }

  private void AddGlobalNoiseReductionList()
  {
    this.Field.Add("DINCSPATIALEQ1VECTOR_A21553", (IAcpField) this.GlobalNoiseReductionList.General.DINCSPATIALEQ1VECTOR_A21553);
    this.Field.Add("DINCSPATIALEQ1VECTORCONT_A37716", (IAcpField) this.GlobalNoiseReductionList.General.DINCSPATIALEQ1VECTORCONT_A37716);
    this.Field.Add("DINCSPATIALEQ2VECTOR_A21556", (IAcpField) this.GlobalNoiseReductionList.General.DINCSPATIALEQ2VECTOR_A21556);
    this.Field.Add("DINCSPATIALEQ2VECTORCONT_A37717", (IAcpField) this.GlobalNoiseReductionList.General.DINCSPATIALEQ2VECTORCONT_A37717);
    this.Field.Add("DINCBFEQVECTOR_A21557", (IAcpField) this.GlobalNoiseReductionList.General.DINCBFEQVECTOR_A21557);
    this.Field.Add("DINCOUTPUTEQVECTOR_A21558", (IAcpField) this.GlobalNoiseReductionList.General.DINCOUTPUTEQVECTOR_A21558);
    this.Field.Add("DINCELKOVECTOR_A21561", (IAcpField) this.GlobalNoiseReductionList.General.DINCELKOVECTOR_A21561);
    this.Field.Add("DINCHOTBEAMHYSTERESIS_A21559", (IAcpField) this.GlobalNoiseReductionList.General.DINCHOTBEAMHYSTERESIS_A21559);
    this.Field.Add("DINCBADMICHYSTERESIS_A21560", (IAcpField) this.GlobalNoiseReductionList.General.DINCBADMICHYSTERESIS_A21560);
  }

  private void AddInternalMicNoiseReductionProfile()
  {
    this.Field.Add("InternalMicNoiseReductionProfileName_A22535", (IAcpField) this.InternalMicNoiseReductionProfile.General.InternalMicNoiseReductionProfileName_A22535);
    this.Field.Add("RadErgoCfgGeneralMAXSVECTOR_A21565", (IAcpField) this.InternalMicNoiseReductionProfile.General.RadErgoCfgGeneralMAXSVECTOR_A21565);
    this.Field.Add("RadErgoCfgGeneralNBANDS_A21573", (IAcpField) this.InternalMicNoiseReductionProfile.General.RadErgoCfgGeneralNBANDS_A21573);
    this.Field.Add("RadErgoCfgGeneralDINCABFSS_A21564", (IAcpField) this.InternalMicNoiseReductionProfile.General.RadErgoCfgGeneralDINCABFSS_A21564);
    this.Field.Add("RadErgoCfgGeneralMINGAIN_A21562", (IAcpField) this.InternalMicNoiseReductionProfile.General.RadErgoCfgGeneralMINGAIN_A21562);
    this.Field.Add("RadErgoCfgGeneralEXPANSIONDEGREE_A21563", (IAcpField) this.InternalMicNoiseReductionProfile.General.RadErgoCfgGeneralEXPANSIONDEGREE_A21563);
    this.Field.Add("RadErgoCfgGeneralHOTBEAMDETTHRESHDBQ8_A21566", (IAcpField) this.InternalMicNoiseReductionProfile.General.RadErgoCfgGeneralHOTBEAMDETTHRESHDBQ8_A21566);
    this.Field.Add("RadErgoCfgGeneralVADDETTHRESHDBQ8_A21567", (IAcpField) this.InternalMicNoiseReductionProfile.General.RadErgoCfgGeneralVADDETTHRESHDBQ8_A21567);
    this.Field.Add("RadErgoCfgGeneralVADDETCOUNT_A21568", (IAcpField) this.InternalMicNoiseReductionProfile.General.RadErgoCfgGeneralVADDETCOUNT_A21568);
    this.Field.Add("RadErgoCfgGeneralINACTIVETHRESHDBQ8_A21569", (IAcpField) this.InternalMicNoiseReductionProfile.General.RadErgoCfgGeneralINACTIVETHRESHDBQ8_A21569);
    this.Field.Add("RadErgoCfgGeneralSDIFFTHRESHDBQ8_A21570", (IAcpField) this.InternalMicNoiseReductionProfile.General.RadErgoCfgGeneralSDIFFTHRESHDBQ8_A21570);
    this.Field.Add("RadErgoCfgGeneralNDIFFTHRESHDBQ8_A21571", (IAcpField) this.InternalMicNoiseReductionProfile.General.RadErgoCfgGeneralNDIFFTHRESHDBQ8_A21571);
    this.Field.Add("RadErgoCfgGeneralRTHRESHDBQ8_A21572", (IAcpField) this.InternalMicNoiseReductionProfile.General.RadErgoCfgGeneralRTHRESHDBQ8_A21572);
    this.Field.Add("IntMicNsRdGenDINCOUTPUTEQVECTOR_A37718", (IAcpField) this.InternalMicNoiseReductionProfile.General.IntMicNsRdGenDINCOUTPUTEQVECTOR_A37718);
    this.Field.Add("IntMicNsRdGenDINCEPVECTOR_A37719", (IAcpField) this.InternalMicNoiseReductionProfile.General.IntMicNsRdGenDINCEPVECTOR_A37719);
  }

  private void AddKeypad()
  {
    this.Field.Add("RadErgCtrlKeypadGeneralKeypadButtonName_A41069", (IAcpField) this.KeypadButtonInner.KeypadButtonInnerSection.RadErgCtrlKeypadGeneralKeypadButtonName_A41069);
    this.Field.Add("RadErgCtrlKeypadGeneralKeypadBCO_A41070", (IAcpField) this.KeypadButtonInner.KeypadButtonInnerSection.RadErgCtrlKeypadGeneralKeypadBCO_A41070);
    this.Field.Add("RadErgCtrlKeypadGeneralKeypadButtonFeature_A41071", (IAcpField) this.KeypadButtonInner.KeypadButtonInnerSection.RadErgCtrlKeypadGeneralKeypadButtonFeature_A41071);
    this.Field.Add("RadErgCtrlKeypadGeneralKeypadButtonIndex_41415", (IAcpField) this.KeypadButtonInner.KeypadButtonInnerSection.RadErgCtrlKeypadGeneralKeypadButtonIndex_41415);
  }

  private void AddKeypadMicAndAccessories()
  {
    this.Field.Add("RadErgoCfgKMButtonName_A22561", (IAcpField) this.KMButtonInner.KMButtonInnerSection.RadErgoCfgKMButtonName_A22561);
    this.Field.Add("RadErgoCfgKMConventionalKMButtonBCO_A19643", (IAcpField) this.KMButtonInner.KMButtonInnerSection.RadErgoCfgKMConventionalKMButtonBCO_A19643);
    this.Field.Add("RadErgoCfgKMConventionalKMButtonFeature_A19646", (IAcpField) this.KMButtonInner.KMButtonInnerSection.RadErgoCfgKMConventionalKMButtonFeature_A19646);
    this.Field.Add("RadErgoCfgKMTrunkingKMButtonBCO_A19745", (IAcpField) this.KMButtonInner.KMButtonInnerSection.RadErgoCfgKMTrunkingKMButtonBCO_A19745);
    this.Field.Add("RadErgoCfgKMTrunkingKMButtonFeature_A19746", (IAcpField) this.KMButtonInner.KMButtonInnerSection.RadErgoCfgKMTrunkingKMButtonFeature_A19746);
    this.Field.Add("RadErgoCfgKMButtonKey_A22560", (IAcpField) this.KMButtonInner.KMButtonInnerSection.RadErgoCfgKMButtonKey_A22560);
    this.Field.Add("RadErgoCfgKMButtonShortPressTime", (IAcpField) this.KMButtonInner.KMButtonInnerSection.RadErgoCfgKMButtonShortPressTime);
    this.Field.Add("RadErgoCfgKMButtonLongPressTime", (IAcpField) this.KMButtonInner.KMButtonInnerSection.RadErgoCfgKMButtonLongPressTime);
    this.Field.Add("RadErgoCfgKMDataButtonName_A22601", (IAcpField) this.KeyPadMicDataButtonInner.DataButtonInnerSection.RadErgoCfgKMDataButtonName_A22601);
    this.Field.Add("RadErgoCfgKMConventionalKMDataButtonBCO_A22602", (IAcpField) this.KeyPadMicDataButtonInner.DataButtonInnerSection.RadErgoCfgKMConventionalKMDataButtonBCO_A22602);
    this.Field.Add("RadErgoCfgKMConventionalKMDatatButtonFeature_A22603", (IAcpField) this.KeyPadMicDataButtonInner.DataButtonInnerSection.RadErgoCfgKMConventionalKMDatatButtonFeature_A22603);
    this.Field.Add("RadErgoCfgKMConventionalKMDatatButtonIndex_A41423", (IAcpField) this.KeyPadMicDataButtonInner.DataButtonInnerSection.RadErgoCfgKMConventionalKMDatatButtonIndex_A41423);
    this.Field.Add("RadErgoCfgKMTrunkingKMDataButtonBCO_A22604", (IAcpField) this.KeyPadMicDataButtonInner.DataButtonInnerSection.RadErgoCfgKMTrunkingKMDataButtonBCO_A22604);
    this.Field.Add("RadErgoCfgKMTrunkingKMDatatButtonFeature_A22605", (IAcpField) this.KeyPadMicDataButtonInner.DataButtonInnerSection.RadErgoCfgKMTrunkingKMDatatButtonFeature_A22605);
    this.Field.Add("RadErgoCfgKMTrunkingKMDatatButtonIndex_A41424", (IAcpField) this.KeyPadMicDataButtonInner.DataButtonInnerSection.RadErgoCfgKMTrunkingKMDatatButtonIndex_A41424);
    this.Field.Add("RadErgoCfgKMDataButtonKey_A22600", (IAcpField) this.KeyPadMicDataButtonInner.DataButtonInnerSection.RadErgoCfgKMDataButtonKey_A22600);
    this.Field.Add("RadErgoControlKMANaviControlName_41759", (IAcpField) this.KMANavigationControlsTableInner.KMANavigationControlsTableInnerSection.RadErgoControlKMANaviControlName_41759);
    this.Field.Add("RadErgoControlKMAUpDownButton_41760", (IAcpField) this.KMANavigationControlsTableInner.KMANavigationControlsTableInnerSection.RadErgoControlKMAUpDownButton_41760);
    if (FieldAccessor.IsCpsApiTest && !UtilityMack.IsMobile())
      return;
    this.Field.Add("RadErgoControlKMAUpDownButton_41760_Down", (IAcpField) this.KMANavigationControlsTableInner_Down.KMANavigationControlsTableInnerSection.RadErgoControlKMAUpDownButton_41760);
  }

  private void AddMDCConventionalHotList()
  {
    this.Field.Add("UclMDCCnvHotList_HotListAlias_A00045", (IAcpField) this.UclMDCCallHotList.MDCCallHotList.UclMDCCnvHotList_HotListAlias_A00045Object);
  }

  private void AddMenuItems()
  {
    this.Field.Add("DispMenuConventionalAvailableMenuItems_A22666", (IAcpField) this.MenuItems.General.DispMenuConventionalAvailableMenuItems_A22666);
    this.Field.Add("DispMenuTrunkingAvailableMenuItems_A22667", (IAcpField) this.MenuItems.General.DispMenuTrunkingAvailableMenuItems_A22667);
    this.Field.Add("DispMenuConventionalSelectedMenuItems_A21736", (IAcpField) this.MenuItems.General.DispMenuConventionalSelectedMenuItems_A21736);
    this.Field.Add("DispMenuTrunkingSelectedMenuItems_A21735", (IAcpField) this.MenuItems.General.DispMenuTrunkingSelectedMenuItems_A21735);
  }

  private void AddRadioWide()
  {
    this.Field.Add("RadWideGeneralLogDisp_A9756", (IAcpField) this.RadioWide.General.RadWideGeneralLogDisp_A9756);
    this.Field.Add("RadInfoGeneralMotorcycleRadio_A8546", (IAcpField) this.RadioWide.General.RadInfoGeneralMotorcycleRadio_A8546);
    this.Field.Add("RadWideGeneralTimeFormat_A9377", (IAcpField) this.RadioWide.General.RadWideGeneralTimeFormat_A9377);
    this.Field.Add("RadWideGeneralDateFormat_A7802", (IAcpField) this.RadioWide.General.RadWideGeneralDateFormat_A7802);
    this.Field.Add("RadWideAdvancedMaximumTxDeviation_A8480", (IAcpField) this.RadioWide.General.RadWideAdvancedMaximumTxDeviation_A8480);
    this.Field.Add("RadWideAdvancedUltraNarrowIntermediateFreqFilter_A9592", (IAcpField) this.RadioWide.General.RadWideAdvancedUltraNarrowIntermediateFreqFilter_A9592);
    this.Field.Add("RadErgoWideAdvancedModeSelTxName", (IAcpField) this.RadioWide.General.RadErgoWideAdvancedModeSelTxName);
    this.Field.Add("RadWideGeneralASKRequired_A37152", (IAcpField) this.RadioWide.General.RadWideGeneralASKRequired_A37152);
    this.Field.Add("RadWideGeneralOwnerAdvancedKeyType_A38663", (IAcpField) this.RadioWide.General.RadWideGeneralOwnerAdvancedKeyType_A38663);
    this.Field.Add("RadWideGeneralOwnerSystemID_A37153", (IAcpField) this.RadioWide.General.RadWideGeneralOwnerSystemID_A37153);
    this.Field.Add("RadWideGeneralOwnerWACNID_A38656", (IAcpField) this.RadioWide.General.RadWideGeneralOwnerWACNID_A38656);
    this.Field.Add("RadWideFeaturesVLIFPLOSSFIELD_A9596", (IAcpField) this.RadioWide.Features.RadWideFeaturesVLIFPLOSSFIELD_A9596);
    this.Field.Add("RadWideGeneralPskId_44840", (IAcpField) this.RadioWide.General.RadWideGeneralPskId_44840);
    this.Field.Add("RadWideGeneralTlsPsk_44841", (IAcpField) this.RadioWide.General.RadWideGeneralTlsPsk_44841);
    this.Field.Add("RadWideGeneralTlsPskPort_44842", (IAcpField) this.RadioWide.General.RadWideGeneralTlsPskPort_44842);
    this.Field.Add("RadWideGeneralDnsSdAddress_44843", (IAcpField) this.RadioWide.General.RadWideGeneralDnsSdAddress_44843);
    this.Field.Add("RadWideGeneralDnsSdPort_44844", (IAcpField) this.RadioWide.General.RadWideGeneralDnsSdPort_44844);
    this.Field.Add("RadWideGeneralProgrammingPath_44845", (IAcpField) this.RadioWide.General.RadWideGeneralProgrammingPath_44845);
    this.Field.Add("RadProfAlertTonesAlertTones_A7428", (IAcpField) this.RadioWide.AlertTones.RadProfAlertTonesAlertTones_A7428);
    this.Field.Add("RadWideAlertTonesVolumeAdjustToneOffset_A9656", (IAcpField) this.RadioWide.AlertTones.RadWideAlertTonesVolumeAdjustToneOffset_A9656);
    this.Field.Add("RadProfAlertTonesPowerUpSelfTestAlertTone_A8718", (IAcpField) this.RadioWide.AlertTones.RadProfAlertTonesPowerUpSelfTestAlertTone_A8718);
    this.Field.Add("RadWideAlertTonesScanAlertToneEnable_A19555", (IAcpField) this.RadioWide.AlertTones.RadWideAlertTonesScanAlertToneEnable_A19555);
    this.Field.Add("RadWideAlertTonesZeroLevelAudioMute_A9689", (IAcpField) this.RadioWide.AlertTones.RadWideAlertTonesZeroLevelAudioMute_A9689);
    this.Field.Add("RadProfAlertTonesCallAlertToneAutoReset_A7596", (IAcpField) this.RadioWide.AlertTones.RadProfAlertTonesCallAlertToneAutoReset_A7596);
    this.Field.Add("RadProfAlertTonesRotaryAlert_A8983", (IAcpField) this.RadioWide.AlertTones.RadProfAlertTonesRotaryAlert_A8983);
    this.Field.Add("RadProfAlertTonesEnhancedMuteTonesOperation_A42150", (IAcpField) this.RadioWide.AlertTones.RadProfAlertTonesEnhancedMuteTonesOperation_A42150);
    this.Field.Add("RadProfAlertTonesMuteTonesOperation_A8562", (IAcpField) this.RadioWide.AlertTones.RadProfAlertTonesMuteTonesOperation_A8562);
    this.Field.Add("RadProfAlertTonesNewMuteTonesOperation_A42149", (IAcpField) this.RadioWide.AlertTones.RadProfAlertTonesNewMuteTonesOperation_A42149);
    this.Field.Add("RadProfAlertTonesLED_A8428", (IAcpField) this.RadioWide.AlertTones.RadProfAlertTonesLED_A8428);
    this.Field.Add("RadWideAlertTonesTxChirp_A9523", (IAcpField) this.RadioWide.AlertTones.RadWideAlertTonesTxChirp_A9523);
    this.Field.Add("RadProfAlertTonesStandbyChirpsec_A9179", (IAcpField) this.RadioWide.AlertTones.RadProfAlertTonesStandbyChirpsec_A9179);
    this.Field.Add("RadWideAdvancedSmartLowBatteryAlert_A9165", (IAcpField) this.RadioWide.AlertTones.RadWideAdvancedSmartLowBatteryAlert_A9165);
    this.Field.Add("RadWideUserInformationandPasswordsSoftIDUsernameDisplayTextSize_A23453", (IAcpField) this.RadioWide.UserInformationAndPasswords.RadWideUserInformationandPasswordsSoftIDUsernameDisplayTextSize_A23453);
    this.Field.Add("RadWideUserInformationandPasswordsSoftIDUsername_A9169", (IAcpField) this.RadioWide.UserInformationAndPasswords.RadWideUserInformationandPasswordsSoftIDUsername_A9169);
    this.Field.Add("RadWideUserInformationandPINPassword_41303", (IAcpField) this.RadioWide.UserInformationAndPasswords.RadWideUserInformationandPINPassword_41303);
    this.Field.Add("RadWideUserInformationandPasswordsPIN_A8705", (IAcpField) this.RadioWide.UserInformationAndPasswords.RadWideUserInformationandPasswordsPIN_A8705);
    this.Field.Add("RadWideUserInformationandPINPasswordPart2_41304", (IAcpField) this.RadioWide.UserInformationAndPasswords.RadWideUserInformationandPINPasswordPart2_41304);
    this.Field.Add("RadWideUserInformationandUserLoginUnitIDEnable_41305", (IAcpField) this.RadioWide.UserInformationAndPasswords.RadWideUserInformationandUserLoginUnitIDEnable_41305);
    this.Field.Add("RadWideUserInformationandUserLoginUnitIDTextSize_41309", (IAcpField) this.RadioWide.UserInformationAndPasswords.RadWideUserInformationandUserLoginUnitIDTextSize_41309);
    this.Field.Add("RadWideUserInformationandUserLoginUnitID_41306", (IAcpField) this.RadioWide.UserInformationAndPasswords.RadWideUserInformationandUserLoginUnitID_41306);
    this.Field.Add("RadWideUserInformationandPasswordsRadioAliasEnable_A8830", (IAcpField) this.RadioWide.UserInformationAndPasswords.RadWideUserInformationandPasswordsRadioAliasEnable_A8830);
    this.Field.Add("RadWideUserInformationandPasswordsRadioAlias_A8829", (IAcpField) this.RadioWide.UserInformationAndPasswords.RadWideUserInformationandPasswordsRadioAlias_A8829);
    this.Field.Add("RadWideUserInformationandPasswordsProtectedZonePassword_A8766", (IAcpField) this.RadioWide.UserInformationAndPasswords.RadWideUserInformationandPasswordsProtectedZonePassword_A8766);
    this.Field.Add("RadWideUserInformationandPasswordsRadioLock_A8836", (IAcpField) this.RadioWide.UserInformationAndPasswords.RadWideUserInformationandPasswordsRadioLock_A8836);
    this.Field.Add("RadWideUserInformationandPasswordsMandatoryPassword_A8461", (IAcpField) this.RadioWide.UserInformationAndPasswords.RadWideUserInformationandPasswordsMandatoryPassword_A8461);
    this.Field.Add("RadWideUserInformationandPasswordsMaximumPasswordLength_A8477", (IAcpField) this.RadioWide.UserInformationAndPasswords.RadWideUserInformationandPasswordsMaximumPasswordLength_A8477);
    this.Field.Add("RadWideUserInformationandPasswordsUnlockPassword_A8690", (IAcpField) this.RadioWide.UserInformationAndPasswords.RadWideUserInformationandPasswordsUnlockPassword_A8690);
    this.Field.Add("RadWideUserInformationAndPasswordsTacticalInhibitEnable_A34405", (IAcpField) this.RadioWide.UserInformationAndPasswords.RadWideUserInformationAndPasswordsTacticalInhibitEnable_A34405);
    this.Field.Add("RadWideUserInformationAndPasswordsTacticalInhibitEncodePassword_A34395", (IAcpField) this.RadioWide.UserInformationAndPasswords.RadWideUserInformationAndPasswordsTacticalInhibitEncodePassword_A34395);
    this.Field.Add("RadWideUserinfoPassRequiredForGunlock_A36531", (IAcpField) this.RadioWide.UserInformationAndPasswords.RadWideUserinfoPassRequiredForGunlock_A36531);
    this.Field.Add("RadWideUserinfoPassRequiredForLightbar_A36532", (IAcpField) this.RadioWide.UserInformationAndPasswords.RadWideUserinfoPassRequiredForLightbar_A36532);
    this.Field.Add("RadWideUserinfoPassRequiredForSiren_A36533", (IAcpField) this.RadioWide.UserInformationAndPasswords.RadWideUserinfoPassRequiredForSiren_A36533);
    this.Field.Add("RadWideUserInformationandPasswordsSecureHardwareAutoLogin_A7508", (IAcpField) this.RadioWide.UserInformationAndPasswords.RadWideUserInformationandPasswordsSecureHardwareAutoLogin_A7508);
    this.Field.Add("RadWideUserInformationandCachedCredentialsUserLoginMode_41307", (IAcpField) this.RadioWide.UserInformationAndPasswords.RadWideUserInformationandCachedCredentialsUserLoginMode_41307);
    this.Field.Add("RadWideUserInformationandPasswordsUserLoginAuthenticationType_A44926", (IAcpField) this.RadioWide.UserInformationAndPasswords.RadWideUserInformationandPasswordsUserLoginAuthenticationType_A44926);
    this.Field.Add("RadWideUserInformationandPasswordsTacticalServiceEncodePassword", (IAcpField) this.RadioWide.UserInformationAndPasswords.RadWideUserInformationandPasswordsTacticalServiceEncodePassword);
    this.Field.Add("RadWideFeaturesBlockPendingCAPC_A7564", (IAcpField) this.RadioWide.Features.RadWideFeaturesBlockPendingCAPC_A7564);
    this.Field.Add("RadWideFeaturesRotarySwitchScanPrgm_A8986", (IAcpField) this.RadioWide.Features.RadWideFeaturesRotarySwitchScanPrgm_A8986);
    this.Field.Add("RadWideTPSFiregroundEvacuationTone_A7980", (IAcpField) this.RadioWide.Features.RadWideTPSFiregroundEvacuationTone_A7980);
    this.Field.Add("ZnChanCfgFPPProtectionFPPEnable_A8142", (IAcpField) this.RadioWide.Features.ZnChanCfgFPPProtectionFPPEnable_A8142);
    this.Field.Add("RadWideAdvancedCyclicKeying_A7795", (IAcpField) this.RadioWide.Features.RadWideAdvancedCyclicKeying_A7795);
    this.Field.Add("RadWideFeaturesChannelFallbackEnable", (IAcpField) this.RadioWide.Features.RadWideFeaturesChannelFallbackEnable);
    this.Field.Add("SwitchConventionalSwitchesPosition1_A12643", (IAcpField) this.RadioWide.Features.SwitchConventionalSwitchesPosition1_A12643);
    this.Field.Add("RadWideFeaturesInactivityAutoPoweroff_A38013", (IAcpField) this.RadioWide.Features.RadWideFeaturesInactivityAutoPoweroff_A38013);
    this.Field.Add("RadWideFeaturesIgnitionAutoPoweroff_A38014", (IAcpField) this.RadioWide.Features.RadWideFeaturesIgnitionAutoPoweroff_A38014);
    this.Field.Add("RadWideAdvancedRFModem_A8972", (IAcpField) this.RadioWide.Features.RadWideAdvancedRFModem_A8972);
    this.Field.Add("RadWideAdvancedRecordAudio_A8922", (IAcpField) this.RadioWide.Features.RadWideAdvancedRecordAudio_A8922);
    this.Field.Add("RadWideAdvancedPreAmp_A8733", (IAcpField) this.RadioWide.Features.RadWideAdvancedPreAmp_A8733);
    this.Field.Add("RadWideFeaturesAccessoryCableConfiguration_41997", (IAcpField) this.RadioWide.Features.RadWideFeaturesAccessoryCableConfiguration_41997);
    this.Field.Add("RadWideFeaturesVoiceControlPriority", (IAcpField) this.RadioWide.Features.RadWideFeaturesVoiceControlPriority);
    this.Field.Add("RadCfgVirtualPartnerMode", (IAcpField) this.RadioWide.Features.RadCfgVirtualPartnerMode);
    this.Field.Add("RadWideTransmitPowerLevelsBandSplitOverride_A41064", (IAcpField) this.RadioWide.Features.RadWideTransmitPowerLevelsBandSplitOverride_A41064);
    this.Field.Add("RadWideDualRadioSelection_A42236", (IAcpField) this.RadioWide.DualRadio.RadWideDualRadioSelection_A42236);
    this.Field.Add("RadWideDualRadioEmergencyRadio_A42239", (IAcpField) this.RadioWide.DualRadio.RadWideDualRadioEmergencyRadio_A42239);
    this.Field.Add("RadWideDualRadioTalkgroupMuteOption_A42290", (IAcpField) this.RadioWide.DualRadio.RadWideDualRadioTalkgroupMuteOption_A42290);
    this.Field.Add("RadWideDualRadioSecRadioTransmissionCapability_A42238", (IAcpField) this.RadioWide.DualRadio.RadWideDualRadioSecRadioTransmissionCapability_A42238);
    this.Field.Add("RadWideDualRadioCrossBandMuteOption_A42240", (IAcpField) this.RadioWide.DualRadio.RadWideDualRadioCrossBandMuteOption_A42240);
    this.Field.Add("RadWideDualRadioFixedRadioSwapMenu_A42241", (IAcpField) this.RadioWide.DualRadio.RadWideDualRadioFixedRadioSwapMenu_A42241);
    this.Field.Add("RadDualRadioFatalErrorOption_A42243", (IAcpField) this.RadioWide.DualRadio.RadDualRadioFatalErrorOption_A42243);
    this.Field.Add("MultiRadioSystemEnable_A42248", (IAcpField) this.RadioWide.DualRadio.MultiRadioSystemEnable_A42248);
    this.Field.Add("RadWideLocationLocationEnable_A8448", (IAcpField) this.RadioWide.Location.RadWideLocationLocationEnable_A8448);
    this.Field.Add("RadWideLocationUserSelectableLocationEnable_A9605", (IAcpField) this.RadioWide.Location.RadWideLocationUserSelectableLocationEnable_A9605);
    this.Field.Add("RadWideLocationGpsMode_A22627", (IAcpField) this.RadioWide.Location.RadWideLocationGpsMode_A22627);
    this.Field.Add("RadWideLocationMaxStoredLocationRequests_A8473", (IAcpField) this.RadioWide.Location.RadWideLocationMaxStoredLocationRequests_A8473);
    this.Field.Add("RadWideLocationDisplayFormat_A41561", (IAcpField) this.RadioWide.Location.RadWideLocationDisplayFormat_A41561);
    this.Field.Add("RadWideDisplaySixFigureUTM", (IAcpField) this.RadioWide.Location.RadWideDisplaySixFigureUTM);
    this.Field.Add("RadWideLocationDistanceUnit_A13080", (IAcpField) this.RadioWide.Location.RadWideLocationDistanceUnit_A13080);
    this.Field.Add("RadWideLocationExitLocationMenuonPTT_A13081", (IAcpField) this.RadioWide.Location.RadWideLocationExitLocationMenuonPTT_A13081);
    this.Field.Add("RadWideDigitalAudioOptionsStrongInterference1_A9207", (IAcpField) this.RadioWide.DigitalAudioOptions.RadWideDigitalAudioOptionsStrongInterference1_A9207);
    this.Field.Add("RadWideDigitalAudioOptionsWeakSignalFringe_A9679", (IAcpField) this.RadioWide.DigitalAudioOptions.RadWideDigitalAudioOptionsWeakSignalFringe_A9679);
    this.Field.Add("RadWideDigitalAudioOptionsStrongInterference2_A9206", (IAcpField) this.RadioWide.DigitalAudioOptions.RadWideDigitalAudioOptionsStrongInterference2_A9206);
    this.Field.Add("RadWideDigitalAudioOptionsWeakSignalFringe_A9678", (IAcpField) this.RadioWide.DigitalAudioOptions.RadWideDigitalAudioOptionsWeakSignalFringe_A9678);
    this.Field.Add("RadWideRxAudioControlMidrangeEqualization_A8508", (IAcpField) this.RadioWide.DigitalAudioOptions.RadWideRxAudioControlMidrangeEqualization_A8508);
    this.Field.Add("RadWideLabtoolMultipleConversationDisable_A19552", (IAcpField) this.RadioWide.DigitalAudioOptions.RadWideLabtoolMultipleConversationDisable_A19552);
    this.Field.Add("RadWideLabtoolDigitalAnalogBalance_A7851", (IAcpField) this.RadioWide.DigitalAudioOptions.RadWideLabtoolDigitalAnalogBalance_A7851);
    this.Field.Add("RadWideAdvancedAuxPTTAudioSource_A7529", (IAcpField) this.RadioWide.DigitalAudioOptions.RadWideAdvancedAuxPTTAudioSource_A7529);
    this.Field.Add("AdvancedAuxTransmitSensitivity_A7530", (IAcpField) this.RadioWide.DigitalAudioOptions.AdvancedAuxTransmitSensitivity_A7530);
    this.Field.Add("RadWideCombineTxWithRxFilteredAudio_44808", (IAcpField) this.RadioWide.DigitalAudioOptions.RadWideCombineTxWithRxFilteredAudio_44808);
    this.Field.Add("RadWideAudioOptionsSelectBluetoothMicForAuxPTTAudioSource_44819", (IAcpField) this.RadioWide.DigitalAudioOptions.RadWideAudioOptionsSelectBluetoothMicForAuxPTTAudioSource_44819);
    this.Field.Add("RadWideTransmitPowerLevelsTxPowerLevelConfigType_A41179", (IAcpField) this.RadioWide.TransmitPowerLevels.RadWideTransmitPowerLevelsTxPowerLevelConfigType_A41179);
    this.Field.Add("RadWidePowerLevelBandFrequency_A41063", (IAcpField) this.TxPowerLevelsByFrequencyRangeInner.TxPowerLevelsByFrequencyRangeInnerSection.RadWidePowerLevelBandFrequency_A41063);
    this.Field.Add("RadWideTransmitPowerLevelsFrequencyRangeStartMHz_A19994", (IAcpField) this.TxPowerLevelsByFrequencyRangeInner.TxPowerLevelsByFrequencyRangeInnerSection.RadWideTransmitPowerLevelsFrequencyRangeStartMHz_A19994);
    this.Field.Add("RadWideTxPowerLevelsNewBandPlan78MHzBandSelection_A41851", (IAcpField) this.RadioWide.TransmitPowerLevels.RadWideTxPowerLevelsNewBandPlan78MHzBandSelection_A41851);
    this.Field.Add("RadWideNumberOfTxPowerLevels", (IAcpField) this.RadioWide.TransmitPowerLevels.RadWideNumberOfTxPowerLevels);
    this.Field.Add("RadWideTransmitPowerLevelsFrequencyRangeEndMHz_A20037", (IAcpField) this.TxPowerLevelsByFrequencyRangeInner.TxPowerLevelsByFrequencyRangeInnerSection.RadWideTransmitPowerLevelsFrequencyRangeEndMHz_A20037);
    this.Field.Add("RadWideTransmitPowerLevelsTxPowerLevelMinimumW_A20038", (IAcpField) this.TxPowerLevelsByFrequencyRangeInner.TxPowerLevelsByFrequencyRangeInnerSection.RadWideTransmitPowerLevelsTxPowerLevelMinimumW_A20038);
    this.Field.Add("RadWideTransmitPowerLevelsConvTxPowerLevelMinimumW_A41173", (IAcpField) this.TxPowerLevelsByFrequencyRangeInner.TxPowerLevelsByFrequencyRangeInnerSection.RadWideTransmitPowerLevelsConvTxPowerLevelMinimumW_A41173);
    this.Field.Add("RadWideTransmitPowerLevelsTrkTxPowerLevelMinimumW_A41174", (IAcpField) this.TxPowerLevelsByFrequencyRangeInner.TxPowerLevelsByFrequencyRangeInnerSection.RadWideTransmitPowerLevelsTrkTxPowerLevelMinimumW_A41174);
    this.Field.Add("RadWideTransmitPowerLevelsTxPowerLevelLowW_A8153", (IAcpField) this.TxPowerLevelsByFrequencyRangeInner.TxPowerLevelsByFrequencyRangeInnerSection.RadWideTransmitPowerLevelsTxPowerLevelLowW_A8153);
    this.Field.Add("RadWideTransmitPowerLevelsConvTxPowerLevelLowW_A41175", (IAcpField) this.TxPowerLevelsByFrequencyRangeInner.TxPowerLevelsByFrequencyRangeInnerSection.RadWideTransmitPowerLevelsConvTxPowerLevelLowW_A41175);
    this.Field.Add("RadWideTransmitPowerLevelsTrkTxPowerLevelLowW_A41176", (IAcpField) this.TxPowerLevelsByFrequencyRangeInner.TxPowerLevelsByFrequencyRangeInnerSection.RadWideTransmitPowerLevelsTrkTxPowerLevelLowW_A41176);
    this.Field.Add("RadWideTransmitPowerLevelsTxPowerLevelMediumW", (IAcpField) this.TxPowerLevelsByFrequencyRangeInner.TxPowerLevelsByFrequencyRangeInnerSection.RadWideTransmitPowerLevelsTxPowerLevelMediumW);
    this.Field.Add("RadWideTransmitPowerLevelsTxPowerLevelMediumHighW", (IAcpField) this.TxPowerLevelsByFrequencyRangeInner.TxPowerLevelsByFrequencyRangeInnerSection.RadWideTransmitPowerLevelsTxPowerLevelMediumHighW);
    this.Field.Add("RadWideTransmitPowerLevelsTxPowerLevelHighW_A8152", (IAcpField) this.TxPowerLevelsByFrequencyRangeInner.TxPowerLevelsByFrequencyRangeInnerSection.RadWideTransmitPowerLevelsTxPowerLevelHighW_A8152);
    this.Field.Add("RadWideTransmitPowerLevelsTxPowerLevelMaximumW_A20039", (IAcpField) this.TxPowerLevelsByFrequencyRangeInner.TxPowerLevelsByFrequencyRangeInnerSection.RadWideTransmitPowerLevelsTxPowerLevelMaximumW_A20039);
    this.Field.Add("RadWidePowerLevelBandFrequency_A41864", (IAcpField) this.TxPowerLevelsByFrequencyRangeNewBandPlanInner.TxPowerLevelsByFrequencyRangeNewBandPlanInnerSection.RadWidePowerLevelBandFrequency_A41864);
    this.Field.Add("RadWideTransmitPowerLevelsFrequencyRangeStartMHz_A41856", (IAcpField) this.TxPowerLevelsByFrequencyRangeNewBandPlanInner.TxPowerLevelsByFrequencyRangeNewBandPlanInnerSection.RadWideTransmitPowerLevelsFrequencyRangeStartMHz_A41856);
    this.Field.Add("RadWideTransmitPowerLevelsFrequencyRangeEndMHz_A41857", (IAcpField) this.TxPowerLevelsByFrequencyRangeNewBandPlanInner.TxPowerLevelsByFrequencyRangeNewBandPlanInnerSection.RadWideTransmitPowerLevelsFrequencyRangeEndMHz_A41857);
    this.Field.Add("RadWideTransmitPowerLevelsTxPowerLevelMinimumW_A41858", (IAcpField) this.TxPowerLevelsByFrequencyRangeNewBandPlanInner.TxPowerLevelsByFrequencyRangeNewBandPlanInnerSection.RadWideTransmitPowerLevelsTxPowerLevelMinimumW_A41858);
    this.Field.Add("RadWideTransmitPowerLevelsConvTxPowerLevelMinimumW_A41863", (IAcpField) this.TxPowerLevelsByFrequencyRangeNewBandPlanInner.TxPowerLevelsByFrequencyRangeNewBandPlanInnerSection.RadWideTransmitPowerLevelsConvTxPowerLevelMinimumW_A41863);
    this.Field.Add("RadWideTransmitPowerLevelsTrkTxPowerLevelMinimumW_A41862", (IAcpField) this.TxPowerLevelsByFrequencyRangeNewBandPlanInner.TxPowerLevelsByFrequencyRangeNewBandPlanInnerSection.RadWideTransmitPowerLevelsTrkTxPowerLevelMinimumW_A41862);
    this.Field.Add("RadWideTransmitPowerLevelsTxPowerLevelLowW_A41855", (IAcpField) this.TxPowerLevelsByFrequencyRangeNewBandPlanInner.TxPowerLevelsByFrequencyRangeNewBandPlanInnerSection.RadWideTransmitPowerLevelsTxPowerLevelLowW_A41855);
    this.Field.Add("RadWideTransmitPowerLevelsConvTxPowerLevelLowW_A41861", (IAcpField) this.TxPowerLevelsByFrequencyRangeNewBandPlanInner.TxPowerLevelsByFrequencyRangeNewBandPlanInnerSection.RadWideTransmitPowerLevelsConvTxPowerLevelLowW_A41861);
    this.Field.Add("RadWideTransmitPowerLevelsTrkTxPowerLevelLowW_A41860", (IAcpField) this.TxPowerLevelsByFrequencyRangeNewBandPlanInner.TxPowerLevelsByFrequencyRangeNewBandPlanInnerSection.RadWideTransmitPowerLevelsTrkTxPowerLevelLowW_A41860);
    this.Field.Add("RadWideTransmitPowerLevelsTxPowerLevelMedNW", (IAcpField) this.TxPowerLevelsByFrequencyRangeNewBandPlanInner.TxPowerLevelsByFrequencyRangeNewBandPlanInnerSection.RadWideTransmitPowerLevelsTxPowerLevelMedNW);
    this.Field.Add("RadWideTransmitPowerLevelsTxPowerLevelMedHighNW", (IAcpField) this.TxPowerLevelsByFrequencyRangeNewBandPlanInner.TxPowerLevelsByFrequencyRangeNewBandPlanInnerSection.RadWideTransmitPowerLevelsTxPowerLevelMedHighNW);
    this.Field.Add("RadWideTransmitPowerLevelsTxPowerLevelHighW_A41854", (IAcpField) this.TxPowerLevelsByFrequencyRangeNewBandPlanInner.TxPowerLevelsByFrequencyRangeNewBandPlanInnerSection.RadWideTransmitPowerLevelsTxPowerLevelHighW_A41854);
    this.Field.Add("RadWideTransmitPowerLevelsTxPowerLevelMaximumW_A41859", (IAcpField) this.TxPowerLevelsByFrequencyRangeNewBandPlanInner.TxPowerLevelsByFrequencyRangeNewBandPlanInnerSection.RadWideTransmitPowerLevelsTxPowerLevelMaximumW_A41859);
    this.Field.Add("RadWideTPSFiregroundVoiceTxEndTone_A9655", (IAcpField) this.RadioWide.TPS.RadWideTPSFiregroundVoiceTxEndTone_A9655);
    this.Field.Add("RadWideTPSAudibleEmergencyBeaconsec_A7502", (IAcpField) this.RadioWide.TPS.RadWideTPSAudibleEmergencyBeaconsec_A7502);
    this.Field.Add("RadWideTPSAudibleEmergencyBeaconRouting_A41972", (IAcpField) this.RadioWide.TPS.RadWideTPSAudibleEmergencyBeaconRouting_A41972);
    this.Field.Add("RadWideTPSFiregroundEmergencyAlarmRetryRatesec_A7929", (IAcpField) this.RadioWide.TPS.RadWideTPSFiregroundEmergencyAlarmRetryRatesec_A7929);
    this.Field.Add("RadWideTPSFiregroundEmergencyCallDekeySidetone_A7936", (IAcpField) this.RadioWide.TPS.RadWideTPSFiregroundEmergencyCallDekeySidetone_A7936);
    this.Field.Add("RadWideTPSPTTTransmission_A41545", (IAcpField) this.RadioWide.TPS.RadWideTPSPTTTransmission_A41545);
    this.Field.Add("RadWideTPSEmergencyPTTTransmission_A41544", (IAcpField) this.RadioWide.TPS.RadWideTPSEmergencyPTTTransmission_A41544);
    this.Field.Add("RadWideTPSFiregroundPeriodicUpdateTimer_A33467", (IAcpField) this.RadioWide.Fireground.RadWideTPSFiregroundPeriodicUpdateTimer_A33467);
    this.Field.Add("RadWideTPSFiregroundRespondToPolls_A33573", (IAcpField) this.RadioWide.Fireground.RadWideTPSFiregroundRespondToPolls_A33573);
    this.Field.Add("RadWideTPSFiregroundEvacuationAcknowledgement_A33216", (IAcpField) this.RadioWide.Fireground.RadWideTPSFiregroundEvacuationAcknowledgement_A33216);
    this.Field.Add("RadWideFiregroundPTTTransmission_A33515", (IAcpField) this.RadioWide.Fireground.RadWideFiregroundPTTTransmission_A33515);
    this.Field.Add("RadWideTPSFiregroundEmergencyPTTTransmission_A33203", (IAcpField) this.RadioWide.Fireground.RadWideTPSFiregroundEmergencyPTTTransmission_A33203);
    this.Field.Add("RadWideLabtoolRxBandSplitName_A24797", (IAcpField) this.RxFrequencySplitFPPInner.RxFrequencySplitFPPInnerSection.RadWideLabtoolRxBandSplitName_A24797);
    this.Field.Add("RadWideLabtoolRxStartFrequencySplit_A9032", (IAcpField) this.RxFrequencySplitFPPInner.RxFrequencySplitFPPInnerSection.RadWideLabtoolRxStartFrequencySplit_A9032);
    this.Field.Add("RadWideLabtoolRxEndFrequencySplit_A9015", (IAcpField) this.RxFrequencySplitFPPInner.RxFrequencySplitFPPInnerSection.RadWideLabtoolRxEndFrequencySplit_A9015);
    this.Field.Add("RadWideLabtoolTxBandSplitName_A24799", (IAcpField) this.TxFrequencySplitFPPInner.TxFrequencySplitFPPInnerSection.RadWideLabtoolTxBandSplitName_A24799);
    this.Field.Add("RadWideLabtoolTxStartFrequencySplit_A9571", (IAcpField) this.TxFrequencySplitFPPInner.TxFrequencySplitFPPInnerSection.RadWideLabtoolTxStartFrequencySplit_A9571);
    this.Field.Add("RadWideLabtoolTxEndFrequencySplit_A9532", (IAcpField) this.TxFrequencySplitFPPInner.TxFrequencySplitFPPInnerSection.RadWideLabtoolTxEndFrequencySplit_A9532);
    this.Field.Add("RadWideLabtoolFCCNarrowBandStartFrequency_A38270", (IAcpField) this.FCCNarrowBandingFrequencySplitInner.FCCNarrowBandingFrequencySplitInnerSection.RadWideLabtoolFCCNarrowBandStartFrequency_A38270);
    this.Field.Add("RadWideLabtoolFCCNarrowBandEndFrequency_A38271", (IAcpField) this.FCCNarrowBandingFrequencySplitInner.FCCNarrowBandingFrequencySplitInnerSection.RadWideLabtoolFCCNarrowBandEndFrequency_A38271);
    this.Field.Add("RadWideUniversalRelayControllerEquipped_A37191", (IAcpField) this.RadioWide.LightbarPattern.RadWideUniversalRelayControllerEquipped_A37191);
    this.Field.Add("RadWideGenLgtBarName_A36505", (IAcpField) this.GeneralLightbarPatternInner.GeneralLightbarPatternInnerSection.RadWideGenLgtBarName_A36505);
    this.Field.Add("RadWideUniversalRelayControllerFatalError_A37194", (IAcpField) this.RadioWide.LightbarPattern.RadWideUniversalRelayControllerFatalError_A37194);
    this.Field.Add("RadWideGenLightBarPatternRelay1_A36506", (IAcpField) this.GeneralLightbarPatternInner.GeneralLightbarPatternInnerSection.RadWideGenLightBarPatternRelay1_A36506);
    this.Field.Add("RadWideGenLightBarPatternRelay2_A36507", (IAcpField) this.GeneralLightbarPatternInner.GeneralLightbarPatternInnerSection.RadWideGenLightBarPatternRelay2_A36507);
    this.Field.Add("RadWideGenLightBarPatternRelay3_A36508", (IAcpField) this.GeneralLightbarPatternInner.GeneralLightbarPatternInnerSection.RadWideGenLightBarPatternRelay3_A36508);
    this.Field.Add("RadWideGenLightBarPatternRelay4_A36509", (IAcpField) this.GeneralLightbarPatternInner.GeneralLightbarPatternInnerSection.RadWideGenLightBarPatternRelay4_A36509);
    this.Field.Add("RadWideGenLightBarPatternRelay5_A36510", (IAcpField) this.GeneralLightbarPatternInner.GeneralLightbarPatternInnerSection.RadWideGenLightBarPatternRelay5_A36510);
    this.Field.Add("RadWideGenLightBarPatternRelay6_A36511", (IAcpField) this.GeneralLightbarPatternInner.GeneralLightbarPatternInnerSection.RadWideGenLightBarPatternRelay6_A36511);
    this.Field.Add("RadWideGenLightBarPatternRelay7_A36512", (IAcpField) this.GeneralLightbarPatternInner.GeneralLightbarPatternInnerSection.RadWideGenLightBarPatternRelay7_A36512);
    this.Field.Add("RadWideGenLightBarPatternRelay8_A36513", (IAcpField) this.GeneralLightbarPatternInner.GeneralLightbarPatternInnerSection.RadWideGenLightBarPatternRelay8_A36513);
    this.Field.Add("RadWideGenLightBarPatternRelay9_A36515", (IAcpField) this.GeneralLightbarPatternInner.GeneralLightbarPatternInnerSection.RadWideGenLightBarPatternRelay9_A36515);
    this.Field.Add("RadWideGenLightBarPatternRelay10_A36516", (IAcpField) this.GeneralLightbarPatternInner.GeneralLightbarPatternInnerSection.RadWideGenLightBarPatternRelay10_A36516);
    this.Field.Add("RadWideGunlockRelocktimerName_A36521", (IAcpField) this.RelockTimerInner.RelockTimerInnerSection.RadWideGunlockRelocktimerName_A36521);
    this.Field.Add("RadWideGunlockRelocktimerTimer_A36522", (IAcpField) this.RelockTimerInner.RelockTimerInnerSection.RadWideGunlockRelocktimerTimer_A36522);
    this.Field.Add("RadWideBluetoothBluetoothEnable_A37028", (IAcpField) this.RadioWide.Bluetooth.RadWideBluetoothBluetoothEnable_A37028);
    this.Field.Add("RadWideBluetoothBluetoothRSMLED_A37039", (IAcpField) this.RadioWide.Bluetooth.RadWideBluetoothBluetoothRSMLED_A37039);
    this.Field.Add("RadWideBluetoothBluetoothTones_A37035", (IAcpField) this.RadioWide.Bluetooth.RadWideBluetoothBluetoothTones_A37035);
    this.Field.Add("RadWideBluetoothBluetoothPairingType_A37036", (IAcpField) this.RadioWide.Bluetooth.RadWideBluetoothBluetoothPairingType_A37036);
    this.Field.Add("RadWideStandardNFCTouchPairing_A44928", (IAcpField) this.RadioWide.Bluetooth.RadWideStandardNFCTouchPairing_A44928);
    this.Field.Add("RadWideSecureNFCTouchPairing_A44931", (IAcpField) this.RadioWide.Bluetooth.RadWideSecureNFCTouchPairing_A44931);
    this.Field.Add("RadWideBluetoothBluetoothReconnectTimer_A37037", (IAcpField) this.RadioWide.Bluetooth.RadWideBluetoothBluetoothReconnectTimer_A37037);
    this.Field.Add("RadWideBluetoothBluetoothDropTimer_A37038", (IAcpField) this.RadioWide.Bluetooth.RadWideBluetoothBluetoothDropTimer_A37038);
    this.Field.Add("RadWideBluetoothFriendlyNameEditable_A41182", (IAcpField) this.RadioWide.Bluetooth.RadWideBluetoothFriendlyNameEditable_A41182);
    this.Field.Add("RadWideBluetoothFriendlyName_A41181", (IAcpField) this.RadioWide.Bluetooth.RadWideBluetoothFriendlyName_A41181);
    this.Field.Add("RadWideBluetoothReplacePairingInfo_A41562", (IAcpField) this.RadioWide.Bluetooth.RadWideBluetoothReplacePairingInfo_A41562);
    this.Field.Add("RadWideBluetoothActiveRSMInternalMicIfNotBtMic_A41576", (IAcpField) this.RadioWide.Bluetooth.RadWideBluetoothActiveRSMInternalMicIfNotBtMic_A41576);
    this.Field.Add("RadWideBluetoothBluetoothDeviceInquiryDuration_41977", (IAcpField) this.RadioWide.Bluetooth.RadWideBluetoothBluetoothDeviceInquiryDuration_41977);
    this.Field.Add("RadWideBluetoothBluetoothDiscoverableExpirationTimer_41980", (IAcpField) this.RadioWide.Bluetooth.RadWideBluetoothBluetoothDiscoverableExpirationTimer_41980);
    this.Field.Add("RadWideBluetoothBluetoothPANNetworkAddress_41983", (IAcpField) this.RadioWide.Bluetooth.RadWideBluetoothBluetoothPANNetworkAddress_41983);
    this.Field.Add("RadWideBluetoothLegacyBluetoothPINPairing", (IAcpField) this.RadioWide.Bluetooth.RadWideBluetoothLegacyBluetoothPINPairing);
    this.Field.Add("RadWideBluetoothAudioBackwardsCompatibility_A44942", (IAcpField) this.RadioWide.Bluetooth.RadWideBluetoothAudioBackwardsCompatibility_A44942);
    this.Field.Add("RadWideBluetoothImproveAudioLatency_A44943", (IAcpField) this.RadioWide.Bluetooth.RadWideBluetoothImproveAudioLatency_A44943);
    this.Field.Add("RadWideBluetoothStandardPairing", (IAcpField) this.RadioWide.Bluetooth.RadWideBluetoothStandardPairing);
    this.Field.Add("RadWideBluetoothSecureMPPTouchPairing", (IAcpField) this.RadioWide.Bluetooth.RadWideBluetoothSecureMPPTouchPairing);
    this.Field.Add("RadWideAccessoryExtraLoudEarpieceInUse", (IAcpField) this.RadioWide.Accessory.RadWideAccessoryExtraLoudEarpieceInUse);
    this.Field.Add("RadWideAccessoryRSMSideForceSecureMode", (IAcpField) this.RadioWide.Accessory.RadWideAccessoryRSMSideForceSecureMode);
    this.Field.Add("AdvancedExternalMicOnly", (IAcpField) this.RadioWide.Depot.AdvancedExternalMicOnly);
    this.Field.Add("RadWideLabtoolSmartLowBatteryThreshold_A20201", (IAcpField) this.RadioWide.Labtool.RadWideLabtoolSmartLowBatteryThreshold_A20201);
    this.Field.Add("RadWideLabtoolEarlyWarningBatteryThreshold_A23977", (IAcpField) this.RadioWide.Labtool.RadWideLabtoolEarlyWarningBatteryThreshold_A23977);
    this.Field.Add("RadWideLabtoolUltraLowPowerSoldierMacCapable_A41710", (IAcpField) this.RadioWide.Labtool.RadWideLabtoolUltraLowPowerSoldierMacCapable_A41710);
    this.Field.Add("RadWideLabtoolEmergencyRevertCapable_A41918", (IAcpField) this.RadioWide.Labtool.RadWideLabtoolEmergencyRevertCapable_A41918);
    this.Field.Add("RadWideLabtoolAudibleBeaconRoutingCapable_A41974", (IAcpField) this.RadioWide.Labtool.RadWideLabtoolAudibleBeaconRoutingCapable_A41974);
    this.Field.Add("RadWideLabtoolAPX6000P25Radio_A42121", (IAcpField) this.RadioWide.Labtool.RadWideLabtoolAPX6000P25Radio_A42121);
    this.Field.Add("RadWideLabtoolSuppressEmergencyCallCapability_A42143", (IAcpField) this.RadioWide.Labtool.RadWideLabtoolSuppressEmergencyCallCapability_A42143);
    this.Field.Add("RadWideLabtoolMaritimeRadioSoftware_A42191", (IAcpField) this.RadioWide.Labtool.RadWideLabtoolMaritimeRadioSoftware_A42191);
    this.Field.Add("RadWideLabtoolMFKEmergencyAccess_A42216", (IAcpField) this.RadioWide.Labtool.RadWideLabtoolMFKEmergencyAccess_A42216);
    this.Field.Add("ManDownPersonalityConfigurableCapable_42082", (IAcpField) this.RadioWide.Labtool.ManDownPersonalityConfigurableCapable_42082);
    this.Field.Add("ToneEmergencyConfigurableCapable_42083", (IAcpField) this.RadioWide.Labtool.ToneEmergencyConfigurableCapable_42083);
    this.Field.Add("RadWideLabtoolRadioPassword_A8837", (IAcpField) this.RadioWide.Labtool.RadWideLabtoolRadioPassword_A8837);
    this.Field.Add("RadWideLabtoolConsoletteModelEnable_A7713", (IAcpField) this.RadioWide.Labtool.RadWideLabtoolConsoletteModelEnable_A7713);
    this.Field.Add("RadWideLabtoolFatalError_A8015", (IAcpField) this.RadioWide.Labtool.RadWideLabtoolFatalError_A8015);
    this.Field.Add("RadWideLabtoolArchiveReadPasswordEnable_A7462", (IAcpField) this.RadioWide.Labtool.RadWideLabtoolArchiveReadPasswordEnable_A7462);
    this.Field.Add("RadWideLabtoolControlHeadSelection_A7723", (IAcpField) this.RadioWide.Labtool.RadWideLabtoolControlHeadSelection_A7723);
    this.Field.Add("RadWideLabtoolKeypadType_A8372", (IAcpField) this.RadioWide.Labtool.RadWideLabtoolKeypadType_A8372);
    this.Field.Add("RadWideLabtoolZoneSelectorOnSwitch_A19550", (IAcpField) this.RadioWide.Labtool.RadWideLabtoolZoneSelectorOnSwitch_A19550);
    this.Field.Add("RadWideLabtoolChannelSelectorOnSwitch_A19551", (IAcpField) this.RadioWide.Labtool.RadWideLabtoolChannelSelectorOnSwitch_A19551);
    this.Field.Add("RadWideLabtoolDisplayType_A7887", (IAcpField) this.RadioWide.Labtool.RadWideLabtoolDisplayType_A7887);
    this.Field.Add("RadWideLabtoolFlipDisplayOption_A8140", (IAcpField) this.RadioWide.Labtool.RadWideLabtoolFlipDisplayOption_A8140);
    this.Field.Add("RadWideLabtoolFreeRevolvingRotary_A8147", (IAcpField) this.RadioWide.Labtool.RadWideLabtoolFreeRevolvingRotary_A8147);
    this.Field.Add("RadWideLabtoolRadioWritePasswordEnable_A8889", (IAcpField) this.RadioWide.Labtool.RadWideLabtoolRadioWritePasswordEnable_A8889);
    this.Field.Add("RadWideLabtoolRadioReadPasswordEnable_A8869", (IAcpField) this.RadioWide.Labtool.RadWideLabtoolRadioReadPasswordEnable_A8869);
    this.Field.Add("RadWideLabtoolDisplayContrastConfiguration_A7873", (IAcpField) this.RadioWide.Labtool.RadWideLabtoolDisplayContrastConfiguration_A7873);
    this.Field.Add("RadWideLabtoolControlHeadConfiguration_A7722", (IAcpField) this.RadioWide.Labtool.RadWideLabtoolControlHeadConfiguration_A7722);
    this.Field.Add("RadWideLabtoolReadWriteVoiceFiles_A8893", (IAcpField) this.RadioWide.Labtool.RadWideLabtoolReadWriteVoiceFiles_A8893);
    this.Field.Add("RadWideLabtoolSirenPaFatalError_A9141", (IAcpField) this.RadioWide.Labtool.RadWideLabtoolSirenPaFatalError_A9141);
    this.Field.Add("RadWideLabtoolSirenPaOnly_A9142", (IAcpField) this.RadioWide.Labtool.RadWideLabtoolSirenPaOnly_A9142);
    this.Field.Add("RadWideLabtoolSirenPaSystemLookup_A9143", (IAcpField) this.RadioWide.Labtool.RadWideLabtoolSirenPaSystemLookup_A9143);
    this.Field.Add("RadWideLabtoolSirenAndLightsKeypadEnable_A41413", (IAcpField) this.RadioWide.Labtool.RadWideLabtoolSirenAndLightsKeypadEnable_A41413);
    this.Field.Add("TrunkingRadioInhibited_A19483", (IAcpField) this.RadioWide.Labtool.TrunkingRadioInhibited_A19483);
    this.Field.Add("RadWideLabtoolDynamicZoneCable_A41258", (IAcpField) this.RadioWide.Labtool.RadWideLabtoolDynamicZoneCable_A41258);
    this.Field.Add("RadWideEmergencyRxTxAlertToneSet_A41508", (IAcpField) this.RadioWide.Labtool.RadWideEmergencyRxTxAlertToneSet_A41508);
    this.Field.Add("RadWideRadioKilled_A41559", (IAcpField) this.RadioWide.Labtool.RadWideRadioKilled_A41559);
    this.Field.Add("RadWideLabtoolEncryptPassword_A41695", (IAcpField) this.RadioWide.Labtool.RadWideLabtoolEncryptPassword_A41695);
    this.Field.Add("RadWideLabtoolEncryptedPINPassword_A41702", (IAcpField) this.RadioWide.Labtool.RadWideLabtoolEncryptedPINPassword_A41702);
    this.Field.Add("RadWideFeaturesEnableInvalidSIMNotification_A44945", (IAcpField) this.RadioWide.Features.RadWideFeaturesEnableInvalidSIMNotification_A44945);
    this.Field.Add("RadWideFeaturesChanChangeOnOffHookEnable_A42354", (IAcpField) this.RadioWide.Features.RadWideFeaturesChanChangeOnOffHookEnable_A42354);
    this.Field.Add("RadWideFeaturesTargetZoneOnOffHook_A42355", (IAcpField) this.RadioWide.Features.RadWideFeaturesTargetZoneOnOffHook_A42355);
    this.Field.Add("RadWideFeaturesTargetChanOnOffHook_A42356", (IAcpField) this.RadioWide.Features.RadWideFeaturesTargetChanOnOffHook_A42356);
    this.Field.Add("RadWideLocP25LocationReporting_42412", (IAcpField) this.RadioWide.Location.RadWideLocP25LocationReporting_42412);
    this.Field.Add("RadWideLocationDisplayPeerLocation_42433", (IAcpField) this.RadioWide.Location.RadWideLocationDisplayPeerLocation_42433);
    this.Field.Add("RadWideFeaturesZoneCloneEnable_43130", (IAcpField) this.RadioWide.Features.RadWideFeaturesZoneCloneEnable_43130);
    this.Field.Add("TEN_DIGIT_RL_PSWD_capable_43711", (IAcpField) this.RadioWide.Labtool.TEN_DIGIT_RL_PSWD_capable_43711);
    this.Field.Add("AllowPSUSecure_43809", (IAcpField) this.RadioWide.Labtool.AllowPSUSecure_43809);
    this.Field.Add("UCLContactsLimitationEnhancement_43811", (IAcpField) this.RadioWide.Labtool.UCLContactsLimitationEnhancement_43811);
    this.Field.Add("DVRSRangeExt_44809", (IAcpField) this.RadioWide.Labtool.DVRSRangeExt_44809);
    this.Field.Add("RadWideLabtoolADPGatingPCIBit_44813", (IAcpField) this.RadioWide.Labtool.RadWideLabtoolADPGatingPCIBit_44813);
    this.Field.Add("RadWideLabtoolSupportO3ControlHeadPCIBit_44884", (IAcpField) this.RadioWide.Labtool.RadWideLabtoolSupportO3ControlHeadPCIBit_44884);
    this.Field.Add("RadWideLabtoolAnalogWideBandDataPCIBit_44885", (IAcpField) this.RadioWide.Labtool.RadWideLabtoolAnalogWideBandDataPCIBit_44885);
    this.Field.Add("RadWideLabtoolMaceAdpKeyLoadingCapablePCIBit", (IAcpField) this.RadioWide.Labtool.RadWideLabtoolMaceAdpKeyLoadingCapablePCIBit);
    this.Field.Add("RadWideLabtool4PowerLevelCapablePCIBit", (IAcpField) this.RadioWide.Labtool.RadWideLabtool4PowerLevelCapablePCIBit);
    this.Field.Add("RadWideFeaturesSmartMessagingSmartMessageMode", (IAcpField) this.RadioWide.Features.RadWideFeaturesSmartMessagingSmartMessageMode);
    this.Field.Add("RadWideFeaturesMapping", (IAcpField) this.RadioWide.Location.RadWideFeaturesMapping);
    this.Field.Add("RadWideFeaturesRadioInhibitUIEnabled_44914", (IAcpField) this.RadioWide.Features.RadWideFeaturesRadioInhibitUIEnabled_44914);
    this.Field.Add("RadWideFeaturesRadioInhibitDisplayTextLine1_44915", (IAcpField) this.RadioWide.Features.RadWideFeaturesRadioInhibitDisplayTextLine1_44915);
    this.Field.Add("RadWideFeaturesRadioInhibitDisplayTextLine2_44916", (IAcpField) this.RadioWide.Features.RadWideFeaturesRadioInhibitDisplayTextLine2_44916);
    this.Field.Add("RadWideFeaturesCloudServicesDisabled", (IAcpField) this.RadioWide.Features.RadWideFeaturesCloudServicesDisabled);
    this.Field.Add("RadWideMultiCodeplugEnable", (IAcpField) this.RadioWide.MultiCodeplug.RadWideMultiCodeplugEnable);
    this.Field.Add("RadWideMultiCodeplugDelete", (IAcpField) this.RadioWide.MultiCodeplug.RadWideMultiCodeplugDelete);
    this.Field.Add("RadWideLabtoolSilentEmergencyCapablePCIBit", (IAcpField) this.RadioWide.Labtool.RadWideLabtoolSilentEmergencyCapablePCIBit);
    this.Field.Add("RadWideLabtoolWirelessMicWithFallBackToWiredRSMPCIBit", (IAcpField) this.RadioWide.Labtool.RadWideLabtoolWirelessMicWithFallBackToWiredRSMPCIBit);
    this.Field.Add("RadWideLabtoolExpandedVATTSFileCapablePCIBit", (IAcpField) this.RadioWide.Labtool.RadWideLabtoolExpandedVATTSFileCapablePCIBit);
  }

  private void AddDataProfile()
  {
    this.Field.Add("DataProfGeneralkeyofDataProfiles_A19446", (IAcpField) this.DataProfiles.General.DataProfGeneralkeyofDataProfiles_A19446);
    this.Field.Add("DataProfGeneralDataProfileType_A21320", (IAcpField) this.DataProfiles.General.DataProfGeneralDataProfileType_A21320);
    this.Field.Add("DataProfGeneralPacketDataMode_A8689", (IAcpField) this.DataProfiles.General.DataProfGeneralPacketDataMode_A8689);
    this.Field.Add("DataProfGeneralQueueDwellTimersec_A8806", (IAcpField) this.DataProfiles.General.DataProfGeneralQueueDwellTimersec_A8806);
    this.Field.Add("DataProfGeneralDataScanPreambleLength_A7798", (IAcpField) this.DataProfiles.General.DataProfGeneralDataScanPreambleLength_A7798);
    this.Field.Add("TrkSysLabtoolRxVoiceInterruptsData_A9043", (IAcpField) this.DataProfiles.General.TrkSysLabtoolRxVoiceInterruptsData_A9043);
    this.Field.Add("DataProfGeneralLimitedBroadcast_A8431", (IAcpField) this.DataProfiles.General.DataProfGeneralLimitedBroadcast_A8431);
    this.Field.Add("DataProfGeneralAutoGenerateIPAddress_A19320", (IAcpField) this.DataProfiles.General.DataProfGeneralAutoGenerateIPAddress_A19320);
    this.Field.Add("DataWideGeneralNATEnable_A38866", (IAcpField) this.DataProfiles.General.DataWideGeneralNATEnable_A38866);
    this.Field.Add("DataProfGeneralAutoGenerateTargetIPAddress_A41697", (IAcpField) this.DataProfiles.General.DataProfGeneralAutoGenerateTargetIPAddress_A41697);
    this.Field.Add("DataProfGeneralSubscriberIPAddress_A21157", (IAcpField) this.DataProfiles.General.DataProfGeneralSubscriberIPAddress_A21157);
    this.Field.Add("DataProfGeneralMobileComputerIPAddress_A8523", (IAcpField) this.DataProfiles.General.DataProfGeneralMobileComputerIPAddress_A8523);
    this.Field.Add("DataWideGeneralPeerIPAddressAssignmentType_A22263", (IAcpField) this.DataProfiles.General.DataWideGeneralPeerIPAddressAssignmentType_A22263);
    this.Field.Add("DataProfilesGeneralBTDUNSUIPAddress_A41126", (IAcpField) this.DataProfiles.General.DataProfilesGeneralBTDUNSUIPAddress_A41126);
    this.Field.Add("DataProfilesGeneralBTDUNPeerIPAddress_A41127", (IAcpField) this.DataProfiles.General.DataProfilesGeneralBTDUNPeerIPAddress_A41127);
    this.Field.Add("DataProfilesGeneralBTDUNPeerIPAddressAssignmentType_A41128", (IAcpField) this.DataProfiles.General.DataProfilesGeneralBTDUNPeerIPAddressAssignmentType_A41128);
    this.Field.Add("DataProfGeneralSubscriberAirInterfaceIPAddress_A9220", (IAcpField) this.DataProfiles.General.DataProfGeneralSubscriberAirInterfaceIPAddress_A9220);
    this.Field.Add("DataConfigDataProfIntersystemData_A42381", (IAcpField) this.DataProfiles.General.DataConfigDataProfIntersystemData_A42381);
    this.Field.Add("DataConfigDataProfRandomHoldOffTime_A36552", (IAcpField) this.DataProfiles.General.DataConfigDataProfRandomHoldOffTime_A36552);
    this.Field.Add("DataConfigDataProfContextActivationHoldoffTime_A36551", (IAcpField) this.DataProfiles.General.DataConfigDataProfContextActivationHoldoffTime_A36551);
    this.Field.Add("DataConigurationDataProfilePacketDataRegistrationVersion_A36210", (IAcpField) this.DataProfiles.General.DataConigurationDataProfilePacketDataRegistrationVersion_A36210);
    this.Field.Add("DataConfigDataProfIPHeaderCompressionEnable_A36190", (IAcpField) this.DataProfiles.General.DataConfigDataProfIPHeaderCompressionEnable_A36190);
    this.Field.Add("DataProfFeaturesTerminalData_A9288", (IAcpField) this.DataProfiles.Features.DataProfFeaturesTerminalData_A9288);
    this.Field.Add("TrkSysLabtoolRetransmissionTimersec_A8672", (IAcpField) this.DataProfiles.Features.TrkSysLabtoolRetransmissionTimersec_A8672);
    this.Field.Add("DataProfFeatureContxActivHldoffMode_A36469", (IAcpField) this.DataProfiles.Features.DataProfFeatureContxActivHldoffMode_A36469);
    this.Field.Add("DataProfFeaturesARSRetryTimermin_A7466", (IAcpField) this.DataProfiles.Features.DataProfFeaturesARSRetryTimermin_A7466);
    this.Field.Add("DataProfFeaturesApplicationTimeBetweenAttemptssec_A7460", (IAcpField) this.DataProfiles.Features.DataProfFeaturesApplicationTimeBetweenAttemptssec_A7460);
    this.Field.Add("DataProfFeaturesApplicationNumberofAttempts_A7458", (IAcpField) this.DataProfiles.Features.DataProfFeaturesApplicationNumberofAttempts_A7458);
    this.Field.Add("DataProfFeaturesARSMode_A7465", (IAcpField) this.DataProfiles.Features.DataProfFeaturesARSMode_A7465);
    this.Field.Add("DataProfFeaturesAutomaticRegistrationServerAddress_A7524", (IAcpField) this.DataProfiles.Features.DataProfFeaturesAutomaticRegistrationServerAddress_A7524);
    this.Field.Add("DatProFeaturesPADMode_A20536", (IAcpField) this.DataProfiles.Features.DatProFeaturesPADMode_A20536);
    this.Field.Add("DatProFeaturesStartSequence_A20537", (IAcpField) this.DataProfiles.Features.DatProFeaturesStartSequence_A20537);
    this.Field.Add("DatProFeaturesStopSequence_A20538", (IAcpField) this.DataProfiles.Features.DatProFeaturesStopSequence_A20538);
    this.Field.Add("DatProFeaturesEscapeSequence_A20539", (IAcpField) this.DataProfiles.Features.DatProFeaturesEscapeSequence_A20539);
    this.Field.Add("DatProFeaturesReceiveIdleTimeOut_A20540", (IAcpField) this.DataProfiles.Features.DatProFeaturesReceiveIdleTimeOut_A20540);
    this.Field.Add("DatProFeaturesTransmissionInhibitValue_A20541", (IAcpField) this.DataProfiles.Features.DatProFeaturesTransmissionInhibitValue_A20541);
    this.Field.Add("DatProFeaturesMaximumBufferThreshold_A20542", (IAcpField) this.DataProfiles.Features.DatProFeaturesMaximumBufferThreshold_A20542);
    this.Field.Add("DatProFeaturesDestinationAddress_A20543", (IAcpField) this.DataProfiles.Features.DatProFeaturesDestinationAddress_A20543);
    this.Field.Add("DatProFeaturesDestinationPort_A20544", (IAcpField) this.DataProfiles.Features.DatProFeaturesDestinationPort_A20544);
    this.Field.Add("DataProfilesDACOperationalMode_A36199", (IAcpField) this.DACListInner.DACListInnerSection.DataProfilesDACOperationalMode_A36199);
    this.Field.Add("DataProfilesDACSlotSize_A36203", (IAcpField) this.DACListInner.DACListInnerSection.DataProfilesDACSlotSize_A36203);
    this.Field.Add("DataProfilesTrunkingGroupID_ASTRO25DataGroupID_A36204", (IAcpField) this.TrunkingGroupIDListInner.TrunkingGroupIDListInnerSection.DataProfilesTrunkingGroupID_ASTRO25DataGroupID_A36204);
    this.Field.Add("DataProfLTEEnabled_A42075", (IAcpField) this.DataProfiles.LTE.DataProfLTEEnabled_A42075);
    this.Field.Add("DataProfBroadbandSource_A42858", (IAcpField) this.DataProfiles.LTE.DataProfBroadbandSource_A42858);
    this.Field.Add("DataProfNLSSecClrStrp_A36415", (IAcpField) this.DataProfiles.NetworkLayerSecurity.DataProfNLSSecClrStrp_A36415);
    this.Field.Add("DataProfNLSKMFProfSele_A36419", (IAcpField) this.DataProfiles.NetworkLayerSecurity.DataProfNLSKMFProfSele_A36419);
    this.Field.Add("DataProfNLSKeySele_A36410", (IAcpField) this.DataProfiles.NetworkLayerSecurity.DataProfNLSKeySele_A36410);
    this.Field.Add("DataProfNLSEncGatewayAddr_A36412", (IAcpField) this.DataProfiles.NetworkLayerSecurity.DataProfNLSEncGatewayAddr_A36412);
    this.Field.Add("DataProfNLSAllowRxClrPackData_A36414", (IAcpField) this.DataProfiles.NetworkLayerSecurity.DataProfNLSAllowRxClrPackData_A36414);
    this.Field.Add("DataProfVPNSecClrStrp_A42120", (IAcpField) this.DataProfiles.NetworkLayerSecurity.DataProfVPNSecClrStrp_A42120);
    this.Field.Add("DataProfVPNKeySelection_42280", (IAcpField) this.DataProfiles.NetworkLayerSecurity.DataProfVPNKeySelection_42280);
    this.Field.Add("DataProfVPNGatewayIPAddress_A42079", (IAcpField) this.DataProfiles.NetworkLayerSecurity.DataProfVPNGatewayIPAddress_A42079);
    this.Field.Add("DataProfVPNMessageRetransmissionTime_A42209", (IAcpField) this.DataProfiles.NetworkLayerSecurity.DataProfVPNMessageRetransmissionTime_A42209);
    this.Field.Add("DataProfVPNMessageRetransmissionAttempts_A42210", (IAcpField) this.DataProfiles.NetworkLayerSecurity.DataProfVPNMessageRetransmissionAttempts_A42210);
    this.Field.Add("DataProfVPNDeadPeerDetectionInterval_A42211", (IAcpField) this.DataProfiles.NetworkLayerSecurity.DataProfVPNDeadPeerDetectionInterval_A42211);
    this.Field.Add("DataProfVPNRekeyMargin_A42212", (IAcpField) this.DataProfiles.NetworkLayerSecurity.DataProfVPNRekeyMargin_A42212);
    this.Field.Add("DataProfVPNRekeyAttempts_A42213", (IAcpField) this.DataProfiles.NetworkLayerSecurity.DataProfVPNRekeyAttempts_A42213);
    this.Field.Add("DataProfEIDByPassListIPAddr_A36417", (IAcpField) this.EIDBypassListInner.EIDBypassListInnerSection.DataProfEIDByPassListIPAddr_A36417);
    this.Field.Add("DataProfEIDByPassListAddrType_A36418", (IAcpField) this.EIDBypassListInner.EIDBypassListInnerSection.DataProfEIDByPassListAddrType_A36418);
    this.Field.Add("DatProFeaturesPortListSelection_A42011", (IAcpField) this.DataProfiles.EnhancedData.DatProFeaturesPortListSelection_A42011);
    this.Field.Add("AllowEnhancedDataToBeSentOnClassicDataChannel_42014", (IAcpField) this.DataProfiles.EnhancedData.AllowEnhancedDataToBeSentOnClassicDataChannel_42014);
    this.Field.Add("QueueDwellTimerSec_42015", (IAcpField) this.DataProfiles.EnhancedData.QueueDwellTimerSec_42015);
    this.Field.Add("DataProfFeaturesDirLocReg_A42332", (IAcpField) this.DataProfiles.Features.DataProfFeaturesDirLocReg_A42332);
    this.Field.Add("DataProfFeaturesLocServerIPAddr_A42333", (IAcpField) this.DataProfiles.Features.DataProfFeaturesLocServerIPAddr_A42333);
    this.Field.Add("DatProSendDataDurEmerHangtime_A43103", (IAcpField) this.DataProfiles.EnhancedData.DatProSendDataDurEmerHangtime_A43103);
    this.Field.Add("DataProfLTEBackupPTTGatewayHostname_A43621", (IAcpField) this.DataProfiles.LTE.DataProfLTEBackupPTTGatewayHostname_A43621);
    this.Field.Add("DataProfLTEBackupPTTGatewayPort_A43618", (IAcpField) this.DataProfiles.LTE.DataProfLTEBackupPTTGatewayPort_A43618);
  }

  private void AddRadioInfomation()
  {
    this.Field.Add("RadInfoGeneralCodeplugAlias_A7684", (IAcpField) this.RadioInformation.General.RadInfoGeneralCodeplugAlias_A7684);
    this.Field.Add("RadInfoGeneralCodeplugName", (IAcpField) this.RadioInformation.General.RadInfoGeneralCodeplugName);
    this.Field.Add("RadInfoGeneralModelNumber_A8539", (IAcpField) this.RadioInformation.General.RadInfoGeneralModelNumber_A8539);
    this.Field.Add("RadInfoGeneralMaximumChannels_A11479", (IAcpField) this.RadioInformation.General.RadInfoGeneralMaximumChannels_A11479);
    this.Field.Add("RadInfoGeneralSerialNumber_A9122", (IAcpField) this.RadioInformation.General.RadInfoGeneralSerialNumber_A9122);
    this.Field.Add("RadInfoGeneralElectronicSerialNumber_A41744", (IAcpField) this.RadioInformation.General.RadInfoGeneralElectronicSerialNumber_A41744);
    this.Field.Add("RadInfoGeneralMACAddress_A41837", (IAcpField) this.RadioInformation.General.RadInfoGeneralMACAddress_A41837);
    this.Field.Add("RadInfoGeneralWiFiMACAddress_42509", (IAcpField) this.RadioInformation.General.RadInfoGeneralWiFiMACAddress_42509);
    this.Field.Add("RadInfoGeneralWiFiBTMACAddress_42510", (IAcpField) this.RadioInformation.General.RadInfoGeneralWiFiBTMACAddress_42510);
    this.Field.Add("RadInfoGeneralPrimaryFrequencyBand_A12713", (IAcpField) this.RadioInformation.General.RadInfoGeneralPrimaryFrequencyBand_A12713);
    this.Field.Add("RadInfoGeneralSecondaryFrequencyBand_A12715", (IAcpField) this.RadioInformation.General.RadInfoGeneralSecondaryFrequencyBand_A12715);
    this.Field.Add("RadInfoGeneralRegionalGovernance_A36710", (IAcpField) this.RadioInformation.General.RadInfoGeneralRegionalGovernance_A36710);
    this.Field.Add("RadInfoGeneralWiFiRegulatoryRegion_A43772", (IAcpField) this.RadioInformation.General.RadInfoGeneralWiFiRegulatoryRegion_A43772);
    this.Field.Add("RadInfoGeneralCodeplugVersion_A7683", (IAcpField) this.RadioInformation.General.RadInfoGeneralCodeplugVersion_A7683);
    this.Field.Add("RadInfoGeneralFirmwareVersion_A8124", (IAcpField) this.RadioInformation.General.RadInfoGeneralFirmwareVersion_A8124);
    this.Field.Add("RadInfoGeneralPrimaryFrequencyBandVHF_A42545", (IAcpField) this.RadioInformation.General.RadInfoGeneralPrimaryFrequencyBandVHF_A42545);
    this.Field.Add("RadInfoGeneralPrimaryFrequencyBandUHF1_A42546", (IAcpField) this.RadioInformation.General.RadInfoGeneralPrimaryFrequencyBandUHF1_A42546);
    this.Field.Add("RadInfoGeneralPrimaryFrequencyBandUHF2_A42547", (IAcpField) this.RadioInformation.General.RadInfoGeneralPrimaryFrequencyBandUHF2_A42547);
    this.Field.Add("RadInfoGeneralPrimaryFrequencyBand700_A42543", (IAcpField) this.RadioInformation.General.RadInfoGeneralPrimaryFrequencyBand700_A42543);
    this.Field.Add("RadInfoGeneralPrimaryFrequencyBand800_A42544", (IAcpField) this.RadioInformation.General.RadInfoGeneralPrimaryFrequencyBand800_A42544);
    this.Field.Add("RadInfoGeneralPrimaryFrequencyBand900_A42548", (IAcpField) this.RadioInformation.General.RadInfoGeneralPrimaryFrequencyBand900_A42548);
    this.Field.Add("RadInfoGeneralDSPVersion_A7892", (IAcpField) this.RadioInformation.General.RadInfoGeneralDSPVersion_A7892);
    this.Field.Add("RadInfoGeneralUCMVersion_A9591", (IAcpField) this.RadioInformation.General.RadInfoGeneralUCMVersion_A9591);
    this.Field.Add("RadInfoGeneralSecureHardwareType", (IAcpField) this.RadioInformation.General.RadInfoGeneralSecureHardwareType);
    this.Field.Add("RadInfoGeneralSecureHardwareVersion", (IAcpField) this.RadioInformation.General.RadInfoGeneralSecureHardwareVersion);
    this.Field.Add("RadInfoGeneralTuningVersion_A9509", (IAcpField) this.RadioInformation.General.RadInfoGeneralTuningVersion_A9509);
    this.Field.Add("RadInfoGeneralPSDTVersion_A8768", (IAcpField) this.RadioInformation.General.RadInfoGeneralPSDTVersion_A8768);
    this.Field.Add("RadInfoGeneralBootloaderVersion_A7567", (IAcpField) this.RadioInformation.General.RadInfoGeneralBootloaderVersion_A7567);
    this.Field.Add("RadInfoGeneralNautilusVersion_A8564", (IAcpField) this.RadioInformation.General.RadInfoGeneralNautilusVersion_A8564);
    this.Field.Add("RadInfoGeneralInstalledTxmCertificate", (IAcpField) this.RadioInformation.General.RadInfoGeneralInstalledTxmCertificate);
    this.Field.Add("RadInfoLabtoolLastProgrammedDateDBValue_A8411", (IAcpField) this.RadioInformation.Tracking.RadInfoLabtoolLastProgrammedDateDBValue_A8411);
    this.Field.Add("RadInfoTrackingSource1_A9171", (IAcpField) this.RadioInformation.Tracking.RadInfoTrackingSource1_A9171);
    this.Field.Add("RadInfoLabtoolBornOnDateDBValue_A7568", (IAcpField) this.RadioInformation.Tracking.RadInfoLabtoolBornOnDateDBValue_A7568);
    this.Field.Add("RadInfoTrackingCodeplugVersion_A7688", (IAcpField) this.RadioInformation.Tracking.RadInfoTrackingCodeplugVersion_A7688);
    this.Field.Add("RadInfoTrackingSource2_A8625", (IAcpField) this.RadioInformation.Tracking.RadInfoTrackingSource2_A8625);
    this.Field.Add("RadInfoFLASHportFLASHcode_A8132", (IAcpField) this.RadioInformation.FLASHport.RadInfoFLASHportFLASHcode_A8132);
    this.Field.Add("RadInfoFLASHportNumberofTimesFlashed_A8581", (IAcpField) this.RadioInformation.FLASHport.RadInfoFLASHportNumberofTimesFlashed_A8581);
    this.Field.Add("RadInfoFLASHportIButton_A8217", (IAcpField) this.RadioInformation.FLASHport.RadInfoFLASHportIButton_A8217);
    this.Field.Add("RadInfoFLASHportLastUpgradeSource_A8387", (IAcpField) this.RadioInformation.FLASHport.RadInfoFLASHportLastUpgradeSource_A8387);
    this.Field.Add("RadInfoLabtoolLastFLASHKeyDateStampData_A8388", (IAcpField) this.RadioInformation.FLASHport.RadInfoLabtoolLastFLASHKeyDateStampData_A8388);
    this.Field.Add("RadInfoAdvancedSystemKeyInfoAdvancedSystemKeyLastProgramDateCP_A7410", (IAcpField) this.ASKProgrammingHistoryInner.ASKProgrammingHistoryInnerSection.RadInfoAdvancedSystemKeyInfoAdvancedSystemKeyLastProgramDateCP_A7410);
    this.Field.Add("RadInfoAdvancedSystemKeyInfoAdvancedSystemKeySerialNumber_A7411", (IAcpField) this.ASKProgrammingHistoryInner.ASKProgrammingHistoryInnerSection.RadInfoAdvancedSystemKeyInfoAdvancedSystemKeySerialNumber_A7411);
    this.Field.Add("RadInfoFrequencyRangesOpenFrequency_A22699", (IAcpField) this.RadioInformation.FrequencyRanges.RadInfoFrequencyRangesOpenFrequency_A22699);
    this.Field.Add("RadInfoFrequencyRangesExtendedUHFR1Capable_A41443", (IAcpField) this.RadioInformation.FrequencyRanges.RadInfoFrequencyRangesExtendedUHFR1Capable_A41443);
    this.Field.Add("RadInfoFrequencyRangesAllowInvalidFrequencies_A12493", (IAcpField) this.RadioInformation.FrequencyRanges.RadInfoFrequencyRangesAllowInvalidFrequencies_A12493);
    this.Field.Add("RadInfoFrequencyRangesVHFUsedinCodeplug_A8481", (IAcpField) this.RadioInformation.FrequencyRanges.RadInfoFrequencyRangesVHFUsedinCodeplug_A8481);
    this.Field.Add("RadInfoFrequencyRangesUHF1UsedinCodeplug_A8504", (IAcpField) this.RadioInformation.FrequencyRanges.RadInfoFrequencyRangesUHF1UsedinCodeplug_A8504);
    this.Field.Add("RadInfoFrequencyRangesUHF2UsedinCodeplug_A8507", (IAcpField) this.RadioInformation.FrequencyRanges.RadInfoFrequencyRangesUHF2UsedinCodeplug_A8507);
    this.Field.Add("RadInfoFrequencyRanges7800MHzUsedinCodeplug_A8512", (IAcpField) this.RadioInformation.FrequencyRanges.RadInfoFrequencyRanges7800MHzUsedinCodeplug_A8512);
    this.Field.Add("RadInfoFrequencyRanges900MHzUsedinCodeplug_A8516", (IAcpField) this.RadioInformation.FrequencyRanges.RadInfoFrequencyRanges900MHzUsedinCodeplug_A8516);
    this.Field.Add("RadInfoOptionExpansionBoardBoardName_A37549", (IAcpField) this.RadioInformation.OptionExpansionBoard.RadInfoOptionExpansionBoardBoardName_A37549);
    this.Field.Add("RadInfoOptionExpansionBoardBoardType_A37049", (IAcpField) this.RadioInformation.OptionExpansionBoard.RadInfoOptionExpansionBoardBoardType_A37049);
    this.Field.Add("RadInfoOptionExpansionBoardBoardFirmwareVersion_A37048", (IAcpField) this.RadioInformation.OptionExpansionBoard.RadInfoOptionExpansionBoardBoardFirmwareVersion_A37048);
    this.Field.Add("RadInfoLabtoolFPPStatus_A8144", (IAcpField) this.RadioInformation.Labtool.RadInfoLabtoolFPPStatus_A8144);
    this.Field.Add("RadInfoLabtoolCodeplugAllowsExpandedAustraliaFrequencies_A7685", (IAcpField) this.RadioInformation.Labtool.RadInfoLabtoolCodeplugAllowsExpandedAustraliaFrequencies_A7685);
    this.Field.Add("RadInfoLabtoolZoneCloningStatus_A9721", (IAcpField) this.RadioInformation.Labtool.RadInfoLabtoolZoneCloningStatus_A9721);
    this.Field.Add("RadInfoLabtoolExternalRadioBlockExternalCodeplugSize_A7991", (IAcpField) this.RadioInformation.Labtool.RadInfoLabtoolExternalRadioBlockExternalCodeplugSize_A7991);
    this.Field.Add("RadInfoLabtoolQA02006APX6000XE_A38951", (IAcpField) this.RadioInformation.Labtool.RadInfoLabtoolQA02006APX6000XE_A38951);
    this.Field.Add("RadInfoLabtoolCloningInProgress_A7672", (IAcpField) this.RadioInformation.Labtool.RadInfoLabtoolCloningInProgress_A7672);
    this.Field.Add("RadInfoLabtoolSecurePartitionVersionNumber_A9076", (IAcpField) this.RadioInformation.Labtool.RadInfoLabtoolSecurePartitionVersionNumber_A9076);
    this.Field.Add("RadInfoLabtoolOriginalSecurePartitionVersion_A8626", (IAcpField) this.RadioInformation.Labtool.RadInfoLabtoolOriginalSecurePartitionVersion_A8626);
    this.Field.Add("RadInfoLabtoolNumOfSysEnhBytes_A22749", (IAcpField) this.RadioInformation.Labtool.RadInfoLabtoolNumOfSysEnhBytes_A22749);
    this.Field.Add("RadInfoLabtoolG966OTAP_A22740", (IAcpField) this.RadioInformation.Labtool.RadInfoLabtoolG966OTAP_A22740);
    this.Field.Add("RadInfoLabtoolG138MotorcycleRadio_A24684", (IAcpField) this.RadioInformation.Labtool.RadInfoLabtoolG138MotorcycleRadio_A24684);
    this.Field.Add("RadInfoLabtoolH37G50Smartnet_A8184", (IAcpField) this.RadioInformation.Labtool.RadInfoLabtoolH37G50Smartnet_A8184);
    this.Field.Add("RadInfoLabtoolH38G51Smartzone_A8185", (IAcpField) this.RadioInformation.Labtool.RadInfoLabtoolH38G51Smartzone_A8185);
    this.Field.Add("RadInfoLabtoolQ806IMBE_A8191", (IAcpField) this.RadioInformation.Labtool.RadInfoLabtoolQ806IMBE_A8191);
    this.Field.Add("RadInfoLabtoolH868W968OtarAndMultikey_A8192", (IAcpField) this.RadioInformation.Labtool.RadInfoLabtoolH868W968OtarAndMultikey_A8192);
    this.Field.Add("RadInfoLabtoolH869W969Multikey_A8193", (IAcpField) this.RadioInformation.Labtool.RadInfoLabtoolH869W969Multikey_A8193);
    this.Field.Add("RadInfoLabtoolQ173G173Omnilink_A8788", (IAcpField) this.RadioInformation.Labtool.RadInfoLabtoolQ173G173Omnilink_A8788);
    this.Field.Add("RadInfoLabtoolExtendedDispatch_A38638", (IAcpField) this.RadioInformation.Labtool.RadInfoLabtoolExtendedDispatch_A38638);
    this.Field.Add("RadInfoLabtoolQ361G361APCOTrunking_A8794", (IAcpField) this.RadioInformation.Labtool.RadInfoLabtoolQ361G361APCOTrunking_A8794);
    this.Field.Add("RadInfoLabtoolQ387G387ConvVoteScan_A8795", (IAcpField) this.RadioInformation.Labtool.RadInfoLabtoolQ387G387ConvVoteScan_A8795);
    this.Field.Add("RadInfoLabtoolQ445FiregroundSupport_A8796", (IAcpField) this.RadioInformation.Labtool.RadInfoLabtoolQ445FiregroundSupport_A8796);
    this.Field.Add("RadInfoLabtoolQ52FEDFPPAndZoneClone_A8798", (IAcpField) this.RadioInformation.Labtool.RadInfoLabtoolQ52FEDFPPAndZoneClone_A8798);
    this.Field.Add("RadInfoLabtoolQ53NonFEDFPPAndZoneClone_A8799", (IAcpField) this.RadioInformation.Labtool.RadInfoLabtoolQ53NonFEDFPPAndZoneClone_A8799);
    this.Field.Add("RadInfoLabtoolQ947W947APCOPacketData_8804", (IAcpField) this.RadioInformation.Labtool.RadInfoLabtoolQ947W947APCOPacketData_8804);
    this.Field.Add("RadInfoLabtoolW12Preamp_A9671", (IAcpField) this.RadioInformation.Labtool.RadInfoLabtoolW12Preamp_A9671);
    this.Field.Add("RadInfoLabtoolGPSActivation_A23983", (IAcpField) this.RadioInformation.Labtool.RadInfoLabtoolGPSActivation_A23983);
    this.Field.Add("RadInfoLabtoolFPPNonFEDVersion_A8143", (IAcpField) this.RadioInformation.Labtool.RadInfoLabtoolFPPNonFEDVersion_A8143);
    this.Field.Add("RadInfoLabtoolMCHFamilyDifferntiator_A8482", (IAcpField) this.RadioInformation.Labtool.RadInfoLabtoolMCHFamilyDifferntiator_A8482);
    this.Field.Add("RadInfoLabtoolTDMAOperation_A23984", (IAcpField) this.RadioInformation.Labtool.RadInfoLabtoolTDMAOperation_A23984);
    this.Field.Add("RadInfoLabtoolFrontDisplayFullKeypad_A23985", (IAcpField) this.RadioInformation.Labtool.RadInfoLabtoolFrontDisplayFullKeypad_A23985);
    this.Field.Add("RadInfoLabtoolDualBandEnable_A23986", (IAcpField) this.RadioInformation.Labtool.RadInfoLabtoolDualBandEnable_A23986);
    this.Field.Add("RadInfoLabtoolQA01648ASKEnable_A37150", (IAcpField) this.RadioInformation.Labtool.RadInfoLabtoolQA01648ASKEnable_A37150);
    this.Field.Add("RadInfoLabtoolQA01749LegacySWEnable_A37151", (IAcpField) this.RadioInformation.Labtool.RadInfoLabtoolQA01749LegacySWEnable_A37151);
    this.Field.Add("RadInfoLabtoolPrimaryBands_A23987", (IAcpField) this.RadioInformation.Labtool.RadInfoLabtoolPrimaryBands_A23987);
    this.Field.Add("RadInfoLabtoolSecondaryBands_A23988", (IAcpField) this.RadioInformation.Labtool.RadInfoLabtoolSecondaryBands_A23988);
    this.Field.Add("RadInfoLabtoolBluetooth_A37042", (IAcpField) this.RadioInformation.Labtool.RadInfoLabtoolBluetooth_A37042);
    this.Field.Add("RadInfoLabtoolProductModelIdentifier_A37178", (IAcpField) this.RadioInformation.Labtool.RadInfoLabtoolProductModelIdentifier_A37178);
    this.Field.Add("RadInfoLabtoolQA01768EnhancedZoneBank_A37209", (IAcpField) this.RadioInformation.Labtool.RadInfoLabtoolQA01768EnhancedZoneBank_A37209);
    this.Field.Add("RadInfoLabtoolH43G170TrunkedRadioTraceRemoteMonitor_37551", (IAcpField) this.RadioInformation.Labtool.RadInfoLabtoolH43G170TrunkedRadioTraceRemoteMonitor_37551);
    this.Field.Add("RadInfoLabtoolAuthentication_A37609", (IAcpField) this.RadioInformation.Labtool.RadInfoLabtoolAuthentication_A37609);
    this.Field.Add("RadInfoLabtoolH46G683OneTouchStatusMsg_37658", (IAcpField) this.RadioInformation.Labtool.RadInfoLabtoolH46G683OneTouchStatusMsg_37658);
    this.Field.Add("RadInfoLabtoolQA01771GA01771EnhancementLev2_37660", (IAcpField) this.RadioInformation.Labtool.RadInfoLabtoolQA01771GA01771EnhancementLev2_37660);
    this.Field.Add("RadioInfoLabtoolExtremeNoiseReduction_A37723", (IAcpField) this.RadioInformation.Labtool.RadioInfoLabtoolExtremeNoiseReduction_A37723);
    this.Field.Add("RadInfoLabtoolH04ConvTacticalRekey_35710", (IAcpField) this.RadioInformation.Labtool.RadInfoLabtoolH04ConvTacticalRekey_35710);
    this.Field.Add("RadInfoLabtoolQ507G507FCCMANDATE_A38198", (IAcpField) this.RadioInformation.Labtool.RadInfoLabtoolQ507G507FCCMANDATE_A38198);
    this.Field.Add("RadInfoLabtoolManDown_A40006", (IAcpField) this.RadioInformation.Labtool.RadInfoLabtoolManDown_A40006);
    this.Field.Add("RadInfoLabtoolQ667G193ADPSW_38631", (IAcpField) this.RadioInformation.Labtool.RadInfoLabtoolQ667G193ADPSW_38631);
    this.Field.Add("RadioInfoLabToolQA00631DvrsPsuActivation_A40166", (IAcpField) this.RadioInformation.Labtool.RadioInfoLabToolQA00631DvrsPsuActivation_A40166);
    this.Field.Add("RadioInfoLabToolGA00631DvrsMsuOperation_A41827", (IAcpField) this.RadioInformation.Labtool.RadioInfoLabToolGA00631DvrsMsuOperation_A41827);
    this.Field.Add("RadInfoLabtoolQA01770GA01770EnhancementLev1_38632", (IAcpField) this.RadioInformation.Labtool.RadInfoLabtoolQA01770GA01770EnhancementLev1_38632);
    this.Field.Add("RadInfoLabtoolQA02751APXLiRadioTrigger_A41197", (IAcpField) this.RadioInformation.Labtool.RadInfoLabtoolQA02751APXLiRadioTrigger_A41197);
    this.Field.Add("RadInfoLabtoolQA02811TrkSingleSysTrigger_A41198", (IAcpField) this.RadioInformation.Labtool.RadInfoLabtoolQA02811TrkSingleSysTrigger_A41198);
    this.Field.Add("RadInfoLabtoolG857FDNYEmRxTxToneSet_A41509", (IAcpField) this.RadioInformation.Labtool.RadInfoLabtoolG857FDNYEmRxTxToneSet_A41509);
    this.Field.Add("RadInfoLabtoolH02EncryTacticalInhibit_A41560", (IAcpField) this.RadioInformation.Labtool.RadInfoLabtoolH02EncryTacticalInhibit_A41560);
    this.Field.Add("RadInfoLabtoolCollaborativePhase1_A41683", (IAcpField) this.RadioInformation.Labtool.RadInfoLabtoolCollaborativePhase1_A41683);
    this.Field.Add("RadInfoLabtoolV24Software_A41828", (IAcpField) this.RadioInformation.Labtool.RadInfoLabtoolV24Software_A41828);
    this.Field.Add("RadInfoLabtoolP25CommonAirInterface_A42122", (IAcpField) this.RadioInformation.Labtool.RadInfoLabtoolP25CommonAirInterface_A42122);
    this.Field.Add("EnhancedDataOperation_42024", (IAcpField) this.RadioInformation.Labtool.EnhancedDataOperation_42024);
    this.Field.Add("RadInfoLabtool00982SiteSelAlertForP25_42052", (IAcpField) this.RadioInformation.Labtool.RadInfoLabtool00982SiteSelAlertForP25_42052);
    this.Field.Add("RadInfoLabtoolLTEOperation_A41923", (IAcpField) this.RadioInformation.Labtool.RadInfoLabtoolLTEOperation_A41923);
    this.Field.Add("RadInfoLabtoolDualRadioOperation_A42245", (IAcpField) this.RadioInformation.Labtool.RadInfoLabtoolDualRadioOperation_A42245);
    this.Field.Add("RadInfoLabtoolEncryptedVPNGateway_42279", (IAcpField) this.RadioInformation.Labtool.RadInfoLabtoolEncryptedVPNGateway_42279);
    this.Field.Add("RadInfoLabtoolAstroAlertingOperHOption", (IAcpField) this.RadioInformation.Labtool.RadInfoLabtoolAstroAlertingOperHOption);
    this.Field.Add("RadInfoLabtoolQA07516NYPDTrigger_43587", (IAcpField) this.RadioInformation.Labtool.RadInfoLabtoolQA07516NYPDTrigger_43587);
    this.Field.Add("RadInfoLabtoolQA07680AAGA01620AAMultiSystemOTARHOption_43695", (IAcpField) this.RadioInformation.Labtool.RadInfoLabtoolQA07680AAGA01620AAMultiSystemOTARHOption_43695);
    this.Field.Add("RadInfoLabtoolGA01731AAQA07949AAApxDesSoftwareCrypto_43745", (IAcpField) this.RadioInformation.Labtool.RadInfoLabtoolGA01731AAQA07949AAApxDesSoftwareCrypto_43745);
    this.Field.Add("DVRS_PSU_CONVENTIONAL_SCAN_ENABLED", (IAcpField) this.RadioInformation.Labtool.RadInfoLabtool_HA00677_DVRS_PSU_CONVENTIONAL_SCAN_ENABLED);
    this.Field.Add("RadInfoLabtoolQA08157ETSIRegulatoryRegionEnabled_43771", (IAcpField) this.RadioInformation.Labtool.RadInfoLabtoolQA08157ETSIRegulatoryRegionEnabled_43771);
    this.Field.Add("RadInfoLabtoolAtakHOption_HA00680", (IAcpField) this.RadioInformation.Labtool.RadInfoLabtoolAtakHOption_HA00680);
    this.Field.Add("RadInfoLabtoolQA08676_AdaptiveSpeakerVolume", (IAcpField) this.RadioInformation.Labtool.RadInfoLabtoolQA08676_AdaptiveSpeakerVolume);
    this.Field.Add("RadInfoLabtoolQA08715VoiceControlBasic", (IAcpField) this.RadioInformation.Labtool.RadInfoLabtoolQA08715VoiceControlBasic);
    this.Field.Add("RadInfoLabtoolLTEHWEnablement_QA08887", (IAcpField) this.RadioInformation.Labtool.RadInfoLabtoolLTEHWEnablement_QA08887);
    this.Field.Add("RadInfoLabtoolTacticalServicesHOption", (IAcpField) this.RadioInformation.Labtool.RadInfoLabtoolTacticalServicesHOption);
    this.Field.Add("RadInfoLabtoolMultiCodeplug", (IAcpField) this.RadioInformation.Labtool.RadInfoLabtoolMultiCodeplug);
    this.Field.Add("RadInfoLabtoolQA09776WebBrowserEnablement", (IAcpField) this.RadioInformation.Labtool.RadInfoLabtoolQA09776WebBrowserEnablement);
  }

  private void AddZoneChannelAssigement()
  {
    this.Field.Add("ZnChanCfgZoneZoneName_A9724", (IAcpField) this.ZoneChannelAssignment.Zone.ZnChanCfgZoneZoneName_A9724);
    this.Field.Add("ZnChanCfgZoneTopDisplayZone_A19772", (IAcpField) this.ZoneChannelAssignment.Zone.ZnChanCfgZoneTopDisplayZone_A19772);
    this.Field.Add("ZoneVoiceAnnouncementID_A21514", (IAcpField) this.ZoneChannelAssignment.Zone.ZoneVoiceAnnouncementID_A21514);
    this.Field.Add("ZnChanCfgZoneDynamicZoneEnable_A41257", (IAcpField) this.ZoneChannelAssignment.Zone.ZnChanCfgZoneDynamicZoneEnable_A41257);
    this.Field.Add("ZnChanCfgZoneZoneCloningEnable_43119", (IAcpField) this.ZoneChannelAssignment.Zone.ZnChanCfgZoneZoneCloningEnable_43119);
    this.Field.Add("ZoneChannelAssignmentRSIMode_A41831", (IAcpField) this.ZoneChannelAssignment.RSI.ZoneChannelAssignmentRSIMode_A41831);
    this.Field.Add("ZoneChannelAssignmentRSITransmitIndication_A41834", (IAcpField) this.ZoneChannelAssignment.RSI.ZoneChannelAssignmentRSITransmitIndication_A41834);
    this.Field.Add("ZoneChannelAssignmentRSISiteNumber_A41833", (IAcpField) this.ZoneChannelAssignment.RSI.ZoneChannelAssignmentRSISiteNumber_A41833);
    this.Field.Add("ZoneChannelAssignmentRSIAutoDial_A41832", (IAcpField) this.ZoneChannelAssignment.RSI.ZoneChannelAssignmentRSIAutoDial_A41832);
    this.Field.Add("ZoneChannelAssignmentRSITimeDialAtt_A41835", (IAcpField) this.ZoneChannelAssignment.RSI.ZoneChannelAssignmentRSITimeDialAtt_A41835);
    this.Field.Add("ZoneChannelAssignmentRSIDTRTogTime_A41836", (IAcpField) this.ZoneChannelAssignment.RSI.ZoneChannelAssignmentRSIDTRTogTime_A41836);
    this.Field.Add("ZnChanCfgFPPProtectionProtectedZone_A8765", (IAcpField) this.ZoneChannelAssignment.FPPProtection.ZnChanCfgFPPProtectionProtectedZone_A8765);
    this.Field.Add("ZnChanCfgFPPProtectionFPPEnable_A19562", (IAcpField) this.ZoneChannelAssignment.FPPProtection.ZnChanCfgFPPProtectionFPPEnable_A19562);
    this.Field.Add("ZnChanCfgChannelsChannelName_A7659", (IAcpField) this.ChannelAssignmentListInner.ChannelAssignmentListInnerSection.ZnChanCfgChannelsChannelName_A7659);
    this.Field.Add("ZnChanCfgChannelsTopDisplayChannel_A19774", (IAcpField) this.ChannelAssignmentListInner.ChannelAssignmentListInnerSection.ZnChanCfgChannelsTopDisplayChannel_A19774);
    this.Field.Add("ZnChanCfgChannelsChannelType_A22241", (IAcpField) this.ChannelAssignmentListInner.ChannelAssignmentListInnerSection.ZnChanCfgChannelsChannelType_A22241);
    this.Field.Add("ZnChanCfgChannelsPersonality_A8698", (IAcpField) this.ChannelAssignmentListInner.ChannelAssignmentListInnerSection.ZnChanCfgChannelsPersonality_A8698);
    this.Field.Add("ZnChanCfgChannelsTalkgroup_A9276", (IAcpField) this.ChannelAssignmentListInner.ChannelAssignmentListInnerSection.ZnChanCfgChannelsTalkgroup_A9276);
    this.Field.Add("ZnChanCfgChannelsConventionalChannelReference_A20560", (IAcpField) this.ChannelAssignmentListInner.ChannelAssignmentListInnerSection.ZnChanCfgChannelsConventionalChannelReference_A20560);
    this.Field.Add("ZnChanCfgChannelsRadioProfileCompositeItemNameID_A20192", (IAcpField) this.ChannelAssignmentListInner.ChannelAssignmentListInnerSection.ZnChanCfgChannelsRadioProfileCompositeItemNameID_A20192);
    this.Field.Add("ZnChanCfgChannelsFallbackZone", (IAcpField) this.ChannelAssignmentListInner.ChannelAssignmentListInnerSection.ZnChanCfgChannelsFallbackZone);
    this.Field.Add("ZnChanCfgChannelsFallbackChannel", (IAcpField) this.ChannelAssignmentListInner.ChannelAssignmentListInnerSection.ZnChanCfgChannelsFallbackChannel);
    this.Field.Add("ChannelAnnouncementID_A20175", (IAcpField) this.ChannelAssignmentListInner.ChannelAssignmentListInnerSection.ChannelAnnouncementID_A20175);
    this.Field.Add("ChannelsActiveChannel", (IAcpField) this.ChannelAssignmentListInner.ChannelAssignmentListInnerSection.ChannelsActiveChannel);
    this.Field.Add("ZnChanCfgChannelsFiregroundSectorID_A33630", (IAcpField) this.ChannelAssignmentListInner.ChannelAssignmentListInnerSection.ZnChanCfgChannelsFiregroundSectorID_A33630);
    this.Field.Add("ZnChanCfgLabtoolLastSelectedChnl_A41075", (IAcpField) this.ZoneChannelAssignment.Labtool.ZnChanCfgLabtoolLastSelectedChnl_A41075);
    this.Field.Add("MainComparatorHostname_43796", (IAcpField) this.ZoneChannelAssignment.RSI.MainComparatorHostname_43796);
    this.Field.Add("AlternateComparatorHostname_43797", (IAcpField) this.ZoneChannelAssignment.RSI.AlternateComparatorHostname_43797);
    this.Field.Add("MainComparatorDTLSPortNumber_43798", (IAcpField) this.ZoneChannelAssignment.RSI.MainComparatorDTLSPortNumber_43798);
    this.Field.Add("AlternateComparatorDTLSPortNumber_43801", (IAcpField) this.ZoneChannelAssignment.RSI.AlternateComparatorDTLSPortNumber_43801);
    this.Field.Add("ComparatorChannelNumber_43800", (IAcpField) this.ZoneChannelAssignment.RSI.ComparatorChannelNumber_43800);
  }

  private void AddScanList()
  {
    this.Field.Add("ScanLstGeneralKeyofScanList_A12668", (IAcpField) this.ScanList.General.ScanLstGeneralKeyofScanList_A12668);
    this.Field.Add("ScanLstGeneralScanType_A9058", (IAcpField) this.ScanList.General.ScanLstGeneralScanType_A9058);
    this.Field.Add("ScanLstGeneralRecord_A8921", (IAcpField) this.ScanList.General.ScanLstGeneralRecord_A8921);
    this.Field.Add("ScanLstGeneralType_A9578", (IAcpField) this.ScanList.General.ScanLstGeneralType_A9578);
    this.Field.Add("ScanLstGeneralDynamicPriority_A7915", (IAcpField) this.ScanList.General.ScanLstGeneralDynamicPriority_A7915);
    this.Field.Add("ScanLstGeneralPriority1Type_A8745", (IAcpField) this.ScanList.General.ScanLstGeneralPriority1Type_A8745);
    this.Field.Add("ScanLstGeneralPriorityMember1_A8747", (IAcpField) this.ScanList.General.ScanLstGeneralPriorityMember1_A8747);
    this.Field.Add("ScanLstGeneralPriority2Type_A8748", (IAcpField) this.ScanList.General.ScanLstGeneralPriority2Type_A8748);
    this.Field.Add("ScanLstGeneralPriorityMember2_A8749", (IAcpField) this.ScanList.General.ScanLstGeneralPriorityMember2_A8749);
    this.Field.Add("ScanLstGeneralNonPriorityMembers_A8569", (IAcpField) this.ScanList.General.ScanLstGeneralNonPriorityMembers_A8569);
    this.Field.Add("ScanLstGeneralDesignatedVoiceTxMemberType_A21524", (IAcpField) this.ScanList.General.ScanLstGeneralDesignatedVoiceTxMemberType_A21524);
    this.Field.Add("ScanLstGeneralDesignatedVoiceTxMember_A7830", (IAcpField) this.ScanList.General.ScanLstGeneralDesignatedVoiceTxMember_A7830);
    this.Field.Add("ScanLstGeneralDesignatedDataTxRxType_A21525", (IAcpField) this.ScanList.General.ScanLstGeneralDesignatedDataTxRxType_A21525);
    this.Field.Add("ScanLstGeneralDesignatedDataMember_A7829", (IAcpField) this.ScanList.General.ScanLstGeneralDesignatedDataMember_A7829);
    this.Field.Add("ScanLstAdvancedDataTxLimitedPatienceTimerms_A7799", (IAcpField) this.ScanList.Advanced.ScanLstAdvancedDataTxLimitedPatienceTimerms_A7799);
    this.Field.Add("ScanLstAdvancedVotingScanDelayTimerMs_A9657", (IAcpField) this.ScanList.Advanced.ScanLstAdvancedVotingScanDelayTimerMs_A9657);
    this.Field.Add("ScanLstAdvancedDisplayStrongestVotedChannel_A7884", (IAcpField) this.ScanList.Advanced.ScanLstAdvancedDisplayStrongestVotedChannel_A7884);
    this.Field.Add("ScanLstAdvancedTxSteering_A9572", (IAcpField) this.ScanList.Advanced.ScanLstAdvancedTxSteering_A9572);
    this.Field.Add("ScanLstAdvancedMixedConvVoteScanInactivityTimer_A38724", (IAcpField) this.ScanList.Advanced.ScanLstAdvancedMixedConvVoteScanInactivityTimer_A38724);
    this.Field.Add("ScanLstScanListKeyofScanListMBRTable_A12673", (IAcpField) this.ScanListInner.ScanListInnerSection.ScanLstScanListKeyofScanListMBRTable_A12673);
    this.Field.Add("ScanLstScanListZone_A9718", (IAcpField) this.ScanListInner.ScanListInnerSection.ScanLstScanListZone_A9718);
    this.Field.Add("ScanLstScanListChannel_A7620", (IAcpField) this.ScanListInner.ScanListInnerSection.ScanLstScanListChannel_A7620);
    this.Field.Add("ScanLstScanListLTEInterferingFreqPresent_A42196", (IAcpField) this.ScanListInner.ScanListInnerSection.ScanLstScanListLTEInterferingFreqPresent_A42196);
    this.Field.Add("ScanLstLabtoolLastVotedChannel_A8419", (IAcpField) this.ScanList.Labtool.ScanLstLabtoolLastVotedChannel_A8419);
    this.Field.Add("ScanLstLabtoolLastVotedZone_A8420", (IAcpField) this.ScanList.Labtool.ScanLstLabtoolLastVotedZone_A8420);
    this.Field.Add("ScanLstLabtoolLTEInterferingFreqPresent_A42197", (IAcpField) this.ScanList.Labtool.ScanLstLabtoolLTEInterferingFreqPresent_A42197);
  }

  private void AddMPLConfiguration()
  {
    this.Field.Add("MplCfgGeneralMPLSelectMode_A8549", (IAcpField) this.MPLConfiguration.General.MplCfgGeneralMPLSelectMode_A8549);
    this.Field.Add("MplCfgGeneralPresetMPLEntry_A8739", (IAcpField) this.MPLConfiguration.General.MplCfgGeneralPresetMPLEntry_A8739);
    this.Field.Add("MplCfgMPLListMPLAlias_A8548", (IAcpField) this.MPLListInner.MPLListInnerSection.MplCfgMPLListMPLAlias_A8548);
    this.Field.Add("MplCfgMPLListRxSquelchType_A9028", (IAcpField) this.MPLListInner.MPLListInnerSection.MplCfgMPLListRxSquelchType_A9028);
    this.Field.Add("MplCfgMPLListRxPLFreq_A9027", (IAcpField) this.MPLListInner.MPLListInnerSection.MplCfgMPLListRxPLFreq_A9027);
    this.Field.Add("MplCfgMPLListRxPLCode_A9026", (IAcpField) this.MPLListInner.MPLListInnerSection.MplCfgMPLListRxPLCode_A9026);
    this.Field.Add("MplCfgMPLListRxDPLCode_A9008", (IAcpField) this.MPLListInner.MPLListInnerSection.MplCfgMPLListRxDPLCode_A9008);
    this.Field.Add("MplCfgMPLListRxDPLInvert_A9009", (IAcpField) this.MPLListInner.MPLListInnerSection.MplCfgMPLListRxDPLInvert_A9009);
    this.Field.Add("MplCfgMPLListTxSquelchType_A9567", (IAcpField) this.MPLListInner.MPLListInnerSection.MplCfgMPLListTxSquelchType_A9567);
    this.Field.Add("MplCfgMPLListTxPLFreq_A9556", (IAcpField) this.MPLListInner.MPLListInnerSection.MplCfgMPLListTxPLFreq_A9556);
    this.Field.Add("MplCfgMPLListTxPLCode_A9555", (IAcpField) this.MPLListInner.MPLListInnerSection.MplCfgMPLListTxPLCode_A9555);
    this.Field.Add("MplCfgMPLListTxDPLCode_A9527", (IAcpField) this.MPLListInner.MPLListInnerSection.MplCfgMPLListTxDPLCode_A9527);
    this.Field.Add("MplCfgMPLListTxDPLInvert_A9528", (IAcpField) this.MPLListInner.MPLListInnerSection.MplCfgMPLListTxDPLInvert_A9528);
    this.Field.Add("MplCfgMPLListTASquelchType_A9266", (IAcpField) this.MPLListInner.MPLListInnerSection.MplCfgMPLListTASquelchType_A9266);
    this.Field.Add("MplCfgMPLListTAPLFreq_A9263", (IAcpField) this.MPLListInner.MPLListInnerSection.MplCfgMPLListTAPLFreq_A9263);
    this.Field.Add("MplCfgMPLListTAPLCode_A9262", (IAcpField) this.MPLListInner.MPLListInnerSection.MplCfgMPLListTAPLCode_A9262);
    this.Field.Add("MplCfgMPLListTADPLCode_A9257", (IAcpField) this.MPLListInner.MPLListInnerSection.MplCfgMPLListTADPLCode_A9257);
    this.Field.Add("MplCfgMPLListTADPLInvert_A9258", (IAcpField) this.MPLListInner.MPLListInnerSection.MplCfgMPLListTADPLInvert_A9258);
  }

  private void AddPhoneWide()
  {
    this.Field.Add("PhnWideGeneralDisplayFormat_A7874", (IAcpField) this.PhoneWide.General.PhnWideGeneralDisplayFormat_A7874);
    this.Field.Add("PhnWideGeneralManualAccessLiveDialing_A8462", (IAcpField) this.PhoneWide.General.PhnWideGeneralManualAccessLiveDialing_A8462);
    this.Field.Add("PhnWideDialingPhoneDialing_A8700", (IAcpField) this.PhoneWide.General.PhnWideDialingPhoneDialing_A8700);
    this.Field.Add("PhnWideDialingASTRO25PhoneOverdialType_A7473", (IAcpField) this.PhoneWide.General.PhnWideDialingASTRO25PhoneOverdialType_A7473);
    this.Field.Add("PhnWideDialingkeyofDialing_A21285", (IAcpField) this.DTMFTimingInner.DTMFTimingInnerSection.PhnWideDialingkeyofDialing_A21285);
    this.Field.Add("PhnWideDialingInitialDelayms_A7835", (IAcpField) this.DTMFTimingInner.DTMFTimingInnerSection.PhnWideDialingInitialDelayms_A7835);
    this.Field.Add("PhnWideDialingDigitDurationms_A7834", (IAcpField) this.DTMFTimingInner.DTMFTimingInnerSection.PhnWideDialingDigitDurationms_A7834);
    this.Field.Add("PhnWideDialingDTMFPauseTimems_A7898", (IAcpField) this.PhoneWide.DTMFTiming.PhnWideDialingDTMFPauseTimems_A7898);
    this.Field.Add("PhnWideDialingInterdigitDelayms_A7836", (IAcpField) this.DTMFTimingInner.DTMFTimingInnerSection.PhnWideDialingInterdigitDelayms_A7836);
    this.Field.Add("PhnWideDialingDTMFDigitHangtimems_A7896", (IAcpField) this.PhoneWide.DTMFTiming.PhnWideDialingDTMFDigitHangtimems_A7896);
    this.Field.Add("PhnWideDTMFCodesKeyofDTMFCodesTable_A12800", (IAcpField) this.DTMFCodesInner.DTMFCodesInnerSection.PhnWideDTMFCodesKeyofDTMFCodesTable_A12800);
    this.Field.Add("PhnWideDTMFCodesAccess_A7381", (IAcpField) this.DTMFCodesInner.DTMFCodesInnerSection.PhnWideDTMFCodesAccess_A7381);
    this.Field.Add("PhnWideDTMFCodesDeaccess_A7803", (IAcpField) this.DTMFCodesInner.DTMFCodesInnerSection.PhnWideDTMFCodesDeaccess_A7803);
  }

  private void AddRadioErgonomicsWide()
  {
    this.Field.Add("RadErgoWideHomeModeHomeModeSelection_A8202", (IAcpField) this.RadioErgonomicsWide.HomeMode.RadErgoWideHomeModeHomeModeSelection_A8202);
    this.Field.Add("RadErgoWideHomeModeZone_A9691", (IAcpField) this.RadioErgonomicsWide.HomeMode.RadErgoWideHomeModeZone_A9691);
    this.Field.Add("HomeModeChannel", (IAcpField) this.RadioErgonomicsWide.HomeMode.HomeModeChannel);
    this.Field.Add("RadErgoWideAdvancedPowerUpInHazardZoneMode", (IAcpField) this.RadioErgonomicsWide.Advanced.RadErgoWideAdvancedPowerUpInHazardZoneMode);
    this.Field.Add("RadErgoWideControlHeadMultiControlHead_A8550", (IAcpField) this.RadioErgonomicsWide.ControlHead.RadErgoWideControlHeadMultiControlHead_A8550);
    this.Field.Add("RadErgoWideControlHeadControlHeadsRequiredforPowerUp_A7725", (IAcpField) this.RadioErgonomicsWide.ControlHead.RadErgoWideControlHeadControlHeadsRequiredforPowerUp_A7725);
    this.Field.Add("RadErgoWideControlHeadMulCHTxAudioRouting_A38459", (IAcpField) this.RadioErgonomicsWide.ControlHead.RadErgoWideControlHeadMulCHTxAudioRouting_A38459);
    this.Field.Add("RadErgoWideControlHeadAggregateCableLength_A38456", (IAcpField) this.RadioErgonomicsWide.ControlHead.RadErgoWideControlHeadAggregateCableLength_A38456);
    this.Field.Add("RadErgoWideControlHeadExpectedNumofControlHeads_A7982", (IAcpField) this.RadioErgonomicsWide.ControlHead.RadErgoWideControlHeadExpectedNumofControlHeads_A7982);
    this.Field.Add("RadErgoWideControlHeadMultipleControlHeadStyle_A8561", (IAcpField) this.RadioErgonomicsWide.ControlHead.RadErgoWideControlHeadMultipleControlHeadStyle_A8561);
    this.Field.Add("RadErgoWideControlHeadIntercomTimeoutTimersec_A8297", (IAcpField) this.RadioErgonomicsWide.ControlHead.RadErgoWideControlHeadIntercomTimeoutTimersec_A8297);
    this.Field.Add("RadErgoWideControlHeadControlHead1Alias_A7718", (IAcpField) this.ControlHeadAliasListInner.ControlHeadAliasListInnerSection.RadErgoWideControlHeadControlHead1Alias_A7718);
    this.Field.Add("RadErgoWideControlHeadRemoteMicSource_A8930", (IAcpField) this.RadioErgonomicsWide.ControlHead.RadErgoWideControlHeadRemoteMicSource_A8930);
    this.Field.Add("RadErgoWideControlHeadBluetoothControl_44820", (IAcpField) this.RadioErgonomicsWide.ControlHead.RadErgoWideControlHeadBluetoothControl_44820);
    this.Field.Add("RadErgoWideControlHeadControlHeadVIPInputSource_A7724", (IAcpField) this.RadioErgonomicsWide.ControlHead.RadErgoWideControlHeadControlHeadVIPInputSource_A7724);
    this.Field.Add("RadErgoWideControlHeadTransceiverVolumeControl_A9405", (IAcpField) this.RadioErgonomicsWide.ControlHead.RadErgoWideControlHeadTransceiverVolumeControl_A9405);
    this.Field.Add("RadErgoWideControlHeadTransceiverDEKDimControl_A9404", (IAcpField) this.RadioErgonomicsWide.ControlHead.RadErgoWideControlHeadTransceiverDEKDimControl_A9404);
    this.Field.Add("RadErgoWidePASirenSirenOperation_A9139", (IAcpField) this.RadioErgonomicsWide.PASiren.RadErgoWidePASirenSirenOperation_A9139);
    this.Field.Add("RadErgoWidePASirenOptionsAudioMuting_A8623", (IAcpField) this.RadioErgonomicsWide.PASiren.RadErgoWidePASirenOptionsAudioMuting_A8623);
    this.Field.Add("RadErgoWidePASirenExternalRadioIgnition_A7992", (IAcpField) this.RadioErgonomicsWide.PASiren.RadErgoWidePASirenExternalRadioIgnition_A7992);
    this.Field.Add("RadErgoWidePASirenPAIgnitionSense_A8683", (IAcpField) this.RadioErgonomicsWide.PASiren.RadErgoWidePASirenPAIgnitionSense_A8683);
    this.Field.Add("RadErgoWidePASirenDefaultPAVolumeLevel_A7812", (IAcpField) this.RadioErgonomicsWide.PASiren.RadErgoWidePASirenDefaultPAVolumeLevel_A7812);
    this.Field.Add("RadErgoWidePASirenSirenPAAfterReset_A9140", (IAcpField) this.RadioErgonomicsWide.PASiren.RadErgoWidePASirenSirenPAAfterReset_A9140);
    this.Field.Add("RadErgoWidePASirenHiLoAirhornTones_A8200", (IAcpField) this.RadioErgonomicsWide.PASiren.RadErgoWidePASirenHiLoAirhornTones_A8200);
    this.Field.Add("RadErgoWidePASirenManualTone_A8464", (IAcpField) this.RadioErgonomicsWide.PASiren.RadErgoWidePASirenManualTone_A8464);
    this.Field.Add("RadErgoWidePASirenSirenIgnitionSense_A9138", (IAcpField) this.RadioErgonomicsWide.PASiren.RadErgoWidePASirenSirenIgnitionSense_A9138);
    this.Field.Add("RadErgoWideHornandLightsHornLights_A8206", (IAcpField) this.RadioErgonomicsWide.HornAndLights.RadErgoWideHornandLightsHornLights_A8206);
    this.Field.Add("RadErgoWideHornandLightsPermanentHornLights_A8697", (IAcpField) this.RadioErgonomicsWide.HornAndLights.RadErgoWideHornandLightsPermanentHornLights_A8697);
    this.Field.Add("RadErgoWideHornandLightsHornDurationsec_A8207", (IAcpField) this.RadioErgonomicsWide.HornAndLights.RadErgoWideHornandLightsHornDurationsec_A8207);
    this.Field.Add("RadErgoWideHornandLightsLightDurationsec_A8430", (IAcpField) this.RadioErgonomicsWide.HornAndLights.RadErgoWideHornandLightsLightDurationsec_A8430);
    this.Field.Add("RadErgoWideHornAndLightsTwoAlarmOption_A9510", (IAcpField) this.RadioErgonomicsWide.HornAndLights.RadErgoWideHornAndLightsTwoAlarmOption_A9510);
    this.Field.Add("RadErgoWideHornandLightsAlarmType_A7424", (IAcpField) this.RadioErgonomicsWide.HornAndLights.RadErgoWideHornandLightsAlarmType_A7424);
    this.Field.Add("RadErgoWideHornandLightsAlarmRearmOption_A7423", (IAcpField) this.RadioErgonomicsWide.HornAndLights.RadErgoWideHornandLightsAlarmRearmOption_A7423);
    this.Field.Add("RadErgoWideHornandLightsExternalAlarmDelaysec_A7984", (IAcpField) this.RadioErgonomicsWide.HornAndLights.RadErgoWideHornandLightsExternalAlarmDelaysec_A7984);
    this.Field.Add("RadErgoWideStealthDisableLightLED_A36482", (IAcpField) this.RadioErgonomicsWide.Stealth.RadErgoWideStealthDisableLightLED_A36482);
    this.Field.Add("RadErgoWideStealthDisableTones_A36487", (IAcpField) this.RadioErgonomicsWide.Stealth.RadErgoWideStealthDisableTones_A36487);
    this.Field.Add("RadErgoWideStealthSaveStealthMode_A36491", (IAcpField) this.RadioErgonomicsWide.Stealth.RadErgoWideStealthSaveStealthMode_A36491);
    this.Field.Add("RadErgoWideAdvancedShortKeypressDurationms_A9125", (IAcpField) this.RadioErgonomicsWide.Advanced.RadErgoWideAdvancedShortKeypressDurationms_A9125);
    this.Field.Add("RadErgoWideAdvancedShortKeypressDurationforEmergencyms_A9126", (IAcpField) this.RadioErgonomicsWide.Advanced.RadErgoWideAdvancedShortKeypressDurationforEmergencyms_A9126);
    this.Field.Add("RadErgoWideAdvancedLongKeypressDurationms_A8450", (IAcpField) this.RadioErgonomicsWide.Advanced.RadErgoWideAdvancedLongKeypressDurationms_A8450);
    this.Field.Add("RadErgoWideAdvancedLongKeypressDurationforEmergencyms_A8451", (IAcpField) this.RadioErgonomicsWide.Advanced.RadErgoWideAdvancedLongKeypressDurationforEmergencyms_A8451);
    this.Field.Add("RadErgoWideAdvancedShortKeypressDurationforMFK_A38505", (IAcpField) this.RadioErgonomicsWide.Advanced.RadErgoWideAdvancedShortKeypressDurationforMFK_A38505);
    this.Field.Add("RadErgoWideAdvancedLongKeypressDurationforMFK_A38506", (IAcpField) this.RadioErgonomicsWide.Advanced.RadErgoWideAdvancedLongKeypressDurationforMFK_A38506);
    this.Field.Add("RadErgoWideAdvancedMFKInactivityTimeout_A38507", (IAcpField) this.RadioErgonomicsWide.Advanced.RadErgoWideAdvancedMFKInactivityTimeout_A38507);
    this.Field.Add("RadErgoWideSideAdvancedMFBInactivityTimeout_A41565", (IAcpField) this.RadioErgonomicsWide.Advanced.RadErgoWideSideAdvancedMFBInactivityTimeout_A41565);
    this.Field.Add("RadErgoWideAdvancedSoftPowerOff_A9170", (IAcpField) this.RadioErgonomicsWide.Advanced.RadErgoWideAdvancedSoftPowerOff_A9170);
    this.Field.Add("RadErgoWideAdvancedLogicalSwitch2_A7756", (IAcpField) this.RadioErgonomicsWide.Advanced.RadErgoWideAdvancedLogicalSwitch2_A7756);
    this.Field.Add("RadErgoWideAdvancedRotarySwitchLockEnable_A8987", (IAcpField) this.RadioErgonomicsWide.Advanced.RadErgoWideAdvancedRotarySwitchLockEnable_A8987);
    this.Field.Add("RadErgoWideAdvancedSideButtonsLockEnable_A38725", (IAcpField) this.RadioErgonomicsWide.Advanced.RadErgoWideAdvancedSideButtonsLockEnable_A38725);
    this.Field.Add("RadErgoWideAdvancedLastSelectedChannelPerZone_A41073", (IAcpField) this.RadioErgonomicsWide.Advanced.RadErgoWideAdvancedLastSelectedChannelPerZone_A41073);
    this.Field.Add("RadErgoWideAdvancedPowerUpOnLastSelectedZoneandChannel_A8787", (IAcpField) this.RadioErgonomicsWide.Advanced.RadErgoWideAdvancedPowerUpOnLastSelectedZoneandChannel_A8787);
    this.Field.Add("RadErgoWideAdvancedZoneBankOperation_A37543", (IAcpField) this.RadioErgonomicsWide.Advanced.RadErgoWideAdvancedZoneBankOperation_A37543);
    this.Field.Add("RadErgoWideAdvancedNumberofZoneBanks_A37256", (IAcpField) this.RadioErgonomicsWide.Advanced.RadErgoWideAdvancedNumberofZoneBanks_A37256);
    this.Field.Add("RadErgoWideAdvancedVolumeControlLockoutWithRSMSelection_A22244", (IAcpField) this.RadioErgonomicsWide.Advanced.RadErgoWideAdvancedVolumeControlLockoutWithRSMSelection_A22244);
    this.Field.Add("RadErgoWideAdvancedChannelControlLockoutWithRSMSelection_A22245", (IAcpField) this.RadioErgonomicsWide.Advanced.RadErgoWideAdvancedChannelControlLockoutWithRSMSelection_A22245);
    this.Field.Add("RadErgoWideAdvancedActiveMicForRadioPTT_A38766", (IAcpField) this.RadioErgonomicsWide.Advanced.RadErgoWideAdvancedActiveMicForRadioPTT_A38766);
    this.Field.Add("RadioErgoCfgExternalAccessoryEnable_A36198", (IAcpField) this.RadioErgonomicsWide.Advanced.RadioErgoCfgExternalAccessoryEnable_A36198);
    this.Field.Add("RadioErgoCfgFatalError_A36202", (IAcpField) this.RadioErgonomicsWide.Advanced.RadioErgoCfgFatalError_A36202);
    this.Field.Add("RadErgoWideAdvancedConsoletteEnable_A37231", (IAcpField) this.RadioErgonomicsWide.Advanced.RadErgoWideAdvancedConsoletteEnable_A37231);
    this.Field.Add("RadErgoWideAdvancedConsoletteFatalError_A37233", (IAcpField) this.RadioErgonomicsWide.Advanced.RadErgoWideAdvancedConsoletteFatalError_A37233);
    this.Field.Add("RadErgoWideAdvancedFixedVolumeEnable_A37218", (IAcpField) this.RadioErgonomicsWide.Advanced.RadErgoWideAdvancedFixedVolumeEnable_A37218);
    this.Field.Add("RadErgoWideAdvancedFixedVolumeLevel_A37219", (IAcpField) this.RadioErgonomicsWide.Advanced.RadErgoWideAdvancedFixedVolumeLevel_A37219);
    this.Field.Add("RadErgoWideAdvancedDefaultCHHubState_A37222", (IAcpField) this.RadioErgonomicsWide.Advanced.RadErgoWideAdvancedDefaultCHHubState_A37222);
    this.Field.Add("RadErgoWideAdvancedKeypadControlsLockKeyPressType_A41569", (IAcpField) this.RadioErgonomicsWide.Advanced.RadErgoWideAdvancedKeypadControlsLockKeyPressType_A41569);
    this.Field.Add("RadWideNVGBacklightBrightnessLevel_A41616", (IAcpField) this.RadioErgonomicsWide.Advanced.RadWideNVGBacklightBrightnessLevel_A41616);
    this.Field.Add("RadErgoWideAuxControlAuxCtrlName_A37714", (IAcpField) this.AuxControlTableInner.AuxControlTableInnerSection.RadErgoWideAuxControlAuxCtrlName_A37714);
    this.Field.Add("RadErgoWideAuxControlActiveDuration_A37249", (IAcpField) this.AuxControlTableInner.AuxControlTableInnerSection.RadErgoWideAuxControlActiveDuration_A37249);
    this.Field.Add("RadErgoWideAuxControlAbbrAuxOnAlias_A37612", (IAcpField) this.AuxControlTableInner.AuxControlTableInnerSection.RadErgoWideAuxControlAbbrAuxOnAlias_A37612);
    this.Field.Add("RadErgoWideAuxControlAuxOnAlias_A37250", (IAcpField) this.AuxControlTableInner.AuxControlTableInnerSection.RadErgoWideAuxControlAuxOnAlias_A37250);
    this.Field.Add("RadErgoWideAuxControlAuxOffAlias_A37252", (IAcpField) this.AuxControlTableInner.AuxControlTableInnerSection.RadErgoWideAuxControlAuxOffAlias_A37252);
    this.Field.Add("LabtoolPresetZone_A41079", (IAcpField) this.PresetZoneAndChannelTableInner.PresetZoneAndChannelTableInnerSection.LabtoolPresetZone_A41079);
    this.Field.Add("LabtoolPresetChannel_A41080", (IAcpField) this.PresetZoneAndChannelTableInner.PresetZoneAndChannelTableInnerSection.LabtoolPresetChannel_A41080);
    this.Field.Add("RadErgoWideLogicalProfileConfigurationCovertProfile_A43135", (IAcpField) this.RadioErgonomicsWide.LogicalProfileConfiguration.RadErgoWideLogicalProfileConfigurationCovertProfile_A43135);
    this.Field.Add("RadErgoWideLogicalProfileConfigurationDefaultProfile_A43136", (IAcpField) this.RadioErgonomicsWide.LogicalProfileConfiguration.RadErgoWideLogicalProfileConfigurationDefaultProfile_A43136);
    this.Field.Add("RadErgoWideLogicalProfileConfigurationLoudAudioProfile_A43137", (IAcpField) this.RadioErgonomicsWide.LogicalProfileConfiguration.RadErgoWideLogicalProfileConfigurationLoudAudioProfile_A43137);
    this.Field.Add("RadErgoWideLogicalProfileConfigurationSurveillanceProfile_A43138", (IAcpField) this.RadioErgonomicsWide.LogicalProfileConfiguration.RadErgoWideLogicalProfileConfigurationSurveillanceProfile_A43138);
    this.Field.Add("RadErgoWideSessionLockEnable", (IAcpField) this.RadioErgonomicsWide.ApplicationSessionLock.RadErgoWideSessionLockEnable);
    this.Field.Add("RadErgoWideVirtualPartnerSessionLock", (IAcpField) this.RadioErgonomicsWide.ApplicationSessionLock.RadErgoWideVirtualPartnerSessionLock);
    this.Field.Add("RadErgoWideSmartMessagingSessionLock", (IAcpField) this.RadioErgonomicsWide.ApplicationSessionLock.RadErgoWideSmartMessagingSessionLock);
    this.Field.Add("RadErgoWideSmartMappingSessionLock", (IAcpField) this.RadioErgonomicsWide.ApplicationSessionLock.RadErgoWideSmartMappingSessionLock);
    this.Field.Add("RadErgoWideSessionLockUserActTimeout", (IAcpField) this.RadioErgonomicsWide.ApplicationSessionLock.RadErgoWideSessionLockUserActTimeout);
  }

  private void AddRadioProfiles()
  {
    this.Field.Add("RadProfGeneralRadioProfileName_A19564", (IAcpField) this.RadioProfiles.General.RadProfGeneralRadioProfileName_A19564);
    this.Field.Add("RadProfNVGEnable_A41615", (IAcpField) this.RadioProfiles.General.RadProfNVGEnable_A41615);
    this.Field.Add("PermanentFrontDisplayBacklight_A22337", (IAcpField) this.RadioProfiles.General.PermanentFrontDisplayBacklight_A22337);
    this.Field.Add("RadProfPermanentDisableTxRxLED_A41609", (IAcpField) this.RadioProfiles.General.RadProfPermanentDisableTxRxLED_A41609);
    this.Field.Add("RadProfAlertTonesAlertToneVolumeOffsetdB_A7427", (IAcpField) this.RadioProfiles.AlertTones.RadProfAlertTonesAlertToneVolumeOffsetdB_A7427);
    this.Field.Add("RadProfGeneralSpeakerAudioRouting_A19566", (IAcpField) this.RadioProfiles.General.RadProfGeneralSpeakerAudioRouting_A19566);
    this.Field.Add("RadProfGeneralDisableLights_A7866", (IAcpField) this.RadioProfiles.General.RadProfGeneralDisableLights_A7866);
    this.Field.Add("RadProfGeneralDisableTones_A7870", (IAcpField) this.RadioProfiles.General.RadProfGeneralDisableTones_A7870);
    this.Field.Add("RadProfGeneralDisableEmergencyAlertsNotification_A19570", (IAcpField) this.RadioProfiles.General.RadProfGeneralDisableEmergencyAlertsNotification_A19570);
    this.Field.Add("RadProfGeneralDisableCriticalAlertsNotification_A19571", (IAcpField) this.RadioProfiles.General.RadProfGeneralDisableCriticalAlertsNotification_A19571);
    this.Field.Add("RadProfGeneralDisableCallAlertsNotification_A19572", (IAcpField) this.RadioProfiles.General.RadProfGeneralDisableCallAlertsNotification_A19572);
    this.Field.Add("RadProfAlertTonesMinimumAlertToneVolume_A8521", (IAcpField) this.RadioProfiles.AlertTones.RadProfAlertTonesMinimumAlertToneVolume_A8521);
    this.Field.Add("RadProfAudioSettingsMaximumAlertToneVolume_A21368", (IAcpField) this.RadioProfiles.AlertTones.RadProfAudioSettingsMaximumAlertToneVolume_A21368);
    this.Field.Add("RadProfAudioSettingsMaximumAudioVolume_A19577", (IAcpField) this.RadioProfiles.AudioSettings.RadProfAudioSettingsMaximumAudioVolume_A19577);
    this.Field.Add("RadProfAlertTonesMinimumAudioVolume_A8517", (IAcpField) this.RadioProfiles.AudioSettings.RadProfAlertTonesMinimumAudioVolume_A8517);
    this.Field.Add("RadProfAudioSettingsCustomGlobalNoiseReductionEnable_A36174", (IAcpField) this.RadioProfiles.AudioSettings.RadProfAudioSettingsCustomGlobalNoiseReductionEnable_A36174);
    this.Field.Add("RadProfAudioSettingsCustomIntMicNoiseReductionEnable_A22294", (IAcpField) this.RadioProfiles.AudioSettings.RadProfAudioSettingsCustomIntMicNoiseReductionEnable_A22294);
    this.Field.Add("RadProfAudioSettingsInternalMicGeneralNoiseReductionLevelSelection_A22292", (IAcpField) this.RadioProfiles.AudioSettings.RadProfAudioSettingsInternalMicGeneralNoiseReductionLevelSelection_A22292);
    this.Field.Add("RadProfAudioSettingsInternalMicWindNoiseReductionLevelSelection_A22194", (IAcpField) this.RadioProfiles.AudioSettings.RadProfAudioSettingsInternalMicWindNoiseReductionLevelSelection_A22194);
    this.Field.Add("RadProfAudioSettingsCustomExtMicNoiseReductionEnable_A22294", (IAcpField) this.RadioProfiles.AudioSettings.RadProfAudioSettingsCustomExtMicNoiseReductionEnable_A22294);
    this.Field.Add("RadProfAudioSettingsExternalMicGeneralNoiseReductionLevelSelection_A22291", (IAcpField) this.RadioProfiles.AudioSettings.RadProfAudioSettingsExternalMicGeneralNoiseReductionLevelSelection_A22291);
    this.Field.Add("RadProfExternalMicWindNoiseReductionLevelSelection_A21511", (IAcpField) this.RadioProfiles.AudioSettings.RadProfExternalMicWindNoiseReductionLevelSelection_A21511);
    this.Field.Add("RadioProfileAudioSettingsTxDigitalAnalogBalance_A37715", (IAcpField) this.RadioProfiles.AudioSettings.RadioProfileAudioSettingsTxDigitalAnalogBalance_A37715);
    this.Field.Add("RadioProfilesAudioSettingsMicHWAGC_A37722", (IAcpField) this.RadioProfiles.AudioSettings.RadioProfilesAudioSettingsMicHWAGC_A37722);
    this.Field.Add("RadProfAudioSettingsAnalogAGC1_A7440", (IAcpField) this.RadioProfiles.AudioSettings.RadProfAudioSettingsAnalogAGC1_A7440);
    this.Field.Add("RadProfAudioSettingsDigitalAGC1_A7854", (IAcpField) this.RadioProfiles.AudioSettings.RadProfAudioSettingsDigitalAGC1_A7854);
    this.Field.Add("RadProfAudioSettingsSecurenetAGC1_A9099", (IAcpField) this.RadioProfiles.AudioSettings.RadProfAudioSettingsSecurenetAGC1_A9099);
    this.Field.Add("RadProfAudioSettingsAnalogFixedGain1_A7442", (IAcpField) this.RadioProfiles.AudioSettings.RadProfAudioSettingsAnalogFixedGain1_A7442);
    this.Field.Add("RadProfAudioSettingsDigitalFixedGain1_A7856", (IAcpField) this.RadioProfiles.AudioSettings.RadProfAudioSettingsDigitalFixedGain1_A7856);
    this.Field.Add("RadProfAudioSettingsSecurenetFixedGain1_A9100", (IAcpField) this.RadioProfiles.AudioSettings.RadProfAudioSettingsSecurenetFixedGain1_A9100);
    this.Field.Add("RadProfAudioSettingsAnalogAGC2_A7439", (IAcpField) this.RadioProfiles.AudioSettings.RadProfAudioSettingsAnalogAGC2_A7439);
    this.Field.Add("RadProfAudioSettingsDigitalAGC2_A7853", (IAcpField) this.RadioProfiles.AudioSettings.RadProfAudioSettingsDigitalAGC2_A7853);
    this.Field.Add("RadProfAudioSettingsSecurenetAGC2_A9098", (IAcpField) this.RadioProfiles.AudioSettings.RadProfAudioSettingsSecurenetAGC2_A9098);
    this.Field.Add("RadProfAudioSettingsAnalogFixedGain2_A7441", (IAcpField) this.RadioProfiles.AudioSettings.RadProfAudioSettingsAnalogFixedGain2_A7441);
    this.Field.Add("RadProfAudioSettingsDigitalFixedGain2_A7855", (IAcpField) this.RadioProfiles.AudioSettings.RadProfAudioSettingsDigitalFixedGain2_A7855);
    this.Field.Add("RadProfAudioSettingsSecurenetFixedGain2_A9101", (IAcpField) this.RadioProfiles.AudioSettings.RadProfAudioSettingsSecurenetFixedGain2_A9101);
    this.Field.Add("RadProfAudioSettingsOutput_A8679", (IAcpField) this.RadioProfiles.AudioSettings.RadProfAudioSettingsOutput_A8679);
    this.Field.Add("RadProfAudioSettingsTotal_A9394", (IAcpField) this.RadioProfiles.AudioSettings.RadProfAudioSettingsTotal_A9394);
    this.Field.Add("RadProfAudioSettingsAnalog_A7438", (IAcpField) this.RadioProfiles.AudioSettings.RadProfAudioSettingsAnalog_A7438);
    this.Field.Add("RadProfAudioSettingsDigital_A7850", (IAcpField) this.RadioProfiles.AudioSettings.RadProfAudioSettingsDigital_A7850);
    this.Field.Add("RadProfAudioSettingsSecurenet_A9097", (IAcpField) this.RadioProfiles.AudioSettings.RadProfAudioSettingsSecurenet_A9097);
    this.Field.Add("RadProfAudioSettingsBluetoothMicGainLevel_41989", (IAcpField) this.RadioProfiles.AudioSettings.RadProfAudioSettingsBluetoothMicGainLevel_41989);
    this.Field.Add("RadProfCustomAudioInternalMicNoiseReductionProfileCompositeItemID_A22312", (IAcpField) this.RadioProfiles.LabtoolRAD_PROF_CDA.RadProfCustomAudioInternalMicNoiseReductionProfileCompositeItemID_A22312);
    this.Field.Add("RadProfLabtoolCustomAudioExtMicNoiseReductionProfileCompositeItemID_A22314", (IAcpField) this.RadioProfiles.LabtoolRAD_PROF_CDA.RadProfLabtoolCustomAudioExtMicNoiseReductionProfileCompositeItemID_A22314);
    this.Field.Add("RadProfAudioSettingsInternalMicOtherNoiseMode_A22196", (IAcpField) this.RadioProfiles.LabtoolRAD_PROF_CDA.RadProfAudioSettingsInternalMicOtherNoiseMode_A22196);
    this.Field.Add("RadProfAudioSettingsExternalMicOtherNoiseMode_A21551", (IAcpField) this.RadioProfiles.LabtoolRAD_PROF_CDA.RadProfAudioSettingsExternalMicOtherNoiseMode_A21551);
    this.Field.Add("RadProfAudioSettingsInternalMicWindNoiseReductionMode_A22197", (IAcpField) this.RadioProfiles.LabtoolRAD_PROF_CDA.RadProfAudioSettingsInternalMicWindNoiseReductionMode_A22197);
    this.Field.Add("RadProfAudioSettingsExternalMicWindNoiseReductionMode_A21550", (IAcpField) this.RadioProfiles.LabtoolRAD_PROF_CDA.RadProfAudioSettingsExternalMicWindNoiseReductionMode_A21550);
    this.Field.Add("RadProfAudioSettingsInternalMicSourceMode_A22193", (IAcpField) this.RadioProfiles.LabtoolRAD_PROF_CDA.RadProfAudioSettingsInternalMicSourceMode_A22193);
    this.Field.Add("RadProfLabtoolExternalMicSourceMode_A21548", (IAcpField) this.RadioProfiles.LabtoolRAD_PROF_CDA.RadProfLabtoolExternalMicSourceMode_A21548);
    this.Field.Add("RadProfAudioSettingsInternalMicDirectivityMode_A22195", (IAcpField) this.RadioProfiles.LabtoolRAD_PROF_CDA.RadProfAudioSettingsInternalMicDirectivityMode_A22195);
    this.Field.Add("RadProfAudioSettingsExternalMicDirectivityMode_A21549", (IAcpField) this.RadioProfiles.LabtoolRAD_PROF_CDA.RadProfAudioSettingsExternalMicDirectivityMode_A21549);
    this.Field.Add("RadProfLabtoolAnalogBassControl_A19506", (IAcpField) this.RadioProfiles.LabtoolRAD_PROF_CDA.RadProfLabtoolAnalogBassControl_A19506);
    this.Field.Add("RadProfLabtoolDigitalBassControl_A19507", (IAcpField) this.RadioProfiles.LabtoolRAD_PROF_CDA.RadProfLabtoolDigitalBassControl_A19507);
    this.Field.Add("RadProfLabtoolSecurenetBassControl_A19508", (IAcpField) this.RadioProfiles.LabtoolRAD_PROF_CDA.RadProfLabtoolSecurenetBassControl_A19508);
    this.Field.Add("RadProfAudioSettingsIntMicPassAlarmFilter_A42382", (IAcpField) this.RadioProfiles.AudioSettings.RadProfAudioSettingsIntMicPassAlarmFilter_A42382);
    this.Field.Add("RadProfAudioSettingsExternalMicPassAlarmFilter_A42386", (IAcpField) this.RadioProfiles.AudioSettings.RadProfAudioSettingsExternalMicPassAlarmFilter_A42386);
    this.Field.Add("NoiseReductionGroupSettingRadio_42584", (IAcpField) this.RadioProfiles.AudioSettings.NoiseReductionGroupSettingRadio_42584);
    this.Field.Add("NoiseReductionGroupSettingAccessory_42585", (IAcpField) this.RadioProfiles.AudioSettings.NoiseReductionGroupSettingAccessory_42585);
    this.Field.Add("GainSensitivityGroupSettingRadio_42608", (IAcpField) this.RadioProfiles.AudioSettings.GainSensitivityGroupSettingRadio_42608);
    this.Field.Add("GainSensitivityGroupSettingAccessory_42610", (IAcpField) this.RadioProfiles.AudioSettings.GainSensitivityGroupSettingAccessory_42610);
    this.Field.Add("AudioEqualizationGroupSettingRadio_42613", (IAcpField) this.RadioProfiles.AudioSettings.AudioEqualizationGroupSettingRadio_42613);
    this.Field.Add("AudioEqualizationGroupSettingAccessory_42614", (IAcpField) this.RadioProfiles.AudioSettings.AudioEqualizationGroupSettingAccessory_42614);
    this.Field.Add("LowFrequencyBandRadio_42638", (IAcpField) this.RadioProfiles.AudioSettings.LowFrequencyBandRadio_42638);
    this.Field.Add("LowFrequencyBandAccessory_42639", (IAcpField) this.RadioProfiles.AudioSettings.LowFrequencyBandAccessory_42639);
    this.Field.Add("MidFrequencyBandRadio_42640", (IAcpField) this.RadioProfiles.AudioSettings.MidFrequencyBandRadio_42640);
    this.Field.Add("MidFrequencyBandAccessory_42641", (IAcpField) this.RadioProfiles.AudioSettings.MidFrequencyBandAccessory_42641);
    this.Field.Add("HighFrequencyBandRadio_42642", (IAcpField) this.RadioProfiles.AudioSettings.HighFrequencyBandRadio_42642);
    this.Field.Add("HighFrequencyBandAccessory_42643", (IAcpField) this.RadioProfiles.AudioSettings.HighFrequencyBandAccessory_42643);
    this.Field.Add("AGCGainControlOutputAccessory_42644", (IAcpField) this.RadioProfiles.AudioSettings.AGCGainControlOutputAccessory_42644);
    this.Field.Add("AGCGainControlTotalAccessory_42645", (IAcpField) this.RadioProfiles.AudioSettings.AGCGainControlTotalAccessory_42645);
    this.Field.Add("RadioProfileAudioSettingsDigitalAnalogBalanceAccessory_42661", (IAcpField) this.RadioProfiles.AudioSettings.RadioProfileAudioSettingsDigitalAnalogBalanceAccessory_42661);
    this.Field.Add("AudioEqualizationGroupSettingRadio_42604", (IAcpField) this.RadioProfiles.AudioSettings.AudioEqualizationGroupSettingRadio_42604);
    this.Field.Add("AudioEqualizationGroupSettingAccessory_42605", (IAcpField) this.RadioProfiles.AudioSettings.AudioEqualizationGroupSettingAccessory_42605);
    this.Field.Add("AnalogLowFrequencyBandAccessory_42647", (IAcpField) this.RadioProfiles.AudioSettings.AnalogLowFrequencyBandAccessory_42647);
    this.Field.Add("AnalogMidFrequencyBandRadio_42648", (IAcpField) this.RadioProfiles.AudioSettings.AnalogMidFrequencyBandRadio_42648);
    this.Field.Add("AnalogMidFrequencyBandAccessory_42649", (IAcpField) this.RadioProfiles.AudioSettings.AnalogMidFrequencyBandAccessory_42649);
    this.Field.Add("AnalogHighFrequencyBandAccessory_42650", (IAcpField) this.RadioProfiles.AudioSettings.AnalogHighFrequencyBandAccessory_42650);
    this.Field.Add("DigitalLowFrequencyBandAccessory_42652", (IAcpField) this.RadioProfiles.AudioSettings.DigitalLowFrequencyBandAccessory_42652);
    this.Field.Add("DigitalMidFrequencyBandRadio_42653", (IAcpField) this.RadioProfiles.AudioSettings.DigitalMidFrequencyBandRadio_42653);
    this.Field.Add("DigitalMidFrequencyBandAccessory_42654", (IAcpField) this.RadioProfiles.AudioSettings.DigitalMidFrequencyBandAccessory_42654);
    this.Field.Add("DigitalHighFrequencyBandAccessory_42655", (IAcpField) this.RadioProfiles.AudioSettings.DigitalHighFrequencyBandAccessory_42655);
    this.Field.Add("SecurenetLowFrequencyBandAccessory_42657", (IAcpField) this.RadioProfiles.AudioSettings.SecurenetLowFrequencyBandAccessory_42657);
    this.Field.Add("SecurenetMidFrequencyBandRadio_42658", (IAcpField) this.RadioProfiles.AudioSettings.SecurenetMidFrequencyBandRadio_42658);
    this.Field.Add("SecurenetMidFrequencyBandAccessory_42659", (IAcpField) this.RadioProfiles.AudioSettings.SecurenetMidFrequencyBandAccessory_42659);
    this.Field.Add("SecurenetHighFrequencyBandAccessory_42660", (IAcpField) this.RadioProfiles.AudioSettings.SecurenetHighFrequencyBandAccessory_42660);
    this.Field.Add("RadWideAudioConfigurationLevel_42740", (IAcpField) this.RadioWide.DigitalAudioOptions.RadWideAudioConfigurationLevel_42740);
    this.Field.Add("RadWideDigitalAudioOptionsICUAPowerUpMuted", (IAcpField) this.RadioWide.DigitalAudioOptions.RadWideDigitalAudioOptionsICUAPowerUpMuted);
  }

  private void AddRadioVIPs()
  {
    this.Field.Add("RadVipName_A22501", (IAcpField) this.RadioVIPInner.RadioVIPInnerSection.RadVipName_A22501);
    this.Field.Add("RadVipInputBCO_A21328", (IAcpField) this.RadioVIPInner.RadioVIPInnerSection.RadVipInputBCO_A21328);
    this.Field.Add("RadVipInputFeature_A21329", (IAcpField) this.RadioVIPInner.RadioVIPInnerSection.RadVipInputFeature_A21329);
    this.Field.Add("RadVipOutputBCO_A20946", (IAcpField) this.RadioVIPInner.RadioVIPInnerSection.RadVipOutputBCO_A20946);
    this.Field.Add("RadVipOutputFeature_A20947", (IAcpField) this.RadioVIPInner.RadioVIPInnerSection.RadVipOutputFeature_A20947);
    this.Field.Add("RadVipKey_A22500", (IAcpField) this.RadioVIPInner.RadioVIPInnerSection.RadVipKey_A22500);
    this.Field.Add("RadioVIPShortPressTime", (IAcpField) this.RadioVIPInner.RadioVIPInnerSection.RadioVIPShortPressTime);
    this.Field.Add("RadioVIPLongPressTime", (IAcpField) this.RadioVIPInner.RadioVIPInnerSection.RadioVIPLongPressTime);
  }

  private void AddRepeaterIDList()
  {
    this.Field.Add("CnvCfgMDCRepeaterIDListRepeaterID_A8941", (IAcpField) this.MDCRepeaterIDTableInner.MDCRepeaterIDTableInnerSection.CnvCfgMDCRepeaterIDListRepeaterID_A8941);
    this.Field.Add("CnvCfgSingletoneFrequencyListToneHz_A9385", (IAcpField) this.SingletoneFrequencyTableInner.SingletoneFrequencyTableInnerSection.CnvCfgSingletoneFrequencyListToneHz_A9385);
  }

  private void AddScanWide()
  {
    this.Field.Add("ScanWideRadioWidePriorityScanAlert_A8752", (IAcpField) this.ScanWide.General.ScanWideRadioWidePriorityScanAlert_A8752);
    this.Field.Add("ScanWideRadioWideHUBSuspendsScan_A8216", (IAcpField) this.ScanWide.General.ScanWideRadioWideHUBSuspendsScan_A8216);
    this.Field.Add("ScanWideRadioWideSuspendAllScan_A9232", (IAcpField) this.ScanWide.General.ScanWideRadioWideSuspendAllScan_A9232);
    this.Field.Add("ScanWideRadioWideVoiceRxTxHoldTimeSec_A9653", (IAcpField) this.ScanWide.General.ScanWideRadioWideVoiceRxTxHoldTimeSec_A9653);
    this.Field.Add("ScanWideRadioWideDataRxTxHoldTimesec_A7797", (IAcpField) this.ScanWide.General.ScanWideRadioWideDataRxTxHoldTimesec_A7797);
    this.Field.Add("ScanWideConventionalCarrierDetectRequired_A7611", (IAcpField) this.ScanWide.Conventional.ScanWideConventionalCarrierDetectRequired_A7611);
    this.Field.Add("ScanWideConventionalPriorityChannelMarking_A8750", (IAcpField) this.ScanWide.Conventional.ScanWideConventionalPriorityChannelMarking_A8750);
    this.Field.Add("ScanWideConventionalMonitorHoldTimesec_A8543", (IAcpField) this.ScanWide.Conventional.ScanWideConventionalMonitorHoldTimesec_A8543);
    this.Field.Add("ScanWideConventionalTimeBetweenPrioritySamplesms_A9376", (IAcpField) this.ScanWide.Conventional.ScanWideConventionalTimeBetweenPrioritySamplesms_A9376);
    this.Field.Add("ScanWideConventionalRSSIVotingThreshold_A8997", (IAcpField) this.ScanWide.Conventional.ScanWideConventionalRSSIVotingThreshold_A8997);
    this.Field.Add("ScanWideTrunkingFailsoftHoldTimesec_A8009", (IAcpField) this.ScanWide.Trunking.ScanWideTrunkingFailsoftHoldTimesec_A8009);
    this.Field.Add("ScanWideTrunkingSystemSearchTimesec_A9250", (IAcpField) this.ScanWide.Trunking.ScanWideTrunkingSystemSearchTimesec_A9250);
    this.Field.Add("ScanWideLabtoolScanDetectTimeForPL_A9049", (IAcpField) this.ScanWide.Labtool.ScanWideLabtoolScanDetectTimeForPL_A9049);
    this.Field.Add("ScanWideLabtoolScanDetectTimeForCarrierSquelch_A9048", (IAcpField) this.ScanWide.Labtool.ScanWideLabtoolScanDetectTimeForCarrierSquelch_A9048);
    this.Field.Add("ScanWideLabtoolLookbackTime_A8454", (IAcpField) this.ScanWide.Labtool.ScanWideLabtoolLookbackTime_A8454);
  }

  private void AddSecureKMFProfile()
  {
    this.Field.Add("SecKmfProfSecureHardwareEncryptionKeyReferencesListCKRNumber_A7667", (IAcpField) this.SecureHardwareEncryptionKeyReferencesListInner.SecureHardwareEncryptionKeyReferencesListInnerSection.SecKmfProfSecureHardwareEncryptionKeyReferencesListCKRNumber_A7667);
    this.Field.Add("SecKmfProfSecureHardwareEncryptionKeyReferencesListHardwareKeyReference_A8194", (IAcpField) this.SecureHardwareEncryptionKeyReferencesListInner.SecureHardwareEncryptionKeyReferencesListInnerSection.SecKmfProfSecureHardwareEncryptionKeyReferencesListHardwareKeyReference_A8194);
    this.Field.Add("SecProfIndependMultikeyListCKR_43594", (IAcpField) this.SecureHardwareEncryptionIndependentKeyListInner.SecureHardwareEncryptionIndependentKeyListInnerSection.SecProfIndependMultikeyListCKR_43594);
    this.Field.Add("SecProfIndependMultikeyListKeyName_43595", (IAcpField) this.SecureHardwareEncryptionIndependentKeyListInner.SecureHardwareEncryptionIndependentKeyListInnerSection.SecProfIndependMultikeyListKeyName_43595);
    this.Field.Add("SecProfIndependMultikeyListProvisionHardwareCryptoModule", (IAcpField) this.SecureHardwareEncryptionIndependentKeyListInner.SecureHardwareEncryptionIndependentKeyListInnerSection.SecProfIndependMultikeyListProvisionHardwareCryptoModule);
    this.Field.Add("SecProfIndependMultikeyListSelectableADPKeyID", (IAcpField) this.SecureHardwareEncryptionIndependentKeyListInner.SecureHardwareEncryptionIndependentKeyListInnerSection.SecProfIndependMultikeyListSelectableADPKeyID);
    this.Field.Add("SecProfIndependMultikeyListSelectableADPKeyData", (IAcpField) this.SecureHardwareEncryptionIndependentKeyListInner.SecureHardwareEncryptionIndependentKeyListInnerSection.SecProfIndependMultikeyListSelectableADPKeyData);
    this.Field.Add("SecKmfProfASTROOTARInformationKeyofSecureKMFProfile_A12663", (IAcpField) this.SecureKMFProfile.ASTROOTARInformation.SecKmfProfASTROOTARInformationKeyofSecureKMFProfile_A12663);
    this.Field.Add("SecKmfProfASTROOTARInformationErasePreviousKeysetonOTARChangeover_A7978", (IAcpField) this.SecureKMFProfile.ASTROOTARInformation.SecKmfProfASTROOTARInformationErasePreviousKeysetonOTARChangeover_A7978);
    this.Field.Add("SecKmfProfASTROOTARInformationIndividualASTROOTARRadioID_A8285", (IAcpField) this.SecureKMFProfile.ASTROOTARInformation.SecKmfProfASTROOTARInformationIndividualASTROOTARRadioID_A8285);
    this.Field.Add("SecKmfProfASTROOTARInformationNumberofAttempts_A8576", (IAcpField) this.SecureKMFProfile.ASTROOTARInformation.SecKmfProfASTROOTARInformationNumberofAttempts_A8576);
    this.Field.Add("SecKmfProfASTROOTARInformationOTARInactivityTimerhr_A8673", (IAcpField) this.SecureKMFProfile.ASTROOTARInformation.SecKmfProfASTROOTARInformationOTARInactivityTimerhr_A8673);
    this.Field.Add("SecKmfProfASTROOTARInformationOTARRxSecurityLevel_A8674", (IAcpField) this.SecureKMFProfile.ASTROOTARInformation.SecKmfProfASTROOTARInformationOTARRxSecurityLevel_A8674);
    this.Field.Add("SecKmfProfASTROOTARInformationOTARTxSecurityLevel_A8677", (IAcpField) this.SecureKMFProfile.ASTROOTARInformation.SecKmfProfASTROOTARInformationOTARTxSecurityLevel_A8677);
    this.Field.Add("SecKmfProfASTROOTARInformationRekeyRequestStatusAlertTone_A8928", (IAcpField) this.SecureKMFProfile.ASTROOTARInformation.SecKmfProfASTROOTARInformationRekeyRequestStatusAlertTone_A8928);
    this.Field.Add("SecKmfProfASTROOTARInformationResponseKind_A8947", (IAcpField) this.SecureKMFProfile.ASTROOTARInformation.SecKmfProfASTROOTARInformationResponseKind_A8947);
    this.Field.Add("SecKmfProfASTROOTARInformationTimeBetweenAttemptssec_A9375", (IAcpField) this.SecureKMFProfile.ASTROOTARInformation.SecKmfProfASTROOTARInformationTimeBetweenAttemptssec_A9375);
    this.Field.Add("SecKmfProfASTROOTARInformationUserSelectableRekeyRequest_A9608", (IAcpField) this.SecureKMFProfile.ASTROOTARInformation.SecKmfProfASTROOTARInformationUserSelectableRekeyRequest_A9608);
    this.Field.Add("SecKmfProfDataTransportKMFIPAddress_A8375", (IAcpField) this.SecureKMFProfile.DataTransport.SecKmfProfDataTransportKMFIPAddress_A8375);
    this.Field.Add("SecKmfProfDataTransportKMFUDPPort_A8384", (IAcpField) this.SecureKMFProfile.DataTransport.SecKmfProfDataTransportKMFUDPPort_A8384);
    this.Field.Add("SecKmfProfDataTransportSubscriberOTARPort_A9226", (IAcpField) this.SecureKMFProfile.DataTransport.SecKmfProfDataTransportSubscriberOTARPort_A9226);
    this.Field.Add("SecKmfProfLabtoolLastUserSelectedProfileKey_A8416", (IAcpField) this.SecureKMFProfile.Labtool.SecKmfProfLabtoolLastUserSelectedProfileKey_A8416);
    this.Field.Add("TouchlessKeyProvisioningEnabled", (IAcpField) this.SecureKMFProfile.ASTROOTARInformation.TouchlessKeyProvisioningEnabled);
    this.Field.Add("UseKVLForKMFRSIAndMNP", (IAcpField) this.SecureKMFProfile.ASTROOTARInformation.UseKVLForKMFRSIAndMNP);
    this.Field.Add("KMFRSI", (IAcpField) this.SecureKMFProfile.ASTROOTARInformation.KMFRSI);
    this.Field.Add("MessageNumberPeriod", (IAcpField) this.SecureKMFProfile.ASTROOTARInformation.MessageNumberPeriod);
  }

  private void AddSecureWide()
  {
    this.Field.Add("SecWideGeneralSecureOperation_A9067", (IAcpField) this.SecureWide.General.SecWideGeneralSecureOperation_A9067);
    this.Field.Add("SecWideGeneralOTAREnable_A7966", (IAcpField) this.SecureWide.General.SecWideGeneralOTAREnable_A7966);
    this.Field.Add("SecWideGeneralOTARGenerateKeyLossKey_A8169", (IAcpField) this.SecureWide.General.SecWideGeneralOTARGenerateKeyLossKey_A8169);
    this.Field.Add("SecureConfigurationSecureWide_A19833", (IAcpField) this.SecureWide.General.SecureConfigurationSecureWide_A19833);
    this.Field.Add("SecWideGeneralEnhancedADPRadioInhibit_A41461", (IAcpField) this.SecureWide.General.SecWideGeneralEnhancedADPRadioInhibit_A41461);
    this.Field.Add("SecWideASTROOTARASTROOTAREnable_A7496", (IAcpField) this.SecureWide.ASTROOTAR.SecWideASTROOTARASTROOTAREnable_A7496);
    this.Field.Add("SecWideASTROOTARRadioInhibitviaASTROOTAR_A8834", (IAcpField) this.SecureWide.ASTROOTAR.SecWideASTROOTARRadioInhibitviaASTROOTAR_A8834);
    this.Field.Add("SecWideASTROOTARIndividualASTROOTARRadioID_A8284", (IAcpField) this.SecureWide.ASTROOTAR.SecWideASTROOTARIndividualASTROOTARRadioID_A8284);
    this.Field.Add("SecWideMDCOTARMDCOTAREnable_A8488", (IAcpField) this.SecureWide.MDCOTAR.SecWideMDCOTARMDCOTAREnable_A8488);
    this.Field.Add("SecWideMDCOTARRadioInhibitviaMDCOTAR_A8835", (IAcpField) this.SecureWide.MDCOTAR.SecWideMDCOTARRadioInhibitviaMDCOTAR_A8835);
    this.Field.Add("SecWideMDCOTAREnable_A7967", (IAcpField) this.SecureWide.MDCOTAR.SecWideMDCOTAREnable_A7967);
    this.Field.Add("SecWideMDCOTAREncryptedOnly_A7971", (IAcpField) this.SecureWide.MDCOTAR.SecWideMDCOTAREncryptedOnly_A7971);
    this.Field.Add("SecWideMDCOTARPowerUp_A8716", (IAcpField) this.SecureWide.MDCOTAR.SecWideMDCOTARPowerUp_A8716);
    this.Field.Add("SecWideMDCOTARMode_A8533", (IAcpField) this.SecureWide.MDCOTAR.SecWideMDCOTARMode_A8533);
    this.Field.Add("SecWideMDCOTARStatusAlertTone_A8489", (IAcpField) this.SecureWide.MDCOTAR.SecWideMDCOTARStatusAlertTone_A8489);
    this.Field.Add("SecWideMDCOTARErasePreviousIndexonIndexChange_A7976", (IAcpField) this.SecureWide.MDCOTAR.SecWideMDCOTARErasePreviousIndexonIndexChange_A7976);
    this.Field.Add("SecWideMDCOTARKMCID_A8374", (IAcpField) this.SecureWide.MDCOTAR.SecWideMDCOTARKMCID_A8374);
    this.Field.Add("SecWideMDCOTARMDCOTARSystem_A8490", (IAcpField) this.SecureWide.MDCOTAR.SecWideMDCOTARMDCOTARSystem_A8490);
    this.Field.Add("SecWideFeaturesInfiniteKeyRetention_A8292", (IAcpField) this.SecureWide.Features.SecWideFeaturesInfiniteKeyRetention_A8292);
    this.Field.Add("SecWideInfiniteUKEKRetention_A41551", (IAcpField) this.SecureWide.General.SecWideInfiniteUKEKRetention_A41551);
    this.Field.Add("SecWideFeaturesProperCodeEnhancer_A8764", (IAcpField) this.SecureWide.Features.SecWideFeaturesProperCodeEnhancer_A8764);
    this.Field.Add("SecWideFeaturesPeriodicKeyfailAlertTone_A8695", (IAcpField) this.SecureWide.Features.SecWideFeaturesPeriodicKeyfailAlertTone_A8695);
    this.Field.Add("SecWideFeaturesClearAlertTones_A9524", (IAcpField) this.SecureWide.Features.SecWideFeaturesClearAlertTones_A9524);
    this.Field.Add("SecWideFeaturesIgnoreSecureClearSwitchWhenStrapped_A8238", (IAcpField) this.SecureWide.Features.SecWideFeaturesIgnoreSecureClearSwitchWhenStrapped_A8238);
    this.Field.Add("SecWideFeaturesNonXLScanUnsquelchDurationms_A8570", (IAcpField) this.SecureWide.Features.SecWideFeaturesNonXLScanUnsquelchDurationms_A8570);
    this.Field.Add("SecWideFeaturesXLScanUnsquelchDurationMs_A9682", (IAcpField) this.SecureWide.Features.SecWideFeaturesXLScanUnsquelchDurationMs_A9682);
    this.Field.Add("SecWideMultikeyDisplayOnSecureSwitchSelect_A7881", (IAcpField) this.SecureWide.Multikey.SecWideMultikeyDisplayOnSecureSwitchSelect_A7881);
    this.Field.Add("SecWideMultikeyDisplayOnPTT_A7879", (IAcpField) this.SecureWide.Multikey.SecWideMultikeyDisplayOnPTT_A7879);
    this.Field.Add("SecWideMultikeyDisplayOnModeChange_A7877", (IAcpField) this.SecureWide.Multikey.SecWideMultikeyDisplayOnModeChange_A7877);
    this.Field.Add("SecWideMultikeyPIDKeyManagementforASNMode_A8704", (IAcpField) this.SecureWide.Multikey.SecWideMultikeyPIDKeyManagementforASNMode_A8704);
    this.Field.Add("SecWideMultikeyRxHangTimems_A9019", (IAcpField) this.SecureWide.Multikey.SecWideMultikeyRxHangTimems_A9019);
    this.Field.Add("SecWideMultikeyTxHangTimeMs_A9540", (IAcpField) this.SecureWide.Multikey.SecWideMultikeyTxHangTimeMs_A9540);
    this.Field.Add("SecWideMultikeyUserSelectable_A9604", (IAcpField) this.SecureWide.General.SecWideMultikeyUserSelectable_A9604);
    this.Field.Add("SecWideMultikeyErasePreviousOnUserChange_A8373", (IAcpField) this.SecureWide.General.SecWideMultikeyErasePreviousOnUserChange_A8373);
    this.Field.Add("SecWideMultikeyListKeyName_A8362", (IAcpField) this.EncryptionKeyListInner.EncryptionKeyListInnerSection.SecWideMultikeyListKeyName_A8362);
    this.Field.Add("SecWideMultikeyListCKR_A7665", (IAcpField) this.EncryptionKeyListInner.EncryptionKeyListInnerSection.SecWideMultikeyListCKR_A7665);
    this.Field.Add("SecWideMultikeyListIndexed_A8282", (IAcpField) this.EncryptionKeyListInner.EncryptionKeyListInnerSection.SecWideMultikeyListIndexed_A8282);
    this.Field.Add("SecWideMultikeyListSlotA_A9155", (IAcpField) this.EncryptionKeyListInner.EncryptionKeyListInnerSection.SecWideMultikeyListSlotA_A9155);
    this.Field.Add("SecWideMultikeyListSlotB_A9158", (IAcpField) this.EncryptionKeyListInner.EncryptionKeyListInnerSection.SecWideMultikeyListSlotB_A9158);
    this.Field.Add("SecWideMultikeyListSelectableADPKeyData_A9106", (IAcpField) this.EncryptionKeyListInner.EncryptionKeyListInnerSection.SecWideMultikeyListSelectableADPKeyData_A9106);
    this.Field.Add("SecWideMultikeyListSelectableADPKeyID_A9107", (IAcpField) this.EncryptionKeyListInner.EncryptionKeyListInnerSection.SecWideMultikeyListSelectableADPKeyID_A9107);
    this.Field.Add("ProvisionHardwareCryptoModule", (IAcpField) this.EncryptionKeyListInner.EncryptionKeyListInnerSection.ProvisionHardwareCryptoModule);
    this.Field.Add("SecWideLabtoolPIDIndexMapping_A8279", (IAcpField) this.SecureWide.Labtool.SecWideLabtoolPIDIndexMapping_A8279);
    this.Field.Add("SecWideGeneralOTAROperation_43700", (IAcpField) this.SecureWide.General.SecWideGeneralOTAROperation_43700);
    this.Field.Add("SecureWideDESAlgorithmEnable_43744", (IAcpField) this.SecureWide.General.SecureWideDESAlgorithmEnable_43744);
    this.Field.Add("SecureWideAESAlgorithmEnable_43201", (IAcpField) this.SecureWide.General.SecureWideAESAlgorithmEnable_43201);
  }

  private void AddShepherds()
  {
    this.Field.Add("ConventionalProductIndependentButtonKey", (IAcpField) this.ConventionalProductIndependentButtonListInner.ConventionalProductIndependentButtonListInnerSection.ConventionalProductIndependentButtonKey);
    this.Field.Add("TrunkingProductIndependentButtonKey", (IAcpField) this.TrunkingProductIndependentButtonListInner.TrunkingProductIndependentButtonListInnerSection.TrunkingProductIndependentButtonKey);
    this.Field.Add("RadErgoCfgSignalIndepBtnListID_A21171", (IAcpField) this.GlobalShepherdListInner.GlobalShepherdListInnerSection.RadErgoCfgSignalIndepBtnListID_A21171);
    this.Field.Add("RadErgoCfgSignalIndepBtnListType_A21172", (IAcpField) this.GlobalShepherdListInner.GlobalShepherdListInnerSection.RadErgoCfgSignalIndepBtnListType_A21172);
    this.Field.Add("RadErgoCfgSignalIndepBtnListKey_A21276", (IAcpField) this.GlobalShepherdListInner.GlobalShepherdListInnerSection.RadErgoCfgSignalIndepBtnListKey_A21276);
    this.Field.Add("RadErgoCfgCnvBtnListType_A21164", (IAcpField) this.ConventionalShepherdListInner.ConventionalShepherdListInnerSection.RadErgoCfgCnvBtnListType_A21164);
    this.Field.Add("RadErgoCfgCnvBtnListID_A21376", (IAcpField) this.ConventionalShepherdListInner.ConventionalShepherdListInnerSection.RadErgoCfgCnvBtnListID_A21376);
    this.Field.Add("RadErgoCfgCnvBtnListKey_A21175", (IAcpField) this.ConventionalShepherdListInner.ConventionalShepherdListInnerSection.RadErgoCfgCnvBtnListKey_A21175);
    this.Field.Add("RadErgoCfgTrkBtnListType_A21167", (IAcpField) this.TrunkingShepherdListInner.TrunkingShepherdListInnerSection.RadErgoCfgTrkBtnListType_A21167);
    this.Field.Add("RadErgoCfgTrkBtnListID_A21166", (IAcpField) this.TrunkingShepherdListInner.TrunkingShepherdListInnerSection.RadErgoCfgTrkBtnListID_A21166);
    this.Field.Add("RadErgoCfgTrkBtnListKey_A21174", (IAcpField) this.TrunkingShepherdListInner.TrunkingShepherdListInnerSection.RadErgoCfgTrkBtnListKey_A21174);
    this.Field.Add("RadErgoCfgSignalIndependentProductIndependentNonProgrammableButtonBCO_A19777", (IAcpField) this.SignalIndependentProductIndependentNonProgrammableButtonListInner.SignalIndependentProductIndependentNonProgrammableButtonListInnerSection.RadErgoCfgSignalIndependentProductIndependentNonProgrammableButtonBCO_A19777);
    this.Field.Add("RadErgoCfgSignalIndependentProductIndependentNonProgrammableButtonFeature_A19778", (IAcpField) this.SignalIndependentProductIndependentNonProgrammableButtonListInner.SignalIndependentProductIndependentNonProgrammableButtonListInnerSection.RadErgoCfgSignalIndependentProductIndependentNonProgrammableButtonFeature_A19778);
    this.Field.Add("RadErgoCfgSignalIndependentProductIndependentNonProgrammableButtonKey_A21195", (IAcpField) this.SignalIndependentProductIndependentNonProgrammableButtonListInner.SignalIndependentProductIndependentNonProgrammableButtonListInnerSection.RadErgoCfgSignalIndependentProductIndependentNonProgrammableButtonKey_A21195);
    this.Field.Add("RadErgoCfgSignalIndependentProductIndependentProgrammableButtonBCO_A19757", (IAcpField) this.SignalIndependentProductIndependentProgrammableButtonListInner.SignalIndependentProductIndependentProgrammableButtonListInnerSection.RadErgoCfgSignalIndependentProductIndependentProgrammableButtonBCO_A19757);
    this.Field.Add("RadErgoCfgSignalIndependentProductIndependentProgrammableButtonFeature_A19758", (IAcpField) this.SignalIndependentProductIndependentProgrammableButtonListInner.SignalIndependentProductIndependentProgrammableButtonListInnerSection.RadErgoCfgSignalIndependentProductIndependentProgrammableButtonFeature_A19758);
    this.Field.Add("RadErgoCfgSignalIndependentProductIndependentProgrammableButtonKey_A21194", (IAcpField) this.SignalIndependentProductIndependentProgrammableButtonListInner.SignalIndependentProductIndependentProgrammableButtonListInnerSection.RadErgoCfgSignalIndependentProductIndependentProgrammableButtonKey_A21194);
    this.Field.Add("RadErgoCfgSignalIndependentProductIndependentProgrammableButtonShortPressTime", (IAcpField) this.SignalIndependentProductIndependentProgrammableButtonListInner.SignalIndependentProductIndependentProgrammableButtonListInnerSection.RadErgoCfgSignalIndependentProductIndependentProgrammableButtonShortPressTime);
    this.Field.Add("RadErgoCfgSignalIndependentProductIndependentProgrammableButtonLongPressTime", (IAcpField) this.SignalIndependentProductIndependentProgrammableButtonListInner.SignalIndependentProductIndependentProgrammableButtonListInnerSection.RadErgoCfgSignalIndependentProductIndependentProgrammableButtonLongPressTime);
    this.Field.Add("RadErgoCfgSignalIndependentProductIndependentNonProgrammableButtonShortPressTime", (IAcpField) this.SignalIndependentProductIndependentNonProgrammableButtonListInner.SignalIndependentProductIndependentNonProgrammableButtonListInnerSection.RadErgoCfgSignalIndependentProductIndependentNonProgrammableButtonShortPressTime);
    this.Field.Add("RadErgoCfgSignalIndependentProductIndependentNonProgrammableButtonLongPressTime", (IAcpField) this.SignalIndependentProductIndependentNonProgrammableButtonListInner.SignalIndependentProductIndependentNonProgrammableButtonListInnerSection.RadErgoCfgSignalIndependentProductIndependentNonProgrammableButtonLongPressTime);
  }

  private void AddSiteSelectableAlertList()
  {
    this.Field.Add("SSAFrontDisplayAlertAlias_A41987", (IAcpField) this.SiteSelectableAlertTableInner.SiteSelectableAlertTableInnerSection.SSAFrontDisplayAlertAlias_A41987);
    this.Field.Add("SiteSelectableAlertListAlias_A41993", (IAcpField) this.SiteSelectableAlertList.SiteSelectableAlertList41985.SiteSelectableAlertListAlias_A41993);
    this.Field.Add("SiteSelectableAlertListConfigurationType_A42058", (IAcpField) this.SiteSelectableAlertList.SiteSelectableAlertList41985.SiteSelectableAlertListConfigurationType_A42058);
  }

  private void AddVirtualPartnerAlertListInnerSection()
  {
    this.Field.Add("vPAlertListAlertAction_A43684", (IAcpField) this.AlertListInner.AlertListInnerSection.VPAlertListAlertAction_A43684);
  }

  private void AddSmartKeyFobButtons()
  {
    this.Field.Add("RadErgoCfgFobButtonName_A41573", (IAcpField) this.SmartKeyFobButtonTableInner.SmartKeyFobButtonTableInnerSection.RadErgoCfgFobButtonName_A41573);
    this.Field.Add("RadErgoCfgFobConventionalBCO_A41577", (IAcpField) this.SmartKeyFobButtonTableInner.SmartKeyFobButtonTableInnerSection.RadErgoCfgFobConventionalBCO_A41577);
    this.Field.Add("RadErgoCfgFobConventionalFeature_A41574", (IAcpField) this.SmartKeyFobButtonTableInner.SmartKeyFobButtonTableInnerSection.RadErgoCfgFobConventionalFeature_A41574);
    this.Field.Add("RadErgoCfgFobTrunkingBCO_A41578", (IAcpField) this.SmartKeyFobButtonTableInner.SmartKeyFobButtonTableInnerSection.RadErgoCfgFobTrunkingBCO_A41578);
    this.Field.Add("RadErgoCfgFobTrunkingFeature_A41575", (IAcpField) this.SmartKeyFobButtonTableInner.SmartKeyFobButtonTableInnerSection.RadErgoCfgFobTrunkingFeature_A41575);
    this.Field.Add("RadErgoCfgSmartKeyFobButtonKey_A41579", (IAcpField) this.SmartKeyFobButtonTableInner.SmartKeyFobButtonTableInnerSection.RadErgoCfgSmartKeyFobButtonKey_A41579);
    this.Field.Add("RadErgoCfgSmartKeyFobShortPressTime", (IAcpField) this.SmartKeyFobButtonTableInner.SmartKeyFobButtonTableInnerSection.RadErgoCfgSmartKeyFobShortPressTime);
    this.Field.Add("RadErgoCfgSmartKeyFobLongPressTime", (IAcpField) this.SmartKeyFobButtonTableInner.SmartKeyFobButtonTableInnerSection.RadErgoCfgSmartKeyFobLongPressTime);
  }

  private void AddSwitches()
  {
    this.Field.Add("SwitchRotaryControlButtonName_A22903", (IAcpField) this.RotaryControlInner.RotaryControlInnerSection.SwitchRotaryControlButtonName_A22903);
    this.Field.Add("SwitchRotaryControlButtonBCO_A22906", (IAcpField) this.RotaryControlInner.RotaryControlInnerSection.SwitchRotaryControlButtonBCO_A22906);
    this.Field.Add("SwitchGeneralRotaryControl_A8984", (IAcpField) this.RotaryControlInner.RotaryControlInnerSection.SwitchGeneralRotaryControl_A8984);
    this.Field.Add("SwitchRotaryControlButtonKey_A22905", (IAcpField) this.RotaryControlInner.RotaryControlInnerSection.SwitchRotaryControlButtonKey_A22905);
    this.Field.Add("SwitchRotaryControlShortPressTime", (IAcpField) this.RotaryControlInner.RotaryControlInnerSection.SwitchRotaryControlShortPressTime);
    this.Field.Add("SwitchRotaryControlLongPressTime", (IAcpField) this.RotaryControlInner.RotaryControlInnerSection.SwitchRotaryControlLongPressTime);
    this.Field.Add("SwitchConventionalSwitchesPosition1_A7734", (IAcpField) this.Switches.ConventionalSwitches.SwitchConventionalSwitchesPosition1_A7734);
    this.Field.Add("SwitchConventionalSwitchesPosition2_A7735", (IAcpField) this.Switches.ConventionalSwitches.SwitchConventionalSwitchesPosition2_A7735);
    this.Field.Add("SwitchConventionalSwitchesPosition3_A7737", (IAcpField) this.Switches.ConventionalSwitches.SwitchConventionalSwitchesPosition3_A7737);
    this.Field.Add("SwitchConventionalSwitchesPosition4_A21530", (IAcpField) this.Switches.ConventionalSwitches.SwitchConventionalSwitchesPosition4_A21530);
    this.Field.Add("SwitchConventionalSwitchesPosition5_A21531", (IAcpField) this.Switches.ConventionalSwitches.SwitchConventionalSwitchesPosition5_A21531);
    this.Field.Add("SwitchTrunkingSwitchesPosition1_A9466", (IAcpField) this.Switches.TrunkingSwitches.SwitchTrunkingSwitchesPosition1_A9466);
    this.Field.Add("SwitchTrunkingSwitchesPosition2_A9467", (IAcpField) this.Switches.TrunkingSwitches.SwitchTrunkingSwitchesPosition2_A9467);
    this.Field.Add("SwitchTrunkingSwitchesPosition3_A9468", (IAcpField) this.Switches.TrunkingSwitches.SwitchTrunkingSwitchesPosition3_A9468);
    this.Field.Add("SwitchTrunkingSwitchesPosition4_A21534", (IAcpField) this.Switches.TrunkingSwitches.SwitchTrunkingSwitchesPosition4_A21534);
    this.Field.Add("SwitchTrunkingSwitchesPosition5_A21535", (IAcpField) this.Switches.TrunkingSwitches.SwitchTrunkingSwitchesPosition5_A21535);
    this.Field.Add("SwitchConventionalSwitchTablePositionsQuantity_A19654", (IAcpField) this.ConventionalSwitchTableInner.ConventionalSwitchTableInnerSection.SwitchConventionalSwitchTablePositionsQuantity_A19654);
    this.Field.Add("SwitchConventionalSwitchTablePosition1Feature_A19655", (IAcpField) this.ConventionalSwitchTableInner.ConventionalSwitchTableInnerSection.SwitchConventionalSwitchTablePosition1Feature_A19655);
    this.Field.Add("SwitchConventionalSwitchTablePosition2Feature_A19656", (IAcpField) this.ConventionalSwitchTableInner.ConventionalSwitchTableInnerSection.SwitchConventionalSwitchTablePosition2Feature_A19656);
    this.Field.Add("SwitchConventionalSwitchTablePosition3Feature_A19657", (IAcpField) this.ConventionalSwitchTableInner.ConventionalSwitchTableInnerSection.SwitchConventionalSwitchTablePosition3Feature_A19657);
    this.Field.Add("SwitchConventionalSwitchTablePosition4Feature_A19658", (IAcpField) this.ConventionalSwitchTableInner.ConventionalSwitchTableInnerSection.SwitchConventionalSwitchTablePosition4Feature_A19658);
    this.Field.Add("SwitchConventionalSwitchTablePosition5Feature_A19717", (IAcpField) this.ConventionalSwitchTableInner.ConventionalSwitchTableInnerSection.SwitchConventionalSwitchTablePosition5Feature_A19717);
    this.Field.Add("SwitchConventionalSwitchKey_A21293", (IAcpField) this.ConventionalSwitchTableInner.ConventionalSwitchTableInnerSection.SwitchConventionalSwitchKey_A21293);
    this.Field.Add("SwitchTrunkingSwitchTablePositionsQuantity_A21003", (IAcpField) this.TrunkingSwitchTableInner.TrunkingSwitchTableInnerSection.SwitchTrunkingSwitchTablePositionsQuantity_A21003);
    this.Field.Add("SwitchTrunkingSwitchTablePosition1Feature_A21004", (IAcpField) this.TrunkingSwitchTableInner.TrunkingSwitchTableInnerSection.SwitchTrunkingSwitchTablePosition1Feature_A21004);
    this.Field.Add("SwitchTrunkingSwitchTablePosition2Feature_A21005", (IAcpField) this.TrunkingSwitchTableInner.TrunkingSwitchTableInnerSection.SwitchTrunkingSwitchTablePosition2Feature_A21005);
    this.Field.Add("SwitchTrunkingSwitchTablePosition3Feature_A21006", (IAcpField) this.TrunkingSwitchTableInner.TrunkingSwitchTableInnerSection.SwitchTrunkingSwitchTablePosition3Feature_A21006);
    this.Field.Add("SwitchTrunkingSwitchTablePosition4Feature_A21007", (IAcpField) this.TrunkingSwitchTableInner.TrunkingSwitchTableInnerSection.SwitchTrunkingSwitchTablePosition4Feature_A21007);
    this.Field.Add("SwitchTrunkingSwitchTablePosition5Feature_A21008", (IAcpField) this.TrunkingSwitchTableInner.TrunkingSwitchTableInnerSection.SwitchTrunkingSwitchTablePosition5Feature_A21008);
    this.Field.Add("SwitchTrunkingSwitchKey_A21294", (IAcpField) this.TrunkingSwitchTableInner.TrunkingSwitchTableInnerSection.SwitchTrunkingSwitchKey_A21294);
    this.Field.Add("SwitchMFKAssignmentControlName_A38529", (IAcpField) this.MFKAssignmentControlInner.MFKAssignmentControlInnerSection.SwitchMFKAssignmentControlName_A38529);
    this.Field.Add("RadErgoControlSwitchsMFKFeatureAssignment_A38514", (IAcpField) this.MFKAssignmentControlInner.MFKAssignmentControlInnerSection.RadErgoControlSwitchsMFKFeatureAssignment_A38514);
    this.Field.Add("RadErgoControlSwitchsMFKFeatureAssignment_A38514_1", (IAcpField) this.MFKAssignmentControlInner_1.MFKAssignmentControlInnerSection.RadErgoControlSwitchsMFKFeatureAssignment_A38514);
  }

  private void AddTrunkingEmergencyProfiles()
  {
    this.Field.Add("TrkEmerProfGeneralkeyofTrunkingEmergencyProfiles_A19419", (IAcpField) this.TrunkingEmergencyProfiles.General.TrkEmerProfGeneralkeyofTrunkingEmergencyProfiles_A19419);
    this.Field.Add("TrkEmerProfGeneralEmergencyOperation_A7926", (IAcpField) this.TrunkingEmergencyProfiles.General.TrkEmerProfGeneralEmergencyOperation_A7926);
    this.Field.Add("TrkEmerProfGeneralRetryCounter_A8951", (IAcpField) this.TrunkingEmergencyProfiles.General.TrkEmerProfGeneralRetryCounter_A8951);
    this.Field.Add("TrkEmerProfGeneralConsoleAckRequired_A7712", (IAcpField) this.TrunkingEmergencyProfiles.General.TrkEmerProfGeneralConsoleAckRequired_A7712);
    this.Field.Add("TrkEmerProfGeneralEmergencyTalkback_A9268", (IAcpField) this.TrunkingEmergencyProfiles.General.TrkEmerProfGeneralEmergencyTalkback_A9268);
    this.Field.Add("TrkEmerProfGeneralRevertPTTID_A12642", (IAcpField) this.TrunkingEmergencyProfiles.General.TrkEmerProfGeneralRevertPTTID_A12642);
    this.Field.Add("TrkPerManDownEnable_42039", (IAcpField) this.TrunkingEmergencyProfiles.General.TrkPerManDownEnable_42039);
    this.Field.Add("TrkEmerProEmergencyAutoTransmitMode_A22567", (IAcpField) this.TrunkingEmergencyProfiles.General.TrkEmerProEmergencyAutoTransmitMode_A22567);
    this.Field.Add("TrkEmerProfGeneralTxPeriodsec1_A7939", (IAcpField) this.TrunkingEmergencyProfiles.General.TrkEmerProfGeneralTxPeriodsec1_A7939);
    this.Field.Add("TrkEmerProfGeneralTxPeriodsec2_A9132", (IAcpField) this.TrunkingEmergencyProfiles.General.TrkEmerProfGeneralTxPeriodsec2_A9132);
    this.Field.Add("EmergencyToneTrigger_42107", (IAcpField) this.TrunkingEmergencyToneTableInner.TrunkingEmergencyToneTableInnerSection.EmergencyToneTrigger_42107);
    this.Field.Add("TrkEmerTone_42108", (IAcpField) this.TrunkingEmergencyToneTableInner.TrunkingEmergencyToneTableInnerSection.TrkEmerTone_42108);
    this.Field.Add("TrkEmerToneMinimumVolume_42109", (IAcpField) this.TrunkingEmergencyToneTableInner.TrunkingEmergencyToneTableInnerSection.TrkEmerToneMinimumVolume_42109);
    this.Field.Add("TrkEmerTonePeriodSec_42110", (IAcpField) this.TrunkingEmergencyToneTableInner.TrunkingEmergencyToneTableInnerSection.TrkEmerTonePeriodSec_42110);
    this.Field.Add("TrkEmerAudioRouting_42111", (IAcpField) this.TrunkingEmergencyToneTableInner.TrunkingEmergencyToneTableInnerSection.TrkEmerAudioRouting_42111);
    this.Field.Add("TrkEmerProfGeneralTxPeriodsec2_A43601", (IAcpField) this.TrunkingEmergencyProfiles.General.TrkEmerProfGeneralTxPeriodsec2_A43601);
    if (this.TrunkingEmergencyProfiles.EmergencyCompatibilityOptionsTrunking == null)
      return;
    this.Field.Add("EmergencyExitControl_43341", (IAcpField) this.TrunkingEmergencyProfiles.EmergencyCompatibilityOptionsTrunking.EmergencyExitControl_43341);
    this.Field.Add("EmergencyHotMicRestart_43342", (IAcpField) this.TrunkingEmergencyProfiles.EmergencyCompatibilityOptionsTrunking.EmergencyHotMicRestart_43342);
  }

  private void AddTrunkingPersonality()
  {
    this.Field.Add("TrkPerGeneralTrunkingPersonalityName_A12659", (IAcpField) this.TrunkingPersonality.General.TrkPerGeneralTrunkingPersonalityName_A12659);
    this.Field.Add("TrkPerGeneralSystem_A9237", (IAcpField) this.TrunkingPersonality.General.TrkPerGeneralSystem_A9237);
    this.Field.Add("TrkPerGeneralProtocolType_A8767", (IAcpField) this.TrunkingPersonality.General.TrkPerGeneralProtocolType_A8767);
    this.Field.Add("TrkPerGeneralUnitID_A9593", (IAcpField) this.TrunkingPersonality.General.TrkPerGeneralUnitID_A9593);
    this.Field.Add("TrkPerGeneralSystemID_A9238", (IAcpField) this.TrunkingPersonality.General.TrkPerGeneralSystemID_A9238);
    this.Field.Add("TrkPerGeneralTimeOutTimersec_A9379", (IAcpField) this.TrunkingPersonality.General.TrkPerGeneralTimeOutTimersec_A9379);
    this.Field.Add("TrkPerGeneralAdvancedRFAGC_A7409", (IAcpField) this.TrunkingPersonality.General.TrkPerGeneralAdvancedRFAGC_A7409);
    this.Field.Add("TrkPerGeneralConversationType_A7781", (IAcpField) this.TrunkingPersonality.General.TrkPerGeneralConversationType_A7781);
    this.Field.Add("TrkPerGeneralFailsoftType_A8599", (IAcpField) this.TrunkingPersonality.General.TrkPerGeneralFailsoftType_A8599);
    this.Field.Add("TrkPerGeneralBroadbandProtection", (IAcpField) this.TrunkingPersonality.General.TrkPerGeneralBroadbandProtection);
    this.Field.Add("TrkPerGeneralRxFrequencyMHz_A8910", (IAcpField) this.TrunkingPersonality.General.TrkPerGeneralRxFrequencyMHz_A8910);
    this.Field.Add("TrkPerGeneralTxFrequencyMHz_A9413", (IAcpField) this.TrunkingPersonality.General.TrkPerGeneralTxFrequencyMHz_A9413);
    this.Field.Add("TrkPerGeneralSecondaryFailsoft_A19991", (IAcpField) this.TrunkingPersonality.General.TrkPerGeneralSecondaryFailsoft_A19991);
    this.Field.Add("TrkPerGeneralSecondaryRxFrequencyMHz_A8904", (IAcpField) this.TrunkingPersonality.General.TrkPerGeneralSecondaryRxFrequencyMHz_A8904);
    this.Field.Add("TrkPerGeneralSecondaryTxFrequencyMHz_A12902", (IAcpField) this.TrunkingPersonality.General.TrkPerGeneralSecondaryTxFrequencyMHz_A12902);
    this.Field.Add("TrkPerGeneralDisableTransmitMode_A41742", (IAcpField) this.TrunkingPersonality.General.TrkPerGeneralDisableTransmitMode_A41742);
    this.Field.Add("TrkPerLabtoolTrunkingEmergencyProfileCompositeItemID_A19980", (IAcpField) this.TrunkingPersonality.General.TrkPerLabtoolTrunkingEmergencyProfileCompositeItemID_A19980);
    this.Field.Add("TrkPerGeneralEmergencyRevertType_A41914", (IAcpField) this.TrunkingPersonality.General.TrkPerGeneralEmergencyRevertType_A41914);
    this.Field.Add("TrkEmerProfGeneralTalkgroup_A8969", (IAcpField) this.TrunkingPersonality.General.TrkEmerProfGeneralTalkgroup_A8969);
    this.Field.Add("TrkEmerProfGeneralVoiceSignalType_A7500", (IAcpField) this.TrunkingPersonality.General.TrkEmerProfGeneralVoiceSignalType_A7500);
    this.Field.Add("TrkEmerProfGeneralSecureClearStrapping_A9092", (IAcpField) this.TrunkingPersonality.General.TrkEmerProfGeneralSecureClearStrapping_A9092);
    this.Field.Add("TrkEmerProfGeneralKeySelect_A8970", (IAcpField) this.TrunkingPersonality.General.TrkEmerProfGeneralKeySelect_A8970);
    this.Field.Add("TrkPerFeaturesDVRSProf_A41796", (IAcpField) this.TrunkingPersonality.General.TrkPerFeaturesDVRSProf_A41796);
    this.Field.Add("TrkPerGeneralRevertZone_A41916", (IAcpField) this.TrunkingPersonality.General.TrkPerGeneralRevertZone_A41916);
    this.Field.Add("TrkPerGeneralRevertChannel_A41917", (IAcpField) this.TrunkingPersonality.General.TrkPerGeneralRevertChannel_A41917);
    this.Field.Add("TrkPerAnnouncementGroupAnnouncementGroup_A7444", (IAcpField) this.TrunkingPersonality.AnnouncementGroup.TrkPerAnnouncementGroupAnnouncementGroup_A7444);
    this.Field.Add("TrkPerAnnouncementGroupAGVoiceSignalType_A7478", (IAcpField) this.TrunkingPersonality.AnnouncementGroup.TrkPerAnnouncementGroupAGVoiceSignalType_A7478);
    this.Field.Add("TrkPerAnnouncementGroupAGSecureClearStrapping_A9089", (IAcpField) this.TrunkingPersonality.AnnouncementGroup.TrkPerAnnouncementGroupAGSecureClearStrapping_A9089);
    this.Field.Add("TrkPerAnnouncementGroupAGKeySelect_A7414", (IAcpField) this.TrunkingPersonality.AnnouncementGroup.TrkPerAnnouncementGroupAGKeySelect_A7414);
    this.Field.Add("TrkPerAnnouncementGroupAnnouncementGroupFailsoft_A8597", (IAcpField) this.TrunkingPersonality.AnnouncementGroup.TrkPerAnnouncementGroupAnnouncementGroupFailsoft_A8597);
    this.Field.Add("TrkPerAnnouncementGroupAGFailsoftRxFrequencyMHz_A9582", (IAcpField) this.TrunkingPersonality.AnnouncementGroup.TrkPerAnnouncementGroupAGFailsoftRxFrequencyMHz_A9582);
    this.Field.Add("TrkPerAnnouncementGroupAGFailsoftTxFrequencyMHz_A9583", (IAcpField) this.TrunkingPersonality.AnnouncementGroup.TrkPerAnnouncementGroupAGFailsoftTxFrequencyMHz_A9583);
    this.Field.Add("TrkPerAnnouncementGroupAGSecondaryFailsoft_A19990", (IAcpField) this.TrunkingPersonality.AnnouncementGroup.TrkPerAnnouncementGroupAGSecondaryFailsoft_A19990);
    this.Field.Add("TrkPerAnnouncementGroupAGSecondaryFSRxFrequencyMHz_A8895", (IAcpField) this.TrunkingPersonality.AnnouncementGroup.TrkPerAnnouncementGroupAGSecondaryFSRxFrequencyMHz_A8895);
    this.Field.Add("TrkPerAnnouncementGroupAGSecondaryFSTxFrequencyMHz_A12903", (IAcpField) this.TrunkingPersonality.AnnouncementGroup.TrkPerAnnouncementGroupAGSecondaryFSTxFrequencyMHz_A12903);
    this.Field.Add("TrkPerAnnouncementGroupAGSystemID_A19705", (IAcpField) this.TrunkingPersonality.AnnouncementGroup.TrkPerAnnouncementGroupAGSystemID_A19705);
    this.Field.Add("TrkPerAnnouncementGroupAGWACNID_A19706", (IAcpField) this.TrunkingPersonality.AnnouncementGroup.TrkPerAnnouncementGroupAGWACNID_A19706);
    this.Field.Add("TrkSysGeneralKeyofTrunkingTalkgroup_A20742", (IAcpField) this.TalkgroupInner.TalkgroupInnerSection.TrkSysGeneralKeyofTrunkingTalkgroup_A20742);
    this.Field.Add("TrkPerTalkgroupTalkgroup_A9274", (IAcpField) this.TalkgroupInner.TalkgroupInnerSection.TrkPerTalkgroupTalkgroup_A9274);
    this.Field.Add("TrkPerTalkgroupTxVoiceSignalType_A9575", (IAcpField) this.TalkgroupInner.TalkgroupInnerSection.TrkPerTalkgroupTxVoiceSignalType_A9575);
    this.Field.Add("TrkPerTalkgroupSecureClearStrapping_A9095", (IAcpField) this.TalkgroupInner.TalkgroupInnerSection.TrkPerTalkgroupSecureClearStrapping_A9095);
    this.Field.Add("TrkPerTalkgroupKeySelect_A8365", (IAcpField) this.TalkgroupInner.TalkgroupInnerSection.TrkPerTalkgroupKeySelect_A8365);
    this.Field.Add("TrkPerTalkgroupTalkgroupFailsoft_A8005", (IAcpField) this.TalkgroupInner.TalkgroupInnerSection.TrkPerTalkgroupTalkgroupFailsoft_A8005);
    this.Field.Add("TrkPerTalkgroupFailsoftRxFrequencyMHz_A8001", (IAcpField) this.TalkgroupInner.TalkgroupInnerSection.TrkPerTalkgroupFailsoftRxFrequencyMHz_A8001);
    this.Field.Add("TrkPerTalkgroupFailsoftTxFrequencyMHz_A8003", (IAcpField) this.TalkgroupInner.TalkgroupInnerSection.TrkPerTalkgroupFailsoftTxFrequencyMHz_A8003);
    this.Field.Add("TrkPerTalkgroupTGSecondaryFailsoft_A19989", (IAcpField) this.TalkgroupInner.TalkgroupInnerSection.TrkPerTalkgroupTGSecondaryFailsoft_A19989);
    this.Field.Add("TrkPerTalkgroupSecondaryFailsoftRxFrequencyMHz_A8900", (IAcpField) this.TalkgroupInner.TalkgroupInnerSection.TrkPerTalkgroupSecondaryFailsoftRxFrequencyMHz_A8900);
    this.Field.Add("TrkPerTalkgroupSecondaryFailsoftTxFrequencyMHz_A8902", (IAcpField) this.TalkgroupInner.TalkgroupInnerSection.TrkPerTalkgroupSecondaryFailsoftTxFrequencyMHz_A8902);
    this.Field.Add("TrkPerTalkgroupTGSystemID_A19715", (IAcpField) this.TalkgroupInner.TalkgroupInnerSection.TrkPerTalkgroupTGSystemID_A19715);
    this.Field.Add("TrkPerTalkgroupTGWACNID_A19716", (IAcpField) this.TalkgroupInner.TalkgroupInnerSection.TrkPerTalkgroupTGWACNID_A19716);
    this.Field.Add("TrkPerCallPagePrivateCallType_A8760", (IAcpField) this.TrunkingPersonality.CallPage.TrkPerCallPagePrivateCallType_A8760);
    this.Field.Add("TrkPerCallPagePrivateCallOperation_A8759", (IAcpField) this.TrunkingPersonality.CallPage.TrkPerCallPagePrivateCallOperation_A8759);
    this.Field.Add("TrkPerCallPageCallAlertPageOperation_A7597", (IAcpField) this.TrunkingPersonality.CallPage.TrkPerCallPageCallAlertPageOperation_A7597);
    this.Field.Add("TrkPerCallPageHotListItemID_A19982", (IAcpField) this.TrunkingPersonality.CallPage.TrkPerCallPageHotListItemID_A19982);
    this.Field.Add("TrkPerCallPageInCallUserAlertEnable_A9434", (IAcpField) this.TrunkingPersonality.CallPage.TrkPerCallPageInCallUserAlertEnable_A9434);
    this.Field.Add("TrkPerCallPageAutomaticCallAlert_A9754", (IAcpField) this.TrunkingPersonality.CallPage.TrkPerCallPageAutomaticCallAlert_A9754);
    this.Field.Add("TrkPerFeaturesAstroAlertingToneTable", (IAcpField) this.TrunkingPersonality.CallPage.TrkPerFeaturesAstroAlertingToneTable);
    this.Field.Add("TrkPerFeaturesPhoneOperation_A8701", (IAcpField) this.TrunkingPersonality.Features.TrkPerFeaturesPhoneOperation_A8701);
    this.Field.Add("TrkPerFeaturesScanListSelection_A9053", (IAcpField) this.TrunkingPersonality.Features.TrkPerFeaturesScanListSelection_A9053);
    this.Field.Add("TrkPerFeaturesAutomaticScan_A7528", (IAcpField) this.TrunkingPersonality.Features.TrkPerFeaturesAutomaticScan_A7528);
    this.Field.Add("TrkPerFeaturesStatusEnable_A9188", (IAcpField) this.TrunkingPersonality.Features.TrkPerFeaturesStatusEnable_A9188);
    this.Field.Add("TrkPerFeaturesMessageEnable_A8499", (IAcpField) this.TrunkingPersonality.Features.TrkPerFeaturesMessageEnable_A8499);
    this.Field.Add("TrkPerFeaturesTalkPermitTone_A9271", (IAcpField) this.TrunkingPersonality.Features.TrkPerFeaturesTalkPermitTone_A9271);
    this.Field.Add("TrkPerFeaturesSecureProperCodeDetect_A8763", (IAcpField) this.TrunkingPersonality.Features.TrkPerFeaturesSecureProperCodeDetect_A8763);
    this.Field.Add("TrkPerIgnoreRxClearVoice_A41610", (IAcpField) this.TrunkingPersonality.Features.TrkPerIgnoreRxClearVoice_A41610);
    this.Field.Add("TrkPerFeaturesHotKeypadDTMF_A8209", (IAcpField) this.TrunkingPersonality.Features.TrkPerFeaturesHotKeypadDTMF_A8209);
    this.Field.Add("TrkPerFeaturesTacticalPublicSafetyUIEnable", (IAcpField) this.TrunkingPersonality.Features.TrkPerFeaturesTacticalPublicSafetyUIEnable);
    this.Field.Add("TrkPerPreferredSitesIgnoreSiteResourcePreference_A8239", (IAcpField) this.TrunkingPersonality.PreferredSites.TrkPerPreferredSitesIgnoreSiteResourcePreference_A8239);
    this.Field.Add("TrkPerPreferredSitesSiteID_A9151", (IAcpField) this.PreferredSitesInner.PreferredSitesInnerSection.TrkPerPreferredSitesSiteID_A9151);
    this.Field.Add("TrkPerPreferredSitesPreferredStatus_A8734", (IAcpField) this.PreferredSitesInner.PreferredSitesInnerSection.TrkPerPreferredSitesPreferredStatus_A8734);
    this.Field.Add("TrkPerPreferredSitesSystemIDRFSSID_A9240", (IAcpField) this.PreferredSitesInner.PreferredSitesInnerSection.TrkPerPreferredSitesSystemIDRFSSID_A9240);
    this.Field.Add("TrkPerPreferredSitesSystemID_A19466", (IAcpField) this.PreferredSitesInner.PreferredSitesInnerSection.TrkPerPreferredSitesSystemID_A19466);
    this.Field.Add("TrkPerPreferredSitesRASWACNID_A20445", (IAcpField) this.PreferredSitesInner.PreferredSitesInnerSection.TrkPerPreferredSitesRASWACNID_A20445);
    this.Field.Add("TrkPerLabtoolSystemKey_A9242", (IAcpField) this.TrunkingPersonality.Labtool.TrkPerLabtoolSystemKey_A9242);
    this.Field.Add("TrkPerLabtoolTrunkingPersonalityPreferredSiteStatusListItemID_A19962", (IAcpField) this.TrunkingPersonality.Labtool.TrkPerLabtoolTrunkingPersonalityPreferredSiteStatusListItemID_A19962);
    this.Field.Add("TrkPerLabtoolTrunkingPersonalityTalkGroupAliasListItemID_A19960", (IAcpField) this.TrunkingPersonality.Labtool.TrkPerLabtoolTrunkingPersonalityTalkGroupAliasListItemID_A19960);
    this.Field.Add("TrkPerLabtoolTrunkingPersonalityAGTGFSListItemID_A21508", (IAcpField) this.TrunkingPersonality.Labtool.TrkPerLabtoolTrunkingPersonalityAGTGFSListItemID_A21508);
    this.Field.Add("TrkPerFeatureBackupPTTOperation_A43628", (IAcpField) this.TrunkingPersonality.Features.TrkPerFeatureBackupPTTOperation_A43628);
  }

  private void AddTrunkingSystem()
  {
    this.Field.Add("TrkSysGeneralKeyofTrunkingSystem_A12658", (IAcpField) this.TrunkingSystem.General.TrkSysGeneralKeyofTrunkingSystem_A12658);
    this.Field.Add("TrkSysGeneralSystemKeyType_A38853", (IAcpField) this.TrunkingSystem.General.TrkSysGeneralSystemKeyType_A38853);
    this.Field.Add("TrkSysGeneralSystemKeyPresent_A9241", (IAcpField) this.TrunkingSystem.General.TrkSysGeneralSystemKeyPresent_A9241);
    this.Field.Add("TrkSysGeneralSystemType_A9252", (IAcpField) this.TrunkingSystem.General.TrkSysGeneralSystemType_A9252);
    this.Field.Add("TrkSysGeneralCoverageType_A7782", (IAcpField) this.TrunkingSystem.General.TrkSysGeneralCoverageType_A7782);
    this.Field.Add("TrkSysGeneralHomeWACNID_A8205", (IAcpField) this.TrunkingSystem.General.TrkSysGeneralHomeWACNID_A8205);
    this.Field.Add("TrkSysGeneralSystemID_A9239", (IAcpField) this.TrunkingSystem.General.TrkSysGeneralSystemID_A9239);
    this.Field.Add("TrkSysGeneralRFSSID_A8980", (IAcpField) this.TrunkingSystem.General.TrkSysGeneralRFSSID_A8980);
    this.Field.Add("TrkSysGeneralSiteID_A9150", (IAcpField) this.TrunkingSystem.General.TrkSysGeneralSiteID_A9150);
    this.Field.Add("TrkSysGeneralUnitID_A12651", (IAcpField) this.TrunkingSystem.General.TrkSysGeneralUnitID_A12651);
    this.Field.Add("TrkSysGeneralTypeIIFrequencyBand_A12491", (IAcpField) this.TrunkingSystem.General.TrkSysGeneralTypeIIFrequencyBand_A12491);
    this.Field.Add("TrkSysGeneralConnectToneHz_A7710", (IAcpField) this.TrunkingSystem.General.TrkSysGeneralConnectToneHz_A7710);
    this.Field.Add("TrkSysGeneralFailsoftConnectToneHz_A8007", (IAcpField) this.TrunkingSystem.General.TrkSysGeneralFailsoftConnectToneHz_A8007);
    this.Field.Add("TrkSysLabtoolNetworkID_A8565", (IAcpField) this.TrunkingSystem.General.TrkSysLabtoolNetworkID_A8565);
    this.Field.Add("TrkSysGeneralRFSSResponseTimems_A8981", (IAcpField) this.TrunkingSystem.General.TrkSysGeneralRFSSResponseTimems_A8981);
    this.Field.Add("TrkSysGeneralRFSSDebounceTimersec_A8979", (IAcpField) this.TrunkingSystem.General.TrkSysGeneralRFSSDebounceTimersec_A8979);
    this.Field.Add("TrkSysGeneralNonAdjacentSiteSearch_A8568", (IAcpField) this.TrunkingSystem.General.TrkSysGeneralNonAdjacentSiteSearch_A8568);
    this.Field.Add("TrkSysGeneralDataProfileSelection_A19449", (IAcpField) this.TrunkingSystem.General.TrkSysGeneralDataProfileSelection_A19449);
    this.Field.Add("TrkSysOBTChannelRange_A24072", (IAcpField) this.ChannelRangesMHzInner.ChannelRangesMHzInnerSection.TrkSysOBTChannelRange_A24072);
    this.Field.Add("TrkSysOBTChannelAssignmentListRxEnable_A9001", (IAcpField) this.ChannelRangesMHzInner.ChannelRangesMHzInnerSection.TrkSysOBTChannelAssignmentListRxEnable_A9001);
    this.Field.Add("TrkSysOBTChannelAssignmentListRxSpacingKHz_A9004", (IAcpField) this.ChannelRangesMHzInner.ChannelRangesMHzInnerSection.TrkSysOBTChannelAssignmentListRxSpacingKHz_A9004);
    this.Field.Add("TrkSysOBTChannelAssignmentListRxStartFrequencyMHz_A9029", (IAcpField) this.ChannelRangesMHzInner.ChannelRangesMHzInnerSection.TrkSysOBTChannelAssignmentListRxStartFrequencyMHz_A9029);
    this.Field.Add("TrkSysOBTChannelAssignmentListRxEndFrequencyMHz_A9012", (IAcpField) this.ChannelRangesMHzInner.ChannelRangesMHzInnerSection.TrkSysOBTChannelAssignmentListRxEndFrequencyMHz_A9012);
    this.Field.Add("TrkSysOBTChannelAssignmentListTxEnable_A9517", (IAcpField) this.ChannelRangesMHzInner.ChannelRangesMHzInnerSection.TrkSysOBTChannelAssignmentListTxEnable_A9517);
    this.Field.Add("TrkSysOBTChannelAssignmentListTxSpacingKHz_A9520", (IAcpField) this.ChannelRangesMHzInner.ChannelRangesMHzInnerSection.TrkSysOBTChannelAssignmentListTxSpacingKHz_A9520);
    this.Field.Add("TrkSysOBTChannelAssignmentListTxStartFrequencyMHz_A9568", (IAcpField) this.ChannelRangesMHzInner.ChannelRangesMHzInnerSection.TrkSysOBTChannelAssignmentListTxStartFrequencyMHz_A9568);
    this.Field.Add("TrkSysOBTChannelAssignmentListTxEndFrequencyMHz_A9529", (IAcpField) this.ChannelRangesMHzInner.ChannelRangesMHzInnerSection.TrkSysOBTChannelAssignmentListTxEndFrequencyMHz_A9529);
    this.Field.Add("TrkSysOBTChannelAssignmentListRxStartChannelNumber_A20478", (IAcpField) this.ChannelRangesMHzInner.ChannelRangesMHzInnerSection.TrkSysOBTChannelAssignmentListRxStartChannelNumber_A20478);
    this.Field.Add("TrkSysOBTChannelAssignmentListTxStartChannelNumber_A20479", (IAcpField) this.ChannelRangesMHzInner.ChannelRangesMHzInnerSection.TrkSysOBTChannelAssignmentListTxStartChannelNumber_A20479);
    this.Field.Add("TrkSysControlChannelsRxFrequencyMHz_A9018", (IAcpField) this.ControlChannelsInner.ControlChannelsInnerSection.TrkSysControlChannelsRxFrequencyMHz_A9018);
    this.Field.Add("TrkSysControlChannelsTxFrequencyMHz_A9535", (IAcpField) this.ControlChannelsInner.ControlChannelsInnerSection.TrkSysControlChannelsTxFrequencyMHz_A9535);
    this.Field.Add("TrkSysAstro25ChannelID_A24066", (IAcpField) this.ASTRO25ChannelIDInner.ASTRO25ChannelIDInnerSection.TrkSysAstro25ChannelID_A24066);
    this.Field.Add("TrkSysASTRO25ChannelIDIdentifierEnable_A8222", (IAcpField) this.ASTRO25ChannelIDInner.ASTRO25ChannelIDInnerSection.TrkSysASTRO25ChannelIDIdentifierEnable_A8222);
    this.Field.Add("TrkSysASTRO25ChannelIDChannelType_A1390", (IAcpField) this.ASTRO25ChannelIDInner.ASTRO25ChannelIDInnerSection.TrkSysASTRO25ChannelIDChannelType_A1390);
    this.Field.Add("TrkSysASTRO25ChannelIDTransmitOffsetSign_A9417", (IAcpField) this.ASTRO25ChannelIDInner.ASTRO25ChannelIDInnerSection.TrkSysASTRO25ChannelIDTransmitOffsetSign_A9417);
    this.Field.Add("TrkSysASTRO25ChannelIDTransmitOffsetMHz_A9416", (IAcpField) this.ASTRO25ChannelIDInner.ASTRO25ChannelIDInnerSection.TrkSysASTRO25ChannelIDTransmitOffsetMHz_A9416);
    this.Field.Add("TrkSysASTRO25ChannelIDChannelSpacingkHz_A7660", (IAcpField) this.ASTRO25ChannelIDInner.ASTRO25ChannelIDInnerSection.TrkSysASTRO25ChannelIDChannelSpacingkHz_A7660);
    this.Field.Add("TrkSysASTRO25ChannelIDBaseFrequencyMHz_A7546", (IAcpField) this.ASTRO25ChannelIDInner.ASTRO25ChannelIDInnerSection.TrkSysASTRO25ChannelIDBaseFrequencyMHz_A7546);
    this.Field.Add("TrkSysFeaturesDTMFTimingTable_A7900", (IAcpField) this.TrunkingSystem.Features.TrkSysFeaturesDTMFTimingTable_A7900);
    this.Field.Add("TrkSysFeaturesRadioInhibit_A8833", (IAcpField) this.TrunkingSystem.Features.TrkSysFeaturesRadioInhibit_A8833);
    this.Field.Add("TrkSysLabtoolEnable_A8669", (IAcpField) this.TrunkingSystem.Features.TrkSysLabtoolEnable_A8669);
    this.Field.Add("TrkSysFeaturesTextMessagingService_A9373", (IAcpField) this.TrunkingSystem.Features.TrkSysFeaturesTextMessagingService_A9373);
    this.Field.Add("TrkSysFeaturesTxPowerLevel_A9557", (IAcpField) this.TrunkingSystem.Features.TrkSysFeaturesTxPowerLevel_A9557);
    this.Field.Add("TrkSysFeaturesHearClear_A36422", (IAcpField) this.TrunkingSystem.Features.TrkSysFeaturesHearClear_A36422);
    this.Field.Add("TrkSysFeaturesEnable_A7968", (IAcpField) this.TrunkingSystem.Features.TrkSysFeaturesEnable_A7968);
    this.Field.Add("TrkSysFeaturesTxBaseTimeSec_A9512", (IAcpField) this.TrunkingSystem.Features.TrkSysFeaturesTxBaseTimeSec_A9512);
    this.Field.Add("TrkSysFeaturesEmergencyAlarmRxIndicator_A7932", (IAcpField) this.TrunkingSystem.Features.TrkSysFeaturesEmergencyAlarmRxIndicator_A7932);
    this.Field.Add("TrkSysFeaturesSecureLED_A9071", (IAcpField) this.TrunkingSystem.Features.TrkSysFeaturesSecureLED_A9071);
    this.Field.Add("TrkSysFeaturesBusyLED_44911", (IAcpField) this.TrunkingSystem.Features.TrkSysFeaturesBusyLED_44911);
    this.Field.Add("TrkSysFeaturesICUAReset_A8249", (IAcpField) this.TrunkingSystem.Features.TrkSysFeaturesICUAReset_A8249);
    this.Field.Add("TrkSysFeaturesICUAAutoResetTimesec_A7515", (IAcpField) this.TrunkingSystem.Features.TrkSysFeaturesICUAAutoResetTimesec_A7515);
    this.Field.Add("SiteSelectableAlertList_A42060", (IAcpField) this.TrunkingSystem.Features.SiteSelectableAlertList_A42060);
    this.Field.Add("SiteSelectableAlertAliasList_A42100", (IAcpField) this.TrunkingSystem.Features.SiteSelectableAlertAliasList_A42100);
    this.Field.Add("TrkSysFeaturesDynamicRegroupingEnable_A7969", (IAcpField) this.TrunkingSystem.Features.TrkSysFeaturesDynamicRegroupingEnable_A7969);
    this.Field.Add("TrkSysFeaturesZone_A9717", (IAcpField) this.TrunkingSystem.Features.TrkSysFeaturesZone_A9717);
    this.Field.Add("TrkSysFeaturesChannel_A7647", (IAcpField) this.TrunkingSystem.Features.TrkSysFeaturesChannel_A7647);
    this.Field.Add("TrkSysMessageAliasMessageAliasEnable_A8505", (IAcpField) this.TrunkingSystem.MessageAlias.TrkSysMessageAliasMessageAliasEnable_A8505);
    this.Field.Add("TrkSysMsgAlias_A24069", (IAcpField) this.MessageAliasInner.MessageAliasInnerSection.TrkSysMsgAlias_A24069);
    this.Field.Add("TrkSysMessageAliasMessageAliasNumber_A8500", (IAcpField) this.MessageAliasInner.MessageAliasInnerSection.TrkSysMessageAliasMessageAliasNumber_A8500);
    this.Field.Add("TrkSysMessageAliasMessageAliasText_A8503", (IAcpField) this.MessageAliasInner.MessageAliasInnerSection.TrkSysMessageAliasMessageAliasText_A8503);
    this.Field.Add("TrkSysTypeIIChannelSetupSplinterChannel_A9175", (IAcpField) this.TrunkingSystem.TypeIIChannelSetup.TrkSysTypeIIChannelSetupSplinterChannel_A9175);
    this.Field.Add("TrkSysTypeIIChannelSetupShuffledBandPlan_A9128", (IAcpField) this.TrunkingSystem.TypeIIChannelSetup.TrkSysTypeIIChannelSetupShuffledBandPlan_A9128);
    this.Field.Add("TrkSysTypeIIChannelSetupLegacyTransitSystem_A8429", (IAcpField) this.TrunkingSystem.TypeIIChannelSetup.TrkSysTypeIIChannelSetupLegacyTransitSystem_A8429);
    this.Field.Add("TrkSysTypeIIChannelSetupChannelBandwidthkHz_A7654", (IAcpField) this.TrunkingSystem.TypeIIChannelSetup.TrkSysTypeIIChannelSetupChannelBandwidthkHz_A7654);
    this.Field.Add("TrkSysTypeIIChannelSetupNPSPACChannelBandwidthkHz_A8571", (IAcpField) this.TrunkingSystem.TypeIIChannelSetup.TrkSysTypeIIChannelSetupNPSPACChannelBandwidthkHz_A8571);
    this.Field.Add("TrkSysTypeIIChannelSetupChannelAssignmentType_A7652", (IAcpField) this.TrunkingSystem.TypeIIChannelSetup.TrkSysTypeIIChannelSetupChannelAssignmentType_A7652);
    this.Field.Add("TrkSysStatusAlias_A24070", (IAcpField) this.StatusAliasInner.StatusAliasInnerSection.TrkSysStatusAlias_A24070);
    this.Field.Add("TrkSysStatusAliasStatusAliasNumber_A9190", (IAcpField) this.StatusAliasInner.StatusAliasInnerSection.TrkSysStatusAliasStatusAliasNumber_A9190);
    this.Field.Add("TrkSysStatusAliasStatusAliasText_A9193", (IAcpField) this.StatusAliasInner.StatusAliasInnerSection.TrkSysStatusAliasStatusAliasText_A9193);
    this.Field.Add("TrkSysStatusAliasStatusAliasEnable_A9195", (IAcpField) this.TrunkingSystem.StatusAlias.TrkSysStatusAliasStatusAliasEnable_A9195);
    this.Field.Add("TrkSysSiteAlias_A24071", (IAcpField) this.SiteAliasInner.SiteAliasInnerSection.TrkSysSiteAlias_A24071);
    this.Field.Add("TrkSysSiteAliasRFSSAliasNumber_A8978", (IAcpField) this.SiteAliasInner.SiteAliasInnerSection.TrkSysSiteAliasRFSSAliasNumber_A8978);
    this.Field.Add("TrkSysSiteAliasSiteAliasNumber_A9145", (IAcpField) this.SiteAliasInner.SiteAliasInnerSection.TrkSysSiteAliasSiteAliasNumber_A9145);
    this.Field.Add("TrkSysSiteAliasSiteAliasEnable_A9148", (IAcpField) this.TrunkingSystem.SiteAlias.TrkSysSiteAliasSiteAliasEnable_A9148);
    this.Field.Add("TrkSysSiteAliasSiteAliasText_A9146", (IAcpField) this.SiteAliasInner.SiteAliasInnerSection.TrkSysSiteAliasSiteAliasText_A9146);
    this.Field.Add("TrkSysSiteAliasSiteAliasType_A41343", (IAcpField) this.SiteAliasInner.SiteAliasInnerSection.TrkSysSiteAliasSiteAliasType_A41343);
    this.Field.Add("TrkSysSiteAliasSystemNumber_A19669", (IAcpField) this.SiteAliasInner.SiteAliasInnerSection.TrkSysSiteAliasSystemNumber_A19669);
    this.Field.Add("TrkSysSiteAliasHomeRASWACNNumber_A20169", (IAcpField) this.SiteAliasInner.SiteAliasInnerSection.TrkSysSiteAliasHomeRASWACNNumber_A20169);
    this.Field.Add("TrkSysOneTouchButton_A19763", (IAcpField) this.TrkOneTouchInner.OneTouchInnerSection.TrkSysOneTouchButton_A19763);
    this.Field.Add("TrkSysOneTouchFeature_A8614", (IAcpField) this.TrkOneTouchInner.OneTouchInnerSection.TrkSysOneTouchFeature_A8614);
    this.Field.Add("TrkSysOneTouchIndex_A8618", (IAcpField) this.TrkOneTouchInner.OneTouchInnerSection.TrkSysOneTouchIndex_A8618);
    this.Field.Add("TrkSysASTRO25MotorolaProprietaryFeatures_A8547", (IAcpField) this.TrunkingSystem.ASTRO26.TrkSysASTRO25MotorolaProprietaryFeatures_A8547);
    this.Field.Add("TrkSysASTRO25ISPSequenceLengthsec_A8354", (IAcpField) this.TrunkingSystem.ASTRO26.TrkSysASTRO25ISPSequenceLengthsec_A8354);
    this.Field.Add("TrkSysASTRO25MaximumSlotSizems_A8478", (IAcpField) this.TrunkingSystem.ASTRO26.TrkSysASTRO25MaximumSlotSizems_A8478);
    this.Field.Add("TrkSysASTRO25ForceUnmuteTimems_A8141", (IAcpField) this.TrunkingSystem.ASTRO26.TrkSysASTRO25ForceUnmuteTimems_A8141);
    this.Field.Add("TrkSysASTRO25QuickFadeProtectms_A8807", (IAcpField) this.TrunkingSystem.ASTRO26.TrkSysASTRO25QuickFadeProtectms_A8807);
    this.Field.Add("TrkSysASTRO25PTTWarningTimems_A8781", (IAcpField) this.TrunkingSystem.ASTRO26.TrkSysASTRO25PTTWarningTimems_A8781);
    this.Field.Add("TrkSysASTRO25BusyUpdateTimesec_A7574", (IAcpField) this.TrunkingSystem.ASTRO26.TrkSysASTRO25BusyUpdateTimesec_A7574);
    this.Field.Add("TrkSysASTRO25ResponsePendingTimesec_A8945", (IAcpField) this.TrunkingSystem.ASTRO26.TrkSysASTRO25ResponsePendingTimesec_A8945);
    this.Field.Add("TrkSysASTRO25DefaultRCMAddress_A7813", (IAcpField) this.TrunkingSystem.ASTRO26.TrkSysASTRO25DefaultRCMAddress_A7813);
    this.Field.Add("TrkSysASTRO25F2VoiceCapable_A1395", (IAcpField) this.TrunkingSystem.ASTRO26.TrkSysASTRO25F2VoiceCapable_A1395);
    this.Field.Add("TrkSysASTRO25EndF2TDMATransmitOnOutOfRange_A1394", (IAcpField) this.TrunkingSystem.ASTRO26.TrkSysASTRO25EndF2TDMATransmitOnOutOfRange_A1394);
    this.Field.Add("TrkSysASTRO25Phase2VoiceCapable_A37972", (IAcpField) this.TrunkingSystem.ASTRO26.TrkSysASTRO25Phase2VoiceCapable_A37972);
    this.Field.Add("TrkSysASTRO25EndPhase2TDMATransmitOnOutOfRange_A37980", (IAcpField) this.TrunkingSystem.ASTRO26.TrkSysASTRO25EndPhase2TDMATransmitOnOutOfRange_A37980);
    this.Field.Add("TrkSysASTRO25ValidateNACAgainstSystemID_A20608", (IAcpField) this.TrunkingSystem.ASTRO26.TrkSysASTRO25ValidateNACAgainstSystemID_A20608);
    this.Field.Add("TrkSysASTRO25WUIDValiditySupport_A41483", (IAcpField) this.TrunkingSystem.ASTRO26.TrkSysASTRO25WUIDValiditySupport_A41483);
    this.Field.Add("TrkSysDigitalAdaptivePower_A7509", (IAcpField) this.TrunkingSystem.Digital.TrkSysDigitalAdaptivePower_A7509);
    this.Field.Add("TrkSysDigitalHighDeviationTx_A19314", (IAcpField) this.TrunkingSystem.Digital.TrkSysDigitalHighDeviationTx_A19314);
    this.Field.Add("TrkSysDigitalPreambleLength_A8722", (IAcpField) this.TrunkingSystem.Digital.TrkSysDigitalPreambleLength_A8722);
    this.Field.Add("TrkSysDigitalDigitalModulatorType_A7858", (IAcpField) this.TrunkingSystem.Digital.TrkSysDigitalDigitalModulatorType_A7858);
    this.Field.Add("TrkSysDigitalF2TDMAFrameSyncBERThreshold_A1396", (IAcpField) this.TrunkingSystem.Digital.TrkSysDigitalF2TDMAFrameSyncBERThreshold_A1396);
    this.Field.Add("TrkSysDigitalFDMAFrameSyncNIDBERThreshold_A8159", (IAcpField) this.TrunkingSystem.Digital.TrkSysDigitalFDMAFrameSyncNIDBERThreshold_A8159);
    this.Field.Add("TrkSysSecureMultikeyDESXLTxRxDefault_A7833", (IAcpField) this.TrunkingSystem.SecureMultikey.TrkSysSecureMultikeyDESXLTxRxDefault_A7833);
    this.Field.Add("TrkSysSecureMultikeyASTROOTAR_A7494", (IAcpField) this.TrunkingSystem.SecureMultikey.TrkSysSecureMultikeyASTROOTAR_A7494);
    this.Field.Add("TrkSysSecureMultikeyOTARTx_A8676", (IAcpField) this.TrunkingSystem.SecureMultikey.TrkSysSecureMultikeyOTARTx_A8676);
    this.Field.Add("TrkSysSecureMultikeyKMFProfileIndex_A8382", (IAcpField) this.TrunkingSystem.SecureMultikey.TrkSysSecureMultikeyKMFProfileIndex_A8382);
    this.Field.Add("TrkSysSecureMultikeyPatchKeySelect_A8694", (IAcpField) this.TrunkingSystem.SecureMultikey.TrkSysSecureMultikeyPatchKeySelect_A8694);
    this.Field.Add("TrkSysSecureMultikeyFailsoftKeySelect_A8012", (IAcpField) this.TrunkingSystem.SecureMultikey.TrkSysSecureMultikeyFailsoftKeySelect_A8012);
    this.Field.Add("TrkSysSecureMultikeyFailsoftSecureClearStrapping_43479", (IAcpField) this.TrunkingSystem.SecureMultikey.TrkSysSecureMultikeyFailsoftSecureClearStrapping_43479);
    this.Field.Add("TrkSysSecureMultikeyPrivateCallKeySelect_A8757", (IAcpField) this.TrunkingSystem.SecureMultikey.TrkSysSecureMultikeyPrivateCallKeySelect_A8757);
    this.Field.Add("TrkSysSecureMultikeyPrivateCallSecureClearStrapping_43477", (IAcpField) this.TrunkingSystem.SecureMultikey.TrkSysSecureMultikeyPrivateCallSecureClearStrapping_43477);
    this.Field.Add("TrkSysSecureMultikeyInterconnectKeySelect_A8298", (IAcpField) this.TrunkingSystem.SecureMultikey.TrkSysSecureMultikeyInterconnectKeySelect_A8298);
    this.Field.Add("TrkSysSecureMultikeyInterconnectSecureClearStrapping_43478", (IAcpField) this.TrunkingSystem.SecureMultikey.TrkSysSecureMultikeyInterconnectSecureClearStrapping_43478);
    this.Field.Add("TrkSysSecureMultikeySystemWideKeySelect_A9253", (IAcpField) this.TrunkingSystem.SecureMultikey.TrkSysSecureMultikeySystemWideKeySelect_A9253);
    this.Field.Add("TrkSysSecureMultikeyDynamicTalkgroupKeySelect_A7918", (IAcpField) this.TrunkingSystem.SecureMultikey.TrkSysSecureMultikeyDynamicTalkgroupKeySelect_A7918);
    this.Field.Add("TrkSysSecureMultikeyDynamicSecureClearStrapping_43489", (IAcpField) this.TrunkingSystem.SecureMultikey.TrkSysSecureMultikeyDynamicSecureClearStrapping_43489);
    this.Field.Add("TrkSysSecureMultikeyDynamicAGKeySelect_A7914", (IAcpField) this.TrunkingSystem.SecureMultikey.TrkSysSecureMultikeyDynamicAGKeySelect_A7914);
    this.Field.Add("TrkSysSecureMultikeyVirtualPartnerSecureClearStrapping_A43670", (IAcpField) this.TrunkingSystem.SecureMultikey.TrkSysSecureMultikeyVirtualPartnerSecureClearStrapping_A43670);
    this.Field.Add("TrkSysSecureMultikeyVirtualPartnerKeySelect_A43669", (IAcpField) this.TrunkingSystem.SecureMultikey.TrkSysSecureMultikeyVirtualPartnerKeySelect_A43669);
    this.Field.Add("TrkSysLabtoolTrunkingSystemAPCOChannelIdentifierListItemID_A19965", (IAcpField) this.TrunkingSystem.Labtool.TrkSysLabtoolTrunkingSystemAPCOChannelIdentifierListItemID_A19965);
    this.Field.Add("TrkSysLabtoolTrunkingSystemOneTouchListItemID_A22633", (IAcpField) this.TrunkingSystem.Labtool.TrkSysLabtoolTrunkingSystemOneTouchListItemID_A22633);
    this.Field.Add("TrkSysLabtoolTrunkingSystemControlChannelListItemID_A19964", (IAcpField) this.TrunkingSystem.Labtool.TrkSysLabtoolTrunkingSystemControlChannelListItemID_A19964);
    this.Field.Add("TrkSysLabtoolTrunkingSystemIIOBTChannelAssignmentListItemID_A19966", (IAcpField) this.TrunkingSystem.Labtool.TrkSysLabtoolTrunkingSystemIIOBTChannelAssignmentListItemID_A19966);
    this.Field.Add("TrkSysLabtoolTrunkingSystemStatusAliasListItemID_A19967", (IAcpField) this.TrunkingSystem.Labtool.TrkSysLabtoolTrunkingSystemStatusAliasListItemID_A19967);
    this.Field.Add("TrkSysLabtoolTrunkingSystemStatusAliasTextListItemID_A19968", (IAcpField) this.TrunkingSystem.Labtool.TrkSysLabtoolTrunkingSystemStatusAliasTextListItemID_A19968);
    this.Field.Add("TrkSysLabtoolTrunkingSystemMessageAliasListItemID_A19969", (IAcpField) this.TrunkingSystem.Labtool.TrkSysLabtoolTrunkingSystemMessageAliasListItemID_A19969);
    this.Field.Add("TrkSysLabtoolTrunkingSystemMessageAliasTextListItemID_A19970", (IAcpField) this.TrunkingSystem.Labtool.TrkSysLabtoolTrunkingSystemMessageAliasTextListItemID_A19970);
    this.Field.Add("TrkSysLabtoolTrunkingSystemSiteAliasTextListItemID_A19972", (IAcpField) this.TrunkingSystem.Labtool.TrkSysLabtoolTrunkingSystemSiteAliasTextListItemID_A19972);
    this.Field.Add("TrkSysLabtoolTrunkingSystemSiteAliasListItemID_A19971", (IAcpField) this.TrunkingSystem.Labtool.TrkSysLabtoolTrunkingSystemSiteAliasListItemID_A19971);
    this.Field.Add("TrkSysFeaturesGroupTMSEable_42804", (IAcpField) this.TrunkingSystem.Features.TrkSysFeaturesGroupTMSEable_42804);
    this.Field.Add("TrkSysFeaturesPASelection_A42882", (IAcpField) this.TrunkingSystem.Features.TrkSysFeaturesPASelection_A42882);
    this.Field.Add("TrkSysFeatureEnableIntermediateHunt_A44946", (IAcpField) this.TrunkingSystem.Features.TrkSysFeatureEnableIntermediateHunt_A44946);
    this.Field.Add("TrkPerFeaturesOTARadioAliasType_42854", (IAcpField) this.TrunkingSystem.Features.TrkPerFeaturesOTARadioAliasType_42854);
    this.Field.Add("TrkSysFeaturesOTARadioAliasUpdateEnable_A43057", (IAcpField) this.TrunkingSystem.Features.TrkSysFeaturesOTARadioAliasUpdateEnable_A43057);
    this.Field.Add("TrkSysGeneralAskRequired_A44909", (IAcpField) this.TrunkingSystem.General.TrkSysGeneralAskRequired_A44909);
  }

  private void AddTrunkingWide()
  {
    this.Field.Add("TrkWideGeneralIndividualCallMaxTargetRingTimesec_A8290", (IAcpField) this.TrunkingWide.General.TrkWideGeneralIndividualCallMaxTargetRingTimesec_A8290);
    this.Field.Add("TrkWideGeneralPrivateCallMaxInitialRingsec_A8758", (IAcpField) this.TrunkingWide.General.TrkWideGeneralPrivateCallMaxInitialRingsec_A8758);
    this.Field.Add("TrkWideGeneralPhoneAutoDialHoldoffms_A7506", (IAcpField) this.TrunkingWide.General.TrkWideGeneralPhoneAutoDialHoldoffms_A7506);
    this.Field.Add("TrkWideGeneralEmergencyBlockedInFailsoft_A7934", (IAcpField) this.TrunkingWide.General.TrkWideGeneralEmergencyBlockedInFailsoft_A7934);
    this.Field.Add("TrkWideGeneralAFCDisable_A41850", (IAcpField) this.TrunkingWide.General.TrkWideGeneralAFCDisable_A41850);
    this.Field.Add("TrkWideFilterConstantsFilterConstantK1_A8114", (IAcpField) this.TrunkingWide.FilterConstants.TrkWideFilterConstantsFilterConstantK1_A8114);
    this.Field.Add("TrkWideFilterConstantsFilterConstantK2_A8115", (IAcpField) this.TrunkingWide.FilterConstants.TrkWideFilterConstantsFilterConstantK2_A8115);
    this.Field.Add("TrkWideFilterConstantsFilterConstantK3_A8116", (IAcpField) this.TrunkingWide.FilterConstants.TrkWideFilterConstantsFilterConstantK3_A8116);
    this.Field.Add("TrkWideFilterConstantsFilterThresholdConstantT1_A8117", (IAcpField) this.TrunkingWide.FilterConstants.TrkWideFilterConstantsFilterThresholdConstantT1_A8117);
    this.Field.Add("TrkWideFilterConstantsFilterThresholdConstantT2_A8118", (IAcpField) this.TrunkingWide.FilterConstants.TrkWideFilterConstantsFilterThresholdConstantT2_A8118);
    this.Field.Add("TrkWideFilterConstantsFilterThresholdConstantT3_A8119", (IAcpField) this.TrunkingWide.FilterConstants.TrkWideFilterConstantsFilterThresholdConstantT3_A8119);
    this.Field.Add("TrkWideRSSIThresholdsRSSIOSWCounter_A8995", (IAcpField) this.TrunkingWide.RSSIThresholds.TrkWideRSSIThresholdsRSSIOSWCounter_A8995);
    this.Field.Add("TrkWideRSSIThresholdsRSSIOSPCounter_A8994", (IAcpField) this.TrunkingWide.RSSIThresholds.TrkWideRSSIThresholdsRSSIOSPCounter_A8994);
    this.Field.Add("TrkWideRSSIThresholdsDesenseTimer_A7828", (IAcpField) this.TrunkingWide.RSSIThresholds.TrkWideRSSIThresholdsDesenseTimer_A7828);
    this.Field.Add("TrkWideRSSIThresholdsRSSIAcceptableThreshold_A8989", (IAcpField) this.TrunkingWide.RSSIThresholds.TrkWideRSSIThresholdsRSSIAcceptableThreshold_A8989);
    this.Field.Add("TrkWideRSSIThresholdsRSSIGoodThreshold_A8992", (IAcpField) this.TrunkingWide.RSSIThresholds.TrkWideRSSIThresholdsRSSIGoodThreshold_A8992);
    this.Field.Add("TrkWideRSSIThresholdsRSSIVeryGoodThreshold_A8996", (IAcpField) this.TrunkingWide.RSSIThresholds.TrkWideRSSIThresholdsRSSIVeryGoodThreshold_A8996);
    this.Field.Add("TrkWideRSSIThresholdsRSSIExcellentThreshold_A8991", (IAcpField) this.TrunkingWide.RSSIThresholds.TrkWideRSSIThresholdsRSSIExcellentThreshold_A8991);
    this.Field.Add("TrkWideRSSIThresholdsStrongSignalRoaming_A24630", (IAcpField) this.TrunkingWide.RSSIThresholds.TrkWideRSSIThresholdsStrongSignalRoaming_A24630);
    this.Field.Add("TrkWideCAIDataMaxTxAttempts_A8475", (IAcpField) this.TrunkingWide.CAIData.TrkWideCAIDataMaxTxAttempts_A8475);
    this.Field.Add("TrkWideCAIDataResponseTimerms_A8949", (IAcpField) this.TrunkingWide.CAIData.TrkWideCAIDataResponseTimerms_A8949);
    this.Field.Add("TrkWideCAIDataMinResponseTimerms_A8515", (IAcpField) this.TrunkingWide.CAIData.TrkWideCAIDataMinResponseTimerms_A8515);
    this.Field.Add("TrkWideCAIDataFrameSyncSeekPeriodms_A8146", (IAcpField) this.TrunkingWide.CAIData.TrkWideCAIDataFrameSyncSeekPeriodms_A8146);
    this.Field.Add("TrkWideCAIDataTxShortRandomRangems_A9566", (IAcpField) this.TrunkingWide.CAIData.TrkWideCAIDataTxShortRandomRangems_A9566);
    this.Field.Add("TrkWideCAIDataTxLongRandomRangeMs_A9547", (IAcpField) this.TrunkingWide.CAIData.TrkWideCAIDataTxLongRandomRangeMs_A9547);
    this.Field.Add("TrkWideCAIDataTxRespRandomRangems_A9564", (IAcpField) this.TrunkingWide.CAIData.TrkWideCAIDataTxRespRandomRangems_A9564);
    this.Field.Add("TrkWideCAIDataTxLimitedPatienceSec_A9545", (IAcpField) this.TrunkingWide.CAIData.TrkWideCAIDataTxLimitedPatienceSec_A9545);
    this.Field.Add("TrkWideAdvancedFailsoftInactivitysec_A8010", (IAcpField) this.TrunkingWide.Advanced.TrkWideAdvancedFailsoftInactivitysec_A8010);
    this.Field.Add("TrkWideAdvancedAffiliationHoldOffsec_A7412", (IAcpField) this.TrunkingWide.Advanced.TrkWideAdvancedAffiliationHoldOffsec_A7412);
    this.Field.Add("TrkWideAdvancedFullSpectrumControlChannelScan_A8161", (IAcpField) this.TrunkingWide.Advanced.TrkWideAdvancedFullSpectrumControlChannelScan_A8161);
    this.Field.Add("TrkWideAdvancedFullSpectrumControlChannelScanTimersec_A8162", (IAcpField) this.TrunkingWide.Advanced.TrkWideAdvancedFullSpectrumControlChannelScanTimersec_A8162);
    this.Field.Add("TrkWideAdvancedInternalRadioHoldoffmin_A8309", (IAcpField) this.TrunkingWide.Advanced.TrkWideAdvancedInternalRadioHoldoffmin_A8309);
    this.Field.Add("TrkWideAdvancedHoldoffDelaysec_A8201", (IAcpField) this.TrunkingWide.Advanced.TrkWideAdvancedHoldoffDelaysec_A8201);
    this.Field.Add("TrkWideAdvancedISWWindowAdjustment_A8358", (IAcpField) this.TrunkingWide.Advanced.TrkWideAdvancedISWWindowAdjustment_A8358);
    this.Field.Add("TrkWideAdvancedVirtualPartnerCallActivityTime_A43675", (IAcpField) this.TrunkingWide.Advanced.TrkWideAdvancedVirtualPartnerCallActivityTime_A43675);
    this.Field.Add("TrkWideLabtoolDesenseRSSIThreshold_A7827", (IAcpField) this.TrunkingWide.Labtool.TrkWideLabtoolDesenseRSSIThreshold_A7827);
    this.Field.Add("TrkWideLabtoolPhase2ScramblingDisable_A37983", (IAcpField) this.TrunkingWide.Labtool.TrkWideLabtoolPhase2ScramblingDisable_A37983);
  }

  private void AddPersonnelAccountability()
  {
    this.Field.Add("RadioErgoConfigACPAListAlertName_A42874", (IAcpField) this.PersonnelAccountability.General.RadioErgoConfigACPAListAlertName_A42874);
    this.Field.Add("RadioErgoConfigACReference_A42911", (IAcpField) this.PerAccListTableInner.PerAccListTableInnerSection.RadioErgoConfigACReference_A42911);
  }
}
