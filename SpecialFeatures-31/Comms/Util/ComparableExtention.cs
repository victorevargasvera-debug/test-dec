// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.Comms.Util.ComparableExtention
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using System;

#nullable disable
namespace SpecialFeatures.Comms.Util;

public static class ComparableExtention
{
  public static bool GreaterThan(this IComparable comarable, object obj)
  {
    short num1 = 8002;
    int num2 = (int) num1;
    num1 = (short) 8002;
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
        return comarable.CompareTo(obj) > 0;
      default:
        goto case 1;
    }
  }

  public static bool LowerThan(this IComparable comarable, object obj)
  {
    short num1 = 13654;
    int num2 = (int) num1;
    num1 = (short) 13654;
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
        return comarable.CompareTo(obj) < 0;
      default:
        goto case 1;
    }
  }

  public static bool EqualTo(this IComparable comarable, object obj)
  {
    short num1 = -27899;
    int num2 = (int) num1;
    num1 = (short) -27899;
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
        return comarable.CompareTo(obj) == 0;
      default:
        goto case 1;
    }
  }
}
