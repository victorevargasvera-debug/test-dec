// Decompiled with JetBrains decompiler
// Type: MackinawCPS.MackCPSDocument
// Assembly: APXFamilyCPS, Version=15.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 7983BD42-76AB-479D-8966-B7B635E0E28A
// Assembly location: C:\Program Files (x86)\Motorola\APX Dpt 25\APXFamilyCPS.exe

using AcpBusinessLayer;
using AcpCommonLib;
using CommonResources;
using Motorola.MackinawCPS.CoreFeatures.ActionConsolidation;
using Motorola.MackinawCPS.CoreFeatures.Buttons;
using Motorola.MackinawCPS.CoreFeatures.ControlHeadO2;
using Motorola.MackinawCPS.CoreFeatures.ControlHeadO3;
using Motorola.MackinawCPS.CoreFeatures.ControlHeadO5;
using Motorola.MackinawCPS.CoreFeatures.ControlHeadO7;
using Motorola.MackinawCPS.CoreFeatures.ControlHeadO9;
using Motorola.MackinawCPS.CoreFeatures.ConventionalEmergencyProfiles;
using Motorola.MackinawCPS.CoreFeatures.ConventionalPersonality;
using Motorola.MackinawCPS.CoreFeatures.ConventionalSystem;
using Motorola.MackinawCPS.CoreFeatures.DataProfiles;
using Motorola.MackinawCPS.CoreFeatures.DataWide;
using Motorola.MackinawCPS.CoreFeatures.DEK;
using Motorola.MackinawCPS.CoreFeatures.DVRSProfiles;
using Motorola.MackinawCPS.CoreFeatures.DVRSWide;
using Motorola.MackinawCPS.CoreFeatures.EmergencyWide;
using Motorola.MackinawCPS.CoreFeatures.EnhancedDataPortList;
using Motorola.MackinawCPS.CoreFeatures.FactoryOverrides;
using Motorola.MackinawCPS.CoreFeatures.GlobalNoiseReductionList;
using Motorola.MackinawCPS.CoreFeatures.Keypad;
using Motorola.MackinawCPS.CoreFeatures.KeypadMicAndAccessories;
using Motorola.MackinawCPS.CoreFeatures.MissionCriticalGeofence;
using Motorola.MackinawCPS.CoreFeatures.PersonnelAccountability;
using Motorola.MackinawCPS.CoreFeatures.RadioErgonomicsWide;
using Motorola.MackinawCPS.CoreFeatures.RadioInformation;
using Motorola.MackinawCPS.CoreFeatures.RadioVIPs;
using Motorola.MackinawCPS.CoreFeatures.RadioWide;
using Motorola.MackinawCPS.CoreFeatures.RemoteSpeakerMic;
using Motorola.MackinawCPS.CoreFeatures.SmartKeyFob;
using Motorola.MackinawCPS.CoreFeatures.Switches;
using Motorola.MackinawCPS.CoreFeatures.ToneSignalingList;
using Motorola.MackinawCPS.CoreFeatures.TrunkingEmergencyProfiles;
using Motorola.MackinawCPS.CoreFeatures.ZoneChannelAssignment;
using SpecialFeatures.VoiceAnnouncements.List;
using SpecialFeatures.VoiceAnnouncements.SiteSelectableAlertList;
using SpecialFeatures.VoiceAnnouncements.Wide;
using System.Collections.ObjectModel;

#nullable disable
namespace MackinawCPS;

public class MackCPSDocument : AcpDocument
{
  internal MackCPSDocument()
  {
  }

  internal void resetDirty() => this.IsDirty = false;

  protected override void AddNewFeatures(string codeplugVersion)
  {
    if (this.GetFeature(2300) == null)
      FeatureManager.AddFeature((IAcpRecordset) new VoiceAnnouncementListRecSet());
    if (this.GetFeature(4145) == null)
      FeatureManager.AddFeature((IAcpRecordset) new SiteSelectableAlertListRecset());
    if (this.GetFeature(2301) == null)
      FeatureManager.AddFeature((IAcpRecordset) new VoiceAnnouncementWideRecSet());
    if (this.GetFeature(2125) == null)
      FeatureManager.AddFeature((IAcpRecordset) new RadioVIPsRecset());
    IAcpRecordset feature1 = this.GetFeature(2003);
    if (feature1 == null)
    {
      FeatureManager.AddFeature((IAcpRecordset) new FactoryOverridesRecset());
    }
    else
    {
      foreach (FeatureNode parent in (Collection<FeatureNode>) feature1)
      {
        if (parent is Motorola.MackinawCPS.CoreFeatures.FactoryOverrides.FactoryOverrides)
        {
          if (parent[10791] == null)
            parent.AddFeatureSection((IAcpFeatureSection) new RxSSIClockRateList(parent));
          if (parent[10801] == null)
            parent.AddFeatureSection((IAcpFeatureSection) new RxSSIRateTXMode(parent));
        }
      }
    }
    IAcpRecordset feature2 = this.GetFeature(2127);
    if (feature2 == null)
    {
      FeatureManager.AddFeature((IAcpRecordset) new ControlHeadO3Recset());
    }
    else
    {
      foreach (FeatureNode parent in (Collection<FeatureNode>) feature2)
      {
        if (parent is Motorola.MackinawCPS.CoreFeatures.ControlHeadO3.ControlHeadO3 && parent[10732] == null)
          parent.AddFeatureSection((IAcpFeatureSection) new O3NavigationControlsExpander(parent));
      }
    }
    if (this.GetFeature(4109) == null)
      FeatureManager.AddFeature((IAcpRecordset) new KeypadRecset());
    IAcpRecordset feature3 = this.GetFeature(2128);
    if (feature3 == null)
    {
      FeatureManager.AddFeature((IAcpRecordset) new KeypadMicAndAccessoriesRecset());
    }
    else
    {
      foreach (FeatureNode parent in (Collection<FeatureNode>) feature3)
      {
        if (parent is Motorola.MackinawCPS.CoreFeatures.KeypadMicAndAccessories.KeypadMicAndAccessories && parent[10753] == null)
          parent.AddFeatureSection((IAcpFeatureSection) new KMANavigationControlsExpander(parent));
      }
    }
    if (this.GetFeature(2129) == null)
      FeatureManager.AddFeature((IAcpRecordset) new DEKRecset());
    IAcpRecordset feature4 = this.GetFeature(2130);
    if (feature4 == null)
    {
      FeatureManager.AddFeature((IAcpRecordset) new ControlHeadO5Recset());
    }
    else
    {
      foreach (FeatureNode parent in (Collection<FeatureNode>) feature4)
      {
        if (parent is Motorola.MackinawCPS.CoreFeatures.ControlHeadO5.ControlHeadO5 && parent[10735] == null)
          parent.AddFeatureSection((IAcpFeatureSection) new O5NavigationControlsExpander(parent));
      }
    }
    if (this.GetFeature(2131) == null)
      FeatureManager.AddFeature((IAcpRecordset) new GlobalNoiseReductionListRecset());
    if (this.GetFeature(4176) == null)
      FeatureManager.AddFeature((IAcpRecordset) new PersonnelAccountabilityRecset());
    if (this.GetFeature(4008) == null)
      FeatureManager.AddFeature((IAcpRecordset) new ActionConsolidationRecset());
    IAcpRecordset feature5 = this.GetFeature(4003);
    if (feature5 == null)
    {
      FeatureManager.AddFeature((IAcpRecordset) new ControlHeadO9Recset());
    }
    else
    {
      foreach (FeatureNode parent in (Collection<FeatureNode>) feature5)
      {
        if (parent is Motorola.MackinawCPS.CoreFeatures.ControlHeadO9.ControlHeadO9)
        {
          if (parent[10731] == null)
            parent.AddFeatureSection((IAcpFeatureSection) new O9NavigationControlsExpander(parent));
          if (parent[10743] == null)
            parent.AddFeatureSection((IAcpFeatureSection) new PASirenButtons(parent));
        }
      }
    }
    if (this.GetFeature(4115) == null)
      FeatureManager.AddFeature((IAcpRecordset) new ControlHeadO2Recset());
    if (this.GetFeature(4114) == null)
      FeatureManager.AddFeature((IAcpRecordset) new ControlHeadO7Recset());
    IAcpRecordset feature6 = this.GetFeature(2033);
    if (feature6 == null)
    {
      FeatureManager.AddFeature((IAcpRecordset) new RadioErgonomicsWideRecset());
    }
    else
    {
      foreach (FeatureNode parent in (Collection<FeatureNode>) feature6)
      {
        if (parent is Motorola.MackinawCPS.CoreFeatures.RadioErgonomicsWide.RadioErgonomicsWide)
        {
          if (parent[10603] == null)
            parent.AddFeatureSection((IAcpFeatureSection) new Stealth(parent));
          if (parent[10640] == null)
            parent.AddFeatureSection((IAcpFeatureSection) new PresetZoneAndChannel(parent));
        }
      }
    }
    if (this.GetFeature(4174) == null)
      FeatureManager.AddFeature((IAcpRecordset) new MissionCriticalGeofenceRecset());
    if (this.GetFeature(4156) == null)
      FeatureManager.AddFeature((IAcpRecordset) new ToneSignalingListRecset());
    IAcpRecordset feature7 = this.GetFeature(2038);
    if (feature7 == null)
    {
      FeatureManager.AddFeature((IAcpRecordset) new SwitchesRecset());
    }
    else
    {
      foreach (FeatureNode parent in (Collection<FeatureNode>) feature7)
      {
        if (parent is Motorola.MackinawCPS.CoreFeatures.Switches.Switches && parent[10637] == null)
          parent.AddFeatureSection((IAcpFeatureSection) new MultiFunctionKnob(parent));
      }
    }
    IAcpRecordset feature8 = this.GetFeature(2049);
    if (feature8 == null)
    {
      FeatureManager.AddFeature((IAcpRecordset) new RadioInformationRecset());
    }
    else
    {
      foreach (FeatureNode parent in (Collection<FeatureNode>) feature8)
      {
        if (parent is Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation && parent[10803] == null)
          parent.AddFeatureSection((IAcpFeatureSection) new DepotKeyInfo(parent));
      }
    }
    IAcpRecordset feature9 = this.GetFeature(2045);
    if (feature9 == null)
    {
      FeatureManager.AddFeature((IAcpRecordset) new RadioWideRecset());
    }
    else
    {
      foreach (FeatureNode parent in (Collection<FeatureNode>) feature9)
      {
        if (parent is Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide)
        {
          if (parent[10604] == null)
            parent.AddFeatureSection((IAcpFeatureSection) new LightbarPattern(parent));
          if (parent[10606] == null)
            parent.AddFeatureSection((IAcpFeatureSection) new GunLock(parent));
          if (parent[10636] == null)
            parent.AddFeatureSection((IAcpFeatureSection) new FCCNarrowBandingFrequencySplit(parent));
          if (parent[10772] == null)
            parent.AddFeatureSection((IAcpFeatureSection) new Motorola.MackinawCPS.CoreFeatures.RadioWide.LTE(parent));
          if (parent[10784] == null)
            parent.AddFeatureSection((IAcpFeatureSection) new DualRadio(parent));
        }
      }
    }
    IAcpRecordset feature10 = this.GetFeature(2028);
    if (feature10 == null)
    {
      FeatureManager.AddFeature((IAcpRecordset) new DataWideRecset());
    }
    else
    {
      foreach (FeatureNode parent in (Collection<FeatureNode>) feature10)
      {
        if (parent is Motorola.MackinawCPS.CoreFeatures.DataWide.DataWide)
        {
          if (parent[10503] == null)
            parent.AddFeatureSection((IAcpFeatureSection) new DataProtocolConfiguration(parent));
          if (parent[10632] == null)
            parent.AddFeatureSection((IAcpFeatureSection) new PortConfiguration(parent));
          if (parent[10782] == null)
            parent.AddFeatureSection((IAcpFeatureSection) new Motorola.MackinawCPS.CoreFeatures.DataWide.LTE(parent));
          if (parent[10793] == null)
            parent.AddFeatureSection((IAcpFeatureSection) new WIFI(parent));
          if (parent[10807] == null)
            parent.AddFeatureSection((IAcpFeatureSection) new ExternalDataModem(parent));
        }
      }
    }
    IAcpRecordset feature11 = this.GetFeature(2054);
    if (feature11 == null)
    {
      FeatureManager.AddFeature((IAcpRecordset) new DataProfilesRecset());
    }
    else
    {
      foreach (FeatureNode parent in (Collection<FeatureNode>) feature11)
      {
        if (parent is Motorola.MackinawCPS.CoreFeatures.DataProfiles.DataProfiles)
        {
          if (parent[10504] == null)
            parent.AddFeatureSection((IAcpFeatureSection) new DAC(parent));
          if (parent[10505] == null)
            parent.AddFeatureSection((IAcpFeatureSection) new TrunkingGroupID(parent));
          if (parent[10770] == null)
            parent.AddFeatureSection((IAcpFeatureSection) new EnhancedData(parent));
          if (parent[10773] == null)
            parent.AddFeatureSection((IAcpFeatureSection) new Motorola.MackinawCPS.CoreFeatures.DataProfiles.LTE(parent));
        }
      }
    }
    if (this.GetFeature(4148) == null)
      FeatureManager.AddFeature((IAcpRecordset) new EnhancedDataPortListRecset());
    if (this.GetFeature(4142) == null)
      FeatureManager.AddFeature((IAcpRecordset) new DVRSWideRecset());
    if (this.GetFeature(4143) == null)
      FeatureManager.AddFeature((IAcpRecordset) new DVRSProfilesRecset());
    IAcpRecordset feature12 = this.GetFeature(2053);
    if (feature12 == null)
    {
      FeatureManager.AddFeature((IAcpRecordset) new ConventionalSystemRecset());
    }
    else
    {
      foreach (FeatureNode parent in (Collection<FeatureNode>) feature12)
      {
        if (parent is Motorola.MackinawCPS.CoreFeatures.ConventionalSystem.ConventionalSystem)
        {
          if (parent[10643] == null)
            parent.AddFeatureSection((IAcpFeatureSection) new Motorola.MackinawCPS.CoreFeatures.ConventionalSystem.DVRS(parent));
          if (parent[10644] == null)
            parent.AddFeatureSection((IAcpFeatureSection) new Motorola.MackinawCPS.CoreFeatures.ConventionalSystem.Secure(parent));
          if (parent[10785] == null)
            parent.AddFeatureSection((IAcpFeatureSection) new QuikCallII(parent));
        }
      }
    }
    IAcpRecordset feature13 = this.GetFeature(2059);
    if (feature13 == null)
    {
      FeatureManager.AddFeature((IAcpRecordset) new ConventionalPersonalityRecset());
    }
    else
    {
      foreach (FeatureNode parent in (Collection<FeatureNode>) feature13)
      {
        if (parent is Motorola.MackinawCPS.CoreFeatures.ConventionalPersonality.ConventionalPersonality && parent[10642] == null)
          parent.AddFeatureSection((IAcpFeatureSection) new Motorola.MackinawCPS.CoreFeatures.ConventionalPersonality.DVRS(parent));
      }
    }
    if (this.GetFeature(2036)[0] is Motorola.MackinawCPS.CoreFeatures.RemoteSpeakerMic.RemoteSpeakerMic remoteSpeakerMic)
    {
      IAcpRecordset embeddedRecset = remoteSpeakerMic.General.EmbeddedRecset;
      int num = 0;
      foreach (FeatureNode featureNode in (Collection<FeatureNode>) embeddedRecset)
      {
        ++num;
        if (featureNode is RSMButtonInner rsmButtonInner && rsmButtonInner.RSMButtonInnerSection.RadErgoCfgRSMButtonKey_A22526.Value.Length > 14)
          rsmButtonInner.RSMButtonInnerSection.RadErgoCfgRSMButtonKey_A22526.Value = AppResources.Accessory_Id + num.ToString();
      }
    }
    IAcpRecordset feature14 = this.GetFeature(2051);
    if (feature14 == null)
    {
      FeatureManager.AddFeature((IAcpRecordset) new ZoneChannelAssignmentRecset());
    }
    else
    {
      foreach (FeatureNode parent in (Collection<FeatureNode>) feature14)
      {
        if (parent is Motorola.MackinawCPS.CoreFeatures.ZoneChannelAssignment.ZoneChannelAssignment)
        {
          if (parent[10711] == null)
            parent.AddFeatureSection((IAcpFeatureSection) new Motorola.MackinawCPS.CoreFeatures.ZoneChannelAssignment.Labtool(parent));
          if (parent[10760] == null)
            parent.AddFeatureSection((IAcpFeatureSection) new RSI(parent));
        }
      }
    }
    IAcpRecordset feature15 = this.GetFeature(2032);
    if (feature15 == null)
    {
      FeatureManager.AddFeature((IAcpRecordset) new EmergencyWideRecset());
    }
    else
    {
      foreach (FeatureNode parent in (Collection<FeatureNode>) feature15)
      {
        if (parent is Motorola.MackinawCPS.CoreFeatures.EmergencyWide.EmergencyWide)
        {
          if (parent[10639] == null)
            parent.AddFeatureSection((IAcpFeatureSection) new ManDown(parent));
          if (parent[10778] == null)
            parent.AddFeatureSection((IAcpFeatureSection) new EmergencyToneTrigger(parent));
        }
      }
    }
    IAcpRecordset feature16 = this.GetFeature(2075);
    if (feature16 == null)
    {
      FeatureManager.AddFeature((IAcpRecordset) new ConventionalEmergencyProfilesRecset());
    }
    else
    {
      foreach (FeatureNode parent in (Collection<FeatureNode>) feature16)
      {
        if (parent is Motorola.MackinawCPS.CoreFeatures.ConventionalEmergencyProfiles.ConventionalEmergencyProfiles)
        {
          if (parent[10771] == null)
            parent.AddFeatureSection((IAcpFeatureSection) new EmergencyToneList(parent));
          if (parent[10777] == null)
            parent.AddFeatureSection((IAcpFeatureSection) new Motorola.MackinawCPS.CoreFeatures.ConventionalEmergencyProfiles.Labtool(parent));
        }
      }
    }
    IAcpRecordset feature17 = this.GetFeature(2076);
    if (feature17 == null)
    {
      FeatureManager.AddFeature((IAcpRecordset) new TrunkingEmergencyProfilesRecset());
    }
    else
    {
      foreach (FeatureNode parent in (Collection<FeatureNode>) feature17)
      {
        if (parent is Motorola.MackinawCPS.CoreFeatures.TrunkingEmergencyProfiles.TrunkingEmergencyProfiles && parent[10775] == null)
          parent.AddFeatureSection((IAcpFeatureSection) new TrunkingEmergencyToneList(parent));
      }
    }
    IAcpRecordset feature18 = this.GetFeature(2045);
    if (feature18 == null)
    {
      FeatureManager.AddFeature((IAcpRecordset) new RadioWideRecset());
    }
    else
    {
      foreach (FeatureNode parent in (Collection<FeatureNode>) feature18)
      {
        if (parent is Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide)
        {
          if (parent[10750] == null)
            parent.AddFeatureSection((IAcpFeatureSection) new Fireground(parent));
          if (parent[10749] == null)
            parent.AddFeatureSection((IAcpFeatureSection) new TPS(parent));
          if (parent[10761] == null)
            parent.AddFeatureSection((IAcpFeatureSection) new TxPowerLevelsNewBandPlan(parent));
        }
      }
    }
    if (this.GetFeature(4130) == null)
      FeatureManager.AddFeature((IAcpRecordset) new SmartKeyFobRecset());
    IAcpRecordset feature19 = this.GetFeature(2042);
    if (feature19 == null)
    {
      FeatureManager.AddFeature((IAcpRecordset) new ButtonsRecset());
    }
    else
    {
      foreach (FeatureNode parent in (Collection<FeatureNode>) feature19)
      {
        if (parent is Motorola.MackinawCPS.CoreFeatures.Buttons.Buttons && parent[10745] == null)
          parent.AddFeatureSection((IAcpFeatureSection) new SideArrowButtons(parent));
      }
    }
    IAcpRecordset feature20 = this.GetFeature(2125);
    if (feature20 == null)
    {
      FeatureManager.AddFeature((IAcpRecordset) new RadioVIPsRecset());
    }
    else
    {
      foreach (FeatureNode parent in (Collection<FeatureNode>) feature20)
      {
        if (parent is Motorola.MackinawCPS.CoreFeatures.RadioVIPs.RadioVIPs && parent[10797] == null)
          parent.AddFeatureSection((IAcpFeatureSection) new GCAI(parent));
      }
    }
  }
}
