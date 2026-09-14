// Decompiled with JetBrains decompiler
// Type: MackinawCPS.NavigationButtonEnabledConverter
// Assembly: APXFamilyCPS, Version=15.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 7983BD42-76AB-479D-8966-B7B635E0E28A
// Assembly location: C:\Program Files (x86)\Motorola\APX Dpt 25\APXFamilyCPS.exe

using AcpCommonLib;
using System;
using System.Globalization;
using System.Windows.Data;

#nullable disable
namespace MackinawCPS;

public class NavigationButtonEnabledConverter : IMultiValueConverter
{
  public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
  {
    bool flag1 = true;
    if (values.Length == 4 && values[0] is ApplicationMode)
    {
      ApplicationMode applicationMode = (ApplicationMode) values[0];
      bool flag2 = (bool) values[1];
      bool flag3 = (bool) values[2];
      bool flag4 = (bool) values[3];
      string str = (string) parameter;
      if (flag4)
        return (object) false;
      switch (str)
      {
        case "ButtonHome":
          int num1;
          switch (applicationMode)
          {
            case ApplicationMode.CodeplugConfigurationMode:
              num1 = 1;
              break;
            case ApplicationMode.CustomViewConfigurationMode:
              num1 = !flag3 ? 1 : 0;
              break;
            default:
              num1 = 0;
              break;
          }
          flag1 = num1 != 0;
          break;
        case "ButtonCpgNav":
          int num2;
          switch (applicationMode)
          {
            case ApplicationMode.CodeplugConfigurationMode:
              num2 = 1;
              break;
            case ApplicationMode.CustomViewConfigurationMode:
              num2 = !flag3 ? 1 : 0;
              break;
            default:
              num2 = 0;
              break;
          }
          flag1 = num2 != 0;
          break;
        case "ButtonCustomViewMode":
          int num3;
          switch (applicationMode)
          {
            case ApplicationMode.CodeplugConfigurationMode:
              num3 = !flag2 ? 1 : 0;
              break;
            case ApplicationMode.CustomViewConfigurationMode:
              num3 = 1;
              break;
            default:
              num3 = 0;
              break;
          }
          flag1 = num3 != 0;
          break;
      }
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
