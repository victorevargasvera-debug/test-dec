// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.DdiltBuilder.DdiltContainer
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SpecialFeatures.DdiltBuilder;

public class DdiltContainer
{
  private uint a;
  private const uint b = 92;
  private ushort c = ushort.MaxValue;
  private uint d;
  private uint e;
  private uint f;
  private uint g;
  private uint h;
  private uint i;
  private uint j;
  private uint k;
  private uint l;
  private uint m;
  private uint n;
  private uint o;
  private uint p;
  private uint q;
  private uint r;
  private uint s;
  private DdiltGroup t;
  private DdiltGroup u;
  private DdiltGroup v;
  private byte[] w;

  public ushort[] LifeTimeMax
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
          return this.x;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = 0;
      num1 = (short) -12867;
      int num2 = (int) num1;
      num1 = (short) -12867;
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
          this.x = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  public uint MagicNumber
  {
    get
    {
      short num1 = 0;
      num1 = (short) 5683;
      int num2 = (int) num1;
      num1 = (short) 5683;
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
      short num = -30050;
      switch ((short) -30050 == num)
      {
        case true:
          num = (short) 1;
          if (num == (short) 0)
            ;
          num = (short) 0;
          if (num == (short) 0)
            ;
          this.e = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  public uint Reserved
  {
    get
    {
      switch (true)
      {
        case true:
          if (false)
            ;
          if (true)
            ;
          return this.f;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = 0;
      num1 = (short) 27511;
      int num2 = (int) num1;
      num1 = (short) 27511;
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

  public uint ChecksumRange
  {
    get
    {
      short num1 = 0;
      num1 = (short) 12286;
      int num2 = (int) num1;
      num1 = (short) 12286;
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
          return this.g;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = 0;
      num1 = (short) -22612;
      int num2 = (int) num1;
      num1 = (short) -22612;
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

  public uint Checksum
  {
    get
    {
      short num1 = 0;
      num1 = (short) 22610;
      int num2 = (int) num1;
      num1 = (short) 22610;
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
          return this.h;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = 0;
      num1 = (short) 5440;
      int num2 = (int) num1;
      num1 = (short) 5440;
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
          this.h = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  public uint VectorCount
  {
    get
    {
      short num = -16946;
      switch ((short) -16946 == num)
      {
        case true:
          num = (short) 1;
          if (num == (short) 0)
            ;
          num = (short) 0;
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
      num1 = (short) 12530;
      int num2 = (int) num1;
      num1 = (short) 12530;
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
          this.i = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  public uint VersionNumber
  {
    get
    {
      short num1 = 0;
      num1 = (short) 1112;
      int num2 = (int) num1;
      num1 = (short) 1112;
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
          return this.j;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = 0;
      num1 = (short) 5544;
      int num2 = (int) num1;
      num1 = (short) 5544;
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

  public uint CodeplugGroupID
  {
    get
    {
      short num1 = 0;
      num1 = (short) -12321;
      int num2 = (int) num1;
      num1 = (short) -12321;
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
          return this.k;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = 0;
      num1 = (short) 28433;
      int num2 = (int) num1;
      num1 = (short) 28433;
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

  public uint CodeplugGroupVector
  {
    get
    {
      short num1 = 0;
      num1 = (short) 1;
      if (num1 == (short) 0)
        ;
      num1 = (short) 2895;
      int num2 = (int) num1;
      num1 = (short) 2895;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
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
      short num = -3754;
      switch ((short) -3754 == num)
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

  public uint UclGroupID
  {
    get
    {
      short num1 = 0;
      num1 = (short) -2212;
      int num2 = (int) num1;
      num1 = (short) -2212;
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
          return this.n;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = 0;
      num1 = (short) 15771;
      int num2 = (int) num1;
      num1 = (short) 15771;
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
          this.n = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  public uint UclGroupVector
  {
    get
    {
      short num1 = 4106;
      int num2 = (int) num1;
      num1 = (short) 4106;
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
          return this.o;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = 0;
      num1 = (short) 21873;
      int num2 = (int) num1;
      num1 = (short) 21873;
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
          this.o = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  public uint SecGroupID
  {
    get
    {
      short num1 = -26202;
      int num2 = (int) num1;
      num1 = (short) -26202;
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
          return this.q;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = 0;
      num1 = (short) -5999;
      int num2 = (int) num1;
      num1 = (short) -5999;
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
          this.q = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  public uint SecGroupVector
  {
    get
    {
      short num1 = -16361;
      int num2 = (int) num1;
      num1 = (short) -16361;
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
          return this.r;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = 0;
      num1 = (short) 1;
      if (num1 == (short) 0)
        ;
      num1 = (short) -24521;
      int num2 = (int) num1;
      num1 = (short) -24521;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          this.r = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  public DdiltGroup CodePlugGroup
  {
    get
    {
      short num = -6061;
      switch ((short) -6061 == num)
      {
        case true:
          num = (short) 1;
          if (num == (short) 0)
            ;
          num = (short) 0;
          if (num == (short) 0)
            ;
          return this.t;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = 0;
      num1 = (short) 1;
      if (num1 == (short) 0)
        ;
      num1 = (short) -19109;
      int num2 = (int) num1;
      num1 = (short) -19109;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          this.t = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  public DdiltGroup UclGroup
  {
    get
    {
      short num1 = 0;
      num1 = (short) 23738;
      int num2 = (int) num1;
      num1 = (short) 23738;
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
          return this.u;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = 0;
      num1 = (short) 6811;
      int num2 = (int) num1;
      num1 = (short) 6811;
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
          this.u = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  public DdiltGroup SecGroup
  {
    get
    {
      short num1 = 0;
      num1 = (short) 23713;
      int num2 = (int) num1;
      num1 = (short) 23713;
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
          return this.v;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = 0;
      num1 = (short) -8294;
      int num2 = (int) num1;
      num1 = (short) -8294;
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
          this.v = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  public byte[] ConvertToBytes()
  {
    int num1 = 0;
    switch (num1)
    {
      default:
        short num2;
        switch (0)
        {
          case 0:
label_3:
            this.m = (uint) this.t.MultiInstanceEntries.Count;
            this.s = (uint) this.v.MultiInstanceEntries.Count;
            num2 = (short) 16 /*0x10*/;
            num1 = (int) (IntPtr) num2;
            goto default;
          default:
            ushort[] lifeTimeMax;
            int index1;
            SortedDictionary<ushort, ushort>.Enumerator enumerator;
            uint num3;
            while (true)
            {
              switch (num1)
              {
                case 0:
                  this.d += this.m * 4U;
                  this.d += this.a * 2U;
                  this.d += this.s * 4U;
                  this.d += 92U;
                  this.w = new byte[(int) this.d];
                  uint num4 = 0;
                  this.d -= 8U;
                  byte[] w1 = this.w;
                  int index2 = (int) num4;
                  uint num5 = (uint) (index2 + 1);
                  w1[index2] = (byte) 2;
                  byte[] w2 = this.w;
                  int index3 = (int) num5;
                  uint num6 = (uint) (index3 + 1);
                  w2[index3] = (byte) 2;
                  byte[] w3 = this.w;
                  int index4 = (int) num6;
                  uint num7 = (uint) (index4 + 1);
                  w3[index4] = (byte) 0;
                  byte[] w4 = this.w;
                  int index5 = (int) num7;
                  uint num8 = (uint) (index5 + 1);
                  w4[index5] = (byte) 158;
                  byte[] w5 = this.w;
                  int index6 = (int) num8;
                  uint num9 = (uint) (index6 + 1);
                  w5[index6] = (byte) 0;
                  byte[] w6 = this.w;
                  int index7 = (int) num9;
                  uint num10 = (uint) (index7 + 1);
                  w6[index7] = (byte) 0;
                  byte[] w7 = this.w;
                  int index8 = (int) num10;
                  uint num11 = (uint) (index8 + 1);
                  int num12 = (int) (byte) (this.d >> 8);
                  w7[index8] = (byte) num12;
                  byte[] w8 = this.w;
                  int index9 = (int) num11;
                  uint num13 = (uint) (index9 + 1);
                  int d = (int) (byte) this.d;
                  w8[index9] = (byte) d;
                  byte[] w9 = this.w;
                  int index10 = (int) num13;
                  uint num14 = (uint) (index10 + 1);
                  int num15 = (int) (byte) (this.e >> 24);
                  w9[index10] = (byte) num15;
                  byte[] w10 = this.w;
                  int index11 = (int) num14;
                  uint num16 = (uint) (index11 + 1);
                  int num17 = (int) (byte) (this.e >> 16 /*0x10*/);
                  w10[index11] = (byte) num17;
                  byte[] w11 = this.w;
                  int index12 = (int) num16;
                  uint num18 = (uint) (index12 + 1);
                  int num19 = (int) (byte) (this.e >> 8);
                  w11[index12] = (byte) num19;
                  byte[] w12 = this.w;
                  int index13 = (int) num18;
                  uint num20 = (uint) (index13 + 1);
                  int e = (int) (byte) this.e;
                  w12[index13] = (byte) e;
                  byte[] w13 = this.w;
                  int index14 = (int) num20;
                  uint num21 = (uint) (index14 + 1);
                  int num22 = (int) (byte) (this.f >> 24);
                  w13[index14] = (byte) num22;
                  byte[] w14 = this.w;
                  int index15 = (int) num21;
                  uint num23 = (uint) (index15 + 1);
                  int num24 = (int) (byte) (this.f >> 16 /*0x10*/);
                  w14[index15] = (byte) num24;
                  byte[] w15 = this.w;
                  int index16 = (int) num23;
                  uint num25 = (uint) (index16 + 1);
                  int num26 = (int) (byte) (this.f >> 8);
                  w15[index16] = (byte) num26;
                  byte[] w16 = this.w;
                  int index17 = (int) num25;
                  uint num27 = (uint) (index17 + 1);
                  int f = (int) (byte) this.f;
                  w16[index17] = (byte) f;
                  byte[] w17 = this.w;
                  int index18 = (int) num27;
                  uint num28 = (uint) (index18 + 1);
                  int num29 = (int) (byte) (this.g >> 24);
                  w17[index18] = (byte) num29;
                  byte[] w18 = this.w;
                  int index19 = (int) num28;
                  uint num30 = (uint) (index19 + 1);
                  int num31 = (int) (byte) (this.g >> 16 /*0x10*/);
                  w18[index19] = (byte) num31;
                  byte[] w19 = this.w;
                  int index20 = (int) num30;
                  uint num32 = (uint) (index20 + 1);
                  int num33 = (int) (byte) (this.g >> 8);
                  w19[index20] = (byte) num33;
                  byte[] w20 = this.w;
                  int index21 = (int) num32;
                  uint num34 = (uint) (index21 + 1);
                  int g = (int) (byte) this.g;
                  w20[index21] = (byte) g;
                  byte[] w21 = this.w;
                  int index22 = (int) num34;
                  uint num35 = (uint) (index22 + 1);
                  int num36 = (int) (byte) (this.h >> 24);
                  w21[index22] = (byte) num36;
                  byte[] w22 = this.w;
                  int index23 = (int) num35;
                  uint num37 = (uint) (index23 + 1);
                  int num38 = (int) (byte) (this.h >> 16 /*0x10*/);
                  w22[index23] = (byte) num38;
                  byte[] w23 = this.w;
                  int index24 = (int) num37;
                  uint num39 = (uint) (index24 + 1);
                  int num40 = (int) (byte) (this.h >> 8);
                  w23[index24] = (byte) num40;
                  byte[] w24 = this.w;
                  int index25 = (int) num39;
                  uint num41 = (uint) (index25 + 1);
                  int h = (int) (byte) this.h;
                  w24[index25] = (byte) h;
                  byte[] w25 = this.w;
                  int index26 = (int) num41;
                  uint num42 = (uint) (index26 + 1);
                  int num43 = (int) (byte) (this.i >> 24);
                  w25[index26] = (byte) num43;
                  byte[] w26 = this.w;
                  int index27 = (int) num42;
                  uint num44 = (uint) (index27 + 1);
                  int num45 = (int) (byte) (this.i >> 16 /*0x10*/);
                  w26[index27] = (byte) num45;
                  byte[] w27 = this.w;
                  int index28 = (int) num44;
                  uint num46 = (uint) (index28 + 1);
                  int num47 = (int) (byte) (this.i >> 8);
                  w27[index28] = (byte) num47;
                  byte[] w28 = this.w;
                  int index29 = (int) num46;
                  uint num48 = (uint) (index29 + 1);
                  int i = (int) (byte) this.i;
                  w28[index29] = (byte) i;
                  byte[] w29 = this.w;
                  int index30 = (int) num48;
                  uint num49 = (uint) (index30 + 1);
                  int num50 = (int) (byte) (this.j >> 24);
                  w29[index30] = (byte) num50;
                  byte[] w30 = this.w;
                  int index31 = (int) num49;
                  uint num51 = (uint) (index31 + 1);
                  int num52 = (int) (byte) (this.j >> 16 /*0x10*/);
                  w30[index31] = (byte) num52;
                  byte[] w31 = this.w;
                  int index32 = (int) num51;
                  uint num53 = (uint) (index32 + 1);
                  int num54 = (int) (byte) (this.j >> 8);
                  w31[index32] = (byte) num54;
                  byte[] w32 = this.w;
                  int index33 = (int) num53;
                  uint num55 = (uint) (index33 + 1);
                  int j = (int) (byte) this.j;
                  w32[index33] = (byte) j;
                  byte[] w33 = this.w;
                  int index34 = (int) num55;
                  uint num56 = (uint) (index34 + 1);
                  int num57 = (int) (byte) (this.k >> 24);
                  w33[index34] = (byte) num57;
                  byte[] w34 = this.w;
                  int index35 = (int) num56;
                  uint num58 = (uint) (index35 + 1);
                  int num59 = (int) (byte) (this.k >> 16 /*0x10*/);
                  w34[index35] = (byte) num59;
                  byte[] w35 = this.w;
                  int index36 = (int) num58;
                  uint num60 = (uint) (index36 + 1);
                  int num61 = (int) (byte) (this.k >> 8);
                  w35[index36] = (byte) num61;
                  byte[] w36 = this.w;
                  int index37 = (int) num60;
                  uint num62 = (uint) (index37 + 1);
                  int k = (int) (byte) this.k;
                  w36[index37] = (byte) k;
                  byte[] w37 = this.w;
                  int index38 = (int) num62;
                  uint num63 = (uint) (index38 + 1);
                  int num64 = (int) (byte) (this.l >> 24);
                  w37[index38] = (byte) num64;
                  byte[] w38 = this.w;
                  int index39 = (int) num63;
                  uint num65 = (uint) (index39 + 1);
                  int num66 = (int) (byte) (this.l >> 16 /*0x10*/);
                  w38[index39] = (byte) num66;
                  byte[] w39 = this.w;
                  int index40 = (int) num65;
                  uint num67 = (uint) (index40 + 1);
                  int num68 = (int) (byte) (this.l >> 8);
                  w39[index40] = (byte) num68;
                  byte[] w40 = this.w;
                  int index41 = (int) num67;
                  uint num69 = (uint) (index41 + 1);
                  int l = (int) (byte) this.l;
                  w40[index41] = (byte) l;
                  byte[] w41 = this.w;
                  int index42 = (int) num69;
                  uint num70 = (uint) (index42 + 1);
                  int num71 = (int) (byte) (this.n >> 24);
                  w41[index42] = (byte) num71;
                  byte[] w42 = this.w;
                  int index43 = (int) num70;
                  uint num72 = (uint) (index43 + 1);
                  int num73 = (int) (byte) (this.n >> 16 /*0x10*/);
                  w42[index43] = (byte) num73;
                  byte[] w43 = this.w;
                  int index44 = (int) num72;
                  uint num74 = (uint) (index44 + 1);
                  int num75 = (int) (byte) (this.n >> 8);
                  w43[index44] = (byte) num75;
                  byte[] w44 = this.w;
                  int index45 = (int) num74;
                  uint num76 = (uint) (index45 + 1);
                  int n = (int) (byte) this.n;
                  w44[index45] = (byte) n;
                  byte[] w45 = this.w;
                  int index46 = (int) num76;
                  uint num77 = (uint) (index46 + 1);
                  int num78 = (int) (byte) (this.o >> 24);
                  w45[index46] = (byte) num78;
                  byte[] w46 = this.w;
                  int index47 = (int) num77;
                  uint num79 = (uint) (index47 + 1);
                  int num80 = (int) (byte) (this.o >> 16 /*0x10*/);
                  w46[index47] = (byte) num80;
                  byte[] w47 = this.w;
                  int index48 = (int) num79;
                  uint num81 = (uint) (index48 + 1);
                  int num82 = (int) (byte) (this.o >> 8);
                  w47[index48] = (byte) num82;
                  byte[] w48 = this.w;
                  int index49 = (int) num81;
                  uint num83 = (uint) (index49 + 1);
                  int o = (int) (byte) this.o;
                  w48[index49] = (byte) o;
                  byte[] w49 = this.w;
                  int index50 = (int) num83;
                  uint num84 = (uint) (index50 + 1);
                  int num85 = (int) (byte) (this.q >> 24);
                  w49[index50] = (byte) num85;
                  byte[] w50 = this.w;
                  int index51 = (int) num84;
                  uint num86 = (uint) (index51 + 1);
                  int num87 = (int) (byte) (this.q >> 16 /*0x10*/);
                  w50[index51] = (byte) num87;
                  byte[] w51 = this.w;
                  int index52 = (int) num86;
                  uint num88 = (uint) (index52 + 1);
                  int num89 = (int) (byte) (this.q >> 8);
                  w51[index52] = (byte) num89;
                  byte[] w52 = this.w;
                  int index53 = (int) num88;
                  uint num90 = (uint) (index53 + 1);
                  int q = (int) (byte) this.q;
                  w52[index53] = (byte) q;
                  byte[] w53 = this.w;
                  int index54 = (int) num90;
                  uint num91 = (uint) (index54 + 1);
                  int num92 = (int) (byte) (this.r >> 24);
                  w53[index54] = (byte) num92;
                  byte[] w54 = this.w;
                  int index55 = (int) num91;
                  uint num93 = (uint) (index55 + 1);
                  int num94 = (int) (byte) (this.r >> 16 /*0x10*/);
                  w54[index55] = (byte) num94;
                  byte[] w55 = this.w;
                  int index56 = (int) num93;
                  uint num95 = (uint) (index56 + 1);
                  int num96 = (int) (byte) (this.r >> 8);
                  w55[index56] = (byte) num96;
                  byte[] w56 = this.w;
                  int index57 = (int) num95;
                  uint num97 = (uint) (index57 + 1);
                  int r = (int) (byte) this.r;
                  w56[index57] = (byte) r;
                  byte[] w57 = this.w;
                  int index58 = (int) num97;
                  uint num98 = (uint) (index58 + 1);
                  int num99 = (int) (byte) ((uint) this.t.NumberTableEntries >> 8);
                  w57[index58] = (byte) num99;
                  byte[] w58 = this.w;
                  int index59 = (int) num98;
                  uint num100 = (uint) (index59 + 1);
                  int numberTableEntries1 = (int) (byte) this.t.NumberTableEntries;
                  w58[index59] = (byte) numberTableEntries1;
                  byte[] w59 = this.w;
                  int index60 = (int) num100;
                  uint num101 = (uint) (index60 + 1);
                  int num102 = (int) (byte) ((uint) this.t.Reserved >> 8);
                  w59[index60] = (byte) num102;
                  byte[] w60 = this.w;
                  int index61 = (int) num101;
                  uint num103 = (uint) (index61 + 1);
                  int reserved1 = (int) (byte) this.t.Reserved;
                  w60[index61] = (byte) reserved1;
                  byte[] w61 = this.w;
                  int index62 = (int) num103;
                  uint num104 = (uint) (index62 + 1);
                  int num105 = (int) (byte) ((uint) this.t.FirstSingleInstance >> 8);
                  w61[index62] = (byte) num105;
                  byte[] w62 = this.w;
                  int index63 = (int) num104;
                  uint num106 = (uint) (index63 + 1);
                  int firstSingleInstance1 = (int) (byte) this.t.FirstSingleInstance;
                  w62[index63] = (byte) firstSingleInstance1;
                  byte[] w63 = this.w;
                  int index64 = (int) num106;
                  uint num107 = (uint) (index64 + 1);
                  int num108 = (int) (byte) ((uint) this.t.LastSingleInstance >> 8);
                  w63[index64] = (byte) num108;
                  byte[] w64 = this.w;
                  int index65 = (int) num107;
                  num3 = (uint) (index65 + 1);
                  int lastSingleInstance1 = (int) (byte) this.t.LastSingleInstance;
                  w64[index65] = (byte) lastSingleInstance1;
                  num2 = (short) 24;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 1:
                case 8:
                  num2 = (short) 22;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 2:
                  if (this.LifeTimeMax.Length == 0)
                  {
                    byte[] w65 = this.w;
                    int index66 = (int) num3;
                    uint num109 = (uint) (index66 + 1);
                    w65[index66] = (byte) 0;
                    byte[] w66 = this.w;
                    int index67 = (int) num109;
                    uint num110 = (uint) (index67 + 1);
                    w66[index67] = (byte) 0;
                    byte[] w67 = this.w;
                    int index68 = (int) num110;
                    uint num111 = (uint) (index68 + 1);
                    w67[index68] = (byte) 0;
                    byte[] w68 = this.w;
                    int index69 = (int) num111;
                    num3 = (uint) (index69 + 1);
                    w68[index69] = (byte) 0;
                    num2 = (short) 18;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 13;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 3:
                  num2 = (short) 7;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 4:
                  if (this.s >= 1U)
                  {
                    num2 = (short) 9;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 0;
                case 5:
                  this.a = (uint) this.LifeTimeMax.Length;
                  this.p = (uint) this.LifeTimeMax.Length / 2U;
                  ++this.p;
                  num2 = (short) 11;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 6:
                  enumerator = this.v.MultiInstanceEntries.GetEnumerator();
                  num2 = (short) 12;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 7:
                case 18:
                  byte[] w69 = this.w;
                  int index70 = (int) num3;
                  uint num112 = (uint) (index70 + 1);
                  int num113 = (int) (byte) ((uint) this.v.NumberTableEntries >> 8);
                  w69[index70] = (byte) num113;
                  byte[] w70 = this.w;
                  int index71 = (int) num112;
                  uint num114 = (uint) (index71 + 1);
                  int numberTableEntries2 = (int) (byte) this.v.NumberTableEntries;
                  w70[index71] = (byte) numberTableEntries2;
                  byte[] w71 = this.w;
                  int index72 = (int) num114;
                  uint num115 = (uint) (index72 + 1);
                  int num116 = (int) (byte) ((uint) this.v.Reserved >> 8);
                  w71[index72] = (byte) num116;
                  byte[] w72 = this.w;
                  int index73 = (int) num115;
                  uint num117 = (uint) (index73 + 1);
                  int reserved2 = (int) (byte) this.v.Reserved;
                  w72[index73] = (byte) reserved2;
                  byte[] w73 = this.w;
                  int index74 = (int) num117;
                  uint num118 = (uint) (index74 + 1);
                  int num119 = (int) (byte) ((uint) this.v.FirstSingleInstance >> 8);
                  w73[index74] = (byte) num119;
                  byte[] w74 = this.w;
                  int index75 = (int) num118;
                  uint num120 = (uint) (index75 + 1);
                  int firstSingleInstance2 = (int) (byte) this.v.FirstSingleInstance;
                  w74[index75] = (byte) firstSingleInstance2;
                  byte[] w75 = this.w;
                  int index76 = (int) num120;
                  uint num121 = (uint) (index76 + 1);
                  int num122 = (int) (byte) ((uint) this.v.LastSingleInstance >> 8);
                  w75[index76] = (byte) num122;
                  byte[] w76 = this.w;
                  int index77 = (int) num121;
                  num3 = (uint) (index77 + 1);
                  int lastSingleInstance2 = (int) (byte) this.v.LastSingleInstance;
                  w76[index77] = (byte) lastSingleInstance2;
                  num2 = (short) 15;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 9:
                  --this.s;
                  num2 = (short) 0;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 10:
                  num2 = (short) 4;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 11:
                  num2 = (short) 1;
                  if (num2 == (short) 0)
                    ;
                  if (this.a > 2U)
                  {
                    num2 = (short) 21;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 10;
                case 12:
                  goto label_18;
                case 13:
                  lifeTimeMax = this.LifeTimeMax;
                  index1 = 0;
                  num2 = (short) 1;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 14:
label_12:
                  byte[] w77 = this.w;
                  int index78 = (int) num3;
                  uint num123 = (uint) (index78 + 1);
                  int num124 = (int) (byte) (this.p >> 8);
                  w77[index78] = (byte) num124;
                  byte[] w78 = this.w;
                  int index79 = (int) num123;
                  uint num125 = (uint) (index79 + 1);
                  int p = (int) (byte) this.p;
                  w78[index79] = (byte) p;
                  byte[] w79 = this.w;
                  int index80 = (int) num125;
                  uint num126 = (uint) (index80 + 1);
                  int num127 = (int) (byte) ((uint) this.c >> 8);
                  w79[index80] = (byte) num127;
                  byte[] w80 = this.w;
                  int index81 = (int) num126;
                  uint num128 = (uint) (index81 + 1);
                  int c = (int) (byte) this.c;
                  w80[index81] = (byte) c;
                  byte[] w81 = this.w;
                  int index82 = (int) num128;
                  uint num129 = (uint) (index82 + 1);
                  w81[index82] = (byte) 0;
                  byte[] w82 = this.w;
                  int index83 = (int) num129;
                  uint num130 = (uint) (index83 + 1);
                  w82[index83] = (byte) 0;
                  byte[] w83 = this.w;
                  int index84 = (int) num130;
                  uint num131 = (uint) (index84 + 1);
                  w83[index84] = (byte) 0;
                  byte[] w84 = this.w;
                  int index85 = (int) num131;
                  num3 = (uint) (index85 + 1);
                  w84[index85] = (byte) 0;
                  num2 = (short) 2;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 15:
                  if (this.v.MultiInstanceEntries.Count <= 0)
                  {
                    byte[] w85 = this.w;
                    int index86 = (int) num3;
                    uint num132 = (uint) (index86 + 1);
                    w85[index86] = (byte) 0;
                    byte[] w86 = this.w;
                    int index87 = (int) num132;
                    uint num133 = (uint) (index87 + 1);
                    w86[index87] = (byte) 0;
                    byte[] w87 = this.w;
                    int index88 = (int) num133;
                    uint num134 = (uint) (index88 + 1);
                    w87[index88] = (byte) 0;
                    byte[] w88 = this.w;
                    int index89 = (int) num134;
                    num3 = (uint) (index89 + 1);
                    w88[index89] = (byte) 0;
                    num2 = (short) 20;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 6;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 16 /*0x10*/:
                  if (this.m >= 1U)
                  {
                    num2 = (short) 23;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 5;
                case 17:
                  enumerator = this.t.MultiInstanceEntries.GetEnumerator();
                  num2 = (short) 19;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 19:
                  try
                  {
                    num2 = (short) 3;
                    int num135 = (int) (IntPtr) num2;
                    while (true)
                    {
                      switch (num135)
                      {
                        case 0:
                          if (!enumerator.MoveNext())
                          {
                            num2 = (short) 4;
                            num135 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 29975;
                          int num136 = (int) num2;
                          num2 = (short) 29975;
                          int num137 = (int) num2;
                          switch (num136 == num137 ? 1 : 0)
                          {
                            case 0:
                            case 2:
                              goto label_29;
                            default:
                              num2 = (short) 0;
                              if (num2 == (short) 0)
                                ;
                              KeyValuePair<ushort, ushort> current = enumerator.Current;
                              this.w[(int) num3++] = (byte) ((uint) current.Key >> 8);
                              this.w[(int) num3++] = (byte) current.Key;
                              this.w[(int) num3++] = (byte) ((uint) current.Value >> 8);
                              this.w[(int) num3++] = (byte) current.Value;
                              num2 = (short) 1;
                              num135 = (int) (IntPtr) num2;
                              continue;
                          }
                        case 2:
                          goto label_12;
                        case 3:
label_29:
                          switch (0)
                          {
                            case 0:
                              break;
                            default:
                              continue;
                          }
                          break;
                        case 4:
                          num2 = (short) 2;
                          num135 = (int) (IntPtr) num2;
                          continue;
                      }
                      num2 = (short) 0;
                      num135 = (int) (IntPtr) num2;
                    }
                  }
                  finally
                  {
                    enumerator.Dispose();
                  }
                case 20:
                  goto label_56;
                case 21:
                  this.a -= 2U;
                  num2 = (short) 10;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 22:
                  if (index1 >= lifeTimeMax.Length)
                  {
                    num2 = (short) 3;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  ushort num138 = lifeTimeMax[index1];
                  byte[] w89 = this.w;
                  int index90 = (int) num3;
                  uint num139 = (uint) (index90 + 1);
                  int num140 = (int) (byte) ((uint) num138 >> 8);
                  w89[index90] = (byte) num140;
                  byte[] w90 = this.w;
                  int index91 = (int) num139;
                  num3 = (uint) (index91 + 1);
                  int num141 = (int) (byte) num138;
                  w90[index91] = (byte) num141;
                  ++index1;
                  num2 = (short) 8;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 23:
                  --this.m;
                  num2 = (short) 5;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 24:
                  if (this.t.MultiInstanceEntries.Count > 0)
                  {
                    num2 = (short) 17;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  byte[] w91 = this.w;
                  int index92 = (int) num3;
                  uint num142 = (uint) (index92 + 1);
                  w91[index92] = (byte) 0;
                  byte[] w92 = this.w;
                  int index93 = (int) num142;
                  uint num143 = (uint) (index93 + 1);
                  w92[index93] = (byte) 0;
                  byte[] w93 = this.w;
                  int index94 = (int) num143;
                  uint num144 = (uint) (index94 + 1);
                  w93[index94] = (byte) 0;
                  byte[] w94 = this.w;
                  int index95 = (int) num144;
                  num3 = (uint) (index95 + 1);
                  w94[index95] = (byte) 0;
                  num2 = (short) 0;
                  num2 = (short) 14;
                  num1 = (int) (IntPtr) num2;
                  continue;
                default:
                  goto label_3;
              }
            }
label_18:
            try
            {
              num2 = (short) 3;
              int num145 = (int) (IntPtr) num2;
              while (true)
              {
                switch (num145)
                {
                  case 1:
                    num2 = (short) 2;
                    num145 = (int) (IntPtr) num2;
                    continue;
                  case 2:
                    goto label_56;
                  case 3:
                    switch (0)
                    {
                      case 0:
                        break;
                      default:
                        continue;
                    }
                    break;
                  case 4:
                    if (enumerator.MoveNext())
                    {
                      KeyValuePair<ushort, ushort> current = enumerator.Current;
                      byte[] w95 = this.w;
                      int index96 = (int) num3;
                      uint num146 = (uint) (index96 + 1);
                      int num147 = (int) (byte) ((uint) current.Key >> 8);
                      w95[index96] = (byte) num147;
                      byte[] w96 = this.w;
                      int index97 = (int) num146;
                      uint num148 = (uint) (index97 + 1);
                      int key = (int) (byte) current.Key;
                      w96[index97] = (byte) key;
                      byte[] w97 = this.w;
                      int index98 = (int) num148;
                      uint num149 = (uint) (index98 + 1);
                      int num150 = (int) (byte) ((uint) current.Value >> 8);
                      w97[index98] = (byte) num150;
                      byte[] w98 = this.w;
                      int index99 = (int) num149;
                      num3 = (uint) (index99 + 1);
                      int num151 = (int) (byte) current.Value;
                      w98[index99] = (byte) num151;
                      num2 = (short) 0;
                      num145 = (int) (IntPtr) num2;
                      continue;
                    }
                    num2 = (short) 1;
                    num145 = (int) (IntPtr) num2;
                    continue;
                }
                num2 = (short) 4;
                num145 = (int) (IntPtr) num2;
              }
            }
            finally
            {
              enumerator.Dispose();
            }
label_56:
            return this.w;
        }
    }
  }
}
