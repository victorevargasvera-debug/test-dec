// Decompiled with JetBrains decompiler
// Type: AcpUI.AcpTreeViewItem
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

#nullable disable
namespace AcpUI;

public class AcpTreeViewItem : TreeViewItem
{
  private int recsetId = -1;
  private int nodeId = -1;
  public static readonly DependencyProperty ShowDiffIconProperty = DependencyProperty.RegisterAttached(nameof (ShowDiffIcon), typeof (bool), typeof (AcpTreeViewItem), (PropertyMetadata) new FrameworkPropertyMetadata((object) false, FrameworkPropertyMetadataOptions.AffectsRender));

  public int RecsetId
  {
    get => this.recsetId;
    set => this.recsetId = value;
  }

  public int NodeId
  {
    get => this.nodeId;
    set => this.nodeId = value;
  }

  public string ReferenceKey { get; set; }

  public bool ShowDiffIcon
  {
    get => (bool) this.GetValue(AcpTreeViewItem.ShowDiffIconProperty);
    set => this.SetValue(AcpTreeViewItem.ShowDiffIconProperty, (object) value);
  }

  public AcpTreeViewItem()
  {
    this.MouseLeftButtonUp += new MouseButtonEventHandler(this.AcpTreeViewItem_MouseLeftButtonUp);
  }

  private void AcpTreeViewItem_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
  {
    AcpTreeViewItem acpTreeViewItem = sender as AcpTreeViewItem;
    if (!acpTreeViewItem.IsSelected)
      acpTreeViewItem.IsSelected = true;
    AcpTreeView parent = (AcpTreeView) this.GetParent((object) acpTreeViewItem, typeof (AcpTreeView));
    parent.NavigateToContentPage((TreeView) parent);
    e.Handled = true;
  }

  private DependencyObject GetParent(object obj, Type parentType)
  {
    DependencyObject reference = (DependencyObject) obj;
    DependencyObject parent;
    do
    {
      parent = VisualTreeHelper.GetParent(reference);
      reference = parent;
    }
    while (parent != null && !parent.GetType().IsSubclassOf(parentType));
    return parent;
  }
}
