// Decompiled with JetBrains decompiler
// Type: AcpSecurityLib.DecToHexConverter
// Assembly: AcpSecurityLib, Version=23.1.0.23, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 41EFF54A-68D7-40EA-A234-214D6B602874
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpSecurityLib.dll

using System;
using System.Globalization;
using System.Windows.Data;

#nullable disable
namespace AcpSecurityLib;

public class DecToHexConverter : IValueConverter
{
  public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
  {
    return value is int num ? (object) num.ToString("X", (IFormatProvider) CultureInfo.CurrentCulture) : (object) value.ToString();
  }

  public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
  {
    return value is int num ? (object) num.ToString("D", (IFormatProvider) CultureInfo.CurrentCulture) : (object) value.ToString();
  }
}
