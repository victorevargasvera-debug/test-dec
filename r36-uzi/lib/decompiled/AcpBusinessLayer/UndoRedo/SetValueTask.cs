// Decompiled with JetBrains decompiler
// Type: AcpBusinessLayer.UndoRedo.SetValueTask
// Assembly: AcpBusinessLayer, Version=23.1.0.23, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 44CF2A76-4418-422B-9DDD-B27A71BAF20C
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpBusinessLayer.dll

#nullable disable
namespace AcpBusinessLayer.UndoRedo;

public class SetValueTask : FieldTaskBase
{
  private string theOtherValue;

  private SetValueTask()
  {
  }

  public SetValueTask(AcpFieldBase field, string newValue)
  {
    this.field = field;
    this.theOtherValue = newValue;
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

  private void SwapValues()
  {
    string str = this.field.ToString();
    this.field.ParseValueFrom(this.theOtherValue);
    this.field.CalculateApplicability();
    this.field.CalculateValidity();
    this.theOtherValue = str;
  }
}
