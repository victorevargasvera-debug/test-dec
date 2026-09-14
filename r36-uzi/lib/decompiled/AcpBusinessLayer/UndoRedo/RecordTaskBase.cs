// Decompiled with JetBrains decompiler
// Type: AcpBusinessLayer.UndoRedo.RecordTaskBase
// Assembly: AcpBusinessLayer, Version=23.1.0.23, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 44CF2A76-4418-422B-9DDD-B27A71BAF20C
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpBusinessLayer.dll

using AcpCommonLib;
using AcpCommonLib.UndoRedo;
using System.Collections.Generic;
using System.Collections.ObjectModel;

#nullable disable
namespace AcpBusinessLayer.UndoRedo;

public class RecordTaskBase : UndoableTask
{
  protected FeatureNode record;

  protected RecordTaskBase()
  {
  }

  public RecordTaskBase(FeatureNode record) => this.record = record;

  public override void LaunchUI()
  {
    if (this.record.Parent.IsEmbeddedRecset)
    {
      UndoManager.GoToSection(this.record.Parent.ParentSection);
    }
    else
    {
      IAcpFeatureNode acpFeatureNode = (IAcpFeatureNode) null;
      if (((Collection<FeatureNode>) this.record.Parent).Contains(this.record))
      {
        acpFeatureNode = (IAcpFeatureNode) this.record;
      }
      else
      {
        int count = ((Recordset) this.record.Parent).Count;
        if (count > 0)
          acpFeatureNode = ((Recordset) this.record.Parent)[count - 1];
      }
      if (acpFeatureNode == null)
        return;
      IEnumerator<IAcpFeatureSection> enumerator = acpFeatureNode.FeatureSectionsCollection.GetEnumerator();
      enumerator.MoveNext();
      UndoManager.GoToSection(enumerator.Current);
    }
  }
}
