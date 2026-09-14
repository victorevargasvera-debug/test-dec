// Decompiled with JetBrains decompiler
// Type: AcpBusinessLayer.AcpNumericKeyField
// Assembly: AcpBusinessLayer, Version=23.1.0.23, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 44CF2A76-4418-422B-9DDD-B27A71BAF20C
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpBusinessLayer.dll

using AcpCommonLib;
using System;
using System.Globalization;

#nullable disable
namespace AcpBusinessLayer;

public class AcpNumericKeyField : AcpKeyField, IAcpRangeField
{
  public AcpNumericKeyField(FeatureSection parent, string name, string uiLabel)
    : base(parent, name, uiLabel)
  {
  }

  public AcpNumericKeyField(
    FeatureSection parent,
    string name,
    string uiLabel,
    string[] legacyUILabels)
    : base(parent, name, uiLabel, legacyUILabels)
  {
  }

  public AcpNumericKeyField(
    FeatureSection parent,
    string name,
    string uiLabel,
    int min,
    int max,
    int step)
    : base(parent, name, uiLabel)
  {
    this.Min = min;
    this.Max = max;
    this.StepSize = step;
  }

  public AcpNumericKeyField(
    FeatureSection parent,
    string name,
    string uiLabel,
    int min,
    int max,
    int step,
    string[] legacyUILabels)
    : base(parent, name, uiLabel, legacyUILabels)
  {
    this.Min = min;
    this.Max = max;
    this.StepSize = step;
  }

  protected internal override void FirePropertyChangedEvent()
  {
    base.FirePropertyChangedEvent();
    if (!this.ShowHexValue)
      return;
    ((FeatureSection) this.Parent).FirePropertyChanged(this.Name + "_HexUIValue");
  }

  public int NumericValue
  {
    get
    {
      int result;
      return int.TryParse(this.Value, out result) ? result : -1;
    }
    set
    {
      if (value >= this.Min)
        this.Value = value.ToString();
      else
        this.SetUITimer();
    }
  }

  public override string Value
  {
    get => base.Value;
    set
    {
      int result;
      if (!int.TryParse(value, out result) || result < this.Min)
        return;
      base.Value = result.ToString();
    }
  }

  internal override int CompareToHelper(AcpFieldBase otherField)
  {
    return this.NumericValue.CompareTo(((AcpNumericKeyField) otherField).NumericValue);
  }

  public string HexUIValue
  {
    get
    {
      string format = "X";
      if (this.ShowLeadingZeros)
      {
        int length = this.Max.ToString("X").Trim().Length;
        if (length > 0)
          format += length.ToString();
      }
      return this.NumericValue.ToString(format);
    }
    set
    {
      int result;
      if (int.TryParse(value, NumberStyles.HexNumber, (IFormatProvider) null, out result) && result >= this.Min)
        this.NumericValue = result;
      this.SetUITimer();
    }
  }

  public bool ShowHexValue
  {
    get => (this.flags & AcpFieldBase.FieldFlags.ShowHexValue) != 0;
    set
    {
      if (value)
        this.flags |= AcpFieldBase.FieldFlags.ShowHexValue;
      else
        this.flags &= ~AcpFieldBase.FieldFlags.ShowHexValue;
    }
  }

  public bool ShowLeadingZeros
  {
    get => (this.flags & AcpFieldBase.FieldFlags.ShowLeadingZeros) != 0;
    set
    {
      if (value)
        this.flags |= AcpFieldBase.FieldFlags.ShowLeadingZeros;
      else
        this.flags &= ~AcpFieldBase.FieldFlags.ShowLeadingZeros;
    }
  }

  public int Min { get; set; }

  public int Max { get; set; }

  public int StepSize { get; set; }

  public void StepUp()
  {
    if (this.NumericValue < this.Max)
      this.NumericValue += this.StepSize;
    else
      this.NumericValue = this.Max;
  }

  public void StepDown()
  {
    if (this.NumericValue > this.Min)
      this.NumericValue -= this.StepSize;
    else
      this.NumericValue = this.Min;
  }
}
