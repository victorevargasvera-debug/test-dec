// Decompiled with JetBrains decompiler
// Type: AcpUI.AcpPasswordEyeBox
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

using AcpBusinessLayer;
using AcpUI.Common;
using AcpUILib;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;

#nullable disable
namespace AcpUI;

public partial class AcpPasswordEyeBox : 
  UserControl,
  IAcpUICtrlBase,
  IAcpUIValueCtrlBase<string>,
  IAcpUIParentCtrlBase,
  IAcpUIChildCtrlBase,
  IAcpUICommon,
  IComponentConnector
{
  public static readonly DependencyProperty IsEyeVisibleProperty = DependencyProperty.Register(nameof (IsEyeVisible), typeof (int), typeof (AcpPasswordEyeBox), (PropertyMetadata) new FrameworkPropertyMetadata((object) 1, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty IsCopyEnabledProperty = DependencyProperty.Register(nameof (IsCopyEnabled), typeof (bool), typeof (AcpPasswordEyeBox), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty IsAcpValidProperty = DependencyProperty.RegisterAttached(nameof (IsAcpValid), typeof (bool), typeof (AcpPasswordEyeBox), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty IsAcpApplicableProperty = DependencyProperty.Register(nameof (IsAcpApplicable), typeof (bool), typeof (AcpPasswordEyeBox), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty IsAcpEditableProperty = DependencyProperty.Register(nameof (IsAcpEditable), typeof (bool), typeof (AcpPasswordEyeBox), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty IsAcpVisibleProperty = DependencyProperty.Register(nameof (IsAcpVisible), typeof (bool), typeof (AcpPasswordEyeBox), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty MyLabelCtrlProperty = DependencyProperty.RegisterAttached(nameof (MyLabelCtrl), typeof (IAcpUIChildCtrlBase), typeof (AcpPasswordEyeBox), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty MyCopyButtonProperty = DependencyProperty.RegisterAttached(nameof (MyCopyButtonCtrl), typeof (IAcpUIChildCtrlBase), typeof (AcpPasswordEyeBox), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty MyBLObjectProperty = DependencyProperty.RegisterAttached(nameof (MyBLObject), typeof (AcpFieldBase), typeof (AcpPasswordEyeBox), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty AreValuesEqualProperty = DependencyProperty.Register(nameof (AreValuesEqual), typeof (bool), typeof (AcpPasswordEyeBox), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty MyExpanderProperty = DependencyProperty.RegisterAttached(nameof (MyExpander), typeof (Expander), typeof (AcpPasswordEyeBox), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty MyParentCtrlProperty = DependencyProperty.RegisterAttached(nameof (MyParentCtrl), typeof (IAcpUIParentCtrlBase), typeof (AcpPasswordEyeBox), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty IsDigitOnlyProperty = DependencyProperty.Register(nameof (IsDigitOnly), typeof (bool), typeof (AcpPasswordEyeBox), (PropertyMetadata) new FrameworkPropertyMetadata((object) false, FrameworkPropertyMetadataOptions.AffectsRender));
  private bool backspaceOrDelete;
  public static readonly DependencyProperty MaxPasswordLengthProperty = DependencyProperty.Register(nameof (MaxPasswordLength), typeof (int), typeof (AcpPasswordEyeBox), (PropertyMetadata) new FrameworkPropertyMetadata((object) 0, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty PINProperty = DependencyProperty.Register(nameof (PIN), typeof (string), typeof (AcpPasswordEyeBox), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(AcpPasswordEyeBox.PINPropertyChanged)));
  internal PasswordBox MyPasswordBox;
  internal TextBox MyOpenPasswordBox;
  internal Button btnShowPassword;
  internal Grid imgWhiteEye;
  internal Grid imgBlackEye;
  private bool _contentLoaded;

  public int IsEyeVisible
  {
    get => (int) this.GetValue(AcpPasswordEyeBox.IsEyeVisibleProperty);
    set => this.SetValue(AcpPasswordEyeBox.IsEyeVisibleProperty, (object) value);
  }

  public bool IsCopyEnabled
  {
    get => (bool) this.GetValue(AcpPasswordEyeBox.IsCopyEnabledProperty);
    set => this.SetValue(AcpPasswordEyeBox.IsCopyEnabledProperty, (object) value);
  }

  public string Value
  {
    get => this.MyPasswordBox.Password;
    set => this.MyPasswordBox.Password = value;
  }

  public bool IsAcpValid
  {
    get => (bool) this.GetValue(AcpPasswordEyeBox.IsAcpValidProperty);
    set => this.SetValue(AcpPasswordEyeBox.IsAcpValidProperty, (object) value);
  }

  public bool IsAcpApplicable
  {
    get => (bool) this.GetValue(AcpPasswordEyeBox.IsAcpApplicableProperty);
    set => this.SetValue(AcpPasswordEyeBox.IsAcpApplicableProperty, (object) value);
  }

  public bool IsAcpEditable
  {
    get => (bool) this.GetValue(AcpPasswordEyeBox.IsAcpEditableProperty);
    set => this.SetValue(AcpPasswordEyeBox.IsAcpEditableProperty, (object) value);
  }

  public bool IsAcpVisible
  {
    get => (bool) this.GetValue(AcpPasswordEyeBox.IsAcpVisibleProperty);
    set => this.SetValue(AcpPasswordEyeBox.IsAcpVisibleProperty, (object) value);
  }

  public IAcpUIChildCtrlBase MyLabelCtrl
  {
    get => (IAcpUIChildCtrlBase) this.GetValue(AcpPasswordEyeBox.MyLabelCtrlProperty);
    set => this.SetValue(AcpPasswordEyeBox.MyLabelCtrlProperty, (object) value);
  }

  public IAcpUIChildCtrlBase MyCopyButtonCtrl
  {
    get => (IAcpUIChildCtrlBase) this.GetValue(AcpPasswordEyeBox.MyCopyButtonProperty);
    set => this.SetValue(AcpPasswordEyeBox.MyCopyButtonProperty, (object) value);
  }

  public AcpFieldBase MyBLObject
  {
    get => (AcpFieldBase) this.GetValue(AcpPasswordEyeBox.MyBLObjectProperty);
    set => this.SetValue(AcpPasswordEyeBox.MyBLObjectProperty, (object) value);
  }

  public bool AreValuesEqual
  {
    get => (bool) this.GetValue(AcpPasswordEyeBox.AreValuesEqualProperty);
    set => this.SetValue(AcpPasswordEyeBox.AreValuesEqualProperty, (object) value);
  }

  public Expander MyExpander
  {
    get => (Expander) this.GetValue(AcpPasswordEyeBox.MyExpanderProperty);
    set => this.SetValue(AcpPasswordEyeBox.MyExpanderProperty, (object) value);
  }

  public IAcpUIParentCtrlBase MyParentCtrl
  {
    get => (IAcpUIParentCtrlBase) this.GetValue(AcpPasswordEyeBox.MyParentCtrlProperty);
    set => this.SetValue(AcpPasswordEyeBox.MyParentCtrlProperty, (object) value);
  }

  public bool IsDigitOnly
  {
    get => (bool) this.GetValue(AcpPasswordEyeBox.IsDigitOnlyProperty);
    set => this.SetValue(AcpPasswordEyeBox.IsDigitOnlyProperty, (object) value);
  }

  private void AcpPasswordEyeBox_OnPreviewKeyDown(object sender, KeyEventArgs e)
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
    get => (int) this.GetValue(AcpPasswordEyeBox.MaxPasswordLengthProperty);
    set => this.SetValue(AcpPasswordEyeBox.MaxPasswordLengthProperty, (object) value);
  }

  public string PIN
  {
    get => (string) this.GetValue(AcpPasswordEyeBox.PINProperty);
    set => this.SetValue(AcpPasswordEyeBox.PINProperty, (object) value);
  }

  public AcpPasswordEyeBox()
  {
    this.InitializeComponent();
    this.Focusable = true;
  }

  private void AcpPasswordEyeBox_LostFocus(object sender, RoutedEventArgs e)
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

  private void AcpPasswordEyeBox_OnLoaded(object sender, RoutedEventArgs e)
  {
    if (!(sender is PasswordBox passwordBox))
      return;
    passwordBox.Password = this.PIN;
  }

  private static void PINPropertyChanged(
    DependencyObject sender,
    DependencyPropertyChangedEventArgs args)
  {
    if (!(sender is AcpPasswordEyeBox))
      return;
    AcpPasswordEyeBox acpPasswordEyeBox = (AcpPasswordEyeBox) sender;
    acpPasswordEyeBox.MyPasswordBox.Password = (string) args.NewValue;
    acpPasswordEyeBox.MyOpenPasswordBox.Text = (string) args.NewValue;
  }

  private void AcpPasswordEyeBox_OnChanged(object sender, RoutedEventArgs e)
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

  private void btnShowPassword_Click(object sender, RoutedEventArgs e)
  {
    this.MyPasswordBox.Visibility = Visibility.Collapsed;
    this.MyOpenPasswordBox.Visibility = Visibility.Visible;
    this.imgWhiteEye.Visibility = Visibility.Collapsed;
    this.imgBlackEye.Visibility = Visibility.Visible;
  }

  private void btnShowPassword_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
  {
    this.MyPasswordBox.Visibility = Visibility.Visible;
    this.MyOpenPasswordBox.Visibility = Visibility.Collapsed;
    this.imgWhiteEye.Visibility = Visibility.Visible;
    this.imgBlackEye.Visibility = Visibility.Collapsed;
  }

  private void btnShowPassword_MouseLeave(object sender, MouseEventArgs e)
  {
    this.MyPasswordBox.Visibility = Visibility.Visible;
    this.MyOpenPasswordBox.Visibility = Visibility.Collapsed;
    this.imgWhiteEye.Visibility = Visibility.Visible;
    this.imgBlackEye.Visibility = Visibility.Collapsed;
  }

  private void CopyCommand_Executed(object sender, ExecutedRoutedEventArgs e)
  {
    string selectedText = this.GetSelectedText();
    if (string.IsNullOrEmpty(selectedText))
      return;
    Clipboard.SetText(selectedText);
  }

  private void CutCommand_Executed(object sender, ExecutedRoutedEventArgs e)
  {
    string selectedText = this.GetSelectedText();
    if (string.IsNullOrEmpty(selectedText))
      return;
    Clipboard.SetText(selectedText);
    PresentationSource inputSource = PresentationSource.FromVisual((Visual) this.MyPasswordBox);
    PasswordBox passwordBox1 = this.MyPasswordBox;
    KeyEventArgs e1 = new KeyEventArgs(Keyboard.PrimaryDevice, inputSource, 0, Key.Delete);
    e1.RoutedEvent = Keyboard.PreviewKeyDownEvent;
    passwordBox1.RaiseEvent((RoutedEventArgs) e1);
    PasswordBox passwordBox2 = this.MyPasswordBox;
    KeyEventArgs e2 = new KeyEventArgs(Keyboard.PrimaryDevice, inputSource, 0, Key.Delete);
    e2.RoutedEvent = Keyboard.KeyDownEvent;
    passwordBox2.RaiseEvent((RoutedEventArgs) e2);
    PasswordBox passwordBox3 = this.MyPasswordBox;
    KeyEventArgs e3 = new KeyEventArgs(Keyboard.PrimaryDevice, inputSource, 0, Key.Delete);
    e3.RoutedEvent = Keyboard.PreviewKeyUpEvent;
    passwordBox3.RaiseEvent((RoutedEventArgs) e3);
    PasswordBox passwordBox4 = this.MyPasswordBox;
    KeyEventArgs e4 = new KeyEventArgs(Keyboard.PrimaryDevice, inputSource, 0, Key.Delete);
    e4.RoutedEvent = Keyboard.KeyUpEvent;
    passwordBox4.RaiseEvent((RoutedEventArgs) e4);
  }

  private void CopyCutCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
  {
    e.CanExecute = this.IsCopyEnabled && !string.IsNullOrEmpty(this.MyPasswordBox.Password);
  }

  private string GetSelectedText()
  {
    TextSelection textSelection = (TextSelection) typeof (PasswordBox).GetProperty("Selection", BindingFlags.Instance | BindingFlags.NonPublic).GetMethod.Invoke((object) this.MyPasswordBox, (object[]) null);
    Type type = ((IEnumerable<Type>) textSelection.GetType().GetInterfaces()).Where<Type>((Func<Type, bool>) (x => x.Name == "ITextRange")).FirstOrDefault<Type>();
    object obj1 = type.GetProperty("Start").GetMethod.Invoke((object) textSelection, (object[]) null);
    object obj2 = type.GetProperty("End").GetMethod.Invoke((object) textSelection, (object[]) null);
    MethodInfo getMethod = obj1.GetType().GetProperty("Offset", BindingFlags.Instance | BindingFlags.NonPublic).GetMethod;
    int startIndex = (int) getMethod.Invoke(obj1, (object[]) null);
    int num = (int) getMethod.Invoke(obj2, (object[]) null);
    return this.MyPasswordBox.Password.Substring(startIndex, num - startIndex);
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "8.0.3.0")]
  public void InitializeComponent()
  {
    if (this._contentLoaded)
      return;
    this._contentLoaded = true;
    Application.LoadComponent((object) this, new Uri("/AcpUI;component/acppasswordeyebox.xaml", UriKind.Relative));
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "8.0.3.0")]
  [EditorBrowsable(EditorBrowsableState.Never)]
  void IComponentConnector.Connect(int connectionId, object target)
  {
    switch (connectionId)
    {
      case 1:
        this.MyPasswordBox = (PasswordBox) target;
        this.MyPasswordBox.Loaded += new RoutedEventHandler(this.AcpPasswordEyeBox_OnLoaded);
        this.MyPasswordBox.PasswordChanged += new RoutedEventHandler(this.AcpPasswordEyeBox_OnChanged);
        this.MyPasswordBox.PreviewKeyDown += new KeyEventHandler(this.AcpPasswordEyeBox_OnPreviewKeyDown);
        this.MyPasswordBox.LostFocus += new RoutedEventHandler(this.AcpPasswordEyeBox_LostFocus);
        break;
      case 2:
        ((CommandBinding) target).Executed += new ExecutedRoutedEventHandler(this.CopyCommand_Executed);
        ((CommandBinding) target).CanExecute += new CanExecuteRoutedEventHandler(this.CopyCutCommand_CanExecute);
        break;
      case 3:
        ((CommandBinding) target).Executed += new ExecutedRoutedEventHandler(this.CutCommand_Executed);
        ((CommandBinding) target).CanExecute += new CanExecuteRoutedEventHandler(this.CopyCutCommand_CanExecute);
        break;
      case 4:
        this.MyOpenPasswordBox = (TextBox) target;
        break;
      case 5:
        this.btnShowPassword = (Button) target;
        this.btnShowPassword.Click += new RoutedEventHandler(this.btnShowPassword_Click);
        this.btnShowPassword.PreviewMouseLeftButtonUp += new MouseButtonEventHandler(this.btnShowPassword_PreviewMouseLeftButtonUp);
        this.btnShowPassword.MouseLeave += new MouseEventHandler(this.btnShowPassword_MouseLeave);
        break;
      case 6:
        this.imgWhiteEye = (Grid) target;
        break;
      case 7:
        this.imgBlackEye = (Grid) target;
        break;
      default:
        this._contentLoaded = true;
        break;
    }
  }
}
