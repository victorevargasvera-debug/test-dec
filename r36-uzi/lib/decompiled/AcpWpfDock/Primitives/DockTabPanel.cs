// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfDock.Primitives.DockTabPanel
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

#nullable disable
namespace DevComponents.WpfDock.Primitives;

[DesignTimeVisible(false)]
public class DockTabPanel : Panel
{
  public static readonly DependencyProperty PanelAlignmentProperty = DependencyProperty.RegisterAttached("PanelAlignment", typeof (eDockTabElementAlignment), typeof (DockTabPanel), (PropertyMetadata) new FrameworkPropertyMetadata((object) eDockTabElementAlignment.Left, new PropertyChangedCallback(DockTabPanel.OnPanelAlignmentChanged)), new ValidateValueCallback(DockTabPanel.IsPanelAlignmentValid));
  public static readonly DependencyProperty BorderInnerBrushProperty = DependencyProperty.Register(nameof (BorderInnerBrush), typeof (Brush), typeof (DockTabPanel), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.SubPropertiesDoNotAffectRender, new PropertyChangedCallback(DockTabPanel.OnBorderInnerBrushChanged)));
  public static readonly DependencyProperty BackgroundInnerProperty;
  public static readonly DependencyProperty BorderBrushProperty = DependencyProperty.Register(nameof (BorderBrush), typeof (Brush), typeof (DockTabPanel), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.SubPropertiesDoNotAffectRender, new PropertyChangedCallback(DockTabPanel.OnBorderBrushChanged)));
  private double m_TabsSize;
  private double m_AvailableWidth;
  private Thickness m_Padding = new Thickness(3.0, 4.0, 3.0, 0.0);
  private Pen m_BorderPen;
  private Pen m_BorderInnerPen;

  static DockTabPanel()
  {
    DockTabPanel.BackgroundInnerProperty = DependencyProperty.Register(nameof (BackgroundInner), typeof (Brush), typeof (DockTabPanel), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.SubPropertiesDoNotAffectRender));
    KeyboardNavigation.DirectionalNavigationProperty.OverrideMetadata(typeof (DockTabPanel), (PropertyMetadata) new FrameworkPropertyMetadata((object) KeyboardNavigationMode.Cycle));
    EventManager.RegisterClassHandler(typeof (DockTabPanel), Selector.SelectedEvent, (Delegate) new RoutedEventHandler(DockTabPanel.OnTabSelected));
  }

  protected override Size MeasureOverride(Size availableSize)
  {
    Size arrangeBounds = this.MeasureInternal(availableSize, 0.0);
    if (arrangeBounds.Width > availableSize.Width && this.m_TabsSize > 0.0)
    {
      double reduction = (this.m_TabsSize - (arrangeBounds.Width - availableSize.Width)) / this.m_TabsSize;
      arrangeBounds = this.MeasureInternal(availableSize, reduction);
    }
    this.m_AvailableWidth = availableSize.Width;
    LayoutHelpers.NormalizeMeasureBounds(ref arrangeBounds);
    return arrangeBounds;
  }

  private Size MeasureInternal(Size availableSize, double reduction)
  {
    this.m_TabsSize = 0.0;
    Size size = new Size();
    UIElementCollection internalChildren = this.InternalChildren;
    bool flag = !LayoutHelpers.IsZero(reduction);
    foreach (UIElement uiElement in internalChildren)
    {
      if (uiElement.Visibility != Visibility.Collapsed)
      {
        Size availableSize1 = availableSize;
        if (flag)
        {
          availableSize1 = uiElement.DesiredSize;
          availableSize1.Width = Math.Round(availableSize1.Width);
          availableSize1.Height = Math.Round(availableSize1.Height);
          availableSize1.Width = Math.Max(22.0, Math.Floor(availableSize1.Width * reduction));
        }
        uiElement.Measure(availableSize1);
        Size desiredSize = uiElement.DesiredSize;
        desiredSize.Width = Math.Round(desiredSize.Width);
        desiredSize.Height = Math.Round(desiredSize.Height);
        if (size.Height < desiredSize.Height)
          size.Height = desiredSize.Height;
        size.Width += desiredSize.Width;
        this.m_TabsSize += desiredSize.Width;
      }
    }
    size.Width += this.m_Padding.Left + this.m_Padding.Right;
    size.Height += this.m_Padding.Top + this.m_Padding.Bottom;
    return size;
  }

  protected override Size ArrangeOverride(Size finalSize)
  {
    double left = this.m_Padding.Left;
    double x = finalSize.Width - (this.m_Padding.Left + this.m_Padding.Right);
    double top = this.m_Padding.Top;
    double height = finalSize.Height - (this.m_Padding.Top + this.m_Padding.Bottom);
    foreach (UIElement internalChild in this.InternalChildren)
    {
      if (internalChild.Visibility != Visibility.Collapsed)
      {
        eDockTabElementAlignment panelAlignment = DockTabPanel.GetPanelAlignment(internalChild);
        Size desiredSize = internalChild.DesiredSize;
        if (panelAlignment == eDockTabElementAlignment.Left)
        {
          internalChild.Arrange(new Rect(left, top, desiredSize.Width, height));
          left += desiredSize.Width;
        }
        else
        {
          x -= desiredSize.Width;
          internalChild.Arrange(new Rect(x, top, desiredSize.Width, height));
        }
      }
    }
    return finalSize;
  }

  protected override void OnRender(DrawingContext dc)
  {
    base.OnRender(dc);
    Rect rect = new Rect(this.RenderSize);
    Thickness padding = this.m_Padding;
    if (this.BackgroundInner != null)
    {
      Rect rectangle = new Rect(rect.X, rect.Y, rect.Width, padding.Top);
      dc.DrawRectangle(this.BackgroundInner, (Pen) null, rectangle);
    }
    if (this.m_BorderPen != null)
    {
      Pen borderPen = this.m_BorderPen;
      rect.Offset(0.5, 0.5);
      --rect.Width;
      dc.DrawLine(borderPen, new System.Windows.Point(rect.X, rect.Y), new System.Windows.Point(rect.Right, rect.Y));
      dc.DrawLine(borderPen, new System.Windows.Point(rect.X, rect.Y + padding.Top), new System.Windows.Point(rect.Right, rect.Y + padding.Top));
    }
    if (this.m_BorderInnerPen == null)
      return;
    Pen borderInnerPen = this.m_BorderInnerPen;
    Rect selectedItemBounds = this.GetSelectedItemBounds();
    --rect.Y;
    dc.DrawLine(borderInnerPen, new System.Windows.Point(rect.X, rect.Y + padding.Top), new System.Windows.Point(selectedItemBounds.X + 1.0, rect.Y + padding.Top));
    dc.DrawLine(borderInnerPen, new System.Windows.Point(selectedItemBounds.Right - 1.0, rect.Y + padding.Top), new System.Windows.Point(rect.Right, rect.Y + padding.Top));
  }

  private Rect GetSelectedItemBounds()
  {
    Rect selectedItemBounds = new Rect();
    foreach (UIElement child in this.Children)
    {
      if (child is DockWindow dockWindow && dockWindow.IsSelected)
      {
        selectedItemBounds = LayoutInformation.GetLayoutSlot(child as FrameworkElement);
        break;
      }
    }
    return selectedItemBounds;
  }

  [AttachedPropertyBrowsableForChildren]
  public static eDockTabElementAlignment GetPanelAlignment(UIElement element)
  {
    return element != null ? (eDockTabElementAlignment) element.GetValue(DockTabPanel.PanelAlignmentProperty) : throw new ArgumentNullException("elem");
  }

  public static void SetPanelAlignment(UIElement element, eDockTabElementAlignment part)
  {
    if (element == null)
      throw new ArgumentNullException("elem");
    element.SetValue(DockTabPanel.PanelAlignmentProperty, (object) part);
  }

  private static void OnPanelAlignmentChanged(
    DependencyObject d,
    DependencyPropertyChangedEventArgs e)
  {
    if (!(d is UIElement reference) || !(VisualTreeHelper.GetParent((DependencyObject) reference) is DockTabPanel parent))
      return;
    parent.InvalidateArrange();
  }

  private static bool IsPanelAlignmentValid(object o)
  {
    switch ((eDockTabElementAlignment) o)
    {
      case eDockTabElementAlignment.Left:
      case eDockTabElementAlignment.Right:
        return true;
      default:
        return false;
    }
  }

  [DefaultValue(null)]
  public Brush BorderInnerBrush
  {
    get => (Brush) this.GetValue(DockTabPanel.BorderInnerBrushProperty);
    set => this.SetValue(DockTabPanel.BorderInnerBrushProperty, (object) value);
  }

  [DefaultValue(null)]
  public Brush BorderBrush
  {
    get => (Brush) this.GetValue(DockTabPanel.BorderBrushProperty);
    set => this.SetValue(DockTabPanel.BorderBrushProperty, (object) value);
  }

  [DefaultValue(null)]
  public Brush BackgroundInner
  {
    get => (Brush) this.GetValue(DockTabPanel.BackgroundInnerProperty);
    set => this.SetValue(DockTabPanel.BackgroundInnerProperty, (object) value);
  }

  private static void OnBorderBrushChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
  {
    ((DockTabPanel) d).OnBorderBrushChanged();
  }

  private void OnBorderBrushChanged()
  {
    this.m_BorderPen = (Pen) null;
    if (this.BorderBrush == null)
      return;
    this.m_BorderPen = new Pen(this.BorderBrush, 1.0);
  }

  private static void OnBorderInnerBrushChanged(
    DependencyObject d,
    DependencyPropertyChangedEventArgs e)
  {
    ((DockTabPanel) d).OnBorderInnerBrushChanged();
  }

  private void OnBorderInnerBrushChanged()
  {
    this.m_BorderInnerPen = (Pen) null;
    if (this.BorderInnerBrush == null)
      return;
    this.m_BorderInnerPen = new Pen(this.BorderInnerBrush, 1.0);
  }

  private static void OnTabSelected(object sender, RoutedEventArgs e)
  {
    if (!(sender is DockTabPanel))
      return;
    ((DockTabPanel) sender).OnTabSelected(e.OriginalSource as DockWindow);
  }

  private void OnTabSelected(DockWindow dockWindow)
  {
    if (this.BackgroundInner == null)
      return;
    this.InvalidateVisual();
  }
}
