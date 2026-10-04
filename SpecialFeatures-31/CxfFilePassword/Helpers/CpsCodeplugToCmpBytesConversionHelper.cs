// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.CxfFilePassword.Helpers.CpsCodeplugToCmpBytesConversionHelper
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using Motorola.Acp.PackUnpack.Ish;
using Motorola.Common.Communication.CommonFile;
using Motorola.Common.Communication.CommonUtil;
using Motorola.Common.Communication.Pba;
using SpecialFeatures.AcpReportManagerLib;
using System;
using System.Collections.Generic;
using System.IO;

#nullable disable
namespace SpecialFeatures.CxfFilePassword.Helpers;

internal class CpsCodeplugToCmpBytesConversionHelper
{
  private const int a = 6;
  private static readonly CodeplugCommFileHeader b;

  private static int IshTypeHeaderOffset
  {
    get
    {
      short num1 = 24712;
      int num2 = (int) num1;
      num1 = (short) 24712;
      int num3 = (int) num1;
      short num4;
      switch (num2 == num3 ? 1 : 0)
      {
        case 0:
        case 2:
          return 0;
        case 1:
          num4 = (short) 1;
          if (num4 == (short) 0)
            ;
          num4 = (short) 0;
          if (num4 == (short) 0)
            ;
          if (BitConverter.IsLittleEndian)
            return 4;
          goto case 0;
        default:
          num4 = (short) 0;
          goto case 1;
      }
    }
  }

  private static int IshIdHeaderOffset
  {
    get
    {
      short num1 = -2925;
      int num2 = (int) num1;
      num1 = (short) -2925;
      int num3 = (int) num1;
      short num4;
      switch (num2 == num3)
      {
        case true:
          num4 = (short) 0;
          if (num4 == (short) 0)
            ;
          num4 = (short) 1;
          if (num4 == (short) 0)
            ;
          return 2;
        default:
          num4 = (short) 0;
          goto case 1;
      }
    }
  }

  private static int IshItemSizeHeaderOffset
  {
    get
    {
      short num1 = 154;
      int num2 = (int) num1;
      num1 = (short) 154;
      int num3 = (int) num1;
      short num4;
      switch (num2 == num3 ? 1 : 0)
      {
        case 0:
        case 2:
          return 4;
        case 1:
          num4 = (short) 1;
          if (num4 == (short) 0)
            ;
          num4 = (short) 0;
          if (num4 == (short) 0)
            ;
          if (BitConverter.IsLittleEndian)
            return 0;
          goto case 0;
        default:
          num4 = (short) 0;
          goto case 1;
      }
    }
  }

  public static byte[] ConvertCpsCodeplugToCmpBytes(Codeplug codeplug)
  {
    short num1 = -27909;
    int num2 = (int) num1;
    num1 = (short) -27909;
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
        PbaObject A_0 = new PbaObject();
        A_0.SetCodeplug(CpsCodeplugToCmpBytesConversionHelper.a(codeplug));
        return CpsCodeplugToCmpBytesConversionHelper.a(A_0);
      default:
        num4 = (short) 0;
        goto case 1;
    }
  }

  private static byte a(byte A_0)
  {
    int A_1 = 6;
    int num1 = 2;
    short num2;
    byte num3;
    while (true)
    {
      switch (num1)
      {
        case 0:
        case 3:
        case 5:
          goto label_14;
        case 1:
          num2 = (short) 4;
          num1 = (int) (IntPtr) num2;
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
        case 4:
          goto label_11;
      }
      switch (A_0)
      {
        case 0:
          num2 = (short) 1;
          if (num2 == (short) 0)
            ;
          num3 = (byte) 208 /*0xD0*/;
          num2 = (short) 5;
          num1 = (int) (IntPtr) num2;
          continue;
        case 1:
          num3 = (byte) 210;
          break;
        case 2:
          num3 = (byte) 212;
          num2 = (short) 3;
          num1 = (int) (IntPtr) num2;
          continue;
        default:
          num2 = (short) -22296;
          int num4 = (int) num2;
          num2 = (short) -22296;
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
label_11:
    num2 = (short) 0;
    throw new InvalidOperationException(string.Format(RptMgrErrorHandler.b("\uD988\uEA8Aﾌﮎ\uF890\uE792ﲔ\uF896\uF798뮚\uE99C\uE69E토욢薤肦튨鮪킬袮醰\uDAB2운鞶ힸ풺즼龾돀ꛂꛄ\uA8C6껈ꗊ\uA4CC뗎듐럒\uF4D4", A_1), (object) A_0));
label_14:
    return num3;
  }

  private static IshItemCollection a(Codeplug A_0)
  {
    int A_1 = 2;
    short num1 = 13080;
    int num2 = (int) num1;
    num1 = (short) 13080;
    int num3 = (int) num1;
    short num4;
    switch (num2 == num3 ? 1 : 0)
    {
      case 0:
      case 2:
label_4:
        IshItemCollection ishItemCollection = new IshItemCollection();
        byte[] buffer1 = new byte[6];
        IEnumerator<Partition> enumerator = A_0.Partitions.GetEnumerator();
        try
        {
          num4 = (short) 9;
          int num5 = (int) (IntPtr) num4;
          while (true)
          {
            ByteBufferStream image;
            Partition current;
            byte num6;
            ushort uint16_1;
            ushort uint16_2;
            short int16;
            byte[] buffer2;
            switch (num5)
            {
              case 0:
              case 1:
                num4 = (short) 6;
                num5 = (int) (IntPtr) num4;
                continue;
              case 2:
                Array.Reverse((Array) buffer1);
                num4 = (short) 8;
                num5 = (int) (IntPtr) num4;
                continue;
              case 3:
                if (((Stream) current.Image).Read(buffer2, 0, buffer2.Length) == (int) int16)
                {
                  IshHeader ishHeader;
                  // ISSUE: explicit constructor call
                  ((IshHeader) ref ishHeader).\u002Ector(num6, uint16_1, uint16_2);
                  IshItem ishItem;
                  // ISSUE: explicit constructor call
                  ((IshItem) ref ishItem).\u002Ector((int) int16, buffer2, (SequenceManagerResult) 135);
                  ishItemCollection.Add(ishHeader, ishItem);
                  num4 = (short) 1;
                  num5 = (int) (IntPtr) num4;
                  continue;
                }
                num4 = (short) 11;
                num5 = (int) (IntPtr) num4;
                continue;
              case 5:
                if (BitConverter.IsLittleEndian)
                {
                  num4 = (short) 2;
                  num5 = (int) (IntPtr) num4;
                  continue;
                }
                goto case 8;
              case 6:
                if (((Stream) image).Read(buffer1, 0, 6) != 0)
                {
                  num4 = (short) 5;
                  num5 = (int) (IntPtr) num4;
                  continue;
                }
                num4 = (short) 4;
                num5 = (int) (IntPtr) num4;
                continue;
              case 7:
                num4 = (short) 12;
                num5 = (int) (IntPtr) num4;
                continue;
              case 8:
                uint16_1 = BitConverter.ToUInt16(buffer1, CpsCodeplugToCmpBytesConversionHelper.IshTypeHeaderOffset);
                uint16_2 = BitConverter.ToUInt16(buffer1, CpsCodeplugToCmpBytesConversionHelper.IshIdHeaderOffset);
                int16 = BitConverter.ToInt16(buffer1, CpsCodeplugToCmpBytesConversionHelper.IshItemSizeHeaderOffset);
                buffer2 = new byte[(int) int16];
                num4 = (short) 3;
                num5 = (int) (IntPtr) num4;
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
              case 10:
                if (enumerator.MoveNext())
                {
                  current = enumerator.Current;
                  num6 = CpsCodeplugToCmpBytesConversionHelper.a((byte) current.PartitionType);
                  image = current.Image;
                  ((Stream) image).Position = 0L;
                  num4 = (short) 0;
                  num5 = (int) (IntPtr) num4;
                  continue;
                }
                num4 = (short) 7;
                num5 = (int) (IntPtr) num4;
                continue;
              case 11:
                goto label_23;
              case 12:
                goto label_32;
            }
            num4 = (short) 10;
            num5 = (int) (IntPtr) num4;
          }
label_23:
          throw new InvalidOperationException(RptMgrErrorHandler.b("힄\uE286\uE888\uEF8A권\uE68E\uE590\uF692\uF894랖ﶘ漢\uE99Cﺞ膠쪢횤螦\uDAA8욪첬쎮\uDDB0횲잴鞶춸펺\uDCBC톾\uE1C0\uA7C2ꃄꇆꃈꗊ\uA8CCꯎ\uF1D0뫒ꇔ닖듘ﯚ껜뛞鯠蛢쯤쟦꿨苪臬諮퇰髲蛴ퟶ铸髺釼駾渀焂栄戆洈┊ⴌ与猐簒朔挖瀘甚稜ㄞ༠ഢ", A_1));
        }
        finally
        {
          short num7 = 0;
          int num8 = (int) (IntPtr) num7;
          while (true)
          {
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
                enumerator.Dispose();
                num7 = (short) 2;
                num8 = (int) (IntPtr) num7;
                continue;
              case 2:
                goto label_31;
            }
            if (enumerator != null)
            {
              num7 = (short) 1;
              num8 = (int) (IntPtr) num7;
            }
            else
              break;
          }
label_31:;
        }
label_32:
        return ishItemCollection;
      default:
        if (true)
          ;
        if (false)
          ;
        num4 = (short) 0;
        switch (num4)
        {
          default:
            goto label_4;
        }
    }
  }

  private static byte[] a(PbaObject A_0)
  {
    short num1 = 28035;
    int num2 = (int) num1;
    num1 = (short) 28035;
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
        return new PartitionCommonFile(true).Serialize(CpsCodeplugToCmpBytesConversionHelper.b, A_0);
      default:
        num4 = (short) 0;
        goto case 1;
    }
  }

  static CpsCodeplugToCmpBytesConversionHelper()
  {
    short num1 = 9472;
    int num2 = (int) num1;
    num1 = (short) 9472;
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
        CpsCodeplugToCmpBytesConversionHelper.b = new CodeplugCommFileHeader()
        {
          HeaderVer = (byte) 16 /*0x10*/,
          FullDelta = (FullDeltaCodeplug) 0,
          Level = (InfoLevel) 4
        };
        break;
      default:
        num4 = (short) 0;
        goto case 1;
    }
  }
}
