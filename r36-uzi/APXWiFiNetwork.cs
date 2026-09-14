// Decompiled with JetBrains decompiler
// Type: MackinawCPS.APXWiFiNetwork
// Assembly: APXFamilyCPS, Version=36.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 9359335E-041C-4B12-9409-F4E6E7D93299
// Assembly location: C:\Program Files (x86)\Motorola\ApxFamilyCPS R36.00\APXFamilyCPS1.exe

using System;

#nullable disable
namespace MackinawCPS;

[Serializable]
public class APXWiFiNetwork
{
  public static readonly int SECURITY_TYPE_NONE;

  public string NetworkSSID { get; set; }

  public string NetworkPWD { get; set; }

  public int NetworkSecureType { get; set; }

  public bool NetworkHidden { get; set; }
}
