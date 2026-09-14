// Decompiled with JetBrains decompiler
// Type: AcpBusinessLayer.Impl.AcpRecRefFieldImpl
// Assembly: AcpBusinessLayer, Version=23.1.0.23, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 44CF2A76-4418-422B-9DDD-B27A71BAF20C
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpBusinessLayer.dll

using AcpCommonResources;

#nullable disable
namespace AcpBusinessLayer.Impl;

internal class AcpRecRefFieldImpl : AcpListFieldImpl
{
  internal AcpRecRefFieldImpl(string uiName)
    : base(uiName)
  {
    this.InvalidText = AcpResources.Null_Id;
  }

  internal string InvalidText { get; set; }

  internal bool IsFirstRecDefault { get; set; }

  internal int IndexBase { get; set; }

  internal int PrependValue { get; set; }

  internal string PrependUIValue { get; set; }

  internal int PrependValue2 { get; set; }

  internal string PrependUIValue2 { get; set; }
}
