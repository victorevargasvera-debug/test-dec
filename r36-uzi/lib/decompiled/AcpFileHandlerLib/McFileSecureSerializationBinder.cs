// Decompiled with JetBrains decompiler
// Type: AcpFileHandlerLib.McFileSecureSerializationBinder
// Assembly: AcpFileHandlerLib, Version=23.1.0.19, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: F211B494-0F50-48D2-88BA-E4CADB408707
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpFileHandlerLib.dll

using Motorola.Common.BinarySerializer;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;

#nullable disable
namespace AcpFileHandlerLib;

public class McFileSecureSerializationBinder : DefaultSerializationBinder
{
  private readonly List<Tuple<string, string>> _allowedTypes;

  public McFileSecureSerializationBinder(IEnumerable<BinarySerializerTypeInfo> allowedTypes)
  {
    this._allowedTypes = this.BuildTupleListWithTypes(allowedTypes);
  }

  public override Type BindToType(string assemblyName, string typeName)
  {
    foreach (Tuple<string, string> allowedType in this._allowedTypes)
    {
      if (typeName.StartsWith(allowedType.Item1) && (string.IsNullOrEmpty(allowedType.Item2) || assemblyName.Equals(allowedType.Item2)))
        return base.BindToType(assemblyName, typeName);
    }
    throw new JsonSerializationException($"Request type `{typeName}` from assembly `{assemblyName}` not supported");
  }

  private List<Tuple<string, string>> BuildTupleListWithTypes(
    IEnumerable<BinarySerializerTypeInfo> allowedTypes)
  {
    List<Tuple<string, string>> tupleList = new List<Tuple<string, string>>();
    foreach (BinarySerializerTypeInfo allowedType in allowedTypes)
    {
      string str = allowedType.Type;
      string assembly = allowedType.Assembly;
      if (str.EndsWith(".*"))
        str = str.TrimEnd('.').TrimEnd('*');
      tupleList.Add(Tuple.Create<string, string>(str, assembly));
    }
    return tupleList;
  }
}
