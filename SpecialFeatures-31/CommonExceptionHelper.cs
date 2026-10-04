// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.CommonExceptionHelper
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using Motorola.Common.CustomException;
using Motorola.CommonCPS.ResourceRepository;
using System;
using System.ServiceModel;

#nullable disable
namespace SpecialFeatures;

public class CommonExceptionHelper
{
  public static readonly CommonErrorCode DirectMsgCode;

  internal static void ConvertExceptiontAndThrow(Exception ex)
  {
    int num1 = 5;
    short num2;
    CommonException commonException;
    while (true)
    {
      num2 = (short) 1;
      if (num2 == (short) 0)
        ;
      switch (num1)
      {
        case 0:
          if (!(ex is FaultException<CommonExceptionData>))
          {
            num2 = (short) 8;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          num2 = (short) 6;
          num1 = (int) (IntPtr) num2;
          continue;
        case 1:
label_14:
          commonException = ex as CommonException;
          num2 = (short) 3;
          num1 = (int) (IntPtr) num2;
          continue;
        case 2:
          goto label_10;
        case 3:
          if (commonException.ErrorCode == CommonExceptionHelper.DirectMsgCode)
          {
            num2 = (short) 2;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          num2 = (short) 2631;
          int num3 = (int) num2;
          num2 = (short) 2631;
          int num4 = (int) num2;
          switch (num3 == num4 ? 1 : 0)
          {
            case 0:
            case 2:
              goto label_14;
            default:
              goto label_21;
          }
        case 4:
          num2 = (short) 9;
          num1 = (int) (IntPtr) num2;
          continue;
        case 5:
          switch (0)
          {
            case 0:
              break;
            default:
              continue;
          }
          break;
        case 6:
          goto label_19;
        case 7:
          if (ex is TimeoutException)
          {
            num2 = (short) 0;
            num2 = (short) 10;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto label_29;
        case 8:
          if (ex is CommunicationException)
          {
            num2 = (short) 4;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          num2 = (short) 7;
          num1 = (int) (IntPtr) num2;
          continue;
        case 9:
          if (ex is EndpointNotFoundException)
          {
            num2 = (short) 11;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto label_17;
        case 10:
          goto label_18;
        case 11:
          goto label_6;
      }
      if (ex is CommonException)
      {
        num2 = (short) 1;
        num1 = (int) (IntPtr) num2;
      }
      else
      {
        num2 = (short) 0;
        num1 = (int) (IntPtr) num2;
      }
    }
label_6:
    throw CommonExceptionHelper.CreateCommonException((CommonErrorCode) 50, Resources.CommunicationServiceNotAvailabe, ex);
label_10:
    throw ex;
label_29:
    return;
label_17:
    throw CommonExceptionHelper.CreateCommonException((CommonErrorCode) 52, Resources.CommunicationServiceCommunicationError, ex);
label_18:
    throw CommonExceptionHelper.CreateCommonException((CommonErrorCode) 51, Resources.CommunicationServiceTimeout, ex);
label_19:
    FaultException<CommonExceptionData> faultException = ex as FaultException<CommonExceptionData>;
    throw CommonExceptionHelper.CreateCommonException(faultException.Detail.ErrorCode, ResourceHelper.GetCommonErrorMessageByID(faultException.Detail.ErrorCode.ToString(), (string[]) null), ex);
label_21:
    num2 = (short) 0;
    if (num2 == (short) 0)
      ;
    throw CommonExceptionHelper.CreateCommonException(commonException.ErrorCode, ResourceHelper.GetCommonErrorMessageByID(commonException.ErrorCode.ToString(), (string[]) null), ex);
  }

  public static CommonException CreateCommonException(
    CommonErrorCode errorID,
    string message,
    Exception ex = null)
  {
    short num1 = -16241;
    int num2 = (int) num1;
    num1 = (short) -16241;
    int num3 = (int) num1;
    short num4;
    switch (num2 == num3 ? 1 : 0)
    {
      case 0:
      case 2:
        num4 = (short) 1;
        if (num4 == (short) 0)
          ;
        return new CommonException(errorID, message, new Exception());
      default:
        num4 = (short) 0;
        if (num4 == (short) 0)
          ;
        if (ex != null)
        {
          num4 = (short) 0;
          return new CommonException(errorID, message, ex);
        }
        goto case 0;
    }
  }

  public static CommonException CreateDirectMessageCommonException(string message)
  {
    short num1 = -9022;
    int num2 = (int) num1;
    num1 = (short) -9022;
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
        return new CommonException(CommonExceptionHelper.DirectMsgCode, message);
      default:
        num4 = (short) 0;
        goto case 1;
    }
  }

  static CommonExceptionHelper()
  {
    short num1 = -32720;
    int num2 = (int) num1;
    num1 = (short) -32720;
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
        CommonExceptionHelper.DirectMsgCode = (CommonErrorCode) 2050;
        break;
      default:
        num4 = (short) 0;
        goto case 1;
    }
  }
}
