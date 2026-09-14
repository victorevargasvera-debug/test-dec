// Decompiled with JetBrains decompiler
// Type: MackinawCPS.Log.UpdateLogSettingView
// Assembly: APXFamilyCPS, Version=36.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 9359335E-041C-4B12-9409-F4E6E7D93299
// Assembly location: C:\Program Files (x86)\Motorola\ApxFamilyCPS R36.00\APXFamilyCPS1.exe

using AcpUI;
using AcpUI.Common;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Navigation;

#nullable disable
namespace MackinawCPS.Log;

public partial class UpdateLogSettingView : PageFunction<string>, IComponentConnector
{
  internal AcpButton btnYes;
  internal AcpButton btnNo;
  private bool _contentLoaded;

  public UpdateLogSettingView(LogSetting logSetting)
  {
    this.InitializeComponent();
    Utility.SetDirection((FrameworkElement) this);
    this.DataContext = (object) new UpdateLogSettingViewModel(this, logSetting);
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "8.0.8.0")]
  public void InitializeComponent()
  {
    if (this._contentLoaded)
      return;
    this._contentLoaded = true;
    Application.LoadComponent((object) this, new Uri("/APXFamilyCPS;component/log/updatelogsettingview.xaml", UriKind.Relative));
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "8.0.8.0")]
  [EditorBrowsable(EditorBrowsableState.Never)]
  void IComponentConnector.Connect(int connectionId, object target)
  {
    if (connectionId != 1)
    {
      if (connectionId == 2)
        this.btnNo = (AcpButton) target;
      else
        this._contentLoaded = true;
    }
    else
      this.btnYes = (AcpButton) target;
  }
}
