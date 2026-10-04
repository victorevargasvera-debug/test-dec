// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.DepotLabtool.DepotUpgradeCodeplugWnd
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using AcpBusinessLayer;
using AcpCommonLib;
using AcpUI.Common;
using SpecialFeatures.AcpReportManagerLib;
using SpecialFeatures.Flashport.FlashRadio;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;

#nullable disable
namespace SpecialFeatures.DepotLabtool;

public partial class DepotUpgradeCodeplugWnd : Window, IComponentConnector
{
  private bool a = true;
  private bool b = true;
  private string c = "";
  private UpgradeRadioData d = new UpgradeRadioData();
  private PCIHandler e = new PCIHandler();
  internal GroupBox groupBox1;
  internal Grid grid1;
  internal Label label1;
  internal TextBox txtModelNumber;
  internal Label label3;
  internal TextBox txtSerNum;
  internal Label label2;
  internal TextBox txtFlashCode1;
  internal Label label5;
  internal TextBox txtFlashCode2;
  internal Label label6;
  internal TextBox txtFlashCodeCheckSum;
  internal CheckBox cbDisableEnc;
  internal Button btnOK;
  internal Button button2;
  private bool g;

  public DepotUpgradeCodeplugWnd()
  {
    this.DepotOptions = new List<string>();
    this.InitializeComponent();
    Utility.SetDirection((FrameworkElement) this);
  }

  public string ModelNumber
  {
    set
    {
      short num1 = -28387;
      int num2 = (int) num1;
      num1 = (short) -28387;
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
          this.txtModelNumber.Text = value;
          break;
        default:
          num4 = (short) 0;
          goto case 1;
      }
    }
    get
    {
      short num1 = -8907;
      int num2 = (int) num1;
      num1 = (short) -8907;
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
          return this.txtModelNumber.Text.ToString();
        default:
          num4 = (short) 0;
          goto case 1;
      }
    }
  }

  public string SerialNumber
  {
    set
    {
      short num1 = -18379;
      int num2 = (int) num1;
      num1 = (short) -18379;
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
          this.txtSerNum.Text = value;
          break;
        default:
          num4 = (short) 0;
          goto case 1;
      }
    }
    get
    {
      short num1 = -5051;
      int num2 = (int) num1;
      num1 = (short) -5051;
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
          return this.txtSerNum.Text.ToString();
        default:
          num4 = (short) 0;
          goto case 1;
      }
    }
  }

  public string FlashCode
  {
    set
    {
      short num1 = -15526;
      int num2 = (int) num1;
      num1 = (short) -15526;
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
          string[] strArray = DepotUpgradeCodeplugWnd.a(value);
          this.txtFlashCode1.Text = strArray[0];
          this.txtFlashCode2.Text = strArray[1];
          this.txtFlashCodeCheckSum.Text = strArray[2];
          break;
        default:
          num4 = (short) 0;
          goto case 1;
      }
    }
    get
    {
      int A_1 = 9;
      short num1 = 29772;
      int num2 = (int) num1;
      num1 = (short) 29772;
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
          return this.txtFlashCode1.Text + RptMgrErrorHandler.b("ꆋ", A_1) + this.txtFlashCode2.Text + RptMgrErrorHandler.b("ꆋ", A_1) + this.txtFlashCodeCheckSum.Text;
        default:
          goto case 1;
      }
    }
  }

  public string FwVersion
  {
    set
    {
      short num1 = -21322;
      int num2 = (int) num1;
      num1 = (short) -21322;
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
          this.c = value;
          break;
        default:
          num4 = (short) 0;
          goto case 1;
      }
    }
    get
    {
      short num1 = 19551;
      int num2 = (int) num1;
      num1 = (short) 19551;
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
          return this.c;
        default:
          num4 = (short) 0;
          goto case 1;
      }
    }
  }

  public bool DisableEnc
  {
    set
    {
      short num1 = 17750;
      int num2 = (int) num1;
      num1 = (short) 17750;
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
          this.cbDisableEnc.IsChecked = new bool?(value);
          break;
        default:
          num4 = (short) 0;
          goto case 1;
      }
    }
    get
    {
      short num1 = -29733;
      int num2 = (int) num1;
      num1 = (short) -29733;
      int num3 = (int) num1;
      switch (num2 == num3 ? 1 : 0)
      {
        case 0:
        case 2:
          return true;
        default:
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          bool? isChecked = this.cbDisableEnc.IsChecked;
          bool flag = true;
          if (!(isChecked.GetValueOrDefault() == flag & isChecked.HasValue))
          {
            num1 = (short) 1;
            if (num1 == (short) 0)
              ;
            return false;
          }
          goto case 0;
      }
    }
  }

  private static string[] a(string A_0)
  {
    short num1 = 17852;
    int num2 = (int) num1;
    num1 = (short) 17852;
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
        return A_0.Trim().Split('-');
      default:
        num4 = (short) 0;
        goto case 1;
    }
  }

  private static string a(string[] A_0)
  {
    int A_1 = 14;
    short num1 = -6329;
    int num2 = (int) num1;
    num1 = (short) -6329;
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
        return A_0[0] + RptMgrErrorHandler.b("벐", A_1) + A_0[1] + RptMgrErrorHandler.b("벐", A_1) + A_0[2];
      default:
        num4 = (short) 0;
        goto case 1;
    }
  }

  private void c()
  {
    int A_1 = 5;
    short num1 = 1;
    if (num1 == (short) 0)
      ;
    num1 = (short) -8993;
    int num2 = (int) num1;
    num1 = (short) -8993;
    int num3 = (int) num1;
    int num4;
    switch (num2 == num3 ? 1 : 0)
    {
      case 0:
      case 2:
label_4:
        this.e.AddPCIOptionsForUpgrade();
        try
        {
          Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide radioWide;
          switch (0)
          {
            case 0:
label_7:
              radioWide = FeatureManager.GetFeature(2045)[0] as Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide;
              num1 = (short) 13;
              num4 = (int) (IntPtr) num1;
              goto default;
            default:
              Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation radioInformation;
              byte flashcodeIntValue;
              bool? isChecked;
              bool flag;
              while (true)
              {
                switch (num4)
                {
                  case 0:
                    isChecked = this.cbDisableEnc.IsChecked;
                    flag = false;
                    num1 = (short) 4;
                    num4 = (int) (IntPtr) num1;
                    continue;
                  case 1:
                    num1 = (short) 7;
                    num4 = (int) (IntPtr) num1;
                    continue;
                  case 2:
                    if (this.txtFlashCode2.Text.Length == 6)
                    {
                      num1 = (short) 18;
                      num4 = (int) (IntPtr) num1;
                      continue;
                    }
                    goto case 12;
                  case 3:
                  case 8:
                    num1 = (short) 16 /*0x10*/;
                    num4 = (int) (IntPtr) num1;
                    continue;
                  case 4:
                    if (!(isChecked.GetValueOrDefault() == flag & isChecked.HasValue))
                    {
                      radioWide.Labtool.RadWideLabtoolDisableEncryption_43371.SetValue(true);
                      num1 = (short) 3;
                      num4 = (int) (IntPtr) num1;
                      continue;
                    }
                    num1 = (short) 20;
                    num4 = (int) (IntPtr) num1;
                    continue;
                  case 5:
                    if (((int) flashcodeIntValue & 8) == 0)
                    {
                      radioWide.Labtool.RadWideLabtoolAPX6000P25Radio_A42121.SetValue(false);
                      num1 = (short) 12;
                      num4 = (int) (IntPtr) num1;
                      continue;
                    }
                    num1 = (short) 9;
                    num4 = (int) (IntPtr) num1;
                    continue;
                  case 6:
                    goto label_35;
                  case 7:
                    if (this.txtModelNumber.Text.StartsWith(RptMgrErrorHandler.b("삇뎉뒋", A_1)))
                    {
                      num1 = (short) 19;
                      num4 = (int) (IntPtr) num1;
                      continue;
                    }
                    goto case 12;
                  case 9:
                    radioWide.Labtool.RadWideLabtoolAPX6000P25Radio_A42121.SetValue(true);
                    num1 = (short) 17;
                    num4 = (int) (IntPtr) num1;
                    continue;
                  case 10:
                    num1 = (short) 5;
                    num4 = (int) (IntPtr) num1;
                    continue;
                  case 11:
                    if (((AcpField<int>) radioInformation.Labtool.RadInfoLabtoolProductModelIdentifier_A37178).Value == 3)
                    {
                      num1 = (short) 10;
                      num4 = (int) (IntPtr) num1;
                      continue;
                    }
                    goto case 12;
                  case 12:
                  case 17:
                    num1 = (short) 6;
                    num4 = (int) (IntPtr) num1;
                    continue;
                  case 13:
                    if (radioWide != null)
                    {
                      num1 = (short) 0;
                      num4 = (int) (IntPtr) num1;
                      continue;
                    }
                    goto case 12;
                  case 14:
                    num1 = (short) 2;
                    num4 = (int) (IntPtr) num1;
                    continue;
                  case 15:
                    if (radioInformation != null)
                    {
                      num1 = (short) 1;
                      num4 = (int) (IntPtr) num1;
                      continue;
                    }
                    goto case 12;
                  case 16 /*0x10*/:
                    if (this.txtFlashCode2 != null)
                    {
                      num1 = (short) 14;
                      num4 = (int) (IntPtr) num1;
                      continue;
                    }
                    goto case 12;
                  case 18:
                    flashcodeIntValue = (byte) FlashcodeMapping.GetFlashcodeIntValue(this.txtFlashCode2.Text[5]);
                    radioInformation = FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation;
                    num1 = (short) 15;
                    num4 = (int) (IntPtr) num1;
                    continue;
                  case 19:
                    num1 = (short) 11;
                    num4 = (int) (IntPtr) num1;
                    continue;
                  case 20:
                    radioWide.Labtool.RadWideLabtoolDisableEncryption_43371.SetValue(false);
                    num1 = (short) 8;
                    num4 = (int) (IntPtr) num1;
                    continue;
                  default:
                    goto label_7;
                }
              }
label_35:
              return;
          }
        }
        catch (Exception ex)
        {
          break;
        }
      default:
        num1 = (short) 0;
        num1 = (short) 0;
        if (num1 == (short) 0)
          ;
        num1 = (short) 0;
        num4 = (int) num1;
        switch (num4)
        {
          default:
            goto label_4;
        }
    }
  }

  private void btnOK_Click(object A_0, RoutedEventArgs A_1)
  {
    int A_1_1 = 13;
    int num1;
    short num2;
    switch (0)
    {
      case 0:
label_2:
        num2 = (short) -4305;
        int num3 = (int) num2;
        num2 = (short) -4305;
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
            this.DepotOptions.Clear();
            this.c();
            num2 = (short) 0;
            num1 = (int) (IntPtr) num2;
            goto label_1;
        }
        break;
      default:
        while (true)
        {
          switch (num1)
          {
            case 0:
              if (this.txtModelNumber.Text == RptMgrErrorHandler.b("톏슑첓꺕ꢗꪙ겛", A_1_1))
              {
                num2 = (short) 0;
                num2 = (short) 1;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_9;
            case 1:
              goto label_7;
            case 2:
              goto label_9;
            default:
              goto label_2;
          }
label_1:;
        }
label_9:
        this.DialogResult = new bool?(true);
        return;
    }
label_7:
    num2 = (short) 1;
    if (num2 == (short) 0)
      ;
    this.txtFlashCode1.Text = this.txtFlashCode1.Text;
    num2 = (short) 2;
    num1 = (int) (IntPtr) num2;
    goto label_1;
  }

  private void txtFlashCode_TextChanged(object A_0, TextChangedEventArgs A_1)
  {
    int num1 = 2;
    short num2;
    while (true)
    {
      byte flashCodeCheckDigit;
      switch (num1)
      {
        case 0:
        case 4:
          goto label_21;
        case 1:
          goto label_8;
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
          num2 = (short) 8;
          num1 = (int) (IntPtr) num2;
          continue;
        case 5:
          if (this.txtFlashCode2 != null)
          {
            num2 = (short) 3;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto label_8;
        case 6:
          num2 = (short) -22759;
          int num3 = (int) num2;
          num2 = (short) -22759;
          int num4 = (int) num2;
          switch (num3 == num4 ? 1 : 0)
          {
            case 0:
            case 2:
              goto label_18;
            default:
              num2 = (short) 0;
              if (num2 == (short) 0)
                ;
              num2 = (short) 5;
              num1 = (int) (IntPtr) num2;
              continue;
          }
        case 7:
          this.txtFlashCodeCheckSum.Text = flashCodeCheckDigit.ToString();
          this.a = FlashcodeValidator.Validate(this.FlashCode);
          num2 = (short) 4;
          num1 = (int) (IntPtr) num2;
          continue;
        case 8:
          if (this.txtFlashCodeCheckSum == null)
          {
            num2 = (short) 1;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          flashCodeCheckDigit = FlashcodeValidator.CalculateFlashCodeCheckDigit(this.txtFlashCode1.Text + this.txtFlashCode2.Text);
          num2 = (short) 9;
          num1 = (int) (IntPtr) num2;
          continue;
        case 9:
label_18:
          if (flashCodeCheckDigit == byte.MaxValue)
          {
            this.txtFlashCodeCheckSum.Text = ' '.ToString();
            this.a = false;
            num2 = (short) 0;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          num2 = (short) 7;
          num1 = (int) (IntPtr) num2;
          continue;
      }
      num2 = (short) 0;
      if (this.txtFlashCode1 != null)
      {
        num2 = (short) 6;
        num1 = (int) (IntPtr) num2;
      }
      else
        break;
    }
label_8:
    num2 = (short) 1;
    if (num2 == (short) 0)
      ;
    return;
label_21:
    this.a();
  }

  private void txtSerNum_TextChanged(object A_0, TextChangedEventArgs A_1)
  {
    short num1 = 32058;
    int num2 = (int) num1;
    num1 = (short) 32058;
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
        this.b = SerialNumberValidator.ValidateSerialNumber(Convert.ToBase64String(Encoding.ASCII.GetBytes(this.txtSerNum.Text.ToString().Trim())));
        this.a();
        break;
      default:
        num4 = (short) 0;
        goto case 1;
    }
  }

  private Brush NormalBorder
  {
    get
    {
      short num1 = -13317;
      int num2 = (int) num1;
      num1 = (short) -13317;
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
          return this.txtModelNumber.BorderBrush;
        default:
          num4 = (short) 0;
          goto case 1;
      }
    }
  }

  public List<string> DepotOptions
  {
    get
    {
      short num1 = -15621;
      int num2 = (int) num1;
      num1 = (short) -15621;
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
          return this.f;
        default:
          num4 = (short) 0;
          goto case 1;
      }
    }
    internal set
    {
      short num1 = -6061;
      int num2 = (int) num1;
      num1 = (short) -6061;
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
          this.f = value;
          break;
        default:
          num4 = (short) 0;
          goto case 1;
      }
    }
  }

  private void a()
  {
    int num1 = 1;
    while (true)
    {
      short num2 = 1;
      if (num2 == (short) 0)
        ;
      Brush brush1;
      Brush brush2;
      switch (num1)
      {
        case 0:
          goto label_20;
        case 1:
          switch (0)
          {
            case 0:
              goto label_4;
            default:
              continue;
          }
        case 2:
          brush1 = this.NormalBorder;
          break;
        case 3:
          brush1 = (Brush) Brushes.Red;
          break;
        case 4:
          brush2 = this.NormalBorder;
          goto label_19;
        case 5:
          num2 = (short) 0;
          num2 = (short) 3;
          num1 = (int) (IntPtr) num2;
          continue;
        case 6:
          if (this.b)
          {
            num2 = (short) 4;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          num2 = (short) 7;
          num1 = (int) (IntPtr) num2;
          continue;
        case 7:
label_15:
          num2 = (short) 8;
          num1 = (int) (IntPtr) num2;
          continue;
        case 8:
          num2 = (short) 23024;
          int num3 = (int) num2;
          num2 = (short) 23024;
          int num4 = (int) num2;
          switch (num3 == num4 ? 1 : 0)
          {
            case 0:
            case 2:
              goto label_15;
            default:
              num2 = (short) 0;
              if (num2 == (short) 0)
                ;
              brush2 = (Brush) Brushes.Red;
              goto label_19;
          }
        default:
label_4:
          if (!this.a)
          {
            num2 = (short) 5;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          num2 = (short) 2;
          num1 = (int) (IntPtr) num2;
          continue;
      }
      Brush brush3 = brush1;
      num2 = (short) 6;
      num1 = (int) (IntPtr) num2;
      continue;
label_19:
      Brush brush4 = brush2;
      this.txtFlashCode1.BorderBrush = brush3;
      this.txtFlashCode2.BorderBrush = brush3;
      this.txtFlashCodeCheckSum.BorderBrush = brush3;
      this.txtSerNum.BorderBrush = brush4;
      num2 = (short) 0;
      num1 = (int) (IntPtr) num2;
    }
label_20:
    this.btnOK.IsEnabled = this.a && this.b;
  }

  [GeneratedCode("PresentationBuildTasks", "5.0.10.0")]
  [DebuggerNonUserCode]
  public void InitializeComponent()
  {
    int A_1 = 16 /*0x10*/;
    if (this.g)
    {
      short num = -14475;
      switch ((short) -14475 == num ? 1 : 0)
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
    this.g = true;
    Application.LoadComponent((object) this, new Uri(RptMgrErrorHandler.b("벒요\uE796ﲘ\uF89A\uF49Cﺞ춠\uE5A2삤욦\uDDA8\uDEAA\uDFAC쪮슰袲횴\uD8B6풸쮺튼톾꓀귂뇄\uE8C6귈껊뷌ꃎꗐ뿒듔뗖귘듚닜돞컠蟢胤韦蛨\u9FEA飬\u9FEE雰臲铴鏶鳸飺鋼鯾搀猂椄爆済簊挌欎㼐欒琔稖甘", A_1), UriKind.Relative));
  }

  [EditorBrowsable(EditorBrowsableState.Never)]
  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "5.0.10.0")]
  void IComponentConnector.Connect(int connectionId, object target)
  {
    short num1 = 1;
    if (num1 == (short) 0)
      ;
    num1 = (short) 0;
    num1 = (short) 1;
    int num2 = (int) (IntPtr) num1;
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
              goto label_4;
            default:
              continue;
          }
        case 2:
label_20:
          num1 = (short) 0;
          num2 = (int) (IntPtr) num1;
          continue;
        default:
label_4:
          switch (connectionId)
          {
            case 1:
              goto label_10;
            case 2:
              goto label_16;
            case 3:
              goto label_8;
            case 4:
              goto label_21;
            case 5:
              goto label_19;
            case 6:
              goto label_22;
            case 7:
              goto label_15;
            case 8:
              goto label_7;
            case 9:
              goto label_23;
            case 10:
              num1 = (short) -31072;
              int num3 = (int) num1;
              num1 = (short) -31072;
              int num4 = (int) num1;
              switch (num3 == num4 ? 1 : 0)
              {
                case 0:
                case 2:
                  goto label_20;
                default:
                  goto label_12;
              }
            case 11:
              goto label_6;
            case 12:
              goto label_18;
            case 13:
              goto label_9;
            case 14:
              goto label_17;
            case 15:
              goto label_14;
            default:
              num1 = (short) 2;
              num2 = (int) (IntPtr) num1;
              continue;
          }
      }
    }
label_6:
    this.label6 = (Label) target;
    return;
label_7:
    this.txtFlashCode1 = (TextBox) target;
    this.txtFlashCode1.TextChanged += new TextChangedEventHandler(this.txtFlashCode_TextChanged);
    return;
label_8:
    this.label1 = (Label) target;
    return;
label_9:
    this.cbDisableEnc = (CheckBox) target;
    return;
label_10:
    this.groupBox1 = (GroupBox) target;
    return;
label_12:
    num1 = (short) 0;
    if (num1 == (short) 0)
      ;
    this.txtFlashCode2 = (TextBox) target;
    this.txtFlashCode2.TextChanged += new TextChangedEventHandler(this.txtFlashCode_TextChanged);
    return;
label_14:
    this.button2 = (Button) target;
    return;
label_15:
    this.label2 = (Label) target;
    return;
label_16:
    this.grid1 = (Grid) target;
    return;
label_17:
    this.btnOK = (Button) target;
    this.btnOK.Click += new RoutedEventHandler(this.btnOK_Click);
    return;
label_18:
    this.txtFlashCodeCheckSum = (TextBox) target;
    return;
label_19:
    this.label3 = (Label) target;
    return;
label_21:
    this.txtModelNumber = (TextBox) target;
    return;
label_22:
    this.txtSerNum = (TextBox) target;
    this.txtSerNum.TextChanged += new TextChangedEventHandler(this.txtSerNum_TextChanged);
    return;
label_23:
    this.label5 = (Label) target;
    return;
label_24:
    this.g = true;
  }
}
