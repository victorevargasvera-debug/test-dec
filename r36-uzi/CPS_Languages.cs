// Decompiled with JetBrains decompiler
// Type: MackinawCPS.CPS_Languages
// Assembly: APXFamilyCPS, Version=36.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 9359335E-041C-4B12-9409-F4E6E7D93299
// Assembly location: C:\Program Files (x86)\Motorola\ApxFamilyCPS R36.00\APXFamilyCPS1.exe

using Motorola.Common.Communication.CommonUtil;
using Motorola.CommonCPS.Server.EntityModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Xml;

#nullable disable
namespace MackinawCPS;

public sealed class CPS_Languages : IEnumerable
{
  private Dictionary<string, string> localizedLanguages;
  private string appMajorVersion = string.Empty;
  private string appKey = string.Empty;
  private string AppRegistryKeyName = "Languages";
  private string InstalledAppLanguagesRegistryValue = "InstalledApplicationLanguages";
  private string DefaultAppLanguagesRegistryValue = "DefaultApplicationLanguage";
  private string AppRegistryKeyBaseLocation = $"Software{(object) Path.DirectorySeparatorChar}Motorola{(object) Path.DirectorySeparatorChar}";
  private const char LRM = '\u200E';
  private const char RLM = '\u200F';

  internal CPS_Languages()
  {
    this.DefaultCPSLanguage = "en";
    this.localizedLanguages = new Dictionary<string, string>();
    try
    {
      this.DetermineAppMajorVersion();
      if (this.appMajorVersion == null)
        throw new ApplicationException("CPS_Languages constructor: could not find application version");
      this.appKey = $"{this.AppRegistryKeyBaseLocation}ApxFamilyCPS {this.appMajorVersion}{(object) Path.DirectorySeparatorChar}{this.AppRegistryKeyName}";
      if (VersionInfoHelper.IsDFlagExisted(DFlagType.DASTRO))
        this.appKey = $"{this.AppRegistryKeyBaseLocation}VertexStandardCPS {this.appMajorVersion}{(object) Path.DirectorySeparatorChar}{this.AppRegistryKeyName}";
      this.DetermineInstalledLanguages();
      this.DetermineDefaultCPSLanguage();
    }
    catch (Exception ex)
    {
      $"CPS_Languages constructor threw an exception, error: {ex.Message}\n";
      throw;
    }
  }

  private void DetermineAppMajorVersion()
  {
    this.appMajorVersion = string.Empty;
    object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof (AssemblyInformationalVersionAttribute), false);
    if (customAttributes.Length == 0)
      this.appMajorVersion = string.Empty;
    else
      this.appMajorVersion = ((AssemblyInformationalVersionAttribute) customAttributes[0]).InformationalVersion.Substring(0, 6);
  }

  private void DetermineInstalledLanguages()
  {
    string empty = string.Empty;
    string stringValue = RegistrySettings.GetStringValue(this.appKey, this.InstalledAppLanguagesRegistryValue);
    if (string.IsNullOrEmpty(stringValue))
      return;
    string str1 = stringValue;
    char[] chArray = new char[1]{ ',' };
    foreach (string str2 in str1.Split(chArray))
    {
      try
      {
        string name = str2.Trim();
        CultureInfo cultureInfo = new CultureInfo(name);
        string nativeName = cultureInfo.NativeName;
        if (!string.IsNullOrEmpty(cultureInfo.NativeName) && char.IsPunctuation(cultureInfo.NativeName[cultureInfo.NativeName.Length - 1]))
        {
          char ch = !cultureInfo.TextInfo.IsRightToLeft ? '\u200E' : '\u200F';
          nativeName += (string) (object) ch;
        }
        this.localizedLanguages.Add(nativeName, name);
      }
      catch (CultureNotFoundException ex)
      {
      }
      catch (Exception ex)
      {
        throw;
      }
    }
  }

  private void DetermineDefaultCPSLanguage()
  {
    string str1 = string.Empty;
    string empty1 = string.Empty;
    string empty2 = string.Empty;
    string empty3 = string.Empty;
    string str2 = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Motorola_Solutions,_Inc";
    string empty4 = string.Empty;
    object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof (AssemblyInformationalVersionAttribute), false);
    string str3 = customAttributes.Length != 0 ? ((AssemblyInformationalVersionAttribute) customAttributes[0]).InformationalVersion.Substring(1, 2) : string.Empty;
    string str4 = $"{str2}\\{str3}" + "\\userapp.config";
    try
    {
      if (File.Exists(str4))
      {
        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.Load(str4);
        XmlNode xmlNode = xmlDocument.SelectSingleNode("/configuration/userSettings/MackinawCPS.Properties.Settings/setting[@name='UserSelectedApplicationLanguage']/value");
        if (xmlNode != null)
          str1 = xmlNode.InnerText;
      }
    }
    catch (Exception ex)
    {
    }
    if (string.IsNullOrEmpty(str1))
      str1 = RegistrySettings.GetStringValue(this.appKey, this.DefaultAppLanguagesRegistryValue);
    if (string.IsNullOrEmpty(str1))
      return;
    try
    {
      string name = str1.Trim();
      CultureInfo cultureInfo = new CultureInfo(name);
      this.DefaultCPSLanguage = name;
    }
    catch (CultureNotFoundException ex)
    {
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  internal int Count => this.localizedLanguages.Count;

  internal string this[string culture]
  {
    get
    {
      string str = string.Empty;
      if (this.localizedLanguages.TryGetValue(culture, out str))
        str = this.localizedLanguages[culture];
      return str;
    }
  }

  internal bool IsLanguageAvailable(string language)
  {
    bool flag = false;
    if (this.localizedLanguages.ContainsValue(language))
      flag = true;
    return flag;
  }

  internal string[] AdditionalCPSLanguages()
  {
    return new List<string>((IEnumerable<string>) this.localizedLanguages.Values).ToArray();
  }

  internal string[] AdditionalCPSLanguagesDisplayNames()
  {
    return new List<string>((IEnumerable<string>) this.localizedLanguages.Keys).ToArray();
  }

  internal string DefaultCPSLanguage { get; private set; }

  IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.localizedLanguages.GetEnumerator();
}
