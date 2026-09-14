// Decompiled with JetBrains decompiler
// Type: AcpSecurityLib.KeyACLTypeConverter
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

public class KeyACLTypeConverter : IValueConverter
{
  public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
  {
    string str = (string) null;
    switch ((KeyAccessLevelType) value)
    {
      case KeyAccessLevelType.LIMITED_ACC:
        str = AcpResources.Limited_Id;
        break;
      case KeyAccessLevelType.UNLM_ACC:
      case KeyAccessLevelType.UNLM_ACC_WITHOUT_WP:
        str = AcpResources.Unlimited_Id;
        break;
    }
    return (object) str;
  }

  public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
  {
    throw new NotImplementedException();
  }
}
