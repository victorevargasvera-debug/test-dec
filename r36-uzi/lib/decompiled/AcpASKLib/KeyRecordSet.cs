// Decompiled with JetBrains decompiler
// Type: AcpASKLib.KeyRecordSet
// Assembly: AcpASKLib, Version=23.1.0.5, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: D65BC533-E9D0-49A5-8218-5CB2B5C70E2D
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpASKLib.dll

using AcpCommonResources;
using AcpKeyValidatorLib;
using AcpUtility;
using IBtnWrapperLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

#nullable disable
namespace AcpASKLib;

public class KeyRecordSet
{
  private static ArrayList arrExpiredSerialNumList = new ArrayList();
  private static Dictionary<string, DateTime> lockedOutKeyList = new Dictionary<string, DateTime>();
  private static Dictionary<string, string> passwdValidatedKeyList = new Dictionary<string, string>();
  private ObservableCollection<IKeyRecord> keyList;
  private ObservableCollection<AcpiButton> specKeyList;

  public KeyRecordSet()
  {
    this.keyList = new ObservableCollection<IKeyRecord>();
    this.specKeyList = new ObservableCollection<AcpiButton>();
    if (KeyRecordSet.arrExpiredSerialNumList != null)
      return;
    KeyRecordSet.arrExpiredSerialNumList = new ArrayList();
  }

  internal bool IsAllKeysFullRestriction(AccessLevelDataRecordSet AccessRecSet) => false;

  internal bool ReadAlliBtnKeys(
    IIBtnWrapper spIBtn,
    HardwareKeyType keyTypeToLoad,
    bool bReadMasterKeys,
    bool bValidatePassword,
    AccessLevelDataRecordSet pRsAccess,
    ref bool bOpen,
    ref bool bISR,
    ref Collection<StatusMsg> status)
  {
    bool flag1 = false;
    bool bAddAccessLevel = true;
    bool bASKCalling = false;
    short num1 = 6;
    MultiBtnWrapper btnWrapper = (MultiBtnWrapper) spIBtn;
    HardwareKey hardwareKey1 = new HardwareKey();
    bool flag2 = false;
    for (short index1 = 2; (int) index1 <= (int) num1; index1 += (short) 4)
    {
      if (!flag2)
      {
        try
        {
          ((IBtnWrapperBase) btnWrapper).PortType = index1;
          btnWrapper.CreateButton();
          short num2 = 1;
          if (((IBtnWrapperBase) btnWrapper).PortType == (short) 6)
            num2 = (short) 2;
          for (short index2 = num2; index2 <= (short) 15; ++index2)
          {
            if (!flag2)
            {
              ((IBtnWrapperBase) btnWrapper).PortNumber = index2;
              bool flag3 = btnWrapper.FindFirstBtn((short) byte.MaxValue);
              if (flag3)
              {
                do
                {
                  try
                  {
                    AcpiButton key1 = (AcpiButton) null;
                    if (!this.IsSpecialHwKey((IIBtnWrapper) btnWrapper, out key1))
                    {
                      if ((keyTypeToLoad & 8) != null)
                      {
                        StatusMsg statusMsg = (StatusMsg) null;
                        IKeyRecord keyRecord = (IKeyRecord) new HardwareKey();
                        flag3 = ((HardwareKey) keyRecord).ReadiBtnKey((IIBtnWrapper) btnWrapper, bReadMasterKeys, bValidatePassword, pRsAccess, ref bOpen, ref bISR, out statusMsg, bASKCalling, bAddAccessLevel);
                        if (flag3)
                        {
                          HardwareKey hKey = (HardwareKey) keyRecord;
                          if (hKey.HighWaterMarkSupported(ref hKey, ref btnWrapper))
                          {
                            flag3 = hKey.HighWaterMarkValidation(hKey.LastDateProgrammed);
                            if (!flag3)
                            {
                              hKey.EraseData(ref btnWrapper);
                              string message = AcpResources.HighWaterMark_Security_Violation.AcpStringFormat((object) hKey.SerialNumber);
                              status.Add(new StatusMsg(AskStatusType.Error, message, 3758129166U /*0xE000800E*/));
                            }
                            else if (hKey.Version == (short) 5)
                            {
                              string empty = string.Empty;
                              if (hKey.GetPswdFromIBtn((IIBtnWrapper) btnWrapper, ref empty) == 0U)
                                hKey.WriteMASKToIBtn((IIBtnWrapper) btnWrapper, empty, hKey.ExpirationType, hKey.DaysToExpiration, (short) 0, ref bOpen);
                              else
                                flag3 = false;
                            }
                            else
                              flag3 = hKey.WriteiBtnKey((IIBtnWrapper) btnWrapper, ref bOpen, false, 1, OpenMode.IBTN_OPEN_WRITE, pRsAccess, out statusMsg);
                          }
                        }
                        if (flag3)
                        {
                          bool flag4 = false;
                          HardwareKey hardwareKey2 = (HardwareKey) null;
                          foreach (HardwareKey key2 in (Collection<IKeyRecord>) this.keyList)
                          {
                            if (key2.SerialNumber == ((HardwareKey) keyRecord).SerialNumber)
                            {
                              hardwareKey2 = key2;
                              flag4 = true;
                            }
                          }
                          if (flag4)
                            this.keyList.Remove((IKeyRecord) hardwareKey2);
                          this.keyList.Add(keyRecord);
                          flag1 = true;
                        }
                        if (statusMsg != null)
                          status.Add(statusMsg);
                      }
                      else if (status != null)
                        status.Add(new StatusMsg(AskStatusType.Error, AcpResources.iButton_Invalid, 3758129160U /*0xE0008008*/));
                    }
                    else if ((keyTypeToLoad & key1.KeyType) != null)
                    {
                      AcpiButton acpiButton = (AcpiButton) null;
                      bool flag5 = false;
                      foreach (AcpiButton specKey in (Collection<AcpiButton>) this.specKeyList)
                      {
                        if (specKey.SerialNumber == key1.SerialNumber)
                        {
                          acpiButton = specKey;
                          flag5 = true;
                          break;
                        }
                      }
                      if (flag5)
                        this.specKeyList.Remove(acpiButton);
                      this.specKeyList.Add(key1);
                      flag1 = true;
                    }
                    else if (status != null)
                      status.Add(new StatusMsg(AskStatusType.Error, AcpResources.iButton_Invalid, 3758129160U /*0xE0008008*/));
                  }
                  catch (Exception ex)
                  {
                    if (ex.Data != null)
                    {
                      switch ((uint) ex.Data[(object) "ErrorCode"])
                      {
                        case 2684387329 /*0xA0008001*/:
                        case 2684387332 /*0xA0008004*/:
                          flag2 = true;
                          break;
                      }
                    }
                  }
                  if (!flag2)
                    flag3 = btnWrapper.FindNextBtn();
                }
                while (flag3 && !flag2);
              }
            }
            else
              break;
          }
        }
        catch (AccessViolationException ex)
        {
          StatusMsg statusMsg = new StatusMsg(AskStatusType.Error, "Read iButton error: " + ex.Message, 1610645507U /*0x60008003*/);
          throw ex;
        }
        catch (Exception ex)
        {
          StatusMsg statusMsg = new StatusMsg(AskStatusType.Error, "Read iButton error: " + ex.Message, 1610645507U /*0x60008003*/);
        }
        finally
        {
          ((IBtnWrapperBase) btnWrapper).CloseButton();
          bOpen = false;
        }
      }
      else
        break;
    }
    return flag1;
  }

  internal bool WriteAlliBtnKeys(
    IIBtnWrapper spIBtn,
    bool bValidatePassword,
    int iKeyType,
    ref bool bOpen,
    ObservableCollection<IKeyDataRecord> keyRec,
    AccessLevelDataRecordSet pRsAccess,
    out StatusMsg statusMessage)
  {
    statusMessage = new StatusMsg(AskStatusType.Info, "", 0U);
    bool flag1 = false;
    short num1 = 6;
    MultiBtnWrapper spIBtn1 = (MultiBtnWrapper) spIBtn;
    bool flag2 = true;
    for (short index1 = 2; (int) index1 <= (int) num1; index1 += (short) 4)
    {
      if (!flag2)
      {
        try
        {
          ((IBtnWrapperBase) spIBtn1).PortType = index1;
          spIBtn1.CreateButton();
          short num2 = 1;
          if (((IBtnWrapperBase) spIBtn1).PortType == (short) 6)
            num2 = (short) 2;
          for (short index2 = num2; index2 <= (short) 15; ++index2)
          {
            if (!flag2)
            {
              ((IBtnWrapperBase) spIBtn1).PortNumber = index2;
              bool flag3 = spIBtn1.FindFirstBtn((short) byte.MaxValue);
              if (flag3)
              {
                do
                {
                  try
                  {
                    IKeyRecord keyRecord = (IKeyRecord) new HardwareKey();
                    foreach (KeyDataRecord keyDataRecord in (Collection<IKeyDataRecord>) keyRec)
                      keyRecord.KeyDataList.Add((IKeyDataRecord) keyDataRecord);
                    flag3 = ((HardwareKey) keyRecord).WriteiBtnKey((IIBtnWrapper) spIBtn1, ref bOpen, bValidatePassword, iKeyType, OpenMode.IBTN_OPEN_WRITE, pRsAccess, out statusMessage);
                  }
                  catch (Exception ex)
                  {
                    if (ex.Data != null)
                    {
                      switch ((uint) ex.Data[(object) "ErrorCode"])
                      {
                        case 2684387329 /*0xA0008001*/:
                        case 2684387332 /*0xA0008004*/:
                          flag2 = true;
                          break;
                      }
                    }
                  }
                  if (!flag2)
                    flag3 = spIBtn1.FindNextBtn();
                }
                while (flag3 && !flag2);
              }
            }
            else
              break;
          }
        }
        catch (Exception ex)
        {
          Trace.WriteLine("Read iButton error: " + ex.Message);
        }
        finally
        {
          ((IBtnWrapperBase) spIBtn1).CloseButton();
          bOpen = false;
        }
      }
      else
        break;
    }
    return flag1;
  }

  internal static void AddToExpiredSerialNumList(string sn)
  {
    KeyRecordSet.arrExpiredSerialNumList.Add((object) sn);
  }

  internal static ArrayList ExpiredSerialNumList => KeyRecordSet.arrExpiredSerialNumList;

  internal static void AddToPasswordValidatedKeyList(string sn)
  {
    KeyRecordSet.passwdValidatedKeyList.Add(sn, sn);
  }

  internal static bool IsPasswordValidated(string sn)
  {
    return KeyRecordSet.passwdValidatedKeyList.ContainsKey(sn);
  }

  internal static void AddToLockedOutKeyList(string sn)
  {
    KeyRecordSet.lockedOutKeyList.Add(sn, DateTime.Now);
  }

  internal static Dictionary<string, DateTime> LockedOutKeyList => KeyRecordSet.lockedOutKeyList;

  internal static bool IsKeyLockedOut(string sn)
  {
    bool flag = false;
    if (KeyRecordSet.lockedOutKeyList.ContainsKey(sn))
    {
      if (DateTime.Now.Subtract(KeyRecordSet.lockedOutKeyList[sn]).TotalSeconds < 600.0)
      {
        flag = true;
      }
      else
      {
        KeyRecordSet.lockedOutKeyList.Remove(sn);
        flag = false;
      }
    }
    return flag;
  }

  internal ObservableCollection<IKeyRecord> KeyList => this.keyList;

  public ObservableCollection<IKeyDataRecord> KeyDataList
  {
    get
    {
      ObservableCollection<IKeyDataRecord> keyDataList = new ObservableCollection<IKeyDataRecord>();
      foreach (IKeyRecord key in (Collection<IKeyRecord>) this.keyList)
      {
        foreach (IKeyDataRecord keyData in (Collection<IKeyDataRecord>) key.KeyDataList)
          keyDataList.Add(keyData);
      }
      return keyDataList;
    }
  }

  private bool IsSpecialHwKey(IIBtnWrapper ibtnWrapper, out AcpiButton key)
  {
    bool flag1 = false;
    bool flag2 = false;
    key = (AcpiButton) null;
    AcpiButton acpiButton = new AcpiButton();
    if (acpiButton.IsFTR(ibtnWrapper))
      flag1 = true;
    else if (acpiButton.IsDepot(ibtnWrapper, ref flag2))
      flag1 = true;
    else if (acpiButton.IsLabTool(ibtnWrapper, ref flag2))
      flag1 = true;
    if (flag1)
      key = acpiButton;
    return flag1;
  }

  internal ObservableCollection<AcpiButton> SpecialKeyList => this.specKeyList;
}
