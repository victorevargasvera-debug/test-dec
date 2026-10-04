// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.Comms.Comms
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using AcpBusinessLayer;
using AcpCommonLib;
using Common;
using CommonResources;
using ConstraintHelper;
using Motorola.Acp.PackUnpack.Ish;
using Motorola.Common.Communication.CommonUtil;
using Motorola.Common.Communication.Pba;
using Motorola.Common.CustomException;
using Motorola.MackinawCPS.CoreFeatures.PackExec;
using Motorola.MackinawCPS.CoreFeatures.RadioWide;
using Motorola.MackinawCPS.CoreFeatures.TrunkingSystem;
using SpecialFeatures.AcpReportManagerLib;
using SpecialFeatures.Programming;
using SpecialFeatures.RadioFeatureSet;
using SpecialFeatures.RadioLanguagePack;
using SpecialFeatures.Security;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows;

#nullable disable
namespace SpecialFeatures.Comms;

public class Comms : IDisposable
{
  public RadioParams m_readRadioParams;
  protected DataPartition oldSecurityPartition;
  protected Dictionary<string, int[]> m_RadioSystemIds;
  protected Dictionary<string, int[]> m_RadioCnvSysIds;
  protected Dictionary<string, int> m_AstroOtarRadioIds;
  protected Dictionary<string, int> m_CustomerId;
  protected Dictionary<string, bool> m_RadioInhibitedTrunking;
  protected Dictionary<string, bool> m_RadioKilled;
  protected DataProfIP[] m_RadioDataProfIPs;
  protected string[] m_SoftIds;
  protected string m_BluetoothFriendlyName;
  protected bool m_EncryptPasswordFlag;
  protected string m_EncryptPassword;
  protected string m_FwVerInRadio = "";
  private OTAPProgrammingParameters d;
  private bool? e;
  private OTAPPrescenceResult f;
  private string g = "";
  public string m_LastLPKUserState;
  private IDeviceProxy h;
  private List<ValidationField> i;
  private bool j;
  private bool k;
  private bool l;
  private string m;

  public static event SpecialFeatures.Comms.Comms.DisplayUpdateStatus updateStatus
  {
    add
    {
      short num1 = 11186;
      int num2 = (int) num1;
      num1 = (short) 11186;
      int num3 = (int) num1;
      short num4;
      int num5;
      switch (num2 == num3 ? 1 : 0)
      {
        case 0:
        case 2:
label_5:
          num4 = (short) 1;
          if (num4 == (short) 0)
            ;
          num4 = (short) 0;
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
      SpecialFeatures.Comms.Comms.DisplayUpdateStatus displayUpdateStatus1;
      SpecialFeatures.Comms.Comms.DisplayUpdateStatus comparand;
      while (true)
      {
        switch (num5)
        {
          case 0:
            comparand = displayUpdateStatus1;
            SpecialFeatures.Comms.Comms.DisplayUpdateStatus displayUpdateStatus2 = comparand + value;
            displayUpdateStatus1 = Interlocked.CompareExchange<SpecialFeatures.Comms.Comms.DisplayUpdateStatus>(ref SpecialFeatures.Comms.Comms.a, displayUpdateStatus2, comparand);
            num4 = (short) 1;
            num5 = (int) (IntPtr) num4;
            continue;
          case 1:
            if (displayUpdateStatus1 == comparand)
            {
              num4 = (short) 2;
              num5 = (int) (IntPtr) num4;
              continue;
            }
            goto case 0;
          case 2:
            goto label_10;
          default:
            goto label_4;
        }
      }
label_10:
      num4 = (short) 0;
      return;
label_4:
      displayUpdateStatus1 = SpecialFeatures.Comms.Comms.a;
      goto label_5;
    }
    remove
    {
      short num1 = -14254;
      int num2 = (int) num1;
      num1 = (short) -14254;
      int num3 = (int) num1;
      short num4;
      int num5;
      switch (num2 == num3 ? 1 : 0)
      {
        case 0:
        case 2:
label_6:
          num4 = (short) 0;
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
      SpecialFeatures.Comms.Comms.DisplayUpdateStatus displayUpdateStatus1;
      SpecialFeatures.Comms.Comms.DisplayUpdateStatus comparand;
      while (true)
      {
        switch (num5)
        {
          case 0:
            comparand = displayUpdateStatus1;
            SpecialFeatures.Comms.Comms.DisplayUpdateStatus displayUpdateStatus2 = comparand - value;
            displayUpdateStatus1 = Interlocked.CompareExchange<SpecialFeatures.Comms.Comms.DisplayUpdateStatus>(ref SpecialFeatures.Comms.Comms.a, displayUpdateStatus2, comparand);
            num4 = (short) 1;
            num5 = (int) (IntPtr) num4;
            continue;
          case 1:
            if (displayUpdateStatus1 == comparand)
            {
              num4 = (short) 2;
              num5 = (int) (IntPtr) num4;
              continue;
            }
            goto case 0;
          case 2:
            goto label_10;
          default:
            goto label_4;
        }
      }
label_10:
      num4 = (short) 0;
      return;
label_4:
      num4 = (short) 1;
      if (num4 == (short) 0)
        ;
      displayUpdateStatus1 = SpecialFeatures.Comms.Comms.a;
      goto label_6;
    }
  }

  public static event SpecialFeatures.Comms.Comms.MainUIDisplayCBI displayCBI
  {
    add
    {
      short num1 = 5636;
      int num2 = (int) num1;
      num1 = (short) 5636;
      int num3 = (int) num1;
      short num4;
      int num5;
      switch (num2 == num3 ? 1 : 0)
      {
        case 0:
        case 2:
label_6:
          num4 = (short) 0;
          num5 = (int) (IntPtr) num4;
          break;
        default:
          num4 = (short) 1;
          if (num4 == (short) 0)
            ;
          num4 = (short) 0;
          if (num4 == (short) 0)
            ;
          switch (0)
          {
            case 0:
              goto label_5;
          }
          break;
      }
      SpecialFeatures.Comms.Comms.MainUIDisplayCBI mainUiDisplayCbi1;
      SpecialFeatures.Comms.Comms.MainUIDisplayCBI comparand;
      while (true)
      {
        switch (num5)
        {
          case 0:
            comparand = mainUiDisplayCbi1;
            SpecialFeatures.Comms.Comms.MainUIDisplayCBI mainUiDisplayCbi2 = comparand + value;
            mainUiDisplayCbi1 = Interlocked.CompareExchange<SpecialFeatures.Comms.Comms.MainUIDisplayCBI>(ref SpecialFeatures.Comms.Comms.b, mainUiDisplayCbi2, comparand);
            num4 = (short) 1;
            num5 = (int) (IntPtr) num4;
            continue;
          case 1:
            if (mainUiDisplayCbi1 == comparand)
            {
              num4 = (short) 2;
              num5 = (int) (IntPtr) num4;
              continue;
            }
            goto case 0;
          case 2:
            goto label_10;
          default:
            goto label_5;
        }
      }
label_10:
      num4 = (short) 0;
      return;
label_5:
      mainUiDisplayCbi1 = SpecialFeatures.Comms.Comms.b;
      goto label_6;
    }
    remove
    {
      short num1 = -23232;
      int num2 = (int) num1;
      num1 = (short) -23232;
      int num3 = (int) num1;
      short num4;
      switch (num2 == num3 ? 1 : 0)
      {
        case 0:
        case 2:
label_9:
          num4 = (short) 0;
          break;
        default:
          num4 = (short) 0;
          if (num4 == (short) 0)
            ;
          int num5;
          SpecialFeatures.Comms.Comms.MainUIDisplayCBI mainUiDisplayCbi1;
          switch (0)
          {
            case 0:
label_4:
              mainUiDisplayCbi1 = SpecialFeatures.Comms.Comms.b;
              num4 = (short) 2;
              num5 = (int) (IntPtr) num4;
              goto default;
            default:
              SpecialFeatures.Comms.Comms.MainUIDisplayCBI comparand;
              while (true)
              {
                switch (num5)
                {
                  case 0:
                    goto label_9;
                  case 1:
                    num4 = (short) 1;
                    if (num4 == (short) 0)
                      ;
                    if (mainUiDisplayCbi1 == comparand)
                    {
                      num4 = (short) 0;
                      num5 = (int) (IntPtr) num4;
                      continue;
                    }
                    goto case 2;
                  case 2:
                    comparand = mainUiDisplayCbi1;
                    SpecialFeatures.Comms.Comms.MainUIDisplayCBI mainUiDisplayCbi2 = comparand - value;
                    mainUiDisplayCbi1 = Interlocked.CompareExchange<SpecialFeatures.Comms.Comms.MainUIDisplayCBI>(ref SpecialFeatures.Comms.Comms.b, mainUiDisplayCbi2, comparand);
                    num4 = (short) 1;
                    num5 = (int) (IntPtr) num4;
                    continue;
                  default:
                    goto label_4;
                }
              }
          }
      }
    }
  }

  public static event SpecialFeatures.Comms.Comms.MainUIDisplayOTAP displayOTAP
  {
    add
    {
      short num1 = -5794;
      int num2 = (int) num1;
      num1 = (short) -5794;
      int num3 = (int) num1;
      short num4;
      switch (num2 == num3 ? 1 : 0)
      {
        case 0:
        case 2:
label_9:
          num4 = (short) 0;
          break;
        default:
          num4 = (short) 0;
          if (num4 == (short) 0)
            ;
          int num5;
          SpecialFeatures.Comms.Comms.MainUIDisplayOTAP mainUiDisplayOtap1;
          switch (0)
          {
            case 0:
label_4:
              mainUiDisplayOtap1 = SpecialFeatures.Comms.Comms.c;
              num4 = (short) 1;
              if (num4 == (short) 0)
                ;
              num4 = (short) 2;
              num5 = (int) (IntPtr) num4;
              goto default;
            default:
              SpecialFeatures.Comms.Comms.MainUIDisplayOTAP comparand;
              while (true)
              {
                switch (num5)
                {
                  case 0:
                    goto label_9;
                  case 1:
                    if (mainUiDisplayOtap1 == comparand)
                    {
                      num4 = (short) 0;
                      num5 = (int) (IntPtr) num4;
                      continue;
                    }
                    goto case 2;
                  case 2:
                    comparand = mainUiDisplayOtap1;
                    SpecialFeatures.Comms.Comms.MainUIDisplayOTAP mainUiDisplayOtap2 = comparand + value;
                    mainUiDisplayOtap1 = Interlocked.CompareExchange<SpecialFeatures.Comms.Comms.MainUIDisplayOTAP>(ref SpecialFeatures.Comms.Comms.c, mainUiDisplayOtap2, comparand);
                    num4 = (short) 1;
                    num5 = (int) (IntPtr) num4;
                    continue;
                  default:
                    goto label_4;
                }
              }
          }
      }
    }
    remove
    {
      short num1 = 12334;
      int num2 = (int) num1;
      num1 = (short) 12334;
      int num3 = (int) num1;
      short num4;
      switch (num2 == num3 ? 1 : 0)
      {
        case 0:
        case 2:
label_8:
          num4 = (short) 1;
          if (num4 == (short) 0)
            ;
          num4 = (short) 0;
          break;
        default:
          num4 = (short) 0;
          if (num4 == (short) 0)
            ;
          int num5;
          SpecialFeatures.Comms.Comms.MainUIDisplayOTAP mainUiDisplayOtap1;
          switch (0)
          {
            case 0:
label_4:
              mainUiDisplayOtap1 = SpecialFeatures.Comms.Comms.c;
              num4 = (short) 2;
              num5 = (int) (IntPtr) num4;
              goto default;
            default:
              SpecialFeatures.Comms.Comms.MainUIDisplayOTAP comparand;
              while (true)
              {
                switch (num5)
                {
                  case 0:
                    goto label_8;
                  case 1:
                    if (mainUiDisplayOtap1 == comparand)
                    {
                      num4 = (short) 0;
                      num5 = (int) (IntPtr) num4;
                      continue;
                    }
                    goto case 2;
                  case 2:
                    comparand = mainUiDisplayOtap1;
                    SpecialFeatures.Comms.Comms.MainUIDisplayOTAP mainUiDisplayOtap2 = comparand - value;
                    mainUiDisplayOtap1 = Interlocked.CompareExchange<SpecialFeatures.Comms.Comms.MainUIDisplayOTAP>(ref SpecialFeatures.Comms.Comms.c, mainUiDisplayOtap2, comparand);
                    num4 = (short) 1;
                    num5 = (int) (IntPtr) num4;
                    continue;
                  default:
                    goto label_4;
                }
              }
          }
      }
    }
  }

  public IshItemCollection ReadRadio(COMMS_OP readType, object lastCommsUserState)
  {
    int num1;
    short num2;
    switch (0)
    {
      case 0:
label_2:
        this.m_readRadioParams = (RadioParams) null;
        num2 = (short) 5;
        num1 = (int) (IntPtr) num2;
        goto default;
      default:
        while (true)
        {
          switch (num1)
          {
            case 0:
              if (lastCommsUserState != null)
              {
                num2 = (short) 3;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              break;
            case 1:
              goto label_6;
            case 2:
              num2 = (short) 0;
              num1 = (int) (IntPtr) num2;
              continue;
            case 3:
              num2 = (short) -28230;
              int num3 = (int) num2;
              num2 = (short) -28230;
              int num4 = (int) num2;
              switch (num3 == num4 ? 1 : 0)
              {
                case 0:
                case 2:
                  break;
                default:
                  num2 = (short) 0;
                  if (num2 == (short) 0)
                    ;
                  this.d = lastCommsUserState as OTAPProgrammingParameters;
                  num2 = (short) 4;
                  num1 = (int) (IntPtr) num2;
                  continue;
              }
              break;
            case 4:
              goto label_8;
            case 5:
              if (readType == COMMS_OP.OTAP_READ_WRITE)
              {
                num2 = (short) 2;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_14;
            default:
              goto label_2;
          }
          this.d = (OTAPProgrammingParameters) null;
          num2 = (short) 1;
          num1 = (int) (IntPtr) num2;
        }
label_6:
        num2 = (short) 0;
        goto label_14;
label_8:
        num2 = (short) 1;
        if (num2 == (short) 0)
          ;
label_14:
        string empty = string.Empty;
        return this.ReadRadio(readType, ref empty);
    }
  }

  public IshItemCollection ReadRadio(
    COMMS_OP readType,
    ref string errorMsg,
    bool isCruncherWriteCheckPBA = false,
    bool isCruncherMode = false)
  {
    int A_1_1 = 3;
    int num1 = 0;
    switch (num1)
    {
      default:
        IshItemCollection ishItemCollection;
        RadioParams A_1_2;
        bool flag;
        short num2;
        switch (0)
        {
          case 0:
label_3:
            ishItemCollection = (IshItemCollection) null;
            A_1_2 = (RadioParams) null;
            // ISSUE: reference to a compiler-generated field
            SpecialFeatures.Comms.Comms.a(0.0, AppResources.Opening_Port);
            flag = this.a(readType, ref A_1_2, true, (RadioOperation) 2L, A_5: RptMgrErrorHandler.b("뚅ꚇ몉ꊋ뺍뺏ꊑ", A_1_1));
            num2 = (short) 2;
            num1 = (int) (IntPtr) num2;
            goto default;
          default:
            while (true)
            {
              switch (num1)
              {
                case 0:
                  goto label_6;
                case 1:
                  num2 = (short) 1;
                  if (num2 == (short) 0)
                    ;
                  this.m_readRadioParams = A_1_2;
                  num2 = (short) 0;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 2:
                  num2 = (short) 0;
                  if (flag)
                  {
                    num2 = (short) 1;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_63;
                default:
                  goto label_3;
              }
            }
label_6:
            try
            {
              PbaObject pbaObject;
              switch (0)
              {
                case 0:
label_8:
                  // ISSUE: reference to a compiler-generated field
                  SpecialFeatures.Comms.Comms.a(1.0, AppResources.Open_Port_Complete);
                  // ISSUE: reference to a compiler-generated field
                  SpecialFeatures.Comms.Comms.a(0.0, AppResources.Read_Radio_Info);
                  List<IshHeader> blockList = new List<IshHeader>();
                  IshHeader ishHeader;
                  // ISSUE: explicit constructor call
                  ((IshHeader) ref ishHeader).\u002Ector((byte) 208 /*0xD0*/, (ushort) 1026, (ushort) 0);
                  blockList.Add(ishHeader);
                  // ISSUE: explicit constructor call
                  ((IshHeader) ref ishHeader).\u002Ector((byte) 208 /*0xD0*/, (ushort) 1029, (ushort) 0);
                  blockList.Add(ishHeader);
                  // ISSUE: explicit constructor call
                  ((IshHeader) ref ishHeader).\u002Ector((byte) 208 /*0xD0*/, (ushort) 1030, (ushort) 0);
                  blockList.Add(ishHeader);
                  pbaObject = this.h.ReadBlock(A_1_2, blockList, new ProgressChangedEventHandler(this.b));
                  this.m_RadioInhibitedTrunking = ParseDataHelper.IsRadioInhibitedTrunking(pbaObject);
                  this.m_RadioKilled = ParseDataHelper.IsRadioKilled(pbaObject);
                  this.a(pbaObject);
                  num2 = (short) 23;
                  num1 = (int) (IntPtr) num2;
                  goto default;
                default:
                  Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation radioInformation;
                  PbaObject pba;
                  string str;
                  while (true)
                  {
                    switch (num1)
                    {
                      case 0:
                      case 14:
                        // ISSUE: reference to a compiler-generated field
                        SpecialFeatures.Comms.Comms.a(0.0, AppResources.ReadRadio_Reading_codeplug_from_radio);
                        pba = this.h.Read(A_1_2, new ProgressChangedEventHandler(this.b));
                        num2 = (short) 10;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      case 1:
                        this.m_CustomerId = ParseDataHelper.ReadCustomerID(pbaObject);
                        num2 = (short) 13;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      case 2:
                        num2 = (short) 19;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      case 3:
                        num2 = (short) 5;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      case 4:
                        if (this.m_readRadioParams.ModelNumber.Equals(AppResources.Txm_3000_Model_Number))
                        {
                          num2 = (short) 3;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        }
                        goto case 0;
                      case 5:
                        if (!isCruncherMode)
                        {
                          num2 = (short) 24;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        }
                        goto case 0;
                      case 6:
                        // ISSUE: reference to a compiler-generated field
                        SpecialFeatures.Comms.Comms.a(1.0, AppResources.Read_Radio_Info_Complete);
                        num2 = (short) 4;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      case 7:
                        errorMsg = AppResources.The_radio_being_read_is_KILLED;
                        AppInfoManager.StatusMsgReport.RegisterMessage((StatusMsgType) 2, errorMsg);
                        // ISSUE: reference to a compiler-generated field
                        SpecialFeatures.Comms.Comms.a(0.0, errorMsg);
                        flag = false;
                        num2 = (short) 12;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      case 8:
                        ishItemCollection = pba.GetCodeplugInIshItemCollection();
                        this.m_RadioSystemIds = ParseDataHelper.ReadRadioTrkSystemNamesTypesAndUnitIds(pba.GetCodeplugInIshItemCollection());
                        this.m_RadioCnvSysIds = ParseDataHelper.ReadConvSysIds(pba);
                        this.m_AstroOtarRadioIds = ParseDataHelper.ReadAstroOtarRadioIds(pba);
                        num2 = (short) 26;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      case 9:
                        radioInformation.General.RadInfoGeneralInstalledTxmCertificate_UIValue = AcgResources.ID_NONE;
                        num2 = (short) 14;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      case 10:
                        if (pba != null)
                        {
                          num2 = (short) 8;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        }
                        goto label_25;
                      case 11:
                        if (flag)
                        {
                          num2 = (short) 6;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        }
                        goto case 26;
                      case 12:
                        num2 = (short) 15;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      case 13:
                        if (!RadioAccessValidator.CheckIfCustomerIDIsInACK(this.c()))
                        {
                          num2 = (short) 7;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        }
                        goto case 12;
                      case 15:
                        if (flag)
                        {
                          num2 = (short) 22;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        }
                        goto case 21;
                      case 16 /*0x10*/:
                        if (this.d() & flag)
                        {
                          num2 = (short) 1;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        }
                        goto case 12;
                      case 17:
                        goto label_62;
                      case 18:
                        errorMsg = AppResources.The_radio_being_read_is_INHIBITED;
                        AppInfoManager.StatusMsgReport.RegisterMessage((StatusMsgType) 2, errorMsg);
                        // ISSUE: reference to a compiler-generated field
                        SpecialFeatures.Comms.Comms.a(0.0, errorMsg);
                        flag = false;
                        num2 = (short) 20;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      case 19:
                        if (this.e())
                        {
                          num2 = (short) 18;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        }
                        goto case 20;
                      case 20:
                        num2 = (short) 16 /*0x10*/;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      case 21:
                        num2 = (short) 11;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      case 22:
                        flag = this.a(readType, A_1_2.SerialNumber);
                        num2 = (short) 21;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      case 23:
                        if (!isCruncherWriteCheckPBA)
                        {
                          num2 = (short) 2;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        }
                        goto case 20;
                      case 24:
                        str = this.h.QueryTxmCertificate(this.m_readRadioParams, RptMgrErrorHandler.b("ꦅ쮇욉얋쮍\uDE8F욑쮓햕\uDD97좙좛놝\uF49F瑱\uE9A3殮\uEBA7\uEFA9ﺫ節龯", A_1_1));
                        radioInformation = FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation;
                        num2 = (short) 25;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      case 25:
                        if (str != null)
                        {
                          radioInformation.General.RadInfoGeneralInstalledTxmCertificate_UIValue = str;
                          num2 = (short) 0;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        }
                        num2 = (short) 9;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      case 26:
                        num2 = (short) 17;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      default:
                        goto label_8;
                    }
                  }
label_25:
                  throw new Exception(AppResources.Read_radio_PBA_is_null);
              }
            }
            catch (CommonException ex)
            {
              // ISSUE: reference to a compiler-generated field
              SpecialFeatures.Comms.Comms.a(0.0, ((Exception) ex).Message);
            }
            catch (Exception ex)
            {
              if (string.IsNullOrEmpty(ex.Message))
              {
                // ISSUE: reference to a compiler-generated field
                SpecialFeatures.Comms.Comms.a(0.0, AppResources.Failed_to_communicate_with_the_radio);
              }
              else
              {
                // ISSUE: reference to a compiler-generated field
                SpecialFeatures.Comms.Comms.a(0.0, ex.Message);
              }
              Exception innerException = ex.InnerException;
              Logger.Log(RptMgrErrorHandler.b("\uDD85", A_1_1) + DateTime.Now.ToString() + RptMgrErrorHandler.b("ꚅꖇꪉ", A_1_1) + ex.Message + RptMgrErrorHandler.b("\uDB85", A_1_1));
            }
            finally
            {
              int num3 = 2;
              while (true)
              {
                short num4;
                switch (num3)
                {
                  case 0:
                    goto label_59;
                  case 1:
                    num4 = (short) -8118;
                    int num5 = (int) num4;
                    num4 = (short) -8118;
                    int num6 = (int) num4;
                    switch (num5 == num6 ? 1 : 0)
                    {
                      case 0:
                      case 2:
                        break;
                      default:
                        num4 = (short) 0;
                        if (num4 == (short) 0)
                          ;
                        Thread.Sleep(500);
                        num4 = (short) 0;
                        num3 = (int) (IntPtr) num4;
                        continue;
                    }
                    break;
                  case 2:
                    switch (0)
                    {
                      case 0:
                        goto label_54;
                      default:
                        continue;
                    }
                  default:
label_54:
                    if (readType != COMMS_OP.USB_READ_WRITE)
                      goto label_59;
                    break;
                }
                num4 = (short) 1;
                num3 = (int) (IntPtr) num4;
              }
label_59:
              this.a();
            }
label_62:
            return ishItemCollection;
label_63:
            Logger.Log(RptMgrErrorHandler.b("\uDD85", A_1_1) + DateTime.Now.ToString() + RptMgrErrorHandler.b("ꚅꖇꪉ\uDE8B\uEB8D\uF18F\uF691뒓\uE495聯ﺙ\uF59B\uF19D肟쒡얣쾥쒧쾩좫肭\uEDAF", A_1_1));
            return (IshItemCollection) null;
        }
    }
  }

  private void b(object A_0, ProgressChangedEventArgs A_1)
  {
    short num1 = 1;
    if (num1 == (short) 0)
      ;
    if (A_1.ProgressPercentage == 100)
    {
      num1 = (short) -22831;
      int num2 = (int) num1;
      num1 = (short) -22831;
      int num3 = (int) num1;
      switch (num2 == num3 ? 1 : 0)
      {
        case 0:
        case 2:
          // ISSUE: reference to a compiler-generated field
          SpecialFeatures.Comms.Comms.a(1.0, AppResources.ReadRadio_Calling_End_Read_Radio);
          break;
        default:
          num1 = (short) 0;
          num1 = (short) 0;
          if (num1 == (short) 0)
            goto case 0;
          goto case 0;
      }
    }
    else
    {
      // ISSUE: reference to a compiler-generated field
      SpecialFeatures.Comms.Comms.a((double) A_1.ProgressPercentage * 0.01, AppResources.Reading_radio_codeplug_);
    }
  }

  public bool WriteRadio(
    IshItemCollection radioCodeplug,
    COMMS_OP WriteType,
    RadioParams codeplgParams,
    object lastCommsUserState,
    bool inbatchMode = false)
  {
    int num1 = 5;
    short num2;
    while (true)
    {
      num2 = (short) 1;
      if (num2 == (short) 0)
        ;
      switch (num1)
      {
        case 0:
        case 1:
          goto label_11;
        case 2:
          if (lastCommsUserState == null)
          {
            this.d = (OTAPProgrammingParameters) null;
            num2 = (short) 0;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          num2 = (short) 4;
          num1 = (int) (IntPtr) num2;
          continue;
        case 3:
          num2 = (short) 2;
          num1 = (int) (IntPtr) num2;
          continue;
        case 4:
          this.d = lastCommsUserState as OTAPProgrammingParameters;
          num2 = (short) 0;
          num2 = (short) 1;
          num1 = (int) (IntPtr) num2;
          continue;
        case 5:
          switch (0)
          {
            case 0:
              break;
            default:
              continue;
          }
          break;
      }
      if (WriteType == COMMS_OP.OTAP_READ_WRITE)
      {
        num2 = (short) 3;
        num1 = (int) (IntPtr) num2;
      }
      else
        break;
    }
label_11:
    num2 = (short) 4374;
    int num3 = (int) num2;
    num2 = (short) 4374;
    int num4 = (int) num2;
    switch (num3 == num4 ? 1 : 0)
    {
      case 0:
      case 2:
        goto label_11;
      default:
        num2 = (short) 0;
        if (num2 == (short) 0)
          ;
        return this.WriteRadio(radioCodeplug, WriteType, codeplgParams, inbatchMode);
    }
  }

  public bool WriteRadio(
    IshItemCollection radioCodeplug,
    COMMS_OP WriteType,
    RadioParams codeplgParams,
    bool inbatchMode = false)
  {
    int A_1 = 4;
    switch (0)
    {
      default:
        short num1 = 1;
        if (num1 == (short) 0)
          ;
        bool flag1 = false;
        bool flag2 = false;
        try
        {
          num1 = (short) 14;
          int num2 = (int) (IntPtr) num1;
          while (true)
          {
            num1 = (short) -18694;
            int num3 = (int) num1;
            num1 = (short) -18694;
            int num4 = (int) num1;
            PbaObject targetPba;
            switch (num3 == num4 ? 1 : 0)
            {
              case 0:
              case 2:
label_19:
                targetPba = new PbaObject();
                targetPba.SetCodeplug(radioCodeplug);
                targetPba.CodeplugData.CPVersion = AppInfoManager.AppVersion;
                targetPba.ValidationFields = this.i;
                num1 = (short) 10;
                num2 = (int) (IntPtr) num1;
                continue;
              default:
                num1 = (short) 0;
                if (num1 == (short) 0)
                  ;
                switch (num2)
                {
                  case 0:
                    if (!this.h.CurrentRadioIsConnected)
                    {
                      num1 = (short) 8;
                      num2 = (int) (IntPtr) num1;
                      continue;
                    }
                    break;
                  case 1:
                    // ISSUE: reference to a compiler-generated field
                    SpecialFeatures.Comms.Comms.a(0.0, AppResources.LP_Cannot_Determine_Host_Version);
                    num1 = (short) 11;
                    num2 = (int) (IntPtr) num1;
                    continue;
                  case 2:
                    this.b(inbatchMode);
                    num1 = (short) 6;
                    num2 = (int) (IntPtr) num1;
                    continue;
                  case 3:
                    goto label_19;
                  case 4:
                    goto label_42;
                  case 5:
                    num1 = (short) 4;
                    num2 = (int) (IntPtr) num1;
                    continue;
                  case 6:
                  case 11:
                    // ISSUE: reference to a compiler-generated field
                    SpecialFeatures.Comms.Comms.a(0.0, AppResources.WriteRadio_Writing_codeplug_to_radio);
                    this.h.Write(this.m_readRadioParams, targetPba, new ProgressChangedEventHandler(this.a));
                    flag1 = true;
                    num1 = (short) 12;
                    num2 = (int) (IntPtr) num1;
                    continue;
                  case 7:
                    num1 = (short) 0;
                    num2 = (int) (IntPtr) num1;
                    continue;
                  case 8:
                    goto label_13;
                  case 9:
                    if (!UtilityMack.IsAPXNextOrAloha)
                    {
                      num1 = (short) 2;
                      num2 = (int) (IntPtr) num1;
                      continue;
                    }
                    goto case 6;
                  case 10:
                    if (!string.IsNullOrEmpty(this.m_readRadioParams.HostVersion))
                    {
                      num1 = (short) 9;
                      num2 = (int) (IntPtr) num1;
                      continue;
                    }
                    num1 = (short) 1;
                    num2 = (int) (IntPtr) num1;
                    continue;
                  case 12:
                    try
                    {
                      this.a();
                      goto case 5;
                    }
                    catch
                    {
                      flag1 = false;
                      flag2 = true;
                      throw;
                    }
                  case 13:
                    if (this.m_readRadioParams != null)
                    {
                      num1 = (short) 3;
                      num2 = (int) (IntPtr) num1;
                      continue;
                    }
                    // ISSUE: reference to a compiler-generated field
                    SpecialFeatures.Comms.Comms.a(0.0, AppResources.Unable_to_read_Radio_Parameters);
                    num1 = (short) 5;
                    num2 = (int) (IntPtr) num1;
                    continue;
                  case 14:
                    switch (0)
                    {
                      case 0:
                        goto label_8;
                      default:
                        continue;
                    }
                  default:
label_8:
                    if (this.h != null)
                    {
                      num1 = (short) 7;
                      num2 = (int) (IntPtr) num1;
                      continue;
                    }
                    break;
                }
                num1 = (short) 13;
                num2 = (int) (IntPtr) num1;
                continue;
            }
          }
label_13:
          throw new Exception(AppResources.Could_not_find_a_radio_connected_to_a_USB_port);
        }
        catch (CommonException ex)
        {
          // ISSUE: reference to a compiler-generated field
          SpecialFeatures.Comms.Comms.a(0.0, ((Exception) ex).Message);
          Logger.Log(RptMgrErrorHandler.b("\uDC86", A_1) + DateTime.Now.ToString() + RptMgrErrorHandler.b("Ꞇꒈꮊ", A_1) + ((Exception) ex).Message + RptMgrErrorHandler.b("\uDA86", A_1));
        }
        catch (Exception ex)
        {
          if (string.IsNullOrEmpty(ex.Message))
          {
            // ISSUE: reference to a compiler-generated field
            SpecialFeatures.Comms.Comms.a(0.0, AppResources.Failed_to_communicate_with_the_radio);
          }
          else
          {
            // ISSUE: reference to a compiler-generated field
            SpecialFeatures.Comms.Comms.a(0.0, ex.Message);
          }
          Exception innerException = ex.InnerException;
          Logger.Log(RptMgrErrorHandler.b("\uDC86", A_1) + DateTime.Now.ToString() + RptMgrErrorHandler.b("Ꞇꒈꮊ", A_1) + ex.Message + RptMgrErrorHandler.b("\uDA86", A_1));
        }
        finally
        {
          int num5 = 2;
          while (true)
          {
            switch (num5)
            {
              case 0:
                this.a();
                num5 = 1;
                continue;
              case 1:
                goto label_41;
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
            if (!flag2)
              num5 = 0;
            else
              break;
          }
label_41:;
        }
label_42:
        return flag1;
    }
  }

  private void b(bool A_0)
  {
    int A_1 = 9;
    short num1 = 1;
    if (num1 == (short) 0)
      ;
    num1 = (short) 0;
    int num2 = (int) num1;
    switch (num2)
    {
      default:
        int codeplugLanguageIndx;
        bool isPortablePro;
        switch (0)
        {
          case 0:
label_4:
            codeplugLanguageIndx = ((AcpField<int>) (FeatureManager.GetFeature(2010)[0] as Motorola.MackinawCPS.CoreFeatures.DisplayAndMenu.DisplayAndMenu).Advanced.DispMenuAdvancedLanguageSelection_A8386).Value;
            isPortablePro = UtilityMack.IsPortablePro;
            this.m_LastLPKUserState = (string) null;
            num1 = (short) 10;
            num2 = (int) (IntPtr) num1;
            goto default;
          default:
            while (true)
            {
              LanguagePackData languagePackData;
              switch (num2)
              {
                case 0:
                  goto label_17;
                case 1:
                  num1 = (short) 9892;
                  int num3 = (int) num1;
                  num1 = (short) 9892;
                  int num4 = (int) num1;
                  switch (num3 == num4 ? 1 : 0)
                  {
                    case 0:
                    case 2:
                      goto label_21;
                    default:
                      num1 = (short) 0;
                      if (num1 == (short) 0)
                        ;
                      // ISSUE: reference to a compiler-generated field
                      SpecialFeatures.Comms.Comms.a(0.0, AppResources.LP_Begin_Language_Pack_Update);
                      languagePackData = LanguagePackHelper.BuildWriteLanguageData(this.m_readRadioParams.HostVersion, false);
                      num1 = (short) 8;
                      num2 = (int) (IntPtr) num1;
                      continue;
                  }
                case 2:
                  if (!string.IsNullOrEmpty(LanguagePackHelper.warningOTAPMessage))
                  {
                    num1 = (short) 4;
                    num2 = (int) (IntPtr) num1;
                    continue;
                  }
                  goto label_13;
                case 3:
                  // ISSUE: reference to a compiler-generated field
                  SpecialFeatures.Comms.Comms.a(0.0, LanguagePackHelper.warningOTAPMessage);
                  num1 = (short) 5;
                  num2 = (int) (IntPtr) num1;
                  continue;
                case 4:
label_21:
                  this.m_LastLPKUserState = LanguagePackHelper.warningOTAPMessage;
                  num1 = (short) 7;
                  num2 = (int) (IntPtr) num1;
                  continue;
                case 5:
                  goto label_24;
                case 6:
                  if (LanguagePackHelper.IsFirmwareLPCompatible(this.m_readRadioParams.HostVersion, ref this.m_LastLPKUserState, codeplugLanguageIndx, isPortablePro))
                  {
                    num1 = (short) 0;
                    num1 = (short) 1;
                    num2 = (int) (IntPtr) num1;
                    continue;
                  }
                  break;
                case 7:
                  if (A_0)
                  {
                    num1 = (short) 3;
                    num2 = (int) (IntPtr) num1;
                    continue;
                  }
                  goto label_20;
                case 8:
                  languagePackData.ModelType = isPortablePro ? (ModelType) 0 : (ModelType) 1;
                  this.h.WriteLanguagePack(this.m_readRadioParams, languagePackData, new ProgressChangedEventHandler(this.a));
                  num1 = (short) 2;
                  num2 = (int) (IntPtr) num1;
                  continue;
                case 9:
                  num1 = (short) 6;
                  num2 = (int) (IntPtr) num1;
                  continue;
                case 10:
                  if (!(bool) Application.Current.Properties[(object) RptMgrErrorHandler.b("쾋\uE18Dﶏﾑ\uF593\uF895ﲗ횙\uF59B\uF09D얟\uE1A1\uF4A3\uF5A5", A_1)])
                  {
                    num1 = (short) 9;
                    num2 = (int) (IntPtr) num1;
                    continue;
                  }
                  break;
                default:
                  goto label_4;
              }
              // ISSUE: reference to a compiler-generated field
              SpecialFeatures.Comms.Comms.a(0.0, this.m_LastLPKUserState);
              Logger.Log(RptMgrErrorHandler.b("힋", A_1) + DateTime.Now.ToString() + RptMgrErrorHandler.b("겋ꎍ낏작望\uE595\uED97\uEA99\uEC9B\uF19D얟킡킣쎥첧誩\uE0ABﺭﮯ銱솳욵\uDFB7좹\uDDBB\uDABDꖿ\uE2C1ꛃ\uA7C5믇꿉\uA8CB\uEECD뿏병\uF4D3郕迗龎ꫛ믝鋟釡跣觥蛧럩", A_1));
              num1 = (short) 0;
              num2 = (int) (IntPtr) num1;
            }
label_17:
            return;
label_24:
            return;
label_13:
            return;
label_20:
            return;
        }
    }
  }

  private void a(object A_0, ProgressChangedEventArgs A_1)
  {
    int A_1_1 = 1;
    int num1 = 12;
    while (true)
    {
      short num2;
      switch (num1)
      {
        case 0:
          if (!A_1.UserState.ToString().Equals(RptMgrErrorHandler.b("펃\uF485\uE187ﺉ\uE98B춍삏횑ﮓ\uF895ﶗ", A_1_1)))
          {
            num2 = (short) 8;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          num2 = (short) 6;
          num1 = (int) (IntPtr) num2;
          continue;
        case 1:
          goto label_7;
        case 2:
          goto label_6;
        case 3:
          if (A_1.UserState.ToString().Equals(RptMgrErrorHandler.b("펃\uF485\uE187ﺉ\uE58B\uE08D\uF78F\uDE91\uF593\uF895ﾗ\uEF99ﶛ劣얟톡", A_1_1)))
          {
            num2 = (short) 7;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          // ISSUE: reference to a compiler-generated field
          SpecialFeatures.Comms.Comms.a((double) A_1.ProgressPercentage * 0.01, AppResources.Writing_radio_codeplug);
          num2 = (short) 4;
          num1 = (int) (IntPtr) num2;
          continue;
        case 4:
          goto label_25;
        case 5:
          num2 = (short) 11;
          num1 = (int) (IntPtr) num2;
          continue;
        case 6:
          goto label_30;
        case 7:
          goto label_9;
        case 8:
          if (A_1.UserState.ToString().Equals(RptMgrErrorHandler.b("솃\uF485\uE987黎\uE98B춍삏횑ﮓ\uF895ﶗ", A_1_1)))
          {
            num2 = (short) -9178;
            int num3 = (int) num2;
            num2 = (short) -9178;
            int num4 = (int) num2;
            switch (num3 == num4 ? 1 : 0)
            {
              case 0:
              case 2:
                break;
              default:
                num2 = (short) 0;
                if (num2 == (short) 0)
                  ;
                num2 = (short) 1;
                num1 = (int) (IntPtr) num2;
                continue;
            }
          }
          else
            goto label_29;
          break;
        case 9:
          if (!A_1.UserState.ToString().Equals(RptMgrErrorHandler.b("솃\uF485\uE987黎\uE58B\uE08D\uF78F톑쒓", A_1_1)))
          {
            num2 = (short) 3;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          break;
        case 10:
          goto label_8;
        case 11:
          if (A_1.UserState.ToString().Equals(RptMgrErrorHandler.b("펃\uF485\uE187ﺉ\uE98B슍\uF18Fﲑ\uF393\uE395聯ﶙ鍊\uED9D\uE49F춡쪣쎥", A_1_1)))
          {
            num2 = (short) 10;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          num2 = (short) 0;
          num1 = (int) (IntPtr) num2;
          continue;
        case 12:
          switch (0)
          {
            case 0:
              goto label_3;
            default:
              continue;
          }
        default:
label_3:
          num2 = (short) 0;
          if (A_1.ProgressPercentage == 100)
          {
            num2 = (short) 1;
            if (num2 == (short) 0)
              ;
            num2 = (short) 5;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          num2 = (short) 9;
          num1 = (int) (IntPtr) num2;
          continue;
      }
      num2 = (short) 2;
      num1 = (int) (IntPtr) num2;
    }
label_25:
    return;
label_6:
    // ISSUE: reference to a compiler-generated field
    SpecialFeatures.Comms.Comms.a((double) A_1.ProgressPercentage * 0.01, AppResources.Radio_Erase_in_Progress_please_wait);
    return;
label_7:
    // ISSUE: reference to a compiler-generated field
    SpecialFeatures.Comms.Comms.a(1.0, AppResources.Radio_Erasing_CP_Completed);
    return;
label_8:
    // ISSUE: reference to a compiler-generated field
    SpecialFeatures.Comms.Comms.a(1.0, AppResources.LP_Language_Pack_Update_Success);
    return;
label_9:
    // ISSUE: reference to a compiler-generated field
    SpecialFeatures.Comms.Comms.a((double) A_1.ProgressPercentage * 0.01, AppResources.LP_Begin_Language_Pack_Update);
    return;
label_29:
    return;
label_30:
    // ISSUE: reference to a compiler-generated field
    SpecialFeatures.Comms.Comms.a(1.0, AppResources.Writing_radio_codeplug_completed);
  }

  public bool LoadTxmCertificate(string fileName, COMMS_OP WriteType, bool inbatchMode = false)
  {
    int num1 = 3;
    RadioParams currentRadioParams;
    while (true)
    {
      short num2;
      switch (num1)
      {
        case 0:
          goto label_8;
        case 1:
          num2 = (short) 9422;
          int num3 = (int) num2;
          num2 = (short) 9422;
          int num4 = (int) num2;
          switch (num3 == num4 ? 1 : 0)
          {
            case 0:
            case 2:
              break;
            case 1:
              num2 = (short) 0;
              if (num2 == (short) 0)
                ;
              if (WriteType == COMMS_OP.USB_READ_WRITE)
              {
                num2 = (short) 2;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_9;
            default:
              num2 = (short) 0;
              goto case 1;
          }
          break;
        case 2:
          goto label_6;
        case 3:
          switch (0)
          {
            case 0:
              goto label_3;
            default:
              continue;
          }
        default:
label_3:
          if (!this.VerifyTxmRadio(WriteType, out currentRadioParams))
          {
            num2 = (short) 0;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          break;
      }
      num2 = (short) 1;
      if (num2 == (short) 0)
        ;
      this.m_readRadioParams = currentRadioParams;
      num2 = (short) 1;
      num1 = (int) (IntPtr) num2;
    }
label_6:
    try
    {
      this.a(currentRadioParams, (RadioOperation) 1024L /*0x0400*/);
    }
    catch (Exception ex)
    {
      AppInfoManager.StatusMsgReport.Clear();
      AppInfoManager.StatusMsgReport.RegisterMessage((StatusMsgType) 0, AppResources.Load_Txm_Cert_Failed);
      return false;
    }
    int num5 = this.h.LoadTxmCertificate(this.m_readRadioParams, fileName) ? 1 : 0;
    this.a();
    return num5 != 0;
label_8:
    return false;
label_9:
    return false;
  }

  public bool blockRadioWrite(
    COMMS_OP WriteType,
    object lastCommsUserState,
    int Headless = 0,
    string HeadlessAddr = "0.0.0.0",
    bool WriteProtecWriteProtectedRadio = false,
    bool otapBatchProgramming = false)
  {
    int num1 = 3;
    short num2;
    while (true)
    {
      num2 = (short) 0;
      switch (num1)
      {
        case 0:
          this.d = lastCommsUserState as OTAPProgrammingParameters;
          num2 = (short) 1;
          num1 = (int) (IntPtr) num2;
          continue;
        case 1:
          goto label_16;
        case 2:
          num2 = (short) 4;
          num1 = (int) (IntPtr) num2;
          continue;
        case 3:
          switch (0)
          {
            case 0:
              goto label_3;
            default:
              continue;
          }
        case 4:
          if (WriteType == COMMS_OP.OTAP_CLONE)
          {
            num2 = (short) 6;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto label_16;
        case 5:
          num2 = (short) -10221;
          int num3 = (int) num2;
          num2 = (short) -10221;
          int num4 = (int) num2;
          switch (num3 == num4 ? 1 : 0)
          {
            case 0:
            case 2:
              goto label_3;
            default:
              goto label_15;
          }
        case 6:
          num2 = (short) 1;
          if (num2 == (short) 0)
            ;
          num2 = (short) 7;
          num1 = (int) (IntPtr) num2;
          continue;
        case 7:
          if (lastCommsUserState != null)
          {
            num2 = (short) 0;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          this.d = (OTAPProgrammingParameters) null;
          num2 = (short) 5;
          num1 = (int) (IntPtr) num2;
          continue;
        default:
label_3:
          if (WriteType != COMMS_OP.OTAP_READ_WRITE)
          {
            num2 = (short) 2;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto case 6;
      }
    }
label_15:
    num2 = (short) 0;
    if (num2 == (short) 0)
      ;
label_16:
    return this.blockRadioWrite(WriteType, Headless, HeadlessAddr, WriteProtecWriteProtectedRadio, otapBatchProgramming);
  }

  public bool VerifyTxmRadio(COMMS_OP WriteType, out RadioParams currentRadioParams)
  {
    int A_1 = 10;
    int num1 = 0;
    switch (num1)
    {
      default:
        short num2 = 10849;
        int num3 = (int) num2;
        num2 = (short) 10849;
        int num4 = (int) num2;
        switch (num3 == num4 ? 1 : 0)
        {
          case 0:
          case 2:
label_12:
            num2 = (short) 1;
            if (num2 == (short) 0)
              ;
            AppInfoManager.StatusMsgReport.Clear();
            AppInfoManager.StatusMsgReport.RegisterMessage((StatusMsgType) 0, AppResources.Txm_Not_Connected_Error_Message);
            return false;
          default:
            num2 = (short) 0;
            if (num2 == (short) 0)
              ;
            int A_4;
            string A_5;
            switch (0)
            {
              case 0:
label_5:
                currentRadioParams = new RadioParams();
                A_4 = 0;
                A_5 = RptMgrErrorHandler.b("붌ꆎꆐ붒ꖔ릖ꦘ", A_1);
                num2 = (short) 1;
                num1 = (int) (IntPtr) num2;
                goto default;
              default:
                while (true)
                {
                  switch (num1)
                  {
                    case 0:
                      goto label_11;
                    case 1:
                      if (!this.a(WriteType, ref currentRadioParams, false, (RadioOperation) 1024L /*0x0400*/, A_4, A_5))
                      {
                        num2 = (short) 2;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      num2 = (short) 4;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 2:
                      goto label_14;
                    case 3:
                      goto label_12;
                    case 4:
                      if (currentRadioParams.ModelNumber.Equals(AppResources.Txm_3000_Model_Number))
                      {
                        num2 = (short) 5;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      num2 = (short) 3;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 5:
                      if (!AcpDocument.ValidCodeplugVersion(currentRadioParams.CodeplugVersion))
                      {
                        num2 = (short) 0;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto label_18;
                    default:
                      goto label_5;
                  }
                }
label_11:
                num2 = (short) 0;
                AppInfoManager.StatusMsgReport.Clear();
                AppInfoManager.StatusMsgReport.RegisterMessage((StatusMsgType) 0, AppResources.Newer_CPS_Version_Required);
                return false;
label_14:
                AppInfoManager.StatusMsgReport.Clear();
                AppInfoManager.StatusMsgReport.RegisterMessage((StatusMsgType) 0, AppResources.Could_not_find_a_radio_connected_to_a_USB_port);
                return false;
label_18:
                return true;
            }
        }
    }
  }

  public bool blockRadioWrite(
    COMMS_OP WriteType,
    int Headless = 0,
    string HeadlessAddr = "0.0.0.0",
    bool WriteProtecWriteProtectedRadio = false,
    bool otapBatchProgramming = false,
    bool updateWriteProtect = false)
  {
    int A_1_1 = 1;
    int num1 = 0;
    switch (num1)
    {
      default:
        bool flag1;
        RadioParams A_1_2;
        short num2;
        switch (0)
        {
          case 0:
label_3:
            flag1 = false;
            A_1_2 = (RadioParams) null;
            this.m_readRadioParams = (RadioParams) null;
            // ISSUE: reference to a compiler-generated field
            SpecialFeatures.Comms.Comms.a(0.0, AppResources.Opening_Port);
            num2 = (short) 3;
            num1 = (int) (IntPtr) num2;
            goto default;
          default:
            while (true)
            {
              switch (num1)
              {
                case 0:
label_549:
                  num2 = (short) 6;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 1:
                  this.m_readRadioParams = A_1_2;
                  num2 = (short) 2;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 2:
                  try
                  {
                    num2 = (short) 338;
                    int num3 = (int) (IntPtr) num2;
                    while (true)
                    {
                      string stsMsg;
                      PbaObject pbaObject1;
                      bool ishItemPciCapable1;
                      RadioParams codeplug;
                      int num4;
                      bool ishItemPciCapable2;
                      bool ishItemPciCapable3;
                      bool ishItemPciCapable4;
                      bool ishItemPciCapable5;
                      string appVersion;
                      bool ishItemPciCapable6;
                      bool ishItemPciCapable7;
                      int int16_1;
                      int int16_2;
                      int int16_3;
                      int int16_4;
                      bool ishItemPciCapable8;
                      Collection<TrkSysBandPlan> radioTrkShuffledBandPlans;
                      PbaObject pbaObject2;
                      Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide radioWide1;
                      Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide radioWide2;
                      bool ishItemPciCapable9;
                      bool ishItemPciCapable10;
                      bool ishItemPciCapable11;
                      bool ishItemPciCapable12;
                      string stat1;
                      bool ishItemPciCapable13;
                      bool ishItemPciCapable14;
                      bool ishItemPciCapable15;
                      bool ishItemPciCapable16;
                      bool ishItemPciCapable17;
                      bool ishItemPciCapable18;
                      bool ishItemPciCapable19;
                      bool ishItemPciCapable20;
                      bool ishItemPciCapable21;
                      bool ishItemPciCapable22;
                      bool ishItemPciCapable23;
                      bool ishItemPciCapable24;
                      bool flag2;
                      bool ishItemPciCapable25;
                      bool ishItemPciCapable26;
                      bool ishItemPciCapable27;
                      bool ishItemPciCapable28;
                      bool ishItemPciCapable29;
                      Labtool labtool;
                      RadioSecurityData radioSecurityData;
                      bool ishItemPciCapable30;
                      string stsErrMsg;
                      bool ishItemPciCapable31;
                      bool ishItemPciCapable32;
                      bool ishItemPciCapable33;
                      bool ishItemPciCapable34;
                      bool ishItemPciCapable35;
                      bool ishItemPciCapable36;
                      switch (num3)
                      {
                        case 0:
                          num2 = (short) 58;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 1:
                          num2 = (short) 198;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 2:
                          num2 = (short) 214;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 3:
                          if (!flag1)
                          {
                            num2 = (short) 167;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 350;
                        case 4:
                          codeplug = new RadioParams();
                          codeplug.ModelNumber = this.g();
                          codeplug.SerialNumber = this.f();
                          codeplug.FlashCode = ParseDataHelper.getCodeplugFlashCode();
                          // ISSUE: reference to a compiler-generated field
                          SpecialFeatures.Comms.Comms.a(1.0, AppResources.Open_Port_Complete);
                          List<IshHeader> blockList = new List<IshHeader>();
                          blockList.Add(new IshHeader((byte) 208 /*0xD0*/, (ushort) 1080, (ushort) 0));
                          blockList.Add(new IshHeader((byte) 208 /*0xD0*/, (ushort) 1026, (ushort) 0));
                          blockList.Add(new IshHeader((byte) 208 /*0xD0*/, (ushort) 1076, (ushort) 0));
                          blockList.Add(new IshHeader((byte) 208 /*0xD0*/, (ushort) 3868, ushort.MaxValue));
                          blockList.Add(new IshHeader((byte) 212, (ushort) 901, (ushort) 0));
                          blockList.Add(new IshHeader((byte) 208 /*0xD0*/, (ushort) 1029, (ushort) 0));
                          blockList.Add(new IshHeader((byte) 212, (ushort) 903, (ushort) 0));
                          blockList.Add(new IshHeader((byte) 208 /*0xD0*/, (ushort) 1062, (ushort) 0));
                          blockList.Add(new IshHeader((byte) 208 /*0xD0*/, (ushort) 1093, (ushort) 0));
                          blockList.Add(new IshHeader((byte) 208 /*0xD0*/, (ushort) 1028, (ushort) 0));
                          blockList.Add(new IshHeader((byte) 208 /*0xD0*/, (ushort) 1146, (ushort) 0));
                          blockList.Add(new IshHeader((byte) 208 /*0xD0*/, (ushort) 1084, (ushort) 0));
                          blockList.Add(new IshHeader((byte) 208 /*0xD0*/, (ushort) 3859, ushort.MaxValue));
                          blockList.Add(new IshHeader((byte) 208 /*0xD0*/, (ushort) 3923, ushort.MaxValue));
                          blockList.Add(new IshHeader((byte) 208 /*0xD0*/, (ushort) 1073, (ushort) 0));
                          blockList.Add(new IshHeader((byte) 208 /*0xD0*/, (ushort) 1027, (ushort) 0));
                          blockList.Add(new IshHeader((byte) 208 /*0xD0*/, (ushort) 3852, ushort.MaxValue));
                          blockList.Add(new IshHeader((byte) 208 /*0xD0*/, (ushort) 1137, (ushort) 0));
                          blockList.Add(new IshHeader((byte) 208 /*0xD0*/, (ushort) 1025, (ushort) 0));
                          blockList.Add(new IshHeader((byte) 212, (ushort) 900, (ushort) 0));
                          blockList.Add(new IshHeader((byte) 208 /*0xD0*/, (ushort) 1030, (ushort) 0));
                          blockList.Add(new IshHeader((byte) 208 /*0xD0*/, (ushort) 1150, (ushort) 0));
                          RadioOperationValidator.CheckAndReviseBlockList(blockList);
                          pbaObject1 = this.h.ReadBlock(A_1_2, blockList);
                          num2 = (short) 351;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 5:
                          num2 = (short) 197;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 6:
                          num2 = (short) 53;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 7:
                          string radioCodeplugVersion = AppResources.Codeplug_version_is_older_than_radio_codeplug_version;
                          // ISSUE: reference to a compiler-generated field
                          SpecialFeatures.Comms.Comms.a(0.0, radioCodeplugVersion);
                          flag1 = true;
                          num2 = (short) 373;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 8:
                          num2 = (short) 325;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 9:
                          string stat2 = string.Format(AppResources.PCI_Compatibility_Error_For_Clone_Write_Radio, (object) AppResources.APX6000_P25_Radio);
                          // ISSUE: reference to a compiler-generated field
                          SpecialFeatures.Comms.Comms.a(0.0, stat2);
                          flag1 = true;
                          num2 = (short) 260;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 10:
                          if (PCIGatings.IsUserSelectablePLEnhancementUsed())
                          {
                            num2 = (short) 362;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 282;
                        case 11:
                          string stat3 = string.Format(AppResources.PCI_Compatibility_Error_For_Clone_Write_Radio, (object) AcgResources.ID_UCLCONTACTSLIMITATIONENHANCEMENT);
                          // ISSUE: reference to a compiler-generated field
                          SpecialFeatures.Comms.Comms.a(0.0, stat3);
                          flag1 = true;
                          num2 = (short) 166;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 12:
                          num2 = (short) 281;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 13:
                          string stat4 = string.Format(AppResources.PCI_Compatibility_Error_For_Clone_Write_Radio, (object) AcgResources.ID_ACTIVEMICFORBLUETOOTHPTTCAPABLE);
                          // ISSUE: reference to a compiler-generated field
                          SpecialFeatures.Comms.Comms.a(0.0, stat4);
                          flag1 = true;
                          num2 = (short) 25;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 14:
                          if (!flag1)
                          {
                            num2 = (short) 312;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 324;
                        case 15:
                          num2 = (short) 44;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 16 /*0x10*/:
                          if (!flag1)
                          {
                            num2 = (short) 57;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 373;
                        case 17:
                          if (radioWide2.Labtool.RadWideLabtoolMaritimeRadioSoftware_A42191.Value)
                          {
                            num2 = (short) 15;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 360;
                        case 18:
                          if (!flag1)
                          {
                            num2 = (short) 148;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 309;
                        case 19:
                          if (PCIGatings.IsAllowPSUSecureUsed())
                          {
                            num2 = (short) 107;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 324;
                        case 20:
                          if (radioWide2.Labtool.RadWideLabtoolMaritimeRadioSoftware_A42191 != null)
                          {
                            num2 = (short) 339;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 360;
                        case 21:
                          if (this.b())
                          {
                            num2 = (short) 24;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 123;
                        case 22:
                          if (this.b(pbaObject1))
                          {
                            num2 = (short) 113;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 126;
                        case 23:
                          num2 = (short) 16 /*0x10*/;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 24:
                          num2 = (short) 60;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 25:
                          num2 = (short) 178;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 26:
                          if (PCIGatings.IsBeaconRoutingUsed())
                          {
                            num2 = (short) 170;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 309;
                        case 27:
                          num2 = (short) 91;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 28:
                          List<string> stringList = new List<string>();
                          stringList.Add(RptMgrErrorHandler.b("쎃", A_1_1));
                          stringList.Add(RptMgrErrorHandler.b("첃", A_1_1));
                          stringList.Add(RptMgrErrorHandler.b("캃", A_1_1));
                          stringList.Add(RptMgrErrorHandler.b("쾃", A_1_1));
                          stringList.Add(RptMgrErrorHandler.b("좃", A_1_1));
                          stringList.Add(RptMgrErrorHandler.b("즃", A_1_1));
                          stringList.Add(RptMgrErrorHandler.b("쪃", A_1_1));
                          stringList.Add(RptMgrErrorHandler.b("풃", A_1_1));
                          stringList.Add(RptMgrErrorHandler.b("햃", A_1_1));
                          stringList.Add(RptMgrErrorHandler.b("횃", A_1_1));
                          stringList.Add(RptMgrErrorHandler.b("힃", A_1_1));
                          stringList.Add(RptMgrErrorHandler.b("킃", A_1_1));
                          stringList.Add(RptMgrErrorHandler.b("톃", A_1_1));
                          stringList.Add(RptMgrErrorHandler.b("튃", A_1_1));
                          stringList.Add(RptMgrErrorHandler.b("펃", A_1_1));
                          stringList.Add(RptMgrErrorHandler.b("\uDC83", A_1_1));
                          stringList.Add(RptMgrErrorHandler.b("\uF683", A_1_1));
                          stringList.Add(RptMgrErrorHandler.b("\uF783", A_1_1));
                          stringList.Add(RptMgrErrorHandler.b("\uF083", A_1_1));
                          stringList.Add(RptMgrErrorHandler.b("\uF183", A_1_1));
                          stringList.Add(RptMgrErrorHandler.b("\uF283", A_1_1));
                          stringList.Add(RptMgrErrorHandler.b("\uF383", A_1_1));
                          stringList.Add(RptMgrErrorHandler.b("ﲃ", A_1_1));
                          stringList.Add(RptMgrErrorHandler.b("ﶃ", A_1_1));
                          stringList.Add(RptMgrErrorHandler.b("ﺃ", A_1_1));
                          stringList.Add(RptMgrErrorHandler.b("ꞃ", A_1_1));
                          stringList.Add(RptMgrErrorHandler.b("것", A_1_1));
                          stringList.Add(RptMgrErrorHandler.b("꾃", A_1_1));
                          stringList.Add(RptMgrErrorHandler.b("ꂃ", A_1_1));
                          stringList.Add(RptMgrErrorHandler.b("궃", A_1_1));
                          stringList.Add(RptMgrErrorHandler.b("ꊃ", A_1_1));
                          stringList.Add(RptMgrErrorHandler.b("ꆃ", A_1_1));
                          string str = ParseDataHelper.GetRadioFlashcodeFromFBD(ParseDataHelper.GetFDB(pbaObject1))[7].ToString();
                          string empty = string.Empty;
                          if (!stringList.Contains(str))
                          {
                            num2 = (short) 236;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 23;
                        case 29:
                          ishItemPciCapable27 = ParseDataHelper.GetIshItemPCICapable(pbaObject1, 2, 32 /*0x20*/);
                          num2 = (short) 117;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 30:
                          num2 = (short) 203;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 31 /*0x1F*/:
                          if (!flag1)
                          {
                            num2 = (short) 70;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 222;
                        case 32 /*0x20*/:
                          num2 = (short) 121;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 33:
                          if (!SerialNumberValidator.IsCBISerialNumber(A_1_2.SerialNumber))
                          {
                            num2 = (short) 264;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 85;
                        case 34:
                          if (int16_4 < int16_3)
                          {
                            num2 = (short) 7;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 373;
                        case 35:
                          if (!flag1)
                          {
                            num2 = (short) 143;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 87;
                        case 36:
                          if (flag1)
                          {
                            this.a();
                            num2 = (short) 259;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          break;
                        case 37:
                          string stat5 = string.Format(AppResources.PCI_Compatibility_Error_For_Clone_Write_Radio, (object) AcgResources.ID_CONSOLIDATEDACTIONSENHANCEMENT);
                          // ISSUE: reference to a compiler-generated field
                          SpecialFeatures.Comms.Comms.a(0.0, stat5);
                          flag1 = true;
                          num2 = (short) 270;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 38:
                          if (!flag1)
                          {
                            num2 = (short) 173;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 272;
                        case 39:
                          if (WriteType != COMMS_OP.USB_CLONE)
                          {
                            num2 = (short) 141;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 130;
                        case 40:
                          string stat6 = string.Format(AppResources.PCI_Compatibility_Error_For_Clone_Write_Radio, (object) AcgResources.ID_APXSINGLETONECAPABLE);
                          // ISSUE: reference to a compiler-generated field
                          SpecialFeatures.Comms.Comms.a(0.0, stat6);
                          flag1 = true;
                          num2 = (short) 242;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 41:
                          num2 = (short) 155;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 42:
                          if (!flag1)
                          {
                            num2 = (short) 30;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 138;
                        case 43:
                          num2 = (short) 346;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 44:
                          if (!ishItemPciCapable25)
                          {
                            num2 = (short) 355;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 360;
                        case 45:
                          if (!flag1)
                          {
                            num2 = (short) 158;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 88;
                        case 46:
                          if (WriteType != COMMS_OP.OTAP_CLONE)
                          {
                            num2 = (short) 50;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 82;
                        case 47:
                          if (!RadioAccessValidator.CheckIfCustomerIDIsInACK(this.c()))
                          {
                            num2 = (short) 345;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 99;
                        case 48 /*0x30*/:
                          num2 = (short) 21;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 49:
                          ishItemPciCapable2 = ParseDataHelper.GetIshItemPCICapable(pbaObject1, 5, 128 /*0x80*/);
                          num2 = (short) 207;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 50:
                          num2 = (short) 193;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 51:
                          string stat7 = string.Format(AppResources.PCI_Compatibility_Error_For_Clone_Write_Radio, (object) AcgResources.ID_AUDIBLEEMERGENCYBEACONROUTING);
                          // ISSUE: reference to a compiler-generated field
                          SpecialFeatures.Comms.Comms.a(0.0, stat7);
                          flag1 = true;
                          num2 = (short) 309;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 52:
                          num2 = (short) 46;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 53:
                          if (!ishItemPciCapable2)
                          {
                            num2 = (short) 293;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 115;
                        case 54:
                          string stat8 = string.Format(AppResources.PCI_Compatibility_Error_For_Clone_Write_Radio, (object) AcgResources.ID_AUDIOENHANCEMENT);
                          // ISSUE: reference to a compiler-generated field
                          SpecialFeatures.Comms.Comms.a(0.0, stat8);
                          flag1 = true;
                          num2 = (short) 111;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 55:
                          ishItemPciCapable14 = ParseDataHelper.GetIshItemPCICapable(pbaObject1, 6, 128 /*0x80*/);
                          num2 = (short) 230;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 56:
                          if ((FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation).FrequencyRanges.RadInfoFrequencyRangesExtendedUHFR1480MHzCapable_A43578.Value != flag2)
                          {
                            num2 = (short) 68;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 89;
                        case 57:
                          appVersion = AppInfoManager.AppVersion;
                          num2 = (short) 250;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 58:
                          if (!flag1)
                          {
                            num2 = (short) 164;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 366;
                        case 59:
                          if (!ishItemPciCapable28)
                          {
                            num2 = (short) 161;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 78;
                        case 60:
                          if (RadioOperationValidator.Is800MHzBandEnabledInRadio(A_1_2, pbaObject1))
                          {
                            num2 = (short) 146;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 123;
                        case 61:
                          if (!ishItemPciCapable8)
                          {
                            num2 = (short) 150;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 187;
                        case 62:
                          if (!flag1)
                          {
                            num2 = (short) 84;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 63 /*0x3F*/;
                        case 63 /*0x3F*/:
                          num2 = (short) 96 /*0x60*/;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 64 /*0x40*/:
                          if (PCIGatings.IsActiveMicForPTTUsed())
                          {
                            num2 = (short) 370;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 25;
                        case 65:
                          num2 = (short) 369;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 66:
                          num2 = (short) 59;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 67:
                          string stat9 = string.Format(AppResources.PCI_Compatibility_Error_For_Clone_Write_Radio, (object) AcgResources.ID_EMERGENCYCALLONLYWITHHOTMICCAPABLE);
                          // ISSUE: reference to a compiler-generated field
                          SpecialFeatures.Comms.Comms.a(0.0, stat9);
                          flag1 = true;
                          num2 = (short) 0;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 68:
                          string stat10 = string.Format(AppResources.PCI_Compatibility_Error_For_Clone_Write_Radio, (object) AppResources.Extended_UHFR1480MHz_Capable);
                          // ISSUE: reference to a compiler-generated field
                          SpecialFeatures.Comms.Comms.a(0.0, stat10);
                          flag1 = true;
                          num2 = (short) 89;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 69:
                          if (PCIGatings.IsAPXSingletoneCapableUsed())
                          {
                            num2 = (short) 102;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 242;
                        case 70:
                          ishItemPciCapable33 = ParseDataHelper.GetIshItemPCICapable(pbaObject1, 3, 32 /*0x20*/);
                          num2 = (short) 145;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 71:
                          if (!ishItemPciCapable4)
                          {
                            num2 = (short) 125;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 183;
                        case 72:
                          ishItemPciCapable28 = ParseDataHelper.GetIshItemPCICapable(pbaObject1, 6, 4);
                          num2 = (short) 209;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 73:
                          labtool = FeatureManager.GetFeature(2045)[0][10093] as Labtool;
                          num2 = (short) 79;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 74:
                          num2 = (short) 210;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 75:
                          if (PCIGatings.IsDVRSRangeExtUsed())
                          {
                            num2 = (short) 168;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 286;
                        case 76:
                          ishItemPciCapable5 = ParseDataHelper.GetIshItemPCICapable(pbaObject1, 4, 2);
                          num2 = (short) 64 /*0x40*/;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 77:
                          if (!flag1)
                          {
                            num2 = (short) 349;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 270;
                        case 78:
                          num2 = (short) 300;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 79:
                          if (labtool != null)
                          {
                            num2 = (short) 103;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 290;
                        case 80 /*0x50*/:
                          num2 = (short) 306;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 81:
                          num2 = (short) 172;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 82:
                          stsErrMsg = "";
                          flag1 = !RadioOperationValidator.PerformCompatibilityChecks(pbaObject1, codeplug.ModelNumber, A_1_2.ModelNumber, ref stsErrMsg);
                          num2 = (short) 357;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 83:
                          string stat11 = string.Format(AppResources.PCI_Compatibility_Error_For_Clone_Write_Radio, (object) AppResources.Ultra_Low_Power_Capable);
                          // ISSUE: reference to a compiler-generated field
                          SpecialFeatures.Comms.Comms.a(0.0, stat11);
                          flag1 = true;
                          num2 = (short) 243;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 84:
                          flag1 = !this.a(WriteType, A_1_2.SerialNumber);
                          num2 = (short) 63 /*0x3F*/;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 85:
                          this.a(pbaObject1);
                          num2 = (short) 22;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 86:
                          num2 = (short) 332;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 87:
                          num2 = (short) 171;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 88:
                          num2 = (short) 316;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 89:
                          num2 = (short) 153;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 90:
                          this.m_RadioKilled = ParseDataHelper.IsRadioKilled(pbaObject1);
                          num2 = (short) 321;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 91:
                          if (!flag1)
                          {
                            num2 = (short) 280;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 187;
                        case 92:
                          if (!ishItemPciCapable3)
                          {
                            num2 = (short) 331;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 163;
                        case 93:
                          num2 = (short) 220;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 94:
                        case 154:
                          num2 = (short) 294;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 95:
                          if (WriteType != COMMS_OP.USB_CLONE)
                          {
                            num2 = (short) 8;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 128 /*0x80*/;
                        case 96 /*0x60*/:
                          if (!flag1)
                          {
                            num2 = (short) 268;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 2;
                        case 97:
                          if (WriteType != COMMS_OP.USB_CLONE)
                          {
                            num2 = (short) 52;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 82;
                        case 98:
                        case 157:
                        case 317:
                        case 328:
                          num2 = (short) 116;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 99:
                          num2 = (short) 343;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 100:
                          if (!flag1)
                          {
                            num2 = (short) 372;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 282;
                        case 101:
                          if (PCIGatings.IsMFKEmergencyAccessUsed())
                          {
                            num2 = (short) 41;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 179;
                        case 102:
                          num2 = (short) 235;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 103:
                          num2 = (short) 251;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 104:
                          num2 = (short) 249;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 105:
                          if (PCIGatings.IsEmergencyCallOnlywithHotMicCapableUsed())
                          {
                            num2 = (short) 12;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 0;
                        case 106:
                          if (!flag1)
                          {
                            num2 = (short) 298;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 290;
                        case 107:
                          num2 = (short) 238;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 108:
                          if (PCIGatings.IsIPSCapableUsed())
                          {
                            num2 = (short) 93;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 87;
                        case 109:
                          ishItemPciCapable11 = ParseDataHelper.GetIshItemPCICapable(pbaObject1, 4, 128 /*0x80*/);
                          num2 = (short) 131;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 110:
                          num2 = (short) 269;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 111:
                          num2 = (short) 277;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 112 /*0x70*/:
                          if (!flag1)
                          {
                            num2 = (short) 182;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 260;
                        case 113:
                          stat1 = string.Empty;
                          num2 = (short) 95;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 114:
                          flag2 = ParseDataHelper.GetIshItemPCICapable(pbaObject1, 5, 8) & ParseDataHelper.GetIshItemPCICapable(pbaObject1, 5, 16 /*0x10*/);
                          num2 = (short) 56;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 115:
                          num2 = (short) 313;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 116:
                          if (!flag1)
                          {
                            num2 = (short) 211;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 142;
                        case 117:
                          if (PCIGatings.IsAudibleEmergencyBeaconUsed())
                          {
                            num2 = (short) 86;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 5;
                        case 118:
                          string stat12 = string.Format(AppResources.PCI_Compatibility_Error_For_Clone_Write_Radio, (object) AppResources.Audible_Emergency_Beacon_ID);
                          // ISSUE: reference to a compiler-generated field
                          SpecialFeatures.Comms.Comms.a(0.0, stat12);
                          flag1 = true;
                          num2 = (short) 5;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 119:
                          if (A_1_2.ModelNumber != null)
                          {
                            num2 = (short) 322;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 259;
                        case 120:
                          if (!ishItemPciCapable11)
                          {
                            num2 = (short) 196;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 149;
                        case 121:
                          if (!ishItemPciCapable33)
                          {
                            num2 = (short) 248;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 222;
                        case 122:
                          ishItemPciCapable9 = ParseDataHelper.GetIshItemPCICapable(pbaObject1, 7, 1);
                          num2 = (short) 133;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 123:
                          IshItemCollection programmingHistoryList = ParseDataHelper.GetRadioASKProgrammingHistoryList(pbaObject1);
                          flag1 = !RadioAccessValidator.RadioWriteSecurityCheck(WriteType, radioSecurityData, programmingHistoryList, radioTrkShuffledBandPlans, out stsMsg, WriteProtecWriteProtectedRadio, otapBatchProgramming, updateWriteProtect);
                          num2 = (short) 94;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 124:
                          string stat13 = string.Format(AppResources.PCI_Compatibility_Error_For_Clone_Write_Radio, (object) AcgResources.ID_MANDOWNEMERGENCYPROFILECONFIGURABILITY);
                          // ISSUE: reference to a compiler-generated field
                          SpecialFeatures.Comms.Comms.a(0.0, stat13);
                          flag1 = true;
                          num2 = (short) 152;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 125:
                          string stat14 = string.Format(AppResources.PCI_Compatibility_Error_For_Clone_Write_Radio, (object) AcgResources.ID_ANALOGWIDEBANDDATAPCI);
                          // ISSUE: reference to a compiler-generated field
                          SpecialFeatures.Comms.Comms.a(0.0, stat14);
                          flag1 = true;
                          num2 = (short) 183;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 126:
                          this.m_RadioInhibitedTrunking = ParseDataHelper.IsRadioInhibitedTrunking(pbaObject1);
                          num2 = (short) 227;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case (int) sbyte.MaxValue:
                          string stat15 = string.Format(AppResources.PCI_Compatibility_Error_For_Clone_Write_Radio, (object) AppResources.Expanded_MDC_ID_Capable);
                          // ISSUE: reference to a compiler-generated field
                          SpecialFeatures.Comms.Comms.a(0.0, stat15);
                          flag1 = true;
                          num2 = (short) 27;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 128 /*0x80*/:
                          stat1 = AppResources.Clone_Between_SoldierMAC_FCC_And_RTTE_Cpg;
                          num2 = (short) 347;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 129:
                          if (PCIGatings.IsZoneCloneCapableUsed())
                          {
                            num2 = (short) 327;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 366;
                        case 130:
                          this.m_RadioSystemIds = ParseDataHelper.ReadRadioTrkSystemNamesTypesAndUnitIds(pbaObject1.GetCodeplugInIshItemCollection());
                          this.m_RadioCnvSysIds = ParseDataHelper.ReadConvSysIds(pbaObject1);
                          this.m_AstroOtarRadioIds = ParseDataHelper.ReadAstroOtarRadioIds(pbaObject1);
                          this.m_RadioDataProfIPs = ParseDataHelper.ReadDataProfIPaddr(pbaObject1);
                          this.m_SoftIds = ParseDataHelper.ReadSoftId(pbaObject1);
                          this.m_BluetoothFriendlyName = ParseDataHelper.ReadBluetoothFriendlyName(pbaObject1);
                          this.m_EncryptPassword = ParseDataHelper.ReadEncryptPassword(pbaObject1);
                          num2 = (short) 353;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 131:
                          if (PCIGatings.IsEmergencyCallTerminationCapableUsed())
                          {
                            num2 = (short) 299;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 149;
                        case 132:
                          string stat16 = string.Format(AppResources.PCI_Compatibility_Error_For_Clone_Write_Radio, (object) AcgResources.ID_DISABLEENCRYPTION);
                          // ISSUE: reference to a compiler-generated field
                          SpecialFeatures.Comms.Comms.a(0.0, stat16);
                          flag1 = true;
                          num2 = (short) 138;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 133:
                          if (PCIGatings.IsADPUsedInHighOrMidTierDevice() & ishItemPciCapable9)
                          {
                            num2 = (short) 256 /*0x0100*/;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 23;
                        case 134:
                          num2 = (short) 305;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 135:
                        case 347:
                          // ISSUE: reference to a compiler-generated field
                          SpecialFeatures.Comms.Comms.a(0.0, stat1);
                          flag1 = true;
                          num2 = (short) 126;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 136:
                          ishItemPciCapable3 = ParseDataHelper.GetIshItemPCICapable(pbaObject1, 3, 16 /*0x10*/);
                          num2 = (short) 159;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 137:
                          ishItemPciCapable25 = ParseDataHelper.GetIshItemPCICapable(pbaObject1, 2, 4);
                          radioWide2 = FeatureManager.GetFeature(2045)[0] as Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide;
                          num2 = (short) 229;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 138:
                          num2 = (short) 35;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 139:
                          if (!ishItemPciCapable6)
                          {
                            num2 = (short) 265;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 350;
                        case 140:
                          num2 = (short) 20;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 141:
                          num2 = (short) 320;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 142:
                          num2 = (short) 36;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 143:
                          ishItemPciCapable7 = ParseDataHelper.GetIshItemPCICapable(pbaObject1, 4, 64 /*0x40*/);
                          num2 = (short) 108;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 144 /*0x90*/:
                          if (PCIGatings.IsAnalogWidebandDataPCIRoutingUsed())
                          {
                            num2 = (short) 151;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 183;
                        case 145:
                          if (PCIGatings.IsPersonnelAccountabilityAlertUsed())
                          {
                            num2 = (short) 32 /*0x20*/;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 222;
                        case 146:
                          radioTrkShuffledBandPlans = ParseDataHelper.GetRadioTrkSystemShuffledBandPlans(pbaObject1);
                          num2 = (short) 123;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 147:
                          if (PCIGatings.IsRemoteMountO3Capable())
                          {
                            num2 = (short) 73;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 290;
                        case 148:
                          ishItemPciCapable35 = ParseDataHelper.GetIshItemPCICapable(pbaObject1, 1, 32 /*0x20*/);
                          num2 = (short) 26;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 149:
                          num2 = (short) 283;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 150:
                          string stat17 = string.Format(AppResources.PCI_Compatibility_Error_For_Clone_Write_Radio, (object) AppResources.Disable_Emergency_Call_Indications_Capable);
                          // ISSUE: reference to a compiler-generated field
                          SpecialFeatures.Comms.Comms.a(0.0, stat17);
                          flag1 = true;
                          num2 = (short) 187;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 151:
                          num2 = (short) 71;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 152:
                          num2 = (short) 344;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 153:
                          if (!flag1)
                          {
                            num2 = (short) 208 /*0xD0*/;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 243;
                        case 155:
                          if (!ishItemPciCapable34)
                          {
                            num2 = (short) 190;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 179;
                        case 156:
                          num2 = (short) 315;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 158:
                          ishItemPciCapable12 = ParseDataHelper.GetIshItemPCICapable(pbaObject1, 3, 8);
                          num2 = (short) 285;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 159:
                          if (PCIGatings.IsMOSCADIsUsed())
                          {
                            num2 = (short) 204;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 163;
                        case 160 /*0xA0*/:
                          num2 = (short) 288;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 161:
                          string stat18 = string.Format(AppResources.PCI_Compatibility_Error_For_Clone_Write_Radio, (object) AcgResources.ID_INDIRECTPTTAUDIOROUTINGPCI);
                          // ISSUE: reference to a compiler-generated field
                          SpecialFeatures.Comms.Comms.a(0.0, stat18);
                          flag1 = true;
                          num2 = (short) 78;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 162:
                          string stat19 = string.Format(AppResources.PCI_Compatibility_Error_For_Clone_Write_Radio, (object) AcgResources.ID_USERSELECTABLEPLENHANCEMENT);
                          // ISSUE: reference to a compiler-generated field
                          SpecialFeatures.Comms.Comms.a(0.0, stat19);
                          flag1 = true;
                          num2 = (short) 282;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 163:
                          num2 = (short) 31 /*0x1F*/;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 164:
                          ishItemPciCapable13 = ParseDataHelper.GetIshItemPCICapable(pbaObject1, 4, 32 /*0x20*/);
                          num2 = (short) 129;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 165:
                          if (!ishItemPciCapable35)
                          {
                            num2 = (short) 51;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 309;
                        case 166:
                          num2 = (short) 106;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 167:
                          ishItemPciCapable6 = ParseDataHelper.GetIshItemPCICapable(pbaObject1, 4, 1);
                          num2 = (short) 202;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 168:
                          num2 = (short) 200;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 169:
                          string stat20 = string.Format(AppResources.PCI_Compatibility_Error_For_Clone_Write_Radio, (object) AcgResources.ID_DYNAMICZONESCANCAPABILITY);
                          // ISSUE: reference to a compiler-generated field
                          SpecialFeatures.Comms.Comms.a(0.0, stat20);
                          flag1 = true;
                          num2 = (short) 216;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 170:
                          num2 = (short) 165;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 171:
                          if (!flag1)
                          {
                            num2 = (short) 109;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 149;
                        case 172:
                          if (!ishItemPciCapable14)
                          {
                            num2 = (short) 11;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 166;
                        case 173:
                          ishItemPciCapable19 = ParseDataHelper.GetIshItemPCICapable(pbaObject1, 1, 8);
                          num2 = (short) 174;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 174:
                          if (PCIGatings.IsMulitEmergencyRevertUsed())
                          {
                            num2 = (short) 218;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 272;
                        case 175:
                          if (!ishItemPciCapable36)
                          {
                            num2 = (short) 37;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 270;
                        case 176 /*0xB0*/:
                          ishItemPciCapable30 = ParseDataHelper.GetIshItemPCICapable(pbaObject1, 2, 8);
                          num2 = (short) 223;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 177:
                          string stat21 = string.Format(AppResources.PCI_Compatibility_Error_For_Clone_Write_Radio, (object) AppResources.DVRS_Trunking_Status_ID);
                          // ISSUE: reference to a compiler-generated field
                          SpecialFeatures.Comms.Comms.a(0.0, stat21);
                          flag1 = true;
                          num2 = (short) 88;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 178:
                          if (!flag1)
                          {
                            num2 = (short) 284;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 242;
                        case 179:
                          num2 = (short) 240 /*0xF0*/;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 180:
                          int16_1 = (int) Convert.ToInt16(A_1_2.CodeplugVersion.Substring(1, 2), 10);
                          int16_2 = (int) Convert.ToInt16(appVersion.Substring(1, 2), 10);
                          int16_3 = (int) Convert.ToInt16(A_1_2.CodeplugVersion.Substring(4, 2), 10);
                          int16_4 = (int) Convert.ToInt16(appVersion.Substring(4, 2), 10);
                          num2 = (short) 217;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 181:
                          ishItemPciCapable10 = ParseDataHelper.GetIshItemPCICapable(pbaObject1, 4, 16 /*0x10*/);
                          num2 = (short) 105;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 182:
                          num2 = (short) 310;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 183:
                          num2 = (short) 334;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 184:
                          string stat22 = string.Format(AppResources.PCI_Compatibility_Error_For_Clone_Write_Radio, (object) AppResources.Emergency_Revert_Capable);
                          // ISSUE: reference to a compiler-generated field
                          SpecialFeatures.Comms.Comms.a(0.0, stat22);
                          flag1 = true;
                          num2 = (short) 272;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 185:
                          if (!flag1)
                          {
                            num2 = (short) 296;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 27;
                        case 186:
                          if (!flag1)
                          {
                            num2 = (short) 329;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 111;
                        case 187:
                          num2 = (short) 38;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 188:
                          if (!flag1)
                          {
                            num2 = (short) 114;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 89;
                        case 189:
                          num2 = (short) 195;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 190:
                          string stat23 = string.Format(AppResources.PCI_Compatibility_Error_For_Clone_Write_Radio, (object) AcgResources.ID_MFKEMERGENCYACCESS);
                          // ISSUE: reference to a compiler-generated field
                          SpecialFeatures.Comms.Comms.a(0.0, stat23);
                          flag1 = true;
                          num2 = (short) 179;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 191:
                          if (!ishItemPciCapable1)
                          {
                            num2 = (short) 364;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 239;
                        case 192 /*0xC0*/:
                          num2 = (short) 292;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 193:
                          if (WriteType == COMMS_OP.BLUETOOTH_CLONE)
                          {
                            num2 = (short) 82;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 2;
                        case 194:
                          this.m_CustomerId = ParseDataHelper.ReadCustomerID(pbaObject1);
                          num2 = (short) 47;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 195:
                          if (!radioWide1.Labtool.RadWideLabtoolDisableEncryption_43371.Value)
                          {
                            num2 = (short) 132;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 138;
                        case 196:
                          string stat24 = string.Format(AppResources.PCI_Compatibility_Error_For_Clone_Write_Radio, (object) AcgResources.ID_EMERGENCYCALLTERMINATION);
                          // ISSUE: reference to a compiler-generated field
                          SpecialFeatures.Comms.Comms.a(0.0, stat24);
                          flag1 = true;
                          num2 = (short) 149;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 197:
                          if (!flag1)
                          {
                            num2 = (short) 65;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 311;
                        case 198:
                          if (!flag1)
                          {
                            num2 = (short) 194;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 99;
                        case 199:
                          string stat25 = string.Format(AppResources.PCI_Compatibility_Error_For_Clone_Write_Radio, (object) AcgResources.ID_DVRSRANGEEXT);
                          // ISSUE: reference to a compiler-generated field
                          SpecialFeatures.Comms.Comms.a(0.0, stat25);
                          flag1 = true;
                          num2 = (short) 286;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 200:
                          if (!ishItemPciCapable23)
                          {
                            num2 = (short) 199;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 286;
                        case 201:
                          if ((FeatureManager.GetFeature(2045)[0] as Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide).Labtool.RadWideLabtoolUltraLowPowerSoldierMacCapable_A41710.Value != ishItemPciCapable21)
                          {
                            num2 = (short) 83;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 243;
                        case 202:
                          if (PCIGatings.IsLimitedISSIDVRSOperationCapableUsed())
                          {
                            num2 = (short) 253;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 350;
                        case 203:
                          int num5 = ParseDataHelper.GetIshItemPCICapable(pbaObject1, 5, 1) ? 1 : 0;
                          radioWide1 = FeatureManager.GetFeature(2045)[0] as Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide;
                          if (num5 != 0)
                          {
                            num2 = (short) 189;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 138;
                        case 204:
                          num2 = (short) 92;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 205:
                          this.oldSecurityPartition = pbaObject2.CodeplugData.DataPartitions.Find((Predicate<DataPartition>) (s =>
                          {
                            short num6 = -2930;
                            int num7 = (int) num6;
                            num6 = (short) -2930;
                            int num8 = (int) num6;
                            short num9;
                            switch (num7 == num8)
                            {
                              case true:
                                num9 = (short) 0;
                                if (num9 == (short) 0)
                                  ;
                                num9 = (short) 1;
                                if (num9 == (short) 0)
                                  ;
                                return s.PartitionID == (byte) 212;
                              default:
                                num9 = (short) 0;
                                goto case 1;
                            }
                          }));
                          num2 = (short) 335;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 206:
                          ishItemPciCapable17 = ParseDataHelper.GetIshItemPCICapable(pbaObject1, 3, 1);
                          num2 = (short) 356;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 207:
                          if (PCIGatings.IsRadioLockExtensionCapableUsed())
                          {
                            num2 = (short) 6;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 115;
                        case 208 /*0xD0*/:
                          ishItemPciCapable21 = ParseDataHelper.GetIshItemPCICapable(pbaObject1, 1, 4);
                          num2 = (short) 201;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 209:
                          if (PCIGatings.IsIndirectPTTAudioRoutingUsed())
                          {
                            num2 = (short) 66;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 78;
                        case 210:
                          if (A_1_2 != null)
                          {
                            num2 = (short) 363;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 259;
                        case 211:
                          stsMsg = (string) null;
                          radioSecurityData = ParseDataHelper.GetRadioSecurityData(A_1_2, pbaObject1);
                          num2 = (short) 342;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 212:
                          num4 = ParseDataHelper.ReadProgrammingPathValue(pbaObject1);
                          num2 = (short) 234;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 213:
                          string stat26 = string.Format(AppResources.PCI_Compatibility_Error_For_Clone_Write_Radio, (object) AppResources.Emergency_Hot_Aux_Mic_ID);
                          // ISSUE: reference to a compiler-generated field
                          SpecialFeatures.Comms.Comms.a(0.0, stat26);
                          flag1 = true;
                          num2 = (short) 254;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 214:
                          if (!flag1)
                          {
                            num2 = (short) 212;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 98;
                        case 215:
                          num2 = (short) 175;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 216:
                          num2 = (short) 45;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 217:
                          if (int16_2 >= int16_1)
                          {
                            num2 = (short) 160 /*0xA0*/;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 7;
                        case 218:
                          num2 = (short) 276;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 219:
                          string stat27 = string.Format(AppResources.PCI_Compatibility_Error_For_Clone_Write_Radio, (object) AcgResources.ID_ENHANCEDARS);
                          // ISSUE: reference to a compiler-generated field
                          SpecialFeatures.Comms.Comms.a(0.0, stat27);
                          flag1 = true;
                          num2 = (short) 192 /*0xC0*/;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 220:
                          if (!ishItemPciCapable7)
                          {
                            num2 = (short) 323;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 87;
                        case 221:
                          if (!ishItemPciCapable32)
                          {
                            num2 = (short) 54;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 111;
                        case 222:
                          num2 = (short) 100;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 223:
                          if (PCIGatings.IsEmergencyHotMicUsed())
                          {
                            num2 = (short) 134;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 254;
                        case 224 /*0xE0*/:
                          // ISSUE: reference to a compiler-generated field
                          SpecialFeatures.Comms.Comms.a(0.0, stsErrMsg);
                          num2 = (short) 2;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 225:
                          num2 = (short) 18;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 226:
                          // ISSUE: reference to a compiler-generated field
                          SpecialFeatures.Comms.Comms.a(0.0, stsMsg);
                          num2 = (short) 142;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 227:
                          if (this.e())
                          {
                            num2 = (short) 232;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 90;
                        case 228:
                          ishItemPciCapable34 = ParseDataHelper.GetIshItemPCICapable(pbaObject1, 2, 16 /*0x10*/);
                          num2 = (short) 101;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 229:
                          if (radioWide2 != null)
                          {
                            num2 = (short) 80 /*0x50*/;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 360;
                        case 230:
                          if (PCIGatings.IsUCLContactsLimitationEnhancementUsed())
                          {
                            num2 = (short) 81;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 166;
                        case 231:
                          if (PCIGatings.IsEnhancedARSUsed())
                          {
                            num2 = (short) 245;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 192 /*0xC0*/;
                        case 232:
                          string writtenToIsInhibited = AppResources.The_radio_being_written_to_is_INHIBITED;
                          // ISSUE: reference to a compiler-generated field
                          SpecialFeatures.Comms.Comms.a(0.0, writtenToIsInhibited);
                          flag1 = true;
                          num2 = (short) 90;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 233:
                          if ((FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation).FrequencyRanges.RadInfoFrequencyRangesExtendedUHFR1Capable_A41443.Value)
                          {
                            num2 = (short) 307;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 239;
                        case 234:
                          if (num4 != -1)
                          {
                            num2 = (short) 258;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 98;
                        case 235:
                          if (!ishItemPciCapable15)
                          {
                            num2 = (short) 40;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 242;
                        case 236:
                          string stat28 = string.Format(AppResources.PCI_Compatibility_Error_For_Clone_Write_Radio, (object) AcgResources.ID_ADPCLONINGINCOMPATIBILITY);
                          // ISSUE: reference to a compiler-generated field
                          SpecialFeatures.Comms.Comms.a(0.0, stat28);
                          flag1 = true;
                          num2 = (short) 23;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 237:
                          if (WriteType == COMMS_OP.BLUETOOTH_CLONE)
                          {
                            num2 = (short) 130;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 353;
                        case 238:
                          if (!ishItemPciCapable31)
                          {
                            num2 = (short) 301;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 324;
                        case 239:
                          num2 = (short) 188;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 240 /*0xF0*/:
                          if (!flag1)
                          {
                            num2 = (short) 176 /*0xB0*/;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 254;
                        case 241:
                          if (!ishItemPciCapable24)
                          {
                            num2 = (short) 124;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 152;
                        case 242:
                          num2 = (short) 319;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 243:
                          num2 = (short) 185;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 244:
                          num2 = (short) 365;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 245:
                          num2 = (short) 297;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 246:
                          if (!ishItemPciCapable5)
                          {
                            num2 = (short) 13;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 25;
                        case 247:
                          if (!RadioAccessValidator.IsCpgConvOnly())
                          {
                            num2 = (short) 48 /*0x30*/;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 123;
                        case 248:
                          string stat29 = string.Format(AppResources.PCI_Compatibility_Error_For_Clone_Write_Radio, (object) AcgResources.ID_PERSONNELACCOUNTABILITYALERTCAPABLE);
                          // ISSUE: reference to a compiler-generated field
                          SpecialFeatures.Comms.Comms.a(0.0, stat29);
                          flag1 = true;
                          num2 = (short) 222;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 249:
                          if (!ishItemPciCapable12)
                          {
                            num2 = (short) 177;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 88;
                        case 250:
                          if (appVersion.StartsWith(RptMgrErrorHandler.b("횃", A_1_1)))
                          {
                            num2 = (short) 180;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 373;
                        case 251:
                          if (ishItemPciCapable29 != labtool.RadWideLabtoolSupportO3ControlHeadPCIBit_Value)
                          {
                            num2 = (short) 340;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 290;
                        case 252:
                          ishItemPciCapable22 = ParseDataHelper.GetIshItemPCICapable(pbaObject1, 3, 4);
                          num2 = (short) 308;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 253:
                          num2 = (short) 139;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 254:
                          num2 = (short) 263;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case (int) byte.MaxValue:
                          if (!flag1)
                          {
                            num2 = (short) 76;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 25;
                        case 256 /*0x0100*/:
                          num2 = (short) 28;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 257:
                          if (PCIGatings.IsPassAlarmFilterUsed())
                          {
                            num2 = (short) 110;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 225;
                        case 258:
                          num2 = (short) 8609;
                          int num10 = (int) num2;
                          num2 = (short) 8609;
                          int num11 = (int) num2;
                          switch (num10 == num11 ? 1 : 0)
                          {
                            case 0:
                            case 2:
                              break;
                            default:
                              num2 = (short) 0;
                              if (num2 == (short) 0)
                                ;
                              num2 = (short) 303;
                              num3 = (int) (IntPtr) num2;
                              continue;
                          }
                          break;
                        case 259:
                        case 335:
                        case 359:
                          num2 = (short) 287;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 260:
                          num2 = (short) 336;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 261:
                          if (!flag1)
                          {
                            num2 = (short) 122;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 23;
                        case 262:
                          if (PCIGatings.IsAudioEnhacementUsed())
                          {
                            num2 = (short) 273;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 111;
                        case 263:
                          if (!flag1)
                          {
                            num2 = (short) 29;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 5;
                        case 264:
                          RadioOperationValidator.CompareRadioParams(codeplug, A_1_2, WriteType);
                          num2 = (short) 85;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 265:
                          string stat30 = string.Format(AppResources.PCI_Compatibility_Error_For_Clone_Write_Radio, (object) AcgResources.ID_LIMITEDISSIDVRSOPERATIONCAPABLE);
                          // ISSUE: reference to a compiler-generated field
                          SpecialFeatures.Comms.Comms.a(0.0, stat30);
                          flag1 = true;
                          num2 = (short) 350;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 266:
                          if (PCIGatings.DisableEmergencyCallIndicationsExcised())
                          {
                            num2 = (short) 358;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 187;
                        case 267:
                          string stat31 = string.Format(AppResources.PCI_Compatibility_Error_For_Clone_Write_Radio, (object) AcgResources.ID_PASSALARMFILTERCAPABLE);
                          // ISSUE: reference to a compiler-generated field
                          SpecialFeatures.Comms.Comms.a(0.0, stat31);
                          flag1 = true;
                          num2 = (short) 225;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 268:
                          num2 = (short) 97;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 269:
                          if (!ishItemPciCapable16)
                          {
                            num2 = (short) 267;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 225;
                        case 270:
                          num2 = (short) 3;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 271:
                          if (!(bool) Application.Current.Properties[(object) RptMgrErrorHandler.b("잃\uE985\uE587\uE789\uED8B\uE08D\uF48F\uDE91ﶓ\uF895ﶗ\uD999첛춝", A_1_1)])
                          {
                            this.i = new List<ValidationField>();
                            num2 = (short) 359;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 368;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 272:
                          num2 = (short) 289;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 273:
                          num2 = (short) 221;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 274:
                          string stat32 = string.Format(AppResources.PCI_Compatibility_Error_For_Clone_Write_Radio, (object) AcgResources.ID_ZONECLONECAPABLE);
                          // ISSUE: reference to a compiler-generated field
                          SpecialFeatures.Comms.Comms.a(0.0, stat32);
                          flag1 = true;
                          num2 = (short) 366;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 275:
                          Thread.Sleep(1000);
                          num2 = (short) 4;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 276:
                          if (!ishItemPciCapable19)
                          {
                            num2 = (short) 184;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 272;
                        case 277:
                          if (!flag1)
                          {
                            num2 = (short) 252;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 216;
                        case 278:
                          ishItemPciCapable24 = ParseDataHelper.GetIshItemPCICapable(pbaObject1, 1, 64 /*0x40*/);
                          num2 = (short) 352;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 279:
                          num2 = (short) 241;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 280:
                          ishItemPciCapable8 = ParseDataHelper.GetIshItemPCICapable(pbaObject1, 2, 2);
                          num2 = (short) 266;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 281:
                          if (!ishItemPciCapable10)
                          {
                            num2 = (short) 67;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 0;
                        case 282:
                          num2 = (short) 77;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 283:
                          if (!flag1)
                          {
                            num2 = (short) 49;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 115;
                        case 284:
                          ishItemPciCapable15 = ParseDataHelper.GetIshItemPCICapable(pbaObject1, 4, 4);
                          num2 = (short) 69;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 285:
                          if (PCIGatings.IsDVRSTRKStatusCapabilityUsed())
                          {
                            num2 = (short) 104;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 88;
                        case 286:
                          num2 = (short) 261;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 287:
                          goto label_549;
                        case 288:
                          if (int16_2 == int16_1)
                          {
                            num2 = (short) 318;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 373;
                        case 289:
                          if (!flag1)
                          {
                            num2 = (short) 278;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 152;
                        case 290:
                          num2 = (short) 14;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 291:
                          if (!flag1)
                          {
                            num2 = (short) 137;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 360;
                        case 292:
                          if (!flag1)
                          {
                            num2 = (short) 181;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 0;
                        case 293:
                          string stat33 = string.Format(AppResources.PCI_Compatibility_Error_For_Clone_Write_Radio, (object) AcgResources.ID_RADIOLOCKPASSWORDEXTENSIONCAPABLE);
                          // ISSUE: reference to a compiler-generated field
                          SpecialFeatures.Comms.Comms.a(0.0, stat33);
                          flag1 = true;
                          num2 = (short) 115;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 294:
                          if (flag1)
                          {
                            num2 = (short) 226;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 142;
                        case 295:
                          ishItemPciCapable4 = ParseDataHelper.GetIshItemPCICapable(pbaObject1, 6, 2);
                          num2 = (short) 144 /*0x90*/;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 296:
                          ishItemPciCapable26 = ParseDataHelper.GetIshItemPCICapable(pbaObject1, 1, 16 /*0x10*/);
                          num2 = (short) 302;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 297:
                          if (!ishItemPciCapable18)
                          {
                            num2 = (short) 219;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 192 /*0xC0*/;
                        case 298:
                          ishItemPciCapable29 = ParseDataHelper.GetIshItemPCICapable(pbaObject1, 7, 2);
                          num2 = (short) 147;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 299:
                          num2 = (short) 120;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 300:
                          if (!flag1)
                          {
                            num2 = (short) 295;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 183;
                        case 301:
                          string stat34 = string.Format(AppResources.PCI_Compatibility_Error_For_Clone_Write_Radio, (object) AcgResources.ID_ALLOWPSUSECURE);
                          // ISSUE: reference to a compiler-generated field
                          SpecialFeatures.Comms.Comms.a(0.0, stat34);
                          flag1 = true;
                          num2 = (short) 324;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 302:
                          if (PCIGatings.ExpandedMDC1200Excised())
                          {
                            num2 = (short) 156;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 27;
                        case 303:
                          if (FeatureManager.GetFeature(2045)[0] is Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide radioWide3)
                          {
                            General general = radioWide3.General;
                            if (general != null)
                            {
                              AcpListField programmingPath44845 = general.RadWideGeneralProgrammingPath_44845;
                              if (programmingPath44845 == null)
                              {
                                num2 = (short) 317;
                                num3 = (int) (IntPtr) num2;
                                continue;
                              }
                              ((AcpField<int>) programmingPath44845).SetValue(num4);
                              num2 = (short) 157;
                              num3 = (int) (IntPtr) num2;
                              continue;
                            }
                            num2 = (short) 98;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 328;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 304:
                          if (!ishItemPciCapable13)
                          {
                            num2 = (short) 274;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 366;
                        case 305:
                          if (!ishItemPciCapable30)
                          {
                            num2 = (short) 213;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 254;
                        case 306:
                          if (radioWide2.Labtool != null)
                          {
                            num2 = (short) 140;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 360;
                        case 307:
                          num2 = (short) 191;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 308:
                          if (PCIGatings.IsDynamicZoneScanCapabilityUsed())
                          {
                            num2 = (short) 244;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 216;
                        case 309:
                          num2 = (short) 291;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 310:
                          if (ParseDataHelper.GetIshItemPCICapable(pbaObject1, 2, 1) != (FeatureManager.GetFeature(2045)[0] as Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide).Labtool.RadWideLabtoolAPX6000P25Radio_A42121.Value)
                          {
                            num2 = (short) 9;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 260;
                        case 311:
                          num2 = (short) 186;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 312:
                          ishItemPciCapable31 = ParseDataHelper.GetIshItemPCICapable(pbaObject1, 6, 32 /*0x20*/);
                          num2 = (short) 19;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 313:
                          if (!flag1)
                          {
                            num2 = (short) 72;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 78;
                        case 314:
                          ishItemPciCapable23 = ParseDataHelper.GetIshItemPCICapable(pbaObject1, 6, 64 /*0x40*/);
                          num2 = (short) 75;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 315:
                          if (!ishItemPciCapable26)
                          {
                            num2 = (short) sbyte.MaxValue;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 27;
                        case 316:
                          if (!flag1)
                          {
                            num2 = (short) 136;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 163;
                        case 318:
                          num2 = (short) 34;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 319:
                          if (!flag1)
                          {
                            num2 = (short) 354;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 192 /*0xC0*/;
                        case 320:
                          if (WriteType != COMMS_OP.OTAP_CLONE)
                          {
                            num2 = (short) 330;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 130;
                        case 321:
                          if (this.d())
                          {
                            num2 = (short) 1;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 99;
                        case 322:
                          this.m_EncryptPasswordFlag = ParseDataHelper.ReadEncryptPasswordFlag(pbaObject1);
                          num2 = (short) 39;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 323:
                          string stat35 = string.Format(AppResources.PCI_Compatibility_Error_For_Clone_Write_Radio, (object) AcgResources.ID_INTELLIGENTPRIORITYSCANCAPABLE);
                          // ISSUE: reference to a compiler-generated field
                          SpecialFeatures.Comms.Comms.a(0.0, stat35);
                          flag1 = true;
                          num2 = (short) 87;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 324:
                          num2 = (short) 341;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 325:
                          if (WriteType != COMMS_OP.OTAP_CLONE)
                          {
                            num2 = (short) 43;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 128 /*0x80*/;
                        case 326:
                          ishItemPciCapable16 = ParseDataHelper.GetIshItemPCICapable(pbaObject1, 2, 64 /*0x40*/);
                          num2 = (short) 257;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 327:
                          num2 = (short) 304;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 329:
                          ishItemPciCapable32 = ParseDataHelper.GetIshItemPCICapable(pbaObject1, 3, 2);
                          num2 = (short) 262;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 330:
                          num2 = (short) 237;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 331:
                          string stat36 = string.Format(AppResources.PCI_Compatibility_Error_For_Clone_Write_Radio, (object) AcgResources.ID_MOSCADACE3600CAPABLE);
                          // ISSUE: reference to a compiler-generated field
                          SpecialFeatures.Comms.Comms.a(0.0, stat36);
                          flag1 = true;
                          num2 = (short) 163;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 332:
                          if (!ishItemPciCapable27)
                          {
                            num2 = (short) 118;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 5;
                        case 333:
                          radioTrkShuffledBandPlans = (Collection<TrkSysBandPlan>) null;
                          num2 = (short) 247;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 334:
                          if (!flag1)
                          {
                            num2 = (short) 55;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 166;
                        case 336:
                          if (!flag1)
                          {
                            num2 = (short) 228;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 179;
                        case 337:
                          goto label_283;
                        case 338:
                          switch (0)
                          {
                            case 0:
                              goto label_10;
                            default:
                              continue;
                          }
                        case 339:
                          num2 = (short) 17;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 340:
                          string stat37 = string.Format(AppResources.PCI_Compatibility_Error_For_Clone_Write_Radio, (object) AcgResources.ID_REMOTEMOUNTO3CH);
                          // ISSUE: reference to a compiler-generated field
                          SpecialFeatures.Comms.Comms.a(0.0, stat37);
                          flag1 = true;
                          num2 = (short) 290;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 341:
                          if (!flag1)
                          {
                            num2 = (short) 314;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 286;
                        case 342:
                          if (radioSecurityData == null)
                          {
                            stsMsg = AppResources.Could_not_retrieve_Radio_Securtiry_Information;
                            flag1 = true;
                            num2 = (short) 154;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 333;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 343:
                          if (!flag1)
                          {
                            num2 = (short) 367;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 239;
                        case 344:
                          if (!flag1)
                          {
                            num2 = (short) 326;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 225;
                        case 345:
                          string writtenToIsKilled = AppResources.The_radio_being_written_to_is_KILLED;
                          AppInfoManager.StatusMsgReport.RegisterMessage((StatusMsgType) 2, writtenToIsKilled);
                          // ISSUE: reference to a compiler-generated field
                          SpecialFeatures.Comms.Comms.a(0.0, writtenToIsKilled);
                          flag1 = true;
                          num2 = (short) 99;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 346:
                          if (WriteType != COMMS_OP.BLUETOOTH_CLONE)
                          {
                            stat1 = AppResources.Write_Between_SoldierMAC_FCC_And_RTTE_Cpg;
                            num2 = (short) 135;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 128 /*0x80*/;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 348:
                          if (!ishItemPciCapable20)
                          {
                            num2 = (short) 162;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 282;
                        case 349:
                          ishItemPciCapable36 = ParseDataHelper.GetIshItemPCICapable(pbaObject1, 3, 64 /*0x40*/);
                          num2 = (short) 361;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 350:
                          num2 = (short) byte.MaxValue;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 351:
                          if (pbaObject1 == null)
                          {
                            num2 = (short) 337;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          // ISSUE: reference to a compiler-generated field
                          SpecialFeatures.Comms.Comms.a(0.0, AppResources.Read_Radio_Info);
                          RadioOperationValidator.RadioFlashCodeCheck(pbaObject1, WriteType);
                          num2 = (short) 33;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 352:
                          if (PCIGatings.IsManDownPerCfgCapUsed())
                          {
                            num2 = (short) 279;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 152;
                        case 353:
                          num2 = (short) 271;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 354:
                          ishItemPciCapable18 = ParseDataHelper.GetIshItemPCICapable(pbaObject1, 4, 8);
                          num2 = (short) 231;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 355:
                          string stat38 = string.Format(AppResources.PCI_Compatibility_Error_For_Clone_Write_Radio, (object) AcgResources.ID_MARITIMERADIOSOFTWARE);
                          // ISSUE: reference to a compiler-generated field
                          SpecialFeatures.Comms.Comms.a(0.0, stat38);
                          flag1 = true;
                          num2 = (short) 360;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 356:
                          if ((FeatureManager.GetFeature(2045)[0] as Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide).Labtool.RadWideLabtoolAPXDualKnobs_A42537.Value != ishItemPciCapable17)
                          {
                            num2 = (short) 371;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 311;
                        case 357:
                          if (flag1)
                          {
                            num2 = (short) 224 /*0xE0*/;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 2;
                        case 358:
                          num2 = (short) 61;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 360:
                          num2 = (short) 112 /*0x70*/;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 361:
                          if (PCIGatings.IsConsolidatedActionsEnhancementUsed())
                          {
                            num2 = (short) 215;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 270;
                        case 362:
                          num2 = (short) 348;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 363:
                          num2 = (short) 119;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 364:
                          string stat39 = string.Format(AppResources.PCI_Compatibility_Error_For_Clone_Write_Radio, (object) AppResources.Extended_UHF_R1_Capable);
                          // ISSUE: reference to a compiler-generated field
                          SpecialFeatures.Comms.Comms.a(0.0, stat39);
                          flag1 = true;
                          num2 = (short) 239;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 365:
                          if (!ishItemPciCapable22)
                          {
                            num2 = (short) 169;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 216;
                        case 366:
                          num2 = (short) 42;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 367:
                          ishItemPciCapable1 = ParseDataHelper.GetIshItemPCICapable(pbaObject1, 1, 2);
                          num2 = (short) 233;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 368:
                          this.i = RadioOperationValidator.PopulateWriteValidationFields(pbaObject1);
                          this.SetCodeplugVersions(A_1_2);
                          (FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation).FLASHport.RadInfoFLASHportFLASHcode_A8132.SetValue(ParseDataHelper.GetRadioFlashcodeFromFBD(ParseDataHelper.GetFDB(pbaObject1)));
                          pbaObject2 = this.h.Read((RadioParams) null, (ProgressChangedEventHandler) null);
                          num2 = (short) 205;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 369:
                          if (!UtilityMack.IsAPX900Radio)
                          {
                            num2 = (short) 206;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 311;
                        case 370:
                          num2 = (short) 246;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 371:
                          string stat40 = string.Format(AppResources.PCI_Compatibility_Error_For_Clone_Write_Radio, (object) AppResources.WWP_2_Knobs_Capable);
                          // ISSUE: reference to a compiler-generated field
                          SpecialFeatures.Comms.Comms.a(0.0, stat40);
                          flag1 = true;
                          num2 = (short) 311;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 372:
                          ishItemPciCapable20 = ParseDataHelper.GetIshItemPCICapable(pbaObject1, 3, 128 /*0x80*/);
                          num2 = (short) 10;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 373:
                          num2 = (short) 62;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        default:
label_10:
                          if (WriteType == COMMS_OP.OTAP_CLONE)
                          {
                            num2 = (short) 275;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 4;
                      }
                      num2 = (short) 74;
                      num3 = (int) (IntPtr) num2;
                    }
label_283:
                    throw new Exception(AppResources.Read_block_failed);
                  }
                  catch (CommonException ex)
                  {
                    // ISSUE: reference to a compiler-generated field
                    SpecialFeatures.Comms.Comms.a(0.0, ((Exception) ex).Message);
                    Logger.Log(RptMgrErrorHandler.b("\uDF83", A_1_1) + DateTime.Now.ToString() + RptMgrErrorHandler.b("ꒃꮅꢇ", A_1_1) + ((Exception) ex).Message + RptMgrErrorHandler.b("\uD983", A_1_1));
                    flag1 = true;
                    this.a();
                    goto case 0;
                  }
                  catch (Exception ex)
                  {
                    // ISSUE: reference to a compiler-generated field
                    SpecialFeatures.Comms.Comms.a(0.0, ex.Message);
                    Exception innerException = ex.InnerException;
                    flag1 = true;
                    this.a();
                    goto case 0;
                  }
                case 3:
                  if (this.a(WriteType, ref A_1_2, false, (RadioOperation) 4L, Headless, HeadlessAddr))
                  {
                    num2 = (short) 1;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  flag1 = true;
                  num2 = (short) 0;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 4:
                  num2 = (short) 1;
                  if (num2 == (short) 0)
                    ;
                  // ISSUE: reference to a compiler-generated field
                  SpecialFeatures.Comms.Comms.a(1.0, AppResources.Read_Radio_Info_Complete);
                  num2 = (short) 5;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 5:
                  goto label_547;
                case 6:
                  if (!flag1)
                  {
                    num2 = (short) 4;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_553;
                default:
                  goto label_3;
              }
            }
label_547:
            num2 = (short) 0;
label_553:
            return flag1;
        }
    }
  }

  private bool b(PbaObject A_0)
  {
label_0:
    short num1;
    int num2;
    Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide radioWide;
    switch (0)
    {
      case 0:
label_2:
        radioWide = FeatureManager.GetFeature(2045)[0] as Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide;
        num1 = (short) -19362;
        int num3 = (int) num1;
        num1 = (short) -19362;
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
            num1 = (short) 3;
            num2 = (int) (IntPtr) num1;
            goto label_1;
        }
      default:
        while (true)
        {
          num1 = (short) 0;
          switch (num2)
          {
            case 0:
              goto label_9;
            case 1:
              if (ParseDataHelper.ReadTxPowerLevelsCFGType(A_0) != ((AcpField<int>) radioWide.TransmitPowerLevels.RadWideTransmitPowerLevelsTxPowerLevelConfigType_A41179).Value)
              {
                num1 = (short) 0;
                num2 = (int) (IntPtr) num1;
                continue;
              }
              goto label_8;
            case 2:
              num1 = (short) 1;
              if (num1 == (short) 0)
                ;
              num1 = (short) 1;
              num2 = (int) (IntPtr) num1;
              continue;
            case 3:
              if (((AcpField<int>) (FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation).Labtool.RadInfoLabtoolProductModelIdentifier_A37178).Value == 8)
              {
                num1 = (short) 2;
                num2 = (int) (IntPtr) num1;
                continue;
              }
              goto label_13;
            default:
              goto label_2;
          }
label_1:;
        }
label_8:
        return false;
label_9:
        return true;
label_13:
        return false;
    }
  }

  private string g()
  {
    short num1 = 0;
    if (!(FeatureManager.GetFeature(2049)[0] is Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation radioInformation))
      goto label_2;
label_1:
    return radioInformation.General.RadInfoGeneralModelNumber_A8539.ToString();
label_2:
    num1 = (short) 14002;
    int num2 = (int) num1;
    num1 = (short) 14002;
    int num3 = (int) num1;
    switch (num2 == num3 ? 1 : 0)
    {
      case 0:
      case 2:
        goto label_1;
      default:
        num1 = (short) 1;
        if (num1 == (short) 0)
          ;
        num1 = (short) 0;
        if (num1 == (short) 0)
          ;
        return string.Empty;
    }
  }

  private string f()
  {
    short num1 = -26475;
    int num2 = (int) num1;
    num1 = (short) -26475;
    int num3 = (int) num1;
    short num4;
    string str;
    switch (num2 == num3 ? 1 : 0)
    {
      case 0:
      case 2:
label_8:
        num4 = (short) 1;
        if (num4 == (short) 0)
          ;
        return str;
      default:
        num4 = (short) 0;
        if (num4 == (short) 0)
          ;
        int num5;
        Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation radioInformation;
        switch (0)
        {
          case 0:
label_4:
            str = "";
            radioInformation = FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation;
            num4 = (short) 2;
            num5 = (int) (IntPtr) num4;
            goto default;
          default:
            while (true)
            {
              switch (num5)
              {
                case 0:
                  goto label_8;
                case 1:
                  num4 = (short) 0;
                  str = Convert.ToBase64String(Encoding.ASCII.GetBytes(radioInformation.General.RadInfoGeneralSerialNumber_A9122.ToString()));
                  num4 = (short) 0;
                  num5 = (int) (IntPtr) num4;
                  continue;
                case 2:
                  if (radioInformation != null)
                  {
                    num4 = (short) 1;
                    num5 = (int) (IntPtr) num4;
                    continue;
                  }
                  goto label_8;
                default:
                  goto label_4;
              }
            }
        }
    }
  }

  private bool e()
  {
    int A_1 = 6;
    short num1 = -9423;
    int num2 = (int) num1;
    num1 = (short) -9423;
    int num3 = (int) num1;
    bool flag;
    switch (num2 == num3 ? 1 : 0)
    {
      case 0:
      case 2:
label_9:
        return flag;
      default:
        if (true)
          ;
        int num4;
        short num5;
        switch (0)
        {
          case 0:
label_4:
            flag = false;
            num5 = (short) 1;
            if (num5 == (short) 0)
              ;
            num5 = (short) 2;
            num4 = (int) (IntPtr) num5;
            goto default;
          default:
            while (true)
            {
              switch (num4)
              {
                case 0:
                  goto label_9;
                case 1:
                  this.m_RadioInhibitedTrunking.TryGetValue(RptMgrErrorHandler.b("\uD988\uEA8Aﾌﮎ\uF890\uE792ﲔ\uF896\uF798Ꚛ꾜꾞馠辢薤\uF3A6킨\uDBAA좬銮肰莲螴膶閸鮺\uF4BC﮾ﳀ\uF3C2\uE9C4\uE7C6胈ꗊ꧌\uAACE꧐\uEED2\uE7D4\uE7D6", A_1), out flag);
                  num5 = (short) 0;
                  num4 = (int) (IntPtr) num5;
                  continue;
                case 2:
                  if (this.m_RadioInhibitedTrunking != null)
                  {
                    num5 = (short) 0;
                    num5 = (short) 1;
                    num4 = (int) (IntPtr) num5;
                    continue;
                  }
                  goto label_9;
                default:
                  goto label_4;
              }
            }
        }
    }
  }

  private bool d()
  {
    int A_1 = 5;
    short num1 = 28975;
    int num2 = (int) num1;
    num1 = (short) 28975;
    int num3 = (int) num1;
    bool flag;
    switch (num2 == num3 ? 1 : 0)
    {
      case 0:
      case 2:
label_9:
        return flag;
      default:
        short num4 = 0;
        if (num4 == (short) 0)
          ;
        int num5;
        switch (0)
        {
          case 0:
label_4:
            flag = false;
            num4 = (short) 2;
            num5 = (int) (IntPtr) num4;
            goto default;
          default:
            while (true)
            {
              switch (num5)
              {
                case 0:
                  goto label_9;
                case 1:
                  num4 = (short) 0;
                  num4 = (short) 1;
                  if (num4 == (short) 0)
                    ;
                  this.m_RadioKilled.TryGetValue(RptMgrErrorHandler.b("\uD887\uEB89ﺋ揄憐\uE691ﶓ秊\uF697ꞙ꺛꺝颟躡蒣\uF2A5톧\uDAA9즫鎭膯花蚳肵钷骹\uF5BB諾ﶿ\uF2C1\uE8C3\uE6C5臇\uA4C9\uA8CBꯍ꣏\uEFD1\uE5D3\uEED5", A_1), out flag);
                  num4 = (short) 0;
                  num5 = (int) (IntPtr) num4;
                  continue;
                case 2:
                  if (this.m_RadioKilled != null)
                  {
                    num4 = (short) 1;
                    num5 = (int) (IntPtr) num4;
                    continue;
                  }
                  goto label_9;
                default:
                  goto label_4;
              }
            }
        }
    }
  }

  private int c()
  {
    int A_1 = 3;
    short num1 = 1;
    if (num1 == (short) 0)
      ;
    num1 = (short) 14201;
    int num2 = (int) num1;
    num1 = (short) 14201;
    int num3 = (int) num1;
    int num4;
    switch (num2 == num3 ? 1 : 0)
    {
      case 0:
      case 2:
label_9:
        return num4;
      default:
        num1 = (short) 0;
        if (num1 == (short) 0)
          ;
        int num5;
        switch (0)
        {
          case 0:
label_5:
            num4 = 0;
            num1 = (short) 2;
            num5 = (int) (IntPtr) num1;
            goto default;
          default:
            while (true)
            {
              switch (num5)
              {
                case 0:
                  goto label_9;
                case 1:
                  this.m_CustomerId.TryGetValue(RptMgrErrorHandler.b("횅\uE987\uF889\uF88B\uE78D\uE48Fﮑﮓ\uF895ꖗꢙ겛ꚝ貟芡\uF0A3\uDFA5\uD8A7쾩醫龭肯膱蒳骵颷\uF3B9\uF8BB莽\uF0BF\uEEC1\uE4C3迅ꛇ껉꧋뛍\uEDCF\uE3D1\uE7D3", A_1), out num4);
                  num1 = (short) 0;
                  num5 = (int) (IntPtr) num1;
                  continue;
                case 2:
                  if (this.m_RadioInhibitedTrunking != null)
                  {
                    num1 = (short) 0;
                    num1 = (short) 1;
                    num5 = (int) (IntPtr) num1;
                    continue;
                  }
                  goto label_9;
                default:
                  goto label_5;
              }
            }
        }
    }
  }

  private bool a(
    COMMS_OP A_0,
    ref RadioParams A_1,
    bool A_2,
    RadioOperation A_3 = 4,
    int A_4 = 0,
    string A_5 = "0.0.0.0")
  {
    int A_1_1 = 15;
    short num1 = 0;
    num1 = (short) -380;
    int num2 = (int) num1;
    num1 = (short) -380;
    int num3 = (int) num1;
    bool flag1;
    switch (num2 == num3 ? 1 : 0)
    {
      case 0:
      case 2:
label_123:
        return flag1;
      default:
        num1 = (short) 1;
        if (num1 == (short) 0)
          ;
        num1 = (short) 0;
        if (num1 == (short) 0)
          ;
        num1 = (short) 0;
        switch (num1)
        {
          default:
            bool flag2 = false;
            bool? nullable1 = new bool?();
            // ISSUE: object of a compiler-generated type is created
            // ISSUE: variable of a compiler-generated type
            SpecialFeaturesSettings featuresSettings = new SpecialFeaturesSettings();
            Semaphore semaphore = (Semaphore) null;
            try
            {
              num1 = (short) 38;
              int num4 = (int) (IntPtr) num1;
              while (true)
              {
                OTAPPrescenceResult otapPrescenceResult;
                ProgrammingOperation ProgOp;
                bool? nullable2;
                DateTime now;
                switch (num4)
                {
                  case 0:
                    otapPrescenceResult = (OTAPPrescenceResult) null;
                    num1 = (short) 27;
                    num4 = (int) (IntPtr) num1;
                    continue;
                  case 1:
                    if (flag2)
                    {
                      num1 = (short) 6;
                      num4 = (int) (IntPtr) num1;
                      continue;
                    }
                    goto case 14;
                  case 2:
                    if (string.IsNullOrEmpty(A_1.ConnectionInfo.UniqueAddress))
                    {
                      num1 = (short) 8;
                      num4 = (int) (IntPtr) num1;
                      continue;
                    }
                    goto case 14;
                  case 3:
                  case 7:
                    // ISSUE: reference to a compiler-generated field
                    SpecialFeatures.Comms.Comms.c(ProgOp, this.d, new SpecialFeatures.Comms.Comms.RadioOTAPObject(this.OTAPRadioResult));
                    num1 = (short) 5;
                    num4 = (int) (IntPtr) num1;
                    continue;
                  case 4:
                    try
                    {
                      switch (0)
                      {
                        case 0:
label_65:
                          RadioParams A_0_1 = new RadioParams()
                          {
                            Family = (ProductFamily) 1,
                            ConnectionInfo = new ConnectionInfo()
                          };
                          A_0_1.ConnectionInfo.ConnectionType = (ConnectionType) 32 /*0x20*/;
                          A_0_1.ConnectionInfo.UniqueAddress = this.GetBluetoothPANIPAddress(A_0);
                          this.h = this.a(A_0_1, A_3);
                          A_1 = this.h.ReadExtendedDeviceInfo();
                          num1 = (short) 1;
                          num4 = (int) (IntPtr) num1;
                          goto default;
                        default:
                          while (true)
                          {
                            switch (num4)
                            {
                              case 0:
                                flag2 = true;
                                num1 = (short) 2;
                                num4 = (int) (IntPtr) num1;
                                continue;
                              case 1:
                                if (A_1 != null)
                                {
                                  num1 = (short) 0;
                                  num4 = (int) (IntPtr) num1;
                                  continue;
                                }
                                goto case 2;
                              case 2:
                                num1 = (short) 3;
                                num4 = (int) (IntPtr) num1;
                                continue;
                              case 3:
                                goto label_112;
                              default:
                                goto label_65;
                            }
                          }
                      }
                    }
                    catch (CommonException ex)
                    {
                      flag2 = false;
                      // ISSUE: reference to a compiler-generated field
                      SpecialFeatures.Comms.Comms.a(0.0, ((Exception) ex).Message);
                      Logger.Log(RptMgrErrorHandler.b("즑", A_1_1) + DateTime.Now.ToString() + RptMgrErrorHandler.b("늑릓뚕", A_1_1) + ((Exception) ex).Message + RptMgrErrorHandler.b("쾑", A_1_1));
                      this.a();
                      goto case 14;
                    }
                    catch (Exception ex)
                    {
                      string[] strArray = new string[5]
                      {
                        RptMgrErrorHandler.b("즑", A_1_1),
                        null,
                        null,
                        null,
                        null
                      };
                      now = DateTime.Now;
                      strArray[1] = now.ToString();
                      strArray[2] = RptMgrErrorHandler.b("늑릓뚕", A_1_1);
                      strArray[3] = ex.Message;
                      strArray[4] = RptMgrErrorHandler.b("쾑", A_1_1);
                      Logger.Log(string.Concat(strArray));
                      // ISSUE: reference to a compiler-generated field
                      SpecialFeatures.Comms.Comms.a(0.0, ex.Message);
                      Exception innerException = ex.InnerException;
                      flag2 = false;
                      this.a();
                      goto case 14;
                    }
                  case 5:
                    if (!(bool) Application.Current.Properties[(object) RptMgrErrorHandler.b("톑ﮓﮕ\uF597ﮙ\uF29B瞧\uEC9F쮡쪣쎥\uEBA7睊ﾫ", A_1_1)])
                    {
                      num1 = (short) 39;
                      num4 = (int) (IntPtr) num1;
                      continue;
                    }
                    goto case 47;
                  case 6:
                    num1 = (short) 2;
                    num4 = (int) (IntPtr) num1;
                    continue;
                  case 8:
                    flag2 = false;
                    // ISSUE: reference to a compiler-generated field
                    SpecialFeatures.Comms.Comms.a(0.0, AppResources.Could_not_find_a_radio_connected_to_a_USB_port);
                    num1 = (short) 14;
                    num4 = (int) (IntPtr) num1;
                    continue;
                  case 9:
                    if (otapPrescenceResult.DevicePrescence != OTAP_SUBSCRIBER_NETWORK_PRESCENCE.OTAP_RADIO_STATUS_PRESENT)
                    {
                      num1 = (short) 16 /*0x10*/;
                      num4 = (int) (IntPtr) num1;
                      continue;
                    }
                    goto case 24;
                  case 10:
                    if (A_4 == 8)
                    {
                      num1 = (short) 51;
                      num4 = (int) (IntPtr) num1;
                      continue;
                    }
                    goto case 14;
                  case 11:
                    if (nullable2.GetValueOrDefault() == flag1 & nullable2.HasValue)
                    {
                      num1 = (short) 46;
                      num4 = (int) (IntPtr) num1;
                      continue;
                    }
                    break;
                  case 12:
                    if (A_0 == COMMS_OP.OTAP_CLONE)
                    {
                      num1 = (short) 0;
                      num4 = (int) (IntPtr) num1;
                      continue;
                    }
                    goto label_105;
                  case 13:
                    num1 = (short) 48 /*0x30*/;
                    num4 = (int) (IntPtr) num1;
                    continue;
                  case 14:
                  case 26:
                  case 34:
                  case 43:
                  case 44:
label_112:
                    flag1 = flag2;
                    num1 = (short) 52;
                    num4 = (int) (IntPtr) num1;
                    continue;
                  case 15:
                    try
                    {
                      switch (0)
                      {
                        case 0:
label_89:
                          RadioParams A_0_2 = new RadioParams()
                          {
                            Family = (ProductFamily) 1,
                            ConnectionInfo = new ConnectionInfo()
                          };
                          A_0_2.ConnectionInfo.ConnectionType = (ConnectionType) 4;
                          this.h = this.a(A_0_2, A_3);
                          A_1 = this.h.ReadExtendedDeviceInfo();
                          num1 = (short) 1;
                          num4 = (int) (IntPtr) num1;
                          goto default;
                        default:
                          while (true)
                          {
                            switch (num4)
                            {
                              case 0:
                                flag2 = true;
                                num1 = (short) 2;
                                num4 = (int) (IntPtr) num1;
                                continue;
                              case 1:
                                if (A_1 != null)
                                {
                                  num1 = (short) 0;
                                  num4 = (int) (IntPtr) num1;
                                  continue;
                                }
                                goto case 2;
                              case 2:
                                num1 = (short) 3;
                                num4 = (int) (IntPtr) num1;
                                continue;
                              case 3:
                                goto label_13;
                              default:
                                goto label_89;
                            }
                          }
                      }
                    }
                    catch (CommonException ex)
                    {
                      flag2 = false;
                      // ISSUE: reference to a compiler-generated field
                      SpecialFeatures.Comms.Comms.a(0.0, ((Exception) ex).Message);
                      Logger.Log(RptMgrErrorHandler.b("즑", A_1_1) + DateTime.Now.ToString() + RptMgrErrorHandler.b("늑릓뚕", A_1_1) + ((Exception) ex).Message + RptMgrErrorHandler.b("쾑", A_1_1));
                      this.a();
                    }
                    catch (Exception ex)
                    {
                      string[] strArray = new string[5]
                      {
                        RptMgrErrorHandler.b("즑", A_1_1),
                        null,
                        null,
                        null,
                        null
                      };
                      now = DateTime.Now;
                      strArray[1] = now.ToString();
                      strArray[2] = RptMgrErrorHandler.b("늑릓뚕", A_1_1);
                      strArray[3] = ex.Message;
                      strArray[4] = RptMgrErrorHandler.b("쾑", A_1_1);
                      Logger.Log(string.Concat(strArray));
                      // ISSUE: reference to a compiler-generated field
                      SpecialFeatures.Comms.Comms.a(0.0, ex.Message);
                      Exception innerException = ex.InnerException;
                      flag2 = false;
                      this.a();
                    }
label_13:
                    num1 = (short) 1;
                    num4 = (int) (IntPtr) num1;
                    continue;
                  case 16 /*0x10*/:
                    num1 = (short) 40;
                    num4 = (int) (IntPtr) num1;
                    continue;
                  case 17:
                    if (nullable1.HasValue)
                    {
                      num1 = (short) 19;
                      num4 = (int) (IntPtr) num1;
                      continue;
                    }
                    break;
                  case 18:
                    if (A_0 != COMMS_OP.BLUETOOTH_CLONE)
                    {
                      num1 = (short) 31 /*0x1F*/;
                      num4 = (int) (IntPtr) num1;
                      continue;
                    }
                    goto case 29;
                  case 19:
                    nullable2 = nullable1;
                    flag1 = true;
                    num1 = (short) 11;
                    num4 = (int) (IntPtr) num1;
                    continue;
                  case 20:
                    // ISSUE: reference to a compiler-generated field
                    SpecialFeatures.Comms.Comms.a(0.0, AppResources.The_application_could_not_communicate_with_the_Automatic_Registration_Server_ARS);
                    flag2 = false;
                    num1 = (short) 44;
                    num4 = (int) (IntPtr) num1;
                    continue;
                  case 21:
                    if (A_0 != COMMS_OP.OTAP_READ_WRITE)
                    {
                      num1 = (short) 49;
                      num4 = (int) (IntPtr) num1;
                      continue;
                    }
                    goto case 0;
                  case 22:
                    // ISSUE: reference to a compiler-generated field
                    SpecialFeatures.Comms.Comms.a(0.0, AppResources.The_radio_is_not_on_the_network);
                    flag2 = false;
                    num1 = (short) 34;
                    num4 = (int) (IntPtr) num1;
                    continue;
                  case 23:
                    if (otapPrescenceResult.DevicePrescence == OTAP_SUBSCRIBER_NETWORK_PRESCENCE.OTAP_RADIO_STATUS_TIMEOUT)
                    {
                      num1 = (short) 20;
                      num4 = (int) (IntPtr) num1;
                      continue;
                    }
                    string[] strArray1 = new string[5]
                    {
                      RptMgrErrorHandler.b("즑", A_1_1),
                      null,
                      null,
                      null,
                      null
                    };
                    now = DateTime.Now;
                    strArray1[1] = now.ToString();
                    strArray1[2] = RptMgrErrorHandler.b("늑릓뚕", A_1_1);
                    strArray1[3] = AppResources.The_radio_network_address_could_not_be_determined;
                    strArray1[4] = RptMgrErrorHandler.b("쾑", A_1_1);
                    Logger.Log(string.Concat(strArray1));
                    // ISSUE: reference to a compiler-generated field
                    SpecialFeatures.Comms.Comms.a(0.0, AppResources.The_radio_network_address_could_not_be_determined);
                    flag2 = false;
                    num1 = (short) 43;
                    num4 = (int) (IntPtr) num1;
                    continue;
                  case 24:
                    num1 = (short) 35;
                    num4 = (int) (IntPtr) num1;
                    continue;
                  case 25:
                    try
                    {
                      RadioParams A_0_3 = new RadioParams()
                      {
                        Family = (ProductFamily) 1,
                        ConnectionInfo = new ConnectionInfo()
                      };
                      A_0_3.ConnectionInfo.UniqueAddress = A_5;
                      A_0_3.ConnectionInfo.ConnectionType = (ConnectionType) 16 /*0x10*/;
                      this.h = this.a(A_0_3, A_3);
                      A_1 = this.h.ReadExtendedDeviceInfo();
                      flag2 = true;
                      goto case 14;
                    }
                    catch (CommonException ex)
                    {
                      flag2 = false;
                      // ISSUE: reference to a compiler-generated field
                      SpecialFeatures.Comms.Comms.a(0.0, ((Exception) ex).Message);
                      Logger.Log(RptMgrErrorHandler.b("즑", A_1_1) + DateTime.Now.ToString() + RptMgrErrorHandler.b("늑릓뚕", A_1_1) + ((Exception) ex).Message + RptMgrErrorHandler.b("쾑", A_1_1));
                      this.a();
                      goto case 14;
                    }
                    catch (Exception ex)
                    {
                      flag2 = false;
                      // ISSUE: reference to a compiler-generated field
                      SpecialFeatures.Comms.Comms.a(0.0, AppResources.The_radio_network_address_could_not_be_determined);
                      this.a();
                      goto case 14;
                    }
                  case 27:
                    if (A_2)
                    {
                      num1 = (short) 30;
                      num4 = (int) (IntPtr) num1;
                      continue;
                    }
                    ProgOp = ProgrammingOperation.PROGRAMMING_OPERATION_WRITE;
                    num1 = (short) 7;
                    num4 = (int) (IntPtr) num1;
                    continue;
                  case 28:
                    if (A_0 == COMMS_OP.BLUETOOTH_READ_WRITE)
                    {
                      num1 = (short) 29;
                      num4 = (int) (IntPtr) num1;
                      continue;
                    }
                    num1 = (short) 10;
                    num4 = (int) (IntPtr) num1;
                    continue;
                  case 29:
                    num1 = (short) 4;
                    num4 = (int) (IntPtr) num1;
                    continue;
                  case 30:
                    ProgOp = ProgrammingOperation.PROGRAMMING_OPERATION_READ;
                    num1 = (short) 3;
                    num4 = (int) (IntPtr) num1;
                    continue;
                  case 31 /*0x1F*/:
                    num1 = (short) 28;
                    num4 = (int) (IntPtr) num1;
                    continue;
                  case 32 /*0x20*/:
                    num1 = (short) 15;
                    num4 = (int) (IntPtr) num1;
                    continue;
                  case 33:
                    num1 = (short) 42;
                    num4 = (int) (IntPtr) num1;
                    continue;
                  case 35:
                    try
                    {
                      int num5;
                      switch (0)
                      {
                        case 0:
label_74:
                          num5 = (int) Convert.ToInt16(featuresSettings.OTAP_CPS_SESSION_INACTIVITY_TIMER);
                          num1 = (short) 3;
                          num4 = (int) (IntPtr) num1;
                          goto default;
                        default:
                          while (true)
                          {
                            switch (num4)
                            {
                              case 0:
                                num1 = (short) 2;
                                num4 = (int) (IntPtr) num1;
                                continue;
                              case 1:
                                RadioParams A_0_4 = new RadioParams()
                                {
                                  Family = (ProductFamily) 1,
                                  ConnectionInfo = new ConnectionInfo()
                                };
                                A_0_4.ConnectionInfo.UniqueAddress = otapPrescenceResult.DeviceIPAddress;
                                A_0_4.ConnectionInfo.ConnectionType = (ConnectionType) 16 /*0x10*/;
                                A_0_4.ConnectionInfo.InactivityTimeout = num5 * 60;
                                this.h = this.a(A_0_4, A_3);
                                A_1 = this.h.ReadExtendedDeviceInfo();
                                A_1.ConnectionInfo.InactivityTimeout = num5 * 60;
                                flag2 = true;
                                num1 = (short) 5;
                                num4 = (int) (IntPtr) num1;
                                continue;
                              case 2:
                                if (num5 < 1)
                                {
                                  num1 = (short) 4;
                                  num4 = (int) (IntPtr) num1;
                                  continue;
                                }
                                goto case 1;
                              case 3:
                                if (num5 <= 4)
                                {
                                  num1 = (short) 0;
                                  num4 = (int) (IntPtr) num1;
                                  continue;
                                }
                                goto case 4;
                              case 4:
                                num5 = 3;
                                featuresSettings.OTAP_CPS_SESSION_INACTIVITY_TIMER = num5.ToString();
                                featuresSettings.Save();
                                num1 = (short) 1;
                                num4 = (int) (IntPtr) num1;
                                continue;
                              case 5:
                                goto label_112;
                              default:
                                goto label_74;
                            }
                          }
                      }
                    }
                    catch (CommonException ex)
                    {
                      flag2 = false;
                      // ISSUE: reference to a compiler-generated field
                      SpecialFeatures.Comms.Comms.a(0.0, ((Exception) ex).Message);
                      Logger.Log(RptMgrErrorHandler.b("즑", A_1_1) + DateTime.Now.ToString() + RptMgrErrorHandler.b("늑릓뚕", A_1_1) + ((Exception) ex).Message + RptMgrErrorHandler.b("쾑", A_1_1));
                      this.a();
                      goto case 14;
                    }
                    catch (Exception ex)
                    {
                      string[] strArray2 = new string[5]
                      {
                        RptMgrErrorHandler.b("즑", A_1_1),
                        null,
                        null,
                        null,
                        null
                      };
                      now = DateTime.Now;
                      strArray2[1] = now.ToString();
                      strArray2[2] = RptMgrErrorHandler.b("늑릓뚕", A_1_1);
                      strArray2[3] = ex.Message;
                      strArray2[4] = RptMgrErrorHandler.b("쾑", A_1_1);
                      Logger.Log(string.Concat(strArray2));
                      flag2 = false;
                      // ISSUE: reference to a compiler-generated field
                      SpecialFeatures.Comms.Comms.a(0.0, AppResources.The_radio_network_address_could_not_be_determined);
                      this.a();
                      Exception innerException = ex.InnerException;
                      goto case 14;
                    }
                  case 36:
                    if (A_0 != COMMS_OP.OTAP_READ_WRITE)
                    {
                      num1 = (short) 13;
                      num4 = (int) (IntPtr) num1;
                      continue;
                    }
                    goto case 37;
                  case 37:
                    num1 = (short) 25;
                    num4 = (int) (IntPtr) num1;
                    continue;
                  case 38:
                    switch (0)
                    {
                      case 0:
                        goto label_8;
                      default:
                        continue;
                    }
                  case 39:
                    semaphore = Semaphore.OpenExisting(RptMgrErrorHandler.b("\uDD91삓힕좗\uDE99\uF59B\uED9D킟캡얣\uDFA5ﾧ쮩얫\uDAAD", A_1_1));
                    semaphore.WaitOne();
                    num1 = (short) 47;
                    num4 = (int) (IntPtr) num1;
                    continue;
                  case 40:
                    if (otapPrescenceResult.DevicePrescence != OTAP_SUBSCRIBER_NETWORK_PRESCENCE.OTAP_RADIO_STATUS_USER_ENTERED)
                    {
                      num1 = (short) 50;
                      num4 = (int) (IntPtr) num1;
                      continue;
                    }
                    num1 = (short) 24;
                    num4 = (int) (IntPtr) num1;
                    continue;
                  case 41:
                    if (A_4 == 0)
                    {
                      num1 = (short) 45;
                      num4 = (int) (IntPtr) num1;
                      continue;
                    }
                    goto label_105;
                  case 42:
                    if (A_0 == COMMS_OP.USB_CLONE)
                    {
                      num1 = (short) 32 /*0x20*/;
                      num4 = (int) (IntPtr) num1;
                      continue;
                    }
                    num1 = (short) 41;
                    num4 = (int) (IntPtr) num1;
                    continue;
                  case 45:
                    num1 = (short) 21;
                    num4 = (int) (IntPtr) num1;
                    continue;
                  case 46:
                    num1 = (short) 9;
                    num4 = (int) (IntPtr) num1;
                    continue;
                  case 47:
                    nullable1 = this.e;
                    otapPrescenceResult = this.f;
                    num1 = (short) 17;
                    num4 = (int) (IntPtr) num1;
                    continue;
                  case 48 /*0x30*/:
                    if (A_0 == COMMS_OP.OTAP_CLONE)
                    {
                      num1 = (short) 37;
                      num4 = (int) (IntPtr) num1;
                      continue;
                    }
                    goto case 14;
                  case 49:
                    num1 = (short) 12;
                    num4 = (int) (IntPtr) num1;
                    continue;
                  case 50:
                    if (otapPrescenceResult.DevicePrescence == OTAP_SUBSCRIBER_NETWORK_PRESCENCE.OTAP_RADIO_STATUS_ABSENT)
                    {
                      num1 = (short) 22;
                      num4 = (int) (IntPtr) num1;
                      continue;
                    }
                    num1 = (short) 23;
                    num4 = (int) (IntPtr) num1;
                    continue;
                  case 51:
                    num1 = (short) 36;
                    num4 = (int) (IntPtr) num1;
                    continue;
                  case 52:
                    goto label_123;
                  default:
label_8:
                    if (A_0 != COMMS_OP.USB_READ_WRITE)
                    {
                      num1 = (short) 33;
                      num4 = (int) (IntPtr) num1;
                      continue;
                    }
                    goto case 32 /*0x20*/;
                }
                flag2 = false;
                // ISSUE: reference to a compiler-generated field
                SpecialFeatures.Comms.Comms.a(0.0, RptMgrErrorHandler.b("늑", A_1_1) + AppResources.POP25_operation_was_aborted);
                num1 = (short) 26;
                num4 = (int) (IntPtr) num1;
                continue;
label_105:
                num1 = (short) 18;
                num4 = (int) (IntPtr) num1;
              }
            }
            catch (Exception ex)
            {
              Logger.Log(RptMgrErrorHandler.b("즑", A_1_1) + DateTime.Now.ToString() + RptMgrErrorHandler.b("늑릓뚕", A_1_1) + ex.Message + RptMgrErrorHandler.b("쾑", A_1_1));
              // ISSUE: reference to a compiler-generated field
              if (SpecialFeatures.Comms.Comms.a != null)
              {
                // ISSUE: reference to a compiler-generated field
                SpecialFeatures.Comms.Comms.a(0.0, ex.Message);
              }
              this.a();
              flag1 = false;
              goto label_123;
            }
            finally
            {
              int num6 = 0;
              while (true)
              {
                switch (num6)
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
                    goto label_122;
                  case 2:
                    semaphore.Dispose();
                    num6 = 1;
                    continue;
                }
                if (semaphore != null)
                  num6 = 2;
                else
                  break;
              }
label_122:;
            }
        }
    }
  }

  public void OTAPRadioResult(
    bool? otapDialogResult,
    OTAPProgrammingParameters RadioProgrammingParameters,
    OTAPPrescenceResult RadioPrescenceResult)
  {
    short num1 = -29051;
    int num2 = (int) num1;
    num1 = (short) -29051;
    int num3 = (int) num1;
    switch (num2 == num3)
    {
      case true:
        short num4 = 1;
        if (num4 == (short) 0)
          ;
        num4 = (short) 0;
        num4 = (short) 0;
        if (num4 == (short) 0)
          ;
        this.e = otapDialogResult;
        this.d = RadioProgrammingParameters;
        this.f = RadioPrescenceResult;
        break;
      default:
        goto case 1;
    }
  }

  public void GetReadWritePassword(
    ref bool read,
    ref bool write,
    ref bool archive,
    ref string password)
  {
    short num1 = 29944;
    int num2 = (int) num1;
    num1 = (short) 29944;
    int num3 = (int) num1;
    switch (num2 == num3)
    {
      case true:
        short num4 = 1;
        if (num4 == (short) 0)
          ;
        num4 = (short) 0;
        num4 = (short) 0;
        if (num4 == (short) 0)
          ;
        read = this.j;
        write = this.k;
        archive = this.l;
        password = this.m;
        break;
      default:
        goto case 1;
    }
  }

  private void a(PbaObject A_0)
  {
label_0:
    short num1 = 0;
    int num2 = (int) num1;
    switch (num2)
    {
      default:
        num1 = (short) -13989;
        int num3 = (int) num1;
        num1 = (short) -13989;
        int num4 = (int) num1;
        switch (num3 == num4 ? 1 : 0)
        {
          case 0:
          case 2:
            goto label_0;
          default:
            num1 = (short) 1;
            if (num1 == (short) 0)
              ;
            num1 = (short) 0;
            if (num1 == (short) 0)
              ;
            IshItemCollection ishItemCollection;
            switch (0)
            {
              case 0:
label_6:
                ishItemCollection = A_0.GetCodeplugInIshItemCollection();
                num1 = (short) 0;
                num2 = (int) (IntPtr) num1;
                goto default;
              default:
                IEnumerator<KeyValuePair<IshHeader, IshItem>> enumerator;
                while (true)
                {
                  switch (num2)
                  {
                    case 0:
                      num1 = (short) 0;
                      if (ishItemCollection.Count > 0)
                      {
                        num1 = (short) 2;
                        num2 = (int) (IntPtr) num1;
                        continue;
                      }
                      goto label_30;
                    case 1:
                      goto label_9;
                    case 2:
                      enumerator = ishItemCollection.GetEnumerator();
                      num1 = (short) 1;
                      num2 = (int) (IntPtr) num1;
                      continue;
                    default:
                      goto label_6;
                  }
                }
label_30:
                return;
label_9:
                try
                {
                  num1 = (short) 0;
                  int num5 = (int) (IntPtr) num1;
                  while (true)
                  {
                    KeyValuePair<IshHeader, IshItem> current;
                    IshHeader key;
                    switch (num5)
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
                        if (((IshHeader) ref key).IshType == (ushort) 1029)
                        {
                          num1 = (short) 5;
                          num5 = (int) (IntPtr) num1;
                          continue;
                        }
                        break;
                      case 2:
                        goto label_27;
                      case 3:
                        goto label_25;
                      case 4:
                        if (!enumerator.MoveNext())
                        {
                          num1 = (short) 6;
                          num5 = (int) (IntPtr) num1;
                          continue;
                        }
                        current = enumerator.Current;
                        key = current.Key;
                        num1 = (short) 1;
                        num5 = (int) (IntPtr) num1;
                        continue;
                      case 5:
                        Encoding ascii = Encoding.ASCII;
                        IshItem ishItem = current.Value;
                        byte[] data = ((IshItem) ref ishItem).Data;
                        this.m = ascii.GetString(data, 2, 32 /*0x20*/).Trim(new char[1]);
                        ishItem = current.Value;
                        this.j = ((uint) ((IshItem) ref ishItem).Data[1] & 128U /*0x80*/) > 0U;
                        ishItem = current.Value;
                        this.k = ((uint) ((IshItem) ref ishItem).Data[1] & 64U /*0x40*/) > 0U;
                        ishItem = current.Value;
                        this.l = ((uint) ((IshItem) ref ishItem).Data[1] & 32U /*0x20*/) > 0U;
                        num1 = (short) 3;
                        num5 = (int) (IntPtr) num1;
                        continue;
                      case 6:
                        num1 = (short) 2;
                        num5 = (int) (IntPtr) num1;
                        continue;
                    }
                    num1 = (short) 4;
                    num5 = (int) (IntPtr) num1;
                  }
label_27:
                  return;
label_25:
                  return;
                }
                finally
                {
                  short num6 = 0;
                  int num7 = (int) (IntPtr) num6;
                  while (true)
                  {
                    switch (num7)
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
                        goto label_28;
                      case 2:
                        enumerator.Dispose();
                        num6 = (short) 1;
                        num7 = (int) (IntPtr) num6;
                        continue;
                    }
                    if (enumerator != null)
                    {
                      num6 = (short) 2;
                      num7 = (int) (IntPtr) num6;
                    }
                    else
                      break;
                  }
label_28:;
                }
            }
        }
    }
  }

  public IshItemCollection packToCodeplug()
  {
    short num1 = 0;
    num1 = (short) -27714;
    int num2 = (int) num1;
    num1 = (short) -27714;
    int num3 = (int) num1;
    IshItemCollection codeplug1;
    switch (num2 == num3 ? 1 : 0)
    {
      case 0:
      case 2:
label_40:
        num1 = (short) 1;
        if (num1 == (short) 0)
          ;
        return codeplug1;
      default:
        num1 = (short) 0;
        if (num1 == (short) 0)
          ;
        num1 = (short) 0;
        switch (num1)
        {
          default:
            bool flag = true;
            Dictionary<int, MemoryStream> codeplug2 = new Dictionary<int, MemoryStream>();
            IshItemCollection ishItemCollection = (IshItemCollection) null;
            PackUnpackExecutor packUnpackExecutor = new PackUnpackExecutor();
            Codeplug codeplug3;
            Codeplug codeplug4 = codeplug3 = new Codeplug();
            try
            {
              try
              {
                codeplug3 = packUnpackExecutor.Pack(this.m_readRadioParams.ModelNumber);
              }
              catch (Exception ex)
              {
                // ISSUE: reference to a compiler-generated field
                if (SpecialFeatures.Comms.Comms.a != null)
                {
                  // ISSUE: reference to a compiler-generated field
                  SpecialFeatures.Comms.Comms.a(0.0, AppResources.Pack_Failure_During_Write);
                }
                Exception innerException = ex.InnerException;
                if (ex.Message == AppResources.Codeplug_Exceeds_Size_Limit_On_Write)
                  throw new CommonException(AppResources.Codeplug_Exceeds_Size_Limit_On_Write);
                flag = false;
              }
              num1 = (short) 1;
              int num4 = (int) (IntPtr) num1;
              IEnumerator<Partition> enumerator;
              while (true)
              {
                switch (num4)
                {
                  case 0:
                    try
                    {
                      num1 = (short) 1;
                      int num5 = (int) (IntPtr) num1;
                      while (true)
                      {
                        switch (num5)
                        {
                          case 0:
                            num1 = (short) 2;
                            num5 = (int) (IntPtr) num1;
                            continue;
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
                            goto label_15;
                          case 3:
                            if (enumerator.MoveNext())
                            {
                              Partition current = enumerator.Current;
                              MemoryStream memoryStream = new MemoryStream(current.Image.GetBuffer());
                              memoryStream.SetLength(((Stream) current.Image).Length);
                              codeplug2.Add((int) current.PartitionType, memoryStream);
                              num1 = (short) 4;
                              num5 = (int) (IntPtr) num1;
                              continue;
                            }
                            num1 = (short) 0;
                            num5 = (int) (IntPtr) num1;
                            continue;
                        }
                        num1 = (short) 3;
                        num5 = (int) (IntPtr) num1;
                      }
                    }
                    finally
                    {
                      short num6 = 0;
                      int num7 = (int) (IntPtr) num6;
                      while (true)
                      {
                        switch (num7)
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
                            goto label_30;
                          case 2:
                            enumerator.Dispose();
                            num6 = (short) 1;
                            num7 = (int) (IntPtr) num6;
                            continue;
                        }
                        if (enumerator != null)
                        {
                          num6 = (short) 2;
                          num7 = (int) (IntPtr) num6;
                        }
                        else
                          break;
                      }
label_30:;
                    }
label_15:
                    ishItemCollection = new CodeplugFormatConverter().Convert(codeplug2);
                    num1 = (short) 3;
                    num4 = (int) (IntPtr) num1;
                    continue;
                  case 1:
                    switch (0)
                    {
                      case 0:
                        goto label_13;
                      default:
                        continue;
                    }
                  case 2:
                    goto label_40;
                  case 3:
                    codeplug1 = ishItemCollection;
                    num1 = (short) 2;
                    num4 = (int) (IntPtr) num1;
                    continue;
                  case 4:
                    enumerator = codeplug3.Partitions.GetEnumerator();
                    num1 = (short) 0;
                    num4 = (int) (IntPtr) num1;
                    continue;
                  default:
label_13:
                    if (flag)
                    {
                      num1 = (short) 4;
                      num4 = (int) (IntPtr) num1;
                      continue;
                    }
                    goto case 3;
                }
              }
            }
            finally
            {
              short num8 = 0;
              int num9 = (int) (IntPtr) num8;
              while (true)
              {
                switch (num9)
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
                    goto label_39;
                  case 2:
                    ((IDisposable) codeplug4).Dispose();
                    num8 = (short) 1;
                    num9 = (int) (IntPtr) num8;
                    continue;
                }
                if (codeplug4 != null)
                {
                  num8 = (short) 2;
                  num9 = (int) (IntPtr) num8;
                }
                else
                  break;
              }
label_39:;
            }
        }
    }
  }

  public void unpackFromRadio(IshItemCollection radioCodeplug)
  {
    switch (0)
    {
      default:
        short num1 = 1;
        if (num1 == (short) 0)
          ;
        Dictionary<int, byte[]> dictionary = new Dictionary<int, byte[]>();
        using (Dictionary<int, MemoryStream>.Enumerator enumerator = new CodeplugFormatConverter().Convert(radioCodeplug).GetEnumerator())
        {
          num1 = (short) 1;
          int num2 = (int) (IntPtr) num1;
          while (true)
          {
            switch (num2)
            {
              case 1:
label_7:
                switch (0)
                {
                  case 0:
                    break;
                  default:
                    continue;
                }
                break;
              case 2:
                goto label_5;
              case 3:
                num1 = (short) -17322;
                int num3 = (int) num1;
                num1 = (short) -17322;
                int num4 = (int) num1;
                switch (num3 == num4 ? 1 : 0)
                {
                  case 0:
                  case 2:
                    goto label_7;
                  default:
                    num1 = (short) 0;
                    if (num1 == (short) 0)
                      ;
                    num1 = (short) 2;
                    num2 = (int) (IntPtr) num1;
                    continue;
                }
              case 4:
                if (!enumerator.MoveNext())
                {
                  num1 = (short) 3;
                  num2 = (int) (IntPtr) num1;
                  continue;
                }
                KeyValuePair<int, MemoryStream> current = enumerator.Current;
                byte[] numArray = new byte[current.Value.Length];
                byte[] buffer = current.Value.GetBuffer();
                dictionary.Add(current.Key, buffer);
                num1 = (short) 0;
                num2 = (int) (IntPtr) num1;
                continue;
            }
            num1 = (short) 4;
            num2 = (int) (IntPtr) num1;
          }
        }
label_5:
        try
        {
          new PackUnpackExecutor().Unpack(dictionary, this.m_readRadioParams.ModelNumber);
          break;
        }
        catch (Exception ex)
        {
          // ISSUE: reference to a compiler-generated field
          SpecialFeatures.Comms.Comms.a(0.0, AppResources.Unpack_failure_during_read);
          Exception innerException = ex.InnerException;
          throw;
        }
    }
  }

  private bool a(COMMS_OP A_0, string A_1)
  {
    int A_1_1 = 19;
    bool flag = true;
    Semaphore semaphore = (Semaphore) null;
    try
    {
      short num1 = 1;
      int num2 = (int) (IntPtr) num1;
      while (true)
      {
        switch (num2)
        {
          case 0:
            num1 = (short) 10;
            num2 = (int) (IntPtr) num1;
            continue;
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
            num1 = (short) 14;
            num2 = (int) (IntPtr) num1;
            continue;
          case 3:
          case 13:
          case 19:
label_34:
            num1 = (short) 8;
            num2 = (int) (IntPtr) num1;
            continue;
          case 4:
            num1 = (short) 6;
            num2 = (int) (IntPtr) num1;
            continue;
          case 5:
            num1 = (short) 12;
            num2 = (int) (IntPtr) num1;
            continue;
          case 6:
            if (A_0 != COMMS_OP.OTAP_READ_WRITE)
            {
              num1 = (short) 7;
              num2 = (int) (IntPtr) num1;
              continue;
            }
            goto case 15;
          case 7:
            num1 = (short) 18;
            num2 = (int) (IntPtr) num1;
            continue;
          case 8:
            goto label_43;
          case 9:
            if (A_0 != COMMS_OP.USB_READ_WRITE)
            {
              num1 = (short) 4;
              num2 = (int) (IntPtr) num1;
              continue;
            }
            goto case 15;
          case 10:
            if (SerialNumberValidator.IsCBISerialNumber(A_1))
            {
              num1 = (short) 11;
              num2 = (int) (IntPtr) num1;
              continue;
            }
            goto case 3;
          case 11:
            num1 = (short) 23517;
            int num3 = (int) num1;
            num1 = (short) 23517;
            int num4 = (int) num1;
            switch (num3 == num4 ? 1 : 0)
            {
              case 0:
              case 2:
                goto label_34;
              default:
                num1 = (short) 0;
                if (num1 == (short) 0)
                  ;
                flag = false;
                num1 = (short) 9;
                num2 = (int) (IntPtr) num1;
                continue;
            }
          case 12:
            if (this.g != "")
            {
              num1 = (short) 2;
              num2 = (int) (IntPtr) num1;
              continue;
            }
            goto case 3;
          case 14:
            if (this.h.UpdateSN(this.m_readRadioParams, this.g))
            {
              num1 = (short) 20;
              num2 = (int) (IntPtr) num1;
              continue;
            }
            goto label_9;
          case 15:
            // ISSUE: reference to a compiler-generated field
            SpecialFeatures.Comms.Comms.b(new SpecialFeatures.Comms.Comms.CBIReturn(this.CbiReturnSN));
            num1 = (short) 16 /*0x10*/;
            num2 = (int) (IntPtr) num1;
            continue;
          case 16 /*0x10*/:
            if (!(bool) Application.Current.Properties[(object) RptMgrErrorHandler.b("햕\uF797\uF799\uF19Bﾝ캟욡\uE8A3쾥욧쾩\uEFABﺭ\uE3AF", A_1_1)])
            {
              num1 = (short) 17;
              num2 = (int) (IntPtr) num1;
              continue;
            }
            goto case 5;
          case 17:
            semaphore = Semaphore.OpenExisting(RptMgrErrorHandler.b("햕\uDA97펙\uD89B\uF79D펟튡좣장톧ﶩ춫잭쒯", A_1_1));
            semaphore.WaitOne();
            num1 = (short) 5;
            num2 = (int) (IntPtr) num1;
            continue;
          case 18:
            if (A_0 == COMMS_OP.BLUETOOTH_READ_WRITE)
            {
              num1 = (short) 15;
              num2 = (int) (IntPtr) num1;
              continue;
            }
            // ISSUE: reference to a compiler-generated field
            SpecialFeatures.Comms.Comms.a(0.0, AppResources.Read_CBI_Initialized_Radio_First);
            num1 = (short) 3;
            num2 = (int) (IntPtr) num1;
            continue;
          case 20:
            // ISSUE: reference to a compiler-generated field
            SpecialFeatures.Comms.Comms.a(0.0, AppResources.Radio_Serial_Number_updated);
            num1 = (short) 13;
            num2 = (int) (IntPtr) num1;
            continue;
        }
        if (!string.IsNullOrEmpty(A_1))
        {
          num1 = (short) 0;
          num2 = (int) (IntPtr) num1;
        }
        else
        {
          // ISSUE: reference to a compiler-generated field
          SpecialFeatures.Comms.Comms.a(0.0, AppResources.Failed_Radio_Serial_Number_read);
          flag = false;
          num1 = (short) 19;
          num2 = (int) (IntPtr) num1;
        }
      }
label_9:
      throw CommonExceptionHelper.CreateDirectMessageCommonException(AppResources.Radio_Serial_Number_update_failed);
    }
    catch (Exception ex)
    {
      flag = false;
      // ISSUE: reference to a compiler-generated field
      SpecialFeatures.Comms.Comms.a(0.0, AppResources.Radio_Serial_Number_update_failed);
    }
    finally
    {
      short num5 = 1;
      int num6 = (int) (IntPtr) num5;
      while (true)
      {
        switch (num6)
        {
          case 0:
            semaphore.Dispose();
            num5 = (short) 2;
            num6 = (int) (IntPtr) num5;
            continue;
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
            goto label_42;
        }
        if (semaphore != null)
        {
          num5 = (short) 0;
          num6 = (int) (IntPtr) num5;
        }
        else
          break;
      }
label_42:;
    }
label_43:
    short num = 0;
    num = (short) 1;
    if (num == (short) 0)
      ;
    return flag;
  }

  public void CbiReturnSN(string RadioSN)
  {
    short num1 = 0;
    num1 = (short) -27564;
    int num2 = (int) num1;
    num1 = (short) -27564;
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
        this.g = RadioSN;
        break;
      default:
        goto case 1;
    }
  }

  public RadioParams GetRadioParams()
  {
    short num1 = 1;
    if (num1 == (short) 0)
      ;
    num1 = (short) 14164;
    int num2 = (int) num1;
    num1 = (short) 14164;
    int num3 = (int) num1;
    switch (num2 == num3)
    {
      case true:
        num1 = (short) 0;
        if (num1 == (short) 0)
          ;
        return this.m_readRadioParams;
      default:
        goto case 1;
    }
  }

  public object GetLastCommsOTAPUserState()
  {
    short num1 = 0;
    num1 = (short) 26438;
    int num2 = (int) num1;
    num1 = (short) 26438;
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
        return (object) this.d;
      default:
        goto case 1;
    }
  }

  public bool SetCodeplugVersions(RadioParams radioVersions)
  {
    int num1;
    string str1;
    short num2;
    switch (0)
    {
      case 0:
label_2:
        str1 = ParseDataHelper.RadioSNToString(radioVersions.SerialNumber);
        num2 = (short) 1;
        num1 = (int) (IntPtr) num2;
        goto default;
      default:
        while (true)
        {
          Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation radioInformation;
          string str2;
          string str3;
          switch (num1)
          {
            case 0:
              if (!string.IsNullOrEmpty(radioVersions.MaceHardwareVersion))
              {
                num2 = (short) 22;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_39;
            case 1:
              num2 = (short) -31470;
              int num3 = (int) num2;
              num2 = (short) -31470;
              int num4 = (int) num2;
              switch (num3 == num4 ? 1 : 0)
              {
                case 0:
                case 2:
                  num2 = (short) 2;
                  num1 = (int) (IntPtr) num2;
                  continue;
                default:
                  num2 = (short) 0;
                  if (num2 == (short) 0)
                    ;
                  if (radioVersions.ESerialNumber == null)
                  {
                    num2 = (short) 6;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 0;
              }
            case 2:
              num2 = (short) 15;
              num1 = (int) (IntPtr) num2;
              continue;
            case 3:
              if (!string.IsNullOrEmpty(radioVersions.MaceHardwareType))
              {
                num2 = (short) 9;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 17;
            case 4:
              radioInformation.General.RadInfoGeneralPSDTVersion_A8768Value = radioVersions.PsdtVersion;
              radioInformation.General.RadInfoGeneralBootloaderVersion_A7567Value = radioVersions.BootAppVersion;
              radioInformation.General.RadInfoGeneralCodeplugVersion_A7683Value = radioVersions.CodeplugVersion.ToString();
              radioInformation.General.RadInfoGeneralTuningVersion_A9509Value = radioVersions.TuneVersion;
              num2 = (short) 12;
              num1 = (int) (IntPtr) num2;
              continue;
            case 5:
              radioInformation.OptionExpansionBoard.RadInfoOptionExpansionBoardBoardName_A37549Value = radioVersions.OptBoardName;
              num2 = (short) 8;
              num1 = (int) (IntPtr) num2;
              continue;
            case 6:
              num2 = (short) 1;
              if (num2 == (short) 0)
                ;
              str3 = string.Empty;
              break;
            case 7:
              radioInformation.OptionExpansionBoard.RadInfoOptionExpansionBoardBoardType_A37049Value = radioVersions.OptBrdHardwareType;
              num2 = (short) 13;
              num1 = (int) (IntPtr) num2;
              continue;
            case 8:
              num2 = (short) 3;
              num1 = (int) (IntPtr) num2;
              continue;
            case 9:
              radioInformation.General.RadInfoGeneralSecureHardwareTypeValue = radioVersions.MaceHardwareType;
              num2 = (short) 17;
              num1 = (int) (IntPtr) num2;
              continue;
            case 10:
              if (!string.IsNullOrEmpty(radioVersions.MaceFlashVersion))
              {
                num2 = (short) 18;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 4;
            case 11:
              radioInformation.General.RadInfoGeneralModelNumber_A8539Value = radioVersions.ModelNumber;
              radioInformation.General.RadInfoGeneralSerialNumber_A9122Value = str1;
              radioInformation.General.RadInfoGeneralElectronicSerialNumber_A41744Value = str2;
              radioInformation.General.RadInfoGeneralFirmwareVersion_A8124Value = radioVersions.HostVersion;
              radioInformation.General.RadInfoGeneralDSPVersion_A7892Value = radioVersions.DspVersion;
              num2 = (short) 10;
              num1 = (int) (IntPtr) num2;
              continue;
            case 12:
              if (!string.IsNullOrEmpty(radioVersions.OptBrdHardwareType))
              {
                num2 = (short) 7;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 13;
            case 13:
              num2 = (short) 20;
              num1 = (int) (IntPtr) num2;
              continue;
            case 14:
              num2 = (short) 0;
              radioInformation.OptionExpansionBoard.RadInfoOptionExpansionBoardBoardFirmwareVersion_A37048Value = radioVersions.OptBrdHwHostVersion;
              num2 = (short) 16 /*0x10*/;
              num1 = (int) (IntPtr) num2;
              continue;
            case 15:
              str3 = AESCryptoUtil.HEXString(radioVersions.ESerialNumber);
              break;
            case 16 /*0x10*/:
              num2 = (short) 19;
              num1 = (int) (IntPtr) num2;
              continue;
            case 17:
              num2 = (short) 0;
              num1 = (int) (IntPtr) num2;
              continue;
            case 18:
              radioInformation.General.RadInfoGeneralUCMVersion_A9591Value = radioVersions.MaceFlashVersion;
              num2 = (short) 4;
              num1 = (int) (IntPtr) num2;
              continue;
            case 19:
              if (!string.IsNullOrEmpty(radioVersions.OptBoardName))
              {
                num2 = (short) 5;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 8;
            case 20:
              if (!string.IsNullOrEmpty(radioVersions.OptBrdHwHostVersion))
              {
                num2 = (short) 14;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 16 /*0x10*/;
            case 21:
              goto label_39;
            case 22:
              radioInformation.General.RadInfoGeneralSecureHardwareVersionValue = radioVersions.MaceHardwareVersion;
              num2 = (short) 21;
              num1 = (int) (IntPtr) num2;
              continue;
            case 23:
              if (radioInformation != null)
              {
                num2 = (short) 11;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_39;
            default:
              goto label_2;
          }
          str2 = str3;
          radioInformation = FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation;
          num2 = (short) 23;
          num1 = (int) (IntPtr) num2;
        }
label_39:
        return true;
    }
  }

  public void ForceClose()
  {
    short num1 = 0;
    num1 = (short) -24190;
    int num2 = (int) num1;
    num1 = (short) -24190;
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
        this.a();
        break;
      default:
        goto case 1;
    }
  }

  public static void DispalyUpdateStatusChanged(double n, string status)
  {
    short num1 = 0;
    num1 = (short) -23022;
    int num2 = (int) num1;
    num1 = (short) -23022;
    int num3 = (int) num1;
    int num4;
    switch (num2 == num3 ? 1 : 0)
    {
      case 0:
      case 2:
        while (true)
        {
          switch (num4)
          {
            case 0:
              // ISSUE: reference to a compiler-generated field
              SpecialFeatures.Comms.Comms.a(n, status);
              num1 = (short) 2;
              num4 = (int) (IntPtr) num1;
              continue;
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
              goto label_8;
          }
          // ISSUE: reference to a compiler-generated field
          if (SpecialFeatures.Comms.Comms.a != null)
          {
            num1 = (short) 0;
            num4 = (int) (IntPtr) num1;
          }
          else
            goto label_10;
        }
label_8:
        break;
label_10:
        break;
      default:
        num1 = (short) 0;
        if (num1 == (short) 0)
          ;
        num1 = (short) 1;
        if (num1 == (short) 0)
          ;
        num1 = (short) 1;
        num4 = (int) (IntPtr) num1;
        goto case 0;
    }
  }

  protected string GetRadioAlias()
  {
label_0:
    short num1 = 0;
    num1 = (short) 0;
    int num2 = (int) num1;
    switch (num2)
    {
      default:
        num1 = (short) 1;
        if (num1 == (short) 0)
          ;
        num1 = (short) -21307;
        int num3 = (int) num1;
        num1 = (short) -21307;
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
            string radioAlias = string.Empty;
            List<IshHeader> blockList = new List<IshHeader>();
            IshHeader ishHeader;
            // ISSUE: explicit constructor call
            ((IshHeader) ref ishHeader).\u002Ector((byte) 208 /*0xD0*/, (ushort) 1026, (ushort) 0);
            blockList.Add(ishHeader);
            try
            {
              IshItemCollection ishItemCollection;
              switch (0)
              {
                case 0:
label_7:
                  ishItemCollection = this.h.ReadBlock(this.m_readRadioParams, blockList).GetCodeplugInIshItemCollection();
                  num1 = (short) 0;
                  num2 = (int) (IntPtr) num1;
                  goto default;
                default:
                  while (true)
                  {
                    IEnumerator<KeyValuePair<IshHeader, IshItem>> enumerator;
                    switch (num2)
                    {
                      case 0:
                        if (ishItemCollection.Count > 0)
                        {
                          num1 = (short) 2;
                          num2 = (int) (IntPtr) num1;
                          continue;
                        }
                        break;
                      case 1:
                        goto label_31;
                      case 2:
                        enumerator = ishItemCollection.GetEnumerator();
                        num1 = (short) 3;
                        num2 = (int) (IntPtr) num1;
                        continue;
                      case 3:
                        try
                        {
                          num1 = (short) 0;
                          int num5 = (int) (IntPtr) num1;
                          while (true)
                          {
                            KeyValuePair<IshHeader, IshItem> current;
                            IshHeader key;
                            switch (num5)
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
                                if (!enumerator.MoveNext())
                                {
                                  num1 = (short) 5;
                                  num5 = (int) (IntPtr) num1;
                                  continue;
                                }
                                current = enumerator.Current;
                                key = current.Key;
                                num1 = (short) 6;
                                num5 = (int) (IntPtr) num1;
                                continue;
                              case 2:
                                goto label_29;
                              case 3:
                              case 5:
                                num1 = (short) 2;
                                num5 = (int) (IntPtr) num1;
                                continue;
                              case 4:
                                int num6 = 59;
                                int num7 = 34;
                                char[] chArray = new char[4]
                                {
                                  char.MinValue,
                                  ' ',
                                  '\r',
                                  '\n'
                                };
                                Encoding bigEndianUnicode = Encoding.BigEndianUnicode;
                                IshItem ishItem = current.Value;
                                byte[] data = ((IshItem) ref ishItem).Data;
                                int index = num6;
                                int count = num7;
                                radioAlias = bigEndianUnicode.GetString(data, index, count).TrimEnd(chArray);
                                num1 = (short) 3;
                                num5 = (int) (IntPtr) num1;
                                continue;
                              case 6:
                                if (((IshHeader) ref key).IshType == (ushort) 1026)
                                {
                                  num1 = (short) 4;
                                  num5 = (int) (IntPtr) num1;
                                  continue;
                                }
                                break;
                            }
                            num1 = (short) 1;
                            num5 = (int) (IntPtr) num1;
                          }
                        }
                        finally
                        {
                          short num8 = 1;
                          int num9 = (int) (IntPtr) num8;
                          while (true)
                          {
                            switch (num9)
                            {
                              case 0:
                                enumerator.Dispose();
                                num8 = (short) 2;
                                num9 = (int) (IntPtr) num8;
                                continue;
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
                                goto label_28;
                            }
                            if (enumerator != null)
                            {
                              num8 = (short) 0;
                              num9 = (int) (IntPtr) num8;
                            }
                            else
                              break;
                          }
label_28:;
                        }
                      default:
                        goto label_7;
                    }
label_29:
                    num1 = (short) 1;
                    num2 = (int) (IntPtr) num1;
                  }
              }
            }
            catch
            {
              this.a();
            }
label_31:
            return radioAlias;
        }
    }
  }

  public void UpdatePINPasswordBeforeWrite()
  {
    short num1 = 0;
    num1 = (short) -505;
    int num2 = (int) num1;
    num1 = (short) -505;
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
        Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide radioWide = FeatureManager.GetFeature(2045)[0] as Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide;
        radioWide.Labtool.RadWideLabtoolEncryptedPINPassword_A41702.SetValue(((AcpField<string>) radioWide.UserInformationAndPasswords.RadWideUserInformationandPINPassword_41303).Value);
        break;
      default:
        goto case 1;
    }
  }

  private bool b()
  {
    int num1;
    bool flag;
    TrunkingSystemRecset feature;
    short num2;
    switch (0)
    {
      case 0:
label_2:
        flag = false;
        feature = FeatureManager.GetFeature(2064) as TrunkingSystemRecset;
        num2 = (short) 1;
        num1 = (int) (IntPtr) num2;
        goto default;
      default:
        IEnumerator<FeatureNode> enumerator;
        while (true)
        {
          switch (num1)
          {
            case 0:
              num2 = (short) 1;
              if (num2 == (short) 0)
                ;
              enumerator = ((Collection<FeatureNode>) feature).GetEnumerator();
              num2 = (short) 2;
              num1 = (int) (IntPtr) num2;
              continue;
            case 1:
              if (feature != null)
              {
                num2 = (short) 0;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_28;
            case 2:
              goto label_5;
            default:
              goto label_2;
          }
        }
label_5:
        try
        {
          num2 = (short) 10731;
          int num3 = (int) num2;
          num2 = (short) 10731;
          int num4 = (int) num2;
          int num5;
          switch (num3 == num4 ? 1 : 0)
          {
            case 0:
            case 2:
label_17:
              num2 = (short) 4;
              num5 = (int) (IntPtr) num2;
              break;
            default:
              num2 = (short) 0;
              if (num2 == (short) 0)
                ;
              num2 = (short) 0;
              num5 = (int) (IntPtr) num2;
              break;
          }
          while (true)
          {
            switch (num5)
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
                if (!enumerator.MoveNext())
                {
                  num2 = (short) 5;
                  num5 = (int) (IntPtr) num2;
                  continue;
                }
                num2 = (short) 3;
                num5 = (int) (IntPtr) num2;
                continue;
              case 2:
              case 4:
                goto label_28;
              case 3:
                if (((Motorola.MackinawCPS.CoreFeatures.TrunkingSystem.TrunkingSystem) enumerator.Current).General.TrkSysGeneralSystemType_A9252Value == 2)
                {
                  num2 = (short) 6;
                  num5 = (int) (IntPtr) num2;
                  continue;
                }
                break;
              case 5:
                num2 = (short) 2;
                num5 = (int) (IntPtr) num2;
                continue;
              case 6:
                goto label_16;
            }
            num2 = (short) 1;
            num5 = (int) (IntPtr) num2;
          }
label_16:
          flag = true;
          goto label_17;
        }
        finally
        {
          int num6 = 1;
          while (true)
          {
            short num7;
            switch (num6)
            {
              case 0:
                enumerator.Dispose();
                num7 = (short) 2;
                num6 = (int) (IntPtr) num7;
                continue;
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
                goto label_25;
            }
            if (enumerator != null)
            {
              num7 = (short) 0;
              num6 = (int) (IntPtr) num7;
            }
            else
              break;
          }
label_25:;
        }
label_28:
        return flag;
    }
  }

  private IDeviceProxy a(RadioParams A_0, RadioOperation A_1)
  {
    int num1 = 3;
    short num2;
    while (true)
    {
      switch (num1)
      {
        case 0:
          num2 = (short) 1;
          if (num2 == (short) 0)
            ;
          if (!this.h.CurrentRadioIsConnected)
          {
            num2 = (short) 5;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto label_15;
        case 1:
          num2 = (short) 2;
          num1 = (int) (IntPtr) num2;
          continue;
        case 2:
label_13:
          if (this.h != null)
          {
            num2 = (short) 4;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto label_15;
        case 3:
          switch (0)
          {
            case 0:
              break;
            default:
              continue;
          }
          break;
        case 4:
          num2 = (short) 0;
          num1 = (int) (IntPtr) num2;
          continue;
        case 5:
          num2 = (short) 19926;
          int num3 = (int) num2;
          num2 = (short) 19926;
          int num4 = (int) num2;
          switch (num3 == num4 ? 1 : 0)
          {
            case 0:
            case 2:
              goto label_13;
            default:
              goto label_11;
          }
      }
      if (this.h != null)
      {
        num2 = (short) 1;
        num1 = (int) (IntPtr) num2;
      }
      else
        break;
    }
label_5:
    num2 = (short) 0;
    return DeviceManagerSingleTon.Instance.CreateDeviceProxy(A_0, A_1);
label_11:
    num2 = (short) 0;
    if (num2 == (short) 0)
      goto label_5;
    goto label_5;
label_15:
    return this.h;
  }

  ~Comms()
  {
    short num1;
    try
    {
      short num2 = -24501;
      int num3 = (int) num2;
      num2 = (short) -24501;
      int num4 = (int) num2;
      switch (num3 == num4)
      {
        case true:
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          this.a(false);
          break;
        default:
          goto case 1;
      }
    }
    finally
    {
      if (false)
        ;
      // ISSUE: explicit finalizer call
      base.Finalize();
    }
    num1 = (short) 0;
  }

  public void Dispose()
  {
    short num1 = -29191;
    int num2 = (int) num1;
    num1 = (short) -29191;
    int num3 = (int) num1;
    short num4;
    switch (num2 == num3)
    {
      case true:
        num4 = (short) 1;
        if (num4 == (short) 0)
          ;
        num4 = (short) 0;
        if (num4 == (short) 0)
          ;
        this.a(true);
        GC.SuppressFinalize((object) this);
        break;
      default:
        num4 = (short) 0;
        goto case 1;
    }
  }

  private void a(bool A_0)
  {
    int num1 = 3;
    while (true)
    {
      short num2;
      switch (num1)
      {
        case 0:
          goto label_10;
        case 1:
label_11:
          num2 = (short) 2;
          num1 = (int) (IntPtr) num2;
          continue;
        case 2:
          if (this.h != null)
          {
            num2 = (short) 4;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          break;
        case 3:
          switch (0)
          {
            case 0:
              goto label_3;
            default:
              continue;
          }
        case 4:
          this.h.Dispose();
          num2 = (short) 5;
          num1 = (int) (IntPtr) num2;
          continue;
        case 5:
          num2 = (short) 1;
          if (num2 == (short) 0)
            ;
          num2 = (short) 31863;
          int num3 = (int) num2;
          num2 = (short) 31863;
          int num4 = (int) num2;
          switch (num3 == num4 ? 1 : 0)
          {
            case 0:
            case 2:
              goto label_11;
            default:
              num2 = (short) 0;
              num2 = (short) 0;
              if (num2 == (short) 0)
                break;
              break;
          }
          break;
        default:
label_3:
          if (A_0)
          {
            num2 = (short) 1;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto label_14;
      }
      this.h = (IDeviceProxy) null;
      num2 = (short) 0;
      num1 = (int) (IntPtr) num2;
    }
label_10:
    return;
label_14:;
  }

  private void a()
  {
    int num1 = 0;
    while (true)
    {
      short num2;
      switch (num1)
      {
        case 0:
          num2 = (short) -28070;
          int num3 = (int) num2;
          num2 = (short) -28070;
          int num4 = (int) num2;
          switch (num3 == num4 ? 1 : 0)
          {
            case 0:
            case 2:
              break;
            default:
              num2 = (short) 0;
              if (num2 == (short) 0)
                ;
              num2 = (short) 0;
              switch (0)
              {
                case 0:
                  break;
                default:
                  continue;
              }
              break;
          }
          break;
        case 1:
          goto label_9;
        case 2:
          num2 = (short) 1;
          if (num2 == (short) 0)
            ;
          this.h.Dispose();
          num2 = (short) 1;
          num1 = (int) (IntPtr) num2;
          continue;
      }
      if (this.h != null)
      {
        num2 = (short) 2;
        num1 = (int) (IntPtr) num2;
      }
      else
        break;
    }
label_9:
    this.h = (IDeviceProxy) null;
  }

  public string GetBluetoothPANIPAddress(COMMS_OP WriteType)
  {
    int num1 = 1;
    while (true)
    {
      switch (num1)
      {
        case 0:
          goto label_10;
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
          goto label_6;
        case 3:
          if (false)
            ;
          if (WriteType == COMMS_OP.BLUETOOTH_READ_WRITE)
          {
            num1 = 2;
            continue;
          }
          goto label_11;
      }
      short num2 = 11515;
      int num3 = (int) num2;
      num2 = (short) 11515;
      int num4 = (int) num2;
      switch (num3 == num4 ? 1 : 0)
      {
        case 0:
        case 2:
          goto label_11;
        default:
          if (true)
            ;
          num1 = WriteType != COMMS_OP.BLUETOOTH_CLONE ? 3 : 0;
          continue;
      }
    }
label_6:
    return BluetoothPANProgramming.BluetoothPANIPForWR;
label_10:
    return BluetoothPANProgramming.BluetoothPANIPForClone;
label_11:
    return (string) null;
  }

  private bool a(COMMS_OP A_0, ref RadioParams A_1, bool A_2, RadioOperation A_3 = 4)
  {
    int A_1_1 = 3;
label_1:
    switch (0)
    {
      default:
        switch (true ? 1 : 0)
        {
          case 0:
          case 2:
            goto label_1;
          default:
            if (true)
              ;
            bool flag1 = false;
            bool flag2;
            try
            {
              short num1 = 33;
              int num2 = (int) (IntPtr) num1;
              while (true)
              {
                bool? nullable1;
                bool? nullable2;
                bool flag3;
                OTAPProgrammingWindow programmingWindow;
                ProgrammingOperation operation;
                switch (num2)
                {
                  case 0:
                    num1 = (short) 10;
                    num2 = (int) (IntPtr) num1;
                    continue;
                  case 1:
                    if (programmingWindow.PrescenceResult.DevicePrescence != OTAP_SUBSCRIBER_NETWORK_PRESCENCE.OTAP_RADIO_STATUS_ABSENT)
                    {
                      num1 = (short) 5;
                      num2 = (int) (IntPtr) num1;
                      continue;
                    }
                    num1 = (short) 31 /*0x1F*/;
                    num2 = (int) (IntPtr) num1;
                    continue;
                  case 2:
                    num1 = (short) 24;
                    num2 = (int) (IntPtr) num1;
                    continue;
                  case 3:
                    num1 = (short) 32 /*0x20*/;
                    num2 = (int) (IntPtr) num1;
                    continue;
                  case 4:
                  case 16 /*0x10*/:
                  case 17:
                  case 19:
                  case 26:
                    num1 = (short) 29;
                    num2 = (int) (IntPtr) num1;
                    continue;
                  case 5:
                    if (programmingWindow.PrescenceResult.DevicePrescence == OTAP_SUBSCRIBER_NETWORK_PRESCENCE.OTAP_RADIO_STATUS_TIMEOUT)
                    {
                      num1 = (short) 8;
                      num2 = (int) (IntPtr) num1;
                      continue;
                    }
                    AppInfoManager.StatusMsgReport.RegisterMessage((StatusMsgType) 0, AppResources.The_radio_network_address_could_not_be_determined);
                    flag1 = false;
                    num1 = (short) 4;
                    num2 = (int) (IntPtr) num1;
                    continue;
                  case 6:
                    if (flag1)
                    {
                      num1 = (short) 18;
                      num2 = (int) (IntPtr) num1;
                      continue;
                    }
                    goto case 4;
                  case 7:
                    if (string.IsNullOrEmpty(A_1.ConnectionInfo.UniqueAddress))
                    {
                      num1 = (short) 11;
                      num2 = (int) (IntPtr) num1;
                      continue;
                    }
                    goto case 4;
                  case 8:
                    AppInfoManager.StatusMsgReport.RegisterMessage((StatusMsgType) 0, AppResources.The_application_could_not_communicate_with_the_Automatic_Registration_Server_ARS);
                    flag1 = false;
                    num1 = (short) 17;
                    num2 = (int) (IntPtr) num1;
                    continue;
                  case 9:
                    nullable2 = nullable1;
                    flag3 = true;
                    num1 = (short) 12;
                    num2 = (int) (IntPtr) num1;
                    continue;
                  case 10:
                    if (A_0 == COMMS_OP.USB_CLONE)
                    {
                      num1 = (short) 2;
                      num2 = (int) (IntPtr) num1;
                      continue;
                    }
                    num1 = (short) 35;
                    num2 = (int) (IntPtr) num1;
                    continue;
                  case 11:
                    flag1 = false;
                    // ISSUE: reference to a compiler-generated field
                    SpecialFeatures.Comms.Comms.a(0.0, AppResources.Could_not_find_a_radio_connected_to_a_USB_port);
                    num1 = (short) 16 /*0x10*/;
                    num2 = (int) (IntPtr) num1;
                    continue;
                  case 12:
                    if (nullable2.GetValueOrDefault() == flag3 & nullable2.HasValue)
                    {
                      num1 = (short) 22;
                      num2 = (int) (IntPtr) num1;
                      continue;
                    }
                    break;
                  case 13:
                    num1 = (short) 30;
                    num2 = (int) (IntPtr) num1;
                    continue;
                  case 14:
                  case 23:
                    programmingWindow = new OTAPProgrammingWindow(operation, this.d);
                    Window mainWindow = Application.Current.MainWindow;
                    programmingWindow.Owner = mainWindow;
                    nullable1 = programmingWindow.ShowDialog();
                    num1 = (short) 20;
                    num2 = (int) (IntPtr) num1;
                    continue;
                  case 15:
                    if (A_2)
                    {
                      num1 = (short) 27;
                      num2 = (int) (IntPtr) num1;
                      continue;
                    }
                    operation = ProgrammingOperation.PROGRAMMING_OPERATION_WRITE;
                    num1 = (short) 14;
                    num2 = (int) (IntPtr) num1;
                    continue;
                  case 18:
                    num1 = (short) 7;
                    num2 = (int) (IntPtr) num1;
                    continue;
                  case 20:
                    if (nullable1.HasValue)
                    {
                      num1 = (short) 9;
                      num2 = (int) (IntPtr) num1;
                      continue;
                    }
                    break;
                  case 21:
                    num1 = (short) 34;
                    num2 = (int) (IntPtr) num1;
                    continue;
                  case 22:
                    this.d = programmingWindow.OTAPProgrammingLastState;
                    num1 = (short) 28;
                    num2 = (int) (IntPtr) num1;
                    continue;
                  case 24:
                    try
                    {
                      switch (0)
                      {
                        case 0:
label_52:
                          RadioParams A_0_1 = new RadioParams()
                          {
                            Family = (ProductFamily) 1,
                            ConnectionInfo = new ConnectionInfo()
                          };
                          A_0_1.ConnectionInfo.ConnectionType = (ConnectionType) 4;
                          this.h = this.a(A_0_1, A_3);
                          A_1 = this.h.ReadExtendedDeviceInfo();
                          num1 = (short) 1;
                          num2 = (int) (IntPtr) num1;
                          goto default;
                        default:
                          while (true)
                          {
                            switch (num2)
                            {
                              case 0:
                                flag1 = true;
                                num1 = (short) 3;
                                num2 = (int) (IntPtr) num1;
                                continue;
                              case 1:
                                if (A_1 != null)
                                {
                                  num1 = (short) 0;
                                  num2 = (int) (IntPtr) num1;
                                  continue;
                                }
                                goto case 3;
                              case 2:
                                goto label_30;
                              case 3:
                                num1 = (short) 2;
                                num2 = (int) (IntPtr) num1;
                                continue;
                              default:
                                goto label_52;
                            }
                          }
                      }
                    }
                    catch (Exception ex)
                    {
                      AppInfoManager.StatusMsgReport.RegisterMessage((StatusMsgType) 0, AppResources.Radio_Caught_exception_while_locating_radio_IP_Address);
                      Exception innerException = ex.InnerException;
                      flag1 = false;
                      this.a();
                    }
label_30:
                    num1 = (short) 6;
                    num2 = (int) (IntPtr) num1;
                    continue;
                  case 25:
                    num1 = (short) 15;
                    num2 = (int) (IntPtr) num1;
                    continue;
                  case 27:
                    operation = ProgrammingOperation.PROGRAMMING_OPERATION_READ;
                    num1 = (short) 23;
                    num2 = (int) (IntPtr) num1;
                    continue;
                  case 28:
                    if (programmingWindow.PrescenceResult.DevicePrescence != OTAP_SUBSCRIBER_NETWORK_PRESCENCE.OTAP_RADIO_STATUS_PRESENT)
                    {
                      num1 = (short) 13;
                      num2 = (int) (IntPtr) num1;
                      continue;
                    }
                    goto case 3;
                  case 29:
                    goto label_5;
                  case 30:
                    if (programmingWindow.PrescenceResult.DevicePrescence != OTAP_SUBSCRIBER_NETWORK_PRESCENCE.OTAP_RADIO_STATUS_USER_ENTERED)
                    {
                      num1 = (short) 1;
                      num2 = (int) (IntPtr) num1;
                      continue;
                    }
                    num1 = (short) 3;
                    num2 = (int) (IntPtr) num1;
                    continue;
                  case 31 /*0x1F*/:
                    AppInfoManager.StatusMsgReport.RegisterMessage((StatusMsgType) 0, AppResources.The_radio_is_not_on_the_network);
                    flag1 = false;
                    num1 = (short) 19;
                    num2 = (int) (IntPtr) num1;
                    continue;
                  case 32 /*0x20*/:
                    try
                    {
                      RadioParams A_0_2 = new RadioParams()
                      {
                        Family = (ProductFamily) 1,
                        ConnectionInfo = new ConnectionInfo()
                      };
                      A_0_2.ConnectionInfo.UniqueAddress = programmingWindow.PrescenceResult.DeviceIPAddress;
                      A_0_2.ConnectionInfo.ConnectionType = (ConnectionType) 16 /*0x10*/;
                      this.h = this.a(A_0_2, A_3);
                      A_1 = this.h.ReadExtendedDeviceInfo();
                      flag1 = true;
                      goto case 4;
                    }
                    catch (Exception ex)
                    {
                      this.a();
                      flag1 = false;
                      AppInfoManager.StatusMsgReport.RegisterMessage((StatusMsgType) 0, AppResources.The_radio_network_address_could_not_be_determined);
                      Exception innerException = ex.InnerException;
                      goto case 4;
                    }
                  case 33:
                    switch (0)
                    {
                      case 0:
                        goto label_9;
                      default:
                        continue;
                    }
                  case 34:
                    if (A_0 == COMMS_OP.OTAP_CLONE)
                    {
                      num1 = (short) 25;
                      num2 = (int) (IntPtr) num1;
                      continue;
                    }
                    goto case 4;
                  case 35:
                    if (A_0 != COMMS_OP.OTAP_READ_WRITE)
                    {
                      num1 = (short) 21;
                      num2 = (int) (IntPtr) num1;
                      continue;
                    }
                    goto case 25;
                  default:
label_9:
                    if (A_0 != COMMS_OP.USB_READ_WRITE)
                    {
                      num1 = (short) 0;
                      num2 = (int) (IntPtr) num1;
                      continue;
                    }
                    goto case 2;
                }
                flag1 = false;
                AppInfoManager.StatusMsgReport.RegisterMessage((StatusMsgType) 0, RptMgrErrorHandler.b("ꚅ", A_1_1) + AppResources.POP25_Operation_Aborted);
                num1 = (short) 26;
                num2 = (int) (IntPtr) num1;
              }
            }
            catch
            {
              this.a();
              flag2 = false;
              goto label_68;
            }
label_5:
            return flag1;
label_68:
            short num = 1;
            if (num == (short) 0)
              ;
            num = (short) 0;
            return flag2;
        }
    }
  }

  public bool CbiProgram(COMMS_OP readType)
  {
    int A_1_1 = 10;
    int num1;
    short num2;
    RadioParams A_1_2;
    switch (0)
    {
      case 0:
label_2:
        num2 = (short) 13800;
        int num3 = (int) num2;
        num2 = (short) 13800;
        int num4 = (int) num2;
        switch (num3 == num4 ? 1 : 0)
        {
          case 0:
          case 2:
            break;
          default:
            num2 = (short) 0;
            if (num2 == (short) 0)
              ;
            A_1_2 = (RadioParams) null;
            num2 = (short) 0;
            num1 = (int) (IntPtr) num2;
            goto label_1;
        }
        break;
      default:
        bool flag;
        while (true)
        {
          switch (num1)
          {
            case 0:
              goto label_5;
            case 1:
              goto label_18;
            case 2:
              num2 = (short) 0;
              flag = false;
              num2 = (short) 1;
              num1 = (int) (IntPtr) num2;
              continue;
            default:
              goto label_2;
          }
label_1:;
        }
label_18:
        num2 = (short) 1;
        if (num2 == (short) 0)
          ;
        try
        {
          switch (0)
          {
            case 0:
label_9:
              flag = this.h.CBIProgram(A_1_2);
              num2 = (short) 1;
              num1 = (int) (IntPtr) num2;
              goto default;
            default:
              while (true)
              {
                switch (num1)
                {
                  case 0:
                    AppInfoManager.StatusMsgReport.RegisterMessage((StatusMsgType) 2, AppResources.Radio_CBI_Program_Successfully);
                    num2 = (short) 3;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  case 1:
                    if (flag)
                    {
                      num2 = (short) 0;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    }
                    goto label_13;
                  case 2:
                    goto label_19;
                  case 3:
                    num2 = (short) 2;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  default:
                    goto label_9;
                }
              }
label_13:
              throw CommonExceptionHelper.CreateDirectMessageCommonException(AppResources.Radio_Serial_Number_update_failed);
          }
        }
        catch (Exception ex)
        {
          flag = false;
          AppInfoManager.StatusMsgReport.RegisterMessage((StatusMsgType) 0, AppResources.Radio_CBI_Program_failed);
        }
        finally
        {
          this.a();
        }
label_19:
        return flag;
    }
label_5:
    if (!this.a(readType, ref A_1_2, true, (RadioOperation) 128L /*0x80*/, A_5: RptMgrErrorHandler.b("붌ꆎꆐ붒ꖔ릖ꦘ", A_1_1)))
      return false;
    num2 = (short) 2;
    num1 = (int) (IntPtr) num2;
    goto label_1;
  }

  public bool WriteRadioForDepot(
    IshItemCollection radioCodeplug,
    COMMS_OP WriteType,
    RadioParams codeplgParams,
    object lastCommsUserState)
  {
    int num1 = 3;
    short num2;
    while (true)
    {
      switch (num1)
      {
        case 0:
          goto label_6;
        case 1:
label_10:
          num2 = (short) 2;
          num1 = (int) (IntPtr) num2;
          continue;
        case 2:
          if (lastCommsUserState == null)
          {
            this.d = (OTAPProgrammingParameters) null;
            num2 = (short) 0;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          num2 = (short) 4;
          num1 = (int) (IntPtr) num2;
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
        case 4:
          this.d = lastCommsUserState as OTAPProgrammingParameters;
          num2 = (short) 5;
          num1 = (int) (IntPtr) num2;
          continue;
        case 5:
          num2 = (short) -2675;
          int num3 = (int) num2;
          num2 = (short) -2675;
          int num4 = (int) num2;
          switch (num3 == num4 ? 1 : 0)
          {
            case 0:
            case 2:
              goto label_10;
            default:
              goto label_9;
          }
      }
      if (WriteType == COMMS_OP.OTAP_READ_WRITE)
      {
        num2 = (short) 1;
        num1 = (int) (IntPtr) num2;
      }
      else
        goto label_13;
    }
label_6:
    num2 = (short) 1;
    if (num2 == (short) 0)
      goto label_13;
    goto label_13;
label_9:
    num2 = (short) 0;
    num2 = (short) 0;
    if (num2 == (short) 0)
      ;
label_13:
    return this.WriteRadioForDepot(radioCodeplug, WriteType, codeplgParams);
  }

  public bool WriteRadioForDepot(
    IshItemCollection radioCodeplug,
    COMMS_OP WriteType,
    RadioParams codeplgParams)
  {
    int A_1_1 = 13;
    int num1 = 0;
    switch (num1)
    {
      default:
        short num2;
        bool flag;
        RadioParams A_1_2;
        switch (0)
        {
          case 0:
label_3:
            num2 = (short) 12021;
            int num3 = (int) num2;
            num2 = (short) 12021;
            int num4 = (int) num2;
            switch (num3 == num4 ? 1 : 0)
            {
              case 0:
              case 2:
                break;
              default:
                num2 = (short) 0;
                if (num2 == (short) 0)
                  ;
                flag = false;
                A_1_2 = (RadioParams) null;
                num2 = (short) 0;
                num1 = (int) (IntPtr) num2;
                goto label_2;
            }
            break;
          default:
            while (true)
            {
              switch (num1)
              {
                case 0:
                  if (!this.a(WriteType, ref A_1_2, false, (RadioOperation) 4L))
                  {
                    num2 = (short) 2;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 1;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 1:
                  goto label_9;
                case 2:
                  goto label_8;
                default:
                  goto label_3;
              }
label_2:;
            }
label_8:
            num2 = (short) 0;
            return false;
label_9:
            try
            {
              num2 = (short) 1;
              if (num2 == (short) 0)
                ;
              PbaObject targetPba = new PbaObject();
              targetPba.SetCodeplug(radioCodeplug);
              this.h.ForceWrite(A_1_2, targetPba);
              flag = true;
              Thread.Sleep(500);
              break;
            }
            catch (CommonException ex)
            {
              // ISSUE: reference to a compiler-generated field
              SpecialFeatures.Comms.Comms.a(0.0, ((Exception) ex).Message);
              Logger.Log(RptMgrErrorHandler.b("쮏", A_1_1) + DateTime.Now.ToString() + RptMgrErrorHandler.b("낏뾑뒓", A_1_1) + ((Exception) ex).Message + RptMgrErrorHandler.b("춏", A_1_1));
              break;
            }
            catch (Exception ex)
            {
              AppInfoManager.StatusMsgReport.RegisterMessage((StatusMsgType) 0, ex.Message);
              Exception innerException = ex.InnerException;
              break;
            }
            finally
            {
              this.a();
            }
        }
        return flag;
    }
  }

  public delegate void MainUIDisplayCBI(SpecialFeatures.Comms.Comms.CBIReturn CbiSN);

  public delegate void CBIReturn(string radioSN);

  public delegate void DisplayUpdateStatus(double n, string stat);

  public delegate void MainUIDisplayOTAP(
    ProgrammingOperation ProgOp,
    OTAPProgrammingParameters LastCommsOTAPUserState,
    SpecialFeatures.Comms.Comms.RadioOTAPObject radioObject);

  public delegate void RadioOTAPObject(
    bool? otapDialogResult,
    OTAPProgrammingParameters RadioProgrammingParameters,
    OTAPPrescenceResult RadioPrescenceResult);

  public delegate void WriteRadioQuery(SpecialFeatures.Comms.Comms.RadioRtn info);

  public delegate void RadioRtn(MessageBoxResult RadioRtn);
}
