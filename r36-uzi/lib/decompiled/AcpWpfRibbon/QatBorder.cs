// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.QatBorder
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
public class QatBorder : Decorator
{
  public static readonly DependencyProperty BackgroundProperty;
  public static readonly DependencyProperty BorderBrushProperty;
  public static readonly DependencyProperty BorderThicknessProperty = DependencyProperty.Register(nameof (BorderThickness), typeof (Thickness), typeof (QatBorder), (PropertyMetadata) new FrameworkPropertyMetadata((object) new Thickness(), FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender), new ValidateValueCallback(QatBorder.IsThicknessValid));
  public static readonly DependencyProperty LightBorderBrushProperty;
  public static readonly DependencyProperty PaddingProperty = DependencyProperty.Register(nameof (Padding), typeof (Thickness), typeof (QatBorder), (PropertyMetadata) new FrameworkPropertyMetadata((object) new Thickness(), FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender), new ValidateValueCallback(QatBorder.IsThicknessValid));
  public static readonly DependencyProperty IsBorderVisibleProperty;
  public static readonly DependencyProperty IsBackgroundVisibleProperty;
  private StreamGeometry m_BackgroundGeometry;
  private StreamGeometry m_BorderGeometry;
  private StreamGeometry m_LightBorderGeometry;
  private const int ArcWidth = 12;

  static QatBorder()
  {
    QatBorder.BorderBrushProperty = DependencyProperty.Register(nameof (BorderBrush), typeof (Brush), typeof (QatBorder), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.SubPropertiesDoNotAffectRender));
    QatBorder.BackgroundProperty = Panel.BackgroundProperty.AddOwner(typeof (QatBorder), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.SubPropertiesDoNotAffectRender));
    QatBorder.LightBorderBrushProperty = DependencyProperty.Register(nameof (LightBorderBrush), typeof (Brush), typeof (QatBorder), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.SubPropertiesDoNotAffectRender));
    QatBorder.IsBorderVisibleProperty = DependencyProperty.Register(nameof (IsBorderVisible), typeof (bool), typeof (QatBorder), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsParentMeasure | FrameworkPropertyMetadataOptions.AffectsParentArrange | FrameworkPropertyMetadataOptions.AffectsRender));
    QatBorder.IsBackgroundVisibleProperty = DependencyProperty.Register(nameof (IsBackgroundVisible), typeof (bool), typeof (QatBorder), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender));
  }

  [DefaultValue(null)]
  public Brush Background
  {
    get => (Brush) this.GetValue(QatBorder.BackgroundProperty);
    set => this.SetValue(QatBorder.BackgroundProperty, (object) value);
  }

  [DefaultValue(null)]
  public Brush BorderBrush
  {
    get => (Brush) this.GetValue(QatBorder.BorderBrushProperty);
    set => this.SetValue(QatBorder.BorderBrushProperty, (object) value);
  }

  [DefaultValue(null)]
  public Brush LightBorderBrush
  {
    get => (Brush) this.GetValue(QatBorder.LightBorderBrushProperty);
    set => this.SetValue(QatBorder.LightBorderBrushProperty, (object) value);
  }

  public Thickness BorderThickness
  {
    get => (Thickness) this.GetValue(QatBorder.BorderThicknessProperty);
    set => this.SetValue(QatBorder.BorderThicknessProperty, (object) value);
  }

  public Thickness Padding
  {
    get => (Thickness) this.GetValue(QatBorder.PaddingProperty);
    set => this.SetValue(QatBorder.PaddingProperty, (object) value);
  }

  [DefaultValue(true)]
  public bool IsBorderVisible
  {
    get => (bool) this.GetValue(QatBorder.IsBorderVisibleProperty);
    set => this.SetValue(QatBorder.IsBorderVisibleProperty, (object) value);
  }

  [DefaultValue(true)]
  public bool IsBackgroundVisible
  {
    get => (bool) this.GetValue(QatBorder.IsBackgroundVisibleProperty);
    set => this.SetValue(QatBorder.IsBackgroundVisibleProperty, (object) value);
  }

  private static bool IsThicknessValid(object value)
  {
    Thickness thickness = (Thickness) value;
    return thickness.Left >= 0.0 && thickness.Right >= 0.0 && thickness.Top >= 0.0 && thickness.Bottom >= 0.0 && !double.IsNaN(thickness.Left) && !double.IsNaN(thickness.Right) && !double.IsNaN(thickness.Top) && !double.IsNaN(thickness.Bottom) && !double.IsPositiveInfinity(thickness.Left) && !double.IsPositiveInfinity(thickness.Right) && !double.IsPositiveInfinity(thickness.Top) && !double.IsPositiveInfinity(thickness.Bottom) && !double.IsNegativeInfinity(thickness.Left) && !double.IsNegativeInfinity(thickness.Right) && !double.IsNegativeInfinity(thickness.Top) && !double.IsNegativeInfinity(thickness.Bottom);
  }

  private bool RendersBorder
  {
    get
    {
      return (!this.IsBorderVisible || !(this.Child is QatPanel child) || !child.HasOnlyCustomizeItem) && this.IsBorderVisible;
    }
  }

  protected override Size MeasureOverride(Size constraint)
  {
    UIElement child = this.Child;
    if (!this.RendersBorder)
    {
      child.Measure(constraint);
      return child.DesiredSize;
    }
    Size thicknessSize1 = QatBorder.GetThicknessSize(this.BorderThickness);
    Size thicknessSize2 = QatBorder.GetThicknessSize(this.Padding);
    if (child == null)
      return new Size(thicknessSize1.Width + thicknessSize2.Width, thicknessSize1.Height + thicknessSize2.Height);
    Size size = new Size(thicknessSize2.Width + 12.0 + 2.0, thicknessSize2.Height);
    Size availableSize = new Size(Math.Max(0.0, constraint.Width - size.Width), Math.Max(0.0, constraint.Height - size.Height));
    child.Measure(availableSize);
    Size desiredSize = child.DesiredSize;
    size.Width = desiredSize.Width + size.Width;
    size.Height = desiredSize.Height + size.Height;
    return size;
  }

  private QatCustomizeButton GetQatCustomizeButton()
  {
    if (this.Child is QatPanel)
    {
      QatPanel child = this.Child as QatPanel;
      for (int index = child.Children.Count - 1; index >= 0; --index)
      {
        if (child.Children[index] is QatCustomizeButton)
          return child.Children[index] as QatCustomizeButton;
        if (child.Children[index].Visibility == Visibility.Visible)
          break;
      }
    }
    return (QatCustomizeButton) null;
  }

  protected override Size ArrangeOverride(Size finalSize)
  {
    UIElement child = this.Child;
    if (!this.RendersBorder)
    {
      child?.Arrange(new Rect(finalSize));
      return finalSize;
    }
    Thickness borderThickness = this.BorderThickness;
    Rect rect1 = new Rect(finalSize);
    Rect rect2 = QatBorder.DeflateRect(rect1, borderThickness);
    rect2.Inflate(0.0, -1.0);
    rect2.X += 0.5;
    rect2.Width -= 0.5;
    if (child != null)
    {
      int num = 7;
      Rect r = new Rect(rect1.X + (double) num, rect1.Y, rect1.Width - (double) num, rect1.Height);
      child.Arrange(QatBorder.DeflateRect(r, this.Padding));
    }
    QatCustomizeButton qatCustomizeButton = this.GetQatCustomizeButton();
    if (qatCustomizeButton != null)
    {
      rect2.Width -= qatCustomizeButton.DesiredSize.Width;
      rect1.Width -= qatCustomizeButton.DesiredSize.Width;
    }
    Brush borderBrush = this.BorderBrush;
    Brush lightBorderBrush = this.LightBorderBrush;
    if (!QatBorder.IsZero(rect2.Width) && !QatBorder.IsZero(rect2.Height))
    {
      this.m_BackgroundGeometry = new StreamGeometry();
      using (StreamGeometryContext ctx = this.m_BackgroundGeometry.Open())
        QatBorder.CreateGeometry(ctx, rect2);
      this.m_BackgroundGeometry.Freeze();
    }
    else
      this.m_BackgroundGeometry = (StreamGeometry) null;
    if (!QatBorder.IsZero(rect1.Width) && !QatBorder.IsZero(rect1.Height) && !rect1.IsEmpty)
    {
      if (this.LightBorderBrush != null)
      {
        this.m_LightBorderGeometry = new StreamGeometry();
        using (StreamGeometryContext ctx = this.m_LightBorderGeometry.Open())
        {
          Rect rect3 = rect1;
          ++rect3.Y;
          --rect3.Height;
          --rect3.X;
          rect3.Width += 1.5;
          QatBorder.CreateGeometry(ctx, rect3);
        }
        this.m_LightBorderGeometry.Freeze();
        rect1.Inflate(0.0, -1.0);
      }
      else
        this.m_LightBorderGeometry = (StreamGeometry) null;
      this.m_BorderGeometry = new StreamGeometry();
      using (StreamGeometryContext ctx = this.m_BorderGeometry.Open())
      {
        rect1.Inflate(-0.5, -0.5);
        QatBorder.CreateGeometry(ctx, rect1);
      }
      this.m_BorderGeometry.Freeze();
      return finalSize;
    }
    this.m_BackgroundGeometry = (StreamGeometry) null;
    this.m_BorderGeometry = (StreamGeometry) null;
    return finalSize;
  }

  protected override void OnRender(DrawingContext dc)
  {
    if (!this.RendersBorder || this.Child is QatPanel && ((QatPanel) this.Child).IsCompleteOverflow)
      return;
    if (this.IsBackgroundVisible)
    {
      if (this.m_LightBorderGeometry != null && this.LightBorderBrush != null)
        dc.DrawGeometry(this.LightBorderBrush, (Pen) null, (Geometry) this.m_LightBorderGeometry);
      if (this.m_BackgroundGeometry != null && this.Background != null)
        dc.DrawGeometry(this.Background, (Pen) null, (Geometry) this.m_BackgroundGeometry);
    }
    if (this.m_BorderGeometry == null || this.BorderBrush == null)
      return;
    dc.DrawGeometry((Brush) null, new Pen(this.BorderBrush, 1.0), (Geometry) this.m_BorderGeometry);
  }

  private static void CreateGeometry(StreamGeometryContext ctx, Rect rect)
  {
    ctx.BeginFigure(rect.Location, true, true);
    ctx.BezierTo(rect.Location, new System.Windows.Point(rect.X + 10.0, rect.Y + 2.0), new System.Windows.Point(rect.X + 12.0, rect.Bottom - 5.0), true, true);
    ctx.LineTo(new System.Windows.Point(rect.X + 12.0, rect.Bottom), true, true);
    ctx.LineTo(new System.Windows.Point(rect.Right - 9.0, rect.Bottom), true, true);
    ctx.ArcTo(new System.Windows.Point(rect.Right - 9.0, rect.Y), new Size(52.0, rect.Height), 0.0, false, SweepDirection.Counterclockwise, true, true);
    ctx.LineTo(rect.Location, true, true);
  }

  private static Rect DeflateRect(Rect r, Thickness thick)
  {
    return new Rect(r.Left + thick.Left, r.Top + thick.Top, Math.Max(0.0, r.Width - thick.Left - thick.Right), Math.Max(0.0, r.Height - thick.Top - thick.Bottom));
  }

  private static Size GetThicknessSize(Thickness t) => new Size(t.Left + t.Right, t.Top + t.Bottom);

  private static bool IsZero(double value) => Math.Abs(value) < 2.2204460492503131E-15;
}
