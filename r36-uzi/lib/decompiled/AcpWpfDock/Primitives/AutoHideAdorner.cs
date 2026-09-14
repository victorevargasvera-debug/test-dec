// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfDock.Primitives.AutoHideAdorner
// Assembly: AcpWpfDock, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 89CC52D3-0487-4106-AFAE-BE4A13C8A50E
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfDock.dll

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

#nullable disable
namespace DevComponents.WpfDock.Primitives;

internal class AutoHideAdorner(DockSite adornedElement) : Adorner((UIElement) adornedElement)
{
  public static readonly DependencyProperty LeftProperty = DependencyProperty.RegisterAttached("Left", typeof (double), typeof (DockSiteAdorner), (PropertyMetadata) new FrameworkPropertyMetadata((object) double.PositiveInfinity, new PropertyChangedCallback(AutoHideAdorner.PositionChanged)));
  public static readonly DependencyProperty TopProperty = DependencyProperty.RegisterAttached("Top", typeof (double), typeof (DockSiteAdorner), (PropertyMetadata) new FrameworkPropertyMetadata((object) double.PositiveInfinity, new PropertyChangedCallback(AutoHideAdorner.PositionChanged)));
  public static readonly DependencyProperty RightProperty;
  public static readonly DependencyProperty BottomProperty = DependencyProperty.RegisterAttached("Bottom", typeof (double), typeof (DockSiteAdorner), (PropertyMetadata) new FrameworkPropertyMetadata((object) double.PositiveInfinity, new PropertyChangedCallback(AutoHideAdorner.PositionChanged)));
  private UIElementCollection m_Children;

  static AutoHideAdorner()
  {
    AutoHideAdorner.RightProperty = DependencyProperty.RegisterAttached("Right", typeof (double), typeof (DockSiteAdorner), (PropertyMetadata) new FrameworkPropertyMetadata((object) double.PositiveInfinity, new PropertyChangedCallback(AutoHideAdorner.PositionChanged)));
  }

  protected override Size MeasureOverride(Size constraint)
  {
    Size availableSize = new Size(double.PositiveInfinity, double.PositiveInfinity);
    foreach (UIElement child in this.Children)
      child.Measure(availableSize);
    LayoutHelpers.NormalizeMeasureBounds(ref constraint);
    return constraint;
  }

  protected override Size ArrangeOverride(Size finalSize)
  {
    Rect empty = Rect.Empty;
    foreach (UIElement child in this.Children)
    {
      Rect finalRect = new Rect(child.DesiredSize);
      double left = AutoHideAdorner.GetLeft(child);
      if (AutoHideAdorner.IsDoubleFiniteOrNaN(left))
        finalRect.X = left;
      double top = AutoHideAdorner.GetTop(child);
      if (AutoHideAdorner.IsDoubleFiniteOrNaN(top))
        finalRect.Y = top;
      double right = AutoHideAdorner.GetRight(child);
      if (AutoHideAdorner.IsDoubleFiniteOrNaN(right))
        finalRect.Width = Math.Max(0.0, right - finalRect.X);
      double bottom = AutoHideAdorner.GetBottom(child);
      if (AutoHideAdorner.IsDoubleFiniteOrNaN(bottom))
        finalRect.Height = Math.Max(0.0, bottom - finalRect.Y);
      child.Arrange(finalRect);
    }
    return finalSize;
  }

  public UIElementCollection Children
  {
    get
    {
      if (this.m_Children == null)
        this.m_Children = new UIElementCollection((UIElement) this, (FrameworkElement) this);
      return this.m_Children;
    }
  }

  protected override Visual GetVisualChild(int index) => (Visual) this.Children[index];

  protected override int VisualChildrenCount => this.Children.Count;

  internal static bool IsDoubleFiniteOrNaN(object o) => !double.IsInfinity((double) o);

  internal static bool IsDoubleFiniteOrNaN(double d) => !double.IsInfinity(d);

  private static void PositionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
  {
    if (!(d is UIElement reference) || !(VisualTreeHelper.GetParent((DependencyObject) reference) is AutoHideAdorner parent))
      return;
    parent.InvalidateArrange();
  }

  [AttachedPropertyBrowsableForChildren]
  public static double GetTop(UIElement element)
  {
    return element != null ? (double) element.GetValue(AutoHideAdorner.TopProperty) : throw new ArgumentNullException(nameof (element));
  }

  public static void SetTop(UIElement element, double length)
  {
    if (element == null)
      throw new ArgumentNullException(nameof (element));
    element.SetValue(AutoHideAdorner.TopProperty, (object) length);
  }

  [AttachedPropertyBrowsableForChildren]
  public static double GetLeft(UIElement element)
  {
    return element != null ? (double) element.GetValue(AutoHideAdorner.LeftProperty) : throw new ArgumentNullException(nameof (element));
  }

  public static void SetLeft(UIElement element, double length)
  {
    if (element == null)
      throw new ArgumentNullException(nameof (element));
    element.SetValue(AutoHideAdorner.LeftProperty, (object) length);
  }

  [AttachedPropertyBrowsableForChildren]
  public static double GetRight(UIElement element)
  {
    return element != null ? (double) element.GetValue(AutoHideAdorner.RightProperty) : throw new ArgumentNullException(nameof (element));
  }

  public static void SetRight(UIElement element, double length)
  {
    if (element == null)
      throw new ArgumentNullException(nameof (element));
    element.SetValue(AutoHideAdorner.RightProperty, (object) length);
  }

  [AttachedPropertyBrowsableForChildren]
  public static double GetBottom(UIElement element)
  {
    return element != null ? (double) element.GetValue(AutoHideAdorner.BottomProperty) : throw new ArgumentNullException(nameof (element));
  }

  public static void SetBottom(UIElement element, double length)
  {
    if (element == null)
      throw new ArgumentNullException(nameof (element));
    element.SetValue(AutoHideAdorner.BottomProperty, (object) length);
  }
}
