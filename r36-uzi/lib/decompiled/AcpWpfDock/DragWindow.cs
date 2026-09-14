// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfDock.DragWindow
// Assembly: AcpWpfDock, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 89CC52D3-0487-4106-AFAE-BE4A13C8A50E
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfDock.dll

using DevComponents.WpfDock.Primitives;
using System.Windows;

#nullable disable
namespace DevComponents.WpfDock;

internal class DragWindow : EmptyWindow
{
  internal Point DisplayOffset;
  internal Size FloatingSize;

  static DragWindow()
  {
    FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof (DragWindow), (PropertyMetadata) new FrameworkPropertyMetadata((object) typeof (DragWindow)));
  }
}
