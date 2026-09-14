// Decompiled with JetBrains decompiler
// Type: MackinawCPS.ComparatorMenuEnabledConverter
// Assembly: APXFamilyCPS, Version=36.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 9359335E-041C-4B12-9409-F4E6E7D93299
// Assembly location: C:\Program Files (x86)\Motorola\ApxFamilyCPS R36.00\APXFamilyCPS1.exe

using DevComponents.WpfRibbon;
using System;
using System.Globalization;
using System.Windows.Data;

#nullable disable
namespace MackinawCPS;

public class ComparatorMenuEnabledConverter : IMultiValueConverter
{
  public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
  {
    bool flag1 = false;
    if (values.Length == 2 && values[0] != null && values[0] is PaneItem)
    {
      PaneItem paneItem = (PaneItem) values[0];
      bool flag2 = (bool) values[1];
      flag1 = !(paneItem.Name == "ButtonHome") && flag2;
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
