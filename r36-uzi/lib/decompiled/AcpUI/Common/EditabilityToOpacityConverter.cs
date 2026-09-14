// Decompiled with JetBrains decompiler
// Type: AcpUI.Common.EditabilityToOpacityConverter
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

using System;
using System.Globalization;
using System.Windows.Data;

#nullable disable
namespace AcpUI.Common;

public class EditabilityToOpacityConverter : IValueConverter
{
  public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
  {
    double num = 1.0;
    if (value is bool flag && !flag)
      num = 0.25;
    return (object) num;
  }

  public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
  {
    throw new NotImplementedException("Method not implemented");
  }
}
