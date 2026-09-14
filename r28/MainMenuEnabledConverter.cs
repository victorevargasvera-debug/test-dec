// Decompiled with JetBrains decompiler
// Type: MackinawCPS.MainMenuEnabledConverter
// Assembly: APXFamilyCPS, Version=15.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 7983BD42-76AB-479D-8966-B7B635E0E28A
// Assembly location: C:\Program Files (x86)\Motorola\ApxFamilyDepot R28\APXdepotR28.exe

using AcpCommonLib;
using System;
using System.Globalization;
using System.Windows.Data;

#nullable disable
namespace MackinawCPS;

public class MainMenuEnabledConverter : IMultiValueConverter
{
  public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
  {
    bool flag1 = true;
    if (values.Length == 2)
    {
      if (values[0] is ApplicationMode)
        flag1 = (ApplicationMode) values[0] == ApplicationMode.CodeplugConfigurationMode && (bool) values[1];
    }
    else if (values.Length == 4 && values[0] is ApplicationMode)
    {
      ApplicationMode applicationMode = (ApplicationMode) values[0];
      bool flag2 = (bool) values[1];
      flag1 = applicationMode == ApplicationMode.CodeplugConfigurationMode && (bool) values[1] && values[2] == null && values[3] == null;
    }
    return (object) flag1;
  }

  public object[] ConvertBack(
    object value,
    Type[] targetType,
    object parameter,
    CultureInfo culture)
  {
    return (object[]) null;
  }
}
