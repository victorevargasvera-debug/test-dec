// Decompiled with JetBrains decompiler
// Type: AcpBusinessLayer.AcpPointerField`1
// Assembly: AcpBusinessLayer, Version=23.1.0.23, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 44CF2A76-4418-422B-9DDD-B27A71BAF20C
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpBusinessLayer.dll

using AcpCommonLib;
using AcpCommonLib.UndoRedo;
using System;

#nullable disable
namespace AcpBusinessLayer;

public class AcpPointerField<TDBType> : AcpFieldX<TDBType, string>, IAcpPointerField where TDBType : IComparable
{
  private AcpField<TDBType> pointedField;
  private TDBType defaultValue;
  private string defaultUIValue;

  public IAcpField PointedField
  {
    get => (IAcpField) this.pointedField;
    set
    {
      if (value != null)
      {
        this.pointedField = value as AcpField<TDBType>;
        this.ShowHexValue = this.pointedField is IAcpRangeField && ((IAcpRangeField) this.pointedField).ShowHexValue;
      }
      else
        this.pointedField = (AcpField<TDBType>) null;
      this.FirePropertyChangedEvent();
    }
  }

  protected AcpPointerField(FeatureSection parent, string name, string uiLabel)
    : base(parent, name, uiLabel)
  {
  }

  public AcpPointerField(
    TDBType defaultValue,
    FeatureSection parent,
    string name,
    string uiLabel,
    string defaultUIValue)
    : base(parent, name, uiLabel)
  {
    this.defaultValue = defaultValue;
    this.defaultUIValue = defaultUIValue;
  }

  public AcpPointerField(
    TDBType defaultValue,
    FeatureSection parent,
    string name,
    string uiLabel,
    string defaultUIValue,
    string[] legacyUILabels)
    : base(parent, name, uiLabel, legacyUILabels)
  {
    this.defaultValue = defaultValue;
    this.defaultUIValue = defaultUIValue;
  }

  internal override void DeepCopy(IAcpField source)
  {
  }

  public override UndoableTask CopyValueOf(IAcpField source) => (UndoableTask) null;

  public override void ResetToDefault()
  {
  }

  public override TDBType Value
  {
    get => this.pointedField == null ? this.defaultValue : this.pointedField.Value;
    set
    {
    }
  }

  public override string UIValue
  {
    get => this.pointedField == null ? this.defaultUIValue : this.pointedField.ToString();
    set
    {
    }
  }

  protected internal override void FirePropertyChangedEvent()
  {
    base.FirePropertyChangedEvent();
    if (!this.ShowHexValue)
      return;
    ((FeatureSection) this.Parent).FirePropertyChanged(this.Name + "_HexUIValue");
  }

  public string HexUIValue
  {
    get
    {
      if (!this.ShowHexValue)
        return (string) null;
      if (this.pointedField != null)
        return ((IAcpRangeField) this.PointedField).HexUIValue;
      int num;
      try
      {
        num = Convert.ToInt32(this.defaultUIValue);
      }
      catch (Exception ex)
      {
        num = 1;
      }
      return num.ToString("X");
    }
    set
    {
    }
  }

  public bool ShowHexValue { get; private set; }
}
