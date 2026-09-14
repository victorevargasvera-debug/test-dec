// Decompiled with JetBrains decompiler
// Type: AcpBusinessLayer.ValueConverters.UInt32FactorByConverter
// Assembly: AcpBusinessLayer, Version=23.1.0.23, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 44CF2A76-4418-422B-9DDD-B27A71BAF20C
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpBusinessLayer.dll

using System;
using System.Globalization;
using System.Windows.Data;

#nullable disable
namespace AcpBusinessLayer.ValueConverters;

public class UInt32FactorByConverter : IValueConverter
{
  private uint x;

  public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
  {
    return (object) (uint) ((int) (uint) value * (int) this.x);
  }

  public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
  {
    return (object) (System.Convert.ToUInt32(value) / this.x);
  }

  public UInt32FactorByConverter(uint x) => this.x = x;
}
