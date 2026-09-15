// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.AcpReportManagerLib.RptTreeViewItem
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using System.Collections.Generic;
using System.Windows.Controls;

#nullable disable
namespace SpecialFeatures.AcpReportManagerLib;

public class RptTreeViewItem : TreeViewItem
{
  private int a;
  private int b;
  private string c;
  private int d;
  private string e;
  private Dictionary<string, string> f = new Dictionary<string, string>();

  internal string RptPath
  {
    get
    {
      short num1 = 6967;
      int num2 = (int) num1;
      num1 = (short) 6967;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          short num4 = 1;
          if (num4 == (short) 0)
            ;
          num4 = (short) 0;
          num4 = (short) 0;
          if (num4 == (short) 0)
            ;
          return this.e;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = -3947;
      int num2 = (int) num1;
      num1 = (short) -3947;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          short num4 = 0;
          if (num4 == (short) 0)
            ;
          num4 = (short) 0;
          num4 = (short) 1;
          if (num4 == (short) 0)
            ;
          this.e = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  internal string RptRecordName
  {
    get
    {
      short num1 = -508;
      int num2 = (int) num1;
      num1 = (short) -508;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          short num4 = 0;
          if (num4 == (short) 0)
            ;
          num4 = (short) 0;
          num4 = (short) 1;
          if (num4 == (short) 0)
            ;
          return this.c;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = 17716;
      int num2 = (int) num1;
      num1 = (short) 17716;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          short num4 = 1;
          if (num4 == (short) 0)
            ;
          num4 = (short) 0;
          num4 = (short) 0;
          if (num4 == (short) 0)
            ;
          this.c = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  internal int ItemType
  {
    get
    {
      short num1 = -20514;
      int num2 = (int) num1;
      num1 = (short) -20514;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          short num4 = 1;
          if (num4 == (short) 0)
            ;
          num4 = (short) 0;
          num4 = (short) 0;
          if (num4 == (short) 0)
            ;
          return this.d;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = -2307;
      int num2 = (int) num1;
      num1 = (short) -2307;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          short num4 = 1;
          if (num4 == (short) 0)
            ;
          num4 = (short) 0;
          num4 = (short) 0;
          if (num4 == (short) 0)
            ;
          this.d = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  internal int ID
  {
    get
    {
      short num1 = 27677;
      int num2 = (int) num1;
      num1 = (short) 27677;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          short num4 = 0;
          if (num4 == (short) 0)
            ;
          num4 = (short) 0;
          num4 = (short) 1;
          if (num4 == (short) 0)
            ;
          return this.a;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = 15105;
      int num2 = (int) num1;
      num1 = (short) 15105;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          short num4 = 1;
          if (num4 == (short) 0)
            ;
          num4 = (short) 0;
          num4 = (short) 0;
          if (num4 == (short) 0)
            ;
          this.a = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  internal int ParentID
  {
    get
    {
      short num1 = 4182;
      int num2 = (int) num1;
      num1 = (short) 4182;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          short num4 = 0;
          if (num4 == (short) 0)
            ;
          num4 = (short) 0;
          num4 = (short) 1;
          if (num4 == (short) 0)
            ;
          return this.b;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = 6517;
      int num2 = (int) num1;
      num1 = (short) 6517;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          short num4 = 1;
          if (num4 == (short) 0)
            ;
          num4 = (short) 0;
          num4 = (short) 0;
          if (num4 == (short) 0)
            ;
          this.b = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  public RptTreeViewItem()
  {
    this.RptPath = "";
    this.RptRecordName = "";
    this.ItemType = 0;
    this.ID = 0;
    this.ParentID = 0;
  }
}
