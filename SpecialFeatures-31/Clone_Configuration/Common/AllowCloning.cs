// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.Clone_Configuration.Common.AllowCloning
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using AcpBusinessLayer;
using AcpCommonLib;
using AcpUtility;
using CommonResources;
using ConstraintHelper;
using Motorola.CommonCPS.Server.CommonDBConstants;
using Motorola.CommonCPS.Server.EntityModel;
using Motorola.MackinawCPS.CoreFeatures.ASTROTalkgroupList;
using Motorola.MackinawCPS.CoreFeatures.ConventionalSystem;
using Motorola.MackinawCPS.CoreFeatures.RadioProfiles;
using Motorola.MackinawCPS.CoreFeatures.SecureKMFProfile;
using Motorola.MackinawCPS.CoreFeatures.SecureWide;
using Motorola.MackinawCPS.CoreFeatures.TrunkingPersonality;
using Motorola.MackinawCPS.CoreFeatures.TrunkingSystem;
using Motorola.MackinawCPS.CoreFeatures.ZoneChannelAssignment;
using SpecialFeatures.AcpReportManagerLib;
using SpecialFeatures.Flashport.FlashRadio;
using SpecialFeatures.Model_Configuration;
using SpecialFeatures.Ucl.Contact;
using SpecialFeatures.VoiceAnnouncements.List;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

#nullable disable
namespace SpecialFeatures.Clone_Configuration.Common;

public static class AllowCloning
{
  public static bool AllowClone(
    CodeplugData srcData,
    CodeplugData targetData,
    bool isPortable,
    ref string stsErrorMsg)
  {
    int num1 = 0;
    switch (num1)
    {
      default:
        bool flag;
        short num2;
        switch (0)
        {
          case 0:
label_3:
            flag = false;
            num2 = (short) 21;
            num1 = (int) (IntPtr) num2;
            goto default;
          default:
            while (true)
            {
              FlashcodeTable flashcodeTable1;
              BitArray bitArray1;
              int index;
              byte[] bytes;
              byte[] decoded;
              switch (num1)
              {
                case 0:
                  num2 = (short) 17;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 1:
                  num2 = (short) 11;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 2:
                case 16 /*0x10*/:
                case 17:
                  goto label_75;
                case 3:
                case 18:
                  num2 = (short) 4;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 4:
                  num2 = (short) 0;
                  if (index >= 24)
                  {
                    num2 = (short) 0;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 15;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 5:
                  bytes = new byte[25];
                  FlashcodeDecoder.Decode(srcData.usedFlashcode, ref bytes);
                  decoded = new byte[25];
                  FlashcodeDecoder.Decode(targetData.purchasedFlashcode, ref decoded);
                  flag = AllowCloning.AllowCloneSpecialCases(srcData, targetData, ref bytes, isPortable, ref stsErrorMsg);
                  num2 = (short) 20;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 6:
                  num2 = (short) 14;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 7:
                  index = 0;
                  num2 = (short) 18;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 8:
                  num2 = (short) 19;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 9:
                  if (srcData.usedFlashcode != targetData.purchasedFlashcode)
                  {
                    num2 = (short) 5;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  break;
                case 10:
                  BitArray bitArray2 = new BitArray(bytes);
                  BitArray bitArray3 = new BitArray(decoded);
                  BitArray bitArray4 = bitArray3;
                  bitArray1 = bitArray2.Or(bitArray4).Xor(bitArray3);
                  flashcodeTable1 = (FlashcodeTable) null;
                  num2 = (short) 12;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 11:
                  if (srcData.purchasedFlashcode != targetData.purchasedFlashcode)
                  {
                    num2 = (short) 13;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  break;
                case 12:
                  try
                  {
                    num2 = (short) 4;
                    int num3 = (int) (IntPtr) num2;
                    int bytePos;
                    int bitPos;
                    IEnumerator enumerator;
                    while (true)
                    {
                      FlashcodeTable flashcodeTable2;
                      switch (num3)
                      {
                        case 0:
                          flashcodeTable2 = new FlashcodeTable();
                          break;
                        case 1:
                          num2 = (short) 2;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 2:
                          flashcodeTable2 = new FlashcodeTable(isPortable, false);
                          break;
                        case 3:
                          goto label_14;
                        case 4:
                          switch (0)
                          {
                            case 0:
                              goto label_10;
                            default:
                              continue;
                          }
                        default:
label_10:
                          if (srcData._data != null)
                          {
                            num2 = (short) 1;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 0;
                          num3 = (int) (IntPtr) num2;
                          continue;
                      }
                      flashcodeTable1 = flashcodeTable2;
                      string empty = string.Empty;
                      flashcodeTable1.InitTable(srcData._data == null, srcData.modelNumber);
                      bitPos = 0;
                      bytePos = 1;
                      stsErrorMsg = AppResources.Failure_due_to_mismatch_of_Codeplug_Used_FLASHcode_and_Radio_FLASHcode;
                      enumerator = bitArray1.GetEnumerator();
                      num2 = (short) 3;
                      num3 = (int) (IntPtr) num2;
                    }
label_14:
                    try
                    {
                      num2 = (short) 9;
                      num3 = (int) (IntPtr) num2;
                      while (true)
                      {
                        switch (num3)
                        {
                          case 0:
                            if ((bool) enumerator.Current)
                            {
                              num2 = (short) 5;
                              num3 = (int) (IntPtr) num2;
                              continue;
                            }
                            goto case 2;
                          case 1:
                            if (bitPos == 8)
                            {
                              num2 = (short) 8;
                              num3 = (int) (IntPtr) num2;
                              continue;
                            }
                            break;
                          case 2:
                            ++bitPos;
                            num2 = (short) 1;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          case 4:
                            goto label_6;
                          case 5:
                            string optionsInOffset = flashcodeTable1.GetOptionsInOffset(bytePos, bitPos);
                            stsErrorMsg += optionsInOffset;
                            num2 = (short) 2;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          case 6:
                            num2 = (short) 4;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          case 7:
                            if (enumerator.MoveNext())
                            {
                              num2 = (short) 0;
                              num3 = (int) (IntPtr) num2;
                              continue;
                            }
                            num2 = (short) 6;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          case 8:
                            bitPos = 0;
                            ++bytePos;
                            num2 = (short) 3;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          case 9:
                            switch (0)
                            {
                              case 0:
                                break;
                              default:
                                continue;
                            }
                            break;
                        }
                        num2 = (short) 7;
                        num3 = (int) (IntPtr) num2;
                      }
                    }
                    finally
                    {
                      IDisposable disposable;
                      switch (0)
                      {
                        case 0:
label_31:
                          disposable = enumerator as IDisposable;
                          num3 = 0;
                          goto default;
                        default:
                          while (true)
                          {
                            switch (num3)
                            {
                              case 0:
                                if (disposable != null)
                                {
                                  num3 = 2;
                                  continue;
                                }
                                goto label_35;
                              case 1:
                                goto label_35;
                              case 2:
                                disposable.Dispose();
                                num3 = 1;
                                continue;
                              default:
                                goto label_31;
                            }
                          }
label_35:;
                      }
                    }
                  }
                  finally
                  {
                    short num4 = 0;
                    int num5 = (int) (IntPtr) num4;
                    while (true)
                    {
                      switch (num5)
                      {
                        case 0:
                          switch (0)
                          {
                            case 0:
                              break;
                            default:
                              continue;
                          }
                          break;
                        case 1:
                          goto label_45;
                        case 2:
                          flashcodeTable1.Dispose();
                          flashcodeTable1 = (FlashcodeTable) null;
                          num4 = (short) 1;
                          num5 = (int) (IntPtr) num4;
                          continue;
                      }
                      if (flashcodeTable1 != null)
                      {
                        num4 = (short) 2;
                        num5 = (int) (IntPtr) num4;
                      }
                      else
                        break;
                    }
label_45:;
                  }
label_6:
                  flag = false;
                  num1 = 16 /*0x10*/;
                  continue;
                case 13:
                  num2 = (short) 9;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 14:
                  if (FlashcodeValidator.Validate(targetData.purchasedFlashcode))
                  {
                    num2 = (short) 1;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_75;
                case 15:
                  if (((int) bytes[index] | (int) decoded[index]) == (int) decoded[index])
                  {
                    ++index;
                    num2 = (short) 3;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_60;
                case 19:
                  num2 = (short) 1;
                  if (num2 == (short) 0)
                    ;
                  if (FlashcodeValidator.Validate(srcData.usedFlashcode))
                  {
                    num2 = (short) 6;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_75;
                case 20:
                  if (flag)
                  {
                    num2 = (short) 7;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_75;
                case 21:
                  if (FlashcodeValidator.Validate(srcData.purchasedFlashcode))
                  {
                    num2 = (short) 8;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_75;
                default:
                  goto label_3;
              }
              num2 = (short) 472;
              int num6 = (int) num2;
              num2 = (short) 472;
              int num7 = (int) num2;
              switch (num6 == num7 ? 1 : 0)
              {
                case 0:
                case 2:
                  break;
                default:
                  num2 = (short) 0;
                  if (num2 == (short) 0)
                    ;
                  flag = true;
                  num2 = (short) 2;
                  num1 = (int) (IntPtr) num2;
                  continue;
              }
label_60:
              num2 = (short) 10;
              num1 = (int) (IntPtr) num2;
            }
label_75:
            return flag;
        }
    }
  }

  public static bool ModelNumberCheck(
    string sourceModel,
    string targetModel,
    bool isPortable,
    ref string stsErrorMsg)
  {
    int num1;
    bool flag;
    string str1;
    string str2;
    short num2;
    switch (0)
    {
      case 0:
label_2:
        flag = true;
        str1 = sourceModel.Trim();
        str2 = targetModel.Trim();
        break;
      default:
        while (true)
        {
          switch (num1)
          {
            case 0:
            case 8:
            case 18:
              num2 = (short) 12;
              num1 = (int) (IntPtr) num2;
              continue;
            case 1:
              num2 = (short) 13;
              num1 = (int) (IntPtr) num2;
              continue;
            case 2:
              if (string.Compare(str1, 0, str2, 0, 3) == 0)
              {
                num2 = (short) 3;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              num2 = (short) 5;
              num1 = (int) (IntPtr) num2;
              continue;
            case 3:
              if (!AllowCloning.IsModelHighPower(str1))
              {
                num2 = (short) 6;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 1;
            case 4:
              flag = false;
              num2 = (short) 18;
              num1 = (int) (IntPtr) num2;
              continue;
            case 5:
              flag = false;
              num2 = (short) 0;
              num1 = (int) (IntPtr) num2;
              continue;
            case 6:
              num2 = (short) 10;
              num1 = (int) (IntPtr) num2;
              continue;
            case 7:
              num2 = (short) 14;
              num1 = (int) (IntPtr) num2;
              continue;
            case 9:
              stsErrorMsg = AppResources.Unable_to_clone_due_to_the_incompatibility_between_source_and_models;
              num2 = (short) 17;
              num1 = (int) (IntPtr) num2;
              continue;
            case 10:
              num2 = (short) 0;
              if (!AllowCloning.IsModelHighPower(str2))
              {
                num2 = (short) 1;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 4;
            case 11:
              if (str1 != str2)
              {
                num2 = (short) 7;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 0;
            case 12:
              if (!flag)
              {
                num2 = (short) 9;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_34;
            case 13:
              if (AllowCloning.IsModelHighPower(str1))
              {
                num2 = (short) 16 /*0x10*/;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 0;
            case 14:
              if (isPortable)
              {
                num2 = (short) 19;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              num2 = (short) 2;
              num1 = (int) (IntPtr) num2;
              continue;
            case 15:
              if (!AllowCloning.IsModelHighPower(str2))
              {
                num2 = (short) 4;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 0;
            case 16 /*0x10*/:
              num2 = (short) 1;
              if (num2 == (short) 0)
                ;
              num2 = (short) 15;
              num1 = (int) (IntPtr) num2;
              continue;
            case 17:
              goto label_34;
            case 19:
              flag = false;
              num2 = (short) 22010;
              int num3 = (int) num2;
              num2 = (short) 22010;
              int num4 = (int) num2;
              switch (num3 == num4 ? 1 : 0)
              {
                case 0:
                case 2:
                  goto label_3;
                default:
                  num2 = (short) 0;
                  if (num2 == (short) 0)
                    ;
                  num2 = (short) 8;
                  num1 = (int) (IntPtr) num2;
                  continue;
              }
            default:
              goto label_2;
          }
label_1:;
        }
label_34:
        return flag;
    }
label_3:
    num2 = (short) 11;
    num1 = (int) (IntPtr) num2;
    goto label_1;
  }

  public static bool IsModelDualBand(string modelNumber)
  {
    int num1;
    bool flag;
    short num2;
    switch (0)
    {
      case 0:
label_2:
        flag = false;
        num2 = (short) 1;
        num1 = (int) (IntPtr) num2;
        goto default;
      default:
        while (true)
        {
          switch (num1)
          {
            case 0:
              goto label_10;
            case 1:
              if (modelNumber.Trim()[3] == 'T')
              {
                num2 = (short) -7374;
                int num3 = (int) num2;
                num2 = (short) -7374;
                int num4 = (int) num2;
                switch (num3 == num4 ? 1 : 0)
                {
                  case 0:
                  case 2:
                    break;
                  default:
                    num2 = (short) 1;
                    if (num2 == (short) 0)
                      ;
                    num2 = (short) 0;
                    if (num2 == (short) 0)
                      ;
                    num2 = (short) 0;
                    num2 = (short) 2;
                    num1 = (int) (IntPtr) num2;
                    continue;
                }
              }
              else
                goto label_10;
              break;
            case 2:
              flag = true;
              break;
            default:
              goto label_2;
          }
          num2 = (short) 0;
          num1 = (int) (IntPtr) num2;
        }
label_10:
        return flag;
    }
  }

  public static bool IsModelSingleBand(string modelNumber)
  {
    int num1;
    bool flag;
    short num2;
    switch (0)
    {
      case 0:
label_2:
        flag = false;
        num2 = (short) 1;
        num1 = (int) (IntPtr) num2;
        goto default;
      default:
        while (true)
        {
          switch (num1)
          {
            case 0:
              goto label_9;
            case 1:
              if (modelNumber.Trim()[3] != 'T')
              {
                num2 = (short) -15564;
                int num3 = (int) num2;
                num2 = (short) -15564;
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
                    num2 = (short) 2;
                    num1 = (int) (IntPtr) num2;
                    continue;
                }
              }
              else
                goto label_10;
              break;
            case 2:
              num2 = (short) 0;
              flag = true;
              break;
            default:
              goto label_2;
          }
          num2 = (short) 0;
          num1 = (int) (IntPtr) num2;
        }
label_9:
        num2 = (short) 1;
        if (num2 == (short) 0)
          ;
label_10:
        return flag;
    }
  }

  public static bool IsModelHighPower(string modelNumber)
  {
    short num1;
    int num2;
    bool flag;
    string str;
    switch (0)
    {
      case 0:
label_2:
        flag = false;
        str = modelNumber.Trim();
        num1 = (short) 3;
        num2 = (int) (IntPtr) num1;
        goto default;
      default:
        while (true)
        {
          num1 = (short) 0;
          switch (num2)
          {
            case 0:
              num1 = (short) -28795;
              int num3 = (int) num1;
              num1 = (short) -28795;
              int num4 = (int) num1;
              switch (num3 == num4 ? 1 : 0)
              {
                case 0:
                case 2:
                  break;
                default:
                  goto label_8;
              }
              break;
            case 1:
              flag = true;
              num1 = (short) 0;
              num2 = (int) (IntPtr) num1;
              continue;
            case 2:
              if (str[4] != 'T')
                goto label_12;
              break;
            case 3:
              if (str[4] != 'X')
              {
                num1 = (short) 4;
                num2 = (int) (IntPtr) num1;
                continue;
              }
              goto case 1;
            case 4:
              num1 = (short) 1;
              if (num1 == (short) 0)
                ;
              num1 = (short) 2;
              num2 = (int) (IntPtr) num1;
              continue;
            default:
              goto label_2;
          }
          num1 = (short) 1;
          num2 = (int) (IntPtr) num1;
        }
label_8:
        num1 = (short) 0;
        if (num1 == (short) 0)
          ;
label_12:
        return flag;
    }
  }

  public static bool AllowCloneSpecialCases(
    CodeplugData srcData,
    CodeplugData targetData,
    ref byte[] srcUsedBytes,
    bool isPortable,
    ref string stsErrorMsg)
  {
    int A_1 = 9;
    int num1 = 0;
    switch (num1)
    {
      default:
        bool flag1;
        bool flag2;
        int num2;
        int index1;
        bool flag3;
        int num3;
        int index2;
        bool flag4;
        bool flag5;
        int num4;
        int num5;
        int index3;
        int index4;
        bool flag6;
        bool flag7;
        int num6;
        int num7;
        int index5;
        int index6;
        int num8;
        int index7;
        bool flag8;
        bool flag9;
        int num9;
        int index8;
        bool flag10;
        int num10;
        int index9;
        bool flag11;
        int index10;
        int num11;
        string name1;
        string str1;
        string str2;
        string str3;
        string str4;
        string str5;
        string str6;
        string name2;
        string name3;
        short num12;
        switch (0)
        {
          case 0:
label_3:
            flag1 = false;
            flag2 = false;
            num2 = -1;
            index1 = -1;
            flag3 = false;
            num3 = -1;
            index2 = -1;
            flag4 = false;
            flag5 = false;
            num4 = -1;
            num5 = -1;
            index3 = -1;
            index4 = -1;
            flag6 = false;
            flag7 = false;
            num6 = -1;
            num7 = -1;
            index5 = -1;
            index6 = -1;
            num8 = -1;
            index7 = -1;
            flag8 = false;
            flag9 = false;
            num9 = -1;
            index8 = -1;
            flag10 = false;
            num10 = -1;
            index9 = -1;
            flag11 = false;
            index10 = -1;
            num11 = -1;
            name1 = RptMgrErrorHandler.b("쒋붍ꢏ", A_1);
            str1 = RptMgrErrorHandler.b("쒋붍ꞏ", A_1);
            str2 = RptMgrErrorHandler.b("\uDD8B쾍ꂏꎑꎓꆕꢗ", A_1);
            str3 = RptMgrErrorHandler.b("\uDD8B쾍ꂏꎑꎓꆕꦗ", A_1);
            str4 = RptMgrErrorHandler.b("\uDD8B뮍ꂏꖑ", A_1);
            str5 = RptMgrErrorHandler.b("\uDD8B쾍ꂏꂑꎓꎕꦗ", A_1);
            str6 = RptMgrErrorHandler.b("\uDD8B쾍ꂏꂑ겓ꞕꦗ", A_1);
            name2 = RptMgrErrorHandler.b("쮋뾍ꦏꆑ", A_1);
            name3 = RptMgrErrorHandler.b("\uDD8B뢍ꚏꖑ", A_1);
            num12 = (short) 74;
            num1 = (int) (IntPtr) num12;
            goto default;
          default:
            FlashcodeTable flashcodeTable1;
            bool flag12;
            while (true)
            {
              switch (num1)
              {
                case 0:
                  if (index5 != -1)
                  {
                    num12 = (short) 16 /*0x10*/;
                    num1 = (int) (IntPtr) num12;
                    continue;
                  }
                  goto case 36;
                case 1:
                  if (flag11)
                  {
                    num12 = (short) 65;
                    num1 = (int) (IntPtr) num12;
                    continue;
                  }
                  goto label_403;
                case 2:
                  if (index8 != -1)
                  {
                    num12 = (short) 63 /*0x3F*/;
                    num1 = (int) (IntPtr) num12;
                    continue;
                  }
                  goto case 57;
                case 3:
                  srcUsedBytes[index9] = (byte) ((uint) srcUsedBytes[index9] & (uint) (byte) ~num10);
                  num12 = (short) 29;
                  num1 = (int) (IntPtr) num12;
                  continue;
                case 4:
                  flashcodeTable1 = (FlashcodeTable) null;
                  num12 = (short) 62;
                  num1 = (int) (IntPtr) num12;
                  continue;
                case 5:
                  if (flag7)
                  {
                    num12 = (short) 9;
                    num1 = (int) (IntPtr) num12;
                    continue;
                  }
                  goto case 22;
                case 6:
                  srcUsedBytes[index6] = (byte) ((uint) srcUsedBytes[index6] & (uint) (byte) ~num7);
                  num12 = (short) 22;
                  num1 = (int) (IntPtr) num12;
                  continue;
                case 7:
                  num12 = (short) 46;
                  num1 = (int) (IntPtr) num12;
                  continue;
                case 8:
                  srcUsedBytes[index2] = (byte) ((uint) srcUsedBytes[index2] & (uint) (byte) ~num3);
                  num12 = (short) 11;
                  num1 = (int) (IntPtr) num12;
                  continue;
                case 9:
                  num12 = (short) 19;
                  num1 = (int) (IntPtr) num12;
                  continue;
                case 10:
                  num12 = (short) 50;
                  num1 = (int) (IntPtr) num12;
                  continue;
                case 11:
                  num12 = (short) 23;
                  num1 = (int) (IntPtr) num12;
                  continue;
                case 12:
                  num12 = (short) 0;
                  num1 = (int) (IntPtr) num12;
                  continue;
                case 13:
                  num12 = (short) 34;
                  num1 = (int) (IntPtr) num12;
                  continue;
                case 14:
                  srcUsedBytes[index10] = (byte) ((uint) srcUsedBytes[index10] & (uint) (byte) ~num11);
                  num12 = (short) 33;
                  num1 = (int) (IntPtr) num12;
                  continue;
                case 15:
                  if (num11 != -1)
                  {
                    num12 = (short) 52;
                    num1 = (int) (IntPtr) num12;
                    continue;
                  }
                  goto label_403;
                case 16 /*0x10*/:
                  srcUsedBytes[index5] = (byte) ((uint) srcUsedBytes[index5] & (uint) (byte) ~num6);
                  num12 = (short) 36;
                  num1 = (int) (IntPtr) num12;
                  continue;
                case 17:
                  name1 = RptMgrErrorHandler.b("쮋뮍ꆏ", A_1);
                  str1 = RptMgrErrorHandler.b("쮋뮍ꂏ", A_1);
                  str2 = RptMgrErrorHandler.b("쮋쾍ꂏꎑꎓꆕꢗ", A_1);
                  str3 = RptMgrErrorHandler.b("쮋쾍ꂏꎑꎓꆕꦗ", A_1);
                  str4 = RptMgrErrorHandler.b("쮋뮍ꂏꖑ", A_1);
                  num12 = (short) 4;
                  num1 = (int) (IntPtr) num12;
                  continue;
                case 18:
                  if (index2 != -1)
                  {
                    num12 = (short) 8;
                    num1 = (int) (IntPtr) num12;
                    continue;
                  }
                  goto case 11;
                case 19:
                  if (num7 != -1)
                  {
                    num12 = (short) 72;
                    num1 = (int) (IntPtr) num12;
                    continue;
                  }
                  goto case 22;
                case 20:
                  num12 = (short) 75;
                  num1 = (int) (IntPtr) num12;
                  continue;
                case 21:
                  if (num2 != -1)
                  {
                    num12 = (short) 54;
                    num1 = (int) (IntPtr) num12;
                    continue;
                  }
                  goto case 25;
                case 22:
                  num12 = (short) 40;
                  num1 = (int) (IntPtr) num12;
                  continue;
                case 23:
                  if (flag4)
                  {
                    num12 = (short) 45;
                    num1 = (int) (IntPtr) num12;
                    continue;
                  }
                  goto case 13;
                case 24:
                  if (num4 != -1)
                  {
                    num12 = (short) 53;
                    num1 = (int) (IntPtr) num12;
                    continue;
                  }
                  goto case 13;
                case 25:
                  num12 = (short) 68;
                  num1 = (int) (IntPtr) num12;
                  continue;
                case 26:
                  if (index3 != -1)
                  {
                    num12 = (short) 69;
                    num1 = (int) (IntPtr) num12;
                    continue;
                  }
                  goto case 13;
                case 27:
                  if (index1 != -1)
                  {
                    num12 = (short) 64 /*0x40*/;
                    num1 = (int) (IntPtr) num12;
                    continue;
                  }
                  goto case 25;
                case 28:
                  if (num3 != -1)
                  {
                    num12 = (short) 59;
                    num1 = (int) (IntPtr) num12;
                    continue;
                  }
                  goto case 11;
                case 29:
                  num12 = (short) 1;
                  num1 = (int) (IntPtr) num12;
                  continue;
                case 30:
                  num12 = (short) 42;
                  num1 = (int) (IntPtr) num12;
                  continue;
                case 31 /*0x1F*/:
                  num12 = (short) 9267;
                  int num13 = (int) num12;
                  num12 = (short) 9267;
                  int num14 = (int) num12;
                  switch (num13 == num14 ? 1 : 0)
                  {
                    case 0:
                    case 2:
                      goto label_407;
                    default:
                      num12 = (short) 0;
                      if (num12 == (short) 0)
                        ;
                      num12 = (short) 28;
                      num1 = (int) (IntPtr) num12;
                      continue;
                  }
                case 32 /*0x20*/:
                  if (num5 != -1)
                  {
                    num12 = (short) 7;
                    num1 = (int) (IntPtr) num12;
                    continue;
                  }
                  goto case 39;
                case 33:
                  goto label_403;
                case 34:
                  if (targetData.modelNumber.StartsWith(RptMgrErrorHandler.b("쒋랍ꞏ", A_1)) & flag5)
                  {
                    num12 = (short) 61;
                    num1 = (int) (IntPtr) num12;
                    continue;
                  }
                  goto case 39;
                case 35:
                  num12 = (short) 2;
                  num1 = (int) (IntPtr) num12;
                  continue;
                case 36:
                  num12 = (short) 66;
                  num1 = (int) (IntPtr) num12;
                  continue;
                case 37:
                  if (index7 != -1)
                  {
                    num12 = (short) 73;
                    num1 = (int) (IntPtr) num12;
                    continue;
                  }
                  goto case 56;
                case 38:
                  if (flag10)
                  {
                    num12 = (short) 60;
                    num1 = (int) (IntPtr) num12;
                    continue;
                  }
                  goto case 29;
                case 39:
                  num12 = (short) 5;
                  num1 = (int) (IntPtr) num12;
                  continue;
                case 40:
                  if (flag6)
                  {
                    num12 = (short) 30;
                    num1 = (int) (IntPtr) num12;
                    continue;
                  }
                  goto case 36;
                case 41:
                  num12 = (short) 37;
                  num1 = (int) (IntPtr) num12;
                  continue;
                case 42:
                  if (num6 != -1)
                  {
                    num12 = (short) 12;
                    num1 = (int) (IntPtr) num12;
                    continue;
                  }
                  goto case 36;
                case 43:
                  num12 = (short) 71;
                  num1 = (int) (IntPtr) num12;
                  continue;
                case 44:
                  srcUsedBytes[index4] = (byte) ((uint) srcUsedBytes[index4] & (uint) (byte) ~num5);
                  num12 = (short) 39;
                  num1 = (int) (IntPtr) num12;
                  continue;
                case 45:
                  num12 = (short) 24;
                  num1 = (int) (IntPtr) num12;
                  continue;
                case 46:
                  if (index4 != -1)
                  {
                    num12 = (short) 44;
                    num1 = (int) (IntPtr) num12;
                    continue;
                  }
                  goto case 39;
                case 47:
                  if (index10 != -1)
                  {
                    num12 = (short) 14;
                    num1 = (int) (IntPtr) num12;
                    continue;
                  }
                  goto label_403;
                case 48 /*0x30*/:
                  if (index6 != -1)
                  {
                    num12 = (short) 6;
                    num1 = (int) (IntPtr) num12;
                    continue;
                  }
                  goto case 22;
                case 49:
                  if (flag9)
                  {
                    num12 = (short) 43;
                    num1 = (int) (IntPtr) num12;
                    continue;
                  }
                  goto case 57;
                case 50:
                  if (num8 != -1)
                  {
                    num12 = (short) 41;
                    num1 = (int) (IntPtr) num12;
                    continue;
                  }
                  goto case 56;
                case 51:
                  if (flag1)
                  {
                    num12 = (short) 67;
                    num1 = (int) (IntPtr) num12;
                    continue;
                  }
                  goto label_403;
                case 52:
                  num12 = (short) 47;
                  num1 = (int) (IntPtr) num12;
                  continue;
                case 53:
                  num12 = (short) 26;
                  num1 = (int) (IntPtr) num12;
                  continue;
                case 54:
                  num12 = (short) 27;
                  num1 = (int) (IntPtr) num12;
                  continue;
                case 55:
                  num12 = (short) 21;
                  num1 = (int) (IntPtr) num12;
                  continue;
                case 56:
                  num12 = (short) 49;
                  num1 = (int) (IntPtr) num12;
                  continue;
                case 57:
                  num12 = (short) 38;
                  num1 = (int) (IntPtr) num12;
                  continue;
                case 58:
                  num12 = (short) 1;
                  if (num12 == (short) 0)
                    ;
                  if (flag2)
                  {
                    num12 = (short) 55;
                    num1 = (int) (IntPtr) num12;
                    continue;
                  }
                  goto case 25;
                case 59:
                  num12 = (short) 18;
                  num1 = (int) (IntPtr) num12;
                  continue;
                case 60:
                  num12 = (short) 70;
                  num1 = (int) (IntPtr) num12;
                  continue;
                case 61:
                  num12 = (short) 32 /*0x20*/;
                  num1 = (int) (IntPtr) num12;
                  continue;
                case 62:
                  try
                  {
                    num12 = (short) 182;
                    int num15 = (int) (IntPtr) num12;
                    while (true)
                    {
                      bool optionFound;
                      Option optionByName1;
                      Option optionByName2;
                      string optName;
                      bool flag13;
                      string str7;
                      string name4;
                      string str8;
                      Option optionByName3;
                      bool flag14;
                      bool A_2;
                      bool flag15;
                      bool flag16;
                      string str9;
                      Option optionByName4;
                      FlashcodeTable flashcodeTable2;
                      switch (num15)
                      {
                        case 0:
                          if (flashcodeTable1.IsOptionEnabledInFlashcode(str7, srcData.usedFlashcode, ref optionFound))
                          {
                            num12 = (short) 4;
                            num15 = (int) (IntPtr) num12;
                            continue;
                          }
                          goto case 103;
                        case 1:
                          if (flashcodeTable1.IsOptionEnabledInFlashcode(str5, srcData.purchasedFlashcode, ref optionFound))
                          {
                            num12 = (short) 28;
                            num15 = (int) (IntPtr) num12;
                            continue;
                          }
                          goto case 149;
                        case 2:
                          num12 = (short) 42;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 3:
                          if (flashcodeTable1.IsOptionEnabledInFlashcode(str4, targetData.purchasedFlashcode, ref optionFound))
                          {
                            num12 = (short) 146;
                            num15 = (int) (IntPtr) num12;
                            continue;
                          }
                          goto case 111;
                        case 4:
                          num12 = (short) 18;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 5:
                          if (!flashcodeTable1.IsOptionEnabledInFlashcode(str6, srcData.purchasedFlashcode, ref optionFound))
                          {
                            num12 = (short) 177;
                            num15 = (int) (IntPtr) num12;
                            continue;
                          }
                          goto case 154;
                        case 6:
                          if (flashcodeTable1.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("\uDD8B쾍ꂏꂑ꒓ꚕ꺗", A_1), targetData.purchasedFlashcode, ref optionFound))
                          {
                            num12 = (short) 165;
                            num15 = (int) (IntPtr) num12;
                            continue;
                          }
                          goto case 15;
                        case 7:
                          stsErrorMsg = AppResources.Unable_to_clone_from_a_NVG_radio;
                          flag12 = false;
                          num12 = (short) 199;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 8:
                          if (flashcodeTable1.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("\uDD8B쾍ꂏꂑ꒓ꚕ꺗", A_1), targetData.purchasedFlashcode, ref optionFound))
                          {
                            num12 = (short) 155;
                            num15 = (int) (IntPtr) num12;
                            continue;
                          }
                          goto case 165;
                        case 9:
                          if (flashcodeTable1.IsOptionEnabledInFlashcode(name2, srcData.purchasedFlashcode, ref optionFound))
                          {
                            num12 = (short) 94;
                            num15 = (int) (IntPtr) num12;
                            continue;
                          }
                          goto case 139;
                        case 10:
                          num12 = (short) 196;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 11:
                          flag1 = AllowCloning.AllowEnhLevel2Clone(flashcodeTable1, srcData, targetData);
                          num12 = (short) 195;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 12:
                          if (isPortable)
                          {
                            num12 = (short) 17;
                            num15 = (int) (IntPtr) num12;
                            continue;
                          }
                          goto label_328;
                        case 13:
                          num12 = (short) 35;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 14:
                          if (!flashcodeTable1.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("쮋뾍ꎏꪑ", A_1), srcData.purchasedFlashcode, ref optionFound))
                          {
                            num12 = (short) 151;
                            num15 = (int) (IntPtr) num12;
                            continue;
                          }
                          goto label_320;
                        case 15:
                          num12 = (short) 130;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 16 /*0x10*/:
                          flag1 = AllowCloning.AllowEnhLevel1Clone(flashcodeTable1, srcData, targetData);
                          num12 = (short) 48 /*0x30*/;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 17:
                          num12 = (short) 194;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 18:
                          if (flashcodeTable1.IsOptionEnabledInFlashcode(name4, targetData.purchasedFlashcode, ref optionFound))
                          {
                            num12 = (short) 156;
                            num15 = (int) (IntPtr) num12;
                            continue;
                          }
                          goto case 103;
                        case 19:
                          num12 = (short) 98;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 20:
                          if (flashcodeTable1.IsOptionEnabledInFlashcode(str6, targetData.purchasedFlashcode, ref optionFound))
                          {
                            num12 = (short) 32 /*0x20*/;
                            num15 = (int) (IntPtr) num12;
                            continue;
                          }
                          goto case 154;
                        case 21:
                          if (!flashcodeTable1.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("\uDD8B붍ꚏꎑ", A_1), srcData.purchasedFlashcode, ref optionFound))
                          {
                            num12 = (short) 109;
                            num15 = (int) (IntPtr) num12;
                            continue;
                          }
                          goto case 53;
                        case 22:
                          if (!isPortable)
                          {
                            num12 = (short) 30;
                            num15 = (int) (IntPtr) num12;
                            continue;
                          }
                          goto case 23;
                        case 23:
                        case 191:
                          num12 = (short) 100;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 24:
                          if (!flashcodeTable1.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("\uDD8B쾍ꂏꂑ꒓ꚕ꺗", A_1), srcData.purchasedFlashcode, ref optionFound))
                          {
                            num12 = (short) 126;
                            num15 = (int) (IntPtr) num12;
                            continue;
                          }
                          goto case 15;
                        case 25:
                          if (!flashcodeTable1.IsOptionEnabledInFlashcode(str5, targetData.purchasedFlashcode, ref optionFound))
                          {
                            num12 = (short) 183;
                            num15 = (int) (IntPtr) num12;
                            continue;
                          }
                          goto case 149;
                        case 26:
                          if (!flashcodeTable1.IsOptionEnabledInFlashcode(str4, srcData.purchasedFlashcode, ref optionFound))
                          {
                            num12 = (short) 90;
                            num15 = (int) (IntPtr) num12;
                            continue;
                          }
                          goto case 111;
                        case 27:
                          num12 = (short) 148;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 28:
                          num12 = (short) 25;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 29:
                          if (flashcodeTable1.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("\uDD8B쾍ꂏꊑꆓꆕ꾗", A_1), targetData.purchasedFlashcode, ref optionFound))
                          {
                            num12 = (short) 88;
                            num15 = (int) (IntPtr) num12;
                            continue;
                          }
                          goto label_356;
                        case 30:
                          num12 = (short) 91;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 31 /*0x1F*/:
                          if (!flashcodeTable1.IsOptionEnabledInFlashcode(name1, targetData.purchasedFlashcode, ref optionFound))
                          {
                            num12 = (short) 84;
                            num15 = (int) (IntPtr) num12;
                            continue;
                          }
                          goto case 190;
                        case 32 /*0x20*/:
                          num12 = (short) 176 /*0xB0*/;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 33:
                          if (flashcodeTable1.IsOptionEnabledInFlashcode(str2, srcData.purchasedFlashcode, ref optionFound))
                          {
                            num12 = (short) 101;
                            num15 = (int) (IntPtr) num12;
                            continue;
                          }
                          goto label_198;
                        case 34:
                          if (flashcodeTable1.IsOptionEnabledInFlashcode(str1, targetData.purchasedFlashcode, ref optionFound))
                          {
                            num12 = (short) 56;
                            num15 = (int) (IntPtr) num12;
                            continue;
                          }
                          goto case 152;
                        case 35:
                          if (!isPortable)
                          {
                            flag1 = AllowCloning.AllowFrequencyCloneMobile(flashcodeTable1, srcData, targetData);
                            num12 = (short) 137;
                            num15 = (int) (IntPtr) num12;
                            continue;
                          }
                          num12 = (short) 93;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 36:
                          num8 = flashcodeTable1.FLASHcode.GetOptionMask(str4);
                          index7 = flashcodeTable1.FLASHcode.GetOptionBytePosition(str4) - 1;
                          flag8 = true;
                          num12 = (short) 178;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 37:
                          if (optionByName1 == null)
                          {
                            stsErrorMsg = AcpStringExtensions.AcpStringFormat(AppResources.Unable_to_clone_because_the_number_of_records_feature_in_target, new object[1]
                            {
                              (object) str2
                            });
                            num12 = (short) 97;
                            num15 = (int) (IntPtr) num12;
                            continue;
                          }
                          num12 = (short) 119;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 38:
                          stsErrorMsg = AcpStringExtensions.AcpStringFormat(AppResources.Unable_to_clone_because_the_number_of_records_feature_in_target, new object[1]
                          {
                            (object) optionByName2.ToString()
                          });
                          num12 = (short) 64 /*0x40*/;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 39:
                          if (!flag1)
                          {
                            num12 = (short) 57;
                            num15 = (int) (IntPtr) num12;
                            continue;
                          }
                          goto case 64 /*0x40*/;
                        case 40:
                          str7 = RptMgrErrorHandler.b("\uDB8B랍ꚏꮑ", A_1);
                          name4 = RptMgrErrorHandler.b("쮋벍ꦏꪑ", A_1);
                          str8 = RptMgrErrorHandler.b("쮋쾍ꂏꎑꎓꂕ꾗", A_1);
                          num12 = (short) 143;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 41:
                          if (flag1)
                          {
                            num12 = (short) 19;
                            num15 = (int) (IntPtr) num12;
                            continue;
                          }
                          goto case 15;
                        case 42:
                          if (flashcodeTable1.IsOptionEnabledInFlashcode(str9, srcData.purchasedFlashcode, ref optionFound))
                          {
                            num12 = (short) 43;
                            num15 = (int) (IntPtr) num12;
                            continue;
                          }
                          goto case 105;
                        case 43:
                          num5 = flashcodeTable1.FLASHcode.GetOptionMask(str9);
                          index4 = flashcodeTable1.FLASHcode.GetOptionBytePosition(str9) - 1;
                          flag5 = true;
                          num12 = (short) 105;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 44:
                          num12 = (short) sbyte.MaxValue;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 45:
                          if (AllowCloning.a(srcData.modelNumber))
                          {
                            num12 = (short) 179;
                            num15 = (int) (IntPtr) num12;
                            continue;
                          }
                          goto case 139;
                        case 46:
                          num12 = (short) 67;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 47:
                          if (!flag1)
                          {
                            num12 = (short) 153;
                            num15 = (int) (IntPtr) num12;
                            continue;
                          }
                          goto case 10;
                        case 48 /*0x30*/:
                          if (!flag1)
                          {
                            optionByName3 = flashcodeTable1.FLASHcode.GetOptionByName(str2);
                            num12 = (short) 77;
                            num15 = (int) (IntPtr) num12;
                            continue;
                          }
                          num12 = (short) 50;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 49:
                          num12 = (short) 104;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 50:
                          num6 = flashcodeTable1.FLASHcode.GetOptionMask(str2);
                          index5 = flashcodeTable1.FLASHcode.GetOptionBytePosition(str2) - 1;
                          flag6 = true;
                          num12 = (short) 142;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 51:
                          flag1 = AllowCloning.b(flashcodeTable1, srcData, targetData);
                          num12 = (short) 47;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 52:
                          num12 = (short) 74;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 53:
                          num12 = (short) 5;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 54:
                          num12 = (short) 112 /*0x70*/;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 55:
                          flag1 = false;
                          stsErrorMsg = AppResources.Unable_to_clone_from_a_trunking;
                          num12 = (short) 190;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 56:
                          flag1 = false;
                          stsErrorMsg = AppResources.Unable_to_clone_from_a_Trunking_SmartZone;
                          num12 = (short) 152;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 57:
                          optionByName1 = flashcodeTable1.FLASHcode.GetOptionByName(str2);
                          num12 = (short) 37;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 58:
                          if (!flashcodeTable1.IsOptionEnabledInFlashcode(name3, srcData.purchasedFlashcode, ref optionFound))
                          {
                            num12 = (short) 169;
                            num15 = (int) (IntPtr) num12;
                            continue;
                          }
                          goto case 94;
                        case 59:
                          num3 = flashcodeTable1.FLASHcode.GetOptionMask(str1);
                          index2 = flashcodeTable1.FLASHcode.GetOptionBytePosition(str1) - 1;
                          flag3 = true;
                          num12 = (short) 172;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 60:
                          num11 = flashcodeTable1.FLASHcode.GetOptionMask(optName);
                          index10 = flashcodeTable1.FLASHcode.GetOptionBytePosition(optName) - 1;
                          num12 = (short) 139;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 61:
                          if (flag1)
                          {
                            num12 = (short) 13;
                            num15 = (int) (IntPtr) num12;
                            continue;
                          }
                          goto case 173;
                        case 62:
                          if (flashcodeTable1.IsOptionEnabledInFlashcode(str1, srcData.purchasedFlashcode, ref optionFound))
                          {
                            num12 = (short) 80 /*0x50*/;
                            num15 = (int) (IntPtr) num12;
                            continue;
                          }
                          goto case 190;
                        case 63 /*0x3F*/:
                          str7 = RptMgrErrorHandler.b("쒋뚍ꚏꮑ", A_1);
                          name4 = RptMgrErrorHandler.b("\uDD8B몍ꦏꪑ", A_1);
                          str8 = RptMgrErrorHandler.b("\uDD8B쾍ꂏꎑꎓꂕ꾗", A_1);
                          str9 = RptMgrErrorHandler.b("\uDD8B쾍ꂏꎑꎓꂕꂗ", A_1);
                          num12 = (short) 131;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 64 /*0x40*/:
                        case 71:
                        case 97:
                        case 102:
                        case 108:
                        case 110:
                        case 125:
                        case 142:
                        case 150:
                        case 189:
                          num12 = (short) 106;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 65:
                          if (flashcodeTable1.IsOptionEnabledInFlashcode(name1, targetData.purchasedFlashcode, ref optionFound))
                          {
                            num12 = (short) 59;
                            num15 = (int) (IntPtr) num12;
                            continue;
                          }
                          goto case 172;
                        case 66:
                          flag1 = false;
                          stsErrorMsg = AppResources.Unable_to_clone_from_a_Motorcycle_radio;
                          num12 = (short) 191;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 67:
                          if (!flashcodeTable1.IsOptionEnabledInFlashcode(str4, targetData.purchasedFlashcode, ref optionFound))
                          {
                            num12 = (short) 36;
                            num15 = (int) (IntPtr) num12;
                            continue;
                          }
                          goto case 178;
                        case 68:
                          num12 = (short) 21;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 69:
                          flag11 = true;
                          optName = name2;
                          num12 = (short) 116;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 70:
                          num12 = (short) 166;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 72:
                          goto label_89;
                        case 73:
                          if (flashcodeTable1.IsOptionEnabledInFlashcode(str6, srcData.purchasedFlashcode, ref optionFound))
                          {
                            num12 = (short) 49;
                            num15 = (int) (IntPtr) num12;
                            continue;
                          }
                          goto case 175;
                        case 74:
                          flashcodeTable2 = new FlashcodeTable(isPortable, false);
                          goto label_177;
                        case 75:
                          if (flag1)
                          {
                            num12 = (short) 184;
                            num15 = (int) (IntPtr) num12;
                            continue;
                          }
                          goto case 111;
                        case 76:
                          optName = name3;
                          num12 = (short) 60;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 77:
                          if (optionByName3 != null)
                          {
                            num12 = (short) 132;
                            num15 = (int) (IntPtr) num12;
                            continue;
                          }
                          stsErrorMsg = AcpStringExtensions.AcpStringFormat(AppResources.Unable_to_clone_because_the_number_of_records_feature, new object[1]
                          {
                            (object) str2
                          });
                          num12 = (short) 125;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 78:
                          if (!flag16)
                          {
                            num12 = (short) 16 /*0x10*/;
                            num15 = (int) (IntPtr) num12;
                            continue;
                          }
                          goto label_198;
                        case 79:
                          if (!flashcodeTable1.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("\uDD8B쾍ꂏꊑꆓꆕ꾗", A_1), srcData.purchasedFlashcode, ref optionFound))
                          {
                            num12 = (short) 123;
                            num15 = (int) (IntPtr) num12;
                            continue;
                          }
                          goto label_356;
                        case 80 /*0x50*/:
                          num12 = (short) 31 /*0x1F*/;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 81:
                          if (flashcodeTable1.IsOptionEnabledInFlashcode(str4, srcData.purchasedFlashcode, ref optionFound))
                          {
                            num12 = (short) 46;
                            num15 = (int) (IntPtr) num12;
                            continue;
                          }
                          goto case 178;
                        case 82:
                          num12 = (short) 62;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 83:
                          if (optionByName4 == null)
                          {
                            stsErrorMsg = AcpStringExtensions.AcpStringFormat(AppResources.Unable_to_clone_because_the_number_of_records_feature, new object[1]
                            {
                              (object) str3
                            });
                            num12 = (short) 108;
                            num15 = (int) (IntPtr) num12;
                            continue;
                          }
                          num12 = (short) 117;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 84:
                          num12 = (short) 115;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 85:
                          if (flag1)
                          {
                            num12 = (short) 141;
                            num15 = (int) (IntPtr) num12;
                            continue;
                          }
                          goto case 152;
                        case 86:
                          if (flashcodeTable1.IsOptionEnabledInFlashcode(str7, srcData.purchasedFlashcode, ref optionFound))
                          {
                            num12 = (short) 167;
                            num15 = (int) (IntPtr) num12;
                            continue;
                          }
                          goto case 103;
                        case 87:
                          num12 = (short) 45;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 88:
                          flag1 = false;
                          stsErrorMsg = AppResources.Unable_to_clone_from_a_model_3_5;
                          num12 = (short) 180;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 89:
                          flag1 = false;
                          stsErrorMsg = AppResources.Unable_to_clone_from_non_APX_Lite_model_to_APX_Lite_model;
                          num12 = (short) 99;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 90:
                          num12 = (short) 3;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 91:
                          if (flashcodeTable1.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("쮋뾍ꎏꪑ", A_1), srcData.purchasedFlashcode, ref optionFound))
                          {
                            num12 = (short) 44;
                            num15 = (int) (IntPtr) num12;
                            continue;
                          }
                          goto case 168;
                        case 92:
                          num7 = flashcodeTable1.FLASHcode.GetOptionMask(str3);
                          index6 = flashcodeTable1.FLASHcode.GetOptionBytePosition(str3) - 1;
                          flag7 = true;
                          num12 = (short) 102;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 93:
                          flag1 = AllowCloning.AllowFrequencyClonePortable(flashcodeTable1, srcData, targetData);
                          num12 = (short) 163;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 94:
                          num12 = (short) 198;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 95:
                        case 180:
                          num12 = (short) 41;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 96 /*0x60*/:
                          num4 = flashcodeTable1.FLASHcode.GetOptionMask(str8);
                          index3 = flashcodeTable1.FLASHcode.GetOptionBytePosition(str8) - 1;
                          flag4 = true;
                          num12 = (short) 2;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 98:
                          if (flashcodeTable1.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("\uDD8B쾍ꂏꂑ꒓ꚕ꺗", A_1), srcData.purchasedFlashcode, ref optionFound))
                          {
                            num12 = (short) 140;
                            num15 = (int) (IntPtr) num12;
                            continue;
                          }
                          goto case 155;
                        case 99:
                          num12 = (short) 161;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 100:
                          if (flag1)
                          {
                            num12 = (short) 27;
                            num15 = (int) (IntPtr) num12;
                            continue;
                          }
                          goto case 190;
                        case 101:
                          num12 = (short) 78;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 103:
                          num12 = (short) 174;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 104:
                          if (!flashcodeTable1.IsOptionEnabledInFlashcode(str6, targetData.purchasedFlashcode, ref optionFound))
                          {
                            num12 = (short) 133;
                            num15 = (int) (IntPtr) num12;
                            continue;
                          }
                          goto case 175;
                        case 105:
                          num12 = (short) 81;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 106:
                          if (flag1)
                          {
                            num12 = (short) 181;
                            num15 = (int) (IntPtr) num12;
                            continue;
                          }
                          goto case 99;
                        case 107:
                          stsErrorMsg = AppResources.Unable_to_clone_to_a_12_5;
                          num12 = (short) 111;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 109:
                          num12 = (short) 138;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 111:
                          num12 = (short) 159;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 112 /*0x70*/:
                          if (flashcodeTable1.IsOptionEnabledInFlashcode(str5, targetData.purchasedFlashcode, ref optionFound))
                          {
                            num12 = (short) 89;
                            num15 = (int) (IntPtr) num12;
                            continue;
                          }
                          goto case 99;
                        case 113:
                          if (!flashcodeTable1.IsOptionEnabledInFlashcode(name2, targetData.purchasedFlashcode, ref optionFound))
                          {
                            num12 = (short) 69;
                            num15 = (int) (IntPtr) num12;
                            continue;
                          }
                          goto case 139;
                        case 114:
                          num12 = (short) 34;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 115:
                          if (!flashcodeTable1.IsOptionEnabledInFlashcode(str1, targetData.purchasedFlashcode, ref optionFound))
                          {
                            num12 = (short) 55;
                            num15 = (int) (IntPtr) num12;
                            continue;
                          }
                          goto case 190;
                        case 116:
                          if (isPortable)
                          {
                            num12 = (short) 76;
                            num15 = (int) (IntPtr) num12;
                            continue;
                          }
                          goto case 60;
                        case 117:
                          stsErrorMsg = AcpStringExtensions.AcpStringFormat(AppResources.Unable_to_clone_because_the_number_of_records_feature, new object[1]
                          {
                            (object) optionByName4.ToString()
                          });
                          num12 = (short) 189;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 118:
                          if (flashcodeTable1.IsOptionEnabledInFlashcode(name1, srcData.purchasedFlashcode, ref optionFound))
                          {
                            num12 = (short) 114;
                            num15 = (int) (IntPtr) num12;
                            continue;
                          }
                          goto case 152;
                        case 119:
                          stsErrorMsg = AcpStringExtensions.AcpStringFormat(AppResources.Unable_to_clone_because_the_number_of_records_feature_in_target, new object[1]
                          {
                            (object) optionByName1.ToString()
                          });
                          num12 = (short) 110;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 120:
                          if (!(!flag15 & flag16))
                          {
                            num12 = (short) 121;
                            num15 = (int) (IntPtr) num12;
                            continue;
                          }
                          num12 = (short) 129;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 121:
                          if (!flag14 & flag13)
                          {
                            num12 = (short) 11;
                            num15 = (int) (IntPtr) num12;
                            continue;
                          }
                          goto case 64 /*0x40*/;
                        case 122:
                          num12 = (short) 65;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 123:
                          num12 = (short) 29;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 124:
                          flashcodeTable2 = new FlashcodeTable();
                          goto label_177;
                        case 126:
                          num12 = (short) 6;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case (int) sbyte.MaxValue:
                          if (flashcodeTable1.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("쮋뾍ꎏꪑ", A_1), targetData.purchasedFlashcode, ref optionFound))
                          {
                            num12 = (short) 168;
                            num15 = (int) (IntPtr) num12;
                            continue;
                          }
                          goto case 66;
                        case 128 /*0x80*/:
                          num12 = (short) 160 /*0xA0*/;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 129:
                          flag1 = AllowCloning.AllowEnhLevel1Clone(flashcodeTable1, srcData, targetData);
                          num12 = (short) 39;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 130:
                          if (flag1)
                          {
                            num12 = (short) 70;
                            num15 = (int) (IntPtr) num12;
                            continue;
                          }
                          goto label_328;
                        case 131:
                          if (!isPortable)
                          {
                            num12 = (short) 40;
                            num15 = (int) (IntPtr) num12;
                            continue;
                          }
                          goto case 143;
                        case 132:
                          stsErrorMsg = AcpStringExtensions.AcpStringFormat(AppResources.Unable_to_clone_because_the_number_of_records_feature, new object[1]
                          {
                            (object) optionByName3.ToString()
                          });
                          num12 = (short) 71;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 133:
                          num10 = flashcodeTable1.FLASHcode.GetOptionMask(str6);
                          index9 = flashcodeTable1.FLASHcode.GetOptionBytePosition(str6) - 1;
                          flag10 = true;
                          num12 = (short) 175;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 134:
                          if (flag1)
                          {
                            num12 = (short) 136;
                            num15 = (int) (IntPtr) num12;
                            continue;
                          }
                          goto case 64 /*0x40*/;
                        case 135:
                          if (flashcodeTable1.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("쮋뾍ꎏꪑ", A_1), targetData.purchasedFlashcode, ref optionFound))
                          {
                            num12 = (short) 66;
                            num15 = (int) (IntPtr) num12;
                            continue;
                          }
                          goto label_320;
                        case 136:
                          flag13 = flashcodeTable1.IsOptionEnabledInFlashcode(str3, targetData.purchasedFlashcode, ref optionFound);
                          flag16 = flashcodeTable1.IsOptionEnabledInFlashcode(str2, targetData.purchasedFlashcode, ref optionFound);
                          flag15 = flashcodeTable1.IsOptionEnabledInFlashcode(str2, srcData.purchasedFlashcode, ref optionFound);
                          flag14 = flashcodeTable1.IsOptionEnabledInFlashcode(str3, srcData.purchasedFlashcode, ref optionFound);
                          num12 = (short) 158;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 137:
                        case 163:
                          num12 = (short) 144 /*0x90*/;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 138:
                          if (flashcodeTable1.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("쮋붍ꚏꎑ", A_1), srcData.purchasedFlashcode, ref optionFound))
                          {
                            num12 = (short) 53;
                            num15 = (int) (IntPtr) num12;
                            continue;
                          }
                          goto case 154;
                        case 139:
                          num12 = (short) 72;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 140:
                          num12 = (short) 8;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 141:
                          num12 = (short) 118;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 143:
                          num12 = (short) 86;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 144 /*0x90*/:
                          if (!flag1)
                          {
                            num12 = (short) 145;
                            num15 = (int) (IntPtr) num12;
                            continue;
                          }
                          goto case 173;
                        case 145:
                          stsErrorMsg = AppResources.Unable_to_clone_due_to_the_incompatibility;
                          num12 = (short) 173;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 146:
                          flag1 = AllowCloning.a(flashcodeTable1, targetData.purchasedFlashcode, A_2, isPortable);
                          num12 = (short) 162;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 147:
                          if (optionByName2 != null)
                          {
                            num12 = (short) 38;
                            num15 = (int) (IntPtr) num12;
                            continue;
                          }
                          stsErrorMsg = AcpStringExtensions.AcpStringFormat(AppResources.Unable_to_clone_because_the_number_of_records_feature_in_target, new object[1]
                          {
                            (object) str3
                          });
                          num12 = (short) 150;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 148:
                          if (!flashcodeTable1.IsOptionEnabledInFlashcode(name1, srcData.purchasedFlashcode, ref optionFound))
                          {
                            num12 = (short) 82;
                            num15 = (int) (IntPtr) num12;
                            continue;
                          }
                          goto case 80 /*0x50*/;
                        case 149:
                          num12 = (short) 73;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 151:
                          num12 = (short) 135;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 152:
                          num12 = (short) 61;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 153:
                          stsErrorMsg = AppResources.Unable_to_clone_due_to_G857_incompatibility;
                          num12 = (short) 10;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 154:
                          num12 = (short) 187;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 155:
                          num12 = (short) 24;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 156:
                          num2 = flashcodeTable1.FLASHcode.GetOptionMask(str7);
                          index1 = flashcodeTable1.FLASHcode.GetOptionBytePosition(str7) - 1;
                          flag2 = true;
                          num12 = (short) 103;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 157:
                          num12 = (short) 164;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 158:
                          if (flashcodeTable1.IsOptionEnabledInFlashcode(str3, srcData.purchasedFlashcode, ref optionFound))
                          {
                            num12 = (short) 128 /*0x80*/;
                            num15 = (int) (IntPtr) num12;
                            continue;
                          }
                          break;
                        case 159:
                          if (flag1)
                          {
                            num12 = (short) 51;
                            num15 = (int) (IntPtr) num12;
                            continue;
                          }
                          goto case 10;
                        case 160 /*0xA0*/:
                          if (!flag13)
                          {
                            num12 = (short) 192 /*0xC0*/;
                            num15 = (int) (IntPtr) num12;
                            continue;
                          }
                          break;
                        case 161:
                          if (flag1)
                          {
                            num12 = (short) 68;
                            num15 = (int) (IntPtr) num12;
                            continue;
                          }
                          goto case 154;
                        case 162:
                          if (!flag1)
                          {
                            num12 = (short) 107;
                            num15 = (int) (IntPtr) num12;
                            continue;
                          }
                          goto case 111;
                        case 164:
                          if (flashcodeTable1.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("\uDD8B쾍ꂏꊑꆓꆕ꾗", A_1), targetData.purchasedFlashcode, ref optionFound))
                          {
                            num12 = (short) 170;
                            num15 = (int) (IntPtr) num12;
                            continue;
                          }
                          goto case 88;
                        case 165:
                          flag1 = false;
                          stsErrorMsg = AppResources.Unable_To_Clone_From_APX6000_To_APX6000XE_And_Viceversa;
                          num12 = (short) 15;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 166:
                          if (flashcodeTable1.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("\uDD8B쾍ꂏ꒑궓꺕궗", A_1), srcData.purchasedFlashcode, ref optionFound) != flashcodeTable1.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("\uDD8B쾍ꂏ꒑궓꺕궗", A_1), targetData.purchasedFlashcode, ref optionFound))
                          {
                            num12 = (short) 7;
                            num15 = (int) (IntPtr) num12;
                            continue;
                          }
                          goto label_328;
                        case 167:
                          num12 = (short) 0;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 168:
                          num12 = (short) 14;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 169:
                          num12 = (short) 9;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 170:
                          num12 = (short) 79;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 171:
                          if (!flashcodeTable1.IsOptionEnabledInFlashcode(str5, srcData.purchasedFlashcode, ref optionFound))
                          {
                            num12 = (short) 54;
                            num15 = (int) (IntPtr) num12;
                            continue;
                          }
                          goto case 99;
                        case 172:
                          num12 = (short) 197;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 173:
                          num12 = (short) 75;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 174:
                          if (flashcodeTable1.IsOptionEnabledInFlashcode(str1, srcData.purchasedFlashcode, ref optionFound))
                          {
                            num12 = (short) 122;
                            num15 = (int) (IntPtr) num12;
                            continue;
                          }
                          goto case 172;
                        case 175:
                          num12 = (short) 134;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 176 /*0xB0*/:
                          if (!AllowCloning.a(srcData))
                          {
                            num12 = (short) 193;
                            num15 = (int) (IntPtr) num12;
                            continue;
                          }
                          goto case 154;
                        case 177:
                          num12 = (short) 20;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 178:
                          num12 = (short) 1;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 179:
                          num12 = (short) 58;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 181:
                          num12 = (short) 171;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 182:
                          switch (0)
                          {
                            case 0:
                              goto label_95;
                            default:
                              continue;
                          }
                        case 183:
                          num9 = flashcodeTable1.FLASHcode.GetOptionMask(str5);
                          index8 = flashcodeTable1.FLASHcode.GetOptionBytePosition(str5) - 1;
                          flag9 = true;
                          num12 = (short) 149;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 184:
                          num12 = (short) 26;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 185:
                          if (!flag1)
                          {
                            optionByName4 = flashcodeTable1.FLASHcode.GetOptionByName(str3);
                            num12 = (short) 83;
                            num15 = (int) (IntPtr) num12;
                            continue;
                          }
                          num12 = (short) 92;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 186:
                          num12 = (short) 113;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 187:
                          if (flag1)
                          {
                            num12 = (short) 87;
                            num15 = (int) (IntPtr) num12;
                            continue;
                          }
                          goto case 139;
                        case 188:
                          optionByName2 = flashcodeTable1.FLASHcode.GetOptionByName(str3);
                          num12 = (short) 147;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 190:
                          num12 = (short) 85;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 192 /*0xC0*/:
                          flag1 = AllowCloning.AllowEnhLevel2Clone(flashcodeTable1, srcData, targetData);
                          num12 = (short) 185;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 193:
                          flag1 = false;
                          stsErrorMsg = AppResources.Unable_to_clone_source_has_36009600_trunking_target_single_trunking;
                          num12 = (short) 154;
                          num15 = (int) (IntPtr) num12;
                          continue;
                        case 194:
                          if (flashcodeTable1.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("\uDD8B쾍ꂏꊑꆓꆕ꾗", A_1), srcData.purchasedFlashcode, ref optionFound))
                          {
                            num12 = (short) 157;
                            num15 = (int) (IntPtr) num12;
                            continue;
                          }
                          goto case 170;
                        case 195:
                          if (!flag1)
                          {
                            num12 = (short) 188;
                            num15 = (int) (IntPtr) num12;
                            continue;
                          }
                          goto case 64 /*0x40*/;
                        case 196:
                          if (flag1)
                          {
                            num12 = (short) 63 /*0x3F*/;
                            num15 = (int) (IntPtr) num12;
                            continue;
                          }
                          goto case 175;
                        case 197:
                          if (flashcodeTable1.IsOptionEnabledInFlashcode(str8, srcData.purchasedFlashcode, ref optionFound))
                          {
                            num12 = (short) 96 /*0x60*/;
                            num15 = (int) (IntPtr) num12;
                            continue;
                          }
                          goto case 2;
                        case 198:
                          if (!flashcodeTable1.IsOptionEnabledInFlashcode(name3, targetData.purchasedFlashcode, ref optionFound))
                          {
                            num12 = (short) 186;
                            num15 = (int) (IntPtr) num12;
                            continue;
                          }
                          goto case 139;
                        case 199:
                          goto label_407;
                        default:
label_95:
                          if (srcData._data != null)
                          {
                            num12 = (short) 52;
                            num15 = (int) (IntPtr) num12;
                            continue;
                          }
                          num12 = (short) 124;
                          num15 = (int) (IntPtr) num12;
                          continue;
                      }
                      num12 = (short) 33;
                      num15 = (int) (IntPtr) num12;
                      continue;
label_177:
                      flashcodeTable1 = flashcodeTable2;
                      flashcodeTable1.InitTable(srcData._data == null, srcData.modelNumber);
                      optionFound = false;
                      A_2 = AllowCloning.b(srcData);
                      num12 = (short) 12;
                      num15 = (int) (IntPtr) num12;
                      continue;
label_198:
                      num12 = (short) 120;
                      num15 = (int) (IntPtr) num12;
                      continue;
label_320:
                      flag1 = true;
                      num12 = (short) 23;
                      num15 = (int) (IntPtr) num12;
                      continue;
label_328:
                      num12 = (short) 22;
                      num15 = (int) (IntPtr) num12;
                      continue;
label_356:
                      flag1 = true;
                      num12 = (short) 95;
                      num15 = (int) (IntPtr) num12;
                    }
                  }
                  finally
                  {
                    short num16 = 2;
                    int num17 = (int) (IntPtr) num16;
                    while (true)
                    {
                      switch (num17)
                      {
                        case 0:
                          flashcodeTable1.Dispose();
                          flashcodeTable1 = (FlashcodeTable) null;
                          num16 = (short) 1;
                          num17 = (int) (IntPtr) num16;
                          continue;
                        case 1:
                          goto label_383;
                        case 2:
                          switch (0)
                          {
                            case 0:
                              break;
                            default:
                              continue;
                          }
                          break;
                      }
                      if (flashcodeTable1 != null)
                      {
                        num16 = (short) 0;
                        num17 = (int) (IntPtr) num16;
                      }
                      else
                        break;
                    }
label_383:;
                  }
label_89:
                  num12 = (short) 51;
                  num1 = (int) (IntPtr) num12;
                  continue;
                case 63 /*0x3F*/:
                  srcUsedBytes[index8] = (byte) ((uint) srcUsedBytes[index8] & (uint) (byte) ~num9);
                  num12 = (short) 57;
                  num1 = (int) (IntPtr) num12;
                  continue;
                case 64 /*0x40*/:
                  srcUsedBytes[index1] = (byte) ((uint) srcUsedBytes[index1] & (uint) (byte) ~num2);
                  num12 = (short) 25;
                  num1 = (int) (IntPtr) num12;
                  continue;
                case 65:
                  num12 = (short) 15;
                  num1 = (int) (IntPtr) num12;
                  continue;
                case 66:
                  if (flag8)
                  {
                    num12 = (short) 10;
                    num1 = (int) (IntPtr) num12;
                    continue;
                  }
                  goto case 56;
                case 67:
                  num12 = (short) 58;
                  num1 = (int) (IntPtr) num12;
                  continue;
                case 68:
                  num12 = (short) 0;
                  if (flag3)
                  {
                    num12 = (short) 31 /*0x1F*/;
                    num1 = (int) (IntPtr) num12;
                    continue;
                  }
                  goto case 11;
                case 69:
                  srcUsedBytes[index3] = (byte) ((uint) srcUsedBytes[index3] & (uint) (byte) ~num4);
                  num12 = (short) 13;
                  num1 = (int) (IntPtr) num12;
                  continue;
                case 70:
                  if (num10 != -1)
                  {
                    num12 = (short) 20;
                    num1 = (int) (IntPtr) num12;
                    continue;
                  }
                  goto case 29;
                case 71:
                  if (num9 != -1)
                  {
                    num12 = (short) 35;
                    num1 = (int) (IntPtr) num12;
                    continue;
                  }
                  goto case 57;
                case 72:
                  num12 = (short) 48 /*0x30*/;
                  num1 = (int) (IntPtr) num12;
                  continue;
                case 73:
                  srcUsedBytes[index7] = (byte) ((uint) srcUsedBytes[index7] & (uint) (byte) ~num8);
                  num12 = (short) 56;
                  num1 = (int) (IntPtr) num12;
                  continue;
                case 74:
                  if (!isPortable)
                  {
                    num12 = (short) 17;
                    num1 = (int) (IntPtr) num12;
                    continue;
                  }
                  goto case 4;
                case 75:
                  if (index9 != -1)
                  {
                    num12 = (short) 3;
                    num1 = (int) (IntPtr) num12;
                    continue;
                  }
                  goto case 29;
                default:
                  goto label_3;
              }
            }
label_403:
            return flag1;
label_407:
            return flag12;
        }
    }
  }

  private static bool a(string A_0)
  {
    int A_1 = 4;
    short num1 = 8137;
    int num2 = (int) num1;
    num1 = (short) 8137;
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
        return new System.Collections.Generic.List<string>()
        {
          RptMgrErrorHandler.b("쾆낈몊\uD98C좎햐ꪒ얔삖겘\uDA9A펜", A_1),
          RptMgrErrorHandler.b("쾆낈몊\uD98C좎햐ꪒ얔삖꾘\uDA9A펜", A_1),
          RptMgrErrorHandler.b("쾆낈몊\uD98C좎햐ꪒ얔삖꺘\uDA9A펜", A_1),
          RptMgrErrorHandler.b("쾆낈몊\uD98C좎햐ꪒ얔삖ꆘ\uDA9A펜", A_1),
          RptMgrErrorHandler.b("쾆낈몊\uD98C좎햐ꪒ얔삖ꂘ\uDA9A펜", A_1),
          RptMgrErrorHandler.b("쾆낈몊\uD98C좎햐ꪒ얔삖궘\uDA9A펜", A_1),
          RptMgrErrorHandler.b("쾆낈벊\uD98C좎햐ꪒ얔삖ꢘ\uDA9A펜", A_1),
          RptMgrErrorHandler.b("쾆불늊\uD98C좎햐ꪒ얔삖ꢘ\uDA9A펜", A_1),
          RptMgrErrorHandler.b("쾆번뺊\uD98C좎얐ꪒ얔삖ꆘ\uDA9A펜", A_1),
          RptMgrErrorHandler.b("쾆번뺊\uD98C좎얐ꪒ잔삖ꆘ\uDA9A펜", A_1),
          RptMgrErrorHandler.b("쾆불뺊\uD98C좎얐ꪒ얔삖ꆘ\uDA9A펜", A_1),
          RptMgrErrorHandler.b("쪆몈뮊욌\uDC8E슐ꪒ얔삖ꢘ\uDA9A펜", A_1),
          RptMgrErrorHandler.b("쪆몈뮊욌\uDB8E슐ꪒ얔삖ꢘ\uDA9A펜", A_1),
          RptMgrErrorHandler.b("쪆몈뮊\uD88C\uDD8E슐ꪒ얔삖ꢘ\uDA9A펜", A_1),
          RptMgrErrorHandler.b("쪆몈뮊\uD98C\uDC8E슐ꪒ얔삖ꢘ\uDA9A펜", A_1),
          RptMgrErrorHandler.b("쪆몈뮊\uD98C힎슐ꪒ얔삖ꢘ\uDA9A펜", A_1),
          RptMgrErrorHandler.b("쪆몈뮊\uDC8C\uDC8E슐ꪒ얔삖ꢘ\uDA9A펜", A_1),
          RptMgrErrorHandler.b("쪆몈뮊\uDC8C\uDB8E슐ꪒ얔삖ꢘ\uDA9A펜", A_1),
          RptMgrErrorHandler.b("쪆몈뮊\uDE8C\uDC8E슐ꪒ얔삖ꢘ\uDA9A펜", A_1),
          RptMgrErrorHandler.b("쮆몈뮊\uD88C\uDD8E슐ꪒ얔삖ꢘ\uDA9A펜", A_1),
          RptMgrErrorHandler.b("쮆몈뮊욌\uDC8E슐ꪒ얔삖ꢘ\uDA9A펜", A_1),
          RptMgrErrorHandler.b("쮆몈뮊\uDC8C\uDC8E슐ꪒ얔삖ꢘ\uDA9A펜", A_1),
          RptMgrErrorHandler.b("쮆몈뮊\uDE8C\uDC8E슐ꪒ얔삖ꢘ\uDA9A펜", A_1),
          RptMgrErrorHandler.b("쮆몈뮊\uD98C\uDC8E슐ꪒ얔삖ꢘ\uDA9A펜", A_1),
          RptMgrErrorHandler.b("쮆몈뮊\uDA8C\uDD8E슐ꪒ얔삖ꢘ\uDA9A펜", A_1),
          RptMgrErrorHandler.b("쪆몈벊\uD98C\uDC8E슐ꪒ얔삖ꢘ\uDA9A펜", A_1),
          RptMgrErrorHandler.b("쪆몈벊\uD98C힎슐ꪒ얔삖ꢘ\uDA9A펜", A_1),
          RptMgrErrorHandler.b("쮆몈벊\uD98C\uDC8E슐ꪒ얔삖ꢘ\uDA9A펜", A_1),
          RptMgrErrorHandler.b("펆릈뺊\uD98C\uDC8E슐ꪒ얔삖ꢘ\uDA9A펜", A_1),
          RptMgrErrorHandler.b("쾆낈뎊\uD88C첎햐ꪒ얔삖겘\uDA9A펜", A_1),
          RptMgrErrorHandler.b("쾆낈뎊\uDC8C쮎햐ꪒ얔삖겘\uDA9A펜", A_1),
          RptMgrErrorHandler.b("쾆낈뎊\uDE8C쮎햐ꪒ얔삖겘\uDA9A펜", A_1),
          RptMgrErrorHandler.b("쾆낈뎊욌좎햐ꪒ얔삖겘\uDA9A펜", A_1),
          RptMgrErrorHandler.b("쾆낈뎊\uD88C첎힐ꪒ얔삖꾘\uDA9A펜", A_1),
          RptMgrErrorHandler.b("쾆낈뎊\uDC8C쮎힐ꪒ얔삖꾘\uDA9A펜", A_1),
          RptMgrErrorHandler.b("쾆낈뎊\uDE8C쮎힐ꪒ얔삖꾘\uDA9A펜", A_1),
          RptMgrErrorHandler.b("쾆낈뎊욌좎힐ꪒ얔삖꾘\uDA9A펜", A_1),
          RptMgrErrorHandler.b("쾆낈뎊\uD88C첎\uD990ꪒ얔삖꺘\uDA9A펜", A_1),
          RptMgrErrorHandler.b("쾆낈뎊\uDC8C쮎\uD990ꪒ얔삖꺘\uDA9A펜", A_1),
          RptMgrErrorHandler.b("쾆낈뎊\uDE8C쮎\uD990ꪒ얔삖꺘\uDA9A펜", A_1),
          RptMgrErrorHandler.b("쾆낈뎊욌좎\uD990ꪒ얔삖꺘\uDA9A펜", A_1),
          RptMgrErrorHandler.b("쾆낈뎊\uD88C첎햐ꪒ얔삖겘\uD99A펜", A_1),
          RptMgrErrorHandler.b("쾆낈뎊\uDC8C쮎햐ꪒ얔삖겘\uD99A펜", A_1),
          RptMgrErrorHandler.b("쾆낈뎊\uDE8C쮎햐ꪒ얔삖겘\uD99A펜", A_1),
          RptMgrErrorHandler.b("쾆낈뎊욌좎햐ꪒ얔삖겘\uD99A펜", A_1),
          RptMgrErrorHandler.b("쾆낈뎊\uD88C첎힐ꪒ얔삖꾘\uD99A펜", A_1),
          RptMgrErrorHandler.b("쾆낈뎊\uDC8C쮎힐ꪒ얔삖꾘\uD99A펜", A_1),
          RptMgrErrorHandler.b("쾆낈뎊\uDE8C쮎힐ꪒ얔삖꾘\uD99A펜", A_1),
          RptMgrErrorHandler.b("쾆낈뎊욌좎힐ꪒ얔삖꾘\uD99A펜", A_1),
          RptMgrErrorHandler.b("쾆낈뎊\uD88C첎\uD990ꪒ얔삖꺘\uD99A펜", A_1),
          RptMgrErrorHandler.b("쾆낈뎊\uDC8C쮎\uD990ꪒ얔삖꺘\uD99A펜", A_1),
          RptMgrErrorHandler.b("쾆낈뎊\uDE8C쮎\uD990ꪒ얔삖꺘\uD99A펜", A_1),
          RptMgrErrorHandler.b("쾆낈뎊욌좎\uD990ꪒ얔삖꺘\uD99A펜", A_1),
          RptMgrErrorHandler.b("쾆낈늊\uDC8C쮎햐ꪒ얔삖겘\uDA9A펜", A_1),
          RptMgrErrorHandler.b("쾆낈늊욌좎햐ꪒ얔삖겘\uDA9A펜", A_1),
          RptMgrErrorHandler.b("쾆낈늊\uD88C첎햐ꪒ얔삖겘\uDA9A펜", A_1),
          RptMgrErrorHandler.b("쾆낈늊\uDC8C쮎\uD990ꪒ얔삖꺘\uDA9A펜", A_1),
          RptMgrErrorHandler.b("쾆낈늊욌좎\uD990ꪒ얔삖꺘\uDA9A펜", A_1),
          RptMgrErrorHandler.b("쾆낈늊\uD88C첎\uD990ꪒ얔삖꺘\uDA9A펜", A_1),
          RptMgrErrorHandler.b("쾆낈늊\uDC8C쮎햐ꪒ얔삖겘\uD99A펜", A_1),
          RptMgrErrorHandler.b("쾆낈늊욌좎햐ꪒ얔삖겘\uD99A펜", A_1),
          RptMgrErrorHandler.b("쾆낈늊\uD88C첎햐ꪒ얔삖겘\uD99A펜", A_1),
          RptMgrErrorHandler.b("쾆낈늊\uDC8C쮎\uD990ꪒ얔삖꺘\uD99A펜", A_1),
          RptMgrErrorHandler.b("쾆낈늊욌좎\uD990ꪒ얔삖꺘\uD99A펜", A_1),
          RptMgrErrorHandler.b("쾆낈늊\uD88C첎\uD990ꪒ얔삖꺘\uD99A펜", A_1),
          RptMgrErrorHandler.b("쪆뮈뺊욌\uDC8E슐ꪒ얔삖ꢘ\uDA9A펜", A_1),
          RptMgrErrorHandler.b("쪆뮈뺊욌\uDB8E슐ꪒ얔삖ꢘ\uDA9A펜", A_1),
          RptMgrErrorHandler.b("쪆뮈뺊\uD88C\uDD8E슐ꪒ얔삖ꢘ\uDA9A펜", A_1),
          RptMgrErrorHandler.b("쪆뮈뺊\uDC8C\uDC8E슐ꪒ얔삖ꢘ\uDA9A펜", A_1),
          RptMgrErrorHandler.b("쪆뮈뺊\uDC8C\uDB8E슐ꪒ얔삖ꢘ\uDA9A펜", A_1),
          RptMgrErrorHandler.b("쪆뮈뺊\uDE8C\uDC8E슐ꪒ얔삖ꢘ\uDA9A펜", A_1),
          RptMgrErrorHandler.b("쪆뮈뺊\uD88C\uDD8E슐ꪒ얔삖ꢘ\uD99A펜", A_1),
          RptMgrErrorHandler.b("쪆뮈뺊욌\uDC8E슐ꪒ얔삖ꢘ\uD99A펜", A_1),
          RptMgrErrorHandler.b("쪆뮈뺊\uDC8C\uDC8E슐ꪒ얔삖ꢘ\uD99A펜", A_1),
          RptMgrErrorHandler.b("쪆뮈뺊\uDE8C\uDC8E슐ꪒ얔삖ꢘ\uD99A펜", A_1),
          RptMgrErrorHandler.b("쪆뮈뺊\uDB8C\uDD8E슐ꪒ얔삖ꢘ\uD89A펜", A_1)
        }.Contains(A_0);
      default:
        goto case 1;
    }
  }

  private static bool b(CodeplugData A_0)
  {
    int num1;
    bool flag;
    short num2;
    switch (0)
    {
      case 0:
label_2:
        flag = false;
        num2 = (short) 3;
        num1 = (int) (IntPtr) num2;
        goto default;
      default:
        while (true)
        {
          switch (num1)
          {
            case 0:
              goto label_12;
            case 1:
              goto label_10;
            case 2:
              flag = (FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation).FrequencyRanges.RadInfoFrequencyRangesAllowInvalidFrequencies_A12493Value;
              break;
            case 3:
              if (A_0._data == null)
              {
                num2 = (short) 2;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              num2 = (short) 24634;
              int num3 = (int) num2;
              num2 = (short) 24634;
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
                  flag = A_0._data.AllowInvalidFrequency.Value;
                  num2 = (short) 0;
                  num1 = (int) (IntPtr) num2;
                  continue;
              }
              break;
            default:
              goto label_2;
          }
          num2 = (short) 1;
          num1 = (int) (IntPtr) num2;
        }
label_10:
        num2 = (short) 1;
        if (num2 == (short) 0)
          ;
        num2 = (short) 0;
label_12:
        return flag;
    }
  }

  private static bool a(CodeplugData A_0)
  {
    int num1 = 0;
    switch (num1)
    {
      default:
        bool flag;
        short num2;
        switch (0)
        {
          case 0:
label_3:
            flag = true;
            num2 = (short) 0;
            num1 = (int) (IntPtr) num2;
            goto default;
          default:
            int num3;
            System.Collections.Generic.List<APXRadioSystem>.Enumerator enumerator1;
            TrunkingSystemRecset feature;
            int num4;
            IEnumerator<FeatureNode> enumerator2;
            while (true)
            {
              switch (num1)
              {
                case 0:
                  if (A_0._data == null)
                  {
                    num2 = (short) 6;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num3 = -1;
                  enumerator1 = A_0._data.APXRadioSystems.GetEnumerator();
                  num2 = (short) 2;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 1:
                  num4 = ((AcpField<int>) ((Motorola.MackinawCPS.CoreFeatures.TrunkingSystem.TrunkingSystem) ((Recordset) feature)[0]).General.TrkSysGeneralSystemType_A9252).Value;
                  num2 = (short) 5;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 2:
                  goto label_12;
                case 3:
                  if (((Recordset) feature).Count > 0)
                  {
                    num2 = (short) 1;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 5;
                case 4:
                  goto label_31;
                case 5:
                  enumerator2 = ((Collection<FeatureNode>) feature).GetEnumerator();
                  num2 = (short) 4;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 6:
                  num4 = -1;
                  feature = FeatureManager.GetFeature(2064) as TrunkingSystemRecset;
                  num2 = (short) 0;
                  num2 = (short) 1;
                  if (num2 == (short) 0)
                    ;
                  num2 = (short) 3;
                  num1 = (int) (IntPtr) num2;
                  continue;
                default:
                  goto label_3;
              }
            }
label_12:
            try
            {
              num2 = (short) 3;
              int num5 = (int) (IntPtr) num2;
              while (true)
              {
                APXRadioSystem current;
                AstroSystemType? systemType;
                AstroSystemType astroSystemType;
                switch (num5)
                {
                  case 1:
                  case 10:
                    goto label_52;
                  case 2:
                    if (num3 == -1)
                    {
                      num2 = (short) 11;
                      num5 = (int) (IntPtr) num2;
                      continue;
                    }
                    num2 = (short) 8;
                    num5 = (int) (IntPtr) num2;
                    continue;
                  case 3:
                    switch (0)
                    {
                      case 0:
                        break;
                      default:
                        continue;
                    }
                    break;
                  case 4:
                    num2 = (short) 1;
                    num5 = (int) (IntPtr) num2;
                    continue;
                  case 5:
                    if (systemType.GetValueOrDefault() == astroSystemType & systemType.HasValue)
                    {
                      num2 = (short) 6;
                      num5 = (int) (IntPtr) num2;
                      continue;
                    }
                    break;
                  case 6:
                    num2 = (short) 2;
                    num5 = (int) (IntPtr) num2;
                    continue;
                  case 7:
                    flag = false;
                    num2 = (short) 10;
                    num5 = (int) (IntPtr) num2;
                    continue;
                  case 8:
                    if (Convert.ToInt32((object) current.SystemSubType) != num3)
                    {
                      num2 = (short) 7;
                      num5 = (int) (IntPtr) num2;
                      continue;
                    }
                    break;
                  case 9:
                    if (!enumerator1.MoveNext())
                    {
                      num2 = (short) 4;
                      num5 = (int) (IntPtr) num2;
                      continue;
                    }
                    current = enumerator1.Current;
                    systemType = current.SystemType;
                    astroSystemType = (AstroSystemType) 0;
                    num2 = (short) 5;
                    num5 = (int) (IntPtr) num2;
                    continue;
                  case 11:
                    num3 = Convert.ToInt32((object) current.SystemSubType);
                    num2 = (short) 0;
                    num5 = (int) (IntPtr) num2;
                    continue;
                }
                num2 = (short) 9;
                num5 = (int) (IntPtr) num2;
              }
            }
            finally
            {
              enumerator1.Dispose();
            }
label_31:
            try
            {
              num2 = (short) 0;
              int num6 = (int) (IntPtr) num2;
              while (true)
              {
                switch (num6)
                {
                  case 0:
                    switch (0)
                    {
                      case 0:
                        break;
                      default:
                        continue;
                    }
                    break;
                  case 1:
                    num2 = (short) 4;
                    num6 = (int) (IntPtr) num2;
                    continue;
                  case 2:
                    flag = false;
                    num2 = (short) 5;
                    num6 = (int) (IntPtr) num2;
                    continue;
                  case 3:
                    if (enumerator2.MoveNext())
                    {
                      num2 = (short) 6;
                      num6 = (int) (IntPtr) num2;
                      continue;
                    }
                    num2 = (short) 1;
                    num6 = (int) (IntPtr) num2;
                    continue;
                  case 4:
                  case 5:
                    goto label_52;
                  case 6:
                    if (((AcpField<int>) ((Motorola.MackinawCPS.CoreFeatures.TrunkingSystem.TrunkingSystem) enumerator2.Current).General.TrkSysGeneralSystemType_A9252).Value != num4)
                    {
                      num2 = (short) 2;
                      num6 = (int) (IntPtr) num2;
                      continue;
                    }
                    break;
                }
                num2 = (short) 3;
                num6 = (int) (IntPtr) num2;
              }
            }
            finally
            {
              short num7 = 2;
              int num8 = (int) (IntPtr) num7;
              while (true)
              {
                switch (num8)
                {
                  case 0:
                    goto label_50;
                  case 1:
                    enumerator2.Dispose();
                    num7 = (short) 0;
                    num8 = (int) (IntPtr) num7;
                    continue;
                  case 2:
                    num7 = (short) 24971;
                    int num9 = (int) num7;
                    num7 = (short) 24971;
                    int num10 = (int) num7;
                    switch (num9 == num10 ? 1 : 0)
                    {
                      case 0:
                      case 2:
                        break;
                      default:
                        num7 = (short) 0;
                        if (num7 == (short) 0)
                          ;
                        switch (0)
                        {
                          case 0:
                            break;
                          default:
                            continue;
                        }
                        break;
                    }
                    break;
                }
                if (enumerator2 != null)
                {
                  num7 = (short) 1;
                  num8 = (int) (IntPtr) num7;
                }
                else
                  break;
              }
label_50:;
            }
label_52:
            return flag;
        }
    }
  }

  private static bool b(FlashcodeTable A_0, CodeplugData A_1, CodeplugData A_2)
  {
    int A_1_1 = 19;
    string purchasedFlashcode1 = A_1.purchasedFlashcode;
    string purchasedFlashcode2 = A_2.purchasedFlashcode;
    bool optionFound = false;
    if (A_0.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("톕ꂗ꾙ꮛ", A_1_1), purchasedFlashcode1, ref optionFound))
      goto label_2;
label_1:
    short num = 0;
    return !A_0.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("톕ꂗ꾙ꮛ", A_1_1), purchasedFlashcode2, ref optionFound);
label_2:
    num = (short) 26579;
    switch ((short) 26579 == num ? 1 : 0)
    {
      case 0:
      case 2:
        goto label_1;
      default:
        num = (short) 1;
        if (num == (short) 0)
          ;
        num = (short) 0;
        if (num == (short) 0)
          ;
        return true;
    }
  }

  private static bool a(FlashcodeTable A_0, string A_1, bool A_2, bool A_3)
  {
    int A_1_1 = 4;
    int num1;
    bool optionFound;
    bool flag;
    short num2;
    switch (0)
    {
      case 0:
label_2:
        optionFound = false;
        flag = true;
        num2 = (short) 34;
        num1 = (int) (IntPtr) num2;
        goto default;
      default:
        while (true)
        {
          switch (num1)
          {
            case 0:
              if (!A_0.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("삆좈뮊붌벎ꖐꆒ", A_1_1), A_1, ref optionFound))
              {
                num2 = (short) 36;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 52;
            case 1:
              num2 = (short) 2;
              num1 = (int) (IntPtr) num2;
              continue;
            case 2:
              if (!A_0.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("횆좈뮊붌몎Ꚑꎒ", A_1_1), A_1, ref optionFound))
              {
                num2 = (short) 38;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 27;
            case 3:
              num2 = (short) 28;
              num1 = (int) (IntPtr) num2;
              continue;
            case 4:
              if (!A_0.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("삆좈뮊붌벎ꆐꪒ", A_1_1), A_1, ref optionFound))
              {
                num2 = (short) 45;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 8;
            case 5:
              num2 = (short) 49;
              num1 = (int) (IntPtr) num2;
              continue;
            case 6:
              num2 = (short) 30;
              num1 = (int) (IntPtr) num2;
              continue;
            case 7:
              num2 = (short) 19;
              num1 = (int) (IntPtr) num2;
              continue;
            case 8:
              flag = false;
              num2 = (short) 5;
              num1 = (int) (IntPtr) num2;
              continue;
            case 9:
              num2 = (short) 4;
              num1 = (int) (IntPtr) num2;
              continue;
            case 10:
              if (!A_0.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("횆좈뮊붌몎ꚐꞒ", A_1_1), A_1, ref optionFound))
              {
                num2 = (short) 7;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 11;
            case 11:
              flag = false;
              num2 = (short) 17;
              num1 = (int) (IntPtr) num2;
              continue;
            case 12:
              num2 = (short) 35;
              num1 = (int) (IntPtr) num2;
              continue;
            case 13:
              if (!A_0.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("삆좈뮊붌벎ꆐꖒ", A_1_1), A_1, ref optionFound))
              {
                num2 = (short) 51;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 52;
            case 14:
              num2 = (short) 24;
              num1 = (int) (IntPtr) num2;
              continue;
            case 15:
              num2 = (short) 10;
              num1 = (int) (IntPtr) num2;
              continue;
            case 16 /*0x10*/:
              num2 = (short) 13;
              num1 = (int) (IntPtr) num2;
              continue;
            case 17:
              goto label_82;
            case 18:
              if (A_0.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("삆좈뮊붌벎ꖐꖒ", A_1_1), A_1, ref optionFound))
              {
                num2 = (short) 8;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 5;
            case 19:
              if (!A_0.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("횆좈뮊붌몎ꚐꚒ", A_1_1), A_1, ref optionFound))
              {
                num2 = (short) 6;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 11;
            case 20:
              num2 = (short) 25;
              num1 = (int) (IntPtr) num2;
              continue;
            case 21:
              if (flag)
              {
                num2 = (short) 12;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 5;
            case 22:
              num2 = (short) 21;
              num1 = (int) (IntPtr) num2;
              continue;
            case 23:
              num2 = (short) 26;
              num1 = (int) (IntPtr) num2;
              continue;
            case 24:
              if (!A_0.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("삆좈뮊붌벎ꖐꊒ", A_1_1), A_1, ref optionFound))
              {
                num2 = (short) 31 /*0x1F*/;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 52;
            case 25:
              if (A_0.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("횆좈뮊붌몎Ꚑꆒ", A_1_1), A_1, ref optionFound))
              {
                num2 = (short) 27;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 23;
            case 26:
              if (flag)
              {
                num2 = (short) 3;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_82;
            case 27:
              flag = false;
              num2 = (short) 23;
              num1 = (int) (IntPtr) num2;
              continue;
            case 28:
              if (A_0.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("횆좈뮊붌몎Ꚑꪒ", A_1_1), A_1, ref optionFound))
              {
                num2 = (short) 15;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_82;
            case 29:
              num2 = (short) 48 /*0x30*/;
              num1 = (int) (IntPtr) num2;
              continue;
            case 30:
              if (A_0.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("횆좈뮊붌몎Ꚑꖒ", A_1_1), A_1, ref optionFound))
              {
                num2 = (short) 11;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_82;
            case 31 /*0x1F*/:
              num2 = (short) 0;
              num1 = (int) (IntPtr) num2;
              continue;
            case 32 /*0x20*/:
              num2 = (short) 43;
              num1 = (int) (IntPtr) num2;
              continue;
            case 33:
              if (A_0.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("삆좈뮊붌벎ꖐꚒ", A_1_1), A_1, ref optionFound))
              {
                num2 = (short) 29422;
                int num3 = (int) num2;
                num2 = (short) 29422;
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
                    num2 = (short) 52;
                    num1 = (int) (IntPtr) num2;
                    continue;
                }
              }
              else
                goto case 22;
              break;
            case 34:
              if (A_2)
              {
                num2 = (short) 46;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 47;
            case 35:
              if (A_0.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("삆좈뮊붌몎Ꚑꪒ", A_1_1), A_1, ref optionFound))
              {
                num2 = (short) 40;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 5;
            case 36:
              num2 = (short) 33;
              num1 = (int) (IntPtr) num2;
              continue;
            case 37:
              if (!A_0.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("삆좈뮊붌벎ꖐꂒ", A_1_1), A_1, ref optionFound))
              {
                num2 = (short) 32 /*0x20*/;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 8;
            case 38:
              num2 = (short) 44;
              num1 = (int) (IntPtr) num2;
              continue;
            case 39:
              if (flag)
              {
                num2 = (short) 29;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 5;
            case 40:
              num2 = (short) 41;
              num1 = (int) (IntPtr) num2;
              continue;
            case 41:
              if (A_0.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("삆좈뮊붌벎ꆐꮒ", A_1_1), A_1, ref optionFound))
                goto case 8;
              break;
            case 42:
              num2 = (short) 18;
              num1 = (int) (IntPtr) num2;
              continue;
            case 43:
              if (!A_0.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("삆좈뮊붌벎ꖐꞒ", A_1_1), A_1, ref optionFound))
              {
                num2 = (short) 42;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 8;
            case 44:
              if (!A_0.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("횆좈뮊붌몎Ꚑꊒ", A_1_1), A_1, ref optionFound))
              {
                num2 = (short) 20;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 27;
            case 45:
              num2 = (short) 37;
              num1 = (int) (IntPtr) num2;
              continue;
            case 46:
              flag = false;
              num2 = (short) 0;
              num2 = (short) 47;
              num1 = (int) (IntPtr) num2;
              continue;
            case 47:
              num2 = (short) 39;
              num1 = (int) (IntPtr) num2;
              continue;
            case 48 /*0x30*/:
              if (!A_3)
              {
                num2 = (short) 16 /*0x10*/;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 5;
            case 49:
              if (flag & A_3)
              {
                num2 = (short) 1;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_82;
            case 50:
              if (!A_0.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("삆좈뮊붌벎ꆐ꒒", A_1_1), A_1, ref optionFound))
              {
                num2 = (short) 1;
                if (num2 == (short) 0)
                  ;
                num2 = (short) 14;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 52;
            case 51:
              num2 = (short) 50;
              num1 = (int) (IntPtr) num2;
              continue;
            case 52:
              flag = false;
              num2 = (short) 22;
              num1 = (int) (IntPtr) num2;
              continue;
            default:
              goto label_2;
          }
          num2 = (short) 9;
          num1 = (int) (IntPtr) num2;
        }
label_82:
        return flag;
    }
  }

  private static void b(FlashcodeTable A_0, string A_1, string A_2, ref bool A_3)
  {
    int A_1_1 = 10;
    int num1 = 0;
    switch (num1)
    {
      default:
        bool optionFound;
        bool flag1;
        bool flag2;
        bool flag3;
        bool flag4;
        short num2;
        switch (0)
        {
          case 0:
label_3:
            optionFound = false;
            flag1 = true;
            flag2 = true;
            flag3 = true;
            flag4 = true;
            num2 = (short) 17;
            num1 = (int) (IntPtr) num2;
            goto default;
          default:
            while (true)
            {
              switch (num1)
              {
                case 0:
                  num2 = (short) 1;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 1:
                  num2 = (short) -27045;
                  int num3 = (int) num2;
                  num2 = (short) -27045;
                  int num4 = (int) num2;
                  switch (num3 == num4 ? 1 : 0)
                  {
                    case 0:
                    case 2:
                      goto label_27;
                    default:
                      num2 = (short) 0;
                      if (num2 == (short) 0)
                        ;
                      if (!A_0.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("\uDC8C캎ꆐꎒꂔꆖꂘ", A_1_1), A_2, ref optionFound))
                      {
                        num2 = (short) 14;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto label_24;
                  }
                case 2:
                  num2 = (short) 15;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 3:
                  if (A_0.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("\uDC8C캎ꆐꎒꂔꂖꢘ", A_1_1), A_1, ref optionFound))
                  {
                    num2 = (short) 12;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 2;
                case 4:
                  flag3 = false;
                  num2 = (short) 2;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 5:
                  if (!A_0.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("\uDC8C캎ꆐꎒꂔꂖꮘ", A_1_1), A_2, ref optionFound))
                  {
                    num2 = (short) 19;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_34;
                case 6:
label_24:
                  num2 = (short) 8;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 7:
                  flag2 = false;
                  num2 = (short) 10;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 8:
                  if (A_0.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("\uDC8C캎ꆐꎒꂔꂖꦘ", A_1_1), A_1, ref optionFound))
                  {
                    num2 = (short) 13;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 10;
                case 9:
                  goto label_34;
                case 10:
                  num2 = (short) 3;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 11:
                  num2 = (short) 1;
                  if (num2 == (short) 0)
                    ;
                  if (!A_0.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("\uDC8C캎ꆐꎒꂔꂖꦘ", A_1_1), A_2, ref optionFound))
                  {
                    num2 = (short) 0;
                    num2 = (short) 7;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 10;
                case 12:
label_27:
                  num2 = (short) 16 /*0x10*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 13:
                  num2 = (short) 11;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 14:
                  flag1 = false;
                  num2 = (short) 6;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 15:
                  if (A_0.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("\uDC8C캎ꆐꎒꂔꂖꮘ", A_1_1), A_1, ref optionFound))
                  {
                    num2 = (short) 18;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_34;
                case 16 /*0x10*/:
                  if (!A_0.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("\uDC8C캎ꆐꎒꂔꂖꢘ", A_1_1), A_2, ref optionFound))
                  {
                    num2 = (short) 4;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 2;
                case 17:
                  if (A_0.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("\uDC8C캎ꆐꎒꂔꆖꂘ", A_1_1), A_1, ref optionFound))
                  {
                    num2 = (short) 0;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 6;
                case 18:
                  num2 = (short) 5;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 19:
                  flag4 = false;
                  num2 = (short) 9;
                  num1 = (int) (IntPtr) num2;
                  continue;
                default:
                  goto label_3;
              }
            }
label_34:
            A_3 = flag1 & flag2 & flag3 & flag4;
            return;
        }
    }
  }

  private static void a(FlashcodeTable A_0, string A_1, string A_2, ref bool A_3)
  {
    int A_1_1 = 2;
    int num1 = 0;
    switch (num1)
    {
      default:
        bool optionFound;
        bool flag1;
        bool flag2;
        bool flag3;
        bool flag4;
        short num2;
        switch (0)
        {
          case 0:
label_3:
            optionFound = false;
            flag1 = true;
            flag2 = true;
            flag3 = true;
            flag4 = true;
            num2 = (short) 17;
            num1 = (int) (IntPtr) num2;
            goto default;
          default:
            while (true)
            {
              switch (num1)
              {
                case 0:
                  num2 = (short) 1;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 1:
                  num2 = (short) 30271;
                  int num3 = (int) num2;
                  num2 = (short) 30271;
                  int num4 = (int) num2;
                  switch (num3 == num4 ? 1 : 0)
                  {
                    case 0:
                    case 2:
                      goto label_28;
                    default:
                      num2 = (short) 0;
                      if (num2 == (short) 0)
                        ;
                      if (!A_0.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("슄욆릈뮊뾌뮎ꖐ", A_1_1), A_2, ref optionFound))
                      {
                        num2 = (short) 1;
                        if (num2 == (short) 0)
                          ;
                        num2 = (short) 14;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto label_25;
                  }
                case 2:
                  num2 = (short) 15;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 3:
                  if (A_0.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("슄욆릈뮊뺌뮎ꂐ", A_1_1), A_1, ref optionFound))
                  {
                    num2 = (short) 12;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 2;
                case 4:
                  flag3 = false;
                  num2 = (short) 2;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 5:
                  if (!A_0.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("슄욆릈뮊뺌뮎꒐", A_1_1), A_2, ref optionFound))
                  {
                    num2 = (short) 19;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_34;
                case 6:
label_25:
                  num2 = (short) 8;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 7:
                  flag2 = false;
                  num2 = (short) 10;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 8:
                  if (A_0.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("슄욆릈뮊뺌뾎Ꞑ", A_1_1), A_1, ref optionFound))
                  {
                    num2 = (short) 13;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 10;
                case 9:
                  goto label_34;
                case 10:
                  num2 = (short) 3;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 11:
                  if (!A_0.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("슄욆릈뮊뺌뾎Ꞑ", A_1_1), A_2, ref optionFound))
                  {
                    num2 = (short) 0;
                    num2 = (short) 7;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 10;
                case 12:
label_28:
                  num2 = (short) 16 /*0x10*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 13:
                  num2 = (short) 11;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 14:
                  flag1 = false;
                  num2 = (short) 6;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 15:
                  if (A_0.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("슄욆릈뮊뺌뮎꒐", A_1_1), A_1, ref optionFound))
                  {
                    num2 = (short) 18;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_34;
                case 16 /*0x10*/:
                  if (!A_0.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("슄욆릈뮊뺌뮎ꂐ", A_1_1), A_2, ref optionFound))
                  {
                    num2 = (short) 4;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 2;
                case 17:
                  if (A_0.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("슄욆릈뮊뾌뮎ꖐ", A_1_1), A_1, ref optionFound))
                  {
                    num2 = (short) 0;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 6;
                case 18:
                  num2 = (short) 5;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 19:
                  flag4 = false;
                  num2 = (short) 9;
                  num1 = (int) (IntPtr) num2;
                  continue;
                default:
                  goto label_3;
              }
            }
label_34:
            A_3 = flag1 & flag2 & flag3 & flag4;
            return;
        }
    }
  }

  internal static bool AllowFrequencyClonePortable(
    FlashcodeTable FcodeTable,
    CodeplugData srcData,
    CodeplugData targetData)
  {
    int A_1 = 13;
    int num1 = 0;
    switch (num1)
    {
      default:
        bool optionFound;
        bool A_3;
        short num2;
        switch (0)
        {
          case 0:
label_3:
            optionFound = false;
            A_3 = false;
            num2 = (short) 197;
            num1 = (int) (IntPtr) num2;
            goto default;
          default:
            while (true)
            {
              string purchasedFlashcode1;
              string purchasedFlashcode2;
              string modelNumber;
              string str;
              switch (num1)
              {
                case 0:
                  num2 = (short) 142;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 1:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗궙꺛", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 192 /*0xC0*/;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 180;
                case 2:
                  num2 = (short) 83;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 3:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗궙겛", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 147;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 170;
                case 4:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗궙ꦛ", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 77;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 191;
                case 5:
                  num2 = (short) 120;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 6:
                  num2 = (short) 30;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 7:
                  num2 = (short) 44;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 8:
                  num2 = (short) 33;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 9:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗궙ꖛ", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 92;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  A_3 = false;
                  num2 = (short) 103;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 10:
                  num2 = (short) 53;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 11:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗궙겛", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 42;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 81;
                case 12:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗궙꺛", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 104;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_34;
                case 13:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗겙ꖛ", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 130;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 2;
                case 14:
                  num2 = (short) 145;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 15:
                  num2 = (short) 172;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 16 /*0x10*/:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗궙ꦛ", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 105;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 191;
                case 17:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗궙ꢛ", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 24;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 56;
                case 18:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗궙궛", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 193;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 129;
                case 19:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗궙겛", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 119;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 171;
                case 20:
                  num2 = (short) 111;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 21:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗궙ꪛ", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 150;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 191;
                case 22:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗궙궛", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 139;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 62;
                case 23:
                  num2 = (short) 98;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 24:
                  num2 = (short) 70;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 25:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗겙ꖛ", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 89;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_219;
                case 26:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗겙ꖛ", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 146;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 93;
                case 27:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗겙ꖛ", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 43;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 107;
                case 28:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗궙꾛", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 151;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 2;
                case 29:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗궙ꦛ", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 57;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 114;
                case 30:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗궙겛", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 85;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 56;
                case 31 /*0x1F*/:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗궙ꪛ", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 88;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 51;
                case 32 /*0x20*/:
                  num2 = (short) 25;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 33:
                  num2 = (short) 0;
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗궙ꪛ", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 15;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 116;
                case 34:
                  num2 = (short) 26;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 35:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗궙꺛", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 47;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 182;
                case 36:
                  num2 = (short) 58;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 37:
                  A_3 = true;
                  num2 = (short) 112 /*0x70*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 38:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗궙겛", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 8;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 116;
                case 39:
                  num2 = (short) 55;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 40:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗궙꾛", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 109;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_219;
                case 41:
                  if (modelNumber == str)
                  {
                    num2 = (short) 10;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_84;
                case 42:
                  num2 = (short) 82;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 43:
                  num2 = (short) 91;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 44:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗궙ꢛ", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 6;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 191;
                case 45:
                  num2 = (short) 144 /*0x90*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 46:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗궙꺛", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 96 /*0x60*/;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 51;
                case 47:
                  num2 = (short) 136;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 48 /*0x30*/:
                  num2 = (short) 118;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 49:
                  num2 = (short) 68;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 50:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗궙ꪛ", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 95;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  break;
                case 51:
                  num2 = (short) 169;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 52:
                  num2 = (short) 102;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 53:
                  if (AllowCloning.IsModelSingleBand(modelNumber))
                  {
                    num2 = (short) 37;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_84;
                case 54:
                case 66:
                case 87:
                case 100:
                case 103:
                case 112 /*0x70*/:
                case 128 /*0x80*/:
                case 178:
                  goto label_302;
                case 55:
                  if (UtilityMack.IsFreonCodeplug(modelNumber))
                  {
                    AllowCloning.b(FcodeTable, purchasedFlashcode2, purchasedFlashcode1, ref A_3);
                    num2 = (short) 100;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 121;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 56:
                  num2 = (short) 188;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 57:
                  num2 = (short) 67;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 58:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗궙꾛", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 115;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 191;
                case 59:
                  num2 = (short) 125;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 60:
                  num2 = (short) 198;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 61:
                  num2 = (short) 31 /*0x1F*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 62:
                  num2 = (short) 35;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 63 /*0x3F*/:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗궙ꦛ", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 49;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 20;
                case 64 /*0x40*/:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗궙ꦛ", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 56;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 191;
                case 65:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗궙꾛", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 135;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_34;
                case 67:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗궙꺛", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 176 /*0xB0*/;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 138;
                case 68:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗궙ꖛ", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 20;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 81;
                case 69:
                  num2 = (short) 50;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 70:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗궙궛", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 7;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 6;
                case 71:
                  num2 = (short) 29;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 72:
                  num2 = (short) 131;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 73:
                  num2 = (short) 134;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 74:
                  num2 = (short) 126;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 75:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗궙궛", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 143;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 114;
                case 76:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗궙ꢛ", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 116;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 191;
                case 77:
                  num2 = (short) 1;
                  if (num2 == (short) 0)
                    goto label_219;
                  goto label_219;
                case 78:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗궙꾛", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 123;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 162;
                case 79:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗궙겛", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 36;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 115;
                case 80 /*0x50*/:
                  num2 = (short) 194;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 81:
                  A_3 = true;
                  num2 = (short) 178;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 82:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗궙ꢛ", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 97;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 170;
                case 83:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗궙겛", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 72;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 156;
                case 84:
                  num2 = (short) 16 /*0x10*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 85:
                  num2 = (short) 98;
                  int num3 = (int) num2;
                  num2 = (short) 98;
                  int num4 = (int) num2;
                  switch (num3 == num4 ? 1 : 0)
                  {
                    case 0:
                    case 2:
                      goto label_173;
                    default:
                      num2 = (short) 0;
                      if (num2 == (short) 0)
                        ;
                      num2 = (short) 64 /*0x40*/;
                      num1 = (int) (IntPtr) num2;
                      continue;
                  }
                case 86:
                  if (modelNumber == str)
                  {
                    num2 = (short) 45;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_302;
                case 88:
                  num2 = (short) 27;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 89:
                  num2 = (short) 4;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 90:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗겙ꖛ", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 84;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 105;
                case 91:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗궙ꪛ", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 107;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 191;
                case 92:
                  num2 = (short) 168;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 93:
                  num2 = (short) 110;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 94:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗궙궛", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 80 /*0x50*/;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 32 /*0x20*/;
                case 95:
                  num2 = (short) 158;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 96 /*0x60*/:
                  num2 = (short) 108;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 97:
                  num2 = (short) 164;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 98:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗궙꾛", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) sbyte.MaxValue;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 191;
                case 99:
                  num2 = (short) 195;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 101:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗궙꾛", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 180;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 191;
                case 102:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗궙ꪛ", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 191;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_34;
                case 104:
                  num2 = (short) 65;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 105:
                  num2 = (short) 18;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 106:
                  num2 = (short) 174;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 107:
                  num2 = (short) 46;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 108:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗궙꾛", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 51;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 191;
                case 109:
                  num2 = (short) 94;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 110:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗궙겛", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 23;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case (int) sbyte.MaxValue;
                case 111:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗궙꺛", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 14;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  break;
                case 113:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗궙궛", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 186;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 56;
                case 114:
                  num2 = (short) 12;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 115:
                  num2 = (short) 13;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 116:
                  num2 = (short) 152;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 117:
                  num2 = (short) 189;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 118:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗궙겛", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 183;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 150;
                case 119:
                  num2 = (short) 166;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 120:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗궙ꢛ", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 34;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case (int) sbyte.MaxValue;
                case 121:
                  num2 = (short) 199;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 122:
                  num2 = (short) 63 /*0x3F*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 123:
                  num2 = (short) 137;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 124:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗궙궛", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 122;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 81;
                case 125:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗궙꺛", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 160 /*0xA0*/;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 48 /*0x30*/;
                case 126:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗궙ꪛ", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 0;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 191;
                case (int) sbyte.MaxValue:
                  num2 = (short) 132;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 129:
                  num2 = (short) 161;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 130:
                  num2 = (short) 159;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 131:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗궙ꦛ", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 185;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 156;
                case 132:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗겙ꖛ", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 196;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 129;
                case 133:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗궙ꢛ", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 93;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 191;
                case 134:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗궙ꖛ", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 9;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 39;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 135:
                  num2 = (short) 1;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 136:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗궙ꦛ", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 182;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 191;
                case 137:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗궙ꖛ", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 162;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 81;
                case 138:
                  num2 = (short) 75;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 139:
                  num2 = (short) 187;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 140:
                  modelNumber = srcData.modelNumber.Trim();
                  str = targetData.modelNumber.Trim();
                  purchasedFlashcode2 = srcData.purchasedFlashcode;
                  purchasedFlashcode1 = targetData.purchasedFlashcode;
                  num2 = (short) 41;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 141:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗겙ꖛ", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 52;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_34;
                case 142:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗궙꺛", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 148;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 116;
                case 143:
                  num2 = (short) 173;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 144 /*0x90*/:
                  if (AllowCloning.IsModelDualBand(modelNumber))
                  {
                    num2 = (short) 73;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_302;
                case 145:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗궙꺛", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 69;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 81;
                case 146:
                  num2 = (short) 133;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 147:
                  num2 = (short) 11;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 148:
                  num2 = (short) 76;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 149:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗궙꾛", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 129;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 191;
                case 150:
                  num2 = (short) 179;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 151:
                  num2 = (short) 79;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 152:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗궙궛", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 155;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_219;
                case 153:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗궙ꦛ", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 138;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 191;
                case 154:
                  num2 = (short) 28;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 155:
                  num2 = (short) 40;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 156:
                  num2 = (short) 38;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 157:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗궙궛", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 106;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 156;
                case 158:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗궙ꖛ", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 81;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  break;
                case 159:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗궙ꢛ", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 2;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 191;
                case 160 /*0xA0*/:
                  num2 = (short) 184;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 161:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗겙ꖛ", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 61;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 51;
                case 162:
                  num2 = (short) 3;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 163:
                  num2 = (short) 22;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 164:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗궙ꖛ", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 170;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 81;
                case 165:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗궙궛", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 181;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 20;
                case 166:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗궙ꦛ", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 171;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 191;
                case 167:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗궙꺛", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 60;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 150;
                case 168:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗겙ꖛ", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 5;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case (int) sbyte.MaxValue;
                case 169:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗궙겛", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 154;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 2;
                case 170:
                  num2 = (short) 165;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 171:
                  num2 = (short) 157;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 172:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗궙겛", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 74;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 0;
                case 173:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗궙ꪛ", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 114;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 191;
                case 174:
label_173:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗궙ꢛ", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 156;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 191;
                case 175:
                  num2 = (short) 78;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 176 /*0xB0*/:
                  num2 = (short) 153;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 177:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗궙ꦛ", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 190;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 129;
                case 179:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗궙꺛", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 71;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 114;
                case 180:
                  num2 = (short) 141;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 181:
                  num2 = (short) 124;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 182:
                  num2 = (short) 167;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 183:
                  num2 = (short) 21;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 184:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗궙ꢛ", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 48 /*0x30*/;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 191;
                case 185:
                  num2 = (short) 19;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 186:
                  num2 = (short) 17;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 187:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗궙ꪛ", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 62;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 191;
                case 188:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗궙궛", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 117;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 182;
                case 189:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗궙ꪛ", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 163;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 182;
                case 190:
                  num2 = (short) 90;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 191:
                  A_3 = true;
                  num2 = (short) 66;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 192 /*0xC0*/:
                  num2 = (short) 101;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 193:
                  num2 = (short) 149;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 194:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗궙꾛", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 32 /*0x20*/;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 191;
                case 195:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗겙ꖛ", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 175;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 81;
                case 196:
                  num2 = (short) 177;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 197:
                  if (!AllowCloning.b(srcData))
                  {
                    num2 = (short) 140;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  A_3 = true;
                  num2 = (short) 128 /*0x80*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 198:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗궙ꢛ", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 59;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 150;
                case 199:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("솏펑꒓ꚕ궗겙ꖛ", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 99;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 162;
                default:
                  goto label_3;
              }
              A_3 = false;
              num2 = (short) 54;
              num1 = (int) (IntPtr) num2;
              continue;
label_34:
              A_3 = false;
              num2 = (short) 87;
              num1 = (int) (IntPtr) num2;
              continue;
label_84:
              num2 = (short) 86;
              num1 = (int) (IntPtr) num2;
              continue;
label_219:
              num2 = (short) 113;
              num1 = (int) (IntPtr) num2;
            }
label_302:
            return A_3;
        }
    }
  }

  internal static bool AllowFrequencyCloneMobile(
    FlashcodeTable FcodeTable,
    CodeplugData srcData,
    CodeplugData targetData)
  {
    int A_1 = 11;
    int num1 = 0;
    switch (num1)
    {
      default:
        bool optionFound;
        bool A_3;
        short num2;
        switch (0)
        {
          case 0:
label_3:
            optionFound = false;
            A_3 = false;
            num2 = (short) 213;
            num1 = (int) (IntPtr) num2;
            goto default;
          default:
            while (true)
            {
              string purchasedFlashcode1;
              string purchasedFlashcode2;
              string modelNumber1;
              string modelNumber2;
              switch (num1)
              {
                case 0:
                  num2 = (short) 431;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 1:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕ겗ꢙ", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 254;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 403;
                case 2:
                  num2 = (short) 227;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 3:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕꢗꊙ", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 100;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 191;
                case 4:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꎕ꾗ꎙ", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 184;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_508;
                case 5:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕꢗ궙", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 355;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 304;
                case 6:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕꢗ겙", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 34;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 145;
                case 7:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕꢗ겙", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 226;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 264;
                case 8:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕꢗꎙ", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 414;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 191;
                case 9:
                  num2 = (short) 57;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 10:
                  num2 = (short) 120;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 11:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕ겗ꦙ", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 166;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 100;
                case 12:
                  num2 = (short) 387;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 13:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕ겗ꮙ", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 368;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 73;
                case 14:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕ겗겙", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 407;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 160 /*0xA0*/;
                case 15:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕ겗ꦙ", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 48 /*0x30*/;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 191;
                case 16 /*0x10*/:
                  num2 = (short) 397;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 17:
                case 71:
                case 94:
                case 123:
                case 164:
                case 171:
                case 172:
                case 188:
                case 203:
                case 248:
                case 286:
                case 294:
                  goto label_648;
                case 18:
                  if (!UtilityMack.IsFreonCodeplug(modelNumber2))
                  {
                    num2 = (short) 76;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  AllowCloning.a(FcodeTable, purchasedFlashcode1, purchasedFlashcode2, ref A_3);
                  num2 = (short) 164;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 19:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕꢗ궙", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 167;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 414;
                case 20:
                  num2 = (short) 26;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 21:
                  if (AllowCloning.IsModelDualBand(modelNumber2))
                  {
                    num2 = (short) 37;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_403;
                case 22:
                  num2 = (short) 415;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 23:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓꒕겗꺙", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 70;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 308;
                case 24:
                  num2 = (short) 147;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 25:
                  if (AllowCloning.IsModelDualBand(modelNumber1))
                  {
                    num2 = (short) 379;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_627;
                case 26:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕꢗꊙ", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 121;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 191;
                case 27:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꎕ꾗ꎙ", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 372;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 242;
                case 28:
                  num2 = (short) 274;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 29:
                  num2 = (short) 175;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 30:
                  num2 = (short) 365;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 31 /*0x1F*/:
                  num2 = (short) 77;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 32 /*0x20*/:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕꢗꎙ", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 115;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 278;
                case 33:
                  if (modelNumber1[3] == 'K')
                  {
                    num2 = (short) 59;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 205;
                case 34:
                  num2 = (short) 7;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 35:
                  num2 = (short) 292;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 36:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕ겗ꦙ", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 287;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 191;
                case 37:
                  num2 = (short) 306;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 38:
                  num2 = (short) 376;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 39:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕꢗꎙ", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 295;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 395;
                case 40:
                  num2 = (short) 196;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 41:
                  num2 = (short) 321;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 42:
                  num2 = (short) 143;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 43:
                  num2 = (short) 204;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 44:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕ겗ꮙ", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 422;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 190;
                case 45:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕꢗꊙ", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 305;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 40;
                case 46:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕ겗꺙", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 400;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 403;
                case 47:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕ겗ꢙ", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 349;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 302;
                case 48 /*0x30*/:
                  num2 = (short) 194;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 49:
                  num2 = (short) 195;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 50:
                  num2 = (short) 53;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 51:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꎕ꾗ꎙ", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 179;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 264;
                case 52:
                  num2 = (short) 149;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 53:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕꢗꎙ", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 322;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 191;
                case 54:
                  num2 = (short) 333;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 55:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕꢗꎙ", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 344;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 374;
                case 56:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕ겗꾙", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 9;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 73;
                case 57:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕ겗ꦙ", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 73;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 191;
                case 58:
                  num2 = (short) 36;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 59:
                  num2 = (short) 68;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 60:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕꢗ궙", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 173;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 296;
                case 61:
                  num2 = (short) 148;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 62:
                  num2 = (short) 86;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 63 /*0x3F*/:
                  num2 = (short) 377;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 64 /*0x40*/:
                  num2 = (short) 55;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 65:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕ겗꾙", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 21776;
                    int num3 = (int) num2;
                    num2 = (short) 21776;
                    int num4 = (int) num2;
                    switch (num3 == num4 ? 1 : 0)
                    {
                      case 0:
                      case 2:
                        goto label_411;
                      default:
                        num2 = (short) 0;
                        if (num2 == (short) 0)
                          ;
                        num2 = (short) 103;
                        num1 = (int) (IntPtr) num2;
                        continue;
                    }
                  }
                  else
                    goto case 261;
                case 66:
                  num2 = (short) 47;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 67:
                  num2 = (short) 339;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 68:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕꢗ겙", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 270;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 205;
                case 69:
                  num2 = (short) 334;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 70:
                  num2 = (short) 317;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 72:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꎕ꾗ꎙ", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 419;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 264;
                case 73:
                  num2 = (short) 385;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 74:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓꒕겗꺙", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 105;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 264;
                case 75:
                  num2 = (short) 74;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 76:
                  num2 = (short) 82;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 77:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓꒕ꪗ꾙", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 67;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 191;
                case 78:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕ겗꾙", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 354;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_508;
                case 79:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓꒕겗꺙", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 236;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 48 /*0x30*/;
                case 80 /*0x50*/:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕ겗ꦙ", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 388;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 131;
                case 81:
                  if (AllowCloning.IsModelDualBand(modelNumber2))
                  {
                    num2 = (short) 243;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_648;
                case 82:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓꒕겗꺙", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 75;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 419;
                case 83:
                  num2 = (short) 14;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 84:
                  modelNumber2 = srcData.modelNumber.Trim();
                  modelNumber1 = targetData.modelNumber.Trim();
                  purchasedFlashcode1 = srcData.purchasedFlashcode;
                  purchasedFlashcode2 = targetData.purchasedFlashcode;
                  num2 = (short) 90;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 85:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕꢗ궙", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 31 /*0x1F*/;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 67;
                case 86:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕ겗겙", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 429;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 95;
                case 87:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓꒕겗꺙", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 237;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 401;
                case 88:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕ겗꾙", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 64 /*0x40*/;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 374;
                case 89:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꎕ꾗ꎙ", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 240 /*0xF0*/;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  A_3 = false;
                  num2 = (short) 171;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 90:
                  if (modelNumber2 == modelNumber1)
                  {
                    num2 = (short) 177;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_494;
                case 91:
                  num2 = (short) 159;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 92:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕ겗ꮙ", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 24;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 361;
                case 93:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓꒕ꪗ꾙", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 375;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 419;
                case 95:
                  num2 = (short) 5;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 96 /*0x60*/:
                  num2 = (short) 364;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 97:
                  num2 = (short) 209;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 98:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓꒕겗꺙", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 343;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 324;
                case 99:
                  num2 = (short) 78;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 100:
                  num2 = (short) 198;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 101:
                  if (modelNumber1[3] == 'U')
                  {
                    num2 = (short) 214;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 347;
                case 102:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓꒕ꪗ꾙", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 309;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 48 /*0x30*/;
                case 103:
                  num2 = (short) 256 /*0x0100*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 104:
                  num2 = (short) 393;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 105:
                  num2 = (short) 93;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 106:
                  num2 = (short) 101;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 107:
                  num2 = (short) 155;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 108:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓꒕겗꺙", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 392;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 386;
                case 109:
                  num2 = (short) 336;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 110:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕ겗겙", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 2;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  break;
                case 111:
                  num2 = (short) 156;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 112 /*0x70*/:
                  num2 = (short) 269;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 113:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꎕ꾗ꎙ", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 278;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 264;
                case 114:
                  num2 = (short) 404;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 115:
                  num2 = (short) 113;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 116:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕ겗겙", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 30;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 304;
                case 117:
                  num2 = (short) byte.MaxValue;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 118:
                  num2 = (short) 32 /*0x20*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 119:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕꢗ겙", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 189;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 332;
                case 120:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓꒕ꪗ꾙", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 125;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 29;
                case 121:
                  num2 = (short) 130;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 122:
                  num2 = (short) 369;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 124:
                  num2 = (short) 356;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 125:
                  num2 = (short) 65;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 126:
                  num2 = (short) 87;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case (int) sbyte.MaxValue:
                  num2 = (short) 245;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 128 /*0x80*/:
                  num2 = (short) 346;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 129:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꎕ꾗ꎙ", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 296;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 184;
                case 130:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕꢗ겙", A_1), purchasedFlashcode2, ref optionFound))
                    goto case 104;
                  goto label_411;
                case 131:
                  num2 = (short) 246;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 132:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕ겗ꦙ", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 324;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 191;
                case 133:
                  num2 = (short) 412;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 134:
                  num2 = (short) 230;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 135:
                  num2 = (short) 410;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 136:
                  num2 = (short) 427;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 137:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕꢗꊙ", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 109;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 191;
                case 138:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓꒕ꪗ꾙", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 395;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 191;
                case 139:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕ겗꾙", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 163;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 109;
                case 140:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꎕ꾗ꎙ", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 390;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 184;
                case 141:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕꢗꎙ", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 302;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 191;
                case 142:
                  num2 = (short) 288;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 143:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕꢗꊙ", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 220;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 191;
                case 144 /*0x90*/:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕ겗꾙", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 35;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_120;
                case 145:
                  num2 = (short) 165;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 146:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕꢗꎙ", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 359;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 372;
                case 147:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓꒕ꪗ꾙", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 361;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 191;
                case 148:
                  if (modelNumber1[3] == 'Q')
                  {
                    num2 = (short) 418;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 390;
                case 149:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓꒕ꪗ꾙", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 391;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 191;
                case 150:
                  if (AllowCloning.IsModelSingleBand(modelNumber1))
                  {
                    num2 = (short) 106;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_648;
                case 151:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕ겗꺙", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 216;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 191;
                case 152:
                  num2 = (short) 110;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 153:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕ겗ꢙ", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 363;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 22;
                case 154:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓꒕겗꺙", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 360;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 104;
                case 155:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕ겗겙", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 212;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 191;
                case 156:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕ겗ꢙ", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 208 /*0xD0*/;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 335;
                case 157:
                  if (modelNumber2[3] == 'U')
                  {
                    num2 = (short) 353;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 229;
                case 158:
                  if (modelNumber2[3] == 'K')
                  {
                    num2 = (short) 128 /*0x80*/;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 372;
                case 159:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕꢗꎙ", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 232;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 239;
                case 160 /*0xA0*/:
                  num2 = (short) 325;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 161:
                  if (modelNumber2[3] == 'Q')
                  {
                    num2 = (short) 0;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 131;
                case 162:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕꢗ궙", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 408;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 395;
                case 163:
                  num2 = (short) 137;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 165:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕꢗ궙", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 342;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 278;
                case 166:
                  num2 = (short) 411;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 167:
                  num2 = (short) 249;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 168:
                  num2 = (short) 299;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 169:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕꢗ궙", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 118;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 264;
                case 170:
                  num2 = (short) 268;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 173:
                  num2 = (short) 129;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 174:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕ겗ꮙ", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 398;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 48 /*0x30*/;
                case 175:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓꒕겗꺙", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 83;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 160 /*0xA0*/;
                case 176 /*0xB0*/:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕ겗ꢙ", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 38;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_501;
                case 177:
                  num2 = (short) 327;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 178:
                  num2 = (short) 88;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 179:
                  num2 = (short) 1;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 180:
                  num2 = (short) 21;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 181:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕ겗꺙", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 239;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 191;
                case 182:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕꢗꊙ", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 332;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 191;
                case 183:
                  num2 = (short) 267;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 184:
                  A_3 = true;
                  num2 = (short) 203;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 185:
                  num2 = (short) 146;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 186:
                  num2 = (short) 362;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 187:
                  num2 = (short) 0;
                  num2 = (short) 8;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 189:
                  num2 = (short) 357;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 190:
                  num2 = (short) 238;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 191:
                  A_3 = true;
                  num2 = (short) 188;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 192 /*0xC0*/:
                  num2 = (short) 228;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 193:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕ겗ꮙ", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 311;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 100;
                case 194:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓꒕겗꺙", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 136;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 361;
                case 195:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕ겗겙", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 234;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_120;
                case 196:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕꢗ겙", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 206;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 100;
                case 197:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕ겗꾙", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 323;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 304;
                case 198:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕ겗ꢙ", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 91;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 239;
                case 199:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓꒕겗꺙", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 168;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 242;
                case 200:
                  if (AllowCloning.IsModelSingleBand(modelNumber2))
                  {
                    num2 = (short) 210;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_627;
                case 201:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꎕ꾗ꎙ", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 347;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 184;
                case 202:
                  num2 = (short) 45;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 204:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕ겗꾙", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 41;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 95;
                case 205:
                  num2 = (short) 330;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 206:
                  num2 = (short) 11;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 207:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕ겗겙", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 335;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 191;
                case 208 /*0xD0*/:
                  num2 = (short) 207;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 209:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓꒕ꪗ꾙", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 160 /*0xA0*/;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 191;
                case 210:
                  num2 = (short) 25;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 211:
                  if (modelNumber1[3] == 'Q')
                  {
                    num2 = (short) 290;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 61;
                case 212:
                  num2 = (short) 56;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 213:
                  if (!AllowCloning.b(srcData))
                  {
                    num2 = (short) 84;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  A_3 = true;
                  num2 = (short) 94;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 214:
                  num2 = (short) 316;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 215:
                  num2 = (short) 158;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 216:
                  num2 = (short) 176 /*0xB0*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 217:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕ겗겙", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 190;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 191;
                case 218:
                  num2 = (short) 182;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 219:
                  num2 = (short) 140;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 220:
                  num2 = (short) 312;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 221:
                  num2 = (short) 402;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 222:
                  num2 = (short) 303;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 223:
                  num2 = (short) 272;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 224 /*0xE0*/:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕ겗꺙", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 192 /*0xC0*/;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 122;
                case 225:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕꢗꎙ", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 22;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 191;
                case 226:
                  num2 = (short) 326;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 227:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꎕ꾗ꎙ", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 242;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  break;
                case 228:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓꒕겗꺙", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 417;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 318;
                case 229:
                  num2 = (short) 244;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 230:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꎕ꾗ꎙ", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 63 /*0x3F*/;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 242;
                case 231:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕ겗겙", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 29;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 191;
                case 232:
                  num2 = (short) 153;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 233:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕ겗꾙", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 50;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 322;
                case 234:
                  num2 = (short) 271;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 235:
                  num2 = (short) 297;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 236:
                  num2 = (short) 15;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 237:
                  num2 = (short) 421;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 238:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕ겗꾙", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 135;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_501;
                case 239:
                  num2 = (short) 258;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 240 /*0xF0*/:
                  num2 = (short) 251;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 241:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕ겗겙", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 43;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 191;
                case 242:
                  A_3 = true;
                  num2 = (short) 123;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 243:
                  num2 = (short) 150;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 244:
                  if (modelNumber2[3] == 'K')
                  {
                    num2 = (short) 300;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 215;
                case 245:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕ겗꺙", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 134;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 63 /*0x3F*/;
                case 246:
                  if (modelNumber2[3] == 'Q')
                  {
                    num2 = (short) 285;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 63 /*0x3F*/;
                case 247:
                  num2 = (short) 394;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 249:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓꒕ꪗ꾙", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 320;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 414;
                case 250:
                  num2 = (short) 380;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 251:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓꒕겗꺙", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 337;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 122;
                case 252:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕ겗ꮙ", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 202;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 40;
                case 253:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕ겗ꮙ", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 247;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 61;
                case 254:
                  num2 = (short) 338;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case (int) byte.MaxValue:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕ겗ꦙ", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 352;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 191;
                case 256 /*0x0100*/:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓꒕ꪗ꾙", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 261;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 191;
                case 257:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꎕ꾗ꎙ", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 229;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 242;
                case 258:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕꢗ궙", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 170;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 302;
                case 259:
                  num2 = (short) 331;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 260:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕꢗꎙ", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 304;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 191;
                case 261:
                  num2 = (short) 399;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 262:
                  num2 = (short) 151;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 263:
                  num2 = (short) 370;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 264:
                  A_3 = true;
                  num2 = (short) 71;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 265:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕ겗ꮙ", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 16 /*0x10*/;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 264;
                case 266:
                  num2 = (short) 416;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 267:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕ겗꺙", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 66;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 191;
                case 268:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕ겗꺙", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 259;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 302;
                case 269:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕ겗꾙", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 117;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 352;
                case 270:
                  num2 = (short) 348;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 271:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꎕ꾗ꎙ", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 264;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_120;
                case 272:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕ겗겙", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 374;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 191;
                case 273:
                  if (modelNumber2 == modelNumber1)
                  {
                    num2 = (short) 180;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_403;
                case 274:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꎕ꾗ꎙ", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 145;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 264;
                case 275:
                  num2 = (short) 301;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 276:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕ겗꺙", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 318;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 191;
                case 277:
                  num2 = (short) 405;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 278:
                  num2 = (short) 319;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 279:
                  num2 = (short) 80 /*0x50*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 280:
                  num2 = (short) 425;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 281:
                  num2 = (short) 98;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 282:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕꢗꎙ", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 386;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 191;
                case 283:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕ겗ꢙ", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) sbyte.MaxValue;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 242;
                case 284:
                  num2 = (short) 60;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 285:
                  num2 = (short) 283;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 287:
                  num2 = (short) 193;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 288:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓꒕ꪗ꾙", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 122;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 191;
                case 289:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꎕ꾗ꎙ", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 215;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 242;
                case 290:
                  num2 = (short) 253;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 291:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕꢗꊙ", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 235;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 104;
                case 292:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕ겗꾙", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 49;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 264;
                case 293:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꎕ꾗ꎙ", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 403;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 264;
                case 295:
                  num2 = (short) 108;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 296:
                  num2 = (short) 211;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 297:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓꒕겗꺙", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 20;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 121;
                case 298:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕꢗ궙", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 223;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 374;
                case 299:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓꒕ꪗ꾙", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 383;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 229;
                case 300:
                  num2 = (short) 341;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 301:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕ겗ꢙ", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 12;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 126;
                case 302:
                  num2 = (short) 174;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 303:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕ겗ꦙ", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 40;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 191;
                case 304:
                  num2 = (short) 406;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 305:
                  num2 = (short) 366;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 306:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꎕ꾗ꎙ", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 89;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 351;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 307:
                  num2 = (short) 197;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 308:
                  num2 = (short) 381;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 309:
                  num2 = (short) 396;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 310:
                  num2 = (short) 46;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 311:
                  num2 = (short) 3;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 312:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕꢗ겙", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 222;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 40;
                case 313:
                  num2 = (short) 51;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 314:
                  num2 = (short) 231;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 315:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕ겗겙", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 69;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 73;
                case 316:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓꒕겗꺙", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 384;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 347;
                case 317:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕ겗겙", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 308;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 191;
                case 318:
                  num2 = (short) 423;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 319:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕ겗ꮙ", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 350;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 179;
                case 320:
                  num2 = (short) 85;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 321:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕꢗꊙ", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 95;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 191;
                case 322:
                  num2 = (short) 298;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 323:
                  num2 = (short) 260;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 324:
                  num2 = (short) 92;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 325:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕꢗ겙", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 62;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 95;
                case 326:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕꢗꊙ", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 28;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 145;
                case 327:
                  if (AllowCloning.IsModelSingleBand(modelNumber2))
                  {
                    num2 = (short) 345;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_494;
                case 328:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꎕ꾗ꎙ", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 131;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 242;
                case 329:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕ겗꾙", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 10;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 29;
                case 330:
                  if (modelNumber1[3] == 'K')
                  {
                    num2 = (short) 284;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 296;
                case 331:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕꢗ궙", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 183;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 66;
                case 332:
                  num2 = (short) 19;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 333:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓꒕겗꺙", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 218;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 332;
                case 334:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕ겗ꮙ", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 107;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 212;
                case 335:
                  num2 = (short) 340;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 336:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕꢗ겙", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 133;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 178;
                case 337:
                  num2 = (short) 224 /*0xE0*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 338:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕ겗ꢙ", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 310;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 264;
                case 339:
                  num2 = (short) 1;
                  if (num2 == (short) 0)
                    ;
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓꒕겗꺙", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 187;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 414;
                case 340:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕ겗꾙", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 263;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 277;
                case 341:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕꢗ겙", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 221;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 242;
                case 342:
                  num2 = (short) 169;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 343:
                  num2 = (short) 132;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 344:
                  num2 = (short) 233;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 345:
                  A_3 = true;
                  num2 = (short) 248;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 346:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕꢗ궙", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 185;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 242;
                case 347:
                  num2 = (short) 33;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 348:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꎕ꾗ꎙ", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 205;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 184;
                case 349:
                  num2 = (short) 141;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 350:
                  num2 = (short) 265;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 351:
                  num2 = (short) 18;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 352:
                  num2 = (short) 44;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 353:
                  num2 = (short) 199;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 354:
                  num2 = (short) 4;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 355:
                  num2 = (short) 116;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 356:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓꒕ꪗ꾙", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 54;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 191;
                case 357:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓꒕ꪗ꾙", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 96 /*0x60*/;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 332;
                case 358:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕ겗겙", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 111;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 277;
                case 359:
                  num2 = (short) 27;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 360:
                  num2 = (short) 291;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 361:
                  num2 = (short) 329;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 362:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕ겗ꦙ", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 112 /*0x70*/;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 190;
                case 363:
                  num2 = (short) 225;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 364:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕꢗ겙", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 124;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 54;
                case 365:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕꢗ궙", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 280;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 307;
                case 366:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕ겗ꮙ", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 42;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 220;
                case 367:
                  num2 = (short) 289;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 368:
                  num2 = (short) 315;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 369:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕ겗ꢙ", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 409;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 401;
                case 370:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕ겗꺙", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 277;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 191;
                case 371:
                  num2 = (short) 430;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 372:
                  num2 = (short) 161;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 373:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕ겗ꢙ", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 219;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 390;
                case 374:
                  num2 = (short) 13;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 375:
                  num2 = (short) 72;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 376:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕ겗겙", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 191;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_501;
                case 377:
                  if (modelNumber2[3] == 'S')
                  {
                    num2 = (short) 250;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  break;
                case 378:
                  num2 = (short) 358;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 379:
                  num2 = (short) 157;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 380:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕ겗꾙", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 152;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 242;
                case 381:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕ겗꾙", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 97;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 160 /*0xA0*/;
                case 382:
                  num2 = (short) 241;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 383:
                  num2 = (short) 257;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 384:
                  num2 = (short) 201;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 385:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕ겗ꢙ", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 378;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 277;
                case 386:
                  num2 = (short) 162;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 387:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓꒕ꪗ꾙", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 126;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 191;
                case 388:
                  num2 = (short) 328;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 389:
                  num2 = (short) 39;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 390:
                  num2 = (short) 426;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 391:
                  num2 = (short) 79;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 392:
                  num2 = (short) 282;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 393:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓꒕겗꺙", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 389;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 395;
                case 394:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꎕ꾗ꎙ", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 61;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 184;
                case 395:
                  num2 = (short) 119;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 396:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕ겗ꮙ", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 52;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 391;
                case 397:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕ겗ꦙ", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 313;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 179;
                case 398:
                  num2 = (short) 102;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 399:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓꒕겗꺙", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 314;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 29;
                case 400:
                  num2 = (short) 293;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 401:
                  num2 = (short) 154;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 402:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕꢗꊙ", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 367;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 215;
                case 403:
                  num2 = (short) 144 /*0x90*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 404:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓꒕ꪗ꾙", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 104;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 191;
                case 405:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕ겗꾙", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 186;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 190;
                case 406:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕ겗꾙", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 371;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 178;
                case 407:
                  num2 = (short) 23;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 408:
                  num2 = (short) 138;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 409:
                  num2 = (short) 428;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 410:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕ겗꺙", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 266;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_501;
                case 411:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕꢗ겙", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 58;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 287;
                case 412:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕ겗겙", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 178;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 191;
                case 413:
                  num2 = (short) 139;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 414:
                  num2 = (short) 252;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 415:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕꢗ궙", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 420;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 239;
                case 416:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕ겗꾙", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 262;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 216;
                case 417:
                  num2 = (short) 276;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 418:
                  num2 = (short) 373;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 419:
                  num2 = (short) 6;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 420:
                  num2 = (short) 181;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 421:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕ겗꺙", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 401;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 191;
                case 422:
                  num2 = (short) 217;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 423:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕ겗ꢙ", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 142;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 122;
                case 424:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕꢗ겙", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 382;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 43;
                case 425:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕ겗겙", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 307;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 191;
                case 426:
                  if (modelNumber1[3] == 'S')
                  {
                    num2 = (short) 99;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_508;
                case 427:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕ겗ꦙ", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 281;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 361;
                case 428:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓꒕ꪗ꾙", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 275;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 401;
                case 429:
                  num2 = (short) 424;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 430:
                  if (FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕꢗꊙ", A_1), purchasedFlashcode1, ref optionFound))
                  {
                    num2 = (short) 413;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 178;
                case 431:
                  if (!FcodeTable.IsOptionEnabledInFlashcode(RptMgrErrorHandler.b("즍톏ꊑ꒓ꖕ겗ꮙ", A_1), purchasedFlashcode2, ref optionFound))
                  {
                    num2 = (short) 279;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 242;
                default:
                  goto label_3;
              }
              A_3 = false;
              num2 = (short) 17;
              num1 = (int) (IntPtr) num2;
              continue;
label_120:
              A_3 = false;
              num2 = (short) 294;
              num1 = (int) (IntPtr) num2;
              continue;
label_403:
              num2 = (short) 200;
              num1 = (int) (IntPtr) num2;
              continue;
label_411:
              num2 = (short) 114;
              num1 = (int) (IntPtr) num2;
              continue;
label_494:
              num2 = (short) 273;
              num1 = (int) (IntPtr) num2;
              continue;
label_501:
              A_3 = false;
              num2 = (short) 172;
              num1 = (int) (IntPtr) num2;
              continue;
label_508:
              A_3 = false;
              num2 = (short) 286;
              num1 = (int) (IntPtr) num2;
              continue;
label_627:
              num2 = (short) 81;
              num1 = (int) (IntPtr) num2;
            }
label_648:
            return A_3;
        }
    }
  }

  internal static bool AllowEnhLevel1Clone(
    FlashcodeTable FcodeTable,
    CodeplugData srcData,
    CodeplugData targetData)
  {
    short num1 = 0;
    num1 = (short) 25746;
    int num2 = (int) num1;
    num1 = (short) 25746;
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
        return AllowCloning.a(FcodeTable, srcData, targetData);
      default:
        goto case 1;
    }
  }

  internal static bool AllowEnhLevel2Clone(
    FlashcodeTable FcodeTable,
    CodeplugData srcData,
    CodeplugData targetData)
  {
    int A_1_1 = 6;
    short num1 = 8501;
    int num2 = (int) num1;
    num1 = (short) 8501;
    int num3 = (int) num1;
    int num4;
    switch (num2 == num3 ? 1 : 0)
    {
      case 0:
      case 2:
label_4:
        if (false)
          ;
        bool flag = true;
        try
        {
          ModelTiering modelTiering = new ModelTiering(targetData.modelNumber, targetData.purchasedFlashcode);
          try
          {
            short num5;
            int nMaxRecs;
            switch (0)
            {
              case 0:
label_9:
                string strFullyQualifiedRecordsetName1 = RptMgrErrorHandler.b("쒈\uE48A歷\uE08E\uE390ﲒ璉\uF696래횚ﲜﲞ쪠쪢쮤욦\uDEA8\uE8AAﶬﲮ龰\uF0B2\uDAB4얶\uDCB8ﶺ\uD8BC\uDEBE뗀뛂럄ꋆ뫈\uE5CA鿌껎뗐뫒뫔蟖ꯘ듚믜뛞跠蛢雤짦믨諪觬蛮黰ꏲ蟴飶\u9FF8鋺釼髾爀儂怄搆稈渊礌", A_1_1);
                nMaxRecs = modelTiering.GetRecordsetDataFromEngine(strFullyQualifiedRecordsetName1, ModelTiering.RecsetAttributeTypes.MaxRecords);
                num5 = (short) 10;
                num4 = (int) (IntPtr) num5;
                goto default;
              default:
                RadioProfilesRecset feature1;
                ZoneChannelAssignmentRecset feature2;
                while (true)
                {
                  switch (num4)
                  {
                    case 0:
                      if (srcData.recSetCounts != null)
                      {
                        num5 = (short) 16 /*0x10*/;
                        num4 = (int) (IntPtr) num5;
                        continue;
                      }
                      goto case 11;
                    case 1:
                      num5 = (short) 18;
                      num4 = (int) (IntPtr) num5;
                      continue;
                    case 2:
                      if (!((Recordset) feature2).HiddenStatic)
                      {
                        num5 = (short) 22;
                        num4 = (int) (IntPtr) num5;
                        continue;
                      }
                      goto case 11;
                    case 3:
                      flag = false;
                      num5 = (short) 27;
                      num4 = (int) (IntPtr) num5;
                      continue;
                    case 4:
                      num5 = (short) 17;
                      num4 = (int) (IntPtr) num5;
                      continue;
                    case 5:
                      feature2 = FeatureManager.GetFeature(2051) as ZoneChannelAssignmentRecset;
                      num5 = (short) 41;
                      num4 = (int) (IntPtr) num5;
                      continue;
                    case 6:
                      if (((Recordset) feature1).Count > nMaxRecs)
                      {
                        num5 = (short) 31 /*0x1F*/;
                        num4 = (int) (IntPtr) num5;
                        continue;
                      }
                      goto case 8;
                    case 7:
                      flag = false;
                      num5 = (short) 38;
                      num4 = (int) (IntPtr) num5;
                      continue;
                    case 8:
                    case 38:
                      num5 = (short) 37;
                      num4 = (int) (IntPtr) num5;
                      continue;
                    case 9:
                      flag = false;
                      num5 = (short) 11;
                      num4 = (int) (IntPtr) num5;
                      continue;
                    case 10:
                      if (srcData._data == null)
                      {
                        num5 = (short) 32 /*0x20*/;
                        num4 = (int) (IntPtr) num5;
                        continue;
                      }
                      num5 = (short) 24;
                      num4 = (int) (IntPtr) num5;
                      continue;
                    case 11:
                    case 27:
                      num5 = (short) 43;
                      num4 = (int) (IntPtr) num5;
                      continue;
                    case 12:
                      if (!((Recordset) feature1).HiddenStatic)
                      {
                        num5 = (short) 21;
                        num4 = (int) (IntPtr) num5;
                        continue;
                      }
                      goto case 8;
                    case 13:
                      if (nMaxRecs != -1)
                      {
                        num5 = (short) 30;
                        num4 = (int) (IntPtr) num5;
                        continue;
                      }
                      goto case 8;
                    case 14:
                      if (nMaxRecs != -1)
                      {
                        num5 = (short) 36;
                        num4 = (int) (IntPtr) num5;
                        continue;
                      }
                      goto case 11;
                    case 15:
                      flag = AllowCloning.a(FcodeTable, srcData, targetData);
                      num5 = (short) 26;
                      num4 = (int) (IntPtr) num5;
                      continue;
                    case 16 /*0x10*/:
                      num5 = (short) 33;
                      num4 = (int) (IntPtr) num5;
                      continue;
                    case 17:
                      if (nMaxRecs != -1)
                      {
                        num5 = (short) 28;
                        num4 = (int) (IntPtr) num5;
                        continue;
                      }
                      goto case 8;
                    case 18:
                      if (nMaxRecs != -1)
                      {
                        num5 = (short) 42;
                        num4 = (int) (IntPtr) num5;
                        continue;
                      }
                      goto case 11;
                    case 19:
                      if (srcData.recSetCounts.Find((Predicate<AstroRecSetCountsItem>) (x =>
                      {
                        int A_1_2 = 2;
label_1:
                        short num6 = 0;
                        num6 = (short) 1;
                        if (num6 == (short) 0)
                          ;
                        if (!(x._recSetName == RptMgrErrorHandler.b("힄\uE686\uED88\uE28A\uE28C\uDF8E\uE390ﲒ\uF394ﺖ\uF598ﺚ\uEE9C춞쒠삢횤슦\uDDA8", A_1_2)))
                          return false;
                        num6 = (short) 20302;
                        int num7 = (int) num6;
                        num6 = (short) 20302;
                        int num8 = (int) num6;
                        switch (num7 == num8 ? 1 : 0)
                        {
                          case 0:
                          case 2:
                            goto label_1;
                          default:
                            num6 = (short) 0;
                            if (num6 == (short) 0)
                              ;
                            return x._count > nMaxRecs;
                        }
                      })) != null)
                      {
                        num5 = (short) 7;
                        num4 = (int) (IntPtr) num5;
                        continue;
                      }
                      goto case 8;
                    case 20:
                      if (srcData.recSetCounts.Find((Predicate<AstroRecSetCountsItem>) (x =>
                      {
                        int A_1_3 = 12;
                        short num9 = 0;
                        if (x._recSetName == RptMgrErrorHandler.b("햎ﺐﶒ\uF094풖\uF198漢\uF39C\uF19E쒠쾢\uE4A4풦\uDAA8슪쪬솮\uDCB0횲\uDBB4쎶\uEBB8\uDEBA\uDEBC첾꓀럂", A_1_3))
                        {
                          num9 = (short) -14326;
                          int num10 = (int) num9;
                          num9 = (short) -14326;
                          int num11 = (int) num9;
                          switch (num10 == num11 ? 1 : 0)
                          {
                            case 0:
                            case 2:
                              break;
                            default:
                              num9 = (short) 0;
                              if (num9 == (short) 0)
                                ;
                              return x._count > nMaxRecs;
                          }
                        }
                        num9 = (short) 1;
                        if (num9 == (short) 0)
                          ;
                        return false;
                      })) != null)
                      {
                        num5 = (short) 3;
                        num4 = (int) (IntPtr) num5;
                        continue;
                      }
                      goto case 11;
                    case 21:
                      num5 = (short) 13;
                      num4 = (int) (IntPtr) num5;
                      continue;
                    case 22:
                      num5 = (short) 14;
                      num4 = (int) (IntPtr) num5;
                      continue;
                    case 23:
                      if (srcData._data != null)
                      {
                        num5 = (short) 0;
                        num4 = (int) (IntPtr) num5;
                        continue;
                      }
                      num5 = (short) 5;
                      num4 = (int) (IntPtr) num5;
                      continue;
                    case 24:
                      if (srcData.recSetCounts != null)
                      {
                        num5 = (short) 29;
                        num4 = (int) (IntPtr) num5;
                        continue;
                      }
                      goto case 8;
                    case 25:
                      if (srcData.recSetCounts.Count > 0)
                      {
                        num5 = (short) 4;
                        num4 = (int) (IntPtr) num5;
                        continue;
                      }
                      goto case 8;
                    case 26:
                      num5 = (short) 39;
                      num4 = (int) (IntPtr) num5;
                      continue;
                    case 28:
                      num5 = (short) 19;
                      num4 = (int) (IntPtr) num5;
                      continue;
                    case 29:
                      num5 = (short) 25;
                      num4 = (int) (IntPtr) num5;
                      continue;
                    case 30:
                      num5 = (short) 6;
                      num4 = (int) (IntPtr) num5;
                      continue;
                    case 31 /*0x1F*/:
                      flag = false;
                      num5 = (short) 8;
                      num4 = (int) (IntPtr) num5;
                      continue;
                    case 32 /*0x20*/:
                      feature1 = FeatureManager.GetFeature(2077) as RadioProfilesRecset;
                      num5 = (short) 34;
                      num4 = (int) (IntPtr) num5;
                      continue;
                    case 33:
                      if (srcData.recSetCounts.Count > 0)
                      {
                        num5 = (short) 1;
                        num4 = (int) (IntPtr) num5;
                        continue;
                      }
                      goto case 11;
                    case 34:
                      if (feature1 != null)
                      {
                        num5 = (short) 40;
                        num4 = (int) (IntPtr) num5;
                        continue;
                      }
                      goto case 8;
                    case 35:
                      string strFullyQualifiedRecordsetName2 = RptMgrErrorHandler.b("쒈\uE48A歷\uE08E\uE390ﲒ璉\uF696래횚ﲜﲞ쪠쪢쮤욦\uDEA8\uE8AAﶬﲮ龰\uF0B2\uDAB4얶\uDCB8ﶺ\uD8BC\uDEBE뗀뛂럄ꋆ뫈\uE5CA韌ꃎ뿐뛒雔뿖룘뗚돜뫞跠ꋢ雤铦胨質菬苮铰鷲致\uD9F6ꏸ铺鏼髾䈀欂搄椆月渊愌与成怒簔瀖眘瘚砜焞唠焢䀤䐦娨个夬", A_1_1);
                      nMaxRecs = modelTiering.GetRecordsetDataFromEngine(strFullyQualifiedRecordsetName2, ModelTiering.RecsetAttributeTypes.MaxRecords);
                      num5 = (short) 23;
                      num4 = (int) (IntPtr) num5;
                      continue;
                    case 36:
                      num5 = (short) 44;
                      num4 = (int) (IntPtr) num5;
                      continue;
                    case 37:
                      if (flag)
                      {
                        num5 = (short) 35;
                        num4 = (int) (IntPtr) num5;
                        continue;
                      }
                      goto case 11;
                    case 39:
                      goto label_83;
                    case 40:
                      num5 = (short) 12;
                      num4 = (int) (IntPtr) num5;
                      continue;
                    case 41:
                      if (feature2 != null)
                      {
                        num5 = (short) 45;
                        num4 = (int) (IntPtr) num5;
                        continue;
                      }
                      goto case 11;
                    case 42:
                      num5 = (short) 20;
                      num4 = (int) (IntPtr) num5;
                      continue;
                    case 43:
                      if (flag)
                      {
                        num5 = (short) 15;
                        num4 = (int) (IntPtr) num5;
                        continue;
                      }
                      goto case 26;
                    case 44:
                      if (((Recordset) feature2).Count > nMaxRecs)
                      {
                        num5 = (short) 9;
                        num4 = (int) (IntPtr) num5;
                        continue;
                      }
                      goto case 11;
                    case 45:
                      num5 = (short) 2;
                      num4 = (int) (IntPtr) num5;
                      continue;
                    default:
                      goto label_9;
                  }
                }
            }
          }
          finally
          {
            int num12 = 0;
            while (true)
            {
              short num13;
              switch (num12)
              {
                case 0:
                  switch (0)
                  {
                    case 0:
                      break;
                    default:
                      continue;
                  }
                  break;
                case 1:
                  modelTiering.Dispose();
                  num13 = (short) 2;
                  num12 = (int) (IntPtr) num13;
                  continue;
                case 2:
                  goto label_81;
              }
              if (modelTiering != null)
              {
                num13 = (short) 1;
                num12 = (int) (IntPtr) num13;
              }
              else
                break;
            }
label_81:;
          }
        }
        catch (Exception ex)
        {
          flag = false;
        }
label_83:
        return flag;
      case 1:
        if (true)
          ;
        num4 = 0;
        switch (num4)
        {
          default:
            goto label_4;
        }
      default:
        goto case 1;
    }
  }

  private static bool a(FlashcodeTable A_0, CodeplugData A_1, CodeplugData A_2)
  {
    int A_1_1 = 11;
    int num1 = 0;
    switch (num1)
    {
      default:
        bool flag = true;
        try
        {
          ModelTiering modelTiering = new ModelTiering(A_2.modelNumber, A_2.purchasedFlashcode);
          try
          {
            short num2;
            int nMaxRecs;
            switch (0)
            {
              case 0:
label_5:
                string strFullyQualifiedRecordsetName1 = RptMgrErrorHandler.b("쎍ﾏ\uE691ﮓ\uE495\uF797\uF699ﶛ낝\uED9F쎡잣춥솧쒩춫\uD9AD\uF3AF\uE2B1\uE7B3颵﮷햹캻\uDBBD蚿\uA7C1ꗃ닅뷇룉꧋뷍ﻏ蛑ꛓꏕ뛗뇙뗛냝蟟뇡鷣闥鳧迩臫샭ꓯ胱至飵鏷鏹鋻駽叿笁眃爅洇有帋欍猏愑焓戕", A_1_1);
                nMaxRecs = modelTiering.GetRecordsetDataFromEngine(strFullyQualifiedRecordsetName1, ModelTiering.RecsetAttributeTypes.MaxRecords);
                num2 = (short) 161;
                num1 = (int) (IntPtr) num2;
                goto default;
              default:
                TrunkingSystemRecset feature1;
                ConventionalSystemRecset feature2;
                EncryptionKeyListInnerRecset embeddedRecset1;
                ZoneChannelAssignmentRecset feature3;
                VoiceAnnouncementListRecSet feature4;
                ZoneChannelAssignmentRecset feature5;
                SecureKMFProfileRecset feature6;
                IEnumerator<FeatureNode> enumerator;
                ChannelAssignmentListInnerRecset embeddedRecset2;
                ASTROTalkgroupListRecset feature7;
                UclContactRecset feature8;
                TrunkingPersonalityRecset feature9;
                int nMaxPoolRecs;
                while (true)
                {
                  switch (num1)
                  {
                    case 0:
                      num2 = (short) 119;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 1:
                      num2 = (short) 19;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 2:
                      if (nMaxRecs != -1)
                      {
                        num2 = (short) 232;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 36;
                    case 3:
                    case 116:
                      num2 = (short) 162;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 4:
                      feature7 = FeatureManager.GetFeature(2062) as ASTROTalkgroupListRecset;
                      num2 = (short) 217;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 5:
                      if (A_1._data == null)
                      {
                        num2 = (short) 49;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      num2 = (short) 148;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 6:
                      if (flag)
                      {
                        num2 = (short) 201;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 3;
                    case 7:
                      string strFullyQualifiedRecordsetName2 = RptMgrErrorHandler.b("쎍ﾏ\uE691ﮓ\uE495\uF797\uF699ﶛ낝\uED9F쎡잣춥솧쒩춫\uD9AD\uF3AF\uE2B1\uE7B3颵﮷햹캻\uDBBD蚿\uA7C1ꗃ닅뷇룉꧋뷍ﻏ裑믓룕뷗駙듛뿝軟賡臣諥ꧧ駩\u9FEB蟭韯鳱駳鏵雷軹틻뷽棿持樃栅洇昉䴋納挏笑猓砕甗缙爛樝氟䬡圣別愧䐩䈫䬭䈯怱儳唵䬷弹䠻", A_1_1);
                      nMaxPoolRecs = modelTiering.GetRecordsetDataFromEngine(strFullyQualifiedRecordsetName2, ModelTiering.RecsetAttributeTypes.MaxPoolRecords);
                      num2 = (short) 16 /*0x10*/;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 8:
                      if (A_1.recSetCounts.Count > 0)
                      {
                        num2 = (short) 53;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 25;
                    case 9:
                      if (flag)
                      {
                        num2 = (short) sbyte.MaxValue;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 122;
                    case 10:
                      if (embeddedRecset1 != null)
                      {
                        num2 = (short) 43;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 3;
                    case 11:
                      num2 = (short) 86;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 12:
                      num2 = (short) 102;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 13:
                      flag = false;
                      num2 = (short) 57;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 14:
                      if (((Recordset) embeddedRecset2).MaxPool - ((Recordset) embeddedRecset2).CounterToMaxPool > nMaxPoolRecs)
                      {
                        num2 = (short) 237;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 29;
                    case 15:
                      if (feature8.Count > nMaxRecs)
                      {
                        num2 = (short) 205;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 128 /*0x80*/;
                    case 16 /*0x10*/:
                      if (A_1._data != null)
                      {
                        num2 = (short) 142;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      num2 = (short) 76;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 17:
                      num2 = (short) 90;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 18:
                      flag = false;
                      num2 = (short) 36;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 19:
                      if (((Recordset) embeddedRecset1).Count > nMaxRecs)
                      {
                        num2 = (short) 204;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 3;
                    case 20:
                      if (nMaxRecs != -1)
                      {
                        num2 = (short) 46;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 128 /*0x80*/;
                    case 21:
                      if (A_1._data != null)
                      {
                        num2 = (short) 145;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      num2 = (short) 4;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 22:
                      if (A_1.recSetCounts != null)
                      {
                        num2 = (short) 30;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 122;
                    case 23:
                      if (A_1.recSetCounts.Count > 0)
                      {
                        num2 = (short) 153;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 36;
                    case 24:
                      num2 = (short) 103;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 25:
                    case 185:
                      num2 = (short) 120;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 26:
                      if (flag)
                      {
                        num2 = (short) 177;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 25;
                    case 27:
                      num2 = (short) 188;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 28:
                      if (A_1._data != null)
                      {
                        num2 = (short) 41;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      num2 = (short) 132;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 29:
                    case 199:
                      num2 = (short) 95;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 30:
                      num2 = (short) 210;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 31 /*0x1F*/:
                      num2 = (short) 144 /*0x90*/;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 32 /*0x20*/:
                      if (feature2 != null)
                      {
                        num2 = (short) 222;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 25;
                    case 33:
                    case 159:
                      num2 = (short) 35;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 34:
                      num2 = (short) 179;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 35:
                      if (flag)
                      {
                        num2 = (short) 194;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 40;
                    case 36:
                    case 37:
                      num2 = (short) 75;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 38:
                      num2 = (short) 139;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 39:
                      if (A_1.recSetCounts.Find((Predicate<AstroRecSetCountsItem>) (x =>
                      {
                        int A_1_2 = 0;
                        if (x._recSetName == RptMgrErrorHandler.b("\uD982\uEA84\uE986\uEC88좊\uE58C\uEE8Eﾐﶒ\uF094ﮖ\uD898\uE89A\uEE9C\uF69E욠춢좤슦잨\uDFAAﾬ쪮튰삲킴쎶", A_1_2))
                        {
                          short num3 = -10762;
                          switch ((short) -10762 == num3 ? 1 : 0)
                          {
                            case 0:
                            case 2:
                              break;
                            default:
                              num3 = (short) 1;
                              if (num3 == (short) 0)
                                ;
                              num3 = (short) 0;
                              if (num3 == (short) 0)
                                ;
                              return x._count > nMaxRecs;
                          }
                        }
                        return false;
                      })) != null)
                      {
                        num2 = (short) 170;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 181;
                    case 40:
                    case 183:
                      num2 = (short) 26;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 41:
                      if (A_1.recSetCounts != null)
                      {
                        num2 = (short) 196;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 36;
                    case 42:
                      num2 = (short) 164;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 43:
                      num2 = (short) 110;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 44:
                      if (A_1.recSetCounts != null)
                      {
                        num2 = (short) 173;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 57;
                    case 45:
                      if (nMaxRecs != -1)
                      {
                        num2 = (short) 31 /*0x1F*/;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 122;
                    case 46:
                      num2 = (short) 15;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 47:
                      if (!feature8.HiddenStatic)
                      {
                        num2 = (short) 105;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 128 /*0x80*/;
                    case 48 /*0x30*/:
                      if (!((Recordset) feature7).HiddenStatic)
                      {
                        num2 = (short) 0;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 40;
                    case 49:
                      feature3 = FeatureManager.GetFeature(2051) as ZoneChannelAssignmentRecset;
                      num2 = (short) 52;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 50:
                      if (((Recordset) feature1).Count > nMaxRecs)
                      {
                        num2 = (short) 236;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 33;
                    case 51:
                      string strFullyQualifiedRecordsetName3 = RptMgrErrorHandler.b("\uDD8D\uE08F\uF791\uF793ﾕ聯\uF699\uDA9Bﮝ솟횡톣풥춧\uD9A9芫ﮭ펯\uDEB1骳\uF5B5ힷ풹좻\uDFBDꎿ뛁\uEAC3鏅ꯇꛉ迋ꇍ뻏ꛑ뗓뗕곗裙맛뷝鏟蟡郣", A_1_1);
                      nMaxRecs = modelTiering.GetRecordsetDataFromEngine(strFullyQualifiedRecordsetName3, ModelTiering.RecsetAttributeTypes.MaxRecords);
                      num2 = (short) 176 /*0xB0*/;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 52:
                      if (feature3 != null)
                      {
                        num2 = (short) 24;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 181;
                    case 53:
                      num2 = (short) 238;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 54:
                      num2 = (short) 208 /*0xD0*/;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 55:
                      num2 = (short) 135;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 56:
                      if (flag)
                      {
                        num2 = (short) 7;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 29;
                    case 57:
                    case 137:
                      num2 = (short) 6;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 58:
                      num2 = (short) 233;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 59:
                      if (A_1._data == null)
                      {
                        num2 = (short) 109;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      num2 = (short) 147;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 60:
                      if (nMaxRecs != -1)
                      {
                        num2 = (short) 80 /*0x50*/;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 25;
                    case 61:
                      enumerator = ((Collection<FeatureNode>) feature6).GetEnumerator();
                      num2 = (short) 131;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 62:
                      num2 = (short) 66;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 63 /*0x3F*/:
                      flag = false;
                      num2 = (short) 183;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 64 /*0x40*/:
                      string strFullyQualifiedRecordsetName4 = RptMgrErrorHandler.b("쎍ﾏ\uE691ﮓ\uE495\uF797\uF699ﶛ낝\uED9F쎡잣춥솧쒩춫\uD9AD\uF3AF\uE2B1\uE7B3颵﮷햹캻\uDBBD蚿\uA7C1ꗃ닅뷇룉꧋뷍ﻏ蛑ꛓꏕ뛗뇙뗛냝蟟닡臣铥鯧藩苫迭鳯鯱胳迵훷껹軻诽滿椁洃栅漇娉椋簍挏紑稓眕琗猙栛朝爟䜡䜣唥䴧帩", A_1_1);
                      nMaxRecs = modelTiering.GetRecordsetDataFromEngine(strFullyQualifiedRecordsetName4, ModelTiering.RecsetAttributeTypes.MaxRecords);
                      num2 = (short) 28;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 65:
                      num2 = (short) 81;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 66:
                      if (A_1.recSetCounts.Find((Predicate<AstroRecSetCountsItem>) (x =>
                      {
                        int A_1_3 = 10;
                        if (x._recSetName == RptMgrErrorHandler.b("힌\uE08Eﾐ\uF692횔ﾖ\uF898\uF59A\uF39C爵춠\uE2A2횤풦삨첪쎬슮풰\uDDB2솴\uE5B6\uDCB8\uD8BA캼\uDABE뗀", A_1_3))
                        {
                          short num4 = -10762;
                          int num5 = (int) num4;
                          num4 = (short) -10762;
                          int num6 = (int) num4;
                          switch (num5 == num6 ? 1 : 0)
                          {
                            case 0:
                            case 2:
                              break;
                            default:
                              num4 = (short) 0;
                              if (num4 == (short) 0)
                                ;
                              num4 = (short) 1;
                              if (num4 == (short) 0)
                                ;
                              return x._count > nMaxRecs;
                          }
                        }
                        return false;
                      })) != null)
                      {
                        num2 = (short) 107;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 122;
                    case 67:
                      if (A_1.recSetCounts != null)
                      {
                        num2 = (short) 113;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 165;
                    case 68:
                      if (A_1.recSetCounts != null)
                      {
                        num2 = (short) 89;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 33;
                    case 69:
                      num2 = (short) 221;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 70:
                      num2 = (short) 79;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 71:
                      num2 = (short) 91;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 72:
                      num2 = (short) 48 /*0x30*/;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 73:
                      num2 = (short) 219;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 74:
                      if (A_1.recSetCounts.Count > 0)
                      {
                        num2 = (short) 99;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 33;
                    case 75:
                      if (flag)
                      {
                        num2 = (short) 123;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 57;
                    case 76:
                      embeddedRecset2 = FeatureManager.GetFeature(2051)[0][10114].EmbeddedRecset as ChannelAssignmentListInnerRecset;
                      num2 = (short) 200;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 77:
                      num2 = (short) 175;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 78:
                      num2 = (short) 133;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 79:
                      if (A_1.recSetCounts.Find((Predicate<AstroRecSetCountsItem>) (x =>
                      {
                        int A_1_4 = 0;
                        short num7 = 0;
                        if (x._recSetName == RptMgrErrorHandler.b("삂\uED84\uE686\uE788\uE58A\uE88C\uE38E킐\uE092\uE694ﺖﺘ\uF59A\uF09C爵쾠힢\uE9A4캦\uDAA8\uDFAA\uE4AC솮\uDFB0횲잴\uE5B6\uDCB8\uD8BA캼\uDABE뗀", A_1_4))
                        {
                          num7 = (short) -8147;
                          int num8 = (int) num7;
                          num7 = (short) -8147;
                          int num9 = (int) num7;
                          switch (num8 == num9 ? 1 : 0)
                          {
                            case 0:
                            case 2:
                              break;
                            default:
                              num7 = (short) 1;
                              if (num7 == (short) 0)
                                ;
                              num7 = (short) 0;
                              if (num7 == (short) 0)
                                ;
                              return x._maxPool - x._counterToMaxPool > nMaxPoolRecs;
                          }
                        }
                        return false;
                      })) != null)
                      {
                        num2 = (short) 101;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 29;
                    case 80 /*0x50*/:
                      num2 = (short) 114;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 81:
                      if (A_1.recSetCounts.Find((Predicate<AstroRecSetCountsItem>) (x =>
                      {
                        int A_1_5 = 7;
                        if (x._recSetName == RptMgrErrorHandler.b("\uDE89ﺋﮍﺏ撚ﶓ\uF895ﾗ즙\uE59B\uED9D풟잡즣\uF4A5춧즩\uDFAB쮭쒯", A_1_5))
                        {
                          short num10 = -32722;
                          switch ((short) -32722 == num10 ? 1 : 0)
                          {
                            case 0:
                            case 2:
                              break;
                            default:
                              num10 = (short) 0;
                              if (num10 == (short) 0)
                                ;
                              num10 = (short) 1;
                              if (num10 == (short) 0)
                                ;
                              return x._count > nMaxRecs;
                          }
                        }
                        return false;
                      })) != null)
                      {
                        num2 = (short) 141;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 33;
                    case 82:
                      if (flag)
                      {
                        num2 = (short) 51;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 128 /*0x80*/;
                    case 83:
                      flag = false;
                      num2 = (short) 37;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 84:
                      num2 = (short) 193;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 85:
                      if (!((Recordset) feature2).HiddenStatic)
                      {
                        num2 = (short) 226;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 25;
                    case 86:
                      if (A_1.recSetCounts.Find((Predicate<AstroRecSetCountsItem>) (x =>
                      {
                        int A_1_6 = 10;
                        short num11 = 0;
                        if (x._recSetName == RptMgrErrorHandler.b("캌\uE08Eﾐ\uE592\uF094練\uED98\uF29A\uF29C\uF19E삠쾢\uF6A4\uDEA6\uDAA8\uDFAA좬슮\uE3B0횲횴쒶\uDCB8쾺", A_1_6))
                        {
                          num11 = (short) 1;
                          if (num11 == (short) 0)
                            ;
                          num11 = (short) 2331;
                          int num12 = (int) num11;
                          num11 = (short) 2331;
                          int num13 = (int) num11;
                          switch (num12 == num13 ? 1 : 0)
                          {
                            case 0:
                            case 2:
                              break;
                            default:
                              num11 = (short) 0;
                              if (num11 == (short) 0)
                                ;
                              return x._count > nMaxRecs;
                          }
                        }
                        return false;
                      })) != null)
                      {
                        num2 = (short) 180;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 25;
                    case 87:
                      flag = false;
                      num2 = (short) 229;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 88:
                      if (!feature4.HiddenStatic)
                      {
                        num2 = (short) 55;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 57;
                    case 89:
                      num2 = (short) 74;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 90:
                      if (A_1.recSetCounts.Find((Predicate<AstroRecSetCountsItem>) (x =>
                      {
                        int A_1_7 = 19;
                        short num14 = 0;
                        if (x._recSetName == RptMgrErrorHandler.b("펕\uF697蓮\uEE9B\uE79D킟횡춣즥욧\uE1A9즫\uD7ADﲯ\uDBB1잳습\uF1B7풹튻\uDBBD늿郁ꇃꗅ믇꿉룋", A_1_7))
                        {
                          num14 = (short) 22759;
                          int num15 = (int) num14;
                          num14 = (short) 22759;
                          int num16 = (int) num14;
                          switch (num15 == num16 ? 1 : 0)
                          {
                            case 0:
                            case 2:
                              break;
                            default:
                              num14 = (short) 1;
                              if (num14 == (short) 0)
                                ;
                              num14 = (short) 0;
                              if (num14 == (short) 0)
                                ;
                              return x._count > nMaxRecs;
                          }
                        }
                        return false;
                      })) != null)
                      {
                        num2 = (short) 184;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 3;
                    case 91:
                      if (!((Recordset) feature6).HiddenStatic)
                      {
                        num2 = (short) 152;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 165;
                    case 92:
                      if (nMaxRecs != -1)
                      {
                        num2 = (short) 156;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 128 /*0x80*/;
                    case 93:
                      num2 = (short) 8;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 94:
                      if (A_1.recSetCounts.Count > 0)
                      {
                        num2 = (short) 121;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 128 /*0x80*/;
                    case 95:
                      goto label_380;
                    case 96 /*0x60*/:
                      num2 = (short) 216;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 97:
                      num2 = (short) 198;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 98:
                      if (nMaxRecs != -1)
                      {
                        num2 = (short) 129;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 33;
                    case 99:
                      num2 = (short) 191;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 100:
                      if (!((Recordset) feature5).HiddenStatic)
                      {
                        num2 = (short) 231;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 122;
                    case 101:
                      flag = false;
                      num2 = (short) 199;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 102:
                      if (nMaxPoolRecs != -1)
                      {
                        num2 = (short) 70;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 29;
                    case 103:
                      if (!((Recordset) feature3).HiddenStatic)
                      {
                        num2 = (short) 97;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 181;
                    case 104:
                      if (A_1.recSetCounts.Count > 0)
                      {
                        num2 = (short) 42;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 165;
                    case 105:
                      num2 = (short) 20;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 106:
                      flag = false;
                      num2 = (short) 40;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 107:
                      flag = false;
                      num2 = (short) 122;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 108:
                      flag = false;
                      num2 = (short) 185;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 109:
                      feature2 = FeatureManager.GetFeature(2053) as ConventionalSystemRecset;
                      num2 = (short) 32 /*0x20*/;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 110:
                      if (!((Recordset) embeddedRecset1).HiddenStatic)
                      {
                        num2 = (short) 54;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 3;
                    case 111:
                      num2 = (short) 228;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 112 /*0x70*/:
                      num2 = (short) 182;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 113:
                      num2 = (short) 104;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 114:
                      if (((Recordset) feature2).Count > nMaxRecs)
                      {
                        num2 = (short) 108;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 25;
                    case 115:
                      if (feature6 != null)
                      {
                        num2 = (short) 71;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 165;
                    case 117:
                      num2 = (short) 178;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 118:
                      flag = false;
                      num2 = (short) 137;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 119:
                      if (nMaxRecs != -1)
                      {
                        num2 = (short) 58;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 40;
                    case 120:
                      if (flag)
                      {
                        num2 = (short) 64 /*0x40*/;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 36;
                    case 121:
                      num2 = (short) 92;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 122:
                    case 229:
                      num2 = (short) 56;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 123:
                      string strFullyQualifiedRecordsetName5 = RptMgrErrorHandler.b("\uDD8D\uE08F\uF791\uF793ﾕ聯\uF699\uDA9Bﮝ솟횡톣풥춧\uD9A9芫\uF8AD\uDFAF\uDBB1ힳ펵醴풹튻톽떿곁\uA7C3ꏅꗇ꿉ꋋ뫍ꏏﳑ飓뿕ꯗ껙\uF2DB裝迟诡蟣菥ꧧ蓩苫臭藯鳱音鏵闷\u9FF9鋻諽䳿欁眃爅娇漉漋崍甏昑", A_1_1);
                      nMaxRecs = modelTiering.GetRecordsetDataFromEngine(strFullyQualifiedRecordsetName5, ModelTiering.RecsetAttributeTypes.MaxRecords);
                      num2 = (short) 207;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 124:
                      if (A_1._data == null)
                      {
                        num2 = (short) 130;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      num2 = (short) 22;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 125:
                      if (A_1._data == null)
                      {
                        num2 = (short) 195;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      num2 = (short) 136;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 126:
                      flag = false;
                      num2 = (short) 165;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case (int) sbyte.MaxValue:
                      string strFullyQualifiedRecordsetName6 = RptMgrErrorHandler.b("쎍ﾏ\uE691ﮓ\uE495\uF797\uF699ﶛ낝\uED9F쎡잣춥솧쒩춫\uD9AD\uF3AF\uE2B1\uE7B3颵﮷햹캻\uDBBD蚿\uA7C1ꗃ닅뷇룉꧋뷍ﻏ裑믓룕뷗駙듛뿝軟賡臣諥ꧧ駩\u9FEB蟭韯鳱駳鏵雷軹틻ꓽ濿氁愃䔅怇欉戋怍甏縑唓攕欗猙笛瀝䴟䜡䨣別稧伩伫崭唯䘱", A_1_1);
                      nMaxRecs = modelTiering.GetRecordsetDataFromEngine(strFullyQualifiedRecordsetName6, ModelTiering.RecsetAttributeTypes.MaxRecords);
                      num2 = (short) 124;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 128 /*0x80*/:
                    case 138:
                      num2 = (short) 186;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 129:
                      num2 = (short) 50;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 130:
                      feature5 = FeatureManager.GetFeature(2051) as ZoneChannelAssignmentRecset;
                      num2 = (short) 150;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 131:
                      try
                      {
                        num2 = (short) 3;
                        int num17 = (int) (IntPtr) num2;
                        while (true)
                        {
                          switch (num17)
                          {
                            case 0:
                            case 5:
label_147:
                              num2 = (short) 1;
                              num17 = (int) (IntPtr) num2;
                              continue;
                            case 1:
                              goto label_277;
                            case 2:
                              flag = false;
                              num2 = (short) 10622;
                              int num18 = (int) num2;
                              num2 = (short) 10622;
                              int num19 = (int) num2;
                              switch (num18 == num19 ? 1 : 0)
                              {
                                case 0:
                                case 2:
                                  goto label_147;
                                default:
                                  num2 = (short) 0;
                                  if (num2 == (short) 0)
                                    ;
                                  num2 = (short) 5;
                                  num17 = (int) (IntPtr) num2;
                                  continue;
                              }
                            case 3:
                              switch (0)
                              {
                                case 0:
                                  break;
                                default:
                                  continue;
                              }
                              break;
                            case 4:
                              if (!enumerator.MoveNext())
                              {
                                num2 = (short) 0;
                                num17 = (int) (IntPtr) num2;
                                continue;
                              }
                              num2 = (short) 6;
                              num17 = (int) (IntPtr) num2;
                              continue;
                            case 6:
                              if (((Recordset) (((FeatureSection) ((Motorola.MackinawCPS.CoreFeatures.SecureKMFProfile.SecureKMFProfile) enumerator.Current).SecureHardwareEncryptionKeyReferencesList).EmbeddedRecset as SecureHardwareEncryptionKeyReferencesListInnerRecset)).Count > nMaxRecs)
                              {
                                num2 = (short) 2;
                                num17 = (int) (IntPtr) num2;
                                continue;
                              }
                              break;
                          }
                          num2 = (short) 4;
                          num17 = (int) (IntPtr) num2;
                        }
                      }
                      finally
                      {
                        int num20 = 0;
                        while (true)
                        {
                          short num21;
                          switch (num20)
                          {
                            case 0:
                              switch (0)
                              {
                                case 0:
                                  break;
                                default:
                                  continue;
                              }
                              break;
                            case 1:
                              goto label_154;
                            case 2:
                              enumerator.Dispose();
                              num21 = (short) 1;
                              num20 = (int) (IntPtr) num21;
                              continue;
                          }
                          if (enumerator != null)
                          {
                            num21 = (short) 2;
                            num20 = (int) (IntPtr) num21;
                          }
                          else
                            break;
                        }
label_154:;
                      }
                    case 132:
                      feature9 = FeatureManager.GetFeature(2072) as TrunkingPersonalityRecset;
                      num2 = (short) 167;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 133:
                      if (A_1.recSetCounts.Find((Predicate<AstroRecSetCountsItem>) (x =>
                      {
                        int A_1_8 = 10;
                        short num22 = 0;
                        if (x._recSetName == RptMgrErrorHandler.b("첌\uDC8E얐솒\uDA94쎖\uF898\uF79A\uF69C\uF89E펠첢키\uD7A6\uE5A8슪\uDEAC\uDBAE\uE3B0횲횴쒶\uDCB8쾺", A_1_8))
                        {
                          num22 = (short) 21501;
                          int num23 = (int) num22;
                          num22 = (short) 21501;
                          int num24 = (int) num22;
                          switch (num23 == num24 ? 1 : 0)
                          {
                            case 0:
                            case 2:
                              break;
                            default:
                              num22 = (short) 1;
                              if (num22 == (short) 0)
                                ;
                              num22 = (short) 0;
                              if (num22 == (short) 0)
                                ;
                              return x._count > nMaxRecs;
                          }
                        }
                        return false;
                      })) != null)
                      {
                        num2 = (short) 63 /*0x3F*/;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 40;
                    case 134:
                      if (A_1.recSetCounts.Find((Predicate<AstroRecSetCountsItem>) (x =>
                      {
                        int A_1_9 = 12;
                        if (x._recSetName == RptMgrErrorHandler.b("\uDA8E\uF290ﾒ횔\uF896\uF798\uEF9Aﲜﲞ햠\uF1A2삤쒦\uDAA8캪\uD9AC", A_1_9))
                        {
                          short num25 = 1;
                          if (num25 == (short) 0)
                            ;
                          num25 = (short) -1450;
                          int num26 = (int) num25;
                          num25 = (short) -1450;
                          int num27 = (int) num25;
                          switch (num26 == num27 ? 1 : 0)
                          {
                            case 0:
                            case 2:
                              break;
                            default:
                              num25 = (short) 0;
                              if (num25 == (short) 0)
                                ;
                              return x._count > nMaxRecs;
                          }
                        }
                        return false;
                      })) != null)
                      {
                        num2 = (short) 212;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 128 /*0x80*/;
                    case 135:
                      if (nMaxRecs != -1)
                      {
                        num2 = (short) 112 /*0x70*/;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 57;
                    case 136:
                      if (A_1.recSetCounts != null)
                      {
                        num2 = (short) 34;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 3;
                    case 139:
                      if (nMaxRecs != -1)
                      {
                        num2 = (short) 174;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 181;
                    case 140:
                      if (feature4 != null)
                      {
                        num2 = (short) 190;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 57;
                    case 141:
                      flag = false;
                      num2 = (short) 159;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 142:
                      if (A_1.recSetCounts != null)
                      {
                        num2 = (short) 77;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 29;
                    case 143:
                      num2 = (short) 227;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 144 /*0x90*/:
                      if (((Recordset) feature5).Count > nMaxRecs)
                      {
                        num2 = (short) 87;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 122;
                    case 145:
                      if (A_1.recSetCounts != null)
                      {
                        num2 = (short) 117;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 40;
                    case 146:
                      num2 = (short) 187;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 147:
                      if (A_1.recSetCounts != null)
                      {
                        num2 = (short) 93;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 25;
                    case 148:
                      if (A_1.recSetCounts != null)
                      {
                        num2 = (short) 96 /*0x60*/;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 181;
                    case 149:
                      if (A_1._data != null)
                      {
                        num2 = (short) 67;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      num2 = (short) 158;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 150:
                      if (feature5 != null)
                      {
                        num2 = (short) 166;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 122;
                    case 151:
                      num2 = (short) 235;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 152:
                      num2 = (short) 189;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 153:
                      num2 = (short) 2;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 154:
                      num2 = (short) 171;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 155:
                      string strFullyQualifiedRecordsetName7 = RptMgrErrorHandler.b("쎍ﾏ\uE691ﮓ\uE495\uF797\uF699ﶛ낝\uED9F쎡잣춥솧쒩춫\uD9AD\uF3AF\uE2B1\uE7B3颵﮷햹캻\uDBBD蚿\uA7C1ꗃ닅뷇룉꧋뷍ﻏ裑믓룕뷗駙듛뿝軟賡臣諥ꧧ駩\u9FEB蟭韯鳱駳鏵雷軹틻ꓽ濿氁愃䔅怇欉戋怍甏縑唓攕欗猙笛瀝䴟䜡䨣別稧伩伫崭唯䘱", A_1_1);
                      nMaxRecs = modelTiering.GetRecordsetDataFromEngine(strFullyQualifiedRecordsetName7, ModelTiering.RecsetAttributeTypes.MaxRecords);
                      num2 = (short) 5;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 156:
                      num2 = (short) 134;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 157:
                      if (A_1.recSetCounts.Find((Predicate<AstroRecSetCountsItem>) (x =>
                      {
                        int A_1_10 = 0;
                        if (x._recSetName == RptMgrErrorHandler.b("힂\uF784\uF286\uE788\uE08A\uE48C\uE18E\uF690쎒\uF094\uE596\uEA98\uF49A\uF39Cﺞ춠쪢톤\uDEA6ﮨ캪캬\uDCAE풰잲", A_1_10))
                        {
                          short num28 = 7909;
                          switch ((short) 7909 == num28 ? 1 : 0)
                          {
                            case 0:
                            case 2:
                              break;
                            default:
                              num28 = (short) 0;
                              if (num28 == (short) 0)
                                ;
                              num28 = (short) 1;
                              if (num28 == (short) 0)
                                ;
                              return x._count > nMaxRecs;
                          }
                        }
                        return false;
                      })) != null)
                      {
                        num2 = (short) 18;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 36;
                    case 158:
                      feature6 = FeatureManager.GetFeature(2055) as SecureKMFProfileRecset;
                      num2 = (short) 115;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 160 /*0xA0*/:
                      flag = false;
                      num2 = (short) 181;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 161:
                      if (A_1._data == null)
                      {
                        num2 = (short) 197;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      num2 = (short) 68;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 162:
                      if (flag)
                      {
                        num2 = (short) 168;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 165;
                    case 163:
                      num2 = (short) 98;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 164:
                      if (nMaxRecs != -1)
                      {
                        num2 = (short) 192 /*0xC0*/;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 165;
                    case 165:
label_277:
                      num2 = (short) 82;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 166:
                      num2 = (short) 100;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 167:
                      if (feature9 != null)
                      {
                        num2 = (short) 224 /*0xE0*/;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 36;
                    case 168:
                      string strFullyQualifiedRecordsetName8 = RptMgrErrorHandler.b("쎍ﾏ\uE691ﮓ\uE495\uF797\uF699ﶛ낝\uED9F쎡잣춥솧쒩춫\uD9AD\uF3AF\uE2B1\uE7B3颵﮷햹캻\uDBBD蚿\uA7C1ꗃ닅뷇룉꧋뷍ﻏ臑뇓뗕귗꣙맛闝귟ꓡ듣铥蟧賩藫苭闯\uDCF1\uA7F3鏵鯷迹軻鯽䣿持瘃戅缇欉縋欍唏簑眓搕愗標栛眝伟䰡漣䌥儧砩䤫䠭唯䀱儳堵嬷弹伻爽⤿ㅁぃཅ♇⑉⥋㱍ɏ㝑㝓╕㵗\u2E59", A_1_1);
                      nMaxRecs = modelTiering.GetRecordsetDataFromEngine(strFullyQualifiedRecordsetName8, ModelTiering.RecsetAttributeTypes.MaxRecords);
                      num2 = (short) 149;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 169:
                      if (A_1.recSetCounts.Find((Predicate<AstroRecSetCountsItem>) (x =>
                      {
                        int A_1_11 = 2;
                        if (x._recSetName == RptMgrErrorHandler.b("횄\uE286\uEA88ﺊﾌ\uEA8E\uD990\uF292\uE794\uF396\uEE98漢\uEF9C爵\uE4A0춢욤햦킨\uDBAA\uD9AC욮\uDEB0\uDDB2ﺴ튶삸\uE9BA\uD8BC\uD9BE꓀뇂ꃄ꧆\uAAC8껊뻌菎룐ꃒꇔ黖럘뗚룜귞돠蛢蛤铦賨\u9FEA", A_1_11))
                        {
                          short num29 = 21790;
                          int num30 = (int) num29;
                          num29 = (short) 21790;
                          int num31 = (int) num29;
                          switch (num30 == num31 ? 1 : 0)
                          {
                            case 0:
                            case 2:
                              break;
                            default:
                              num29 = (short) 1;
                              if (num29 == (short) 0)
                                ;
                              num29 = (short) 0;
                              if (num29 == (short) 0)
                                ;
                              return x._count > nMaxRecs;
                          }
                        }
                        return false;
                      })) != null)
                      {
                        num2 = (short) 126;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 165;
                    case 170:
                      flag = false;
                      num2 = (short) 218;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 171:
                      if (nMaxRecs != -1)
                      {
                        num2 = (short) 78;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 40;
                    case 172:
                      if (feature8 != null)
                      {
                        num2 = (short) 223;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 128 /*0x80*/;
                    case 173:
                      num2 = (short) 213;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 174:
                      num2 = (short) 39;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 175:
                      if (A_1.recSetCounts.Count > 0)
                      {
                        num2 = (short) 12;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 29;
                    case 176 /*0xB0*/:
                      if (A_1._data != null)
                      {
                        num2 = (short) 220;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      num2 = (short) 215;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 177:
                      string strFullyQualifiedRecordsetName9 = RptMgrErrorHandler.b("쎍ﾏ\uE691ﮓ\uE495\uF797\uF699ﶛ낝\uED9F쎡잣춥솧쒩춫\uD9AD\uF3AF\uE2B1\uE7B3颵﮷햹캻\uDBBD蚿\uA7C1ꗃ닅뷇룉꧋뷍ﻏ金믓룕껗뿙닛ꫝ觟跡諣蟥蓧맩闫鷭蓯韱駳\uD8F5믷闹鋻製旿氁瀃漅朇搉洋戍䌏欑朓戕紗眙丛笝䌟儡䄣別", A_1_1);
                      nMaxRecs = modelTiering.GetRecordsetDataFromEngine(strFullyQualifiedRecordsetName9, ModelTiering.RecsetAttributeTypes.MaxRecords);
                      num2 = (short) 59;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 178:
                      if (A_1.recSetCounts.Count > 0)
                      {
                        num2 = (short) 154;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 40;
                    case 179:
                      if (A_1.recSetCounts.Count > 0)
                      {
                        num2 = (short) 143;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 3;
                    case 180:
                      flag = false;
                      num2 = (short) 25;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 181:
                    case 218:
                      num2 = (short) 9;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 182:
                      if (feature4.Count > nMaxRecs)
                      {
                        num2 = (short) 118;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 57;
                    case 184:
                      flag = false;
                      num2 = (short) 3;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 186:
                      if (flag)
                      {
                        num2 = (short) 155;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 181;
                    case 187:
                      if (!((Recordset) embeddedRecset2).HiddenStatic)
                      {
                        num2 = (short) 69;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 29;
                    case 188:
                      if (!((Recordset) feature1).HiddenStatic)
                      {
                        num2 = (short) 163;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 33;
                    case 189:
                      if (nMaxRecs != -1)
                      {
                        num2 = (short) 61;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 165;
                    case 190:
                      num2 = (short) 88;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 191:
                      if (nMaxRecs != -1)
                      {
                        num2 = (short) 65;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 33;
                    case 192 /*0xC0*/:
                      num2 = (short) 169;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 193:
                      if (nMaxRecs != -1)
                      {
                        num2 = (short) 62;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 122;
                    case 194:
                      string strFullyQualifiedRecordsetName10 = RptMgrErrorHandler.b("쎍ﾏ\uE691ﮓ\uE495\uF797\uF699ﶛ낝\uED9F쎡잣춥솧쒩춫\uD9AD\uF3AF\uE2B1\uE7B3颵﮷햹캻\uDBBD蚿\uA7C1ꗃ닅뷇룉꧋뷍ﻏ鏑蟓苕諗闙裛뿝賟觡菣铥蟧\u9FE9鳫ꋭ駯臱胳\uD8F5맷꧹ꣻ곽俿嘁攃樅指洉縋愍攏我堓缕欗渙丛笝䌟儡䄣別", A_1_1);
                      nMaxRecs = modelTiering.GetRecordsetDataFromEngine(strFullyQualifiedRecordsetName10, ModelTiering.RecsetAttributeTypes.MaxRecords);
                      num2 = (short) 21;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 195:
                      embeddedRecset1 = ((Recordset) (FeatureManager.GetFeature(2021) as SecureWideRecset))[0][10040].EmbeddedRecset as EncryptionKeyListInnerRecset;
                      num2 = (short) 10;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 196:
                      num2 = (short) 23;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 197:
                      feature1 = FeatureManager.GetFeature(2064) as TrunkingSystemRecset;
                      num2 = (short) 202;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 198:
                      if (nMaxRecs != -1)
                      {
                        num2 = (short) 111;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 181;
                    case 200:
                      if (embeddedRecset2 != null)
                      {
                        num2 = (short) 146;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 29;
                    case 201:
                      string strFullyQualifiedRecordsetName11 = RptMgrErrorHandler.b("쎍ﾏ\uE691ﮓ\uE495\uF797\uF699ﶛ낝\uED9F쎡잣춥솧쒩춫\uD9AD\uF3AF\uE2B1\uE7B3颵﮷햹캻\uDBBD蚿\uA7C1ꗃ닅뷇룉꧋뷍ﻏ臑뇓뗕귗꣙맛觝觟蛡臣죥귧蓩迫鳭觯英胳\u9FF5韷铹럻鯽秿丁洃甅簇䌉戋怍甏怑䘓猕笗椙礛樝", A_1_1);
                      nMaxRecs = modelTiering.GetRecordsetDataFromEngine(strFullyQualifiedRecordsetName11, ModelTiering.RecsetAttributeTypes.MaxRecords);
                      num2 = (short) 125;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 202:
                      if (feature1 != null)
                      {
                        num2 = (short) 27;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 33;
                    case 203:
                      feature4 = FeatureManager.GetFeature(2300) as VoiceAnnouncementListRecSet;
                      num2 = (short) 140;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 204:
                      flag = false;
                      num2 = (short) 116;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 205:
                      flag = false;
                      num2 = (short) 138;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 206:
                      if (!((Recordset) feature9).HiddenStatic)
                      {
                        num2 = (short) 151;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 36;
                    case 207:
                      if (A_1._data != null)
                      {
                        num2 = (short) 44;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      num2 = (short) 203;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 208 /*0xD0*/:
                      if (nMaxRecs != -1)
                      {
                        num2 = (short) 1;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 3;
                    case 209:
                      num2 = (short) 230;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 210:
                      if (A_1.recSetCounts.Count > 0)
                      {
                        num2 = (short) 84;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 122;
                    case 211:
                      num2 = (short) 94;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 212:
                      flag = false;
                      num2 = (short) 128 /*0x80*/;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 213:
                      if (A_1.recSetCounts.Count > 0)
                      {
                        num2 = (short) 209;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 57;
                    case 214:
                      if (((Recordset) feature9).Count > nMaxRecs)
                      {
                        num2 = (short) 83;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 36;
                    case 215:
                      feature8 = FeatureManager.GetFeature(2200) as UclContactRecset;
                      num2 = (short) 172;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 216:
                      if (A_1.recSetCounts.Count > 0)
                      {
                        num2 = (short) 38;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 181;
                    case 217:
                      if (feature7 != null)
                      {
                        num2 = (short) 72;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 40;
                    case 219:
                      if (A_1.recSetCounts.Find((Predicate<AstroRecSetCountsItem>) (x =>
                      {
                        int A_1_12 = 14;
                        short num32 = 0;
                        if (x._recSetName == RptMgrErrorHandler.b("자ﲒﲔ\uF496ﲘ\uDA9A\uF39C\uF19E캠횢쮤쒦첨욪좬솮얰ﾲ\uDCB4쒶춸\uE9BA\uD8BC\uDCBE鋀ꛂ뇄", A_1_12))
                        {
                          num32 = (short) 19935;
                          int num33 = (int) num32;
                          num32 = (short) 19935;
                          int num34 = (int) num32;
                          switch (num33 == num34 ? 1 : 0)
                          {
                            case 0:
                            case 2:
                              break;
                            default:
                              num32 = (short) 0;
                              if (num32 == (short) 0)
                                ;
                              num32 = (short) 1;
                              if (num32 == (short) 0)
                                ;
                              return x._count > nMaxRecs;
                          }
                        }
                        return false;
                      })) != null)
                      {
                        num2 = (short) 13;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 57;
                    case 220:
                      if (A_1.recSetCounts != null)
                      {
                        num2 = (short) 211;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 128 /*0x80*/;
                    case 221:
                      if (nMaxPoolRecs != -1)
                      {
                        num2 = (short) 234;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 29;
                    case 222:
                      num2 = (short) 85;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 223:
                      num2 = (short) 47;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 224 /*0xE0*/:
                      num2 = (short) 206;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 225:
                      num2 = (short) 214;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 226:
                      num2 = (short) 60;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 227:
                      if (nMaxRecs != -1)
                      {
                        num2 = (short) 17;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 3;
                    case 228:
                      if (((Recordset) feature3).Count > nMaxRecs)
                      {
                        num2 = (short) 160 /*0xA0*/;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 181;
                    case 230:
                      if (nMaxRecs != -1)
                      {
                        num2 = (short) 73;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 57;
                    case 231:
                      num2 = (short) 45;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 232:
                      num2 = (short) 157;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 233:
                      if (((Recordset) feature7).Count > nMaxRecs)
                      {
                        num2 = (short) 106;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 40;
                    case 234:
                      num2 = (short) 14;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 235:
                      if (nMaxRecs != -1)
                      {
                        num2 = (short) 225;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 36;
                    case 236:
                      flag = false;
                      num2 = (short) 33;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 237:
                      flag = false;
                      num2 = (short) 29;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 238:
                      if (nMaxRecs != -1)
                      {
                        num2 = (short) 11;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 25;
                    default:
                      goto label_5;
                  }
                }
            }
          }
          finally
          {
            short num35 = 0;
            int num36 = (int) (IntPtr) num35;
            while (true)
            {
              switch (num36)
              {
                case 0:
                  switch (0)
                  {
                    case 0:
                      break;
                    default:
                      continue;
                  }
                  break;
                case 1:
                  goto label_378;
                case 2:
                  modelTiering.Dispose();
                  num35 = (short) 1;
                  num36 = (int) (IntPtr) num35;
                  continue;
              }
              if (modelTiering != null)
              {
                num35 = (short) 2;
                num36 = (int) (IntPtr) num35;
              }
              else
                break;
            }
label_378:;
          }
        }
        catch (Exception ex)
        {
          flag = false;
        }
label_380:
        short num37 = 0;
        num37 = (short) 1;
        if (num37 == (short) 0)
          ;
        return flag;
    }
  }
}
