// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.DdiltBuilder.DDILTComparer
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SpecialFeatures.DdiltBuilder;

public class DDILTComparer : IComparer<ushort>
{
  public int Compare(ushort x, ushort y)
  {
    int num1;
    int num2;
    short num3;
    switch (0)
    {
      case 0:
label_2:
        num2 = -1;
        num3 = (short) 3;
        num1 = (int) (IntPtr) num3;
        goto default;
      default:
        while (true)
        {
          switch (num1)
          {
            case 0:
              num3 = (short) 0;
              num3 = (short) 1;
              if (num3 == (short) 0)
                ;
              if ((int) x == (int) y)
              {
                num3 = (short) 4;
                num1 = (int) (IntPtr) num3;
                continue;
              }
              goto label_13;
            case 1:
              goto label_13;
            case 2:
              num3 = (short) 0;
              num1 = (int) (IntPtr) num3;
              continue;
            case 3:
              if ((int) x < (int) y)
              {
                num3 = (short) -2591;
                int num4 = (int) num3;
                num3 = (short) -2591;
                int num5 = (int) num3;
                switch (num4 == num5 ? 1 : 0)
                {
                  case 0:
                  case 2:
                    goto label_7;
                  default:
                    num3 = (short) 0;
                    if (num3 == (short) 0)
                      ;
                    num3 = (short) 5;
                    num1 = (int) (IntPtr) num3;
                    continue;
                }
              }
              else
                goto case 2;
            case 4:
label_7:
              num2 = 0;
              num3 = (short) 1;
              num1 = (int) (IntPtr) num3;
              continue;
            case 5:
              num2 = 1;
              num3 = (short) 2;
              num1 = (int) (IntPtr) num3;
              continue;
            default:
              goto label_2;
          }
        }
label_13:
        return num2;
    }
  }
}
