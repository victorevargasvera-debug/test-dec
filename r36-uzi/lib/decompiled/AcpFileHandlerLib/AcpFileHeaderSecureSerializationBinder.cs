// Decompiled with JetBrains decompiler
// Type: AcpFileHandlerLib.AcpFileHeaderSecureSerializationBinder
// Assembly: AcpFileHandlerLib, Version=23.1.0.19, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: F211B494-0F50-48D2-88BA-E4CADB408707
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpFileHandlerLib.dll

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;

#nullable disable
namespace AcpFileHandlerLib;

public class AcpFileHeaderSecureSerializationBinder : DefaultSerializationBinder
{
  public static readonly AcpFileHeaderSecureSerializationBinder Instance = new AcpFileHeaderSecureSerializationBinder();
  private static readonly List<Tuple<string, string>> _headerAllowedTypes = new List<Tuple<string, string>>()
  {
    Tuple.Create<string, string>("AcpBusinessLayer.AcpDocInfo", "AcpBusinessLayer"),
    Tuple.Create<string, string>("AcpFileHandlerLib.", "AcpFileHandlerLib"),
    Tuple.Create<string, string>("System.Collections.Generic.ArrayList`2", string.Empty),
    Tuple.Create<string, string>("System.Collections.Generic.Dictionary`2", string.Empty),
    Tuple.Create<string, string>("System.IO.FileInfo", string.Empty)
  };

  public override Type BindToType(string assemblyName, string typeName)
  {
    foreach (Tuple<string, string> headerAllowedType in AcpFileHeaderSecureSerializationBinder._headerAllowedTypes)
    {
      if (typeName.StartsWith(headerAllowedType.Item1) && (string.IsNullOrEmpty(headerAllowedType.Item2) || assemblyName.Equals(headerAllowedType.Item2)))
        return base.BindToType(assemblyName, typeName);
    }
    throw new JsonSerializationException($"Request type `{typeName}` from assembly `{assemblyName}` not supported");
  }
}
