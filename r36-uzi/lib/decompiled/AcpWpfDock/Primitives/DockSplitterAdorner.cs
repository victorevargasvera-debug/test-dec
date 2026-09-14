// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfDock.Primitives.DockSplitterAdorner
// Assembly: AcpWpfDock, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 89CC52D3-0487-4106-AFAE-BE4A13C8A50E
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfDock.dll

using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

#nullable disable
namespace DevComponents.WpfDock.Primitives;

internal class DockSplitterAdorner(DockSplitter adornedElement) : Adorner((UIElement) adornedElement)
{
  private Brush m_PreviewBrush;
  private double m_Offset;

  protected override void OnRender(DrawingContext dc)
  {
    Rect splitterRect = this.GetSplitterRect();
    Brush previewBrush = this.PreviewBrush;
    dc.DrawRectangle(previewBrush, (Pen) null, splitterRect);
  }

  public Brush PreviewBrush
  {
    get => this.m_PreviewBrush;
    set => this.m_PreviewBrush = value;
  }

  private Rect GetSplitterRect()
  {
    DockSplitter adornedElement = (DockSplitter) this.AdornedElement;
    return adornedElement.Orientation == Orientation.Horizontal ? new Rect(0.0, this.m_Offset, adornedElement.ActualWidth, adornedElement.ActualHeight) : new Rect(this.m_Offset, 0.0, adornedElement.ActualWidth, adornedElement.ActualHeight);
  }

  public double Offset
  {
    get => this.m_Offset;
    set
    {
      if (this.m_Offset == value)
        return;
      this.m_Offset = value;
      this.InvalidateVisual();
    }
  }
}
