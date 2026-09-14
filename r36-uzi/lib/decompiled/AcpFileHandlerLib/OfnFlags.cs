// Decompiled with JetBrains decompiler
// Type: AcpFileHandlerLib.OfnFlags
// Assembly: AcpFileHandlerLib, Version=23.1.0.19, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: F211B494-0F50-48D2-88BA-E4CADB408707
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpFileHandlerLib.dll

#nullable disable
namespace AcpFileHandlerLib;

internal enum OfnFlags
{
  OFN_OVERWRITEPROMPT = 2,
  OFN_HIDEREADONLY = 4,
  OFN_NOCHANGEDIR = 8,
  OFN_ENABLEHOOK = 32, // 0x00000020
  OFN_ALLOWMULTISELECT = 512, // 0x00000200
  OFN_PATHMUSTEXIST = 2048, // 0x00000800
  OFN_FILEMUSTEXIST = 4096, // 0x00001000
  OFN_CREATEPROMPT = 8192, // 0x00002000
  OFN_NOTESTFILECREATE = 65536, // 0x00010000
  OFN_EXPLORER = 524288, // 0x00080000
  OFN_ENABLESIZING = 8388608, // 0x00800000
}
