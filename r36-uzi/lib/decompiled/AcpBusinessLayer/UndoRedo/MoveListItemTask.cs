// Decompiled with JetBrains decompiler
// Type: AcpBusinessLayer.UndoRedo.MoveListItemTask
// Assembly: AcpBusinessLayer, Version=23.1.0.23, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 44CF2A76-4418-422B-9DDD-B27A71BAF20C
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpBusinessLayer.dll

#nullable disable
namespace AcpBusinessLayer.UndoRedo;

internal class MoveListItemTask : ListItemTask
{
  protected int NewIndex { get; private set; }

  internal MoveListItemTask(AcpListField field, int oldIndex, int newIndex)
    : base(field, field.Items[oldIndex].ItemName, oldIndex)
  {
    this.NewIndex = newIndex;
  }

  public override void Do()
  {
    this.SwapItems();
    base.Do();
  }

  public override void Undo()
  {
    this.SwapItems();
    base.Undo();
  }

  private void SwapItems()
  {
    this.TheListField.MoveItem(this.Index, this.NewIndex);
    int index = this.Index;
    this.Index = this.NewIndex;
    this.NewIndex = index;
  }
}
