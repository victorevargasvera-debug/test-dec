// Decompiled with JetBrains decompiler
// Type: MackinawCPS.ReportsMenuItemsEnabledConverter
// Assembly: APXFamilyCPS, Version=15.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 7983BD42-76AB-479D-8966-B7B635E0E28A
// Assembly location: C:\Program Files (x86)\Motorola\ApxFamilyDepot R28\APXdepotR28.exe

using AcpCommonLib;
using System;
using System.Globalization;
using System.Windows.Data;

#nullable disable
namespace MackinawCPS;

public class ReportsMenuItemsEnabledConverter : IMultiValueConverter
{
  public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
  {
    bool flag = false;
    if (values.Length == 3 && values[0] is ApplicationMode)
    {
      int num;
      switch ((ApplicationMode) values[0])
      {
        case ApplicationMode.CodeplugConfigurationMode:
        case ApplicationMode.CustomViewConfigurationMode:
          if ((bool) values[1])
          {
            num = !(bool) values[2] ? 1 : 0;
            break;
          }
          goto default;
        default:
          num = 1;
          break;
      }
      flag = num == 0;
    }
    return (object) flag;
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
