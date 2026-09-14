// Decompiled with JetBrains decompiler
// Type: AcpBusinessLayer.UndoRedo.ModifyAppInfoStateTask
// Assembly: AcpBusinessLayer, Version=23.1.0.23, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 44CF2A76-4418-422B-9DDD-B27A71BAF20C
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpBusinessLayer.dll

using AcpCommonLib;
using AcpCommonLib.UndoRedo;
using AcpCommonResources;
using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace AcpBusinessLayer.UndoRedo;

public class ModifyAppInfoStateTask : UndoableTask
{
  private Dictionary<string, bool> newStates;
  private Dictionary<string, bool> oldStates;
  private Type appInfoType;

  public ModifyAppInfoStateTask(Dictionary<string, bool> newStates)
  {
    this.newStates = newStates != null ? newStates : throw new ArgumentNullException(nameof (newStates));
    this.oldStates = new Dictionary<string, bool>(newStates.Count);
    this.Description = AcpResources.Modify_AppInfoManager_State;
    this.appInfoType = Type.GetType(typeof (AppInfoManager).AssemblyQualifiedName);
    foreach (KeyValuePair<string, bool> newState in newStates)
    {
      PropertyInfo property = this.appInfoType.GetProperty(newState.Key, BindingFlags.Static | BindingFlags.Public);
      bool flag = !(property == (PropertyInfo) null) ? (bool) property.GetValue((object) null, (object[]) null) : throw new InvalidOperationException();
      this.oldStates.Add(newState.Key, flag);
    }
  }

  public override void Do() => this.SetValues(false);

  public override void Undo() => this.SetValues(true);

  protected virtual void SetValues(bool isUndo)
  {
    foreach (KeyValuePair<string, bool> keyValuePair in isUndo ? this.oldStates : this.newStates)
      this.appInfoType.GetProperty(keyValuePair.Key, BindingFlags.Static | BindingFlags.Public).SetValue((object) null, (object) keyValuePair.Value, (object[]) null);
  }
}
