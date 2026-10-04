// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.CBISerialNum.SerialNumberRule
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using CommonResources;
using SpecialFeatures.Comms;
using System;
using System.Globalization;
using System.Text;
using System.Windows.Controls;

#nullable disable
namespace SpecialFeatures.CBISerialNum;

public class SerialNumberRule : ValidationRule
{
  public override ValidationResult Validate(object value, CultureInfo cultureInfo)
  {
    int num1 = 3;
    short num2;
    while (true)
    {
      string s;
      switch (num1)
      {
        case 0:
          s = (string) value;
          num2 = (short) 2;
          num1 = (int) (IntPtr) num2;
          continue;
        case 1:
          goto label_6;
        case 2:
          if (SerialNumberValidator.ValidateSerialNumber(Convert.ToBase64String(Encoding.ASCII.GetBytes(s))))
          {
            num2 = (short) 22602;
            int num3 = (int) num2;
            num2 = (short) 22602;
            int num4 = (int) num2;
            switch (num3 == num4 ? 1 : 0)
            {
              case 0:
              case 2:
                continue;
              default:
                num2 = (short) 0;
                if (num2 == (short) 0)
                  ;
                num2 = (short) 1;
                num1 = (int) (IntPtr) num2;
                continue;
            }
          }
          else
            goto label_5;
        case 3:
          switch (0)
          {
            case 0:
              break;
            default:
              continue;
          }
          break;
      }
      num2 = (short) 0;
      if (value != null)
      {
        num2 = (short) 0;
        num1 = (int) (IntPtr) num2;
      }
      else
        goto label_12;
    }
label_5:
    return new ValidationResult(false, (object) AppResources.Enter_Valid_Serial_Number);
label_6:
    return new ValidationResult(true, (object) null);
label_12:
    num2 = (short) 1;
    if (num2 == (short) 0)
      ;
    return new ValidationResult(false, (object) AppResources.Enter_Valid_Serial_Number);
  }
}
