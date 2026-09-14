// Decompiled with JetBrains decompiler
// Type: AcpUI.Mru.MruFiles
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

using System;
using System.IO;
using System.IO.IsolatedStorage;
using System.Threading;
using System.Xml;

#nullable disable
namespace AcpUI.Mru;

public class MruFiles
{
  private const string ISOLATED_FILE_NAME = "APX7000_7500CpsMru.xml";
  private const int MAX_NAME_LEN = 40;
  private const int MAX_MRU_COUNT = 4;
  private static XmlDocument xmlDoc = new XmlDocument();
  private static IsolatedStorageFile isoStore = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, (Type) null, (Type) null);

  static MruFiles()
  {
    bool flag = false;
    foreach (string fileName in MruFiles.isoStore.GetFileNames("APX7000_7500CpsMru.xml"))
    {
      if (fileName == "APX7000_7500CpsMru.xml")
        flag = true;
    }
    if (!flag)
      MruFiles.CreateMRUFile(MruFiles.isoStore);
    MruFiles.LoadMRUHelper();
  }

  private static void LoadMRUHelper()
  {
    try
    {
      IsolatedStorageFileStream storageFileStream = new IsolatedStorageFileStream("APX7000_7500CpsMru.xml", FileMode.Open, MruFiles.isoStore);
      StreamReader txtReader = new StreamReader((Stream) storageFileStream);
      try
      {
        MruFiles.xmlDoc.Load((TextReader) txtReader);
      }
      catch (XmlException ex)
      {
        txtReader.Close();
        MruFiles.isoStore.DeleteFile("APX7000_7500CpsMru.xml");
        MruFiles.CreateMRUFile(MruFiles.isoStore);
        storageFileStream = new IsolatedStorageFileStream("APX7000_7500CpsMru.xml", FileMode.Open, MruFiles.isoStore);
        txtReader = new StreamReader((Stream) storageFileStream);
        MruFiles.xmlDoc.Load((TextReader) txtReader);
      }
      txtReader.Close();
      storageFileStream.Close();
      storageFileStream.Dispose();
    }
    catch (IOException ex)
    {
      Thread.Sleep(500);
      MruFiles.LoadMRUHelper();
    }
  }

  public static XmlDocument MRUDoc
  {
    get => MruFiles.xmlDoc;
    set => MruFiles.xmlDoc = value;
  }

  private static void CreateMRUFile(IsolatedStorageFile isoStore)
  {
    StreamWriter streamWriter = new StreamWriter((Stream) new IsolatedStorageFileStream("APX7000_7500CpsMru.xml", FileMode.Create, isoStore));
    streamWriter.WriteLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
    streamWriter.WriteLine("<data xmlns=''>");
    streamWriter.WriteLine("</data>");
    streamWriter.Close();
  }

  public static void UpdateMRU(string pathName)
  {
    XmlNode documentElement = (XmlNode) MruFiles.xmlDoc.DocumentElement;
    if (documentElement == null)
      return;
    XmlElement element = MruFiles.xmlDoc.CreateElement("item");
    element.SetAttribute("Path", pathName);
    element.SetAttribute("Name", MruFiles.GetNameFromPath(pathName));
    foreach (XmlNode childNode in documentElement.ChildNodes)
    {
      if (childNode.Attributes["Path"].Value == pathName)
        documentElement.RemoveChild(childNode);
    }
    if (documentElement.ChildNodes.Count > 0)
    {
      documentElement.InsertBefore((XmlNode) element, documentElement.FirstChild);
      while (documentElement.ChildNodes.Count > 4)
        documentElement.RemoveChild(documentElement.LastChild);
    }
    else if (documentElement.ChildNodes.Count == 0)
      documentElement.AppendChild((XmlNode) element);
    int num = 1;
    foreach (XmlElement childNode in documentElement.ChildNodes)
    {
      childNode.SetAttribute("Index", num.ToString());
      ++num;
    }
    TextWriter writer = (TextWriter) new StreamWriter((Stream) new IsolatedStorageFileStream("APX7000_7500CpsMru.xml", FileMode.Create, MruFiles.isoStore));
    MruFiles.xmlDoc.Save(writer);
    writer.Close();
  }

  private static string GetNameFromPath(string path)
  {
    string nameFromPath;
    if (path.Length <= 40)
    {
      nameFromPath = path;
    }
    else
    {
      string str1 = path[0].ToString() + "\\...";
      int startIndex1 = path.Length + str1.Length - 40 - 1;
      string str2 = path.Substring(startIndex1);
      int startIndex2 = str2.IndexOf('\\');
      if (startIndex2 == -1)
        startIndex2 = 0;
      string str3 = str2.Substring(startIndex2);
      nameFromPath = str1 + str3;
    }
    return nameFromPath;
  }
}
