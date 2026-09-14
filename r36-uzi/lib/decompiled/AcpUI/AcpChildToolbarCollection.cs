// Decompiled with JetBrains decompiler
// Type: AcpUI.AcpChildToolbarCollection
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

#nullable disable
namespace AcpUI;

public class AcpChildToolbarCollection : Collection<AcpChildRecNavToolbar>
{
  private AcpParentRecNavToolbar parent;

  internal AcpChildToolbarCollection(AcpParentRecNavToolbar parent) => this.InitParent(parent);

  internal AcpChildToolbarCollection(
    AcpParentRecNavToolbar parent,
    IList<AcpChildRecNavToolbar> list)
    : base(list)
  {
    this.InitParent(parent);
  }

  internal AcpParentRecNavToolbar ParentToolbar => this.parent;

  private void InitParent(AcpParentRecNavToolbar parent)
  {
    this.parent = parent != null ? parent : throw new ArgumentNullException(nameof (parent));
  }

  protected override void InsertItem(int index, AcpChildRecNavToolbar child)
  {
    if (child == null)
      throw new ArgumentNullException(nameof (child));
    if (child.ParentToolbar != null)
      return;
    child.ParentToolbar = this.parent;
    base.InsertItem(index, child);
  }

  protected override void SetItem(int index, AcpChildRecNavToolbar child)
  {
    if (child == null)
      throw new ArgumentNullException(nameof (child));
    child.ParentToolbar = this.parent;
    base.SetItem(index, child);
  }

  protected override void RemoveItem(int index)
  {
    this[index].ParentToolbar = (AcpParentRecNavToolbar) null;
    base.RemoveItem(index);
  }

  protected override void ClearItems()
  {
    foreach (AcpChildRecNavToolbar childRecNavToolbar in (IEnumerable<AcpChildRecNavToolbar>) this.Items)
      childRecNavToolbar.ParentToolbar = (AcpParentRecNavToolbar) null;
    base.ClearItems();
  }
}
