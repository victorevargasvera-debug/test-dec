// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.CxfFilePassword.Models.CxfFilePasswordPromptResult
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using System.Security;

#nullable disable
namespace SpecialFeatures.CxfFilePassword.Models;

internal class CxfFilePasswordPromptResult
{
  internal SecureString ProvidedPassword
  {
    get
    {
      short num1 = -16824;
      int num2 = (int) num1;
      num1 = (short) -16824;
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
      short num1 = -23187;
      int num2 = (int) num1;
      num1 = (short) -23187;
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
          this.a = value;
          break;
        default:
          num4 = (short) 0;
          goto case 1;
      }
    }
  }

  internal bool Cancelled
  {
    get
    {
      short num1 = 29523;
      int num2 = (int) num1;
      num1 = (short) 29523;
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
          return this.b;
        default:
          num4 = (short) 0;
          goto case 1;
      }
    }
    set
    {
      short num1 = -7994;
      int num2 = (int) num1;
      num1 = (short) -7994;
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
          this.b = value;
          break;
        default:
          num4 = (short) 0;
          goto case 1;
      }
    }
  }

  internal bool RememberCxfFilePassword
  {
    get
    {
      short num1 = 1;
      if (num1 == (short) 0)
        ;
      num1 = (short) 0;
      num1 = (short) 28880;
      int num2 = (int) num1;
      num1 = (short) 28880;
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
      short num1 = -5961;
      int num2 = (int) num1;
      num1 = (short) -5961;
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
          this.c = value;
          break;
        default:
          num4 = (short) 0;
          goto case 1;
      }
    }
  }
}
