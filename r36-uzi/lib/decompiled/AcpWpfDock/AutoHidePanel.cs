// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfDock.AutoHidePanel
// Assembly: AcpWpfDock, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 89CC52D3-0487-4106-AFAE-BE4A13C8A50E
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfDock.dll

using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

#nullable disable
namespace DevComponents.WpfDock;

[TemplatePart(Name = "PART_PanelBorder", Type = typeof (Decorator))]
[DesignTimeVisible(false)]
public class AutoHidePanel : ItemsControl
{
  public static readonly DependencyProperty TabOrientationProperty;
  private static readonly DependencyPropertyKey TabOrientationPropertyKey;
  public static readonly DependencyProperty IsBeginGroupProperty;

  static AutoHidePanel()
  {
    FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof (AutoHidePanel), (PropertyMetadata) new FrameworkPropertyMetadata((object) typeof (AutoHidePanel)));
    AutoHidePanel.TabOrientationPropertyKey = DependencyProperty.RegisterReadOnly(nameof (TabOrientation), typeof (Orientation), typeof (AutoHidePanel), (PropertyMetadata) new FrameworkPropertyMetadata((object) Orientation.Horizontal));
    AutoHidePanel.TabOrientationProperty = AutoHidePanel.TabOrientationPropertyKey.DependencyProperty;
    AutoHidePanel.IsBeginGroupProperty = DependencyProperty.RegisterAttached("IsBeginGroup", typeof (bool), typeof (AutoHidePanel), new PropertyMetadata((object) false));
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public Orientation TabOrientation
  {
    get => (Orientation) this.GetValue(AutoHidePanel.TabOrientationProperty);
    internal set => this.SetValue(AutoHidePanel.TabOrientationPropertyKey, (object) value);
  }

  public static bool GetIsBeginGroup(UIElement element)
  {
    return element != null ? (bool) element.GetValue(AutoHidePanel.IsBeginGroupProperty) : throw new ArgumentNullException(nameof (element));
  }

  public static void SetIsBeginGroup(UIElement element, bool doc)
  {
    if (element == null)
      throw new ArgumentNullException(nameof (element));
    element.SetValue(AutoHidePanel.IsBeginGroupProperty, (object) doc);
  }
}
