// Decompiled with JetBrains decompiler
// Type: AcpUI.AcpTableTextBoxSpinner
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

using AcpBusinessLayer;
using AcpUI.Common;
using AcpUILib;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

#nullable disable
namespace AcpUI;

public class AcpTableTextBoxSpinner : 
  Control,
  IAcpUICtrlBase,
  IAcpUIValueCtrlBase<string>,
  IAcpUIParentCtrlBase,
  IAcpUIChildCtrlBase,
  IAcpUICommon,
  ISupportsTextBoxMember
{
  public static readonly DependencyProperty IsAcpValidProperty = DependencyProperty.Register(nameof (IsAcpValid), typeof (bool), typeof (AcpTableTextBoxSpinner), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty IsAcpApplicableProperty = DependencyProperty.Register(nameof (IsAcpApplicable), typeof (bool), typeof (AcpTableTextBoxSpinner), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty IsAcpEditableProperty = DependencyProperty.Register(nameof (IsAcpEditable), typeof (bool), typeof (AcpTableTextBoxSpinner), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty IsAcpVisibleProperty = DependencyProperty.Register(nameof (IsAcpVisible), typeof (bool), typeof (AcpTableTextBoxSpinner), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty MyLabelCtrlProperty = DependencyProperty.RegisterAttached(nameof (MyLabelCtrl), typeof (IAcpUIChildCtrlBase), typeof (AcpTableTextBoxSpinner), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty MyCopyButtonProperty = DependencyProperty.RegisterAttached(nameof (MyCopyButtonCtrl), typeof (IAcpUIChildCtrlBase), typeof (AcpTableTextBoxSpinner), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty MyBLObjectProperty = DependencyProperty.RegisterAttached(nameof (MyBLObject), typeof (AcpFieldBase), typeof (AcpTableTextBoxSpinner), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty AreValuesEqualProperty = DependencyProperty.Register(nameof (AreValuesEqual), typeof (bool), typeof (AcpTableTextBoxSpinner), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty MyExpanderProperty = DependencyProperty.RegisterAttached(nameof (MyExpander), typeof (Expander), typeof (AcpTableTextBoxSpinner), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty MyParentCtrlProperty = DependencyProperty.RegisterAttached(nameof (MyParentCtrl), typeof (IAcpUIParentCtrlBase), typeof (AcpTableTextBoxSpinner), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty TextProperty = DependencyProperty.Register(nameof (Text), typeof (string), typeof (AcpTableTextBoxSpinner), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  private string maskTypeSpinner;

  public string Value
  {
    get => this.Text;
    set => this.Text = value;
  }

  public bool IsAcpValid
  {
    get => (bool) this.GetValue(AcpTableTextBoxSpinner.IsAcpValidProperty);
    set => this.SetValue(AcpTableTextBoxSpinner.IsAcpValidProperty, (object) value);
  }

  public bool IsAcpApplicable
  {
    get => (bool) this.GetValue(AcpTableTextBoxSpinner.IsAcpApplicableProperty);
    set => this.SetValue(AcpTableTextBoxSpinner.IsAcpApplicableProperty, (object) value);
  }

  public bool IsAcpEditable
  {
    get => (bool) this.GetValue(AcpTableTextBoxSpinner.IsAcpEditableProperty);
    set => this.SetValue(AcpTableTextBoxSpinner.IsAcpEditableProperty, (object) value);
  }

  public bool IsAcpVisible
  {
    get => (bool) this.GetValue(AcpTableTextBoxSpinner.IsAcpVisibleProperty);
    set => this.SetValue(AcpTableTextBoxSpinner.IsAcpVisibleProperty, (object) value);
  }

  public IAcpUIChildCtrlBase MyLabelCtrl
  {
    get => (IAcpUIChildCtrlBase) this.GetValue(AcpTableTextBoxSpinner.MyLabelCtrlProperty);
    set => this.SetValue(AcpTableTextBoxSpinner.MyLabelCtrlProperty, (object) value);
  }

  public IAcpUIChildCtrlBase MyCopyButtonCtrl
  {
    get => (IAcpUIChildCtrlBase) this.GetValue(AcpTableTextBoxSpinner.MyCopyButtonProperty);
    set => this.SetValue(AcpTableTextBoxSpinner.MyCopyButtonProperty, (object) value);
  }

  public AcpFieldBase MyBLObject
  {
    get => (AcpFieldBase) this.GetValue(AcpTableTextBoxSpinner.MyBLObjectProperty);
    set => this.SetValue(AcpTableTextBoxSpinner.MyBLObjectProperty, (object) value);
  }

  public bool AreValuesEqual
  {
    get => (bool) this.GetValue(AcpTableTextBoxSpinner.AreValuesEqualProperty);
    set => this.SetValue(AcpTableTextBoxSpinner.AreValuesEqualProperty, (object) value);
  }

  public Expander MyExpander
  {
    get => (Expander) this.GetValue(AcpTableTextBoxSpinner.MyExpanderProperty);
    set => this.SetValue(AcpTableTextBoxSpinner.MyExpanderProperty, (object) value);
  }

  public IAcpUIParentCtrlBase MyParentCtrl
  {
    get => (IAcpUIParentCtrlBase) this.GetValue(AcpTableTextBoxSpinner.MyParentCtrlProperty);
    set => this.SetValue(AcpTableTextBoxSpinner.MyParentCtrlProperty, (object) value);
  }

  public string Text
  {
    get => (string) this.GetValue(AcpTableTextBoxSpinner.TextProperty);
    set => this.SetValue(AcpTableTextBoxSpinner.TextProperty, (object) value);
  }

  public string MaskTypeSpinner
  {
    get => AcpTextBox.DisableMask ? (string) null : this.maskTypeSpinner;
    set => this.maskTypeSpinner = value;
  }

  private void OnClick(object sender, RoutedEventArgs e)
  {
    StepUpDownUtility.OnClick(sender, this.MyBLObject);
  }

  private void OnLostFocus(object sender, RoutedEventArgs e)
  {
    this.Text = this.AcpTextBoxMember.Text;
  }

  private void OnKeyPressUpDownEvent(object sender, KeyEventArgs e)
  {
    StepUpDownUtility.OnKeyPress(e, this.MyBLObject);
  }

  public AcpTableTextBoxSpinner() => this.Focusable = true;

  AcpTextBox ISupportsTextBoxMember.TextBoxMember => (AcpTextBox) this.AcpTextBoxMember;

  public AcpTableTextBoxBase AcpTextBoxMember
  {
    get
    {
      return VisualTreeHelper.GetChild((DependencyObject) (VisualTreeHelper.GetChild((DependencyObject) this, 0) as UIElement), 0) as AcpTableTextBoxBase;
    }
  }
}
