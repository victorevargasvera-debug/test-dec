// Decompiled with JetBrains decompiler
// Type: AcpASKLib.Block03
// Assembly: AcpASKLib, Version=23.1.0.5, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: D65BC533-E9D0-49A5-8218-5CB2B5C70E2D
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpASKLib.dll

#nullable disable
namespace AcpASKLib;

internal class Block03
{
  private const int MAX_ID_CHAR = 3;
  private const int CHANNEL_CHAR = 2;
  private const int MAX_CHANNEL_NO = 8;
  private int system_id;
  private byte[,] channel_list = new byte[8, 2];

  internal Block03(int sysId) => this.system_id = sysId;

  internal int SystemID => this.system_id;
}
