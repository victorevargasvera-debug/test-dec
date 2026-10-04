// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.Comms.CloneParameters
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

#nullable disable
namespace SpecialFeatures.Comms;

public static class CloneParameters
{
  public static COMMS_OP CloneWriteType
  {
    get
    {
      short num1 = 3555;
      int num2 = (int) num1;
      num1 = (short) 3555;
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
          return CloneParameters.a;
        default:
          num4 = (short) 0;
          goto case 1;
      }
    }
    set
    {
      short num1 = 5680;
      int num2 = (int) num1;
      num1 = (short) 5680;
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
          CloneParameters.a = value;
          break;
        default:
          num4 = (short) 0;
          goto case 1;
      }
    }
  }

  public static object LastCloneOTAPUserState
  {
    get
    {
      short num1 = -30559;
      int num2 = (int) num1;
      num1 = (short) -30559;
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
          return CloneParameters.b;
        default:
          num4 = (short) 0;
          goto case 1;
      }
    }
    set
    {
      short num1 = 18073;
      int num2 = (int) num1;
      num1 = (short) 18073;
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
          CloneParameters.b = value;
          break;
        default:
          num4 = (short) 0;
          goto case 1;
      }
    }
  }

  public static bool BlockNewSystemCheck
  {
    get
    {
      short num1 = 7637;
      int num2 = (int) num1;
      num1 = (short) 7637;
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
          return CloneParameters.c;
        default:
          num4 = (short) 0;
          goto case 1;
      }
    }
    set
    {
      short num1 = 4621;
      int num2 = (int) num1;
      num1 = (short) 4621;
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
          CloneParameters.c = value;
          break;
        default:
          num4 = (short) 0;
          goto case 1;
      }
    }
  }
}
