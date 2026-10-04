// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.POP25BatchProgrammer.POP25BatchProgrammerScheduler
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using AcpASKLib;
using ACPBrowser;
using AcpCommonLib;
using AcpSecurityLib;
using AcpUI.Common;
using AcpUtility;
using CommonResources;
using DevComponents.WpfEditors;
using SpecialFeatures.AcpReportManagerLib;
using SpecialFeatures.Clone_Configuration.Common;
using SSLAdminTool;
using SSLMangrComp;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Threading;
using System.Xml.Serialization;

#nullable disable
namespace SpecialFeatures.POP25BatchProgrammer;

public partial class POP25BatchProgrammerScheduler : 
  Window,
  INotifyPropertyChanged,
  IComponentConnector
{
  private TimeSpan a;
  private DispatcherTimer b;
  private string c;
  private SpecialFeaturesSettings d;
  private Collection<SystemKeyData> e;
  private string f;
  private string g;
  private byte[] h;
  private IDataStoreDecryptHandler i;
  private List<PNServer> j;
  private XmlSerializer k;
  private RadioList l;
  internal System.Windows.Controls.Label lbDateTime;
  internal DateTimeInput dtSchedulerDateTime;
  internal System.Windows.Controls.Label lbRadioListFilePath;
  internal System.Windows.Controls.TextBox txtboxRadioListFilePath;
  internal System.Windows.Controls.Button btnRadioListFilePathBrowse;
  internal System.Windows.Controls.GroupBox groupBoxARS;
  internal System.Windows.Controls.CheckBox chkboxStaticIpAddress;
  internal System.Windows.Controls.Label lbArsServerIpAddress;
  internal System.Windows.Controls.ComboBox autoRegServer;
  internal System.Windows.Controls.Label lbArsConnectionType;
  internal System.Windows.Controls.TextBox txtboxConnectionType;
  internal System.Windows.Controls.Label lbAvailableRadios;
  internal System.Windows.Controls.Label lbSelectedRadios;
  internal System.Windows.Controls.DataGrid dgAvailableRadio;
  internal System.Windows.Controls.DataGrid dgSelectedRadios;
  internal System.Windows.Controls.Button btnAdd;
  internal System.Windows.Controls.Button btnAddAll;
  internal System.Windows.Controls.Button btnRemove;
  internal System.Windows.Controls.Button btnRemoveAll;
  internal System.Windows.Controls.Label lbNumRetries;
  internal System.Windows.Controls.ComboBox txtbxNumRetries;
  internal System.Windows.Controls.CheckBox chkboxWriteProtect;
  internal System.Windows.Controls.Button btnStart;
  internal System.Windows.Controls.Button btnCancel;
  internal System.Windows.Controls.Button btnHelp;
  private bool o;

  public List<PNServer> ARS_DataSource
  {
    get
    {
      short num1 = -11467;
      int num2 = (int) num1;
      num1 = (short) -11467;
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
          return this.j;
        default:
          goto case 1;
      }
    }
  }

  public ObservableCollection<POP25RadioInfo> DataSource
  {
    get
    {
      short num1 = -18760;
      int num2 = (int) num1;
      num1 = (short) -18760;
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
          return (ObservableCollection<POP25RadioInfo>) this.l;
        default:
          goto case 1;
      }
    }
  }

  public string ArsIpAddress
  {
    get
    {
      short num1 = -3801;
      int num2 = (int) num1;
      num1 = (short) -3801;
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
          return this.g;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = -667;
      int num2 = (int) num1;
      num1 = (short) -667;
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
          this.g = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  public POP25BatchProgrammerScheduler()
  {
    int A_1 = 9;
    this.c = "";
    // ISSUE: object of a compiler-generated type is created
    this.d = new SpecialFeaturesSettings();
    this.f = string.Empty;
    this.g = string.Empty;
    this.i = (IDataStoreDecryptHandler) new DataStoreDecryptHandler(112 /*0x70*/, 2048 /*0x0800*/);
    this.j = new List<PNServer>();
    this.k = new XmlSerializer(typeof (RadioList));
    this.l = new RadioList();
    // ISSUE: explicit constructor call
    base.\u002Ector();
    this.InitializeComponent();
    Utility.SetDirection((FrameworkElement) this);
    this.chkboxStaticIpAddress.IsChecked = new bool?(false);
    this.chkboxWriteProtect.IsChecked = new bool?(false);
    this.autoRegServer.IsEnabled = false;
    this.txtbxNumRetries.Text = RptMgrErrorHandler.b("뺋", A_1);
    this.txtboxRadioListFilePath.Text = this.e();
    this.b(this.c);
    this.a = new TimeSpan(0, 0, 0, 0, 0);
    this.CancelBatchSchedule = false;
    this.e = SecurityManager.GetSysKeysFromLoadedAndAttachedASKs();
    this.h = new byte[0];
    try
    {
      if (this.i.XStoreAvailable)
      {
        List<PNServer> pnServerList = new List<PNServer>();
        foreach (PNServer pnServer in this.i.XStoreRead())
        {
          if (pnServer.RecType == 2)
            this.j.Add(pnServer);
        }
      }
      else
      {
        int num = (int) System.Windows.MessageBox.Show(AppResources.The_ARS_XML_file_is_not_available, AppResources.ARS_XML_File_Not_Found, MessageBoxButton.OK, MessageBoxImage.Exclamation);
      }
    }
    catch (Exception ex)
    {
      int num = (int) System.Windows.MessageBox.Show(AppResources.There_was_problem_loading_ARS_XML_file, AppResources.ARS_XML_File_Not_Found, MessageBoxButton.OK, MessageBoxImage.Exclamation);
    }
    this.DataContext = (object) this;
    this.autoRegServer.ItemsSource = (IEnumerable) this.ARS_DataSource;
    this.c();
    if (!Thread.CurrentThread.CurrentCulture.Name.ToLower().StartsWith(RptMgrErrorHandler.b("\uED8Bﲍ", A_1)))
      return;
    this.txtboxRadioListFilePath.FlowDirection = System.Windows.FlowDirection.LeftToRight;
    this.txtboxRadioListFilePath.TextAlignment = TextAlignment.Right;
  }

  private void SchedulerWindow_Loaded(object A_0, RoutedEventArgs A_1)
  {
    int num1 = 0;
    switch (num1)
    {
      default:
        string empty;
        bool? isChecked;
        bool flag;
        short num2;
        switch (0)
        {
          case 0:
label_3:
            this.dtSchedulerDateTime.Value = new DateTime?(DateTime.Now);
            empty = string.Empty;
            isChecked = this.chkboxStaticIpAddress.IsChecked;
            flag = true;
            num2 = (short) 4;
            num1 = (int) (IntPtr) num2;
            goto default;
          default:
            while (true)
            {
              IEnumerator enumerator1;
              IEnumerator<SystemKeyData> enumerator2;
              switch (num1)
              {
                case 0:
                  this.autoRegServer.IsEnabled = true;
                  num2 = (short) 1;
                  if (num2 == (short) 0)
                    ;
                  num2 = (short) 9;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 1:
                  goto label_55;
                case 2:
                  if (this.e != null)
                  {
                    num2 = (short) 8;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  break;
                case 3:
                  int num3 = (int) System.Windows.MessageBox.Show((Window) this, empty, AppResources.Certificate_Warning);
                  num2 = (short) 1;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 4:
                  if (isChecked.GetValueOrDefault() == flag & isChecked.HasValue)
                  {
                    num2 = (short) 0;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 9;
                case 5:
                  try
                  {
                    num2 = (short) 1;
                    int num4 = (int) (IntPtr) num2;
                    while (true)
                    {
                      switch (num4)
                      {
                        case 0:
                          if (enumerator2.MoveNext())
                          {
                            num2 = (short) 3;
                            num4 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 6;
                          num4 = (int) (IntPtr) num2;
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
                          this.chkboxWriteProtect.IsEnabled = true;
                          num2 = (short) 5;
                          num4 = (int) (IntPtr) num2;
                          continue;
                        case 3:
                          if (enumerator2.Current.WriteProtectEnabled)
                          {
                            num2 = (short) 2;
                            num4 = (int) (IntPtr) num2;
                            continue;
                          }
                          break;
                        case 4:
                        case 5:
                          goto label_6;
                        case 6:
                          num2 = (short) 4;
                          num4 = (int) (IntPtr) num2;
                          continue;
                      }
                      num2 = (short) 0;
                      num4 = (int) (IntPtr) num2;
                    }
                  }
                  finally
                  {
                    short num5 = 0;
                    int num6 = (int) (IntPtr) num5;
                    while (true)
                    {
                      switch (num6)
                      {
                        case 0:
                          num5 = (short) -20315;
                          int num7 = (int) num5;
                          num5 = (short) -20315;
                          int num8 = (int) num5;
                          switch (num7 == num8 ? 1 : 0)
                          {
                            case 0:
                            case 2:
                              goto label_53;
                            default:
                              num5 = (short) 0;
                              if (num5 == (short) 0)
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
                        case 1:
                          enumerator2.Dispose();
                          num5 = (short) 2;
                          num6 = (int) (IntPtr) num5;
                          continue;
                        case 2:
                          goto label_53;
                      }
                      if (enumerator2 != null)
                      {
                        num5 = (short) 1;
                        num6 = (int) (IntPtr) num5;
                      }
                      else
                        break;
                    }
label_53:;
                  }
                case 6:
                  try
                  {
                    num2 = (short) 1;
                    num1 = (int) (IntPtr) num2;
                    while (true)
                    {
                      PNServer current;
                      switch (num1)
                      {
                        case 0:
                          this.a(current, ref empty);
                          num2 = (short) 6;
                          num1 = (int) (IntPtr) num2;
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
                          num2 = (short) 4;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        case 3:
                          if (!enumerator1.MoveNext())
                          {
                            num2 = (short) 2;
                            num1 = (int) (IntPtr) num2;
                            continue;
                          }
                          current = (PNServer) enumerator1.Current;
                          num2 = (short) 5;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        case 4:
                          goto label_10;
                        case 5:
                          if (current.SecureConn)
                          {
                            num2 = (short) 0;
                            num1 = (int) (IntPtr) num2;
                            continue;
                          }
                          break;
                      }
                      num2 = (short) 3;
                      num1 = (int) (IntPtr) num2;
                    }
                  }
                  finally
                  {
                    IDisposable disposable;
                    short num9;
                    switch (0)
                    {
                      case 0:
label_28:
                        disposable = enumerator1 as IDisposable;
                        num9 = (short) 0;
                        num1 = (int) (IntPtr) num9;
                        goto default;
                      default:
                        while (true)
                        {
                          switch (num1)
                          {
                            case 0:
                              if (disposable != null)
                              {
                                num9 = (short) 1;
                                num1 = (int) (IntPtr) num9;
                                continue;
                              }
                              goto label_32;
                            case 1:
                              disposable.Dispose();
                              num9 = (short) 2;
                              num1 = (int) (IntPtr) num9;
                              continue;
                            case 2:
                              goto label_32;
                            default:
                              goto label_28;
                          }
                        }
label_32:;
                    }
                  }
label_10:
                  num1 = 7;
                  continue;
                case 7:
                  if (empty != string.Empty)
                  {
                    num2 = (short) 3;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_55;
                case 8:
                  num2 = (short) 0;
                  enumerator2 = this.e.GetEnumerator();
                  num2 = (short) 5;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 9:
                  num2 = (short) 2;
                  num1 = (int) (IntPtr) num2;
                  continue;
                default:
                  goto label_3;
              }
label_6:
              enumerator1 = this.autoRegServer.ItemsSource.GetEnumerator();
              num2 = (short) 6;
              num1 = (int) (IntPtr) num2;
            }
label_55:
            this.a();
            return;
        }
    }
  }

  internal string NumRetriePerFailedRadios
  {
    get
    {
      short num1 = 1;
      if (num1 == (short) 0)
        ;
      num1 = (short) 27321;
      int num2 = (int) num1;
      num1 = (short) 27321;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          num1 = (short) 0;
          return this.txtbxNumRetries.Text;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = -30075;
      int num2 = (int) num1;
      num1 = (short) -30075;
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
          this.txtbxNumRetries.Text = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  internal bool WriteProtectRadios
  {
    get
    {
      short num1 = -23170;
      int num2 = (int) num1;
      num1 = (short) -23170;
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
          return this.chkboxWriteProtect.IsChecked.Value;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = -22080;
      int num2 = (int) num1;
      num1 = (short) -22080;
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
          this.chkboxWriteProtect.IsChecked = new bool?(value);
          break;
        default:
          goto case 1;
      }
    }
  }

  internal bool CancelBatchSchedule
  {
    set
    {
      short num1 = 10987;
      int num2 = (int) num1;
      num1 = (short) 10987;
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
          this.m = value;
          break;
        default:
          goto case 1;
      }
    }
    get
    {
      short num1 = 3883;
      int num2 = (int) num1;
      num1 = (short) 3883;
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
          return this.m;
        default:
          goto case 1;
      }
    }
  }

  public event PropertyChangedEventHandler PropertyChanged
  {
    add
    {
      int num1;
      PropertyChangedEventHandler changedEventHandler;
      short num2;
      switch (0)
      {
        case 0:
label_2:
          changedEventHandler = this.n;
          num2 = (short) -26124;
          int num3 = (int) num2;
          num2 = (short) -26124;
          int num4 = (int) num2;
          switch (num3 == num4 ? 1 : 0)
          {
            case 0:
              return;
            case 2:
              return;
            default:
              num2 = (short) 0;
              if (num2 == (short) 0)
                ;
              num2 = (short) 0;
              num2 = (short) 0;
              num1 = (int) (IntPtr) num2;
              goto label_1;
          }
        default:
          while (true)
          {
            PropertyChangedEventHandler comparand;
            switch (num1)
            {
              case 0:
                comparand = changedEventHandler;
                changedEventHandler = Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this.n, comparand + value, comparand);
                num2 = (short) 1;
                if (num2 == (short) 0)
                  ;
                num2 = (short) 1;
                num1 = (int) (IntPtr) num2;
                continue;
              case 1:
                if (changedEventHandler == comparand)
                {
                  num2 = (short) 2;
                  num1 = (int) (IntPtr) num2;
                  continue;
                }
                goto case 0;
              case 2:
                goto label_4;
              default:
                goto label_2;
            }
label_1:;
          }
label_4:
          break;
      }
    }
    remove
    {
      short num1 = 1;
      if (num1 == (short) 0)
        ;
      int num2;
      PropertyChangedEventHandler changedEventHandler;
      switch (0)
      {
        case 0:
label_3:
          changedEventHandler = this.n;
          num1 = (short) 0;
          num1 = (short) 11732;
          int num3 = (int) num1;
          num1 = (short) 11732;
          int num4 = (int) num1;
          switch (num3 == num4 ? 1 : 0)
          {
            case 0:
              return;
            case 2:
              return;
            default:
              num1 = (short) 0;
              if (num1 == (short) 0)
                ;
              num1 = (short) 0;
              num2 = (int) (IntPtr) num1;
              goto label_2;
          }
        default:
          while (true)
          {
            PropertyChangedEventHandler comparand;
            switch (num2)
            {
              case 0:
                comparand = changedEventHandler;
                changedEventHandler = Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this.n, comparand - value, comparand);
                num1 = (short) 1;
                num2 = (int) (IntPtr) num1;
                continue;
              case 1:
                if (changedEventHandler == comparand)
                {
                  num1 = (short) 2;
                  num2 = (int) (IntPtr) num1;
                  continue;
                }
                goto case 0;
              case 2:
                goto label_11;
              default:
                goto label_3;
            }
label_2:;
          }
label_11:
          break;
      }
    }
  }

  public void FireDataSourcePropertyChanged(string name)
  {
    int num1 = 2;
    short num2;
    while (true)
    {
      switch (num1)
      {
        case 0:
          // ISSUE: reference to a compiler-generated field
          this.n((object) this, new PropertyChangedEventArgs(name));
          break;
        case 1:
          num2 = (short) -13287;
          int num3 = (int) num2;
          num2 = (short) -13287;
          int num4 = (int) num2;
          switch (num3 == num4 ? 1 : 0)
          {
            case 0:
            case 2:
              break;
            default:
              goto label_9;
          }
          break;
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
          num2 = (short) 1;
          if (num2 == (short) 0)
            ;
          // ISSUE: reference to a compiler-generated field
          if (this.n != null)
          {
            num2 = (short) 0;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto label_11;
      }
      num2 = (short) 1;
      num1 = (int) (IntPtr) num2;
    }
label_11:
    return;
label_9:
    num2 = (short) 0;
    if (num2 == (short) 0)
      ;
    num2 = (short) 0;
  }

  private string e()
  {
    int A_1 = 13;
    int num1 = 5;
    while (true)
    {
      short num2;
      switch (num1)
      {
        case 0:
          this.c = AppResources.Please_Select_A_Radio_List_Location;
          num2 = (short) 2;
          num1 = (int) (IntPtr) num2;
          continue;
        case 1:
        case 2:
          goto label_14;
        case 3:
          if (!System.IO.File.Exists(this.c))
          {
            num2 = (short) 0;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto label_14;
        case 4:
          num2 = (short) -2342;
          int num3 = (int) num2;
          num2 = (short) -2342;
          int num4 = (int) num2;
          switch (num3 == num4 ? 1 : 0)
          {
            case 0:
            case 2:
              break;
            default:
              num2 = (short) 1;
              if (num2 == (short) 0)
                ;
              num2 = (short) 0;
              if (num2 == (short) 0)
                ;
              num2 = (short) 0;
              this.c = this.d.OTAP_BATCH_RADIO_LIST_LOCATION;
              num2 = (short) 1;
              num1 = (int) (IntPtr) num2;
              continue;
          }
          break;
        case 5:
          switch (0)
          {
            case 0:
              goto label_3;
            default:
              continue;
          }
        default:
label_3:
          if (System.IO.File.Exists(this.d.OTAP_BATCH_RADIO_LIST_LOCATION))
          {
            num2 = (short) 4;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          this.c = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), RptMgrErrorHandler.b("\uDD8F\uFD91\uE093秊\uEA97\uF599\uF09Bﾝﲟ\uE3A1풣\uDEA5\uEEA7쮩솫잭\uDCAF쮱\uF7B3\uE6B5\uEBB7\uE6B9ﾻ톽궿꿁ꯃ\uA8C5铇裉귋뫍돏뫑裓蓕맗뻙뗛뇝뿟껡跣闥鳧쓩铫菭鳯", A_1));
          break;
      }
      num2 = (short) 3;
      num1 = (int) (IntPtr) num2;
    }
label_14:
    return this.c;
  }

  private void btnRadioListFilePathBrowse_Click(object A_0, RoutedEventArgs A_1)
  {
    int A_1_1 = 1;
    OpenFileDialog openFileDialog = new OpenFileDialog();
    openFileDialog.InitialDirectory = this.c;
    openFileDialog.DefaultExt = RptMgrErrorHandler.b("ﲃ\uEB85\uE487", A_1_1);
    openFileDialog.Filter = AppResources.XML_Document_Filter;
    if (openFileDialog.ShowDialog() != System.Windows.Forms.DialogResult.OK)
      return;
label_1:
    if (false)
      ;
    switch (true ? 1 : 0)
    {
      case 0:
      case 2:
        goto label_1;
      default:
        short num = 0;
        num = (short) 0;
        if (num == (short) 0)
          ;
        this.txtboxRadioListFilePath.Text = openFileDialog.FileName;
        this.b(this.txtboxRadioListFilePath.Text);
        break;
    }
  }

  private void b(string A_0)
  {
    int A_1 = 12;
    short num1;
    try
    {
      if (false)
        ;
      FileStream fileStream = new FileStream(A_0, FileMode.Open, FileAccess.Read, FileShare.Read);
      this.l = (RadioList) this.k.Deserialize((Stream) fileStream);
      this.FireDataSourcePropertyChanged(RptMgrErrorHandler.b("쮎\uF090\uE792\uF494쒖\uF698\uEE9A\uEF9Cﲞ쒠", A_1));
      fileStream.Close();
    }
    catch
    {
      if (!System.IO.File.Exists(this.c))
      {
        num1 = (short) 12023;
        int num2 = (int) num1;
        num1 = (short) 12023;
        int num3 = (int) num1;
        switch (num2 == num3 ? 1 : 0)
        {
          case 0:
          case 2:
            break;
          default:
            num1 = (short) 0;
            if (num1 == (short) 0)
              goto label_7;
            goto label_7;
        }
      }
      int num4 = (int) System.Windows.MessageBox.Show(AppResources.Please_Select_A_Valid_XML_File, AppResources.Invalid_XML_File, MessageBoxButton.OK, MessageBoxImage.Exclamation);
    }
label_7:
    num1 = (short) 0;
  }

  private void d()
  {
    int num1;
    short num2;
    bool? isChecked;
    switch (0)
    {
      case 0:
label_2:
        num2 = (short) 1;
        if (num2 == (short) 0)
          ;
        this.d.OTAP_BATCH_RADIO_LIST_LOCATION = this.txtboxRadioListFilePath.Text;
        this.d.OTAP_BATCH_ENABLE_ARS_SERVER_IP_ADDRESS = this.chkboxStaticIpAddress.IsChecked.Value;
        isChecked = this.chkboxStaticIpAddress.IsChecked;
        break;
      default:
        while (true)
        {
          switch (num1)
          {
            case 0:
              if (this.j.Count > 0)
              {
                num2 = (short) 3;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_14;
            case 1:
              num2 = (short) 0;
              num1 = (int) (IntPtr) num2;
              continue;
            case 2:
              goto label_14;
            case 3:
              this.d.OTAP_ARS_IP_ADDRESS = ((PNServer) this.autoRegServer.SelectedItem).PNSName;
              num2 = (short) 2;
              num1 = (int) (IntPtr) num2;
              continue;
            case 4:
              num2 = (short) 29772;
              int num3 = (int) num2;
              num2 = (short) 29772;
              int num4 = (int) num2;
              switch (num3 == num4 ? 1 : 0)
              {
                case 0:
                case 2:
                  goto label_4;
                case 1:
                  num2 = (short) 0;
                  if (num2 == (short) 0)
                    ;
                  if (isChecked.Value)
                  {
                    num2 = (short) 1;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_14;
                default:
                  num2 = (short) 0;
                  goto case 1;
              }
            default:
              goto label_2;
          }
label_1:;
        }
label_14:
        this.d.OTAP_BATCH_NUM_RETRIES_FOR_FAILED_RADIOS = this.txtbxNumRetries.Text;
        this.d.Save();
        return;
    }
label_4:
    num2 = (short) 4;
    num1 = (int) (IntPtr) num2;
    goto label_1;
  }

  private void c()
  {
    try
    {
      this.chkboxStaticIpAddress.IsChecked = new bool?(this.d.OTAP_BATCH_ENABLE_ARS_SERVER_IP_ADDRESS);
      int num1 = -1;
      IEnumerator enumerator = ((IEnumerable) this.autoRegServer.Items).GetEnumerator();
      int num2;
      try
      {
        num2 = 5;
        while (true)
        {
          switch (num2)
          {
            case 0:
              switch (true ? 1 : 0)
              {
                case 0:
                case 2:
                  break;
                default:
                  if (true)
                    ;
                  num2 = 1;
                  continue;
              }
              break;
            case 1:
              goto label_18;
            case 3:
              num2 = enumerator.MoveNext() ? 4 : 0;
              continue;
            case 4:
              PNServer current = (PNServer) enumerator.Current;
              ++num1;
              if (!current.PNSName.Equals(this.d.OTAP_ARS_IP_ADDRESS))
              {
                num2 = 2;
                continue;
              }
              goto case 0;
            case 5:
              switch (0)
              {
                case 0:
                  break;
                default:
                  continue;
              }
              break;
          }
          num2 = 3;
        }
      }
      finally
      {
        IDisposable disposable;
        switch (0)
        {
          case 0:
label_13:
            disposable = enumerator as IDisposable;
            num2 = 2;
            goto default;
          default:
            while (true)
            {
              switch (num2)
              {
                case 0:
                  disposable.Dispose();
                  num2 = 1;
                  continue;
                case 1:
                  goto label_17;
                case 2:
                  if (disposable != null)
                  {
                    num2 = 0;
                    continue;
                  }
                  goto label_17;
                default:
                  goto label_13;
              }
            }
label_17:;
        }
      }
label_18:
      this.autoRegServer.SelectedIndex = num1;
      this.txtbxNumRetries.Text = this.d.OTAP_BATCH_NUM_RETRIES_FOR_FAILED_RADIOS;
    }
    catch (Exception ex)
    {
    }
    if (false)
      ;
  }

  private void btnStart_Click(object A_0, RoutedEventArgs A_1)
  {
    int A_1_1 = 17;
    short num1 = 1;
    if (num1 == (short) 0)
      ;
    num1 = (short) 0;
    switch (num1)
    {
      default:
        num1 = (short) 28;
        int num2 = (int) (IntPtr) num1;
        while (true)
        {
          bool flag;
          IEnumerator<SystemKeyData> enumerator;
          DateTime? nullable;
          bool? isChecked;
          string str;
          string folderPath;
          string empty;
          switch (num2)
          {
            case 0:
              try
              {
                num1 = (short) 4;
                int num3 = (int) (IntPtr) num1;
                while (true)
                {
                  switch (num3)
                  {
                    case 0:
                      num1 = (short) 8;
                      num3 = (int) (IntPtr) num1;
                      continue;
                    case 1:
                    case 7:
                      goto label_47;
                    case 2:
                      this.WriteProtectRadios = true;
                      num1 = (short) 1;
                      num3 = (int) (IntPtr) num1;
                      continue;
                    case 3:
                      if (!enumerator.MoveNext())
                      {
                        num1 = (short) 5;
                        num3 = (int) (IntPtr) num1;
                        continue;
                      }
                      num1 = (short) 6;
                      num3 = (int) (IntPtr) num1;
                      continue;
                    case 4:
                      switch (0)
                      {
                        case 0:
                          break;
                        default:
                          continue;
                      }
                      break;
                    case 5:
label_31:
                      num1 = (short) 7;
                      num3 = (int) (IntPtr) num1;
                      continue;
                    case 6:
                      if (enumerator.Current.WriteProtectEnabled)
                      {
                        num1 = (short) 0;
                        num3 = (int) (IntPtr) num1;
                        continue;
                      }
                      break;
                    case 8:
                      num1 = (short) 31379;
                      int num4 = (int) num1;
                      num1 = (short) 31379;
                      int num5 = (int) num1;
                      switch (num4 == num5 ? 1 : 0)
                      {
                        case 0:
                        case 2:
                          break;
                        default:
                          num1 = (short) 0;
                          if (num1 == (short) 0)
                            ;
                          if (System.Windows.MessageBox.Show(AppResources.Warning_One_Or_More_WPEd_Advanced_Key_Loaded, AppResources.Radio_Write_Protect_Warning, MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
                          {
                            num1 = (short) 2;
                            num3 = (int) (IntPtr) num1;
                            continue;
                          }
                          goto label_31;
                      }
                      break;
                  }
                  num1 = (short) 3;
                  num3 = (int) (IntPtr) num1;
                }
              }
              finally
              {
                int num6 = 2;
                while (true)
                {
                  short num7;
                  switch (num6)
                  {
                    case 0:
                      enumerator.Dispose();
                      num7 = (short) 1;
                      num6 = (int) (IntPtr) num7;
                      continue;
                    case 1:
                      goto label_38;
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
                  if (enumerator != null)
                  {
                    num7 = (short) 0;
                    num6 = (int) (IntPtr) num7;
                  }
                  else
                    break;
                }
label_38:;
              }
            case 1:
              if (!WiFiPasswordUtil.OpenValidateDlg((Window) this))
              {
                num1 = (short) 13;
                num2 = (int) (IntPtr) num1;
                continue;
              }
              goto label_92;
            case 2:
              num1 = (short) 36;
              num2 = (int) (IntPtr) num1;
              continue;
            case 3:
              num1 = (short) 7;
              num2 = (int) (IntPtr) num1;
              continue;
            case 4:
              if (empty != string.Empty)
              {
                num1 = (short) 35;
                num2 = (int) (IntPtr) num1;
                continue;
              }
              goto label_91;
            case 5:
              if (!System.IO.File.Exists(folderPath + str))
              {
                flag = false;
                int num8 = (int) System.Windows.MessageBox.Show(AppResources.There_was_a_problem_with_reading_the_Diffy_Helman_Key_files_installed);
                num1 = (short) 8;
                num2 = (int) (IntPtr) num1;
                continue;
              }
              num1 = (short) 10;
              num2 = (int) (IntPtr) num1;
              continue;
            case 6:
              str = RptMgrErrorHandler.b("좓\uDB95\uF797\uEE99\uF39B\uEC9D쾟캡얣瘟\uE9A7\uF8A9ﾫ\uEAAD톯욱햳\uF7B5\uDCB7ힹ햻킽鲿迁ꯃ닅\uA7C7룉ꏋꋍ뇏\uF2D1郓돕뻗믙\uA9DB닝铟싡\uA7E3菥髧黩藫裭駯釱闳苵鷷\uA6F9飻雽烿持瘃朅攇␉簋欍紏", A_1_1);
              folderPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
              num1 = (short) 5;
              num2 = (int) (IntPtr) num1;
              continue;
            case 7:
              if (this.a((PNServer) this.autoRegServer.SelectedItem, ref empty))
              {
                num1 = (short) 34;
                num2 = (int) (IntPtr) num1;
                continue;
              }
              break;
            case 8:
              num1 = (short) 38;
              num2 = (int) (IntPtr) num1;
              continue;
            case 9:
              isChecked = this.chkboxStaticIpAddress.IsChecked;
              num1 = (short) 23;
              num2 = (int) (IntPtr) num1;
              continue;
            case 10:
              try
              {
                FileStream fileStream = new FileStream(folderPath + str, FileMode.Open, FileAccess.Read);
                this.h = new byte[fileStream.Length];
                fileStream.Read(this.h, 0, (int) fileStream.Length);
                fileStream.Close();
                goto case 8;
              }
              catch
              {
                flag = false;
                int num9 = (int) System.Windows.MessageBox.Show(AppResources.There_was_a_problem_with_reading_the_Diffy_Helman_Key_file_valid);
                goto case 8;
              }
            case 11:
              if (!this.WriteProtectRadios)
              {
                num1 = (short) 24;
                num2 = (int) (IntPtr) num1;
                continue;
              }
              goto label_47;
            case 12:
              goto label_87;
            case 13:
              goto label_50;
            case 14:
              if (!this.a(this.g))
              {
                num1 = (short) 37;
                num2 = (int) (IntPtr) num1;
                continue;
              }
              goto label_62;
            case 15:
              nullable = this.dtSchedulerDateTime.Value;
              num1 = (short) 27;
              num2 = (int) (IntPtr) num1;
              continue;
            case 16 /*0x10*/:
              if (System.Windows.MessageBox.Show(AppResources.Warning_The_ARS_IP_Address_is_invalid, AppResources.Invalid_ARS_Server_IP_Address_Warning, MessageBoxButton.OK, MessageBoxImage.Exclamation) == MessageBoxResult.OK)
              {
                num1 = (short) 22;
                num2 = (int) (IntPtr) num1;
                continue;
              }
              goto label_62;
            case 17:
              if (this.j.Count > 0)
              {
                num1 = (short) 9;
                num2 = (int) (IntPtr) num1;
                continue;
              }
              break;
            case 18:
              if (isChecked.Value)
              {
                num1 = (short) 25;
                num2 = (int) (IntPtr) num1;
                continue;
              }
              goto label_62;
            case 19:
              flag = true;
              nullable = this.dtSchedulerDateTime.Value;
              DateTime dateTime = nullable.Value;
              empty = string.Empty;
              isChecked = this.chkboxStaticIpAddress.IsChecked;
              num1 = (short) 29;
              num2 = (int) (IntPtr) num1;
              continue;
            case 20:
              if (((PNServer) this.autoRegServer.SelectedItem).SecureConn)
              {
                num1 = (short) 6;
                num2 = (int) (IntPtr) num1;
                continue;
              }
              break;
            case 21:
              if (System.Windows.MessageBox.Show(AppResources.Warning_There_is_no_ARS_selected, AppResources.Invalid_ARS_Warning, MessageBoxButton.OK, MessageBoxImage.Exclamation) == MessageBoxResult.OK)
              {
                num1 = (short) 30;
                num2 = (int) (IntPtr) num1;
                continue;
              }
              goto label_58;
            case 22:
              goto label_61;
            case 23:
              if (isChecked.Value)
              {
                num1 = (short) 33;
                num2 = (int) (IntPtr) num1;
                continue;
              }
              break;
            case 24:
              num1 = (short) 31 /*0x1F*/;
              num2 = (int) (IntPtr) num1;
              continue;
            case 25:
              num1 = (short) 14;
              num2 = (int) (IntPtr) num1;
              continue;
            case 26:
              num1 = (short) 21;
              num2 = (int) (IntPtr) num1;
              continue;
            case 27:
              if (nullable.HasValue)
              {
                num1 = (short) 19;
                num2 = (int) (IntPtr) num1;
                continue;
              }
              goto label_51;
            case 28:
              switch (0)
              {
                case 0:
                  goto label_5;
                default:
                  continue;
              }
            case 29:
              if (isChecked.Value)
              {
                num1 = (short) 2;
                num2 = (int) (IntPtr) num1;
                continue;
              }
              goto label_58;
            case 30:
              goto label_42;
            case 31 /*0x1F*/:
              if (this.e != null)
              {
                num1 = (short) 32 /*0x20*/;
                num2 = (int) (IntPtr) num1;
                continue;
              }
              goto label_47;
            case 32 /*0x20*/:
              enumerator = this.e.GetEnumerator();
              num1 = (short) 0;
              num2 = (int) (IntPtr) num1;
              continue;
            case 33:
              num1 = (short) 20;
              num2 = (int) (IntPtr) num1;
              continue;
            case 34:
              num1 = (short) 4;
              num2 = (int) (IntPtr) num1;
              continue;
            case 35:
              int num10 = (int) System.Windows.MessageBox.Show((Window) this, empty, AppResources.Certificate_Warning);
              num1 = (short) 12;
              num2 = (int) (IntPtr) num1;
              continue;
            case 36:
              if (this.autoRegServer.Items.Count <= 0)
              {
                num1 = (short) 26;
                num2 = (int) (IntPtr) num1;
                continue;
              }
              goto label_58;
            case 37:
              num1 = (short) 16 /*0x10*/;
              num2 = (int) (IntPtr) num1;
              continue;
            case 38:
              if (flag)
              {
                num1 = (short) 3;
                num2 = (int) (IntPtr) num1;
                continue;
              }
              goto case 34;
            default:
label_5:
              if (this.dgSelectedRadios.HasItems)
              {
                num1 = (short) 15;
                num2 = (int) (IntPtr) num1;
                continue;
              }
              goto label_93;
          }
          num1 = (short) 11;
          num2 = (int) (IntPtr) num1;
          continue;
label_47:
          this.d();
          num1 = (short) 1;
          num2 = (int) (IntPtr) num1;
          continue;
label_58:
          isChecked = this.chkboxStaticIpAddress.IsChecked;
          num1 = (short) 18;
          num2 = (int) (IntPtr) num1;
          continue;
label_62:
          num1 = (short) 17;
          num2 = (int) (IntPtr) num1;
        }
label_87:
        break;
label_61:
        break;
label_42:
        break;
label_50:
        num1 = (short) 0;
        break;
label_51:
        int num11 = (int) System.Windows.MessageBox.Show(AppResources.Please_Select_A_Time_To_Start_Batch_Programming);
        break;
label_91:
        break;
label_92:
        ((UIElement) this.dtSchedulerDateTime).IsEnabled = false;
        this.btnStart.IsEnabled = false;
        this.txtboxRadioListFilePath.IsEnabled = false;
        this.btnRadioListFilePathBrowse.IsEnabled = false;
        this.chkboxStaticIpAddress.IsEnabled = false;
        this.autoRegServer.IsEnabled = false;
        this.btnAdd.IsEnabled = false;
        this.btnAddAll.IsEnabled = false;
        this.btnRemove.IsEnabled = false;
        this.btnRemoveAll.IsEnabled = false;
        this.txtbxNumRetries.IsEnabled = false;
        this.chkboxWriteProtect.IsEnabled = false;
        this.b = new DispatcherTimer();
        this.a = TimeSpan.FromMilliseconds(5000.0);
        this.b.Interval = this.a;
        this.b.Tick += new EventHandler(this.batchTimer_Tick);
        this.b.Start();
        AppInfoManager.StatusMsgReport.Clear();
        break;
label_93:
        int num12 = (int) System.Windows.MessageBox.Show(AppResources.No_Radios_Have_Been_Selected_For_Programming);
        break;
    }
  }

  private void batchTimer_Tick(object A_0, EventArgs A_1)
  {
    int A_1_1 = 19;
    switch (0)
    {
      default:
        short num1 = 2;
        int num2 = (int) (IntPtr) num1;
        while (true)
        {
          POP25BatchProgrammerProgress programmerProgress;
          DateTime dateTime;
          int num3;
          IEnumerator enumerator;
          DateTime now;
          switch (num2)
          {
            case 0:
              goto label_24;
            case 1:
              try
              {
                num1 = (short) 2;
                num2 = (int) (IntPtr) num1;
                while (true)
                {
                  switch (num2)
                  {
                    case 1:
                      if (!enumerator.MoveNext())
                      {
                        num1 = (short) 3;
                        num2 = (int) (IntPtr) num1;
                        continue;
                      }
                      POP25RadioInfo current = (POP25RadioInfo) enumerator.Current;
                      ++num3;
                      POP25RadioInfo newItem = new POP25RadioInfo();
                      newItem.Radio_ID = current.Radio_ID;
                      newItem.Radio_IP = current.Radio_IP;
                      newItem.Status = "";
                      programmerProgress.dgBatchProgrammingProgress.Items.Add((object) newItem);
                      newItem.IndexInList = num3;
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
                      num1 = (short) 4;
                      num2 = (int) (IntPtr) num1;
                      continue;
                    case 4:
                      goto label_11;
                  }
                  num1 = (short) 1;
                  num2 = (int) (IntPtr) num1;
                }
              }
              finally
              {
                IDisposable disposable;
                short num4;
                switch (0)
                {
                  case 0:
label_29:
                    disposable = enumerator as IDisposable;
                    num4 = (short) 0;
                    num2 = (int) (IntPtr) num4;
                    goto default;
                  default:
                    while (true)
                    {
                      switch (num2)
                      {
                        case 0:
                          if (disposable != null)
                          {
                            num4 = (short) 1;
                            num2 = (int) (IntPtr) num4;
                            continue;
                          }
                          goto label_35;
                        case 1:
                          disposable.Dispose();
                          num4 = (short) 2;
                          num2 = (int) (IntPtr) num4;
                          continue;
                        case 2:
                          goto label_35;
                        default:
                          goto label_29;
                      }
                    }
label_35:;
                }
              }
label_11:
              programmerProgress.Show();
              programmerProgress.Focus();
              programmerProgress.Hide();
              programmerProgress.ShowDialog();
              this.btnStart.IsEnabled = true;
              ((UIElement) this.dtSchedulerDateTime).IsEnabled = true;
              this.txtboxRadioListFilePath.IsEnabled = true;
              this.btnRadioListFilePathBrowse.IsEnabled = true;
              this.chkboxStaticIpAddress.IsEnabled = true;
              this.autoRegServer.IsEnabled = this.d.OTAP_BATCH_ENABLE_ARS_SERVER_IP_ADDRESS;
              this.btnAdd.IsEnabled = true;
              this.btnAddAll.IsEnabled = true;
              this.btnRemove.IsEnabled = true;
              this.btnRemoveAll.IsEnabled = true;
              this.txtbxNumRetries.IsEnabled = true;
              this.chkboxWriteProtect.IsEnabled = true;
              num1 = (short) 0;
              num2 = (int) (IntPtr) num1;
              continue;
            case 2:
              switch (0)
              {
                case 0:
                  goto label_4;
                default:
                  continue;
              }
            case 3:
              if (!this.CancelBatchSchedule)
              {
                num1 = (short) 6;
                num2 = (int) (IntPtr) num1;
                continue;
              }
              goto label_32;
            case 4:
              if (dateTime.CompareTo(now) > 0)
                goto label_26;
              break;
            case 5:
              num1 = (short) 3;
              num2 = (int) (IntPtr) num1;
              continue;
            case 6:
              num1 = (short) 0;
              dateTime = this.dtSchedulerDateTime.Value.Value;
              now = DateTime.Now;
              num1 = (short) 1933;
              int num5 = (int) num1;
              num1 = (short) 1933;
              int num6 = (int) num1;
              switch (num5 == num6 ? 1 : 0)
              {
                case 0:
                case 2:
                  break;
                default:
                  num1 = (short) 0;
                  if (num1 == (short) 0)
                    ;
                  num1 = (short) 4;
                  num2 = (int) (IntPtr) num1;
                  continue;
              }
              break;
            case 7:
              num1 = (short) 1;
              if (num1 == (short) 0)
                ;
              this.b.Stop();
              programmerProgress = new POP25BatchProgrammerProgress();
              ((System.Windows.Controls.TextBox) programmerProgress.dtProgressDateTime).Text = dateTime.ToString(RptMgrErrorHandler.b("톕", A_1_1), (IFormatProvider) Thread.CurrentThread.CurrentCulture);
              programmerProgress.ARSServerEnabled = this.chkboxStaticIpAddress.IsChecked.Value;
              programmerProgress.txtboxArsServer.Text = this.f;
              programmerProgress.txtbxRetryCount.Text = this.NumRetriePerFailedRadios;
              programmerProgress.WriteProtectWriteProtectedRad = this.WriteProtectRadios;
              programmerProgress.TargetARS = (PNServer) this.autoRegServer.SelectedItem;
              programmerProgress.DhBuff = this.h;
              num3 = -1;
              enumerator = ((IEnumerable) this.dgSelectedRadios.Items).GetEnumerator();
              num1 = (short) 1;
              num2 = (int) (IntPtr) num1;
              continue;
            default:
label_4:
              if (this.b != null)
              {
                num1 = (short) 5;
                num2 = (int) (IntPtr) num1;
                continue;
              }
              goto label_34;
          }
          num1 = (short) 7;
          num2 = (int) (IntPtr) num1;
        }
label_24:
        break;
label_34:
        break;
label_32:
        break;
label_26:
        break;
    }
  }

  private void EnableArsServer_Checked(object A_0, RoutedEventArgs A_1)
  {
    short num1 = 20261;
    int num2 = (int) num1;
    num1 = (short) 20261;
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
        this.d.OTAP_BATCH_ENABLE_ARS_SERVER_IP_ADDRESS = true;
        this.autoRegServer.IsEnabled = true;
        break;
      default:
        goto case 1;
    }
  }

  private void EnableArsServer_UnChecked(object A_0, RoutedEventArgs A_1)
  {
    short num1 = 5630;
    int num2 = (int) num1;
    num1 = (short) 5630;
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
        this.d.OTAP_BATCH_ENABLE_ARS_SERVER_IP_ADDRESS = false;
        this.autoRegServer.IsEnabled = false;
        break;
      default:
        goto case 1;
    }
  }

  private void btnCancel_Click(object A_0, RoutedEventArgs A_1)
  {
    short num1 = 2738;
    int num2 = (int) num1;
    num1 = (short) 2738;
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
        this.CancelBatchSchedule = true;
        this.Close();
        break;
      default:
        goto case 1;
    }
  }

  private void SchedulerWindowClosing(object A_0, CancelEventArgs A_1)
  {
    short num1 = 1;
    if (num1 == (short) 0)
      ;
    int num2;
    switch (0)
    {
      case 0:
label_3:
        this.CancelBatchSchedule = true;
        break;
      default:
        while (true)
        {
          switch (num2)
          {
            case 0:
              num1 = (short) -30574;
              int num3 = (int) num1;
              num1 = (short) -30574;
              int num4 = (int) num1;
              switch (num3 == num4 ? 1 : 0)
              {
                case 0:
                case 2:
                  goto label_4;
                default:
                  num1 = (short) 0;
                  if (num1 == (short) 0)
                    ;
                  if (!this.b())
                  {
                    num1 = (short) 1;
                    num2 = (int) (IntPtr) num1;
                    continue;
                  }
                  goto label_11;
              }
            case 1:
              A_1.Cancel = true;
              num1 = (short) 2;
              num2 = (int) (IntPtr) num1;
              continue;
            case 2:
              goto label_10;
            default:
              goto label_3;
          }
label_2:;
        }
label_11:
        return;
label_10:
        num1 = (short) 0;
        return;
    }
label_4:
    num1 = (short) 0;
    num2 = (int) (IntPtr) num1;
    goto label_2;
  }

  private bool b()
  {
    int num1;
    bool flag;
    short num2;
    switch (0)
    {
      case 0:
label_2:
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
              if (this.b.IsEnabled)
              {
                num2 = (short) 0;
                num2 = (short) 4;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_17;
            case 1:
            case 7:
              goto label_17;
            case 2:
              if (this.b != null)
              {
                num2 = (short) 5;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_17;
            case 3:
              if (System.Windows.MessageBox.Show(AppResources.Warning_A_Batch_Programming_Schedule_Has_Already_Setup, AppResources.Cancel_Batch_Programming_Schedule, MessageBoxButton.YesNo, MessageBoxImage.Exclamation) != MessageBoxResult.Yes)
              {
                num2 = (short) 6;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              this.btnStart.IsEnabled = true;
              ((UIElement) this.dtSchedulerDateTime).IsEnabled = true;
              this.txtboxRadioListFilePath.IsEnabled = true;
              this.btnRadioListFilePathBrowse.IsEnabled = true;
              this.chkboxStaticIpAddress.IsEnabled = true;
              this.autoRegServer.IsEnabled = true;
              this.btnAdd.IsEnabled = true;
              this.btnAddAll.IsEnabled = true;
              this.btnRemove.IsEnabled = true;
              this.btnRemoveAll.IsEnabled = true;
              this.txtbxNumRetries.IsEnabled = true;
              this.chkboxWriteProtect.IsEnabled = true;
              flag = false;
              break;
            case 4:
              num2 = (short) 30108;
              int num3 = (int) num2;
              num2 = (short) 30108;
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
                  this.b.Stop();
                  num2 = (short) 1;
                  if (num2 == (short) 0)
                    ;
                  num2 = (short) 3;
                  num1 = (int) (IntPtr) num2;
                  continue;
              }
              break;
            case 5:
              num2 = (short) 0;
              num1 = (int) (IntPtr) num2;
              continue;
            case 6:
              flag = false;
              this.b.Start();
              num2 = (short) 1;
              num1 = (int) (IntPtr) num2;
              continue;
            default:
              goto label_2;
          }
          num2 = (short) 7;
          num1 = (int) (IntPtr) num2;
        }
label_17:
        this.CancelBatchSchedule = false;
        return flag;
    }
  }

  private bool a(POP25RadioInfo A_0, POP25RadioInfo A_1)
  {
    while (A_0.Radio_ID == A_1.Radio_ID)
    {
      short num1 = -3084;
      int num2 = (int) num1;
      num1 = (short) -3084;
      int num3 = (int) num1;
      switch (num2 == num3 ? 1 : 0)
      {
        case 0:
        case 2:
          continue;
        default:
          num1 = (short) 1;
          if (num1 == (short) 0)
            ;
          num1 = (short) 0;
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          return A_0.Radio_IP == A_1.Radio_IP;
      }
    }
    return false;
  }

  private void btnAdd_Click(object A_0, RoutedEventArgs A_1)
  {
    int A_1_1 = 18;
    switch (0)
    {
      default:
        int num1 = 21;
        while (true)
        {
          short num2;
          POP25RadioInfo selectedItem;
          string str;
          bool flag;
          System.Windows.Input.Cursor overrideCursor;
          IEnumerator enumerator;
          switch (num1)
          {
            case 0:
              if (selectedItem.Radio_IP_Valid)
              {
                num2 = (short) 49;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_75;
            case 1:
            case 27:
            case 38:
              num2 = (short) 42;
              num1 = (int) (IntPtr) num2;
              continue;
            case 2:
              num2 = (short) 24;
              num1 = (int) (IntPtr) num2;
              continue;
            case 3:
              int num3 = (int) System.Windows.MessageBox.Show(AppResources.BP_Warning_Some_radios_require_the_presence_of_an_ARS_to_be_programmed, AppResources.Warning_Id, MessageBoxButton.OK, MessageBoxImage.Exclamation);
              num2 = (short) 33;
              num1 = (int) (IntPtr) num2;
              continue;
            case 4:
              if (string.IsNullOrEmpty(selectedItem.Radio_ID))
              {
                num2 = (short) 46;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 11;
            case 5:
              if (this.dgAvailableRadio.SelectedItems.Count <= 0)
              {
                num2 = (short) 1;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              flag = false;
              selectedItem = (POP25RadioInfo) this.dgAvailableRadio.SelectedItems[0];
              num2 = (short) 4;
              num1 = (int) (IntPtr) num2;
              continue;
            case 6:
              num2 = (short) 27;
              num1 = (int) (IntPtr) num2;
              continue;
            case 7:
              num2 = (short) 26;
              num1 = (int) (IntPtr) num2;
              continue;
            case 8:
              num2 = (short) 48 /*0x30*/;
              num1 = (int) (IntPtr) num2;
              continue;
            case 9:
            case 16 /*0x10*/:
            case 29:
            case 36:
            case 40:
            case 45:
              num2 = (short) 5;
              num1 = (int) (IntPtr) num2;
              continue;
            case 10:
label_22:
              num2 = (short) 38;
              num1 = (int) (IntPtr) num2;
              continue;
            case 11:
              num2 = (short) 41;
              num1 = (int) (IntPtr) num2;
              continue;
            case 12:
              enumerator = ((IEnumerable) this.dgSelectedRadios.Items).GetEnumerator();
              num2 = (short) 32 /*0x20*/;
              num1 = (int) (IntPtr) num2;
              continue;
            case 13:
              num2 = (short) 35;
              num1 = (int) (IntPtr) num2;
              continue;
            case 14:
              overrideCursor = Mouse.OverrideCursor;
              Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
              str = "";
              num2 = (short) 36;
              num1 = (int) (IntPtr) num2;
              continue;
            case 15:
              if (selectedItem.Radio_ID_Valid)
              {
                num2 = (short) 13;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_82;
            case 17:
              if (System.Windows.MessageBox.Show(AppResources.You_Are_Trying_Select_An_Invalid_Radio, AppResources.Error_excalmatory_mark, MessageBoxButton.OK, MessageBoxImage.Exclamation) == MessageBoxResult.OK)
              {
                num2 = (short) 6;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 9;
            case 18:
              num2 = (short) 15;
              num1 = (int) (IntPtr) num2;
              continue;
            case 19:
              if (selectedItem.Radio_IP.Length <= 0)
              {
                num2 = (short) 43;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_81;
            case 20:
              num2 = (short) 39;
              num1 = (int) (IntPtr) num2;
              continue;
            case 21:
              switch (0)
              {
                case 0:
                  goto label_4;
                default:
                  continue;
              }
            case 22:
              num2 = (short) 1;
              if (num2 == (short) 0)
                ;
              if (System.Windows.MessageBox.Show(AppResources.You_Are_Trying_Select_An_Invalid_Radio, AppResources.Error_excalmatory_mark, MessageBoxButton.OK, MessageBoxImage.Exclamation) == MessageBoxResult.OK)
              {
                num2 = (short) 10;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 9;
            case 23:
              if (this.autoRegServer.Items.Count <= 0)
              {
                num2 = (short) 7;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              break;
            case 24:
              if (this.autoRegServer.Items.Count <= 0)
              {
                num2 = (short) 31667;
                int num4 = (int) num2;
                num2 = (short) 31667;
                int num5 = (int) num2;
                switch (num4 == num5 ? 1 : 0)
                {
                  case 0:
                  case 2:
                    goto label_22;
                  default:
                    num2 = (short) 0;
                    num2 = (short) 0;
                    if (num2 == (short) 0)
                      ;
                    num2 = (short) 8;
                    num1 = (int) (IntPtr) num2;
                    continue;
                }
              }
              else
                goto label_81;
            case 25:
              num2 = (short) 19;
              num1 = (int) (IntPtr) num2;
              continue;
            case 26:
              if (selectedItem.Radio_ID.Length > 0)
              {
                num2 = (short) 20;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              break;
            case 28:
              str = str + selectedItem.Radio_ID + RptMgrErrorHandler.b("龔", A_1_1);
              this.dgAvailableRadio.SelectedItems.Remove((object) selectedItem);
              num2 = (short) 9;
              num1 = (int) (IntPtr) num2;
              continue;
            case 30:
              if (string.IsNullOrEmpty(selectedItem.Radio_IP))
              {
                num2 = (short) 37;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              num2 = (short) 11;
              num1 = (int) (IntPtr) num2;
              continue;
            case 31 /*0x1F*/:
              num2 = (short) 0;
              num1 = (int) (IntPtr) num2;
              continue;
            case 32 /*0x20*/:
              try
              {
                num2 = (short) 1;
                num1 = (int) (IntPtr) num2;
                while (true)
                {
                  POP25RadioInfo current;
                  switch (num1)
                  {
                    case 0:
                      flag = true;
                      this.dgAvailableRadio.SelectedItems.RemoveAt(0);
                      num2 = (short) 3;
                      num1 = (int) (IntPtr) num2;
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
                      num2 = (short) 6;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 3:
                    case 6:
                      goto label_23;
                    case 4:
                      if (!enumerator.MoveNext())
                      {
                        num2 = (short) 2;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      current = (POP25RadioInfo) enumerator.Current;
                      num2 = (short) 5;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 5:
                      if (this.a(selectedItem, current))
                      {
                        num2 = (short) 0;
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
                IDisposable disposable;
                switch (0)
                {
                  case 0:
label_47:
                    disposable = enumerator as IDisposable;
                    num1 = 0;
                    goto default;
                  default:
                    while (true)
                    {
                      switch (num1)
                      {
                        case 0:
                          if (disposable != null)
                          {
                            num1 = 1;
                            continue;
                          }
                          goto label_51;
                        case 1:
                          disposable.Dispose();
                          num1 = 2;
                          continue;
                        case 2:
                          goto label_51;
                        default:
                          goto label_47;
                      }
                    }
label_51:;
                }
              }
label_23:
              num2 = (short) 47;
              num1 = (int) (IntPtr) num2;
              continue;
            case 33:
              Mouse.OverrideCursor = overrideCursor;
              num2 = (short) 34;
              num1 = (int) (IntPtr) num2;
              continue;
            case 34:
              goto label_93;
            case 35:
              if (selectedItem.Radio_IP_Valid)
              {
                num2 = (short) 2;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_82;
            case 37:
              if (System.Windows.MessageBox.Show(AppResources.Empty_Entries_Not_Allowed_Please_Remove_Before_Continuing, AppResources.Error_excalmatory_mark, MessageBoxButton.OK, MessageBoxImage.Exclamation) != MessageBoxResult.OK)
              {
                num2 = (short) 16 /*0x10*/;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 1;
            case 39:
              if (selectedItem.Radio_IP.Length <= 0)
              {
                num2 = (short) 28;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              break;
            case 41:
              if (!this.dgSelectedRadios.HasItems)
              {
                num2 = (short) 44;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              num2 = (short) 12;
              num1 = (int) (IntPtr) num2;
              continue;
            case 42:
              if (str.Length > 0)
              {
                num2 = (short) 3;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 33;
            case 43:
              str = str + selectedItem.Radio_ID + RptMgrErrorHandler.b("龔", A_1_1);
              this.dgAvailableRadio.SelectedItems.Remove((object) selectedItem);
              num2 = (short) 29;
              num1 = (int) (IntPtr) num2;
              continue;
            case 44:
              if (selectedItem.Radio_ID_Valid)
              {
                num2 = (short) 31 /*0x1F*/;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_75;
            case 46:
              num2 = (short) 30;
              num1 = (int) (IntPtr) num2;
              continue;
            case 47:
              if (!flag)
              {
                num2 = (short) 18;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 9;
            case 48 /*0x30*/:
              if (selectedItem.Radio_ID.Length > 0)
              {
                num2 = (short) 25;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_81;
            case 49:
              num2 = (short) 23;
              num1 = (int) (IntPtr) num2;
              continue;
            default:
label_4:
              if (this.dgAvailableRadio.SelectedItems.Count > 0)
              {
                num2 = (short) 14;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_95;
          }
          this.dgSelectedRadios.Items.Add((object) selectedItem);
          this.DataSource.Remove(selectedItem);
          num2 = (short) 40;
          num1 = (int) (IntPtr) num2;
          continue;
label_75:
          num2 = (short) 17;
          num1 = (int) (IntPtr) num2;
          continue;
label_81:
          this.dgSelectedRadios.Items.Add((object) selectedItem);
          this.DataSource.Remove(selectedItem);
          num2 = (short) 45;
          num1 = (int) (IntPtr) num2;
          continue;
label_82:
          num2 = (short) 22;
          num1 = (int) (IntPtr) num2;
        }
label_93:
        break;
label_95:
        break;
    }
  }

  private void btnAddAll_Click(object A_0, RoutedEventArgs A_1)
  {
    int A_1_1 = 18;
    int num1 = 0;
    switch (num1)
    {
      default:
        short num2;
        switch (0)
        {
          case 0:
label_3:
            this.dgAvailableRadio.SelectAll();
            num2 = (short) 10;
            num1 = (int) (IntPtr) num2;
            goto default;
          default:
            while (true)
            {
              POP25RadioInfo selectedItem;
              string str;
              bool flag;
              System.Windows.Input.Cursor overrideCursor;
              IEnumerator enumerator;
              switch (num1)
              {
                case 0:
                  num2 = (short) 5;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 1:
                  enumerator = ((IEnumerable) this.dgSelectedRadios.Items).GetEnumerator();
                  num2 = (short) 47;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 2:
                case 8:
                case 13:
                case 15:
                case 27:
                case 43:
                  num2 = (short) 49;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 3:
                  if (selectedItem.Radio_ID_Valid)
                  {
                    num2 = (short) 45;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_75;
                case 4:
                  num2 = (short) 39;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 5:
                  if (this.autoRegServer.Items.Count <= 0)
                  {
                    num2 = (short) 38;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  break;
                case 6:
                  if (string.IsNullOrEmpty(selectedItem.Radio_ID))
                  {
                    num2 = (short) 34;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 32 /*0x20*/;
                case 7:
                  if (string.IsNullOrEmpty(selectedItem.Radio_IP))
                  {
                    num2 = (short) 37;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 32 /*0x20*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 9:
                  num2 = (short) 36;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 10:
                  if (this.dgAvailableRadio.SelectedItems.Count > 0)
                  {
                    num2 = (short) 28;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_95;
                case 11:
                case 17:
                case 41:
                  num2 = (short) 14;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 12:
                  str = str + selectedItem.Radio_ID + RptMgrErrorHandler.b("龔", A_1_1);
                  this.dgAvailableRadio.SelectedItems.Remove((object) selectedItem);
                  num2 = (short) 43;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 14:
                  if (str.Length > 0)
                  {
                    num2 = (short) 42;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 16 /*0x10*/;
                case 16 /*0x10*/:
                  Mouse.OverrideCursor = overrideCursor;
                  num2 = (short) 46;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 18:
                  num2 = (short) 17;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 19:
                  num2 = (short) 30;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 20:
                  if (!this.dgSelectedRadios.HasItems)
                  {
                    num2 = (short) 3;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 1;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 21:
                  if (selectedItem.Radio_IP_Valid)
                  {
                    num2 = (short) 0;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_75;
                case 22:
                  num2 = (short) 0;
                  if (selectedItem.Radio_ID.Length > 0)
                  {
                    num2 = (short) 24;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  break;
                case 23:
                  num2 = (short) 40;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 24:
                  num2 = (short) 29;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 25:
                  if (System.Windows.MessageBox.Show(AppResources.You_Are_Trying_Select_An_Invalid_Radio, AppResources.Error_excalmatory_mark, MessageBoxButton.OK, MessageBoxImage.Exclamation) == MessageBoxResult.OK)
                  {
                    num2 = (short) 18;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 2;
                case 26:
                  if (System.Windows.MessageBox.Show(AppResources.You_Are_Trying_Select_An_Invalid_Radio, AppResources.Error_excalmatory_mark, MessageBoxButton.OK, MessageBoxImage.Exclamation) == MessageBoxResult.OK)
                  {
                    num2 = (short) 31 /*0x1F*/;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 2;
                case 28:
                  overrideCursor = Mouse.OverrideCursor;
                  Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
                  str = "";
                  num2 = (short) 13;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 29:
                  if (selectedItem.Radio_IP.Length <= 0)
                  {
                    num2 = (short) 44;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  break;
                case 30:
                  if (selectedItem.Radio_ID.Length > 0)
                  {
                    num2 = (short) 35;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_81;
                case 31 /*0x1F*/:
                  num2 = (short) 41;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 32 /*0x20*/:
                  num2 = (short) 20;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 33:
                  if (selectedItem.Radio_IP.Length <= 0)
                  {
                    num2 = (short) 12;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_81;
                case 34:
                  num2 = (short) 1;
                  if (num2 == (short) 0)
                    ;
                  num2 = (short) 7;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 35:
                  num2 = (short) 33;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 36:
                  if (selectedItem.Radio_ID_Valid)
                  {
                    num2 = (short) 23;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_82;
                case 37:
                  if (System.Windows.MessageBox.Show(AppResources.Empty_Entries_Not_Allowed_Please_Remove_Before_Continuing, AppResources.Error_excalmatory_mark, MessageBoxButton.OK, MessageBoxImage.Exclamation) != MessageBoxResult.OK)
                  {
                    num2 = (short) 27;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 11;
                case 38:
                  num2 = (short) 22;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 39:
                  if (this.autoRegServer.Items.Count <= 0)
                  {
                    num2 = (short) 19;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_81;
                case 40:
                  if (selectedItem.Radio_IP_Valid)
                  {
                    num2 = (short) 4;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_82;
                case 42:
                  int num3 = (int) System.Windows.MessageBox.Show(AppResources.BP_Warning_Some_radios_require_the_presence_of_an_ARS_to_be_programmed, AppResources.Warning_Id, MessageBoxButton.OK, MessageBoxImage.Exclamation);
                  num2 = (short) 16 /*0x10*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 44:
                  str = str + selectedItem.Radio_ID + RptMgrErrorHandler.b("龔", A_1_1);
                  this.dgAvailableRadio.SelectedItems.Remove((object) selectedItem);
                  num2 = (short) 2;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 45:
                  num2 = (short) 21;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 46:
                  goto label_93;
                case 47:
                  try
                  {
                    num2 = (short) -8152;
                    int num4 = (int) num2;
                    num2 = (short) -8152;
                    int num5 = (int) num2;
                    switch (num4 == num5 ? 1 : 0)
                    {
                      case 0:
                      case 2:
                        while (true)
                        {
                          POP25RadioInfo current;
                          switch (num1)
                          {
                            case 0:
                              if (this.a(selectedItem, current))
                              {
                                num2 = (short) 1;
                                num1 = (int) (IntPtr) num2;
                                continue;
                              }
                              break;
                            case 1:
                              flag = true;
                              this.dgAvailableRadio.SelectedItems.RemoveAt(0);
                              num2 = (short) 3;
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
                            case 4:
                              goto label_23;
                            case 5:
                              if (!enumerator.MoveNext())
                              {
                                num2 = (short) 6;
                                num1 = (int) (IntPtr) num2;
                                continue;
                              }
                              current = (POP25RadioInfo) enumerator.Current;
                              num2 = (short) 0;
                              num1 = (int) (IntPtr) num2;
                              continue;
                            case 6:
                              num2 = (short) 4;
                              num1 = (int) (IntPtr) num2;
                              continue;
                          }
                          num2 = (short) 5;
                          num1 = (int) (IntPtr) num2;
                        }
                      default:
                        num2 = (short) 0;
                        if (num2 == (short) 0)
                          ;
                        num2 = (short) 2;
                        num1 = (int) (IntPtr) num2;
                        goto case 0;
                    }
                  }
                  finally
                  {
                    IDisposable disposable;
                    short num6;
                    switch (0)
                    {
                      case 0:
label_49:
                        disposable = enumerator as IDisposable;
                        num6 = (short) 2;
                        num1 = (int) (IntPtr) num6;
                        goto default;
                      default:
                        while (true)
                        {
                          switch (num1)
                          {
                            case 0:
                              disposable.Dispose();
                              num6 = (short) 1;
                              num1 = (int) (IntPtr) num6;
                              continue;
                            case 1:
                              goto label_53;
                            case 2:
                              if (disposable != null)
                              {
                                num6 = (short) 0;
                                num1 = (int) (IntPtr) num6;
                                continue;
                              }
                              goto label_53;
                            default:
                              goto label_49;
                          }
                        }
label_53:;
                    }
                  }
label_23:
                  num1 = 48 /*0x30*/;
                  continue;
                case 48 /*0x30*/:
                  if (!flag)
                  {
                    num2 = (short) 9;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 2;
                case 49:
                  if (this.dgAvailableRadio.SelectedItems.Count <= 0)
                  {
                    num2 = (short) 11;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  flag = false;
                  selectedItem = (POP25RadioInfo) this.dgAvailableRadio.SelectedItems[0];
                  num2 = (short) 6;
                  num1 = (int) (IntPtr) num2;
                  continue;
                default:
                  goto label_3;
              }
              this.dgSelectedRadios.Items.Add((object) selectedItem);
              this.DataSource.Remove(selectedItem);
              num2 = (short) 15;
              num1 = (int) (IntPtr) num2;
              continue;
label_75:
              num2 = (short) 26;
              num1 = (int) (IntPtr) num2;
              continue;
label_81:
              this.dgSelectedRadios.Items.Add((object) selectedItem);
              this.DataSource.Remove(selectedItem);
              num2 = (short) 8;
              num1 = (int) (IntPtr) num2;
              continue;
label_82:
              num2 = (short) 25;
              num1 = (int) (IntPtr) num2;
            }
label_93:
            return;
label_95:
            return;
        }
    }
  }

  private void btnRemove_Click(object A_0, RoutedEventArgs A_1)
  {
    short num1 = 0;
    num1 = (short) 1;
    int num2 = (int) (IntPtr) num1;
    while (true)
    {
      switch (num2)
      {
        case 0:
          while (this.dgSelectedRadios.SelectedItems.Count > 0)
          {
            num1 = (short) -12624;
            int num3 = (int) num1;
            num1 = (short) -12624;
            int num4 = (int) num1;
            switch (num3 == num4 ? 1 : 0)
            {
              case 0:
              case 2:
                continue;
              default:
                num1 = (short) 0;
                if (num1 == (short) 0)
                  ;
                POP25RadioInfo selectedItem = (POP25RadioInfo) this.dgSelectedRadios.SelectedItems[0];
                this.dgSelectedRadios.Items.Remove((object) selectedItem);
                this.DataSource.Add(selectedItem);
                num1 = (short) 3;
                num2 = (int) (IntPtr) num1;
                goto label_2;
            }
          }
          num1 = (short) 2;
          num2 = (int) (IntPtr) num1;
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
          goto label_12;
        case 3:
        case 4:
          num1 = (short) 0;
          num2 = (int) (IntPtr) num1;
          continue;
        case 5:
          num1 = (short) 1;
          if (num1 == (short) 0)
            ;
          num1 = (short) 4;
          num2 = (int) (IntPtr) num1;
          continue;
      }
      if (this.dgSelectedRadios.Items.Count > 0)
      {
        num1 = (short) 5;
        num2 = (int) (IntPtr) num1;
        continue;
      }
      goto label_14;
label_2:;
    }
label_12:
    return;
label_14:;
  }

  private void btnRemoveAll_Click(object A_0, RoutedEventArgs A_1)
  {
    short num1 = 0;
    num1 = (short) 1;
    int num2 = (int) (IntPtr) num1;
    while (true)
    {
      switch (num2)
      {
        case 0:
          while (this.dgSelectedRadios.Items.Count > 0)
          {
            num1 = (short) -28313;
            int num3 = (int) num1;
            num1 = (short) -28313;
            int num4 = (int) num1;
            switch (num3 == num4 ? 1 : 0)
            {
              case 0:
              case 2:
                continue;
              default:
                num1 = (short) 0;
                if (num1 == (short) 0)
                  ;
                POP25RadioInfo removeItem = (POP25RadioInfo) this.dgSelectedRadios.Items[0];
                this.dgSelectedRadios.Items.Remove((object) removeItem);
                this.DataSource.Add(removeItem);
                num1 = (short) 3;
                num2 = (int) (IntPtr) num1;
                goto label_2;
            }
          }
          num1 = (short) 2;
          num2 = (int) (IntPtr) num1;
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
          goto label_12;
        case 3:
        case 4:
          num1 = (short) 0;
          num2 = (int) (IntPtr) num1;
          continue;
        case 5:
          num1 = (short) 4;
          num2 = (int) (IntPtr) num1;
          continue;
      }
      num1 = (short) 1;
      if (num1 == (short) 0)
        ;
      if (this.dgSelectedRadios.Items.Count > 0)
      {
        num1 = (short) 5;
        num2 = (int) (IntPtr) num1;
        continue;
      }
      goto label_14;
label_2:;
    }
label_12:
    return;
label_14:;
  }

  private void F1HelpCommandCanExcute(object A_0, CanExecuteRoutedEventArgs A_1)
  {
    short num1 = 8088;
    int num2 = (int) num1;
    num1 = (short) 8088;
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
        A_1.CanExecute = true;
        break;
      default:
        goto case 1;
    }
  }

  private void btnSchedulerHelp_Click(object A_0, RoutedEventArgs A_1)
  {
    int A_1_1 = 9;
    try
    {
      short num = 491;
      switch ((short) 491 == num)
      {
        case true:
          num = (short) 0;
          if (num == (short) 0)
            ;
          Utility.CloseHelpWindowIfOpen();
          Utility.DisplayCPSHelpDITA(RptMgrErrorHandler.b("꾋\uEB8Dꢏ꒑ꊓ꒕겗ꦙ겛", A_1_1));
          break;
        default:
          goto case 1;
      }
    }
    catch (Exception ex)
    {
    }
    if (false)
      ;
  }

  private void txtboxRadioListFilePath_SelectionChanged(object A_0, RoutedEventArgs A_1)
  {
    short num1 = 0;
    int num2;
    string text;
    switch (0)
    {
      case 0:
label_2:
        text = this.txtboxRadioListFilePath.Text;
        num1 = (short) 2;
        num2 = (int) (IntPtr) num1;
        goto default;
      default:
        while (true)
        {
          switch (num2)
          {
            case 0:
              goto label_8;
            case 1:
              if (!System.IO.File.Exists(text))
                goto label_12;
              break;
            case 2:
              if (string.IsNullOrEmpty(text))
              {
                num1 = (short) 3;
                num2 = (int) (IntPtr) num1;
                continue;
              }
              goto label_8;
            case 3:
              num1 = (short) 1;
              if (num1 == (short) 0)
                ;
              num1 = (short) -646;
              int num3 = (int) num1;
              num1 = (short) -646;
              int num4 = (int) num1;
              switch (num3 == num4 ? 1 : 0)
              {
                case 0:
                case 2:
                  break;
                default:
                  num1 = (short) 0;
                  if (num1 == (short) 0)
                    ;
                  num1 = (short) 1;
                  num2 = (int) (IntPtr) num1;
                  continue;
              }
              break;
            default:
              goto label_2;
          }
          num1 = (short) 0;
          num2 = (int) (IntPtr) num1;
        }
label_8:
        this.b(this.txtboxRadioListFilePath.Text);
        break;
label_12:
        int num5 = (int) System.Windows.MessageBox.Show(AppResources.Please_Select_A_Valid_Radio_List_XML_file, AppResources.File_Does_Not_Exist, MessageBoxButton.OK, MessageBoxImage.Exclamation);
        break;
    }
  }

  private bool a(string A_0)
  {
    short num1;
    bool flag;
    try
    {
      int num2;
      byte[] addressBytes;
      byte num3;
      switch (0)
      {
        case 0:
label_2:
          addressBytes = IPAddress.Parse(A_0).GetAddressBytes();
          num3 = addressBytes[0];
          num1 = (short) 17;
          num2 = (int) (IntPtr) num1;
          goto default;
        default:
          while (true)
          {
            switch (num2)
            {
              case 0:
                if (addressBytes[3] != byte.MaxValue)
                {
                  num1 = (short) 30;
                  num2 = (int) (IntPtr) num1;
                  continue;
                }
                goto case 8;
              case 1:
                if (addressBytes[1] != (byte) 0)
                {
                  num1 = (short) 31 /*0x1F*/;
                  num2 = (int) (IntPtr) num1;
                  continue;
                }
                goto case 8;
              case 2:
                flag = false;
                num1 = (short) 35;
                num2 = (int) (IntPtr) num1;
                continue;
              case 3:
                if (num3 != (byte) 127 /*0x7F*/)
                {
                  num1 = (short) 20;
                  num2 = (int) (IntPtr) num1;
                  continue;
                }
                goto case 2;
              case 4:
                num1 = (short) 39;
                num2 = (int) (IntPtr) num1;
                continue;
              case 5:
                if (addressBytes[3] != (byte) 0)
                {
                  num1 = (short) 44;
                  num2 = (int) (IntPtr) num1;
                  continue;
                }
                goto case 24;
              case 6:
                if (num3 != (byte) 0)
                {
                  num1 = (short) 40;
                  num2 = (int) (IntPtr) num1;
                  continue;
                }
                num1 = (short) 2;
                num2 = (int) (IntPtr) num1;
                continue;
              case 7:
                if (addressBytes[2] != (byte) 0)
                {
                  num1 = (short) 47;
                  num2 = (int) (IntPtr) num1;
                  continue;
                }
                goto case 42;
              case 8:
                flag = false;
                num1 = (short) 12;
                num2 = (int) (IntPtr) num1;
                continue;
              case 9:
                if (addressBytes[1] == (byte) 0)
                {
                  num1 = (short) 37;
                  num2 = (int) (IntPtr) num1;
                  continue;
                }
                goto case 44;
              case 10:
                num1 = (short) 21;
                num2 = (int) (IntPtr) num1;
                continue;
              case 11:
                if (addressBytes[3] == byte.MaxValue)
                {
                  num1 = (short) 24;
                  num2 = (int) (IntPtr) num1;
                  continue;
                }
                break;
              case 12:
              case 22:
              case 33:
              case 35:
                goto label_79;
              case 13:
                num1 = (short) 28;
                num2 = (int) (IntPtr) num1;
                continue;
              case 14:
                if (addressBytes[2] == byte.MaxValue)
                {
                  num1 = (short) 41;
                  num2 = (int) (IntPtr) num1;
                  continue;
                }
                goto case 30;
              case 15:
                goto label_74;
              case 16 /*0x10*/:
                if (addressBytes[3] == byte.MaxValue)
                {
                  num1 = (short) 42;
                  num2 = (int) (IntPtr) num1;
                  continue;
                }
                break;
              case 17:
                if (num3 <= (byte) 223)
                {
                  num1 = (short) 27;
                  num2 = (int) (IntPtr) num1;
                  continue;
                }
                goto case 2;
              case 18:
                num1 = (short) 1;
                num2 = (int) (IntPtr) num1;
                continue;
              case 19:
                num1 = (short) 46;
                num2 = (int) (IntPtr) num1;
                continue;
              case 20:
                num1 = (short) 6;
                num2 = (int) (IntPtr) num1;
                continue;
              case 21:
                if (addressBytes[2] == byte.MaxValue)
                {
                  num1 = (short) 23;
                  num2 = (int) (IntPtr) num1;
                  continue;
                }
                break;
              case 23:
                num1 = (short) 11;
                num2 = (int) (IntPtr) num1;
                continue;
              case 24:
                flag = false;
                num1 = (short) 33;
                num2 = (int) (IntPtr) num1;
                continue;
              case 25:
                if (addressBytes[2] == (byte) 0)
                {
                  num1 = (short) 4;
                  num2 = (int) (IntPtr) num1;
                  continue;
                }
                break;
              case 26:
                num1 = (short) 16 /*0x10*/;
                num2 = (int) (IntPtr) num1;
                continue;
              case 27:
                num1 = (short) 3;
                num2 = (int) (IntPtr) num1;
                continue;
              case 28:
                if (addressBytes[1] == (byte) 0)
                {
                  num1 = (short) 43;
                  num2 = (int) (IntPtr) num1;
                  continue;
                }
                goto case 47;
              case 29:
                if (addressBytes[2] == (byte) 0)
                {
                  num1 = (short) 34;
                  num2 = (int) (IntPtr) num1;
                  continue;
                }
                goto case 44;
              case 30:
                num1 = (short) 25;
                num2 = (int) (IntPtr) num1;
                continue;
              case 31 /*0x1F*/:
                num1 = (short) 14;
                num2 = (int) (IntPtr) num1;
                continue;
              case 32 /*0x20*/:
                num1 = (short) 38;
                num2 = (int) (IntPtr) num1;
                continue;
              case 34:
                num1 = (short) 5;
                num2 = (int) (IntPtr) num1;
                continue;
              case 36:
                if (addressBytes[3] != (byte) 0)
                {
                  num1 = (short) 26;
                  num2 = (int) (IntPtr) num1;
                  continue;
                }
                goto case 42;
              case 37:
                num1 = (short) 29;
                num2 = (int) (IntPtr) num1;
                continue;
              case 38:
                if (num3 == (byte) 128 /*0x80*/)
                {
                  num1 = (short) 18;
                  num2 = (int) (IntPtr) num1;
                  continue;
                }
                goto case 31 /*0x1F*/;
              case 39:
                if (addressBytes[3] == (byte) 0)
                {
                  num1 = (short) 8;
                  num2 = (int) (IntPtr) num1;
                  continue;
                }
                break;
              case 40:
                if (num3 >= (byte) 192 /*0xC0*/)
                {
                  num1 = (short) 19;
                  num2 = (int) (IntPtr) num1;
                  continue;
                }
                num1 = (short) 45;
                num2 = (int) (IntPtr) num1;
                continue;
              case 41:
                num1 = (short) 0;
                num2 = (int) (IntPtr) num1;
                continue;
              case 42:
                flag = false;
                num1 = (short) 22;
                num2 = (int) (IntPtr) num1;
                continue;
              case 43:
                num1 = (short) 7;
                num2 = (int) (IntPtr) num1;
                continue;
              case 44:
                num1 = (short) 48 /*0x30*/;
                num2 = (int) (IntPtr) num1;
                continue;
              case 45:
                if (num3 >= (byte) 128 /*0x80*/)
                {
                  num1 = (short) 32 /*0x20*/;
                  num2 = (int) (IntPtr) num1;
                  continue;
                }
                num1 = (short) 9;
                num2 = (int) (IntPtr) num1;
                continue;
              case 46:
                if (num3 == (byte) 192 /*0xC0*/)
                {
                  num1 = (short) 13;
                  num2 = (int) (IntPtr) num1;
                  continue;
                }
                goto case 47;
              case 47:
                num1 = (short) 36;
                num2 = (int) (IntPtr) num1;
                continue;
              case 48 /*0x30*/:
                if (addressBytes[1] == byte.MaxValue)
                {
                  num1 = (short) 10;
                  num2 = (int) (IntPtr) num1;
                  continue;
                }
                break;
              default:
                goto label_2;
            }
            num1 = (short) 15;
            num2 = (int) (IntPtr) num1;
          }
      }
    }
    catch (Exception ex)
    {
      flag = false;
      goto label_79;
    }
label_74:
    num1 = (short) 24226;
    int num4 = (int) num1;
    num1 = (short) 24226;
    int num5 = (int) num1;
    switch (num4 == num5 ? 1 : 0)
    {
      case 0:
      case 2:
        break;
      case 1:
        num1 = (short) 1;
        if (num1 == (short) 0)
          ;
        num1 = (short) 0;
        if (num1 == (short) 0)
          ;
        return true;
      default:
        num1 = (short) 0;
        goto case 1;
    }
label_79:
    return flag;
  }

  private void txtbxNumRetries_TextChanged(object A_0, TextChangedEventArgs A_1)
  {
    int A_1_1 = 6;
    int num1 = 0;
    short num2;
    while (true)
    {
      switch (num1)
      {
        case 0:
          num2 = (short) -8165;
          int num3 = (int) num2;
          num2 = (short) -8165;
          int num4 = (int) num2;
          switch (num3 == num4 ? 1 : 0)
          {
            case 0:
            case 2:
              goto label_9;
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
        case 1:
          num2 = (short) 1;
          if (num2 == (short) 0)
            ;
          this.txtbxNumRetries.Text = RptMgrErrorHandler.b("릈", A_1_1);
          num2 = (short) 2;
          num1 = (int) (IntPtr) num2;
          continue;
        case 2:
          goto label_9;
      }
      if (this.txtbxNumRetries.Text == "")
      {
        num2 = (short) 1;
        num1 = (int) (IntPtr) num2;
      }
      else
        break;
    }
label_9:
    num2 = (short) 0;
  }

  private bool a(PNServer A_0, ref string A_1)
  {
    int A_1_1 = 1;
    int num1 = 0;
    switch (num1)
    {
      default:
        bool flag;
        RawData rawCertData;
        short num2;
        switch (0)
        {
          case 0:
label_3:
            flag = false;
            rawCertData = this.i.GetRawCertData(A_0.PNSName);
            num2 = (short) 9;
            num1 = (int) (IntPtr) num2;
            goto default;
          default:
            while (true)
            {
              X509Certificate2 x509Certificate2_1;
              DateTime notAfter;
              X509Certificate2 x509Certificate2_2;
              TimeSpan timeSpan1;
              TimeSpan timeSpan2;
              switch (num1)
              {
                case 0:
                  if (timeSpan1.Days < 31 /*0x1F*/)
                  {
                    num2 = (short) 2;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 4;
                case 1:
                  if (timeSpan2.Days < 31 /*0x1F*/)
                  {
                    num2 = (short) 8;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_29;
                case 2:
                  num2 = (short) 13686;
                  int num3 = (int) num2;
                  num2 = (short) 13686;
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
                      A_1 = A_1 + AcpStringExtensions.AcpStringFormat(AppResources.The_following_ARS_Data_records_have_CA_certificates_that_are_about_to_expire, new object[1]
                      {
                        (object) A_0.PNSName
                      }) + RptMgrErrorHandler.b("躃", A_1_1);
                      num2 = (short) 11;
                      num1 = (int) (IntPtr) num2;
                      continue;
                  }
                  break;
                case 3:
                  goto label_26;
                case 4:
                case 11:
                  notAfter = x509Certificate2_1.NotAfter;
                  num2 = (short) 7;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 5:
                  flag = true;
                  A_1 = A_1 + AcpStringExtensions.AcpStringFormat(AppResources.The_following_ARS_Data_records_have_CA_certificates_that_have_expired, new object[1]
                  {
                    (object) A_0.PNSName
                  }) + RptMgrErrorHandler.b("躃", A_1_1);
                  num2 = (short) 4;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 6:
                  if (notAfter.CompareTo(DateTime.Today) > 0)
                  {
                    notAfter = x509Certificate2_2.NotAfter;
                    timeSpan1 = notAfter.Subtract(DateTime.Today);
                    num2 = (short) 0;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  break;
                case 7:
                  if (notAfter.CompareTo(DateTime.Today) <= 0)
                  {
                    num2 = (short) 10;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  notAfter = x509Certificate2_1.NotAfter;
                  timeSpan2 = notAfter.Subtract(DateTime.Today);
                  num2 = (short) 1;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 8:
                  num2 = (short) 0;
                  A_1 = A_1 + AcpStringExtensions.AcpStringFormat(AppResources.The_following_ARS_Data_records_have_Client_certificates_that_are_about_to_expire, new object[1]
                  {
                    (object) A_0.PNSName
                  }) + RptMgrErrorHandler.b("躃", A_1_1);
                  num2 = (short) 14;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 9:
                  if (rawCertData == null)
                  {
                    num2 = (short) 3;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  x509Certificate2_2 = CertificateLoader.LoadCertificate(Convert.FromBase64String(rawCertData.mRawCACert));
                  num2 = (short) 1;
                  if (num2 == (short) 0)
                    ;
                  num2 = (short) 12;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 10:
                  flag = true;
                  A_1 = A_1 + AcpStringExtensions.AcpStringFormat(AppResources.The_following_ARS_Data_records_have_Client_certificates_that_have_expired, new object[1]
                  {
                    (object) A_0.PNSName
                  }) + RptMgrErrorHandler.b("躃", A_1_1);
                  num2 = (short) 13;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 12:
                  try
                  {
                    x509Certificate2_1 = CertificateLoader.LoadPfxCertificate(Convert.FromBase64String(rawCertData.mRawCliCert), rawCertData.mPassPhrase);
                  }
                  catch
                  {
                    x509Certificate2_1 = CertificateLoader.LoadCertificate(Convert.FromBase64String(rawCertData.mRawCliCert));
                  }
                  notAfter = x509Certificate2_2.NotAfter;
                  num1 = 6;
                  continue;
                case 13:
                case 14:
                  goto label_29;
                default:
                  goto label_3;
              }
              num2 = (short) 5;
              num1 = (int) (IntPtr) num2;
            }
label_26:
            return flag;
label_29:
            return flag;
        }
    }
  }

  private void autoRegServer_SelectionChanged(object A_0, SelectionChangedEventArgs A_1)
  {
    short num1 = 0;
    num1 = (short) 1;
    if (num1 == (short) 0)
      ;
    num1 = (short) 32486;
    int num2 = (int) num1;
    num1 = (short) 32486;
    int num3 = (int) num1;
    switch (num2 == num3)
    {
      case true:
        num1 = (short) 0;
        if (num1 == (short) 0)
          ;
        this.a();
        break;
      default:
        goto case 1;
    }
  }

  private void a()
  {
    int num1 = 0;
    while (true)
    {
      short num2;
      switch (num1)
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
label_5:
          num2 = (short) 1;
          if (num2 == (short) 0)
            ;
          this.f = ((PNServer) this.autoRegServer.SelectedItem).PNSName;
          this.g = ((PNServer) this.autoRegServer.SelectedItem).PNServerIP.ToString();
          num2 = (short) 0;
          num2 = (short) -5884;
          int num3 = (int) num2;
          num2 = (short) -5884;
          int num4 = (int) num2;
          switch (num3 == num4 ? 1 : 0)
          {
            case 0:
            case 2:
              goto label_5;
            default:
              num2 = (short) 0;
              if (num2 == (short) 0)
                ;
              num2 = (short) 4;
              num1 = (int) (IntPtr) num2;
              continue;
          }
        case 3:
          goto label_8;
        case 4:
          if (!((PNServer) this.autoRegServer.SelectedItem).SecureConn)
          {
            this.txtboxConnectionType.Text = AppResources.Clear_Id;
            num2 = (short) 1;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          num2 = (short) 3;
          num1 = (int) (IntPtr) num2;
          continue;
      }
      if (this.j.Count > 0)
      {
        num2 = (short) 2;
        num1 = (int) (IntPtr) num2;
      }
      else
        goto label_14;
    }
label_7:
    return;
label_14:
    return;
label_8:
    this.txtboxConnectionType.Text = AppResources.Secure_Id;
  }

  private string a(IPAddress A_0)
  {
    short num1 = -23006;
    int num2 = (int) num1;
    num1 = (short) -23006;
    int num3 = (int) num1;
    short num4;
    string empty;
    switch (num2 == num3 ? 1 : 0)
    {
      case 0:
      case 2:
        return empty;
      case 1:
        num4 = (short) 1;
        if (num4 == (short) 0)
          ;
        num4 = (short) 0;
        if (num4 == (short) 0)
          ;
        empty = string.Empty;
        try
        {
          empty = A_0.ToString();
          goto case 0;
        }
        catch (Exception ex)
        {
          goto case 0;
        }
      default:
        num4 = (short) 0;
        goto case 1;
    }
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "5.0.10.0")]
  public void InitializeComponent()
  {
    int A_1 = 10;
    short num1 = -8968;
    int num2 = (int) num1;
    num1 = (short) -8968;
    int num3 = (int) num1;
    switch (num2 == num3 ? 1 : 0)
    {
      case 0:
        break;
      case 2:
        break;
      default:
        short num4 = 0;
        num4 = (short) 0;
        if (num4 == (short) 0)
          ;
        num4 = (short) 1;
        if (num4 == (short) 0)
          ;
        if (this.o)
          break;
        this.o = true;
        System.Windows.Application.LoadComponent((object) this, new Uri(RptMgrErrorHandler.b("ꊌ\uDC8E\uE190\uF692\uF694ﺖ\uF898\uF79A\uDB9C爵삠힢키햦첨\uD8AA隬첮\uDEB0\uDEB2어\uD8B6ힸ\uDEBA펼쮾\uEEC0돂\uAAC4럆\uFBC8ﻊ꿌껎ꗐ냒뷔\uA7D6ꯘ듚뫜귞胠転裤苦鯨쓪鷬胮臰쇲샴闶飸迺黼韾焀焂樄怆笈樊怌戎琐愒昔琖焘縚礜樞䴠䘢圤द儨䨪䀬䌮", A_1), UriKind.Relative));
        break;
    }
  }

  [EditorBrowsable(EditorBrowsableState.Never)]
  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "5.0.10.0")]
  void IComponentConnector.Connect(int connectionId, object target)
  {
    int num1 = 0;
    while (true)
    {
      switch (num1)
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
          num1 = 2;
          continue;
        case 2:
          goto label_36;
      }
      switch (connectionId)
      {
        case 1:
          goto label_33;
        case 2:
          goto label_30;
        case 3:
          goto label_9;
        case 4:
          goto label_19;
        case 5:
          goto label_7;
        case 6:
          goto label_13;
        case 7:
          goto label_20;
        case 8:
          goto label_21;
        case 9:
          goto label_29;
        case 10:
          goto label_17;
        case 11:
          goto label_26;
        case 12:
          goto label_27;
        case 13:
          goto label_32;
        case 14:
          goto label_12;
        case 15:
          goto label_6;
        case 16 /*0x10*/:
          goto label_34;
        case 17:
          goto label_28;
        case 18:
          goto label_10;
        case 19:
          goto label_5;
        case 20:
          goto label_25;
        case 21:
          goto label_35;
        case 22:
          goto label_22;
        case 23:
          goto label_8;
        case 24:
          goto label_14;
        case 25:
          goto label_11;
        case 26:
          goto label_31;
        case 27:
          goto label_16;
        default:
          num1 = 1;
          continue;
      }
    }
label_5:
    this.btnAddAll = (System.Windows.Controls.Button) target;
    this.btnAddAll.Click += new RoutedEventHandler(this.btnAddAll_Click);
    return;
label_6:
    this.lbSelectedRadios = (System.Windows.Controls.Label) target;
    return;
label_7:
    this.lbRadioListFilePath = (System.Windows.Controls.Label) target;
    return;
label_8:
    this.txtbxNumRetries = (System.Windows.Controls.ComboBox) target;
    return;
label_9:
    this.lbDateTime = (System.Windows.Controls.Label) target;
    return;
label_10:
    this.btnAdd = (System.Windows.Controls.Button) target;
    this.btnAdd.Click += new RoutedEventHandler(this.btnAdd_Click);
    return;
label_11:
    this.btnStart = (System.Windows.Controls.Button) target;
    this.btnStart.Click += new RoutedEventHandler(this.btnStart_Click);
    return;
label_12:
    this.lbAvailableRadios = (System.Windows.Controls.Label) target;
    return;
label_13:
    this.txtboxRadioListFilePath = (System.Windows.Controls.TextBox) target;
    this.txtboxRadioListFilePath.LostFocus += new RoutedEventHandler(this.txtboxRadioListFilePath_SelectionChanged);
    return;
label_14:
    short num2 = 0;
    num2 = (short) 1;
    if (num2 == (short) 0)
      ;
    this.chkboxWriteProtect = (System.Windows.Controls.CheckBox) target;
    return;
label_16:
    this.btnHelp = (System.Windows.Controls.Button) target;
    this.btnHelp.Click += new RoutedEventHandler(this.btnSchedulerHelp_Click);
    return;
label_17:
    this.lbArsServerIpAddress = (System.Windows.Controls.Label) target;
    return;
label_19:
    this.dtSchedulerDateTime = (DateTimeInput) target;
    return;
label_20:
    this.btnRadioListFilePathBrowse = (System.Windows.Controls.Button) target;
    this.btnRadioListFilePathBrowse.Click += new RoutedEventHandler(this.btnRadioListFilePathBrowse_Click);
    return;
label_21:
    this.groupBoxARS = (System.Windows.Controls.GroupBox) target;
    return;
label_22:
    short num3 = -23041;
    int num4 = (int) num3;
    num3 = (short) -23041;
    int num5 = (int) num3;
    switch (num4 == num5 ? 1 : 0)
    {
      case 0:
      case 2:
        goto label_19;
      default:
        num3 = (short) 0;
        if (num3 == (short) 0)
          ;
        this.lbNumRetries = (System.Windows.Controls.Label) target;
        return;
    }
label_25:
    this.btnRemove = (System.Windows.Controls.Button) target;
    this.btnRemove.Click += new RoutedEventHandler(this.btnRemove_Click);
    return;
label_26:
    this.autoRegServer = (System.Windows.Controls.ComboBox) target;
    this.autoRegServer.SelectionChanged += new SelectionChangedEventHandler(this.autoRegServer_SelectionChanged);
    return;
label_27:
    this.lbArsConnectionType = (System.Windows.Controls.Label) target;
    return;
label_28:
    this.dgSelectedRadios = (System.Windows.Controls.DataGrid) target;
    return;
label_29:
    this.chkboxStaticIpAddress = (System.Windows.Controls.CheckBox) target;
    this.chkboxStaticIpAddress.Checked += new RoutedEventHandler(this.EnableArsServer_Checked);
    this.chkboxStaticIpAddress.Unchecked += new RoutedEventHandler(this.EnableArsServer_UnChecked);
    return;
label_30:
    ((CommandBinding) target).Executed += new ExecutedRoutedEventHandler(this.btnSchedulerHelp_Click);
    ((CommandBinding) target).CanExecute += new CanExecuteRoutedEventHandler(this.F1HelpCommandCanExcute);
    return;
label_31:
    this.btnCancel = (System.Windows.Controls.Button) target;
    this.btnCancel.Click += new RoutedEventHandler(this.btnCancel_Click);
    return;
label_32:
    this.txtboxConnectionType = (System.Windows.Controls.TextBox) target;
    return;
label_33:
    ((Window) target).Closing += new CancelEventHandler(this.SchedulerWindowClosing);
    ((FrameworkElement) target).Loaded += new RoutedEventHandler(this.SchedulerWindow_Loaded);
    return;
label_34:
    this.dgAvailableRadio = (System.Windows.Controls.DataGrid) target;
    return;
label_35:
    this.btnRemoveAll = (System.Windows.Controls.Button) target;
    this.btnRemoveAll.Click += new RoutedEventHandler(this.btnRemoveAll_Click);
    return;
label_36:
    this.o = true;
  }
}
