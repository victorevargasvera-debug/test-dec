// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.Comms.IDeviceManager
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using Motorola.Common.Communication.CommonUtil;
using SSLMangrComp;
using System;

#nullable disable
namespace SpecialFeatures.Comms;

public interface IDeviceManager
{
  DeviceInfo[] GetAllConnectedDevice();

  PresenceNotification RetrievePresenceInfo(PNConnectionInfo connectionConfig);

  IDeviceProxy CreateDeviceProxy(RadioParams radioPara, RadioOperation radioOp);

  event EventHandler<DeviceEventArgs> DeviceConnectedEvent;

  event EventHandler<DeviceEventArgs> DeviceLostEvent;
}
