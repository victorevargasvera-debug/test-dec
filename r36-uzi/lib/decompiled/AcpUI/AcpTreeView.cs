// Decompiled with JetBrains decompiler
// Type: AcpUI.AcpTreeView
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

using AcpBusinessLayer;
using AcpCommonLib;
using AcpCommonLib.UndoRedo;
using AcpUI.DragDrop;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

#nullable disable
namespace AcpUI;

public abstract class AcpTreeView : TreeView
{
  private IAcpFeatureNode currentRecord;
  private Dictionary<int, AcpTreeViewItem> rootNodes = new Dictionary<int, AcpTreeViewItem>();
  private bool treeIsNavigating;
  private bool capturedMouseDownNeedCaptureMouseUp;
  protected IAcpFeatureSection sectionToLaunch;

  public AcpTreeView()
  {
    this.Loaded += new RoutedEventHandler(this.AcpTreeView_Loaded);
    this.Unloaded += new RoutedEventHandler(this.AcpTreeView_Unloaded);
  }

  public Dictionary<int, AcpTreeViewItem> RootNodes => this.rootNodes;

  private void AcpTreeView_Loaded(object sender, RoutedEventArgs e)
  {
    UndoManager.LaunchSectionHandler += new AcpCommonLib.LaunchSection(this.LaunchSection);
    this.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(this.AcpTreeView_PreviewMouseLeftButtonDown);
    this.PreviewMouseLeftButtonUp += new MouseButtonEventHandler(this.AcpTreeView_PreviewMouseLeftButtonUp);
  }

  private void AcpTreeView_Unloaded(object sender, RoutedEventArgs e)
  {
    this.PreviewMouseLeftButtonDown -= new MouseButtonEventHandler(this.AcpTreeView_PreviewMouseLeftButtonDown);
    this.PreviewMouseLeftButtonUp -= new MouseButtonEventHandler(this.AcpTreeView_PreviewMouseLeftButtonUp);
    UndoManager.LaunchSectionHandler -= new AcpCommonLib.LaunchSection(this.LaunchSection);
    this.treeIsNavigating = false;
    this.capturedMouseDownNeedCaptureMouseUp = false;
    if (this.rootNodes == null)
      return;
    this.rootNodes.Clear();
  }

  private void AcpTreeView_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
  {
    if (this.treeIsNavigating)
    {
      this.capturedMouseDownNeedCaptureMouseUp = true;
      e.Handled = true;
    }
    else
      this.capturedMouseDownNeedCaptureMouseUp = false;
  }

  private void AcpTreeView_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
  {
    if (this.treeIsNavigating)
      e.Handled = true;
    if (!this.capturedMouseDownNeedCaptureMouseUp)
      return;
    e.Handled = true;
    this.capturedMouseDownNeedCaptureMouseUp = false;
  }

  public void OnTreeViewRecordNavigation(IAcpFeatureNode newRecord, TreeView MyTreeView)
  {
    Stopwatch.StartNew();
    IAcpRecordset parent = newRecord.Parent;
    if (parent == null)
      return;
    this.FindChildTreeViewItem(parent.RecsetId, newRecord.NodeId, MyTreeView.Items)?.Focus();
  }

  private AcpTreeViewItem FindTreeViewItem(int recsetId, ItemCollection items)
  {
    foreach (AcpTreeViewItem treeViewItem1 in (IEnumerable) items)
    {
      if (recsetId == treeViewItem1.RecsetId && treeViewItem1.NodeId == 0)
        return treeViewItem1;
      if (treeViewItem1.Items.Count > 0)
      {
        AcpTreeViewItem treeViewItem2 = this.FindTreeViewItem(recsetId, treeViewItem1.Items);
        if (treeViewItem2 != null)
          return treeViewItem2;
      }
    }
    return (AcpTreeViewItem) null;
  }

  private void OnCollectionItemMoved(
    int oldStartingIndex,
    int newStartingIndex,
    ItemCollection items,
    IAcpRecordset recset)
  {
    TreeViewItem insertItem = (TreeViewItem) items[oldStartingIndex];
    try
    {
      items.RemoveAt(oldStartingIndex);
    }
    catch (ArgumentOutOfRangeException ex)
    {
    }
    catch (Exception ex)
    {
      throw new Exception(ex.Message, ex.InnerException);
    }
    items.Insert(newStartingIndex, (object) insertItem);
    if (oldStartingIndex < newStartingIndex)
    {
      for (int index = oldStartingIndex; index < newStartingIndex + 1; ++index)
      {
        ((HeaderedItemsControl) items[index]).Header = (object) recset[index].ReferenceKey;
        ((AcpTreeViewItem) items[index]).ReferenceKey = recset[index].ReferenceKey;
      }
    }
    else
    {
      for (int index = newStartingIndex; index < oldStartingIndex + 1; ++index)
      {
        ((HeaderedItemsControl) items[index]).Header = (object) recset[index].ReferenceKey;
        ((AcpTreeViewItem) items[index]).ReferenceKey = recset[index].ReferenceKey;
      }
    }
  }

  public void OnTreeViewRecordOperation(
    IAcpRecordset recset,
    NotifyCollectionChangedEventArgs e,
    TreeView MyTreeView)
  {
    AcpTreeViewItem acpTreeViewItem1 = new AcpTreeViewItem();
    if (!this.UpdateTreeView(recset.RecsetId) || recset == null)
      return;
    AcpTreeViewItem treeViewItem = this.FindTreeViewItem(recset.RecsetId, MyTreeView.Items);
    if (treeViewItem == null)
      return;
    switch (e.Action)
    {
      case NotifyCollectionChangedAction.Add:
        if (e.NewStartingIndex == treeViewItem.Items.Count)
        {
          IEnumerator enumerator = e.NewItems.GetEnumerator();
          try
          {
            while (enumerator.MoveNext())
            {
              FeatureNode current = (FeatureNode) enumerator.Current;
              acpTreeViewItem1.Header = (object) current.ReferenceKey;
              if (recset.HasKeyField)
                acpTreeViewItem1.ReferenceKey = current.ReferenceKey;
              acpTreeViewItem1.RecsetId = recset.RecsetId;
              acpTreeViewItem1.NodeId = current.NodeId;
              treeViewItem.Items.Add((object) acpTreeViewItem1);
              if (treeViewItem.IsSelected)
              {
                treeViewItem.Focus();
                this.currentRecord = (IAcpFeatureNode) null;
              }
              else
                acpTreeViewItem1.Focus();
            }
            break;
          }
          finally
          {
            if (enumerator is IDisposable disposable)
              disposable.Dispose();
          }
        }
        else
        {
          for (int index = 0; index < e.NewItems.Count; ++index)
          {
            foreach (FeatureNode newItem in (IEnumerable) e.NewItems)
            {
              acpTreeViewItem1.Header = (object) newItem.ReferenceKey;
              if (recset.HasKeyField)
                acpTreeViewItem1.ReferenceKey = newItem.ReferenceKey;
              acpTreeViewItem1.RecsetId = recset.RecsetId;
              acpTreeViewItem1.NodeId = newItem.NodeId;
              treeViewItem.Items.Insert(e.NewStartingIndex, (object) acpTreeViewItem1);
            }
          }
          for (int newStartingIndex = e.NewStartingIndex; newStartingIndex < recset.Count; ++newStartingIndex)
          {
            ((HeaderedItemsControl) treeViewItem.Items[newStartingIndex]).Header = (object) recset[newStartingIndex].ReferenceKey;
            ((AcpTreeViewItem) treeViewItem.Items[newStartingIndex]).ReferenceKey = recset[newStartingIndex].ReferenceKey;
          }
          break;
        }
      case NotifyCollectionChangedAction.Remove:
        for (int index = treeViewItem.Items.Count - 1; index >= 0; --index)
        {
          AcpTreeViewItem removeItem = (AcpTreeViewItem) treeViewItem.Items[index];
          foreach (FeatureNode oldItem in (IEnumerable) e.OldItems)
          {
            if (removeItem.RecsetId == recset.RecsetId && removeItem.NodeId == oldItem.NodeId)
            {
              treeViewItem.Items.MoveCurrentToFirst();
              treeViewItem.Items.Remove((object) removeItem);
              if (treeViewItem.Items.Count > 0)
              {
                AcpTreeViewItem acpTreeViewItem2 = index != treeViewItem.Items.Count ? (AcpTreeViewItem) treeViewItem.Items[index] : (AcpTreeViewItem) treeViewItem.Items[index - 1];
                if (this.currentRecord == null)
                {
                  if (!treeViewItem.IsSelected)
                    treeViewItem.IsSelected = true;
                }
                else
                  acpTreeViewItem2.Focus();
              }
            }
          }
          if (e.OldStartingIndex < recset.Count)
          {
            for (int oldStartingIndex = e.OldStartingIndex; oldStartingIndex < recset.Count; ++oldStartingIndex)
            {
              ((HeaderedItemsControl) treeViewItem.Items[oldStartingIndex]).Header = (object) recset[oldStartingIndex].ReferenceKey;
              ((AcpTreeViewItem) treeViewItem.Items[oldStartingIndex]).ReferenceKey = recset[oldStartingIndex].ReferenceKey;
            }
          }
        }
        break;
      case NotifyCollectionChangedAction.Move:
        this.OnCollectionItemMoved(e.OldStartingIndex, e.NewStartingIndex, treeViewItem.Items, recset);
        break;
    }
  }

  public AcpTreeViewItem FindChildTreeViewItem(int recsetId, int nodeId, ItemCollection items)
  {
    foreach (AcpTreeViewItem childTreeViewItem1 in (IEnumerable) items)
    {
      if (recsetId == childTreeViewItem1.RecsetId && nodeId == childTreeViewItem1.NodeId)
        return childTreeViewItem1;
      if (childTreeViewItem1.Items.Count > 0)
      {
        AcpTreeViewItem childTreeViewItem2 = this.FindChildTreeViewItem(recsetId, nodeId, childTreeViewItem1.Items);
        if (childTreeViewItem2 != null)
          return childTreeViewItem2;
      }
    }
    return (AcpTreeViewItem) null;
  }

  public AcpTreeViewItem FindChildTreeViewItem(int recsetId, int nodeId)
  {
    AcpTreeViewItem childTreeViewItem1 = (AcpTreeViewItem) null;
    if (!this.RootNodes.TryGetValue(recsetId, out childTreeViewItem1))
      return (AcpTreeViewItem) null;
    if (childTreeViewItem1.Items.Count == 0)
      return childTreeViewItem1;
    foreach (AcpTreeViewItem childTreeViewItem2 in (IEnumerable) childTreeViewItem1.Items)
    {
      if (childTreeViewItem2.NodeId == nodeId)
        return childTreeViewItem2;
    }
    return (AcpTreeViewItem) null;
  }

  public void OnReferenceKeyChanged(IAcpFeatureNode node, TreeView MyTreeView)
  {
    IAcpRecordset parent = node.Parent;
    if (parent == null)
      return;
    AcpTreeViewItem childTreeViewItem = this.FindChildTreeViewItem(parent.RecsetId, node.NodeId, MyTreeView.Items);
    if (childTreeViewItem == null || !(node.ReferenceKey != ""))
      return;
    childTreeViewItem.Header = (object) node.ReferenceKey;
    if (!parent.HasKeyField)
      return;
    childTreeViewItem.ReferenceKey = node.ReferenceKey;
  }

  public virtual bool UpdateTreeView(int nRecsetID) => true;

  public void NavigateToContentPage(TreeView MyTreeView)
  {
    AcpTreeViewItem selectedItem = (AcpTreeViewItem) MyTreeView.SelectedItem;
    if (selectedItem == null)
      return;
    IAcpRecordset acpRecordset = (IAcpRecordset) null;
    IAcpRecordset feature;
    if (AppInfoManager.AppMode == ApplicationMode.CustomViewConfigurationMode)
    {
      feature = AppInfoManager.DefaultDocument.GetFeature(selectedItem.RecsetId);
      if (feature != null && !feature.SingleInstance && selectedItem.NodeId == 0 && !feature.HideRecordsFromTree)
      {
        acpRecordset = (IAcpRecordset) null;
        return;
      }
    }
    else
      feature = FeatureManager.GetFeature(selectedItem.RecsetId);
    if (feature == null)
      return;
    string uiPagePath;
    if (!feature.SingleInstance && selectedItem.NodeId != 0)
    {
      IAcpFeatureNode acpFeatureNode = feature.NodeFromId(selectedItem.NodeId);
      uiPagePath = acpFeatureNode.UIPagePath;
      this.currentRecord = acpFeatureNode;
    }
    else
    {
      uiPagePath = feature.UIPagePath;
      this.currentRecord = (IAcpFeatureNode) null;
      if (AppInfoManager.AppMode == ApplicationMode.CustomViewConfigurationMode && this.currentRecord == null)
      {
        this.currentRecord = feature[0];
        uiPagePath = this.currentRecord.UIPagePath;
      }
    }
    if (string.IsNullOrEmpty(uiPagePath))
      return;
    this.treeIsNavigating = true;
    DragDropManager.TreeNavigationStart();
    if (this.currentRecord != null)
      ((CollectionView) CollectionViewSource.GetDefaultView((object) (Recordset) this.currentRecord.Parent)).MoveCurrentTo((object) this.currentRecord);
    this.LaunchPage(uiPagePath);
  }

  public void LaunchSection(IAcpFeatureSection section)
  {
    if (this.treeIsNavigating)
      return;
    IAcpRecordset parentRecset = section.ParentRecset;
    string uiPagePath;
    if (!parentRecset.SingleInstance)
    {
      this.currentRecord = !parentRecset.IsEmbeddedRecset ? section.Parent : parentRecset.ParentSection.Parent;
      uiPagePath = this.currentRecord.UIPagePath;
    }
    else
    {
      uiPagePath = parentRecset.UIPagePath;
      this.currentRecord = parentRecset[0];
    }
    this.sectionToLaunch = section;
    if (string.IsNullOrEmpty(uiPagePath))
      return;
    this.treeIsNavigating = true;
    DragDropManager.TreeNavigationStart();
    if (this.currentRecord != null)
      ((CollectionView) CollectionViewSource.GetDefaultView((object) (Recordset) this.currentRecord.Parent)).MoveCurrentTo((object) this.currentRecord);
    this.LaunchPage(uiPagePath);
  }

  public virtual void LaunchPage(string pageUri) => this.OnLoadComplete((System.Windows.Controls.Frame) null);

  public void OnLoadComplete(System.Windows.Controls.Frame frmCenter)
  {
    this.treeIsNavigating = false;
    DragDropManager.TreeNavigationStop();
  }

  public IAcpFeatureNode CurrentRecord
  {
    get => this.currentRecord;
    set => this.currentRecord = value;
  }

  protected override void OnKeyDown(KeyEventArgs e)
  {
    if (e.Key == Key.F5)
      e.Handled = true;
    else
      base.OnKeyDown(e);
  }
}
