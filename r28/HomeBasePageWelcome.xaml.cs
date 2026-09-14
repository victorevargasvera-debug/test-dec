// Decompiled with JetBrains decompiler
// Type: MackinawCPS.HomeBase.PageWelcome
// Assembly: APXFamilyCPS, Version=15.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 7983BD42-76AB-479D-8966-B7B635E0E28A
// Assembly location: C:\Program Files (x86)\Motorola\ApxFamilyDepot R28\APXdepotR28.exe

using AcpCommonLib;
using MackinawCPS.Properties;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

#nullable disable
namespace MackinawCPS.HomeBase;

public partial class PageWelcome : Page, IComponentConnector
{
  private string CustomBackgroudPath = string.Empty;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal PageWelcome acpPageFeature;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal Viewbox LayoutRoot;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal Rectangle image;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal Rectangle rectangle1;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal Path path;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal Path path1;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal Path path2;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal Path path3;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal Path path4;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal Path path5;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal Path path6;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal Path path6_Copy;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal Path path7;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal Path path8;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal Path path9;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal Path path10;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal Path path11;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal Path path12;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal Ellipse ellipse;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal Path path13;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal Path path14;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal Viewbox Main_Monitor_Art;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal Viewbox Monitor1;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal Canvas Monitor1Display;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal Border CustomerLogo;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal StackPanel Expanders;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal Expander WhatsNewExp;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal Expander GettingStartedExp;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal Expander RMExp;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal Expander CPSNavExp;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal Expander ASKExp;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal Expander RadioFeatExp;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal Expander MoreExp;
  private bool _contentLoaded;

  public PageWelcome()
  {
    this.InitializeComponent();
    AcpUI.Common.Utility.SetDirection((FrameworkElement) this);
  }

  private void OnLoaded(object sender, RoutedEventArgs e)
  {
    this.WhatsNewExp.IsExpanded = false;
    this.GettingStartedExp.IsExpanded = false;
    this.RMExp.IsExpanded = false;
    this.ASKExp.IsExpanded = false;
    this.CPSNavExp.IsExpanded = false;
    this.RadioFeatExp.IsExpanded = false;
    this.MoreExp.IsExpanded = false;
    this.CustomBackgroudPath = Settings.Default.CustomBackgroudPath;
    this.SetBackground(this.CustomBackgroudPath);
  }

  internal void LoadDefaultLogo() => this.SetBackground(WindowMain.DefaultLogoPath);

  internal void SetBackground(string path)
  {
    this.CustomBackgroudPath = !string.IsNullOrEmpty(path) ? path : WindowMain.DefaultLogoPath;
    try
    {
      Image image = new Image();
      BitmapImage bitmapImage = new BitmapImage();
      bitmapImage.BeginInit();
      bitmapImage.UriSource = new Uri(this.CustomBackgroudPath, UriKind.RelativeOrAbsolute);
      bitmapImage.EndInit();
      image.Source = (ImageSource) bitmapImage;
      this.CustomerLogo.Child = (UIElement) image;
      Settings.Default.CustomBackgroudPath = this.CustomBackgroudPath;
      Settings.Default.Save();
    }
    catch (Exception ex)
    {
      this.CustomBackgroudPath = WindowMain.DefaultLogoPath;
      AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, ex.Message);
    }
  }

  private void OnExpanderWhatsNewCollapsed(object sender, RoutedEventArgs e)
  {
    try
    {
      AcpUI.Help.Utility.CloseHelpWindowIfOpen();
      AcpUI.Help.Utility.DisplayCPSHelp("zzTutorials\\zWhatsNewTopics\\WhatsNewNow.htm");
    }
    catch (Exception ex)
    {
    }
  }

  private void OnExpanderGettingStartedCollapsed(object sender, RoutedEventArgs e)
  {
    try
    {
      AcpUI.Help.Utility.CloseHelpWindowIfOpen();
      AcpUI.Help.Utility.DisplayMovie("zzTutorials\\Movies\\GS1GettingStarted1ProgrammingARadioML.html");
    }
    catch (Exception ex)
    {
    }
  }

  private void OnExpanderTutorialsCollapsed(object sender, RoutedEventArgs e)
  {
    try
    {
      AcpUI.Help.Utility.CloseHelpWindowIfOpen();
      AcpUI.Help.Utility.DisplayCPSHelp("zzTutorials\\yMenus\\TutorialsMenu.htm");
    }
    catch (Exception ex)
    {
    }
  }

  private void OnExpanderRMCollapsed(object sender, RoutedEventArgs e)
  {
    try
    {
      AcpUI.Help.Utility.CloseHelpWindowIfOpen();
      AcpUI.Help.Utility.DisplayMovie("zzTutorials\\Movies\\RM01TheIntroductionML.html");
    }
    catch (Exception ex)
    {
    }
  }

  private void OnExpanderASKCollapsed(object sender, RoutedEventArgs e)
  {
    try
    {
      AcpUI.Help.Utility.CloseHelpWindowIfOpen();
      AcpUI.Help.Utility.DisplayMovie("zzTutorials\\Movies\\AdvancedSystemKeys1ML.html");
    }
    catch (Exception ex)
    {
    }
  }

  private void OnExpanderCPSNavCollapsed(object sender, RoutedEventArgs e)
  {
    try
    {
      AcpUI.Help.Utility.CloseHelpWindowIfOpen();
      AcpUI.Help.Utility.DisplayMovie("zzTutorials\\Movies\\GS2CPSNavigation1IntroML.html");
    }
    catch (Exception ex)
    {
    }
  }

  private void OnExpanderRadioFeatCollapsed(object sender, RoutedEventArgs e)
  {
    try
    {
      AcpUI.Help.Utility.CloseHelpWindowIfOpen();
      AcpUI.Help.Utility.DisplayCPSHelp("zzTutorials\\yMenus\\RadioFeatures.htm");
    }
    catch (Exception ex)
    {
    }
  }

  private void OnExpanderExpanded(object sender, RoutedEventArgs e)
  {
    this.WhatsNewExp.IsExpanded = false;
    this.GettingStartedExp.IsExpanded = false;
    this.RMExp.IsExpanded = false;
    this.ASKExp.IsExpanded = false;
    this.CPSNavExp.IsExpanded = false;
    this.RadioFeatExp.IsExpanded = false;
    this.MoreExp.IsExpanded = false;
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
  public void InitializeComponent()
  {
    if (this._contentLoaded)
      return;
    this._contentLoaded = true;
    Application.LoadComponent((object) this, new Uri("/APXFamilyCPS;component/homebase/pagewelcome.xaml", UriKind.Relative));
  }

  [EditorBrowsable(EditorBrowsableState.Never)]
  [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
  [DebuggerNonUserCode]
  [SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
  [SuppressMessage("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
  [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
  void IComponentConnector.Connect(int connectionId, object target)
  {
    switch (connectionId)
    {
      case 1:
        this.acpPageFeature = (PageWelcome) target;
        this.acpPageFeature.Loaded += new RoutedEventHandler(this.OnLoaded);
        break;
      case 2:
        this.LayoutRoot = (Viewbox) target;
        break;
      case 3:
        this.image = (Rectangle) target;
        break;
      case 4:
        this.rectangle1 = (Rectangle) target;
        break;
      case 5:
        this.path = (Path) target;
        break;
      case 6:
        this.path1 = (Path) target;
        break;
      case 7:
        this.path2 = (Path) target;
        break;
      case 8:
        this.path3 = (Path) target;
        break;
      case 9:
        this.path4 = (Path) target;
        break;
      case 10:
        this.path5 = (Path) target;
        break;
      case 11:
        this.path6 = (Path) target;
        break;
      case 12:
        this.path6_Copy = (Path) target;
        break;
      case 13:
        this.path7 = (Path) target;
        break;
      case 14:
        this.path8 = (Path) target;
        break;
      case 15:
        this.path9 = (Path) target;
        break;
      case 16 /*0x10*/:
        this.path10 = (Path) target;
        break;
      case 17:
        this.path11 = (Path) target;
        break;
      case 18:
        this.path12 = (Path) target;
        break;
      case 19:
        this.ellipse = (Ellipse) target;
        break;
      case 20:
        this.path13 = (Path) target;
        break;
      case 21:
        this.path14 = (Path) target;
        break;
      case 22:
        this.Main_Monitor_Art = (Viewbox) target;
        break;
      case 23:
        this.Monitor1 = (Viewbox) target;
        break;
      case 24:
        this.Monitor1Display = (Canvas) target;
        break;
      case 25:
        this.CustomerLogo = (Border) target;
        break;
      case 26:
        this.Expanders = (StackPanel) target;
        break;
      case 27:
        this.WhatsNewExp = (Expander) target;
        this.WhatsNewExp.Collapsed += new RoutedEventHandler(this.OnExpanderWhatsNewCollapsed);
        this.WhatsNewExp.Expanded += new RoutedEventHandler(this.OnExpanderExpanded);
        break;
      case 28:
        this.GettingStartedExp = (Expander) target;
        this.GettingStartedExp.Collapsed += new RoutedEventHandler(this.OnExpanderGettingStartedCollapsed);
        this.GettingStartedExp.Expanded += new RoutedEventHandler(this.OnExpanderExpanded);
        break;
      case 29:
        this.RMExp = (Expander) target;
        this.RMExp.Collapsed += new RoutedEventHandler(this.OnExpanderRMCollapsed);
        this.RMExp.Expanded += new RoutedEventHandler(this.OnExpanderExpanded);
        break;
      case 30:
        this.CPSNavExp = (Expander) target;
        this.CPSNavExp.Collapsed += new RoutedEventHandler(this.OnExpanderCPSNavCollapsed);
        this.CPSNavExp.Expanded += new RoutedEventHandler(this.OnExpanderExpanded);
        break;
      case 31 /*0x1F*/:
        this.ASKExp = (Expander) target;
        this.ASKExp.Collapsed += new RoutedEventHandler(this.OnExpanderASKCollapsed);
        this.ASKExp.Expanded += new RoutedEventHandler(this.OnExpanderExpanded);
        break;
      case 32 /*0x20*/:
        this.RadioFeatExp = (Expander) target;
        this.RadioFeatExp.Collapsed += new RoutedEventHandler(this.OnExpanderRadioFeatCollapsed);
        this.RadioFeatExp.Expanded += new RoutedEventHandler(this.OnExpanderExpanded);
        break;
      case 33:
        this.MoreExp = (Expander) target;
        this.MoreExp.Collapsed += new RoutedEventHandler(this.OnExpanderTutorialsCollapsed);
        this.MoreExp.Expanded += new RoutedEventHandler(this.OnExpanderExpanded);
        break;
      default:
        this._contentLoaded = true;
        break;
    }
  }
}
