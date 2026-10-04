// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.Programming.DeviceOpStatusWindow
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using AcpUI.Common;
using SpecialFeatures.AcpReportManagerLib;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;

#nullable disable
namespace SpecialFeatures.Programming;

public partial class DeviceOpStatusWindow : Window, IDisposable, IComponentConnector
{
  private bool a;
  private EventWaitHandle b;
  private EventWaitHandle c;
  private string d;
  internal TextBox statusText;
  private bool e;

  public string StatusMsg
  {
    set
    {
      int num1 = 2;
      while (true)
      {
        short num2;
        switch (num1)
        {
          case 0:
          case 3:
            goto label_10;
          case 1:
            num2 = (short) -1934;
            int num3 = (int) num2;
            num2 = (short) -1934;
            int num4 = (int) num2;
            switch (num3 == num4 ? 1 : 0)
            {
              case 0:
              case 2:
                this.d = value;
                num2 = (short) 3;
                num1 = (int) (IntPtr) num2;
                continue;
              default:
                num2 = (short) 0;
                if (num2 == (short) 0)
                  goto case 0;
                goto case 0;
            }
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
        num2 = (short) 0;
        if (value != null)
        {
          num2 = (short) 1;
          if (num2 == (short) 0)
            ;
          num2 = (short) 1;
          num1 = (int) (IntPtr) num2;
        }
        else
        {
          this.d = "";
          num2 = (short) 0;
          num1 = (int) (IntPtr) num2;
        }
      }
label_10:
      this.statusText.Text = this.d;
    }
  }

  internal EventWaitHandle WaitStatusThread
  {
    set
    {
      short num1 = -8039;
      int num2 = (int) num1;
      num1 = (short) -8039;
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
          this.c = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  internal EventWaitHandle CloseEventHandle
  {
    get
    {
      short num1 = -622;
      int num2 = (int) num1;
      num1 = (short) -622;
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
          return this.b;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = -5701;
      int num2 = (int) num1;
      num1 = (short) -5701;
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
          this.b = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  internal DeviceOpStatusWindow()
  {
    this.InitializeComponent();
    Utility.SetDirection((FrameworkElement) this);
    this.Topmost = true;
    this.statusText.Text = "";
    this.CloseEventHandle = new EventWaitHandle(false, EventResetMode.ManualReset);
    this.statusText.Background = (Brush) Brushes.OldLace;
    this.Background = (Brush) Brushes.OldLace;
    this.WindowStyle = WindowStyle.SingleBorderWindow;
  }

  internal void Run()
  {
    short num1 = -28319;
    int num2 = (int) num1;
    num1 = (short) -28319;
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
        this.Show();
        this.c.Set();
        this.CloseEventHandle.WaitOne();
        this.Close();
        this.CloseEventHandle.Close();
        this.c.Set();
        break;
      default:
        goto case 1;
    }
  }

  public void Dispose()
  {
    short num1 = 4549;
    int num2 = (int) num1;
    num1 = (short) 4549;
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
        this.a(true);
        GC.SuppressFinalize((object) this);
        break;
      default:
        goto case 1;
    }
  }

  private void a(bool A_0)
  {
    short num1 = 1;
    if (num1 == (short) 0)
      ;
    num1 = (short) 1;
    int num2 = (int) (IntPtr) num1;
    while (true)
    {
      switch (num2)
      {
        case 0:
label_6:
          this.CloseEventHandle.Set();
          num1 = (short) 2;
          num2 = (int) (IntPtr) num1;
          continue;
        case 1:
          num1 = (short) 0;
          switch (0)
          {
            case 0:
              break;
            default:
              continue;
          }
          break;
        case 2:
          num1 = (short) -4786;
          int num3 = (int) num1;
          num1 = (short) -4786;
          int num4 = (int) num1;
          switch (num3 == num4 ? 1 : 0)
          {
            case 0:
            case 2:
              goto label_6;
            default:
              goto label_8;
          }
      }
      if (!this.a)
      {
        num1 = (short) 0;
        num2 = (int) (IntPtr) num1;
      }
      else
        goto label_9;
    }
label_8:
    num1 = (short) 0;
    if (num1 == (short) 0)
      ;
label_9:
    this.a = true;
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "5.0.10.0")]
  public void InitializeComponent()
  {
    int A_1 = 2;
    if (this.e)
    {
label_1:
      short num1 = 1;
      if (num1 == (short) 0)
        ;
      num1 = (short) 24893;
      int num2 = (int) num1;
      num1 = (short) 24893;
      int num3 = (int) num1;
      switch (num2 == num3 ? 1 : 0)
      {
        case 0:
        case 2:
          goto label_1;
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
      this.e = true;
      Application.LoadComponent((object) this, new Uri(RptMgrErrorHandler.b("ꪄ풆麗\uEE8A\uEE8C\uE68E\uF090ﾒ펔\uF296\uF898\uEF9A\uE89C\uED9E쒠킢麤쒦욨욪\uDDAC삮\uDFB0횲\uDBB4쎶隸쮺쾼킾ꛀ뇂꓄\uAAC6\uA4C8ꋊꏌ꣎ﻐ럒냔ꇖ냘룚룜냞釠郢釤蛦鷨黪黬飮飰鷲釴飶軸헺藼黾氀漂", A_1), UriKind.Relative));
    }
  }

  [EditorBrowsable(EditorBrowsableState.Never)]
  [GeneratedCode("PresentationBuildTasks", "5.0.10.0")]
  [DebuggerNonUserCode]
  void IComponentConnector.Connect(int connectionId, object target)
  {
    if (connectionId == 1)
    {
label_1:
      short num1 = 461;
      int num2 = (int) num1;
      num1 = (short) 461;
      int num3 = (int) num1;
      switch (num2 == num3 ? 1 : 0)
      {
        case 0:
        case 2:
          goto label_1;
        default:
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          num1 = (short) 0;
          num1 = (short) 1;
          if (num1 == (short) 0)
            ;
          this.statusText = (TextBox) target;
          break;
      }
    }
    else
      this.e = true;
  }
}
