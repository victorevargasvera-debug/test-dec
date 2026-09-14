// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfDock.DockWindow
// Assembly: AcpWpfDock, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 89CC52D3-0487-4106-AFAE-BE4A13C8A50E
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfDock.dll

using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

#nullable disable
namespace DevComponents.WpfDock;

[TemplatePart(Name = "TabBorder", Type = typeof (Decorator))]
[DesignTimeVisible(false)]
public class DockWindow : HeaderedContentControl
{
  public static readonly DependencyProperty IsSelectedProperty;
  public static readonly DependencyProperty CanAutoHideProperty;
  public static readonly DependencyProperty CanCloseProperty;
  public static readonly DependencyProperty CanFloatProperty;
  public static readonly DependencyProperty CanTearOffProperty;
  public static readonly DependencyProperty CanDockLeftProperty;
  public static readonly DependencyProperty CanDockRightProperty;
  public static readonly DependencyProperty CanDockTopProperty;
  public static readonly DependencyProperty CanDockBottomProperty;
  public static readonly DependencyProperty CanDockAsDocumentProperty;
  public static readonly DependencyProperty IsAutoHideProperty;
  public static readonly DependencyProperty AutoHideOpenProperty;
  public static readonly DependencyProperty OptionsMenuProperty;
  public static readonly DependencyProperty CustomOptionsMenuProperty;
  public static readonly DependencyProperty ImageProperty;
  public static readonly DependencyProperty ImageSourceProperty;
  public static readonly DependencyProperty DescriptionProperty;
  public static readonly DependencyProperty FloatingRectProperty;
  public static readonly DependencyProperty AttentionRequiredProperty;
  public static RoutedCommand ToggleAutoHide = new RoutedCommand(nameof (ToggleAutoHide), typeof (DockWindow));
  public static RoutedCommand OpenAutoHide = new RoutedCommand(nameof (OpenAutoHide), typeof (DockWindow));
  public static RoutedCommand CloseAutoHide = new RoutedCommand(nameof (CloseAutoHide), typeof (DockWindow));
  public static RoutedCommand CloseWindow = new RoutedCommand("Close", typeof (DockWindow));
  public static RoutedCommand FloatWindow = new RoutedCommand("Float", typeof (DockWindow));
  public static RoutedCommand ReDockWindow = new RoutedCommand("ReDock", typeof (DockWindow));
  public static RoutedCommand DockAsDocumentWindow = new RoutedCommand("DockAsDocument", typeof (DockWindow));
  public static RoutedCommand SelectWindow = new RoutedCommand(nameof (SelectWindow), typeof (DockWindow));
  public static readonly RoutedEvent AutoHideChangedEvent;
  public static readonly RoutedEvent AutoHideOpenChangedEvent;
  public static readonly RoutedEvent ClosingEvent;
  public static readonly RoutedEvent ClosedEvent;
  public static readonly RoutedEvent ActivatedEvent;
  public static readonly RoutedEvent DeactivatedEvent;
  internal static Rect DefaultFloatingRect = new Rect(100.0, 100.0, 150.0, 250.0);
  public static readonly RoutedEvent TabVisibilityChangedEvent;
  public static readonly DependencyProperty TabToolTipProperty = DependencyProperty.Register(nameof (TabToolTip), typeof (object), typeof (DockWindow), (PropertyMetadata) new UIPropertyMetadata((PropertyChangedCallback) null));
  public static readonly DependencyProperty AutoCloseProperty = DependencyProperty.Register(nameof (AutoClose), typeof (bool), typeof (DockWindow), (PropertyMetadata) new UIPropertyMetadata((object) false));
  public static readonly DependencyProperty CloseButtonVisibilityProperty = DependencyProperty.Register(nameof (CloseButtonVisibility), typeof (Visibility), typeof (DockWindow), (PropertyMetadata) new FrameworkPropertyMetadata((object) Visibility.Collapsed));
  private string m_LastDockWindowGroupId = "";
  private Dock m_LastDock;
  private DockWindowGroup m_LastDockWindowGroup;
  private Size m_LastDockedSize;
  private Size m_LastAutoHideSize;
  private DispatcherTimer m_DelayOpenTimer;
  private System.Windows.Point m_MouseDownPoint;
  private bool m_DelayedAutoHide;
  private Decorator m_TabBorder;
  private DockWindowGroup _ParentGroup;
  internal bool IgnoreAutoHideChange;
  public static bool isCPSWindowHidden = false;
  private DockWindowGroup m_previousGroup;
  private Canvas m_autoHidePopup;

  public event EventHandler DockParentChanged;

  public object TabToolTip
  {
    get => this.GetValue(DockWindow.TabToolTipProperty);
    set => this.SetValue(DockWindow.TabToolTipProperty, value);
  }

  [DefaultValue(false)]
  public bool AutoClose
  {
    get => (bool) this.GetValue(DockWindow.AutoCloseProperty);
    set => this.SetValue(DockWindow.AutoCloseProperty, (object) value);
  }

  public Visibility CloseButtonVisibility
  {
    get => (Visibility) this.GetValue(DockWindow.CloseButtonVisibilityProperty);
    set => this.SetValue(DockWindow.CloseButtonVisibilityProperty, (object) value);
  }

  static DockWindow()
  {
    FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof (DockWindow), (PropertyMetadata) new FrameworkPropertyMetadata((object) typeof (DockWindow)));
    DockWindow.IsSelectedProperty = Selector.IsSelectedProperty.AddOwner(typeof (DockWindow), (PropertyMetadata) new FrameworkPropertyMetadata((object) false, FrameworkPropertyMetadataOptions.AffectsParentMeasure | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault | FrameworkPropertyMetadataOptions.Journal, new PropertyChangedCallback(DockWindow.OnIsSelectedChanged)));
    DockWindow.ImageProperty = DependencyProperty.Register(nameof (Image), typeof (object), typeof (DockWindow), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsMeasure));
    DockWindow.ImageSourceProperty = DependencyProperty.Register(nameof (ImageSource), typeof (string), typeof (DockWindow), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, new PropertyChangedCallback(DockWindow.ImageSourceChanged)));
    DockWindow.FloatingRectProperty = DependencyProperty.Register(nameof (FloatingRect), typeof (Rect), typeof (DockWindow), (PropertyMetadata) new FrameworkPropertyMetadata((object) DockWindow.DefaultFloatingRect));
    DockWindow.CanAutoHideProperty = DependencyProperty.Register(nameof (CanAutoHide), typeof (bool), typeof (DockWindow), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsRender));
    DockWindow.CanCloseProperty = DependencyProperty.Register(nameof (CanClose), typeof (bool), typeof (DockWindow), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsRender));
    DockWindow.CanDockAsDocumentProperty = DependencyProperty.Register(nameof (CanDockAsDocument), typeof (bool), typeof (DockWindow), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsRender));
    DockWindow.CanDockBottomProperty = DependencyProperty.Register(nameof (CanDockBottom), typeof (bool), typeof (DockWindow), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsRender));
    DockWindow.CanDockLeftProperty = DependencyProperty.Register(nameof (CanDockLeft), typeof (bool), typeof (DockWindow), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsRender));
    DockWindow.CanDockRightProperty = DependencyProperty.Register(nameof (CanDockRight), typeof (bool), typeof (DockWindow), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsRender));
    DockWindow.CanDockTopProperty = DependencyProperty.Register(nameof (CanDockTop), typeof (bool), typeof (DockWindow), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsRender));
    DockWindow.CanFloatProperty = DependencyProperty.Register(nameof (CanFloat), typeof (bool), typeof (DockWindow), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsRender));
    DockWindow.CanTearOffProperty = DependencyProperty.Register(nameof (CanTearOff), typeof (bool), typeof (DockWindow), (PropertyMetadata) new FrameworkPropertyMetadata((object) true));
    DockWindow.IsAutoHideProperty = DependencyProperty.Register(nameof (IsAutoHide), typeof (bool), typeof (DockWindow), (PropertyMetadata) new FrameworkPropertyMetadata((object) false, new PropertyChangedCallback(DockWindow.IsAutoHideChanged)));
    DockWindow.AutoHideOpenProperty = DependencyProperty.Register(nameof (AutoHideOpen), typeof (bool), typeof (DockWindow), (PropertyMetadata) new FrameworkPropertyMetadata((object) false, new PropertyChangedCallback(DockWindow.OnAutoHideOpenChanged)));
    DockWindow.OptionsMenuProperty = DependencyProperty.Register(nameof (OptionsMenu), typeof (bool), typeof (DockWindow), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, new PropertyChangedCallback(DockWindow.UpdateParentGroupState)));
    DockWindow.CustomOptionsMenuProperty = DependencyProperty.Register(nameof (CustomOptionsMenu), typeof (ContextMenu), typeof (DockWindow), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, new PropertyChangedCallback(DockWindow.UpdateParentGroupState)));
    DockWindow.DescriptionProperty = DependencyProperty.Register(nameof (Description), typeof (string), typeof (DockWindow), (PropertyMetadata) new FrameworkPropertyMetadata((object) ""));
    DockWindow.AttentionRequiredProperty = DependencyProperty.Register(nameof (AttentionRequired), typeof (bool), typeof (DockWindow), (PropertyMetadata) new FrameworkPropertyMetadata((object) false, FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsRender));
    DockWindow.AutoHideChangedEvent = EventManager.RegisterRoutedEvent("AutoHideChanged", RoutingStrategy.Bubble, typeof (RoutedEventHandler), typeof (DockWindow));
    DockWindow.AutoHideOpenChangedEvent = EventManager.RegisterRoutedEvent("AutoHideOpenChanged", RoutingStrategy.Bubble, typeof (RoutedEventHandler), typeof (DockWindow));
    DockWindow.ClosingEvent = EventManager.RegisterRoutedEvent("Closing", RoutingStrategy.Bubble, typeof (CancelSourceRoutedEventHandler), typeof (DockWindow));
    DockWindow.ClosedEvent = EventManager.RegisterRoutedEvent("Closed", RoutingStrategy.Bubble, typeof (RoutedEventHandler), typeof (DockWindow));
    DockWindow.ActivatedEvent = EventManager.RegisterRoutedEvent("Activated", RoutingStrategy.Bubble, typeof (RoutedEventHandler), typeof (DockWindow));
    DockWindow.DeactivatedEvent = EventManager.RegisterRoutedEvent("Deactivated", RoutingStrategy.Bubble, typeof (RoutedEventHandler), typeof (DockWindow));
    DockWindow.TabVisibilityChangedEvent = EventManager.RegisterRoutedEvent("TabVisibilityChanged", RoutingStrategy.Direct, typeof (RoutedEventHandler), typeof (DockWindow));
  }

  public DockWindow() => this.Loaded += new RoutedEventHandler(this.DockWindowLoaded);

  public override void OnApplyTemplate()
  {
    this.m_TabBorder = this.GetTemplateChild("TabBorder") as Decorator;
    base.OnApplyTemplate();
  }

  public event RoutedEventHandler AutoHideChanged
  {
    add => this.AddHandler(DockWindow.AutoHideChangedEvent, (Delegate) value);
    remove => this.RemoveHandler(DockWindow.AutoHideChangedEvent, (Delegate) value);
  }

  public event RoutedEventHandler AutoHideOpenChanged
  {
    add => this.AddHandler(DockWindow.AutoHideOpenChangedEvent, (Delegate) value);
    remove => this.RemoveHandler(DockWindow.AutoHideOpenChangedEvent, (Delegate) value);
  }

  public event RoutedEventHandler TabVisibilityChanged
  {
    add => this.AddHandler(DockWindow.TabVisibilityChangedEvent, (Delegate) value);
    remove => this.RemoveHandler(DockWindow.TabVisibilityChangedEvent, (Delegate) value);
  }

  internal void InvokeTabVisibilityChangedEvent()
  {
    this.OnTabVisibilityChanged(new RoutedEventArgs(DockWindow.TabVisibilityChangedEvent));
  }

  protected virtual void OnTabVisibilityChanged(RoutedEventArgs e) => this.RaiseEvent(e);

  public event CancelSourceRoutedEventHandler Closing
  {
    add => this.AddHandler(DockWindow.ClosingEvent, (Delegate) value);
    remove => this.RemoveHandler(DockWindow.ClosingEvent, (Delegate) value);
  }

  public event RoutedEventHandler Closed
  {
    add => this.AddHandler(DockWindow.ClosedEvent, (Delegate) value);
    remove => this.RemoveHandler(DockWindow.ClosedEvent, (Delegate) value);
  }

  public event RoutedEventHandler Activated
  {
    add => this.AddHandler(DockWindow.ActivatedEvent, (Delegate) value);
    remove => this.RemoveHandler(DockWindow.ActivatedEvent, (Delegate) value);
  }

  public event RoutedEventHandler Deactivated
  {
    add => this.AddHandler(DockWindow.DeactivatedEvent, (Delegate) value);
    remove => this.RemoveHandler(DockWindow.DeactivatedEvent, (Delegate) value);
  }

  protected override void OnMouseEnter(MouseEventArgs e)
  {
    if (this.IsAutoHide && !this.AutoHideOpen)
      this.SetupOpenTimer();
    base.OnMouseEnter(e);
  }

  private void SetupOpenTimer()
  {
    if (this.m_DelayOpenTimer == null)
    {
      this.m_DelayOpenTimer = new DispatcherTimer(DispatcherPriority.Normal);
      this.m_DelayOpenTimer.Tick += new EventHandler(this.OnDelayPopupOpen);
    }
    else
      this.m_DelayOpenTimer.Stop();
    this.StartTimer(this.m_DelayOpenTimer);
  }

  private void OnDelayPopupOpen(object sender, EventArgs e)
  {
    this.StopTimer(ref this.m_DelayOpenTimer);
    this.AutoHideOpen = true;
  }

  private void StopTimer(ref DispatcherTimer timer)
  {
    if (timer == null)
      return;
    timer.Stop();
    timer = (DispatcherTimer) null;
  }

  private void StartTimer(DispatcherTimer timer)
  {
    timer.Interval = TimeSpan.FromMilliseconds((double) SystemParameters.MenuShowDelay * 2.5);
    timer.Start();
  }

  protected override void OnMouseMove(MouseEventArgs e)
  {
    if (this.IsMouseCaptured && this.m_TabBorder != null && !new Rect(this.m_TabBorder.RenderSize).Contains(e.GetPosition((IInputElement) this.m_TabBorder)))
      this.ProcessMouseDocking(e);
    base.OnMouseMove(e);
  }

  private void ProcessMouseDocking(MouseEventArgs e)
  {
    if (e.LeftButton != MouseButtonState.Pressed || LayoutHelpers.IsEmpty(this.m_MouseDownPoint) || this.m_TabBorder == null || !new Rect(this.m_TabBorder.RenderSize).Contains(this.m_MouseDownPoint))
      return;
    DockSite dockSite = this.GetDockSite();
    if (dockSite.IsDockingInProgress)
      return;
    DockWindowGroup parentGroup = this.ParentGroup;
    System.Windows.Point position = e.GetPosition((IInputElement) this);
    Rect layoutSlot = LayoutInformation.GetLayoutSlot((FrameworkElement) this);
    double num1 = DockSite.GetIsDocument((UIElement) this) ? this.ActualHeight : 0.0;
    if (parentGroup != null && parentGroup.IsMouseInsideTabPanel && parentGroup.VisibleItemsCount > 1 && position.Y > layoutSlot.Y && position.Y < layoutSlot.Bottom && (parentGroup.Items.IndexOf((object) this) > 0 && position.X < num1 || parentGroup.Items.IndexOf((object) this) < parentGroup.Items.Count - 1 && position.X > num1))
    {
      int num2 = parentGroup.Items.IndexOf((object) this);
      parentGroup.Items.Remove((object) this);
      int insertIndex = position.X >= num1 ? num2 + 1 : num2 - 1;
      parentGroup.Items.Insert(insertIndex, (object) this);
      parentGroup.SelectedItem = (object) this;
    }
    else
    {
      if (this.IsMouseCaptured)
        this.ReleaseMouseCapture();
      this.m_MouseDownPoint = new System.Windows.Point();
      bool flag = true;
      if (DockSite.GetIsDocument((UIElement) this) && parentGroup != null && parentGroup.VisibleItemsCount == 1)
        flag = false;
      if (dockSite.DockHintOverlay)
        this.Dispatcher.BeginInvoke(DispatcherPriority.Render, (Delegate) new DispatcherOperationCallback(this.StartDockAfterRender), (object) new DockWindow.DockInfoStart(parentGroup, flag, eEventActionSource.Mouse));
      else
        dockSite.StartDockWindowDrag(parentGroup, flag, eEventActionSource.Mouse);
    }
  }

  protected override void OnMouseLeave(MouseEventArgs e)
  {
    if (this.IsAutoHide)
      this.StopTimer(ref this.m_DelayOpenTimer);
    base.OnMouseLeave(e);
  }

  private object StartDockAfterRender(object arg)
  {
    DockSite dockSite = this.GetDockSite();
    DockWindow.DockInfoStart dockInfoStart = arg as DockWindow.DockInfoStart;
    DockWindowGroup group = dockInfoStart.Group;
    int num = dockInfoStart.DragSelectedTab ? 1 : 0;
    int source = (int) dockInfoStart.Source;
    dockSite.StartDockWindowDrag(group, num != 0, (eEventActionSource) source);
    return (object) null;
  }

  protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
  {
    this.m_MouseDownPoint = new System.Windows.Point();
    if (this.IsMouseCaptured)
      this.ReleaseMouseCapture();
    base.OnMouseLeftButtonUp(e);
  }

  protected override void OnMouseRightButtonDown(MouseButtonEventArgs e)
  {
    if (!this.IsAutoHide && e.Source == this && !this.IsSelected)
      this.IsSelected = true;
    base.OnMouseRightButtonDown(e);
  }

  protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
  {
    base.OnMouseLeftButtonDown(e);
    if (!WinApi.KeyValidated)
      return;
    Rect rect;
    if (!this.IsAutoHide && !this.IsSelected)
    {
      this.IsSelected = true;
      e.Handled = true;
    }
    else if (this.IsAutoHide && !e.Handled)
    {
      rect = new Rect(this.RenderSize);
      if (rect.Contains(e.GetPosition((IInputElement) this)))
      {
        this.AutoHideOpen = !this.AutoHideOpen;
        e.Handled = true;
        this.StopTimer(ref this.m_DelayOpenTimer);
      }
    }
    if (this.Content is UIElement && !this.IsKeyboardFocusWithin)
      this.FocusContent();
    if (!this.IsAutoHide && this.IsSelected)
    {
      if (e.ClickCount == 2)
      {
        rect = new Rect(this.RenderSize);
        if (rect.Contains(e.GetPosition((IInputElement) this)))
        {
          DockSite dockSite = this.GetDockSite();
          if (dockSite != null && !dockSite.IsDockingInProgress && this.CanFloat)
            dockSite.FloatWindow(this, eEventActionSource.Mouse, true);
        }
        this.m_MouseDownPoint = new System.Windows.Point();
      }
      else if (this.GetCanTearOff())
      {
        this.m_MouseDownPoint = e.GetPosition((IInputElement) this);
        if (this.m_TabBorder == null)
          return;
        rect = new Rect(this.m_TabBorder.RenderSize);
        if (!rect.Contains(e.GetPosition((IInputElement) this.m_TabBorder)))
          return;
        this.CaptureMouse();
      }
      else
        this.m_MouseDownPoint = new System.Windows.Point();
    }
    else
      this.m_MouseDownPoint = new System.Windows.Point();
  }

  public bool FocusContent()
  {
    if (!this.IsKeyboardFocusWithin && this.Content is UIElement)
    {
      this.UpdateLayout();
      ((UIElement) this.Content).MoveFocus(new TraversalRequest(FocusNavigationDirection.First));
    }
    return this.IsKeyboardFocusWithin;
  }

  private bool GetCanTearOff()
  {
    if (!this.CanTearOff)
      return false;
    if (DockSite.GetIsDocument((UIElement) this))
      return true;
    return this.ParentGroup != null && this.ParentGroup.VisibleItemsCount > 1;
  }

  [Category("Appearance")]
  [Bindable(true)]
  public bool IsSelected
  {
    get => (bool) this.GetValue(DockWindow.IsSelectedProperty);
    set => this.SetValue(DockWindow.IsSelectedProperty, (object) value);
  }

  internal void SetParentGroup(DockWindowGroup group) => this._ParentGroup = group;

  [Browsable(false)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  [Bindable(false)]
  public DockWindowGroup ParentGroup
  {
    get => this.Parent == null ? this._ParentGroup : this.Parent as DockWindowGroup;
    set
    {
      if (this.ParentGroup == value)
        return;
      DockWindowGroup parentGroup = this.ParentGroup;
      if (parentGroup != null)
      {
        if (parentGroup.SelectedItem == this)
          parentGroup.SelectDifferentTab();
        parentGroup.Items.Remove((object) this);
      }
      value?.Items.Add((object) this);
    }
  }

  [Category("Appearance")]
  [Bindable(true)]
  [DefaultValue(true)]
  public bool CanAutoHide
  {
    get => (bool) this.GetValue(DockWindow.CanAutoHideProperty);
    set => this.SetValue(DockWindow.CanAutoHideProperty, (object) value);
  }

  [Category("Appearance")]
  [Bindable(true)]
  [DefaultValue(true)]
  public bool CanClose
  {
    get => (bool) this.GetValue(DockWindow.CanCloseProperty);
    set => this.SetValue(DockWindow.CanCloseProperty, (object) value);
  }

  [Category("Appearance")]
  [Bindable(true)]
  [DefaultValue(true)]
  public bool CanDockAsDocument
  {
    get => (bool) this.GetValue(DockWindow.CanDockAsDocumentProperty);
    set => this.SetValue(DockWindow.CanDockAsDocumentProperty, (object) value);
  }

  [Category("Appearance")]
  [Bindable(true)]
  [DefaultValue(true)]
  public bool CanDockBottom
  {
    get => (bool) this.GetValue(DockWindow.CanDockBottomProperty);
    set => this.SetValue(DockWindow.CanDockBottomProperty, (object) value);
  }

  [Category("Appearance")]
  [Bindable(true)]
  [DefaultValue(true)]
  public bool CanDockLeft
  {
    get => (bool) this.GetValue(DockWindow.CanDockLeftProperty);
    set => this.SetValue(DockWindow.CanDockLeftProperty, (object) value);
  }

  [Category("Appearance")]
  [Bindable(true)]
  [DefaultValue(true)]
  public bool CanDockRight
  {
    get => (bool) this.GetValue(DockWindow.CanDockRightProperty);
    set => this.SetValue(DockWindow.CanDockRightProperty, (object) value);
  }

  [Category("Appearance")]
  [Bindable(true)]
  [DefaultValue(true)]
  public bool CanDockTop
  {
    get => (bool) this.GetValue(DockWindow.CanDockTopProperty);
    set => this.SetValue(DockWindow.CanDockTopProperty, (object) value);
  }

  [Category("Appearance")]
  [Bindable(true)]
  [DefaultValue(true)]
  public bool CanFloat
  {
    get => (bool) this.GetValue(DockWindow.CanFloatProperty);
    set => this.SetValue(DockWindow.CanFloatProperty, (object) value);
  }

  [Category("Appearance")]
  [Bindable(true)]
  [DefaultValue(true)]
  public bool CanTearOff
  {
    get => (bool) this.GetValue(DockWindow.CanTearOffProperty);
    set => this.SetValue(DockWindow.CanTearOffProperty, (object) value);
  }

  [Category("Appearance")]
  [Bindable(true)]
  [DefaultValue(false)]
  public bool IsAutoHide
  {
    get => (bool) this.GetValue(DockWindow.IsAutoHideProperty);
    set => this.SetValue(DockWindow.IsAutoHideProperty, (object) value);
  }

  [Category("Appearance")]
  [Bindable(true)]
  [DefaultValue(false)]
  public bool AttentionRequired
  {
    get => (bool) this.GetValue(DockWindow.AttentionRequiredProperty);
    set => this.SetValue(DockWindow.AttentionRequiredProperty, (object) value);
  }

  private static void IsAutoHideChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
  {
    ((DockWindow) d).IsAutoHideChanged();
  }

  private void IsAutoHideChanged()
  {
    if (this.IgnoreAutoHideChange)
      return;
    DockSite dockSite = this.GetDockSite();
    if (this.IsLoaded && dockSite != null)
    {
      bool enableAnimation = !this.m_DelayedAutoHide;
      this.m_DelayedAutoHide = false;
      dockSite.SetAutoHide(this, this.IsAutoHide, eEventActionSource.Code, enableAnimation);
      this.StopTimer(ref this.m_DelayOpenTimer);
      this.OnAutoHideChanged(new RoutedEventArgs(DockWindow.AutoHideChangedEvent, (object) this));
    }
    else if (this.m_DelayedAutoHide)
    {
      if (dockSite != null || this.IsAutoHide)
        return;
      this.m_DelayedAutoHide = false;
    }
    else
      this.m_DelayedAutoHide = true;
  }

  private void DockWindowLoaded(object sender, RoutedEventArgs e)
  {
    if (!this.m_DelayedAutoHide)
      return;
    this.IsAutoHideChanged();
  }

  protected virtual void OnAutoHideChanged(RoutedEventArgs e) => this.RaiseEvent(e);

  protected virtual void OnActivated(RoutedEventArgs e) => this.RaiseEvent(e);

  protected virtual void OnDeactivated(RoutedEventArgs e) => this.RaiseEvent(e);

  [Browsable(false)]
  [Category("Appearance")]
  [Bindable(true)]
  [DefaultValue(false)]
  public bool AutoHideOpen
  {
    get => (bool) this.GetValue(DockWindow.AutoHideOpenProperty);
    set => this.SetValue(DockWindow.AutoHideOpenProperty, (object) value);
  }

  private static void OnAutoHideOpenChanged(
    DependencyObject d,
    DependencyPropertyChangedEventArgs e)
  {
    ((DockWindow) d).OnAutoHideOpenChanged();
  }

  private void OnAutoHideOpenChanged()
  {
    if (this.AutoHideOpen && !this.IsAutoHide || DockWindow.isCPSWindowHidden)
      return;
    DockSite dockSite = this.GetDockSite();
    if (dockSite == null)
      return;
    if (this.AutoHideOpen)
    {
      this.m_autoHidePopup = (Canvas) dockSite.OpenAutoHidePopup(this);
    }
    else
    {
      dockSite.CloseAutoHidePopup(this, dockSite.AnimationEnabled);
      this.m_autoHidePopup = (Canvas) null;
    }
    this.OnAutoHideOpenChanged(new RoutedEventArgs(DockWindow.AutoHideOpenChangedEvent, (object) this));
  }

  protected virtual void OnAutoHideOpenChanged(RoutedEventArgs e) => this.RaiseEvent(e);

  [Browsable(false)]
  [Category("Appearance")]
  [Bindable(true)]
  [DefaultValue(true)]
  public bool OptionsMenu
  {
    get => (bool) this.GetValue(DockWindow.OptionsMenuProperty);
    set => this.SetValue(DockWindow.OptionsMenuProperty, (object) value);
  }

  [Browsable(false)]
  [Category("Appearance")]
  [Bindable(true)]
  [DefaultValue(true)]
  public ContextMenu CustomOptionsMenu
  {
    get => (ContextMenu) this.GetValue(DockWindow.CustomOptionsMenuProperty);
    set => this.SetValue(DockWindow.CustomOptionsMenuProperty, (object) value);
  }

  private static void UpdateParentGroupState(
    DependencyObject d,
    DependencyPropertyChangedEventArgs e)
  {
    ((DockWindow) d).UpdateParentGroupState();
  }

  private void UpdateParentGroupState()
  {
    if (this.ParentGroup == null)
      return;
    this.ParentGroup.UpdateStateProperties();
  }

  public DockSite GetDockSite() => DockSite.GetDockSite((DependencyObject) this);

  private static void OnIsSelectedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
  {
    DockWindow source = d as DockWindow;
    if ((bool) e.NewValue)
      source.OnSelected(new RoutedEventArgs(Selector.SelectedEvent, (object) source));
    else
      source.OnUnselected(new RoutedEventArgs(Selector.UnselectedEvent, (object) source));
  }

  protected virtual void OnSelected(RoutedEventArgs e)
  {
    this.RaiseSelectedEvents(true, e);
    if (!DockSite.GetIsDocument((UIElement) this) || !(this.VisualParent is IScrollInfo visualParent))
      return;
    visualParent.MakeVisible((Visual) this, new Rect(this.RenderSize));
  }

  protected virtual void OnUnselected(RoutedEventArgs e) => this.RaiseSelectedEvents(false, e);

  protected override void OnGotKeyboardFocus(KeyboardFocusChangedEventArgs e)
  {
    base.OnGotKeyboardFocus(e);
    if (e.Handled || e.NewFocus != this || this.IsSelected)
      return;
    this.IsSelected = true;
  }

  protected override void OnIsKeyboardFocusWithinChanged(DependencyPropertyChangedEventArgs e)
  {
    if (this.IsKeyboardFocusWithin)
      this.OnActivated(new RoutedEventArgs(DockWindow.ActivatedEvent, (object) this));
    else
      this.OnDeactivated(new RoutedEventArgs(DockWindow.DeactivatedEvent, (object) this));
    base.OnIsKeyboardFocusWithinChanged(e);
  }

  private void RaiseSelectedEvents(bool newValue, RoutedEventArgs e) => this.RaiseEvent(e);

  protected override void OnHeaderChanged(object oldHeader, object newHeader)
  {
    if (this.IsInitialized && this.ParentGroup != null)
      this.ParentGroup.UpdateSelectedHeader();
    base.OnHeaderChanged(oldHeader, newHeader);
  }

  protected override void OnContentChanged(object oldContent, object newContent)
  {
    if (this.IsInitialized && this.ParentGroup != null)
      this.ParentGroup.UpdateSelectedContent();
    base.OnContentChanged(oldContent, newContent);
  }

  [Bindable(true)]
  [Category("Content")]
  [DefaultValue(null)]
  public object Image
  {
    get => this.GetValue(DockWindow.ImageProperty);
    set => this.SetValue(DockWindow.ImageProperty, value);
  }

  [Bindable(true)]
  [Category("Content")]
  [DefaultValue(null)]
  public string ImageSource
  {
    get => (string) this.GetValue(DockWindow.ImageSourceProperty);
    set => this.SetValue(DockWindow.ImageSourceProperty, (object) value);
  }

  private static void ImageSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
  {
    ((DockWindow) d).ImageSourceChanged();
  }

  private void ImageSourceChanged()
  {
    string imageSource = this.ImageSource;
    if (imageSource == null || imageSource.Length == 0)
    {
      this.Image = (object) null;
    }
    else
    {
      System.Windows.Controls.Image image;
      try
      {
        BitmapImage bitmapImage = new BitmapImage(new Uri(imageSource, UriKind.RelativeOrAbsolute));
        image = new System.Windows.Controls.Image();
        image.Source = (System.Windows.Media.ImageSource) bitmapImage;
        image.Stretch = Stretch.None;
      }
      catch
      {
        this.Image = (object) null;
        return;
      }
      this.Image = (object) image;
    }
  }

  [Bindable(true)]
  [Category("Content")]
  [DefaultValue("")]
  public string Description
  {
    get => (string) this.GetValue(DockWindow.DescriptionProperty);
    set => this.SetValue(DockWindow.DescriptionProperty, (object) value);
  }

  [Category("Behavior")]
  public Rect FloatingRect
  {
    get => (Rect) this.GetValue(DockWindow.FloatingRectProperty);
    set => this.SetValue(DockWindow.FloatingRectProperty, (object) value);
  }

  [Browsable(false)]
  [Bindable(false)]
  public bool IsFloating => this.ParentGroup != null && this.ParentGroup.IsFloating;

  public bool Close() => this.Close(eEventActionSource.Code);

  public bool Close(eEventActionSource actionSource)
  {
    if (this.Visibility == Visibility.Collapsed)
      return false;
    CancelSourceRoutedEventArgs e = new CancelSourceRoutedEventArgs(DockWindow.ClosingEvent, (object) this);
    e.EventActionSource = actionSource;
    this.OnClosing(e);
    if (e.Cancel)
      return false;
    if (this.AutoHideOpen)
      this.AutoHideOpen = false;
    if (this.IsAutoHide)
      this.IsAutoHide = false;
    DockWindowGroup parentGroup1 = this.ParentGroup;
    bool flag = false;
    if (this.IsFloating && parentGroup1 != null)
    {
      Window window = Window.GetWindow((DependencyObject) this);
      if (window != null)
        this.FloatingRect = new Rect(window.Left, window.Top, window.Width, window.Height);
      this.GetDockSite()?.RestoreLastDockPosition(parentGroup1);
      flag = true;
    }
    this.Visibility = Visibility.Collapsed;
    if (flag && parentGroup1 != null && parentGroup1.VisibleItemsCount > 0)
    {
      object[] objArray = new object[parentGroup1.Items.Count];
      parentGroup1.Items.CopyTo((Array) objArray, 0);
      foreach (object obj in objArray)
      {
        if (obj != this && obj is DockWindow)
          ((DockWindow) obj).Close(actionSource);
      }
    }
    if (parentGroup1 != null)
    {
      parentGroup1.UpdateTabVisibility();
      if (parentGroup1.VisibleItemsCount == 0)
        parentGroup1.UpdateVisibility();
      else
        parentGroup1.SelectDifferentTab();
    }
    this.OnClosed(new RoutedEventArgs(DockWindow.ClosedEvent, (object) this));
    DockWindowGroup parentGroup2 = this.ParentGroup;
    if (this.AutoClose && parentGroup2 != null)
    {
      parentGroup2.Items.Remove((object) this);
      if (parentGroup2.Items.Count == 0)
        parentGroup2.GetDockSite()?.Detach(parentGroup2);
      this.Loaded -= new RoutedEventHandler(this.DockWindowLoaded);
    }
    return true;
  }

  protected virtual void OnClosed(RoutedEventArgs e) => this.RaiseEvent(e);

  protected virtual void OnClosing(CancelSourceRoutedEventArgs e)
  {
    this.RaiseEvent((RoutedEventArgs) e);
  }

  public void Open()
  {
    if (this.Visibility == Visibility.Visible)
      return;
    this.Visibility = Visibility.Visible;
    DockWindowGroup parentGroup = this.ParentGroup;
    if (parentGroup == null)
      return;
    parentGroup.UpdateVisibility();
    if (parentGroup.Visibility != Visibility.Visible)
      parentGroup.Visibility = Visibility.Visible;
    parentGroup.UpdateTabVisibility();
  }

  internal string LastDockWindowGroupId
  {
    get => this.m_LastDockWindowGroupId;
    set => this.m_LastDockWindowGroupId = value;
  }

  internal Dock LastDock
  {
    get => this.m_LastDock;
    set => this.m_LastDock = value;
  }

  internal DockWindowGroup LastDockWindowGroup
  {
    get => this.m_LastDockWindowGroup;
    set => this.m_LastDockWindowGroup = value;
  }

  internal Size LastDockedSize
  {
    get => this.m_LastDockedSize;
    set => this.m_LastDockedSize = value;
  }

  internal Size LastAutoHideSize
  {
    get => this.m_LastAutoHideSize;
    set => this.m_LastAutoHideSize = value;
  }

  internal void InvokeDockParentChanged() => this.OnDockParentChanged(new EventArgs());

  protected virtual void OnDockParentChanged(EventArgs e)
  {
    EventHandler dockParentChanged = this.DockParentChanged;
    if (dockParentChanged == null)
      return;
    dockParentChanged((object) this, e);
  }

  public DockWindowGroup PreviousGroup
  {
    get => this.m_previousGroup;
    set => this.m_previousGroup = value;
  }

  public Canvas AutoHidePopupWnd
  {
    get => this.m_autoHidePopup;
    set => this.m_autoHidePopup = value;
  }

  public bool IsMouseWithinAutoHidePopup()
  {
    if (this.m_autoHidePopup == null)
      return false;
    return this.m_autoHidePopup.IsMouseOver || LayoutHelpers.IsMouseWithin((UIElement) this.m_autoHidePopup);
  }

  private class DockInfoStart
  {
    public DockWindowGroup Group;
    public bool DragSelectedTab;
    public eEventActionSource Source;

    public DockInfoStart(DockWindowGroup group, bool dragSelectedTab, eEventActionSource source)
    {
      this.Group = group;
      this.DragSelectedTab = dragSelectedTab;
      this.Source = source;
    }
  }
}
