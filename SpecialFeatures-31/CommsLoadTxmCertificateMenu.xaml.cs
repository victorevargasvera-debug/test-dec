// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.Comms.LoadTxmCertificateMenu
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using AcpCommonLib;
using CommonResources;
using SpecialFeatures.AcpReportManagerLib;
using SpecialFeatures.FileOperations;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Markup;
using System.Windows.Shapes;

#nullable disable
namespace SpecialFeatures.Comms;

public partial class LoadTxmCertificateMenu : Window, IDisposable, IComponentConnector
{
  public bool bCommSuccess = true;
  private string a;
  private string b;
  private OpenFileDialog c;
  internal Grid Header;
  internal Rectangle Divider_Copy;
  internal System.Windows.Controls.Label ViewboxTitle;
  internal StackPanel stackMoreInfo;
  internal System.Windows.Controls.Label BrowseCertificateLabel;
  internal System.Windows.Controls.TextBox TxtBoxCertFile;
  internal TextBlock ButtonBlock;
  internal System.Windows.Controls.Button LoadButton;
  internal System.Windows.Controls.Button CloseBtn;
  private bool d;

  public LoadTxmCertificateMenu(string initDir)
  {
    this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
    this.a = (string) null;
    this.b = initDir;
    this.InitializeComponent();
  }

  private void OnButtonClick_Close(object A_0, RoutedEventArgs A_1)
  {
    short num1 = -16959;
    int num2 = (int) num1;
    num1 = (short) -16959;
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
        this.Close();
        break;
      default:
        goto case 1;
    }
  }

  protected virtual void Dispose(bool disposing)
  {
    int num1 = 2;
    short num2;
    while (true)
    {
      switch (num1)
      {
        case 0:
          num2 = (short) 0;
          num2 = (short) -28466;
          int num3 = (int) num2;
          num2 = (short) -28466;
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
              this.c.Dispose();
              num2 = (short) 1;
              num1 = (int) (IntPtr) num2;
              continue;
          }
          break;
        case 1:
          goto label_10;
        case 2:
          switch (0)
          {
            case 0:
              goto label_3;
            default:
              continue;
          }
        default:
label_3:
          if (!disposing)
            goto label_10;
          break;
      }
      num2 = (short) 0;
      num1 = (int) (IntPtr) num2;
    }
label_10:
    num2 = (short) 1;
    if (num2 == (short) 0)
      ;
  }

  public void Dispose()
  {
    short num1 = 20388;
    int num2 = (int) num1;
    num1 = (short) 20388;
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
        this.Dispose(true);
        GC.SuppressFinalize((object) this);
        break;
      default:
        goto case 1;
    }
  }

  public void OnButtonClick_BrowseCert(object sender, EventArgs args)
  {
    int num1;
    short num2;
    switch (0)
    {
      case 0:
label_2:
        this.c = new OpenFileDialog();
        this.c.InitialDirectory = this.b;
        this.c.Filter = AppResources.PKCS12_files_Filter;
        this.c.Multiselect = false;
        this.c.RestoreDirectory = true;
        num2 = (short) 4;
        num1 = (int) (IntPtr) num2;
        goto default;
      default:
        while (true)
        {
          switch (num1)
          {
            case 0:
              if (this.a != null)
              {
                num2 = (short) 3;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_10;
            case 1:
              goto label_9;
            case 2:
              num2 = (short) 1;
              if (num2 == (short) 0)
                break;
              break;
            case 3:
              this.LoadButton.IsEnabled = true;
              this.TxtBoxCertFile.Text = this.a;
              this.c.InitialDirectory = System.IO.Path.GetDirectoryName(this.a);
              num2 = (short) -3113;
              int num3 = (int) num2;
              num2 = (short) -3113;
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
                  num1 = (int) (IntPtr) num2;
                  continue;
              }
              break;
            case 4:
              if (this.c.ShowDialog() == System.Windows.Forms.DialogResult.OK)
              {
                num2 = (short) 2;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_14;
            default:
              goto label_2;
          }
          num2 = (short) 0;
          this.a = this.c.FileName;
          num2 = (short) 0;
          num1 = (int) (IntPtr) num2;
        }
label_9:
        break;
label_14:
        break;
label_10:
        break;
    }
  }

  public void OnButtonClick_LoadCert(object sender, EventArgs args)
  {
    int A_1 = 16 /*0x10*/;
    int num1 = 0;
    switch (num1)
    {
      default:
        string text;
        string str;
        short num2;
        switch (0)
        {
          case 0:
label_3:
            text = this.TxtBoxCertFile.Text;
            str = System.IO.Path.GetExtension(text);
            num2 = (short) 10;
            num1 = (int) (IntPtr) num2;
            goto default;
          default:
            while (true)
            {
              switch (num1)
              {
                case 0:
                  if (!(str == RptMgrErrorHandler.b("붒\uE594Ꚗꮘ", A_1)))
                  {
                    num2 = (short) 1;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 8;
                case 1:
                  num2 = (short) 4;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 2:
                  num2 = (short) 0;
                  num2 = (short) 0;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 3:
                  goto label_20;
                case 4:
                  if (str == RptMgrErrorHandler.b("붒\uE594\uF196\uE198", A_1))
                  {
                    num2 = (short) 8;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_16;
                case 5:
                  SpecialFeatures.Comms.Comms comms = new SpecialFeatures.Comms.Comms();
                  COMMS_OP commsOp = COMMS_OP.USB_READ_WRITE;
                  string a = this.a;
                  int WriteType = (int) commsOp;
                  if (comms.LoadTxmCertificate(a, (COMMS_OP) WriteType))
                  {
                    num2 = (short) 9;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_24;
                case 6:
                  num2 = (short) 1;
                  if (num2 == (short) 0)
                    ;
                  num2 = (short) 7;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 7:
                  if (!(text != ""))
                    goto label_16;
                  break;
                case 8:
                  this.Close();
                  num2 = (short) 5;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 9:
                  goto label_8;
                case 10:
                  if (File.Exists(text))
                  {
                    num2 = (short) -22752;
                    int num3 = (int) num2;
                    num2 = (short) -22752;
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
                        num2 = (short) 6;
                        num1 = (int) (IntPtr) num2;
                        continue;
                    }
                  }
                  else
                    goto label_16;
                  break;
                default:
                  goto label_3;
              }
              num2 = (short) 2;
              num1 = (int) (IntPtr) num2;
              continue;
label_16:
              MessageWindow messageWindow = new MessageWindow(AppResources.Select_Valid_PKCS12_Certificate);
              messageWindow.Owner = Window.GetWindow((DependencyObject) this);
              messageWindow.ShowDialog();
              num2 = (short) 3;
              num1 = (int) (IntPtr) num2;
            }
label_20:
            return;
label_8:
            AppInfoManager.StatusMsgReport.Clear();
            AppInfoManager.StatusMsgReport.RegisterMessage((StatusMsgType) 2, AppResources.Load_Txm_Cert_Success);
            return;
label_24:
            return;
        }
    }
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "5.0.10.0")]
  public void InitializeComponent()
  {
    int A_1 = 13;
    short num1 = 1;
    if (num1 == (short) 0)
      ;
    if (this.d)
    {
      num1 = (short) 31938;
      int num2 = (int) num1;
      num1 = (short) 31938;
      int num3 = (int) num1;
      switch (num2 == num3 ? 1 : 0)
      {
        case 0:
          break;
        case 2:
          break;
        default:
          num1 = (short) 0;
          num1 = (short) 0;
          if (num1 == (short) 0)
            break;
          break;
      }
    }
    else
    {
      this.d = true;
      System.Windows.Application.LoadComponent((object) this, new Uri(RptMgrErrorHandler.b("뾏솑\uE493\uF395ﮗ\uF399ﶛ\uF29D\uE69F잡얣튥\uDDA7\uD8A9즫\uDDAD讯톱\uDBB3\uDBB5좷햹튻\uDBBD꺿뛁\uEBC3ꗅ\uA7C7\uA7C9ꇋ뷍ￏ뻑믓럕볗껙ꓛ돝菟蟡難鋥臧賩藫跭釯蛱釳鯵鷷铹觻탽磿持椃樅", A_1), UriKind.Relative));
    }
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "5.0.10.0")]
  [EditorBrowsable(EditorBrowsableState.Never)]
  void IComponentConnector.Connect(int connectionId, object target)
  {
    int num1 = 2;
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
          goto label_19;
        case 2:
          num2 = (short) 1;
          if (num2 == (short) 0)
            ;
          num2 = (short) 1019;
          int num3 = (int) num2;
          num2 = (short) 1019;
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
      switch (connectionId)
      {
        case 1:
          goto label_10;
        case 2:
          goto label_16;
        case 3:
          goto label_18;
        case 4:
          goto label_15;
        case 5:
          goto label_9;
        case 6:
          goto label_17;
        case 7:
          goto label_8;
        case 8:
          goto label_13;
        case 9:
          goto label_11;
        case 10:
          goto label_14;
        default:
          num2 = (short) 0;
          num1 = (int) (IntPtr) num2;
          continue;
      }
    }
label_8:
    ((System.Windows.Controls.Primitives.ButtonBase) target).Click += new RoutedEventHandler(this.OnButtonClick_BrowseCert);
    return;
label_9:
    this.BrowseCertificateLabel = (System.Windows.Controls.Label) target;
    return;
label_10:
    this.Header = (Grid) target;
    return;
label_11:
    this.LoadButton = (System.Windows.Controls.Button) target;
    this.LoadButton.Click += new RoutedEventHandler(this.OnButtonClick_LoadCert);
    return;
label_13:
    this.ButtonBlock = (TextBlock) target;
    return;
label_14:
    this.CloseBtn = (System.Windows.Controls.Button) target;
    this.CloseBtn.Click += new RoutedEventHandler(this.OnButtonClick_Close);
    return;
label_15:
    num2 = (short) 0;
    this.stackMoreInfo = (StackPanel) target;
    return;
label_16:
    this.Divider_Copy = (Rectangle) target;
    return;
label_17:
    this.TxtBoxCertFile = (System.Windows.Controls.TextBox) target;
    return;
label_18:
    this.ViewboxTitle = (System.Windows.Controls.Label) target;
    return;
label_19:
    this.d = true;
  }
}
