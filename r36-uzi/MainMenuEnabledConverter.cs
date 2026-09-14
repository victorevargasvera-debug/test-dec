// Decompiled with JetBrains decompiler
// Type: MackinawCPS.MainMenuEnabledConverter
// Assembly: APXFamilyCPS, Version=36.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 9359335E-041C-4B12-9409-F4E6E7D93299
// Assembly location: C:\Program Files (x86)\Motorola\ApxFamilyCPS R36.00\APXFamilyCPS1.exe

using AcpCommonLib;
using System;
using System.Globalization;
using System.Windows.Data;

#nullable disable
namespace MackinawCPS;

public class MainMenuEnabledConverter : IMultiValueConverter
{
  public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
  {
    bool flag = true;
    if (values.Length == 2)
    {
      if (values[0] is ApplicationMode)
        flag = (ApplicationMode) values[0] == ApplicationMode.CodeplugConfigurationMode && (bool) values[1];
    }
    else if (values.Length == 4 && values[0] is ApplicationMode)
    {
      int num1 = (int) values[0];
      int num2 = (bool) values[1] ? 1 : 0;
      flag = num1 == 0 && (bool) values[1] && values[2] == null && values[3] == null;
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
