// Decompiled with JetBrains decompiler
// Type: AcpFileHandlerLib.SetWindowPosFlags
// Assembly: AcpFileHandlerLib, Version=23.1.0.19, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: F211B494-0F50-48D2-88BA-E4CADB408707
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpFileHandlerLib.dll

#nullable disable
namespace AcpFileHandlerLib;

internal enum SetWindowPosFlags
{
  SWP_NOSIZE = 1,
  SWP_NOMOVE = 2,
  SWP_NOZORDER = 4,
  SWP_NOREDRAW = 8,
  SWP_NOACTIVATE = 16, // 0x00000010
  SWP_DRAWFRAME = 32, // 0x00000020
  SWP_FRAMECHANGED = 32, // 0x00000020
  SWP_SHOWWINDOW = 64, // 0x00000040
  SWP_HIDEWINDOW = 128, // 0x00000080
  SWP_NOCOPYBITS = 256, // 0x00000100
  SWP_NOOWNERZORDER = 512, // 0x00000200
  SWP_NOREPOSITION = 512, // 0x00000200
  SWP_NOSENDCHANGING = 1024, // 0x00000400
  SWP_DEFERERASE = 8192, // 0x00002000
  SWP_ASYNCWINDOWPOS = 16384, // 0x00004000
}
