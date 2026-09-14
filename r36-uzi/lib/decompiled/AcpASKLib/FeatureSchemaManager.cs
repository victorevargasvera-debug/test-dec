// Decompiled with JetBrains decompiler
// Type: AcpASKLib.FeatureSchemaManager
// Assembly: AcpASKLib, Version=23.1.0.5, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: D65BC533-E9D0-49A5-8218-5CB2B5C70E2D
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpASKLib.dll

using AcpASKLib.Properties;
using AcpCommonResources;
using AcpCryptoLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading;
using System.Windows;
using System.Xml;
using System.Xml.Serialization;

#nullable disable
namespace AcpASKLib;

public static class FeatureSchemaManager
{
  private static ArrayList featureCat = (ArrayList) null;
  private static Type[] extraTypes = new Type[9];
  private static Dictionary<AccessElementIDType, AccessElement> accessElementMap = (Dictionary<AccessElementIDType, AccessElement>) null;

  static FeatureSchemaManager()
  {
    FeatureSchemaManager.extraTypes[0] = typeof (FeatureCategory);
    FeatureSchemaManager.extraTypes[1] = typeof (AccessNode);
    FeatureSchemaManager.extraTypes[2] = typeof (AccessSection);
    FeatureSchemaManager.extraTypes[3] = typeof (AccessField);
    FeatureSchemaManager.extraTypes[4] = typeof (AccessOperation);
    FeatureSchemaManager.extraTypes[5] = typeof (Collection<AccessNode>);
    FeatureSchemaManager.extraTypes[6] = typeof (Collection<AccessSection>);
    FeatureSchemaManager.extraTypes[7] = typeof (Collection<AccessField>);
    FeatureSchemaManager.extraTypes[8] = typeof (Collection<AccessOperation>);
    FeatureSchemaManager.Initialize();
  }

  internal static void Initialize()
  {
    if (FeatureSchemaManager.featureCat != null)
      return;
    FeatureSchemaManager.Deserialize();
  }

  private static void Deserialize()
  {
    MessageBoxOptions options = MessageBoxOptions.None;
    try
    {
      options = !Thread.CurrentThread.CurrentUICulture.TextInfo.IsRightToLeft ? MessageBoxOptions.None : MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading;
    }
    catch
    {
    }
    try
    {
      XmlNodeReader xmlNodeReader = new XmlNodeReader((XmlNode) new AcpXMLEncryptDecrypt().DecryptXMLFile((Stream) new MemoryStream(Resources.askalm2p)).DocumentElement);
      FeatureSchemaManager.featureCat = (ArrayList) new XmlSerializer(typeof (ArrayList), FeatureSchemaManager.extraTypes).Deserialize((XmlReader) xmlNodeReader);
      FeatureSchemaManager.CreateElementMap();
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show(AcpResources.Critical_File_Missing, AcpResources.Warning_Id, MessageBoxButton.OK, MessageBoxImage.Hand, MessageBoxResult.OK, options);
      Environment.Exit(3073);
    }
  }

  public static ArrayList FeatureCategories
  {
    get => FeatureSchemaManager.featureCat;
    set => FeatureSchemaManager.featureCat = value;
  }

  internal static AccessElement GetAccessElement(AccessElementIDType id)
  {
    AccessElement accessElement = (AccessElement) null;
    if (FeatureSchemaManager.accessElementMap.ContainsKey(id))
      accessElement = FeatureSchemaManager.accessElementMap[id];
    return accessElement;
  }

  private static void CreateElementMap()
  {
    FeatureSchemaManager.accessElementMap = new Dictionary<AccessElementIDType, AccessElement>();
    foreach (FeatureCategory featureCategory in FeatureSchemaManager.FeatureCategories)
    {
      if (featureCategory.RadioType == FeatureCategoryRadioType.APXRadios)
      {
        foreach (AccessNode feature in featureCategory.Features)
        {
          foreach (AccessSection section in feature.Sections)
          {
            foreach (AccessElement accessElement in section.Items)
              FeatureSchemaManager.accessElementMap.Add(accessElement.ElemID, accessElement);
          }
        }
        foreach (AccessNode function in featureCategory.Functions)
        {
          foreach (AccessSection section in function.Sections)
          {
            foreach (AccessElement accessElement in section.Items)
              FeatureSchemaManager.accessElementMap.Add(accessElement.ElemID, accessElement);
          }
        }
      }
    }
  }
}
