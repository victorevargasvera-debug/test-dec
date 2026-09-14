// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfDock.Primitives.DockSelectorAdorner
// Assembly: AcpWpfDock, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 89CC52D3-0487-4106-AFAE-BE4A13C8A50E
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfDock.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

#nullable disable
namespace DevComponents.WpfDock.Primitives;

internal class DockSelectorAdorner : Adorner
{
  private DockWindowSelector m_Selector;

  public DockSelectorAdorner(UIElement adornedElement)
    : base(adornedElement)
  {
    this.m_Selector = new DockWindowSelector();
    this.AddVisualChild((Visual) this.m_Selector);
    this.AddLogicalChild((object) this.m_Selector);
  }

  protected override Size MeasureOverride(Size constraint)
  {
    Size availableSize = constraint;
    int visualChildrenCount = this.VisualChildrenCount;
    for (int index = 0; index < visualChildrenCount; ++index)
    {
      if (this.GetVisualChild(index) is UIElement visualChild)
        visualChild.Measure(availableSize);
    }
    LayoutHelpers.NormalizeMeasureBounds(ref constraint);
    return constraint;
  }

  protected override void OnRender(DrawingContext dc)
  {
    Brush brush = (Brush) new SolidColorBrush(Color.FromArgb((byte) 128 /*0x80*/, (byte) 0, (byte) 0, (byte) 0));
    dc.DrawRectangle(brush, (Pen) null, new Rect(0.0, 0.0, this.ActualWidth, this.ActualHeight));
    base.OnRender(dc);
  }

  protected override Size ArrangeOverride(Size finalSize)
  {
    Rect finalRect;
    ref Rect local = ref finalRect;
    double x = (finalSize.Width - this.m_Selector.DesiredSize.Width) / 2.0;
    double y = (finalSize.Height - this.m_Selector.DesiredSize.Height) / 2.0;
    Size desiredSize = this.m_Selector.DesiredSize;
    double width = desiredSize.Width;
    desiredSize = this.m_Selector.DesiredSize;
    double height = desiredSize.Height;
    local = new Rect(x, y, width, height);
    this.m_Selector.Arrange(finalRect);
    return finalSize;
  }

  public UIElement RealAdornedElement { get; set; }

  protected override int VisualChildrenCount => 1;

  protected override Visual GetVisualChild(int index)
  {
    if (index < 0 || index > 0)
      throw new ArgumentOutOfRangeException(nameof (index), (object) index, "Argument for Visual child is out of range");
    return (Visual) this.m_Selector;
  }

  protected override IEnumerator LogicalChildren
  {
    get
    {
      return (IEnumerator) new List<UIElement>(1)
      {
        (UIElement) this.m_Selector
      }.GetEnumerator();
    }
  }

  public DockWindowSelector DockWindowSelector => this.m_Selector;

  public override GeneralTransform GetDesiredTransform(GeneralTransform transform)
  {
    return (GeneralTransform) null;
  }
}
