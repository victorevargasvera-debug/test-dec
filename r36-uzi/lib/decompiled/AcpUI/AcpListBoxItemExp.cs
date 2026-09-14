// Decompiled with JetBrains decompiler
// Type: AcpUI.AcpListBoxItemExp
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

using AcpUILib;
using System.Windows;
using System.Windows.Controls;

#nullable disable
namespace AcpUI;

public class AcpListBoxItemExp : ListBoxItem, IAcpUICtrlBase, IAcpUICommon
{
  public static readonly DependencyProperty IsAcpValidProperty = DependencyProperty.Register(nameof (IsAcpValid), typeof (bool), typeof (AcpListBoxItemExp), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty IsAcpApplicableProperty = DependencyProperty.Register(nameof (IsAcpApplicable), typeof (bool), typeof (AcpListBoxItemExp), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty IsAcpEditableProperty = DependencyProperty.Register(nameof (IsAcpEditable), typeof (bool), typeof (AcpListBoxItemExp), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty IsAcpVisibleProperty = DependencyProperty.Register(nameof (IsAcpVisible), typeof (bool), typeof (AcpListBoxItemExp), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(AcpListBoxItemExp.IsAcpVisiblePropertyChanged)));
  public static readonly DependencyProperty MyExpanderProperty = DependencyProperty.RegisterAttached(nameof (MyExpander), typeof (Expander), typeof (AcpListBoxItemExp), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(AcpListBoxItemExp.MyExpanderPropertyChanged)));
  public static readonly DependencyProperty ShowDiffIconProperty = DependencyProperty.RegisterAttached(nameof (ShowDiffIcon), typeof (bool), typeof (AcpListBoxItemExp), (PropertyMetadata) new FrameworkPropertyMetadata((object) false, FrameworkPropertyMetadataOptions.AffectsRender));

  public bool IsAcpValid
  {
    get => (bool) this.GetValue(AcpListBoxItemExp.IsAcpValidProperty);
    set => this.SetValue(AcpListBoxItemExp.IsAcpValidProperty, (object) value);
  }

  public bool IsAcpApplicable
  {
    get => (bool) this.GetValue(AcpListBoxItemExp.IsAcpApplicableProperty);
    set => this.SetValue(AcpListBoxItemExp.IsAcpApplicableProperty, (object) value);
  }

  public bool IsAcpEditable
  {
    get => (bool) this.GetValue(AcpListBoxItemExp.IsAcpEditableProperty);
    set => this.SetValue(AcpListBoxItemExp.IsAcpEditableProperty, (object) value);
  }

  public bool IsAcpVisible
  {
    get => (bool) this.GetValue(AcpListBoxItemExp.IsAcpVisibleProperty);
    set => this.SetValue(AcpListBoxItemExp.IsAcpVisibleProperty, (object) value);
  }

  private static void IsAcpVisiblePropertyChanged(
    DependencyObject d,
    DependencyPropertyChangedEventArgs e)
  {
    if (!(d is AcpListBoxItemExp acpListBoxItemExp))
      return;
    if (!acpListBoxItemExp.IsAcpVisible)
    {
      acpListBoxItemExp.MyExpander.Visibility = Visibility.Collapsed;
    }
    else
    {
      if (!acpListBoxItemExp.IsSelected)
        return;
      acpListBoxItemExp.MyExpander.Visibility = Visibility.Visible;
      acpListBoxItemExp.MyExpander.IsExpanded = true;
    }
  }

  public Expander MyExpander
  {
    get => (Expander) this.GetValue(AcpListBoxItemExp.MyExpanderProperty);
    set => this.SetValue(AcpListBoxItemExp.MyExpanderProperty, (object) value);
  }

  private static void MyExpanderPropertyChanged(
    DependencyObject d,
    DependencyPropertyChangedEventArgs e)
  {
    AcpListBoxItemExp acpListBoxItemExp = d as AcpListBoxItemExp;
    if (acpListBoxItemExp.MyExpander == null || acpListBoxItemExp == null)
      return;
    if (!acpListBoxItemExp.IsAcpVisible)
    {
      acpListBoxItemExp.MyExpander.Visibility = Visibility.Collapsed;
    }
    else
    {
      if (!acpListBoxItemExp.IsSelected)
        return;
      acpListBoxItemExp.MyExpander.Visibility = Visibility.Visible;
      acpListBoxItemExp.MyExpander.IsExpanded = true;
    }
  }

  public bool ShowDiffIcon
  {
    get => (bool) this.GetValue(AcpListBoxItemExp.ShowDiffIconProperty);
    set => this.SetValue(AcpListBoxItemExp.ShowDiffIconProperty, (object) value);
  }

  private void AcpListBoxItemExp_Unselected(object sender, RoutedEventArgs e)
  {
    if (!(sender is AcpListBoxItemExp acpListBoxItemExp) || acpListBoxItemExp.MyExpander == null)
      return;
    acpListBoxItemExp.MyExpander.Visibility = Visibility.Collapsed;
    acpListBoxItemExp.MyExpander.IsExpanded = false;
  }

  private void AcpListBoxItemExp_Selected(object sender, RoutedEventArgs e)
  {
    if (!(sender is AcpListBoxItemExp acpListBoxItemExp) || acpListBoxItemExp.MyExpander == null)
      return;
    acpListBoxItemExp.MyExpander.Visibility = Visibility.Visible;
    acpListBoxItemExp.MyExpander.IsExpanded = true;
    acpListBoxItemExp.MyExpander.Focus();
  }

  public AcpListBoxItemExp()
  {
    this.Selected += new RoutedEventHandler(this.AcpListBoxItemExp_Selected);
    this.Loaded += new RoutedEventHandler(this.AcpListBoxItemExp_Loaded);
    this.Unloaded += new RoutedEventHandler(this.AcpListBoxItemExp_Unloaded);
    this.FocusVisualStyle = (Style) null;
  }

  private void AcpListBoxItemExp_Loaded(object sender, RoutedEventArgs e)
  {
    this.Unselected += new RoutedEventHandler(this.AcpListBoxItemExp_Unselected);
  }

  private void AcpListBoxItemExp_Unloaded(object sender, RoutedEventArgs e)
  {
    this.Unselected -= new RoutedEventHandler(this.AcpListBoxItemExp_Unselected);
  }
}
