// Decompiled with JetBrains decompiler
// Type: AcpASKLib.AccessRecordSetX`1
// Assembly: AcpASKLib, Version=23.1.0.5, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: D65BC533-E9D0-49A5-8218-5CB2B5C70E2D
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpASKLib.dll

using System;
using System.Collections.ObjectModel;

#nullable disable
namespace AcpASKLib;

[Serializable]
public class AccessRecordSetX<T> : ObservableCollection<T>
{
  private string name;

  protected AccessRecordSetX()
  {
  }

  internal AccessRecordSetX(string name) => this.name = name;

  internal string Name
  {
    get => this.name;
    set => this.name = value;
  }

  internal void AddRecord(T item) => this.Add(item);

  internal void RemoveRecord(T item) => this.Remove(item);
}
