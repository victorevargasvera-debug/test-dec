// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.FileOperations.BrowseForFilePage
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using ACPBrowser;
using AcpFileHandlerLib;
using AcpUI.Common;
using SpecialFeatures.AcpReportManagerLib;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Navigation;
using System.Windows.Shapes;

#nullable disable
namespace SpecialFeatures.FileOperations;

public partial class BrowseForFilePage : PageFunction<DialogResult>, IComponentConnector
{
  internal Grid Main;
  internal Rectangle Divider;
  internal Grid Header;
  internal Label ViewboxTitle;
  internal Grid SelectUpgradeFile1;
  internal Label TitleContent;
  internal TextBox TxtBoxFilePath;
  internal Button HelpBtn;
  internal Button ActionBtn;
  private bool c;

  internal BrowseForFilePage(FileOperationData fileOperationData, System.Action<BrowseForFilePage> action)
  {
    int A_1 = 12;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    if (fileOperationData == null)
      throw new ArgumentNullException(RptMgrErrorHandler.b("\uE98E\uF890ﾒ\uF094\uD896\uE998ﺚ\uEF9Cﺞ햠쪢쪤즦\uEDA8쪪\uD9AC캮", A_1), RptMgrErrorHandler.b("\uDF8E\uE390ﲒ\uE394ﺖﶘﺚ列뾞잠쪢즤슦\uE6A8\uDBAA좬\uDDAE킰잲\uDCB4\uD8B6ힸﾺ\uDCBC쮾ꃀ\uE3C2ꛄꛆ\uA7C8ꗊꋌ믎\uF1D0뇒냔\uF7D6럘껚뇜돞쿠", A_1));
    // ISSUE: reference to a compiler-generated field
    this.b = action != null ? action : throw new ArgumentNullException(RptMgrErrorHandler.b("\uEE8E\uF290\uE792ﲔ\uF896\uF798", A_1), RptMgrErrorHandler.b("\uDF8E\uE390ﲒ\uE394ﺖﶘﺚ列뾞삠삢톤캦욨얪趬첮킰\uDDB2\uDBB4\uD8B6춸鮺\uDFBC\uDABE\uE1C0귂냄ꯆꗈ\uE5CA", A_1));
    Utility.SetDirection((FrameworkElement) this);
    this.FileOperationData = fileOperationData;
    this.FileOperationData.CurrentPage = (object) this;
    this.InitializeComponent();
    this.ViewboxTitle.Content = (object) this.FileOperationData.BrowseDialogTitleContent;
    this.TitleContent.Content = (object) this.FileOperationData.HeadingTitleContent;
    this.ActionBtn.Content = (object) this.FileOperationData.BrowseDialogActionButtonContent;
    this.TxtBoxFilePath.Text = this.FileOperationData.FilePath;
    if (!Thread.CurrentThread.CurrentCulture.Name.ToLower().StartsWith(RptMgrErrorHandler.b("\uEE8E\uE390", A_1)))
      return;
    this.TxtBoxFilePath.FlowDirection = FlowDirection.LeftToRight;
    this.TxtBoxFilePath.TextAlignment = TextAlignment.Right;
  }

  public FileOperationData FileOperationData
  {
    get
    {
      short num1 = 0;
      num1 = (short) -28660;
      int num2 = (int) num1;
      num1 = (short) -28660;
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
      short num1 = 0;
      num1 = (short) 6943;
      int num2 = (int) num1;
      num1 = (short) 6943;
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

  public System.Action<BrowseForFilePage> Action
  {
    get
    {
      short num1 = 0;
      num1 = (short) -20022;
      int num2 = (int) num1;
      num1 = (short) -20022;
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
          return this.b;
        default:
          goto case 1;
      }
    }
  }

  private void OnButtonClickBrowse(object A_0, RoutedEventArgs A_1)
  {
    int num1 = 0;
    switch (num1)
    {
      default:
        AcpOpenFileDialog acpOpenFileDialog;
        bool? nullable;
        bool flag;
        short num2;
        switch (0)
        {
          case 0:
label_3:
            acpOpenFileDialog = new AcpOpenFileDialog();
            ((AcpFileDialog) acpOpenFileDialog).Filter = this.FileOperationData.Filter;
            AcpFileDialog.InitialDirectory = this.FileOperationData.InitialDirectory;
            nullable = ((AcpFileDialog) acpOpenFileDialog).ShowDialog();
            flag = true;
            num2 = (short) 0;
            num1 = (int) (IntPtr) num2;
            goto default;
          default:
            string fileName;
            while (true)
            {
              switch (num1)
              {
                case 0:
                  if (nullable.GetValueOrDefault() == flag & nullable.HasValue)
                  {
                    num2 = (short) 4;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_15;
                case 1:
label_9:
                  if (fileName != null)
                  {
                    num2 = (short) 1;
                    if (num2 == (short) 0)
                      ;
                    num2 = (short) 0;
                    num2 = (short) 2;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_11;
                case 2:
                  num2 = (short) 9102;
                  int num3 = (int) num2;
                  num2 = (short) 9102;
                  int num4 = (int) num2;
                  switch (num3 == num4 ? 1 : 0)
                  {
                    case 0:
                    case 2:
                      goto label_9;
                    default:
                      num2 = (short) 0;
                      if (num2 == (short) 0)
                        ;
                      this.TxtBoxFilePath.Text = fileName;
                      this.FileOperationData.FilePath = fileName;
                      this.FileOperationData.InitialDirectory = System.IO.Path.GetDirectoryName(fileName);
                      num2 = (short) 3;
                      num1 = (int) (IntPtr) num2;
                      continue;
                  }
                case 3:
                  goto label_7;
                case 4:
                  fileName = ((AcpFileDialog) acpOpenFileDialog).FileName;
                  num2 = (short) 1;
                  num1 = (int) (IntPtr) num2;
                  continue;
                default:
                  goto label_3;
              }
            }
label_7:
            return;
label_15:
            return;
label_11:
            return;
        }
    }
  }

  private void OnLoaded(object A_0, RoutedEventArgs A_1)
  {
    int num1 = 2;
    while (true)
    {
      short num2 = -2024;
      int num3 = (int) num2;
      num2 = (short) -2024;
      int num4 = (int) num2;
      switch (num3 == num4 ? 1 : 0)
      {
        case 0:
          goto label_10;
        case 1:
          num2 = (short) 0;
          if (num2 == (short) 0)
            ;
          switch (num1)
          {
            case 0:
              goto label_13;
            case 1:
              Keyboard.Focus((IInputElement) this);
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
          num2 = (short) 1;
          if (num2 == (short) 0)
            ;
          if (!this.IsKeyboardFocusWithin)
          {
            num2 = (short) 1;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto label_12;
        case 2:
          goto label_3;
        default:
          num2 = (short) 0;
          goto case 1;
      }
    }
label_10:
    return;
label_3:
    return;
label_13:
    return;
label_12:;
  }

  private void OnF1HelpCommandCanExcute(object A_0, CanExecuteRoutedEventArgs A_1)
  {
    short num1 = 0;
    num1 = (short) 23387;
    int num2 = (int) num1;
    num1 = (short) 23387;
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

  private void OnButtonClickF1Help(object A_0, RoutedEventArgs A_1)
  {
    try
    {
      short num1 = -19788;
      int num2 = (int) num1;
      num1 = (short) -19788;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          if (true)
            ;
          Utility.CloseHelpWindowIfOpen();
          Utility.DisplayCPSHelpDITA(this.FileOperationData.BrowseDialogHelpTopicId);
          break;
        default:
          goto case 1;
      }
    }
    catch (Exception ex)
    {
    }
    short num = 1;
    if (num == (short) 0)
      ;
    num = (short) 0;
  }

  private void OnButtonClickCancel(object A_0, RoutedEventArgs A_1)
  {
    short num1 = 0;
    num1 = (short) -704;
    int num2 = (int) num1;
    num1 = (short) -704;
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
        this.OnReturn(new ReturnEventArgs<DialogResult>(DialogResult.Canceled));
        break;
      default:
        goto case 1;
    }
  }

  private void OnButtonClickAction(object A_0, RoutedEventArgs A_1)
  {
    short num1 = 0;
    num1 = (short) -5958;
    int num2 = (int) num1;
    num1 = (short) -5958;
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
        this.Action(this);
        break;
      default:
        goto case 1;
    }
  }

  public void OnPageReturn(object sender, ReturnEventArgs<DialogResult> e)
  {
    short num1 = 0;
    num1 = (short) 19284;
    int num2 = (int) num1;
    num1 = (short) 19284;
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
        this.OnReturn(e);
        break;
      default:
        goto case 1;
    }
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "5.0.10.0")]
  public void InitializeComponent()
  {
    int A_1 = 16 /*0x10*/;
    short num1 = -2804;
    int num2 = (int) num1;
    num1 = (short) -2804;
    int num3 = (int) num1;
    short num4;
    switch (num2 == num3 ? 1 : 0)
    {
      case 0:
      case 2:
        this.c = true;
        Application.LoadComponent((object) this, new Uri(RptMgrErrorHandler.b("벒요\uE796ﲘ\uF89A\uF49Cﺞ춠\uE5A2삤욦\uDDA8\uDEAA\uDFAC쪮슰袲횴\uD8B6풸쮺튼톾꓀귂뇄\uE8C6꿈ꋊꇌ\uAACE뻐ꏒ냔ꗖ룘꿚드냞迠郢쫤藦鯨蓪髬鳮铰闲髴藶\u9FF8鋺釼髾焀戂戄戆✈猊氌戎紐", A_1), UriKind.Relative));
        break;
      case 1:
        num4 = (short) 0;
        if (num4 == (short) 0)
          ;
        if (this.c)
        {
          num4 = (short) 1;
          if (num4 == (short) 0)
            break;
          break;
        }
        goto case 0;
      default:
        num4 = (short) 0;
        goto case 1;
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
          goto label_22;
        case 1:
          num2 = (short) 0;
          num1 = (int) (IntPtr) num2;
          continue;
        case 2:
          num2 = (short) 0;
          switch (0)
          {
            case 0:
              break;
            default:
              continue;
          }
          break;
      }
      num2 = (short) 1;
      if (num2 == (short) 0)
        ;
      switch (connectionId)
      {
        case 1:
          goto label_10;
        case 2:
          goto label_8;
        case 3:
          goto label_14;
        case 4:
          goto label_17;
        case 5:
          goto label_21;
        case 6:
          goto label_13;
        case 7:
          goto label_7;
        case 8:
          goto label_16;
        case 9:
          goto label_6;
        case 10:
          goto label_11;
        case 11:
          goto label_9;
        case 12:
          goto label_15;
        case 13:
          goto label_12;
        default:
          num2 = (short) 1;
          num1 = (int) (IntPtr) num2;
          continue;
      }
    }
label_6:
    this.TxtBoxFilePath = (TextBox) target;
    return;
label_7:
    this.SelectUpgradeFile1 = (Grid) target;
    return;
label_8:
    ((CommandBinding) target).Executed += new ExecutedRoutedEventHandler(this.OnButtonClickF1Help);
    ((CommandBinding) target).CanExecute += new CanExecuteRoutedEventHandler(this.OnF1HelpCommandCanExcute);
    return;
label_9:
    this.HelpBtn = (Button) target;
    this.HelpBtn.Click += new RoutedEventHandler(this.OnButtonClickF1Help);
    return;
label_10:
    ((FrameworkElement) target).Loaded += new RoutedEventHandler(this.OnLoaded);
    return;
label_11:
    ((ButtonBase) target).Click += new RoutedEventHandler(this.OnButtonClickBrowse);
    return;
label_12:
    this.ActionBtn = (Button) target;
    this.ActionBtn.Click += new RoutedEventHandler(this.OnButtonClickAction);
    return;
label_13:
    this.ViewboxTitle = (Label) target;
    return;
label_14:
    this.Main = (Grid) target;
    return;
label_15:
    ((ButtonBase) target).Click += new RoutedEventHandler(this.OnButtonClickCancel);
    return;
label_16:
    this.TitleContent = (Label) target;
    return;
label_17:
    num2 = (short) -32120;
    int num3 = (int) num2;
    num2 = (short) -32120;
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
        this.Divider = (Rectangle) target;
        return;
    }
label_21:
    this.Header = (Grid) target;
    return;
label_22:
    this.c = true;
  }
}
