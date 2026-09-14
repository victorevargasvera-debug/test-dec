// Decompiled with JetBrains decompiler
// Type: AcpASKLib.KeyDataRecord
// Assembly: AcpASKLib, Version=23.1.0.5, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: D65BC533-E9D0-49A5-8218-5CB2B5C70E2D
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpASKLib.dll

using System;

#nullable disable
namespace AcpASKLib;

[Serializable]
public class KeyDataRecord : IKeyDataRecord
{
  private byte m_keyType;
  private int id;
  private bool bOTAPState;
  private bool bEditable;
  private bool bSeleceted;
  private byte uForiegnKey;
  private AccessRecord m_Accesslevel;
  private byte[] m_packedData;

  internal KeyDataRecord(byte uKeyType, int sysID, AccessRecord acclvl)
  {
    this.m_keyType = uKeyType;
    this.id = sysID;
    this.m_Accesslevel = acclvl;
    if (acclvl != null)
      this.uForiegnKey = (byte) acclvl.ID;
    this.m_packedData = new byte[5];
  }

  internal KeyDataRecord(byte uKeyType, int sysID, byte uFKey)
  {
    this.m_keyType = uKeyType;
    this.id = sysID;
    this.m_Accesslevel = (AccessRecord) null;
    this.uForiegnKey = uFKey;
    this.m_packedData = new byte[5];
  }

  internal KeyDataRecord(byte keyType, byte[] sys_id, byte uFkey, bool bOTAP)
  {
    this.m_keyType = keyType;
    this.uForiegnKey = uFkey;
    this.bOTAPState = bOTAP;
    this.m_Accesslevel = (AccessRecord) null;
  }

  internal static int GetAccessLevelType(byte[] pResult)
  {
    int accessLevelType = 1;
    for (int index = 0; index < pResult.Length; ++index)
    {
      if (index != 10)
      {
        if (index == 3 && pResult[index] != (byte) 239 && pResult[index] != byte.MaxValue)
        {
          accessLevelType = 0;
          break;
        }
        if (index != 3 && pResult[index] != byte.MaxValue)
        {
          accessLevelType = 0;
          break;
        }
      }
    }
    if (accessLevelType != 0)
      accessLevelType = pResult[10] != (byte) 247 ? (pResult[10] != byte.MaxValue ? 0 : 1) : 2;
    return accessLevelType;
  }

  private void Pack()
  {
    int num1 = 0;
    byte num2 = (byte) ((uint) (byte) (this.id >> 16 /*0x10*/) | (uint) (byte) ((uint) this.m_keyType << 4));
    byte[] packedData1 = this.m_packedData;
    int index1 = num1;
    int num3 = index1 + 1;
    int num4 = (int) num2;
    packedData1[index1] = (byte) num4;
    byte num5 = (byte) (this.id >> 8);
    byte[] packedData2 = this.m_packedData;
    int index2 = num3;
    int num6 = index2 + 1;
    int num7 = (int) num5;
    packedData2[index2] = (byte) num7;
    byte id1 = (byte) this.id;
    byte[] packedData3 = this.m_packedData;
    int index3 = num6;
    int num8 = index3 + 1;
    int num9 = (int) id1;
    packedData3[index3] = (byte) num9;
    byte id2 = (byte) this.m_Accesslevel.ID;
    byte[] packedData4 = this.m_packedData;
    int index4 = num8;
    int num10 = index4 + 1;
    int num11 = (int) id2;
    packedData4[index4] = (byte) num11;
    Global.CalculateCheckSum(this.m_packedData, (byte[]) null, (byte[]) null);
  }

  public byte KeyType
  {
    get => this.m_keyType;
    set => this.m_keyType = value;
  }

  public int SystemID
  {
    get => this.id;
    set => this.id = value;
  }

  internal byte ForiegnKey
  {
    get => this.uForiegnKey;
    set => this.uForiegnKey = value;
  }

  internal bool OTAPState
  {
    get => this.bOTAPState;
    set => this.bOTAPState = value;
  }

  public bool Editable
  {
    get => this.bEditable;
    set => this.bEditable = value;
  }

  public bool IsSelected
  {
    get => this.bSeleceted;
    set => this.bSeleceted = value;
  }

  public AccessRecord AccessLevel
  {
    get => this.m_Accesslevel;
    set => this.m_Accesslevel = value;
  }
}
