// Decompiled with JetBrains decompiler
// Type: MackinawCPS.CustomViewMenuVisibilityConverter
// Assembly: APXFamilyCPS, Version=15.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 7983BD42-76AB-479D-8966-B7B635E0E28A
// Assembly location: C:\Program Files (x86)\Motorola\APX Dpt 25\APXFamilyCPS.exe

using AcpCommonLib;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

#nullable disable
namespace MackinawCPS;

public class CustomViewMenuVisibilityConverter : IValueConverter
{
  public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
  {
    Visibility visibility = Visibility.Visible;
    if (value is ApplicationMode applicationMode && applicationMode != ApplicationMode.CustomViewConfigurationMode)
      visibility = Visibility.Collapsed;
    return (object) visibility;
  }

  public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
  {
    return (object) null;
  }
}
