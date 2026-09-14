// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfDock.eDockList
// Assembly: AcpWpfDock, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 89CC52D3-0487-4106-AFAE-BE4A13C8A50E
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfDock.dll

using System;

#nullable disable
namespace DevComponents.WpfDock;

[Flags]
public enum eDockList
{
  Docked = 1,
  AutoHide = 2,
  Floating = 4,
  Documents = 8,
  All = Documents | Floating | AutoHide | Docked, // 0x0000000F
}
