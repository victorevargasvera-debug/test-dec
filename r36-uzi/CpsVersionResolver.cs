// Decompiled with JetBrains decompiler
// Type: MackinawCPS.CpsVersionResolver
// Assembly: APXFamilyCPS, Version=36.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 9359335E-041C-4B12-9409-F4E6E7D93299
// Assembly location: C:\Program Files (x86)\Motorola\ApxFamilyCPS R36.00\APXFamilyCPS1.exe

using Motorola.Common.CommonLib;
using SpecialFeatures.Comms;
using System;
using System.IO;
using System.Reflection;
using System.Xml;

#nullable disable
namespace MackinawCPS;

public class CpsVersionResolver
{
  private const string RmConfigFileName = "cpsConfig.xml.rm";
  private static readonly CpsVersionResolver _instance = new CpsVersionResolver();

  public static CpsVersionResolver Instance => CpsVersionResolver._instance;

  public bool IsItCpsWithoutAnRm { get; private set; }

  private CpsVersionResolver() => this.GetValueFromXml();

  private void GetValueFromXml()
  {
    try
    {
      XmlTextReader xmlTextReader = new XmlTextReader(MetaDataEnDecryptHelper.Instance.DecryptFileToStream(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "cpsConfig.xml.rm"), false));
      while (xmlTextReader.Read())
      {
        if (xmlTextReader.NodeType == XmlNodeType.Element && xmlTextReader.ReadToDescendant("IsItCpsWithoutAnRm"))
        {
          xmlTextReader.Read();
          this.IsItCpsWithoutAnRm = Convert.ToBoolean(xmlTextReader.Value);
        }
      }
    }
    catch (Exception ex)
    {
      this.IsItCpsWithoutAnRm = true;
      Logger.Log(ex.Message);
    }
  }
}
