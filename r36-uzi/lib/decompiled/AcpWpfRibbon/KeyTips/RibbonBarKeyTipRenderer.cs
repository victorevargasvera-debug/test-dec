// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.KeyTips.RibbonBarKeyTipRenderer
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

internal class RibbonBarKeyTipRenderer : KeyTipRenderer
{
  public override void Render(DrawingContext dc, object elem, KeyTipRenderInfo info)
  {
    Size rbSize = elem is RibbonBar ribbonBar ? ribbonBar.RenderSize : throw new InvalidOperationException("Renderer can render only objects of type RibbonBar while elem type is " + elem.GetType()?.ToString());
    if (ribbonBar.ButtonPanel != null)
      rbSize = ribbonBar.ButtonPanel.RenderSize;
    foreach (object obj in (IEnumerable) ribbonBar.Items)
    {
      if (obj is UIElement e && e.Visibility == Visibility.Visible && e.IsVisible)
      {
        if (e is Panel)
          this.ProcessPanel(e as Panel, dc, info, ribbonBar, rbSize);
        else
          this.ProcessUIElement(e, dc, info, ribbonBar, rbSize);
      }
    }
    if (ribbonBar.DialogLauncherVisible != Visibility.Visible || !this.HasKeyTip((UIElement) ribbonBar))
      return;
    System.Windows.Point point;
    ref System.Windows.Point local1 = ref point;
    Size renderSize = ribbonBar.RenderSize;
    double x = renderSize.Width - KeyTipRenderer.DefaultKeyTipSize.Width;
    renderSize = ribbonBar.RenderSize;
    double y = renderSize.Height - 2.0;
    local1 = new System.Windows.Point(x, y);
    if (info.RibbonMenuMode)
    {
      ref System.Windows.Point local2 = ref point;
      renderSize = ribbonBar.RenderSize;
      double num = renderSize.Height - KeyTipRenderer.DefaultKeyTipSize.Height + 5.0;
      local2.Y = num;
    }
    System.Windows.Point screen = ribbonBar.PointToScreen(point);
    System.Windows.Point loc = info.Adorner.PointFromScreen(screen);
    loc.X = Math.Round(loc.X) + 0.5;
    loc.Y = Math.Round(loc.Y) + 0.5;
    this.RenderKeyTip(dc, info, (UIElement) ribbonBar, loc);
    this.RecordActiveKeyTip((UIElement) ribbonBar, info);
  }

  private void ProcessPanel(
    Panel panel,
    DrawingContext dc,
    KeyTipRenderInfo info,
    RibbonBar rb,
    Size rbSize)
  {
    foreach (UIElement child in panel.Children)
    {
      if (child.Visibility == Visibility.Visible && child.IsVisible)
      {
        if (child is Panel)
          this.ProcessPanel(child as Panel, dc, info, rb, rbSize);
        else
          this.ProcessUIElement(child, dc, info, rb, rbSize);
      }
    }
  }

  private void ProcessUIElement(
    UIElement e,
    DrawingContext dc,
    KeyTipRenderInfo info,
    RibbonBar rb,
    Size rbSize)
  {
    if (!this.HasKeyTip(e))
      return;
    if (info.UseSpecKeyTipPositioning)
    {
      System.Windows.Point screen1 = e.PointToScreen(new System.Windows.Point());
      Rect elemRect = new Rect(rb.PointFromScreen(screen1), e.RenderSize);
      System.Windows.Point specKeyTipPosition = this.GetSpecKeyTipPosition(rbSize, elemRect);
      System.Windows.Point screen2 = rb.PointToScreen(specKeyTipPosition);
      System.Windows.Point loc = info.Adorner.PointFromScreen(screen2);
      if (info.RibbonMenuMode && loc.Y < 0.0)
        loc.Y = 0.0;
      loc.X = Math.Round(loc.X) + 0.5;
      loc.Y = Math.Round(loc.Y) + 0.5;
      this.RenderKeyTip(dc, info, e, loc);
    }
    else
      this.RenderKeyTip(dc, info, e);
    this.RecordActiveKeyTip(e, info);
  }

  private System.Windows.Point GetSpecKeyTipPosition(Size ribbonBarSize, Rect elemRect)
  {
    return new System.Windows.Point(elemRect.X + (elemRect.Width - KeyTipRenderer.DefaultKeyTipSize.Width) / 2.0, 0.0)
    {
      Y = elemRect.Y >= ribbonBarSize.Height * 0.699999988079071 || elemRect.Bottom >= ribbonBarSize.Height * 0.800000011920929 ? ribbonBarSize.Height - KeyTipRenderer.DefaultKeyTipSize.Height / 2.0 : (elemRect.Y > ribbonBarSize.Height * 0.2 ? (ribbonBarSize.Height - KeyTipRenderer.DefaultKeyTipSize.Height) / 2.0 : -KeyTipRenderer.DefaultKeyTipSize.Height * 0.3)
    };
  }
}
