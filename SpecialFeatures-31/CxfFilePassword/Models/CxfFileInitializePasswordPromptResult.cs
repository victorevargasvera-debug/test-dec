// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.CxfFilePassword.Models.CxfFileInitializePasswordPromptResult
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using System.Security;

#nullable disable
namespace SpecialFeatures.CxfFilePassword.Models;

internal class CxfFileInitializePasswordPromptResult : CxfFilePasswordPromptResult
{
  internal SecureString ConfirmedProvidedPassword
  {
    get
    {
      short num1 = -23142;
      int num2 = (int) num1;
      num1 = (short) -23142;
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
          return this.a;
        default:
          num4 = (short) 0;
          goto case 1;
      }
    }
    set
    {
      short num1 = -25182;
      int num2 = (int) num1;
      num1 = (short) -25182;
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
          this.a = value;
          break;
        default:
          num4 = (short) 0;
          goto case 1;
      }
    }
  }
}
