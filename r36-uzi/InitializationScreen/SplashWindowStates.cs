// Decompiled with JetBrains decompiler
// Type: MackinawCPS.InitializationScreen.SplashWindowStates
// Assembly: APXFamilyCPS, Version=36.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 9359335E-041C-4B12-9409-F4E6E7D93299
// Assembly location: C:\Program Files (x86)\Motorola\ApxFamilyCPS R36.00\APXFamilyCPS1.exe

#nullable disable
namespace MackinawCPS.InitializationScreen;

internal enum SplashWindowStates
{
  WAIT_FOR_ACTIVATE,
  SHOWN,
  SHOWN_MINIMUM_TIME_HIT,
  SHOWN_MAXIMUM_TIME_HIT,
  CLOSING_FADE_DELAY,
  CLOSING_WITH_FADE,
  CLOSED,
}
