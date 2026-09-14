// Decompiled with JetBrains decompiler
// Type: AcpUI.ImportExport.ImportExportManager
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

using AcpBusinessLayer;
using AcpBusinessLayer.UndoRedo;
using AcpCommonLib;
using AcpCommonLib.UndoRedo;
using AcpCommonResources;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;
using System.Xml.XPath;

#nullable disable
namespace AcpUI.ImportExport;

public static class ImportExportManager
{
  private static IAcpBatchOperation Process;
  private static ImportExportItem urlRecSet;
  private static string dataWideRecSetName = FeatureManager.GetFeature(2028)?.UIName;
  private static string urlRecSetName = FeatureManager.GetFeature(4237)?.UIName;

  public static void SetImportProcess(IAcpBatchOperation process)
  {
    ImportExportManager.Process = process;
  }

  public static List<ImportExportItem> GetListOfRecsets(XmlDocument document)
  {
    XmlNode lastChild = document.ChildNodes[1].LastChild;
    List<ImportExportItem> listOfRecsets = new List<ImportExportItem>();
    foreach (XmlNode childNode in lastChild.ChildNodes)
    {
      try
      {
        IAcpRecordset feature = FeatureManager.GetFeature(Convert.ToInt32(childNode.Attributes["Id"].Value));
        if (feature != null)
        {
          if (!feature.HiddenStatic)
          {
            if (feature.UIName == ImportExportManager.urlRecSetName)
              ImportExportManager.urlRecSet = new ImportExportItem(childNode.Attributes["Name"].Value, feature.DataTransferOrder);
            else
              listOfRecsets.Add(new ImportExportItem(childNode.Attributes["Name"].Value, feature.DataTransferOrder));
          }
        }
      }
      catch (FormatException ex)
      {
      }
    }
    listOfRecsets.Sort((Comparison<ImportExportItem>) ((p1, p2) => p1.RecsetName.CompareTo(p2.RecsetName)));
    return listOfRecsets;
  }

  public static List<ImportExportItem> GetListOfRecsets()
  {
    List<ImportExportItem> listOfRecsets = new List<ImportExportItem>();
    foreach (IAcpRecordset feature in FeatureManager.Features)
    {
      if (!feature.HiddenStatic)
      {
        if (feature.UIName == ImportExportManager.urlRecSetName)
          ImportExportManager.urlRecSet = new ImportExportItem(feature.UIName, feature.DataTransferOrder);
        else
          listOfRecsets.Add(new ImportExportItem(feature.UIName, feature.DataTransferOrder));
      }
    }
    listOfRecsets.Sort((Comparison<ImportExportItem>) ((p1, p2) => p1.RecsetName.CompareTo(p2.RecsetName)));
    return listOfRecsets;
  }

  public static bool ImportFromXmlDoc(
    XmlDocument document,
    IList listOfRecsetNames,
    XmlFileType fileType,
    bool importCopyOper)
  {
    ContainerTask containerTask = new ContainerTask(AcpResources.XML_Import);
    ModifyAppInfoStateTask task1 = new ModifyAppInfoStateTask(new Dictionary<string, bool>()
    {
      {
        "ImportOperationCompleted",
        false
      },
      {
        "ImportCopyOperation",
        true
      }
    });
    containerTask.AddTask((UndoableTask) task1);
    IList list = (IList) new List<object>();
    list.Add((object) listOfRecsetNames);
    list.Add((object) document);
    ImportExportManager.Process.Data = (object) list;
    ImportExportManager.Process.PreProcess(containerTask);
    bool flag1 = true;
    List<ImportExportItem> importExportItemList = new List<ImportExportItem>();
    Dictionary<IAcpField, string> RecRefsToRepair = new Dictionary<IAcpField, string>();
    Dictionary<IAcpField, string> RecRefFieldsOfEmbedRecset = new Dictionary<IAcpField, string>();
    for (int index = 0; index < listOfRecsetNames.Count; ++index)
    {
      importExportItemList.Add((ImportExportItem) listOfRecsetNames[index]);
      if (((ImportExportItem) listOfRecsetNames[index]).recsetName == ImportExportManager.dataWideRecSetName && ImportExportManager.urlRecSet != null)
      {
        importExportItemList.Add(ImportExportManager.urlRecSet);
        ImportExportManager.urlRecSet = (ImportExportItem) null;
      }
    }
    importExportItemList.Sort((Comparison<ImportExportItem>) ((p1, p2) => p1.RecsetDataTransferOrder.CompareTo(p2.RecsetDataTransferOrder)));
    XmlNode lastChild = document.ChildNodes[1].LastChild;
    RecRefsToRepair.Clear();
    for (int index = 0; index < importExportItemList.Count; ++index)
    {
      string recsetName = importExportItemList[index].RecsetName;
      foreach (XmlNode childNode in lastChild.ChildNodes)
      {
        if (string.Equals(childNode.Attributes["Name"].Value, recsetName, StringComparison.CurrentCulture))
        {
          XmlAttribute attribute = childNode.Attributes["Id"];
          if (attribute != null)
          {
            int id;
            try
            {
              id = int.Parse(attribute.Value, (IFormatProvider) CultureInfo.InvariantCulture);
            }
            catch (ArgumentNullException ex)
            {
              flag1 = false;
              break;
            }
            catch (FormatException ex)
            {
              flag1 = false;
              break;
            }
            catch (OverflowException ex)
            {
              flag1 = false;
              break;
            }
            IAcpRecordset feature = FeatureManager.GetFeature(id);
            if (feature != null)
            {
              feature.CalculateVisibility(true);
              feature.CalculateEditability(true);
              if (!feature.HiddenStatic)
              {
                feature.ReadFromXml(childNode, containerTask, fileType, importCopyOper, RecRefsToRepair, RecRefFieldsOfEmbedRecset);
                break;
              }
              break;
            }
            Utility.LogMissingXmlNode((IXPathNavigable) childNode);
            break;
          }
          break;
        }
      }
    }
    foreach (KeyValuePair<IAcpField, string> keyValuePair in RecRefsToRepair)
    {
      AcpRecRefField key = keyValuePair.Key as AcpRecRefField;
      containerTask.AddTask((UndoableTask) new ModifyRecRefDataTask(key, keyValuePair.Value));
      if (key.ValueSetter != null)
        key.ValueSetter(key.Parent, containerTask);
    }
    foreach (KeyValuePair<IAcpField, string> keyValuePair in RecRefFieldsOfEmbedRecset)
    {
      AcpRecRefField key = keyValuePair.Key as AcpRecRefField;
      if (!key.HiddenStatic)
      {
        containerTask.AddTask((UndoableTask) new ModifyRecRefDataTask(key, keyValuePair.Value));
        if (key.ValueSetter != null)
          key.ValueSetter(key.Parent, containerTask);
      }
      else
        key.ResetToDefaultWithUndo(containerTask);
    }
    AppInfoManager.DndAndImportTask = containerTask;
    Dictionary<string, bool> newStates = new Dictionary<string, bool>();
    newStates.Add("ImportOperationCompleted", true);
    newStates.Add("ImportCopyOperation", false);
    ImportExportManager.Process.PostProcess(containerTask);
    ModifyAppInfoStateTask task2 = new ModifyAppInfoStateTask(newStates);
    containerTask.AddTask((UndoableTask) task2);
    UndoManager.AddTask((UndoableTask) containerTask);
    RecRefsToRepair.Clear();
    RecRefFieldsOfEmbedRecset.Clear();
    AppInfoManager.DndAndImportSection.Clear();
    AppInfoManager.DndAndImportTask = (ContainerTask) null;
    bool flag2 = UndoManager.StopUndoRedo();
    foreach (Recordset feature in FeatureManager.Features)
    {
      foreach (AcpRecRefField recRefField in feature.RecRefFields)
        recRefField.CleanupDuplicates();
    }
    if (flag2)
      UndoManager.StartUndoRedo();
    return flag1;
  }

  public static XmlDocument ExportToXmlDoc(IList listOfRecsetNames, bool exportAll)
  {
    XmlDocument xmlDoc = new XmlDocument();
    xmlDoc.AppendChild((XmlNode) xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", (string) null));
    XmlElement element1 = xmlDoc.CreateElement("import_export_doc");
    xmlDoc.AppendChild((XmlNode) element1);
    XmlElement element2 = xmlDoc.CreateElement("Version");
    element2.InnerText = "2";
    element1.AppendChild((XmlNode) element2);
    XmlElement element3 = xmlDoc.CreateElement("Language");
    element3.InnerText = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
    element1.AppendChild((XmlNode) element3);
    XmlElement element4 = xmlDoc.CreateElement("Root");
    element4.SetAttribute("ExportedAllFeatures", exportAll.ToString());
    element4.SetAttribute("ConverterGenerated", "False");
    element1.AppendChild((XmlNode) element4);
    for (int index = 0; index < listOfRecsetNames.Count; ++index)
    {
      ImportExportItem listOfRecsetName = (ImportExportItem) listOfRecsetNames[index];
      ImportExportManager.CheckAndAddItemsToXML(listOfRecsetName, element4);
      if (listOfRecsetName.recsetName == ImportExportManager.dataWideRecSetName && ImportExportManager.urlRecSet != null)
      {
        ImportExportManager.CheckAndAddItemsToXML(ImportExportManager.urlRecSet, element4);
        ImportExportManager.urlRecSet = (ImportExportItem) null;
      }
    }
    return xmlDoc;
  }

  private static void CheckAndAddItemsToXML(ImportExportItem impExpItem, XmlElement root)
  {
    string recsetName = impExpItem.RecsetName;
    foreach (IAcpRecordset feature in FeatureManager.Features)
    {
      if (string.Equals(feature.UIName, recsetName, StringComparison.CurrentCulture))
      {
        feature.CalculateVisibility(true);
        if (feature.HiddenStatic || !feature.HasVisibleObjects && feature.Count != 0)
          break;
        feature.AddToXml((XmlNode) root, XmlFileType.ImpExp);
        break;
      }
    }
  }
}
