// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfDock.IDockOperations
// Assembly: AcpWpfDock, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 89CC52D3-0487-4106-AFAE-BE4A13C8A50E
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfDock.dll

using System.Windows;

#nullable disable
namespace DevComponents.WpfDock;

public interface IDockOperations
{
  void BeginDockOperation(bool isFloatWindowOperation);

  DockWindowGroup TearOffSelectedDockWindow(DockWindowGroup currentGroup);

  void DockWindow(DockWindowGroup dragDockWindowGroup, eDockSide dockSide, bool fullSize);

  void DockWindow(
    DockWindowGroup dragDockWindowGroup,
    UIElement mouseOverElement,
    eDockSide dockSide);

  void FloatWindow(DockWindowGroup dragDockWindowGroup, Rect floatingRect);

  void EndDockOperation();
}
