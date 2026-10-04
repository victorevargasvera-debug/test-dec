// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.Clone_Configuration.Common.AstroRecSetCountsItem
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

#nullable disable
namespace SpecialFeatures.Clone_Configuration.Common;

public class AstroRecSetCountsItem
{
  public int _count;
  public int _maxPool;
  public int _counterToMaxPool;
  public int _recSetInstanceNo;
  public string _recSetName;

  public AstroRecSetCountsItem(
    string recsetName,
    int instance,
    int count,
    int maxpool,
    int countToMaxPool)
  {
    this._recSetName = recsetName;
    this._recSetInstanceNo = instance;
    this._count = count;
    this._maxPool = maxpool;
    this._counterToMaxPool = countToMaxPool;
  }
}
