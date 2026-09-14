// Decompiled with JetBrains decompiler
// Type: AcpUI.Common.AcpXamDataPresenterVisibilityConverterForEmptyTbl
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

using AcpCommonLib;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

#nullable disable
namespace AcpUI.Common;

public class AcpXamDataPresenterVisibilityConverterForEmptyTbl : IMultiValueConverter
{
  public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
  {
    if ((bool) DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof (DependencyObject)).DefaultValue)
      return (object) false;
    bool flag = false;
    IValueConverter valueConverter = (IValueConverter) new BooleanToVisibilityConverter();
    int int32 = System.Convert.ToInt32(parameter);
    if (values[0] != DependencyProperty.UnsetValue && values[1] != DependencyProperty.UnsetValue && values[2] != DependencyProperty.UnsetValue && values[3] != DependencyProperty.UnsetValue)
    {
      if ((ApplicationMode) values[0] == ApplicationMode.CodeplugComparisonMode && bool.Parse(values[1].ToString()) && !bool.Parse(values[2].ToString()))
        return (object) false;
      if (values[4] != DependencyProperty.UnsetValue)
      {
        if (bool.Parse(values[4].ToString()))
        {
          for (int index = 5; index < 5 + int32; ++index)
          {
            if (values[index] != DependencyProperty.UnsetValue)
              flag = flag || bool.Parse(values[index].ToString());
          }
        }
        else
        {
          for (int index = 5 + int32; index < 5 + int32 * 2; ++index)
          {
            if (values[index] != DependencyProperty.UnsetValue)
              flag = flag || (bool) valueConverter.ConvertBack(values[index], (Type) null, (object) null, culture);
          }
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
