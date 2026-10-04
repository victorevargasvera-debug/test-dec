// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.Comms.Clone
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using AcpCommonLib;
using CommonResources;
using Motorola.Common.Communication.CommonUtil;
using Motorola.Common.CustomException;
using SpecialFeatures.AcpReportManagerLib;
using SpecialFeatures.ReadWritePassword;
using SpecialFeatures.VoiceAnnouncements;
using System;
using System.Threading;
using System.Windows;

#nullable disable
namespace SpecialFeatures.Comms;

internal class Clone : SpecialFeatures.Comms.Comms
{
  private static bool a;
  private static bool b;
  private bool c;
  private bool d;
  private bool e;
  private string f = string.Empty;
  private readonly ReadWritePasswordApp g;
  private Window h;

  public Clone() => this.g = ReadWritePasswordApp.GetInstance();

  internal RadioIdInfo ReadRadioIds(
    COMMS_OP WriteType,
    int Headless = 0,
    string HeadlessAddr = "192.168.128.1",
    bool WriteProtecWriteProtectedRadio = false,
    bool otapBatchProgramming = false)
  {
    short num1 = -16975;
    int num2 = (int) num1;
    num1 = (short) -16975;
    int num3 = (int) num1;
    short num4;
    int num5;
    switch (num2 == num3 ? 1 : 0)
    {
      case 0:
      case 2:
label_24:
        num4 = (short) 5;
        num5 = (int) (IntPtr) num4;
        break;
      default:
        num4 = (short) 0;
        if (num4 == (short) 0)
          ;
        switch (0)
        {
          case 0:
            goto label_4;
        }
        break;
    }
    RadioIdInfo radioIdInfo;
    while (true)
    {
      switch (num5)
      {
        case 0:
          num4 = (short) 3;
          num5 = (int) (IntPtr) num4;
          continue;
        case 1:
          goto label_7;
        case 2:
          if (WriteType == COMMS_OP.OTAP_CLONE)
          {
            num4 = (short) 0;
            num5 = (int) (IntPtr) num4;
            continue;
          }
          goto case 4;
        case 3:
          num4 = (short) 1;
          if (num4 == (short) 0)
            ;
          if (!Clone.b)
            goto case 4;
          goto label_24;
        case 4:
          radioIdInfo = new RadioIdInfo();
          num4 = (short) 1;
          num5 = (int) (IntPtr) num4;
          continue;
        case 5:
          Thread.Sleep(3000);
          num4 = (short) 4;
          num5 = (int) (IntPtr) num4;
          continue;
        default:
          goto label_4;
      }
label_3:;
    }
label_7:
    try
    {
      num4 = (short) 4;
      int num6 = (int) (IntPtr) num4;
      while (true)
      {
        switch (num6)
        {
          case 0:
          case 1:
            num4 = (short) 6;
            num6 = (int) (IntPtr) num4;
            continue;
          case 2:
            this.GetReadWritePassword(ref this.c, ref this.d, ref this.e, ref this.f);
            num4 = (short) 0;
            num6 = (int) (IntPtr) num4;
            continue;
          case 3:
            radioIdInfo.TrkSysIds = this.m_RadioSystemIds;
            radioIdInfo.CnvSysIds = this.m_RadioCnvSysIds;
            radioIdInfo.AstroOtarRadioIds = this.m_AstroOtarRadioIds;
            radioIdInfo.DataProfIps = this.m_RadioDataProfIPs;
            radioIdInfo.SoftIds = this.m_SoftIds;
            radioIdInfo.BluetoothFriendlyName = this.m_BluetoothFriendlyName;
            RadioParams radioParams = this.GetRadioParams();
            radioIdInfo.RadioAlias = this.GetRadioAlias();
            radioIdInfo.ESerialNumber = this.m_readRadioParams.ESerialNumber;
            radioIdInfo.IsEncryptedPwd = this.m_EncryptPasswordFlag;
            radioIdInfo.EncryptedPwd = this.m_EncryptPassword;
            radioIdInfo.SerialNumber = ParseDataHelper.RadioSNToString(radioParams.SerialNumber);
            Clone.a = false;
            Clone.b = true;
            num4 = (short) 5;
            num6 = (int) (IntPtr) num4;
            continue;
          case 4:
            switch (0)
            {
              case 0:
                break;
              default:
                continue;
            }
            break;
          case 5:
            if (WriteType == COMMS_OP.OTAP_CLONE)
            {
              num4 = (short) 7;
              num6 = (int) (IntPtr) num4;
              continue;
            }
            goto case 2;
          case 6:
            goto label_26;
          case 7:
            CloneParameters.LastCloneOTAPUserState = this.GetLastCommsOTAPUserState();
            num4 = (short) 2;
            num6 = (int) (IntPtr) num4;
            continue;
        }
        if (!this.blockRadioWrite(WriteType, CloneParameters.LastCloneOTAPUserState, Headless, HeadlessAddr, WriteProtecWriteProtectedRadio, otapBatchProgramming))
        {
          num4 = (short) 3;
          num6 = (int) (IntPtr) num4;
        }
        else
        {
          Clone.b = false;
          Clone.a = true;
          num4 = (short) 1;
          num6 = (int) (IntPtr) num4;
        }
      }
    }
    catch
    {
      this.ForceClose();
    }
label_26:
    return radioIdInfo;
label_4:
    this.c = false;
    this.d = false;
    this.e = false;
    num4 = (short) 0;
    num4 = (short) 2;
    num5 = (int) (IntPtr) num4;
    goto label_3;
  }

  internal bool CloneRadio(
    bool ReadRadioIds,
    COMMS_OP WriteType,
    object lastCommsUserState,
    Window win,
    bool inbatchMode = false)
  {
    short num1 = 4623;
    int num2 = (int) num1;
    num1 = (short) 4623;
    int num3 = (int) num1;
    switch (num2 == num3 ? 1 : 0)
    {
      case 0:
      case 2:
label_13:
        return this.CloneRadio(ReadRadioIds, WriteType, inbatchMode);
      default:
        short num4 = 1;
        if (num4 == (short) 0)
          ;
        num4 = (short) 0;
        if (num4 == (short) 0)
          ;
        int num5;
        switch (0)
        {
          case 0:
label_5:
            num4 = (short) 0;
            this.h = win;
            num4 = (short) 2;
            num5 = (int) (IntPtr) num4;
            goto default;
          default:
            while (true)
            {
              switch (num5)
              {
                case 0:
                  num4 = (short) 5;
                  num5 = (int) (IntPtr) num4;
                  continue;
                case 1:
                case 3:
                  goto label_13;
                case 2:
                  if (WriteType == COMMS_OP.OTAP_CLONE)
                  {
                    num4 = (short) 0;
                    num5 = (int) (IntPtr) num4;
                    continue;
                  }
                  goto label_13;
                case 4:
                  CloneParameters.LastCloneOTAPUserState = lastCommsUserState;
                  num4 = (short) 3;
                  num5 = (int) (IntPtr) num4;
                  continue;
                case 5:
                  if (lastCommsUserState == null)
                  {
                    CloneParameters.LastCloneOTAPUserState = (object) null;
                    num4 = (short) 1;
                    num5 = (int) (IntPtr) num4;
                    continue;
                  }
                  num4 = (short) 4;
                  num5 = (int) (IntPtr) num4;
                  continue;
                default:
                  goto label_5;
              }
            }
        }
    }
  }

  internal bool CloneRadio(bool ReadRadioIds, COMMS_OP WriteType, bool inbatchMode = false)
  {
    int A_1 = 10;
    short num1 = 6748;
    int num2 = (int) num1;
    num1 = (short) 6748;
    int num3 = (int) num1;
    short num4;
    int num5;
    switch (num2 == num3 ? 1 : 0)
    {
      case 0:
      case 2:
label_4:
        bool flag1 = false;
        Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation radioInformation = FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation;
        string str = "";
        string guidToSet = "";
        try
        {
          RadioParams codeplgParams;
          switch (0)
          {
            case 0:
label_7:
              codeplgParams = new RadioParams();
              num4 = (short) 0;
              num5 = (int) (IntPtr) num4;
              goto default;
            default:
              while (true)
              {
                bool flag2;
                string serialNumber;
                IshItemCollection ishItemCollection;
                int num6;
                switch (num5)
                {
                  case 0:
                    if (!ReadRadioIds)
                    {
                      num4 = (short) 1;
                      num5 = (int) (IntPtr) num4;
                      continue;
                    }
                    goto case 30;
                  case 1:
                    this.c = false;
                    this.d = false;
                    this.e = false;
                    Clone.a = this.blockRadioWrite(WriteType, CloneParameters.LastCloneOTAPUserState, HeadlessAddr: RptMgrErrorHandler.b("붌ꆎꆐ붒ꖔ릖ꦘ", A_1));
                    num4 = (short) 12;
                    num5 = (int) (IntPtr) num4;
                    continue;
                  case 2:
                    num4 = (short) 23;
                    num5 = (int) (IntPtr) num4;
                    continue;
                  case 3:
                    if (!flag1)
                    {
                      num4 = (short) 4;
                      num5 = (int) (IntPtr) num4;
                      continue;
                    }
                    goto case 10;
                  case 4:
                    num4 = (short) 29;
                    num5 = (int) (IntPtr) num4;
                    continue;
                  case 5:
                    if (this.d)
                    {
                      num4 = (short) 8;
                      num5 = (int) (IntPtr) num4;
                      continue;
                    }
                    break;
                  case 6:
                    this.GetReadWritePassword(ref this.c, ref this.d, ref this.e, ref this.f);
                    num4 = (short) 30;
                    num5 = (int) (IntPtr) num4;
                    continue;
                  case 7:
                    flag1 = this.WriteRadio(ishItemCollection, WriteType, codeplgParams, inbatchMode);
                    num4 = (short) 21;
                    num5 = (int) (IntPtr) num4;
                    continue;
                  case 8:
                    num4 = (short) 17;
                    num5 = (int) (IntPtr) num4;
                    continue;
                  case 9:
                    if (!(bool) Application.Current.Properties[(object) RptMgrErrorHandler.b("캌\uE08Eﲐﺒ\uF494練ﶘ힚\uF49C\uF19E쒠\uE0A2\uF5A4\uF4A6", A_1)])
                    {
                      codeplgParams = this.GetRadioParams();
                      serialNumber = ParseDataHelper.RadioSNToString(codeplgParams.SerialNumber);
                      num4 = (short) 5;
                      num5 = (int) (IntPtr) num4;
                      continue;
                    }
                    num4 = (short) 14;
                    num5 = (int) (IntPtr) num4;
                    continue;
                  case 10:
                    LastSetJobUuidHelper.SetLastSetJobUuidField(guidToSet);
                    Clone.a = true;
                    num4 = (short) 27;
                    num5 = (int) (IntPtr) num4;
                    continue;
                  case 11:
                    num6 = this.g.ValidateOKToReadWrite(this.h, this.f, serialNumber, ReadWritePasswordApp.ValidType.Write) ? 1 : 0;
                    goto label_44;
                  case 12:
                    if (WriteType == COMMS_OP.OTAP_CLONE)
                    {
                      num4 = (short) 25;
                      num5 = (int) (IntPtr) num4;
                      continue;
                    }
                    goto case 6;
                  case 13:
                  case 33:
                    num4 = (short) 18;
                    num5 = (int) (IntPtr) num4;
                    continue;
                  case 14:
                    flag2 = true;
                    num4 = (short) 13;
                    num5 = (int) (IntPtr) num4;
                    continue;
                  case 15:
                    if (ishItemCollection != null)
                    {
                      num4 = (short) 2;
                      num5 = (int) (IntPtr) num4;
                      continue;
                    }
                    goto case 21;
                  case 16 /*0x10*/:
                    ishItemCollection = ParseDataHelper.ReplaceSecurityPartition(ishItemCollection, this.oldSecurityPartition);
                    num4 = (short) 7;
                    num5 = (int) (IntPtr) num4;
                    continue;
                  case 17:
                    if (!Clone.a)
                    {
                      num4 = (short) 22;
                      num5 = (int) (IntPtr) num4;
                      continue;
                    }
                    break;
                  case 18:
                    if (!flag2)
                    {
                      num4 = (short) 19;
                      num5 = (int) (IntPtr) num4;
                      continue;
                    }
                    goto case 28;
                  case 19:
                    this.ForceClose();
                    SpecialFeatures.Comms.Comms.DispalyUpdateStatusChanged(0.0, AppResources.Password_validation_failed);
                    num4 = (short) 28;
                    num5 = (int) (IntPtr) num4;
                    continue;
                  case 20:
                    goto label_59;
                  case 21:
                    num4 = (short) 3;
                    num5 = (int) (IntPtr) num4;
                    continue;
                  case 22:
                    num4 = (short) 11;
                    num5 = (int) (IntPtr) num4;
                    continue;
                  case 23:
                    if ((bool) Application.Current.Properties[(object) RptMgrErrorHandler.b("캌\uE08Eﲐﺒ\uF494練ﶘ힚\uF49C\uF19E쒠\uE0A2\uF5A4\uF4A6", A_1)])
                    {
                      num4 = (short) 16 /*0x10*/;
                      num5 = (int) (IntPtr) num4;
                      continue;
                    }
                    goto case 7;
                  case 24:
                    num6 = 1;
                    goto label_44;
                  case 25:
                    CloneParameters.LastCloneOTAPUserState = this.GetLastCommsOTAPUserState();
                    num4 = (short) 6;
                    num5 = (int) (IntPtr) num4;
                    continue;
                  case 26:
                    radioInformation.General.RadInfoGeneralCodeplugVersion_A7683_UIValue = str;
                    num4 = (short) 10;
                    num5 = (int) (IntPtr) num4;
                    continue;
                  case 27:
                    Clone.b = false;
                    num4 = (short) 20;
                    num5 = (int) (IntPtr) num4;
                    continue;
                  case 28:
                    num4 = (short) 31 /*0x1F*/;
                    num5 = (int) (IntPtr) num4;
                    continue;
                  case 29:
                    if (!(bool) Application.Current.Properties[(object) RptMgrErrorHandler.b("캌\uE08Eﲐﺒ\uF494練ﶘ힚\uF49C\uF19E쒠\uE0A2\uF5A4\uF4A6", A_1)])
                    {
                      num4 = (short) 26;
                      num5 = (int) (IntPtr) num4;
                      continue;
                    }
                    goto case 10;
                  case 30:
                    flag2 = false;
                    num4 = (short) 9;
                    num5 = (int) (IntPtr) num4;
                    continue;
                  case 31 /*0x1F*/:
                    if (!Clone.a & flag2)
                    {
                      num4 = (short) 32 /*0x20*/;
                      num5 = (int) (IntPtr) num4;
                      continue;
                    }
                    goto case 27;
                  case 32 /*0x20*/:
                    string appVersion = AppInfoManager.AppVersion;
                    str = radioInformation.General.RadInfoGeneralCodeplugVersion_A7683_UIValue;
                    radioInformation.General.RadInfoGeneralCodeplugVersion_A7683_UIValue = appVersion;
                    guidToSet = (FeatureManager.GetFeature(2045)[0] as Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide).Labtool.RadWideLabtoolRCLastJobSetUUIDValue;
                    LastSetJobUuidHelper.SetLastSetJobUuidField();
                    this.UpdatePINPasswordBeforeWrite();
                    TtsDataTreeUpdater.AddTtsToFeatureManager();
                    ishItemCollection = this.packToCodeplug();
                    num4 = (short) 15;
                    num5 = (int) (IntPtr) num4;
                    continue;
                  default:
                    goto label_7;
                }
                num4 = (short) 24;
                num5 = (int) (IntPtr) num4;
                continue;
label_44:
                flag2 = num6 != 0;
                num4 = (short) 33;
                num5 = (int) (IntPtr) num4;
              }
          }
        }
        catch (Exception ex)
        {
          if (ex.Message == AppResources.Codeplug_Exceeds_Size_Limit_On_Write)
          {
            if (!flag1 && !(bool) Application.Current.Properties[(object) RptMgrErrorHandler.b("캌\uE08Eﲐﺒ\uF494練ﶘ힚\uF49C\uF19E쒠\uE0A2\uF5A4\uF4A6", A_1)])
              goto label_57;
label_55:
            LastSetJobUuidHelper.SetLastSetJobUuidField(guidToSet);
            Clone.a = true;
            throw new CommonException(AppResources.Codeplug_Exceeds_Size_Limit_On_Write);
label_57:
            radioInformation.General.RadInfoGeneralCodeplugVersion_A7683_UIValue = str;
            goto label_55;
          }
        }
        finally
        {
          this.g.ClearCachedPasswordValidation();
          this.ForceClose();
        }
label_59:
        return flag1;
      default:
        num4 = (short) 0;
        num4 = (short) 1;
        if (num4 == (short) 0)
          ;
        num4 = (short) 0;
        if (num4 == (short) 0)
          ;
        num4 = (short) 0;
        num5 = (int) num4;
        switch (num5)
        {
          default:
            goto label_4;
        }
    }
  }

  internal void FileCloneForceClose()
  {
    short num1 = 1801;
    int num2 = (int) num1;
    num1 = (short) 1801;
    int num3 = (int) num1;
    short num4;
    switch (num2 == num3)
    {
      case true:
        num4 = (short) 0;
        if (num4 == (short) 0)
          ;
        num4 = (short) 1;
        if (num4 == (short) 0)
          ;
        Clone.b = false;
        this.ForceClose();
        break;
      default:
        num4 = (short) 0;
        goto case 1;
    }
  }
}
