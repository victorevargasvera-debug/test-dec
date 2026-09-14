// Decompiled with JetBrains decompiler
// Type: AcpASKLib.SecurityDocument
// Assembly: AcpASKLib, Version=23.1.0.5, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: D65BC533-E9D0-49A5-8218-5CB2B5C70E2D
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpASKLib.dll

using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Xml;

#nullable disable
namespace AcpASKLib;

public static class SecurityDocument
{
  public static bool bAccessLevelFileOpened;

  public static bool FileOpenAccessLevel(string path)
  {
    bool flag = true;
    if (!SecurityDocument.bAccessLevelFileOpened)
    {
      try
      {
        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.Load(path);
        SecurityDocument.bAccessLevelFileOpened = true;
        for (XmlNode node = xmlDocument.DocumentElement.FirstChild; node != null; node = node.NextSibling)
        {
          string name = node.Name;
          string innerText = node.InnerText;
          if ("Record" == name)
          {
            try
            {
              AccessRecord newRec = new AccessRecord(node);
              if (newRec.RecordType == FeatureCategoryType.RADIOWIDE)
                Global.m_persistentData.RadioWideACLRecSet.AddNewRecord(newRec);
              else if (newRec.RecordType == FeatureCategoryType.TRUNKING)
                Global.m_persistentData.SystemWideACLRecSet.AddNewRecord(newRec);
            }
            catch
            {
              flag = false;
            }
          }
        }
      }
      catch (Exception ex)
      {
        if (ex is FileNotFoundException)
          SecurityDocument.bAccessLevelFileOpened = true;
        throw;
      }
    }
    return flag;
  }

  public static bool FileSaveAccessLevel(string path)
  {
    string str1 = "<?xml version=\"1.0\"?>\n<AccessListFile>\n";
    foreach (AccessRecord systemWideAclRec in (Collection<AccessRecord>) Global.m_persistentData.SystemWideACLRecSet)
    {
      string str2 = string.Empty;
      if (systemWideAclRec.Name.Contains("&") || systemWideAclRec.Name.Contains("<"))
      {
        str2 = systemWideAclRec.Name;
        if (systemWideAclRec.Name.Contains("&"))
          systemWideAclRec.Name = systemWideAclRec.Name.Replace("&", "&amp;");
        if (systemWideAclRec.Name.Contains("<"))
          systemWideAclRec.Name = systemWideAclRec.Name.Replace("<", "&lt;");
      }
      if (systemWideAclRec.PrimaryKey != 4 && systemWideAclRec.PrimaryKey != 5)
        str1 += systemWideAclRec.ToXMLString();
      if (str2 != string.Empty)
        systemWideAclRec.Name = str2;
    }
    string xml = str1 + "</AccessListFile>";
    XmlDocument xmlDocument = new XmlDocument();
    xmlDocument.LoadXml(xml);
    xmlDocument.Save(path);
    return true;
  }
}
