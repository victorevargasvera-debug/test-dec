// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.ReadWritePassword.ChangePassword
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

public partial class ChangePassword : Window, IComponentConnector
{
  private string a;
  private string b;
  internal ChangePassword changePassword;
  internal Grid windowGrid;
  internal Label CurrentPasswordText;
  internal Label NewPasswordText;
  internal Label ConfirmPasswordText;
  internal PasswordBox CurrentPasswordBox;
  internal PasswordBox NewPasswordBox;
  internal PasswordBox ConfirmPasswordBox;
  internal Button OK;
  internal Button Cancel;
  internal Button changePasswdHelpbutton;
  private bool d;

  public bool IsCancelButtonClicked
  {
    get
    {
      short num1 = 23605;
      int num2 = (int) num1;
      num1 = (short) 23605;
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
          return this.c;
        default:
          num4 = (short) 0;
          goto case 1;
      }
    }
    set
    {
      short num1 = -1422;
      int num2 = (int) num1;
      num1 = (short) -1422;
      int num3 = (int) num1;
      short num4;
      switch (num2 == num3)
      {
        case true:
          num4 = (short) 1;
          if (num4 == (short) 0)
            ;
          num4 = (short) 0;
          if (num4 == (short) 0)
            ;
          this.c = value;
          break;
        default:
          num4 = (short) 0;
          goto case 1;
      }
    }
  }

  internal ChangePassword(string codeplugPassword)
  {
    this.InitializeComponent();
    Utility.SetDirection((FrameworkElement) this);
    this.a = string.Empty;
    this.b = codeplugPassword;
    this.IsCancelButtonClicked = true;
    this.CurrentPasswordBox.Focus();
  }

  internal string UserEnteredPassword
  {
    get
    {
      short num1 = 29711;
      int num2 = (int) num1;
      num1 = (short) 29711;
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
          return this.a;
        default:
          num4 = (short) 0;
          goto case 1;
      }
    }
    set
    {
      short num1 = 1;
      if (num1 == (short) 0)
        ;
      num1 = (short) 0;
      num1 = (short) 9778;
      int num2 = (int) num1;
      num1 = (short) 9778;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
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

  private void OnClickOK(object A_0, RoutedEventArgs A_1)
  {
    int num1 = 0;
    switch (num1)
    {
      default:
        string password1;
        string password2;
        string password3;
        ReadWriteUtil readWriteUtil;
        string b;
        bool flag;
        char[] chArray;
        int index;
        switch (0)
        {
          case 0:
label_3:
            password1 = this.CurrentPasswordBox.Password;
            password2 = this.NewPasswordBox.Password;
            password3 = this.ConfirmPasswordBox.Password;
            readWriteUtil = new ReadWriteUtil();
            b = this.b;
            flag = false;
            char[] charArray = password2.ToCharArray();
            this.IsCancelButtonClicked = false;
            chArray = charArray;
            index = 0;
            num1 = 10;
            goto default;
          default:
            while (true)
            {
              switch (num1)
              {
                case 0:
                  if (password1 != b)
                  {
                    num1 = 20;
                    continue;
                  }
                  break;
                case 1:
                  num1 = 15;
                  continue;
                case 2:
                  if (chArray[index] >= '\u0080')
                  {
                    num1 = 9;
                    continue;
                  }
                  goto case 8;
                case 3:
                  num1 = 12;
                  continue;
                case 4:
                  num1 = index < chArray.Length ? 2 : 16 /*0x10*/;
                  continue;
                case 5:
                  num1 = 14;
                  continue;
                case 6:
                  if (!readWriteUtil.isHiddenPwd(password1, (string) null))
                  {
                    num1 = 11;
                    continue;
                  }
                  break;
                case 7:
                  goto label_20;
                case 8:
                  switch (true ? 1 : 0)
                  {
                    case 0:
                    case 2:
                      if (false)
                        ;
                      num1 = 13;
                      continue;
                    default:
                      if (true)
                        ;
                      ++index;
                      goto case 0;
                  }
                case 9:
                  flag = true;
                  num1 = 8;
                  continue;
                case 10:
                case 13:
                  num1 = 4;
                  continue;
                case 11:
                  num1 = 0;
                  continue;
                case 12:
                  if (!flag)
                  {
                    num1 = 7;
                    continue;
                  }
                  goto label_36;
                case 14:
                  if (password2.Length <= 16 /*0x10*/)
                  {
                    num1 = 3;
                    continue;
                  }
                  goto label_36;
                case 15:
                  if (password2.Length >= 6)
                  {
                    num1 = 5;
                    continue;
                  }
                  goto label_36;
                case 16 /*0x10*/:
                  num1 = 6;
                  continue;
                case 17:
                  if (password2 != null)
                  {
                    num1 = 1;
                    continue;
                  }
                  goto label_36;
                case 18:
                  goto label_27;
                case 19:
                  num1 = !(password2 != password3) ? 17 : 18;
                  continue;
                case 20:
                  goto label_21;
                default:
                  goto label_3;
              }
              num1 = 19;
            }
label_20:
            this.a = password2;
            this.Close();
            return;
label_21:
            int num2 = (int) MessageBox.Show(AppResources.Incorrect_Password, AppResources.APX_CPS, MessageBoxButton.OK, MessageBoxImage.Exclamation, MessageBoxResult.OK);
            return;
label_27:
            int num3 = (int) MessageBox.Show(AppResources.New_Passwords_Do_Not_Match, AppResources.APX_CPS, MessageBoxButton.OK, MessageBoxImage.Exclamation, MessageBoxResult.OK);
            return;
label_36:
            int num4 = (int) MessageBox.Show(AppResources.Must_Contain_6_to_16_Characters, AppResources.APX_CPS, MessageBoxButton.OK, MessageBoxImage.Exclamation, MessageBoxResult.OK);
            return;
        }
    }
  }

  private void OnClickCancel(object A_0, RoutedEventArgs A_1)
  {
    short num1 = -8522;
    int num2 = (int) num1;
    num1 = (short) -8522;
    int num3 = (int) num1;
    short num4;
    switch (num2 == num3)
    {
      case true:
        num4 = (short) 1;
        if (num4 == (short) 0)
          ;
        num4 = (short) 0;
        if (num4 == (short) 0)
          ;
        this.a = string.Empty;
        this.IsCancelButtonClicked = true;
        this.Close();
        break;
      default:
        num4 = (short) 0;
        goto case 1;
    }
  }

  private void F1HelpCommandCanExcute(object A_0, CanExecuteRoutedEventArgs A_1)
  {
    short num1 = 30303;
    int num2 = (int) num1;
    num1 = (short) 30303;
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
        A_1.CanExecute = true;
        break;
      default:
        num4 = (short) 0;
        goto case 1;
    }
  }

  private void OnHelpButton_Click(object A_0, RoutedEventArgs A_1)
  {
    int A_1_1 = 4;
    try
    {
      short num1 = -10472;
      int num2 = (int) num1;
      num1 = (short) -10472;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          Utility.CloseHelpWindowIfOpen();
          Utility.DisplayCPSHelpDITA(RptMgrErrorHandler.b("ꒆ몈\uEE8A\uEB8C\uEB8E\uF090\uF692\uF194\uF196", A_1_1));
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

  [GeneratedCode("PresentationBuildTasks", "5.0.10.0")]
  [DebuggerNonUserCode]
  public void InitializeComponent()
  {
    int A_1 = 0;
    if (this.d)
      return;
    short num = -23756;
    switch ((short) -23756 == num ? 1 : 0)
    {
      case 0:
        break;
      case 2:
        break;
      default:
        num = (short) 1;
        if (num == (short) 0)
          ;
        num = (short) 0;
        num = (short) 0;
        if (num == (short) 0)
          ;
        this.d = true;
        Application.LoadComponent((object) this, new Uri(RptMgrErrorHandler.b("겂횄\uF786\uEC88\uE88A\uE48C\uEE8E\uFD90햒\uF094\uF696\uED98\uEE9A\uEF9C爵튠颢욤좦쒨\uDBAA슬솮풰\uDDB2솴颶쮸\uDEBA\uDCBC\uDBBE뛀뇂계돆곈믊곌볎ꋐꓒ뫔ꗖ뷘\uF4DA뻜럞胠跢苤苦駨諪黬鳮蛰鳲蟴鏶ퟸ菺鳼鋾洀", A_1), UriKind.Relative));
        break;
    }
  }

  [EditorBrowsable(EditorBrowsableState.Never)]
  [GeneratedCode("PresentationBuildTasks", "5.0.10.0")]
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
          num2 = (short) -29393;
          int num3 = (int) num2;
          num2 = (short) -29393;
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
              num1 = (int) (IntPtr) num2;
              continue;
          }
        case 1:
          goto label_21;
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
          goto label_9;
        case 2:
          goto label_7;
        case 3:
          goto label_14;
        case 4:
          goto label_20;
        case 5:
          goto label_12;
        case 6:
          goto label_6;
        case 7:
          goto label_16;
        case 8:
          goto label_10;
        case 9:
          goto label_5;
        case 10:
          goto label_15;
        case 11:
          goto label_8;
        case 12:
          goto label_11;
        default:
          num2 = (short) 0;
          num1 = (int) (IntPtr) num2;
          continue;
      }
    }
label_5:
    this.ConfirmPasswordBox = (PasswordBox) target;
    return;
label_6:
    this.ConfirmPasswordText = (Label) target;
    return;
label_7:
    ((CommandBinding) target).Executed += new ExecutedRoutedEventHandler(this.OnHelpButton_Click);
    ((CommandBinding) target).CanExecute += new CanExecuteRoutedEventHandler(this.F1HelpCommandCanExcute);
    return;
label_8:
    this.Cancel = (Button) target;
    this.Cancel.Click += new RoutedEventHandler(this.OnClickCancel);
    return;
label_9:
    this.changePassword = (ChangePassword) target;
    return;
label_10:
    this.NewPasswordBox = (PasswordBox) target;
    return;
label_11:
    this.changePasswdHelpbutton = (Button) target;
    this.changePasswdHelpbutton.Click += new RoutedEventHandler(this.OnHelpButton_Click);
    return;
label_12:
    num2 = (short) 1;
    if (num2 == (short) 0)
      ;
    this.NewPasswordText = (Label) target;
    return;
label_14:
    this.windowGrid = (Grid) target;
    return;
label_15:
    this.OK = (Button) target;
    this.OK.Click += new RoutedEventHandler(this.OnClickOK);
    return;
label_16:
    this.CurrentPasswordBox = (PasswordBox) target;
    return;
label_20:
    num2 = (short) 0;
    this.CurrentPasswordText = (Label) target;
    return;
label_21:
    this.d = true;
  }
}
