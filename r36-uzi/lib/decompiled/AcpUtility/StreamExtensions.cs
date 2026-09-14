// Decompiled with JetBrains decompiler
// Type: AcpUtility.StreamExtensions
// Assembly: AcpUtility, Version=1.2.0.9, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0374A65F-E929-4173-BF51-69A629A9A82D
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUtility.dll

using System.IO;

#nullable disable
namespace AcpUtility;

public static class StreamExtensions
{
  public static byte[] ReadRequestedBytes(this Stream stream, int count)
  {
    int count1 = count;
    byte[] buffer = new byte[count];
    int offset = 0;
    int num;
    for (; count1 > 0; count1 -= num)
    {
      num = stream.Read(buffer, offset, count1);
      if (num != 0)
        offset += num;
      else
        break;
    }
    return buffer;
  }
}
