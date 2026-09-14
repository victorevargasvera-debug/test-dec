// Decompiled with JetBrains decompiler
// Type: AcpBusinessLayer.AcpCustomRangeField
// Assembly: AcpBusinessLayer, Version=23.1.0.23, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 44CF2A76-4418-422B-9DDD-B27A71BAF20C
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpBusinessLayer.dll

using AcpBusinessLayer.ValueConverters;
using System;
using System.Collections.Generic;
using System.Windows.Data;

#nullable disable
namespace AcpBusinessLayer;

[Serializable]
public class AcpCustomRangeField : AcpRangeField<int, string>
{
  private Dictionary<int, string> customValues;
  private string minLabel;
  private string maxLabel;

  public AcpCustomRangeField(
    int value,
    IValueConverter converter,
    FeatureSection parent,
    string name,
    string uiLabel,
    string minLabel,
    string maxLabel)
    : base(value, converter, parent, name, uiLabel)
  {
    this.minLabel = minLabel;
    this.maxLabel = maxLabel;
  }

  public AcpCustomRangeField(
    int value,
    IValueConverter converter,
    FeatureSection parent,
    string name,
    string uiLabel,
    string minLabel,
    string maxLabel,
    string[] legacyUILabels)
    : base(value, converter, parent, name, uiLabel, legacyUILabels)
  {
    this.minLabel = minLabel;
    this.maxLabel = maxLabel;
  }

  public AcpCustomRangeField(
    FeatureSection parent,
    string name,
    string uiLabel,
    string minLabel,
    string maxLabel)
    : base((IValueConverter) new Int32ToStringConverter(), parent, name, uiLabel)
  {
    this.minLabel = minLabel;
    this.maxLabel = maxLabel;
  }

  public AcpCustomRangeField(
    FeatureSection parent,
    string name,
    string uiLabel,
    string minLabel,
    string maxLabel,
    string[] legacyUILabels)
    : base((IValueConverter) new Int32ToStringConverter(), parent, name, uiLabel, legacyUILabels)
  {
    this.minLabel = minLabel;
    this.maxLabel = maxLabel;
  }

  public AcpCustomRangeField(
    int value,
    FeatureSection parent,
    string name,
    string uiLabel,
    string minLabel,
    string maxLabel)
    : base(value, (IValueConverter) new Int32ToStringConverter(), parent, name, uiLabel)
  {
    this.minLabel = minLabel;
    this.maxLabel = maxLabel;
  }

  public AcpCustomRangeField(
    int value,
    FeatureSection parent,
    string name,
    string uiLabel,
    string minLabel,
    string maxLabel,
    string[] legacyUILabels)
    : base(value, (IValueConverter) new Int32ToStringConverter(), parent, name, uiLabel, legacyUILabels)
  {
    this.minLabel = minLabel;
    this.maxLabel = maxLabel;
  }

  public AcpCustomRangeField(
    IValueConverter converter,
    FeatureSection parent,
    string name,
    string uiLabel,
    string minLabel,
    string maxLabel)
    : base(converter, parent, name, uiLabel)
  {
    this.minLabel = minLabel;
    this.maxLabel = maxLabel;
  }

  public AcpCustomRangeField(
    IValueConverter converter,
    FeatureSection parent,
    string name,
    string uiLabel,
    string minLabel,
    string maxLabel,
    string[] legacyUILabels)
    : base(converter, parent, name, uiLabel, legacyUILabels)
  {
    this.minLabel = minLabel;
    this.maxLabel = maxLabel;
  }

  public AcpCustomRangeField(
    FeatureSection parent,
    string name,
    string uiLabel,
    int min,
    int max,
    int step,
    string minLabel,
    string maxLabel)
    : base((IValueConverter) new Int32ToStringConverter(), parent, name, uiLabel, min, max, step)
  {
    this.minLabel = minLabel;
    this.maxLabel = maxLabel;
  }

  public AcpCustomRangeField(
    FeatureSection parent,
    string name,
    string uiLabel,
    int min,
    int max,
    int step,
    string minLabel,
    string maxLabel,
    string[] legacyUILabels)
    : base((IValueConverter) new Int32ToStringConverter(), parent, name, uiLabel, min, max, step, legacyUILabels)
  {
    this.minLabel = minLabel;
    this.maxLabel = maxLabel;
  }

  public AcpCustomRangeField(
    int value,
    IValueConverter converter,
    FeatureSection parent,
    string name,
    string uiLabel,
    int min,
    int max,
    int step,
    string minLabel,
    string maxLabel)
    : base(value, converter, parent, name, uiLabel, min, max, step)
  {
    this.minLabel = minLabel;
    this.maxLabel = maxLabel;
  }

  public AcpCustomRangeField(
    int value,
    IValueConverter converter,
    FeatureSection parent,
    string name,
    string uiLabel,
    int min,
    int max,
    int step,
    string minLabel,
    string maxLabel,
    string[] legacyUILabels)
    : base(value, converter, parent, name, uiLabel, min, max, step, legacyUILabels)
  {
    this.minLabel = minLabel;
    this.maxLabel = maxLabel;
  }

  public AcpCustomRangeField(
    int value,
    FeatureSection parent,
    string name,
    string uiLabel,
    int min,
    int max,
    int step,
    string minLabel,
    string maxLabel)
    : base(value, (IValueConverter) new Int32ToStringConverter(), parent, name, uiLabel, min, max, step)
  {
    this.minLabel = minLabel;
    this.maxLabel = maxLabel;
  }

  public AcpCustomRangeField(
    int value,
    FeatureSection parent,
    string name,
    string uiLabel,
    int min,
    int max,
    int step,
    string minLabel,
    string maxLabel,
    string[] legacyUILabels)
    : base(value, (IValueConverter) new Int32ToStringConverter(), parent, name, uiLabel, min, max, step, legacyUILabels)
  {
    this.minLabel = minLabel;
    this.maxLabel = maxLabel;
  }

  public AcpCustomRangeField(
    IValueConverter converter,
    FeatureSection parent,
    string name,
    string uiLabel,
    int min,
    int max,
    int step,
    string minLabel,
    string maxLabel)
    : base(converter, parent, name, uiLabel, min, max, step)
  {
    this.minLabel = minLabel;
    this.maxLabel = maxLabel;
  }

  public AcpCustomRangeField(
    IValueConverter converter,
    FeatureSection parent,
    string name,
    string uiLabel,
    int min,
    int max,
    int step,
    string minLabel,
    string maxLabel,
    string[] legacyUILabels)
    : base(converter, parent, name, uiLabel, min, max, step, legacyUILabels)
  {
    this.minLabel = minLabel;
    this.maxLabel = maxLabel;
  }

  protected override bool CheckRange(int value)
  {
    return this.customValues != null && this.customValues.ContainsKey(value) || base.CheckRange(value);
  }

  public override int Value
  {
    get => base.Value;
    set
    {
      int num = this.UIInvalid ? 1 : 0;
      this.UIInvalid = false;
      base.Value = value;
      this.ValueChanged = true;
      if (num == 0)
        return;
      this.FirePropertyChangedEvent();
    }
  }

  public override string UIValue
  {
    get
    {
      if (this.UIInvalid)
        return this.DirectUIValue;
      if (this.minLabel != null && this.Value == this.Min)
        return this.minLabel;
      if (this.maxLabel != null && this.Value == this.Max)
        return this.maxLabel;
      return this.customValues != null && this.customValues.ContainsKey(this.Value) ? this.customValues[this.Value] : base.UIValue;
    }
    set
    {
      if (value == this.UIValue)
        return;
      if (value == string.Empty)
        this.Value = this.Min;
      else if (this.minLabel != null && value != null && this.minLabel.StartsWith(value, StringComparison.CurrentCultureIgnoreCase))
        this.Value = this.Min;
      else if (this.maxLabel != null && value != null && this.maxLabel.StartsWith(value, StringComparison.CurrentCultureIgnoreCase))
      {
        this.Value = this.Max;
      }
      else
      {
        if (this.customValues != null && value != null)
        {
          foreach (KeyValuePair<int, string> customValue in this.customValues)
          {
            if (customValue.Value.StartsWith(value, StringComparison.CurrentCultureIgnoreCase))
            {
              this.Value = customValue.Key;
              this.FirePropertyChangedEvent();
              if (!(this.UIValue != value))
                return;
              this.SetUITimer();
              return;
            }
          }
        }
        base.UIValue = value;
      }
      this.FirePropertyChangedEvent();
      if (!(this.UIValue != value) || !this.IsUISpecial)
        return;
      this.SetUITimer();
    }
  }

  private bool IsUISpecial
  {
    get
    {
      if (this.Value == this.Min || this.Value == this.Max)
        return true;
      if (this.customValues != null)
      {
        foreach (KeyValuePair<int, string> customValue in this.customValues)
        {
          if (customValue.Key == this.Value)
            return true;
        }
      }
      return false;
    }
  }

  public void AddCustomValue(int customValue, string label)
  {
    if (this.customValues == null)
      this.customValues = new Dictionary<int, string>();
    this.CustomValueOutOfRange = !base.CheckRange(customValue);
    if (this.CustomValueOutOfRange && customValue == this.Value)
    {
      this.ForceValid = true;
      this.UIInvalid = false;
    }
    this.customValues[customValue] = label;
  }

  public void ReplaceCustomValue(int customValue, string label)
  {
    this.customValues.Clear();
    this.customValues[customValue] = label;
    this.FirePropertyChangedEvent();
  }

  private bool CustomValueOutOfRange
  {
    get => (this.flags & AcpFieldBase.FieldFlags.HasSpecialRange) != 0;
    set
    {
      if (value)
        this.flags |= AcpFieldBase.FieldFlags.HasSpecialRange;
      else
        this.flags &= ~AcpFieldBase.FieldFlags.HasSpecialRange;
    }
  }

  public override void StepUp()
  {
    if (this.CustomValueOutOfRange && this.Value == this.Max)
    {
      foreach (int key in this.customValues.Keys)
      {
        if (!base.CheckRange(key))
        {
          this.Value = key;
          break;
        }
      }
    }
    else
      base.StepUp();
  }

  public override void StepDown()
  {
    if (this.CustomValueOutOfRange && this.Value == this.Min)
    {
      foreach (int key in this.customValues.Keys)
      {
        if (!base.CheckRange(key))
        {
          this.Value = key;
          break;
        }
      }
    }
    else
      base.StepDown();
  }

  public string GetSpecialValue(int value)
  {
    if (this.minLabel != null && value == this.Min)
      return this.minLabel;
    if (this.maxLabel != null && value == this.Max)
      return this.maxLabel;
    return this.customValues != null && this.customValues.ContainsKey(value) ? this.customValues[value] : (string) null;
  }

  public string GetSpecialValue(string value)
  {
    if (this.minLabel != null && this.minLabel.StartsWith(value, StringComparison.CurrentCultureIgnoreCase))
      return this.minLabel;
    if (this.maxLabel != null && this.maxLabel.StartsWith(value, StringComparison.CurrentCultureIgnoreCase))
      return this.maxLabel;
    if (this.customValues != null)
    {
      foreach (KeyValuePair<int, string> customValue in this.customValues)
      {
        if (customValue.Value.StartsWith(value, StringComparison.CurrentCultureIgnoreCase))
          return customValue.Value;
      }
    }
    return (string) null;
  }
}
