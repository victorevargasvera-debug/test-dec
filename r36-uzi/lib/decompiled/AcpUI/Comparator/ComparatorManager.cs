// Decompiled with JetBrains decompiler
// Type: AcpUI.Comparator.ComparatorManager
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

using AcpBusinessLayer;
using AcpCommonLib;
using AcpCommonLib.UndoRedo;
using AcpCommonResources;
using AcpUILib;
using AcpUtility;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

#nullable disable
namespace AcpUI.Comparator;

public static class ComparatorManager
{
  public static void CompareDocuments(Document activeDoc, Document compDoc)
  {
    UndoManager.StopUndoRedo();
    if (activeDoc != null && compDoc != null)
    {
      UndoManager.Reset();
      foreach (IAcpRecordset feature1 in activeDoc.Features)
      {
        IAcpRecordset feature2 = compDoc.GetFeature(feature1.RecsetId);
        if (!feature1.HiddenStatic && feature2 != null)
          ComparatorManager.CompareRecsets(feature1, feature2, false);
        else if (feature2 == null && !feature1.HiddenStatic && feature1.HasVisibleObjects)
          AppInfoManager.ComparatorFieldsReport.RegisterFieldInReport((IAcpField) null, AcpResources.Cannot_Compare_Field_Does_Not_Exist_In_Comparison.AcpStringFormat((object) feature1.Path("\\")), false);
      }
      AppInfoManager.ComparatorFieldsReport.RegisterFieldInReport((IAcpField) null, AcpResources.Comparison_Completed, false);
      AppInfoManager.ComparatorFieldsReport.FieldsReportChanged = true;
      if (AppInfoManager.ComparatorFieldsReport.HasFields)
        AcpUI.Common.Utility.FieldsReportChanged((object) null, FieldReportType.Comparator);
    }
    UndoManager.StartUndoRedo();
  }

  private static void CompareRecsets(
    IAcpRecordset activeDocRecSet,
    IAcpRecordset compDocRecSet,
    bool swapped)
  {
    bool flag = false;
    for (int index = 0; index < activeDocRecSet.Count; ++index)
    {
      activeDocRecSet.CalculateVisibility(true);
      IAcpFeatureNode activeDocRec = activeDocRecSet[index];
      IAcpFeatureNode acpFeatureNode = (IAcpFeatureNode) null;
      if (activeDocRecSet.HasKeyField)
      {
        if (compDocRecSet.Count > 0)
          acpFeatureNode = compDocRecSet.NodeFromKey(activeDocRec.ReferenceKey);
        if (acpFeatureNode == null)
        {
          if (!swapped)
            AppInfoManager.ComparatorFieldsReport.RegisterFieldInReport((IAcpField) null, AcpResources.Cannot_Compare_Field_Does_Not_Exist_In_Comparison.AcpStringFormat((object) activeDocRec.Path("\\")), false);
          else
            AppInfoManager.ComparatorFieldsReport.RegisterFieldInReport((IAcpField) null, AcpResources.Cannot_Compare_Field_Does_Not_Exist_In_Active.AcpStringFormat((object) activeDocRec.Path("\\")), false);
        }
      }
      else if (index < compDocRecSet.Count)
        acpFeatureNode = compDocRecSet[index];
      else if (!swapped)
        AppInfoManager.ComparatorFieldsReport.RegisterFieldInReport((IAcpField) null, AcpResources.Cannot_Compare_Field_Does_Not_Exist_In_Comparison.AcpStringFormat((object) activeDocRec.Path("\\")), false);
      else
        AppInfoManager.ComparatorFieldsReport.RegisterFieldInReport((IAcpField) null, AcpResources.Cannot_Compare_Field_Does_Not_Exist_In_Active.AcpStringFormat((object) activeDocRec.Path("\\")), false);
      if (acpFeatureNode != null)
      {
        foreach (IAcpFeatureSection featureSections in activeDocRec.FeatureSectionsCollection)
        {
          IAcpFeatureSection acpFeatureSection = acpFeatureNode[featureSections.FeatureSectionId];
          if (acpFeatureSection == null)
          {
            if (featureSections.HasVisibleObjects)
            {
              if (!swapped)
                AppInfoManager.ComparatorFieldsReport.RegisterFieldInReport((IAcpField) null, AcpResources.Cannot_Compare_Field_Does_Not_Exist_In_Comparison.AcpStringFormat((object) featureSections.Path("\\")), false);
              else
                AppInfoManager.ComparatorFieldsReport.RegisterFieldInReport((IAcpField) null, AcpResources.Cannot_Compare_Field_Does_Not_Exist_In_Active.AcpStringFormat((object) featureSections.Path("\\")), false);
            }
          }
          else
          {
            if (featureSections.HasEmbeddedRecset)
            {
              IAcpRecordset embeddedRecset1 = featureSections.EmbeddedRecset;
              IAcpRecordset embeddedRecset2 = acpFeatureSection.EmbeddedRecset;
              if (embeddedRecset1 != null && embeddedRecset2 != null && !embeddedRecset1.HiddenStatic)
              {
                if (embeddedRecset1.RecsetId == embeddedRecset2.RecsetId)
                  ComparatorManager.CompareRecsets(embeddedRecset1, embeddedRecset2, swapped);
                else if (!swapped)
                  AppInfoManager.ComparatorFieldsReport.RegisterFieldInReport((IAcpField) null, AcpResources.Cannot_Compare_Field_Does_Not_Exist_In_Comparison.AcpStringFormat((object) featureSections.Path("\\")), false);
                else
                  AppInfoManager.ComparatorFieldsReport.RegisterFieldInReport((IAcpField) null, AcpResources.Cannot_Compare_Field_Does_Not_Exist_In_Active.AcpStringFormat((object) featureSections.Path("\\")), false);
              }
            }
            foreach (IAcpField fields in featureSections.FieldsCollection)
            {
              if (((AcpFieldBase) fields).AllowsCompare())
              {
                IAcpField field = acpFeatureSection[fields.UIName];
                if (field == null)
                {
                  if (!swapped)
                    AppInfoManager.ComparatorFieldsReport.RegisterFieldInReport((IAcpField) null, AcpResources.Cannot_Compare_Field_Does_Not_Exist_In_Comparison.AcpStringFormat((object) fields.Path("\\")), false);
                  else
                    AppInfoManager.ComparatorFieldsReport.RegisterFieldInReport((IAcpField) null, AcpResources.Cannot_Compare_Field_Does_Not_Exist_In_Active.AcpStringFormat((object) fields.Path("\\")), false);
                }
                else if (!swapped)
                {
                  if (fields.CompareTo((object) field) == 0)
                  {
                    if (AppInfoManager.ComparatorFieldsReport.ContainsField(fields))
                      AppInfoManager.ComparatorFieldsReport.UnregisterFieldInReport(fields);
                    fields._HasDiffs = false;
                  }
                  else
                  {
                    string fldValue = AcpCommonLib.Utility.FormatFieldValue(field);
                    if (!AppInfoManager.ComparatorFieldsReport.ContainsField(fields))
                    {
                      string message = AcpCommonLib.Utility.displayReverseForSpecialLanguageAndField(fields, fldValue);
                      AppInfoManager.ComparatorFieldsReport.RegisterFieldInReport(fields, message, false);
                    }
                    if (!fields._HasDiffs)
                      fields._HasDiffs = true;
                  }
                  flag = true;
                }
              }
            }
          }
        }
      }
    }
    if (!flag)
      return;
    AppInfoManager.ComparatorFieldsReport.FieldsReportChanged = true;
  }

  private static void CompareDocumentsSwapped(Document activeDoc, Document compDoc)
  {
    foreach (IAcpRecordset feature1 in activeDoc.Features)
    {
      IAcpRecordset feature2 = compDoc.GetFeature(feature1.RecsetId);
      if (feature2 != null)
        ComparatorManager.CompareRecsets(feature1, feature2, true);
    }
  }

  public static void CopyAllFields(IAcpPageFeature page)
  {
    ContainerTask task = new ContainerTask("Copy All");
    IAcpRecordset dataContext = (IAcpRecordset) ((FrameworkElement) page).DataContext;
    if (dataContext.Count == 0)
      return;
    IAcpRecordset feature = AppInfoManager.ComparatorDocument.GetFeature(dataContext.RecsetId);
    if (feature == null)
      return;
    int currentPosition = ((CollectionView) CollectionViewSource.GetDefaultView(((FrameworkElement) page).DataContext)).CurrentPosition;
    IAcpFeatureNode activeDocRecord = dataContext[currentPosition];
    IAcpFeatureNode compDocRecord = (IAcpFeatureNode) null;
    if (activeDocRecord.Parent.HasKeyField)
    {
      if (feature.Count > 0)
        compDocRecord = feature.NodeFromKey(activeDocRecord.ReferenceKey);
    }
    else if (currentPosition < feature.Count)
      compDocRecord = feature[currentPosition];
    if (compDocRecord != null)
    {
      activeDocRecord.CalculateVisibility(true);
      activeDocRecord.CalculateEditability(true);
      ComparatorManager.CopySections(activeDocRecord, compDocRecord, task);
    }
    if (task != null && task.Tasks.Count > 0)
    {
      UndoManager.AddTask((UndoableTask) task);
    }
    else
    {
      if (UndoManager.MarkForUndo)
        return;
      UndoManager.StartUndoRedo();
    }
  }

  private static void CopySections(
    IAcpFeatureNode activeDocRecord,
    IAcpFeatureNode compDocRecord,
    ContainerTask task)
  {
    foreach (IAcpFeatureSection acpFeatureSection1 in activeDocRecord.FeatureSectionsCollectionByOrder)
    {
      IAcpFeatureSection acpFeatureSection2 = compDocRecord[acpFeatureSection1.FeatureSectionId];
      if (acpFeatureSection2 != null)
      {
        foreach (IAcpField field in acpFeatureSection1.FieldsCollectionByOrder)
        {
          if (((AcpFieldBase) field).AllowsCopy())
          {
            IAcpField source = acpFeatureSection2[field.UIName];
            if (source != null)
            {
              task.AddTask(field.CopyValueOf(source));
              if (((AcpFieldBase) field).UnsupportedValue)
                AppInfoManager.ComparatorFieldsReport.RegisterFieldInReport(field, AcpResources.Value_Not_Copied_Unsupported_Value, false);
            }
          }
        }
        if (acpFeatureSection1.HasEmbeddedRecset)
        {
          IAcpRecordset embeddedRecset1 = acpFeatureSection1.EmbeddedRecset;
          IAcpRecordset embeddedRecset2 = acpFeatureSection2.EmbeddedRecset;
          if (embeddedRecset1 != null && embeddedRecset2 != null && !embeddedRecset1.HiddenStatic && embeddedRecset1.RecsetId == embeddedRecset2.RecsetId)
            ComparatorManager.CopyEmbeddedRecordset(embeddedRecset1, embeddedRecset2, task);
        }
      }
    }
  }

  private static void CopyEmbeddedRecordset(
    IAcpRecordset activeDocRecSet,
    IAcpRecordset compDocRecSet,
    ContainerTask task)
  {
    activeDocRecSet.CalculateVisibility(true);
    activeDocRecSet.CalculateEditability(true);
    for (int index = 0; index < activeDocRecSet.Count; ++index)
    {
      IAcpFeatureNode activeDocRec = activeDocRecSet[index];
      IAcpFeatureNode compDocRecord = (IAcpFeatureNode) null;
      if (activeDocRec.Parent.HasKeyField)
      {
        if (compDocRecSet.Count > 0)
          compDocRecord = compDocRecSet.NodeFromKey(activeDocRec.ReferenceKey);
      }
      else if (index < compDocRecSet.Count)
        compDocRecord = compDocRecSet[index];
      if (compDocRecord != null)
        ComparatorManager.CopySections(activeDocRec, compDocRecord, task);
    }
  }

  public static void RefreshTree(Page treeViewPage)
  {
    if (treeViewPage == null || treeViewPage.Content == null || !(treeViewPage.Content is TreeView))
      return;
    ItemCollection items = ((ItemsControl) treeViewPage.Content).Items;
    ComparatorManager.LoopThruTreeViewItems((AcpTreeViewItem) items[0]);
    foreach (IAcpField allField in AppInfoManager.ComparatorFieldsReport.AllFields)
    {
      int recsetId;
      int nodeId;
      if (allField.Parent.Parent.Parent.IsEmbeddedRecset)
      {
        recsetId = allField.Parent.Parent.Parent.ParentSection.Parent.Parent.RecsetId;
        nodeId = allField.Parent.Parent.Parent.ParentSection.Parent.Parent.SingleInstance || allField.Parent.Parent.Parent.ParentSection.Parent.Parent.HideRecordsFromTree ? 0 : allField.Parent.Parent.Parent.ParentSection.Parent.NodeId;
      }
      else
      {
        recsetId = allField.Parent.Parent.Parent.RecsetId;
        nodeId = allField.Parent.Parent.Parent.SingleInstance || allField.Parent.Parent.Parent.HideRecordsFromTree ? 0 : allField.Parent.Parent.NodeId;
      }
      AcpTreeViewItem childTreeViewItem = ((AcpTreeView) treeViewPage.Content).FindChildTreeViewItem(recsetId, nodeId, items);
      if (childTreeViewItem != null)
      {
        childTreeViewItem.ShowDiffIcon = true;
        AcpTreeViewItem acpTreeViewItem = childTreeViewItem;
        do
        {
          ((AcpTreeViewItem) acpTreeViewItem.Parent).ShowDiffIcon = true;
          acpTreeViewItem = (AcpTreeViewItem) acpTreeViewItem.Parent;
        }
        while (acpTreeViewItem.Parent is AcpTreeViewItem);
      }
    }
  }

  private static void LoopThruTreeViewItems(AcpTreeViewItem currentTvi)
  {
    if (currentTvi == null)
      return;
    currentTvi.ShowDiffIcon = false;
    int count = currentTvi.Items.Count;
    if (count <= 0)
      return;
    ItemCollection items = currentTvi.Items;
    items.MoveCurrentToFirst();
    for (int index = 0; index < count; ++index)
    {
      AcpTreeViewItem currentItem = (AcpTreeViewItem) items.CurrentItem;
      items.MoveCurrentToNext();
      ComparatorManager.LoopThruTreeViewItems(currentItem);
    }
  }
}
