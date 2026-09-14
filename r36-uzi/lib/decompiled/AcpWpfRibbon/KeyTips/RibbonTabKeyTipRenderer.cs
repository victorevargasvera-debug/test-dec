// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.KeyTips.RibbonTabKeyTipRenderer
// Assembly: AcpWpfRibbon, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 45A745B5-88C3-40EE-B1E5-8DBA2EACD529
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfRibbon.dll

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

#nullable disable
namespace DevComponents.WpfRibbon.KeyTips;

internal class RibbonTabKeyTipRenderer : KeyTipRenderer
{
  public override void Render(DrawingContext dc, object elem, KeyTipRenderInfo info)
  {
    if (!(elem is RibbonTab ribbonTab))
      throw new InvalidOperationException("Renderer can render only objects of type RibbonTab while elem type is " + elem.GetType()?.ToString());
    if (ribbonTab.Content == null || !(ribbonTab.Content is Panel))
      return;
    foreach (UIElement child in (ribbonTab.Content as Panel).Children)
    {
      if (child.Visibility == Visibility.Visible && child.IsVisible)
        KeyTipRenderFactory.GetRenderer((object) child)?.Render(dc, (object) child, info);
    }
  }
}
