// Decompiled with JetBrains decompiler
// Type: MackinawCPS.WcfServiceForRmcTemplateTest.MackinawOperationContract
// Assembly: APXFamilyCPS, Version=36.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 9359335E-041C-4B12-9409-F4E6E7D93299
// Assembly location: C:\Program Files (x86)\Motorola\ApxFamilyCPS R36.00\APXFamilyCPS1.exe

using Motorola.CommonCPS.RadioManagement.Infrastructure.Services.RMCExportToCPS;
using Motorola.CommonCPS.RadioManagement.Interface.RmcCpsWcfContractInterfaceForTestsOnly;
using Motorola.CommonCPS.RadioManagement.SharedServices;
using SpecialFeatures.Comms;
using System;
using System.Reflection;
using System.ServiceModel;
using System.Windows;

#nullable disable
namespace MackinawCPS.WcfServiceForRmcTemplateTest;

[ServiceBehavior(IncludeExceptionDetailInFaults = true)]
public class MackinawOperationContract : IRmcCpsWcfContract
{
  public bool InitDeviceManager() => DeviceManagerSingleTon.Instance != null;

  public OpenFileEventArgs ImportDevice(OpenFileEventArgs args)
  {
    this.InvokeMethod("ExportInterfaceForCPS_ImportDeviceEvtHandler", (object) args);
    return args;
  }

  public OpenFileEventArgs ParseAchive(OpenFileEventArgs args)
  {
    this.InvokeMethod("ExportInterfaceForCPS_ParseAchiveEvtHandler", (object) args);
    return args;
  }

  public DeviceEventArgs EditTemplate(DeviceEventArgs args)
  {
    this.InvokeMethod("ExportInterfaceForCPS_ExportEditCodeplugEvtHandler", (object) args);
    return args;
  }

  public OpenFileEventArgs ImportTemplate(OpenFileEventArgs args)
  {
    this.InvokeMethod("RMCWnd_ImportTemplateEvtHandler", (object) args);
    return args;
  }

  public ExportDeviceEventArgs ExportDevice(ExportDeviceEventArgs args)
  {
    this.InvokeMethod("RMCWnd_ExportDeviceEvtHandler", (object) args);
    return args;
  }

  public ExportDVRSEventArgs ExportDVRS(ExportDVRSEventArgs args)
  {
    this.InvokeMethod("RMCWnd_ExportDVRSEvtHandler", (object) args);
    return args;
  }

  public AstroUpgradeCodeplugEventArgs AstroUpgradeCodeplug(AstroUpgradeCodeplugEventArgs args)
  {
    this.InvokeMethod("RMCWnd_AstroUpgradeCodeplugEvtHandler", (object) args);
    return args;
  }

  public ASTROHoptionEnableEventArgs AstroCheckHoptionEnable(ASTROHoptionEnableEventArgs args)
  {
    this.InvokeMethod("RMCWnd_AstroCheckHoptionEnableEvtHandler", (object) args);
    return args;
  }

  public ASTROHoptionEnableEventArgs AstroCheckIsConvOnly(ASTROHoptionEnableEventArgs args)
  {
    this.InvokeMethod("RMCWnd_AstroCheckIsConvOnlyEvtHandler", (object) args);
    return args;
  }

  public AnalysisPackageEventArgs AnalysisPackage(AnalysisPackageEventArgs args)
  {
    this.InvokeMethod("RMCWnd_AnalysisPackageEvtHandler", (object) args);
    return args;
  }

  public ListLpPackageEventArgs LanguagePackInfos(ListLpPackageEventArgs args)
  {
    this.InvokeMethod("RMCWnd_LanguagePackInfosEvtHandler", (object) args);
    return args;
  }

  public AstroDecodeLanguageIndexToLPIDEventArgs AstroDecodeLangageIndexToLpID(
    AstroDecodeLanguageIndexToLPIDEventArgs args)
  {
    this.InvokeMethod("RMCWnd_AstroDecodeLangageIndexToLpIDEvtHandler", (object) args);
    return args;
  }

  public AstroLanguageCompatibleCheckEventArgs AstroLanguagePackCompatibleCheck(
    AstroLanguageCompatibleCheckEventArgs args)
  {
    this.InvokeMethod("RMCWnd_AstroLanguagePackCompatibleCheckEvtHandler", (object) args);
    return args;
  }

  public AstroUpgradeWithLanugagePackIsSupportedCheckEventArgs AstroUpgradeWithLanugagePackIsSupportedCheck(
    AstroUpgradeWithLanugagePackIsSupportedCheckEventArgs args)
  {
    this.InvokeMethod("RMCWnd_AstroUpgradeWithLanugagePackIsSupportedCheckEvtHandler", (object) args);
    return args;
  }

  public AstroUpgradeFWCompatibleCheckEventArgs AstroUpgradeFWVerCompatibleCheck(
    AstroUpgradeFWCompatibleCheckEventArgs args)
  {
    this.InvokeMethod("RMCWnd_AstroUpgradeFWVerCompatibleCheckEvtHandler", (object) args);
    return args;
  }

  public AstroDecodeFlashCodeEventArgs AstroDecodeFlashCode(AstroDecodeFlashCodeEventArgs args)
  {
    this.InvokeMethod("RMCWnd_AstroDecodeFlashCodeEvtHandler", (object) args);
    return args;
  }

  public AstroFlashKeyEventArgs AstroReadFlashKey(AstroFlashKeyEventArgs args)
  {
    this.InvokeMethod("RMCWnd_AstroReadFlashKeyEvtHandler", (object) args);
    return args;
  }

  public void AstroReleaseFlashKey()
  {
    this.InvokeMethod("RMCWnd_AstroReleaseFlashKeyEvtHandler", (object) new object[2]
    {
      new object(),
      (object) EventArgs.Empty
    });
  }

  public AstroDecreaseKeyCountEventArgs AstroDecraseFlashKey(AstroDecreaseKeyCountEventArgs args)
  {
    this.InvokeMethod("RMCWnd_AstroDecraseFlashKeyEvtHandler", (object) args);
    return args;
  }

  public AstroPINPasswordConvertEventArgs AstroPINPasswordConvert(
    AstroPINPasswordConvertEventArgs args)
  {
    this.InvokeMethod("RMCWnd_AstroPINPasswordConvertEventHandler", (object) args);
    return args;
  }

  public AstroFlashKeyEventArgs AstroValidateFlashKey(AstroFlashKeyEventArgs args)
  {
    this.InvokeMethod("RMCWnd_AstroValidateFlashKeyEvtHandler", (object) args);
    return args;
  }

  public AstroASKRequirementEventArgs AstroASKRequirementEditingCheck(
    AstroASKRequirementEventArgs args)
  {
    this.InvokeMethod("ExportInterfaceForCPS_AstroASKRequirementEditingCheckEvtHandler", (object) args);
    return args;
  }

  public ASTROIndividualIdEditingEventArgs ASTROIndividualIdEditingCheck(
    ASTROIndividualIdEditingEventArgs args)
  {
    this.InvokeMethod("ExportInterfaceForCPS_AstroIndividualIdEditingCheckEvtHandler", (object) args);
    return args;
  }

  public AstroWritingEventArgs AstroWritingCheck(AstroWritingEventArgs args)
  {
    this.InvokeMethod("ExportInterfaceForCPS_AstroWritingCheckEvtHandler", (object) args);
    return args;
  }

  public AstroCompatibilityEventArgs AstroCompatibilityCheck(AstroCompatibilityEventArgs args)
  {
    this.InvokeMethod("ExportInterfaceForCPS_AstroCompatibilityCheckEvtHandler", (object) args);
    return args;
  }

  public AstroPop25EnabledEventArgs AstroPop25Enabled(AstroPop25EnabledEventArgs args)
  {
    this.InvokeMethod("AstroPOP25EnabledCheckEvtHandler", (object) args);
    return args;
  }

  public AstroEncodeFlashCodeEventArgs AstroEncodeFlashCode(AstroEncodeFlashCodeEventArgs args)
  {
    this.InvokeMethod("RMCWnd_AstroEncodeFlashCodeEvtHandler", (object) args);
    return args;
  }

  public ParseFeatureCodeEventArgs ParseFeatureCode(ParseFeatureCodeEventArgs args)
  {
    this.InvokeMethod("RMCWnd_ParseFeatureCodeEvtHandler", (object) args);
    return args;
  }

  public AstroParseFlashCodeEventArgs AstroParseFlashCode(AstroParseFlashCodeEventArgs args)
  {
    this.InvokeMethod("RMCWnd_AstroParseFlashCodeEvtHandler", (object) args);
    return args;
  }

  public ParseFeatureStatusEventArgs ParseFeatureStatus(ParseFeatureStatusEventArgs args)
  {
    this.InvokeMethod("RMCWnd_ParseFeatureStatusEvtHandler", (object) args);
    return args;
  }

  public PopulateRadioFeaturesFromCodeplugEventArgs PopulateRadioFeaturesFromCodeplug(
    PopulateRadioFeaturesFromCodeplugEventArgs args)
  {
    this.InvokeMethod("RMCWnd_PopulateRadioFeaturesFromCodeplugEvtHandler", (object) args);
    return args;
  }

  public PopulateRadioFeaturesFromFlashCodeEventArgs PopulateRadioFeaturesFromFlashCode(
    PopulateRadioFeaturesFromFlashCodeEventArgs args)
  {
    this.InvokeMethod("RMCWnd_PopulateRadioFeaturesFromFlashCodeEvtHandler", (object) args);
    return args;
  }

  public QueryUpdateRadioEventArgs QueryUpdateRadio(QueryUpdateRadioEventArgs args)
  {
    this.InvokeMethod("RMCWnd_QueryUpdateRadioEvtHandler", (object) args);
    return args;
  }

  public ASTROHoptionEnableEventArgs AstroCheckIsConvOnly2(ASTROHoptionEnableEventArgs args)
  {
    this.InvokeMethod("RMCWnd_RadioIsConvOnlyEvtHandler", (object) args);
    return args;
  }

  public BindingServerLanguagePackEventArgs BindingServerLanguagePack(
    BindingServerLanguagePackEventArgs args)
  {
    this.InvokeMethod("RMCWnd_BindingServerLanguagePackEvtHandler", (object) args);
    return args;
  }

  public IsFreonEventArgs RMCWnd_IsFreon(IsFreonEventArgs args)
  {
    this.InvokeMethod("RMCWnd_IsFreonEvtHandler", (object) args);
    return args;
  }

  public AstroSystemKeyDataEventArgs AstroGetLoadedSysKeys(AstroSystemKeyDataEventArgs args)
  {
    this.InvokeMethod("RMCWnd_AstroGetLoadedSysKeysEvtHandlerEvtHandler", (object) args);
    return args;
  }

  private void InvokeMethod(string functionName, object args)
  {
    try
    {
      Application.Current.Dispatcher.Invoke((Action) (() =>
      {
        RMCWnd rmcWnd = new RMCWnd(true);
        rmcWnd.GetType().GetMethod(functionName, BindingFlags.Instance | BindingFlags.NonPublic).Invoke((object) rmcWnd, new object[2]
        {
          new object(),
          args
        });
      }));
    }
    catch (TargetInvocationException ex)
    {
      throw ex.InnerException;
    }
  }

  public ListTTSLpPackageEventArgs TTSLanguagePackInfos(ListTTSLpPackageEventArgs args)
  {
    throw new NotImplementedException();
  }

  public ModelTierEventArgs ModelTier(ModelTierEventArgs args)
  {
    throw new NotImplementedException();
  }

  public GetVAInstallationPathEventArgs GetVAInsallationPath(GetVAInstallationPathEventArgs args)
  {
    throw new NotImplementedException();
  }

  public GetTTSInstallationPathEventArgs GetTTSInsallationPath(GetTTSInstallationPathEventArgs args)
  {
    throw new NotImplementedException();
  }

  public IsSameFWVersionUpgradeSupportedEventArgs IsSameFWVersionUpgradeSupported(
    IsSameFWVersionUpgradeSupportedEventArgs args)
  {
    throw new NotImplementedException();
  }

  public GenerateLicenseFilterEventArgs GenerateLicenseFilter(GenerateLicenseFilterEventArgs args)
  {
    throw new NotImplementedException();
  }

  public ParseRadioFeatureEventArgs ParseRadioFeature(ParseRadioFeatureEventArgs args)
  {
    throw new NotImplementedException();
  }

  public UpgradeTemplateByFeaturesEventArgs UpgradeTemplateByFeatures(
    UpgradeTemplateByFeaturesEventArgs args)
  {
    throw new NotImplementedException();
  }

  public ApplyRadioWithFeaturesEventArgs ApplyRadioWithFeatures(ApplyRadioWithFeaturesEventArgs args)
  {
    throw new NotImplementedException();
  }

  public RadioCfsChangesInUpgradeEventArgs RadioCfsChangesInUpgrade(
    RadioCfsChangesInUpgradeEventArgs args)
  {
    throw new NotImplementedException();
  }

  public FirmwareUpgradeIncludeEqualEventArgs FirmwareUpgradeIncludeEqual(
    FirmwareUpgradeIncludeEqualEventArgs args)
  {
    throw new NotImplementedException();
  }
}
