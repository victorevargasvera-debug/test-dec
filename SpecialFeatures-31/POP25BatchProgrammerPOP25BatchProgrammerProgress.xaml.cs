// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.POP25BatchProgrammer.POP25BatchProgrammerProgress
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using ACPBrowser;
using AcpBusinessLayer;
using AcpCommonLib;
using AcpCommonLib.UndoRedo;
using AcpUI;
using AcpUI.Common;
using AcpUtility;
using CommonResources;
using Motorola.MackinawCPS.CoreFeatures.ConventionalSystem;
using Motorola.MackinawCPS.CoreFeatures.DataProfiles;
using Motorola.MackinawCPS.CoreFeatures.DataWide;
using Motorola.MackinawCPS.CoreFeatures.PackExec;
using Motorola.MackinawCPS.CoreFeatures.RadioInformation;
using Motorola.MackinawCPS.CoreFeatures.RadioWide;
using Motorola.MackinawCPS.CoreFeatures.SecureKMFProfile;
using Motorola.MackinawCPS.CoreFeatures.SecureWide;
using Motorola.MackinawCPS.CoreFeatures.TrunkingSystem;
using SpecialFeatures.AcpReportManagerLib;
using SpecialFeatures.Clone_Configuration.Common;
using SpecialFeatures.Comms;
using SpecialFeatures.Programming;
using SpecialFeatures.Security;
using SSLAdminTool;
using SSLMangrComp.Packets;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Threading;

#nullable disable
namespace SpecialFeatures.POP25BatchProgrammer;

public partial class POP25BatchProgrammerProgress : Window, IComponentConnector
{
  private DispatcherTimer a;
  private bool b;
  private string c = "";
  private string d = "";
  private double e;
  private bool f;
  private bool g;
  public double totItems;
  private int h;
  public const int RADIO_ID_MAX = 16777211;
  private SpecialFeaturesSettings i = new SpecialFeaturesSettings();
  private string j = "";
  private bool k;
  private bool l;
  private int m;
  private int n;
  private int o;
  private int p;
  private ASKProgrammingHistoryInnerRecset q;
  private bool r;
  private PNServer s = new PNServer();
  private byte[] t;
  private ObservableCollection<POP25RadioInfo> u = new ObservableCollection<POP25RadioInfo>();
  private ObservableCollection<POP25RadioInfo> v = new ObservableCollection<POP25RadioInfo>();
  private ObservableCollection<POP25RadioInfo> w = new ObservableCollection<POP25RadioInfo>();
  internal POP25BatchProgrammerProgress This;
  internal StackPanel spBatchProgrammingIPAndStart;
  internal System.Windows.Controls.TextBox txtboxArsServer;
  internal AcpTextBox dtProgressDateTime;
  internal StackPanel spBackGround;
  internal System.Windows.Controls.DataGrid dgBatchProgrammingProgress;
  internal System.Windows.Controls.TextBox ProgText;
  internal System.Windows.Controls.ProgressBar pbBatchProgrammingProgress;
  internal System.Windows.Controls.ProgressBar pbOverallBatchProgrammingProgress;
  internal System.Windows.Controls.TextBox txtbxRetryCount;
  internal Expander batProgressResultExpander;
  internal System.Windows.Controls.TextBox txtBoxProgressStatus;
  internal System.Windows.Controls.Button btnSaveToFile;
  internal StackPanel spBatchProgrammingRadioProgress;
  internal System.Windows.Controls.Button btnBatchProgrammingClose;
  internal System.Windows.Controls.Button btnBatchProgrammingCancel;
  internal System.Windows.Controls.Button btnBatchProgrammingHelp;
  private bool ab;

  public ObservableCollection<POP25RadioInfo> DataSource
  {
    get
    {
      short num1 = -15002;
      int num2 = (int) num1;
      num1 = (short) -15002;
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
          return this.u;
        default:
          num4 = (short) 0;
          goto case 1;
      }
    }
  }

  public POP25BatchProgrammerProgress()
  {
    this.InitializeComponent();
    Utility.SetDirection((FrameworkElement) this);
    this.DataContext = (object) this;
    this.CancelBatchProgramming = false;
    this.BatchProgrammingInProgress = false;
    this.BatchProgrammingComplete = false;
    this.g = true;
    this.t = new byte[0];
  }

  internal double PbStatusval
  {
    set
    {
      short num1 = 23807;
      int num2 = (int) num1;
      num1 = (short) 23807;
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
          this.e = value;
          break;
        default:
          num4 = (short) 0;
          goto case 1;
      }
    }
    get
    {
      short num1 = -10968;
      int num2 = (int) num1;
      num1 = (short) -10968;
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
          return this.e;
        default:
          goto case 1;
      }
    }
  }

  internal bool ARSServerEnabled
  {
    set
    {
      short num1 = 1;
      if (num1 == (short) 0)
        ;
      num1 = (short) 8767;
      int num2 = (int) num1;
      num1 = (short) 8767;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          num1 = (short) 0;
          this.b = value;
          break;
        default:
          goto case 1;
      }
    }
    get
    {
      short num1 = -30267;
      int num2 = (int) num1;
      num1 = (short) -30267;
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
  }

  internal string CurrentRadioIpAddress
  {
    set
    {
      short num1 = 30225;
      int num2 = (int) num1;
      num1 = (short) 30225;
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
    get
    {
      short num1 = 1;
      if (num1 == (short) 0)
        ;
      num1 = (short) 14613;
      int num2 = (int) num1;
      num1 = (short) 14613;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          num1 = (short) 0;
          return this.c;
        default:
          goto case 1;
      }
    }
  }

  internal string CurrentRadioID
  {
    set
    {
      short num1 = 1;
      if (num1 == (short) 0)
        ;
      num1 = (short) -25625;
      int num2 = (int) num1;
      num1 = (short) -25625;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          num1 = (short) 0;
          this.d = value;
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
      num1 = (short) 16037;
      int num2 = (int) num1;
      num1 = (short) 16037;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          num1 = (short) 0;
          return this.d;
        default:
          goto case 1;
      }
    }
  }

  public string ARSIpAddress
  {
    set
    {
      short num1 = 3210;
      int num2 = (int) num1;
      num1 = (short) 3210;
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
          this.x = value;
          break;
        default:
          goto case 1;
      }
    }
    get
    {
      short num1 = -12241;
      int num2 = (int) num1;
      num1 = (short) -12241;
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
          return this.x;
        default:
          goto case 1;
      }
    }
  }

  internal bool WriteProtectWriteProtectedRad
  {
    get
    {
      short num1 = 27183;
      int num2 = (int) num1;
      num1 = (short) 27183;
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
      short num1 = 1;
      if (num1 == (short) 0)
        ;
      num1 = (short) -29456;
      int num2 = (int) num1;
      num1 = (short) -29456;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          num1 = (short) 0;
          this.f = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  public int RetryCount
  {
    get
    {
      short num1 = -19329;
      int num2 = (int) num1;
      num1 = (short) -19329;
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
          int result = 0;
          int.TryParse(this.txtbxRetryCount.Text, out result);
          return result;
        default:
          goto case 1;
      }
    }
    set
    {
      int A_1 = 3;
      try
      {
        short num1 = -32763;
        int num2 = (int) num1;
        num1 = (short) -32763;
        int num3 = (int) num1;
        switch (num2 == num3)
        {
          case true:
            num1 = (short) 0;
            if (num1 == (short) 0)
              ;
            this.txtbxRetryCount.Text = Convert.ToString(value);
            break;
          default:
            goto case 1;
        }
      }
      catch (Exception ex)
      {
        this.txtbxRetryCount.Text = RptMgrErrorHandler.b("뚅", A_1);
      }
      if (false)
        ;
    }
  }

  internal int CurRetry
  {
    get
    {
      short num1 = -24162;
      int num2 = (int) num1;
      num1 = (short) -24162;
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
          return this.h;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = 1;
      if (num1 == (short) 0)
        ;
      num1 = (short) 18011;
      int num2 = (int) num1;
      num1 = (short) 18011;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          num1 = (short) 0;
          this.h = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  internal bool CancelBatchProgramming
  {
    set
    {
      short num1 = -10124;
      int num2 = (int) num1;
      num1 = (short) -10124;
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
          this.y = value;
          break;
        default:
          goto case 1;
      }
    }
    get
    {
      short num1 = 2915;
      int num2 = (int) num1;
      num1 = (short) 2915;
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
          return this.y;
        default:
          goto case 1;
      }
    }
  }

  internal bool BatchProgrammingInProgress
  {
    set
    {
      short num1 = 18825;
      int num2 = (int) num1;
      num1 = (short) 18825;
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
          this.z = value;
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
      num1 = (short) 17417;
      int num2 = (int) num1;
      num1 = (short) 17417;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          num1 = (short) 0;
          return this.z;
        default:
          goto case 1;
      }
    }
  }

  internal bool BatchProgrammingComplete
  {
    set
    {
      short num1 = 1;
      if (num1 == (short) 0)
        ;
      num1 = (short) -10522;
      int num2 = (int) num1;
      num1 = (short) -10522;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          num1 = (short) 0;
          this.aa = value;
          break;
        default:
          goto case 1;
      }
    }
    get
    {
      short num1 = 24333;
      int num2 = (int) num1;
      num1 = (short) 24333;
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
          return this.aa;
        default:
          goto case 1;
      }
    }
  }

  internal PNServer TargetARS
  {
    get
    {
      short num1 = 1;
      if (num1 == (short) 0)
        ;
      num1 = (short) 18297;
      int num2 = (int) num1;
      num1 = (short) 18297;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          num1 = (short) 0;
          return this.s;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = -3849;
      int num2 = (int) num1;
      num1 = (short) -3849;
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
          this.s = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  internal byte[] DhBuff
  {
    get
    {
      short num1 = -8576;
      int num2 = (int) num1;
      num1 = (short) -8576;
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
          return this.t;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = 1;
      if (num1 == (short) 0)
        ;
      num1 = (short) 26652;
      int num2 = (int) num1;
      num1 = (short) 26652;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          num1 = (short) 0;
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          this.t = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  internal void OnLoaded(object sender, RoutedEventArgs e)
  {
    int num1;
    short num2;
    switch (0)
    {
      case 0:
label_2:
        num2 = (short) 0;
        this.a = new DispatcherTimer();
        this.a.Interval = TimeSpan.FromMilliseconds(5000.0);
        this.a.Tick += new EventHandler(this.batchCloneTimer_Tick);
        this.a.Start();
        this.pbBatchProgrammingProgress.Value = 0.0;
        this.pbOverallBatchProgrammingProgress.Value = 0.0;
        this.btnBatchProgrammingClose.IsEnabled = false;
        this.btnSaveToFile.IsEnabled = false;
        num2 = (short) 1;
        num1 = (int) (IntPtr) num2;
        goto default;
      default:
        IEnumerator enumerator;
        while (true)
        {
          switch (num1)
          {
            case 0:
label_33:
              enumerator = ((IEnumerable) this.dgBatchProgrammingProgress.Items).GetEnumerator();
              num2 = (short) 3;
              num1 = (int) (IntPtr) num2;
              continue;
            case 1:
              num2 = (short) 13977;
              int num3 = (int) num2;
              num2 = (short) 13977;
              int num4 = (int) num2;
              switch (num3 == num4 ? 1 : 0)
              {
                case 0:
                case 2:
                  continue;
                default:
                  num2 = (short) 0;
                  if (num2 == (short) 0)
                    ;
                  if (this.TargetARS != null)
                  {
                    num2 = (short) 1;
                    if (num2 == (short) 0)
                      ;
                    num2 = (short) 2;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_33;
              }
            case 2:
              this.txtboxArsServer.Text = this.TargetARS.PNSName;
              this.ARSIpAddress = this.TargetARS.PNServerIP.ToString();
              num2 = (short) 0;
              num1 = (int) (IntPtr) num2;
              continue;
            case 3:
              goto label_8;
            default:
              goto label_2;
          }
        }
label_8:
        try
        {
          num2 = (short) 9;
          num1 = (int) (IntPtr) num2;
          while (true)
          {
            POP25RadioInfo current;
            switch (num1)
            {
              case 1:
                if (!this.ARSServerEnabled)
                {
                  num2 = (short) 6;
                  num1 = (int) (IntPtr) num2;
                  continue;
                }
                goto default;
              case 2:
                current.Radio_IP_ARS_Check = false;
                num2 = (short) 8;
                num1 = (int) (IntPtr) num2;
                continue;
              case 3:
                num2 = (short) 10;
                num1 = (int) (IntPtr) num2;
                continue;
              case 4:
                if (this.ARSServerEnabled)
                {
                  num2 = (short) 7;
                  num1 = (int) (IntPtr) num2;
                  continue;
                }
                break;
              case 5:
                if (enumerator.MoveNext())
                {
                  current = (POP25RadioInfo) enumerator.Current;
                  num2 = (short) 4;
                  num1 = (int) (IntPtr) num2;
                  continue;
                }
                num2 = (short) 3;
                num1 = (int) (IntPtr) num2;
                continue;
              case 6:
                current.Radio_ID_Check = false;
                num2 = (short) 0;
                num1 = (int) (IntPtr) num2;
                continue;
              case 7:
                num2 = (short) 11;
                num1 = (int) (IntPtr) num2;
                continue;
              case 9:
                switch (0)
                {
                  case 0:
                    goto label_15;
                  default:
                    continue;
                }
              case 10:
                goto label_35;
              case 11:
                if (current.Radio_ID != "")
                {
                  num2 = (short) 2;
                  num1 = (int) (IntPtr) num2;
                  continue;
                }
                break;
              default:
label_15:
                num2 = (short) 5;
                num1 = (int) (IntPtr) num2;
                continue;
            }
            num2 = (short) 1;
            num1 = (int) (IntPtr) num2;
          }
        }
        finally
        {
          IDisposable disposable;
          short num5;
          switch (0)
          {
            case 0:
label_28:
              disposable = enumerator as IDisposable;
              num5 = (short) 0;
              num1 = (int) (IntPtr) num5;
              goto default;
            default:
              while (true)
              {
                switch (num1)
                {
                  case 0:
                    if (disposable != null)
                    {
                      num5 = (short) 2;
                      num1 = (int) (IntPtr) num5;
                      continue;
                    }
                    goto label_32;
                  case 1:
                    goto label_32;
                  case 2:
                    disposable.Dispose();
                    num5 = (short) 1;
                    num1 = (int) (IntPtr) num5;
                    continue;
                  default:
                    goto label_28;
                }
              }
label_32:;
          }
        }
label_35:
        this.r = RadioAccessValidator.CacheCodeplugSecurityFields(out this.k, out this.l, out this.m, out this.n, out this.o, out this.q, out this.p);
        break;
    }
  }

  internal void OnUnLoaded(object sender, RoutedEventArgs e)
  {
    int num1 = 1;
    short num2;
    IEnumerator enumerator;
    while (true)
    {
      switch (num1)
      {
        case 0:
          num2 = (short) 1;
          if (num2 == (short) 0)
            ;
          num2 = (short) 0;
          goto label_20;
        case 1:
          switch (0)
          {
            case 0:
              goto label_3;
            default:
              continue;
          }
        case 2:
          RadioAccessValidator.RestoreCachedCodeplugSecurityFields(this.k, this.l, this.m, this.n, this.o, this.q, this.p);
          num2 = (short) 0;
          num1 = (int) (IntPtr) num2;
          continue;
        case 3:
          num2 = (short) -17963;
          int num3 = (int) num2;
          num2 = (short) -17963;
          int num4 = (int) num2;
          switch (num3 == num4 ? 1 : 0)
          {
            case 0:
            case 2:
              break;
            default:
              goto label_22;
          }
          break;
        default:
label_3:
          if (!this.r)
            goto label_20;
          break;
      }
      num2 = (short) 2;
      num1 = (int) (IntPtr) num2;
      continue;
label_20:
      enumerator = ((IEnumerable) this.dgBatchProgrammingProgress.Items).GetEnumerator();
      num2 = (short) 3;
      num1 = (int) (IntPtr) num2;
    }
label_22:
    num2 = (short) 0;
    if (num2 == (short) 0)
      ;
    try
    {
      num2 = (short) 2;
      num1 = (int) (IntPtr) num2;
      while (true)
      {
        switch (num1)
        {
          case 0:
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
            goto label_26;
          case 4:
            if (enumerator.MoveNext())
            {
              POP25RadioInfo current = (POP25RadioInfo) enumerator.Current;
              current.Radio_IP_ARS_Check = true;
              current.Radio_ID_Check = true;
              num2 = (short) 1;
              num1 = (int) (IntPtr) num2;
              continue;
            }
            num2 = (short) 0;
            num1 = (int) (IntPtr) num2;
            continue;
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
label_15:
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
                  num1 = 2;
                  continue;
                }
                goto label_19;
              case 1:
                goto label_19;
              case 2:
                disposable.Dispose();
                num1 = 1;
                continue;
              default:
                goto label_15;
            }
          }
label_19:;
      }
    }
label_26:
    this.v.Clear();
    this.w.Clear();
    this.dgBatchProgrammingProgress.Items.Clear();
  }

  private void batchCloneTimer_Tick(object A_0, EventArgs A_1)
  {
    switch (0)
    {
      default:
        short num1 = 4;
        int num2 = (int) (IntPtr) num1;
        IEnumerator enumerator;
        while (true)
        {
          switch (num2)
          {
            case 0:
              goto label_28;
            case 1:
              num1 = (short) 0;
              num1 = (short) -5222;
              int num3 = (int) num1;
              num1 = (short) -5222;
              int num4 = (int) num1;
              switch (num3 == num4 ? 1 : 0)
              {
                case 0:
                case 2:
                  goto label_25;
                default:
                  num1 = (short) 0;
                  if (num1 == (short) 0)
                    ;
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
                            num1 = (short) 4;
                            num2 = (int) (IntPtr) num1;
                            continue;
                          }
                          this.w.Add((POP25RadioInfo) enumerator.Current);
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
                          goto label_6;
                        case 4:
                          num1 = (short) 3;
                          num2 = (int) (IntPtr) num1;
                          continue;
                      }
                      num1 = (short) 1;
                      num2 = (int) (IntPtr) num1;
                    }
                  }
                  finally
                  {
                    IDisposable disposable;
                    short num5;
                    switch (0)
                    {
                      case 0:
label_19:
                        disposable = enumerator as IDisposable;
                        num5 = (short) 0;
                        num2 = (int) (IntPtr) num5;
                        goto default;
                      default:
                        while (true)
                        {
                          switch (num2)
                          {
                            case 0:
                              if (disposable != null)
                              {
                                num5 = (short) 2;
                                num2 = (int) (IntPtr) num5;
                                continue;
                              }
                              goto label_23;
                            case 1:
                              goto label_23;
                            case 2:
                              disposable.Dispose();
                              num5 = (short) 1;
                              num2 = (int) (IntPtr) num5;
                              continue;
                            default:
                              goto label_19;
                          }
                        }
label_23:;
                    }
                  }
label_6:
                  num1 = (short) 3;
                  num2 = (int) (IntPtr) num1;
                  continue;
              }
            case 2:
              this.a.Stop();
              num1 = (short) 6;
              num2 = (int) (IntPtr) num1;
              continue;
            case 3:
              if (this.w.Count > 0)
              {
                num1 = (short) 5;
                num2 = (int) (IntPtr) num1;
                continue;
              }
              goto label_31;
            case 4:
              switch (0)
              {
                case 0:
                  goto label_4;
                default:
                  continue;
              }
            case 5:
label_25:
              num1 = (short) 1;
              if (num1 == (short) 0)
                ;
              this.totItems = (double) this.dgBatchProgrammingProgress.Items.Count;
              POP25RadioInfo radio = this.w[0];
              this.dgBatchProgrammingProgress.SelectedItem = this.dgBatchProgrammingProgress.Items[radio.IndexInList];
              this.dgBatchProgrammingProgress.ScrollIntoView(this.dgBatchProgrammingProgress.Items[radio.IndexInList]);
              radio.Status = AppResources.In_Progress;
              this.CloneRadioUsingRadioIdOrRadioIp(radio);
              num1 = (short) 0;
              num2 = (int) (IntPtr) num1;
              continue;
            case 6:
              enumerator = ((IEnumerable) this.dgBatchProgrammingProgress.Items).GetEnumerator();
              num1 = (short) 1;
              num2 = (int) (IntPtr) num1;
              continue;
            default:
label_4:
              if (this.a != null)
              {
                num1 = (short) 2;
                num2 = (int) (IntPtr) num1;
                continue;
              }
              goto case 6;
          }
        }
label_28:
        break;
label_31:
        break;
    }
  }

  private bool a(POP25RadioInfo A_0)
  {
    int A_1 = 13;
    int num1 = 0;
    switch (num1)
    {
      default:
        bool flag1;
        bool flag2;
        string str1;
        string str2;
        int result1;
        short num2;
        switch (0)
        {
          case 0:
label_3:
            flag1 = false;
            flag2 = true;
            str1 = (string) null;
            str2 = (string) null;
            result1 = 0;
            num2 = (short) 27;
            num1 = (int) (IntPtr) num2;
            goto default;
          default:
            while (true)
            {
              ARSGetPOP25BatchIPAddress p25BatchIpAddress;
              SubscriptionType mode;
              int result2;
              switch (num1)
              {
                case 0:
                  num2 = (short) 0;
                  num2 = (short) 6;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 1:
                  if (int.TryParse(this.i.OTAP_CPS_SESSION_INACTIVITY_TIMER, out result2))
                  {
                    num2 = (short) 0;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_29;
                case 2:
                case 9:
                case 23:
                case 25:
                  num2 = (short) 10;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 3:
                  if (p25BatchIpAddress.ARSResult.DevicePrescence == OTAP_SUBSCRIBER_NETWORK_PRESCENCE.OTAP_RADIO_STATUS_TIMEOUT)
                  {
                    num2 = (short) 19;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  str1 = AcpStringExtensions.AcpStringFormat(AppResources.Radio_CurrentRadioID_CurrentRadioIpAddress_Radio_presence_is_unknown_on_the_ARS, new object[2]
                  {
                    (object) this.CurrentRadioID,
                    (object) this.CurrentRadioIpAddress
                  });
                  A_0.Status = AppResources.FAILED_All_UpperCase_Id;
                  num2 = (short) 25;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 4:
                  if (flag2)
                  {
                    num2 = (short) 20;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_49;
                case 5:
                  str1 = AcpStringExtensions.AcpStringFormat(AppResources.Radio_CurrentRadioID_CurrentRadioIpAddress_Radio_presence_is_absent_on_the_ARS, new object[2]
                  {
                    (object) this.CurrentRadioID,
                    (object) this.CurrentRadioIpAddress
                  });
                  A_0.Status = AppResources.FAILED_All_UpperCase_Id;
                  num2 = (short) 2;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 6:
                  if (result2 == 0)
                  {
                    num2 = (short) 24;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_29;
                case 7:
                  if (p25BatchIpAddress.ARSResult.DevicePrescence == OTAP_SUBSCRIBER_NETWORK_PRESCENCE.OTAP_RADIO_STATUS_ABSENT)
                  {
                    num2 = (short) 5;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  break;
                case 8:
                  if (p25BatchIpAddress.ARSResult.DevicePrescence == OTAP_SUBSCRIBER_NETWORK_PRESCENCE.OTAP_RADIO_STATUS_PRESENT)
                  {
                    num2 = (short) 16 /*0x10*/;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 7;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 10:
                  if (p25BatchIpAddress.ARSResult.NetworkError != null)
                  {
                    num2 = (short) 29;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_49;
                case 11:
                case 26:
                  goto label_49;
                case 12:
                  if (result1 > 0)
                  {
                    num2 = (short) 21;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_28;
                case 13:
                  result2 = 8;
                  num2 = (short) 1;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 14:
                  num2 = (short) 12;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 15:
                  try
                  {
                    this.i.OTAP_CPS_SESSION_INACTIVITY_TIMER = Convert.ToString(result2);
                    this.i.Save();
                    goto label_29;
                  }
                  catch
                  {
                    goto label_29;
                  }
                case 16 /*0x10*/:
                  this.CurrentRadioIpAddress = p25BatchIpAddress.ARSResult.DeviceIPAddress;
                  this.CurrentRadioID = A_0.Radio_ID;
                  flag1 = true;
                  num2 = (short) 9;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 17:
                  mode = (SubscriptionType) 0;
                  num2 = (short) 22;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 18:
                  if (result1 <= 16777211)
                  {
                    num2 = (short) 13;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_28;
                case 19:
                  str1 = AcpStringExtensions.AcpStringFormat(AppResources.Radio_CurrentRadioID_CurrentRadioIpAddress_Radio_look_up_has_timed_out_on_the_ARS, new object[2]
                  {
                    (object) this.CurrentRadioID,
                    (object) this.CurrentRadioIpAddress
                  });
                  A_0.Status = AppResources.FAILED_All_UpperCase_Id;
                  num2 = (short) 23;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 20:
                  p25BatchIpAddress = new ARSGetPOP25BatchIPAddress(this.TargetARS.PNServerIP.ToString(), this.TargetARS.PortNum, this.TargetARS.PortNum, this.TargetARS.CipherSuite, mode, result1, this.TargetARS.SecureConn, this.TargetARS.CACert, this.TargetARS.ClientCert, this.TargetARS.PassWordPhrase, this.DhBuff);
                  p25BatchIpAddress.GetIPAddressFromARS();
                  num2 = (short) 8;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 21:
                  num2 = (short) 1;
                  if (num2 == (short) 0)
                    ;
                  num2 = (short) -19830;
                  int num3 = (int) num2;
                  num2 = (short) -19830;
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
                      num2 = (short) 18;
                      num1 = (int) (IntPtr) num2;
                      continue;
                  }
                  break;
                case 22:
                  num2 = (short) 4;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 24:
                  result2 = 8;
                  num2 = (short) 15;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 27:
                  if (int.TryParse(A_0.Radio_ID, out result1))
                  {
                    num2 = (short) 14;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_28;
                case 28:
                  if (this.TargetARS.SecureConn)
                  {
                    num2 = (short) 17;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 22;
                case 29:
                  str2 = p25BatchIpAddress.ARSResult.NetworkError;
                  num2 = (short) 11;
                  num1 = (int) (IntPtr) num2;
                  continue;
                default:
                  goto label_3;
              }
              num2 = (short) 3;
              num1 = (int) (IntPtr) num2;
              continue;
label_28:
              str1 = AppResources.Radio_Colon + RptMgrErrorHandler.b("낏", A_1) + this.CurrentRadioID + RptMgrErrorHandler.b("뾏", A_1) + this.CurrentRadioIpAddress + RptMgrErrorHandler.b("낏늑릓뮕뢗몙", A_1) + AppResources.Invalid_Radio_ID;
              A_0.Status = AppResources.FAILED_All_UpperCase_Id;
              num2 = (short) 26;
              num1 = (int) (IntPtr) num2;
              continue;
label_29:
              mode = (SubscriptionType) 2;
              num2 = (short) 28;
              num1 = (int) (IntPtr) num2;
            }
label_49:
            this.Dispatcher.BeginInvoke((Delegate) new POP25BatchProgrammerProgress.RadioPresent(this.ProcessRadio), (object) A_0, (object) flag1, (object) str1, (object) str2);
            return flag1;
        }
    }
  }

  private void btnBack_Click(object A_0, RoutedEventArgs A_1)
  {
    short num1 = -10685;
    int num2 = (int) num1;
    num1 = (short) -10685;
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
          break;
        break;
      default:
        goto case 1;
    }
  }

  private void btnCancel_Click(object A_0, RoutedEventArgs A_1)
  {
    int num1 = 1;
    short num2;
    while (true)
    {
      switch (num1)
      {
        case 0:
          goto label_12;
        case 1:
          switch (0)
          {
            case 0:
              goto label_3;
            default:
              continue;
          }
        case 2:
          num2 = (short) 3;
          num1 = (int) (IntPtr) num2;
          continue;
        case 3:
          if (System.Windows.MessageBox.Show(AppResources.Warning_Batch_Programming_Is_Currently_Running_Do_You_Want_Cancel, AppResources.Cancel_Batch_Programming, MessageBoxButton.YesNo, MessageBoxImage.Exclamation) != MessageBoxResult.Yes)
            goto label_11;
          break;
        default:
label_3:
          num2 = (short) -28419;
          int num3 = (int) num2;
          num2 = (short) -28419;
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
              if (this.BatchProgrammingInProgress)
              {
                num2 = (short) 2;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_13;
          }
          break;
      }
      num2 = (short) 0;
      num1 = (int) (IntPtr) num2;
    }
label_13:
    return;
label_11:
    return;
label_12:
    num2 = (short) 0;
    this.CancelBatchProgramming = true;
    this.btnBatchProgrammingCancel.IsEnabled = false;
    int num5 = (int) System.Windows.MessageBox.Show(AppResources.Batch_Programming_Will_Cancelled_After_Current_Radio_Programmed, AppResources.Warning_Id, MessageBoxButton.OK, MessageBoxImage.Exclamation);
  }

  private void btnClose_Click(object A_0, RoutedEventArgs A_1)
  {
    short num1 = 10274;
    int num2 = (int) num1;
    num1 = (short) 10274;
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

  private void ProgressWindowClosing(object A_0, CancelEventArgs A_1)
  {
    short num1 = 1;
    if (num1 == (short) 0)
      ;
    num1 = (short) 3;
    int num2 = (int) (IntPtr) num1;
    while (true)
    {
      switch (num2)
      {
        case 0:
          num1 = (short) 1;
          num2 = (int) (IntPtr) num1;
          continue;
        case 1:
          if (System.Windows.MessageBox.Show(AppResources.Warning_Batch_Programming_Is_Currently_Running_Do_You_Want_Cancel, AppResources.Cancel_Batch_Programming, MessageBoxButton.YesNo, MessageBoxImage.Exclamation) != MessageBoxResult.Yes)
            goto case 5;
          break;
        case 2:
          goto label_12;
        case 3:
          switch (0)
          {
            case 0:
              goto label_4;
            default:
              continue;
          }
        case 4:
          num1 = (short) -26959;
          int num3 = (int) num1;
          num1 = (short) -26959;
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
              num1 = (short) 0;
              this.CancelBatchProgramming = true;
              this.btnBatchProgrammingCancel.IsEnabled = false;
              int num5 = (int) System.Windows.MessageBox.Show(AppResources.Batch_Programming_Cancelled_After_The_Current_Radio_Programmed, AppResources.Warning_Id, MessageBoxButton.OK, MessageBoxImage.Exclamation);
              num1 = (short) 5;
              num2 = (int) (IntPtr) num1;
              continue;
          }
          break;
        case 5:
          A_1.Cancel = true;
          num1 = (short) 2;
          num2 = (int) (IntPtr) num1;
          continue;
        default:
label_4:
          if (this.BatchProgrammingInProgress)
          {
            num1 = (short) 0;
            num2 = (int) (IntPtr) num1;
            continue;
          }
          goto label_14;
      }
      num1 = (short) 4;
      num2 = (int) (IntPtr) num1;
    }
label_12:
    return;
label_14:;
  }

  private void F1HelpCommandCanExcute(object A_0, CanExecuteRoutedEventArgs A_1)
  {
    short num1 = -15103;
    int num2 = (int) num1;
    num1 = (short) -15103;
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
        A_1.CanExecute = true;
        break;
      default:
        goto case 1;
    }
  }

  private void btnProgressWndHelp_Click(object A_0, RoutedEventArgs A_1)
  {
    int A_1_1 = 15;
    try
    {
      short num1 = -9779;
      int num2 = (int) num1;
      num1 = (short) -9779;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          Utility.CloseHelpWindowIfOpen();
          Utility.DisplayCPSHelpDITA(RptMgrErrorHandler.b("놑\uF093ꖕꪗ\uF899\uF89Bꦝ쎟閡", A_1_1));
          break;
        default:
          goto case 1;
      }
    }
    catch (Exception ex)
    {
    }
    short num = 1;
    if (num == (short) 0)
      ;
    num = (short) 0;
  }

  private void btnSaveAs_Click(object A_0, RoutedEventArgs A_1)
  {
    int A_1_1 = 0;
    int num1;
    SaveFileDialog saveFileDialog;
    short num2;
    switch (0)
    {
      case 0:
label_2:
        saveFileDialog = new SaveFileDialog();
        saveFileDialog.InitialDirectory = RptMgrErrorHandler.b("캂\uEA84\uF386\uE688力\uE28C\uE38E\uF090쾒풔\uE796\uE198\uDD9Aﲜ\uF29E좠쾢\uDCA4\uE4A6令\uF8AA\uF1AC\uECAE\uDEB0\uDEB2\uD8B4\uD8B6ힸ\uE7BAﾼ\uDEBE뗀ꃂ귄鯆", A_1_1);
        saveFileDialog.Filter = AppResources.Batch_Programming_Log_Filter;
        num2 = (short) 15;
        num1 = (int) (IntPtr) num2;
        goto default;
      default:
        string fileName;
        while (true)
        {
          switch (num1)
          {
            case 0:
              goto label_6;
            case 1:
              if (!string.IsNullOrEmpty(fileName))
              {
                num2 = (short) 3;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_47;
            case 2:
              if (System.IO.File.Exists(fileName))
              {
                num2 = (short) 0;
                num2 = (short) 16 /*0x10*/;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_48;
            case 3:
              num2 = (short) 2;
              num1 = (int) (IntPtr) num2;
              continue;
            case 4:
              if (System.Windows.MessageBox.Show(AppResources.File_You_Save_Is_Readonly, AppResources.Error_Saving_The_Log_File, MessageBoxButton.OK, MessageBoxImage.Exclamation) == MessageBoxResult.OK)
              {
                num2 = (short) 14;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_45;
            case 5:
              num2 = (short) 9;
              num1 = (int) (IntPtr) num2;
              continue;
            case 6:
              num2 = (short) 8;
              num1 = (int) (IntPtr) num2;
              continue;
            case 7:
              if (System.IO.File.Exists(fileName))
              {
                num2 = (short) 6;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              break;
            case 8:
              if ((System.IO.File.GetAttributes(fileName) & FileAttributes.Hidden) == FileAttributes.Hidden)
              {
                num2 = (short) 5;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              break;
            case 9:
              if (System.Windows.MessageBox.Show(AppResources.File_You_Save_Is_Hidden, AppResources.Error_Saving_The_Log_File, MessageBoxButton.OK, MessageBoxImage.Exclamation) == MessageBoxResult.OK)
              {
                num2 = (short) 0;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_51;
            case 10:
              num2 = (short) 4;
              num1 = (int) (IntPtr) num2;
              continue;
            case 11:
              if ((System.IO.File.GetAttributes(fileName) & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
              {
                num2 = (short) 10;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_48;
            case 12:
              fileName = saveFileDialog.FileName;
              num2 = (short) 1;
              num1 = (int) (IntPtr) num2;
              continue;
            case 13:
              goto label_13;
            case 14:
              goto label_41;
            case 15:
              if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
              {
                num2 = (short) 1;
                if (num2 == (short) 0)
                  ;
                num2 = (short) 12;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_55;
            case 16 /*0x10*/:
              num2 = (short) 11;
              num1 = (int) (IntPtr) num2;
              continue;
            default:
              goto label_2;
          }
          num2 = (short) 13;
          num1 = (int) (IntPtr) num2;
          continue;
label_48:
          num2 = (short) 7;
          num1 = (int) (IntPtr) num2;
        }
label_55:
        break;
label_6:
        AppInfoManager.StatusMsgReport.RegisterMessage((StatusMsgType) 0, AppResources.File_You_Save_Is_Hidden);
        break;
label_13:
        try
        {
          num2 = (short) 3;
          int num3 = (int) (IntPtr) num2;
          StreamWriter streamWriter;
          while (true)
          {
            switch (num3)
            {
              case 0:
                try
                {
                  streamWriter.Write(this.txtBoxProgressStatus.Text);
                  streamWriter.Flush();
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
                        goto label_29;
                      case 1:
                        num5 = (short) 19389;
                        int num6 = (int) num5;
                        num5 = (short) 19389;
                        int num7 = (int) num5;
                        switch (num6 == num7 ? 1 : 0)
                        {
                          case 0:
                          case 2:
                            goto label_28;
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
                      case 2:
label_28:
                        streamWriter.Dispose();
                        num5 = (short) 0;
                        num4 = (int) (IntPtr) num5;
                        continue;
                    }
                    if (streamWriter != null)
                    {
                      num5 = (short) 2;
                      num4 = (int) (IntPtr) num5;
                    }
                    else
                      break;
                  }
label_29:;
                }
                num2 = (short) 1;
                num3 = (int) (IntPtr) num2;
                continue;
              case 1:
                goto label_40;
              case 2:
                fileName += RptMgrErrorHandler.b("궂\uE984\uE886\uEE88", A_1_1);
                num2 = (short) 4;
                num3 = (int) (IntPtr) num2;
                continue;
              case 3:
                switch (0)
                {
                  case 0:
                    goto label_16;
                  default:
                    continue;
                }
              case 4:
                streamWriter = new StreamWriter(fileName);
                num2 = (short) 0;
                num3 = (int) (IntPtr) num2;
                continue;
              default:
label_16:
                if (!fileName.EndsWith(RptMgrErrorHandler.b("궂\uE984\uE886\uEE88", A_1_1)))
                {
                  num2 = (short) 2;
                  num3 = (int) (IntPtr) num2;
                  continue;
                }
                goto case 4;
            }
          }
label_40:
          break;
        }
        catch (Exception ex)
        {
          if (System.Windows.MessageBox.Show(ex.Message, AppResources.Error_Saving_The_Log_File, MessageBoxButton.OK, MessageBoxImage.Exclamation) != MessageBoxResult.OK)
            break;
          AppInfoManager.StatusMsgReport.RegisterMessage((StatusMsgType) 0, AppResources.Error_Saving_The_Log_File + RptMgrErrorHandler.b("ꎂ", A_1_1) + fileName);
          break;
        }
label_51:
        break;
label_41:
        AppInfoManager.StatusMsgReport.RegisterMessage((StatusMsgType) 0, AppResources.File_You_Save_Is_Readonly);
        break;
label_47:
        break;
label_45:
        break;
    }
  }

  private void batProgressResultExpander_Expanded(object A_0, RoutedEventArgs A_1)
  {
    short num1 = -9596;
    int num2 = (int) num1;
    num1 = (short) -9596;
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
        this.This.Height = 745.0;
        this.txtBoxProgressStatus.Visibility = Visibility.Visible;
        break;
      default:
        goto case 1;
    }
  }

  private void batProgressResultExpander_Collapsed(object A_0, RoutedEventArgs A_1)
  {
    short num1 = 17401;
    int num2 = (int) num1;
    num1 = (short) 17401;
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
        this.This.Height = 530.0;
        this.txtBoxProgressStatus.Visibility = Visibility.Collapsed;
        break;
      default:
        goto case 1;
    }
  }

  private bool b(string A_0)
  {
    bool flag;
    try
    {
      int num1;
      byte[] addressBytes;
      byte num2;
      short num3;
      switch (0)
      {
        case 0:
label_2:
          addressBytes = IPAddress.Parse(A_0).GetAddressBytes();
          num2 = addressBytes[0];
          num3 = (short) 8;
          num1 = (int) (IntPtr) num3;
          goto default;
        default:
          while (true)
          {
            switch (num1)
            {
              case 0:
                if (num2 == (byte) 192 /*0xC0*/)
                {
                  num3 = (short) 10;
                  num1 = (int) (IntPtr) num3;
                  continue;
                }
                goto case 20;
              case 1:
                if (addressBytes[2] != (byte) 0)
                {
                  num3 = (short) 20;
                  num1 = (int) (IntPtr) num3;
                  continue;
                }
                goto case 32 /*0x20*/;
              case 2:
                if (num2 >= (byte) 128 /*0x80*/)
                {
                  num3 = (short) 23;
                  num1 = (int) (IntPtr) num3;
                  continue;
                }
                num3 = (short) 31 /*0x1F*/;
                num1 = (int) (IntPtr) num3;
                continue;
              case 3:
                num3 = (short) 1;
                if (num3 == (short) 0)
                  ;
                if (num2 != (byte) 127 /*0x7F*/)
                {
                  num3 = (short) 48 /*0x30*/;
                  num1 = (int) (IntPtr) num3;
                  continue;
                }
                goto case 18;
              case 4:
                num3 = (short) 36;
                num1 = (int) (IntPtr) num3;
                continue;
              case 5:
                if (num2 != (byte) 0)
                {
                  num3 = (short) 9;
                  num1 = (int) (IntPtr) num3;
                  continue;
                }
                num3 = (short) 18;
                num1 = (int) (IntPtr) num3;
                continue;
              case 6:
                num3 = (short) 26;
                num1 = (int) (IntPtr) num3;
                continue;
              case 7:
                if (addressBytes[2] == byte.MaxValue)
                {
                  num3 = (short) 4;
                  num1 = (int) (IntPtr) num3;
                  continue;
                }
                goto case 22;
              case 8:
                if (num2 <= (byte) 223)
                {
                  num3 = (short) 13;
                  num1 = (int) (IntPtr) num3;
                  continue;
                }
                goto case 18;
              case 9:
                if (num2 >= (byte) 192 /*0xC0*/)
                {
                  num3 = (short) 21;
                  num1 = (int) (IntPtr) num3;
                  continue;
                }
                num3 = (short) 2;
                num1 = (int) (IntPtr) num3;
                continue;
              case 10:
                num3 = (short) 47;
                num1 = (int) (IntPtr) num3;
                continue;
              case 11:
                if (num2 == (byte) 128 /*0x80*/)
                {
                  num3 = (short) 6;
                  num1 = (int) (IntPtr) num3;
                  continue;
                }
                goto case 30;
              case 12:
                num3 = (short) 44;
                num1 = (int) (IntPtr) num3;
                continue;
              case 13:
                num3 = (short) 3;
                num1 = (int) (IntPtr) num3;
                continue;
              case 14:
                if (addressBytes[3] == (byte) 0)
                {
                  num3 = (short) 19;
                  num1 = (int) (IntPtr) num3;
                  continue;
                }
                goto label_75;
              case 15:
                flag = false;
                num3 = (short) 43;
                num1 = (int) (IntPtr) num3;
                continue;
              case 16 /*0x10*/:
                if (addressBytes[3] == byte.MaxValue)
                {
                  num3 = (short) 32 /*0x20*/;
                  num1 = (int) (IntPtr) num3;
                  continue;
                }
                goto label_75;
              case 17:
              case 38:
              case 39:
              case 43:
                goto label_78;
              case 18:
                flag = false;
                num3 = (short) 17;
                num1 = (int) (IntPtr) num3;
                continue;
              case 19:
                flag = false;
                num3 = (short) 39;
                num1 = (int) (IntPtr) num3;
                continue;
              case 20:
                num3 = (short) 46;
                num1 = (int) (IntPtr) num3;
                continue;
              case 21:
                num3 = (short) 0;
                num1 = (int) (IntPtr) num3;
                continue;
              case 22:
                num3 = (short) -27082;
                int num4 = (int) num3;
                num3 = (short) -27082;
                int num5 = (int) num3;
                switch (num4 == num5 ? 1 : 0)
                {
                  case 0:
                  case 2:
                    break;
                  default:
                    num3 = (short) 0;
                    if (num3 == (short) 0)
                      ;
                    num3 = (short) 25;
                    num1 = (int) (IntPtr) num3;
                    continue;
                }
                break;
              case 23:
                num3 = (short) 11;
                num1 = (int) (IntPtr) num3;
                continue;
              case 24:
                if (addressBytes[2] == (byte) 0)
                {
                  num3 = (short) 12;
                  num1 = (int) (IntPtr) num3;
                  continue;
                }
                goto case 27;
              case 25:
                if (addressBytes[2] == (byte) 0)
                {
                  num3 = (short) 41;
                  num1 = (int) (IntPtr) num3;
                  continue;
                }
                goto label_75;
              case 26:
                if (addressBytes[1] != (byte) 0)
                {
                  num3 = (short) 30;
                  num1 = (int) (IntPtr) num3;
                  continue;
                }
                goto case 19;
              case 27:
                num3 = (short) 33;
                num1 = (int) (IntPtr) num3;
                continue;
              case 28:
                num3 = (short) 24;
                num1 = (int) (IntPtr) num3;
                continue;
              case 29:
                num3 = (short) 45;
                num1 = (int) (IntPtr) num3;
                continue;
              case 30:
                num3 = (short) 7;
                num1 = (int) (IntPtr) num3;
                continue;
              case 31 /*0x1F*/:
                if (addressBytes[1] == (byte) 0)
                {
                  num3 = (short) 28;
                  num1 = (int) (IntPtr) num3;
                  continue;
                }
                goto case 27;
              case 32 /*0x20*/:
                flag = false;
                num3 = (short) 38;
                num1 = (int) (IntPtr) num3;
                continue;
              case 33:
                if (addressBytes[1] == byte.MaxValue)
                {
                  num3 = (short) 34;
                  num1 = (int) (IntPtr) num3;
                  continue;
                }
                goto label_75;
              case 34:
                num3 = (short) 40;
                num1 = (int) (IntPtr) num3;
                continue;
              case 35:
                num3 = (short) 1;
                num1 = (int) (IntPtr) num3;
                continue;
              case 36:
                if (addressBytes[3] != byte.MaxValue)
                {
                  num3 = (short) 22;
                  num1 = (int) (IntPtr) num3;
                  continue;
                }
                goto case 19;
              case 37:
                num3 = (short) 16 /*0x10*/;
                num1 = (int) (IntPtr) num3;
                continue;
              case 40:
                if (addressBytes[2] != byte.MaxValue)
                  goto label_75;
                break;
              case 41:
                num3 = (short) 14;
                num1 = (int) (IntPtr) num3;
                continue;
              case 42:
                goto label_77;
              case 44:
                if (addressBytes[3] != (byte) 0)
                {
                  num3 = (short) 27;
                  num1 = (int) (IntPtr) num3;
                  continue;
                }
                goto case 15;
              case 45:
                if (addressBytes[3] == byte.MaxValue)
                {
                  num3 = (short) 15;
                  num1 = (int) (IntPtr) num3;
                  continue;
                }
                goto label_75;
              case 46:
                if (addressBytes[3] != (byte) 0)
                {
                  num3 = (short) 37;
                  num1 = (int) (IntPtr) num3;
                  continue;
                }
                goto case 32 /*0x20*/;
              case 47:
                if (addressBytes[1] == (byte) 0)
                {
                  num3 = (short) 35;
                  num1 = (int) (IntPtr) num3;
                  continue;
                }
                goto case 20;
              case 48 /*0x30*/:
                num3 = (short) 5;
                num1 = (int) (IntPtr) num3;
                continue;
              default:
                goto label_2;
            }
            num3 = (short) 29;
            num1 = (int) (IntPtr) num3;
            continue;
label_75:
            num3 = (short) 42;
            num1 = (int) (IntPtr) num3;
          }
      }
    }
    catch (Exception ex)
    {
      flag = false;
      goto label_78;
    }
label_77:
    return true;
label_78:
    return flag;
  }

  internal void CloneRadioUsingRadioIdOrRadioIp(POP25RadioInfo radio)
  {
    int A_1 = 17;
    int num1 = 0;
    switch (num1)
    {
      default:
        string statusMsg;
        bool bContinueClone;
        short num2;
        switch (0)
        {
          case 0:
label_3:
            statusMsg = (string) null;
            bContinueClone = false;
            this.WriteToLogCurrentPass();
            this.CurrentRadioIpAddress = radio.Radio_IP;
            this.CurrentRadioID = radio.Radio_ID;
            num2 = (short) 5;
            num1 = (int) (IntPtr) num2;
            goto default;
          default:
            while (true)
            {
              switch (num1)
              {
                case 0:
                  num2 = (short) 3;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 1:
                  if (this.b(radio.Radio_IP))
                  {
                    num2 = (short) 11;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 0;
                  statusMsg = AppResources.Radio_Colon + RptMgrErrorHandler.b("뒓", A_1) + radio.Radio_ID + RptMgrErrorHandler.b("뮓", A_1) + radio.Radio_IP + RptMgrErrorHandler.b("뒓뚕떗랙벛뺝", A_1) + AppResources.Invalid_Radio_IP_Address;
                  radio.Status = AppResources.FAILED_All_UpperCase_Id;
                  num2 = (short) 8;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 2:
                  num2 = (short) 9;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 3:
                  if (this.b(this.ARSIpAddress))
                  {
                    num2 = (short) 4;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  break;
                case 4:
                  num2 = (short) 14;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 5:
                  num2 = (short) 1;
                  if (num2 == (short) 0)
                    ;
                  if (!this.CancelBatchProgramming)
                  {
                    num2 = (short) 6;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_30;
                case 6:
                  this.BatchProgrammingInProgress = true;
                  AppInfoManager.StatusMsgReport.Clear();
                  Utility.SaveFieldWithFocus();
                  num2 = (short) 7;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 7:
                  if (this.ARSServerEnabled)
                  {
                    num2 = (short) 0;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  break;
                case 8:
                case 12:
                  goto label_19;
                case 9:
label_26:
                  if (this.b(radio.Radio_IP))
                  {
                    num2 = (short) 10;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_10;
                case 10:
                  num2 = (short) -28137;
                  int num3 = (int) num2;
                  num2 = (short) -28137;
                  int num4 = (int) num2;
                  switch (num3 == num4 ? 1 : 0)
                  {
                    case 0:
                    case 2:
                      goto label_26;
                    default:
                      num2 = (short) 0;
                      if (num2 == (short) 0)
                        ;
                      bContinueClone = true;
                      num2 = (short) 13;
                      num1 = (int) (IntPtr) num2;
                      continue;
                  }
                case 11:
                  bContinueClone = true;
                  num2 = (short) 12;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 13:
                  goto label_10;
                case 14:
                  if (radio.Radio_ID == "")
                  {
                    num2 = (short) 2;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_24;
                default:
                  goto label_3;
              }
              num2 = (short) 1;
              num1 = (int) (IntPtr) num2;
            }
label_10:
            this.ProcessRadio(radio, bContinueClone, statusMsg, (string) null);
            return;
label_19:
            this.ProcessRadio(radio, bContinueClone, statusMsg, (string) null);
            return;
label_24:
            new Thread((ThreadStart) (() =>
            {
              short num5 = 1;
              if (num5 == (short) 0)
                ;
              num5 = (short) -526;
              int num6 = (int) num5;
              num5 = (short) -526;
              int num7 = (int) num5;
              switch (num6 == num7)
              {
                case true:
                  num5 = (short) 0;
                  if (num5 == (short) 0)
                    ;
                  this.a(radio);
                  break;
                default:
                  goto case 1;
              }
            })).Start();
            return;
label_30:
            this.BatchProgrammingComplete = true;
            this.BatchProgrammingInProgress = false;
            this.btnBatchProgrammingClose.IsEnabled = true;
            this.btnSaveToFile.IsEnabled = true;
            radio.Status = AppResources.Cancelled_Id;
            string programmingCancelled = AppResources.User_Action_Batch_Programming_Cancelled;
            this.txtBoxProgressStatus.AppendText(RptMgrErrorHandler.b("馓鲕", A_1) + DateTime.Now.ToString() + RptMgrErrorHandler.b("뒓뮕떗몙", A_1) + AppResources.User_Action_Batch_Programming_Cancelled + Environment.NewLine);
            this.txtBoxProgressStatus.ScrollToEnd();
            this.ProcessRadio(radio, bContinueClone, programmingCancelled, (string) null);
            return;
        }
    }
  }

  internal void ProcessRadio(
    POP25RadioInfo radio,
    bool bContinueClone,
    string statusMsg,
    string networkError)
  {
    int A_1 = 2;
    int num1;
    short num2;
    int status_int;
    int status;
    switch (0)
    {
      case 0:
label_2:
        status = 0;
        status_int = 0;
        num2 = (short) 3;
        num1 = (int) (IntPtr) num2;
        goto default;
      default:
        while (true)
        {
          switch (num1)
          {
            case 0:
              this.ProgText.Text = AcpStringExtensions.AcpStringFormat(networkError, new object[2]
              {
                (object) this.CurrentRadioID,
                (object) this.CurrentRadioIpAddress
              });
              AppInfoManager.StatusMsgReport.RegisterMessage((StatusMsgType) 0, networkError);
              this.WriteToLog_Failure();
              num2 = (short) 2;
              num1 = (int) (IntPtr) num2;
              continue;
            case 1:
              if (bContinueClone)
              {
                num2 = (short) 11;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_25;
            case 2:
              num2 = (short) 12;
              num1 = (int) (IntPtr) num2;
              continue;
            case 3:
label_3:
              if (!bContinueClone)
              {
                num2 = (short) 4;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 10;
            case 4:
              this.ProgText.Text = AcpStringExtensions.AcpStringFormat(statusMsg, new object[2]
              {
                (object) this.CurrentRadioID,
                (object) this.CurrentRadioIpAddress
              });
              this.WriteToLog_Failure();
              num2 = (short) 10;
              num1 = (int) (IntPtr) num2;
              continue;
            case 5:
              if (networkError != null)
              {
                num2 = (short) 0;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 2;
            case 6:
              radio.Radio_IP = radio.Radio_IP + RptMgrErrorHandler.b("ꖄ꾆", A_1) + this.CurrentRadioIpAddress + RptMgrErrorHandler.b("겄", A_1);
              num2 = (short) 9;
              num1 = (int) (IntPtr) num2;
              continue;
            case 7:
              if (!radio.Radio_IP.Contains(RptMgrErrorHandler.b("ꖄ꾆", A_1) + this.CurrentRadioIpAddress + RptMgrErrorHandler.b("겄", A_1)))
              {
                num2 = (short) 1;
                if (num2 == (short) 0)
                  ;
                num2 = (short) 6;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 9;
            case 8:
              num2 = (short) 5691;
              int num3 = (int) num2;
              num2 = (short) 5691;
              int num4 = (int) num2;
              switch (num3 == num4 ? 1 : 0)
              {
                case 0:
                case 2:
                  goto label_3;
                case 1:
                  num2 = (short) 0;
                  if (num2 == (short) 0)
                    ;
                  num2 = (short) 7;
                  num1 = (int) (IntPtr) num2;
                  continue;
                default:
                  num2 = (short) 0;
                  goto case 1;
              }
            case 9:
              num2 = (short) 1;
              num1 = (int) (IntPtr) num2;
              continue;
            case 10:
              num2 = (short) 5;
              num1 = (int) (IntPtr) num2;
              continue;
            case 11:
              goto label_13;
            case 12:
              if (this.CurrentRadioIpAddress != radio.Radio_IP & bContinueClone)
              {
                num2 = (short) 8;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 9;
            default:
              goto label_2;
          }
        }
label_13:
        new PackUnpackExecutor().PrePackHandler();
        new Thread((ThreadStart) (() =>
        {
          int num5;
          Clone clone;
          short num6;
          switch (0)
          {
            case 0:
label_2:
              clone = new Clone();
              SpecialFeatures.Comms.Comms.updateStatus += new SpecialFeatures.Comms.Comms.DisplayUpdateStatus(this.a);
              status_int = (int) this.Dispatcher.Invoke((Delegate) new POP25BatchProgrammerProgress.MainThreadUpdateRadioIds(this.SaveRadioIds), (object) clone.ReadRadioIds(CloneParameters.CloneWriteType, 8, this.CurrentRadioIpAddress, this.WriteProtectWriteProtectedRad, this.g));
              num6 = (short) 0;
              num6 = (short) 1;
              num5 = (int) (IntPtr) num6;
              goto default;
            default:
              while (true)
              {
                switch (num5)
                {
                  case 0:
                    num6 = (short) 9;
                    num5 = (int) (IntPtr) num6;
                    continue;
                  case 1:
                    if (status_int == 1)
                    {
                      num6 = (short) 0;
                      num5 = (int) (IntPtr) num6;
                      continue;
                    }
                    num6 = (short) -29265;
                    int num7 = (int) num6;
                    num6 = (short) -29265;
                    int num8 = (int) num6;
                    switch (num7 == num8 ? 1 : 0)
                    {
                      case 0:
                      case 2:
                        goto label_11;
                      default:
                        num6 = (short) 0;
                        if (num6 == (short) 0)
                          ;
                        num6 = (short) 4;
                        num5 = (int) (IntPtr) num6;
                        continue;
                    }
                  case 2:
                  case 8:
                    this.j = Encoding.ASCII.GetString(Convert.FromBase64String(clone.GetRadioParams().SerialNumber));
                    num6 = (short) 7;
                    num5 = (int) (IntPtr) num6;
                    continue;
                  case 3:
                  case 5:
                  case 7:
                    goto label_19;
                  case 4:
                    if (status_int == -1)
                    {
                      num6 = (short) 6;
                      num5 = (int) (IntPtr) num6;
                      continue;
                    }
                    num6 = (short) 1;
                    if (num6 == (short) 0)
                      ;
                    status = 0;
                    num6 = (short) 5;
                    num5 = (int) (IntPtr) num6;
                    continue;
                  case 6:
                    SpecialFeatures.Comms.Comms.DispalyUpdateStatusChanged(0.0, AppResources.Warning_System_Type_Not_Match_While_Batch_Clone);
                    status = -1;
                    num6 = (short) 3;
                    num5 = (int) (IntPtr) num6;
                    continue;
                  case 9:
                    if (clone.CloneRadio(true, CloneParameters.CloneWriteType, CloneParameters.LastCloneOTAPUserState, (Window) this, this.g))
                    {
                      num6 = (short) 10;
                      num5 = (int) (IntPtr) num6;
                      continue;
                    }
                    status = 0;
                    num6 = (short) 8;
                    num5 = (int) (IntPtr) num6;
                    continue;
                  case 10:
label_11:
                    status = 1;
                    num6 = (short) 2;
                    num5 = (int) (IntPtr) num6;
                    continue;
                  default:
                    goto label_2;
                }
              }
label_19:
              this.CallMainFinish(status);
              SpecialFeatures.Comms.Comms.updateStatus -= new SpecialFeatures.Comms.Comms.DisplayUpdateStatus(this.a);
              break;
          }
        })).Start();
        break;
label_25:
        this.CloneFinished(0);
        break;
    }
  }

  internal int SaveRadioIds(RadioIdInfo tempRadioIds)
  {
    int A_1 = 13;
    int num1 = 0;
    switch (num1)
    {
      default:
        int num2;
        Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation radioInformation;
        bool flag1;
        short num3;
        switch (0)
        {
          case 0:
label_3:
            num2 = 0;
            radioInformation = FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation;
            flag1 = false;
            num3 = (short) 48 /*0x30*/;
            num1 = (int) (IntPtr) num3;
            goto default;
          default:
            int num4;
            while (true)
            {
              Motorola.MackinawCPS.CoreFeatures.DataWide.DataWide dataWide;
              DataProfIP dataProfIp;
              int index;
              DataProfIP[] dataProfIps;
              string strB1;
              SecureKMFProfileRecset feature1;
              IEnumerator<FeatureNode> enumerator1;
              int length1;
              int num5;
              bool smartnetA8184Value;
              bool smartzoneA8185Value;
              Dictionary<string, int[]>.Enumerator enumerator2;
              Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide radioWide1;
              TrunkingSystemRecset feature2;
              SecureWideRecset feature3;
              bool flag2;
              ConventionalSystemRecset feature4;
              DataProfilesRecset feature5;
              switch (num1)
              {
                case 0:
                  if (feature4 != null)
                  {
                    num3 = (short) 3;
                    num1 = (int) (IntPtr) num3;
                    continue;
                  }
                  goto label_236;
                case 1:
                  num3 = (short) 40;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 2:
                  num2 = 1;
                  feature2 = FeatureManager.GetFeature(2064) as TrunkingSystemRecset;
                  num3 = (short) 45;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 3:
                  enumerator1 = ((Collection<FeatureNode>) feature4).GetEnumerator();
                  num3 = (short) 41;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 4:
                  Motorola.MackinawCPS.CoreFeatures.SecureWide.SecureWide secureWide = ((Recordset) feature3)[0] as Motorola.MackinawCPS.CoreFeatures.SecureWide.SecureWide;
                  flag2 = UndoManager.StopUndoRedo();
                  ((AcpField<int>) secureWide.ASTROOTAR.SecWideASTROOTARIndividualASTROOTARRadioID_A8284).Value = num5;
                  num3 = (short) 44;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 5:
                  num3 = (short) 0;
                  if (num5 != -1)
                  {
                    num3 = (short) 4;
                    num1 = (int) (IntPtr) num3;
                    continue;
                  }
                  goto case 10;
                case 6:
                  if (tempRadioIds.SoftIds != null)
                  {
                    num3 = (short) 57;
                    num1 = (int) (IntPtr) num3;
                    continue;
                  }
                  goto case 58;
                case 7:
                  num3 = (short) 5;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 8:
                  if (radioWide1 != null)
                  {
                    num3 = (short) 54;
                    num1 = (int) (IntPtr) num3;
                    continue;
                  }
                  goto case 56;
                case 9:
                  num3 = (short) 12;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 10:
                  num3 = (short) 6;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 11:
                  num2 = 1;
                  feature4 = FeatureManager.GetFeature(2053) as ConventionalSystemRecset;
                  num3 = (short) 0;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 12:
                  if (strB1 == RptMgrErrorHandler.b("풏\uF391\uE093\uF795쾗\uF399\uF89Bﮝ", A_1))
                  {
                    num3 = (short) 50;
                    num1 = (int) (IntPtr) num3;
                    continue;
                  }
                  feature5 = FeatureManager.GetFeature(2054) as DataProfilesRecset;
                  num3 = (short) 17;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 13:
                  ((AcpField<long>) dataWide.General.DataWideGeneralBTDUNPeerIPAddress_A41123).SetValue(dataProfIp.BTPeerIP.Address);
                  num3 = (short) 23;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 14:
                  if (smartnetA8184Value | smartzoneA8185Value)
                  {
                    num3 = (short) 16 /*0x10*/;
                    num1 = (int) (IntPtr) num3;
                    continue;
                  }
                  goto case 15;
                case 15:
                  num3 = (short) 39;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 16 /*0x10*/:
                  flag1 = true;
                  num3 = (short) 15;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 17:
                  if (feature5 != null)
                  {
                    num3 = (short) 43;
                    num1 = (int) (IntPtr) num3;
                    continue;
                  }
                  goto label_243;
                case 18:
                  if (tempRadioIds.DataProfIps != null)
                  {
                    num3 = (short) 47;
                    num1 = (int) (IntPtr) num3;
                    continue;
                  }
                  goto label_111;
                case 19:
                  if (feature1 != null)
                  {
                    num3 = (short) 55;
                    num1 = (int) (IntPtr) num3;
                    continue;
                  }
                  goto label_239;
                case 20:
                  if (tempRadioIds.CnvSysIds != null)
                  {
                    num3 = (short) 11;
                    num1 = (int) (IntPtr) num3;
                    continue;
                  }
                  goto label_236;
                case 21:
                  num3 = (short) 1;
                  if (num3 == (short) 0)
                    ;
                  UndoManager.StartUndoRedo();
                  num3 = (short) 10;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 22:
                  if (tempRadioIds.AstroOtarRadioIds != null)
                  {
                    num3 = (short) 46;
                    num1 = (int) (IntPtr) num3;
                    continue;
                  }
                  goto case 10;
                case 23:
                case 49:
                  goto label_111;
                case 24:
                case 35:
                  num3 = (short) 37;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 25:
                  try
                  {
                    num3 = (short) 5;
                    int num6 = (int) (IntPtr) num3;
                    while (true)
                    {
                      Motorola.MackinawCPS.CoreFeatures.DataProfiles.DataProfiles current;
                      switch (num6)
                      {
                        case 0:
                          num3 = (short) 2;
                          num6 = (int) (IntPtr) num3;
                          continue;
                        case 1:
                          if (dataProfIp.BTSubIP != null)
                          {
                            num3 = (short) 3;
                            num6 = (int) (IntPtr) num3;
                            continue;
                          }
                          goto case 0;
                        case 2:
                          if (dataProfIp.BTPeerIP != null)
                          {
                            num3 = (short) 4;
                            num6 = (int) (IntPtr) num3;
                            continue;
                          }
                          goto case 6;
                        case 3:
                          ((AcpField<long>) current.General.DataProfilesGeneralBTDUNSUIPAddress_A41126).SetValue(dataProfIp.BTSubIP.Address);
                          num3 = (short) 0;
                          num6 = (int) (IntPtr) num3;
                          continue;
                        case 4:
                          ((AcpField<long>) current.General.DataProfilesGeneralBTDUNPeerIPAddress_A41127).SetValue(dataProfIp.BTPeerIP.Address);
                          num3 = (short) 8;
                          num6 = (int) (IntPtr) num3;
                          continue;
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
                          num3 = (short) 13;
                          num6 = (int) (IntPtr) num3;
                          continue;
                        case 7:
                          if (!enumerator1.MoveNext())
                          {
                            num3 = (short) 6;
                            num6 = (int) (IntPtr) num3;
                            continue;
                          }
                          current = (Motorola.MackinawCPS.CoreFeatures.DataProfiles.DataProfiles) enumerator1.Current;
                          num3 = (short) 10;
                          num6 = (int) (IntPtr) num3;
                          continue;
                        case 8:
                        case 13:
                          goto label_243;
                        case 9:
                          if (!current.General.DataProfGeneralAutoGenerateIPAddress_A19320.Value)
                          {
                            num3 = (short) 11;
                            num6 = (int) (IntPtr) num3;
                            continue;
                          }
                          break;
                        case 10:
                          if (((FeatureNode) current).ReferenceKey.CompareTo(strB1) == 0)
                          {
                            num3 = (short) 12;
                            num6 = (int) (IntPtr) num3;
                            continue;
                          }
                          break;
                        case 11:
                          ((AcpField<long>) current.General.DataProfGeneralSubscriberIPAddress_A21157).SetValue(dataProfIp.SubIP.Address);
                          ((AcpField<long>) current.General.DataProfGeneralMobileComputerIPAddress_A8523).SetValue(dataProfIp.PeerIP.Address);
                          ((AcpField<long>) current.General.DataProfGeneralSubscriberAirInterfaceIPAddress_A9220).SetValue(dataProfIp.SubAirInterfaceIP.Address);
                          num3 = (short) 1;
                          num6 = (int) (IntPtr) num3;
                          continue;
                        case 12:
                          num3 = (short) 9;
                          num6 = (int) (IntPtr) num3;
                          continue;
                      }
                      num3 = (short) 7;
                      num6 = (int) (IntPtr) num3;
                    }
                  }
                  finally
                  {
                    int num7 = 0;
                    while (true)
                    {
                      short num8;
                      switch (num7)
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
                          enumerator1.Dispose();
                          num8 = (short) 2;
                          num7 = (int) (IntPtr) num8;
                          continue;
                        case 2:
                          goto label_153;
                      }
                      if (enumerator1 != null)
                      {
                        num8 = (short) 1;
                        num7 = (int) (IntPtr) num8;
                      }
                      else
                        break;
                    }
label_153:;
                  }
                case 26:
                  num2 = 1;
                  Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide radioWide2 = ((Recordset) (FeatureManager.GetFeature(2045) as RadioWideRecset))[0] as Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide;
                  tempRadioIds.BluetoothFriendlyName = this.a(tempRadioIds.BluetoothFriendlyName);
                  radioWide2.Bluetooth.RadWideBluetoothFriendlyName_A41181.SetValue(tempRadioIds.BluetoothFriendlyName);
                  num3 = (short) 31 /*0x1F*/;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 27:
                  if (tempRadioIds.RadioAlias != null)
                  {
                    num3 = (short) 32 /*0x20*/;
                    num1 = (int) (IntPtr) num3;
                    continue;
                  }
                  goto case 56;
                case 28:
                  if (length1 > 0)
                  {
                    num3 = (short) 52;
                    num1 = (int) (IntPtr) num3;
                    continue;
                  }
                  goto case 9;
                case 29:
                  smartnetA8184Value = radioInformation.Labtool.RadInfoLabtoolH37G50Smartnet_A8184Value;
                  smartzoneA8185Value = radioInformation.Labtool.RadInfoLabtoolH38G51Smartzone_A8185Value;
                  num3 = (short) 14;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 30:
                  Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide radioWide3 = ((Recordset) (FeatureManager.GetFeature(2045) as RadioWideRecset))[0] as Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide;
                  ((AcpField<string>) radioWide3.UserInformationAndPasswords.RadWideUserInformationandPasswordsSoftIDUsername_A9169).SetValue(this.a(tempRadioIds.SoftIds[0]));
                  PINPasswordUtil.UpdatePINPasswordFromRadio(tempRadioIds);
                  radioWide3.UserInformationAndPasswords.RadWideUserInformationandUserLoginUnitID_41306.SetValue(tempRadioIds.SoftIds[3] == null ? "" : this.a(tempRadioIds.SoftIds[3]));
                  num3 = (short) 58;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 31 /*0x1F*/:
                  num3 = (short) 18;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 32 /*0x20*/:
                  num2 = 1;
                  radioWide1 = ((Recordset) (FeatureManager.GetFeature(2045) as RadioWideRecset))[0] as Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide;
                  tempRadioIds.RadioAlias = this.a(tempRadioIds.RadioAlias);
                  num3 = (short) 8;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 33:
                  if (tempRadioIds.BluetoothFriendlyName != null)
                  {
                    num3 = (short) 26;
                    num1 = (int) (IntPtr) num3;
                    continue;
                  }
                  goto case 31 /*0x1F*/;
                case 34:
                  ((AcpField<long>) dataWide.General.DataWideGeneralBTDUNSUIPAddress_A41120).SetValue(dataProfIp.BTSubIP.Address);
                  num3 = (short) 1;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 36:
                  try
                  {
                    num3 = (short) 3;
                    int num9 = (int) (IntPtr) num3;
                    while (true)
                    {
                      Motorola.MackinawCPS.CoreFeatures.SecureKMFProfile.SecureKMFProfile current1;
                      Dictionary<string, int>.Enumerator enumerator3;
                      string referenceKey;
                      switch (num9)
                      {
                        case 0:
                          try
                          {
                            num3 = (short) 4;
                            int num10 = (int) (IntPtr) num3;
                            while (true)
                            {
                              KeyValuePair<string, int> current2;
                              string key;
                              switch (num10)
                              {
                                case 0:
                                case 8:
                                  goto label_40;
                                case 1:
                                  num3 = (short) 0;
                                  num10 = (int) (IntPtr) num3;
                                  continue;
                                case 2:
                                  if (!enumerator3.MoveNext())
                                  {
                                    num3 = (short) 1;
                                    num10 = (int) (IntPtr) num3;
                                    continue;
                                  }
                                  current2 = enumerator3.Current;
                                  key = current2.Key;
                                  num3 = (short) 3;
                                  num10 = (int) (IntPtr) num3;
                                  continue;
                                case 3:
                                  if (referenceKey.Equals(key.TrimEnd(new char[1])))
                                  {
                                    num3 = (short) 6;
                                    num10 = (int) (IntPtr) num3;
                                    continue;
                                  }
                                  break;
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
                                  num5 = current2.Value;
                                  num3 = (short) 8;
                                  num10 = (int) (IntPtr) num3;
                                  continue;
                                case 6:
                                  ((AcpField<int>) current1.ASTROOTARInformation.SecKmfProfASTROOTARInformationIndividualASTROOTARRadioID_A8285).SetValue(current2.Value);
                                  num3 = (short) 7;
                                  num10 = (int) (IntPtr) num3;
                                  continue;
                                case 7:
                                  if (!current1.General.SecKmfProfGenIndependentKeyList_43597.Value)
                                  {
                                    num3 = (short) 5;
                                    num10 = (int) (IntPtr) num3;
                                    continue;
                                  }
                                  goto case 1;
                              }
                              num3 = (short) 2;
                              num10 = (int) (IntPtr) num3;
                            }
                          }
                          finally
                          {
                            enumerator3.Dispose();
                          }
                        case 1:
                          if (enumerator1.MoveNext())
                          {
                            current1 = (Motorola.MackinawCPS.CoreFeatures.SecureKMFProfile.SecureKMFProfile) enumerator1.Current;
                            referenceKey = ((FeatureNode) current1).ReferenceKey;
                            enumerator3 = tempRadioIds.AstroOtarRadioIds.GetEnumerator();
                            num3 = (short) 0;
                            num9 = (int) (IntPtr) num3;
                            continue;
                          }
                          num3 = (short) 4;
                          num9 = (int) (IntPtr) num3;
                          continue;
                        case 2:
                          goto label_239;
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
                          num3 = (short) 2;
                          num9 = (int) (IntPtr) num3;
                          continue;
                      }
label_40:
                      num9 = 1;
                    }
                  }
                  finally
                  {
                    int num11 = 1;
                    while (true)
                    {
                      short num12;
                      switch (num11)
                      {
                        case 0:
                          goto label_50;
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
                          enumerator1.Dispose();
                          num12 = (short) 0;
                          num11 = (int) (IntPtr) num12;
                          continue;
                      }
                      if (enumerator1 != null)
                      {
                        num12 = (short) 2;
                        num11 = (int) (IntPtr) num12;
                      }
                      else
                        break;
                    }
label_50:;
                  }
                case 37:
                  if (index >= dataProfIps.Length)
                  {
                    num3 = (short) 49;
                    num1 = (int) (IntPtr) num3;
                    continue;
                  }
                  dataProfIp = dataProfIps[index];
                  strB1 = dataProfIp.DataProfName;
                  length1 = dataProfIp.DataProfName.IndexOf(char.MinValue);
                  num3 = (short) 28;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 38:
                  if (feature3 != null)
                  {
                    num3 = (short) 7;
                    num1 = (int) (IntPtr) num3;
                    continue;
                  }
                  goto case 10;
                case 39:
                  if (tempRadioIds.TrkSysIds != null & flag1)
                  {
                    num3 = (short) 2;
                    num1 = (int) (IntPtr) num3;
                    continue;
                  }
                  break;
                case 40:
                  if (dataProfIp.BTPeerIP != null)
                  {
                    num3 = (short) 13;
                    num1 = (int) (IntPtr) num3;
                    continue;
                  }
                  goto label_111;
                case 41:
                  try
                  {
                    num3 = (short) 1;
                    int num13 = (int) (IntPtr) num3;
                    while (true)
                    {
                      bool flag3;
                      Motorola.MackinawCPS.CoreFeatures.ConventionalSystem.ConventionalSystem current3;
                      string referenceKey;
                      switch (num13)
                      {
                        case 0:
                          if (CloneParameters.BlockNewSystemCheck)
                          {
                            num3 = (short) 3;
                            num13 = (int) (IntPtr) num3;
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
                          goto label_251;
                        case 3:
                          num4 = -1;
                          num3 = (short) 2;
                          num13 = (int) (IntPtr) num3;
                          continue;
                        case 4:
                          try
                          {
                            num3 = (short) 19;
                            int num14 = (int) (IntPtr) num3;
                            while (true)
                            {
                              KeyValuePair<string, int[]> current4;
                              string strB2;
                              int length2;
                              string typeA13262UiValue;
                              switch (num14)
                              {
                                case 0:
                                  if (referenceKey.CompareTo(strB2) == 0)
                                  {
                                    num3 = (short) 12;
                                    num14 = (int) (IntPtr) num3;
                                    continue;
                                  }
                                  goto default;
                                case 1:
                                case 23:
                                case 24:
                                case 27:
                                  goto label_168;
                                case 2:
                                  if (enumerator2.MoveNext())
                                  {
                                    current4 = enumerator2.Current;
                                    strB2 = current4.Key;
                                    length2 = current4.Key.IndexOf(char.MinValue);
                                    num3 = (short) 16 /*0x10*/;
                                    num14 = (int) (IntPtr) num3;
                                    continue;
                                  }
                                  num3 = (short) 7;
                                  num14 = (int) (IntPtr) num3;
                                  continue;
                                case 3:
                                  num3 = (short) 9;
                                  num14 = (int) (IntPtr) num3;
                                  continue;
                                case 4:
                                  flag3 = true;
                                  num3 = (short) 1;
                                  num14 = (int) (IntPtr) num3;
                                  continue;
                                case 5:
                                  num3 = (short) 11573;
                                  int num15 = (int) num3;
                                  num3 = (short) 11573;
                                  int num16 = (int) num3;
                                  switch (num15 == num16 ? 1 : 0)
                                  {
                                    case 0:
                                    case 2:
                                      goto label_217;
                                    default:
                                      num3 = (short) 0;
                                      if (num3 == (short) 0)
                                        ;
                                      num3 = (short) 6;
                                      num14 = (int) (IntPtr) num3;
                                      continue;
                                  }
                                case 6:
                                  if (typeA13262UiValue == AppResources.DVRS_Id)
                                  {
                                    num3 = (short) 3;
                                    num14 = (int) (IntPtr) num3;
                                    continue;
                                  }
                                  goto label_213;
                                case 7:
                                  num3 = (short) 27;
                                  num14 = (int) (IntPtr) num3;
                                  continue;
                                case 8:
                                  ((AcpField<int>) current3.General.CnvSysGeneralIndividualID_A8287).SetValue(current4.Value[1]);
                                  flag3 = true;
                                  num3 = (short) 23;
                                  num14 = (int) (IntPtr) num3;
                                  continue;
                                case 9:
                                  if (current4.Value[0] == 2)
                                  {
                                    num3 = (short) 8;
                                    num14 = (int) (IntPtr) num3;
                                    continue;
                                  }
                                  goto label_213;
                                case 10:
                                  if (current4.Value[0] == 3)
                                  {
                                    num3 = (short) 4;
                                    num14 = (int) (IntPtr) num3;
                                    continue;
                                  }
                                  goto case 7;
                                case 11:
                                  ((AcpField<int>) current3.General.CnvSysGeneralMDCPrimaryID_A8744).SetValue(current4.Value[1]);
                                  flag3 = true;
                                  goto label_217;
                                case 12:
                                  typeA13262UiValue = current3.General.CnvSysGeneralSystemType_A13262_UIValue;
                                  num3 = (short) 17;
                                  num14 = (int) (IntPtr) num3;
                                  continue;
                                case 13:
                                  num3 = (short) 22;
                                  num14 = (int) (IntPtr) num3;
                                  continue;
                                case 14:
                                  if (typeA13262UiValue == AppResources.QCII_ID)
                                  {
                                    num3 = (short) 25;
                                    num14 = (int) (IntPtr) num3;
                                    continue;
                                  }
                                  goto case 7;
                                case 15:
                                  strB2 = current4.Key.Substring(0, length2);
                                  num3 = (short) 21;
                                  num14 = (int) (IntPtr) num3;
                                  continue;
                                case 16 /*0x10*/:
                                  if (length2 > 0)
                                  {
                                    num3 = (short) 15;
                                    num14 = (int) (IntPtr) num3;
                                    continue;
                                  }
                                  goto case 21;
                                case 17:
                                  if (typeA13262UiValue == AppResources.ASTRO_Id)
                                  {
                                    num3 = (short) 13;
                                    num14 = (int) (IntPtr) num3;
                                    continue;
                                  }
                                  goto case 5;
                                case 18:
                                  if (typeA13262UiValue == AppResources.MDC_Id)
                                  {
                                    num3 = (short) 20;
                                    num14 = (int) (IntPtr) num3;
                                    continue;
                                  }
                                  break;
                                case 19:
                                  switch (0)
                                  {
                                    case 0:
                                      goto label_206;
                                    default:
                                      continue;
                                  }
                                case 20:
                                  num3 = (short) 26;
                                  num14 = (int) (IntPtr) num3;
                                  continue;
                                case 21:
                                  num3 = (short) 0;
                                  num14 = (int) (IntPtr) num3;
                                  continue;
                                case 22:
                                  if (current4.Value[0] != 0)
                                  {
                                    num3 = (short) 5;
                                    num14 = (int) (IntPtr) num3;
                                    continue;
                                  }
                                  goto case 8;
                                case 25:
                                  num3 = (short) 10;
                                  num14 = (int) (IntPtr) num3;
                                  continue;
                                case 26:
                                  if (current4.Value[0] == 1)
                                  {
                                    num3 = (short) 11;
                                    num14 = (int) (IntPtr) num3;
                                    continue;
                                  }
                                  break;
                                default:
label_206:
                                  num3 = (short) 2;
                                  num14 = (int) (IntPtr) num3;
                                  continue;
                              }
                              num3 = (short) 14;
                              num14 = (int) (IntPtr) num3;
                              continue;
label_213:
                              num3 = (short) 18;
                              num14 = (int) (IntPtr) num3;
                              continue;
label_217:
                              num3 = (short) 24;
                              num14 = (int) (IntPtr) num3;
                            }
                          }
                          finally
                          {
                            enumerator2.Dispose();
                          }
label_168:
                          num13 = 5;
                          continue;
                        case 5:
                          if (!flag3)
                          {
                            num3 = (short) 7;
                            num13 = (int) (IntPtr) num3;
                            continue;
                          }
                          break;
                        case 6:
                          if (!enumerator1.MoveNext())
                          {
                            num3 = (short) 8;
                            num13 = (int) (IntPtr) num3;
                            continue;
                          }
                          current3 = (Motorola.MackinawCPS.CoreFeatures.ConventionalSystem.ConventionalSystem) enumerator1.Current;
                          flag3 = false;
                          referenceKey = ((FeatureNode) current3).ReferenceKey;
                          enumerator2 = tempRadioIds.CnvSysIds.GetEnumerator();
                          num3 = (short) 4;
                          num13 = (int) (IntPtr) num3;
                          continue;
                        case 7:
                          num3 = (short) 0;
                          num13 = (int) (IntPtr) num3;
                          continue;
                        case 8:
                          num3 = (short) 9;
                          num13 = (int) (IntPtr) num3;
                          continue;
                        case 9:
                          goto label_236;
                      }
                      num3 = (short) 6;
                      num13 = (int) (IntPtr) num3;
                    }
                  }
                  finally
                  {
                    int num17 = 0;
                    while (true)
                    {
                      short num18;
                      switch (num17)
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
                          goto label_231;
                        case 2:
                          enumerator1.Dispose();
                          num18 = (short) 1;
                          num17 = (int) (IntPtr) num18;
                          continue;
                      }
                      if (enumerator1 != null)
                      {
                        num18 = (short) 2;
                        num17 = (int) (IntPtr) num18;
                      }
                      else
                        break;
                    }
label_231:;
                  }
                case 42:
                  if (dataProfIp.BTSubIP != null)
                  {
                    num3 = (short) 34;
                    num1 = (int) (IntPtr) num3;
                    continue;
                  }
                  goto case 1;
                case 43:
                  enumerator1 = ((Collection<FeatureNode>) feature5).GetEnumerator();
                  num3 = (short) 25;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 44:
                  if (flag2)
                  {
                    num3 = (short) 21;
                    num1 = (int) (IntPtr) num3;
                    continue;
                  }
                  goto case 10;
                case 45:
                  if (feature2 != null)
                  {
                    num3 = (short) 53;
                    num1 = (int) (IntPtr) num3;
                    continue;
                  }
                  break;
                case 46:
                  num5 = -1;
                  num2 = 1;
                  feature1 = FeatureManager.GetFeature(2055) as SecureKMFProfileRecset;
                  num3 = (short) 19;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 47:
                  num2 = 1;
                  dataProfIps = tempRadioIds.DataProfIps;
                  index = 0;
                  num3 = (short) 35;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 48 /*0x30*/:
                  if (radioInformation != null)
                  {
                    num3 = (short) 29;
                    num1 = (int) (IntPtr) num3;
                    continue;
                  }
                  goto case 15;
                case 50:
                  dataWide = ((Recordset) (FeatureManager.GetFeature(2028) as DataWideRecset))[0] as Motorola.MackinawCPS.CoreFeatures.DataWide.DataWide;
                  ((AcpField<long>) dataWide.General.DataWideGeneralPeerIPAddress1_A8524).SetValue(dataProfIp.PeerIP.Address);
                  ((AcpField<long>) dataWide.General.DataWideGeneralSubscriberIPAddress1_A9222).SetValue(dataProfIp.SubIP.Address);
                  num3 = (short) 42;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 51:
                  try
                  {
                    num3 = (short) 5;
                    int num19 = (int) (IntPtr) num3;
                    while (true)
                    {
                      Motorola.MackinawCPS.CoreFeatures.TrunkingSystem.TrunkingSystem current5;
                      bool flag4;
                      string referenceKey;
                      switch (num19)
                      {
                        case 0:
                          num4 = -1;
                          num3 = (short) 4;
                          num19 = (int) (IntPtr) num3;
                          continue;
                        case 1:
                          if (enumerator1.MoveNext())
                          {
                            current5 = (Motorola.MackinawCPS.CoreFeatures.TrunkingSystem.TrunkingSystem) enumerator1.Current;
                            flag4 = false;
                            referenceKey = ((FeatureNode) current5).ReferenceKey;
                            enumerator2 = tempRadioIds.TrkSysIds.GetEnumerator();
                            num3 = (short) 8;
                            num19 = (int) (IntPtr) num3;
                            continue;
                          }
                          num3 = (short) 9;
                          num19 = (int) (IntPtr) num3;
                          continue;
                        case 2:
                          goto label_113;
                        case 3:
                          if (!flag4)
                          {
                            num3 = (short) 7;
                            num19 = (int) (IntPtr) num3;
                            continue;
                          }
                          break;
                        case 4:
                          goto label_251;
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
                          if (CloneParameters.BlockNewSystemCheck)
                          {
                            num3 = (short) 0;
                            num19 = (int) (IntPtr) num3;
                            continue;
                          }
                          break;
                        case 7:
                          num3 = (short) 6;
                          num19 = (int) (IntPtr) num3;
                          continue;
                        case 8:
                          try
                          {
                            num3 = (short) 4;
                            int num20 = (int) (IntPtr) num3;
                            KeyValuePair<string, int[]> current6;
                            while (true)
                            {
                              string strB3;
                              int length3;
                              switch (num20)
                              {
                                case 0:
                                  goto label_86;
                                case 1:
                                  strB3 = current6.Key.Substring(0, length3);
                                  num3 = (short) 8;
                                  num20 = (int) (IntPtr) num3;
                                  continue;
                                case 2:
                                  if (length3 > 0)
                                  {
                                    num3 = (short) 1;
                                    num20 = (int) (IntPtr) num3;
                                    continue;
                                  }
                                  goto case 8;
                                case 3:
                                  if (enumerator2.MoveNext())
                                  {
                                    current6 = enumerator2.Current;
                                    strB3 = current6.Key;
                                    length3 = current6.Key.IndexOf(char.MinValue);
                                    num3 = (short) 2;
                                    num20 = (int) (IntPtr) num3;
                                    continue;
                                  }
                                  num3 = (short) 6;
                                  num20 = (int) (IntPtr) num3;
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
                                  goto label_67;
                                case 6:
                                  num3 = (short) 0;
                                  num20 = (int) (IntPtr) num3;
                                  continue;
                                case 7:
                                  if (referenceKey.CompareTo(strB3) == 0)
                                  {
                                    num3 = (short) 5;
                                    num20 = (int) (IntPtr) num3;
                                    continue;
                                  }
                                  break;
                                case 8:
                                  num3 = (short) 7;
                                  num20 = (int) (IntPtr) num3;
                                  continue;
                              }
                              num3 = (short) 3;
                              num20 = (int) (IntPtr) num3;
                            }
label_67:
                            try
                            {
                              flag4 = true;
                              ((AcpFieldBase) current5.General.TrkSysGeneralUnitID_A12651).DisableASKRangeValidation = true;
                              ((AcpField<int>) current5.General.TrkSysGeneralUnitID_A12651).Value = current6.Value[1];
                            }
                            catch (Exception ex)
                            {
                            }
                            finally
                            {
                              ((AcpFieldBase) current5.General.TrkSysGeneralUnitID_A12651).DisableASKRangeValidation = false;
                            }
                          }
                          finally
                          {
                            enumerator2.Dispose();
                          }
label_86:
                          num19 = 3;
                          continue;
                        case 9:
                          num3 = (short) 2;
                          num19 = (int) (IntPtr) num3;
                          continue;
                      }
                      num3 = (short) 1;
                      num19 = (int) (IntPtr) num3;
                    }
                  }
                  finally
                  {
                    int num21 = 1;
                    while (true)
                    {
                      short num22;
                      switch (num21)
                      {
                        case 0:
                          goto label_96;
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
                          enumerator1.Dispose();
                          num22 = (short) 0;
                          num21 = (int) (IntPtr) num22;
                          continue;
                      }
                      if (enumerator1 != null)
                      {
                        num22 = (short) 2;
                        num21 = (int) (IntPtr) num22;
                      }
                      else
                        break;
                    }
label_96:;
                  }
                case 52:
                  strB1 = dataProfIp.DataProfName.Substring(0, length1);
                  num3 = (short) 9;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 53:
                  enumerator1 = ((Collection<FeatureNode>) feature2).GetEnumerator();
                  num3 = (short) 51;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 54:
                  radioWide1.UserInformationAndPasswords.RadWideUserInformationandPasswordsRadioAlias_A8829.SetValue(tempRadioIds.RadioAlias);
                  num3 = (short) 56;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 55:
                  enumerator1 = ((Collection<FeatureNode>) feature1).GetEnumerator();
                  num3 = (short) 36;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 56:
                  num3 = (short) 33;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 57:
                  num2 = 1;
                  num3 = (short) 30;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 58:
                  num3 = (short) 27;
                  num1 = (int) (IntPtr) num3;
                  continue;
                default:
                  goto label_3;
              }
label_113:
              num3 = (short) 20;
              num1 = (int) (IntPtr) num3;
              continue;
label_236:
              num3 = (short) 22;
              num1 = (int) (IntPtr) num3;
              continue;
label_239:
              feature3 = FeatureManager.GetFeature(2021) as SecureWideRecset;
              num3 = (short) 38;
              num1 = (int) (IntPtr) num3;
              continue;
label_243:
              ++index;
              num3 = (short) 24;
              num1 = (int) (IntPtr) num3;
            }
label_111:
            return num2;
label_251:
            return num4;
        }
    }
  }

  private string a(string A_0)
  {
    int num1;
    short num2;
    int length;
    switch (0)
    {
      case 0:
label_2:
        num2 = (short) 0;
        num2 = (short) 1;
        if (num2 == (short) 0)
          ;
        num2 = (short) -20316;
        int num3 = (int) num2;
        num2 = (short) -20316;
        int num4 = (int) num2;
        switch (num3 == num4 ? 1 : 0)
        {
          case 0:
          case 2:
            goto label_1;
          default:
            num2 = (short) 0;
            if (num2 == (short) 0)
              ;
            length = A_0.IndexOf(char.MinValue);
            num2 = (short) 3;
            num1 = (int) (IntPtr) num2;
            goto label_1;
        }
      default:
        while (true)
        {
          switch (num1)
          {
            case 0:
            case 2:
              goto label_13;
            case 1:
              if (length > 0)
              {
                num2 = (short) 4;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_13;
            case 3:
              if (length == 0)
              {
                num2 = (short) 5;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              num2 = (short) 1;
              num1 = (int) (IntPtr) num2;
              continue;
            case 4:
              A_0 = A_0.Substring(0, length);
              num2 = (short) 0;
              num1 = (int) (IntPtr) num2;
              continue;
            case 5:
              A_0 = "";
              num2 = (short) 2;
              num1 = (int) (IntPtr) num2;
              continue;
            default:
              goto label_2;
          }
label_1:;
        }
label_13:
        return A_0;
    }
  }

  private void a(double A_0, string A_1)
  {
    short num1 = -13735;
    int num2 = (int) num1;
    num1 = (short) -13735;
    int num3 = (int) num1;
    switch (num2 == num3)
    {
      case true:
        short num4 = 0;
        num4 = (short) 0;
        if (num4 == (short) 0)
          ;
        num4 = (short) 1;
        if (num4 == (short) 0)
          ;
        this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Delegate) new POP25BatchProgrammerProgress.UpdateProgress(this.Radio_updateStatus), (object) A_0, (object) A_1);
        break;
      default:
        goto case 1;
    }
  }

  internal void WriteToLogCurrentPass()
  {
    int A_1 = 12;
    try
    {
      switch (true)
      {
        case true:
          if (true)
            ;
          this.txtBoxProgressStatus.AppendText(RptMgrErrorHandler.b("芎鮐", A_1) + AppResources.PASS_Id + (this.CurRetry + 1).ToString() + RptMgrErrorHandler.b("꾎벐뺒떔", A_1));
          this.txtBoxProgressStatus.ScrollToEnd();
          break;
        default:
          goto case 1;
      }
    }
    catch (Exception ex)
    {
      int num = (int) System.Windows.MessageBox.Show(AppResources.Cannot_Log_Status_Any_Further, AppResources.Log_File_Error, MessageBoxButton.OK, MessageBoxImage.Exclamation);
    }
    if (false)
      ;
  }

  internal void WriteToLog_Initial()
  {
    int A_1 = 13;
    try
    {
      switch (true)
      {
        case true:
          if (true)
            ;
          this.txtBoxProgressStatus.AppendText(RptMgrErrorHandler.b("骏", A_1) + DateTime.Now.ToString() + RptMgrErrorHandler.b("낏뾑릓뚕", A_1) + this.ProgText.Text + Environment.NewLine);
          this.txtBoxProgressStatus.ScrollToEnd();
          break;
        default:
          goto case 1;
      }
    }
    catch (Exception ex)
    {
      int num = (int) System.Windows.MessageBox.Show(AppResources.Cannot_Log_Status_Any_Further, AppResources.Log_File_Error, MessageBoxButton.OK, MessageBoxImage.Exclamation);
    }
    if (false)
      ;
  }

  internal void WriteToLog_Cont()
  {
    int A_1 = 8;
    try
    {
      short num1 = 9661;
      int num2 = (int) num1;
      num1 = (short) 9661;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          this.txtBoxProgressStatus.AppendText(DateTime.Now.ToString() + RptMgrErrorHandler.b("ꮊꂌꊎ놐", A_1) + this.ProgText.Text + Environment.NewLine);
          this.txtBoxProgressStatus.ScrollToEnd();
          break;
        default:
          goto case 1;
      }
    }
    catch (Exception ex)
    {
      int num = (int) System.Windows.MessageBox.Show(AppResources.Cannot_Log_Status_Any_Further, AppResources.Log_File_Error, MessageBoxButton.OK, MessageBoxImage.Exclamation);
    }
    if (false)
      ;
  }

  internal void WriteToLog_Success()
  {
    int A_1 = 7;
    try
    {
      if (false)
        ;
      short num1 = 21079;
      int num2 = (int) num1;
      num1 = (short) 21079;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          this.txtBoxProgressStatus.AppendText(DateTime.Now.ToString() + RptMgrErrorHandler.b("ꪉꆋꎍ낏", A_1) + this.ProgText.Text + Environment.NewLine);
          this.txtBoxProgressStatus.AppendText(RptMgrErrorHandler.b("ꂉꚋ\uA48D몏뢑뺓법늗낙뚛뒝誟袡躣貥袧", A_1) + AppResources.SUCCESS_All_Uppercase_Id + RptMgrErrorHandler.b("ꪉꚋ\uA48D몏뢑뺓법늗낙뚛뒝誟袡躣貥芧", A_1) + Environment.NewLine);
          this.txtBoxProgressStatus.ScrollToEnd();
          break;
        default:
          goto case 1;
      }
    }
    catch (Exception ex)
    {
      int num = (int) System.Windows.MessageBox.Show(AppResources.Cannot_Log_Status_Any_Further, AppResources.Log_File_Error, MessageBoxButton.OK, MessageBoxImage.Exclamation);
    }
  }

  internal void WriteToLog_Failure()
  {
    int A_1 = 16 /*0x10*/;
    try
    {
      switch (true)
      {
        case true:
          if (true)
            ;
          this.txtBoxProgressStatus.AppendText(DateTime.Now.ToString() + RptMgrErrorHandler.b("뎒뢔몖릘", A_1) + this.ProgText.Text + Environment.NewLine);
          this.txtBoxProgressStatus.AppendText(RptMgrErrorHandler.b("릒뾔붖뎘놚랜떞讠覢辤趦莨膪螬薮醰", A_1) + AppResources.FAILED_All_UpperCase_Id + RptMgrErrorHandler.b("뎒뾔붖뎘놚랜떞讠覢辤趦莨膪螬薮鮰", A_1) + Environment.NewLine);
          this.txtBoxProgressStatus.ScrollToEnd();
          break;
        default:
          goto case 1;
      }
    }
    catch (Exception ex)
    {
      int num = (int) System.Windows.MessageBox.Show(AppResources.Cannot_Log_Status_Any_Further, AppResources.Log_File_Error, MessageBoxButton.OK, MessageBoxImage.Exclamation);
    }
    short num1 = 1;
    if (num1 == (short) 0)
      ;
    num1 = (short) 0;
  }

  internal void Radio_updateStatus(double n, string stat)
  {
    int A_1 = 7;
    int num1 = 25;
    short num2;
    while (true)
    {
      switch (num1)
      {
        case 0:
          goto label_106;
        case 1:
          if (!(AppResources.ReadRadio_Reading_codeplug_from_radio == stat))
          {
            num2 = (short) 18;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          num2 = (short) 12;
          num1 = (int) (IntPtr) num2;
          continue;
        case 2:
          if (!(AppResources.ReadRadio_Calling_End_Read_Radio == stat))
          {
            num2 = (short) 14;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          num2 = (short) 5;
          num1 = (int) (IntPtr) num2;
          continue;
        case 3:
          goto label_89;
        case 4:
          goto label_15;
        case 5:
          goto label_32;
        case 6:
          goto label_94;
        case 7:
          num2 = (short) -22608;
          int num3 = (int) num2;
          num2 = (short) -22608;
          int num4 = (int) num2;
          switch (num3 == num4 ? 1 : 0)
          {
            case 0:
            case 2:
              goto label_40;
            default:
              goto label_114;
          }
        case 8:
          this.pbBatchProgrammingProgress.Value = (double) (int) (n * 100.0);
          num2 = (short) 34;
          num1 = (int) (IntPtr) num2;
          continue;
        case 9:
          goto label_38;
        case 10:
          if (!(AppResources.Unpack_failure_during_read == stat))
          {
            num2 = (short) 51;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          num2 = (short) 30;
          num1 = (int) (IntPtr) num2;
          continue;
        case 11:
          goto label_20;
        case 12:
          goto label_49;
        case 13:
          goto label_5;
        case 14:
          if (AppResources.Reading_radio_codeplug_completed == stat)
          {
            num2 = (short) 15;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          num2 = (short) 56;
          num1 = (int) (IntPtr) num2;
          continue;
        case 15:
          goto label_47;
        case 16 /*0x10*/:
          goto label_67;
        case 17:
          goto label_43;
        case 18:
          if (AppResources.Read_Radio_Verification_Start == stat)
          {
            num2 = (short) 50;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          num2 = (short) 29;
          num1 = (int) (IntPtr) num2;
          continue;
        case 19:
          if (AppResources.Read_Radio_Info_Complete == stat)
          {
            num2 = (short) 32 /*0x20*/;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          num2 = (short) 2;
          num1 = (int) (IntPtr) num2;
          continue;
        case 20:
          goto label_63;
        case 21:
          if (AppResources.Read_Radio_Info == stat)
          {
            num2 = (short) 4;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          num2 = (short) 19;
          num1 = (int) (IntPtr) num2;
          continue;
        case 22:
          goto label_85;
        case 23:
          if (!(AppResources.Open_Port_Complete == stat))
          {
            num2 = (short) 21;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          num2 = (short) 22;
          num1 = (int) (IntPtr) num2;
          continue;
        case 24:
          if (!(AppResources.LP_Begin_Language_Pack_Update == stat))
          {
            num2 = (short) 28;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          num2 = (short) 48 /*0x30*/;
          num1 = (int) (IntPtr) num2;
          continue;
        case 25:
          switch (0)
          {
            case 0:
              goto label_3;
            default:
              continue;
          }
        case 26:
label_40:
          if (!(AppResources.Read_Radio_Verification_Complete == stat))
          {
            num2 = (short) 33;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          num2 = (short) 37;
          num1 = (int) (IntPtr) num2;
          continue;
        case 27:
          goto label_24;
        case 28:
          if (stat.Contains(AppResources.A_recommended_radio_language_is_available))
          {
            num2 = (short) 41;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          num2 = (short) 44;
          num1 = (int) (IntPtr) num2;
          continue;
        case 29:
          if (!(AppResources.Read_Radio_Verification_ == stat))
          {
            num2 = (short) 26;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          num2 = (short) 20;
          num1 = (int) (IntPtr) num2;
          continue;
        case 30:
          goto label_90;
        case 31 /*0x1F*/:
          if (!(AppResources.Radio_Serial_Number_update_failed == stat))
          {
            num2 = (short) 46;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          num2 = (short) 6;
          num1 = (int) (IntPtr) num2;
          continue;
        case 32 /*0x20*/:
          goto label_33;
        case 33:
          if (AppResources.Read_Radio_Verification_Fail == stat)
          {
            num2 = (short) 16 /*0x10*/;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          num2 = (short) 10;
          num1 = (int) (IntPtr) num2;
          continue;
        case 34:
          num2 = (short) 0;
          if (AppResources.Opening_Port == stat)
          {
            num2 = (short) 53;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          num2 = (short) 23;
          num1 = (int) (IntPtr) num2;
          continue;
        case 35:
          goto label_34;
        case 36:
          goto label_19;
        case 37:
          goto label_42;
        case 38:
          if (AppResources.Radio_Serial_Number_updated == stat)
          {
            num2 = (short) 13;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          num2 = (short) 31 /*0x1F*/;
          num1 = (int) (IntPtr) num2;
          continue;
        case 39:
          if (stat.Contains(AppResources.Warning_System_Type_Not_Match_While_Batch_Clone))
          {
            num2 = (short) 7;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto label_117;
        case 40:
          if (!stat.Contains(AppResources.LP_Radio_display_Language_Not_Supported_By_this_radio))
          {
            num2 = (short) 39;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          num2 = (short) 47;
          num1 = (int) (IntPtr) num2;
          continue;
        case 41:
          goto label_95;
        case 42:
          goto label_116;
        case 43:
          if (AppResources.WriteRadio_Close_Port == stat)
          {
            num2 = (short) 17;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          num2 = (short) 55;
          num1 = (int) (IntPtr) num2;
          continue;
        case 44:
          if (!stat.Contains(AppResources.To_update_radio_language_please_write_via_USB))
          {
            num2 = (short) 52;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          num2 = (short) 27;
          num1 = (int) (IntPtr) num2;
          continue;
        case 45:
          if (!(AppResources.WriteRadio_Writing_codeplug_to_radio == stat))
          {
            num2 = (short) 54;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          num2 = (short) 11;
          num1 = (int) (IntPtr) num2;
          continue;
        case 46:
          if (AppResources.Password_validation_failed == stat)
          {
            num2 = (short) 9;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          num2 = (short) 24;
          num1 = (int) (IntPtr) num2;
          continue;
        case 47:
          goto label_75;
        case 48 /*0x30*/:
          goto label_48;
        case 49:
          stat = string.Empty;
          num2 = (short) 8;
          num1 = (int) (IntPtr) num2;
          continue;
        case 50:
          goto label_53;
        case 51:
          if (!(AppResources.Writing_radio_codeplug == stat))
          {
            num2 = (short) 45;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          num2 = (short) 0;
          num1 = (int) (IntPtr) num2;
          continue;
        case 52:
          if (stat.Contains(AppResources.Radio_is_Missing_one_or_more_files_to_support_radio_language))
          {
            num2 = (short) 36;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          num2 = (short) 40;
          num1 = (int) (IntPtr) num2;
          continue;
        case 53:
          goto label_74;
        case 54:
          if (AppResources.Writing_radio_codeplug_completed == stat)
          {
            num2 = (short) 42;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          num2 = (short) 1;
          if (num2 == (short) 0)
            ;
          num2 = (short) 43;
          num1 = (int) (IntPtr) num2;
          continue;
        case 55:
          if (!(AppResources.Radio_Erase_in_Progress_please_wait == stat))
          {
            num2 = (short) 38;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          num2 = (short) 3;
          num1 = (int) (IntPtr) num2;
          continue;
        case 56:
          if (AppResources.Reading_radio_codeplug_ == stat)
          {
            num2 = (short) 35;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          num2 = (short) 1;
          num1 = (int) (IntPtr) num2;
          continue;
        default:
label_3:
          if (stat == null)
          {
            num2 = (short) 49;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto case 8;
      }
    }
label_5:
    this.ProgText.Text = AppResources.Radio_Colon + RptMgrErrorHandler.b("ꪉ", A_1) + this.CurrentRadioID + RptMgrErrorHandler.b("ꖉ", A_1) + this.CurrentRadioIpAddress + RptMgrErrorHandler.b("ꪉ겋ꎍ붏늑뒓", A_1) + AppResources.Radio_Serial_Number_updated;
    this.WriteToLog_Cont();
    return;
label_15:
    this.ProgText.Text = AppResources.Radio_Colon + RptMgrErrorHandler.b("ꪉ", A_1) + this.CurrentRadioID + RptMgrErrorHandler.b("ꖉ", A_1) + this.CurrentRadioIpAddress + RptMgrErrorHandler.b("ꪉ겋ꎍ붏늑뒓", A_1) + AppResources.Read_radio_info_start_;
    this.WriteToLog_Cont();
    return;
label_19:
    this.ProgText.Text = AppResources.Radio_Colon + RptMgrErrorHandler.b("ꪉ", A_1) + this.CurrentRadioID + RptMgrErrorHandler.b("ꖉ", A_1) + this.CurrentRadioIpAddress + RptMgrErrorHandler.b("ꪉ겋ꎍ붏늑뒓", A_1) + stat;
    this.WriteToLog_Cont();
    return;
label_20:
    this.ProgText.Text = AppResources.Radio_Colon + RptMgrErrorHandler.b("ꪉ", A_1) + this.CurrentRadioID + RptMgrErrorHandler.b("ꖉ", A_1) + this.CurrentRadioIpAddress + RptMgrErrorHandler.b("ꪉ겋ꎍ붏늑뒓", A_1) + AppResources.Begin_write_to_radio;
    this.WriteToLog_Cont();
    return;
label_24:
    this.ProgText.Text = AppResources.Radio_Colon + RptMgrErrorHandler.b("ꪉ", A_1) + this.CurrentRadioID + RptMgrErrorHandler.b("ꖉ", A_1) + this.CurrentRadioIpAddress + RptMgrErrorHandler.b("ꪉ겋ꎍ붏늑뒓", A_1) + stat;
    this.WriteToLog_Cont();
    return;
label_32:
    this.ProgText.Text = AppResources.Radio_Colon + RptMgrErrorHandler.b("ꪉ", A_1) + this.CurrentRadioID + RptMgrErrorHandler.b("ꖉ", A_1) + this.CurrentRadioIpAddress + RptMgrErrorHandler.b("ꪉ겋ꎍ붏늑뒓", A_1) + AppResources.Read_radio_codeplug_complete;
    this.WriteToLog_Cont();
    return;
label_33:
    this.ProgText.Text = AppResources.Radio_Colon + RptMgrErrorHandler.b("ꪉ", A_1) + this.CurrentRadioID + RptMgrErrorHandler.b("ꖉ", A_1) + this.CurrentRadioIpAddress + RptMgrErrorHandler.b("ꪉ겋ꎍ붏늑뒓", A_1) + AppResources.Read_radio_info_complete_;
    this.WriteToLog_Cont();
    return;
label_34:
    this.ProgText.Text = AppResources.Radio_Colon + RptMgrErrorHandler.b("ꪉ", A_1) + this.CurrentRadioID + RptMgrErrorHandler.b("ꖉ", A_1) + this.CurrentRadioIpAddress + RptMgrErrorHandler.b("ꪉ겋ꎍ붏늑뒓", A_1) + AppResources.Read_Radio_Info_;
    this.WriteToLog_Cont();
    return;
label_38:
    this.ProgText.Text = AppResources.Radio_Colon + RptMgrErrorHandler.b("ꪉ", A_1) + this.CurrentRadioID + RptMgrErrorHandler.b("ꖉ", A_1) + this.CurrentRadioIpAddress + RptMgrErrorHandler.b("ꪉ겋ꎍ붏늑뒓", A_1) + AppResources.Password_validation_failed;
    this.WriteToLog_Failure();
    return;
label_42:
    this.ProgText.Text = AppResources.Radio_Colon + RptMgrErrorHandler.b("ꪉ", A_1) + this.CurrentRadioID + RptMgrErrorHandler.b("ꖉ", A_1) + this.CurrentRadioIpAddress + RptMgrErrorHandler.b("ꪉ겋ꎍ붏늑뒓", A_1) + AppResources.Read_Radio_Verification_Complete;
    this.WriteToLog_Cont();
    return;
label_43:
    this.ProgText.Text = AppResources.Radio_Colon + RptMgrErrorHandler.b("ꪉ", A_1) + this.CurrentRadioID + RptMgrErrorHandler.b("ꖉ", A_1) + this.CurrentRadioIpAddress + RptMgrErrorHandler.b("ꪉ겋ꎍ붏늑뒓", A_1) + AppResources.Write_radio_release_complete;
    this.WriteToLog_Cont();
    return;
label_47:
    this.ProgText.Text = AppResources.Radio_Colon + RptMgrErrorHandler.b("ꪉ", A_1) + this.CurrentRadioID + RptMgrErrorHandler.b("ꖉ", A_1) + this.CurrentRadioIpAddress + RptMgrErrorHandler.b("ꪉ겋ꎍ붏늑뒓", A_1) + AppResources.Reading_radio_codeplug_;
    this.WriteToLog_Cont();
    return;
label_48:
    this.ProgText.Text = AppResources.Radio_Colon + RptMgrErrorHandler.b("ꪉ", A_1) + this.CurrentRadioID + RptMgrErrorHandler.b("ꖉ", A_1) + this.CurrentRadioIpAddress + RptMgrErrorHandler.b("ꪉ겋ꎍ붏늑뒓", A_1) + AppResources.LP_Checking_Radio_Language_Settings;
    this.WriteToLog_Cont();
    return;
label_49:
    this.ProgText.Text = AppResources.Radio_Colon + RptMgrErrorHandler.b("ꪉ", A_1) + this.CurrentRadioID + RptMgrErrorHandler.b("ꖉ", A_1) + this.CurrentRadioIpAddress + RptMgrErrorHandler.b("ꪉ겋ꎍ붏늑뒓", A_1) + AppResources.Begin_read_codeplug;
    this.WriteToLog_Cont();
    return;
label_53:
    this.ProgText.Text = RptMgrErrorHandler.b("\uD889\uED8B\uEA8D憐\uFD91꺓뚕", A_1) + this.CurrentRadioID + RptMgrErrorHandler.b("ꖉ", A_1) + this.CurrentRadioIpAddress + RptMgrErrorHandler.b("ꪉ겋ꎍ붏늑뒓", A_1) + AppResources.Read_Radio_Verification_Start_;
    this.WriteToLog_Cont();
    return;
label_63:
    this.ProgText.Text = AppResources.Radio_Colon + RptMgrErrorHandler.b("ꪉ", A_1) + this.CurrentRadioID + RptMgrErrorHandler.b("ꖉ", A_1) + this.CurrentRadioIpAddress + RptMgrErrorHandler.b("ꪉ겋ꎍ붏늑뒓", A_1) + AppResources.Read_Radio_Verification_;
    this.WriteToLog_Cont();
    return;
label_67:
    this.ProgText.Text = AppResources.Radio_Colon + RptMgrErrorHandler.b("ꪉ", A_1) + this.CurrentRadioID + RptMgrErrorHandler.b("ꖉ", A_1) + this.CurrentRadioIpAddress + RptMgrErrorHandler.b("ꪉ겋ꎍ붏늑뒓", A_1) + AppResources.Read_Radio_Verification_Failure;
    this.WriteToLog_Failure();
    return;
label_74:
    this.ProgText.Text = AppResources.Radio_Colon + RptMgrErrorHandler.b("ꪉ", A_1) + this.CurrentRadioID + RptMgrErrorHandler.b("ꖉ", A_1) + this.CurrentRadioIpAddress + RptMgrErrorHandler.b("ꪉ겋ꎍ붏늑뒓", A_1) + AppResources.Opening_Connection_To_Radio;
    this.WriteToLog_Initial();
    return;
label_75:
    this.ProgText.Text = AppResources.Radio_Colon + RptMgrErrorHandler.b("ꪉ", A_1) + this.CurrentRadioID + RptMgrErrorHandler.b("ꖉ", A_1) + this.CurrentRadioIpAddress + RptMgrErrorHandler.b("ꪉ겋ꎍ붏늑뒓", A_1) + stat;
    this.WriteToLog_Cont();
    return;
label_85:
    this.ProgText.Text = AppResources.Radio_Colon + RptMgrErrorHandler.b("ꪉ", A_1) + this.CurrentRadioID + RptMgrErrorHandler.b("ꖉ", A_1) + this.CurrentRadioIpAddress + RptMgrErrorHandler.b("ꪉ겋ꎍ붏늑뒓", A_1) + AppResources.Connecting_opened_to_radio;
    this.WriteToLog_Cont();
    return;
label_89:
    this.ProgText.Text = AppResources.Radio_Colon + RptMgrErrorHandler.b("ꪉ", A_1) + this.CurrentRadioID + RptMgrErrorHandler.b("ꖉ", A_1) + this.CurrentRadioIpAddress + RptMgrErrorHandler.b("ꪉ겋ꎍ붏늑뒓", A_1) + AppResources.Radio_Erasing_please_wait;
    this.WriteToLog_Cont();
    return;
label_90:
    this.ProgText.Text = AppResources.Radio_Colon + RptMgrErrorHandler.b("ꪉ", A_1) + this.CurrentRadioID + RptMgrErrorHandler.b("ꖉ", A_1) + this.CurrentRadioIpAddress + RptMgrErrorHandler.b("ꪉ겋ꎍ붏늑뒓", A_1) + AppResources.Read_radio_unpack_failure;
    this.WriteToLog_Failure();
    return;
label_94:
    this.ProgText.Text = AppResources.Radio_Colon + RptMgrErrorHandler.b("ꪉ", A_1) + this.CurrentRadioID + RptMgrErrorHandler.b("ꖉ", A_1) + this.CurrentRadioIpAddress + RptMgrErrorHandler.b("ꪉ겋ꎍ붏늑뒓", A_1) + AppResources.Radio_Serial_Number_update_failed;
    this.WriteToLog_Failure();
    return;
label_95:
    this.ProgText.Text = AppResources.Radio_Colon + RptMgrErrorHandler.b("ꪉ", A_1) + this.CurrentRadioID + RptMgrErrorHandler.b("ꖉ", A_1) + this.CurrentRadioIpAddress + RptMgrErrorHandler.b("ꪉ겋ꎍ붏늑뒓", A_1) + stat;
    this.WriteToLog_Cont();
    return;
label_106:
    this.ProgText.Text = AppResources.Radio_Colon + RptMgrErrorHandler.b("ꪉ", A_1) + this.CurrentRadioID + RptMgrErrorHandler.b("ꖉ", A_1) + this.CurrentRadioIpAddress + RptMgrErrorHandler.b("ꪉ겋ꎍ붏늑뒓", A_1) + AppResources.Write_to_radio_in_progress;
    this.WriteToLog_Cont();
    return;
label_114:
    num2 = (short) 0;
    if (num2 == (short) 0)
      ;
    this.ProgText.Text = AppResources.Radio_Colon + RptMgrErrorHandler.b("ꪉ", A_1) + this.CurrentRadioID + RptMgrErrorHandler.b("ꖉ", A_1) + this.CurrentRadioIpAddress + RptMgrErrorHandler.b("ꪉ겋ꎍ붏늑뒓", A_1) + stat;
    this.WriteToLog_Cont();
    this.ProgText.Text = AppResources.Radio_Colon + RptMgrErrorHandler.b("ꪉ", A_1) + this.CurrentRadioID + RptMgrErrorHandler.b("ꖉ", A_1) + this.CurrentRadioIpAddress + RptMgrErrorHandler.b("ꪉ겋ꎍ붏늑뒓", A_1) + AppResources.No_Need_Retry_Batch_Programming;
    this.WriteToLog_Failure();
    return;
label_116:
    this.ProgText.Text = AppResources.Radio_Colon + RptMgrErrorHandler.b("ꪉ", A_1) + this.CurrentRadioID + RptMgrErrorHandler.b("ꖉ", A_1) + this.CurrentRadioIpAddress + RptMgrErrorHandler.b("ꪉ겋ꎍ붏늑뒓", A_1) + AppResources.Write_to_radio_complete;
    this.WriteToLog_Success();
    return;
label_117:
    this.ProgText.Text = AppResources.Radio_Colon + RptMgrErrorHandler.b("ꪉ", A_1) + this.CurrentRadioID + RptMgrErrorHandler.b("ꖉ", A_1) + this.CurrentRadioIpAddress + RptMgrErrorHandler.b("ꪉꆋꎍ낏", A_1) + stat;
    this.WriteToLog_Failure();
  }

  internal void CallMainFinish(int status)
  {
    short num1 = -3498;
    int num2 = (int) num1;
    num1 = (short) -3498;
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
        this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Delegate) new POP25BatchProgrammerProgress.MainFinish(this.CloneFinished), (object) status);
        break;
      default:
        goto case 1;
    }
  }

  internal void CloneFinished(int status)
  {
    int A_1 = 6;
    int num1 = 0;
    switch (num1)
    {
      default:
        POP25RadioInfo poP25RadioInfo;
        short num2;
        switch (0)
        {
          case 0:
label_3:
            poP25RadioInfo = new POP25RadioInfo();
            num2 = (short) 21;
            num1 = (int) (IntPtr) num2;
            goto default;
          default:
            while (true)
            {
              int num3;
              IEnumerator<POP25RadioInfo> enumerator;
              double num4;
              double num5;
              switch (num1)
              {
                case 0:
                  num2 = (short) 1;
                  if (num2 == (short) 0)
                    ;
                  this.pbOverallBatchProgrammingProgress.Value = num4 * 100.0;
                  num2 = (short) 47;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 1:
                case 39:
                case 82:
                  num2 = (short) 31 /*0x1F*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 2:
                  if (this.w.Count == 1)
                  {
                    num2 = (short) 60;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 3;
                case 3:
                case 35:
                  poP25RadioInfo.Status = AppResources.FAILED_All_UpperCase_Id;
                  num2 = (short) 29;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 4:
                  this.w.RemoveAt(0);
                  POP25RadioInfo radio1 = this.w[0];
                  this.dgBatchProgrammingProgress.SelectedItem = this.dgBatchProgrammingProgress.Items[radio1.IndexInList];
                  this.dgBatchProgrammingProgress.ScrollIntoView(this.dgBatchProgrammingProgress.Items[radio1.IndexInList]);
                  radio1.Status = AppResources.In_Progress;
                  this.CloneRadioUsingRadioIdOrRadioIp(radio1);
                  num2 = (short) 12;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 5:
                  if (status == 1)
                  {
                    num2 = (short) 15;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 11;
                case 6:
                case 36:
                  poP25RadioInfo.Status = AppResources.FAILED_All_UpperCase_Id;
                  num2 = (short) 1;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 7:
                  this.btnBatchProgrammingClose.IsEnabled = true;
                  this.btnSaveToFile.IsEnabled = true;
                  this.btnBatchProgrammingCancel.IsEnabled = false;
                  this.BatchProgrammingInProgress = false;
                  num2 = (short) 75;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 8:
                  if (status != 1)
                  {
                    num2 = (short) 41;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 30;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 9:
                  POP25RadioInfo radio2 = this.w[0];
                  this.dgBatchProgrammingProgress.SelectedItem = this.dgBatchProgrammingProgress.Items[radio2.IndexInList];
                  this.dgBatchProgrammingProgress.ScrollIntoView(this.dgBatchProgrammingProgress.Items[radio2.IndexInList]);
                  radio2.Status = AppResources.In_Progress;
                  this.CloneRadioUsingRadioIdOrRadioIp(radio2);
                  num2 = (short) 38;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 10:
                  num2 = (short) 44;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 11:
                case 69:
                  num2 = (short) 13;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 12:
                case 22:
                  num2 = (short) 57;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 13:
                  if (this.w.Count <= 1)
                  {
                    num2 = (short) 62;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 4;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 14:
                  try
                  {
                    num2 = (short) 1;
                    int num6 = (int) (IntPtr) num2;
                    while (true)
                    {
                      num2 = (short) -15746;
                      int num7 = (int) num2;
                      num2 = (short) -15746;
                      int num8 = (int) num2;
                      switch (num7 == num8 ? 1 : 0)
                      {
                        case 0:
                        case 2:
label_100:
                          switch (0)
                          {
                            case 0:
                              break;
                            default:
                              continue;
                          }
                          break;
                        default:
                          num2 = (short) 0;
                          if (num2 == (short) 0)
                            ;
                          switch (num6)
                          {
                            case 0:
                              if (enumerator.MoveNext())
                              {
                                this.w.Add(enumerator.Current);
                                num2 = (short) 3;
                                num6 = (int) (IntPtr) num2;
                                continue;
                              }
                              num2 = (short) 2;
                              num6 = (int) (IntPtr) num2;
                              continue;
                            case 1:
                              goto label_100;
                            case 2:
                              num2 = (short) 4;
                              num6 = (int) (IntPtr) num2;
                              continue;
                            case 4:
                              goto label_29;
                          }
                          break;
                      }
                      num2 = (short) 0;
                      num6 = (int) (IntPtr) num2;
                    }
                  }
                  finally
                  {
                    int num9 = 1;
                    while (true)
                    {
                      short num10;
                      switch (num9)
                      {
                        case 0:
                          enumerator.Dispose();
                          num10 = (short) 2;
                          num9 = (int) (IntPtr) num10;
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
                          goto label_115;
                      }
                      if (enumerator != null)
                      {
                        num10 = (short) 0;
                        num9 = (int) (IntPtr) num10;
                      }
                      else
                        break;
                    }
label_115:;
                  }
label_29:
                  this.totItems = (double) this.dgBatchProgrammingProgress.Items.Count;
                  this.v.Clear();
                  num2 = (short) 73;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 15:
                  num3 = DVRSXmlUtil.ExportDVRSAfterClone(this.j);
                  num2 = (short) 67;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 16 /*0x10*/:
                  if (this.v.Count > 0)
                  {
                    num2 = (short) 78;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 38;
                case 17:
                  num2 = (short) 46;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 18:
                  num2 = (short) 74;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 19:
                  this.v.Add(this.w.ElementAt<POP25RadioInfo>(0));
                  num2 = (short) 39;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 20:
                  poP25RadioInfo = this.w[0];
                  num2 = (short) 52;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 21:
                  if (this.w.Count > 0)
                  {
                    num2 = (short) 20;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 52;
                case 23:
                  if (!this.BatchProgrammingComplete)
                  {
                    num2 = (short) 18;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 7;
                case 24:
                  num2 = (short) 56;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 25:
                  num2 = (short) 16 /*0x10*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 26:
                  this.ProgText.Text = AppResources.User_Action_Batch_Programming_Cancelled;
                  this.txtBoxProgressStatus.AppendText(RptMgrErrorHandler.b("蒈膊", A_1) + DateTime.Now.ToString() + RptMgrErrorHandler.b("ꦈꚊꂌ꾎", A_1) + AppResources.User_Action_Batch_Programming_Cancelled + Environment.NewLine);
                  this.txtBoxProgressStatus.ScrollToEnd();
                  num2 = (short) 34;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 27:
                  num2 = (short) 49;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 28:
                  if (this.CurRetry == 0)
                  {
                    num2 = (short) 10;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  break;
                case 29:
                  if (this.RetryCount > 0)
                  {
                    num2 = (short) 19;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 1;
                case 30:
                  num2 = (short) 79;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 31 /*0x1F*/:
                  if (this.r)
                  {
                    num2 = (short) 71;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 63 /*0x3F*/;
                case 32 /*0x20*/:
                  if (this.CurRetry == 0)
                  {
                    num2 = (short) 64 /*0x40*/;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 68;
                case 33:
                  num2 = (short) 72;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 34:
                  goto label_131;
                case 37:
                  num2 = (short) 76;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 38:
                  num2 = (short) 23;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 40:
                  num2 = (short) 66;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 41:
                  if (status == -1)
                  {
                    num2 = (short) 37;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 28;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 42:
                  this.pbOverallBatchProgrammingProgress.Value = num4 * 100.0;
                  num2 = (short) 3;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 43:
                  if (this.RetryCount == 0)
                  {
                    num2 = (short) 70;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 3;
                case 44:
                  if (this.RetryCount == 0)
                  {
                    num2 = (short) 42;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  break;
                case 45:
                case 47:
                  poP25RadioInfo.Status = AppResources.SUCCESS_All_Uppercase_Id;
                  num2 = (short) 82;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 46:
                  if (this.CancelBatchProgramming)
                  {
                    num2 = (short) 26;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_141;
                case 48 /*0x30*/:
                  if (this.CurRetry == 0)
                  {
                    num2 = (short) 24;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 80 /*0x50*/;
                case 49:
                  if (!this.CancelBatchProgramming)
                  {
                    num2 = (short) 25;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 38;
                case 50:
                  if (this.v.Count <= 0)
                  {
                    num2 = (short) 55;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 12;
                case 51:
                  if (this.RetryCount != 0)
                  {
                    num2 = (short) 68;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 45;
                case 52:
                  num4 = ((double) poP25RadioInfo.IndexInList + 1.0) / this.totItems;
                  num5 = 100.0 / this.totItems;
                  num2 = (short) 8;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 53:
                  num2 = (short) 0;
                  this.ProgText.Text = AppResources.Radio_Colon + RptMgrErrorHandler.b("ꦈ", A_1) + this.CurrentRadioID + RptMgrErrorHandler.b("Ꚉ", A_1) + this.CurrentRadioIpAddress + RptMgrErrorHandler.b("ꦈꮊꂌꊎ놐뎒", A_1) + AppResources.Export_DVRS_MSU_Data_Failed_Error_Writing_File;
                  this.WriteToLog_Cont();
                  num2 = (short) 11;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 54:
                  this.pbOverallBatchProgrammingProgress.Value = num4 * 100.0;
                  num2 = (short) 6;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 55:
                  this.BatchProgrammingComplete = true;
                  num2 = (short) 22;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 56:
                  if (this.RetryCount != 0)
                  {
                    num2 = (short) 80 /*0x50*/;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 6;
                case 57:
                  if (this.w.Count == 0)
                  {
                    num2 = (short) 83;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 38;
                case 58:
                  num2 = (short) 43;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 59:
                  if (this.RetryCount > 0)
                  {
                    num2 = (short) 27;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 38;
                case 60:
                  this.pbOverallBatchProgrammingProgress.Value = 100.0;
                  num2 = (short) 35;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 61:
                  this.w.RemoveAt(0);
                  num2 = (short) 50;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 62:
                  if (this.w.Count == 1)
                  {
                    num2 = (short) 61;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 12;
                case 63 /*0x3F*/:
                  num2 = (short) 5;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 64 /*0x40*/:
                  num2 = (short) 51;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 65:
                  this.ProgText.Text = AppResources.Radio_Colon + RptMgrErrorHandler.b("ꦈ", A_1) + this.CurrentRadioID + RptMgrErrorHandler.b("Ꚉ", A_1) + this.CurrentRadioIpAddress + RptMgrErrorHandler.b("ꦈꮊꂌꊎ놐뎒", A_1) + AppResources.Export_DVRS_MSU_Data_Completed;
                  this.WriteToLog_Cont();
                  num2 = (short) 69;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 66:
                  if (this.RetryCount == 0)
                  {
                    num2 = (short) 0;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_86;
                case 67:
                  if (num3 == 1)
                  {
                    num2 = (short) 65;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 77;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 68:
                  this.pbOverallBatchProgrammingProgress.Value += num5;
                  num2 = (short) 45;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 70:
                  num2 = (short) 2;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 71:
                  RadioAccessValidator.RestoreCachedCodeplugSecurityFields(this.k, this.l, this.m, this.n, this.o, this.q, this.p);
                  num2 = (short) 63 /*0x3F*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 72:
                  if (this.RetryCount == 0)
                  {
                    num2 = (short) 54;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_65;
                case 73:
                  if (this.w.Count > 0)
                  {
                    num2 = (short) 9;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 38;
                case 74:
                  if (this.CancelBatchProgramming)
                  {
                    num2 = (short) 7;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_137;
                case 75:
                  if (!this.BatchProgrammingComplete)
                  {
                    num2 = (short) 17;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_135;
                case 76:
                  if (this.CurRetry == 0)
                  {
                    num2 = (short) 33;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_65;
                case 77:
                  if (num3 == 0)
                  {
                    num2 = (short) 53;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 11;
                case 78:
                  this.BatchProgrammingComplete = false;
                  --this.RetryCount;
                  ++this.CurRetry;
                  enumerator = this.v.GetEnumerator();
                  num2 = (short) 14;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 79:
                  if (this.CurRetry == 0)
                  {
                    num2 = (short) 40;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_86;
                case 80 /*0x50*/:
                  this.pbOverallBatchProgrammingProgress.Value += num5;
                  num2 = (short) 36;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 81:
                  if (this.CurRetry > 0)
                  {
                    num2 = (short) 58;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 3;
                case 83:
                  num2 = (short) 59;
                  num1 = (int) (IntPtr) num2;
                  continue;
                default:
                  goto label_3;
              }
              num2 = (short) 81;
              num1 = (int) (IntPtr) num2;
              continue;
label_65:
              num2 = (short) 48 /*0x30*/;
              num1 = (int) (IntPtr) num2;
              continue;
label_86:
              num2 = (short) 32 /*0x20*/;
              num1 = (int) (IntPtr) num2;
            }
label_131:
            return;
label_141:
            return;
label_137:
            return;
label_135:
            return;
        }
    }
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "5.0.10.0")]
  public void InitializeComponent()
  {
    int A_1 = 2;
    short num = 19430;
    switch ((short) 19430 == num ? 1 : 0)
    {
      case 0:
        break;
      case 2:
        break;
      default:
        num = (short) 0;
        if (num == (short) 0)
          ;
        num = (short) 1;
        if (num == (short) 0)
          ;
        if (this.ab)
          break;
        this.ab = true;
        System.Windows.Application.LoadComponent((object) this, new Uri(RptMgrErrorHandler.b("ꪄ풆麗\uEE8A\uEE8C\uE68E\uF090ﾒ펔\uF296\uF898\uEF9A\uE89C\uED9E쒠킢麤쒦욨욪\uDDAC삮\uDFB0횲\uDBB4쎶隸쮺튼쾾\uF3C0\uF6C2\uA7C4ꛆ뷈\uA8CAꗌ뿎ꏐ볒닔ꗖ룘뛚냜뫞鏠쳢闤裦駨\uD9EA\uD8EC跮郰蟲雴\u9FF6觸觺鋼飾猀戂栄樆氈礊紌紎縐琒朔爖樘栚㌜朞䀠丢䤤", A_1), UriKind.Relative));
        break;
    }
  }

  [EditorBrowsable(EditorBrowsableState.Never)]
  [GeneratedCode("PresentationBuildTasks", "5.0.10.0")]
  [DebuggerNonUserCode]
  void IComponentConnector.Connect(int connectionId, object target)
  {
    int num1 = 0;
    while (true)
    {
      short num2 = -4481;
      int num3 = (int) num2;
      num2 = (short) -4481;
      int num4 = (int) num2;
      switch (num3 == num4 ? 1 : 0)
      {
        case 0:
        case 2:
          goto label_22;
        default:
          num2 = (short) 0;
          if (num2 == (short) 0)
            ;
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
              num2 = (short) 2;
              num1 = (int) (IntPtr) num2;
              continue;
            case 2:
              goto label_27;
          }
          switch (connectionId)
          {
            case 1:
              goto label_22;
            case 2:
              goto label_12;
            case 3:
              goto label_10;
            case 4:
              goto label_16;
            case 5:
              goto label_21;
            case 6:
              goto label_19;
            case 7:
              goto label_23;
            case 8:
              goto label_26;
            case 9:
              goto label_15;
            case 10:
              goto label_9;
            case 11:
              goto label_25;
            case 12:
              goto label_13;
            case 13:
              goto label_8;
            case 14:
              goto label_24;
            case 15:
              goto label_11;
            case 16 /*0x10*/:
              goto label_17;
            case 17:
              goto label_14;
            case 18:
              goto label_18;
            default:
              num2 = (short) 0;
              num2 = (short) 1;
              if (num2 == (short) 0)
                ;
              num2 = (short) 1;
              num1 = (int) (IntPtr) num2;
              continue;
          }
      }
    }
label_8:
    this.txtBoxProgressStatus = (System.Windows.Controls.TextBox) target;
    return;
label_9:
    this.pbOverallBatchProgrammingProgress = (System.Windows.Controls.ProgressBar) target;
    return;
label_10:
    this.spBatchProgrammingIPAndStart = (StackPanel) target;
    return;
label_11:
    this.spBatchProgrammingRadioProgress = (StackPanel) target;
    return;
label_12:
    ((CommandBinding) target).Executed += new ExecutedRoutedEventHandler(this.btnProgressWndHelp_Click);
    ((CommandBinding) target).CanExecute += new CanExecuteRoutedEventHandler(this.F1HelpCommandCanExcute);
    return;
label_13:
    this.batProgressResultExpander = (Expander) target;
    this.batProgressResultExpander.Expanded += new RoutedEventHandler(this.batProgressResultExpander_Expanded);
    this.batProgressResultExpander.Collapsed += new RoutedEventHandler(this.batProgressResultExpander_Collapsed);
    return;
label_14:
    this.btnBatchProgrammingCancel = (System.Windows.Controls.Button) target;
    this.btnBatchProgrammingCancel.Click += new RoutedEventHandler(this.btnCancel_Click);
    return;
label_15:
    this.pbBatchProgrammingProgress = (System.Windows.Controls.ProgressBar) target;
    return;
label_16:
    this.txtboxArsServer = (System.Windows.Controls.TextBox) target;
    return;
label_17:
    this.btnBatchProgrammingClose = (System.Windows.Controls.Button) target;
    this.btnBatchProgrammingClose.Click += new RoutedEventHandler(this.btnClose_Click);
    return;
label_18:
    this.btnBatchProgrammingHelp = (System.Windows.Controls.Button) target;
    this.btnBatchProgrammingHelp.Click += new RoutedEventHandler(this.btnProgressWndHelp_Click);
    return;
label_19:
    this.spBackGround = (StackPanel) target;
    return;
label_21:
    this.dtProgressDateTime = (AcpTextBox) target;
    return;
label_22:
    this.This = (POP25BatchProgrammerProgress) target;
    this.This.Loaded += new RoutedEventHandler(this.OnLoaded);
    this.This.Unloaded += new RoutedEventHandler(this.OnUnLoaded);
    this.This.Closing += new CancelEventHandler(this.ProgressWindowClosing);
    return;
label_23:
    this.dgBatchProgrammingProgress = (System.Windows.Controls.DataGrid) target;
    return;
label_24:
    this.btnSaveToFile = (System.Windows.Controls.Button) target;
    this.btnSaveToFile.Click += new RoutedEventHandler(this.btnSaveAs_Click);
    return;
label_25:
    this.txtbxRetryCount = (System.Windows.Controls.TextBox) target;
    return;
label_26:
    this.ProgText = (System.Windows.Controls.TextBox) target;
    return;
label_27:
    this.ab = true;
  }

  public delegate void UpdateProgress(double n, string stat);

  private delegate void MainFinish(int status);

  public delegate void WriteRadioQuery(SpecialFeatures.Comms.Comms.RadioRtn info);

  private delegate int MainThreadUpdateRadioIds(RadioIdInfo tempRadioIds);

  private delegate void UpdateRadioOverallProgressBarDelegate(DependencyProperty dp, object val);

  private delegate void RadioPresent(
    POP25RadioInfo currentRadio,
    bool bPresenceReturn,
    string statusMsg,
    string networkError);
}
