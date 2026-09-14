// Decompiled with JetBrains decompiler
// Type: AcpBusinessLayer.UndoRedo.AddListItemTask
// Assembly: AcpBusinessLayer, Version=23.1.0.23, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 44CF2A76-4418-422B-9DDD-B27A71BAF20C
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpBusinessLayer.dll

using AcpCommonResources;
using AcpUtility;

#nullable disable
namespace AcpBusinessLayer.UndoRedo;

internal class AddListItemTask : ListItemTask
{
  internal AddListItemTask(AcpListField field, string item)
    : base(field, item, field.Items.Count)
  {
    this.Description = AcpResources.Add.AcpStringFormat((object) item);
  }

  internal AddListItemTask(AcpListField field, string item, int index)
    : base(field, item, index)
  {
    this.Description = AcpResources.Add.AcpStringFormat((object) item);
  }

  public override void Do()
  {
    this.TheListField.AddItemHelper(this.ListItem);
    this.TheListField.CallConstraintsX();
    base.Do();
  }

  public override void Undo()
  {
    this.TheListField.RemoveItemAt(this.Index);
    this.TheListField.CallConstraintsX();
    base.Undo();
  }
}
