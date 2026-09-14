// Decompiled with JetBrains decompiler
// Type: MackinawCPS.CommonUtility
// Assembly: APXFamilyCPS, Version=15.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 7983BD42-76AB-479D-8966-B7B635E0E28A
// Assembly location: C:\Program Files (x86)\Motorola\APX Dpt 25\APXFamilyCPS.exe

using AcpBusinessLayer;
using AcpCommonLib;
using ConstraintHelper;
using MackinawCPS.CommandLineCPS;
using Motorola.CommonCPS.RadioManagement.SharedServices;
using Motorola.CommonCPS.Server.EntityModel;
using Motorola.CommonCPS.Server.EntityModel.GenericModel;
using Motorola.MackinawCPS.CoreFeatures.DataWide;
using SpecialFeatures.Clone_Configuration.Common;
using SpecialFeatures.Flashport.FlashRadio;
using SpecialFeatures.RadioFeatureSet;
using SpecialFeatures.ReadWritePassword;
using SpecialFeatures.Security;
using SpecialFeatures.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;

#nullable disable
namespace MackinawCPS;

public static class CommonUtility
{
  internal static void PopulatecpAndDeviceColumnsFromDatabaseLayer(
    APXCodeplug cp,
    Radio dev,
    PopulateOpeartion operation)
  {
    try
    {
      Motorola.MackinawCPS.CoreFeatures.SecureWide.SecureWide secureWide = FeatureManager.GetFeature(2021)[0] as Motorola.MackinawCPS.CoreFeatures.SecureWide.SecureWide;
      Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide radioWide = FeatureManager.GetFeature(2045)[0] as Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide;
      Motorola.MackinawCPS.CoreFeatures.DataWide.DataWide dataWide = FeatureManager.GetFeature(2028)[0] as Motorola.MackinawCPS.CoreFeatures.DataWide.DataWide;
      cp.OtarID = new int?(secureWide.ASTROOTAR.SecWideASTROOTARIndividualASTROOTARRadioID_A8284.Value);
      cp.PeerIP = dataWide.General.DataWideGeneralPeerIPAddress1_A8524.UIValue;
      cp.SubscriberIP = dataWide.General.DataWideGeneralSubscriberIPAddress1_A9222.UIValue;
      cp.PeerIP_A41818 = dataWide.General.DataWideGeneralDVRIPAddress_A41818.UIValue;
      cp.SubscriberIP_A41819 = dataWide.General.DataWideGeneralMobileSubIPAddress_A41819.UIValue;
      cp.BluetoothFriendlyName = radioWide.Bluetooth.RadWideBluetoothFriendlyName_A41181.Value == null ? (string) null : radioWide.Bluetooth.RadWideBluetoothFriendlyName_A41181.Value.Trim();
      cp.BluetoothDUNPeerIP = dataWide.General.DataWideGeneralBTDUNPeerIPAddress_A41123.UIValue;
      cp.BluetoothDUNSubscriberIP = dataWide.General.DataWideGeneralBTDUNSUIPAddress_A41120.UIValue;
      cp.BluetoothPANNetworkBaseAddress = radioWide.Bluetooth.RadWideBluetoothBluetoothPANNetworkAddress_41983.UIValue;
      switch (dataWide.General.DataWideGeneralBTDUNPeerIPAddressAssignmentType_A41124.Value)
      {
        case 0:
          cp.BluetoothDunPeerIpAssignmentType = new int?(0);
          break;
        case 1:
          cp.BluetoothDunPeerIpAssignmentType = new int?(1);
          break;
      }
      Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation radioInformation = FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation;
      cp.CodeplugVersion = radioInformation.General.RadInfoGeneralCodeplugVersion_A7683.Value;
      string flasHcodeA8132Value = radioInformation.FLASHport.RadInfoFLASHportFLASHcode_A8132Value;
      byte[] decoded1 = new byte[0];
      FlashcodeDecoder.Decode(flasHcodeA8132Value, ref decoded1);
      cp.AstroPurchasedFlashCode = decoded1;
      string usedFcodeValue = FeatureSetConstraints.getUsedFcodeValue();
      byte[] decoded2 = new byte[0];
      FlashcodeDecoder.Decode(usedFcodeValue, ref decoded2);
      cp.AstroEnableFlashCode = decoded2;
      cp.UserName = radioWide.UserInformationAndPasswords.RadWideUserInformationandPasswordsSoftIDUsername_A9169.Value == null ? (string) null : radioWide.UserInformationAndPasswords.RadWideUserInformationandPasswordsSoftIDUsername_A9169.Value.Trim();
      cp.RadioAlias = radioWide.UserInformationAndPasswords.RadWideUserInformationandPasswordsRadioAlias_A8829.Value == null ? (string) null : radioWide.UserInformationAndPasswords.RadWideUserInformationandPasswordsRadioAlias_A8829.Value.Trim();
      if (operation != PopulateOpeartion.Write)
      {
        cp.UserPIN = radioWide.UserInformationAndPasswords.RadWideUserInformationandPINPassword_41303Value;
        if (cp.APXDataProfiles == null)
          cp.APXDataProfiles = new List<APXDataProfile>();
        else
          cp.APXDataProfiles.Clear();
        APXDataProfile[] profiles = CommonUtility.PopulateDataProfiles();
        int num1 = 1;
        if (profiles != null)
        {
          foreach (APXDataProfile apxDataProfile in profiles)
          {
            apxDataProfile.OrderId = new int?(num1);
            cp.APXDataProfiles.Add(apxDataProfile);
            ++num1;
          }
        }
        CommonUtility.PopulateDataProfilesFromCodeplug(profiles, cp.Template);
        if (cp.APXRadioSystems == null)
          cp.APXRadioSystems = new List<APXRadioSystem>();
        else
          cp.APXRadioSystems.Clear();
        APXRadioSystem[] systems = CommonUtility.PopulateSystems();
        int num2 = 1;
        foreach (APXRadioSystem apxRadioSystem in systems)
        {
          apxRadioSystem.OrderId = new int?(num2);
          cp.APXRadioSystems.Add(apxRadioSystem);
          ++num2;
        }
        CommonUtility.PopulateRadioSystemsFromCodeplug(systems, cp.Template);
        CommonUtility.PopulateWiFiNetworksFromCodeplug(CommonUtility.PopulateWiFiNetworks(), cp.Template);
      }
      if (operation == PopulateOpeartion.Import || operation == PopulateOpeartion.Read)
        cp.FirmwareVersion = radioInformation.General.RadInfoGeneralFirmwareVersion_A8124.Value;
      cp.CodeplugVersion = radioInformation.General.RadInfoGeneralCodeplugVersion_A7683.Value;
      CommonUtility.PopulateTemplateColumnsHelper((APXTemplate) cp.Template);
      if (radioInformation.Tracking.RadInfoLabtoolLastProgrammedDateDBValue_A8411.Value != 0L)
      {
        try
        {
          if (CultureInfo.CurrentCulture.Name.ToLower() == "he")
          {
            string s = radioInformation.Tracking.RadInfoLabtoolLastProgrammedDateDBValue_A8411.UIValue;
            int startIndex;
            while ((startIndex = s.IndexOf('\u200E')) >= 0)
              s = s.Remove(startIndex, 1);
            cp.LastProgrammedDate = new DateTime?(DateTime.Parse(s));
          }
          else
            cp.LastProgrammedDate = new DateTime?(DateTime.Parse(radioInformation.Tracking.RadInfoLabtoolLastProgrammedDateDBValue_A8411.UIValue));
        }
        catch
        {
        }
      }
      cp.HomeSystemId = new int?(radioWide.General.RadWideGeneralOwnerSystemID_A37153.Value);
      cp.DisableWriteProtect = new bool?(radioWide.Depot.AdvancedExternalMicOnly.Value);
      cp.RadioInhibitedTrunking = new bool?(radioWide.Labtool.TrunkingRadioInhibited_A19483.Value);
      cp.OwnerAdvKeyType = new int?(radioWide.General.RadWideGeneralOwnerAdvancedKeyType_A38663.Value);
      cp.OwnerWacnId = new int?(radioWide.General.RadWideGeneralOwnerWACNID_A38656.Value);
      cp.AskRequired = new bool?(radioWide.General.RadWideGeneralASKRequired_A37152.Value);
      cp.AllowInvalidFrequency = new bool?(radioInformation.FrequencyRanges.RadInfoFrequencyRangesAllowInvalidFrequencies_A12493.Value);
      cp.RecSetCounts = AstroRecSetCounts.PopulateAstroRecSetCounts();
      cp.AstroSysKeyLog = RMUtilities.PopulateAstroSysKeyLog();
      cp.BluetoothEnable = new bool?(radioWide.Bluetooth.RadWideBluetoothBluetoothEnable_A37028.Value);
      cp.LocationEnable = new bool?(radioWide.Location.RadWideLocationLocationEnable_A8448.Value);
      cp.P25LocationReporting = new bool?(radioWide.Location.RadWideLocP25LocationReporting_42412.Value);
      cp.OtarEnable = new bool?(secureWide.General.SecWideGeneralOTAREnable_A7966.Value);
      cp.AstroOtarEnable = new bool?(secureWide.ASTROOTAR.SecWideASTROOTARASTROOTAREnable_A7496.Value);
      cp.RadioAliasEnable = new bool?(radioWide.UserInformationAndPasswords.RadWideUserInformationandPasswordsRadioAliasEnable_A8830.Value);
      switch (secureWide.General.SecWideGeneralSecureOperation_A9067.Value)
      {
        case 0:
          cp.SecureOperation = new int?(0);
          break;
        case 1:
          cp.SecureOperation = new int?(1);
          break;
        case 3:
          cp.SecureOperation = new int?(2);
          break;
      }
      cp.UserLoginUnitID = radioWide.UserInformationAndPasswords.RadWideUserInformationandUserLoginUnitID_41306.Value == null ? (string) null : radioWide.UserInformationAndPasswords.RadWideUserInformationandUserLoginUnitID_41306.Value.Trim();
      cp.UserLoginUnitIDEnable = new bool?(radioWide.UserInformationAndPasswords.RadWideUserInformationandUserLoginUnitIDEnable_41305.Value);
      cp.UserLoginUnitIDTextSize = new int?(radioWide.UserInformationAndPasswords.RadWideUserInformationandUserLoginUnitIDTextSize_41309.Value);
      cp.UserNameDisplayTextSize = new int?(radioWide.UserInformationAndPasswords.RadWideUserInformationandPasswordsSoftIDUsernameDisplayTextSize_A23453.Value);
      MultipleFieldsXML multipleFieldsXml = new MultipleFieldsXML();
      NameAndValue nameAndValue1 = new NameAndValue("RadInfoGeneralDSPVersion_A7892", (object) radioInformation.General.RadInfoGeneralDSPVersion_A7892.Value);
      NameAndValue nameAndValue2 = new NameAndValue("RadInfoGeneralSecureHardwareType", (object) radioInformation.General.RadInfoGeneralSecureHardwareType.Value);
      NameAndValue nameAndValue3 = new NameAndValue("RadInfoGeneralSecureHardwareVersion", (object) radioInformation.General.RadInfoGeneralSecureHardwareVersion.Value);
      NameAndValue nameAndValue4 = new NameAndValue("RadInfoGeneralUCMVersion_A9591", (object) radioInformation.General.RadInfoGeneralUCMVersion_A9591.Value);
      NameAndValue nameAndValue5 = new NameAndValue("RadInfoGeneralBootloaderVersion_A7567", (object) radioInformation.General.RadInfoGeneralBootloaderVersion_A7567.Value);
      NameAndValue nameAndValue6 = new NameAndValue("RadInfoGeneralTuningVersion_A9509", (object) radioInformation.General.RadInfoGeneralTuningVersion_A9509.Value);
      NameAndValue nameAndValue7 = new NameAndValue("RadInfoGeneralPSDTVersion_A8768", (object) radioInformation.General.RadInfoGeneralPSDTVersion_A8768.Value);
      NameAndValue nameAndValue8 = new NameAndValue("RadInfoOptionExpansionBoardBoardName_A37549", (object) radioInformation.OptionExpansionBoard.RadInfoOptionExpansionBoardBoardName_A37549.Value);
      NameAndValue nameAndValue9 = new NameAndValue("RadInfoOptionExpansionBoardBoardFirmwareVersion_A37048", (object) radioInformation.OptionExpansionBoard.RadInfoOptionExpansionBoardBoardFirmwareVersion_A37048.Value);
      NameAndValue nameAndValue10 = new NameAndValue("RadInfoOptionExpansionBoardBoardType_A37049", (object) radioInformation.OptionExpansionBoard.RadInfoOptionExpansionBoardBoardType_A37049.Value);
      multipleFieldsXml.NameAndValueList.Add(nameAndValue1);
      multipleFieldsXml.NameAndValueList.Add(nameAndValue2);
      multipleFieldsXml.NameAndValueList.Add(nameAndValue3);
      multipleFieldsXml.NameAndValueList.Add(nameAndValue4);
      multipleFieldsXml.NameAndValueList.Add(nameAndValue5);
      multipleFieldsXml.NameAndValueList.Add(nameAndValue6);
      multipleFieldsXml.NameAndValueList.Add(nameAndValue7);
      multipleFieldsXml.NameAndValueList.Add(nameAndValue8);
      multipleFieldsXml.NameAndValueList.Add(nameAndValue9);
      multipleFieldsXml.NameAndValueList.Add(nameAndValue10);
      cp.DeviceInfoFields = multipleFieldsXml.SerializeToXML();
      if (operation != PopulateOpeartion.Write)
        CommonUtility.PopulatePassword2CodeplugColumn((Codeplug) cp, dev, operation);
      if (operation == PopulateOpeartion.Import)
        dev.SerialNumber = radioInformation.General.RadInfoGeneralSerialNumber_A9122.Value;
      if (operation != PopulateOpeartion.Save)
        dev.ModelNumber = radioInformation.General.RadInfoGeneralModelNumber_A8539.Value;
    }
    catch (Exception ex)
    {
      Trace.WriteLine("[Cruncher][Exception][PopulatecpAndDeviceColumnsFromDatabaseLayer]: " + ex.Message);
      throw new ApplicationException("Populate codeplug and device columns fails");
    }
    Trace.WriteLine("[Cruncher][Information][End][PopulatecpAndDeviceColumnsFromDatabaseLayer]");
  }

  internal static void PopulatePassword2CodeplugColumn(
    Codeplug codeplug,
    Radio dev,
    PopulateOpeartion operation)
  {
    Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide radioWide = FeatureManager.GetFeature(2045)[0] as Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide;
    ASTROPasswordPolicy astroPasswordPolicy = ASTROPasswordPolicy.None;
    if (radioWide.Labtool.RadWideLabtoolRadioReadPasswordEnable_A8869.Value)
      astroPasswordPolicy |= ASTROPasswordPolicy.Read;
    if (radioWide.Labtool.RadWideLabtoolRadioWritePasswordEnable_A8889.Value)
      astroPasswordPolicy |= ASTROPasswordPolicy.Write;
    if (radioWide.Labtool.RadWideLabtoolArchiveReadPasswordEnable_A7462.Value)
      astroPasswordPolicy |= ASTROPasswordPolicy.Open;
    (codeplug as APXCodeplug).PasswordPolicy = astroPasswordPolicy;
    AcpField<string> radioPasswordA8837 = radioWide.Labtool.RadWideLabtoolRadioPassword_A8837;
    (codeplug as APXCodeplug).CodeplugPassword = new ReadWriteUtil().decryptMesg(radioPasswordA8837.Value);
    if (operation == PopulateOpeartion.Read && radioWide.Labtool.RadWideLabtoolRadioReadPasswordEnable_A8869.Value || operation == PopulateOpeartion.Import && radioWide.Labtool.RadWideLabtoolArchiveReadPasswordEnable_A7462.Value)
      (dev as APXRadio).ReadPassword = new ReadWriteUtil().decryptMesg(radioPasswordA8837.Value);
    codeplug.PasswordPerDevice = false;
  }

  internal static void PopulatecpAndDeviceColumnsFromDatabaseLayerForCruncherRead(
    APXCodeplug cp,
    Radio dev)
  {
    CommonUtility.PopulatecpAndDeviceColumnsFromDatabaseLayer(cp, dev, PopulateOpeartion.Read);
    string flasHcodeA8132Value = (FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation).FLASHport.RadInfoFLASHportFLASHcode_A8132Value;
    if (UpgradeRadio.checkPCIFieldsValue(dev.ModelNumber, cp.FirmwareVersion, flasHcodeA8132Value))
      cp.ExtendedFlags |= 1;
    else
      cp.ExtendedFlags &= -2;
  }

  internal static void PopulatecpAndDeviceColumnsFromDatabaseLayerForCruncherWrite(
    CruncherData cruncherData,
    CruncherOperation.Operation opType)
  {
    APXCodeplug codeplug = cruncherData.Codeplug as APXCodeplug;
    Radio radio = cruncherData.Radio;
    CommonUtility.PopulatecpAndDeviceColumnsFromDatabaseLayer(codeplug, radio, PopulateOpeartion.Write);
    cruncherData.WriteJobUpdateData = (JPWriteJobUpdateData) new JPASTROWriteJobUpdateData();
    Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide radioWide = FeatureManager.GetFeature(2045)[0] as Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide;
    bool flag1 = radioWide.Labtool.RadWideLabtoolRadioReadPasswordEnable_A8869.Value;
    bool flag2 = radioWide.Labtool.RadWideLabtoolRadioWritePasswordEnable_A8889.Value;
    bool flag3 = radioWide.Labtool.RadWideLabtoolArchiveReadPasswordEnable_A7462.Value;
    if (!flag1 && !flag2 && !flag3)
    {
      cruncherData.WriteJobUpdateData.CodeplugPassword = string.Empty;
    }
    else
    {
      AcpField<string> radioPasswordA8837 = radioWide.Labtool.RadWideLabtoolRadioPassword_A8837;
      cruncherData.WriteJobUpdateData.CodeplugPassword = new ReadWriteUtil().decryptMesg(radioPasswordA8837.Value);
    }
    if (opType == CruncherOperation.Operation.UPGRADE)
      codeplug.ExtendedFlags |= 1;
    (cruncherData.WriteJobUpdateData as JPASTROWriteJobUpdateData).ExtendedFlags = codeplug.ExtendedFlags;
  }

  private static APXRadioSystem[] PopulateSystems()
  {
    IAcpRecordset feature1 = FeatureManager.GetFeature(2053);
    IAcpRecordset feature2 = FeatureManager.GetFeature(2064);
    Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation radioInformation = FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation;
    bool flag = RadioAccessValidator.IsConvOnly(radioInformation.General.RadInfoGeneralModelNumber_A8539.Value, radioInformation.FLASHport.RadInfoFLASHportFLASHcode_A8132Value, true);
    int count1 = feature1.Count;
    if (!flag)
      count1 += feature2.Count;
    APXRadioSystem[] apxRadioSystemArray = new APXRadioSystem[count1];
    for (int index = 0; index < feature1.Count; ++index)
    {
      Motorola.MackinawCPS.CoreFeatures.ConventionalSystem.ConventionalSystem conventionalSystem = feature1[index] as Motorola.MackinawCPS.CoreFeatures.ConventionalSystem.ConventionalSystem;
      APXRadioSystem apxRadioSystem = new APXRadioSystem();
      apxRadioSystem.SystemType = new AstroSystemType?(AstroSystemType.CONVENTIONAL);
      if (conventionalSystem.General.CnvSysGeneralSystemType_A13262.Value == 0)
        apxRadioSystem.SystemSubType = new AstroSystemSubType?(AstroSystemSubType.ASTRO);
      else if (conventionalSystem.General.CnvSysGeneralSystemType_A13262.Value == 1)
        apxRadioSystem.SystemSubType = new AstroSystemSubType?(AstroSystemSubType.MDC);
      else if (conventionalSystem.General.CnvSysGeneralSystemType_A13262.Value == 2)
        apxRadioSystem.SystemSubType = new AstroSystemSubType?(AstroSystemSubType.DVRS);
      else if (conventionalSystem.General.CnvSysGeneralSystemType_A13262.Value == 3)
        apxRadioSystem.SystemSubType = new AstroSystemSubType?(AstroSystemSubType.QCII);
      apxRadioSystem.SystemName = conventionalSystem.General.CnvSysGeneralKeyofConventionalSystem_A20482.Value;
      apxRadioSystem.SystemId = new int?(conventionalSystem.General.CnvSysGeneralSystemID_A40122.Value);
      AstroSystemSubType? systemSubType = apxRadioSystem.SystemSubType;
      int num;
      if ((systemSubType.GetValueOrDefault() != AstroSystemSubType.ASTRO ? 0 : (systemSubType.HasValue ? 1 : 0)) == 0)
      {
        systemSubType = apxRadioSystem.SystemSubType;
        num = (systemSubType.GetValueOrDefault() != AstroSystemSubType.DVRS ? 0 : (systemSubType.HasValue ? 1 : 0)) == 0 ? 1 : 0;
      }
      else
        num = 0;
      if (num == 0)
      {
        apxRadioSystem.RadioId = new int?(conventionalSystem.General.CnvSysGeneralIndividualID_A8287.Value);
      }
      else
      {
        systemSubType = apxRadioSystem.SystemSubType;
        if ((systemSubType.GetValueOrDefault() != AstroSystemSubType.MDC ? 0 : (systemSubType.HasValue ? 1 : 0)) != 0)
        {
          apxRadioSystem.RadioId = new int?(conventionalSystem.General.CnvSysGeneralMDCPrimaryID_A8744.Value);
          apxRadioSystem.ExpandedMDCIDRange = conventionalSystem.General.CnvSysGeneralAdditionalMDCPID_A41761.Value;
        }
        else
        {
          systemSubType = apxRadioSystem.SystemSubType;
          if ((systemSubType.GetValueOrDefault() != AstroSystemSubType.QCII ? 0 : (systemSubType.HasValue ? 1 : 0)) != 0)
            apxRadioSystem.RadioId = new int?(conventionalSystem.General.CnvSysGeneralMDCPrimaryID_A8744.Value);
        }
      }
      apxRadioSystem.CnvGroupNumber = new int?(conventionalSystem.General.CnvSysGeneralSystemGroupNumber_A21960.Value);
      apxRadioSystemArray[index] = apxRadioSystem;
    }
    if (!flag)
    {
      for (int count2 = feature1.Count; count2 < feature1.Count + feature2.Count; ++count2)
      {
        Motorola.MackinawCPS.CoreFeatures.TrunkingSystem.TrunkingSystem trunkingSystem = feature2[count2 - feature1.Count] as Motorola.MackinawCPS.CoreFeatures.TrunkingSystem.TrunkingSystem;
        APXRadioSystem apxRadioSystem = new APXRadioSystem();
        apxRadioSystem.SystemType = new AstroSystemType?(AstroSystemType.TRUNCKING);
        if (trunkingSystem.General.TrkSysGeneralSystemType_A9252.Value == 2)
          apxRadioSystem.SystemSubType = new AstroSystemSubType?(AstroSystemSubType.TYPEII);
        else if (trunkingSystem.General.TrkSysGeneralSystemType_A9252.Value == 3)
          apxRadioSystem.SystemSubType = new AstroSystemSubType?(AstroSystemSubType.ASTRO25);
        apxRadioSystem.CnvGroupNumber = new int?(-1);
        apxRadioSystem.SystemName = trunkingSystem.General.TrkSysGeneralKeyofTrunkingSystem_A12658.Value;
        apxRadioSystem.SystemId = new int?(trunkingSystem.General.TrkSysGeneralSystemID_A9239.Value);
        apxRadioSystem.RadioId = new int?(trunkingSystem.General.TrkSysGeneralUnitID_A12651.Value);
        apxRadioSystem.WacnId = new int?(trunkingSystem.General.TrkSysGeneralHomeWACNID_A8205.Value);
        apxRadioSystem.CoverageType = new int?(trunkingSystem.General.TrkSysGeneralCoverageType_A7782.Value);
        apxRadioSystem.ShuffeledBandPlan = new bool?(trunkingSystem.TypeIIChannelSetup.TrkSysTypeIIChannelSetupShuffledBandPlan_A9128.Value);
        apxRadioSystemArray[count2] = apxRadioSystem;
        apxRadioSystem.SelectedDataProfileName = trunkingSystem.General.TrkSysGeneralDataProfileSelection_A19449.Value >= 1 ? trunkingSystem.General.TrkSysGeneralDataProfileSelection_A19449.ReferencedNode.ReferenceKey : (string) null;
      }
    }
    return apxRadioSystemArray;
  }

  private static APXWiFiNetwork[] PopulateWiFiNetworks()
  {
    ConfiguredNetworksListInnerRecset embeddedRecset = (FeatureManager.GetFeature(2028)[0] as Motorola.MackinawCPS.CoreFeatures.DataWide.DataWide).WIFI.EmbeddedRecset as ConfiguredNetworksListInnerRecset;
    APXWiFiNetwork[] apxWiFiNetworkArray = new APXWiFiNetwork[embeddedRecset.Count];
    for (int index = 0; index < embeddedRecset.Count; ++index)
    {
      ConfiguredNetworksListInnerSection listInnerSection = (embeddedRecset[index] as ConfiguredNetworksListInner).ConfiguredNetworksListInnerSection;
      apxWiFiNetworkArray[index] = new APXWiFiNetwork()
      {
        NetworkSSID = listInnerSection.DataWideWiFiNetworkSSID_42519.Value,
        NetworkSecureType = listInnerSection.DataWideWiFiNetworkSecurityType_42516.Value,
        NetworkPWD = listInnerSection.DataWideWiFiNetworkEncryptedNetworkPassword_42517.Value
      };
    }
    return apxWiFiNetworkArray;
  }

  private static APXDataProfile[] PopulateDataProfiles()
  {
    IAcpRecordset feature = FeatureManager.GetFeature(2054);
    APXDataProfile[] apxDataProfileArray = new APXDataProfile[feature.Count];
    for (int index = 0; index < feature.Count; ++index)
    {
      Motorola.MackinawCPS.CoreFeatures.DataProfiles.DataProfiles RefDataProfile = feature[index] as Motorola.MackinawCPS.CoreFeatures.DataProfiles.DataProfiles;
      APXDataProfile apxDataProfile = new APXDataProfile();
      apxDataProfile.Name = RefDataProfile.General.DataProfGeneralkeyofDataProfiles_A19446.Value;
      apxDataProfile.PeerIP = RefDataProfile.General.DataProfGeneralMobileComputerIPAddress_A8523.UIValue;
      apxDataProfile.SubscriberIP = RefDataProfile.General.DataProfGeneralSubscriberIPAddress_A21157.UIValue;
      apxDataProfile.AirInterfaceAddress = RefDataProfile.General.DataProfGeneralSubscriberAirInterfaceIPAddress_A9220.UIValue;
      if (RefDataProfile.General.DataProfGeneralDataProfileType_A21320.Value == 0)
        apxDataProfile.SystemType = new int?(1);
      else if (RefDataProfile.General.DataProfGeneralDataProfileType_A21320.Value == 1)
        apxDataProfile.SystemType = new int?(0);
      else if (RefDataProfile.General.DataProfGeneralDataProfileType_A21320.Value == 3)
        apxDataProfile.SystemType = new int?(3);
      else if (RefDataProfile.General.DataProfGeneralDataProfileType_A21320.Value == 4)
        apxDataProfile.SystemType = new int?(4);
      else if (RefDataProfile.General.DataProfGeneralDataProfileType_A21320.Value == 2)
        apxDataProfile.SystemType = new int?(2);
      apxDataProfile.InheritFlag = new bool?(RefDataProfile.General.DataProfGeneralAutoGenerateIPAddress_A19320.Value);
      apxDataProfile.AstroBluetoothDunPeerIp = RefDataProfile.General.DataProfilesGeneralBTDUNPeerIPAddress_A41127.UIValue;
      apxDataProfile.AstroBluetoothDunSubscriberIp = RefDataProfile.General.DataProfilesGeneralBTDUNSUIPAddress_A41126.UIValue;
      apxDataProfile.TrunkingGroupIds = RMUtilities.PopulateTrunkingGroupIDs(RefDataProfile);
      switch (RefDataProfile.General.DataProfGeneralPacketDataMode_A8689.Value)
      {
        case 0:
          apxDataProfile.PacketDataMode = new int?(0);
          break;
        case 1:
          apxDataProfile.PacketDataMode = new int?(1);
          break;
        case 2:
          apxDataProfile.PacketDataMode = new int?(2);
          break;
      }
      apxDataProfile.NatEnable = new bool?(RefDataProfile.General.DataWideGeneralNATEnable_A38866.Value);
      switch (RefDataProfile.General.DataProfilesGeneralBTDUNPeerIPAddressAssignmentType_A41128.Value)
      {
        case 0:
          apxDataProfile.BluetoothDunPeerIpAssignmentType = new int?(0);
          break;
        case 1:
          apxDataProfile.BluetoothDunPeerIpAssignmentType = new int?(1);
          break;
      }
      switch (RefDataProfile.Features.DataProfFeaturesARSMode_A7465.Value)
      {
        case 0:
          apxDataProfile.ArsMode = new int?(0);
          break;
        case 1:
          apxDataProfile.ArsMode = new int?(1);
          break;
        case 3:
          apxDataProfile.ArsMode = new int?(3);
          break;
        case 5:
          apxDataProfile.ArsMode = new int?(5);
          break;
      }
      apxDataProfile.AutomaticRegistrationServerAddress = RefDataProfile.Features.DataProfFeaturesAutomaticRegistrationServerAddress_A7524.UIValue;
      apxDataProfile.DirectLocationRegistration = new bool?(RefDataProfile.Features.DataProfFeaturesDirLocReg_A42332.Value);
      apxDataProfile.LocationServerIPAddress = RefDataProfile.Features.DataProfFeaturesLocServerIPAddr_A42333.UIValue;
      apxDataProfileArray[index] = apxDataProfile;
    }
    return apxDataProfileArray;
  }

  internal static void PopulateTemplateColumnsFromDatabaseLayer(APXTemplate template)
  {
    APXRadioSystem[] systems = CommonUtility.PopulateSystems();
    APXDataProfile[] profiles = CommonUtility.PopulateDataProfiles();
    CommonUtility.PopulateTemplateColumnsHelper(template);
    CommonUtility.PopulateRadioSystemsFromCodeplug(systems, (Template) template);
    CommonUtility.PopulateDataProfilesFromCodeplug(profiles, (Template) template);
    CommonUtility.PopulateWiFiNetworksFromCodeplug(CommonUtility.PopulateWiFiNetworks(), (Template) template);
  }

  private static void PopulateTemplateColumnsHelper(APXTemplate template)
  {
    Motorola.MackinawCPS.CoreFeatures.SecureWide.SecureWide secureWide = FeatureManager.GetFeature(2021)[0] as Motorola.MackinawCPS.CoreFeatures.SecureWide.SecureWide;
    Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide radioWide = FeatureManager.GetFeature(2045)[0] as Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide;
    Motorola.MackinawCPS.CoreFeatures.DataWide.DataWide dataWide = FeatureManager.GetFeature(2028)[0] as Motorola.MackinawCPS.CoreFeatures.DataWide.DataWide;
    Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation radioInformation = FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation;
    template.ProductFamily = new int?(1);
    template.ModelNumber = radioInformation.General.RadInfoGeneralModelNumber_A8539.Value;
    template.RadioAliasEnable = new bool?(radioWide.UserInformationAndPasswords.RadWideUserInformationandPasswordsRadioAliasEnable_A8830.Value);
    template.OtarEnable = new bool?(secureWide.General.SecWideGeneralOTAREnable_A7966.Value);
    template.AstroOtarEnable = new bool?(secureWide.ASTROOTAR.SecWideASTROOTARASTROOTAREnable_A7496.Value);
    template.SecureOperation = new int?(secureWide.General.SecWideGeneralSecureOperation_A9067.Value);
    template.BluetoothDunPeerIpAssignmentType = new int?(dataWide.General.DataWideGeneralBTDUNPeerIPAddressAssignmentType_A41124.Value);
    template.BluetoothEnable = new bool?(radioWide.Bluetooth.RadWideBluetoothBluetoothEnable_A37028.Value);
    template.LocationEnable = new bool?(radioWide.Location.RadWideLocationLocationEnable_A8448.Value);
    template.P25LocationReporting = new bool?(radioWide.Location.RadWideLocP25LocationReporting_42412.Value);
    template.UserNameDisplayTextSize = radioWide.UserInformationAndPasswords.RadWideUserInformationandPasswordsSoftIDUsernameDisplayTextSize_A23453.Value;
    template.UserLoginUnitIDTextSize = radioWide.UserInformationAndPasswords.RadWideUserInformationandUserLoginUnitIDTextSize_41309.Value;
    template.UserLoginUnitIDEnable = radioWide.UserInformationAndPasswords.RadWideUserInformationandUserLoginUnitIDEnable_41305.Value;
    template.PeerIP_A41818 = dataWide.General.DataWideGeneralDVRIPAddress_A41818.UIValue;
    template.SubscriberIP_A41819 = dataWide.General.DataWideGeneralMobileSubIPAddress_A41819.UIValue;
    template.CodeplugVersion = radioInformation.General.RadInfoGeneralCodeplugVersion_A7683.Value;
    template.FirmwareVersion = radioInformation.General.RadInfoGeneralFirmwareVersion_A8124.Value;
    template.AllowInvalidFrequency = new bool?(radioInformation.FrequencyRanges.RadInfoFrequencyRangesAllowInvalidFrequencies_A12493.Value);
    Motorola.MackinawCPS.CoreFeatures.DisplayAndMenu.DisplayAndMenu displayAndMenu = FeatureManager.GetFeature(2010)[0] as Motorola.MackinawCPS.CoreFeatures.DisplayAndMenu.DisplayAndMenu;
    template.LanguageIndex = new int?(displayAndMenu.Advanced.DispMenuAdvancedLanguageSelection_A8386Value);
    string flasHcodeA8132Value = radioInformation.FLASHport.RadInfoFLASHportFLASHcode_A8132Value;
    byte[] decoded1 = new byte[0];
    FlashcodeDecoder.Decode(flasHcodeA8132Value, ref decoded1);
    template.AstroPurchasedFlashCode = decoded1;
    string usedFcodeValue = FeatureSetConstraints.getUsedFcodeValue();
    byte[] decoded2 = new byte[0];
    FlashcodeDecoder.Decode(usedFcodeValue, ref decoded2);
    template.AstroEnableFlashCode = decoded2;
    template.RecSetCounts = AstroRecSetCounts.PopulateAstroRecSetCounts();
    template.HomeSystemId = new int?(radioWide.General.RadWideGeneralOwnerSystemID_A37153.Value);
    template.OwnerAdvKeyType = new int?(radioWide.General.RadWideGeneralOwnerAdvancedKeyType_A38663.Value);
    template.OwnerWacnId = new int?(radioWide.General.RadWideGeneralOwnerWACNID_A38656.Value);
    template.BluetoothPANNetworkBaseAddress = radioWide.Bluetooth.RadWideBluetoothBluetoothPANNetworkAddress_41983.UIValue;
    template.WiFiEnable = new bool?(dataWide.WIFI.DataWideWIFIEnable_42506.Value);
  }

  private static void PopulateRadioSystemsFromCodeplug(APXRadioSystem[] systems, Template target)
  {
    if (target == null)
      target = (Template) new APXTemplate();
    ((APXTemplate) target).RadioSystems = RMCExportInterface.GetInstance().EntityCollectionsToXML<APXRadioSystem>(systems);
  }

  private static void PopulateDataProfilesFromCodeplug(APXDataProfile[] profiles, Template target)
  {
    if (target == null)
      target = (Template) new APXTemplate();
    ((APXTemplate) target).DataProfiles = RMCExportInterface.GetInstance().EntityCollectionsToXML<APXDataProfile>(profiles);
  }

  private static void PopulateWiFiNetworksFromCodeplug(
    APXWiFiNetwork[] wifiNetworks,
    Template target)
  {
    if (target == null)
      target = (Template) new APXTemplate();
    ((APXTemplate) target).WiFiNetworks = RMCExportInterface.GetInstance().EntityCollectionsToXML<APXWiFiNetwork>(wifiNetworks);
  }

  public static void SetFeatureSet(Radio d, Guid radioUuid)
  {
    bool isPortablePro = UtilityMack.IsPortablePro;
    string flasHcodeA8132Value = (FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation).FLASHport.RadInfoFLASHportFLASHcode_A8132Value;
    using (FlashcodeTable flashcodeTable = new FlashcodeTable(isPortablePro, true))
    {
      d.RadioFeatures.Clear();
      flashcodeTable.InitTable(true, d.ModelNumber);
      foreach (Option opt in flashcodeTable.FLASHcode)
      {
        if (flashcodeTable.IsOptionEnabledInFlashcode(opt, flasHcodeA8132Value))
          d.RadioFeatures.Add(RadioFeature.CreateRadioFeature(new Guid?(), radioUuid, (int) opt.OptionID, 8, 8, false, 8, 0));
      }
    }
  }
}
