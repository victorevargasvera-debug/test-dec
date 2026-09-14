// Decompiled with JetBrains decompiler
// Type: AcpBusinessLayer.UndoRedo.AddRecordContainerTask
// Assembly: AcpBusinessLayer, Version=23.1.0.23, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 44CF2A76-4418-422B-9DDD-B27A71BAF20C
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpBusinessLayer.dll

using AcpCommonLib;
using AcpCommonLib.FieldsReport;
using AcpCommonLib.UndoRedo;
using System.Collections.Generic;

#nullable disable
namespace AcpBusinessLayer.UndoRedo;

public class AddRecordContainerTask : ContainerTask
{
  private List<AcpRecRefField> listInvalidRecRefField;

  protected FeatureNode[] Records { get; set; }

  internal AddRecordContainerTask(string description)
    : base(description)
  {
    this.listInvalidRecRefField = new List<AcpRecRefField>();
  }

  internal void PopulateRecRefFieldTasks(FeatureNode record)
  {
    foreach (AcpRecRefField recRefField in record.RecRefFields)
    {
      this.AddTask((UndoableTask) new ModifyRecRefDataTask(recRefField, recRefField.UIValue));
      if (!recRefField.Valid)
        this.listInvalidRecRefField.Add(recRefField);
    }
    this.fieldsFromSections((IAcpFeatureNode) record);
  }

  private void fieldsFromSections(IAcpFeatureNode record)
  {
    foreach (FeatureSection featureSection in record.FeatureSectionsCollectionByOrder)
    {
      foreach (IAcpField acpField in featureSection.FieldsCollectionByOrder)
      {
        if (acpField is AcpRecRefField)
        {
          AcpRecRefField acpRecRefField = (AcpRecRefField) acpField;
          this.AddTask((UndoableTask) new ModifyRecRefDataTask(acpRecRefField, acpRecRefField.UIValue));
          if (!acpRecRefField.Valid)
            this.listInvalidRecRefField.Add(acpRecRefField);
        }
      }
      if (featureSection.HasEmbeddedRecset)
        this.fieldsFromSectionsEmbeddedRecsets(featureSection.EmbeddedRecset);
    }
  }

  private void fieldsFromSectionsEmbeddedRecsets(IAcpRecordset embeddedRec)
  {
    for (int index = 0; index < embeddedRec.Count; ++index)
      this.fieldsFromSections(embeddedRec[index]);
  }

  public override void Do()
  {
    base.Do();
    for (int index = this.listInvalidRecRefField.Count - 1; index >= 0; --index)
    {
      AcpRecRefField field = this.listInvalidRecRefField[index];
      if (!AppInfoManager.InvalidFieldsReport.ContainsField((IAcpField) field) && !field.Valid)
      {
        AppInfoManager.InvalidFieldsReport.RegisterFieldInReport((IAcpField) field, string.Empty, true);
        AppInfoManager.InvalidFieldsReport.FieldsReportChanged = true;
      }
      else if (field.Valid)
        this.listInvalidRecRefField.RemoveAt(index);
    }
  }

  public override void Undo()
  {
    base.Undo();
    foreach (FieldsReportInfo field1 in AppInfoManager.InvalidFieldsReport.Fields)
    {
      foreach (FeatureNode record in this.Records)
      {
        if (field1.Field != null && field1.FieldType == FieldInfoType.Field && field1.Field is AcpRecRefField)
        {
          AcpRecRefField field2 = (AcpRecRefField) field1.Field;
          if (field2.Parent.Parent == record || field2.Parent.ParentRecset.IsEmbeddedRecset && field2.Parent.ParentRecset.ParentSection.Parent == record)
            this.listInvalidRecRefField.Add(field2);
        }
      }
    }
    foreach (IAcpField field in this.listInvalidRecRefField)
    {
      AppInfoManager.InvalidFieldsReport.UnregisterFieldInReport(field);
      AppInfoManager.InvalidFieldsReport.FieldsReportChanged = true;
    }
  }
}
