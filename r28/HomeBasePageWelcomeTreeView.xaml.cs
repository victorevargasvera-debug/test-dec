// Decompiled with JetBrains decompiler
// Type: MackinawCPS.HomeBase.PageWelcomeTreeView
// Assembly: APXFamilyCPS, Version=15.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 7983BD42-76AB-479D-8966-B7B635E0E28A
// Assembly location: C:\Program Files (x86)\Motorola\ApxFamilyDepot R28\APXdepotR28.exe

using AcpCommonLib;
using AcpUI;
using CommonResources;
using Motorola.MackinawCPS.CoreFeatures.RadioInformation;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

#nullable disable
namespace MackinawCPS.HomeBase;

public partial class PageWelcomeTreeView : Page, IComponentConnector
{
  private WindowMain winMain;
  private DependencyPropertyDescriptor dpd;
  private DependencyPropertyDescriptor dpdclone;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal StackPanel NAVs;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal Button ButtonRMC;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal Button ButtonBrowseForCpg;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal Button ButtonReadRadio;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal Button ButtonFlashRadio;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal Button ButtonCloneRadio;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal AcpListBoxMruFiles AppMruListHomeBase;
  private bool _contentLoaded;

  public PageWelcomeTreeView()
  {
    this.InitializeComponent();
    AcpUI.Common.Utility.SetDirection((FrameworkElement) this);
    this.winMain = (WindowMain) Application.Current.MainWindow;
    this.dpd = DependencyPropertyDescriptor.FromProperty(WindowMain.ReadWriteTransportProperty, typeof (WindowMain));
    if (this.dpd != null)
      this.dpd.AddValueChanged((object) this.winMain, new EventHandler(this.ReadWriteTransportPropertyHandler));
    this.dpdclone = DependencyPropertyDescriptor.FromProperty(WindowMain.CloneTransportProperty, typeof (WindowMain));
    if (this.dpdclone != null)
      this.dpdclone.AddValueChanged((object) this.winMain, new EventHandler(this.CloneTransportPropertyHandler));
    this.DataContext = (object) this.winMain;
    if (Thread.CurrentThread.CurrentCulture.Name.ToLower().StartsWith("ar"))
      this.AppMruListHomeBase.FlowDirection = FlowDirection.LeftToRight;
    this.ButtonRMC.Visibility = Visibility.Collapsed;
  }

  internal void OnButtonClick(object sender, RoutedEventArgs e)
  {
    WindowMain mainWindow = (WindowMain) Application.Current.MainWindow;
    if (sender == this.ButtonReadRadio)
      mainWindow.OnRibbonBarReadRadio((object) null, (RoutedEventArgs) null);
    else if (sender == this.ButtonBrowseForCpg)
      mainWindow.OnAppMenuOpen(sender, e);
    else if (sender == this.ButtonFlashRadio)
      mainWindow.FlashRadio(true);
    else if (sender == this.ButtonCloneRadio)
      mainWindow.CloneRadio();
    else if (sender == this.ButtonRMC)
      mainWindow.OnAppMenuRadioManagement(sender, e);
    else
      AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, AppResources.PageWelcomeTreeView_OnButtonClick_Not_implemented_yet);
  }

  private void ReadWriteTransportPropertyHandler(object sender, EventArgs args)
  {
    if (!(this.ButtonReadRadio.Template.FindName("USBtitle5", (FrameworkElement) this.ButtonReadRadio) is Label name))
      return;
    if (this.winMain.ReadWriteTransport == 0)
      name.Content = (object) AppResources.USB_ID;
    else if (this.winMain.ReadWriteTransport == 1)
      name.Content = (object) AppResources.POP25_Id;
    else if (this.winMain.ReadWriteTransport == 2)
      name.Content = (object) AppResources.Bluetooth_Id;
  }

  private void CloneTransportPropertyHandler(object sender, EventArgs args)
  {
    if (!(this.ButtonCloneRadio.Template.FindName("USBtitle4", (FrameworkElement) this.ButtonCloneRadio) is Label name))
      return;
    if (this.winMain.CloneTransport == 0)
      name.Content = (object) AppResources.USB_ID;
    else if (this.winMain.CloneTransport == 1)
      name.Content = (object) AppResources.POP25_Id;
    else if (this.winMain.CloneTransport == 2)
      name.Content = (object) AppResources.Bluetooth_Id;
  }

  private void OnMruFileOpen(object sender, RoutedEventArgs e)
  {
    if (!(sender is AcpListBoxMruFiles))
      return;
    WindowMain mainWindow = (WindowMain) Application.Current.MainWindow;
    PageNavPaneButtons content = (PageNavPaneButtons) mainWindow.FrameLeft.Content;
    bool flag = false;
    if (mainWindow.CpgOpenFlag)
    {
      mainWindow.OnAppMenuClose(sender, e);
      if (mainWindow.CpgOpenFlag && !mainWindow.CanOpenCpgFlag)
        return;
      flag = true;
    }
    string filePath = ((SelectedMruFileEventArgs) e).FilePath;
    if (!string.IsNullOrEmpty(filePath) && mainWindow.OpenCodeplug(filePath) && flag)
    {
      content.FrameCodeplug.NavigationService.Refresh();
      if (mainWindow.FrameCenterTop.Content is PageRadioInformation)
        mainWindow.FrameCenterTop.NavigationService.Refresh();
    }
  }

  [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
  [DebuggerNonUserCode]
  public void InitializeComponent()
  {
    if (this._contentLoaded)
      return;
    this._contentLoaded = true;
    Application.LoadComponent((object) this, new Uri("/APXFamilyCPS;component/homebase/pagewelcometreeview.xaml", UriKind.Relative));
  }

  [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
  [SuppressMessage("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
  [EditorBrowsable(EditorBrowsableState.Never)]
  [SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
  void IComponentConnector.Connect(int connectionId, object target)
  {
    switch (connectionId)
    {
      case 1:
        this.NAVs = (StackPanel) target;
        break;
      case 2:
        this.ButtonRMC = (Button) target;
        this.ButtonRMC.Click += new RoutedEventHandler(this.OnButtonClick);
        break;
      case 3:
        this.ButtonBrowseForCpg = (Button) target;
        this.ButtonBrowseForCpg.Click += new RoutedEventHandler(this.OnButtonClick);
        break;
      case 4:
        this.ButtonReadRadio = (Button) target;
        this.ButtonReadRadio.Click += new RoutedEventHandler(this.OnButtonClick);
        break;
      case 5:
        this.ButtonFlashRadio = (Button) target;
        this.ButtonFlashRadio.Click += new RoutedEventHandler(this.OnButtonClick);
        break;
      case 6:
        this.ButtonCloneRadio = (Button) target;
        this.ButtonCloneRadio.Click += new RoutedEventHandler(this.OnButtonClick);
        break;
      case 7:
        this.AppMruListHomeBase = (AcpListBoxMruFiles) target;
        this.AppMruListHomeBase.FileClick += new RoutedEventHandler(this.OnMruFileOpen);
        break;
      default:
        this._contentLoaded = true;
        break;
    }
  }
}
