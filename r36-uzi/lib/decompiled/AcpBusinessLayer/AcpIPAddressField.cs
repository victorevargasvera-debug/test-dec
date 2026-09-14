// Decompiled with JetBrains decompiler
// Type: AcpBusinessLayer.AcpIPAddressField
// Assembly: AcpBusinessLayer, Version=23.1.0.23, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 44CF2A76-4418-422B-9DDD-B27A71BAF20C
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpBusinessLayer.dll

using AcpBusinessLayer.UndoRedo;
using AcpBusinessLayer.ValueConverters;
using AcpCommonLib;
using AcpCommonLib.UndoRedo;
using System;
using System.Globalization;
using System.Windows.Data;

#nullable disable
namespace AcpBusinessLayer;

[Serializable]
public class AcpIPAddressField : AcpFieldX<long, string>
{
  public AcpIPAddressField(FeatureSection parent, string name, string uiLabel)
    : base(parent, name, uiLabel)
  {
    this.Converter = (IValueConverter) new IPAddressConverter();
    if (this.Parent.Parent == null)
      return;
    ((FeatureNode) this.Parent.Parent).RegisterValidity((IAcpField) this);
  }

  public AcpIPAddressField(
    FeatureSection parent,
    string name,
    string uiLabel,
    string[] legacyUILabels)
    : base(parent, name, uiLabel, legacyUILabels)
  {
    this.Converter = (IValueConverter) new IPAddressConverter();
    if (this.Parent.Parent == null)
      return;
    ((FeatureNode) this.Parent.Parent).RegisterValidity((IAcpField) this);
  }

  public AcpIPAddressField(long value, FeatureSection parent, string name, string uiLabel)
    : base(value, parent, name, uiLabel)
  {
    this.Converter = (IValueConverter) new IPAddressConverter();
    this.ForceValid = this.ValidateHelper();
    if (this.Parent.Parent == null)
      return;
    ((FeatureNode) this.Parent.Parent).RegisterValidity((IAcpField) this);
  }

  public AcpIPAddressField(
    long value,
    FeatureSection parent,
    string name,
    string uiLabel,
    string[] legacyUILabels)
    : base(value, parent, name, uiLabel, legacyUILabels)
  {
    this.Converter = (IValueConverter) new IPAddressConverter();
    this.ForceValid = this.ValidateHelper();
    if (this.Parent.Parent == null)
      return;
    ((FeatureNode) this.Parent.Parent).RegisterValidity((IAcpField) this);
  }

  private byte[] GetAddressBytes(bool asV6)
  {
    if (asV6)
      throw new NotImplementedException();
    long num = this.Value;
    return new byte[4]
    {
      (byte) num,
      (byte) (num >> 8),
      (byte) (num >> 16 /*0x10*/),
      (byte) (num >> 24)
    };
  }

  public byte[] AddressBytes
  {
    get
    {
      byte[] addressBytes = new byte[16 /*0x10*/];
      this.GetAddressBytes(false).CopyTo((Array) addressBytes, 12);
      return addressBytes;
    }
    set
    {
      this.Value = (long) value[12] + ((long) value[13] << 8) + ((long) value[14] << 16 /*0x10*/) + ((long) value[15] << 24);
      this.ForceValid = this.ValidateHelper();
    }
  }

  public override void ParseDefaultValueFrom(string value)
  {
    try
    {
      this.DefaultValue = (long) this.Converter.ConvertBack((object) value, (Type) null, (object) this.Parent, (CultureInfo) null);
    }
    catch
    {
    }
  }

  public override void ParseValueFrom(string value)
  {
    try
    {
      this.UnsupportedValue = false;
      this.ForceValid = this.ValidateHelper();
      this.UIValue = value;
    }
    catch (Exception ex)
    {
      this.UnsupportedValue = true;
    }
  }

  public override void CalculateValidity()
  {
    if (AcpDocument.Closing || !this.Applicable || this.UIInvalid || !this.ForceValid)
      return;
    this.ValidityHelper();
  }

  public override void SetValue(long newValue)
  {
    FeatureNode parent1 = (FeatureNode) this.Parent.Parent;
    if (parent1 != null && newValue.CompareTo(this.Value) != 0)
    {
      Recordset parent2 = (Recordset) parent1.Parent;
      if (parent2 != null)
      {
        Document containerDoc = parent2.ContainerDoc;
        if (containerDoc != null && containerDoc.ModificationLogEnabled)
          containerDoc.AddToModificationLog(this.BuildModificationLog(this.Value, newValue));
      }
    }
    this.SetValueNoConstraints(newValue);
    this.ValueChanged = true;
    this.ForceValid = this.ValidateHelper();
    this.UIInvalid = !this.ForceValid;
    if (!ConstraintManager.Suspended)
      this.CallConstraintsX();
    this.SetUITimer();
    this.FirePropertyChangedEvent();
  }

  public override long Value
  {
    get => base.Value;
    set
    {
      base.Value = value;
      if (!this.UIInvalid)
        return;
      this.DirectUIValue = this.Converter.Convert((object) value, (Type) null, (object) null, (CultureInfo) null).ToString();
    }
  }

  public override UndoableTask CopyValueOf(IAcpField source)
  {
    SetValueTask task = (SetValueTask) null;
    if (!this.Value.Equals(((AcpField<long>) source).Value))
    {
      task = new SetValueTask((AcpFieldBase) this, source.ToString());
      if (this.ValueSetter != null)
      {
        ContainerTask containerTask = new ContainerTask(task.ToString());
        containerTask.AddTask((UndoableTask) task);
        this.CallValueSetter(containerTask);
        return (UndoableTask) containerTask;
      }
    }
    return (UndoableTask) task;
  }

  public bool SkipValidation
  {
    get => (this.flags & AcpFieldBase.FieldFlags.SkipValidation) != 0;
    set
    {
      if (!value)
        throw new InvalidOperationException("This property cannot be reset.");
      this.flags |= AcpFieldBase.FieldFlags.SkipValidation;
    }
  }

  protected override bool ValidateHelper()
  {
    if (this.Value == 0L || this.SkipValidation)
      return true;
    byte[] addressBytes = this.GetAddressBytes(false);
    byte num = addressBytes[0];
    if (num > (byte) 223 || num == (byte) 127 /*0x7F*/ || num == (byte) 0)
      return false;
    if (num >= (byte) 192 /*0xC0*/)
    {
      if (num == (byte) 192 /*0xC0*/ && addressBytes[1] == (byte) 0 && addressBytes[2] == (byte) 0 || addressBytes[3] == (byte) 0 || addressBytes[3] == byte.MaxValue)
        return false;
    }
    else if (num >= (byte) 128 /*0x80*/)
    {
      if (num == (byte) 128 /*0x80*/ && addressBytes[1] == (byte) 0 || addressBytes[2] == byte.MaxValue && addressBytes[3] == byte.MaxValue || addressBytes[2] == (byte) 0 && addressBytes[3] == (byte) 0)
        return false;
    }
    else if (addressBytes[1] == (byte) 0 && addressBytes[2] == (byte) 0 && addressBytes[3] == (byte) 0 || addressBytes[1] == byte.MaxValue && addressBytes[2] == byte.MaxValue && addressBytes[3] == byte.MaxValue)
      return false;
    return true;
  }
}
