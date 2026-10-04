// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.Comms.DeviceProxy
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using AcpCommonLib;
using CommonResources;
using Motorola.Common.Communication.CommonUtil;
using Motorola.Common.Communication.Pba;
using Motorola.Common.Communication.Service;
using Motorola.Common.CustomException;
using Motorola.CommonCPS.ResourceRepository;
using SpecialFeatures.AcpReportManagerLib;
using SpecialFeatures.RadioLanguagePack;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

#nullable disable
namespace SpecialFeatures.Comms;

public class DeviceProxy : IDeviceProxy, IDisposable
{
  private DeviceServiceHandler a;
  private IDeviceOperation b;
  private ProgressChangedEventHandler c;
  private DeviceInfo d;
  private bool e;
  private RadioOperation f;
  private bool g;
  private readonly string h;
  private bool i;

  public DeviceProxy(DeviceInfo deviceInfo, RadioOperation radioOp, string psk = null)
  {
    int A_1 = 10;
    this.g = true;
    this.h = RptMgrErrorHandler.b("ꊌ\uDB8E쎐튒\uDB94쒖\uDF98\uDE9A쾜낞", A_1);
    // ISSUE: explicit constructor call
    base.\u002Ector();
    this.f = radioOp;
    this.d = deviceInfo;
    try
    {
      this.a = new DeviceServiceHandler();
      this.a.ProgressEventHandler += new ProgressChangedEventHandler(this.a);
      this.b = DeviceServiceManagerProvider.Instance.GetDeviceOperationService((IOperationServiceEvent) this.a);
      this.d.ConnectionInfo.SessionID = this.b.OpenSession(this.d, this.f, string.IsNullOrEmpty(psk) ? (SessionParameter) null : new SessionParameter((ushort) 0, false, psk), false);
      DeviceManagerSingleTon.Instance.DeviceLostEvent += new EventHandler<DeviceEventArgs>(this.a);
    }
    catch (Exception ex)
    {
      this.a();
      CommonExceptionHelper.ConvertExceptiontAndThrow(ex);
      throw CommonExceptionHelper.CreateCommonException((CommonErrorCode) 1, Resources.GenericError, ex);
    }
  }

  public bool CurrentRadioIsConnected
  {
    get
    {
      short num1 = -31825;
      int num2 = (int) num1;
      num1 = (short) -31825;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          short num4 = 1;
          if (num4 == (short) 0)
            ;
          num4 = (short) 0;
          if (num4 == (short) 0)
            ;
          num4 = (short) 0;
          return this.g;
        default:
          goto case 1;
      }
    }
  }

  public PbaObject Read(RadioParams radioPara, ProgressChangedEventHandler prgressIndicator = null)
  {
    PbaObject pbaObject;
    try
    {
      short num1 = -28182;
      int num2 = (int) num1;
      num1 = (short) -28182;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          if (true)
            ;
          this.c = prgressIndicator;
          pbaObject = this.b.ReadDevice(radioPara.WrapperDeviceInfo(), (PbaObject) null);
          break;
        default:
          goto case 1;
      }
    }
    catch (Exception ex)
    {
      this.a();
      CommonExceptionHelper.ConvertExceptiontAndThrow(ex);
      throw CommonExceptionHelper.CreateCommonException((CommonErrorCode) 1, Resources.GenericError, ex);
    }
    finally
    {
      this.c = (ProgressChangedEventHandler) null;
    }
    short num = 1;
    if (num == (short) 0)
      ;
    num = (short) 0;
    return pbaObject;
  }

  public PbaObject ReadBlock(
    RadioParams radioPara,
    List<IshHeader> blockList,
    ProgressChangedEventHandler prgressIndicator = null)
  {
    PbaObject pbaObject;
    try
    {
      int num1 = 0;
      switch (num1)
      {
        default:
          object[] objArray;
          int index;
          short num2;
          switch (0)
          {
            case 0:
label_3:
              objArray = new object[blockList.Count];
              index = 0;
              num2 = (short) 3;
              num1 = (int) (IntPtr) num2;
              goto default;
            default:
              while (true)
              {
                switch (num1)
                {
                  case 0:
                    goto label_14;
                  case 1:
label_11:
                    this.c = prgressIndicator;
                    pbaObject = this.b.ReadBlocks(radioPara.WrapperDeviceInfo(), (ICollection) objArray);
                    num2 = (short) 0;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  case 2:
                  case 3:
                    num2 = (short) 4;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  case 4:
                    num2 = (short) 24200;
                    int num3 = (int) num2;
                    num2 = (short) 24200;
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
                        num2 = (short) 1;
                        if (num2 == (short) 0)
                          ;
                        if (index >= blockList.Count)
                        {
                          num2 = (short) 1;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        }
                        objArray[index] = (object) blockList[index];
                        ++index;
                        num2 = (short) 2;
                        num1 = (int) (IntPtr) num2;
                        continue;
                    }
                  default:
                    goto label_3;
                }
              }
          }
      }
    }
    catch (Exception ex)
    {
      this.a();
      CommonExceptionHelper.ConvertExceptiontAndThrow(ex);
      throw CommonExceptionHelper.CreateCommonException((CommonErrorCode) 1, Resources.GenericError, ex);
    }
    finally
    {
      this.c = (ProgressChangedEventHandler) null;
    }
label_14:
    return pbaObject;
  }

  public bool Write(
    RadioParams radioPara,
    PbaObject targetPba,
    ProgressChangedEventHandler prgressIndicator = null)
  {
    bool flag;
    try
    {
      short num1 = 6344;
      int num2 = (int) num1;
      num1 = (short) 6344;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          short num4 = 1;
          if (num4 == (short) 0)
            ;
          num4 = (short) 0;
          if (num4 == (short) 0)
            ;
          this.c = prgressIndicator;
          this.b.WriteDevice(radioPara.WrapperDeviceInfo(), targetPba, new int?());
          this.e = true;
          flag = true;
          break;
        default:
          goto case 1;
      }
    }
    catch (Exception ex)
    {
      this.a();
      CommonExceptionHelper.ConvertExceptiontAndThrow(ex);
      throw CommonExceptionHelper.CreateCommonException((CommonErrorCode) 1, Resources.GenericError, ex);
    }
    finally
    {
      this.c = (ProgressChangedEventHandler) null;
    }
    return flag;
  }

  public DeviceInfo ReadDeviceInfo()
  {
    short num1 = 1;
    if (num1 == (short) 0)
      ;
    num1 = (short) 15401;
    int num2 = (int) num1;
    num1 = (short) 15401;
    int num3 = (int) num1;
    switch (num2 == num3)
    {
      case true:
        num1 = (short) 0;
        if (num1 == (short) 0)
          ;
        num1 = (short) 0;
        return this.b.ReadDeviceInfo(this.d);
      default:
        goto case 1;
    }
  }

  public RadioParams ReadExtendedDeviceInfo()
  {
    short num1;
    RadioParams radioParams;
    try
    {
      short num2 = -11907;
      int num3 = (int) num2;
      num2 = (short) -11907;
      int num4 = (int) num2;
      switch (num3 == num4)
      {
        case true:
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          AstroDeviceInfo astroDeviceInfo = this.b.ReadExtendedDeviceInfo(this.d) as AstroDeviceInfo;
          ((DeviceInfo) astroDeviceInfo).ConnectionInfo = this.d.ConnectionInfo;
          radioParams = astroDeviceInfo.WrapperRadioParams();
          break;
        default:
          goto case 1;
      }
    }
    catch (Exception ex)
    {
      this.a();
      CommonExceptionHelper.ConvertExceptiontAndThrow(ex);
      throw CommonExceptionHelper.CreateCommonException((CommonErrorCode) 1, Resources.GenericError, ex);
    }
    num1 = (short) 1;
    if (num1 == (short) 0)
      ;
    num1 = (short) 0;
    return radioParams;
  }

  public bool ResetPassword(byte[] passwordResetFileContent)
  {
    short num1;
    bool flag;
    try
    {
      short num2 = 6366;
      int num3 = (int) num2;
      num2 = (short) 6366;
      int num4 = (int) num2;
      switch (num3 == num4)
      {
        case true:
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          num1 = (short) 1;
          if (num1 == (short) 0)
            ;
          flag = this.b.ResetPassword(this.d, passwordResetFileContent);
          break;
        default:
          goto case 1;
      }
    }
    catch (Exception ex)
    {
      this.a();
      CommonExceptionHelper.ConvertExceptiontAndThrow(ex);
      throw CommonExceptionHelper.CreateCommonException((CommonErrorCode) 1, Resources.GenericError, ex);
    }
    num1 = (short) 0;
    return flag;
  }

  public bool ForceWrite(
    RadioParams radioPara,
    PbaObject targetPba,
    ProgressChangedEventHandler prgressIndicator = null)
  {
    short num1;
    bool flag;
    try
    {
      short num2 = 26993;
      int num3 = (int) num2;
      num2 = (short) 26993;
      int num4 = (int) num2;
      switch (num3 == num4)
      {
        case true:
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          this.c = prgressIndicator;
          this.b.ForceWriteDevice(radioPara.WrapperDeviceInfo(), targetPba);
          this.e = true;
          flag = true;
          break;
        default:
          goto case 1;
      }
    }
    catch (Exception ex)
    {
      this.a();
      CommonExceptionHelper.ConvertExceptiontAndThrow(ex);
      throw CommonExceptionHelper.CreateCommonException((CommonErrorCode) 1, Resources.GenericError, ex);
    }
    finally
    {
      if (false)
        ;
      this.c = (ProgressChangedEventHandler) null;
    }
    num1 = (short) 0;
    return flag;
  }

  public bool UpdateSN(RadioParams radioPara, string serialNumber)
  {
    short num1;
    bool flag;
    try
    {
      short num2 = -31403;
      int num3 = (int) num2;
      num2 = (short) -31403;
      int num4 = (int) num2;
      switch (num3 == num4)
      {
        case true:
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          this.b.UpdateSerialNumber(radioPara.WrapperDeviceInfo(), serialNumber);
          flag = true;
          break;
        default:
          goto case 1;
      }
    }
    catch (Exception ex)
    {
      this.a();
      CommonExceptionHelper.ConvertExceptiontAndThrow(ex);
      throw CommonExceptionHelper.CreateCommonException((CommonErrorCode) 1, Resources.GenericError, ex);
    }
    num1 = (short) 1;
    if (num1 == (short) 0)
      ;
    num1 = (short) 0;
    return flag;
  }

  public bool CBIProgram(RadioParams radioPara)
  {
    short num1;
    bool flag;
    try
    {
      short num2 = 3166;
      int num3 = (int) num2;
      num2 = (short) 3166;
      int num4 = (int) num2;
      switch (num3 == num4)
      {
        case true:
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          this.b.CBIProgramme(radioPara.WrapperDeviceInfo());
          flag = true;
          break;
        default:
          goto case 1;
      }
    }
    catch (Exception ex)
    {
      this.a();
      CommonExceptionHelper.ConvertExceptiontAndThrow(ex);
      throw CommonExceptionHelper.CreateCommonException((CommonErrorCode) 1, Resources.GenericError, ex);
    }
    num1 = (short) 1;
    if (num1 == (short) 0)
      ;
    num1 = (short) 0;
    return flag;
  }

  public void UpdateDevice(
    RadioParams radioPara,
    PbaObject targetPba,
    ProgressChangedEventHandler prgressIndicator = null)
  {
    short num1;
    try
    {
      short num2 = 19841;
      int num3 = (int) num2;
      num2 = (short) 19841;
      int num4 = (int) num2;
      switch (num3 == num4)
      {
        case true:
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          this.c = prgressIndicator;
          this.b.UpdateDevice(radioPara.WrapperDeviceInfo(), targetPba, false, new int?());
          break;
        default:
          goto case 1;
      }
    }
    catch (Exception ex)
    {
      this.a();
      CommonExceptionHelper.ConvertExceptiontAndThrow(ex);
      throw CommonExceptionHelper.CreateCommonException((CommonErrorCode) 1, Resources.GenericError, ex);
    }
    finally
    {
      if (false)
        ;
      this.c = (ProgressChangedEventHandler) null;
    }
    num1 = (short) 0;
  }

  public void ValidateUpdate(RadioParams radioPara, ProgressChangedEventHandler prgressIndicator = null)
  {
    try
    {
      short num1 = -1266;
      int num2 = (int) num1;
      num1 = (short) -1266;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          short num4 = 1;
          if (num4 == (short) 0)
            ;
          num4 = (short) 0;
          if (num4 == (short) 0)
            ;
          this.c = prgressIndicator;
          this.b.CloseSession(this.d, false);
          break;
        default:
          goto case 1;
      }
    }
    catch (Exception ex)
    {
      this.a();
      CommonExceptionHelper.ConvertExceptiontAndThrow(ex);
      throw CommonExceptionHelper.CreateCommonException((CommonErrorCode) 1, Resources.GenericError, ex);
    }
    finally
    {
      this.c = (ProgressChangedEventHandler) null;
    }
  }

  public void WriteLanguagePack(
    RadioParams radioParam,
    LanguagePackData languagePackData,
    ProgressChangedEventHandler prgressIndicator = null)
  {
    try
    {
      this.c = prgressIndicator;
      this.b.WriteLanguagePacks(radioParam.WrapperDeviceInfo(), languagePackData);
    }
    catch (Exception ex)
    {
      this.a();
      CommonExceptionHelper.ConvertExceptiontAndThrow(ex);
      throw CommonExceptionHelper.CreateDirectMessageCommonException(AppResources.WriteLanguagePack_Astro_WriteRadioLanguagePackFailed);
    }
    finally
    {
      int num1;
      CommonErrorCode warningOtapErrorCode;
      short num2;
      switch (0)
      {
        case 0:
label_4:
          warningOtapErrorCode = (languagePackData.LanguagePacks[0] as AstroFilePackInfo).warningOTAPErrorCode;
          num2 = (short) 2;
          num1 = (int) (IntPtr) num2;
          goto default;
        default:
          while (true)
          {
            switch (num1)
            {
              case 0:
                LanguagePackHelper.warningOTAPMessage = ResourceHelper.GetCommonErrorMessageByID(warningOtapErrorCode.ToString(), (string[]) null);
                break;
              case 1:
                goto label_11;
              case 2:
                if (warningOtapErrorCode != null)
                {
                  num2 = (short) -9447;
                  int num3 = (int) num2;
                  num2 = (short) -9447;
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
                      num1 = (int) (IntPtr) num2;
                      continue;
                  }
                }
                else
                  goto label_11;
                break;
              default:
                goto label_4;
            }
            num2 = (short) 1;
            num1 = (int) (IntPtr) num2;
          }
label_11:
          this.c = (ProgressChangedEventHandler) null;
      }
    }
    if (false)
      ;
  }

  public bool LoadTxmCertificate(RadioParams radioParam, string path)
  {
    bool flag;
    try
    {
      byte[] numArray = File.ReadAllBytes(path);
      FileItem fileItem = new FileItem((ushort) 0, this.h + Path.GetFileName(path), numArray.Length, numArray, (string) null, (string) null);
      this.b.WriteFile(radioParam.WrapperDeviceInfo(), fileItem);
    }
    catch (CommonException ex)
    {
      AppInfoManager.StatusMsgReport.Clear();
      AppInfoManager.StatusMsgReport.RegisterMessage((StatusMsgType) 0, AppResources.Radio_denied_file_transfer);
      flag = false;
      goto label_4;
    }
    catch (Exception ex)
    {
      AppInfoManager.StatusMsgReport.Clear();
      AppInfoManager.StatusMsgReport.RegisterMessage((StatusMsgType) 0, AppResources.Load_Txm_Cert_Failed);
      flag = false;
      goto label_4;
    }
label_3:
    return true;
label_4:
    if (false)
      ;
    short num1 = 20553;
    int num2 = (int) num1;
    num1 = (short) 20553;
    int num3 = (int) num1;
    switch (num2 == num3 ? 1 : 0)
    {
      case 0:
      case 2:
        goto label_3;
      default:
        num1 = (short) 0;
        if (num1 == (short) 0)
          ;
        num1 = (short) 0;
        return flag;
    }
  }

  public string QueryTxmCertificate(RadioParams radioParam, string path)
  {
    string str;
    try
    {
      int num1 = 0;
      switch (num1)
      {
        default:
          List<FileItem> fileItemList;
          short num2;
          switch (0)
          {
            case 0:
label_3:
              FileItem fileItem = new FileItem((ushort) 0, path, 0, (byte[]) null, (string) null, (string) null);
              fileItemList = this.b.ReadFilesListInDir(radioParam.WrapperDeviceInfo(), fileItem);
              break;
            default:
              while (true)
              {
                switch (num1)
                {
                  case 0:
                    num2 = (short) -1201;
                    int num3 = (int) num2;
                    num2 = (short) -1201;
                    int num4 = (int) num2;
                    switch (num3 == num4 ? 1 : 0)
                    {
                      case 0:
                      case 2:
                        goto label_4;
                      default:
                        num2 = (short) 0;
                        if (num2 == (short) 0)
                          ;
                        str = AppResources.None_Id;
                        num2 = (short) 1;
                        num1 = (int) (IntPtr) num2;
                        continue;
                    }
                  case 1:
                  case 2:
                    goto label_12;
                  case 3:
                    if (fileItemList.Count == 0)
                    {
                      num2 = (short) 0;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    }
                    str = Path.GetFileNameWithoutExtension(fileItemList[0].FilePath);
                    num2 = (short) 2;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  default:
                    goto label_3;
                }
label_2:;
              }
          }
label_4:
          num2 = (short) 3;
          num1 = (int) (IntPtr) num2;
          goto label_2;
      }
    }
    catch (Exception ex)
    {
      AppInfoManager.StatusMsgReport.Clear();
      AppInfoManager.StatusMsgReport.RegisterMessage((StatusMsgType) 0, AppResources.Failed_to_read_installed_certificate_id);
      str = AcgResources.ID_UNKNOWN;
    }
label_12:
    short num = 1;
    if (num == (short) 0)
      ;
    num = (short) 0;
    return str;
  }

  private void a()
  {
    int num1 = 3;
    while (true)
    {
      short num2;
      switch (num1)
      {
        case 0:
          goto label_13;
        case 1:
          num2 = (short) -6032;
          int num3 = (int) num2;
          num2 = (short) -6032;
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
              if (this.d != null)
              {
                num2 = (short) 1;
                if (num2 == (short) 0)
                  ;
                num2 = (short) 2;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_14;
          }
          break;
        case 2:
          try
          {
            this.b.CloseSession(this.d, true);
            goto label_14;
          }
          catch
          {
            goto label_14;
          }
        case 3:
          switch (0)
          {
            case 0:
              goto label_3;
            default:
              continue;
          }
        case 4:
          num2 = (short) 1;
          num1 = (int) (IntPtr) num2;
          continue;
        default:
label_3:
          if (this.b == null)
            goto label_15;
          break;
      }
      num2 = (short) 4;
      num1 = (int) (IntPtr) num2;
      continue;
label_14:
      this.b = (IDeviceOperation) null;
      num2 = (short) 0;
      num1 = (int) (IntPtr) num2;
    }
label_13:
    return;
label_15:;
  }

  private void a(object A_0, DeviceEventArgs A_1)
  {
    short num1 = 2;
    int num2 = (int) (IntPtr) num1;
    while (true)
    {
      switch (num2)
      {
        case 0:
          this.g = false;
          num1 = (short) 4;
          num2 = (int) (IntPtr) num1;
          continue;
        case 1:
          num1 = (short) 23426;
          int num3 = (int) num1;
          num1 = (short) 23426;
          int num4 = (int) num1;
          switch (num3 == num4 ? 1 : 0)
          {
            case 0:
            case 2:
              break;
            default:
              num1 = (short) 1;
              if (num1 == (short) 0)
                ;
              num1 = (short) 0;
              if (num1 == (short) 0)
                ;
              num1 = (short) 3;
              num2 = (int) (IntPtr) num1;
              continue;
          }
          break;
        case 2:
          switch (0)
          {
            case 0:
              goto label_3;
            default:
              continue;
          }
        case 3:
          if (!this.a(this.d, A_1.DeviceInfo))
            goto label_10;
          break;
        case 4:
          goto label_8;
        default:
label_3:
          if (this.d != null)
          {
            num1 = (short) 1;
            num2 = (int) (IntPtr) num1;
            continue;
          }
          goto label_14;
      }
      num1 = (short) 0;
      num2 = (int) (IntPtr) num1;
    }
label_8:
    return;
label_14:
    return;
label_10:;
  }

  private void a(object A_0, ProgressChangedEventArgs A_1)
  {
    short num1 = -16341;
    int num2 = (int) num1;
    num1 = (short) -16341;
    int num3 = (int) num1;
    short num4;
    int num5;
    switch (num2 == num3 ? 1 : 0)
    {
      case 0:
      case 2:
label_6:
        num4 = (short) 1;
        if (num4 == (short) 0)
          ;
        num4 = (short) 2;
        num5 = (int) (IntPtr) num4;
        break;
      default:
        num4 = (short) 0;
        if (num4 == (short) 0)
          ;
        num4 = (short) 0;
        num5 = (int) (IntPtr) num4;
        break;
    }
    while (true)
    {
      num4 = (short) 0;
      switch (num5)
      {
        case 0:
          goto label_3;
        case 1:
          goto label_8;
        case 2:
          this.c((object) null, A_1);
          num4 = (short) 1;
          num5 = (int) (IntPtr) num4;
          continue;
        default:
          goto label_5;
      }
label_4:;
    }
label_3:
    switch (0)
    {
      case 0:
        goto label_5;
      default:
        goto label_4;
    }
label_8:
    return;
label_5:
    if (this.c != null)
      goto label_6;
  }

  private bool a(DeviceInfo A_0, DeviceInfo A_1)
  {
    switch (0)
    {
      default:
        if (false)
          ;
        short num1 = 2;
        int num2 = (int) (IntPtr) num1;
        while (true)
        {
          switch (num2)
          {
            case 0:
              goto label_35;
            case 1:
              num1 = (short) 3;
              num2 = (int) (IntPtr) num1;
              continue;
            case 2:
              switch (0)
              {
                case 0:
                  break;
                default:
                  continue;
              }
              break;
            case 3:
              if (A_1 != null)
              {
                num1 = (short) 0;
                num1 = (short) 4;
                num2 = (int) (IntPtr) num1;
                continue;
              }
              num1 = (short) 0;
              num2 = (int) (IntPtr) num1;
              continue;
            case 4:
              goto label_7;
          }
          if (A_0 != null)
          {
            num1 = (short) 1;
            num2 = (int) (IntPtr) num1;
          }
          else
            goto label_35;
        }
label_7:
        bool flag;
        try
        {
          MemoryStream serializationStream1;
          switch (0)
          {
            case 0:
label_9:
              serializationStream1 = new MemoryStream();
              num1 = (short) 0;
              num2 = (int) (IntPtr) num1;
              goto default;
            default:
              MemoryStream serializationStream2;
              byte[] numArray1;
              while (true)
              {
                switch (num2)
                {
                  case 0:
                    try
                    {
                      new BinaryFormatter().Serialize((Stream) serializationStream1, (object) A_0);
                      serializationStream1.Position = 0L;
                      numArray1 = new byte[serializationStream1.Length];
                      serializationStream1.Read(numArray1, 0, numArray1.Length);
                    }
                    finally
                    {
                      short num3 = 0;
                      num2 = (int) (IntPtr) num3;
                      while (true)
                      {
                        switch (num2)
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
                            goto label_25;
                          case 2:
                            serializationStream1.Dispose();
                            num3 = (short) 1;
                            num2 = (int) (IntPtr) num3;
                            continue;
                        }
                        if (serializationStream1 != null)
                        {
                          num3 = (short) 2;
                          num2 = (int) (IntPtr) num3;
                        }
                        else
                          break;
                      }
label_25:;
                    }
                    num1 = (short) -23748;
                    int num4 = (int) num1;
                    num1 = (short) -23748;
                    int num5 = (int) num1;
                    switch (num4 == num5 ? 1 : 0)
                    {
                      case 0:
                      case 2:
                        goto label_7;
                      default:
                        num1 = (short) 0;
                        if (num1 == (short) 0)
                          ;
                        serializationStream2 = new MemoryStream();
                        num1 = (short) 2;
                        num2 = (int) (IntPtr) num1;
                        continue;
                    }
                  case 1:
                    goto label_36;
                  case 2:
                    byte[] numArray2;
                    try
                    {
                      new BinaryFormatter().Serialize((Stream) serializationStream2, (object) A_1);
                      serializationStream2.Position = 0L;
                      numArray2 = new byte[serializationStream2.Length];
                      serializationStream2.Read(numArray2, 0, numArray2.Length);
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
                            goto label_17;
                          case 2:
                            serializationStream2.Dispose();
                            num6 = (short) 1;
                            num7 = (int) (IntPtr) num6;
                            continue;
                        }
                        if (serializationStream2 != null)
                        {
                          num6 = (short) 2;
                          num7 = (int) (IntPtr) num6;
                        }
                        else
                          break;
                      }
label_17:;
                    }
                    flag = string.Equals(numArray1.GetSHA256Hash(), numArray2.GetSHA256Hash());
                    num1 = (short) 1;
                    num2 = (int) (IntPtr) num1;
                    continue;
                  default:
                    goto label_9;
                }
              }
          }
        }
        catch
        {
          flag = false;
        }
label_36:
        return flag;
label_35:
        return false;
    }
  }

  ~DeviceProxy()
  {
    short num1;
    try
    {
      short num2 = -1922;
      int num3 = (int) num2;
      num2 = (short) -1922;
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
    short num1 = -3721;
    int num2 = (int) num1;
    num1 = (short) -3721;
    int num3 = (int) num1;
    switch (num2 == num3)
    {
      case true:
        short num4 = 1;
        if (num4 == (short) 0)
          ;
        num4 = (short) 0;
        if (num4 == (short) 0)
          ;
        num4 = (short) 0;
        this.a(true);
        GC.SuppressFinalize((object) this);
        break;
      default:
        goto case 1;
    }
  }

  private void a(bool A_0)
  {
    int num1 = 1;
    while (true)
    {
      short num2;
      switch (num1)
      {
        case 0:
          if (A_0)
          {
            num2 = (short) 10;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto case 3;
        case 1:
          switch (0)
          {
            case 0:
              goto label_3;
            default:
              continue;
          }
        case 2:
          num2 = (short) 0;
          goto label_25;
        case 3:
          this.i = true;
          num2 = (short) 7;
          num1 = (int) (IntPtr) num2;
          continue;
        case 4:
          num2 = (short) 28773;
          int num3 = (int) num2;
          num2 = (short) 28773;
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
              DeviceManagerSingleTon.Instance.DeviceLostEvent -= new EventHandler<DeviceEventArgs>(this.a);
              this.a.ProgressEventHandler -= new ProgressChangedEventHandler(this.a);
              this.a = (DeviceServiceHandler) null;
              this.c = (ProgressChangedEventHandler) null;
              num2 = (short) 2;
              num1 = (int) (IntPtr) num2;
              continue;
          }
          break;
        case 5:
          num2 = (short) 0;
          num1 = (int) (IntPtr) num2;
          continue;
        case 6:
          try
          {
            num2 = (short) 2;
            int num5 = (int) (IntPtr) num2;
            while (true)
            {
              switch (num5)
              {
                case 0:
                  goto label_24;
                case 1:
                  this.b.CloseSession(this.d, false);
                  num2 = (short) 4;
                  num5 = (int) (IntPtr) num2;
                  continue;
                case 2:
                  switch (0)
                  {
                    case 0:
                      break;
                    default:
                      continue;
                  }
                  break;
                case 3:
                case 4:
                  num2 = (short) 0;
                  num5 = (int) (IntPtr) num2;
                  continue;
              }
              if (this.f == 2L)
              {
                num2 = (short) 1;
                num5 = (int) (IntPtr) num2;
              }
              else
              {
                this.b.CloseSession(this.d, !this.e);
                num2 = (short) 3;
                num5 = (int) (IntPtr) num2;
              }
            }
          }
          catch (Exception ex)
          {
            CommonExceptionHelper.ConvertExceptiontAndThrow(ex);
            throw CommonExceptionHelper.CreateCommonException((CommonErrorCode) 1, Resources.GenericError, ex);
          }
          finally
          {
            this.b = (IDeviceOperation) null;
          }
        case 7:
          goto label_30;
        case 8:
          if (this.a != null)
          {
            num2 = (short) 4;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto label_25;
        case 9:
          num2 = (short) 1;
          if (num2 == (short) 0)
            ;
          if (this.b != null)
          {
            num2 = (short) 6;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          break;
        case 10:
          num2 = (short) 8;
          num1 = (int) (IntPtr) num2;
          continue;
        default:
label_3:
          if (!this.i)
          {
            num2 = (short) 5;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto label_32;
      }
label_24:
      this.d = (DeviceInfo) null;
      num2 = (short) 3;
      num1 = (int) (IntPtr) num2;
      continue;
label_25:
      num2 = (short) 9;
      num1 = (int) (IntPtr) num2;
    }
label_30:
    return;
label_32:;
  }
}
