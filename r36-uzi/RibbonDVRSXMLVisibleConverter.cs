// Decompiled with JetBrains decompiler
// Type: MackinawCPS.RibbonDVRSXMLVisibleConverter
// Assembly: APXFamilyCPS, Version=36.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 9359335E-041C-4B12-9409-F4E6E7D93299
// Assembly location: C:\Program Files (x86)\Motorola\ApxFamilyCPS R36.00\APXFamilyCPS1.exe

using AcpCommonLib;
using System;
using System.Globalization;
using System.Windows.Data;

#nullable disable
namespace MackinawCPS;

public class RibbonDVRSXMLVisibleConverter : IMultiValueConverter
{
  public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
  {
    bool flag1 = false;
    if (values.Length == 3 && values[0] is ApplicationMode)
    {
      ApplicationMode applicationMode = (ApplicationMode) values[0];
      bool flag2 = (bool) values[1];
      bool flag3 = (bool) values[2];
      if (((applicationMode == ApplicationMode.CodeplugConfigurationMode ? 1 : (applicationMode == ApplicationMode.CodeplugComparisonMode ? 1 : 0)) & (flag2 ? 1 : 0) & (flag3 ? 1 : 0)) != 0)
        flag1 = true;
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
