// Decompiled with JetBrains decompiler
// Type: AcpUI.AcpColorKeyBrush
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

using System;
using System.Windows;
using System.Windows.Media;

#nullable disable
namespace AcpUI;

public class AcpColorKeyBrush
{
  public static Brush GetBrushFromColorKey(Type type, string colorKey)
  {
    return (Brush) new FrameworkElement().TryFindResource((object) new ComponentResourceKey(type, (object) colorKey));
  }
}
