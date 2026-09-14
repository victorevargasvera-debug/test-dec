// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.CrumbBarSelectionChangedEventArgs
// Assembly: AcpWpfRibbon, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 45A745B5-88C3-40EE-B1E5-8DBA2EACD529
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfRibbon.dll

using System.Windows;

#nullable disable
namespace DevComponents.WpfRibbon;

public class CrumbBarSelectionChangedEventArgs : RoutedEventArgs
{
  private object _SelectedItem;
  private object _DeselectedItem;

  public object SelectedItem => this._SelectedItem;

  public object DeselectedItem => this._DeselectedItem;

  public CrumbBarSelectionChangedEventArgs(
    RoutedEvent routedEvent,
    object source,
    object selectedItem,
    object deselectedItem)
    : base(routedEvent, source)
  {
    this._SelectedItem = selectedItem;
    this._DeselectedItem = deselectedItem;
  }
}
