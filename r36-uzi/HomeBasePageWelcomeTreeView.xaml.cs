// Decompiled with JetBrains decompiler
// Type: MackinawCPS.HomeBase.PageWelcomeTreeView
// Assembly: APXFamilyCPS, Version=36.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 9359335E-041C-4B12-9409-F4E6E7D93299
// Assembly location: C:\Program Files (x86)\Motorola\ApxFamilyCPS R36.00\APXFamilyCPS1.exe

using AcpCommonLib;
using AcpUI;
using CommonResources;
using Motorola.Common.Communication.CommonUtil;
using Motorola.CommonCPS.Server.EntityModel;
using Motorola.MackinawCPS.CoreFeatures.RadioInformation;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Shapes;

#nullable disable
namespace MackinawCPS.HomeBase;

public partial class PageWelcomeTreeView : Page, IComponentConnector
{
  private WindowMain winMain;
  private DependencyPropertyDescriptor dpd;
  private DependencyPropertyDescriptor dpdclone;
  internal DockPanel DockPanelPageWelcomeTreeView;
  internal Rectangle Rectangle_GetingStarted;
  internal StackPanel NAVs;
  internal Button ButtonRMC;
  internal Button ButtonBrowseForCpg;
  internal Button ButtonReadRadio;
  internal Button ButtonFlashRadio;
  internal Button ButtonCloneRadio;
  internal AcpListBoxMruFiles AppMruListHomeBase;
  private bool _contentLoaded;

  public bool IsCloudNativeMode => Startup.IsCloudNativeMode;

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
    if (VersionInfoHelper.IsDFlagExisted(DFlagType.DASTRO))
    {
      this.ButtonRMC.Visibility = Visibility.Collapsed;
      this.Rectangle_GetingStarted.Fill = (Brush) Brushes.Orange;
      Style resource1 = (Style) this.FindResource((object) "radio button for Vertex");
      Style resource2 = (Style) this.FindResource((object) "Clone_A_Radio_Button_For_Vertex");
      Style resource3 = (Style) this.FindResource((object) "Flash a radio button for Vertex");
      this.ButtonBrowseForCpg.Style = (Style) this.FindResource((object) "Browse for a codeplug for Vertex");
      this.ButtonReadRadio.Style = resource1;
      this.ButtonFlashRadio.Style = resource3;
      this.ButtonCloneRadio.Style = resource2;
    }
    if (!CpsVersionResolver.Instance.IsItCpsWithoutAnRm)
      return;
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
    {
      name.Content = (object) AppResources.POP25_Id;
    }
    else
    {
      if (this.winMain.ReadWriteTransport != 2)
        return;
      name.Content = (object) AppResources.Bluetooth_Id;
    }
  }

  private void CloneTransportPropertyHandler(object sender, EventArgs args)
  {
    if (!(this.ButtonCloneRadio.Template.FindName("USBtitle4", (FrameworkElement) this.ButtonCloneRadio) is Label name))
      return;
    if (this.winMain.CloneTransport == 0)
      name.Content = (object) AppResources.USB_ID;
    else if (this.winMain.CloneTransport == 1)
    {
      name.Content = (object) AppResources.POP25_Id;
    }
    else
    {
      if (this.winMain.CloneTransport != 2)
        return;
      name.Content = (object) AppResources.Bluetooth_Id;
    }
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
    if (string.IsNullOrEmpty(filePath) || !mainWindow.OpenCodeplug(filePath) || !flag)
      return;
    content.FrameCodeplug.NavigationService.Refresh();
    if (!(mainWindow.FrameCenterTop.Content is PageRadioInformation))
      return;
    mainWindow.FrameCenterTop.NavigationService.Refresh();
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "8.0.8.0")]
  public void InitializeComponent()
  {
    if (this._contentLoaded)
      return;
    this._contentLoaded = true;
    Application.LoadComponent((object) this, new Uri("/APXFamilyCPS;component/homebase/pagewelcometreeview.xaml", UriKind.Relative));
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "8.0.8.0")]
  [EditorBrowsable(EditorBrowsableState.Never)]
  void IComponentConnector.Connect(int connectionId, object target)
  {
    switch (connectionId)
    {
      case 1:
        this.DockPanelPageWelcomeTreeView = (DockPanel) target;
        break;
      case 2:
        this.Rectangle_GetingStarted = (Rectangle) target;
        break;
      case 3:
        this.NAVs = (StackPanel) target;
        break;
      case 4:
        this.ButtonRMC = (Button) target;
        this.ButtonRMC.Click += new RoutedEventHandler(this.OnButtonClick);
        break;
      case 5:
        this.ButtonBrowseForCpg = (Button) target;
        this.ButtonBrowseForCpg.Click += new RoutedEventHandler(this.OnButtonClick);
        break;
      case 6:
        this.ButtonReadRadio = (Button) target;
        this.ButtonReadRadio.Click += new RoutedEventHandler(this.OnButtonClick);
        break;
      case 7:
        this.ButtonFlashRadio = (Button) target;
        this.ButtonFlashRadio.Click += new RoutedEventHandler(this.OnButtonClick);
        break;
      case 8:
        this.ButtonCloneRadio = (Button) target;
        this.ButtonCloneRadio.Click += new RoutedEventHandler(this.OnButtonClick);
        break;
      case 9:
        this.AppMruListHomeBase = (AcpListBoxMruFiles) target;
        this.AppMruListHomeBase.FileClick += new RoutedEventHandler(this.OnMruFileOpen);
        break;
      default:
        this._contentLoaded = true;
        break;
    }
  }
}
