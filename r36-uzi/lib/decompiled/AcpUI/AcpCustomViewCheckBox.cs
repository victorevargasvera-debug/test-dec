// Decompiled with JetBrains decompiler
// Type: AcpUI.AcpCustomViewCheckBox
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

using AcpUILib;
using System.Windows;
using System.Windows.Controls;

#nullable disable
namespace AcpUI;

public class AcpCustomViewCheckBox : CheckBox, IAcpUICtrlBase, IAcpUIChildCtrlBase
{
  public static readonly DependencyProperty IsAcpValidProperty = DependencyProperty.Register(nameof (IsAcpValid), typeof (bool), typeof (AcpCustomViewCheckBox), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty IsAcpApplicableProperty = DependencyProperty.Register(nameof (IsAcpApplicable), typeof (bool), typeof (AcpCustomViewCheckBox), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty IsAcpEditableProperty = DependencyProperty.Register(nameof (IsAcpEditable), typeof (bool), typeof (AcpCustomViewCheckBox), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty IsAcpVisibleProperty = DependencyProperty.Register(nameof (IsAcpVisible), typeof (bool), typeof (AcpCustomViewCheckBox), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty MyParentCtrlProperty = DependencyProperty.RegisterAttached(nameof (MyParentCtrl), typeof (IAcpUIParentCtrlBase), typeof (AcpCustomViewCheckBox), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender));

  public bool IsAcpValid
  {
    get => (bool) this.GetValue(AcpCustomViewCheckBox.IsAcpValidProperty);
    set => this.SetValue(AcpCustomViewCheckBox.IsAcpValidProperty, (object) value);
  }

  public bool IsAcpApplicable
  {
    get => (bool) this.GetValue(AcpCustomViewCheckBox.IsAcpApplicableProperty);
    set => this.SetValue(AcpCustomViewCheckBox.IsAcpApplicableProperty, (object) value);
  }

  public bool IsAcpEditable
  {
    get => (bool) this.GetValue(AcpCustomViewCheckBox.IsAcpEditableProperty);
    set => this.SetValue(AcpCustomViewCheckBox.IsAcpEditableProperty, (object) value);
  }

  public bool IsAcpVisible
  {
    get => (bool) this.GetValue(AcpCustomViewCheckBox.IsAcpVisibleProperty);
    set => this.SetValue(AcpCustomViewCheckBox.IsAcpVisibleProperty, (object) value);
  }

  public IAcpUIParentCtrlBase MyParentCtrl
  {
    get => (IAcpUIParentCtrlBase) this.GetValue(AcpCustomViewCheckBox.MyParentCtrlProperty);
    set => this.SetValue(AcpCustomViewCheckBox.MyParentCtrlProperty, (object) value);
  }

  public AcpCustomViewCheckBox()
  {
    this.Loaded += new RoutedEventHandler(this.AcpCustomViewCheckBox_Loaded);
    this.Unloaded += new RoutedEventHandler(this.AcpCustomViewCheckBox_Unloaded);
  }

  private void AcpCustomViewCheckBox_Loaded(object sender, RoutedEventArgs e)
  {
    this.Click += new RoutedEventHandler(this.AcpCustomViewCheckBox_Click);
  }

  private void AcpCustomViewCheckBox_Unloaded(object sender, RoutedEventArgs e)
  {
    this.Click -= new RoutedEventHandler(this.AcpCustomViewCheckBox_Click);
  }

  private void AcpCustomViewCheckBox_Click(object sender, RoutedEventArgs e)
  {
    if (this.MyParentCtrl == null || this.MyParentCtrl.MyBLObject == null)
      return;
    if (this.IsChecked.Value)
      this.MyParentCtrl.MyBLObject.CustomViewVisibility = true;
    else
      this.MyParentCtrl.MyBLObject.CustomViewVisibility = false;
    e.Handled = true;
  }
}
