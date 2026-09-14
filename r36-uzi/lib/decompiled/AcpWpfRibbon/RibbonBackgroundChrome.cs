// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.RibbonBackgroundChrome
// Assembly: AcpWpfRibbon, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 45A745B5-88C3-40EE-B1E5-8DBA2EACD529
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfRibbon.dll

using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Threading;

#nullable disable
namespace DevComponents.WpfRibbon;

[DesignTimeVisible(false)]
public class RibbonBackgroundChrome : ContentControl
{
  public static readonly DependencyProperty VisualStyleProperty = Ribbon.VisualStyleProperty.AddOwner(typeof (RibbonBackgroundChrome), (PropertyMetadata) new FrameworkPropertyMetadata((object) eRibbonVisualStyle.Office2007Blue, FrameworkPropertyMetadataOptions.Inherits, new PropertyChangedCallback(RibbonBackgroundChrome.OnVisualStyleChanged)));
  private static readonly DependencyPropertyKey EffectiveStylePropertyKey = DependencyProperty.RegisterReadOnly(nameof (EffectiveStyle), typeof (eEffectiveStyle), typeof (RibbonBackgroundChrome), (PropertyMetadata) new UIPropertyMetadata((object) eEffectiveStyle.Office2007, new PropertyChangedCallback(RibbonBackgroundChrome.OnEffectiveStyleChanged)));
  public static readonly DependencyProperty EffectiveStyleProperty = RibbonBackgroundChrome.EffectiveStylePropertyKey.DependencyProperty;
  public static readonly DependencyProperty QatRightPositionProperty;
  public static readonly DependencyProperty TitleChromeHeightProperty;
  public static readonly DependencyProperty IsActiveProperty;
  public static readonly DependencyProperty WindowStateProperty;
  public static readonly DependencyProperty CloseButtonVisibilityProperty;
  public static readonly DependencyProperty RestoreButtonVisibilityProperty;
  public static readonly DependencyProperty MinimizeButtonVisibilityProperty;
  public static readonly DependencyProperty MaximizeButtonVisibilityProperty;
  public static readonly DependencyProperty WindowBorderThicknessProperty;
  public static readonly DependencyProperty IsGlassEnabledProperty;
  public static readonly DependencyProperty SystemButtonsProperty;
  public static readonly DependencyProperty TotalTitleChromeHeightProperty;
  private static readonly DependencyPropertyKey TotalTitleChromeHeightPropertyKey;
  public static readonly DependencyProperty HorizontalWindowBorderThicknessProperty;
  private static readonly DependencyPropertyKey HorizontalWindowBorderThicknessPropertyKey;
  private TitlePanel m_TitlePanel;
  private ContextGroupCollection m_ConnectedCollection;
  private double m_TabXPosition;
  private Button m_MinButton;
  private Button m_MaxButton;
  private Button m_CloseButton;
  private Button m_RestoreButton;
  private Image m_WindowIcon;
  private const string TitleBarElementName = "TitleBar";
  private const string TitleLabelName = "SysTitleLabel";

  public eRibbonVisualStyle VisualStyle
  {
    get => (eRibbonVisualStyle) this.GetValue(RibbonBackgroundChrome.VisualStyleProperty);
    set => this.SetValue(RibbonBackgroundChrome.VisualStyleProperty, (object) value);
  }

  private static void OnVisualStyleChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
  {
    ((RibbonBackgroundChrome) o).OnVisualStyleChanged((eRibbonVisualStyle) e.OldValue, (eRibbonVisualStyle) e.NewValue);
  }

  private void OnVisualStyleChanged(eRibbonVisualStyle oldValue, eRibbonVisualStyle newValue)
  {
    if (newValue == eRibbonVisualStyle.Office2010Silver || newValue == eRibbonVisualStyle.Office2010Blue || newValue == eRibbonVisualStyle.Office2010Black)
      this.EffectiveStyle = eEffectiveStyle.Office2010;
    else
      this.EffectiveStyle = eEffectiveStyle.Office2007;
  }

  private bool IsDesignMode => DesignerProperties.GetIsInDesignMode((DependencyObject) this);

  public eEffectiveStyle EffectiveStyle
  {
    get => (eEffectiveStyle) this.GetValue(RibbonBackgroundChrome.EffectiveStyleProperty);
    internal set => this.SetValue(RibbonBackgroundChrome.EffectiveStylePropertyKey, (object) value);
  }

  private static void OnEffectiveStyleChanged(
    DependencyObject o,
    DependencyPropertyChangedEventArgs e)
  {
    if (!(o is RibbonBackgroundChrome backgroundChrome))
      return;
    backgroundChrome.OnEffectiveStyleChanged((eEffectiveStyle) e.OldValue, (eEffectiveStyle) e.NewValue);
  }

  protected virtual void OnEffectiveStyleChanged(eEffectiveStyle oldValue, eEffectiveStyle newValue)
  {
    this.UpdateWindowIconVisibility();
  }

  private void UpdateWindowIconVisibility()
  {
    eEffectiveStyle effectiveStyle = this.EffectiveStyle;
    if (this.m_WindowIcon == null)
      return;
    if (effectiveStyle == eEffectiveStyle.Office2007)
    {
      this.m_WindowIcon.Visibility = Visibility.Collapsed;
    }
    else
    {
      if (effectiveStyle != eEffectiveStyle.Office2010)
        return;
      this.m_WindowIcon.Visibility = Visibility.Visible;
    }
  }

  static RibbonBackgroundChrome()
  {
    FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof (RibbonBackgroundChrome), (PropertyMetadata) new FrameworkPropertyMetadata((object) typeof (RibbonBackgroundChrome)));
    RibbonBackgroundChrome.QatRightPositionProperty = DependencyProperty.Register(nameof (QatRightPosition), typeof (GridLength), typeof (RibbonBackgroundChrome), (PropertyMetadata) new FrameworkPropertyMetadata((object) new GridLength(0.0), FrameworkPropertyMetadataOptions.AffectsArrange, new PropertyChangedCallback(RibbonBackgroundChrome.OnQatRightPositionChanged)));
    RibbonBackgroundChrome.TitleChromeHeightProperty = DependencyProperty.Register(nameof (TitleChromeHeight), typeof (double), typeof (RibbonBackgroundChrome), (PropertyMetadata) new FrameworkPropertyMetadata((object) 28.0, FrameworkPropertyMetadataOptions.AffectsMeasure, new PropertyChangedCallback(RibbonBackgroundChrome.OnTitleChromeHeightChanged)));
    RibbonBackgroundChrome.IsGlassEnabledProperty = DependencyProperty.Register(nameof (IsGlassEnabled), typeof (bool), typeof (RibbonBackgroundChrome), (PropertyMetadata) new FrameworkPropertyMetadata((object) false, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(RibbonBackgroundChrome.IsGlassEnabledChanged)));
    RibbonBackgroundChrome.SystemButtonsProperty = DependencyProperty.Register(nameof (SystemButtons), typeof (bool), typeof (RibbonBackgroundChrome), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, new PropertyChangedCallback(RibbonBackgroundChrome.OnSystemButtonsChanged)));
    RibbonBackgroundChrome.CloseButtonVisibilityProperty = DependencyProperty.Register(nameof (CloseButtonVisibility), typeof (Visibility), typeof (RibbonBackgroundChrome), (PropertyMetadata) new FrameworkPropertyMetadata((object) Visibility.Visible, FrameworkPropertyMetadataOptions.AffectsMeasure));
    RibbonBackgroundChrome.RestoreButtonVisibilityProperty = DependencyProperty.Register(nameof (RestoreButtonVisibility), typeof (Visibility), typeof (RibbonBackgroundChrome), (PropertyMetadata) new FrameworkPropertyMetadata((object) Visibility.Visible, FrameworkPropertyMetadataOptions.AffectsMeasure));
    RibbonBackgroundChrome.MinimizeButtonVisibilityProperty = DependencyProperty.Register(nameof (MinimizeButtonVisibility), typeof (Visibility), typeof (RibbonBackgroundChrome), (PropertyMetadata) new FrameworkPropertyMetadata((object) Visibility.Visible, FrameworkPropertyMetadataOptions.AffectsMeasure));
    RibbonBackgroundChrome.MaximizeButtonVisibilityProperty = DependencyProperty.Register(nameof (MaximizeButtonVisibility), typeof (Visibility), typeof (RibbonBackgroundChrome), (PropertyMetadata) new FrameworkPropertyMetadata((object) Visibility.Visible, FrameworkPropertyMetadataOptions.AffectsMeasure));
    RibbonBackgroundChrome.IsActiveProperty = Ribbon.IsActiveProperty.AddOwner(typeof (RibbonBackgroundChrome), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender));
    RibbonBackgroundChrome.WindowStateProperty = DependencyProperty.Register(nameof (WindowState), typeof (WindowState), typeof (RibbonBackgroundChrome), (PropertyMetadata) new FrameworkPropertyMetadata((object) WindowState.Normal, new PropertyChangedCallback(RibbonBackgroundChrome.WindowStateChanged)));
    RibbonBackgroundChrome.WindowBorderThicknessProperty = Ribbon.WindowBorderThicknessProperty.AddOwner(typeof (RibbonBackgroundChrome), (PropertyMetadata) new FrameworkPropertyMetadata((object) new Thickness(3.0, 0.0, 3.0, 0.0), FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(RibbonBackgroundChrome.WindowBorderThicknessChanged)));
    RibbonBackgroundChrome.HorizontalWindowBorderThicknessPropertyKey = DependencyProperty.RegisterReadOnly(nameof (HorizontalWindowBorderThickness), typeof (Thickness), typeof (RibbonBackgroundChrome), (PropertyMetadata) new FrameworkPropertyMetadata((object) new Thickness()));
    RibbonBackgroundChrome.HorizontalWindowBorderThicknessProperty = RibbonBackgroundChrome.HorizontalWindowBorderThicknessPropertyKey.DependencyProperty;
    RibbonBackgroundChrome.TotalTitleChromeHeightPropertyKey = DependencyProperty.RegisterReadOnly(nameof (TotalTitleChromeHeight), typeof (double), typeof (RibbonBackgroundChrome), (PropertyMetadata) new FrameworkPropertyMetadata((object) 28.0));
    RibbonBackgroundChrome.TotalTitleChromeHeightProperty = RibbonBackgroundChrome.TotalTitleChromeHeightPropertyKey.DependencyProperty;
  }

  public RibbonBackgroundChrome()
  {
    Thickness windowBorderThickness = this.WindowBorderThickness;
    double left = windowBorderThickness.Left;
    windowBorderThickness = this.WindowBorderThickness;
    double right = windowBorderThickness.Right;
    this.HorizontalWindowBorderThickness = new Thickness(left, 0.0, right, 0.0);
    this.TitleChromeHeight = (double) this.GetSystemCaptionHeight();
    this.UpdateTotalChromeHeight();
  }

  public override void OnApplyTemplate()
  {
    if (this.m_ConnectedCollection != null)
    {
      this.m_ConnectedCollection.CollectionChanged -= new NotifyCollectionChangedEventHandler(this.ContextGroupsChanged);
      this.m_ConnectedCollection = (ContextGroupCollection) null;
    }
    if (this.m_MaxButton != null)
    {
      this.m_MaxButton.Click -= new RoutedEventHandler(this.SysButtonClick);
      this.m_MaxButton = (Button) null;
    }
    if (this.m_MinButton != null)
    {
      this.m_MinButton.Click -= new RoutedEventHandler(this.SysButtonClick);
      this.m_MinButton = (Button) null;
    }
    if (this.m_RestoreButton != null)
    {
      this.m_RestoreButton.Click -= new RoutedEventHandler(this.SysButtonClick);
      this.m_RestoreButton = (Button) null;
    }
    if (this.m_CloseButton != null)
    {
      this.m_CloseButton.Click -= new RoutedEventHandler(this.SysButtonClick);
      this.m_CloseButton = (Button) null;
    }
    if (this.m_TitlePanel != null)
      this.m_TitlePanel.Children.Clear();
    this.m_MaxButton = this.GetTemplateChild("PART_SysMaximizeButton") as Button;
    this.m_MinButton = this.GetTemplateChild("PART_SysMinimizeButton") as Button;
    this.m_RestoreButton = this.GetTemplateChild("PART_SysRestoreButton") as Button;
    this.m_CloseButton = this.GetTemplateChild("PART_SysCloseButton") as Button;
    if (this.m_MaxButton != null)
      this.m_MaxButton.Click += new RoutedEventHandler(this.SysButtonClick);
    if (this.m_MinButton != null)
      this.m_MinButton.Click += new RoutedEventHandler(this.SysButtonClick);
    if (this.m_RestoreButton != null)
      this.m_RestoreButton.Click += new RoutedEventHandler(this.SysButtonClick);
    if (this.m_CloseButton != null)
      this.m_CloseButton.Click += new RoutedEventHandler(this.SysButtonClick);
    this.m_TitlePanel = this.GetTemplateChild("PART_TitleContent") as TitlePanel;
    if (this.m_TitlePanel != null)
    {
      this.m_TitlePanel.TabXPosition = this.m_TabXPosition;
      this.m_TitlePanel.QatRightPosition = this.QatRightPosition.Value;
      this.UpdateTitlePanelChromeHeight();
      DependencyObject parent = VisualTreeHelper.GetParent((DependencyObject) this);
      Ribbon ribbon = (Ribbon) null;
      while (true)
      {
        switch (parent)
        {
          case null:
            goto label_26;
          case Ribbon _:
            goto label_22;
          case Visual _:
            parent = VisualTreeHelper.GetParent(parent);
            continue;
          default:
            parent = LogicalTreeHelper.GetParent(parent);
            continue;
        }
      }
label_22:
      ribbon = parent as Ribbon;
label_26:
      if (ribbon != null)
      {
        this.m_ConnectedCollection = ribbon.ContextGroups;
        this.LoadPanel(this.m_ConnectedCollection);
        this.m_ConnectedCollection.CollectionChanged += new NotifyCollectionChangedEventHandler(this.ContextGroupsChanged);
        this.UpdateContextGroupGlassEffect();
        BindingOperations.SetBinding((DependencyObject) this, RibbonBackgroundChrome.SystemButtonsProperty, (BindingBase) new Binding("SystemButtons")
        {
          Source = (object) ribbon
        });
      }
    }
    Window window = Window.GetWindow((DependencyObject) this);
    if (window != null)
    {
      BindingOperations.SetBinding((DependencyObject) this, RibbonBackgroundChrome.IsActiveProperty, (BindingBase) new Binding("IsActive")
      {
        Source = (object) window
      });
      BindingOperations.SetBinding((DependencyObject) this, RibbonBackgroundChrome.WindowStateProperty, (BindingBase) new Binding("WindowState")
      {
        Source = (object) window
      });
      this.m_WindowIcon = this.GetTemplateChild("WinIcon") as Image;
      if (this.m_WindowIcon != null)
      {
        BindingOperations.SetBinding((DependencyObject) this.m_WindowIcon, Image.SourceProperty, (BindingBase) new Binding("Icon")
        {
          Source = (object) window
        });
        this.m_WindowIcon.MouseDown += new MouseButtonEventHandler(this.WindowIconMouseDown);
      }
    }
    this.UpdateSystemButtonVisibility();
    this.UpdateWindowIconVisibility();
    base.OnApplyTemplate();
  }

  private void WindowIconMouseDown(object sender, MouseButtonEventArgs e)
  {
    if (e.LeftButton != MouseButtonState.Pressed || Window.GetWindow((DependencyObject) this) == null)
      return;
    this.ShowTitleContextMenu(this.m_WindowIcon.PointToScreen(new System.Windows.Point(0.0, this.m_WindowIcon.RenderSize.Height + 1.0)));
    e.Handled = true;
  }

  private bool SystemTitleElementsVisible => this.SystemButtons;

  protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
  {
    if (e.OriginalSource is FrameworkElement && (e.OriginalSource is TextBlock || ((FrameworkElement) e.OriginalSource).Name == "TitleBar" || ((FrameworkElement) e.OriginalSource).Name == "SysTitleLabel") && this.SystemTitleElementsVisible)
    {
      Window window = Window.GetWindow((DependencyObject) this);
      if (window != null && window.WindowState != WindowState.Maximized)
        this.StartWindowDragMove();
      e.Handled = true;
    }
    base.OnMouseLeftButtonDown(e);
  }

  protected override void OnMouseMove(MouseEventArgs e)
  {
    if (e.LeftButton == MouseButtonState.Pressed && e.OriginalSource is FrameworkElement && (e.OriginalSource is TextBlock || ((FrameworkElement) e.OriginalSource).Name == "TitleBar" || ((FrameworkElement) e.OriginalSource).Name == "SysTitleLabel") && this.SystemTitleElementsVisible)
    {
      Window window = Window.GetWindow((DependencyObject) this);
      if (window != null && window.WindowState == WindowState.Maximized)
      {
        System.Windows.Point screen = window.PointToScreen(e.GetPosition((IInputElement) window));
        double y = screen.Y;
        window.WindowState = WindowState.Normal;
        window.Top = screen.Y;
        this.StartWindowDragMove();
      }
      e.Handled = true;
    }
    base.OnMouseMove(e);
  }

  private void StartWindowDragMove()
  {
    if (Window.GetWindow((DependencyObject) this) == null)
      return;
    this.Dispatcher.BeginInvoke(DispatcherPriority.Background, (Delegate) new DispatcherOperationCallback(this.DispatcherStartWindowDragMove), (object) null);
  }

  private object DispatcherStartWindowDragMove(object arg)
  {
    Window window = Window.GetWindow((DependencyObject) this);
    if (window != null)
    {
      if (Mouse.LeftButton == MouseButtonState.Pressed)
      {
        try
        {
          window.DragMove();
        }
        catch (InvalidOperationException ex)
        {
        }
      }
    }
    return (object) null;
  }

  protected override void OnMouseRightButtonUp(MouseButtonEventArgs e)
  {
    if (e.OriginalSource is FrameworkElement && ((FrameworkElement) e.OriginalSource).Name == "TitleBar" && this.SystemTitleElementsVisible)
    {
      this.ShowTitleContextMenu(this.PointToScreen(e.GetPosition((IInputElement) this)));
      e.Handled = true;
    }
    base.OnMouseRightButtonUp(e);
  }

  private void ShowTitleContextMenu(System.Windows.Point screenPos)
  {
    Window window = Window.GetWindow((DependencyObject) this);
    if (window == null)
      return;
    IntPtr handle = new WindowInteropHelper(window).Handle;
    byte[] bytes1 = BitConverter.GetBytes((int) screenPos.X);
    byte[] bytes2 = BitConverter.GetBytes((int) screenPos.Y);
    int int32 = BitConverter.ToInt32(new byte[4]
    {
      bytes1[0],
      bytes1[1],
      bytes2[0],
      bytes2[1]
    }, 0);
    WinApi.SendMessage(handle, 274, WinApi.TrackPopupMenu(WinApi.GetSystemMenu(handle, false), 256U /*0x0100*/, (int) screenPos.X, (int) screenPos.Y, 0, handle, IntPtr.Zero), int32);
  }

  protected override void OnMouseDoubleClick(MouseButtonEventArgs e)
  {
    if (e.OriginalSource is FrameworkElement && ((FrameworkElement) e.OriginalSource).Name == "TitleBar" || this.IsMouseInContextGroup())
      e.Handled = this.ToggleWindowState();
    else if (e.OriginalSource == this.m_WindowIcon)
    {
      Window window = Window.GetWindow((DependencyObject) this);
      if (window != null)
      {
        e.Handled = true;
        window.Close();
      }
    }
    base.OnMouseDoubleClick(e);
  }

  private bool IsMouseInContextGroup()
  {
    if (this.m_TitlePanel == null)
      return false;
    foreach (UIElement child in this.m_TitlePanel.Children)
    {
      if (child is ContextGroup contextGroup && contextGroup.Visibility == Visibility.Visible && contextGroup.IsMouseOver)
        return true;
    }
    return false;
  }

  private bool ToggleWindowState()
  {
    bool flag = false;
    if (!this.SystemTitleElementsVisible)
      return false;
    Window window = Window.GetWindow((DependencyObject) this);
    if (window != null && window.ResizeMode != ResizeMode.NoResize && !this.IsBrowserWindow(window))
    {
      if (window.WindowState == WindowState.Normal)
      {
        window.WindowState = WindowState.Maximized;
        flag = true;
      }
      else if (window.WindowState == WindowState.Maximized)
      {
        window.WindowState = WindowState.Normal;
        flag = true;
      }
    }
    return flag;
  }

  private void SysButtonClick(object sender, RoutedEventArgs e)
  {
    Window window = Window.GetWindow((DependencyObject) this);
    if (window == null || this.IsBrowserWindow(window))
      return;
    if (sender == this.m_MinButton)
      window.WindowState = WindowState.Minimized;
    else if (sender == this.m_MaxButton)
      window.WindowState = WindowState.Maximized;
    else if (sender == this.m_RestoreButton)
    {
      window.WindowState = WindowState.Normal;
    }
    else
    {
      if (sender != this.m_CloseButton)
        return;
      window.Close();
    }
  }

  private static DropShadowEffect CreateTitleEffect()
  {
    return new DropShadowEffect()
    {
      ShadowDepth = 0.0,
      Color = Colors.White,
      BlurRadius = 9.0,
      Opacity = 1.0
    };
  }

  private void LoadPanel(ContextGroupCollection contextGroupCollection)
  {
    if (this.m_TitlePanel == null || contextGroupCollection == null)
      return;
    this.m_TitlePanel.Children.Clear();
    foreach (ContextGroup contextGroup in (Collection<ContextGroup>) contextGroupCollection)
    {
      if (contextGroup.Parent is Panel)
        ((Panel) contextGroup.Parent).Children.Remove((UIElement) contextGroup);
      this.m_TitlePanel.Children.Add((UIElement) contextGroup);
    }
    Window window = Window.GetWindow((DependencyObject) this);
    if (window == null)
      return;
    Label label = new Label();
    label.IsHitTestVisible = false;
    label.HorizontalAlignment = HorizontalAlignment.Stretch;
    label.HorizontalContentAlignment = HorizontalAlignment.Center;
    if (this.IsGlassEnabled)
      label.SetResourceReference(Control.ForegroundProperty, (object) SystemColors.ActiveCaptionTextBrushKey);
    else
      label.SetResourceReference(Control.ForegroundProperty, (object) new ComponentResourceKey(typeof (Ribbon), (object) RibbonColors.WindowActiveTitleText));
    label.SnapsToDevicePixels = true;
    label.Name = "SysTitleLabel";
    label.FontSize = this.FontSize + 1.0;
    label.Visibility = this.SystemTitleElementsVisible ? Visibility.Visible : Visibility.Collapsed;
    BindingOperations.SetBinding((DependencyObject) label, ContentControl.ContentProperty, (BindingBase) new Binding("Title")
    {
      Source = (object) window
    });
    if (this.IsGlassEnabled)
      label.Effect = (Effect) RibbonBackgroundChrome.CreateTitleEffect();
    this.m_TitlePanel.Children.Add((UIElement) label);
    this.UpdateContextGroupGlassEffect();
  }

  private void UpdateTitleLabelAppearance()
  {
    if (this.m_TitlePanel == null)
      return;
    Label label = (Label) null;
    foreach (UIElement child in this.m_TitlePanel.Children)
    {
      if (child is Label && ((FrameworkElement) child).Name == "SysTitleLabel")
      {
        label = (Label) child;
        break;
      }
    }
    if (label == null)
      return;
    label.Visibility = this.SystemTitleElementsVisible ? Visibility.Visible : Visibility.Collapsed;
    if (this.IsGlassEnabled)
    {
      label.SetResourceReference(Control.ForegroundProperty, (object) SystemColors.ActiveCaptionTextBrushKey);
      Window window = Window.GetWindow((DependencyObject) this);
      if (window == null)
        return;
      bool flag = window.WindowState == WindowState.Maximized;
      label.Effect = (Effect) RibbonBackgroundChrome.CreateTitleEffect();
      label.Margin = flag ? new Thickness(0.0, 4.0, 0.0, 0.0) : new Thickness();
    }
    else
    {
      label.Effect = (Effect) null;
      label.SetResourceReference(Control.ForegroundProperty, (object) new ComponentResourceKey(typeof (Ribbon), (object) RibbonColors.WindowActiveTitleText));
    }
  }

  private void UpdateContextGroupGlassEffect()
  {
    if (this.m_ConnectedCollection == null)
      return;
    foreach (ContextGroup connected in (Collection<ContextGroup>) this.m_ConnectedCollection)
      connected.IsGlassEnabled = this.IsGlassEnabled;
  }

  private bool IsBrowserWindow(Window w) => w.ToString().Contains("RootBrowserWindow");

  internal void UpdateMinimalAppearance(bool newMin)
  {
    if (newMin)
    {
      if (this.m_WindowIcon == null || this.m_WindowIcon.Visibility == Visibility.Visible)
        return;
      this.m_WindowIcon.Visibility = Visibility.Visible;
    }
    else
    {
      if (this.EffectiveStyle != eEffectiveStyle.Office2007 || this.m_WindowIcon == null || this.m_WindowIcon.Visibility == Visibility.Collapsed)
        return;
      this.m_WindowIcon.Visibility = Visibility.Collapsed;
    }
  }

  private void UpdateSystemButtonVisibility()
  {
    Window window = Window.GetWindow((DependencyObject) this);
    if (window != null)
    {
      Visibility visibility1 = Visibility.Visible;
      Visibility visibility2 = Visibility.Visible;
      Visibility visibility3 = Visibility.Visible;
      Visibility visibility4;
      if (!this.SystemTitleElementsVisible)
      {
        visibility1 = Visibility.Collapsed;
        visibility2 = Visibility.Collapsed;
        visibility4 = Visibility.Collapsed;
        visibility3 = Visibility.Collapsed;
      }
      else if (this.IsGlassEnabled)
      {
        visibility1 = Visibility.Hidden;
        visibility2 = Visibility.Hidden;
        visibility4 = Visibility.Collapsed;
        visibility3 = Visibility.Hidden;
      }
      else if (this.IsBrowserWindow(window))
      {
        visibility4 = Visibility.Collapsed;
      }
      else
      {
        if (window.WindowState == WindowState.Maximized)
        {
          visibility2 = Visibility.Collapsed;
          visibility4 = Visibility.Visible;
        }
        else
        {
          visibility2 = Visibility.Visible;
          visibility4 = Visibility.Collapsed;
        }
        if (window.ResizeMode == ResizeMode.NoResize)
        {
          visibility2 = Visibility.Collapsed;
          visibility1 = Visibility.Collapsed;
          visibility4 = Visibility.Collapsed;
        }
      }
      this.MaximizeButtonVisibility = visibility2;
      this.RestoreButtonVisibility = visibility4;
      this.MinimizeButtonVisibility = visibility1;
      this.CloseButtonVisibility = visibility3;
    }
    else
    {
      this.MaximizeButtonVisibility = Visibility.Collapsed;
      this.RestoreButtonVisibility = Visibility.Collapsed;
      this.MinimizeButtonVisibility = Visibility.Collapsed;
      this.CloseButtonVisibility = Visibility.Collapsed;
    }
  }

  private void ContextGroupsChanged(object sender, NotifyCollectionChangedEventArgs e)
  {
    this.LoadPanel(sender as ContextGroupCollection);
  }

  public GridLength QatRightPosition
  {
    get => (GridLength) this.GetValue(RibbonBackgroundChrome.QatRightPositionProperty);
    set => this.SetValue(RibbonBackgroundChrome.QatRightPositionProperty, (object) value);
  }

  public bool IsActive
  {
    get => (bool) this.GetValue(RibbonBackgroundChrome.IsActiveProperty);
    set => this.SetValue(RibbonBackgroundChrome.IsActiveProperty, (object) value);
  }

  public WindowState WindowState
  {
    get => (WindowState) this.GetValue(RibbonBackgroundChrome.WindowStateProperty);
    set => this.SetValue(RibbonBackgroundChrome.WindowStateProperty, (object) value);
  }

  private static void WindowStateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
  {
    ((RibbonBackgroundChrome) d).OnWindowStateChanged();
  }

  private void OnWindowStateChanged()
  {
    this.UpdateSystemButtonVisibility();
    this.UpdateTitleLabelAppearance();
    this.UpdateTotalChromeHeight();
  }

  public bool IsGlassEnabled
  {
    get => (bool) this.GetValue(RibbonBackgroundChrome.IsGlassEnabledProperty);
    set => this.SetValue(RibbonBackgroundChrome.IsGlassEnabledProperty, (object) value);
  }

  private static void IsGlassEnabledChanged(
    DependencyObject d,
    DependencyPropertyChangedEventArgs e)
  {
    ((RibbonBackgroundChrome) d).OnIsGlassEnabledChanged();
  }

  private void OnIsGlassEnabledChanged()
  {
    this.UpdateSystemButtonVisibility();
    this.UpdateTitleLabelAppearance();
    this.UpdateContextGroupGlassEffect();
    this.TitleChromeHeight = (double) this.GetSystemCaptionHeight();
  }

  public double TitleChromeHeight
  {
    get => (double) this.GetValue(RibbonBackgroundChrome.TitleChromeHeightProperty);
    set => this.SetValue(RibbonBackgroundChrome.TitleChromeHeightProperty, (object) value);
  }

  private static void OnTitleChromeHeightChanged(
    DependencyObject d,
    DependencyPropertyChangedEventArgs e)
  {
    ((RibbonBackgroundChrome) d).OnTitleChromeHeightChanged((double) e.NewValue);
  }

  private void OnTitleChromeHeightChanged(double d)
  {
    this.UpdateTotalChromeHeight();
    this.UpdateTitlePanelChromeHeight();
  }

  private void UpdateTitlePanelChromeHeight()
  {
    if (this.m_TitlePanel == null)
      return;
    this.m_TitlePanel.TitleChromeHeight = this.TotalTitleChromeHeight - (double) (this.IsGlassEnabled ? 1 : 0);
    this.m_TitlePanel.Margin = new Thickness(0.0, this.WindowBorderThickness.Top, 0.0, 0.0);
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  [Browsable(false)]
  public double TotalTitleChromeHeight
  {
    get => (double) this.GetValue(RibbonBackgroundChrome.TotalTitleChromeHeightProperty);
    internal set
    {
      this.SetValue(RibbonBackgroundChrome.TotalTitleChromeHeightPropertyKey, (object) value);
    }
  }

  private void UpdateTotalChromeHeight()
  {
    double num = 0.0;
    if (this.IsGlassEnabled)
    {
      Window window = Window.GetWindow((DependencyObject) this);
      if (window != null && window.WindowState == WindowState.Maximized)
        num = RibbonWindow.MaximizedGlassTopAdjustment;
    }
    this.TotalTitleChromeHeight = this.TitleChromeHeight + this.WindowBorderThickness.Top + num;
  }

  private static void OnQatRightPositionChanged(
    DependencyObject d,
    DependencyPropertyChangedEventArgs e)
  {
    ((RibbonBackgroundChrome) d).OnQatRightPositionChanged((GridLength) e.NewValue);
  }

  private void OnQatRightPositionChanged(GridLength p)
  {
    if (this.m_TitlePanel == null)
      return;
    this.m_TitlePanel.QatRightPosition = p.Value;
  }

  internal double TabXPosition
  {
    get => this.m_TabXPosition;
    set
    {
      this.m_TabXPosition = value;
      if (this.m_TitlePanel == null)
        return;
      this.m_TitlePanel.TabXPosition = value;
    }
  }

  [Browsable(false)]
  public Visibility CloseButtonVisibility
  {
    get => (Visibility) this.GetValue(RibbonBackgroundChrome.CloseButtonVisibilityProperty);
    set => this.SetValue(RibbonBackgroundChrome.CloseButtonVisibilityProperty, (object) value);
  }

  [Browsable(false)]
  public Visibility RestoreButtonVisibility
  {
    get => (Visibility) this.GetValue(RibbonBackgroundChrome.RestoreButtonVisibilityProperty);
    set => this.SetValue(RibbonBackgroundChrome.RestoreButtonVisibilityProperty, (object) value);
  }

  [Browsable(false)]
  public Visibility MinimizeButtonVisibility
  {
    get => (Visibility) this.GetValue(RibbonBackgroundChrome.MinimizeButtonVisibilityProperty);
    set => this.SetValue(RibbonBackgroundChrome.MinimizeButtonVisibilityProperty, (object) value);
  }

  [Browsable(false)]
  public Visibility MaximizeButtonVisibility
  {
    get => (Visibility) this.GetValue(RibbonBackgroundChrome.MaximizeButtonVisibilityProperty);
    set => this.SetValue(RibbonBackgroundChrome.MaximizeButtonVisibilityProperty, (object) value);
  }

  public Thickness WindowBorderThickness
  {
    get => (Thickness) this.GetValue(RibbonBackgroundChrome.WindowBorderThicknessProperty);
    set => this.SetValue(RibbonBackgroundChrome.WindowBorderThicknessProperty, (object) value);
  }

  private static void WindowBorderThicknessChanged(
    DependencyObject d,
    DependencyPropertyChangedEventArgs e)
  {
    ((RibbonBackgroundChrome) d).OnWindowBorderThicknessChanged((Thickness) e.NewValue);
  }

  private void OnWindowBorderThicknessChanged(Thickness t)
  {
    this.UpdateTotalChromeHeight();
    this.UpdateTitlePanelChromeHeight();
    this.HorizontalWindowBorderThickness = new Thickness(t.Left, 0.0, t.Right, 0.0);
  }

  public Thickness HorizontalWindowBorderThickness
  {
    get
    {
      return (Thickness) this.GetValue(RibbonBackgroundChrome.HorizontalWindowBorderThicknessProperty);
    }
    internal set
    {
      this.SetValue(RibbonBackgroundChrome.HorizontalWindowBorderThicknessPropertyKey, (object) value);
    }
  }

  private int GetSystemCaptionHeight() => 28;

  [Browsable(true)]
  [DefaultValue(true)]
  public bool SystemButtons
  {
    get => (bool) this.GetValue(RibbonBackgroundChrome.SystemButtonsProperty);
    set => this.SetValue(RibbonBackgroundChrome.SystemButtonsProperty, (object) value);
  }

  private static void OnSystemButtonsChanged(
    DependencyObject d,
    DependencyPropertyChangedEventArgs e)
  {
    ((RibbonBackgroundChrome) d).OnSystemButtonsChanged();
  }

  private void OnSystemButtonsChanged()
  {
    this.UpdateSystemButtonVisibility();
    this.UpdateTitleLabelAppearance();
  }
}
