// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.Comms.BluetoothPANProgramming
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

#nullable disable
namespace SpecialFeatures.Comms;

public class BluetoothPANProgramming
{
  public static string BluetoothPANIPForWR
  {
    get
    {
      short num1 = -28780;
      int num2 = (int) num1;
      num1 = (short) -28780;
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
          return BluetoothPANProgramming.a;
        default:
          num4 = (short) 0;
          goto case 1;
      }
    }
    set
    {
      short num1 = 1;
      if (num1 == (short) 0)
        ;
      num1 = (short) 0;
      num1 = (short) 15479;
      int num2 = (int) num1;
      num1 = (short) 15479;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          BluetoothPANProgramming.a = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  public static string BluetoothPANIPForClone
  {
    get
    {
      short num1 = 13348;
      int num2 = (int) num1;
      num1 = (short) 13348;
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
          return BluetoothPANProgramming.b;
        default:
          num4 = (short) 0;
          goto case 1;
      }
    }
    set
    {
      short num1 = -27529;
      int num2 = (int) num1;
      num1 = (short) -27529;
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
          BluetoothPANProgramming.b = value;
          break;
        default:
          num4 = (short) 0;
          goto case 1;
      }
    }
  }
}
