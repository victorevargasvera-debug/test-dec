// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfDock.Primitives.DocumentTabBorder
// Assembly: AcpWpfDock, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 89CC52D3-0487-4106-AFAE-BE4A13C8A50E
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfDock.dll

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

#nullable disable
namespace DevComponents.WpfDock.Primitives;

[DesignTimeVisible(false)]
public class DocumentTabBorder : Decorator
{
  public static readonly DependencyProperty BackgroundProperty;
  public static readonly DependencyProperty BorderBrushProperty = DependencyProperty.Register(nameof (BorderBrush), typeof (Brush), typeof (DocumentTabBorder), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.SubPropertiesDoNotAffectRender));
  public static readonly DependencyProperty BorderInnerBrushProperty = DependencyProperty.Register(nameof (BorderInnerBrush), typeof (Brush), typeof (DocumentTabBorder), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.SubPropertiesDoNotAffectRender));
  public static readonly DependencyProperty BottomBorderBrushProperty;
  private PathGeometry m_BorderGeometry;
  private PathGeometry m_BorderInnerGeometry;

  static DocumentTabBorder()
  {
    DocumentTabBorder.BackgroundProperty = Panel.BackgroundProperty.AddOwner(typeof (DocumentTabBorder), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.SubPropertiesDoNotAffectRender));
    DocumentTabBorder.BottomBorderBrushProperty = DependencyProperty.Register(nameof (BottomBorderBrush), typeof (Brush), typeof (DocumentTabBorder), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.SubPropertiesDoNotAffectRender));
  }

  protected override Size MeasureOverride(Size constraint)
  {
    if (this.Child == null)
      return base.MeasureOverride(constraint);
    Size availableSize = constraint;
    availableSize.Width = Math.Max(0.0, availableSize.Width - 4.0);
    availableSize.Height = Math.Max(0.0, availableSize.Height - 4.0);
    this.Child.Measure(availableSize);
    Size desiredSize = this.Child.DesiredSize;
    desiredSize.Width += 4.0;
    desiredSize.Height += 4.0;
    desiredSize.Width += desiredSize.Height + 2.0;
    LayoutHelpers.NormalizeMeasureBounds(ref desiredSize);
    return desiredSize;
  }

  protected override Size ArrangeOverride(Size arrangeSize)
  {
    Rect finalRect = new Rect();
    finalRect.Width = Math.Max(0.0, arrangeSize.Width - 2.0 - arrangeSize.Height);
    finalRect.Height = Math.Max(0.0, arrangeSize.Height - 4.0);
    finalRect.X = Math.Min(arrangeSize.Height, arrangeSize.Width);
    finalRect.Y = Math.Min(2.0, arrangeSize.Height);
    if (this.Child != null)
      this.Child.Arrange(finalRect);
    this.m_BorderGeometry = new PathGeometry();
    this.m_BorderGeometry.Figures.Add(new PathFigure(new System.Windows.Point(0.0, arrangeSize.Height), (IEnumerable<PathSegment>) new PathSegment[6]
    {
      (PathSegment) new LineSegment(new System.Windows.Point(arrangeSize.Height - 3.0, 3.0), true),
      (PathSegment) new LineSegment(new System.Windows.Point(arrangeSize.Height, 1.5), true),
      (PathSegment) new LineSegment(new System.Windows.Point(arrangeSize.Height + 3.0, 0.5), true),
      (PathSegment) new LineSegment(new System.Windows.Point(arrangeSize.Width - 4.0, 0.5), true),
      (PathSegment) new ArcSegment(new System.Windows.Point(arrangeSize.Width - 0.5, 4.0), new Size(3.5, 3.5), 0.0, false, SweepDirection.Clockwise, true),
      (PathSegment) new LineSegment(new System.Windows.Point(arrangeSize.Width - 0.5, arrangeSize.Height), true)
    }, false));
    this.m_BorderInnerGeometry = new PathGeometry();
    this.m_BorderInnerGeometry.Figures.Add(new PathFigure(new System.Windows.Point(1.0, arrangeSize.Height), (IEnumerable<PathSegment>) new PathSegment[6]
    {
      (PathSegment) new LineSegment(new System.Windows.Point(arrangeSize.Height - 3.0, 4.0), true),
      (PathSegment) new LineSegment(new System.Windows.Point(arrangeSize.Height, 2.5), true),
      (PathSegment) new LineSegment(new System.Windows.Point(arrangeSize.Height + 3.0, 1.5), true),
      (PathSegment) new LineSegment(new System.Windows.Point(arrangeSize.Width - 5.0, 1.5), true),
      (PathSegment) new ArcSegment(new System.Windows.Point(arrangeSize.Width - 1.5, 5.0), new Size(3.5, 3.5), 0.0, false, SweepDirection.Clockwise, true),
      (PathSegment) new LineSegment(new System.Windows.Point(arrangeSize.Width - 1.5, arrangeSize.Height), true)
    }, false));
    return arrangeSize;
  }

  protected override void OnRender(DrawingContext drawingContext)
  {
    base.OnRender(drawingContext);
    if (this.m_BorderGeometry == null || this.Background == null && this.BorderBrush == null)
      return;
    Pen pen1 = (Pen) null;
    if (this.BorderBrush != null)
      pen1 = new Pen(this.BorderBrush, 1.0);
    drawingContext.DrawGeometry(this.Background, pen1, (Geometry) this.m_BorderGeometry);
    if (this.BorderInnerBrush != null)
    {
      Pen pen2 = new Pen(this.BorderInnerBrush, 1.0);
      drawingContext.DrawGeometry((Brush) null, pen2, (Geometry) this.m_BorderInnerGeometry);
    }
    if (this.BottomBorderBrush != null)
      drawingContext.DrawLine(new Pen(this.BottomBorderBrush, 1.2), new System.Windows.Point(0.0, this.ActualHeight - 0.5), new System.Windows.Point(this.ActualWidth - 1.0, this.ActualHeight - 0.5));
    if (this.VisualXSnappingGuidelines == null)
      this.VisualXSnappingGuidelines = new DoubleCollection((IEnumerable<double>) new double[2]
      {
        0.0,
        this.ActualWidth
      });
    if (this.VisualYSnappingGuidelines != null)
      return;
    this.VisualYSnappingGuidelines = new DoubleCollection((IEnumerable<double>) new double[2]
    {
      0.0,
      this.ActualHeight
    });
  }

  [DefaultValue(null)]
  public Brush Background
  {
    get => (Brush) this.GetValue(DocumentTabBorder.BackgroundProperty);
    set => this.SetValue(DocumentTabBorder.BackgroundProperty, (object) value);
  }

  [DefaultValue(null)]
  public Brush BorderBrush
  {
    get => (Brush) this.GetValue(DocumentTabBorder.BorderBrushProperty);
    set => this.SetValue(DocumentTabBorder.BorderBrushProperty, (object) value);
  }

  [DefaultValue(null)]
  public Brush BorderInnerBrush
  {
    get => (Brush) this.GetValue(DocumentTabBorder.BorderInnerBrushProperty);
    set => this.SetValue(DocumentTabBorder.BorderInnerBrushProperty, (object) value);
  }

  [DefaultValue(null)]
  public Brush BottomBorderBrush
  {
    get => (Brush) this.GetValue(DocumentTabBorder.BottomBorderBrushProperty);
    set => this.SetValue(DocumentTabBorder.BottomBorderBrushProperty, (object) value);
  }
}
