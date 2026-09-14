// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfDock.Primitives.EmptyWindow
// Assembly: AcpWpfDock, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 89CC52D3-0487-4106-AFAE-BE4A13C8A50E
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfDock.dll

using System;
using System.Windows;
using System.Windows.Media;

#nullable disable
namespace DevComponents.WpfDock.Primitives;

internal class EmptyWindow : Window
{
  public EmptyWindow()
  {
    this.WindowStyle = WindowStyle.None;
    this.AllowsTransparency = true;
    this.Background = (Brush) Brushes.Transparent;
    this.ShowInTaskbar = false;
  }

  protected override void OnSourceInitialized(EventArgs e) => base.OnSourceInitialized(e);
}
