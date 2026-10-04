// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.Comms.DataProfIP
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using System.Net;

#nullable disable
namespace SpecialFeatures.Comms;

public struct DataProfIP
{
  private string a;
  private IPAddress b;
  private IPAddress c;
  private IPAddress d;
  private IPAddress e;
  private IPAddress f;

  public string DataProfName
  {
    get
    {
      short num1 = 17146;
      int num2 = (int) num1;
      num1 = (short) 17146;
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
          return this.a;
        default:
          num4 = (short) 0;
          goto case 1;
      }
    }
    set
    {
      short num1 = -14950;
      int num2 = (int) num1;
      num1 = (short) -14950;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          num1 = (short) 1;
          if (num1 == (short) 0)
            ;
          this.a = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  public IPAddress SubIP
  {
    get
    {
      short num1 = 0;
      num1 = (short) 1;
      if (num1 == (short) 0)
        ;
      num1 = (short) 28485;
      int num2 = (int) num1;
      num1 = (short) 28485;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          return this.b;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = 0;
      num1 = (short) -16541;
      int num2 = (int) num1;
      num1 = (short) -16541;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          num1 = (short) 1;
          if (num1 == (short) 0)
            ;
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          this.b = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  public IPAddress PeerIP
  {
    get
    {
      if (false)
        ;
      short num1 = -31877;
      int num2 = (int) num1;
      num1 = (short) -31877;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          return this.c;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = 0;
      num1 = (short) -17176;
      int num2 = (int) num1;
      num1 = (short) -17176;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          num1 = (short) 1;
          if (num1 == (short) 0)
            ;
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          this.c = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  public IPAddress BTSubIP
  {
    get
    {
      short num1 = 0;
      num1 = (short) 1;
      if (num1 == (short) 0)
        ;
      num1 = (short) -20243;
      int num2 = (int) num1;
      num1 = (short) -20243;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          return this.d;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = 0;
      num1 = (short) -16231;
      int num2 = (int) num1;
      num1 = (short) -16231;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          num1 = (short) 1;
          if (num1 == (short) 0)
            ;
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          this.d = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  public IPAddress BTPeerIP
  {
    get
    {
      short num1 = 0;
      num1 = (short) -3519;
      int num2 = (int) num1;
      num1 = (short) -3519;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          num1 = (short) 1;
          if (num1 == (short) 0)
            ;
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          return this.e;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = 0;
      num1 = (short) -19844;
      int num2 = (int) num1;
      num1 = (short) -19844;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          num1 = (short) 1;
          if (num1 == (short) 0)
            ;
          this.e = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  public IPAddress SubAirInterfaceIP
  {
    get
    {
      short num = 19454;
      switch ((short) 19454 == num)
      {
        case true:
          num = (short) 1;
          if (num == (short) 0)
            ;
          num = (short) 0;
          if (num == (short) 0)
            ;
          return this.f;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = 0;
      num1 = (short) -777;
      int num2 = (int) num1;
      num1 = (short) -777;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          num1 = (short) 1;
          if (num1 == (short) 0)
            ;
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          this.f = value;
          break;
        default:
          goto case 1;
      }
    }
  }
}
