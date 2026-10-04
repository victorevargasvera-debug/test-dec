// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.Comms.CodeplugFormatConverter
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using Motorola.Common.Communication.CommonUtil;
using SpecialFeatures.AcpReportManagerLib;
using System;
using System.Collections.Generic;
using System.IO;

#nullable disable
namespace SpecialFeatures.Comms;

public class CodeplugFormatConverter
{
  private const int a = 6;
  private byte[] b;

  public CodeplugFormatConverter() => this.b = new byte[2];

  internal Dictionary<int, MemoryStream> Convert(IshItemCollection collection)
  {
    int A_1 = 3;
    switch (0)
    {
      default:
        short num1 = 0;
        int num2 = (int) (IntPtr) num1;
        byte key1;
        Dictionary<int, int> dictionary1;
        Dictionary<int, MemoryStream> dictionary2;
        IEnumerator<KeyValuePair<IshHeader, IshItem>> enumerator;
        while (true)
        {
          switch (num2)
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
              goto label_8;
            case 2:
              goto label_7;
          }
          num1 = (short) 1;
          if (num1 == (short) 0)
            ;
          if (collection == null)
          {
            num1 = (short) 2;
            num2 = (int) (IntPtr) num1;
          }
          else
          {
            dictionary1 = this.a(collection);
            dictionary2 = new Dictionary<int, MemoryStream>();
            key1 = (byte) 0;
            enumerator = collection.GetEnumerator();
            num1 = (short) 1;
            num2 = (int) (IntPtr) num1;
          }
        }
label_7:
        num1 = (short) 0;
        throw new ArgumentNullException(RptMgrErrorHandler.b("\uE585\uE787\uE689\uE08B\uEB8D\uF38F\uE691ﶓ秊\uF697", A_1));
label_8:
        try
        {
          num1 = (short) 14;
          int num3 = (int) (IntPtr) num1;
          while (true)
          {
            num1 = (short) -11197;
            int num4 = (int) num1;
            num1 = (short) -11197;
            int num5 = (int) num1;
            switch (num4 == num5 ? 1 : 0)
            {
              case 0:
              case 2:
                goto label_42;
              default:
                num1 = (short) 0;
                if (num1 == (short) 0)
                  ;
                KeyValuePair<IshHeader, IshItem> current;
                IshHeader key2;
                MemoryStream memoryStream1;
                switch (num3)
                {
                  case 0:
                  case 1:
                  case 13:
                    num1 = (short) 16 /*0x10*/;
                    num3 = (int) (IntPtr) num1;
                    continue;
                  case 2:
                    byte[] b1 = this.b;
                    key2 = current.Key;
                    int num6 = (int) (byte) ((uint) ((IshHeader) ref key2).IshType >> 8);
                    b1[0] = (byte) num6;
                    byte[] b2 = this.b;
                    key2 = current.Key;
                    int ishType = (int) (byte) ((IshHeader) ref key2).IshType;
                    b2[1] = (byte) ishType;
                    memoryStream1.Write(this.b, 0, 2);
                    byte[] b3 = this.b;
                    key2 = current.Key;
                    int num7 = (int) (byte) ((uint) ((IshHeader) ref key2).IshID >> 8);
                    b3[0] = (byte) num7;
                    byte[] b4 = this.b;
                    key2 = current.Key;
                    int ishId = (int) (byte) ((IshHeader) ref key2).IshID;
                    b4[1] = (byte) ishId;
                    memoryStream1.Write(this.b, 0, 2);
                    byte[] b5 = this.b;
                    IshItem ishItem = current.Value;
                    int num8 = (int) (byte) ((uint) (ushort) ((IshItem) ref ishItem).Data.Length >> 8);
                    b5[0] = (byte) num8;
                    byte[] b6 = this.b;
                    ishItem = current.Value;
                    int length1 = (int) (byte) (ushort) ((IshItem) ref ishItem).Data.Length;
                    b6[1] = (byte) length1;
                    memoryStream1.Write(this.b, 0, 2);
                    MemoryStream memoryStream2 = memoryStream1;
                    ishItem = current.Value;
                    byte[] data = ((IshItem) ref ishItem).Data;
                    ishItem = current.Value;
                    int length2 = ((IshItem) ref ishItem).Data.Length;
                    memoryStream2.Write(data, 0, length2);
                    num1 = (short) 4;
                    num3 = (int) (IntPtr) num1;
                    continue;
                  case 3:
                    key1 = (byte) 0;
                    num1 = (short) 13;
                    num3 = (int) (IntPtr) num1;
                    continue;
                  case 5:
                    if (((IshHeader) ref key2).PartitionNumber == (byte) 210)
                    {
                      num1 = (short) 10;
                      num3 = (int) (IntPtr) num1;
                      continue;
                    }
                    key2 = current.Key;
                    num1 = (short) 9;
                    num3 = (int) (IntPtr) num1;
                    continue;
                  case 6:
                    key1 = (byte) 2;
                    num1 = (short) 1;
                    num3 = (int) (IntPtr) num1;
                    continue;
                  case 7:
                    if (!enumerator.MoveNext())
                    {
                      num1 = (short) 8;
                      num3 = (int) (IntPtr) num1;
                      continue;
                    }
                    current = enumerator.Current;
                    key2 = current.Key;
                    num1 = (short) 15;
                    num3 = (int) (IntPtr) num1;
                    continue;
                  case 8:
                    num1 = (short) 12;
                    num3 = (int) (IntPtr) num1;
                    continue;
                  case 9:
                    if (((IshHeader) ref key2).PartitionNumber == (byte) 212)
                    {
                      num1 = (short) 6;
                      num3 = (int) (IntPtr) num1;
                      continue;
                    }
                    goto case 0;
                  case 10:
                    key1 = (byte) 1;
                    num1 = (short) 0;
                    num3 = (int) (IntPtr) num1;
                    continue;
                  case 11:
                    Dictionary<int, int> dictionary3 = dictionary1;
                    key2 = current.Key;
                    int partitionNumber = (int) ((IshHeader) ref key2).PartitionNumber;
                    memoryStream1 = new MemoryStream(dictionary3[partitionNumber]);
                    dictionary2.Add((int) key1, memoryStream1);
                    num1 = (short) 2;
                    num3 = (int) (IntPtr) num1;
                    continue;
                  case 12:
                    goto label_42;
                  case 14:
                    switch (0)
                    {
                      case 0:
                        break;
                      default:
                        continue;
                    }
                    break;
                  case 15:
                    if (((IshHeader) ref key2).PartitionNumber != (byte) 208 /*0xD0*/)
                    {
                      key2 = current.Key;
                      num1 = (short) 5;
                      num3 = (int) (IntPtr) num1;
                      continue;
                    }
                    num1 = (short) 3;
                    num3 = (int) (IntPtr) num1;
                    continue;
                  case 16 /*0x10*/:
                    if (!dictionary2.TryGetValue((int) key1, out memoryStream1))
                    {
                      num1 = (short) 11;
                      num3 = (int) (IntPtr) num1;
                      continue;
                    }
                    goto case 2;
                }
                num1 = (short) 7;
                num3 = (int) (IntPtr) num1;
                continue;
            }
          }
        }
        finally
        {
          short num9 = 1;
          int num10 = (int) (IntPtr) num9;
          while (true)
          {
            switch (num10)
            {
              case 0:
                enumerator.Dispose();
                num9 = (short) 2;
                num10 = (int) (IntPtr) num9;
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
                goto label_40;
            }
            if (enumerator != null)
            {
              num9 = (short) 0;
              num10 = (int) (IntPtr) num9;
            }
            else
              break;
          }
label_40:;
        }
label_42:
        return dictionary2;
    }
  }

  internal IshItemCollection Convert(Dictionary<int, MemoryStream> codeplug)
  {
    int A_1 = 16 /*0x10*/;
    switch (0)
    {
      default:
        int num1 = 1;
        short num2;
        Dictionary<int, MemoryStream>.Enumerator enumerator;
        byte num3;
        IshItemCollection ishItemCollection;
        while (true)
        {
          switch (num1)
          {
            case 0:
              goto label_39;
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
              goto label_36;
          }
          if (codeplug == null)
          {
            num2 = (short) 0;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          ishItemCollection = new IshItemCollection();
          num3 = (byte) 0;
          enumerator = codeplug.GetEnumerator();
          num2 = (short) 2;
          num1 = (int) (IntPtr) num2;
          continue;
label_3:;
        }
label_36:
        num2 = (short) 4071;
        int num4 = (int) num2;
        num2 = (short) 4071;
        int num5 = (int) num2;
        switch (num4 == num5 ? 1 : 0)
        {
          case 0:
          case 2:
            goto label_3;
          default:
            num2 = (short) 0;
            if (num2 == (short) 0)
              ;
            num2 = (short) 0;
            num2 = (short) 1;
            if (num2 == (short) 0)
              ;
            try
            {
              num2 = (short) 11;
              int num6 = (int) (IntPtr) num2;
              while (true)
              {
                KeyValuePair<int, MemoryStream> current;
                ushort num7;
                ushort num8;
                byte[] buffer;
                switch (num6)
                {
                  case 0:
                    if (current.Key == 2)
                    {
                      num2 = (short) 9;
                      num6 = (int) (IntPtr) num2;
                      continue;
                    }
                    goto case 8;
                  case 1:
                    if (current.Key == 0)
                    {
                      num2 = (short) 2;
                      num6 = (int) (IntPtr) num2;
                      continue;
                    }
                    num2 = (short) 14;
                    num6 = (int) (IntPtr) num2;
                    continue;
                  case 2:
                    num3 = (byte) 208 /*0xD0*/;
                    num2 = (short) 17;
                    num6 = (int) (IntPtr) num2;
                    continue;
                  case 3:
                  case 18:
                    num2 = (short) 16 /*0x10*/;
                    num6 = (int) (IntPtr) num2;
                    continue;
                  case 4:
                    num3 = (byte) 210;
                    num2 = (short) 13;
                    num6 = (int) (IntPtr) num2;
                    continue;
                  case 5:
                    if (current.Value.Position != current.Value.Length)
                    {
                      num2 = (short) 12;
                      num6 = (int) (IntPtr) num2;
                      continue;
                    }
                    break;
                  case 6:
                    num2 = (short) 15;
                    num6 = (int) (IntPtr) num2;
                    continue;
                  case 7:
                    num2 = (short) 5;
                    num6 = (int) (IntPtr) num2;
                    continue;
                  case 8:
                  case 13:
                  case 17:
                    IshHeader ishHeader = new IshHeader(num3, num7, num8);
                    IshItem ishItem = new IshItem(buffer.Length, buffer, (SequenceManagerResult) 0);
                    ishItemCollection.Add(ishHeader, ishItem);
                    num2 = (short) 18;
                    num6 = (int) (IntPtr) num2;
                    continue;
                  case 9:
                    num3 = (byte) 212;
                    num2 = (short) 8;
                    num6 = (int) (IntPtr) num2;
                    continue;
                  case 10:
                    if (!enumerator.MoveNext())
                    {
                      num2 = (short) 6;
                      num6 = (int) (IntPtr) num2;
                      continue;
                    }
                    current = enumerator.Current;
                    num2 = (short) 3;
                    num6 = (int) (IntPtr) num2;
                    continue;
                  case 11:
                    switch (0)
                    {
                      case 0:
                        break;
                      default:
                        continue;
                    }
                    break;
                  case 12:
                    goto label_20;
                  case 14:
                    if (current.Key == 1)
                    {
                      num2 = (short) 4;
                      num6 = (int) (IntPtr) num2;
                      continue;
                    }
                    num2 = (short) 0;
                    num6 = (int) (IntPtr) num2;
                    continue;
                  case 15:
                    goto label_40;
                  case 16 /*0x10*/:
                    if (current.Value.Position < current.Value.Length)
                    {
                      num7 = this.a(current.Value);
                      num8 = this.a(current.Value);
                      buffer = new byte[(int) this.a(current.Value)];
                      current.Value.Read(buffer, 0, buffer.Length);
                      num2 = (short) 1;
                      num6 = (int) (IntPtr) num2;
                      continue;
                    }
                    num2 = (short) 7;
                    num6 = (int) (IntPtr) num2;
                    continue;
                }
                num2 = (short) 10;
                num6 = (int) (IntPtr) num2;
              }
label_20:
              throw new IOException(RptMgrErrorHandler.b("\uDA92ﮔ\uE196\uF898\uF79A\uF49Cﮞ膠쪢좤욦캨캪", A_1));
            }
            finally
            {
              enumerator.Dispose();
            }
label_40:
            return ishItemCollection;
        }
label_39:
        throw new ArgumentNullException(RptMgrErrorHandler.b("\uE792\uF494\uF596\uF598ﺚ", A_1));
    }
  }

  private ushort a(MemoryStream A_0)
  {
    int A_1 = 17;
label_1:
    short num1 = 0;
    if (A_0.Read(this.b, 0, 2) != 2)
    {
      num1 = (short) -31425;
      int num2 = (int) num1;
      num1 = (short) -31425;
      int num3 = (int) num1;
      switch (num2 == num3 ? 1 : 0)
      {
        case 0:
        case 2:
          goto label_1;
        default:
          num1 = (short) 1;
          if (num1 == (short) 0)
            ;
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          throw new IOException(RptMgrErrorHandler.b("톓\uF895ﲗ몙\uF39B\uF89D肟톡킣풥춧쮩솫躭슯ힱ햳햵킷\uDFB9\uD8BB", A_1));
      }
    }
    else
    {
      Array.Reverse((Array) this.b, 0, 2);
      return BitConverter.ToUInt16(this.b, 0);
    }
  }

  private Dictionary<int, int> a(IshItemCollection A_0)
  {
    switch (0)
    {
      default:
        Dictionary<int, int> dictionary1 = new Dictionary<int, int>();
        IEnumerator<KeyValuePair<IshHeader, IshItem>> enumerator = A_0.GetEnumerator();
        short num1;
        try
        {
          int num2 = 0;
          while (true)
          {
            KeyValuePair<IshHeader, IshItem> current;
            IshHeader key;
            IshItem ishItem;
            switch (num2)
            {
              case 0:
                num1 = (short) 14043;
                int num3 = (int) num1;
                num1 = (short) 14043;
                int num4 = (int) num1;
                switch (num3 == num4 ? 1 : 0)
                {
                  case 0:
                  case 2:
                    break;
                  default:
                    num1 = (short) 0;
                    if (num1 == (short) 0)
                      ;
                    switch (0)
                    {
                      case 0:
                        goto label_10;
                      default:
                        continue;
                    }
                }
                break;
              case 2:
                num1 = (short) 7;
                num2 = (int) (IntPtr) num1;
                continue;
              case 4:
                Dictionary<int, int> dictionary2 = dictionary1;
                key = current.Key;
                int partitionNumber1 = (int) ((IshHeader) ref key).PartitionNumber;
                ishItem = current.Value;
                int num5 = 6 + ((IshItem) ref ishItem).Data.Length;
                dictionary2.Add(partitionNumber1, num5);
                num1 = (short) 1;
                num2 = (int) (IntPtr) num1;
                continue;
              case 5:
                Dictionary<int, int> dictionary3 = dictionary1;
                key = current.Key;
                int partitionNumber2 = (int) ((IshHeader) ref key).PartitionNumber;
                int num6;
                ref int local = ref num6;
                if (!dictionary3.TryGetValue(partitionNumber2, out local))
                {
                  num1 = (short) 4;
                  num2 = (int) (IntPtr) num1;
                  continue;
                }
                int num7 = num6;
                ishItem = current.Value;
                int num8 = 6 + ((IshItem) ref ishItem).Data.Length;
                num6 = num7 + num8;
                Dictionary<int, int> dictionary4 = dictionary1;
                key = current.Key;
                int partitionNumber3 = (int) ((IshHeader) ref key).PartitionNumber;
                int num9 = num6;
                dictionary4[partitionNumber3] = num9;
                break;
              case 6:
                if (enumerator.MoveNext())
                {
                  current = enumerator.Current;
                  num1 = (short) 5;
                  num2 = (int) (IntPtr) num1;
                  continue;
                }
                num1 = (short) 2;
                num2 = (int) (IntPtr) num1;
                continue;
              case 7:
                goto label_24;
              default:
label_10:
                num1 = (short) 6;
                num2 = (int) (IntPtr) num1;
                continue;
            }
            num1 = (short) 3;
            num2 = (int) (IntPtr) num1;
          }
        }
        finally
        {
          int num10 = 1;
          while (true)
          {
            switch (num10)
            {
              case 0:
                enumerator.Dispose();
                num10 = 2;
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
                goto label_23;
            }
            if (enumerator != null)
              num10 = 0;
            else
              break;
          }
label_23:;
        }
label_24:
        num1 = (short) 0;
        num1 = (short) 1;
        if (num1 == (short) 0)
          ;
        return dictionary1;
    }
  }
}
