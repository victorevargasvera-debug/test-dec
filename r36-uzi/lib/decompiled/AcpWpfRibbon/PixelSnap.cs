// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.PixelSnap
// Assembly: AcpWpfRibbon, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 45A745B5-88C3-40EE-B1E5-8DBA2EACD529
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfRibbon.dll

using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

#nullable disable
namespace DevComponents.WpfRibbon;

[DesignTimeVisible(false)]
public class PixelSnap : Decorator
{
  protected override Size MeasureOverride(Size constraint)
  {
    UIElement child = this.Child;
    Size size = new Size(0.0, 0.0);
    if (child != null)
    {
      constraint.Width = Math.Floor(constraint.Width);
      constraint.Height = Math.Floor(constraint.Height);
      child.Measure(constraint);
      size = new Size(Math.Round(child.DesiredSize.Width), Math.Round(child.DesiredSize.Height));
    }
    return size;
  }

  protected override Size ArrangeOverride(Size finalSize)
  {
    UIElement child = this.Child;
    if (child == null)
      return finalSize;
    Rect finalRect = new Rect(0.0, 0.0, Math.Floor(finalSize.Width), Math.Floor(finalSize.Height));
    child.Arrange(finalRect);
    return finalRect.Size;
  }
}
