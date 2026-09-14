// Decompiled with JetBrains decompiler
// Type: AcpUI.AcpTableTextBoxDecHex
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

using AcpBusinessLayer;
using AcpUILib;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

#nullable disable
namespace AcpUI;

public class AcpTableTextBoxDecHex : 
  Control,
  IAcpUICtrlBase,
  IAcpUIValueCtrlBase<string>,
  IAcpUIParentCtrlBase,
  IAcpUIChildCtrlBase,
  IAcpUICommon,
  ISupportsTextBoxMember
{
  public static readonly DependencyProperty IsAcpValidProperty = DependencyProperty.Register(nameof (IsAcpValid), typeof (bool), typeof (AcpTableTextBoxDecHex), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty IsAcpApplicableProperty = DependencyProperty.Register(nameof (IsAcpApplicable), typeof (bool), typeof (AcpTableTextBoxDecHex), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty IsAcpEditableProperty = DependencyProperty.Register(nameof (IsAcpEditable), typeof (bool), typeof (AcpTableTextBoxDecHex), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty IsAcpVisibleProperty = DependencyProperty.Register(nameof (IsAcpVisible), typeof (bool), typeof (AcpTableTextBoxDecHex), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty MyLabelCtrlProperty = DependencyProperty.RegisterAttached(nameof (MyLabelCtrl), typeof (IAcpUIChildCtrlBase), typeof (AcpTableTextBoxDecHex), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty MyCopyButtonProperty = DependencyProperty.RegisterAttached(nameof (MyCopyButtonCtrl), typeof (IAcpUIChildCtrlBase), typeof (AcpTableTextBoxDecHex), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty MyBLObjectProperty = DependencyProperty.RegisterAttached(nameof (MyBLObject), typeof (AcpFieldBase), typeof (AcpTableTextBoxDecHex), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty AreValuesEqualProperty = DependencyProperty.Register(nameof (AreValuesEqual), typeof (bool), typeof (AcpTableTextBoxDecHex), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty MyExpanderProperty = DependencyProperty.RegisterAttached(nameof (MyExpander), typeof (Expander), typeof (AcpTableTextBoxDecHex), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty MyParentCtrlProperty = DependencyProperty.RegisterAttached(nameof (MyParentCtrl), typeof (IAcpUIParentCtrlBase), typeof (AcpTableTextBoxDecHex), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty TextProperty = DependencyProperty.Register(nameof (Text), typeof (string), typeof (AcpTableTextBoxDecHex), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty HexTextProperty = DependencyProperty.Register(nameof (HexText), typeof (string), typeof (AcpTableTextBoxDecHex), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

  public AcpTableTextBoxDecHex() => this.Focusable = true;

  public string Value
  {
    get => this.Text;
    set => this.Text = value;
  }

  public bool IsAcpValid
  {
    get => (bool) this.GetValue(AcpTableTextBoxDecHex.IsAcpValidProperty);
    set => this.SetValue(AcpTableTextBoxDecHex.IsAcpValidProperty, (object) value);
  }

  public bool IsAcpApplicable
  {
    get => (bool) this.GetValue(AcpTableTextBoxDecHex.IsAcpApplicableProperty);
    set => this.SetValue(AcpTableTextBoxDecHex.IsAcpApplicableProperty, (object) value);
  }

  public bool IsAcpEditable
  {
    get => (bool) this.GetValue(AcpTableTextBoxDecHex.IsAcpEditableProperty);
    set => this.SetValue(AcpTableTextBoxDecHex.IsAcpEditableProperty, (object) value);
  }

  public bool IsAcpVisible
  {
    get => (bool) this.GetValue(AcpTableTextBoxDecHex.IsAcpVisibleProperty);
    set => this.SetValue(AcpTableTextBoxDecHex.IsAcpVisibleProperty, (object) value);
  }

  public IAcpUIChildCtrlBase MyLabelCtrl
  {
    get => (IAcpUIChildCtrlBase) this.GetValue(AcpTableTextBoxDecHex.MyLabelCtrlProperty);
    set => this.SetValue(AcpTableTextBoxDecHex.MyLabelCtrlProperty, (object) value);
  }

  public IAcpUIChildCtrlBase MyCopyButtonCtrl
  {
    get => (IAcpUIChildCtrlBase) this.GetValue(AcpTableTextBoxDecHex.MyCopyButtonProperty);
    set => this.SetValue(AcpTableTextBoxDecHex.MyCopyButtonProperty, (object) value);
  }

  public AcpFieldBase MyBLObject
  {
    get => (AcpFieldBase) this.GetValue(AcpTableTextBoxDecHex.MyBLObjectProperty);
    set => this.SetValue(AcpTableTextBoxDecHex.MyBLObjectProperty, (object) value);
  }

  public bool AreValuesEqual
  {
    get => (bool) this.GetValue(AcpTableTextBoxDecHex.AreValuesEqualProperty);
    set => this.SetValue(AcpTableTextBoxDecHex.AreValuesEqualProperty, (object) value);
  }

  public Expander MyExpander
  {
    get => (Expander) this.GetValue(AcpTableTextBoxDecHex.MyExpanderProperty);
    set => this.SetValue(AcpTableTextBoxDecHex.MyExpanderProperty, (object) value);
  }

  public IAcpUIParentCtrlBase MyParentCtrl
  {
    get => (IAcpUIParentCtrlBase) this.GetValue(AcpTableTextBoxDecHex.MyParentCtrlProperty);
    set => this.SetValue(AcpTableTextBoxDecHex.MyParentCtrlProperty, (object) value);
  }

  public string Text
  {
    get => (string) this.GetValue(AcpTableTextBoxDecHex.TextProperty);
    set => this.SetValue(AcpTableTextBoxDecHex.TextProperty, (object) value);
  }

  public string HexText
  {
    get => (string) this.GetValue(AcpTableTextBoxDecHex.HexTextProperty);
    set => this.SetValue(AcpTableTextBoxDecHex.HexTextProperty, (object) value);
  }

  private void OnKeyPressUpDownNoAction(object sender, KeyEventArgs e)
  {
    switch (e.Key)
    {
      case Key.Up:
      case Key.Down:
        e.Handled = true;
        break;
    }
  }

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
