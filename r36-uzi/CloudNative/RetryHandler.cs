// Decompiled with JetBrains decompiler
// Type: MackinawCPS.CloudNative.RetryHandler
// Assembly: APXFamilyCPS, Version=36.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 9359335E-041C-4B12-9409-F4E6E7D93299
// Assembly location: C:\Program Files (x86)\Motorola\ApxFamilyCPS R36.00\APXFamilyCPS1.exe

using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

#nullable disable
namespace MackinawCPS.CloudNative;

public class RetryHandler(HttpMessageHandler innerHandler) : DelegatingHandler(innerHandler)
{
  private const int MaxRetries = 3;

  protected override async Task<HttpResponseMessage> SendAsync(
    HttpRequestMessage request,
    CancellationToken cancellationToken)
  {
    HttpResponseMessage httpResponseMessage = (HttpResponseMessage) null;
    for (int i = 0; i < 3; ++i)
    {
      Thread.Sleep((i + 1) * 1000);
      httpResponseMessage = await base.SendAsync(request, cancellationToken);
      if (httpResponseMessage.IsSuccessStatusCode)
        return httpResponseMessage;
    }
    return httpResponseMessage;
  }
}
