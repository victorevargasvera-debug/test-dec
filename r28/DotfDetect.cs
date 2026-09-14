// Decompiled with JetBrains decompiler
// Type: MackinawCPS.DotfDetect
// Assembly: APXFamilyCPS, Version=15.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 7983BD42-76AB-479D-8966-B7B635E0E28A
// Assembly location: C:\Program Files (x86)\Motorola\ApxFamilyDepot R28\APXdepotR28.exe

#nullable disable
namespace MackinawCPS;

public class DotfDetect
{
  internal static void handle(bool isTampered) => AcpUtility.DotfDetect.handle(isTampered);
}
