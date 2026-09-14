// Decompiled with JetBrains decompiler
// Type: AcpUI.DragDrop.DropPreviewAdorner
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

#nullable disable
namespace AcpUI.DragDrop;

public class DropPreviewAdorner : Adorner
{
  private ContentPresenter _presenter;
  private double _left;
  private double _top;

  internal double Left
  {
    get => this._left;
    set
    {
      this._left = value;
      this.UpdatePosition();
    }
  }

  internal double Top
  {
    get => this._top;
    set
    {
      this._top = value;
      this.UpdatePosition();
    }
  }

  internal DropPreviewAdorner(UIElement feedbackUI, UIElement adornedElement)
    : base(adornedElement)
  {
    this._presenter = new ContentPresenter();
    this._presenter.Content = (object) feedbackUI;
    this._presenter.IsHitTestVisible = false;
  }

  private void UpdatePosition()
  {
    if (!(this.Parent is AdornerLayer parent))
      return;
    parent.Update(this.AdornedElement);
  }

  protected override Size MeasureOverride(Size constraint)
  {
    this._presenter.Measure(constraint);
    return this._presenter.DesiredSize;
  }

  protected override Size ArrangeOverride(Size finalSize)
  {
    this._presenter.Arrange(new Rect(finalSize));
    return finalSize;
  }

  protected override Visual GetVisualChild(int index) => (Visual) this._presenter;

  protected override int VisualChildrenCount => 1;

  public override GeneralTransform GetDesiredTransform(GeneralTransform transform)
  {
    return (GeneralTransform) new GeneralTransformGroup()
    {
      Children = {
        (GeneralTransform) new TranslateTransform(this.Left, this.Top),
        base.GetDesiredTransform(transform)
      }
    };
  }
}
