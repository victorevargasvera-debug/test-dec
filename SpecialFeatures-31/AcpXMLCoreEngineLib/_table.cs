// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.AcpXMLCoreEngineLib._table
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using System.Collections.Generic;

#nullable disable
namespace SpecialFeatures.AcpXMLCoreEngineLib;

public class _table : _RecSet
{
  private string a = "";
  internal List<_RecSet> RecSet = new List<_RecSet>();
  internal List<string> ColTitle = new List<string>();

  internal string TableTitle
  {
    get
    {
      short num1 = 1;
      if (num1 == (short) 0)
        ;
      num1 = (short) -8517;
      int num2 = (int) num1;
      num1 = (short) -8517;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          return this.a;
        default:
          num1 = (short) 0;
          goto case 1;
      }
    }
    set
    {
      short num1 = -669;
      int num2 = (int) num1;
      num1 = (short) -669;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          short num4 = 0;
          num4 = (short) 0;
          if (num4 == (short) 0)
            ;
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
}
