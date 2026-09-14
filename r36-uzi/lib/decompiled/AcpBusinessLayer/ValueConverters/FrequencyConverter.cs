// Decompiled with JetBrains decompiler
// Type: AcpBusinessLayer.ValueConverters.FrequencyConverter
// Assembly: AcpBusinessLayer, Version=23.1.0.23, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 44CF2A76-4418-422B-9DDD-B27A71BAF20C
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpBusinessLayer.dll

using AcpCommonResources;
using System;
using System.Globalization;
using System.Windows.Data;

#nullable disable
namespace AcpBusinessLayer.ValueConverters;

public class FrequencyConverter : IValueConverter
{
  private bool kiloHertz;
  private int step;

  public FrequencyConverter(int step) => this.step = step;

  public FrequencyConverter(bool kiloHertz, int step)
  {
    this.kiloHertz = kiloHertz;
    this.step = step;
  }

  public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
  {
    double num = (double) (int) value;
    return this.kiloHertz ? (object) (num / 200.0).ToString("f3") : (object) (num / 200000.0).ToString("f6");
  }

  public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
  {
    Decimal num1 = Decimal.Parse((string) value);
    Decimal num2 = 0M;
    num2 = !this.kiloHertz ? 1000000M : 1000M;
    Decimal num3 = num1 * num2;
    Decimal num4 = System.Convert.ToDecimal(this.step);
    if (!(num3 - Math.Floor(num3 / num4) * num4 == 0.0M))
      throw new ArgumentException(AcpResources.UI_Value_Not_On_Step);
    Decimal num5 = 5M;
    if (num3 - Math.Floor(num3 / num5) * num5 == 0.0M)
      return (object) (int) (num3 / num5);
    throw new ArgumentException(AcpResources.UI_Value_Not_On_Step);
  }
}
