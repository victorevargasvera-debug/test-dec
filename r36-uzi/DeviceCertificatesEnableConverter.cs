// Decompiled with JetBrains decompiler
// Type: MackinawCPS.DeviceCertificatesEnableConverter
// Assembly: APXFamilyCPS, Version=36.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 9359335E-041C-4B12-9409-F4E6E7D93299
// Assembly location: C:\Program Files (x86)\Motorola\ApxFamilyCPS R36.00\APXFamilyCPS1.exe

using System;
using System.Globalization;
using System.Windows.Data;

#nullable disable
namespace MackinawCPS;

public class DeviceCertificatesEnableConverter : IValueConverter
{
  public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
  {
    bool flag1 = false;
    if (value is bool flag2)
      flag1 = !flag2;
    return (object) flag1;
  }

  public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
  {
    return (object) null;
  }
}
