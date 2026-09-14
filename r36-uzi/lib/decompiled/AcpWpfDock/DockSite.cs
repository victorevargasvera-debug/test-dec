// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfDock.DockSite
// Assembly: AcpWpfDock, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 89CC52D3-0487-4106-AFAE-BE4A13C8A50E
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfDock.dll

using DevComponents.WpfDock.Primitives;
using DevComponents.WpfDock.themes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Animation;

#nullable disable
namespace DevComponents.WpfDock;

public class DockSite : ContentControl
{
  public static readonly DependencyProperty MinimumDocumentAreaSizeProperty = DependencyProperty.Register(nameof (MinimumDocumentAreaSize), typeof (Size), typeof (DockSite), (PropertyMetadata) new UIPropertyMetadata((object) new Size(32.0, 32.0)));
  public static readonly DependencyProperty VisualStyleProperty = DependencyProperty.RegisterAttached(nameof (VisualStyle), typeof (eDockVisualStyle), typeof (DockSite), (PropertyMetadata) new FrameworkPropertyMetadata((object) eDockVisualStyle.Office2007Blue, FrameworkPropertyMetadataOptions.Inherits, new PropertyChangedCallback(DockSite.OnVisualStyleChanged)));
  private static readonly DependencyPropertyKey EffectiveStylePropertyKey = DependencyProperty.RegisterReadOnly(nameof (EffectiveStyle), typeof (eEffectiveDockVisualStyle), typeof (DockSite), (PropertyMetadata) new UIPropertyMetadata((object) eEffectiveDockVisualStyle.Office2007, new PropertyChangedCallback(DockSite.OnEffectiveStyleChanged)));
  public static readonly DependencyProperty EffectiveStyleProperty = DockSite.EffectiveStylePropertyKey.DependencyProperty;
  public static readonly DependencyProperty KeyboardNavigationEnabledProperty = DependencyProperty.Register(nameof (KeyboardNavigationEnabled), typeof (bool), typeof (DockSite), (PropertyMetadata) new UIPropertyMetadata((object) true));
  public static readonly DependencyProperty DockProperty;
  public static readonly DependencyProperty IsDocumentProperty;
  public static readonly DependencyProperty SaveLayoutProperty;
  public static readonly DependencyProperty DockSizeProperty;
  private static readonly DependencyPropertyKey SplitPanelsPropertyKey;
  public static readonly DependencyProperty SplitPanelsProperty;
  private static readonly DependencyPropertyKey ActiveDockWindowPropertyKey;
  public static readonly DependencyProperty ActiveDockWindowProperty;
  public static readonly RoutedEvent DockChangedEvent;
  public static readonly RoutedEvent BeforeDockingStartsEvent;
  public static readonly RoutedEvent BeforeDockedEvent;
  public static readonly RoutedEvent AfterDockedEvent;
  public static readonly DependencyProperty LicenseKeyProperty;
  public static readonly DependencyProperty DockHintOverlayProperty;
  public static readonly DependencyProperty DockSelectorOverlayProperty;
  public static readonly RoutedEvent IsDocumentChangedEvent;
  public static readonly DependencyProperty AutoHidePopupOverlayProperty = DependencyProperty.Register(nameof (AutoHidePopupOverlay), typeof (bool), typeof (DockSite), (PropertyMetadata) new UIPropertyMetadata((object) false));
  public static readonly DependencyProperty SelectorCycleAllWindowsProperty = DependencyProperty.Register(nameof (SelectorCycleAllWindows), typeof (bool), typeof (DockSite), (PropertyMetadata) new UIPropertyMetadata((object) false));
  public static readonly DependencyProperty IsAnimationEnabledProperty = DependencyProperty.Register(nameof (IsAnimationEnabled), typeof (bool), typeof (DockSite), (PropertyMetadata) new UIPropertyMetadata((object) true));
  private UIElementCollection m_Children;
  private Rect m_DocumentRect;
  private bool m_IsDockingInProgress;
  private DragWindow m_DragWindow;
  private DockWindowGroup m_DragDockWindowGroup;
  private bool m_DragSelectedTabOnly;
  private DockSiteAdorner m_DockHintAdorner;
  private AutoHideAdorner m_AutoHideAdorner;
  private UIElement m_DockMouseOverElement;
  private DockSite.DockPositionInfo m_CurrentDockPosition;
  private AutoHidePanel m_LeftAutoHidePanel;
  private AutoHidePanel m_RightAutoHidePanel;
  private AutoHidePanel m_TopAutoHidePanel;
  private AutoHidePanel m_BottomAutoHidePanel;
  private IDockSiteLayoutSerializer m_LayoutSerializer;
  private const int FadeInDockDuration = 350;
  private List<FloatingWindow> m_FloatingWindows = new List<FloatingWindow>();
  private DockLocalization m_SystemText = new DockLocalization();
  private DockSelectorAdorner m_DockSelectorAdorner;
  private IDockOperations m_DockOperations;
  private DockSiteOverlayWindow m_DockHintWindow;
  private DockSiteOverlayWindow m_DockSelectorWindow;
  private bool _IgnoreLoadLayoutElementNotFoundErrors;
  private bool _DockWindowDragInitializing;
  private bool _InternalAnimationDisabled;
  private bool _ParentWindowMoveHandler;
  private List<Popup> _AutoHidePopupWindows = new List<Popup>();

  public Size MinimumDocumentAreaSize
  {
    get => (Size) this.GetValue(DockSite.MinimumDocumentAreaSizeProperty);
    set => this.SetValue(DockSite.MinimumDocumentAreaSizeProperty, (object) value);
  }

  public static eDockVisualStyle GetVisualStyle(DependencyObject target)
  {
    return (eDockVisualStyle) target.GetValue(DockSite.VisualStyleProperty);
  }

  public static void SetVisualStyle(DependencyObject target, eDockVisualStyle value)
  {
    target.SetValue(DockSite.VisualStyleProperty, (object) value);
  }

  private static void OnVisualStyleChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
  {
    DockSite.OnVisualStyleChanged(o, (eDockVisualStyle) e.OldValue, (eDockVisualStyle) e.NewValue);
  }

  private static void OnVisualStyleChanged(
    DependencyObject o,
    eDockVisualStyle oldValue,
    eDockVisualStyle newValue)
  {
    if (!(o is DockSite))
      return;
    DockSite dockSite = (DockSite) o;
    dockSite.ChangeColorScheme(newValue);
    if (newValue == eDockVisualStyle.Office2010Silver || newValue == eDockVisualStyle.Office2010Blue || newValue == eDockVisualStyle.Office2010Black)
      dockSite.EffectiveStyle = eEffectiveDockVisualStyle.Office2010;
    else
      dockSite.EffectiveStyle = eEffectiveDockVisualStyle.Office2007;
  }

  public eDockVisualStyle VisualStyle
  {
    get => DockSite.GetVisualStyle((DependencyObject) this);
    set => DockSite.SetVisualStyle((DependencyObject) this, value);
  }

  public eEffectiveDockVisualStyle EffectiveStyle
  {
    get => (eEffectiveDockVisualStyle) this.GetValue(DockSite.EffectiveStyleProperty);
    internal set => this.SetValue(DockSite.EffectiveStylePropertyKey, (object) value);
  }

  private static void OnEffectiveStyleChanged(
    DependencyObject o,
    DependencyPropertyChangedEventArgs e)
  {
    if (!(o is DockSite dockSite))
      return;
    dockSite.OnEffectiveStyleChanged((eEffectiveDockVisualStyle) e.OldValue, (eEffectiveDockVisualStyle) e.NewValue);
  }

  protected virtual void OnEffectiveStyleChanged(
    eEffectiveDockVisualStyle oldValue,
    eEffectiveDockVisualStyle newValue)
  {
  }

  public bool KeyboardNavigationEnabled
  {
    get => (bool) this.GetValue(DockSite.KeyboardNavigationEnabledProperty);
    set => this.SetValue(DockSite.KeyboardNavigationEnabledProperty, (object) value);
  }

  public bool AutoHidePopupOverlay
  {
    get => (bool) this.GetValue(DockSite.AutoHidePopupOverlayProperty);
    set => this.SetValue(DockSite.AutoHidePopupOverlayProperty, (object) value);
  }

  [DefaultValue(false)]
  public bool SelectorCycleAllWindows
  {
    get => (bool) this.GetValue(DockSite.SelectorCycleAllWindowsProperty);
    set => this.SetValue(DockSite.SelectorCycleAllWindowsProperty, (object) value);
  }

  [Category("Behavior")]
  [Description("Indicates whether animation between states of the control is enabled")]
  public bool IsAnimationEnabled
  {
    get => (bool) this.GetValue(DockSite.IsAnimationEnabledProperty);
    set => this.SetValue(DockSite.IsAnimationEnabledProperty, (object) value);
  }

  static DockSite()
  {
    DockSite.DockProperty = DependencyProperty.RegisterAttached("Dock", typeof (Dock), typeof (DockSite), new PropertyMetadata((object) Dock.Left, new PropertyChangedCallback(DockSite.OnDockChanged)));
    DockSite.DockSizeProperty = DependencyProperty.RegisterAttached("DockSize", typeof (double), typeof (DockSite), new PropertyMetadata((object) 100.0, new PropertyChangedCallback(DockSite.DockSizeChanged)));
    DockSite.SplitPanelsPropertyKey = DependencyProperty.RegisterReadOnly(nameof (SplitPanels), typeof (SplitPanelCollection), typeof (DockSite), (PropertyMetadata) new FrameworkPropertyMetadata((object) new SplitPanelCollection()));
    DockSite.SplitPanelsProperty = DockSite.SplitPanelsPropertyKey.DependencyProperty;
    DockSite.IsDocumentProperty = DependencyProperty.RegisterAttached("IsDocument", typeof (bool), typeof (DockSite), new PropertyMetadata((object) false, new PropertyChangedCallback(DockSite.OnDocumentPropertyChanged)));
    DockSite.SaveLayoutProperty = DependencyProperty.RegisterAttached("SaveLayout", typeof (bool), typeof (DockSite), new PropertyMetadata((object) true));
    DockSite.ActiveDockWindowPropertyKey = DependencyProperty.RegisterReadOnly(nameof (ActiveDockWindow), typeof (DevComponents.WpfDock.DockWindow), typeof (DockSite), (PropertyMetadata) new FrameworkPropertyMetadata((PropertyChangedCallback) null));
    DockSite.ActiveDockWindowProperty = DockSite.ActiveDockWindowPropertyKey.DependencyProperty;
    DockSite.DockChangedEvent = EventManager.RegisterRoutedEvent("DockChanged", RoutingStrategy.Direct, typeof (RoutedEventHandler), typeof (DockSite));
    DockSite.BeforeDockingStartsEvent = EventManager.RegisterRoutedEvent("BeforeDockingStarts", RoutingStrategy.Direct, typeof (DockRoutedEventHandler), typeof (DockSite));
    DockSite.BeforeDockedEvent = EventManager.RegisterRoutedEvent("BeforeDocked", RoutingStrategy.Direct, typeof (BeforeDockedRoutedEventHandler), typeof (DockSite));
    DockSite.AfterDockedEvent = EventManager.RegisterRoutedEvent("AfterDocked", RoutingStrategy.Direct, typeof (DockRoutedEventHandler), typeof (DockSite));
    DockSite.IsDocumentChangedEvent = EventManager.RegisterRoutedEvent("IsDocumentChanged", RoutingStrategy.Bubble, typeof (RoutedEventHandler), typeof (DockSite));
    DockSite.LicenseKeyProperty = DependencyProperty.Register(nameof (LicenseKey), typeof (string), typeof (DockSite), (PropertyMetadata) new FrameworkPropertyMetadata((object) "", new PropertyChangedCallback(DockSite.OnLicenseKeyChanged)));
    EventManager.RegisterClassHandler(typeof (DockSite), DevComponents.WpfDock.DockWindow.ActivatedEvent, (Delegate) new RoutedEventHandler(DockSite.DockWindowActivated));
    EventManager.RegisterClassHandler(typeof (DockSite), DevComponents.WpfDock.DockWindow.DeactivatedEvent, (Delegate) new RoutedEventHandler(DockSite.DockWindowDeactivated));
    DockSite.DockHintOverlayProperty = DependencyProperty.Register(nameof (DockHintOverlay), typeof (bool), typeof (DockSite), (PropertyMetadata) new FrameworkPropertyMetadata((object) false, new PropertyChangedCallback(DockSite.OnDockHintOverlayChanged)));
    DockSite.DockSelectorOverlayProperty = DependencyProperty.Register(nameof (DockSelectorOverlay), typeof (bool), typeof (DockSite), (PropertyMetadata) new FrameworkPropertyMetadata((object) false, new PropertyChangedCallback(DockSite.OnDockSelectorOverlayChanged)));
  }

  public DockSite()
  {
    this.SetValue(DockSite.SplitPanelsPropertyKey, (object) new SplitPanelCollection(this));
    this.m_Children = new UIElementCollection((UIElement) this, (FrameworkElement) this);
    this.Unloaded += new RoutedEventHandler(this.DockSiteUnloaded);
  }

  private static void OnDockHintOverlayChanged(
    DependencyObject o,
    DependencyPropertyChangedEventArgs e)
  {
    if (!(o is DockSite dockSite))
      return;
    dockSite.OnDockHintOverlayChanged((bool) e.OldValue, (bool) e.NewValue);
  }

  private static void OnDockSelectorOverlayChanged(
    DependencyObject o,
    DependencyPropertyChangedEventArgs e)
  {
    if (!(o is DockSite dockSite))
      return;
    dockSite.OnDockSelectorOverlayChanged((bool) e.OldValue, (bool) e.NewValue);
  }

  protected virtual void OnDockHintOverlayChanged(bool oldValue, bool newValue)
  {
    if (!newValue)
    {
      if (this.m_DockHintWindow == null)
        return;
      this.m_DockHintWindow.Close();
      this.m_DockHintWindow = (DockSiteOverlayWindow) null;
    }
    else
      this.m_DockHintWindow = new DockSiteOverlayWindow();
  }

  protected virtual void OnDockSelectorOverlayChanged(bool oldValue, bool newValue)
  {
    if (newValue || this.m_DockSelectorWindow == null)
      return;
    this.m_DockSelectorWindow.Close();
    this.m_DockSelectorWindow = (DockSiteOverlayWindow) null;
  }

  [DefaultValue(false)]
  [Description("Indicates whether docking hint overlay is used to display the docking hints. Set to true so dock hints overlay windows forms controls")]
  public bool DockHintOverlay
  {
    get => (bool) this.GetValue(DockSite.DockHintOverlayProperty);
    set => this.SetValue(DockSite.DockHintOverlayProperty, (object) value);
  }

  [DefaultValue(false)]
  [Description("Indicates whether a translucent overlay window is used to display the dock selector. Set to true so dock hints overlay windows forms controls")]
  public bool DockSelectorOverlay
  {
    get => (bool) this.GetValue(DockSite.DockSelectorOverlayProperty);
    set => this.SetValue(DockSite.DockSelectorOverlayProperty, (object) value);
  }

  [DefaultValue(false)]
  [Browsable(false)]
  public bool IgnoreLoadLayoutElementNotFoundErrors
  {
    get => this._IgnoreLoadLayoutElementNotFoundErrors;
    set => this._IgnoreLoadLayoutElementNotFoundErrors = value;
  }

  private void DockSiteUnloaded(object sender, RoutedEventArgs e)
  {
    if (this.m_DockHintWindow != null)
    {
      this.m_DockHintWindow.Close();
      this.m_DockHintWindow = (DockSiteOverlayWindow) null;
    }
    if (this.m_DockSelectorWindow != null)
    {
      this.m_DockSelectorWindow.Close();
      this.m_DockSelectorWindow = (DockSiteOverlayWindow) null;
    }
    if (this.m_DragWindow == null)
      return;
    this.m_DragWindow.Close();
    this.m_DragWindow.KeyDown -= new KeyEventHandler(this.DragWindowKeyDown);
    this.m_DragWindow = (DragWindow) null;
  }

  public event RoutedEventHandler DockChanged
  {
    add => this.AddHandler(DockSite.DockChangedEvent, (Delegate) value);
    remove => this.RemoveHandler(DockSite.DockChangedEvent, (Delegate) value);
  }

  public event RoutedEventHandler IsDocumentChanged
  {
    add => this.AddHandler(DockSite.IsDocumentChangedEvent, (Delegate) value);
    remove => this.RemoveHandler(DockSite.IsDocumentChangedEvent, (Delegate) value);
  }

  public event DockRoutedEventHandler BeforeDockingStarts
  {
    add => this.AddHandler(DockSite.BeforeDockingStartsEvent, (Delegate) value);
    remove => this.RemoveHandler(DockSite.BeforeDockingStartsEvent, (Delegate) value);
  }

  public event BeforeDockedRoutedEventHandler BeforeDocked
  {
    add => this.AddHandler(DockSite.BeforeDockedEvent, (Delegate) value);
    remove => this.RemoveHandler(DockSite.BeforeDockedEvent, (Delegate) value);
  }

  public event DockRoutedEventHandler AfterDocked
  {
    add => this.AddHandler(DockSite.AfterDockedEvent, (Delegate) value);
    remove => this.RemoveHandler(DockSite.AfterDockedEvent, (Delegate) value);
  }

  protected override void OnInitialized(EventArgs e)
  {
    this.CommandBindings.Add(new CommandBinding((ICommand) DevComponents.WpfDock.DockWindow.ToggleAutoHide, new ExecutedRoutedEventHandler(this.ExecuteToggleAutoHide), new CanExecuteRoutedEventHandler(this.CanExecuteToggleAutoHide)));
    this.CommandBindings.Add(new CommandBinding((ICommand) DevComponents.WpfDock.DockWindow.OpenAutoHide, new ExecutedRoutedEventHandler(this.ExecuteOpenAutoHide), new CanExecuteRoutedEventHandler(this.CanExecuteOpenAutoHide)));
    this.CommandBindings.Add(new CommandBinding((ICommand) DevComponents.WpfDock.DockWindow.CloseAutoHide, new ExecutedRoutedEventHandler(this.ExecuteCloseAutoHide), new CanExecuteRoutedEventHandler(this.CanExecuteCloseAutoHide)));
    this.CommandBindings.Add(new CommandBinding((ICommand) DevComponents.WpfDock.DockWindow.CloseWindow, new ExecutedRoutedEventHandler(this.ExecuteCloseWindow), new CanExecuteRoutedEventHandler(this.CanExecuteCloseWindow)));
    this.CommandBindings.Add(new CommandBinding((ICommand) DevComponents.WpfDock.DockWindow.ReDockWindow, new ExecutedRoutedEventHandler(this.ExecuteReDockWindow), new CanExecuteRoutedEventHandler(this.CanExecuteReDockWindow)));
    this.CommandBindings.Add(new CommandBinding((ICommand) DevComponents.WpfDock.DockWindow.FloatWindow, new ExecutedRoutedEventHandler(this.ExecuteFloatWindow), new CanExecuteRoutedEventHandler(this.CanExecuteFloatWindow)));
    this.CommandBindings.Add(new CommandBinding((ICommand) DevComponents.WpfDock.DockWindow.DockAsDocumentWindow, new ExecutedRoutedEventHandler(this.ExecuteDockAsDocumentWindow), new CanExecuteRoutedEventHandler(this.CanExecuteDockAsDocumentWindow)));
    this.CommandBindings.Add(new CommandBinding((ICommand) DevComponents.WpfDock.DockWindow.SelectWindow, new ExecutedRoutedEventHandler(this.ExecuteSelectWindow), new CanExecuteRoutedEventHandler(this.CanExecuteSelectWindow)));
    base.OnInitialized(e);
  }

  protected override Size MeasureOverride(Size constraint)
  {
    return this.MeasureArrange(constraint, false);
  }

  protected override Size ArrangeOverride(Size arrangeBounds)
  {
    return !WinApi.KeyValidated ? arrangeBounds : this.MeasureArrange(arrangeBounds, true);
  }

  private Size MeasureArrange(Size arrangeBounds, bool isArrange)
  {
    Rect finalRect1 = new Rect(arrangeBounds);
    Size desiredSize1;
    if (this.m_TopAutoHidePanel != null)
    {
      if (isArrange)
      {
        AutoHidePanel topAutoHidePanel = this.m_TopAutoHidePanel;
        double x = finalRect1.X;
        double y = finalRect1.Y;
        double width = finalRect1.Width;
        desiredSize1 = this.m_TopAutoHidePanel.DesiredSize;
        double height = desiredSize1.Height;
        Rect finalRect2 = new Rect(x, y, width, height);
        topAutoHidePanel.Arrange(finalRect2);
      }
      else
        this.m_TopAutoHidePanel.Measure(finalRect1.Size);
      ref Rect local1 = ref finalRect1;
      double height1 = finalRect1.Height;
      desiredSize1 = this.m_TopAutoHidePanel.DesiredSize;
      double height2 = desiredSize1.Height;
      double num = Math.Max(0.0, height1 - height2);
      local1.Height = num;
      ref Rect local2 = ref finalRect1;
      double y1 = local2.Y;
      desiredSize1 = this.m_TopAutoHidePanel.DesiredSize;
      double height3 = desiredSize1.Height;
      local2.Y = y1 + height3;
    }
    if (this.m_BottomAutoHidePanel != null)
    {
      if (isArrange)
      {
        AutoHidePanel bottomAutoHidePanel = this.m_BottomAutoHidePanel;
        double x = finalRect1.X;
        double bottom = finalRect1.Bottom;
        desiredSize1 = this.m_BottomAutoHidePanel.DesiredSize;
        double height4 = desiredSize1.Height;
        double y = bottom - height4;
        double width = finalRect1.Width;
        desiredSize1 = this.m_BottomAutoHidePanel.DesiredSize;
        double height5 = desiredSize1.Height;
        Rect finalRect3 = new Rect(x, y, width, height5);
        bottomAutoHidePanel.Arrange(finalRect3);
      }
      else
        this.m_BottomAutoHidePanel.Measure(finalRect1.Size);
      ref Rect local = ref finalRect1;
      double height6 = finalRect1.Height;
      desiredSize1 = this.m_BottomAutoHidePanel.DesiredSize;
      double height7 = desiredSize1.Height;
      double num = Math.Max(0.0, height6 - height7);
      local.Height = num;
    }
    if (this.m_LeftAutoHidePanel != null)
    {
      if (isArrange)
      {
        AutoHidePanel leftAutoHidePanel = this.m_LeftAutoHidePanel;
        double x = finalRect1.X;
        double y = finalRect1.Y;
        desiredSize1 = this.m_LeftAutoHidePanel.DesiredSize;
        double width = desiredSize1.Width;
        double height = finalRect1.Height;
        Rect finalRect4 = new Rect(x, y, width, height);
        leftAutoHidePanel.Arrange(finalRect4);
      }
      else
        this.m_LeftAutoHidePanel.Measure(finalRect1.Size);
      ref Rect local3 = ref finalRect1;
      double x1 = local3.X;
      desiredSize1 = this.m_LeftAutoHidePanel.DesiredSize;
      double width1 = desiredSize1.Width;
      local3.X = x1 + width1;
      ref Rect local4 = ref finalRect1;
      double width2 = finalRect1.Width;
      desiredSize1 = this.m_LeftAutoHidePanel.DesiredSize;
      double width3 = desiredSize1.Width;
      double num = Math.Max(0.0, width2 - width3);
      local4.Width = num;
    }
    if (this.m_RightAutoHidePanel != null)
    {
      if (isArrange)
      {
        AutoHidePanel rightAutoHidePanel = this.m_RightAutoHidePanel;
        double right = finalRect1.Right;
        desiredSize1 = this.m_RightAutoHidePanel.DesiredSize;
        double width4 = desiredSize1.Width;
        double x = right - width4;
        double y = finalRect1.Y;
        desiredSize1 = this.m_RightAutoHidePanel.DesiredSize;
        double width5 = desiredSize1.Width;
        double height = finalRect1.Height;
        Rect finalRect5 = new Rect(x, y, width5, height);
        rightAutoHidePanel.Arrange(finalRect5);
      }
      else
        this.m_RightAutoHidePanel.Measure(finalRect1.Size);
      ref Rect local = ref finalRect1;
      double width6 = finalRect1.Width;
      desiredSize1 = this.m_RightAutoHidePanel.DesiredSize;
      double width7 = desiredSize1.Width;
      double num = Math.Max(0.0, width6 - width7);
      local.Width = num;
    }
    foreach (SplitPanel splitPanel in (Collection<SplitPanel>) this.SplitPanels)
    {
      if (splitPanel.Visibility != Visibility.Collapsed)
      {
        Dock dock = DockSite.GetDock((UIElement) splitPanel);
        Rect finalRect6 = Rect.Empty;
        Size desiredSize2 = splitPanel.DesiredSize;
        if (!isArrange)
        {
          if (dock == Dock.Left || dock == Dock.Right)
          {
            desiredSize2.Width = DockSite.GetDockSize((UIElement) splitPanel);
            desiredSize2.Height = finalRect1.Height;
            if (desiredSize2.Width > finalRect1.Width && finalRect1.Width > 0.0)
              desiredSize2.Width = finalRect1.Width;
          }
          else
          {
            desiredSize2.Height = DockSite.GetDockSize((UIElement) splitPanel);
            desiredSize2.Width = finalRect1.Width;
            if (desiredSize2.Height > finalRect1.Height && finalRect1.Height > 0.0)
              desiredSize2.Height = finalRect1.Height;
          }
        }
        switch (dock)
        {
          case Dock.Left:
            finalRect6 = new Rect(finalRect1.X, finalRect1.Y, desiredSize2.Width, finalRect1.Height);
            finalRect1.Width = Math.Max(0.0, finalRect1.Width - desiredSize2.Width);
            finalRect1.X += desiredSize2.Width;
            break;
          case Dock.Top:
            finalRect6 = new Rect(finalRect1.X, finalRect1.Y, finalRect1.Width, desiredSize2.Height);
            finalRect1.Height = Math.Max(0.0, finalRect1.Height - desiredSize2.Height);
            finalRect1.Y += desiredSize2.Height;
            break;
          case Dock.Right:
            finalRect6 = new Rect(finalRect1.Right - desiredSize2.Width, finalRect1.Y, desiredSize2.Width, finalRect1.Height);
            finalRect1.Width = Math.Max(0.0, finalRect1.Width - desiredSize2.Width);
            break;
          case Dock.Bottom:
            finalRect6 = new Rect(finalRect1.X, finalRect1.Bottom - desiredSize2.Height, finalRect1.Width, desiredSize2.Height);
            finalRect1.Height = Math.Max(0.0, finalRect1.Height - desiredSize2.Height);
            break;
        }
        if (isArrange)
          splitPanel.Arrange(finalRect6);
        else
          splitPanel.Measure(finalRect6.Size);
      }
    }
    this.m_DocumentRect = finalRect1;
    if (this.HasContent && this.Content is UIElement)
    {
      if (isArrange)
        ((UIElement) this.Content).Arrange(finalRect1);
      else
        ((UIElement) this.Content).Measure(finalRect1.Size);
    }
    if (!isArrange)
      LayoutHelpers.NormalizeMeasureBounds(ref arrangeBounds);
    return arrangeBounds;
  }

  [Browsable(true)]
  [NotifyParentProperty(true)]
  [Category("Localization")]
  [Description("Gets system text used by the component..")]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
  public DockLocalization SystemText => this.m_SystemText;

  [AttachedPropertyBrowsableForChildren]
  public static Dock GetDock(UIElement element)
  {
    return element != null ? (Dock) element.GetValue(DockSite.DockProperty) : throw new ArgumentNullException(nameof (element));
  }

  public static void SetDock(UIElement element, Dock d)
  {
    if (element == null)
      throw new ArgumentNullException(nameof (element));
    element.SetValue(DockSite.DockProperty, (object) d);
  }

  private static void OnDockChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
  {
    if (d is SplitPanel splitPanel)
    {
      int num;
      switch ((Dock) e.NewValue)
      {
        case Dock.Left:
        case Dock.Right:
          num = 1;
          break;
        default:
          num = 0;
          break;
      }
      splitPanel.Orientation = (Orientation) num;
    }
    if (!(d is UIElement uiElement))
      return;
    uiElement.RaiseEvent(new RoutedEventArgs(DockSite.DockChangedEvent));
  }

  [AttachedPropertyBrowsableForChildren]
  public static double GetDockSize(UIElement element)
  {
    return element != null ? (double) element.GetValue(DockSite.DockSizeProperty) : throw new ArgumentNullException(nameof (element));
  }

  public static void SetDockSize(UIElement element, double d)
  {
    if (element == null)
      throw new ArgumentNullException(nameof (element));
    element.SetValue(DockSite.DockSizeProperty, (object) d);
  }

  private static void DockSizeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
  {
    UIElement reference = (UIElement) d;
    if (reference == null)
      return;
    reference.InvalidateMeasure();
    if (!(VisualTreeHelper.GetParent((DependencyObject) reference) is UIElement parent))
      return;
    parent.InvalidateMeasure();
  }

  public static bool GetIsDocument(UIElement element)
  {
    return element != null ? (bool) element.GetValue(DockSite.IsDocumentProperty) : throw new ArgumentNullException(nameof (element));
  }

  public static void SetIsDocument(UIElement element, bool doc)
  {
    if (element == null)
      throw new ArgumentNullException(nameof (element));
    element.SetValue(DockSite.IsDocumentProperty, (object) doc);
  }

  private static void OnDocumentPropertyChanged(
    DependencyObject d,
    DependencyPropertyChangedEventArgs e)
  {
    if (!(d is UIElement uiElement))
      return;
    uiElement.RaiseEvent(new RoutedEventArgs(DockSite.IsDocumentChangedEvent));
  }

  public static bool GetSaveLayout(UIElement element)
  {
    return element != null ? (bool) element.GetValue(DockSite.SaveLayoutProperty) : throw new ArgumentNullException(nameof (element));
  }

  public static void SetSaveLayout(UIElement element, bool saveLayout)
  {
    if (element == null)
      throw new ArgumentNullException(nameof (element));
    element.SetValue(DockSite.SaveLayoutProperty, (object) saveLayout);
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
  public SplitPanelCollection SplitPanels
  {
    get => (SplitPanelCollection) this.GetValue(DockSite.SplitPanelsProperty);
  }

  internal void AddSplitPanel(SplitPanel p) => this.m_Children.Add((UIElement) p);

  internal void RemoveSplitPanel(SplitPanel p) => this.m_Children.Remove((UIElement) p);

  protected override Visual GetVisualChild(int index) => (Visual) this.m_Children[index];

  protected override int VisualChildrenCount => this.m_Children.Count;

  protected override void OnContentChanged(object oldContent, object newContent)
  {
    if (oldContent is UIElement)
    {
      this.m_Children.Remove((UIElement) oldContent);
      if (oldContent is SplitPanel)
        this.UpdateIsDocument(oldContent as SplitPanel, false);
      else
        DockSite.SetIsDocument((UIElement) oldContent, false);
    }
    base.OnContentChanged(oldContent, newContent);
    if (!(newContent is UIElement))
      return;
    this.m_Children.Add((UIElement) newContent);
    if (newContent is SplitPanel)
      this.UpdateIsDocument(newContent as SplitPanel, true);
    else
      DockSite.SetIsDocument((UIElement) newContent, true);
  }

  [EditorBrowsable(EditorBrowsableState.Never)]
  [Browsable(false)]
  public Rect DocumentRect => this.m_DocumentRect;

  internal Size GetMinimumDocumentAreaSize() => this.MinimumDocumentAreaSize;

  protected virtual void OnBeforeDockingStarts(DockRoutedEventArgs e)
  {
    this.RaiseEvent((RoutedEventArgs) e);
  }

  private void CreateNewDockHintAdorner(
    AdornerLayer adornerLayer,
    UIElement adornedElement,
    DockWindowGroup dockWindowGroup)
  {
    if (this.m_DockHintAdorner != null)
    {
      this.RemoveAdorner(this.m_DockHintAdorner);
      this.m_DockHintAdorner = (DockSiteAdorner) null;
    }
    this.m_DockHintAdorner = new DockSiteAdorner(this.m_DockHintWindow == null ? adornedElement : this.m_DockHintWindow.GetElementToAdorn());
    this.m_DockHintAdorner.RealAdornedElement = adornedElement;
    if (dockWindowGroup.CanDockBottom)
      this.m_DockHintAdorner.DockHintBottom = this.GetDockHint(eDockHintSide.Bottom);
    if (dockWindowGroup.CanDockTop)
      this.m_DockHintAdorner.DockHintTop = this.GetDockHint(eDockHintSide.Top);
    if (dockWindowGroup.CanDockLeft)
      this.m_DockHintAdorner.DockHintLeft = this.GetDockHint(eDockHintSide.Left);
    if (dockWindowGroup.CanDockRight)
      this.m_DockHintAdorner.DockHintRight = this.GetDockHint(eDockHintSide.Right);
    this.m_DockHintAdorner.DockHintAllSides = !dockWindowGroup.CanDockAsDocument ? this.GetDockHint(eDockHintSide.AllSides) : this.GetDockHint(eDockHintSide.AllSidesAndCenter);
    adornerLayer.Add((Adorner) this.m_DockHintAdorner);
  }

  private AdornerLayer GetDockHintAdornerLayer()
  {
    AdornerLayer adornerLayer;
    if (this.DockHintOverlay)
    {
      if (this.m_DockHintWindow == null)
        this.m_DockHintWindow = new DockSiteOverlayWindow();
      System.Windows.Point screen = this.PointToScreen(new System.Windows.Point(0.0, 0.0));
      this.m_DockHintWindow.Left = screen.X;
      this.m_DockHintWindow.Top = screen.Y;
      this.m_DockHintWindow.Width = this.ActualWidth;
      this.m_DockHintWindow.Height = this.ActualHeight;
      if (!this.m_DockHintWindow.IsVisible)
        this.m_DockHintWindow.Show();
      adornerLayer = this.m_DockHintWindow.GetAdornerLayer();
    }
    else
      adornerLayer = AdornerLayer.GetAdornerLayer((Visual) this);
    return adornerLayer;
  }

  internal bool StartDockWindowDrag(
    DockWindowGroup dockWindowGroup,
    bool dragSelectedTabOnly,
    eEventActionSource actionSource)
  {
    if (this.m_IsDockingInProgress || !dockWindowGroup.CanDockAsDocument && !dockWindowGroup.CanDockBottom && !dockWindowGroup.CanDockLeft && !dockWindowGroup.CanDockRight && !dockWindowGroup.CanDockTop || dockWindowGroup == null)
      return false;
    DockRoutedEventArgs e = new DockRoutedEventArgs(DockSite.BeforeDockingStartsEvent, (object) this, dragSelectedTabOnly ? (object) dockWindowGroup.SelectedDockWindow : (object) dockWindowGroup, actionSource);
    this.OnBeforeDockingStarts(e);
    if (e.Cancel)
      return false;
    this._DockWindowDragInitializing = true;
    try
    {
      this.m_IsDockingInProgress = true;
      this.ActivateParentWindow();
      if (this.m_DragWindow == null)
      {
        this.m_DragWindow = new DragWindow();
        this.m_DragWindow.ShowActivated = false;
        this.m_DragWindow.KeyDown += new KeyEventHandler(this.DragWindowKeyDown);
        this.m_DragWindow.Width = 0.0;
        this.m_DragWindow.Height = 0.0;
      }
      this.m_DragWindow.Show();
      if (!this.CaptureMouse())
      {
        this.m_IsDockingInProgress = false;
        this.m_DragWindow.Hide();
        return false;
      }
      Rect rect = new Rect(0.0, 0.0, 150.0, 200.0);
      if (dockWindowGroup.IsFloating && !dragSelectedTabOnly)
      {
        FloatingWindow floatingWindow = this.GetFloatingWindow((UIElement) dockWindowGroup);
        rect = new Rect(floatingWindow.Left, floatingWindow.Top, floatingWindow.Width, floatingWindow.Height);
        floatingWindow.Hide();
      }
      else if (dockWindowGroup.SelectedItem is DevComponents.WpfDock.DockWindow)
      {
        Rect floatingRect = ((DevComponents.WpfDock.DockWindow) dockWindowGroup.SelectedItem).FloatingRect;
        if (floatingRect.Width > 0.0 && floatingRect.Height > 0.0)
          rect = floatingRect;
      }
      else if (dockWindowGroup.RenderSize.Width > 0.0 && dockWindowGroup.RenderSize.Height > 0.0)
        rect.Size = dockWindowGroup.RenderSize;
      this.CreateNewDockHintAdorner(this.GetDockHintAdornerLayer(), (UIElement) this, dockWindowGroup);
      int num = !this.AnimationEnabled ? 0 : (!this.DockHintOverlay ? 1 : 0);
      if (num != 0)
        this.m_DockHintAdorner.Opacity = 0.0;
      if (num != 0)
      {
        DoubleAnimation animation = new DoubleAnimation(1.0, new Duration(TimeSpan.FromMilliseconds(200.0)));
        this.m_DockHintAdorner.BeginAnimation(UIElement.OpacityProperty, (AnimationTimeline) animation);
      }
      this.m_DragWindow.FloatingSize = rect.Size;
      this.m_DragWindow.Width = rect.Width;
      this.m_DragWindow.Height = rect.Height;
      System.Windows.Point point = new System.Windows.Point();
      bool flag = false;
      System.Windows.Point position;
      if (dockWindowGroup.IsFloating)
      {
        FloatingWindow floatingWindow = this.GetFloatingWindow((UIElement) dockWindowGroup);
        position = Mouse.GetPosition((IInputElement) floatingWindow);
        if (position.X > floatingWindow.Width - 8.0)
          position.X = Math.Round(floatingWindow.Width / 2.0);
        if (dragSelectedTabOnly)
        {
          position.Y = -8.0;
          position.X = Math.Round(floatingWindow.Width / 2.0);
        }
        flag = true;
      }
      else
      {
        position = Mouse.GetPosition((IInputElement) dockWindowGroup);
        if (position.X > this.m_DragWindow.FloatingSize.Width)
          position.X = Math.Round(this.m_DragWindow.FloatingSize.Width / 2.0);
        if (dragSelectedTabOnly)
          position.Y = 8.0;
      }
      System.Windows.Point screen = dockWindowGroup.PointToScreen(position);
      if (flag)
      {
        screen.Offset(-position.X, position.Y);
        this.m_DragWindow.DisplayOffset = new System.Windows.Point(position.X, -position.Y);
      }
      else
      {
        screen.Offset(-position.X, -position.Y);
        this.m_DragWindow.DisplayOffset = position;
      }
      this.m_DragWindow.Left = screen.X;
      this.m_DragWindow.Top = screen.Y;
      this.m_DragDockWindowGroup = dockWindowGroup;
      this.m_DragSelectedTabOnly = dragSelectedTabOnly;
    }
    finally
    {
      this._DockWindowDragInitializing = false;
    }
    return true;
  }

  private void DragWindowKeyDown(object sender, KeyEventArgs e)
  {
    if (e.Key != Key.Escape)
      return;
    this.CancelWindowDocking();
  }

  private UIElement GetDockHint(eDockHintSide dh) => (UIElement) new DockHint(dh);

  protected override void OnMouseMove(MouseEventArgs e)
  {
    if (this.m_DragWindow != null && this.m_DragWindow.IsVisible && this.m_IsDockingInProgress && !this._DockWindowDragInitializing)
    {
      System.Windows.Point position = e.GetPosition((IInputElement) this);
      this.UpdateMouseOverDockHint(position);
      System.Windows.Point mousePos = position;
      FloatingWindow relativeTo = (FloatingWindow) null;
      if (this.m_DockMouseOverElement is DockWindowGroup && ((DockWindowGroup) this.m_DockMouseOverElement).IsFloating)
      {
        relativeTo = this.GetFloatingWindow(this.m_DockMouseOverElement);
        if (relativeTo != null)
          mousePos = e.GetPosition((IInputElement) relativeTo);
      }
      DockSite.DockPositionInfo dockPosition = this.GetDockPosition(mousePos);
      if (dockPosition.PositionInfo == eDockInfo.Float)
      {
        System.Windows.Point screen = this.PointToScreen(position);
        screen.Offset(-this.m_DragWindow.DisplayOffset.X, -this.m_DragWindow.DisplayOffset.Y);
        if (this.DpiMultiplier > 1.0)
        {
          WinApi.SetWindowPos(new WindowInteropHelper((Window) this.m_DragWindow).Handle, IntPtr.Zero, (int) screen.X, (int) screen.Y, 0, 0, 5);
        }
        else
        {
          this.m_DragWindow.Left = screen.X;
          this.m_DragWindow.Top = screen.Y;
        }
        if (this.m_DragWindow.Width != this.m_DragWindow.FloatingSize.Width)
          this.m_DragWindow.Width = this.m_DragWindow.FloatingSize.Width;
        if (this.m_DragWindow.Height != this.m_DragWindow.FloatingSize.Height)
          this.m_DragWindow.Height = this.m_DragWindow.FloatingSize.Height;
        dockPosition.DockRect = new Rect(screen.X, screen.Y, this.m_DragWindow.FloatingSize.Width, this.m_DragWindow.FloatingSize.Height);
      }
      else
      {
        System.Windows.Point screen = this.PointToScreen(dockPosition.DockRect.Location);
        if (relativeTo != null)
          screen = relativeTo.PointToScreen(dockPosition.DockRect.Location);
        if (this.DpiMultiplier > 1.0)
        {
          WinApi.SetWindowPos(new WindowInteropHelper((Window) this.m_DragWindow).Handle, IntPtr.Zero, (int) screen.X, (int) screen.Y, 0, 0, 5);
        }
        else
        {
          this.m_DragWindow.Left = screen.X;
          this.m_DragWindow.Top = screen.Y;
        }
        this.m_DragWindow.Width = dockPosition.DockRect.Width;
        this.m_DragWindow.Height = dockPosition.DockRect.Height;
      }
      this.m_CurrentDockPosition = dockPosition;
    }
    base.OnMouseMove(e);
  }

  private double DpiMultiplier
  {
    get
    {
      double dpiMultiplier = 1.0;
      System.Windows.Point resolution = LayoutHelpers.GetResolution((Visual) this);
      if (resolution.Y != 96.0)
        dpiMultiplier += (resolution.Y - 96.0) / 96.0;
      return dpiMultiplier;
    }
  }

  private void UpdateMouseOverDockHint(System.Windows.Point mp)
  {
    DockWindowGroup dragDockWindowGroup = this.m_DragDockWindowGroup;
    UIElement dockedElementAt = this.GetDockedElementAt(mp, DockSite.GetIsDocument((UIElement) dragDockWindowGroup) || this.IsDockableAsDocumentOnly(dragDockWindowGroup), false, this.IsDockableAsDocumentOnly(dragDockWindowGroup));
    bool flag = false;
    if (dockedElementAt != null)
      flag = this.GetIsDocumentElement(dockedElementAt);
    FloatingWindow floatingWindow = (FloatingWindow) null;
    if (dockedElementAt is DockWindowGroup && ((DockWindowGroup) dockedElementAt).IsFloating && dockedElementAt != this.m_DragDockWindowGroup)
    {
      AdornerLayer hintAdornerLayer = this.GetDockHintAdornerLayer();
      if (this.m_DockHintAdorner.Parent != hintAdornerLayer)
      {
        this.CreateNewDockHintAdorner(hintAdornerLayer, dockedElementAt, dragDockWindowGroup);
        if (this.m_DockHintAdorner.DockHintBottom != null)
          this.m_DockHintAdorner.DockHintBottom.Visibility = Visibility.Collapsed;
        if (this.m_DockHintAdorner.DockHintTop != null)
          this.m_DockHintAdorner.DockHintTop.Visibility = Visibility.Collapsed;
        if (this.m_DockHintAdorner.DockHintLeft != null)
          this.m_DockHintAdorner.DockHintLeft.Visibility = Visibility.Collapsed;
        if (this.m_DockHintAdorner.DockHintRight != null)
          this.m_DockHintAdorner.DockHintRight.Visibility = Visibility.Collapsed;
      }
      floatingWindow = this.GetFloatingWindow(dockedElementAt);
    }
    else if (this.m_DockHintAdorner.Parent != this.GetDockHintAdornerLayer())
      this.CreateNewDockHintAdorner(this.GetDockHintAdornerLayer(), (UIElement) this, dragDockWindowGroup);
    if (dockedElementAt != null && (dockedElementAt != this.m_DragDockWindowGroup || this.m_DragSelectedTabOnly && this.m_DragDockWindowGroup.Items.Count > 1) && (!flag || flag && dragDockWindowGroup.CanDockAsDocument))
    {
      System.Windows.Point location = this.PointFromScreen(dockedElementAt.PointToScreen(new System.Windows.Point(0.0, 0.0)));
      if (floatingWindow != null)
        location = floatingWindow.PointFromScreen(dockedElementAt.PointToScreen(new System.Windows.Point(0.0, 0.0)));
      if (this.m_DockHintWindow != null)
        location = this.m_DockHintWindow.PointFromScreen(dockedElementAt.PointToScreen(new System.Windows.Point(0.0, 0.0)));
      this.m_DockHintAdorner.AllSidesRect = new Rect(location, dockedElementAt.RenderSize);
      UIElement uiElement = !(dockedElementAt is DockWindowGroup) || dockedElementAt == this.m_DragDockWindowGroup && this.m_DragSelectedTabOnly ? this.GetDockHint(eDockHintSide.AllSides) : this.GetDockHint(eDockHintSide.AllSidesAndCenter);
      if (this.m_DockHintAdorner.DockHintAllSides != uiElement)
      {
        this.m_DockHintAdorner.DockHintAllSides = uiElement;
        this.m_DockHintAdorner.UpdateLayout();
      }
    }
    else
    {
      Rect rect1 = this.m_DockHintAdorner.AllSidesRect;
      if (rect1.Width > 0.0)
      {
        this.m_DockHintAdorner.DockHintAllSides = !dragDockWindowGroup.CanDockAsDocument ? this.GetDockHint(eDockHintSide.AllSides) : this.GetDockHint(eDockHintSide.AllSidesAndCenter);
        DockSiteAdorner dockHintAdorner = this.m_DockHintAdorner;
        rect1 = new Rect();
        Rect rect2 = rect1;
        dockHintAdorner.AllSidesRect = rect2;
      }
    }
    this.m_DockMouseOverElement = dockedElementAt;
  }

  private bool IsDockableAsDocumentOnly(DockWindowGroup group)
  {
    return group.CanDockAsDocument && !group.CanDockLeft && !group.CanDockRight && !group.CanDockTop && !group.CanDockBottom;
  }

  internal FloatingWindow GetFloatingWindow(UIElement elem)
  {
    if (elem == null)
      return (FloatingWindow) null;
    for (; elem != null; elem = LogicalTreeHelper.GetParent((DependencyObject) elem) as UIElement)
    {
      if (elem is FloatingWindow)
        return elem as FloatingWindow;
    }
    return (FloatingWindow) null;
  }

  public bool GetIsDocumentElement(UIElement elem)
  {
    if (DockSite.GetIsDocument(elem))
      return true;
    uiElement = elem;
    while (!(LogicalTreeHelper.GetParent((DependencyObject) uiElement) is UIElement uiElement) || !DockSite.GetIsDocument(uiElement))
    {
      if (uiElement == null || uiElement is DockSite)
        return false;
    }
    return true;
  }

  private UIElement GetDockedElementAt(
    System.Windows.Point mp,
    bool enumDocuments,
    bool enumFloating,
    bool enumDocumentsOnly)
  {
    if (!enumDocumentsOnly)
    {
      foreach (SplitPanel splitPanel in (Collection<SplitPanel>) this.SplitPanels)
      {
        if (LayoutInformation.GetLayoutSlot((FrameworkElement) splitPanel).Contains(mp))
        {
          System.Windows.Point p = splitPanel.PointFromScreen(this.PointToScreen(mp));
          return splitPanel.GetDockedElementAt(p);
        }
      }
    }
    if (enumDocuments && this.Content is SplitPanel)
    {
      SplitPanel content = this.Content as SplitPanel;
      if (LayoutInformation.GetLayoutSlot((FrameworkElement) content).Contains(mp))
      {
        System.Windows.Point p = content.PointFromScreen(this.PointToScreen(mp));
        return content.GetDockedElementAt(p);
      }
    }
    if (enumFloating)
    {
      System.Windows.Point screen = this.PointToScreen(mp);
      foreach (FloatingWindow floatingWindow in this.m_FloatingWindows)
      {
        if (new Rect(floatingWindow.Left, floatingWindow.Top, floatingWindow.Width, floatingWindow.Height).Contains(screen))
        {
          if (floatingWindow.Content is DockWindowGroup)
            return (UIElement) (floatingWindow.Content as DockWindowGroup);
          if (floatingWindow.Content is SplitPanel)
          {
            SplitPanel content = floatingWindow.Content as SplitPanel;
            return content.GetDockedElementAt(content.PointFromScreen(screen));
          }
        }
      }
    }
    return (UIElement) null;
  }

  protected override void OnMouseUp(MouseButtonEventArgs e)
  {
    if (this.m_IsDockingInProgress && e.LeftButton == MouseButtonState.Released)
      this.ReleaseMouseCapture();
    base.OnMouseUp(e);
  }

  protected override void OnKeyDown(KeyEventArgs e)
  {
    if (e.Key == Key.Escape)
      this.CancelWindowDocking();
    else if (this.KeyboardNavigationEnabled && e.Key == Key.Tab && (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)))
    {
      this.DockSelectorNavigate(Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift));
      e.Handled = true;
    }
    else if (e.Key == Key.F6 && (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)))
    {
      DevComponents.WpfDock.DockWindow activeDockWindow = this.ActiveDockWindow;
      if (activeDockWindow != null && activeDockWindow.ParentGroup != null)
      {
        DockWindowGroup parentGroup = activeDockWindow.ParentGroup;
        if (Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift))
          parentGroup.SelectPreviousTab(true);
        else
          parentGroup.SelectNextTab(true);
        if (parentGroup.SelectedDockWindow != null)
          parentGroup.SelectedDockWindow.FocusContent();
      }
      e.Handled = true;
    }
    base.OnKeyDown(e);
  }

  protected override void OnKeyUp(KeyEventArgs e)
  {
    if (e.Key == Key.LeftCtrl || e.Key == Key.RightCtrl)
      this.ReleaseDockSelectorAdorner(true);
    else if (e.Key == Key.Escape)
      this.ReleaseDockSelectorAdorner(false);
    base.OnKeyUp(e);
  }

  public void ReleaseDockSelectorAdorner(bool applySelection)
  {
    if (this.m_DockSelectorAdorner == null)
      return;
    DockWindowSelector dockWindowSelector = this.m_DockSelectorAdorner.DockWindowSelector;
    dockWindowSelector.LostMouseCapture -= new MouseEventHandler(this.DockWindowSelectorLostMouseCapture);
    if (applySelection)
    {
      DevComponents.WpfDock.DockWindow dockWindow = (DevComponents.WpfDock.DockWindow) null;
      if (dockWindowSelector.SelectedItem != null)
        dockWindow = ((DockWindowInfo) dockWindowSelector.SelectedItem).DockWindow;
      else if (dockWindowSelector.SelectedToolWindow != null)
        dockWindow = dockWindowSelector.SelectedToolWindow.DockWindow;
      if (dockWindow != null)
      {
        if (dockWindow.IsAutoHide)
          dockWindow.AutoHideOpen = true;
        dockWindow.IsSelected = true;
        dockWindow.FocusContent();
      }
    }
    this.GetDockSelectorAdornerLayer().Remove((Adorner) this.m_DockSelectorAdorner);
    this.m_DockSelectorAdorner.ReleaseMouseCapture();
    this.m_DockSelectorAdorner = (DockSelectorAdorner) null;
    if (this.m_DockSelectorWindow == null)
      return;
    this.m_DockSelectorWindow.Close();
    this.m_DockSelectorWindow = (DockSiteOverlayWindow) null;
  }

  private void DockSelectorNavigate(bool back)
  {
    if (this.m_DockSelectorAdorner == null)
    {
      this.CreateDockSelectorAdorner();
      this.m_DockSelectorAdorner.DockWindowSelector.NavigateForward();
    }
    else if (back)
      this.m_DockSelectorAdorner.DockWindowSelector.NavigateBack();
    else
      this.m_DockSelectorAdorner.DockWindowSelector.NavigateForward();
  }

  private AdornerLayer GetDockSelectorAdornerLayer()
  {
    AdornerLayer adornerLayer;
    if (this.DockSelectorOverlay)
    {
      if (this.m_DockSelectorWindow == null)
      {
        DockSiteOverlayWindow siteOverlayWindow = new DockSiteOverlayWindow();
        siteOverlayWindow.Owner = Window.GetWindow((DependencyObject) this);
        this.m_DockSelectorWindow = siteOverlayWindow;
        this.m_DockSelectorWindow.PreviewKeyDown += (KeyEventHandler) ((sender, e) =>
        {
          if (e.Key != Key.Tab || !Keyboard.IsKeyDown(Key.LeftCtrl) && !Keyboard.IsKeyDown(Key.RightCtrl))
            return;
          this.DockSelectorNavigate(Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift));
          e.Handled = true;
        });
        this.m_DockSelectorWindow.KeyUp += (KeyEventHandler) ((sender, e) =>
        {
          if (e.Key == Key.LeftCtrl || e.Key == Key.RightCtrl)
          {
            this.ReleaseDockSelectorAdorner(true);
          }
          else
          {
            if (e.Key != Key.Escape)
              return;
            this.ReleaseDockSelectorAdorner(false);
          }
        });
      }
      System.Windows.Point screen = this.PointToScreen(new System.Windows.Point(0.0, 0.0));
      this.m_DockSelectorWindow.Left = screen.X;
      this.m_DockSelectorWindow.Top = screen.Y;
      this.m_DockSelectorWindow.Width = this.ActualWidth;
      this.m_DockSelectorWindow.Height = this.ActualHeight;
      if (!this.m_DockSelectorWindow.IsVisible)
        this.m_DockSelectorWindow.Show();
      adornerLayer = this.m_DockSelectorWindow.GetAdornerLayer();
    }
    else
      adornerLayer = AdornerLayer.GetAdornerLayer((Visual) this);
    return adornerLayer;
  }

  private void CreateDockSelectorAdorner()
  {
    if (this.m_DockSelectorAdorner != null)
    {
      this.RemoveDockSelectorAdorner(this.m_DockSelectorAdorner);
      this.m_DockSelectorAdorner = (DockSelectorAdorner) null;
    }
    DevComponents.WpfDock.DockWindow activeDockWindow = this.ActiveDockWindow;
    AdornerLayer selectorAdornerLayer = this.GetDockSelectorAdornerLayer();
    DockSelectorAdorner dockSelectorAdorner = new DockSelectorAdorner(this.m_DockSelectorWindow == null ? (UIElement) this : this.m_DockSelectorWindow.GetElementToAdorn());
    dockSelectorAdorner.DockWindowSelector.ActiveFilesLabel = this.SystemText.DockSelectorActiveFilesText;
    dockSelectorAdorner.DockWindowSelector.ActiveToolWindowsLabel = this.SystemText.DockSelectorActiveToolWindowsText;
    dockSelectorAdorner.DockWindowSelector.CycleAllWindows = this.SelectorCycleAllWindows;
    dockSelectorAdorner.RealAdornedElement = (UIElement) this;
    foreach (DevComponents.WpfDock.DockWindow dockWindow in this.GetDockWindows())
    {
      if (dockWindow.Visibility == Visibility.Visible)
      {
        if (DockSite.GetIsDocument((UIElement) dockWindow))
        {
          DockWindowInfo newItem = DockWindowInfo.FromDockWindow(dockWindow);
          dockSelectorAdorner.DockWindowSelector.Items.Add((object) newItem);
          if (dockWindow == activeDockWindow)
            dockSelectorAdorner.DockWindowSelector.SelectedItem = (object) newItem;
        }
        else
        {
          DockWindowInfo dockWindowInfo = DockWindowInfo.FromDockWindow(dockWindow);
          dockSelectorAdorner.DockWindowSelector.ToolWindows.Add(dockWindowInfo);
          if (dockWindow == activeDockWindow)
            dockSelectorAdorner.DockWindowSelector.SelectedToolWindow = dockWindowInfo;
        }
      }
    }
    selectorAdornerLayer.Add((Adorner) dockSelectorAdorner);
    this.m_DockSelectorAdorner = dockSelectorAdorner;
    dockSelectorAdorner.DockWindowSelector.LostMouseCapture += new MouseEventHandler(this.DockWindowSelectorLostMouseCapture);
    Mouse.Capture((IInputElement) dockSelectorAdorner.DockWindowSelector, CaptureMode.SubTree);
    dockSelectorAdorner.UpdateLayout();
  }

  private void DockWindowSelectorLostMouseCapture(object sender, MouseEventArgs e)
  {
    this.ReleaseDockSelectorAdorner(false);
  }

  public void CancelWindowDocking()
  {
    if (!this.m_IsDockingInProgress)
      return;
    this.EndDockWindowDrag(true);
    this.ReleaseMouseCapture();
  }

  [Browsable(false)]
  public bool IsDockingInProgress => this.m_IsDockingInProgress;

  protected override void OnLostMouseCapture(MouseEventArgs e)
  {
    if (this.m_IsDockingInProgress)
      this.EndDockWindowDrag(false);
    base.OnLostMouseCapture(e);
  }

  private void SaveCurrentDockInfo(DockWindowGroup source)
  {
    this.SaveCurrentDockInfo(source, source, false);
  }

  private void SaveCurrentDockInfo(DockWindowGroup source, DockWindowGroup target, bool saveAsTab)
  {
    SplitPanel parent = source.Parent as SplitPanel;
    target.LastDockReferenceId = "";
    if (saveAsTab)
    {
      target.LastDockReferenceId = source.Id;
      target.LastDockSide = parent == null ? source.LastDockSide : DockSite.GetDockSideFromDock(DockSite.GetDock((UIElement) parent));
      target.LastDockReference = eDockSide.Tab;
      target.LastIsDocument = DockSite.GetIsDocument((UIElement) source);
    }
    else
    {
      if (parent == null)
        return;
      if (parent.Parent is DockSite && parent.Children.Count == 1 || parent.Children.Count == 1)
      {
        if (DockSite.GetIsDocument((UIElement) source))
        {
          target.LastDockSide = eDockSide.Tab;
        }
        else
        {
          target.LastDockSide = DockSite.GetDockSideFromDock(DockSite.GetDock((UIElement) parent));
          target.LastDockIsFullSizeDock = parent.ActualWidth == this.ActualWidth || parent.ActualHeight == this.ActualHeight;
          DockSite.SetDockSize((UIElement) target, DockSite.GetDockSize((UIElement) parent));
        }
      }
      else
      {
        int index = parent.Children.IndexOf((UIElement) source);
        string previousReferenceId = this.GetPreviousReferenceId(index, parent);
        if (previousReferenceId != "")
        {
          target.LastDockReference = parent.Orientation == Orientation.Horizontal ? eDockSide.Right : eDockSide.Bottom;
          target.LastDockReferenceId = previousReferenceId;
        }
        else
        {
          string nextReferenceId = this.GetNextReferenceId(index, parent);
          if (nextReferenceId != "")
          {
            target.LastDockReferenceId = nextReferenceId;
            target.LastDockReference = parent.Orientation == Orientation.Horizontal ? eDockSide.Left : eDockSide.Top;
          }
        }
        SplitPanel element = parent;
        if (element == null)
          return;
        while (element.Parent != null && element.Parent is SplitPanel)
          element = element.Parent as SplitPanel;
        target.LastDockSide = DockSite.GetDockSideFromDock(DockSite.GetDock((UIElement) element));
      }
    }
  }

  private void SaveCurrentDockInfo(DevComponents.WpfDock.DockWindow dw)
  {
    DockWindowGroup parent1 = dw.Parent as DockWindowGroup;
    dw.LastDockWindowGroupId = "";
    if (parent1 == null)
      return;
    dw.LastDockWindowGroupId = parent1.Id;
    dw.LastDockedSize = SplitPanel.GetRelativeSize((UIElement) parent1);
    SplitPanel parent2 = parent1.Parent as SplitPanel;
    while (parent2 != null && !(parent2.Parent is DockSite))
      parent2 = parent2.Parent as SplitPanel;
    if (parent2 != null)
      dw.LastDock = DockSite.GetDock((UIElement) parent2);
    else
      dw.LastDock = Dock.Right;
  }

  private string GetPreviousReferenceId(int index, SplitPanel parent)
  {
    return index == 0 ? "" : this.GetReferenceId(index, parent, -1);
  }

  private string GetNextReferenceId(int index, SplitPanel parent)
  {
    return index == parent.Children.Count - 1 ? "" : this.GetReferenceId(index, parent, 1);
  }

  private string GetReferenceId(int index, SplitPanel parent, int direction)
  {
    int num = 0;
    if (direction > 0)
      num = parent.Children.Count - 1;
    do
    {
      index += direction;
      UIElement child = parent.Children[index];
      if (child.Visibility == Visibility.Visible)
      {
        if (child is SplitPanel)
          return ((SplitPanel) child).Id;
        if (child is DockWindowGroup)
          return ((DockWindowGroup) child).Id;
      }
    }
    while (index != num);
    return "";
  }

  private void EndDockWindowDrag(bool cancel)
  {
    try
    {
      if (this.m_DockHintWindow == null)
      {
        DoubleAnimation doubleAnimation = new DoubleAnimation(0.0, new Duration(TimeSpan.FromMilliseconds(300.0)));
        doubleAnimation.Completed += new EventHandler(this.m_DockHintAdorner.AnimationCompleteCleanup);
        DockSiteAdorner dockHintAdorner = this.m_DockHintAdorner;
        this.m_DockHintAdorner = (DockSiteAdorner) null;
        DependencyProperty opacityProperty = UIElement.OpacityProperty;
        DoubleAnimation animation = doubleAnimation;
        dockHintAdorner.BeginAnimation(opacityProperty, (AnimationTimeline) animation);
      }
      else
      {
        this.RemoveAdorner(this.m_DockHintAdorner);
        this.m_DockHintAdorner = (DockSiteAdorner) null;
        this.m_DockHintWindow.Hide();
      }
      this.m_DragWindow.Hide();
      DockSite.DockPositionInfo dockPositionInfo = this.m_CurrentDockPosition;
      if (dockPositionInfo != null && (dockPositionInfo.PositionInfo & eDockInfo.Float) == eDockInfo.Float && !this.m_DragDockWindowGroup.CanFloat)
        dockPositionInfo = (DockSite.DockPositionInfo) null;
      if (!cancel && dockPositionInfo != null)
      {
        eDockSide dockSide = eDockSide.Left;
        if (this.CanConvertDockInfoToDockSide(dockPositionInfo.PositionInfo))
          dockSide = this.GetDockSideFromDockHint(dockPositionInfo.PositionInfo);
        BeforeDockedRoutedEventArgs dockEndsArgs = new BeforeDockedRoutedEventArgs(DockSite.BeforeDockedEvent, (object) this, this.m_DragSelectedTabOnly ? this.m_DragDockWindowGroup.SelectedItem : (object) this.m_DragDockWindowGroup, eEventActionSource.Mouse, (dockPositionInfo.PositionInfo & eDockInfo.Float) == eDockInfo.Float, dockSide, dockPositionInfo.MouseOverGroup);
        this.OnBeforeDocked(dockEndsArgs);
        cancel = dockEndsArgs.Cancel;
      }
      else if (dockPositionInfo == null)
        cancel = true;
      if (!cancel && this.m_DockOperations != null)
        this.m_DockOperations.BeginDockOperation((dockPositionInfo.PositionInfo & eDockInfo.Float) == eDockInfo.Float);
      if (!cancel && this.m_DragSelectedTabOnly)
      {
        if (this.m_DockOperations != null)
        {
          this.m_DragDockWindowGroup = this.m_DockOperations.TearOffSelectedDockWindow(this.m_DragDockWindowGroup);
        }
        else
        {
          DockWindowGroup target = new DockWindowGroup();
          object selectedItem = this.m_DragDockWindowGroup.SelectedItem;
          this.SelectDifferentTab(this.m_DragDockWindowGroup);
          if (this.m_DragDockWindowGroup.SelectedDockWindow != null)
            this.m_DragDockWindowGroup.SelectedDockWindow.FocusContent();
          this.SaveCurrentDockInfo(this.m_DragDockWindowGroup, target, true);
          this.m_DragDockWindowGroup.Items.Remove(selectedItem);
          if (this.m_DragDockWindowGroup.IsFloating)
            this.Focus();
          DockSite.SetIsDocument((UIElement) selectedItem, false);
          target.Items.Add(selectedItem);
          this.m_DragDockWindowGroup = target;
        }
      }
      if (!cancel && dockPositionInfo != null)
      {
        if (dockPositionInfo.MouseOverGroup == null || dockPositionInfo.MouseOverGroup == this.m_DragDockWindowGroup)
        {
          if ((dockPositionInfo.PositionInfo & eDockInfo.Float) == eDockInfo.Float)
          {
            if (this.m_DockOperations != null)
              this.m_DockOperations.FloatWindow(this.m_DragDockWindowGroup, dockPositionInfo.DockRect);
            else
              this.FloatWindow(this.m_DragDockWindowGroup, dockPositionInfo.DockRect, eEventActionSource.Mouse, false);
          }
          else if (this.m_DockOperations != null)
            this.m_DockOperations.DockWindow(this.m_DragDockWindowGroup, this.GetDockSideFromDockHint(dockPositionInfo.PositionInfo), (dockPositionInfo.PositionInfo & eDockInfo.Outer) == eDockInfo.Outer);
          else
            this.DockWindow(this.m_DragDockWindowGroup, this.GetDockSideFromDockHint(dockPositionInfo.PositionInfo), (dockPositionInfo.PositionInfo & eDockInfo.Outer) == eDockInfo.Outer, eEventActionSource.Mouse, false);
        }
        else if (this.m_DockOperations != null)
          this.m_DockOperations.DockWindow(this.m_DragDockWindowGroup, (UIElement) dockPositionInfo.MouseOverGroup, this.GetDockSideFromDockHint(dockPositionInfo.PositionInfo));
        else
          this.DockWindow(this.m_DragDockWindowGroup, dockPositionInfo.MouseOverGroup, this.GetDockSideFromDockHint(dockPositionInfo.PositionInfo), eEventActionSource.Mouse, false);
        if (this.m_DockOperations != null)
          this.m_DockOperations.EndDockOperation();
      }
      else if (this.m_DragDockWindowGroup.IsFloating)
        this.GetFloatingWindow((UIElement) this.m_DragDockWindowGroup).Show();
      this.OnAfterDocked(new DockRoutedEventArgs(DockSite.AfterDockedEvent, (object) this, (object) this.m_DragDockWindowGroup, eEventActionSource.Mouse));
      this.m_CurrentDockPosition = (DockSite.DockPositionInfo) null;
    }
    finally
    {
      this.m_IsDockingInProgress = false;
      this.m_DragDockWindowGroup = (DockWindowGroup) null;
    }
  }

  protected virtual void OnAfterDocked(DockRoutedEventArgs dockRoutedEventArgs)
  {
    this.RaiseEvent((RoutedEventArgs) dockRoutedEventArgs);
  }

  protected virtual void OnBeforeDocked(BeforeDockedRoutedEventArgs dockEndsArgs)
  {
    this.RaiseEvent((RoutedEventArgs) dockEndsArgs);
  }

  private void SelectDifferentTab(DockWindowGroup dg) => dg.SelectDifferentTab();

  public bool FloatWindow(DevComponents.WpfDock.DockWindow dw)
  {
    return this.FloatWindow(dw, eEventActionSource.Code, true, true);
  }

  public bool FloatWindow(DevComponents.WpfDock.DockWindow dw, bool focusContent)
  {
    return this.FloatWindow(dw, eEventActionSource.Code, true, focusContent);
  }

  public bool FloatWindow(DevComponents.WpfDock.DockWindow dw, eEventActionSource eventSource, bool raiseDockEvents)
  {
    return this.FloatWindow(dw, eventSource, raiseDockEvents, true);
  }

  public bool FloatWindow(
    DevComponents.WpfDock.DockWindow dw,
    eEventActionSource eventSource,
    bool raiseDockEvents,
    bool focusContent)
  {
    if (dw.Parent is DockWindowGroup parent && parent.VisibleItemsCount == 1)
      return this.FloatWindow(dw.Parent as DockWindowGroup, Rect.Empty, eventSource, raiseDockEvents);
    if (raiseDockEvents)
    {
      BeforeDockedRoutedEventArgs dockEndsArgs = new BeforeDockedRoutedEventArgs(DockSite.BeforeDockedEvent, (object) this, (object) dw, eventSource, true, eDockSide.Left, (DockWindowGroup) null);
      this.OnBeforeDocked(dockEndsArgs);
      if (dockEndsArgs.Cancel)
        return false;
    }
    if (parent != null)
    {
      if (parent.SelectedItem == dw)
      {
        this.SelectDifferentTab(parent);
        if (parent.SelectedDockWindow != null)
          parent.SelectedDockWindow.FocusContent();
      }
      parent.Items.Remove((object) dw);
    }
    DockWindowGroup dockWindowGroup = new DockWindowGroup();
    if (parent != null)
      this.SaveCurrentDockInfo(parent, dockWindowGroup, true);
    dockWindowGroup.Items.Add((object) dw);
    dockWindowGroup.SelectedItem = (object) dw;
    this.FloatWindow(dockWindowGroup, Rect.Empty, eventSource, false, focusContent);
    if (raiseDockEvents)
      this.OnAfterDocked(new DockRoutedEventArgs(DockSite.AfterDockedEvent, (object) this, (object) dw, eventSource));
    return true;
  }

  public bool FloatWindow(DockWindowGroup dg)
  {
    return this.FloatWindow(dg, Rect.Empty, eEventActionSource.Code, true, true);
  }

  public bool FloatWindow(
    DockWindowGroup dg,
    Rect floatingRect,
    eEventActionSource eventSource,
    bool raiseDockEvents)
  {
    return this.FloatWindow(dg, floatingRect, eventSource, raiseDockEvents, true);
  }

  public bool FloatWindow(
    DockWindowGroup dg,
    Rect floatingRect,
    eEventActionSource eventSource,
    bool raiseDockEvents,
    bool focusWindowContent)
  {
    if (!dg.CanFloat && !dg.IsFloating || this.IsDesignMode)
      return false;
    if (raiseDockEvents)
    {
      BeforeDockedRoutedEventArgs dockEndsArgs = new BeforeDockedRoutedEventArgs(DockSite.BeforeDockedEvent, (object) this, (object) dg, eventSource, true, eDockSide.Left, (DockWindowGroup) null);
      this.OnBeforeDocked(dockEndsArgs);
      if (dockEndsArgs.Cancel)
        return false;
    }
    FloatingWindow target;
    if (!dg.IsFloating)
    {
      if (dg.Parent != null)
        this.SaveCurrentDockInfo(dg);
      this.Focus();
      this.Detach(dg);
      if (dg.SelectedIndex == -1)
        dg.SelectFirstTab();
      target = new FloatingWindow();
      target.DataContext = this.DataContext;
      this.m_FloatingWindows.Add(target);
      Window window = Window.GetWindow((DependencyObject) this);
      if (window != null)
        target.Owner = window;
      target.DockSite = this;
      target.Content = (object) dg;
      BindingOperations.SetBinding((DependencyObject) target, Window.TitleProperty, (BindingBase) new Binding("SelectedContentHeader")
      {
        Source = (object) dg
      });
      dg.IsFloating = true;
    }
    else
      target = this.GetFloatingWindow((UIElement) dg);
    if (floatingRect.IsEmpty)
      floatingRect = dg.FloatingRect;
    target.Width = floatingRect.Width;
    target.Height = floatingRect.Height;
    target.Left = floatingRect.Left;
    target.Top = floatingRect.Top;
    target.Show();
    target.CanClose = dg.CanClose;
    if (focusWindowContent && dg.SelectedDockWindow != null)
      dg.SelectedDockWindow.FocusContent();
    if (raiseDockEvents)
      this.OnAfterDocked(new DockRoutedEventArgs(DockSite.AfterDockedEvent, (object) this, (object) dg, eventSource));
    return true;
  }

  internal void FloatingWindowClosed(FloatingWindow floatingWindow)
  {
    this.m_FloatingWindows.Remove(floatingWindow);
  }

  private bool CanConvertDockInfoToDockSide(eDockInfo di)
  {
    return (di & eDockInfo.Bottom) != (eDockInfo) 0 || (di & eDockInfo.Left) != (eDockInfo) 0 || (di & eDockInfo.Right) != (eDockInfo) 0 || (di & eDockInfo.Tab) != (eDockInfo) 0 || (di & eDockInfo.Top) != (eDockInfo) 0;
  }

  private eDockSide GetDockSideFromDockHint(eDockInfo di)
  {
    if ((di & eDockInfo.Bottom) != (eDockInfo) 0)
      return eDockSide.Bottom;
    if ((di & eDockInfo.Left) != (eDockInfo) 0)
      return eDockSide.Left;
    if ((di & eDockInfo.Right) != (eDockInfo) 0)
      return eDockSide.Right;
    if ((di & eDockInfo.Tab) != (eDockInfo) 0)
      return eDockSide.Tab;
    if ((di & eDockInfo.Top) != (eDockInfo) 0)
      return eDockSide.Top;
    throw new InvalidCastException("Cannot convert eDockInfo di to eDockSide since it contains invalid value.");
  }

  private void RemoveAdorner(DockSiteAdorner da)
  {
    if (da == null)
      return;
    (this.m_DockHintWindow == null ? (!(da.Parent is AdornerLayer) ? AdornerLayer.GetAdornerLayer((Visual) this) : da.Parent as AdornerLayer) : this.m_DockHintWindow.GetAdornerLayer())?.Remove((Adorner) da);
  }

  private void RemoveDockSelectorAdorner(DockSelectorAdorner dsa)
  {
    if (dsa == null)
      return;
    (this.m_DockSelectorWindow == null ? (!(dsa.Parent is AdornerLayer) ? AdornerLayer.GetAdornerLayer((Visual) this) : dsa.Parent as AdornerLayer) : this.m_DockSelectorWindow.GetAdornerLayer())?.Remove((Adorner) dsa);
  }

  private DockSite.DockPositionInfo GetDockPosition(System.Windows.Point mousePos)
  {
    DockWindowGroup dragDockWindowGroup = this.m_DragDockWindowGroup;
    double num = !(dragDockWindowGroup.Parent is SplitPanel) ? DockSite.GetDockSize((UIElement) dragDockWindowGroup) : DockSite.GetDockSize(dragDockWindowGroup.Parent as UIElement);
    if (this.m_DockHintAdorner.DockHintAllSides != null && LayoutInformation.GetLayoutSlot((FrameworkElement) this.m_DockHintAdorner.DockHintAllSides).Contains(mousePos) && this.m_DockHintAdorner.DockHintAllSides is DockHint dockHintAllSides)
    {
      System.Windows.Point p = dockHintAllSides.PointFromScreen(this.PointToScreen(mousePos));
      if (this.m_DockMouseOverElement is DockWindowGroup && ((DockWindowGroup) this.m_DockMouseOverElement).IsFloating)
      {
        FloatingWindow floatingWindow = this.GetFloatingWindow(this.m_DockMouseOverElement);
        if (floatingWindow != null)
          p = dockHintAllSides.PointFromScreen(floatingWindow.PointToScreen(mousePos));
      }
      eDockHintHitTest eDockHintHitTest = dockHintAllSides.HitTest(p);
      if (eDockHintHitTest != eDockHintHitTest.None)
      {
        DockSite.DockPositionInfo dockPosition = new DockSite.DockPositionInfo();
        dockPosition.MouseOverGroup = this.m_DockMouseOverElement as DockWindowGroup;
        Rect allSidesRect = this.m_DockHintAdorner.AllSidesRect;
        bool flag = this.m_DockMouseOverElement != null;
        if (eDockHintHitTest == eDockHintHitTest.Bottom && (dragDockWindowGroup.CanDockBottom || dockPosition.MouseOverGroup != null))
        {
          dockPosition.PositionInfo = eDockInfo.Bottom;
          dockPosition.DockRect = !flag ? new Rect(this.m_DocumentRect.X, this.m_DocumentRect.Bottom - num, this.m_DocumentRect.Width, num) : new Rect(allSidesRect.X, allSidesRect.Bottom - allSidesRect.Height / 2.0, allSidesRect.Width, allSidesRect.Height / 2.0);
        }
        else if (eDockHintHitTest == eDockHintHitTest.Left && (dragDockWindowGroup.CanDockLeft || dockPosition.MouseOverGroup != null))
        {
          dockPosition.DockRect = !flag ? new Rect(this.m_DocumentRect.X, this.m_DocumentRect.Y, num, this.m_DocumentRect.Height) : new Rect(allSidesRect.X, allSidesRect.Y, allSidesRect.Width / 2.0, allSidesRect.Height);
          dockPosition.PositionInfo = eDockInfo.Left;
        }
        else if (eDockHintHitTest == eDockHintHitTest.Right && (dragDockWindowGroup.CanDockRight || dockPosition.MouseOverGroup != null))
        {
          dockPosition.PositionInfo = eDockInfo.Right;
          dockPosition.DockRect = !flag ? new Rect(this.m_DocumentRect.Right - num, this.m_DocumentRect.Y, num, this.m_DocumentRect.Height) : new Rect(allSidesRect.Right - allSidesRect.Width / 2.0, allSidesRect.Y, allSidesRect.Width / 2.0, allSidesRect.Height);
        }
        else if (eDockHintHitTest == eDockHintHitTest.Top && (dragDockWindowGroup.CanDockTop || dockPosition.MouseOverGroup != null))
        {
          dockPosition.PositionInfo = eDockInfo.Top;
          dockPosition.DockRect = !flag ? new Rect(this.m_DocumentRect.X, this.m_DocumentRect.Y, this.m_DocumentRect.Width, num) : new Rect(allSidesRect.X, allSidesRect.Y, allSidesRect.Width, allSidesRect.Height / 2.0);
        }
        else if (eDockHintHitTest == eDockHintHitTest.Tab)
        {
          dockPosition.DockRect = this.m_DockMouseOverElement == null ? this.m_DocumentRect : allSidesRect;
          dockPosition.PositionInfo = eDockInfo.Tab;
        }
        return dockPosition;
      }
    }
    if (this.m_DockHintAdorner.DockHintBottom != null && LayoutInformation.GetLayoutSlot(this.m_DockHintAdorner.DockHintBottom as FrameworkElement).Contains(mousePos))
      return new DockSite.DockPositionInfo()
      {
        PositionInfo = eDockInfo.Outer | eDockInfo.Bottom,
        SplitPanel = (SplitPanel) null,
        DockRect = new Rect(0.0, this.RenderSize.Height - num, this.RenderSize.Width, num)
      };
    if (this.m_DockHintAdorner.DockHintRight != null && LayoutInformation.GetLayoutSlot(this.m_DockHintAdorner.DockHintRight as FrameworkElement).Contains(mousePos))
      return new DockSite.DockPositionInfo()
      {
        PositionInfo = eDockInfo.Outer | eDockInfo.Right,
        SplitPanel = (SplitPanel) null,
        DockRect = new Rect(this.RenderSize.Width - num, 0.0, num, this.RenderSize.Height)
      };
    if (this.m_DockHintAdorner.DockHintLeft != null && LayoutInformation.GetLayoutSlot(this.m_DockHintAdorner.DockHintLeft as FrameworkElement).Contains(mousePos))
      return new DockSite.DockPositionInfo()
      {
        PositionInfo = eDockInfo.Outer | eDockInfo.Left,
        SplitPanel = (SplitPanel) null,
        DockRect = new Rect(0.0, 0.0, num, this.RenderSize.Height)
      };
    if (this.m_DockHintAdorner.DockHintTop == null || !LayoutInformation.GetLayoutSlot(this.m_DockHintAdorner.DockHintTop as FrameworkElement).Contains(mousePos))
      return new DockSite.DockPositionInfo();
    return new DockSite.DockPositionInfo()
    {
      PositionInfo = eDockInfo.Outer | eDockInfo.Top,
      SplitPanel = (SplitPanel) null,
      DockRect = new Rect(0.0, 0.0, this.RenderSize.Width, num)
    };
  }

  public SplitPanel CreateSplitPanel(DockWindowGroup group)
  {
    return this.CreateSplitPanel(group, DockSite.GetDockSize((UIElement) group));
  }

  public SplitPanel CreateSplitPanel(DockWindowGroup group, double size)
  {
    SplitPanel element = new SplitPanel();
    element.Children.Add((UIElement) group);
    if (!double.IsNaN(size))
      DockSite.SetDockSize((UIElement) element, size);
    return element;
  }

  private SplitPanel CreateSplitPanel(SplitPanel group) => this.CreateSplitPanel(group, double.NaN);

  private SplitPanel CreateSplitPanel(SplitPanel sp, double size)
  {
    SplitPanel element = new SplitPanel();
    element.Children.Add((UIElement) sp);
    if (!double.IsNaN(size))
      DockSite.SetDockSize((UIElement) element, size);
    return element;
  }

  public void RestoreLastDockPosition(DockWindowGroup dg)
  {
    this.RestoreLastDockPosition(dg, false);
  }

  public void RestoreLastDockPosition(DockWindowGroup dg, bool focusSelectedDockWindow)
  {
    this.RestoreLastDockPosition(dg, focusSelectedDockWindow, eEventActionSource.Code);
  }

  public void RestoreLastDockPosition(
    DockWindowGroup dg,
    bool focusSelectedDockWindow,
    eEventActionSource actionSource)
  {
    bool flag = false;
    if (dg.IsFloating)
    {
      FloatingWindow floatingWindow = this.GetFloatingWindow((UIElement) dg);
      if (floatingWindow != null && floatingWindow.IsActive)
        this.ActivateParentWindow();
    }
    if (dg.LastDockReferenceId == "")
    {
      flag = this.DockWindow(dg, dg.LastDockSide, dg.LastDockIsFullSizeDock, actionSource, true);
    }
    else
    {
      UIElement dockElementFromId = this.GetDockElementFromId(dg.LastDockReferenceId);
      if (dockElementFromId == null)
      {
        flag = this.DockWindow(dg, dg.LastIsDocument ? eDockSide.Tab : dg.LastDockSide, actionSource, true);
      }
      else
      {
        if (dockElementFromId is DockWindowGroup)
          flag = this.DockWindow(dg, dockElementFromId as DockWindowGroup, dg.LastDockReference, actionSource, true);
        else if (dockElementFromId is SplitPanel)
          flag = this.DockWindow(dg, dockElementFromId as SplitPanel, dg.LastDockReference, actionSource, true);
        if (flag & focusSelectedDockWindow && dockElementFromId is DockWindowGroup)
        {
          if (((DockWindowGroup) dockElementFromId).SelectedDockWindow != null)
            ((DockWindowGroup) dockElementFromId).SelectedDockWindow.Focus();
          focusSelectedDockWindow = false;
        }
      }
    }
    if (!(focusSelectedDockWindow & flag) || dg.SelectedDockWindow == null)
      return;
    dg.SelectedDockWindow.FocusContent();
  }

  private void ActivateParentWindow()
  {
    Window window = Window.GetWindow((DependencyObject) this);
    if (window == null || window.IsActive)
      return;
    window.Activate();
  }

  private void RestoreLastDockPosition(DevComponents.WpfDock.DockWindow dw)
  {
    if (!(this.GetDockElementFromId(dw.LastDockWindowGroupId) is DockWindowGroup dockElementFromId) || dockElementFromId == dw.ParentGroup && dockElementFromId.VisibleItemsCount > 1)
    {
      DockWindowGroup parentGroup = dw.ParentGroup;
      DockWindowGroup group = new DockWindowGroup();
      this.Detach(dw);
      group.Items.Add((object) dw);
      if (!this.DockWindow(group, DockSite.GetDockSideFromDock(dw.LastDock)))
      {
        this.Detach(dw);
        parentGroup.Items.Add((object) dw);
      }
      else
        this.RemoveEmptyElements(parentGroup);
    }
    else if (dockElementFromId == dw.ParentGroup && dockElementFromId.VisibleItemsCount == 1)
    {
      this.DockWindow(dockElementFromId, DockSite.GetDockSideFromDock(dw.LastDock));
    }
    else
    {
      DockWindowGroup parentGroup = dw.ParentGroup;
      DockWindowGroup group = new DockWindowGroup();
      this.Detach(dw);
      group.Items.Add((object) dw);
      if (!this.DockWindow(group, dockElementFromId, eDockSide.Tab))
      {
        this.Detach(dw);
        parentGroup.Items.Add((object) dw);
      }
      else
      {
        this.RemoveEmptyElements(parentGroup);
        dockElementFromId.UpdateVisibility();
      }
    }
  }

  private void RemoveEmptyElements(DockWindowGroup referenceGroup)
  {
    if (referenceGroup.Items.Count > 0)
      return;
    this.Detach(referenceGroup);
  }

  private UIElement GetDockElementFromId(string id)
  {
    if (id == "")
      return (UIElement) null;
    SplitPanel content = this.Content as SplitPanel;
    SplitPanel[] array = new SplitPanel[this.SplitPanels.Count + (content != null ? 1 : 0)];
    this.SplitPanels.CopyTo(array, 0);
    if (content != null)
      array[array.Length - 1] = content;
    foreach (SplitPanel panel in array)
    {
      if (panel.Id == id)
        return (UIElement) panel;
      UIElement dockElementFromId = this.GetDockElementFromId(panel, id);
      if (dockElementFromId != null)
        return dockElementFromId;
    }
    return (UIElement) null;
  }

  private UIElement GetDockElementFromId(SplitPanel panel, string id)
  {
    foreach (UIElement child in (Collection<UIElement>) panel.Children)
    {
      if (child is DockWindowGroup dockElementFromId1 && dockElementFromId1.Id == id)
        return (UIElement) dockElementFromId1;
      if (child is SplitPanel panel1)
      {
        if (panel1.Id == id)
          return (UIElement) panel1;
        UIElement dockElementFromId2 = this.GetDockElementFromId(panel1, id);
        if (dockElementFromId2 != null)
          return dockElementFromId2;
      }
    }
    return (UIElement) null;
  }

  public bool DockWindow(DockWindowGroup group, eDockSide dockSide, bool fullSize)
  {
    return this.DockWindow(group, dockSide, fullSize, eEventActionSource.Code, true);
  }

  public bool DockWindow(
    DockWindowGroup group,
    eDockSide dockSide,
    bool fullSize,
    eEventActionSource actionSource,
    bool raiseEvents)
  {
    BeforeDockedRoutedEventArgs dockEndsArgs = new BeforeDockedRoutedEventArgs(DockSite.BeforeDockedEvent, (object) this, (object) group, actionSource, false, dockSide, (DockWindowGroup) null);
    if (dockSide == eDockSide.Tab)
    {
      if (!group.CanDockAsDocument)
        return false;
      if (raiseEvents)
      {
        this.OnBeforeDocked(dockEndsArgs);
        if (dockEndsArgs.Cancel)
          return false;
      }
      this.Detach(group);
      DockWindowGroup dockDocumentGroup = this.FindTargetDockDocumentGroup();
      if (dockDocumentGroup != null)
      {
        object[] objArray = new object[group.Items.Count];
        group.Items.CopyTo((Array) objArray, 0);
        foreach (object obj in objArray)
        {
          group.Items.Remove(obj);
          dockDocumentGroup.Items.Add(obj);
        }
      }
      else
        this.Content = (object) this.CreateSplitPanel(group);
      this.UpdateIsDocument();
      if (raiseEvents)
        this.OnAfterDocked(new DockRoutedEventArgs(DockSite.AfterDockedEvent, (object) this, (object) (dockDocumentGroup ?? group), actionSource));
      return true;
    }
    Dock dockFromDockSide = DockSite.GetDockFromDockSide(dockSide);
    if (dockFromDockSide == Dock.Left && !group.CanDockLeft || dockFromDockSide == Dock.Bottom && !group.CanDockBottom || dockFromDockSide == Dock.Right && !group.CanDockRight || dockFromDockSide == Dock.Top && !group.CanDockTop)
      return false;
    if (raiseEvents)
    {
      this.OnBeforeDocked(dockEndsArgs);
      if (dockEndsArgs.Cancel)
        return false;
    }
    SplitPanel splitPanel;
    if (group.Parent is SplitPanel && ((SplitPanel) group.Parent).Children.Count == 1)
    {
      splitPanel = group.Parent as SplitPanel;
      this.Detach(splitPanel);
    }
    else
    {
      this.Detach(group);
      splitPanel = this.CreateSplitPanel(group);
    }
    group.IsFloating = false;
    if (fullSize)
      this.SplitPanels.Insert(0, splitPanel);
    else
      this.SplitPanels.Add(splitPanel);
    DockSite.SetDock((UIElement) splitPanel, dockFromDockSide);
    group.InvalidateMeasure();
    if (this.AnimationEnabled)
    {
      DoubleAnimation animation = new DoubleAnimation(0.0, 1.0, new Duration(TimeSpan.FromMilliseconds(350.0)), FillBehavior.Stop);
      group.BeginAnimation(UIElement.OpacityProperty, (AnimationTimeline) animation);
    }
    if (raiseEvents)
      this.OnAfterDocked(new DockRoutedEventArgs(DockSite.AfterDockedEvent, (object) this, (object) group, actionSource));
    return true;
  }

  public bool DockWindow(DevComponents.WpfDock.DockWindow dw, eDockSide dockSide)
  {
    return this.DockWindow(dw, dockSide, eEventActionSource.Code, true);
  }

  public bool DockWindow(
    DevComponents.WpfDock.DockWindow dw,
    eDockSide dockSide,
    eEventActionSource actionSource,
    bool raiseEvents)
  {
    return this.DockWindow(dw, dockSide, false, actionSource, raiseEvents);
  }

  public bool DockWindow(DevComponents.WpfDock.DockWindow dw, DockWindowGroup referenceGroup, eDockSide dockSide)
  {
    return this.DockWindow(dw, referenceGroup, dockSide, eEventActionSource.Code, true);
  }

  public bool DockWindow(
    DevComponents.WpfDock.DockWindow dw,
    DockWindowGroup referenceGroup,
    eDockSide dockSide,
    eEventActionSource actionSource,
    bool raiseEvents)
  {
    DockWindowGroup parentGroup = dw.ParentGroup;
    DockWindowGroup group = new DockWindowGroup();
    int insertIndex = -1;
    if (parentGroup != null)
      insertIndex = parentGroup.Items.IndexOf((object) group);
    this.Detach(dw);
    group.Items.Add((object) dw);
    if (this.DockWindowInternal(group, (UIElement) referenceGroup, dockSide, actionSource, raiseEvents))
      return true;
    this.Detach(dw);
    parentGroup?.Items.Insert(insertIndex, (object) dw);
    return false;
  }

  public bool DockWindow(
    DevComponents.WpfDock.DockWindow dw,
    eDockSide dockSide,
    bool fullSize,
    eEventActionSource actionSource,
    bool raiseEvents)
  {
    DockWindowGroup parentGroup = dw.ParentGroup;
    DockWindowGroup group = new DockWindowGroup();
    int insertIndex = -1;
    if (parentGroup != null)
      insertIndex = parentGroup.Items.IndexOf((object) group);
    this.Detach(dw);
    group.Items.Add((object) dw);
    if (this.DockWindow(group, dockSide, fullSize, actionSource, raiseEvents))
      return true;
    this.Detach(dw);
    parentGroup?.Items.Insert(insertIndex, (object) dw);
    return false;
  }

  public bool DockWindow(DockWindowGroup group, eDockSide dockSide)
  {
    return this.DockWindow(group, dockSide, eEventActionSource.Code, true);
  }

  public bool DockWindow(
    DockWindowGroup group,
    eDockSide dockSide,
    eEventActionSource actionSource,
    bool raiseEvents)
  {
    return this.DockWindow(group, dockSide, false, actionSource, raiseEvents);
  }

  public bool DockWindow(DockWindowGroup group, DockWindowGroup referenceGroup, eDockSide dockSide)
  {
    return this.DockWindow(group, referenceGroup, dockSide, eEventActionSource.Code, true);
  }

  public bool DockWindow(
    DockWindowGroup group,
    DockWindowGroup referenceGroup,
    eDockSide dockSide,
    eEventActionSource actionSource,
    bool raiseEvents)
  {
    return this.DockWindowInternal(group, (UIElement) referenceGroup, dockSide, actionSource, raiseEvents);
  }

  public bool DockWindow(DockWindowGroup group, SplitPanel sp, eDockSide dockSide)
  {
    return this.DockWindow(group, sp, dockSide, eEventActionSource.Code, true);
  }

  public bool DockWindow(
    DockWindowGroup group,
    SplitPanel sp,
    eDockSide dockSide,
    eEventActionSource actionSource,
    bool raiseEvents)
  {
    return this.DockWindowInternal(group, (UIElement) sp, dockSide, actionSource, raiseEvents);
  }

  private bool DockWindowInternal(
    DockWindowGroup group,
    UIElement referenceElem,
    eDockSide dockSide,
    eEventActionSource actionSource,
    bool raiseEvents)
  {
    SplitPanel splitPanel1 = (SplitPanel) null;
    if (referenceElem is FrameworkElement)
      splitPanel1 = ((FrameworkElement) referenceElem).Parent as SplitPanel;
    if (splitPanel1 == null)
      throw new NullReferenceException("The referenceElem.Parent is not SplitPanel. The referenceElem must be already docked to be used as reference");
    if (raiseEvents)
    {
      BeforeDockedRoutedEventArgs dockEndsArgs = new BeforeDockedRoutedEventArgs(DockSite.BeforeDockedEvent, (object) this, (object) group, actionSource, false, dockSide, referenceElem as DockWindowGroup);
      this.OnBeforeDocked(dockEndsArgs);
      if (dockEndsArgs.Cancel)
        return false;
    }
    bool isFloating = group.IsFloating;
    this.Detach(group);
    if (!(((FrameworkElement) referenceElem).Parent is SplitPanel parent))
      throw new NullReferenceException("The referenceElem.Parent SplitPanel parent lost due to cleanup");
    group.IsFloating = false;
    if (dockSide == eDockSide.Tab)
    {
      DockWindowGroup dockWindowGroup = referenceElem is DockWindowGroup ? referenceElem as DockWindowGroup : throw new InvalidOperationException("referenceElem is not DockWindowGroup type. Only DockWindowGroup type can be reference for Tab docking");
      object[] objArray = (object[]) new UIElement[group.Items.Count];
      group.Items.CopyTo((Array) objArray, 0);
      group.Items.Clear();
      foreach (object newItem in objArray)
        dockWindowGroup.Items.Add(newItem);
      this.UpdateIsDocument(group);
      this.UpdateIsDocument(dockWindowGroup);
      if (dockWindowGroup.Visibility != Visibility.Visible)
      {
        dockWindowGroup.Visibility = Visibility.Visible;
        dockWindowGroup.SelectNextTab(true);
      }
      if (raiseEvents)
        this.OnAfterDocked(new DockRoutedEventArgs(DockSite.AfterDockedEvent, (object) this, (object) dockWindowGroup, actionSource));
      return true;
    }
    if (parent.Orientation == Orientation.Horizontal && (dockSide == eDockSide.Left || dockSide == eDockSide.Right) || parent.Orientation == Orientation.Vertical && (dockSide == eDockSide.Top || dockSide == eDockSide.Bottom))
    {
      int index = parent.Children.IndexOf(referenceElem);
      if (dockSide == eDockSide.Right || dockSide == eDockSide.Bottom)
        ++index;
      if (isFloating)
      {
        object[] objArray = new object[group.Items.Count];
        int selectedIndex = group.SelectedIndex;
        group.Items.CopyTo((Array) objArray, 0);
        group.Items.Clear();
        parent.Children.Insert(index, (UIElement) group);
        foreach (object newItem in objArray)
          group.Items.Add(newItem);
        group.SelectedIndex = selectedIndex;
      }
      else
        parent.Children.Insert(index, (UIElement) group);
      this.UpdateIsDocument(group);
      if (this.AnimationEnabled)
      {
        DoubleAnimation animation = new DoubleAnimation(0.0, 1.0, new Duration(TimeSpan.FromMilliseconds(350.0)), FillBehavior.Stop);
        group.BeginAnimation(UIElement.OpacityProperty, (AnimationTimeline) animation);
      }
      if (raiseEvents)
        this.OnAfterDocked(new DockRoutedEventArgs(DockSite.AfterDockedEvent, (object) this, (object) group, actionSource));
      return true;
    }
    if (parent.Children.Count == 1)
    {
      parent.Orientation = parent.Orientation != Orientation.Vertical ? Orientation.Vertical : Orientation.Horizontal;
      int index = parent.Children.IndexOf(referenceElem);
      if (dockSide == eDockSide.Bottom || dockSide == eDockSide.Right)
        ++index;
      parent.Children.Insert(index, (UIElement) group);
    }
    else
    {
      int index1 = parent.Children.IndexOf(referenceElem);
      SplitPanel splitPanel2 = (SplitPanel) null;
      switch (referenceElem)
      {
        case DockWindowGroup _:
          this.Detach(referenceElem as DockWindowGroup, false);
          splitPanel2 = this.CreateSplitPanel(referenceElem as DockWindowGroup);
          break;
        case SplitPanel _:
          this.Detach(referenceElem as SplitPanel);
          splitPanel2 = this.CreateSplitPanel(referenceElem as SplitPanel);
          break;
      }
      splitPanel2.Orientation = parent.Orientation != Orientation.Vertical ? Orientation.Vertical : Orientation.Horizontal;
      int index2 = splitPanel2.Children.IndexOf(referenceElem);
      if (dockSide == eDockSide.Bottom || dockSide == eDockSide.Right)
        ++index2;
      splitPanel2.Children.Insert(index2, (UIElement) group);
      parent.Children.Insert(index1, (UIElement) splitPanel2);
    }
    this.UpdateIsDocument(group);
    if (DockSite.GetIsDocument((UIElement) group))
      this.UpdateIsDocument();
    if (this.AnimationEnabled)
    {
      DoubleAnimation animation = new DoubleAnimation(0.0, 1.0, new Duration(TimeSpan.FromMilliseconds(350.0)), FillBehavior.Stop);
      group.BeginAnimation(UIElement.OpacityProperty, (AnimationTimeline) animation);
    }
    if (raiseEvents)
      this.OnAfterDocked(new DockRoutedEventArgs(DockSite.AfterDockedEvent, (object) this, (object) group, actionSource));
    return true;
  }

  internal bool AnimationEnabled
  {
    get
    {
      return SystemParameters.PowerLineStatus == PowerLineStatus.Online && SystemParameters.ClientAreaAnimation && RenderCapability.Tier > 0 && !this.IsDesignMode && this.IsEnabled && this.IsAnimationEnabled && !this._InternalAnimationDisabled;
    }
  }

  private bool IsDesignMode => DesignerProperties.GetIsInDesignMode((DependencyObject) this);

  [EditorBrowsable(EditorBrowsableState.Never)]
  public void UpdateIsDocument()
  {
    if (!(this.Content is SplitPanel content))
      return;
    this.UpdateIsDocument(content, true);
  }

  internal void UpdateIsDocument(SplitPanel sp, bool isDocument)
  {
    DockSite.SetIsDocument((UIElement) sp, isDocument);
    foreach (UIElement child in (Collection<UIElement>) sp.Children)
    {
      DockSite.SetIsDocument(child, isDocument);
      if (child is DockWindowGroup)
        this.UpdateIsDocument(child as DockWindowGroup, isDocument);
      else if (child is SplitPanel)
        this.UpdateIsDocument(child as SplitPanel, isDocument);
    }
  }

  private void UpdateIsDocument(DockWindowGroup group, bool isDocument)
  {
    DockSite.SetIsDocument((UIElement) group, isDocument);
    foreach (object obj in (IEnumerable) group.Items)
    {
      UIElement element = obj as UIElement;
      if (!(obj is DevComponents.WpfDock.DockWindow))
        element = group.ItemContainerGenerator.ContainerFromItem(obj) as UIElement;
      if (element != null)
        DockSite.SetIsDocument(element, isDocument);
    }
  }

  [EditorBrowsable(EditorBrowsableState.Never)]
  public void UpdateIsDocument(DockWindowGroup group)
  {
    this.UpdateIsDocument(group, this.IsDockedAsDocument(group));
  }

  private bool IsDockedAsDocument(DockWindowGroup group)
  {
    if (group == null)
      return false;
    for (SplitPanel parent = group.Parent as SplitPanel; parent != null; parent = parent.Parent as SplitPanel)
    {
      if (this.Content == parent)
        return true;
    }
    return false;
  }

  public void Detach(DockWindowGroup group) => this.Detach(group, true);

  private void Detach(DockWindowGroup group, bool pruneRedundantPanels)
  {
    if (group.Parent == null)
      return;
    if (group.Parent is SplitPanel)
    {
      int selectedIndex = group.SelectedIndex;
      group.SelectedIndex = -1;
      SplitPanel parent1 = group.Parent as SplitPanel;
      parent1.Children.Remove((UIElement) group);
      if (parent1.Children.Count == 0)
        this.Detach(parent1);
      else if (parent1.VisibleItemsCount == 0)
        parent1.UpdateAutoVisibility();
      else if (pruneRedundantPanels && parent1.Parent is SplitPanel && (((SplitPanel) parent1.Parent).Orientation == parent1.Orientation || parent1.Children.Count == 1))
      {
        SplitPanel parent2 = parent1.Parent as SplitPanel;
        int num = parent2.Children.IndexOf((UIElement) parent1);
        UIElement[] array = new UIElement[parent1.Children.Count];
        parent1.Children.CopyTo(array, 0);
        parent1.Children.Clear();
        for (int index = 0; index < array.Length; ++index)
          parent2.Children.Insert(num + index, array[index]);
        this.Detach(parent1);
      }
      else if (pruneRedundantPanels && parent1.Children.Count == 1 && parent1.Children[0] is SplitPanel)
      {
        SplitPanel child = (SplitPanel) parent1.Children[0];
        UIElement[] array = new UIElement[child.Children.Count];
        child.Children.CopyTo(array, 0);
        child.Children.Clear();
        parent1.Orientation = child.Orientation;
        for (int index = 0; index < array.Length; ++index)
          parent1.Children.Add(array[index]);
        this.Detach(child);
      }
      group.SelectedIndex = selectedIndex;
    }
    else if (group.Parent is FloatingWindow)
    {
      FloatingWindow parent = group.Parent as FloatingWindow;
      group.FloatingRect = new Rect(parent.Left, parent.Top, parent.Width, parent.Height);
      BindingOperations.ClearAllBindings((DependencyObject) parent);
      parent.Content = (object) null;
      parent.Width = 0.0;
      parent.Close();
      group.IsFloating = false;
    }
    else if (group.Parent is DockSite)
      ((ContentControl) group.Parent).Content = (object) null;
    this.UpdateIsDocument(group);
  }

  public void Detach(SplitPanel sp)
  {
    if (sp.Parent == null)
      return;
    if (sp.Parent is SplitPanel)
    {
      SplitPanel parent = sp.Parent as SplitPanel;
      parent.Children.Remove((UIElement) sp);
      if (parent.Children.Count != 0)
        return;
      this.Detach(parent);
    }
    else if (sp.Parent is DockSite)
    {
      DockSite parent = sp.Parent as DockSite;
      if (parent.Content == sp)
        parent.Content = (object) null;
      else
        parent.SplitPanels.Remove(sp);
    }
    else
    {
      if (!(sp.Parent is FloatingWindow))
        return;
      FloatingWindow parent = sp.Parent as FloatingWindow;
      parent.Content = (object) null;
      parent.Close();
    }
  }

  public void Detach(DevComponents.WpfDock.DockWindow dw)
  {
    if (!(dw.Parent is DockWindowGroup parent))
      return;
    if (parent.SelectedItem == dw)
      this.SelectDifferentTab(parent);
    parent.Items.Remove((object) dw);
    if (parent.Items.Count == 0)
      this.Detach(parent);
    DockSite.SetIsDocument((UIElement) dw, false);
  }

  internal static eDockSide GetDockSideFromDock(Dock dock)
  {
    switch (dock)
    {
      case Dock.Left:
        return eDockSide.Left;
      case Dock.Right:
        return eDockSide.Right;
      case Dock.Bottom:
        return eDockSide.Bottom;
      default:
        return eDockSide.Top;
    }
  }

  private static Dock GetDockFromDockSide(eDockSide dockSide)
  {
    switch (dockSide)
    {
      case eDockSide.Top:
        return Dock.Top;
      case eDockSide.Bottom:
        return Dock.Bottom;
      case eDockSide.Left:
        return Dock.Left;
      case eDockSide.Right:
        return Dock.Right;
      default:
        throw new InvalidCastException("Cannot convert dockSide to Dock. DockSide has an invalid value");
    }
  }

  public AutoHidePanel GetAutoHidePanel(Dock d)
  {
    switch (d)
    {
      case Dock.Left:
        if (this.m_LeftAutoHidePanel == null)
          this.m_LeftAutoHidePanel = this.CreateAutoHidePanel(d);
        return this.m_LeftAutoHidePanel;
      case Dock.Top:
        if (this.m_TopAutoHidePanel == null)
          this.m_TopAutoHidePanel = this.CreateAutoHidePanel(d);
        return this.m_TopAutoHidePanel;
      case Dock.Right:
        if (this.m_RightAutoHidePanel == null)
          this.m_RightAutoHidePanel = this.CreateAutoHidePanel(d);
        return this.m_RightAutoHidePanel;
      case Dock.Bottom:
        if (this.m_BottomAutoHidePanel == null)
          this.m_BottomAutoHidePanel = this.CreateAutoHidePanel(d);
        return this.m_BottomAutoHidePanel;
      default:
        return (AutoHidePanel) null;
    }
  }

  private AutoHidePanel CreateAutoHidePanel(Dock d)
  {
    AutoHidePanel element = new AutoHidePanel();
    DockSite.SetDock((UIElement) element, d);
    element.TabOrientation = d == Dock.Left || d == Dock.Right ? Orientation.Vertical : Orientation.Horizontal;
    this.m_Children.Add((UIElement) element);
    this.InvalidateMeasure();
    return element;
  }

  internal void SetAutoHide(DevComponents.WpfDock.DockWindow dw, bool autoHide, eEventActionSource actionSource)
  {
    this.SetAutoHide(dw, autoHide, actionSource, true);
  }

  internal void SetAutoHide(
    DevComponents.WpfDock.DockWindow dw,
    bool autoHide,
    eEventActionSource actionSource,
    bool enableAnimation)
  {
    this.SetAutoHide(dw, autoHide, actionSource, enableAnimation, this.GetDockFromDockWindow(dw));
  }

  internal void SetAutoHide(
    DevComponents.WpfDock.DockWindow dw,
    bool autoHide,
    eEventActionSource actionSource,
    bool enableAnimation,
    Dock d)
  {
    AutoHidePanel autoHidePanel = this.GetAutoHidePanel(d);
    bool flag = this.AnimationEnabled & enableAnimation;
    if (autoHide)
    {
      DockSite.SetDock((UIElement) dw, d);
      DockWindowGroup parent = dw.Parent as DockWindowGroup;
      dw.LastDock = d;
      Rect rect = new Rect();
      SnapshotImage snapshotImage = (SnapshotImage) null;
      if (parent != null & flag && (parent.InnerContent != null || parent.SelectedContent is UIElement))
      {
        rect = LayoutHelpers.GetBounds((UIElement) parent, (UIElement) this);
        snapshotImage = new SnapshotImage();
        if (parent.InnerContent != null)
          snapshotImage.TakeSnapshot(parent.InnerContent);
        else
          snapshotImage.TakeSnapshot(parent.SelectedContent as UIElement);
      }
      if (parent != null)
      {
        dw.LastDockWindowGroupId = parent.Id;
        dw.LastDockedSize = parent.RenderSize;
        if (parent.SelectedItem == dw)
          this.SelectDifferentTab(parent);
        parent.Items.Remove((object) dw);
        if (parent.Items.Count == 0)
        {
          this.SaveCurrentDockInfo(parent);
          this.Detach(parent);
          dw.LastDockWindowGroup = parent;
        }
        else if (parent.VisibleItemsCount == 0)
          parent.UpdateVisibility();
      }
      int insertIndex = autoHidePanel.Items.Count;
      bool doc = insertIndex != 0;
      for (int index = 0; index < autoHidePanel.Items.Count; ++index)
      {
        if (autoHidePanel.Items[index] is DevComponents.WpfDock.DockWindow dockWindow && dockWindow.LastDockWindowGroupId == dw.LastDockWindowGroupId)
        {
          insertIndex = index;
          doc = false;
          break;
        }
      }
      AutoHidePanel.SetIsBeginGroup((UIElement) dw, doc);
      autoHidePanel.Items.Insert(insertIndex, (object) dw);
      if (!flag || snapshotImage == null)
        return;
      this.UpdateLayout();
      VisualBrush visualBrush = new VisualBrush(dw.Content as Visual);
      this.GetAutoHideAdorner().Children.Add((UIElement) snapshotImage);
      AutoHideAdorner.SetLeft((UIElement) snapshotImage, rect.Left);
      AutoHideAdorner.SetTop((UIElement) snapshotImage, rect.Top);
      AutoHideAdorner.SetRight((UIElement) snapshotImage, rect.Right);
      AutoHideAdorner.SetBottom((UIElement) snapshotImage, rect.Bottom);
      Rect bounds = LayoutHelpers.GetBounds((UIElement) dw, (UIElement) this);
      double num1 = 0.3;
      double num2 = 300.0;
      Storyboard storyboard = new Storyboard();
      storyboard.AccelerationRatio = num1;
      if (!LayoutHelpers.IsClose(bounds.Top, rect.Top))
      {
        DoubleAnimation element = new DoubleAnimation(bounds.Top, new Duration(TimeSpan.FromMilliseconds(num2)));
        Storyboard.SetTargetProperty((DependencyObject) element, new PropertyPath((object) AutoHideAdorner.TopProperty));
        storyboard.Children.Add((Timeline) element);
      }
      if (!LayoutHelpers.IsClose(bounds.Bottom, rect.Bottom))
      {
        DoubleAnimation element = new DoubleAnimation(bounds.Bottom, new Duration(TimeSpan.FromMilliseconds(num2)));
        Storyboard.SetTargetProperty((DependencyObject) element, new PropertyPath((object) AutoHideAdorner.BottomProperty));
        storyboard.Children.Add((Timeline) element);
      }
      if (!LayoutHelpers.IsClose(bounds.Left, rect.Left))
      {
        DoubleAnimation element = new DoubleAnimation(bounds.Left, new Duration(TimeSpan.FromMilliseconds(num2)));
        Storyboard.SetTargetProperty((DependencyObject) element, new PropertyPath((object) AutoHideAdorner.LeftProperty));
        storyboard.Children.Add((Timeline) element);
      }
      if (!LayoutHelpers.IsClose(bounds.Right, rect.Right))
      {
        DoubleAnimation element = new DoubleAnimation(bounds.Left, new Duration(TimeSpan.FromMilliseconds(num2)));
        Storyboard.SetTargetProperty((DependencyObject) element, new PropertyPath((object) AutoHideAdorner.RightProperty));
        storyboard.Children.Add((Timeline) element);
      }
      DoubleAnimation element1 = new DoubleAnimation(0.0, new Duration(TimeSpan.FromMilliseconds(num2)));
      Storyboard.SetTargetProperty((DependencyObject) element1, new PropertyPath((object) UIElement.OpacityProperty));
      storyboard.Children.Add((Timeline) element1);
      storyboard.Completed += new EventHandler(snapshotImage.RemoveOnAnimationCompleted);
      storyboard.Begin((FrameworkElement) snapshotImage);
    }
    else
    {
      if (dw.AutoHideOpen)
      {
        this._InternalAnimationDisabled = true;
        dw.AutoHideOpen = false;
        this._InternalAnimationDisabled = false;
      }
      autoHidePanel.Items.Remove((object) dw);
      dw.LastAutoHideSize = new Size();
      if (dw.LastDockWindowGroup == null && this.GetDockElementFromId(dw.LastDockWindowGroupId) == null)
      {
        foreach (object obj in (IEnumerable) autoHidePanel.Items)
        {
          if (obj is DevComponents.WpfDock.DockWindow dockWindow && dockWindow.LastDockWindowGroupId == dw.LastDockWindowGroupId && dockWindow.LastDockWindowGroup != null)
          {
            dw.LastDockWindowGroup = dockWindow.LastDockWindowGroup;
            dockWindow.LastDockWindowGroup = (DockWindowGroup) null;
            break;
          }
        }
      }
      if (dw.LastDockWindowGroup != null)
      {
        DockWindowGroup lastDockWindowGroup = dw.LastDockWindowGroup;
        lastDockWindowGroup.Items.Add((object) dw);
        lastDockWindowGroup.UpdateVisibility();
        this.RestoreLastDockPosition(lastDockWindowGroup);
        lastDockWindowGroup.SelectedItem = (object) dw;
        dw.PreviousGroup = lastDockWindowGroup;
      }
      else
      {
        if (this.GetDockElementFromId(dw.LastDockWindowGroupId) is DockWindowGroup dockWindowGroup && this.GetDockFromDockWindowGroup(dockWindowGroup) == d)
        {
          dockWindowGroup.Items.Add((object) dw);
        }
        else
        {
          dockWindowGroup = new DockWindowGroup();
          dockWindowGroup.Items.Add((object) dw);
          this.DockWindow(dockWindowGroup, DockSite.GetDockSideFromDock(d), false, actionSource, true);
        }
        dockWindowGroup.SelectedItem = (object) dw;
        dockWindowGroup.UpdateVisibility();
        dw.PreviousGroup = dockWindowGroup;
      }
      dw.LastDockWindowGroup = (DockWindowGroup) null;
      dw.LastDockWindowGroupId = "";
      if (dw.FocusContent())
        return;
      this.Focus();
    }
  }

  public Dock GetDockFromDockWindow(DevComponents.WpfDock.DockWindow dw)
  {
    if (dw.IsFloating)
      return DockSite.GetDockFromDockSide(((DockWindowGroup) dw.Parent).LastDockSide);
    for (FrameworkElement element = (FrameworkElement) dw; element != null; element = element.Parent as FrameworkElement)
    {
      if (element.Parent is DockSite)
        return DockSite.GetDock((UIElement) element);
    }
    return Dock.Left;
  }

  internal Dock GetDockFromDockWindowGroup(DockWindowGroup dw)
  {
    for (FrameworkElement element = (FrameworkElement) dw; element != null; element = element.Parent as FrameworkElement)
    {
      if (element.Parent is DockSite)
        return DockSite.GetDock((UIElement) element);
    }
    return Dock.Left;
  }

  private void ExecuteToggleAutoHide(object sender, ExecutedRoutedEventArgs e)
  {
    if (e.Source is DevComponents.WpfDock.DockWindow)
    {
      DevComponents.WpfDock.DockWindow source = e.Source as DevComponents.WpfDock.DockWindow;
      source.IsAutoHide = !source.IsAutoHide;
    }
    e.Handled = true;
  }

  private void CanExecuteToggleAutoHide(object sender, CanExecuteRoutedEventArgs e)
  {
    e.CanExecute = e.Source is DevComponents.WpfDock.DockWindow source && !source.IsFloating && (!this.GetIsDocumentElement((UIElement) source) || source.IsAutoHide);
    e.Handled = true;
    e.ContinueRouting = false;
  }

  private void ExecuteOpenAutoHide(object sender, ExecutedRoutedEventArgs e)
  {
    if (e.Source is DevComponents.WpfDock.DockWindow)
    {
      DevComponents.WpfDock.DockWindow source = e.Source as DevComponents.WpfDock.DockWindow;
      if (!source.AutoHideOpen)
        source.AutoHideOpen = true;
    }
    e.Handled = true;
  }

  private void CanExecuteOpenAutoHide(object sender, CanExecuteRoutedEventArgs e)
  {
    e.CanExecute = e.Source is DevComponents.WpfDock.DockWindow source && !source.IsFloating && (!this.GetIsDocumentElement((UIElement) source) || source.IsAutoHide) && !source.AutoHideOpen;
    e.Handled = true;
    e.ContinueRouting = false;
  }

  private void ExecuteCloseAutoHide(object sender, ExecutedRoutedEventArgs e)
  {
    if (e.Source is DevComponents.WpfDock.DockWindow)
    {
      DevComponents.WpfDock.DockWindow source = e.Source as DevComponents.WpfDock.DockWindow;
      if (source.AutoHideOpen)
        source.AutoHideOpen = false;
    }
    e.Handled = true;
  }

  private void CanExecuteCloseAutoHide(object sender, CanExecuteRoutedEventArgs e)
  {
    e.CanExecute = e.Source is DevComponents.WpfDock.DockWindow source && !source.IsFloating && (!this.GetIsDocumentElement((UIElement) source) || source.IsAutoHide) && source.AutoHideOpen;
    e.Handled = true;
    e.ContinueRouting = false;
  }

  private void ExecuteCloseWindow(object sender, ExecutedRoutedEventArgs e)
  {
    if (e.Source is DevComponents.WpfDock.DockWindow)
    {
      DevComponents.WpfDock.DockWindow source = e.Source as DevComponents.WpfDock.DockWindow;
      if (source.CanClose)
        source.Close();
    }
    else if (e.Source is DockWindowGroup)
    {
      DockWindowGroup source = (DockWindowGroup) e.Source;
      if (source.SelectedDockWindow != null && source.SelectedDockWindow.CanClose)
        source.SelectedDockWindow.Close();
    }
    e.Handled = true;
  }

  private void CanExecuteCloseWindow(object sender, CanExecuteRoutedEventArgs e)
  {
    DevComponents.WpfDock.DockWindow source1 = e.Source as DevComponents.WpfDock.DockWindow;
    DockWindowGroup source2 = e.Source as DockWindowGroup;
    e.CanExecute = source1 == null ? source2 != null && source2.CanClose : source1.CanClose;
    e.Handled = true;
    e.ContinueRouting = false;
  }

  private void ExecuteReDockWindow(object sender, ExecutedRoutedEventArgs e)
  {
    if (e.Source is DevComponents.WpfDock.DockWindow)
    {
      DevComponents.WpfDock.DockWindow source = e.Source as DevComponents.WpfDock.DockWindow;
      if (!source.IsAutoHide && source.IsFloating)
      {
        DockWindowGroup parentGroup = source.ParentGroup;
        if (parentGroup != null)
          this.RestoreLastDockPosition(parentGroup);
      }
      else if (!source.IsAutoHide && DockSite.GetIsDocument((UIElement) source))
        this.RestoreLastDockPosition(source);
    }
    e.Handled = true;
  }

  private void CanExecuteReDockWindow(object sender, CanExecuteRoutedEventArgs e)
  {
    e.CanExecute = e.Source is DevComponents.WpfDock.DockWindow source && (!DockSite.GetIsDocument((UIElement) source) ? !source.IsAutoHide : source.CanDockLeft && source.CanDockRight && source.CanDockTop && source.CanDockBottom);
    e.Handled = true;
    e.ContinueRouting = false;
  }

  private void ExecuteFloatWindow(object sender, ExecutedRoutedEventArgs e)
  {
    if (e.Source is DevComponents.WpfDock.DockWindow)
    {
      DevComponents.WpfDock.DockWindow source = e.Source as DevComponents.WpfDock.DockWindow;
      if (!source.IsAutoHide && !source.IsFloating && source.CanFloat)
        this.FloatWindow(source);
    }
    e.Handled = true;
  }

  private void CanExecuteFloatWindow(object sender, CanExecuteRoutedEventArgs e)
  {
    e.CanExecute = e.Source is DevComponents.WpfDock.DockWindow source && !source.IsAutoHide && !source.IsFloating && source.CanFloat;
    e.Handled = true;
    e.ContinueRouting = false;
  }

  [EditorBrowsable(EditorBrowsableState.Never)]
  public DockWindowGroup FindTargetDockDocumentGroup()
  {
    return this.Content is SplitPanel && ((SplitPanel) this.Content).VisibleItemsCount > 0 ? this.FindTargetDockDocumentGroup(this.Content as SplitPanel) : (DockWindowGroup) null;
  }

  private DockWindowGroup FindTargetDockDocumentGroup(SplitPanel sp)
  {
    foreach (UIElement child in (Collection<UIElement>) sp.Children)
    {
      if (child is DockWindowGroup && child.Visibility == Visibility.Visible)
        return child as DockWindowGroup;
      if (child is SplitPanel)
      {
        DockWindowGroup dockDocumentGroup = this.FindTargetDockDocumentGroup((SplitPanel) child);
        if (dockDocumentGroup != null)
          return dockDocumentGroup;
      }
    }
    return (DockWindowGroup) null;
  }

  private void ExecuteDockAsDocumentWindow(object sender, ExecutedRoutedEventArgs e)
  {
    if (e.Source is DevComponents.WpfDock.DockWindow)
    {
      DevComponents.WpfDock.DockWindow source = e.Source as DevComponents.WpfDock.DockWindow;
      if (!source.IsAutoHide && source.CanDockAsDocument && !DockSite.GetIsDocument((UIElement) source))
      {
        this.SaveCurrentDockInfo(source);
        DockWindowGroup dockWindowGroup = (DockWindowGroup) null;
        int insertIndex = -1;
        DockWindowGroup group;
        if (source.ParentGroup.Items.Count == 1)
        {
          group = source.ParentGroup;
        }
        else
        {
          dockWindowGroup = source.ParentGroup;
          if (dockWindowGroup != null)
            insertIndex = dockWindowGroup.Items.IndexOf((object) source);
          group = new DockWindowGroup();
          this.Detach(source);
          group.Items.Add((object) source);
        }
        DockWindowGroup dockDocumentGroup = this.FindTargetDockDocumentGroup();
        if (!(dockDocumentGroup == null ? this.DockWindow(group, eDockSide.Tab) : this.DockWindow(group, dockDocumentGroup, eDockSide.Tab)) && dockWindowGroup != null)
        {
          this.Detach(source);
          dockWindowGroup.Items.Insert(insertIndex, (object) source);
        }
        else
          dockWindowGroup?.UpdateVisibility();
      }
    }
    e.Handled = true;
  }

  private void CanExecuteDockAsDocumentWindow(object sender, CanExecuteRoutedEventArgs e)
  {
    e.CanExecute = e.Source is DevComponents.WpfDock.DockWindow source && !source.IsAutoHide && source.CanDockAsDocument;
    e.Handled = true;
    e.ContinueRouting = false;
  }

  private void ExecuteSelectWindow(object sender, ExecutedRoutedEventArgs e)
  {
    if (e.Source is DevComponents.WpfDock.DockWindow)
    {
      DevComponents.WpfDock.DockWindow source = e.Source as DevComponents.WpfDock.DockWindow;
      if (!source.IsSelected)
        source.IsSelected = true;
    }
    e.Handled = true;
  }

  private void CanExecuteSelectWindow(object sender, CanExecuteRoutedEventArgs e)
  {
    e.CanExecute = e.Source is DevComponents.WpfDock.DockWindow;
    e.Handled = true;
    e.ContinueRouting = false;
  }

  public List<DevComponents.WpfDock.DockWindow> GetDocuments()
  {
    List<DevComponents.WpfDock.DockWindow> list = new List<DevComponents.WpfDock.DockWindow>();
    if (this.Content is SplitPanel)
      this.GetDockWindows(list, this.Content as SplitPanel);
    return list;
  }

  public List<DevComponents.WpfDock.DockWindow> GetDockWindows()
  {
    return this.GetDockWindows(eDockList.All);
  }

  public List<DevComponents.WpfDock.DockWindow> GetDockWindows(eDockList dockWindowsToReturn)
  {
    List<DevComponents.WpfDock.DockWindow> list = new List<DevComponents.WpfDock.DockWindow>();
    if ((dockWindowsToReturn & eDockList.Docked) == eDockList.Docked)
    {
      foreach (SplitPanel splitPanel in (Collection<SplitPanel>) this.SplitPanels)
        this.GetDockWindows(list, splitPanel);
    }
    if ((dockWindowsToReturn & eDockList.Documents) == eDockList.Documents && this.Content is SplitPanel)
      this.GetDockWindows(list, this.Content as SplitPanel);
    if ((dockWindowsToReturn & eDockList.AutoHide) == eDockList.AutoHide)
    {
      if (this.m_TopAutoHidePanel != null)
        this.GetDockWindows(list, this.m_TopAutoHidePanel);
      if (this.m_BottomAutoHidePanel != null)
        this.GetDockWindows(list, this.m_BottomAutoHidePanel);
      if (this.m_LeftAutoHidePanel != null)
        this.GetDockWindows(list, this.m_LeftAutoHidePanel);
      if (this.m_RightAutoHidePanel != null)
        this.GetDockWindows(list, this.m_RightAutoHidePanel);
    }
    if ((dockWindowsToReturn & eDockList.Floating) == eDockList.Floating)
    {
      foreach (ContentControl floatingWindow in this.m_FloatingWindows)
      {
        if (floatingWindow.Content is DockWindowGroup content)
        {
          foreach (object obj in (IEnumerable) content.Items)
          {
            if (obj is DevComponents.WpfDock.DockWindow dockWindow)
              list.Add(dockWindow);
          }
        }
      }
    }
    return list;
  }

  public List<FloatingWindow> GetFloatingWindows() => this.m_FloatingWindows;

  private void GetDockWindows(List<DevComponents.WpfDock.DockWindow> list, AutoHidePanel parent)
  {
    foreach (object obj in (IEnumerable) parent.Items)
    {
      if (obj is DevComponents.WpfDock.DockWindow)
        list.Add((DevComponents.WpfDock.DockWindow) obj);
    }
  }

  private void GetDockWindows(List<DevComponents.WpfDock.DockWindow> list, SplitPanel parent)
  {
    foreach (UIElement child in (Collection<UIElement>) parent.Children)
    {
      switch (child)
      {
        case DevComponents.WpfDock.DockWindow _:
          list.Add(child as DevComponents.WpfDock.DockWindow);
          continue;
        case SplitPanel _:
          this.GetDockWindows(list, child as SplitPanel);
          continue;
        case DockWindowGroup _:
          this.GetDockWindows(list, (DockWindowGroup) child);
          continue;
        default:
          continue;
      }
    }
  }

  private void GetDockWindows(List<DevComponents.WpfDock.DockWindow> list, DockWindowGroup parent)
  {
    foreach (object obj in (IEnumerable) parent.Items)
    {
      if (obj is DevComponents.WpfDock.DockWindow)
        list.Add((DevComponents.WpfDock.DockWindow) obj);
    }
  }

  internal AutoHidePopup OpenAutoHidePopup(DevComponents.WpfDock.DockWindow dw)
  {
    return this.OpenAutoHidePopup(dw, false);
  }

  private void CloseAllAutoHideDockWindows()
  {
    List<DevComponents.WpfDock.DockWindow> dockWindowList = new List<DevComponents.WpfDock.DockWindow>();
    if (this.m_AutoHideAdorner != null && this.m_AutoHideAdorner.Children.Count > 0)
    {
      foreach (UIElement child in this.m_AutoHideAdorner.Children)
      {
        if (child is AutoHidePopup autoHidePopup && autoHidePopup.DockWindow != null)
          dockWindowList.Add(autoHidePopup.DockWindow);
      }
    }
    else if (this._AutoHidePopupWindows.Count > 0)
    {
      foreach (Popup autoHidePopupWindow in this._AutoHidePopupWindows)
      {
        if (autoHidePopupWindow.Child is AutoHidePopup child && child.DockWindow != null)
          dockWindowList.Add(child.DockWindow);
      }
    }
    foreach (DevComponents.WpfDock.DockWindow dockWindow in dockWindowList)
      dockWindow.AutoHideOpen = false;
  }

  protected override void OnVisualParentChanged(DependencyObject oldParent)
  {
    this.CloseAllAutoHideDockWindows();
    this.m_AutoHideAdorner = (AutoHideAdorner) null;
    base.OnVisualParentChanged(oldParent);
  }

  private AutoHideAdorner GetAutoHideAdorner()
  {
    if (this.m_AutoHideAdorner == null)
    {
      this.m_AutoHideAdorner = new AutoHideAdorner(this);
      AdornerLayer.GetAdornerLayer((Visual) this).Add((Adorner) this.m_AutoHideAdorner);
    }
    else
    {
      AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer((Visual) this);
      if (this.m_AutoHideAdorner.Parent != adornerLayer)
      {
        if (this.m_AutoHideAdorner.Parent is AdornerLayer)
          ((AdornerLayer) this.m_AutoHideAdorner.Parent).Remove((Adorner) this.m_AutoHideAdorner);
        adornerLayer.Add((Adorner) this.m_AutoHideAdorner);
      }
    }
    return this.m_AutoHideAdorner;
  }

  protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
  {
    AutoHideAdorner autoHideAdorner = this.m_AutoHideAdorner;
    if (autoHideAdorner != null && autoHideAdorner.Children.Count > 0)
    {
      foreach (UIElement child in autoHideAdorner.Children)
      {
        if (!(child is AutoHidePopup autoHidePopup))
          return;
        Size newSize;
        if (autoHidePopup.DockWindow != null && autoHidePopup.DockWindow.AutoHideOpen)
        {
          if (autoHidePopup.DockWindow.LastDock == Dock.Bottom)
          {
            AutoHidePanel autoHidePanel = this.GetAutoHidePanel(Dock.Bottom);
            if (autoHidePanel != null)
            {
              autoHidePopup.BeginAnimation(AutoHideAdorner.TopProperty, (AnimationTimeline) null);
              autoHidePopup.BeginAnimation(AutoHideAdorner.BottomProperty, (AnimationTimeline) null);
              AutoHidePopup element1 = autoHidePopup;
              newSize = sizeInfo.NewSize;
              double length1 = newSize.Height - autoHidePopup.ActualHeight - autoHidePanel.ActualHeight;
              AutoHideAdorner.SetTop((UIElement) element1, length1);
              AutoHidePopup element2 = autoHidePopup;
              newSize = sizeInfo.NewSize;
              double length2 = newSize.Height - autoHidePanel.ActualHeight;
              AutoHideAdorner.SetBottom((UIElement) element2, length2);
            }
          }
          else if (autoHidePopup.DockWindow.LastDock == Dock.Right)
          {
            AutoHidePanel autoHidePanel = this.GetAutoHidePanel(Dock.Right);
            if (autoHidePanel != null)
            {
              autoHidePopup.BeginAnimation(AutoHideAdorner.LeftProperty, (AnimationTimeline) null);
              autoHidePopup.BeginAnimation(AutoHideAdorner.RightProperty, (AnimationTimeline) null);
              AutoHidePopup element3 = autoHidePopup;
              newSize = sizeInfo.NewSize;
              double length3 = newSize.Width - autoHidePopup.ActualWidth - autoHidePanel.ActualHeight;
              AutoHideAdorner.SetLeft((UIElement) element3, length3);
              AutoHidePopup element4 = autoHidePopup;
              newSize = sizeInfo.NewSize;
              double length4 = newSize.Width - autoHidePanel.ActualHeight;
              AutoHideAdorner.SetRight((UIElement) element4, length4);
            }
          }
        }
      }
    }
    base.OnRenderSizeChanged(sizeInfo);
  }

  protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
  {
    if (e.Property == Control.BackgroundProperty)
      this.InvalidateVisual();
    base.OnPropertyChanged(e);
  }

  private bool GeAutoHidePopupOverlay() => this.AutoHidePopupOverlay;

  private void ParentWindowLocationChanged(object sender, EventArgs e)
  {
    this.CloseAllAutoHideDockWindows();
  }

  private void HandleParentWindowMove(bool remove)
  {
    if (!remove && this._ParentWindowMoveHandler || remove && !this._ParentWindowMoveHandler)
      return;
    Window window = Window.GetWindow((DependencyObject) this);
    if (window == null)
      return;
    if (remove)
    {
      window.LocationChanged -= new EventHandler(this.ParentWindowLocationChanged);
      this._ParentWindowMoveHandler = false;
    }
    else
    {
      window.LocationChanged += new EventHandler(this.ParentWindowLocationChanged);
      this._ParentWindowMoveHandler = true;
    }
  }

  internal AutoHidePopup OpenAutoHidePopup(DevComponents.WpfDock.DockWindow dw, bool disableAnimation)
  {
    bool flag1 = this.GeAutoHidePopupOverlay();
    AutoHidePopup autoHidePopup = new AutoHidePopup();
    autoHidePopup.DockWindow = dw;
    if (!flag1)
      autoHidePopup.Opacity = 0.0;
    SplitPanel splitPanel = new SplitPanel();
    DockWindowGroup target = new DockWindowGroup();
    target.AutoHideGroup = true;
    target.OwnerSite = this;
    Dock dockFromDockWindow = this.GetDockFromDockWindow(dw);
    AutoHidePanel autoHidePanel1 = this.GetAutoHidePanel(dockFromDockWindow);
    target.TabVisibility = Visibility.Collapsed;
    target.SelectedContent = dw.Content;
    BindingOperations.SetBinding((DependencyObject) target, DockWindowGroup.SelectedContentHeaderProperty, (BindingBase) new Binding("Header")
    {
      Source = (object) dw
    });
    target.SelectedDockWindow = dw;
    target.CanAutoHide = dw.CanAutoHide;
    target.CanClose = dw.CanClose;
    target.IsAutoHide = true;
    target.OptionsMenu = dw.OptionsMenu ? Visibility.Visible : Visibility.Collapsed;
    splitPanel.Children.Add((UIElement) target);
    DockSite.SetDock((UIElement) splitPanel, dockFromDockWindow);
    autoHidePopup.Children.Add((UIElement) splitPanel);
    Canvas.SetLeft((UIElement) splitPanel, 0.0);
    Canvas.SetTop((UIElement) splitPanel, 0.0);
    bool flag2 = this.AnimationEnabled && !disableAnimation;
    Popup popup = (Popup) null;
    if (flag1)
    {
      popup = new Popup();
      popup.DataContext = this.DataContext;
      popup.Placement = PlacementMode.Absolute;
      popup.Child = (UIElement) autoHidePopup;
      this._AutoHidePopupWindows.Add(popup);
      popup.PopupAnimation = flag2 ? PopupAnimation.Fade : PopupAnimation.None;
      this.HandleParentWindowMove(false);
    }
    else
      this.GetAutoHideAdorner().Children.Add((UIElement) autoHidePopup);
    DoubleAnimation animation1 = (DoubleAnimation) null;
    if (flag2 && !flag1)
    {
      animation1 = new DoubleAnimation();
      animation1.Duration = (Duration) TimeSpan.FromMilliseconds(200.0);
      animation1.DecelerationRatio = 0.2;
    }
    AutoHidePanel autoHidePanel2 = this.GetAutoHidePanel(dockFromDockWindow);
    switch (dockFromDockWindow)
    {
      case Dock.Left:
        Rect layoutSlot = LayoutInformation.GetLayoutSlot((FrameworkElement) autoHidePanel1);
        AutoHideAdorner.SetTop((UIElement) autoHidePopup, layoutSlot.Y);
        autoHidePopup.Height = autoHidePanel1.ActualWidth;
        splitPanel.Height = autoHidePanel1.ActualWidth;
        Binding binding1 = new Binding("ActualWidth");
        binding1.Source = (object) autoHidePanel1;
        BindingOperations.SetBinding((DependencyObject) autoHidePopup, FrameworkElement.HeightProperty, (BindingBase) binding1);
        BindingOperations.SetBinding((DependencyObject) splitPanel, FrameworkElement.HeightProperty, (BindingBase) binding1);
        splitPanel.Width = dw.LastAutoHideSize.Width > 0.0 ? dw.LastAutoHideSize.Width : dw.LastDockedSize.Width;
        double actualHeight1 = autoHidePanel2.ActualHeight;
        double length1 = autoHidePanel2.ActualHeight + splitPanel.Width;
        if (flag1)
        {
          autoHidePopup.Width = length1 - actualHeight1;
          System.Windows.Point screen = this.PointToScreen(new System.Windows.Point(actualHeight1, 0.0));
          popup.HorizontalOffset = screen.X;
          popup.VerticalOffset = screen.Y;
          break;
        }
        AutoHideAdorner.SetLeft((UIElement) autoHidePopup, actualHeight1);
        if (flag2)
        {
          AutoHideAdorner.SetRight((UIElement) autoHidePopup, autoHidePanel2.ActualHeight);
          animation1.To = new double?(length1);
          autoHidePopup.BeginAnimation(AutoHideAdorner.RightProperty, (AnimationTimeline) animation1);
          break;
        }
        AutoHideAdorner.SetRight((UIElement) autoHidePopup, length1);
        break;
      case Dock.Top:
        autoHidePopup.Width = this.ActualWidth;
        splitPanel.Width = this.ActualWidth;
        Binding binding2 = new Binding("ActualWidth");
        binding2.Source = (object) this;
        BindingOperations.SetBinding((DependencyObject) autoHidePopup, FrameworkElement.WidthProperty, (BindingBase) binding2);
        BindingOperations.SetBinding((DependencyObject) splitPanel, FrameworkElement.WidthProperty, (BindingBase) binding2);
        splitPanel.Height = dw.LastAutoHideSize.Height > 0.0 ? dw.LastAutoHideSize.Height : dw.LastDockedSize.Height;
        double length2 = autoHidePanel2.ActualHeight + splitPanel.Height;
        double actualHeight2 = autoHidePanel2.ActualHeight;
        if (flag1)
        {
          autoHidePopup.Height = length2 - actualHeight2;
          System.Windows.Point screen = this.PointToScreen(new System.Windows.Point(0.0, actualHeight2));
          popup.HorizontalOffset = screen.X;
          popup.VerticalOffset = screen.Y;
          break;
        }
        AutoHideAdorner.SetTop((UIElement) autoHidePopup, actualHeight2);
        if (flag2)
        {
          AutoHideAdorner.SetBottom((UIElement) autoHidePopup, autoHidePanel2.ActualHeight);
          animation1.To = new double?(length2);
          autoHidePopup.BeginAnimation(AutoHideAdorner.BottomProperty, (AnimationTimeline) animation1);
          break;
        }
        AutoHideAdorner.SetBottom((UIElement) autoHidePopup, length2);
        break;
      case Dock.Right:
        autoHidePopup.Height = autoHidePanel1.ActualWidth;
        splitPanel.Height = autoHidePanel1.ActualWidth;
        Binding binding3 = new Binding("ActualWidth");
        binding3.Source = (object) autoHidePanel1;
        BindingOperations.SetBinding((DependencyObject) autoHidePopup, FrameworkElement.HeightProperty, (BindingBase) binding3);
        BindingOperations.SetBinding((DependencyObject) splitPanel, FrameworkElement.HeightProperty, (BindingBase) binding3);
        splitPanel.Width = dw.LastAutoHideSize.Width > 0.0 ? dw.LastAutoHideSize.Width : dw.LastDockedSize.Width;
        double length3 = this.ActualWidth - autoHidePanel2.ActualHeight;
        double num1 = this.ActualWidth - autoHidePanel2.ActualHeight - splitPanel.Width;
        if (flag1)
        {
          autoHidePopup.Width = length3 - num1;
          System.Windows.Point screen = this.PointToScreen(new System.Windows.Point(num1, 0.0));
          popup.HorizontalOffset = screen.X;
          popup.VerticalOffset = screen.Y;
          break;
        }
        AutoHideAdorner.SetRight((UIElement) autoHidePopup, length3);
        if (flag2)
        {
          AutoHideAdorner.SetLeft((UIElement) autoHidePopup, this.ActualWidth - autoHidePanel2.ActualHeight);
          animation1.To = new double?(num1);
          autoHidePopup.BeginAnimation(AutoHideAdorner.LeftProperty, (AnimationTimeline) animation1);
          break;
        }
        AutoHideAdorner.SetLeft((UIElement) autoHidePopup, num1);
        break;
      case Dock.Bottom:
        autoHidePopup.Width = this.ActualWidth;
        Binding binding4 = new Binding("ActualWidth");
        binding4.Source = (object) this;
        BindingOperations.SetBinding((DependencyObject) autoHidePopup, FrameworkElement.WidthProperty, (BindingBase) binding4);
        BindingOperations.SetBinding((DependencyObject) splitPanel, FrameworkElement.WidthProperty, (BindingBase) binding4);
        splitPanel.Height = dw.LastAutoHideSize.Height > 0.0 ? dw.LastAutoHideSize.Height : dw.LastDockedSize.Height;
        double length4 = this.ActualHeight - autoHidePanel2.ActualHeight;
        double num2 = this.ActualHeight - autoHidePanel2.ActualHeight - splitPanel.Height;
        if (flag1)
        {
          autoHidePopup.Height = length4 - num2;
          System.Windows.Point screen = this.PointToScreen(new System.Windows.Point(0.0, num2));
          popup.HorizontalOffset = screen.X;
          popup.VerticalOffset = screen.Y;
          break;
        }
        AutoHideAdorner.SetBottom((UIElement) autoHidePopup, length4);
        if (flag2)
        {
          AutoHideAdorner.SetTop((UIElement) autoHidePopup, this.ActualHeight - autoHidePanel2.ActualHeight);
          animation1.To = new double?(num2);
          autoHidePopup.BeginAnimation(AutoHideAdorner.TopProperty, (AnimationTimeline) animation1);
          break;
        }
        AutoHideAdorner.SetTop((UIElement) autoHidePopup, num2);
        break;
    }
    if (flag1)
      popup.IsOpen = true;
    else if (flag2)
    {
      DoubleAnimation animation2 = new DoubleAnimation(1.0, (Duration) TimeSpan.FromMilliseconds(120.0));
      autoHidePopup.BeginAnimation(UIElement.OpacityProperty, (AnimationTimeline) animation2);
    }
    else
      autoHidePopup.Opacity = 1.0;
    bool flag3 = false;
    if (dw.Content is IInputElement)
    {
      flag3 = ((IInputElement) dw.Content).Focus();
      if (!flag3 && dw.Content is WindowsFormsHost && dw.Content is WindowsFormsHost content)
        flag3 = content.TabInto(new TraversalRequest(FocusNavigationDirection.First));
    }
    if (!flag3)
      autoHidePopup.Focus();
    return autoHidePopup;
  }

  internal void CloseAutoHidePopup(DevComponents.WpfDock.DockWindow dw, bool animate)
  {
    bool flag = this.GeAutoHidePopupOverlay();
    AutoHidePopup autoHidePopup1 = (AutoHidePopup) null;
    Popup popup = (Popup) null;
    if (flag)
    {
      foreach (Popup autoHidePopupWindow in this._AutoHidePopupWindows)
      {
        if (autoHidePopupWindow.Child is AutoHidePopup child && child.DockWindow == dw)
        {
          autoHidePopup1 = child;
          popup = autoHidePopupWindow;
          break;
        }
      }
    }
    else
    {
      foreach (UIElement child in this.m_AutoHideAdorner.Children)
      {
        if (child is AutoHidePopup autoHidePopup2 && autoHidePopup2.DockWindow == dw)
        {
          autoHidePopup1 = autoHidePopup2;
          break;
        }
      }
    }
    SplitPanel child1 = autoHidePopup1.Children[0] as SplitPanel;
    dw.LastAutoHideSize = new Size(child1.ActualWidth, child1.ActualHeight);
    autoHidePopup1.DockWindow = (DevComponents.WpfDock.DockWindow) null;
    AutoHidePanel parent = dw.Parent as AutoHidePanel;
    Dock dock = DockSite.GetDock((UIElement) parent);
    if (flag)
    {
      autoHidePopup1.CleanupPopup();
      popup.IsOpen = false;
      this._AutoHidePopupWindows.Remove(popup);
      if (this._AutoHidePopupWindows.Count != 0)
        return;
      this.HandleParentWindowMove(true);
    }
    else if (animate)
    {
      DoubleAnimation animation1 = new DoubleAnimation();
      animation1.Duration = (Duration) TimeSpan.FromMilliseconds(250.0);
      animation1.Completed += new EventHandler(autoHidePopup1.AutoHideCloseAnimationCompleted);
      switch (dock)
      {
        case Dock.Left:
          animation1.To = new double?(parent.ActualHeight);
          autoHidePopup1.BeginAnimation(AutoHideAdorner.RightProperty, (AnimationTimeline) animation1);
          break;
        case Dock.Top:
          animation1.To = new double?(parent.ActualHeight);
          autoHidePopup1.BeginAnimation(AutoHideAdorner.BottomProperty, (AnimationTimeline) animation1);
          break;
        case Dock.Right:
          animation1.To = new double?(this.ActualWidth - parent.ActualHeight);
          autoHidePopup1.BeginAnimation(AutoHideAdorner.LeftProperty, (AnimationTimeline) animation1);
          break;
        case Dock.Bottom:
          animation1.To = new double?(this.ActualHeight - parent.ActualHeight);
          autoHidePopup1.BeginAnimation(AutoHideAdorner.TopProperty, (AnimationTimeline) animation1);
          break;
      }
      DoubleAnimation animation2 = new DoubleAnimation(0.0, (Duration) TimeSpan.FromMilliseconds(250.0));
      autoHidePopup1.BeginAnimation(UIElement.OpacityProperty, (AnimationTimeline) animation2);
    }
    else
      autoHidePopup1.CleanupPopup();
  }

  internal static DockSite GetDockSite(DependencyObject dpo)
  {
    DependencyObject reference = dpo;
    while (reference != null)
    {
      reference = VisualTreeHelper.GetParent(reference);
      if (reference is DockSite)
        return reference as DockSite;
      if (reference is FloatingWindow)
        return ((FloatingWindow) reference).DockSite;
    }
    return (DockSite) null;
  }

  [Browsable(false)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public string Layout
  {
    get => this.GetDockSiteLayoutSerializer().SaveLayout(this);
    set => this.GetDockSiteLayoutSerializer().LoadLayout(this, value);
  }

  private IDockSiteLayoutSerializer GetDockSiteLayoutSerializer()
  {
    if (this.m_LayoutSerializer == null)
      this.m_LayoutSerializer = (IDockSiteLayoutSerializer) new DockSiteLayoutSerializer();
    return this.m_LayoutSerializer;
  }

  private static void DockWindowActivated(object sender, RoutedEventArgs e)
  {
    ((DockSite) sender).OnDockWindowActivated(e.OriginalSource as DevComponents.WpfDock.DockWindow);
  }

  private void OnDockWindowActivated(DevComponents.WpfDock.DockWindow dockWindow)
  {
    this.ActiveDockWindow = dockWindow;
  }

  private static void DockWindowDeactivated(object sender, RoutedEventArgs e)
  {
    ((DockSite) sender).OnDockWindowDeactivated(e.OriginalSource as DevComponents.WpfDock.DockWindow);
  }

  private void OnDockWindowDeactivated(DevComponents.WpfDock.DockWindow dockWindow)
  {
    if (this.ActiveDockWindow != dockWindow)
      return;
    this.ActiveDockWindow = (DevComponents.WpfDock.DockWindow) null;
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  [Browsable(false)]
  public DevComponents.WpfDock.DockWindow ActiveDockWindow
  {
    get => (DevComponents.WpfDock.DockWindow) this.GetValue(DockSite.ActiveDockWindowProperty);
    internal set => this.SetValue(DockSite.ActiveDockWindowPropertyKey, (object) value);
  }

  public void ChangeColorScheme(eDockVisualStyle colorTable)
  {
    if (Application.Current == null)
      return;
    this.MergeDictionary(this.GetColorTable(colorTable));
  }

  private void MergeDictionary(ResourceDictionary rd)
  {
    ResourceDictionary resourceDictionary = Application.Current != null ? Application.Current.Resources : this.Resources;
    foreach (ResourceDictionary mergedDictionary in resourceDictionary.MergedDictionaries)
    {
      switch (mergedDictionary)
      {
        case Office2007BlackSkin _:
        case Office2007BlueSkin _:
        case Office2007SilverSkin _:
        case Office2010SilverSkin _:
        case Office2010BlackSkin _:
          resourceDictionary.MergedDictionaries.Remove(mergedDictionary);
          goto label_8;
        default:
          continue;
      }
    }
label_8:
    resourceDictionary.MergedDictionaries.Add(rd);
  }

  protected override IEnumerator LogicalChildren => this.m_Children.GetEnumerator();

  public void ChangeColorScheme(eDockVisualStyle baseColorTable, Color baseColor)
  {
    if (Application.Current == null)
      return;
    this.MergeDictionary(this.CreateColorScheme(baseColorTable, baseColor));
  }

  public ResourceDictionary CreateColorScheme(eDockVisualStyle baseColorTable, Color baseColor)
  {
    return this.CreateColorScheme(this.GetColorTable(baseColorTable), baseColor);
  }

  private ResourceDictionary GetColorTable(eDockVisualStyle colorTable)
  {
    switch (colorTable)
    {
      case eDockVisualStyle.Office2007Blue:
        return (ResourceDictionary) new Office2007BlueSkin();
      case eDockVisualStyle.Office2007Silver:
        return (ResourceDictionary) new Office2007SilverSkin();
      case eDockVisualStyle.Office2007Black:
        return (ResourceDictionary) new Office2007BlackSkin();
      case eDockVisualStyle.Office2010Silver:
        return (ResourceDictionary) new Office2010SilverSkin();
      case eDockVisualStyle.Office2010Blue:
        return (ResourceDictionary) new Office2010BlueSkin();
      case eDockVisualStyle.Office2010Black:
        return (ResourceDictionary) new Office2010BlackSkin();
      case eDockVisualStyle.Office2007Classic:
        return (ResourceDictionary) new Office2007ClassicSkin();
      case eDockVisualStyle.Office2007Police:
        return (ResourceDictionary) new Office2007PoliceSkin();
      case eDockVisualStyle.Office2007Military:
        return (ResourceDictionary) new Office2007MilitarySkin();
      case eDockVisualStyle.Office2007Fireman:
        return (ResourceDictionary) new Office2007FiremanSkin();
      case eDockVisualStyle.Office2007FullColor:
        return (ResourceDictionary) new Office2007FullColorSkin();
      default:
        throw new InvalidEnumArgumentException("Color table not not recognized");
    }
  }

  private ResourceDictionary CreateColorScheme(ResourceDictionary rd, Color baseColor)
  {
    ColorFactory colorFactory = this.GetColorFactory(baseColor);
    foreach (object key in (IEnumerable) rd.Keys)
    {
      if (!(key is ComponentResourceKey) || !(key as ComponentResourceKey).ResourceId.ToString().StartsWith(DockColors.DockButtonClass))
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

  private ColorFactory GetColorFactory(Color baseColor)
  {
    return (ColorFactory) new ColorBlendFactory(baseColor);
  }

  [Browsable(false)]
  [DefaultValue("")]
  public string LicenseKey
  {
    get => (string) this.GetValue(DockSite.LicenseKeyProperty);
    set => this.SetValue(DockSite.LicenseKeyProperty, (object) value);
  }

  private static void OnLicenseKeyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
  {
    ((DockSite) d).OnLicenseKeyChanged();
  }

  private void OnLicenseKeyChanged() => WinApi.ValidateLicenseKey(this.LicenseKey);

  protected override void OnRender(DrawingContext dc)
  {
    Brush background = this.Background;
    Size renderSize;
    if (background != null)
    {
      DrawingContext drawingContext = dc;
      Brush brush = background;
      renderSize = this.RenderSize;
      double width = renderSize.Width;
      renderSize = this.RenderSize;
      double height = renderSize.Height;
      Rect rectangle = new Rect(0.0, 0.0, width, height);
      drawingContext.DrawRectangle(brush, (Pen) null, rectangle);
    }
    if (WinApi.KeyValidated)
      return;
    FormattedText formattedText1 = new FormattedText("License not found. See DotNetBar for WPF registration message for activation details.", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("Arial"), 9.0, (Brush) Brushes.Maroon);
    DrawingContext drawingContext1 = dc;
    FormattedText formattedText2 = formattedText1;
    renderSize = this.RenderSize;
    double x = (renderSize.Width - formattedText1.Width) / 2.0;
    renderSize = this.RenderSize;
    double y = (renderSize.Height - formattedText1.Height) / 2.0;
    System.Windows.Point origin = new System.Windows.Point(x, y);
    drawingContext1.DrawText(formattedText2, origin);
  }

  internal IDockOperations DockOperations
  {
    get => this.m_DockOperations;
    set
    {
      if (this.m_DockOperations == value)
        return;
      this.m_DockOperations = value;
    }
  }

  private class DockPositionInfo
  {
    public eDockInfo PositionInfo = eDockInfo.Float;
    public SplitPanel SplitPanel;
    public Rect DockRect;
    public DockWindowGroup MouseOverGroup;
  }
}
