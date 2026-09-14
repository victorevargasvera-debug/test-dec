// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.NavigationPanePanel
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
public class NavigationPanePanel : Panel
{
  private NavigationPaneCustomizeButton _CustomizeButton;
  public static readonly DependencyProperty LargeItemsCountProperty = DependencyProperty.Register(nameof (LargeItemsCount), typeof (int), typeof (NavigationPanePanel), (PropertyMetadata) new FrameworkPropertyMetadata((object) 3, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsParentArrange));
  public static readonly DependencyProperty EnableCustomizationProperty = DependencyProperty.Register(nameof (EnableCustomization), typeof (bool), typeof (NavigationPanePanel), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange));
  public static readonly DependencyProperty SmallItemsHeightProperty = DependencyProperty.Register(nameof (SmallItemsHeight), typeof (double), typeof (NavigationPanePanel), (PropertyMetadata) new FrameworkPropertyMetadata((object) 30.0, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsParentArrange));
  public static readonly DependencyProperty SmallItemsBackgroundProperty = DependencyProperty.Register(nameof (SmallItemsBackground), typeof (Brush), typeof (NavigationPanePanel), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.SubPropertiesDoNotAffectRender));
  public static readonly DependencyProperty PaneExpandedProperty = DependencyProperty.Register(nameof (PaneExpanded), typeof (bool), typeof (NavigationPanePanel), (PropertyMetadata) new FrameworkPropertyMetadata((object) true));

  public NavigationPanePanel() => this.ClipToBounds = true;

  protected override Size MeasureOverride(Size availableSize)
  {
    UIElementCollection internalChildren = this.InternalChildren;
    Size availableSize1 = availableSize;
    if (availableSize1.Width != double.PositiveInfinity)
      availableSize1.Width = Math.Ceiling(availableSize1.Width);
    if (availableSize1.Height != double.PositiveInfinity)
      availableSize1.Height = Math.Ceiling(availableSize1.Height);
    Size availableSize2 = new Size(availableSize1.Width, this.SmallItemsHeight);
    Size size = new Size(0.0, this.SmallItemsHeight);
    int largeItemsCount = this.LargeItemsCount;
    double val2 = 0.0;
    bool paneExpanded = this.PaneExpanded;
    foreach (UIElement uiElement in internalChildren)
    {
      if (uiElement.Visibility != Visibility.Collapsed)
      {
        if (largeItemsCount == 0)
        {
          uiElement.Measure(availableSize2);
          if (paneExpanded)
            val2 += Math.Ceiling(uiElement.DesiredSize.Width);
        }
        else
        {
          uiElement.Measure(availableSize1);
          Size desiredSize = uiElement.DesiredSize;
          --largeItemsCount;
          size.Height += desiredSize.Height;
          size.Width = Math.Max(size.Width, Math.Ceiling(desiredSize.Width));
        }
      }
    }
    if (this.EnableCustomization)
    {
      NavigationPaneCustomizeButton navigationPaneCustomize = this.GetNavigationPaneCustomize();
      navigationPaneCustomize.Measure(new Size(availableSize1.Width, this.SmallItemsHeight));
      val2 += navigationPaneCustomize.DesiredSize.Width;
    }
    else
      this.DestroyNavigationPaneCustomize();
    if (val2 > size.Width)
      val2 = size.Width;
    size.Width = Math.Max(size.Width, val2);
    return size;
  }

  protected override Size ArrangeOverride(Size finalSize)
  {
    UIElementCollection internalChildren = this.InternalChildren;
    int largeItemsCount1 = this.LargeItemsCount;
    double smallItemsHeight = this.SmallItemsHeight;
    System.Windows.Point point1 = new System.Windows.Point(finalSize.Width, finalSize.Height - smallItemsHeight);
    System.Windows.Point point2 = new System.Windows.Point(0.0, 0.0);
    bool paneExpanded = this.PaneExpanded;
    double width1 = finalSize.Width;
    if (this.EnableCustomization)
    {
      NavigationPaneCustomizeButton navigationPaneCustomize = this.GetNavigationPaneCustomize();
      navigationPaneCustomize.Arrange(new Rect(new System.Windows.Point(finalSize.Width - navigationPaneCustomize.DesiredSize.Width, point1.Y), new Size(navigationPaneCustomize.DesiredSize.Width, smallItemsHeight)));
      width1 -= navigationPaneCustomize.DesiredSize.Width;
    }
    double num1 = 0.0;
    double num2 = num1;
    for (int index = 0; index < internalChildren.Count; ++index)
    {
      UIElement uiElement = internalChildren[index];
      if (uiElement.Visibility != Visibility.Collapsed)
      {
        if (largeItemsCount1 == 0)
        {
          if (num2 + uiElement.DesiredSize.Width <= width1)
            num2 += uiElement.DesiredSize.Width;
          else
            break;
        }
        else
          --largeItemsCount1;
      }
    }
    point1.X = width1 - num2;
    bool flag = false;
    int largeItemsCount2 = this.LargeItemsCount;
    for (int index = 0; index < internalChildren.Count; ++index)
    {
      UIElement uiElement1 = internalChildren[index];
      Size desiredSize;
      if (uiElement1.Visibility != Visibility.Collapsed)
      {
        if (largeItemsCount2 == 0)
        {
          if (paneExpanded)
          {
            if (!flag)
            {
              double num3 = num1;
              desiredSize = uiElement1.DesiredSize;
              double width2 = desiredSize.Width;
              if (num3 + width2 <= width1)
              {
                UIElement uiElement2 = uiElement1;
                System.Windows.Point location = point1;
                desiredSize = uiElement1.DesiredSize;
                Size size = new Size(desiredSize.Width, smallItemsHeight);
                Rect finalRect = new Rect(location, size);
                uiElement2.Arrange(finalRect);
                ref System.Windows.Point local = ref point1;
                double x = local.X;
                desiredSize = uiElement1.DesiredSize;
                double width3 = desiredSize.Width;
                local.X = x + width3;
                double num4 = num1;
                desiredSize = uiElement1.DesiredSize;
                double width4 = desiredSize.Width;
                num1 = num4 + width4;
                continue;
              }
            }
            UIElement uiElement3 = uiElement1;
            desiredSize = uiElement1.DesiredSize;
            double width5 = desiredSize.Width;
            desiredSize = uiElement1.DesiredSize;
            double height = desiredSize.Height;
            Rect finalRect1 = new Rect(-1000.0, 0.0, width5, height);
            uiElement3.Arrange(finalRect1);
            flag = true;
          }
          else
          {
            UIElement uiElement4 = uiElement1;
            desiredSize = uiElement1.DesiredSize;
            Rect finalRect = new Rect(-1000.0, 0.0, desiredSize.Width, smallItemsHeight);
            uiElement4.Arrange(finalRect);
          }
        }
        else
        {
          UIElement uiElement5 = uiElement1;
          System.Windows.Point location = point2;
          double width6 = finalSize.Width;
          desiredSize = uiElement1.DesiredSize;
          double height1 = desiredSize.Height;
          Size size = new Size(width6, height1);
          Rect finalRect = new Rect(location, size);
          uiElement5.Arrange(finalRect);
          ref System.Windows.Point local = ref point2;
          double y = local.Y;
          desiredSize = uiElement1.DesiredSize;
          double height2 = desiredSize.Height;
          local.Y = y + height2;
          --largeItemsCount2;
        }
      }
    }
    return finalSize;
  }

  [Browsable(false)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  public int VisiblePaneItemCount
  {
    get
    {
      int visiblePaneItemCount = 0;
      foreach (UIElement child in this.Children)
      {
        if (child.Visibility == Visibility.Visible)
          ++visiblePaneItemCount;
      }
      return visiblePaneItemCount;
    }
  }

  [Browsable(false)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  public UIElement FirstVisible
  {
    get
    {
      foreach (UIElement child in this.Children)
      {
        if (child.Visibility == Visibility.Visible)
          return child;
      }
      return (UIElement) null;
    }
  }

  private NavigationPaneCustomizeButton GetNavigationPaneCustomize()
  {
    if (this._CustomizeButton == null)
    {
      NavigationPaneCustomizeButton child = new NavigationPaneCustomizeButton();
      child.Content = (object) "C";
      this.AddLogicalChild((object) child);
      this.AddVisualChild((Visual) child);
      this._CustomizeButton = child;
    }
    return this._CustomizeButton;
  }

  private void DestroyNavigationPaneCustomize()
  {
    NavigationPaneCustomizeButton customizeButton = this._CustomizeButton;
    if (customizeButton == null)
      return;
    this._CustomizeButton = (NavigationPaneCustomizeButton) null;
    this.RemoveLogicalChild((object) customizeButton);
    this.RemoveVisualChild((Visual) customizeButton);
  }

  [Bindable(true)]
  public double SmallItemsHeight
  {
    get => (double) this.GetValue(NavigationPanePanel.SmallItemsHeightProperty);
    set => this.SetValue(NavigationPanePanel.SmallItemsHeightProperty, (object) value);
  }

  [Bindable(true)]
  public int LargeItemsCount
  {
    get => (int) this.GetValue(NavigationPanePanel.LargeItemsCountProperty);
    set => this.SetValue(NavigationPanePanel.LargeItemsCountProperty, (object) value);
  }

  [Bindable(true)]
  public bool EnableCustomization
  {
    get => (bool) this.GetValue(NavigationPanePanel.EnableCustomizationProperty);
    set => this.SetValue(NavigationPanePanel.EnableCustomizationProperty, (object) value);
  }

  protected override int VisualChildrenCount
  {
    get
    {
      int visualChildrenCount = base.VisualChildrenCount;
      if (this.EnableCustomization)
        ++visualChildrenCount;
      return visualChildrenCount;
    }
  }

  protected override Visual GetVisualChild(int index)
  {
    return this.EnableCustomization && index == this.VisualChildrenCount - 1 ? (Visual) this.GetNavigationPaneCustomize() : base.GetVisualChild(index);
  }

  [DefaultValue(null)]
  public Brush SmallItemsBackground
  {
    get => (Brush) this.GetValue(NavigationPanePanel.SmallItemsBackgroundProperty);
    set => this.SetValue(NavigationPanePanel.SmallItemsBackgroundProperty, (object) value);
  }

  protected override void OnRender(DrawingContext dc)
  {
    base.OnRender(dc);
    Brush smallItemsBackground = this.SmallItemsBackground;
    if (smallItemsBackground == null)
      return;
    Rect rectangle;
    ref Rect local = ref rectangle;
    Size renderSize = this.RenderSize;
    double y = renderSize.Height - this.SmallItemsHeight;
    renderSize = this.RenderSize;
    double width = renderSize.Width;
    double smallItemsHeight = this.SmallItemsHeight;
    local = new Rect(0.0, y, width, smallItemsHeight);
    if (rectangle.Width <= 0.0 || rectangle.Height <= 0.0)
      return;
    dc.DrawRectangle(smallItemsBackground, (Pen) null, rectangle);
  }

  public bool PaneExpanded
  {
    get => (bool) this.GetValue(NavigationPanePanel.PaneExpandedProperty);
    set => this.SetValue(NavigationPanePanel.PaneExpandedProperty, (object) value);
  }
}
