// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfDock.DockTabCloseButton
// Assembly: AcpWpfDock, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 89CC52D3-0487-4106-AFAE-BE4A13C8A50E
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfDock.dll

using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

#nullable disable
namespace DevComponents.WpfDock;

[DesignTimeVisible(false)]
public class DockTabCloseButton : Button
{
  public static readonly DependencyProperty IsActiveProperty = DependencyProperty.Register(nameof (IsActive), typeof (bool), typeof (DockTabCloseButton), (PropertyMetadata) new FrameworkPropertyMetadata((object) false, FrameworkPropertyMetadataOptions.AffectsRender));

  public bool IsActive
  {
    get => (bool) this.GetValue(DockTabCloseButton.IsActiveProperty);
    set => this.SetValue(DockTabCloseButton.IsActiveProperty, (object) value);
  }

  static DockTabCloseButton()
  {
    FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof (DockTabCloseButton), (PropertyMetadata) new FrameworkPropertyMetadata((object) typeof (DockTabCloseButton)));
  }
}
