// Decompiled with JetBrains decompiler
// Type: ACPBrowser.ContextHelp
// Assembly: ACPBrowser, Version=1.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 8594EB5B-A9B7-4EA3-AB9A-BDF8416D55ED
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\ACPBrowser.dll

using CefSharp;
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

public partial class ContextHelp : UserControl, IComponentConnector
{
  private string currentUrlLoaded = string.Empty;
  internal ChromiumWebBrowser myBrowser;
  private bool _contentLoaded;

  static ContextHelp() => Utility.SubscribeAnyCpuAssemblyResolver();

  public ContextHelp() => this.InitializeComponent();

  public void ShowSingleFileHelp(string fileName)
  {
    if (string.IsNullOrEmpty(fileName))
      return;
    this.DisplayHelp(HelpFilePathProvider.BuildPathForHelpByTagContextMenu(fileName));
  }

  public void ShowMultipleFileHelp(string fileName)
  {
    if (string.IsNullOrEmpty(fileName))
      return;
    this.DisplayHelp(HelpFilePathProvider.BuildPathForHelpByFileContextMenu(fileName));
  }

  private void DisplayHelp(string fieldHelpPath)
  {
    if (string.IsNullOrEmpty(fieldHelpPath))
      return;
    if (this.currentUrlLoaded.Equals(fieldHelpPath))
      return;
    try
    {
      this.myBrowser.Load(fieldHelpPath);
      this.currentUrlLoaded = fieldHelpPath;
      string RemoveNavigationTreeJSInjection = "document.getElementsByTagName('header')[0].remove(); document.getElementsByTagName('footer')[0].remove();document.getElementsByClassName('slide-btn')[0].remove();document.getElementsByClassName('nav-container')[0].remove();document.getElementsByClassName('content-container')[0].style.height = 'auto';document.getElementsByClassName('container')[0].style.margin = '10px'; ";
      this.myBrowser.LoadingStateChanged += (EventHandler<LoadingStateChangedEventArgs>) ((sender, args) =>
      {
        if (args.IsLoading)
          return;
        WebBrowserExtensions.ExecuteScriptAsyncWhenPageLoaded((IChromiumWebBrowserBase) this.myBrowser, RemoveNavigationTreeJSInjection, true);
      });
    }
    catch (Exception ex)
    {
    }
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "8.0.3.0")]
  public void InitializeComponent()
  {
    if (this._contentLoaded)
      return;
    this._contentLoaded = true;
    Application.LoadComponent((object) this, new Uri("/ACPBrowser;component/contexthelp.xaml", UriKind.Relative));
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "8.0.3.0")]
  [EditorBrowsable(EditorBrowsableState.Never)]
  void IComponentConnector.Connect(int connectionId, object target)
  {
    if (connectionId == 1)
      this.myBrowser = (ChromiumWebBrowser) target;
    else
      this._contentLoaded = true;
  }
}
