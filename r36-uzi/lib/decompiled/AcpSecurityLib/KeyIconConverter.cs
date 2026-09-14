// Decompiled with JetBrains decompiler
// Type: AcpSecurityLib.KeyIconConverter
// Assembly: AcpSecurityLib, Version=23.1.0.23, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 41EFF54A-68D7-40EA-A234-214D6B602874
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpSecurityLib.dll

using AcpASKLib;
using System;
using System.Globalization;
using System.Windows.Data;

#nullable disable
namespace AcpSecurityLib;

public class KeyIconConverter : IValueConverter
{
  public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
  {
    string str = "../../icons/ibutton.png";
    switch ((KeySource) value)
    {
      case KeySource.HARDWARE:
        str = "../../icons/ibutton.png";
        break;
      case KeySource.LEGACY_KEY_FILE:
        str = "../../icons/softwareKey.png";
        break;
    }
    return (object) str;
  }

  public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
  {
    throw new NotImplementedException();
  }
}
