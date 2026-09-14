// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfDock.eDockInfo
// Assembly: AcpWpfDock, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 89CC52D3-0487-4106-AFAE-BE4A13C8A50E
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfDock.dll

using System;

#nullable disable
namespace DevComponents.WpfDock;

[Flags]
internal enum eDockInfo
{
  Float = 1,
  Outer = 2,
  Left = 4,
  Right = 8,
  Top = 16, // 0x00000010
  Bottom = 32, // 0x00000020
  Tab = 64, // 0x00000040
  SplitContainerValid = 128, // 0x00000080
}
