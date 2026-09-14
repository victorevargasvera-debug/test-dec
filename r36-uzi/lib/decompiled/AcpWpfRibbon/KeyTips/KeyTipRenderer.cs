// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.KeyTips.KeyTipRenderer
// Assembly: AcpWpfRibbon, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 45A745B5-88C3-40EE-B1E5-8DBA2EACD529
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfRibbon.dll

using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

#nullable disable
namespace DevComponents.WpfRibbon.KeyTips;

internal abstract class KeyTipRenderer
{
  protected static Size DefaultKeyTipSize = new Size(15.0, 17.0);

  public abstract void Render(DrawingContext dc, object elem, KeyTipRenderInfo info);

  protected virtual bool HasKeyTip(UIElement e)
  {
    if (e == null)
      return false;
    string keyTip = Ribbon.GetKeyTip(e);
    return keyTip != null && keyTip.Length > 0;
  }

  protected virtual void RecordActiveKeyTip(UIElement e, KeyTipRenderInfo info)
  {
    if (!e.IsEnabled)
      return;
    info.ActiveKeyTipsElements.Add(e);
  }

  protected virtual string GetKeyTipString(UIElement elem, KeyTipRenderInfo info)
  {
    string keyTipString = Ribbon.GetKeyTip(elem);
    if (keyTipString != "" && info.KeyTipsStack != null && !keyTipString.StartsWith(info.KeyTipsStack))
      keyTipString = "";
    return keyTipString;
  }

  protected virtual void RenderKeyTip(
    DrawingContext dc,
    KeyTipRenderInfo info,
    UIElement e,
    Point loc)
  {
    if (e == null || e.Visibility != Visibility.Visible || !e.IsVisible)
      return;
    string keyTipString = this.GetKeyTipString(e, info);
    if (keyTipString == "")
      return;
    LayoutInformation.GetLayoutSlot(e as FrameworkElement);
    Point point;
    ref Point local = ref point;
    Size renderSize = e.RenderSize;
    double x = (renderSize.Width - KeyTipRenderer.DefaultKeyTipSize.Width) / 2.0;
    renderSize = e.RenderSize;
    double y = renderSize.Height - (e is ButtonDropDown ? KeyTipRenderer.DefaultKeyTipSize.Height / 2.0 : KeyTipRenderer.DefaultKeyTipSize.Height / 3.0);
    local = new Point(x, y);
    point = e.PointToScreen(point);
    point = info.Adorner.PointFromScreen(point);
    point.X = Math.Round(point.X) + 0.5;
    point.Y = Math.Round(point.Y) + 0.5;
    if (!LayoutHelpers.IsEmpty(loc))
    {
      if (!LayoutHelpers.IsZero(loc.X))
        point.X = loc.X;
      if (!LayoutHelpers.IsZero(loc.Y))
        point.Y = loc.Y;
    }
    KeyTipColors colors = this.GetColors(e, info);
    this.RenderKeyTip(dc, new Rect(point, KeyTipRenderer.DefaultKeyTipSize), colors, info.Typeface, info.FontSize, keyTipString);
  }

  protected virtual void RenderKeyTip(DrawingContext dc, KeyTipRenderInfo info, UIElement e)
  {
    this.RenderKeyTip(dc, info, e, new Point());
  }

  protected virtual void RenderKeyTip(
    DrawingContext dc,
    Rect r,
    KeyTipColors c,
    Typeface tf,
    double fontSize,
    string keyTip)
  {
    FormattedText formattedText = new FormattedText(keyTip, CultureInfo.CurrentCulture, FlowDirection.LeftToRight, tf, fontSize, c.Foreground);
    if (formattedText.Width > r.Width)
      r.Width = formattedText.Width + 4.0;
    dc.DrawRoundedRectangle(c.Background, c.Border, r, 2.0, 2.0);
    Point origin = new Point(r.X + (r.Width - formattedText.Width) / 2.0, r.Y + (r.Height - formattedText.Height) / 2.0);
    dc.DrawText(formattedText, origin);
  }

  protected virtual KeyTipColors GetColors(UIElement elem, KeyTipRenderInfo info)
  {
    return elem.IsEnabled ? info.EnabledColors : info.DisabledColors;
  }
}
