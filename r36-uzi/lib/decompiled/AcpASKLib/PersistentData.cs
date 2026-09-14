// Decompiled with JetBrains decompiler
// Type: AcpASKLib.PersistentData
// Assembly: AcpASKLib, Version=23.1.0.5, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: D65BC533-E9D0-49A5-8218-5CB2B5C70E2D
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpASKLib.dll

using AcpCommonResources;
using System;

#nullable disable
namespace AcpASKLib;

[Serializable]
public class PersistentData
{
  public AccessLevelDataRecordSet RadioWideACLRecSet;
  public AccessLevelDataRecordSet SystemWideACLRecSet;
  public AccessLevelDataRecordSet ConvSystemACLRecSet;

  internal PersistentData()
  {
    this.RadioWideACLRecSet = new AccessLevelDataRecordSet(AcpResources.Radio_Wide_Test);
    this.SystemWideACLRecSet = new AccessLevelDataRecordSet(AcpResources.System_Wide_Test);
    this.ConvSystemACLRecSet = new AccessLevelDataRecordSet(AcpResources.Conventional_System_Test);
  }
}
