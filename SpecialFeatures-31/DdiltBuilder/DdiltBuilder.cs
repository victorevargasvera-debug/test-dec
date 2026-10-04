// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.DdiltBuilder.DdiltBuilder
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using SpecialFeatures.AcpReportManagerLib;
using System;
using System.Collections.Generic;

#nullable disable
namespace SpecialFeatures.DdiltBuilder;

public class DdiltBuilder
{
  private const uint a = 1375928576;
  private const uint b = 1129530456;
  private const uint c = 16384 /*0x4000*/;
  private const uint d = 4294967295 /*0xFFFFFFFF*/;
  private const ushort e = 65535 /*0xFFFF*/;
  private const uint f = 1129334616;
  private const uint g = 1430473816;
  private const uint h = 1397048152;
  private const ushort i = 208 /*0xD0*/;
  private const ushort j = 212;
  private const ushort k = 210;
  private const uint l = 4;
  private const uint m = 20;
  private const ushort n = 3762;
  private const ushort o = 999;
  private const ushort p = 10;
  private const ushort q = 2000;

  public byte[] DdiltBuild(ushort[] IshType, ushort[] UclLifeTimeMax)
  {
    int A_1 = 13;
    switch (0)
    {
      default:
        int num1 = 16 /*0x10*/;
        short num2;
        DdiltContainer ddiltContainer;
        byte[] numArray1;
        while (true)
        {
          int index1;
          ushort[] numArray2;
          int index2;
          ushort num3;
          ushort num4;
          ushort key1;
          ushort num5;
          DdiltGroup ddiltGroup;
          ushort num6;
          int index3;
          ushort num7;
          ushort num8;
          switch (num1)
          {
            case 0:
              num2 = (short) 26;
              num1 = (int) (IntPtr) num2;
              continue;
            case 1:
            case 13:
            case 31 /*0x1F*/:
              index2 += 2;
              num2 = (short) 24;
              num1 = (int) (IntPtr) num2;
              continue;
            case 2:
            case 22:
              num2 = (short) 6;
              num1 = (int) (IntPtr) num2;
              continue;
            case 3:
              if (index2 >= (int) num3 + (int) num4 * 2)
              {
                num2 = (short) 33;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              key1 = IshType[index2];
              num5 = IshType[index2 + 1];
              num2 = (short) 27;
              num1 = (int) (IntPtr) num2;
              continue;
            case 4:
              ddiltGroup.MultiInstanceEntries[key1] += num5;
              num2 = (short) 13;
              num1 = (int) (IntPtr) num2;
              continue;
            case 5:
              goto label_57;
            case 6:
              if (index3 >= IshType.Length)
              {
                num2 = (short) 5;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              ushort num9 = IshType[index3];
              num4 = IshType[index3 + 1];
              num3 = (ushort) (index3 + 2);
              ddiltGroup = new DdiltGroup();
              ddiltGroup.PartitionNum = num9;
              ddiltGroup.MultiInstanceEntries = new SortedDictionary<ushort, ushort>((IComparer<ushort>) new DDILTComparer());
              ddiltGroup.FirstSingleInstance = num7;
              num8 = (ushort) 0;
              index2 = (int) num3;
              num2 = (short) 21;
              num1 = (int) (IntPtr) num2;
              continue;
            case 7:
              if (ddiltGroup.PartitionNum != (ushort) 208 /*0xD0*/)
              {
                num2 = (short) 15;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              num2 = (short) 19;
              num1 = (int) (IntPtr) num2;
              continue;
            case 8:
            case 17:
              num2 = (short) 23;
              num1 = (int) (IntPtr) num2;
              continue;
            case 9:
              if ((int) key1 < (int) ddiltGroup.FirstSingleInstance)
              {
                num2 = (short) 30;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 1;
            case 10:
              num2 = (short) 9;
              num1 = (int) (IntPtr) num2;
              continue;
            case 11:
              ddiltGroup.MultiInstanceEntries.Add((ushort) 999, (ushort) 10);
              ddiltGroup.NumberTableEntries = (ushort) (ddiltGroup.MultiInstanceEntries.Count + 1);
              ddiltContainer.SecGroup = ddiltGroup;
              num2 = (short) 29;
              num1 = (int) (IntPtr) num2;
              continue;
            case 12:
              if (IshType != null)
              {
                num7 = (ushort) 14745;
                numArray1 = new byte[16384 /*0x4000*/];
                ddiltContainer = new DdiltContainer();
                ddiltContainer.LifeTimeMax = UclLifeTimeMax;
                ddiltContainer.MagicNumber = 1129530456U;
                ddiltContainer.Reserved = uint.MaxValue;
                ddiltContainer.ChecksumRange = 16384U /*0x4000*/;
                ddiltContainer.VersionNumber = 1375928576U;
                ddiltContainer.CodeplugGroupID = 1129334616U;
                ddiltContainer.UclGroupID = 1430473816U;
                ddiltContainer.SecGroupID = 1397048152U;
                index3 = 0;
                num2 = (short) 22;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              num2 = (short) 34;
              num1 = (int) (IntPtr) num2;
              continue;
            case 14:
            case 29:
              index3 = (int) num3 + (int) num4 * 2;
              num2 = (short) 2;
              num1 = (int) (IntPtr) num2;
              continue;
            case 15:
              if (ddiltGroup.PartitionNum != (ushort) 210)
              {
                num2 = (short) 0;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 14;
            case 16 /*0x10*/:
              switch (0)
              {
                case 0:
                  break;
                default:
                  continue;
              }
              break;
            case 18:
              goto label_33;
            case 19:
              num6 = (ushort) 2001;
              numArray2 = new ushort[8]
              {
                (ushort) 3974,
                (ushort) 3973,
                (ushort) 3972,
                (ushort) 3971,
                (ushort) 3970,
                (ushort) 3969,
                (ushort) 3968,
                (ushort) 3967
              };
              index1 = 0;
              num2 = (short) 8;
              num1 = (int) (IntPtr) num2;
              continue;
            case 20:
              if ((int) key1 > (int) ddiltGroup.LastSingleInstance)
              {
                num2 = (short) 32 /*0x20*/;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 10;
            case 21:
            case 24:
              num2 = (short) 3;
              num1 = (int) (IntPtr) num2;
              continue;
            case 23:
              num2 = (short) 1;
              if (num2 == (short) 0)
                ;
              if (index1 >= numArray2.Length)
              {
                num2 = (short) 28;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              ushort key2 = numArray2[index1];
              ddiltGroup.MultiInstanceEntries[key2] = num6;
              ++index1;
              num2 = (short) 17;
              num1 = (int) (IntPtr) num2;
              continue;
            case 25:
              if (ddiltGroup.MultiInstanceEntries.TryGetValue(key1, out num8))
              {
                num2 = (short) 4;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              ddiltGroup.MultiInstanceEntries.Add(key1, num5);
              num2 = (short) 1;
              num1 = (int) (IntPtr) num2;
              continue;
            case 26:
              if (ddiltGroup.PartitionNum == (ushort) 212)
              {
                num2 = (short) -4778;
                int num10 = (int) num2;
                num2 = (short) -4778;
                int num11 = (int) num2;
                switch (num10 == num11 ? 1 : 0)
                {
                  case 0:
                  case 2:
                    goto label_25;
                  default:
                    num2 = (short) 0;
                    if (num2 == (short) 0)
                      ;
                    num2 = (short) 11;
                    num1 = (int) (IntPtr) num2;
                    continue;
                }
              }
              else
                goto label_54;
            case 27:
              if (key1 < (ushort) 2000)
              {
                num2 = (short) 35;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              num2 = (short) 25;
              num1 = (int) (IntPtr) num2;
              continue;
            case 28:
              ddiltGroup.MultiInstanceEntries.Add((ushort) 3762, (ushort) 10);
              ddiltGroup.NumberTableEntries = (ushort) (ddiltGroup.MultiInstanceEntries.Count + 1);
              ddiltContainer.CodePlugGroup = ddiltGroup;
              num2 = (short) 14;
              num1 = (int) (IntPtr) num2;
              continue;
            case 30:
              ddiltGroup.FirstSingleInstance = key1;
              num2 = (short) 31 /*0x1F*/;
              num1 = (int) (IntPtr) num2;
              continue;
            case 32 /*0x20*/:
              ddiltGroup.LastSingleInstance = key1;
              num2 = (short) 10;
              num1 = (int) (IntPtr) num2;
              continue;
            case 33:
              ddiltGroup.Reserved = ushort.MaxValue;
              num2 = (short) 7;
              num1 = (int) (IntPtr) num2;
              continue;
            case 34:
              goto label_21;
            case 35:
label_25:
              num2 = (short) 20;
              num1 = (int) (IntPtr) num2;
              continue;
          }
          if (UclLifeTimeMax == null)
          {
            num2 = (short) 18;
            num1 = (int) (IntPtr) num2;
          }
          else
          {
            num2 = (short) 12;
            num1 = (int) (IntPtr) num2;
          }
        }
label_21:
        num2 = (short) 0;
        throw new ArgumentNullException(RptMgrErrorHandler.b("\uD98F\uE191ﲓ슕\uE197\uEA99鍊", A_1));
label_33:
        throw new ArgumentNullException(RptMgrErrorHandler.b("얏\uF191\uF893\uDA95\uF197ﲙ鍊쪝즟쾡솣\uEBA5즧튩", A_1));
label_54:
        throw new ArgumentOutOfRangeException(RptMgrErrorHandler.b("\uD98Fﲑ\uE293\uF795\uF497\uF399\uF89B뺝\uF09F쎡횣튥솧\uDEA9얫솭\uDEAF銱荒쎵햷\uD8B9\uD9BB첽", A_1));
label_57:
        ddiltContainer.VectorCount = 3U;
        ddiltContainer.CodeplugGroupVector = 48U /*0x30*/;
        ddiltContainer.UclGroupVector = (uint) ((int) ddiltContainer.CodeplugGroupVector + 4 + (int) ddiltContainer.CodePlugGroup.NumberTableEntries * 4);
        ddiltContainer.SecGroupVector = (uint) ((int) ddiltContainer.UclGroupVector + 4 + (ddiltContainer.LifeTimeMax.Length + 2) * 2);
        ddiltContainer.Checksum = 0U;
        byte[] bytes = ddiltContainer.ConvertToBytes();
        uint A_2;
        uint A_3;
        SpecialFeatures.DdiltBuilder.DdiltBuilder.a(bytes, numArray1, out A_2, out A_3);
        uint num12 = this.a(numArray1, A_2, A_3);
        bytes[20] = (byte) (num12 >> 24);
        bytes[21] = (byte) (num12 >> 16 /*0x10*/);
        bytes[22] = (byte) (num12 >> 8);
        bytes[23] = (byte) num12;
        return bytes;
    }
  }

  private static void a(byte[] A_0, byte[] A_1, out uint A_2, out uint A_3)
  {
    int A_1_1 = 16 /*0x10*/;
    int num1 = 5;
    short num2;
    while (true)
    {
      int index;
      switch (num1)
      {
        case 0:
          goto label_27;
        case 1:
          if (A_0.Length < 15)
          {
            num2 = (short) 3;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          A_2 = 8U;
          A_3 = (uint) A_1.Length;
          index = 0;
          num2 = (short) 16 /*0x10*/;
          num1 = (int) (IntPtr) num2;
          continue;
        case 2:
          num2 = (short) 4;
          num1 = (int) (IntPtr) num2;
          continue;
        case 3:
          goto label_34;
        case 4:
          if (index >= 24)
          {
            num2 = (short) 20;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto case 13;
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
          if (index >= 24)
          {
            num2 = (short) 7;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto case 13;
        case 7:
          A_1[index - 4] = A_0[index];
          num2 = (short) 19;
          num1 = (int) (IntPtr) num2;
          continue;
        case 8:
          if (A_0 != null)
          {
            num2 = (short) 1;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          num2 = (short) 0;
          num1 = (int) (IntPtr) num2;
          continue;
        case 9:
        case 16 /*0x10*/:
          num2 = (short) 17;
          num1 = (int) (IntPtr) num2;
          continue;
        case 10:
          num2 = (short) 1;
          if (num2 == (short) 0)
            ;
          num2 = (short) 0;
          goto case 13;
        case 11:
          A_1[index] = A_0[index];
          num2 = (short) 13;
          num1 = (int) (IntPtr) num2;
          continue;
        case 12:
          num2 = (short) -2190;
          int num3 = (int) num2;
          num2 = (short) -2190;
          int num4 = (int) num2;
          switch (num3 == num4 ? 1 : 0)
          {
            case 0:
            case 2:
              goto label_24;
            default:
              goto label_40;
          }
        case 13:
        case 19:
          ++index;
          num2 = (short) 9;
          num1 = (int) (IntPtr) num2;
          continue;
        case 14:
          if (index < A_0.Length)
          {
            num2 = (short) 22;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          num2 = (short) 21;
          num1 = (int) (IntPtr) num2;
          continue;
        case 15:
          goto label_33;
        case 17:
          if ((long) index >= (long) (A_3 + 4U))
          {
            num2 = (short) 12;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          num2 = (short) 14;
          num1 = (int) (IntPtr) num2;
          continue;
        case 18:
          if (index >= 20)
          {
            num2 = (short) 2;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto case 20;
        case 20:
          num2 = (short) 6;
          num1 = (int) (IntPtr) num2;
          continue;
        case 21:
label_24:
          A_1[index - 4] = byte.MaxValue;
          num2 = (short) 10;
          num1 = (int) (IntPtr) num2;
          continue;
        case 22:
          if (index < 20)
          {
            num2 = (short) 11;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          num2 = (short) 18;
          num1 = (int) (IntPtr) num2;
          continue;
      }
      if (A_1 == null)
      {
        num2 = (short) 15;
        num1 = (int) (IntPtr) num2;
      }
      else
      {
        num2 = (short) 8;
        num1 = (int) (IntPtr) num2;
      }
    }
label_27:
    throw new ArgumentNullException(RptMgrErrorHandler.b("ﶒ톔\uF396\uF098\uF79A\uE99C튞튠쒢", A_1_1));
label_33:
    throw new ArgumentNullException(RptMgrErrorHandler.b("힒\uF194ﺖ\uF598\uEF9A출ﺞ펠힢", A_1_1));
label_34:
    throw new ArgumentOutOfRangeException(RptMgrErrorHandler.b("ﶒ톔\uF396\uF098\uF79A\uE99C튞튠쒢", A_1_1));
label_40:
    num2 = (short) 0;
    if (num2 == (short) 0)
      ;
    A_3 -= A_2;
  }

  private uint a(byte[] A_0, uint A_1, uint A_2)
  {
    int A_1_1 = 8;
    int num1 = 0;
    switch (num1)
    {
      default:
        uint num2;
        short num3;
        uint num4;
        switch (0)
        {
          case 0:
label_3:
            num2 = 0U;
            num3 = (short) -7616;
            int num5 = (int) num3;
            num3 = (short) -7616;
            int num6 = (int) num3;
            switch (num5 == num6 ? 1 : 0)
            {
              case 0:
              case 2:
                break;
              default:
                num3 = (short) 0;
                if (num3 == (short) 0)
                  ;
                num3 = (short) 5;
                num1 = (int) (IntPtr) num3;
                goto label_2;
            }
            break;
          default:
            while (true)
            {
              uint index;
              uint num7;
              switch (num1)
              {
                case 0:
                  num3 = (short) 1;
                  if (num3 == (short) 0)
                    ;
                  if (uint.MaxValue - num2 >= num4)
                  {
                    num2 += num4;
                    num3 = (short) 15;
                    num1 = (int) (IntPtr) num3;
                    continue;
                  }
                  num3 = (short) 4;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 1:
                  if (index >= num7)
                  {
                    num3 = (short) 2;
                    num1 = (int) (IntPtr) num3;
                    continue;
                  }
                  num4 = (uint) A_0[(int) index];
                  num3 = (short) 6;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 2:
                  goto label_22;
                case 3:
                case 15:
                  goto label_29;
                case 4:
                  num3 = (short) 0;
                  num2 = num4 - (uint) (-1 - (int) num2 + 1);
                  num3 = (short) 3;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 5:
                  if (A_0 == null)
                  {
                    num3 = (short) 8;
                    num1 = (int) (IntPtr) num3;
                    continue;
                  }
                  num3 = (short) 9;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 6:
                  if (uint.MaxValue - num2 >= num4)
                  {
                    num2 += num4;
                    num3 = (short) 13;
                    num1 = (int) (IntPtr) num3;
                    continue;
                  }
                  num3 = (short) 12;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 7:
                case 14:
                  num3 = (short) 1;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 8:
                  goto label_21;
                case 9:
                  if ((long) A_2 > (long) A_0.Length - (long) A_1)
                  {
                    num3 = (short) 10;
                    num1 = (int) (IntPtr) num3;
                    continue;
                  }
                  num7 = A_1 + A_2;
                  index = A_1;
                  num3 = (short) 14;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 10:
                  goto label_12;
                case 11:
                case 13:
                  ++index;
                  num3 = (short) 7;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 12:
                  num2 = num4 - (uint) (-1 - (int) num2 + 1);
                  num3 = (short) 11;
                  num1 = (int) (IntPtr) num3;
                  continue;
                default:
                  goto label_3;
              }
label_2:;
            }
label_12:
            throw new ArgumentOutOfRangeException(RptMgrErrorHandler.b("\uE98A\uF88C\uE98E\uF790\uF692\uE794", A_1_1), RptMgrErrorHandler.b("ﮊ\uEC8Cﲎ\uE290뎒\uE194ﾖﲘ뮚ﾜ\uEA9E잠얢삤햦覨캪쎬쮮", A_1_1));
label_21:
            throw new ArgumentNullException(RptMgrErrorHandler.b("\uE98A\uF88C\uE98E\uF790\uF692\uE794", A_1_1));
label_29:
            return (uint) (-1 - (int) num2 + 1);
        }
label_22:
        num4 = 1020U;
        num3 = (short) 0;
        num1 = (int) (IntPtr) num3;
        goto label_2;
    }
  }
}
