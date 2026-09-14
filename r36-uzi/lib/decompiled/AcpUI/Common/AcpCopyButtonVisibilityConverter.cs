// Decompiled with JetBrains decompiler
// Type: AcpUI.Common.AcpCopyButtonVisibilityConverter
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

using AcpBusinessLayer;
using AcpCommonLib;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

#nullable disable
namespace AcpUI.Common;

public class AcpCopyButtonVisibilityConverter : IMultiValueConverter
{
  public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
  {
    if ((bool) DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof (DependencyObject)).DefaultValue)
      return (object) false;
    if (values[0] == DependencyProperty.UnsetValue || values[1] == DependencyProperty.UnsetValue || values[2] == DependencyProperty.UnsetValue || values[3] == DependencyProperty.UnsetValue)
      return (object) false;
    AcpFieldBase acpFieldBase = values[1] as AcpFieldBase;
    return (ApplicationMode) values[0] == ApplicationMode.CodeplugComparisonMode && !(values[1] is AcpKeyField) && !(values[1] is IAcpPointerField) && acpFieldBase != null && !acpFieldBase.BlockDataTransfer && bool.Parse(values[2].ToString()) && bool.Parse(values[3].ToString()) ? (object) true : (object) false;
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
