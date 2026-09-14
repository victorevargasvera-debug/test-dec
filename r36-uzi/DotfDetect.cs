// Decompiled with JetBrains decompiler
// Type: MackinawCPS.DotfDetect
// Assembly: APXFamilyCPS, Version=36.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 9359335E-041C-4B12-9409-F4E6E7D93299
// Assembly location: C:\Program Files (x86)\Motorola\ApxFamilyCPS R36.00\APXFamilyCPS1.exe

#nullable disable
namespace MackinawCPS;

public class DotfDetect
{
  internal static void handle(bool isTampered) => AcpUtility.DotfDetect.handle(isTampered);
}
