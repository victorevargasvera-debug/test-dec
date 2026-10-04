// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.Clone_Configuration.Common.CodeplugData
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using Motorola.CommonCPS.Server.EntityModel;
using System.Collections.Generic;

#nullable disable
namespace SpecialFeatures.Clone_Configuration.Common;

public class CodeplugData
{
  public string purchasedFlashcode;
  public string usedFlashcode;
  public string modelNumber;
  public List<AstroRecSetCountsItem> recSetCounts;
  public APXCodeplug _data;
}
