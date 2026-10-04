// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.Comms.ParseDataHelper
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using AcpCommonLib;
using Common;
using CommonResources;
using Motorola.Acp.PackUnpack.Ish.Layouts;
using Motorola.Common.Communication.CommonUtil;
using Motorola.Common.Communication.Pba;
using SpecialFeatures.AcpReportManagerLib;
using SpecialFeatures.Flashport.FlashRadio;
using SpecialFeatures.Security;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;

#nullable disable
namespace SpecialFeatures.Comms;

public static class ParseDataHelper
{
  internal const int TRUNKING_SYSTEM_COUNT_MSB_INDEX = 5;
  internal const int TRUNKING_SYSTEM_COUNT_LSB_INDEX = 6;
  internal const int TRUNKING_SYSTEM_NAME_SIZE_MSB_INDEX = 1;
  internal const int TRUNKING_SYSTEM_NAME_SIZE_LSB_INDEX = 2;
  internal const int TRUNKING_SYSTEM_NAME_STRING_START_INDEX = 19;
  internal const int TRUNKING_SYSTEM_ID_MSB_INDEX = 59;
  internal const int TRUNKING_SYSTEM_ID_LSB_INDEX = 60;
  internal const int TRUNKING_SYSTEM_ASK_REQUIRED_BYTE_INDEX = 130;
  internal const int TRUNKING_SYSTEM_UNIT_ID_MSB_INDEX = 63 /*0x3F*/;
  internal const int TRUNKING_SYSTEM_UNIT_ID_BYTE_3_INDEX = 64 /*0x40*/;
  internal const int TRUNKING_SYSTEM_UNIT_ID_BYTE_2_INDEX = 65;
  internal const int TRUNKING_SYSTEM_UNIT_ID_LSB_INDEX = 66;
  internal const int TRUNKING_SYSTEM_SYSTEM_TYPE_BYTE_INDEX = 1;

  internal static string[] ReadRadioTrkSysNames(IshItemCollection ishItemCollection)
  {
label_0:
    short num1 = 0;
    int num2 = (int) num1;
    switch (num2)
    {
      default:
        num1 = (short) 0;
        string[] strArray1;
        switch (0)
        {
          case 0:
label_3:
            strArray1 = (string[]) null;
            num1 = (short) 0;
            num2 = (int) (IntPtr) num1;
            goto default;
          default:
            IEnumerator<KeyValuePair<IshHeader, IshItem>> enumerator;
            while (true)
            {
              switch (num2)
              {
                case 0:
                  if (ishItemCollection != null)
                  {
                    num1 = (short) 1;
                    num2 = (int) (IntPtr) num1;
                    continue;
                  }
                  goto label_40;
                case 1:
                  num1 = (short) 1;
                  if (num1 == (short) 0)
                    ;
                  num1 = (short) 4;
                  num2 = (int) (IntPtr) num1;
                  continue;
                case 2:
                  goto label_7;
                case 3:
                  goto label_40;
                case 4:
                  if (((IEnumerable<KeyValuePair<IshHeader, IshItem>>) ishItemCollection).Any<KeyValuePair<IshHeader, IshItem>>())
                  {
                    enumerator = ishItemCollection.GetEnumerator();
                    num1 = (short) 2;
                    num2 = (int) (IntPtr) num1;
                    continue;
                  }
                  num1 = (short) 3;
                  num2 = (int) (IntPtr) num1;
                  continue;
                default:
                  goto label_3;
              }
            }
label_7:
            try
            {
              num1 = (short) 2;
              int num3 = (int) (IntPtr) num1;
              while (true)
              {
                int num4;
                int length;
                int num5;
                KeyValuePair<IshHeader, IshItem> current;
                IshItem ishItem;
                int num6;
                IshHeader key;
                switch (num3)
                {
                  case 0:
                    if (!enumerator.MoveNext())
                    {
                      num1 = (short) 8;
                      num3 = (int) (IntPtr) num1;
                      continue;
                    }
                    current = enumerator.Current;
                    key = current.Key;
                    num1 = (short) 4;
                    num3 = (int) (IntPtr) num1;
                    continue;
                  case 1:
                    if (((IshItem) ref ishItem).Data != null)
                    {
                      num1 = (short) 10;
                      num3 = (int) (IntPtr) num1;
                      continue;
                    }
                    break;
                  case 2:
                    switch (0)
                    {
                      case 0:
                        break;
                      default:
                        continue;
                    }
                    break;
                  case 3:
                    if (num4 >= length)
                    {
                      num1 = (short) 6;
                      num3 = (int) (IntPtr) num1;
                      continue;
                    }
                    string[] strArray2 = strArray1;
                    int index1 = num4;
                    Encoding bigEndianUnicode = Encoding.BigEndianUnicode;
                    ishItem = current.Value;
                    byte[] data = ((IshItem) ref ishItem).Data;
                    int index2 = num5;
                    int count = num6;
                    string str = bigEndianUnicode.GetString(data, index2, count);
                    strArray2[index1] = str;
                    num5 += num6;
                    ++num4;
                    num1 = (short) 12;
                    num3 = (int) (IntPtr) num1;
                    continue;
                  case 4:
                    if (((IshHeader) ref key).IshType == (ushort) 1080)
                    {
                      num1 = (short) 14;
                      num3 = (int) (IntPtr) num1;
                      continue;
                    }
                    break;
                  case 5:
                  case 12:
                    num1 = (short) 3;
                    num3 = (int) (IntPtr) num1;
                    continue;
                  case 6:
                    num1 = (short) 11;
                    num3 = (int) (IntPtr) num1;
                    continue;
                  case 7:
                  case 11:
                    goto label_41;
                  case 8:
                    num1 = (short) 7;
                    num3 = (int) (IntPtr) num1;
                    continue;
                  case 9:
                    strArray1 = new string[length];
                    num5 = 19;
                    ishItem = current.Value;
                    int num7 = (int) ((IshItem) ref ishItem).Data[1] << 8;
                    ishItem = current.Value;
                    int num8 = (int) ((IshItem) ref ishItem).Data[2];
                    num6 = num7 | num8;
                    num4 = 0;
                    num1 = (short) 5;
                    num3 = (int) (IntPtr) num1;
                    continue;
                  case 10:
                    ishItem = current.Value;
                    int num9 = (int) ((IshItem) ref ishItem).Data[5];
                    ishItem = current.Value;
                    byte num10 = ((IshItem) ref ishItem).Data[6];
                    length = num9 << 8 | (int) num10;
                    num1 = (short) 13;
                    num3 = (int) (IntPtr) num1;
                    continue;
                  case 13:
                    if (length < (int) byte.MaxValue)
                    {
                      num1 = (short) 9;
                      num3 = (int) (IntPtr) num1;
                      continue;
                    }
                    break;
                  case 14:
                    ishItem = current.Value;
                    num1 = (short) 1;
                    num3 = (int) (IntPtr) num1;
                    continue;
                }
                num1 = (short) 0;
                num3 = (int) (IntPtr) num1;
              }
            }
            finally
            {
              int num11 = 0;
              while (true)
              {
                switch (num11)
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
                    enumerator.Dispose();
                    num11 = 2;
                    continue;
                  case 2:
                    goto label_35;
                }
                if (enumerator != null)
                  num11 = 1;
                else
                  break;
              }
label_35:;
            }
label_41:
            num1 = (short) 22292;
            int num12 = (int) num1;
            num1 = (short) 22292;
            int num13 = (int) num1;
            switch (num12 == num13 ? 1 : 0)
            {
              case 0:
              case 2:
                goto label_0;
              default:
                num1 = (short) 0;
                if (num1 == (short) 0)
                  ;
                return strArray1;
            }
label_40:
            return (string[]) null;
        }
    }
  }

  internal static void ReadRadioTrkSystemNamesAndIds(
    IshItemCollection ishItemCollection,
    out Dictionary<string, int> radioTrkSysNamesAndIdsWithAskReqOn,
    out Dictionary<string, int> radioTrkSysNamesAndIdsWithAskReqOff)
  {
    short num1 = -31925;
    int num2 = (int) num1;
    num1 = (short) -31925;
    int num3 = (int) num1;
    short num4;
    int num5;
    switch (num2 == num3 ? 1 : 0)
    {
      case 0:
      case 2:
label_46:
        num4 = (short) 4;
        num5 = (int) (IntPtr) num4;
        break;
      default:
        num4 = (short) 0;
        if (num4 == (short) 0)
          ;
        num4 = (short) 0;
        num5 = (int) num4;
        switch (num5)
        {
          default:
            num4 = (short) 0;
            switch (0)
            {
              case 0:
                goto label_5;
            }
            break;
        }
    }
    string[] strArray;
    IEnumerator<KeyValuePair<IshHeader, IshItem>> enumerator;
    while (true)
    {
      switch (num5)
      {
        case 0:
          if (ishItemCollection != null)
          {
            num4 = (short) 1;
            if (num4 == (short) 0)
              ;
            num4 = (short) 1;
            num5 = (int) (IntPtr) num4;
            continue;
          }
          goto label_49;
        case 1:
          goto label_46;
        case 2:
          goto label_9;
        case 3:
          strArray = ParseDataHelper.ReadRadioTrkSysNames(ishItemCollection);
          enumerator = ishItemCollection.GetEnumerator();
          num4 = (short) 2;
          num5 = (int) (IntPtr) num4;
          continue;
        case 4:
          if (ishItemCollection.Count > 0)
          {
            num4 = (short) 3;
            num5 = (int) (IntPtr) num4;
            continue;
          }
          goto label_43;
        default:
          goto label_5;
      }
label_4:;
    }
label_49:
    return;
label_9:
    int index;
    try
    {
      num4 = (short) 0;
      int num6 = (int) (IntPtr) num4;
      while (true)
      {
        KeyValuePair<IshHeader, IshItem> current;
        IshItem ishItem;
        int num7;
        IshHeader key;
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
            num4 = (short) 3;
            num6 = (int) (IntPtr) num4;
            continue;
          case 2:
            num4 = (short) 6;
            num6 = (int) (IntPtr) num4;
            continue;
          case 3:
            if (strArray != null)
            {
              num4 = (short) 4;
              num6 = (int) (IntPtr) num4;
              continue;
            }
            break;
          case 4:
            ishItem = current.Value;
            num4 = (short) 10;
            num6 = (int) (IntPtr) num4;
            continue;
          case 5:
            if (!enumerator.MoveNext())
            {
              num4 = (short) 2;
              num6 = (int) (IntPtr) num4;
              continue;
            }
            current = enumerator.Current;
            key = current.Key;
            num4 = (short) 9;
            num6 = (int) (IntPtr) num4;
            continue;
          case 6:
            goto label_41;
          case 7:
            try
            {
              switch (0)
              {
                case 0:
label_25:
                  ishItem = current.Value;
                  num4 = (short) 0;
                  num6 = (int) (IntPtr) num4;
                  goto default;
                default:
                  while (true)
                  {
                    switch (num6)
                    {
                      case 0:
                        if (((uint) ((IshItem) ref ishItem).Data[130] & 4U) > 0U)
                        {
                          num4 = (short) 1;
                          num6 = (int) (IntPtr) num4;
                          continue;
                        }
                        radioTrkSysNamesAndIdsWithAskReqOff.Add(strArray[index].TrimEnd(new char[1]), num7);
                        num4 = (short) 4;
                        num6 = (int) (IntPtr) num4;
                        continue;
                      case 1:
                        radioTrkSysNamesAndIdsWithAskReqOn.Add(strArray[index].TrimEnd(new char[1]), num7);
                        num4 = (short) 2;
                        num6 = (int) (IntPtr) num4;
                        continue;
                      case 2:
                      case 4:
                        num4 = (short) 3;
                        num6 = (int) (IntPtr) num4;
                        continue;
                      case 3:
                        goto label_22;
                      default:
                        goto label_25;
                    }
                  }
              }
            }
            catch (Exception ex)
            {
              SpecialFeatures.Comms.Comms.DispalyUpdateStatusChanged(0.0, AppResources.Duplicate_Trunking_System_Strings);
              Exception innerException = ex.InnerException;
              return;
            }
label_22:
            ++index;
            num4 = (short) 11;
            num6 = (int) (IntPtr) num4;
            continue;
          case 8:
            ishItem = current.Value;
            int num8 = (int) ((IshItem) ref ishItem).Data[59];
            ishItem = current.Value;
            byte num9 = ((IshItem) ref ishItem).Data[60];
            num7 = num8 << 8 | (int) num9;
            num4 = (short) 7;
            num6 = (int) (IntPtr) num4;
            continue;
          case 9:
            if (((IshHeader) ref key).IshType == (ushort) 3852)
            {
              num4 = (short) 1;
              num6 = (int) (IntPtr) num4;
              continue;
            }
            break;
          case 10:
            if (((IshItem) ref ishItem).Data != null)
            {
              num4 = (short) 8;
              num6 = (int) (IntPtr) num4;
              continue;
            }
            break;
        }
        num4 = (short) 5;
        num6 = (int) (IntPtr) num4;
      }
label_41:
      return;
    }
    finally
    {
      short num10 = 0;
      int num11 = (int) (IntPtr) num10;
      while (true)
      {
        switch (num11)
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
            enumerator.Dispose();
            num10 = (short) 2;
            num11 = (int) (IntPtr) num10;
            continue;
          case 2:
            goto label_44;
        }
        if (enumerator != null)
        {
          num10 = (short) 1;
          num11 = (int) (IntPtr) num10;
        }
        else
          break;
      }
label_44:;
    }
label_43:
    return;
label_5:
    radioTrkSysNamesAndIdsWithAskReqOff = new Dictionary<string, int>();
    radioTrkSysNamesAndIdsWithAskReqOn = new Dictionary<string, int>();
    index = 0;
    num4 = (short) 0;
    num5 = (int) (IntPtr) num4;
    goto label_4;
  }

  internal static Dictionary<string, int[]> ReadRadioTrkSystemNamesTypesAndUnitIds(
    IshItemCollection ishItemCollection)
  {
    short num1 = 12800;
    int num2 = (int) num1;
    num1 = (short) 12800;
    int num3 = (int) num1;
    short num4;
    int num5;
    switch (num2 == num3 ? 1 : 0)
    {
      case 0:
      case 2:
label_8:
        num4 = (short) 1;
        if (num4 == (short) 0)
          ;
        num4 = (short) 4;
        num5 = (int) (IntPtr) num4;
        break;
      default:
        num4 = (short) 0;
        if (num4 == (short) 0)
          ;
        num4 = (short) 0;
        num5 = (int) num4;
        switch (num5)
        {
          default:
            num4 = (short) 0;
            switch (0)
            {
              case 0:
                goto label_5;
            }
            break;
        }
    }
    string[] strArray;
    IEnumerator<KeyValuePair<IshHeader, IshItem>> enumerator;
    while (true)
    {
      switch (num5)
      {
        case 0:
          if (ishItemCollection != null)
          {
            num4 = (short) 1;
            num5 = (int) (IntPtr) num4;
            continue;
          }
          goto label_40;
        case 1:
          goto label_8;
        case 2:
          goto label_9;
        case 3:
          strArray = ParseDataHelper.ReadRadioTrkSysNames(ishItemCollection);
          enumerator = ishItemCollection.GetEnumerator();
          num4 = (short) 2;
          num5 = (int) (IntPtr) num4;
          continue;
        case 4:
          if (ishItemCollection.Count > 0)
          {
            num4 = (short) 3;
            num5 = (int) (IntPtr) num4;
            continue;
          }
          goto label_40;
        default:
          goto label_5;
      }
label_4:;
    }
label_9:
    Dictionary<string, int[]> dictionary;
    int index;
    try
    {
      num4 = (short) 0;
      int num6 = (int) (IntPtr) num4;
      while (true)
      {
        KeyValuePair<IshHeader, IshItem> current;
        IshItem ishItem;
        byte num7;
        int num8;
        IshHeader key;
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
            num4 = (short) 3;
            num6 = (int) (IntPtr) num4;
            continue;
          case 2:
            num4 = (short) 6;
            num6 = (int) (IntPtr) num4;
            continue;
          case 3:
            if (strArray != null)
            {
              num4 = (short) 4;
              num6 = (int) (IntPtr) num4;
              continue;
            }
            break;
          case 4:
            ishItem = current.Value;
            num4 = (short) 10;
            num6 = (int) (IntPtr) num4;
            continue;
          case 5:
            if (!enumerator.MoveNext())
            {
              num4 = (short) 2;
              num6 = (int) (IntPtr) num4;
              continue;
            }
            current = enumerator.Current;
            key = current.Key;
            num4 = (short) 9;
            num6 = (int) (IntPtr) num4;
            continue;
          case 6:
            goto label_40;
          case 7:
            try
            {
              int[] numArray = new int[2]
              {
                (int) num7,
                num8
              };
              dictionary.Add(strArray[index], numArray);
            }
            catch (Exception ex)
            {
              SpecialFeatures.Comms.Comms.DispalyUpdateStatusChanged(0.0, AppResources.Duplicate_Trunking_System_Strings);
              Exception innerException = ex.InnerException;
              goto label_40;
            }
            ++index;
            num4 = (short) 11;
            num6 = (int) (IntPtr) num4;
            continue;
          case 8:
            ishItem = current.Value;
            num7 = ((IshItem) ref ishItem).Data[1];
            ishItem = current.Value;
            int num9 = (int) ((IshItem) ref ishItem).Data[63 /*0x3F*/];
            ishItem = current.Value;
            byte num10 = ((IshItem) ref ishItem).Data[64 /*0x40*/];
            ishItem = current.Value;
            byte num11 = ((IshItem) ref ishItem).Data[65];
            ishItem = current.Value;
            byte num12 = ((IshItem) ref ishItem).Data[66];
            num8 = num9 << 24 | (int) num10 << 16 /*0x10*/ | (int) num11 << 8 | (int) num12;
            num4 = (short) 7;
            num6 = (int) (IntPtr) num4;
            continue;
          case 9:
            if (((IshHeader) ref key).IshType == (ushort) 3852)
            {
              num4 = (short) 1;
              num6 = (int) (IntPtr) num4;
              continue;
            }
            break;
          case 10:
            if (((IshItem) ref ishItem).Data != null)
            {
              num4 = (short) 8;
              num6 = (int) (IntPtr) num4;
              continue;
            }
            break;
        }
        num4 = (short) 5;
        num6 = (int) (IntPtr) num4;
      }
    }
    finally
    {
      short num13 = 0;
      int num14 = (int) (IntPtr) num13;
      while (true)
      {
        switch (num14)
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
            enumerator.Dispose();
            num13 = (short) 2;
            num14 = (int) (IntPtr) num13;
            continue;
          case 2:
            goto label_35;
        }
        if (enumerator != null)
        {
          num13 = (short) 1;
          num14 = (int) (IntPtr) num13;
        }
        else
          break;
      }
label_35:;
    }
label_40:
    return dictionary;
label_5:
    dictionary = new Dictionary<string, int[]>();
    index = 0;
    num4 = (short) 0;
    num5 = (int) (IntPtr) num4;
    goto label_4;
  }

  internal static Dictionary<string, int[]> ReadConvSysIds(PbaObject pba)
  {
    int num1 = 0;
    switch (num1)
    {
      default:
        Dictionary<string, int[]> dictionary;
        IshItemCollection ishItemCollection;
        string[] strArray1;
        int index1;
        short num2;
        switch (0)
        {
          case 0:
label_3:
            dictionary = new Dictionary<string, int[]>();
            ishItemCollection = pba.GetCodeplugInIshItemCollection();
            strArray1 = new string[1];
            index1 = 0;
            num2 = (short) 3;
            num1 = (int) (IntPtr) num2;
            goto default;
          default:
            IEnumerator<KeyValuePair<IshHeader, IshItem>> enumerator;
            IshHeader key;
            while (true)
            {
              switch (num1)
              {
                case 0:
                  goto label_7;
                case 1:
                  try
                  {
                    num2 = (short) 0;
                    int num3 = (int) (IntPtr) num2;
                    while (true)
                    {
                      KeyValuePair<IshHeader, IshItem> current;
                      int num4;
                      int num5;
                      int num6;
                      int length;
                      switch (num3)
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
                        case 9:
                          goto label_78;
                        case 2:
                          strArray1 = new string[length];
                          num5 = 19;
                          IshItem ishItem1 = current.Value;
                          num6 = (int) ((IshItem) ref ishItem1).Data[1] << 8;
                          int num7 = num6;
                          ishItem1 = current.Value;
                          int num8 = (int) ((IshItem) ref ishItem1).Data[2];
                          num6 = num7 | num8;
                          num4 = 0;
                          num2 = (short) 6;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 3:
                          IshItem ishItem2 = current.Value;
                          int num9 = (int) ((IshItem) ref ishItem2).Data[5];
                          ishItem2 = current.Value;
                          byte num10 = ((IshItem) ref ishItem2).Data[6];
                          length = num9 << 8;
                          length |= (int) num10;
                          num2 = (short) 4;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 4:
                          if (length < (int) byte.MaxValue)
                          {
                            num2 = (short) 2;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          break;
                        case 5:
                        case 6:
                          num2 = (short) 11;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 7:
                          num2 = (short) 1;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 8:
                          if (enumerator.MoveNext())
                          {
                            current = enumerator.Current;
                            key = current.Key;
                            num2 = (short) 12;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 10;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 10:
                          num2 = (short) 9;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 11:
                          if (num4 < length)
                          {
                            string[] strArray2 = strArray1;
                            int index2 = num4;
                            Encoding bigEndianUnicode = Encoding.BigEndianUnicode;
                            IshItem ishItem3 = current.Value;
                            byte[] data = ((IshItem) ref ishItem3).Data;
                            int index3 = num5;
                            int count = num6;
                            string str = bigEndianUnicode.GetString(data, index3, count);
                            strArray2[index2] = str;
                            num5 += num6;
                            ++num4;
                            num2 = (short) 5;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 7;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 12:
                          if (((IshHeader) ref key).IshType == (ushort) 1076)
                          {
                            num2 = (short) 3;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          break;
                      }
                      num2 = (short) 8;
                      num3 = (int) (IntPtr) num2;
                    }
                  }
                  finally
                  {
                    int num11 = 2;
                    while (true)
                    {
                      short num12;
                      switch (num11)
                      {
                        case 0:
                          goto label_77;
                        case 1:
                          enumerator.Dispose();
                          num12 = (short) 0;
                          num11 = (int) (IntPtr) num12;
                          continue;
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
                      if (enumerator != null)
                      {
                        num12 = (short) 1;
                        num11 = (int) (IntPtr) num12;
                      }
                      else
                        break;
                    }
label_77:;
                  }
label_78:
                  enumerator = ishItemCollection.GetEnumerator();
                  num2 = (short) 0;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 2:
                  num2 = (short) 1;
                  if (num2 == (short) 0)
                    ;
                  enumerator = ishItemCollection.GetEnumerator();
                  num2 = (short) 1;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 3:
                  if (ishItemCollection.Count > 0)
                  {
                    num2 = (short) 2;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_79;
                default:
                  goto label_3;
              }
            }
label_7:
            try
            {
              num2 = (short) 0;
              int num13 = (int) (IntPtr) num2;
              while (true)
              {
                int[] numArray1;
                KeyValuePair<IshHeader, IshItem> current;
                IshItem ishItem;
                int[] numArray2;
                byte num14;
                int[] numArray3;
                switch (num13)
                {
                  case 0:
                    switch (0)
                    {
                      case 0:
                        goto label_14;
                      default:
                        continue;
                    }
                  case 1:
                    try
                    {
                      dictionary.Add(strArray1[index1], numArray2);
                      break;
                    }
                    catch (Exception ex)
                    {
                      switch (num14)
                      {
                        case 0:
                          SpecialFeatures.Comms.Comms.DispalyUpdateStatusChanged(0.0, AppResources.Duplicate_ASTRO_Conventional_System_Strings);
                          break;
                        case 2:
                          SpecialFeatures.Comms.Comms.DispalyUpdateStatusChanged(0.0, AppResources.Duplicate_DVRS_Conventional_System_Strings);
                          break;
                      }
                      Exception innerException = ex.InnerException;
                      goto label_79;
                    }
                  case 2:
                    if (num14 == (byte) 3)
                    {
                      num2 = (short) 15;
                      num13 = (int) (IntPtr) num2;
                      continue;
                    }
                    break;
                  case 3:
                    num2 = (short) 14;
                    num13 = (int) (IntPtr) num2;
                    continue;
                  case 4:
                    num2 = (short) 16 /*0x10*/;
                    num13 = (int) (IntPtr) num2;
                    continue;
                  case 5:
                    if (num14 != (byte) 0)
                    {
                      num2 = (short) 4;
                      num13 = (int) (IntPtr) num2;
                      continue;
                    }
                    goto case 8;
                  case 6:
                    if (((IshHeader) ref key).IshType == (ushort) 3868)
                    {
                      num2 = (short) 11;
                      num13 = (int) (IntPtr) num2;
                      continue;
                    }
                    goto default;
                  case 7:
                    if (num14 == (byte) 1)
                    {
                      num2 = (short) 10;
                      num13 = (int) (IntPtr) num2;
                      continue;
                    }
                    num2 = (short) 2;
                    num13 = (int) (IntPtr) num2;
                    continue;
                  case 8:
                    ishItem = current.Value;
                    int num15 = (int) ((IshItem) ref ishItem).Data[17];
                    ishItem = current.Value;
                    byte num16 = ((IshItem) ref ishItem).Data[18];
                    ishItem = current.Value;
                    byte num17 = ((IshItem) ref ishItem).Data[19];
                    int num18 = num15 << 16 /*0x10*/ | (int) num16 << 8 | (int) num17;
                    numArray2 = new int[2]
                    {
                      (int) num14,
                      num18
                    };
                    num2 = (short) 1;
                    num13 = (int) (IntPtr) num2;
                    continue;
                  case 9:
                    if (!enumerator.MoveNext())
                    {
                      num2 = (short) 3;
                      num13 = (int) (IntPtr) num2;
                      continue;
                    }
                    current = enumerator.Current;
                    key = current.Key;
                    num2 = (short) 6;
                    num13 = (int) (IntPtr) num2;
                    continue;
                  case 10:
                    ishItem = current.Value;
                    int num19 = (int) ((IshItem) ref ishItem).Data[20];
                    ishItem = current.Value;
                    byte num20 = ((IshItem) ref ishItem).Data[21];
                    int num21 = num19 << 8 | (int) num20;
                    numArray1 = new int[2]
                    {
                      (int) num14,
                      num21
                    };
                    num2 = (short) 13;
                    num13 = (int) (IntPtr) num2;
                    continue;
                  case 11:
                    ishItem = current.Value;
                    num14 = ((IshItem) ref ishItem).Data[1];
                    num2 = (short) 5;
                    num13 = (int) (IntPtr) num2;
                    continue;
                  case 12:
                    try
                    {
                      dictionary.Add(strArray1[index1], numArray3);
                      break;
                    }
                    catch (Exception ex)
                    {
                      SpecialFeatures.Comms.Comms.DispalyUpdateStatusChanged(0.0, AppResources.Duplicate_MDC_Conventional_System_Strings);
                      Exception innerException = ex.InnerException;
                      goto label_79;
                    }
                  case 13:
                    try
                    {
                      dictionary.Add(strArray1[index1], numArray1);
                      break;
                    }
                    catch (Exception ex)
                    {
                      SpecialFeatures.Comms.Comms.DispalyUpdateStatusChanged(0.0, AppResources.Duplicate_MDC_Conventional_System_Strings);
                      Exception innerException = ex.InnerException;
                      goto label_79;
                    }
                  case 14:
                    goto label_79;
                  case 15:
                    numArray3 = new int[2]{ (int) num14, 0 };
                    num2 = (short) 12;
                    num13 = (int) (IntPtr) num2;
                    continue;
                  case 16 /*0x10*/:
                    if (num14 != (byte) 2)
                    {
                      num2 = (short) 7;
                      num13 = (int) (IntPtr) num2;
                      continue;
                    }
                    num2 = (short) 32155;
                    int num22 = (int) num2;
                    num2 = (short) 32155;
                    int num23 = (int) num2;
                    switch (num22 == num23 ? 1 : 0)
                    {
                      case 0:
                      case 2:
                        goto label_79;
                      default:
                        num2 = (short) 0;
                        if (num2 == (short) 0)
                          ;
                        num2 = (short) 8;
                        num13 = (int) (IntPtr) num2;
                        continue;
                    }
                  default:
label_14:
                    num2 = (short) 9;
                    num13 = (int) (IntPtr) num2;
                    continue;
                }
                ++index1;
                num2 = (short) 17;
                num13 = (int) (IntPtr) num2;
              }
            }
            finally
            {
              short num24 = 2;
              int num25 = (int) (IntPtr) num24;
              while (true)
              {
                switch (num25)
                {
                  case 0:
                    goto label_50;
                  case 1:
                    enumerator.Dispose();
                    num24 = (short) 0;
                    num25 = (int) (IntPtr) num24;
                    continue;
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
                if (enumerator != null)
                {
                  num24 = (short) 1;
                  num25 = (int) (IntPtr) num24;
                }
                else
                  break;
              }
label_50:;
            }
label_79:
            return dictionary;
        }
    }
  }

  internal static Dictionary<string, int> ReadAstroOtarRadioIds(PbaObject pba)
  {
    int num1 = 0;
    switch (num1)
    {
      default:
        Dictionary<string, int> dictionary;
        IshItemCollection ishItemCollection;
        string[] strArray1;
        int index1;
        short num2;
        switch (0)
        {
          case 0:
label_3:
            dictionary = new Dictionary<string, int>();
            ishItemCollection = pba.GetCodeplugInIshItemCollection();
            strArray1 = new string[1];
            index1 = 0;
            num2 = (short) 3;
            num1 = (int) (IntPtr) num2;
            goto default;
          default:
            IEnumerator<KeyValuePair<IshHeader, IshItem>> enumerator;
            IshHeader key;
            while (true)
            {
              switch (num1)
              {
                case 0:
                  goto label_58;
                case 1:
                  try
                  {
                    num2 = (short) 0;
                    int num3 = (int) (IntPtr) num2;
                    while (true)
                    {
                      KeyValuePair<IshHeader, IshItem> current;
                      int length;
                      int num4;
                      int num5;
                      int num6;
                      switch (num3)
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
                          strArray1 = new string[length];
                          num4 = 19;
                          IshItem ishItem1 = current.Value;
                          num5 = (int) ((IshItem) ref ishItem1).Data[1] << 8;
                          int num7 = num5;
                          IshItem ishItem2 = current.Value;
                          int num8 = (int) ((IshItem) ref ishItem2).Data[2];
                          num5 = num7 | num8;
                          num6 = 0;
                          num2 = (short) 5;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 2:
                          num2 = (short) 10;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 3:
                          IshItem ishItem3 = current.Value;
                          int num9 = (int) ((IshItem) ref ishItem3).Data[5];
                          IshItem ishItem4 = current.Value;
                          byte num10 = ((IshItem) ref ishItem4).Data[6];
                          length = num9 << 8;
                          length |= (int) num10;
                          num2 = (short) 6;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 4:
                          if (num6 < length)
                          {
                            string[] strArray2 = strArray1;
                            int index2 = num6;
                            Encoding bigEndianUnicode = Encoding.BigEndianUnicode;
                            IshItem ishItem5 = current.Value;
                            byte[] data = ((IshItem) ref ishItem5).Data;
                            int index3 = num4;
                            int count = num5;
                            string str = bigEndianUnicode.GetString(data, index3, count);
                            strArray2[index2] = str;
                            num4 += num5;
                            ++num6;
                            num2 = (short) 11;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 2;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 5:
                        case 11:
                          num2 = (short) 4;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 6:
                          if (length < (int) byte.MaxValue)
                          {
                            num2 = (short) 1;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          break;
                        case 7:
                          if (enumerator.MoveNext())
                          {
                            current = enumerator.Current;
                            key = current.Key;
                            num2 = (short) 12;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 8;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 8:
                          num2 = (short) 9;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 9:
                        case 10:
                          goto label_57;
                        case 12:
                          if (((IshHeader) ref key).IshType == (ushort) 1084)
                          {
                            num2 = (short) 3;
                            num3 = (int) (IntPtr) num2;
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
                    short num11 = 2;
                    int num12 = (int) (IntPtr) num11;
                    while (true)
                    {
                      switch (num12)
                      {
                        case 0:
                          goto label_56;
                        case 1:
                          enumerator.Dispose();
                          num11 = (short) 0;
                          num12 = (int) (IntPtr) num11;
                          continue;
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
                      if (enumerator != null)
                      {
                        num11 = (short) 1;
                        num12 = (int) (IntPtr) num11;
                      }
                      else
                        break;
                    }
label_56:;
                  }
label_57:
                  enumerator = ishItemCollection.GetEnumerator();
                  num2 = (short) 0;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 2:
                  enumerator = ishItemCollection.GetEnumerator();
                  num2 = (short) 1;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 3:
                  if (ishItemCollection.Count > 0)
                  {
                    num2 = (short) 2;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_59;
                default:
                  goto label_3;
              }
            }
label_58:
            num2 = (short) 0;
            try
            {
              num2 = (short) 7;
              int num13 = (int) (IntPtr) num2;
              while (true)
              {
                int num14;
                KeyValuePair<IshHeader, IshItem> current;
                switch (num13)
                {
                  case 0:
                    num2 = (short) 9114;
                    int num15 = (int) num2;
                    num2 = (short) 9114;
                    int num16 = (int) num2;
                    switch (num15 == num16 ? 1 : 0)
                    {
                      case 0:
                      case 2:
                        goto label_19;
                      default:
                        num2 = (short) 0;
                        if (num2 == (short) 0)
                          ;
                        try
                        {
                          dictionary.Add(strArray1[index1], num14);
                        }
                        catch (Exception ex)
                        {
                          SpecialFeatures.Comms.Comms.DispalyUpdateStatusChanged(0.0, AppResources.Duplicate_Secure_Kmf_Profile_Strings);
                          Exception innerException = ex.InnerException;
                          goto label_59;
                        }
                        ++index1;
                        num2 = (short) 1;
                        if (num2 == (short) 0)
                          ;
                        num2 = (short) 5;
                        num13 = (int) (IntPtr) num2;
                        continue;
                    }
                  case 1:
                    if (!enumerator.MoveNext())
                    {
                      num2 = (short) 2;
                      num13 = (int) (IntPtr) num2;
                      continue;
                    }
                    current = enumerator.Current;
                    key = current.Key;
                    num2 = (short) 3;
                    num13 = (int) (IntPtr) num2;
                    continue;
                  case 2:
                    num2 = (short) 4;
                    num13 = (int) (IntPtr) num2;
                    continue;
                  case 3:
                    if (((IshHeader) ref key).IshType == (ushort) 3859)
                    {
                      num2 = (short) 6;
                      num13 = (int) (IntPtr) num2;
                      continue;
                    }
                    break;
                  case 4:
                    goto label_59;
                  case 6:
label_19:
                    IshItem ishItem = current.Value;
                    int num17 = (int) ((IshItem) ref ishItem).Data[11] << 8;
                    ishItem = current.Value;
                    int num18 = (int) ((IshItem) ref ishItem).Data[12];
                    int num19 = 18;
                    ishItem = current.Value;
                    int num20 = (int) ((IshItem) ref ishItem).Data[17] << 8;
                    ishItem = current.Value;
                    int num21 = (int) ((IshItem) ref ishItem).Data[18];
                    ishItem = current.Value;
                    int num22 = (int) ((IshItem) ref ishItem).Data[num19 + 5] << 16 /*0x10*/;
                    ishItem = current.Value;
                    int num23 = (int) ((IshItem) ref ishItem).Data[num19 + 6] << 8;
                    int num24 = num22 | num23;
                    ishItem = current.Value;
                    int num25 = (int) ((IshItem) ref ishItem).Data[num19 + 7];
                    num14 = num24 | num25;
                    num2 = (short) 0;
                    num13 = (int) (IntPtr) num2;
                    continue;
                  case 7:
                    switch (0)
                    {
                      case 0:
                        break;
                      default:
                        continue;
                    }
                    break;
                }
                num2 = (short) 1;
                num13 = (int) (IntPtr) num2;
              }
            }
            finally
            {
              short num26 = 2;
              int num27 = (int) (IntPtr) num26;
              while (true)
              {
                switch (num27)
                {
                  case 0:
                    goto label_29;
                  case 1:
                    enumerator.Dispose();
                    num26 = (short) 0;
                    num27 = (int) (IntPtr) num26;
                    continue;
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
                if (enumerator != null)
                {
                  num26 = (short) 1;
                  num27 = (int) (IntPtr) num26;
                }
                else
                  break;
              }
label_29:;
            }
label_59:
            return dictionary;
        }
    }
  }

  internal static Dictionary<string, bool> IsRadioKilled(PbaObject pba)
  {
    int A_1 = 4;
    int num1 = 0;
    switch (num1)
    {
      default:
        short num2;
        int index;
        Dictionary<string, bool> dictionary;
        IshItemCollection ishItemCollection;
        switch (0)
        {
          case 0:
label_3:
            index = 19;
            dictionary = new Dictionary<string, bool>();
            ishItemCollection = pba.GetCodeplugInIshItemCollection();
            num2 = (short) 2;
            num1 = (int) (IntPtr) num2;
            goto default;
          default:
            IEnumerator<KeyValuePair<IshHeader, IshItem>> enumerator;
            while (true)
            {
              num2 = (short) 0;
              switch (num1)
              {
                case 0:
                  goto label_6;
                case 1:
                  enumerator = ishItemCollection.GetEnumerator();
                  num2 = (short) 0;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 2:
                  if (ishItemCollection.Count > 0)
                  {
                    num2 = (short) 1;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_32;
                default:
                  goto label_3;
              }
            }
label_6:
            try
            {
              num2 = (short) 9;
              int num3 = (int) (IntPtr) num2;
              while (true)
              {
                KeyValuePair<IshHeader, IshItem> current;
                IshHeader key1;
                string key2;
                IshItem ishItem;
                switch (num3)
                {
                  case 0:
                    if (((IshHeader) ref key1).IshType == (ushort) 1026)
                    {
                      num2 = (short) 4;
                      num3 = (int) (IntPtr) num2;
                      continue;
                    }
                    break;
                  case 2:
                    if (!enumerator.MoveNext())
                    {
                      num2 = (short) 3;
                      num3 = (int) (IntPtr) num2;
                      continue;
                    }
                    current = enumerator.Current;
                    key1 = current.Key;
                    num2 = (short) 0;
                    num3 = (int) (IntPtr) num2;
                    continue;
                  case 3:
                    num2 = (short) 6;
                    num3 = (int) (IntPtr) num2;
                    continue;
                  case 4:
                    ishItem = current.Value;
                    num2 = (short) 7;
                    num3 = (int) (IntPtr) num2;
                    continue;
                  case 5:
                    dictionary.Add(key2, true);
                    num2 = (short) 1;
                    num3 = (int) (IntPtr) num2;
                    continue;
                  case 6:
                    goto label_32;
                  case 7:
                    int num4 = ((int) ((IshItem) ref ishItem).Data[index] & 2) >> 1;
                    key1 = current.Key;
                    key2 = key1.ToString() + RptMgrErrorHandler.b("ꮆꦈ슊\uE38C\uEB8E\uF490\uEB92ꢔꚖꆘ", A_1);
                    if (num4 != 1)
                    {
                      dictionary.Add(key2, false);
                      num2 = (short) 8;
                      num3 = (int) (IntPtr) num2;
                      continue;
                    }
                    num2 = (short) 5;
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
                num2 = (short) 2;
                num3 = (int) (IntPtr) num2;
              }
            }
            finally
            {
              int num5 = 2;
              short num6;
              while (true)
              {
                switch (num5)
                {
                  case 0:
                    goto label_30;
                  case 1:
label_29:
                    enumerator.Dispose();
                    num6 = (short) 0;
                    num5 = (int) (IntPtr) num6;
                    continue;
                  case 2:
                    switch (0)
                    {
                      case 0:
                        goto label_24;
                      default:
                        continue;
                    }
                  default:
label_24:
                    num6 = (short) -30094;
                    int num7 = (int) num6;
                    num6 = (short) -30094;
                    int num8 = (int) num6;
                    switch (num7 == num8 ? 1 : 0)
                    {
                      case 0:
                      case 2:
                        goto label_29;
                      default:
                        num6 = (short) 1;
                        if (num6 == (short) 0)
                          ;
                        num6 = (short) 0;
                        if (num6 == (short) 0)
                          ;
                        if (enumerator != null)
                        {
                          num6 = (short) 1;
                          num5 = (int) (IntPtr) num6;
                          continue;
                        }
                        goto label_30;
                    }
                }
              }
label_30:;
            }
label_32:
            return dictionary;
        }
    }
  }

  internal static Dictionary<string, int> ReadCustomerID(PbaObject pba)
  {
    int A_1 = 18;
    int num1 = 0;
    switch (num1)
    {
      default:
        Dictionary<string, int> dictionary;
        IshItemCollection ishItemCollection;
        short num2;
        switch (0)
        {
          case 0:
label_3:
            dictionary = new Dictionary<string, int>();
            ishItemCollection = pba.GetCodeplugInIshItemCollection();
            num2 = (short) 1;
            num1 = (int) (IntPtr) num2;
            goto default;
          default:
            IEnumerator<KeyValuePair<IshHeader, IshItem>> enumerator;
            while (true)
            {
              switch (num1)
              {
                case 0:
                  goto label_7;
                case 1:
                  if (ishItemCollection.Count > 0)
                  {
                    num2 = (short) 1;
                    if (num2 == (short) 0)
                      ;
                    num2 = (short) 2;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_31;
                case 2:
                  num2 = (short) 0;
                  enumerator = ishItemCollection.GetEnumerator();
                  num2 = (short) 0;
                  num1 = (int) (IntPtr) num2;
                  continue;
                default:
                  goto label_3;
              }
            }
label_7:
            try
            {
              num2 = (short) 6;
              int num3 = (int) (IntPtr) num2;
              while (true)
              {
                KeyValuePair<IshHeader, IshItem> current;
                IshHeader key1;
                IshItem ishItem;
                switch (num3)
                {
                  case 0:
                    goto label_31;
                  case 1:
                    if (!enumerator.MoveNext())
                    {
                      num2 = (short) 7;
                      num3 = (int) (IntPtr) num2;
                      continue;
                    }
                    current = enumerator.Current;
                    key1 = current.Key;
                    num2 = (short) 5;
                    num3 = (int) (IntPtr) num2;
                    continue;
                  case 2:
                    ishItem = current.Value;
                    int num4 = (int) ((IshItem) ref ishItem).Data[14];
                    ishItem = current.Value;
                    byte num5 = ((IshItem) ref ishItem).Data[15];
                    int num6 = num4 << 8 | (int) num5;
                    key1 = current.Key;
                    string key2 = key1.ToString() + RptMgrErrorHandler.b("릔랖킘\uF59A列爵\uD9A0麢钤钦", A_1);
                    dictionary.Add(key2, num6);
                    num2 = (short) 3;
                    num3 = (int) (IntPtr) num2;
                    continue;
                  case 4:
                    if (((IshItem) ref ishItem).Data != null)
                    {
                      num2 = (short) 2;
                      num3 = (int) (IntPtr) num2;
                      continue;
                    }
                    break;
                  case 5:
                    if (((IshHeader) ref key1).IshType == (ushort) 1030)
                    {
                      num2 = (short) 8;
                      num3 = (int) (IntPtr) num2;
                      continue;
                    }
                    break;
                  case 6:
                    switch (0)
                    {
                      case 0:
                        break;
                      default:
                        continue;
                    }
                    break;
                  case 7:
                    num2 = (short) 0;
                    num3 = (int) (IntPtr) num2;
                    continue;
                  case 8:
                    ishItem = current.Value;
                    num2 = (short) 4;
                    num3 = (int) (IntPtr) num2;
                    continue;
                }
                num2 = (short) 1;
                num3 = (int) (IntPtr) num2;
              }
            }
            finally
            {
              short num7 = 1;
              int num8 = (int) (IntPtr) num7;
              while (true)
              {
                switch (num8)
                {
                  case 0:
                    num7 = (short) -5925;
                    int num9 = (int) num7;
                    num7 = (short) -5925;
                    int num10 = (int) num7;
                    switch (num9 == num10 ? 1 : 0)
                    {
                      case 0:
                      case 2:
                        goto label_26;
                      default:
                        goto label_28;
                    }
                  case 1:
                    switch (0)
                    {
                      case 0:
                        break;
                      default:
                        continue;
                    }
                    break;
                  case 2:
label_26:
                    enumerator.Dispose();
                    num7 = (short) 0;
                    num8 = (int) (IntPtr) num7;
                    continue;
                }
                if (enumerator != null)
                {
                  num7 = (short) 2;
                  num8 = (int) (IntPtr) num7;
                }
                else
                  goto label_29;
              }
label_28:
              num7 = (short) 0;
              if (num7 == (short) 0)
                ;
label_29:;
            }
label_31:
            return dictionary;
        }
    }
  }

  internal static Dictionary<string, bool> IsRadioInhibitedTrunking(PbaObject pba)
  {
    int A_1 = 17;
    int num1 = 0;
    switch (num1)
    {
      default:
        int index;
        Dictionary<string, bool> dictionary;
        IshItemCollection ishItemCollection;
        short num2;
        switch (0)
        {
          case 0:
label_3:
            index = 21;
            dictionary = new Dictionary<string, bool>();
            ishItemCollection = pba.GetCodeplugInIshItemCollection();
            num2 = (short) 1;
            num1 = (int) (IntPtr) num2;
            goto default;
          default:
            IEnumerator<KeyValuePair<IshHeader, IshItem>> enumerator;
            while (true)
            {
              switch (num1)
              {
                case 0:
                  goto label_7;
                case 1:
                  if (ishItemCollection.Count > 0)
                  {
                    num2 = (short) 2;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_32;
                case 2:
                  num2 = (short) 1;
                  if (num2 == (short) 0)
                    ;
                  num2 = (short) 0;
                  enumerator = ishItemCollection.GetEnumerator();
                  num2 = (short) 0;
                  num1 = (int) (IntPtr) num2;
                  continue;
                default:
                  goto label_3;
              }
            }
label_7:
            try
            {
              num2 = (short) 7;
              int num3 = (int) (IntPtr) num2;
              while (true)
              {
                KeyValuePair<IshHeader, IshItem> current;
                IshHeader key1;
                string key2;
                IshItem ishItem;
                switch (num3)
                {
                  case 0:
                    dictionary.Add(key2, true);
                    num2 = (short) 3;
                    num3 = (int) (IntPtr) num2;
                    continue;
                  case 2:
                    if (!enumerator.MoveNext())
                    {
                      num2 = (short) 8;
                      num3 = (int) (IntPtr) num2;
                      continue;
                    }
                    current = enumerator.Current;
                    key1 = current.Key;
                    num2 = (short) 6;
                    num3 = (int) (IntPtr) num2;
                    continue;
                  case 4:
                    goto label_32;
                  case 5:
                    int num4 = ((int) ((IshItem) ref ishItem).Data[index] & 16 /*0x10*/) >> 4;
                    key1 = current.Key;
                    key2 = key1.ToString() + RptMgrErrorHandler.b("뢓뚕톗\uF499\uF89Bﮝ\uD89F龡隣隥", A_1);
                    if (num4 == 0)
                    {
                      dictionary.Add(key2, false);
                      num2 = (short) 1;
                      num3 = (int) (IntPtr) num2;
                      continue;
                    }
                    num2 = (short) 0;
                    num3 = (int) (IntPtr) num2;
                    continue;
                  case 6:
                    if (((IshHeader) ref key1).IshType == (ushort) 1026)
                    {
                      num2 = (short) 9;
                      num3 = (int) (IntPtr) num2;
                      continue;
                    }
                    break;
                  case 7:
                    switch (0)
                    {
                      case 0:
                        break;
                      default:
                        continue;
                    }
                    break;
                  case 8:
                    num2 = (short) 4;
                    num3 = (int) (IntPtr) num2;
                    continue;
                  case 9:
                    ishItem = current.Value;
                    num2 = (short) 5;
                    num3 = (int) (IntPtr) num2;
                    continue;
                }
                num2 = (short) 2;
                num3 = (int) (IntPtr) num2;
              }
            }
            finally
            {
              short num5 = 1;
              int num6 = (int) (IntPtr) num5;
              while (true)
              {
                switch (num6)
                {
                  case 0:
                    num5 = (short) -1974;
                    int num7 = (int) num5;
                    num5 = (short) -1974;
                    int num8 = (int) num5;
                    switch (num7 == num8 ? 1 : 0)
                    {
                      case 0:
                      case 2:
                        goto label_27;
                      default:
                        goto label_29;
                    }
                  case 1:
                    switch (0)
                    {
                      case 0:
                        break;
                      default:
                        continue;
                    }
                    break;
                  case 2:
label_27:
                    enumerator.Dispose();
                    num5 = (short) 0;
                    num6 = (int) (IntPtr) num5;
                    continue;
                }
                if (enumerator != null)
                {
                  num5 = (short) 2;
                  num6 = (int) (IntPtr) num5;
                }
                else
                  goto label_30;
              }
label_29:
              num5 = (short) 0;
              if (num5 == (short) 0)
                ;
label_30:;
            }
label_32:
            return dictionary;
        }
    }
  }

  internal static DataProfIP[] ReadDataProfIPaddr(PbaObject pba)
  {
    int A_1 = 14;
    int num1 = 0;
    switch (num1)
    {
      default:
        short num2;
        IshItemCollection ishItemCollection;
        int length1;
        IEnumerator<KeyValuePair<IshHeader, IshItem>> enumerator;
        string[] strArray1;
        IshHeader key;
        int num3;
        ulong newAddress;
        DataProfIP[] dataProfIpArray;
        int index1;
        switch (0)
        {
          case 0:
label_3:
            num2 = (short) 19767;
            int num4 = (int) num2;
            num2 = (short) 19767;
            int num5 = (int) num2;
            switch (num4 == num5 ? 1 : 0)
            {
              case 0:
              case 2:
                break;
              default:
                num2 = (short) 0;
                if (num2 == (short) 0)
                  ;
                num2 = (short) 1;
                if (num2 == (short) 0)
                  ;
                ishItemCollection = pba.GetCodeplugInIshItemCollection();
                length1 = 0;
                num2 = (short) 4;
                num1 = (int) (IntPtr) num2;
                goto label_2;
            }
            break;
          default:
            IshItem ishItem1;
            while (true)
            {
              switch (num1)
              {
                case 0:
                  try
                  {
                    num2 = (short) 10;
                    int num6 = (int) (IntPtr) num2;
                    while (true)
                    {
                      int length2;
                      int num7;
                      KeyValuePair<IshHeader, IshItem> current;
                      int num8;
                      int num9;
                      switch (num6)
                      {
                        case 0:
                          if (num9 < length2)
                          {
                            string[] strArray2 = strArray1;
                            int index2 = num9;
                            Encoding bigEndianUnicode = Encoding.BigEndianUnicode;
                            ishItem1 = current.Value;
                            byte[] data = ((IshItem) ref ishItem1).Data;
                            int index3 = num7;
                            int count = num8;
                            string str = bigEndianUnicode.GetString(data, index3, count);
                            strArray2[index2] = str;
                            num7 += num8;
                            ++num9;
                            num2 = (short) 4;
                            num6 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 1;
                          num6 = (int) (IntPtr) num2;
                          continue;
                        case 1:
                          num2 = (short) 5;
                          num6 = (int) (IntPtr) num2;
                          continue;
                        case 2:
                          if (((IshHeader) ref key).IshType == (ushort) 1073)
                          {
                            num2 = (short) 12;
                            num6 = (int) (IntPtr) num2;
                            continue;
                          }
                          break;
                        case 3:
                          num2 = (short) 9;
                          num6 = (int) (IntPtr) num2;
                          continue;
                        case 4:
                        case 11:
                          num2 = (short) 0;
                          num6 = (int) (IntPtr) num2;
                          continue;
                        case 5:
                        case 9:
                          goto label_9;
                        case 6:
                          if (length2 < (int) byte.MaxValue)
                          {
                            num2 = (short) 7;
                            num6 = (int) (IntPtr) num2;
                            continue;
                          }
                          break;
                        case 7:
                          strArray1 = new string[length2];
                          num7 = 19;
                          ishItem1 = current.Value;
                          num8 = (int) ((IshItem) ref ishItem1).Data[1] << 8;
                          int num10 = num8;
                          ishItem1 = current.Value;
                          int num11 = (int) ((IshItem) ref ishItem1).Data[2];
                          num8 = num10 | num11;
                          num9 = 0;
                          num2 = (short) 11;
                          num6 = (int) (IntPtr) num2;
                          continue;
                        case 8:
                          if (!enumerator.MoveNext())
                          {
                            num2 = (short) 3;
                            num6 = (int) (IntPtr) num2;
                            continue;
                          }
                          current = enumerator.Current;
                          key = current.Key;
                          num2 = (short) 2;
                          num6 = (int) (IntPtr) num2;
                          continue;
                        case 10:
                          switch (0)
                          {
                            case 0:
                              break;
                            default:
                              continue;
                          }
                          break;
                        case 12:
                          ishItem1 = current.Value;
                          int num12 = (int) ((IshItem) ref ishItem1).Data[5];
                          ishItem1 = current.Value;
                          byte num13 = ((IshItem) ref ishItem1).Data[6];
                          length2 = num12 << 8;
                          length2 |= (int) num13;
                          num2 = (short) 6;
                          num6 = (int) (IntPtr) num2;
                          continue;
                      }
                      num2 = (short) 8;
                      num6 = (int) (IntPtr) num2;
                    }
                  }
                  finally
                  {
                    short num14 = 1;
                    int num15 = (int) (IntPtr) num14;
                    while (true)
                    {
                      switch (num15)
                      {
                        case 0:
                          goto label_35;
                        case 1:
                          switch (0)
                          {
                            case 0:
                              break;
                            default:
                              continue;
                          }
                          break;
                        case 2:
                          enumerator.Dispose();
                          num14 = (short) 0;
                          num15 = (int) (IntPtr) num14;
                          continue;
                      }
                      if (enumerator != null)
                      {
                        num14 = (short) 2;
                        num15 = (int) (IntPtr) num14;
                      }
                      else
                        break;
                    }
label_35:;
                  }
label_9:
                  enumerator = ishItemCollection.GetEnumerator();
                  num2 = (short) 3;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 1:
                  enumerator = ishItemCollection.GetEnumerator();
                  num2 = (short) 0;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 2:
                  if (ishItemCollection.Count > 0)
                  {
                    num2 = (short) 1;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_137;
                case 3:
                  goto label_57;
                case 4:
                  if (ishItemCollection.Count > 0)
                  {
                    num2 = (short) 5;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_133;
                case 5:
                  enumerator = ishItemCollection.GetEnumerator();
                  num2 = (short) 6;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 6:
                  goto label_36;
                default:
                  goto label_3;
              }
label_2:;
            }
label_57:
            try
            {
              num2 = (short) 38;
              int num16 = (int) (IntPtr) num2;
              while (true)
              {
                KeyValuePair<IshHeader, IshItem> current;
                switch (num16)
                {
                  case 0:
                  case 18:
                  case 23:
                  case 41:
                    num2 = (short) 37;
                    num16 = (int) (IntPtr) num2;
                    continue;
                  case 1:
                  case 13:
                  case 36:
                  case 39:
                  case 45:
                    num2 = (short) 5;
                    num16 = (int) (IntPtr) num2;
                    continue;
                  case 2:
                    if (num3 != 2)
                    {
                      num2 = (short) 10;
                      num16 = (int) (IntPtr) num2;
                      continue;
                    }
                    num2 = (short) 33;
                    num16 = (int) (IntPtr) num2;
                    continue;
                  case 3:
                    IPAddress ipAddress1 = new IPAddress((long) newAddress);
                    dataProfIpArray[length1 - 1].SubIP = ipAddress1;
                    num3 = 20;
                    newAddress = 0UL;
                    dataProfIpArray[length1 - 1].DataProfName = RptMgrErrorHandler.b("햐\uF292\uE194\uF696캘\uF29A列爵", A_1);
                    num2 = (short) 41;
                    num16 = (int) (IntPtr) num2;
                    continue;
                  case 5:
                    if (num3 >= 206)
                    {
                      num2 = (short) 44;
                      num16 = (int) (IntPtr) num2;
                      continue;
                    }
                    goto case 11;
                  case 6:
                    goto label_137;
                  case 7:
                    if (((IshItem) ref ishItem1).Data.Length <= 189)
                    {
                      num3 = 206;
                      num2 = (short) 14;
                      num16 = (int) (IntPtr) num2;
                      continue;
                    }
                    num2 = (short) 25;
                    num16 = (int) (IntPtr) num2;
                    continue;
                  case 8:
                    if (num3 == 135)
                    {
                      num2 = (short) 29;
                      num16 = (int) (IntPtr) num2;
                      continue;
                    }
                    num2 = (short) 34;
                    num16 = (int) (IntPtr) num2;
                    continue;
                  case 9:
                    num2 = (short) 6;
                    num16 = (int) (IntPtr) num2;
                    continue;
                  case 10:
                    if (num3 != 18)
                    {
                      num2 = (short) 8;
                      num16 = (int) (IntPtr) num2;
                      continue;
                    }
                    num2 = (short) 19;
                    num16 = (int) (IntPtr) num2;
                    continue;
                  case 11:
                    IshItem ishItem2 = current.Value;
                    byte num17 = ((IshItem) ref ishItem2).Data[num3 + 12];
                    IshItem ishItem3 = current.Value;
                    byte num18 = ((IshItem) ref ishItem3).Data[num3 + 13];
                    IshItem ishItem4 = current.Value;
                    byte num19 = ((IshItem) ref ishItem4).Data[num3 + 14];
                    ishItem1 = current.Value;
                    byte num20 = ((IshItem) ref ishItem1).Data[num3 + 15];
                    newAddress = newAddress | (ulong) num20 << 24 | (ulong) num19 << 16 /*0x10*/ | (ulong) num18 << 8 | (ulong) num17;
                    num2 = (short) 2;
                    num16 = (int) (IntPtr) num2;
                    continue;
                  case 12:
                    IPAddress ipAddress2 = new IPAddress((long) newAddress);
                    dataProfIpArray[length1 - 1].BTPeerIP = ipAddress2;
                    num3 = 108;
                    newAddress = 0UL;
                    num2 = (short) 0;
                    num16 = (int) (IntPtr) num2;
                    continue;
                  case 14:
                  case 40:
                    newAddress = 0UL;
                    num2 = (short) 13;
                    num16 = (int) (IntPtr) num2;
                    continue;
                  case 15:
                  case 24:
                    newAddress = 0UL;
                    num2 = (short) 23;
                    num16 = (int) (IntPtr) num2;
                    continue;
                  case 16 /*0x10*/:
                    if (num3 == 205)
                    {
                      num2 = (short) 22;
                      num16 = (int) (IntPtr) num2;
                      continue;
                    }
                    goto case 1;
                  case 17:
                    if (num3 != 20)
                    {
                      num2 = (short) 27;
                      num16 = (int) (IntPtr) num2;
                      continue;
                    }
                    num2 = (short) 26;
                    num16 = (int) (IntPtr) num2;
                    continue;
                  case 19:
                    IPAddress ipAddress3 = new IPAddress((long) newAddress);
                    dataProfIpArray[index1].PeerIP = ipAddress3;
                    num3 = 135;
                    newAddress = 0UL;
                    num2 = (short) 1;
                    num16 = (int) (IntPtr) num2;
                    continue;
                  case 20:
                    if (((IshItem) ref ishItem1).Data.Length <= 91)
                    {
                      num3 = 108;
                      num2 = (short) 24;
                      num16 = (int) (IntPtr) num2;
                      continue;
                    }
                    num2 = (short) 48 /*0x30*/;
                    num16 = (int) (IntPtr) num2;
                    continue;
                  case 22:
                    IPAddress ipAddress4 = new IPAddress((long) newAddress);
                    dataProfIpArray[index1].BTPeerIP = ipAddress4;
                    num3 = 206;
                    newAddress = 0UL;
                    num2 = (short) 39;
                    num16 = (int) (IntPtr) num2;
                    continue;
                  case 25:
                    num3 = 189;
                    num2 = (short) 40;
                    num16 = (int) (IntPtr) num2;
                    continue;
                  case 26:
                    IPAddress ipAddress5 = new IPAddress((long) newAddress);
                    dataProfIpArray[length1 - 1].PeerIP = ipAddress5;
                    ishItem1 = current.Value;
                    num2 = (short) 20;
                    num16 = (int) (IntPtr) num2;
                    continue;
                  case 27:
                    if (num3 == 91)
                    {
                      num2 = (short) 42;
                      num16 = (int) (IntPtr) num2;
                      continue;
                    }
                    num2 = (short) 46;
                    num16 = (int) (IntPtr) num2;
                    continue;
                  case 28:
                    if (((IshHeader) ref key).IshType == (ushort) 3923)
                    {
                      num2 = (short) 31 /*0x1F*/;
                      num16 = (int) (IntPtr) num2;
                      continue;
                    }
                    key = current.Key;
                    num2 = (short) 30;
                    num16 = (int) (IntPtr) num2;
                    continue;
                  case 29:
                    IPAddress ipAddress6 = new IPAddress((long) newAddress);
                    dataProfIpArray[index1].SubIP = ipAddress6;
                    ishItem1 = current.Value;
                    num2 = (short) 7;
                    num16 = (int) (IntPtr) num2;
                    continue;
                  case 30:
                    if (((IshHeader) ref key).IshType == (ushort) 1027)
                    {
                      num2 = (short) 49;
                      num16 = (int) (IntPtr) num2;
                      continue;
                    }
                    break;
                  case 31 /*0x1F*/:
                    num3 = 2;
                    num2 = (short) 11;
                    num16 = (int) (IntPtr) num2;
                    continue;
                  case 32 /*0x20*/:
                    IshItem ishItem5 = current.Value;
                    byte num21 = ((IshItem) ref ishItem5).Data[num3 + 12];
                    IshItem ishItem6 = current.Value;
                    byte num22 = ((IshItem) ref ishItem6).Data[num3 + 13];
                    IshItem ishItem7 = current.Value;
                    byte num23 = ((IshItem) ref ishItem7).Data[num3 + 14];
                    ishItem1 = current.Value;
                    byte num24 = ((IshItem) ref ishItem1).Data[num3 + 15];
                    newAddress = newAddress | (ulong) num24 << 24 | (ulong) num23 << 16 /*0x10*/ | (ulong) num22 << 8 | (ulong) num21;
                    num2 = (short) 43;
                    num16 = (int) (IntPtr) num2;
                    continue;
                  case 33:
                    IPAddress ipAddress7 = new IPAddress((long) newAddress);
                    dataProfIpArray[index1].SubAirInterfaceIP = ipAddress7;
                    num3 = 18;
                    newAddress = 0UL;
                    dataProfIpArray[index1].DataProfName = strArray1[index1];
                    num2 = (short) 45;
                    num16 = (int) (IntPtr) num2;
                    continue;
                  case 34:
                    if (num3 != 189)
                    {
                      num2 = (short) 16 /*0x10*/;
                      num16 = (int) (IntPtr) num2;
                      continue;
                    }
                    num2 = (short) 47;
                    num16 = (int) (IntPtr) num2;
                    continue;
                  case 35:
                    if (enumerator.MoveNext())
                    {
                      current = enumerator.Current;
                      key = current.Key;
                      num2 = (short) 28;
                      num16 = (int) (IntPtr) num2;
                      continue;
                    }
                    num2 = (short) 9;
                    num16 = (int) (IntPtr) num2;
                    continue;
                  case 37:
                    if (num3 >= 108)
                    {
                      num2 = (short) 21;
                      num16 = (int) (IntPtr) num2;
                      continue;
                    }
                    goto case 32 /*0x20*/;
                  case 38:
                    switch (0)
                    {
                      case 0:
                        break;
                      default:
                        continue;
                    }
                    break;
                  case 42:
                    IPAddress ipAddress8 = new IPAddress((long) newAddress);
                    dataProfIpArray[length1 - 1].BTSubIP = ipAddress8;
                    num3 = 107;
                    newAddress = 0UL;
                    num2 = (short) 18;
                    num16 = (int) (IntPtr) num2;
                    continue;
                  case 43:
                    if (num3 != 4)
                    {
                      num2 = (short) 17;
                      num16 = (int) (IntPtr) num2;
                      continue;
                    }
                    num2 = (short) 3;
                    num16 = (int) (IntPtr) num2;
                    continue;
                  case 44:
                    ++index1;
                    num2 = (short) 4;
                    num16 = (int) (IntPtr) num2;
                    continue;
                  case 46:
                    if (num3 == 107)
                    {
                      num2 = (short) 12;
                      num16 = (int) (IntPtr) num2;
                      continue;
                    }
                    goto case 0;
                  case 47:
                    IPAddress ipAddress9 = new IPAddress((long) newAddress);
                    dataProfIpArray[index1].BTSubIP = ipAddress9;
                    num3 = 205;
                    newAddress = 0UL;
                    num2 = (short) 36;
                    num16 = (int) (IntPtr) num2;
                    continue;
                  case 48 /*0x30*/:
                    num3 = 91;
                    num2 = (short) 15;
                    num16 = (int) (IntPtr) num2;
                    continue;
                  case 49:
                    num3 = 4;
                    num2 = (short) 32 /*0x20*/;
                    num16 = (int) (IntPtr) num2;
                    continue;
                }
                num2 = (short) 35;
                num16 = (int) (IntPtr) num2;
              }
            }
            finally
            {
              int num25 = 2;
              while (true)
              {
                short num26;
                switch (num25)
                {
                  case 0:
                    goto label_131;
                  case 1:
                    enumerator.Dispose();
                    num26 = (short) 0;
                    num25 = (int) (IntPtr) num26;
                    continue;
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
                if (enumerator != null)
                {
                  num26 = (short) 1;
                  num25 = (int) (IntPtr) num26;
                }
                else
                  break;
              }
label_131:;
            }
label_137:
            num2 = (short) 0;
            return dataProfIpArray;
        }
label_36:
        try
        {
          num2 = (short) 6;
          int num27 = (int) (IntPtr) num2;
          while (true)
          {
            KeyValuePair<IshHeader, IshItem> current;
            switch (num27)
            {
              case 0:
                goto label_133;
              case 1:
                if (!enumerator.MoveNext())
                {
                  num2 = (short) 7;
                  num27 = (int) (IntPtr) num2;
                  continue;
                }
                current = enumerator.Current;
                key = current.Key;
                num2 = (short) 3;
                num27 = (int) (IntPtr) num2;
                continue;
              case 3:
                if (((IshHeader) ref key).IshType != (ushort) 3923)
                {
                  num2 = (short) 4;
                  num27 = (int) (IntPtr) num2;
                  continue;
                }
                goto case 8;
              case 4:
                key = current.Key;
                num2 = (short) 5;
                num27 = (int) (IntPtr) num2;
                continue;
              case 5:
                if (((IshHeader) ref key).IshType == (ushort) 1027)
                {
                  num2 = (short) 8;
                  num27 = (int) (IntPtr) num2;
                  continue;
                }
                break;
              case 6:
                switch (0)
                {
                  case 0:
                    break;
                  default:
                    continue;
                }
                break;
              case 7:
                num2 = (short) 0;
                num27 = (int) (IntPtr) num2;
                continue;
              case 8:
                ++length1;
                num2 = (short) 2;
                num27 = (int) (IntPtr) num2;
                continue;
            }
            num2 = (short) 1;
            num27 = (int) (IntPtr) num2;
          }
        }
        finally
        {
          int num28 = 1;
          while (true)
          {
            switch (num28)
            {
              case 0:
                goto label_56;
              case 1:
                switch (0)
                {
                  case 0:
                    break;
                  default:
                    continue;
                }
                break;
              case 2:
                enumerator.Dispose();
                num28 = 0;
                continue;
            }
            if (enumerator != null)
              num28 = 2;
            else
              break;
          }
label_56:;
        }
label_133:
        dataProfIpArray = new DataProfIP[length1];
        index1 = 0;
        num3 = 2;
        strArray1 = new string[1];
        newAddress = 0UL;
        num2 = (short) 2;
        num1 = (int) (IntPtr) num2;
        goto label_2;
    }
  }

  internal static string[] ReadSoftId(PbaObject pba)
  {
    short num1 = 0;
    num1 = (short) 0;
    switch (num1)
    {
      default:
        num1 = (short) 1;
        if (num1 == (short) 0)
          ;
        IshItemCollection ishItemCollection = pba.GetCodeplugInIshItemCollection();
        string[] strArray1 = new string[4];
        IEnumerator<KeyValuePair<IshHeader, IshItem>> enumerator = ishItemCollection.GetEnumerator();
        try
        {
          num1 = (short) 6;
          int num2 = (int) (IntPtr) num1;
          while (true)
          {
            KeyValuePair<IshHeader, IshItem> current;
            IshItem ishItem;
            IshHeader key;
            int num3;
            int num4;
            switch (num2)
            {
              case 0:
                if (((IshHeader) ref key).IshType == (ushort) 1093)
                {
                  num1 = (short) 2;
                  num2 = (int) (IntPtr) num1;
                  continue;
                }
                key = current.Key;
                num1 = (short) 10;
                num2 = (int) (IntPtr) num1;
                continue;
              case 2:
                int num5 = 2;
                ishItem = current.Value;
                int num6 = (int) ((IshItem) ref ishItem).Data[1];
                string[] strArray2 = strArray1;
                Encoding ascii = Encoding.ASCII;
                ishItem = current.Value;
                byte[] data1 = ((IshItem) ref ishItem).Data;
                int index1 = num5;
                int count1 = num6;
                string str1 = ascii.GetString(data1, index1, count1);
                strArray2[0] = str1;
                num1 = (short) 11;
                num2 = (int) (IntPtr) num1;
                continue;
              case 4:
                if (enumerator.MoveNext())
                {
                  current = enumerator.Current;
                  key = current.Key;
                  num1 = (short) 0;
                  num2 = (int) (IntPtr) num1;
                  continue;
                }
                num1 = (short) 5;
                num2 = (int) (IntPtr) num1;
                continue;
              case 5:
                num1 = (short) 12;
                num2 = (int) (IntPtr) num1;
                continue;
              case 6:
                switch (0)
                {
                  case 0:
                    break;
                  default:
                    continue;
                }
                break;
              case 7:
                string[] strArray3 = strArray1;
                Encoding bigEndianUnicode1 = Encoding.BigEndianUnicode;
                ishItem = current.Value;
                byte[] data2 = ((IshItem) ref ishItem).Data;
                int index2 = num3;
                int count2 = num4;
                string str2 = bigEndianUnicode1.GetString(data2, index2, count2);
                strArray3[2] = str2;
                num1 = (short) 1;
                num2 = (int) (IntPtr) num1;
                continue;
              case 8:
                int num7 = 3;
                ishItem = current.Value;
                int num8 = (int) ((IshItem) ref ishItem).Data[2] * 2;
                string[] strArray4 = strArray1;
                Encoding bigEndianUnicode2 = Encoding.BigEndianUnicode;
                ishItem = current.Value;
                byte[] data3 = ((IshItem) ref ishItem).Data;
                int index3 = num7;
                int count3 = num8;
                string str3 = bigEndianUnicode2.GetString(data3, index3, count3);
                strArray4[3] = str3;
                num1 = (short) 3;
                num2 = (int) (IntPtr) num1;
                continue;
              case 9:
                int num9 = 103;
                int num10 = 32 /*0x20*/;
                string[] strArray5 = strArray1;
                Encoding bigEndianUnicode3 = Encoding.BigEndianUnicode;
                ishItem = current.Value;
                byte[] data4 = ((IshItem) ref ishItem).Data;
                int index4 = num9;
                int count4 = num10;
                string str4 = bigEndianUnicode3.GetString(data4, index4, count4);
                strArray5[1] = str4;
                num3 = 155;
                num4 = 32 /*0x20*/;
                ishItem = current.Value;
                num1 = (short) 14;
                num2 = (int) (IntPtr) num1;
                continue;
              case 10:
                if (((IshHeader) ref key).IshType != (ushort) 1028)
                {
                  key = current.Key;
                  num1 = (short) 13;
                  num2 = (int) (IntPtr) num1;
                  continue;
                }
                num1 = (short) 9;
                num2 = (int) (IntPtr) num1;
                continue;
              case 12:
                goto label_34;
              case 13:
                if (((IshHeader) ref key).IshType == (ushort) 1146)
                {
                  num1 = (short) 8;
                  num2 = (int) (IntPtr) num1;
                  continue;
                }
                break;
              case 14:
                if (((IshItem) ref ishItem).Data.Length > num3 + num4)
                {
                  num1 = (short) 7;
                  num2 = (int) (IntPtr) num1;
                  continue;
                }
                break;
            }
            num1 = (short) 4;
            num2 = (int) (IntPtr) num1;
          }
        }
        finally
        {
          int num11 = 1;
          short num12;
          while (true)
          {
            switch (num11)
            {
              case 0:
                goto label_31;
              case 1:
                switch (0)
                {
                  case 0:
                    break;
                  default:
                    continue;
                }
                break;
              case 2:
                enumerator.Dispose();
                num12 = (short) 0;
                num11 = (int) (IntPtr) num12;
                continue;
            }
            if (enumerator != null)
            {
              num12 = (short) 2;
              num11 = (int) (IntPtr) num12;
              continue;
            }
            break;
label_27:;
          }
label_31:
          num12 = (short) -2888;
          int num13 = (int) num12;
          num12 = (short) -2888;
          int num14 = (int) num12;
          switch (num13 == num14 ? 1 : 0)
          {
            case 0:
            case 2:
              goto label_27;
            default:
              num12 = (short) 0;
              if (num12 == (short) 0)
                ;
          }
        }
label_34:
        return strArray1;
    }
  }

  internal static string ReadBluetoothFriendlyName(PbaObject pba)
  {
    switch (0)
    {
      default:
        IshItemCollection ishItemCollection = pba.GetCodeplugInIshItemCollection();
        string str = (string) null;
        IEnumerator<KeyValuePair<IshHeader, IshItem>> enumerator = ishItemCollection.GetEnumerator();
        short num1;
        try
        {
          num1 = (short) 6;
          int num2 = (int) (IntPtr) num1;
          while (true)
          {
            KeyValuePair<IshHeader, IshItem> current;
            IshHeader key;
            IshItem ishItem;
            switch (num2)
            {
              case 0:
                goto label_29;
              case 1:
                ishItem = current.Value;
                num1 = (short) 3;
                num2 = (int) (IntPtr) num1;
                continue;
              case 2:
                num1 = (short) 0;
                num2 = (int) (IntPtr) num1;
                continue;
              case 3:
                if (((IshItem) ref ishItem).Data.Length > 7)
                {
                  num1 = (short) 4;
                  num2 = (int) (IntPtr) num1;
                  continue;
                }
                break;
              case 4:
                int num3 = 6;
                int num4 = 28;
                UnicodeEncoding unicodeEncoding = new UnicodeEncoding(true, true, true);
                ishItem = current.Value;
                byte[] data = ((IshItem) ref ishItem).Data;
                int index = num3;
                int count = num4;
                str = unicodeEncoding.GetString(data, index, count);
                num1 = (short) 10;
                num2 = (int) (IntPtr) num1;
                continue;
              case 5:
                if (((IshItem) ref ishItem).Data != null)
                {
                  num1 = (short) 8;
                  num2 = (int) (IntPtr) num1;
                  continue;
                }
                break;
              case 6:
                switch (0)
                {
                  case 0:
                    break;
                  default:
                    continue;
                }
                break;
              case 7:
                if (((IshHeader) ref key).IshType == (ushort) 1137)
                {
                  num1 = (short) 1;
                  num2 = (int) (IntPtr) num1;
                  continue;
                }
                break;
              case 8:
                key = current.Key;
                num1 = (short) 7;
                num2 = (int) (IntPtr) num1;
                continue;
              case 9:
                if (!enumerator.MoveNext())
                {
                  num1 = (short) 2;
                  num2 = (int) (IntPtr) num1;
                  continue;
                }
                current = enumerator.Current;
                ishItem = current.Value;
                num1 = (short) 5;
                num2 = (int) (IntPtr) num1;
                continue;
            }
            num1 = (short) 9;
            num2 = (int) (IntPtr) num1;
          }
        }
        finally
        {
          short num5 = 1;
          if (num5 == (short) 0)
            ;
          num5 = (short) 1;
          int num6 = (int) (IntPtr) num5;
          while (true)
          {
            switch (num6)
            {
              case 0:
                goto label_26;
              case 1:
                switch (0)
                {
                  case 0:
                    break;
                  default:
                    continue;
                }
                break;
              case 2:
                enumerator.Dispose();
                num5 = (short) 0;
                num6 = (int) (IntPtr) num5;
                continue;
            }
            if (enumerator != null)
            {
              num5 = (short) 2;
              num6 = (int) (IntPtr) num5;
              continue;
            }
            break;
label_22:;
          }
label_26:
          num5 = (short) -23266;
          int num7 = (int) num5;
          num5 = (short) -23266;
          int num8 = (int) num5;
          switch (num7 == num8 ? 1 : 0)
          {
            case 0:
            case 2:
              goto label_22;
            default:
              num5 = (short) 0;
              if (num5 == (short) 0)
                ;
          }
        }
label_29:
        num1 = (short) 0;
        return str;
    }
  }

  public static bool ReadEncryptPasswordFlag(PbaObject pba)
  {
    int num1 = 0;
    switch (num1)
    {
      default:
        if (false)
          ;
        IshItemCollection ishItemCollection;
        bool flag;
        short num2;
        switch (0)
        {
          case 0:
label_4:
            ishItemCollection = pba.GetCodeplugInIshItemCollection();
            flag = false;
            num2 = (short) 1;
            num1 = (int) (IntPtr) num2;
            goto default;
          default:
            IEnumerator<KeyValuePair<IshHeader, IshItem>> enumerator;
            while (true)
            {
              switch (num1)
              {
                case 0:
                  goto label_7;
                case 1:
                  if (ishItemCollection.Count > 0)
                  {
                    num2 = (short) 2;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_32;
                case 2:
                  enumerator = ishItemCollection.GetEnumerator();
                  num2 = (short) 0;
                  num1 = (int) (IntPtr) num2;
                  continue;
                default:
                  goto label_4;
              }
            }
label_7:
            try
            {
              num2 = (short) 5;
              int num3 = (int) (IntPtr) num2;
              while (true)
              {
                KeyValuePair<IshHeader, IshItem> current;
                IshHeader key;
                int index;
                IshItem ishItem;
                switch (num3)
                {
                  case 0:
                  case 7:
                  case 9:
                    goto label_32;
                  case 1:
                    num2 = (short) 0;
                    num3 = (int) (IntPtr) num2;
                    continue;
                  case 2:
                    if (((int) ((IshItem) ref ishItem).Data[index] & 1) == 0)
                    {
                      flag = false;
                      num2 = (short) 7;
                      num3 = (int) (IntPtr) num2;
                      continue;
                    }
                    num2 = (short) 3;
                    num3 = (int) (IntPtr) num2;
                    continue;
                  case 3:
                    flag = true;
                    num2 = (short) 9;
                    num3 = (int) (IntPtr) num2;
                    continue;
                  case 4:
                    index = 1;
                    ishItem = current.Value;
                    num2 = (short) 2;
                    num3 = (int) (IntPtr) num2;
                    continue;
                  case 5:
                    switch (0)
                    {
                      case 0:
                        break;
                      default:
                        continue;
                    }
                    break;
                  case 6:
                    if (!enumerator.MoveNext())
                    {
                      num2 = (short) 1;
                      num3 = (int) (IntPtr) num2;
                      continue;
                    }
                    current = enumerator.Current;
                    key = current.Key;
                    num2 = (short) 8;
                    num3 = (int) (IntPtr) num2;
                    continue;
                  case 8:
                    if (((IshHeader) ref key).IshType == (ushort) 903)
                    {
                      num2 = (short) 4;
                      num3 = (int) (IntPtr) num2;
                      continue;
                    }
                    break;
                }
                num2 = (short) 6;
                num3 = (int) (IntPtr) num2;
              }
            }
            finally
            {
              int num4 = 1;
              short num5;
              while (true)
              {
                switch (num4)
                {
                  case 0:
                    goto label_28;
                  case 1:
                    switch (0)
                    {
                      case 0:
                        break;
                      default:
                        continue;
                    }
                    break;
                  case 2:
                    enumerator.Dispose();
                    num5 = (short) 0;
                    num4 = (int) (IntPtr) num5;
                    continue;
                }
                if (enumerator != null)
                {
                  num5 = (short) 2;
                  num4 = (int) (IntPtr) num5;
                  continue;
                }
                break;
label_24:;
              }
label_28:
              num5 = (short) -11895;
              int num6 = (int) num5;
              num5 = (short) -11895;
              int num7 = (int) num5;
              switch (num6 == num7 ? 1 : 0)
              {
                case 0:
                case 2:
                  goto label_24;
                default:
                  num5 = (short) 0;
                  if (num5 == (short) 0)
                    ;
              }
            }
label_32:
            return flag;
        }
    }
  }

  internal static string ReadEncryptPassword(PbaObject pba)
  {
    short num1 = 0;
    num1 = (short) 0;
    switch (num1)
    {
      default:
        num1 = (short) 1;
        if (num1 == (short) 0)
          ;
        IshItemCollection ishItemCollection = pba.GetCodeplugInIshItemCollection();
        string str = string.Empty;
        IEnumerator<KeyValuePair<IshHeader, IshItem>> enumerator = ishItemCollection.GetEnumerator();
        try
        {
          num1 = (short) 3;
          int num2 = (int) (IntPtr) num1;
          while (true)
          {
            KeyValuePair<IshHeader, IshItem> current;
            IshHeader key;
            switch (num2)
            {
              case 0:
              case 2:
                goto label_23;
              case 1:
                if (((IshHeader) ref key).IshType == (ushort) 1150)
                {
                  num1 = (short) 5;
                  num2 = (int) (IntPtr) num1;
                  continue;
                }
                break;
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
                if (enumerator.MoveNext())
                {
                  current = enumerator.Current;
                  key = current.Key;
                  num1 = (short) 1;
                  num2 = (int) (IntPtr) num1;
                  continue;
                }
                num1 = (short) 6;
                num2 = (int) (IntPtr) num1;
                continue;
              case 5:
                int sourceIndex = 1;
                int length = 48 /*0x30*/;
                byte[] destinationArray = new byte[length];
                IshItem ishItem = current.Value;
                Array.Copy((Array) ((IshItem) ref ishItem).Data, sourceIndex, (Array) destinationArray, 0, length);
                str = AESCryptoUtil.HEXString(destinationArray);
                num1 = (short) 0;
                num2 = (int) (IntPtr) num1;
                continue;
              case 6:
                num1 = (short) 2;
                num2 = (int) (IntPtr) num1;
                continue;
            }
            num1 = (short) 4;
            num2 = (int) (IntPtr) num1;
          }
        }
        finally
        {
          short num3 = 1;
          int num4 = (int) (IntPtr) num3;
          while (true)
          {
            switch (num4)
            {
              case 0:
                goto label_20;
              case 1:
                switch (0)
                {
                  case 0:
                    break;
                  default:
                    continue;
                }
                break;
              case 2:
                enumerator.Dispose();
                num3 = (short) 0;
                num4 = (int) (IntPtr) num3;
                continue;
            }
            if (enumerator != null)
            {
              num3 = (short) 2;
              num4 = (int) (IntPtr) num3;
              continue;
            }
            break;
label_16:;
          }
label_20:
          num3 = (short) -2184;
          int num5 = (int) num3;
          num3 = (short) -2184;
          int num6 = (int) num3;
          switch (num5 == num6 ? 1 : 0)
          {
            case 0:
            case 2:
              goto label_16;
            default:
              num3 = (short) 0;
              if (num3 == (short) 0)
                ;
          }
        }
label_23:
        return str;
    }
  }

  internal static int ReadTxPowerLevelsCFGType(PbaObject pba)
  {
    short num1 = 0;
    num1 = (short) 0;
    switch (num1)
    {
      default:
        IshItemCollection ishItemCollection = pba.GetCodeplugInIshItemCollection();
        int num2 = -1;
        IEnumerator<KeyValuePair<IshHeader, IshItem>> enumerator = ishItemCollection.GetEnumerator();
        try
        {
          num1 = (short) 3;
          int num3 = (int) (IntPtr) num1;
          while (true)
          {
            KeyValuePair<IshHeader, IshItem> current;
            IshHeader key;
            switch (num3)
            {
              case 0:
              case 2:
                goto label_22;
              case 1:
                if (((IshHeader) ref key).IshType == (ushort) 1026)
                {
                  num1 = (short) 5;
                  num3 = (int) (IntPtr) num1;
                  continue;
                }
                break;
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
                if (enumerator.MoveNext())
                {
                  current = enumerator.Current;
                  key = current.Key;
                  num1 = (short) 1;
                  num3 = (int) (IntPtr) num1;
                  continue;
                }
                num1 = (short) 6;
                num3 = (int) (IntPtr) num1;
                continue;
              case 5:
                int index = 129;
                IshItem ishItem = current.Value;
                num2 = (int) ((IshItem) ref ishItem).Data[index];
                num1 = (short) 0;
                num3 = (int) (IntPtr) num1;
                continue;
              case 6:
                num1 = (short) 2;
                num3 = (int) (IntPtr) num1;
                continue;
            }
            num1 = (short) 4;
            num3 = (int) (IntPtr) num1;
          }
        }
        finally
        {
          short num4 = 1;
          int num5 = (int) (IntPtr) num4;
          while (true)
          {
            switch (num5)
            {
              case 0:
                goto label_19;
              case 1:
                switch (0)
                {
                  case 0:
                    break;
                  default:
                    continue;
                }
                break;
              case 2:
                enumerator.Dispose();
                num4 = (short) 0;
                num5 = (int) (IntPtr) num4;
                continue;
            }
            if (enumerator != null)
            {
              num4 = (short) 2;
              num5 = (int) (IntPtr) num4;
              continue;
            }
            break;
label_15:;
          }
label_19:
          num4 = (short) 16143;
          int num6 = (int) num4;
          num4 = (short) 16143;
          int num7 = (int) num4;
          switch (num6 == num7 ? 1 : 0)
          {
            case 0:
            case 2:
              goto label_15;
            default:
              num4 = (short) 0;
              if (num4 == (short) 0)
                ;
          }
        }
label_22:
        num1 = (short) 1;
        if (num1 == (short) 0)
          ;
        return num2;
    }
  }

  internal static bool GetIshItemPCICapable(PbaObject pba, int nOffset, int nValue)
  {
    int num1 = 0;
    switch (num1)
    {
      default:
        if (false)
          ;
        short num2 = 0;
        int num3 = 2;
        bool ishItemPciCapable;
        try
        {
          IshItemCollection ishItemCollection;
          switch (0)
          {
            case 0:
label_5:
              ishItemCollection = pba.GetCodeplugInIshItemCollection();
              num2 = (short) 0;
              num1 = (int) (IntPtr) num2;
              goto default;
            default:
              while (true)
              {
                IEnumerator<KeyValuePair<IshHeader, IshItem>> enumerator;
                switch (num1)
                {
                  case 0:
                    if (ishItemCollection.Count > 0)
                    {
                      num2 = (short) 2;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    }
                    break;
                  case 1:
                    goto label_35;
                  case 2:
                    enumerator = ishItemCollection.GetEnumerator();
                    num2 = (short) 3;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  case 3:
                    try
                    {
                      num2 = (short) 5;
                      int num4 = (int) (IntPtr) num2;
                      while (true)
                      {
                        KeyValuePair<IshHeader, IshItem> current;
                        IshHeader key;
                        switch (num4)
                        {
                          case 0:
                            goto label_33;
                          case 1:
                            if (!enumerator.MoveNext())
                            {
                              num2 = (short) 8;
                              num4 = (int) (IntPtr) num2;
                              continue;
                            }
                            current = enumerator.Current;
                            key = current.Key;
                            num2 = (short) 9;
                            num4 = (int) (IntPtr) num2;
                            continue;
                          case 2:
                            num2 = (short) 4;
                            num4 = (int) (IntPtr) num2;
                            continue;
                          case 3:
                            goto label_23;
                          case 4:
                            int num5 = nOffset + num3;
                            IshItem ishItem1 = current.Value;
                            int length = ((IshItem) ref ishItem1).Data.Length;
                            if (num5 < length)
                            {
                              IshItem ishItem2 = current.Value;
                              ishItemPciCapable = ((uint) ((IshItem) ref ishItem2).Data[nOffset] & (uint) nValue) > 0U;
                              num2 = (short) 6;
                              num4 = (int) (IntPtr) num2;
                              continue;
                            }
                            num2 = (short) 7;
                            num4 = (int) (IntPtr) num2;
                            continue;
                          case 5:
                            switch (0)
                            {
                              case 0:
                                break;
                              default:
                                continue;
                            }
                            break;
                          case 6:
                            goto label_35;
                          case 7:
                            ishItemPciCapable = false;
                            num2 = (short) 3;
                            num4 = (int) (IntPtr) num2;
                            continue;
                          case 8:
                            num2 = (short) 0;
                            num4 = (int) (IntPtr) num2;
                            continue;
                          case 9:
                            if (((IshHeader) ref key).IshType == (ushort) 903)
                            {
                              num2 = (short) 2;
                              num4 = (int) (IntPtr) num2;
                              continue;
                            }
                            break;
                        }
                        num2 = (short) 1;
                        num4 = (int) (IntPtr) num2;
                        continue;
label_11:;
                      }
label_23:
                      num2 = (short) -11315;
                      int num6 = (int) num2;
                      num2 = (short) -11315;
                      int num7 = (int) num2;
                      switch (num6 == num7 ? 1 : 0)
                      {
                        case 0:
                        case 2:
                          goto label_11;
                        default:
                          num2 = (short) 0;
                          if (num2 == (short) 0)
                            goto label_35;
                          goto label_35;
                      }
                    }
                    finally
                    {
                      int num8 = 2;
                      while (true)
                      {
                        switch (num8)
                        {
                          case 0:
                            enumerator.Dispose();
                            num8 = 1;
                            continue;
                          case 1:
                            goto label_32;
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
                        if (enumerator != null)
                          num8 = 0;
                        else
                          break;
                      }
label_32:;
                    }
                  default:
                    goto label_5;
                }
label_33:
                ishItemPciCapable = false;
                num2 = (short) 1;
                num1 = (int) (IntPtr) num2;
              }
          }
        }
        catch
        {
          ishItemPciCapable = false;
        }
label_35:
        return ishItemPciCapable;
    }
  }

  internal static byte[] GetFDB(PbaObject pba)
  {
    int num1 = 0;
    switch (num1)
    {
      default:
        byte[] fdb;
        IshItemCollection ishItemCollection;
        switch (0)
        {
          case 0:
label_3:
            fdb = new byte[0];
            ishItemCollection = pba.GetCodeplugInIshItemCollection();
            num1 = 2;
            goto default;
          default:
            IEnumerator<KeyValuePair<IshHeader, IshItem>> enumerator;
            while (true)
            {
              switch (num1)
              {
                case 0:
                  enumerator = ishItemCollection.GetEnumerator();
                  num1 = 1;
                  continue;
                case 1:
                  goto label_7;
                case 2:
                  if (false)
                    ;
                  if (ishItemCollection.Count > 0)
                  {
                    num1 = 0;
                    continue;
                  }
                  goto label_28;
                default:
                  goto label_3;
              }
            }
label_7:
            try
            {
              int num2 = 6;
              while (true)
              {
                short num3;
                KeyValuePair<IshHeader, IshItem> current;
                IshHeader key;
                switch (num2)
                {
                  case 0:
                  case 5:
                    goto label_28;
                  case 1:
                    if (((IshHeader) ref key).IshType == (ushort) 901)
                    {
                      num3 = (short) 4;
                      num2 = (int) (IntPtr) num3;
                      continue;
                    }
                    goto default;
                  case 2:
                    if (enumerator.MoveNext())
                    {
                      current = enumerator.Current;
                      key = current.Key;
                      num3 = (short) 1;
                      num2 = (int) (IntPtr) num3;
                      continue;
                    }
                    break;
                  case 3:
                    num3 = (short) 25800;
                    int num4 = (int) num3;
                    num3 = (short) 25800;
                    int num5 = (int) num3;
                    switch (num4 == num5 ? 1 : 0)
                    {
                      case 0:
                      case 2:
                        break;
                      default:
                        num3 = (short) 0;
                        if (num3 == (short) 0)
                          ;
                        num3 = (short) 5;
                        num2 = (int) (IntPtr) num3;
                        continue;
                    }
                    break;
                  case 4:
                    IshItem ishItem = current.Value;
                    fdb = ((IshItem) ref ishItem).Data;
                    num3 = (short) 0;
                    num2 = (int) (IntPtr) num3;
                    continue;
                  case 6:
                    switch (0)
                    {
                      case 0:
                        goto label_10;
                      default:
                        continue;
                    }
                  default:
label_10:
                    num3 = (short) 2;
                    num2 = (int) (IntPtr) num3;
                    continue;
                }
                num3 = (short) 3;
                num2 = (int) (IntPtr) num3;
              }
            }
            finally
            {
              short num6 = 2;
              int num7 = (int) (IntPtr) num6;
              while (true)
              {
                switch (num7)
                {
                  case 0:
                    enumerator.Dispose();
                    num6 = (short) 1;
                    num7 = (int) (IntPtr) num6;
                    continue;
                  case 1:
                    goto label_26;
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
                if (enumerator != null)
                {
                  num6 = (short) 0;
                  num7 = (int) (IntPtr) num6;
                }
                else
                  break;
              }
label_26:;
            }
label_28:
            return fdb;
        }
    }
  }

  internal static IshItem GetBlockIshItem(PbaObject pba, ushort itemID)
  {
    int num1 = 0;
    switch (num1)
    {
      default:
        IshItem blockIshItem;
        IshItemCollection ishItemCollection;
        short num2;
        switch (0)
        {
          case 0:
label_3:
            blockIshItem = new IshItem();
            ishItemCollection = pba.GetCodeplugInIshItemCollection();
            num2 = (short) 2;
            num1 = (int) (IntPtr) num2;
            goto default;
          default:
            IEnumerator<KeyValuePair<IshHeader, IshItem>> enumerator;
            while (true)
            {
              switch (num1)
              {
                case 0:
                  enumerator = ishItemCollection.GetEnumerator();
                  num2 = (short) 0;
                  num2 = (short) 1;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 1:
                  goto label_27;
                case 2:
                  if (ishItemCollection.Count > 0)
                  {
                    num2 = (short) 0;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_28;
                default:
                  goto label_3;
              }
            }
label_27:
            num2 = (short) 1;
            if (num2 == (short) 0)
              ;
            try
            {
              num2 = (short) 6;
              int num3 = (int) (IntPtr) num2;
              while (true)
              {
                KeyValuePair<IshHeader, IshItem> current;
                IshHeader key;
                switch (num3)
                {
                  case 0:
                  case 5:
                    goto label_28;
                  case 1:
                    if ((int) ((IshHeader) ref key).IshType == (int) itemID)
                    {
                      num2 = (short) 4;
                      num3 = (int) (IntPtr) num2;
                      continue;
                    }
                    goto default;
                  case 2:
                    if (enumerator.MoveNext())
                    {
                      current = enumerator.Current;
                      key = current.Key;
                      num2 = (short) 1;
                      num3 = (int) (IntPtr) num2;
                      continue;
                    }
                    break;
                  case 3:
                    num2 = (short) -10028;
                    int num4 = (int) num2;
                    num2 = (short) -10028;
                    int num5 = (int) num2;
                    switch (num4 == num5 ? 1 : 0)
                    {
                      case 0:
                      case 2:
                        break;
                      default:
                        num2 = (short) 0;
                        if (num2 == (short) 0)
                          ;
                        num2 = (short) 5;
                        num3 = (int) (IntPtr) num2;
                        continue;
                    }
                    break;
                  case 4:
                    blockIshItem = current.Value;
                    num2 = (short) 0;
                    num3 = (int) (IntPtr) num2;
                    continue;
                  case 6:
                    switch (0)
                    {
                      case 0:
                        goto label_9;
                      default:
                        continue;
                    }
                  default:
label_9:
                    num2 = (short) 2;
                    num3 = (int) (IntPtr) num2;
                    continue;
                }
                num2 = (short) 3;
                num3 = (int) (IntPtr) num2;
              }
            }
            finally
            {
              short num6 = 2;
              int num7 = (int) (IntPtr) num6;
              while (true)
              {
                switch (num7)
                {
                  case 0:
                    enumerator.Dispose();
                    num6 = (short) 1;
                    num7 = (int) (IntPtr) num6;
                    continue;
                  case 1:
                    goto label_25;
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
                if (enumerator != null)
                {
                  num6 = (short) 0;
                  num7 = (int) (IntPtr) num6;
                }
                else
                  break;
              }
label_25:;
            }
label_28:
            return blockIshItem;
        }
    }
  }

  internal static IshItemCollection UpdateBlockIshItem(
    IshItemCollection ishItems,
    IshItem blockItem,
    byte partition,
    ushort blockType)
  {
    switch (0)
    {
      default:
        short num1 = 10;
        int num2 = (int) (IntPtr) num1;
        while (true)
        {
          IEnumerator<KeyValuePair<IshHeader, IshItem>> enumerator;
          bool flag;
          switch (num2)
          {
            case 0:
              if (flag)
              {
                num1 = (short) 4;
                num2 = (int) (IntPtr) num1;
                continue;
              }
              goto label_39;
            case 1:
              num1 = (short) 7;
              num2 = (int) (IntPtr) num1;
              continue;
            case 2:
            case 6:
              goto label_39;
            case 3:
              if (ishItems.Count > 0)
              {
                num1 = (short) 9;
                num2 = (int) (IntPtr) num1;
                continue;
              }
              goto label_39;
            case 4:
              IshHeader ishHeader1;
              // ISSUE: explicit constructor call
              ((IshHeader) ref ishHeader1).\u002Ector(partition, blockType, (ushort) 0);
              ishItems.Remove(ishHeader1);
              ishItems.Add(ishHeader1, blockItem);
              num1 = (short) 2;
              num2 = (int) (IntPtr) num1;
              continue;
            case 5:
              num1 = (short) 0;
              IshHeader ishHeader2;
              // ISSUE: explicit constructor call
              ((IshHeader) ref ishHeader2).\u002Ector(partition, blockType, (ushort) 0);
              ishItems.Remove(ishHeader2);
              num1 = (short) 6;
              num2 = (int) (IntPtr) num1;
              continue;
            case 7:
              if (ishItems.Count > 0)
              {
                num1 = (short) 5;
                num2 = (int) (IntPtr) num1;
                continue;
              }
              goto label_39;
            case 8:
              try
              {
                num1 = (short) 6;
                int num3 = (int) (IntPtr) num1;
                while (true)
                {
                  IshHeader key;
                  switch (num3)
                  {
                    case 0:
                    case 5:
                      goto label_31;
                    case 1:
                      if (enumerator.MoveNext())
                      {
                        key = enumerator.Current.Key;
                        num1 = (short) 2;
                        num3 = (int) (IntPtr) num1;
                        continue;
                      }
                      num1 = (short) 4;
                      num3 = (int) (IntPtr) num1;
                      continue;
                    case 2:
label_10:
                      if ((int) ((IshHeader) ref key).IshType == (int) blockType)
                      {
                        num1 = (short) 3;
                        num3 = (int) (IntPtr) num1;
                        continue;
                      }
                      break;
                    case 3:
                      flag = true;
                      num1 = (short) 0;
                      num3 = (int) (IntPtr) num1;
                      continue;
                    case 4:
                      num1 = (short) 26447;
                      int num4 = (int) num1;
                      num1 = (short) 26447;
                      int num5 = (int) num1;
                      switch (num4 == num5 ? 1 : 0)
                      {
                        case 0:
                        case 2:
                          goto label_10;
                        default:
                          num1 = (short) 0;
                          if (num1 == (short) 0)
                            ;
                          num1 = (short) 5;
                          num3 = (int) (IntPtr) num1;
                          continue;
                      }
                    case 6:
                      switch (0)
                      {
                        case 0:
                          break;
                        default:
                          continue;
                      }
                      break;
                  }
                  num1 = (short) 1;
                  num3 = (int) (IntPtr) num1;
                }
              }
              finally
              {
                int num6 = 2;
                while (true)
                {
                  short num7;
                  switch (num6)
                  {
                    case 0:
                      enumerator.Dispose();
                      num7 = (short) 1;
                      num6 = (int) (IntPtr) num7;
                      continue;
                    case 1:
                      goto label_25;
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
                  if (enumerator != null)
                  {
                    num7 = (short) 0;
                    num6 = (int) (IntPtr) num7;
                  }
                  else
                    break;
                }
label_25:;
              }
label_31:
              num1 = (short) 0;
              num2 = (int) (IntPtr) num1;
              continue;
            case 9:
              flag = false;
              enumerator = ishItems.GetEnumerator();
              num1 = (short) 1;
              if (num1 == (short) 0)
                ;
              num1 = (short) 8;
              num2 = (int) (IntPtr) num1;
              continue;
            case 10:
              switch (0)
              {
                case 0:
                  break;
                default:
                  continue;
              }
              break;
          }
          if (((IshItem) ref blockItem).ItemSize == 0)
          {
            num1 = (short) 1;
            num2 = (int) (IntPtr) num1;
          }
          else
          {
            num1 = (short) 3;
            num2 = (int) (IntPtr) num1;
          }
        }
label_39:
        return ishItems;
    }
  }

  public static string RadioSNToString(string radSN)
  {
    string empty;
    try
    {
      short num1 = -16368;
      int num2 = (int) num1;
      num1 = (short) -16368;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          short num4 = 1;
          if (num4 == (short) 0)
            ;
          num4 = (short) 0;
          if (num4 == (short) 0)
            ;
          empty = Encoding.ASCII.GetString(Convert.FromBase64String(radSN));
          break;
        default:
          goto case 1;
      }
    }
    catch
    {
      empty = string.Empty;
    }
    return empty;
  }

  internal static RadioSecurityData GetRadioSecurityData(RadioParams curRadioParms, PbaObject pba)
  {
label_0:
    int ownerAdvKeyType = 0;
    int ownerSysId = 0;
    int ownerWacnId = 0;
    bool bAskReq = false;
    bool bWriteProtected = false;
    RadioSecurityData radioSecurityData;
    try
    {
      string flashcodeFromFbd = ParseDataHelper.GetRadioFlashcodeFromFBD(ParseDataHelper.GetFDB(pba));
      Dictionary<string, int> radioTrkSysNamesAndIdsWithAskReqOn;
      Dictionary<string, int> radioTrkSysNamesAndIdsWithAskReqOff;
      ParseDataHelper.ReadRadioTrkSystemNamesAndIds(pba.GetCodeplugInIshItemCollection(), out radioTrkSysNamesAndIdsWithAskReqOn, out radioTrkSysNamesAndIdsWithAskReqOff);
      bool bConvnOnly = RadioOperationValidator.IsRadioConvOnly(curRadioParms.ModelNumber, flashcodeFromFbd, false);
      ProtectionOption protectionOption = RadioAccessValidator.GetProtectionOption(curRadioParms.ModelNumber, flashcodeFromFbd, false);
      ParseDataHelper.GetRadioSecurityConfigurationData(curRadioParms.CodeplugVersion, protectionOption, out ownerAdvKeyType, out ownerSysId, out ownerWacnId, out bAskReq, out bWriteProtected, pba);
      radioSecurityData = new RadioSecurityData(protectionOption, ownerAdvKeyType, ownerSysId, ownerWacnId, bAskReq, bWriteProtected, bConvnOnly, radioTrkSysNamesAndIdsWithAskReqOn, radioTrkSysNamesAndIdsWithAskReqOff);
    }
    catch (Exception ex)
    {
      radioSecurityData = (RadioSecurityData) null;
    }
    short num = 10093;
    switch ((short) 10093 == num ? 1 : 0)
    {
      case 0:
      case 2:
        goto label_0;
      default:
        num = (short) 0;
        if (num == (short) 0)
          ;
        num = (short) 0;
        num = (short) 1;
        if (num == (short) 0)
          ;
        return radioSecurityData;
    }
  }

  internal static string GetRadioFlashcodeFromFBD(byte[] featDescBlk)
  {
    int A_1 = 3;
    int num1 = 6;
    short num2;
    byte[] numArray;
    while (true)
    {
      int index;
      int sourceIndex;
      switch (num1)
      {
        case 0:
        case 8:
          num2 = (short) 9;
          num1 = (int) (IntPtr) num2;
          continue;
        case 1:
          num2 = (short) -7674;
          int num3 = (int) num2;
          num2 = (short) -7674;
          int num4 = (int) num2;
          switch (num3 == num4 ? 1 : 0)
          {
            case 0:
            case 2:
              goto label_9;
            case 1:
              goto label_8;
            default:
              goto label_7;
          }
        case 2:
          if (featDescBlk.Length == 16 /*0x10*/)
          {
            num2 = (short) 3;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          Array.Copy((Array) featDescBlk, sourceIndex, (Array) numArray, 0, 24);
          num2 = (short) 7;
          num1 = (int) (IntPtr) num2;
          continue;
        case 3:
          Array.Copy((Array) featDescBlk, sourceIndex, (Array) numArray, 0, 12);
          num2 = (short) 4;
          num1 = (int) (IntPtr) num2;
          continue;
        case 4:
        case 7:
          goto label_20;
        case 5:
label_9:
          num2 = (short) 2;
          num1 = (int) (IntPtr) num2;
          continue;
        case 6:
          switch (0)
          {
            case 0:
              break;
            default:
              continue;
          }
          break;
        case 9:
          if (index >= 24)
          {
            num2 = (short) 5;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          numArray[index] = (byte) 0;
          ++index;
          num2 = (short) 8;
          num1 = (int) (IntPtr) num2;
          continue;
      }
      num2 = (short) 1;
      if (num2 == (short) 0)
        ;
      if (featDescBlk == null)
      {
        num2 = (short) 1;
        num1 = (int) (IntPtr) num2;
      }
      else
      {
        sourceIndex = 2;
        numArray = new byte[24];
        index = 0;
        num2 = (short) 0;
        num1 = (int) (IntPtr) num2;
      }
    }
label_7:
    num2 = (short) 0;
label_8:
    num2 = (short) 0;
    if (num2 == (short) 0)
      ;
    throw new ArgumentException(RptMgrErrorHandler.b("\uE085\uED87\uEB89\uF88B쪍\uF58F\uE191\uF793풕\uF497\uF199", A_1));
label_20:
    return FlashcodeFormatter.FormatFlashcodeString(numArray, numArray.Length);
  }

  internal static void GetRadioSecurityConfigurationData(
    string curRadioCpgVersion,
    ProtectionOption opt,
    out int ownerAdvKeyType,
    out int ownerSysId,
    out int ownerWacnId,
    out bool bAskReq,
    out bool bWriteProtected,
    PbaObject pba)
  {
    int num1 = 0;
    switch (num1)
    {
      default:
        int index1;
        int index2;
        int index3;
        int index4;
        int num2;
        int index5;
        int num3;
        IshItemCollection ishItemCollection;
        IshHeader ishHeader;
        short num4;
        switch (0)
        {
          case 0:
label_3:
            ushort num5 = 1026;
            ownerAdvKeyType = 0;
            index1 = 124;
            ownerSysId = 0;
            index2 = 106;
            ownerWacnId = 0;
            index3 = 121;
            bAskReq = false;
            index4 = 97;
            num2 = 3;
            bWriteProtected = false;
            index5 = 19;
            num3 = 6;
            ishItemCollection = pba.GetCodeplugInIshItemCollection();
            // ISSUE: explicit constructor call
            ((IshHeader) ref ishHeader).\u002Ector((byte) 208 /*0xD0*/, num5, (ushort) 0);
            num4 = (short) 4;
            num1 = (int) (IntPtr) num4;
            goto default;
          default:
            while (true)
            {
              int num6;
              int num7;
              int num8;
              int num9;
              int num10;
              IshItem ishItem;
              int num11;
              switch (num1)
              {
                case 0:
                  num11 = 5;
                  num9 = 1;
                  num7 = 0;
                  num10 = 0;
                  num8 = 0;
                  num6 = 0;
                  num4 = (short) 20022;
                  int num12 = (int) num4;
                  num4 = (short) 20022;
                  int num13 = (int) num4;
                  switch (num12 == num13 ? 1 : 0)
                  {
                    case 0:
                    case 2:
                      goto label_14;
                    default:
                      num4 = (short) 0;
                      if (num4 == (short) 0)
                        ;
                      num4 = (short) 18;
                      num1 = (int) (IntPtr) num4;
                      continue;
                  }
                case 1:
                  num4 = (short) 17;
                  num1 = (int) (IntPtr) num4;
                  continue;
                case 2:
                  byte num14 = ((IshItem) ref ishItem).Data[index5];
                  IntMask intMask1 = new IntMask(num3, 1);
                  bWriteProtected = intMask1.Apply((int) num14, (MaskApplication) 1) > 0;
                  num4 = (short) 8;
                  num1 = (int) (IntPtr) num4;
                  continue;
                case 3:
                  num4 = (short) 0;
                  ishItem = ishItemCollection[ishHeader];
                  num4 = (short) 19;
                  num1 = (int) (IntPtr) num4;
                  continue;
                case 4:
                  if (ishItemCollection.ContainsHeader(ishHeader))
                  {
                    num4 = (short) 3;
                    num1 = (int) (IntPtr) num4;
                    continue;
                  }
                  goto label_39;
                case 5:
                  if (num10 == num11)
                  {
                    num4 = (short) 1;
                    num1 = (int) (IntPtr) num4;
                    continue;
                  }
                  goto case 20;
                case 6:
                  if (num6 >= num7)
                  {
                    num4 = (short) 11;
                    num1 = (int) (IntPtr) num4;
                    continue;
                  }
                  goto case 7;
                case 7:
label_14:
                  num4 = (short) 1;
                  if (num4 == (short) 0)
                    ;
                  int num15 = (int) ((IshItem) ref ishItem).Data[index2] << 8 | (int) ((IshItem) ref ishItem).Data[index2 + 1];
                  ownerSysId = num15;
                  byte num16 = ((IshItem) ref ishItem).Data[index4];
                  IntMask intMask2 = new IntMask(num2, 1);
                  bAskReq = intMask2.Apply((int) num16, (MaskApplication) 1) > 0;
                  num4 = (short) 2;
                  num1 = (int) (IntPtr) num4;
                  continue;
                case 8:
                  goto label_35;
                case 9:
                  if (num10 >= num11)
                  {
                    num4 = (short) 13;
                    num1 = (int) (IntPtr) num4;
                    continue;
                  }
                  goto case 7;
                case 10:
                  if (num8 == num9)
                  {
                    num4 = (short) 16 /*0x10*/;
                    num1 = (int) (IntPtr) num4;
                    continue;
                  }
                  goto case 11;
                case 11:
                  ownerAdvKeyType = (int) ((IshItem) ref ishItem).Data[index1];
                  byte num17 = ((IshItem) ref ishItem).Data[index3];
                  byte num18 = ((IshItem) ref ishItem).Data[index3 + 1];
                  byte num19 = ((IshItem) ref ishItem).Data[index3 + 2];
                  ownerWacnId |= (int) num17 << 16 /*0x10*/;
                  ownerWacnId |= (int) num18 << 8;
                  ownerWacnId |= (int) num19;
                  num4 = (short) 7;
                  num1 = (int) (IntPtr) num4;
                  continue;
                case 12:
                  try
                  {
                    num10 = (int) Convert.ToInt16(curRadioCpgVersion.Substring(1, 2), 10);
                    num8 = (int) Convert.ToInt16(curRadioCpgVersion.Substring(4, 2), 10);
                    num6 = (int) Convert.ToInt16(curRadioCpgVersion.Substring(7, 2), 10);
                    break;
                  }
                  catch (Exception ex)
                  {
                    break;
                  }
                case 13:
                  num4 = (short) 5;
                  num1 = (int) (IntPtr) num4;
                  continue;
                case 14:
                  num4 = (short) 10;
                  num1 = (int) (IntPtr) num4;
                  continue;
                case 15:
                  if (num10 == num11)
                  {
                    num4 = (short) 14;
                    num1 = (int) (IntPtr) num4;
                    continue;
                  }
                  goto case 11;
                case 16 /*0x10*/:
                  num4 = (short) 6;
                  num1 = (int) (IntPtr) num4;
                  continue;
                case 17:
                  if (num8 >= num9)
                  {
                    num4 = (short) 20;
                    num1 = (int) (IntPtr) num4;
                    continue;
                  }
                  goto case 7;
                case 18:
                  if (!string.IsNullOrEmpty(curRadioCpgVersion))
                  {
                    num4 = (short) 12;
                    num1 = (int) (IntPtr) num4;
                    continue;
                  }
                  break;
                case 19:
                  if (opt == ProtectionOption.HARDWARE)
                  {
                    num4 = (short) 0;
                    num1 = (int) (IntPtr) num4;
                    continue;
                  }
                  goto case 2;
                case 20:
                  num4 = (short) 15;
                  num1 = (int) (IntPtr) num4;
                  continue;
                default:
                  goto label_3;
              }
              num1 = 9;
            }
label_35:
            return;
label_39:
            return;
        }
    }
  }

  internal static string getCodeplugFlashCode()
  {
label_0:
    short num1 = 0;
    int num2;
    string codeplugFlashCode;
    Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation radioInformation;
    switch (0)
    {
      case 0:
label_2:
        codeplugFlashCode = string.Empty;
        radioInformation = FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation;
        num1 = (short) 1;
        if (num1 == (short) 0)
          ;
        num1 = (short) 2;
        num2 = (int) (IntPtr) num1;
        goto default;
      default:
        while (true)
        {
          switch (num2)
          {
            case 0:
              goto label_9;
            case 1:
              num1 = (short) -6401;
              int num3 = (int) num1;
              num1 = (short) -6401;
              int num4 = (int) num1;
              switch (num3 == num4 ? 1 : 0)
              {
                case 0:
                case 2:
                  goto label_0;
                default:
                  num1 = (short) 0;
                  if (num1 == (short) 0)
                    ;
                  codeplugFlashCode = Convert.ToBase64String(Encoding.ASCII.GetBytes(radioInformation.FLASHport.RadInfoFLASHportFLASHcode_A8132Value));
                  num1 = (short) 0;
                  num2 = (int) (IntPtr) num1;
                  continue;
              }
            case 2:
              if (radioInformation != null)
              {
                num1 = (short) 1;
                num2 = (int) (IntPtr) num1;
                continue;
              }
              goto label_9;
            default:
              goto label_2;
          }
        }
label_9:
        return codeplugFlashCode;
    }
  }

  internal static IshItemCollection GetRadioASKProgrammingHistoryList(PbaObject pba)
  {
    int num1 = 0;
    switch (num1)
    {
      default:
        short num2;
        IshItemCollection ishItemCollection;
        IshItemCollection programmingHistoryList;
        switch (0)
        {
          case 0:
label_3:
            num2 = (short) 1;
            if (num2 == (short) 0)
              ;
            ishItemCollection = pba.GetCodeplugInIshItemCollection();
            programmingHistoryList = new IshItemCollection();
            num2 = (short) 2;
            num1 = (int) (IntPtr) num2;
            goto default;
          default:
            IEnumerator<KeyValuePair<IshHeader, IshItem>> enumerator;
            while (true)
            {
              switch (num1)
              {
                case 0:
                  goto label_7;
                case 1:
                  enumerator = ishItemCollection.GetEnumerator();
                  num2 = (short) 0;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 2:
                  num2 = (short) 0;
                  if (ishItemCollection.Count > 0)
                  {
                    num2 = (short) 1;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_28;
                default:
                  goto label_3;
              }
            }
label_7:
            try
            {
              num2 = (short) 3;
              int num3 = (int) (IntPtr) num2;
              while (true)
              {
                KeyValuePair<IshHeader, IshItem> current;
                IshHeader key;
                switch (num3)
                {
                  case 0:
                    if (((IshHeader) ref key).IshType == (ushort) 1062)
                    {
                      num2 = (short) 2;
                      num3 = (int) (IntPtr) num2;
                      continue;
                    }
                    break;
                  case 1:
                    num2 = (short) 4;
                    num3 = (int) (IntPtr) num2;
                    continue;
                  case 2:
                    programmingHistoryList.Add(current.Key, current.Value);
                    num2 = (short) 5;
                    num3 = (int) (IntPtr) num2;
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
                  case 5:
                    goto label_28;
                  case 6:
                    if (!enumerator.MoveNext())
                    {
                      num2 = (short) 1;
                      num3 = (int) (IntPtr) num2;
                      continue;
                    }
                    current = enumerator.Current;
                    key = current.Key;
                    num2 = (short) 0;
                    num3 = (int) (IntPtr) num2;
                    continue;
                }
                num2 = (short) 6;
                num3 = (int) (IntPtr) num2;
              }
            }
            finally
            {
              short num4;
              int num5;
              switch (true ? 1 : 0)
              {
                case 0:
                case 2:
label_25:
                  enumerator.Dispose();
                  num4 = (short) 0;
                  num5 = (int) (IntPtr) num4;
                  break;
                default:
                  if (true)
                    ;
                  num4 = (short) 2;
                  num5 = (int) (IntPtr) num4;
                  break;
              }
              while (true)
              {
                switch (num5)
                {
                  case 0:
                    goto label_26;
                  case 1:
                    goto label_25;
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
                if (enumerator != null)
                {
                  num4 = (short) 1;
                  num5 = (int) (IntPtr) num4;
                }
                else
                  break;
              }
label_26:;
            }
label_28:
            return programmingHistoryList;
        }
    }
  }

  internal static Collection<TrkSysBandPlan> GetRadioTrkSystemShuffledBandPlans(PbaObject pba)
  {
    int num1 = 0;
    switch (num1)
    {
      default:
        Collection<TrkSysBandPlan> shuffledBandPlans;
        IshItemCollection ishItemCollection;
        short num2;
        switch (0)
        {
          case 0:
label_3:
            shuffledBandPlans = new Collection<TrkSysBandPlan>();
            ishItemCollection = pba.GetCodeplugInIshItemCollection();
            num2 = (short) 2;
            num1 = (int) (IntPtr) num2;
            goto default;
          default:
            IEnumerator<KeyValuePair<IshHeader, IshItem>> enumerator;
            while (true)
            {
              switch (num1)
              {
                case 0:
                  goto label_7;
                case 1:
                  num2 = (short) 1;
                  if (num2 == (short) 0)
                    ;
                  enumerator = ishItemCollection.GetEnumerator();
                  num2 = (short) 0;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 2:
                  if (ishItemCollection.Count > 0)
                  {
                    num2 = (short) 0;
                    num2 = (short) 1;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_31;
                default:
                  goto label_3;
              }
            }
label_7:
            try
            {
              num2 = (short) 1;
              int num3 = (int) (IntPtr) num2;
              while (true)
              {
                KeyValuePair<IshHeader, IshItem> current;
                IshHeader key;
                IshItem ishItem1;
                switch (num3)
                {
                  case 1:
                    switch (0)
                    {
                      case 0:
                        break;
                      default:
                        continue;
                    }
                    break;
                  case 2:
                    if (((IshItem) ref ishItem1).Data != null)
                    {
                      num2 = (short) 7;
                      num3 = (int) (IntPtr) num2;
                      continue;
                    }
                    break;
                  case 3:
                    ishItem1 = current.Value;
                    num2 = (short) 2;
                    num3 = (int) (IntPtr) num2;
                    continue;
                  case 4:
                    if (((IshHeader) ref key).IshType == (ushort) 3852)
                    {
                      num2 = (short) 3;
                      num3 = (int) (IntPtr) num2;
                      continue;
                    }
                    break;
                  case 5:
                    if (!enumerator.MoveNext())
                    {
                      num2 = (short) 8;
                      num3 = (int) (IntPtr) num2;
                      continue;
                    }
                    current = enumerator.Current;
                    key = current.Key;
                    num2 = (short) 4;
                    num3 = (int) (IntPtr) num2;
                    continue;
                  case 6:
                    goto label_31;
                  case 7:
                    IshItem ishItem2 = current.Value;
                    byte sysType = ((IshItem) ref ishItem2).Data[1];
                    IshItem ishItem3 = current.Value;
                    int num4 = (int) ((IshItem) ref ishItem3).Data[59];
                    IshItem ishItem4 = current.Value;
                    byte num5 = ((IshItem) ref ishItem4).Data[60];
                    int sysId = num4 << 8 | (int) num5;
                    ishItem1 = current.Value;
                    bool shuffledBandPlan = new IntMask(2, 1).Apply((int) ((IshItem) ref ishItem1).Data[70], (MaskApplication) 1) > 0;
                    shuffledBandPlans.Add(new TrkSysBandPlan((int) sysType, sysId, shuffledBandPlan));
                    num2 = (short) 0;
                    num3 = (int) (IntPtr) num2;
                    continue;
                  case 8:
                    num2 = (short) 6;
                    num3 = (int) (IntPtr) num2;
                    continue;
                }
                num2 = (short) 5;
                num3 = (int) (IntPtr) num2;
              }
            }
            finally
            {
              short num6 = -27323;
              int num7;
              switch ((short) -27323 == num6 ? 1 : 0)
              {
                case 0:
                case 2:
label_28:
                  enumerator.Dispose();
                  num6 = (short) 0;
                  num7 = (int) (IntPtr) num6;
                  break;
                default:
                  num6 = (short) 0;
                  if (num6 == (short) 0)
                    ;
                  num6 = (short) 2;
                  num7 = (int) (IntPtr) num6;
                  break;
              }
              while (true)
              {
                switch (num7)
                {
                  case 0:
                    goto label_29;
                  case 1:
                    goto label_28;
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
                if (enumerator != null)
                {
                  num6 = (short) 1;
                  num7 = (int) (IntPtr) num6;
                }
                else
                  break;
              }
label_29:;
            }
label_31:
            return shuffledBandPlans;
        }
    }
  }

  internal static IshItemCollection ReplaceSecurityPartition(
    IshItemCollection ishItems,
    DataPartition oldSecurityPartition)
  {
    int num1 = 0;
    switch (num1)
    {
      default:
        short num2;
        switch (0)
        {
          case 0:
label_3:
            num2 = (short) 1;
            num1 = (int) (IntPtr) num2;
            goto default;
          default:
            List<DataBlock>.Enumerator enumerator1;
            List<IshHeader> ishHeaderList;
            IEnumerator<KeyValuePair<IshHeader, IshItem>> enumerator2;
            while (true)
            {
              switch (num1)
              {
                case 0:
                  goto label_7;
                case 1:
                  num2 = (short) 1;
                  if (num2 == (short) 0)
                    ;
                  if (ishItems.Count > 0)
                  {
                    num2 = (short) 3;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_38;
                case 2:
                  try
                  {
                    num2 = (short) 3;
                    int num3 = (int) (IntPtr) num2;
                    while (true)
                    {
                      KeyValuePair<IshHeader, IshItem> current;
                      IshHeader key;
                      switch (num3)
                      {
                        case 0:
                          if (enumerator2.MoveNext())
                          {
                            current = enumerator2.Current;
                            key = current.Key;
                            num2 = (short) 6;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 2;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 1:
                          ishHeaderList.Add(current.Key);
                          num2 = (short) 5;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 2:
                          num2 = (short) 4;
                          num3 = (int) (IntPtr) num2;
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
                          goto label_37;
                        case 6:
                          if (((IshHeader) ref key).PartitionNumber == (byte) 212)
                          {
                            num2 = (short) 1;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          break;
                      }
                      num2 = (short) 0;
                      num3 = (int) (IntPtr) num2;
                    }
                  }
                  finally
                  {
                    short num4 = -6324;
                    int num5;
                    switch ((short) -6324 == num4 ? 1 : 0)
                    {
                      case 0:
                      case 2:
label_35:
                        enumerator2.Dispose();
                        num4 = (short) 0;
                        num5 = (int) (IntPtr) num4;
                        break;
                      default:
                        num4 = (short) 0;
                        if (num4 == (short) 0)
                          ;
                        num4 = (short) 2;
                        num5 = (int) (IntPtr) num4;
                        break;
                    }
                    while (true)
                    {
                      switch (num5)
                      {
                        case 0:
                          goto label_36;
                        case 1:
                          goto label_35;
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
                      if (enumerator2 != null)
                      {
                        num4 = (short) 1;
                        num5 = (int) (IntPtr) num4;
                      }
                      else
                        break;
                    }
label_36:;
                  }
label_37:
                  ishHeaderList.ForEach((Action<IshHeader>) (s =>
                  {
                    short num6 = -6397;
                    int num7 = (int) num6;
                    num6 = (short) -6397;
                    int num8 = (int) num6;
                    switch (num7 == num8)
                    {
                      case true:
                        short num9 = 0;
                        num9 = (short) 1;
                        if (num9 == (short) 0)
                          ;
                        num9 = (short) 0;
                        if (num9 == (short) 0)
                          ;
                        ishItems.Remove(s);
                        break;
                      default:
                        goto case 1;
                    }
                  }));
                  enumerator1 = oldSecurityPartition.DataBlocks.GetEnumerator();
                  num2 = (short) 0;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 3:
                  num2 = (short) 0;
                  ishHeaderList = new List<IshHeader>();
                  enumerator2 = ishItems.GetEnumerator();
                  num2 = (short) 2;
                  num1 = (int) (IntPtr) num2;
                  continue;
                default:
                  goto label_3;
              }
            }
label_7:
            try
            {
              num2 = (short) 1;
              int num10 = (int) (IntPtr) num2;
              while (true)
              {
                switch (num10)
                {
                  case 0:
                    num2 = (short) 2;
                    num10 = (int) (IntPtr) num2;
                    continue;
                  case 1:
                    switch (0)
                    {
                      case 0:
                        break;
                      default:
                        continue;
                    }
                    break;
                  case 2:
                    goto label_38;
                  case 4:
                    if (!enumerator1.MoveNext())
                    {
                      num2 = (short) 0;
                      num10 = (int) (IntPtr) num2;
                      continue;
                    }
                    DataBlock current = enumerator1.Current;
                    IshHeader ishHeader;
                    // ISSUE: explicit constructor call
                    ((IshHeader) ref ishHeader).\u002Ector(oldSecurityPartition.PartitionID, current.BlockType, current.BlockID);
                    IshItem ishItem;
                    // ISSUE: explicit constructor call
                    ((IshItem) ref ishItem).\u002Ector(current.LegthInBits / 8, current.PacketValue, (SequenceManagerResult) 135);
                    ishItems.Add(ishHeader, ishItem);
                    num2 = (short) 3;
                    num10 = (int) (IntPtr) num2;
                    continue;
                }
                num2 = (short) 4;
                num10 = (int) (IntPtr) num2;
              }
            }
            finally
            {
              enumerator1.Dispose();
            }
label_38:
            return ishItems;
        }
    }
  }

  internal static int ReadProgrammingPathValue(PbaObject pba)
  {
    short num1 = 1;
    if (num1 == (short) 0)
      ;
    num1 = (short) 0;
    switch (num1)
    {
      default:
        IshItemCollection ishItemCollection = pba.GetCodeplugInIshItemCollection();
        int num2 = -1;
        IEnumerator<KeyValuePair<IshHeader, IshItem>> enumerator = ishItemCollection.GetEnumerator();
        try
        {
          num1 = (short) 3;
          int num3 = (int) (IntPtr) num1;
          while (true)
          {
            KeyValuePair<IshHeader, IshItem> current;
            IshHeader key;
            switch (num3)
            {
              case 0:
                if (enumerator.MoveNext())
                {
                  current = enumerator.Current;
                  key = current.Key;
                  num1 = (short) 6;
                  num3 = (int) (IntPtr) num1;
                  continue;
                }
                num1 = (short) 2;
                num3 = (int) (IntPtr) num1;
                continue;
              case 1:
                int index = 294;
                IshItem ishItem = current.Value;
                num2 = (int) ((IshItem) ref ishItem).Data[index] & 15;
                num1 = (short) 5;
                num3 = (int) (IntPtr) num1;
                continue;
              case 2:
                num1 = (short) 4;
                num3 = (int) (IntPtr) num1;
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
              case 5:
                goto label_23;
              case 6:
                if (((IshHeader) ref key).IshType == (ushort) 1173)
                {
                  num1 = (short) 1;
                  num3 = (int) (IntPtr) num1;
                  continue;
                }
                break;
            }
            num1 = (short) 0;
            num3 = (int) (IntPtr) num1;
          }
        }
        finally
        {
          short num4 = -19067;
          int num5 = (int) num4;
          num4 = (short) -19067;
          int num6 = (int) num4;
          int num7;
          switch (num5 == num6 ? 1 : 0)
          {
            case 0:
            case 2:
label_21:
              enumerator.Dispose();
              num4 = (short) 0;
              num7 = (int) (IntPtr) num4;
              break;
            default:
              num4 = (short) 0;
              if (num4 == (short) 0)
                ;
              num4 = (short) 2;
              num7 = (int) (IntPtr) num4;
              break;
          }
          while (true)
          {
            switch (num7)
            {
              case 0:
                goto label_22;
              case 1:
                goto label_21;
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
            if (enumerator != null)
            {
              num4 = (short) 1;
              num7 = (int) (IntPtr) num4;
            }
            else
              break;
          }
label_22:;
        }
label_23:
        num1 = (short) 0;
        return num2;
    }
  }
}
