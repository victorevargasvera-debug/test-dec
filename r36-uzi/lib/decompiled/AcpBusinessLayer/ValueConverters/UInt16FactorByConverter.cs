// Decompiled with JetBrains decompiler
// Type: AcpBusinessLayer.ValueConverters.UInt16FactorByConverter
// Assembly: AcpBusinessLayer, Version=23.1.0.23, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 44CF2A76-4418-422B-9DDD-B27A71BAF20C
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpBusinessLayer.dll

using System;
using System.Globalization;
using System.Windows.Data;

#nullable disable
namespace AcpBusinessLayer.ValueConverters;

public class UInt16FactorByConverter : IValueConverter
{
  private ushort x;

  public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
  {
    return (object) ((int) (ushort) value * (int) this.x);
  }

  public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
  {
    return (object) ((int) System.Convert.ToUInt16(value) / (int) this.x);
  }

  public UInt16FactorByConverter(ushort x) => this.x = x;

  internal UInt16FactorByConverter() => this.x = (ushort) 1;
}
