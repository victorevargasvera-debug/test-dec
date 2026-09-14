// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.KeyTips.ButtonPopupKeyRenderer
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

internal class ButtonPopupKeyRenderer : KeyTipRenderer
{
  public override void Render(DrawingContext dc, object elem, KeyTipRenderInfo info)
  {
    if (!(elem is ButtonDropDown buttonDropDown))
      throw new InvalidOperationException("Renderer can render only objects of type ButtonDropDown while elem type is " + elem.GetType()?.ToString());
    Size renderSize = buttonDropDown.Popup.RenderSize;
    foreach (object obj in (IEnumerable) buttonDropDown.Items)
    {
      if (obj is UIElement e && e.Visibility == Visibility.Visible && e.IsVisible)
      {
        if (e is Panel)
          this.ProcessPanel(e as Panel, dc, info, (UIElement) buttonDropDown.Popup, renderSize);
        else
          this.ProcessUIElement(e, dc, info, (UIElement) buttonDropDown.Popup, renderSize);
      }
    }
  }

  protected virtual void ProcessPanel(
    Panel panel,
    DrawingContext dc,
    KeyTipRenderInfo info,
    UIElement container,
    Size popupSize)
  {
    foreach (UIElement child in panel.Children)
    {
      if (child.Visibility == Visibility.Visible && child.IsVisible)
      {
        if (child is Panel)
          this.ProcessPanel(child as Panel, dc, info, container, popupSize);
        else
          this.ProcessUIElement(child, dc, info, container, popupSize);
      }
    }
  }

  protected virtual void ProcessUIElement(
    UIElement e,
    DrawingContext dc,
    KeyTipRenderInfo info,
    UIElement container,
    Size popupSize)
  {
    System.Windows.Point screen1 = e.PointToScreen(new System.Windows.Point());
    System.Windows.Point point = container.PointFromScreen(screen1);
    Rect rect = new Rect(point, e.RenderSize);
    point = new System.Windows.Point(rect.X + 16.0, rect.Bottom - KeyTipRenderer.DefaultKeyTipSize.Height * 0.92);
    System.Windows.Point screen2 = container.PointToScreen(point);
    System.Windows.Point loc = info.Adorner.PointFromScreen(screen2);
    loc.X = Math.Round(loc.X) + 0.5;
    loc.Y = Math.Round(loc.Y) + 0.5;
    this.RenderKeyTip(dc, info, e, loc);
    this.RecordActiveKeyTip(e, info);
  }
}
