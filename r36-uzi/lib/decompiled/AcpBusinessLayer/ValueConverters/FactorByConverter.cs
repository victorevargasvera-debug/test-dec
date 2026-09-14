// Decompiled with JetBrains decompiler
// Type: AcpBusinessLayer.ValueConverters.FactorByConverter
// Assembly: AcpBusinessLayer, Version=23.1.0.23, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 44CF2A76-4418-422B-9DDD-B27A71BAF20C
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpBusinessLayer.dll

using AcpCommonResources;
using System;
using System.Globalization;
using System.Windows.Data;

#nullable disable
namespace AcpBusinessLayer.ValueConverters;

public class FactorByConverter : IValueConverter
{
  private int factor;
  private int uiOffset;

  private FactorByConverter()
  {
  }

  public FactorByConverter(int factor, int uiOffset)
  {
    this.factor = factor;
    this.uiOffset = uiOffset;
  }

  public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
  {
    return (object) (this.uiOffset + (int) value * this.factor).ToString();
  }

  public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
  {
    int num1 = int.Parse(value.ToString());
    if (num1 < this.uiOffset)
      throw new ArgumentException(AcpResources.UI_Value_Below_Offset);
    int num2 = num1 - this.uiOffset;
    if (num2 % this.factor != 0)
      throw new ArgumentException(AcpResources.UI_Value_Not_On_Step);
    return (object) (num2 / this.factor);
  }
}
