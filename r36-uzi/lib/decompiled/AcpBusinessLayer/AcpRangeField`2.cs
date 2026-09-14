// Decompiled with JetBrains decompiler
// Type: AcpBusinessLayer.AcpRangeField`2
// Assembly: AcpBusinessLayer, Version=23.1.0.23, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 44CF2A76-4418-422B-9DDD-B27A71BAF20C
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpBusinessLayer.dll

using AcpBusinessLayer.Impl;
using AcpBusinessLayer.UndoRedo;
using AcpBusinessLayer.ValueConverters;
using AcpCommonLib;
using AcpCommonLib.UndoRedo;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;

#nullable disable
namespace AcpBusinessLayer;

[Serializable]
public class AcpRangeField<TDBType, TUIType> : AcpFieldX<int, TUIType>, IAcpRangeField
  where TDBType : IComparable
  where TUIType : IComparable
{
  public AcpRangeField(
    int value,
    IValueConverter converter,
    FeatureSection parent,
    string name,
    string uiLabel)
    : base(value, parent, name, uiLabel)
  {
    if (converter == null)
      this.Converter = (IValueConverter) new DummyConverter();
    else
      this.Converter = converter;
  }

  public AcpRangeField(
    int value,
    IValueConverter converter,
    FeatureSection parent,
    string name,
    string uiLabel,
    string[] legacyUILabels)
    : base(value, parent, name, uiLabel, legacyUILabels)
  {
    if (converter == null)
      this.Converter = (IValueConverter) new DummyConverter();
    else
      this.Converter = converter;
  }

  public AcpRangeField(
    IValueConverter converter,
    FeatureSection parent,
    string name,
    string uiLabel)
    : base(converter, parent, name, uiLabel)
  {
    if (converter == null)
      this.Converter = (IValueConverter) new DummyConverter();
    else
      this.Converter = converter;
  }

  public AcpRangeField(
    IValueConverter converter,
    FeatureSection parent,
    string name,
    string uiLabel,
    string[] legacyUILabels)
    : base(converter, parent, name, uiLabel, legacyUILabels)
  {
    if (converter == null)
      this.Converter = (IValueConverter) new DummyConverter();
    else
      this.Converter = converter;
  }

  public AcpRangeField(
    int value,
    IValueConverter converter,
    FeatureSection parent,
    string name,
    string uiLabel,
    int min,
    int max,
    int step)
    : base(value, parent, name, uiLabel)
  {
    this.StepSize = step > 0 ? step : 1;
    this.Min = min;
    this.Max = max;
    if (converter == null)
      this.Converter = (IValueConverter) new DummyConverter();
    else
      this.Converter = converter;
  }

  public AcpRangeField(
    int value,
    IValueConverter converter,
    FeatureSection parent,
    string name,
    string uiLabel,
    int min,
    int max,
    int step,
    string[] legacyUILabels)
    : base(value, parent, name, uiLabel, legacyUILabels)
  {
    this.StepSize = step > 0 ? step : 1;
    this.Min = min;
    this.Max = max;
    if (converter == null)
      this.Converter = (IValueConverter) new DummyConverter();
    else
      this.Converter = converter;
  }

  public AcpRangeField(
    IValueConverter converter,
    FeatureSection parent,
    string name,
    string uiLabel,
    int min,
    int max,
    int step)
    : base(min, parent, name, uiLabel)
  {
    this.StepSize = step > 0 ? step : 1;
    this.Min = min;
    this.Max = max;
    if (converter == null)
      this.Converter = (IValueConverter) new DummyConverter();
    else
      this.Converter = converter;
  }

  public AcpRangeField(
    IValueConverter converter,
    FeatureSection parent,
    string name,
    string uiLabel,
    int min,
    int max,
    int step,
    string[] legacyUILabels)
    : base(min, parent, name, uiLabel, legacyUILabels)
  {
    this.StepSize = step > 0 ? step : 1;
    this.Min = min;
    this.Max = max;
    if (converter == null)
      this.Converter = (IValueConverter) new DummyConverter();
    else
      this.Converter = converter;
  }

  public AcpRangeField(
    TUIType uiValue,
    IValueConverter converter,
    FeatureSection parent,
    string name,
    string uiLabel,
    int min,
    int max,
    int step)
    : base(uiValue, converter, parent, name, uiLabel)
  {
    this.StepSize = step > 0 ? step : 1;
    this.Min = min;
    this.Max = max;
    if (converter == null)
      this.Converter = (IValueConverter) new DummyConverter();
    else
      this.Converter = converter;
  }

  public override int Value
  {
    get => base.Value;
    set
    {
      bool uiInvalid = this.UIInvalid;
      bool forceValid = this.ForceValid;
      if (this.Value == value)
      {
        this.ForceValid = this.CheckRange(this.Value);
        if (!this.ForceValid || forceValid)
          return;
        this.CalculateValidityWithDep();
      }
      else
      {
        if (UndoManager.MarkForUndo)
        {
          if (!this.CheckRange(value))
          {
            try
            {
              UndoableTask task = (UndoableTask) new SetValueTask((AcpFieldBase) this, this.Converter.Convert((object) value, (Type) null, this.ConverterParameterObject, (CultureInfo) null).ToString());
              if (this.ValueSetter != null)
              {
                ContainerTask containerTask = new ContainerTask(task.ToString());
                containerTask.AddTask(task);
                this.CallValueSetter(containerTask);
                UndoManager.AddTask((UndoableTask) containerTask);
                this.SetUITimer();
                goto label_12;
              }
              UndoManager.AddTask(task);
              goto label_12;
            }
            catch
            {
              base.Value = value;
              this.ForceValid = this.CheckRange(this.Value);
              goto label_12;
            }
          }
        }
        base.Value = value;
        this.ForceValid = this.CheckRange(this.Value);
label_12:
        if (this.ForceValid && !forceValid)
          this.CalculateValidityWithDep();
        if (!uiInvalid && !this.UIInvalid)
          return;
        this.FirePropertyChangedEvent();
      }
    }
  }

  public override TUIType UIValue
  {
    get => base.UIValue;
    set => base.UIValue = value;
  }

  protected virtual bool CheckRange(int value)
  {
    return this.Min.CompareTo(value) <= 0 && this.Max.CompareTo(value) >= 0 && this.IsValueOnStep(value);
  }

  protected internal override void FirePropertyChangedEvent()
  {
    base.FirePropertyChangedEvent();
    if (!this.ShowHexValue)
      return;
    ((FeatureSection) this.Parent).FirePropertyChanged(this.Name + "_HexUIValue");
  }

  internal override void DeepCopy(IAcpField source)
  {
    base.DeepCopy(source);
    this.ForceValid = this.CheckRange(this.Value);
    this.UIValue = ((AcpFieldX<int, TUIType>) source).UIValue;
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
      return this.Value.ToString(format);
    }
    set
    {
      int result;
      if (int.TryParse(value, NumberStyles.HexNumber, (IFormatProvider) null, out result))
        this.Value = result;
      if (this.UIInvalid)
        this.DirectUIValue = (TUIType) this.Converter.Convert((object) this.Value, (Type) null, this.ConverterParameterObject, (CultureInfo) null);
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

  public int Min
  {
    get => ((AcpRangeFieldImpl) this.FieldData).Min;
    set => ((AcpRangeFieldImpl) this.FieldData).Min = value;
  }

  public int Max
  {
    get => ((AcpRangeFieldImpl) this.FieldData).Max;
    set => ((AcpRangeFieldImpl) this.FieldData).Max = value;
  }

  public int StepSize
  {
    get => ((AcpRangeFieldImpl) this.FieldData).StepSize;
    set => ((AcpRangeFieldImpl) this.FieldData).StepSize = value;
  }

  public virtual void StepUp()
  {
    if (this.Value >= this.Max || this.Value < this.Min)
      this.Value = this.Min;
    else if (this.ForceValid)
      this.Value += this.StepSize;
    else
      this.Value = this.RoundUp(this.Value);
    this.ForceValid = true;
    this.UIInvalid = false;
    this.SetUITimer();
  }

  public virtual void StepDown()
  {
    if (this.Value <= this.Min || this.Value > this.Max)
      this.Value = this.Max;
    else if (this.ForceValid)
      this.Value -= this.StepSize;
    else
      this.Value = this.RoundDown(this.Value);
    this.ForceValid = true;
    this.UIInvalid = false;
    this.SetUITimer();
  }

  public IEnumerable<TUIType> UIValues
  {
    get
    {
      AcpRangeField<TDBType, TUIType> acpRangeField = this;
      if (acpRangeField.Converter != null)
      {
        for (int i = __nonvirtual (acpRangeField.Min); i <= __nonvirtual (acpRangeField.Max); i += __nonvirtual (acpRangeField.StepSize))
          yield return (TUIType) acpRangeField.Converter.Convert((object) i, (Type) null, acpRangeField.ConverterParameterObject, (CultureInfo) null);
      }
    }
  }

  private bool IsValueOnStep(int value) => (value - this.Min) % this.StepSize == 0;

  private int RoundDown(int value)
  {
    return value < this.Min || value > this.Max ? this.Max : this.Min + this.StepSize * ((value - this.Min) / this.StepSize);
  }

  private int RoundUp(int value)
  {
    return value < this.Min || value >= this.Max ? this.Min : this.Min + this.StepSize * ((value - this.Min) / this.StepSize + 1);
  }

  internal override void CreateFieldData(string uiName)
  {
    this.FieldData = (AcpFieldImplBase) new AcpRangeFieldImpl(uiName);
  }

  internal override int CompareToHelper(AcpFieldBase otherField)
  {
    TUIType uiValue = ((AcpFieldX<int, TUIType>) otherField).UIValue;
    if (base.CompareToHelper(otherField) != 0)
      return this.UIValue.CompareTo((object) uiValue);
    return this.UIInvalid || otherField.UIInvalid ? this.UIValue.CompareTo((object) uiValue) : 0;
  }

  private UndoableTask CreateModifyUIValueTask(TUIType newUIValue)
  {
    ModifyUIValueTask<TUIType> task = new ModifyUIValueTask<TUIType>((AcpFieldBase) this, newUIValue);
    if (this.ValueSetter == null)
      return (UndoableTask) task;
    ContainerTask containerTask = new ContainerTask(task.ToString());
    containerTask.AddTask((UndoableTask) task);
    this.CallValueSetter(containerTask);
    return (UndoableTask) containerTask;
  }

  public override UndoableTask CopyValueOf(IAcpField source)
  {
    int num = ((AcpField<int>) source).Value;
    TUIType uiValue = ((AcpFieldX<int, TUIType>) source).UIValue;
    if (!this.Value.Equals(num))
      return base.CopyValueOf(source);
    return (object) this.UIValue == null || !this.UIValue.Equals((object) uiValue) ? this.CreateModifyUIValueTask(uiValue) : (UndoableTask) null;
  }
}
