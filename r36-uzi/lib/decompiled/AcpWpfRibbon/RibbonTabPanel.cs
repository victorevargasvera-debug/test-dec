// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.RibbonTabPanel
// Assembly: AcpWpfRibbon, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 45A745B5-88C3-40EE-B1E5-8DBA2EACD529
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfRibbon.dll

using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

#nullable disable
namespace DevComponents.WpfRibbon;

[DesignTimeVisible(false)]
public class RibbonTabPanel : Panel
{
  public static readonly DependencyProperty PanelAlignmentProperty;
  internal static readonly RoutedEvent TabsScrolledEvent = EventManager.RegisterRoutedEvent("TabsScrolled", RoutingStrategy.Bubble, typeof (RoutedEventHandler), typeof (RibbonTabPanel));
  private int m_TabsCount;
  private double m_TabsSize;
  private RepeatButton m_ScrollLeft;
  private RepeatButton m_ScrollRight;
  private double m_AvailableWidth;
  private int m_HorizontalOffset;
  private bool m_RaiseTabsScrolledEvent;

  static RibbonTabPanel()
  {
    RibbonTabPanel.PanelAlignmentProperty = DependencyProperty.RegisterAttached("PanelAlignment", typeof (eTabElementAlignment), typeof (RibbonTabPanel), (PropertyMetadata) new FrameworkPropertyMetadata((object) eTabElementAlignment.Left, new PropertyChangedCallback(RibbonTabPanel.OnPanelAlignmentChanged)), new ValidateValueCallback(RibbonTabPanel.IsPanelAlignmentValid));
    KeyboardNavigation.DirectionalNavigationProperty.OverrideMetadata(typeof (RibbonTabPanel), (PropertyMetadata) new FrameworkPropertyMetadata((object) KeyboardNavigationMode.Cycle));
  }

  protected override Size MeasureOverride(Size availableSize)
  {
    Size size = this.MeasureInternal(availableSize, 0.0);
    if (size.Width > availableSize.Width && this.m_TabsSize > 0.0)
    {
      double reduction = (this.m_TabsSize - (size.Width - availableSize.Width)) / this.m_TabsSize;
      size = this.MeasureInternal(availableSize, reduction);
    }
    if (size.Width - 1.0 > availableSize.Width)
      this.CreateScrollButtons();
    else
      this.DestroyScrollButtons();
    this.MeasureScrollButtons(availableSize);
    this.m_AvailableWidth = availableSize.Width;
    return size;
  }

  private Size MeasureInternal(Size availableSize, double reduction)
  {
    this.m_TabsCount = 0;
    this.m_TabsSize = 0.0;
    Size size = new Size();
    UIElementCollection internalChildren = this.InternalChildren;
    bool flag1 = !LayoutHelpers.IsZero(reduction);
    foreach (UIElement uiElement in internalChildren)
    {
      if (uiElement.Visibility != Visibility.Collapsed && uiElement != this.m_ScrollLeft && uiElement != this.m_ScrollRight)
      {
        Size availableSize1 = availableSize;
        bool flag2 = uiElement is RibbonTab;
        if (flag1 & flag2)
        {
          availableSize1 = uiElement.DesiredSize;
          availableSize1.Width = Math.Round(availableSize1.Width);
          availableSize1.Height = Math.Round(availableSize1.Height);
          availableSize1.Width = Math.Max((double) RibbonTab.MinimumTabWidth, availableSize1.Width * reduction);
        }
        uiElement.Measure(availableSize1);
        Size desiredSize = uiElement.DesiredSize;
        desiredSize.Width = Math.Round(desiredSize.Width);
        desiredSize.Height = Math.Round(desiredSize.Height);
        if (size.Height < desiredSize.Height)
          size.Height = desiredSize.Height;
        size.Width += desiredSize.Width;
        if (flag2)
        {
          ++this.m_TabsCount;
          this.m_TabsSize += desiredSize.Width;
        }
      }
    }
    return size;
  }

  protected override Size ArrangeOverride(Size finalSize)
  {
    double horizontalOffset = (double) this.m_HorizontalOffset;
    double width = finalSize.Width;
    foreach (UIElement internalChild in this.InternalChildren)
    {
      if (internalChild.Visibility != Visibility.Collapsed && internalChild != this.m_ScrollLeft && internalChild != this.m_ScrollRight)
      {
        int panelAlignment = (int) RibbonTabPanel.GetPanelAlignment(internalChild);
        Size desiredSize = internalChild.DesiredSize;
        if (panelAlignment == 0)
        {
          internalChild.Arrange(new Rect(horizontalOffset, 0.0, desiredSize.Width, finalSize.Height));
          horizontalOffset += desiredSize.Width;
        }
        else
        {
          width -= desiredSize.Width;
          internalChild.Arrange(new Rect(width + (double) this.m_HorizontalOffset, 0.0, desiredSize.Width, finalSize.Height));
        }
      }
    }
    if (this.m_ScrollLeft != null)
      this.m_ScrollLeft.Arrange(new Rect(0.0, 0.0, this.m_ScrollLeft.DesiredSize.Width, finalSize.Height));
    if (this.m_ScrollRight != null)
      this.m_ScrollRight.Arrange(new Rect(this.m_AvailableWidth - this.m_ScrollRight.DesiredSize.Width, 0.0, this.m_ScrollRight.DesiredSize.Width, finalSize.Height));
    if (this.m_RaiseTabsScrolledEvent)
    {
      this.m_RaiseTabsScrolledEvent = false;
      this.RaiseEvent(new RoutedEventArgs(RibbonTabPanel.TabsScrolledEvent, (object) this));
    }
    this.InvalidateContextGroupParent();
    return finalSize;
  }

  protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
  {
    base.OnRenderSizeChanged(sizeInfo);
    if (this.IsScrollUsed)
      this.UpdateScrollButtonVisibility();
    this.InvalidateContextGroupParent();
  }

  private void InvalidateContextGroupParent()
  {
    foreach (UIElement internalChild in this.InternalChildren)
    {
      if (internalChild is RibbonTab ribbonTab && ribbonTab.ContextGroup != null)
      {
        if (!(VisualTreeHelper.GetParent((DependencyObject) ribbonTab.ContextGroup) is UIElement parent))
          break;
        parent.InvalidateMeasure();
        break;
      }
    }
  }

  private void MeasureScrollButtons(Size availableSize)
  {
    if (this.m_ScrollLeft != null)
      this.m_ScrollLeft.Measure(availableSize);
    if (this.m_ScrollRight == null)
      return;
    this.m_ScrollRight.Measure(availableSize);
  }

  private void CreateScrollButtons()
  {
    if (this.m_ScrollLeft != null)
      return;
    this.m_ScrollLeft = new RepeatButton();
    this.m_ScrollLeft.Style = this.TryFindResource((object) new ComponentResourceKey(typeof (Ribbon), (object) "RibbonScrollButton")) as Style;
    this.m_ScrollLeft.Tag = (object) "LeftScroll";
    this.m_ScrollLeft.Click += new RoutedEventHandler(this.ScrollLeft_Click);
    this.m_ScrollLeft.Visibility = Visibility.Collapsed;
    this.AddLogicalChild((object) this.m_ScrollLeft);
    this.AddVisualChild((Visual) this.m_ScrollLeft);
    this.m_ScrollRight = new RepeatButton();
    this.m_ScrollRight.Style = this.TryFindResource((object) new ComponentResourceKey(typeof (Ribbon), (object) "RibbonScrollButton")) as Style;
    this.m_ScrollRight.Click += new RoutedEventHandler(this.ScrollRight_Click);
    this.AddLogicalChild((object) this.m_ScrollRight);
    this.AddVisualChild((Visual) this.m_ScrollRight);
  }

  private void ScrollRight_Click(object sender, RoutedEventArgs e)
  {
    Size size = this.DesiredSize;
    double width1 = size.Width;
    size = this.RenderSize;
    double width2 = size.Width;
    size = this.DesiredSize;
    double num = size.Width + (double) this.m_HorizontalOffset;
    double val2 = width2 - num;
    this.SetScrollOffset(-(int) Math.Ceiling(Math.Min(width1, val2)));
  }

  private void ScrollLeft_Click(object sender, RoutedEventArgs e)
  {
    this.SetScrollOffset((int) Math.Min((double) Math.Abs(this.m_HorizontalOffset), this.RenderSize.Width));
  }

  private void SetScrollOffset(int offset)
  {
    this.m_HorizontalOffset += offset;
    this.InvalidateArrange();
    this.UpdateScrollButtonVisibility();
    this.m_RaiseTabsScrolledEvent = true;
  }

  private void UpdateScrollButtonVisibility()
  {
    if (this.m_ScrollLeft != null && this.m_HorizontalOffset != 0)
      this.m_ScrollLeft.Visibility = Visibility.Visible;
    else
      this.m_ScrollLeft.Visibility = Visibility.Collapsed;
    if (this.RenderSize.Width + (double) this.m_HorizontalOffset <= this.DesiredSize.Width)
      this.m_ScrollRight.Visibility = Visibility.Collapsed;
    else
      this.m_ScrollRight.Visibility = Visibility.Visible;
  }

  private bool IsScrollUsed => this.m_ScrollLeft != null;

  protected override int VisualChildrenCount
  {
    get
    {
      int visualChildrenCount = base.VisualChildrenCount;
      if (this.IsScrollUsed)
        visualChildrenCount += 2;
      return visualChildrenCount;
    }
  }

  protected override Visual GetVisualChild(int index)
  {
    if (!this.IsScrollUsed || index < this.VisualChildrenCount - 2)
      return base.GetVisualChild(index);
    return index == this.VisualChildrenCount - 1 ? (Visual) this.m_ScrollRight : (Visual) this.m_ScrollLeft;
  }

  private void DestroyScrollButtons()
  {
    this.m_HorizontalOffset = 0;
    this.RemoveButton(this.m_ScrollLeft);
    this.RemoveButton(this.m_ScrollRight);
    this.m_ScrollRight = (RepeatButton) null;
    this.m_ScrollLeft = (RepeatButton) null;
  }

  private void RemoveButton(RepeatButton b)
  {
    if (b == null)
      return;
    this.RemoveLogicalChild((object) b);
    this.RemoveVisualChild((Visual) b);
  }

  [AttachedPropertyBrowsableForChildren]
  public static eTabElementAlignment GetPanelAlignment(UIElement element)
  {
    return element != null ? (eTabElementAlignment) element.GetValue(RibbonTabPanel.PanelAlignmentProperty) : throw new ArgumentNullException("elem");
  }

  public static void SetPanelAlignment(UIElement element, eTabElementAlignment part)
  {
    if (element == null)
      throw new ArgumentNullException("elem");
    element.SetValue(RibbonTabPanel.PanelAlignmentProperty, (object) part);
  }

  private static void OnPanelAlignmentChanged(
    DependencyObject d,
    DependencyPropertyChangedEventArgs e)
  {
    if (!(d is UIElement reference) || !(VisualTreeHelper.GetParent((DependencyObject) reference) is RibbonTabPanel parent))
      return;
    parent.InvalidateArrange();
  }

  private static bool IsPanelAlignmentValid(object o)
  {
    switch ((eTabElementAlignment) o)
    {
      case eTabElementAlignment.Left:
      case eTabElementAlignment.Right:
        return true;
      default:
        return false;
    }
  }

  protected override void OnRender(DrawingContext dc)
  {
    base.OnRender(dc);
    if (WinApi.KeyValidated)
      return;
    FormattedText formattedText1 = new FormattedText("License not found. See registration message for activation details.", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("Arial"), 9.0, (Brush) Brushes.Maroon);
    DrawingContext drawingContext = dc;
    FormattedText formattedText2 = formattedText1;
    Size renderSize = this.RenderSize;
    double x = (renderSize.Width - formattedText1.Width) / 2.0;
    renderSize = this.RenderSize;
    double y = (renderSize.Height - formattedText1.Height) / 2.0;
    System.Windows.Point origin = new System.Windows.Point(x, y);
    drawingContext.DrawText(formattedText2, origin);
  }
}
