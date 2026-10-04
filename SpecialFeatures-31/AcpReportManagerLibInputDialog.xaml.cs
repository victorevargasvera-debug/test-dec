// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.AcpReportManagerLib.InputDialog
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using AcpUI.Common;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

#nullable disable
namespace SpecialFeatures.AcpReportManagerLib;

public partial class InputDialog : Window, IComponentConnector
{
  public bool click;
  private int a;
  internal TextBox txtUserInput;
  internal Button BtnOk;
  private bool b;

  internal InputDialog()
  {
    this.InitializeComponent();
    this.Page = 0;
    Utility.SetDirection((FrameworkElement) this);
  }

  internal void OnClick(object sender, RoutedEventArgs e)
  {
    short num1 = 0;
    num1 = (short) -10808;
    int num2 = (int) num1;
    num1 = (short) -10808;
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
        this.click = true;
        break;
      default:
        goto case 1;
    }
  }

  internal void OnClosed(object sender, EventArgs e)
  {
    short num1 = -21711;
    int num2 = (int) num1;
    num1 = (short) -21711;
    int num3 = (int) num1;
    switch (num2 == num3)
    {
      case true:
        num1 = (short) 0;
        if (num1 == (short) 0)
          ;
        num1 = (short) 1;
        if (num1 == (short) 0)
          break;
        break;
      default:
        goto case 1;
    }
  }

  internal int Page
  {
    get
    {
      short num = -13254;
      switch ((short) -13254 == num)
      {
        case true:
          num = (short) 1;
          if (num == (short) 0)
            ;
          num = (short) 0;
          if (num == (short) 0)
            ;
          return this.a;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = 0;
      num1 = (short) 19878;
      int num2 = (int) num1;
      num1 = (short) 19878;
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
          this.a = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "5.0.10.0")]
  public void InitializeComponent()
  {
    int A_1 = 14;
    short num1 = 2487;
    int num2 = (int) num1;
    num1 = (short) 2487;
    int num3 = (int) num1;
    switch (num2 == num3 ? 1 : 0)
    {
      case 0:
      case 2:
        this.b = true;
        Application.LoadComponent((object) this, new Uri(RptMgrErrorHandler.b("뺐삒\uE594\uF296滛\uF29Aﲜ\uF39E\uE7A0욢쒤펦\uDCA8\uD9AA좬\uDCAE誰킲\uDAB4\uDAB6즸풺펼\uDABE꿀럂\uEAC4ꛆ\uAAC8믊뿌\uAACEꇐ볒\uA7D4ꏖ듘뫚돜뻞蛠蛢韤详胨觪심蛮\u9FF0菲胴菶鷸鋺鳼鏾渀搂⬄缆栈昊愌", A_1), UriKind.Relative));
        break;
      default:
        short num4 = 1;
        if (num4 == (short) 0)
          ;
        num4 = (short) 0;
        if (num4 == (short) 0)
          ;
        if (this.b)
        {
          num4 = (short) 0;
          break;
        }
        goto case 0;
    }
  }

  [DebuggerNonUserCode]
  [EditorBrowsable(EditorBrowsableState.Never)]
  [GeneratedCode("PresentationBuildTasks", "5.0.10.0")]
  void IComponentConnector.Connect(int connectionId, object target)
  {
    int num1 = 0;
    short num2;
    while (true)
    {
      num2 = (short) 1;
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
          goto label_12;
        case 2:
          num2 = (short) -6998;
          int num3 = (int) num2;
          num2 = (short) -6998;
          int num4 = (int) num2;
          switch (num3 == num4 ? 1 : 0)
          {
            case 0:
            case 2:
              goto label_7;
            default:
              num2 = (short) 0;
              if (num2 == (short) 0)
                ;
              num2 = (short) 1;
              num1 = (int) (IntPtr) num2;
              continue;
          }
      }
      switch (connectionId)
      {
        case 1:
          goto label_7;
        case 2:
          goto label_6;
        case 3:
          goto label_11;
        default:
          num2 = (short) 2;
          num1 = (int) (IntPtr) num2;
          continue;
      }
    }
label_6:
    this.txtUserInput = (TextBox) target;
    return;
label_7:
    ((Window) target).Closing += new CancelEventHandler(this.OnClosed);
    return;
label_11:
    num2 = (short) 0;
    this.BtnOk = (Button) target;
    this.BtnOk.Click += new RoutedEventHandler(this.OnClick);
    return;
label_12:
    this.b = true;
  }
}
