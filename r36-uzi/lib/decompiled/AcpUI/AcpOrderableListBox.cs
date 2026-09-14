// Decompiled with JetBrains decompiler
// Type: AcpUI.AcpOrderableListBox
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

using AcpUI.DragDrop;
using System.Windows;
using System.Windows.Controls;

#nullable disable
namespace AcpUI;

public class AcpOrderableListBox : AcpListBox
{
  public AcpOrderableListBox()
  {
    ListBoxDragDropManager<AcpBusinessLayer.ListItem> boxDragDropManager = new ListBoxDragDropManager<AcpBusinessLayer.ListItem>((ListBox) this);
  }

  public override void OnApplyTemplate()
  {
    base.OnApplyTemplate();
    Style resource = (Style) this.TryFindResource((object) "AcpListBoxItemStyle");
    if (resource == null)
      return;
    this.ItemContainerStyle = new Style(typeof (ListBoxItem), resource);
  }
}
