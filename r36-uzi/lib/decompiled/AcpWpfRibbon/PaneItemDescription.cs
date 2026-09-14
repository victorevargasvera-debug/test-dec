// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.PaneItemDescription
// Assembly: AcpWpfRibbon, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 45A745B5-88C3-40EE-B1E5-8DBA2EACD529
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfRibbon.dll

using System.Windows;

#nullable disable
namespace DevComponents.WpfRibbon;

internal class PaneItemDescription
{
  private PaneItem _PaneItem;
  private object _Header;
  private bool _IsVisible = true;

  public PaneItem PaneItem
  {
    get => this._PaneItem;
    set
    {
      if (this._PaneItem == value)
        return;
      this._PaneItem = value;
    }
  }

  public object Header
  {
    get => this._Header;
    set
    {
      if (this._Header == value)
        return;
      this._Header = value;
    }
  }

  public bool IsVisible
  {
    get => this._IsVisible;
    set
    {
      if (this._IsVisible == value)
        return;
      this._IsVisible = value;
    }
  }

  public PaneItemDescription(PaneItem paneItem)
  {
    this.PaneItem = paneItem;
    this.Header = CloningMachine.GetObjectCopy(paneItem.Header, false);
    this.IsVisible = paneItem.Visibility == Visibility.Visible;
  }
}
