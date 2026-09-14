// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfDock.LayoutHelpers
// Assembly: AcpWpfDock, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 89CC52D3-0487-4106-AFAE-BE4A13C8A50E
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfDock.dll

using System;
using System.Windows;
using System.Windows.Media;

#nullable disable
namespace DevComponents.WpfDock;

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

  public static CornerRadius DeflateCornerRadius(CornerRadius cr, double d)
  {
    CornerRadius cornerRadius = new CornerRadius(0.0);
    if (cr.BottomLeft > 0.0)
      cornerRadius.BottomLeft = Math.Max(0.0, cr.BottomLeft - d);
    if (cr.BottomRight > 0.0)
      cornerRadius.BottomRight = Math.Max(0.0, cr.BottomRight - d);
    if (cr.TopLeft > 0.0)
      cornerRadius.TopLeft = Math.Max(0.0, cr.TopLeft - d);
    if (cr.TopRight > 0.0)
      cornerRadius.TopRight = Math.Max(0.0, cr.TopRight - d);
    return cornerRadius;
  }

  public static void CreateGeometry(
    StreamGeometryContext ctx,
    Rect rect,
    LayoutHelpers.RadiusDescription rd)
  {
    Point startPoint = new Point(rect.X, rect.Y + rd.TopLeft.Y);
    Point point1 = new Point(rect.X + rd.TopLeft.X, rect.Y);
    Point point2 = new Point(rect.Right - rd.TopRight.X, rect.Y);
    Point point3 = new Point(rect.Right, rect.Y + rd.TopRight.Y);
    Point point4 = new Point(rect.Right, rect.Bottom - rd.BottomRight.Y);
    Point point5 = new Point(rect.Right - rd.BottomRight.X, rect.Bottom);
    Point point6 = new Point(rd.BottomLeft.X, rect.Bottom);
    Point point7 = new Point(rect.X, rect.Bottom - rd.BottomLeft.Y);
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

  public static bool IsEmpty(Rect r)
  {
    return LayoutHelpers.IsZero(r.Width) && LayoutHelpers.IsZero(r.Height) || r.IsEmpty;
  }

  public static bool IsEmpty(Size s)
  {
    return LayoutHelpers.IsZero(s.Width) && LayoutHelpers.IsZero(s.Height) || s.IsEmpty;
  }

  public static bool IsEmpty(Point p) => LayoutHelpers.IsZero(p.X) && LayoutHelpers.IsZero(p.Y);

  public static Point GetResolution(Visual visual)
  {
    Point resolution = new Point(120.0, 120.0);
    PresentationSource presentationSource = PresentationSource.FromVisual(visual);
    if (presentationSource == null)
      return resolution;
    MatrixTransform matrixTransform = new MatrixTransform(presentationSource.CompositionTarget.TransformToDevice);
    Point point1 = matrixTransform.Transform(new Point(0.0, 0.0));
    Point point2 = new Point(96.0, 96.0);
    point2 = matrixTransform.Transform(point2);
    resolution.X = point2.X - point1.X;
    resolution.Y = point2.Y - point1.Y;
    return resolution;
  }

  public static Rect GetBounds(UIElement elem, UIElement referenceParent)
  {
    Point screen = elem.PointToScreen(new Point(0.0, 0.0));
    Point location = referenceParent.PointFromScreen(screen);
    Size renderSize = elem.RenderSize;
    double width = Math.Ceiling(renderSize.Width);
    renderSize = elem.RenderSize;
    double height = Math.Ceiling(renderSize.Height);
    Size size = new Size(width, height);
    return new Rect(location, size);
  }

  internal static void NormalizeMeasureBounds(ref Size arrangeBounds)
  {
    if (double.IsPositiveInfinity(arrangeBounds.Width))
      arrangeBounds.Width = 0.0;
    if (!double.IsPositiveInfinity(arrangeBounds.Height))
      return;
    arrangeBounds.Height = 0.0;
  }

  public static bool IsMouseWithin(UIElement el)
  {
    bool flag = false;
    Point mousePosition = LayoutHelpers.GetMousePosition((Visual) el);
    if (VisualTreeHelper.HitTest((Visual) el, mousePosition) != null)
      flag = true;
    return flag;
  }

  private static Point GetMousePosition(Visual relativeTo)
  {
    WinApi.Win32Point pt = new WinApi.Win32Point();
    WinApi.GetCursorPos(ref pt);
    return relativeTo.PointFromScreen(new Point((double) pt.X, (double) pt.Y));
  }

  public struct RadiusDescription
  {
    public Point TopLeft;
    public Point TopRight;
    public Point BottomLeft;
    public Point BottomRight;

    public RadiusDescription(CornerRadius rad, Thickness border, bool isOutterBorder)
    {
      double num1 = border.Left * 0.5;
      double num2 = border.Right * 0.5;
      double num3 = border.Top * 0.5;
      double num4 = border.Bottom * 0.5;
      this.TopLeft = new Point(0.0, 0.0);
      this.TopRight = new Point(0.0, 0.0);
      this.BottomLeft = new Point(0.0, 0.0);
      this.BottomRight = new Point(0.0, 0.0);
      if (isOutterBorder)
      {
        if (!LayoutHelpers.IsZero(rad.TopLeft))
          this.TopLeft = new Point(rad.TopLeft + num3, rad.TopLeft + num1);
        if (!LayoutHelpers.IsZero(rad.TopRight))
          this.TopRight = new Point(rad.TopRight + num3, rad.TopRight + num2);
        if (!LayoutHelpers.IsZero(rad.BottomLeft))
          this.BottomLeft = new Point(rad.BottomLeft + num4, rad.BottomLeft + num1);
        if (LayoutHelpers.IsZero(rad.BottomRight))
          return;
        this.BottomRight = new Point(rad.BottomRight + num4, rad.BottomRight + num2);
      }
      else
      {
        this.TopLeft = new Point(Math.Max(0.0, rad.TopLeft - num3), Math.Max(0.0, rad.TopLeft - num1));
        this.TopRight = new Point(Math.Max(0.0, rad.TopRight - num3), Math.Max(0.0, rad.TopRight - num2));
        this.BottomLeft = new Point(Math.Max(0.0, rad.BottomLeft - num4), Math.Max(0.0, rad.BottomLeft - num1));
        this.BottomRight = new Point(Math.Max(0.0, rad.BottomRight - num4), Math.Max(0.0, rad.BottomRight - num2));
      }
    }
  }
}
