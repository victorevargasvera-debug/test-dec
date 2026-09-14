// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.CrumbBar
// Assembly: AcpWpfRibbon, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 45A745B5-88C3-40EE-B1E5-8DBA2EACD529
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfRibbon.dll

using DevComponents.WpfRibbon.themes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

#nullable disable
namespace DevComponents.WpfRibbon;

public class CrumbBar : ItemsControl
{
  public static readonly DependencyProperty SelectedItemProperty = DependencyProperty.Register(nameof (SelectedItem), typeof (object), typeof (CrumbBar), (PropertyMetadata) new UIPropertyMetadata((object) null, new PropertyChangedCallback(CrumbBar.OnSelectedItemChanged), new CoerceValueCallback(CrumbBar.OnCoerceSelectedItem)));
  public static readonly DependencyProperty SelectedImageProperty = DependencyProperty.Register(nameof (SelectedImage), typeof (object), typeof (CrumbBar), (PropertyMetadata) new UIPropertyMetadata((PropertyChangedCallback) null));
  public static readonly DependencyProperty HasOverflowItemsProperty = DependencyProperty.Register(nameof (HasOverflowItems), typeof (bool), typeof (CrumbBar), (PropertyMetadata) new UIPropertyMetadata((object) false));
  public static readonly DependencyProperty IsOverflowOpenProperty = DependencyProperty.Register(nameof (IsOverflowOpen), typeof (bool), typeof (CrumbBar), (PropertyMetadata) new FrameworkPropertyMetadata((object) false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  private static readonly DependencyPropertyKey ActionItemsPropertyKey;
  public static readonly DependencyProperty ActionItemsProperty;
  private static readonly DependencyPropertyKey HasActionItemsPropertyKey;
  public static readonly DependencyProperty HasActionItemsProperty;
  public static readonly DependencyProperty ActionItemTemplateProperty = DependencyProperty.Register(nameof (ActionItemTemplate), typeof (DataTemplate), typeof (CrumbBar), (PropertyMetadata) new UIPropertyMetadata((PropertyChangedCallback) null));
  public static readonly DependencyProperty ActionItemTemplateSelectorProperty = DependencyProperty.Register(nameof (ActionItemTemplateSelector), typeof (DataTemplateSelector), typeof (CrumbBar), (PropertyMetadata) new UIPropertyMetadata((PropertyChangedCallback) null));
  public static readonly RoutedEvent SelectionChangedEvent = EventManager.RegisterRoutedEvent("SelectionChanged", RoutingStrategy.Bubble, typeof (CrumbBarSelectionChangedEventHandler), typeof (CrumbBar));
  public static readonly RoutedEvent PreviewSelectionChangedEvent = EventManager.RegisterRoutedEvent("PreviewSelectionChanged", RoutingStrategy.Tunnel, typeof (CrumbBarSelectionChangedEventHandler), typeof (CrumbBar));
  private CrumbBarViewOverflowPanel _ViewOverflowPanel;
  private CrumbBarViewPanel _ViewPanel;
  private Popup _OverflowPopup;
  private CrumbBarItem _SelectedContainer;
  private CrumbBarItemView _OpenItem;
  private bool _IsMenuMode;

  private static object OnCoerceSelectedItem(DependencyObject o, object value)
  {
    return o is CrumbBar crumbBar ? crumbBar.OnCoerceSelectedItem(value) : value;
  }

  private static void OnSelectedItemChanged(
    DependencyObject o,
    DependencyPropertyChangedEventArgs e)
  {
    if (!(o is CrumbBar crumbBar))
      return;
    crumbBar.OnSelectedItemChanged(e.OldValue, e.NewValue);
  }

  protected virtual object OnCoerceSelectedItem(object value) => value;

  protected virtual void OnSelectedItemChanged(object oldValue, object newValue)
  {
    this.SetSelectedItem(newValue);
    this.OnSelectionChanged(oldValue, newValue);
  }

  [Browsable(false)]
  [DefaultValue(null)]
  public object SelectedItem
  {
    get => this.GetValue(CrumbBar.SelectedItemProperty);
    set => this.SetValue(CrumbBar.SelectedItemProperty, value);
  }

  public object SelectedImage
  {
    get => this.GetValue(CrumbBar.SelectedImageProperty);
    set => this.SetValue(CrumbBar.SelectedImageProperty, value);
  }

  public bool HasOverflowItems
  {
    get => (bool) this.GetValue(CrumbBar.HasOverflowItemsProperty);
    set => this.SetValue(CrumbBar.HasOverflowItemsProperty, (object) value);
  }

  public bool IsOverflowOpen
  {
    get => (bool) this.GetValue(CrumbBar.IsOverflowOpenProperty);
    set => this.SetValue(CrumbBar.IsOverflowOpenProperty, (object) value);
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
  public ObservableCollection<object> ActionItems
  {
    get => (ObservableCollection<object>) this.GetValue(CrumbBar.ActionItemsProperty);
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
  [Browsable(false)]
  public bool HasActionItems => (bool) this.GetValue(CrumbBar.HasActionItemsProperty);

  [Bindable(true)]
  public DataTemplate ActionItemTemplate
  {
    get => (DataTemplate) this.GetValue(CrumbBar.ActionItemTemplateProperty);
    set => this.SetValue(CrumbBar.ActionItemTemplateProperty, (object) value);
  }

  public DataTemplateSelector ActionItemTemplateSelector
  {
    get => (DataTemplateSelector) this.GetValue(CrumbBar.ActionItemTemplateSelectorProperty);
    set => this.SetValue(CrumbBar.ActionItemTemplateSelectorProperty, (object) value);
  }

  public event CrumbBarSelectionChangedEventHandler SelectionChanged
  {
    add => this.AddHandler(CrumbBar.SelectionChangedEvent, (Delegate) value);
    remove => this.RemoveHandler(CrumbBar.SelectionChangedEvent, (Delegate) value);
  }

  public event CrumbBarSelectionChangedEventHandler PreviewSelectionChanged
  {
    add => this.AddHandler(CrumbBar.PreviewSelectionChangedEvent, (Delegate) value);
    remove => this.RemoveHandler(CrumbBar.PreviewSelectionChangedEvent, (Delegate) value);
  }

  protected virtual void OnSelectionChanged(object oldSelection, object newSelection)
  {
    CrumbBarSelectionChangedEventArgs e = new CrumbBarSelectionChangedEventArgs(CrumbBar.PreviewSelectionChangedEvent, (object) this, newSelection, oldSelection);
    this.RaiseEvent((RoutedEventArgs) e);
    if (e.Handled)
      return;
    this.RaiseEvent((RoutedEventArgs) new CrumbBarSelectionChangedEventArgs(CrumbBar.SelectionChangedEvent, (object) this, newSelection, oldSelection));
  }

  static CrumbBar()
  {
    FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof (CrumbBar), (PropertyMetadata) new FrameworkPropertyMetadata((object) typeof (CrumbBar)));
    CrumbBar.ActionItemsPropertyKey = DependencyProperty.RegisterReadOnly(nameof (ActionItems), typeof (ObservableCollection<object>), typeof (CrumbBar), new PropertyMetadata((object) new ObservableCollection<object>()));
    CrumbBar.ActionItemsProperty = CrumbBar.ActionItemsPropertyKey.DependencyProperty;
    CrumbBar.HasActionItemsPropertyKey = DependencyProperty.RegisterReadOnly(nameof (HasActionItems), typeof (bool), typeof (CrumbBar), new PropertyMetadata((object) false));
    CrumbBar.HasActionItemsProperty = CrumbBar.HasActionItemsPropertyKey.DependencyProperty;
  }

  public CrumbBar()
  {
    ObservableCollection<object> observableCollection = new ObservableCollection<object>();
    observableCollection.CollectionChanged += new NotifyCollectionChangedEventHandler(this.ActionItemsCollectionChanged);
    this.SetValue(CrumbBar.ActionItemsPropertyKey, (object) observableCollection);
  }

  public override void OnApplyTemplate()
  {
    if (this._ViewPanel != null)
      this._ViewPanel.Children.Clear();
    if (this._OverflowPopup != null)
    {
      this._OverflowPopup.Opened -= new EventHandler(this.OverflowPopupOpened);
      this._OverflowPopup.Closed -= new EventHandler(this.OverflowPopupClosed);
    }
    this._ViewPanel = this.GetTemplateChild("PART_ViewPanel") as CrumbBarViewPanel;
    this._ViewOverflowPanel = this.GetTemplateChild("PART_OverflowPanel") as CrumbBarViewOverflowPanel;
    this._OverflowPopup = this.GetTemplateChild("OverflowPopup") as Popup;
    if (this._OverflowPopup != null)
    {
      this._OverflowPopup.Opened += new EventHandler(this.OverflowPopupOpened);
      this._OverflowPopup.Closed += new EventHandler(this.OverflowPopupClosed);
    }
    this.SetSelectedItem(this.SelectedItem);
    base.OnApplyTemplate();
  }

  private void OverflowPopupClosed(object sender, EventArgs e)
  {
    if (this._OpenItem != null)
      return;
    this.IsMenuMode = false;
  }

  private void OverflowPopupOpened(object sender, EventArgs e)
  {
    this.SetOpenedViewItem((CrumbBarItemView) null);
    this.IsMenuMode = true;
  }

  protected override void OnInitialized(EventArgs e)
  {
    this.ItemContainerGenerator.StatusChanged += new EventHandler(this.ItemContainerGeneratorStatusChanged);
    if (this.SelectedItem == null)
    {
      if (this.ItemsSource == null || this.ItemContainerGenerator.Status == GeneratorStatus.ContainersGenerated)
        this.SelectFirstItem();
      else if (this.ItemsSource != null && this.ItemContainerGenerator.Status != GeneratorStatus.ContainersGenerated)
      {
        IItemContainerGenerator containerGenerator = (IItemContainerGenerator) this.ItemContainerGenerator;
        using (containerGenerator.StartAt(new GeneratorPosition(-1, 0), GeneratorDirection.Forward))
        {
          while (containerGenerator.GenerateNext() is UIElement next)
            containerGenerator.PrepareItemContainer((DependencyObject) next);
        }
      }
    }
    base.OnInitialized(e);
  }

  private void ItemContainerGeneratorStatusChanged(object sender, EventArgs e)
  {
    if (this.ItemContainerGenerator.Status != GeneratorStatus.ContainersGenerated || !this.HasItems || this.SelectedItem != null)
      return;
    this.SelectFirstItem();
  }

  protected override bool IsItemItsOwnContainerOverride(object item) => item is CrumbBarItem;

  protected override DependencyObject GetContainerForItemOverride()
  {
    return (DependencyObject) new CrumbBarItem();
  }

  protected override void OnItemsChanged(NotifyCollectionChangedEventArgs e)
  {
    base.OnItemsChanged(e);
  }

  private CrumbBarItemView CreateView(CrumbBarItem item)
  {
    CrumbBarItemView element = new CrumbBarItemView();
    element.ParentTree = this;
    element.CrumbBarItem = item;
    if (ToolTipService.GetToolTip((DependencyObject) item) != null)
      ToolTipService.SetToolTip((DependencyObject) element, ToolTipService.GetToolTip((DependencyObject) item));
    return element;
  }

  private void SelectFirstItem()
  {
    object obj;
    if (!this.GetFirstItem(out obj, out CrumbBarItem _))
      return;
    this.SelectedItem = obj;
  }

  private bool GetFirstItem(out object item, out CrumbBarItem container)
  {
    if (this.HasItems)
    {
      item = this.Items[0];
      container = this.ItemContainerGenerator.ContainerFromIndex(0) as CrumbBarItem;
      return item != null;
    }
    item = (object) null;
    container = (CrumbBarItem) null;
    return false;
  }

  private void SetSelectedItem(object selectedItem)
  {
    CrumbBarItem container = (CrumbBarItem) null;
    if (selectedItem != null)
      container = this.FindContainer(selectedItem);
    this.SetSelectedItem(selectedItem, container);
  }

  private CrumbBarItem FindContainer(object selectedItem)
  {
    CrumbBarItem container = (CrumbBarItem) null;
    if (selectedItem != null)
      container = this.ItemContainerGenerator.ContainerFromItem(selectedItem) as CrumbBarItem;
    if (container == null)
    {
      switch (selectedItem)
      {
        case null:
        case CrumbBarItem _:
          break;
        default:
          IEnumerator enumerator = ((IEnumerable) this.Items).GetEnumerator();
          try
          {
            while (enumerator.MoveNext())
            {
              object current = enumerator.Current;
              CrumbBarItem generatedItem = current is CrumbBarItem ? (CrumbBarItem) current : this.ItemContainerGenerator.ContainerFromItem(current) as CrumbBarItem;
              if (generatedItem != null)
              {
                container = this.FindContainer(generatedItem, selectedItem);
                if (container != null)
                  break;
              }
            }
            break;
          }
          finally
          {
            if (enumerator is IDisposable disposable)
              disposable.Dispose();
          }
      }
    }
    return container;
  }

  private CrumbBarItem FindContainer(CrumbBarItem generatedItem, object selectedItem)
  {
    if (generatedItem.ItemContainerGenerator.Status == GeneratorStatus.NotStarted)
    {
      IItemContainerGenerator containerGenerator = (IItemContainerGenerator) generatedItem.ItemContainerGenerator;
      if (containerGenerator != null)
      {
        using (containerGenerator.StartAt(new GeneratorPosition(-1, 0), GeneratorDirection.Forward))
        {
          while (containerGenerator.GenerateNext() is UIElement next)
          {
            containerGenerator.PrepareItemContainer((DependencyObject) next);
            if (next is CrumbBarItem crumbBarItem)
              crumbBarItem.ApplyTemplate();
          }
        }
      }
    }
    if (!(generatedItem.ItemContainerGenerator.ContainerFromItem(selectedItem) is CrumbBarItem container))
    {
      foreach (object obj in (IEnumerable) generatedItem.Items)
      {
        CrumbBarItem generatedItem1 = obj is CrumbBarItem ? (CrumbBarItem) obj : generatedItem.ItemContainerGenerator.ContainerFromItem(obj) as CrumbBarItem;
        if (generatedItem1 != null)
        {
          container = this.FindContainer(generatedItem1, selectedItem);
          if (container != null)
            break;
        }
      }
    }
    return container;
  }

  [Browsable(false)]
  [Bindable(false)]
  public ReadOnlyCollection<UIElement> ViewItems
  {
    get
    {
      return this._ViewPanel == null ? (ReadOnlyCollection<UIElement>) null : new ReadOnlyCollection<UIElement>((IList<UIElement>) this._ViewPanel.GeneratedChildren);
    }
  }

  internal void SetSelectedItem(object selectedItem, CrumbBarItem container)
  {
    if (this._ViewPanel == null)
      return;
    CrumbBarViewPanel viewPanel = this._ViewPanel;
    if (this._SelectedContainer != null)
      this._SelectedContainer.IsSelected = false;
    if (selectedItem == null)
    {
      viewPanel.GeneratedChildren.Clear();
      viewPanel.InvalidateMeasure();
    }
    else
    {
      if (container == null && selectedItem is CrumbBarItem)
        container = (CrumbBarItem) selectedItem;
      this._SelectedContainer = container;
      if (container == null)
        return;
      if (this._SelectedContainer != null)
        this._SelectedContainer.IsSelected = true;
      List<CrumbBarItemView> crumbBarItemViewList = new List<CrumbBarItemView>();
      for (CrumbBarItem current = container; current != null; current = this.GetParentTreeItem(current))
      {
        CrumbBarItemView viewItem = this.GetViewItem(current);
        crumbBarItemViewList.Insert(0, viewItem);
      }
      viewPanel.GeneratedChildren.Clear();
      foreach (CrumbBarItemView crumbBarItemView in crumbBarItemViewList)
        viewPanel.GeneratedChildren.Add((UIElement) crumbBarItemView);
      viewPanel.InvalidateMeasure();
      this.SelectedImage = container == null ? (object) null : CloningMachine.GetObjectCopy(container.Image, true);
      this.IsMenuMode = false;
    }
  }

  private CrumbBarItem GetParentTreeItem(CrumbBarItem current)
  {
    if (current == null)
      return (CrumbBarItem) null;
    if (current.Parent is CrumbBarItem)
      return (CrumbBarItem) current.Parent;
    ItemsControl parentTreeItem = ItemsControl.ItemsControlFromItemContainer((DependencyObject) current);
    switch (parentTreeItem)
    {
      case CrumbBarItem _:
        return (CrumbBarItem) parentTreeItem;
      case CrumbBarItemsControl _:
        return parentTreeItem.TemplatedParent is CrumbBarItemView templatedParent ? templatedParent.CrumbBarItem : ((CrumbBarItemsControl) parentTreeItem).ParentViewItem.CrumbBarItem;
      default:
        return (CrumbBarItem) null;
    }
  }

  private CrumbBarItemView GetViewItem(CrumbBarItem current)
  {
    CrumbBarViewPanel viewPanel = this._ViewPanel;
    if (viewPanel != null)
    {
      foreach (UIElement generatedChild in viewPanel.GeneratedChildren)
      {
        if (generatedChild is CrumbBarItemView viewItem && viewItem.CrumbBarItem == current)
          return viewItem;
      }
    }
    return this.CreateView(current);
  }

  internal CrumbBarViewOverflowPanel OverflowPanel => this._ViewOverflowPanel;

  internal void SetOpenedViewItem(CrumbBarItemView item)
  {
    CrumbBarItemView openItem = this._OpenItem;
    if (openItem != null && openItem != item)
      openItem.ClosePopup();
    if (item != null && this._OverflowPopup != null && this._OverflowPopup.IsOpen)
      this._OverflowPopup.IsOpen = false;
    this._OpenItem = item;
    if (this._OpenItem == null)
      return;
    this.IsMenuMode = true;
  }

  internal void ViewItemClosed(CrumbBarItemView item)
  {
    if (item != this._OpenItem)
      return;
    this._OpenItem = (CrumbBarItemView) null;
    this.IsMenuMode = false;
  }

  internal bool IsMenuMode
  {
    get => this._IsMenuMode;
    set
    {
      if (this._IsMenuMode == value)
        return;
      this._IsMenuMode = value;
      if (!this._IsMenuMode)
      {
        if (this.IsMouseCaptured)
          this.ReleaseMouseCapture();
        if (this._OpenItem != null)
          this.SetOpenedViewItem((CrumbBarItemView) null);
        if (this._OverflowPopup == null || !this._OverflowPopup.IsOpen)
          return;
        this._OverflowPopup.IsOpen = false;
      }
      else
      {
        if (this.IsMouseCaptured)
          return;
        Mouse.Capture((IInputElement) this, CaptureMode.SubTree);
      }
    }
  }

  protected override void OnLostMouseCapture(MouseEventArgs e)
  {
    if (this.IsMenuMode && e.OriginalSource == this)
      this.IsMenuMode = false;
    base.OnLostMouseCapture(e);
  }

  protected override void OnPreviewMouseDown(MouseButtonEventArgs e)
  {
    if (!e.Handled && (e.ChangedButton == MouseButton.Left || e.ChangedButton == MouseButton.Right) && this.IsMenuMode)
    {
      FrameworkElement originalSource = e.OriginalSource as FrameworkElement;
      FrameworkElement parent = (FrameworkElement) this;
      if (originalSource != null && (originalSource == this || originalSource.TemplatedParent == this || originalSource.TemplatedParent is CrumbBar || ParentPopupControlImpl.IsChildOf((UIElement) parent, (UIElement) originalSource)))
      {
        this.IsMenuMode = false;
        e.Handled = true;
      }
    }
    base.OnPreviewMouseDown(e);
  }

  private void ActionItemsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
  {
    if (e.Action == NotifyCollectionChangedAction.Add || e.Action == NotifyCollectionChangedAction.Remove || e.Action == NotifyCollectionChangedAction.Reset)
    {
      if (this.ActionItems.Count == 0 && this.HasActionItems)
        this.SetValue(CrumbBar.HasActionItemsPropertyKey, (object) false);
      else if (this.ActionItems.Count > 0 && !this.HasActionItems)
        this.SetValue(CrumbBar.HasActionItemsPropertyKey, (object) true);
    }
    if (e.Action == NotifyCollectionChangedAction.Reset)
    {
      foreach (object actionItem in (Collection<object>) this.ActionItems)
        this.AddLogicalChild(actionItem);
    }
    else
    {
      if (e.OldItems != null)
      {
        foreach (object oldItem in (IEnumerable) e.OldItems)
          this.RemoveLogicalChild(oldItem);
      }
      if (e.NewItems == null)
        return;
      foreach (object newItem in (IEnumerable) e.NewItems)
        this.AddLogicalChild(newItem);
    }
  }

  private static ResourceDictionary GetColorTable(eCrumbBarVisualStyle colorTable)
  {
    switch (colorTable)
    {
      case eCrumbBarVisualStyle.Vista:
        return (ResourceDictionary) new CrumbBarVistaScheme();
      case eCrumbBarVisualStyle.Office2007Blue:
        return (ResourceDictionary) new CrumbBarOffice2007BlueScheme();
      case eCrumbBarVisualStyle.Office2007Black:
        return (ResourceDictionary) new CrumbBarOffice2007BlackScheme();
      case eCrumbBarVisualStyle.Office2007Silver:
        return (ResourceDictionary) new CrumbBarOffice2007SilverScheme();
      default:
        throw new InvalidEnumArgumentException("Color table not not recognized");
    }
  }

  private static ResourceDictionary CreateColorScheme(ResourceDictionary rd, Color baseColor)
  {
    ColorFactory colorFactory = CrumbBar.GetColorFactory(baseColor);
    foreach (object key in (IEnumerable) rd.Keys)
    {
      if (!(key is ComponentResourceKey) || !(key as ComponentResourceKey).ResourceId.ToString().StartsWith(CrumbBarColors.ButtonClass))
      {
        object obj = rd[key];
        switch (obj)
        {
          case SolidColorBrush _:
            SolidColorBrush solidColorBrush = obj as SolidColorBrush;
            solidColorBrush.Color = colorFactory.GetColor(solidColorBrush.Color);
            continue;
          case LinearGradientBrush _:
            using (GradientStopCollection.Enumerator enumerator = (obj as LinearGradientBrush).GradientStops.GetEnumerator())
            {
              while (enumerator.MoveNext())
              {
                GradientStop current = enumerator.Current;
                current.Color = colorFactory.GetColor(current.Color);
              }
              continue;
            }
          case RadialGradientBrush _:
            using (GradientStopCollection.Enumerator enumerator = (obj as RadialGradientBrush).GradientStops.GetEnumerator())
            {
              while (enumerator.MoveNext())
              {
                GradientStop current = enumerator.Current;
                current.Color = colorFactory.GetColor(current.Color);
              }
              continue;
            }
          default:
            continue;
        }
      }
    }
    return rd;
  }

  private static ColorFactory GetColorFactory(Color baseColor)
  {
    return (ColorFactory) new ColorBlendFactory(baseColor);
  }

  public void ChangeColorScheme(eCrumbBarVisualStyle colorTable)
  {
    if (Application.Current == null)
      return;
    this.MergeDictionary(CrumbBar.GetColorTable(colorTable));
  }

  public void ChangeColorScheme(eCrumbBarVisualStyle baseColorTable, Color baseColor)
  {
    if (Application.Current == null)
      return;
    this.MergeDictionary(CrumbBar.CreateColorScheme(baseColorTable, baseColor));
  }

  public static ResourceDictionary CreateColorScheme(
    eCrumbBarVisualStyle baseColorTable,
    Color baseColor)
  {
    return CrumbBar.CreateColorScheme(CrumbBar.GetColorTable(baseColorTable), baseColor);
  }

  private void MergeDictionary(ResourceDictionary rd)
  {
    ResourceDictionary resourceDictionary = Application.Current != null ? Application.Current.Resources : this.Resources;
    foreach (ResourceDictionary mergedDictionary in resourceDictionary.MergedDictionaries)
    {
      switch (mergedDictionary)
      {
        case CrumbBarVistaScheme _:
        case CrumbBarOffice2007BlackScheme _:
        case CrumbBarOffice2007BlueScheme _:
        case CrumbBarOffice2007SilverScheme _:
          resourceDictionary.MergedDictionaries.Remove(mergedDictionary);
          goto label_8;
        default:
          continue;
      }
    }
label_8:
    resourceDictionary.MergedDictionaries.Add(rd);
  }
}
