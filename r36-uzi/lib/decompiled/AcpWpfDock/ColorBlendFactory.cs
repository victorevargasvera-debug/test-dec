// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfDock.ColorBlendFactory
// Assembly: AcpWpfDock, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 89CC52D3-0487-4106-AFAE-BE4A13C8A50E
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfDock.dll

using System.Windows.Media;

#nullable disable
namespace DevComponents.WpfDock;

internal class ColorBlendFactory : ColorFactory
{
  private Color m_BlendColor;

  public ColorBlendFactory(Color blendColor) => this.m_BlendColor = blendColor;

  public override Color GetColor(int rgb)
  {
    return rgb == -1 ? new Color() : Color.FromArgb(byte.MaxValue, ColorBlendFactory.SoftLight((rgb & 16711680 /*0xFF0000*/) >> 16 /*0x10*/, (int) this.m_BlendColor.R), ColorBlendFactory.SoftLight((rgb & 65280) >> 8, (int) this.m_BlendColor.G), ColorBlendFactory.SoftLight(rgb & (int) byte.MaxValue, (int) this.m_BlendColor.B));
  }

  public override Color GetColor(Color c)
  {
    return c.A == (byte) 0 ? c : Color.FromArgb(c.A, ColorBlendFactory.SoftLight((int) c.R, (int) this.m_BlendColor.R), ColorBlendFactory.SoftLight((int) c.G, (int) this.m_BlendColor.G), ColorBlendFactory.SoftLight((int) c.B, (int) this.m_BlendColor.B));
  }

  internal static byte SoftLight(int a, int b)
  {
    int num = a * b / (int) byte.MaxValue;
    return (byte) (num + a * ((int) byte.MaxValue - ((int) byte.MaxValue - a) * ((int) byte.MaxValue - b) / (int) byte.MaxValue - num) / (int) byte.MaxValue);
  }

  internal static Color SoftLight(Color c, Color light)
  {
    return Color.FromArgb(c.A, ColorBlendFactory.SoftLight((int) c.R, (int) light.R), ColorBlendFactory.SoftLight((int) c.G, (int) light.G), ColorBlendFactory.SoftLight((int) c.B, (int) light.B));
  }
}
