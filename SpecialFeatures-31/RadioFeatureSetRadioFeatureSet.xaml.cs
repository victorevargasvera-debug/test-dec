// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.RadioFeatureSet.RadioFeatureSet
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using CommonResources;
using SpecialFeatures.AcpReportManagerLib;
using SpecialFeatures.Flashport;

#nullable disable
namespace SpecialFeatures.RadioFeatureSet;

public partial class RadioFeatureSet : FeatureNode
{
  internal RadioFeatureSet(Recordset parent)
  {
    int A_1 = 17;
    // ISSUE: explicit constructor call
    base.\u002Ector(parent);
    this.FeatureName = RptMgrErrorHandler.b("힓秊ﲗﾙ\uEC9B\uF29D햟얡蒣\uE0A5춧쮩\uD8AB\uDBAD슯ힱ钳\uE5B5\uDDB7캹", A_1);
    this.UIName = AppResources.Codeplug_Feature_Set;
    this.AddFeatureSection((FeatureSection) new General((FeatureNode) this));
    this.AddFeatureSection((FeatureSection) new FeatureSet((FeatureNode) this));
    this.AddFeatureSection((FeatureSection) new ExtendedFeatureSet((FeatureNode) this));
  }

  public FeatureSet FeatureSet
  {
    get
    {
      short num1 = 11991;
      int num2 = (int) num1;
      num1 = (short) 11991;
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
          return (FeatureSet) this[30];
        default:
          goto case 1;
      }
    }
  }

  public General General
  {
    get
    {
      short num1 = 15188;
      int num2 = (int) num1;
      num1 = (short) 15188;
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
          return (General) this[31 /*0x1F*/];
        default:
          goto case 1;
      }
    }
  }

  public ExtendedFeatureSet ExtendedFeatureSet
  {
    get
    {
      short num1 = 12385;
      int num2 = (int) num1;
      num1 = (short) 12385;
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
          return (ExtendedFeatureSet) this[33];
        default:
          goto case 1;
      }
    }
  }
}
