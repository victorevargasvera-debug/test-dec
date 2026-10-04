// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.ReadWritePassword.InitReadWritePassword
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using ACPBrowser;
using AcpUI.Common;
using CommonResources;
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
namespace SpecialFeatures.ReadWritePassword;

public partial class InitReadWritePassword : Window, IComponentConnector
{
  private string a = string.Empty;
  internal PasswordBox ConfirmpasswordBox;
  internal PasswordBox EnterPasswordBox;
  internal Button Okbutton;
  internal Button CancelButton;
  internal Label ConfirmPasswordText;
  internal Label EnterPasswordText;
  internal Label label1;
  internal CheckBox RememberPasswordSession;
  internal Button initialPasswdHelpButton;
  private bool b;

  public InitReadWritePassword()
  {
    this.InitializeComponent();
    Utility.SetDirection((FrameworkElement) this);
    this.EnterPasswordBox.Focus();
  }

  internal string UserEnteredPassword
  {
    get
    {
      short num1 = 29770;
      int num2 = (int) num1;
      num1 = (short) 29770;
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
          return this.a;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = 9921;
      int num2 = (int) num1;
      num1 = (short) 9921;
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
          this.a = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  private void OnClickCancel(object A_0, RoutedEventArgs A_1)
  {
    short num1 = -2280;
    int num2 = (int) num1;
    num1 = (short) -2280;
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
        this.Close();
        break;
      default:
        goto case 1;
    }
  }

  private void OnClickOK(object A_0, RoutedEventArgs A_1)
  {
    try
    {
      int num1 = 0;
      switch (num1)
      {
        default:
          string password1;
          string password2;
          bool flag;
          char[] charArray;
          int index;
          short num2;
          switch (0)
          {
            case 0:
label_3:
              password1 = this.EnterPasswordBox.Password;
              password2 = this.ConfirmpasswordBox.Password;
              flag = false;
              charArray = password2.ToCharArray();
              index = 0;
              num2 = (short) 8;
              num1 = (int) (IntPtr) num2;
              goto default;
            default:
              while (true)
              {
                switch (num1)
                {
                  case 0:
                    num2 = (short) 20;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  case 1:
                    num2 = (short) 5;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  case 2:
                    flag = true;
                    num2 = (short) 3;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  case 3:
                    ++index;
                    num2 = (short) 16 /*0x10*/;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  case 4:
                    if (password1 != null)
                    {
                      num2 = (short) 0;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    }
                    break;
                  case 5:
                    if (!flag)
                    {
                      num2 = (short) 7;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    }
                    break;
                  case 6:
                    num2 = (short) 12;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  case 7:
                    this.a = password1;
                    this.Close();
                    num2 = (short) 18;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  case 8:
                  case 16 /*0x10*/:
                    num2 = (short) 10;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  case 9:
                    num2 = (short) 4;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  case 10:
                    if (index < charArray.Length)
                    {
                      num2 = (short) 11;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    }
                    num2 = (short) 6;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  case 11:
                    if (charArray[index] >= '\u0080')
                    {
                      num2 = (short) 2;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    }
                    goto case 3;
                  case 12:
                    if (!(password1 == password2))
                    {
                      int num3 = (int) MessageBox.Show(AppResources.New_Passwords_Do_Not_Match, AppResources.APX_CPS, MessageBoxButton.OK, MessageBoxImage.Exclamation, MessageBoxResult.OK);
                      num2 = (short) 13;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    }
                    goto label_21;
                  case 13:
                  case 17:
                  case 18:
                    num2 = (short) 15;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  case 14:
                    num2 = (short) 19;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  case 15:
                    goto label_36;
                  case 19:
                    if (password1.Length <= 16 /*0x10*/)
                    {
                      num2 = (short) 1;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    }
                    break;
                  case 20:
                    if (password1.Length >= 6)
                    {
                      num2 = (short) 14;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    }
                    break;
                  default:
                    goto label_3;
                }
                num2 = (short) 12742;
                int num4 = (int) num2;
                num2 = (short) 12742;
                int num5 = (int) num2;
                switch (num4 == num5 ? 1 : 0)
                {
                  case 0:
                  case 2:
                    break;
                  default:
                    num2 = (short) 0;
                    if (num2 == (short) 0)
                      ;
                    int num6 = (int) MessageBox.Show(AppResources.Must_Contain_6_to_16_Characters, AppResources.APX_CPS, MessageBoxButton.OK, MessageBoxImage.Exclamation, MessageBoxResult.OK);
                    num2 = (short) 17;
                    num1 = (int) (IntPtr) num2;
                    continue;
                }
label_21:
                num2 = (short) 9;
                num1 = (int) (IntPtr) num2;
              }
          }
      }
    }
    catch (Exception ex)
    {
    }
label_36:
    if (false)
      ;
  }

  private void F1HelpCommandCanExcute(object A_0, CanExecuteRoutedEventArgs A_1)
  {
    short num1 = 21931;
    int num2 = (int) num1;
    num1 = (short) 21931;
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

  private void OnHelpButton_Click(object A_0, RoutedEventArgs A_1)
  {
    int A_1_1 = 1;
    try
    {
      short num1 = -25509;
      int num2 = (int) num1;
      num1 = (short) -25509;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          Utility.CloseHelpWindowIfOpen();
          Utility.DisplayCPSHelpDITA(RptMgrErrorHandler.b("ꞃ뾅릇릉벋\uEB8D\uF48Fꎑꎓ", A_1_1));
          break;
        default:
          goto case 1;
      }
    }
    catch (Exception ex)
    {
    }
    short num = 0;
    num = (short) 1;
    if (num == (short) 0)
      ;
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "5.0.10.0")]
  public void InitializeComponent()
  {
    int A_1 = 17;
    if (!this.b)
      goto label_2;
label_1:
    return;
label_2:
    switch (true ? 1 : 0)
    {
      case 0:
      case 2:
        goto label_1;
      default:
        if (false)
          ;
        if (true)
          ;
        this.b = true;
        Application.LoadComponent((object) this, new Uri(RptMgrErrorHandler.b("뮓얕\uE897ﾙﾛ\uF79D솟캡\uE2A3쎥즧\uDEA9\uD9AB\uDCAD햯솱辳햵ힷힹ첻톽꺿\uA7C1\uAAC3닅\uE7C7룉꧋꿍듏ꗑꛓ뿕곗뿙곛뿝鏟釡鏣觥髧軩쏫蟭黯鯱胳蓵鷷鯹飻觽狿欁瀃挅砇欉缋納朏紑易爕㘗戙紛猝䰟", A_1), UriKind.Relative));
        break;
    }
  }

  [EditorBrowsable(EditorBrowsableState.Never)]
  [GeneratedCode("PresentationBuildTasks", "5.0.10.0")]
  [DebuggerNonUserCode]
  void IComponentConnector.Connect(int connectionId, object target)
  {
    int num1 = 1;
    short num2;
    while (true)
    {
      switch (num1)
      {
        case 0:
          goto label_19;
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
          num2 = (short) 0;
          num2 = (short) 0;
          num1 = (int) (IntPtr) num2;
          continue;
      }
      switch (connectionId)
      {
        case 1:
          goto label_8;
        case 2:
          goto label_16;
        case 3:
          goto label_18;
        case 4:
          goto label_15;
        case 5:
          goto label_7;
        case 6:
          goto label_17;
        case 7:
          goto label_6;
        case 8:
          goto label_10;
        case 9:
          goto label_9;
        case 10:
          goto label_11;
        default:
          num2 = (short) 2;
          num1 = (int) (IntPtr) num2;
          continue;
      }
    }
label_6:
    this.EnterPasswordText = (Label) target;
    return;
label_7:
    this.CancelButton = (Button) target;
    this.CancelButton.Click += new RoutedEventHandler(this.OnClickCancel);
    return;
label_8:
    ((CommandBinding) target).Executed += new ExecutedRoutedEventHandler(this.OnHelpButton_Click);
    ((CommandBinding) target).CanExecute += new CanExecuteRoutedEventHandler(this.F1HelpCommandCanExcute);
    return;
label_9:
    this.RememberPasswordSession = (CheckBox) target;
    return;
label_10:
    this.label1 = (Label) target;
    return;
label_11:
    num2 = (short) 9150;
    int num3 = (int) num2;
    num2 = (short) 9150;
    int num4 = (int) num2;
    switch (num3 == num4 ? 1 : 0)
    {
      case 0:
      case 2:
        goto label_16;
      default:
        num2 = (short) 1;
        if (num2 == (short) 0)
          ;
        num2 = (short) 0;
        if (num2 == (short) 0)
          ;
        this.initialPasswdHelpButton = (Button) target;
        this.initialPasswdHelpButton.Click += new RoutedEventHandler(this.OnHelpButton_Click);
        return;
    }
label_15:
    this.Okbutton = (Button) target;
    this.Okbutton.Click += new RoutedEventHandler(this.OnClickOK);
    return;
label_16:
    this.ConfirmpasswordBox = (PasswordBox) target;
    return;
label_17:
    this.ConfirmPasswordText = (Label) target;
    return;
label_18:
    this.EnterPasswordBox = (PasswordBox) target;
    return;
label_19:
    this.b = true;
  }
}
