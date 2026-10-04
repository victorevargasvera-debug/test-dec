// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.Comms.Util.IOCompressionHelper
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using System.IO.Compression;

#nullable disable
namespace SpecialFeatures.Comms.Util;

public class IOCompressionHelper : IIOCompressionHelper
{
  public ZipArchive OpenRead(string path)
  {
    short num1 = 7367;
    int num2 = (int) num1;
    num1 = (short) 7367;
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
        return ZipFile.OpenRead(path);
      default:
        goto case 1;
    }
  }
}
