// Decompiled with JetBrains decompiler
// Type: MackinawCPS.RibbonRadioUserDefinedEnabledConverter
// Assembly: APXFamilyCPS, Version=15.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 7983BD42-76AB-479D-8966-B7B635E0E28A
// Assembly location: C:\Program Files (x86)\Motorola\ApxFamilyDepot R28\APXdepotR28.exe

using AcpCommonLib;
using Microsoft.Win32;
using System;
using System.Globalization;
using System.Windows.Data;

#nullable disable
namespace MackinawCPS;

public class RibbonRadioUserDefinedEnabledConverter : IMultiValueConverter
{
  public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
  {
    bool flag1 = false;
    if (values.Length == 2 && values[0] is ApplicationMode)
    {
      ApplicationMode applicationMode = (ApplicationMode) values[0];
      bool flag2 = (bool) values[1];
      object obj = ((Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Office\\11.0\\Word\\InstallRoot", "Path", (object) false) ?? Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Office\\12.0\\Word\\InstallRoot", "Path", (object) false)) ?? Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Office\\14.0\\Word\\InstallRoot", "Path", (object) false)) ?? Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Office\\15.0\\Word\\InstallRoot", "Path", (object) false);
      try
      {
        if (obj == null)
          obj = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey("SOFTWARE").OpenSubKey("Microsoft").OpenSubKey("Office").OpenSubKey("11.0").OpenSubKey("Word").OpenSubKey("InstallRoot").GetValue("Path");
      }
      catch
      {
      }
      try
      {
        if (obj == null)
          obj = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey("SOFTWARE").OpenSubKey("Microsoft").OpenSubKey("Office").OpenSubKey("12.0").OpenSubKey("Word").OpenSubKey("InstallRoot").GetValue("Path");
      }
      catch
      {
      }
      try
      {
        if (obj == null)
          obj = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey("SOFTWARE").OpenSubKey("Microsoft").OpenSubKey("Office").OpenSubKey("14.0").OpenSubKey("Word").OpenSubKey("InstallRoot").GetValue("Path");
      }
      catch
      {
      }
      try
      {
        if (obj == null)
          obj = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey("SOFTWARE").OpenSubKey("Microsoft").OpenSubKey("Office").OpenSubKey("15.0").OpenSubKey("Word").OpenSubKey("InstallRoot").GetValue("Path");
      }
      catch
      {
      }
      bool flag3 = obj != null;
      flag1 = (applicationMode == ApplicationMode.CodeplugConfigurationMode || applicationMode == ApplicationMode.CustomViewConfigurationMode) && (bool) values[1] && flag3;
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
