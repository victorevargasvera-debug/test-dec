// Decompiled with JetBrains decompiler
// Type: AcpSecurityLib.KeyWriteProtectEnabledConverter
// Assembly: AcpSecurityLib, Version=23.1.0.23, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 41EFF54A-68D7-40EA-A234-214D6B602874
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpSecurityLib.dll

using AcpASKLib;
using AcpCommonResources;
using System;
using System.Globalization;
using System.Windows.Data;

#nullable disable
namespace AcpSecurityLib;

public class KeyWriteProtectEnabledConverter : IMultiValueConverter
{
  public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
  {
    string str = (string) null;
    KeySource keySource = (KeySource) values[0];
    bool flag = (bool) values[1];
    switch (keySource)
    {
      case KeySource.HARDWARE:
        str = flag.ToString();
        break;
      case KeySource.LEGACY_KEY_FILE:
        str = AcpResources.NA_Id;
        break;
    }
    return (object) str;
  }

  public object[] ConvertBack(
    object value,
    Type[] targetType,
    object parameter,
    CultureInfo culture)
  {
    throw new NotImplementedException();
  }
}
