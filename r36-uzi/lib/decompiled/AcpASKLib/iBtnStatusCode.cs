// Decompiled with JetBrains decompiler
// Type: AcpASKLib.iBtnStatusCode
// Assembly: AcpASKLib, Version=23.1.0.5, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: D65BC533-E9D0-49A5-8218-5CB2B5C70E2D
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpASKLib.dll

using AcpCommonResources;
using AcpUtility;
using System;

#nullable disable
namespace AcpASKLib;

public static class iBtnStatusCode
{
  public const uint S_OK = 0;
  public const uint E_INFO_BASE = 1610645504 /*0x60008000*/;
  public const uint E_SILENT_MODE = 1610645505 /*0x60008001*/;
  public const uint E_READ_ASK_SUCCESSFUL = 1610645506 /*0x60008002*/;
  public const uint E_READ_ASK_FAILED = 1610645507 /*0x60008003*/;
  public const uint E_WRITE_ASK_SUCCESSFUL = 1610645508 /*0x60008004*/;
  public const uint E_WRITE_ASK_FAILED = 1610645509 /*0x60008005*/;
  public const uint E_SET_PASSWORD_CANCELLED = 1610645510 /*0x60008006*/;
  public const uint E_WARNING_BASE = 2684387328 /*0xA0008000*/;
  public const uint E_ACCESS_LOCKEDOUT = 2684387329 /*0xA0008001*/;
  public const uint E_NOT_SUPPORT_PASSWORD = 2684387330 /*0xA0008002*/;
  public const uint E_NO_KEY_LOADED = 2684387331 /*0xA0008003*/;
  public const uint E_UP_PSWD_RETRY_LIMITATION = 2684387332 /*0xA0008004*/;
  public const uint E_UPGRADE_WITHOUT_MASTER_KEY = 2684387333 /*0xA0008005*/;
  public const uint E_NO_MASTER_KEY_LOADED = 2684387334 /*0xA0008006*/;
  public const uint E_ABORT_ACCESS_PASSWORD = 2684387335 /*0xA0008007*/;
  public const uint E_READ_IMCOMPATIBLE_VERSION_IBTN = 2684387336 /*0xA0008008*/;
  public const uint E_FILE_NOT_EXIST = 2684387337 /*0xA0008009*/;
  public const uint E_WRITE_OLD_VERSION_IBTN = 2684387338 /*0xA000800A*/;
  public const uint E_WRITE_NEW_VERSION_IBTN = 2684387339 /*0xA000800B*/;
  public const uint E_WRITE_IBTN_CANCELLED = 2684387340 /*0xA000800C*/;
  public const uint E_MESSAGE_BOX_SHOWN = 2684387341 /*0xA000800D*/;
  public const uint E_NOT_SUPPORT_SW_EXPIRATION = 2684387342 /*0xA000800E*/;
  public const uint E_ERROR_BASE = 3758129152 /*0xE0008000*/;
  public const uint E_IBTN_ABSENT = 3758129153 /*0xE0008001*/;
  public const uint E_INTERNAL_PROGRAM_ERROR = 3758129154 /*0xE0008002*/;
  public const uint E_SN_NOT_MATCH = 3758129155 /*0xE0008003*/;
  public const uint E_CRC_NOT_MATCH = 3758129156 /*0xE0008004*/;
  public const uint E_IBTN_BE_REPLACED = 3758129157 /*0xE0008005*/;
  public const uint E_NO_KEY_IN_ASK = 3758129158 /*0xE0008006*/;
  public const uint E_ERROR_MESSAGE_DUMMY = 3758129159 /*0xE0008007*/;
  public const uint E_NOT_VALID_IBTN_KEY = 3758129160 /*0xE0008008*/;
  public const uint E_FILE_IS_DAMAGED = 3758129161 /*0xE0008009*/;
  public const uint E_OUTOFMEMORY = 3758129162 /*0xE000800A*/;
  public const uint E_ACCESSDENIED = 3758129163 /*0xE000800B*/;
  public const uint E_KEY_EXPIRED = 3758129164 /*0xE000800C*/;
  public const uint E_READ_SOFTWARE_KEY_FAILED = 3758129165 /*0xE000800D*/;
  public const uint E_HIGH_WATER_MARK_VIOLATION = 3758129166 /*0xE000800E*/;

  public static string GetErrorMsg(uint hStatus)
  {
    string errorMsg = (string) null;
    switch (hStatus)
    {
      case 2684387329 /*0xA0008001*/:
        errorMsg = AcpResources.Account_Locked_Out;
        goto case 2684387338 /*0xA000800A*/;
      case 2684387330 /*0xA0008002*/:
        errorMsg = AcpResources.Advance_Key_Old + Environment.NewLine;
        goto case 2684387338 /*0xA000800A*/;
      case 2684387331 /*0xA0008003*/:
        errorMsg = (AcpResources.No_Key_Loaded + Environment.NewLine).AcpStringFormat();
        goto case 2684387338 /*0xA000800A*/;
      case 2684387332 /*0xA0008004*/:
        errorMsg = AcpResources.Incorrect_Password + Environment.NewLine;
        goto case 2684387338 /*0xA000800A*/;
      case 2684387333 /*0xA0008005*/:
        errorMsg = (AcpResources.Not_Updated_Master_key + Environment.NewLine).AcpStringFormat();
        goto case 2684387338 /*0xA000800A*/;
      case 2684387334 /*0xA0008006*/:
        errorMsg = (AcpResources.Load_Master_Key + Environment.NewLine).AcpStringFormat();
        goto case 2684387338 /*0xA000800A*/;
      case 2684387335 /*0xA0008007*/:
        errorMsg = (AcpResources.Access_Password + Environment.NewLine).AcpStringFormat();
        goto case 2684387338 /*0xA000800A*/;
      case 2684387336 /*0xA0008008*/:
        errorMsg = AcpResources.Cannot_Read_Key;
        goto case 2684387338 /*0xA000800A*/;
      case 2684387338 /*0xA000800A*/:
      case 3758129159 /*0xE0008007*/:
        return errorMsg;
      case 2684387339 /*0xA000800B*/:
        errorMsg = AcpResources.New_Version_iBtn;
        goto case 2684387338 /*0xA000800A*/;
      case 3758129153 /*0xE0008001*/:
        errorMsg = (AcpResources.iButton_Absent + Environment.NewLine).AcpStringFormat();
        goto case 2684387338 /*0xA000800A*/;
      case 3758129154 /*0xE0008002*/:
        errorMsg = (AcpResources.Internal_Error_Msg + Environment.NewLine).AcpStringFormat();
        goto case 2684387338 /*0xA000800A*/;
      case 3758129155 /*0xE0008003*/:
        errorMsg = AcpResources.SN_No_Not_Match + Environment.NewLine;
        goto case 2684387338 /*0xA000800A*/;
      case 3758129156 /*0xE0008004*/:
        errorMsg = (AcpResources.CRC_Not_Match + Environment.NewLine).AcpStringFormat();
        goto case 2684387338 /*0xA000800A*/;
      case 3758129157 /*0xE0008005*/:
        errorMsg = AcpResources.Advance_Key_Replaced + Environment.NewLine;
        goto case 2684387338 /*0xA000800A*/;
      case 3758129158 /*0xE0008006*/:
        errorMsg = AcpResources.Advance_Sys_key.AcpStringFormat();
        goto case 2684387338 /*0xA000800A*/;
      case 3758129160 /*0xE0008008*/:
        errorMsg = AcpResources.Advance_Key_Invalid.AcpStringFormat();
        goto case 2684387338 /*0xA000800A*/;
      case 3758129161 /*0xE0008009*/:
        errorMsg = AcpResources.iButton_Damaged.AcpStringFormat();
        goto case 2684387338 /*0xA000800A*/;
      case 3758129162 /*0xE000800A*/:
        errorMsg = AcpResources.Out_Of_Memory.AcpStringFormat();
        goto case 2684387338 /*0xA000800A*/;
      case 3758129163 /*0xE000800B*/:
        errorMsg = AcpResources.Access_Denied.AcpStringFormat();
        goto case 2684387338 /*0xA000800A*/;
      case 3758129164 /*0xE000800C*/:
        errorMsg = AcpResources.iButton_Expired.AcpStringFormat();
        goto case 2684387338 /*0xA000800A*/;
      case 3758129166 /*0xE000800E*/:
        errorMsg = AcpResources.HighWaterMark_Security_Violation.AcpStringFormat();
        goto case 2684387338 /*0xA000800A*/;
      default:
        errorMsg = AcpResources.Undefined_Error_Status.AcpStringFormat((object) (hStatus.ToString() + Environment.NewLine));
        goto case 2684387338 /*0xA000800A*/;
    }
  }
}
