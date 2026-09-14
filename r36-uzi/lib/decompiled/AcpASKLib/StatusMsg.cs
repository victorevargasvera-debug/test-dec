// Decompiled with JetBrains decompiler
// Type: AcpASKLib.StatusMsg
// Assembly: AcpASKLib, Version=23.1.0.5, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: D65BC533-E9D0-49A5-8218-5CB2B5C70E2D
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpASKLib.dll

#nullable disable
namespace AcpASKLib;

public class StatusMsg
{
  public StatusMsg(AskStatusType type, string message, uint retCode)
  {
    this.Type = type;
    this.Message = message;
    this.RetCode = retCode;
  }

  public uint RetCode { get; private set; }

  public AskStatusType Type { get; private set; }

  public string Message { get; private set; }
}
