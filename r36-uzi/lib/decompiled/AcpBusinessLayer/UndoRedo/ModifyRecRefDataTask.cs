// Decompiled with JetBrains decompiler
// Type: AcpBusinessLayer.UndoRedo.ModifyRecRefDataTask
// Assembly: AcpBusinessLayer, Version=23.1.0.23, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 44CF2A76-4418-422B-9DDD-B27A71BAF20C
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpBusinessLayer.dll

using AcpCommonResources;
using AcpUtility;

#nullable disable
namespace AcpBusinessLayer.UndoRedo;

public class ModifyRecRefDataTask : FieldTaskBase
{
  private string theOtherValue;
  private bool forceValid;
  private string[] slaveValues;

  private ModifyRecRefDataTask()
  {
  }

  public ModifyRecRefDataTask(AcpRecRefField obj, string newValue)
  {
    this.field = (AcpFieldBase) obj;
    this.theOtherValue = newValue;
    this.forceValid = obj.ForceValid;
    this.Description = AcpResources.Change.AcpStringFormat((object) $" \"{this.field.UIName}\"");
    this.slaveValues = new string[obj.SlaveFieldCount];
    int num = 0;
    foreach (AcpRecRefSlaveItem slaveField in obj.SlaveFields)
      this.slaveValues[num++] = slaveField.SlaveField.UIValue;
  }

  public override void Do()
  {
    this.SwapValues();
    base.Do();
  }

  public override void Undo()
  {
    this.SwapValues();
    base.Undo();
  }

  protected virtual void SwapValues()
  {
    AcpRecRefField field = this.field as AcpRecRefField;
    string uiValue = field.UIValue;
    field.UIValue = this.theOtherValue;
    this.theOtherValue = uiValue;
    if (!this.Done)
      return;
    int num = 0;
    foreach (AcpRecRefSlaveItem slaveField in field.SlaveFields)
    {
      if (this.slaveValues.Length <= num)
        break;
      slaveField.SlaveField.UIValue = this.slaveValues[num++];
    }
  }
}
