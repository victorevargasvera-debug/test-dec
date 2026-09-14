// Decompiled with JetBrains decompiler
// Type: MackinawCPS.TreeRootHeaderConverter
// Assembly: APXFamilyCPS, Version=15.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 7983BD42-76AB-479D-8966-B7B635E0E28A
// Assembly location: C:\Program Files (x86)\Motorola\APX Dpt 25\APXFamilyCPS.exe

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
