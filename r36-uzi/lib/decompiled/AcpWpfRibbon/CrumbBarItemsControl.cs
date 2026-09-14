// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.CrumbBarItemsControl
// Assembly: AcpWpfRibbon, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 45A745B5-88C3-40EE-B1E5-8DBA2EACD529
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfRibbon.dll

using System.Windows;
using System.Windows.Controls;

#nullable disable
namespace DevComponents.WpfRibbon;

internal class CrumbBarItemsControl : ItemsControl
{
  private CrumbBarItemView _ParentViewItem;

  protected override bool IsItemItsOwnContainerOverride(object item) => item is CrumbBarItem;

  internal CrumbBarItemView ParentViewItem
  {
    get => this._ParentViewItem;
    set => this._ParentViewItem = value;
  }

  protected override DependencyObject GetContainerForItemOverride()
  {
    return (DependencyObject) new CrumbBarItem();
  }
}
