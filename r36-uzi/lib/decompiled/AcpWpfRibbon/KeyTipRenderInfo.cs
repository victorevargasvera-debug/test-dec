// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.KeyTipRenderInfo
// Assembly: AcpWpfRibbon, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 45A745B5-88C3-40EE-B1E5-8DBA2EACD529
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfRibbon.dll

using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

#nullable disable
namespace DevComponents.WpfRibbon;

internal class KeyTipRenderInfo
{
  public KeyTipColors EnabledColors;
  public KeyTipColors DisabledColors;
  public Typeface Typeface;
  public double FontSize;
  public string KeyTipsStack = "";
  public KeyTipsAdorner Adorner;
  public bool UseSpecKeyTipPositioning;
  public List<UIElement> ActiveKeyTipsElements;
  public bool RibbonMenuMode;
}
