// Decompiled with JetBrains decompiler
// Type: MackinawCPS.ResetRadioPasswordEnabledConverter
// Assembly: APXFamilyCPS, Version=36.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 9359335E-041C-4B12-9409-F4E6E7D93299
// Assembly location: C:\Program Files (x86)\Motorola\ApxFamilyCPS R36.00\APXFamilyCPS1.exe

using Motorola.CommonCPS.Server.EntityModel;
using System;
using System.Globalization;
using System.Windows.Data;

#nullable disable
namespace MackinawCPS;

public class ResetRadioPasswordEnabledConverter : IValueConverter
{
  public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
  {
    if (value == null)
      return (object) true;
    if (!(value is APXRadio))
      throw new ArgumentException("The provided value should be of type APXRadio (DeviceFromServer).", nameof (value));
    return (object) false;
  }

  public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
  {
    throw new NotImplementedException();
  }
}
