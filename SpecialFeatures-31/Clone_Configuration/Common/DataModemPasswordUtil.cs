// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.Clone_Configuration.Common.DataModemPasswordUtil
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using AcpBusinessLayer;
using AcpCommonLib;
using Common;
using Motorola.MackinawCPS.CoreFeatures.DataWide;
using SpecialFeatures.AcpReportManagerLib;
using System;

#nullable disable
namespace SpecialFeatures.Clone_Configuration.Common;

public static class DataModemPasswordUtil
{
  private static string a;
  private static ClearAndRestorePassword b;

  public static void UpdateCipherPasswordsToPlain()
  {
    int A_1 = 5;
    short num1 = 1;
    if (num1 == (short) 0)
      ;
    int num2;
    switch (0)
    {
      case 0:
label_3:
        Motorola.MackinawCPS.CoreFeatures.DataWide.DataWide dataWide1 = FeatureManager.GetFeature(2028)[0] as Motorola.MackinawCPS.CoreFeatures.DataWide.DataWide;
        string str = AESCryptoUtil.AESDecryptWithDefKey_ForDataModemPassword(((AcpField<string>) dataWide1.ExternalDataModem.DataWideDataModemPassword_A42848).Value);
        ((AcpField<string>) dataWide1.ExternalDataModem.DataWideDataModemPassword_A42848).SetValue(string.Empty);
        DataModemPasswordUtil.a = str;
        num1 = (short) 1;
        num2 = (int) (IntPtr) num1;
        goto default;
      default:
        ExternalDataModem externalDataModem;
        while (true)
        {
          num1 = (short) 0;
          switch (num2)
          {
            case 0:
              goto label_6;
            case 1:
              if (!(FeatureManager.GetFeature(2028)[0] is Motorola.MackinawCPS.CoreFeatures.DataWide.DataWide dataWide2))
              {
                num1 = (short) 0;
                num2 = (int) (IntPtr) num1;
                continue;
              }
              externalDataModem = dataWide2.ExternalDataModem;
              if (externalDataModem == null)
              {
                num1 = (short) -29804;
                int num3 = (int) num1;
                num1 = (short) -29804;
                int num4 = (int) num1;
                switch (num3 == num4 ? 1 : 0)
                {
                  case 0:
                  case 2:
                    continue;
                  default:
                    num1 = (short) 0;
                    if (num1 == (short) 0)
                      ;
                    num1 = (short) 2;
                    num2 = (int) (IntPtr) num1;
                    continue;
                }
              }
              else
                goto label_12;
            case 2:
              goto label_11;
            default:
              goto label_3;
          }
        }
label_6:
        IAcpRecordset iacpRecordset = (IAcpRecordset) null;
        goto label_13;
label_11:
        iacpRecordset = (IAcpRecordset) null;
        goto label_13;
label_12:
        iacpRecordset = ((FeatureSection) externalDataModem).EmbeddedRecset;
label_13:
        DataModemPasswordUtil.b = new ClearAndRestorePassword(iacpRecordset as Recordset, RptMgrErrorHandler.b("첇\uEB89\uF88B\uEF8D잏ﮑ\uF093\uF395\uDD97\uF499ﾛ\uEC9D\uD99F튡킣쎥첧\uE7A9쎫쪭햯\uDFB1\uE4B3ힵ쮷즹쮻톽늿ꛁ鯃\uF2C5\uFBC7柳頋ￍ", A_1));
        DataModemPasswordUtil.b.ClearFieldsAndRemember(new Func<string, string>(AESCryptoUtil.AESDecryptWithDefKey_ForDataModemPassword));
        break;
    }
  }

  public static void RestorePlainPasswordToCipher()
  {
    if (false)
      ;
    short num1 = -30811;
    int num2 = (int) num1;
    num1 = (short) -30811;
    int num3 = (int) num1;
    switch (num2 == num3)
    {
      case true:
        num1 = (short) 0;
        if (num1 == (short) 0)
          ;
        ((AcpField<string>) (FeatureManager.GetFeature(2028)[0] as Motorola.MackinawCPS.CoreFeatures.DataWide.DataWide).ExternalDataModem.DataWideDataModemPassword_A42848).SetValue(AESCryptoUtil.AESEncryptWithDefKey_ForDataModemPassword(DataModemPasswordUtil.a).Substring(0, 66));
        DataModemPasswordUtil.b.RestorePasswordsAndForgot(new Func<string, string>(AESCryptoUtil.AESEncryptWithDefKey_ForDataModemPassword), 66);
        break;
      default:
        goto case 1;
    }
  }

  static DataModemPasswordUtil()
  {
    short num1 = 0;
    num1 = (short) -2722;
    int num2 = (int) num1;
    num1 = (short) -2722;
    int num3 = (int) num1;
    switch (num2 == num3)
    {
      case true:
        num1 = (short) 0;
        if (num1 == (short) 0)
          ;
        num1 = (short) 1;
        if (num1 == (short) 0)
          ;
        DataModemPasswordUtil.a = string.Empty;
        break;
      default:
        goto case 1;
    }
  }
}
