// Decompiled with JetBrains decompiler
// Type: AcpBusinessLayer.VAUtilities
// Assembly: AcpBusinessLayer, Version=23.1.0.23, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 44CF2A76-4418-422B-9DDD-B27A71BAF20C
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpBusinessLayer.dll

using System;

#nullable disable
namespace AcpBusinessLayer;

public static class VAUtilities
{
  internal static byte[] StrToByteArray(string str)
  {
    return str == null || str == string.Empty ? (byte[]) null : Convert.FromBase64String(str);
  }

  internal static string ByteArrayToStr(byte[] byteArr, int length)
  {
    return byteArr == null ? string.Empty : Convert.ToBase64String(byteArr, 0, length);
  }
}
