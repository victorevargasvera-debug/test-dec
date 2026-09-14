// Decompiled with JetBrains decompiler
// Type: MackinawCPS.POP25BatchSchedulerMenuEnabledConverter
// Assembly: APXFamilyCPS, Version=36.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 9359335E-041C-4B12-9409-F4E6E7D93299
// Assembly location: C:\Program Files (x86)\Motorola\ApxFamilyCPS R36.00\APXFamilyCPS1.exe

using System;
using System.Globalization;
using System.Windows.Data;

#nullable disable
namespace MackinawCPS;

public class POP25BatchSchedulerMenuEnabledConverter : IMultiValueConverter
{
  public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
  {
    bool flag = false;
    if (values.Length == 3 && values[0] is bool && values[1] is bool && values[2] is bool)
      flag = (bool) values[0] && (bool) values[1] && (bool) values[2];
    if (values.Length == 4 && values[0] is bool && values[1] is bool && values[2] is bool)
      flag = (bool) values[0] && (bool) values[1] && (bool) values[2] && values[3] == null;
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
