// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfDock.Converters.IsStringTypeConverter
// Assembly: AcpWpfDock, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 89CC52D3-0487-4106-AFAE-BE4A13C8A50E
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfDock.dll

using System;
using System.Globalization;
using System.Windows.Data;

#nullable disable
namespace DevComponents.WpfDock.Converters;

[ValueConversion(typeof (object), typeof (bool))]
public class IsStringTypeConverter : IValueConverter
{
  public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
  {
    return value is string ? (object) true : (object) false;
  }

  public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
  {
    return (object) new NotSupportedException("ConvertBack not supported by this converter.");
  }
}
