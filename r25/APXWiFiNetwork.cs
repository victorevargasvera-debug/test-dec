// Decompiled with JetBrains decompiler
// Type: MackinawCPS.APXWiFiNetwork
// Assembly: APXFamilyCPS, Version=15.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 7983BD42-76AB-479D-8966-B7B635E0E28A
// Assembly location: C:\Program Files (x86)\Motorola\APX Dpt 25\APXFamilyCPS.exe

using System;

#nullable disable
namespace MackinawCPS;

[Serializable]
public class APXWiFiNetwork
{
  public static readonly int SECURITY_TYPE_NONE = 0;

  public string NetworkSSID { get; set; }

  public string NetworkPWD { get; set; }

  public int NetworkSecureType { get; set; }
}
