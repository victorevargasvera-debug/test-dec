// Decompiled with JetBrains decompiler
// Type: AcpUI.Common.BooleanToColorConverter
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

#nullable disable
namespace AcpUI.Common;

public class BooleanToColorConverter : IValueConverter
{
  public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
  {
    Brush brush = (Brush) Brushes.Blue;
    if (value is bool flag && flag)
      brush = (Brush) Brushes.Red;
    return (object) brush;
  }

  public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
  {
    throw new NotImplementedException("Method not implemented");
  }
}
