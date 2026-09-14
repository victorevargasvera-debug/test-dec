// Decompiled with JetBrains decompiler
// Type: AcpBusinessLayer.DeleteMultipleRecordsTask
// Assembly: AcpBusinessLayer, Version=23.1.0.23, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 44CF2A76-4418-422B-9DDD-B27A71BAF20C
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpBusinessLayer.dll

using AcpBusinessLayer.UndoRedo;
using AcpCommonResources;
using AcpUtility;

#nullable disable
namespace AcpBusinessLayer;

public class DeleteMultipleRecordsTask : MultiRecordTaskBase
{
  private DeleteRecordTask[] deletedRecords;

  protected DeleteMultipleRecordsTask()
  {
  }

  public DeleteMultipleRecordsTask(FeatureNode[] records)
    : base(records)
  {
    this.Description = AcpResources.Delete_Records.AcpStringFormat((object) $"{this.Count.ToString()} {records[0].FeatureName}");
    this.deletedRecords = new DeleteRecordTask[records.Length];
    for (int index = 0; index < records.Length; ++index)
      this.deletedRecords[index] = new DeleteRecordTask(records[index]);
  }

  public override void Do()
  {
    Recordset parent = this.Records[0].Parent as Recordset;
    parent.LastRecordInOperation = false;
    for (int index = 0; index < this.deletedRecords.Length; ++index)
    {
      parent.LastRecordInOperation = index == this.Count - 1;
      this.deletedRecords[index].Do();
    }
    base.Do();
  }

  public override void Undo()
  {
    Recordset parent = this.Records[0].Parent as Recordset;
    parent.LastRecordInOperation = false;
    for (int index = this.deletedRecords.Length - 1; index >= 0; --index)
    {
      parent.LastRecordInOperation = index == 0;
      this.deletedRecords[index].Undo();
    }
    base.Undo();
  }
}
