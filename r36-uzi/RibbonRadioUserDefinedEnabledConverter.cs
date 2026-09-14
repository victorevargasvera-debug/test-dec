// Decompiled with JetBrains decompiler
// Type: MackinawCPS.RibbonRadioUserDefinedEnabledConverter
// Assembly: APXFamilyCPS, Version=36.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 9359335E-041C-4B12-9409-F4E6E7D93299
// Assembly location: C:\Program Files (x86)\Motorola\ApxFamilyCPS R36.00\APXFamilyCPS1.exe

using AcpCommonLib;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

#nullable disable
namespace MackinawCPS;

public class RibbonRadioUserDefinedEnabledConverter : IMultiValueConverter
{
  private static string[] wordVersions = new string[4]
  {
    "11.0",
    "12.0",
    "14.0",
    "15.0"
  };

  private bool SearchMsWord(string version)
  {
    try
    {
      using (RegistryKey registryKey1 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey("SOFTWARE")?.OpenSubKey("Microsoft")?.OpenSubKey("Office")?.OpenSubKey(version)?.OpenSubKey("Word")?.OpenSubKey("InstallRoot"))
      {
        bool flag = !string.IsNullOrEmpty(registryKey1?.GetValue("Path")?.ToString());
        if (!flag)
        {
          using (RegistryKey registryKey2 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey("SOFTWARE")?.OpenSubKey("Microsoft")?.OpenSubKey("Office")?.OpenSubKey(version)?.OpenSubKey("Word")?.OpenSubKey("InstallRoot"))
            flag = !string.IsNullOrEmpty(registryKey2?.GetValue("Path")?.ToString());
        }
        return flag;
      }
    }
    catch (Exception ex)
    {
      Trace.WriteLine("SearchMsWord threw an exception, error: " + ex.Message);
      return false;
    }
  }

  public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
  {
    bool flag1 = false;
    if (values.Length == 2 && values[0] is ApplicationMode)
    {
      ApplicationMode applicationMode = (ApplicationMode) values[0];
      int num = (bool) values[1] ? 1 : 0;
      bool flag2 = ((IEnumerable<string>) RibbonRadioUserDefinedEnabledConverter.wordVersions).Any<string>(new Func<string, bool>(this.SearchMsWord));
      flag1 = ((applicationMode == ApplicationMode.CodeplugConfigurationMode || applicationMode == ApplicationMode.CustomViewConfigurationMode ? ((bool) values[1] ? 1 : 0) : 0) & (flag2 ? 1 : 0)) != 0;
    }
    return (object) flag1;
  }

  public object[] ConvertBack(
    object value,
    Type[] targetType,
    object parameter,
    CultureInfo culture)
  {
    return (object[]) null;
  }
}
