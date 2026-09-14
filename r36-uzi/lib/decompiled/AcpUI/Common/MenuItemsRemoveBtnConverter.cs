// Decompiled with JetBrains decompiler
// Type: AcpUI.Common.MenuItemsRemoveBtnConverter
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

public class MenuItemsRemoveBtnConverter : IMultiValueConverter
{
  public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
  {
    if ((bool) DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof (DependencyObject)).DefaultValue)
      return (object) false;
    if (values[0] == DependencyProperty.UnsetValue || values[1] == DependencyProperty.UnsetValue)
      return (object) false;
    int int32 = System.Convert.ToInt32(values[0]);
    if (System.Convert.ToInt32(values[1]) < 0)
      return (object) false;
    return int32 > 1 ? (object) true : (object) false;
  }

  public object[] ConvertBack(
    object value,
    Type[] targetType,
    object parameter,
    CultureInfo culture)
  {
    throw new NotImplementedException();
  }
}
