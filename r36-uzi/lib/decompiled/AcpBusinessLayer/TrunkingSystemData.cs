// Decompiled with JetBrains decompiler
// Type: AcpBusinessLayer.TrunkingSystemData
// Assembly: AcpBusinessLayer, Version=23.1.0.23, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 44CF2A76-4418-422B-9DDD-B27A71BAF20C
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpBusinessLayer.dll

using AcpASKLib;

#nullable disable
namespace AcpBusinessLayer;

public static class TrunkingSystemData
{
  public const string RECSET_ID = "2064";
  public const string ASK_REQUIRED_FIELD_NAME = "TrkSysGeneralAskRequired_A44909";
  public const string SYSTEM_ID_FIELD_NAME = "TrkSysGeneralSystemID_A9239";

  public static bool PartialXmlExport { get; set; }

  public static ISystemKeyMgr SystemKeyManager { get; set; }
}
