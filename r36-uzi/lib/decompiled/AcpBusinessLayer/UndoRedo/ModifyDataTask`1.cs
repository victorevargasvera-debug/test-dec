// Decompiled with JetBrains decompiler
// Type: AcpBusinessLayer.UndoRedo.ModifyDataTask`1
// Assembly: AcpBusinessLayer, Version=23.1.0.23, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 44CF2A76-4418-422B-9DDD-B27A71BAF20C
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpBusinessLayer.dll

using AcpCommonResources;
using AcpUtility;
using System;

#nullable disable
namespace AcpBusinessLayer.UndoRedo;

public class ModifyDataTask<TDBValue> : FieldTaskBase where TDBValue : IComparable
{
  private TDBValue theOtherValue;
  private bool forceValid;
  private SetRefRecsetTask setRefTask;

  private ModifyDataTask()
  {
  }

  public ModifyDataTask(AcpField<TDBValue> obj, TDBValue newValue)
  {
    this.field = (AcpFieldBase) obj;
    this.theOtherValue = newValue;
    this.forceValid = obj.ForceValid;
    this.Description = AcpResources.Change.AcpStringFormat((object) $" \"{this.field.UIName}\"");
  }

  internal ModifyDataTask(AcpField<TDBValue> obj, TDBValue newValue, SetRefRecsetTask setRefTask)
  {
    this.field = (AcpFieldBase) obj;
    this.theOtherValue = newValue;
    this.forceValid = obj.ForceValid;
    this.setRefTask = setRefTask;
    this.Description = AcpResources.Change.AcpStringFormat((object) $" \"{this.field.UIName}\"");
  }

  public override void Do()
  {
    this.SwapValues();
    if (this.setRefTask != null)
      this.setRefTask.Do();
    base.Do();
  }

  public override void Undo()
  {
    this.SwapValues();
    if (this.setRefTask != null)
      this.setRefTask.Undo();
    base.Undo();
  }

  protected virtual void SwapValues()
  {
    TDBValue dbValue = ((AcpField<TDBValue>) this.field).Value;
    ((AcpField<TDBValue>) this.field).Value = this.theOtherValue;
    this.theOtherValue = dbValue;
  }
}
