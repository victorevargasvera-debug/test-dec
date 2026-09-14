// Decompiled with JetBrains decompiler
// Type: AcpBusinessLayer.MemoryUtility
// Assembly: AcpBusinessLayer, Version=23.1.0.23, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 44CF2A76-4418-422B-9DDD-B27A71BAF20C
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpBusinessLayer.dll

using System;
using System.Reflection;

#nullable disable
namespace AcpBusinessLayer;

public static class MemoryUtility
{
  public static void RemoveEventHandler(string name, Type notfyObjType, object obj)
  {
    EventInfo eventInfo = notfyObjType.GetEvent(name);
    object obj1 = notfyObjType.GetField(name, BindingFlags.Instance | BindingFlags.NonPublic)?.GetValue(obj);
    if (obj1 == null || !(eventInfo != (EventInfo) null))
      return;
    Delegate @delegate = obj1 as Delegate;
    if ((object) @delegate == null)
      return;
    foreach (Delegate invocation in @delegate.GetInvocationList())
      eventInfo.RemoveEventHandler(obj, invocation);
  }
}
