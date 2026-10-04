// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.Comms.DeviceManagerSingleTon
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using System;
using System.Threading;

#nullable disable
namespace SpecialFeatures.Comms;

public static class DeviceManagerSingleTon
{
  private static IDeviceManager a;
  private static object b;

  public static IDeviceManager Instance
  {
    get
    {
      int num1 = 2;
      object b;
      bool lockTaken;
      while (true)
      {
        short num2;
        switch (num1)
        {
          case 0:
            num2 = (short) 0;
            num2 = (short) 1;
            if (num2 == (short) 0)
              ;
            b = DeviceManagerSingleTon.b;
            lockTaken = false;
            num2 = (short) 1;
            num1 = (int) (IntPtr) num2;
            continue;
          case 1:
            goto label_6;
          case 2:
            switch (0)
            {
              case 0:
                break;
              default:
                continue;
            }
            break;
        }
        if (DeviceManagerSingleTon.a == null)
        {
          num2 = (short) 0;
          num1 = (int) (IntPtr) num2;
        }
        else
          goto label_17;
      }
label_6:
      try
      {
        Monitor.Enter(b, ref lockTaken);
        DeviceManagerSingleTon.a = (IDeviceManager) new DeviceManager();
      }
      finally
      {
        int num3 = 2;
        while (true)
        {
          switch (num3)
          {
            case 0:
              switch (true ? 1 : 0)
              {
                case 0:
                case 2:
                  break;
                default:
                  if (true)
                    ;
                  Monitor.Exit(b);
                  num3 = 1;
                  continue;
              }
              break;
            case 1:
              goto label_15;
            case 2:
              switch (0)
              {
                case 0:
                  break;
                default:
                  continue;
              }
              break;
          }
          if (lockTaken)
            num3 = 0;
          else
            break;
        }
label_15:;
      }
label_17:
      return DeviceManagerSingleTon.a;
    }
  }

  static DeviceManagerSingleTon()
  {
    short num1 = -27458;
    int num2 = (int) num1;
    num1 = (short) -27458;
    int num3 = (int) num1;
    switch (num2 == num3)
    {
      case true:
        short num4 = 0;
        if (num4 == (short) 0)
          ;
        num4 = (short) 1;
        if (num4 == (short) 0)
          ;
        num4 = (short) 0;
        DeviceManagerSingleTon.a = (IDeviceManager) null;
        DeviceManagerSingleTon.b = new object();
        break;
      default:
        goto case 1;
    }
  }
}
