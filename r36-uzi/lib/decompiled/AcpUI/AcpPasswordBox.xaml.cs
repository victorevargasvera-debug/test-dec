// Decompiled with JetBrains decompiler
// Type: AcpUI.AcpPasswordBox
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
using System.Windows.Input;
using System.Windows.Markup;

#nullable disable
namespace AcpUI;

public partial class AcpPasswordBox : 
  UserControl,
  IAcpUICtrlBase,
  IAcpUIValueCtrlBase<string>,
  IAcpUIParentCtrlBase,
  IAcpUIChildCtrlBase,
  IAcpUICommon,
  IComponentConnector
{
  public static readonly DependencyProperty IsAcpValidProperty = DependencyProperty.RegisterAttached(nameof (IsAcpValid), typeof (bool), typeof (AcpPasswordBox), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty IsAcpApplicableProperty = DependencyProperty.Register(nameof (IsAcpApplicable), typeof (bool), typeof (AcpPasswordBox), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty IsAcpEditableProperty = DependencyProperty.Register(nameof (IsAcpEditable), typeof (bool), typeof (AcpPasswordBox), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty IsAcpVisibleProperty = DependencyProperty.Register(nameof (IsAcpVisible), typeof (bool), typeof (AcpPasswordBox), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty MyLabelCtrlProperty = DependencyProperty.RegisterAttached(nameof (MyLabelCtrl), typeof (IAcpUIChildCtrlBase), typeof (AcpPasswordBox), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty MyCopyButtonProperty = DependencyProperty.RegisterAttached(nameof (MyCopyButtonCtrl), typeof (IAcpUIChildCtrlBase), typeof (AcpPasswordBox), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty MyBLObjectProperty = DependencyProperty.RegisterAttached(nameof (MyBLObject), typeof (AcpFieldBase), typeof (AcpPasswordBox), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty AreValuesEqualProperty = DependencyProperty.Register(nameof (AreValuesEqual), typeof (bool), typeof (AcpPasswordBox), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty MyExpanderProperty = DependencyProperty.RegisterAttached(nameof (MyExpander), typeof (Expander), typeof (AcpPasswordBox), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty MyParentCtrlProperty = DependencyProperty.RegisterAttached(nameof (MyParentCtrl), typeof (IAcpUIParentCtrlBase), typeof (AcpPasswordBox), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty IsDigitOnlyProperty = DependencyProperty.Register(nameof (IsDigitOnly), typeof (bool), typeof (AcpPasswordBox), (PropertyMetadata) new FrameworkPropertyMetadata((object) false, FrameworkPropertyMetadataOptions.AffectsRender));
  private bool backspaceOrDelete;
  public static readonly DependencyProperty MaxPasswordLengthProperty = DependencyProperty.Register(nameof (MaxPasswordLength), typeof (int), typeof (AcpPasswordBox), (PropertyMetadata) new FrameworkPropertyMetadata((object) 0, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty PINProperty = DependencyProperty.Register(nameof (PIN), typeof (string), typeof (AcpPasswordBox), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(AcpPasswordBox.PINPropertyChanged)));
  internal PasswordBox MyPasswordBox;
  private bool _contentLoaded;

  public string Value
  {
    get => this.MyPasswordBox.Password;
    set => this.MyPasswordBox.Password = value;
  }

  public bool IsAcpValid
  {
    get => (bool) this.GetValue(AcpPasswordBox.IsAcpValidProperty);
    set => this.SetValue(AcpPasswordBox.IsAcpValidProperty, (object) value);
  }

  public bool IsAcpApplicable
  {
    get => (bool) this.GetValue(AcpPasswordBox.IsAcpApplicableProperty);
    set => this.SetValue(AcpPasswordBox.IsAcpApplicableProperty, (object) value);
  }

  public bool IsAcpEditable
  {
    get => (bool) this.GetValue(AcpPasswordBox.IsAcpEditableProperty);
    set => this.SetValue(AcpPasswordBox.IsAcpEditableProperty, (object) value);
  }

  public bool IsAcpVisible
  {
    get => (bool) this.GetValue(AcpPasswordBox.IsAcpVisibleProperty);
    set => this.SetValue(AcpPasswordBox.IsAcpVisibleProperty, (object) value);
  }

  public IAcpUIChildCtrlBase MyLabelCtrl
  {
    get => (IAcpUIChildCtrlBase) this.GetValue(AcpPasswordBox.MyLabelCtrlProperty);
    set => this.SetValue(AcpPasswordBox.MyLabelCtrlProperty, (object) value);
  }

  public IAcpUIChildCtrlBase MyCopyButtonCtrl
  {
    get => (IAcpUIChildCtrlBase) this.GetValue(AcpPasswordBox.MyCopyButtonProperty);
    set => this.SetValue(AcpPasswordBox.MyCopyButtonProperty, (object) value);
  }

  public AcpFieldBase MyBLObject
  {
    get => (AcpFieldBase) this.GetValue(AcpPasswordBox.MyBLObjectProperty);
    set => this.SetValue(AcpPasswordBox.MyBLObjectProperty, (object) value);
  }

  public bool AreValuesEqual
  {
    get => (bool) this.GetValue(AcpPasswordBox.AreValuesEqualProperty);
    set => this.SetValue(AcpPasswordBox.AreValuesEqualProperty, (object) value);
  }

  public Expander MyExpander
  {
    get => (Expander) this.GetValue(AcpPasswordBox.MyExpanderProperty);
    set => this.SetValue(AcpPasswordBox.MyExpanderProperty, (object) value);
  }

  public IAcpUIParentCtrlBase MyParentCtrl
  {
    get => (IAcpUIParentCtrlBase) this.GetValue(AcpPasswordBox.MyParentCtrlProperty);
    set => this.SetValue(AcpPasswordBox.MyParentCtrlProperty, (object) value);
  }

  public bool IsDigitOnly
  {
    get => (bool) this.GetValue(AcpPasswordBox.IsDigitOnlyProperty);
    set => this.SetValue(AcpPasswordBox.IsDigitOnlyProperty, (object) value);
  }

  private void AcpPasswordBox_OnPreviewKeyDown(object sender, KeyEventArgs e)
  {
    if (!(sender is PasswordBox))
      return;
    this.backspaceOrDelete = e.Key == Key.Back || e.Key == Key.Delete;
    if (this.IsDigitOnly)
    {
      if (char.IsNumber(new KeyConverter().ConvertToString((object) e.Key)[0]) && Keyboard.Modifiers == ModifierKeys.None || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9 || e.Key == Key.Return || e.Key == Key.Tab || e.Key == Key.Back || e.Key == Key.Delete)
        e.Handled = false;
      else
        e.Handled = true;
    }
    else if (e.Key == Key.RightShift || e.Key == Key.LeftShift || e.Key == Key.Return || e.Key == Key.Tab || e.Key == Key.Back || e.Key == Key.Delete)
      e.Handled = false;
    else if (Keyboard.Modifiers == ModifierKeys.None && e.Key == Key.Space)
      e.Handled = false;
    else if (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9 || e.Key == Key.Subtract || e.Key == Key.Add || e.Key == Key.Divide || e.Key == Key.Multiply)
      e.Handled = false;
    else if ((e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key == Key.Oem2 || e.Key == Key.OemMinus) && Keyboard.Modifiers == ModifierKeys.None)
      e.Handled = false;
    else if (e.Key >= Key.A && e.Key <= Key.Z)
      e.Handled = false;
    else if (Keyboard.Modifiers == ModifierKeys.Shift && (e.Key == Key.OemPlus || e.Key == Key.D8 || e.Key == Key.D3 || e.Key == Key.D7 || e.Key == Key.D5 || e.Key == Key.D4))
      e.Handled = false;
    else if (Keyboard.Modifiers == ModifierKeys.Shift && (e.Key == Key.D1 || e.Key == Key.D2 || e.Key == Key.D6 || e.Key == Key.D9 || e.Key == Key.D0 || e.Key == Key.Oem2 || e.Key == Key.OemMinus))
      e.Handled = false;
    else if (e.Key == Key.Oem1 || e.Key == Key.Oem3 || e.Key == Key.Oem4 || e.Key == Key.Oem5 || e.Key == Key.Oem6 || e.Key == Key.Oem7 || e.Key == Key.OemComma || e.Key == Key.OemPeriod || e.Key == Key.OemPlus || e.Key == Key.Decimal)
      e.Handled = false;
    else
      e.Handled = true;
    if (e.Key != Key.Right && e.Key != Key.Left && e.Key != Key.Home && e.Key != Key.End)
      return;
    e.Handled = false;
  }

  public int MaxPasswordLength
  {
    get => (int) this.GetValue(AcpPasswordBox.MaxPasswordLengthProperty);
    set => this.SetValue(AcpPasswordBox.MaxPasswordLengthProperty, (object) value);
  }

  public string PIN
  {
    get => (string) this.GetValue(AcpPasswordBox.PINProperty);
    set => this.SetValue(AcpPasswordBox.PINProperty, (object) value);
  }

  public AcpPasswordBox()
  {
    this.InitializeComponent();
    this.Focusable = true;
  }

  private void AcpPasswordBox_LostFocus(object sender, RoutedEventArgs e)
  {
    if (!(sender is PasswordBox passwordBox))
      return;
    string textDiacritics = passwordBox.Password;
    if (!string.IsNullOrEmpty(textDiacritics))
      textDiacritics = Utility.FilterArabicDiacritics(textDiacritics);
    passwordBox.Password = textDiacritics;
    this.PIN = passwordBox.Password;
    this.backspaceOrDelete = false;
  }

  private void AcpPasswordBox_OnLoaded(object sender, RoutedEventArgs e)
  {
    if (!(sender is PasswordBox passwordBox))
      return;
    passwordBox.Password = this.PIN;
  }

  private static void PINPropertyChanged(
    DependencyObject sender,
    DependencyPropertyChangedEventArgs args)
  {
    if (!(sender is AcpPasswordBox))
      return;
    ((AcpPasswordBox) sender).MyPasswordBox.Password = (string) args.NewValue;
  }

  private void AcpPasswordBox_OnChanged(object sender, RoutedEventArgs e)
  {
    if (!(sender is PasswordBox passwordBox))
      return;
    string textDiacritics = this.PIN;
    if (!string.IsNullOrEmpty(textDiacritics))
      textDiacritics = Utility.FilterArabicDiacritics(textDiacritics);
    this.PIN = textDiacritics;
    if (!(passwordBox.Password == string.Empty) || this.backspaceOrDelete)
      return;
    passwordBox.Password = this.PIN;
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "8.0.3.0")]
  public void InitializeComponent()
  {
    if (this._contentLoaded)
      return;
    this._contentLoaded = true;
    Application.LoadComponent((object) this, new Uri("/AcpUI;component/acppasswordbox.xaml", UriKind.Relative));
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "8.0.3.0")]
  [EditorBrowsable(EditorBrowsableState.Never)]
  void IComponentConnector.Connect(int connectionId, object target)
  {
    if (connectionId == 1)
    {
      this.MyPasswordBox = (PasswordBox) target;
      this.MyPasswordBox.Loaded += new RoutedEventHandler(this.AcpPasswordBox_OnLoaded);
      this.MyPasswordBox.PasswordChanged += new RoutedEventHandler(this.AcpPasswordBox_OnChanged);
      this.MyPasswordBox.PreviewKeyDown += new KeyEventHandler(this.AcpPasswordBox_OnPreviewKeyDown);
      this.MyPasswordBox.LostFocus += new RoutedEventHandler(this.AcpPasswordBox_LostFocus);
    }
    else
      this._contentLoaded = true;
  }
}
