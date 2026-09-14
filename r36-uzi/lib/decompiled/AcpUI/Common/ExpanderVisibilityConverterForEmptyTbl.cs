// Decompiled with JetBrains decompiler
// Type: AcpUI.Common.ExpanderVisibilityConverterForEmptyTbl
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

public class ExpanderVisibilityConverterForEmptyTbl : IMultiValueConverter
{
  public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
  {
    if ((bool) DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof (DependencyObject)).DefaultValue)
      return (object) false;
    bool flag1 = false;
    int int32 = System.Convert.ToInt32(parameter);
    if (values[0] != DependencyProperty.UnsetValue)
    {
      if (bool.Parse(values[0].ToString()))
      {
        for (int index = 1; index <= int32; ++index)
        {
          if (values[index] != DependencyProperty.UnsetValue)
            flag1 = flag1 || bool.Parse(values[index].ToString());
        }
      }
      else
      {
        for (int index = int32 + 1; index <= int32 * 2; ++index)
        {
          if (values[index] != DependencyProperty.UnsetValue)
            flag1 = flag1 || bool.Parse(values[index].ToString());
        }
      }
    }
    if (!flag1)
      return (object) false;
    bool flag2 = false;
    for (int index = int32 * 2 + 1; index < values.Length; ++index)
    {
      bool result;
      if (values[index] != DependencyProperty.UnsetValue && bool.TryParse(values[index].ToString(), out result))
        flag2 |= result;
    }
    return (object) flag2;
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
