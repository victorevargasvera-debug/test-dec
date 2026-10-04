// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.CloneWizard.SetCloneBtnLblConverter
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using CommonResources;
using System;
using System.Globalization;
using System.Windows.Data;

#nullable disable
namespace SpecialFeatures.CloneWizard;

public class SetCloneBtnLblConverter : IValueConverter
{
  public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
  {
    short num1 = 25562;
    int num2 = (int) num1;
    num1 = (short) 25562;
    int num3 = (int) num1;
    short num4;
    int num5;
    switch (num2 == num3 ? 1 : 0)
    {
      case 0:
      case 2:
label_5:
        if (value is bool?)
        {
          num4 = (short) 3;
          num5 = (int) (IntPtr) num4;
          break;
        }
        goto label_10;
      default:
        num4 = (short) 0;
        if (num4 == (short) 0)
          ;
        switch (0)
        {
          case 0:
            goto label_4;
        }
        break;
    }
    bool? nullable1;
    while (true)
    {
      bool? nullable2;
      bool flag;
      switch (num5)
      {
        case 0:
          if (nullable2.GetValueOrDefault() == flag & nullable2.HasValue)
          {
            num4 = (short) 2;
            num5 = (int) (IntPtr) num4;
            continue;
          }
          goto label_16;
        case 1:
          if (nullable1.HasValue)
          {
            num4 = (short) 5;
            num5 = (int) (IntPtr) num4;
            continue;
          }
          goto label_15;
        case 2:
          goto label_15;
        case 3:
          nullable1 = value as bool?;
          num4 = (short) 4;
          num5 = (int) (IntPtr) num4;
          continue;
        case 4:
          goto label_14;
        case 5:
          nullable2 = nullable1;
          flag = true;
          num4 = (short) 0;
          num5 = (int) (IntPtr) num4;
          continue;
        case 6:
          goto label_5;
        default:
          goto label_4;
      }
label_3:;
    }
label_14:
    num4 = (short) 0;
    num4 = (short) 1;
    if (num4 == (short) 0)
      goto label_10;
    goto label_10;
label_15:
    return (object) AppResources.Save_As;
label_16:
    return (object) AppResources.Clone_Id;
label_4:
    nullable1 = new bool?(true);
    num4 = (short) 6;
    num5 = (int) (IntPtr) num4;
    goto label_3;
label_10:
    num4 = (short) 1;
    num5 = (int) (IntPtr) num4;
    goto label_3;
  }

  public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
  {
    short num1 = 13305;
    int num2 = (int) num1;
    num1 = (short) 13305;
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
        return (object) null;
      default:
        num4 = (short) 0;
        goto case 1;
    }
  }
}
