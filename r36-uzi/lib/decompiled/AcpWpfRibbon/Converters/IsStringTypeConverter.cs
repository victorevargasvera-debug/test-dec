// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.Converters.IsStringTypeConverter
// Assembly: AcpWpfRibbon, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 45A745B5-88C3-40EE-B1E5-8DBA2EACD529
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfRibbon.dll

using System;
using System.Globalization;
using System.Windows.Data;

#nullable disable
namespace DevComponents.WpfRibbon.Converters;

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
