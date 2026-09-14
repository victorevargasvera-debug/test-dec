// Decompiled with JetBrains decompiler
// Type: AcpASKLib.AccessNodeIDType
// Assembly: AcpASKLib, Version=23.1.0.5, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: D65BC533-E9D0-49A5-8218-5CB2B5C70E2D
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpASKLib.dll

#nullable disable
namespace AcpASKLib;

public enum AccessNodeIDType
{
  UNDEFINED = 0,
  TRK_SYSTEM = 1,
  TRK_PERS = 2,
  TRK_HPD = 3,
  TRK_DATA = 4,
  TRK_EMERG = 5,
  TRK_TYPEIIi = 6,
  TRK_OPERS = 7,
  CONV_DUMMY = 1000, // 0x000003E8
}
