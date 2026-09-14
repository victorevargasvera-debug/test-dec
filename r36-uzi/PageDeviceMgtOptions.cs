// Decompiled with JetBrains decompiler
// Type: MackinawCPS.PageDeviceMgtOptions
// Assembly: APXFamilyCPS, Version=36.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 9359335E-041C-4B12-9409-F4E6E7D93299
// Assembly location: C:\Program Files (x86)\Motorola\ApxFamilyCPS R36.00\APXFamilyCPS1.exe

using AcpUI.Common;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

#nullable disable
namespace MackinawCPS;

public class PageDeviceMgtOptions : Page, IComponentConnector
{
  internal Button ButtonReadRadio;
  internal Button ButtonWriteRadio;
  internal Button ButtonCloneradio;
  internal Button ButtonFlashradio;
  private bool _contentLoaded;

  public PageDeviceMgtOptions()
  {
    this.InitializeComponent();
    Utility.SetDirection((FrameworkElement) this);
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "8.0.8.0")]
  public void InitializeComponent()
  {
    if (this._contentLoaded)
      return;
    this._contentLoaded = true;
    Application.LoadComponent((object) this, new Uri("/APXFamilyCPS;component/devicemanager/pagedevicemgtoptions.xaml", UriKind.Relative));
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "8.0.8.0")]
  [EditorBrowsable(EditorBrowsableState.Never)]
  void IComponentConnector.Connect(int connectionId, object target)
  {
    switch (connectionId)
    {
      case 1:
        this.ButtonReadRadio = (Button) target;
        break;
      case 2:
        this.ButtonWriteRadio = (Button) target;
        break;
      case 3:
        this.ButtonCloneradio = (Button) target;
        break;
      case 4:
        this.ButtonFlashradio = (Button) target;
        break;
      default:
        this._contentLoaded = true;
        break;
    }
  }
}
