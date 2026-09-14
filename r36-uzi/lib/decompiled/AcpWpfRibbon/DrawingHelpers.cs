// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.DrawingHelpers
// Assembly: AcpWpfRibbon, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 45A745B5-88C3-40EE-B1E5-8DBA2EACD529
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfRibbon.dll

using System.Windows;
using System.Windows.Media;

#nullable disable
namespace DevComponents.WpfRibbon;

internal class DrawingHelpers
{
  public static void DrawBorder(
    DrawingContext dc,
    Thickness borderThickness,
    Brush borderBrush,
    Rect borderBounds)
  {
    if (borderBrush == null || LayoutHelpers.IsEmpty(borderThickness))
      return;
    if (LayoutHelpers.IsUniform(borderThickness))
    {
      Pen pen = new Pen(borderBrush, borderThickness.Left);
      dc.DrawRectangle((Brush) null, pen, borderBounds);
    }
    else
    {
      borderBounds.Y = 0.5;
      --borderBounds.Height;
      borderBounds.X += 0.5;
      --borderBounds.Width;
      if (borderThickness.Top > 0.0)
      {
        Pen pen = new Pen(borderBrush, borderThickness.Top);
        dc.DrawLine(pen, borderBounds.TopLeft, borderBounds.TopRight);
      }
      if (borderThickness.Left > 0.0)
      {
        Pen pen = new Pen(borderBrush, borderThickness.Left);
        dc.DrawLine(pen, borderBounds.TopLeft, borderBounds.BottomLeft);
      }
      if (borderThickness.Right > 0.0)
      {
        Pen pen = new Pen(borderBrush, borderThickness.Right);
        dc.DrawLine(pen, borderBounds.TopRight, borderBounds.BottomRight);
      }
      if (borderThickness.Bottom <= 0.0)
        return;
      Pen pen1 = new Pen(borderBrush, borderThickness.Bottom);
      dc.DrawLine(pen1, borderBounds.BottomLeft, borderBounds.BottomRight);
    }
  }
}
