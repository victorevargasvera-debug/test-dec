// Decompiled with JetBrains decompiler
// Type: AcpBusinessLayer.UndoRedo.ChangeMinTask
// Assembly: AcpBusinessLayer, Version=23.1.0.23, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 44CF2A76-4418-422B-9DDD-B27A71BAF20C
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpBusinessLayer.dll

using AcpCommonLib;
using AcpCommonLib.UndoRedo;

#nullable disable
namespace AcpBusinessLayer.UndoRedo;

public class ChangeMinTask : UndoableTask
{
  private int oldMin;
  private int newMin;
  private IAcpRecordset recordset;

  public ChangeMinTask(IAcpRecordset recordset, int newValue)
  {
    this.recordset = recordset;
    if (recordset != null)
      this.oldMin = this.recordset.Min;
    this.newMin = newValue;
  }

  public override void Do()
  {
    if (this.recordset != null)
      this.recordset.Min = this.newMin;
    base.Do();
  }

  public override void Undo()
  {
    if (this.recordset != null)
      this.recordset.Min = this.oldMin;
    base.Undo();
  }

  public override void LaunchUI()
  {
    if (this.recordset == null || !this.recordset.IsEmbeddedRecset)
      return;
    UndoManager.GoToSection(this.recordset.ParentSection);
  }
}
