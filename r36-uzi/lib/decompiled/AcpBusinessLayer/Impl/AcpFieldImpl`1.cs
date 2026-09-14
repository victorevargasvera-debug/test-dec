// Decompiled with JetBrains decompiler
// Type: AcpBusinessLayer.Impl.AcpFieldImpl`1
// Assembly: AcpBusinessLayer, Version=23.1.0.23, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 44CF2A76-4418-422B-9DDD-B27A71BAF20C
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpBusinessLayer.dll

#nullable disable
namespace AcpBusinessLayer.Impl;

internal class AcpFieldImpl<TDBType> : AcpFieldImplBase
{
  internal AcpFieldImpl(string uiName)
    : base(uiName)
  {
  }

  internal TDBType DefaultValue { get; set; }
}
