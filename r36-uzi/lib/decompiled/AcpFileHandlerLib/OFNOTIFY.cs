// Decompiled with JetBrains decompiler
// Type: AcpFileHandlerLib.OFNOTIFY
// Assembly: AcpFileHandlerLib, Version=23.1.0.19, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: F211B494-0F50-48D2-88BA-E4CADB408707
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpFileHandlerLib.dll

using System;
using System.Runtime.InteropServices;

#nullable disable
namespace AcpFileHandlerLib;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
internal struct OFNOTIFY
{
  public NMHDR nmhdr;
  public IntPtr ofn;
  public IntPtr pszFile;
}
