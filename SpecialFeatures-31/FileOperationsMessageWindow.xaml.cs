// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.FileOperations.MessageWindow
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
namespace SpecialFeatures.FileOperations;

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

  internal MessageWindow(string messageText, string title)
  {
    this.InitializeComponent();
    this.ProgText.Text = messageText;
    this.operationLabel.Content = (object) title;
    Utility.SetDirection((FrameworkElement) this);
  }

  private void Window_MouseLeftButtonDown(object A_0, MouseButtonEventArgs A_1)
  {
    int num1 = 1;
    while (true)
    {
      short num2 = -3429;
      int num3 = (int) num2;
      num2 = (short) -3429;
      int num4 = (int) num2;
      switch (num3 == num4 ? 1 : 0)
      {
        case 0:
        case 2:
label_10:
          num2 = (short) 2;
          num1 = (int) (IntPtr) num2;
          continue;
        default:
          num2 = (short) 1;
          if (num2 == (short) 0)
            ;
          num2 = (short) 0;
          if (num2 == (short) 0)
            ;
          switch (num1)
          {
            case 0:
              this.OnMouseLeftButtonDown(A_1);
              this.DragMove();
              goto label_10;
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
              goto label_8;
          }
          if (A_1.ChangedButton == MouseButton.Left)
          {
            num2 = (short) 0;
            num2 = (short) 0;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto label_11;
      }
    }
label_8:
    return;
label_11:;
  }

  private void ObButtonClick_Close(object A_0, RoutedEventArgs A_1)
  {
    short num1 = -32430;
    int num2 = (int) num1;
    num1 = (short) -32430;
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
        break;
      default:
        goto case 1;
    }
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "5.0.10.0")]
  public void InitializeComponent()
  {
    int A_1 = 3;
    short num1 = -16650;
    int num2 = (int) num1;
    num1 = (short) -16650;
    int num3 = (int) num1;
    switch (num2 == num3 ? 1 : 0)
    {
      case 0:
      case 2:
        this.a = true;
        Application.LoadComponent((object) this, new Uri(RptMgrErrorHandler.b("ꦅ\uDB87憎\uE98B\uED8D憐\uF391\uF893킕ﶗﮙ\uE89B\uEB9D튟잡힣鶥쮧얩솫\uDEAD\uDFAF\uDCB1톳\uD8B5첷閹\uDABBힽ겿\uA7C1ꯃ뛅귇룉귋뫍맏뷑뫓ꗕ\uF7D7럙맛귝鏟菡菣菥\u9FE7菩苫諭\u9FEF藱\uDAF3軵駷韹郻", A_1), UriKind.Relative));
        break;
      case 1:
        short num4 = 1;
        if (num4 == (short) 0)
          ;
        num4 = (short) 0;
        if (num4 == (short) 0)
          ;
        if (this.a)
          break;
        goto case 0;
      default:
        goto case 1;
    }
  }

  [EditorBrowsable(EditorBrowsableState.Never)]
  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "5.0.10.0")]
  void IComponentConnector.Connect(int connectionId, object target)
  {
    int num1 = 1;
    while (true)
    {
      short num2;
      switch (num1)
      {
        case 0:
          num2 = (short) -31937;
          int num3 = (int) num2;
          num2 = (short) -31937;
          int num4 = (int) num2;
          switch (num3 == num4 ? 1 : 0)
          {
            case 0:
            case 2:
              goto label_6;
            default:
              num2 = (short) 1;
              if (num2 == (short) 0)
                ;
              num2 = (short) 0;
              if (num2 == (short) 0)
                ;
              num2 = (short) 0;
              num2 = (short) 2;
              num1 = (int) (IntPtr) num2;
              continue;
          }
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
          goto label_14;
        case 3:
label_6:
          num2 = (short) 4;
          num1 = (int) (IntPtr) num2;
          continue;
        case 4:
          if (connectionId != 2)
          {
            num2 = (short) 0;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto label_13;
      }
      if (connectionId != 1)
      {
        num2 = (short) 3;
        num1 = (int) (IntPtr) num2;
      }
      else
        break;
    }
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
