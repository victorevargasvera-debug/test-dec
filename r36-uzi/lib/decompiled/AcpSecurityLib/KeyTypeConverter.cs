// Decompiled with JetBrains decompiler
// Type: AcpSecurityLib.KeyTypeConverter
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

public class KeyTypeConverter : IValueConverter
{
  public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
  {
    string str;
    switch ((KeyType) value)
    {
      case KeyType.ADVANCED_SYSTEM_KEY:
        str = AcpResources.Advanced_Trunking_System;
        break;
      case KeyType.ADVANCED_WACN_KEY:
        str = AcpResources.Advanced_WACN_System;
        break;
      case KeyType.ADVANCED_CONV_SYSTEM_KEY:
        str = AcpResources.Advanced_Conventional_System;
        break;
      default:
        str = AcpResources.Undefined_Id;
        break;
    }
    return (object) str;
  }

  public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
  {
    string str = (string) value;
    return (object) (KeyType) (!(str == AcpResources.Advanced_Conventional_System) ? (!(str == AcpResources.Advanced_Trunking_System) ? (!(str == AcpResources.Advanced_WACN_System) ? 254 : 1) : 0) : 2);
  }
}
