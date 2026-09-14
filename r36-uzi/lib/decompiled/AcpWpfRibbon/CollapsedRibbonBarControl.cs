// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.CollapsedRibbonBarControl
// Assembly: AcpWpfRibbon, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 45A745B5-88C3-40EE-B1E5-8DBA2EACD529
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfRibbon.dll

using System.ComponentModel;
using System.Windows;

#nullable disable
namespace DevComponents.WpfRibbon;

[DesignTimeVisible(false)]
public class CollapsedRibbonBarControl : HeaderedPopupControl
{
  static CollapsedRibbonBarControl()
  {
    FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof (CollapsedRibbonBarControl), (PropertyMetadata) new FrameworkPropertyMetadata((object) typeof (CollapsedRibbonBarControl)));
  }

  internal CollapsedRibbonBarButton CreateButton()
  {
    CollapsedRibbonBarButton button = new CollapsedRibbonBarButton();
    button.Role = eButtonRole.DropDown;
    this.Header = (object) button;
    return button;
  }
}
