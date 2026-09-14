// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.Utility
// Assembly: AcpWpfRibbon, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 45A745B5-88C3-40EE-B1E5-8DBA2EACD529
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfRibbon.dll

using System.Collections;
using System.Windows;
using System.Windows.Controls;

#nullable disable
namespace DevComponents.WpfRibbon;

internal class Utility
{
  public static bool ContainsName(IEnumerable items, string name)
  {
    foreach (object obj in items)
    {
      if (obj is FrameworkElement frameworkElement && frameworkElement.Name == name)
        return true;
    }
    return false;
  }

  public static int IndexOfName(IList items, string name)
  {
    for (int index = 0; index < items.Count; ++index)
    {
      if (items[index] is FrameworkElement frameworkElement && frameworkElement.Name == name)
        return index;
    }
    return -1;
  }

  public static FrameworkElement FindByName(IEnumerable collection, string name)
  {
    foreach (object obj in collection)
    {
      if (obj is FrameworkElement byName1 && byName1.Name == name)
        return byName1;
      switch (byName1)
      {
        case ItemsControl _:
          FrameworkElement byName2 = Utility.FindByName((IEnumerable) ((ItemsControl) byName1).Items, name);
          if (byName2 != null)
            return byName2;
          continue;
        case Panel _:
          FrameworkElement byName3 = Utility.FindByName((IEnumerable) ((Panel) byName1).Children, name);
          if (byName3 != null)
            return byName3;
          continue;
        case HeaderedContentControl _:
          HeaderedContentControl headeredContentControl = (HeaderedContentControl) byName1;
          if (headeredContentControl.Content is ItemsControl)
          {
            FrameworkElement byName4 = Utility.FindByName((IEnumerable) ((ItemsControl) headeredContentControl.Content).Items, name);
            if (byName4 != null)
              return byName4;
            continue;
          }
          if (headeredContentControl.Content is Panel)
          {
            FrameworkElement byName5 = Utility.FindByName((IEnumerable) ((Panel) headeredContentControl.Content).Children, name);
            if (byName5 != null)
              return byName5;
            continue;
          }
          continue;
        default:
          continue;
      }
    }
    return (FrameworkElement) null;
  }
}
