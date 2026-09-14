// Decompiled with JetBrains decompiler
// Type: AcpASKLib.HardwareKey
// Assembly: AcpASKLib, Version=23.1.0.5, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: D65BC533-E9D0-49A5-8218-5CB2B5C70E2D
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpASKLib.dll

using AcpCommonResources;
using AcpCryptoLib;
using AcpUtility;
using IBtnWrapperLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Threading;
using System.Windows;
using System.Windows.Media;

#nullable disable
namespace AcpASKLib;

public class HardwareKey : IKeyRecord
{
  private short versionNum;
  private string serialNum;
  private byte[] serialNumBytes;
  private ObservableCollection<IKeyDataRecord> keyDataList;
  private KeyType ukeyType;
  private HardwareKeyFamily ukeyFamily;
  private bool bIsMaster;
  private bool bIsASK;
  private bool bIsValid;
  private bool bIsFormated;
  private bool bNeedUpgrade;
  private bool isPaswordProtected;
  private string strPasswordInIBtn;
  private bool bIsPasswordValidated;
  private KeyExpirationType expirationType;
  private short sDaysLeft;
  private bool isExpired;
  private DateTime expirationDate;
  private short daysToExpiration;
  private short programmingCount;
  private DateTime lastDateProgrammed;
  private MessageBoxOptions m_mbOptions;
  private string m_strProgramName = AcpResources.Application_Name_CPS;
  private readonly bool m_usePasswordCache = true;

  public HardwareKey()
  {
    this.keyDataList = new ObservableCollection<IKeyDataRecord>();
    this.serialNum = (string) null;
    this.serialNumBytes = (byte[]) null;
    this.versionNum = (short) 0;
    this.isExpired = false;
    this.ukeyType = KeyType.ADVANCED_SYSTEM_KEY;
    this.ukeyFamily = HardwareKeyFamily.Unknown;
    this.bIsPasswordValidated = false;
    this.expirationDate = DateTime.Now;
  }

  public HardwareKey(bool usePasswordCache)
    : this()
  {
    this.m_usePasswordCache = usePasswordCache;
  }

  internal uint OpenIBtn(
    IIBtnWrapper spIBtn,
    bool bReadMasterKeys,
    bool bValidatePassword,
    int options,
    int iOpenMode)
  {
    bool flag1 = true;
    uint num;
    try
    {
      spIBtn.OpenNonMotoBtn(options);
      bool pbOpen = true;
      this.serialNum = this.GetSerialNumber(spIBtn, -1);
      this.serialNumBytes = spIBtn.GetROMSerialNum();
      this.ukeyFamily = this.GetKeyFamily(spIBtn);
      bool flag2;
      if (!KeyRecordSet.IsKeyLockedOut(this.serialNum))
      {
        if (this.IsFormated(spIBtn, ref pbOpen))
        {
          num = this.GetFileLayoutVersionFromIBtn(spIBtn, 0, out this.versionNum);
          this.bIsPasswordValidated = KeyRecordSet.IsPasswordValidated(this.serialNum);
          bool flag3 = bValidatePassword;
          this.bIsASK = this.IsASK(spIBtn, ref pbOpen);
          if (this.bIsASK)
          {
            num = this.GetFileLayoutVersionFromIBtn(spIBtn, 1, out this.versionNum);
            if (num == 0U)
            {
              if (this.versionNum > (short) 5)
              {
                flag1 = false;
                num = iOpenMode != 1 ? 2684387339U /*0xA000800B*/ : 2684387336U /*0xA0008008*/;
              }
              else if (this.versionNum < (short) 5)
              {
                switch (iOpenMode)
                {
                  case 2:
                    if (MessageBox.Show(AcpResources.ResourceManager.GetString("Advance_Key_Upgrade", AcpResources.Culture).AcpStringFormat((object) this.m_strProgramName), AcpResources.ResourceManager.GetString("iButton_Open_Error", AcpResources.Culture), MessageBoxButton.YesNo, MessageBoxImage.Hand, MessageBoxResult.Yes, this.m_mbOptions) == MessageBoxResult.Yes)
                    {
                      num = this.versionNum < (short) 3 ? 2684387338U /*0xA000800A*/ : 0U;
                      break;
                    }
                    flag1 = false;
                    num = 2684387340U /*0xA000800C*/;
                    break;
                  case 3:
                    flag3 = false;
                    break;
                }
              }
            }
            if (num == 0U)
              num = this.DoesASKNeedUpgradeForPassword(spIBtn, ref this.bNeedUpgrade);
            if (num == 0U)
            {
              if (iOpenMode == 1)
                num = this.CheckKeyExpiration(spIBtn);
              if (num == 0U)
              {
                if (flag3 && this.bIsASK && !this.bIsPasswordValidated)
                {
                  num = this.NeedInputPswdForIBtn(spIBtn, out this.strPasswordInIBtn);
                  if (this.strPasswordInIBtn != null && this.strPasswordInIBtn.Length > 0)
                    this.isPaswordProtected = true;
                  switch (num)
                  {
                    case 2684387330 /*0xA0008002*/:
                      flag2 = true;
                      this.bIsPasswordValidated = true;
                      num = 0U;
                      goto label_38;
                    case 3758129160 /*0xE0008008*/:
                      if (iOpenMode != 1)
                      {
                        flag2 = false;
                        goto label_38;
                      }
                      break;
                  }
                  if (flag1)
                  {
                    if (this.strPasswordInIBtn != null)
                    {
                      if (this.strPasswordInIBtn.Length > 0)
                        num = this.ValidatePassword(this.strPasswordInIBtn);
                    }
                  }
                }
              }
            }
          }
          else if (this.IsMasterKey(spIBtn, ref pbOpen))
          {
            this.bIsMaster = true;
            if (!bReadMasterKeys)
              num = 3758129160U /*0xE0008008*/;
          }
          else if (iOpenMode == 1)
            num = this.CheckKeyExpiration(spIBtn);
        }
        else
          num = 3758129160U /*0xE0008008*/;
      }
      else
      {
        num = 2684387329U /*0xA0008001*/;
        flag2 = false;
      }
    }
    catch (Exception ex)
    {
      spIBtn.CloseButton();
      throw new Exception("Open Button failed: " + ex.Message, ex);
    }
label_38:
    return num;
  }

  private bool HasPswdAlreadyInput(IIBtnWrapper spIBtn)
  {
    bool flag = false;
    try
    {
      string serialNumber = this.GetSerialNumber(spIBtn, -1);
      if (serialNumber != null)
        flag = serialNumber == this.serialNum;
    }
    catch (Exception ex)
    {
      throw ex;
    }
    return flag;
  }

  private uint NeedInputPswdForIBtn(IIBtnWrapper spIBtn, out string pswdInIBtn)
  {
    bool flag = false;
    uint num = 0;
    pswdInIBtn = (string) null;
    try
    {
      if (this.IsValidIBtnKey(spIBtn))
        flag = this.IsPswdProtectIBtn(spIBtn);
      else
        num = 3758129160U /*0xE0008008*/;
      if (num == 0U)
      {
        if (flag)
          num = this.GetPswdFromIBtn(spIBtn, ref pswdInIBtn);
      }
    }
    catch
    {
      num = 3758129154U /*0xE0008002*/;
    }
    return num;
  }

  private bool IsValidIBtnKey(IIBtnWrapper spIBtn)
  {
    int num = this.IsValidIBtnFile(spIBtn, 0, (string) null) ? 1 : 0;
    if (num != 0)
    {
      this.bIsFormated = true;
      return num != 0;
    }
    this.bIsFormated = false;
    return num != 0;
  }

  private uint GetExpirationInfoFromIBtn(
    IIBtnWrapper spIBtn,
    out KeyExpirationType expirationType,
    out short daysLeft,
    out short numProgsLeft,
    out short lastUpdate,
    out int iVersion,
    out short lastUpdateHour)
  {
    expirationType = KeyExpirationType.Date;
    daysLeft = (short) 0;
    numProgsLeft = (short) 0;
    lastUpdate = (short) 0;
    lastUpdateHour = (short) 0;
    uint expirationInfoFromIbtn = 0;
    iVersion = 0;
    try
    {
      byte[] pByteData = (byte[]) null;
      short pMaxBytes = 50;
      if (this.GetBytesFromFile(spIBtn, 0, ref pByteData, out pMaxBytes))
      {
        int num = (int) pMaxBytes;
        byte[] numArray = new byte[(int) pMaxBytes];
        Array.Copy((Array) pByteData, (Array) numArray, (int) pMaxBytes);
        if (9 > (int) pMaxBytes - 2)
          expirationInfoFromIbtn = 3758129161U /*0xE0008009*/;
        if (expirationInfoFromIbtn == 0U)
        {
          iVersion = (int) numArray[9];
          if ((iVersion >= 3 ? (int) Global.calculateCRC8(numArray, (short) (num - 2), (byte) 0) : (int) Global.calculateCRC8(numArray, (short) (num - 1), (byte) 0)) != (int) numArray[num - 1])
          {
            Trace.WriteLine("CRC doesn't match when read MASK.0 file!!\n");
            expirationInfoFromIbtn = 3758129156U /*0xE0008004*/;
          }
          else
          {
            expirationInfoFromIbtn = this.GetExpirationInfoFromByteArray(numArray, out expirationType, out daysLeft, out numProgsLeft, out lastUpdate, out lastUpdateHour);
            DateTime dateTime = Constants.ReferenceDate;
            TimeSpan timeSpan = dateTime.AddDays((double) daysLeft).Subtract(DateTime.Today);
            daysLeft = (short) timeSpan.Days;
            dateTime = DateTime.Today;
            this.expirationDate = dateTime.AddDays((double) daysLeft);
            this.daysToExpiration = daysLeft >= (short) 0 ? daysLeft : (short) -1;
            this.expirationDate = this.expirationDate.Date + new TimeSpan(23, 59, 59);
            dateTime = Constants.ReferenceDate;
            this.LastDateProgrammed = dateTime.AddDays((double) lastUpdate);
            dateTime = this.LastDateProgrammed;
            this.LastDateProgrammed = dateTime.AddHours((double) lastUpdateHour);
          }
        }
      }
    }
    catch (Exception ex)
    {
      throw ex;
    }
    return expirationInfoFromIbtn;
  }

  private uint GetExpirationInfoFromByteArray(
    byte[] maskArray,
    out KeyExpirationType expirationType,
    out short daysLeft,
    out short progCount,
    out short lastUpdate,
    out short lastUpdateHour)
  {
    uint infoFromByteArray1 = 0;
    daysLeft = (short) 0;
    progCount = (short) 0;
    lastUpdate = (short) 0;
    lastUpdateHour = (short) 0;
    expirationType = KeyExpirationType.Date;
    if (maskArray[9] > (byte) 4)
    {
      int length = maskArray.Length;
      byte[] numArray = new byte[8];
      int num = length - 9;
      for (int index = 0; index < 8; ++index)
        numArray[index] = maskArray[num + index];
      expirationType = (KeyExpirationType) numArray[0];
      daysLeft = (short) ((int) numArray[1] << 8);
      daysLeft |= (short) numArray[2];
      progCount = (short) ((int) numArray[3] << 8);
      progCount |= (short) numArray[4];
      lastUpdate = (short) ((int) numArray[5] << 8);
      lastUpdate |= (short) numArray[6];
      lastUpdateHour = (short) numArray[7];
      return infoFromByteArray1;
    }
    uint infoFromByteArray2 = 2684387342 /*0xA000800E*/;
    Trace.WriteLine("The Advanced Key layout version is too old, don't support expiration date and programming counter.\n");
    return infoFromByteArray2;
  }

  private uint ValidatePassword(string strPswdInIBtn)
  {
    uint num1 = 0;
    int num2 = 0;
    while (num2++ < 3)
    {
      string strUserPassword = (string) null;
      if (this.GetInputPasswordFromUser(ref strUserPassword))
      {
        if (strUserPassword?.ToLower() == strPswdInIBtn?.ToLower())
        {
          this.bIsPasswordValidated = true;
          if (this.m_usePasswordCache)
          {
            KeyRecordSet.AddToPasswordValidatedKeyList(this.serialNum);
            break;
          }
          break;
        }
        if (num2 < 3)
        {
          int num3 = (int) MessageBox.Show(AcpResources.ResourceManager.GetString("Incorrect_Password_3_Times", AcpResources.Culture), AcpResources.ResourceManager.GetString("Warning_Id", AcpResources.Culture), MessageBoxButton.OK, MessageBoxImage.Exclamation, MessageBoxResult.OK, this.m_mbOptions);
        }
      }
      else
      {
        num1 = 2684387335U /*0xA0008007*/;
        break;
      }
    }
    if (num1 != 2684387335U /*0xA0008007*/ && num2 > 3)
    {
      if (this.m_usePasswordCache)
        KeyRecordSet.AddToLockedOutKeyList(this.serialNum);
      num1 = 2684387332U /*0xA0008004*/;
    }
    return num1;
  }

  public uint GetPswdFromIBtn(IIBtnWrapper spIBtn, ref string strPassword)
  {
    strPassword = (string) null;
    uint pswdFromIbtn = 0;
    try
    {
      byte[] pByteData = (byte[]) null;
      short pMaxBytes = 50;
      if (this.GetBytesFromFile(spIBtn, 0, ref pByteData, out pMaxBytes))
      {
        int num = (int) pMaxBytes;
        byte[] numArray = new byte[(int) pMaxBytes];
        Array.Copy((Array) pByteData, (Array) numArray, (int) pMaxBytes);
        if (9 > (int) pMaxBytes - 2)
          pswdFromIbtn = 3758129161U /*0xE0008009*/;
        if (pswdFromIbtn == 0U)
        {
          if ((numArray[9] >= (byte) 3 ? (int) Global.calculateCRC8(numArray, (short) (num - 2), (byte) 0) : (int) Global.calculateCRC8(numArray, (short) (num - 1), (byte) 0)) != (int) numArray[num - 1])
          {
            Trace.WriteLine("CRC doesn't match when read MASK.0 file!!\n");
            pswdFromIbtn = 3758129156U /*0xE0008004*/;
          }
          else
            pswdFromIbtn = this.GetPasswordFromByteArray(ref strPassword, numArray);
        }
      }
    }
    catch (Exception ex)
    {
      throw ex;
    }
    return pswdFromIbtn;
  }

  private uint GetPasswordFromByteArray(ref string strpswd, byte[] pswdArray)
  {
    uint passwordFromByteArray1 = 0;
    if (pswdArray[9] >= (byte) 3)
    {
      int pswd = (int) pswdArray[11];
      string str = (string) null;
      int num = 12;
      for (int index = 0; index < (pswd + 1) / 2; ++index)
        str = index != (pswd + 1) / 2 - 1 || pswd % 2 == 0 ? str + $"{pswdArray[num + index]:x2}" : str + $"{pswdArray[num + index]:x}";
      strpswd = str;
      return passwordFromByteArray1;
    }
    uint passwordFromByteArray2 = 2684387330 /*0xA0008002*/;
    Trace.WriteLine("The Advanced Key layout version is too old, don't support the password protection.\n");
    strpswd = (string) null;
    return passwordFromByteArray2;
  }

  internal uint CheckKeyExpiration(IIBtnWrapper spIBtn)
  {
    short daysLeft = 0;
    short numProgsLeft = 0;
    short lastUpdate = 0;
    short lastUpdateHour = 0;
    KeyExpirationType expirationType = KeyExpirationType.Date;
    uint num = 0;
    this.ukeyFamily = this.GetKeyFamily(spIBtn);
    if (this.ukeyFamily == HardwareKeyFamily.DS1994)
    {
      spIBtn.GetNumDaysLeft(ref this.sDaysLeft);
      this.daysToExpiration = this.sDaysLeft;
      DateTime dateTime = DateTime.Today;
      dateTime = dateTime.AddHours(23.0);
      dateTime = dateTime.AddMinutes(59.0);
      this.expirationDate = dateTime.AddSeconds(59.0);
      this.expirationDate = this.expirationDate.AddDays((double) this.sDaysLeft);
    }
    else
    {
      int iVersion = 0;
      num = this.GetExpirationInfoFromIBtn(spIBtn, out expirationType, out daysLeft, out numProgsLeft, out lastUpdate, out iVersion, out lastUpdateHour);
    }
    switch (num)
    {
      case 0:
        this.ProgrammingCount = numProgsLeft;
        switch (expirationType)
        {
          case KeyExpirationType.Date:
            if (this.expirationDate < DateTime.Now)
            {
              this.isExpired = true;
              num = 3758129164U /*0xE000800C*/;
              break;
            }
            break;
          case KeyExpirationType.Counter:
            if (this.ProgrammingCount < (short) 1)
            {
              this.isExpired = true;
              num = 3758129164U /*0xE000800C*/;
              break;
            }
            break;
          case KeyExpirationType.Both:
            if (this.expirationDate < DateTime.Now || this.ProgrammingCount < (short) 1)
            {
              this.isExpired = true;
              num = 3758129164U /*0xE000800C*/;
              break;
            }
            break;
        }
        break;
      case 2684387342 /*0xA000800E*/:
        if (this.ukeyFamily == HardwareKeyFamily.DS1963 || this.ukeyFamily == HardwareKeyFamily.DS1996)
        {
          num = 0U;
          break;
        }
        break;
    }
    return num;
  }

  private uint GetFileLayoutVersionFromIBtn(IIBtnWrapper spIBtn, int iFileID, out short iVersion)
  {
    byte[] pByteData = (byte[]) null;
    short pMaxBytes = 50;
    uint layoutVersionFromIbtn = 0;
    iVersion = (short) 0;
    try
    {
      this.GetBytesFromFile(spIBtn, iFileID, ref pByteData, out pMaxBytes);
      byte[] numArray = new byte[(int) pMaxBytes];
      Array.Copy((Array) pByteData, (Array) numArray, (int) pMaxBytes);
      int num = (int) pMaxBytes;
      if (9 > (int) pMaxBytes - 2)
        layoutVersionFromIbtn = 3758129161U /*0xE0008009*/;
      if (layoutVersionFromIbtn == 0U)
      {
        iVersion = (short) pByteData[9];
        if ((iFileID != 0 || iVersion >= (short) 3 ? (int) Global.calculateCRC8(numArray, (short) (num - 2), (byte) 0) : (int) Global.calculateCRC8(numArray, (short) (num - 1), (byte) 0)) != (int) numArray[num - 1])
        {
          Trace.WriteLine($"CRC doesn't match when read {this.GetFileNameFromFileID(iFileID)} file!!\n");
          layoutVersionFromIbtn = 3758129156U /*0xE0008004*/;
        }
      }
    }
    catch (Exception ex)
    {
      throw ex;
    }
    return layoutVersionFromIbtn;
  }

  protected virtual bool GetInputPasswordFromUser(ref string strUserPassword)
  {
    bool passwordFromUser = false;
    IBtnAccessPasswordWnd accessPasswordWnd = new IBtnAccessPasswordWnd();
    accessPasswordWnd.WindowStyle = WindowStyle.ToolWindow;
    accessPasswordWnd.Background = (Brush) Brushes.LightGray;
    accessPasswordWnd.Title = AcpResources.Enter_Access_Password.AcpStringFormat((object) this.serialNum);
    accessPasswordWnd.WindowStartupLocation = WindowStartupLocation.CenterScreen;
    if (Application.Current != null && Application.Current.MainWindow != null)
      accessPasswordWnd.Owner = Application.Current.MainWindow;
    bool? nullable = accessPasswordWnd.ShowDialog();
    bool flag = true;
    if (nullable.GetValueOrDefault() == flag & nullable.HasValue)
    {
      strUserPassword = accessPasswordWnd.Passwd.Password;
      passwordFromUser = true;
    }
    return passwordFromUser;
  }

  internal uint DoesASKNeedUpgradeForPassword(IIBtnWrapper spIBtn, ref bool needUpgrade)
  {
    short iVersion1 = -1;
    uint layoutVersionFromIbtn = this.GetFileLayoutVersionFromIBtn(spIBtn, 0, out iVersion1);
    short iVersion2 = -1;
    if (layoutVersionFromIbtn == 0U)
      layoutVersionFromIbtn = this.GetFileLayoutVersionFromIBtn(spIBtn, 1, out iVersion2);
    short iVersion3 = -1;
    if (layoutVersionFromIbtn == 0U)
      layoutVersionFromIbtn = this.GetFileLayoutVersionFromIBtn(spIBtn, 2, out iVersion3);
    short iVersion4 = -1;
    if (layoutVersionFromIbtn == 0U)
    {
      string str = "OTAP.0";
      if (spIBtn.DoesFileExist(str))
        layoutVersionFromIbtn = this.GetFileLayoutVersionFromIBtn(spIBtn, 4, out iVersion4);
      else
        iVersion4 = (short) 3;
    }
    needUpgrade = iVersion1 < (short) 3 || iVersion2 < (short) 3 || iVersion3 < (short) 3 || iVersion4 < (short) 3;
    return layoutVersionFromIbtn;
  }

  public bool WriteiBtnKey(
    IIBtnWrapper spIBtn,
    ref bool bOpen,
    bool bValidatePassword,
    int iKeyType,
    OpenMode iOpenMode,
    AccessLevelDataRecordSet pRsAccess,
    out StatusMsg statusMessage)
  {
    bool flag = false;
    int options = 0;
    string message1 = "";
    try
    {
      uint retCode1 = this.OpenIBtn(spIBtn, false, bValidatePassword, options, (int) iOpenMode);
      bOpen = true;
      if (retCode1 == 2684387338U /*0xA000800A*/)
        retCode1 = 0U;
      if (retCode1 == 0U)
      {
        string romSn = this.GetRomSN(spIBtn);
        flag = this.DoWrite(spIBtn, romSn, iKeyType, pRsAccess);
        statusMessage = new StatusMsg(AskStatusType.Info, message1, retCode1);
      }
      else
      {
        uint retCode2 = 1610645509 /*0x60008005*/;
        string message2 = AcpResources.iBtn_System_key.AcpStringFormat((object) this.serialNum);
        statusMessage = new StatusMsg(AskStatusType.Error, message2, retCode2);
      }
    }
    catch (Exception ex)
    {
      uint retCode = 1610645509 /*0x60008005*/;
      statusMessage = new StatusMsg(AskStatusType.Error, ex.Message, retCode);
      throw ex;
    }
    return flag;
  }

  internal bool DoWrite(
    IIBtnWrapper spIBtn,
    string strSerialNumber,
    int iKeyType,
    AccessLevelDataRecordSet pRsAccess)
  {
    bool flag1 = true;
    try
    {
      char[] chArray = new char[2];
      ArrayList pKeysArray = new ArrayList();
      ArrayList pDataArray = new ArrayList();
      ArrayList pOTAPArray = new ArrayList();
      Dictionary<int, AccessRecord> dictionary = new Dictionary<int, AccessRecord>();
      int length1 = strSerialNumber.Length;
      for (int index = 0; index < length1 / 2; ++index)
      {
        chArray[0] = strSerialNumber[2 * index];
        chArray[1] = strSerialNumber[2 * index + 1];
        byte num = byte.Parse($"{new string(chArray):s}", NumberStyles.HexNumber);
        pKeysArray.Insert(index, (object) num);
        pDataArray.Insert(index, (object) num);
        pOTAPArray.Insert(index, (object) num);
      }
      string str1 = "MFTR.1";
      bool flag2 = spIBtn.DoesFileExist(str1);
      if (!flag2)
      {
        switch (iKeyType)
        {
          case 3:
            pKeysArray.Insert(8, (object) (byte) 3);
            pKeysArray.Insert(9, (object) (byte) 5);
            byte count1 = (byte) this.keyDataList.Count;
            pKeysArray.Insert(10, (object) count1);
            byte checkSum1 = Global.CalculateCheckSum((byte[]) pKeysArray.ToArray(typeof (byte)));
            pKeysArray.Add((object) checkSum1);
            break;
          case 5:
            Trace.WriteLine("\n\t\t********* Testing for ISR **********\n");
            pKeysArray.Insert(8, (object) (byte) 5);
            pKeysArray.Insert(9, (object) (byte) 5);
            byte checkSum2 = Global.CalculateCheckSum((byte[]) pKeysArray.ToArray(typeof (byte)));
            pKeysArray.Add((object) checkSum2);
            break;
          default:
            string str2 = "MSTR.0";
            flag2 = spIBtn.DoesFileExist(str2);
            if (!flag2)
            {
              string str3 = "MISR.0";
              flag2 = spIBtn.DoesFileExist(str3);
            }
            if (!flag2)
            {
              pKeysArray.Insert(8, (object) (byte) 1);
              pDataArray.Insert(8, (object) (byte) 2);
              pOTAPArray.Insert(8, (object) (byte) 4);
              pKeysArray.Insert(9, (object) (byte) 5);
              pDataArray.Insert(9, (object) (byte) 5);
              pOTAPArray.Insert(9, (object) (byte) 5);
              pOTAPArray.Insert(10, (object) (byte) 0);
              byte num = 0;
              foreach (KeyDataRecord keyData in (Collection<IKeyDataRecord>) this.keyDataList)
              {
                AccessRecord accessLevel = keyData.AccessLevel;
                byte[] fieldCode = accessLevel.FieldCode;
                ++num;
                int primaryKey = accessLevel.PrimaryKey;
                if (!dictionary.ContainsKey(primaryKey))
                  dictionary.Add(primaryKey, accessLevel);
              }
              byte count2 = (byte) dictionary.Count;
              pKeysArray.Insert(10, (object) num);
              pDataArray.Insert(10, (object) count2);
              pOTAPArray.Insert(11, (object) num);
              byte checkSum3 = Global.CalculateCheckSum((byte[]) pKeysArray.ToArray(typeof (byte)));
              pKeysArray.Add((object) checkSum3);
              byte checkSum4 = Global.CalculateCheckSum((byte[]) pDataArray.ToArray(typeof (byte)));
              pDataArray.Add((object) checkSum4);
              byte checkSum5 = Global.CalculateCheckSum((byte[]) pOTAPArray.ToArray(typeof (byte)));
              pOTAPArray.Add((object) checkSum5);
              break;
            }
            break;
        }
      }
      if (!flag2)
        this.RefreshMASKFileLayout(spIBtn);
      bool flag3;
      if (!flag2)
      {
        ArrayList accessRecsInUse = new ArrayList();
        foreach (KeyValuePair<int, AccessRecord> keyValuePair in dictionary)
          accessRecsInUse.Add((object) keyValuePair.Value);
        this.Pack(ref pKeysArray, ref pDataArray, ref pOTAPArray, accessRecsInUse, pRsAccess);
        int num1 = pDataArray.Count;
        int num2 = pKeysArray.Count;
        int num3 = pOTAPArray.Count;
        if (num1 % 28 != 0)
          num1 = (num1 / 28 + 1) * 28;
        if (num2 % 28 != 0)
          num2 = (num2 / 28 + 1) * 28;
        if (num3 % 28 != 0)
          num3 = (num3 / 28 + 1) * 28;
        int num4 = 28;
        int num5 = pRsAccess != null ? num4 + (num1 + num2 + num3) : num4 + num2;
        if (this.GetSerialNumber(spIBtn, 0) != strSerialNumber)
          throw new Exception("Serial Number MISMATCH!");
        byte[] pByteData1 = (byte[]) null;
        byte[] pByteData2 = (byte[]) null;
        byte[] pByteData3 = (byte[]) null;
        byte[] pByteData4 = (byte[]) null;
        short pMaxBytes1 = 400;
        short pMaxBytes2 = 400;
        short pMaxBytes3 = 400;
        short pMaxBytes4 = 400;
        string str4 = "MSTR.0";
        bool flag4 = spIBtn.DoesFileExist(str4);
        if (flag4)
          this.GetBytesFromFile(spIBtn, 3, ref pByteData1, out pMaxBytes1);
        else
          Trace.WriteLine("\n\t\t********* MSTR.0 does not exist. **********\n");
        string str5 = "KEYS.0";
        bool flag5 = spIBtn.DoesFileExist(str5);
        if (flag5)
          this.GetBytesFromFile(spIBtn, 1, ref pByteData2, out pMaxBytes2);
        else
          Trace.WriteLine("\n\t\t********* KEYS.0 does not exist. **********\n");
        string str6 = "DATA.0";
        bool flag6 = spIBtn.DoesFileExist(str6);
        if (flag6)
          this.GetBytesFromFile(spIBtn, 2, ref pByteData3, out pMaxBytes3);
        else
          Trace.WriteLine("\n\t\t********* DATA.0 does not exist. **********\n");
        string str7 = "OTAP.0";
        bool flag7 = spIBtn.DoesFileExist(str7);
        if (flag7)
          this.GetBytesFromFile(spIBtn, 4, ref pByteData4, out pMaxBytes4);
        else
          Trace.WriteLine("\n\t\t********* OTAP.0 does not exist. **********\n");
        string str8 = "MISR.0";
        int num6 = spIBtn.DoesFileExist(str8) ? 1 : 0;
        if (num6 == 0)
          Trace.WriteLine("\n\t\t********* MISR.0 does not exist. **********\n");
        string str9 = "MSTR.0";
        if (flag4)
        {
          spIBtn.DeleteFile(str9);
          Trace.WriteLine("\n\t\t********* Delete of MSTR.0 Successful. **********\n");
        }
        string str10 = "KEYS.0";
        if (flag5)
        {
          spIBtn.DeleteFile(str10);
          Trace.WriteLine("\n\t\t********* Delete of KEYS.0 Successful. **********\n");
        }
        string str11 = "DATA.0";
        if (flag6)
        {
          spIBtn.DeleteFile(str11);
          Trace.WriteLine("\n\t\t********* Delete of DATA.0 Successful. **********\n");
        }
        string str12 = "OTAP.0";
        if (flag7)
        {
          spIBtn.DeleteFile(str12);
          Trace.WriteLine("\n\t\t********* Delete of OTAP.0 Successful. **********\n");
        }
        string str13 = "MISR.0";
        if (num6 != 0)
        {
          spIBtn.DeleteFile(str13);
          Trace.WriteLine("\n\t\t********* Delete of MISR.0 Successful. **********\n");
        }
        bool flag8 = false;
        string str14 = (string) null;
        short num7 = 0;
        spIBtn.GetMaxFileSpace(str14, ref num7);
        Trace.WriteLine("\n\t\t********* {0} ********\n", $"Bytes available = {num7}");
        if (num5 > (int) num7)
          flag8 = true;
        string str15 = this.keyDataList.Count != 0 ? (pRsAccess != null ? "KEYS.0" : "MSTR.0") : "MISR.0";
        int count3 = pKeysArray.Count;
        short num8 = 0;
        if (!flag8)
        {
          spIBtn.CreateFile(str15, ref num8);
        }
        else
        {
          if (flag4)
          {
            str15 = "MSTR.0";
            spIBtn.CreateFile(str15, ref num8);
          }
          if (flag5)
          {
            str15 = "KEYS.0";
            spIBtn.CreateFile(str15, ref num8);
          }
        }
        int length2 = pKeysArray.Count;
        int length3 = pKeysArray.Count;
        if (flag8)
        {
          if (flag5)
            length2 = (int) pMaxBytes2;
          if (flag4)
            length3 = (int) pMaxBytes1;
        }
        byte[] numArray1 = new byte[length2];
        byte[] numArray2 = new byte[length3];
        if (flag8)
        {
          if (flag5)
          {
            for (int index = 0; index < length2; ++index)
              numArray1[index] = pByteData2[index];
          }
          if (flag4)
          {
            for (int index = 0; index < length3; ++index)
              numArray2[index] = pByteData1[index];
          }
        }
        else
        {
          for (int index = 0; index < length2; ++index)
            numArray1[index] = (byte) pKeysArray[index];
        }
        byte[] numArray3 = (byte[]) null;
        byte[] numArray4 = (byte[]) null;
        AcpIBtnEncyptDecrpt ibtnEncyptDecrpt = new AcpIBtnEncyptDecrpt();
        if (flag8)
        {
          if (flag5)
          {
            ibtnEncyptDecrpt.Encrypt(numArray1, ref numArray3);
            string str16 = "KEYS.0";
            spIBtn.WriteFile(str16, (short) length2, numArray3);
          }
          if (flag4)
          {
            ibtnEncyptDecrpt.Encrypt(numArray2, ref numArray4);
            string str17 = "MSTR.0";
            spIBtn.WriteFile(str17, (short) length3, numArray4);
          }
        }
        else
        {
          ibtnEncyptDecrpt.Encrypt(numArray1, ref numArray3);
          spIBtn.WriteFile(str15, (short) length2, numArray3);
        }
        if (flag6 && (flag8 || pRsAccess != null) || !flag6 && !flag8 && pRsAccess != null)
        {
          string str18 = "DATA.0";
          int count4 = pDataArray.Count;
          short num9 = 0;
          spIBtn.CreateFile(str18, ref num9);
          int length4 = pDataArray.Count;
          if (flag8)
            length4 = (int) pMaxBytes3;
          byte[] numArray5 = new byte[length4];
          for (int index = 0; index < length4; ++index)
            numArray5[index] = !flag8 ? (byte) pDataArray[index] : pByteData3[index];
          byte[] numArray6 = (byte[]) null;
          ibtnEncyptDecrpt.Encrypt(numArray5, ref numArray6);
          spIBtn.WriteFile(str18, (short) length4, numArray6);
        }
        if (flag7 && (flag8 || pRsAccess != null) || !flag7 && !flag8 && pRsAccess != null)
        {
          string str19 = "OTAP.0";
          int count5 = pOTAPArray.Count;
          short num10 = 0;
          spIBtn.CreateFile(str19, ref num10);
          int length5 = pOTAPArray.Count;
          if (flag8)
            length5 = (int) pMaxBytes4;
          byte[] numArray7 = new byte[length5];
          for (int index = 0; index < length5; ++index)
            numArray7[index] = !flag8 ? (byte) pOTAPArray[index] : pByteData4[index];
          byte[] numArray8 = (byte[]) null;
          ibtnEncyptDecrpt.Encrypt(numArray7, ref numArray8);
          spIBtn.WriteFile(str19, (short) length5, numArray8);
        }
        if (flag8)
        {
          flag3 = false;
          throw new Exception("Out of Memory!")
          {
            Data = {
              {
                (object) "ErrorCode",
                (object) 3758129162U /*0xE000800A*/
              }
            }
          };
        }
      }
      else
      {
        flag3 = false;
        throw new Exception("Access Denied!")
        {
          Data = {
            {
              (object) "ErrorCode",
              (object) 3758129163U /*0xE000800B*/
            }
          }
        };
      }
    }
    catch (Exception ex)
    {
      throw new Exception("iButton Write Error: " + ex.Message, ex);
    }
    return flag1;
  }

  public void WriteMASKToIBtn(
    IIBtnWrapper spIBtn,
    string pstrPassword,
    KeyExpirationType expType,
    short daysToExpire,
    short progCount,
    ref bool bOpen)
  {
    try
    {
      if (!bOpen)
      {
        int num = 0;
        spIBtn.OpenNonMotoBtn(num);
      }
      TimeSpan timeSpan1 = DateTime.Now.Subtract(new DateTime(1970, 1, 1));
      daysToExpire += (short) timeSpan1.Days;
      ArrayList arrayList = new ArrayList();
      string romSn = this.GetRomSN(spIBtn);
      char[] chArray = new char[2];
      int length = romSn.Length;
      for (int index = 0; index < length / 2; ++index)
      {
        chArray.SetValue((object) null, 0);
        chArray.SetValue((object) null, 1);
        chArray[0] = romSn[2 * index];
        chArray[1] = romSn[2 * index + 1];
        byte num = byte.Parse($"{new string(chArray):s}", NumberStyles.HexNumber);
        arrayList.Insert(index, (object) num);
      }
      arrayList.Insert(8, (object) (byte) 0);
      arrayList.Insert(9, (object) (byte) 5);
      byte checkSum1 = Global.CalculateCheckSum((byte[]) arrayList.ToArray(typeof (byte)));
      arrayList.Add((object) checkSum1);
      byte num1 = 0;
      if (pstrPassword != null)
        num1 = (byte) pstrPassword.Length;
      ArrayList c1 = new ArrayList();
      c1.Insert(0, (object) num1);
      if (num1 > (byte) 0)
      {
        for (int index = 0; index < ((int) num1 + 1) / 2; ++index)
        {
          chArray.SetValue((object) null, 0);
          chArray.SetValue((object) null, 1);
          chArray[0] = pstrPassword[2 * index];
          if (index != ((int) num1 + 1) / 2 - 1 || (int) num1 % 2 == 0)
            chArray[1] = pstrPassword[2 * index + 1];
          byte num2 = byte.Parse($"{new string(chArray):s}", NumberStyles.HexNumber);
          c1.Add((object) num2);
        }
      }
      byte checkSum2 = Global.CalculateCheckSum((byte[]) c1.ToArray(typeof (byte)));
      c1.Add((object) checkSum2);
      arrayList.AddRange((ICollection) c1);
      arrayList.Add((object) (byte) expType);
      byte[] c2 = new byte[2];
      byte num3 = (byte) ((uint) daysToExpire >> 8);
      c2[0] = num3;
      byte num4 = (byte) daysToExpire;
      c2[1] = num4;
      arrayList.AddRange((ICollection) c2);
      byte[] c3 = new byte[2];
      byte num5 = (byte) ((uint) progCount >> 8);
      c3[0] = num5;
      byte num6 = (byte) progCount;
      c3[1] = num6;
      arrayList.AddRange((ICollection) c3);
      byte[] c4 = new byte[3];
      TimeSpan timeSpan2 = DateTime.Now.ToUniversalTime().Subtract(Constants.ReferenceDate);
      int days = (int) (short) timeSpan2.Days;
      byte num7 = (byte) (days >> 8);
      c4[0] = num7;
      byte num8 = (byte) days;
      c4[1] = num8;
      byte hours = (byte) timeSpan2.Hours;
      c4[2] = hours;
      arrayList.AddRange((ICollection) c4);
      byte checkSum3 = Global.CalculateCheckSum((byte[]) arrayList.ToArray(typeof (byte)));
      arrayList.Add((object) checkSum3);
      byte[] array = (byte[]) arrayList.ToArray(typeof (byte));
      byte[] numArray = (byte[]) null;
      string str = "MASK.0";
      new AcpIBtnEncyptDecrpt().Encrypt(array, ref numArray);
      if (!spIBtn.DoesFileExist(str))
      {
        short num9 = 0;
        spIBtn.CreateFile(str, ref num9);
      }
      spIBtn.WriteFile(str, (short) numArray.Length, numArray);
      if (bOpen)
        return;
      spIBtn.CloseButton();
    }
    catch (Exception ex)
    {
      throw new Exception("Write MASK file failed: " + ex.Message, ex);
    }
  }

  public void UpdatePassword(IIBtnWrapper spIBtn, string newPaswd)
  {
    bool bOpen = true;
    uint hStatus = 0;
    try
    {
      KeyExpirationType expirationType = KeyExpirationType.Date;
      short daysLeft = 0;
      short numProgsLeft = 0;
      short lastUpdate = 0;
      int iVersion = 0;
      short lastUpdateHour = 0;
      this.ukeyFamily = this.GetKeyFamily(spIBtn);
      if (this.ukeyFamily == HardwareKeyFamily.DS1994)
      {
        spIBtn.GetNumDaysLeft(ref this.sDaysLeft);
        daysLeft = this.sDaysLeft;
        this.expirationDate = DateTime.Now.AddDays((double) this.sDaysLeft);
      }
      else
      {
        hStatus = this.GetExpirationInfoFromIBtn(spIBtn, out expirationType, out daysLeft, out numProgsLeft, out lastUpdate, out iVersion, out lastUpdateHour);
        this.expirationDate = DateTime.Now.AddDays((double) daysLeft);
      }
      if (hStatus != 0U)
        throw new Exception(iBtnStatusCode.GetErrorMsg(hStatus));
      this.WriteMASKToIBtn(spIBtn, newPaswd, expirationType, daysLeft, numProgsLeft, ref bOpen);
      if (KeyRecordSet.IsPasswordValidated(this.serialNum) || !this.m_usePasswordCache)
        return;
      KeyRecordSet.AddToPasswordValidatedKeyList(this.serialNum);
    }
    catch (Exception ex)
    {
      throw ex;
    }
  }

  public void RefreshMASKFileLayout(IIBtnWrapper spIBtn)
  {
    bool flag = true;
    uint hStatus = 0;
    try
    {
      int num = this.IsFormated(spIBtn, ref flag) ? 1 : 0;
      string strPassword = "";
      if (num != 0)
        hStatus = this.GetPswdFromIBtn(spIBtn, ref strPassword);
      KeyExpirationType expirationType = KeyExpirationType.Date;
      short daysLeft = 0;
      short numProgsLeft = 0;
      short lastUpdate = 0;
      short lastUpdateHour = 0;
      int iVersion = 0;
      if (hStatus == 0U)
      {
        this.ukeyFamily = this.GetKeyFamily(spIBtn);
        if (this.ukeyFamily == HardwareKeyFamily.DS1994)
        {
          spIBtn.GetNumDaysLeft(ref this.sDaysLeft);
          daysLeft = this.sDaysLeft;
          this.expirationDate = DateTime.Now.AddDays((double) this.sDaysLeft);
        }
        else
        {
          hStatus = this.GetExpirationInfoFromIBtn(spIBtn, out expirationType, out daysLeft, out numProgsLeft, out lastUpdate, out iVersion, out lastUpdateHour);
          this.expirationDate = DateTime.Now.AddDays((double) daysLeft);
        }
      }
      if (hStatus != 0U && hStatus != 2684387330U /*0xA0008002*/ && hStatus != 2684387342U /*0xA000800E*/)
        throw new Exception(iBtnStatusCode.GetErrorMsg(hStatus));
      this.WriteMASKToIBtn(spIBtn, strPassword, expirationType, daysLeft, numProgsLeft, ref flag);
    }
    catch (Exception ex)
    {
      throw ex;
    }
  }

  public void InitButton(IIBtnWrapper spIBtn, short daysToFinalExpiration, DateTime expirationDate)
  {
    try
    {
      short num1 = daysToFinalExpiration;
      this.ExpirationDate = expirationDate;
      this.DaysToExpiration = daysToFinalExpiration;
      char ch1 = 'D';
      if (num1 < (short) 0)
        throw new Exception("Button Format Error: Invalid Expiration date");
      byte[] numArray1 = new byte[6];
      numArray1[4] = (byte) 1;
      byte[] numArray2 = numArray1;
      string str1 = "MOT_CPS";
      string str2 = "MOT_CPS";
      short num2 = 1;
      byte[] numArray3 = new byte[2]
      {
        (byte) ((uint) num2 & (uint) byte.MaxValue),
        (byte) ((uint) num2 >> 8)
      };
      char ch2 = 'B';
      bool flag1 = true;
      this.ukeyFamily = this.GetKeyFamily(spIBtn);
      bool flag2 = this.ukeyFamily == HardwareKeyFamily.DS1994 & flag1;
      string str3 = "{6BCB32177E034B3CBDA0DDA9A6E8E4760xC3A4bfe1,0x4bfe1xAa7c{0xB9";
      ((IBtnWrapperBase) spIBtn).InitButton(numArray2, numArray3, str1, str2, str3, num1, ch1, ch2, flag2);
      ((IBtnWrapperBase) spIBtn).GetROMSerialNumString();
      short num3 = 0;
      ((IBtnWrapperBase) spIBtn).GetNumDaysLeft(ref num3);
      bool bOpen = true;
      this.WriteMASKToIBtn(spIBtn, (string) null, this.expirationType, this.DaysToExpiration, this.ProgrammingCount, ref bOpen);
      this.bIsFormated = true;
    }
    catch (Exception ex)
    {
      throw new Exception("Button Format Error: " + ex.Message);
    }
  }

  public bool ReadiBtnKey(
    IIBtnWrapper spIBtn,
    bool bReadMasterKeys,
    bool bValidatePassword,
    AccessLevelDataRecordSet pRsAccess,
    ref bool bOpen,
    ref bool bISR,
    out StatusMsg status,
    bool bASKCalling,
    bool bAddAccessLevel)
  {
    bool flag = true;
    int options = 0;
    status = (StatusMsg) null;
    try
    {
      uint num = this.OpenIBtn(spIBtn, bReadMasterKeys, bValidatePassword, options, 1);
      bOpen = true;
      if (num == 0U)
      {
        int iKeyType = 0;
        if (this.bIsMaster)
        {
          iKeyType = 3;
          pRsAccess = (AccessLevelDataRecordSet) null;
        }
        else if (this.bIsASK)
          iKeyType = 1;
        if (!this.bIsMaster)
        {
          if (!this.bIsASK)
            goto label_13;
        }
        try
        {
          this.DoRead(spIBtn, this.serialNum, iKeyType, pRsAccess, bISR, bASKCalling, bAddAccessLevel);
        }
        catch (Exception ex)
        {
          this.keyDataList.Clear();
          uint retCode = 1610645507 /*0x60008003*/;
          this.bIsValid = false;
          flag = false;
          string str = AcpResources.iBtn_System_key.AcpStringFormat((object) this.serialNum);
          status = new StatusMsg(AskStatusType.Error, $"{str} {ex.Message}", retCode);
        }
      }
      else
      {
        flag = false;
        string message = AcpResources.Error_Reading_iButton.AcpStringFormat((object) iBtnStatusCode.GetErrorMsg(num), (object) this.serialNum);
        status = new StatusMsg(AskStatusType.Error, message, num);
      }
    }
    catch (Exception ex)
    {
      flag = false;
      uint retCode = 1610645507 /*0x60008003*/;
      string message = AcpResources.Error_Reading_iButton.AcpStringFormat((object) ex.Message, (object) this.serialNum);
      status = new StatusMsg(AskStatusType.Error, message, retCode);
    }
label_13:
    return flag;
  }

  internal void DoRead(
    IIBtnWrapper spIBtn,
    string pSN,
    int iKeyType,
    AccessLevelDataRecordSet pRsAccess,
    bool bISR,
    bool bASKCalling,
    bool bAddAccessLevel)
  {
    try
    {
      bool flag1 = false;
      if (iKeyType == 1)
        flag1 = true;
      if (flag1)
      {
        if (this.KeyFamily == HardwareKeyFamily.DS1994)
        {
          spIBtn.GetNumDaysLeft(ref this.sDaysLeft);
          this.ExpirationWarning(this.sDaysLeft, spIBtn);
        }
        else
        {
          KeyExpirationType expirationType = KeyExpirationType.Date;
          short numProgsLeft = 0;
          short lastUpdate = 0;
          short lastUpdateHour = 0;
          int iVersion = 0;
          int expirationInfoFromIbtn = (int) this.GetExpirationInfoFromIBtn(spIBtn, out expirationType, out this.daysToExpiration, out numProgsLeft, out lastUpdate, out iVersion, out lastUpdateHour);
          if (this.KeyFamily != HardwareKeyFamily.DS1963 || iVersion >= 5)
            this.ExpirationWarning(this.daysToExpiration, spIBtn);
        }
      }
      string str1 = "MASK.0";
      short num1 = 400;
      short num2 = 400;
      spIBtn.GetMaxFileSpace(str1, ref num1);
      spIBtn.GetFileSize(str1, ref num2);
      if (this.GetSerialNumber(spIBtn, 0) != pSN)
        throw new Exception("\n\t\t******* MASK.0 serial number does not match device serial number. *********\n");
      int nFile1 = iKeyType;
      int nFile2 = 2;
      int nFile3 = 4;
      byte[] pByteData1 = (byte[]) null;
      byte[] pByteData2 = (byte[]) null;
      byte[] pByteData3 = (byte[]) null;
      short pMaxBytes1 = 400;
      short pMaxBytes2 = 400;
      short pMaxBytes3 = 400;
      bool flag2 = false;
      this.GetBytesFromFile(spIBtn, nFile1, ref pByteData1, out pMaxBytes1);
      if (flag1)
      {
        this.GetBytesFromFile(spIBtn, nFile2, ref pByteData2, out pMaxBytes2);
        string str2 = "OTAP.0";
        flag2 = spIBtn.DoesFileExist(str2);
        if (flag2)
          this.GetBytesFromFile(spIBtn, nFile3, ref pByteData3, out pMaxBytes3);
      }
      string serialNumber = this.GetSerialNumber(spIBtn, nFile1);
      string str3;
      if (nFile1 != 1)
      {
        str3 = serialNumber;
      }
      else
      {
        str3 = this.GetSerialNumber(spIBtn, 2);
        if (flag2 && this.GetSerialNumber(spIBtn, 4) != pSN)
          throw new Exception("\n\t\t***** OTAP serial numbers from files do not match device");
      }
      if (serialNumber != pSN || str3 != pSN)
        throw new Exception("\n\t\t***** serial numbers from files do not match device *******\n");
      ArrayList arrayList1 = new ArrayList();
      ArrayList arrayList2 = new ArrayList();
      ArrayList arrayList3 = new ArrayList();
      int index1 = 0;
      while (index1 < (int) pMaxBytes1)
        arrayList2.Insert(index1, (object) pByteData1[index1++]);
      int index2 = 0;
      if (pRsAccess != null)
      {
        while (index2 < (int) pMaxBytes2)
          arrayList1.Insert(index2, (object) pByteData2[index2++]);
      }
      int index3 = 0;
      if (pRsAccess != null && flag2)
      {
        while (index3 < (int) pMaxBytes3)
          arrayList3.Insert(index3, (object) pByteData3[index3++]);
      }
      if ((int) Global.calculateCRC8((byte[]) arrayList2.ToArray(typeof (byte)), (short) (index1 - 2), (byte) 0) != (int) (byte) arrayList2[index1 - 1])
        throw new Exception("Key Checksum does not match !");
      if (pRsAccess != null && (int) Global.calculateCRC8((byte[]) arrayList1.ToArray(typeof (byte)), (short) (index2 - 2), (byte) 0) != (int) (byte) arrayList1[index2 - 1])
        throw new Exception("Data Checksum does not match !");
      if (flag2 && pRsAccess != null && (int) Global.calculateCRC8((byte[]) arrayList3.ToArray(typeof (byte)), (short) (index3 - 2), (byte) 0) != (int) (byte) arrayList3[index3 - 1])
        throw new Exception("OTAP Checksum does not match !");
      byte num3 = (byte) arrayList2[8];
      if (pRsAccess != null)
      {
        byte num4 = (byte) arrayList1[8];
        if (flag2 && (byte) arrayList3[8] != (byte) 4)
          throw new Exception("Invalid OTAP File ID!");
        if (num3 != (byte) 1 || num4 != (byte) 2)
          throw new Exception("Invalid KEY/DATA File ID!");
      }
      else if ((int) num3 != nFile1)
        throw new Exception("Invalid KEY File ID!");
      this.versionNum = (short) (byte) arrayList2[9];
      this.UnPack((byte[]) null, (byte[]) arrayList2.ToArray(typeof (byte)), (byte[]) arrayList1.ToArray(typeof (byte)), (byte[]) arrayList3.ToArray(typeof (byte)), pRsAccess, bASKCalling, bAddAccessLevel);
    }
    catch (Exception ex)
    {
      throw ex;
    }
  }

  internal void ExpirationWarning(short numberOfDaysLeft, IIBtnWrapper spIBtn)
  {
    if (numberOfDaysLeft >= (short) 30)
      return;
    string strSerialNum = (string) null;
    if (this.CheckIfPopupExpiredMessage(spIBtn, ref strSerialNum))
      return;
    if (strSerialNum != null && strSerialNum.Length > 0)
    {
      this.isExpired = true;
      KeyRecordSet.AddToExpiredSerialNumList(strSerialNum);
    }
    if (numberOfDaysLeft < (short) 0)
    {
      string str = string.Format(AcpResources.ResourceManager.GetString("Attached_Key_Expired", AcpResources.Culture), (object) strSerialNum);
      int num = (int) MessageBox.Show(str, AcpResources.ResourceManager.GetString("Warning_Id", AcpResources.Culture), MessageBoxButton.OK, MessageBoxImage.Exclamation, MessageBoxResult.OK, this.m_mbOptions);
      throw new Exception(str);
    }
    int num1 = (int) MessageBox.Show(numberOfDaysLeft != (short) 0 ? string.Format(AcpResources.ResourceManager.GetString("Attached_Key_Will_Expire", AcpResources.Culture), (object) strSerialNum, (object) numberOfDaysLeft) : string.Format(AcpResources.ResourceManager.GetString("Attached_Key_Expiring_Today", AcpResources.Culture), (object) strSerialNum), AcpResources.ResourceManager.GetString("Warning_Id", AcpResources.Culture), MessageBoxButton.OK, MessageBoxImage.Exclamation, MessageBoxResult.OK, this.m_mbOptions);
  }

  private void SetDialogCulture()
  {
    try
    {
      if (Thread.CurrentThread.CurrentUICulture.TextInfo.IsRightToLeft)
        this.m_mbOptions = MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading;
      else
        this.m_mbOptions = MessageBoxOptions.None;
    }
    catch
    {
    }
  }

  internal bool UnPack(
    byte[] maskArray,
    byte[] keyArray,
    byte[] dataArray,
    byte[] otapArray,
    AccessLevelDataRecordSet accessRecSet,
    bool bASKCalling,
    bool bAddAccessLevel)
  {
    Collection<KeyDataRecord> collection1 = this.UnPackKeyData(keyArray, accessRecSet);
    if (collection1 == null)
      throw new Exception("No Systems found in the key");
    bool flag1 = true;
    Collection<OtapData> collection2 = this.UnPackOPTAPData(otapArray);
    if (collection2 == null || collection2.Count == 0)
      flag1 = false;
    if (flag1)
    {
      int count1 = collection1.Count;
      int count2 = collection2.Count;
    }
    Collection<AccessRecordData> collection3 = this.UnPackAccessRecordData(dataArray);
    if (accessRecSet != null)
    {
      foreach (KeyDataRecord keyDataRecord in collection1)
      {
        AccessRecordData legacyAccRecData = (AccessRecordData) null;
        if (collection3 != null)
        {
          foreach (AccessRecordData accessRecordData in collection3)
          {
            if (accessRecordData.PrimaryKey == (int) keyDataRecord.ForiegnKey)
            {
              legacyAccRecData = accessRecordData;
              break;
            }
          }
        }
        if (legacyAccRecData != null)
        {
          bool flag2 = false;
          if (flag1)
          {
            foreach (OtapData otapData in collection2)
            {
              if (keyDataRecord.SystemID == otapData.SystemID && (int) keyDataRecord.KeyType == (int) otapData.OTAPKeyType)
              {
                flag2 = otapData.OTAPStatus;
                break;
              }
            }
          }
          else
            flag2 = true;
          byte[] pResult = legacyAccRecData.FieldCode;
          int num1 = 0;
          if (legacyAccRecData.Ranges != null)
            num1 = legacyAccRecData.Ranges.Count;
          int num2 = 1;
          if (this.versionNum == (short) 1)
          {
            for (int index = 0; index < 10; ++index)
            {
              if (pResult[index] != byte.MaxValue)
              {
                num2 = 0;
                break;
              }
            }
            num2 = num2 <= 0 || ((int) pResult[10] & 15) != 15 || num1 != 0 ? 0 : 1;
          }
          else if (this.versionNum == (short) 2)
          {
            for (int index = 0; index < 12; ++index)
            {
              if (pResult[index] != byte.MaxValue)
              {
                num2 = 0;
                break;
              }
            }
            if (!flag2 || num1 != 0)
              num2 = 0;
          }
          else
          {
            num2 = KeyDataRecord.GetAccessLevelType(pResult);
            if (!flag2 || num1 != 0)
              num2 = 0;
          }
          if (num2 == 1)
          {
            if (pResult.Length != 24)
              pResult = new byte[24];
            for (int index = 0; index < 24; ++index)
              pResult[index] = byte.MaxValue;
            if (legacyAccRecData.FieldCode.Length != 24)
              legacyAccRecData.FieldCode = pResult;
          }
          if (num2 == 2)
          {
            if (pResult.Length != 24)
              pResult = new byte[24];
            for (int index = 0; index < 24; ++index)
              pResult[index] = byte.MaxValue;
            pResult[10] = (byte) 247;
            if (legacyAccRecData.FieldCode.Length != 24)
              legacyAccRecData.FieldCode = pResult;
          }
          if (!flag1 && num2 != 0)
            flag2 = true;
          if (bASKCalling)
          {
            keyDataRecord.AccessLevel = new AccessRecord(legacyAccRecData.PrimaryKey, FeatureCategoryType.TRUNKING, legacyAccRecData.FieldCode, legacyAccRecData.Ranges, flag2);
          }
          else
          {
            AccessRecordData accessRecordData = AccessDataConverter.ConvertLegacyAccessRecordData(legacyAccRecData, flag2);
            keyDataRecord.AccessLevel = new AccessRecord(accessRecordData.PrimaryKey, FeatureCategoryType.TRUNKING, accessRecordData.FieldCode, accessRecordData.Ranges, flag2);
          }
          if (bAddAccessLevel)
          {
            AccessRecord recordByData = accessRecSet.GetRecordByData(keyDataRecord.AccessLevel);
            if (recordByData == null)
            {
              int num3 = 1;
              string strName = "Access Level 1";
              for (AccessRecord recordByAccessName = accessRecSet.GetRecordByAccessName(strName); recordByAccessName != null; recordByAccessName = accessRecSet.GetRecordByAccessName(strName))
                strName = $"Access Level {++num3}";
              keyDataRecord.AccessLevel.Name = strName;
              accessRecSet.AddNewRecord(keyDataRecord.AccessLevel);
            }
            else
            {
              keyDataRecord.AccessLevel.Name = recordByData.Name;
              keyDataRecord.AccessLevel.ID = recordByData.ID;
              keyDataRecord.AccessLevel.PrimaryKey = recordByData.PrimaryKey;
            }
          }
        }
      }
    }
    foreach (IKeyDataRecord keyDataRecord in collection1)
      this.keyDataList.Add(keyDataRecord);
    return true;
  }

  internal bool Pack(
    ref ArrayList pKeysArray,
    ref ArrayList pDataArray,
    ref ArrayList pOTAPArray,
    ArrayList accessRecsInUse,
    AccessLevelDataRecordSet pRsAccess)
  {
    if (pRsAccess != null)
    {
      foreach (AccessRecord accessRecord in accessRecsInUse)
        pDataArray.AddRange((ICollection) accessRecord.PackedData);
    }
    foreach (KeyDataRecord keyData in (Collection<IKeyDataRecord>) this.keyDataList)
    {
      byte primaryKey = (byte) keyData.AccessLevel.PrimaryKey;
      ArrayList arrayList = new ArrayList();
      int systemId = keyData.SystemID;
      byte keyType = keyData.KeyType;
      byte num1 = (byte) ((uint) keyType << 4);
      byte num2 = (byte) ((uint) (byte) (systemId >> 16 /*0x10*/) | (uint) num1);
      pKeysArray.Add((object) num2);
      arrayList.Add((object) num2);
      byte num3 = (byte) (systemId >> 8);
      pKeysArray.Add((object) num3);
      arrayList.Add((object) num3);
      byte num4 = (byte) systemId;
      pKeysArray.Add((object) num4);
      arrayList.Add((object) num4);
      if (pRsAccess != null)
      {
        pKeysArray.Add((object) primaryKey);
        arrayList.Add((object) primaryKey);
      }
      byte checkSum1 = Global.CalculateCheckSum((byte[]) arrayList.ToArray(typeof (byte)));
      pKeysArray.Add((object) checkSum1);
      arrayList.Clear();
      pOTAPArray.Add((object) keyType);
      arrayList.Add((object) keyType);
      byte num5 = (byte) (systemId >> 16 /*0x10*/);
      pOTAPArray.Add((object) num5);
      arrayList.Add((object) num5);
      byte num6 = (byte) (systemId >> 8);
      pOTAPArray.Add((object) num6);
      arrayList.Add((object) num6);
      byte num7 = (byte) systemId;
      pOTAPArray.Add((object) num7);
      arrayList.Add((object) num7);
      int num8 = keyData.AccessLevel.OPTAPState ? 1 : 0;
      byte num9 = 0;
      if (num8 != 0)
        num9 = (byte) 1;
      if (pRsAccess != null)
      {
        pOTAPArray.Add((object) num9);
        arrayList.Add((object) num7);
      }
      byte checkSum2 = Global.CalculateCheckSum((byte[]) arrayList.ToArray(typeof (byte)));
      pOTAPArray.Add((object) checkSum2);
    }
    byte checkSum3 = Global.CalculateCheckSum((byte[]) pKeysArray.ToArray(typeof (byte)));
    pKeysArray.Add((object) checkSum3);
    byte checkSum4 = Global.CalculateCheckSum((byte[]) pDataArray.ToArray(typeof (byte)));
    pDataArray.Add((object) checkSum4);
    byte checkSum5 = Global.CalculateCheckSum((byte[]) pOTAPArray.ToArray(typeof (byte)));
    pOTAPArray.Add((object) checkSum5);
    return true;
  }

  private Collection<OtapData> UnPackOPTAPData(byte[] optapArray)
  {
    Collection<OtapData> collection = (Collection<OtapData>) null;
    bool flag = true;
    if (optapArray != null && optapArray.Length != 0)
    {
      if (optapArray.Length == 0)
        flag = false;
      if (flag)
      {
        int num1 = 0;
        byte[] byteArray = new byte[12];
        for (int index = 0; index < 12; ++index)
          byteArray[index] = optapArray[index];
        int num2 = (int) Global.CalculateCheckSum(byteArray) == (int) optapArray[12] ? (int) optapArray[9] : throw new Exception("\n\t FAILED AT OTAP.0 HEADER CHECKSUM !!!\n");
        int optap = (int) optapArray[11];
        int index1 = 13;
        int length = optapArray.Length;
        collection = new Collection<OtapData>();
        while (index1 < length - 3)
        {
          int num3 = 0;
          ArrayList arrayList = new ArrayList();
          byte keytype = 0;
          int index2;
          if (num2 < 4)
          {
            arrayList.Add((object) optapArray[index1]);
            byte[] numArray = optapArray;
            int index3 = index1;
            index2 = index3 + 1;
            num3 = (int) numArray[index3] << 24;
          }
          else
          {
            arrayList.Add((object) optapArray[index1]);
            byte[] numArray = optapArray;
            int index4 = index1;
            index2 = index4 + 1;
            keytype = numArray[index4];
          }
          arrayList.Add((object) optapArray[index2]);
          int num4 = num3;
          byte[] numArray1 = optapArray;
          int index5 = index2;
          int index6 = index5 + 1;
          int num5 = (int) numArray1[index5] << 16 /*0x10*/;
          int num6 = num4 | num5;
          arrayList.Add((object) optapArray[index6]);
          int num7 = num6;
          byte[] numArray2 = optapArray;
          int index7 = index6;
          int index8 = index7 + 1;
          int num8 = (int) numArray2[index7] << 8;
          int num9 = num7 | num8;
          arrayList.Add((object) optapArray[index8]);
          int num10 = num9;
          byte[] numArray3 = optapArray;
          int index9 = index8;
          int num11 = index9 + 1;
          int num12 = (int) numArray3[index9];
          int sysID = num10 | num12;
          byte[] numArray4 = optapArray;
          int index10 = num11;
          int num13 = index10 + 1;
          byte num14 = numArray4[index10];
          arrayList.Add((object) num14);
          bool otap = ((int) num14 & 1) > 0;
          byte checkSum = Global.CalculateCheckSum((byte[]) arrayList.ToArray(typeof (byte)));
          byte[] numArray5 = optapArray;
          int index11 = num13;
          index1 = index11 + 1;
          if ((int) numArray5[index11] != (int) checkSum)
            throw new Exception("\n\t FAILED AT OTAP.0 ENTRY CHECKSUM !!!\n");
          OtapData otapData = new OtapData(keytype, sysID, otap);
          collection.Add(otapData);
          ++num1;
        }
        if (optap != num1)
          throw new Exception("\n\t FAILED AT OTAP.0 - RECORD COUNT MISMATCH !!!\n");
      }
    }
    return collection;
  }

  private Collection<KeyDataRecord> UnPackKeyData(
    byte[] pKeysArray,
    AccessLevelDataRecordSet accessRecSet)
  {
    Collection<KeyDataRecord> collection = (Collection<KeyDataRecord>) null;
    if (pKeysArray != null && pKeysArray.Length != 0)
    {
      int num1 = 0;
      byte[] byteArray = new byte[11];
      for (int index = 0; index < 11; ++index)
        byteArray[index] = pKeysArray[index];
      int num2 = (int) Global.CalculateCheckSum(byteArray) == (int) pKeysArray[11] ? (int) pKeysArray[10] : throw new Exception("\n\t FAILED AT KEYS.0 HEADER CHECKSUM !!!\n");
      int index1 = 12;
      int length = pKeysArray.Length;
      collection = new Collection<KeyDataRecord>();
      while (index1 < length - 3)
      {
        byte uFKey = 0;
        ArrayList arrayList = new ArrayList();
        int num3;
        int sysID;
        byte uKeyType;
        if (this.versionNum < (short) 4)
        {
          arrayList.Add((object) pKeysArray[index1]);
          arrayList.Add((object) pKeysArray[index1 + 1]);
          byte[] numArray1 = pKeysArray;
          int index2 = index1;
          int num4 = index2 + 1;
          int num5 = (int) numArray1[index2] << 8;
          byte[] numArray2 = pKeysArray;
          int index3 = num4;
          num3 = index3 + 1;
          int num6 = (int) numArray2[index3];
          sysID = num5 | num6;
          uKeyType = (byte) 0;
        }
        else
        {
          arrayList.Add((object) pKeysArray[index1]);
          arrayList.Add((object) pKeysArray[index1 + 1]);
          arrayList.Add((object) pKeysArray[index1 + 2]);
          int num7 = (int) pKeysArray[index1] & 15;
          uKeyType = (byte) ((uint) pKeysArray[index1] >> 4);
          int num8 = index1 + 1;
          int num9 = (int) (byte) num7 << 16 /*0x10*/;
          byte[] numArray3 = pKeysArray;
          int index4 = num8;
          int num10 = index4 + 1;
          int num11 = (int) numArray3[index4] << 8;
          int num12 = num9 | num11;
          byte[] numArray4 = pKeysArray;
          int index5 = num10;
          num3 = index5 + 1;
          int num13 = (int) numArray4[index5];
          sysID = num12 | num13;
        }
        if (accessRecSet != null)
        {
          uFKey = pKeysArray[num3++];
          arrayList.Add((object) uFKey);
        }
        byte checkSum = Global.CalculateCheckSum((byte[]) arrayList.ToArray(typeof (byte)));
        byte[] numArray = pKeysArray;
        int index6 = num3;
        index1 = index6 + 1;
        if ((int) numArray[index6] != (int) checkSum)
          throw new Exception("\n\t FAILED AT KEY.0 ENTRY CHECKSUM !!!\n");
        KeyDataRecord keyDataRecord = new KeyDataRecord(uKeyType, sysID, uFKey);
        collection.Add(keyDataRecord);
        ++num1;
      }
      if (num1 != num2)
        throw new Exception("\n\t FAILED AT KEY.0 - RECORD COUNT MISMATCH !!!\n");
    }
    return collection;
  }

  private Collection<AccessRecordData> UnPackAccessRecordData(byte[] pDataArray)
  {
    int num1 = 0;
    Collection<AccessRecordData> collection = (Collection<AccessRecordData>) null;
    if (pDataArray != null && pDataArray.Length != 0)
    {
      byte[] byteArray = new byte[11];
      for (int index = 0; index < 11; ++index)
        byteArray[index] = pDataArray[index];
      int num2 = (int) Global.CalculateCheckSum(byteArray) == (int) pDataArray[11] ? (int) pDataArray[10] : throw new Exception("\n\t FAILED AT DATA.0 HEADER CHECKSUM !!!\n");
      collection = new Collection<AccessRecordData>();
      int index1 = 12;
      int length1 = pDataArray.Length;
      while (index1 < length1 - 3)
      {
        ArrayList arrayList1 = new ArrayList();
        byte[] numArray1 = pDataArray;
        int index2 = index1;
        int num3 = index2 + 1;
        byte pK = numArray1[index2];
        arrayList1.Add((object) pK);
        int length2;
        if (this.versionNum <= (short) 2)
        {
          length2 = 12;
        }
        else
        {
          length2 = (int) pDataArray[num3++];
          arrayList1.Add((object) (byte) length2);
        }
        byte[] fc = new byte[length2];
        for (int index3 = 0; index3 < length2; ++index3)
        {
          fc[index3] = pDataArray[num3++];
          arrayList1.Add((object) fc[index3]);
        }
        byte[] numArray2 = pDataArray;
        int index4 = num3;
        int num4 = index4 + 1;
        byte num5 = numArray2[index4];
        arrayList1.Add((object) num5);
        int checkSum = (int) Global.CalculateCheckSum((byte[]) arrayList1.ToArray(typeof (byte)));
        byte[] numArray3 = pDataArray;
        int index5 = num4;
        index1 = index5 + 1;
        int num6 = (int) numArray3[index5];
        if (checkSum != num6)
          throw new Exception("\n\t FAILED AT DATA.0 ENTRY CHECKSUM !!!\n");
        arrayList1.Clear();
        ArrayList arrayList2 = new ArrayList();
        Dictionary<ushort, FieldValueRangeRecSet> rg = new Dictionary<ushort, FieldValueRangeRecSet>();
        for (int index6 = 0; index6 < (int) num5; ++index6)
        {
          if (index1 >= length1 - 2)
          {
            index6 = (int) num5;
          }
          else
          {
            byte pData1 = pDataArray[index1++];
            arrayList1.Add((object) pData1);
            int num7 = 1;
            if (this.versionNum > (short) 2)
            {
              byte pData2 = pDataArray[index1++];
              arrayList1.Add((object) pData2);
              num7 = (int) pData2;
            }
            FieldValueRangeRecSet valueRangeRecSet = new FieldValueRangeRecSet((ushort) pData1);
            for (int index7 = 0; index7 < num7; ++index7)
            {
              arrayList1.Add((object) pDataArray[index1]);
              byte[] numArray4 = pDataArray;
              int index8 = index1;
              int index9 = index8 + 1;
              int num8 = (int) numArray4[index8] << 24;
              arrayList1.Add((object) pDataArray[index9]);
              byte[] numArray5 = pDataArray;
              int index10 = index9;
              int index11 = index10 + 1;
              int num9 = (int) numArray5[index10] << 16 /*0x10*/;
              int num10 = num8 + num9;
              arrayList1.Add((object) pDataArray[index11]);
              byte[] numArray6 = pDataArray;
              int index12 = index11;
              int index13 = index12 + 1;
              int num11 = (int) numArray6[index12] << 8;
              int num12 = num10 + num11;
              arrayList1.Add((object) pDataArray[index13]);
              byte[] numArray7 = pDataArray;
              int index14 = index13;
              int index15 = index14 + 1;
              int num13 = (int) numArray7[index14];
              uint num14 = (uint) (num12 + num13);
              arrayList1.Add((object) pDataArray[index15]);
              byte[] numArray8 = pDataArray;
              int index16 = index15;
              int index17 = index16 + 1;
              int num15 = (int) numArray8[index16] << 24;
              arrayList1.Add((object) pDataArray[index17]);
              byte[] numArray9 = pDataArray;
              int index18 = index17;
              int index19 = index18 + 1;
              int num16 = (int) numArray9[index18] << 16 /*0x10*/;
              int num17 = num15 + num16;
              arrayList1.Add((object) pDataArray[index19]);
              byte[] numArray10 = pDataArray;
              int index20 = index19;
              int index21 = index20 + 1;
              int num18 = (int) numArray10[index20] << 8;
              int num19 = num17 + num18;
              arrayList1.Add((object) pDataArray[index21]);
              byte[] numArray11 = pDataArray;
              int index22 = index21;
              index1 = index22 + 1;
              int num20 = (int) numArray11[index22];
              uint num21 = (uint) (num19 + num20);
              AccessFieldValueRange accessFieldValueRange = new AccessFieldValueRange((int) pData1, new uint?(num14), new uint?(num21));
              valueRangeRecSet.Add(accessFieldValueRange);
            }
            rg.Add((ushort) pData1, valueRangeRecSet);
          }
        }
        if (num5 > (byte) 0 && (int) Global.CalculateCheckSum((byte[]) arrayList1.ToArray(typeof (byte))) != (int) pDataArray[index1++])
          throw new Exception("\n\t FAILED AT DATA.0 RANGE DATA CHECKSUM !!!\n");
        AccessRecordData accessRecordData = new AccessRecordData((int) pK, fc, rg);
        collection.Add(accessRecordData);
        ++num1;
      }
      if (num1 != num2)
        throw new Exception("\n\t FAILED AT DATA.0 - RECORD COUNT MISMATCH !!!\n");
    }
    return collection;
  }

  internal string GetSerialNumber(IIBtnWrapper spIBtn, int nFile)
  {
    byte[] pByteData = (byte[]) null;
    short pMaxBytes = 400;
    string serialNumber;
    try
    {
      switch (nFile)
      {
        case 0:
        case 1:
        case 2:
        case 3:
          this.GetBytesFromFile(spIBtn, nFile, ref pByteData, out pMaxBytes);
          serialNumber = this.GetSnFromBytes(pByteData);
          break;
        default:
          serialNumber = this.GetRomSN(spIBtn);
          break;
      }
    }
    catch (Exception ex)
    {
      throw ex;
    }
    return serialNumber;
  }

  private string GetSnFromBytes(byte[] pBytes)
  {
    string snFromBytes = (string) null;
    if (pBytes != null)
    {
      for (int index = 0; index < 8; ++index)
        snFromBytes += $"{pBytes[index]:x2}";
    }
    return snFromBytes;
  }

  private HardwareKeyFamily GetKeyFamily(IIBtnWrapper spIBtn)
  {
    try
    {
      return (HardwareKeyFamily) spIBtn.GetROMSerialNum()[0];
    }
    catch (Exception ex)
    {
      throw new Exception("GetFamily failed!", ex);
    }
  }

  private string GetRomSN(IIBtnWrapper spIBtn)
  {
    string romSn = (string) null;
    try
    {
      byte[] romSerialNum = spIBtn.GetROMSerialNum();
      for (int index = 7; index >= 0; --index)
        romSn += $"{romSerialNum[index]:x2}";
    }
    catch (Exception ex)
    {
      throw new Exception("GetRomSN failed!", ex);
    }
    return romSn;
  }

  private bool GetBytesFromFile(
    IIBtnWrapper spIBtn,
    int nFile,
    ref byte[] pByteData,
    out short pMaxBytes)
  {
    bool bytesFromFile = true;
    pMaxBytes = (short) 0;
    try
    {
      string str;
      switch (nFile)
      {
        case 0:
          str = "MASK.0";
          break;
        case 1:
          str = "KEYS.0";
          break;
        case 2:
          str = "DATA.0";
          break;
        case 3:
          str = "MSTR.0";
          break;
        case 4:
          str = "OTAP.0";
          break;
        case 5:
          str = "MISR.0";
          break;
        default:
          str = (string) null;
          bytesFromFile = false;
          break;
      }
      short length = 400;
      spIBtn.GetMaxFileSpace(str, ref pMaxBytes);
      spIBtn.GetFileSize(str, ref length);
      byte[] sourceArray = new byte[(int) length];
      pMaxBytes = (short) 0;
      spIBtn.ReadFile(str, ref pMaxBytes, ref sourceArray);
      byte[] destinationArray = new byte[(int) pMaxBytes];
      Array.Copy((Array) sourceArray, 0, (Array) destinationArray, 0, destinationArray.Length);
      new AcpIBtnEncyptDecrpt().Decrypt(destinationArray, ref pByteData);
    }
    catch (TMEXException ex)
    {
      if (ex.ErrorCode == (short) -6)
        bytesFromFile = false;
    }
    catch (Exception ex)
    {
      throw ex;
    }
    return bytesFromFile;
  }

  internal bool DoesFileExistInIBtn(IIBtnWrapper spIBtn, string fileName, bool pbOpen)
  {
    bool flag = false;
    try
    {
      if (!pbOpen)
      {
        int num = 0;
        spIBtn.OpenNonMotoBtn(num);
      }
      flag = spIBtn.DoesFileExist(fileName);
      if (!pbOpen)
        spIBtn.CloseButton();
    }
    catch (Exception ex)
    {
      throw ex;
    }
    finally
    {
      if (!pbOpen)
        spIBtn.CloseButton();
    }
    return flag;
  }

  private bool IsASK(IIBtnWrapper spIBtn, ref bool pbOpen)
  {
    return this.DoesFileExistInIBtn(spIBtn, "KEYS.0", pbOpen);
  }

  private bool IsMasterKey(IIBtnWrapper spIBtn, ref bool pbOpen)
  {
    return this.DoesFileExistInIBtn(spIBtn, "MSTR.0", pbOpen);
  }

  public bool IsFormated(IIBtnWrapper spIBtn, ref bool pbOpen)
  {
    return this.DoesFileExistInIBtn(spIBtn, "MASK.0", pbOpen);
  }

  private bool IsValidIBtnFile(IIBtnWrapper spIBtn, int iFileID, string pstrSN)
  {
    string str1 = pstrSN != null ? pstrSN : this.GetSerialNumber(spIBtn, -1);
    string fileNameFromFileId = this.GetFileNameFromFileID(iFileID);
    if (fileNameFromFileId == null)
      throw new Exception("INTERNAL PROGRAM ERROR !!!");
    bool flag;
    if (this.DoesFileExistInIBtn(spIBtn, fileNameFromFileId, true))
    {
      string str2 = fileNameFromFileId;
      short num1 = 400;
      short num2 = 400;
      spIBtn.GetMaxFileSpace(str2, ref num1);
      spIBtn.GetFileSize(str2, ref num2);
      if (this.GetSerialNumber(spIBtn, iFileID) != str1)
      {
        flag = false;
        Trace.WriteLine($"\n\t\t******* {fileNameFromFileId} serial number does not match device serial number. *********\n");
      }
      else
        flag = true;
    }
    else
    {
      flag = false;
      Trace.WriteLine("File does not exist!");
    }
    return flag;
  }

  private bool IsPswdProtectIBtn(IIBtnWrapper spIBtn)
  {
    return this.IsValidIBtnFile(spIBtn, 1, (string) null);
  }

  private string GetFileNameFromFileID(int iFileID)
  {
    string fileNameFromFileId;
    switch (iFileID)
    {
      case 0:
        fileNameFromFileId = "MASK.0";
        break;
      case 1:
        fileNameFromFileId = "KEYS.0";
        break;
      case 2:
        fileNameFromFileId = "DATA.0";
        break;
      case 3:
        fileNameFromFileId = "MSTR.0";
        break;
      case 4:
        fileNameFromFileId = "OTAP.0";
        break;
      case 5:
        fileNameFromFileId = "MISR.0";
        break;
      default:
        fileNameFromFileId = (string) null;
        break;
    }
    return fileNameFromFileId;
  }

  private bool CheckIfPopupExpiredMessage(IIBtnWrapper spIBtn, ref string strSerialNum)
  {
    bool flag = false;
    try
    {
      strSerialNum = this.GetRomSN(spIBtn);
      int count = KeyRecordSet.ExpiredSerialNumList.Count;
      for (int index = 0; index < count; ++index)
      {
        if (strSerialNum == (string) KeyRecordSet.ExpiredSerialNumList[index])
        {
          flag = true;
          break;
        }
      }
    }
    catch (Exception ex)
    {
      throw ex;
    }
    return flag;
  }

  public bool HighWaterMarkSupported(ref HardwareKey hKey, ref MultiBtnWrapper btnWrapper)
  {
    bool flag = false;
    if ((hKey.KeyFamily == HardwareKeyFamily.DS1963 || hKey.KeyFamily == HardwareKeyFamily.DS1996) && hKey.Version > (short) 4 && !hKey.IsMaster && !((IBtnWrapperBase) btnWrapper).DoesFileExist("MISR.0"))
      flag = true;
    return flag;
  }

  public bool HighWaterMarkValidation(DateTime keyDate)
  {
    bool flag = true;
    DateTime dateTime = DateTime.Now.ToUniversalTime();
    dateTime = dateTime.AddHours(4.0);
    if (keyDate.CompareTo(dateTime) > 0)
      flag = false;
    return flag;
  }

  public void EraseData(ref MultiBtnWrapper btnWrapper)
  {
    string empty = string.Empty;
    try
    {
      string str1 = "KEYS.0";
      if (((IBtnWrapperBase) btnWrapper).DoesFileExist(str1))
        ((IBtnWrapperBase) btnWrapper).DeleteFile(str1);
      string str2 = "DATA.0";
      if (((IBtnWrapperBase) btnWrapper).DoesFileExist(str2))
        ((IBtnWrapperBase) btnWrapper).DeleteFile(str2);
      string str3 = "OTAP.0";
      if (((IBtnWrapperBase) btnWrapper).DoesFileExist(str3))
        ((IBtnWrapperBase) btnWrapper).DeleteFile(str3);
      string str4 = "MASK.0";
      if (!((IBtnWrapperBase) btnWrapper).DoesFileExist(str4))
        return;
      ((IBtnWrapperBase) btnWrapper).DeleteFile(str4);
    }
    catch (Exception ex)
    {
    }
  }

  internal DateTime FinalExpirationDate
  {
    get => Constants.ReferenceDate.AddDays((double) this.sDaysLeft);
    set => this.sDaysLeft = (short) value.Subtract(Constants.ReferenceDate).Days;
  }

  internal short DaysToFinalExpiration => this.sDaysLeft;

  public KeyExpirationType ExpirationType
  {
    get => this.expirationType;
    set => this.expirationType = value;
  }

  public DateTime ExpirationDate
  {
    get => this.expirationDate;
    set => this.expirationDate = value;
  }

  internal string ExpirationDateString
  {
    get => this.bIsValid ? this.expirationDate.ToShortDateString() : (string) null;
  }

  public short DaysToExpiration
  {
    get => this.daysToExpiration;
    set => this.daysToExpiration = value;
  }

  internal short ProgrammingCount
  {
    get => this.bIsValid ? this.programmingCount : (short) 0;
    set => this.programmingCount = value;
  }

  public DateTime LastDateProgrammed
  {
    get => this.lastDateProgrammed;
    set => this.lastDateProgrammed = value;
  }

  internal bool IsExpired => this.isExpired;

  internal byte[] SerialNumBytes => this.serialNumBytes;

  public string SerialNumber => this.serialNum;

  public HardwareKeyFamily KeyFamily => this.ukeyFamily;

  internal string SerialNumberAndFamily => $"{this.serialNum}  ({this.ukeyFamily})";

  public bool IsMaster => this.bIsMaster;

  public bool IsAdvancedSystemKey => this.bIsASK;

  internal bool HasOTAPEnabledSystem
  {
    get
    {
      bool otapEnabledSystem = false;
      foreach (KeyDataRecord keyData in (Collection<IKeyDataRecord>) this.keyDataList)
      {
        if (keyData.OTAPState)
        {
          otapEnabledSystem = true;
          break;
        }
      }
      return otapEnabledSystem;
    }
  }

  internal bool IsPaswordProtected
  {
    get => this.isPaswordProtected;
    set => this.isPaswordProtected = value;
  }

  internal string Password => this.strPasswordInIBtn;

  public bool IsPasswordUpgradeNeeded => this.bNeedUpgrade;

  internal bool IsValid => this.bIsValid;

  internal HardwareKeyStatus KeyStatus
  {
    get
    {
      HardwareKeyStatus keyStatus = HardwareKeyStatus.Valid;
      if (this.isExpired)
        keyStatus = HardwareKeyStatus.Expired;
      else if (!this.IsValid)
        keyStatus = this.bIsFormated ? HardwareKeyStatus.Invalid : HardwareKeyStatus.Unformatted;
      return keyStatus;
    }
  }

  public KeyType Type
  {
    get => this.ukeyType;
    set => this.ukeyType = value;
  }

  public ObservableCollection<IKeyDataRecord> KeyDataList
  {
    get => this.keyDataList;
    set => this.keyDataList = value;
  }

  public short Version
  {
    get => this.versionNum;
    set => this.versionNum = value;
  }
}
