// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.DepotLabtool.DepotUpgradeRadioWnd
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using AcpFileHandlerLib;
using AcpUI.Common;
using AcpUtility;
using CommonResources;
using CommonUtility;
using SpecialFeatures.AcpReportManagerLib;
using SpecialFeatures.Flashport.FlashRadio;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;

#nullable disable
namespace SpecialFeatures.DepotLabtool;

public partial class DepotUpgradeRadioWnd : Window, IComponentConnector
{
  private bool a;
  private bool b;
  private UpgradeRadioData c = new UpgradeRadioData();
  internal GroupBox groupBox1;
  internal Grid grid1;
  internal Label label1;
  internal TextBox txtModelNumber;
  internal Label label2;
  internal TextBox txtFlashCode1;
  internal Label label5;
  internal TextBox txtFlashCode2;
  internal Label label6;
  internal TextBox txtFlashCodeCheckSum;
  internal GroupBox groupBox2;
  internal Label label3;
  internal TextBox txtFlashUpgradeFile;
  internal Button btnBrowse;
  internal GroupBox groupBox3;
  internal Label label4;
  internal TextBox txtNewFlashCode1;
  internal TextBox txtNewFlashCode2;
  internal TextBox txtNewFlashCodeCheckSum;
  internal Label label7;
  internal Label label8;
  internal Button btnOK;
  internal Button button2;
  private bool d;

  public DepotUpgradeRadioWnd()
  {
    this.InitializeComponent();
    this.upgradeFile = "";
    Utility.SetDirection((FrameworkElement) this);
  }

  public string ModelNumber
  {
    set
    {
      short num1 = -6402;
      int num2 = (int) num1;
      num1 = (short) -6402;
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
          this.txtModelNumber.Text = value;
          break;
        default:
          goto case 1;
      }
    }
    get
    {
      short num1 = 1;
      if (num1 == (short) 0)
        ;
      num1 = (short) 473;
      int num2 = (int) num1;
      num1 = (short) 473;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          num1 = (short) 0;
          return this.txtModelNumber.Text.ToString();
        default:
          goto case 1;
      }
    }
  }

  public string FlashCode
  {
    set
    {
      short num1 = -20570;
      int num2 = (int) num1;
      num1 = (short) -20570;
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
          string[] strArray = DepotUpgradeRadioWnd.a(value);
          this.txtFlashCode1.Text = strArray[0];
          this.txtFlashCode2.Text = strArray[1];
          this.txtFlashCodeCheckSum.Text = strArray[2];
          break;
        default:
          goto case 1;
      }
    }
  }

  private static string[] a(string A_0)
  {
    short num1 = -25862;
    int num2 = (int) num1;
    num1 = (short) -25862;
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
        return A_0.Trim().Split('-');
      default:
        goto case 1;
    }
  }

  private static string a(string[] A_0)
  {
    int A_1 = 15;
    short num1 = 1;
    if (num1 == (short) 0)
      ;
    num1 = (short) -10790;
    int num2 = (int) num1;
    num1 = (short) -10790;
    int num3 = (int) num1;
    switch (num2 == num3)
    {
      case true:
        num1 = (short) 0;
        if (num1 == (short) 0)
          ;
        num1 = (short) 0;
        return A_0[0] + RptMgrErrorHandler.b("뾑", A_1) + A_0[1] + RptMgrErrorHandler.b("뾑", A_1) + A_0[2];
      default:
        goto case 1;
    }
  }

  public string NewFlashCode
  {
    get
    {
      short num1 = -2755;
      int num2 = (int) num1;
      num1 = (short) -2755;
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
          return DepotUpgradeRadioWnd.a(new string[3]
          {
            this.txtNewFlashCode1.Text,
            this.txtNewFlashCode2.Text,
            this.txtNewFlashCodeCheckSum.Text
          });
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = -11745;
      int num2 = (int) num1;
      num1 = (short) -11745;
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
          string[] strArray = DepotUpgradeRadioWnd.a(value);
          this.txtNewFlashCode1.Text = strArray[0];
          this.txtNewFlashCode2.Text = strArray[1];
          this.txtNewFlashCodeCheckSum.Text = strArray[2];
          break;
        default:
          goto case 1;
      }
    }
  }

  public string upgradeFile
  {
    get
    {
      short num1 = -12463;
      int num2 = (int) num1;
      num1 = (short) -12463;
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
          return this.txtFlashUpgradeFile.Text;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = 1;
      if (num1 == (short) 0)
        ;
      num1 = (short) 25652;
      int num2 = (int) num1;
      num1 = (short) 25652;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          num1 = (short) 0;
          this.txtFlashUpgradeFile.Text = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  private void btnOK_Click(object A_0, RoutedEventArgs A_1)
  {
    int A_1_1 = 7;
    int num1 = 6;
    short num2;
    while (true)
    {
      switch (num1)
      {
        case 0:
          num2 = (short) 1;
          num1 = (int) (IntPtr) num2;
          continue;
        case 1:
          num2 = (short) 1;
          if (num2 == (short) 0)
            ;
          if (File.Exists(this.upgradeFile))
          {
            num2 = (short) 5;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          break;
        case 2:
          this.txtNewFlashCode1.Text = this.txtNewFlashCode1.Text;
          num2 = (short) 0;
          num1 = (int) (IntPtr) num2;
          continue;
        case 3:
          goto label_8;
        case 4:
label_6:
          if (!string.IsNullOrEmpty(this.upgradeFile))
          {
            num2 = (short) 3;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          break;
        case 5:
          num2 = (short) 4;
          num1 = (int) (IntPtr) num2;
          continue;
        case 6:
          switch (0)
          {
            case 0:
              goto label_3;
            default:
              continue;
          }
        default:
label_3:
          if (this.ModelNumber == RptMgrErrorHandler.b("쮉\uDC8B획ꢏꊑ꒓ꚕ", A_1_1))
          {
            num2 = (short) 2;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto case 0;
      }
      num2 = (short) 6953;
      int num3 = (int) num2;
      num2 = (short) 6953;
      int num4 = (int) num2;
      switch (num3 == num4 ? 1 : 0)
      {
        case 0:
        case 2:
          goto label_6;
        default:
          goto label_15;
      }
    }
label_8:
    num2 = (short) 0;
    this.c.UpgradeFile = this.upgradeFile;
    this.c.NewFlashCode = this.NewFlashCode;
    this.Hide();
    DepotPageUpgradeRadioProgressWnd radioProgressWnd = new DepotPageUpgradeRadioProgressWnd(this.c);
    radioProgressWnd.Owner = (Window) this;
    radioProgressWnd.progressBar2.Value = 0.0;
    radioProgressWnd.ShowDialog();
    return;
label_15:
    num2 = (short) 0;
    if (num2 == (short) 0)
      ;
    MessageWindow messageWindow = new MessageWindow(AppResources.Select_Valid_Upgrade_File);
    messageWindow.Owner = Window.GetWindow((DependencyObject) this);
    messageWindow.ShowDialog();
  }

  private void btnBrowse_Click(object A_0, RoutedEventArgs A_1)
  {
    int A_1_1 = 5;
    int num1;
    AcpOpenFileDialog acpOpenFileDialog;
    bool? nullable;
    bool flag;
    short num2;
    switch (0)
    {
      case 0:
label_2:
        acpOpenFileDialog = new AcpOpenFileDialog();
        ((AcpFileDialog) acpOpenFileDialog).Filter = AcpStringExtensions.AcpStringFormat(AppResources.FLASHport_Upgrade_Files, new object[1]
        {
          (object) RptMgrErrorHandler.b("ꢇꊉꚋꂍ\uF28F\uF091\uF293뾕\uE497낙늛ﲝ슟쒡\uD8A3\uE0A5\uE4A7\uEBA9ﾫ\uE6AD삯\uDDB1욳습颷\uEFB9첻\uD9BD늿ꏁꃃꏅ\uE8C7賉ꗋꋍ뗏ꇑ\uF4D3ﻕ\uF2D7\uF4D9뿛\uA8DD軟쯡飣쳥웧觩髫胭賯돱飳髵\uD8F7鳹闻鋽旿焁␃⸅∇␉☋✍氏㠑㨓㰕", A_1_1)
        });
        acpOpenFileDialog.MultiSelect = false;
        ((AcpFileDialog) acpOpenFileDialog).FileName = this.upgradeFile;
        nullable = ((AcpFileDialog) acpOpenFileDialog).ShowDialog();
        flag = true;
        num2 = (short) 2;
        num1 = (int) (IntPtr) num2;
        goto default;
      default:
        while (true)
        {
          switch (num1)
          {
            case 0:
              num2 = (short) 15146;
              int num3 = (int) num2;
              num2 = (short) 15146;
              int num4 = (int) num2;
              switch (num3 == num4 ? 1 : 0)
              {
                case 0:
                case 2:
                  goto label_5;
                default:
                  goto label_7;
              }
            case 1:
label_5:
              this.upgradeFile = ((AcpFileDialog) acpOpenFileDialog).FileName;
              num2 = (short) 0;
              num1 = (int) (IntPtr) num2;
              continue;
            case 2:
              if (nullable.GetValueOrDefault() == flag & nullable.HasValue)
              {
                num2 = (short) 1;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 0;
            default:
              goto label_2;
          }
        }
label_7:
        num2 = (short) 1;
        if (num2 == (short) 0)
          ;
        num2 = (short) 0;
        if (num2 == (short) 0)
          ;
        num2 = (short) 0;
        break;
    }
  }

  private void txtNewFlashCode_TextChanged(object A_0, TextChangedEventArgs A_1)
  {
    int num1 = 9;
    while (true)
    {
      short num2 = 1;
      if (num2 == (short) 0)
        ;
      num2 = (short) 0;
      byte flashCodeCheckDigit;
      switch (num1)
      {
        case 0:
          num2 = (short) 4;
          num1 = (int) (IntPtr) num2;
          continue;
        case 1:
          this.txtNewFlashCodeCheckSum.Text = flashCodeCheckDigit.ToString();
          this.b = FlashcodeValidator.Validate(this.NewFlashCode);
          num2 = (short) 3;
          num1 = (int) (IntPtr) num2;
          continue;
        case 2:
          num2 = (short) 7;
          num1 = (int) (IntPtr) num2;
          continue;
        case 3:
        case 6:
          goto label_24;
        case 4:
          if (this.txtNewFlashCodeCheckSum == null)
          {
            num2 = (short) 8;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          flashCodeCheckDigit = FlashcodeValidator.CalculateFlashCodeCheckDigit(this.txtNewFlashCode1.Text + this.txtNewFlashCode2.Text);
          num2 = (short) 5;
          num1 = (int) (IntPtr) num2;
          continue;
        case 5:
          if (flashCodeCheckDigit == byte.MaxValue)
          {
            this.txtNewFlashCodeCheckSum.Text = ' '.ToString();
            this.b = false;
            num2 = (short) 6;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          num2 = (short) 1;
          num1 = (int) (IntPtr) num2;
          continue;
        case 7:
          if (this.txtNewFlashCode2 != null)
          {
            num2 = (short) 0;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto label_13;
        case 8:
          goto label_9;
        case 9:
          num2 = (short) -31335;
          int num3 = (int) num2;
          num2 = (short) -31335;
          int num4 = (int) num2;
          switch (num3 == num4 ? 1 : 0)
          {
            case 0:
              goto label_23;
            case 2:
              goto label_19;
            default:
              num2 = (short) 0;
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
          }
      }
      if (this.txtNewFlashCode1 != null)
      {
        num2 = (short) 2;
        num1 = (int) (IntPtr) num2;
      }
      else
        goto label_15;
    }
label_23:
    return;
label_19:
    return;
label_9:
    return;
label_15:
    return;
label_13:
    return;
label_24:
    this.a();
  }

  private void txtFlashUpgradeFile_TextChanged(object A_0, TextChangedEventArgs A_1)
  {
    short num1 = 1;
    if (num1 == (short) 0)
      ;
    num1 = (short) 5002;
    int num2 = (int) num1;
    num1 = (short) 5002;
    int num3 = (int) num1;
    switch (num2 == num3)
    {
      case true:
        num1 = (short) 0;
        if (num1 == (short) 0)
          ;
        num1 = (short) 0;
        this.a = File.Exists(this.upgradeFile) && (BundleNameUtility.IsCVNFile(this.upgradeFile.Trim()) || BundleNameUtility.IsBBFFile(this.upgradeFile.Trim()));
        this.a();
        break;
      default:
        goto case 1;
    }
  }

  private void a()
  {
    int num1 = 8;
    while (true)
    {
      short num2;
      Brush brush1;
      Brush brush2;
      switch (num1)
      {
        case 0:
          num2 = (short) 1;
          if (num2 == (short) 0)
            ;
          brush2 = this.txtModelNumber.BorderBrush;
          num2 = (short) 7;
          num1 = (int) (IntPtr) num2;
          continue;
        case 1:
          if (!this.a)
          {
            brush2 = (Brush) Brushes.Red;
            num2 = (short) 6;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          num2 = (short) 0;
          num1 = (int) (IntPtr) num2;
          continue;
        case 2:
          num2 = (short) 21122;
          int num3 = (int) num2;
          num2 = (short) 21122;
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
              num2 = (short) 0;
              brush1 = this.txtModelNumber.BorderBrush;
              num2 = (short) 3;
              num1 = (int) (IntPtr) num2;
              continue;
          }
        case 3:
        case 5:
label_14:
          num2 = (short) 1;
          num1 = (int) (IntPtr) num2;
          continue;
        case 4:
          goto label_6;
        case 6:
        case 7:
          this.txtNewFlashCode1.BorderBrush = brush1;
          this.txtNewFlashCode2.BorderBrush = brush1;
          this.txtNewFlashCodeCheckSum.BorderBrush = brush1;
          this.txtFlashUpgradeFile.BorderBrush = brush2;
          num2 = (short) 4;
          num1 = (int) (IntPtr) num2;
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
      }
      if (this.b)
      {
        num2 = (short) 2;
        num1 = (int) (IntPtr) num2;
      }
      else
      {
        brush1 = (Brush) Brushes.Red;
        num2 = (short) 5;
        num1 = (int) (IntPtr) num2;
      }
    }
label_6:
    this.btnOK.IsEnabled = this.a && this.b;
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "5.0.10.0")]
  public void InitializeComponent()
  {
    int A_1 = 6;
    short num;
    if (this.d)
    {
      if (false)
        ;
      num = (short) -13072;
      switch ((short) -13072 == num ? 1 : 0)
      {
        case 0:
        case 2:
          break;
        default:
          num = (short) 0;
          if (num == (short) 0)
            ;
          return;
      }
    }
    num = (short) 0;
    this.d = true;
    Application.LoadComponent((object) this, new Uri(RptMgrErrorHandler.b("Ꚉ\uD88Aﶌ\uEA8E\uF290朗\uF494ﮖ\uDF98ﺚﲜ\uEB9E풠톢삤풦銨좪슬슮솰\uDCB2\uDBB4튶ힸ쾺銼\uDBBE꓀돂\uAAC4돆ꗈ\uAACA꿌믎뻐볒맔\uF8D6뷘뻚규냞闠離闤胦鯨諪觬諮菰鋲釴黶雸賺鏼鯾⼀笂搄樆攈", A_1), UriKind.Relative));
  }

  [GeneratedCode("PresentationBuildTasks", "5.0.10.0")]
  [EditorBrowsable(EditorBrowsableState.Never)]
  [DebuggerNonUserCode]
  void IComponentConnector.Connect(int connectionId, object target)
  {
    int num1 = 2;
    short num2;
    while (true)
    {
      switch (num1)
      {
        case 0:
          goto label_32;
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
          goto label_10;
        case 3:
          goto label_20;
        case 4:
          goto label_8;
        case 5:
          goto label_14;
        case 6:
          goto label_19;
        case 7:
          goto label_21;
        case 8:
          goto label_17;
        case 9:
          goto label_25;
        case 10:
          goto label_24;
        case 11:
          goto label_30;
        case 12:
          goto label_13;
        case 13:
          goto label_6;
        case 14:
          goto label_28;
        case 15:
          goto label_23;
        case 16 /*0x10*/:
          goto label_5;
        case 17:
          goto label_11;
        case 18:
          goto label_31;
        case 19:
          goto label_22;
        case 20:
          goto label_9;
        case 21:
          goto label_15;
        case 22:
          goto label_12;
        case 23:
          goto label_16;
        default:
          num2 = (short) 1;
          num1 = (int) (IntPtr) num2;
          continue;
      }
    }
label_5:
    this.label4 = (Label) target;
    return;
label_6:
    num2 = (short) 1;
    if (num2 == (short) 0)
      ;
    this.txtFlashUpgradeFile = (TextBox) target;
    this.txtFlashUpgradeFile.TextChanged += new TextChangedEventHandler(this.txtFlashUpgradeFile_TextChanged);
    return;
label_8:
    this.txtModelNumber = (TextBox) target;
    return;
label_9:
    this.label7 = (Label) target;
    return;
label_10:
    this.grid1 = (Grid) target;
    return;
label_11:
    this.txtNewFlashCode1 = (TextBox) target;
    this.txtNewFlashCode1.TextChanged += new TextChangedEventHandler(this.txtNewFlashCode_TextChanged);
    return;
label_12:
    this.btnOK = (Button) target;
    this.btnOK.Click += new RoutedEventHandler(this.btnOK_Click);
    return;
label_13:
    this.label3 = (Label) target;
    return;
label_14:
    num2 = (short) 0;
    this.label2 = (Label) target;
    return;
label_15:
    this.label8 = (Label) target;
    return;
label_16:
    this.button2 = (Button) target;
    return;
label_17:
    this.txtFlashCode2 = (TextBox) target;
    return;
label_19:
    this.txtFlashCode1 = (TextBox) target;
    return;
label_20:
    this.label1 = (Label) target;
    return;
label_21:
    this.label5 = (Label) target;
    return;
label_22:
    this.txtNewFlashCodeCheckSum = (TextBox) target;
    return;
label_23:
    this.groupBox3 = (GroupBox) target;
    return;
label_24:
    this.txtFlashCodeCheckSum = (TextBox) target;
    return;
label_25:
    num2 = (short) 27785;
    int num3 = (int) num2;
    num2 = (short) 27785;
    int num4 = (int) num2;
    switch (num3 == num4 ? 1 : 0)
    {
      case 0:
      case 2:
        goto label_8;
      default:
        num2 = (short) 0;
        if (num2 == (short) 0)
          ;
        this.label6 = (Label) target;
        return;
    }
label_28:
    this.btnBrowse = (Button) target;
    this.btnBrowse.Click += new RoutedEventHandler(this.btnBrowse_Click);
    return;
label_29:
    this.groupBox1 = (GroupBox) target;
    return;
label_30:
    this.groupBox2 = (GroupBox) target;
    return;
label_31:
    this.txtNewFlashCode2 = (TextBox) target;
    this.txtNewFlashCode2.TextChanged += new TextChangedEventHandler(this.txtNewFlashCode_TextChanged);
    return;
label_32:
    this.d = true;
  }
}
