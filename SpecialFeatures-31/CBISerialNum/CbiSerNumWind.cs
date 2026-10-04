// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.CBISerialNum.CbiSerNumWind
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using ACPBrowser;
using AcpUI.Common;
using SpecialFeatures.AcpReportManagerLib;
using SpecialFeatures.Comms;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Markup;

#nullable disable
namespace SpecialFeatures.CBISerialNum;

public class CbiSerNumWind : Window, IComponentConnector
{
  private string a;
  internal CbiSerNumWind myCbiWindow;
  internal Label operationLabel;
  internal Grid Main;
  internal TextBox CbiSerEntry;
  internal StackPanel stackPanelError;
  internal Image imageError;
  internal TextBox textBoxError;
  private bool b;

  public CbiSerNumWind()
  {
    int A_1 = 16 /*0x10*/;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    this.InitializeComponent();
    this.CbiSerEntry.Focus();
    Utility.SetDirection((FrameworkElement) this);
    if (!Thread.CurrentThread.CurrentCulture.Name.ToLower().StartsWith(RptMgrErrorHandler.b("\uF292\uE794", A_1)))
      return;
    this.CbiSerEntry.FlowDirection = FlowDirection.LeftToRight;
    this.CbiSerEntry.TextAlignment = TextAlignment.Right;
  }

  public string SerNum
  {
    get
    {
      short num1 = -15833;
      int num2 = (int) num1;
      num1 = (short) -15833;
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
      short num1 = 4141;
      int num2 = (int) num1;
      num1 = (short) 4141;
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

  private void F1HelpCommandCanExcute(object A_0, CanExecuteRoutedEventArgs A_1)
  {
    short num1 = 25402;
    int num2 = (int) num1;
    num1 = (short) 25402;
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

  private void buttonHelp_Click(object A_0, RoutedEventArgs A_1)
  {
    try
    {
      short num1 = 8968;
      int num2 = (int) num1;
      num1 = (short) 8968;
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
          Utility.CloseHelpWindowIfOpen();
          Utility.DisplayCPSHelpDITA((string) null);
          break;
        default:
          goto case 1;
      }
    }
    catch (Exception ex)
    {
    }
  }

  private void CbiSerEntryOK_Click(object A_0, RoutedEventArgs A_1)
  {
label_0:
    int num1;
    short num2;
    string s;
    switch (0)
    {
      case 0:
label_2:
        num2 = (short) -14306;
        int num3 = (int) num2;
        num2 = (short) -14306;
        int num4 = (int) num2;
        switch (num3 == num4 ? 1 : 0)
        {
          case 0:
          case 2:
            goto label_0;
          default:
            num2 = (short) 0;
            if (num2 == (short) 0)
              ;
            string str = this.CbiSerEntry.ToString();
            int length = str.Length;
            s = str.Substring(length - 10, 10);
            num2 = (short) 4;
            num1 = (int) (IntPtr) num2;
            goto label_1;
        }
      default:
        while (true)
        {
          switch (num1)
          {
            case 0:
              if (string.IsNullOrEmpty(this.CbiSerEntry.Text))
              {
                num2 = (short) 2;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_13;
            case 1:
              goto label_14;
            case 2:
              num2 = (short) 1;
              if (num2 == (short) 0)
                ;
              this.CbiSerEntry.GetBindingExpression(TextBox.TextProperty).UpdateSource();
              num2 = (short) 3;
              num1 = (int) (IntPtr) num2;
              continue;
            case 3:
              goto label_8;
            case 4:
              if (SerialNumberValidator.ValidateSerialNumber(Convert.ToBase64String(Encoding.ASCII.GetBytes(s))))
              {
                num2 = (short) 0;
                num2 = (short) 1;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              this.CbiSerEntry.Focus();
              num2 = (short) 0;
              num1 = (int) (IntPtr) num2;
              continue;
            default:
              goto label_2;
          }
label_1:;
        }
label_8:
        break;
label_13:
        break;
label_14:
        this.a = s;
        this.Close();
        break;
    }
  }

  private void CbiSerEntryCancel_Click(object A_0, RoutedEventArgs A_1)
  {
    short num1 = 25026;
    int num2 = (int) num1;
    num1 = (short) 25026;
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

  [GeneratedCode("PresentationBuildTasks", "5.0.10.0")]
  [DebuggerNonUserCode]
  public void InitializeComponent()
  {
    int A_1 = 0;
    if (this.b)
    {
      short num = 2830;
      switch ((short) 2830 == num ? 1 : 0)
      {
        case 0:
        case 2:
          break;
        default:
          num = (short) 1;
          if (num == (short) 0)
            ;
          num = (short) 0;
          if (num == (short) 0)
            ;
          num = (short) 0;
          return;
      }
    }
    this.b = true;
    Application.LoadComponent((object) this, new Uri(RptMgrErrorHandler.b("겂횄\uF786\uEC88\uE88A\uE48C\uEE8E\uFD90햒\uF094\uF696\uED98\uEE9A\uEF9C爵튠颢욤좦쒨\uDBAA슬솮풰\uDDB2솴颶\uDAB8\uD9BA풼邾ꋀꇂ계듆곈맊ꏌ뫎볐ꓒ볔맖뷘\uF5DAꗜ뻞賠迢", A_1), UriKind.Relative));
  }

  [GeneratedCode("PresentationBuildTasks", "5.0.10.0")]
  [EditorBrowsable(EditorBrowsableState.Never)]
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
          goto label_20;
        case 1:
          num2 = (short) 0;
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
      }
      switch (connectionId)
      {
        case 1:
          goto label_12;
        case 2:
          goto label_10;
        case 3:
          goto label_19;
        case 4:
          goto label_15;
        case 5:
          goto label_18;
        case 6:
          goto label_9;
        case 7:
          goto label_13;
        case 8:
          goto label_8;
        case 9:
          goto label_17;
        case 10:
          goto label_11;
        case 11:
          goto label_14;
        default:
          num2 = (short) 1;
          if (num2 == (short) 0)
            ;
          num2 = (short) -2929;
          int num3 = (int) num2;
          num2 = (short) -2929;
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
      }
    }
label_8:
    this.textBoxError = (TextBox) target;
    return;
label_9:
    num2 = (short) 0;
    this.stackPanelError = (StackPanel) target;
    return;
label_10:
    ((CommandBinding) target).Executed += new ExecutedRoutedEventHandler(this.buttonHelp_Click);
    ((CommandBinding) target).CanExecute += new CanExecuteRoutedEventHandler(this.F1HelpCommandCanExcute);
    return;
label_11:
    ((ButtonBase) target).Click += new RoutedEventHandler(this.CbiSerEntryCancel_Click);
    return;
label_12:
    this.myCbiWindow = (CbiSerNumWind) target;
    return;
label_13:
    this.imageError = (Image) target;
    return;
label_14:
    ((ButtonBase) target).Click += new RoutedEventHandler(this.CbiSerEntryOK_Click);
    return;
label_15:
    this.Main = (Grid) target;
    return;
label_17:
    ((ButtonBase) target).Click += new RoutedEventHandler(this.buttonHelp_Click);
    return;
label_18:
    this.CbiSerEntry = (TextBox) target;
    return;
label_19:
    this.operationLabel = (Label) target;
    return;
label_20:
    this.b = true;
  }
}
