// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.CxfFilePassword.Helpers.CmpToRawPartitionsConversionHelper
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using Motorola.Common.Communication.CommonUtil;
using SpecialFeatures.AcpReportManagerLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#nullable disable
namespace SpecialFeatures.CxfFilePassword.Helpers;

internal static class CmpToRawPartitionsConversionHelper
{
  private const int a = 900;

  internal static Dictionary<int, byte[]> ConvertIshItemCollectionToRawPartitions(
    IshItemCollection codeplug)
  {
    short num1 = 0;
    num1 = (short) 0;
    switch (num1)
    {
      default:
        Dictionary<int, byte[]> rawPartitions = new Dictionary<int, byte[]>();
        List<byte> byteList = new List<byte>();
        IEnumerator<IGrouping<byte, KeyValuePair<IshHeader, IshItem>>> enumerator1 = ((IEnumerable<KeyValuePair<IshHeader, IshItem>>) codeplug).GroupBy<KeyValuePair<IshHeader, IshItem>, byte>((Func<KeyValuePair<IshHeader, IshItem>, byte>) (x =>
        {
          short num2 = 4281;
          int num3 = (int) num2;
          num2 = (short) 4281;
          int num4 = (int) num2;
          short num5;
          switch (num3 == num4)
          {
            case true:
              num5 = (short) 0;
              if (num5 == (short) 0)
                ;
              num5 = (short) 1;
              if (num5 == (short) 0)
                ;
              IshHeader key = x.Key;
              return ((IshHeader) ref key).PartitionNumber;
            default:
              num5 = (short) 0;
              goto case 1;
          }
        })).GetEnumerator();
        try
        {
          num1 = (short) 2;
          int num6 = (int) (IntPtr) num1;
          while (true)
          {
            int key1;
            IEnumerator<KeyValuePair<IshHeader, IshItem>> enumerator2;
            switch (num6)
            {
              case 0:
                if (enumerator1.MoveNext())
                {
                  IGrouping<byte, KeyValuePair<IshHeader, IshItem>> current = enumerator1.Current;
                  key1 = CmpToRawPartitionsConversionHelper.a(current.Key);
                  enumerator2 = current.GetEnumerator();
                  num1 = (short) 1;
                  num6 = (int) (IntPtr) num1;
                  continue;
                }
                num1 = (short) 4;
                num6 = (int) (IntPtr) num1;
                continue;
              case 1:
                try
                {
                  num1 = (short) 1;
                  int num7 = (int) (IntPtr) num1;
                  while (true)
                  {
                    switch (num7)
                    {
                      case 0:
                        if (!enumerator2.MoveNext())
                        {
                          num1 = (short) 2;
                          num7 = (int) (IntPtr) num1;
                          continue;
                        }
                        KeyValuePair<IshHeader, IshItem> current = enumerator2.Current;
                        IshHeader key2 = current.Key;
                        IshItem ishItem = current.Value;
                        byteList.Add((byte) ((uint) ((IshHeader) ref key2).IshType >> 8));
                        byteList.Add((byte) ((IshHeader) ref key2).IshType);
                        byteList.Add((byte) ((uint) ((IshHeader) ref key2).IshID >> 8));
                        byteList.Add((byte) ((IshHeader) ref key2).IshID);
                        byteList.Add((byte) (((IshItem) ref ishItem).Data.Length >> 8));
                        byteList.Add((byte) ((IshItem) ref ishItem).Data.Length);
                        byteList.AddRange((IEnumerable<byte>) ((IshItem) ref ishItem).Data);
                        num1 = (short) 3;
                        num7 = (int) (IntPtr) num1;
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
                        num1 = (short) 4;
                        num7 = (int) (IntPtr) num1;
                        continue;
                      case 4:
                        goto label_6;
                    }
                    num1 = (short) 0;
                    num7 = (int) (IntPtr) num1;
                  }
                }
                finally
                {
                  int num8 = 0;
                  while (true)
                  {
                    short num9;
                    switch (num8)
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
                        enumerator2.Dispose();
                        num9 = (short) 2;
                        num8 = (int) (IntPtr) num9;
                        continue;
                      case 2:
                        goto label_26;
                    }
                    if (enumerator2 != null)
                    {
                      num9 = (short) 1;
                      num8 = (int) (IntPtr) num9;
                    }
                    else
                      break;
                  }
label_26:;
                }
label_6:
                num1 = (short) -7560;
                int num10 = (int) num1;
                num1 = (short) -7560;
                int num11 = (int) num1;
                switch (num10 == num11 ? 1 : 0)
                {
                  case 0:
                  case 2:
                    break;
                  default:
                    num1 = (short) 0;
                    if (num1 == (short) 0)
                      ;
                    rawPartitions.Add(key1, byteList.ToArray());
                    byteList.Clear();
                    num1 = (short) 3;
                    num6 = (int) (IntPtr) num1;
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
              case 4:
                num1 = (short) 5;
                num6 = (int) (IntPtr) num1;
                continue;
              case 5:
                goto label_36;
            }
            num1 = (short) 0;
            num6 = (int) (IntPtr) num1;
          }
        }
        finally
        {
          short num12 = 0;
          int num13 = (int) (IntPtr) num12;
          while (true)
          {
            switch (num13)
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
                enumerator1.Dispose();
                num12 = (short) 2;
                num13 = (int) (IntPtr) num12;
                continue;
              case 2:
                goto label_34;
            }
            if (enumerator1 != null)
            {
              num12 = (short) 1;
              num13 = (int) (IntPtr) num12;
            }
            else
              goto label_35;
          }
label_34:
          num12 = (short) 1;
          if (num12 == (short) 0)
            ;
label_35:;
        }
label_36:
        return rawPartitions;
    }
  }

  internal static string GetModelNumber(IshItemCollection codeplug)
  {
    string modelNumber;
    try
    {
      short num1 = -18433;
      int num2 = (int) num1;
      num1 = (short) -18433;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          if (true)
            ;
          IshItem ishItem = codeplug[(byte) 212, (ushort) 900, (ushort) 0];
          modelNumber = Encoding.BigEndianUnicode.GetString(((IshItem) ref ishItem).Data, 23, 34).TrimEnd(new char[1]);
          break;
        default:
          goto case 1;
      }
    }
    catch (KeyNotFoundException ex)
    {
      modelNumber = string.Empty;
    }
    short num = 0;
    num = (short) 1;
    if (num == (short) 0)
      ;
    return modelNumber;
  }

  private static int a(byte A_0)
  {
    int A_1 = 13;
    int num1 = 2;
    short num2;
    int num3;
    while (true)
    {
      switch (num1)
      {
        case 0:
        case 3:
        case 5:
          goto label_15;
        case 1:
          num2 = (short) 4;
          num1 = (int) (IntPtr) num2;
          continue;
        case 2:
          num2 = (short) 1;
          if (num2 == (short) 0)
            ;
          switch (0)
          {
            case 0:
              break;
            default:
              continue;
          }
          break;
        case 4:
          goto label_12;
      }
      switch (A_0)
      {
        case 208 /*0xD0*/:
          num3 = 0;
          num2 = (short) 5;
          num1 = (int) (IntPtr) num2;
          continue;
        case 209:
        case 211:
          goto label_13;
        case 210:
          num3 = 1;
          break;
        case 212:
          num3 = 2;
          num2 = (short) 3;
          num1 = (int) (IntPtr) num2;
          continue;
        default:
          num2 = (short) 31542;
          int num4 = (int) num2;
          num2 = (short) 31542;
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
              num1 = (int) (IntPtr) num2;
              continue;
          }
          break;
      }
      num2 = (short) 0;
      num1 = (int) (IntPtr) num2;
    }
label_12:
    num2 = (short) 0;
label_13:
    throw new InvalidOperationException(string.Format(RptMgrErrorHandler.b("삏\uF391\uE693\uE295\uF197\uEE99\uF59B\uF19D캟芡킣\uDFA5\uD8A7쾩貫覭쮯花즳醵颷펹쾻麽꺿귁냃\uE6C5뫇꿉꿋ꇍ럏병뷓곕뷗뻙\uFDDB", A_1), (object) A_0));
label_15:
    return num3;
  }
}
