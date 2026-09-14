// Decompiled with JetBrains decompiler
// Type: AcpUI.AcpViewOnlyCtrl
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

using AcpBusinessLayer;
using AcpUILib;
using System.Windows;
using System.Windows.Controls;

#nullable disable
namespace AcpUI;

public class AcpViewOnlyCtrl : 
  Label,
  IAcpUICtrlBase,
  IAcpUIValueCtrlBase<string>,
  IAcpUIParentCtrlBase,
  IAcpUIChildCtrlBase,
  IAcpUICommon
{
  public static readonly DependencyProperty IsAcpValidProperty = DependencyProperty.Register(nameof (IsAcpValid), typeof (bool), typeof (AcpViewOnlyCtrl), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty IsAcpApplicableProperty = DependencyProperty.Register(nameof (IsAcpApplicable), typeof (bool), typeof (AcpViewOnlyCtrl), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty IsAcpEditableProperty = DependencyProperty.Register(nameof (IsAcpEditable), typeof (bool), typeof (AcpViewOnlyCtrl), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty IsAcpVisibleProperty = DependencyProperty.Register(nameof (IsAcpVisible), typeof (bool), typeof (AcpViewOnlyCtrl), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty MyLabelCtrlProperty = DependencyProperty.RegisterAttached(nameof (MyLabelCtrl), typeof (IAcpUIChildCtrlBase), typeof (AcpViewOnlyCtrl), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty MyCopyButtonProperty = DependencyProperty.RegisterAttached(nameof (MyCopyButtonCtrl), typeof (IAcpUIChildCtrlBase), typeof (AcpViewOnlyCtrl), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty MyBLObjectProperty = DependencyProperty.RegisterAttached(nameof (MyBLObject), typeof (AcpFieldBase), typeof (AcpViewOnlyCtrl), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty AreValuesEqualProperty = DependencyProperty.Register(nameof (AreValuesEqual), typeof (bool), typeof (AcpViewOnlyCtrl), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty MyExpanderProperty = DependencyProperty.RegisterAttached(nameof (MyExpander), typeof (Expander), typeof (AcpViewOnlyCtrl), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty MyParentCtrlProperty = DependencyProperty.RegisterAttached(nameof (MyParentCtrl), typeof (IAcpUIParentCtrlBase), typeof (AcpViewOnlyCtrl), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender));

  public string Value
  {
    get => this.Content != null ? this.Content.ToString() : (string) null;
    set => this.Content = (object) value;
  }

  public bool IsAcpValid
  {
    get => (bool) this.GetValue(AcpViewOnlyCtrl.IsAcpValidProperty);
    set => this.SetValue(AcpViewOnlyCtrl.IsAcpValidProperty, (object) value);
  }

  public bool IsAcpApplicable
  {
    get => (bool) this.GetValue(AcpViewOnlyCtrl.IsAcpApplicableProperty);
    set => this.SetValue(AcpViewOnlyCtrl.IsAcpApplicableProperty, (object) value);
  }

  public bool IsAcpEditable
  {
    get => (bool) this.GetValue(AcpViewOnlyCtrl.IsAcpEditableProperty);
    set => this.SetValue(AcpViewOnlyCtrl.IsAcpEditableProperty, (object) value);
  }

  public bool IsAcpVisible
  {
    get => (bool) this.GetValue(AcpViewOnlyCtrl.IsAcpVisibleProperty);
    set => this.SetValue(AcpViewOnlyCtrl.IsAcpVisibleProperty, (object) value);
  }

  public IAcpUIChildCtrlBase MyLabelCtrl
  {
    get => (IAcpUIChildCtrlBase) this.GetValue(AcpViewOnlyCtrl.MyLabelCtrlProperty);
    set => this.SetValue(AcpViewOnlyCtrl.MyLabelCtrlProperty, (object) value);
  }

  public IAcpUIChildCtrlBase MyCopyButtonCtrl
  {
    get => (IAcpUIChildCtrlBase) this.GetValue(AcpViewOnlyCtrl.MyCopyButtonProperty);
    set => this.SetValue(AcpViewOnlyCtrl.MyCopyButtonProperty, (object) value);
  }

  public AcpFieldBase MyBLObject
  {
    get => (AcpFieldBase) this.GetValue(AcpViewOnlyCtrl.MyBLObjectProperty);
    set => this.SetValue(AcpViewOnlyCtrl.MyBLObjectProperty, (object) value);
  }

  public bool AreValuesEqual
  {
    get => (bool) this.GetValue(AcpViewOnlyCtrl.AreValuesEqualProperty);
    set => this.SetValue(AcpViewOnlyCtrl.AreValuesEqualProperty, (object) value);
  }

  public Expander MyExpander
  {
    get => (Expander) this.GetValue(AcpViewOnlyCtrl.MyExpanderProperty);
    set => this.SetValue(AcpViewOnlyCtrl.MyExpanderProperty, (object) value);
  }

  public IAcpUIParentCtrlBase MyParentCtrl
  {
    get => (IAcpUIParentCtrlBase) this.GetValue(AcpViewOnlyCtrl.MyParentCtrlProperty);
    set => this.SetValue(AcpViewOnlyCtrl.MyParentCtrlProperty, (object) value);
  }

  public bool IsInTable { get; set; }

  public AcpViewOnlyCtrl()
  {
    this.MinWidth = 150.0;
    this.Height = 6983.0 / 300.0;
  }
}
