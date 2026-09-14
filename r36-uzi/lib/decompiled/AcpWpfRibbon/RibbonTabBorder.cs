// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.RibbonTabBorder
// Assembly: AcpWpfRibbon, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 45A745B5-88C3-40EE-B1E5-8DBA2EACD529
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfRibbon.dll

using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

#nullable disable
namespace DevComponents.WpfRibbon;

[DesignTimeVisible(false)]
public class RibbonTabBorder : Decorator
{
  public static readonly DependencyProperty BackgroundProperty;
  public static readonly DependencyProperty BorderBrushProperty;
  public static readonly DependencyProperty BorderInnerBrushProperty;
  public static readonly DependencyProperty BorderOuterBrushProperty;
  public static readonly DependencyProperty PaddingProperty = DependencyProperty.Register(nameof (Padding), typeof (Thickness), typeof (RibbonTabBorder), (PropertyMetadata) new FrameworkPropertyMetadata((object) new Thickness(10.0, 1.0, 10.0, 2.0), FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender), new ValidateValueCallback(RibbonTabBorder.IsThicknessValid));
  public static readonly DependencyProperty TabStateProperty;
  public static readonly DependencyProperty ColorClassProperty;
  private int m_CornerSize = 3;
  private StreamGeometry m_SelectedBackgroundGeometry;
  private StreamGeometry m_SelectedBorderGeometry;
  private StreamGeometry m_SelectedBorderInnerGeometry;
  private StreamGeometry m_BackgroundGeometry;
  private StreamGeometry m_BorderGeometry;
  private StreamGeometry m_BorderInnerGeometry;
  private StreamGeometry m_BorderOuterGeometry;
  private bool m_Animation = true;
  private const double FadeDuration = 0.2;
  private RibbonTabBorder.RenderOverlayBrushes m_RenderBrushes;
  private double m_SizeReducedFactor;
  private Brush m_SeparatorBrush;
  private Pen m_SeparatorPen;
  private object m_ResourceAccessLock = new object();

  static RibbonTabBorder()
  {
    RibbonTabBorder.BorderBrushProperty = DependencyProperty.Register(nameof (BorderBrush), typeof (Brush), typeof (RibbonTabBorder), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.SubPropertiesDoNotAffectRender));
    RibbonTabBorder.BorderInnerBrushProperty = DependencyProperty.Register(nameof (BorderInnerBrush), typeof (Brush), typeof (RibbonTabBorder), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.SubPropertiesDoNotAffectRender));
    RibbonTabBorder.BorderOuterBrushProperty = DependencyProperty.Register(nameof (BorderOuterBrush), typeof (Brush), typeof (RibbonTabBorder), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.SubPropertiesDoNotAffectRender));
    RibbonTabBorder.BackgroundProperty = Panel.BackgroundProperty.AddOwner(typeof (RibbonTabBorder), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.SubPropertiesDoNotAffectRender));
    RibbonTabBorder.TabStateProperty = DependencyProperty.Register(nameof (TabState), typeof (eRibbonTabRenderingState), typeof (RibbonTabBorder), (PropertyMetadata) new FrameworkPropertyMetadata((object) eRibbonTabRenderingState.Normal, FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(RibbonTabBorder.OnTabStateChanged)));
    RibbonTabBorder.ColorClassProperty = DependencyProperty.Register(nameof (ColorClass), typeof (string), typeof (RibbonTabBorder), (PropertyMetadata) new FrameworkPropertyMetadata((object) RibbonColors.RibbonTabClass, FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(RibbonTabBorder.OnTabClassChanged)));
  }

  protected override void OnRender(DrawingContext dc)
  {
    base.OnRender(dc);
    eRibbonTabRenderingState tabState = this.TabState;
    StreamGeometry backgroundGeometry = this.m_BackgroundGeometry;
    StreamGeometry streamGeometry = this.m_BorderGeometry;
    StreamGeometry borderInnerGeometry = this.m_BorderInnerGeometry;
    if (tabState == eRibbonTabRenderingState.Selected || tabState == eRibbonTabRenderingState.HoverSelected)
    {
      backgroundGeometry = this.m_SelectedBackgroundGeometry;
      streamGeometry = this.m_SelectedBorderGeometry;
      borderInnerGeometry = this.m_SelectedBorderInnerGeometry;
    }
    RibbonTabBorder.RenderOverlayBrushes renderOverlayBrushes = this.GetRenderOverlayBrushes();
    if (backgroundGeometry != null)
    {
      Brush background1 = this.Background;
      if (background1 != null)
        dc.DrawGeometry(background1, (Pen) null, (Geometry) backgroundGeometry);
      if (renderOverlayBrushes != null && renderOverlayBrushes.Background != null)
      {
        Brush background2 = renderOverlayBrushes.Background;
        dc.DrawGeometry(background2, (Pen) null, (Geometry) backgroundGeometry);
      }
    }
    if (this.m_BorderOuterGeometry != null)
    {
      Brush borderOuterBrush1 = this.BorderOuterBrush;
      if (borderOuterBrush1 != null)
        dc.DrawGeometry(borderOuterBrush1, (Pen) null, (Geometry) this.m_BorderOuterGeometry);
      if (renderOverlayBrushes != null && renderOverlayBrushes.BorderOuterBrush != null)
      {
        Brush borderOuterBrush2 = renderOverlayBrushes.BorderOuterBrush;
        dc.DrawGeometry(borderOuterBrush2, (Pen) null, (Geometry) this.m_BorderOuterGeometry);
      }
    }
    if (borderInnerGeometry != null)
    {
      Brush borderInnerBrush1 = this.BorderInnerBrush;
      if (borderInnerBrush1 != null)
        dc.DrawGeometry(borderInnerBrush1, (Pen) null, (Geometry) borderInnerGeometry);
      if (renderOverlayBrushes != null && renderOverlayBrushes.BorderInnerBrush != null)
      {
        Brush borderInnerBrush2 = renderOverlayBrushes.BorderInnerBrush;
        dc.DrawGeometry(borderInnerBrush2, (Pen) null, (Geometry) borderInnerGeometry);
      }
    }
    if (streamGeometry != null)
    {
      Brush borderBrush1 = this.BorderBrush;
      if (borderBrush1 != null)
        dc.DrawGeometry(borderBrush1, (Pen) null, (Geometry) streamGeometry);
      if (renderOverlayBrushes != null && renderOverlayBrushes.BorderBrush != null)
      {
        Brush borderBrush2 = renderOverlayBrushes.BorderBrush;
        dc.DrawGeometry(borderBrush2, (Pen) null, (Geometry) streamGeometry);
      }
    }
    if (this.m_SizeReducedFactor <= 0.0 || this.m_SizeReducedFactor >= 0.8)
      return;
    Pen separatorPen = this.GetSeparatorPen();
    if (separatorPen == null)
      return;
    DrawingContext drawingContext = dc;
    Pen pen = separatorPen;
    Size desiredSize = this.DesiredSize;
    System.Windows.Point point0 = new System.Windows.Point(desiredSize.Width - 1.5, 0.0);
    desiredSize = this.DesiredSize;
    double x = desiredSize.Width - 1.5;
    desiredSize = this.DesiredSize;
    double y = desiredSize.Height + 3.0;
    System.Windows.Point point1 = new System.Windows.Point(x, y);
    drawingContext.DrawLine(pen, point0, point1);
  }

  private Pen GetSeparatorPen()
  {
    if (this.m_SeparatorPen != null)
      return this.m_SeparatorPen;
    if (this.m_SeparatorBrush == null)
      this.m_SeparatorBrush = this.TryFindResource((object) new ComponentResourceKey(typeof (Ribbon), (object) RibbonColors.RibbonTabSeparator)) as Brush;
    if (this.m_SeparatorBrush == null)
      return (Pen) null;
    this.m_SeparatorPen = new Pen(this.m_SeparatorBrush, 1.0);
    return this.m_SeparatorPen;
  }

  protected override Size MeasureOverride(Size constraint)
  {
    UIElement child = this.Child;
    Size size = new Size((double) (this.m_CornerSize * 2), (double) (this.m_CornerSize * 2 - 1));
    if (child != null)
    {
      child.Measure(constraint);
      Size desiredSize = child.DesiredSize;
      size.Width += desiredSize.Width;
      size.Height += desiredSize.Height;
    }
    ref Size local = ref size;
    double width = local.Width;
    Thickness padding = this.Padding;
    double left = padding.Left;
    padding = this.Padding;
    double right = padding.Right;
    double num = left + right;
    local.Width = width + num;
    size.Height += this.Padding.Top + this.Padding.Bottom;
    if (size.Width > constraint.Width)
    {
      this.m_SizeReducedFactor = size.Width <= 0.0 ? 0.0 : constraint.Width / size.Width;
      size.Width = Math.Max((double) RibbonTab.MinimumTabWidth, constraint.Width);
    }
    else
      this.m_SizeReducedFactor = 0.0;
    return size;
  }

  private Rect GetInnerRect(Rect r)
  {
    r.Inflate(-1.0, 0.0);
    r.Offset(0.0, 1.0);
    --r.Height;
    return r;
  }

  protected override Size ArrangeOverride(Size finalSize)
  {
    this.m_SelectedBackgroundGeometry = (StreamGeometry) null;
    this.m_SelectedBorderGeometry = (StreamGeometry) null;
    this.m_SelectedBorderInnerGeometry = (StreamGeometry) null;
    this.m_BackgroundGeometry = (StreamGeometry) null;
    this.m_BorderGeometry = (StreamGeometry) null;
    this.m_BorderInnerGeometry = (StreamGeometry) null;
    Rect rect1 = new Rect(finalSize);
    rect1.Inflate((double) -this.m_CornerSize, 0.0);
    if (LayoutHelpers.IsZero(finalSize.Width) || LayoutHelpers.IsZero(finalSize.Height) || LayoutHelpers.GreaterThan(0.0, rect1.Width))
      return finalSize;
    CornerRadius rad = new CornerRadius((double) this.m_CornerSize, (double) this.m_CornerSize, (double) (this.m_CornerSize - 2), (double) (this.m_CornerSize - 2));
    this.m_SelectedBackgroundGeometry = new StreamGeometry();
    using (StreamGeometryContext ctx = this.m_SelectedBackgroundGeometry.Open())
    {
      Rect innerRect = this.GetInnerRect(rect1);
      this.CreateTabGeometry(ctx, innerRect, new LayoutHelpers.RadiusDescription(rad, new Thickness(1.0), false), false);
    }
    this.m_SelectedBorderGeometry = new StreamGeometry();
    using (StreamGeometryContext ctx = this.m_SelectedBorderGeometry.Open())
    {
      this.CreateTabGeometry(ctx, rect1, new LayoutHelpers.RadiusDescription(rad, new Thickness(1.0), true), false);
      Rect innerRect = this.GetInnerRect(rect1);
      this.CreateTabGeometry(ctx, innerRect, new LayoutHelpers.RadiusDescription(rad, new Thickness(1.0), true), false);
    }
    this.m_SelectedBorderInnerGeometry = new StreamGeometry();
    using (StreamGeometryContext ctx = this.m_SelectedBorderInnerGeometry.Open())
    {
      Rect rect2 = rect1;
      rect2.Inflate(-1.0, -1.0);
      this.CreateTabGeometry(ctx, rect2, new LayoutHelpers.RadiusDescription(rad, new Thickness(1.0), true), false);
      Rect innerRect = this.GetInnerRect(rect2);
      this.CreateTabGeometry(ctx, innerRect, new LayoutHelpers.RadiusDescription(rad, new Thickness(1.0), true), false);
    }
    rad = new CornerRadius((double) this.m_CornerSize, (double) this.m_CornerSize, 0.0, 0.0);
    this.m_BackgroundGeometry = new StreamGeometry();
    using (StreamGeometryContext ctx = this.m_BackgroundGeometry.Open())
    {
      Rect innerRect = this.GetInnerRect(rect1);
      this.CreateTabGeometry(ctx, innerRect, new LayoutHelpers.RadiusDescription(rad, new Thickness(1.0), false), false);
    }
    this.m_BorderGeometry = new StreamGeometry();
    using (StreamGeometryContext ctx = this.m_BorderGeometry.Open())
    {
      this.CreateTabGeometry(ctx, rect1, new LayoutHelpers.RadiusDescription(rad, new Thickness(1.0), true), false);
      Rect innerRect = this.GetInnerRect(rect1);
      this.CreateTabGeometry(ctx, innerRect, new LayoutHelpers.RadiusDescription(rad, new Thickness(1.0), true), false);
    }
    this.m_BorderOuterGeometry = new StreamGeometry();
    using (StreamGeometryContext ctx = this.m_BorderOuterGeometry.Open())
    {
      Rect rect3 = rect1;
      rect3.Inflate(1.0, 0.0);
      this.CreateTabGeometry(ctx, rect3, new LayoutHelpers.RadiusDescription(rad, new Thickness(1.0), true), false);
      Rect innerRect = this.GetInnerRect(rect3);
      this.CreateTabGeometry(ctx, innerRect, new LayoutHelpers.RadiusDescription(rad, new Thickness(1.0), true), false);
    }
    this.m_BorderInnerGeometry = new StreamGeometry();
    using (StreamGeometryContext ctx = this.m_BorderInnerGeometry.Open())
    {
      Rect rect4 = rect1;
      rect4.Inflate(-1.0, -1.0);
      this.CreateTabGeometry(ctx, rect4, new LayoutHelpers.RadiusDescription(rad, new Thickness(1.0), true), false);
      Rect innerRect = this.GetInnerRect(rect4);
      this.CreateTabGeometry(ctx, innerRect, new LayoutHelpers.RadiusDescription(rad, new Thickness(1.0), true), false);
    }
    UIElement child = this.Child;
    if (child != null)
    {
      rect1.Inflate(-2.0, (double) -this.m_CornerSize);
      Thickness padding = this.Padding;
      Size desiredSize = child.DesiredSize;
      if (LayoutHelpers.GreaterThan(rect1.Width, desiredSize.Width))
      {
        double num = (rect1.Width - desiredSize.Width) / 2.0;
        rect1.X += num;
        rect1.Width = desiredSize.Width;
      }
      child.Arrange(rect1);
    }
    return finalSize;
  }

  private void CreateTabGeometry(
    StreamGeometryContext ctx,
    Rect rect,
    LayoutHelpers.RadiusDescription rd,
    bool isBorder)
  {
    System.Windows.Point point1 = new System.Windows.Point(rect.X, rect.Y + rd.TopLeft.Y);
    System.Windows.Point point2 = new System.Windows.Point(rect.X + rd.TopLeft.X, rect.Y);
    System.Windows.Point point3 = new System.Windows.Point(rect.Right - rd.TopRight.X, rect.Y);
    System.Windows.Point point4 = new System.Windows.Point(rect.Right, rect.Y + rd.TopRight.Y);
    System.Windows.Point point5 = new System.Windows.Point(rect.Right, rect.Bottom - rd.BottomRight.Y);
    System.Windows.Point point6 = new System.Windows.Point(rect.Right + rd.BottomRight.X, rect.Bottom);
    System.Windows.Point point7 = new System.Windows.Point(rect.X - rd.BottomLeft.X, rect.Bottom);
    System.Windows.Point point8 = new System.Windows.Point(rect.X, rect.Bottom - rd.BottomLeft.Y);
    if (point1.Y > point7.Y)
    {
      point1.Y = rect.Y + rect.Height / 2.0;
      point8.Y = point1.Y;
    }
    if (point2.X > point3.X)
    {
      point2.X = rect.X + rect.Width / 2.0;
      point3.X = point2.X;
    }
    if (point4.Y > point5.Y)
    {
      point4.Y = rect.Y + rect.Height / 2.0;
      point5.Y = point4.Y;
    }
    if (point7.X > point6.X)
    {
      point7.X = rect.X + rect.Width / 2.0;
      point6.X = point7.X;
    }
    if (isBorder)
      ctx.BeginFigure(point7, false, false);
    else
      ctx.BeginFigure(point7, true, true);
    Size size = new Size(Math.Max(0.0, rect.X - point7.X), Math.Max(0.0, rect.Bottom - point8.Y));
    if (!LayoutHelpers.IsZero(size))
      ctx.ArcTo(point8, size, 0.0, false, SweepDirection.Counterclockwise, true, false);
    ctx.LineTo(point1, true, false);
    size = new Size(Math.Max(point2.X - rect.X, 0.0), Math.Max(0.0, point1.Y - rect.Y));
    if (!LayoutHelpers.IsZero(size))
      ctx.ArcTo(point2, size, 0.0, false, SweepDirection.Clockwise, true, false);
    ctx.LineTo(point3, true, false);
    size = new Size(Math.Max(0.0, rect.Right - point3.X), Math.Max(0.0, point4.Y - rect.Y));
    if (!LayoutHelpers.IsZero(size))
      ctx.ArcTo(point4, size, 0.0, false, SweepDirection.Clockwise, true, false);
    ctx.LineTo(point5, true, false);
    size = new Size(Math.Max(0.0, point6.X - rect.Right), Math.Max(0.0, rect.Bottom - point5.Y));
    if (!LayoutHelpers.IsZero(size))
      ctx.ArcTo(point6, size, 0.0, false, SweepDirection.Counterclockwise, true, false);
    if (isBorder)
      return;
    ctx.LineTo(point7, true, false);
  }

  protected override HitTestResult HitTestCore(PointHitTestParameters hitTestParameters)
  {
    HitTestResult hitTestResult = base.HitTestCore(hitTestParameters);
    if (hitTestResult == null)
    {
      System.Windows.Point hitPoint = hitTestParameters.HitPoint;
      if (hitPoint.X >= 0.0)
      {
        hitPoint = hitTestParameters.HitPoint;
        if (hitPoint.Y >= 0.0)
        {
          hitPoint = hitTestParameters.HitPoint;
          double x = hitPoint.X;
          Size renderSize = this.RenderSize;
          double width = renderSize.Width;
          if (x <= width)
          {
            hitPoint = hitTestParameters.HitPoint;
            double y = hitPoint.Y;
            renderSize = this.RenderSize;
            double height = renderSize.Height;
            if (y < height)
              hitTestResult = (HitTestResult) new PointHitTestResult((Visual) this, hitTestParameters.HitPoint);
          }
        }
      }
    }
    return hitTestResult;
  }

  private static bool IsThicknessValid(object value) => LayoutHelpers.IsThicknessValid(value);

  public Thickness Padding
  {
    get => (Thickness) this.GetValue(RibbonTabBorder.PaddingProperty);
    set => this.SetValue(RibbonTabBorder.PaddingProperty, (object) value);
  }

  private static void OnTabStateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
  {
    RibbonTabBorder ribbonTabBorder = (RibbonTabBorder) d;
    ribbonTabBorder.UpdateOverlay((eRibbonTabRenderingState) e.OldValue, (eRibbonTabRenderingState) e.NewValue);
    ribbonTabBorder.UpdateVisualState();
  }

  private void UpdateOverlay(eRibbonTabRenderingState oldState, eRibbonTabRenderingState newState)
  {
    if (newState == eRibbonTabRenderingState.Hover || oldState == eRibbonTabRenderingState.Hover && newState == eRibbonTabRenderingState.Normal)
      this.CreateRendererOverlayBrushes(eRibbonTabRenderingState.Hover);
    else if (newState == eRibbonTabRenderingState.HoverSelected || oldState == eRibbonTabRenderingState.HoverSelected && newState == eRibbonTabRenderingState.Selected)
      this.CreateRendererOverlayBrushes(eRibbonTabRenderingState.HoverSelected);
    else
      this.DestroyRendererOverlayBrushes();
  }

  private void UpdateVisualState()
  {
    string colorClass = this.ColorClass;
    if (colorClass == "")
    {
      this.Background = (Brush) null;
      this.BorderBrush = (Brush) null;
      this.BorderInnerBrush = (Brush) null;
      this.BorderOuterBrush = (Brush) null;
      this.InvalidateVisual();
    }
    else
    {
      eRibbonTabRenderingState renderingState = this.TabState;
      if (this.AnimationEnabled)
      {
        switch (renderingState)
        {
          case eRibbonTabRenderingState.Hover:
            renderingState = eRibbonTabRenderingState.Normal;
            break;
          case eRibbonTabRenderingState.HoverSelected:
            renderingState = eRibbonTabRenderingState.Selected;
            break;
        }
      }
      string str = colorClass + this.GetStateKey(renderingState);
      this.SetResourceReference(RibbonTabBorder.BackgroundProperty, (object) new ComponentResourceKey(typeof (Ribbon), (object) (str + RibbonTabPartColorKeys.Background)));
      this.SetResourceReference(RibbonTabBorder.BorderBrushProperty, (object) new ComponentResourceKey(typeof (Ribbon), (object) (str + RibbonTabPartColorKeys.Border)));
      this.SetResourceReference(RibbonTabBorder.BorderInnerBrushProperty, (object) new ComponentResourceKey(typeof (Ribbon), (object) (str + RibbonTabPartColorKeys.BorderInner)));
      this.SetResourceReference(RibbonTabBorder.BorderOuterBrushProperty, (object) new ComponentResourceKey(typeof (Ribbon), (object) (str + RibbonTabPartColorKeys.BorderOuter)));
      this.m_SeparatorPen = (Pen) null;
      this.m_SeparatorBrush = this.TryFindResource((object) new ComponentResourceKey(typeof (Ribbon), (object) RibbonColors.RibbonTabSeparator)) as Brush;
      if (this.AnimationEnabled && (this.TabState == eRibbonTabRenderingState.Hover || this.TabState == eRibbonTabRenderingState.HoverSelected))
      {
        RibbonTabBorder.RenderOverlayBrushes renderOverlayBrushes = this.GetRenderOverlayBrushes();
        if (renderOverlayBrushes == null)
          return;
        DoubleAnimation animation1 = new DoubleAnimation(0.3, 1.0, new Duration(TimeSpan.FromSeconds(0.2)));
        renderOverlayBrushes.BeginAnimation(animation1);
      }
      else if (this.AnimationEnabled && (this.TabState == eRibbonTabRenderingState.Normal || this.TabState == eRibbonTabRenderingState.Selected))
      {
        RibbonTabBorder.RenderOverlayBrushes renderOverlayBrushes = this.GetRenderOverlayBrushes();
        if (renderOverlayBrushes == null)
          return;
        DoubleAnimation animation1 = new DoubleAnimation(1.0, 0.0, new Duration(TimeSpan.FromSeconds(0.2)));
        renderOverlayBrushes.BeginAnimation(animation1);
      }
      else
        this.InvalidateVisual();
    }
  }

  private string GetStateKey(eRibbonTabRenderingState renderingState)
  {
    switch (renderingState)
    {
      case eRibbonTabRenderingState.Normal:
        return RibbonTabStateColorKeys.Normal;
      case eRibbonTabRenderingState.Selected:
        return RibbonTabStateColorKeys.Selected;
      case eRibbonTabRenderingState.Hover:
        return RibbonTabStateColorKeys.Hover;
      case eRibbonTabRenderingState.HoverSelected:
        return RibbonTabStateColorKeys.HoverSelected;
      case eRibbonTabRenderingState.Focused:
        return RibbonTabStateColorKeys.Focused;
      default:
        return RibbonTabStateColorKeys.Normal;
    }
  }

  private static void OnTabClassChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
  {
    ((RibbonTabBorder) d).UpdateVisualState();
  }

  [DefaultValue(null)]
  public Brush Background
  {
    get => (Brush) this.GetValue(RibbonTabBorder.BackgroundProperty);
    set => this.SetValue(RibbonTabBorder.BackgroundProperty, (object) value);
  }

  [DefaultValue(null)]
  public Brush BorderBrush
  {
    get => (Brush) this.GetValue(RibbonTabBorder.BorderBrushProperty);
    set => this.SetValue(RibbonTabBorder.BorderBrushProperty, (object) value);
  }

  [DefaultValue(null)]
  public Brush BorderInnerBrush
  {
    get => (Brush) this.GetValue(RibbonTabBorder.BorderInnerBrushProperty);
    set => this.SetValue(RibbonTabBorder.BorderInnerBrushProperty, (object) value);
  }

  [DefaultValue(null)]
  public Brush BorderOuterBrush
  {
    get => (Brush) this.GetValue(RibbonTabBorder.BorderOuterBrushProperty);
    set => this.SetValue(RibbonTabBorder.BorderOuterBrushProperty, (object) value);
  }

  [DefaultValue("Button")]
  public string ColorClass
  {
    get => (string) this.GetValue(RibbonTabBorder.ColorClassProperty);
    set => this.SetValue(RibbonTabBorder.ColorClassProperty, (object) value);
  }

  [DefaultValue(eRibbonTabRenderingState.Normal)]
  public eRibbonTabRenderingState TabState
  {
    get => (eRibbonTabRenderingState) this.GetValue(RibbonTabBorder.TabStateProperty);
    set => this.SetValue(RibbonTabBorder.TabStateProperty, (object) value);
  }

  private bool AnimationEnabled
  {
    get
    {
      return SystemParameters.PowerLineStatus == PowerLineStatus.Online && SystemParameters.ClientAreaAnimation && RenderCapability.Tier > 0 && this.IsEnabled && this.m_Animation;
    }
  }

  internal bool Animation
  {
    get => this.m_Animation;
    set => this.m_Animation = value;
  }

  private RibbonTabBorder.RenderOverlayBrushes GetRenderOverlayBrushes()
  {
    return !this.IsEnabled || !this.AnimationEnabled ? (RibbonTabBorder.RenderOverlayBrushes) null : this.m_RenderBrushes;
  }

  private void DestroyRendererOverlayBrushes()
  {
    lock (this.m_ResourceAccessLock)
      this.m_RenderBrushes = (RibbonTabBorder.RenderOverlayBrushes) null;
  }

  private void CreateRendererOverlayBrushes(eRibbonTabRenderingState renderingState)
  {
    lock (this.m_ResourceAccessLock)
    {
      this.m_RenderBrushes = new RibbonTabBorder.RenderOverlayBrushes();
      string colorClass = this.ColorClass;
      if (!(colorClass != ""))
        return;
      string str = colorClass + this.GetStateKey(renderingState);
      if (this.TryFindResource((object) new ComponentResourceKey(typeof (Ribbon), (object) (str + RibbonTabPartColorKeys.Background))) is Brush resource1)
        this.m_RenderBrushes.Background = resource1.Clone();
      if (this.TryFindResource((object) new ComponentResourceKey(typeof (Ribbon), (object) (str + RibbonTabPartColorKeys.Border))) is Brush resource2)
        this.m_RenderBrushes.BorderBrush = resource2.Clone();
      if (this.TryFindResource((object) new ComponentResourceKey(typeof (Ribbon), (object) (str + RibbonTabPartColorKeys.BorderInner))) is Brush resource3)
        this.m_RenderBrushes.BorderInnerBrush = resource3.Clone();
      if (!(this.TryFindResource((object) new ComponentResourceKey(typeof (Ribbon), (object) (str + RibbonTabPartColorKeys.BorderOuter))) is Brush resource4))
        return;
      this.m_RenderBrushes.BorderOuterBrush = resource4.Clone();
    }
  }

  private class RenderOverlayBrushes
  {
    public Brush Background;
    public Brush BorderBrush;
    public Brush BorderInnerBrush;
    public Brush BorderOuterBrush;

    internal void BeginAnimation(DoubleAnimation animation1)
    {
      if (this.Background != null)
        this.Background.BeginAnimation(Brush.OpacityProperty, (AnimationTimeline) animation1);
      if (this.BorderBrush != null)
        this.BorderBrush.BeginAnimation(Brush.OpacityProperty, (AnimationTimeline) animation1);
      if (this.BorderInnerBrush != null)
        this.BorderInnerBrush.BeginAnimation(Brush.OpacityProperty, (AnimationTimeline) animation1);
      if (this.BorderOuterBrush == null)
        return;
      this.BorderOuterBrush.BeginAnimation(Brush.OpacityProperty, (AnimationTimeline) animation1);
    }
  }
}
