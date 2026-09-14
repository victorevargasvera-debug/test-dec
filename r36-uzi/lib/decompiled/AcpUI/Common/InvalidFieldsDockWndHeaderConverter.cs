// Decompiled with JetBrains decompiler
// Type: AcpUI.Common.InvalidFieldsDockWndHeaderConverter
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

using AcpCommonResources;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

#nullable disable
namespace AcpUI.Common;

public class InvalidFieldsDockWndHeaderConverter : IValueConverter
{
  public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
  {
    if ((bool) DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof (DependencyObject)).DefaultValue)
      return (object) string.Empty;
    string invalidFieldsReport = AcpResources.Invalid_Fields_Report;
    string str;
    if (value is int)
    {
      int int32 = System.Convert.ToInt32(value);
      str = int32 <= 0 ? invalidFieldsReport : $"{invalidFieldsReport} ({int32.ToString()})";
    }
    else
      str = invalidFieldsReport;
    return (object) str;
  }

  public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
  {
    return (object) null;
  }
}
