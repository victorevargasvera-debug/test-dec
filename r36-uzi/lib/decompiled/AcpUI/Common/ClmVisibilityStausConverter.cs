// Decompiled with JetBrains decompiler
// Type: AcpUI.Common.ClmVisibilityStausConverter
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

using AcpBusinessLayer;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

#nullable disable
namespace AcpUI.Common;

public class ClmVisibilityStausConverter : IMultiValueConverter
{
  public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
  {
    if ((bool) DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof (DependencyObject)).DefaultValue)
      return (object) Visibility.Collapsed;
    if (values[0] != DependencyProperty.UnsetValue)
    {
      AcpFieldBase acpFieldBase = (AcpFieldBase) values[0];
      if (acpFieldBase.HiddenDynamic || acpFieldBase.HiddenStatic)
        return (object) Visibility.Collapsed;
    }
    return (object) Visibility.Visible;
  }

  public object[] ConvertBack(
    object value,
    Type[] targetType,
    object parameter,
    CultureInfo culture)
  {
    return (object[]) null;
  }
}
