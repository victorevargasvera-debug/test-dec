// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.Ribbon
// Assembly: AcpWpfRibbon, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 45A745B5-88C3-40EE-B1E5-8DBA2EACD529
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfRibbon.dll

using DevComponents.WpfRibbon.themes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Reflection;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

#nullable disable
namespace DevComponents.WpfRibbon;

[ToolboxItem(true)]
[TemplatePart(Name = "PART_RibbonPanelBorder", Type = typeof (Decorator))]
public class Ribbon : Selector, IPopupParentControl
{
  public static readonly DependencyProperty VisualStyleProperty = DependencyProperty.RegisterAttached(nameof (VisualStyle), typeof (eRibbonVisualStyle), typeof (Ribbon), (PropertyMetadata) new FrameworkPropertyMetadata((object) eRibbonVisualStyle.Office2007Blue, FrameworkPropertyMetadataOptions.Inherits, new PropertyChangedCallback(Ribbon.OnVisualStyleChanged)));
  private static readonly DependencyPropertyKey EffectiveStylePropertyKey = DependencyProperty.RegisterReadOnly(nameof (EffectiveStyle), typeof (eEffectiveStyle), typeof (Ribbon), (PropertyMetadata) new UIPropertyMetadata((object) eEffectiveStyle.Office2007, new PropertyChangedCallback(Ribbon.OnEffectiveStyleChanged)));
  public static readonly DependencyProperty EffectiveStyleProperty = Ribbon.EffectiveStylePropertyKey.DependencyProperty;
  public static readonly DependencyProperty AutoExpandProperty;
  public static readonly DependencyProperty CanDialogCustomizeQatProperty;
  public static readonly DependencyProperty CanChangeQatPlacementProperty;
  public static readonly DependencyProperty IsRibbonMenuOpenProperty;
  public static readonly DependencyProperty IsMinimizedProperty;
  public static readonly DependencyProperty ApplicationMenuProperty;
  public static readonly DependencyProperty QuickAccessToolbarProperty;
  public static readonly DependencyProperty IsQuickAccessToolbarBelowProperty;
  public static readonly DependencyProperty WindowBorderThicknessProperty;
  public static readonly DependencyProperty HorizontalWindowBorderThicknessProperty;
  private static readonly DependencyPropertyKey HorizontalWindowBorderThicknessPropertyKey;
  public static readonly DependencyProperty SelectedContentProperty;
  private static readonly DependencyPropertyKey SelectedContentPropertyKey;
  public static readonly DependencyProperty SelectedContentTemplateProperty;
  private static readonly DependencyPropertyKey SelectedContentTemplatePropertyKey;
  public static readonly DependencyProperty SelectedContentTemplateSelectorProperty;
  private static readonly DependencyPropertyKey SelectedContentTemplateSelectorPropertyKey;
  public static readonly DependencyProperty ContentTemplateSelectorProperty;
  public static readonly DependencyProperty ContentTemplateProperty;
  private static readonly DependencyPropertyKey ContextGroupsPropertyKey;
  public static readonly DependencyProperty ContextGroupsProperty;
  public static readonly DependencyProperty IsUsingGlassProperty;
  private static readonly DependencyPropertyKey IsUsingGlassPropertyKey;
  public static readonly DependencyProperty KeyTipProperty;
  public static readonly DependencyProperty IsCustomizableProperty;
  public static readonly DependencyProperty ElementRoleProperty;
  public static readonly DependencyProperty IsCustomizableContextSetProperty;
  public static readonly DependencyProperty UseSpecKeyTipPositioningProperty;
  public static readonly DependencyProperty AutoHideRibbonContentProperty;
  public static readonly DependencyProperty AutoHideTriggerSizeProperty;
  public static readonly DependencyProperty SystemButtonsProperty;
  public static RoutedCommand ToggleRibbonMinimize = new RoutedCommand(nameof (ToggleRibbonMinimize), typeof (Ribbon));
  public static readonly DependencyProperty LicenseKeyProperty;
  public static readonly RoutedEvent BeforeRemoveFromQatEvent;
  public static readonly RoutedEvent AfterRemoveFromQatEvent;
  public static readonly RoutedEvent BeforeAddToQatEvent;
  public static readonly RoutedEvent AfterAddToQatEvent;
  public static readonly RoutedEvent BeforeCustomizeQatDialogEvent;
  public static readonly RoutedEvent AfterCustomizeQatDialogEvent;
  public static readonly DependencyProperty IsActiveProperty;
  public static readonly DependencyProperty LivePreviewEnabledProperty;
  public static readonly RoutedEvent LivePreviewEvent;
  public static readonly RoutedEvent UndoLivePreviewEvent;
  public static readonly RoutedEvent EnterLivePreviewEvent;
  public static readonly RoutedEvent ExitLivePreviewEvent;
  private const string PartTabContentPresenter = "PART_TabContentHost";
  private const string PartRibbonPanelBorderName = "PART_RibbonPanelBorder";
  private const string PartQatPresenter = "PART_QAT";
  private const string PartAppMenuPresenter = "PART_ApplicationMenu";
  private const string PartQatBelowContainer = "PART_RibbonQatBelowBorder";
  private const string PartRibbonContentPanel = "PART_RCP";
  private const string PartPopup = "PART_Popup";
  private const string PartRibbonContentBorder = "PART_RibbonPanelBorder";
  private const string PartRibbonPopupBorder = "PART_RibbonPopupBorder";
  private const string QatRibbonBarNamePart = "SysQatButton_";
  private RibbonBorder m_PanelBorder;
  internal ParentPopupControlImpl m_PopupHandler;
  private ContentPresenter m_QatPresenter;
  private ContentPresenter m_AppMenuPresenter;
  private Decorator m_QatBelowContainer;
  private RibbonContentPanel m_RibbonContentPanel;
  private Popup m_Popup;
  private RibbonBorder m_ContentBorder;
  private RibbonBorder m_PopupBorder;
  private RibbonLocalization m_SystemText = new RibbonLocalization();
  private bool m_ShowKeyTips;
  private KeyTipsAdorner m_KeyTipsAdorner;
  private CommandBinding _RibbonMinimizeCommandBinding;
  private KeyBinding _RibbonMinimizeKeyBinding;
  private Delegate m_EnterMenuModeDelegate;
  private static bool _IsLivePreviewActive = false;
  private static bool _PopupAllowsTransparency = true;
  private static FieldInfo s_ShowKeyboardCues = (FieldInfo) null;
  public static readonly string SystemAddToQatMenuItem = nameof (SystemAddToQatMenuItem);
  public static readonly string SystemRemoveFromQatMenuItem = nameof (SystemRemoveFromQatMenuItem);
  public static readonly string SystemCustomizeQatMenuItem = nameof (SystemCustomizeQatMenuItem);
  public static readonly string SystemQatChangePlacementMenuItem = "SystemQatChangePlacementName";
  public static readonly string SystemQatMinMaxRibbonMenuItem = nameof (SystemQatMinMaxRibbonMenuItem);
  public static readonly string SysQatCustomizeContextMenu = "SystemQatCustomizeContextMenu";

  public static eRibbonVisualStyle GetVisualStyle(DependencyObject target)
  {
    return (eRibbonVisualStyle) target.GetValue(Ribbon.VisualStyleProperty);
  }

  public static void SetVisualStyle(DependencyObject target, eRibbonVisualStyle value)
  {
    target.SetValue(Ribbon.VisualStyleProperty, (object) value);
  }

  private static void OnVisualStyleChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
  {
    Ribbon.OnVisualStyleChanged(o, (eRibbonVisualStyle) e.OldValue, (eRibbonVisualStyle) e.NewValue);
  }

  private static void OnVisualStyleChanged(
    DependencyObject o,
    eRibbonVisualStyle oldValue,
    eRibbonVisualStyle newValue)
  {
    if (!(o is Ribbon))
      return;
    Ribbon ribbon = (Ribbon) o;
    ribbon.ChangeColorScheme(newValue);
    if (newValue == eRibbonVisualStyle.Office2010Silver || newValue == eRibbonVisualStyle.Office2010Blue || newValue == eRibbonVisualStyle.Office2010Black)
      ribbon.EffectiveStyle = eEffectiveStyle.Office2010;
    else
      ribbon.EffectiveStyle = eEffectiveStyle.Office2007;
  }

  public eRibbonVisualStyle VisualStyle
  {
    get => Ribbon.GetVisualStyle((DependencyObject) this);
    set => Ribbon.SetVisualStyle((DependencyObject) this, value);
  }

  public eEffectiveStyle EffectiveStyle
  {
    get => (eEffectiveStyle) this.GetValue(Ribbon.EffectiveStyleProperty);
    internal set => this.SetValue(Ribbon.EffectiveStylePropertyKey, (object) value);
  }

  private static void OnEffectiveStyleChanged(
    DependencyObject o,
    DependencyPropertyChangedEventArgs e)
  {
    if (!(o is Ribbon ribbon))
      return;
    ribbon.OnEffectiveStyleChanged((eEffectiveStyle) e.OldValue, (eEffectiveStyle) e.NewValue);
  }

  protected virtual void OnEffectiveStyleChanged(eEffectiveStyle oldValue, eEffectiveStyle newValue)
  {
    this.UpdateRibbonWindowGlass();
  }

  private void UpdateRibbonWindowGlass()
  {
    if (!(Window.GetWindow((DependencyObject) this) is RibbonWindow window))
      return;
    window.UpdateGlass();
  }

  static Ribbon()
  {
    FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof (Ribbon), (PropertyMetadata) new FrameworkPropertyMetadata((object) typeof (Ribbon)));
    Ribbon.WindowBorderThicknessProperty = DependencyProperty.Register(nameof (WindowBorderThickness), typeof (Thickness), typeof (Ribbon), (PropertyMetadata) new FrameworkPropertyMetadata((object) new Thickness(3.0, 0.0, 3.0, 0.0), FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange, new PropertyChangedCallback(Ribbon.WindowBorderThicknessChanged)));
    Ribbon.HorizontalWindowBorderThicknessPropertyKey = DependencyProperty.RegisterReadOnly(nameof (HorizontalWindowBorderThickness), typeof (Thickness), typeof (Ribbon), (PropertyMetadata) new FrameworkPropertyMetadata((object) new Thickness()));
    Ribbon.HorizontalWindowBorderThicknessProperty = Ribbon.HorizontalWindowBorderThicknessPropertyKey.DependencyProperty;
    Ribbon.ApplicationMenuProperty = DependencyProperty.Register(nameof (ApplicationMenu), typeof (UIElement), typeof (Ribbon), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(Ribbon.OnApplicationMenuChanged)));
    Ribbon.QuickAccessToolbarProperty = DependencyProperty.Register(nameof (QuickAccessToolbar), typeof (UIElement), typeof (Ribbon), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(Ribbon.OnQuickAccessToolbarChanged)));
    Ribbon.IsQuickAccessToolbarBelowProperty = DependencyProperty.Register(nameof (IsQuickAccessToolbarBelow), typeof (bool), typeof (Ribbon), (PropertyMetadata) new FrameworkPropertyMetadata((object) false, FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(Ribbon.OnIsQuickAccessToolbarBelowChanged)));
    Ribbon.SelectedContentPropertyKey = DependencyProperty.RegisterReadOnly(nameof (SelectedContent), typeof (object), typeof (Ribbon), (PropertyMetadata) new FrameworkPropertyMetadata((PropertyChangedCallback) null));
    Ribbon.SelectedContentProperty = Ribbon.SelectedContentPropertyKey.DependencyProperty;
    Ribbon.IsRibbonMenuOpenProperty = DependencyProperty.Register(nameof (IsRibbonMenuOpen), typeof (bool), typeof (Ribbon), (PropertyMetadata) new FrameworkPropertyMetadata((object) false, new PropertyChangedCallback(Ribbon.IsRibbonMenuOpenChanged)));
    Ribbon.IsMinimizedProperty = DependencyProperty.Register(nameof (IsMinimized), typeof (bool), typeof (Ribbon), (PropertyMetadata) new FrameworkPropertyMetadata((object) false, new PropertyChangedCallback(Ribbon.IsMinimizedChanged)));
    Ribbon.AutoExpandProperty = DependencyProperty.Register(nameof (AutoExpand), typeof (bool), typeof (Ribbon), (PropertyMetadata) new FrameworkPropertyMetadata((object) true));
    Ribbon.CanDialogCustomizeQatProperty = DependencyProperty.Register(nameof (CanDialogCustomizeQat), typeof (bool), typeof (Ribbon), (PropertyMetadata) new FrameworkPropertyMetadata((object) true));
    Ribbon.CanChangeQatPlacementProperty = DependencyProperty.Register(nameof (CanChangeQatPlacement), typeof (bool), typeof (Ribbon), (PropertyMetadata) new FrameworkPropertyMetadata((object) true));
    Ribbon.UseSpecKeyTipPositioningProperty = DependencyProperty.Register(nameof (UseSpecKeyTipPositioning), typeof (bool), typeof (Ribbon), (PropertyMetadata) new FrameworkPropertyMetadata((object) true));
    Ribbon.AutoHideRibbonContentProperty = DependencyProperty.Register(nameof (AutoHideRibbonContent), typeof (bool), typeof (Ribbon), (PropertyMetadata) new FrameworkPropertyMetadata((object) true));
    Ribbon.AutoHideTriggerSizeProperty = DependencyProperty.Register(nameof (AutoHideTriggerSize), typeof (Size), typeof (Ribbon), (PropertyMetadata) new FrameworkPropertyMetadata((object) new Size(300.0, 250.0)));
    Ribbon.IsActiveProperty = DependencyProperty.Register(nameof (IsActive), typeof (bool), typeof (Ribbon), (PropertyMetadata) new FrameworkPropertyMetadata((object) true));
    Ribbon.SystemButtonsProperty = DependencyProperty.Register(nameof (SystemButtons), typeof (bool), typeof (Ribbon), (PropertyMetadata) new FrameworkPropertyMetadata((object) true));
    Ribbon.LicenseKeyProperty = DependencyProperty.Register(nameof (LicenseKey), typeof (string), typeof (Ribbon), (PropertyMetadata) new FrameworkPropertyMetadata((object) "", new PropertyChangedCallback(Ribbon.OnLicenseKeyChanged)));
    Ribbon.SelectedContentTemplatePropertyKey = DependencyProperty.RegisterReadOnly(nameof (SelectedContentTemplate), typeof (DataTemplate), typeof (Ribbon), (PropertyMetadata) new FrameworkPropertyMetadata((PropertyChangedCallback) null));
    Ribbon.SelectedContentTemplateProperty = Ribbon.SelectedContentTemplatePropertyKey.DependencyProperty;
    Ribbon.SelectedContentTemplateSelectorPropertyKey = DependencyProperty.RegisterReadOnly(nameof (SelectedContentTemplateSelector), typeof (DataTemplateSelector), typeof (Ribbon), (PropertyMetadata) new FrameworkPropertyMetadata((PropertyChangedCallback) null));
    Ribbon.SelectedContentTemplateSelectorProperty = Ribbon.SelectedContentTemplateSelectorPropertyKey.DependencyProperty;
    Ribbon.ContentTemplateProperty = DependencyProperty.Register(nameof (ContentTemplate), typeof (DataTemplate), typeof (Ribbon), (PropertyMetadata) new FrameworkPropertyMetadata((PropertyChangedCallback) null));
    Ribbon.ContentTemplateSelectorProperty = DependencyProperty.Register(nameof (ContentTemplateSelector), typeof (DataTemplateSelector), typeof (Ribbon), (PropertyMetadata) new FrameworkPropertyMetadata((PropertyChangedCallback) null));
    Ribbon.ContextGroupsPropertyKey = DependencyProperty.RegisterReadOnly(nameof (ContextGroups), typeof (ContextGroupCollection), typeof (Ribbon), (PropertyMetadata) new FrameworkPropertyMetadata((object) new ContextGroupCollection()));
    Ribbon.ContextGroupsProperty = Ribbon.ContextGroupsPropertyKey.DependencyProperty;
    Ribbon.IsUsingGlassPropertyKey = DependencyProperty.RegisterReadOnly(nameof (IsUsingGlass), typeof (bool), typeof (Ribbon), (PropertyMetadata) new FrameworkPropertyMetadata((object) false));
    Ribbon.IsUsingGlassProperty = Ribbon.IsUsingGlassPropertyKey.DependencyProperty;
    Ribbon.KeyTipProperty = DependencyProperty.RegisterAttached("KeyTip", typeof (string), typeof (Ribbon), new PropertyMetadata((object) "", new PropertyChangedCallback(Ribbon.KeyTipChanged)));
    Ribbon.IsCustomizableProperty = DependencyProperty.RegisterAttached("IsCustomizable", typeof (bool), typeof (Ribbon), new PropertyMetadata((object) false, new PropertyChangedCallback(Ribbon.IsCustomizableChanged)));
    Ribbon.IsCustomizableContextSetProperty = DependencyProperty.RegisterAttached("IsCustomizableContextSet", typeof (bool), typeof (Ribbon), new PropertyMetadata((object) false));
    Ribbon.ElementRoleProperty = DependencyProperty.RegisterAttached("ElementRole", typeof (eElementRole), typeof (Ribbon), new PropertyMetadata((object) eElementRole.Default));
    EventManager.RegisterClassHandler(typeof (Ribbon), RibbonTabPanel.TabsScrolledEvent, (Delegate) new RoutedEventHandler(Ribbon.OnTabsScrolled));
    EventManager.RegisterClassHandler(typeof (Ribbon), Mouse.MouseWheelEvent, (Delegate) new MouseWheelEventHandler(Ribbon.OnMouseWheel));
    EventManager.RegisterClassHandler(typeof (Ribbon), ButtonDropDown.PreviewClickEvent, (Delegate) new RoutedEventHandler(Ribbon.OnButtonDropDownPreviewClick));
    EventManager.RegisterClassHandler(typeof (Ribbon), Mouse.MouseDownEvent, (Delegate) new MouseButtonEventHandler(Ribbon.OnMouseButtonDown));
    EventManager.RegisterClassHandler(typeof (Ribbon), Mouse.PreviewMouseDownEvent, (Delegate) new MouseButtonEventHandler(Ribbon.OnPreviewMouseButtonDown));
    EventManager.RegisterClassHandler(typeof (Ribbon), Mouse.MouseUpEvent, (Delegate) new MouseButtonEventHandler(Ribbon.OnMouseButtonUp));
    EventManager.RegisterClassHandler(typeof (Ribbon), Mouse.LostMouseCaptureEvent, (Delegate) new MouseEventHandler(Ribbon.OnLostMouseCapture));
    EventManager.RegisterClassHandler(typeof (Ribbon), BasePopupControl.IsSelectedChangedEvent, (Delegate) new RoutedPropertyChangedEventHandler<bool>(Ribbon.OnPopupIsSelectedChanged));
    EventManager.RegisterClassHandler(typeof (Ribbon), ButtonDropDown.CheckedEvent, (Delegate) new RoutedEventHandler(Ribbon.OnButtonDropDownCheckedClick));
    EventManager.RegisterClassHandler(typeof (Ribbon), ButtonDropDown.UncheckedEvent, (Delegate) new RoutedEventHandler(Ribbon.OnButtonDropDownUnCheckedClick));
    FocusManager.IsFocusScopeProperty.OverrideMetadata(typeof (Ribbon), (PropertyMetadata) new FrameworkPropertyMetadata((object) true));
    InputMethod.IsInputMethodSuspendedProperty.OverrideMetadata(typeof (Ribbon), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.Inherits));
    CommandManager.RegisterClassInputBinding(typeof (Ribbon), (InputBinding) new KeyBinding((ICommand) Ribbon.ToggleRibbonMinimize, Key.F1, ModifierKeys.Control));
    EventManager.RegisterClassHandler(typeof (Ribbon), AccessKeyManager.AccessKeyPressedEvent, (Delegate) new AccessKeyPressedEventHandler(Ribbon.OnAccessKeyPressed));
    Ribbon.BeforeRemoveFromQatEvent = EventManager.RegisterRoutedEvent("BeforeRemoveFromQat", RoutingStrategy.Direct, typeof (QatOperationEventHandler), typeof (Ribbon));
    Ribbon.AfterRemoveFromQatEvent = EventManager.RegisterRoutedEvent("AfterRemoveFromQat", RoutingStrategy.Direct, typeof (QatOperationEventHandler), typeof (Ribbon));
    Ribbon.BeforeAddToQatEvent = EventManager.RegisterRoutedEvent("BeforeAddToQat", RoutingStrategy.Direct, typeof (QatOperationAddEventHandler), typeof (Ribbon));
    Ribbon.AfterAddToQatEvent = EventManager.RegisterRoutedEvent("AfterAddToQat", RoutingStrategy.Direct, typeof (QatOperationAddEventHandler), typeof (Ribbon));
    Ribbon.BeforeCustomizeQatDialogEvent = EventManager.RegisterRoutedEvent("BeforeCustomizeQatDialog", RoutingStrategy.Direct, typeof (QatDialogEventHandler), typeof (Ribbon));
    Ribbon.AfterCustomizeQatDialogEvent = EventManager.RegisterRoutedEvent("AfterCustomizeQatDialog", RoutingStrategy.Direct, typeof (QatDialogEventHandler), typeof (Ribbon));
    Ribbon.LivePreviewEnabledProperty = DependencyProperty.RegisterAttached("LivePreviewEnabled", typeof (bool), typeof (Ribbon), new PropertyMetadata((object) false));
    Ribbon.LivePreviewEvent = EventManager.RegisterRoutedEvent("LivePreview", RoutingStrategy.Bubble, typeof (RoutedEventHandler), typeof (Ribbon));
    Ribbon.UndoLivePreviewEvent = EventManager.RegisterRoutedEvent("UndoLivePreview", RoutingStrategy.Bubble, typeof (RoutedEventHandler), typeof (Ribbon));
    Ribbon.EnterLivePreviewEvent = EventManager.RegisterRoutedEvent("EnterLivePreview", RoutingStrategy.Bubble, typeof (RoutedEventHandler), typeof (Ribbon));
    Ribbon.ExitLivePreviewEvent = EventManager.RegisterRoutedEvent("ExitLivePreview", RoutingStrategy.Bubble, typeof (RoutedEventHandler), typeof (Ribbon));
  }

  public Ribbon()
  {
    this.m_PopupHandler = new ParentPopupControlImpl((FrameworkElement) this);
    this.m_PopupHandler.InternalMenuModeChanged += new EventHandler(this.PopupHandlerInternalMenuModeChanged);
    ContextGroupCollection contextGroupCollection = new ContextGroupCollection();
    this.SetValue(Ribbon.ContextGroupsPropertyKey, (object) contextGroupCollection);
    Thickness windowBorderThickness = this.WindowBorderThickness;
    double left = windowBorderThickness.Left;
    windowBorderThickness = this.WindowBorderThickness;
    double right = windowBorderThickness.Right;
    this.HorizontalWindowBorderThickness = new Thickness(left, 0.0, right, 0.0);
    this.Loaded += new RoutedEventHandler(this.Ribbon_Loaded);
    this.Unloaded += new RoutedEventHandler(this.Ribbon_Unloaded);
  }

  public event QatDialogEventHandler BeforeCustomizeQatDialog
  {
    add => this.AddHandler(Ribbon.BeforeCustomizeQatDialogEvent, (Delegate) value);
    remove => this.RemoveHandler(Ribbon.BeforeCustomizeQatDialogEvent, (Delegate) value);
  }

  public event QatDialogEventHandler AfterCustomizeQatDialog
  {
    add => this.AddHandler(Ribbon.AfterCustomizeQatDialogEvent, (Delegate) value);
    remove => this.RemoveHandler(Ribbon.AfterCustomizeQatDialogEvent, (Delegate) value);
  }

  public event QatOperationEventHandler BeforeRemoveFromQat
  {
    add => this.AddHandler(Ribbon.BeforeRemoveFromQatEvent, (Delegate) value);
    remove => this.RemoveHandler(Ribbon.BeforeRemoveFromQatEvent, (Delegate) value);
  }

  public event QatOperationEventHandler AfterRemoveFromQat
  {
    add => this.AddHandler(Ribbon.AfterRemoveFromQatEvent, (Delegate) value);
    remove => this.RemoveHandler(Ribbon.AfterRemoveFromQatEvent, (Delegate) value);
  }

  public event QatOperationAddEventHandler BeforeAddToQat
  {
    add => this.AddHandler(Ribbon.BeforeAddToQatEvent, (Delegate) value);
    remove => this.RemoveHandler(Ribbon.BeforeAddToQatEvent, (Delegate) value);
  }

  public event QatOperationAddEventHandler AfterAddToQat
  {
    add => this.AddHandler(Ribbon.AfterAddToQatEvent, (Delegate) value);
    remove => this.RemoveHandler(Ribbon.AfterAddToQatEvent, (Delegate) value);
  }

  public event RoutedEventHandler LivePreview
  {
    add => this.AddHandler(Ribbon.LivePreviewEvent, (Delegate) value);
    remove => this.RemoveHandler(Ribbon.LivePreviewEvent, (Delegate) value);
  }

  public event RoutedEventHandler UndoLivePreview
  {
    add => this.AddHandler(Ribbon.UndoLivePreviewEvent, (Delegate) value);
    remove => this.RemoveHandler(Ribbon.UndoLivePreviewEvent, (Delegate) value);
  }

  public event RoutedEventHandler EnterLivePreview
  {
    add => this.AddHandler(Ribbon.EnterLivePreviewEvent, (Delegate) value);
    remove => this.RemoveHandler(Ribbon.EnterLivePreviewEvent, (Delegate) value);
  }

  public event RoutedEventHandler ExitLivePreview
  {
    add => this.AddHandler(Ribbon.ExitLivePreviewEvent, (Delegate) value);
    remove => this.RemoveHandler(Ribbon.ExitLivePreviewEvent, (Delegate) value);
  }

  protected override bool IsItemItsOwnContainerOverride(object item)
  {
    return this.ItemsSource != null ? item is RibbonTab : base.IsItemItsOwnContainerOverride(item);
  }

  protected override DependencyObject GetContainerForItemOverride()
  {
    return this.ItemsSource != null ? (DependencyObject) new RibbonTab() : base.GetContainerForItemOverride();
  }

  private void Ribbon_Unloaded(object sender, RoutedEventArgs e)
  {
    InputManager.Current.PostProcessInput -= new ProcessInputEventHandler(this.InternalPostProcessInput);
  }

  private void Ribbon_Loaded(object sender, RoutedEventArgs e)
  {
    InputManager.Current.PostProcessInput += new ProcessInputEventHandler(this.InternalPostProcessInput);
  }

  protected override IEnumerator LogicalChildren
  {
    get
    {
      ArrayList arrayList = new ArrayList();
      IEnumerator logicalChildren = base.LogicalChildren;
      while (logicalChildren.MoveNext())
        arrayList.Add(logicalChildren.Current);
      if (this.ApplicationMenu != null)
        arrayList.Add((object) this.ApplicationMenu);
      if (this.QuickAccessToolbar != null)
        arrayList.Add((object) this.QuickAccessToolbar);
      arrayList.AddRange((ICollection) this.ContextGroups);
      return arrayList.GetEnumerator();
    }
  }

  public override void OnApplyTemplate()
  {
    base.OnApplyTemplate();
    if (this.m_Popup != null)
    {
      this.m_Popup.Opened -= new EventHandler(this.Popup_Opened);
      this.m_Popup.Closed -= new EventHandler(this.Popup_Closed);
    }
    this.m_PanelBorder = this.GetTemplateChild("PART_RibbonPanelBorder") as RibbonBorder;
    this.m_QatPresenter = this.GetTemplateChild("PART_QAT") as ContentPresenter;
    this.m_AppMenuPresenter = this.GetTemplateChild("PART_ApplicationMenu") as ContentPresenter;
    this.m_QatBelowContainer = this.GetTemplateChild("PART_RibbonQatBelowBorder") as Decorator;
    this.m_RibbonContentPanel = this.GetTemplateChild("PART_RCP") as RibbonContentPanel;
    this.m_Popup = this.GetTemplateChild("PART_Popup") as Popup;
    this.m_ContentBorder = this.GetTemplateChild("PART_RibbonPanelBorder") as RibbonBorder;
    this.m_PopupBorder = this.GetTemplateChild("PART_RibbonPopupBorder") as RibbonBorder;
    this.OnIsQuickAccessToolbarBelowChanged(!this.IsQuickAccessToolbarBelow, this.IsQuickAccessToolbarBelow);
    this.UpdateSelectedContent();
    Window window = Window.GetWindow((DependencyObject) this);
    if (window != null)
      this.SetupWindowBinding(window);
    if (this.m_Popup != null)
    {
      this.m_Popup.Opened += new EventHandler(this.Popup_Opened);
      this.m_Popup.Closed += new EventHandler(this.Popup_Closed);
    }
    if (this.IsMinimized)
      this.UpdateMinimizedContentState();
    if (!(window is RibbonWindow))
      return;
    ((RibbonWindow) window).UpdateGlass();
  }

  private void Popup_Closed(object sender, EventArgs e)
  {
    if (this.m_KeyTipsAdorner == null || !(this.m_KeyTipsAdorner.ContextObject is RibbonTab))
      return;
    if (this.m_KeyTipsAdorner.Parent is AdornerLayer parent)
      parent.Remove((Adorner) this.m_KeyTipsAdorner);
    this.m_KeyTipsAdorner = (KeyTipsAdorner) null;
  }

  private void Popup_Opened(object sender, EventArgs e)
  {
  }

  protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
  {
    if (this.ApplicationMenu is DevComponents.WpfRibbon.ApplicationMenu)
    {
      DevComponents.WpfRibbon.ApplicationMenu applicationMenu = this.ApplicationMenu as DevComponents.WpfRibbon.ApplicationMenu;
      if (applicationMenu.IsPopupOpen && !applicationMenu.IsBackstageActive)
        applicationMenu.IsPopupOpen = false;
    }
    base.OnRenderSizeChanged(sizeInfo);
  }

  private static void OnTabsScrolled(object sender, RoutedEventArgs e)
  {
    if (!(sender is Ribbon ribbon))
      return;
    ribbon.UpdatePanelBorderSelectedTabRect();
  }

  private void UpdatePanelBorderSelectedTabRect() => this.UpdatePanelBorderSelectedTabRect(true);

  private void UpdatePanelBorderSelectedTabRect(bool invokeAfterRenderIfNeeded)
  {
    if (this.m_PanelBorder == null)
      return;
    RibbonTab selectedTabItem = this.GetSelectedTabItem();
    if (selectedTabItem == null)
      this.m_PanelBorder.SelectedTabRect = new Rect();
    else if (selectedTabItem.IsArrangeValid && selectedTabItem.Parent == this)
    {
      Rect layoutSlot = LayoutInformation.GetLayoutSlot((FrameworkElement) selectedTabItem) with
      {
        Location = selectedTabItem.PointToScreen(new System.Windows.Point(0.0, 0.0))
      };
      layoutSlot.Location = this.m_PanelBorder.PointFromScreen(layoutSlot.Location);
      layoutSlot.Inflate(-3.0, 0.0);
      this.m_PanelBorder.SelectedTabRect = layoutSlot;
    }
    else
    {
      if (!invokeAfterRenderIfNeeded)
        return;
      this.Dispatcher.BeginInvoke(DispatcherPriority.Render, (Delegate) new DispatcherOperationCallback(this.InvokeUpdateBorderAfterRender), (object) null);
    }
  }

  private object InvokeUpdateBorderAfterRender(object args)
  {
    this.UpdatePanelBorderSelectedTabRect(false);
    return (object) null;
  }

  internal bool IsBelowMinimumSize
  {
    get
    {
      if (this.HasItems && this.AutoHideRibbonContent)
      {
        Window window = Window.GetWindow((DependencyObject) this);
        if (window != null && !this.IsDesignMode && window.ActualWidth > 0.0)
        {
          double actualWidth = window.ActualWidth;
          Size autoHideTriggerSize = this.AutoHideTriggerSize;
          double width = autoHideTriggerSize.Width;
          if (actualWidth > width)
          {
            double actualHeight = window.ActualHeight;
            autoHideTriggerSize = this.AutoHideTriggerSize;
            double height = autoHideTriggerSize.Height;
            if (actualHeight > height)
              goto label_5;
          }
          return true;
        }
      }
label_5:
      return false;
    }
  }

  private bool IsDesignMode => DesignerProperties.GetIsInDesignMode((DependencyObject) this);

  internal UIElement PopupBorderContent
  {
    get => this.m_PopupBorder != null ? this.m_PopupBorder.Child : (UIElement) this.m_PopupBorder;
  }

  protected override Size MeasureOverride(Size constraint)
  {
    if (this.m_PanelBorder != null)
    {
      if (this.IsBelowMinimumSize)
      {
        if (this.m_PanelBorder.Visibility == Visibility.Visible)
          this.m_PanelBorder.Visibility = Visibility.Collapsed;
      }
      else if (this.HasItems)
      {
        if (this.IsMinimized)
        {
          if (this.m_PanelBorder.Visibility == Visibility.Visible)
            this.m_PanelBorder.Visibility = Visibility.Collapsed;
        }
        else if (this.m_PanelBorder.Visibility != Visibility.Visible)
          this.m_PanelBorder.Visibility = Visibility.Visible;
      }
    }
    return base.MeasureOverride(constraint);
  }

  protected override Size ArrangeOverride(Size arrangeBounds)
  {
    Size size = base.ArrangeOverride(arrangeBounds);
    this.UpdatePanelBorderSelectedTabRect();
    return size;
  }

  private void UpdateSelectedContent()
  {
    if (this.SelectedIndex < 0)
    {
      this.SelectedContent = (object) null;
      this.ClearValue(RibbonTab.TabColorProperty);
    }
    else
    {
      RibbonTab selectedTabItem = this.GetSelectedTabItem();
      if (selectedTabItem != null)
      {
        this.SelectedContent = selectedTabItem.Content;
        ContentPresenter contentPresenter = this.GetSelectedContentPresenter();
        if (contentPresenter != null)
        {
          contentPresenter.HorizontalAlignment = selectedTabItem.HorizontalContentAlignment;
          contentPresenter.VerticalAlignment = selectedTabItem.VerticalContentAlignment;
        }
        if (selectedTabItem.ContentTemplate != null || selectedTabItem.ContentTemplateSelector != null)
        {
          this.SelectedContentTemplate = selectedTabItem.ContentTemplate;
          this.SelectedContentTemplateSelector = selectedTabItem.ContentTemplateSelector;
        }
        else
        {
          this.SelectedContentTemplate = this.ContentTemplate;
          this.SelectedContentTemplateSelector = this.ContentTemplateSelector;
        }
        if (this.ShowKeyTips && this.m_KeyTipsAdorner != null && this.m_KeyTipsAdorner.ContextObject is RibbonTab && this.m_KeyTipsAdorner.ContextObject != selectedTabItem)
          this.ShowKeyTips = false;
        RibbonTab.SetTabColor((UIElement) this, selectedTabItem.Color);
      }
      else
        this.ClearValue(RibbonTab.TabColorProperty);
    }
    this.UpdatePanelBorderSelectedTabRect();
  }

  internal ContentPresenter GetSelectedContentPresenter()
  {
    return this.GetTemplateChild("PART_TabContentHost") as ContentPresenter;
  }

  protected override void OnSelectionChanged(SelectionChangedEventArgs e)
  {
    base.OnSelectionChanged(e);
    if (this.ApplicationMenu is DevComponents.WpfRibbon.ApplicationMenu)
    {
      DevComponents.WpfRibbon.ApplicationMenu applicationMenu = this.ApplicationMenu as DevComponents.WpfRibbon.ApplicationMenu;
      if (applicationMenu.IsPopupOpen)
        applicationMenu.IsPopupOpen = false;
    }
    this.UpdateSelectedContent();
    CommandManager.InvalidateRequerySuggested();
  }

  protected override void OnInitialized(EventArgs e)
  {
    Ribbon.LoadCommonStyles();
    base.OnInitialized(e);
    PropertyInfo property = this.GetType().GetProperty("CanSelectMultiple", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
    if (property != (PropertyInfo) null)
      property.SetValue((object) this, (object) false, (object[]) null);
    this.ItemContainerGenerator.StatusChanged += new EventHandler(this.OnGeneratorStatusChanged);
    this.SetupRibbonWindow();
    this.SetupEnterMenuMode();
  }

  private void SetupRibbonWindow()
  {
    Window window = Window.GetWindow((DependencyObject) this);
    if (window == null || !(window is RibbonWindow) || ((RibbonWindow) window).RibbonControl == this)
      return;
    ((RibbonWindow) window).RibbonControl = this;
  }

  public void SetupBindings()
  {
    Window window = Window.GetWindow((DependencyObject) this);
    if (window == null)
      return;
    if (this._RibbonMinimizeCommandBinding == null)
      this._RibbonMinimizeCommandBinding = new CommandBinding((ICommand) Ribbon.ToggleRibbonMinimize, new ExecutedRoutedEventHandler(this.ToggleRibbonMinimizeExecuted), new CanExecuteRoutedEventHandler(this.ToggleRibbonMinimizeCanExecute));
    window.CommandBindings.Add(this._RibbonMinimizeCommandBinding);
    if (this._RibbonMinimizeKeyBinding == null)
      this._RibbonMinimizeKeyBinding = new KeyBinding((ICommand) Ribbon.ToggleRibbonMinimize, Key.F1, ModifierKeys.Control);
    window.InputBindings.Add((InputBinding) this._RibbonMinimizeKeyBinding);
  }

  public void ReleaseBindings()
  {
    Window window = Window.GetWindow((DependencyObject) this);
    if (this._RibbonMinimizeCommandBinding != null && window != null)
    {
      window.CommandBindings.Remove(this._RibbonMinimizeCommandBinding);
      this._RibbonMinimizeCommandBinding = (CommandBinding) null;
    }
    if (this._RibbonMinimizeKeyBinding == null || window == null)
      return;
    window.InputBindings.Remove((InputBinding) this._RibbonMinimizeKeyBinding);
    this._RibbonMinimizeKeyBinding = (KeyBinding) null;
  }

  protected override void OnVisualParentChanged(DependencyObject oldParent)
  {
    this.SetupRibbonWindow();
    base.OnVisualParentChanged(oldParent);
  }

  private void OnGeneratorStatusChanged(object sender, EventArgs e)
  {
    if (this.ItemContainerGenerator.Status != GeneratorStatus.ContainersGenerated)
      return;
    if (this.HasItems && this.SelectedIndex < 0)
      this.SelectedItem = (object) this.FindNextTabItem(-1, 1);
    this.UpdateSelectedContent();
  }

  protected override void OnItemsChanged(NotifyCollectionChangedEventArgs e)
  {
    base.OnItemsChanged(e);
    if (e.Action != NotifyCollectionChangedAction.Remove || this.SelectedIndex != -1)
      return;
    int startIndex = e.OldStartingIndex + 1;
    if (startIndex > this.Items.Count)
      startIndex = 0;
    RibbonTab nextTabItem = this.FindNextTabItem(startIndex, -1);
    if (nextTabItem == null)
      return;
    nextTabItem.IsSelected = true;
  }

  private RibbonTab FindNextTabItem(int startIndex, int direction)
  {
    if (direction != 0)
    {
      int index1 = startIndex;
      for (int index2 = 0; index2 < this.Items.Count; ++index2)
      {
        index1 += direction;
        if (index1 >= this.Items.Count)
          index1 = 0;
        else if (index1 < 0)
          index1 = this.Items.Count - 1;
        if (this.Items[index1] is RibbonTab nextTabItem && nextTabItem.IsEnabled && nextTabItem.Visibility == Visibility.Visible)
          return nextTabItem;
      }
    }
    return (RibbonTab) null;
  }

  private RibbonTab GetSelectedTabItem() => this.SelectedItem as RibbonTab;

  [Browsable(true)]
  [DefaultValue(true)]
  public bool SystemButtons
  {
    get => (bool) this.GetValue(Ribbon.SystemButtonsProperty);
    set => this.SetValue(Ribbon.SystemButtonsProperty, (object) value);
  }

  [Browsable(false)]
  [DefaultValue("")]
  public string LicenseKey
  {
    get => (string) this.GetValue(Ribbon.LicenseKeyProperty);
    set => this.SetValue(Ribbon.LicenseKeyProperty, (object) value);
  }

  private static void OnLicenseKeyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
  {
    ((Ribbon) d).OnLicenseKeyChanged();
  }

  private void OnLicenseKeyChanged() => WinApi.ValidateLicenseKey(this.LicenseKey);

  [EditorBrowsable(EditorBrowsableState.Never)]
  public static void InitLK(string lk) => WinApi.ValidateLicenseKey(lk);

  private static void OnApplicationMenuChanged(
    DependencyObject d,
    DependencyPropertyChangedEventArgs e)
  {
    ((Ribbon) d).OnApplicationMenuChanged(e.OldValue as UIElement, e.NewValue as UIElement);
  }

  private void OnApplicationMenuChanged(UIElement oldValue, UIElement newValue)
  {
    if (oldValue != null)
    {
      this.RemoveLogicalChild((object) oldValue);
      if (oldValue is FrameworkElement)
        ((FrameworkElement) oldValue).SizeChanged -= new SizeChangedEventHandler(this.AppMenuSizeChanged);
    }
    if (newValue == null)
      return;
    this.AddLogicalChild((object) newValue);
    if (!(newValue is FrameworkElement))
      return;
    ((FrameworkElement) newValue).SizeChanged += new SizeChangedEventHandler(this.AppMenuSizeChanged);
  }

  private void AppMenuSizeChanged(object sender, SizeChangedEventArgs e)
  {
    this.UpdateRibbonWindowGlass();
  }

  private static void OnQuickAccessToolbarChanged(
    DependencyObject d,
    DependencyPropertyChangedEventArgs e)
  {
    ((Ribbon) d).OnQuickAccessToolbarChanged(e.OldValue as UIElement, e.NewValue as UIElement);
  }

  private void OnQuickAccessToolbarChanged(UIElement oldValue, UIElement newValue)
  {
    if (oldValue != null)
    {
      this.RemoveLogicalChild((object) oldValue);
      if (oldValue is Qat target)
        BindingOperations.ClearBinding((DependencyObject) target, Qat.IsActiveProperty);
    }
    if (newValue == null)
      return;
    this.AddLogicalChild((object) newValue);
    if (!(newValue is Qat target1))
      return;
    BindingOperations.SetBinding((DependencyObject) target1, Qat.IsActiveProperty, (BindingBase) new Binding("IsActive")
    {
      Source = (object) this
    });
  }

  private static void OnIsQuickAccessToolbarBelowChanged(
    DependencyObject d,
    DependencyPropertyChangedEventArgs e)
  {
    ((Ribbon) d).OnIsQuickAccessToolbarBelowChanged((bool) e.OldValue, (bool) e.NewValue);
  }

  public void SetupWindowBinding(Window w)
  {
    BindingOperations.SetBinding((DependencyObject) this, Ribbon.IsActiveProperty, (BindingBase) new Binding("IsActive")
    {
      Source = (object) w
    });
  }

  private void OnIsQuickAccessToolbarBelowChanged(bool oldValue, bool newValue)
  {
    if (this.m_QatPresenter == null || this.m_QatBelowContainer == null || this.m_RibbonContentPanel == null)
      return;
    if (newValue)
    {
      this.m_RibbonContentPanel.Children.Remove((UIElement) this.m_QatPresenter);
      this.m_QatBelowContainer.Child = (UIElement) this.m_QatPresenter;
      this.m_QatBelowContainer.Visibility = Visibility.Visible;
      if (!(this.m_QatPresenter.Content is Qat))
        return;
      ((Qat) this.m_QatPresenter.Content).IsAboveRibbon = false;
    }
    else
    {
      if (this.m_QatBelowContainer.Child != this.m_QatPresenter)
        return;
      this.m_QatBelowContainer.Child = (UIElement) null;
      this.m_QatBelowContainer.Visibility = Visibility.Collapsed;
      this.m_RibbonContentPanel.Children.Add((UIElement) this.m_QatPresenter);
      if (!(this.m_QatPresenter.Content is Qat))
        return;
      ((Qat) this.m_QatPresenter.Content).IsAboveRibbon = true;
    }
  }

  private static void OnMouseWheel(object sender, MouseWheelEventArgs e)
  {
    if (!(sender is Ribbon ribbon) || e.Handled || ribbon.IsKeyboardFocusWithin)
      return;
    ribbon.SelectTabMouseWheel(e);
  }

  private void SelectTabMouseWheel(MouseWheelEventArgs e)
  {
    if (!new Rect(this.RenderSize).Contains(Mouse.GetPosition((IInputElement) this)))
      return;
    if (e.Delta < 0)
      e.Handled = this.SelectNextTab();
    else
      e.Handled = this.SelectPreviousTab();
  }

  private bool SelectPreviousTab()
  {
    if (this.SelectedIndex <= 0)
      return false;
    int ribbonTabIndex = this.GetRibbonTabIndex(this.SelectedIndex, -1);
    if (ribbonTabIndex < 0)
      return false;
    this.SelectedIndex = ribbonTabIndex;
    return true;
  }

  private bool SelectNextTab()
  {
    if (this.SelectedIndex >= this.Items.Count - 1)
      return false;
    int ribbonTabIndex = this.GetRibbonTabIndex(this.SelectedIndex, 1);
    if (ribbonTabIndex < 0)
      return false;
    this.SelectedIndex = ribbonTabIndex;
    return true;
  }

  private int GetRibbonTabIndex(int start, int direction)
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
      if (this.Items[index] is RibbonTab ribbonTab && ribbonTab.Visibility == Visibility.Visible)
        return index;
    }
    return -1;
  }

  [Browsable(false)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public bool IsActive
  {
    get => (bool) this.GetValue(RibbonBackgroundChrome.IsActiveProperty);
    set => this.SetValue(RibbonBackgroundChrome.IsActiveProperty, (object) value);
  }

  public UIElement ApplicationMenu
  {
    get => (UIElement) this.GetValue(Ribbon.ApplicationMenuProperty);
    set => this.SetValue(Ribbon.ApplicationMenuProperty, (object) value);
  }

  public UIElement QuickAccessToolbar
  {
    get => (UIElement) this.GetValue(Ribbon.QuickAccessToolbarProperty);
    set => this.SetValue(Ribbon.QuickAccessToolbarProperty, (object) value);
  }

  public bool IsQuickAccessToolbarBelow
  {
    get => (bool) this.GetValue(Ribbon.IsQuickAccessToolbarBelowProperty);
    set => this.SetValue(Ribbon.IsQuickAccessToolbarBelowProperty, (object) value);
  }

  public Thickness WindowBorderThickness
  {
    get => (Thickness) this.GetValue(Ribbon.WindowBorderThicknessProperty);
    set => this.SetValue(Ribbon.WindowBorderThicknessProperty, (object) value);
  }

  private static void WindowBorderThicknessChanged(
    DependencyObject d,
    DependencyPropertyChangedEventArgs e)
  {
    ((Ribbon) d).OnWindowBorderThicknessChanged((Thickness) e.NewValue);
  }

  private void OnWindowBorderThicknessChanged(Thickness t)
  {
    this.HorizontalWindowBorderThickness = new Thickness(t.Left, 0.0, t.Right, 0.0);
  }

  public Thickness HorizontalWindowBorderThickness
  {
    get => (Thickness) this.GetValue(Ribbon.HorizontalWindowBorderThicknessProperty);
    internal set
    {
      this.SetValue(Ribbon.HorizontalWindowBorderThicknessPropertyKey, (object) value);
    }
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public object SelectedContent
  {
    get => this.GetValue(Ribbon.SelectedContentProperty);
    internal set => this.SetValue(Ribbon.SelectedContentPropertyKey, value);
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public DataTemplate SelectedContentTemplate
  {
    get => (DataTemplate) this.GetValue(Ribbon.SelectedContentTemplateProperty);
    internal set => this.SetValue(Ribbon.SelectedContentTemplatePropertyKey, (object) value);
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public DataTemplateSelector SelectedContentTemplateSelector
  {
    get => (DataTemplateSelector) this.GetValue(Ribbon.SelectedContentTemplateSelectorProperty);
    internal set
    {
      this.SetValue(Ribbon.SelectedContentTemplateSelectorPropertyKey, (object) value);
    }
  }

  public DataTemplate ContentTemplate
  {
    get => (DataTemplate) this.GetValue(Ribbon.ContentTemplateProperty);
    set => this.SetValue(Ribbon.ContentTemplateProperty, (object) value);
  }

  public DataTemplateSelector ContentTemplateSelector
  {
    get => (DataTemplateSelector) this.GetValue(Ribbon.ContentTemplateSelectorProperty);
    set => this.SetValue(Ribbon.ContentTemplateSelectorProperty, (object) value);
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
  public ContextGroupCollection ContextGroups
  {
    get => (ContextGroupCollection) this.GetValue(Ribbon.ContextGroupsProperty);
  }

  internal static void LoadCommonStyles()
  {
    if (Application.Current == null || Application.Current.Resources.Contains((object) RibbonColors.CaptionBackground))
      return;
    Application.Current.Resources.MergedDictionaries.Add((ResourceDictionary) new CommonStyles());
  }

  [Browsable(true)]
  [NotifyParentProperty(true)]
  [Category("Localization")]
  [Description("Gets system text used by the component..")]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
  public RibbonLocalization SystemText => this.m_SystemText;

  [Browsable(true)]
  [DefaultValue(true)]
  public bool AutoExpand
  {
    get => (bool) this.GetValue(Ribbon.AutoExpandProperty);
    set => this.SetValue(Ribbon.AutoExpandProperty, (object) value);
  }

  [Browsable(true)]
  [DefaultValue(true)]
  public bool CanDialogCustomizeQat
  {
    get => (bool) this.GetValue(Ribbon.CanDialogCustomizeQatProperty);
    set => this.SetValue(Ribbon.CanDialogCustomizeQatProperty, (object) value);
  }

  [Browsable(true)]
  [DefaultValue(true)]
  public bool CanChangeQatPlacement
  {
    get => (bool) this.GetValue(Ribbon.CanChangeQatPlacementProperty);
    set => this.SetValue(Ribbon.CanChangeQatPlacementProperty, (object) value);
  }

  [Browsable(true)]
  [DefaultValue(true)]
  public bool AutoHideRibbonContent
  {
    get => (bool) this.GetValue(Ribbon.AutoHideRibbonContentProperty);
    set => this.SetValue(Ribbon.AutoHideRibbonContentProperty, (object) value);
  }

  [Browsable(true)]
  public Size AutoHideTriggerSize
  {
    get => (Size) this.GetValue(Ribbon.AutoHideTriggerSizeProperty);
    set => this.SetValue(Ribbon.AutoHideTriggerSizeProperty, (object) value);
  }

  private bool ShouldSerializeAutoHideTriggerSize()
  {
    return this.AutoHideTriggerSize.Width != 300.0 || this.AutoHideTriggerSize.Height != 250.0;
  }

  [Browsable(true)]
  [DefaultValue(true)]
  public bool UseSpecKeyTipPositioning
  {
    get => (bool) this.GetValue(Ribbon.UseSpecKeyTipPositioningProperty);
    set => this.SetValue(Ribbon.UseSpecKeyTipPositioningProperty, (object) value);
  }

  [Browsable(false)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public bool IsRibbonMenuOpen
  {
    get => (bool) this.GetValue(Ribbon.IsRibbonMenuOpenProperty);
    set => this.SetValue(Ribbon.IsRibbonMenuOpenProperty, (object) value);
  }

  [Browsable(false)]
  public bool IsMinimized
  {
    get => (bool) this.GetValue(Ribbon.IsMinimizedProperty);
    set => this.SetValue(Ribbon.IsMinimizedProperty, (object) value);
  }

  private static void IsMinimizedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
  {
    (d as Ribbon).OnIsMinimizedChanged((bool) e.OldValue, (bool) e.NewValue);
  }

  private void OnIsMinimizedChanged(bool oldValue, bool newValue)
  {
    this.UpdateMinimizedContentState();
  }

  private void UpdateMinimizedContentState()
  {
    if (this.m_Popup == null || this.m_ContentBorder == null || this.m_PopupBorder == null)
      return;
    if (this.IsMinimized)
    {
      UIElement child = this.m_ContentBorder.Child;
      this.m_ContentBorder.Child = (UIElement) null;
      this.m_PopupBorder.Child = child;
    }
    else
    {
      if (this.IsRibbonMenuOpen)
        this.IsRibbonMenuOpen = false;
      UIElement child = this.m_PopupBorder.Child;
      this.m_PopupBorder.Child = (UIElement) null;
      this.m_ContentBorder.Child = child;
    }
    foreach (object obj in (IEnumerable) this.Items)
    {
      if (obj is RibbonTab)
        ((RibbonTab) obj).IsMinimizedState = this.IsMinimized;
    }
    this.InvalidateMeasure();
  }

  private static void IsRibbonMenuOpenChanged(
    DependencyObject d,
    DependencyPropertyChangedEventArgs e)
  {
    (d as Ribbon).OnIsRibbonMenuOpenChanged((bool) e.OldValue, (bool) e.NewValue);
  }

  private void OnIsRibbonMenuOpenChanged(bool oldValue, bool newValue)
  {
    foreach (object obj in (IEnumerable) this.Items)
    {
      if (obj is RibbonTab)
        ((RibbonTab) obj).IsRibbonMenuOpen = newValue;
    }
    Window window = Window.GetWindow((DependencyObject) this);
    if (newValue)
    {
      ((IPopupParentControl) this).IsPopupMode = true;
      if (window != null)
        window.Deactivated += new EventHandler(this.ParentWindowDeactivated);
    }
    else if (window != null)
      window.Deactivated -= new EventHandler(this.ParentWindowDeactivated);
    this.InvalidateMeasure();
  }

  private void ParentWindowDeactivated(object sender, EventArgs e)
  {
    if (!this.IsRibbonMenuOpen)
      return;
    this.IsRibbonMenuOpen = false;
  }

  internal bool HasCaption => this.m_AppMenuPresenter != null || this.m_QatPresenter != null;

  internal double GetTitleChromeHeight()
  {
    double titleChromeHeight = 0.0;
    if (this.m_RibbonContentPanel != null)
    {
      titleChromeHeight = this.m_RibbonContentPanel.BackgroundChrome.TotalTitleChromeHeight;
      if (this.EffectiveStyle == eEffectiveStyle.Office2010)
      {
        if (this.ApplicationMenu != null)
          titleChromeHeight += this.ApplicationMenu.RenderSize.Height + 5.0;
        else
          titleChromeHeight += 28.0;
      }
    }
    return titleChromeHeight;
  }

  [Browsable(false)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public bool IsUsingGlass
  {
    get => (bool) this.GetValue(Ribbon.IsUsingGlassProperty);
    internal set => this.SetValue(Ribbon.IsUsingGlassPropertyKey, (object) value);
  }

  [AttachedPropertyBrowsableForChildren]
  public static string GetKeyTip(UIElement element)
  {
    return element != null ? (string) element.GetValue(Ribbon.KeyTipProperty) : throw new ArgumentNullException("elem");
  }

  public static void SetKeyTip(UIElement element, string keytip)
  {
    if (element == null)
      throw new ArgumentNullException("elem");
    if (keytip != null)
      keytip = keytip.ToUpper();
    element.SetValue(Ribbon.KeyTipProperty, (object) keytip);
  }

  private static void KeyTipChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
  {
  }

  public static bool GetIsCustomizable(FrameworkElement element)
  {
    return element != null ? (bool) element.GetValue(Ribbon.IsCustomizableProperty) : throw new ArgumentNullException("elem");
  }

  public static void SetIsCustomizable(FrameworkElement element, bool value)
  {
    if (element == null)
      throw new ArgumentNullException("elem");
    element.SetValue(Ribbon.IsCustomizableProperty, (object) value);
  }

  public static eElementRole GetElementRole(FrameworkElement element)
  {
    return element != null ? (eElementRole) element.GetValue(Ribbon.ElementRoleProperty) : throw new ArgumentNullException("elem");
  }

  public static void SetElementRole(FrameworkElement element, eElementRole value)
  {
    if (element == null)
      throw new ArgumentNullException("elem");
    element.SetValue(Ribbon.ElementRoleProperty, (object) value);
  }

  public static bool GetLivePreviewEnabled(FrameworkElement element)
  {
    return element != null ? (bool) element.GetValue(Ribbon.LivePreviewEnabledProperty) : throw new ArgumentNullException("elem");
  }

  public static void SetLivePreviewEnabled(FrameworkElement element, bool value)
  {
    if (element == null)
      throw new ArgumentNullException("elem");
    element.SetValue(Ribbon.LivePreviewEnabledProperty, (object) value);
  }

  private static void IsCustomizableChanged(
    DependencyObject d,
    DependencyPropertyChangedEventArgs e)
  {
  }

  internal static bool GetIsCustomizableContextSet(FrameworkElement element)
  {
    return element != null ? (bool) element.GetValue(Ribbon.IsCustomizableContextSetProperty) : throw new ArgumentNullException("elem");
  }

  internal static void SetIsCustomizableContextSet(FrameworkElement element, bool value)
  {
    if (element == null)
      throw new ArgumentNullException("elem");
    element.SetValue(Ribbon.IsCustomizableContextSetProperty, (object) value);
  }

  protected override void OnPreviewMouseRightButtonUp(MouseButtonEventArgs e)
  {
    if (Ribbon.GetIsCustomizable((FrameworkElement) this) && e.Source != this && !e.Handled && e.Source != null && e.Source is FrameworkElement)
    {
      FrameworkElement frameworkElement = e.Source as FrameworkElement;
      switch (frameworkElement)
      {
        case RibbonBar _:
        case Qat _:
        case DevComponents.WpfRibbon.ApplicationMenu _ when ((ButtonDropDown) frameworkElement).IsPopupOpen:
          FrameworkElement elementAt = LayoutHelpers.GetElementAt(frameworkElement, frameworkElement.PointToScreen(e.GetPosition((IInputElement) frameworkElement)));
          if (elementAt != null)
          {
            frameworkElement = elementAt;
            break;
          }
          break;
        case DevComponents.WpfRibbon.ApplicationMenu _ when !((ButtonDropDown) frameworkElement).IsPopupOpen:
          frameworkElement = (FrameworkElement) null;
          break;
      }
      if (frameworkElement != null && frameworkElement.ContextMenu == null && Ribbon.GetIsCustomizable(frameworkElement))
      {
        if (frameworkElement is ButtonDropDown && ((ButtonDropDown) frameworkElement).IsPopupOpen)
          ((ButtonDropDown) frameworkElement).IsPopupOpen = false;
        if (!frameworkElement.IsEnabled)
          ContextMenuService.SetShowOnDisabled((DependencyObject) frameworkElement, true);
        ContextMenu customizeContextMenu = this.GetCustomizeContextMenu();
        this.SetupCustomizeContextMenu(customizeContextMenu, frameworkElement);
        frameworkElement.ContextMenu = customizeContextMenu;
        Ribbon.SetIsCustomizableContextSet(frameworkElement, true);
      }
    }
    base.OnPreviewMouseRightButtonUp(e);
  }

  private void SetupCustomizeContextMenu(ContextMenu cm, FrameworkElement elem)
  {
    DependencyObject parent = LogicalTreeHelper.GetParent((DependencyObject) elem);
    Visibility visibility1 = Visibility.Collapsed;
    Visibility visibility2 = Visibility.Collapsed;
    Visibility visibility3 = Visibility.Collapsed;
    Visibility visibility4 = Visibility.Collapsed;
    bool flag1 = true;
    if (!(elem is RibbonTab))
    {
      switch (parent)
      {
        case Qat _:
        case QatPanel _:
        case QatOverflowPanel _:
          break;
        default:
          if (this.IsElementOnQat(elem))
          {
            if (elem.Parent != this.QuickAccessToolbar)
            {
              visibility1 = Visibility.Visible;
              flag1 = false;
              break;
            }
            break;
          }
          visibility1 = Visibility.Visible;
          break;
      }
    }
    if (this.CanDialogCustomizeQat)
      visibility3 = Visibility.Visible;
    if (this.CanChangeQatPlacement)
      visibility4 = Visibility.Visible;
    Visibility visibility5 = this.AutoExpand ? Visibility.Visible : Visibility.Collapsed;
    bool flag2 = true;
    for (int index = 0; index < cm.Items.Count; ++index)
    {
      object obj = cm.Items[index];
      if (obj is MenuItem)
      {
        MenuItem menuItem = obj as MenuItem;
        if (menuItem.Name == Ribbon.SystemQatChangePlacementMenuItem)
        {
          if (this.IsQuickAccessToolbarBelow)
            menuItem.Header = (object) this.SystemText.QatPlaceAboveRibbonText;
          else
            menuItem.Header = (object) this.SystemText.QatPlaceBelowRibbonText;
          menuItem.Visibility = visibility4;
        }
        else if (menuItem.Name == Ribbon.SystemQatMinMaxRibbonMenuItem)
        {
          if (this.IsMinimized)
            menuItem.Header = (object) this.SystemText.MaximizeRibbonText;
          else
            menuItem.Header = (object) this.SystemText.MinimizeRibbonText;
          menuItem.Visibility = visibility5;
        }
        else if (menuItem.Name == Ribbon.SystemAddToQatMenuItem)
        {
          menuItem.Visibility = visibility1;
          menuItem.IsEnabled = flag1;
          if (visibility1 == Visibility.Visible)
          {
            menuItem.CommandTarget = (IInputElement) this;
            menuItem.CommandParameter = (object) elem;
          }
          else
          {
            menuItem.CommandTarget = (IInputElement) null;
            menuItem.CommandParameter = (object) null;
          }
        }
        else if (menuItem.Name == Ribbon.SystemRemoveFromQatMenuItem)
        {
          menuItem.Visibility = visibility2;
          if (visibility2 == Visibility.Visible)
          {
            menuItem.CommandTarget = (IInputElement) this;
            menuItem.CommandParameter = (object) elem;
          }
          else
          {
            menuItem.CommandTarget = (IInputElement) null;
            menuItem.CommandParameter = (object) null;
          }
        }
        else if (menuItem.Name == Ribbon.SystemCustomizeQatMenuItem)
          menuItem.Visibility = visibility3;
      }
      else if (obj is Separator && flag2)
        ((UIElement) obj).Visibility = Visibility.Collapsed;
      if (obj is FrameworkElement && ((UIElement) obj).Visibility == Visibility.Visible)
        flag2 = false;
    }
  }

  public bool IsElementOnQat(FrameworkElement elem)
  {
    ItemsControl quickAccessToolbar = this.QuickAccessToolbar as ItemsControl;
    if (elem != null && quickAccessToolbar != null && quickAccessToolbar.Items.Contains((object) elem))
      return true;
    ButtonDropDown buttonDropDown = elem as ButtonDropDown;
    if (elem == null || this.QuickAccessToolbar == null || !(this.QuickAccessToolbar is ItemsControl) || elem.Name == "" && buttonDropDown == null || elem.Name == "" && buttonDropDown != null && buttonDropDown.Command == null)
      return false;
    foreach (object obj in (IEnumerable) quickAccessToolbar.Items)
    {
      if (obj is FrameworkElement frameworkElement && (frameworkElement.Name != "" && (frameworkElement.Name == elem.Name || frameworkElement.Name == "SysQatButton_" + elem.Name) || frameworkElement is ButtonDropDown && buttonDropDown != null && ((ButtonDropDown) frameworkElement).Command == buttonDropDown.Command))
        return true;
    }
    return false;
  }

  protected override void OnContextMenuClosing(ContextMenuEventArgs e)
  {
    this.HandleContextMenuClosing(e);
    base.OnContextMenuClosing(e);
  }

  private void HandleContextMenuClosing(ContextMenuEventArgs e)
  {
    if (e.Source == null || !(e.Source is FrameworkElement))
      return;
    FrameworkElement source = e.Source as FrameworkElement;
    if (!Ribbon.GetIsCustomizableContextSet(source))
      return;
    ContextMenu contextMenu = source.ContextMenu;
    source.ContextMenu = (ContextMenu) null;
  }

  private ContextMenu GetCustomizeContextMenu()
  {
    if (this.FindResource((object) new ComponentResourceKey(typeof (Ribbon), (object) "QatCustomizeContextMenu")) is ContextMenu resource)
    {
      if (resource.Name == "" || resource.Name == null)
      {
        resource.Name = Ribbon.SysQatCustomizeContextMenu;
        foreach (object obj in (IEnumerable) resource.Items)
        {
          if (obj is MenuItem menuItem)
          {
            if ((string) menuItem.Header == Ribbon.SystemAddToQatMenuItem)
            {
              menuItem.Name = Ribbon.SystemAddToQatMenuItem;
              menuItem.Header = (object) this.SystemText.QatAddItemText;
            }
            else if ((string) menuItem.Header == Ribbon.SystemCustomizeQatMenuItem)
            {
              menuItem.Name = Ribbon.SystemCustomizeQatMenuItem;
              menuItem.Header = (object) this.SystemText.QatCustomizeText;
            }
            else if ((string) menuItem.Header == Ribbon.SystemQatChangePlacementMenuItem)
            {
              menuItem.Name = Ribbon.SystemQatChangePlacementMenuItem;
              menuItem.Header = (object) this.SystemText.QatPlaceBelowRibbonText;
            }
            else if ((string) menuItem.Header == Ribbon.SystemQatMinMaxRibbonMenuItem)
            {
              menuItem.Name = Ribbon.SystemQatMinMaxRibbonMenuItem;
              menuItem.Header = (object) this.SystemText.MinimizeRibbonText;
            }
            else if ((string) menuItem.Header == Ribbon.SystemRemoveFromQatMenuItem)
            {
              menuItem.Name = Ribbon.SystemRemoveFromQatMenuItem;
              menuItem.Header = (object) this.SystemText.QatRemoveItemText;
            }
          }
        }
      }
      resource.Closed += new RoutedEventHandler(this.CustomizeContextMenuClosed);
      this.AddMenuItemEventHandlers(resource);
    }
    return resource;
  }

  private void AddMenuItemEventHandlers(ContextMenu cm)
  {
    foreach (object obj in (IEnumerable) cm.Items)
    {
      if (obj is MenuItem menuItem)
      {
        if (menuItem.Name == Ribbon.SystemAddToQatMenuItem)
          menuItem.Click += new RoutedEventHandler(this.ContextMenuAddToQatClick);
        else if (menuItem.Name == Ribbon.SystemCustomizeQatMenuItem)
          menuItem.Click += new RoutedEventHandler(this.ContextMenuCustomizeQatClick);
        else if (menuItem.Name == Ribbon.SystemQatChangePlacementMenuItem)
          menuItem.Click += new RoutedEventHandler(this.ContextMenuQatChangePlacementClick);
        else if (menuItem.Name == Ribbon.SystemQatMinMaxRibbonMenuItem)
          menuItem.Click += new RoutedEventHandler(this.ContextMenuMinMaxRibbonClick);
        else if (menuItem.Name == Ribbon.SystemRemoveFromQatMenuItem)
          menuItem.Click += new RoutedEventHandler(this.ContextMenuRemoveFromQatClick);
      }
    }
  }

  private void CustomizeContextMenuClosed(object sender, RoutedEventArgs e)
  {
    ContextMenu contextMenu = (ContextMenu) sender;
    foreach (object obj in (IEnumerable) contextMenu.Items)
    {
      if (obj is MenuItem menuItem)
      {
        if (menuItem.Name == Ribbon.SystemAddToQatMenuItem)
          menuItem.Click -= new RoutedEventHandler(this.ContextMenuAddToQatClick);
        else if (menuItem.Name == Ribbon.SystemCustomizeQatMenuItem)
          menuItem.Click -= new RoutedEventHandler(this.ContextMenuCustomizeQatClick);
        else if (menuItem.Name == Ribbon.SystemQatChangePlacementMenuItem)
          menuItem.Click -= new RoutedEventHandler(this.ContextMenuQatChangePlacementClick);
        else if (menuItem.Name == Ribbon.SystemQatMinMaxRibbonMenuItem)
          menuItem.Click -= new RoutedEventHandler(this.ContextMenuMinMaxRibbonClick);
        else if (menuItem.Name == Ribbon.SystemRemoveFromQatMenuItem)
          menuItem.Click -= new RoutedEventHandler(this.ContextMenuRemoveFromQatClick);
      }
    }
    contextMenu.Closed -= new RoutedEventHandler(this.CustomizeContextMenuClosed);
  }

  private void ContextMenuRemoveFromQatClick(object sender, RoutedEventArgs e)
  {
    this.RemoveFromQat((object) (((FrameworkElement) sender).Parent as ContextMenu).PlacementTarget);
  }

  private void ContextMenuMinMaxRibbonClick(object sender, RoutedEventArgs e)
  {
    this.ToggleRibbonMinimized();
  }

  private void ContextMenuQatChangePlacementClick(object sender, RoutedEventArgs e)
  {
    this.ChangeQatPlacement();
  }

  private void ContextMenuCustomizeQatClick(object sender, RoutedEventArgs e)
  {
    this.OnQatDialogCustomize();
  }

  private void ContextMenuAddToQatClick(object sender, RoutedEventArgs e)
  {
    this.AddToQat((object) (((FrameworkElement) sender).Parent as ContextMenu).PlacementTarget);
  }

  internal void ToggleRibbonMinimized() => this.IsMinimized = !this.IsMinimized;

  private void ToggleRibbonMinimizeExecuted(object sender, ExecutedRoutedEventArgs e)
  {
    this.ToggleRibbonMinimized();
    e.Handled = true;
  }

  private void ToggleRibbonMinimizeCanExecute(object sender, CanExecuteRoutedEventArgs e)
  {
    e.CanExecute = this.AutoExpand;
    e.Handled = true;
    e.ContinueRouting = false;
  }

  internal void OnQatDialogCustomize()
  {
    this.OnBeforeCustomizeQatDialog(new QatDialogEventArgs(Ribbon.BeforeCustomizeQatDialogEvent, (object) this));
    this.OnAfterCustomizeQatDialog(new QatDialogEventArgs(Ribbon.AfterCustomizeQatDialogEvent, (object) this));
  }

  protected virtual void OnAfterCustomizeQatDialog(QatDialogEventArgs e)
  {
    this.RaiseEvent((RoutedEventArgs) e);
  }

  private void OnBeforeCustomizeQatDialog(QatDialogEventArgs e)
  {
    this.RaiseEvent((RoutedEventArgs) e);
  }

  internal void ChangeQatPlacement()
  {
    this.IsQuickAccessToolbarBelow = !this.IsQuickAccessToolbarBelow;
  }

  [Browsable(false)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public string QuickAccessToolbarLayout
  {
    get => this.GetQatLayoutDescription();
    set => this.SetQatLayoutDescription(value);
  }

  private string GetQatLayoutDescription()
  {
    if (!(this.QuickAccessToolbar is ItemsControl quickAccessToolbar))
      throw new InvalidOperationException("Ribbon.QuickAccessToolbar property must be set to an ItemsControl so layout can be saved.");
    StringBuilder stringBuilder = new StringBuilder();
    if (this.IsQuickAccessToolbarBelow)
      stringBuilder.Append("1");
    else
      stringBuilder.Append("0");
    foreach (object obj in (IEnumerable) quickAccessToolbar.Items)
    {
      FrameworkElement frameworkElement = obj as FrameworkElement;
      if (frameworkElement.Name == "SysQatButton_")
        throw new InvalidOperationException("RibbonBar control was added to Quick Access Toolbar but it did not have unique name set.");
      if (!(frameworkElement.Name != "") || frameworkElement.Name == null)
        throw new InvalidOperationException($"Cannot serialize layout for element of type {obj.GetType().ToString()} becouse Name is not assigned");
      stringBuilder.Append("," + frameworkElement.Name);
    }
    return stringBuilder.ToString();
  }

  private void SetQatLayoutDescription(string layoutDesc)
  {
    switch (layoutDesc)
    {
      case "":
        break;
      case null:
        break;
      default:
        if (!(this.QuickAccessToolbar is ItemsControl quickAccessToolbar))
          throw new InvalidOperationException("Ribbon.QuickAccessToolbar property must be set to an ItemsControl so layout can be loaded.");
        string[] strArray = layoutDesc.Split(',');
        if (strArray.Length == 0)
          break;
        bool flag = strArray[0] == "1";
        List<object> objectList = new List<object>();
        for (int index1 = 1; index1 < strArray.Length; ++index1)
        {
          int index2 = Utility.IndexOfName((IList) quickAccessToolbar.Items, strArray[index1]);
          if (index2 >= 0)
            objectList.Add(quickAccessToolbar.Items[index2]);
          else if (strArray[index1].StartsWith("SysQatButton_"))
          {
            RibbonBar ribbonBar = this.GetRibbonBar(strArray[index1].Substring("SysQatButton_".Length));
            if (ribbonBar != null && Ribbon.GetIsCustomizable((FrameworkElement) ribbonBar))
            {
              object qatItemCopy = this.CreateQatItemCopy((object) ribbonBar);
              if (qatItemCopy != null)
                objectList.Add(qatItemCopy);
            }
          }
          else
          {
            FrameworkElement controlByName = this.FindControlByName(strArray[index1]);
            if (controlByName != null && Ribbon.GetIsCustomizable(controlByName))
            {
              object qatItemCopy = this.CreateQatItemCopy((object) controlByName);
              if (qatItemCopy != null)
                objectList.Add(qatItemCopy);
            }
          }
        }
        if (quickAccessToolbar.Items.Count > 0 && quickAccessToolbar.Items[quickAccessToolbar.Items.Count - 1] is QatCustomizeButton && (objectList.Count == 0 || !(objectList[objectList.Count - 1] is QatCustomizeButton)))
          objectList.Add(quickAccessToolbar.Items[quickAccessToolbar.Items.Count - 1]);
        quickAccessToolbar.Items.Clear();
        foreach (object newItem in objectList)
          quickAccessToolbar.Items.Add(newItem);
        if (this.IsQuickAccessToolbarBelow == flag)
          break;
        this.IsQuickAccessToolbarBelow = flag;
        break;
    }
  }

  private FrameworkElement FindControlByName(string name)
  {
    if (this.ApplicationMenu is DevComponents.WpfRibbon.ApplicationMenu)
    {
      FrameworkElement byName1 = Utility.FindByName((IEnumerable) ((ItemsControl) this.ApplicationMenu).Items, name);
      if (byName1 != null)
        return byName1;
      FrameworkElement byName2 = Utility.FindByName((IEnumerable) ((DevComponents.WpfRibbon.ApplicationMenu) this.ApplicationMenu).AppItems, name);
      if (byName2 != null)
        return byName2;
      FrameworkElement byName3 = Utility.FindByName((IEnumerable) ((DevComponents.WpfRibbon.ApplicationMenu) this.ApplicationMenu).MruItems, name);
      if (byName3 != null)
        return byName3;
    }
    return Utility.FindByName((IEnumerable) this.Items, name);
  }

  private RibbonBar GetRibbonBar(string name)
  {
    foreach (object obj in (IEnumerable) this.Items)
    {
      if (obj is RibbonTab ribbonTab && ribbonTab.Content is Panel content)
      {
        foreach (UIElement child in content.Children)
        {
          if (child is RibbonBar && ((FrameworkElement) child).Name == name)
            return (RibbonBar) child;
        }
      }
    }
    return (RibbonBar) null;
  }

  public object CreateQatItemCopy(object element)
  {
    QatOperationAddEventArgs qe = new QatOperationAddEventArgs(element, Ribbon.BeforeAddToQatEvent, element);
    if (qe.OriginalSource is ButtonDropDown)
      qe.ItemCopy = (object) this.GetButtonDropDownQatCopy((ButtonDropDown) qe.OriginalSource);
    else if (qe.OriginalSource is RibbonBar)
      qe.ItemCopy = (object) this.GetRibbonBarQatCopy((RibbonBar) qe.OriginalSource);
    this.OnBeforeAddToQat(qe);
    if (qe.Cancel)
      return (object) null;
    object itemCopy = qe.ItemCopy;
    if (itemCopy == null)
      throw new InvalidOperationException("QatOperationAddEventArgs.ItemCopy must be set to the copy of the QatOperationAddEventArgs.Item so the copy can be added to QAT");
    if (itemCopy == qe.Item)
      throw new InvalidOperationException("QatOperationAddEventArgs.ItemCopy cannot be same as QatOperationAddEventArgs.Item. It must be set to the copy of the QatOperationAddEventArgs.Item so the copy can be added to QAT");
    return itemCopy;
  }

  public void AddToQat(object element)
  {
    if (!(this.QuickAccessToolbar is ItemsControl quickAccessToolbar))
      throw new InvalidOperationException("Ribbon.QuickAccessToolbar property must be set to an ItemsControl so items can be added.");
    if (this.IsElementOnQat(element as FrameworkElement))
      return;
    object qatItemCopy = this.CreateQatItemCopy(element);
    if (qatItemCopy == null)
      return;
    if (quickAccessToolbar.Items.Count > 0 && quickAccessToolbar.Items[quickAccessToolbar.Items.Count - 1] is QatCustomizeButton)
      quickAccessToolbar.Items.Insert(quickAccessToolbar.Items.Count - 1, qatItemCopy);
    else
      quickAccessToolbar.Items.Add(qatItemCopy);
    this.OnAfterAddToQat(new QatOperationAddEventArgs(element, Ribbon.AfterAddToQatEvent, element)
    {
      ItemCopy = qatItemCopy
    });
  }

  private ButtonDropDown GetRibbonBarQatCopy(RibbonBar ribbonBar)
  {
    ContextMenu contextMenu = ribbonBar.ContextMenu;
    ribbonBar.ContextMenu = (ContextMenu) null;
    RibbonBar newItem = ribbonBar.Copy(true);
    ribbonBar.ContextMenu = contextMenu;
    newItem.Height = ribbonBar.RenderSize.Height;
    ButtonDropDown ribbonBarQatCopy = new ButtonDropDown();
    ribbonBarQatCopy.Name = "SysQatButton_" + newItem.Name;
    ribbonBarQatCopy.ExpandVisibility = eExpandVisibility.Hidden;
    ribbonBarQatCopy.Items.Add((object) newItem);
    ribbonBarQatCopy.PopupType = eDropDownType.Popup;
    ribbonBarQatCopy.Role = eButtonRole.DropDown;
    ribbonBarQatCopy.Header = ribbonBar.Header;
    if (ribbonBar.CollapsedImage != null)
    {
      ribbonBarQatCopy.Image = CloningMachine.GetObjectCopy(ribbonBar.CollapsedImage, false);
      ribbonBarQatCopy.UseSmallImage = true;
      ribbonBarQatCopy.PartVisibility = eButtonPartVisibility.ImageOnly;
    }
    return ribbonBarQatCopy;
  }

  private ButtonDropDown GetButtonDropDownQatCopy(ButtonDropDown b)
  {
    ButtonDropDown buttonDropDownQatCopy = b.Copy(true);
    if (buttonDropDownQatCopy.Role == eButtonRole.MenuItem)
      buttonDropDownQatCopy.Role = eButtonRole.SplitButton;
    bool flag = b.Image != null;
    if (!flag && b.Command != null)
    {
      if (b.Command is IButtonDropDownCommandExtender)
      {
        flag = ((IButtonDropDownCommandExtender) b.Command).ImageSource != null || ((IButtonDropDownCommandExtender) b.Command).ImageSmallSource != null;
      }
      else
      {
        IButtonDropDownCommandExtender exender = RibbonCommandManager.GetExender(b.Command);
        if (exender != null)
          flag = exender.ImageSource != null || exender.ImageSmallSource != null;
      }
    }
    if (flag)
    {
      buttonDropDownQatCopy.PartVisibility = eButtonPartVisibility.ImageOnly;
      if (b.Image is Image && (((UIElement) b.Image).RenderSize.Width > 16.0 || ((UIElement) b.Image).RenderSize.Height > 16.0))
        buttonDropDownQatCopy.UseSmallImage = true;
    }
    if (buttonDropDownQatCopy.IsExpandVisible == Visibility.Visible && buttonDropDownQatCopy.ExpandPosition != eExpandPosition.Right)
      buttonDropDownQatCopy.ExpandPosition = eExpandPosition.Right;
    buttonDropDownQatCopy.ImagePosition = eButtonImagePosition.Left;
    return buttonDropDownQatCopy;
  }

  internal bool CanAddToQat(object element)
  {
    return element is FrameworkElement && this.QuickAccessToolbar is ItemsControl quickAccessToolbar && !quickAccessToolbar.Items.Contains(element) && Ribbon.GetIsCustomizable(element as FrameworkElement);
  }

  protected virtual void OnAfterAddToQat(QatOperationAddEventArgs qe)
  {
    this.RaiseEvent((RoutedEventArgs) qe);
  }

  protected virtual void OnBeforeAddToQat(QatOperationAddEventArgs qe)
  {
    this.RaiseEvent((RoutedEventArgs) qe);
  }

  public void RemoveFromQat(object element)
  {
    if (!(this.QuickAccessToolbar is ItemsControl quickAccessToolbar))
      throw new InvalidOperationException("Ribbon.QuickAccessToolbar property must be set to an ItemsControl so items can be removed.");
    QatOperationEventArgs oe = new QatOperationEventArgs(element, Ribbon.BeforeRemoveFromQatEvent, element);
    oe.Source = (object) this;
    this.OnBeforeRemoveFromQat(oe);
    if (oe.Cancel)
      return;
    quickAccessToolbar.Items.Remove(element);
    this.OnAfterRemoveFromQat(new QatOperationEventArgs(element, Ribbon.AfterRemoveFromQatEvent, element));
  }

  protected virtual void OnAfterRemoveFromQat(QatOperationEventArgs oe)
  {
    this.RaiseEvent((RoutedEventArgs) oe);
  }

  protected virtual void OnBeforeRemoveFromQat(QatOperationEventArgs oe)
  {
    this.RaiseEvent((RoutedEventArgs) oe);
  }

  private bool CanRemoveFromQat(object element)
  {
    return element != null && this.QuickAccessToolbar != null && this.QuickAccessToolbar is ItemsControl && ((ItemsControl) this.QuickAccessToolbar).Items.Contains(element);
  }

  private static void OnAccessKeyPressed(object sender, AccessKeyPressedEventArgs e)
  {
    if (Keyboard.IsKeyDown(Key.LeftAlt) || Keyboard.IsKeyDown(Key.RightAlt))
      return;
    e.Scope = sender;
    e.Handled = true;
  }

  private void SetupEnterMenuMode()
  {
    if ((object) this.m_EnterMenuModeDelegate != null)
      return;
    Type type = typeof (KeyboardNavigation);
    if (!(type.GetProperty("Current", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic).GetValue((object) null, (object[]) null) is KeyboardNavigation keyboardNavigation))
      return;
    new UIPermission(UIPermissionWindow.AllWindows).Assert();
    try
    {
      EventInfo eventInfo = type.GetEvent("EnterMenuMode", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
      Delegate @delegate = Delegate.CreateDelegate(eventInfo.EventHandlerType, (object) this, typeof (Ribbon).GetMethod("xeom", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic));
      object[] parameters = new object[1]
      {
        (object) @delegate
      };
      this.m_EnterMenuModeDelegate = @delegate;
      eventInfo.GetAddMethod(true).Invoke((object) keyboardNavigation, parameters);
    }
    finally
    {
      CodeAccessPermission.RevertAssert();
    }
  }

  internal bool EnterKeyTipsMode()
  {
    if (!(this.SelectedItem is RibbonTab selectedItem))
      return false;
    selectedItem.Focus();
    this.ShowKeyTips = true;
    return true;
  }

  private bool xeom(object sender, EventArgs e)
  {
    Window window = Window.GetWindow((DependencyObject) this);
    if (window != null && !window.IsActive || !this.IsEnabled)
      return false;
    if (Mouse.Captured == null && !this.ShowKeyTips)
    {
      if (this.EnterKeyTipsMode())
        return true;
    }
    else if (this.ShowKeyTips)
      this.RestorePreviousFocus();
    else if (this.ApplicationMenu != null && this.ApplicationMenu is DevComponents.WpfRibbon.ApplicationMenu)
    {
      DevComponents.WpfRibbon.ApplicationMenu applicationMenu = this.ApplicationMenu as DevComponents.WpfRibbon.ApplicationMenu;
      if (applicationMenu.IsPopupOpen)
        applicationMenu.IsPopupOpen = false;
    }
    return false;
  }

  protected override void OnKeyDown(KeyEventArgs e)
  {
    base.OnKeyDown(e);
    if (e.Handled)
      return;
    if (Keyboard.FocusedElement is RibbonTab)
    {
      if (e.Key == Key.Down)
      {
        if (this.SelectedContent != null && this.SelectedContent is RibbonBarPanel)
        {
          RibbonBarPanel selectedContent = (RibbonBarPanel) this.SelectedContent;
          e.Handled = selectedContent.FocusFirstRibbonBar();
          this.ShowKeyTips = false;
        }
      }
      else if (e.Key == Key.Up && this.QuickAccessToolbar is ItemsControl)
      {
        e.Handled = FocusHelpers.FocusFirstChild(this.QuickAccessToolbar as ItemsControl);
        this.ShowKeyTips = false;
      }
    }
    if (e.Key == Key.Left || e.Key == Key.Right || e.Key == Key.Up || e.Key == Key.Tab || e.Key == Key.Back)
      this.ShowKeyTips = false;
    if (e.Key != Key.Escape)
      return;
    if (this.m_KeyTipsAdorner != null && this.m_KeyTipsAdorner.ContextObject != null && this.SelectedItem is RibbonTab)
    {
      this.m_KeyTipsAdorner.ContextObject = (object) null;
      this.m_KeyTipsAdorner.KeyTipsStack = "";
      ((UIElement) this.SelectedItem).Focus();
      e.Handled = true;
    }
    else
    {
      this.RestorePreviousFocus();
      e.Handled = true;
    }
    if (!this.IsMinimized || !this.IsRibbonMenuOpen)
      return;
    this.IsRibbonMenuOpen = false;
  }

  protected override void OnTextInput(TextCompositionEventArgs e)
  {
    base.OnTextInput(e);
    if (e.Handled || this.m_KeyTipsAdorner == null || !this.m_KeyTipsAdorner.ProcessTextInput(e))
      return;
    this.RestorePreviousFocus();
  }

  private UIElement GetElementWithKeyTip(string s)
  {
    if (s == null || s.Length == 0)
      return (UIElement) null;
    s = s.ToUpper();
    foreach (object obj in (IEnumerable) this.Items)
    {
      if (obj is UIElement element && element.IsEnabled && element.IsVisible && Ribbon.GetKeyTip(element) == s)
        return element;
    }
    if (this.ApplicationMenu != null && Ribbon.GetKeyTip(this.ApplicationMenu) == s)
      return this.ApplicationMenu;
    if (this.QuickAccessToolbar is ItemsControl)
    {
      ItemsControl quickAccessToolbar = this.QuickAccessToolbar as ItemsControl;
      int result = 0;
      if (int.TryParse(s, out result))
      {
        for (int index = 0; index < quickAccessToolbar.Items.Count; ++index)
        {
          if (quickAccessToolbar.Items[index] is UIElement elementWithKeyTip && elementWithKeyTip.Visibility == Visibility.Visible && !(elementWithKeyTip is QatCustomizeButton) && index + 1 == result)
            return elementWithKeyTip;
        }
      }
    }
    return (UIElement) null;
  }

  private void RestorePreviousFocus()
  {
    if (this.IsKeyboardFocusWithin)
      Keyboard.Focus((IInputElement) null);
    DependencyObject parent = this.Parent;
    if (parent == null)
      return;
    DependencyObject focusScope = FocusManager.GetFocusScope(parent);
    if (focusScope == null || !this.ContainsElement(FocusManager.GetFocusedElement(focusScope)))
      return;
    FocusManager.SetFocusedElement(focusScope, (IInputElement) null);
  }

  private bool ContainsElement(IInputElement elem)
  {
    if (elem == this)
      return true;
    DependencyObject dependencyObject;
    for (MenuItem container = elem as MenuItem; container != null; container = dependencyObject as MenuItem)
    {
      dependencyObject = container.Parent ?? (DependencyObject) ItemsControl.ItemsControlFromItemContainer((DependencyObject) container);
      if (dependencyObject == this)
        return true;
    }
    return false;
  }

  protected override void OnIsKeyboardFocusWithinChanged(DependencyPropertyChangedEventArgs e)
  {
    if (!(bool) e.NewValue)
      this.ShowKeyTips = false;
    base.OnIsKeyboardFocusWithinChanged(e);
  }

  internal void ShowKeyTipsForContext(RibbonTab contextObject)
  {
    if (this.IsMinimized)
    {
      this.ShowKeyTips = false;
      if (!contextObject.IsSelected)
        contextObject.IsSelected = true;
      if (!contextObject.IsFocused)
        contextObject.Focus();
      if (this.IsMinimized && !this.IsRibbonMenuOpen)
        this.IsRibbonMenuOpen = true;
      RibbonTab selectedItem = this.SelectedItem as RibbonTab;
      KeyTipsAdorner keyTipsAdorner = new KeyTipsAdorner(this.m_PopupBorder.Child);
      keyTipsAdorner.RootControl = (Control) this;
      AdornerLayer.GetAdornerLayer((Visual) this.m_PopupBorder.Child).Add((Adorner) keyTipsAdorner);
      keyTipsAdorner.ContextObject = (object) selectedItem;
      this.m_KeyTipsAdorner = keyTipsAdorner;
    }
    else
    {
      this.ShowKeyTips = true;
      if (!contextObject.IsSelected)
      {
        contextObject.IsSelected = true;
        contextObject.Focus();
        this.UpdateLayout();
      }
      if (this.m_KeyTipsAdorner == null)
        return;
      this.m_KeyTipsAdorner.ContextObject = (object) contextObject;
    }
  }

  internal bool KeyTipsVisible => this.m_ShowKeyTips || this.m_KeyTipsAdorner != null;

  internal bool ShowKeyTips
  {
    get => this.m_ShowKeyTips;
    set
    {
      if (this.m_ShowKeyTips == value && (value || this.m_KeyTipsAdorner == null))
        return;
      this.m_ShowKeyTips = value;
      if (this.m_ShowKeyTips)
      {
        if (!this.IsKeyboardFocusWithin && this.SelectedItem is RibbonTab selectedItem)
          selectedItem.Focus();
        this.m_KeyTipsAdorner = new KeyTipsAdorner((UIElement) this);
        AdornerLayer.GetAdornerLayer((Visual) this).Add((Adorner) this.m_KeyTipsAdorner);
      }
      else
      {
        if (this.m_KeyTipsAdorner.ContextObject is RibbonTab && this.m_KeyTipsAdorner.ContextObject != this.SelectedItem)
        {
          (this.m_KeyTipsAdorner.ContextObject as RibbonTab).UpdateBorderRenderState();
          this.UpdatePanelBorderSelectedTabRect();
        }
        if (this.m_KeyTipsAdorner.Parent is AdornerLayer parent)
          parent.Remove((Adorner) this.m_KeyTipsAdorner);
        this.m_KeyTipsAdorner = (KeyTipsAdorner) null;
      }
      if (!(this.SelectedItem is RibbonTab))
        return;
      ((RibbonTab) this.SelectedItem).UpdateBorderRenderState();
    }
  }

  private void InternalPostProcessInput(object sender, ProcessInputEventArgs e)
  {
    if (!this.IsEnabled || this.Visibility != Visibility.Visible || e.StagingItem.Input.RoutedEvent != TextCompositionManager.TextInputEvent || (Keyboard.Modifiers & ModifierKeys.Alt) == ModifierKeys.None)
      return;
    Window window = Window.GetWindow((DependencyObject) this);
    if (window != null && !window.IsActive)
      return;
    TextCompositionEventArgs input = e.StagingItem.Input as TextCompositionEventArgs;
    if (!(input.SystemText != ""))
      return;
    if (this.m_KeyTipsAdorner != null)
    {
      this.m_KeyTipsAdorner.ProcessTextInput(input);
    }
    else
    {
      UIElement elementWithKeyTip = this.GetElementWithKeyTip(input.SystemText);
      if (elementWithKeyTip == null)
        return;
      this.EnterKeyTipsMode();
      if (this.m_KeyTipsAdorner != null)
      {
        if (elementWithKeyTip is RibbonTab)
          this.ShowKeyTipsForContext(elementWithKeyTip as RibbonTab);
        else if (this.m_KeyTipsAdorner.ExecuteAction(elementWithKeyTip) && this.ShowKeyTips)
          this.ShowKeyTips = false;
      }
      input.Handled = true;
    }
  }

  private Key GetKey(KeyEventArgs e) => e.Key != Key.System ? e.Key : e.SystemKey;

  public void ChangeColorScheme(eRibbonVisualStyle colorTable)
  {
    this.MergeDictionary(Ribbon.GetColorTable(colorTable));
  }

  public void ChangeColorScheme(eRibbonVisualStyle baseColorTable, Color baseColor)
  {
    if (Application.Current == null)
      return;
    this.MergeDictionary(this.CreateColorScheme(baseColorTable, baseColor));
  }

  public ResourceDictionary CreateColorScheme(eRibbonVisualStyle baseColorTable, Color baseColor)
  {
    return Ribbon.CreateColorScheme(Ribbon.GetColorTable(baseColorTable), baseColor);
  }

  public static ResourceDictionary CreateColorSchemeResourceDictionary(
    eRibbonVisualStyle baseColorTable,
    Color baseColor)
  {
    return Ribbon.CreateColorScheme(Ribbon.GetColorTable(baseColorTable), baseColor);
  }

  private void MergeDictionary(ResourceDictionary rd)
  {
    ResourceDictionary resourceDictionary = Application.Current == null || this.IsDesignMode ? this.Resources : Application.Current.Resources;
    foreach (ResourceDictionary mergedDictionary in resourceDictionary.MergedDictionaries)
    {
      switch (mergedDictionary)
      {
        case BlackSkin _:
        case BlueSkin _:
        case GraySkin _:
        case Office2010SilverColorScheme _:
        case PoliceSkin _:
        case MilitarySkin _:
        case FiremanSkin _:
        case FullColorSkin _:
          resourceDictionary.MergedDictionaries.Remove(mergedDictionary);
          goto label_8;
        default:
          continue;
      }
    }
label_8:
    resourceDictionary.MergedDictionaries.Add(rd);
  }

  public static void SetColorScheme(eRibbonVisualStyle colorTable)
  {
    if (Application.Current == null)
      return;
    Ribbon.MergeStaticDictionary(Ribbon.GetColorTable(colorTable));
  }

  public static void SetColorScheme(eRibbonVisualStyle baseColorTable, Color baseColor)
  {
    if (Application.Current == null)
      return;
    Ribbon.MergeStaticDictionary(Ribbon.CreateColorScheme(Ribbon.GetColorTable(baseColorTable), baseColor));
  }

  private static void MergeStaticDictionary(ResourceDictionary rd)
  {
    if (Application.Current == null)
      return;
    ResourceDictionary resources = Application.Current.Resources;
    foreach (ResourceDictionary mergedDictionary in resources.MergedDictionaries)
    {
      switch (mergedDictionary)
      {
        case BlackSkin _:
        case BlueSkin _:
        case GraySkin _:
        case Office2010SilverColorScheme _:
        case PoliceSkin _:
        case MilitarySkin _:
        case FiremanSkin _:
        case FullColorSkin _:
          resources.MergedDictionaries.Remove(mergedDictionary);
          goto label_10;
        default:
          continue;
      }
    }
label_10:
    resources.MergedDictionaries.Add(rd);
  }

  private static ResourceDictionary GetColorTable(eRibbonVisualStyle colorTable)
  {
    switch (colorTable)
    {
      case eRibbonVisualStyle.Office2007Blue:
        return (ResourceDictionary) new BlueSkin();
      case eRibbonVisualStyle.Office2007Silver:
        return (ResourceDictionary) new GraySkin();
      case eRibbonVisualStyle.Office2007Black:
        return (ResourceDictionary) new BlackSkin();
      case eRibbonVisualStyle.Office2007Classic:
        return (ResourceDictionary) new ClassicSkin();
      case eRibbonVisualStyle.Office2007Police:
        return (ResourceDictionary) new PoliceSkin();
      case eRibbonVisualStyle.Office2007Military:
        return (ResourceDictionary) new MilitarySkin();
      case eRibbonVisualStyle.Office2007Fireman:
        return (ResourceDictionary) new FiremanSkin();
      case eRibbonVisualStyle.Office2007FullColor:
        return (ResourceDictionary) new FullColorSkin();
      case eRibbonVisualStyle.Office2010Silver:
        return (ResourceDictionary) new Office2010SilverColorScheme();
      case eRibbonVisualStyle.Office2010Blue:
        return (ResourceDictionary) new Office2010BlueColorScheme();
      case eRibbonVisualStyle.Office2010Black:
        return (ResourceDictionary) new Office2010BlackColorScheme();
      default:
        throw new InvalidEnumArgumentException("Color table not not recognized");
    }
  }

  private static ResourceDictionary CreateColorScheme(ResourceDictionary rd, Color baseColor)
  {
    ColorFactory colorFactory = Ribbon.GetColorFactory(baseColor);
    foreach (object key in (IEnumerable) rd.Keys)
    {
      if (key is ComponentResourceKey)
      {
        string str = (key as ComponentResourceKey).ResourceId.ToString();
        if (str.StartsWith(RibbonColors.ButtonClass) && !str.StartsWith(RibbonColors.ButtonWithBackgroundClass))
          continue;
      }
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
    return rd;
  }

  private static ColorFactory GetColorFactory(Color baseColor)
  {
    return (ColorFactory) new ColorBlendFactory(baseColor);
  }

  private static void OnButtonDropDownCheckedClick(object sender, RoutedEventArgs e)
  {
    Ribbon ribbon = (Ribbon) sender;
    if (e.Source is ButtonDropDown)
    {
      ribbon.SyncChecked(e.Source as ButtonDropDown);
    }
    else
    {
      if (!(e.OriginalSource is ButtonDropDown))
        return;
      ribbon.SyncChecked(e.OriginalSource as ButtonDropDown);
    }
  }

  private static void OnButtonDropDownUnCheckedClick(object sender, RoutedEventArgs e)
  {
    ((Ribbon) sender).SyncChecked(e.Source as ButtonDropDown);
  }

  private void SyncChecked(ButtonDropDown button)
  {
    if (button == null || button.Name == "" || !this.IsElementOnQat((FrameworkElement) button) || button.Command is ButtonDropDownCommand)
      return;
    foreach (ButtonDropDown allInstance in this.GetAllInstances(button.Name))
    {
      if (allInstance != button)
        allInstance.IsChecked = button.IsChecked;
    }
  }

  public List<ButtonDropDown> GetAllInstances(string name)
  {
    List<ButtonDropDown> list = new List<ButtonDropDown>();
    if (name.Length == 0)
      return list;
    if (this.QuickAccessToolbar is ItemsControl quickAccessToolbar)
      this.FindAllInstances(quickAccessToolbar, name, list);
    this.FindAllInstances((ItemsControl) this, name, list);
    return list;
  }

  private void FindAllInstances(ItemsControl ic, string name, List<ButtonDropDown> list)
  {
    foreach (object obj in (IEnumerable) ic.Items)
    {
      switch (obj)
      {
        case ButtonDropDown buttonDropDown:
          if (buttonDropDown.Name == name)
          {
            list.Add(buttonDropDown);
            continue;
          }
          if (buttonDropDown.Name.StartsWith("SysQatButton_") && buttonDropDown.Items.Count > 0 && buttonDropDown.Items[0] is RibbonBar)
          {
            this.FindAllInstances((ItemsControl) (buttonDropDown.Items[0] as RibbonBar), name, list);
            continue;
          }
          continue;
        case ItemsControl _:
          this.FindAllInstances(obj as ItemsControl, name, list);
          continue;
        case Panel _:
          this.FindAllInstances(obj as Panel, name, list);
          continue;
        default:
          continue;
      }
    }
  }

  private void FindAllInstances(Panel p, string name, List<ButtonDropDown> list)
  {
    foreach (UIElement child in p.Children)
    {
      switch (child)
      {
        case ButtonDropDown buttonDropDown when buttonDropDown.Name == name:
          list.Add(buttonDropDown);
          continue;
        case ItemsControl _:
          this.FindAllInstances(child as ItemsControl, name, list);
          continue;
        case Panel _:
          this.FindAllInstances(child as Panel, name, list);
          continue;
        default:
          continue;
      }
    }
  }

  internal static bool IsLivePreviewActive => Ribbon._IsLivePreviewActive;

  internal static void SetIsLivePreviewActive(FrameworkElement elem, bool active)
  {
    if (Ribbon._IsLivePreviewActive == active)
      return;
    Ribbon._IsLivePreviewActive = active;
    if (elem == null)
      return;
    if (Ribbon._IsLivePreviewActive)
      elem.RaiseEvent(new RoutedEventArgs(Ribbon.EnterLivePreviewEvent, (object) elem));
    else
      elem.RaiseEvent(new RoutedEventArgs(Ribbon.ExitLivePreviewEvent, (object) elem));
  }

  public static bool PopupAllowsTransparency => Ribbon._PopupAllowsTransparency;

  private static void OnPopupIsSelectedChanged(
    object sender,
    RoutedPropertyChangedEventArgs<bool> e)
  {
    ((Ribbon) sender)?.OnSelectedChanged(sender, e);
  }

  private void OnSelectedChanged(object sender, RoutedPropertyChangedEventArgs<bool> e)
  {
    this.m_PopupHandler.OnIsSelectedChanged(sender, e);
  }

  private static void OnButtonDropDownPreviewClick(object sender, RoutedEventArgs e)
  {
    ParentPopupControlImpl.OnButtonDropDownPreviewClick(sender, e);
  }

  private static void OnMouseButtonDown(object sender, MouseButtonEventArgs e)
  {
    ((Ribbon) sender).InternalMouseButtonDown(e);
  }

  protected virtual void InternalMouseButtonDown(MouseButtonEventArgs e)
  {
    if (this.ShowKeyTips)
      this.ShowKeyTips = false;
    this.m_PopupHandler.ClosePopupOnMouseEvent(e);
  }

  private static void OnPreviewMouseButtonDown(object sender, MouseButtonEventArgs e)
  {
    ((Ribbon) sender).InternalPreviewMouseButtonDown(e);
  }

  private void InternalPreviewMouseButtonDown(MouseButtonEventArgs e)
  {
    if (this.ApplicationMenu is DevComponents.WpfRibbon.ApplicationMenu)
    {
      DevComponents.WpfRibbon.ApplicationMenu applicationMenu = this.ApplicationMenu as DevComponents.WpfRibbon.ApplicationMenu;
      if (applicationMenu.IsPopupOpen && !applicationMenu.BackstageUsesPopup && applicationMenu.IsBackstageActive && !new Rect(applicationMenu.RenderSize).Contains(e.GetPosition((IInputElement) applicationMenu)))
      {
        bool flag = true;
        if (this.HasCaption && this.m_RibbonContentPanel != null && this.m_RibbonContentPanel.BackgroundChrome != null && new Rect(0.0, 0.0, this.RenderSize.Width, this.m_RibbonContentPanel.BackgroundChrome.TotalTitleChromeHeight).Contains(e.GetPosition((IInputElement) this)))
          flag = false;
        if (flag && e.Source is ButtonDropDown && ((FrameworkElement) e.Source).Parent is ButtonDropDown)
          flag = false;
        if (flag)
          applicationMenu.IsPopupOpen = false;
      }
    }
    if (this.IsRibbonMenuOpen && this.m_PopupBorder != null && e.OriginalSource is DependencyObject dependencyObject)
    {
      for (; dependencyObject != null; dependencyObject = !(dependencyObject is Visual) ? LogicalTreeHelper.GetParent(dependencyObject) : VisualTreeHelper.GetParent(dependencyObject))
      {
        if (dependencyObject == this.m_PopupBorder.Child || dependencyObject is Popup || dependencyObject == this.m_PopupHandler.CurrentSelection || dependencyObject.GetType().ToString().Contains("PopupRoot"))
          return;
      }
      this.IsRibbonMenuOpen = false;
    }
    if (!this.ShowKeyTips)
      return;
    this.ShowKeyTips = false;
  }

  private static void OnMouseButtonUp(object sender, MouseButtonEventArgs e)
  {
    ((Ribbon) sender).InternalMouseButtonUp(e);
  }

  protected virtual void InternalMouseButtonUp(MouseButtonEventArgs e)
  {
    if (this.ApplicationMenu is DevComponents.WpfRibbon.ApplicationMenu)
    {
      DevComponents.WpfRibbon.ApplicationMenu applicationMenu = this.ApplicationMenu as DevComponents.WpfRibbon.ApplicationMenu;
      System.Windows.Point position = e.GetPosition((IInputElement) applicationMenu);
      if (new Rect(applicationMenu.RenderSize).Contains(position) && applicationMenu.IsPopupOpen)
        return;
    }
    this.m_PopupHandler.ClosePopupOnMouseEvent(e);
  }

  private static void OnLostMouseCapture(object sender, MouseEventArgs e)
  {
    ParentPopupControlImpl.OnLostMouseCapture(sender, e);
  }

  bool IPopupParentControl.IsPopupMode
  {
    get => this.m_PopupHandler.IsPopupMode;
    set
    {
      this.m_PopupHandler.IsPopupMode = value;
      if (value || !this.IsRibbonMenuOpen)
        return;
      this.IsRibbonMenuOpen = false;
    }
  }

  private void PopupHandlerInternalMenuModeChanged(object sender, EventArgs e)
  {
    if (this.m_PopupHandler.IsPopupMode || !this.IsRibbonMenuOpen)
      return;
    this.IsRibbonMenuOpen = false;
  }

  internal static void ShowKeyboardCues(DependencyObject obj, bool value)
  {
    if (Ribbon.s_ShowKeyboardCues == (FieldInfo) null)
      Ribbon.s_ShowKeyboardCues = typeof (KeyboardNavigation).GetField("ShowKeyboardCuesProperty", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);
    if (!(Ribbon.s_ShowKeyboardCues != (FieldInfo) null) || obj == null)
      return;
    DependencyProperty dp = Ribbon.s_ShowKeyboardCues.GetValue((object) null) as DependencyProperty;
    obj.SetValue(dp, (object) true);
  }

  bool IPopupParentControl.QueryMouseCapturePopupClose(DependencyObject sourceObject) => true;
}
