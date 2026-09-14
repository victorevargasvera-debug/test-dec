// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfDock.DockSiteDesignExtension
// Assembly: AcpWpfDock, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 89CC52D3-0487-4106-AFAE-BE4A13C8A50E
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfDock.dll

using System.ComponentModel;

#nullable disable
namespace DevComponents.WpfDock;

[EditorBrowsable(EditorBrowsableState.Never)]
[ToolboxItem(false)]
public class DockSiteDesignExtension
{
  private DockSite _DockSite;

  public DockSiteDesignExtension(DockSite dockSite) => this._DockSite = dockSite;

  public void StartWindowDrag(
    DockWindowGroup dockWindowGroup,
    bool dragSelectedTabOnly,
    eEventActionSource actionSource,
    IDockOperations dockOperations)
  {
    this._DockSite.DockOperations = dockOperations;
    this._DockSite.StartDockWindowDrag(dockWindowGroup, dragSelectedTabOnly, actionSource);
    this._DockSite.AfterDocked += new DockRoutedEventHandler(this.DockSiteAfterDocked);
  }

  private void DockSiteAfterDocked(object sender, DockRoutedEventArgs e)
  {
    this._DockSite.DockOperations = (IDockOperations) null;
    this._DockSite.AfterDocked -= new DockRoutedEventHandler(this.DockSiteAfterDocked);
    this._DockSite = (DockSite) null;
  }
}
