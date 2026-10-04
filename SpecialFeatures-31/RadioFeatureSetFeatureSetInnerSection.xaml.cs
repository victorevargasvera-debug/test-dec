// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.RadioFeatureSet.FeatureSetInnerSection
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using CommonResources;
using SpecialFeatures.AcpReportManagerLib;
using SpecialFeatures.Flashport;

#nullable disable
namespace SpecialFeatures.RadioFeatureSet;

public sealed partial class FeatureSetInnerSection : FeatureSection
{
  private Field a;
  private Field b;

  internal FeatureSetInnerSection(FeatureNode parent)
    : base(parent)
  {
    this.Init();
    this.a();
  }

  private void a()
  {
    short num1 = 13975;
    int num2 = (int) num1;
    num1 = (short) 13975;
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
        this.a.Value = AppResources.N_A;
        this.b.Value = AppResources.N_A;
        break;
      default:
        goto case 1;
    }
  }

  public override void Init()
  {
    int A_1 = 4;
    short num1 = -20340;
    int num2 = (int) num1;
    num1 = (short) -20340;
    int num3 = (int) num1;
    switch (num2 == num3)
    {
      case true:
        if (false)
          ;
        if (true)
          ;
        this.a = new Field(AppResources.Purchased_Feature, true);
        this.b = new Field(AppResources.Enabled_in_Used_FLASHcode, true);
        this.FeatureSectionName = RptMgrErrorHandler.b("솆\uEC88\uEA8A歷搜\uE390\uF692요\uF296\uED98", A_1);
        this.Id = 32 /*0x20*/;
        this.UIName = AppResources.FeatureSet_Id;
        break;
      default:
        goto case 1;
    }
  }

  public string FeatureSetPurchasedFeatureNameValue
  {
    get
    {
      short num1 = 9738;
      int num2 = (int) num1;
      num1 = (short) 9738;
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
          return this.a.Value;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = -26221;
      int num2 = (int) num1;
      num1 = (short) -26221;
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
          this.a.Value = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  public Field FeatureSetPurchasedFeatureName
  {
    get
    {
      short num1 = 24870;
      int num2 = (int) num1;
      num1 = (short) 24870;
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
          return this.a;
        default:
          goto case 1;
      }
    }
  }

  public string FeatureSetPurchasedFeatureName_UIValue
  {
    get
    {
      short num1 = 18215;
      int num2 = (int) num1;
      num1 = (short) 18215;
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
          return this.a.Value;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = 13572;
      int num2 = (int) num1;
      num1 = (short) 13572;
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
          this.a.Value = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  public bool FeatureSetPurchasedFeatureName_Applicable
  {
    get
    {
      short num1 = 9269;
      int num2 = (int) num1;
      num1 = (short) 9269;
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
          return true;
        default:
          goto case 1;
      }
    }
  }

  public bool FeatureSetPurchasedFeatureName_Valid
  {
    get
    {
      short num1 = 6225;
      int num2 = (int) num1;
      num1 = (short) 6225;
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
          return true;
        default:
          goto case 1;
      }
    }
  }

  public bool FeatureSetPurchasedFeatureName_Visible
  {
    get
    {
      short num1 = 3337;
      int num2 = (int) num1;
      num1 = (short) 3337;
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
          return true;
        default:
          goto case 1;
      }
    }
  }

  public bool FeatureSetPurchasedFeatureName_Editable
  {
    get
    {
      short num1 = -28913;
      int num2 = (int) num1;
      num1 = (short) -28913;
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
          return false;
        default:
          goto case 1;
      }
    }
  }

  public string FeatureSetPurchasedFeatureName_UILabel
  {
    get
    {
      short num1 = 154;
      int num2 = (int) num1;
      num1 = (short) 154;
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
          return this.a.UIName;
        default:
          goto case 1;
      }
    }
  }

  public string FeatureSetEnabledInUsedFlashcodeValue
  {
    get
    {
      short num1 = 10652;
      int num2 = (int) num1;
      num1 = (short) 10652;
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
          return this.b.Value;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = 16248;
      int num2 = (int) num1;
      num1 = (short) 16248;
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
          this.b.Value = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  public Field FeatureSetEnabledInUsedFlashcode
  {
    get
    {
      short num1 = 26527;
      int num2 = (int) num1;
      num1 = (short) 26527;
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
  }

  public string FeatureSetEnabledInUsedFlashcode_UIValue
  {
    get
    {
      short num1 = -17884;
      int num2 = (int) num1;
      num1 = (short) -17884;
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
          return this.b.Value;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = 8872;
      int num2 = (int) num1;
      num1 = (short) 8872;
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
          this.b.Value = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  public bool FeatureSetEnabledInUsedFlashcode_Applicable
  {
    get
    {
      short num1 = 12012;
      int num2 = (int) num1;
      num1 = (short) 12012;
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
          return true;
        default:
          goto case 1;
      }
    }
  }

  public bool FeatureSetEnabledInUsedFlashcode_Valid
  {
    get
    {
      short num1 = 0;
      num1 = (short) -14598;
      int num2 = (int) num1;
      num1 = (short) -14598;
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
          return true;
        default:
          goto case 1;
      }
    }
  }

  public bool FeatureSetEnabledInUsedFlashcode_Visible
  {
    get
    {
      short num1 = 0;
      num1 = (short) 1;
      if (num1 == (short) 0)
        ;
      num1 = (short) -8065;
      int num2 = (int) num1;
      num1 = (short) -8065;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          return true;
        default:
          goto case 1;
      }
    }
  }

  public bool FeatureSetEnabledInUsedFlashcode_Editable
  {
    get
    {
      short num = -20586;
      switch ((short) -20586 == num)
      {
        case true:
          num = (short) 1;
          if (num == (short) 0)
            ;
          num = (short) 0;
          if (num == (short) 0)
            ;
          return false;
        default:
          goto case 1;
      }
    }
  }

  public string FeatureSetEnabledInUsedFlashcode_UILabel
  {
    get
    {
      short num1 = 0;
      num1 = (short) 28105;
      int num2 = (int) num1;
      num1 = (short) 28105;
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
          return this.b.UIName;
        default:
          goto case 1;
      }
    }
  }
}
