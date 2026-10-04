// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.Comms.DeviceServiceHandler
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using Motorola.Common.Communication.CommonUtil;
using Motorola.Common.Communication.Service;
using System;
using System.ComponentModel;
using System.ServiceModel;
using System.Threading;

#nullable disable
namespace SpecialFeatures.Comms;

[CallbackBehavior(UseSynchronizationContext = false)]
public class DeviceServiceHandler : IOperationServiceEvent
{
  public event ProgressChangedEventHandler ProgressEventHandler
  {
    add
    {
label_0:
      short num1 = 0;
      int num2;
      ProgressChangedEventHandler changedEventHandler;
      switch (0)
      {
        case 0:
label_2:
          changedEventHandler = this.a;
          num1 = (short) 0;
          num2 = (int) (IntPtr) num1;
          goto default;
        default:
          while (true)
          {
            ProgressChangedEventHandler comparand;
            switch (num2)
            {
              case 0:
                num1 = (short) 1;
                if (num1 == (short) 0)
                  break;
                break;
              case 1:
                goto label_9;
              case 2:
                if (changedEventHandler == comparand)
                {
                  num1 = (short) 1;
                  num2 = (int) (IntPtr) num1;
                  continue;
                }
                break;
              default:
                goto label_2;
            }
            num1 = (short) 5093;
            int num3 = (int) num1;
            num1 = (short) 5093;
            int num4 = (int) num1;
            switch (num3 == num4 ? 1 : 0)
            {
              case 0:
              case 2:
                goto label_0;
              default:
                num1 = (short) 0;
                if (num1 == (short) 0)
                  ;
                comparand = changedEventHandler;
                changedEventHandler = Interlocked.CompareExchange<ProgressChangedEventHandler>(ref this.a, comparand + value, comparand);
                num1 = (short) 2;
                num2 = (int) (IntPtr) num1;
                continue;
            }
          }
label_9:
          break;
      }
    }
    remove
    {
label_0:
      short num1 = 0;
      int num2;
      ProgressChangedEventHandler changedEventHandler;
      switch (0)
      {
        case 0:
label_2:
          changedEventHandler = this.a;
          num1 = (short) 0;
          num2 = (int) (IntPtr) num1;
          goto default;
        default:
          ProgressChangedEventHandler comparand;
          while (true)
          {
            switch (num2)
            {
              case 0:
                num1 = (short) 11394;
                int num3 = (int) num1;
                num1 = (short) 11394;
                int num4 = (int) num1;
                switch (num3 == num4 ? 1 : 0)
                {
                  case 0:
                  case 2:
                    goto label_0;
                  default:
                    num1 = (short) 0;
                    if (num1 == (short) 0)
                      ;
                    num1 = (short) 1;
                    if (num1 == (short) 0)
                      ;
                    comparand = changedEventHandler;
                    changedEventHandler = Interlocked.CompareExchange<ProgressChangedEventHandler>(ref this.a, comparand - value, comparand);
                    num1 = (short) 2;
                    num2 = (int) (IntPtr) num1;
                    continue;
                }
              case 1:
                goto label_9;
              case 2:
                if (changedEventHandler == comparand)
                {
                  num1 = (short) 1;
                  num2 = (int) (IntPtr) num1;
                  continue;
                }
                goto case 0;
              default:
                goto label_2;
            }
          }
label_9:
          break;
      }
    }
  }

  public void OnProgress(int percent, ProgressStatus processStatus)
  {
    short num1 = -21884;
    int num2 = (int) num1;
    num1 = (short) -21884;
    int num3 = (int) num1;
    short num4;
    int num5;
    switch (num2 == num3 ? 1 : 0)
    {
      case 0:
      case 2:
label_7:
        num4 = (short) 2;
        num5 = (int) (IntPtr) num4;
        break;
      default:
        num4 = (short) 0;
        if (num4 == (short) 0)
          ;
        num4 = (short) 1;
        if (num4 == (short) 0)
          ;
        num4 = (short) 0;
        num5 = (int) (IntPtr) num4;
        break;
    }
    while (true)
    {
      switch (num5)
      {
        case 0:
          goto label_4;
        case 1:
          goto label_8;
        case 2:
          // ISSUE: reference to a compiler-generated field
          this.a((object) this, new ProgressChangedEventArgs(percent, (object) processStatus.ToString()));
          num4 = (short) 1;
          num5 = (int) (IntPtr) num4;
          continue;
        default:
          goto label_6;
      }
label_5:;
    }
label_4:
    num4 = (short) 0;
    switch (0)
    {
      case 0:
        goto label_6;
      default:
        goto label_5;
    }
label_8:
    return;
label_6:
    // ISSUE: reference to a compiler-generated field
    if (this.a != null)
      goto label_7;
  }

  internal void OnClientStatusCheck()
  {
    short num1 = 6368;
    int num2 = (int) num1;
    num1 = (short) 6368;
    int num3 = (int) num1;
    switch (num2 == num3)
    {
      case true:
        short num4 = 1;
        if (num4 == (short) 0)
          ;
        num4 = (short) 0;
        if (num4 == (short) 0)
          ;
        num4 = (short) 0;
        break;
      default:
        goto case 1;
    }
  }
}
