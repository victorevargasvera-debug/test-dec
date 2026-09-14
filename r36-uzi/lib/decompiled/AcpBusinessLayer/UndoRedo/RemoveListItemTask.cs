// Decompiled with JetBrains decompiler
// Type: AcpBusinessLayer.UndoRedo.RemoveListItemTask
// Assembly: AcpBusinessLayer, Version=23.1.0.23, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 44CF2A76-4418-422B-9DDD-B27A71BAF20C
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpBusinessLayer.dll

using AcpCommonResources;
using AcpUtility;

#nullable disable
namespace AcpBusinessLayer.UndoRedo;

internal class RemoveListItemTask : ListItemTask
{
  internal RemoveListItemTask(AcpListField field, int index)
    : base(field, field.Items[index].ItemName, index)
  {
    this.Description = AcpResources.Remove.AcpStringFormat((object) this.ListItem);
  }

  public override void Do()
  {
    this.TheListField.RemoveItemAt(this.Index);
    this.TheListField.CallConstraintsX();
    base.Do();
  }

  public override void Undo()
  {
    this.TheListField.InsertItem(this.Index, this.ListItem);
    this.TheListField.CallConstraintsX();
    base.Undo();
  }
}
