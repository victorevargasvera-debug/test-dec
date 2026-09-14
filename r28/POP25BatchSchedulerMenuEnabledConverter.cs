// Decompiled with JetBrains decompiler
// Type: MackinawCPS.POP25BatchSchedulerMenuEnabledConverter
// Assembly: APXFamilyCPS, Version=15.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 7983BD42-76AB-479D-8966-B7B635E0E28A
// Assembly location: C:\Program Files (x86)\Motorola\ApxFamilyDepot R28\APXdepotR28.exe

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
