// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfDock.SplitPanelCollection
// Assembly: AcpWpfDock, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 89CC52D3-0487-4106-AFAE-BE4A13C8A50E
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfDock.dll

using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

#nullable disable
namespace DevComponents.WpfDock;

public class SplitPanelCollection : ObservableCollection<SplitPanel>
{
  private DockSite m_Parent;

  public SplitPanelCollection()
  {
  }

  public SplitPanelCollection(DockSite parent) => this.m_Parent = parent;

  protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
  {
    if (e.Action == NotifyCollectionChangedAction.Add || e.Action == NotifyCollectionChangedAction.Remove)
    {
      if (e.NewItems != null)
      {
        foreach (SplitPanel newItem in (IEnumerable) e.NewItems)
          this.m_Parent.AddSplitPanel(newItem);
      }
      if (e.OldItems != null)
      {
        foreach (SplitPanel oldItem in (IEnumerable) e.OldItems)
          this.m_Parent.RemoveSplitPanel(oldItem);
      }
    }
    base.OnCollectionChanged(e);
  }
}
