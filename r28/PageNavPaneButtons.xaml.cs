// Decompiled with JetBrains decompiler
// Type: MackinawCPS.PageNavPaneButtons
// Assembly: APXFamilyCPS, Version=15.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 7983BD42-76AB-479D-8966-B7B635E0E28A
// Assembly location: C:\Program Files (x86)\Motorola\ApxFamilyDepot R28\APXdepotR28.exe

using AcpCommonLib;
using AcpUI.Common;
using CommonResources;
using DevComponents.WpfDock;
using DevComponents.WpfRibbon;
using MackinawCPS.HomeBase;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;
using System.Windows.Navigation;

#nullable disable
namespace MackinawCPS;

public partial class PageNavPaneButtons : Page, IComponentConnector
{
  private bool bNavigateToContentPage = true;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal NavigationPane AppNavPane;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal PaneItem ButtonHome;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal System.Windows.Controls.Frame FrameHome;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal PaneItem ButtonCpgNav;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal System.Windows.Controls.Frame FrameCodeplug;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal PaneItem ButtonCustomViewMode;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal System.Windows.Controls.Frame FrameCustView;
  private bool _contentLoaded;

  internal void OnButtonClick(object sender, RoutedEventArgs e)
  {
    WindowMain mainWindow = (WindowMain) Application.Current.MainWindow;
    mainWindow.ribbonTabSecurity.Visibility = Visibility.Collapsed;
    if (sender == this.ButtonHome)
    {
      AppInfoManager.AppMode = ApplicationMode.CodeplugConfigurationMode;
      mainWindow.ribbonTabCodeplug.IsSelected = true;
      mainWindow.GetPageIUI.InitializeHelpPanel("aaTopLevel\\aDefaultTopic\\DefaultFieldInformationPaneTopic.htm");
      DockWindow dockWindow = mainWindow.GetPageIUI.GetDockWindow(DockWndType.Naviagtion);
      if (!dockWindow.IsAutoHide && !dockWindow.IsFloating)
        DockSite.SetDockSize((UIElement) ((FrameworkElement) dockWindow.Parent).Parent, 300.0);
      if (this.FrameHome.Content == null || !(this.FrameHome.Content is PageWelcomeTreeView))
        this.FrameHome.Navigate(new Uri("HomeBase/PageWelcomeTreeView.xaml", UriKind.RelativeOrAbsolute));
      if (this.bNavigateToContentPage)
        mainWindow.FrameCenterTop.Navigate(new Uri("HomeBase/PageWelcome.xaml", UriKind.RelativeOrAbsolute));
      this.bNavigateToContentPage = true;
    }
    else if (sender == this.ButtonCpgNav)
    {
      AppInfoManager.AppMode = ApplicationMode.CodeplugConfigurationMode;
      bool flag = mainWindow.CpgOpenFlag;
      if (!flag)
        flag = mainWindow.OpenCodeplug((string) null);
      if (flag)
      {
        mainWindow.ribbonTabCodeplug.IsSelected = true;
        DockWindow dockWindow = mainWindow.GetPageIUI.GetDockWindow(DockWndType.Naviagtion);
        if (!dockWindow.IsAutoHide && !dockWindow.IsFloating)
          DockSite.SetDockSize((UIElement) ((FrameworkElement) dockWindow.Parent).Parent, 220.0);
        if (this.FrameCodeplug.Content == null || !(this.FrameCodeplug.Content is PageTreeView))
          this.FrameCodeplug.Navigate(new Uri("PageTreeView.xaml", UriKind.RelativeOrAbsolute));
        if (this.bNavigateToContentPage)
          mainWindow.FrameCenterTop.Navigate(new Uri(FeatureManager.GetFeature(2049).UIPagePath, UriKind.RelativeOrAbsolute));
        this.bNavigateToContentPage = true;
      }
      else
      {
        this.ButtonHome.IsSelected = true;
        this.ButtonCpgNav.IsSelected = false;
        e.Handled = true;
      }
    }
    else if (sender == this.ButtonCustomViewMode)
    {
      AppInfoManager.AppMode = ApplicationMode.CustomViewConfigurationMode;
      mainWindow.ribbonTabCustomViewCfgMode.IsSelected = true;
      AppInfoManager.ClearNavigationHistory = true;
      mainWindow.FrameCenterTop.Navigate(new Uri("CustomView/PageCustomViewWelcome.xaml", UriKind.RelativeOrAbsolute));
    }
    else
    {
      int num = (int) MessageBox.Show(AppResources.PageNavPaneButtons_OnButtonClick);
    }
    mainWindow.SelectedNavigationMode = (PaneItem) sender;
  }

  internal object GetSelectedItemContent()
  {
    return ((ContentControl) this.AppNavPane.SelectedContent).Content;
  }

  internal void SetSelectedItem(PaneItem item, bool NavigateToContentPage)
  {
    if (item.IsSelected)
      return;
    this.bNavigateToContentPage = NavigateToContentPage;
    item.IsSelected = true;
  }

  public PageNavPaneButtons()
  {
    this.InitializeComponent();
    AcpUI.Common.Utility.SetDirection((FrameworkElement) this);
    this.ButtonHome.IsSelected = true;
    this.DataContext = (object) (WindowMain) Application.Current.MainWindow;
  }

  private void ClearFrame_Navigated(object sender, NavigationEventArgs e)
  {
    System.Windows.Controls.Frame frame = (System.Windows.Controls.Frame) sender;
    while (frame.NavigationService.CanGoBack && frame.Content == null)
      frame.NavigationService.RemoveBackEntry();
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
  public void InitializeComponent()
  {
    if (this._contentLoaded)
      return;
    this._contentLoaded = true;
    Application.LoadComponent((object) this, new Uri("/APXFamilyCPS;component/pagenavpanebuttons.xaml", UriKind.Relative));
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
  [EditorBrowsable(EditorBrowsableState.Never)]
  [SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
  [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
  [SuppressMessage("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
  void IComponentConnector.Connect(int connectionId, object target)
  {
    switch (connectionId)
    {
      case 1:
        this.AppNavPane = (NavigationPane) target;
        break;
      case 2:
        this.ButtonHome = (PaneItem) target;
        this.ButtonHome.AddHandler(Selector.SelectedEvent, (Delegate) new RoutedEventHandler(this.OnButtonClick));
        break;
      case 3:
        this.FrameHome = (System.Windows.Controls.Frame) target;
        break;
      case 4:
        this.ButtonCpgNav = (PaneItem) target;
        this.ButtonCpgNav.AddHandler(Selector.SelectedEvent, (Delegate) new RoutedEventHandler(this.OnButtonClick));
        break;
      case 5:
        this.FrameCodeplug = (System.Windows.Controls.Frame) target;
        this.FrameCodeplug.Navigated += new NavigatedEventHandler(this.ClearFrame_Navigated);
        break;
      case 6:
        this.ButtonCustomViewMode = (PaneItem) target;
        this.ButtonCustomViewMode.AddHandler(Selector.SelectedEvent, (Delegate) new RoutedEventHandler(this.OnButtonClick));
        break;
      case 7:
        this.FrameCustView = (System.Windows.Controls.Frame) target;
        this.FrameCustView.Navigated += new NavigatedEventHandler(this.ClearFrame_Navigated);
        break;
      default:
        this._contentLoaded = true;
        break;
    }
  }
}
