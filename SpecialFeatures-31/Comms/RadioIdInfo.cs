// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.Comms.RadioIdInfo
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using System.Collections.Generic;

#nullable disable
namespace SpecialFeatures.Comms;

public struct RadioIdInfo
{
  private Dictionary<string, int[]> a;
  private Dictionary<string, int[]> b;
  private Dictionary<string, int> c;
  private DataProfIP[] d;
  private string[] e;
  private string f;
  private string g;
  private byte[] h;
  private bool i;
  private string j;
  private bool k;

  public Dictionary<string, int[]> CnvSysIds
  {
    get
    {
      short num1 = 10790;
      int num2 = (int) num1;
      num1 = (short) 10790;
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
          return this.b;
        default:
          goto case 1;
      }
    }
    set
    {
      short num = -3403;
      switch ((short) -3403 == num)
      {
        case true:
          num = (short) 1;
          if (num == (short) 0)
            ;
          num = (short) 0;
          if (num == (short) 0)
            ;
          this.b = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  public Dictionary<string, int[]> TrkSysIds
  {
    get
    {
      switch (true)
      {
        case true:
          short num = 1;
          if (num == (short) 0)
            ;
          num = (short) 0;
          if (num == (short) 0)
            ;
          return this.a;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = -1755;
      int num2 = (int) num1;
      num1 = (short) -1755;
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
          this.a = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  public Dictionary<string, int> AstroOtarRadioIds
  {
    get
    {
      short num1 = 0;
      num1 = (short) 1;
      if (num1 == (short) 0)
        ;
      num1 = (short) -23252;
      int num2 = (int) num1;
      num1 = (short) -23252;
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
      num1 = (short) -4893;
      int num2 = (int) num1;
      num1 = (short) -4893;
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

  public DataProfIP[] DataProfIps
  {
    get
    {
      short num1 = 0;
      num1 = (short) 25569;
      int num2 = (int) num1;
      num1 = (short) 25569;
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
          return this.d;
        default:
          goto case 1;
      }
    }
    set
    {
      short num = 19506;
      switch ((short) 19506 == num)
      {
        case true:
          num = (short) 1;
          if (num == (short) 0)
            ;
          num = (short) 0;
          if (num == (short) 0)
            ;
          this.d = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  public string[] SoftIds
  {
    get
    {
      short num = -4021;
      switch ((short) -4021 == num)
      {
        case true:
          num = (short) 1;
          if (num == (short) 0)
            ;
          num = (short) 0;
          if (num == (short) 0)
            ;
          return this.e;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = 0;
      num1 = (short) -9818;
      int num2 = (int) num1;
      num1 = (short) -9818;
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
          this.e = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  public string RadioAlias
  {
    get
    {
      short num = 11565;
      switch ((short) 11565 == num)
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
      num1 = (short) 22776;
      int num2 = (int) num1;
      num1 = (short) 22776;
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

  public string BluetoothFriendlyName
  {
    get
    {
      short num1 = 8657;
      int num2 = (int) num1;
      num1 = (short) 8657;
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
          return this.g;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = 0;
      num1 = (short) -13797;
      int num2 = (int) num1;
      num1 = (short) -13797;
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
          this.g = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  public byte[] ESerialNumber
  {
    get
    {
      short num = 25939;
      switch ((short) 25939 == num)
      {
        case true:
          num = (short) 1;
          if (num == (short) 0)
            ;
          num = (short) 0;
          if (num == (short) 0)
            ;
          return this.h;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = 0;
      num1 = (short) 7014;
      int num2 = (int) num1;
      num1 = (short) 7014;
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
          this.h = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  public bool IsEncryptedPwd
  {
    get
    {
      short num = 29904;
      switch ((short) 29904 == num)
      {
        case true:
          num = (short) 0;
          if (num == (short) 0)
            ;
          num = (short) 1;
          if (num == (short) 0)
            ;
          return this.i;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = 0;
      num1 = (short) 5562;
      int num2 = (int) num1;
      num1 = (short) 5562;
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
          this.i = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  public string EncryptedPwd
  {
    get
    {
      short num1 = 0;
      num1 = (short) 5637;
      int num2 = (int) num1;
      num1 = (short) 5637;
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
          return this.j;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = 24874;
      int num2 = (int) num1;
      num1 = (short) 24874;
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
          this.j = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  public bool IsManagedUpgrade
  {
    get
    {
      short num1 = 0;
      num1 = (short) -30173;
      int num2 = (int) num1;
      num1 = (short) -30173;
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
          return this.k;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = 0;
      num1 = (short) 4341;
      int num2 = (int) num1;
      num1 = (short) 4341;
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
          this.k = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  public string SerialNumber
  {
    readonly get
    {
      short num1 = 0;
      num1 = (short) 12376;
      int num2 = (int) num1;
      num1 = (short) 12376;
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
          return this.l;
        default:
          goto case 1;
      }
    }
    set
    {
      short num = 6955;
      switch ((short) 6955 == num)
      {
        case true:
          num = (short) 1;
          if (num == (short) 0)
            ;
          num = (short) 0;
          if (num == (short) 0)
            ;
          this.l = value;
          break;
        default:
          goto case 1;
      }
    }
  }
}
