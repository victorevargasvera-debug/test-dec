// Decompiled with JetBrains decompiler
// Type: AcpUI.DragDrop.ListBoxDragAdorner
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;

#nullable disable
namespace AcpUI.DragDrop;

public class ListBoxDragAdorner : Adorner
{
  private Rectangle child;
  private double offsetLeft;
  private double offsetTop;

  internal ListBoxDragAdorner(UIElement adornedElement, Size size, Brush brush)
    : base(adornedElement)
  {
    Rectangle rectangle = new Rectangle();
    rectangle.Fill = brush;
    rectangle.Width = size.Width;
    rectangle.Height = size.Height;
    rectangle.IsHitTestVisible = false;
    this.child = rectangle;
  }

  public override GeneralTransform GetDesiredTransform(GeneralTransform transform)
  {
    return (GeneralTransform) new GeneralTransformGroup()
    {
      Children = {
        base.GetDesiredTransform(transform),
        (GeneralTransform) new TranslateTransform(this.offsetLeft, this.offsetTop)
      }
    };
  }

  internal double OffsetLeft
  {
    get => this.offsetLeft;
    set
    {
      this.offsetLeft = value;
      this.UpdateLocation();
    }
  }

  internal void SetOffsets(double left, double top)
  {
    this.offsetLeft = left;
    this.offsetTop = top;
    this.UpdateLocation();
  }

  internal double OffsetTop
  {
    get => this.offsetTop;
    set
    {
      this.offsetTop = value;
      this.UpdateLocation();
    }
  }

  protected override Size MeasureOverride(Size constraint)
  {
    this.child.Measure(constraint);
    return this.child.DesiredSize;
  }

  protected override Size ArrangeOverride(Size finalSize)
  {
    this.child.Arrange(new Rect(finalSize));
    return finalSize;
  }

  protected override Visual GetVisualChild(int index) => (Visual) this.child;

  protected override int VisualChildrenCount => 1;

  private void UpdateLocation()
  {
    if (!(this.Parent is AdornerLayer parent))
      return;
    parent.Update(this.AdornedElement);
  }
}
