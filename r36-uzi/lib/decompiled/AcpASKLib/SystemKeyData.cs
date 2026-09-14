// Decompiled with JetBrains decompiler
// Type: AcpASKLib.SystemKeyData
// Assembly: AcpASKLib, Version=23.1.0.5, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: D65BC533-E9D0-49A5-8218-5CB2B5C70E2D
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpASKLib.dll

using System;

#nullable disable
namespace AcpASKLib;

public class SystemKeyData
{
  private string ibtnSerialNum;
  private int sysID;
  private bool bOtapEnabled;
  private bool bWriteProtectEnabled;
  private KeyType uKeyType;
  private AccessRecord accessLvl;
  private KeySource sysKeySrc;

  public SystemKeyData(
    KeySource src,
    string serialNum,
    int id,
    KeyType type,
    bool otapEnabled,
    bool bWriteProtected,
    AccessRecord aclvl)
  {
    this.ibtnSerialNum = serialNum;
    this.sysID = id;
    this.bOtapEnabled = otapEnabled;
    this.bWriteProtectEnabled = bWriteProtected;
    this.uKeyType = type;
    this.accessLvl = aclvl;
    this.sysKeySrc = src;
  }

  public int SystemID => this.sysID;

  public KeyType Type => this.uKeyType;

  public bool OtapEnabled => this.bOtapEnabled;

  public bool WriteProtectEnabled => this.bWriteProtectEnabled;

  public string iBtnSerialNum => this.ibtnSerialNum;

  public AccessRecord AccessLevel => this.accessLvl;

  public KeyAccessLevelType AccessLevelType
  {
    get
    {
      if (this.sysKeySrc == KeySource.LEGACY_KEY_FILE)
        return KeyAccessLevelType.UNLM_ACC;
      return this.AccessLevel != null ? this.AccessLevel.GetKeyAccessLevelType() : throw new Exception("Could not retrieve AccessLevelType! AccessLevel not defined for this System Key");
    }
  }

  public KeySource Source => this.sysKeySrc;

  public string SystemIDHex => this.sysID.ToString("X");
}
