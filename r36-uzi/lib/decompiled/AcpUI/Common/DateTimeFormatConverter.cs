// Decompiled with JetBrains decompiler
// Type: AcpUI.Common.DateTimeFormatConverter
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

#nullable disable
namespace AcpUI.Common;

public class DateTimeFormatConverter : IValueConverter
{
  public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
  {
    if ((bool) DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof (DependencyObject)).DefaultValue)
      return (object) string.Empty;
    if (!(value is long ticks))
      return (object) value.ToString();
    DateTime localTime = new DateTime(ticks).ToLocalTime();
    return parameter is string format ? (object) string.Format((IFormatProvider) culture, format, (object) localTime) : (object) string.Format((IFormatProvider) culture, "{0:dd-MMM-yyyy hh:mm}", (object) localTime);
  }

  public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
  {
    throw new NotImplementedException("Method not implemented");
  }
}
