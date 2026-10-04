// Decompiled with JetBrains decompiler
// Type: CommonSecurity
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using Motorola.Common.CustomException;
using SpecialFeatures.AcpReportManagerLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

#nullable disable
internal class CommonSecurity
{
  private const uint a = 1;
  private const uint b = 24;

  public static string ComputeHash(string input, byte[] salt = null, uint algorithm = 1)
  {
    int A_1 = 8;
    switch (0)
    {
      default:
        int num1 = 2;
        StringBuilder stringBuilder;
        while (true)
        {
          short num2;
          byte[] numArray;
          int index;
          byte[] bytes;
          switch (num1)
          {
            case 0:
              num2 = (short) 11;
              num1 = (int) (IntPtr) num2;
              continue;
            case 1:
              goto label_16;
            case 2:
              switch (0)
              {
                case 0:
                  goto label_4;
                default:
                  continue;
              }
            case 3:
              num2 = (short) 0;
              goto label_27;
            case 4:
              num2 = (short) 30140;
              int num3 = (int) num2;
              num2 = (short) 30140;
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
                  salt = CommonSecurity.a();
                  num2 = (short) 1;
                  if (num2 == (short) 0)
                    ;
                  num2 = (short) 3;
                  num1 = (int) (IntPtr) num2;
                  continue;
              }
              break;
            case 5:
              Array.Reverse((Array) bytes);
              num2 = (short) 0;
              num1 = (int) (IntPtr) num2;
              continue;
            case 6:
              stringBuilder = new StringBuilder();
              index = 0;
              num2 = (short) 14;
              num1 = (int) (IntPtr) num2;
              continue;
            case 7:
            case 14:
              num2 = (short) 8;
              num1 = (int) (IntPtr) num2;
              continue;
            case 8:
              if (index >= numArray.Length)
              {
                num2 = (short) 12;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              break;
            case 9:
              bytes = BitConverter.GetBytes(1U);
              num2 = (short) 13;
              num1 = (int) (IntPtr) num2;
              continue;
            case 10:
              if (algorithm == 1U)
              {
                num2 = (short) 9;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_6;
            case 11:
              if (salt == null)
              {
                num2 = (short) 4;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_27;
            case 12:
              goto label_29;
            case 13:
              if (BitConverter.IsLittleEndian)
              {
                num2 = (short) 5;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 0;
            default:
label_4:
              if (string.IsNullOrEmpty(input))
              {
                num2 = (short) 1;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              numArray = (byte[]) null;
              num2 = (short) 10;
              num1 = (int) (IntPtr) num2;
              continue;
          }
          stringBuilder.Append(numArray[index].ToString(RptMgrErrorHandler.b("펊뾌", A_1)));
          ++index;
          num2 = (short) 7;
          num1 = (int) (IntPtr) num2;
          continue;
label_27:
          byte[] second = CommonSecurity.a(input, salt);
          numArray = ((IEnumerable<byte>) bytes).Concat<byte>((IEnumerable<byte>) salt).Concat<byte>((IEnumerable<byte>) second).ToArray<byte>();
          num2 = (short) 6;
          num1 = (int) (IntPtr) num2;
        }
label_6:
        throw new CommonException((CommonErrorCode) 4);
label_16:
        throw new CommonException((CommonErrorCode) 2);
label_29:
        return stringBuilder.ToString();
    }
  }

  private static byte[] a(uint A_0 = 24)
  {
    byte[] data = new byte[(int) A_0];
    RNGCryptoServiceProvider cryptoServiceProvider = new RNGCryptoServiceProvider();
    try
    {
      cryptoServiceProvider.GetBytes(data);
    }
    finally
    {
      short num1;
      int num2;
      switch (true ? 1 : 0)
      {
        case 0:
        case 2:
label_6:
          switch (0)
          {
            case 0:
              goto label_8;
          }
          break;
        default:
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          num1 = (short) 1;
          if (num1 == (short) 0)
            ;
          num1 = (short) 0;
          num2 = (int) (IntPtr) num1;
          break;
      }
      while (true)
      {
        switch (num2)
        {
          case 0:
            goto label_6;
          case 1:
            goto label_11;
          case 2:
            cryptoServiceProvider.Dispose();
            num1 = (short) 1;
            num2 = (int) (IntPtr) num1;
            continue;
          default:
            goto label_8;
        }
label_7:;
      }
label_8:
      if (cryptoServiceProvider != null)
      {
        num1 = (short) 2;
        num2 = (int) (IntPtr) num1;
        goto label_7;
      }
label_11:;
    }
    return data;
  }

  private static byte[] a(string A_0, byte[] A_1)
  {
    short num1 = 0;
    byte[] array = ((IEnumerable<byte>) A_1).Concat<byte>((IEnumerable<byte>) Encoding.UTF8.GetBytes(A_0)).ToArray<byte>();
    byte[] numArray = (byte[]) null;
    SHA256 shA256 = SHA256.Create();
    try
    {
      numArray = shA256.ComputeHash(array);
    }
    finally
    {
      short num2 = -8222;
      int num3 = (int) num2;
      num2 = (short) -8222;
      int num4 = (int) num2;
      int num5;
      switch (num3 == num4 ? 1 : 0)
      {
        case 0:
        case 2:
label_5:
          switch (0)
          {
            case 0:
              goto label_7;
          }
          break;
        default:
          num2 = (short) 0;
          if (num2 == (short) 0)
            ;
          num2 = (short) 0;
          num5 = (int) (IntPtr) num2;
          break;
      }
      while (true)
      {
        switch (num5)
        {
          case 0:
            goto label_5;
          case 1:
            goto label_10;
          case 2:
            shA256.Dispose();
            num2 = (short) 1;
            num5 = (int) (IntPtr) num2;
            continue;
          default:
            goto label_7;
        }
label_6:;
      }
label_7:
      if (shA256 != null)
      {
        num2 = (short) 2;
        num5 = (int) (IntPtr) num2;
        goto label_6;
      }
label_10:;
    }
    num1 = (short) 1;
    if (num1 == (short) 0)
      ;
    return numArray;
  }

  private static string a(SHA256 A_0, string A_1)
  {
    int A_1_1 = 11;
    short num1 = -1165;
    int num2 = (int) num1;
    num1 = (short) -1165;
    int num3 = (int) num1;
    short num4;
    int num5;
    byte[] hash;
    StringBuilder stringBuilder;
    int index;
    switch (num2 == num3 ? 1 : 0)
    {
      case 0:
      case 2:
        while (true)
        {
          switch (num5)
          {
            case 0:
            case 1:
              num4 = (short) 3;
              num5 = (int) (IntPtr) num4;
              continue;
            case 2:
              goto label_10;
            case 3:
              if (index >= hash.Length)
              {
                num4 = (short) 2;
                num5 = (int) (IntPtr) num4;
                continue;
              }
              stringBuilder.Append(hash[index].ToString(RptMgrErrorHandler.b("\uF68Dꊏ", A_1_1)));
              ++index;
              num4 = (short) 1;
              num5 = (int) (IntPtr) num4;
              continue;
            default:
              goto label_5;
          }
label_4:;
        }
label_10:
        num4 = (short) 0;
        return stringBuilder.ToString();
      default:
        num4 = (short) 1;
        if (num4 == (short) 0)
          ;
        num4 = (short) 0;
        if (num4 == (short) 0)
          ;
        switch (0)
        {
          case 0:
            break;
          default:
            goto label_4;
        }
        break;
    }
label_5:
    hash = A_0.ComputeHash(Encoding.UTF8.GetBytes(A_1));
    stringBuilder = new StringBuilder();
    index = 0;
    num4 = (short) 0;
    num5 = (int) (IntPtr) num4;
    goto label_4;
  }

  private static string a(DateTime A_0, string A_1)
  {
    int A_1_1 = 11;
    int num1 = 0;
    switch (num1)
    {
      default:
        int day;
        string empty;
        string A_1_2;
        int num2;
        ASCIIEncoding asciiEncoding;
        byte[] bytes1;
        byte[] bytes2;
        int length1;
        short index1;
        short num3;
        switch (0)
        {
          case 0:
label_3:
            day = A_0.Day;
            int month = A_0.Month;
            int year = A_0.Year;
            string s = RptMgrErrorHandler.b("\uEF8D\uE58F힑ﮓﾕﺗﶙ\uEC9B첝즟잡솣\uEFA5슧\uD8A9쎫\uDEAD쪯莱욳\uE1B5ힷ躹覻趽\uF2BF蛁꿃뇅뫇뫉믋\uFDCD\uE2CF铑뿓뇕꣗뿙껛", A_1_1);
            empty = string.Empty;
            A_1_2 = string.Empty;
            num2 = day + month;
            asciiEncoding = new ASCIIEncoding();
            bytes1 = asciiEncoding.GetBytes(s);
            bytes2 = asciiEncoding.GetBytes(A_0.ToString(RptMgrErrorHandler.b("\uEA8D\uF48F\uDF91\uD993\uEF95\uE197\uE399\uE59B", A_1_1)));
            length1 = bytes2.GetLength(0);
            index1 = (short) 0;
            num3 = (short) 28;
            num1 = (int) (IntPtr) num3;
            goto default;
          default:
            int index2;
            int length2;
            byte[] bytes3;
            byte num4;
            SHA256 A_0_1;
            while (true)
            {
              switch (num1)
              {
                case 0:
                  num3 = (short) 22;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 1:
                  A_1_2 += ((char) bytes3[index2]).ToString();
                  --index2;
                  num3 = (short) 7;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 2:
                  if (num4 != (byte) 49)
                  {
                    num3 = (short) 23;
                    num1 = (int) (IntPtr) num3;
                    continue;
                  }
                  goto case 8;
                case 3:
                  char ch1 = (char) bytes2[2];
                  A_1_2 += ch1.ToString();
                  num3 = (short) 1;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 4:
                  bytes3 = asciiEncoding.GetBytes(empty);
                  length2 = bytes3.Length;
                  index2 = length2 - 1;
                  num3 = (short) 18;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 5:
                  num3 = (short) 17;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 6:
                  if (num4 < (byte) 127 /*0x7F*/)
                  {
                    num3 = (short) 5;
                    num1 = (int) (IntPtr) num3;
                    continue;
                  }
                  goto case 9;
                case 7:
                case 18:
                  num3 = (short) 38;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 8:
                  empty += RptMgrErrorHandler.b("\uF68D", A_1_1);
                  num3 = (short) 9;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 9:
                case 26:
                  ++index1;
                  num3 = (short) 10;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 10:
                case 28:
                  num3 = (short) 19;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 11:
                  num3 = (short) 20;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 12:
                  A_1_2 = A_1_2.Remove(11);
                  num3 = (short) 35;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 13:
                  num3 = (short) 2;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 14:
                  num3 = (short) 39;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 15:
                  num3 = (short) 6;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 16 /*0x10*/:
                  num3 = (short) 1;
                  if (num3 == (short) 0)
                    ;
                  if (num4 != (byte) 73)
                  {
                    num3 = (short) 36;
                    num1 = (int) (IntPtr) num3;
                    continue;
                  }
                  goto case 8;
                case 17:
                  num3 = (short) 0;
                  if (num4 != (byte) 48 /*0x30*/)
                  {
                    num3 = (short) 13;
                    num1 = (int) (IntPtr) num3;
                    continue;
                  }
                  goto case 8;
                case 19:
                  if ((int) index1 >= length1)
                  {
                    num3 = (short) 4;
                    num1 = (int) (IntPtr) num3;
                    continue;
                  }
                  num3 = (short) 40;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 20:
                  if (index2 == length2 - 1)
                  {
                    num3 = (short) 3;
                    num1 = (int) (IntPtr) num3;
                    continue;
                  }
                  goto case 1;
                case 21:
                  A_1_2 = A_1 + A_1_2;
                  A_0_1 = SHA256.Create();
                  num3 = (short) 25;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 22:
                  if (num4 != (byte) 108)
                  {
                    num3 = (short) 14;
                    num1 = (int) (IntPtr) num3;
                    continue;
                  }
                  goto case 8;
                case 23:
                  num3 = (short) 16 /*0x10*/;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 24:
                  if (A_1_2.Length > 12)
                  {
                    num3 = (short) 12;
                    num1 = (int) (IntPtr) num3;
                    continue;
                  }
                  goto label_70;
                case 25:
                  try
                  {
                    A_1_2 = CommonSecurity.a(A_0_1, A_1_2);
                  }
                  finally
                  {
                    short num5 = -14869;
                    int num6 = (int) num5;
                    num5 = (short) -14869;
                    int num7 = (int) num5;
                    switch (num6 == num7 ? 1 : 0)
                    {
                      case 0:
                      case 2:
label_27:
                        switch (0)
                        {
                          case 0:
                            goto label_29;
                        }
                        break;
                      default:
                        num5 = (short) 0;
                        if (num5 == (short) 0)
                          ;
                        num5 = (short) 0;
                        num1 = (int) (IntPtr) num5;
                        break;
                    }
                    while (true)
                    {
                      switch (num1)
                      {
                        case 0:
                          goto label_27;
                        case 1:
                          goto label_32;
                        case 2:
                          A_0_1.Dispose();
                          num5 = (short) 1;
                          num1 = (int) (IntPtr) num5;
                          continue;
                        default:
                          goto label_29;
                      }
label_28:;
                    }
label_29:
                    if (A_0_1 != null)
                    {
                      num5 = (short) 2;
                      num1 = (int) (IntPtr) num5;
                      goto label_28;
                    }
label_32:;
                  }
                  num3 = (short) 24;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 27:
                  num4 = (byte) ((uint) bytes1[num2++] ^ (uint) bytes2[(int) index1]);
                  num3 = (short) 37;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 29:
                  num2 = day;
                  num3 = (short) 27;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 30:
                  num3 = (short) 31 /*0x1F*/;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 31 /*0x1F*/:
                  if (index2 == length2 - 2)
                  {
                    num3 = (short) 34;
                    num1 = (int) (IntPtr) num3;
                    continue;
                  }
                  goto case 11;
                case 32 /*0x20*/:
                  if (num4 != (byte) 79)
                  {
                    num3 = (short) 0;
                    num1 = (int) (IntPtr) num3;
                    continue;
                  }
                  goto case 8;
                case 33:
                  if (length2 < 6)
                  {
                    num3 = (short) 30;
                    num1 = (int) (IntPtr) num3;
                    continue;
                  }
                  goto case 1;
                case 34:
                  char ch2 = (char) bytes2[3];
                  A_1_2 += ch2.ToString();
                  num3 = (short) 11;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 35:
                  goto label_70;
                case 36:
                  num3 = (short) 32 /*0x20*/;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 37:
                  if (num4 > (byte) 32 /*0x20*/)
                  {
                    num3 = (short) 15;
                    num1 = (int) (IntPtr) num3;
                    continue;
                  }
                  goto case 9;
                case 38:
                  if (index2 < 0)
                  {
                    num3 = (short) 21;
                    num1 = (int) (IntPtr) num3;
                    continue;
                  }
                  num3 = (short) 33;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 39:
                  if (num4 != (byte) 111)
                  {
                    empty += ((char) num4).ToString();
                    num3 = (short) 26;
                    num1 = (int) (IntPtr) num3;
                    continue;
                  }
                  num3 = (short) 8;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 40:
                  if (num2 >= 40)
                  {
                    num3 = (short) 29;
                    num1 = (int) (IntPtr) num3;
                    continue;
                  }
                  goto case 27;
                default:
                  goto label_3;
              }
            }
label_70:
            return A_1_2;
        }
    }
  }

  internal static bool isHiddenPwd(string testPwd, string serialNumber)
  {
    int num1 = 1;
    bool flag;
    while (true)
    {
      short num2 = 0;
      DateTime now;
      switch (num1)
      {
        case 0:
          flag = true;
          num2 = (short) 5;
          num1 = (int) (IntPtr) num2;
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
        case 5:
          goto label_17;
        case 3:
          if (CommonSecurity.a(now.AddDays(-1.0), serialNumber) == testPwd)
          {
            num2 = (short) 6;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto label_17;
        case 4:
          goto label_12;
        case 6:
          flag = true;
          num2 = (short) 2;
          num1 = (int) (IntPtr) num2;
          continue;
        case 7:
          if (!(CommonSecurity.a(now.Date, serialNumber) == testPwd))
          {
            now = DateTime.Now;
            num2 = (short) 3;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          num2 = (short) 0;
          num1 = (int) (IntPtr) num2;
          continue;
      }
      num2 = (short) -9612;
      int num3 = (int) num2;
      num2 = (short) -9612;
      int num4 = (int) num2;
      switch (num3 == num4 ? 1 : 0)
      {
        case 0:
        case 2:
          num2 = (short) 4;
          num1 = (int) (IntPtr) num2;
          continue;
        default:
          num2 = (short) 0;
          if (num2 == (short) 0)
            ;
          num2 = (short) 1;
          if (num2 == (short) 0)
            ;
          if (!string.IsNullOrEmpty(serialNumber))
          {
            flag = false;
            now = DateTime.Now;
            num2 = (short) 7;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto case 0;
      }
    }
label_12:
    throw new CommonException((CommonErrorCode) 1450);
label_17:
    return flag;
  }
}
