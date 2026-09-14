// Decompiled with JetBrains decompiler
// Type: AcpBusinessLayer.UndoRedo.SetRefRecsetTask
// Assembly: AcpBusinessLayer, Version=23.1.0.23, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 44CF2A76-4418-422B-9DDD-B27A71BAF20C
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpBusinessLayer.dll

using AcpCommonLib;
using AcpCommonResources;
using AcpUtility;

#nullable disable
namespace AcpBusinessLayer.UndoRedo;

public class SetRefRecsetTask : FieldTaskBase
{
  private Recordset theOtherRecset;
  private string theOtherUIValue;

  internal SetRefRecsetTask(AcpRecRefField recRefField, Recordset newRecset)
  {
    this.field = (AcpFieldBase) recRefField;
    this.theOtherRecset = newRecset;
    this.theOtherUIValue = recRefField.UIValue;
    this.Description = AcpResources.Is_Set_To.AcpStringFormat((object) recRefField.UIName, newRecset != null ? (object) newRecset.UIName : (object) recRefField.InvalidText);
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

  internal void SwapValues()
  {
    AcpRecRefField field = this.field as AcpRecRefField;
    Recordset refRecset = field.RefRecset;
    string uiValue = field.UIValue;
    field.SetRecset((IAcpRecordset) this.theOtherRecset);
    if (this.Done)
      field.UIValue = this.theOtherUIValue;
    this.theOtherRecset = refRecset;
    this.theOtherUIValue = uiValue;
    field.SetUITimer();
  }
}
