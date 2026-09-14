// Decompiled with JetBrains decompiler
// Type: AcpBusinessLayer.UndoRedo.AddRecordTask
// Assembly: AcpBusinessLayer, Version=23.1.0.23, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 44CF2A76-4418-422B-9DDD-B27A71BAF20C
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpBusinessLayer.dll

using AcpCommonLib;
using AcpCommonLib.FieldsReport;
using AcpCommonResources;
using AcpUtility;
using System.Collections.Generic;

#nullable disable
namespace AcpBusinessLayer.UndoRedo;

public class AddRecordTask : RecordTaskBase
{
  public List<IAcpCommon> invalidFieds;
  private bool _bIsCurrentAdd;

  protected AddRecordTask()
  {
  }

  public AddRecordTask(FeatureNode rec)
  {
    this.record = rec;
    this.Description = AcpResources.Add.AcpStringFormat((object) $" \"{rec.FeatureName}\"");
  }

  internal AddRecordTask(FeatureNode rec, bool isCurrentAdd)
  {
    this.record = rec;
    this._bIsCurrentAdd = isCurrentAdd;
    this.Description = $"Add Copy Of \"{rec.FeatureName}\"";
  }

  public override void Do()
  {
    ((Recordset) this.record.Parent).AddRecord(this.record);
    this.record.Initialize();
    this.record.CallConstraints();
    this.record.Deleted = false;
    if (this.invalidFieds != null)
    {
      foreach (IAcpCommon invalidFied in this.invalidFieds)
      {
        if (invalidFied is IAcpField)
        {
          if ((!(invalidFied is AcpRecRefField) || !this._bIsCurrentAdd) && !AppInfoManager.InvalidFieldsReport.ContainsUIField((IAcpField) invalidFied))
          {
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
    base.Do();
  }

  public override void Undo()
  {
    Recordset parent = this.record.Parent as Recordset;
    parent.RemoveRecordInternal(parent.IndexOf((IAcpFeatureNode) this.record), new bool?(false));
    if (this.invalidFieds == null)
    {
      this.invalidFieds = new List<IAcpCommon>();
      foreach (FieldsReportInfo field1 in AppInfoManager.InvalidFieldsReport.Fields)
      {
        if (field1.Field != null && field1.FieldType == FieldInfoType.Field && (!(field1.Field is AcpRecRefField) || !this._bIsCurrentAdd))
        {
          IAcpField field2 = field1.Field;
          if (field2.Parent.Parent == this.record || field2.Parent.ParentRecset.IsEmbeddedRecset && field2.Parent.ParentRecset.ParentSection.Parent == this.record)
            this.invalidFieds.Add((IAcpCommon) field2);
        }
        else if (field1.Node != null && field1.FieldType == FieldInfoType.Record && (field1.Node == this.record || field1.Node.Parent.IsEmbeddedRecset && field1.Node.Parent.ParentSection.Parent == this.record))
          this.invalidFieds.Add((IAcpCommon) field1.Node);
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
    this.record.Deleted = true;
    base.Undo();
  }
}
