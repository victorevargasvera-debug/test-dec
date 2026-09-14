// Decompiled with JetBrains decompiler
// Type: AcpBusinessLayer.UndoRedo.AddMultipleCurrRecordsContainerTask
// Assembly: AcpBusinessLayer, Version=23.1.0.23, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 44CF2A76-4418-422B-9DDD-B27A71BAF20C
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpBusinessLayer.dll

using AcpCommonLib.UndoRedo;

#nullable disable
namespace AcpBusinessLayer.UndoRedo;

public class AddMultipleCurrRecordsContainerTask : AddRecordContainerTask
{
  internal AddMultipleCurrRecordsContainerTask(FeatureNode[] records)
    : base("")
  {
    this.Description = $"Add {records.Length.ToString()} copies of {records[0].FeatureName} record";
    this.Records = records;
    this.AddTask((UndoableTask) new AddMultipleRecordsTask(records, true));
    foreach (FeatureNode record in records)
      this.PopulateRecRefFieldTasks(record);
  }
}
