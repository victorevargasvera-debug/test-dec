// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.RibbonBar
// Assembly: AcpWpfRibbon, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 45A745B5-88C3-40EE-B1E5-8DBA2EACD529
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfRibbon.dll

using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

#nullable disable
namespace DevComponents.WpfRibbon;

[TemplatePart(Name = "PART_RibbonBarBorder", Type = typeof (Decorator))]
public class RibbonBar : HeaderedPopupControl
{
  public static readonly DependencyProperty VisualStyleProperty = Ribbon.VisualStyleProperty.AddOwner(typeof (RibbonBar), (PropertyMetadata) new FrameworkPropertyMetadata((object) eRibbonVisualStyle.Office2007Blue, FrameworkPropertyMetadataOptions.Inherits, new PropertyChangedCallback(RibbonBar.OnVisualStyleChanged)));
  private static readonly DependencyPropertyKey EffectiveStylePropertyKey = DependencyProperty.RegisterReadOnly(nameof (EffectiveStyle), typeof (eEffectiveStyle), typeof (RibbonBar), (PropertyMetadata) new UIPropertyMetadata((object) eEffectiveStyle.Office2007, new PropertyChangedCallback(RibbonBar.OnEffectiveStyleChanged)));
  public static readonly DependencyProperty EffectiveStyleProperty = RibbonBar.EffectiveStylePropertyKey.DependencyProperty;
  public static RoutedEvent LaunchDialogEvent;
  public static DependencyProperty DialogLauncherVisibleProperty;
  public static DependencyProperty IsAutoSizeEnabledProperty;
  public static DependencyProperty ResizeOrderIndexProperty;
  public static DependencyProperty CollapsedImageProperty;
  public static readonly DependencyProperty MinAutoSizeHintProperty;
  public static readonly DependencyProperty CollapsedHeaderProperty;
  public static readonly RoutedEvent CollapsedStateChangedEvent = EventManager.RegisterRoutedEvent("CollapsedStateChanged", RoutingStrategy.Bubble, typeof (RoutedEventHandler), typeof (RibbonBar));
  private const string RibbonBarBorderName = "PART_RibbonBarBorder";
  private const string RibbonBarTitleName = "PART_RibbonBarTitle";
  private const string DialogLauncherButtonName = "PART_DialogLauncher";
  private const string RibbonBarPanelName = "PART_RibbonBarPanel";
  private RibbonBorder m_Border;
  private RibbonBorder m_Title;
  private ButtonDropDown m_DialogLauncherButton;
  private ButtonPanel m_ButtonPanel;
  private bool m_IsCollapsed;
  private bool m_MeasureNeedCollapse;
  private bool m_IsSecondMeasurePass;
  private Size m_LastPanelMeasureSize;
  internal bool IsRibbonBarPanelMeasure;

  public eRibbonVisualStyle VisualStyle
  {
    get => (eRibbonVisualStyle) this.GetValue(RibbonBar.VisualStyleProperty);
    set => this.SetValue(RibbonBar.VisualStyleProperty, (object) value);
  }

  private static void OnVisualStyleChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
  {
    ((RibbonBar) o).OnVisualStyleChanged((eRibbonVisualStyle) e.OldValue, (eRibbonVisualStyle) e.NewValue);
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
    get => (eEffectiveStyle) this.GetValue(RibbonBar.EffectiveStyleProperty);
    internal set => this.SetValue(RibbonBar.EffectiveStylePropertyKey, (object) value);
  }

  private static void OnEffectiveStyleChanged(
    DependencyObject o,
    DependencyPropertyChangedEventArgs e)
  {
    if (!(o is RibbonBar ribbonBar))
      return;
    ribbonBar.OnEffectiveStyleChanged((eEffectiveStyle) e.OldValue, (eEffectiveStyle) e.NewValue);
  }

  protected virtual void OnEffectiveStyleChanged(eEffectiveStyle oldValue, eEffectiveStyle newValue)
  {
  }

  public event RoutedEventHandler CollapsedStateChanged
  {
    add => this.AddHandler(RibbonBar.CollapsedStateChangedEvent, (Delegate) value);
    remove => this.RemoveHandler(RibbonBar.CollapsedStateChangedEvent, (Delegate) value);
  }

  protected virtual void OnCollapsedStateChanged()
  {
    this.RaiseEvent(new RoutedEventArgs(RibbonBar.CollapsedStateChangedEvent));
  }

  static RibbonBar()
  {
    FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof (RibbonBar), (PropertyMetadata) new FrameworkPropertyMetadata((object) typeof (RibbonBar)));
    RibbonBar.LaunchDialogEvent = EventManager.RegisterRoutedEvent("LaunchDialog", RoutingStrategy.Direct, typeof (EventHandler), typeof (RibbonBar));
    RibbonBar.DialogLauncherVisibleProperty = DependencyProperty.Register(nameof (DialogLauncherVisible), typeof (Visibility), typeof (RibbonBar), new PropertyMetadata((object) Visibility.Visible));
    RibbonBar.ResizeOrderIndexProperty = DependencyProperty.Register(nameof (ResizeOrderIndex), typeof (int), typeof (RibbonBar), new PropertyMetadata((object) 0));
    RibbonBar.CollapsedImageProperty = DependencyProperty.Register(nameof (CollapsedImage), typeof (object), typeof (RibbonBar), new PropertyMetadata((PropertyChangedCallback) null));
    RibbonBar.MinAutoSizeHintProperty = DependencyProperty.RegisterAttached("MinAutoSizeHint", typeof (eAutoSizeHint), typeof (RibbonBar), (PropertyMetadata) new FrameworkPropertyMetadata((object) eAutoSizeHint.Small, new PropertyChangedCallback(RibbonBar.OnMinAutoSizeHintChanged)), new ValidateValueCallback(RibbonBar.IsMinAutoSizeHintValid));
    RibbonBar.CollapsedHeaderProperty = DependencyProperty.Register(nameof (CollapsedHeader), typeof (object), typeof (RibbonBar), new PropertyMetadata((PropertyChangedCallback) null));
    RibbonBar.IsAutoSizeEnabledProperty = DependencyProperty.Register(nameof (IsAutoSizeEnabled), typeof (bool), typeof (RibbonBar), new PropertyMetadata((object) true));
    Control.IsTabStopProperty.OverrideMetadata(typeof (RibbonBar), (PropertyMetadata) new FrameworkPropertyMetadata((object) false));
    KeyboardNavigation.DirectionalNavigationProperty.OverrideMetadata(typeof (RibbonBar), (PropertyMetadata) new FrameworkPropertyMetadata((object) KeyboardNavigationMode.Local));
    KeyboardNavigation.TabNavigationProperty.OverrideMetadata(typeof (RibbonBar), (PropertyMetadata) new FrameworkPropertyMetadata((object) KeyboardNavigationMode.Local));
  }

  public event RoutedEventHandler LaunchDialog
  {
    add => this.AddHandler(RibbonBar.LaunchDialogEvent, (Delegate) value);
    remove => this.RemoveHandler(RibbonBar.LaunchDialogEvent, (Delegate) value);
  }

  [DefaultValue(0)]
  public int ResizeOrderIndex
  {
    get => (int) this.GetValue(RibbonBar.ResizeOrderIndexProperty);
    set => this.SetValue(RibbonBar.ResizeOrderIndexProperty, (object) value);
  }

  protected virtual void OnLaunchDialog()
  {
    this.RaiseEvent(new RoutedEventArgs()
    {
      RoutedEvent = RibbonBar.LaunchDialogEvent
    });
  }

  internal void InvokeLaunchDialog() => this.OnLaunchDialog();

  [DefaultValue(Visibility.Visible)]
  public Visibility DialogLauncherVisible
  {
    get => (Visibility) this.GetValue(RibbonBar.DialogLauncherVisibleProperty);
    set => this.SetValue(RibbonBar.DialogLauncherVisibleProperty, (object) value);
  }

  public override void OnApplyTemplate()
  {
    if (this.m_DialogLauncherButton != null)
      this.m_DialogLauncherButton.Click -= new RoutedEventHandler(this.LauncherClick);
    this.m_DialogLauncherButton = this.GetTemplateChild("PART_DialogLauncher") as ButtonDropDown;
    this.m_Border = this.GetTemplateChild("PART_RibbonBarBorder") as RibbonBorder;
    this.m_Title = this.GetTemplateChild("PART_RibbonBarTitle") as RibbonBorder;
    this.m_ButtonPanel = this.GetTemplateChild("PART_RibbonBarPanel") as ButtonPanel;
    if (this.m_DialogLauncherButton != null)
      this.m_DialogLauncherButton.Click += new RoutedEventHandler(this.LauncherClick);
    base.OnApplyTemplate();
  }

  protected override void OnInitialized(EventArgs e) => base.OnInitialized(e);

  private void LauncherClick(object sender, RoutedEventArgs e)
  {
    this.OnLaunchDialog();
    e.Handled = true;
  }

  protected override void OnMouseEnter(MouseEventArgs e)
  {
    if (this.m_Border != null)
      this.m_Border.BorderState = eRibbonBarRenderingState.Hover;
    if (this.m_Title != null)
      this.m_Title.BorderState = eRibbonBarRenderingState.Hover;
    base.OnMouseEnter(e);
  }

  protected override void OnMouseLeave(MouseEventArgs e)
  {
    if (this.m_Border != null)
      this.m_Border.BorderState = eRibbonBarRenderingState.Normal;
    if (this.m_Title != null)
      this.m_Title.BorderState = eRibbonBarRenderingState.Normal;
    base.OnMouseLeave(e);
  }

  public bool IsCollapsed
  {
    get => this.m_IsCollapsed;
    internal set
    {
      if (this.m_IsCollapsed == value)
        return;
      this.m_IsCollapsed = value;
      this.OnCollapsedStateChanged();
    }
  }

  [DefaultValue(null)]
  public object CollapsedImage
  {
    get => this.GetValue(RibbonBar.CollapsedImageProperty);
    set => this.SetValue(RibbonBar.CollapsedImageProperty, value);
  }

  [DefaultValue(null)]
  public object CollapsedHeader
  {
    get => this.GetValue(RibbonBar.CollapsedHeaderProperty);
    set => this.SetValue(RibbonBar.CollapsedHeaderProperty, value);
  }

  internal bool MeasureNeedCollapse
  {
    get => this.m_MeasureNeedCollapse;
    set => this.m_MeasureNeedCollapse = value;
  }

  internal bool IsSecondMeasurePass
  {
    get => this.m_IsSecondMeasurePass;
    set => this.m_IsSecondMeasurePass = value;
  }

  internal Size LastPanelMeasureSize
  {
    get => this.m_LastPanelMeasureSize;
    set => this.m_LastPanelMeasureSize = value;
  }

  [AttachedPropertyBrowsableForChildren]
  public static eAutoSizeHint GetMinAutoSizeHint(UIElement element)
  {
    return element != null ? (eAutoSizeHint) element.GetValue(RibbonBar.MinAutoSizeHintProperty) : throw new ArgumentNullException("elem");
  }

  public static void SetMinAutoSizeHint(UIElement element, eAutoSizeHint part)
  {
    if (element == null)
      throw new ArgumentNullException("elem");
    element.SetValue(RibbonBar.MinAutoSizeHintProperty, (object) part);
  }

  private static void OnMinAutoSizeHintChanged(
    DependencyObject d,
    DependencyPropertyChangedEventArgs e)
  {
    if (!(d is UIElement reference) || !(VisualTreeHelper.GetParent((DependencyObject) reference) is ButtonPanel parent))
      return;
    parent.InvalidateMeasure();
  }

  private static bool IsMinAutoSizeHintValid(object o)
  {
    switch ((eAutoSizeHint) o)
    {
      case eAutoSizeHint.Small:
      case eAutoSizeHint.Medium:
      case eAutoSizeHint.NoAutoSize:
        return true;
      default:
        return false;
    }
  }

  [Browsable(true)]
  [DefaultValue(true)]
  public bool IsAutoSizeEnabled
  {
    get => (bool) this.GetValue(RibbonBar.IsAutoSizeEnabledProperty);
    set => this.SetValue(RibbonBar.IsAutoSizeEnabledProperty, (object) value);
  }

  internal ButtonPanel ButtonPanel => this.m_ButtonPanel;

  internal RibbonBar Copy(bool deepCopy) => CloningMachine.Clone(this, deepCopy);
}
