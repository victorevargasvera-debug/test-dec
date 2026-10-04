// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.SpecialFeaturesSettings
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using SpecialFeatures.AcpReportManagerLib;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

#nullable disable
namespace SpecialFeatures;

[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "14.0.0.0")]
[CompilerGenerated]
internal sealed class SpecialFeaturesSettings : ApplicationSettingsBase
{
  private static SpecialFeaturesSettings a;

  private void a(object A_0, SettingChangingEventArgs A_1)
  {
    short num1 = 10623;
    int num2 = (int) num1;
    num1 = (short) 10623;
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
          break;
        break;
      default:
        num4 = (short) 0;
        goto case 1;
    }
  }

  private void a(object A_0, CancelEventArgs A_1)
  {
    short num1 = -24543;
    int num2 = (int) num1;
    num1 = (short) -24543;
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
          break;
        break;
      default:
        num4 = (short) 0;
        goto case 1;
    }
  }

  public static SpecialFeaturesSettings Default
  {
    get
    {
      short num1 = -19242;
      int num2 = (int) num1;
      num1 = (short) -19242;
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
          return SpecialFeaturesSettings.a;
        default:
          num4 = (short) 0;
          goto case 1;
      }
    }
  }

  [DebuggerNonUserCode]
  [UserScopedSetting]
  [DefaultSettingValue("Please select wav file location.")]
  public string VA_WAV_FILE_LOCATION
  {
    get
    {
      int A_1 = 5;
      short num1 = 1;
      if (num1 == (short) 0)
        ;
      num1 = (short) 0;
      num1 = (short) 9980;
      int num2 = (int) num1;
      num1 = (short) 9980;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          return (string) this[RptMgrErrorHandler.b("\uDE87쮉펋\uD98D톏쒑쮓킕톗횙\uD99B솝\uEC9F\uEDA1\uE7A3\uE7A5ﲧ\uE3A9\uE3AB\uE0AD", A_1)];
        default:
          goto case 1;
      }
    }
    set
    {
      int A_1 = 14;
      short num1 = -14944;
      int num2 = (int) num1;
      num1 = (short) -14944;
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
          this[RptMgrErrorHandler.b("자튒쪔삖\uD898춚슜\uD99E\uE8A0\uEFA2\uE0A4\uF8A6\uE5A8\uE4AA\uEEAC\uEEAE\uE5B0者華禮", A_1)] = (object) value;
          break;
        default:
          num4 = (short) 0;
          goto case 1;
      }
    }
  }

  [DefaultSettingValue("Please select voice file storage location.")]
  [UserScopedSetting]
  [DebuggerNonUserCode]
  public string VA_MVA_FILE_LOCATION
  {
    get
    {
      int A_1 = 3;
      short num1 = -12531;
      int num2 = (int) num1;
      num1 = (short) -12531;
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
          return (string) this[RptMgrErrorHandler.b("킅즇행솋\uD88D톏춑튓\uDF95풗\uDF99쎛튝\uEF9F\uE1A1\uE5A3\uF2A5\uE1A7\uE5A9\uE2AB", A_1)];
        default:
          num4 = (short) 0;
          goto case 1;
      }
    }
    set
    {
      int A_1 = 15;
      short num1 = -22953;
      int num2 = (int) num1;
      num1 = (short) -22953;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          if (true)
            ;
          if (false)
            ;
          this[RptMgrErrorHandler.b("쒑햓즕햗척\uDD9B솝\uE69F\uEBA1\uE8A3\uE3A5\uF7A7\uE6A9\uE3AB\uEDAD\uF1AF\uE6B1ﶳ例\uF6B7", A_1)] = (object) value;
          break;
        default:
          goto case 1;
      }
    }
  }

  [DefaultSettingValue("Please select voice file download location.")]
  [DebuggerNonUserCode]
  [UserScopedSetting]
  public string VA_DOWNLOAD_FILE_LOCATION
  {
    get
    {
      int A_1 = 8;
      short num1 = -24835;
      int num2 = (int) num1;
      num1 = (short) -24835;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          if (false)
            ;
          if (true)
            ;
          return (string) this[RptMgrErrorHandler.b("\uDD8A첌킎햐\uDC92슔\uD996햘풚\uDC9C\uDB9Eﺠ\uE5A2\uECA4\uEBA6\uECA8\uF4AA\uE1AC\uE0AE\uF2B0\uF2B2\uE1B4ﺶ\uF6B8\uF5BA", A_1)];
        default:
          goto case 1;
      }
    }
    set
    {
      int A_1 = 19;
      short num1 = 15774;
      int num2 = (int) num1;
      num1 = (short) 15774;
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
          this[RptMgrErrorHandler.b("삕\uD997얙\uD89B톝\uF79F\uECA1\uE8A3\uE9A5\uE9A7\uEEA9\uF3AB\uE8AD羚ﺱ\uF1B3\uE9B5\uF4B7\uF5B9ﾻﾽ钿证诃装", A_1)] = (object) value;
          break;
        default:
          num4 = (short) 0;
          goto case 1;
      }
    }
  }

  [DefaultSettingValue("3")]
  [UserScopedSetting]
  [DebuggerNonUserCode]
  public string OTAP_CPS_SESSION_INACTIVITY_TIMER
  {
    get
    {
      int A_1 = 6;
      short num1 = 26692;
      int num2 = (int) num1;
      num1 = (short) 26692;
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
          return (string) this[RptMgrErrorHandler.b("욈\uDF8A첌\uDF8E캐킒얔쒖욘좚\uD89C첞\uF2A0\uEAA2\uEAA4\uE9A6\uF6A8\uE2AA\uE3AC\uEEAE\uF2B0\uE7B2ﲴ\uE1B6\uF0B8\uEFBA\uE4BC\uE0BE闀諂裄苆鯈", A_1)];
        default:
          num4 = (short) 0;
          goto case 1;
      }
    }
    set
    {
      int A_1 = 13;
      short num1 = -17469;
      int num2 = (int) num1;
      num1 = (short) -17469;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          if (false)
            ;
          if (true)
            ;
          this[RptMgrErrorHandler.b("\uDF8F욑햓욕잗\uD999첛춝ﾟ\uF1A1\uE1A3\uF5A5ﮧ\uE3A9\uE3AB\uE0AD\uEFAFﮱ荒\uF7B5﮷\uEEB9\uF5BB\uE8BD覿雁鷃駅鳇菉臋词苏", A_1)] = (object) value;
          break;
        default:
          goto case 1;
      }
    }
  }

  [DebuggerNonUserCode]
  [DefaultSettingValue("Please select the location for Radio List.")]
  [UserScopedSetting]
  public string OTAP_BATCH_RADIO_LIST_LOCATION
  {
    get
    {
      int A_1 = 7;
      short num1 = 1;
      if (num1 == (short) 0)
        ;
      num1 = (short) 0;
      num1 = (short) -3691;
      int num2 = (int) num1;
      num1 = (short) -3691;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          return (string) this[RptMgrErrorHandler.b("얉\uD88B쾍삏춑횓힕첗\uD999풛솝\uF29F\uE3A1\uE0A3\uEFA5\uE7A7\uF5A9\uE0AB\uE7AD\uE3AF\uE6B1\uEBB3蝹\uF7B7惡ﶻ\uEABD覿跁諃", A_1)];
        default:
          goto case 1;
      }
    }
    set
    {
      int A_1 = 3;
      short num1 = -10695;
      int num2 = (int) num1;
      num1 = (short) -10695;
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
          this[RptMgrErrorHandler.b("즅\uDC87쮉\uDC8B톍튏펑삓햕킗얙캛\uDF9D\uE49F\uEBA1\uEBA3殮\uE4A7\uE3A9ﾫ節\uEFAFﺱ﮳\uF5B5醴\uEEB9\uF5BB\uF1BD躿", A_1)] = (object) value;
          break;
        default:
          num4 = (short) 0;
          goto case 1;
      }
    }
  }

  [DebuggerNonUserCode]
  [DefaultSettingValue("2")]
  [UserScopedSetting]
  public string OTAP_BATCH_NUM_RETRIES_FOR_FAILED_RADIOS
  {
    get
    {
      int A_1 = 5;
      short num1 = -20546;
      int num2 = (int) num1;
      num1 = (short) -20546;
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
          return (string) this[RptMgrErrorHandler.b("잇\uDE89춋\uDE8D쾏킑햓슕\uDB97튙쎛킝\uF59F\uEFA1ﮣ\uF4A5\uEDA7ﺩﺫ\uE7AD\uF5AF\uE1B1\uEBB3\uF0B5\uF7B7\uE8B9\uE3BB\uF8BD膿证裃菅資闉黋迍铏鯑鯓藕", A_1)];
        default:
          num4 = (short) 0;
          goto case 1;
      }
    }
    set
    {
      int A_1 = 8;
      short num1 = 4186;
      int num2 = (int) num1;
      num1 = (short) 4186;
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
          this[RptMgrErrorHandler.b("쒊\uD98C캎손첒힔횖춘\uD89A햜삞\uEFA0\uF6A2\uE8A4\uF8A6ﮨ\uEEAA怜ﶮ\uF8B0\uF6B2\uE6B4\uE8B6ﾸ\uF4BA\uEFBC\uE0BE蟀苂賄识賈迊鋌鷎郐韒鳔飖諘", A_1)] = (object) value;
          break;
        default:
          num4 = (short) 0;
          goto case 1;
      }
    }
  }

  [UserScopedSetting]
  [DebuggerNonUserCode]
  [DefaultSettingValue("False")]
  public bool OTAP_BATCH_WRITE_PROTECT_RADIOS
  {
    get
    {
      int A_1 = 7;
      short num1 = -11965;
      int num2 = (int) num1;
      num1 = (short) -11965;
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
          return (bool) this[RptMgrErrorHandler.b("얉\uD88B쾍삏춑횓힕첗\uD999풛솝\uF79F\uF0A1\uEDA3\uF2A5\uEDA7\uF5A9ﲫﲭﾯ\uE6B1\uF1B3\uF5B5\uECB7\uE5B9\uEEBBﾽ蒿证诃闅", A_1)];
        default:
          num4 = (short) 0;
          goto case 1;
      }
    }
    set
    {
      int A_1 = 14;
      short num1 = 22994;
      int num2 = (int) num1;
      num1 = (short) 22994;
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
          this[RptMgrErrorHandler.b("\uDE90잒풔잖욘\uD99A\uDC9C쮞\uE2A0\uEBA2瘝\uF0A6ﮨ\uE2AA怜\uEAAE\uEEB0\uE3B2\uE7B4\uF8B6\uEDB8ﺺﺼ\uEBBE黀釂蓄菆胈蓊黌", A_1)] = (object) value;
          break;
        default:
          num4 = (short) 0;
          goto case 1;
      }
    }
  }

  [UserScopedSetting]
  [DefaultSettingValue("False")]
  [DebuggerNonUserCode]
  public bool OTAP_BATCH_ENABLE_ARS_SERVER_IP_ADDRESS
  {
    get
    {
      int A_1 = 17;
      short num1 = -16545;
      int num2 = (int) num1;
      num1 = (short) -16545;
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
          return (bool) this[RptMgrErrorHandler.b("\uDB93슕\uD997쪙쎛\uDC9D\uE19F\uF6A1\uE7A3\uEEA5\uF7A7\uEFA9\uE2AB\uEFAD\uF2AFﺱ\uF1B3\uE9B5醴\uE8B9\uEFBB\uE1BD鎿蟁雃郅跇飉鏋蟍胏跑闓鋕鳗裙駛距돟", A_1)];
        default:
          num4 = (short) 0;
          goto case 1;
      }
    }
    set
    {
      int A_1 = 18;
      short num1 = 1;
      if (num1 == (short) 0)
        ;
      num1 = (short) 0;
      num1 = (short) 13707;
      int num2 = (int) num1;
      num1 = (short) 13707;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          this[RptMgrErrorHandler.b("\uDA94쎖\uD898쮚슜\uDD9E\uE0A0\uF7A2\uE6A4\uEFA6\uF6A8\uEEAA\uE3AC\uEEAE\uF3B0ﾲ\uF0B4\uE8B6\uF8B8\uE9BA\uEEBC\uE0BE鋀蛂韄釆賈駊鋌蛎臐賒铔鏖鷘觚飜賞닠", A_1)] = (object) value;
          break;
        default:
          goto case 1;
      }
    }
  }

  [UserScopedSetting]
  [DebuggerNonUserCode]
  [DefaultSettingValue("0.0.0.0")]
  public string OTAP_ARS_IP_ADDRESS
  {
    get
    {
      int A_1 = 3;
      short num1 = -6877;
      int num2 = (int) num1;
      num1 = (short) -6877;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          if (false)
            ;
          if (true)
            ;
          return (string) this[RptMgrErrorHandler.b("즅\uDC87쮉\uDC8B톍톏삑잓즕톗쪙쎛\uDF9D\uE49F\uE6A1\uF6A3\uE3A5ﮧ囹", A_1)];
        default:
          goto case 1;
      }
    }
    set
    {
      int A_1 = 4;
      short num1 = -6112;
      int num2 = (int) num1;
      num1 = (short) -6112;
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
          this[RptMgrErrorHandler.b("좆\uDD88쪊\uDD8C킎킐솒요좖킘쮚슜\uDE9E\uE5A0\uE7A2\uF7A4\uE2A6直\uF8AA", A_1)] = (object) value;
          break;
        default:
          num4 = (short) 0;
          goto case 1;
      }
    }
  }

  [DebuggerNonUserCode]
  [DefaultSettingValue("False")]
  [UserScopedSetting]
  public bool OTAP_ARS_IP_CHKBOX
  {
    get
    {
      int A_1 = 6;
      short num1 = 12224;
      int num2 = (int) num1;
      num1 = (short) 12224;
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
          return (bool) this[RptMgrErrorHandler.b("욈\uDF8A첌\uDF8E캐튒잔쒖욘튚출삞\uE2A0\uEBA2\uEEA4\uE5A6\uE6A8\uF3AA", A_1)];
        default:
          goto case 1;
      }
    }
    set
    {
      int A_1 = 11;
      short num1 = -22082;
      int num2 = (int) num1;
      num1 = (short) -22082;
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
          this[RptMgrErrorHandler.b("속쒏펑쒓즕\uD997좙쾛솝\uE99F\uF2A1ﮣ\uE5A5\uE0A7\uE1A9\uEEAB\uE1AD\uE8AF", A_1)] = (object) value;
          break;
        default:
          num4 = (short) 0;
          goto case 1;
      }
    }
  }

  static SpecialFeaturesSettings()
  {
    short num1 = -8468;
    int num2 = (int) num1;
    num1 = (short) -8468;
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
        // ISSUE: reference to a compiler-generated field
        // ISSUE: object of a compiler-generated type is created
        SpecialFeaturesSettings.a = (SpecialFeaturesSettings) SettingsBase.Synchronized((SettingsBase) new SpecialFeaturesSettings());
        break;
      default:
        num4 = (short) 0;
        goto case 1;
    }
  }
}
