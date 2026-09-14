// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.ButtonBorder
// Assembly: AcpWpfRibbon, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 45A745B5-88C3-40EE-B1E5-8DBA2EACD529
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfRibbon.dll

using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Media.Animation;

#nullable disable
namespace DevComponents.WpfRibbon;

[DesignTimeVisible(false)]
public class ButtonBorder : Decorator
{
  public static readonly DependencyProperty InactiveOverlayBrushProperty = DependencyProperty.Register(nameof (InactiveOverlayBrush), typeof (Brush), typeof (ButtonBorder), (PropertyMetadata) new UIPropertyMetadata((PropertyChangedCallback) null));
  public static readonly DependencyProperty BackgroundProperty;
  public static readonly DependencyProperty TopHighlightProperty;
  public static readonly DependencyProperty BottomHighlightProperty;
  public static readonly DependencyProperty BorderBrushProperty;
  public static readonly DependencyProperty BorderThicknessProperty = DependencyProperty.Register(nameof (BorderThickness), typeof (Thickness), typeof (ButtonBorder), (PropertyMetadata) new FrameworkPropertyMetadata((object) new Thickness(), FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender), new ValidateValueCallback(ButtonBorder.IsThicknessValid));
  public static readonly DependencyProperty LightBorderBrushProperty;
  public static readonly DependencyProperty PaddingProperty = DependencyProperty.Register(nameof (Padding), typeof (Thickness), typeof (ButtonBorder), (PropertyMetadata) new FrameworkPropertyMetadata((object) new Thickness(), FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender), new ValidateValueCallback(ButtonBorder.IsThicknessValid));
  public static readonly DependencyProperty CornerRadiusProperty;
  public static readonly DependencyProperty ButtonStateProperty;
  public static readonly DependencyProperty ColorClassProperty;
  public static readonly DependencyProperty RenderBorderProperty;
  private StreamGeometry m_BackgroundGeometry;
  private StreamGeometry m_BorderGeometry;
  private StreamGeometry m_LightBorderGeometry;
  private ButtonBorder.RenderOverlayBrushes m_RenderBrushes;
  private const double FadeDuration = 0.08;
  private Rect m_ExpandBounds = Rect.Empty;
  private StreamGeometry m_ExpandGeometry;
  private bool m_Animation = true;
  private Rect m_MouseOverInactiveRect = Rect.Empty;
  private object m_ResourceAccessLock = new object();

  public Brush InactiveOverlayBrush
  {
    get => (Brush) this.GetValue(ButtonBorder.InactiveOverlayBrushProperty);
    set => this.SetValue(ButtonBorder.InactiveOverlayBrushProperty, (object) value);
  }

  static ButtonBorder()
  {
    ButtonBorder.BorderBrushProperty = DependencyProperty.Register(nameof (BorderBrush), typeof (Brush), typeof (ButtonBorder), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.SubPropertiesDoNotAffectRender));
    ButtonBorder.BackgroundProperty = Panel.BackgroundProperty.AddOwner(typeof (ButtonBorder), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.SubPropertiesDoNotAffectRender));
    ButtonBorder.LightBorderBrushProperty = DependencyProperty.Register(nameof (LightBorderBrush), typeof (Brush), typeof (ButtonBorder), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.SubPropertiesDoNotAffectRender));
    ButtonBorder.TopHighlightProperty = DependencyProperty.Register(nameof (TopHighlight), typeof (Brush), typeof (ButtonBorder), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.SubPropertiesDoNotAffectRender));
    ButtonBorder.BottomHighlightProperty = DependencyProperty.Register(nameof (BottomHighlight), typeof (Brush), typeof (ButtonBorder), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.SubPropertiesDoNotAffectRender));
    ButtonBorder.CornerRadiusProperty = DependencyProperty.Register(nameof (CornerRadius), typeof (CornerRadius), typeof (ButtonBorder), (PropertyMetadata) new FrameworkPropertyMetadata((object) new CornerRadius(0.0), FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.SubPropertiesDoNotAffectRender), new ValidateValueCallback(ButtonBorder.IsCornerRadiusValid));
    ButtonBorder.ButtonStateProperty = DependencyProperty.Register(nameof (ButtonState), typeof (eButtonRenderingState), typeof (ButtonBorder), (PropertyMetadata) new FrameworkPropertyMetadata((object) eButtonRenderingState.Normal, FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(ButtonBorder.OnButtonStateChanged)));
    ButtonBorder.ColorClassProperty = DependencyProperty.Register(nameof (ColorClass), typeof (string), typeof (ButtonBorder), (PropertyMetadata) new FrameworkPropertyMetadata((object) RibbonColors.ButtonClass, FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(ButtonBorder.OnButtonClassChanged)));
    ButtonBorder.RenderBorderProperty = DependencyProperty.Register(nameof (RenderBorder), typeof (bool), typeof (ButtonBorder), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender));
  }

  public ButtonBorder()
  {
    this.SetResourceReference(ButtonBorder.InactiveOverlayBrushProperty, (object) new ComponentResourceKey(typeof (Ribbon), (object) RibbonColors.ButtonInactiveOverlay));
  }

  [DefaultValue(true)]
  [Browsable(true)]
  [Description("Indicates whether border is rendered.")]
  public bool RenderBorder
  {
    get => (bool) this.GetValue(ButtonBorder.RenderBorderProperty);
    set => this.SetValue(ButtonBorder.RenderBorderProperty, (object) value);
  }

  [DefaultValue("Button")]
  public string ColorClass
  {
    get => (string) this.GetValue(ButtonBorder.ColorClassProperty);
    set => this.SetValue(ButtonBorder.ColorClassProperty, (object) value);
  }

  [TypeConverter(typeof (CornerRadiusConverter))]
  public CornerRadius CornerRadius
  {
    get => (CornerRadius) this.GetValue(ButtonBorder.CornerRadiusProperty);
    set => this.SetValue(ButtonBorder.CornerRadiusProperty, (object) value);
  }

  [DefaultValue(eButtonRenderingState.Normal)]
  public eButtonRenderingState ButtonState
  {
    get => (eButtonRenderingState) this.GetValue(ButtonBorder.ButtonStateProperty);
    set => this.SetValue(ButtonBorder.ButtonStateProperty, (object) value);
  }

  [DefaultValue(null)]
  public Brush Background
  {
    get => (Brush) this.GetValue(ButtonBorder.BackgroundProperty);
    set => this.SetValue(ButtonBorder.BackgroundProperty, (object) value);
  }

  [DefaultValue(null)]
  public Brush TopHighlight
  {
    get => (Brush) this.GetValue(ButtonBorder.TopHighlightProperty);
    set => this.SetValue(ButtonBorder.TopHighlightProperty, (object) value);
  }

  [DefaultValue(null)]
  public Brush BottomHighlight
  {
    get => (Brush) this.GetValue(ButtonBorder.BottomHighlightProperty);
    set => this.SetValue(ButtonBorder.BottomHighlightProperty, (object) value);
  }

  [DefaultValue(null)]
  public Brush BorderBrush
  {
    get => (Brush) this.GetValue(ButtonBorder.BorderBrushProperty);
    set => this.SetValue(ButtonBorder.BorderBrushProperty, (object) value);
  }

  [DefaultValue(null)]
  public Brush LightBorderBrush
  {
    get => (Brush) this.GetValue(ButtonBorder.LightBorderBrushProperty);
    set => this.SetValue(ButtonBorder.LightBorderBrushProperty, (object) value);
  }

  public Thickness BorderThickness
  {
    get => (Thickness) this.GetValue(ButtonBorder.BorderThicknessProperty);
    set => this.SetValue(ButtonBorder.BorderThicknessProperty, (object) value);
  }

  public Thickness Padding
  {
    get => (Thickness) this.GetValue(ButtonBorder.PaddingProperty);
    set => this.SetValue(ButtonBorder.PaddingProperty, (object) value);
  }

  internal Rect ExpandBounds
  {
    get => this.m_ExpandBounds;
    set
    {
      this.m_ExpandBounds = value;
      Rect rect = new Rect(this.RenderSize);
      Rect layoutSlot = LayoutInformation.GetLayoutSlot((FrameworkElement) this);
      this.m_ExpandGeometry = (StreamGeometry) null;
      if (this.m_ExpandBounds.Right >= layoutSlot.Right && LayoutHelpers.IsClose(this.m_ExpandBounds.Y, layoutSlot.Y) && this.m_ExpandBounds.Bottom >= layoutSlot.Bottom)
      {
        this.m_ExpandGeometry = new StreamGeometry();
        using (StreamGeometryContext streamGeometryContext = this.m_ExpandGeometry.Open())
        {
          streamGeometryContext.BeginFigure(new System.Windows.Point(this.m_ExpandBounds.X - 1.0, this.m_ExpandBounds.Y), true, true);
          streamGeometryContext.LineTo(new System.Windows.Point(this.m_ExpandBounds.X - 1.0, this.m_ExpandBounds.Bottom), false, false);
          streamGeometryContext.LineTo(new System.Windows.Point(this.m_ExpandBounds.X, this.m_ExpandBounds.Bottom), false, false);
          streamGeometryContext.LineTo(new System.Windows.Point(this.m_ExpandBounds.X, this.m_ExpandBounds.Y), false, false);
        }
        this.m_ExpandGeometry.Freeze();
      }
      else if (LayoutHelpers.IsClose(this.m_ExpandBounds.X, layoutSlot.X) && LayoutHelpers.IsClose(this.m_ExpandBounds.Y, layoutSlot.Y) && this.m_ExpandBounds.Bottom >= layoutSlot.Bottom)
      {
        this.m_ExpandGeometry = new StreamGeometry();
        using (StreamGeometryContext streamGeometryContext = this.m_ExpandGeometry.Open())
        {
          streamGeometryContext.BeginFigure(new System.Windows.Point(this.m_ExpandBounds.Right - 1.0, this.m_ExpandBounds.Y), true, true);
          streamGeometryContext.LineTo(new System.Windows.Point(this.m_ExpandBounds.Right - 1.0, this.m_ExpandBounds.Bottom), false, false);
          streamGeometryContext.LineTo(new System.Windows.Point(this.m_ExpandBounds.Right, this.m_ExpandBounds.Bottom), false, false);
          streamGeometryContext.LineTo(new System.Windows.Point(this.m_ExpandBounds.Right, this.m_ExpandBounds.Y), false, false);
        }
        this.m_ExpandGeometry.Freeze();
      }
      else if (LayoutHelpers.IsClose(this.m_ExpandBounds.X, layoutSlot.X) && this.m_ExpandBounds.Bottom >= layoutSlot.Bottom && this.m_ExpandBounds.Right >= layoutSlot.Right)
      {
        this.m_ExpandGeometry = new StreamGeometry();
        using (StreamGeometryContext streamGeometryContext = this.m_ExpandGeometry.Open())
        {
          streamGeometryContext.BeginFigure(new System.Windows.Point(layoutSlot.X, this.m_ExpandBounds.Y - 1.0), true, true);
          streamGeometryContext.LineTo(new System.Windows.Point(layoutSlot.Right, this.m_ExpandBounds.Y - 1.0), false, false);
          streamGeometryContext.LineTo(new System.Windows.Point(layoutSlot.Right, this.m_ExpandBounds.Y), false, false);
          streamGeometryContext.LineTo(new System.Windows.Point(layoutSlot.X, this.m_ExpandBounds.Y), false, false);
        }
        this.m_ExpandGeometry.Freeze();
      }
      else
      {
        if (!LayoutHelpers.IsClose(this.m_ExpandBounds.X, layoutSlot.X) || !LayoutHelpers.IsClose(this.m_ExpandBounds.Y, layoutSlot.Y) || this.m_ExpandBounds.Right < layoutSlot.Right)
          return;
        this.m_ExpandGeometry = new StreamGeometry();
        using (StreamGeometryContext streamGeometryContext = this.m_ExpandGeometry.Open())
        {
          streamGeometryContext.BeginFigure(new System.Windows.Point(this.m_ExpandBounds.X, this.m_ExpandBounds.Bottom - 1.0), true, true);
          streamGeometryContext.LineTo(new System.Windows.Point(this.m_ExpandBounds.Right, this.m_ExpandBounds.Bottom - 1.0), false, false);
          streamGeometryContext.LineTo(new System.Windows.Point(this.m_ExpandBounds.Right, this.m_ExpandBounds.Bottom), false, false);
          streamGeometryContext.LineTo(new System.Windows.Point(this.m_ExpandBounds.X, this.m_ExpandBounds.Bottom), false, false);
        }
        this.m_ExpandGeometry.Freeze();
      }
    }
  }

  private static void OnButtonClassChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
  {
    ((ButtonBorder) d).UpdateVisualState();
  }

  private static void OnButtonStateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
  {
    ButtonBorder buttonBorder = (ButtonBorder) d;
    buttonBorder.UpdateOverlay((eButtonRenderingState) e.OldValue, (eButtonRenderingState) e.NewValue);
    buttonBorder.UpdateVisualState();
  }

  private void UpdateOverlay(eButtonRenderingState oldState, eButtonRenderingState newState)
  {
    if (newState == eButtonRenderingState.Hover || oldState == eButtonRenderingState.Hover && newState == eButtonRenderingState.Normal)
      this.CreateRendererOverlayBrushes(eButtonRenderingState.Hover);
    else if (newState == eButtonRenderingState.CheckedHover || oldState == eButtonRenderingState.CheckedHover && newState == eButtonRenderingState.Checked)
      this.CreateRendererOverlayBrushes(eButtonRenderingState.CheckedHover);
    else
      this.DestroyRendererOverlayBrushes();
  }

  private void UpdateVisualState()
  {
    string colorClass = this.ColorClass;
    if (colorClass == "")
    {
      this.Background = (Brush) null;
      this.TopHighlight = (Brush) null;
      this.BorderBrush = (Brush) null;
      this.LightBorderBrush = (Brush) null;
      this.BottomHighlight = (Brush) null;
      this.InvalidateVisual();
    }
    else
    {
      eButtonRenderingState renderingState = this.ButtonState;
      if (this.AnimationEnabled)
      {
        switch (renderingState)
        {
          case eButtonRenderingState.Hover:
            renderingState = eButtonRenderingState.Normal;
            break;
          case eButtonRenderingState.CheckedHover:
            renderingState = eButtonRenderingState.Checked;
            break;
        }
      }
      string str = !colorClass.EndsWith("WithBackground") || renderingState == eButtonRenderingState.Normal || renderingState == eButtonRenderingState.Disabled ? colorClass + this.GetStateKey(renderingState) : colorClass.Substring(0, colorClass.Length - 14) + this.GetStateKey(renderingState);
      Type targetType = this.GetTargetType();
      this.SetResourceReference(ButtonBorder.BackgroundProperty, (object) new ComponentResourceKey(targetType, (object) (str + ButtonPartColorKeys.Background)));
      this.SetResourceReference(ButtonBorder.TopHighlightProperty, (object) new ComponentResourceKey(targetType, (object) (str + ButtonPartColorKeys.TopHighlight)));
      this.SetResourceReference(ButtonBorder.BottomHighlightProperty, (object) new ComponentResourceKey(targetType, (object) (str + ButtonPartColorKeys.BottomHighlight)));
      this.SetResourceReference(ButtonBorder.BorderBrushProperty, (object) new ComponentResourceKey(targetType, (object) (str + ButtonPartColorKeys.Border)));
      this.SetResourceReference(ButtonBorder.LightBorderBrushProperty, (object) new ComponentResourceKey(targetType, (object) (str + ButtonPartColorKeys.BorderLight)));
      if (this.AnimationEnabled && (this.ButtonState == eButtonRenderingState.Hover || this.ButtonState == eButtonRenderingState.CheckedHover))
      {
        ButtonBorder.RenderOverlayBrushes renderOverlayBrushes = this.GetRenderOverlayBrushes();
        if (renderOverlayBrushes == null)
          return;
        DoubleAnimation animation1 = new DoubleAnimation(0.3, 1.0, new Duration(TimeSpan.FromSeconds(0.08)));
        renderOverlayBrushes.BeginAnimation(animation1);
      }
      else if (this.AnimationEnabled && (this.ButtonState == eButtonRenderingState.Normal || this.ButtonState == eButtonRenderingState.Checked))
      {
        ButtonBorder.RenderOverlayBrushes renderOverlayBrushes = this.GetRenderOverlayBrushes();
        if (renderOverlayBrushes == null)
          return;
        DoubleAnimation animation1 = new DoubleAnimation(1.0, 0.0, new Duration(TimeSpan.FromSeconds(0.08)));
        animation1.Completed += new EventHandler(this.OverlayAnimationCompleted);
        renderOverlayBrushes.LightBorderPen = (Pen) null;
        renderOverlayBrushes.BeginAnimation(animation1);
      }
      else
        this.InvalidateVisual();
    }
  }

  private Type GetTargetType() => typeof (Ribbon);

  private void OverlayAnimationCompleted(object sender, EventArgs e)
  {
    if (this.ButtonState != eButtonRenderingState.Normal && this.ButtonState != eButtonRenderingState.Checked)
      return;
    this.DestroyRendererOverlayBrushes();
  }

  private string GetStateKey(eButtonRenderingState renderingState)
  {
    switch (renderingState)
    {
      case eButtonRenderingState.Normal:
        return ButtonStateColorKeys.Normal;
      case eButtonRenderingState.Hover:
        return ButtonStateColorKeys.Hover;
      case eButtonRenderingState.Pressed:
        return ButtonStateColorKeys.Pressed;
      case eButtonRenderingState.Checked:
        return ButtonStateColorKeys.Checked;
      case eButtonRenderingState.CheckedHover:
        return ButtonStateColorKeys.CheckedHover;
      case eButtonRenderingState.Disabled:
        return ButtonStateColorKeys.Disabled;
      case eButtonRenderingState.Expanded:
        return ButtonStateColorKeys.Expanded;
      default:
        return ButtonStateColorKeys.Normal;
    }
  }

  private static bool IsThicknessValid(object value) => LayoutHelpers.IsThicknessValid(value);

  protected override Size MeasureOverride(Size constraint)
  {
    UIElement child = this.Child;
    Size size1 = new Size(2.0, 2.0);
    if (this.RenderBorder)
    {
      size1 = LayoutHelpers.GetThicknessSize(this.BorderThickness);
      size1.Height += 2.0;
      size1.Width += 2.0;
    }
    Size thicknessSize = LayoutHelpers.GetThicknessSize(this.Padding);
    if (child == null)
      return new Size(size1.Width + thicknessSize.Width, size1.Height + thicknessSize.Height);
    Size size2 = new Size(size1.Width + thicknessSize.Width, size1.Height + thicknessSize.Height);
    child.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
    Size desiredSize = child.DesiredSize;
    size2.Width = Math.Ceiling(desiredSize.Width + size2.Width);
    size2.Height = Math.Ceiling(desiredSize.Height + size2.Height);
    return size2;
  }

  protected override HitTestResult HitTestCore(PointHitTestParameters hitTestParameters)
  {
    HitTestResult hitTestResult = base.HitTestCore(hitTestParameters);
    if (hitTestResult == null || hitTestResult.VisualHit == null)
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

  protected override Size ArrangeOverride(Size finalSize)
  {
    Thickness borderThickness = this.BorderThickness;
    Rect rect1 = new Rect(finalSize);
    Rect r = LayoutHelpers.DeflateRect(rect1, borderThickness);
    if (this.RenderBorder)
      r.Inflate(-1.0, -1.0);
    this.m_BackgroundGeometry = (StreamGeometry) null;
    UIElement child = this.Child;
    if (child != null)
    {
      Rect finalRect = LayoutHelpers.DeflateRect(r, this.Padding);
      child.Arrange(finalRect);
    }
    Rect rect2 = rect1;
    if (this.RenderBorder)
      rect2.Inflate(-1.0, -1.0);
    CornerRadius cornerRadius = this.CornerRadius;
    Brush borderBrush = this.BorderBrush;
    Brush lightBorderBrush = this.LightBorderBrush;
    if (!LayoutHelpers.IsZero(rect2.Width) && !LayoutHelpers.IsZero(rect2.Height) && !rect2.IsEmpty)
    {
      this.m_BackgroundGeometry = new StreamGeometry();
      using (StreamGeometryContext ctx = this.m_BackgroundGeometry.Open())
        LayoutHelpers.CreateGeometry(ctx, rect2, new LayoutHelpers.RadiusDescription(cornerRadius, borderThickness, false));
      this.m_BackgroundGeometry.Freeze();
    }
    else
      this.m_BackgroundGeometry = (StreamGeometry) null;
    if (!LayoutHelpers.IsZero(rect1.Width) && !LayoutHelpers.IsZero(rect1.Height) && !rect1.IsEmpty)
    {
      this.m_BorderGeometry = new StreamGeometry();
      using (StreamGeometryContext ctx = this.m_BorderGeometry.Open())
      {
        LayoutHelpers.CreateGeometry(ctx, rect1, new LayoutHelpers.RadiusDescription(cornerRadius, borderThickness, true));
        rect1 = LayoutHelpers.DeflateRect(rect1, borderThickness);
        LayoutHelpers.CreateGeometry(ctx, rect1, new LayoutHelpers.RadiusDescription(cornerRadius, borderThickness, true));
      }
      this.m_BorderGeometry.Freeze();
      this.m_LightBorderGeometry = new StreamGeometry();
      using (StreamGeometryContext ctx = this.m_LightBorderGeometry.Open())
      {
        LayoutHelpers.CreateGeometry(ctx, rect1, new LayoutHelpers.RadiusDescription(cornerRadius, borderThickness, false));
        rect1.Inflate(-1.0, -1.0);
        LayoutHelpers.CreateGeometry(ctx, rect1, new LayoutHelpers.RadiusDescription(cornerRadius, borderThickness, true));
      }
      this.m_LightBorderGeometry.Freeze();
      return finalSize;
    }
    this.m_BackgroundGeometry = (StreamGeometry) null;
    this.m_BorderGeometry = (StreamGeometry) null;
    this.m_LightBorderGeometry = (StreamGeometry) null;
    return finalSize;
  }

  internal Rect MouseOverInactiveRect
  {
    get => this.m_MouseOverInactiveRect;
    set
    {
      if (!(this.m_MouseOverInactiveRect != value))
        return;
      this.m_MouseOverInactiveRect = value;
      this.InvalidateVisual();
    }
  }

  protected override void OnRender(DrawingContext dc)
  {
    ButtonBorder.RenderOverlayBrushes renderOverlayBrushes = this.GetRenderOverlayBrushes();
    float num = 0.4f;
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
      if (topHighlight1 != null || renderOverlayBrushes != null && renderOverlayBrushes.TopHighlight != null)
      {
        dc.PushClip((Geometry) new RectangleGeometry(new Rect(0.0, 0.0, this.ActualWidth, this.ActualHeight * (double) num)));
        if (topHighlight1 != null)
          dc.DrawGeometry(topHighlight1, (Pen) null, (Geometry) this.m_BackgroundGeometry);
        if (renderOverlayBrushes != null && renderOverlayBrushes.TopHighlight != null)
        {
          Brush topHighlight2 = renderOverlayBrushes.TopHighlight;
          dc.DrawGeometry(topHighlight2, (Pen) null, (Geometry) this.m_BackgroundGeometry);
        }
        dc.Pop();
      }
      Brush bottomHighlight1 = this.BottomHighlight;
      if (bottomHighlight1 != null || renderOverlayBrushes != null && renderOverlayBrushes.BottomHighlight != null)
      {
        dc.PushClip((Geometry) new RectangleGeometry(new Rect(0.0, this.ActualHeight * (double) num, this.ActualWidth, this.ActualHeight * (1.0 - (double) num))));
        if (bottomHighlight1 != null)
          dc.DrawGeometry(bottomHighlight1, (Pen) null, (Geometry) this.m_BackgroundGeometry);
        if (renderOverlayBrushes != null && renderOverlayBrushes.BottomHighlight != null)
        {
          Brush bottomHighlight2 = renderOverlayBrushes.BottomHighlight;
          dc.DrawGeometry(bottomHighlight2, (Pen) null, (Geometry) this.m_BackgroundGeometry);
        }
        dc.Pop();
      }
      if (!this.m_MouseOverInactiveRect.IsEmpty && this.InactiveOverlayBrush != null)
      {
        dc.PushClip((Geometry) this.m_BackgroundGeometry);
        dc.DrawRectangle(this.InactiveOverlayBrush, (Pen) null, this.m_MouseOverInactiveRect);
        dc.Pop();
      }
    }
    bool renderBorder = this.RenderBorder;
    if (renderBorder && this.m_LightBorderGeometry != null)
    {
      Brush lightBorderBrush1 = this.LightBorderBrush;
      if (lightBorderBrush1 != null)
        dc.DrawGeometry(lightBorderBrush1, (Pen) null, (Geometry) this.m_LightBorderGeometry);
      if (renderOverlayBrushes != null && renderOverlayBrushes.LightBorderBrush != null)
      {
        Brush lightBorderBrush2 = renderOverlayBrushes.LightBorderBrush;
        dc.DrawGeometry(lightBorderBrush2, (Pen) null, (Geometry) this.m_LightBorderGeometry);
      }
    }
    if (renderOverlayBrushes != null && renderOverlayBrushes.BorderBrush != null && renderOverlayBrushes.LightBorderPen != null && !LayoutHelpers.IsEmpty(this.m_ExpandBounds) && this.m_BackgroundGeometry != null)
    {
      dc.PushClip((Geometry) this.m_BackgroundGeometry);
      dc.DrawRectangle((Brush) null, renderOverlayBrushes.LightBorderPen, this.m_ExpandBounds);
      dc.Pop();
    }
    if (this.m_BorderGeometry == null)
      return;
    Brush borderBrush1 = this.BorderBrush;
    if (borderBrush1 != null)
    {
      if (renderBorder)
        dc.DrawGeometry(borderBrush1, (Pen) null, (Geometry) this.m_BorderGeometry);
      if (this.m_ExpandGeometry != null)
        dc.DrawGeometry(borderBrush1, (Pen) null, (Geometry) this.m_ExpandGeometry);
    }
    if (renderOverlayBrushes == null || renderOverlayBrushes.BorderBrush == null)
      return;
    Brush borderBrush2 = renderOverlayBrushes.BorderBrush;
    if (renderBorder)
      dc.DrawGeometry(borderBrush2, (Pen) null, (Geometry) this.m_BorderGeometry);
    if (this.m_ExpandGeometry == null)
      return;
    dc.DrawGeometry(borderBrush2, (Pen) null, (Geometry) this.m_ExpandGeometry);
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
      return SystemParameters.PowerLineStatus == PowerLineStatus.Online && SystemParameters.ClientAreaAnimation && RenderCapability.Tier > 0 && this.IsEnabled && this.m_Animation;
    }
  }

  internal bool Animation
  {
    get => this.m_Animation;
    set => this.m_Animation = value;
  }

  private ButtonBorder.RenderOverlayBrushes GetRenderOverlayBrushes()
  {
    return !this.IsEnabled || !this.AnimationEnabled ? (ButtonBorder.RenderOverlayBrushes) null : this.m_RenderBrushes;
  }

  private void DestroyRendererOverlayBrushes()
  {
    lock (this.m_ResourceAccessLock)
      this.m_RenderBrushes = (ButtonBorder.RenderOverlayBrushes) null;
  }

  private void CreateRendererOverlayBrushes(eButtonRenderingState renderingState)
  {
    lock (this.m_ResourceAccessLock)
    {
      this.m_RenderBrushes = new ButtonBorder.RenderOverlayBrushes();
      string colorClass = this.ColorClass;
      if (!(colorClass != ""))
        return;
      Type targetType = this.GetTargetType();
      string str = colorClass + this.GetStateKey(renderingState);
      if (colorClass.EndsWith("WithBackground"))
        str = colorClass.Substring(0, colorClass.Length - 14) + this.GetStateKey(renderingState);
      if (this.TryFindResource((object) new ComponentResourceKey(targetType, (object) (str + ButtonPartColorKeys.Background))) is Brush resource1)
        this.m_RenderBrushes.Background = resource1.Clone();
      if (this.TryFindResource((object) new ComponentResourceKey(targetType, (object) (str + ButtonPartColorKeys.TopHighlight))) is Brush resource2)
        this.m_RenderBrushes.TopHighlight = resource2.Clone();
      if (this.TryFindResource((object) new ComponentResourceKey(targetType, (object) (str + ButtonPartColorKeys.BottomHighlight))) is Brush resource3)
        this.m_RenderBrushes.BottomHighlight = resource3.Clone();
      if (this.TryFindResource((object) new ComponentResourceKey(targetType, (object) (str + ButtonPartColorKeys.Border))) is Brush resource4)
        this.m_RenderBrushes.BorderBrush = resource4.Clone();
      if (!(this.TryFindResource((object) new ComponentResourceKey(targetType, (object) (str + ButtonPartColorKeys.BorderLight))) is Brush resource5))
        return;
      this.m_RenderBrushes.LightBorderBrush = resource5.Clone();
      this.m_RenderBrushes.LightBorderPen = new Pen(resource5, 1.0);
    }
  }

  private class RenderOverlayBrushes
  {
    public Brush Background;
    public Brush TopHighlight;
    public Brush BottomHighlight;
    public Brush BorderBrush;
    public Brush LightBorderBrush;
    public Pen LightBorderPen;

    internal void BeginAnimation(DoubleAnimation animation1)
    {
      if (this.Background != null)
        this.Background.BeginAnimation(Brush.OpacityProperty, (AnimationTimeline) animation1);
      if (this.TopHighlight != null)
        this.TopHighlight.BeginAnimation(Brush.OpacityProperty, (AnimationTimeline) animation1);
      if (this.BottomHighlight != null)
        this.BottomHighlight.BeginAnimation(Brush.OpacityProperty, (AnimationTimeline) animation1);
      if (this.BorderBrush != null)
        this.BorderBrush.BeginAnimation(Brush.OpacityProperty, (AnimationTimeline) animation1);
      if (this.LightBorderBrush == null)
        return;
      this.LightBorderBrush.BeginAnimation(Brush.OpacityProperty, (AnimationTimeline) animation1);
    }
  }
}
