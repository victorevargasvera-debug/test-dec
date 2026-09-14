// Decompiled with JetBrains decompiler
// Type: AcpBusinessLayer.AcpFrequencyField
// Assembly: AcpBusinessLayer, Version=23.1.0.23, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 44CF2A76-4418-422B-9DDD-B27A71BAF20C
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpBusinessLayer.dll

using AcpBusinessLayer.ValueConverters;
using AcpCommonLib;
using System;
using System.Windows.Data;

#nullable disable
namespace AcpBusinessLayer;

[Serializable]
public class AcpFrequencyField : AcpRangeField<int, string>
{
  public AcpFrequencyField(int value, FeatureSection parent, string name, string uiLabel)
    : base(value, (IValueConverter) null, parent, name, uiLabel)
  {
    this.Converter = (IValueConverter) new FrequencyConverter(this.StepSize);
  }

  public AcpFrequencyField(
    int value,
    FeatureSection parent,
    string name,
    string uiLabel,
    string[] legacyUILabels)
    : base(value, (IValueConverter) null, parent, name, uiLabel, legacyUILabels)
  {
    this.Converter = (IValueConverter) new FrequencyConverter(this.StepSize);
  }

  public AcpFrequencyField(
    int value,
    FeatureSection parent,
    string name,
    string uiLabel,
    bool kilohertz)
    : base(value, (IValueConverter) null, parent, name, uiLabel)
  {
    this.Converter = (IValueConverter) new FrequencyConverter(kilohertz, this.StepSize);
  }

  public AcpFrequencyField(
    int value,
    FeatureSection parent,
    string name,
    string uiLabel,
    bool kilohertz,
    string[] legacyUILabels)
    : base(value, (IValueConverter) null, parent, name, uiLabel, legacyUILabels)
  {
    this.Converter = (IValueConverter) new FrequencyConverter(kilohertz, this.StepSize);
  }

  public AcpFrequencyField(FeatureSection parent, string name, string uiLabel)
    : base((IValueConverter) null, parent, name, uiLabel)
  {
    this.Converter = (IValueConverter) new FrequencyConverter(this.StepSize);
  }

  public AcpFrequencyField(FeatureSection parent, string name, string uiLabel, bool kilohertz)
    : base((IValueConverter) null, parent, name, uiLabel)
  {
    this.Converter = (IValueConverter) new FrequencyConverter(kilohertz, this.StepSize);
  }

  public AcpFrequencyField(
    FeatureSection parent,
    string name,
    string uiLabel,
    bool kilohertz,
    string[] legacyUILabels)
    : base((IValueConverter) null, parent, name, uiLabel, legacyUILabels)
  {
    this.Converter = (IValueConverter) new FrequencyConverter(kilohertz, this.StepSize);
  }

  public AcpFrequencyField(
    FeatureSection parent,
    string name,
    string uiLabel,
    int min,
    int max,
    int step)
    : base((IValueConverter) new FrequencyConverter(step), parent, name, uiLabel, min, max, step)
  {
  }

  public AcpFrequencyField(
    FeatureSection parent,
    string name,
    string uiLabel,
    int min,
    int max,
    int step,
    string[] legacyUILabels)
    : base((IValueConverter) new FrequencyConverter(step), parent, name, uiLabel, min, max, step, legacyUILabels)
  {
  }

  public AcpFrequencyField(
    int value,
    FeatureSection parent,
    string name,
    string uiLabel,
    int min,
    int max,
    int step)
    : base(value, (IValueConverter) new FrequencyConverter(step), parent, name, uiLabel, min, max, step)
  {
  }

  public AcpFrequencyField(
    int value,
    FeatureSection parent,
    string name,
    string uiLabel,
    int min,
    int max,
    int step,
    string[] legacyUILabels)
    : base(value, (IValueConverter) new FrequencyConverter(step), parent, name, uiLabel, min, max, step, legacyUILabels)
  {
  }

  public AcpFrequencyField(
    FeatureSection parent,
    string name,
    string uiLabel,
    int min,
    int max,
    int step,
    bool kilohertz)
    : base((IValueConverter) new FrequencyConverter(kilohertz, step), parent, name, uiLabel, min, max, step)
  {
  }

  public AcpFrequencyField(
    int value,
    FeatureSection parent,
    string name,
    string uiLabel,
    int min,
    int max,
    int step,
    bool kilohertz)
    : base(value, (IValueConverter) new FrequencyConverter(kilohertz, step), parent, name, uiLabel, min, max, step)
  {
  }

  public AcpFrequencyField(
    int value,
    FeatureSection parent,
    string name,
    string uiLabel,
    int min,
    int max,
    int step,
    bool kilohertz,
    string[] legacyUILabels)
    : base(value, (IValueConverter) new FrequencyConverter(kilohertz, step), parent, name, uiLabel, min, max, step, legacyUILabels)
  {
  }

  public override int Value
  {
    get => base.Value;
    set
    {
      base.Value = value;
      if (ConstraintManager.Suspended)
        return;
      this.CalculateApplicability();
      this.CalculateValidity();
    }
  }
}
