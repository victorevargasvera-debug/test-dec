// Decompiled with JetBrains decompiler
// Type: AcpBusinessLayer.UndoRedo.ListItemTask
// Assembly: AcpBusinessLayer, Version=23.1.0.23, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 44CF2A76-4418-422B-9DDD-B27A71BAF20C
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpBusinessLayer.dll

#nullable disable
namespace AcpBusinessLayer.UndoRedo;

internal class ListItemTask : FieldTaskBase
{
  protected ListItemTask(AcpListField field, string listItem, int index)
  {
    this.field = (AcpFieldBase) field;
    this.ListItem = listItem;
    this.Index = index;
  }

  protected AcpListField TheListField => this.field as AcpListField;

  protected string ListItem { get; set; }

  protected int Index { get; set; }
}
