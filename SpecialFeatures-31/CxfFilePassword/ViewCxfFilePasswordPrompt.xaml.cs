// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.CxfFilePassword.View.CxfFilePasswordPrompt
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
using System.Windows.Markup;

#nullable disable
namespace SpecialFeatures.CxfFilePassword.View;

public partial class CxfFilePasswordPrompt : Window, IComponentConnector
{
  internal TextBlock FileNameTextBlock;
  internal PasswordBox CxfFilePasswordBox;
  private bool a;

  public CxfFilePasswordPrompt()
  {
    this.InitializeComponent();
    Utility.SetDirection((FrameworkElement) this);
  }

  [GeneratedCode("PresentationBuildTasks", "5.0.10.0")]
  [DebuggerNonUserCode]
  public void InitializeComponent()
  {
    int A_1 = 8;
    short num1;
    while (this.a)
    {
      num1 = (short) -4705;
      int num2 = (int) num1;
      num1 = (short) -4705;
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
          return;
      }
    }
    num1 = (short) 0;
    this.a = true;
    Application.LoadComponent((object) this, new Uri(RptMgrErrorHandler.b("ꒊ\uDE8Cﾎ\uF490\uF092ﲔ\uF696\uF598\uDD9A\uF89Cﺞ햠횢\uD7A4슦\uDAA8邪캬삮\uDCB0쎲\uDAB4\uD9B6\uDCB8햺즼邾ꋀ믂ꏄꇆꃈ\uA7CA\uA8CC뿎냐ꃒꛔꃖ뛘\uA9DA맜\uF0DE韠諢胤郦웨裪闬觮韰髲駴鋶觸髺軼賾瘀氂眄挆礈礊戌戎愐朒㬔漖砘瘚焜", A_1), UriKind.Relative));
  }

  [EditorBrowsable(EditorBrowsableState.Never)]
  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "5.0.10.0")]
  void IComponentConnector.Connect(int connectionId, object target)
  {
    int num1 = 2;
    while (true)
    {
      short num2 = 1162;
      int num3 = (int) num2;
      num2 = (short) 1162;
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
          num2 = (short) 1;
          if (num2 == (short) 0)
            ;
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
          goto label_8;
      }
    }
label_8:
    this.FileNameTextBlock = (TextBlock) target;
    return;
label_13:
    this.CxfFilePasswordBox = (PasswordBox) target;
    return;
label_14:
    this.a = true;
  }
}
