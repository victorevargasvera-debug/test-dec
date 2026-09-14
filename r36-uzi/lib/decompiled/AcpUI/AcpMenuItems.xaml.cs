// Decompiled with JetBrains decompiler
// Type: AcpUI.AcpMenuItems
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

using AcpBusinessLayer;
using AcpUI.DragDrop;
using AcpUILib;
using System;
using System.CodeDom.Compiler;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

#nullable disable
namespace AcpUI;

public partial class AcpMenuItems : 
  UserControl,
  IAcpUICtrlBase,
  IAcpUIParentCtrlBase,
  IAcpUIChildCtrlBase,
  IAcpUICommon,
  IComponentConnector
{
  public static readonly DependencyProperty IsAcpValidProperty = DependencyProperty.Register(nameof (IsAcpValid), typeof (bool), typeof (AcpMenuItems), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty IsAcpApplicableProperty = DependencyProperty.Register(nameof (IsAcpApplicable), typeof (bool), typeof (AcpMenuItems), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty IsAcpEditableProperty = DependencyProperty.Register(nameof (IsAcpEditable), typeof (bool), typeof (AcpMenuItems), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty IsAcpVisibleProperty = DependencyProperty.Register(nameof (IsAcpVisible), typeof (bool), typeof (AcpMenuItems), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty MyLabelCtrlProperty = DependencyProperty.RegisterAttached(nameof (MyLabelCtrl), typeof (IAcpUIChildCtrlBase), typeof (AcpMenuItems), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty MyCopyButtonProperty = DependencyProperty.RegisterAttached(nameof (MyCopyButtonCtrl), typeof (IAcpUIChildCtrlBase), typeof (AcpMenuItems), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty MyBLObjectProperty = DependencyProperty.RegisterAttached(nameof (MyBLObject), typeof (AcpFieldBase), typeof (AcpMenuItems), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty AreValuesEqualProperty = DependencyProperty.Register(nameof (AreValuesEqual), typeof (bool), typeof (AcpMenuItems), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty MyExpanderProperty = DependencyProperty.RegisterAttached(nameof (MyExpander), typeof (Expander), typeof (AcpMenuItems), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty MyParentCtrlProperty = DependencyProperty.RegisterAttached(nameof (MyParentCtrl), typeof (IAcpUIParentCtrlBase), typeof (AcpMenuItems), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty AvailableItemsItemsSourceProperty = DependencyProperty.Register(nameof (AvailableItemsItemsSource), typeof (ObservableCollection<AcpBusinessLayer.ListItem>), typeof (AcpMenuItems), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty AvailableItemsSelectedValueProperty = DependencyProperty.Register(nameof (AvailableItemsSelectedValue), typeof (string), typeof (AcpMenuItems), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty SelectedItemsItemsSourceProperty = DependencyProperty.Register(nameof (SelectedItemsItemsSource), typeof (ObservableCollection<AcpBusinessLayer.ListItem>), typeof (AcpMenuItems), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty SelectedItemsSelectedValueProperty = DependencyProperty.Register(nameof (SelectedItemsSelectedValue), typeof (string), typeof (AcpMenuItems), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty MaximumItemsAllowedProperty = DependencyProperty.Register(nameof (MaximumItemsAllowed), typeof (int), typeof (AcpMenuItems), (PropertyMetadata) new FrameworkPropertyMetadata((object) int.MaxValue, FrameworkPropertyMetadataOptions.AffectsRender));
  internal RowDefinition MenuItemsLabelRowHeight;
  internal AcpListBox ListBoxAvailableMenuItems;
  internal AcpButton BtnAddMenuItem;
  internal AcpButton BtnRemoveMenuItem;
  internal AcpListBox ListBoxSelectedMenuItems;
  private bool _contentLoaded;

  public bool IsAcpValid
  {
    get => (bool) this.GetValue(AcpMenuItems.IsAcpValidProperty);
    set => this.SetValue(AcpMenuItems.IsAcpValidProperty, (object) value);
  }

  public bool IsAcpApplicable
  {
    get => (bool) this.GetValue(AcpMenuItems.IsAcpApplicableProperty);
    set => this.SetValue(AcpMenuItems.IsAcpApplicableProperty, (object) value);
  }

  public bool IsAcpEditable
  {
    get => (bool) this.GetValue(AcpMenuItems.IsAcpEditableProperty);
    set => this.SetValue(AcpMenuItems.IsAcpEditableProperty, (object) value);
  }

  public bool IsAcpVisible
  {
    get => (bool) this.GetValue(AcpMenuItems.IsAcpVisibleProperty);
    set => this.SetValue(AcpMenuItems.IsAcpVisibleProperty, (object) value);
  }

  public IAcpUIChildCtrlBase MyLabelCtrl
  {
    get => (IAcpUIChildCtrlBase) this.GetValue(AcpMenuItems.MyLabelCtrlProperty);
    set => this.SetValue(AcpMenuItems.MyLabelCtrlProperty, (object) value);
  }

  public IAcpUIChildCtrlBase MyCopyButtonCtrl
  {
    get => (IAcpUIChildCtrlBase) this.GetValue(AcpMenuItems.MyCopyButtonProperty);
    set => this.SetValue(AcpMenuItems.MyCopyButtonProperty, (object) value);
  }

  public AcpFieldBase MyBLObject
  {
    get => (AcpFieldBase) this.GetValue(AcpMenuItems.MyBLObjectProperty);
    set => this.SetValue(AcpMenuItems.MyBLObjectProperty, (object) value);
  }

  public bool AreValuesEqual
  {
    get => (bool) this.GetValue(AcpMenuItems.AreValuesEqualProperty);
    set => this.SetValue(AcpMenuItems.AreValuesEqualProperty, (object) value);
  }

  public Expander MyExpander
  {
    get => (Expander) this.GetValue(AcpMenuItems.MyExpanderProperty);
    set => this.SetValue(AcpMenuItems.MyExpanderProperty, (object) value);
  }

  public IAcpUIParentCtrlBase MyParentCtrl
  {
    get => (IAcpUIParentCtrlBase) this.GetValue(AcpMenuItems.MyParentCtrlProperty);
    set => this.SetValue(AcpMenuItems.MyParentCtrlProperty, (object) value);
  }

  public override void OnApplyTemplate()
  {
    base.OnApplyTemplate();
    Style resource = (Style) this.TryFindResource((object) "AcpListBoxItemStyle");
    if (resource == null)
      return;
    Style style = new Style(typeof (ListBoxItem), resource);
    this.ListBoxAvailableMenuItems.ItemContainerStyle = style;
    this.ListBoxSelectedMenuItems.ItemContainerStyle = style;
  }

  public ObservableCollection<AcpBusinessLayer.ListItem> AvailableItemsItemsSource
  {
    get
    {
      return (ObservableCollection<AcpBusinessLayer.ListItem>) this.GetValue(AcpMenuItems.AvailableItemsItemsSourceProperty);
    }
    set => this.SetValue(AcpMenuItems.AvailableItemsItemsSourceProperty, (object) value);
  }

  public string AvailableItemsSelectedValue
  {
    get => (string) this.GetValue(AcpMenuItems.AvailableItemsSelectedValueProperty);
    set => this.SetValue(AcpMenuItems.AvailableItemsSelectedValueProperty, (object) value);
  }

  public ObservableCollection<AcpBusinessLayer.ListItem> SelectedItemsItemsSource
  {
    get
    {
      return (ObservableCollection<AcpBusinessLayer.ListItem>) this.GetValue(AcpMenuItems.SelectedItemsItemsSourceProperty);
    }
    set => this.SetValue(AcpMenuItems.SelectedItemsItemsSourceProperty, (object) value);
  }

  public string SelectedItemsSelectedValue
  {
    get => (string) this.GetValue(AcpMenuItems.SelectedItemsSelectedValueProperty);
    set => this.SetValue(AcpMenuItems.SelectedItemsSelectedValueProperty, (object) value);
  }

  public int MaximumItemsAllowed
  {
    get => (int) this.GetValue(AcpMenuItems.MaximumItemsAllowedProperty);
    set => this.SetValue(AcpMenuItems.MaximumItemsAllowedProperty, (object) value);
  }

  private void BtnAddMenuItem_Click(object sender, RoutedEventArgs e)
  {
    if (this.ListBoxAvailableMenuItems.SelectedIndex == -1 || this.ListBoxSelectedMenuItems.Items.Count >= this.MaximumItemsAllowed || !(this.MyBLObject is AcpListField myBlObject))
      return;
    myBlObject.AddItem(this.ListBoxAvailableMenuItems.SelectedValue.ToString());
  }

  private void BtnRemoveMenuItem_Click(object sender, RoutedEventArgs e)
  {
    int selectedIndex = this.ListBoxSelectedMenuItems.SelectedIndex;
    if (selectedIndex == -1 || this.ListBoxSelectedMenuItems.Items.Count <= 1 || !(this.MyBLObject is AcpListField myBlObject))
      return;
    myBlObject.RemoveItemAt(selectedIndex);
    if (selectedIndex > 0)
      this.ListBoxSelectedMenuItems.SelectedIndex = selectedIndex - 1;
    else
      this.ListBoxSelectedMenuItems.SelectedIndex = 0;
  }

  public AcpMenuItems()
  {
    this.InitializeComponent();
    ListBoxDragDropManager<AcpBusinessLayer.ListItem> boxDragDropManager = new ListBoxDragDropManager<AcpBusinessLayer.ListItem>((ListBox) this.ListBoxSelectedMenuItems);
    this.MenuItemsLabelRowHeight.Height = (GridLength) new GridLengthConverter().ConvertFrom((object) 30.0);
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "8.0.3.0")]
  public void InitializeComponent()
  {
    if (this._contentLoaded)
      return;
    this._contentLoaded = true;
    Application.LoadComponent((object) this, new Uri("/AcpUI;component/acpmenuitems.xaml", UriKind.Relative));
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
        this.MenuItemsLabelRowHeight = (RowDefinition) target;
        break;
      case 2:
        this.ListBoxAvailableMenuItems = (AcpListBox) target;
        break;
      case 3:
        this.BtnAddMenuItem = (AcpButton) target;
        break;
      case 4:
        this.BtnRemoveMenuItem = (AcpButton) target;
        break;
      case 5:
        this.ListBoxSelectedMenuItems = (AcpListBox) target;
        break;
      default:
        this._contentLoaded = true;
        break;
    }
  }
}
