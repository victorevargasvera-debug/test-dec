// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.Comms.ProxyParameter
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using Motorola.Common.Communication.CommonUtil;

#nullable disable
namespace SpecialFeatures.Comms;

public class ProxyParameter
{
  public RadioParams RadioParams
  {
    get
    {
      short num1 = 29510;
      int num2 = (int) num1;
      num1 = (short) 29510;
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
    set
    {
      short num1 = -3582;
      int num2 = (int) num1;
      num1 = (short) -3582;
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
          this.a = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  public RadioOperation RadioOperation
  {
    get
    {
      short num1 = 18040;
      int num2 = (int) num1;
      num1 = (short) 18040;
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
    set
    {
      short num1 = 1;
      if (num1 == (short) 0)
        ;
      num1 = (short) -4821;
      int num2 = (int) num1;
      num1 = (short) -4821;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          num1 = (short) 0;
          this.b = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  public AstroDeviceInfo AstroDeviceInfo
  {
    get
    {
      short num1 = -15127;
      int num2 = (int) num1;
      num1 = (short) -15127;
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
          return this.c;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = -14425;
      int num2 = (int) num1;
      num1 = (short) -14425;
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
          this.c = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  public string DeviceFile
  {
    get
    {
      short num1 = -19274;
      int num2 = (int) num1;
      num1 = (short) -19274;
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
          return this.d;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = -13669;
      int num2 = (int) num1;
      num1 = (short) -13669;
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
          this.d = value;
          break;
        default:
          goto case 1;
      }
    }
  }
}
