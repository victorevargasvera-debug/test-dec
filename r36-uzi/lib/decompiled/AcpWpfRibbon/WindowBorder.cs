// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.WindowBorder
// Assembly: AcpWpfRibbon, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 45A745B5-88C3-40EE-B1E5-8DBA2EACD529
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfRibbon.dll

using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

#nullable disable
namespace DevComponents.WpfRibbon;

[DesignTimeVisible(false)]
public class WindowBorder : Border
{
  public static readonly DependencyProperty TransparentMarginProperty = DependencyProperty.Register(nameof (TransparentMargin), typeof (Thickness), typeof (WindowBorder), (PropertyMetadata) new FrameworkPropertyMetadata((object) new Thickness(), FrameworkPropertyMetadataOptions.AffectsRender));

  protected override void OnRender(DrawingContext dc)
  {
    Rect r = new Rect(this.RenderSize);
    if (!LayoutHelpers.IsEmpty(this.TransparentMargin))
    {
      Rect rect = LayoutHelpers.DeflateRect(r, this.TransparentMargin);
      dc.PushClip((Geometry) new RectangleGeometry(rect));
      try
      {
        base.OnRender(dc);
      }
      finally
      {
        dc.Pop();
      }
    }
    else
      base.OnRender(dc);
  }

  [Browsable(false)]
  public Thickness TransparentMargin
  {
    get => (Thickness) this.GetValue(WindowBorder.TransparentMarginProperty);
    set => this.SetValue(WindowBorder.TransparentMarginProperty, (object) value);
  }
}
