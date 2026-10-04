// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.Comms.Util.HostVersion
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using SpecialFeatures.AcpReportManagerLib;
using System;
using System.Text.RegularExpressions;

#nullable disable
namespace SpecialFeatures.Comms.Util;

public struct HostVersion : IComparable
{
  public HostVersion(bool success, short major, short minor)
  {
    // ISSUE: reference to a compiler-generated field
    this.a = success;
    // ISSUE: reference to a compiler-generated field
    this.b = major;
    // ISSUE: reference to a compiler-generated field
    this.c = minor;
  }

  public readonly bool Success
  {
    get
    {
      short num1 = -26317;
      int num2 = (int) num1;
      num1 = (short) -26317;
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
          return this.a;
        default:
          goto case 1;
      }
    }
  }

  public readonly short Major
  {
    get
    {
      short num1 = 19232;
      int num2 = (int) num1;
      num1 = (short) 19232;
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
          num4 = (short) 0;
          return this.b;
        default:
          goto case 1;
      }
    }
  }

  public readonly short Minor
  {
    get
    {
      short num1 = -7260;
      int num2 = (int) num1;
      num1 = (short) -7260;
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
          num4 = (short) 0;
          return this.c;
        default:
          goto case 1;
      }
    }
  }

  internal static Regex VersionPattern
  {
    get
    {
      short num1 = -17231;
      int num2 = (int) num1;
      num1 = (short) -17231;
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
          return HostVersion.d;
        default:
          goto case 1;
      }
    }
  }

  public static HostVersion Parse(string hostVersionStr)
  {
    int A_1_1 = 2;
    switch (0)
    {
      default:
        short num1;
        int num2;
        Match match;
        switch (true ? 1 : 0)
        {
          case 0:
          case 2:
label_6:
            match = HostVersion.VersionPattern.Match(hostVersionStr ?? string.Empty);
            num1 = (short) 1;
            if (num1 == (short) 0)
              ;
            num1 = (short) 1;
            num2 = (int) (IntPtr) num1;
            break;
          default:
            num1 = (short) 0;
            num1 = (short) 0;
            if (num1 == (short) 0)
              ;
            num1 = (short) 2;
            num2 = (int) (IntPtr) num1;
            break;
        }
        while (true)
        {
          switch (num2)
          {
            case 0:
              goto label_7;
            case 1:
              if (match.Success)
              {
                num1 = (short) 0;
                num2 = (int) (IntPtr) num1;
                continue;
              }
              goto label_11;
            case 2:
              goto label_4;
            default:
              goto label_6;
          }
label_5:;
        }
label_4:
        switch (0)
        {
          case 0:
            goto label_6;
          default:
            goto label_5;
        }
label_7:
        short A_1_2;
        bool flag = HostVersion.a(match.Groups[RptMgrErrorHandler.b("좄\uE686\uE388\uE48Aﾌ", A_1_1)], out A_1_2);
        short A_1_3;
        return new HostVersion(HostVersion.a(match.Groups[RptMgrErrorHandler.b("좄\uEE86\uE788\uE48Aﾌ", A_1_1)], out A_1_3) & flag, A_1_2, A_1_3);
label_11:
        return new HostVersion();
    }
  }

  private static bool a(Group A_0, out short A_1)
  {
    A_1 = (short) 0;
    if (!A_0.Success)
      goto label_2;
label_1:
    short num1 = 0;
    return short.TryParse(A_0.Value, out A_1);
label_2:
    if (false)
      ;
    num1 = (short) -8873;
    int num2 = (int) num1;
    num1 = (short) -8873;
    int num3 = (int) num1;
    switch (num2 == num3 ? 1 : 0)
    {
      case 0:
      case 2:
        goto label_1;
      default:
        num1 = (short) 0;
        if (num1 == (short) 0)
          ;
        return false;
    }
  }

  public int CompareTo(object obj)
  {
    int num1 = 0;
    switch (num1)
    {
      default:
        short num2;
        HostVersion hostVersion;
        switch (0)
        {
          case 0:
label_3:
            num2 = (short) 1;
            if (num2 == (short) 0)
              ;
            hostVersion = HostVersion.Parse(obj.ToString());
            num2 = (short) 4;
            num1 = (int) (IntPtr) num2;
            goto default;
          default:
            int num3;
            while (true)
            {
              switch (num1)
              {
                case 0:
                  num3 = this.Minor.CompareTo(hostVersion.Minor);
                  num2 = (short) 2;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 1:
                  goto label_14;
                case 2:
                  goto label_15;
                case 3:
                  if (num3 == 0)
                  {
                    num2 = (short) 0;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_15;
                case 4:
                  num2 = (short) 0;
                  if (hostVersion.Equals((object) new HostVersion()))
                  {
                    num2 = (short) 2269;
                    int num4 = (int) num2;
                    num2 = (short) 2269;
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
                  }
                  else
                    num3 = this.Major.CompareTo(hostVersion.Major);
                  num2 = (short) 3;
                  num1 = (int) (IntPtr) num2;
                  continue;
                default:
                  goto label_3;
              }
            }
label_14:
            return -1;
label_15:
            return num3;
        }
    }
  }

  static HostVersion()
  {
    int A_1 = 3;
    short num1 = -25525;
    int num2 = (int) num1;
    num1 = (short) -25525;
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
        num4 = (short) 0;
        // ISSUE: reference to a compiler-generated field
        HostVersion.d = new Regex(RptMgrErrorHandler.b("\uD885풇캉뎋ꚍ꾏꺑\uD993\uF795\uF297\uF599\uEE9Bꂝﲟ욡\uDFA3鞥蒧颩톫螭\uECAF鲱讳麵螷蚹\uF1BBힽ꺿귁뛃\uF8C5铇껉럋ￍﳏ\uE0D1꧓ￕ", A_1));
        break;
      default:
        goto case 1;
    }
  }
}
