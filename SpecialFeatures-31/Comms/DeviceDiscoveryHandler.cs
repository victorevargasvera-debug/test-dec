// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.Comms.DeviceDiscoveryHandler
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using Motorola.Common.Communication.CommonUtil;
using Motorola.Common.Communication.Service;
using System;
using System.ServiceModel;

#nullable disable
namespace SpecialFeatures.Comms;

[CallbackBehavior(UseSynchronizationContext = false)]
public class DeviceDiscoveryHandler : IDiscoveryServiceEvent
{
  internal EventHandler<DeviceEventArgs> DeviceConnectedEventHandler
  {
    get
    {
      switch (true)
      {
        case true:
          if (true)
            ;
          if (false)
            ;
          return this.a;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = 0;
      num1 = (short) 18080;
      int num2 = (int) num1;
      num1 = (short) 18080;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          num1 = (short) 1;
          if (num1 == (short) 0)
            ;
          this.a = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  internal EventHandler<DeviceEventArgs> DeviceLostEventHandler
  {
    get
    {
      short num1 = 0;
      num1 = (short) 10531;
      int num2 = (int) num1;
      num1 = (short) 10531;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          num1 = (short) 1;
          if (num1 == (short) 0)
            ;
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          return this.b;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = 0;
      num1 = (short) 25150;
      int num2 = (int) num1;
      num1 = (short) 25150;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          num1 = (short) 1;
          if (num1 == (short) 0)
            ;
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          this.b = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  public void OnDeviceConnected(DeviceEventArgs args)
  {
    short num1 = 0;
    num1 = (short) 0;
    int num2 = (int) (IntPtr) num1;
    while (true)
    {
      switch (num2)
      {
        case 0:
          switch (0)
          {
            case 0:
              break;
            default:
              continue;
          }
          break;
        case 1:
          goto label_12;
        case 2:
          num1 = (short) 1;
          if (num1 == (short) 0)
            ;
          this.DeviceConnectedEventHandler((object) this, args);
          num1 = (short) -12126;
          int num3 = (int) num1;
          num1 = (short) -12126;
          int num4 = (int) num1;
          switch (num3 == num4 ? 1 : 0)
          {
            case 0:
              goto label_5;
            case 2:
              goto label_11;
            default:
              num1 = (short) 0;
              if (num1 == (short) 0)
                ;
              num1 = (short) 1;
              num2 = (int) (IntPtr) num1;
              continue;
          }
      }
      if (this.DeviceConnectedEventHandler != null)
      {
        num1 = (short) 2;
        num2 = (int) (IntPtr) num1;
      }
      else
        goto label_10;
    }
label_12:
    return;
label_10:
    return;
label_5:
    return;
label_11:;
  }

  public void OnDeviceLost(DeviceEventArgs args)
  {
    short num1 = 0;
    num1 = (short) 0;
    int num2 = (int) (IntPtr) num1;
    while (true)
    {
      switch (num2)
      {
        case 0:
          switch (0)
          {
            case 0:
              break;
            default:
              continue;
          }
          break;
        case 1:
          goto label_12;
        case 2:
          this.DeviceLostEventHandler((object) this, args);
          num1 = (short) -21401;
          int num3 = (int) num1;
          num1 = (short) -21401;
          int num4 = (int) num1;
          switch (num3 == num4 ? 1 : 0)
          {
            case 0:
              goto label_5;
            case 2:
              goto label_11;
            default:
              num1 = (short) 0;
              if (num1 == (short) 0)
                ;
              num1 = (short) 1;
              if (num1 == (short) 0)
                ;
              num1 = (short) 1;
              num2 = (int) (IntPtr) num1;
              continue;
          }
      }
      if (this.DeviceLostEventHandler != null)
      {
        num1 = (short) 2;
        num2 = (int) (IntPtr) num1;
      }
      else
        goto label_10;
    }
label_12:
    return;
label_10:
    return;
label_5:
    return;
label_11:;
  }

  public void OnDeviceSwitchOver(SwitchOverEventArgs args)
  {
    short num1 = 0;
    num1 = (short) -1192;
    int num2 = (int) num1;
    num1 = (short) -1192;
    int num3 = (int) num1;
    switch (num2 == num3)
    {
      case true:
        num1 = (short) 0;
        if (num1 == (short) 0)
          ;
        num1 = (short) 1;
        if (num1 == (short) 0)
          break;
        break;
      default:
        goto case 1;
    }
  }

  public void OnMasterSystemLost(DeviceEventArgs args)
  {
    short num = -19032;
    switch ((short) -19032 == num)
    {
      case true:
        num = (short) 1;
        if (num == (short) 0)
          ;
        num = (short) 0;
        if (num == (short) 0)
          break;
        break;
      default:
        goto case 1;
    }
  }
}
