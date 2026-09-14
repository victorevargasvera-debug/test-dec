// Decompiled with JetBrains decompiler
// Type: MackinawCPS.InitializationScreen.SplashWindowStates
// Assembly: APXFamilyCPS, Version=15.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 7983BD42-76AB-479D-8966-B7B635E0E28A
// Assembly location: C:\Program Files (x86)\Motorola\APX Dpt 25\APXFamilyCPS.exe

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
