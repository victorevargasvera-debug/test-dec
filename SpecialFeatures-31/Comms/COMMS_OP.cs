// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.Comms.COMMS_OP
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

#nullable disable
namespace SpecialFeatures.Comms;

public enum COMMS_OP
{
  USB_READ_WRITE = 1,
  USB_CLONE = 2,
  OTAP_READ_WRITE = 8,
  OTAP_CLONE = 10, // 0x0000000A
  BLUETOOTH_READ_WRITE = 16, // 0x00000010
  BLUETOOTH_CLONE = 32, // 0x00000020
}
