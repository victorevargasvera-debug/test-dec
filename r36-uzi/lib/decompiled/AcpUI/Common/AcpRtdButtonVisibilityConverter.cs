// Decompiled with JetBrains decompiler
// Type: AcpUI.Common.AcpRtdButtonVisibilityConverter
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

public class AcpRtdButtonVisibilityConverter : IMultiValueConverter
{
  public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
  {
    if ((bool) DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof (DependencyObject)).DefaultValue)
      return (object) false;
    if (values[0] == DependencyProperty.UnsetValue || values[1] == DependencyProperty.UnsetValue || values[2] == DependencyProperty.UnsetValue || values[3] == DependencyProperty.UnsetValue || values[4] == DependencyProperty.UnsetValue)
      return (object) false;
    AcpFieldBase acpFieldBase = values[2] as AcpFieldBase;
    AcpListField acpListField = acpFieldBase as AcpListField;
    bool flag = false;
    if (acpListField != null && acpListField.SerializeItems)
      flag = true;
    return (ApplicationMode) values[0] == ApplicationMode.CodeplugConfigurationMode && bool.Parse(values[1].ToString()) && !flag && !(values[2] is AcpKeyField) && !(values[2] is IAcpPointerField) && acpFieldBase != null && !acpFieldBase.BlockDataTransfer && bool.Parse(values[3].ToString()) && bool.Parse(values[4].ToString()) ? (object) true : (object) false;
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
