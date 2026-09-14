// Decompiled with JetBrains decompiler
// Type: MackinawCPS.DocumentOperations
// Assembly: APXFamilyCPS, Version=36.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 9359335E-041C-4B12-9409-F4E6E7D93299
// Assembly location: C:\Program Files (x86)\Motorola\ApxFamilyCPS R36.00\APXFamilyCPS1.exe

using AcpBusinessLayer;
using AcpBusinessLayer.UndoRedo;
using AcpCommonLib;
using AcpCommonLib.UndoRedo;
using Common;
using CommonResources;
using ConstraintHelper;
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
using SpecialFeatures.Comms;
using SpecialFeatures.DVRSFiles.List;
using SpecialFeatures.Flashport.FlashRadio;
using SpecialFeatures.Security;
using SpecialFeatures.SystemCertificates.List;
using SpecialFeatures.Ucl.Contact;
using SpecialFeatures.Ucl.HotList;
using SpecialFeatures.Ucl.UclWide;
using SpecialFeatures.VoiceAnnouncements.List;
using SpecialFeatures.VoiceAnnouncements.SiteSelectableAlertList;
using SpecialFeatures.VoiceAnnouncements.Wide;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows;

#nullable disable
namespace MackinawCPS;

public class DocumentOperations
{
  private Version CodeplugVersion => FeatureManager.GetCodeplugVersion();

  public void InitDocument()
  {
    this.InitDocument((Document) ((App) Application.Current).TheDocument);
  }

  public void InitDocument(Document doc)
  {
    if (doc == null)
      return;
    FeatureManager.BeginAddFeatures(doc);
    DocumentOperations.AddAllFeatures(doc);
    FeatureManager.EndAddFeatures(doc);
    this.UclTemplateNodeInit();
    doc.ModificationLogEnabled = false;
  }

  public static void AddAllFeatures(Document doc)
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
    FeatureManager.AddFeature(doc, (IAcpRecordset) new ControlHeadE5Recset());
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
    FeatureManager.AddFeature(doc, (IAcpRecordset) new SystemCertificateListRecSet());
    FeatureManager.AddFeature(doc, (IAcpRecordset) new URLTableRecset());
    FeatureManager.AddFeature(doc, (IAcpRecordset) new DVRSFileListRecSet());
    FeatureManager.AddFeature(doc, (IAcpRecordset) new VirtualPartnerAlertRecset());
    FeatureManager.AddFeature(doc, (IAcpRecordset) new TTSVoiceAnnouncementListRecSet());
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

  private void ResetInvalidFrequencyOptions()
  {
    foreach (Motorola.MackinawCPS.CoreFeatures.ConventionalPersonality.ConventionalPersonality conventionalPersonality in (FeatureManager.GetFeature(2059) as ConventionalPersonalityRecset).Cast<Motorola.MackinawCPS.CoreFeatures.ConventionalPersonality.ConventionalPersonality>())
    {
      foreach (FrequencyOptionsInner frequencyOptionsInner in (conventionalPersonality.FrequencyOptions.EmbeddedRecset as FrequencyOptionsInnerRecset).Cast<FrequencyOptionsInner>())
      {
        foreach (AcpListField acpListField in frequencyOptionsInner.FrequencyOptionsInnerSection.FieldsCollection.Where<IAcpField>((Func<IAcpField, bool>) (x => x is AcpListField)).Cast<AcpListField>())
        {
          if (acpListField.Value == 0 && acpListField.UIValue == "")
            acpListField.ResetToDefault();
        }
      }
    }
  }

  public void FixUpAfterOpen()
  {
    this.SetProductModelIdentifierField();
    this.PropertiesChanged();
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
    if (UtilityMack.IsPortable())
      this.TxPowerTableInit();
    this.MFKTableInit();
    this.ShepherdsInitForFob();
    this.TriggerMuteToneRefresh();
    int num = this.O9TableInit() ? 1 : 0;
    this.SyncE5BottomButton();
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
    this.AlertListTableInit();
    this.AddQC2DefaultRecord();
    this.expandFlashcode();
    ASKConstraints.Initialize();
    ConstraintManager.Suspend();
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
    this.expandFlashcode();
    this.ResetInvalidFrequencyOptions();
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

  private void SecureADPKeyDataFixup()
  {
    if (int.Parse(((FeatureManager.GetFeature(2049) as RadioInformationRecset)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation).General.RadInfoGeneralCodeplugVersion_A7683.Value.Substring(1, 2)) >= 8)
      return;
    Motorola.MackinawCPS.CoreFeatures.SecureWide.SecureWide secureWide = FeatureManager.GetFeature(2021)[0] as Motorola.MackinawCPS.CoreFeatures.SecureWide.SecureWide;
    if (secureWide.General.SecWideGeneralSecureOperation_A9067.Value != 3 || !(secureWide.EncryptionKeyList.EmbeddedRecset is EncryptionKeyListInnerRecset embeddedRecset) || embeddedRecset.Count == 0)
      return;
    foreach (IAcpFeatureNode acpFeatureNode in (Collection<FeatureNode>) embeddedRecset)
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
    foreach (Motorola.MackinawCPS.CoreFeatures.ScanList.ScanList scanList in (Collection<FeatureNode>) feature)
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
    foreach (Motorola.MackinawCPS.CoreFeatures.ConventionalPersonality.ConventionalPersonality conventionalPersonality in (Collection<FeatureNode>) feature)
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
    foreach (Motorola.MackinawCPS.CoreFeatures.ScanList.ScanList scanList in (Collection<FeatureNode>) acpRecordset)
      ((Recordset) scanList.ScanListMembers.EmbeddedRecset).RefreshKeyMap();
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

  private void InitTrkPerAnnGroup()
  {
    foreach (Motorola.MackinawCPS.CoreFeatures.TrunkingPersonality.TrunkingPersonality trunkingPersonality in AppInfoManager.AppMode != ApplicationMode.CodeplugConfigurationMode ? (Collection<FeatureNode>) (AppInfoManager.ComparatorDocument.GetFeature(2072) as TrunkingPersonalityRecset) : (Collection<FeatureNode>) (FeatureManager.GetFeature(2072) as TrunkingPersonalityRecset))
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

  private void ToneSignalingListToneAliasFixup()
  {
    if (this.CodeplugVersion.Major >= 14)
      return;
    foreach (FeatureNode featureNode1 in (Collection<FeatureNode>) (FeatureManager.GetFeature(4156) as ToneSignalingListRecset))
    {
      if (featureNode1 is Motorola.MackinawCPS.CoreFeatures.ToneSignalingList.ToneSignalingList toneSignalingList && toneSignalingList.AstroAlertingToneListExpander != null && toneSignalingList.AstroAlertingToneListExpander.EmbeddedRecset != null && toneSignalingList.AstroAlertingToneListExpander.EmbeddedRecset is AstroAlertingToneTableInnerRecset embeddedRecset)
      {
        int num = 1;
        foreach (FeatureNode featureNode2 in (Collection<FeatureNode>) embeddedRecset)
        {
          (featureNode2 as AstroAlertingToneTableInner).AstroAlertingToneTableInnerSection.RadErgoAstroAlertingToneTableToneAliasText_42533.SetValue($"Tone Alias {num}");
          ++num;
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

  private void AddQC2DefaultRecord()
  {
    IAcpRecordset feature = FeatureManager.GetFeature(2053);
    if (feature == null)
      return;
    foreach (FeatureNode featureNode in (Collection<FeatureNode>) feature)
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

  private void updateUnpackedFields(bool isReadingRadio, RadioParams currentRadioParams)
  {
    UndoManager.StopUndoRedo();
    this.AddQC2DefaultRecord();
    this.SyncQC2Code();
    this.InitTrkPerAnnGroup();
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
    this.FixPassword();
    this.UnpackFixupForFPPProtectedZonePassword();
    this.RefreshAESFields();
    this.SynPreAmp();
    this.SetValueForNewCnvHotMicTxPeriodField();
    this.SetValueForNewTrkHotMicTxPeriodField();
    UpgradeRadio.SetWindNoiseReductionLevelForAccessories();
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
            foreach (DEKButtonInner dekButtonInner in (Collection<FeatureNode>) embeddedRecset1)
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
            foreach (DEKButtonInner dekButtonInner in (Collection<FeatureNode>) embeddedRecset1)
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
            foreach (DEKButtonInner dekButtonInner in (Collection<FeatureNode>) embeddedRecset1)
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
          foreach (TopFunctionProgrammableButtonListInner programmableButtonListInner in (Collection<FeatureNode>) embeddedRecset5)
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
          foreach (TopFunctionProgrammableButtonListInner programmableButtonListInner in (Collection<FeatureNode>) embeddedRecset5)
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
      IAcpRecordset embeddedRecset10 = feature2[0][10628].EmbeddedRecset;
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
        foreach (TopFunctionProgrammableButtonListInner programmableButtonListInner in (Collection<FeatureNode>) embeddedRecset5)
        {
          if (programmableButtonListInner.TopFunctionProgrammableButtonListInnerSection.CnvTopFunctionButtonBCO_A36628.Value == listInnerSection.RadErgoControlO9ACBCOListBco_A36666.Value)
          {
            programmableButtonListInner.TopFunctionProgrammableButtonListInnerSection.O9CHCnvTopFunctionButtonIndex_A36634.UIValue = listInnerSection.RadErgoControlO9ACBCOListIndex_A36668.UIValue;
            programmableButtonListInner.TopFunctionProgrammableButtonListInnerSection.O9CHTrkTopFunctionButtonIndex_A36639.SetValue(listInnerSection.RadErgoControlO9ACBCOListIndex_A36668.Value);
            break;
          }
        }
        foreach (BottomFunctionProgrammableButtonInner programmableButtonInner in (Collection<FeatureNode>) embeddedRecset8)
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
        foreach (TopFunctionProgrammableButtonListInner programmableButtonListInner in (Collection<FeatureNode>) embeddedRecset5)
        {
          if (programmableButtonListInner.TopFunctionProgrammableButtonListInnerSection.CnvTopFunctionButtonBCO_A36628.Value == listInnerSection.RdEgoO9DirLtbarPatternBcoListBco_A36661.Value)
          {
            programmableButtonListInner.TopFunctionProgrammableButtonListInnerSection.O9CHCnvTopFunctionButtonIndex_A36634.UIValue = listInnerSection.RdEgoO9DirLtbarPatternBcoListIndex_A36707.UIValue;
            programmableButtonListInner.TopFunctionProgrammableButtonListInnerSection.O9CHTrkTopFunctionButtonIndex_A36639.SetValue(listInnerSection.RdEgoO9DirLtbarPatternBcoListIndex_A36707.Value);
            break;
          }
        }
        foreach (BottomFunctionProgrammableButtonInner programmableButtonInner in (Collection<FeatureNode>) embeddedRecset8)
        {
          if (programmableButtonInner.BottomFunctionProgrammableButtonInnerSection.CHO9BottomFunctionButtonBCO_A36660.Value == listInnerSection.RdEgoO9DirLtbarPatternBcoListBco_A36661.Value)
          {
            programmableButtonInner.BottomFunctionProgrammableButtonInnerSection.CHO9BottomFunctionButtonIndex_A36665.UIValue = listInnerSection.RdEgoO9DirLtbarPatternBcoListIndex_A36707.UIValue;
            break;
          }
        }
        foreach (DirectionalButtonsListInner buttonsListInner in (Collection<FeatureNode>) embeddedRecset16)
        {
          if (buttonsListInner.DirectionalButtonsListInnerSection.RadErgCtrlHeadO9DirLightBarBCO_A36559.Value == listInnerSection.RdEgoO9DirLtbarPatternBcoListBco_A36661.Value)
          {
            buttonsListInner.DirectionalButtonsListInnerSection.RadErgCtrlHeadO9DirLightBarIndex_A36601.UIValue = listInnerSection.RdEgoO9DirLtbarPatternBcoListIndex_A36707.UIValue;
            break;
          }
        }
        foreach (KeypadButtonInner keypadButtonInner in (Collection<FeatureNode>) ((FeatureManager.GetFeature(4109) as KeypadRecset)[0][10710].EmbeddedRecset as KeypadButtonInnerRecset))
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
          foreach (TopFunctionProgrammableButtonListInner programmableButtonListInner in (Collection<FeatureNode>) embeddedRecset5)
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
      foreach (FeatureNode featureNode in (Collection<FeatureNode>) (feature3[0] as Motorola.MackinawCPS.CoreFeatures.MPLConfiguration.MPLConfiguration).MPLList.EmbeddedRecset)
      {
        MPLListInner mplListInner = featureNode as MPLListInner;
        mplListInner.MPLListInnerSection.MplCfgMPLListTxPLFreq_A9556.SetValue(mplListInner.MPLListInnerSection.MplCfgMPLListTxPLCode_A9555.Value);
        mplListInner.MPLListInnerSection.MplCfgMPLListRxPLFreq_A9027.SetValue(mplListInner.MPLListInnerSection.MplCfgMPLListRxPLCode_A9026.Value);
        mplListInner.MPLListInnerSection.MplCfgMPLListTAPLFreq_A9263.SetValue(mplListInner.MPLListInnerSection.MplCfgMPLListTAPLCode_A9262.Value);
      }
    }
    IAcpRecordset feature4 = FeatureManager.GetFeature(2059);
    if (feature4 != null && feature4.Count != 0)
    {
      foreach (FeatureNode featureNode1 in (Collection<FeatureNode>) feature4)
      {
        foreach (FeatureNode featureNode2 in (Collection<FeatureNode>) (featureNode1 as Motorola.MackinawCPS.CoreFeatures.ConventionalPersonality.ConventionalPersonality).FrequencyOptions.EmbeddedRecset)
        {
          FrequencyOptionsInnerSection optionsInnerSection = (featureNode2 as FrequencyOptionsInner).FrequencyOptionsInnerSection;
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
        foreach (SignalIndependentProductIndependentProgrammableButtonListInner programmableButtonListInner in (Collection<FeatureNode>) embeddedRecset22)
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
      foreach (FeatureNode featureNode in (Collection<FeatureNode>) feature10)
      {
        Motorola.MackinawCPS.CoreFeatures.TrunkingSystem.TrunkingSystem trunkingSystem = featureNode as Motorola.MackinawCPS.CoreFeatures.TrunkingSystem.TrunkingSystem;
        trunkingSystem.General.TrkSysLabtoolNetworkID_A8565.SetValue(trunkingSystem.General.TrkSysGeneralSystemType_A9252.Value != 3 ? ((trunkingSystem.General.TrkSysGeneralSystemID_A9239.Value & (int) byte.MaxValue) << 4) + trunkingSystem.General.TrkSysGeneralConnectToneHz_A7710.Value : 0);
      }
    }
    IAcpRecordset feature11 = FeatureManager.GetFeature(4174);
    if (feature11 != null && feature11.Count != 0)
    {
      foreach (FeatureNode featureNode in (Collection<FeatureNode>) feature11)
      {
        Motorola.MackinawCPS.CoreFeatures.MissionCriticalGeofence.MissionCriticalGeofence criticalGeofence = featureNode as Motorola.MackinawCPS.CoreFeatures.MissionCriticalGeofence.MissionCriticalGeofence;
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
      int newValue = 1;
      IAcpRecordset feature13 = FeatureManager.GetFeature(2021);
      Motorola.MackinawCPS.CoreFeatures.SecureWide.SecureWide secureWide = (Motorola.MackinawCPS.CoreFeatures.SecureWide.SecureWide) null;
      if (feature13 != null && feature13.Count != 0)
      {
        secureWide = feature13[0] as Motorola.MackinawCPS.CoreFeatures.SecureWide.SecureWide;
        newValue = secureWide.ASTROOTAR.SecWideASTROOTARIndividualASTROOTARRadioID_A8284.DefaultValue;
      }
      foreach (Motorola.MackinawCPS.CoreFeatures.SecureKMFProfile.SecureKMFProfile secureKmfProfile in (Collection<FeatureNode>) (feature12 as SecureKMFProfileRecset))
      {
        if (!secureKmfProfile.General.SecKmfProfGenIndependentKeyList_43597.Value)
        {
          newValue = secureKmfProfile.ASTROOTARInformation.SecKmfProfASTROOTARInformationIndividualASTROOTARRadioID_A8285.Value;
          break;
        }
      }
      secureWide?.ASTROOTAR.SecWideASTROOTARIndividualASTROOTARRadioID_A8284.SetValue(newValue);
    }
    this.InitFCCNarrowBandSplit();
    IAcpRecordset feature14 = FeatureManager.GetFeature(2021);
    if (feature14 != null && feature14.Count != 0)
    {
      Motorola.MackinawCPS.CoreFeatures.SecureWide.SecureWide secureWide = feature14[0] as Motorola.MackinawCPS.CoreFeatures.SecureWide.SecureWide;
      if (secureWide.EncryptionKeyList.EmbeddedRecset != null)
      {
        int newValue = -1;
        foreach (FeatureNode featureNode in (Collection<FeatureNode>) secureWide.EncryptionKeyList.EmbeddedRecset)
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
      IAcpRecordset embeddedRecset23 = displayAndMenu.BacklightColorControl.EmbeddedRecset;
      int num = 0;
      foreach (FeatureNode featureNode in (Collection<FeatureNode>) embeddedRecset23)
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
          Recordset embeddedRecset24 = (Recordset) (uclContact.PhoneCallList.EmbeddedRecset as PhoneCallListRecset);
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
    this.SyncAllControlHeadsNavigationControls();
    Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation radioInformation = FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation;
    string codeplugVersionA7683 = (string) radioInformation.General.RadInfoGeneralCodeplugVersion_A7683;
    bool dispatchA38638Value = radioInformation.Labtool.RadInfoLabtoolExtendedDispatch_A38638Value;
    int num1 = int.Parse(codeplugVersionA7683.Substring(1, 2));
    ConventionalSystemRecset feature16 = FeatureManager.GetFeature(2053) as ConventionalSystemRecset;
    if (num1 < 9)
    {
      foreach (Motorola.MackinawCPS.CoreFeatures.ConventionalSystem.ConventionalSystem conventionalSystem in (Collection<FeatureNode>) feature16)
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
    if (FeatureManager.GetFeature(2054) is DataProfilesRecset feature17 && this.CodeplugVersion.Major < 9)
    {
      foreach (Motorola.MackinawCPS.CoreFeatures.DataProfiles.DataProfiles dataProfiles in (Collection<FeatureNode>) feature17)
      {
        if (dataProfiles.General.DataProfGeneralDataProfileType_A21320.Value == 0 && dataProfiles.General.DataProfGeneralPacketDataMode_A8689.Value == 0 && dataProfiles.Features.DataProfFeaturesARSMode_A7465.Value == 3)
          dataProfiles.Features.DataProfFeaturesARSMode_A7465.SetValue(0);
      }
    }
    if (FeatureManager.GetFeature(2059) is ConventionalPersonalityRecset feature18)
    {
      foreach (FeatureNode featureNode in (Collection<FeatureNode>) feature18)
      {
        if (featureNode is Motorola.MackinawCPS.CoreFeatures.ConventionalPersonality.ConventionalPersonality conventionalPersonality && conventionalPersonality.Secure.CnvPerSecureOTARTx_A8675.HiddenStatic && conventionalPersonality.Secure.CnvPerSecureOTARTx_A8675.Value)
          conventionalPersonality.Secure.CnvPerSecureOTARTx_A8675.SetValue(false);
      }
    }
    this.UpdatePaddingSpacesForSoftIDUsername();
    this.ConsolidatedActionBCOTableInit();
    if (UtilityMack.IsMobileOnly())
    {
      foreach (FeatureNode featureNode in (Collection<FeatureNode>) (FeatureManager.GetFeature(4008) as ActionConsolidationRecset))
      {
        ConsolidatedActionsInnerRecset embeddedRecset25 = ((Motorola.MackinawCPS.CoreFeatures.ActionConsolidation.ActionConsolidation) featureNode).General.EmbeddedRecset as ConsolidatedActionsInnerRecset;
        if (embeddedRecset25.Count != 0)
        {
          if (embeddedRecset25.ParentSection != null)
          {
            AcpFieldX<bool, string> actionAllowedA36579 = ((Motorola.MackinawCPS.CoreFeatures.ActionConsolidation.ActionConsolidation) featureNode).General.RadioErgoConfigACGeneralActionAllowed_A36579;
            bool flag = false;
            int num2 = 0;
            foreach (IAcpFeatureNode acpFeatureNode in (Collection<FeatureNode>) embeddedRecset25)
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
        foreach (FeatureNode featureNode in (Collection<FeatureNode>) embeddedRecset26)
        {
          (featureNode[10212] as Motorola.MackinawCPS.CoreFeatures.ControlHeadO3.DataButtonInnerSection).CHO3DataButtonConvIndex_A41419.CalculateApplicability();
          (featureNode[10212] as Motorola.MackinawCPS.CoreFeatures.ControlHeadO3.DataButtonInnerSection).CHO3DataButtonConvIndex_A41419.CalculateValidity();
          (featureNode[10212] as Motorola.MackinawCPS.CoreFeatures.ControlHeadO3.DataButtonInnerSection).CHO3DataButtonTrkIndex_A41420.CalculateApplicability();
          (featureNode[10212] as Motorola.MackinawCPS.CoreFeatures.ControlHeadO3.DataButtonInnerSection).CHO3DataButtonTrkIndex_A41420.CalculateValidity();
        }
      }
      if ((FeatureManager.GetFeature(4114) as ControlHeadO7Recset)[0][10717].EmbeddedRecset is O7DataButtonInnerRecset embeddedRecset27)
      {
        foreach (FeatureNode featureNode in (Collection<FeatureNode>) embeddedRecset27)
        {
          (featureNode[10713] as O7DataButtonInnerSection).CHO7DataButtonConvIndex_A41417.CalculateApplicability();
          (featureNode[10713] as O7DataButtonInnerSection).CHO7DataButtonConvIndex_A41417.CalculateValidity();
          (featureNode[10713] as O7DataButtonInnerSection).CHO7DataButtonTrkIndex_A41418.CalculateApplicability();
          (featureNode[10713] as O7DataButtonInnerSection).CHO7DataButtonTrkIndex_A41418.CalculateValidity();
        }
      }
      ControlHeadO9Recset feature19 = FeatureManager.GetFeature(4003) as ControlHeadO9Recset;
      ResponseSelectorListInnerRecset embeddedRecset28 = feature19[0][10624].EmbeddedRecset as ResponseSelectorListInnerRecset;
      O9DataButtonInnerRecset embeddedRecset29 = feature19[0][10611].EmbeddedRecset as O9DataButtonInnerRecset;
      if (embeddedRecset28 != null)
      {
        foreach (FeatureNode featureNode in (Collection<FeatureNode>) embeddedRecset28)
        {
          (featureNode[10625] as ResponseSelectorListInnerSection).CHO9PursuitKnobIndex_A36685.CalculateApplicability();
          (featureNode[10625] as ResponseSelectorListInnerSection).CHO9PursuitKnobIndex_A36685.CalculateValidity();
        }
      }
      if (embeddedRecset29 != null)
      {
        foreach (FeatureNode featureNode in (Collection<FeatureNode>) embeddedRecset29)
        {
          (featureNode[10608] as O9DataButtonInnerSection).CHO9DataButtonConvIndex_A41414.CalculateApplicability();
          (featureNode[10608] as O9DataButtonInnerSection).CHO9DataButtonConvIndex_A41414.CalculateValidity();
          (featureNode[10608] as O9DataButtonInnerSection).CHO9DataButtonTrkIndex_A41416.CalculateApplicability();
          (featureNode[10608] as O9DataButtonInnerSection).CHO9DataButtonTrkIndex_A41416.CalculateValidity();
        }
      }
      if ((FeatureManager.GetFeature(2128) as KeypadMicAndAccessoriesRecset)[0][10228].EmbeddedRecset is Motorola.MackinawCPS.CoreFeatures.KeypadMicAndAccessories.DataButtonInnerRecset embeddedRecset30)
      {
        foreach (FeatureNode featureNode in (Collection<FeatureNode>) embeddedRecset30)
        {
          (featureNode[10209] as Motorola.MackinawCPS.CoreFeatures.KeypadMicAndAccessories.DataButtonInnerSection).RadErgoCfgKMConventionalKMDatatButtonIndex_A41423.CalculateApplicability();
          (featureNode[10209] as Motorola.MackinawCPS.CoreFeatures.KeypadMicAndAccessories.DataButtonInnerSection).RadErgoCfgKMConventionalKMDatatButtonIndex_A41423.CalculateValidity();
          (featureNode[10209] as Motorola.MackinawCPS.CoreFeatures.KeypadMicAndAccessories.DataButtonInnerSection).RadErgoCfgKMTrunkingKMDatatButtonIndex_A41424.CalculateApplicability();
          (featureNode[10209] as Motorola.MackinawCPS.CoreFeatures.KeypadMicAndAccessories.DataButtonInnerSection).RadErgoCfgKMTrunkingKMDatatButtonIndex_A41424.CalculateValidity();
        }
      }
    }
    this.RefreshMaxChangeRecords();
    int channelsA11479Value = (FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation).General.RadInfoGeneralMaximumChannels_A11479Value;
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
          foreach (IAcpFeatureNode acpFeatureNode in (Collection<FeatureNode>) embeddedRecset31)
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
    UndoManager.StartUndoRedo();
  }

  private void ResetEmergencyAlarmRetryRateDefaultValue()
  {
    TPS tps = (FeatureManager.GetFeature(2045) as RadioWideRecset)[0][10749] as TPS;
    int major = this.CodeplugVersion.Major;
    if (tps == null || major >= 9)
      return;
    tps.RadWideTPSFiregroundEmergencyAlarmRetryRatesec_A7929.Value = 4;
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

  private void SetStatusAutoExitToAlwaysAndUpdateConStatusAliasNumber()
  {
    if (!UtilityMack.IsPortablePro || this.CodeplugVersion.Major >= 12 && (this.CodeplugVersion.Major != 12 || this.CodeplugVersion.Minor >= 1) || !(FeatureManager.GetFeature(2033)[0] is Motorola.MackinawCPS.CoreFeatures.RadioErgonomicsWide.RadioErgonomicsWide radioErgonomicsWide) || !radioErgonomicsWide.HomeMode.RadErgoWideHomeModeHomeModeSelection_A8202.HiddenStatic)
      return;
    if (FeatureManager.GetFeature(2010)[0] is Motorola.MackinawCPS.CoreFeatures.DisplayAndMenu.DisplayAndMenu displayAndMenu)
      displayAndMenu.Advanced.RadioErgDispAdvanceStatusAutoExit_42158.SetValue(1);
    if (!(FeatureManager.GetFeature(2007)[0] is Motorola.MackinawCPS.CoreFeatures.ConventionalAliasLists.ConventionalAliasLists conventionalAliasLists) || !(conventionalAliasLists.StatusAliasList.EmbeddedRecset is StatusAliasTableInnerRecset embeddedRecset))
      return;
    int num = 1;
    foreach (FeatureNode featureNode in (Collection<FeatureNode>) embeddedRecset)
    {
      if (featureNode is StatusAliasTableInner statusAliasTableInner)
        statusAliasTableInner.StatusAliasTableInnerSection.CnvAlsLstStatusAliasListStatusAliasNumber_A9191.SetValue(num++);
    }
  }

  private void SetAudioConfigurationLevelToBasic()
  {
    IAcpRecordset feature = FeatureManager.GetFeature(2045);
    if ((feature[0][10093] as Motorola.MackinawCPS.CoreFeatures.RadioWide.Labtool).RadWideLabtoolAudioEnhancement_A42736.Value)
      return;
    (feature[0][10101] as DigitalAudioOptions).RadWideAudioConfigurationLevel_42740.Value = 0;
  }

  private void SetAudioSettingGroupSettingValueToCustom()
  {
    if (this.CodeplugVersion.Major >= 13 && (this.CodeplugVersion.Major != 13 || this.CodeplugVersion.Minor >= 1) || !(FeatureManager.GetFeature(2077) is RadioProfilesRecset feature))
      return;
    foreach (IAcpFeatureNode acpFeatureNode in (Collection<FeatureNode>) feature)
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

  private void SyncValueForAccessoryFieldsForAudioEnhancementFeature()
  {
    if (this.CodeplugVersion.Major >= 13 && (this.CodeplugVersion.Major != 13 || this.CodeplugVersion.Minor >= 1) || !(FeatureManager.GetFeature(2077) is RadioProfilesRecset feature))
      return;
    foreach (FeatureNode featureNode in (Collection<FeatureNode>) feature)
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

  private void RefreshAudioEnhancementForConsolette()
  {
    if (this.CodeplugVersion.Major >= 15 || !(FeatureManager.GetFeature(2049)[0] is Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation radioInformation))
      return;
    string numberA8539Value = radioInformation.General.RadInfoGeneralModelNumber_A8539Value;
    if (numberA8539Value == null || !numberA8539Value.StartsWith("L30") || !(FeatureManager.GetFeature(2077) is RadioProfilesRecset feature))
      return;
    foreach (IAcpFeatureNode acpFeatureNode in (Collection<FeatureNode>) feature)
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
    foreach (Motorola.MackinawCPS.CoreFeatures.ActionConsolidation.ActionConsolidation actionConsolidation in (Collection<FeatureNode>) feature)
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

  private void RefreshDynChannelName()
  {
    if (!(FeatureManager.GetFeature(2045)[0] is Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide radioWide) || !radioWide.Labtool.RadWideLabtoolDynamicZoneScanCapability_42749.Value)
      return;
    IAcpRecordset acpRecordset = AppInfoManager.AppMode != ApplicationMode.CodeplugComparisonMode ? FeatureManager.GetFeature(2051) : AppInfoManager.ComparatorDocument.GetFeature(2051);
    if (acpRecordset == null)
      return;
    foreach (Motorola.MackinawCPS.CoreFeatures.ZoneChannelAssignment.ZoneChannelAssignment channelAssignment in (Collection<FeatureNode>) acpRecordset)
    {
      if (channelAssignment.Zone.ZnChanCfgZoneDynamicZoneEnable_A41257.Value)
      {
        if (channelAssignment.Channels.EmbeddedRecset is ChannelAssignmentListInnerRecset embeddedRecset)
        {
          int num = 1;
          foreach (ChannelAssignmentListInner assignmentListInner in (Collection<FeatureNode>) embeddedRecset)
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
      foreach (FeatureNode featureNode in (Collection<FeatureNode>) feature)
      {
        Motorola.MackinawCPS.CoreFeatures.DataProfiles.DataProfiles dataProfiles = featureNode as Motorola.MackinawCPS.CoreFeatures.DataProfiles.DataProfiles;
        if (dataProfiles.LTE.DataProfLTEEnabled_A42075.Value && ((int) (AcpField<int>) dataProfiles.General.DataProfGeneralDataProfileType_A21320 == 3 || (int) (AcpField<int>) dataProfiles.General.DataProfGeneralDataProfileType_A21320 == 4 || (int) (AcpField<int>) dataProfiles.General.DataProfGeneralDataProfileType_A21320 == 2))
          dataProfiles.LTE.DataProfBroadbandSource_A42858.SetValue(1);
      }
    }
    dataWide?.General.DataWideGeneralBroadbandCheckbackTime_A42862.SetValue(dataWide.LTE.DataWideLTELTECheckbackTime_A42205.Value);
  }

  private void RefreshUserSelectablePL()
  {
    ConventionalPersonalityRecset personalityRecset = AppInfoManager.AppMode != ApplicationMode.CodeplugConfigurationMode ? AppInfoManager.ComparatorDocument.GetFeature(2059) as ConventionalPersonalityRecset : FeatureManager.GetFeature(2059) as ConventionalPersonalityRecset;
    if (personalityRecset == null)
      return;
    foreach (FeatureNode featureNode in (Collection<FeatureNode>) personalityRecset)
    {
      Motorola.MackinawCPS.CoreFeatures.ConventionalPersonality.ConventionalPersonality conventionalPersonality = featureNode as Motorola.MackinawCPS.CoreFeatures.ConventionalPersonality.ConventionalPersonality;
      FrequencyOptionsInnerRecset embeddedRecset = conventionalPersonality.Features.Parent[10148].EmbeddedRecset as FrequencyOptionsInnerRecset;
      if (conventionalPersonality != null && embeddedRecset != null)
      {
        foreach (FrequencyOptionsInner frequencyOptionsInner in (Collection<FeatureNode>) embeddedRecset)
        {
          if (frequencyOptionsInner != null && frequencyOptionsInner.FrequencyOptionsInnerSection.CnvPerConventionalChannelOptionsUserSelectablePLMPLEnhance_43029.Value == 0 && frequencyOptionsInner.FrequencyOptionsInnerSection.CnvPerConventionalChannelOptionsUserSelectablePLMPL_A9606.Value)
            frequencyOptionsInner.FrequencyOptionsInnerSection.CnvPerConventionalChannelOptionsUserSelectablePLMPLEnhance_43029.SetValue(7);
        }
      }
    }
  }

  private void RefreshActionConsolidation()
  {
    ActionConsolidationRecset feature = FeatureManager.GetFeature(4008) as ActionConsolidationRecset;
    for (int index = 0; index < feature.Count; ++index)
    {
      ConsolidatedActionsInnerSection actionsInnerSection = ((feature[index][10615].EmbeddedRecset as ConsolidatedActionsInnerRecset).TemplateNode as ConsolidatedActionsInner).ConsolidatedActionsInnerSection;
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      actionsInnerSection.RadioErgoConfigACGeneralIndex_A36591.IsVisible = DocumentOperations.\u003C\u003EO.\u003C0\u003E__ConActionTypeIsGeneralOrExitOrControlOrInvalidSim ?? (DocumentOperations.\u003C\u003EO.\u003C0\u003E__ConActionTypeIsGeneralOrExitOrControlOrInvalidSim = new StateConstraint(ActionConsolidationConstraints.ConActionTypeIsGeneralOrExitOrControlOrInvalidSim));
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      actionsInnerSection.RadioErgoConfigACGeneralZone_A36592.IsVisible = DocumentOperations.\u003C\u003EO.\u003C1\u003E__ConActionTypeIsGeneralOrControlOrInvalidSim ?? (DocumentOperations.\u003C\u003EO.\u003C1\u003E__ConActionTypeIsGeneralOrControlOrInvalidSim = new StateConstraint(ActionConsolidationConstraints.ConActionTypeIsGeneralOrControlOrInvalidSim));
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      actionsInnerSection.RadioErgoConfigACGeneralChannel_A36593.IsVisible = DocumentOperations.\u003C\u003EO.\u003C1\u003E__ConActionTypeIsGeneralOrControlOrInvalidSim ?? (DocumentOperations.\u003C\u003EO.\u003C1\u003E__ConActionTypeIsGeneralOrControlOrInvalidSim = new StateConstraint(ActionConsolidationConstraints.ConActionTypeIsGeneralOrControlOrInvalidSim));
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      actionsInnerSection.RadioErgoConfigACGeneralTEXTMESSAGE_42913.IsVisible = DocumentOperations.\u003C\u003EO.\u003C2\u003E__ConActionTypeIsGeneralOrExit ?? (DocumentOperations.\u003C\u003EO.\u003C2\u003E__ConActionTypeIsGeneralOrExit = new StateConstraint(ActionConsolidationConstraints.ConActionTypeIsGeneralOrExit));
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      actionsInnerSection.RadioErgoConfigACGeneralTxPowerChange__42916.IsVisible = DocumentOperations.\u003C\u003EO.\u003C3\u003E__ConActionTypeIsGeneral ?? (DocumentOperations.\u003C\u003EO.\u003C3\u003E__ConActionTypeIsGeneral = new StateConstraint(ActionConsolidationConstraints.ConActionTypeIsGeneral));
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      actionsInnerSection.RadioErgoConfigACGeneralMuteSSA__42917.IsVisible = DocumentOperations.\u003C\u003EO.\u003C3\u003E__ConActionTypeIsGeneral ?? (DocumentOperations.\u003C\u003EO.\u003C3\u003E__ConActionTypeIsGeneral = new StateConstraint(ActionConsolidationConstraints.ConActionTypeIsGeneral));
      actionsInnerSection.CalculateVisibility();
    }
  }

  private void RefreshToneSignalingList()
  {
    if (!(FeatureManager.GetFeature(2059) is ConventionalPersonalityRecset feature))
      return;
    foreach (FeatureNode featureNode in (Collection<FeatureNode>) feature)
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
      foreach (FeatureNode featureNode in (Collection<FeatureNode>) embeddedRecset)
      {
        ConfiguredNetworksListInner networksListInner = featureNode as ConfiguredNetworksListInner;
        networksListInner.ConfiguredNetworksListInnerSection.DataWideWiFiNetworkEncryptedNetworkPassword_42517.CalculateValidity();
        if (!networksListInner.ConfiguredNetworksListInnerSection.DataWideWiFiNetworkEncryptedNetworkPassword_42517.Valid)
        {
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

  private void UnpackFixupForFPPProtectedZonePassword()
  {
    Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide radioWide = FeatureManager.GetFeature(2045)[0] as Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide;
    if (!(bool) (FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation).Labtool.RadInfoLabtoolQ53NonFEDFPPAndZoneClone_A8799 || !((string) radioWide.UserInformationAndPasswords.RadWideUserInformationandPasswordsProtectedZonePassword_A8766 == string.Empty) || !(bool) radioWide.Features.ZnChanCfgFPPProtectionFPPEnable_A8142)
      return;
    radioWide.Features.ZnChanCfgFPPProtectionFPPEnable_A8142.Value = false;
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

  private void SetValueForNewCnvHotMicTxPeriodField()
  {
    int major = this.CodeplugVersion.Major;
    if (this.GetConventionalEmergencyProfiles() == null || major >= 19)
      return;
    foreach (Motorola.MackinawCPS.CoreFeatures.ConventionalEmergencyProfiles.ConventionalEmergencyProfiles emergencyProfile in (Collection<FeatureNode>) this.GetConventionalEmergencyProfiles())
      emergencyProfile.General.CnvEmerProfGeneralTxPeriodsec2_A43600.SetValue((int) (AcpField<int>) emergencyProfile.General.CnvEmerProfGeneralTxPeriodsec1_A8212 * 10);
  }

  private ConventionalEmergencyProfilesRecset GetConventionalEmergencyProfiles()
  {
    return AppInfoManager.AppMode == ApplicationMode.CodeplugConfigurationMode ? FeatureManager.GetFeature(2075) as ConventionalEmergencyProfilesRecset : AppInfoManager.ComparatorDocument.GetFeature(2075) as ConventionalEmergencyProfilesRecset;
  }

  private void SetValueForNewTrkHotMicTxPeriodField()
  {
    int major = this.CodeplugVersion.Major;
    if (this.GetTrunkingEmergencyProfiles() == null || major >= 19)
      return;
    foreach (Motorola.MackinawCPS.CoreFeatures.TrunkingEmergencyProfiles.TrunkingEmergencyProfiles emergencyProfile in (Collection<FeatureNode>) this.GetTrunkingEmergencyProfiles())
      emergencyProfile.General.TrkEmerProfGeneralTxPeriodsec2_A43601.SetValue((int) (AcpField<int>) emergencyProfile.General.TrkEmerProfGeneralTxPeriodsec1_A7939 * 10);
  }

  private TrunkingEmergencyProfilesRecset GetTrunkingEmergencyProfiles()
  {
    return AppInfoManager.AppMode == ApplicationMode.CodeplugConfigurationMode ? FeatureManager.GetFeature(2076) as TrunkingEmergencyProfilesRecset : AppInfoManager.ComparatorDocument.GetFeature(2076) as TrunkingEmergencyProfilesRecset;
  }

  public bool IsPortableModel
  {
    set
    {
      string docFileName = ((App) Application.Current).TheDocument.docFileName;
      if (this.PropertyChanged == null)
        return;
      this.PropertyChanged((object) this, new PropertyChangedEventArgs(nameof (IsPortableModel)));
    }
    get => UtilityMack.IsPortable();
  }

  public event PropertyChangedEventHandler PropertyChanged;

  public bool IsMobileModel
  {
    set
    {
      string docFileName = ((App) Application.Current).TheDocument.docFileName;
      if (this.PropertyChanged == null)
        return;
      this.PropertyChanged((object) this, new PropertyChangedEventArgs(nameof (IsMobileModel)));
    }
    get => UtilityMack.IsMobile();
  }

  private void InitFCCNarrowBandSplit()
  {
    IAcpRecordset acpRecordset = AppInfoManager.AppMode != ApplicationMode.CodeplugComparisonMode ? FeatureManager.GetFeature(2045) : AppInfoManager.ComparatorDocument.GetFeature(2045);
    if (acpRecordset == null)
      return;
    FeatureNode parent = acpRecordset[0] as FeatureNode;
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
        foreach (Motorola.MackinawCPS.CoreFeatures.InternalMicNoiseReductionProfile.InternalMicNoiseReductionProfile reductionProfile in (Collection<FeatureNode>) (feature1 as InternalMicNoiseReductionProfileRecset))
        {
          reductionProfile.General.RadErgoCfgGeneralMAXSVECTOR_A21565.Value = reductionProfile.General.RadErgoCfgGeneralMAXSVECTOR_A21565.Value.ToUpper();
          reductionProfile.General.IntMicNsRdGenDINCOUTPUTEQVECTOR_A37718.Value = reductionProfile.General.IntMicNsRdGenDINCOUTPUTEQVECTOR_A37718.Value.ToUpper();
          reductionProfile.General.IntMicNsRdGenDINCEPVECTOR_A37719.Value = reductionProfile.General.IntMicNsRdGenDINCEPVECTOR_A37719.Value.ToUpper();
        }
      }
      if (feature2 != null && feature2.Count > 0)
      {
        foreach (Motorola.MackinawCPS.CoreFeatures.ExternalMicNoiseReductionProfile.ExternalMicNoiseReductionProfile reductionProfile in (Collection<FeatureNode>) (feature2 as ExternalMicNoiseReductionProfileRecset))
        {
          reductionProfile.General.RadErgoCfgGeneralMAXSVECTOR_A22297.Value = reductionProfile.General.RadErgoCfgGeneralMAXSVECTOR_A22297.Value.ToUpper();
          reductionProfile.General.ExtMicNsRdGenDINCOUTPUTEQVECTOR_A37720.Value = reductionProfile.General.ExtMicNsRdGenDINCOUTPUTEQVECTOR_A37720.Value.ToUpper();
          reductionProfile.General.ExtMicNsRdGenDINCEPVECTOR_A37721.Value = reductionProfile.General.ExtMicNsRdGenDINCEPVECTOR_A37721.Value.ToUpper();
        }
      }
      if (feature3 == null || feature3.Count <= 0)
        return;
      foreach (Motorola.MackinawCPS.CoreFeatures.GlobalNoiseReductionList.GlobalNoiseReductionList noiseReductionList in (Collection<FeatureNode>) (feature3 as GlobalNoiseReductionListRecset))
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

  private void RemoveTheRecordOfCallAlertIDDisplay()
  {
    if (!(FeatureManager.GetFeature(2010) is DisplayAndMenuRecset feature) || feature.Count <= 0 || !((feature[0] as Motorola.MackinawCPS.CoreFeatures.DisplayAndMenu.DisplayAndMenu).IDDisplay.EmbeddedRecset is IDDisplayTableInnerRecset embeddedRecset) || embeddedRecset.Count <= 2)
      return;
    for (int index = 2; index < embeddedRecset.Count; ++index)
      new DeleteRecordTask((FeatureNode) (embeddedRecset[index] as IDDisplayTableInner)).Do();
    IDDisplayTableInnerRecset._Min = embeddedRecset.Count;
    IDDisplayTableInnerRecset._MaxPool = embeddedRecset.Count;
    embeddedRecset.DefaultRecordCount = embeddedRecset.Count;
    embeddedRecset.Max = embeddedRecset.Count;
  }

  private void SynO2O7MFK()
  {
    IAcpRecordset feature = FeatureManager.GetFeature(2038);
    if (feature == null)
      return;
    foreach (MFKAssignmentControlInner assignmentControlInner in (Collection<FeatureNode>) ((feature[0] as Motorola.MackinawCPS.CoreFeatures.Switches.Switches).MultiFunctionKnob.EmbeddedRecset as MFKAssignmentControlInnerRecset))
      this.updateO2O7MFK(assignmentControlInner.MFKAssignmentControlInnerSection.SwitchMFKAssignmentControlName_A38529.Value, assignmentControlInner.MFKAssignmentControlInnerSection.RadErgoControlSwitchsMFKFeatureAssignment_A38514.Value);
  }

  internal void updateO2O7MFK(string name, int curConfigureFeature)
  {
    IAcpRecordset feature = FeatureManager.GetFeature(4114);
    if (feature != null)
    {
      foreach (O7MFKAssignmentControlInner assignmentControlInner in (Collection<FeatureNode>) ((feature[0] as Motorola.MackinawCPS.CoreFeatures.ControlHeadO7.ControlHeadO7).O7MultiFunctionKnob.EmbeddedRecset as O7MFKAssignmentControlInnerRecset))
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
    foreach (O2MFKAssignmentControlInner assignmentControlInner in (Collection<FeatureNode>) ((acpRecordset[0] as Motorola.MackinawCPS.CoreFeatures.ControlHeadO2.ControlHeadO2).O2MultiFunctionKnob.EmbeddedRecset as O2MFKAssignmentControlInnerRecset))
    {
      if (assignmentControlInner.O2MFKAssignmentControlInnerSection.O2MFKAssignmentControlName_A41274Value == name && assignmentControlInner.O2MFKAssignmentControlInnerSection.RadErgoControlO2MFKFeatureAssignment_A41275Value != curConfigureFeature)
      {
        assignmentControlInner.O2MFKAssignmentControlInnerSection.RadErgoControlO2MFKFeatureAssignment_A41275.SetValue(curConfigureFeature);
        break;
      }
    }
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
    if (!(FeatureManager.GetFeature(4236) is ControlHeadE5Recset feature4))
      return;
    ((feature4[0][10902].EmbeddedRecset as E5InnerRecset)[0][10901] as E5InnerSection).CHE5EmergencyButtonFeature_43768.SetValue(o5Inner.O5InnerSection.CntrlHeadO5SignalIndependentO5M5MXChiefCHButtonButtonFeature_A19754.Value);
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

  private void ConsolidatedActionBCOTableInit()
  {
    if (!(FeatureManager.GetFeature(4003) is ControlHeadO9Recset feature) || !(feature[0][10622].EmbeddedRecset is ConsolidatedActionBCOListInnerRecset embeddedRecset))
      return;
    foreach (IAcpFeatureNode acpFeatureNode in (Collection<FeatureNode>) embeddedRecset)
    {
      if (134 == (acpFeatureNode[10623] as ConsolidatedActionBCOListInnerSection).RadErgoControlO9ACBCOListBco_A36666.Value)
      {
        DocumentOperations.SyncO9ACBCODataButtonIndexToOtherDataButtonIndex((AcpListField) (acpFeatureNode[10623] as ConsolidatedActionBCOListInnerSection).RadErgoControlO9ACBCOListIndex_A36668);
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
      foreach (IAcpFeatureNode acpFeatureNode in (Collection<FeatureNode>) buttonInnerRecset1)
      {
        if (srcField.Value != (acpFeatureNode[10209] as Motorola.MackinawCPS.CoreFeatures.KeypadMicAndAccessories.DataButtonInnerSection).RadErgoCfgKMConventionalKMDatatButtonIndex_A41423.Value)
          (acpFeatureNode[10209] as Motorola.MackinawCPS.CoreFeatures.KeypadMicAndAccessories.DataButtonInnerSection).RadErgoCfgKMConventionalKMDatatButtonIndex_A41423.UIValue = srcField.UIValue;
        if (srcField.Value != (acpFeatureNode[10209] as Motorola.MackinawCPS.CoreFeatures.KeypadMicAndAccessories.DataButtonInnerSection).RadErgoCfgKMTrunkingKMDatatButtonIndex_A41424.Value)
          (acpFeatureNode[10209] as Motorola.MackinawCPS.CoreFeatures.KeypadMicAndAccessories.DataButtonInnerSection).RadErgoCfgKMTrunkingKMDatatButtonIndex_A41424.UIValue = srcField.UIValue;
      }
    }
    if (buttonInnerRecset2 != null)
    {
      foreach (IAcpFeatureNode acpFeatureNode in (Collection<FeatureNode>) buttonInnerRecset2)
      {
        if (srcField.Value != (acpFeatureNode[10212] as Motorola.MackinawCPS.CoreFeatures.ControlHeadO3.DataButtonInnerSection).CHO3DataButtonConvIndex_A41419.Value)
          (acpFeatureNode[10212] as Motorola.MackinawCPS.CoreFeatures.ControlHeadO3.DataButtonInnerSection).CHO3DataButtonConvIndex_A41419.UIValue = srcField.UIValue;
        if (srcField.Value != (acpFeatureNode[10212] as Motorola.MackinawCPS.CoreFeatures.ControlHeadO3.DataButtonInnerSection).CHO3DataButtonTrkIndex_A41420.Value)
          (acpFeatureNode[10212] as Motorola.MackinawCPS.CoreFeatures.ControlHeadO3.DataButtonInnerSection).CHO3DataButtonTrkIndex_A41420.UIValue = srcField.UIValue;
      }
    }
    if (buttonInnerRecset3 != null)
    {
      foreach (IAcpFeatureNode acpFeatureNode in (Collection<FeatureNode>) buttonInnerRecset3)
      {
        if (srcField.Value != (acpFeatureNode[10713] as O7DataButtonInnerSection).CHO7DataButtonConvIndex_A41417.Value)
          (acpFeatureNode[10713] as O7DataButtonInnerSection).CHO7DataButtonConvIndex_A41417.UIValue = srcField.UIValue;
        if (srcField.Value != (acpFeatureNode[10713] as O7DataButtonInnerSection).CHO7DataButtonTrkIndex_A41418.Value)
          (acpFeatureNode[10713] as O7DataButtonInnerSection).CHO7DataButtonTrkIndex_A41418.UIValue = srcField.UIValue;
      }
    }
    if (buttonInnerRecset4 == null)
      return;
    foreach (IAcpFeatureNode acpFeatureNode in (Collection<FeatureNode>) buttonInnerRecset4)
    {
      if (srcField.Value != (acpFeatureNode[10608] as O9DataButtonInnerSection).CHO9DataButtonConvIndex_A41414.Value)
        (acpFeatureNode[10608] as O9DataButtonInnerSection).CHO9DataButtonConvIndex_A41414.UIValue = srcField.UIValue;
      if (srcField.Value != (acpFeatureNode[10608] as O9DataButtonInnerSection).CHO9DataButtonTrkIndex_A41416.Value)
        (acpFeatureNode[10608] as O9DataButtonInnerSection).CHO9DataButtonTrkIndex_A41416.UIValue = srcField.UIValue;
    }
  }

  private void RefreshMaxChangeRecords()
  {
    ConventionalPersonalityRecset feature1 = FeatureManager.GetFeature(2059) as ConventionalPersonalityRecset;
    if (feature1 != null)
    {
      foreach (FeatureNode featureNode in (Collection<FeatureNode>) feature1)
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
      foreach (FeatureNode featureNode in (Collection<FeatureNode>) feature2)
      {
        if (featureNode is Motorola.MackinawCPS.CoreFeatures.ScanList.ScanList scanList && scanList.General.ScanLstGeneralScanType_A9058 != null)
          scanList.General.ScanLstGeneralScanType_A9058.CalculateApplicability();
      }
    }
    if (!(FeatureManager.GetFeature(2064) is TrunkingSystemRecset feature3))
      return;
    foreach (FeatureNode featureNode in (Collection<FeatureNode>) feature3)
    {
      if (featureNode is Motorola.MackinawCPS.CoreFeatures.TrunkingSystem.TrunkingSystem trunkingSystem && trunkingSystem.StatusAlias.TrkSysStatusAliasStatusAliasEnable_A9195 != null)
        trunkingSystem.StatusAlias.TrkSysStatusAliasStatusAliasEnable_A9195.CalculateApplicability();
    }
  }

  private void SyncQC2Code()
  {
    IAcpRecordset feature = FeatureManager.GetFeature(2053);
    if (feature == null)
      return;
    foreach (FeatureNode featureNode in (Collection<FeatureNode>) feature)
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

  private void ResetMotionSensitivityDefaultValue()
  {
    if (!((FeatureManager.GetFeature(2032) as EmergencyWideRecset)[0][10639] is ManDown manDown))
      return;
    manDown.EmerWideManDownMotionlessSensitivity_A40002.SetValue(1);
  }

  public void ResolveUCLReferenceAfterUnpack()
  {
    foreach (IAcpFeatureNode acpFeatureNode1 in (Collection<FeatureNode>) FeatureManager.GetFeature(2200))
    {
      foreach (IAcpRecordset embeddedRecordset in acpFeatureNode1.EmbeddedRecordsets)
      {
        foreach (IAcpFeatureNode acpFeatureNode2 in (Collection<FeatureNode>) embeddedRecordset)
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

  public static void PostUpgradeCodeplugProccessing(string codeplugVersion, string appVersion)
  {
    try
    {
      int num1 = int.Parse(codeplugVersion.Substring(1, 2));
      int num2 = int.Parse(appVersion.Substring(1, 2));
      if (num1 < 3 && num2 > 2 && num2 > num1)
      {
        foreach (Motorola.MackinawCPS.CoreFeatures.DataProfiles.DataProfiles dataProfiles in (Collection<FeatureNode>) (FeatureManager.GetFeature(2054) as DataProfilesRecset))
        {
          dataProfiles.General.DataConfigDataProfRandomHoldOffTime_A36552.Value = dataProfiles.General.DataConfigDataProfRandomHoldOffTime_A36552.DefaultValue;
          DocumentOperations.SetFixedNumRecords(dataProfiles.DAC.EmbeddedRecset as Recordset, 16 /*0x10*/);
          DocumentOperations.SetFixedNumRecords(dataProfiles.TrunkingGroupID.EmbeddedRecset as Recordset, 8);
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

  public static void SetFixedNumRecords(Recordset recordset, int FixedTableRecordNumber)
  {
    recordset.Max = FixedTableRecordNumber;
    recordset.Min = FixedTableRecordNumber;
    while (recordset.Count < FixedTableRecordNumber)
      recordset.AddRecord(recordset.CreateDefaultRecord());
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

  private void expandFlashcode()
  {
    Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation radioInformation = AppInfoManager.AppMode != ApplicationMode.CodeplugComparisonMode ? FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation : AppInfoManager.ComparatorDocument.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation;
    string flasHcodeA8132Value = radioInformation.FLASHport.RadInfoFLASHportFLASHcode_A8132Value;
    string str = "-000000-000000";
    if (flasHcodeA8132Value == null || flasHcodeA8132Value.Length > 15)
      return;
    radioInformation.FLASHport.RadInfoFLASHportFLASHcode_A8132Value = flasHcodeA8132Value + str;
  }

  private void PropertiesChanged()
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

  private void SyncAllControlHeadsNavigationControls()
  {
    int num1 = 135;
    int num2 = 136;
    if (!(FeatureManager.GetFeature(2013) is ShepherdsRecset feature))
      return;
    foreach (IAcpFeatureNode acpFeatureNode1 in (Collection<FeatureNode>) (feature[0][10031].EmbeddedRecset as SignalIndependentProductIndependentNonProgrammableButtonListInnerRecset))
    {
      int num3 = (acpFeatureNode1[10032] as SignalIndependentProductIndependentNonProgrammableButtonListInnerSection).RadErgoCfgSignalIndependentProductIndependentNonProgrammableButtonBCO_A19777.Value;
      if (num3 == num1 || num3 == num2)
      {
        int newValue = (acpFeatureNode1[10032] as SignalIndependentProductIndependentNonProgrammableButtonListInnerSection).RadErgoCfgSignalIndependentProductIndependentNonProgrammableButtonFeature_A19778.Value;
        O2NavigationControlsTableInnerRecset embeddedRecset1 = (FeatureManager.GetFeature(4115) as ControlHeadO2Recset)[0][10722].EmbeddedRecset as O2NavigationControlsTableInnerRecset;
        int num4 = 0;
        foreach (IAcpFeatureNode acpFeatureNode2 in (Collection<FeatureNode>) embeddedRecset1)
        {
          ++num4;
          if ((num3 == num1 && num4 == 1 || num3 == num2 && num4 == 2) && (acpFeatureNode2[10725] as O2NavigationControlsTableInnerSection).RadErgoControlO2UpDownButton_A41278.Value != newValue)
            (acpFeatureNode2[10725] as O2NavigationControlsTableInnerSection).RadErgoControlO2UpDownButton_A41278.SetValue(newValue);
        }
        O3NavigationControlsTableInnerRecset embeddedRecset2 = (FeatureManager.GetFeature(2127) as ControlHeadO3Recset)[0][10732].EmbeddedRecset as O3NavigationControlsTableInnerRecset;
        int num5 = 0;
        foreach (IAcpFeatureNode acpFeatureNode3 in (Collection<FeatureNode>) embeddedRecset2)
        {
          ++num5;
          if ((num3 == num1 && num5 == 1 || num3 == num2 && num5 == 2) && (acpFeatureNode3[10733] as O3NavigationControlsTableInnerSection).RadErgoControlO3NaviControlFeature_A41375.Value != newValue)
            (acpFeatureNode3[10733] as O3NavigationControlsTableInnerSection).RadErgoControlO3NaviControlFeature_A41375.SetValue(newValue);
        }
        O7NavigationControlsTableInnerRecset embeddedRecset3 = (FeatureManager.GetFeature(4114) as ControlHeadO7Recset)[0][10727].EmbeddedRecset as O7NavigationControlsTableInnerRecset;
        int num6 = 0;
        foreach (IAcpFeatureNode acpFeatureNode4 in (Collection<FeatureNode>) embeddedRecset3)
        {
          ++num6;
          if ((num3 == num1 && num6 == 1 || num3 == num2 && num6 == 2) && (acpFeatureNode4[10728] as O7NavigationControlsTableInnerSection).RadErgoControlO7UpDownButton_A41293.Value != newValue)
            (acpFeatureNode4[10728] as O7NavigationControlsTableInnerSection).RadErgoControlO7UpDownButton_A41293.SetValue(newValue);
        }
        O5NavigationControlsTableInnerRecset embeddedRecset4 = (FeatureManager.GetFeature(2130) as ControlHeadO5Recset)[0][10735].EmbeddedRecset as O5NavigationControlsTableInnerRecset;
        int num7 = 0;
        foreach (IAcpFeatureNode acpFeatureNode5 in (Collection<FeatureNode>) embeddedRecset4)
        {
          ++num7;
          if ((num3 == num1 && num7 == 1 || num3 == num2 && num7 == 2) && (acpFeatureNode5[10736] as O5NavigationControlsTableInnerSection).RadErgoControlO5NaviControlFeature_A41379.Value != newValue)
            (acpFeatureNode5[10736] as O5NavigationControlsTableInnerSection).RadErgoControlO5NaviControlFeature_A41379.SetValue(newValue);
        }
        KMANavigationControlsTableInnerRecset embeddedRecset5 = (FeatureManager.GetFeature(2128) as KeypadMicAndAccessoriesRecset)[0][10753].EmbeddedRecset as KMANavigationControlsTableInnerRecset;
        int num8 = 0;
        foreach (IAcpFeatureNode acpFeatureNode6 in (Collection<FeatureNode>) embeddedRecset5)
        {
          ++num8;
          if ((num3 == num1 && num8 == 1 || num3 == num2 && num8 == 2) && (acpFeatureNode6[10754] as KMANavigationControlsTableInnerSection).RadErgoControlKMAUpDownButton_41760.Value != newValue)
            (acpFeatureNode6[10754] as KMANavigationControlsTableInnerSection).RadErgoControlKMAUpDownButton_41760.SetValue(newValue);
        }
        O9NavigationControlsTableInnerRecset embeddedRecset6 = (FeatureManager.GetFeature(4003) as ControlHeadO9Recset)[0][10731].EmbeddedRecset as O9NavigationControlsTableInnerRecset;
        int num9 = 0;
        foreach (IAcpFeatureNode acpFeatureNode7 in (Collection<FeatureNode>) embeddedRecset6)
        {
          ++num9;
          if ((num3 == num1 && num9 == 1 || num3 == num2 && num9 == 2) && (acpFeatureNode7[10734] as O9NavigationControlsTableInnerSection).RadErgoControlO9NaviControlFeature_A41371.Value != newValue)
            (acpFeatureNode7[10734] as O9NavigationControlsTableInnerSection).RadErgoControlO9NaviControlFeature_A41371.SetValue(newValue);
        }
        E5NavigationControlsTableInnerRecset embeddedRecset7 = (FeatureManager.GetFeature(4236) as ControlHeadE5Recset)[0][10896].EmbeddedRecset as E5NavigationControlsTableInnerRecset;
        int num10 = 0;
        foreach (IAcpFeatureNode acpFeatureNode8 in (Collection<FeatureNode>) embeddedRecset7)
        {
          ++num10;
          if ((num3 == num1 && num10 == 1 || num3 == num2 && num10 == 2) && (acpFeatureNode8[10897] as E5NavigationControlsTableInnerSection).RadErgoControlE5UpDownButton_43752.Value != newValue)
            (acpFeatureNode8[10897] as E5NavigationControlsTableInnerSection).RadErgoControlE5UpDownButton_43752.SetValue(newValue);
        }
      }
    }
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

  private void UpdateAuxControlTable()
  {
    foreach (FeatureNode featureNode in (Collection<FeatureNode>) (((FeatureManager.GetFeature(2033) as RadioErgonomicsWideRecset)[0][10633] as AuxControl).EmbeddedRecset as AuxControlTableInnerRecset))
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

  private void DataProfileTrunkingGroupIDFixup()
  {
    int major = this.CodeplugVersion.Major;
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
          if (groupIdListInner != null && major <= 2 && groupIdListInner.TrunkingGroupIDListInnerSection.DataProfilesTrunkingGroupID_ASTRO25DataGroupID_A36204Value == groupIdListInner.TrunkingGroupIDListInnerSection.DataProfilesTrunkingGroupID_ASTRO25DataGroupID_A36204.DefaultValue)
            groupIdListInner.TrunkingGroupIDListInnerSection.DataProfilesTrunkingGroupID_ASTRO25DataGroupID_A36204.SetValue(groupIdListInner.TrunkingGroupIDListInnerSection.DataProfilesTrunkingGroupID_ASTRO25DataGroupID_A36204.DefaultValue + index2);
        }
      }
    }
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
    for (int index = 0; index < feature1.Count && index != 15; ++index)
    {
      if ((feature1[index] as Motorola.MackinawCPS.CoreFeatures.ZoneChannelAssignment.ZoneChannelAssignment).Zone.ZnChanCfgZoneZoneCloningEnable_43119.Value)
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
          Task.AddTask((UndoableTask) new ChangePermissionsTask((IAcpFeatureNode) featureNode1, Permissions.DragDisabled | Permissions.DropBeforeDisabled | Permissions.InsertBeforeDisabeled));
        }
        else
        {
          feature2[0].Permissions = newValue;
          feature2.Min = 2;
          featureNode1.Permissions = Permissions.DragDisabled | Permissions.DropBeforeDisabled | Permissions.InsertBeforeDisabeled;
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
    int num1 = -1;
    for (int index1 = 0; index1 < feature1.Count; ++index1)
    {
      if ((feature1[index1] as Motorola.MackinawCPS.CoreFeatures.ZoneChannelAssignment.ZoneChannelAssignment).Zone.ZnChanCfgZoneZoneCloningEnable_43119.Value)
      {
        num1 = index1;
        Permissions newValue1 = Permissions.Undeletable | Permissions.DragDisabled | Permissions.DropBeforeDisabled | Permissions.InsertBeforeDisabeled | Permissions.RefernceDisabled | Permissions.CopyDisabled | Permissions.AddCurrentDisabled;
        if (Task != null)
          Task.AddTask((UndoableTask) new ChangePermissionsTask(feature1[index1], newValue1));
        else
          feature1[index1].Permissions = newValue1;
        if ((feature1[index1] as Motorola.MackinawCPS.CoreFeatures.ZoneChannelAssignment.ZoneChannelAssignment).Channels.EmbeddedRecset is ChannelAssignmentListInnerRecset embeddedRecset1)
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
              FeatureNode referencedNode = featureNode2.ChannelAssignmentListInnerSection.ZnChanCfgChannelsPersonality_A8698.ReferencedNode;
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
    if (num1 >= -1)
    {
      int newValue = 1 + (num1 + 1) * 16 /*0x10*/;
      if (Task != null)
        Task.AddTask((UndoableTask) new ChangeMinTask(FeatureManager.GetFeature(2059), newValue));
      else
        ConventionalPersonalityRecset._Min = newValue;
    }
    if (!flag1)
      return;
    if (!(FeatureManager.GetFeature(2051) is ZoneChannelAssignmentRecset feature6))
      return;
    int num2 = 0;
    foreach (IAcpFeatureNode acpFeatureNode in (Collection<FeatureNode>) feature6)
    {
      ++num2;
      if (num2 > 15)
        break;
      if (acpFeatureNode != null && (acpFeatureNode as Motorola.MackinawCPS.CoreFeatures.ZoneChannelAssignment.ZoneChannelAssignment).Zone != null && (acpFeatureNode as Motorola.MackinawCPS.CoreFeatures.ZoneChannelAssignment.ZoneChannelAssignment).Zone.ZnChanCfgZoneZoneCloningEnable_43119 != null)
      {
        (acpFeatureNode as Motorola.MackinawCPS.CoreFeatures.ZoneChannelAssignment.ZoneChannelAssignment).Zone.ZnChanCfgZoneZoneCloningEnable_43119.CallConstraints();
        break;
      }
    }
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
    {
      embeddedRecset.AddRecord(embeddedRecset.CreateDefaultRecord());
      embeddedRecset[embeddedRecset.Count - 1].RepairRecRefs();
    }
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
    foreach (BottomFunctionButtonBCOListInner buttonBcoListInner in (Collection<FeatureNode>) embeddedRecset2)
    {
      if (buttonBcoListInner.BottomFunctionButtonBCOListInnerSection.CHO9BottomFunctionButtonBCO_A36827.Value == functionButtonBco43757.Value)
      {
        buttonInnerSection.E5BottomFunctionButtonFeature_43758.Value = buttonBcoListInner.BottomFunctionButtonBCOListInnerSection.CHO9BottomFunctionButtonFeature_A36826.Value;
        break;
      }
    }
  }
}
