// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.Comms.Extension
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using Motorola.Common.Communication.CommonUtil;
using Motorola.Common.CustomException;
using Motorola.CommonCPS.ResourceRepository;
using SpecialFeatures.AcpReportManagerLib;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;

#nullable disable
namespace SpecialFeatures.Comms;

public static class Extension
{
  internal static DeviceInfo Clone(this DeviceInfo deviceInfo)
  {
    short num1 = -17790;
    int num2 = (int) num1;
    num1 = (short) -17790;
    int num3 = (int) num1;
    switch (num2 == num3)
    {
      case true:
        short num4 = 0;
        num4 = (short) 1;
        if (num4 == (short) 0)
          ;
        num4 = (short) 0;
        if (num4 == (short) 0)
          ;
        return new DeviceInfo()
        {
          CodeplugVersion = deviceInfo.CodeplugVersion,
          ConnectionInfo = deviceInfo.ConnectionInfo,
          Family = deviceInfo.Family,
          ModelNumber = deviceInfo.ModelNumber,
          RadioID = deviceInfo.RadioID,
          RadioState = deviceInfo.RadioState,
          SerialNumber = deviceInfo.SerialNumber,
          SoftwareVersion = deviceInfo.SoftwareVersion
        };
      default:
        goto case 1;
    }
  }

  internal static RadioParams WrapperRadioParams(this AstroDeviceInfo astroDeviceInfo)
  {
    short num1;
    RadioParams radioParams1;
    try
    {
      int num2 = 0;
      switch (num2)
      {
        default:
          RadioParams radioParams2;
          switch (0)
          {
            case 0:
label_3:
              radioParams2 = new RadioParams();
              radioParams2.BootAppVersion = astroDeviceInfo.BootloaderVersion;
              radioParams2.CodeplugVersion = ((DeviceInfo) astroDeviceInfo).CodeplugVersion;
              radioParams2.DspVersion = astroDeviceInfo.DspVersion;
              radioParams2.RadioBBFSuiteVersion = Extension.GetRadioBBFSuiteVersion(astroDeviceInfo);
              radioParams2.HostVersion = ((DeviceInfo) astroDeviceInfo).SoftwareVersion;
              radioParams2.MaceFlashVersion = astroDeviceInfo.MaceFlashVersion;
              radioParams2.ModelNumber = ((DeviceInfo) astroDeviceInfo).ModelNumber;
              radioParams2.OptBoardName = astroDeviceInfo.OptionBoardName;
              radioParams2.OptBrdFlashImageType = astroDeviceInfo.OptionBoardFlashImageType;
              radioParams2.OptBrdFlashImageVersion = astroDeviceInfo.OptionBoardFlashImageVersion;
              radioParams2.OptBrdHardwareType = astroDeviceInfo.OptionBoardHardwareType;
              radioParams2.OptBrdHwHostVersion = astroDeviceInfo.OptionBoardHardwareHostVersion;
              radioParams2.LTEOptBrdHwHostVersion = astroDeviceInfo.LTEOptionBoardHardwareHostVersion;
              radioParams2.OptBrdHwNotPresentFlag = astroDeviceInfo.OptionBoardHardwareNotPresentFlag;
              radioParams2.PsdtVersion = astroDeviceInfo.PsdtVersion;
              radioParams2.ConBrdHardwareType = astroDeviceInfo.ConsoletteBoardHardwareType;
              radioParams2.ConBrdHwHostVersion = astroDeviceInfo.ConsoletteBoardHardwareHostVersion;
              radioParams2.SerialNumber = ((DeviceInfo) astroDeviceInfo).SerialNumber;
              radioParams2.ESerialNumber = astroDeviceInfo.ESN;
              radioParams2.MaceHardwareType = astroDeviceInfo.MaceSecureHardwareType;
              radioParams2.MaceHardwareVersion = astroDeviceInfo.MaceSecureHardwareVersion;
              radioParams2.TuneVersion = astroDeviceInfo.TuneVersion;
              num1 = (short) 0;
              num2 = (int) (IntPtr) num1;
              goto default;
            default:
              ConnectionInfo connectionInfo;
              while (true)
              {
                switch (num2)
                {
                  case 0:
                    if (astroDeviceInfo.UUID != null)
                    {
                      num1 = (short) 4;
                      num2 = (int) (IntPtr) num1;
                      continue;
                    }
                    goto case 3;
                  case 1:
                    connectionInfo.UniqueAddress = ((DeviceInfo) astroDeviceInfo).ConnectionInfo.UniqueAddress;
                    connectionInfo.ConnectionType = ((DeviceInfo) astroDeviceInfo).ConnectionInfo.ConnectionType;
                    connectionInfo.Location = ((DeviceInfo) astroDeviceInfo).ConnectionInfo.Location;
                    connectionInfo.SessionID = ((DeviceInfo) astroDeviceInfo).ConnectionInfo.SessionID;
                    connectionInfo.IsTlsPskCompatible = ((DeviceInfo) astroDeviceInfo).ConnectionInfo.IsTlsPskCompatible;
                    num1 = (short) 5;
                    num2 = (int) (IntPtr) num1;
                    continue;
                  case 2:
                    if (((DeviceInfo) astroDeviceInfo).ConnectionInfo != null)
                    {
                      num1 = (short) 1;
                      num2 = (int) (IntPtr) num1;
                      continue;
                    }
                    goto case 5;
                  case 3:
                    connectionInfo = new ConnectionInfo();
                    num1 = (short) 2;
                    num2 = (int) (IntPtr) num1;
                    continue;
                  case 4:
                    num1 = (short) -28455;
                    int num3 = (int) num1;
                    num1 = (short) -28455;
                    int num4 = (int) num1;
                    switch (num3 == num4 ? 1 : 0)
                    {
                      case 0:
                      case 2:
                        goto label_3;
                      default:
                        num1 = (short) 0;
                        if (num1 == (short) 0)
                          ;
                        radioParams2.Uuid = new Guid(astroDeviceInfo.UUID);
                        num1 = (short) 3;
                        num2 = (int) (IntPtr) num1;
                        continue;
                    }
                  case 5:
                    radioParams2.ConnectionInfo = connectionInfo;
                    radioParams2.Family = ((DeviceInfo) astroDeviceInfo).Family;
                    radioParams2.RadioID = ((DeviceInfo) astroDeviceInfo).RadioID;
                    radioParams2.RadioState = ((DeviceInfo) astroDeviceInfo).RadioState;
                    radioParams2.RadioStorage = ((DeviceInfo) astroDeviceInfo).RadioStorage;
                    radioParams1 = radioParams2;
                    num1 = (short) 6;
                    num2 = (int) (IntPtr) num1;
                    continue;
                  case 6:
                    goto label_15;
                  default:
                    goto label_3;
                }
              }
          }
      }
    }
    catch (Exception ex)
    {
      throw CommonExceptionHelper.CreateCommonException((CommonErrorCode) 1, Resources.GenericError, ex);
    }
label_15:
    num1 = (short) 0;
    num1 = (short) 1;
    if (num1 == (short) 0)
      ;
    return radioParams1;
  }

  internal static string GetRadioBBFSuiteVersion(AstroDeviceInfo deviceInfo)
  {
    int num1 = 1;
    AmpDeviceInfo ampDeviceInfo;
    while (true)
    {
      short num2;
      switch (num1)
      {
        case 0:
label_11:
          if (((DeviceInfo) ampDeviceInfo).RadioBBFSuiteVersion == null)
          {
            num2 = (short) 0;
            num2 = (short) 3;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto label_6;
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
          num2 = (short) 6016;
          int num3 = (int) num2;
          num2 = (short) 6016;
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
              ampDeviceInfo = deviceInfo as AmpDeviceInfo;
              num2 = (short) 0;
              num1 = (int) (IntPtr) num2;
              continue;
          }
        case 3:
          goto label_7;
      }
      if (((DeviceInfo) deviceInfo).Family == 4096 /*0x1000*/)
      {
        num2 = (short) 1;
        if (num2 == (short) 0)
          ;
        num2 = (short) 2;
        num1 = (int) (IntPtr) num2;
      }
      else
        goto label_13;
    }
label_6:
    return ((DeviceInfo) ampDeviceInfo).RadioBBFSuiteVersion;
label_7:
    return ampDeviceInfo.BpFirmwareVersion;
label_13:
    return ((DeviceInfo) deviceInfo).RadioBBFSuiteVersion;
  }

  internal static string GetSHA256Hash(this byte[] data)
  {
    int A_1 = 0;
    short num1 = 5818;
    int num2 = (int) num1;
    num1 = (short) 5818;
    int num3 = (int) num1;
    string shA256Hash;
    switch (num2 == num3 ? 1 : 0)
    {
      case 0:
      case 2:
        return shA256Hash;
      default:
        if (false)
          ;
        if (true)
          ;
        SHA256 shA256 = (SHA256) new SHA256CryptoServiceProvider();
        try
        {
          shA256Hash = BitConverter.ToString(shA256.ComputeHash(data)).Replace(RptMgrErrorHandler.b("꺂", A_1), "");
          goto case 0;
        }
        finally
        {
          int num4 = 1;
          while (true)
          {
            short num5;
            switch (num4)
            {
              case 0:
                shA256.Dispose();
                num5 = (short) 2;
                num4 = (int) (IntPtr) num5;
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
                goto label_11;
            }
            if (shA256 != null)
            {
              num5 = (short) 0;
              num4 = (int) (IntPtr) num5;
            }
            else
              break;
          }
label_11:;
        }
    }
  }

  internal static DeviceInfo WrapperDeviceInfo(this RadioParams radioPara)
  {
    short num1;
    DeviceInfo deviceInfo1;
    try
    {
      short num2 = 29798;
      int num3 = (int) num2;
      num2 = (short) 29798;
      int num4 = (int) num2;
      switch (num3 == num4)
      {
        case true:
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          DeviceInfo deviceInfo2 = new DeviceInfo();
          ConnectionInfo connectionInfo = new ConnectionInfo();
          connectionInfo.UniqueAddress = radioPara.ConnectionInfo.UniqueAddress;
          connectionInfo.ConnectionType = radioPara.ConnectionInfo.ConnectionType;
          connectionInfo.Location = radioPara.ConnectionInfo.Location;
          connectionInfo.InactivityTimeout = radioPara.ConnectionInfo.InactivityTimeout;
          deviceInfo2.Family = radioPara.Family;
          deviceInfo2.ConnectionInfo = connectionInfo;
          deviceInfo2.CodeplugVersion = radioPara.CodeplugVersion;
          deviceInfo2.ModelNumber = radioPara.ModelNumber;
          deviceInfo2.RadioID = radioPara.RadioID;
          deviceInfo2.RadioState = radioPara.RadioState;
          deviceInfo2.RadioStorage = radioPara.RadioStorage;
          deviceInfo2.ConnectionInfo.SessionID = radioPara.ConnectionInfo.SessionID;
          deviceInfo2.SerialNumber = radioPara.SerialNumber;
          deviceInfo2.SoftwareVersion = radioPara.HostVersion;
          deviceInfo1 = deviceInfo2;
          break;
        default:
          goto case 1;
      }
    }
    catch (Exception ex)
    {
      throw CommonExceptionHelper.CreateCommonException((CommonErrorCode) 1, Resources.GenericError, ex);
    }
    num1 = (short) 0;
    num1 = (short) 1;
    if (num1 == (short) 0)
      ;
    return deviceInfo1;
  }

  internal static bool Serialize(this AstroDeviceInfo astrodeviceInfo, string fileName)
  {
    short num1;
    try
    {
      short num2 = 26323;
      int num3 = (int) num2;
      num2 = (short) 26323;
      int num4 = (int) num2;
      switch (num3 == num4 ? 1 : 0)
      {
        case 0:
        case 2:
          break;
        default:
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          FileStream serializationStream = File.Create(fileName);
          try
          {
            new BinaryFormatter().Serialize((Stream) serializationStream, (object) astrodeviceInfo);
            break;
          }
          finally
          {
            short num5 = 1;
            int num6 = (int) (IntPtr) num5;
            while (true)
            {
              switch (num6)
              {
                case 0:
                  serializationStream.Dispose();
                  num5 = (short) 2;
                  num6 = (int) (IntPtr) num5;
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
                  goto label_10;
              }
              if (serializationStream != null)
              {
                num5 = (short) 0;
                num6 = (int) (IntPtr) num5;
              }
              else
                break;
            }
label_10:;
          }
      }
    }
    catch (Exception ex)
    {
      return false;
    }
    num1 = (short) 1;
    if (num1 == (short) 0)
      ;
    num1 = (short) 0;
    return true;
  }

  internal static AstroDeviceInfo Deserialize(this AstroDeviceInfo astrodeviceInfo, string fileName)
  {
    short num1 = 0;
    AstroDeviceInfo astroDeviceInfo = (AstroDeviceInfo) null;
    try
    {
      num1 = (short) -516;
      int num2 = (int) num1;
      num1 = (short) -516;
      int num3 = (int) num1;
      switch (num2 == num3 ? 1 : 0)
      {
        case 0:
        case 2:
          break;
        default:
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          FileStream serializationStream = File.OpenRead(fileName);
          try
          {
            astroDeviceInfo = new BinaryFormatter().Deserialize((Stream) serializationStream) as AstroDeviceInfo;
            break;
          }
          finally
          {
            int num4 = 1;
            while (true)
            {
              short num5;
              switch (num4)
              {
                case 0:
                  serializationStream.Dispose();
                  num5 = (short) 2;
                  num4 = (int) (IntPtr) num5;
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
                  goto label_13;
              }
              if (serializationStream != null)
              {
                num5 = (short) 0;
                num4 = (int) (IntPtr) num5;
              }
              else
                break;
            }
label_13:;
          }
      }
    }
    catch (Exception ex)
    {
      return (AstroDeviceInfo) null;
    }
    num1 = (short) 1;
    if (num1 == (short) 0)
      ;
    return astroDeviceInfo;
  }
}
