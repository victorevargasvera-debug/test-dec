// Decompiled with JetBrains decompiler
// Type: AcpASKLib.OtapData
// Assembly: AcpASKLib, Version=23.1.0.5, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: D65BC533-E9D0-49A5-8218-5CB2B5C70E2D
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpASKLib.dll

#nullable disable
namespace AcpASKLib;

public class OtapData
{
  private byte uKeyType;
  private int sys_id;
  private bool bOTAP;

  internal OtapData(byte keytype, int sysID, bool otap)
  {
    this.uKeyType = keytype;
    this.sys_id = sysID;
    this.bOTAP = otap;
  }

  internal byte OTAPKeyType
  {
    get => this.uKeyType;
    set => this.uKeyType = value;
  }

  internal int SystemID
  {
    get => this.sys_id;
    set => this.sys_id = value;
  }

  internal bool OTAPStatus
  {
    get => this.bOTAP;
    set => this.bOTAP = value;
  }
}
