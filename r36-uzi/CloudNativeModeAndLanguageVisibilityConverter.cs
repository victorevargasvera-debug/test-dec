// Decompiled with JetBrains decompiler
// Type: MackinawCPS.CloudNativeModeAndLanguageVisibilityConverter
// Assembly: APXFamilyCPS, Version=36.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 9359335E-041C-4B12-9409-F4E6E7D93299
// Assembly location: C:\Program Files (x86)\Motorola\ApxFamilyCPS R36.00\APXFamilyCPS1.exe

using System;
using System.Globalization;
using System.Windows.Data;

#nullable disable
namespace MackinawCPS;

public class CloudNativeModeAndLanguageVisibilityConverter : IMultiValueConverter
{
  public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
  {
    if (values.Length != 2)
      return (object) false;
    int num = (bool) values[0] ? 1 : 0;
    bool flag = (bool) values[1];
    return (object) (bool) (num == 0 ? 0 : (!flag ? 1 : 0));
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
