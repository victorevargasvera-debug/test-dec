// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.Converters.BoolToVisibilityConverter
// Assembly: AcpWpfRibbon, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 45A745B5-88C3-40EE-B1E5-8DBA2EACD529
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfRibbon.dll

using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

#nullable disable
namespace DevComponents.WpfRibbon.Converters;

public class BoolToVisibilityConverter : IValueConverter
{
  public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
  {
    bool flag = (bool) value;
    if (targetType == typeof (string))
      return (object) flag.ToString();
    if (!(targetType == typeof (Visibility)))
      return (object) null;
    return (string) parameter == "Inverse" ? (!flag ? (object) Visibility.Visible : (object) Visibility.Collapsed) : (flag ? (object) Visibility.Visible : (object) Visibility.Collapsed);
  }

  public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
  {
    if (!(value is Visibility visibility))
      throw new Exception("The method or operation is not implemented.");
    return visibility == Visibility.Visible ? (object) true : (object) false;
  }
}
