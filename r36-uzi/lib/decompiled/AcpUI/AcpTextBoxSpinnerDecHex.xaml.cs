// Decompiled with JetBrains decompiler
// Type: AcpUI.AcpTextBoxSpinnerDecHex
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

using AcpBusinessLayer;
using AcpUI.Common;
using AcpUILib;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Markup;

#nullable disable
namespace AcpUI;

public partial class AcpTextBoxSpinnerDecHex : 
  UserControl,
  IAcpUICtrlBase,
  IAcpUIValueCtrlBase<string>,
  IAcpUIParentCtrlBase,
  IAcpUIChildCtrlBase,
  IAcpUICommon,
  ISupportsTextBoxMember,
  IComponentConnector
{
  public static readonly DependencyProperty IsAcpValidProperty = DependencyProperty.Register(nameof (IsAcpValid), typeof (bool), typeof (AcpTextBoxSpinnerDecHex), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty IsAcpApplicableProperty = DependencyProperty.Register(nameof (IsAcpApplicable), typeof (bool), typeof (AcpTextBoxSpinnerDecHex), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty IsAcpEditableProperty = DependencyProperty.Register(nameof (IsAcpEditable), typeof (bool), typeof (AcpTextBoxSpinnerDecHex), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty IsAcpVisibleProperty = DependencyProperty.Register(nameof (IsAcpVisible), typeof (bool), typeof (AcpTextBoxSpinnerDecHex), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty MyLabelCtrlProperty = DependencyProperty.RegisterAttached(nameof (MyLabelCtrl), typeof (IAcpUIChildCtrlBase), typeof (AcpTextBoxSpinnerDecHex), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty MyCopyButtonProperty = DependencyProperty.RegisterAttached(nameof (MyCopyButtonCtrl), typeof (IAcpUIChildCtrlBase), typeof (AcpTextBoxSpinnerDecHex), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty MyBLObjectProperty = DependencyProperty.RegisterAttached(nameof (MyBLObject), typeof (AcpFieldBase), typeof (AcpTextBoxSpinnerDecHex), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty AreValuesEqualProperty = DependencyProperty.Register(nameof (AreValuesEqual), typeof (bool), typeof (AcpTextBoxSpinnerDecHex), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty MyExpanderProperty = DependencyProperty.RegisterAttached(nameof (MyExpander), typeof (Expander), typeof (AcpTextBoxSpinnerDecHex), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty MyParentCtrlProperty = DependencyProperty.RegisterAttached(nameof (MyParentCtrl), typeof (IAcpUIParentCtrlBase), typeof (AcpTextBoxSpinnerDecHex), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty TextProperty = DependencyProperty.Register(nameof (Text), typeof (string), typeof (AcpTextBoxSpinnerDecHex), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty HexTextProperty = DependencyProperty.Register(nameof (HexText), typeof (string), typeof (AcpTextBoxSpinnerDecHex), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  internal AcpTextBox AcpTextBoxMemberDec;
  internal AcpTextBox AcpTextBoxMemberHex;
  internal RepeatButton UpClick;
  internal RepeatButton DownClick;
  private bool _contentLoaded;

  public string Value
  {
    get => this.Text;
    set => this.Text = value;
  }

  public bool IsAcpValid
  {
    get => (bool) this.GetValue(AcpTextBoxSpinnerDecHex.IsAcpValidProperty);
    set => this.SetValue(AcpTextBoxSpinnerDecHex.IsAcpValidProperty, (object) value);
  }

  public bool IsAcpApplicable
  {
    get => (bool) this.GetValue(AcpTextBoxSpinnerDecHex.IsAcpApplicableProperty);
    set => this.SetValue(AcpTextBoxSpinnerDecHex.IsAcpApplicableProperty, (object) value);
  }

  public bool IsAcpEditable
  {
    get => (bool) this.GetValue(AcpTextBoxSpinnerDecHex.IsAcpEditableProperty);
    set => this.SetValue(AcpTextBoxSpinnerDecHex.IsAcpEditableProperty, (object) value);
  }

  public bool IsAcpVisible
  {
    get => (bool) this.GetValue(AcpTextBoxSpinnerDecHex.IsAcpVisibleProperty);
    set => this.SetValue(AcpTextBoxSpinnerDecHex.IsAcpVisibleProperty, (object) value);
  }

  public IAcpUIChildCtrlBase MyLabelCtrl
  {
    get => (IAcpUIChildCtrlBase) this.GetValue(AcpTextBoxSpinnerDecHex.MyLabelCtrlProperty);
    set => this.SetValue(AcpTextBoxSpinnerDecHex.MyLabelCtrlProperty, (object) value);
  }

  public IAcpUIChildCtrlBase MyCopyButtonCtrl
  {
    get => (IAcpUIChildCtrlBase) this.GetValue(AcpTextBoxSpinnerDecHex.MyCopyButtonProperty);
    set => this.SetValue(AcpTextBoxSpinnerDecHex.MyCopyButtonProperty, (object) value);
  }

  public AcpFieldBase MyBLObject
  {
    get => (AcpFieldBase) this.GetValue(AcpTextBoxSpinnerDecHex.MyBLObjectProperty);
    set => this.SetValue(AcpTextBoxSpinnerDecHex.MyBLObjectProperty, (object) value);
  }

  public bool AreValuesEqual
  {
    get => (bool) this.GetValue(AcpTextBoxSpinnerDecHex.AreValuesEqualProperty);
    set => this.SetValue(AcpTextBoxSpinnerDecHex.AreValuesEqualProperty, (object) value);
  }

  public Expander MyExpander
  {
    get => (Expander) this.GetValue(AcpTextBoxSpinnerDecHex.MyExpanderProperty);
    set => this.SetValue(AcpTextBoxSpinnerDecHex.MyExpanderProperty, (object) value);
  }

  public IAcpUIParentCtrlBase MyParentCtrl
  {
    get => (IAcpUIParentCtrlBase) this.GetValue(AcpTextBoxSpinnerDecHex.MyParentCtrlProperty);
    set => this.SetValue(AcpTextBoxSpinnerDecHex.MyParentCtrlProperty, (object) value);
  }

  public string Text
  {
    get => (string) this.GetValue(AcpTextBoxSpinnerDecHex.TextProperty);
    set => this.SetValue(AcpTextBoxSpinnerDecHex.TextProperty, (object) value);
  }

  public string HexText
  {
    get => (string) this.GetValue(AcpTextBoxSpinnerDecHex.HexTextProperty);
    set => this.SetValue(AcpTextBoxSpinnerDecHex.HexTextProperty, (object) value);
  }

  private void OnClick(object sender, RoutedEventArgs e)
  {
    StepUpDownUtility.OnClick(sender, this.MyBLObject);
  }

  private void OnKeyPressUpDownEvent(object sender, KeyEventArgs e)
  {
    StepUpDownUtility.OnKeyPress(e, this.MyBLObject);
  }

  public AcpTextBoxSpinnerDecHex()
  {
    this.InitializeComponent();
    this.Focusable = true;
  }

  protected override void OnGotFocus(RoutedEventArgs e) => this.AcpTextBoxMemberDec.Focus();

  AcpTextBox ISupportsTextBoxMember.TextBoxMember => this.AcpTextBoxMemberDec;

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "8.0.3.0")]
  public void InitializeComponent()
  {
    if (this._contentLoaded)
      return;
    this._contentLoaded = true;
    Application.LoadComponent((object) this, new Uri("/AcpUI;component/acptextboxspinnerdechex.xaml", UriKind.Relative));
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
    switch (connectionId)
    {
      case 1:
        this.AcpTextBoxMemberDec = (AcpTextBox) target;
        break;
      case 2:
        this.AcpTextBoxMemberHex = (AcpTextBox) target;
        break;
      case 3:
        this.UpClick = (RepeatButton) target;
        this.UpClick.Click += new RoutedEventHandler(this.OnClick);
        break;
      case 4:
        this.DownClick = (RepeatButton) target;
        this.DownClick.Click += new RoutedEventHandler(this.OnClick);
        break;
      default:
        this._contentLoaded = true;
        break;
    }
  }
}
