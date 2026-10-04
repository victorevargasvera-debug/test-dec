// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.Clone_Configuration.Common.WiFiPasswordUtil
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using AcpBusinessLayer;
using AcpCommonLib;
using AcpUI.Common;
using Common;
using CommonResources;
using Motorola.MackinawCPS.CoreFeatures.DataWide;
using SpecialFeatures.AcpReportManagerLib;
using SpecialFeatures.CloneWiFi;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Timers;
using System.Windows;

#nullable disable
namespace SpecialFeatures.Clone_Configuration.Common;

public class WiFiPasswordUtil
{
  private static List<string> a;
  private static int b;
  private const int c = 1000;
  private const int d = 900000;
  private static System.Timers.Timer e;
  private static bool f;
  private static readonly Dictionary<string, string> g;
  private static readonly Dictionary<string, string> h;
  private static ClearAndRestorePassword i;

  static WiFiPasswordUtil()
  {
    short num1 = 0;
    num1 = (short) -10191;
    int num2 = (int) num1;
    num1 = (short) -10191;
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
        WiFiPasswordUtil.a = new List<string>();
        WiFiPasswordUtil.b = 1;
        WiFiPasswordUtil.f = true;
        WiFiPasswordUtil.g = new Dictionary<string, string>();
        WiFiPasswordUtil.h = new Dictionary<string, string>();
        WiFiPasswordUtil.e = new System.Timers.Timer(900000.0);
        WiFiPasswordUtil.e.Elapsed += new ElapsedEventHandler(WiFiPasswordUtil.a);
        WiFiPasswordUtil.e.AutoReset = false;
        break;
      default:
        goto case 1;
    }
  }

  public static void UpdateCipherPasswordsToPlain()
  {
    int A_1 = 9;
    int num1 = 0;
    switch (num1)
    {
      default:
        ConfiguredNetworksListInnerRecset embeddedRecset;
        short num2;
        switch (0)
        {
          case 0:
label_3:
            embeddedRecset = ((FeatureSection) (FeatureManager.GetFeature(2028)[0] as Motorola.MackinawCPS.CoreFeatures.DataWide.DataWide).WIFI).EmbeddedRecset as ConfiguredNetworksListInnerRecset;
            num2 = (short) 1;
            num1 = (int) (IntPtr) num2;
            goto default;
          default:
            IEnumerator<FeatureNode> enumerator;
            ExternalDataModem externalDataModem;
            while (true)
            {
              switch (num1)
              {
                case 0:
                  goto label_33;
                case 1:
                  if (embeddedRecset == null)
                  {
                    num2 = (short) 0;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 1;
                  if (num2 == (short) 0)
                    ;
                  WiFiPasswordUtil.a.Clear();
                  enumerator = ((Collection<FeatureNode>) embeddedRecset).GetEnumerator();
                  num2 = (short) 3;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 2:
                  goto label_34;
                case 3:
                  try
                  {
                    num2 = (short) 2;
                    num1 = (int) (IntPtr) num2;
                    while (true)
                    {
                      ConfiguredNetworksListInner current;
                      switch (num1)
                      {
                        case 0:
                          num2 = (short) 5;
                          num1 = (int) (IntPtr) num2;
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
                          string str = AESCryptoUtil.AESDecryptWithDefKey_ForWiFiPassword(((AcpField<string>) current.ConfiguredNetworksListInnerSection.DataWideWiFiNetworkEncryptedNetworkPassword_42517).Value);
                          ((AcpField<string>) current.ConfiguredNetworksListInnerSection.DataWideWiFiNetworkEncryptedNetworkPassword_42517).SetValue(string.Empty);
                          WiFiPasswordUtil.a.Add(str);
                          num2 = (short) 1;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        case 4:
                          if (enumerator.MoveNext())
                          {
                            current = enumerator.Current as ConfiguredNetworksListInner;
                            num2 = (short) 6;
                            num1 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 0;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        case 5:
                          goto label_6;
                        case 6:
                          if (current != null)
                          {
                            num2 = (short) 3;
                            num1 = (int) (IntPtr) num2;
                            continue;
                          }
                          break;
                      }
                      num2 = (short) 4;
                      num1 = (int) (IntPtr) num2;
                    }
                  }
                  finally
                  {
                    short num3 = 19784;
                    int num4 = (int) num3;
                    num3 = (short) 19784;
                    int num5 = (int) num3;
                    switch (num4 == num5 ? 1 : 0)
                    {
                      case 0:
                      case 2:
                        while (true)
                        {
                          switch (num1)
                          {
                            case 0:
                              goto label_30;
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
                              enumerator.Dispose();
                              num3 = (short) 0;
                              num1 = (int) (IntPtr) num3;
                              continue;
                          }
                          if (enumerator != null)
                          {
                            num3 = (short) 2;
                            num1 = (int) (IntPtr) num3;
                          }
                          else
                            break;
                        }
label_30:;
                      default:
                        num3 = (short) 0;
                        if (num3 == (short) 0)
                          ;
                        num3 = (short) 1;
                        num1 = (int) (IntPtr) num3;
                        goto case 0;
                    }
                  }
label_6:
                  num2 = (short) 5;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 4:
                  goto label_36;
                case 5:
                  if (FeatureManager.GetFeature(2028)[0] is Motorola.MackinawCPS.CoreFeatures.DataWide.DataWide dataWide)
                  {
                    externalDataModem = dataWide.ExternalDataModem;
                    if (externalDataModem == null)
                    {
                      num2 = (short) 4;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    }
                    goto label_31;
                  }
                  num2 = (short) 2;
                  num1 = (int) (IntPtr) num2;
                  continue;
                default:
                  goto label_3;
              }
            }
label_33:
            return;
label_31:
            IAcpRecordset iacpRecordset = ((FeatureSection) externalDataModem).EmbeddedRecset;
            goto label_37;
label_34:
            num2 = (short) 0;
            iacpRecordset = (IAcpRecordset) null;
            goto label_37;
label_36:
            iacpRecordset = (IAcpRecordset) null;
label_37:
            WiFiPasswordUtil.i = new ClearAndRestorePassword(iacpRecordset as Recordset, RptMgrErrorHandler.b("좋\uEF8D\uE48F\uF391쎓ﾕﲗﾙ\uD99B\uF09D쎟킡\uDDA3횥\uDCA7쾩좫\uE0AD햯욱쎳\uD9B5쪷톹\uECBB\uDFBD뎿뇁돃꧅뫇껉鏋鬒\uE3CF\uE1D1\uE2D3\uE7D5", A_1));
            WiFiPasswordUtil.i.ClearFieldsAndRemember(new Func<string, string>(AESCryptoUtil.AESDecryptWithDefKey_ForWiFiPassword));
            return;
        }
    }
  }

  public static void RestorePlainPasswordToCipher()
  {
    int num1 = 0;
    switch (num1)
    {
      default:
        short num2 = 18033;
        int num3 = (int) num2;
        num2 = (short) 18033;
        int num4 = (int) num2;
        ConfiguredNetworksListInnerRecset embeddedRecset;
        int index;
        switch (num3 == num4 ? 1 : 0)
        {
          case 0:
          case 2:
label_6:
            if (embeddedRecset == null)
            {
              num2 = (short) 4;
              num1 = (int) (IntPtr) num2;
              break;
            }
            index = 0;
            num2 = (short) 2;
            num1 = (int) (IntPtr) num2;
            break;
          default:
            num2 = (short) 0;
            if (num2 == (short) 0)
              ;
            switch (0)
            {
              case 0:
                goto label_5;
            }
            break;
        }
        while (true)
        {
          ConfiguredNetworksListInner networksListInner;
          switch (num1)
          {
            case 0:
              goto label_6;
            case 1:
              goto label_19;
            case 2:
            case 3:
              num2 = (short) 6;
              num1 = (int) (IntPtr) num2;
              continue;
            case 4:
              goto label_18;
            case 5:
              num2 = (short) 0;
              string str = AESCryptoUtil.AESEncryptWithDefKey_ForWiFiPassword(WiFiPasswordUtil.a[index]);
              ((AcpField<string>) networksListInner.ConfiguredNetworksListInnerSection.DataWideWiFiNetworkEncryptedNetworkPassword_42517).SetValue(str);
              num2 = (short) 7;
              num1 = (int) (IntPtr) num2;
              continue;
            case 6:
              if (index < ((Recordset) embeddedRecset).Count)
              {
                networksListInner = ((Recordset) embeddedRecset)[index] as ConfiguredNetworksListInner;
                num2 = (short) 8;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              num2 = (short) 1;
              if (num2 == (short) 0)
                ;
              num2 = (short) 1;
              num1 = (int) (IntPtr) num2;
              continue;
            case 7:
              ++index;
              num2 = (short) 3;
              num1 = (int) (IntPtr) num2;
              continue;
            case 8:
              if (networksListInner != null)
              {
                num2 = (short) 5;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 7;
            default:
              goto label_5;
          }
label_4:;
        }
label_18:
        break;
label_19:
        WiFiPasswordUtil.i.RestorePasswordsAndForgot(new Func<string, string>(AESCryptoUtil.AESEncryptWithDefKey_ForWiFiPassword));
        break;
label_5:
        embeddedRecset = ((FeatureSection) (FeatureManager.GetFeature(2028)[0] as Motorola.MackinawCPS.CoreFeatures.DataWide.DataWide).WIFI).EmbeddedRecset as ConfiguredNetworksListInnerRecset;
        num2 = (short) 0;
        num1 = (int) (IntPtr) num2;
        goto label_4;
    }
  }

  private static void a(object A_0, ElapsedEventArgs A_1)
  {
    short num1 = 0;
    num1 = (short) 22484;
    int num2 = (int) num1;
    num1 = (short) 22484;
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
        WiFiPasswordUtil.ResetSessionTimer();
        break;
      default:
        goto case 1;
    }
  }

  internal static bool NeedValidation()
  {
    short num1 = 0;
    num1 = (short) -30650;
    int num2 = (int) num1;
    num1 = (short) -30650;
    int num3 = (int) num1;
    switch (num2 == num3 ? 1 : 0)
    {
      case 0:
      case 2:
        return WiFiPasswordUtil.b();
      default:
        num1 = (short) 1;
        if (num1 == (short) 0)
          ;
        num1 = (short) 0;
        if (num1 == (short) 0)
          ;
        if (WiFiPasswordUtil.c())
          return true;
        goto case 0;
    }
  }

  private static bool c()
  {
    int num1;
    Motorola.MackinawCPS.CoreFeatures.DataWide.DataWide dataWide;
    short num2;
    switch (0)
    {
      case 0:
label_2:
        dataWide = FeatureManager.GetFeature(2028)[0] as Motorola.MackinawCPS.CoreFeatures.DataWide.DataWide;
        num2 = (short) 1;
        num1 = (int) (IntPtr) num2;
        goto default;
      default:
        ConfiguredNetworksListInnerRecset embeddedRecset;
        bool isUpdated;
        while (true)
        {
          switch (num1)
          {
            case 0:
              num2 = (short) 4;
              num1 = (int) (IntPtr) num2;
              continue;
            case 1:
              if (dataWide != null)
              {
                num2 = (short) 0;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_9;
            case 2:
              goto label_21;
            case 3:
              goto label_10;
            case 4:
              num2 = (short) -23478;
              int num3 = (int) num2;
              num2 = (short) -23478;
              int num4 = (int) num2;
              switch (num3 == num4 ? 1 : 0)
              {
                case 0:
                case 2:
                  goto label_17;
                default:
                  num2 = (short) 0;
                  if (num2 == (short) 0)
                    ;
                  if (!dataWide.WIFI.DataWideWIFIEnable_42506.Value)
                  {
                    num2 = (short) 1;
                    if (num2 == (short) 0)
                      ;
                    num2 = (short) 7;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  embeddedRecset = ((FeatureSection) dataWide.WIFI).EmbeddedRecset as ConfiguredNetworksListInnerRecset;
                  num2 = (short) 5;
                  num1 = (int) (IntPtr) num2;
                  continue;
              }
            case 5:
              if (embeddedRecset != null)
              {
                isUpdated = false;
                num2 = (short) 10;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              num2 = (short) 2;
              num1 = (int) (IntPtr) num2;
              continue;
            case 6:
              num2 = (short) 8;
              num1 = (int) (IntPtr) num2;
              continue;
            case 7:
              goto label_17;
            case 8:
              if (WiFiPasswordUtil.IsTimerRefreshedAndWiFiPasswordValidationSkept(isUpdated))
              {
                num2 = (short) 3;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_25;
            case 9:
              isUpdated = WiFiPasswordUtil.a(embeddedRecset);
              num2 = (short) 6;
              num1 = (int) (IntPtr) num2;
              continue;
            case 10:
              if (WiFiPasswordUtil.g.Count != 0)
              {
                num2 = (short) 9;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 6;
            default:
              goto label_2;
          }
        }
label_9:
        return false;
label_10:
        return false;
label_17:
        num2 = (short) 0;
        goto label_9;
label_21:
        return false;
label_25:
        return WiFiPasswordUtil.b(embeddedRecset);
    }
  }

  private static bool b()
  {
    int num;
    Motorola.MackinawCPS.CoreFeatures.DataWide.DataWide dataWide;
    switch (0)
    {
      case 0:
label_4:
        dataWide = FeatureManager.GetFeature(2028)[0] as Motorola.MackinawCPS.CoreFeatures.DataWide.DataWide;
        num = 0;
        goto default;
      default:
        DataModemTableInnerRecset embeddedRecset;
        while (true)
        {
          switch (true ? 1 : 0)
          {
            case 0:
            case 2:
label_11:
              if (WiFiPasswordUtil.h.Count != 0)
              {
                if (false)
                  ;
                num = 6;
                continue;
              }
              break;
            default:
              if (true)
                ;
              bool isUpdated;
              switch (num)
              {
                case 0:
                  if (dataWide != null)
                  {
                    num = 4;
                    continue;
                  }
                  goto label_18;
                case 1:
                  if (AcpField<int>.op_Implicit((AcpField<int>) dataWide.ExternalDataModem.ModemConnectionType_43350) == 1)
                  {
                    embeddedRecset = ((FeatureSection) dataWide.ExternalDataModem).EmbeddedRecset as DataModemTableInnerRecset;
                    isUpdated = false;
                    num = 5;
                    continue;
                  }
                  num = 2;
                  continue;
                case 2:
                  goto label_18;
                case 3:
                  if (WiFiPasswordUtil.IsTimerRefreshedAndWiFiPasswordValidationSkept(isUpdated))
                  {
                    num = 8;
                    continue;
                  }
                  goto label_20;
                case 4:
                  num = 1;
                  continue;
                case 5:
                  goto label_11;
                case 6:
                  isUpdated = WiFiPasswordUtil.a(embeddedRecset);
                  num = 7;
                  continue;
                case 7:
                  break;
                case 8:
                  goto label_17;
                default:
                  goto label_4;
              }
              break;
          }
          num = 3;
        }
label_17:
        return false;
label_18:
        return false;
label_20:
        return WiFiPasswordUtil.b(embeddedRecset);
    }
  }

  public static bool IsTimerRefreshedAndWiFiPasswordValidationSkept(bool isUpdated)
  {
    short num1 = 1;
    if (num1 == (short) 0)
      ;
    num1 = (short) 0;
    int num2 = (int) (IntPtr) num1;
    while (true)
    {
      switch (num2)
      {
        case 0:
label_2:
          switch (0)
          {
            case 0:
              break;
            default:
              continue;
          }
          break;
        case 1:
          if (!isUpdated)
          {
            num1 = (short) -3256;
            int num3 = (int) num1;
            num1 = (short) -3256;
            int num4 = (int) num1;
            switch (num3 == num4 ? 1 : 0)
            {
              case 0:
              case 2:
                goto label_2;
              default:
                num1 = (short) 0;
                if (num1 == (short) 0)
                  ;
                num1 = (short) 2;
                num2 = (int) (IntPtr) num1;
                continue;
            }
          }
          else
            goto label_12;
        case 2:
          goto label_6;
        case 3:
          num1 = (short) 1;
          num2 = (int) (IntPtr) num1;
          continue;
      }
      num1 = (short) 0;
      if (!WiFiPasswordUtil.f)
      {
        num1 = (short) 3;
        num2 = (int) (IntPtr) num1;
      }
      else
        goto label_12;
    }
label_6:
    WiFiPasswordUtil.RefreshSessionTimer();
    return true;
label_12:
    return false;
  }

  private static bool b(ConfiguredNetworksListInnerRecset A_0)
  {
    short num1 = 1;
    if (num1 == (short) 0)
      ;
    bool flag = false;
    IEnumerator<FeatureNode> enumerator = ((Collection<FeatureNode>) A_0).GetEnumerator();
    int num2;
    try
    {
      num1 = (short) 0;
      num2 = (int) (IntPtr) num1;
      while (true)
      {
        ConfiguredNetworksListInner current;
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
            flag = true;
            num1 = (short) 2;
            num2 = (int) (IntPtr) num1;
            continue;
          case 2:
          case 7:
            goto label_25;
          case 3:
            num1 = (short) 6;
            num2 = (int) (IntPtr) num1;
            continue;
          case 4:
            if (current != null)
            {
              num1 = (short) 3;
              num2 = (int) (IntPtr) num1;
              continue;
            }
            break;
          case 5:
            num1 = (short) 7;
            num2 = (int) (IntPtr) num1;
            continue;
          case 6:
            if (((AcpField<int>) current.ConfiguredNetworksListInnerSection.DataWideWiFiNetworkSecurityType_42516).Value != 0)
            {
              num1 = (short) 1;
              num2 = (int) (IntPtr) num1;
              continue;
            }
            break;
          case 8:
            if (enumerator.MoveNext())
            {
              current = enumerator.Current as ConfiguredNetworksListInner;
              num1 = (short) 4;
              num2 = (int) (IntPtr) num1;
              continue;
            }
            num1 = (short) 5;
            num2 = (int) (IntPtr) num1;
            continue;
        }
        num1 = (short) 8;
        num2 = (int) (IntPtr) num1;
      }
    }
    finally
    {
      short num3 = -26360;
      int num4 = (int) num3;
      num3 = (short) -26360;
      int num5 = (int) num3;
      switch (num4 == num5 ? 1 : 0)
      {
        case 0:
        case 2:
          while (true)
          {
            switch (num2)
            {
              case 0:
                goto label_24;
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
                enumerator.Dispose();
                num3 = (short) 0;
                num2 = (int) (IntPtr) num3;
                continue;
            }
            if (enumerator != null)
            {
              num3 = (short) 2;
              num2 = (int) (IntPtr) num3;
            }
            else
              break;
          }
label_24:;
        default:
          num3 = (short) 0;
          if (num3 == (short) 0)
            ;
          num3 = (short) 1;
          num2 = (int) (IntPtr) num3;
          goto case 0;
      }
    }
label_25:
    num1 = (short) 0;
    return flag;
  }

  private static bool b(DataModemTableInnerRecset A_0)
  {
    short num1 = 0;
    num1 = (short) 29764;
    int num2 = (int) num1;
    num1 = (short) 29764;
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
        return ((Recordset) A_0).Count > 0;
      default:
        goto case 1;
    }
  }

  private static bool a(ConfiguredNetworksListInnerRecset A_0)
  {
    int num1 = 0;
    switch (num1)
    {
      default:
        short num2 = 0;
        num2 = (short) 1;
        if (num2 == (short) 0)
          ;
        IEnumerator<FeatureNode> enumerator = ((Collection<FeatureNode>) A_0).GetEnumerator();
        bool flag;
        try
        {
          num2 = (short) 3;
          num1 = (int) (IntPtr) num2;
          while (true)
          {
            ConfiguredNetworksListInner current;
            ConfiguredNetworksListInnerSection listInnerSection;
            switch (num1)
            {
              case 0:
                if (((AcpField<int>) listInnerSection.DataWideWiFiNetworkSecurityType_42516).Value != 0)
                {
                  num2 = (short) 7;
                  num1 = (int) (IntPtr) num2;
                  continue;
                }
                break;
              case 1:
                if (enumerator.MoveNext())
                {
                  current = enumerator.Current as ConfiguredNetworksListInner;
                  num2 = (short) 8;
                  num1 = (int) (IntPtr) num2;
                  continue;
                }
                num2 = (short) 6;
                num1 = (int) (IntPtr) num2;
                continue;
              case 2:
                goto label_33;
              case 3:
                switch (0)
                {
                  case 0:
                    break;
                  default:
                    continue;
                }
                break;
              case 4:
                goto label_3;
              case 5:
                listInnerSection = current.ConfiguredNetworksListInnerSection;
                num2 = (short) 0;
                num1 = (int) (IntPtr) num2;
                continue;
              case 6:
                num2 = (short) 4;
                num1 = (int) (IntPtr) num2;
                continue;
              case 7:
                num2 = (short) 9;
                num1 = (int) (IntPtr) num2;
                continue;
              case 8:
                if (current != null)
                {
                  num2 = (short) 5;
                  num1 = (int) (IntPtr) num2;
                  continue;
                }
                break;
              case 9:
                if (WiFiPasswordUtil.g.ContainsKey(listInnerSection.DataWideWiFiNetworkSSID_42519.Value))
                {
                  num2 = (short) 10;
                  num1 = (int) (IntPtr) num2;
                  continue;
                }
                goto case 11;
              case 10:
                num2 = (short) 12;
                num1 = (int) (IntPtr) num2;
                continue;
              case 11:
                flag = true;
                num2 = (short) 2;
                num1 = (int) (IntPtr) num2;
                continue;
              case 12:
                if (WiFiPasswordUtil.g[listInnerSection.DataWideWiFiNetworkSSID_42519.Value] != ((AcpField<string>) listInnerSection.DataWideWiFiNetworkEncryptedNetworkPassword_42517).Value)
                {
                  num2 = (short) 11;
                  num1 = (int) (IntPtr) num2;
                  continue;
                }
                break;
            }
            num2 = (short) 1;
            num1 = (int) (IntPtr) num2;
          }
        }
        finally
        {
          short num3 = 21693;
          switch ((short) 21693 == num3 ? 1 : 0)
          {
            case 0:
            case 2:
              while (true)
              {
                switch (num1)
                {
                  case 0:
                    goto label_32;
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
                    enumerator.Dispose();
                    num3 = (short) 0;
                    num1 = (int) (IntPtr) num3;
                    continue;
                }
                if (enumerator != null)
                {
                  num3 = (short) 2;
                  num1 = (int) (IntPtr) num3;
                }
                else
                  break;
              }
label_32:;
            default:
              num3 = (short) 0;
              if (num3 == (short) 0)
                ;
              num3 = (short) 1;
              num1 = (int) (IntPtr) num3;
              goto case 0;
          }
        }
label_3:
        return false;
label_33:
        return flag;
    }
  }

  private static bool a(DataModemTableInnerRecset A_0)
  {
    switch (0)
    {
      default:
        short num1 = 0;
        IEnumerator<FeatureNode> enumerator = ((Collection<FeatureNode>) A_0).GetEnumerator();
        bool flag;
        try
        {
          num1 = (short) 8;
          int num2 = (int) (IntPtr) num1;
          while (true)
          {
            num1 = (short) -21029;
            int num3 = (int) num1;
            num1 = (short) -21029;
            int num4 = (int) num1;
            DataModemTableInner current;
            switch (num3 == num4 ? 1 : 0)
            {
              case 0:
              case 2:
label_11:
                current = enumerator.Current as DataModemTableInner;
                num1 = (short) 6;
                num2 = (int) (IntPtr) num1;
                continue;
              default:
                num1 = (short) 0;
                if (num1 == (short) 0)
                  ;
                DataModemTableInnerSection tableInnerSection;
                switch (num2)
                {
                  case 0:
                    goto label_2;
                  case 1:
                    goto label_30;
                  case 2:
                    if (WiFiPasswordUtil.h[tableInnerSection.DataWideExternalDataModemNetworkSsid_43358.Value] != ((AcpField<string>) tableInnerSection.DataWideEncryptedNetworkPassword_43361).Value)
                    {
                      num1 = (short) 10;
                      num2 = (int) (IntPtr) num1;
                      continue;
                    }
                    break;
                  case 3:
                    num1 = (short) 0;
                    num2 = (int) (IntPtr) num1;
                    continue;
                  case 4:
                    if (WiFiPasswordUtil.h.ContainsKey(tableInnerSection.DataWideExternalDataModemNetworkSsid_43358.Value))
                    {
                      num1 = (short) 7;
                      num2 = (int) (IntPtr) num1;
                      continue;
                    }
                    goto case 10;
                  case 5:
                    tableInnerSection = current.DataModemTableInnerSection;
                    num1 = (short) 4;
                    num2 = (int) (IntPtr) num1;
                    continue;
                  case 6:
                    if (current != null)
                    {
                      num1 = (short) 5;
                      num2 = (int) (IntPtr) num1;
                      continue;
                    }
                    break;
                  case 7:
                    num1 = (short) 2;
                    num2 = (int) (IntPtr) num1;
                    continue;
                  case 8:
                    switch (0)
                    {
                      case 0:
                        break;
                      default:
                        continue;
                    }
                    break;
                  case 9:
                    if (!enumerator.MoveNext())
                    {
                      num1 = (short) 3;
                      num2 = (int) (IntPtr) num1;
                      continue;
                    }
                    goto label_11;
                  case 10:
                    flag = true;
                    num1 = (short) 1;
                    num2 = (int) (IntPtr) num1;
                    continue;
                }
                num1 = (short) 9;
                num2 = (int) (IntPtr) num1;
                continue;
            }
          }
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
                enumerator.Dispose();
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
                goto label_29;
            }
            num5 = (short) 1;
            if (num5 == (short) 0)
              ;
            if (enumerator != null)
            {
              num5 = (short) 0;
              num6 = (int) (IntPtr) num5;
            }
            else
              break;
          }
label_29:;
        }
label_2:
        return false;
label_30:
        return flag;
    }
  }

  internal static bool OpenValidateDlg(Window parent)
  {
    int num1 = 3;
    while (true)
    {
      short num2;
      bool? nullable;
      bool flag;
      switch (num1)
      {
        case 0:
          Window window = new Window();
          PageCloneWiFiView pageCloneWiFiView = new PageCloneWiFiView();
          window.Title = AppResources.WiFi_Password_Validation;
          window.Content = (object) pageCloneWiFiView;
          window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
          window.SizeToContent = SizeToContent.WidthAndHeight;
          window.ResizeMode = ResizeMode.CanResize;
          window.Background = parent.Background;
          pageCloneWiFiView.LblCloneWiFiWarning.Visibility = Visibility.Hidden;
          Utility.SetDirection((FrameworkElement) window);
          nullable = window.ShowDialog();
          flag = false;
          num2 = (short) 4;
          num1 = (int) (IntPtr) num2;
          continue;
        case 1:
          goto label_13;
        case 2:
          goto label_9;
        case 3:
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
        case 4:
          if (!(nullable.GetValueOrDefault() == flag & nullable.HasValue))
          {
            WiFiPasswordUtil.a();
            num2 = (short) 1;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          num2 = (short) 2;
          num1 = (int) (IntPtr) num2;
          continue;
      }
      if (WiFiPasswordUtil.NeedValidation())
      {
        num2 = (short) 19678;
        int num3 = (int) num2;
        num2 = (short) 19678;
        int num4 = (int) num2;
        switch (num3 == num4 ? 1 : 0)
        {
          case 0:
          case 2:
            goto label_13;
          default:
            num2 = (short) 0;
            num2 = (short) 0;
            if (num2 == (short) 0)
              ;
            num2 = (short) 0;
            num1 = (int) (IntPtr) num2;
            continue;
        }
      }
      else
        goto label_13;
    }
label_9:
    return false;
label_13:
    return true;
  }

  private static void a()
  {
    if (!(FeatureManager.GetFeature(2028)[0] is Motorola.MackinawCPS.CoreFeatures.DataWide.DataWide A_0))
    {
      short num = -15283;
      switch ((short) -15283 == num ? 1 : 0)
      {
        case 0:
        case 2:
          break;
        default:
          num = (short) 1;
          if (num == (short) 0)
            ;
          num = (short) 0;
          num = (short) 0;
          if (num == (short) 0)
            ;
          return;
      }
    }
    WiFiPasswordUtil.g.Clear();
    WiFiPasswordUtil.h.Clear();
    WiFiPasswordUtil.b(A_0);
    WiFiPasswordUtil.a(A_0);
  }

  private static void b(Motorola.MackinawCPS.CoreFeatures.DataWide.DataWide A_0)
  {
    int num1 = 0;
    switch (num1)
    {
      default:
        ConfiguredNetworksListInnerRecset embeddedRecset;
        short num2;
        switch (0)
        {
          case 0:
label_3:
            embeddedRecset = ((FeatureSection) A_0.WIFI).EmbeddedRecset as ConfiguredNetworksListInnerRecset;
            num2 = (short) 1;
            num1 = (int) (IntPtr) num2;
            goto default;
          default:
            IEnumerator<FeatureNode> enumerator;
            while (true)
            {
              switch (num1)
              {
                case 0:
                  num2 = (short) 0;
                  num2 = (short) 1;
                  if (num2 == (short) 0)
                    ;
                  enumerator = ((Collection<FeatureNode>) embeddedRecset).GetEnumerator();
                  num2 = (short) 2;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 1:
                  if (embeddedRecset != null)
                  {
                    num2 = (short) 0;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_33;
                case 2:
                  goto label_7;
                default:
                  goto label_3;
              }
            }
label_33:
            return;
label_7:
            try
            {
              num2 = (short) 7;
              int num3 = (int) (IntPtr) num2;
              while (true)
              {
                ConfiguredNetworksListInner current;
                ConfiguredNetworksListInnerSection listInnerSection;
                switch (num3)
                {
                  case 0:
                    if (current != null)
                    {
                      num2 = (short) 3;
                      num3 = (int) (IntPtr) num2;
                      continue;
                    }
                    goto case 1;
                  case 1:
label_12:
                    num2 = (short) 5;
                    num3 = (int) (IntPtr) num2;
                    continue;
                  case 2:
                    goto label_30;
                  case 3:
                    listInnerSection = current.ConfiguredNetworksListInnerSection;
                    num2 = (short) 8;
                    num3 = (int) (IntPtr) num2;
                    continue;
                  case 4:
                    num2 = (short) 2;
                    num3 = (int) (IntPtr) num2;
                    continue;
                  case 5:
                    if (!enumerator.MoveNext())
                    {
                      num2 = (short) 4;
                      num3 = (int) (IntPtr) num2;
                      continue;
                    }
                    current = enumerator.Current as ConfiguredNetworksListInner;
                    break;
                  case 6:
                    WiFiPasswordUtil.g.Add(listInnerSection.DataWideWiFiNetworkSSID_42519.Value, ((AcpField<string>) listInnerSection.DataWideWiFiNetworkEncryptedNetworkPassword_42517).Value);
                    num2 = (short) 1;
                    num3 = (int) (IntPtr) num2;
                    continue;
                  case 7:
                    switch (0)
                    {
                      case 0:
                        goto label_10;
                      default:
                        continue;
                    }
                  case 8:
                    if (((AcpField<int>) listInnerSection.DataWideWiFiNetworkSecurityType_42516).Value != 0)
                    {
                      num2 = (short) 6;
                      num3 = (int) (IntPtr) num2;
                      continue;
                    }
                    goto case 1;
                  default:
label_10:
                    num2 = (short) 30036;
                    int num4 = (int) num2;
                    num2 = (short) 30036;
                    int num5 = (int) num2;
                    switch (num4 == num5 ? 1 : 0)
                    {
                      case 0:
                      case 2:
                        break;
                      default:
                        num2 = (short) 0;
                        if (num2 == (short) 0)
                          goto label_12;
                        goto label_12;
                    }
                    break;
                }
                num2 = (short) 0;
                num3 = (int) (IntPtr) num2;
              }
label_30:
              return;
            }
            finally
            {
              short num6 = 1;
              int num7 = (int) (IntPtr) num6;
              while (true)
              {
                switch (num7)
                {
                  case 0:
                    enumerator.Dispose();
                    num6 = (short) 2;
                    num7 = (int) (IntPtr) num6;
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
                    goto label_31;
                }
                if (enumerator != null)
                {
                  num6 = (short) 0;
                  num7 = (int) (IntPtr) num6;
                }
                else
                  break;
              }
label_31:;
            }
        }
    }
  }

  private static void a(Motorola.MackinawCPS.CoreFeatures.DataWide.DataWide A_0)
  {
    int num1 = 0;
    switch (num1)
    {
      default:
        DataModemTableInnerRecset embeddedRecset;
        short num2;
        switch (0)
        {
          case 0:
label_3:
            embeddedRecset = ((FeatureSection) A_0.ExternalDataModem).EmbeddedRecset as DataModemTableInnerRecset;
            num2 = (short) 3;
            num1 = (int) (IntPtr) num2;
            goto default;
          default:
            IEnumerator<FeatureNode> enumerator;
            while (true)
            {
              switch (num1)
              {
                case 0:
                  num2 = (short) 4;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 1:
                  goto label_7;
                case 2:
                  enumerator = ((Collection<FeatureNode>) embeddedRecset).GetEnumerator();
                  num2 = (short) 1;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 3:
                  num2 = (short) 0;
                  num2 = (short) 1;
                  if (num2 == (short) 0)
                    ;
                  if (embeddedRecset != null)
                  {
                    num2 = (short) 0;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_33;
                case 4:
                  if (AcpField<int>.op_Implicit((AcpField<int>) A_0.ExternalDataModem.ModemConnectionType_43350) == 1)
                  {
                    num2 = (short) 2;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_29;
                default:
                  goto label_3;
              }
            }
label_33:
            return;
label_7:
            try
            {
              num2 = (short) 5;
              int num3 = (int) (IntPtr) num2;
              while (true)
              {
                DataModemTableInner current;
                switch (num3)
                {
                  case 0:
                    if (enumerator.MoveNext())
                    {
                      current = enumerator.Current as DataModemTableInner;
                      num2 = (short) 13982;
                      int num4 = (int) num2;
                      num2 = (short) 13982;
                      int num5 = (int) num2;
                      switch (num4 == num5 ? 1 : 0)
                      {
                        case 0:
                        case 2:
                          goto label_8;
                        default:
                          num2 = (short) 0;
                          if (num2 == (short) 0)
                            ;
                          num2 = (short) 2;
                          num3 = (int) (IntPtr) num2;
                          continue;
                      }
                    }
                    else
                    {
                      num2 = (short) 6;
                      num3 = (int) (IntPtr) num2;
                      continue;
                    }
                  case 1:
                    DataModemTableInnerSection tableInnerSection = current.DataModemTableInnerSection;
                    WiFiPasswordUtil.h.Add(tableInnerSection.DataWideExternalDataModemNetworkSsid_43358.Value, ((AcpField<string>) tableInnerSection.DataWideEncryptedNetworkPassword_43361).Value);
                    num2 = (short) 4;
                    num3 = (int) (IntPtr) num2;
                    continue;
                  case 2:
                    if (current != null)
                    {
                      num2 = (short) 1;
                      num3 = (int) (IntPtr) num2;
                      continue;
                    }
                    break;
                  case 3:
                    goto label_26;
                  case 5:
label_8:
                    switch (0)
                    {
                      case 0:
                        break;
                      default:
                        continue;
                    }
                    break;
                  case 6:
                    num2 = (short) 3;
                    num3 = (int) (IntPtr) num2;
                    continue;
                }
                num2 = (short) 0;
                num3 = (int) (IntPtr) num2;
              }
label_26:
              return;
            }
            finally
            {
              int num6 = 1;
              while (true)
              {
                switch (num6)
                {
                  case 0:
                    enumerator.Dispose();
                    num6 = 2;
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
                    goto label_27;
                }
                if (enumerator != null)
                  num6 = 0;
                else
                  break;
              }
label_27:;
            }
label_29:
            return;
        }
    }
  }

  internal static void RefreshSessionTimer()
  {
    short num1 = 0;
    num1 = (short) -12523;
    int num2 = (int) num1;
    num1 = (short) -12523;
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
        WiFiPasswordUtil.f = false;
        WiFiPasswordUtil.b = 1;
        WiFiPasswordUtil.e.Stop();
        WiFiPasswordUtil.e.Start();
        break;
      default:
        goto case 1;
    }
  }

  public static void ResetSessionTimer()
  {
    short num1 = 0;
    num1 = (short) 9586;
    int num2 = (int) num1;
    num1 = (short) 9586;
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
        WiFiPasswordUtil.f = true;
        WiFiPasswordUtil.b = 1;
        WiFiPasswordUtil.g.Clear();
        WiFiPasswordUtil.h.Clear();
        WiFiPasswordUtil.e.Stop();
        break;
      default:
        goto case 1;
    }
  }

  internal static void WaitNextValidate()
  {
    short num1 = 0;
    num1 = (short) 1;
    if (num1 == (short) 0)
      ;
    num1 = (short) -30141;
    int num2 = (int) num1;
    num1 = (short) -30141;
    int num3 = (int) num1;
    switch (num2 == num3)
    {
      case true:
        num1 = (short) 0;
        if (num1 == (short) 0)
          ;
        Thread.Sleep(1000 * WiFiPasswordUtil.b);
        WiFiPasswordUtil.b *= 2;
        break;
      default:
        goto case 1;
    }
  }
}
