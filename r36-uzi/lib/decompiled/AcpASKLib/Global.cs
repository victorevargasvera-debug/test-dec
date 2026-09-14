// Decompiled with JetBrains decompiler
// Type: AcpASKLib.Global
// Assembly: AcpASKLib, Version=23.1.0.5, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: D65BC533-E9D0-49A5-8218-5CB2B5C70E2D
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpASKLib.dll

using System.Collections.ObjectModel;

#nullable disable
namespace AcpASKLib;

public static class Global
{
  public static PersistentData m_persistentData = new PersistentData();
  private static byte[] CheckSumTable = new byte[8]
  {
    (byte) 0,
    (byte) 153,
    (byte) 172,
    (byte) 53,
    (byte) 199,
    (byte) 94,
    (byte) 107,
    (byte) 242
  };

  internal static PersistentData GetPersistentAccessLevelRoot() => Global.m_persistentData;

  internal static void AddRadioWideAccessLevel(AccessRecord record)
  {
    Global.m_persistentData.RadioWideACLRecSet.AddNewRecord(record);
  }

  public static void AddSystemWideAccessLevel(AccessRecord record)
  {
    Global.m_persistentData.SystemWideACLRecSet.AddNewRecord(record);
  }

  internal static void AddConvSysAccessLevel(AccessRecord record)
  {
    Global.m_persistentData.ConvSystemACLRecSet.AddNewRecord(record);
  }

  internal static void RemoveRadioWideAccessLevel(AccessRecord record)
  {
    Global.m_persistentData.RadioWideACLRecSet.Remove(record);
  }

  public static void RemoveSystemWideAccessLevel(AccessRecord record)
  {
    Global.m_persistentData.SystemWideACLRecSet.Remove(record);
  }

  internal static void RemoveConvSysAccessLevel(AccessRecord record)
  {
    Global.m_persistentData.ConvSystemACLRecSet.Remove(record);
  }

  internal static AccessLevelDataRecordSet GetRadioWideAccessLevels()
  {
    return Global.m_persistentData.RadioWideACLRecSet;
  }

  internal static AccessRecord GetRadioWideAccessLevel(int id)
  {
    AccessRecord radioWideAccessLevel = (AccessRecord) null;
    foreach (AccessRecord radioWideAclRec in (Collection<AccessRecord>) Global.m_persistentData.RadioWideACLRecSet)
    {
      if (radioWideAclRec.ID == id)
        radioWideAccessLevel = radioWideAclRec;
    }
    return radioWideAccessLevel;
  }

  public static AccessLevelDataRecordSet GetSysWideAccessLevels()
  {
    return Global.m_persistentData.SystemWideACLRecSet;
  }

  public static AccessRecord GetSysWideAccessLevel(int id)
  {
    AccessRecord sysWideAccessLevel = (AccessRecord) null;
    foreach (AccessRecord systemWideAclRec in (Collection<AccessRecord>) Global.m_persistentData.SystemWideACLRecSet)
    {
      if (systemWideAclRec.ID == id)
        sysWideAccessLevel = systemWideAclRec;
    }
    return sysWideAccessLevel;
  }

  internal static AccessLevelDataRecordSet GetConvSysAccessLevels()
  {
    return Global.m_persistentData.ConvSystemACLRecSet;
  }

  internal static AccessRecord GetConvSysAccessLevels(int id)
  {
    AccessRecord convSysAccessLevels = (AccessRecord) null;
    foreach (AccessRecord convSystemAclRec in (Collection<AccessRecord>) Global.m_persistentData.ConvSystemACLRecSet)
    {
      if (convSystemAclRec.ID == id)
        convSysAccessLevels = convSystemAclRec;
    }
    return convSysAccessLevels;
  }

  internal static void CalculateCheckSum(byte[] pKeysArray, byte[] pDataArray, byte[] pOTAPArray)
  {
    if (pDataArray != null)
    {
      int upperBound = pDataArray.GetUpperBound(0);
      byte crc8 = 0;
      byte crC8 = Global.calculateCRC8(pDataArray, (short) upperBound, crc8);
      pDataArray.SetValue((object) crC8, upperBound);
    }
    if (pKeysArray != null)
    {
      int upperBound = pKeysArray.GetUpperBound(0);
      byte crc8 = 0;
      byte crC8 = Global.calculateCRC8(pKeysArray, (short) upperBound, crc8);
      pKeysArray.SetValue((object) crC8, upperBound);
    }
    if (pOTAPArray == null)
      return;
    int upperBound1 = pOTAPArray.GetUpperBound(0);
    byte crc8_1 = 0;
    byte crC8_1 = Global.calculateCRC8(pOTAPArray, (short) upperBound1, crc8_1);
    pOTAPArray.SetValue((object) crC8_1, upperBound1);
  }

  internal static byte CalculateCheckSum(byte[] byteArray)
  {
    byte crc8 = 0;
    if (byteArray != null)
    {
      int upperBound = byteArray.GetUpperBound(0);
      crc8 = Global.calculateCRC8(byteArray, (short) upperBound, crc8);
    }
    return crc8;
  }

  internal static byte calculateCRC8(byte[] data, short sizeData, byte crc8)
  {
    byte crC8 = 0;
    for (short index = 0; (int) index < (int) sizeData; ++index)
    {
      byte num1 = (byte) ((uint) data[(int) index] ^ (uint) crc8);
      crc8 = num1;
      byte num2 = (byte) ((uint) (byte) ((((int) num1 & 128 /*0x80*/) == 0 ? (uint) (byte) ((uint) num1 >> 1) : (uint) (byte) ((int) num1 >> 1 | 128 /*0x80*/)) >> 1) ^ (uint) crc8);
      byte num3 = num2;
      byte yVal = (byte) ((uint) (byte) ((uint) (byte) ((uint) num2 << 1) & 240U /*0xF0*/) + (uint) (byte) ((((int) num3 & 128 /*0x80*/) == 0 ? (uint) (byte) ((uint) num3 >> 1) : (uint) (byte) ((uint) (byte) ((int) num3 >> 1 | 128 /*0x80*/) ^ (uint) byte.MaxValue)) & 15U));
      byte xVal = (byte) ((uint) crc8 & 7U);
      Global.swap(ref xVal, ref yVal);
      byte num4 = Global.CheckSumTable[(int) yVal];
      crC8 = (byte) ((uint) xVal ^ (uint) num4);
      crc8 = crC8;
    }
    return crC8;
  }

  private static void swap(ref byte xVal, ref byte yVal)
  {
    xVal ^= yVal;
    yVal ^= xVal;
    xVal ^= yVal;
  }

  internal static bool IsDigitOrHexChar(char ch)
  {
    bool flag;
    switch (ch)
    {
      case '0':
      case '1':
      case '2':
      case '3':
      case '4':
      case '5':
      case '6':
      case '7':
      case '8':
      case '9':
      case 'A':
      case 'B':
      case 'C':
      case 'D':
      case 'E':
      case 'F':
      case 'a':
      case 'b':
      case 'c':
      case 'd':
      case 'e':
      case 'f':
        flag = true;
        break;
      default:
        flag = false;
        break;
    }
    return flag;
  }
}
