// Decompiled with JetBrains decompiler
// Type: MackinawCPS.CloudNative.CloudNativeHeaders
// Assembly: APXFamilyCPS, Version=36.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 9359335E-041C-4B12-9409-F4E6E7D93299
// Assembly location: C:\Program Files (x86)\Motorola\ApxFamilyCPS R36.00\APXFamilyCPS1.exe

using System.Linq;
using System.Net.Http.Headers;

#nullable disable
namespace MackinawCPS.CloudNative;

public class CloudNativeHeaders
{
  public CloudNativeHeaders()
  {
  }

  public CloudNativeHeaders(HttpResponseHeaders httpResponseHeaders)
  {
    this.Nonce = httpResponseHeaders.GetValues("msi-rc-cpsbridge-nonce").FirstOrDefault<string>();
    this.BridgeHash = httpResponseHeaders.GetValues("msi-rc-cpsbridge-auth").FirstOrDefault<string>();
  }

  public string Nonce { get; set; }

  public string BridgeHash { get; set; }
}
