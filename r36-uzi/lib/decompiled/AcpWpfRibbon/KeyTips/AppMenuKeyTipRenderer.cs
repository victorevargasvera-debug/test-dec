// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.KeyTips.AppMenuKeyTipRenderer
// Assembly: AcpWpfRibbon, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 45A745B5-88C3-40EE-B1E5-8DBA2EACD529
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfRibbon.dll

using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

#nullable disable
namespace DevComponents.WpfRibbon.KeyTips;

internal class AppMenuKeyTipRenderer : ButtonPopupKeyRenderer
{
  public override void Render(DrawingContext dc, object elem, KeyTipRenderInfo info)
  {
    if (!(elem is ApplicationMenu applicationMenu))
      throw new InvalidOperationException("Renderer can render only objects of type ApplicationMenu while elem type is " + elem.GetType()?.ToString());
    if (applicationMenu.IsBackstageActive)
    {
      if (!(applicationMenu.BackstageTab is ItemsControl backstageTab))
        return;
      Size renderSize = backstageTab.RenderSize;
      for (int index = 0; index < backstageTab.Items.Count; ++index)
      {
        if (backstageTab.ItemContainerGenerator.ContainerFromIndex(index) is UIElement e && e.Visibility == Visibility.Visible && e.IsVisible)
        {
          if (e is Panel)
            this.ProcessPanel(e as Panel, dc, info, (UIElement) backstageTab, renderSize);
          else
            this.ProcessUIElement(e, dc, info, (UIElement) backstageTab, renderSize);
        }
      }
    }
    else
    {
      Size renderSize = applicationMenu.Popup.RenderSize;
      foreach (object obj in (IEnumerable) applicationMenu.Items)
      {
        if (obj is UIElement e && e.Visibility == Visibility.Visible && e.IsVisible)
        {
          if (e is Panel)
            this.ProcessPanel(e as Panel, dc, info, (UIElement) applicationMenu.Popup, renderSize);
          else
            this.ProcessUIElement(e, dc, info, (UIElement) applicationMenu.Popup, renderSize);
        }
      }
      foreach (object mruItem in (Collection<object>) applicationMenu.MruItems)
      {
        if (mruItem is UIElement e && e.Visibility == Visibility.Visible && e.IsVisible)
        {
          if (e is Panel)
            this.ProcessPanel(e as Panel, dc, info, (UIElement) applicationMenu.Popup, renderSize);
          else
            this.ProcessUIElement(e, dc, info, (UIElement) applicationMenu.Popup, renderSize);
        }
      }
      foreach (object appItem in (Collection<object>) applicationMenu.AppItems)
      {
        if (appItem is UIElement e && e.Visibility == Visibility.Visible && e.IsVisible)
        {
          if (e is Panel)
            this.ProcessPanel(e as Panel, dc, info, (UIElement) applicationMenu.Popup, renderSize);
          else
            this.ProcessUIElement(e, dc, info, (UIElement) applicationMenu.Popup, renderSize);
        }
      }
    }
  }
}
