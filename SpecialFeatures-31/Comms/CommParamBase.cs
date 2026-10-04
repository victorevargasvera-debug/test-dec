// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.Comms.CommParamBase
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

#nullable disable
namespace SpecialFeatures.Comms;

public class CommParamBase
{
  internal int CommReceiveTimeout
  {
    get
    {
      short num1 = 13505;
      int num2 = (int) num1;
      num1 = (short) 13505;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          short num4 = 1;
          if (num4 == (short) 0)
            ;
          num4 = (short) 0;
          num4 = (short) 0;
          if (num4 == (short) 0)
            ;
          return this.a;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = -25695;
      int num2 = (int) num1;
      num1 = (short) -25695;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          short num4 = 0;
          if (num4 == (short) 0)
            ;
          num4 = (short) 0;
          num4 = (short) 1;
          if (num4 == (short) 0)
            ;
          this.a = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  internal int CommSendTimeout
  {
    get
    {
      short num1 = 16880;
      int num2 = (int) num1;
      num1 = (short) 16880;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          short num4 = 0;
          if (num4 == (short) 0)
            ;
          num4 = (short) 0;
          num4 = (short) 1;
          if (num4 == (short) 0)
            ;
          return this.b;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = 4500;
      int num2 = (int) num1;
      num1 = (short) 4500;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          short num4 = 1;
          if (num4 == (short) 0)
            ;
          num4 = (short) 0;
          num4 = (short) 0;
          if (num4 == (short) 0)
            ;
          this.b = value;
          break;
        default:
          goto case 1;
      }
    }
  }
}
