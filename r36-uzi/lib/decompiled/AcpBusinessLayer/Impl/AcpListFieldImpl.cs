// Decompiled with JetBrains decompiler
// Type: AcpBusinessLayer.Impl.AcpListFieldImpl
// Assembly: AcpBusinessLayer, Version=23.1.0.23, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 44CF2A76-4418-422B-9DDD-B27A71BAF20C
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpBusinessLayer.dll

using AcpCommonLib;
using System.Collections;

#nullable disable
namespace AcpBusinessLayer.Impl;

internal class AcpListFieldImpl : AcpFieldImpl<int>
{
  private BitArray itemVisibilities;

  internal AcpListFieldImpl(string uiName)
    : base(uiName)
  {
    this.itemVisibilities = new BitArray(32 /*0x20*/, true);
  }

  internal ListItemStateConstraint IsIndexValid { get; set; }

  internal ListItemImageConstraint IndexImage { get; set; }

  internal bool SerializeItems { get; set; }

  internal bool UndoIgnoresSelection { get; set; }

  internal AcpListField BuddyList { get; set; }

  internal int ItemCount => this.itemVisibilities.Count;

  internal void SetItemVisibility(int index, bool visibility)
  {
    if (index >= this.itemVisibilities.Count)
      return;
    this.itemVisibilities[index] = visibility;
  }

  internal bool GetItemVisibility(int index)
  {
    return index >= this.itemVisibilities.Count || this.itemVisibilities[index];
  }

  internal void DoubleItems()
  {
    BitArray bitArray = new BitArray(this.itemVisibilities.Count * 2, true);
    for (int index = 0; index < this.itemVisibilities.Count; ++index)
      bitArray.Set(index, this.itemVisibilities[index]);
    this.itemVisibilities = bitArray;
  }
}
