// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.CxfFilePassword.View.CxfFileInitializePasswordPrompt
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using AcpUI.Common;
using SpecialFeatures.AcpReportManagerLib;
using SpecialFeatures.CxfFilePassword.ViewModel;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

#nullable disable
namespace SpecialFeatures.CxfFilePassword.View;

public partial class CxfFileInitializePasswordPrompt : Window, IComponentConnector
{
  internal PasswordBox CxfFilePasswordBox;
  internal PasswordBox CxfFileRepeatPasswordBox;
  private bool a;

  public CxfFileInitializePasswordPrompt()
  {
    this.InitializeComponent();
    Utility.SetDirection((FrameworkElement) this);
  }

  private void CxfFilePasswordBoxChanged(object A_0, RoutedEventArgs A_1)
  {
    int num1 = 0;
    while (true)
    {
      short num2;
      switch (num1)
      {
        case 0:
          num2 = (short) 0;
          num2 = (short) -16475;
          int num3 = (int) num2;
          num2 = (short) -16475;
          int num4 = (int) num2;
          switch (num3 == num4 ? 1 : 0)
          {
            case 0:
              goto label_11;
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
          ((CxfFileInitializePasswordPromptViewModel) this.DataContext).ProvidedPassword = ((PasswordBox) A_0).SecurePassword;
          num2 = (short) 2;
          num1 = (int) (IntPtr) num2;
          continue;
        case 2:
          goto label_12;
      }
      if (this.DataContext != null)
      {
        num2 = (short) 1;
        num1 = (int) (IntPtr) num2;
      }
      else
        goto label_1;
    }
label_11:
    return;
label_9:
    return;
label_12:
    return;
label_1:;
  }

  private void CxfFileRepeatPasswordBoxChanged(object A_0, RoutedEventArgs A_1)
  {
    int num1 = 0;
    short num2;
    while (true)
    {
      switch (num1)
      {
        case 0:
          num2 = (short) 0;
          num2 = (short) 7469;
          int num3 = (int) num2;
          num2 = (short) 7469;
          int num4 = (int) num2;
          switch (num3 == num4 ? 1 : 0)
          {
            case 0:
              goto label_11;
            case 2:
              goto label_8;
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
          ((CxfFileInitializePasswordPromptViewModel) this.DataContext).ConfirmProvidedPassword = ((PasswordBox) A_0).SecurePassword;
          num2 = (short) 2;
          num1 = (int) (IntPtr) num2;
          continue;
        case 2:
          goto label_10;
      }
      if (this.DataContext != null)
      {
        num2 = (short) 1;
        num1 = (int) (IntPtr) num2;
      }
      else
        goto label_1;
    }
label_11:
    return;
label_8:
    return;
label_1:
    return;
label_10:
    num2 = (short) 1;
    if (num2 == (short) 0)
      ;
  }

  [GeneratedCode("PresentationBuildTasks", "5.0.10.0")]
  [DebuggerNonUserCode]
  public void InitializeComponent()
  {
    int A_1 = 14;
    short num1;
    while (this.a)
    {
      num1 = (short) -18961;
      int num2 = (int) num1;
      num1 = (short) -18961;
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
    num1 = (short) 0;
    this.a = true;
    Application.LoadComponent((object) this, new Uri(RptMgrErrorHandler.b("뺐삒\uE594\uF296滛\uF29Aﲜ\uF39E\uE7A0욢쒤펦\uDCA8\uD9AA좬\uDCAE誰킲\uDAB4\uDAB6즸풺펼\uDABE꿀럂\uEAC4꓆뇈귊ꯌꛎ뷐뛒ꗔ뛖\uAAD8\uA8DAꫜ냞鏠蟢쫤釦胨軪髬샮鋰诲鏴釶郸韺飼雾漀樂焄渆栈朊搌甎琐挒琔搖樘氚爜洞䔠匢圤䠦䐨嬪夬Į䤰刲場嬶", A_1), UriKind.Relative));
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
      num2 = (short) -17971;
      int num3 = (int) num2;
      num2 = (short) -17971;
      int num4 = (int) num2;
      switch (num3 == num4 ? 1 : 0)
      {
        case 0:
        case 2:
label_9:
          num2 = (short) 1;
          num1 = (int) (IntPtr) num2;
          continue;
        default:
          num2 = (short) 0;
          if (num2 == (short) 0)
            ;
          num2 = (short) 0;
          switch (num1)
          {
            case 0:
              num2 = (short) 4;
              num1 = (int) (IntPtr) num2;
              continue;
            case 1:
              goto label_14;
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
              goto label_9;
            case 4:
              if (connectionId != 2)
              {
                num2 = (short) 3;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_13;
          }
          if (connectionId != 1)
          {
            num2 = (short) 0;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto label_7;
      }
    }
label_7:
    num2 = (short) 1;
    if (num2 == (short) 0)
      ;
    this.CxfFilePasswordBox = (PasswordBox) target;
    this.CxfFilePasswordBox.PasswordChanged += new RoutedEventHandler(this.CxfFilePasswordBoxChanged);
    return;
label_13:
    this.CxfFileRepeatPasswordBox = (PasswordBox) target;
    this.CxfFileRepeatPasswordBox.PasswordChanged += new RoutedEventHandler(this.CxfFileRepeatPasswordBoxChanged);
    return;
label_14:
    this.a = true;
  }
}
