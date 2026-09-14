// Decompiled with JetBrains decompiler
// Type: MackinawCPS.CloudNative.CloudNativeParameters
// Assembly: APXFamilyCPS, Version=36.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 9359335E-041C-4B12-9409-F4E6E7D93299
// Assembly location: C:\Program Files (x86)\Motorola\ApxFamilyCPS R36.00\APXFamilyCPS1.exe

using System.IO;

#nullable disable
namespace MackinawCPS.CloudNative;

internal static class CloudNativeParameters
{
  public static CloudNativeHeaders CloudNativeHeaders = new CloudNativeHeaders();
  public static CloudNativeJobWrapper CloudNativeJobWrapper = new CloudNativeJobWrapper();
  public static byte[] CloudNativeCodeplugBytes = (byte[]) null;
  public static MemoryStream CloudNativeCodeplugMemoryStream = (MemoryStream) null;
  public static string RcCpsBridgeGetSessionUrl = string.Empty;
  public static string RcCpsBridgeGetFileUrl = string.Empty;
  public static string RcCpsBridgePostSessionUrl = string.Empty;
}
