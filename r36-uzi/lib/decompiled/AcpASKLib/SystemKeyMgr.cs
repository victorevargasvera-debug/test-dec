// Decompiled with JetBrains decompiler
// Type: AcpASKLib.SystemKeyMgr
// Assembly: AcpASKLib, Version=23.1.0.5, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: D65BC533-E9D0-49A5-8218-5CB2B5C70E2D
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpASKLib.dll

using AcpCommonResources;
using AcpKeyValidatorLib;
using AcpUtility;
using IBtnWrapperLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

#nullable disable
namespace AcpASKLib;

public class SystemKeyMgr : ISystemKeyMgr
{
  private ObservableCollection<SpecialKeyData> loadedSpecialKeys;
  private ObservableCollection<SystemKeyData> loadedSystemKeys;
  private MultiBtnWrapper btnWrapper;
  private const int DEFAULTSYSTEMID = 1;
  private AccessRecord accessRecUnLimited;
  private AccessRecord UnlimitedWithoutWriteProtect;
  private LegacySoftwareKey swSysKey;

  public SystemKeyMgr()
  {
    this.loadedSystemKeys = new ObservableCollection<SystemKeyData>();
    this.loadedSpecialKeys = new ObservableCollection<SpecialKeyData>();
    this.btnWrapper = new MultiBtnWrapper();
    this.swSysKey = new LegacySoftwareKey();
    this.accessRecUnLimited = new AccessRecord(AcpResources.Default_Unlimited, "fffffffffffffffffffffffffff7ffffffffffffffffffff", false, (Dictionary<ushort, FieldValueRangeRecSet>) null);
  }

  public int LoadHardwareKeys(HardwareKeyType keyTypeToLoad, Collection<StatusMsg> status)
  {
    int num;
    try
    {
      bool loadedSystemKeys = this.AddDefaultSystemToLoadedSystemKeys();
      KeyRecordSet keyRecordSet = new KeyRecordSet();
      AccessLevelDataRecordSet systemWideAclRecSet = Global.m_persistentData.SystemWideACLRecSet;
      bool bOpen = true;
      bool bISR = true;
      if (keyRecordSet.ReadAlliBtnKeys((IIBtnWrapper) this.btnWrapper, keyTypeToLoad, false, true, systemWideAclRecSet, ref bOpen, ref bISR, ref status))
      {
        foreach (HardwareKey key in (Collection<IKeyRecord>) keyRecordSet.KeyList)
        {
          if (key.IsAdvancedSystemKey)
            this.AddToLoadedSystemKeys(key);
        }
        foreach (AcpiButton specialKey in (Collection<AcpiButton>) keyRecordSet.SpecialKeyList)
          this.AddToLoadedSpecialKeys(specialKey);
        if (((keyRecordSet.KeyList.Count > 0 ? 1 : (keyRecordSet.SpecialKeyList.Count > 0 ? 1 : 0)) | (loadedSystemKeys ? 1 : 0)) != 0)
          this.NotifyKeyLoadedEvent();
        num = keyRecordSet.KeyList.Count + keyRecordSet.SpecialKeyList.Count;
      }
      else
        num = 0;
    }
    catch (AccessViolationException ex)
    {
      throw ex;
    }
    return num;
  }

  public int LoadAllKeys(
    string swKeyDirectory,
    HardwareKeyType keyTypeToLoad,
    bool bLoadSwKeys,
    Collection<StatusMsg> status)
  {
    if (bLoadSwKeys)
      this.LoadAllSwKeyFiles(swKeyDirectory, false, status);
    this.LoadHardwareKeys(keyTypeToLoad, status);
    return this.loadedSystemKeys.Count;
  }

  public bool IsSpecialKeyLoaded()
  {
    bool flag = false;
    if (this.loadedSpecialKeys != null && this.loadedSpecialKeys.Count > 0)
      flag = true;
    return flag;
  }

  public bool CheckIfSpecialKeyIsAttached(HardwareKeyType keyToCheck)
  {
    bool flag1 = false;
    bool flag2 = false;
    AcpKeyValidator acpKeyValidator = new AcpKeyValidator();
    switch (keyToCheck - 1)
    {
      case 0:
        flag1 = acpKeyValidator.IsDepotKeyAttached();
        break;
      case 1:
        flag1 = acpKeyValidator.IsLabtoolKeyAttached(ref flag2);
        break;
      case 3:
        flag1 = acpKeyValidator.IsFTRKeyAttached();
        break;
    }
    return flag1;
  }

  internal bool CheckIfAnySpecialKeyIsAttached()
  {
    bool flag = false;
    AcpKeyValidator acpKeyValidator = new AcpKeyValidator();
    return acpKeyValidator.IsFTRKeyAttached() || acpKeyValidator.IsDepotKeyAttached() || acpKeyValidator.IsLabtoolKeyAttached(ref flag);
  }

  public bool IsFieldEditable(AccessElementIDType id, KeyType type, int sysId, bool bAskOnly)
  {
    return this.IsAccessElementEnabled(id, type, sysId, bAskOnly);
  }

  internal bool IsOperationEnabled(AccessElementIDType id, KeyType type, int sysId, bool bAskOnly)
  {
    return this.IsAccessElementEnabled(id, type, sysId, bAskOnly);
  }

  private bool IsAccessElementEnabled(
    AccessElementIDType id,
    KeyType type,
    int sysId,
    bool bAskOnly)
  {
    bool flag1 = false;
    bool flag2 = false;
    foreach (SystemKeyData loadedSystemKey in (Collection<SystemKeyData>) this.loadedSystemKeys)
    {
      if (bAskOnly)
      {
        if (loadedSystemKey.SystemID == sysId && loadedSystemKey.Type == type && loadedSystemKey.Source == KeySource.HARDWARE)
          flag2 = true;
      }
      else if (loadedSystemKey.SystemID == sysId && loadedSystemKey.Type == type)
        flag2 = true;
      if (flag2)
      {
        AccessRecord accessLevel = loadedSystemKey.AccessLevel;
        if (accessLevel != null)
        {
          flag1 = accessLevel.IsAccessElementEnabled(id);
          break;
        }
        break;
      }
    }
    return flag1;
  }

  public bool IsRangeValueValid(
    AccessElementIDType id,
    KeyType type,
    int sysId,
    int value,
    bool bAskOnly)
  {
    bool flag1 = false;
    bool flag2 = false;
    foreach (SystemKeyData loadedSystemKey in (Collection<SystemKeyData>) this.loadedSystemKeys)
    {
      if (bAskOnly)
      {
        if (loadedSystemKey.SystemID == sysId && loadedSystemKey.Type == type && loadedSystemKey.Source == KeySource.HARDWARE)
          flag2 = true;
      }
      else if (loadedSystemKey.SystemID == sysId && loadedSystemKey.Type == type)
        flag2 = true;
      if (flag2)
      {
        AccessRecord accessLevel = loadedSystemKey.AccessLevel;
        if (accessLevel != null)
        {
          flag1 = accessLevel.IsRangeValueValid(id, value);
          break;
        }
        break;
      }
    }
    return flag1;
  }

  public bool IsRangeField(AccessElementIDType id)
  {
    bool flag = false;
    if (FeatureSchemaManager.GetAccessElement(id) is AccessRangeField)
      flag = true;
    return flag;
  }

  internal bool IsWriteProtected()
  {
    bool flag = false;
    foreach (SystemKeyData loadedSystemKey in (Collection<SystemKeyData>) this.loadedSystemKeys)
    {
      if (loadedSystemKey.WriteProtectEnabled)
      {
        flag = true;
        break;
      }
    }
    return flag;
  }

  internal bool IsCloningEnabled()
  {
    bool flag = false;
    foreach (SystemKeyData loadedSystemKey in (Collection<SystemKeyData>) this.loadedSystemKeys)
    {
      AccessRecord accessLevel = loadedSystemKey.AccessLevel;
      if (accessLevel != null && accessLevel.IsCloningEnabled())
      {
        flag = true;
        break;
      }
    }
    return flag;
  }

  public AccessRecord GetSystemAccessLevel(int sysId, KeyType uKeyTpe)
  {
    AccessRecord systemAccessLevel = (AccessRecord) null;
    foreach (SystemKeyData loadedSystemKey in (Collection<SystemKeyData>) this.loadedSystemKeys)
    {
      if (loadedSystemKey.SystemID == sysId && loadedSystemKey.Type == uKeyTpe)
      {
        systemAccessLevel = loadedSystemKey.AccessLevel;
        break;
      }
    }
    return systemAccessLevel;
  }

  public bool IsSystemKeyLoaded(int sysId, byte uKeyTpe, bool bAskOnly)
  {
    bool flag = false;
    foreach (SystemKeyData loadedSystemKey in (Collection<SystemKeyData>) this.loadedSystemKeys)
    {
      if (bAskOnly)
      {
        if (loadedSystemKey.SystemID == sysId && loadedSystemKey.Type == (KeyType) uKeyTpe && loadedSystemKey.Source == KeySource.HARDWARE)
        {
          flag = true;
          break;
        }
      }
      else if (loadedSystemKey.SystemID == sysId && loadedSystemKey.Type == (KeyType) uKeyTpe)
      {
        flag = true;
        break;
      }
    }
    return flag;
  }

  public bool IsUnLimitedASKLoaded(int sysId, byte uKeyTpe, bool bSearchWriteProtectOnly)
  {
    bool flag = false;
    foreach (SystemKeyData loadedSystemKey in (Collection<SystemKeyData>) this.loadedSystemKeys)
    {
      if (bSearchWriteProtectOnly)
      {
        if (loadedSystemKey.SystemID == sysId && loadedSystemKey.Type == (KeyType) uKeyTpe && loadedSystemKey.Source == KeySource.HARDWARE && loadedSystemKey.AccessLevelType == KeyAccessLevelType.UNLM_ACC)
        {
          flag = true;
          break;
        }
      }
      else if (loadedSystemKey.SystemID == sysId && loadedSystemKey.Type == (KeyType) uKeyTpe && loadedSystemKey.Source == KeySource.HARDWARE && (loadedSystemKey.AccessLevelType == KeyAccessLevelType.UNLM_ACC || loadedSystemKey.AccessLevelType == KeyAccessLevelType.UNLM_ACC_WITHOUT_WP))
      {
        flag = true;
        break;
      }
    }
    return flag;
  }

  public bool IsASKAttachedForGivenSysIdAndType(int dwSystemId, byte uKeyType)
  {
    bool flag = false;
    KeyRecordSet keyRecordSet = new KeyRecordSet();
    MultiBtnWrapper spIBtn = new MultiBtnWrapper();
    AccessLevelDataRecordSet systemWideAclRecSet = Global.m_persistentData.SystemWideACLRecSet;
    bool bOpen = true;
    bool bISR = true;
    Collection<StatusMsg> status = new Collection<StatusMsg>();
    keyRecordSet.ReadAlliBtnKeys((IIBtnWrapper) spIBtn, (HardwareKeyType) 12, false, true, systemWideAclRecSet, ref bOpen, ref bISR, ref status);
    foreach (HardwareKey key in (Collection<IKeyRecord>) keyRecordSet.KeyList)
    {
      foreach (IKeyDataRecord keyData in (Collection<IKeyDataRecord>) key.KeyDataList)
      {
        if (keyData.SystemID == dwSystemId && (int) keyData.KeyType == (int) uKeyType)
        {
          flag = true;
          break;
        }
      }
      if (flag)
        break;
    }
    return flag;
  }

  public Collection<SystemKeyData> GetSysKeysFromAttachedASKs(bool bValidatePassword)
  {
    Collection<SystemKeyData> fromAttachedAsKs = (Collection<SystemKeyData>) null;
    KeyRecordSet keyRecordSet = new KeyRecordSet();
    MultiBtnWrapper spIBtn = new MultiBtnWrapper();
    AccessLevelDataRecordSet systemWideAclRecSet = Global.m_persistentData.SystemWideACLRecSet;
    bool bOpen = true;
    bool bISR = true;
    Collection<StatusMsg> status = new Collection<StatusMsg>();
    keyRecordSet.ReadAlliBtnKeys((IIBtnWrapper) spIBtn, (HardwareKeyType) 12, false, bValidatePassword, systemWideAclRecSet, ref bOpen, ref bISR, ref status);
    foreach (HardwareKey key in (Collection<IKeyRecord>) keyRecordSet.KeyList)
    {
      foreach (IKeyDataRecord keyData in (Collection<IKeyDataRecord>) key.KeyDataList)
      {
        if (fromAttachedAsKs == null)
          fromAttachedAsKs = new Collection<SystemKeyData>();
        KeyDataRecord keyDataRecord = (KeyDataRecord) keyData;
        bool bWriteProtected = false;
        bool otapEnabled = false;
        if (keyDataRecord.AccessLevel != null)
        {
          bWriteProtected = keyDataRecord.AccessLevel.IsWriteProtected();
          otapEnabled = keyDataRecord.AccessLevel.OPTAPState;
        }
        SystemKeyData systemKeyData = new SystemKeyData(KeySource.HARDWARE, key.SerialNumber, keyDataRecord.SystemID, (KeyType) keyDataRecord.KeyType, otapEnabled, bWriteProtected, keyDataRecord.AccessLevel);
        fromAttachedAsKs.Add(systemKeyData);
      }
    }
    return fromAttachedAsKs;
  }

  private bool AddDefaultSystemToLoadedSystemKeys()
  {
    bool loadedSystemKeys = false;
    bool flag = false;
    foreach (SystemKeyData loadedSystemKey in (Collection<SystemKeyData>) this.loadedSystemKeys)
    {
      if (loadedSystemKey.SystemID == 1 && loadedSystemKey.Type == KeyType.ADVANCED_SYSTEM_KEY)
      {
        flag = true;
        break;
      }
    }
    if (!flag)
    {
      this.loadedSystemKeys.Add(new SystemKeyData(KeySource.HARDWARE, AcpResources.None_Id, 1, KeyType.ADVANCED_SYSTEM_KEY, false, false, this.accessRecUnLimited));
      loadedSystemKeys = true;
    }
    return loadedSystemKeys;
  }

  private void AddToLoadedSystemKeys(HardwareKey hkey)
  {
    foreach (KeyDataRecord keyData in (Collection<IKeyDataRecord>) hkey.KeyDataList)
    {
      bool bWriteProtected = false;
      bool otapEnabled = false;
      if (keyData.AccessLevel != null)
      {
        bWriteProtected = keyData.AccessLevel.IsWriteProtected();
        otapEnabled = keyData.AccessLevel.OPTAPState;
      }
      SystemKeyData systemKeyData1 = new SystemKeyData(KeySource.HARDWARE, hkey.SerialNumber, keyData.SystemID, (KeyType) keyData.KeyType, otapEnabled, bWriteProtected, keyData.AccessLevel);
      Collection<SystemKeyData> collection = new Collection<SystemKeyData>();
      foreach (SystemKeyData loadedSystemKey in (Collection<SystemKeyData>) this.loadedSystemKeys)
      {
        if (loadedSystemKey.SystemID == systemKeyData1.SystemID && loadedSystemKey.Type == systemKeyData1.Type)
          collection.Add(loadedSystemKey);
      }
      foreach (SystemKeyData systemKeyData2 in collection)
        this.loadedSystemKeys.Remove(systemKeyData2);
      this.loadedSystemKeys.Add(systemKeyData1);
    }
  }

  private void AddToLoadedSpecialKeys(AcpiButton specKey)
  {
    SpecialKeyData specialKeyData1 = new SpecialKeyData(specKey.SerialNumber, specKey.KeyType);
    Collection<SpecialKeyData> collection = new Collection<SpecialKeyData>();
    foreach (SpecialKeyData loadedSpecialKey in (Collection<SpecialKeyData>) this.loadedSpecialKeys)
    {
      if (loadedSpecialKey.iBtnSerialNum == specKey.SerialNumber)
        collection.Add(loadedSpecialKey);
    }
    foreach (SpecialKeyData specialKeyData2 in collection)
      this.loadedSpecialKeys.Remove(specialKeyData2);
    this.loadedSpecialKeys.Add(specialKeyData1);
  }

  internal int LoadAllSwKeyFiles(
    string sDirectoryPath,
    bool bSendNotification,
    Collection<StatusMsg> status)
  {
    int num = 0;
    try
    {
      if (Directory.Exists(sDirectoryPath))
      {
        string strB = "*.key".Substring(1).Trim();
        foreach (FileInfo file in new DirectoryInfo(sDirectoryPath).GetFiles("*.key"))
        {
          if (string.Compare(file.Extension, strB, true) == 0 && this.LoadASystemKey(file.FullName, status))
            ++num;
        }
      }
      else
        status.Add(new StatusMsg(AskStatusType.Warning, AcpResources.System_Key_Files_Not_Loaded.AcpStringFormat((object) sDirectoryPath), 3758129160U /*0xE0008008*/));
    }
    catch (Exception ex)
    {
      status.Add(new StatusMsg(AskStatusType.Error, AcpResources.Error_Loading_Software + ex.Message, 3758129160U /*0xE0008008*/));
    }
    finally
    {
      if (bSendNotification && num > 0)
        this.NotifyKeyLoadedEvent();
    }
    return num;
  }

  public int LoadSelectedSwKeyFiles(string[] selectedFileNames, Collection<StatusMsg> status)
  {
    int num = 0;
    foreach (string selectedFileName in selectedFileNames)
    {
      if (this.LoadASystemKey(selectedFileName, status))
        ++num;
    }
    if (num > 0)
      this.NotifyKeyLoadedEvent();
    return num;
  }

  private bool LoadASystemKey(string path, Collection<StatusMsg> status)
  {
    bool flag = false;
    if (File.Exists(path))
    {
      int id = this.swSysKey.readASystemKey(path, status);
      if (id > 0)
      {
        SystemKeyData systemKeyData = (SystemKeyData) null;
        foreach (SystemKeyData loadedSystemKey in (Collection<SystemKeyData>) this.loadedSystemKeys)
        {
          if (loadedSystemKey.SystemID == id && loadedSystemKey.Type == KeyType.ADVANCED_SYSTEM_KEY)
          {
            systemKeyData = loadedSystemKey;
            break;
          }
        }
        if (systemKeyData != null)
          this.loadedSystemKeys.Remove(systemKeyData);
        this.loadedSystemKeys.Add(new SystemKeyData(KeySource.LEGACY_KEY_FILE, AcpResources.None_Id, id, KeyType.ADVANCED_SYSTEM_KEY, false, false, this.accessRecUnLimited));
        flag = true;
      }
    }
    return flag;
  }

  private void NotifyKeyLoadedEvent()
  {
    if ((this.loadedSystemKeys == null || this.loadedSystemKeys.Count <= 0) && this.loadedSpecialKeys.Count <= 0 || this.SystemKeyLoadedEvent == null)
      return;
    this.SystemKeyLoadedEvent((object) this, new SystemKeyLoadedEventArgs(this.loadedSystemKeys, this.loadedSpecialKeys));
  }

  public ObservableCollection<SystemKeyData> LoadedUserSystemKeys => this.loadedSystemKeys;

  public ObservableCollection<SystemKeyData> LoadedASKs
  {
    get
    {
      ObservableCollection<SystemKeyData> loadedAsKs = new ObservableCollection<SystemKeyData>();
      foreach (SystemKeyData loadedSystemKey in (Collection<SystemKeyData>) this.loadedSystemKeys)
      {
        if (loadedSystemKey.Source == KeySource.HARDWARE)
          loadedAsKs.Add(loadedSystemKey);
      }
      return loadedAsKs;
    }
  }

  public ObservableCollection<SpecialKeyData> LoadedSpecialKeys => this.loadedSpecialKeys;

  public event SystemKeyLoadedEventHandler SystemKeyLoadedEvent;
}
