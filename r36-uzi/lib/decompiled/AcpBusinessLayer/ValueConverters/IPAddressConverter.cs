// Decompiled with JetBrains decompiler
// Type: AcpBusinessLayer.ValueConverters.IPAddressConverter
// Assembly: AcpBusinessLayer, Version=23.1.0.23, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 44CF2A76-4418-422B-9DDD-B27A71BAF20C
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpBusinessLayer.dll

using AcpCommonResources;
using System;
using System.Globalization;
using System.Windows.Data;

#nullable disable
namespace AcpBusinessLayer.ValueConverters;

public class IPAddressConverter : IValueConverter
{
  public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
  {
    long num = (long) value;
    return (object) $"{((byte) num).ToString()}.{((byte) (num >> 8)).ToString()}.{((byte) (num >> 16 /*0x10*/)).ToString()}.{((byte) (num >> 24)).ToString()}";
  }

  public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
  {
    long num = 0;
    string[] strArray = !string.IsNullOrEmpty((string) value) ? ((string) value).Split(new char[1]
    {
      '.'
    }, 5) : throw new ArgumentNullException();
    if (strArray.Length != 4)
      throw new ArgumentException(AcpResources.Not_IPV4_Format);
    for (int index = 0; index < 4; ++index)
    {
      int fromBase = !strArray[index].ToUpper().StartsWith("0X") ? (!strArray[index].ToUpper().StartsWith("0") ? 10 : 8) : 16 /*0x10*/;
      long int32 = (long) System.Convert.ToInt32(strArray[index], fromBase);
      if (int32 < 0L || int32 > (long) byte.MaxValue)
        throw new ArgumentException(AcpResources.Octet_Larger_Than_255);
      num += int32 << 8 * index;
    }
    return (object) num;
  }
}
