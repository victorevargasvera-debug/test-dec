// Decompiled with JetBrains decompiler
// Type: AcpUI.AcpTextBoxDecHex
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

using AcpBusinessLayer;
using AcpUILib;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;

#nullable disable
namespace AcpUI;

public partial class AcpTextBoxDecHex : 
  UserControl,
  IAcpUICtrlBase,
  IAcpUIValueCtrlBase<string>,
  IAcpUIParentCtrlBase,
  IAcpUIChildCtrlBase,
  IAcpUICommon,
  ISupportsTextBoxMember,
  IComponentConnector
{
  public static readonly DependencyProperty IsAcpValidProperty = DependencyProperty.Register(nameof (IsAcpValid), typeof (bool), typeof (AcpTextBoxDecHex), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty IsAcpApplicableProperty = DependencyProperty.Register(nameof (IsAcpApplicable), typeof (bool), typeof (AcpTextBoxDecHex), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty IsAcpEditableProperty = DependencyProperty.Register(nameof (IsAcpEditable), typeof (bool), typeof (AcpTextBoxDecHex), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty IsAcpVisibleProperty = DependencyProperty.Register(nameof (IsAcpVisible), typeof (bool), typeof (AcpTextBoxDecHex), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty MyLabelCtrlProperty = DependencyProperty.RegisterAttached(nameof (MyLabelCtrl), typeof (IAcpUIChildCtrlBase), typeof (AcpTextBoxDecHex), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty MyCopyButtonProperty = DependencyProperty.RegisterAttached(nameof (MyCopyButtonCtrl), typeof (IAcpUIChildCtrlBase), typeof (AcpTextBoxDecHex), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty MyBLObjectProperty = DependencyProperty.RegisterAttached(nameof (MyBLObject), typeof (AcpFieldBase), typeof (AcpTextBoxDecHex), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty AreValuesEqualProperty = DependencyProperty.Register(nameof (AreValuesEqual), typeof (bool), typeof (AcpTextBoxDecHex), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty MyExpanderProperty = DependencyProperty.RegisterAttached(nameof (MyExpander), typeof (Expander), typeof (AcpTextBoxDecHex), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty MyParentCtrlProperty = DependencyProperty.RegisterAttached(nameof (MyParentCtrl), typeof (IAcpUIParentCtrlBase), typeof (AcpTextBoxDecHex), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty TextProperty = DependencyProperty.Register(nameof (Text), typeof (string), typeof (AcpTextBoxDecHex), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty HexTextProperty = DependencyProperty.Register(nameof (HexText), typeof (string), typeof (AcpTextBoxDecHex), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  internal AcpTextBox AcpTextBoxMemberDec;
  internal AcpTextBox AcpTextBoxMemberHex;
  private bool _contentLoaded;

  public string Value
  {
    get => this.Text;
    set => this.Text = value;
  }

  public bool IsAcpValid
  {
    get => (bool) this.GetValue(AcpTextBoxDecHex.IsAcpValidProperty);
    set => this.SetValue(AcpTextBoxDecHex.IsAcpValidProperty, (object) value);
  }

  public bool IsAcpApplicable
  {
    get => (bool) this.GetValue(AcpTextBoxDecHex.IsAcpApplicableProperty);
    set => this.SetValue(AcpTextBoxDecHex.IsAcpApplicableProperty, (object) value);
  }

  public bool IsAcpEditable
  {
    get => (bool) this.GetValue(AcpTextBoxDecHex.IsAcpEditableProperty);
    set => this.SetValue(AcpTextBoxDecHex.IsAcpEditableProperty, (object) value);
  }

  public bool IsAcpVisible
  {
    get => (bool) this.GetValue(AcpTextBoxDecHex.IsAcpVisibleProperty);
    set => this.SetValue(AcpTextBoxDecHex.IsAcpVisibleProperty, (object) value);
  }

  public IAcpUIChildCtrlBase MyLabelCtrl
  {
    get => (IAcpUIChildCtrlBase) this.GetValue(AcpTextBoxDecHex.MyLabelCtrlProperty);
    set => this.SetValue(AcpTextBoxDecHex.MyLabelCtrlProperty, (object) value);
  }

  public IAcpUIChildCtrlBase MyCopyButtonCtrl
  {
    get => (IAcpUIChildCtrlBase) this.GetValue(AcpTextBoxDecHex.MyCopyButtonProperty);
    set => this.SetValue(AcpTextBoxDecHex.MyCopyButtonProperty, (object) value);
  }

  public AcpFieldBase MyBLObject
  {
    get => (AcpFieldBase) this.GetValue(AcpTextBoxDecHex.MyBLObjectProperty);
    set => this.SetValue(AcpTextBoxDecHex.MyBLObjectProperty, (object) value);
  }

  public bool AreValuesEqual
  {
    get => (bool) this.GetValue(AcpTextBoxDecHex.AreValuesEqualProperty);
    set => this.SetValue(AcpTextBoxDecHex.AreValuesEqualProperty, (object) value);
  }

  public Expander MyExpander
  {
    get => (Expander) this.GetValue(AcpTextBoxDecHex.MyExpanderProperty);
    set => this.SetValue(AcpTextBoxDecHex.MyExpanderProperty, (object) value);
  }

  public IAcpUIParentCtrlBase MyParentCtrl
  {
    get => (IAcpUIParentCtrlBase) this.GetValue(AcpTextBoxDecHex.MyParentCtrlProperty);
    set => this.SetValue(AcpTextBoxDecHex.MyParentCtrlProperty, (object) value);
  }

  public string Text
  {
    get => (string) this.GetValue(AcpTextBoxDecHex.TextProperty);
    set => this.SetValue(AcpTextBoxDecHex.TextProperty, (object) value);
  }

  public string HexText
  {
    get => (string) this.GetValue(AcpTextBoxDecHex.HexTextProperty);
    set => this.SetValue(AcpTextBoxDecHex.HexTextProperty, (object) value);
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

  protected override void OnGotFocus(RoutedEventArgs e) => this.AcpTextBoxMemberDec.Focus();

  public AcpTextBoxDecHex()
  {
    this.InitializeComponent();
    this.Focusable = true;
  }

  AcpTextBox ISupportsTextBoxMember.TextBoxMember => this.AcpTextBoxMemberDec;

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "8.0.3.0")]
  public void InitializeComponent()
  {
    if (this._contentLoaded)
      return;
    this._contentLoaded = true;
    Application.LoadComponent((object) this, new Uri("/AcpUI;component/acptextboxdechex.xaml", UriKind.Relative));
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "8.0.3.0")]
  internal Delegate _CreateDelegate(Type delegateType, string handler)
  {
    return Delegate.CreateDelegate(delegateType, (object) this, handler);
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "8.0.3.0")]
  [EditorBrowsable(EditorBrowsableState.Never)]
  void IComponentConnector.Connect(int connectionId, object target)
  {
    if (connectionId != 1)
    {
      if (connectionId == 2)
        this.AcpTextBoxMemberHex = (AcpTextBox) target;
      else
        this._contentLoaded = true;
    }
    else
      this.AcpTextBoxMemberDec = (AcpTextBox) target;
  }
}
