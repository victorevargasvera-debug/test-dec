// Decompiled with JetBrains decompiler
// Type: AcpFileHandlerLib.ConverterContractResolver
// Assembly: AcpFileHandlerLib, Version=23.1.0.19, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: F211B494-0F50-48D2-88BA-E4CADB408707
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpFileHandlerLib.dll

using Newtonsoft.Json.Serialization;
using System;

#nullable disable
namespace AcpFileHandlerLib;

public class ConverterContractResolver : DefaultContractResolver
{
  public static readonly ConverterContractResolver Instance = new ConverterContractResolver();

  protected override JsonContract CreateContract(Type objectType)
  {
    JsonContract contract = base.CreateContract(objectType);
    if (objectType?.BaseType?.FullName == "AcpBusinessLayer.Recordset")
      contract = (JsonContract) this.CreateISerializableContract(objectType);
    return contract;
  }
}
