// Decompiled with JetBrains decompiler
// Type: AcpASKLib.SpecialKeyData
// Assembly: AcpASKLib, Version=23.1.0.5, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: D65BC533-E9D0-49A5-8218-5CB2B5C70E2D
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpASKLib.dll

using AcpKeyValidatorLib;

#nullable disable
namespace AcpASKLib;

public class SpecialKeyData
{
  private string ibtnSerialNum;
  private HardwareKeyType uKeyType;

  internal SpecialKeyData(string serialNum, HardwareKeyType type)
  {
    this.ibtnSerialNum = serialNum;
    this.uKeyType = type;
  }

  internal HardwareKeyType Type => this.uKeyType;

  internal string iBtnSerialNum => this.ibtnSerialNum;
}
