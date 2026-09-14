// Decompiled with JetBrains decompiler
// Type: AcpSecurityLib.SecurityManager
// Assembly: AcpSecurityLib, Version=23.1.0.23, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 41EFF54A-68D7-40EA-A234-214D6B602874
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpSecurityLib.dll

using AcpASKLib;
using AcpBusinessLayer;
using AcpCommonLib;
using AcpKeyValidatorLib;
using AcpUtility;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;

#nullable disable
namespace AcpSecurityLib;

public static class SecurityManager
{
  internal static SystemKeyMgr AskMgr = (SystemKeyMgr) null;
  public static BooleanSwitch SecurityEnabled = new BooleanSwitch(nameof (SecurityEnabled), "Indicates whether or not ASK security is enabled", "false");
  private static bool isSpecialKeyLoaded = false;

  public static event SystemKeyLoadedEventHandler SystemKeyLoadedEvent;

  static SecurityManager()
  {
    AssemblyValidator.IsCallerAuthorized();
    TrunkingSystemData.SystemKeyManager = (ISystemKeyMgr) (SecurityManager.AskMgr = new SystemKeyMgr());
    SecurityManager.AskMgr.SystemKeyLoadedEvent += new SystemKeyLoadedEventHandler(SecurityManager.OnSystemKeyLoaded);
  }

  public static int LoadAllKeys(string swKeyDirectory, bool bSupressMessage)
  {
    Collection<StatusMsg> status = new Collection<StatusMsg>();
    bool bLoadSwKeys = true;
    HardwareKeyType keyTypeToLoad = (HardwareKeyType) 8;
    switch (AppInfoManager.AppType)
    {
      case ApplicationType.CPS:
        keyTypeToLoad = (HardwareKeyType) 12;
        break;
      case ApplicationType.LABTOOL:
        keyTypeToLoad = (HardwareKeyType) 12;
        break;
      case ApplicationType.DEPOT:
        keyTypeToLoad = (HardwareKeyType) 1;
        bLoadSwKeys = false;
        break;
      default:
        status.Add(new StatusMsg(AskStatusType.Error, "Error Loading iButtons - Unsupported Application", 1610645507U /*0x60008003*/));
        break;
    }
    int num = SecurityManager.AskMgr.LoadAllKeys(swKeyDirectory, keyTypeToLoad, bLoadSwKeys, status);
    if (!bSupressMessage)
    {
      foreach (StatusMsg statusMsg in status)
      {
        if (!statusMsg.Message.Contains("Non-Motorola iButton contains unauthorized file."))
        {
          StatusMsgType type;
          switch (statusMsg.Type)
          {
            case AskStatusType.Error:
              type = StatusMsgType.Error;
              break;
            case AskStatusType.Warning:
              type = StatusMsgType.Warning;
              break;
            case AskStatusType.Info:
              type = StatusMsgType.Info;
              break;
            default:
              type = StatusMsgType.Error;
              break;
          }
          AppInfoManager.StatusMsgReport.RegisterMessage(type, statusMsg.Message);
        }
      }
    }
    return num;
  }

  public static int LoadAllAttachedKeys(bool bSupressMessage)
  {
    int num = 0;
    Collection<StatusMsg> status = new Collection<StatusMsg>();
    try
    {
      switch (AppInfoManager.AppType)
      {
        case ApplicationType.CPS:
          num = SecurityManager.AskMgr.LoadHardwareKeys((HardwareKeyType) 12, status);
          break;
        case ApplicationType.LABTOOL:
          num = SecurityManager.AskMgr.LoadHardwareKeys((HardwareKeyType) 12, status);
          break;
        case ApplicationType.DEPOT:
          num = SecurityManager.AskMgr.LoadHardwareKeys((HardwareKeyType) 1, status);
          break;
        default:
          status.Add(new StatusMsg(AskStatusType.Error, "Error Loading iButtons - Unsupported Application", 1610645507U /*0x60008003*/));
          break;
      }
    }
    catch (AccessViolationException ex)
    {
      throw ex;
    }
    if (!bSupressMessage)
    {
      foreach (StatusMsg statusMsg in status)
      {
        StatusMsgType type;
        switch (statusMsg.Type)
        {
          case AskStatusType.Error:
            type = StatusMsgType.Error;
            break;
          case AskStatusType.Warning:
            type = StatusMsgType.Warning;
            break;
          case AskStatusType.Info:
            type = StatusMsgType.Info;
            break;
          default:
            type = StatusMsgType.Error;
            break;
        }
        AppInfoManager.StatusMsgReport.RegisterMessage(type, statusMsg.Message);
      }
    }
    return num;
  }

  public static int LoadSelectedSwKeyFiles(string[] selectedFileNames, bool bSupressMessage)
  {
    Collection<StatusMsg> status = new Collection<StatusMsg>();
    int num = SecurityManager.AskMgr.LoadSelectedSwKeyFiles(selectedFileNames, status);
    if (!bSupressMessage)
    {
      foreach (StatusMsg statusMsg in status)
      {
        StatusMsgType type;
        switch (statusMsg.Type)
        {
          case AskStatusType.Error:
            type = StatusMsgType.Error;
            break;
          case AskStatusType.Warning:
            type = StatusMsgType.Warning;
            break;
          case AskStatusType.Info:
            type = StatusMsgType.Info;
            break;
          default:
            type = StatusMsgType.Error;
            break;
        }
        AppInfoManager.StatusMsgReport.RegisterMessage(type, statusMsg.Message);
      }
    }
    return num;
  }

  private static void OnSystemKeyLoaded(object sender, SystemKeyLoadedEventArgs e)
  {
    SecurityManager.isSpecialKeyLoaded = SecurityManager.AskMgr.IsSpecialKeyLoaded();
    if (SecurityManager.SystemKeyLoadedEvent == null)
      return;
    SecurityManager.SystemKeyLoadedEvent(sender, e);
  }

  public static bool IsSystemKeyLoaded(int dwSystemId, byte uKeyType, bool bAskOnly)
  {
    return SecurityManager.AskMgr.IsSystemKeyLoaded(dwSystemId, uKeyType, bAskOnly);
  }

  public static bool IsASKAttachedForGivenSysIdAndType(int dwSystemId, byte uKeyType)
  {
    return SecurityManager.AskMgr.IsASKAttachedForGivenSysIdAndType(dwSystemId, uKeyType);
  }

  public static Collection<SystemKeyData> GetSysKeysFromAttachedASKs()
  {
    return SecurityManager.AskMgr.GetSysKeysFromAttachedASKs(true);
  }

  public static Collection<SystemKeyData> GetSysKeysFromLoadedAndAttachedASKs()
  {
    Collection<SystemKeyData> loadedAndAttachedAsKs = (Collection<SystemKeyData>) null;
    Collection<SystemKeyData> fromAttachedAsKs = SecurityManager.AskMgr.GetSysKeysFromAttachedASKs(false);
    if (fromAttachedAsKs != null && SecurityManager.LoadedASKs != null)
    {
      foreach (SystemKeyData systemKeyData in fromAttachedAsKs)
      {
        foreach (SystemKeyData loadedAsK in (Collection<SystemKeyData>) SecurityManager.LoadedASKs)
        {
          if (systemKeyData.iBtnSerialNum == loadedAsK.iBtnSerialNum && systemKeyData.SystemID == loadedAsK.SystemID)
          {
            if (loadedAndAttachedAsKs == null)
              loadedAndAttachedAsKs = new Collection<SystemKeyData>();
            loadedAndAttachedAsKs.Add(systemKeyData);
          }
        }
      }
    }
    return loadedAndAttachedAsKs;
  }

  public static ObservableCollection<SystemKeyData> LoadedUserSystemKeys
  {
    get => SecurityManager.AskMgr.LoadedUserSystemKeys;
  }

  public static ObservableCollection<SystemKeyData> LoadedASKs => SecurityManager.AskMgr.LoadedASKs;

  public static ObservableCollection<SpecialKeyData> LoadedSpecialKeys
  {
    get => SecurityManager.AskMgr.LoadedSpecialKeys;
  }

  public static bool IsFieldEditable(
    AccessElementIDType id,
    KeyType type,
    int sysId,
    bool bAskOnly)
  {
    return SecurityManager.AskMgr.IsFieldEditable(id, type, sysId, bAskOnly);
  }

  public static bool IsRangeValueValid(
    AccessElementIDType id,
    KeyType type,
    int sysId,
    int value,
    bool bAskOnly)
  {
    return SecurityManager.AskMgr.IsRangeValueValid(id, type, sysId, value, bAskOnly);
  }

  public static bool IsRangeField(AccessElementIDType id)
  {
    return SecurityManager.AskMgr.IsRangeField(id);
  }

  public static bool IsUnLimitedASKLoaded(int sysId, KeyType type, bool bSearchWriteProtectOnly)
  {
    return SecurityManager.AskMgr.IsUnLimitedASKLoaded(sysId, (byte) type, bSearchWriteProtectOnly);
  }

  public static AccessRecord GetSystemAccessLevel(int sysId, KeyType uKeyTpe)
  {
    return SecurityManager.AskMgr.GetSystemAccessLevel(sysId, uKeyTpe);
  }

  public static bool IsSpecialKeyLoaded => SecurityManager.isSpecialKeyLoaded;

  public static bool CheckIfSpecialKeyIsAttached()
  {
    bool flag = false;
    switch (AppInfoManager.AppType)
    {
      case ApplicationType.CPS:
        flag = SecurityManager.AskMgr.CheckIfSpecialKeyIsAttached((HardwareKeyType) 4);
        break;
      case ApplicationType.LABTOOL:
        flag = SecurityManager.AskMgr.CheckIfSpecialKeyIsAttached((HardwareKeyType) 4);
        break;
      case ApplicationType.DEPOT:
        flag = SecurityManager.AskMgr.CheckIfSpecialKeyIsAttached((HardwareKeyType) 1);
        break;
    }
    return flag;
  }
}
