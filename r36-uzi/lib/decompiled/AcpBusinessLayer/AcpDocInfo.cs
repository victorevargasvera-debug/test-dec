// Decompiled with JetBrains decompiler
// Type: AcpBusinessLayer.AcpDocInfo
// Assembly: AcpBusinessLayer, Version=23.1.0.23, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 44CF2A76-4418-422B-9DDD-B27A71BAF20C
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpBusinessLayer.dll

using AcpCommonLib;
using System;
using System.Runtime.Serialization;

#nullable disable
namespace AcpBusinessLayer;

[Serializable]
public class AcpDocInfo : ISerializable
{
  internal AcpDocument Document { get; set; }

  public AcpDocInfo(AcpDocument document)
  {
    this.Document = document;
    this.HasInvalids = AppInfoManager.InvalidFieldsReport.HasFields;
  }

  public AcpDocInfo(SerializationInfo info, StreamingContext context)
  {
    this.HasInvalids = info.GetBoolean(nameof (HasInvalids));
  }

  public bool HasInvalids { get; set; }

  public void GetObjectData(SerializationInfo info, StreamingContext context)
  {
    info.AddValue("HasInvalids", this.HasInvalids);
  }
}
