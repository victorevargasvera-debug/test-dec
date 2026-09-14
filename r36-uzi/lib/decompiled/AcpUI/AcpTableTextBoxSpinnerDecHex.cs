// Decompiled with JetBrains decompiler
// Type: AcpUI.AcpTableTextBoxSpinnerDecHex
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

public class AcpTableTextBoxSpinnerDecHex : 
  Control,
  IAcpUICtrlBase,
  IAcpUIValueCtrlBase<string>,
  IAcpUIParentCtrlBase,
  IAcpUIChildCtrlBase,
  IAcpUICommon,
  ISupportsTextBoxMember
{
  public static readonly DependencyProperty IsAcpValidProperty = DependencyProperty.Register(nameof (IsAcpValid), typeof (bool), typeof (AcpTableTextBoxSpinnerDecHex), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty IsAcpApplicableProperty = DependencyProperty.Register(nameof (IsAcpApplicable), typeof (bool), typeof (AcpTableTextBoxSpinnerDecHex), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty IsAcpEditableProperty = DependencyProperty.Register(nameof (IsAcpEditable), typeof (bool), typeof (AcpTableTextBoxSpinnerDecHex), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty IsAcpVisibleProperty = DependencyProperty.Register(nameof (IsAcpVisible), typeof (bool), typeof (AcpTableTextBoxSpinnerDecHex), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty MyLabelCtrlProperty = DependencyProperty.RegisterAttached(nameof (MyLabelCtrl), typeof (IAcpUIChildCtrlBase), typeof (AcpTableTextBoxSpinnerDecHex), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty MyCopyButtonProperty = DependencyProperty.RegisterAttached(nameof (MyCopyButtonCtrl), typeof (IAcpUIChildCtrlBase), typeof (AcpTableTextBoxSpinnerDecHex), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty MyBLObjectProperty = DependencyProperty.RegisterAttached(nameof (MyBLObject), typeof (AcpFieldBase), typeof (AcpTableTextBoxSpinnerDecHex), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty AreValuesEqualProperty = DependencyProperty.Register(nameof (AreValuesEqual), typeof (bool), typeof (AcpTableTextBoxSpinnerDecHex), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty MyExpanderProperty = DependencyProperty.RegisterAttached(nameof (MyExpander), typeof (Expander), typeof (AcpTableTextBoxSpinnerDecHex), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty MyParentCtrlProperty = DependencyProperty.RegisterAttached(nameof (MyParentCtrl), typeof (IAcpUIParentCtrlBase), typeof (AcpTableTextBoxSpinnerDecHex), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty TextProperty = DependencyProperty.Register(nameof (Text), typeof (string), typeof (AcpTableTextBoxSpinnerDecHex), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty HexTextProperty = DependencyProperty.Register(nameof (HexText), typeof (string), typeof (AcpTableTextBoxSpinnerDecHex), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

  public string Value
  {
    get => this.Text;
    set => this.Text = value;
  }

  public bool IsAcpValid
  {
    get => (bool) this.GetValue(AcpTableTextBoxSpinnerDecHex.IsAcpValidProperty);
    set => this.SetValue(AcpTableTextBoxSpinnerDecHex.IsAcpValidProperty, (object) value);
  }

  public bool IsAcpApplicable
  {
    get => (bool) this.GetValue(AcpTableTextBoxSpinnerDecHex.IsAcpApplicableProperty);
    set => this.SetValue(AcpTableTextBoxSpinnerDecHex.IsAcpApplicableProperty, (object) value);
  }

  public bool IsAcpEditable
  {
    get => (bool) this.GetValue(AcpTableTextBoxSpinnerDecHex.IsAcpEditableProperty);
    set => this.SetValue(AcpTableTextBoxSpinnerDecHex.IsAcpEditableProperty, (object) value);
  }

  public bool IsAcpVisible
  {
    get => (bool) this.GetValue(AcpTableTextBoxSpinnerDecHex.IsAcpVisibleProperty);
    set => this.SetValue(AcpTableTextBoxSpinnerDecHex.IsAcpVisibleProperty, (object) value);
  }

  public IAcpUIChildCtrlBase MyLabelCtrl
  {
    get => (IAcpUIChildCtrlBase) this.GetValue(AcpTableTextBoxSpinnerDecHex.MyLabelCtrlProperty);
    set => this.SetValue(AcpTableTextBoxSpinnerDecHex.MyLabelCtrlProperty, (object) value);
  }

  public IAcpUIChildCtrlBase MyCopyButtonCtrl
  {
    get => (IAcpUIChildCtrlBase) this.GetValue(AcpTableTextBoxSpinnerDecHex.MyCopyButtonProperty);
    set => this.SetValue(AcpTableTextBoxSpinnerDecHex.MyCopyButtonProperty, (object) value);
  }

  public AcpFieldBase MyBLObject
  {
    get => (AcpFieldBase) this.GetValue(AcpTableTextBoxSpinnerDecHex.MyBLObjectProperty);
    set => this.SetValue(AcpTableTextBoxSpinnerDecHex.MyBLObjectProperty, (object) value);
  }

  public bool AreValuesEqual
  {
    get => (bool) this.GetValue(AcpTableTextBoxSpinnerDecHex.AreValuesEqualProperty);
    set => this.SetValue(AcpTableTextBoxSpinnerDecHex.AreValuesEqualProperty, (object) value);
  }

  public Expander MyExpander
  {
    get => (Expander) this.GetValue(AcpTableTextBoxSpinnerDecHex.MyExpanderProperty);
    set => this.SetValue(AcpTableTextBoxSpinnerDecHex.MyExpanderProperty, (object) value);
  }

  public IAcpUIParentCtrlBase MyParentCtrl
  {
    get => (IAcpUIParentCtrlBase) this.GetValue(AcpTableTextBoxSpinnerDecHex.MyParentCtrlProperty);
    set => this.SetValue(AcpTableTextBoxSpinnerDecHex.MyParentCtrlProperty, (object) value);
  }

  public string Text
  {
    get => (string) this.GetValue(AcpTableTextBoxSpinnerDecHex.TextProperty);
    set => this.SetValue(AcpTableTextBoxSpinnerDecHex.TextProperty, (object) value);
  }

  public string HexText
  {
    get => (string) this.GetValue(AcpTableTextBoxSpinnerDecHex.HexTextProperty);
    set => this.SetValue(AcpTableTextBoxSpinnerDecHex.HexTextProperty, (object) value);
  }

  private void OnClick(object sender, RoutedEventArgs e)
  {
    StepUpDownUtility.OnClick(sender, this.MyBLObject);
  }

  private void OnKeyPressUpDownEvent(object sender, KeyEventArgs e)
  {
    StepUpDownUtility.OnKeyPress(e, this.MyBLObject);
  }

  public AcpTableTextBoxSpinnerDecHex() => this.Focusable = true;

  AcpTextBox ISupportsTextBoxMember.TextBoxMember => (AcpTextBox) this.AcpTextBoxMemberDec;

  public AcpTableTextBoxBase AcpTextBoxMemberDec
  {
    get
    {
      return VisualTreeHelper.GetChild((DependencyObject) (VisualTreeHelper.GetChild((DependencyObject) this, 0) as UIElement), 0) as AcpTableTextBoxBase;
    }
  }

  public AcpTableTextBoxBase AcpTextBoxMemberHex
  {
    get
    {
      return VisualTreeHelper.GetChild((DependencyObject) (VisualTreeHelper.GetChild((DependencyObject) this, 0) as UIElement), 2) as AcpTableTextBoxBase;
    }
  }
}
