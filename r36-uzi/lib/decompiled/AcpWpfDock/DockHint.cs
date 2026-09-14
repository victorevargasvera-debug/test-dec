// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfDock.DockHint
// Assembly: AcpWpfDock, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 89CC52D3-0487-4106-AFAE-BE4A13C8A50E
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfDock.dll

using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

#nullable disable
namespace DevComponents.WpfDock;

[DesignTimeVisible(false)]
public class DockHint : Control
{
  public static readonly DependencyProperty DockHintSideProperty;
  public static readonly DependencyProperty PartHitTestSizeProperty;

  static DockHint()
  {
    FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof (DockHint), (PropertyMetadata) new FrameworkPropertyMetadata((object) typeof (DockHint)));
    DockHint.DockHintSideProperty = DependencyProperty.Register(nameof (DockHintSide), typeof (eDockHintSide), typeof (DockHint), (PropertyMetadata) new FrameworkPropertyMetadata((object) eDockHintSide.Top, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender));
    DockHint.PartHitTestSizeProperty = DependencyProperty.Register(nameof (PartHitTestSize), typeof (Size), typeof (DockHint), (PropertyMetadata) new FrameworkPropertyMetadata((object) new Size(29.0, 31.0)));
  }

  public DockHint()
  {
  }

  internal DockHint(eDockHintSide dh) => this.DockHintSide = dh;

  [Category("Appearance")]
  [Bindable(true)]
  public eDockHintSide DockHintSide
  {
    get => (eDockHintSide) this.GetValue(DockHint.DockHintSideProperty);
    set => this.SetValue(DockHint.DockHintSideProperty, (object) value);
  }

  [Category("Behavior")]
  [Bindable(true)]
  public Size PartHitTestSize
  {
    get => (Size) this.GetValue(DockHint.PartHitTestSizeProperty);
    set => this.SetValue(DockHint.PartHitTestSizeProperty, (object) value);
  }

  public eDockHintHitTest HitTest(System.Windows.Point p)
  {
    eDockHintHitTest eDockHintHitTest = eDockHintHitTest.None;
    Rect rect1 = new Rect(this.RenderSize);
    if (!rect1.Contains(p))
      return eDockHintHitTest;
    Size partHitTestSize1 = this.PartHitTestSize;
    if (this.DockHintSide == eDockHintSide.AllSides || this.DockHintSide == eDockHintSide.AllSidesAndCenter)
    {
      Rect rect2 = new Rect(rect1.X + (rect1.Width - this.PartHitTestSize.Width) / 2.0, 0.0, partHitTestSize1.Width, partHitTestSize1.Height);
      if (rect2.Contains(p))
        eDockHintHitTest = eDockHintHitTest.Top;
      rect2 = new Rect(rect1.X + (rect1.Width - this.PartHitTestSize.Width) / 2.0, rect1.Bottom - partHitTestSize1.Height, partHitTestSize1.Width, partHitTestSize1.Height);
      if (rect2.Contains(p))
        eDockHintHitTest = eDockHintHitTest.Bottom;
      ref Rect local1 = ref rect2;
      double y1 = rect1.Y;
      double height1 = rect1.Height;
      Size partHitTestSize2 = this.PartHitTestSize;
      double height2 = partHitTestSize2.Height;
      double num1 = (height1 - height2) / 2.0;
      double y2 = y1 + num1;
      double width1 = partHitTestSize1.Width;
      double height3 = partHitTestSize1.Height;
      local1 = new Rect(0.0, y2, width1, height3);
      if (rect2.Contains(p))
        eDockHintHitTest = eDockHintHitTest.Left;
      ref Rect local2 = ref rect2;
      double x1 = rect1.Right - partHitTestSize1.Width;
      double y3 = rect1.Y;
      double height4 = rect1.Height;
      partHitTestSize2 = this.PartHitTestSize;
      double height5 = partHitTestSize2.Height;
      double num2 = (height4 - height5) / 2.0;
      double y4 = y3 + num2;
      double width2 = partHitTestSize1.Width;
      double height6 = partHitTestSize1.Height;
      local2 = new Rect(x1, y4, width2, height6);
      if (rect2.Contains(p))
        eDockHintHitTest = eDockHintHitTest.Right;
      if (this.DockHintSide == eDockHintSide.AllSidesAndCenter)
      {
        ref Rect local3 = ref rect2;
        double x2 = rect1.X;
        double width3 = rect1.Width;
        partHitTestSize2 = this.PartHitTestSize;
        double width4 = partHitTestSize2.Width;
        double num3 = (width3 - width4) / 2.0;
        double x3 = x2 + num3;
        double y5 = rect1.Y;
        double height7 = rect1.Height;
        partHitTestSize2 = this.PartHitTestSize;
        double height8 = partHitTestSize2.Height;
        double num4 = (height7 - height8) / 2.0;
        double y6 = y5 + num4;
        double width5 = partHitTestSize1.Width;
        double height9 = partHitTestSize1.Height;
        local3 = new Rect(x3, y6, width5, height9);
        if (rect2.Contains(p))
          eDockHintHitTest = eDockHintHitTest.Tab;
      }
    }
    else if (this.DockHintSide == eDockHintSide.Top)
      eDockHintHitTest = eDockHintHitTest.Top;
    else if (this.DockHintSide == eDockHintSide.Bottom)
      eDockHintHitTest = eDockHintHitTest.Bottom;
    else if (this.DockHintSide == eDockHintSide.Left)
      eDockHintHitTest = eDockHintHitTest.Left;
    else if (this.DockHintSide == eDockHintSide.Right)
      eDockHintHitTest = eDockHintHitTest.Right;
    return eDockHintHitTest;
  }
}
