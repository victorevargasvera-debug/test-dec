// Decompiled with JetBrains decompiler
// Type: AcpUI.AcpCopyButton
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

using AcpBusinessLayer;
using AcpCommonLib;
using AcpCommonLib.UndoRedo;
using AcpCommonResources;
using AcpUILib;
using AcpUtility;
using System.Windows;
using System.Windows.Controls;

#nullable disable
namespace AcpUI;

public class AcpCopyButton : Button, IAcpUICtrlBase, IAcpUIChildCtrlBase
{
  public static readonly DependencyProperty IsAcpValidProperty = DependencyProperty.Register(nameof (IsAcpValid), typeof (bool), typeof (AcpCopyButton), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty IsAcpApplicableProperty = DependencyProperty.Register(nameof (IsAcpApplicable), typeof (bool), typeof (AcpCopyButton), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty IsAcpEditableProperty = DependencyProperty.Register(nameof (IsAcpEditable), typeof (bool), typeof (AcpCopyButton), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty IsAcpVisibleProperty = DependencyProperty.Register(nameof (IsAcpVisible), typeof (bool), typeof (AcpCopyButton), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty MyParentCtrlProperty = DependencyProperty.RegisterAttached(nameof (MyParentCtrl), typeof (IAcpUIParentCtrlBase), typeof (AcpCopyButton), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty MyCompCtrlProperty = DependencyProperty.RegisterAttached(nameof (MyCompCtrl), typeof (IAcpUIParentCtrlBase), typeof (AcpCopyButton), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty AreValuesEqualProperty = DependencyProperty.Register(nameof (AreValuesEqual), typeof (bool), typeof (AcpCopyButton), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender));

  public bool IsAcpValid
  {
    get => (bool) this.GetValue(AcpCopyButton.IsAcpValidProperty);
    set => this.SetValue(AcpCopyButton.IsAcpValidProperty, (object) value);
  }

  public bool IsAcpApplicable
  {
    get => (bool) this.GetValue(AcpCopyButton.IsAcpApplicableProperty);
    set => this.SetValue(AcpCopyButton.IsAcpApplicableProperty, (object) value);
  }

  public bool IsAcpEditable
  {
    get => (bool) this.GetValue(AcpCopyButton.IsAcpEditableProperty);
    set => this.SetValue(AcpCopyButton.IsAcpEditableProperty, (object) value);
  }

  public bool IsAcpVisible
  {
    get => (bool) this.GetValue(AcpCopyButton.IsAcpVisibleProperty);
    set => this.SetValue(AcpCopyButton.IsAcpVisibleProperty, (object) value);
  }

  public IAcpUIParentCtrlBase MyParentCtrl
  {
    get => (IAcpUIParentCtrlBase) this.GetValue(AcpCopyButton.MyParentCtrlProperty);
    set => this.SetValue(AcpCopyButton.MyParentCtrlProperty, (object) value);
  }

  public IAcpUIParentCtrlBase MyCompCtrl
  {
    get => (IAcpUIParentCtrlBase) this.GetValue(AcpCopyButton.MyCompCtrlProperty);
    set => this.SetValue(AcpCopyButton.MyCompCtrlProperty, (object) value);
  }

  public bool AreValuesEqual
  {
    get => (bool) this.GetValue(AcpCopyButton.AreValuesEqualProperty);
    set => this.SetValue(AcpCopyButton.AreValuesEqualProperty, (object) value);
  }

  internal void AcpCopyButton_Click(object sender, RoutedEventArgs e)
  {
    AcpFieldBase myBlObject1 = this.MyCompCtrl.MyBLObject;
    AcpFieldBase myBlObject2 = this.MyParentCtrl.MyBLObject;
    if (myBlObject1 == null || myBlObject2 == null)
      return;
    ContainerTask task = new ContainerTask(AcpResources.Copy_Value_Of.AcpStringFormat((object) myBlObject1.UIName));
    task.AddTask(myBlObject2.CopyValueOf((IAcpField) myBlObject1));
    if (myBlObject2.UnsupportedValue)
      AppInfoManager.ComparatorFieldsReport.RegisterFieldInReport((IAcpField) myBlObject2, AcpResources.Value_Not_Copied_Unsupported_Value, false);
    if (task != null && task.Tasks.Count > 0)
      UndoManager.AddTask((UndoableTask) task);
    else if (!UndoManager.MarkForUndo)
      UndoManager.StartUndoRedo();
    e.Handled = true;
  }

  public AcpCopyButton()
  {
    this.Loaded += new RoutedEventHandler(this.AcpCopyButton_Loaded);
    this.Unloaded += new RoutedEventHandler(this.AcpCopyButton_Unloaded);
    this.ToolTip = (object) AcpResources.Copy_Value;
    this.Width = 40.0;
    this.Height = 6983.0 / 300.0;
    this.Margin = new Thickness(10.0, 0.0, 10.0, 0.0);
  }

  private void AcpCopyButton_Loaded(object sender, RoutedEventArgs e)
  {
    this.Click += new RoutedEventHandler(this.AcpCopyButton_Click);
  }

  private void AcpCopyButton_Unloaded(object sender, RoutedEventArgs e)
  {
    this.Click -= new RoutedEventHandler(this.AcpCopyButton_Click);
  }
}
