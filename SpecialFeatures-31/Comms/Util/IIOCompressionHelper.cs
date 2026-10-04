// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.Comms.Util.IIOCompressionHelper
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using System.IO.Compression;

#nullable disable
namespace SpecialFeatures.Comms.Util;

public interface IIOCompressionHelper
{
  ZipArchive OpenRead(string path);
}
