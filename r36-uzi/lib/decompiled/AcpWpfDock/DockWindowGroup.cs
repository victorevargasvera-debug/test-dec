// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfDock.DockWindowGroup
// Assembly: AcpWpfDock, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 89CC52D3-0487-4106-AFAE-BE4A13C8A50E
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfDock.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Markup;
using System.Xml;

#nullable disable
namespace DevComponents.WpfDock;

[TemplatePart(Name = "PART_GroupCaption", Type = typeof (Decorator))]
[DesignTimeVisible(false)]
public class DockWindowGroup : Selector
{
  public static readonly DependencyProperty SelectedContentProperty;
  private static readonly DependencyPropertyKey SelectedContentPropertyKey;
  public static readonly DependencyProperty SelectedDockWindowProperty;
  private static readonly DependencyPropertyKey SelectedDockWindowPropertyKey;
  public static readonly DependencyProperty SelectedContentTemplateProperty;
  private static readonly DependencyPropertyKey SelectedContentTemplatePropertyKey;
  public static readonly DependencyProperty SelectedContentTemplateSelectorProperty;
  private static readonly DependencyPropertyKey SelectedContentTemplateSelectorPropertyKey;
  public static readonly DependencyProperty SelectedContentHeaderProperty;
  public static readonly DependencyProperty ContentTemplateSelectorProperty;
  public static readonly DependencyProperty ContentTemplateProperty;
  public static readonly DependencyProperty IsFloatingProperty;
  private static readonly DependencyPropertyKey IsFloatingPropertyKey;
  public static readonly DependencyProperty TabVisibilityProperty;
  private static readonly DependencyPropertyKey TabVisibilityPropertyKey;
  public static readonly DependencyProperty CanCloseProperty;
  private static readonly DependencyPropertyKey CanClosePropertyKey;
  public static readonly DependencyProperty CanAutoHideProperty;
  private static readonly DependencyPropertyKey CanAutoHidePropertyKey;
  public static readonly DependencyProperty IsAutoHideProperty;
  private static readonly DependencyPropertyKey IsAutoHidePropertyKey;
  public static readonly DependencyProperty OptionsMenuProperty;
  private static readonly DependencyPropertyKey OptionsMenuPropertyKey;
  private const string PartTabContentPresenter = "PART_TabContentHost";
  private const string PartGroupCaption = "PART_GroupCaption";
  private const string PartButtonOptions = "OptionsButton";
  private const string PartContextMenuOptions = "OptionsMenu";
  private const string PartContextMenuWindowList = "WindowList";
  private const string PartTabPanel = "PART_TabPanel";
  private const string PartInnerContent = "InnerContent";
  private UIElement m_GroupCaption;
  private System.Windows.Point m_MouseDownPoint;
  private eDockSide m_LastDockSide = eDockSide.Left;
  private eDockSide m_LastDockReference = eDockSide.Left;
  private string m_LastDockReferenceId = "";
  private bool m_LastDockIsFullSizeDock;
  internal bool AutoHideGroup;
  private string m_Id = "";
  private Panel m_TabPanel;
  private Button m_ButtonOptions;
  private ContextMenu m_ContextMenuOptions;
  private ContextMenu m_ContextMenuWindowsList;
  private UIElement m_InnerContent;
  private bool m_DoubleClicked;
  private DockSite _OwnerSite;
  private bool _LastIsDocument;

  static DockWindowGroup()
  {
    FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof (DockWindowGroup), (PropertyMetadata) new FrameworkPropertyMetadata((object) typeof (DockWindowGroup)));
    DockWindowGroup.SelectedContentPropertyKey = DependencyProperty.RegisterReadOnly(nameof (SelectedContent), typeof (object), typeof (DockWindowGroup), (PropertyMetadata) new FrameworkPropertyMetadata((PropertyChangedCallback) null));
    DockWindowGroup.SelectedContentProperty = DockWindowGroup.SelectedContentPropertyKey.DependencyProperty;
    DockWindowGroup.SelectedContentTemplatePropertyKey = DependencyProperty.RegisterReadOnly(nameof (SelectedContentTemplate), typeof (DataTemplate), typeof (DockWindowGroup), (PropertyMetadata) new FrameworkPropertyMetadata((PropertyChangedCallback) null));
    DockWindowGroup.SelectedContentTemplateProperty = DockWindowGroup.SelectedContentTemplatePropertyKey.DependencyProperty;
    DockWindowGroup.SelectedContentTemplateSelectorPropertyKey = DependencyProperty.RegisterReadOnly(nameof (SelectedContentTemplateSelector), typeof (DataTemplateSelector), typeof (DockWindowGroup), (PropertyMetadata) new FrameworkPropertyMetadata((PropertyChangedCallback) null));
    DockWindowGroup.SelectedContentTemplateSelectorProperty = DockWindowGroup.SelectedContentTemplateSelectorPropertyKey.DependencyProperty;
    DockWindowGroup.SelectedContentHeaderProperty = DependencyProperty.Register(nameof (SelectedContentHeader), typeof (object), typeof (DockWindowGroup), (PropertyMetadata) new FrameworkPropertyMetadata((PropertyChangedCallback) null));
    DockWindowGroup.ContentTemplateProperty = DependencyProperty.Register(nameof (ContentTemplate), typeof (DataTemplate), typeof (DockWindowGroup), (PropertyMetadata) new FrameworkPropertyMetadata((PropertyChangedCallback) null));
    DockWindowGroup.ContentTemplateSelectorProperty = DependencyProperty.Register(nameof (ContentTemplateSelector), typeof (DataTemplateSelector), typeof (DockWindowGroup), (PropertyMetadata) new FrameworkPropertyMetadata((PropertyChangedCallback) null));
    DockWindowGroup.IsFloatingPropertyKey = DependencyProperty.RegisterReadOnly(nameof (IsFloating), typeof (bool), typeof (DockWindowGroup), (PropertyMetadata) new FrameworkPropertyMetadata((object) false));
    DockWindowGroup.IsFloatingProperty = DockWindowGroup.IsFloatingPropertyKey.DependencyProperty;
    DockWindowGroup.TabVisibilityPropertyKey = DependencyProperty.RegisterReadOnly(nameof (TabVisibility), typeof (Visibility), typeof (DockWindowGroup), (PropertyMetadata) new FrameworkPropertyMetadata((object) Visibility.Visible, new PropertyChangedCallback(DockWindowGroup.OnTabVisibilityChanged)));
    DockWindowGroup.TabVisibilityProperty = DockWindowGroup.TabVisibilityPropertyKey.DependencyProperty;
    DockWindowGroup.CanClosePropertyKey = DependencyProperty.RegisterReadOnly(nameof (CanClose), typeof (bool), typeof (DockWindowGroup), (PropertyMetadata) new FrameworkPropertyMetadata((object) false));
    DockWindowGroup.CanCloseProperty = DockWindowGroup.CanClosePropertyKey.DependencyProperty;
    DockWindowGroup.CanAutoHidePropertyKey = DependencyProperty.RegisterReadOnly(nameof (CanAutoHide), typeof (bool), typeof (DockWindowGroup), (PropertyMetadata) new FrameworkPropertyMetadata((object) false));
    DockWindowGroup.CanAutoHideProperty = DockWindowGroup.CanAutoHidePropertyKey.DependencyProperty;
    DockWindowGroup.IsAutoHidePropertyKey = DependencyProperty.RegisterReadOnly(nameof (IsAutoHide), typeof (bool), typeof (DockWindowGroup), (PropertyMetadata) new FrameworkPropertyMetadata((object) false));
    DockWindowGroup.IsAutoHideProperty = DockWindowGroup.IsAutoHidePropertyKey.DependencyProperty;
    DockWindowGroup.OptionsMenuPropertyKey = DependencyProperty.RegisterReadOnly(nameof (OptionsMenu), typeof (Visibility), typeof (DockWindowGroup), (PropertyMetadata) new FrameworkPropertyMetadata((object) Visibility.Visible));
    DockWindowGroup.OptionsMenuProperty = DockWindowGroup.OptionsMenuPropertyKey.DependencyProperty;
    DockWindowGroup.SelectedDockWindowPropertyKey = DependencyProperty.RegisterReadOnly(nameof (SelectedDockWindow), typeof (DockWindow), typeof (DockWindowGroup), (PropertyMetadata) new FrameworkPropertyMetadata((PropertyChangedCallback) null));
    DockWindowGroup.SelectedDockWindowProperty = DockWindowGroup.SelectedDockWindowPropertyKey.DependencyProperty;
  }

  public DockWindowGroup() => this.m_Id = Guid.NewGuid().ToString();

  public override void OnApplyTemplate()
  {
    base.OnApplyTemplate();
    if (this.m_GroupCaption != null)
    {
      this.m_GroupCaption.MouseLeftButtonDown -= new MouseButtonEventHandler(this.GroupCaptionMouseLeftButtonDown);
      this.m_GroupCaption.MouseMove -= new MouseEventHandler(this.GroupCaptionMouseMove);
      this.m_GroupCaption.MouseLeave -= new MouseEventHandler(this.GroupCaptionMouseLeave);
    }
    if (this.m_ButtonOptions != null)
      this.m_ButtonOptions.PreviewMouseLeftButtonDown -= new MouseButtonEventHandler(this.ButtonOptionsMouseLeftButtonDown);
    this.m_GroupCaption = this.GetTemplateChild("PART_GroupCaption") as UIElement;
    if (this.m_GroupCaption != null)
    {
      this.m_GroupCaption.MouseLeftButtonDown += new MouseButtonEventHandler(this.GroupCaptionMouseLeftButtonDown);
      this.m_GroupCaption.MouseMove += new MouseEventHandler(this.GroupCaptionMouseMove);
      this.m_GroupCaption.MouseLeave += new MouseEventHandler(this.GroupCaptionMouseLeave);
    }
    this.m_InnerContent = (UIElement) null;
    this.m_ButtonOptions = this.GetTemplateChild("OptionsButton") as Button;
    if (this.m_ButtonOptions != null)
    {
      this.m_ButtonOptions.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(this.ButtonOptionsMouseLeftButtonDown);
      this.m_ButtonOptions.PreviewMouseRightButtonUp += new MouseButtonEventHandler(this.ButtonOptionsMouseRightButtonDown);
    }
    this.m_ContextMenuOptions = this.GetTemplateChild("OptionsMenu") as ContextMenu;
    if (this.m_ContextMenuOptions != null)
      this.m_ContextMenuOptions.Opened += new RoutedEventHandler(this.ContextMenuOptionsOpened);
    this.m_ContextMenuWindowsList = this.GetTemplateChild("WindowList") as ContextMenu;
    if (this.m_ContextMenuWindowsList != null)
      this.m_ContextMenuWindowsList.Opened += new RoutedEventHandler(this.ContextMenuWindowListOpened);
    this.m_TabPanel = this.GetTemplateChild("PART_TabPanel") as Panel;
    this.m_InnerContent = this.GetTemplateChild("InnerContent") as UIElement;
    this.UpdateAllSelectedContent();
  }

  internal UIElement InnerContent => this.m_InnerContent;

  private void ContextMenuWindowListOpened(object sender, RoutedEventArgs e)
  {
    if (!DockSite.GetIsDocument((UIElement) this))
      return;
    this.LoadOpenDocumentsToMenu(this.m_ContextMenuWindowsList);
  }

  private void ContextMenuOptionsOpened(object sender, RoutedEventArgs e)
  {
    DockSite dockSite = this.GetDockSite(true);
    if (dockSite == null)
      return;
    DockLocalization systemText = dockSite.SystemText;
    foreach (object obj in (IEnumerable) this.m_ContextMenuOptions.Items)
    {
      if (obj is MenuItem menuItem)
      {
        switch (menuItem.Name)
        {
          case "MenuOptionFloating":
            menuItem.Header = (object) systemText.OptionsMenuFloatingText;
            if (this.SelectedDockWindow != null)
            {
              menuItem.IsChecked = this.SelectedDockWindow.IsFloating;
              continue;
            }
            continue;
          case "MenuOptionDockable":
            menuItem.Header = (object) systemText.OptionsMenuDockableText;
            if (this.SelectedDockWindow != null)
            {
              menuItem.IsChecked = !this.SelectedDockWindow.IsFloating && !this.SelectedDockWindow.IsAutoHide && !DockSite.GetIsDocument((UIElement) this.SelectedDockWindow);
              continue;
            }
            continue;
          case "MenuOptionTabbedDoc":
            menuItem.Header = (object) systemText.OptionsMenuTabbedDocumentText;
            if (this.SelectedDockWindow != null)
            {
              menuItem.IsEnabled = true;
              menuItem.Visibility = this.SelectedDockWindow.CanDockAsDocument ? Visibility.Visible : Visibility.Collapsed;
              if (DockSite.GetIsDocument((UIElement) this.SelectedDockWindow))
              {
                menuItem.IsChecked = true;
                continue;
              }
              continue;
            }
            menuItem.IsEnabled = false;
            continue;
          case "MenuOptionAutoHide":
            menuItem.Header = (object) systemText.OptionsMenuAutoHideText;
            if (this.SelectedDockWindow != null)
            {
              menuItem.IsEnabled = true;
              menuItem.IsChecked = this.SelectedDockWindow.IsAutoHide;
              if (DockSite.GetIsDocument((UIElement) this) || !this.SelectedDockWindow.CanAutoHide)
              {
                menuItem.IsEnabled = false;
                continue;
              }
              continue;
            }
            menuItem.IsEnabled = false;
            continue;
          case "MenuOptionHide":
            menuItem.Header = (object) systemText.OptionsMenuHideText;
            continue;
          default:
            continue;
        }
      }
    }
  }

  private void LoadOpenDocumentsToMenu(ContextMenu parentMenu)
  {
    parentMenu.Items.Clear();
    foreach (object obj in (IEnumerable) this.Items)
    {
      if (obj is HeaderedContentControl && ((UIElement) obj).Visibility == Visibility.Visible)
      {
        DockWindow dockWindow = obj as DockWindow;
        HeaderedContentControl headeredContentControl = obj as HeaderedContentControl;
        MenuItem newItem = new MenuItem();
        if (dockWindow != null)
        {
          newItem.Header = DockWindowGroup.XamlClone(dockWindow.Header);
          newItem.Icon = DockWindowGroup.XamlClone(dockWindow.Image);
        }
        else
          newItem.Header = DockWindowGroup.XamlClone(headeredContentControl.Header);
        if (newItem.Header != null)
        {
          parentMenu.Items.Add((object) newItem);
          if (dockWindow != null)
          {
            if (dockWindow.IsSelected)
              newItem.IsChecked = true;
            newItem.Command = (ICommand) DockWindow.SelectWindow;
            newItem.CommandTarget = (IInputElement) dockWindow;
          }
        }
      }
    }
  }

  internal static object XamlClone(object source)
  {
    if (source == null)
      return (object) null;
    if (source is string)
      return (object) source.ToString();
    return source.GetType().IsValueType ? source : XamlReader.Load(XmlReader.Create((TextReader) new StringReader(XamlWriter.Save(source))));
  }

  private void ButtonOptionsMouseRightButtonDown(object sender, MouseButtonEventArgs e)
  {
    e.Handled = true;
  }

  private void ButtonOptionsMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
  {
    ContextMenu contextMenu = DockSite.GetIsDocument((UIElement) this) ? this.m_ContextMenuWindowsList : this.m_ContextMenuOptions;
    if (this.SelectedDockWindow != null && this.SelectedDockWindow.CustomOptionsMenu != null)
      contextMenu = this.SelectedDockWindow.CustomOptionsMenu;
    if (contextMenu == null)
      return;
    e.Handled = true;
    contextMenu.PlacementTarget = (UIElement) this.m_ButtonOptions;
    contextMenu.Placement = PlacementMode.Bottom;
    contextMenu.IsOpen = true;
  }

  private void GroupCaptionMouseLeave(object sender, MouseEventArgs e)
  {
    if (this.m_DoubleClicked || e.LeftButton != MouseButtonState.Pressed || LayoutHelpers.IsEmpty(this.m_MouseDownPoint) || this.AutoHideGroup)
      return;
    this.m_MouseDownPoint = new System.Windows.Point();
    DockSite dockSite = this.GetDockSite();
    if (dockSite == null || dockSite.IsDockingInProgress)
      return;
    dockSite.StartDockWindowDrag(this, false, eEventActionSource.Mouse);
  }

  public DockSite GetDockSite() => this.GetDockSite(false);

  private DockSite GetDockSite(bool checkAutoHideState)
  {
    return checkAutoHideState && this.AutoHideGroup && this._OwnerSite != null ? this._OwnerSite : DockSite.GetDockSite((DependencyObject) this);
  }

  internal DockSite OwnerSite
  {
    get => this._OwnerSite;
    set => this._OwnerSite = value;
  }

  private void GroupCaptionMouseMove(object sender, MouseEventArgs e)
  {
    if (e.LeftButton != MouseButtonState.Pressed || LayoutHelpers.IsEmpty(this.m_MouseDownPoint) || this.AutoHideGroup)
      return;
    System.Windows.Point position = e.GetPosition((IInputElement) this);
    if (Math.Abs(position.X - this.m_MouseDownPoint.X) < 4.0 && Math.Abs(position.Y - this.m_MouseDownPoint.Y) < 4.0)
      return;
    this.m_MouseDownPoint = new System.Windows.Point();
    this.GetDockSite()?.StartDockWindowDrag(this, false, eEventActionSource.Mouse);
  }

  private void GroupCaptionMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
  {
    if (e.ClickCount == 2)
    {
      if (!e.Handled)
      {
        try
        {
          this.m_DoubleClicked = true;
          DockSite dockSite = this.GetDockSite();
          dockSite?.FloatWindow(this);
          this.m_MouseDownPoint = new System.Windows.Point();
          dockSite?.Focus();
          return;
        }
        finally
        {
          this.m_DoubleClicked = false;
        }
      }
    }
    this.m_MouseDownPoint = e.GetPosition((IInputElement) this);
  }

  internal void UpdateAllSelectedContent()
  {
    this.UpdateSelectedHeader();
    this.UpdateSelectedContent();
  }

  internal void UpdateSelectedContent()
  {
    if (this.SelectedIndex < 0)
    {
      if (this.AutoHideGroup)
        return;
      this.SelectedContent = (object) null;
      this.SelectedDockWindow = (DockWindow) null;
    }
    else
    {
      HeaderedContentControl selectedItem = this.GetSelectedItem();
      if (selectedItem == null)
        return;
      this.SelectedDockWindow = selectedItem as DockWindow;
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

  internal void UpdateSelectedHeader()
  {
    if (this.SelectedIndex < 0)
    {
      if (this.AutoHideGroup)
        return;
      this.SelectedContentHeader = (object) null;
    }
    else
    {
      HeaderedContentControl selectedItem = this.GetSelectedItem();
      if (selectedItem == null)
        return;
      this.SelectedContentHeader = this.GetHeaderCopy(selectedItem.Header);
    }
  }

  internal object GetHeaderCopy(object p)
  {
    if (p == null)
      return (object) null;
    return p is string ? (object) p.ToString() : XamlReader.Load(XmlReader.Create((TextReader) new StringReader(XamlWriter.Save(p))));
  }

  internal ContentPresenter GetSelectedContentPresenter()
  {
    return this.GetTemplateChild("PART_TabContentHost") as ContentPresenter;
  }

  protected override void OnInitialized(EventArgs e)
  {
    base.OnInitialized(e);
    PropertyInfo property = this.GetType().GetProperty("CanSelectMultiple", BindingFlags.Instance | BindingFlags.NonPublic);
    if (property != (PropertyInfo) null)
      property.SetValue((object) this, (object) false, (object[]) null);
    this.ItemContainerGenerator.StatusChanged += new EventHandler(this.OnGeneratorStatusChanged);
  }

  private void OnGeneratorStatusChanged(object sender, EventArgs e)
  {
    if (this.ItemContainerGenerator.Status != GeneratorStatus.ContainersGenerated)
      return;
    if (this.HasItems && this.SelectedIndex < 0)
      this.SelectedIndex = 0;
    this.UpdateAllSelectedContent();
    this.UpdateTabVisibility();
  }

  protected override void OnSelectionChanged(SelectionChangedEventArgs e)
  {
    base.OnSelectionChanged(e);
    this.UpdateAllSelectedContent();
    this.UpdateZOrder();
    this.UpdateStateProperties();
    CommandManager.InvalidateRequerySuggested();
  }

  internal void UpdateStateProperties()
  {
    bool flag1 = false;
    if (this.SelectedDockWindow != null)
      flag1 = this.SelectedDockWindow.CanClose;
    if (this.CanClose != flag1)
      this.CanClose = flag1;
    bool flag2 = false;
    if (this.SelectedDockWindow != null)
      flag2 = this.SelectedDockWindow.CanAutoHide;
    if (this.CanAutoHide != flag2)
      this.CanAutoHide = flag2;
    bool flag3 = false;
    if (this.SelectedDockWindow != null)
      flag3 = this.SelectedDockWindow.IsAutoHide;
    if (this.IsAutoHide != flag3)
      this.IsAutoHide = flag3;
    Visibility visibility = Visibility.Visible;
    if (this.SelectedDockWindow != null)
      visibility = this.SelectedDockWindow.OptionsMenu ? Visibility.Visible : Visibility.Collapsed;
    if (this.OptionsMenu == visibility)
      return;
    this.OptionsMenu = visibility;
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public DockWindow SelectedDockWindow
  {
    get => (DockWindow) this.GetValue(DockWindowGroup.SelectedDockWindowProperty);
    internal set => this.SetValue(DockWindowGroup.SelectedDockWindowPropertyKey, (object) value);
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public object SelectedContent
  {
    get => this.GetValue(DockWindowGroup.SelectedContentProperty);
    internal set => this.SetValue(DockWindowGroup.SelectedContentPropertyKey, value);
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public DataTemplate SelectedContentTemplate
  {
    get => (DataTemplate) this.GetValue(DockWindowGroup.SelectedContentTemplateProperty);
    internal set
    {
      this.SetValue(DockWindowGroup.SelectedContentTemplatePropertyKey, (object) value);
    }
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public DataTemplateSelector SelectedContentTemplateSelector
  {
    get
    {
      return (DataTemplateSelector) this.GetValue(DockWindowGroup.SelectedContentTemplateSelectorProperty);
    }
    internal set
    {
      this.SetValue(DockWindowGroup.SelectedContentTemplateSelectorPropertyKey, (object) value);
    }
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public object SelectedContentHeader
  {
    get => this.GetValue(DockWindowGroup.SelectedContentHeaderProperty);
    internal set => this.SetValue(DockWindowGroup.SelectedContentHeaderProperty, value);
  }

  public DataTemplate ContentTemplate
  {
    get => (DataTemplate) this.GetValue(DockWindowGroup.ContentTemplateProperty);
    set => this.SetValue(DockWindowGroup.ContentTemplateProperty, (object) value);
  }

  public DataTemplateSelector ContentTemplateSelector
  {
    get => (DataTemplateSelector) this.GetValue(DockWindowGroup.ContentTemplateSelectorProperty);
    set => this.SetValue(DockWindowGroup.ContentTemplateSelectorProperty, (object) value);
  }

  private HeaderedContentControl GetSelectedItem()
  {
    if (!(this.SelectedItem is HeaderedContentControl selectedItem) && this.ItemsSource != null && this.SelectedItem != null)
      selectedItem = this.ItemContainerGenerator.ContainerFromItem(this.SelectedItem) as HeaderedContentControl;
    return selectedItem;
  }

  internal bool CanFloat
  {
    get => !(this.SelectedItem is DockWindow) || ((DockWindow) this.SelectedItem).CanFloat;
  }

  [EditorBrowsable(EditorBrowsableState.Never)]
  [Browsable(false)]
  public bool CanDockTop
  {
    get => !(this.SelectedItem is DockWindow) || ((DockWindow) this.SelectedItem).CanDockTop;
  }

  [EditorBrowsable(EditorBrowsableState.Never)]
  [Browsable(false)]
  public bool CanDockBottom
  {
    get => !(this.SelectedItem is DockWindow) || ((DockWindow) this.SelectedItem).CanDockBottom;
  }

  [EditorBrowsable(EditorBrowsableState.Never)]
  [Browsable(false)]
  public bool CanDockLeft
  {
    get => !(this.SelectedItem is DockWindow) || ((DockWindow) this.SelectedItem).CanDockLeft;
  }

  [EditorBrowsable(EditorBrowsableState.Never)]
  [Browsable(false)]
  public bool CanDockRight
  {
    get => !(this.SelectedItem is DockWindow) || ((DockWindow) this.SelectedItem).CanDockRight;
  }

  [EditorBrowsable(EditorBrowsableState.Never)]
  [Browsable(false)]
  public bool CanDockAsDocument
  {
    get => !(this.SelectedItem is DockWindow) || ((DockWindow) this.SelectedItem).CanDockAsDocument;
  }

  internal Rect FloatingRect
  {
    get
    {
      return this.SelectedItem is DockWindow ? ((DockWindow) this.SelectedItem).FloatingRect : new Rect(100.0, 100.0, 150.0, 200.0);
    }
    set
    {
      if (!(this.SelectedItem is DockWindow))
        return;
      ((DockWindow) this.SelectedItem).FloatingRect = value;
    }
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  [Browsable(false)]
  public bool IsFloating
  {
    get => (bool) this.GetValue(DockWindowGroup.IsFloatingProperty);
    internal set => this.SetValue(DockWindowGroup.IsFloatingPropertyKey, (object) value);
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  [Browsable(false)]
  public Visibility TabVisibility
  {
    get => (Visibility) this.GetValue(DockWindowGroup.TabVisibilityProperty);
    internal set => this.SetValue(DockWindowGroup.TabVisibilityPropertyKey, (object) value);
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  [Browsable(false)]
  public bool CanClose
  {
    get => (bool) this.GetValue(DockWindowGroup.CanCloseProperty);
    internal set => this.SetValue(DockWindowGroup.CanClosePropertyKey, (object) value);
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  [Browsable(false)]
  public bool CanAutoHide
  {
    get => (bool) this.GetValue(DockWindowGroup.CanAutoHideProperty);
    internal set => this.SetValue(DockWindowGroup.CanAutoHidePropertyKey, (object) value);
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  [Browsable(false)]
  public bool IsAutoHide
  {
    get => (bool) this.GetValue(DockWindowGroup.IsAutoHideProperty);
    internal set => this.SetValue(DockWindowGroup.IsAutoHidePropertyKey, (object) value);
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  [Browsable(false)]
  public Visibility OptionsMenu
  {
    get => (Visibility) this.GetValue(DockWindowGroup.OptionsMenuProperty);
    internal set => this.SetValue(DockWindowGroup.OptionsMenuPropertyKey, (object) value);
  }

  internal int VisibleItemsCount
  {
    get
    {
      int visibleItemsCount = 0;
      foreach (object obj in (IEnumerable) this.Items)
      {
        if (this.ItemContainerGenerator.ContainerFromItem(obj) is FrameworkElement frameworkElement && frameworkElement.Visibility == Visibility.Visible)
          ++visibleItemsCount;
      }
      return visibleItemsCount;
    }
  }

  protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
  {
    base.PrepareContainerForItemOverride(element, item);
    if (element == item || !(element is DockWindow))
      return;
    ((DockWindow) element).SetParentGroup(this);
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
    bool flag = this.ItemsSource != null;
    if (e.Action == NotifyCollectionChangedAction.Reset)
    {
      foreach (object obj in (IEnumerable) this.Items)
      {
        if (obj is DockWindow child)
        {
          if (flag)
            this.AddLogicalChild((object) child);
          child.InvokeDockParentChanged();
        }
        else if (this.ItemContainerGenerator.ContainerFromItem(obj) is DockWindow dockWindow)
          dockWindow.InvokeDockParentChanged();
      }
    }
    if (e.NewItems != null)
    {
      foreach (object newItem in (IEnumerable) e.NewItems)
      {
        if (newItem is DockWindow child)
        {
          if (flag)
            this.AddLogicalChild((object) child);
          child.InvokeDockParentChanged();
        }
        else if (this.ItemContainerGenerator.ContainerFromItem(newItem) is DockWindow dockWindow)
          dockWindow.InvokeDockParentChanged();
      }
    }
    if (e.OldItems != null)
    {
      foreach (object oldItem in (IEnumerable) e.OldItems)
      {
        if (oldItem is DockWindow child)
        {
          if (flag)
            this.RemoveLogicalChild((object) child);
          child.InvokeDockParentChanged();
        }
        else if (this.ItemContainerGenerator.ContainerFromItem(oldItem) is DockWindow dockWindow)
          dockWindow.InvokeDockParentChanged();
      }
    }
    this.UpdateZOrder();
    this.UpdateTabVisibility();
    this.GetDockSite()?.UpdateIsDocument(this);
    base.OnItemsChanged(e);
  }

  public void UpdateTabVisibility()
  {
    if (this.ItemContainerGenerator.Status != GeneratorStatus.ContainersGenerated)
      return;
    Visibility visibility = Visibility.Visible;
    if (this.VisibleItemsCount <= 1 && !DockSite.GetIsDocument((UIElement) this))
      visibility = Visibility.Collapsed;
    if (this.TabVisibility == visibility)
      return;
    this.TabVisibility = visibility;
  }

  private static void OnTabVisibilityChanged(
    DependencyObject d,
    DependencyPropertyChangedEventArgs e)
  {
    DockWindowGroup dockWindowGroup = (DockWindowGroup) d;
    foreach (object obj in (IEnumerable) dockWindowGroup.Items)
    {
      if (!(obj is DockWindow dockWindow))
        dockWindow = dockWindowGroup.ItemContainerGenerator.ContainerFromItem(obj) as DockWindow;
      dockWindow?.InvokeTabVisibilityChangedEvent();
    }
  }

  public void UpdateVisibility() => this.UpdateVisibility(this.VisibleItemsCount > 0);

  internal void UpdateVisibility(bool isVisible)
  {
    if (!isVisible)
    {
      this.Visibility = Visibility.Collapsed;
      if (!(this.Parent is SplitPanel))
        return;
      ((SplitPanel) this.Parent).UpdateAutoVisibility();
    }
    else
    {
      if (this.Visibility != Visibility.Visible)
        this.Visibility = Visibility.Visible;
      if (!(this.Parent is SplitPanel))
        return;
      ((SplitPanel) this.Parent).UpdateAutoVisibility();
    }
  }

  internal bool IsMouseInsideTabPanel
  {
    get
    {
      return this.m_TabPanel != null && new Rect(0.0, 0.0, this.m_TabPanel.ActualWidth, this.m_TabPanel.ActualHeight).Contains(Mouse.GetPosition((IInputElement) this.m_TabPanel));
    }
  }

  public void SelectDifferentTab()
  {
    bool flag = false;
    if (this.SelectedDockWindow != null)
      flag = this.SelectedDockWindow.IsKeyboardFocusWithin;
    if (this.SelectedIndex > 0)
      this.SelectPreviousTab(true);
    else if (this.Items.Count > 1)
      this.SelectNextTab(true);
    else
      this.SelectedIndex = -1;
    if (!flag || this.SelectedDockWindow == null)
      return;
    this.SelectedDockWindow.FocusContent();
  }

  internal bool SelectPreviousTab(bool cycle)
  {
    int tabIndex;
    if (this.SelectedIndex <= 0)
    {
      if (!cycle)
        return false;
      tabIndex = this.GetTabIndex(this.Items.Count, -1);
    }
    else
    {
      tabIndex = this.GetTabIndex(this.SelectedIndex, -1);
      if (tabIndex < 0 & cycle)
        tabIndex = this.GetTabIndex(this.Items.Count, -1);
    }
    if (tabIndex < 0)
      return false;
    this.SelectedIndex = tabIndex;
    return true;
  }

  internal bool SelectNextTab(bool cycle)
  {
    int tabIndex;
    if (this.SelectedIndex >= this.Items.Count - 1)
    {
      if (!cycle)
        return false;
      tabIndex = this.GetTabIndex(-1, 1);
    }
    else
    {
      tabIndex = this.GetTabIndex(this.SelectedIndex, 1);
      if (tabIndex < 0 & cycle)
        tabIndex = this.GetTabIndex(-1, 1);
    }
    if (tabIndex < 0)
      return false;
    this.SelectedIndex = tabIndex;
    return true;
  }

  private int GetTabIndex(int start, int direction)
  {
    int index = start;
    int num1 = this.Items.Count - 1;
    int num2 = 1;
    if (direction < 0)
    {
      num1 = 0;
      num2 = -1;
      if (start <= 0)
        return -1;
    }
    else if (start >= num1)
      return -1;
    while (num1 != index)
    {
      index += num2;
      if (this.ItemContainerGenerator.ContainerFromIndex(index) is UIElement uiElement && uiElement.Visibility == Visibility.Visible)
        return index;
    }
    return -1;
  }

  private void UpdateZOrder()
  {
    int num = this.Items.Count - 1;
    bool flag = true;
    for (int index = 0; index <= num; ++index)
    {
      if (this.ItemContainerGenerator.ContainerFromIndex(index) is UIElement element)
      {
        if (index == this.SelectedIndex)
          Panel.SetZIndex(element, 10000);
        else
          Panel.SetZIndex(element, num - index);
        if (flag && element.Visibility == Visibility.Visible)
        {
          Panel.SetZIndex(element, 9999);
          flag = false;
        }
      }
    }
  }

  protected override bool IsItemItsOwnContainerOverride(object item) => item is DockWindow;

  protected override DependencyObject GetContainerForItemOverride()
  {
    return (DependencyObject) new DockWindow();
  }

  [Browsable(false)]
  public string Id => this.m_Id;

  internal eDockSide LastDockSide
  {
    get => this.m_LastDockSide;
    set => this.m_LastDockSide = value;
  }

  internal eDockSide LastDockReference
  {
    get => this.m_LastDockReference;
    set => this.m_LastDockReference = value;
  }

  internal string LastDockReferenceId
  {
    get => this.m_LastDockReferenceId;
    set => this.m_LastDockReferenceId = value;
  }

  internal bool LastDockIsFullSizeDock
  {
    get => this.m_LastDockIsFullSizeDock;
    set => this.m_LastDockIsFullSizeDock = value;
  }

  internal bool LastIsDocument
  {
    get => this._LastIsDocument;
    set => this._LastIsDocument = value;
  }

  internal void SelectFirstTab()
  {
    if (this.SelectedIndex != -1)
      return;
    this.SelectNextTab(false);
  }

  internal ContextMenu OptionsContextMenu => this.m_ContextMenuOptions;

  protected override IEnumerator LogicalChildren
  {
    get
    {
      if (this.ItemsSource == null)
        return base.LogicalChildren;
      List<object> objectList = new List<object>();
      foreach (object obj in (IEnumerable) this.Items)
      {
        if (obj is DockWindow)
          objectList.Add(obj);
      }
      return (IEnumerator) objectList.GetEnumerator();
    }
  }
}
