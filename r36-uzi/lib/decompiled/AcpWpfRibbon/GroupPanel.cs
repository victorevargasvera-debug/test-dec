// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.GroupPanel
// Assembly: AcpWpfRibbon, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 45A745B5-88C3-40EE-B1E5-8DBA2EACD529
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfRibbon.dll

using System;
using System.Collections;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

#nullable disable
namespace DevComponents.WpfRibbon;

[DesignTimeVisible(false)]
public class GroupPanel : ButtonPanel
{
  private const int Office2010SeparationWidth = 6;
  public static readonly DependencyProperty VisualStyleProperty = Ribbon.VisualStyleProperty.AddOwner(typeof (GroupPanel), (PropertyMetadata) new FrameworkPropertyMetadata((object) eRibbonVisualStyle.Office2007Blue, FrameworkPropertyMetadataOptions.Inherits, new PropertyChangedCallback(GroupPanel.OnVisualStyleChanged)));
  private static readonly DependencyPropertyKey EffectiveStylePropertyKey = DependencyProperty.RegisterReadOnly(nameof (EffectiveStyle), typeof (eEffectiveStyle), typeof (GroupPanel), (PropertyMetadata) new UIPropertyMetadata((object) eEffectiveStyle.Office2007, new PropertyChangedCallback(GroupPanel.OnEffectiveStyleChanged)));
  public static readonly DependencyProperty EffectiveStyleProperty = GroupPanel.EffectiveStylePropertyKey.DependencyProperty;
  public static readonly DependencyProperty BorderBrushProperty;
  public static readonly DependencyProperty LightBorderBrushProperty;
  public static readonly DependencyProperty CornerRadiusProperty;
  private StreamGeometry m_BackgroundGeometry;
  private StreamGeometry m_BorderGeometry;
  private StreamGeometry m_LightBorderGeometry;
  private Pen m_DividerPen;
  private Pen m_DividerPenLight;

  public eRibbonVisualStyle VisualStyle
  {
    get => (eRibbonVisualStyle) this.GetValue(GroupPanel.VisualStyleProperty);
    set => this.SetValue(GroupPanel.VisualStyleProperty, (object) value);
  }

  private static void OnVisualStyleChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
  {
    ((GroupPanel) o).OnVisualStyleChanged((eRibbonVisualStyle) e.OldValue, (eRibbonVisualStyle) e.NewValue);
  }

  private void OnVisualStyleChanged(eRibbonVisualStyle oldValue, eRibbonVisualStyle newValue)
  {
    if (this.IsDesignMode)
      return;
    if (newValue == eRibbonVisualStyle.Office2010Silver || newValue == eRibbonVisualStyle.Office2010Blue || newValue == eRibbonVisualStyle.Office2010Black)
      this.EffectiveStyle = eEffectiveStyle.Office2010;
    else
      this.EffectiveStyle = eEffectiveStyle.Office2007;
  }

  private bool IsDesignMode => DesignerProperties.GetIsInDesignMode((DependencyObject) this);

  public eEffectiveStyle EffectiveStyle
  {
    get => (eEffectiveStyle) this.GetValue(GroupPanel.EffectiveStyleProperty);
    internal set => this.SetValue(GroupPanel.EffectiveStylePropertyKey, (object) value);
  }

  private static void OnEffectiveStyleChanged(
    DependencyObject o,
    DependencyPropertyChangedEventArgs e)
  {
    if (!(o is GroupPanel groupPanel))
      return;
    groupPanel.OnEffectiveStyleChanged((eEffectiveStyle) e.OldValue, (eEffectiveStyle) e.NewValue);
  }

  protected virtual void OnEffectiveStyleChanged(eEffectiveStyle oldValue, eEffectiveStyle newValue)
  {
    this.InvalidateMeasure();
    this.InvalidateArrange();
    this.InvalidateVisual();
  }

  static GroupPanel()
  {
    FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof (GroupPanel), (PropertyMetadata) new FrameworkPropertyMetadata((object) typeof (GroupPanel)));
    GroupPanel.BorderBrushProperty = DependencyProperty.Register(nameof (BorderBrush), typeof (Brush), typeof (GroupPanel), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.SubPropertiesDoNotAffectRender, new PropertyChangedCallback(GroupPanel.OnBorderBrushChanged)));
    GroupPanel.LightBorderBrushProperty = DependencyProperty.Register(nameof (LightBorderBrush), typeof (Brush), typeof (GroupPanel), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.SubPropertiesDoNotAffectRender, new PropertyChangedCallback(GroupPanel.OnLightBorderBrushChanged)));
    GroupPanel.CornerRadiusProperty = DependencyProperty.Register(nameof (CornerRadius), typeof (CornerRadius), typeof (GroupPanel), (PropertyMetadata) new FrameworkPropertyMetadata((object) new CornerRadius(0.0), FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.SubPropertiesDoNotAffectRender), new ValidateValueCallback(GroupPanel.IsCornerRadiusValid));
  }

  public override ButtonPanel Copy(bool deepCopy)
  {
    return (ButtonPanel) CloningMachine.Clone(this, deepCopy);
  }

  protected override void OnRender(DrawingContext dc)
  {
    Brush background = this.Background;
    if (this.m_BackgroundGeometry != null)
    {
      if (background != null)
        dc.DrawGeometry(background, (Pen) null, (Geometry) this.m_BackgroundGeometry);
    }
    else
      base.OnRender(dc);
    eEffectiveStyle effectiveStyle = this.EffectiveStyle;
    bool flag = this.Orientation == eButtonPanelOrientation.Horizontal;
    switch (effectiveStyle)
    {
      case eEffectiveStyle.Office2007:
        Brush lightBorderBrush1 = this.LightBorderBrush;
        if (this.m_LightBorderGeometry != null && lightBorderBrush1 != null)
          dc.DrawGeometry(lightBorderBrush1, (Pen) null, (Geometry) this.m_LightBorderGeometry);
        Brush borderBrush1 = this.BorderBrush;
        if (this.m_BorderGeometry != null && borderBrush1 != null)
          dc.DrawGeometry(borderBrush1, (Pen) null, (Geometry) this.m_BorderGeometry);
        if (this.m_DividerPen == null && this.m_DividerPenLight == null)
          break;
        if (flag)
        {
          IEnumerator enumerator = this.Children.GetEnumerator();
          try
          {
            while (enumerator.MoveNext())
            {
              UIElement current = (UIElement) enumerator.Current;
              if (current.Visibility == Visibility.Visible)
              {
                Rect layoutSlot = LayoutInformation.GetLayoutSlot(current as FrameworkElement);
                double x1 = Math.Round(layoutSlot.Right) + 0.5;
                dc.DrawLine(this.m_DividerPen, new Point(x1, layoutSlot.Y), new Point(x1, layoutSlot.Bottom));
                if (this.m_DividerPenLight != null)
                {
                  double x2 = x1 + 1.0;
                  dc.DrawLine(this.m_DividerPenLight, new Point(x2, layoutSlot.Y), new Point(x2, layoutSlot.Bottom));
                }
              }
            }
            break;
          }
          finally
          {
            if (enumerator is IDisposable disposable)
              disposable.Dispose();
          }
        }
        else
        {
          IEnumerator enumerator = this.Children.GetEnumerator();
          try
          {
            while (enumerator.MoveNext())
            {
              UIElement current = (UIElement) enumerator.Current;
              if (current.Visibility == Visibility.Visible)
              {
                Rect layoutSlot = LayoutInformation.GetLayoutSlot(current as FrameworkElement);
                double y1 = Math.Round(layoutSlot.Bottom) + 0.5;
                dc.DrawLine(this.m_DividerPen, new Point(layoutSlot.X, y1), new Point(layoutSlot.Right, y1));
                if (this.m_DividerPenLight != null)
                {
                  double y2 = y1 + 1.0;
                  dc.DrawLine(this.m_DividerPenLight, new Point(layoutSlot.X, y2), new Point(layoutSlot.Right, y2));
                }
              }
            }
            break;
          }
          finally
          {
            if (enumerator is IDisposable disposable)
              disposable.Dispose();
          }
        }
      case eEffectiveStyle.Office2010:
        if (!flag)
          break;
        Brush borderBrush2 = this.BorderBrush;
        Rect rect = new Rect(this.RenderSize);
        rect.Width -= 3.5;
        if (borderBrush2 != null)
        {
          Pen pen = new Pen(borderBrush2, 1.0);
          dc.DrawLine(pen, rect.TopRight, rect.BottomRight);
        }
        ++rect.X;
        Brush lightBorderBrush2 = this.LightBorderBrush;
        if (lightBorderBrush2 == null)
          break;
        Pen pen1 = new Pen(lightBorderBrush2, 1.0);
        dc.DrawLine(pen1, rect.TopRight, rect.BottomRight);
        break;
    }
  }

  protected override Size MeasureOverride(Size constraint)
  {
    Size size = base.MeasureOverride(constraint);
    if (this.EffectiveStyle == eEffectiveStyle.Office2010)
      size.Width += 6.0;
    else if (this.BorderBrush != null)
    {
      size.Width += 2.0;
      size.Height += 2.0;
    }
    return size;
  }

  protected override Size ArrangeOverride(Size finalSize)
  {
    this.m_BackgroundGeometry = (StreamGeometry) null;
    this.m_BorderGeometry = (StreamGeometry) null;
    this.m_LightBorderGeometry = (StreamGeometry) null;
    Rect rect1 = new Rect(finalSize);
    int effectiveStyle = (int) this.EffectiveStyle;
    if (effectiveStyle == 1)
      rect1.Width -= 6.0;
    else if (this.BorderBrush != null)
      rect1.Inflate(-1.0, -1.0);
    this.ArrangeInternal(rect1);
    if (effectiveStyle == 0)
    {
      Thickness thickness = new Thickness(1.0);
      Rect rect2 = new Rect(finalSize);
      CornerRadius cornerRadius = this.CornerRadius;
      Brush borderBrush = this.BorderBrush;
      Brush lightBorderBrush = this.LightBorderBrush;
      if (!LayoutHelpers.IsZero(rect1.Width) && !LayoutHelpers.IsZero(rect1.Height) && !rect1.IsEmpty)
      {
        this.m_BackgroundGeometry = new StreamGeometry();
        using (StreamGeometryContext ctx = this.m_BackgroundGeometry.Open())
          LayoutHelpers.CreateGeometry(ctx, rect1, new LayoutHelpers.RadiusDescription(cornerRadius, thickness, false));
        this.m_BackgroundGeometry.Freeze();
      }
      if (!LayoutHelpers.IsZero(rect2.Width) && !LayoutHelpers.IsZero(rect2.Height) && !rect2.IsEmpty)
      {
        this.m_BorderGeometry = new StreamGeometry();
        using (StreamGeometryContext ctx = this.m_BorderGeometry.Open())
        {
          LayoutHelpers.CreateGeometry(ctx, rect2, new LayoutHelpers.RadiusDescription(cornerRadius, thickness, true));
          rect2 = LayoutHelpers.DeflateRect(rect2, thickness);
          LayoutHelpers.CreateGeometry(ctx, rect2, new LayoutHelpers.RadiusDescription(cornerRadius, thickness, true));
        }
        this.m_BorderGeometry.Freeze();
        if (lightBorderBrush != null)
        {
          this.m_LightBorderGeometry = new StreamGeometry();
          using (StreamGeometryContext ctx = this.m_LightBorderGeometry.Open())
          {
            LayoutHelpers.CreateGeometry(ctx, rect2, new LayoutHelpers.RadiusDescription(cornerRadius, thickness, false));
            rect2.Inflate(-1.0, -1.0);
            LayoutHelpers.CreateGeometry(ctx, rect2, new LayoutHelpers.RadiusDescription(cornerRadius, thickness, true));
          }
          this.m_LightBorderGeometry.Freeze();
        }
      }
    }
    else
    {
      this.m_BackgroundGeometry = (StreamGeometry) null;
      this.m_BorderGeometry = (StreamGeometry) null;
      this.m_LightBorderGeometry = (StreamGeometry) null;
    }
    return finalSize;
  }

  [DefaultValue(null)]
  public Brush BorderBrush
  {
    get => (Brush) this.GetValue(GroupPanel.BorderBrushProperty);
    set => this.SetValue(GroupPanel.BorderBrushProperty, (object) value);
  }

  [DefaultValue(null)]
  public Brush LightBorderBrush
  {
    get => (Brush) this.GetValue(GroupPanel.LightBorderBrushProperty);
    set => this.SetValue(GroupPanel.LightBorderBrushProperty, (object) value);
  }

  [TypeConverter(typeof (CornerRadiusConverter))]
  public CornerRadius CornerRadius
  {
    get => (CornerRadius) this.GetValue(GroupPanel.CornerRadiusProperty);
    set => this.SetValue(GroupPanel.CornerRadiusProperty, (object) value);
  }

  private static bool IsCornerRadiusValid(object value)
  {
    CornerRadius cornerRadius = (CornerRadius) value;
    return cornerRadius.BottomLeft >= 0.0 && cornerRadius.BottomRight >= 0.0 && cornerRadius.TopLeft >= 0.0 && cornerRadius.TopRight >= 0.0;
  }

  private static void OnBorderBrushChanged(object sender, DependencyPropertyChangedEventArgs e)
  {
    ((GroupPanel) sender).OnBorderBrushChanged(e.OldValue as Brush, e.NewValue as Brush);
  }

  private void OnBorderBrushChanged(Brush oldBrush, Brush newBrush)
  {
    this.m_DividerPen = (Pen) null;
    if (newBrush == null)
      return;
    Brush brush = newBrush.Clone();
    brush.Opacity = 0.35;
    brush.Freeze();
    this.m_DividerPen = new Pen(brush, 1.0);
    this.m_DividerPen.Freeze();
  }

  private static void OnLightBorderBrushChanged(object sender, DependencyPropertyChangedEventArgs e)
  {
    ((GroupPanel) sender).OnLightBorderBrushChanged(e.OldValue as Brush, e.NewValue as Brush);
  }

  private void OnLightBorderBrushChanged(Brush oldBrush, Brush newBrush)
  {
    this.m_DividerPenLight = (Pen) null;
    if (newBrush == null)
      return;
    Brush brush = newBrush.Clone();
    brush.Opacity = 0.5;
    brush.Freeze();
    this.m_DividerPenLight = new Pen(brush, 1.0);
    this.m_DividerPenLight.Freeze();
  }

  protected override void OnVisualChildrenChanged(
    DependencyObject visualAdded,
    DependencyObject visualRemoved)
  {
    base.OnVisualChildrenChanged(visualAdded, visualRemoved);
    if (visualAdded is ButtonDropDown)
      ((ButtonDropDown) visualAdded).RenderBorder = false;
    if (!(visualRemoved is ButtonDropDown))
      return;
    ((ButtonDropDown) visualRemoved).RenderBorder = true;
  }
}
