// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.Comms.SerialNumberValidator
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using SpecialFeatures.AcpReportManagerLib;
using System;
using System.Text;
using System.Text.RegularExpressions;

#nullable disable
namespace SpecialFeatures.Comms;

public static class SerialNumberValidator
{
  private static readonly byte[] a;
  internal const short SERIALNUMBERSIZE = 10;

  internal static bool IsCBISerialNumber(string serialNumber) => true;

  internal static bool ValidateSerialNumber(string serialNumber)
  {
    int A_1 = 2;
    int num1;
    bool flag;
    short num2;
    switch (0)
    {
      case 0:
label_2:
        flag = false;
        num2 = (short) 12;
        num1 = (int) (IntPtr) num2;
        goto default;
      default:
        while (true)
        {
          switch (num1)
          {
            case 0:
              goto label_26;
            case 1:
label_14:
              flag = true;
              num2 = (short) 1;
              if (num2 == (short) 0)
                ;
              num2 = (short) 2;
              num1 = (int) (IntPtr) num2;
              continue;
            case 2:
              goto label_3;
            case 3:
              num2 = (short) 7;
              num1 = (int) (IntPtr) num2;
              continue;
            case 4:
              num2 = (short) 8;
              num1 = (int) (IntPtr) num2;
              continue;
            case 5:
              if (new Regex(RptMgrErrorHandler.b("\uDE84랆ꒈ늊킌풎ꆐ뺒겔쪖슘ꮚ난ꚞﲠ\uF8A2閤誦邨\uEAAA肬\uF5AE鲰\uE8B2華\uEAB6\uE4B8\uE0BAﲼ銾鯀\uEEC2黄軆蛈雊郌铎郐ﻒ返𥳐苘鋚鋜苞볠룢헤쫦탨ꫪ샬뗮\uDCF0ꣲ보룶ꓸ\uA6FA\uA6FC쿾Ⰰ㨂䐄⨆匈☊嘌䘎帐丒䠔䰖⤘㘚␜帞ఠ礢ࠤ簦栨渪搬怮搰樲栴樶戸\u0B3Aြؾ@湂ὄ橆ቈ\u0A4AࡌَṐْ\u0C54\u0A56ј", A_1)).IsMatch(serialNumber))
              {
                num2 = (short) 6;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_26;
            case 6:
              flag = true;
              num2 = (short) 0;
              num1 = (int) (IntPtr) num2;
              continue;
            case 7:
              if (new Regex(RptMgrErrorHandler.b("\uDE84랆ꒈ늊킌풎ꆐ뺒겔쪖슘ꮚ난ꚞﲠ\uF8A2閤誦邨\uEAAA肬\uF5AE鲰\uE8B2華\uEAB6\uE4B8\uE0BAﲼ銾鯀\uEEC2黄軆蛈雊郌铎郐ﻒ返𥳐苘鋚鋜苞볠룢헤쫦탨ꫪ샬뗮\uDCF0ꣲ듴닶냸듺꣼\uA6FE尀市帄㜆␈㈊䰌∎䬐㸒且嘖尘刚刜䨞砠縢砤簦ᤨتᐬ渮ᰰ椲ᠴ氶砸縺琼瀾ᑀᩂᡄᩆቈ筊恌癎ၐ繒པ穖ɘᩚᡜᙞ\u2E60㙢㱤㩦㑨", A_1)).IsMatch(serialNumber))
              {
                num2 = (short) -5190;
                int num3 = (int) num2;
                num2 = (short) -5190;
                int num4 = (int) num2;
                switch (num3 == num4 ? 1 : 0)
                {
                  case 0:
                  case 2:
                    goto label_14;
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
                goto label_3;
            case 8:
              if (!char.IsUpper(serialNumber[8]))
              {
                num2 = (short) 9;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 3;
            case 9:
              num2 = (short) 10;
              num1 = (int) (IntPtr) num2;
              continue;
            case 10:
              if (!char.IsUpper(serialNumber[9]))
              {
                num2 = (short) 5;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              num2 = (short) 3;
              num1 = (int) (IntPtr) num2;
              continue;
            case 11:
              if (serialNumber.Length == 10)
              {
                num2 = (short) 4;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_26;
            case 12:
              try
              {
                serialNumber = Encoding.ASCII.GetString(Convert.FromBase64String(serialNumber));
              }
              catch (Exception ex)
              {
              }
              num2 = (short) 11;
              num1 = (int) (IntPtr) num2;
              continue;
            default:
              goto label_2;
          }
        }
label_3:
        num2 = (short) 0;
        return flag;
label_26:
        return flag;
    }
  }

  static SerialNumberValidator()
  {
    short num1 = 17910;
    int num2 = (int) num1;
    num1 = (short) 17910;
    int num3 = (int) num1;
    switch (num2 == num3)
    {
      case true:
        short num4 = 0;
        if (num4 == (short) 0)
          ;
        num4 = (short) 1;
        if (num4 == (short) 0)
          ;
        num4 = (short) 0;
        SerialNumberValidator.a = new byte[10]
        {
          (byte) 200,
          (byte) 212,
          (byte) 221,
          (byte) 157,
          (byte) 162,
          (byte) 204,
          (byte) 132,
          (byte) 209,
          (byte) 157,
          (byte) 175
        };
        break;
      default:
        goto case 1;
    }
  }
}
