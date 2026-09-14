// Decompiled with JetBrains decompiler
// Type: AcpBusinessLayer.MultiRecordTaskBase
// Assembly: AcpBusinessLayer, Version=23.1.0.23, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 44CF2A76-4418-422B-9DDD-B27A71BAF20C
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpBusinessLayer.dll

using AcpCommonLib;
using AcpCommonLib.UndoRedo;
using System.Collections.Generic;
using System.Collections.ObjectModel;

#nullable disable
namespace AcpBusinessLayer;

public class MultiRecordTaskBase : UndoableTask
{
  private int count;

  protected int Count
  {
    get => this.count;
    set => this.count = value;
  }

  protected FeatureNode[] Records { get; private set; }

  protected MultiRecordTaskBase()
  {
  }

  protected MultiRecordTaskBase(FeatureNode[] records)
  {
    this.Records = records;
    this.count = records.Length;
  }

  public override void LaunchUI()
  {
    FeatureNode record = this.Records[0];
    if (record.Parent.IsEmbeddedRecset)
    {
      UndoManager.GoToSection(record.Parent.ParentSection);
    }
    else
    {
      IAcpFeatureNode acpFeatureNode = (IAcpFeatureNode) null;
      if (((Collection<FeatureNode>) record.Parent).Contains(record))
      {
        acpFeatureNode = (IAcpFeatureNode) this.Records[this.count - 1];
      }
      else
      {
        int count = ((Recordset) record.Parent).Count;
        if (count > 0)
          acpFeatureNode = ((Recordset) record.Parent)[count - 1];
      }
      if (acpFeatureNode == null)
        return;
      IEnumerator<IAcpFeatureSection> enumerator = acpFeatureNode.FeatureSectionsCollection.GetEnumerator();
      enumerator.MoveNext();
      UndoManager.GoToSection(enumerator.Current);
    }
  }
}
