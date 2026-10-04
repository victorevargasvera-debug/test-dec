// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.PasswordResetFile.PageResetRadioPasswordProgress
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using ACPBrowser;
using AcpUI.Common;
using CommonResources;
using SpecialFeatures.AcpReportManagerLib;
using SpecialFeatures.FileOperations;
using SpecialFeatures.Flashport.FlashRadio;
using SpecialFeatures.ReadWritePassword;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Navigation;
using System.Windows.Shapes;

#nullable disable
namespace SpecialFeatures.PasswordResetFile;

public partial class PageResetRadioPasswordProgress : 
  PageFunction<DialogResult>,
  IDisposable,
  IComponentConnector
{
  private readonly FileOperationData a;
  private readonly ReadWritePasswordApp b;
  private BackgroundWorker c;
  internal Grid Header;
  internal Rectangle Divider_Copy;
  internal Label ViewboxTitle;
  internal GroupBox GrpbxRadioParams;
  internal Label lblRadioModel;
  internal TextBox RadioModelTextBox;
  internal Label lblRadioSerialNo;
  internal TextBox RadioSerialNoTextBox;
  internal GroupBox GrpbxProgress;
  internal StackPanel stackMoreInfo;
  internal Label ConnectingToRadioLabel;
  internal SpecialFeatures.FileOperations.BusyIndicator ConnectBusyIndicator;
  internal SpecialFeatures.FileOperations.BusyIndicator VerifyBusyIndicator;
  internal SpecialFeatures.FileOperations.BusyIndicator ResetFileValidationIndicator;
  internal SpecialFeatures.FileOperations.BusyIndicator ResetIndicator;
  internal FlowDocumentScrollViewer ProgText;
  internal Paragraph myStsParagraph;
  internal ProgressBar progressBar2;
  internal Button CloseBtn;
  internal Button HelpBtn;
  private bool d;

  public PageResetRadioPasswordProgress(
    FileOperationData flashData,
    ReadWritePasswordApp readWritePasswordApp)
  {
    int A_1 = 4;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    if (flashData == null)
      throw new ArgumentNullException(RptMgrErrorHandler.b("캆\uE788\uE88A\uE28C\uE28E\uF890ﶒ\uF294랖ﾘ\uF79Aﲜ\uEC9E즠\uE7A2쒤펦좨讪캬캮\uDFB0\uDDB2\uDAB4쎶馸\uD9BA\uD8BC龾꿀뛂꧄ꯆ\uE7C8", A_1), RptMgrErrorHandler.b("\uE186\uE588\uEA8Aﺌ\uE78E햐\uF292\uE194\uF696", A_1));
    this.b = readWritePasswordApp;
    this.c = new BackgroundWorker()
    {
      WorkerReportsProgress = true
    };
    this.a = flashData;
    this.a.CurrentPage = (object) this;
    Utility.SetDirection((FrameworkElement) this);
    this.InitializeComponent();
    this.a();
    this.ViewboxTitle.Content = (object) this.a.ProgressDialogTitleContent;
    this.CloseBtn.IsEnabled = false;
  }

  public void Dispose()
  {
    short num1 = 3794;
    int num2 = (int) num1;
    num1 = (short) 3794;
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
        this.Dispose(true);
        GC.SuppressFinalize((object) this);
        break;
      default:
        goto case 1;
    }
  }

  protected virtual void Dispose(bool disposing)
  {
    int num1 = 2;
    while (true)
    {
      short num2;
      switch (num1)
      {
        case 0:
          if (this.c != null)
          {
            num2 = (short) 1;
            if (num2 == (short) 0)
              ;
            num2 = (short) 1;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto label_11;
        case 1:
          this.c.Dispose();
          this.c = (BackgroundWorker) null;
          num2 = (short) 4;
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
        case 3:
          num2 = (short) 0;
          num1 = (int) (IntPtr) num2;
          continue;
        case 4:
          goto label_9;
      }
      num2 = (short) -15019;
      int num3 = (int) num2;
      num2 = (short) -15019;
      int num4 = (int) num2;
      switch (num3 == num4 ? 1 : 0)
      {
        case 0:
          goto label_4;
        case 1:
          num2 = (short) 0;
          if (num2 == (short) 0)
            ;
          if (disposing)
          {
            num2 = (short) 3;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto label_16;
        case 2:
          goto label_17;
        default:
          num2 = (short) 0;
          goto case 1;
      }
    }
label_9:
    return;
label_4:
    return;
label_17:
    return;
label_16:
    return;
label_11:;
  }

  private void a()
  {
    short num1 = -9457;
    int num2 = (int) num1;
    num1 = (short) -9457;
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
        this.c.DoWork += new DoWorkEventHandler(this.OnBackgroundWorkerDoWork);
        this.c.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.OnBackgroundWorkerRunWorkerCompleted);
        this.c.ProgressChanged += new ProgressChangedEventHandler(this.OnBackgroundWorkerProgressChanged);
        break;
      default:
        goto case 1;
    }
  }

  private void OnBackgroundWorkerDoWork(object A_0, DoWorkEventArgs A_1)
  {
    short num1 = 1;
    if (num1 == (short) 0)
      ;
    num1 = (short) -26236;
    int num2 = (int) num1;
    num1 = (short) -26236;
    int num3 = (int) num1;
    switch (num2 == num3)
    {
      case true:
        num1 = (short) 0;
        num1 = (short) 0;
        if (num1 == (short) 0)
          ;
        this.UploadPasswordResetFile((string) A_1.Argument, A_1);
        break;
      default:
        goto case 1;
    }
  }

  private void OnBackgroundWorkerRunWorkerCompleted(object A_0, RunWorkerCompletedEventArgs A_1)
  {
    int num1 = 10;
    while (true)
    {
      short num2;
      switch (num1)
      {
        case 0:
          if (this.ResetFileValidationIndicator.BusyState == BusyStates.BUSY)
          {
            num2 = (short) 7;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto case 3;
        case 1:
          this.ConnectBusyIndicator.BusyState = BusyStates.COMPLETE_WITH_ERROR;
          num2 = (short) 1;
          if (num2 == (short) 0)
            ;
          num2 = (short) 12;
          num1 = (int) (IntPtr) num2;
          continue;
        case 2:
          this.ResetIndicator.BusyState = BusyStates.COMPLETE_WITH_ERROR;
          num2 = (short) 5;
          num1 = (int) (IntPtr) num2;
          continue;
        case 3:
          num2 = (short) 8;
          num1 = (int) (IntPtr) num2;
          continue;
        case 4:
          this.VerifyBusyIndicator.BusyState = BusyStates.COMPLETE_WITH_ERROR;
          num2 = (short) 9;
          num1 = (int) (IntPtr) num2;
          continue;
        case 5:
          goto label_25;
        case 6:
          if (this.VerifyBusyIndicator.BusyState == BusyStates.BUSY)
          {
            num2 = (short) 4;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          break;
        case 7:
          this.ResetFileValidationIndicator.BusyState = BusyStates.COMPLETE_WITH_ERROR;
          num2 = (short) 3;
          num1 = (int) (IntPtr) num2;
          continue;
        case 8:
          if (this.ResetIndicator.BusyState == BusyStates.BUSY)
          {
            num2 = (short) 2;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto label_25;
        case 9:
          num2 = (short) 0;
          break;
        case 10:
          switch (0)
          {
            case 0:
              goto label_3;
            default:
              continue;
          }
        case 11:
label_12:
          this.myStsParagraph.Inlines.Clear();
          this.myStsParagraph.Inlines.Add(A_1.Error.Message);
          num2 = (short) -4206;
          int num3 = (int) num2;
          num2 = (short) -4206;
          int num4 = (int) num2;
          switch (num3 == num4 ? 1 : 0)
          {
            case 0:
            case 2:
              goto label_12;
            default:
              num2 = (short) 0;
              if (num2 == (short) 0)
                ;
              num2 = (short) 13;
              num1 = (int) (IntPtr) num2;
              continue;
          }
        case 12:
          num2 = (short) 6;
          num1 = (int) (IntPtr) num2;
          continue;
        case 13:
          if (this.ConnectBusyIndicator.BusyState == BusyStates.BUSY)
          {
            num2 = (short) 1;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto case 12;
        default:
label_3:
          if (A_1.Error != null)
          {
            num2 = (short) 11;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto label_25;
      }
      num2 = (short) 0;
      num1 = (int) (IntPtr) num2;
    }
label_25:
    this.CloseBtn.IsEnabled = true;
    this.a.OkToCancel = true;
  }

  private void OnBackgroundWorkerProgressChanged(object A_0, ProgressChangedEventArgs A_1)
  {
    int num1;
    ProgressUserState userState1;
    short num2;
    switch (0)
    {
      case 0:
label_2:
        this.progressBar2.Value = (double) A_1.ProgressPercentage;
        userState1 = A_1.UserState as ProgressUserState;
        num2 = (short) -26616;
        int num3 = (int) num2;
        num2 = (short) -26616;
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
            num2 = (short) 2;
            num1 = (int) (IntPtr) num2;
            goto label_1;
        }
        break;
      default:
        RadioInfoParams userState2;
        while (true)
        {
          switch (num1)
          {
            case 0:
              if (userState2 != null)
              {
                num2 = (short) 1;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_14;
            case 1:
              this.RadioModelTextBox.Text = userState2.ModelNumber;
              this.RadioSerialNoTextBox.Text = userState2.SerialNumber;
              num2 = (short) 4;
              num1 = (int) (IntPtr) num2;
              continue;
            case 2:
              if (userState1 != null)
              {
                num2 = (short) 3;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_8;
            case 3:
              goto label_12;
            case 4:
              goto label_14;
            default:
              goto label_2;
          }
label_1:;
        }
label_8:
        userState2 = A_1.UserState as RadioInfoParams;
        break;
label_12:
        num2 = (short) 1;
        if (num2 == (short) 0)
          ;
        this.myStsParagraph.Inlines.Clear();
        this.myStsParagraph.Inlines.Add(userState1.UserText);
        this.a(userState1.CurrentUserState);
        this.a(userState1.NewUserState);
        return;
label_14:
        num2 = (short) 0;
        return;
    }
    num2 = (short) 0;
    num1 = (int) (IntPtr) num2;
    goto label_1;
  }

  private void a(UserState A_0)
  {
    int A_1 = 8;
    int num1 = 1;
    while (true)
    {
      short num2;
      switch (num1)
      {
        case 0:
          goto label_16;
        case 1:
          num2 = (short) 1;
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
        case 2:
          num2 = (short) 12378;
          int num3 = (int) num2;
          num2 = (short) 12378;
          int num4 = (int) num2;
          switch (num3 == num4 ? 1 : 0)
          {
            case 0:
              goto label_9;
            case 2:
              goto label_4;
            default:
              num2 = (short) 0;
              if (num2 == (short) 0)
                ;
              num2 = (short) 0;
              num1 = (int) (IntPtr) num2;
              continue;
          }
      }
      num2 = (short) 0;
      switch (A_0)
      {
        case UserState.ConnectStart:
          goto label_14;
        case UserState.ConnectError:
          goto label_12;
        case UserState.ConnectDone:
          goto label_18;
        case UserState.ReadRadInfoStart:
          goto label_21;
        case UserState.ReadRadInfoError:
          goto label_24;
        case UserState.ReadRadInfoDone:
          goto label_17;
        case UserState.ResetFileValidationStart:
          goto label_11;
        case UserState.ResetFileValidationDone:
          goto label_10;
        case UserState.ResetFileValidationError:
          goto label_20;
        case UserState.ResetPasswordStart:
          goto label_15;
        case UserState.ResetPasswordDone:
          goto label_19;
        case UserState.ResetPasswordError:
          goto label_13;
        case UserState.None:
          goto label_23;
        default:
          num2 = (short) 2;
          num1 = (int) (IntPtr) num2;
          continue;
      }
    }
label_23:
    return;
label_9:
    return;
label_4:
    return;
label_10:
    this.ResetFileValidationIndicator.BusyState = BusyStates.COMPLETE_NO_ERROR;
    return;
label_11:
    this.ResetFileValidationIndicator.BusyState = BusyStates.BUSY;
    return;
label_12:
    this.ConnectBusyIndicator.BusyState = BusyStates.COMPLETE_WITH_ERROR;
    return;
label_13:
    this.ResetIndicator.BusyState = BusyStates.COMPLETE_WITH_ERROR;
    return;
label_14:
    this.ConnectBusyIndicator.BusyState = BusyStates.BUSY;
    return;
label_15:
    this.ResetIndicator.BusyState = BusyStates.BUSY;
    return;
label_16:
    throw new ArgumentException(string.Format(RptMgrErrorHandler.b("얊\uE28Cﮎ놐\uE092\uE094\uE796\uE998\uF49A\uEF9C\uEB9E쒠잢薤슦잨\uDEAA사辮잰튲\uD9B4슶\uDCB8膺鶼쒾\uF1C0뻂\uEBC4", A_1), (object) A_0), RptMgrErrorHandler.b("ﺊﺌ\uEA8E\uE390삒\uE194\uF696\uED98ﺚ", A_1));
label_17:
    this.VerifyBusyIndicator.BusyState = BusyStates.COMPLETE_NO_ERROR;
    return;
label_18:
    this.ConnectBusyIndicator.BusyState = BusyStates.COMPLETE_NO_ERROR;
    return;
label_19:
    this.ResetIndicator.BusyState = BusyStates.COMPLETE_NO_ERROR;
    return;
label_20:
    this.ResetFileValidationIndicator.BusyState = BusyStates.COMPLETE_WITH_ERROR;
    return;
label_21:
    this.VerifyBusyIndicator.BusyState = BusyStates.BUSY;
    return;
label_24:
    this.VerifyBusyIndicator.BusyState = BusyStates.COMPLETE_WITH_ERROR;
  }

  private void UploadPasswordResetFile(string A_0, DoWorkEventArgs A_1)
  {
    int num1 = 1;
    while (true)
    {
      short num2;
      switch (num1)
      {
        case 0:
          goto label_5;
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
          num2 = (short) 28022;
          int num3 = (int) num2;
          num2 = (short) 28022;
          int num4 = (int) num2;
          switch (num3 == num4 ? 1 : 0)
          {
            case 0:
            case 2:
              goto label_12;
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
        case 3:
          if (!File.Exists(A_0))
          {
            num2 = (short) 0;
            num2 = (short) 0;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto label_12;
      }
      if (!string.IsNullOrEmpty(A_0))
      {
        num2 = (short) 2;
        num1 = (int) (IntPtr) num2;
      }
      else
        break;
    }
label_5:
    throw new ArgumentException(AppResources.Invalid_reset_password_file);
label_12:
    new SendPasswordResetFileExecutor(this.c, this.b).SendPasswordResetFile(A_0);
  }

  private void Page_Loaded(object A_0, RoutedEventArgs A_1)
  {
    int num1;
    short num2;
    switch (0)
    {
      case 0:
label_2:
        this.myStsParagraph.Inlines.Clear();
        this.NavigationService.Navigating += new NavigatingCancelEventHandler(this.NavigationService_Navigating);
        num2 = (short) 3;
        num1 = (int) (IntPtr) num2;
        goto default;
      default:
        while (true)
        {
          switch (num1)
          {
            case 0:
label_9:
              Keyboard.Focus((IInputElement) this);
              num2 = (short) 1;
              num1 = (int) (IntPtr) num2;
              continue;
            case 1:
              goto label_13;
            case 2:
label_10:
              num2 = (short) 5;
              num1 = (int) (IntPtr) num2;
              continue;
            case 3:
              num2 = (short) 5822;
              int num3 = (int) num2;
              num2 = (short) 5822;
              int num4 = (int) num2;
              switch (num3 == num4 ? 1 : 0)
              {
                case 0:
                case 2:
                  goto label_9;
                case 1:
                  num2 = (short) 0;
                  if (num2 == (short) 0)
                    ;
                  num2 = (short) 1;
                  if (num2 == (short) 0)
                    ;
                  if (!this.c.IsBusy)
                  {
                    num2 = (short) 4;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_10;
                default:
                  num2 = (short) 0;
                  goto case 1;
              }
            case 4:
              this.c.RunWorkerAsync((object) this.a.FilePath);
              num2 = (short) 2;
              num1 = (int) (IntPtr) num2;
              continue;
            case 5:
              if (!this.IsKeyboardFocusWithin)
              {
                num2 = (short) 0;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_15;
            default:
              goto label_2;
          }
        }
label_13:
        break;
label_15:
        break;
    }
  }

  private void NavigationService_Navigating(object A_0, NavigatingCancelEventArgs A_1)
  {
    short num1 = 1;
    if (num1 == (short) 0)
      ;
    num1 = (short) -10957;
    int num2 = (int) num1;
    num1 = (short) -10957;
    int num3 = (int) num1;
    switch (num2 == num3)
    {
      case true:
        num1 = (short) 0;
        num1 = (short) 0;
        if (num1 == (short) 0)
          ;
        A_1.Cancel = true;
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
    num1 = (short) -20463;
    int num2 = (int) num1;
    num1 = (short) -20463;
    int num3 = (int) num1;
    switch (num2 == num3)
    {
      case true:
        num1 = (short) 0;
        num1 = (short) 0;
        if (num1 == (short) 0)
          ;
        this.OnReturn(new ReturnEventArgs<DialogResult>(DialogResult.Finished));
        break;
      default:
        goto case 1;
    }
  }

  private void F1HelpCommandCanExcute(object A_0, CanExecuteRoutedEventArgs A_1)
  {
    short num1 = -29880;
    int num2 = (int) num1;
    num1 = (short) -29880;
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
      short num1 = 19325;
      int num2 = (int) num1;
      num1 = (short) 19325;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          if (true)
            ;
          Utility.CloseHelpWindowIfOpen();
          Utility.DisplayCPSHelpDITA(this.a.ProgressDialogHelpTopicId);
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

  public void FlashportPage_Return(object sender, ReturnEventArgs<DialogResult> e)
  {
    short num1 = -25189;
    int num2 = (int) num1;
    num1 = (short) -25189;
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
        this.OnReturn(e);
        break;
      default:
        num4 = (short) 0;
        goto case 1;
    }
  }

  [GeneratedCode("PresentationBuildTasks", "5.0.10.0")]
  [DebuggerNonUserCode]
  public void InitializeComponent()
  {
    int A_1 = 17;
    if (this.d)
    {
      short num = 24973;
      switch ((short) 24973 == num ? 1 : 0)
      {
        case 0:
          break;
        case 2:
          break;
        default:
          num = (short) 0;
          if (num == (short) 0)
            ;
          num = (short) 0;
          break;
      }
    }
    else
    {
      if (false)
        ;
      this.d = true;
      Application.LoadComponent((object) this, new Uri(RptMgrErrorHandler.b("뮓얕\uE897ﾙﾛ\uF79D솟캡\uE2A3쎥즧\uDEA9\uD9AB\uDCAD햯솱辳햵ힷힹ첻톽꺿\uA7C1\uAAC3닅\uE7C7뫉귋뷍ꏏꗑ믓ꓕ볗꣙맛귝藟雡苣迥蓧迩쏫黭釯闱釳蓵鷷觹駻諽狿持怃漅朇稉洋納挏攑笓搕簗標減焝䜟倡䄣唥嬧Щ含伭崯帱", A_1), UriKind.Relative));
    }
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "5.0.10.0")]
  internal Delegate _CreateDelegate(Type delegateType, string handler)
  {
    short num1 = 1;
    if (num1 == (short) 0)
      ;
    num1 = (short) 0;
    num1 = (short) -4596;
    int num2 = (int) num1;
    num1 = (short) -4596;
    int num3 = (int) num1;
    switch (num2 == num3)
    {
      case true:
        num1 = (short) 0;
        if (num1 == (short) 0)
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
    int num1 = 1;
    while (true)
    {
      switch (num1)
      {
        case 0:
          num1 = 2;
          continue;
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
          goto label_31;
      }
      switch (connectionId)
      {
        case 1:
          goto label_29;
        case 2:
          goto label_9;
        case 3:
          goto label_21;
        case 4:
          goto label_7;
        case 5:
          goto label_15;
        case 6:
          goto label_22;
        case 7:
          goto label_23;
        case 8:
          goto label_19;
        case 9:
          goto label_26;
        case 10:
          goto label_27;
        case 11:
          goto label_12;
        case 12:
          goto label_6;
        case 13:
          goto label_28;
        case 14:
          goto label_25;
        case 15:
          goto label_10;
        case 16 /*0x10*/:
          goto label_5;
        case 17:
          goto label_30;
        case 18:
          goto label_24;
        case 19:
          goto label_8;
        case 20:
          goto label_16;
        case 21:
          goto label_11;
        case 22:
          goto label_18;
        default:
          num1 = 0;
          continue;
      }
    }
label_5:
    this.ResetFileValidationIndicator = (SpecialFeatures.FileOperations.BusyIndicator) target;
    return;
label_6:
    this.stackMoreInfo = (StackPanel) target;
    return;
label_7:
    this.Divider_Copy = (Rectangle) target;
    return;
label_8:
    this.myStsParagraph = (Paragraph) target;
    return;
label_9:
    ((CommandBinding) target).Executed += new ExecutedRoutedEventHandler(this.buttonHelp_Click);
    ((CommandBinding) target).CanExecute += new CanExecuteRoutedEventHandler(this.F1HelpCommandCanExcute);
    return;
label_10:
    this.VerifyBusyIndicator = (SpecialFeatures.FileOperations.BusyIndicator) target;
    return;
label_11:
    this.CloseBtn = (Button) target;
    this.CloseBtn.Click += new RoutedEventHandler(this.ObButtonClick_Close);
    return;
label_12:
    short num2 = 23804;
    int num3 = (int) num2;
    num2 = (short) 23804;
    int num4 = (int) num2;
    switch (num3 == num4 ? 1 : 0)
    {
      case 0:
      case 2:
        goto label_25;
      default:
        if (true)
          ;
        this.GrpbxProgress = (GroupBox) target;
        return;
    }
label_15:
    this.ViewboxTitle = (Label) target;
    return;
label_16:
    if (false)
      ;
    this.progressBar2 = (ProgressBar) target;
    return;
label_18:
    this.HelpBtn = (Button) target;
    this.HelpBtn.Click += new RoutedEventHandler(this.buttonHelp_Click);
    return;
label_19:
    this.RadioModelTextBox = (TextBox) target;
    return;
label_21:
    this.Header = (Grid) target;
    return;
label_22:
    this.GrpbxRadioParams = (GroupBox) target;
    return;
label_23:
    this.lblRadioModel = (Label) target;
    return;
label_24:
    this.ProgText = (FlowDocumentScrollViewer) target;
    return;
label_25:
    this.ConnectBusyIndicator = (SpecialFeatures.FileOperations.BusyIndicator) target;
    return;
label_26:
    this.lblRadioSerialNo = (Label) target;
    return;
label_27:
    this.RadioSerialNoTextBox = (TextBox) target;
    return;
label_28:
    this.ConnectingToRadioLabel = (Label) target;
    return;
label_29:
    ((FrameworkElement) target).Loaded += new RoutedEventHandler(this.Page_Loaded);
    return;
label_30:
    this.ResetIndicator = (SpecialFeatures.FileOperations.BusyIndicator) target;
    return;
label_31:
    this.d = true;
  }
}
