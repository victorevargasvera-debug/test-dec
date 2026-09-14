// Decompiled with JetBrains decompiler
// Type: AcpASKLib.Constants
// Assembly: AcpASKLib, Version=23.1.0.5, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: D65BC533-E9D0-49A5-8218-5CB2B5C70E2D
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpASKLib.dll

using System;

#nullable disable
namespace AcpASKLib;

public static class Constants
{
  public const int FIELD_CODE_ARRAY_SZ = 24;
  public const int LEGACY_FIELD_CODE_ARRAY_SZ = 12;
  public const int VERSION_R01_00_00 = 1;
  public const int VERSION_R01_01_00 = 1;
  public const int VERSION_R01_01_01 = 2;
  public const int VERSION_R01_01_02 = 3;
  public const int VERSION_SUPPORT_PASSWORD = 3;
  public const int VERSION_R01_01_03 = 4;
  public const int VERSION_R01_01_04 = 5;
  public const int CURRENT_VERSION = 5;
  public const int FILE_ID_POS = 8;
  public const int VERSION_POS = 9;
  public const int COUNTER_1_POS = 10;
  public const int SYSTME_TYPE_POS = 10;
  public const int COUNTER_2_POS = 11;
  public const int MASK_FILE_ID = 0;
  public const int KEYS_FILE_ID = 1;
  public const int DATA_FILE_ID = 2;
  public const int MSTR_FILE_ID = 3;
  public const int OTAP_FILE_ID = 4;
  public const int MISR_FILE_ID = 5;
  public const int SERIAL_NUM_SZ = 8;
  public const int KEYS_FILE_HEADER_SZ = 11;
  public const int DATA_FILE_HEADER_SZ = 11;
  public const int MASK_FILE_HEADER_SZ = 10;
  public const int OTAP_FILE_HEADER_SZ = 12;
  public const int IBTN_PAGE_SIZE = 28;
  public const int BTN_PASSWORD_MAX_LENGTH = 10;
  public const int PASSWORD_RETRY_LIMITATION = 3;
  public const string SSYSKEYFILESSEARCHKEY = "*.key";
  public static readonly string COMMON_APPLICATION_PATH = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
  public static readonly string ACCESS_LIST_PATH_AND_NAME = Constants.COMMON_APPLICATION_PATH + "\\Motorola\\SysKeyAdmin\\AccessList.xml";
  public static readonly string MACK_ACCESS_LIST_PATH_AND_NAME = Constants.COMMON_APPLICATION_PATH + "\\Motorola\\SysKeyAdmin\\ApxAccessList.xml";
  public static readonly int MAX_LENGTH = 64 /*0x40*/;

  internal static DateTime ReferenceDate => new DateTime(1970, 1, 1);
}
