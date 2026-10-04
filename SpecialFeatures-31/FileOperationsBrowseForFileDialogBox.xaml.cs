// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.FileOperations.BrowseForFileDialogBox
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

public partial class BrowseForFileDialogBox : Window, IComponentConnector
{
  private readonly Type a;
  private bool b;
  internal Label operationLabel;
  internal System.Windows.Controls.Frame BrowseForFileMainFrame;
  private bool d;

  public BrowseForFileDialogBox(
    Action<BrowseForFilePage> action,
    FileOperationData fileOperationData,
    Type expectedProgressPageType)
  {
    this.a = expectedProgressPageType;
    this.FileOperationData = fileOperationData;
    Utility.SetDirection((FrameworkElement) this);
    this.b = false;
    this.InitializeComponent();
    BrowseForFileLauncher content = new BrowseForFileLauncher(action, this.FileOperationData);
    content.FileOperationReturn += new FileOperationReturnEventHandler(this.a);
    this.BrowseForFileMainFrame.Navigate((object) content);
  }

  public FileOperationData FileOperationData
  {
    get
    {
      short num1 = -31660;
      int num2 = (int) num1;
      num1 = (short) -31660;
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
          return this.c;
        default:
          goto case 1;
      }
    }
    private set
    {
      short num1 = 18287;
      int num2 = (int) num1;
      num1 = (short) 18287;
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
          this.c = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  private void a(object A_0, FileOperationReturnEventArgs A_1)
  {
    int num1;
    bool? dialogResult;
    short num2;
    switch (0)
    {
      case 0:
label_2:
        this.b = true;
        this.FileOperationData = A_1.Data as FileOperationData;
        dialogResult = this.DialogResult;
        num2 = (short) 0;
        num2 = (short) 1;
        num1 = (int) (IntPtr) num2;
        goto default;
      default:
        while (true)
        {
          switch (num1)
          {
            case 0:
              goto label_9;
            case 1:
label_3:
              if (!dialogResult.HasValue)
              {
                num2 = (short) 2;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_10;
            case 2:
              this.DialogResult = new bool?(A_1.Result == SpecialFeatures.FileOperations.DialogResult.Finished);
              num2 = (short) 22815;
              int num3 = (int) num2;
              num2 = (short) 22815;
              int num4 = (int) num2;
              switch (num3 == num4 ? 1 : 0)
              {
                case 0:
                case 2:
                  goto label_3;
                default:
                  num2 = (short) 0;
                  if (num2 == (short) 0)
                    ;
                  num2 = (short) 0;
                  num1 = (int) (IntPtr) num2;
                  continue;
              }
            default:
              goto label_2;
          }
        }
label_10:
        break;
label_9:
        num2 = (short) 1;
        if (num2 == (short) 0)
          break;
        break;
    }
  }

  private void NavigationWindow_Closing(object A_0, CancelEventArgs A_1)
  {
    int num1 = 2;
    while (true)
    {
      short num2;
      switch (num1)
      {
        case 0:
          if (!this.b)
          {
            num2 = (short) 1;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto label_8;
        case 1:
          A_1.Cancel = true;
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
          num2 = (short) -15825;
          int num3 = (int) num2;
          num2 = (short) -15825;
          int num4 = (int) num2;
          switch (num3 == num4 ? 1 : 0)
          {
            case 0:
            case 2:
              continue;
            default:
              num2 = (short) 0;
              if (num2 == (short) 0)
                ;
              num2 = (short) 0;
              num1 = (int) (IntPtr) num2;
              continue;
          }
        case 4:
          goto label_6;
      }
      num2 = (short) 1;
      if (num2 == (short) 0)
        ;
      num2 = (short) 0;
      if (this.FileOperationData.CurrentPage.GetType() == this.a)
      {
        num2 = (short) 3;
        num1 = (int) (IntPtr) num2;
      }
      else
        goto label_14;
    }
label_6:
    return;
label_14:
    return;
label_8:;
  }

  private void Window_MouseLeftButtonDown(object A_0, MouseButtonEventArgs A_1)
  {
label_0:
    short num1 = 1;
    int num2 = (int) (IntPtr) num1;
    while (true)
    {
      num1 = (short) 0;
      switch (num2)
      {
        case 0:
          goto label_8;
        case 1:
          num1 = (short) 1;
          if (num1 == (short) 0)
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
          num1 = (short) 15129;
          int num3 = (int) num1;
          num1 = (short) 15129;
          int num4 = (int) num1;
          switch (num3 == num4 ? 1 : 0)
          {
            case 0:
            case 2:
              goto label_0;
            default:
              num1 = (short) 0;
              if (num1 == (short) 0)
                ;
              this.OnMouseLeftButtonDown(A_1);
              this.DragMove();
              num1 = (short) 0;
              num2 = (int) (IntPtr) num1;
              continue;
          }
      }
      if (A_1.ChangedButton == MouseButton.Left)
      {
        num1 = (short) 2;
        num2 = (int) (IntPtr) num1;
      }
      else
        goto label_10;
    }
label_8:
    return;
label_10:;
  }

  [GeneratedCode("PresentationBuildTasks", "5.0.10.0")]
  [DebuggerNonUserCode]
  public void InitializeComponent()
  {
    int A_1 = 16 /*0x10*/;
    short num1 = 2371;
    int num2 = (int) num1;
    num1 = (short) 2371;
    int num3 = (int) num1;
    switch (num2 == num3 ? 1 : 0)
    {
      case 0:
      case 2:
        this.d = true;
        Application.LoadComponent((object) this, new Uri(RptMgrErrorHandler.b("벒요\uE796ﲘ\uF89A\uF49Cﺞ춠\uE5A2삤욦\uDDA8\uDEAA\uDFAC쪮슰袲횴\uD8B6풸쮺튼톾꓀귂뇄\uE8C6꿈ꋊꇌ\uAACE뻐ꏒ냔ꗖ룘꿚드냞迠郢쫤藦鯨蓪髬鳮铰闲髴藶\u9FF8鋺釼髾攀樂搄欆昈氊漌怎椐㴒洔瘖琘眚", A_1), UriKind.Relative));
        break;
      case 1:
        short num4 = 1;
        if (num4 == (short) 0)
          ;
        num4 = (short) 0;
        if (num4 == (short) 0)
          ;
        if (this.d)
          break;
        goto case 0;
      default:
        goto case 1;
    }
  }

  [EditorBrowsable(EditorBrowsableState.Never)]
  [GeneratedCode("PresentationBuildTasks", "5.0.10.0")]
  [DebuggerNonUserCode]
  void IComponentConnector.Connect(int connectionId, object target)
  {
    int num1 = 2;
    while (true)
    {
      switch (num1)
      {
        case 0:
          goto label_9;
        case 1:
          num1 = 0;
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
          goto label_7;
        case 2:
          goto label_5;
        case 3:
          goto label_11;
        default:
          num1 = 1;
          continue;
      }
    }
label_5:
    if (false)
      ;
    this.operationLabel = (Label) target;
    this.operationLabel.MouseDown += new MouseButtonEventHandler(this.Window_MouseLeftButtonDown);
    return;
label_7:
    ((Window) target).Closing += new CancelEventHandler(this.NavigationWindow_Closing);
    return;
label_9:
    short num2 = 29988;
    int num3 = (int) num2;
    num2 = (short) 29988;
    int num4 = (int) num2;
    switch (num3 == num4 ? 1 : 0)
    {
      case 0:
      case 2:
        num2 = (short) 0;
        this.d = true;
        return;
      default:
        num2 = (short) 0;
        if (num2 == (short) 0)
          goto case 0;
        goto case 0;
    }
label_11:
    this.BrowseForFileMainFrame = (System.Windows.Controls.Frame) target;
  }
}
