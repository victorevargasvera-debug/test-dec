// Decompiled with JetBrains decompiler
// Type: AcpUI.AcpTextBoxSpinner
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

public partial class AcpTextBoxSpinner : 
  UserControl,
  IAcpUICtrlBase,
  IAcpUIValueCtrlBase<string>,
  IAcpUIParentCtrlBase,
  IAcpUIChildCtrlBase,
  IAcpUICommon,
  ISupportsTextBoxMember,
  IComponentConnector
{
  public static readonly DependencyProperty IsAcpValidProperty = DependencyProperty.Register(nameof (IsAcpValid), typeof (bool), typeof (AcpTextBoxSpinner), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty IsAcpApplicableProperty = DependencyProperty.Register(nameof (IsAcpApplicable), typeof (bool), typeof (AcpTextBoxSpinner), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty IsAcpEditableProperty = DependencyProperty.Register(nameof (IsAcpEditable), typeof (bool), typeof (AcpTextBoxSpinner), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty IsAcpVisibleProperty = DependencyProperty.Register(nameof (IsAcpVisible), typeof (bool), typeof (AcpTextBoxSpinner), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty MyLabelCtrlProperty = DependencyProperty.RegisterAttached(nameof (MyLabelCtrl), typeof (IAcpUIChildCtrlBase), typeof (AcpTextBoxSpinner), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty MyCopyButtonProperty = DependencyProperty.RegisterAttached(nameof (MyCopyButtonCtrl), typeof (IAcpUIChildCtrlBase), typeof (AcpTextBoxSpinner), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty MyBLObjectProperty = DependencyProperty.RegisterAttached(nameof (MyBLObject), typeof (AcpFieldBase), typeof (AcpTextBoxSpinner), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty AreValuesEqualProperty = DependencyProperty.Register(nameof (AreValuesEqual), typeof (bool), typeof (AcpTextBoxSpinner), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty MyExpanderProperty = DependencyProperty.RegisterAttached(nameof (MyExpander), typeof (Expander), typeof (AcpTextBoxSpinner), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty MyParentCtrlProperty = DependencyProperty.RegisterAttached(nameof (MyParentCtrl), typeof (IAcpUIParentCtrlBase), typeof (AcpTextBoxSpinner), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty TextProperty = DependencyProperty.Register(nameof (Text), typeof (string), typeof (AcpTextBoxSpinner), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  private string maskTypeSpinner;
  internal AcpTextBox AcpTextBoxMember;
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
    get => (bool) this.GetValue(AcpTextBoxSpinner.IsAcpValidProperty);
    set => this.SetValue(AcpTextBoxSpinner.IsAcpValidProperty, (object) value);
  }

  public bool IsAcpApplicable
  {
    get => (bool) this.GetValue(AcpTextBoxSpinner.IsAcpApplicableProperty);
    set => this.SetValue(AcpTextBoxSpinner.IsAcpApplicableProperty, (object) value);
  }

  public bool IsAcpEditable
  {
    get => (bool) this.GetValue(AcpTextBoxSpinner.IsAcpEditableProperty);
    set => this.SetValue(AcpTextBoxSpinner.IsAcpEditableProperty, (object) value);
  }

  public bool IsAcpVisible
  {
    get => (bool) this.GetValue(AcpTextBoxSpinner.IsAcpVisibleProperty);
    set => this.SetValue(AcpTextBoxSpinner.IsAcpVisibleProperty, (object) value);
  }

  public IAcpUIChildCtrlBase MyLabelCtrl
  {
    get => (IAcpUIChildCtrlBase) this.GetValue(AcpTextBoxSpinner.MyLabelCtrlProperty);
    set => this.SetValue(AcpTextBoxSpinner.MyLabelCtrlProperty, (object) value);
  }

  public IAcpUIChildCtrlBase MyCopyButtonCtrl
  {
    get => (IAcpUIChildCtrlBase) this.GetValue(AcpTextBoxSpinner.MyCopyButtonProperty);
    set => this.SetValue(AcpTextBoxSpinner.MyCopyButtonProperty, (object) value);
  }

  public AcpFieldBase MyBLObject
  {
    get => (AcpFieldBase) this.GetValue(AcpTextBoxSpinner.MyBLObjectProperty);
    set => this.SetValue(AcpTextBoxSpinner.MyBLObjectProperty, (object) value);
  }

  public bool AreValuesEqual
  {
    get => (bool) this.GetValue(AcpTextBoxSpinner.AreValuesEqualProperty);
    set => this.SetValue(AcpTextBoxSpinner.AreValuesEqualProperty, (object) value);
  }

  public Expander MyExpander
  {
    get => (Expander) this.GetValue(AcpTextBoxSpinner.MyExpanderProperty);
    set => this.SetValue(AcpTextBoxSpinner.MyExpanderProperty, (object) value);
  }

  public IAcpUIParentCtrlBase MyParentCtrl
  {
    get => (IAcpUIParentCtrlBase) this.GetValue(AcpTextBoxSpinner.MyParentCtrlProperty);
    set => this.SetValue(AcpTextBoxSpinner.MyParentCtrlProperty, (object) value);
  }

  public string Text
  {
    get => (string) this.GetValue(AcpTextBoxSpinner.TextProperty);
    set => this.SetValue(AcpTextBoxSpinner.TextProperty, (object) value);
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

  private void AcpTextBoxSpinner_GotFocus(object sender, RoutedEventArgs e)
  {
  }

  protected override void OnGotFocus(RoutedEventArgs e) => this.AcpTextBoxMember.Focus();

  public AcpTextBoxSpinner()
  {
    this.InitializeComponent();
    this.Focusable = true;
  }

  AcpTextBox ISupportsTextBoxMember.TextBoxMember => this.AcpTextBoxMember;

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "8.0.3.0")]
  public void InitializeComponent()
  {
    if (this._contentLoaded)
      return;
    this._contentLoaded = true;
    Application.LoadComponent((object) this, new Uri("/AcpUI;component/acptextboxspinner.xaml", UriKind.Relative));
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
        this.AcpTextBoxMember = (AcpTextBox) target;
        break;
      case 2:
        this.UpClick = (RepeatButton) target;
        this.UpClick.Click += new RoutedEventHandler(this.OnClick);
        break;
      case 3:
        this.DownClick = (RepeatButton) target;
        this.DownClick.Click += new RoutedEventHandler(this.OnClick);
        break;
      default:
        this._contentLoaded = true;
        break;
    }
  }
}
