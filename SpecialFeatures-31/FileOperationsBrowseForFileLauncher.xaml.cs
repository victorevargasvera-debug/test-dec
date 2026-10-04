// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.FileOperations.BrowseForFileLauncher
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using AcpUI.Common;
using SpecialFeatures.AcpReportManagerLib;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Navigation;

#nullable disable
namespace SpecialFeatures.FileOperations;

public partial class BrowseForFileLauncher : PageFunction<DialogResult>, IComponentConnector
{
  private bool d;

  public event FileOperationReturnEventHandler FileOperationReturn
  {
    add
    {
      int num1;
      short num2;
      FileOperationReturnEventHandler returnEventHandler;
      switch (0)
      {
        case 0:
label_2:
          num2 = (short) 27886;
          int num3 = (int) num2;
          num2 = (short) 27886;
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
              num2 = (short) 1;
              if (num2 == (short) 0)
                ;
              returnEventHandler = this.a;
              num2 = (short) 2;
              num1 = (int) (IntPtr) num2;
              goto label_1;
          }
          break;
        default:
          FileOperationReturnEventHandler comparand;
          while (true)
          {
            switch (num1)
            {
              case 0:
                goto label_10;
              case 1:
                if (returnEventHandler == comparand)
                {
                  num2 = (short) 0;
                  num1 = (int) (IntPtr) num2;
                  continue;
                }
                goto label_6;
              case 2:
                goto label_6;
              default:
                goto label_2;
            }
label_1:;
          }
label_10:
          return;
label_6:
          num2 = (short) 0;
          comparand = returnEventHandler;
          returnEventHandler = Interlocked.CompareExchange<FileOperationReturnEventHandler>(ref this.a, comparand + value, comparand);
          break;
      }
      num2 = (short) 1;
      num1 = (int) (IntPtr) num2;
      goto label_1;
    }
    remove
    {
      short num1;
      int num2;
      FileOperationReturnEventHandler returnEventHandler;
      switch (0)
      {
        case 0:
label_3:
          num1 = (short) 30878;
          int num3 = (int) num1;
          num1 = (short) 30878;
          int num4 = (int) num1;
          switch (num3 == num4 ? 1 : 0)
          {
            case 0:
            case 2:
              break;
            default:
              num1 = (short) 0;
              if (num1 == (short) 0)
                ;
              returnEventHandler = this.a;
              num1 = (short) 2;
              num2 = (int) (IntPtr) num1;
              goto label_1;
          }
          break;
        default:
          FileOperationReturnEventHandler comparand;
          while (true)
          {
            num1 = (short) 1;
            if (num1 == (short) 0)
              ;
            switch (num2)
            {
              case 0:
                goto label_10;
              case 1:
                if (returnEventHandler == comparand)
                {
                  num1 = (short) 0;
                  num2 = (int) (IntPtr) num1;
                  continue;
                }
                goto label_6;
              case 2:
                goto label_6;
              default:
                goto label_3;
            }
label_1:;
          }
label_10:
          return;
label_6:
          num1 = (short) 0;
          comparand = returnEventHandler;
          returnEventHandler = Interlocked.CompareExchange<FileOperationReturnEventHandler>(ref this.a, comparand - value, comparand);
          break;
      }
      num1 = (short) 1;
      num2 = (int) (IntPtr) num1;
      goto label_1;
    }
  }

  public BrowseForFileLauncher(
    System.Action<BrowseForFilePage> action,
    FileOperationData fileOperationData)
  {
    // ISSUE: reference to a compiler-generated field
    this.b = action;
    this.FileOperationData = fileOperationData;
  }

  public System.Action<BrowseForFilePage> Action
  {
    get
    {
      short num = -17542;
      switch ((short) -17542 == num)
      {
        case true:
          num = (short) 1;
          if (num == (short) 0)
            ;
          num = (short) 0;
          if (num == (short) 0)
            ;
          return this.b;
        default:
          goto case 1;
      }
    }
  }

  internal FileOperationData FileOperationData
  {
    get
    {
      short num1 = 0;
      num1 = (short) 1;
      if (num1 == (short) 0)
        ;
      num1 = (short) 27114;
      int num2 = (int) num1;
      num1 = (short) 27114;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          return this.c;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = 0;
      num1 = (short) 15694;
      int num2 = (int) num1;
      num1 = (short) 15694;
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
          this.c = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  protected override void Start()
  {
    switch (true)
    {
      case true:
        if (false)
          ;
        if (true)
          ;
        Utility.SetDirection((FrameworkElement) this);
        base.Start();
        this.KeepAlive = true;
        BrowseForFilePage root = new BrowseForFilePage(this.FileOperationData, this.Action);
        root.Return += new ReturnEventHandler<DialogResult>(this.OnBrowseForFileReturn);
        this.NavigationService.Navigate((object) root);
        break;
      default:
        goto case 1;
    }
  }

  internal void OnBrowseForFileReturn(object sender, ReturnEventArgs<DialogResult> e)
  {
    short num1 = 1;
    if (num1 == (short) 0)
      ;
    num1 = (short) 2;
    int num2 = (int) (IntPtr) num1;
    while (true)
    {
      num1 = (short) 0;
      num1 = (short) -10543;
      int num3 = (int) num1;
      num1 = (short) -10543;
      int num4 = (int) num1;
      switch (num3 == num4 ? 1 : 0)
      {
        case 0:
        case 2:
          goto label_9;
        default:
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          switch (num2)
          {
            case 0:
              goto label_9;
            case 1:
              // ISSUE: reference to a compiler-generated field
              this.a((object) this, new FileOperationReturnEventArgs(e.Result, (object) this.FileOperationData));
              num1 = (short) 0;
              num2 = (int) (IntPtr) num1;
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
          // ISSUE: reference to a compiler-generated field
          if (this.a != null)
          {
            num1 = (short) 1;
            num2 = (int) (IntPtr) num1;
            continue;
          }
          goto label_9;
      }
    }
label_9:
    this.OnReturn((ReturnEventArgs<DialogResult>) null);
  }

  [GeneratedCode("PresentationBuildTasks", "5.0.10.0")]
  [DebuggerNonUserCode]
  public void InitializeComponent()
  {
    int A_1 = 17;
    short num1 = -20912;
    int num2 = (int) num1;
    num1 = (short) -20912;
    int num3 = (int) num1;
    short num4;
    switch (num2 == num3 ? 1 : 0)
    {
      case 0:
      case 2:
        this.d = true;
        Application.LoadComponent((object) this, new Uri(RptMgrErrorHandler.b("뮓얕\uE897ﾙﾛ\uF79D솟캡\uE2A3쎥즧\uDEA9\uD9AB\uDCAD햯솱辳햵ힷힹ첻톽꺿\uA7C1\uAAC3닅\uE7C7곉ꗋꋍ뗏뷑ꓓ돕\uAAD7믙\uA8DB럝迟賡韣짥諧飩菫駭華韱鋳駵諷鳹闻鋽旿渁攃猅昇椉搋欍戏㰑氓眕甗瘙", A_1), UriKind.Relative));
        break;
      case 1:
        num4 = (short) 0;
        if (num4 == (short) 0)
          ;
        num4 = (short) 1;
        if (num4 == (short) 0)
          ;
        if (this.d)
          break;
        goto case 0;
      default:
        num4 = (short) 0;
        goto case 1;
    }
  }

  [DebuggerNonUserCode]
  [EditorBrowsable(EditorBrowsableState.Never)]
  [GeneratedCode("PresentationBuildTasks", "5.0.10.0")]
  void IComponentConnector.Connect(int connectionId, object target)
  {
    if (false)
      ;
    short num1 = 31750;
    int num2 = (int) num1;
    num1 = (short) 31750;
    int num3 = (int) num1;
    switch (num2 == num3)
    {
      case true:
        num1 = (short) 0;
        if (num1 == (short) 0)
          ;
        this.d = true;
        break;
      default:
        goto case 1;
    }
  }
}
