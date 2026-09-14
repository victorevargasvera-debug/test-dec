// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfDock.BeforeDockedRoutedEventArgs
// Assembly: AcpWpfDock, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 89CC52D3-0487-4106-AFAE-BE4A13C8A50E
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfDock.dll

using System.Windows;

#nullable disable
namespace DevComponents.WpfDock;

public class BeforeDockedRoutedEventArgs : DockRoutedEventArgs
{
  public readonly bool IsFloating;
  public readonly eDockSide DockSide = eDockSide.Left;
  public readonly DockWindowGroup ReferenceDockGroup;

  public BeforeDockedRoutedEventArgs(RoutedEvent e)
    : base(e)
  {
  }

  public BeforeDockedRoutedEventArgs(RoutedEvent e, object source)
    : base(e, source)
  {
  }

  public BeforeDockedRoutedEventArgs(
    RoutedEvent e,
    object source,
    object dockControl,
    eEventActionSource actionSource,
    bool isFloating,
    eDockSide dockSide,
    DockWindowGroup refGroup)
    : base(e, source, dockControl, actionSource)
  {
    this.IsFloating = isFloating;
    this.DockSide = dockSide;
    this.ReferenceDockGroup = refGroup;
  }
}
