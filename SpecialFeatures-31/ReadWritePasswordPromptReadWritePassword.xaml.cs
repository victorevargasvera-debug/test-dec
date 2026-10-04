// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.ReadWritePassword.PromptReadWritePassword
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using ACPBrowser;
using AcpCommonLib;
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
namespace SpecialFeatures.ReadWritePassword;

public partial class PromptReadWritePassword : Window, IComponentConnector
{
  private string a = string.Empty;
  private bool b;
  internal PasswordBox CodeplugPasswordBox;
  internal Label CodeplugPasswordText;
  internal Label SerialNumberText;
  internal Label SerialNumberValue;
  internal Button OKButton;
  internal Button CancelButton;
  internal Label label1;
  internal CheckBox RememberPasswordSession;
  internal Button promptPasswdHelpButton;
  private bool c;

  internal bool IsCanceled
  {
    get
    {
      short num1 = -18027;
      int num2 = (int) num1;
      num1 = (short) -18027;
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
  }

  public PromptReadWritePassword()
  {
    this.b = true;
    this.InitializeComponent();
    Utility.SetDirection((FrameworkElement) this);
    this.CodeplugPasswordBox.Focus();
  }

  public PromptReadWritePassword(string serialNumber)
  {
    this.b = true;
    this.InitializeComponent();
    if (serialNumber == null)
      this.SerialNumberValue.Content = (object) (FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation).General.RadInfoGeneralSerialNumber_A9122Value;
    else
      this.SerialNumberValue.Content = (object) serialNumber;
    Utility.SetDirection((FrameworkElement) this);
    this.CodeplugPasswordBox.Focus();
  }

  internal string UserEnteredPassword
  {
    get
    {
      short num1 = 0;
      num1 = (short) -10451;
      int num2 = (int) num1;
      num1 = (short) -10451;
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
          return this.a;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = -13344;
      int num2 = (int) num1;
      num1 = (short) -13344;
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

  private void OnClickOK(object A_0, RoutedEventArgs A_1)
  {
    switch (true)
    {
      case true:
        if (false)
          ;
        if (true)
          ;
        this.a = this.CodeplugPasswordBox.Password;
        this.b = false;
        this.Close();
        break;
      default:
        goto case 1;
    }
  }

  private void OnClickCancel(object A_0, RoutedEventArgs A_1)
  {
    switch (true)
    {
      case true:
        if (false)
          ;
        if (true)
          ;
        this.b = true;
        this.Close();
        break;
      default:
        goto case 1;
    }
  }

  private void F1HelpCommandCanExcute(object A_0, CanExecuteRoutedEventArgs A_1)
  {
    short num1 = 0;
    num1 = (short) -9921;
    int num2 = (int) num1;
    num1 = (short) -9921;
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
        A_1.CanExecute = true;
        break;
      default:
        goto case 1;
    }
  }

  private void OnHelpButton_Click(object A_0, RoutedEventArgs A_1)
  {
    int A_1_1 = 19;
    try
    {
      short num = 15491;
      switch ((short) 15491 == num)
      {
        case true:
          num = (short) 0;
          if (num == (short) 0)
            ;
          Utility.CloseHelpWindowIfOpen();
          Utility.DisplayCPSHelpDITA(RptMgrErrorHandler.b("떕ꦗꊙꖛ겝슟鎡鶣장", A_1_1));
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
    int A_1 = 1;
    while (this.c)
    {
      short num1 = 18660;
      int num2 = (int) num1;
      num1 = (short) 18660;
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
          if (num1 == (short) 0)
            ;
          num1 = (short) 0;
          return;
      }
    }
    this.c = true;
    Application.LoadComponent((object) this, new Uri(RptMgrErrorHandler.b("ꮃ햅\uF887\uEF89\uEF8B\uE78D\uF18Fﺑ튓\uF395聯\uEE99\uE99B\uEC9D얟톡龣얥잧잩\uDCAB솭\uDEAFힱ\uDAB3습鞷좹\uD9BB\uDFBD꒿뗁뛃꿅볇꿉볋꿍ꏏꇑꏓ맕\uAAD7뻙\uF3DB껝鋟跡解雥鳧飩觫迭铯藱蛳\u9FF5賷\u9FF9賻\u9FFD珿焁猃椅稇渉∋瘍焏缑砓", A_1), UriKind.Relative));
  }

  [EditorBrowsable(EditorBrowsableState.Never)]
  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "5.0.10.0")]
  void IComponentConnector.Connect(int connectionId, object target)
  {
    short num1 = 14630;
    int num2 = (int) num1;
    num1 = (short) 14630;
    int num3 = (int) num1;
    switch (num2 == num3 ? 1 : 0)
    {
      case 0:
      case 2:
label_9:
        this.SerialNumberValue = (Label) target;
        break;
      default:
        short num4 = 0;
        if (num4 == (short) 0)
          ;
        num4 = (short) 0;
        int num5 = (int) (IntPtr) num4;
        while (true)
        {
          switch (num5)
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
              goto label_19;
            case 2:
              num4 = (short) 1;
              num5 = (int) (IntPtr) num4;
              continue;
          }
          num4 = (short) 1;
          if (num4 == (short) 0)
            ;
          num4 = (short) 0;
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
              num4 = (short) 2;
              num5 = (int) (IntPtr) num4;
              continue;
          }
        }
label_8:
        this.CancelButton = (Button) target;
        this.CancelButton.Click += new RoutedEventHandler(this.OnClickCancel);
        break;
label_10:
        ((CommandBinding) target).Executed += new ExecutedRoutedEventHandler(this.OnHelpButton_Click);
        ((CommandBinding) target).CanExecute += new CanExecuteRoutedEventHandler(this.F1HelpCommandCanExcute);
        break;
label_11:
        this.RememberPasswordSession = (CheckBox) target;
        break;
label_13:
        this.label1 = (Label) target;
        break;
label_14:
        this.promptPasswdHelpButton = (Button) target;
        this.promptPasswdHelpButton.Click += new RoutedEventHandler(this.OnHelpButton_Click);
        break;
label_15:
        this.SerialNumberText = (Label) target;
        break;
label_16:
        this.CodeplugPasswordBox = (PasswordBox) target;
        break;
label_17:
        this.OKButton = (Button) target;
        this.OKButton.Click += new RoutedEventHandler(this.OnClickOK);
        break;
label_18:
        this.CodeplugPasswordText = (Label) target;
        break;
label_19:
        this.c = true;
        break;
    }
  }
}
