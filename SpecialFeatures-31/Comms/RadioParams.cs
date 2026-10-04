// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.Comms.RadioParams
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using Motorola.Common.Communication.CommonUtil;
using SpecialFeatures.AcpReportManagerLib;
using System;
using System.Runtime.Serialization;

#nullable disable
namespace SpecialFeatures.Comms;

[DataContract]
public class RadioParams
{
  [DataMember]
  private string m_SerialNumber;
  [DataMember]
  private byte[] m_ESerialNumber;
  [DataMember]
  private string m_ModelNumber;
  [DataMember]
  private Guid m_Uuid;
  [DataMember]
  private string m_RadioBBFVersion;
  [DataMember]
  private string m_HostVersion;
  [DataMember]
  private string m_DspVersion;
  [DataMember]
  private string m_CodeplugVersion;
  [DataMember]
  private string m_PsdtVersion;
  [DataMember]
  private string m_BootAppVersion;
  [DataMember]
  private string m_TuneVersion;
  [DataMember]
  private string m_FlashCode;
  [DataMember]
  private string m_OptBrdName;
  [DataMember]
  private string m_OptBrdHwType;
  [DataMember]
  private string m_OptBrdHwHostVersion;
  [DataMember]
  private string m_LTEOptBrdHwHostVersion;
  [DataMember]
  private string m_OptBrdFlashImageVersion;
  [DataMember]
  private string m_OptBrdFlashImageType;
  [DataMember]
  private bool m_OptBrdHwNotPresentFlag;
  [DataMember]
  private string m_ConBrdHwType;
  [DataMember]
  private string m_ConBrdHwHostVersion;
  private string a;
  private string b;
  private string c;

  public string SerialNumber
  {
    get
    {
      short num1 = 0;
      num1 = (short) 394;
      int num2 = (int) num1;
      num1 = (short) 394;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          num1 = (short) 1;
          if (num1 == (short) 0)
            ;
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          return this.m_SerialNumber;
        default:
          goto case 1;
      }
    }
    set
    {
      switch (true)
      {
        case true:
          short num = 0;
          if (num == (short) 0)
            ;
          num = (short) 1;
          if (num == (short) 0)
            ;
          this.m_SerialNumber = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  public byte[] ESerialNumber
  {
    get
    {
      short num1 = 0;
      num1 = (short) 24316;
      int num2 = (int) num1;
      num1 = (short) 24316;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          num1 = (short) 1;
          if (num1 == (short) 0)
            ;
          return this.m_ESerialNumber;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = 0;
      num1 = (short) -1258;
      int num2 = (int) num1;
      num1 = (short) -1258;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          num1 = (short) 1;
          if (num1 == (short) 0)
            ;
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          this.m_ESerialNumber = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  public string ModelNumber
  {
    get
    {
      short num1 = 1;
      if (num1 == (short) 0)
        ;
      num1 = (short) -13751;
      int num2 = (int) num1;
      num1 = (short) -13751;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          num1 = (short) 0;
          return this.m_ModelNumber;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = -6294;
      int num2 = (int) num1;
      num1 = (short) -6294;
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
          this.m_ModelNumber = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  public Guid Uuid
  {
    get
    {
      short num1 = 7799;
      int num2 = (int) num1;
      num1 = (short) 7799;
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
          return this.m_Uuid;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = -20980;
      int num2 = (int) num1;
      num1 = (short) -20980;
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
          this.m_Uuid = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  public string HostVersion
  {
    get
    {
      short num1 = -22380;
      int num2 = (int) num1;
      num1 = (short) -22380;
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
          return this.m_HostVersion;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = 930;
      int num2 = (int) num1;
      num1 = (short) 930;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          short num4 = 0;
          if (num4 == (short) 0)
            ;
          num4 = (short) 1;
          if (num4 == (short) 0)
            ;
          num4 = (short) 0;
          this.m_HostVersion = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  public string RadioBBFSuiteVersion
  {
    get
    {
      short num1 = 26837;
      int num2 = (int) num1;
      num1 = (short) 26837;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          short num4 = 0;
          if (num4 == (short) 0)
            ;
          num4 = (short) 1;
          if (num4 == (short) 0)
            ;
          num4 = (short) 0;
          return this.m_RadioBBFVersion;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = -18893;
      int num2 = (int) num1;
      num1 = (short) -18893;
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
          this.m_RadioBBFVersion = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  public string DspVersion
  {
    get
    {
      short num1 = -8314;
      int num2 = (int) num1;
      num1 = (short) -8314;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          short num4 = 0;
          if (num4 == (short) 0)
            ;
          num4 = (short) 1;
          if (num4 == (short) 0)
            ;
          num4 = (short) 0;
          return this.m_DspVersion;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = 29789;
      int num2 = (int) num1;
      num1 = (short) 29789;
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
          this.m_DspVersion = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  public string PsdtVersion
  {
    get
    {
      short num1 = 32724;
      int num2 = (int) num1;
      num1 = (short) 32724;
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
          return this.m_PsdtVersion;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = -23887;
      int num2 = (int) num1;
      num1 = (short) -23887;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          short num4 = 0;
          if (num4 == (short) 0)
            ;
          num4 = (short) 1;
          if (num4 == (short) 0)
            ;
          num4 = (short) 0;
          this.m_PsdtVersion = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  public string BootAppVersion
  {
    get
    {
      short num1 = -10090;
      int num2 = (int) num1;
      num1 = (short) -10090;
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
          return this.m_BootAppVersion;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = -6159;
      int num2 = (int) num1;
      num1 = (short) -6159;
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
          this.m_BootAppVersion = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  public string TuneVersion
  {
    get
    {
      short num1 = -23508;
      int num2 = (int) num1;
      num1 = (short) -23508;
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
          return this.m_TuneVersion;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = 26964;
      int num2 = (int) num1;
      num1 = (short) 26964;
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
          this.m_TuneVersion = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  public string CodeplugVersion
  {
    get
    {
      short num1 = -26515;
      int num2 = (int) num1;
      num1 = (short) -26515;
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
          return this.m_CodeplugVersion;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = 5708;
      int num2 = (int) num1;
      num1 = (short) 5708;
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
          this.m_CodeplugVersion = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  public string FlashCode
  {
    get
    {
      short num1 = -25199;
      int num2 = (int) num1;
      num1 = (short) -25199;
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
          return this.m_FlashCode;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = -18080;
      int num2 = (int) num1;
      num1 = (short) -18080;
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
          this.m_FlashCode = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  public string OptBoardName
  {
    get
    {
      short num1 = 22420;
      int num2 = (int) num1;
      num1 = (short) 22420;
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
          return this.m_OptBrdName;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = -27257;
      int num2 = (int) num1;
      num1 = (short) -27257;
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
          this.m_OptBrdName = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  public string OptBrdHardwareType
  {
    get
    {
      short num1 = 19401;
      int num2 = (int) num1;
      num1 = (short) 19401;
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
          return this.m_OptBrdHwType;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = -9081;
      int num2 = (int) num1;
      num1 = (short) -9081;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          short num4 = 0;
          if (num4 == (short) 0)
            ;
          num4 = (short) 1;
          if (num4 == (short) 0)
            ;
          num4 = (short) 0;
          this.m_OptBrdHwType = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  public string OptBrdHwHostVersion
  {
    get
    {
      short num1 = -25481;
      int num2 = (int) num1;
      num1 = (short) -25481;
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
          return this.m_OptBrdHwHostVersion;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = -5421;
      int num2 = (int) num1;
      num1 = (short) -5421;
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
          this.m_OptBrdHwHostVersion = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  public string LTEOptBrdHwHostVersion
  {
    get
    {
      short num1 = 29396;
      int num2 = (int) num1;
      num1 = (short) 29396;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          short num4 = 0;
          if (num4 == (short) 0)
            ;
          num4 = (short) 1;
          if (num4 == (short) 0)
            ;
          num4 = (short) 0;
          return this.m_LTEOptBrdHwHostVersion;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = 1;
      if (num1 == (short) 0)
        ;
      num1 = (short) 6448;
      int num2 = (int) num1;
      num1 = (short) 6448;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          num1 = (short) 0;
          this.m_LTEOptBrdHwHostVersion = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  public string OptBrdFlashImageVersion
  {
    get
    {
      short num1 = 1;
      if (num1 == (short) 0)
        ;
      num1 = (short) -15780;
      int num2 = (int) num1;
      num1 = (short) -15780;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          num1 = (short) 0;
          return this.m_OptBrdFlashImageVersion;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = 14438;
      int num2 = (int) num1;
      num1 = (short) 14438;
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
          this.m_OptBrdFlashImageVersion = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  public string OptBrdFlashImageType
  {
    get
    {
      short num1 = -2149;
      int num2 = (int) num1;
      num1 = (short) -2149;
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
          return this.m_OptBrdFlashImageType;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = 31704;
      int num2 = (int) num1;
      num1 = (short) 31704;
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
          this.m_OptBrdFlashImageType = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  public bool OptBrdHwNotPresentFlag
  {
    get
    {
      short num1 = -29210;
      int num2 = (int) num1;
      num1 = (short) -29210;
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
          return this.m_OptBrdHwNotPresentFlag;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = 26826;
      int num2 = (int) num1;
      num1 = (short) 26826;
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
          this.m_OptBrdHwNotPresentFlag = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  public string ConBrdHardwareType
  {
    get
    {
      short num1 = -32279;
      int num2 = (int) num1;
      num1 = (short) -32279;
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
          return this.m_ConBrdHwType;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = 2272;
      int num2 = (int) num1;
      num1 = (short) 2272;
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
          this.m_ConBrdHwType = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  public string ConBrdHwHostVersion
  {
    get
    {
      short num1 = -17618;
      int num2 = (int) num1;
      num1 = (short) -17618;
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
          return this.m_ConBrdHwHostVersion;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = 32545;
      int num2 = (int) num1;
      num1 = (short) 32545;
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
          this.m_ConBrdHwHostVersion = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  public string MaceFlashVersion
  {
    get
    {
      short num1 = -20380;
      int num2 = (int) num1;
      num1 = (short) -20380;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          short num4 = 0;
          if (num4 == (short) 0)
            ;
          num4 = (short) 1;
          if (num4 == (short) 0)
            ;
          num4 = (short) 0;
          return this.a;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = 7726;
      int num2 = (int) num1;
      num1 = (short) 7726;
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
          this.a = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  internal string MaceHardwareType
  {
    get
    {
      short num1 = 24902;
      int num2 = (int) num1;
      num1 = (short) 24902;
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
          return this.b;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = -20704;
      int num2 = (int) num1;
      num1 = (short) -20704;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          short num4 = 0;
          if (num4 == (short) 0)
            ;
          num4 = (short) 1;
          if (num4 == (short) 0)
            ;
          num4 = (short) 0;
          this.b = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  internal string MaceHardwareVersion
  {
    get
    {
      short num1 = 15327;
      int num2 = (int) num1;
      num1 = (short) 15327;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          short num4 = 0;
          if (num4 == (short) 0)
            ;
          num4 = (short) 1;
          if (num4 == (short) 0)
            ;
          num4 = (short) 0;
          return this.c;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = 114;
      int num2 = (int) num1;
      num1 = (short) 114;
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
          this.c = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  public override string ToString()
  {
    int A_1 = 13;
    short num1 = -27162;
    int num2 = (int) num1;
    num1 = (short) -27162;
    int num3 = (int) num1;
    switch (num2 == num3)
    {
      case true:
        short num4 = 0;
        if (num4 == (short) 0)
          ;
        num4 = (short) 1;
        if (num4 == (short) 0)
          ;
        num4 = (short) 0;
        return string.Format(RptMgrErrorHandler.b("슏\uF391\uF093ﾕ\uF797쪙ﶛ\uEC9D솟쾡힣躥ﮧ쾩\uDEAB잭톯\uDEB1荒쎵햷\uD8B9\uD9BB첽謹링\uF4C3믅\uE4C7\uEAC9臋ꇍ듏럑룓飕귗럙뻛믝鋟\uD8E1\u9FE3ퟥ闧웩쳫믭ꗯ믱냳쳵菷죹臻틽\u20FF䨁欃甅簇尉椋簍挏笑笓砕∗愙⼛挝టȡ怣唥堧簩䤫尭䌯嬱嬳堵ȷ䄹࠻䌽氿扁݃⥅ⱇ⽉㱋≍╏㕑ɓ㍕⩗⥙㕛ㅝ\u0E5F塡呣ṥ፧彩ᅫ䝭", A_1), (object) this.SerialNumber, (object) this.ModelNumber, (object) this.Uuid, (object) this.HostVersion, (object) this.DspVersion, (object) this.CodeplugVersion);
      default:
        goto case 1;
    }
  }

  public ProductFamily Family
  {
    get
    {
      short num1 = 29523;
      int num2 = (int) num1;
      num1 = (short) 29523;
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
          return this.d;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = -30572;
      int num2 = (int) num1;
      num1 = (short) -30572;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          short num4 = 0;
          if (num4 == (short) 0)
            ;
          num4 = (short) 1;
          if (num4 == (short) 0)
            ;
          num4 = (short) 0;
          this.d = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  public ConnectionInfo ConnectionInfo
  {
    get
    {
      short num1 = -24015;
      int num2 = (int) num1;
      num1 = (short) -24015;
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
          return this.e;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = 27849;
      int num2 = (int) num1;
      num1 = (short) 27849;
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
          this.e = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  public string RadioID
  {
    get
    {
      short num1 = -14588;
      int num2 = (int) num1;
      num1 = (short) -14588;
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
          return this.f;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = -32067;
      int num2 = (int) num1;
      num1 = (short) -32067;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          short num4 = 0;
          if (num4 == (short) 0)
            ;
          num4 = (short) 1;
          if (num4 == (short) 0)
            ;
          num4 = (short) 0;
          this.f = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  public RadioState RadioState
  {
    get
    {
      short num1 = -5314;
      int num2 = (int) num1;
      num1 = (short) -5314;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          short num4 = 0;
          if (num4 == (short) 0)
            ;
          num4 = (short) 0;
          num4 = (short) 1;
          if (num4 == (short) 0)
            ;
          return this.g;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = -29758;
      int num2 = (int) num1;
      num1 = (short) -29758;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          short num4 = 1;
          if (num4 == (short) 0)
            ;
          num4 = (short) 0;
          num4 = (short) 0;
          if (num4 == (short) 0)
            ;
          this.g = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  public RadioStorage RadioStorage
  {
    get
    {
      short num1 = -23140;
      int num2 = (int) num1;
      num1 = (short) -23140;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          short num4 = 1;
          if (num4 == (short) 0)
            ;
          num4 = (short) 0;
          num4 = (short) 0;
          if (num4 == (short) 0)
            ;
          return this.h;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = -23678;
      int num2 = (int) num1;
      num1 = (short) -23678;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          short num4 = 0;
          if (num4 == (short) 0)
            ;
          num4 = (short) 0;
          num4 = (short) 1;
          if (num4 == (short) 0)
            ;
          this.h = value;
          break;
        default:
          goto case 1;
      }
    }
  }
}
