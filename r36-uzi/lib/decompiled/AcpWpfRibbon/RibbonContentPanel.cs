// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.RibbonContentPanel
// Assembly: AcpWpfRibbon, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 45A745B5-88C3-40EE-B1E5-8DBA2EACD529
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfRibbon.dll

using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

#nullable disable
namespace DevComponents.WpfRibbon;

[DesignTimeVisible(false)]
public class RibbonContentPanel : Panel
{
  public static readonly DependencyProperty VisualStyleProperty = Ribbon.VisualStyleProperty.AddOwner(typeof (RibbonContentPanel), (PropertyMetadata) new FrameworkPropertyMetadata((object) eRibbonVisualStyle.Office2007Blue, FrameworkPropertyMetadataOptions.Inherits, new PropertyChangedCallback(RibbonContentPanel.OnVisualStyleChanged)));
  private static readonly DependencyPropertyKey EffectiveStylePropertyKey = DependencyProperty.RegisterReadOnly(nameof (EffectiveStyle), typeof (eEffectiveStyle), typeof (RibbonContentPanel), (PropertyMetadata) new UIPropertyMetadata((object) eEffectiveStyle.Office2007, new PropertyChangedCallback(RibbonContentPanel.OnEffectiveStyleChanged)));
  public static readonly DependencyProperty EffectiveStyleProperty = RibbonContentPanel.EffectiveStylePropertyKey.DependencyProperty;
  public static readonly DependencyProperty ContentPartProperty = DependencyProperty.RegisterAttached("ContentPart", typeof (eRibbonContentPart), typeof (RibbonContentPanel), (PropertyMetadata) new FrameworkPropertyMetadata((object) eRibbonContentPart.None, new PropertyChangedCallback(RibbonContentPanel.OnContentPartChanged)), new ValidateValueCallback(RibbonContentPanel.IsPartValid));
  public static readonly DependencyProperty WindowBorderThicknessProperty = Ribbon.WindowBorderThicknessProperty.AddOwner(typeof (RibbonContentPanel), (PropertyMetadata) new FrameworkPropertyMetadata((object) new Thickness(3.0, 0.0, 3.0, 0.0), FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(RibbonContentPanel.OnWindowBorderThicknessChanged)));
  public static readonly DependencyProperty IsGlassEnabledProperty = DependencyProperty.Register(nameof (IsGlassEnabled), typeof (bool), typeof (RibbonContentPanel), (PropertyMetadata) new FrameworkPropertyMetadata((object) false, FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(RibbonContentPanel.IsGlassEnabledChanged)));
  public static readonly DependencyProperty IsVisibleAutoChangedProperty = DependencyProperty.RegisterAttached("IsVisibleAutoChanged", typeof (bool), typeof (RibbonContentPanel), new PropertyMetadata((object) false));
  private int QatTabSpacing = 1;
  private RibbonBackgroundChrome m_BackChrome;
  private const int MinSystemItemsSize = 120;

  public eRibbonVisualStyle VisualStyle
  {
    get => (eRibbonVisualStyle) this.GetValue(RibbonContentPanel.VisualStyleProperty);
    set => this.SetValue(RibbonContentPanel.VisualStyleProperty, (object) value);
  }

  private static void OnVisualStyleChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
  {
    ((RibbonContentPanel) o).OnVisualStyleChanged((eRibbonVisualStyle) e.OldValue, (eRibbonVisualStyle) e.NewValue);
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
    get => (eEffectiveStyle) this.GetValue(RibbonContentPanel.EffectiveStyleProperty);
    internal set => this.SetValue(RibbonContentPanel.EffectiveStylePropertyKey, (object) value);
  }

  private static void OnEffectiveStyleChanged(
    DependencyObject o,
    DependencyPropertyChangedEventArgs e)
  {
    if (!(o is RibbonContentPanel ribbonContentPanel))
      return;
    ribbonContentPanel.OnEffectiveStyleChanged((eEffectiveStyle) e.OldValue, (eEffectiveStyle) e.NewValue);
  }

  protected virtual void OnEffectiveStyleChanged(eEffectiveStyle oldValue, eEffectiveStyle newValue)
  {
  }

  protected override void OnInitialized(EventArgs e)
  {
    this.CreateBackgroundChrome();
    base.OnInitialized(e);
  }

  protected override Size MeasureOverride(Size availableSize)
  {
    UIElementCollection internalChildren = this.InternalChildren;
    Size s1 = new Size();
    Size s2 = new Size();
    Size size = new Size();
    UIElement uiElement = (UIElement) null;
    bool isMinimumSized = this.GetIsMinimumSized();
    foreach (UIElement element in internalChildren)
    {
      if (isMinimumSized && element != this.m_BackChrome && element.Visibility != Visibility.Collapsed)
      {
        element.Visibility = Visibility.Collapsed;
        RibbonContentPanel.SetIsVisibleAutoChanged(element, true);
      }
      else if (!isMinimumSized && RibbonContentPanel.GetIsVisibleAutoChanged(element))
      {
        element.Visibility = Visibility.Visible;
        RibbonContentPanel.SetIsVisibleAutoChanged(element, false);
      }
      if (RibbonContentPanel.GetContentPart(element) == eRibbonContentPart.ApplicationMenu && element.Visibility != Visibility.Collapsed)
      {
        element.Measure(availableSize);
        s1 = element.DesiredSize;
      }
      else if (RibbonContentPanel.GetContentPart(element) == eRibbonContentPart.QuickAccessToolbar && element.Visibility != Visibility.Collapsed)
      {
        Size availableSize1 = availableSize;
        if (availableSize.Width < double.PositiveInfinity)
          availableSize1.Width = Math.Max(availableSize.Width - 120.0, 22.0);
        element.Measure(availableSize1);
        s2 = element.DesiredSize;
      }
      else if (RibbonContentPanel.GetContentPart(element) == eRibbonContentPart.Tabs)
        uiElement = element;
      else if (element != this.m_BackChrome && element.Visibility != Visibility.Collapsed)
        element.Measure(availableSize);
    }
    Thickness windowBorderThickness;
    if (uiElement != null && uiElement.Visibility != Visibility.Collapsed)
    {
      Size availableSize2 = availableSize;
      availableSize2.Width = Math.Max(6.0, availableSize2.Width - s1.Width) - this.WindowBorderThickness.Right;
      uiElement.Measure(availableSize2);
      size = uiElement.DesiredSize;
      ref Size local1 = ref size;
      double height = local1.Height;
      windowBorderThickness = this.WindowBorderThickness;
      double top = windowBorderThickness.Top;
      local1.Height = height + top;
      ref Size local2 = ref size;
      double width = local2.Width;
      windowBorderThickness = this.WindowBorderThickness;
      double right = windowBorderThickness.Right;
      local2.Width = width + right;
    }
    bool flag = !LayoutHelpers.IsEmpty(s1) || !LayoutHelpers.IsEmpty(s2) || isMinimumSized;
    Size availableSize3;
    if (this.EffectiveStyle == eEffectiveStyle.Office2007)
    {
      if (flag)
      {
        ref Size local = ref availableSize3;
        double num1 = Math.Max(s1.Width + s2.Width, size.Width);
        windowBorderThickness = this.WindowBorderThickness;
        double left = windowBorderThickness.Left;
        double num2 = num1 + left;
        windowBorderThickness = this.WindowBorderThickness;
        double right = windowBorderThickness.Right;
        double width = num2 + right;
        double height1 = s1.Height;
        double num3 = Math.Max(s2.Height, this.m_BackChrome.TitleChromeHeight) + size.Height + (double) this.QatTabSpacing;
        windowBorderThickness = this.WindowBorderThickness;
        double top = windowBorderThickness.Top;
        double val2 = num3 + top;
        double height2 = Math.Max(height1, val2);
        local = new Size(width, height2);
      }
      else
      {
        ref Size local = ref availableSize3;
        double num4 = Math.Max(s1.Width + s2.Width, size.Width);
        windowBorderThickness = this.WindowBorderThickness;
        double left = windowBorderThickness.Left;
        double num5 = num4 + left;
        windowBorderThickness = this.WindowBorderThickness;
        double right = windowBorderThickness.Right;
        double width = num5 + right;
        double num6 = Math.Max(s1.Height, s2.Height) + size.Height;
        windowBorderThickness = this.WindowBorderThickness;
        double top = windowBorderThickness.Top;
        double height = num6 + top;
        local = new Size(width, height);
      }
    }
    else if (flag)
    {
      ref Size local = ref availableSize3;
      double num7 = Math.Max(s1.Width + size.Width, s2.Width);
      windowBorderThickness = this.WindowBorderThickness;
      double left = windowBorderThickness.Left;
      double num8 = num7 + left;
      windowBorderThickness = this.WindowBorderThickness;
      double right = windowBorderThickness.Right;
      double width = num8 + right;
      double num9 = Math.Max(s2.Height, this.m_BackChrome.TitleChromeHeight) + Math.Max(s1.Height, size.Height) + (double) this.QatTabSpacing;
      windowBorderThickness = this.WindowBorderThickness;
      double top = windowBorderThickness.Top;
      double height = num9 + top;
      local = new Size(width, height);
    }
    else
    {
      ref Size local = ref availableSize3;
      double num10 = Math.Max(s1.Width + s2.Width, size.Width);
      windowBorderThickness = this.WindowBorderThickness;
      double left = windowBorderThickness.Left;
      double num11 = num10 + left;
      windowBorderThickness = this.WindowBorderThickness;
      double right = windowBorderThickness.Right;
      double width = num11 + right;
      double num12 = Math.Max(s1.Height, s2.Height) + size.Height;
      windowBorderThickness = this.WindowBorderThickness;
      double top = windowBorderThickness.Top;
      double height = num12 + top;
      local = new Size(width, height);
    }
    if (isMinimumSized)
      availableSize3 = new Size(availableSize.Width, this.m_BackChrome.TotalTitleChromeHeight);
    if (availableSize3.Width > availableSize.Width)
      availableSize3.Width = availableSize.Width;
    if (this.m_BackChrome != null)
    {
      if (LayoutHelpers.IsEmpty(s1) && LayoutHelpers.IsEmpty(s2) && !isMinimumSized)
      {
        if (this.m_BackChrome.Visibility == Visibility.Visible)
          this.m_BackChrome.Visibility = Visibility.Collapsed;
      }
      else
      {
        if (this.m_BackChrome.Visibility != Visibility.Visible)
          this.m_BackChrome.Visibility = Visibility.Visible;
        this.m_BackChrome.Measure(availableSize3);
      }
      this.m_BackChrome.UpdateMinimalAppearance(isMinimumSized);
    }
    return availableSize3;
  }

  private bool GetIsMinimumSized()
  {
    return this.TemplatedParent is Ribbon && ((Ribbon) this.TemplatedParent).IsBelowMinimumSize;
  }

  protected override Size ArrangeOverride(Size finalSize)
  {
    UIElementCollection internalChildren = this.InternalChildren;
    UIElement uiElement1 = (UIElement) null;
    UIElement uiElement2 = (UIElement) null;
    UIElement uiElement3 = (UIElement) null;
    foreach (UIElement element in internalChildren)
    {
      if (RibbonContentPanel.GetContentPart(element) == eRibbonContentPart.ApplicationMenu)
        uiElement1 = element;
      else if (RibbonContentPanel.GetContentPart(element) == eRibbonContentPart.QuickAccessToolbar)
        uiElement2 = element;
      else if (RibbonContentPanel.GetContentPart(element) == eRibbonContentPart.Tabs)
        uiElement3 = element;
      else
        element.Arrange(new Rect(finalSize));
    }
    double num1 = 0.0;
    double num2 = 0.0;
    eEffectiveStyle effectiveStyle = this.EffectiveStyle;
    double num3 = effectiveStyle == eEffectiveStyle.Office2010 ? 0.0 : 6.0;
    if (effectiveStyle == eEffectiveStyle.Office2007 && uiElement1 != null && (!(uiElement1 is ContentPresenter) || ((ContentPresenter) uiElement1).Content != null) && uiElement1.Visibility != Visibility.Collapsed)
    {
      Rect finalRect = new Rect(new System.Windows.Point(this.WindowBorderThickness.Left - 3.0, this.WindowBorderThickness.Top), uiElement1.DesiredSize);
      uiElement1.Arrange(finalRect);
      num1 = finalRect.Right - 12.0;
      num3 = finalRect.Right - 2.0;
    }
    else if (effectiveStyle == eEffectiveStyle.Office2010)
      num1 = 8.0;
    Size desiredSize1;
    if (uiElement2 != null && (!(uiElement2 is ContentPresenter) || ((ContentPresenter) uiElement2).Content != null) && uiElement2.Visibility != Visibility.Collapsed)
    {
      UIElement uiElement4 = uiElement2;
      double x = num1;
      double y = this.WindowBorderThickness.Top + 1.0;
      double width = uiElement2.DesiredSize.Width;
      desiredSize1 = uiElement2.DesiredSize;
      double height = desiredSize1.Height;
      Rect finalRect = new Rect(x, y, width, height);
      uiElement4.Arrange(finalRect);
      desiredSize1 = uiElement2.DesiredSize;
      num2 = desiredSize1.Height + (double) this.QatTabSpacing;
      if (uiElement2 is ContentPresenter && ((ContentPresenter) uiElement2).Content is Qat && ((Qat) ((ContentPresenter) uiElement2).Content).IsGlassEnabled != this.IsGlassEnabled)
        ((Qat) ((ContentPresenter) uiElement2).Content).IsGlassEnabled = this.IsGlassEnabled;
    }
    if (effectiveStyle == eEffectiveStyle.Office2010 && uiElement1 != null && (!(uiElement1 is ContentPresenter) || ((ContentPresenter) uiElement1).Content != null) && uiElement1.Visibility != Visibility.Collapsed)
    {
      Rect finalRect;
      ref Rect local = ref finalRect;
      double x = num3;
      double height1 = finalSize.Height;
      desiredSize1 = uiElement1.DesiredSize;
      double height2 = desiredSize1.Height;
      double y = height1 - height2 + 1.0;
      System.Windows.Point location = new System.Windows.Point(x, y);
      Size desiredSize2 = uiElement1.DesiredSize;
      local = new Rect(location, desiredSize2);
      uiElement1.Arrange(finalRect);
      double num4 = num3;
      desiredSize1 = uiElement1.DesiredSize;
      double num5 = desiredSize1.Width + 1.0;
      num3 = num4 + num5;
    }
    if (uiElement3 != null && uiElement3.Visibility != Visibility.Collapsed)
    {
      double height3 = finalSize.Height;
      desiredSize1 = uiElement3.DesiredSize;
      double height4 = desiredSize1.Height;
      double num6 = height3 - height4;
      UIElement uiElement5 = uiElement3;
      double x = num3;
      double y = num6;
      double width = Math.Max(finalSize.Width - num3 - this.WindowBorderThickness.Right, 16.0);
      desiredSize1 = uiElement3.DesiredSize;
      double height5 = desiredSize1.Height;
      Rect finalRect = new Rect(x, y, width, height5);
      uiElement5.Arrange(finalRect);
    }
    if (this.m_BackChrome != null)
    {
      if (uiElement2 != null && uiElement2.Visibility != Visibility.Collapsed)
      {
        RibbonBackgroundChrome backChrome = this.m_BackChrome;
        double num7 = num1;
        double num8;
        if (uiElement2 == null)
        {
          num8 = 0.0;
        }
        else
        {
          desiredSize1 = uiElement2.DesiredSize;
          num8 = desiredSize1.Width;
        }
        GridLength gridLength = new GridLength(num7 + num8);
        backChrome.QatRightPosition = gridLength;
      }
      else
        this.m_BackChrome.QatRightPosition = new GridLength(0.0);
      this.m_BackChrome.TabXPosition = num3;
      this.m_BackChrome.Arrange(new Rect(finalSize));
    }
    return finalSize;
  }

  [AttachedPropertyBrowsableForChildren]
  public static eRibbonContentPart GetContentPart(UIElement element)
  {
    return element != null ? (eRibbonContentPart) element.GetValue(RibbonContentPanel.ContentPartProperty) : throw new ArgumentNullException("elem");
  }

  public static void SetContentPart(UIElement element, eRibbonContentPart part)
  {
    if (element == null)
      throw new ArgumentNullException("elem");
    element.SetValue(RibbonContentPanel.ContentPartProperty, (object) part);
  }

  private static void OnContentPartChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
  {
    if (!(d is UIElement reference) || !(VisualTreeHelper.GetParent((DependencyObject) reference) is RibbonContentPanel parent))
      return;
    parent.InvalidateMeasure();
  }

  private static bool IsPartValid(object o)
  {
    switch ((eRibbonContentPart) o)
    {
      case eRibbonContentPart.ApplicationMenu:
      case eRibbonContentPart.QuickAccessToolbar:
      case eRibbonContentPart.Tabs:
      case eRibbonContentPart.None:
        return true;
      default:
        return false;
    }
  }

  private void CreateBackgroundChrome()
  {
    if (this.m_BackChrome != null)
      return;
    this.m_BackChrome = new RibbonBackgroundChrome();
    this.m_BackChrome.WindowBorderThickness = this.WindowBorderThickness;
    this.m_BackChrome.IsGlassEnabled = this.IsGlassEnabled;
    this.Children.Add((UIElement) this.m_BackChrome);
    Panel.SetZIndex((UIElement) this.m_BackChrome, -1);
  }

  internal RibbonBackgroundChrome BackgroundChrome => this.m_BackChrome;

  public Thickness WindowBorderThickness
  {
    get => (Thickness) this.GetValue(RibbonContentPanel.WindowBorderThicknessProperty);
    set => this.SetValue(RibbonContentPanel.WindowBorderThicknessProperty, (object) value);
  }

  private static void OnWindowBorderThicknessChanged(
    DependencyObject d,
    DependencyPropertyChangedEventArgs e)
  {
    ((RibbonContentPanel) d).OnWindowBorderThicknessChanged((Thickness) e.NewValue);
  }

  private void OnWindowBorderThicknessChanged(Thickness t)
  {
    if (this.m_BackChrome == null)
      return;
    this.m_BackChrome.WindowBorderThickness = t;
  }

  public bool IsGlassEnabled
  {
    get => (bool) this.GetValue(RibbonContentPanel.IsGlassEnabledProperty);
    set => this.SetValue(RibbonContentPanel.IsGlassEnabledProperty, (object) value);
  }

  private static void IsGlassEnabledChanged(
    DependencyObject d,
    DependencyPropertyChangedEventArgs e)
  {
    ((RibbonContentPanel) d).OnIsGlassEnabledChanged((bool) e.NewValue);
  }

  private void OnIsGlassEnabledChanged(bool newValue)
  {
    if (this.m_BackChrome != null)
      this.m_BackChrome.IsGlassEnabled = newValue;
    foreach (UIElement internalChild in this.InternalChildren)
    {
      if (internalChild is ContentPresenter && ((ContentPresenter) internalChild).Content is Qat)
      {
        (((ContentPresenter) internalChild).Content as Qat).IsGlassEnabled = newValue;
        break;
      }
    }
  }

  internal static bool GetIsVisibleAutoChanged(UIElement element)
  {
    return element != null ? (bool) element.GetValue(RibbonContentPanel.IsVisibleAutoChangedProperty) : throw new ArgumentNullException("elem");
  }

  internal static void SetIsVisibleAutoChanged(UIElement element, bool value)
  {
    if (element == null)
      throw new ArgumentNullException("elem");
    element.SetValue(RibbonContentPanel.IsVisibleAutoChangedProperty, (object) value);
  }
}
