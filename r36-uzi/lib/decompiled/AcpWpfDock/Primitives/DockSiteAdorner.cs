// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfDock.Primitives.DockSiteAdorner
// Assembly: AcpWpfDock, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 89CC52D3-0487-4106-AFAE-BE4A13C8A50E
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfDock.dll

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

#nullable disable
namespace DevComponents.WpfDock.Primitives;

internal class DockSiteAdorner(UIElement adornedElement) : Adorner(adornedElement)
{
  private UIElementCollection m_Children;
  private UIElement m_DockHintBottom;
  private UIElement m_DockHintTop;
  private UIElement m_DockHintLeft;
  private UIElement m_DockHintRight;
  private UIElement m_DockHintAllSides;
  private Rect m_AllSidesRect;
  private double m_EdgeOffset = 12.0;
  private UIElement _RealAdornedElement;

  public UIElement RealAdornedElement
  {
    get => this._RealAdornedElement;
    set => this._RealAdornedElement = value;
  }

  protected override Size MeasureOverride(Size constraint)
  {
    Size availableSize = new Size(double.PositiveInfinity, double.PositiveInfinity);
    foreach (UIElement child in this.Children)
      child.Measure(availableSize);
    LayoutHelpers.NormalizeMeasureBounds(ref constraint);
    return constraint;
  }

  protected override Size ArrangeOverride(Size finalSize)
  {
    Rect empty = Rect.Empty;
    Rect rect1 = new Rect(finalSize);
    if (this.RealAdornedElement is DockSite)
      rect1 = LayoutHelpers.GetBounds((UIElement) (this.RealAdornedElement as DockSite), (UIElement) this) with
      {
        Y = 0.0
      };
    if (this.DockHintBottom != null)
    {
      Size desiredSize = this.DockHintBottom.DesiredSize;
      this.DockHintBottom.Arrange(this.PrepareRect(new Rect(rect1.X + (rect1.Width - desiredSize.Width) / 2.0, rect1.Bottom - desiredSize.Height - this.m_EdgeOffset, desiredSize.Width, desiredSize.Height)));
    }
    if (this.DockHintTop != null)
    {
      Size desiredSize = this.DockHintTop.DesiredSize;
      this.DockHintTop.Arrange(this.PrepareRect(new Rect(rect1.X + (rect1.Width - desiredSize.Width) / 2.0, rect1.Y + this.m_EdgeOffset, desiredSize.Width, desiredSize.Height)));
    }
    if (this.DockHintLeft != null)
    {
      Size desiredSize = this.DockHintLeft.DesiredSize;
      this.DockHintLeft.Arrange(this.PrepareRect(new Rect(rect1.X + this.m_EdgeOffset, rect1.Y + (rect1.Height - desiredSize.Height) / 2.0, desiredSize.Width, desiredSize.Height)));
    }
    if (this.DockHintRight != null)
    {
      Size desiredSize = this.DockHintRight.DesiredSize;
      this.DockHintRight.Arrange(this.PrepareRect(new Rect(rect1.Right - desiredSize.Width - this.m_EdgeOffset, rect1.Y + (rect1.Height - desiredSize.Height) / 2.0, desiredSize.Width, desiredSize.Height)));
    }
    if (this.DockHintAllSides != null)
    {
      Size desiredSize = this.DockHintAllSides.DesiredSize;
      Rect rect2 = rect1;
      if (this.m_AllSidesRect.Width > 0.0 && this.m_AllSidesRect.Height > 0.0)
        rect2 = this.m_AllSidesRect;
      this.DockHintAllSides.Arrange(this.PrepareRect(new Rect(rect2.X + (rect2.Width - desiredSize.Width) / 2.0, rect2.Y + (rect2.Height - desiredSize.Height) / 2.0, desiredSize.Width, desiredSize.Height)));
    }
    return finalSize;
  }

  private Rect PrepareRect(Rect rect)
  {
    rect.X = Math.Round(rect.X);
    rect.Y = Math.Round(rect.Y);
    return rect;
  }

  public UIElement DockHintBottom
  {
    get => this.m_DockHintBottom;
    set => this.SetDockHint(value, ref this.m_DockHintBottom);
  }

  public UIElement DockHintTop
  {
    get => this.m_DockHintTop;
    set => this.SetDockHint(value, ref this.m_DockHintTop);
  }

  public UIElement DockHintLeft
  {
    get => this.m_DockHintLeft;
    set => this.SetDockHint(value, ref this.m_DockHintLeft);
  }

  public UIElement DockHintRight
  {
    get => this.m_DockHintRight;
    set => this.SetDockHint(value, ref this.m_DockHintRight);
  }

  public UIElement DockHintAllSides
  {
    get => this.m_DockHintAllSides;
    set => this.SetDockHint(value, ref this.m_DockHintAllSides);
  }

  public Rect AllSidesRect
  {
    get => this.m_AllSidesRect;
    set
    {
      if (!(this.m_AllSidesRect != value))
        return;
      this.m_AllSidesRect = value;
      this.InvalidateArrange();
      this.InvalidateVisual();
    }
  }

  private void SetDockHint(UIElement value, ref UIElement dockHintVariable)
  {
    if (dockHintVariable != null)
      this.Children.Remove(dockHintVariable);
    dockHintVariable = value;
    if (dockHintVariable != null)
      this.Children.Add(dockHintVariable);
    this.InvalidateMeasure();
    this.InvalidateVisual();
  }

  public UIElementCollection Children
  {
    get
    {
      if (this.m_Children == null)
        this.m_Children = new UIElementCollection((UIElement) this, (FrameworkElement) this);
      return this.m_Children;
    }
  }

  protected override Visual GetVisualChild(int index) => (Visual) this.Children[index];

  protected override int VisualChildrenCount => this.Children.Count;

  internal void AnimationCompleteCleanup(object sender, EventArgs e)
  {
    AdornerLayer.GetAdornerLayer((Visual) this.AdornedElement)?.Remove((Adorner) this);
  }
}
