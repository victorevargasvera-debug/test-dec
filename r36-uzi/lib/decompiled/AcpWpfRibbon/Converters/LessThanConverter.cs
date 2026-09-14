// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.Converters.LessThanConverter
// Assembly: AcpWpfRibbon, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 45A745B5-88C3-40EE-B1E5-8DBA2EACD529
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfRibbon.dll

using System;
using System.Globalization;
using System.Windows.Data;

#nullable disable
namespace DevComponents.WpfRibbon.Converters;

[ValueConversion(typeof (double), typeof (bool), ParameterType = typeof (double))]
public class LessThanConverter : IValueConverter
{
  public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
  {
    double num1 = (double) value;
    switch (parameter)
    {
      case double result:
label_4:
        double num2 = result;
        return (object) (num1 < num2);
      case string _:
        if (!double.TryParse(parameter.ToString(), out result))
          throw new FormatException("paramter not in supported double format and cannot be parsed.");
        goto label_4;
      default:
        throw new ArgumentException("Unsupported paramter type. Supported are double and string.");
    }
  }

  public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
  {
    return (object) new NotSupportedException("ConvertBack not supported by this converter.");
  }
}
