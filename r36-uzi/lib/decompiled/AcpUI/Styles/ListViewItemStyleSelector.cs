// Decompiled with JetBrains decompiler
// Type: AcpUI.Styles.ListViewItemStyleSelector
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

using System.Windows;
using System.Windows.Controls;

#nullable disable
namespace AcpUI.Styles;

public class ListViewItemStyleSelector : StyleSelector
{
  private int i;

  public override Style SelectStyle(object item, DependencyObject container)
  {
    ItemsControl itemsControl = ItemsControl.ItemsControlFromItemContainer(container);
    if (item == itemsControl.Items[0])
      this.i = 0;
    string resourceKey = this.i % 2 != 0 ? "ListViewItemStyleBlue" : "ListViewItemStyleWhite";
    ++this.i;
    return (Style) itemsControl.FindResource((object) resourceKey);
  }
}
