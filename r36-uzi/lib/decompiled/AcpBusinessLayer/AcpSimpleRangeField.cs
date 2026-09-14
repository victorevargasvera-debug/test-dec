// Decompiled with JetBrains decompiler
// Type: AcpBusinessLayer.AcpSimpleRangeField
// Assembly: AcpBusinessLayer, Version=23.1.0.23, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 44CF2A76-4418-422B-9DDD-B27A71BAF20C
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpBusinessLayer.dll

using AcpBusinessLayer.ValueConverters;
using System.Windows.Data;

#nullable disable
namespace AcpBusinessLayer;

public class AcpSimpleRangeField : AcpCustomRangeField
{
  public AcpSimpleRangeField(
    int value,
    FeatureSection parent,
    string name,
    string uiName,
    string minLabel,
    string maxLabel,
    int uiOffset,
    int uiMultiplier)
    : base(value, (IValueConverter) new FactorByConverter(uiMultiplier, uiOffset), parent, name, uiName, minLabel, maxLabel)
  {
  }

  public AcpSimpleRangeField(
    int value,
    FeatureSection parent,
    string name,
    string uiName,
    string minLabel,
    string maxLabel,
    int uiOffset,
    int uiMultiplier,
    string[] legacyUILabels)
    : base(value, (IValueConverter) new FactorByConverter(uiMultiplier, uiOffset), parent, name, uiName, minLabel, maxLabel, legacyUILabels)
  {
  }

  public AcpSimpleRangeField(
    int value,
    FeatureSection parent,
    string name,
    string uiName,
    int min,
    int max,
    string minLabel,
    string maxLabel,
    int uiOffset,
    int uiMultiplier)
    : base(value, (IValueConverter) new FactorByConverter(uiMultiplier, uiOffset), parent, name, uiName, min, max, 1, minLabel, maxLabel)
  {
  }

  public AcpSimpleRangeField(
    int value,
    FeatureSection parent,
    string name,
    string uiName,
    int min,
    int max,
    string minLabel,
    string maxLabel,
    int uiOffset,
    int uiMultiplier,
    string[] legacyUILabels)
    : base(value, (IValueConverter) new FactorByConverter(uiMultiplier, uiOffset), parent, name, uiName, min, max, 1, minLabel, maxLabel, legacyUILabels)
  {
  }

  public AcpSimpleRangeField(
    int value,
    IValueConverter converter,
    FeatureSection parent,
    string name,
    string uiName,
    int min,
    int max,
    string minLabel,
    string maxLabel)
    : base(value, converter, parent, name, uiName, min, max, 1, minLabel, maxLabel)
  {
  }
}
