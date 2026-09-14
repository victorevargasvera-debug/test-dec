// Decompiled with JetBrains decompiler
// Type: AcpUI.AcpTextBox
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

public class AcpTextBox : 
  TextBox,
  IAcpUICtrlBase,
  IAcpUIValueCtrlBase<string>,
  IAcpUIParentCtrlBase,
  IAcpUIChildCtrlBase,
  IAcpUICommon,
  ISupportsTextBoxMember
{
  public static readonly DependencyProperty IsAcpValidProperty = DependencyProperty.Register(nameof (IsAcpValid), typeof (bool), typeof (AcpTextBox), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty IsAcpApplicableProperty = DependencyProperty.Register(nameof (IsAcpApplicable), typeof (bool), typeof (AcpTextBox), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty IsAcpEditableProperty = DependencyProperty.Register(nameof (IsAcpEditable), typeof (bool), typeof (AcpTextBox), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty IsAcpVisibleProperty = DependencyProperty.Register(nameof (IsAcpVisible), typeof (bool), typeof (AcpTextBox), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty MyLabelCtrlProperty = DependencyProperty.RegisterAttached(nameof (MyLabelCtrl), typeof (IAcpUIChildCtrlBase), typeof (AcpTextBox), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty MyCopyButtonProperty = DependencyProperty.RegisterAttached(nameof (MyCopyButtonCtrl), typeof (IAcpUIChildCtrlBase), typeof (AcpTextBox), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty MyBLObjectProperty = DependencyProperty.RegisterAttached(nameof (MyBLObject), typeof (AcpFieldBase), typeof (AcpTextBox), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty AreValuesEqualProperty = DependencyProperty.Register(nameof (AreValuesEqual), typeof (bool), typeof (AcpTextBox), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty MyExpanderProperty = DependencyProperty.RegisterAttached(nameof (MyExpander), typeof (Expander), typeof (AcpTextBox), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty MyParentCtrlProperty = DependencyProperty.RegisterAttached(nameof (MyParentCtrl), typeof (IAcpUIParentCtrlBase), typeof (AcpTextBox), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty MaskTypeProperty = DependencyProperty.Register(nameof (MaskType), typeof (string), typeof (AcpTextBox), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(AcpTextBox.MaskTypePropertyChanged)));
  public static bool DisableMask = false;
  public static bool DisableIPMask = false;
  public static readonly DependencyProperty IsMaskedProperty = DependencyProperty.Register(nameof (IsMasked), typeof (bool), typeof (AcpTextBox), (PropertyMetadata) new FrameworkPropertyMetadata((object) false, FrameworkPropertyMetadataOptions.AffectsRender));

  public string Value
  {
    get => this.Text;
    set
    {
      this.Text = value;
      this.GetBindingExpression(TextBox.TextProperty).UpdateSource();
    }
  }

  public bool IsAcpValid
  {
    get => (bool) this.GetValue(AcpTextBox.IsAcpValidProperty);
    set => this.SetValue(AcpTextBox.IsAcpValidProperty, (object) value);
  }

  public bool IsAcpApplicable
  {
    get => (bool) this.GetValue(AcpTextBox.IsAcpApplicableProperty);
    set => this.SetValue(AcpTextBox.IsAcpApplicableProperty, (object) value);
  }

  public bool IsAcpEditable
  {
    get => (bool) this.GetValue(AcpTextBox.IsAcpEditableProperty);
    set => this.SetValue(AcpTextBox.IsAcpEditableProperty, (object) value);
  }

  public bool IsAcpVisible
  {
    get => (bool) this.GetValue(AcpTextBox.IsAcpVisibleProperty);
    set => this.SetValue(AcpTextBox.IsAcpVisibleProperty, (object) value);
  }

  public IAcpUIChildCtrlBase MyLabelCtrl
  {
    get => (IAcpUIChildCtrlBase) this.GetValue(AcpTextBox.MyLabelCtrlProperty);
    set => this.SetValue(AcpTextBox.MyLabelCtrlProperty, (object) value);
  }

  public IAcpUIChildCtrlBase MyCopyButtonCtrl
  {
    get => (IAcpUIChildCtrlBase) this.GetValue(AcpTextBox.MyCopyButtonProperty);
    set => this.SetValue(AcpTextBox.MyCopyButtonProperty, (object) value);
  }

  public AcpFieldBase MyBLObject
  {
    get => (AcpFieldBase) this.GetValue(AcpTextBox.MyBLObjectProperty);
    set => this.SetValue(AcpTextBox.MyBLObjectProperty, (object) value);
  }

  public bool AreValuesEqual
  {
    get => (bool) this.GetValue(AcpTextBox.AreValuesEqualProperty);
    set => this.SetValue(AcpTextBox.AreValuesEqualProperty, (object) value);
  }

  public Expander MyExpander
  {
    get => (Expander) this.GetValue(AcpTextBox.MyExpanderProperty);
    set => this.SetValue(AcpTextBox.MyExpanderProperty, (object) value);
  }

  public IAcpUIParentCtrlBase MyParentCtrl
  {
    get => (IAcpUIParentCtrlBase) this.GetValue(AcpTextBox.MyParentCtrlProperty);
    set => this.SetValue(AcpTextBox.MyParentCtrlProperty, (object) value);
  }

  public string MaskType
  {
    get => (string) this.GetValue(AcpTextBox.MaskTypeProperty);
    set => this.SetValue(AcpTextBox.MaskTypeProperty, (object) value);
  }

  private static void MaskTypePropertyChanged(
    DependencyObject sender,
    DependencyPropertyChangedEventArgs args)
  {
    if (!(sender is AcpTextBox))
      return;
    AcpTextBox acpTextBox = (AcpTextBox) sender;
    string newValue = (string) args.NewValue;
    acpTextBox.IsMasked = !string.IsNullOrEmpty(newValue);
    if (AcpTextBox.DisableMask && newValue != null && newValue.Contains("a-zA-Z") && newValue != "{char:8:0-9a-zA-Z/* #-}")
      acpTextBox.IsMasked = false;
    if (!AcpTextBox.DisableIPMask || newValue == null || !newValue.Contains("{number:0-255}.{number:0-255}.{number:0-255}"))
      return;
    acpTextBox.IsMasked = false;
  }

  public bool IsMasked
  {
    get => (bool) this.GetValue(AcpTextBox.IsMaskedProperty);
    set => this.SetValue(AcpTextBox.IsMaskedProperty, (object) value);
  }

  protected override void OnTextChanged(TextChangedEventArgs e)
  {
    string text = this.Text;
    if (!string.IsNullOrEmpty(text))
    {
      string str = Utility.FilterArabicDiacritics(text);
      if (str != this.Text)
        this.Text = str;
    }
    base.OnTextChanged(e);
  }

  public TChild FindVisualChild<TChild>(DependencyObject obj) where TChild : DependencyObject
  {
    for (int childIndex = 0; childIndex < VisualTreeHelper.GetChildrenCount(obj); ++childIndex)
    {
      DependencyObject child = VisualTreeHelper.GetChild(obj, childIndex);
      if (child != null && child is TChild visualChild1)
        return visualChild1;
      TChild visualChild2 = this.FindVisualChild<TChild>(child);
      if ((object) visualChild2 != null)
        return visualChild2;
    }
    return default (TChild);
  }

  public static T FindVisualParent<T>(UIElement element) where T : UIElement
  {
    for (UIElement reference = element; reference != null; reference = VisualTreeHelper.GetParent((DependencyObject) reference) as UIElement)
    {
      if (reference is T visualParent)
        return visualParent;
    }
    return default (T);
  }

  public static T GetElementUnderMouse<T>() where T : UIElement
  {
    return AcpTextBox.FindVisualParent<T>(Mouse.DirectlyOver as UIElement);
  }

  public AcpTextBox()
  {
    this.VerticalAlignment = VerticalAlignment.Center;
    this.ContextMenu = (ContextMenu) null;
  }

  AcpTextBox ISupportsTextBoxMember.TextBoxMember => this;
}
