// Decompiled with JetBrains decompiler
// Type: AcpUI.AcpLabel
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

using AcpBusinessLayer;
using AcpCommonResources;
using AcpUI.Common;
using AcpUILib;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

#nullable disable
namespace AcpUI;

public class AcpLabel : 
  Label,
  IAcpUICtrlBase,
  IAcpUIValueCtrlBase<string>,
  IAcpUIParentCtrlBase,
  IAcpUIChildCtrlBase,
  IAcpUICommon
{
  private MenuItem menuItem;
  public static readonly DependencyProperty IsAcpValidProperty = DependencyProperty.Register(nameof (IsAcpValid), typeof (bool), typeof (AcpLabel), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty IsAcpApplicableProperty = DependencyProperty.Register(nameof (IsAcpApplicable), typeof (bool), typeof (AcpLabel), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty IsAcpEditableProperty = DependencyProperty.Register(nameof (IsAcpEditable), typeof (bool), typeof (AcpLabel), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty IsAcpVisibleProperty = DependencyProperty.Register(nameof (IsAcpVisible), typeof (bool), typeof (AcpLabel), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty MyLabelCtrlProperty = DependencyProperty.RegisterAttached(nameof (MyLabelCtrl), typeof (IAcpUIChildCtrlBase), typeof (AcpLabel), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty MyCopyButtonProperty = DependencyProperty.RegisterAttached(nameof (MyCopyButtonCtrl), typeof (IAcpUIChildCtrlBase), typeof (AcpLabel), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty MyBLObjectProperty = DependencyProperty.RegisterAttached(nameof (MyBLObject), typeof (AcpFieldBase), typeof (AcpLabel), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty AreValuesEqualProperty = DependencyProperty.Register(nameof (AreValuesEqual), typeof (bool), typeof (AcpLabel), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty MyExpanderProperty = DependencyProperty.RegisterAttached(nameof (MyExpander), typeof (Expander), typeof (AcpLabel), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty MyParentCtrlProperty = DependencyProperty.RegisterAttached(nameof (MyParentCtrl), typeof (IAcpUIParentCtrlBase), typeof (AcpLabel), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty AcpLabelFromViewOnlyCtrlProperty = DependencyProperty.Register(nameof (AcpLabelFromViewOnlyCtrl), typeof (bool), typeof (AcpLabel), (PropertyMetadata) new FrameworkPropertyMetadata((object) false, FrameworkPropertyMetadataOptions.AffectsRender));

  public string Value
  {
    get => (string) this.Content;
    set => this.Content = (object) value;
  }

  public bool IsAcpValid
  {
    get => (bool) this.GetValue(AcpLabel.IsAcpValidProperty);
    set => this.SetValue(AcpLabel.IsAcpValidProperty, (object) value);
  }

  public bool IsAcpApplicable
  {
    get => (bool) this.GetValue(AcpLabel.IsAcpApplicableProperty);
    set => this.SetValue(AcpLabel.IsAcpApplicableProperty, (object) value);
  }

  public bool IsAcpEditable
  {
    get => (bool) this.GetValue(AcpLabel.IsAcpEditableProperty);
    set => this.SetValue(AcpLabel.IsAcpEditableProperty, (object) value);
  }

  public bool IsAcpVisible
  {
    get => (bool) this.GetValue(AcpLabel.IsAcpVisibleProperty);
    set => this.SetValue(AcpLabel.IsAcpVisibleProperty, (object) value);
  }

  public IAcpUIChildCtrlBase MyLabelCtrl
  {
    get => (IAcpUIChildCtrlBase) this.GetValue(AcpLabel.MyLabelCtrlProperty);
    set => this.SetValue(AcpLabel.MyLabelCtrlProperty, (object) value);
  }

  public IAcpUIChildCtrlBase MyCopyButtonCtrl
  {
    get => (IAcpUIChildCtrlBase) this.GetValue(AcpLabel.MyCopyButtonProperty);
    set => this.SetValue(AcpLabel.MyCopyButtonProperty, (object) value);
  }

  public AcpFieldBase MyBLObject
  {
    get => (AcpFieldBase) this.GetValue(AcpLabel.MyBLObjectProperty);
    set => this.SetValue(AcpLabel.MyBLObjectProperty, (object) value);
  }

  public bool AreValuesEqual
  {
    get => (bool) this.GetValue(AcpLabel.AreValuesEqualProperty);
    set => this.SetValue(AcpLabel.AreValuesEqualProperty, (object) value);
  }

  public Expander MyExpander
  {
    get => (Expander) this.GetValue(AcpLabel.MyExpanderProperty);
    set => this.SetValue(AcpLabel.MyExpanderProperty, (object) value);
  }

  public IAcpUIParentCtrlBase MyParentCtrl
  {
    get => (IAcpUIParentCtrlBase) this.GetValue(AcpLabel.MyParentCtrlProperty);
    set => this.SetValue(AcpLabel.MyParentCtrlProperty, (object) value);
  }

  public string HelpText { get; set; }

  private void menuItem_Click(object sender, RoutedEventArgs e)
  {
    string data = string.Empty;
    if (sender is MenuItem menuItem)
    {
      AcpLabel placementTarget = (AcpLabel) ((ContextMenu) menuItem.Parent).PlacementTarget;
      if (placementTarget.MyParentCtrl != null && placementTarget.MyParentCtrl.MyBLObject != null)
        data = placementTarget.MyParentCtrl.MyBLObject.Path("»");
    }
    Clipboard.SetData(DataFormats.UnicodeText, (object) data);
  }

  public bool AcpLabelFromViewOnlyCtrl
  {
    get => (bool) this.GetValue(AcpLabel.AcpLabelFromViewOnlyCtrlProperty);
    set => this.SetValue(AcpLabel.AcpLabelFromViewOnlyCtrlProperty, (object) value);
  }

  public AcpLabel()
  {
    this.VerticalAlignment = VerticalAlignment.Center;
    this.Loaded += new RoutedEventHandler(this.AcpLabel_Loaded);
    this.Unloaded += new RoutedEventHandler(this.AcpLabel_UnLoaded);
  }

  private void AcpLabel_Loaded(object sender, RoutedEventArgs e)
  {
    if (this.AcpLabelFromViewOnlyCtrl)
      return;
    ContextMenu contextMenu = new ContextMenu();
    this.menuItem = new MenuItem();
    this.menuItem.Header = (object) AcpResources.Copy_Public_Tag;
    this.menuItem.Click += new RoutedEventHandler(this.menuItem_Click);
    contextMenu.Items.Add((object) this.menuItem);
    this.ContextMenu = contextMenu;
    this.MouseDoubleClick += new MouseButtonEventHandler(this.AcpLabel_MouseDoubleClick);
    this.MouseLeftButtonDown += new MouseButtonEventHandler(this.AcpLabel_MouseLeftButtonDown);
  }

  private void AcpLabel_UnLoaded(object sender, RoutedEventArgs e)
  {
    if (this.AcpLabelFromViewOnlyCtrl)
      return;
    this.MouseDoubleClick -= new MouseButtonEventHandler(this.AcpLabel_MouseDoubleClick);
    this.MouseLeftButtonDown -= new MouseButtonEventHandler(this.AcpLabel_MouseLeftButtonDown);
    if (this.menuItem == null)
      return;
    this.menuItem.Click -= new RoutedEventHandler(this.menuItem_Click);
  }

  private void AcpLabel_MouseDoubleClick(object sender, MouseButtonEventArgs e)
  {
    if (this.AcpLabelFromViewOnlyCtrl)
      return;
    Utility.NavigateFieldHelpText((object) this.MyParentCtrl);
  }

  private void AcpLabel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
  {
    if (this.AcpLabelFromViewOnlyCtrl)
      return;
    Utility.GetFieldHelpText((object) this.MyParentCtrl);
  }
}
