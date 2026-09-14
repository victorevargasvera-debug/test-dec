// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfDock.DockRoutedEventArgs
// Assembly: AcpWpfDock, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 89CC52D3-0487-4106-AFAE-BE4A13C8A50E
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfDock.dll

using System.Windows;

#nullable disable
namespace DevComponents.WpfDock;

public class DockRoutedEventArgs : CancelSourceRoutedEventArgs
{
  public readonly object DockControl;

  public DockRoutedEventArgs(RoutedEvent e)
    : base(e)
  {
  }

  public DockRoutedEventArgs(RoutedEvent e, object source)
    : base(e, source)
  {
  }

  public DockRoutedEventArgs(
    RoutedEvent e,
    object source,
    object dockControl,
    eEventActionSource actionSource)
    : base(e, source)
  {
    this.DockControl = dockControl;
    this.EventActionSource = actionSource;
  }
}
