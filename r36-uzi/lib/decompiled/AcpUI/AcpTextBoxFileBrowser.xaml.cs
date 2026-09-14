// Decompiled with JetBrains decompiler
// Type: AcpUI.AcpTextBoxFileBrowser
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

using AcpBusinessLayer;
using AcpCommonLib;
using AcpFileHandlerLib;
using AcpUILib;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

#nullable disable
namespace AcpUI;

public partial class AcpTextBoxFileBrowser : 
  UserControl,
  IAcpUICtrlBase,
  IAcpUIValueCtrlBase<string>,
  IAcpUIParentCtrlBase,
  IAcpUIChildCtrlBase,
  IAcpUICommon,
  IComponentConnector
{
  public static readonly DependencyProperty IsAcpValidProperty = DependencyProperty.Register(nameof (IsAcpValid), typeof (bool), typeof (AcpTextBoxFileBrowser), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty IsAcpApplicableProperty = DependencyProperty.Register(nameof (IsAcpApplicable), typeof (bool), typeof (AcpTextBoxFileBrowser), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty IsAcpEditableProperty = DependencyProperty.Register(nameof (IsAcpEditable), typeof (bool), typeof (AcpTextBoxFileBrowser), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty IsAcpVisibleProperty = DependencyProperty.Register(nameof (IsAcpVisible), typeof (bool), typeof (AcpTextBoxFileBrowser), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty MyLabelCtrlProperty = DependencyProperty.RegisterAttached(nameof (MyLabelCtrl), typeof (IAcpUIChildCtrlBase), typeof (AcpTextBoxFileBrowser), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty MyCopyButtonProperty = DependencyProperty.RegisterAttached(nameof (MyCopyButtonCtrl), typeof (IAcpUIChildCtrlBase), typeof (AcpTextBoxFileBrowser), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty MyBLObjectProperty = DependencyProperty.RegisterAttached(nameof (MyBLObject), typeof (AcpFieldBase), typeof (AcpTextBoxFileBrowser), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty AreValuesEqualProperty = DependencyProperty.Register(nameof (AreValuesEqual), typeof (bool), typeof (AcpTextBoxFileBrowser), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty MyExpanderProperty = DependencyProperty.RegisterAttached(nameof (MyExpander), typeof (Expander), typeof (AcpTextBoxFileBrowser), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty MyParentCtrlProperty = DependencyProperty.RegisterAttached(nameof (MyParentCtrl), typeof (IAcpUIParentCtrlBase), typeof (AcpTextBoxFileBrowser), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty TextProperty = DependencyProperty.Register(nameof (Text), typeof (string), typeof (AcpTextBoxFileBrowser), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  internal AcpTextBox AcpTextBoxMember;
  internal Button FileBrowser;
  private bool _contentLoaded;

  public string Value
  {
    get => this.Text;
    set => this.Text = value;
  }

  public bool IsAcpValid
  {
    get => (bool) this.GetValue(AcpTextBoxFileBrowser.IsAcpValidProperty);
    set => this.SetValue(AcpTextBoxFileBrowser.IsAcpValidProperty, (object) value);
  }

  public bool IsAcpApplicable
  {
    get => (bool) this.GetValue(AcpTextBoxFileBrowser.IsAcpApplicableProperty);
    set => this.SetValue(AcpTextBoxFileBrowser.IsAcpApplicableProperty, (object) value);
  }

  public bool IsAcpEditable
  {
    get => (bool) this.GetValue(AcpTextBoxFileBrowser.IsAcpEditableProperty);
    set => this.SetValue(AcpTextBoxFileBrowser.IsAcpEditableProperty, (object) value);
  }

  public bool IsAcpVisible
  {
    get => (bool) this.GetValue(AcpTextBoxFileBrowser.IsAcpVisibleProperty);
    set => this.SetValue(AcpTextBoxFileBrowser.IsAcpVisibleProperty, (object) value);
  }

  public IAcpUIChildCtrlBase MyLabelCtrl
  {
    get => (IAcpUIChildCtrlBase) this.GetValue(AcpTextBoxFileBrowser.MyLabelCtrlProperty);
    set => this.SetValue(AcpTextBoxFileBrowser.MyLabelCtrlProperty, (object) value);
  }

  public IAcpUIChildCtrlBase MyCopyButtonCtrl
  {
    get => (IAcpUIChildCtrlBase) this.GetValue(AcpTextBoxFileBrowser.MyCopyButtonProperty);
    set => this.SetValue(AcpTextBoxFileBrowser.MyCopyButtonProperty, (object) value);
  }

  public AcpFieldBase MyBLObject
  {
    get => (AcpFieldBase) this.GetValue(AcpTextBoxFileBrowser.MyBLObjectProperty);
    set => this.SetValue(AcpTextBoxFileBrowser.MyBLObjectProperty, (object) value);
  }

  public bool AreValuesEqual
  {
    get => (bool) this.GetValue(AcpTextBoxFileBrowser.AreValuesEqualProperty);
    set => this.SetValue(AcpTextBoxFileBrowser.AreValuesEqualProperty, (object) value);
  }

  public Expander MyExpander
  {
    get => (Expander) this.GetValue(AcpTextBoxFileBrowser.MyExpanderProperty);
    set => this.SetValue(AcpTextBoxFileBrowser.MyExpanderProperty, (object) value);
  }

  public IAcpUIParentCtrlBase MyParentCtrl
  {
    get => (IAcpUIParentCtrlBase) this.GetValue(AcpTextBoxFileBrowser.MyParentCtrlProperty);
    set => this.SetValue(AcpTextBoxFileBrowser.MyParentCtrlProperty, (object) value);
  }

  public string Text
  {
    get => (string) this.GetValue(AcpTextBoxFileBrowser.TextProperty);
    set => this.SetValue(AcpTextBoxFileBrowser.TextProperty, (object) value);
  }

  public static Func<SelectionMode, List<string>> SelectVAFileDialog { get; set; }

  private void OnClick(object sender, RoutedEventArgs e)
  {
    AppInfoManager.LoadingVoiceData = true;
    string path = string.Empty;
    try
    {
      if (AcpTextBoxFileBrowser.SelectVAFileDialog != null)
      {
        List<string> stringList = AcpTextBoxFileBrowser.SelectVAFileDialog(SelectionMode.Single);
        if (stringList != null && stringList.Count > 0)
          path = stringList[0];
      }
      else
      {
        AcpOpenFileDialog acpOpenFileDialog = new AcpOpenFileDialog();
        if (this.MyBLObject.Name == "SecSysCertGeneralCertificateFilename_A43634")
          acpOpenFileDialog.Filter = "Certificate files (*.*)|*.*";
        else
          acpOpenFileDialog.Filter = "Motorola Voice Announcement files (*.mva)|*.mva";
        acpOpenFileDialog.MultiSelect = false;
        bool? nullable = acpOpenFileDialog.ShowDialog();
        bool flag = true;
        if (nullable.GetValueOrDefault() == flag & nullable.HasValue)
          path = acpOpenFileDialog.FileName;
      }
      if (string.IsNullOrEmpty(path))
        return;
      this.AcpTextBoxMember.Text = Path.GetFileName(path);
      object myBlObject = (object) (this.MyBLObject as AcpKeyField);
      if (myBlObject != null)
      {
        ((AcpField<string>) myBlObject).Value = path;
      }
      else
      {
        if (!(this.MyBLObject is AcpStringField))
          return;
        (this.MyBLObject as AcpStringField).Value = path;
      }
    }
    finally
    {
      AppInfoManager.LoadingVoiceData = false;
    }
  }

  private void OnLostFocus(object sender, RoutedEventArgs e)
  {
    this.Text = this.AcpTextBoxMember.Text;
  }

  private void AcpTextBoxFileBrowser_GotFocus(object sender, RoutedEventArgs e)
  {
  }

  protected override void OnGotFocus(RoutedEventArgs e) => this.AcpTextBoxMember.Focus();

  public AcpTextBoxFileBrowser()
  {
    this.InitializeComponent();
    this.Focusable = true;
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "8.0.3.0")]
  public void InitializeComponent()
  {
    if (this._contentLoaded)
      return;
    this._contentLoaded = true;
    Application.LoadComponent((object) this, new Uri("/AcpUI;component/acptextboxfilebrowser.xaml", UriKind.Relative));
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
      {
        this.FileBrowser = (Button) target;
        this.FileBrowser.Click += new RoutedEventHandler(this.OnClick);
      }
      else
        this._contentLoaded = true;
    }
    else
      this.AcpTextBoxMember = (AcpTextBox) target;
  }
}
