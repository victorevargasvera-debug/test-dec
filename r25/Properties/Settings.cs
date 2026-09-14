// Decompiled with JetBrains decompiler
// Type: MackinawCPS.Properties.Settings
// Assembly: APXFamilyCPS, Version=15.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 7983BD42-76AB-479D-8966-B7B635E0E28A
// Assembly location: C:\Program Files (x86)\Motorola\APX Dpt 25\APXFamilyCPS.exe

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

#nullable disable
namespace MackinawCPS.Properties;

[CompilerGenerated]
[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "12.0.0.0")]
internal sealed class Settings : ApplicationSettingsBase
{
  private static Settings defaultInstance = (Settings) SettingsBase.Synchronized((SettingsBase) new Settings());

  public static Settings Default
  {
    get
    {
      Settings defaultInstance = Settings.defaultInstance;
      return defaultInstance;
    }
  }

  [DefaultSettingValue("<INSTALL>\\voice")]
  [DebuggerNonUserCode]
  [SettingsDescription("Location the CPS will use for the Motorola Voice Announcment Files")]
  [UserScopedSetting]
  public string ACP_MVA_Folder
  {
    get => (string) this[nameof (ACP_MVA_Folder)];
    set => this[nameof (ACP_MVA_Folder)] = (object) value;
  }

  [DefaultSettingValue("<INSTALL>\\voice")]
  [DebuggerNonUserCode]
  [UserScopedSetting]
  [SettingsDescription("Location the CPS will show to the user for the last folder for WAV input files for voice announcement creation")]
  public string ACP_Last_WAV_Source_Folder
  {
    get => (string) this[nameof (ACP_Last_WAV_Source_Folder)];
    set => this[nameof (ACP_Last_WAV_Source_Folder)] = (object) value;
  }

  [UserScopedSetting]
  [DebuggerNonUserCode]
  [DefaultSettingValue("")]
  public string CustomBackgroudPath
  {
    get => (string) this[nameof (CustomBackgroudPath)];
    set => this[nameof (CustomBackgroudPath)] = (object) value;
  }

  [DefaultSettingValue("True")]
  [UserScopedSetting]
  [DebuggerNonUserCode]
  public bool NavigationWindowVisible
  {
    get => (bool) this[nameof (NavigationWindowVisible)];
    set => this[nameof (NavigationWindowVisible)] = (object) value;
  }

  [UserScopedSetting]
  [DebuggerNonUserCode]
  [DefaultSettingValue("True")]
  public bool FieldInfoVisible
  {
    get => (bool) this[nameof (FieldInfoVisible)];
    set => this[nameof (FieldInfoVisible)] = (object) value;
  }

  [DebuggerNonUserCode]
  [UserScopedSetting]
  [DefaultSettingValue("True")]
  public bool OutputWindowVisible
  {
    get => (bool) this[nameof (OutputWindowVisible)];
    set => this[nameof (OutputWindowVisible)] = (object) value;
  }

  [DebuggerNonUserCode]
  [UserScopedSetting]
  [DefaultSettingValue("True")]
  public bool OutputWindowAutoRise
  {
    get => (bool) this[nameof (OutputWindowAutoRise)];
    set => this[nameof (OutputWindowAutoRise)] = (object) value;
  }

  [UserScopedSetting]
  [DebuggerNonUserCode]
  [DefaultSettingValue("True")]
  public bool ComparatorWindowVisible
  {
    get => (bool) this[nameof (ComparatorWindowVisible)];
    set => this[nameof (ComparatorWindowVisible)] = (object) value;
  }

  [DefaultSettingValue("True")]
  [UserScopedSetting]
  [DebuggerNonUserCode]
  public bool ComparatorWindowAutoRise
  {
    get => (bool) this[nameof (ComparatorWindowAutoRise)];
    set => this[nameof (ComparatorWindowAutoRise)] = (object) value;
  }

  [UserScopedSetting]
  [DebuggerNonUserCode]
  [DefaultSettingValue("True")]
  public bool DnDWindowVisible
  {
    get => (bool) this[nameof (DnDWindowVisible)];
    set => this[nameof (DnDWindowVisible)] = (object) value;
  }

  [DebuggerNonUserCode]
  [DefaultSettingValue("True")]
  [UserScopedSetting]
  public bool DnDWindowAutoRise
  {
    get => (bool) this[nameof (DnDWindowAutoRise)];
    set => this[nameof (DnDWindowAutoRise)] = (object) value;
  }

  [DefaultSettingValue("True")]
  [DebuggerNonUserCode]
  [UserScopedSetting]
  public bool ImpExpWindowVisible
  {
    get => (bool) this[nameof (ImpExpWindowVisible)];
    set => this[nameof (ImpExpWindowVisible)] = (object) value;
  }

  [DefaultSettingValue("True")]
  [UserScopedSetting]
  [DebuggerNonUserCode]
  public bool ImpExpWindowAutoRise
  {
    get => (bool) this[nameof (ImpExpWindowAutoRise)];
    set => this[nameof (ImpExpWindowAutoRise)] = (object) value;
  }

  [UserScopedSetting]
  [DebuggerNonUserCode]
  [DefaultSettingValue("True")]
  public bool FindResultWindowVisible
  {
    get => (bool) this[nameof (FindResultWindowVisible)];
    set => this[nameof (FindResultWindowVisible)] = (object) value;
  }

  [DebuggerNonUserCode]
  [DefaultSettingValue("True")]
  [UserScopedSetting]
  public bool FindResultWindowAutoRise
  {
    get => (bool) this[nameof (FindResultWindowAutoRise)];
    set => this[nameof (FindResultWindowAutoRise)] = (object) value;
  }

  [UserScopedSetting]
  [DefaultSettingValue("True")]
  [DebuggerNonUserCode]
  public bool SystemKeyWindowVisible
  {
    get => (bool) this[nameof (SystemKeyWindowVisible)];
    set => this[nameof (SystemKeyWindowVisible)] = (object) value;
  }

  [UserScopedSetting]
  [DefaultSettingValue("True")]
  [DebuggerNonUserCode]
  public bool SystemKeyWindowAutoRise
  {
    get => (bool) this[nameof (SystemKeyWindowAutoRise)];
    set => this[nameof (SystemKeyWindowAutoRise)] = (object) value;
  }

  [DefaultSettingValue("True")]
  [UserScopedSetting]
  [DebuggerNonUserCode]
  public bool InvalidFieldWindowVisible
  {
    get => (bool) this[nameof (InvalidFieldWindowVisible)];
    set => this[nameof (InvalidFieldWindowVisible)] = (object) value;
  }

  [DefaultSettingValue("False")]
  [DebuggerNonUserCode]
  [UserScopedSetting]
  public bool InvalidFieldWindowAutoRise
  {
    get => (bool) this[nameof (InvalidFieldWindowAutoRise)];
    set => this[nameof (InvalidFieldWindowAutoRise)] = (object) value;
  }

  [DefaultSettingValue("True")]
  [DebuggerNonUserCode]
  [UserScopedSetting]
  public bool FillUpFillDownWindowVisible
  {
    get => (bool) this[nameof (FillUpFillDownWindowVisible)];
    set => this[nameof (FillUpFillDownWindowVisible)] = (object) value;
  }

  [DebuggerNonUserCode]
  [DefaultSettingValue("True")]
  [UserScopedSetting]
  public bool FillUpFillDownWindowAutoRise
  {
    get => (bool) this[nameof (FillUpFillDownWindowAutoRise)];
    set => this[nameof (FillUpFillDownWindowAutoRise)] = (object) value;
  }

  [UserScopedSetting]
  [DebuggerNonUserCode]
  [DefaultSettingValue("")]
  public string KeyFiles_Default_Folder
  {
    get => (string) this[nameof (KeyFiles_Default_Folder)];
    set => this[nameof (KeyFiles_Default_Folder)] = (object) value;
  }

  [DefaultSettingValue("")]
  [DebuggerNonUserCode]
  [UserScopedSetting]
  public string OpenCodeplugFilePath
  {
    get => (string) this[nameof (OpenCodeplugFilePath)];
    set => this[nameof (OpenCodeplugFilePath)] = (object) value;
  }

  [UserScopedSetting]
  [DebuggerNonUserCode]
  [DefaultSettingValue("")]
  public string UserSelectedApplicationLanguage
  {
    get => (string) this[nameof (UserSelectedApplicationLanguage)];
    set => this[nameof (UserSelectedApplicationLanguage)] = (object) value;
  }

  [DefaultSettingValue("")]
  [UserScopedSetting]
  [DebuggerNonUserCode]
  public string UserSelectedReportsLanguage
  {
    get => (string) this[nameof (UserSelectedReportsLanguage)];
    set => this[nameof (UserSelectedReportsLanguage)] = (object) value;
  }

  [UserScopedSetting]
  [DebuggerNonUserCode]
  [DefaultSettingValue("False")]
  public bool ReportLangDia
  {
    get => (bool) this[nameof (ReportLangDia)];
    set => this[nameof (ReportLangDia)] = (object) value;
  }

  [UserScopedSetting]
  [DebuggerNonUserCode]
  public WindowMain.WINDOWPLACEMENT WindowPlacement
  {
    get => (WindowMain.WINDOWPLACEMENT) this[nameof (WindowPlacement)];
    set => this[nameof (WindowPlacement)] = (object) value;
  }

  [UserScopedSetting]
  [DefaultSettingValue("False")]
  [DebuggerNonUserCode]
  public bool SizeStored
  {
    get => (bool) this[nameof (SizeStored)];
    set => this[nameof (SizeStored)] = (object) value;
  }

  [DefaultSettingValue("")]
  [DebuggerNonUserCode]
  [UserScopedSetting]
  public string SelectedHelpLanguage_RootDir
  {
    get => (string) this[nameof (SelectedHelpLanguage_RootDir)];
    set => this[nameof (SelectedHelpLanguage_RootDir)] = (object) value;
  }

  [UserScopedSetting]
  [DefaultSettingValue("0")]
  [DebuggerNonUserCode]
  public int UpgradeRadioLang
  {
    get => (int) this[nameof (UpgradeRadioLang)];
    set => this[nameof (UpgradeRadioLang)] = (object) value;
  }

  [DefaultSettingValue("True")]
  [UserScopedSetting]
  [DebuggerNonUserCode]
  public bool FieldInfoWindowAutoHidden
  {
    get => (bool) this[nameof (FieldInfoWindowAutoHidden)];
    set => this[nameof (FieldInfoWindowAutoHidden)] = (object) value;
  }

  [DebuggerNonUserCode]
  [UserScopedSetting]
  [DefaultSettingValue("")]
  public string DVRS_Export_Default_Folder
  {
    get => (string) this[nameof (DVRS_Export_Default_Folder)];
    set => this[nameof (DVRS_Export_Default_Folder)] = (object) value;
  }

  [UserScopedSetting]
  [DefaultSettingValue("False")]
  [DebuggerNonUserCode]
  public bool Ribbon_Maximized
  {
    get => (bool) this[nameof (Ribbon_Maximized)];
    set => this[nameof (Ribbon_Maximized)] = (object) value;
  }

  [DebuggerNonUserCode]
  [DefaultSettingValue("MackinawCPS.themes.PCRSkin")]
  [UserScopedSetting]
  public string Color_Theme
  {
    get => (string) this[nameof (Color_Theme)];
    set => this[nameof (Color_Theme)] = (object) value;
  }

  [DefaultSettingValue("True")]
  [DebuggerNonUserCode]
  [UserScopedSetting]
  public bool BottomPanelAutoHide
  {
    get => (bool) this[nameof (BottomPanelAutoHide)];
    set => this[nameof (BottomPanelAutoHide)] = (object) value;
  }

  [DebuggerNonUserCode]
  [DefaultSettingValue("True")]
  [UserScopedSetting]
  public bool BlockNewSysCheck
  {
    get => (bool) this[nameof (BlockNewSysCheck)];
    set => this[nameof (BlockNewSysCheck)] = (object) value;
  }

  [DebuggerNonUserCode]
  [DefaultSettingValue("")]
  [UserScopedSetting]
  public string Refresh_Radio_Default_Folder
  {
    get => (string) this[nameof (Refresh_Radio_Default_Folder)];
    set => this[nameof (Refresh_Radio_Default_Folder)] = (object) value;
  }

  private void SettingChangingEventHandler(object sender, SettingChangingEventArgs e)
  {
  }

  private void SettingsSavingEventHandler(object sender, CancelEventArgs e)
  {
  }
}
