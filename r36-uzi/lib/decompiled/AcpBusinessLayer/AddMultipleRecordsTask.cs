// Decompiled with JetBrains decompiler
// Type: AcpBusinessLayer.AddMultipleRecordsTask
// Assembly: AcpBusinessLayer, Version=23.1.0.23, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 44CF2A76-4418-422B-9DDD-B27A71BAF20C
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpBusinessLayer.dll

using AcpCommonLib;
using AcpCommonLib.FieldsReport;
using AcpCommonResources;
using AcpUtility;
using System.Collections.Generic;

#nullable disable
namespace AcpBusinessLayer;

public class AddMultipleRecordsTask : MultiRecordTaskBase
{
  private List<IAcpCommon> invalidFieds;
  private bool _bIsCurrentAdd;

  protected AddMultipleRecordsTask()
  {
  }

  public AddMultipleRecordsTask(FeatureNode[] records)
    : base(records)
  {
    this.Description = AcpResources.Add_Records.AcpStringFormat((object) $"{this.Count.ToString()} {records[0].FeatureName}");
  }

  internal AddMultipleRecordsTask(FeatureNode[] records, bool isCurrentAdd)
    : base(records)
  {
    this._bIsCurrentAdd = isCurrentAdd;
    this.Description = $"Add {this.Count.ToString()} copies of {records[0].FeatureName} record";
  }

  public override void Do()
  {
    Recordset parent = this.Records[0].Parent as Recordset;
    parent.LastRecordInOperation = false;
    parent.NotFirstNoLastAddOnMultiAddOperation = false;
    for (int index = 0; index < this.Count; ++index)
    {
      parent.LastRecordInOperation = index == this.Count - 1;
      parent.NotFirstNoLastAddOnMultiAddOperation = index != 0 && index != this.Count - 1;
      parent.AddRecord(this.Records[index]);
      this.Records[index].Initialize();
      this.Records[index].CallConstraints();
      this.Records[index].Deleted = false;
    }
    if (this.invalidFieds != null)
    {
      foreach (IAcpCommon invalidFied in this.invalidFieds)
      {
        if (invalidFied is IAcpField)
        {
          if (!(invalidFied is AcpRecRefField) || !this._bIsCurrentAdd)
          {
            AppInfoManager.InvalidFieldsReport.UnregisterFieldInReport((IAcpField) invalidFied);
            AppInfoManager.InvalidFieldsReport.RegisterFieldInReport((IAcpField) invalidFied, string.Empty, true);
            AppInfoManager.InvalidFieldsReport.FieldsReportChanged = true;
          }
        }
        else if (invalidFied is IAcpFeatureNode)
        {
          AppInfoManager.InvalidFieldsReport.RegisterFieldInReport((IAcpFeatureNode) invalidFied, AcpResources.Extra_Record);
          AppInfoManager.InvalidFieldsReport.FieldsReportChanged = true;
        }
      }
    }
    parent.NotFirstNoLastAddOnMultiAddOperation = false;
    base.Do();
  }

  public override void Undo()
  {
    Recordset parent = this.Records[0].Parent as Recordset;
    parent.LastRecordInOperation = false;
    for (int index1 = 0; index1 < this.Count; ++index1)
    {
      parent.LastRecordInOperation = index1 == this.Count - 1;
      int index2 = parent.IndexOf((IAcpFeatureNode) this.Records[index1]);
      if (index2 >= 0)
        parent.RemoveRecordInternal(index2, new bool?(false));
    }
    if (this.invalidFieds == null)
    {
      this.invalidFieds = new List<IAcpCommon>();
      foreach (FieldsReportInfo field1 in AppInfoManager.InvalidFieldsReport.Fields)
      {
        foreach (FeatureNode record in this.Records)
        {
          if (field1.Field != null && field1.FieldType == FieldInfoType.Field && (!(field1.Field is AcpRecRefField) || !this._bIsCurrentAdd))
          {
            IAcpField field2 = field1.Field;
            if (field2.Parent.Parent == record || field2.Parent.ParentRecset.IsEmbeddedRecset && field2.Parent.ParentRecset.ParentSection.Parent == record)
              this.invalidFieds.Add((IAcpCommon) field2);
          }
          else if (field1.Node != null && field1.FieldType == FieldInfoType.Record && (field1.Node == record || field1.Node.Parent.IsEmbeddedRecset && field1.Node.Parent.ParentSection.Parent == record))
            this.invalidFieds.Add((IAcpCommon) field1.Node);
        }
      }
    }
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
    if (this.invalidFieds.Count > 0)
      AppInfoManager.InvalidFieldsReport.FieldsReportChanged = true;
    foreach (FeatureNode record in this.Records)
      record.Deleted = true;
    base.Undo();
  }
}
