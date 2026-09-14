// Decompiled with JetBrains decompiler
// Type: AcpBusinessLayer.SerializationInfoExtensions
// Assembly: AcpBusinessLayer, Version=23.1.0.23, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 44CF2A76-4418-422B-9DDD-B27A71BAF20C
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpBusinessLayer.dll

using System;
using System.Reflection;
using System.Runtime.Serialization;

#nullable enable
namespace AcpBusinessLayer;

public static class SerializationInfoExtensions
{
  private static readonly 
  #nullable disable
  Type _int = typeof (int);
  private static readonly Type _string = typeof (string);
  private static readonly Type _bool = typeof (bool);
  private static readonly MethodInfo _GetValueNoThrow = typeof (SerializationInfo).GetMethod("GetValueNoThrow", BindingFlags.Instance | BindingFlags.NonPublic);

  public static int? GetIntValueNoThrow(this SerializationInfo info, string name)
  {
    return (int?) SerializationInfoExtensions._GetValueNoThrow.Invoke((object) info, new object[2]
    {
      (object) name,
      (object) SerializationInfoExtensions._int
    });
  }

  public static 
  #nullable enable
  string? GetStringValueNoThrow(this 
  #nullable disable
  SerializationInfo info, string name)
  {
    return (string) SerializationInfoExtensions._GetValueNoThrow.Invoke((object) info, new object[2]
    {
      (object) name,
      (object) SerializationInfoExtensions._string
    });
  }

  public static bool? GetBoolValueNoThrow(this SerializationInfo info, string name)
  {
    return (bool?) SerializationInfoExtensions._GetValueNoThrow.Invoke((object) info, new object[2]
    {
      (object) name,
      (object) SerializationInfoExtensions._bool
    });
  }
}
