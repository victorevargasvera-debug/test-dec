// Decompiled with JetBrains decompiler
// Type: MackinawCPS.TreeRootHeaderConverter
// Assembly: APXFamilyCPS, Version=36.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 9359335E-041C-4B12-9409-F4E6E7D93299
// Assembly location: C:\Program Files (x86)\Motorola\ApxFamilyCPS R36.00\APXFamilyCPS1.exe

using AcpCommonLib;
using CommonResources;
using System;
using System.Globalization;
using System.Windows.Data;

#nullable disable
namespace MackinawCPS;

public class TreeRootHeaderConverter : IMultiValueConverter
{
  public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
  {
    string str = AppResources.Unkown_Id;
    if (AppInfoManager.AppMode == ApplicationMode.CustomViewConfigurationMode)
    {
      str = AppResources.View_Manager;
    }
    else
    {
      for (int index = 0; index < values.Length; ++index)
      {
        if (values[index] is string && !string.IsNullOrEmpty((string) values[index]))
        {
          str = (string) values[index];
          break;
        }
      }
    }
    return (object) str;
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
