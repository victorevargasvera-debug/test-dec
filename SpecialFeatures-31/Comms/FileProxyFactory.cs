// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.Comms.FileProxyFactory
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using Motorola.Common.Communication.CommonUtil;
using Motorola.Common.CustomException;
using Motorola.CommonCPS.ResourceRepository;
using SpecialFeatures.AcpReportManagerLib;
using System;
using System.Diagnostics;
using System.Windows;

#nullable disable
namespace SpecialFeatures.Comms;

public class FileProxyFactory
{
  protected ProxyParameter _proxyParameter;
  private static FileProxyFactory a;

  public static FileProxyFactory Instance
  {
    get
    {
      short num1 = 18805;
      int num2 = (int) num1;
      num1 = (short) 18805;
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
          return FileProxyFactory.a;
        default:
          goto case 1;
      }
    }
  }

  public FileProxyFactory() => this._proxyParameter = new ProxyParameter();

  internal IDeviceProxy GetDevice(object arg, RadioOperation radioOperation)
  {
    short num1 = -27527;
    int num2 = (int) num1;
    num1 = (short) -27527;
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
        return this.CreateDevice(new ProxyParameter()
        {
          RadioParams = (RadioParams) arg,
          RadioOperation = radioOperation,
          AstroDeviceInfo = this._proxyParameter.AstroDeviceInfo,
          DeviceFile = this._proxyParameter.DeviceFile
        });
      default:
        goto case 1;
    }
  }

  public virtual bool SetupVirtualProxy(string deviceFile, AstroDeviceInfo deviceInfo)
  {
    int A_1 = 3;
    short num1 = 1;
    if (num1 == (short) 0)
      ;
    num1 = (short) -9494;
    int num2 = (int) num1;
    num1 = (short) -9494;
    int num3 = (int) num1;
    switch (num2 == num3)
    {
      case true:
        num1 = (short) 0;
        if (num1 == (short) 0)
          ;
        num1 = (short) 0;
        int num4 = (bool) Application.Current.Properties[(object) RptMgrErrorHandler.b("얅\uE787\uE789\uE18B\uEF8Dﺏ\uF691\uD893ﾕ\uF697ﾙ\uDF9B캝\uF39F", A_1)] ? 1 : 0;
        if (num4 == 0)
          return num4 != 0;
        this._proxyParameter.DeviceFile = deviceFile;
        this._proxyParameter.AstroDeviceInfo = deviceInfo;
        return num4 != 0;
      default:
        goto case 1;
    }
  }

  protected virtual IDeviceProxy CreateDevice(ProxyParameter parameter)
  {
    int A_1 = 5;
    short num1;
    IDeviceProxy device;
    try
    {
      num1 = (short) -7558;
      int num2 = (int) num1;
      num1 = (short) -7558;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          device = (IDeviceProxy) new FileProxy(parameter.DeviceFile, parameter.AstroDeviceInfo);
          break;
        default:
          goto case 1;
      }
    }
    catch (CommonException ex)
    {
      throw;
    }
    catch (Exception ex)
    {
      Trace.WriteLine(RptMgrErrorHandler.b("펇캉\uE98B\uF88D憐\uF191\uF193욕\uEA97\uF599\uE49B\uE79D\uE69F쎡잣튥잧\uD8A9햫\uF3AD\uEBAF\uF7B1첳햵\uDDB7쪹좻ힽ꾿곁駃鷅诇룉꧋꿍\uA4CF럑郓돕껗동뿛믝뷟\uD8E1쓣", A_1) + ex.Message);
      throw CommonExceptionHelper.CreateCommonException((CommonErrorCode) 1, Resources.GenericError, ex);
    }
    num1 = (short) 0;
    num1 = (short) 1;
    if (num1 == (short) 0)
      ;
    return device;
  }

  static FileProxyFactory()
  {
    short num1 = 1;
    if (num1 == (short) 0)
      ;
    num1 = (short) 19511;
    int num2 = (int) num1;
    num1 = (short) 19511;
    int num3 = (int) num1;
    switch (num2 == num3)
    {
      case true:
        num1 = (short) 0;
        if (num1 == (short) 0)
          ;
        num1 = (short) 0;
        FileProxyFactory.a = new FileProxyFactory();
        break;
      default:
        goto case 1;
    }
  }
}
