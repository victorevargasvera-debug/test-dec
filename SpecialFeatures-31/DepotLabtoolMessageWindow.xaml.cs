// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.DepotLabtool.MessageWindow
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using AcpUI.Common;
using SpecialFeatures.AcpReportManagerLib;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;

#nullable disable
namespace SpecialFeatures.DepotLabtool;

public partial class MessageWindow : Window, IComponentConnector
{
  internal Label operationLabel;
  internal TextBox ProgText;
  private bool a;

  public MessageWindow()
  {
    this.InitializeComponent();
    Utility.SetDirection((FrameworkElement) this);
  }

  public MessageWindow(string messageText)
  {
    this.InitializeComponent();
    this.ProgText.Text = messageText;
    Utility.SetDirection((FrameworkElement) this);
  }

  public MessageWindow(string messageText, string title)
  {
    this.InitializeComponent();
    this.ProgText.Text = messageText;
    this.operationLabel.Content = (object) title;
    Utility.SetDirection((FrameworkElement) this);
  }

  private void Window_MouseLeftButtonDown(object A_0, MouseButtonEventArgs A_1)
  {
    int num1 = 1;
    short num2;
    while (true)
    {
      switch (num1)
      {
        case 0:
label_8:
          num2 = (short) 0;
          this.OnMouseLeftButtonDown(A_1);
          this.DragMove();
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
          goto label_9;
        default:
label_3:
          if (A_1.ChangedButton == MouseButton.Left)
          {
            num2 = (short) -809;
            int num3 = (int) num2;
            num2 = (short) -809;
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
                num2 = (short) 1;
                if (num2 == (short) 0)
                  ;
                num2 = (short) 0;
                num1 = (int) (IntPtr) num2;
                continue;
            }
          }
          else
            goto label_10;
      }
    }
label_9:
    return;
label_10:;
  }

  private void ObButtonClick_Close(object A_0, RoutedEventArgs A_1)
  {
    short num1 = 13868;
    int num2 = (int) num1;
    num1 = (short) 13868;
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
          break;
        break;
      default:
        goto case 1;
    }
  }

  [GeneratedCode("PresentationBuildTasks", "5.0.10.0")]
  [DebuggerNonUserCode]
  public void InitializeComponent()
  {
    int A_1 = 19;
    short num1 = 1;
    if (num1 == (short) 0)
      ;
    if (this.a)
    {
label_4:
      num1 = (short) 0;
      num1 = (short) -21045;
      int num2 = (int) num1;
      num1 = (short) -21045;
      int num3 = (int) num1;
      switch (num2 == num3 ? 1 : 0)
      {
        case 0:
        case 2:
          goto label_4;
        default:
          num1 = (short) 0;
          if (num1 == (short) 0)
            break;
          break;
      }
    }
    else
    {
      this.a = true;
      Application.LoadComponent((object) this, new Uri(RptMgrErrorHandler.b("릕쮗\uEA99鍊ﶝ즟쎡좣\uE0A5춧쮩\uD8AB\uDBAD슯ힱ잳趵\uDBB7햹톻캽꾿곁ꇃ\uA8C5볇\uE5C9\uA8CBꯍꃏ뷑ꃓ뫕맗룙\uA8DB뇝迟軡쯣该跧駩\u9FEB迭韯韱菳\u9FF5雷黹鏻觽\u2EFF稁攃欅搇", A_1), UriKind.Relative));
    }
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "5.0.10.0")]
  [EditorBrowsable(EditorBrowsableState.Never)]
  void IComponentConnector.Connect(int connectionId, object target)
  {
    int num1 = 1;
    while (true)
    {
      short num2;
      switch (num1)
      {
        case 0:
          if (connectionId != 2)
          {
            num2 = (short) 4;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto label_13;
        case 1:
          num2 = (short) 0;
          switch (0)
          {
            case 0:
              break;
            default:
              continue;
          }
          break;
        case 2:
          goto label_14;
        case 3:
          num2 = (short) 0;
          num1 = (int) (IntPtr) num2;
          continue;
        case 4:
          num2 = (short) 2;
          num1 = (int) (IntPtr) num2;
          continue;
      }
      if (connectionId != 1)
      {
        num2 = (short) -7415;
        int num3 = (int) num2;
        num2 = (short) -7415;
        int num4 = (int) num2;
        switch (num3 == num4 ? 1 : 0)
        {
          case 0:
          case 2:
            goto label_8;
          default:
            num2 = (short) 1;
            if (num2 == (short) 0)
              ;
            num2 = (short) 0;
            if (num2 == (short) 0)
              ;
            num2 = (short) 3;
            num1 = (int) (IntPtr) num2;
            continue;
        }
      }
      else
        break;
    }
label_8:
    this.operationLabel = (Label) target;
    this.operationLabel.MouseDown += new MouseButtonEventHandler(this.Window_MouseLeftButtonDown);
    return;
label_13:
    this.ProgText = (TextBox) target;
    return;
label_14:
    this.a = true;
  }
}
