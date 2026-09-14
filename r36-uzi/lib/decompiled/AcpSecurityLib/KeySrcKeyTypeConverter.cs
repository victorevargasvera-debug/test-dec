// Decompiled with JetBrains decompiler
// Type: AcpSecurityLib.KeySrcKeyTypeConverter
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

public class KeySrcKeyTypeConverter : IMultiValueConverter
{
  public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
  {
    KeySource keySource = (KeySource) values[0];
    string str;
    switch ((KeyType) values[1])
    {
      case KeyType.ADVANCED_SYSTEM_KEY:
        switch (keySource)
        {
          case KeySource.HARDWARE:
            str = AcpResources.Advanced_System_Key;
            break;
          case KeySource.LEGACY_KEY_FILE:
            str = AcpResources.Legacy_Software_System_Key;
            break;
          default:
            str = AcpResources.Undefined_Id;
            break;
        }
        break;
      case KeyType.ADVANCED_WACN_KEY:
        str = AcpResources.Advanced_WACN_Key;
        break;
      case KeyType.ADVANCED_CONV_SYSTEM_KEY:
        str = AcpResources.Advanced_Conventional_Key;
        break;
      default:
        str = AcpResources.Undefined_Id;
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
