// Decompiled with JetBrains decompiler
// Type: AcpBusinessLayer.AcpSparseLOVField
// Assembly: AcpBusinessLayer, Version=23.1.0.23, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 44CF2A76-4418-422B-9DDD-B27A71BAF20C
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpBusinessLayer.dll

using AcpBusinessLayer.UndoRedo;
using AcpCommonLib;
using AcpCommonLib.UndoRedo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Data;

#nullable disable
namespace AcpBusinessLayer;

[Serializable]
public class AcpSparseLOVField : AcpListField
{
  private int currentValue;
  private Dictionary<string, Recordset> buddyRecsets;
  private AcpRecRefField buddyRecRefField;

  private AcpSparseLOVField()
  {
  }

  public AcpSparseLOVField(
    IValueConverter converter,
    FeatureSection parent,
    string name,
    string uiLabel,
    string[] items)
    : base(parent, name, uiLabel, items)
  {
    this.Converter = converter;
    this.UIValue = items[0];
  }

  public AcpSparseLOVField(
    IValueConverter converter,
    FeatureSection parent,
    string name,
    string uiLabel,
    string[] items,
    string[] legacyUILabels)
    : base(parent, name, uiLabel, items, legacyUILabels)
  {
    this.Converter = converter;
    this.UIValue = items[0];
  }

  public AcpSparseLOVField(
    int value,
    IValueConverter converter,
    FeatureSection parent,
    string name,
    string uiLabel,
    string[] items)
    : base(value, parent, name, uiLabel, items)
  {
    this.Converter = converter;
  }

  public AcpSparseLOVField(
    int value,
    IValueConverter converter,
    FeatureSection parent,
    string name,
    string uiLabel,
    string[] items,
    string[] legacyUILabels)
    : base(value, parent, name, uiLabel, items, legacyUILabels)
  {
    this.Converter = converter;
  }

  public AcpSparseLOVField(
    int value,
    IValueConverter converter,
    FeatureSection parent,
    string name,
    string uiLabel,
    bool sortItems,
    string[] items)
    : base(value, parent, name, uiLabel, sortItems, items)
  {
    this.Converter = converter;
  }

  public AcpSparseLOVField(
    int value,
    IValueConverter converter,
    FeatureSection parent,
    string name,
    string uiLabel,
    bool sortItems,
    string[] items,
    string[] legacyUILabels)
    : base(value, parent, name, uiLabel, sortItems, items, legacyUILabels)
  {
    this.Converter = converter;
  }

  public AcpSparseLOVField(
    IValueConverter converter,
    FeatureSection parent,
    string name,
    string uiLabel,
    bool serializeItems)
    : base(parent, name, uiLabel, serializeItems)
  {
    this.Converter = converter;
  }

  public AcpSparseLOVField(
    int value,
    IValueConverter converter,
    FeatureSection parent,
    string name,
    string uiLabel,
    bool serializeItems)
    : base(value, parent, name, uiLabel, serializeItems)
  {
    this.Converter = converter;
  }

  public AcpSparseLOVField(
    IValueConverter converter,
    FeatureSection parent,
    string name,
    string uiLabel,
    string[] items,
    bool serializeItems)
    : base(parent, name, uiLabel, items, serializeItems)
  {
    this.Converter = converter;
    this.UIValue = items[0];
  }

  public AcpSparseLOVField(
    IValueConverter converter,
    FeatureSection parent,
    string name,
    string uiLabel,
    string[] items,
    bool serializeItems,
    string[] legacyUILabels)
    : base(parent, name, uiLabel, items, serializeItems, legacyUILabels)
  {
    this.Converter = converter;
    this.UIValue = items[0];
  }

  public override int Value
  {
    get => this.currentValue;
    set
    {
      if (UndoManager.MarkForUndo)
        UndoManager.AddTask(this.GetModifyDataTask(value));
      else
        this.SetValue(value);
    }
  }

  public new UndoableTask GetModifyDataTask(int newValue)
  {
    ModifyDataTask<int> task = (ModifyDataTask<int>) null;
    this.UnsupportedValue = false;
    string strB = (string) this.Converter.Convert((object) newValue, (Type) null, (object) this.Parent, (CultureInfo) null);
    foreach (ListItem listItem in (Collection<ListItem>) this.Items)
    {
      if (listItem.ItemName.CompareTo(strB) == 0 && !listItem.ItemVisibility)
      {
        this.UnsupportedValue = true;
        break;
      }
    }
    if (!this.UnsupportedValue)
    {
      task = new ModifyDataTask<int>((AcpField<int>) this, newValue, this.buddyRecRefField != null ? new SetRefRecsetTask(this.buddyRecRefField, this.buddyRecsets[(string) this.Converter.Convert((object) newValue, (Type) null, (object) this.Parent, (CultureInfo) null)]) : (SetRefRecsetTask) null);
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

  public override string UIValue
  {
    get
    {
      string uiValue = string.Empty;
      try
      {
        uiValue = (string) this.Converter.Convert((object) this.Value, (Type) null, (object) this.Parent, (CultureInfo) null);
      }
      catch (Exception ex)
      {
      }
      return uiValue;
    }
    set
    {
      if (value == null)
        return;
      try
      {
        this.Value = (int) this.Converter.ConvertBack((object) value, (Type) null, (object) this.Parent, (CultureInfo) null);
      }
      catch (Exception ex)
      {
      }
    }
  }

  public void SetBuddyRecRefField(
    AcpRecRefField field,
    List<Recordset> refRecsets,
    List<string> resourceStrings)
  {
    this.buddyRecRefField = field;
    this.buddyRecsets = new Dictionary<string, Recordset>();
    if (refRecsets.Count > 1)
    {
      foreach (AcpRecRefSlaveItem slaveField in field.SlaveFields)
        slaveField.SlaveField.HasSiblingRecset = true;
    }
    for (int index1 = 0; index1 < this.Items.Count; ++index1)
    {
      if (resourceStrings.Contains(this.Items[index1].ItemName))
      {
        int index2 = resourceStrings.IndexOf(this.Items[index1].ItemName);
        this.buddyRecsets[this.Items[index1].ItemName] = refRecsets[index2];
      }
      else
        this.buddyRecsets[this.Items[index1].ItemName] = (Recordset) null;
    }
    this.buddyRecRefField.SetRecset((IAcpRecordset) this.buddyRecsets[this.UIValue]);
  }

  public IEnumerable<int> Values
  {
    get
    {
      AcpSparseLOVField acpSparseLovField = this;
      if (acpSparseLovField.Converter != null)
      {
        foreach (ListItem listItem in (Collection<ListItem>) acpSparseLovField.Items)
          yield return (int) acpSparseLovField.Converter.ConvertBack((object) listItem.ItemName, (Type) null, (object) __nonvirtual (acpSparseLovField.Parent), (CultureInfo) null);
      }
    }
  }

  public override void SetValue(int newValue)
  {
    FeatureNode parent1 = (FeatureNode) this.Parent.Parent;
    if (parent1 != null && newValue != this.currentValue)
    {
      Recordset parent2 = (Recordset) parent1.Parent;
      if (parent2 != null)
      {
        Document containerDoc = parent2.ContainerDoc;
        if (containerDoc != null && containerDoc.ModificationLogEnabled)
          containerDoc.AddToModificationLog(this.BuildModificationLog(this.currentValue, newValue));
      }
    }
    this.currentValue = newValue;
    this.ValueChanged = true;
    if (!ConstraintManager.Suspended)
      this.CallConstraintsX();
    this.FirePropertyChangedEvent();
  }

  internal void ReplaceAt(int index, int value)
  {
    this.RemoveItemAt(index);
    this.AddValue(value);
  }

  public void AddValue(int value)
  {
    this.AddItemHelper((string) this.Converter.Convert((object) value, (Type) null, (object) this.Parent, (CultureInfo) null));
    this.currentValue = value;
  }

  public override void CalculateItemsValidity()
  {
    if (this.IsIndexValid == null || this.Converter == null)
      return;
    ((FeatureSection) this.Parent).CurrentField = (IAcpField) this;
    foreach (ListItem listItem in (Collection<ListItem>) this.Items)
      listItem.ItemValidity = this.IsIndexValid(this.Parent, (int) this.Converter.ConvertBack((object) listItem.ItemName, (Type) null, this.ConverterParameterObject, (CultureInfo) null));
  }

  public override UndoableTask CopyValueOf(IAcpField source)
  {
    if (this.buddyRecRefField == null)
      return base.CopyValueOf(source);
    string uiValue = (source as AcpSparseLOVField).UIValue;
    return this.UIValue == null || !this.UIValue.Equals(uiValue) ? this.GetModifyDataTask(((AcpField<int>) source).Value) : base.CopyValueOf(source);
  }

  public override void ResetToDefaultWithUndo()
  {
    if (this.Value.CompareTo(this.DefaultValue) == 0)
      return;
    UndoManager.AddTask(this.GetModifyDataTask(this.DefaultValue));
  }

  public override void ResetToDefaultWithUndo(ContainerTask taskContainer)
  {
    if (taskContainer == null || this.Value.CompareTo(this.DefaultValue) == 0)
      return;
    taskContainer.AddTask(this.GetModifyDataTask(this.DefaultValue));
    this.SetUITimer();
  }
}
