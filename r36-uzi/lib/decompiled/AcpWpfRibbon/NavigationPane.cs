// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.NavigationPane
// Assembly: AcpWpfRibbon, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 45A745B5-88C3-40EE-B1E5-8DBA2EACD529
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfRibbon.dll

using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Interop;

#nullable disable
namespace DevComponents.WpfRibbon;

public class NavigationPane : Selector
{
  private const string PartPaneContentPresenter = "PART_PaneContentHost";
  private const string PartItemsPanel = "PART_ItemPanel";
  private const string PartPopup = "PART_Popup";
  private const string PartPopupToggle = "PART_PopupToggle";
  private NavigationPanePanel _ItemsPanel;
  private Popup _Popup;
  private ToggleButton _PopupToggle;
  public static RoutedCommand Collapse = new RoutedCommand(nameof (Collapse), typeof (NavigationPane));
  public static RoutedCommand Expand = new RoutedCommand(nameof (Expand), typeof (NavigationPane));
  public static readonly DependencyProperty SelectedContentProperty;
  private static readonly DependencyPropertyKey SelectedContentPropertyKey;
  public static readonly DependencyProperty SelectedPaneItemProperty;
  private static readonly DependencyPropertyKey SelectedPaneItemPropertyKey;
  public static readonly DependencyProperty SelectedContentTemplateProperty;
  private static readonly DependencyPropertyKey SelectedContentTemplatePropertyKey;
  public static readonly DependencyProperty SelectedContentTemplateSelectorProperty;
  private static readonly DependencyPropertyKey SelectedContentTemplateSelectorPropertyKey;
  public static readonly DependencyProperty SelectedContentHeaderProperty;
  private static readonly DependencyPropertyKey SelectedContentHeaderPropertyKey;
  public static readonly DependencyProperty ContentTemplateSelectorProperty;
  public static readonly DependencyProperty ContentTemplateProperty;
  public static readonly DependencyProperty IsExpandedProperty;
  public static readonly DependencyProperty LargeItemsCountProperty;
  public static readonly DependencyProperty SystemTextProperty;
  private static readonly DependencyPropertyKey SystemTextPropertyKey;
  public static readonly DependencyProperty ExpandedWidthProperty;
  public static readonly DependencyProperty CollapsedWidthProperty;
  public static readonly RoutedEvent ExpandedEvent;
  public static readonly RoutedEvent CollapsedEvent;
  public static readonly RoutedEvent PopupOpenedEvent;
  public static readonly RoutedEvent PopupClosedEvent;
  public static readonly RoutedEvent BeforeCustomizeDialogEvent;
  public static readonly DependencyProperty LicenseKeyProperty = DependencyProperty.Register(nameof (LicenseKey), typeof (string), typeof (NavigationPane), (PropertyMetadata) new FrameworkPropertyMetadata((object) "", new PropertyChangedCallback(NavigationPane.OnLicenseKeyChanged)));
  private bool _ReTakeMouseCapture;
  public static readonly DependencyProperty SelectedContentHeaderTemplateProperty = DependencyProperty.Register(nameof (SelectedContentHeaderTemplate), typeof (DataTemplate), typeof (NavigationPane), (PropertyMetadata) new FrameworkPropertyMetadata((PropertyChangedCallback) null));
  private double _ActualExpandedWidth = double.NaN;
  public static readonly string SystemShowMoreButtonsMenuItem = nameof (SystemShowMoreButtonsMenuItem);
  public static readonly string SystemShowFewerButtonsMenuItem = nameof (SystemShowFewerButtonsMenuItem);
  public static readonly string SystemNavPaneOptionMenuItem = nameof (SystemNavPaneOptionMenuItem);
  public static readonly string SystemAddRemoveMenuItem = nameof (SystemAddRemoveMenuItem);

  static NavigationPane()
  {
    FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof (NavigationPane), (PropertyMetadata) new FrameworkPropertyMetadata((object) typeof (NavigationPane)));
    NavigationPane.SelectedContentPropertyKey = DependencyProperty.RegisterReadOnly(nameof (SelectedContent), typeof (object), typeof (NavigationPane), (PropertyMetadata) new FrameworkPropertyMetadata((PropertyChangedCallback) null));
    NavigationPane.SelectedContentProperty = NavigationPane.SelectedContentPropertyKey.DependencyProperty;
    NavigationPane.SelectedContentTemplatePropertyKey = DependencyProperty.RegisterReadOnly(nameof (SelectedContentTemplate), typeof (DataTemplate), typeof (NavigationPane), (PropertyMetadata) new FrameworkPropertyMetadata((PropertyChangedCallback) null));
    NavigationPane.SelectedContentTemplateProperty = NavigationPane.SelectedContentTemplatePropertyKey.DependencyProperty;
    NavigationPane.SelectedContentTemplateSelectorPropertyKey = DependencyProperty.RegisterReadOnly(nameof (SelectedContentTemplateSelector), typeof (DataTemplateSelector), typeof (NavigationPane), (PropertyMetadata) new FrameworkPropertyMetadata((PropertyChangedCallback) null));
    NavigationPane.SelectedContentTemplateSelectorProperty = NavigationPane.SelectedContentTemplateSelectorPropertyKey.DependencyProperty;
    NavigationPane.SelectedContentHeaderPropertyKey = DependencyProperty.RegisterReadOnly(nameof (SelectedContentHeader), typeof (object), typeof (NavigationPane), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange));
    NavigationPane.SelectedContentHeaderProperty = NavigationPane.SelectedContentHeaderPropertyKey.DependencyProperty;
    NavigationPane.ContentTemplateProperty = DependencyProperty.Register(nameof (ContentTemplate), typeof (DataTemplate), typeof (NavigationPane), (PropertyMetadata) new FrameworkPropertyMetadata((PropertyChangedCallback) null));
    NavigationPane.ContentTemplateSelectorProperty = DependencyProperty.Register(nameof (ContentTemplateSelector), typeof (DataTemplateSelector), typeof (NavigationPane), (PropertyMetadata) new FrameworkPropertyMetadata((PropertyChangedCallback) null));
    NavigationPane.SelectedPaneItemPropertyKey = DependencyProperty.RegisterReadOnly(nameof (SelectedPaneItem), typeof (PaneItem), typeof (NavigationPane), (PropertyMetadata) new FrameworkPropertyMetadata((PropertyChangedCallback) null));
    NavigationPane.SelectedPaneItemProperty = NavigationPane.SelectedPaneItemPropertyKey.DependencyProperty;
    NavigationPane.IsExpandedProperty = DependencyProperty.Register(nameof (IsExpanded), typeof (bool), typeof (NavigationPane), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsParentArrange, new PropertyChangedCallback(NavigationPane.IsExpandedChanged)));
    NavigationPane.LargeItemsCountProperty = DependencyProperty.Register(nameof (LargeItemsCount), typeof (int), typeof (NavigationPane), (PropertyMetadata) new FrameworkPropertyMetadata((object) 3, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange, new PropertyChangedCallback(NavigationPane.LargeItemsCountChanged)));
    NavigationPane.SystemTextPropertyKey = DependencyProperty.RegisterReadOnly(nameof (SystemText), typeof (NavigationPaneLocalization), typeof (NavigationPane), (PropertyMetadata) new FrameworkPropertyMetadata((PropertyChangedCallback) null));
    NavigationPane.SystemTextProperty = NavigationPane.SystemTextPropertyKey.DependencyProperty;
    NavigationPane.ExpandedWidthProperty = DependencyProperty.Register(nameof (ExpandedWidth), typeof (double), typeof (NavigationPane), (PropertyMetadata) new FrameworkPropertyMetadata((object) double.NaN));
    NavigationPane.CollapsedWidthProperty = DependencyProperty.Register(nameof (CollapsedWidth), typeof (double), typeof (NavigationPane), (PropertyMetadata) new FrameworkPropertyMetadata((object) 33.0));
    EventManager.RegisterClassHandler(typeof (NavigationPane), Mouse.LostMouseCaptureEvent, (Delegate) new MouseEventHandler(NavigationPane.OnLostMouseCapture));
    EventManager.RegisterClassHandler(typeof (NavigationPane), Mouse.PreviewMouseDownOutsideCapturedElementEvent, (Delegate) new MouseButtonEventHandler(NavigationPane.MouseDownOutsideCapturedElement));
    NavigationPane.ExpandedEvent = EventManager.RegisterRoutedEvent("Expanded", RoutingStrategy.Bubble, typeof (RoutedEventHandler), typeof (NavigationPane));
    NavigationPane.CollapsedEvent = EventManager.RegisterRoutedEvent("Collapsed", RoutingStrategy.Bubble, typeof (RoutedEventHandler), typeof (NavigationPane));
    NavigationPane.PopupOpenedEvent = EventManager.RegisterRoutedEvent("PopupOpened", RoutingStrategy.Bubble, typeof (RoutedEventHandler), typeof (NavigationPane));
    NavigationPane.PopupClosedEvent = EventManager.RegisterRoutedEvent("PopupClosed", RoutingStrategy.Bubble, typeof (RoutedEventHandler), typeof (NavigationPane));
    NavigationPane.BeforeCustomizeDialogEvent = EventManager.RegisterRoutedEvent("BeforeCustomizeDialog", RoutingStrategy.Bubble, typeof (RoutedEventHandler), typeof (NavigationPane));
  }

  public NavigationPane() => this.SystemText = new NavigationPaneLocalization();

  [Browsable(false)]
  [DefaultValue("")]
  public string LicenseKey
  {
    get => (string) this.GetValue(NavigationPane.LicenseKeyProperty);
    set => this.SetValue(NavigationPane.LicenseKeyProperty, (object) value);
  }

  private static void OnLicenseKeyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
  {
    ((NavigationPane) d).OnLicenseKeyChanged();
  }

  private void OnLicenseKeyChanged() => WinApi.ValidateLicenseKey(this.LicenseKey);

  public event RoutedEventHandler Expanded
  {
    add => this.AddHandler(NavigationPane.ExpandedEvent, (Delegate) value);
    remove => this.RemoveHandler(NavigationPane.ExpandedEvent, (Delegate) value);
  }

  protected virtual void OnExpanded(RoutedEventArgs e) => this.RaiseEvent(e);

  public event RoutedEventHandler Collapsed
  {
    add => this.AddHandler(NavigationPane.CollapsedEvent, (Delegate) value);
    remove => this.RemoveHandler(NavigationPane.CollapsedEvent, (Delegate) value);
  }

  protected virtual void OnCollapsed(RoutedEventArgs e) => this.RaiseEvent(e);

  public event RoutedEventHandler PopupOpened
  {
    add => this.AddHandler(NavigationPane.PopupOpenedEvent, (Delegate) value);
    remove => this.RemoveHandler(NavigationPane.PopupOpenedEvent, (Delegate) value);
  }

  protected virtual void OnPopupOpened(RoutedEventArgs e) => this.RaiseEvent(e);

  public event RoutedEventHandler PopupClosed
  {
    add => this.AddHandler(NavigationPane.PopupClosedEvent, (Delegate) value);
    remove => this.RemoveHandler(NavigationPane.PopupClosedEvent, (Delegate) value);
  }

  protected virtual void OnPopupClosed(RoutedEventArgs e) => this.RaiseEvent(e);

  public event RoutedEventHandler BeforeCustomizeDialog
  {
    add => this.AddHandler(NavigationPane.BeforeCustomizeDialogEvent, (Delegate) value);
    remove => this.RemoveHandler(NavigationPane.BeforeCustomizeDialogEvent, (Delegate) value);
  }

  protected virtual void OnBeforeCustomizeDialogEvent(RoutedEventArgs e) => this.RaiseEvent(e);

  public override void OnApplyTemplate()
  {
    base.OnApplyTemplate();
    if (this._PopupToggle != null)
      this._PopupToggle.Click -= new RoutedEventHandler(this.PopupToggleClick);
    if (this._Popup != null)
      this._Popup.Opened -= new EventHandler(this.InternalPopupOpened);
    this._ItemsPanel = this.GetTemplateChild("PART_ItemPanel") as NavigationPanePanel;
    this._Popup = this.GetTemplateChild("PART_Popup") as Popup;
    if (this._Popup != null)
      this._Popup.Opened += new EventHandler(this.InternalPopupOpened);
    this._PopupToggle = this.GetTemplateChild("PART_PopupToggle") as ToggleButton;
    if (this._PopupToggle != null)
      this._PopupToggle.Click += new RoutedEventHandler(this.PopupToggleClick);
    this.UpdateAllSelectedContent();
  }

  [EditorBrowsable(EditorBrowsableState.Never)]
  [Browsable(false)]
  public NavigationPanePanel InternalItemsPanel => this._ItemsPanel;

  internal double MinimumContentHeight
  {
    get
    {
      if (this.SelectedContent is FrameworkElement && ((FrameworkElement) this.SelectedContent).MinHeight > 0.0)
        return ((FrameworkElement) this.SelectedContent).MinHeight;
      if (this._ItemsPanel != null && this._ItemsPanel.FirstVisible != null)
      {
        Size size = this._ItemsPanel.FirstVisible.RenderSize;
        if (size.Height > 0.0)
        {
          size = this._ItemsPanel.FirstVisible.RenderSize;
          return size.Height / 2.0;
        }
        size = this._ItemsPanel.FirstVisible.DesiredSize;
        if (size.Height > 0.0)
        {
          size = this._ItemsPanel.FirstVisible.DesiredSize;
          return size.Height / 2.0;
        }
      }
      return double.NaN;
    }
  }

  private void InternalPopupOpened(object sender, EventArgs e)
  {
    this.OnPopupOpened(new RoutedEventArgs(NavigationPane.PopupOpenedEvent, (object) this));
  }

  private void PopupToggleClick(object sender, RoutedEventArgs e)
  {
    if (this._Popup == null)
      return;
    bool? isChecked = this._PopupToggle.IsChecked;
    bool flag = true;
    if (isChecked.GetValueOrDefault() == flag & isChecked.HasValue)
    {
      this._Popup.Placement = PlacementMode.Right;
      this._Popup.PlacementTarget = (UIElement) this._PopupToggle;
      if (this.ExpandedWidth != double.NaN)
        this._Popup.Width = this.ExpandedWidth;
      else if (this._ActualExpandedWidth != double.NaN)
        this._Popup.Width = this._ActualExpandedWidth;
      this._Popup.Height = this._PopupToggle.RenderSize.Height + this._ItemsPanel.RenderSize.Height - this._ItemsPanel.SmallItemsHeight + 16.0;
      this._Popup.IsOpen = true;
      if (!Mouse.Capture((IInputElement) this, CaptureMode.SubTree))
        this._Popup.IsOpen = false;
      else
        this._Popup.Closed += new EventHandler(this.InternalPopupClosed);
    }
    else
      this._Popup.IsOpen = false;
  }

  private void InternalPopupClosed(object sender, EventArgs e)
  {
    if (this._PopupToggle != null)
      this._PopupToggle.IsChecked = new bool?(false);
    if (this._Popup != null)
      this._Popup.Closed -= new EventHandler(this.InternalPopupClosed);
    if (this.IsMouseCaptured)
      Mouse.Capture((IInputElement) null);
    this.OnPopupClosed(new RoutedEventArgs(NavigationPane.PopupClosedEvent, (object) this));
  }

  private bool IsPopupOpen => this._Popup != null && this._Popup.IsOpen;

  private static void OnLostMouseCapture(object sender, MouseEventArgs e)
  {
    ((NavigationPane) sender).SystemLostMouseCapture(e);
  }

  private void SystemLostMouseCapture(MouseEventArgs e)
  {
    if (!this.IsPopupOpen || Mouse.Captured == this)
      return;
    if (Mouse.Captured == null && this._ReTakeMouseCapture)
    {
      Mouse.Capture((IInputElement) this, CaptureMode.SubTree);
      this._ReTakeMouseCapture = false;
    }
    else if (Mouse.Captured != null && this.IgnoreMouseCapture(Mouse.Captured))
      this._ReTakeMouseCapture = true;
    else
      this.ClosePopup();
  }

  private bool IgnoreMouseCapture(IInputElement p)
  {
    return p is PaneItem && this.Items.Contains((object) p) || this.GetTemplateChild("PopupBorder") is UIElement templateChild && p is UIElement && ParentPopupControlImpl.IsChildOf(templateChild, p as UIElement);
  }

  protected override void OnPreviewMouseDown(MouseButtonEventArgs e)
  {
    if (this.IsPopupOpen && new Rect(this.RenderSize).Contains(e.GetPosition((IInputElement) this)))
      this.ClosePopup();
    base.OnPreviewMouseDown(e);
  }

  private static void MouseDownOutsideCapturedElement(object sender, MouseButtonEventArgs e)
  {
    ((NavigationPane) sender).MouseDownOutsideCapturedElement(e);
  }

  private void MouseDownOutsideCapturedElement(MouseButtonEventArgs e)
  {
    if (!this.IsPopupOpen)
      return;
    this.ClosePopup();
  }

  public void ClosePopup()
  {
    if (this._Popup == null)
      return;
    this._Popup.IsOpen = false;
  }

  protected override void OnInitialized(EventArgs e)
  {
    base.OnInitialized(e);
    PropertyInfo property = this.GetType().GetProperty("CanSelectMultiple", BindingFlags.Instance | BindingFlags.NonPublic);
    if (property != (PropertyInfo) null)
      property.SetValue((object) this, (object) false, (object[]) null);
    this.ItemContainerGenerator.StatusChanged += new EventHandler(this.OnGeneratorStatusChanged);
    this.CommandBindings.Add(new CommandBinding((ICommand) NavigationPane.Collapse, new ExecutedRoutedEventHandler(this.ExecuteCollapseCommand)));
    this.CommandBindings.Add(new CommandBinding((ICommand) NavigationPane.Expand, new ExecutedRoutedEventHandler(this.ExecuteExpandCommand)));
  }

  private void ExecuteCollapseCommand(object sender, ExecutedRoutedEventArgs e)
  {
    int selectedIndex = this.SelectedIndex;
    if (this.IsExpanded)
    {
      this.IsExpanded = false;
      this.SelectedIndex = selectedIndex;
    }
    e.Handled = true;
  }

  private void ExecuteExpandCommand(object sender, ExecutedRoutedEventArgs e)
  {
    int selectedIndex = this.SelectedIndex;
    if (!this.IsExpanded)
    {
      this.IsExpanded = true;
      this.SelectedIndex = selectedIndex;
    }
    e.Handled = true;
  }

  private void OnGeneratorStatusChanged(object sender, EventArgs e)
  {
    if (this.ItemContainerGenerator.Status != GeneratorStatus.ContainersGenerated)
      return;
    if (this.HasItems && this.SelectedIndex < 0)
      this.SelectedIndex = 0;
    this.UpdateItemsState();
    this.UpdateAllSelectedContent();
  }

  protected override void OnSelectionChanged(SelectionChangedEventArgs e)
  {
    base.OnSelectionChanged(e);
    this.UpdateAllSelectedContent();
    CommandManager.InvalidateRequerySuggested();
  }

  private void UpdateAllSelectedContent()
  {
    this.UpdateSelectedHeader();
    this.UpdateSelectedContent();
  }

  internal void UpdateSelectedContent()
  {
    if (this.SelectedIndex < 0)
    {
      this.SelectedContent = (object) null;
      this.SelectedPaneItem = (PaneItem) null;
    }
    else
    {
      HeaderedContentControl selectedItem = this.GetSelectedItem();
      if (selectedItem == null)
        return;
      this.SelectedPaneItem = selectedItem as PaneItem;
      this.SelectedContent = selectedItem.Content;
      ContentPresenter contentPresenter = this.GetSelectedContentPresenter();
      if (contentPresenter != null)
      {
        contentPresenter.HorizontalAlignment = HorizontalAlignment.Stretch;
        contentPresenter.VerticalAlignment = VerticalAlignment.Stretch;
      }
      if (selectedItem.ContentTemplate != null || selectedItem.ContentTemplateSelector != null)
      {
        this.SelectedContentTemplate = selectedItem.ContentTemplate;
        this.SelectedContentTemplateSelector = selectedItem.ContentTemplateSelector;
      }
      else
      {
        this.SelectedContentTemplate = this.ContentTemplate;
        this.SelectedContentTemplateSelector = this.ContentTemplateSelector;
      }
    }
  }

  internal ContentPresenter GetSelectedContentPresenter()
  {
    return this.GetTemplateChild("PART_PaneContentHost") as ContentPresenter;
  }

  internal void UpdateSelectedHeader()
  {
    if (this.SelectedIndex < 0)
    {
      this.SelectedContentHeader = (object) null;
    }
    else
    {
      HeaderedContentControl selectedItem = this.GetSelectedItem();
      if (selectedItem != null)
      {
        try
        {
          this.SelectedContentHeader = CloningMachine.GetObjectCopy(selectedItem.Header, false);
        }
        catch
        {
          Trace.WriteLine("Cannot clone the object header. Header: " + selectedItem.Header?.ToString());
        }
      }
      PaneItem paneItem = selectedItem as PaneItem;
      if (selectedItem == null || paneItem.Title == null)
        return;
      this.SelectedContentHeader = (object) paneItem.Title;
    }
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public PaneItem SelectedPaneItem
  {
    get => (PaneItem) this.GetValue(NavigationPane.SelectedPaneItemProperty);
    internal set => this.SetValue(NavigationPane.SelectedPaneItemPropertyKey, (object) value);
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public object SelectedContent
  {
    get => this.GetValue(NavigationPane.SelectedContentProperty);
    internal set => this.SetValue(NavigationPane.SelectedContentPropertyKey, value);
  }

  public DataTemplate SelectedContentHeaderTemplate
  {
    get => (DataTemplate) this.GetValue(NavigationPane.SelectedContentHeaderTemplateProperty);
    set => this.SetValue(NavigationPane.SelectedContentHeaderTemplateProperty, (object) value);
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public DataTemplate SelectedContentTemplate
  {
    get => (DataTemplate) this.GetValue(NavigationPane.SelectedContentTemplateProperty);
    internal set
    {
      this.SetValue(NavigationPane.SelectedContentTemplatePropertyKey, (object) value);
    }
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public DataTemplateSelector SelectedContentTemplateSelector
  {
    get
    {
      return (DataTemplateSelector) this.GetValue(NavigationPane.SelectedContentTemplateSelectorProperty);
    }
    internal set
    {
      this.SetValue(NavigationPane.SelectedContentTemplateSelectorPropertyKey, (object) value);
    }
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public object SelectedContentHeader
  {
    get => this.GetValue(NavigationPane.SelectedContentHeaderProperty);
    internal set => this.SetValue(NavigationPane.SelectedContentHeaderPropertyKey, value);
  }

  public DataTemplate ContentTemplate
  {
    get => (DataTemplate) this.GetValue(NavigationPane.ContentTemplateProperty);
    set => this.SetValue(NavigationPane.ContentTemplateProperty, (object) value);
  }

  public DataTemplateSelector ContentTemplateSelector
  {
    get => (DataTemplateSelector) this.GetValue(NavigationPane.ContentTemplateSelectorProperty);
    set => this.SetValue(NavigationPane.ContentTemplateSelectorProperty, (object) value);
  }

  private HeaderedContentControl GetSelectedItem()
  {
    if (!(this.SelectedItem is HeaderedContentControl selectedItem) && this.SelectedItem != null)
      selectedItem = this.ItemContainerGenerator.ContainerFromItem(this.SelectedItem) as HeaderedContentControl;
    return selectedItem;
  }

  protected override void OnItemsChanged(NotifyCollectionChangedEventArgs e)
  {
    if (this.SelectedIndex == -1 && this.Items.Count > 0 && this.ItemContainerGenerator.Status == GeneratorStatus.ContainersGenerated)
    {
      foreach (object obj in (IEnumerable) this.Items)
      {
        if (obj is UIElement)
        {
          if ((obj as UIElement).Visibility == Visibility.Visible)
          {
            this.SelectedItem = obj;
            break;
          }
        }
        else
        {
          this.SelectedItem = obj;
          break;
        }
      }
    }
    this.UpdateItemsState();
    base.OnItemsChanged(e);
  }

  internal void UpdateItemsState()
  {
    int largeItemsCount = this.LargeItemsCount;
    bool isExpanded = this.IsExpanded;
    for (int index = 0; index < this.Items.Count; ++index)
    {
      if (!(this.Items[index] is PaneItem paneItem))
        paneItem = this.ItemContainerGenerator.ContainerFromIndex(index) as PaneItem;
      if (paneItem != null)
      {
        if (paneItem.PaneExpanded != isExpanded)
          paneItem.PaneExpanded = isExpanded;
        if (paneItem.Visibility != Visibility.Collapsed)
        {
          if (largeItemsCount > 0)
          {
            paneItem.SmallState = false;
            --largeItemsCount;
          }
          else
            paneItem.SmallState = true;
        }
      }
    }
  }

  private static void IsExpandedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
  {
    ((NavigationPane) d).IsExpandedChanged(e);
  }

  private void IsExpandedChanged(DependencyPropertyChangedEventArgs e)
  {
    if (this.IsExpanded)
    {
      this.Width = this.ExpandedWidth;
      this.ExpandedWidth = double.NaN;
      this.OnExpanded(new RoutedEventArgs(NavigationPane.ExpandedEvent, (object) this));
    }
    else
    {
      this.ExpandedWidth = this.Width;
      this._ActualExpandedWidth = this.ActualWidth;
      this.Width = this.CollapsedWidth;
      this.OnCollapsed(new RoutedEventArgs(NavigationPane.CollapsedEvent, (object) this));
    }
    this.UpdateItemsState();
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public double ExpandedWidth
  {
    get => (double) this.GetValue(NavigationPane.ExpandedWidthProperty);
    set => this.SetValue(NavigationPane.ExpandedWidthProperty, (object) value);
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public double CollapsedWidth
  {
    get => (double) this.GetValue(NavigationPane.CollapsedWidthProperty);
    set => this.SetValue(NavigationPane.CollapsedWidthProperty, (object) value);
  }

  private static void LargeItemsCountChanged(
    DependencyObject d,
    DependencyPropertyChangedEventArgs e)
  {
    ((NavigationPane) d).LargeItemsCountChanged(e);
  }

  private void LargeItemsCountChanged(DependencyPropertyChangedEventArgs e)
  {
    this.UpdateItemsState();
  }

  [Bindable(true)]
  public int LargeItemsCount
  {
    get => (int) this.GetValue(NavigationPane.LargeItemsCountProperty);
    set => this.SetValue(NavigationPane.LargeItemsCountProperty, (object) value);
  }

  protected override bool IsItemItsOwnContainerOverride(object item) => item is PaneItem;

  protected override DependencyObject GetContainerForItemOverride()
  {
    return (DependencyObject) new PaneItem();
  }

  [Bindable(true)]
  public bool IsExpanded
  {
    get => (bool) this.GetValue(NavigationPane.IsExpandedProperty);
    set => this.SetValue(NavigationPane.IsExpandedProperty, (object) value);
  }

  public void ShowOptionsDialog()
  {
    RoutedEventArgs e = new RoutedEventArgs(NavigationPane.BeforeCustomizeDialogEvent, (object) this);
    this.OnBeforeCustomizeDialogEvent(e);
    if (e.Handled)
      return;
    NavigationPaneCustomizeDialog paneCustomizeDialog = new NavigationPaneCustomizeDialog();
    paneCustomizeDialog.Initialize(this);
    if (BrowserInteropHelper.IsBrowserHosted)
    {
      paneCustomizeDialog.WindowStartupLocation = WindowStartupLocation.CenterScreen;
    }
    else
    {
      Window window = Window.GetWindow((DependencyObject) this);
      if (window != null)
        paneCustomizeDialog.Owner = window;
    }
    paneCustomizeDialog.ShowDialog();
  }

  internal void ItemVisibilityChanged(PaneItem paneItem)
  {
    if (!paneItem.IsSelected || paneItem.Visibility == Visibility.Visible)
      return;
    foreach (object obj in (IEnumerable) this.Items)
    {
      if (obj is PaneItem paneItem1 && paneItem1.Visibility == Visibility.Visible)
      {
        paneItem1.IsSelected = true;
        break;
      }
    }
  }

  public NavigationPaneLocalization SystemText
  {
    get => (NavigationPaneLocalization) this.GetValue(NavigationPane.SystemTextProperty);
    internal set => this.SetValue(NavigationPane.SystemTextPropertyKey, (object) value);
  }
}
