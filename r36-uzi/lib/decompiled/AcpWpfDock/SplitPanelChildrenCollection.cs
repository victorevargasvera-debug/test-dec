// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfDock.SplitPanelChildrenCollection
// Assembly: AcpWpfDock, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 89CC52D3-0487-4106-AFAE-BE4A13C8A50E
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfDock.dll

using System.Collections.ObjectModel;
using System.Windows;

#nullable disable
namespace DevComponents.WpfDock;

public class SplitPanelChildrenCollection : ObservableCollection<UIElement>
{
  private SplitPanel m_Parent;

  public SplitPanelChildrenCollection(SplitPanel parent) => this.m_Parent = parent;

  protected override void ClearItems()
  {
    this.m_Parent.OnChildrenClear();
    base.ClearItems();
  }
}
