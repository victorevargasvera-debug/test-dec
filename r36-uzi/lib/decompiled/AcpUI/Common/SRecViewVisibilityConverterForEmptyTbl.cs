// Decompiled with JetBrains decompiler
// Type: AcpUI.Common.SRecViewVisibilityConverterForEmptyTbl
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

public class SRecViewVisibilityConverterForEmptyTbl : IMultiValueConverter
{
  public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
  {
    if ((bool) DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof (DependencyObject)).DefaultValue)
      return (object) false;
    bool flag = false;
    int int32 = System.Convert.ToInt32(parameter);
    if (values[0] != DependencyProperty.UnsetValue && !bool.Parse(values[0].ToString()) && values[1] != DependencyProperty.UnsetValue)
    {
      if (bool.Parse(values[1].ToString()))
      {
        for (int index = 2; index < 2 + int32; ++index)
        {
          if (values[index] != DependencyProperty.UnsetValue)
            flag = flag || bool.Parse(values[index].ToString());
        }
      }
      else
      {
        for (int index = 2 + int32; index < 2 + int32 * 2; ++index)
        {
          if (values[index] != DependencyProperty.UnsetValue)
            flag = flag || bool.Parse(values[index].ToString());
        }
      }
    }
    return (object) flag;
  }

  public object[] ConvertBack(
    object value,
    Type[] targetTypes,
    object parameter,
    CultureInfo culture)
  {
    throw new NotImplementedException();
  }
}
