// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfDock.ColorFactory
// Assembly: AcpWpfDock, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 89CC52D3-0487-4106-AFAE-BE4A13C8A50E
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfDock.dll

using System.Windows.Media;

#nullable disable
namespace DevComponents.WpfDock;

internal abstract class ColorFactory
{
  public abstract Color GetColor(int color);

  public abstract Color GetColor(Color color);
}
