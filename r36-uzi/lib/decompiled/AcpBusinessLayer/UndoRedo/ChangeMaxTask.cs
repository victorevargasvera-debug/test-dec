// Decompiled with JetBrains decompiler
// Type: AcpBusinessLayer.UndoRedo.ChangeMaxTask
// Assembly: AcpBusinessLayer, Version=23.1.0.23, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 44CF2A76-4418-422B-9DDD-B27A71BAF20C
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpBusinessLayer.dll

using AcpCommonLib;
using AcpCommonLib.UndoRedo;

#nullable disable
namespace AcpBusinessLayer.UndoRedo;

public class ChangeMaxTask : UndoableTask
{
  private readonly int oldMax;
  private readonly int newMax;
  private IAcpRecordset recordset;

  public ChangeMaxTask(IAcpRecordset recordset, int newValue)
  {
    this.recordset = recordset;
    if (recordset != null)
      this.oldMax = this.recordset.Max;
    this.newMax = newValue;
  }

  public override void Do()
  {
    if (this.recordset != null)
      this.recordset.Max = this.newMax;
    base.Do();
  }

  public override void Undo()
  {
    if (this.recordset != null)
      this.recordset.Max = this.oldMax;
    base.Undo();
  }

  public override void LaunchUI()
  {
    if (this.recordset == null || !this.recordset.IsEmbeddedRecset)
      return;
    UndoManager.GoToSection(this.recordset.ParentSection);
  }
}
