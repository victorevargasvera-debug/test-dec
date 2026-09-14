// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.KeyTips.RibbonKeyTipRenderer
// Assembly: AcpWpfRibbon, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 45A745B5-88C3-40EE-B1E5-8DBA2EACD529
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfRibbon.dll

using System;
using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

#nullable disable
namespace DevComponents.WpfRibbon.KeyTips;

internal class RibbonKeyTipRenderer : KeyTipRenderer
{
  public override void Render(DrawingContext dc, object elem, KeyTipRenderInfo info)
  {
    if (!(elem is Ribbon ribbon))
      throw new InvalidOperationException("Renderer can render only objects of type Ribbon while elem type is " + elem.GetType()?.ToString());
    double num = 0.0;
    if (ribbon.QuickAccessToolbar != null)
    {
      System.Windows.Point point = new System.Windows.Point(0.0, ribbon.QuickAccessToolbar.RenderSize.Height - KeyTipRenderer.DefaultKeyTipSize.Height * 0.7);
      System.Windows.Point screen = ribbon.QuickAccessToolbar.PointToScreen(point);
      System.Windows.Point loc = info.Adorner.PointFromScreen(screen);
      num = Math.Round(loc.Y) + 0.5;
      loc.Y = num;
      loc.X = 0.0;
      if (ribbon.QuickAccessToolbar is ItemsControl)
      {
        ItemsControl quickAccessToolbar = ribbon.QuickAccessToolbar as ItemsControl;
        foreach (object obj in (IEnumerable) quickAccessToolbar.Items)
        {
          if (!(obj is UIElement e))
            e = quickAccessToolbar.ItemContainerGenerator.ContainerFromItem(obj) as UIElement;
          this.RenderKeyTip(dc, info, e, loc);
          this.RecordActiveKeyTip(e, info);
        }
      }
      else if (ribbon.QuickAccessToolbar is Panel)
      {
        foreach (UIElement child in (ribbon.QuickAccessToolbar as Panel).Children)
        {
          this.RenderKeyTip(dc, info, child, loc);
          this.RecordActiveKeyTip(child, info);
        }
      }
    }
    if (ribbon.ApplicationMenu != null && ribbon.ApplicationMenu != null)
    {
      string keyTipString = this.GetKeyTipString(ribbon.ApplicationMenu, info);
      if (keyTipString != "")
      {
        System.Windows.Point point;
        ref System.Windows.Point local1 = ref point;
        Size renderSize = ribbon.ApplicationMenu.RenderSize;
        double x1 = (renderSize.Width - KeyTipRenderer.DefaultKeyTipSize.Width) / 2.0;
        renderSize = ribbon.ApplicationMenu.RenderSize;
        double y1 = (renderSize.Height - KeyTipRenderer.DefaultKeyTipSize.Height) / 2.0;
        local1 = new System.Windows.Point(x1, y1);
        if (ribbon.EffectiveStyle == eEffectiveStyle.Office2010)
        {
          ref System.Windows.Point local2 = ref point;
          renderSize = ribbon.ApplicationMenu.RenderSize;
          double x2 = (renderSize.Width - KeyTipRenderer.DefaultKeyTipSize.Width) / 2.0;
          renderSize = ribbon.ApplicationMenu.RenderSize;
          double y2 = renderSize.Height - KeyTipRenderer.DefaultKeyTipSize.Height / 2.0;
          local2 = new System.Windows.Point(x2, y2);
        }
        System.Windows.Point screen = ribbon.ApplicationMenu.PointToScreen(point);
        System.Windows.Point location = info.Adorner.PointFromScreen(screen);
        location.X = Math.Round(location.X) + 0.5;
        location.Y = Math.Round(location.Y) + 0.5;
        if (num > 0.0 && !ribbon.IsQuickAccessToolbarBelow && ribbon.EffectiveStyle == eEffectiveStyle.Office2007)
          location.Y = num;
        KeyTipColors colors = this.GetColors(ribbon.ApplicationMenu, info);
        this.RenderKeyTip(dc, new Rect(location, KeyTipRenderer.DefaultKeyTipSize), colors, info.Typeface, info.FontSize, keyTipString);
        this.RecordActiveKeyTip(ribbon.ApplicationMenu, info);
      }
    }
    foreach (object obj in (IEnumerable) ribbon.Items)
    {
      UIElement e = obj as UIElement;
      this.RenderKeyTip(dc, info, e);
      this.RecordActiveKeyTip(e, info);
    }
  }
}
