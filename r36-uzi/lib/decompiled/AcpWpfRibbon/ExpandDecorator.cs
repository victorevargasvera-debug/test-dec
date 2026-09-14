// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.ExpandDecorator
// Assembly: AcpWpfRibbon, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 45A745B5-88C3-40EE-B1E5-8DBA2EACD529
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfRibbon.dll

using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

#nullable disable
namespace DevComponents.WpfRibbon;

[DesignTimeVisible(false)]
public class ExpandDecorator : Control
{
  public static readonly DependencyProperty PopupPlacementProperty = DependencyProperty.Register(nameof (PopupPlacement), typeof (ePopupPlacement), typeof (ExpandDecorator), (PropertyMetadata) new UIPropertyMetadata((object) ePopupPlacement.Bottom));
  public static readonly DependencyProperty ExpanderWidthProperty = DependencyProperty.Register(nameof (ExpanderWidth), typeof (double), typeof (ExpandDecorator), (PropertyMetadata) new UIPropertyMetadata((object) 5.0));
  public static readonly DependencyProperty ExpanderHeightProperty = DependencyProperty.Register(nameof (ExpanderHeight), typeof (double), typeof (ExpandDecorator), (PropertyMetadata) new UIPropertyMetadata((object) 3.0));

  public ePopupPlacement PopupPlacement
  {
    get => (ePopupPlacement) this.GetValue(ExpandDecorator.PopupPlacementProperty);
    set => this.SetValue(ExpandDecorator.PopupPlacementProperty, (object) value);
  }

  public double ExpanderWidth
  {
    get => (double) this.GetValue(ExpandDecorator.ExpanderWidthProperty);
    set => this.SetValue(ExpandDecorator.ExpanderWidthProperty, (object) value);
  }

  public double ExpanderHeight
  {
    get => (double) this.GetValue(ExpandDecorator.ExpanderHeightProperty);
    set => this.SetValue(ExpandDecorator.ExpanderHeightProperty, (object) value);
  }

  static ExpandDecorator()
  {
    FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof (ExpandDecorator), (PropertyMetadata) new FrameworkPropertyMetadata((object) typeof (ExpandDecorator)));
  }
}
