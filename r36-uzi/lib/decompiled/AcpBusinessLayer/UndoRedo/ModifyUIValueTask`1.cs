// Decompiled with JetBrains decompiler
// Type: AcpBusinessLayer.UndoRedo.ModifyUIValueTask`1
// Assembly: AcpBusinessLayer, Version=23.1.0.23, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 44CF2A76-4418-422B-9DDD-B27A71BAF20C
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpBusinessLayer.dll

using AcpCommonResources;
using AcpUtility;

#nullable disable
namespace AcpBusinessLayer.UndoRedo;

public class ModifyUIValueTask<TUIValue> : FieldTaskBase
{
  private string theOtherValue;
  private bool uiInvalid;

  private ModifyUIValueTask()
  {
  }

  public ModifyUIValueTask(AcpFieldBase field, TUIValue newValue)
  {
    this.field = field;
    this.uiInvalid = field.UIInvalid;
    this.theOtherValue = newValue.ToString();
    this.Description = AcpResources.Change.AcpStringFormat((object) $" \"{field.UIName}\"");
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
    string str = this.field.ToString();
    bool uiInvalid = this.field.UIInvalid;
    this.field.ParseValueFrom(this.theOtherValue.ToString());
    this.field.CallConstraintsX();
    this.field.FirePropertyChangedEvent();
    this.uiInvalid = uiInvalid;
    this.theOtherValue = str;
  }
}
