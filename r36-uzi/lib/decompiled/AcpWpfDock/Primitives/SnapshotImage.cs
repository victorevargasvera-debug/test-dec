// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfDock.Primitives.SnapshotImage
// Assembly: AcpWpfDock, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 89CC52D3-0487-4106-AFAE-BE4A13C8A50E
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfDock.dll

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

#nullable disable
namespace DevComponents.WpfDock.Primitives;

internal class SnapshotImage : Image
{
  public void TakeSnapshot(UIElement elem)
  {
    Size renderSize = elem.RenderSize;
    int width = (int) renderSize.Width;
    renderSize = elem.RenderSize;
    int height = (int) renderSize.Height;
    PixelFormat pixelFormat = PixelFormats.Default;
    RenderTargetBitmap renderTargetBitmap = new RenderTargetBitmap(width, height, 96.0, 96.0, pixelFormat);
    renderTargetBitmap.Render((Visual) elem);
    this.Source = (ImageSource) renderTargetBitmap;
  }

  public void RemoveOnAnimationCompleted(object sender, EventArgs e)
  {
    if (this.Parent is AutoHideAdorner)
    {
      (this.Parent as AutoHideAdorner).Children.Remove((UIElement) this);
    }
    else
    {
      if (!(this.Parent is Panel))
        return;
      (this.Parent as Panel).Children.Remove((UIElement) this);
    }
  }
}
