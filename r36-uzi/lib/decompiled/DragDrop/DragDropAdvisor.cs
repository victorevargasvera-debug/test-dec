// Decompiled with JetBrains decompiler
// Type: AcpUI.DragDrop.DragDropAdvisor
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

using AcpBusinessLayer;
using AcpBusinessLayer.UndoRedo;
using AcpCommonLib;
using AcpCommonLib.FieldsReport;
using AcpCommonLib.UndoRedo;
using AcpCommonResources;
using AcpUtility;
using Infragistics.Windows.DataPresenter;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

#nullable disable
namespace AcpUI.DragDrop;

public class DragDropAdvisor : IDragSourceAdvisor, IDropTargetAdvisor
{
  private const string zoneChannelAssignmentRecsetId = "2051";
  private const int dataWideRecsetId = 2028;
  private const int bookmarkUrlRecsetId = 4237;
  private const string producerTreeDataId = "ProducerTreeData";
  private IAcpBatchOperation Process;
  private static Dictionary<AcpRecRefField, string> RecRefsToRepair = new Dictionary<AcpRecRefField, string>();
  private static Dictionary<IAcpField, string> RecRefFieldsOfEmbedRecset = new Dictionary<IAcpField, string>();

  public UIElement SourceUI { get; set; }

  public DragDropEffects SupportedEffects
  {
    get => this.GetDragDropsEffects(this.SourceUI, (Dictionary<string, object>) null);
  }

  public bool IsDropAllowed(DragEventArgs dragData)
  {
    return this.GetDragDropsEffects((UIElement) this.ConsumerNode, (Dictionary<string, object>) dragData.Data.GetData("ProducerTreeData")) != 0;
  }

  private DragDropEffects GetDragDropsEffects(
    UIElement uiElement,
    Dictionary<string, object> producerTreeData)
  {
    switch (uiElement)
    {
      case AcpTreeView _:
        AcpTreeView acpTreeView = uiElement as AcpTreeView;
        if (acpTreeView.SelectedItem is AcpTreeViewItem)
          return this.GetDragDropsEffectsFromAcpTree(acpTreeView.SelectedItem as AcpTreeViewItem, producerTreeData);
        break;
      case AcpTreeViewItem _:
        return this.GetDragDropsEffectsFromAcpTree(uiElement as AcpTreeViewItem, producerTreeData);
    }
    return DragDropEffects.Copy | DragDropEffects.Move;
  }

  private DragDropEffects GetDragDropsEffectsFromAcpTree(
    AcpTreeViewItem targetNode,
    Dictionary<string, object> producerTreeData)
  {
    Dictionary<string, object> dictionary = new Dictionary<string, object>();
    SortedDictionary<int, int> listOfRecsets = new SortedDictionary<int, int>();
    this.GetChildNodeDataObject(dictionary, listOfRecsets, targetNode);
    if (dictionary != null && dictionary.ContainsKey("2051"))
    {
      if (dictionary["2051"] is IAcpRecordset)
      {
        if (DragDropEffectsUtilitie.IsZoneChannelAssignmentRecsetDragDropDisable(dictionary["2051"] as IAcpRecordset, producerTreeData))
        {
          this.DisplayDragAndDropDisallowanceNotice();
          return DragDropEffects.None;
        }
      }
      else if (dictionary["2051"] is IAcpFeatureNode && DragDropEffectsUtilitie.IsZoneDragDropDisble(dictionary["2051"] as IAcpFeatureNode))
      {
        this.DisplayDragAndDropDisallowanceNotice();
        return DragDropEffects.None;
      }
    }
    return DragDropEffects.Copy | DragDropEffects.Move;
  }

  private void DisplayDragAndDropDisallowanceNotice()
  {
    AppInfoManager.DragAndDropFieldsReport.RegisterFieldInReport((IAcpField) null, AcpResources.Drag_and_drop_blocked_when_clone_enable_is_set_to_true_in_ZCA, false);
    AppInfoManager.DragAndDropFieldsReport.FieldsReportChanged = true;
  }

  private void GetChildNodeDataObject(
    Dictionary<string, object> obj,
    SortedDictionary<int, int> listOfRecsets,
    AcpTreeViewItem currentNode)
  {
    if (currentNode == null)
      return;
    if (currentNode.RecsetId == 0 && currentNode.NodeId == 0 || currentNode.NodeId != 0)
    {
      int count = currentNode.Items.Count;
      if (count > 0)
      {
        ItemCollection items = currentNode.Items;
        items.MoveCurrentToFirst();
        for (int index = 0; index < count; ++index)
        {
          AcpTreeViewItem currentItem = (AcpTreeViewItem) items.CurrentItem;
          items.MoveCurrentToNext();
          this.GetChildNodeDataObject(obj, listOfRecsets, currentItem);
        }
      }
    }
    int recsetId = currentNode.RecsetId;
    int nodeId = currentNode.NodeId;
    if (recsetId == 0 || recsetId == -1 || recsetId == 4237 || obj.ContainsKey(recsetId.ToString((IFormatProvider) CultureInfo.InvariantCulture)))
      return;
    IAcpRecordset feature1 = FeatureManager.GetFeature(recsetId);
    if (nodeId == 0)
    {
      feature1.CalculateVisibility(true);
      if (!feature1.HiddenStatic)
        obj.Add(recsetId.ToString((IFormatProvider) CultureInfo.InvariantCulture), (object) feature1);
    }
    else
    {
      feature1.NodeFromId(nodeId).CalculateVisibility(true);
      obj.Add(recsetId.ToString((IFormatProvider) CultureInfo.InvariantCulture), (object) feature1.NodeFromId(nodeId));
    }
    if (feature1.DataTransferOrder <= 0)
      return;
    listOfRecsets.Add(feature1.DataTransferOrder, recsetId);
    if (recsetId != 2028)
      return;
    IAcpRecordset feature2 = FeatureManager.GetFeature(4237);
    if (feature2 == null)
      return;
    feature2.CalculateVisibility(true);
    if (!feature2.HiddenStatic)
      obj.Add(4237.ToString((IFormatProvider) CultureInfo.InvariantCulture), (object) feature2);
    if (feature2.DataTransferOrder <= 0)
      return;
    listOfRecsets.Add(feature2.DataTransferOrder, 4237);
  }

  public DataObject GetDataObject(UIElement draggedElement)
  {
    AppInfoManager.DndOperation = true;
    AppInfoManager.DragOperation = true;
    DataObject dataObject = new DataObject();
    Dictionary<string, object> data1 = new Dictionary<string, object>();
    Dictionary<string, object> data2 = new Dictionary<string, object>();
    SortedDictionary<int, int> listOfRecsets = new SortedDictionary<int, int>();
    if (draggedElement is AcpTreeViewItem currentNode && currentNode.HasHeader)
    {
      data1.Add("ProducerNodeHeader", (object) currentNode.Header.ToString());
      data1.Add("ProducerNodeRecsetID", (object) currentNode.RecsetId);
      data1.Add("ProducerNodeNodeID", (object) currentNode.NodeId);
      data1.Add("ProducerNodeReferenceKey", (object) currentNode.ReferenceKey);
      this.GetChildNodeDataObject(data2, listOfRecsets, currentNode);
      data2.Add("ListOfRecsets", (object) listOfRecsets);
      dataObject.SetData("ProducerTreeData", (object) data1);
      dataObject.SetData("ProducerData", (object) data2);
      dataObject.SetData("ProducerApplicationLanguage", (object) AppInfoManager.DndVersionManager.GetApplicationLanguage());
      object versionObj = AppInfoManager.DndVersionManager.GetVersionObj();
      if (versionObj != null)
        dataObject.SetData("ProducerVersionData", versionObj);
      return dataObject;
    }
    dataObject.SetData(DataFormats.Text, (object) "NO DATA");
    return dataObject;
  }

  public void FinishDrag(UIElement draggedElement, DragDropEffects finalEffects)
  {
    AppInfoManager.DndOperation = false;
    AppInfoManager.DragOperation = false;
  }

  public bool IsDraggable(UIElement dragElement)
  {
    bool flag = false;
    AcpTreeViewItem acpTreeViewItem = this.IsAcpTreeViewItem((object) dragElement);
    if (acpTreeViewItem != null && (acpTreeViewItem.RecsetId != -1 || acpTreeViewItem.NodeId != -1))
      flag = true;
    return flag;
  }

  private bool IsInRecordSelectorArea(object obj)
  {
    bool flag = false;
    if (obj is DependencyObject reference)
    {
      DependencyObject parent = VisualTreeHelper.GetParent(reference);
      if (reference is RecordSelector)
        flag = true;
      else if (parent != null)
        flag = this.IsInRecordSelectorArea((object) parent);
    }
    return flag;
  }

  private AcpTreeViewItem IsAcpTreeViewItem(object obj)
  {
    AcpTreeViewItem acpTreeViewItem1 = (AcpTreeViewItem) null;
    if (obj is DependencyObject reference)
    {
      DependencyObject parent = VisualTreeHelper.GetParent(reference);
      if (reference is AcpTreeViewItem acpTreeViewItem2)
        acpTreeViewItem1 = acpTreeViewItem2;
      else if (parent != null)
        acpTreeViewItem1 = this.IsAcpTreeViewItem((object) parent);
    }
    return acpTreeViewItem1;
  }

  public UIElement TargetUI { get; set; }

  public AcpTreeViewItem ConsumerNode { get; set; }

  public bool IsDropAllowedByApp(IDataObject obj)
  {
    if (!obj.GetDataPresent("ProducerVersionData"))
      return true;
    object data = obj.GetData("ProducerVersionData");
    object versionObj = AppInfoManager.DndVersionManager.GetVersionObj();
    int num = AppInfoManager.DndVersionManager.IsDropAllowedByApp(data, versionObj) ? 1 : 0;
    AppInfoManager.ProducerVersion = (int) data;
    return num != 0;
  }

  public bool IsDropAllowedByLocalApp(IDataObject obj)
  {
    return AppInfoManager.DndVersionManager.IsDropAllowedByLocalApp(!obj.GetDataPresent("ProducerVersionData") ? (object) 1 : obj.GetData("ProducerVersionData"), AppInfoManager.DndVersionManager.GetVersionObj());
  }

  public bool IsDropAllowedByApplicationLanguage(IDataObject obj)
  {
    string name1 = obj.GetData("ProducerApplicationLanguage") is CultureInfo data ? data.Name : (string) null;
    if (name1 == null)
      return true;
    string name2 = AppInfoManager.DndVersionManager.GetApplicationLanguage().Name;
    return name1 == name2;
  }

  public bool IsValidDataObject(IDataObject obj)
  {
    return obj.GetDataPresent("ProducerTreeData") && obj.GetDataPresent("ProducerData");
  }

  public AcpTreeViewItem IsValidConsumerNode(object uiObj, DragEventArgs e)
  {
    int num1 = -1;
    int num2 = -1;
    string a = (string) null;
    int num3 = -1;
    AcpTreeViewItem acpTreeViewItem1 = (AcpTreeViewItem) null;
    Dictionary<string, object> data = (Dictionary<string, object>) e.Data.GetData("ProducerTreeData");
    object obj;
    if (data.TryGetValue("ProducerNodeRecsetID", out obj))
      num1 = (int) obj;
    if (data.TryGetValue("ProducerNodeNodeID", out obj))
      num2 = (int) obj;
    if (data.TryGetValue("ProducerNodeReferenceKey", out obj))
      a = (string) obj;
    if (data.TryGetValue("HotlistParentRecsetId", out obj))
      num3 = (int) obj;
    UIElement relativeTo = (UIElement) uiObj;
    System.Windows.Point position = e.GetPosition((IInputElement) relativeTo);
    DependencyObject reference = (DependencyObject) relativeTo.InputHitTest(position);
    if (reference is TextBlock)
    {
      do
      {
        reference = VisualTreeHelper.GetParent(reference);
      }
      while (!(reference is AcpTreeViewItem) && reference != null);
      if (reference != null)
      {
        AcpTreeViewItem acpTreeViewItem2 = (AcpTreeViewItem) reference;
        if (num3 == -1)
        {
          if (num2 == 0)
          {
            if (num2 == acpTreeViewItem2.NodeId && num1 == acpTreeViewItem2.RecsetId)
              acpTreeViewItem1 = acpTreeViewItem2;
          }
          else if (a != null && acpTreeViewItem2.ReferenceKey != null)
          {
            if (num1 == acpTreeViewItem2.RecsetId && (string.Equals(a, acpTreeViewItem2.ReferenceKey, StringComparison.CurrentCulture) || acpTreeViewItem2.NodeId == 0))
              acpTreeViewItem1 = acpTreeViewItem2;
          }
          else if (num1 == acpTreeViewItem2.RecsetId)
            acpTreeViewItem1 = acpTreeViewItem2;
        }
      }
    }
    return acpTreeViewItem1;
  }

  private void CopyProducerRecToConsumerRec(
    IAcpFeatureNode producerRecord,
    IAcpFeatureNode consumerRecord,
    ContainerTask task,
    bool topNodeDnd)
  {
    FeatureNode featureNode1 = producerRecord as FeatureNode;
    FeatureNode featureNode2 = consumerRecord as FeatureNode;
    foreach (FeatureSection featureSection in producerRecord.FeatureSectionsCollectionByOrder)
    {
      IAcpFeatureSection acpFeatureSection = consumerRecord[featureSection.FeatureSectionId];
      if (acpFeatureSection != null)
      {
        foreach (IAcpField source in featureSection.FieldsCollectionByOrder)
        {
          if (acpFeatureSection[source.UIName] is AcpFieldBase acpFieldBase)
          {
            if (acpFieldBase.Name == "TrkSysGeneralAskRequired_A44909" && source is AcpField<bool> acpField && acpField.Value)
              acpFieldBase.Editable = true;
            if (acpFieldBase.AllowsDataTransfer() && !((AcpFieldBase) source).HiddenStatic && !((AcpFieldBase) source).UIInvalid || featureNode1.KeyField == source && featureNode2.KeyField == acpFieldBase && acpFieldBase.AllowsDataTransfer() && ((AcpFieldBase) source).HiddenStatic)
            {
              try
              {
                acpFieldBase.DisableASKRangeValidation = false;
                bool flag = true;
                if (acpFieldBase is AcpRecRefField key)
                {
                  DragDropAdvisor.RecRefFieldsOfEmbedRecset.Remove((IAcpField) key);
                  if (key.SlaveRecRef && !key.Applicable && key.HasSiblingRecset)
                    flag = false;
                  else if (key.SlaveRecRef)
                    DragDropAdvisor.RecRefsToRepair[(AcpRecRefField) acpFieldBase] = ((AcpFieldX<int, string>) source).UIValue;
                }
                if (flag)
                {
                  task.AddTask(acpFieldBase.CopyValueOf(source));
                  if (acpFieldBase.UnsupportedValue)
                  {
                    acpFieldBase.UnsupportedValue = false;
                    AppInfoManager.DragAndDropFieldsReport.RegisterFieldInReport((IAcpField) acpFieldBase, AcpResources.Value_Not_Copied_Unsupported_Value, false);
                  }
                }
              }
              catch
              {
              }
            }
            else if (!source.HiddenStatic && !acpFieldBase.HiddenStatic)
            {
              if (acpFieldBase.BlockDataTransfer)
                AppInfoManager.DragAndDropFieldsReport.RegisterFieldInReport((IAcpField) acpFieldBase, AcpResources.Value_Not_Copied_Unsupported_DataTransfer, false);
              else if (!acpFieldBase.Editable)
                AppInfoManager.DragAndDropFieldsReport.RegisterFieldInReport((IAcpField) acpFieldBase, AcpResources.Value_Not_Copied_Uneditable_Destination, false);
              else if (((AcpFieldBase) source).UIInvalid)
                AppInfoManager.DragAndDropFieldsReport.RegisterFieldInReport((IAcpField) acpFieldBase, AcpResources.Value_Not_Copied_Unacceptable_Destination, false);
            }
          }
          else
            AppInfoManager.DragAndDropFieldsReport.RegisterFieldInReport((IAcpField) null, AcpResources.Cannot_Copy_Not_Exists.AcpStringFormat((object) source.Name), false);
        }
        int num = featureSection.HasEmbeddedRecset ? 1 : 0;
        Dictionary<string, List<IAcpField>> dictionary = new Dictionary<string, List<IAcpField>>();
        if (num != 0)
        {
          IAcpRecordset embeddedRecset1 = featureSection.EmbeddedRecset;
          IAcpRecordset embeddedRecset2 = acpFeatureSection.EmbeddedRecset;
          if (embeddedRecset1 != null && embeddedRecset2 != null && !embeddedRecset1.HiddenStatic && !embeddedRecset2.HiddenStatic)
          {
            if (embeddedRecset1.RecsetId == embeddedRecset2.RecsetId)
            {
              FeatureNode featureNode3 = (FeatureNode) embeddedRecset2[0];
              if (featureNode3 != null && featureNode3.Parent != null && featureNode3.Parent.ParentSection != null)
                AppInfoManager.DndAndImportSection.Add(featureNode3.Parent.ParentSection.GetType());
              if (!topNodeDnd)
              {
                if (featureNode3 != null && embeddedRecset2.Count > 0 && featureNode3.KeyField != null && !featureNode3.KeyField.BlockDataTransfer && featureNode3.KeyField.Editable && embeddedRecset2.Min != embeddedRecset2.Max)
                {
                  foreach (FeatureNode featureNode4 in (Collection<FeatureNode>) embeddedRecset2)
                  {
                    if (featureNode4.KeyField.ReferencingFields != null)
                    {
                      foreach (AcpRecRefField referencingField in featureNode4.KeyField.ReferencingFields)
                        DragDropAdvisor.RecRefFieldsOfEmbedRecset[(IAcpField) referencingField] = referencingField.UIValue;
                    }
                  }
                  ((Recordset) embeddedRecset2).FindNewFieldsInEmbeddedRecset_DnD(embeddedRecset1, dictionary);
                  embeddedRecset2.ClearRecordset(embeddedRecset2, task);
                }
                else if (featureNode3 != null && embeddedRecset2.Count > 0 && featureNode3.KeyField == null && embeddedRecset2.Min != embeddedRecset2.Max)
                {
                  ((Recordset) embeddedRecset2).FindNewFieldsInEmbeddedRecset_DnD(embeddedRecset1, dictionary);
                  embeddedRecset2.ClearRecordset(embeddedRecset2, task);
                }
              }
              this.CopyProducerToConsumer(embeddedRecset1, embeddedRecset2, task, true);
              ((Recordset) embeddedRecset2).UpdateNewFieldsInEmbeddedRecset_ImpExpDnD(task, dictionary);
            }
            else
              AppInfoManager.DragAndDropFieldsReport.RegisterFieldInReport((IAcpField) null, AcpResources.Cannot_Copy_Not_Exists.AcpStringFormat((object) embeddedRecset1.Path("\\")), false);
          }
        }
        dictionary.Clear();
      }
      else
        AppInfoManager.DragAndDropFieldsReport.RegisterFieldInReport((IAcpField) null, AcpResources.Cannot_Copy_Not_Exists.AcpStringFormat((object) featureSection.UIName), false);
    }
  }

  private void CopyProducerToConsumer(
    IAcpRecordset producer,
    IAcpRecordset consumer,
    ContainerTask task,
    bool topNodeDnd)
  {
    Recordset recordset = (Recordset) consumer;
    if (topNodeDnd)
    {
      int num1 = producer.Count - consumer.Count;
      if (num1 >= 0)
      {
        for (int index = 0; index < producer.Count; ++index)
        {
          IAcpFeatureNode producerRecord = producer[index];
          IAcpFeatureNode acpFeatureNode;
          if (index < consumer.Count)
          {
            acpFeatureNode = consumer[index];
          }
          else
          {
            if (consumer.CounterToMax == 0)
            {
              AppInfoManager.DragAndDropFieldsReport.RegisterFieldInReport((IAcpField) null, AcpResources.Max_Rec_Reached_Add.AcpStringFormat((object) consumer.Path("\\")), false);
              break;
            }
            if (consumer.CounterToMax < 0)
            {
              AppInfoManager.DragAndDropFieldsReport.RegisterFieldInReport((IAcpField) null, AcpResources.Max_Rec_Exceeded.AcpStringFormat((object) consumer.Path("\\")), false);
              break;
            }
            FeatureNode defaultRecordHelper = recordset.CreateDefaultRecordHelper();
            defaultRecordHelper.CalculateVisibility(true);
            defaultRecordHelper.CalculateEditability(true);
            task.AddTask((UndoableTask) new AddRecordTask(defaultRecordHelper));
            acpFeatureNode = recordset.NodeFromId(defaultRecordHelper.NodeId);
          }
          if (acpFeatureNode != null)
          {
            if (consumer.PreDataTransferClearRecordset)
              ((Recordset) consumer).ClearMyEmbeddedRecsets(acpFeatureNode, task, DragDropAdvisor.RecRefFieldsOfEmbedRecset);
            this.CopyProducerRecToConsumerRec(producerRecord, acpFeatureNode, task, topNodeDnd);
          }
        }
      }
      else
      {
        int num2 = Math.Abs(num1);
        if (num2 > consumer.CounterToMin)
        {
          num2 = consumer.CounterToMin;
          AppInfoManager.DragAndDropFieldsReport.RegisterFieldInReport((IAcpField) null, AcpResources.Min_Rec_Reached_Delete.AcpStringFormat((object) consumer.Path("\\")), false);
        }
        for (int index = 0; index < num2; ++index)
        {
          if (AppInfoManager.SkipValueSetter || !Permission.Have(Permissions.Undeletable, ((FeatureNode) recordset[recordset.Count - 1]).Permissions))
            task.AddTask((UndoableTask) new DeleteRecordTask((FeatureNode) recordset[recordset.Count - 1]));
        }
        for (int index = 0; index < producer.Count; ++index)
        {
          IAcpFeatureNode producerRecord = producer[index];
          IAcpFeatureNode acpFeatureNode = (IAcpFeatureNode) null;
          if (index < consumer.Count)
            acpFeatureNode = consumer[index];
          if (acpFeatureNode != null)
          {
            if (consumer.PreDataTransferClearRecordset)
              ((Recordset) consumer).ClearMyEmbeddedRecsets(acpFeatureNode, task, DragDropAdvisor.RecRefFieldsOfEmbedRecset);
            this.CopyProducerRecToConsumerRec(producerRecord, acpFeatureNode, task, topNodeDnd);
          }
        }
      }
    }
    else
    {
      List<string> stringList = new List<string>();
      for (int index = 0; index < producer.Count; ++index)
      {
        IAcpFeatureNode producerRecord = producer[index];
        IAcpFeatureNode acpFeatureNode = (IAcpFeatureNode) null;
        if (producer.HasKeyField)
        {
          if (consumer.Count > 0 && !stringList.Contains(producerRecord.ReferenceKey))
            acpFeatureNode = consumer.NodeFromKey(producerRecord.ReferenceKey);
        }
        else if (producer.SingleInstance)
          acpFeatureNode = consumer[0];
        else if (index < consumer.Count)
          acpFeatureNode = consumer[index];
        if (acpFeatureNode == null)
        {
          if (consumer.CounterToMax == 0)
            AppInfoManager.DragAndDropFieldsReport.RegisterFieldInReport((IAcpField) null, AcpResources.Max_Rec_Reached_Add.AcpStringFormat((object) consumer.Path("\\")), false);
          else if (consumer.CounterToMax < 0)
          {
            AppInfoManager.DragAndDropFieldsReport.RegisterFieldInReport((IAcpField) null, AcpResources.Max_Rec_Exceeded.AcpStringFormat((object) consumer.Path("\\")), false);
          }
          else
          {
            FeatureNode defaultRecordHelper = recordset.CreateDefaultRecordHelper();
            defaultRecordHelper.CalculateVisibility(true);
            defaultRecordHelper.CalculateEditability(true);
            task.AddTask((UndoableTask) new AddRecordTask(defaultRecordHelper));
            acpFeatureNode = recordset.NodeFromId(defaultRecordHelper.NodeId);
          }
        }
        if (acpFeatureNode != null)
        {
          if (consumer.PreDataTransferClearRecordset)
            ((Recordset) consumer).ClearMyEmbeddedRecsets(acpFeatureNode, task, DragDropAdvisor.RecRefFieldsOfEmbedRecset);
          this.CopyProducerRecToConsumerRec(producerRecord, acpFeatureNode, task, topNodeDnd);
          stringList.Add(acpFeatureNode.ReferenceKey);
        }
      }
      stringList.Clear();
    }
  }

  public void OnDropCompleted(IDataObject obj, System.Windows.Point dropPoint, AcpTreeViewItem consumerNode)
  {
    ModifyAppInfoStateTask task = new ModifyAppInfoStateTask(new Dictionary<string, bool>()
    {
      {
        "DndOperation",
        true
      },
      {
        "DropOperation",
        true
      },
      {
        "DndOperationCompleted",
        false
      }
    });
    task.Do();
    DragDropAdvisor.RecRefsToRepair.Clear();
    bool topNodeDnd = false;
    if (AppInfoManager.DragAndDropFieldsReport == null)
      AppInfoManager.DragAndDropFieldsReport = new FieldsReportManager();
    else
      AppInfoManager.DragAndDropFieldsReport.Clear();
    ConstraintManager.Suspend();
    UndoManager.StopUndoRedo();
    AppInfoManager.BackgroundDeserializeOpertaion = true;
    Dictionary<string, object> data1;
    Dictionary<string, object> data2;
    try
    {
      data1 = (Dictionary<string, object>) obj.GetData("ProducerTreeData");
      data2 = (Dictionary<string, object>) obj.GetData("ProducerData");
    }
    catch (Exception ex)
    {
      string str = $"Message: {ex.InnerException.Message}; Source: {ex.InnerException.Source}";
      ConstraintManager.Resume();
      UndoManager.StartUndoRedo();
      AppInfoManager.BackgroundDeserializeOpertaion = false;
      AppInfoManager.DropOperation = false;
      AppInfoManager.DndOperation = false;
      AppInfoManager.DndOperationCompleted = false;
      AppInfoManager.SkipValueSetter = false;
      AppInfoManager.DragAndDropFieldsReport.RegisterFieldInReport((IAcpField) null, AcpResources.Error_Drop_Opn, false);
      AcpUI.Common.Utility.FieldsReportChanged((object) this, FieldReportType.DnD);
      return;
    }
    AppInfoManager.BackgroundDeserializeOpertaion = false;
    ConstraintManager.Resume();
    UndoManager.StartUndoRedo();
    AppInfoManager.DndOperationList = data2;
    SortedDictionary<int, int> sortedDictionary1 = (SortedDictionary<int, int>) null;
    object obj1;
    if (data2.TryGetValue("ListOfRecsets", out obj1))
      sortedDictionary1 = (SortedDictionary<int, int>) obj1;
    string key1 = (string) null;
    object obj2;
    if (data1.TryGetValue("ProducerNodeReferenceKey", out obj2))
      key1 = (string) obj2;
    if (consumerNode != null)
    {
      ContainerTask containerTask = new ContainerTask("Drag and Drop");
      if (sortedDictionary1 != null)
      {
        containerTask.AddTask((UndoableTask) task);
        SortedDictionary<int, int> sortedDictionary2 = new SortedDictionary<int, int>();
        foreach (KeyValuePair<int, int> keyValuePair in sortedDictionary1)
        {
          int num = keyValuePair.Value;
          object obj3;
          data2.TryGetValue(num.ToString((IFormatProvider) CultureInfo.InvariantCulture), out obj3);
          if (obj3 is IAcpRecordset acpRecordset)
          {
            if (acpRecordset.DataTransferOrder > 0)
              sortedDictionary2.Add(acpRecordset.DataTransferOrder, num);
          }
          else
            sortedDictionary2.Add(keyValuePair.Key, num);
        }
        if (consumerNode.RecsetId == 0 && consumerNode.NodeId == 0)
          topNodeDnd = true;
        AppInfoManager.SkipValueSetter = topNodeDnd;
        this.Process.Data = (object) data2;
        this.Process.PreProcess(containerTask);
        foreach (KeyValuePair<int, int> keyValuePair in sortedDictionary2)
        {
          int id = keyValuePair.Value;
          object obj4;
          data2.TryGetValue(id.ToString((IFormatProvider) CultureInfo.InvariantCulture), out obj4);
          IAcpRecordset acpRecordset = obj4 as IAcpRecordset;
          IAcpFeatureNode acpFeatureNode1 = obj4 as IAcpFeatureNode;
          if (acpRecordset != null)
          {
            IAcpRecordset producer = acpRecordset;
            IAcpRecordset feature = FeatureManager.GetFeature(id);
            if (feature != null)
            {
              if (feature != producer)
              {
                if (!producer.HiddenStatic && !feature.HiddenStatic)
                {
                  if (feature.PreDataTransferClearRecordset & topNodeDnd)
                    feature.ClearRecordset(feature, containerTask);
                  feature.CalculateVisibility(true);
                  feature.CalculateEditability(true);
                  this.CopyProducerToConsumer(producer, feature, containerTask, topNodeDnd);
                }
              }
              else
                AppInfoManager.DragAndDropFieldsReport.RegisterFieldInReport((IAcpField) null, AcpResources.Cannot_Drop_Itself.AcpStringFormat((object) producer.Path("\\")), false);
            }
            else
              AppInfoManager.DragAndDropFieldsReport.RegisterFieldInReport((IAcpField) null, AcpResources.Cannot_Copy_Not_Exists.AcpStringFormat((object) producer.Path("\\")), false);
          }
          else if (acpFeatureNode1 != null)
          {
            IAcpFeatureNode producerRecord = acpFeatureNode1;
            IAcpRecordset feature = FeatureManager.GetFeature(id);
            if (feature != null)
            {
              IAcpFeatureNode acpFeatureNode2 = (IAcpFeatureNode) null;
              if (consumerNode.NodeId != 0)
                acpFeatureNode2 = feature.NodeFromId(consumerNode.NodeId);
              else if (producerRecord.Parent != feature)
              {
                if (((FeatureNode) producerRecord).KeyField != null && feature.Count > 0)
                  acpFeatureNode2 = feature.NodeFromKey(key1);
                if (acpFeatureNode2 == null)
                {
                  if (feature.CounterToMax == 0)
                  {
                    AppInfoManager.DragAndDropFieldsReport.RegisterFieldInReport((IAcpField) null, AcpResources.Max_Rec_Reached_Add.AcpStringFormat((object) feature.Path("\\")), false);
                  }
                  else
                  {
                    FeatureNode defaultRecordHelper = ((Recordset) feature).CreateDefaultRecordHelper();
                    defaultRecordHelper.CalculateVisibility(true);
                    defaultRecordHelper.CalculateEditability(true);
                    containerTask.AddTask((UndoableTask) new AddRecordTask(defaultRecordHelper));
                    acpFeatureNode2 = feature.NodeFromId(defaultRecordHelper.NodeId);
                  }
                }
              }
              else
                AppInfoManager.DragAndDropFieldsReport.RegisterFieldInReport((IAcpField) null, AcpResources.Cannot_Drop_Parent.AcpStringFormat((object) producerRecord.Path("\\")), false);
              if (acpFeatureNode2 != null)
              {
                if (acpFeatureNode2 != producerRecord)
                {
                  if (feature.PreDataTransferClearRecordset)
                    ((Recordset) feature).ClearMyEmbeddedRecsets(acpFeatureNode2, containerTask, DragDropAdvisor.RecRefFieldsOfEmbedRecset);
                  acpFeatureNode2.CalculateVisibility(true);
                  acpFeatureNode2.CalculateEditability(true);
                  this.CopyProducerRecToConsumerRec(producerRecord, acpFeatureNode2, containerTask, topNodeDnd);
                }
                else
                  AppInfoManager.DragAndDropFieldsReport.RegisterFieldInReport((IAcpField) null, AcpResources.Cannot_Drop_Itself.AcpStringFormat((object) producerRecord.Path("\\")), false);
              }
            }
            else
              AppInfoManager.DragAndDropFieldsReport.RegisterFieldInReport((IAcpField) null, AcpResources.Cannot_Copy_Not_Exists.AcpStringFormat((object) producerRecord.Path("\\")), false);
          }
        }
        foreach (KeyValuePair<AcpRecRefField, string> keyValuePair in DragDropAdvisor.RecRefsToRepair)
        {
          AcpRecRefField key2 = keyValuePair.Key;
          containerTask.AddTask((UndoableTask) new ModifyRecRefDataTask(key2, keyValuePair.Value));
          if (key2.ValueSetter != null)
            key2.ValueSetter(key2.Parent, containerTask);
        }
        foreach (KeyValuePair<IAcpField, string> keyValuePair in DragDropAdvisor.RecRefFieldsOfEmbedRecset)
        {
          AcpRecRefField key3 = keyValuePair.Key as AcpRecRefField;
          if (key3.HiddenStatic)
            key3.ResetToDefaultWithUndo(containerTask);
        }
        foreach (KeyValuePair<IAcpField, string> keyValuePair in DragDropAdvisor.RecRefFieldsOfEmbedRecset)
        {
          AcpRecRefField key4 = keyValuePair.Key as AcpRecRefField;
          if (!key4.HiddenStatic)
          {
            containerTask.AddTask((UndoableTask) new ModifyRecRefDataTask(key4, keyValuePair.Value));
            if (key4.ValueSetter != null)
              key4.ValueSetter(key4.Parent, containerTask);
          }
        }
      }
      AppInfoManager.DragAndDropFieldsReport.RegisterFieldInReport((IAcpField) null, AcpResources.Drag_Drop_Opn_Complete, false);
      AcpUI.Common.Utility.FieldsReportChanged((object) this, FieldReportType.DnD);
      if (containerTask != null && containerTask.Tasks.Count > 0)
      {
        AppInfoManager.DndAndImportTask = containerTask;
        Dictionary<string, bool> newStates = new Dictionary<string, bool>();
        newStates.Add("DropOperation", false);
        newStates.Add("DndOperation", false);
        newStates.Add("DndOperationCompleted", true);
        this.Process.PostProcess(containerTask);
        containerTask.AddTask((UndoableTask) new ModifyAppInfoStateTask(newStates));
        UndoManager.AddTask((UndoableTask) containerTask);
      }
      else if (!UndoManager.MarkForUndo)
        UndoManager.StartUndoRedo();
    }
    bool flag = UndoManager.StopUndoRedo();
    foreach (Recordset feature in FeatureManager.Features)
    {
      foreach (AcpRecRefField recRefField in feature.RecRefFields)
        recRefField.CleanupDuplicates();
    }
    if (flag)
      UndoManager.StartUndoRedo();
    DragDropAdvisor.RecRefsToRepair.Clear();
    DragDropAdvisor.RecRefFieldsOfEmbedRecset.Clear();
    AppInfoManager.DndAndImportSection.Clear();
    AppInfoManager.DndAndImportTask = (ContainerTask) null;
  }

  public UIElement GetVisualFeedback(IDataObject obj)
  {
    TextBlock visualFeedback = new TextBlock();
    object obj1;
    if (((Dictionary<string, object>) obj.GetData("ProducerTreeData")).TryGetValue("ProducerNodeHeader", out obj1))
      visualFeedback.Text = obj1 as string;
    visualFeedback.Background = (Brush) new SolidColorBrush(Colors.Gray);
    visualFeedback.Foreground = (Brush) new SolidColorBrush(Colors.White);
    visualFeedback.Width = (double) (visualFeedback.Text.Length + 125);
    visualFeedback.Height = 25.0;
    visualFeedback.Opacity = 0.5;
    return (UIElement) visualFeedback;
  }

  public void SetProcess(IAcpBatchOperation process) => this.Process = process;
}
