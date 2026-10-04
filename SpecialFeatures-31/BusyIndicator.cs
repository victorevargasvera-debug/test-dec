// Decompiled with JetBrains decompiler
// Type: BusyIndicator
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using SpecialFeatures.AcpReportManagerLib;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Markup;

#nullable disable
public class BusyIndicator : ResourceDictionary, IComponentConnector
{
  private bool a;

  [GeneratedCode("PresentationBuildTasks", "5.0.10.0")]
  [DebuggerNonUserCode]
  public void InitializeComponent()
  {
    int A_1 = 8;
    short num1 = 26813;
    int num2 = (int) num1;
    num1 = (short) 26813;
    int num3 = (int) num1;
    switch (num2 == num3 ? 1 : 0)
    {
      case 0:
        break;
      case 2:
        break;
      default:
        short num4 = 1;
        if (num4 == (short) 0)
          ;
        num4 = (short) 0;
        if (num4 == (short) 0)
          ;
        if (this.a)
          break;
        num4 = (short) 0;
        this.a = true;
        Application.LoadComponent((object) this, new Uri(RptMgrErrorHandler.b("ꒊ\uDE8Cﾎ\uF490\uF092ﲔ\uF696\uF598\uDD9A\uF89Cﺞ햠횢\uD7A4슦\uDAA8邪캬삮\uDCB0쎲\uDAB4\uD9B6\uDCB8햺즼邾\uA7C0ꫂ꧄ꋆꛈ믊\uA8CC뷎냐\uA7D2볔룖럘\uA8DA\uF2DC뷞铠郢鳤軦蟨迪蓬賮郰蟲髴藶ퟸ菺鳼鋾洀", A_1), UriKind.Relative));
        break;
    }
  }

  [EditorBrowsable(EditorBrowsableState.Never)]
  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "5.0.10.0")]
  void IComponentConnector.Connect(int connectionId, object target)
  {
    short num1 = 13694;
    int num2 = (int) num1;
    num1 = (short) 13694;
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
        this.a = true;
        break;
      default:
        num4 = (short) 0;
        goto case 1;
    }
  }
}
