// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.Comms.ProgressUpdate
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using AcpUI.Common;
using CommonResources;
using SpecialFeatures.AcpReportManagerLib;
using SpecialFeatures.Flashport.FlashRadio;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Shapes;

#nullable disable
namespace SpecialFeatures.Comms;

public partial class ProgressUpdate : Window, IDisposable, IComponentConnector
{
  public bool bCommSuccess = true;
  internal Grid Header;
  internal Rectangle Divider_Copy;
  internal Label ViewboxTitle;
  internal GroupBox GrpbxProgress;
  internal StackPanel stackMoreInfo;
  internal Label ConnectingToRadioLabel;
  internal SpecialFeatures.FileOperations.BusyIndicator ConnectingToRadioIndicator;
  internal TextBlock ConnectText;
  internal SpecialFeatures.FileOperations.BusyIndicator ReadingRadioInformationIndicator;
  internal TextBlock RadioInfoText;
  internal SpecialFeatures.FileOperations.BusyIndicator CodeplugIndicator;
  internal TextBlock CodeplugText;
  internal SpecialFeatures.FileOperations.BusyIndicator VerificationIndicator;
  internal TextBlock VerificationText;
  internal TextBox ProgText;
  internal ProgressBar progressBar2;
  internal Button CloseBtn;
  private bool a;

  public void SetCloseBtnEnable(bool isEnable)
  {
    short num1 = 5323;
    int num2 = (int) num1;
    num1 = (short) 5323;
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
        this.CloseBtn.IsEnabled = isEnable;
        break;
      default:
        goto case 1;
    }
  }

  public ProgressUpdate()
  {
    this.InitializeComponent();
    Utility.SetDirection((FrameworkElement) this);
  }

  private void Page_Loaded(object A_0, RoutedEventArgs A_1)
  {
    short num1 = 28620;
    int num2 = (int) num1;
    num1 = (short) 28620;
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
        this.CloseBtn.IsEnabled = false;
        this.progressBar2.Value = 0.0;
        break;
      default:
        goto case 1;
    }
  }

  private void ObButtonClick_Close(object A_0, RoutedEventArgs A_1)
  {
    short num1 = 1;
    if (num1 == (short) 0)
      ;
    num1 = (short) 26120;
    int num2 = (int) num1;
    num1 = (short) 26120;
    int num3 = (int) num1;
    switch (num2 == num3)
    {
      case true:
        num1 = (short) 0;
        num1 = (short) 0;
        if (num1 == (short) 0)
          ;
        this.Close();
        break;
      default:
        goto case 1;
    }
  }

  protected override void OnClosing(CancelEventArgs e)
  {
    int num1 = 2;
    short num2;
    while (true)
    {
      switch (num1)
      {
        case 0:
          num2 = (short) 0;
          num2 = (short) -25781;
          int num3 = (int) num2;
          num2 = (short) -25781;
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
              e.Cancel = true;
              num2 = (short) 1;
              num1 = (int) (IntPtr) num2;
              continue;
          }
          break;
        case 1:
          goto label_10;
        case 2:
          switch (0)
          {
            case 0:
              goto label_3;
            default:
              continue;
          }
        default:
label_3:
          if (this.CloseBtn.IsEnabled)
            goto label_10;
          break;
      }
      num2 = (short) 0;
      num1 = (int) (IntPtr) num2;
    }
label_10:
    num2 = (short) 1;
    if (num2 == (short) 0)
      ;
  }

  protected virtual void Dispose(bool disposing)
  {
    short num1 = -20954;
    int num2 = (int) num1;
    num1 = (short) -20954;
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
        int num5 = disposing ? 1 : 0;
        break;
      default:
        goto case 1;
    }
  }

  public void Dispose()
  {
    short num1 = 6476;
    int num2 = (int) num1;
    num1 = (short) 6476;
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
        this.Dispose(true);
        GC.SuppressFinalize((object) this);
        break;
      default:
        goto case 1;
    }
  }

  public void ProgressUpdat(object sender, ProgressChangedEventArgs e)
  {
    int num1;
    ProgressUserState userState;
    short num2;
    switch (0)
    {
      case 0:
label_2:
        this.progressBar2.Value = (double) e.ProgressPercentage;
        userState = (ProgressUserState) e.UserState;
        num2 = (short) 26088;
        int num3 = (int) num2;
        num2 = (short) 26088;
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
            num2 = (short) 4;
            num1 = (int) (IntPtr) num2;
            goto label_1;
        }
        break;
      default:
        UserState currentUserState;
        while (true)
        {
          switch (num1)
          {
            case 0:
              this.VerificationIndicator.Visibility = Visibility.Hidden;
              this.VerificationText.Visibility = Visibility.Hidden;
              this.CodeplugIndicator.Visibility = Visibility.Hidden;
              this.CodeplugText.Visibility = Visibility.Hidden;
              this.CloseBtn.IsEnabled = true;
              num2 = (short) 9;
              num1 = (int) (IntPtr) num2;
              continue;
            case 1:
              goto label_16;
            case 2:
              goto label_23;
            case 3:
              goto label_40;
            case 4:
              num2 = (short) 0;
              if (userState != null)
              {
                num2 = (short) 2;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_41;
            case 5:
              goto label_5;
            case 6:
              if (userState.UserText == AppResources.Radio_Serial_Number_updated)
              {
                num2 = (short) 1;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_8;
            case 7:
              switch (currentUserState)
              {
                case UserState.ConnectStart:
                  goto label_13;
                case UserState.ConnectError:
                  goto label_28;
                case UserState.ConnectDone:
                  goto label_11;
                case UserState.ReadRadInfoStart:
                  goto label_17;
                case UserState.ReadRadInfoError:
                  this.ProgText.Text = userState.UserText;
                  this.ReadingRadioInformationIndicator.BusyState = BusyStates.COMPLETE_WITH_ERROR;
                  this.CodeplugIndicator.BusyState = BusyStates.NOT_BUSY;
                  this.VerificationIndicator.BusyState = BusyStates.NOT_BUSY;
                  num2 = (short) 8;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case UserState.ReadRadInfoDone:
                  this.ProgText.Text = userState.UserText;
                  this.ReadingRadioInformationIndicator.BusyState = BusyStates.COMPLETE_NO_ERROR;
                  num2 = (short) 6;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case UserState.CodeplugStart:
                  goto label_10;
                case UserState.CodeplugError:
                  goto label_42;
                case UserState.CodeplugDone:
                  goto label_36;
                case UserState.FlashingComponentStart:
                  goto label_9;
                case UserState.FlashingComponentError:
                  goto label_14;
                case UserState.FlashingComponentDone:
                  goto label_34;
                case UserState.FinalValidationStart:
                  goto label_12;
                case UserState.FinalValidationError:
                  goto label_18;
                case UserState.FinalValidationDone:
                  goto label_15;
                case UserState.UploadFirmwareStart:
                  goto label_32;
                case UserState.UploadFirmwareDone:
                  goto label_27;
                case UserState.UploadFirmwareError:
                  goto label_22;
                case UserState.FirmwarePackageInvalid:
                  goto label_20;
                case UserState.None:
                  this.ProgText.Text = userState.UserText;
                  num2 = (short) 5;
                  num1 = (int) (IntPtr) num2;
                  continue;
                default:
                  num2 = (short) 3;
                  num1 = (int) (IntPtr) num2;
                  continue;
              }
            case 8:
              if (userState.UserText == AppResources.Radio_Serial_Number_update_failed)
              {
                num2 = (short) 0;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_33;
            case 9:
              goto label_33;
            default:
              goto label_2;
          }
label_1:;
        }
label_40:
        return;
label_5:
        return;
label_41:
        return;
label_9:
        this.CodeplugIndicator.BusyState = BusyStates.BUSY;
        return;
label_10:
        this.ProgText.Text = userState.UserText;
        this.CodeplugIndicator.BusyState = BusyStates.BUSY;
        return;
label_11:
        this.ProgText.Text = userState.UserText;
        this.ConnectingToRadioIndicator.BusyState = BusyStates.COMPLETE_NO_ERROR;
        return;
label_12:
        this.ProgText.Text = userState.UserText;
        this.VerificationIndicator.BusyState = BusyStates.BUSY;
        return;
label_13:
        this.ProgText.Text = userState.UserText;
        this.ConnectingToRadioIndicator.BusyState = BusyStates.BUSY;
        this.CloseBtn.IsEnabled = false;
        return;
label_14:
        this.CodeplugIndicator.BusyState = BusyStates.COMPLETE_WITH_ERROR;
        this.VerificationIndicator.BusyState = BusyStates.NOT_BUSY;
        this.CloseBtn.IsEnabled = true;
        this.bCommSuccess = false;
        return;
label_15:
        this.ProgText.Text = userState.UserText;
        this.VerificationIndicator.BusyState = BusyStates.COMPLETE_NO_ERROR;
        this.CloseBtn.IsEnabled = true;
        return;
label_16:
        this.VerificationIndicator.Visibility = Visibility.Hidden;
        this.VerificationText.Visibility = Visibility.Hidden;
        this.CodeplugIndicator.Visibility = Visibility.Hidden;
        this.CodeplugText.Visibility = Visibility.Hidden;
        this.CloseBtn.IsEnabled = true;
        return;
label_17:
        this.ProgText.Text = userState.UserText;
        this.ReadingRadioInformationIndicator.BusyState = BusyStates.BUSY;
        return;
label_18:
        this.ProgText.Text = userState.UserText;
        this.VerificationIndicator.BusyState = BusyStates.COMPLETE_WITH_ERROR;
        this.CloseBtn.IsEnabled = true;
        this.bCommSuccess = false;
        return;
label_23:
        currentUserState = userState.CurrentUserState;
        break;
label_20:
        return;
label_32:
        return;
label_27:
        return;
label_22:
        return;
label_28:
        this.ProgText.Text = userState.UserText;
        this.ConnectingToRadioIndicator.BusyState = BusyStates.COMPLETE_WITH_ERROR;
        this.ReadingRadioInformationIndicator.BusyState = BusyStates.NOT_BUSY;
        this.CodeplugIndicator.BusyState = BusyStates.NOT_BUSY;
        this.VerificationIndicator.BusyState = BusyStates.NOT_BUSY;
        this.CloseBtn.IsEnabled = true;
        this.bCommSuccess = false;
        return;
label_33:
        this.CloseBtn.IsEnabled = true;
        this.bCommSuccess = false;
        return;
label_34:
        num2 = (short) 1;
        if (num2 == (short) 0)
          ;
        this.CodeplugIndicator.BusyState = BusyStates.COMPLETE_NO_ERROR;
        return;
label_36:
        this.ProgText.Text = userState.UserText;
        this.CodeplugIndicator.BusyState = BusyStates.COMPLETE_NO_ERROR;
        return;
label_8:
        return;
label_42:
        this.ProgText.Text = userState.UserText;
        this.CodeplugIndicator.BusyState = BusyStates.COMPLETE_WITH_ERROR;
        this.VerificationIndicator.BusyState = BusyStates.NOT_BUSY;
        this.CloseBtn.IsEnabled = true;
        this.bCommSuccess = false;
        return;
    }
    num2 = (short) 7;
    num1 = (int) (IntPtr) num2;
    goto label_1;
  }

  public void ClearStatus()
  {
    short num1 = 0;
    num1 = (short) 1;
    if (num1 == (short) 0)
      ;
    num1 = (short) 32611;
    int num2 = (int) num1;
    num1 = (short) 32611;
    int num3 = (int) num1;
    switch (num2 == num3)
    {
      case true:
        num1 = (short) 0;
        if (num1 == (short) 0)
          ;
        this.ConnectingToRadioIndicator.BusyState = BusyStates.NOT_BUSY;
        this.ReadingRadioInformationIndicator.BusyState = BusyStates.NOT_BUSY;
        this.CodeplugIndicator.BusyState = BusyStates.NOT_BUSY;
        this.VerificationIndicator.BusyState = BusyStates.NOT_BUSY;
        this.VerificationText.Visibility = Visibility.Visible;
        this.VerificationIndicator.Visibility = Visibility.Visible;
        this.CodeplugIndicator.Visibility = Visibility.Visible;
        this.CodeplugText.Visibility = Visibility.Visible;
        this.ProgText.Text = "";
        this.CloseBtn.IsEnabled = false;
        this.bCommSuccess = true;
        break;
      default:
        goto case 1;
    }
  }

  [GeneratedCode("PresentationBuildTasks", "5.0.10.0")]
  [DebuggerNonUserCode]
  public void InitializeComponent()
  {
    int A_1 = 8;
    short num1 = 22554;
    int num2 = (int) num1;
    num1 = (short) 22554;
    int num3 = (int) num1;
    switch (num2 == num3 ? 1 : 0)
    {
      case 0:
      case 2:
        this.a = true;
        Application.LoadComponent((object) this, new Uri(RptMgrErrorHandler.b("ꒊ\uDE8Cﾎ\uF490\uF092ﲔ\uF696\uF598\uDD9A\uF89Cﺞ햠횢\uD7A4슦\uDAA8邪캬삮\uDCB0쎲\uDAB4\uD9B6\uDCB8햺즼邾ꋀ곂꣄\uAAC6뫈\uE4CA뷌뷎뻐듒\uA7D4닖\uAAD8\uA8DA\uA8DC꿞藠苢釤苦쟨鏪賬苮鷰", A_1), UriKind.Relative));
        break;
      default:
        short num4 = 0;
        num4 = (short) 1;
        if (num4 == (short) 0)
          ;
        num4 = (short) 0;
        if (num4 == (short) 0)
          ;
        if (this.a)
          break;
        goto case 0;
    }
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "5.0.10.0")]
  internal Delegate _CreateDelegate(Type delegateType, string handler)
  {
    switch (true)
    {
      case true:
        short num = 1;
        if (num == (short) 0)
          ;
        num = (short) 0;
        if (num == (short) 0)
          ;
        return Delegate.CreateDelegate(delegateType, (object) this, handler);
      default:
        goto case 1;
    }
  }

  [EditorBrowsable(EditorBrowsableState.Never)]
  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "5.0.10.0")]
  void IComponentConnector.Connect(int connectionId, object target)
  {
    int num1 = 0;
    short num2;
    while (true)
    {
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
          goto label_28;
        case 2:
          num2 = (short) 1;
          num1 = (int) (IntPtr) num2;
          continue;
      }
      switch (connectionId)
      {
        case 1:
          goto label_20;
        case 2:
          goto label_9;
        case 3:
          goto label_7;
        case 4:
          goto label_14;
        case 5:
          goto label_19;
        case 6:
          goto label_17;
        case 7:
          goto label_24;
        case 8:
          goto label_27;
        case 9:
          goto label_13;
        case 10:
          goto label_6;
        case 11:
          goto label_26;
        case 12:
          goto label_10;
        case 13:
          goto label_5;
        case 14:
          goto label_25;
        case 15:
          goto label_8;
        case 16 /*0x10*/:
          goto label_15;
        case 17:
          goto label_11;
        case 18:
          goto label_16;
        default:
          num2 = (short) 2;
          num1 = (int) (IntPtr) num2;
          continue;
      }
    }
label_5:
    this.CodeplugText = (TextBlock) target;
    return;
label_6:
    this.ReadingRadioInformationIndicator = (SpecialFeatures.FileOperations.BusyIndicator) target;
    return;
label_7:
    this.Divider_Copy = (Rectangle) target;
    return;
label_8:
    this.VerificationText = (TextBlock) target;
    return;
label_9:
    this.Header = (Grid) target;
    return;
label_10:
    this.CodeplugIndicator = (SpecialFeatures.FileOperations.BusyIndicator) target;
    return;
label_11:
    num2 = (short) 1;
    if (num2 == (short) 0)
      ;
    this.progressBar2 = (ProgressBar) target;
    return;
label_13:
    this.ConnectText = (TextBlock) target;
    return;
label_14:
    this.ViewboxTitle = (Label) target;
    return;
label_15:
    this.ProgText = (TextBox) target;
    return;
label_16:
    this.CloseBtn = (Button) target;
    this.CloseBtn.Click += new RoutedEventHandler(this.ObButtonClick_Close);
    return;
label_17:
    this.stackMoreInfo = (StackPanel) target;
    return;
label_19:
    this.GrpbxProgress = (GroupBox) target;
    return;
label_20:
    num2 = (short) 22952;
    int num3 = (int) num2;
    num2 = (short) 22952;
    int num4 = (int) num2;
    switch (num3 == num4 ? 1 : 0)
    {
      case 0:
      case 2:
        goto label_11;
      case 1:
        num2 = (short) 0;
        if (num2 == (short) 0)
          ;
        ((FrameworkElement) target).Loaded += new RoutedEventHandler(this.Page_Loaded);
        return;
      default:
        num2 = (short) 0;
        goto case 1;
    }
label_24:
    this.ConnectingToRadioLabel = (Label) target;
    return;
label_25:
    this.VerificationIndicator = (SpecialFeatures.FileOperations.BusyIndicator) target;
    return;
label_26:
    this.RadioInfoText = (TextBlock) target;
    return;
label_27:
    this.ConnectingToRadioIndicator = (SpecialFeatures.FileOperations.BusyIndicator) target;
    return;
label_28:
    this.a = true;
  }
}
