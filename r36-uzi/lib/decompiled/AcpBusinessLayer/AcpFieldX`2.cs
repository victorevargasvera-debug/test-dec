// Decompiled with JetBrains decompiler
// Type: AcpBusinessLayer.AcpFieldX`2
// Assembly: AcpBusinessLayer, Version=23.1.0.23, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 44CF2A76-4418-422B-9DDD-B27A71BAF20C
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpBusinessLayer.dll

using AcpBusinessLayer.UndoRedo;
using AcpCommonLib;
using AcpCommonLib.UndoRedo;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Windows.Data;

#nullable disable
namespace AcpBusinessLayer;

[DebuggerDisplay("Name={UIName}, UIValue={UIValue}")]
[Serializable]
public class AcpFieldX<TDBType, TUIType> : AcpField<TDBType>
  where TDBType : IComparable
  where TUIType : IComparable
{
  private TUIType tempUIBackup;

  protected AcpFieldX()
  {
  }

  protected AcpFieldX(FeatureSection parent, string name, string uiLabel)
    : base(parent, name, uiLabel)
  {
  }

  protected AcpFieldX(FeatureSection parent, string name, string uiLabel, string[] legacyUILabels)
    : base(parent, name, uiLabel, legacyUILabels)
  {
  }

  protected AcpFieldX(TDBType value, FeatureSection parent, string name, string uiLabel)
    : base(value, parent, name, uiLabel)
  {
  }

  protected AcpFieldX(
    TDBType value,
    FeatureSection parent,
    string name,
    string uiLabel,
    string[] legacyUILabels)
    : base(value, parent, name, uiLabel, legacyUILabels)
  {
  }

  public AcpFieldX(
    TDBType value,
    IValueConverter converter,
    FeatureSection parent,
    string name,
    string uiLabel)
    : base(value, parent, name, uiLabel)
  {
    this.Converter = converter;
  }

  public AcpFieldX(
    TDBType value,
    IValueConverter converter,
    FeatureSection parent,
    string name,
    string uiLabel,
    string[] legacyUILabels)
    : base(value, parent, name, uiLabel, legacyUILabels)
  {
    this.Converter = converter;
  }

  public AcpFieldX(IValueConverter converter, FeatureSection parent, string name, string uiLabel)
    : this(parent, name, uiLabel)
  {
    this.Converter = converter;
  }

  public AcpFieldX(
    IValueConverter converter,
    FeatureSection parent,
    string name,
    string uiLabel,
    string[] legacyUILabels)
    : this(parent, name, uiLabel, legacyUILabels)
  {
    this.Converter = converter;
  }

  protected AcpFieldX(
    TUIType uiValue,
    IValueConverter converter,
    FeatureSection parent,
    string name,
    string uiLabel)
    : this(parent, name, uiLabel)
  {
    this.Converter = converter;
    this.UIValue = uiValue;
  }

  public IValueConverter Converter { get; internal set; }

  public object ConverterParameterObject => (object) this;

  public virtual TUIType UIValue
  {
    get
    {
      return this.UIInvalid ? this.DirectUIValue : (TUIType) this.Converter.Convert((object) this.Value, (Type) null, this.ConverterParameterObject, (CultureInfo) null);
    }
    set
    {
      if ((object) this.UIValue != null && this.UIValue.CompareTo((object) value) == 0 && (!this.UIInvalid || AppInfoManager.AppMode != ApplicationMode.CodeplugComparisonMode))
        return;
      bool uiInvalid = this.UIInvalid;
      try
      {
        if (this.UIInvalid && UndoManager.MarkForUndo)
          throw new FormatException("The existing text is UIInvalid. Cannot create a ModifyDataTask.");
        this.Value = (TDBType) this.Converter.ConvertBack((object) value, (Type) null, this.ConverterParameterObject, (CultureInfo) null);
        this.UIInvalid = false;
      }
      catch (Exception ex)
      {
        if (UndoManager.MarkForUndo)
        {
          UndoableTask task = (UndoableTask) new ModifyUIValueTask<TUIType>((AcpFieldBase) this, value);
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
        else
        {
          this.DirectUIValue = value;
          this.UIInvalid = true;
          uiInvalid = this.UIInvalid;
        }
      }
      finally
      {
        if (uiInvalid)
          this.FirePropertyChangedEvent();
      }
    }
  }

  protected virtual bool ValidateHelper() => true;

  public override void ResetToDefaultWithUndo()
  {
    if (this.UIInvalid)
    {
      TUIType newValue = (TUIType) this.Converter.Convert((object) this.DefaultValue, (Type) null, this.ConverterParameterObject, (CultureInfo) null);
      if (UndoManager.MarkForUndo && (object) newValue != null)
      {
        ref TUIType local = ref newValue;
        if ((object) default (TUIType) == null)
        {
          TUIType uiType = local;
          local = ref uiType;
        }
        // ISSUE: variable of a boxed type
        __Boxed<TUIType> uiValue = (object) this.UIValue;
        if (local.CompareTo((object) uiValue) != 0)
        {
          UndoableTask task = (UndoableTask) new ModifyUIValueTask<TUIType>((AcpFieldBase) this, newValue);
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
      }
      this.SetUITimer();
    }
    else
      base.ResetToDefaultWithUndo();
  }

  public override void ResetToDefaultWithUndo(ContainerTask taskContainer)
  {
    if (this.UIInvalid)
    {
      TUIType newValue = (TUIType) this.Converter.Convert((object) this.DefaultValue, (Type) null, this.ConverterParameterObject, (CultureInfo) null);
      if ((object) newValue == null)
        return;
      ref TUIType local = ref newValue;
      if ((object) default (TUIType) == null)
      {
        TUIType uiType = local;
        local = ref uiType;
      }
      // ISSUE: variable of a boxed type
      __Boxed<TUIType> uiValue = (object) this.UIValue;
      if (local.CompareTo((object) uiValue) == 0)
        return;
      UndoableTask task = (UndoableTask) new ModifyUIValueTask<TUIType>((AcpFieldBase) this, newValue);
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
    else
      base.ResetToDefaultWithUndo(taskContainer);
  }

  public static implicit operator TUIType(AcpFieldX<TDBType, TUIType> obj) => obj.UIValue;

  protected internal override void FirePropertyChangedEvent()
  {
    base.FirePropertyChangedEvent();
    ((FeatureSection) this.Parent).FirePropertyChanged(this.Name + "_UIValue");
  }

  public override void ParseValueFrom(string value)
  {
    Type type = typeof (TUIType);
    try
    {
      this.UnsupportedValue = false;
      if (type == typeof (string))
      {
        this.UIValue = (TUIType) value;
      }
      else
      {
        MethodInfo method = type.GetMethod("Parse", new Type[1]
        {
          typeof (string)
        });
        if (!(method != (MethodInfo) null))
          return;
        this.UIValue = (TUIType) method.Invoke((object) null, new object[1]
        {
          (object) value
        });
      }
    }
    catch (Exception ex)
    {
      this.UnsupportedValue = true;
    }
  }

  public override string ToString()
  {
    return (object) this.UIValue == null ? string.Empty : this.UIValue.ToString();
  }

  internal TUIType DirectUIValue
  {
    get => this.tempUIBackup;
    set
    {
      this.tempUIBackup = value;
      this.ForceValid = false;
    }
  }

  public override UndoableTask CopyValueOf(IAcpField source)
  {
    SetValueTask task = (SetValueTask) null;
    if (!this.Value.Equals((object) ((AcpField<TDBType>) source).Value))
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

  public virtual UndoableTask CopyUIValue(object sourcevalue)
  {
    ModifyUIValueTask<TUIType> task = new ModifyUIValueTask<TUIType>((AcpFieldBase) this, (TUIType) sourcevalue);
    if (this.ValueSetter == null)
      return (UndoableTask) task;
    ContainerTask containerTask = new ContainerTask(task.ToString());
    containerTask.AddTask((UndoableTask) task);
    this.CallValueSetter(containerTask);
    return (UndoableTask) containerTask;
  }
}
