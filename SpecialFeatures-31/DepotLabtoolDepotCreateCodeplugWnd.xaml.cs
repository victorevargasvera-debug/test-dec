// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.DepotLabtool.DepotCreateCodeplugWnd
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using AcpCryptoLib;
using SpecialFeatures.AcpReportManagerLib;
using SpecialFeatures.Flashport.FlashRadio;
using SpecialFeatures.Model_Configuration;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;
using System.Windows.Media;
using System.Xml;

#nullable disable
namespace SpecialFeatures.DepotLabtool;

public partial class DepotCreateCodeplugWnd : Window, IComponentConnector
{
  private bool a = true;
  private bool b = true;
  private bool c = true;
  private string d = "";
  private const string e = "APX5000";
  private const string f = "APX5500";
  private const string g = "APX6000";
  private const string h = "APX6500";
  private const string i = "I";
  private Dictionary<int, Dictionary<string, string>> j;
  private PCIHandler k = new PCIHandler();
  internal Label label1;
  internal ComboBox cmbRadio;
  internal Label label3;
  internal ComboBox cmbModelNum;
  internal Label label4;
  internal Label label5;
  internal TextBox txtFlashCode1;
  internal Label label6;
  internal TextBox txtFlashCode2;
  internal Label label7;
  internal TextBox txtFlashCodeCheckSum;
  internal Button btnOK;
  internal Button btnCancel;
  internal TextBox txtSerNum;
  internal Label labelRegion;
  internal ComboBox cmbRegion;
  internal CheckBox cbULP;
  internal CheckBox cbAPX6000P25;
  internal CheckBox cbMariTimeRadio;
  internal CheckBox cbDualKnobs;
  internal CheckBox cbDisableEnc;
  private bool m;

  public DepotCreateCodeplugWnd()
  {
    this.InitializeComponent();
    this.DepotOptions = new List<string>();
    this.cmbRadio.SelectionChanged += new SelectionChangedEventHandler(this.SelectModel);
    this.cmbModelNum.SelectionChanged += new SelectionChangedEventHandler(this.cmbModelNum_SelectionChanged);
    this.cmbRadio.SelectedIndex = 0;
    this.cmbRegion.SelectedIndex = 0;
    this.e();
    this.SelectModel((object) this.cmbRadio, (RoutedEventArgs) null);
  }

  private void e()
  {
    int A_1 = 5;
    try
    {
      short num1 = 0;
      int num2 = (int) num1;
      switch (num2)
      {
        default:
          ModelTiering modelTiering;
          switch (0)
          {
            case 0:
label_4:
              modelTiering = new ModelTiering(RptMgrErrorHandler.b("삇뎉뮋\uDA8D힏횑궓욕쾗ꮙ\uDD9B킝", A_1), ModelTiering.ActionTypes.NONE, ModelTiering.TargetTypes.NONE);
              this.d = modelTiering.MTFPath;
              num1 = (short) 5;
              num2 = (int) (IntPtr) num1;
              goto default;
            default:
              while (true)
              {
                Dictionary<string, string> A_0_1;
                Dictionary<string, string> A_0_2;
                IEnumerator enumerator1;
                IDisposable disposable;
                XmlNodeList xmlNodeList;
                switch (num2)
                {
                  case 0:
                    XmlDocument xmlDocument = new XmlDocument();
                    xmlNodeList = new AcpXMLEncryptDecrypt().DecryptXMLFile(modelTiering.MTFPath).SelectNodes(RptMgrErrorHandler.b("ꞇ\uF889\uE38B\uE18D\uE48F붑\uD993秊ﲗﾙ\uF09B쪝즟잡횣쾥욧충\uEAAB잭\uDCAFힱ鮳\uE5B5춷쪹첻톽늿뛁ꇃꋅ胇藉볋뫍맏뷑뫓ꗕ", A_1));
                    this.j = new Dictionary<int, Dictionary<string, string>>();
                    enumerator1 = ((IEnumerable) this.cmbRadio.Items).GetEnumerator();
                    num1 = (short) 2;
                    num2 = (int) (IntPtr) num1;
                    continue;
                  case 1:
                    try
                    {
                      num1 = (short) 1;
                      num2 = (int) (IntPtr) num1;
                      while (true)
                      {
                        int key;
                        string str;
                        switch (num2)
                        {
                          case 0:
                            if (str == RptMgrErrorHandler.b("즇\uDA89풋뢍ꖏꊑ꒓", A_1))
                            {
                              num1 = (short) 3;
                              num2 = (int) (IntPtr) num1;
                              continue;
                            }
                            break;
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
                            if (str == RptMgrErrorHandler.b("즇\uDA89풋뢍ꂏꊑ꒓", A_1))
                            {
                              num1 = (short) 6;
                              num2 = (int) (IntPtr) num1;
                              continue;
                            }
                            num1 = (short) 0;
                            num2 = (int) (IntPtr) num1;
                            continue;
                          case 3:
                            A_0_2 = new Dictionary<string, string>((IDictionary<string, string>) this.j[key]);
                            num1 = (short) 4;
                            num2 = (int) (IntPtr) num1;
                            continue;
                          case 5:
                            num1 = (short) 8;
                            num2 = (int) (IntPtr) num1;
                            continue;
                          case 6:
                            A_0_1 = new Dictionary<string, string>((IDictionary<string, string>) this.j[key]);
                            num1 = (short) 7;
                            num2 = (int) (IntPtr) num1;
                            continue;
                          case 8:
                            goto label_7;
                          case 9:
                            if (!enumerator1.MoveNext())
                            {
                              num1 = (short) 5;
                              num2 = (int) (IntPtr) num1;
                              continue;
                            }
                            ComboBoxItem current = (ComboBoxItem) enumerator1.Current;
                            str = current.Content.ToString().ToUpper().Trim();
                            key = this.cmbRadio.Items.IndexOf((object) current);
                            num1 = (short) 2;
                            num2 = (int) (IntPtr) num1;
                            continue;
                        }
                        num1 = (short) 9;
                        num2 = (int) (IntPtr) num1;
                      }
                    }
                    finally
                    {
                      short num3;
                      switch (0)
                      {
                        case 0:
label_27:
                          disposable = enumerator1 as IDisposable;
                          num3 = (short) 2;
                          num2 = (int) (IntPtr) num3;
                          goto default;
                        default:
                          while (true)
                          {
                            num3 = (short) 30729;
                            int num4 = (int) num3;
                            num3 = (short) 30729;
                            int num5 = (int) num3;
                            switch (num4 == num5 ? 1 : 0)
                            {
                              case 0:
                              case 2:
label_28:
                                if (disposable != null)
                                {
                                  num3 = (short) 0;
                                  num2 = (int) (IntPtr) num3;
                                  continue;
                                }
                                goto label_31;
                              default:
                                num3 = (short) 0;
                                if (num3 == (short) 0)
                                  ;
                                switch (num2)
                                {
                                  case 0:
                                    disposable.Dispose();
                                    num3 = (short) 1;
                                    num2 = (int) (IntPtr) num3;
                                    continue;
                                  case 1:
                                    goto label_31;
                                  case 2:
                                    goto label_28;
                                  default:
                                    goto label_27;
                                }
                            }
                          }
label_31:;
                      }
                    }
label_7:
                    this.a(A_0_1, RptMgrErrorHandler.b("펇쮉\uED8B펍쮏슑\uE493쮕쎗슙\uE49B쎝ﲟ톡辣邥颧骩鲫", A_1), RptMgrErrorHandler.b("즇\uDA89풋꺍ꖏꊑ꒓ꚕ", A_1));
                    this.a(A_0_2, RptMgrErrorHandler.b("펇쮉\uED8B펍쮏슑\uE493쮕쎗슙\uE49B쎝ﲟ톡辣邥鶧骩鲫", A_1), RptMgrErrorHandler.b("즇\uDA89풋꺍ꖏꞑ꒓ꚕ", A_1));
                    enumerator1 = ((IEnumerable) this.cmbRadio.Items).GetEnumerator();
                    num1 = (short) 3;
                    num2 = (int) (IntPtr) num1;
                    continue;
                  case 2:
                    try
                    {
                      num1 = (short) 6;
                      num2 = (int) (IntPtr) num1;
                      while (true)
                      {
                        string str1;
                        string str2;
                        ComboBoxItem current1;
                        int key;
                        Dictionary<string, string> dictionary;
                        IEnumerator enumerator2;
                        switch (num2)
                        {
                          case 0:
                            goto label_166;
                          case 1:
                            try
                            {
                              num1 = (short) 4;
                              num2 = (int) (IntPtr) num1;
                              while (true)
                              {
                                IEnumerator enumerator3;
                                switch (num2)
                                {
                                  case 0:
                                    num1 = (short) 3;
                                    num2 = (int) (IntPtr) num1;
                                    continue;
                                  case 1:
                                    if (enumerator2.MoveNext())
                                    {
                                      enumerator3 = ((XmlNode) enumerator2.Current).ChildNodes.GetEnumerator();
                                      num1 = (short) 2;
                                      num2 = (int) (IntPtr) num1;
                                      continue;
                                    }
                                    num1 = (short) 0;
                                    num2 = (int) (IntPtr) num1;
                                    continue;
                                  case 2:
                                    try
                                    {
                                      num1 = (short) 2;
                                      num2 = (int) (IntPtr) num1;
                                      while (true)
                                      {
                                        XmlNode current2;
                                        IEnumerator enumerator4;
                                        switch (num2)
                                        {
                                          case 0:
                                            try
                                            {
                                              num1 = (short) 13;
                                              num2 = (int) (IntPtr) num1;
                                              while (true)
                                              {
                                                XmlNode current3;
                                                switch (num2)
                                                {
                                                  case 0:
                                                    if (!(str2 == RptMgrErrorHandler.b("\uE987憎\uF48B꺍ꞏꊑ꒓ꚕ", A_1)))
                                                    {
                                                      num1 = (short) 21;
                                                      num2 = (int) (IntPtr) num1;
                                                      continue;
                                                    }
                                                    goto case 9;
                                                  case 1:
                                                    num1 = (short) 0;
                                                    num2 = (int) (IntPtr) num1;
                                                    continue;
                                                  case 2:
                                                    if (dictionary != null)
                                                    {
                                                      num1 = (short) 10;
                                                      num2 = (int) (IntPtr) num1;
                                                      continue;
                                                    }
                                                    break;
                                                  case 4:
                                                    if (str2 == RptMgrErrorHandler.b("\uE987憎\uF48B꺍\uA48Fꊑ꒓ꚕ", A_1))
                                                    {
                                                      num1 = (short) 9;
                                                      num2 = (int) (IntPtr) num1;
                                                      continue;
                                                    }
                                                    dictionary.Add(current3.Attributes[RptMgrErrorHandler.b("\uE687\uEB89\uE18B\uEB8D", A_1)].Value, current3.Attributes[RptMgrErrorHandler.b("\uEC87\uEF89ﾋ\uED8D\uE28Fﮑ\uE493\uE295\uF197\uF599\uF29B", A_1)].Value + RptMgrErrorHandler.b("ꢇ꞉겋", A_1) + current3.Attributes[RptMgrErrorHandler.b("\uEA87\uEB89\uE28B\uEA8D", A_1)].Value);
                                                    num1 = (short) 3;
                                                    num2 = (int) (IntPtr) num1;
                                                    continue;
                                                  case 5:
                                                    num1 = (short) 2;
                                                    num2 = (int) (IntPtr) num1;
                                                    continue;
                                                  case 6:
                                                    num1 = (short) 15;
                                                    num2 = (int) (IntPtr) num1;
                                                    continue;
                                                  case 7:
                                                    if (current3 is XmlElement)
                                                    {
                                                      num1 = (short) 5;
                                                      num2 = (int) (IntPtr) num1;
                                                      continue;
                                                    }
                                                    break;
                                                  case 8:
                                                    dictionary.Add(current3.Attributes[RptMgrErrorHandler.b("\uE687\uEB89\uE18B\uEB8D", A_1)].Value, current3.Attributes[RptMgrErrorHandler.b("\uEC87\uEF89ﾋ\uED8D\uE28Fﮑ\uE493\uE295\uF197\uF599\uF29B", A_1)].Value + RptMgrErrorHandler.b("ꢇ꞉겋", A_1) + current3.Attributes[RptMgrErrorHandler.b("\uEA87\uEB89\uE28B\uEA8D", A_1)].Value);
                                                    num1 = (short) 17;
                                                    num2 = (int) (IntPtr) num1;
                                                    continue;
                                                  case 9:
                                                    num1 = (short) 20;
                                                    num2 = (int) (IntPtr) num1;
                                                    continue;
                                                  case 10:
                                                    num1 = (short) 11;
                                                    num2 = (int) (IntPtr) num1;
                                                    continue;
                                                  case 11:
                                                    if (!dictionary.ContainsKey(current3.Attributes[RptMgrErrorHandler.b("\uE687\uEB89\uE18B\uEB8D", A_1)].Value))
                                                    {
                                                      num1 = (short) 6;
                                                      num2 = (int) (IntPtr) num1;
                                                      continue;
                                                    }
                                                    break;
                                                  case 12:
                                                    if (enumerator4.MoveNext())
                                                    {
                                                      current3 = (XmlNode) enumerator4.Current;
                                                      num1 = (short) 7;
                                                      num2 = (int) (IntPtr) num1;
                                                      continue;
                                                    }
                                                    num1 = (short) 18;
                                                    num2 = (int) (IntPtr) num1;
                                                    continue;
                                                  case 13:
                                                    switch (0)
                                                    {
                                                      case 0:
                                                        break;
                                                      default:
                                                        continue;
                                                    }
                                                    break;
                                                  case 14:
                                                    num1 = (short) 19;
                                                    num2 = (int) (IntPtr) num1;
                                                    continue;
                                                  case 15:
                                                    if (current3.Attributes[RptMgrErrorHandler.b("\uEC87\uEF89ﾋ\uED8D\uE28Fﮑ\uE493\uE295\uF197\uF599\uF29B", A_1)].Value.ToLower().Contains(str2))
                                                    {
                                                      num1 = (short) 1;
                                                      num2 = (int) (IntPtr) num1;
                                                      continue;
                                                    }
                                                    break;
                                                  case 16 /*0x10*/:
                                                    goto label_102;
                                                  case 18:
                                                    num1 = (short) 16 /*0x10*/;
                                                    num2 = (int) (IntPtr) num1;
                                                    continue;
                                                  case 19:
                                                    if (!current3.Attributes[RptMgrErrorHandler.b("\uEC87\uEF89ﾋ\uED8D\uE28Fﮑ\uE493\uE295\uF197\uF599\uF29B", A_1)].Value.ToLower().Contains(RptMgrErrorHandler.b("벇몉벋뺍\uE88F晴", A_1)))
                                                    {
                                                      num1 = (short) 8;
                                                      num2 = (int) (IntPtr) num1;
                                                      continue;
                                                    }
                                                    break;
                                                  case 20:
                                                    if (!current3.Attributes[RptMgrErrorHandler.b("\uEC87\uEF89ﾋ\uED8D\uE28Fﮑ\uE493\uE295\uF197\uF599\uF29B", A_1)].Value.ToLower().Contains(RptMgrErrorHandler.b("뾇몉벋뺍\uE88F\uF791", A_1)))
                                                    {
                                                      num1 = (short) 14;
                                                      num2 = (int) (IntPtr) num1;
                                                      continue;
                                                    }
                                                    break;
                                                  case 21:
                                                    num1 = (short) 4;
                                                    num2 = (int) (IntPtr) num1;
                                                    continue;
                                                }
                                                num1 = (short) 12;
                                                num2 = (int) (IntPtr) num1;
                                              }
                                            }
                                            finally
                                            {
                                              short num6;
                                              switch (0)
                                              {
                                                case 0:
label_96:
                                                  disposable = enumerator4 as IDisposable;
                                                  num6 = (short) 0;
                                                  num2 = (int) (IntPtr) num6;
                                                  goto default;
                                                default:
                                                  while (true)
                                                  {
                                                    switch (num2)
                                                    {
                                                      case 0:
                                                        if (disposable != null)
                                                        {
                                                          num6 = (short) 2;
                                                          num2 = (int) (IntPtr) num6;
                                                          continue;
                                                        }
                                                        goto label_100;
                                                      case 1:
                                                        goto label_100;
                                                      case 2:
                                                        disposable.Dispose();
                                                        num6 = (short) 1;
                                                        num2 = (int) (IntPtr) num6;
                                                        continue;
                                                      default:
                                                        goto label_96;
                                                    }
                                                  }
label_100:;
                                              }
                                            }
                                          case 1:
                                            enumerator4 = current2.SelectSingleNode(RptMgrErrorHandler.b("얇\uE589\uE88B\uEB8Dﲏ\uE191", A_1)).ChildNodes.GetEnumerator();
                                            num1 = (short) 0;
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
                                            if (current2.Attributes[RptMgrErrorHandler.b("\uE687\uEB89\uE18B\uEB8D", A_1)].Value.ToLower().Contains(str2))
                                            {
                                              num1 = (short) 1;
                                              num2 = (int) (IntPtr) num1;
                                              continue;
                                            }
                                            break;
                                          case 4:
                                            num1 = (short) 3;
                                            num2 = (int) (IntPtr) num1;
                                            continue;
                                          case 5:
                                            num1 = (short) 7;
                                            num2 = (int) (IntPtr) num1;
                                            continue;
                                          case 6:
                                            if (enumerator3.MoveNext())
                                            {
                                              current2 = (XmlNode) enumerator3.Current;
                                              num1 = (short) 8;
                                              num2 = (int) (IntPtr) num1;
                                              continue;
                                            }
                                            num1 = (short) 5;
                                            num2 = (int) (IntPtr) num1;
                                            continue;
                                          case 7:
                                            goto label_117;
                                          case 8:
                                            if (current2 is XmlElement)
                                            {
                                              num1 = (short) 4;
                                              num2 = (int) (IntPtr) num1;
                                              continue;
                                            }
                                            break;
                                        }
label_102:
                                        num2 = 6;
                                      }
                                    }
                                    finally
                                    {
                                      short num7;
                                      switch (0)
                                      {
                                        case 0:
label_111:
                                          disposable = enumerator3 as IDisposable;
                                          num7 = (short) 0;
                                          num2 = (int) (IntPtr) num7;
                                          goto default;
                                        default:
                                          while (true)
                                          {
                                            switch (num2)
                                            {
                                              case 0:
                                                if (disposable != null)
                                                {
                                                  num7 = (short) 2;
                                                  num2 = (int) (IntPtr) num7;
                                                  continue;
                                                }
                                                goto label_115;
                                              case 1:
                                                goto label_115;
                                              case 2:
                                                disposable.Dispose();
                                                num7 = (short) 1;
                                                num2 = (int) (IntPtr) num7;
                                                continue;
                                              default:
                                                goto label_111;
                                            }
                                          }
label_115:;
                                      }
                                    }
                                  case 3:
                                    goto label_44;
                                  case 4:
                                    switch (0)
                                    {
                                      case 0:
                                        break;
                                      default:
                                        continue;
                                    }
                                    break;
                                }
label_117:
                                num2 = 1;
                              }
                            }
                            finally
                            {
                              switch (0)
                              {
                                case 0:
label_123:
                                  disposable = enumerator2 as IDisposable;
                                  num2 = 0;
                                  goto default;
                                default:
                                  while (true)
                                  {
                                    switch (num2)
                                    {
                                      case 0:
                                        if (disposable != null)
                                        {
                                          num2 = 2;
                                          continue;
                                        }
                                        goto label_127;
                                      case 1:
                                        goto label_127;
                                      case 2:
                                        disposable.Dispose();
                                        num2 = 1;
                                        continue;
                                      default:
                                        goto label_123;
                                    }
                                  }
label_127:;
                              }
                            }
label_44:
                            num2 = 4;
                            continue;
                          case 2:
                            if (!(str1 == RptMgrErrorHandler.b("즇\uDA89풋뮍ꂏꊑ꒓", A_1)))
                            {
                              num1 = (short) 3;
                              num2 = (int) (IntPtr) num1;
                              continue;
                            }
                            break;
                          case 3:
                            num1 = (short) 14;
                            num2 = (int) (IntPtr) num1;
                            continue;
                          case 4:
                            if (!this.j.ContainsKey(key))
                            {
                              num1 = (short) 12;
                              num2 = (int) (IntPtr) num1;
                              continue;
                            }
                            break;
                          case 5:
                            if (!(current1.Content as string).ToLower().StartsWith(RptMgrErrorHandler.b("ﺇ\uF289", A_1)))
                            {
                              num1 = (short) 10;
                              num2 = (int) (IntPtr) num1;
                              continue;
                            }
                            goto case 11;
                          case 6:
                            switch (0)
                            {
                              case 0:
                                break;
                              default:
                                continue;
                            }
                            break;
                          case 7:
                            if (!enumerator1.MoveNext())
                            {
                              num1 = (short) 9;
                              num2 = (int) (IntPtr) num1;
                              continue;
                            }
                            current1 = (ComboBoxItem) enumerator1.Current;
                            str1 = current1.Content.ToString().ToUpper().Trim();
                            num1 = (short) 2;
                            num2 = (int) (IntPtr) num1;
                            continue;
                          case 9:
                            num1 = (short) 0;
                            num2 = (int) (IntPtr) num1;
                            continue;
                          case 10:
                            str2 = (current1.Content as string).Insert(3, RptMgrErrorHandler.b("ꢇ", A_1)).ToLower();
                            num1 = (short) 11;
                            num2 = (int) (IntPtr) num1;
                            continue;
                          case 11:
                            key = this.cmbRadio.Items.IndexOf((object) current1);
                            dictionary = new Dictionary<string, string>();
                            enumerator2 = xmlNodeList.GetEnumerator();
                            num1 = (short) 1;
                            num2 = (int) (IntPtr) num1;
                            continue;
                          case 12:
                            this.j.Add(key, dictionary);
                            num1 = (short) 8;
                            num2 = (int) (IntPtr) num1;
                            continue;
                          case 13:
                            str2 = RptMgrErrorHandler.b("ﺇ\uF289ꆋﺍꦏꚑ궓", A_1);
                            num1 = (short) 5;
                            num2 = (int) (IntPtr) num1;
                            continue;
                          case 14:
                            if (!(str1 == RptMgrErrorHandler.b("즇\uDA89풋뮍ꖏꊑ꒓", A_1)))
                            {
                              num1 = (short) 13;
                              num2 = (int) (IntPtr) num1;
                              continue;
                            }
                            break;
                        }
                        num1 = (short) 7;
                        num2 = (int) (IntPtr) num1;
                      }
                    }
                    finally
                    {
                      switch (0)
                      {
                        case 0:
label_132:
                          disposable = enumerator1 as IDisposable;
                          num2 = 0;
                          goto default;
                        default:
                          while (true)
                          {
                            switch (num2)
                            {
                              case 0:
                                if (disposable != null)
                                {
                                  num2 = 2;
                                  continue;
                                }
                                goto label_136;
                              case 1:
                                goto label_136;
                              case 2:
                                disposable.Dispose();
                                num2 = 1;
                                continue;
                              default:
                                goto label_132;
                            }
                          }
label_136:;
                      }
                    }
label_166:
                    A_0_1 = new Dictionary<string, string>();
                    A_0_2 = new Dictionary<string, string>();
                    enumerator1 = ((IEnumerable) this.cmbRadio.Items).GetEnumerator();
                    num1 = (short) 1;
                    num2 = (int) (IntPtr) num1;
                    continue;
                  case 3:
                    try
                    {
                      num1 = (short) 5;
                      num2 = (int) (IntPtr) num1;
                      while (true)
                      {
                        int key;
                        string str;
                        switch (num2)
                        {
                          case 0:
                            num1 = (short) 4;
                            num2 = (int) (IntPtr) num1;
                            continue;
                          case 1:
                            num1 = (short) 11;
                            num2 = (int) (IntPtr) num1;
                            continue;
                          case 4:
                            if (!this.j.ContainsKey(key))
                            {
                              num1 = (short) 10;
                              num2 = (int) (IntPtr) num1;
                              continue;
                            }
                            break;
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
                            if (!enumerator1.MoveNext())
                            {
                              num1 = (short) 8;
                              num2 = (int) (IntPtr) num1;
                              continue;
                            }
                            ComboBoxItem current = (ComboBoxItem) enumerator1.Current;
                            str = current.Content.ToString().ToUpper().Trim();
                            key = this.cmbRadio.Items.IndexOf((object) current);
                            num1 = (short) 13;
                            num2 = (int) (IntPtr) num1;
                            continue;
                          case 7:
                            this.j.Add(key, A_0_1);
                            num1 = (short) 2;
                            num2 = (int) (IntPtr) num1;
                            continue;
                          case 8:
                            num1 = (short) 9;
                            num2 = (int) (IntPtr) num1;
                            continue;
                          case 9:
                            goto label_167;
                          case 10:
                            this.j.Add(key, A_0_2);
                            num1 = (short) 3;
                            num2 = (int) (IntPtr) num1;
                            continue;
                          case 11:
                            if (!this.j.ContainsKey(key))
                            {
                              num1 = (short) 7;
                              num2 = (int) (IntPtr) num1;
                              continue;
                            }
                            break;
                          case 12:
                            if (str == RptMgrErrorHandler.b("즇\uDA89풋뮍ꖏꊑ꒓", A_1))
                            {
                              num1 = (short) 0;
                              num2 = (int) (IntPtr) num1;
                              continue;
                            }
                            break;
                          case 13:
                            if (str == RptMgrErrorHandler.b("즇\uDA89풋뮍ꂏꊑ꒓", A_1))
                            {
                              num1 = (short) 1;
                              num2 = (int) (IntPtr) num1;
                              continue;
                            }
                            num1 = (short) 12;
                            num2 = (int) (IntPtr) num1;
                            continue;
                        }
                        num1 = (short) 6;
                        num2 = (int) (IntPtr) num1;
                      }
                    }
                    finally
                    {
                      short num8;
                      switch (0)
                      {
                        case 0:
label_160:
                          disposable = enumerator1 as IDisposable;
                          num8 = (short) 0;
                          num2 = (int) (IntPtr) num8;
                          goto default;
                        default:
                          while (true)
                          {
                            switch (num2)
                            {
                              case 0:
                                if (disposable != null)
                                {
                                  num8 = (short) 2;
                                  num2 = (int) (IntPtr) num8;
                                  continue;
                                }
                                goto label_164;
                              case 1:
                                goto label_164;
                              case 2:
                                disposable.Dispose();
                                num8 = (short) 1;
                                num2 = (int) (IntPtr) num8;
                                continue;
                              default:
                                goto label_160;
                            }
                          }
label_164:;
                      }
                    }
                  case 4:
                    goto label_171;
                  case 5:
                    if (File.Exists(this.d))
                    {
                      num1 = (short) 0;
                      num2 = (int) (IntPtr) num1;
                      continue;
                    }
                    break;
                  default:
                    goto label_4;
                }
label_167:
                num2 = 4;
              }
          }
      }
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show(ex.Message);
    }
label_171:
    if (false)
      ;
  }

  private void a(Dictionary<string, string> A_0, string A_1, string A_2)
  {
    int num1 = 0;
    short num2;
    List<string>.Enumerator enumerator;
    while (true)
    {
      switch (num1)
      {
        case 0:
          num2 = (short) -6368;
          int num3 = (int) num2;
          num2 = (short) -6368;
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
              switch (0)
              {
                case 0:
                  goto label_5;
                default:
                  continue;
              }
          }
          break;
        case 1:
          goto label_18;
        case 2:
          goto label_17;
        default:
label_5:
          num2 = (short) 0;
          if (A_0 != null)
          {
            enumerator = new List<string>((IEnumerable<string>) A_0.Keys).GetEnumerator();
            num2 = (short) 2;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          break;
      }
      num2 = (short) 1;
      num1 = (int) (IntPtr) num2;
    }
label_18:
    return;
label_17:
    num2 = (short) 1;
    if (num2 == (short) 0)
      ;
    try
    {
      num2 = (short) 0;
      int num5 = (int) (IntPtr) num2;
      while (true)
      {
        switch (num5)
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
          case 2:
            num2 = (short) 4;
            num5 = (int) (IntPtr) num2;
            continue;
          case 3:
            if (enumerator.MoveNext())
            {
              string current = enumerator.Current;
              A_0[current] = Regex.Replace(A_0[current], A_1, A_2);
              num2 = (short) 1;
              num5 = (int) (IntPtr) num2;
              continue;
            }
            num2 = (short) 2;
            num5 = (int) (IntPtr) num2;
            continue;
          case 4:
            goto label_19;
        }
        num2 = (short) 3;
        num5 = (int) (IntPtr) num2;
      }
label_19:;
    }
    finally
    {
      enumerator.Dispose();
    }
  }

  public string ModelNum
  {
    get
    {
      int A_1 = 11;
      short num1;
      int num2;
      string str;
      switch (0)
      {
        case 0:
label_3:
          num1 = (short) 12847;
          int num3 = (int) num1;
          num1 = (short) 12847;
          int num4 = (int) num1;
          switch (num3 == num4 ? 1 : 0)
          {
            case 0:
            case 2:
              num1 = (short) 0;
              num2 = (int) (IntPtr) num1;
              goto label_1;
            default:
              num1 = (short) 0;
              if (num1 == (short) 0)
                ;
              str = ((ContentControl) this.cmbRadio.SelectedItem).Content.ToString().ToUpper().Trim();
              goto case 0;
          }
        default:
          while (true)
          {
            num1 = (short) 1;
            if (num1 == (short) 0)
              ;
            switch (num2)
            {
              case 0:
                if (!(str == RptMgrErrorHandler.b("쾍삏쪑ꆓꚕꢗꪙ", A_1)))
                {
                  num1 = (short) 2;
                  num2 = (int) (IntPtr) num1;
                  continue;
                }
                goto label_9;
              case 1:
                if (str == RptMgrErrorHandler.b("쾍삏쪑ꆓꎕꢗꪙ", A_1))
                {
                  num1 = (short) 3;
                  num2 = (int) (IntPtr) num1;
                  continue;
                }
                goto label_14;
              case 2:
                num1 = (short) 1;
                num2 = (int) (IntPtr) num1;
                continue;
              case 3:
                goto label_13;
              default:
                goto label_3;
            }
label_1:;
          }
label_9:
          return this.cmbModelNum.Text + RptMgrErrorHandler.b("잍", A_1);
label_13:
          num1 = (short) 0;
          goto label_9;
label_14:
          return this.cmbModelNum.Text;
      }
    }
  }

  public string SerNum
  {
    get
    {
      short num1 = 0;
      num1 = (short) -1892;
      int num2 = (int) num1;
      num1 = (short) -1892;
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
          return this.txtSerNum.Text;
        default:
          goto case 1;
      }
    }
  }

  public string FlashCode
  {
    get
    {
      int A_1 = 10;
      short num1 = 0;
      num1 = (short) 26286;
      int num2 = (int) num1;
      num1 = (short) 26286;
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
          return this.txtFlashCode1.Text + RptMgrErrorHandler.b("ꂌ", A_1) + this.txtFlashCode2.Text + RptMgrErrorHandler.b("ꂌ", A_1) + this.txtFlashCodeCheckSum.Text + RptMgrErrorHandler.b("ꂌ뾎ꆐꎒꖔꞖꦘ뚚궜꾞醠鎢閤鞦", A_1);
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = 0;
      num1 = (short) -26843;
      int num2 = (int) num1;
      num1 = (short) -26843;
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
          string[] strArray = value.Trim().Split('-');
          this.txtFlashCode1.Text = strArray[0];
          this.txtFlashCode2.Text = strArray[1];
          this.txtFlashCodeCheckSum.Text = strArray[2];
          break;
        default:
          goto case 1;
      }
    }
  }

  public List<string> DepotOptions
  {
    get
    {
      switch (true)
      {
        case true:
          if (true)
            ;
          if (false)
            ;
          return this.l;
        default:
          goto case 1;
      }
    }
    internal set
    {
      short num1 = -20193;
      int num2 = (int) num1;
      num1 = (short) -20193;
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
          this.l = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  private void txtFlashCode_TextChanged(object A_0, TextChangedEventArgs A_1)
  {
    int num1 = 1;
    while (true)
    {
      short num2;
      byte flashCodeCheckDigit;
      switch (num1)
      {
        case 0:
          num2 = (short) 2;
          num1 = (int) (IntPtr) num2;
          continue;
        case 1:
          switch (0)
          {
            case 0:
              goto label_3;
            default:
              continue;
          }
        case 2:
          if (this.txtFlashCode2 != null)
          {
            num2 = (short) 3;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto label_15;
        case 3:
          num2 = (short) 5;
          num1 = (int) (IntPtr) num2;
          continue;
        case 4:
        case 8:
          goto label_23;
        case 5:
          if (this.txtFlashCodeCheckSum == null)
          {
            num2 = (short) 7;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          flashCodeCheckDigit = FlashcodeValidator.CalculateFlashCodeCheckDigit(this.txtFlashCode1.Text + this.txtFlashCode2.Text);
          num2 = (short) 9;
          num1 = (int) (IntPtr) num2;
          continue;
        case 6:
          num2 = (short) 0;
          this.txtFlashCodeCheckSum.Text = flashCodeCheckDigit.ToString();
          this.a = FlashcodeValidator.Validate(this.FlashCode);
          break;
        case 7:
          goto label_11;
        case 9:
          num2 = (short) -30297;
          int num3 = (int) num2;
          num2 = (short) -30297;
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
              num2 = (short) 1;
              if (num2 == (short) 0)
                ;
              if (flashCodeCheckDigit == byte.MaxValue)
              {
                this.txtFlashCodeCheckSum.Text = ' '.ToString();
                this.a = false;
                num2 = (short) 8;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              num2 = (short) 6;
              num1 = (int) (IntPtr) num2;
              continue;
          }
          break;
        default:
label_3:
          if (this.txtFlashCode1 != null)
          {
            num2 = (short) 0;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto label_22;
      }
      num2 = (short) 4;
      num1 = (int) (IntPtr) num2;
    }
label_11:
    return;
label_22:
    return;
label_15:
    return;
label_23:
    this.d();
    this.b();
  }

  private void d()
  {
    int A_1 = 19;
    int num1 = 0;
    short num2;
    while (true)
    {
      num2 = (short) -9390;
      int num3 = (int) num2;
      num2 = (short) -9390;
      int num4 = (int) num2;
      switch (num3 == num4 ? 1 : 0)
      {
        case 0:
        case 2:
label_19:
          num2 = (short) 8;
          num1 = (int) (IntPtr) num2;
          continue;
        default:
          num2 = (short) 0;
          if (num2 == (short) 0)
            ;
          byte flashcodeIntValue;
          switch (num1)
          {
            case 0:
              switch (0)
              {
                case 0:
                  goto label_5;
                default:
                  continue;
              }
            case 1:
              goto label_10;
            case 2:
              num2 = (short) 7;
              num1 = (int) (IntPtr) num2;
              continue;
            case 3:
              if (((int) flashcodeIntValue & 8) != 0)
              {
                num2 = (short) 1;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              break;
            case 4:
              flashcodeIntValue = (byte) FlashcodeMapping.GetFlashcodeIntValue(this.txtFlashCode2.Text[5]);
              goto label_19;
            case 5:
              num2 = (short) 3;
              num1 = (int) (IntPtr) num2;
              continue;
            case 6:
              goto label_15;
            case 7:
              if (this.txtFlashCode2.Text.Length == 6)
              {
                num2 = (short) 4;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_17;
            case 8:
              if (((ContentControl) this.cmbRadio.SelectedItem).Content.ToString().ToUpper().Trim().Equals(RptMgrErrorHandler.b("힕좗슙ꪛ꺝邟銡", A_1)))
              {
                num2 = (short) 5;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              break;
            default:
label_5:
              if (this.txtFlashCode2 != null)
              {
                num2 = (short) 2;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_22;
          }
          this.cbAPX6000P25.IsChecked = new bool?(false);
          num2 = (short) 6;
          num1 = (int) (IntPtr) num2;
          continue;
      }
    }
label_15:
    return;
label_22:
    return;
label_10:
    num2 = (short) 1;
    if (num2 == (short) 0)
      ;
    num2 = (short) 0;
    this.cbAPX6000P25.IsChecked = new bool?(true);
    return;
label_17:;
  }

  private void txtSerNum_TextChanged(object A_0, TextChangedEventArgs A_1)
  {
    short num1 = 0;
    num1 = (short) -205;
    int num2 = (int) num1;
    num1 = (short) -205;
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
        this.b = SerialNumberValidator.ValidateSerialNumber(Convert.ToBase64String(Encoding.ASCII.GetBytes(this.txtSerNum.Text.ToString().Trim())));
        this.b();
        break;
      default:
        goto case 1;
    }
  }

  private void c()
  {
    short num = -19715;
    switch ((short) -19715 == num)
    {
      case true:
        num = (short) 0;
        if (num == (short) 0)
          ;
        num = (short) 1;
        if (num == (short) 0)
          ;
        this.k.AddPCIOptionsForCreate(((ContentControl) this.cmbRadio.SelectedItem).Content.ToString().ToUpper().Trim());
        break;
      default:
        goto case 1;
    }
  }

  private void btnOK_Click(object A_0, RoutedEventArgs A_1)
  {
    int A_1_1 = 15;
    int num1;
    short num2;
    switch (0)
    {
      case 0:
label_2:
        this.DepotOptions.Clear();
        this.c = true;
        this.c();
        this.DepotOptions = this.k.PCIOptionList;
        num2 = (short) 18;
        num1 = (int) (IntPtr) num2;
        goto default;
      default:
        bool? isChecked;
        bool flag;
        while (true)
        {
          switch (num1)
          {
            case 0:
              this.a(RptMgrErrorHandler.b("\uDA91ꆓꎕꮗ", A_1_1));
              num2 = (short) 21;
              num1 = (int) (IntPtr) num2;
              continue;
            case 1:
              if (this.cbULP.IsVisible)
              {
                num2 = (short) 7;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 21;
            case 2:
              num2 = (short) 30;
              num1 = (int) (IntPtr) num2;
              continue;
            case 3:
              if (isChecked.GetValueOrDefault() == flag & isChecked.HasValue)
              {
                num2 = (short) 17;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 26;
            case 4:
              num2 = (short) 0;
              this.a(RptMgrErrorHandler.b("\uDA91ꖓꆕ", A_1_1));
              num2 = (short) 22;
              num1 = (int) (IntPtr) num2;
              continue;
            case 5:
label_42:
              isChecked = this.cbDualKnobs.IsChecked;
              flag = true;
              num2 = (short) 3;
              num1 = (int) (IntPtr) num2;
              continue;
            case 6:
              if (this.cbMariTimeRadio.IsVisible)
              {
                num2 = (short) 11091;
                int num3 = (int) num2;
                num2 = (short) 11091;
                int num4 = (int) num2;
                switch (num3 == num4 ? 1 : 0)
                {
                  case 0:
                  case 2:
                    goto label_42;
                  default:
                    num2 = (short) 0;
                    if (num2 == (short) 0)
                      ;
                    num2 = (short) 20;
                    num1 = (int) (IntPtr) num2;
                    continue;
                }
              }
              else
                goto case 13;
            case 7:
              isChecked = this.cbULP.IsChecked;
              flag = true;
              num2 = (short) 8;
              num1 = (int) (IntPtr) num2;
              continue;
            case 8:
              if (isChecked.GetValueOrDefault() == flag & isChecked.HasValue)
              {
                num2 = (short) 0;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 21;
            case 9:
              if (isChecked.GetValueOrDefault() == flag & isChecked.HasValue)
              {
                num2 = (short) 27;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 12;
            case 10:
              if (this.cmbRegion.SelectedIndex == 1)
              {
                num2 = (short) 2;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 22;
            case 11:
              this.a(RptMgrErrorHandler.b("쎑햓ꚕꮗꪙꦛꮝ", A_1_1));
              num2 = (short) 23;
              num1 = (int) (IntPtr) num2;
              continue;
            case 12:
              num2 = (short) 6;
              num1 = (int) (IntPtr) num2;
              continue;
            case 13:
              num2 = (short) 16 /*0x10*/;
              num1 = (int) (IntPtr) num2;
              continue;
            case 14:
              if (isChecked.GetValueOrDefault() == flag & isChecked.HasValue)
              {
                num2 = (short) 28;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_48;
            case 15:
              this.a(RptMgrErrorHandler.b("햑햓ꚕꦗꪙ꾛궝", A_1_1));
              num2 = (short) 13;
              num1 = (int) (IntPtr) num2;
              continue;
            case 16 /*0x10*/:
              if (this.cbDualKnobs.IsVisible)
              {
                num2 = (short) 5;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 26;
            case 17:
              this.a(RptMgrErrorHandler.b("쎑햓ꚕ겗ꊙꪛꮝ", A_1_1));
              num2 = (short) 26;
              num1 = (int) (IntPtr) num2;
              continue;
            case 18:
              if (this.cmbRegion.SelectedIndex == 2)
              {
                num2 = (short) 4;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              num2 = (short) 10;
              num1 = (int) (IntPtr) num2;
              continue;
            case 19:
              if (this.cbDisableEnc.IsVisible)
              {
                num2 = (short) 24;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_48;
            case 20:
              isChecked = this.cbMariTimeRadio.IsChecked;
              flag = true;
              num2 = (short) 29;
              num1 = (int) (IntPtr) num2;
              continue;
            case 21:
              num2 = (short) 1;
              if (num2 == (short) 0)
                ;
              isChecked = this.cbAPX6000P25.IsChecked;
              flag = true;
              num2 = (short) 9;
              num1 = (int) (IntPtr) num2;
              continue;
            case 22:
            case 23:
              num2 = (short) 1;
              num1 = (int) (IntPtr) num2;
              continue;
            case 24:
              isChecked = this.cbDisableEnc.IsChecked;
              flag = true;
              num2 = (short) 14;
              num1 = (int) (IntPtr) num2;
              continue;
            case 25:
              goto label_48;
            case 26:
              num2 = (short) 19;
              num1 = (int) (IntPtr) num2;
              continue;
            case 27:
              this.a(RptMgrErrorHandler.b("쎑햓ꚕꮗ궙겛꾝", A_1_1));
              num2 = (short) 12;
              num1 = (int) (IntPtr) num2;
              continue;
            case 28:
              this.a(RptMgrErrorHandler.b("쎑햓ꚕ궗궙ꦛ꾝", A_1_1));
              num2 = (short) 25;
              num1 = (int) (IntPtr) num2;
              continue;
            case 29:
              if (isChecked.GetValueOrDefault() == flag & isChecked.HasValue)
              {
                num2 = (short) 15;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 13;
            case 30:
              if (((Control) this.cmbRegion.ItemContainerGenerator.ContainerFromIndex(1)).Foreground == Brushes.Black)
              {
                num2 = (short) 11;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 22;
            default:
              goto label_2;
          }
        }
label_48:
        this.DialogResult = new bool?(true);
        break;
    }
  }

  private void a(string A_0)
  {
    short num1 = 1;
    if (num1 == (short) 0)
      ;
    num1 = (short) -23524;
    int num2 = (int) num1;
    num1 = (short) -23524;
    int num3 = (int) num1;
    int num4;
    switch (num2 == num3 ? 1 : 0)
    {
      case 0:
      case 2:
label_6:
        num1 = (short) 0;
        num4 = (int) (IntPtr) num1;
        break;
      default:
        num1 = (short) 0;
        if (num1 == (short) 0)
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
      switch (num4)
      {
        case 0:
          if (!this.DepotOptions.Contains(A_0))
          {
            num1 = (short) 1;
            num4 = (int) (IntPtr) num1;
            continue;
          }
          goto label_10;
        case 1:
          this.DepotOptions.Add(A_0);
          num1 = (short) 2;
          num4 = (int) (IntPtr) num1;
          continue;
        case 2:
          goto label_10;
        default:
          goto label_5;
      }
    }
label_10:
    num1 = (short) 0;
    return;
label_5:
    A_0 = A_0.Trim();
    goto label_6;
  }

  private void SelectModel(object A_0, RoutedEventArgs A_1)
  {
    int A_1_1 = 8;
    try
    {
      short num1 = 0;
      switch (num1)
      {
        default:
          num1 = (short) 3;
          int num2 = (int) (IntPtr) num1;
          while (true)
          {
            Dictionary<string, string>.KeyCollection.Enumerator enumerator;
            Dictionary<string, string> dictionary;
            int selectedIndex;
            switch (num2)
            {
              case 0:
                if (this.j != null)
                {
                  num1 = (short) 4;
                  num2 = (int) (IntPtr) num1;
                  continue;
                }
                break;
              case 1:
                this.d();
                this.b();
                num1 = (short) 7;
                num2 = (int) (IntPtr) num1;
                continue;
              case 2:
                num1 = (short) -27914;
                int num3 = (int) num1;
                num1 = (short) -27914;
                int num4 = (int) num1;
                switch (num3 == num4 ? 1 : 0)
                {
                  case 0:
                  case 2:
                    goto label_39;
                  default:
                    num1 = (short) 0;
                    if (num1 == (short) 0)
                      goto label_22;
                    goto label_22;
                }
              case 3:
                switch (0)
                {
                  case 0:
                    goto label_5;
                  default:
                    continue;
                }
              case 4:
                num1 = (short) 12;
                num2 = (int) (IntPtr) num1;
                continue;
              case 5:
                this.cmbModelNum.Items.Clear();
                num1 = (short) 2;
                num2 = (int) (IntPtr) num1;
                continue;
              case 6:
                dictionary = this.j[selectedIndex];
                num1 = (short) 15;
                num2 = (int) (IntPtr) num1;
                continue;
              case 7:
                goto label_44;
              case 8:
                if (this.cmbModelNum != null)
                {
                  num1 = (short) 9;
                  num2 = (int) (IntPtr) num1;
                  continue;
                }
                goto case 1;
              case 9:
                num1 = (short) 13;
                num2 = (int) (IntPtr) num1;
                continue;
              case 10:
                enumerator = dictionary.Keys.GetEnumerator();
                goto label_39;
              case 11:
                this.cmbModelNum.SelectedIndex = 0;
                num1 = (short) 1;
                num2 = (int) (IntPtr) num1;
                continue;
              case 12:
                if (this.j.ContainsKey(selectedIndex))
                {
                  num1 = (short) 6;
                  num2 = (int) (IntPtr) num1;
                  continue;
                }
                break;
              case 13:
                if (this.cmbModelNum.Items.Count > 0)
                {
                  num1 = (short) 11;
                  num2 = (int) (IntPtr) num1;
                  continue;
                }
                goto case 1;
              case 14:
                try
                {
                  num1 = (short) 0;
                  int num5 = (int) (IntPtr) num1;
                  while (true)
                  {
                    string current;
                    ComboBoxItem newItem;
                    switch (num5)
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
                        goto label_7;
                      case 2:
                        if (!enumerator.MoveNext())
                        {
                          num1 = (short) 4;
                          num5 = (int) (IntPtr) num1;
                          continue;
                        }
                        current = enumerator.Current;
                        newItem = new ComboBoxItem();
                        newItem.Content = (object) current;
                        new System.Windows.Controls.ToolTip().Content = (object) dictionary[current];
                        newItem.ToolTip = (object) dictionary[current];
                        num1 = (short) 3;
                        num5 = (int) (IntPtr) num1;
                        continue;
                      case 3:
                        if (Array.IndexOf<string>(new string[1]
                        {
                          RptMgrErrorHandler.b("쎊떌뮎욐킒톔꺖즘첚ꢜ\uDE9E\uEFA0", A_1_1)
                        }, current) <= -1)
                        {
                          num1 = (short) 6;
                          num5 = (int) (IntPtr) num1;
                          continue;
                        }
                        break;
                      case 4:
                        num1 = (short) 1;
                        num5 = (int) (IntPtr) num1;
                        continue;
                      case 6:
                        this.cmbModelNum.Items.Add((object) newItem);
                        num1 = (short) 5;
                        num5 = (int) (IntPtr) num1;
                        continue;
                    }
                    num1 = (short) 2;
                    num5 = (int) (IntPtr) num1;
                  }
                }
                finally
                {
                  enumerator.Dispose();
                }
              case 15:
                if (dictionary != null)
                {
                  num1 = (short) 10;
                  num2 = (int) (IntPtr) num1;
                  continue;
                }
                break;
              default:
label_5:
                if (this.cmbModelNum.Items.Count > 0)
                {
                  num1 = (short) 5;
                  num2 = (int) (IntPtr) num1;
                  continue;
                }
                goto label_22;
            }
label_7:
            num1 = (short) 8;
            num2 = (int) (IntPtr) num1;
            continue;
label_22:
            selectedIndex = ((Selector) A_0).SelectedIndex;
            num1 = (short) 0;
            num2 = (int) (IntPtr) num1;
            continue;
label_39:
            num1 = (short) 14;
            num2 = (int) (IntPtr) num1;
          }
      }
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show(ex.Message);
    }
label_44:
    short num6 = 0;
    num6 = (short) 1;
    if (num6 == (short) 0)
      ;
  }

  private void cmbModelNum_SelectionChanged(object A_0, SelectionChangedEventArgs A_1)
  {
    short num1;
    switch (true ? 1 : 0)
    {
      case 0:
      case 2:
        try
        {
          num1 = (short) 1;
          if (num1 == (short) 0)
            ;
          int num2;
          ComboBoxItem comboBoxItem;
          int selectedIndex;
          switch (0)
          {
            case 0:
label_6:
              comboBoxItem = this.cmbModelNum.Items[this.cmbModelNum.SelectedIndex] as ComboBoxItem;
              selectedIndex = this.cmbRadio.SelectedIndex;
              num1 = (short) 0;
              num2 = (int) (IntPtr) num1;
              goto default;
            default:
              while (true)
              {
                switch (num2)
                {
                  case 0:
                    if (this.j != null)
                    {
                      num1 = (short) 3;
                      num2 = (int) (IntPtr) num1;
                      continue;
                    }
                    goto case 5;
                  case 1:
                    System.Windows.Controls.ToolTip toolTip = new System.Windows.Controls.ToolTip();
                    toolTip.Content = (object) this.j[selectedIndex][comboBoxItem.Content as string];
                    this.cmbModelNum.ToolTip = (object) toolTip;
                    num1 = (short) 5;
                    num2 = (int) (IntPtr) num1;
                    continue;
                  case 2:
                    if (this.j.ContainsKey(selectedIndex))
                    {
                      num1 = (short) 1;
                      num2 = (int) (IntPtr) num1;
                      continue;
                    }
                    goto case 5;
                  case 3:
                    num1 = (short) 2;
                    num2 = (int) (IntPtr) num1;
                    continue;
                  case 4:
                    goto label_12;
                  case 5:
                    num1 = (short) 4;
                    num2 = (int) (IntPtr) num1;
                    continue;
                  default:
                    goto label_6;
                }
              }
label_12:
              return;
          }
        }
        catch (Exception ex)
        {
          int num3 = (int) MessageBox.Show(ex.Message);
          break;
        }
      default:
        num1 = (short) 0;
        if (num1 == (short) 0)
          ;
        if (this.cmbModelNum.SelectedIndex <= -1)
          break;
        goto case 0;
    }
  }

  private void b()
  {
    int num1 = 3;
    while (true)
    {
      short num2;
      Brush brush1;
      Brush brush2;
      switch (num1)
      {
        case 0:
label_13:
          if (!this.b)
          {
            num2 = (short) 4;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          num2 = (short) 11;
          num1 = (int) (IntPtr) num2;
          continue;
        case 1:
          num2 = (short) 15;
          num1 = (int) (IntPtr) num2;
          continue;
        case 2:
          if (this.cmbRegion != null)
          {
            num2 = (short) 1;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto case 14;
        case 3:
          num2 = (short) 21295;
          int num3 = (int) num2;
          num2 = (short) 21295;
          int num4 = (int) num2;
          switch (num3 == num4 ? 1 : 0)
          {
            case 0:
            case 2:
              goto label_13;
            default:
              num2 = (short) 0;
              if (num2 == (short) 0)
                ;
              switch (0)
              {
                case 0:
                  goto label_5;
                default:
                  continue;
              }
          }
        case 4:
          num2 = (short) 13;
          num1 = (int) (IntPtr) num2;
          continue;
        case 5:
          num2 = (short) 8;
          num1 = (int) (IntPtr) num2;
          continue;
        case 6:
          this.c = false;
          num2 = (short) 14;
          num1 = (int) (IntPtr) num2;
          continue;
        case 7:
          goto label_30;
        case 8:
          brush1 = (Brush) Brushes.Red;
          break;
        case 9:
          num2 = (short) 1;
          if (num2 == (short) 0)
            ;
          num2 = (short) 0;
          brush1 = this.NormalBorder;
          break;
        case 10:
          num2 = (short) 12;
          num1 = (int) (IntPtr) num2;
          continue;
        case 11:
          brush2 = this.NormalBorder;
          goto label_19;
        case 12:
          if (((Control) this.cmbRegion.SelectedItem).Foreground == Brushes.Red)
          {
            num2 = (short) 6;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto case 14;
        case 13:
          brush2 = (Brush) Brushes.Red;
          goto label_19;
        case 14:
          num2 = (short) 7;
          num1 = (int) (IntPtr) num2;
          continue;
        case 15:
          if (this.cmbRegion.SelectedIndex == 1)
          {
            num2 = (short) 10;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto case 14;
        default:
label_5:
          if (!this.a)
          {
            num2 = (short) 5;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          num2 = (short) 9;
          num1 = (int) (IntPtr) num2;
          continue;
      }
      Brush brush3 = brush1;
      num2 = (short) 0;
      num1 = (int) (IntPtr) num2;
      continue;
label_19:
      Brush brush4 = brush2;
      this.txtFlashCode1.BorderBrush = brush3;
      this.txtFlashCode2.BorderBrush = brush3;
      this.txtFlashCodeCheckSum.BorderBrush = brush3;
      this.txtSerNum.BorderBrush = brush4;
      this.c = true;
      num2 = (short) 2;
      num1 = (int) (IntPtr) num2;
    }
label_30:
    this.btnOK.IsEnabled = this.a && this.b && this.c;
  }

  private Brush NormalBorder
  {
    get
    {
      switch (true)
      {
        case true:
          if (false)
            ;
          if (true)
            ;
          return this.cmbRadio.BorderBrush;
        default:
          goto case 1;
      }
    }
  }

  private void btnCancel_Click(object A_0, RoutedEventArgs A_1)
  {
    short num1 = 0;
    num1 = (short) -18281;
    int num2 = (int) num1;
    num1 = (short) -18281;
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
        this.Close();
        break;
      default:
        goto case 1;
    }
  }

  private void cmbRegion_SelectionChanged(object A_0, SelectionChangedEventArgs A_1)
  {
    short num1 = 0;
    num1 = (short) 18028;
    int num2 = (int) num1;
    num1 = (short) 18028;
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
        this.b();
        break;
      default:
        goto case 1;
    }
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "5.0.10.0")]
  public void InitializeComponent()
  {
    int A_1 = 8;
    while (this.m)
    {
      short num1 = 0;
      num1 = (short) 31752;
      int num2 = (int) num1;
      num1 = (short) 31752;
      int num3 = (int) num1;
      switch (num2 == num3 ? 1 : 0)
      {
        case 0:
        case 2:
          continue;
        default:
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          num1 = (short) 1;
          if (num1 == (short) 0)
            ;
          return;
      }
    }
    this.m = true;
    Application.LoadComponent((object) this, new Uri(RptMgrErrorHandler.b("ꒊ\uDE8Cﾎ\uF490\uF092ﲔ\uF696\uF598\uDD9A\uF89Cﺞ햠횢\uD7A4슦\uDAA8邪캬삮\uDCB0쎲\uDAB4\uD9B6\uDCB8햺즼邾ꗀꛂ뗄\uA8C6뷈\uA7CA곌귎ꗐ볒뫔믖\uF6D8뿚룜꿞軠韢蛤闦賨諪駬諮鋰鳲釴鋶觸韺裼飾瘀洂愄⤆焈樊怌挎", A_1), UriKind.Relative));
  }

  [EditorBrowsable(EditorBrowsableState.Never)]
  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "5.0.10.0")]
  void IComponentConnector.Connect(int connectionId, object target)
  {
    int num1 = 2;
    short num2;
    while (true)
    {
      switch (num1)
      {
        case 0:
          goto label_18;
        case 1:
          num2 = (short) 0;
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
      }
      switch (connectionId)
      {
        case 1:
          goto label_29;
        case 2:
          goto label_9;
        case 3:
          goto label_19;
        case 4:
          goto label_7;
        case 5:
          goto label_13;
        case 6:
          goto label_20;
        case 7:
          goto label_23;
        case 8:
          goto label_16;
        case 9:
          goto label_26;
        case 10:
          goto label_12;
        case 11:
          goto label_27;
        case 12:
          goto label_6;
        case 13:
          goto label_28;
        case 14:
          goto label_10;
        case 15:
          goto label_5;
        case 16 /*0x10*/:
          goto label_25;
        case 17:
          goto label_24;
        case 18:
          goto label_8;
        case 19:
          goto label_14;
        case 20:
          goto label_11;
        case 21:
          goto label_15;
        default:
          num2 = (short) 1;
          num1 = (int) (IntPtr) num2;
          continue;
      }
    }
label_5:
    this.labelRegion = (Label) target;
    return;
label_6:
    this.btnOK = (Button) target;
    this.btnOK.Click += new RoutedEventHandler(this.btnOK_Click);
    return;
label_7:
    this.cmbModelNum = (ComboBox) target;
    return;
label_8:
    this.cbAPX6000P25 = (CheckBox) target;
    return;
label_9:
    this.cmbRadio = (ComboBox) target;
    return;
label_10:
    num2 = (short) 0;
    this.txtSerNum = (TextBox) target;
    this.txtSerNum.TextChanged += new TextChangedEventHandler(this.txtSerNum_TextChanged);
    return;
label_11:
    this.cbDualKnobs = (CheckBox) target;
    return;
label_12:
    this.label7 = (Label) target;
    return;
label_13:
    this.label4 = (Label) target;
    return;
label_14:
    this.cbMariTimeRadio = (CheckBox) target;
    return;
label_15:
    this.cbDisableEnc = (CheckBox) target;
    return;
label_16:
    this.label6 = (Label) target;
    return;
label_18:
    num2 = (short) 1;
    if (num2 == (short) 0)
      ;
    this.m = true;
    return;
label_19:
    this.label3 = (Label) target;
    return;
label_20:
    num2 = (short) -20333;
    int num3 = (int) num2;
    num2 = (short) -20333;
    int num4 = (int) num2;
    switch (num3 == num4 ? 1 : 0)
    {
      case 0:
      case 2:
        goto label_14;
      default:
        num2 = (short) 0;
        if (num2 == (short) 0)
          ;
        this.label5 = (Label) target;
        return;
    }
label_23:
    this.txtFlashCode1 = (TextBox) target;
    this.txtFlashCode1.TextChanged += new TextChangedEventHandler(this.txtFlashCode_TextChanged);
    return;
label_24:
    this.cbULP = (CheckBox) target;
    return;
label_25:
    this.cmbRegion = (ComboBox) target;
    this.cmbRegion.SelectionChanged += new SelectionChangedEventHandler(this.cmbRegion_SelectionChanged);
    return;
label_26:
    this.txtFlashCode2 = (TextBox) target;
    this.txtFlashCode2.TextChanged += new TextChangedEventHandler(this.txtFlashCode_TextChanged);
    return;
label_27:
    this.txtFlashCodeCheckSum = (TextBox) target;
    return;
label_28:
    this.btnCancel = (Button) target;
    return;
label_29:
    this.label1 = (Label) target;
  }
}
