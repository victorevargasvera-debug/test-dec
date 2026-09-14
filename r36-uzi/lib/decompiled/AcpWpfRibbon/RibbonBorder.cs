// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.RibbonBorder
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
public class RibbonBorder : Decorator
{
  public static readonly DependencyProperty BackgroundProperty;
  public static readonly DependencyProperty TopHighlightProperty;
  public static readonly DependencyProperty BorderBrushProperty;
  public static readonly DependencyProperty LightBorderBrushProperty;
  public static readonly DependencyProperty PaddingProperty = DependencyProperty.Register(nameof (Padding), typeof (Thickness), typeof (RibbonBorder), (PropertyMetadata) new FrameworkPropertyMetadata((object) new Thickness(), FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender), new ValidateValueCallback(RibbonBorder.IsThicknessValid));
  public static readonly DependencyProperty CornerRadiusProperty;
  public static readonly DependencyProperty ColorClassProperty;
  public static readonly DependencyProperty BorderStateProperty;
  public static readonly DependencyProperty BorderThicknessProperty;
  public static readonly DependencyProperty LightBorderThicknessProperty;
  public static readonly DependencyProperty AutoAnimationProperty;
  public static readonly DependencyProperty InnerBorderProperty;
  public static readonly DependencyProperty IsRibbonPanelProperty;
  private StreamGeometry m_BackgroundGeometry;
  private StreamGeometry m_BorderGeometry;
  private StreamGeometry m_BorderGeometryMouseOver;
  private StreamGeometry m_LightBorderGeometry;
  private StreamGeometry m_LightBorderGeometryMouseOver;
  private const double FadeDuration = 0.4;
  private RibbonBorder.RenderOverlayBrushes m_RenderBrushes;
  private Rect m_SelectedTabRect;
  private object m_ResourceAccessLock = new object();

  static RibbonBorder()
  {
    RibbonBorder.BorderBrushProperty = DependencyProperty.Register(nameof (BorderBrush), typeof (Brush), typeof (RibbonBorder), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.SubPropertiesDoNotAffectRender));
    RibbonBorder.BackgroundProperty = Panel.BackgroundProperty.AddOwner(typeof (RibbonBorder), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.SubPropertiesDoNotAffectRender));
    RibbonBorder.LightBorderBrushProperty = DependencyProperty.Register(nameof (LightBorderBrush), typeof (Brush), typeof (RibbonBorder), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.SubPropertiesDoNotAffectRender));
    RibbonBorder.CornerRadiusProperty = DependencyProperty.Register(nameof (CornerRadius), typeof (CornerRadius), typeof (RibbonBorder), (PropertyMetadata) new FrameworkPropertyMetadata((object) new CornerRadius(0.0), FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.SubPropertiesDoNotAffectRender), new ValidateValueCallback(RibbonBorder.IsCornerRadiusValid));
    RibbonBorder.ColorClassProperty = DependencyProperty.Register(nameof (ColorClass), typeof (string), typeof (RibbonBorder), (PropertyMetadata) new FrameworkPropertyMetadata((object) RibbonColors.RibbonBarClass, FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(RibbonBorder.OnColorClassChanged)));
    RibbonBorder.BorderStateProperty = DependencyProperty.Register(nameof (BorderState), typeof (eRibbonBarRenderingState), typeof (RibbonBorder), (PropertyMetadata) new FrameworkPropertyMetadata((object) eRibbonBarRenderingState.Normal, FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(RibbonBorder.OnRibbonBarStateChanged)));
    RibbonBorder.TopHighlightProperty = DependencyProperty.Register(nameof (TopHighlight), typeof (Brush), typeof (RibbonBorder), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.SubPropertiesDoNotAffectRender));
    RibbonBorder.BorderThicknessProperty = DependencyProperty.Register(nameof (BorderThickness), typeof (Thickness), typeof (RibbonBorder), (PropertyMetadata) new FrameworkPropertyMetadata((object) new Thickness(0.0), FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender), new ValidateValueCallback(RibbonBorder.IsThicknessValid));
    RibbonBorder.LightBorderThicknessProperty = DependencyProperty.Register(nameof (LightBorderThickness), typeof (Thickness), typeof (RibbonBorder), (PropertyMetadata) new FrameworkPropertyMetadata((object) new Thickness(0.0), FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender), new ValidateValueCallback(RibbonBorder.IsThicknessValid));
    RibbonBorder.InnerBorderProperty = DependencyProperty.Register(nameof (InnerBorder), typeof (bool), typeof (RibbonBorder), (PropertyMetadata) new FrameworkPropertyMetadata((object) false, FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsRender));
    RibbonBorder.AutoAnimationProperty = DependencyProperty.Register(nameof (AutoAnimation), typeof (bool), typeof (RibbonBorder), (PropertyMetadata) new FrameworkPropertyMetadata((object) true));
    RibbonBorder.IsRibbonPanelProperty = DependencyProperty.Register(nameof (IsRibbonPanel), typeof (bool), typeof (RibbonBorder), (PropertyMetadata) new FrameworkPropertyMetadata((object) false));
  }

  internal Rect SelectedTabRect
  {
    get => this.m_SelectedTabRect;
    set
    {
      this.m_SelectedTabRect = value;
      this.InvalidateVisual();
    }
  }

  [DefaultValue(true)]
  public bool IsRibbonPanel
  {
    get => (bool) this.GetValue(RibbonBorder.IsRibbonPanelProperty);
    set => this.SetValue(RibbonBorder.IsRibbonPanelProperty, (object) value);
  }

  [DefaultValue(true)]
  public bool InnerBorder
  {
    get => (bool) this.GetValue(RibbonBorder.InnerBorderProperty);
    set => this.SetValue(RibbonBorder.InnerBorderProperty, (object) value);
  }

  [DefaultValue(true)]
  public bool AutoAnimation
  {
    get => (bool) this.GetValue(RibbonBorder.AutoAnimationProperty);
    set => this.SetValue(RibbonBorder.AutoAnimationProperty, (object) value);
  }

  public Thickness BorderThickness
  {
    get => (Thickness) this.GetValue(RibbonBorder.BorderThicknessProperty);
    set => this.SetValue(RibbonBorder.BorderThicknessProperty, (object) value);
  }

  public Thickness LightBorderThickness
  {
    get => (Thickness) this.GetValue(RibbonBorder.LightBorderThicknessProperty);
    set => this.SetValue(RibbonBorder.LightBorderThicknessProperty, (object) value);
  }

  private static bool IsThicknessValid(object value) => LayoutHelpers.IsThicknessValid(value);

  [DefaultValue(eButtonRenderingState.Normal)]
  public eRibbonBarRenderingState BorderState
  {
    get => (eRibbonBarRenderingState) this.GetValue(RibbonBorder.BorderStateProperty);
    set => this.SetValue(RibbonBorder.BorderStateProperty, (object) value);
  }

  public string ColorClass
  {
    get => (string) this.GetValue(RibbonBorder.ColorClassProperty);
    set => this.SetValue(RibbonBorder.ColorClassProperty, (object) value);
  }

  [TypeConverter(typeof (CornerRadiusConverter))]
  public CornerRadius CornerRadius
  {
    get => (CornerRadius) this.GetValue(RibbonBorder.CornerRadiusProperty);
    set => this.SetValue(RibbonBorder.CornerRadiusProperty, (object) value);
  }

  [DefaultValue(null)]
  public Brush Background
  {
    get => (Brush) this.GetValue(RibbonBorder.BackgroundProperty);
    set => this.SetValue(RibbonBorder.BackgroundProperty, (object) value);
  }

  [DefaultValue(null)]
  public Brush BorderBrush
  {
    get => (Brush) this.GetValue(RibbonBorder.BorderBrushProperty);
    set => this.SetValue(RibbonBorder.BorderBrushProperty, (object) value);
  }

  [DefaultValue(null)]
  public Brush TopHighlight
  {
    get => (Brush) this.GetValue(RibbonBorder.TopHighlightProperty);
    set => this.SetValue(RibbonBorder.TopHighlightProperty, (object) value);
  }

  [DefaultValue(null)]
  public Brush LightBorderBrush
  {
    get => (Brush) this.GetValue(RibbonBorder.LightBorderBrushProperty);
    set => this.SetValue(RibbonBorder.LightBorderBrushProperty, (object) value);
  }

  public Thickness Padding
  {
    get => (Thickness) this.GetValue(RibbonBorder.PaddingProperty);
    set => this.SetValue(RibbonBorder.PaddingProperty, (object) value);
  }

  private static void OnColorClassChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
  {
    ((RibbonBorder) d).OnColorClassChanged(e);
  }

  private void OnColorClassChanged(DependencyPropertyChangedEventArgs e)
  {
    this.UpdateVisualState();
  }

  private static void OnRibbonBarStateChanged(
    DependencyObject d,
    DependencyPropertyChangedEventArgs e)
  {
    RibbonBorder ribbonBorder = (RibbonBorder) d;
    ribbonBorder.UpdateOverlay((eRibbonBarRenderingState) e.OldValue, (eRibbonBarRenderingState) e.NewValue);
    ribbonBorder.UpdateVisualState();
  }

  private void UpdateOverlay(eRibbonBarRenderingState oldState, eRibbonBarRenderingState newState)
  {
    if (newState == eRibbonBarRenderingState.Hover || oldState == eRibbonBarRenderingState.Hover && newState == eRibbonBarRenderingState.Normal)
      this.CreateRendererOverlayBrushes(eRibbonBarRenderingState.Hover);
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
      this.LightBorderBrush = (Brush) null;
      this.InvalidateVisual();
    }
    else
    {
      eRibbonBarRenderingState renderingState = this.BorderState;
      if (this.AnimationEnabled && renderingState == eRibbonBarRenderingState.Hover)
        renderingState = eRibbonBarRenderingState.Normal;
      string str = colorClass + this.GetStateKey(renderingState);
      this.SetResourceReference(RibbonBorder.BackgroundProperty, (object) new ComponentResourceKey(typeof (Ribbon), (object) (str + RibbonBarPartColorKeys.Background)));
      this.SetResourceReference(RibbonBorder.BorderBrushProperty, (object) new ComponentResourceKey(typeof (Ribbon), (object) (str + RibbonBarPartColorKeys.Border)));
      this.SetResourceReference(RibbonBorder.LightBorderBrushProperty, (object) new ComponentResourceKey(typeof (Ribbon), (object) (str + RibbonBarPartColorKeys.BorderLight)));
      this.SetResourceReference(RibbonBorder.TopHighlightProperty, (object) new ComponentResourceKey(typeof (Ribbon), (object) (str + RibbonBarPartColorKeys.TopHighlight)));
      if (this.AnimationEnabled && this.BorderState == eRibbonBarRenderingState.Hover)
      {
        RibbonBorder.RenderOverlayBrushes renderOverlayBrushes = this.GetRenderOverlayBrushes();
        if (renderOverlayBrushes == null)
          return;
        DoubleAnimation animation1 = new DoubleAnimation(0.3, 1.0, new Duration(TimeSpan.FromSeconds(0.4)));
        renderOverlayBrushes.BeginAnimation(animation1);
      }
      else if (this.AnimationEnabled && this.BorderState == eRibbonBarRenderingState.Normal)
      {
        RibbonBorder.RenderOverlayBrushes renderOverlayBrushes = this.GetRenderOverlayBrushes();
        if (renderOverlayBrushes == null)
          return;
        DoubleAnimation animation1 = new DoubleAnimation(1.0, 0.0, new Duration(TimeSpan.FromSeconds(0.4)));
        animation1.Completed += new EventHandler(this.AnimationCompleted);
        renderOverlayBrushes.BeginAnimation(animation1);
      }
      else
        this.InvalidateVisual();
    }
  }

  private void AnimationCompleted(object sender, EventArgs e)
  {
    if (this.BorderState != eRibbonBarRenderingState.Normal)
      return;
    this.DestroyRendererOverlayBrushes();
  }

  protected override Size MeasureOverride(Size constraint)
  {
    UIElement child = this.Child;
    Size thicknessSize1 = LayoutHelpers.GetThicknessSize(this.BorderThickness);
    Size thicknessSize2 = LayoutHelpers.GetThicknessSize(this.LightBorderThickness);
    thicknessSize1.Height += thicknessSize2.Height;
    thicknessSize1.Width += thicknessSize2.Width;
    Size thicknessSize3 = LayoutHelpers.GetThicknessSize(this.Padding);
    if (child == null)
      return new Size(thicknessSize1.Width + thicknessSize3.Width, thicknessSize1.Height + thicknessSize3.Height);
    Size size = new Size(thicknessSize1.Width + thicknessSize3.Width, thicknessSize1.Height + thicknessSize3.Height);
    Size availableSize = new Size(Math.Max(0.0, constraint.Width - size.Width), Math.Max(0.0, constraint.Height - size.Height));
    child.Measure(availableSize);
    Size desiredSize = child.DesiredSize;
    size.Width = desiredSize.Width + size.Width;
    size.Height = desiredSize.Height + size.Height;
    return size;
  }

  protected override Size ArrangeOverride(Size finalSize)
  {
    Rect r1 = new Rect(finalSize);
    Thickness borderThickness = this.BorderThickness;
    Thickness lightBorderThickness = this.LightBorderThickness;
    Rect r2 = LayoutHelpers.DeflateRect(LayoutHelpers.DeflateRect(r1, borderThickness), lightBorderThickness);
    this.Child?.Arrange(LayoutHelpers.DeflateRect(r2, this.Padding));
    this.m_BackgroundGeometry = (StreamGeometry) null;
    this.m_BorderGeometry = (StreamGeometry) null;
    this.m_BorderGeometryMouseOver = (StreamGeometry) null;
    this.m_LightBorderGeometry = (StreamGeometry) null;
    this.m_LightBorderGeometryMouseOver = (StreamGeometry) null;
    if (finalSize.IsEmpty || LayoutHelpers.IsZero(r2.Width) || LayoutHelpers.IsZero(r2.Height) || r2.IsEmpty)
      return finalSize;
    CornerRadius rad = this.CornerRadius;
    Brush borderBrush = this.BorderBrush;
    Brush lightBorderBrush = this.LightBorderBrush;
    if (!LayoutHelpers.IsZero(r2.Width) && !LayoutHelpers.IsZero(r2.Height) && !r2.IsEmpty)
    {
      Rect rect = LayoutHelpers.DeflateRect(r1, borderThickness);
      if (!LayoutHelpers.IsEmpty(rad))
      {
        this.m_BackgroundGeometry = new StreamGeometry();
        using (StreamGeometryContext ctx = this.m_BackgroundGeometry.Open())
          LayoutHelpers.CreateGeometry(ctx, rect, new LayoutHelpers.RadiusDescription(rad, borderThickness, false));
        this.m_BackgroundGeometry.Freeze();
      }
    }
    else
      this.m_BackgroundGeometry = (StreamGeometry) null;
    if (!LayoutHelpers.IsEmpty(rad) && !LayoutHelpers.IsZero(r1.Width) && !LayoutHelpers.IsZero(r1.Height) && !r1.IsEmpty && !LayoutHelpers.IsEmpty(borderThickness))
    {
      this.m_BorderGeometryMouseOver = new StreamGeometry();
      Rect rect1 = r1;
      using (StreamGeometryContext ctx = this.m_BorderGeometryMouseOver.Open())
      {
        LayoutHelpers.CreateGeometry(ctx, rect1, new LayoutHelpers.RadiusDescription(rad, borderThickness, true));
        rect1 = LayoutHelpers.DeflateRect(rect1, borderThickness);
        LayoutHelpers.CreateGeometry(ctx, rect1, new LayoutHelpers.RadiusDescription(rad, borderThickness, true));
      }
      this.m_BorderGeometryMouseOver.Freeze();
      if (!LayoutHelpers.IsEmpty(lightBorderThickness))
      {
        this.m_LightBorderGeometryMouseOver = new StreamGeometry();
        using (StreamGeometryContext ctx = this.m_LightBorderGeometryMouseOver.Open())
        {
          LayoutHelpers.CreateGeometry(ctx, rect1, new LayoutHelpers.RadiusDescription(rad, lightBorderThickness, false));
          Rect rect2 = LayoutHelpers.DeflateRect(rect1, lightBorderThickness);
          LayoutHelpers.CreateGeometry(ctx, rect2, new LayoutHelpers.RadiusDescription(rad, lightBorderThickness, true));
        }
        this.m_LightBorderGeometryMouseOver.Freeze();
      }
      --r1.Width;
      --r1.Height;
      Rect rect3 = r1;
      this.m_BorderGeometry = new StreamGeometry();
      using (StreamGeometryContext ctx = this.m_BorderGeometry.Open())
      {
        LayoutHelpers.CreateGeometry(ctx, rect3, new LayoutHelpers.RadiusDescription(rad, borderThickness, true));
        Rect rect4 = LayoutHelpers.DeflateRect(rect3, borderThickness);
        LayoutHelpers.CreateGeometry(ctx, rect4, new LayoutHelpers.RadiusDescription(rad, borderThickness, true));
      }
      this.m_BorderGeometry.Freeze();
      if (!LayoutHelpers.IsEmpty(lightBorderThickness))
      {
        Rect rect5 = r1;
        if (this.InnerBorder)
        {
          rect5.Inflate(-1.0, -1.0);
        }
        else
        {
          ++rect5.X;
          ++rect5.Y;
        }
        this.m_LightBorderGeometry = new StreamGeometry();
        rad = new CornerRadius(rad.TopLeft, rad.TopRight + 1.0, rad.BottomRight, rad.BottomLeft + 2.0);
        using (StreamGeometryContext ctx = this.m_LightBorderGeometry.Open())
        {
          LayoutHelpers.CreateGeometry(ctx, rect5, new LayoutHelpers.RadiusDescription(rad, lightBorderThickness, false));
          rect5 = LayoutHelpers.DeflateRect(rect5, lightBorderThickness);
          LayoutHelpers.CreateGeometry(ctx, rect5, new LayoutHelpers.RadiusDescription(rad, lightBorderThickness, true));
        }
        this.m_LightBorderGeometry.Freeze();
      }
    }
    return finalSize;
  }

  protected override void OnRender(DrawingContext dc)
  {
    RibbonBorder.RenderOverlayBrushes renderOverlayBrushes = this.GetRenderOverlayBrushes();
    if (this.m_BackgroundGeometry != null)
    {
      Brush background1 = this.Background;
      if (background1 != null)
        dc.DrawGeometry(background1, (Pen) null, (Geometry) this.m_BackgroundGeometry);
      if (renderOverlayBrushes != null && renderOverlayBrushes.Background != null)
      {
        Brush background2 = renderOverlayBrushes.Background;
        dc.DrawGeometry(background2, (Pen) null, (Geometry) this.m_BackgroundGeometry);
      }
      Brush topHighlight1 = this.TopHighlight;
      if (topHighlight1 != null)
      {
        double height = 15.0;
        if (this.IsRibbonPanel)
          height += this.Padding.Top + 2.0;
        dc.PushClip((Geometry) this.m_BackgroundGeometry);
        DrawingContext drawingContext1 = dc;
        Brush brush1 = topHighlight1;
        Size renderSize = this.RenderSize;
        Rect rectangle1 = new Rect(0.0, 0.0, renderSize.Width, height);
        drawingContext1.DrawRectangle(brush1, (Pen) null, rectangle1);
        if (renderOverlayBrushes != null && renderOverlayBrushes.TopHighlight != null)
        {
          Brush topHighlight2 = renderOverlayBrushes.TopHighlight;
          DrawingContext drawingContext2 = dc;
          Brush brush2 = topHighlight2;
          renderSize = this.RenderSize;
          Rect rectangle2 = new Rect(0.0, 0.0, renderSize.Width, height);
          drawingContext2.DrawRectangle(brush2, (Pen) null, rectangle2);
        }
        dc.Pop();
      }
    }
    else
    {
      Rect rectangle = new Rect(this.RenderSize);
      Brush background = this.Background;
      if (background != null)
        dc.DrawRectangle(background, (Pen) null, rectangle);
      Brush topHighlight3 = this.TopHighlight;
      if (topHighlight3 != null)
      {
        double height = 15.0;
        if (this.IsRibbonPanel)
          height += this.Padding.Top + 2.0;
        dc.DrawRectangle(topHighlight3, (Pen) null, new Rect(0.0, 0.0, this.RenderSize.Width, height));
        if (renderOverlayBrushes != null && renderOverlayBrushes.TopHighlight != null)
        {
          Brush topHighlight4 = renderOverlayBrushes.TopHighlight;
          dc.DrawRectangle(topHighlight4, (Pen) null, new Rect(0.0, 0.0, this.RenderSize.Width, height));
        }
      }
    }
    bool flag = false;
    if (!LayoutHelpers.IsEmpty(this.m_SelectedTabRect))
    {
      CombinedGeometry clipGeometry = new CombinedGeometry(GeometryCombineMode.Exclude, (Geometry) new RectangleGeometry(new Rect(this.RenderSize)), (Geometry) new RectangleGeometry(new Rect(this.m_SelectedTabRect.X, 0.0, this.m_SelectedTabRect.Width - 1.0, 1.0)));
      dc.PushClip((Geometry) clipGeometry);
      flag = true;
    }
    if (this.m_LightBorderGeometry != null)
    {
      Brush lightBorderBrush = this.LightBorderBrush;
      if (lightBorderBrush != null)
        dc.DrawGeometry(lightBorderBrush, (Pen) null, (Geometry) this.m_LightBorderGeometry);
    }
    else
    {
      Rect borderBounds = new Rect(this.RenderSize);
      borderBounds.Offset(0.5, 0.0);
      DrawingHelpers.DrawBorder(dc, this.LightBorderThickness, this.LightBorderBrush, borderBounds);
    }
    if (this.m_BorderGeometry != null)
    {
      Brush borderBrush = this.BorderBrush;
      if (borderBrush != null)
        dc.DrawGeometry(borderBrush, (Pen) null, (Geometry) this.m_BorderGeometry);
    }
    else
    {
      Rect borderBounds = new Rect(this.RenderSize);
      DrawingHelpers.DrawBorder(dc, this.BorderThickness, this.BorderBrush, borderBounds);
    }
    if (renderOverlayBrushes != null && renderOverlayBrushes.LightBorderBrush != null && renderOverlayBrushes.LightBorderBrush.Opacity > 0.0 && this.m_LightBorderGeometryMouseOver != null)
    {
      Brush lightBorderBrush = renderOverlayBrushes.LightBorderBrush;
      dc.DrawGeometry(lightBorderBrush, (Pen) null, (Geometry) this.m_LightBorderGeometryMouseOver);
    }
    if (renderOverlayBrushes != null && renderOverlayBrushes.BorderBrush != null && renderOverlayBrushes.BorderBrush.Opacity > 0.0 && this.m_BorderGeometryMouseOver != null)
    {
      Brush borderBrush = renderOverlayBrushes.BorderBrush;
      dc.DrawGeometry(borderBrush, (Pen) null, (Geometry) this.m_BorderGeometryMouseOver);
    }
    if (flag)
      dc.Pop();
    if (LayoutHelpers.IsEmpty(this.m_SelectedTabRect) || this.Background == null)
      return;
    Brush brush = this.Background;
    if (brush is LinearGradientBrush && ((GradientBrush) brush).GradientStops.Count > 0)
      brush = (Brush) new SolidColorBrush(((GradientBrush) brush).GradientStops[0].Color);
    dc.DrawRectangle(brush, (Pen) null, new Rect(this.m_SelectedTabRect.X, 0.0, this.m_SelectedTabRect.Width, 1.0));
  }

  private static bool IsCornerRadiusValid(object value)
  {
    CornerRadius cornerRadius = (CornerRadius) value;
    return cornerRadius.BottomLeft >= 0.0 && cornerRadius.BottomRight >= 0.0 && cornerRadius.TopLeft >= 0.0 && cornerRadius.TopRight >= 0.0;
  }

  private bool AnimationEnabled
  {
    get
    {
      return SystemParameters.PowerLineStatus == PowerLineStatus.Online && SystemParameters.ClientAreaAnimation && RenderCapability.Tier > 0 && this.IsEnabled && this.AutoAnimation;
    }
  }

  private RibbonBorder.RenderOverlayBrushes GetRenderOverlayBrushes()
  {
    return !this.IsEnabled || !this.AnimationEnabled ? (RibbonBorder.RenderOverlayBrushes) null : this.m_RenderBrushes;
  }

  private void DestroyRendererOverlayBrushes()
  {
    lock (this.m_ResourceAccessLock)
      this.m_RenderBrushes = (RibbonBorder.RenderOverlayBrushes) null;
  }

  private void CreateRendererOverlayBrushes(eRibbonBarRenderingState renderingState)
  {
    lock (this.m_ResourceAccessLock)
    {
      this.m_RenderBrushes = new RibbonBorder.RenderOverlayBrushes();
      string colorClass = this.ColorClass;
      if (!(colorClass != ""))
        return;
      string str = colorClass + this.GetStateKey(renderingState);
      if (this.TryFindResource((object) new ComponentResourceKey(typeof (Ribbon), (object) (str + RibbonBarPartColorKeys.Background))) is Brush resource1)
        this.m_RenderBrushes.Background = resource1.Clone();
      if (this.TryFindResource((object) new ComponentResourceKey(typeof (Ribbon), (object) (str + RibbonBarPartColorKeys.Border))) is Brush resource2)
        this.m_RenderBrushes.BorderBrush = resource2.Clone();
      if (this.TryFindResource((object) new ComponentResourceKey(typeof (Ribbon), (object) (str + RibbonBarPartColorKeys.BorderLight))) is Brush resource3)
        this.m_RenderBrushes.LightBorderBrush = resource3.Clone();
      if (!(this.TryFindResource((object) new ComponentResourceKey(typeof (Ribbon), (object) (str + RibbonBarPartColorKeys.TopHighlight))) is Brush resource4))
        return;
      this.m_RenderBrushes.TopHighlight = resource4.Clone();
    }
  }

  private string GetStateKey(eRibbonBarRenderingState renderingState)
  {
    return renderingState == eRibbonBarRenderingState.Normal || renderingState != eRibbonBarRenderingState.Hover ? RibbonBarStateColorKeys.Normal : RibbonBarStateColorKeys.Hover;
  }

  private class RenderOverlayBrushes
  {
    public Brush Background;
    public Brush TopHighlight;
    public Brush BorderBrush;
    public Brush LightBorderBrush;

    internal void BeginAnimation(DoubleAnimation animation1)
    {
      if (this.Background != null)
        this.Background.BeginAnimation(Brush.OpacityProperty, (AnimationTimeline) animation1);
      if (this.BorderBrush != null)
        this.BorderBrush.BeginAnimation(Brush.OpacityProperty, (AnimationTimeline) animation1);
      if (this.LightBorderBrush != null)
        this.LightBorderBrush.BeginAnimation(Brush.OpacityProperty, (AnimationTimeline) animation1);
      if (this.TopHighlight == null)
        return;
      this.TopHighlight.BeginAnimation(Brush.OpacityProperty, (AnimationTimeline) animation1);
    }
  }
}
