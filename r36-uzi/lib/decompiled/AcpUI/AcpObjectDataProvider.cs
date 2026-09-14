// Decompiled with JetBrains decompiler
// Type: AcpUI.AcpObjectDataProvider
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

using AcpBusinessLayer;
using AcpCommonLib;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;

#nullable disable
namespace AcpUI;

public static class AcpObjectDataProvider
{
  public static Recordset GetRecordset(int parentRecsetID)
  {
    return (bool) DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof (DependencyObject)).DefaultValue ? (Recordset) null : (AppInfoManager.AppMode != ApplicationMode.CustomViewConfigurationMode ? (Recordset) FeatureManager.GetFeature(parentRecsetID) : (Recordset) AppInfoManager.DefaultDocument.GetFeature(parentRecsetID));
  }

  public static Recordset GetRecordset(int parentRecsetID, int parentSectionID)
  {
    if ((bool) DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof (DependencyObject)).DefaultValue)
      return (Recordset) null;
    IAcpFeatureSection acpFeatureSection = ((IAcpFeatureNode) ((CollectionView) CollectionViewSource.GetDefaultView((object) ((AppInfoManager.AppMode != ApplicationMode.CustomViewConfigurationMode ? AcpObjectDataProvider.GetRecordset(parentRecsetID) : AcpObjectDataProvider.GetRecordset(parentRecsetID)) ?? throw new ArgumentException(nameof (parentRecsetID), $"A Recordset instance with ID {parentRecsetID} does not exist")))).CurrentItem)[parentSectionID];
    if (acpFeatureSection == null)
      throw new ArgumentException(nameof (parentSectionID), $"Recordset instance with ID {parentRecsetID} does not contain a FeatureSection with ID {parentSectionID}");
    return acpFeatureSection.EmbeddedRecset != null ? (Recordset) acpFeatureSection.EmbeddedRecset : throw new InvalidOperationException($"FeatureSection with ID {parentSectionID} does not contain an embedded Recordset instance");
  }

  public static Recordset GetRecordset(
    int parentRecsetID,
    int parentNodeIndex,
    int parentSectionID)
  {
    if ((bool) DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof (DependencyObject)).DefaultValue)
      return (Recordset) null;
    Recordset recordset = AppInfoManager.AppMode != ApplicationMode.CustomViewConfigurationMode ? AcpObjectDataProvider.GetRecordset(parentRecsetID) : AcpObjectDataProvider.GetRecordset(parentRecsetID);
    if (recordset == null)
      throw new ArgumentException(nameof (parentRecsetID), $"A Recordset instance with ID {parentRecsetID} does not exist");
    if (parentNodeIndex < 0 || parentNodeIndex >= recordset.Count)
      throw new ArgumentOutOfRangeException(nameof (parentNodeIndex));
    IAcpFeatureSection acpFeatureSection = recordset[parentNodeIndex][parentSectionID];
    if (acpFeatureSection == null)
      throw new ArgumentException(nameof (parentSectionID), $"Recordset instance with ID {parentRecsetID} does not contain a FeatureSection with ID {parentSectionID}");
    return acpFeatureSection.EmbeddedRecset != null ? (Recordset) acpFeatureSection.EmbeddedRecset : throw new InvalidOperationException($"FeatureSection with ID {parentSectionID} does not contain an embedded Recordset instance");
  }

  public static FeatureNode GetNode(int parentRecsetID, int parentNodeIndex)
  {
    if ((bool) DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof (DependencyObject)).DefaultValue)
      return (FeatureNode) null;
    Recordset recordset = AcpObjectDataProvider.GetRecordset(parentRecsetID);
    if (parentNodeIndex < 0 || parentNodeIndex > recordset.Count - 1)
      throw new ArgumentOutOfRangeException(nameof (parentNodeIndex));
    return (FeatureNode) recordset[parentNodeIndex];
  }

  public static FeatureNode GetNode(
    int parentRecsetID,
    int parentNodeIndex,
    int parentSectionID,
    int childNodeIndex,
    bool canBeEmpty)
  {
    if ((bool) DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof (DependencyObject)).DefaultValue)
      return (FeatureNode) null;
    FeatureSection featureSection = (FeatureSection) AcpObjectDataProvider.GetNode(parentRecsetID, parentNodeIndex)[parentSectionID];
    Recordset recordset = featureSection.EmbeddedRecset != null ? (Recordset) featureSection.EmbeddedRecset : throw new ArithmeticException(nameof (parentSectionID));
    FeatureNode defaultRecord;
    if (recordset.Count > 0)
    {
      if (childNodeIndex < 0 || childNodeIndex > recordset.Count - 1)
        throw new ArgumentOutOfRangeException(nameof (childNodeIndex));
      defaultRecord = (FeatureNode) recordset[childNodeIndex];
    }
    else
    {
      if (!canBeEmpty)
        throw new ArgumentException(nameof (canBeEmpty));
      defaultRecord = recordset.CreateDefaultRecord();
    }
    return defaultRecord;
  }

  public static Recordset GetComparatorRecordset(int parentRecsetID)
  {
    if ((bool) DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof (DependencyObject)).DefaultValue)
      return (Recordset) null;
    return AppInfoManager.AppMode != ApplicationMode.CodeplugComparisonMode ? (Recordset) null : (Recordset) AppInfoManager.ComparatorDocument.GetFeature(parentRecsetID);
  }
}
