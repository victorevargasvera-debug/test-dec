// Decompiled with JetBrains decompiler
// Type: ACPBrowser.HelpWindow
// Assembly: ACPBrowser, Version=1.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 8594EB5B-A9B7-4EA3-AB9A-BDF8416D55ED
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\ACPBrowser.dll

using CefSharp.Wpf;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

#nullable disable
namespace ACPBrowser;

public partial class HelpWindow : Window, IComponentConnector
{
  internal Grid NavigationGrid;
  internal Button backBtn;
  internal Button forwardBtn;
  internal ChromiumWebBrowser MainHelpBrowser;
  private bool _contentLoaded;

  static HelpWindow() => Utility.SubscribeAnyCpuAssemblyResolver();

  public bool IsClosed { get; private set; }

  internal bool IsWindowBeingDisplayed { get; private set; }

  public HelpWindow()
  {
    this.InitializeComponent();
    this.IsWindowBeingDisplayed = false;
  }

  private void Window_Closed(object sender, EventArgs e) => this.IsClosed = true;

  internal void Go(string url)
  {
    if (this.MainHelpBrowser.IsLoading)
      return;
    this.MainHelpBrowser.Load(url);
  }

  internal void CloseWindow()
  {
    this.IsClosed = true;
    this.IsWindowBeingDisplayed = false;
    this.Close();
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "8.0.3.0")]
  public void InitializeComponent()
  {
    if (this._contentLoaded)
      return;
    this._contentLoaded = true;
    Application.LoadComponent((object) this, new Uri("/ACPBrowser;component/helpwindow.xaml", UriKind.Relative));
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "8.0.3.0")]
  [EditorBrowsable(EditorBrowsableState.Never)]
  void IComponentConnector.Connect(int connectionId, object target)
  {
    switch (connectionId)
    {
      case 1:
        ((Window) target).Closed += new EventHandler(this.Window_Closed);
        break;
      case 2:
        this.NavigationGrid = (Grid) target;
        break;
      case 3:
        this.backBtn = (Button) target;
        break;
      case 4:
        this.forwardBtn = (Button) target;
        break;
      case 5:
        this.MainHelpBrowser = (ChromiumWebBrowser) target;
        break;
      default:
        this._contentLoaded = true;
        break;
    }
  }
}
