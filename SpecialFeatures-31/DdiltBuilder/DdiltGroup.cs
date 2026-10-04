// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.DdiltBuilder.DdiltGroup
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using System.Collections.Generic;

#nullable disable
namespace SpecialFeatures.DdiltBuilder;

public struct DdiltGroup
{
  public ushort PartitionNum;
  public ushort NumberTableEntries;
  public ushort Reserved;
  public ushort FirstSingleInstance;
  public ushort LastSingleInstance;
  public SortedDictionary<ushort, ushort> MultiInstanceEntries;
}
