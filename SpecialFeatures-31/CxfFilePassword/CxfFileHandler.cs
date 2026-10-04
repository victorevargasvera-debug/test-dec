// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.CxfFilePassword.CxfFileHandler
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using AcpCommonLib;
using CodeplugExchangeLibrary;
using CommonResources;
using ConstraintHelper;
using Motorola.Acp.PackUnpack.Ish;
using Motorola.Common.Communication.CommonFile;
using Motorola.Common.Communication.CommonUtil;
using Motorola.MackinawCPS.CoreFeatures.PackExec;
using MotorolaSolutions.RadioCentral.CodeplugExchangeLibrary.Extensions;
using SpecialFeatures.AcpReportManagerLib;
using SpecialFeatures.CxfFilePassword.Helpers;
using SpecialFeatures.CxfFilePassword.Models;
using SpecialFeatures.CxfFilePassword.View;
using SpecialFeatures.CxfFilePassword.ViewModel;
using System;
using System.IO;
using System.Security;
using System.Windows;

#nullable disable
namespace SpecialFeatures.CxfFilePassword;

public static class CxfFileHandler
{
  public static SecureString currentlyOpenedCxfFilePass;
  private static SecureString a;

  public static CodeplugExchangeFile OpenFileAndValidatePassword(string filePath)
  {
    int num1 = 14;
    CodeplugExchangeFile codeplugExchangeFile1;
    CodeplugExchangeFile codeplugExchangeFile2;
    while (true)
    {
      short num2;
      CxfFilePasswordPromptResult A_0;
      SecureString secureString;
      switch (num1)
      {
        case 0:
          secureString = (SecureString) null;
          break;
        case 1:
          goto label_30;
        case 2:
          A_0 = CxfFileHandler.a(Path.GetFileName(filePath));
          num2 = (short) 13;
          num1 = (int) (IntPtr) num2;
          continue;
        case 3:
          codeplugExchangeFile1 = CodeplugExchangeFileFactory.Open(filePath, CxfFileHandler.a);
          num2 = (short) 8;
          num1 = (int) (IntPtr) num2;
          continue;
        case 4:
          CxfFileHandler.currentlyOpenedCxfFilePass = A_0.ProvidedPassword;
          num2 = (short) 5;
          num1 = (int) (IntPtr) num2;
          continue;
        case 5:
          if (A_0.RememberCxfFilePassword)
          {
            num2 = (short) 9;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          num2 = (short) 6;
          num1 = (int) (IntPtr) num2;
          continue;
        case 6:
          num2 = (short) 0;
          num1 = (int) (IntPtr) num2;
          continue;
        case 7:
          num2 = (short) 1;
          if (num2 == (short) 0)
            ;
          codeplugExchangeFile2 = CodeplugExchangeFileFactory.Open(filePath, A_0.ProvidedPassword);
          num2 = (short) 12;
          num1 = (int) (IntPtr) num2;
          continue;
        case 8:
          if (codeplugExchangeFile1 != null)
          {
            num2 = (short) 15;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto label_26;
        case 9:
          num2 = (short) -24119;
          int num3 = (int) num2;
          num2 = (short) -24119;
          int num4 = (int) num2;
          switch (num3 == num4 ? 1 : 0)
          {
            case 0:
            case 2:
              goto label_28;
            default:
              num2 = (short) 0;
              if (num2 == (short) 0)
                ;
              secureString = A_0.ProvidedPassword;
              break;
          }
          break;
        case 10:
          num2 = (short) 0;
          if (codeplugExchangeFile2 != null)
          {
            num2 = (short) 1;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto case 2;
        case 11:
          CxfFileHandler.a(A_0);
          num2 = (short) 4;
          num1 = (int) (IntPtr) num2;
          continue;
        case 12:
label_28:
          if (codeplugExchangeFile2 == null)
          {
            num2 = (short) 11;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto case 4;
        case 13:
          if (!A_0.Cancelled)
          {
            num2 = (short) 7;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto label_30;
        case 14:
          switch (0)
          {
            case 0:
              goto label_3;
            default:
              continue;
          }
        case 15:
          goto label_8;
        default:
label_3:
          if (CxfFileHandler.a != null)
          {
            num2 = (short) 3;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto label_26;
      }
      CxfFileHandler.a = secureString;
      num2 = (short) 10;
      num1 = (int) (IntPtr) num2;
      continue;
label_26:
      codeplugExchangeFile2 = (CodeplugExchangeFile) null;
      num2 = (short) 2;
      num1 = (int) (IntPtr) num2;
    }
label_8:
    return codeplugExchangeFile1;
label_30:
    return codeplugExchangeFile2;
  }

  public static SecureString InitializePassword(bool isCxfEditingMode)
  {
    int num1;
    short num2;
    SecureString secureString1;
    bool flag;
    switch (0)
    {
      case 0:
label_2:
        num2 = (short) 1;
        if (num2 == (short) 0)
          ;
        secureString1 = (SecureString) null;
        flag = false;
        num2 = (short) 10;
        num1 = (int) (IntPtr) num2;
        goto default;
      default:
        while (true)
        {
          CxfFileInitializePasswordPromptResult A_0;
          SecureString secureString2;
          switch (num1)
          {
            case 0:
              secureString2 = A_0.ProvidedPassword;
              goto label_20;
            case 1:
              if (!A_0.Cancelled)
              {
                num2 = (short) 9;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_24;
            case 2:
              goto label_24;
            case 3:
              num2 = (short) 6;
              num1 = (int) (IntPtr) num2;
              continue;
            case 4:
              if (flag)
              {
                num2 = (short) 11;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 3;
            case 5:
              secureString2 = (SecureString) null;
              goto label_20;
            case 6:
              if (flag)
              {
                num2 = (short) 2;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 10;
            case 7:
              num2 = (short) 5;
              num1 = (int) (IntPtr) num2;
              continue;
            case 8:
              if (A_0.RememberCxfFilePassword)
              {
                num2 = (short) 0;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              num2 = (short) 7;
              num1 = (int) (IntPtr) num2;
              continue;
            case 9:
              num2 = (short) 1719;
              int num3 = (int) num2;
              num2 = (short) 1719;
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
                  flag = CxfFileHandler.a(A_0);
                  num2 = (short) 4;
                  num1 = (int) (IntPtr) num2;
                  continue;
              }
              break;
            case 10:
              A_0 = CxfFileHandler.a(isCxfEditingMode);
              break;
            case 11:
              num2 = (short) 0;
              secureString1 = A_0.ProvidedPassword;
              num2 = (short) 8;
              num1 = (int) (IntPtr) num2;
              continue;
            default:
              goto label_2;
          }
          num2 = (short) 1;
          num1 = (int) (IntPtr) num2;
          continue;
label_20:
          CxfFileHandler.a = secureString2;
          num2 = (short) 3;
          num1 = (int) (IntPtr) num2;
        }
label_24:
        return secureString1;
    }
  }

  public static bool OpenCodeplugFile(byte[] codeplugBytes)
  {
    short num1;
    int num2;
    IshItemCollection ishItemCollection;
    string modelNumber;
    switch (0)
    {
      case 0:
label_4:
        ishItemCollection = new PartitionCommonFile(true).Deserialize(codeplugBytes).GetCodeplugInIshItemCollection();
        modelNumber = CmpToRawPartitionsConversionHelper.GetModelNumber(ishItemCollection);
        num1 = (short) 0;
        num2 = (int) (IntPtr) num1;
        goto default;
      default:
        while (true)
        {
          num1 = (short) 26734;
          int num3 = (int) num1;
          num1 = (short) 26734;
          int num4 = (int) num1;
          switch (num3 == num4 ? 1 : 0)
          {
            case 0:
            case 2:
label_6:
              num1 = (short) 1;
              num2 = (int) (IntPtr) num1;
              continue;
            default:
              num1 = (short) 0;
              num1 = (short) 0;
              if (num1 == (short) 0)
                ;
              switch (num2)
              {
                case 0:
                  if (!string.IsNullOrEmpty(modelNumber))
                  {
                    num1 = (short) 2;
                    num2 = (int) (IntPtr) num1;
                    continue;
                  }
                  goto label_6;
                case 1:
                  goto label_9;
                case 2:
                  goto label_12;
                default:
                  goto label_4;
              }
          }
        }
label_9:
        return false;
label_12:
        num1 = (short) 1;
        if (num1 == (short) 0)
          ;
        try
        {
          new PackUnpackExecutor().Unpack(CmpToRawPartitionsConversionHelper.ConvertIshItemCollectionToRawPartitions(ishItemCollection), modelNumber);
        }
        catch (Exception ex)
        {
          int num5 = (int) MessageBox.Show(AppResources.Unable_to_unpack_codeplug_image, AppResources.Open_Byte_Array_File, MessageBoxButton.OK);
          AppInfoManager.StatusMsgReport.RegisterMessage((StatusMsgType) 0, AppResources.Unable_to_unpack_codeplug_image);
          return false;
        }
        return true;
    }
  }

  public static bool SaveCodeplugFile(
    string filePath,
    SecureString filePassword,
    string modelNumber,
    string codeplugVersion)
  {
    int A_1 = 0;
    short num1;
    bool flag;
    try
    {
      int num2 = 0;
      switch (num2)
      {
        default:
          num1 = (short) -26728;
          Codeplug codeplug;
          switch ((short) -26728 == num1 ? 1 : 0)
          {
            case 0:
            case 2:
              CodeplugExchangeFile codeplugExchangeFile;
              while (true)
              {
                switch (num2)
                {
                  case 0:
                    num1 = (short) 1;
                    num2 = (int) (IntPtr) num1;
                    continue;
                  case 1:
                    byte[] cmpBytes = CpsCodeplugToCmpBytesConversionHelper.ConvertCpsCodeplugToCmpBytes(codeplug);
                    CodeplugExchageFileMetadata exchageFileMetadata1 = new CodeplugExchageFileMetadata(codeplugVersion, UtilityMack.IsAPXNextOrAloha || UtilityMack.IsAlohaRadio ? RptMgrErrorHandler.b("슂좄힆", A_1) : RptMgrErrorHandler.b("슂햄\uDF86", A_1));
                    SecureString secureString = filePassword;
                    CodeplugExchageFileMetadata exchageFileMetadata2 = exchageFileMetadata1;
                    codeplugExchangeFile = CodeplugExchangeFileFactory.Create(cmpBytes, secureString, exchageFileMetadata2);
                    num1 = (short) 4;
                    num2 = (int) (IntPtr) num1;
                    continue;
                  case 2:
                    if (codeplug != null)
                    {
                      num1 = (short) 0;
                      num2 = (int) (IntPtr) num1;
                      continue;
                    }
                    num1 = (short) 3;
                    num2 = (int) (IntPtr) num1;
                    continue;
                  case 3:
                    goto label_23;
                  case 4:
                    goto label_11;
                  default:
                    goto label_6;
                }
label_5:;
              }
label_11:
              try
              {
                codeplugExchangeFile.SaveAs(filePath);
                flag = true;
                goto label_24;
              }
              finally
              {
                short num3 = 0;
                int num4 = (int) (IntPtr) num3;
                while (true)
                {
                  switch (num4)
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
                      ((IDisposable) codeplugExchangeFile).Dispose();
                      num3 = (short) 2;
                      num4 = (int) (IntPtr) num3;
                      continue;
                    case 2:
                      goto label_18;
                  }
                  if (codeplugExchangeFile != null)
                  {
                    num3 = (short) 1;
                    num4 = (int) (IntPtr) num3;
                  }
                  else
                    break;
                }
label_18:;
              }
            default:
              num1 = (short) 0;
              if (num1 == (short) 0)
                ;
              switch (0)
              {
                case 0:
                  break;
                default:
                  goto label_5;
              }
              break;
          }
label_6:
          PackUnpackExecutor packUnpackExecutor = new PackUnpackExecutor();
          packUnpackExecutor.PrePackHandler();
          codeplug = packUnpackExecutor.Pack(modelNumber);
          num1 = (short) 2;
          num2 = (int) (IntPtr) num1;
          goto label_5;
      }
    }
    catch (Exception ex)
    {
      if (ex.Message == AppResources.Codeplug_Exceeds_Size_Limit_On_Write)
        AppInfoManager.StatusMsgReport.RegisterMessage((StatusMsgType) 0, ex.Message);
      int num5 = (int) MessageBox.Show(AppResources.Unable_to_pack_codeplug_image, AppResources.Save_Codeplug_as_ByteArray, MessageBoxButton.OK);
      AppInfoManager.StatusMsgReport.RegisterMessage((StatusMsgType) 0, AppResources.Unable_to_pack_codeplug_image);
      flag = false;
      goto label_24;
    }
label_23:
    num1 = (short) 0;
    return false;
label_24:
    if (false)
      ;
    return flag;
  }

  private static CxfFilePasswordPromptResult a(string A_0)
  {
    short num1 = 22635;
    int num2 = (int) num1;
    num1 = (short) 22635;
    int num3 = (int) num1;
    short num4;
    switch (num2 == num3)
    {
      case true:
        num4 = (short) 0;
        if (num4 == (short) 0)
          ;
        num4 = (short) 1;
        if (num4 == (short) 0)
          ;
        CxfFilePasswordPromptViewModel passwordPromptViewModel = new CxfFilePasswordPromptViewModel()
        {
          CxfFileName = A_0
        };
        CxfFilePasswordPrompt filePasswordPrompt = new CxfFilePasswordPrompt();
        filePasswordPrompt.DataContext = (object) passwordPromptViewModel;
        CxfFilePasswordPrompt prompt = filePasswordPrompt;
        passwordPromptViewModel.OnClose += (EventHandler) ((_1, _2) =>
        {
          short num5 = 10262;
          int num6 = (int) num5;
          num5 = (short) 10262;
          int num7 = (int) num5;
          short num8;
          switch (num6 == num7)
          {
            case true:
              num8 = (short) 0;
              if (num8 == (short) 0)
                ;
              num8 = (short) 1;
              if (num8 == (short) 0)
                ;
              prompt.Close();
              break;
            default:
              num8 = (short) 0;
              goto case 1;
          }
        });
        Application.Current.Dispatcher.Invoke((Action) (() =>
        {
          short num9 = 18005;
          int num10 = (int) num9;
          num9 = (short) 18005;
          int num11 = (int) num9;
          short num12;
          switch (num10 == num11)
          {
            case true:
              num12 = (short) 1;
              if (num12 == (short) 0)
                ;
              num12 = (short) 0;
              if (num12 == (short) 0)
                ;
              prompt.Show();
              prompt.Focus();
              prompt.Hide();
              prompt.ShowDialog();
              break;
            default:
              num12 = (short) 0;
              goto case 1;
          }
        }));
        return new CxfFilePasswordPromptResult()
        {
          ProvidedPassword = passwordPromptViewModel.ProvidedPassword,
          Cancelled = passwordPromptViewModel.IsCancelled,
          RememberCxfFilePassword = passwordPromptViewModel.RemeberCxfFilePassword
        };
      default:
        num4 = (short) 0;
        goto case 1;
    }
  }

  private static CxfFileInitializePasswordPromptResult a(bool A_0)
  {
    short num1 = -28058;
    int num2 = (int) num1;
    num1 = (short) -28058;
    int num3 = (int) num1;
    short num4;
    switch (num2 == num3)
    {
      case true:
        num4 = (short) 1;
        if (num4 == (short) 0)
          ;
        num4 = (short) 0;
        if (num4 == (short) 0)
          ;
        CxfFileInitializePasswordPromptViewModel passwordPromptViewModel = new CxfFileInitializePasswordPromptViewModel()
        {
          DataLostInfoVisibility = A_0 ? Visibility.Collapsed : Visibility.Visible
        };
        CxfFileInitializePasswordPrompt initializePasswordPrompt = new CxfFileInitializePasswordPrompt();
        initializePasswordPrompt.DataContext = (object) passwordPromptViewModel;
        CxfFileInitializePasswordPrompt prompt = initializePasswordPrompt;
        passwordPromptViewModel.OnClose += (EventHandler) ((_1, _2) =>
        {
          short num5 = 11199;
          int num6 = (int) num5;
          num5 = (short) 11199;
          int num7 = (int) num5;
          short num8;
          switch (num6 == num7)
          {
            case true:
              num8 = (short) 1;
              if (num8 == (short) 0)
                ;
              num8 = (short) 0;
              if (num8 == (short) 0)
                ;
              prompt.Close();
              break;
            default:
              num8 = (short) 0;
              goto case 1;
          }
        });
        Application.Current.Dispatcher.Invoke((Action) (() =>
        {
          short num9 = -8633;
          int num10 = (int) num9;
          num9 = (short) -8633;
          int num11 = (int) num9;
          short num12;
          switch (num10 == num11)
          {
            case true:
              num12 = (short) 1;
              if (num12 == (short) 0)
                ;
              num12 = (short) 0;
              if (num12 == (short) 0)
                ;
              prompt.Show();
              prompt.Focus();
              prompt.Hide();
              prompt.ShowDialog();
              break;
            default:
              num12 = (short) 0;
              goto case 1;
          }
        }));
        CxfFileInitializePasswordPromptResult passwordPromptResult = new CxfFileInitializePasswordPromptResult();
        passwordPromptResult.ProvidedPassword = passwordPromptViewModel.ProvidedPassword;
        passwordPromptResult.ConfirmedProvidedPassword = passwordPromptViewModel.ConfirmProvidedPassword;
        passwordPromptResult.Cancelled = passwordPromptViewModel.IsCancelled;
        passwordPromptResult.RememberCxfFilePassword = passwordPromptViewModel.RemeberCxfFilePassword;
        return passwordPromptResult;
      default:
        num4 = (short) 0;
        goto case 1;
    }
  }

  private static bool a(CxfFileInitializePasswordPromptResult A_0)
  {
    int num1 = 5;
    short num2;
    while (true)
    {
      switch (num1)
      {
        case 0:
          num2 = (short) -24828;
          int num3 = (int) num2;
          num2 = (short) -24828;
          int num4 = (int) num2;
          switch (num3 == num4 ? 1 : 0)
          {
            case 0:
            case 2:
              goto label_16;
            default:
              goto label_10;
          }
        case 1:
          num2 = (short) 2;
          num1 = (int) (IntPtr) num2;
          continue;
        case 2:
          if (CxfFileHandler.a(A_0.ProvidedPassword))
          {
            num2 = (short) 6;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto case 0;
        case 3:
          goto label_15;
        case 4:
          if (!SecureStringExtensions.Compare(A_0.ProvidedPassword, A_0.ConfirmedProvidedPassword))
          {
            num2 = (short) 0;
            num2 = (short) 3;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto label_19;
        case 5:
          switch (0)
          {
            case 0:
              goto label_3;
            default:
              continue;
          }
        case 6:
label_16:
          num2 = (short) 7;
          num1 = (int) (IntPtr) num2;
          continue;
        case 7:
          if (CxfFileHandler.a(A_0.ConfirmedProvidedPassword))
          {
            num2 = (short) 4;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          num2 = (short) 0;
          num1 = (int) (IntPtr) num2;
          continue;
        default:
label_3:
          num2 = (short) 1;
          if (num2 == (short) 0)
            ;
          if (!A_0.Cancelled)
          {
            num2 = (short) 1;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto case 0;
      }
    }
label_10:
    num2 = (short) 0;
    if (num2 == (short) 0)
      ;
    int num5 = (int) MessageBox.Show(AppResources.Password_Must_Contain_10_to_32_Characters, AppResources.APX_CPS, MessageBoxButton.OK, MessageBoxImage.Exclamation, MessageBoxResult.OK);
    return false;
label_15:
    int num6 = (int) MessageBox.Show(AppResources.New_Passwords_Do_Not_Match, AppResources.APX_CPS, MessageBoxButton.OK, MessageBoxImage.Exclamation, MessageBoxResult.OK);
    return false;
label_19:
    return true;
  }

  private static bool a(SecureString A_0)
  {
    int num = 1;
    while (true)
    {
      switch (num)
      {
        case 0:
          num = 2;
          continue;
        case 1:
          switch (0)
          {
            case 0:
              break;
            default:
              continue;
          }
          break;
        case 2:
          if (false)
            ;
          if (A_0.Length <= 32 /*0x20*/)
          {
            num = 3;
            continue;
          }
          goto label_12;
        case 3:
          goto label_10;
      }
      if (A_0 != null)
      {
        num = 0;
        continue;
      }
      goto label_12;
label_2:;
    }
label_10:
    switch (true ? 1 : 0)
    {
      case 0:
      case 2:
        goto label_2;
      default:
        if (true)
          ;
        return A_0.Length >= 10;
    }
label_12:
    return false;
  }

  private static void a(CxfFilePasswordPromptResult A_0)
  {
    int num1 = 1;
    short num2;
    while (true)
    {
      switch (num1)
      {
        case 0:
          num2 = (short) 2;
          num1 = (int) (IntPtr) num2;
          continue;
        case 1:
          num2 = (short) 1;
          if (num2 == (short) 0)
            ;
          switch (0)
          {
            case 0:
              break;
            default:
              continue;
          }
          break;
        case 2:
          if (!A_0.Cancelled)
          {
            num2 = (short) 0;
            num2 = (short) 3;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto label_12;
        case 3:
          goto label_10;
      }
      if (A_0.ProvidedPassword == null)
      {
        num2 = (short) 0;
        num1 = (int) (IntPtr) num2;
        continue;
      }
      goto label_12;
label_3:;
    }
label_10:
    num2 = (short) -7358;
    int num3 = (int) num2;
    num2 = (short) -7358;
    int num4 = (int) num2;
    switch (num3 == num4 ? 1 : 0)
    {
      case 0:
      case 2:
        goto label_3;
      default:
        num2 = (short) 0;
        if (num2 == (short) 0)
          ;
        int num5 = (int) MessageBox.Show(AppResources.Please_enter_a_valid_password, AppResources.APX_CPS, MessageBoxButton.OK, MessageBoxImage.Exclamation, MessageBoxResult.OK);
        return;
    }
label_12:
    int num6 = (int) MessageBox.Show(AppResources.Incorrect_Password, AppResources.APX_CPS, MessageBoxButton.OK, MessageBoxImage.Exclamation, MessageBoxResult.OK);
  }
}
