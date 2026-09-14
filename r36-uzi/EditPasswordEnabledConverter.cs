// Decompiled with JetBrains decompiler
// Type: MackinawCPS.EditPasswordEnabledConverter
// Assembly: APXFamilyCPS, Version=36.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 9359335E-041C-4B12-9409-F4E6E7D93299
// Assembly location: C:\Program Files (x86)\Motorola\ApxFamilyCPS R36.00\APXFamilyCPS1.exe

using Motorola.Common.Communication.CommonUtil;
using Motorola.CommonCPS.Server.EntityModel;
using System;
using System.Globalization;
using System.Windows.Data;

#nullable disable
namespace MackinawCPS;

public class EditPasswordEnabledConverter : IValueConverter
{
  public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
  {
    if (value == null)
      return (object) true;
    if (!(value is APXRadio apxRadio))
      return (object) true;
    if (!apxRadio.ProductFamily.HasValue)
      return (object) true;
    switch ((ProductFamily) apxRadio.ProductFamily.Value)
    {
      case ProductFamily.AstroRadio:
      case ProductFamily.AMPRadio:
        return (object) false;
      default:
        return (object) true;
    }
  }

  public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
  {
    return (object) null;
  }
}
