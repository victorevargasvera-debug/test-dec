// Decompiled with JetBrains decompiler
// Type: AcpBusinessLayer.UndoRedo.DeleteRecordTask
// Assembly: AcpBusinessLayer, Version=23.1.0.23, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 44CF2A76-4418-422B-9DDD-B27A71BAF20C
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpBusinessLayer.dll

using AcpCommonLib;
using AcpCommonLib.FieldsReport;
using AcpCommonLib.UndoRedo;
using AcpCommonResources;
using AcpUtility;
using System.Collections.Generic;

#nullable disable
namespace AcpBusinessLayer.UndoRedo;

public class DeleteRecordTask : RecordTaskBase
{
  private int position;
  private List<IAcpCommon> invalidFieds;
  private List<AcpRecRefField> referencingFields;
  private Dictionary<AcpRecRefField, FeatureNode> referencedChildNodes;
  private int invalidRecIndex = -1;
  private ContainerTask nodeTasks;
  private bool bDndImportOperation;

  private DeleteRecordTask()
  {
  }

  public DeleteRecordTask(FeatureNode rec)
    : base(rec)
  {
    this.position = this.record.Parent.IndexOf((IAcpFeatureNode) this.record);
    this.Description = AcpResources.Delete.AcpStringFormat((object) $" \"{rec.FeatureName}\"");
  }

  internal DeleteRecordTask(FeatureNode rec, bool dndimpexp)
    : base(rec)
  {
    this.position = this.record.Parent.IndexOf((IAcpFeatureNode) this.record);
    this.Description = AcpResources.Delete.AcpStringFormat((object) $" \"{rec.FeatureName}\"");
    this.bDndImportOperation = dndimpexp;
  }

  public override void Do()
  {
    if (this.invalidFieds == null)
    {
      this.invalidFieds = new List<IAcpCommon>();
      this.referencingFields = new List<AcpRecRefField>();
      foreach (FieldsReportInfo field1 in AppInfoManager.InvalidFieldsReport.Fields)
      {
        if (field1.Field != null && field1.FieldType == FieldInfoType.Field)
        {
          IAcpField field2 = field1.Field;
          if (field2.Parent.Parent == this.record || field2.Parent.ParentRecset.IsEmbeddedRecset && field2.Parent.ParentRecset.ParentSection.Parent == this.record)
            this.invalidFieds.Add((IAcpCommon) field2);
        }
        else if (field1.Node != null && field1.FieldType == FieldInfoType.Record && (field1.Node == this.record || field1.Node.Parent.IsEmbeddedRecset && field1.Node.Parent.ParentSection.Parent == this.record))
          this.invalidFieds.Add((IAcpCommon) field1.Node);
      }
      if (this.record.KeyField != null && this.record.KeyField.ReferencingFields != null)
      {
        foreach (AcpRecRefField referencingField in this.record.KeyField.ReferencingFields)
        {
          this.referencingFields.Add(referencingField);
          foreach (AcpRecRefSlaveItem slaveField in referencingField.SlaveFields)
          {
            if (slaveField.SlaveField.ReferencedNode != null)
            {
              if (this.referencedChildNodes == null)
                this.referencedChildNodes = new Dictionary<AcpRecRefField, FeatureNode>();
              this.referencedChildNodes[slaveField.SlaveField] = slaveField.SlaveField.ReferencedNode;
            }
          }
        }
      }
      if (this.record.Valid)
      {
        for (int index = 0; index < this.record.Parent.Count; ++index)
        {
          FeatureNode featureNode = (FeatureNode) this.record.Parent[index];
          if (!featureNode.Valid)
          {
            featureNode.Valid = true;
            this.invalidRecIndex = index;
            break;
          }
        }
      }
      if (this.record.NodeDeleted != null)
      {
        this.nodeTasks = new ContainerTask(this.Description);
        this.record.NodeDeleted((IAcpFeatureNode) this.record, this.nodeTasks);
      }
    }
    else if (this.invalidRecIndex != -1)
      ((FeatureNode) this.record.Parent[this.invalidRecIndex]).Valid = true;
    this.record.Deleted = true;
    foreach (IAcpCommon invalidFied in this.invalidFieds)
    {
      if (invalidFied is IAcpField)
      {
        AppInfoManager.InvalidFieldsReport.UnregisterFieldInReport((IAcpField) invalidFied);
        AppInfoManager.InvalidFieldsReport.FieldsReportChanged = true;
      }
      else if (invalidFied is IAcpFeatureNode)
      {
        AppInfoManager.InvalidFieldsReport.UnregisterFieldInReport((IAcpFeatureNode) invalidFied);
        AppInfoManager.InvalidFieldsReport.FieldsReportChanged = true;
      }
    }
    if (this.nodeTasks != null)
      this.nodeTasks.Do();
    if (this.bDndImportOperation)
      ((Recordset) this.record.Parent).RemoveRecordAtNoMin(this.position);
    else
      ((Recordset) this.record.Parent).RemoveRecordAt(this.position);
    this.record.DropReferences();
    base.Do();
  }

  public override void Undo()
  {
    this.record.Deleted = false;
    if (this.invalidFieds != null)
    {
      foreach (IAcpCommon invalidFied in this.invalidFieds)
      {
        if (invalidFied is IAcpField)
        {
          AppInfoManager.InvalidFieldsReport.RegisterFieldInReport((IAcpField) invalidFied, string.Empty, true);
          AppInfoManager.InvalidFieldsReport.FieldsReportChanged = true;
        }
        else if (invalidFied is IAcpFeatureNode)
        {
          AppInfoManager.InvalidFieldsReport.RegisterFieldInReport((IAcpFeatureNode) invalidFied, AcpResources.Extra_Record);
          AppInfoManager.InvalidFieldsReport.FieldsReportChanged = true;
        }
      }
    }
    ((Recordset) this.record.Parent).InsertRecord(this.position, (IAcpFeatureNode) this.record);
    this.record.PopulateReferences();
    this.record.CalculateApplicability();
    this.record.CalculateValidity();
    foreach (AcpFieldX<int, string> referencingField in this.referencingFields)
      referencingField.UIValue = this.record.ReferenceKey;
    if (this.referencedChildNodes != null)
    {
      foreach (KeyValuePair<AcpRecRefField, FeatureNode> referencedChildNode in this.referencedChildNodes)
        referencedChildNode.Key.UIValue = referencedChildNode.Value.ReferenceKey;
    }
    if (this.invalidRecIndex != -1)
      ((FeatureNode) this.record.Parent[this.invalidRecIndex]).Valid = false;
    if (this.nodeTasks != null)
      this.nodeTasks.Undo();
    base.Undo();
  }
}
