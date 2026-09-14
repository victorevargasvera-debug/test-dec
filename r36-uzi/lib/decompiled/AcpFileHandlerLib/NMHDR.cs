// Decompiled with JetBrains decompiler
// Type: AcpFileHandlerLib.NMHDR
// Assembly: AcpFileHandlerLib, Version=23.1.0.19, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: F211B494-0F50-48D2-88BA-E4CADB408707
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpFileHandlerLib.dll

using System;

#nullable disable
namespace AcpFileHandlerLib;

internal struct NMHDR
{
  public IntPtr HwndFrom;
  public IntPtr IdFrom;
  public uint Code;
}
