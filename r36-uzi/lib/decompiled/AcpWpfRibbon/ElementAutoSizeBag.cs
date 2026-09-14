// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.ElementAutoSizeBag
// Assembly: AcpWpfRibbon, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 45A745B5-88C3-40EE-B1E5-8DBA2EACD529
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfRibbon.dll

using System.Windows;

#nullable disable
namespace DevComponents.WpfRibbon;

internal class ElementAutoSizeBag
{
  public UIElement Element;
  private bool m_SettingsRecorded;

  protected bool SettingsRecorded
  {
    get => this.m_SettingsRecorded;
    set => this.m_SettingsRecorded = value;
  }

  public virtual void RecordSetting(UIElement item)
  {
    this.Element = item;
    this.m_SettingsRecorded = true;
  }

  public virtual void RestoreSettings() => this.m_SettingsRecorded = false;
}
