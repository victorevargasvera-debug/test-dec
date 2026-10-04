// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.CloneWizard.SerialNumberValidMultiConverter
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using SpecialFeatures.Comms;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Data;

#nullable disable
namespace SpecialFeatures.CloneWizard;

public class SerialNumberValidMultiConverter : IMultiValueConverter
{
  public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
  {
    short num1;
    int num2;
    bool flag;
    switch (0)
    {
      case 0:
label_3:
        flag = false;
        num1 = (short) 10;
        num2 = (int) (IntPtr) num1;
        goto default;
      default:
        while (true)
        {
          num1 = (short) 1;
          if (num1 == (short) 0)
            ;
          object s;
          switch (num2)
          {
            case 0:
              if (values[0] != DependencyProperty.UnsetValue)
              {
                num1 = (short) 3;
                num2 = (int) (IntPtr) num1;
                continue;
              }
              goto label_24;
            case 1:
              num1 = (short) 7165;
              int num3 = (int) num1;
              num1 = (short) 7165;
              int num4 = (int) num1;
              switch (num3 == num4 ? 1 : 0)
              {
                case 0:
                case 2:
                  break;
                case 1:
                  goto label_16;
                default:
                  goto label_15;
              }
              break;
            case 2:
              goto label_6;
            case 3:
              num1 = (short) 9;
              num2 = (int) (IntPtr) num1;
              continue;
            case 4:
              num1 = (short) 7;
              num2 = (int) (IntPtr) num1;
              continue;
            case 5:
              flag = SerialNumberValidator.ValidateSerialNumber(System.Convert.ToBase64String(Encoding.ASCII.GetBytes((string) s)));
              num1 = (short) 1;
              num2 = (int) (IntPtr) num1;
              continue;
            case 6:
              if (s != null)
              {
                num1 = (short) 5;
                num2 = (int) (IntPtr) num1;
                continue;
              }
              goto label_24;
            case 7:
              if (!(bool) values[0])
              {
                num1 = (short) 2;
                num2 = (int) (IntPtr) num1;
                continue;
              }
              break;
            case 8:
              goto label_17;
            case 9:
              if (values[1] != DependencyProperty.UnsetValue)
              {
                num1 = (short) 4;
                num2 = (int) (IntPtr) num1;
                continue;
              }
              goto label_24;
            case 10:
              if ((bool) DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof (DependencyObject)).DefaultValue)
              {
                num1 = (short) 8;
                num2 = (int) (IntPtr) num1;
                continue;
              }
              num1 = (short) 0;
              num2 = (int) (IntPtr) num1;
              continue;
            default:
              goto label_3;
          }
          s = values[1];
          num1 = (short) 6;
          num2 = (int) (IntPtr) num1;
        }
label_6:
        return (object) true;
label_15:
        num1 = (short) 0;
label_16:
        num1 = (short) 0;
        if (num1 == (short) 0)
          goto label_24;
        goto label_24;
label_17:
        return (object) false;
label_24:
        return (object) flag;
    }
  }

  public object[] ConvertBack(
    object value,
    Type[] targetType,
    object parameter,
    CultureInfo culture)
  {
    short num1 = -28324;
    int num2 = (int) num1;
    num1 = (short) -28324;
    int num3 = (int) num1;
    short num4;
    switch (num2 == num3)
    {
      case true:
        num4 = (short) 1;
        if (num4 == (short) 0)
          ;
        num4 = (short) 0;
        if (num4 == (short) 0)
          ;
        return (object[]) null;
      default:
        num4 = (short) 0;
        goto case 1;
    }
  }
}
