// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.ButtonDropDownAutoSizeBag
// Assembly: AcpWpfRibbon, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 45A745B5-88C3-40EE-B1E5-8DBA2EACD529
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfRibbon.dll

using System.Windows;

#nullable disable
namespace DevComponents.WpfRibbon;

internal class ButtonDropDownAutoSizeBag : ElementAutoSizeBag
{
  private eButtonPartVisibility m_PartVisibility;
  private eButtonImagePosition m_ImagePosition;
  private bool m_UseSmallImage;
  private eExpandPosition m_ExpandPosition = eExpandPosition.Right;

  public override void RecordSetting(UIElement item)
  {
    if (this.SettingsRecorded)
      return;
    ButtonDropDown buttonDropDown = item as ButtonDropDown;
    this.m_PartVisibility = buttonDropDown.PartVisibility;
    this.m_ImagePosition = buttonDropDown.ImagePosition;
    this.m_UseSmallImage = buttonDropDown.UseSmallImage;
    this.m_ExpandPosition = buttonDropDown.ExpandPosition;
    base.RecordSetting(item);
  }

  public override void RestoreSettings()
  {
    if (!this.SettingsRecorded)
      return;
    ButtonDropDown element = this.Element as ButtonDropDown;
    element.PartVisibility = this.m_PartVisibility;
    element.ImagePosition = this.m_ImagePosition;
    element.UseSmallImage = this.m_UseSmallImage;
    element.ExpandPosition = this.m_ExpandPosition;
    base.RestoreSettings();
  }
}
