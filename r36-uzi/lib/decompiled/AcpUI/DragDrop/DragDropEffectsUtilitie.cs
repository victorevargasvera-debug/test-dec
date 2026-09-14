// Decompiled with JetBrains decompiler
// Type: AcpUI.DragDrop.DragDropEffectsUtilitie
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

using AcpBusinessLayer;
using AcpCommonLib;
using System;
using System.Collections.Generic;
using System.Linq;

#nullable disable
namespace AcpUI.DragDrop;

public static class DragDropEffectsUtilitie
{
  private const int zoneFeatureSectionId = 10116;
  private const string zoneChannelAssignmentRecsetId = "2051";
  private const string cloneEnableFieldId = "ZnChanCfgZoneZoneCloningEnable_43119";
  private const string zoneNameFieldId = "ZnChanCfgZoneZoneName_A9724";
  private const string producerNodeRecsetID = "ProducerNodeRecsetID";
  private const string referenceKey = "ProducerNodeReferenceKey";

  private static bool IsZoneWithSameNamePresentInRecordSet(
    IEnumerable<IAcpFeatureNode> recordSet,
    string zoneName)
  {
    return recordSet.Any<IAcpFeatureNode>((Func<IAcpFeatureNode, bool>) (x =>
    {
      IAcpField acpField2;
      if (x == null)
      {
        acpField2 = (IAcpField) null;
      }
      else
      {
        IEnumerable<IAcpFeatureSection> sectionsCollection = x.FeatureSectionsCollection;
        if (sectionsCollection == null)
        {
          acpField2 = (IAcpField) null;
        }
        else
        {
          List<IAcpFeatureSection> list1 = sectionsCollection.ToList<IAcpFeatureSection>();
          if (list1 == null)
          {
            acpField2 = (IAcpField) null;
          }
          else
          {
            IAcpFeatureSection acpFeatureSection = list1.First<IAcpFeatureSection>((Func<IAcpFeatureSection, bool>) (y => y != null && y.FeatureSectionId == 10116));
            if (acpFeatureSection == null)
            {
              acpField2 = (IAcpField) null;
            }
            else
            {
              IEnumerable<IAcpField> fieldsCollection = acpFeatureSection.FieldsCollection;
              if (fieldsCollection == null)
              {
                acpField2 = (IAcpField) null;
              }
              else
              {
                List<IAcpField> list2 = fieldsCollection.ToList<IAcpField>();
                acpField2 = list2 != null ? list2.First<IAcpField>((Func<IAcpField, bool>) (z => z?.Name == "ZnChanCfgZoneZoneName_A9724")) : (IAcpField) null;
              }
            }
          }
        }
      }
      return (acpField2 is AcpField<string> acpField3 ? acpField3.Value : (string) null) == zoneName;
    }));
  }

  private static bool GetCloneEnableFlag(IAcpFeatureNode node)
  {
    IEnumerable<IAcpFeatureSection> sectionsCollection = node.FeatureSectionsCollection;
    IAcpField acpField1;
    if (sectionsCollection == null)
    {
      acpField1 = (IAcpField) null;
    }
    else
    {
      IAcpFeatureSection acpFeatureSection = sectionsCollection.First<IAcpFeatureSection>((Func<IAcpFeatureSection, bool>) (x => x != null && x.FeatureSectionId == 10116));
      if (acpFeatureSection == null)
      {
        acpField1 = (IAcpField) null;
      }
      else
      {
        IEnumerable<IAcpField> fieldsCollection = acpFeatureSection.FieldsCollection;
        if (fieldsCollection == null)
        {
          acpField1 = (IAcpField) null;
        }
        else
        {
          List<IAcpField> list = fieldsCollection.ToList<IAcpField>();
          acpField1 = list != null ? list.First<IAcpField>((Func<IAcpField, bool>) (x => x?.Name == "ZnChanCfgZoneZoneCloningEnable_43119")) : (IAcpField) null;
        }
      }
    }
    return acpField1 is AcpField<bool> acpField2 && acpField2.Value;
  }

  private static IAcpFeatureNode GetZoneFromRecordSet(
    IEnumerable<IAcpFeatureNode> recordSet,
    string zoneName)
  {
    return recordSet.First<IAcpFeatureNode>((Func<IAcpFeatureNode, bool>) (x =>
    {
      IAcpFeatureSection acpFeatureSection = x.FeatureSectionsCollection.ToList<IAcpFeatureSection>().First<IAcpFeatureSection>((Func<IAcpFeatureSection, bool>) (y => y != null && y.FeatureSectionId == 10116));
      IAcpField acpField;
      if (acpFeatureSection == null)
      {
        acpField = (IAcpField) null;
      }
      else
      {
        IEnumerable<IAcpField> fieldsCollection = acpFeatureSection.FieldsCollection;
        if (fieldsCollection == null)
        {
          acpField = (IAcpField) null;
        }
        else
        {
          List<IAcpField> list = fieldsCollection.ToList<IAcpField>();
          acpField = list != null ? list.First<IAcpField>((Func<IAcpField, bool>) (z => z?.Name == "ZnChanCfgZoneZoneName_A9724")) : (IAcpField) null;
        }
      }
      return (acpField as AcpField<string>).Value == zoneName;
    }));
  }

  private static bool IsCloneEnableFlagSetInZone(
    IEnumerable<IAcpFeatureNode> recordSet,
    string zoneName)
  {
    IAcpFeatureNode zoneFromRecordSet = DragDropEffectsUtilitie.GetZoneFromRecordSet(recordSet, zoneName);
    return zoneFromRecordSet != null && DragDropEffectsUtilitie.GetCloneEnableFlag(zoneFromRecordSet);
  }

  private static string GetDraggableZoneName(Dictionary<string, object> producerTreeData)
  {
    if (producerTreeData == null || !(producerTreeData["ProducerNodeRecsetID"]?.ToString() == "2051") || !(producerTreeData["ProducerNodeReferenceKey"] is string))
      return (string) null;
    string str = producerTreeData["ProducerNodeReferenceKey"] as string;
    return str.Substring(str.IndexOf('-') + 1);
  }

  private static bool IsAnyZoneCloneEnableFlagSet(IEnumerable<IAcpFeatureNode> recordSet)
  {
    return recordSet.Any<IAcpFeatureNode>((Func<IAcpFeatureNode, bool>) (y =>
    {
      IAcpField acpField;
      if (y == null)
      {
        acpField = (IAcpField) null;
      }
      else
      {
        IEnumerable<IAcpFeatureSection> sectionsCollection = y.FeatureSectionsCollection;
        if (sectionsCollection == null)
        {
          acpField = (IAcpField) null;
        }
        else
        {
          IAcpFeatureSection acpFeatureSection = sectionsCollection.First<IAcpFeatureSection>((Func<IAcpFeatureSection, bool>) (x => x != null && x.FeatureSectionId == 10116));
          if (acpFeatureSection == null)
          {
            acpField = (IAcpField) null;
          }
          else
          {
            IEnumerable<IAcpField> fieldsCollection = acpFeatureSection.FieldsCollection;
            if (fieldsCollection == null)
            {
              acpField = (IAcpField) null;
            }
            else
            {
              List<IAcpField> list = fieldsCollection.ToList<IAcpField>();
              acpField = list != null ? list.First<IAcpField>((Func<IAcpField, bool>) (x => x?.Name == "ZnChanCfgZoneZoneCloningEnable_43119")) : (IAcpField) null;
            }
          }
        }
      }
      return (bool) (acpField as AcpField<bool>);
    }));
  }

  private static bool IsDraggableZoneCloneEnableFlagSet(
    IEnumerable<IAcpFeatureNode> recordSet,
    string zoneName)
  {
    return DragDropEffectsUtilitie.IsZoneWithSameNamePresentInRecordSet(recordSet, zoneName) && DragDropEffectsUtilitie.IsCloneEnableFlagSetInZone(recordSet, zoneName);
  }

  public static bool IsZoneChannelAssignmentRecsetDragDropDisable(
    IAcpRecordset recordSet,
    Dictionary<string, object> producerTreeData)
  {
    if (recordSet.Count <= 0)
      return false;
    try
    {
      string draggableZoneName = DragDropEffectsUtilitie.GetDraggableZoneName(producerTreeData);
      return draggableZoneName != null ? DragDropEffectsUtilitie.IsDraggableZoneCloneEnableFlagSet(recordSet as IEnumerable<IAcpFeatureNode>, draggableZoneName) : DragDropEffectsUtilitie.IsAnyZoneCloneEnableFlagSet(recordSet as IEnumerable<IAcpFeatureNode>);
    }
    catch (NullReferenceException ex)
    {
      return false;
    }
  }

  public static bool IsZoneDragDropDisble(IAcpFeatureNode section)
  {
    return DragDropEffectsUtilitie.GetCloneEnableFlag(section);
  }
}
