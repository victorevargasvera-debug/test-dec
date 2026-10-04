// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.Clone_Configuration.Common.PINPasswordUtil
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using AcpBusinessLayer;
using AcpCommonLib;
using Common;
using Motorola.MackinawCPS.CoreFeatures.RadioWide;
using SpecialFeatures.Comms;
using System;

#nullable disable
namespace SpecialFeatures.Clone_Configuration.Common;

public class PINPasswordUtil
{
  public static void UpdatePINPasswordFromRadio(RadioIdInfo tempRadioIds)
  {
    int num1 = 0;
    switch (num1)
    {
      default:
        Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide radioWide;
        short num2;
        switch (0)
        {
          case 0:
label_3:
            radioWide = ((Recordset) (FeatureManager.GetFeature(2045) as RadioWideRecset))[0] as Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide;
            string empty = string.Empty;
            num2 = (short) 4;
            num1 = (int) (IntPtr) num2;
            goto default;
          default:
            while (true)
            {
              string str1;
              string str2;
              switch (num1)
              {
                case 0:
                  num2 = (short) 8;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 1:
                  goto label_19;
                case 2:
                  goto label_11;
                case 3:
                  if (str1.Length > 4)
                  {
                    num2 = (short) 9;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 12;
                case 4:
                  if (tempRadioIds.IsEncryptedPwd)
                  {
                    num2 = (short) 0;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 11;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 5:
                  if (tempRadioIds.SoftIds[2] == null)
                  {
                    num2 = (short) 0;
                    str2 = "";
                    num2 = (short) 7;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) -136;
                  int num3 = (int) num2;
                  num2 = (short) -136;
                  int num4 = (int) num2;
                  switch (num3 == num4 ? 1 : 0)
                  {
                    case 0:
                    case 2:
                      break;
                    default:
                      num2 = (short) 0;
                      if (num2 == (short) 0)
                        ;
                      num2 = (short) 6;
                      num1 = (int) (IntPtr) num2;
                      continue;
                  }
                  break;
                case 6:
                  num2 = (short) 1;
                  if (num2 == (short) 0)
                    ;
                  str2 = PINPasswordUtil.a(tempRadioIds.SoftIds[2]);
                  num2 = (short) 13;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 7:
                case 13:
                  num2 = (short) 3;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 8:
                  if (!string.IsNullOrEmpty(tempRadioIds.EncryptedPwd))
                  {
                    num2 = (short) 2;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_29;
                case 9:
                  str1 = str1.Substring(0, 4);
                  break;
                case 10:
                  goto label_23;
                case 11:
                  if (tempRadioIds.IsManagedUpgrade)
                  {
                    num2 = (short) 1;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  str1 = PINPasswordUtil.a(tempRadioIds.SoftIds[1]);
                  num2 = (short) 5;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 12:
                  string str3 = AESCryptoUtil.AESEncryptWithDefKey(str1 + str2);
                  ((AcpField<string>) radioWide.UserInformationAndPasswords.RadWideUserInformationandPINPassword_41303).SetValue(str3);
                  num2 = (short) 10;
                  num1 = (int) (IntPtr) num2;
                  continue;
                default:
                  goto label_3;
              }
              num2 = (short) 12;
              num1 = (int) (IntPtr) num2;
            }
label_23:
            return;
label_11:
            ((AcpField<string>) radioWide.UserInformationAndPasswords.RadWideUserInformationandPINPassword_41303).SetValue(tempRadioIds.EncryptedPwd);
            return;
label_29:
            return;
label_19:
            PINPasswordUtil.UpdatePasswordsToClear(tempRadioIds.EncryptedPwd);
            return;
        }
    }
  }

  private static string a(string A_0)
  {
    int num1;
    short num2;
    int length;
    switch (0)
    {
      case 0:
label_2:
        num2 = (short) 1;
        if (num2 == (short) 0)
          ;
        num2 = (short) 0;
        length = A_0.IndexOf(char.MinValue);
        break;
      default:
        while (true)
        {
          switch (num1)
          {
            case 0:
              A_0 = "";
              num2 = (short) -10981;
              int num3 = (int) num2;
              num2 = (short) -10981;
              int num4 = (int) num2;
              switch (num3 == num4 ? 1 : 0)
              {
                case 0:
                case 2:
                  goto label_4;
                default:
                  num2 = (short) 0;
                  if (num2 == (short) 0)
                    ;
                  num2 = (short) 4;
                  num1 = (int) (IntPtr) num2;
                  continue;
              }
            case 1:
              if (length == 0)
              {
                num2 = (short) 0;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              num2 = (short) 3;
              num1 = (int) (IntPtr) num2;
              continue;
            case 2:
              A_0 = A_0.Substring(0, length);
              num2 = (short) 5;
              num1 = (int) (IntPtr) num2;
              continue;
            case 3:
              if (length > 0)
              {
                num2 = (short) 2;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_14;
            case 4:
            case 5:
              goto label_14;
            default:
              goto label_2;
          }
label_1:;
        }
label_14:
        return A_0;
    }
label_4:
    num2 = (short) 1;
    num1 = (int) (IntPtr) num2;
    goto label_1;
  }

  public static string UpdatePasswordsToClear(string encryptedPswd = null)
  {
    int num1 = 0;
    switch (num1)
    {
      default:
        short num2;
        Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide radioWide;
        switch (0)
        {
          case 0:
label_3:
            num2 = (short) 1;
            if (num2 == (short) 0)
              ;
            radioWide = FeatureManager.GetFeature(2045)[0] as Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide;
            num2 = (short) 0;
            num1 = (int) (IntPtr) num2;
            goto default;
          default:
            while (true)
            {
              num2 = (short) 0;
              switch (num1)
              {
                case 0:
                  if (encryptedPswd == null)
                    goto label_10;
                  break;
                case 1:
                  num2 = (short) 12666;
                  int num3 = (int) num2;
                  num2 = (short) 12666;
                  int num4 = (int) num2;
                  switch (num3 == num4 ? 1 : 0)
                  {
                    case 0:
                    case 2:
                      break;
                    default:
                      num2 = (short) 0;
                      if (num2 == (short) 0)
                        goto label_10;
                      goto label_10;
                  }
                  break;
                case 2:
                  goto label_11;
                case 3:
                  ((AcpField<string>) radioWide.UserInformationAndPasswords.RadWideUserInformationandPINPassword_41303).SetValue(encryptedPswd);
                  num2 = (short) 1;
                  num1 = (int) (IntPtr) num2;
                  continue;
                default:
                  goto label_3;
              }
              num2 = (short) 3;
              num1 = (int) (IntPtr) num2;
              continue;
label_10:
              num2 = (short) 2;
              num1 = (int) (IntPtr) num2;
            }
label_11:
            string clear = ((AcpField<string>) radioWide.UserInformationAndPasswords.RadWideUserInformationandPINPassword_41303).Value;
            string empty1 = string.Empty;
            string empty2 = string.Empty;
            string str1 = string.Empty;
            string str2 = AESCryptoUtil.AESDecryptWithDefKey(clear);
            string str3;
            if (str2.Length > 4)
            {
              str3 = str2.Substring(0, 4);
              str1 = str2.Substring(4);
            }
            else
              str3 = str2;
            radioWide.Labtool.RadWideLabtoolEncryptPassword_A41695.SetValue(false);
            radioWide.UserInformationAndPasswords.RadWideUserInformationandPasswordsPIN_A8705.SetValue(str3);
            radioWide.UserInformationAndPasswords.RadWideUserInformationandPINPasswordPart2_41304.SetValue(str1);
            radioWide.Labtool.RadWideLabtoolEncryptedPINPassword_A41702.SetValue(string.Empty);
            return clear;
        }
    }
  }

  public static void RestorePasswordsBackEncrypt(string originalPwd)
  {
    short num1 = 12639;
    int num2 = (int) num1;
    num1 = (short) 12639;
    int num3 = (int) num1;
    switch (num2 == num3)
    {
      case true:
        num1 = (short) 1;
        if (num1 == (short) 0)
          ;
        num1 = (short) 0;
        if (num1 == (short) 0)
          ;
        Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide radioWide = FeatureManager.GetFeature(2045)[0] as Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide;
        radioWide.Labtool.RadWideLabtoolEncryptPassword_A41695.SetValue(true);
        radioWide.Labtool.RadWideLabtoolEncryptedPINPassword_A41702.SetValue(originalPwd);
        radioWide.UserInformationAndPasswords.RadWideUserInformationandPasswordsPIN_A8705.SetValue(string.Empty);
        radioWide.UserInformationAndPasswords.RadWideUserInformationandPINPasswordPart2_41304.SetValue(string.Empty);
        break;
      default:
        goto case 1;
    }
  }
}
