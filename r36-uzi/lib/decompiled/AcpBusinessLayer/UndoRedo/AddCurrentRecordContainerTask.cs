// Decompiled with JetBrains decompiler
// Type: AcpBusinessLayer.UndoRedo.AddCurrentRecordContainerTask
// Assembly: AcpBusinessLayer, Version=23.1.0.23, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 44CF2A76-4418-422B-9DDD-B27A71BAF20C
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpBusinessLayer.dll

using AcpCommonLib.UndoRedo;

#nullable disable
namespace AcpBusinessLayer.UndoRedo;

public class AddCurrentRecordContainerTask : AddRecordContainerTask
{
  internal AddCurrentRecordContainerTask(FeatureNode record)
    : base("")
  {
    this.Description = "Add Copy Of " + record.FeatureName;
    this.Records = new FeatureNode[1]{ record };
    this.AddTask((UndoableTask) new AddRecordTask(record, true));
    this.PopulateRecRefFieldTasks(record);
  }
}
