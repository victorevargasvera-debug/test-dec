// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.Comms.DeviceManager
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using CommonResources;
using Motorola.Common.Communication.CommonUtil;
using Motorola.Common.Communication.Service;
using Motorola.Common.CustomException;
using Motorola.CommonCPS.ResourceRepository;
using SpecialFeatures.AcpReportManagerLib;
using SpecialFeatures.ReadWritePassword;
using SpecialFeatures.ReadWriteTlsPsk;
using SSLMangrComp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows;

#nullable disable
namespace SpecialFeatures.Comms;

public class DeviceManager : IDeviceManager
{
  private readonly IDeviceDiscovery a;
  private readonly DeviceDiscoveryHandler b;
  private readonly bool c;
  private readonly ReadWritePasswordApp d;
  public static int pos;

  public DeviceManager()
  {
    int A_1 = 17;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    this.c = (bool) Application.Current.Properties[(object) RptMgrErrorHandler.b("힓秊\uF597\uF799ﶛ\uF09D쒟\uEEA1춣좥춧\uE9A9ﲫﶭ", A_1)];
    if (!this.c)
    {
      this.b = new DeviceDiscoveryHandler();
      this.a = DeviceServiceManagerProvider.Instance.GetDeviceDiscoveryService((ProductFamily) 4097, (WorkMode) 1, (IDiscoveryServiceEvent) this.b);
    }
    this.d = ReadWritePasswordApp.GetInstance();
  }

  public event EventHandler<DeviceEventArgs> DeviceConnectedEvent
  {
    add
    {
      short num1 = 0;
      num1 = (short) 3165;
      int num2 = (int) num1;
      num1 = (short) 3165;
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
          this.b.DeviceConnectedEventHandler += value;
          break;
        default:
          goto case 1;
      }
    }
    remove
    {
      short num1 = -4074;
      int num2 = (int) num1;
      num1 = (short) -4074;
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
          this.b.DeviceConnectedEventHandler -= value;
          break;
        default:
          goto case 1;
      }
    }
  }

  public event EventHandler<DeviceEventArgs> DeviceLostEvent
  {
    add
    {
      short num1 = 0;
      num1 = (short) -6071;
      int num2 = (int) num1;
      num1 = (short) -6071;
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
          this.b.DeviceLostEventHandler += value;
          break;
        default:
          goto case 1;
      }
    }
    remove
    {
      short num1 = 0;
      num1 = (short) -15033;
      int num2 = (int) num1;
      num1 = (short) -15033;
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
          this.b.DeviceLostEventHandler -= value;
          break;
        default:
          goto case 1;
      }
    }
  }

  public PresenceNotification RetrievePresenceInfo(PNConnectionInfo connectionConfig)
  {
    short num1;
    PresenceNotification presenceNotification;
    try
    {
      short num2 = 19752;
      int num3 = (int) num2;
      num2 = (short) 19752;
      int num4 = (int) num2;
      switch (num3 == num4)
      {
        case true:
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          presenceNotification = this.a.RetrievePresenceInfo(connectionConfig);
          break;
        default:
          goto case 1;
      }
    }
    catch (Exception ex)
    {
      CommonExceptionHelper.ConvertExceptiontAndThrow(ex);
      throw CommonExceptionHelper.CreateCommonException((CommonErrorCode) 1, Resources.GenericError, ex);
    }
    num1 = (short) 1;
    if (num1 == (short) 0)
      ;
    num1 = (short) 0;
    return presenceNotification;
  }

  public IDeviceProxy CreateDeviceProxy(RadioParams radioParameter, RadioOperation radioOperation)
  {
    int num1 = 1;
    DeviceInfo deviceInfo;
    while (true)
    {
      short num2;
      ConnectionType connectionType;
      switch (num1)
      {
        case 0:
          goto label_19;
        case 1:
          switch (0)
          {
            case 0:
              break;
            default:
              continue;
          }
          break;
        case 2:
label_25:
          connectionType = radioParameter.ConnectionInfo.ConnectionType;
          num2 = (short) 5;
          num1 = (int) (IntPtr) num2;
          continue;
        case 3:
          num2 = (short) 10;
          num1 = (int) (IntPtr) num2;
          continue;
        case 4:
          if (radioParameter.ConnectionInfo.ConnectionType == 16 /*0x10*/)
          {
            num2 = (short) 7;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto label_28;
        case 5:
          if (connectionType != 32 /*0x20*/)
          {
            num2 = (short) 3;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto case 14;
        case 6:
          if (deviceInfo.ConnectionInfo.OtapConnectionType == null)
          {
            num2 = (short) 0;
            num2 = (short) 0;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto label_28;
        case 7:
          num2 = (short) 6;
          num1 = (int) (IntPtr) num2;
          continue;
        case 8:
          if (radioParameter.ConnectionInfo.ConnectionType == 4)
          {
            num2 = (short) 12;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          deviceInfo = radioParameter.WrapperDeviceInfo();
          num2 = (short) 11;
          num1 = (int) (IntPtr) num2;
          continue;
        case 9:
          goto label_17;
        case 10:
          if (connectionType == 16 /*0x10*/)
          {
            num2 = (short) 14;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto case 13;
        case 11:
          num2 = (short) 27967;
          int num3 = (int) num2;
          num2 = (short) 27967;
          int num4 = (int) num2;
          switch (num3 == num4 ? 1 : 0)
          {
            case 0:
            case 2:
              goto label_25;
            default:
              num2 = (short) 0;
              if (num2 == (short) 0)
                goto label_25;
              goto label_25;
          }
        case 12:
          num2 = (short) 1;
          if (num2 == (short) 0)
            ;
          deviceInfo = this.a((ConnectionType) 4, radioOperation);
          num2 = (short) 2;
          num1 = (int) (IntPtr) num2;
          continue;
        case 13:
          num2 = (short) 4;
          num1 = (int) (IntPtr) num2;
          continue;
        case 14:
          deviceInfo = new DeviceProxy(deviceInfo, (RadioOperation) 1L).ReadDeviceInfo();
          num2 = (short) 13;
          num1 = (int) (IntPtr) num2;
          continue;
      }
      if (this.c)
      {
        num2 = (short) 9;
        num1 = (int) (IntPtr) num2;
      }
      else
      {
        num2 = (short) 8;
        num1 = (int) (IntPtr) num2;
      }
    }
label_17:
    return FileProxyFactory.Instance.GetDevice((object) radioParameter, radioOperation);
label_19:
    return (IDeviceProxy) new DeviceProxy(deviceInfo, radioOperation);
label_28:
    string A_2;
    this.a(deviceInfo, radioOperation, out A_2);
    return (IDeviceProxy) new DeviceProxy(deviceInfo, radioOperation, A_2);
  }

  private DeviceInfo a(ConnectionType A_0, RadioOperation A_1)
  {
    List<DeviceInfo> A_0_1;
    try
    {
      A_0_1 = this.a.ListConnectedDevices((int) A_0);
    }
    catch (Exception ex)
    {
      CommonExceptionHelper.ConvertExceptiontAndThrow(ex);
      throw CommonExceptionHelper.CreateCommonException((CommonErrorCode) 52, Resources.CommunicationServiceCommunicationError);
    }
    int num = 2;
    while (true)
    {
      switch (num)
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
label_2:
          switch (true ? 1 : 0)
          {
            case 0:
            case 2:
              goto label_2;
            default:
              if (true)
                ;
              num = 0;
              continue;
          }
        case 2:
          if (A_0_1 != null)
          {
            num = 1;
            continue;
          }
          goto label_13;
        case 3:
          goto label_13;
      }
      if (false)
        ;
      if (A_0_1.Count == 0)
        num = 3;
      else
        goto label_14;
    }
label_13:
    throw CommonExceptionHelper.CreateDirectMessageCommonException(AppResources.Could_not_find_a_radio_connected_to_a_USB_port);
label_14:
    return this.a((IList<DeviceInfo>) A_0_1, A_0, A_1);
  }

  private DeviceInfo a(IList<DeviceInfo> A_0, ConnectionType A_1, RadioOperation A_2)
  {
    int A_1_1 = 10;
label_1:
    short num1;
    int num2;
    DeviceInfo deviceInfo;
    switch (0)
    {
      case 0:
label_3:
        deviceInfo = A_0[0];
        Trace.TraceInformation(string.Format(RptMgrErrorHandler.b("회\uF48Eꆐ\uEE92좔첖\uE298ꪚ\uE09C슞猪\uD8A2鞤\uDAA6\uF4A8\uF0AA횬鲮첰\uEEB2\uEEB4骶钸隺\uE0BC", A_1_1), (object) deviceInfo.ConnectionInfo.ConnectionType, (object) deviceInfo.Family, (object) deviceInfo.SerialNumber, (object) deviceInfo.ModelNumber) + RptMgrErrorHandler.b("회", A_1_1) + deviceInfo.SoftwareVersion + RptMgrErrorHandler.b("킌풎", A_1_1) + deviceInfo.CodeplugVersion + RptMgrErrorHandler.b("킌꾎\uF690\uF692\uE194\uE396\uF098\uF59A煮뾞햠쮢삤螦춨캪\uDBAC욮튰횲閴톶쮸풺킼龾藀ꛂ도껆\uAAC8껊背껎뿐닒닔닖ꯘ\uF5DA", A_1_1));
        num1 = (short) 0;
        num2 = (int) (IntPtr) num1;
        goto default;
      default:
        while (true)
        {
          num1 = (short) 0;
          switch (num2)
          {
            case 0:
              if (deviceInfo.Family == 4096 /*0x1000*/)
              {
                num1 = (short) 4;
                num2 = (int) (IntPtr) num1;
                continue;
              }
              goto label_13;
            case 1:
              if (this.a.IsRadioInBpMode(deviceInfo))
              {
                num1 = (short) 1;
                if (num1 == (short) 0)
                  ;
                num1 = (short) 2;
                num2 = (int) (IntPtr) num1;
                continue;
              }
              goto label_13;
            case 2:
              Trace.TraceInformation(string.Format(RptMgrErrorHandler.b("회\uF48Eꆐ\uEE92좔첖\uE298ꪚ\uE09C슞猪\uD8A2鞤\uDAA6\uF4A8\uF0AA횬鲮첰\uEEB2\uEEB4骶钸隺\uE0BC", A_1_1), (object) deviceInfo.ConnectionInfo.ConnectionType, (object) deviceInfo.Family, (object) deviceInfo.SerialNumber, (object) deviceInfo.ModelNumber) + RptMgrErrorHandler.b("회", A_1_1) + deviceInfo.SoftwareVersion + RptMgrErrorHandler.b("킌풎", A_1_1) + deviceInfo.CodeplugVersion + RptMgrErrorHandler.b("킌꾎\uE490\uE392떔\uE396\uF698뮚\uEE9C\uE89E좠힢욤쾦삨얪쪬辮\uF0B0ﺲ\uE5B4鞶ﶸ\uDEBA쮼횾ꋀꛂ\uE5C4ꇆ믈\uA4CAꃌ\uEFCE鏐菒\uF5D4뫖뛘뿚룜\uFFDE闠賢엤ꛦ맨쯪胬胮闰雲\uDBF4", A_1_1));
              this.a.ChangeDeviceProcessorToAp(deviceInfo);
              deviceInfo = this.a(A_1);
              num1 = (short) 3;
              num2 = (int) (IntPtr) num1;
              continue;
            case 3:
              goto label_7;
            case 4:
              num1 = (short) 1;
              num2 = (int) (IntPtr) num1;
              continue;
            default:
              goto label_3;
          }
        }
label_7:
        num1 = (short) 28044;
        int num3 = (int) num1;
        num1 = (short) 28044;
        int num4 = (int) num1;
        switch (num3 == num4 ? 1 : 0)
        {
          case 0:
          case 2:
            goto label_1;
          default:
            num1 = (short) 0;
            if (num1 == (short) 0)
              break;
            break;
        }
label_13:
        return deviceInfo;
    }
  }

  private void a(DeviceInfo A_0, RadioOperation A_1, out string A_2)
  {
    int A_1_1 = 6;
    A_2 = (string) null;
label_1:
    short num1;
    try
    {
      int num2;
      switch (0)
      {
        case 0:
label_3:
          Trace.TraceInformation(string.Format(RptMgrErrorHandler.b("튈\uF08A붌\uF28E첐좒\uEE94Ꚗ\uE498욚욜\uE49E鎠\uDEA2\uF8A4ﲦ튨颪킬\uF2AE\uEAB0麲颴骶\uE4B8", A_1_1), (object) A_0.ConnectionInfo.ConnectionType, (object) A_0.Family, (object) A_0.SerialNumber, (object) A_0.ModelNumber) + string.Format(RptMgrErrorHandler.b("튈\uF08A붌\uF28E첐좒\uEE94Ꚗ\uE498욚붜횞튠莢\uF7A4욦춨슪슬辮\uE5B0ﾲ\uE6B4骶\uE9B8\uE8BA\uF6BC銾ꋀ곂꣄럆\uA8C8뿊\uA4CC귎뷐뛒\uEFD4\uF7D6ꋘ\uE9DAꃜ", A_1_1), (object) A_0.SoftwareVersion, (object) A_0.CodeplugVersion, (object) A_0.ConnectionInfo.IsTlsPskCompatible));
          num1 = (short) 1;
          num2 = (int) (IntPtr) num1;
          goto default;
        default:
          while (true)
          {
            switch (num2)
            {
              case 0:
                num1 = (short) 5;
                num2 = (int) (IntPtr) num1;
                continue;
              case 1:
                if (A_1 != 2048L /*0x0800*/)
                {
                  num1 = (short) 0;
                  num2 = (int) (IntPtr) num1;
                  continue;
                }
                goto case 2;
              case 2:
                num1 = (short) 1;
                if (num1 == (short) 0)
                  ;
                num1 = (short) 3;
                num2 = (int) (IntPtr) num1;
                continue;
              case 3:
                goto label_12;
              case 4:
                new TlsPskHandler(this.d).HandlePsk(this.a, A_0, out A_2);
                num1 = (short) 2;
                num2 = (int) (IntPtr) num1;
                continue;
              case 5:
                if (A_0.ConnectionInfo.IsTlsPskCompatible)
                {
                  num1 = (short) 4;
                  num2 = (int) (IntPtr) num1;
                  continue;
                }
                goto case 2;
              default:
                goto label_3;
            }
          }
label_12:
          num1 = (short) -3422;
          int num3 = (int) num1;
          num1 = (short) -3422;
          int num4 = (int) num1;
          switch (num3 == num4 ? 1 : 0)
          {
            case 0:
            case 2:
              goto label_1;
            default:
              num1 = (short) 0;
              if (num1 == (short) 0)
                break;
              break;
          }
          break;
      }
    }
    catch (InvalidOperationException ex)
    {
      CommonException messageCommonException = CommonExceptionHelper.CreateDirectMessageCommonException(AppResources.Could_not_connect_to_the_radio);
      Logger.LogWithDateTime(((Exception) messageCommonException).Message);
      throw messageCommonException;
    }
    num1 = (short) 0;
  }

  private DeviceInfo a(ConnectionType A_0)
  {
label_0:
    int num1;
    TimeSpan timeSpan;
    DateTime now;
    short num2;
    switch (0)
    {
      case 0:
label_2:
        Thread.Sleep(TimeSpan.FromSeconds(2.0));
        timeSpan = TimeSpan.FromSeconds(60.0);
        now = DateTime.Now;
        num2 = (short) 2;
        num1 = (int) (IntPtr) num2;
        goto default;
      default:
        List<DeviceInfo> deviceInfoList;
        while (true)
        {
          switch (num1)
          {
            case 0:
              goto label_3;
            case 1:
              goto label_17;
            case 2:
            case 5:
              num2 = (short) 6;
              num1 = (int) (IntPtr) num2;
              continue;
            case 3:
              if (!this.a.IsRadioInBpMode(deviceInfoList[0]))
              {
                num2 = (short) 0;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 2;
            case 4:
              num2 = (short) 1;
              if (num2 == (short) 0)
                ;
              Thread.Sleep(TimeSpan.FromSeconds(1.0));
              num2 = (short) 5;
              num1 = (int) (IntPtr) num2;
              continue;
            case 6:
              if (DateTime.Now - now <= timeSpan)
              {
                deviceInfoList = this.a.ListConnectedDevices((int) A_0);
                num2 = (short) 7;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              num2 = (short) 1;
              num1 = (int) (IntPtr) num2;
              continue;
            case 7:
              if (deviceInfoList.Count != 0)
              {
                num2 = (short) 3;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              num2 = (short) 0;
              num2 = (short) -29344;
              int num3 = (int) num2;
              num2 = (short) -29344;
              int num4 = (int) num2;
              switch (num3 == num4 ? 1 : 0)
              {
                case 0:
                case 2:
                  goto label_0;
                default:
                  num2 = (short) 0;
                  if (num2 == (short) 0)
                    ;
                  num2 = (short) 4;
                  num1 = (int) (IntPtr) num2;
                  continue;
              }
            default:
              goto label_2;
          }
        }
label_3:
        return deviceInfoList[0];
label_17:
        throw CommonExceptionHelper.CreateDirectMessageCommonException(AppResources.Radio_Connection_Failed);
    }
  }

  public DeviceInfo[] GetAllConnectedDevice()
  {
    DeviceInfo[] array;
    try
    {
      array = this.a.ListConnectedDevices(4).ToArray<DeviceInfo>();
    }
    catch (Exception ex)
    {
      CommonExceptionHelper.ConvertExceptiontAndThrow(ex);
      throw CommonExceptionHelper.CreateCommonException((CommonErrorCode) 50, Resources.CommunicationServiceNotAvailabe, ex);
    }
label_11:
    int num = 1;
    while (true)
    {
      switch (num)
      {
        case 0:
          goto label_7;
        case 1:
          if (array != null)
          {
            num = 2;
            continue;
          }
          goto label_14;
        case 2:
          num = 3;
          continue;
        case 3:
          switch (0)
          {
            case 0:
              break;
            default:
              continue;
          }
          break;
      }
      if (array.Length == 0)
        num = 0;
      else
        goto label_15;
    }
label_7:
    if (false)
      ;
    switch (true ? 1 : 0)
    {
      case 0:
      case 2:
        goto label_11;
      case 1:
        if (true)
          break;
        break;
      default:
        goto case 1;
    }
label_14:
    throw CommonExceptionHelper.CreateDirectMessageCommonException(AppResources.Could_not_find_a_radio_connected_to_a_USB_port);
label_15:
    return array;
  }
}
