// Decompiled with JetBrains decompiler
// Type: AcpBusinessLayer.UndoRedo.MoveRecordTask
// Assembly: AcpBusinessLayer, Version=23.1.0.23, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 44CF2A76-4418-422B-9DDD-B27A71BAF20C
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpBusinessLayer.dll

using AcpCommonLib;
using AcpCommonResources;
using AcpUtility;

#nullable disable
namespace AcpBusinessLayer.UndoRedo;

internal class MoveRecordTask : RecordTaskBase
{
  private int theOtherPosition;

  private MoveRecordTask()
  {
  }

  internal MoveRecordTask(FeatureNode rec, int newPos)
    : base(rec)
  {
    this.theOtherPosition = newPos;
    this.Description = AcpResources.Move_To.AcpStringFormat((object) $"\"{this.record.FeatureName}\"", (object) this.theOtherPosition.ToString());
  }

  public override void Do()
  {
    this.Swap();
    base.Do();
  }

  public override void Undo()
  {
    this.Swap();
    base.Undo();
  }

  private void Swap()
  {
    Recordset parent = (Recordset) this.record.Parent;
    int oldIndex = parent.IndexOf((IAcpFeatureNode) this.record);
    int theOtherPosition = this.theOtherPosition;
    int num1;
    int num2;
    if (oldIndex > this.theOtherPosition)
    {
      num1 = this.theOtherPosition;
      num2 = oldIndex;
    }
    else
    {
      num2 = this.theOtherPosition < parent.Count ? this.theOtherPosition : parent.Count - 1;
      num1 = oldIndex;
    }
    parent.Move(oldIndex, this.theOtherPosition);
    for (int index = num1; index <= num2; ++index)
    {
      FeatureNode featureNode = parent[index] as FeatureNode;
      featureNode.RaisePositionChanged();
      if (parent.KeysToNode != null)
        parent.KeysToNode.UpdateKey((FeatureNode) parent[index]);
      if (featureNode.KeyField != null && featureNode.KeyField.ReferencingFields != null)
      {
        foreach (AcpRecRefField referencingField in featureNode.KeyField.ReferencingFields)
          referencingField.UpdateValue();
      }
    }
    if (parent.Count > parent.Max)
    {
      for (int index = 0; index < parent.Max; ++index)
        ((FeatureNode) parent[index]).Valid = true;
      for (int max = parent.Max; max < parent.Count; ++max)
        ((FeatureNode) parent[max]).Valid = false;
    }
    parent.FinishedMoveRecord(oldIndex, this.theOtherPosition);
    this.theOtherPosition = oldIndex;
  }
}
