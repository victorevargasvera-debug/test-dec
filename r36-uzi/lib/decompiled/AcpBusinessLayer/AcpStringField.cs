// Decompiled with JetBrains decompiler
// Type: AcpBusinessLayer.AcpStringField
// Assembly: AcpBusinessLayer, Version=23.1.0.23, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 44CF2A76-4418-422B-9DDD-B27A71BAF20C
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpBusinessLayer.dll

using AcpCommonLib;
using System;
using System.Diagnostics;

#nullable disable
namespace AcpBusinessLayer;

[DebuggerDisplay("Name={UIName}, Value={Value}, MaxLength={MaxLength}")]
[Serializable]
public class AcpStringField : AcpField<string>
{
  private int maxLength = int.MaxValue;

  public AcpStringField(FeatureSection parent, string name, string uiLabel)
    : this(parent, name, uiLabel, int.MaxValue)
  {
  }

  public AcpStringField(
    FeatureSection parent,
    string name,
    string uiLabel,
    string[] legacyUILabels)
    : this(parent, name, uiLabel, int.MaxValue, legacyUILabels)
  {
  }

  public AcpStringField(string value, FeatureSection parent, string name, string uiLabel)
    : this(value, parent, name, uiLabel, int.MaxValue)
  {
  }

  public AcpStringField(
    string value,
    FeatureSection parent,
    string name,
    string uiLabel,
    string[] legacyUILabels)
    : this(value, parent, name, uiLabel, int.MaxValue, legacyUILabels)
  {
  }

  public AcpStringField(FeatureSection parent, string name, string uiLabel, int maxLength)
    : base(parent, name, uiLabel)
  {
    this.MaxLength = maxLength;
  }

  public AcpStringField(
    FeatureSection parent,
    string name,
    string uiLabel,
    int maxLength,
    string[] legacyUILabels)
    : base(parent, name, uiLabel, legacyUILabels)
  {
    this.MaxLength = maxLength;
  }

  public AcpStringField(
    string value,
    FeatureSection parent,
    string name,
    string uiLabel,
    int maxLength)
    : base(value, parent, name, uiLabel)
  {
    this.MaxLength = maxLength;
  }

  public AcpStringField(
    string value,
    FeatureSection parent,
    string name,
    string uiLabel,
    int maxLength,
    string[] legacyUILabels)
    : base(value, parent, name, uiLabel, legacyUILabels)
  {
    this.MaxLength = maxLength;
  }

  protected AcpStringField()
  {
  }

  public int MaxLength
  {
    get => this.maxLength;
    set => this.maxLength = value;
  }

  public override string Value
  {
    get => base.Value;
    set
    {
      if (value != null)
        this.ForceValid = this.CheckLength(value);
      base.Value = value;
    }
  }

  protected virtual bool CheckLength(string value) => value.Length <= this.MaxLength;

  internal override void DeepCopy(IAcpField source)
  {
    base.DeepCopy(source);
    if (this.Value == null)
      return;
    this.ForceValid = this.CheckLength(this.Value);
  }
}
