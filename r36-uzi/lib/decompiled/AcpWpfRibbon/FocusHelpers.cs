// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.FocusHelpers
// Assembly: AcpWpfRibbon, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 45A745B5-88C3-40EE-B1E5-8DBA2EACD529
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfRibbon.dll

using System.Collections;
using System.Windows;
using System.Windows.Controls;

#nullable disable
namespace DevComponents.WpfRibbon;

internal static class FocusHelpers
{
  internal static bool FocusFirstChild(ItemsControl ic)
  {
    foreach (object obj in (IEnumerable) ic.Items)
    {
      if (obj is UIElement uiElement && uiElement.IsVisible && uiElement.IsEnabled && uiElement.Focusable)
        return uiElement.Focus();
    }
    return false;
  }

  internal static bool FocusFirstChild(Panel p)
  {
    foreach (UIElement child in p.Children)
    {
      if (child.IsVisible && child.IsEnabled && child.Focusable)
        return child.Focus();
    }
    return false;
  }
}
