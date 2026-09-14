// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.LayoutHelpers
// Assembly: AcpWpfRibbon, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 45A745B5-88C3-40EE-B1E5-8DBA2EACD529
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfRibbon.dll

using System;
using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

#nullable disable
namespace DevComponents.WpfRibbon;

internal class LayoutHelpers
{
  public static Size AddHorizontal(Size size1, Size size2)
  {
    size1.Width += size2.Width;
    if (size2.Height > size1.Height)
      size1.Height = size2.Height;
    return size1;
  }

  public static Size AddVertical(Size size1, Size size2)
  {
    size1.Height += size2.Height;
    if (size2.Width > size1.Width)
      size1.Width = size2.Width;
    return size1;
  }

  public static bool IsUniform(Thickness borderThickness)
  {
    return borderThickness.Bottom == borderThickness.Top && borderThickness.Left == borderThickness.Right && borderThickness.Top == borderThickness.Left;
  }

  public static bool IsZero(double value) => Math.Abs(value) < 2.2204460492503131E-15;

  public static bool IsClose(double val1, double val2) => Math.Abs(val1 - val2) < 1.0;

  public static bool GreaterThan(double value1, double value2)
  {
    return value1 > value2 && !LayoutHelpers.IsClose(value1, value2);
  }

  public static bool IsZero(Size size)
  {
    return LayoutHelpers.IsZero(size.Width) && LayoutHelpers.IsZero(size.Height);
  }

  public static Rect DeflateRect(Rect r, Thickness thick)
  {
    return new Rect(r.Left + thick.Left, r.Top + thick.Top, Math.Max(0.0, r.Width - thick.Left - thick.Right), Math.Max(0.0, r.Height - thick.Top - thick.Bottom));
  }

  public static Size GetThicknessSize(Thickness t) => new Size(t.Left + t.Right, t.Top + t.Bottom);

  public static void CreateGeometry(
    StreamGeometryContext ctx,
    Rect rect,
    LayoutHelpers.RadiusDescription rd)
  {
    System.Windows.Point startPoint = new System.Windows.Point(rect.X, rect.Y + rd.TopLeft.Y);
    System.Windows.Point point1 = new System.Windows.Point(rect.X + rd.TopLeft.X, rect.Y);
    System.Windows.Point point2 = new System.Windows.Point(rect.Right - rd.TopRight.X, rect.Y);
    System.Windows.Point point3 = new System.Windows.Point(rect.Right, rect.Y + rd.TopRight.Y);
    System.Windows.Point point4 = new System.Windows.Point(rect.Right, rect.Bottom - rd.BottomRight.Y);
    System.Windows.Point point5 = new System.Windows.Point(rect.Right - rd.BottomRight.X, rect.Bottom);
    System.Windows.Point point6 = new System.Windows.Point(rd.BottomLeft.X, rect.Bottom);
    System.Windows.Point point7 = new System.Windows.Point(rect.X, rect.Bottom - rd.BottomLeft.Y);
    if (startPoint.Y > point6.Y)
    {
      startPoint.Y = rect.Y + rect.Height / 2.0;
      point7.Y = startPoint.Y;
    }
    if (point1.X > point2.X)
    {
      point1.X = rect.X + rect.Width / 2.0;
      point2.X = point1.X;
    }
    if (point3.Y > point4.Y)
    {
      point3.Y = rect.Y + rect.Height / 2.0;
      point4.Y = point3.Y;
    }
    if (point6.X > point5.X)
    {
      point6.X = rect.X + rect.Width / 2.0;
      point5.X = point6.X;
    }
    ctx.BeginFigure(startPoint, true, true);
    Size size = new Size(Math.Max(point1.X - rect.X, 0.0), Math.Max(0.0, startPoint.Y - rect.Y));
    if (!LayoutHelpers.IsZero(size))
      ctx.ArcTo(point1, size, 0.0, false, SweepDirection.Clockwise, true, false);
    ctx.LineTo(point2, true, false);
    size = new Size(Math.Max(0.0, rect.Right - point2.X), Math.Max(0.0, point3.Y - rect.Y));
    if (!LayoutHelpers.IsZero(size))
      ctx.ArcTo(point3, size, 0.0, false, SweepDirection.Clockwise, true, false);
    ctx.LineTo(point4, true, false);
    size = new Size(Math.Max(0.0, rect.Right - point5.X), Math.Max(0.0, rect.Bottom - point4.Y));
    if (!LayoutHelpers.IsZero(size))
      ctx.ArcTo(point5, size, 0.0, false, SweepDirection.Clockwise, true, false);
    ctx.LineTo(point6, true, false);
    size = new Size(Math.Max(0.0, point6.X - rect.X), Math.Max(0.0, rect.Bottom - point7.Y));
    if (LayoutHelpers.IsZero(size))
      return;
    ctx.ArcTo(point7, size, 0.0, false, SweepDirection.Clockwise, true, false);
  }

  public static bool IsThicknessValid(object value)
  {
    Thickness thickness = (Thickness) value;
    return thickness.Left >= 0.0 && thickness.Right >= 0.0 && thickness.Top >= 0.0 && thickness.Bottom >= 0.0 && !double.IsNaN(thickness.Left) && !double.IsNaN(thickness.Right) && !double.IsNaN(thickness.Top) && !double.IsNaN(thickness.Bottom) && !double.IsPositiveInfinity(thickness.Left) && !double.IsPositiveInfinity(thickness.Right) && !double.IsPositiveInfinity(thickness.Top) && !double.IsPositiveInfinity(thickness.Bottom) && !double.IsNegativeInfinity(thickness.Left) && !double.IsNegativeInfinity(thickness.Right) && !double.IsNegativeInfinity(thickness.Top) && !double.IsNegativeInfinity(thickness.Bottom);
  }

  public static bool IsEmpty(Thickness t)
  {
    return !LayoutHelpers.IsThicknessValid((object) t) || LayoutHelpers.IsZero(t.Bottom) && LayoutHelpers.IsZero(t.Left) && LayoutHelpers.IsZero(t.Right) && LayoutHelpers.IsZero(t.Top);
  }

  public static bool IsEmpty(CornerRadius rad)
  {
    return rad.BottomLeft == 0.0 && rad.BottomRight == 0.0 && rad.TopLeft == 0.0 && rad.TopRight == 0.0;
  }

  public static bool IsEmpty(Rect r)
  {
    return LayoutHelpers.IsZero(r.Width) && LayoutHelpers.IsZero(r.Height) || r.IsEmpty;
  }

  public static bool IsEmpty(Size s)
  {
    return LayoutHelpers.IsZero(s.Width) && LayoutHelpers.IsZero(s.Height) || s.IsEmpty;
  }

  public static bool IsEmpty(System.Windows.Point p)
  {
    return LayoutHelpers.IsZero(p.X) && LayoutHelpers.IsZero(p.Y);
  }

  public static System.Windows.Point GetResolution(Visual visual)
  {
    System.Windows.Point resolution = new System.Windows.Point(120.0, 120.0);
    PresentationSource presentationSource = PresentationSource.FromVisual(visual);
    if (presentationSource == null)
      return resolution;
    MatrixTransform matrixTransform = new MatrixTransform(presentationSource.CompositionTarget.TransformToDevice);
    System.Windows.Point point1 = matrixTransform.Transform(new System.Windows.Point(0.0, 0.0));
    System.Windows.Point point2 = new System.Windows.Point(96.0, 96.0);
    point2 = matrixTransform.Transform(point2);
    resolution.X = point2.X - point1.X;
    resolution.Y = point2.Y - point1.Y;
    return resolution;
  }

  public static FrameworkElement GetElementAt(FrameworkElement elem, System.Windows.Point screenLocation)
  {
    switch (elem)
    {
      case ItemsControl _:
        return LayoutHelpers.GetElementAt(elem as ItemsControl, screenLocation);
      case Panel _:
        return LayoutHelpers.GetElementAt(elem as Panel, screenLocation);
      default:
        return (FrameworkElement) null;
    }
  }

  public static FrameworkElement GetElementAt(ItemsControl ic, System.Windows.Point screenLocation)
  {
    foreach (object obj in (IEnumerable) ic.Items)
    {
      if (obj is FrameworkElement)
      {
        FrameworkElement ic1 = obj as FrameworkElement;
        System.Windows.Point point = ic1.PointFromScreen(screenLocation);
        if (new Rect(ic1.RenderSize).Contains(point))
        {
          switch (ic1)
          {
            case ButtonDropDown _:
              return ic1;
            case Panel _:
              FrameworkElement elementAt1 = LayoutHelpers.GetElementAt(ic1 as Panel, screenLocation);
              if (elementAt1 != null)
                return elementAt1;
              continue;
            case ItemsControl _:
              FrameworkElement elementAt2 = LayoutHelpers.GetElementAt(ic1 as ItemsControl, screenLocation);
              if (elementAt2 != null)
                return elementAt2;
              continue;
            default:
              return ic1;
          }
        }
      }
    }
    return (FrameworkElement) null;
  }

  public static FrameworkElement GetElementAt(Panel panel, System.Windows.Point screenLocation)
  {
    foreach (UIElement child in panel.Children)
    {
      System.Windows.Point point = child.PointFromScreen(screenLocation);
      if (new Rect(child.RenderSize).Contains(point))
      {
        switch (child)
        {
          case ButtonDropDown _:
            return child as FrameworkElement;
          case Panel _:
            FrameworkElement elementAt1 = LayoutHelpers.GetElementAt(child as Panel, screenLocation);
            if (elementAt1 != null)
              return elementAt1;
            continue;
          case ItemsControl _:
            FrameworkElement elementAt2 = LayoutHelpers.GetElementAt(child as ItemsControl, screenLocation);
            if (elementAt2 != null)
              return elementAt2;
            continue;
          default:
            return child as FrameworkElement;
        }
      }
    }
    return (FrameworkElement) null;
  }

  public struct RadiusDescription
  {
    public System.Windows.Point TopLeft;
    public System.Windows.Point TopRight;
    public System.Windows.Point BottomLeft;
    public System.Windows.Point BottomRight;

    public RadiusDescription(CornerRadius rad, Thickness border, bool isOutterBorder)
    {
      double num1 = border.Left * 0.5;
      double num2 = border.Right * 0.5;
      double num3 = border.Top * 0.5;
      double num4 = border.Bottom * 0.5;
      this.TopLeft = new System.Windows.Point(0.0, 0.0);
      this.TopRight = new System.Windows.Point(0.0, 0.0);
      this.BottomLeft = new System.Windows.Point(0.0, 0.0);
      this.BottomRight = new System.Windows.Point(0.0, 0.0);
      if (isOutterBorder)
      {
        if (!LayoutHelpers.IsZero(rad.TopLeft))
          this.TopLeft = new System.Windows.Point(rad.TopLeft + num3, rad.TopLeft + num1);
        if (!LayoutHelpers.IsZero(rad.TopRight))
          this.TopRight = new System.Windows.Point(rad.TopRight + num3, rad.TopRight + num2);
        if (!LayoutHelpers.IsZero(rad.BottomLeft))
          this.BottomLeft = new System.Windows.Point(rad.BottomLeft + num4, rad.BottomLeft + num1);
        if (LayoutHelpers.IsZero(rad.BottomRight))
          return;
        this.BottomRight = new System.Windows.Point(rad.BottomRight + num4, rad.BottomRight + num2);
      }
      else
      {
        this.TopLeft = new System.Windows.Point(Math.Max(0.0, rad.TopLeft - num3), Math.Max(0.0, rad.TopLeft - num1));
        this.TopRight = new System.Windows.Point(Math.Max(0.0, rad.TopRight - num3), Math.Max(0.0, rad.TopRight - num2));
        this.BottomLeft = new System.Windows.Point(Math.Max(0.0, rad.BottomLeft - num4), Math.Max(0.0, rad.BottomLeft - num1));
        this.BottomRight = new System.Windows.Point(Math.Max(0.0, rad.BottomRight - num4), Math.Max(0.0, rad.BottomRight - num2));
      }
    }
  }
}
