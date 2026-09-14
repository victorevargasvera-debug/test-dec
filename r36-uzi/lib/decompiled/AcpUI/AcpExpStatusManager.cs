// Decompiled with JetBrains decompiler
// Type: AcpUI.AcpExpStatusManager
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

using AcpBusinessLayer;
using AcpCommonLib;
using System.Collections.Generic;
using System.Windows.Data;

#nullable disable
namespace AcpUI;

public static class AcpExpStatusManager
{
  private static Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();

  public static void Add(int nodeId, AcpExpander expander)
  {
    List<int> intList;
    if (!AcpExpStatusManager.map.TryGetValue(nodeId, out intList))
      intList = new List<int>();
    FeatureSection section = AcpExpStatusManager.GetSection(AcpExpStatusManager.GetNode(expander), expander.Header as string);
    if (section == null || intList.Contains(section.FeatureSectionId))
      return;
    if (intList.Count == 0)
      AcpExpStatusManager.map.Add(nodeId, intList);
    intList.Add(section.FeatureSectionId);
  }

  public static void Remove(int nodeId) => AcpExpStatusManager.map.Remove(nodeId);

  public static void Remove(int nodeId, AcpExpander expander)
  {
    List<int> intList;
    if (!AcpExpStatusManager.map.TryGetValue(nodeId, out intList))
      return;
    FeatureSection section = AcpExpStatusManager.GetSection(AcpExpStatusManager.GetNode(expander), expander.Header as string);
    if (section != null)
      intList.Remove(section.FeatureSectionId);
    if (intList.Count != 0)
      return;
    AcpExpStatusManager.Remove(nodeId);
  }

  public static void Clear() => AcpExpStatusManager.map.Clear();

  public static bool Contains(int nodeId, AcpExpander expander)
  {
    List<int> intList;
    if (AcpExpStatusManager.map.TryGetValue(nodeId, out intList))
    {
      FeatureSection section = AcpExpStatusManager.GetSection(AcpExpStatusManager.GetNode(expander), expander.Header as string);
      if (section != null)
        return intList.Contains(section.FeatureSectionId);
    }
    return false;
  }

  private static FeatureNode GetNode(AcpExpander expander)
  {
    return (FeatureNode) ((CollectionView) CollectionViewSource.GetDefaultView((object) (IAcpRecordset) expander.DataContext)).CurrentItem;
  }

  private static FeatureSection GetSection(FeatureNode node, string sectionUIName)
  {
    foreach (FeatureSection featureSections in node.FeatureSectionsCollection)
    {
      if (featureSections.UIName == sectionUIName)
        return featureSections;
    }
    return (FeatureSection) null;
  }
}
