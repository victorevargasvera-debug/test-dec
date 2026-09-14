// Decompiled with JetBrains decompiler
// Type: AcpBusinessLayer.ValueConverters.DivideBy10Converter
// Assembly: AcpBusinessLayer, Version=23.1.0.23, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 44CF2A76-4418-422B-9DDD-B27A71BAF20C
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpBusinessLayer.dll

using System;
using System.Globalization;
using System.Windows.Data;

#nullable disable
namespace AcpBusinessLayer.ValueConverters;

public class DivideBy10Converter : IValueConverter
{
  public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
  {
    return (object) ((double) (int) value / 10.0).ToString("f2");
  }

  public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
  {
    return (object) (int) (double.Parse((string) value) * 10.0);
  }
}
