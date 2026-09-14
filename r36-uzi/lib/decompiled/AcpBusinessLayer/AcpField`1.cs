// Decompiled with JetBrains decompiler
// Type: AcpBusinessLayer.AcpField`1
// Assembly: AcpBusinessLayer, Version=23.1.0.23, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 44CF2A76-4418-422B-9DDD-B27A71BAF20C
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpBusinessLayer.dll

using AcpBusinessLayer.Impl;
using AcpBusinessLayer.UndoRedo;
using AcpCommonLib;
using AcpCommonLib.UndoRedo;
using AcpCommonResources;
using AcpUtility;
using System;
using System.Diagnostics;
using System.Reflection;

#nullable disable
namespace AcpBusinessLayer;

[DebuggerDisplay("Name={UIName}, Value={Value}")]
[Serializable]
public class AcpField<TDBType> : AcpFieldBase where TDBType : IComparable
{
  private TDBType dataValue;

  public virtual TDBType DefaultValue
  {
    get => ((AcpFieldImpl<TDBType>) this.FieldData).DefaultValue;
    set => ((AcpFieldImpl<TDBType>) this.FieldData).DefaultValue = value;
  }

  protected AcpField()
  {
  }

  public AcpField(FeatureSection parent, string name, string uiLabel)
    : base(parent, name, uiLabel)
  {
    this.dataValue = default (TDBType);
  }

  public AcpField(FeatureSection parent, string name, string uiLabel, string[] legacyUILabels)
    : base(parent, name, uiLabel, legacyUILabels)
  {
    this.dataValue = default (TDBType);
  }

  public AcpField(TDBType value, FeatureSection parent, string name, string uiLabel)
    : this(parent, name, uiLabel)
  {
    TDBType dbType = value;
    if (this.DefaultSetByTiering)
      dbType = this.DefaultValue;
    try
    {
      int num = ConstraintManager.Suspend() ? 1 : 0;
      this.Value = dbType;
      if (num != 0)
        ConstraintManager.Resume();
    }
    catch (NullReferenceException ex)
    {
      this.dataValue = dbType;
    }
    if (AppInfoManager.DndOperation)
      return;
    this.DefaultValue = dbType;
  }

  public AcpField(
    TDBType value,
    FeatureSection parent,
    string name,
    string uiLabel,
    string[] legacyUILabels)
    : this(parent, name, uiLabel, legacyUILabels)
  {
    TDBType dbType = value;
    if (this.DefaultSetByTiering)
      dbType = this.DefaultValue;
    try
    {
      int num = ConstraintManager.Suspend() ? 1 : 0;
      this.Value = dbType;
      if (num != 0)
        ConstraintManager.Resume();
    }
    catch (NullReferenceException ex)
    {
      this.dataValue = dbType;
    }
    if (AppInfoManager.DndOperation)
      return;
    this.DefaultValue = dbType;
  }

  public virtual TDBType Value
  {
    get => this.dataValue;
    set
    {
      if (!this.UIInvalid && (object) this.Value != null && this.Value.Equals((object) value))
        return;
      if (UndoManager.MarkForUndo)
      {
        UndoableTask task = (UndoableTask) new ModifyDataTask<TDBType>(this, value);
        if (this.ValueSetter != null)
        {
          ContainerTask containerTask = new ContainerTask(task.ToString());
          containerTask.AddTask(task);
          this.CallValueSetter(containerTask);
          UndoManager.AddTask((UndoableTask) containerTask);
          this.SetUITimer();
        }
        else
          UndoManager.AddTask(task);
      }
      else
        this.SetValue(value);
    }
  }

  internal override string ValueString
  {
    get => (object) this.Value != null ? this.Value.ToString() : string.Empty;
  }

  internal override void ParseValueHelper(string value) => this.Value = this.Parse(value);

  internal override void CallValueSetter(ContainerTask containerTask)
  {
    if (this.ValueSetter == null || this.CallingValueSetter)
      return;
    this.CallingValueSetter = true;
    this.ValueSetter(this.Parent, containerTask);
    this.CallingValueSetter = false;
  }

  public virtual void SetValue(TDBType newValue)
  {
    FeatureNode parent1 = (FeatureNode) this.Parent.Parent;
    Document document = (Document) null;
    if (parent1 != null && (object) newValue != null && newValue.CompareTo((object) this.dataValue) != 0)
    {
      Recordset parent2 = (Recordset) parent1.Parent;
      if (parent2 != null)
      {
        document = parent2.ContainerDoc;
        if (document != null && document.ModificationLogEnabled)
          document.AddToModificationLog(this.BuildModificationLog(this.dataValue, newValue));
      }
    }
    bool oldKeyPresent = false;
    string oldKey = string.Empty;
    if (this.KeyNameField && document != null && document.IsOpen && ((FeatureSection) this.Parent).FeatureSectionName != null)
    {
      oldKey = parent1.ReferenceKey;
      oldKeyPresent = this.PreKeyMapUpdate();
    }
    if (this.NotifyPropertyChanging)
      this.FirePropertyChangingEvent();
    this.dataValue = newValue;
    if (!ConstraintManager.Suspended)
      this.CallConstraintsX();
    this.FirePropertyChangedEvent();
    this.ValueChanged = true;
    if (!this.KeyNameField || document == null || !document.IsOpen || ((FeatureSection) this.Parent).FeatureSectionName == null)
      return;
    this.PostKeyMapUpdate(oldKey, oldKeyPresent);
  }

  public static implicit operator TDBType(AcpField<TDBType> obj) => obj.dataValue;

  public override UndoableTask CopyValueOf(IAcpField source)
  {
    TDBType newValue = ((AcpField<TDBType>) source).Value;
    ModifyDataTask<TDBType> task = (ModifyDataTask<TDBType>) null;
    if (this.UIInvalid || (object) this.Value == null || !this.Value.Equals((object) newValue))
    {
      task = new ModifyDataTask<TDBType>(this, newValue);
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

  public override UndoableTask CopyValue(object sourcevalue)
  {
    TDBType newValue = (TDBType) sourcevalue;
    ModifyDataTask<TDBType> task = (ModifyDataTask<TDBType>) null;
    if (this.UIInvalid || (object) this.Value == null || !this.Value.Equals((object) newValue))
    {
      task = new ModifyDataTask<TDBType>(this, newValue);
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

  internal override void DeepCopy(IAcpField source)
  {
    this.SetValue(((AcpField<TDBType>) source).Value);
  }

  public override void ResetToDefault() => this.Value = this.DefaultValue;

  public override void ResetToDefaultWithUndo()
  {
    if (!UndoManager.MarkForUndo || (object) this.Value == null || this.Value.CompareTo((object) this.DefaultValue) == 0)
      return;
    UndoableTask task = (UndoableTask) new ModifyDataTask<TDBType>(this, this.DefaultValue);
    if (this.ValueSetter != null)
    {
      ContainerTask containerTask = new ContainerTask(task.ToString());
      containerTask.AddTask(task);
      this.CallValueSetter(containerTask);
      UndoManager.AddTask((UndoableTask) containerTask);
    }
    else
      UndoManager.AddTask(task);
  }

  public override void ResetToDefaultWithUndo(ContainerTask taskContainer)
  {
    if (taskContainer == null || (object) this.Value == null || this.Value.CompareTo((object) this.DefaultValue) == 0)
      return;
    UndoableTask task = (UndoableTask) new ModifyDataTask<TDBType>(this, this.DefaultValue);
    if (this.ValueSetter != null)
    {
      ContainerTask containerTask = new ContainerTask(task.ToString());
      containerTask.AddTask(task);
      this.CallValueSetter(containerTask);
      taskContainer.AddTask((UndoableTask) containerTask);
    }
    else
      taskContainer.AddTask(task);
  }

  public override void ParseValueFrom(string value) => this.Value = this.Parse(value);

  public override void ParseDefaultValueFrom(string value) => this.DefaultValue = this.Parse(value);

  private TDBType Parse(string value)
  {
    if (this.DataType == typeof (string))
      return (TDBType) value;
    try
    {
      this.UnsupportedValue = false;
      MethodInfo method = this.DataType.GetMethod(nameof (Parse), new Type[1]
      {
        typeof (string)
      });
      if (method != (MethodInfo) null)
        return (TDBType) method.Invoke((object) null, new object[1]
        {
          (object) value
        });
    }
    catch (Exception ex)
    {
      this.UnsupportedValue = true;
      return this.Value;
    }
    return default (TDBType);
  }

  public override Type DataType => typeof (TDBType);

  public override string ToString()
  {
    return (object) this.Value == null ? string.Empty : this.Value.ToString();
  }

  internal override int CompareToHelper(AcpFieldBase otherField)
  {
    AcpField<TDBType> acpField = (AcpField<TDBType>) otherField;
    if ((object) this.Value != null && !string.IsNullOrEmpty(this.Value.ToString()))
      return this.Value.CompareTo((object) acpField.Value);
    return (object) acpField.Value == null || string.IsNullOrEmpty(acpField.Value.ToString()) ? 0 : 1;
  }

  protected string BuildModificationLog(TDBType oldValue, TDBType newValue)
  {
    string str = AcpResources.Edited_Msg.AcpStringFormat((object) DateTime.Now.ToString(), (object) $"\"{this.UIName}\"", (object) $"\"{((object) oldValue != null ? oldValue.ToString() : "null")}\"", (object) $"\"{((object) newValue != null ? newValue.ToString() : "null")}\"");
    try
    {
      str = $"{str} {AcpResources.At_Id} \"{this.Parent.Path("\\")}\"";
    }
    catch (NullReferenceException ex)
    {
    }
    return str;
  }

  internal override void CreateFieldData(string uiName)
  {
    this.FieldData = (AcpFieldImplBase) new AcpFieldImpl<TDBType>(uiName);
  }

  internal virtual void ResetToDefaultNoConstraints() => this.dataValue = this.DefaultValue;

  internal void SetValueNoConstraints(TDBType value) => this.dataValue = value;

  protected bool PreKeyMapUpdate()
  {
    if (this.Parent.ParentRecset is Recordset parentRecset)
    {
      FeatureNode parent = (FeatureNode) this.Parent.Parent;
      if (parentRecset.KeysToNode != null)
      {
        int num = parentRecset.KeysToNode.Contains(parent) ? 1 : 0;
        if (num == 0)
          return num != 0;
        parentRecset.KeysToNode.Remove(parent);
        return num != 0;
      }
    }
    return false;
  }

  protected void PostKeyMapUpdate(string oldKey, bool oldKeyPresent)
  {
    if (!(this.Parent.ParentRecset is Recordset parentRecset))
      return;
    FeatureNode parent = (FeatureNode) this.Parent.Parent;
    if (parent.ReferenceKey != null)
    {
      string str = parent.ReferenceKey;
      if (parentRecset.RecsetId == 2300)
        str = System.IO.Path.GetFileNameWithoutExtension(str);
      if (!parentRecset.KeysToNode.Contains(str))
      {
        try
        {
          parentRecset.KeysToNode.Add(parent);
        }
        catch (ArgumentException ex)
        {
          this.ForceValid = false;
        }
      }
    }
    this.FirePropertyChangedEvent();
    parentRecset.RaiseReferenceKeyChanged(parent);
    if (!parentRecset.PositionBased)
      return;
    parentRecset.MoveNodeBasedOnKey(parent);
  }
}
