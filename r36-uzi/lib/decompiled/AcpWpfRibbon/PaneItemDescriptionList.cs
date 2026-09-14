// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.PaneItemDescriptionList
// Assembly: AcpWpfRibbon, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 45A745B5-88C3-40EE-B1E5-8DBA2EACD529
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfRibbon.dll

using System.Collections;
using System.Collections.ObjectModel;

#nullable disable
namespace DevComponents.WpfRibbon;

internal class PaneItemDescriptionList : ObservableCollection<PaneItemDescription>
{
  public PaneItemDescriptionList(NavigationPane np)
  {
    foreach (object obj in (IEnumerable) np.Items)
    {
      if (obj is PaneItem paneItem)
        this.Add(new PaneItemDescription(paneItem));
    }
  }
}
