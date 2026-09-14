// Decompiled with JetBrains decompiler
// Type: AcpBusinessLayer.Impl.AcpRangeFieldImpl
// Assembly: AcpBusinessLayer, Version=23.1.0.23, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 44CF2A76-4418-422B-9DDD-B27A71BAF20C
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpBusinessLayer.dll

#nullable disable
namespace AcpBusinessLayer.Impl;

internal class AcpRangeFieldImpl : AcpFieldImpl<int>
{
  internal AcpRangeFieldImpl(string uiName)
    : base(uiName)
  {
    this.Min = 0;
    this.Max = int.MaxValue;
    this.StepSize = 1;
  }

  internal int Min { get; set; }

  internal int Max { get; set; }

  internal int StepSize { get; set; }
}
