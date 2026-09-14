// Decompiled with JetBrains decompiler
// Type: MackinawCPS.ReportsMenuItemsEnabledConverter
// Assembly: APXFamilyCPS, Version=36.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 9359335E-041C-4B12-9409-F4E6E7D93299
// Assembly location: C:\Program Files (x86)\Motorola\ApxFamilyCPS R36.00\APXFamilyCPS1.exe

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
      switch ((ApplicationMode) values[0])
      {
        case ApplicationMode.CodeplugConfigurationMode:
        case ApplicationMode.CustomViewConfigurationMode:
          if ((bool) values[1] && (bool) values[2])
          {
            flag = true;
            goto label_5;
          }
          break;
      }
      flag = false;
    }
label_5:
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
