// Decompiled with JetBrains decompiler
// Type: MackinawCPS.HomeBase.PageWelcome
// Assembly: APXFamilyCPS, Version=36.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 9359335E-041C-4B12-9409-F4E6E7D93299
// Assembly location: C:\Program Files (x86)\Motorola\ApxFamilyCPS R36.00\APXFamilyCPS1.exe

using AcpCommonLib;
using MackinawCPS.Properties;
using Motorola.Common.Communication.CommonUtil;
using Motorola.CommonCPS.Server.EntityModel;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
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
  private string VertexBackgroundPath = string.Empty;
  internal PageWelcome acpPageFeature;
  internal Viewbox LayoutRoot;
  internal Rectangle backgroundImage;
  internal Rectangle image;
  internal Rectangle rectangle1;
  internal Path path;
  internal Path path1;
  internal Path path2;
  internal Path path3;
  internal Path path4;
  internal Path path5;
  internal Path path6;
  internal Path path6_Copy;
  internal Path path7;
  internal Path path8;
  internal Path path9;
  internal Path path10;
  internal Path path11;
  internal Path path12;
  internal Ellipse ellipse;
  internal Path path13;
  internal Path path14;
  internal Viewbox Main_Monitor_Art;
  internal Viewbox Monitor1;
  internal Canvas Monitor1Display;
  internal Border CustomerLogo;
  internal StackPanel Expanders;
  internal Expander GettingStartedExp;
  internal Expander RMExp;
  internal Expander CPSNavExp;
  internal Expander ASKExp;
  internal Expander RadioFeatExp;
  internal Expander MoreExp;
  internal GroupBox Tutorials;
  private bool _contentLoaded;

  public PageWelcome()
  {
    this.InitializeComponent();
    AcpUI.Common.Utility.SetDirection((FrameworkElement) this);
  }

  private void OnLoaded(object sender, RoutedEventArgs e)
  {
    this.GettingStartedExp.IsExpanded = false;
    this.RMExp.IsExpanded = false;
    this.ASKExp.IsExpanded = false;
    this.CPSNavExp.IsExpanded = false;
    this.RadioFeatExp.IsExpanded = false;
    this.MoreExp.IsExpanded = false;
    this.CustomBackgroudPath = Settings.Default.CustomBackgroudPath;
    this.VertexBackgroundPath = Settings.Default.VertexBackgroundPath;
    if (VersionInfoHelper.IsDFlagExisted(DFlagType.DASTRO))
    {
      Image image = new Image();
      BitmapImage bitmapImage = new BitmapImage();
      bitmapImage.BeginInit();
      bitmapImage.UriSource = new Uri(this.VertexBackgroundPath, UriKind.RelativeOrAbsolute);
      bitmapImage.EndInit();
      image.Source = (ImageSource) bitmapImage;
      this.CustomerLogo.Child = (UIElement) image;
      this.image.SetResourceReference(Shape.FillProperty, (object) "WelcomePageBannerImageBrushVertex");
      this.backgroundImage.SetResourceReference(Shape.FillProperty, (object) "WelcomePageBackgroundImageBrushVertex");
      this.RMExp.Visibility = Visibility.Collapsed;
      this.Tutorials.Visibility = Visibility.Hidden;
      this.GettingStartedExp.Visibility = Visibility.Hidden;
      this.CPSNavExp.Visibility = Visibility.Hidden;
      this.ASKExp.Visibility = Visibility.Hidden;
      this.RadioFeatExp.Visibility = Visibility.Hidden;
      this.MoreExp.Visibility = Visibility.Hidden;
    }
    else
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
      ACPBrowser.Utility.CloseHelpWindowIfOpen();
      ACPBrowser.Utility.DisplayCPSHelpDITA((string) null);
    }
    catch (Exception ex)
    {
    }
  }

  private void OnExpanderGettingStartedCollapsed(object sender, RoutedEventArgs e)
  {
    try
    {
      ACPBrowser.Utility.CloseHelpWindowIfOpen();
      ACPBrowser.Utility.DisplayMovie((string) null);
    }
    catch (Exception ex)
    {
    }
  }

  private void OnExpanderTutorialsCollapsed(object sender, RoutedEventArgs e)
  {
    try
    {
      ACPBrowser.Utility.CloseHelpWindowIfOpen();
      ACPBrowser.Utility.DisplayCPSHelpDITA((string) null);
    }
    catch (Exception ex)
    {
    }
  }

  private void OnExpanderRMCollapsed(object sender, RoutedEventArgs e)
  {
    try
    {
      ACPBrowser.Utility.CloseHelpWindowIfOpen();
      ACPBrowser.Utility.DisplayMovie((string) null);
    }
    catch (Exception ex)
    {
    }
  }

  private void OnExpanderASKCollapsed(object sender, RoutedEventArgs e)
  {
    try
    {
      ACPBrowser.Utility.CloseHelpWindowIfOpen();
      ACPBrowser.Utility.DisplayMovie((string) null);
    }
    catch (Exception ex)
    {
    }
  }

  private void OnExpanderCPSNavCollapsed(object sender, RoutedEventArgs e)
  {
    try
    {
      ACPBrowser.Utility.CloseHelpWindowIfOpen();
      ACPBrowser.Utility.DisplayMovie((string) null);
    }
    catch (Exception ex)
    {
    }
  }

  private void OnExpanderRadioFeatCollapsed(object sender, RoutedEventArgs e)
  {
    try
    {
      ACPBrowser.Utility.CloseHelpWindowIfOpen();
      ACPBrowser.Utility.DisplayCPSHelpDITA("#610ca765");
    }
    catch (Exception ex)
    {
    }
  }

  private void OnExpanderExpanded(object sender, RoutedEventArgs e)
  {
    this.GettingStartedExp.IsExpanded = false;
    this.RMExp.IsExpanded = false;
    this.ASKExp.IsExpanded = false;
    this.CPSNavExp.IsExpanded = false;
    this.RadioFeatExp.IsExpanded = false;
    this.MoreExp.IsExpanded = false;
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "8.0.8.0")]
  public void InitializeComponent()
  {
    if (this._contentLoaded)
      return;
    this._contentLoaded = true;
    Application.LoadComponent((object) this, new Uri("/APXFamilyCPS;component/homebase/pagewelcome.xaml", UriKind.Relative));
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "8.0.8.0")]
  [EditorBrowsable(EditorBrowsableState.Never)]
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
        this.backgroundImage = (Rectangle) target;
        break;
      case 4:
        this.image = (Rectangle) target;
        break;
      case 5:
        this.rectangle1 = (Rectangle) target;
        break;
      case 6:
        this.path = (Path) target;
        break;
      case 7:
        this.path1 = (Path) target;
        break;
      case 8:
        this.path2 = (Path) target;
        break;
      case 9:
        this.path3 = (Path) target;
        break;
      case 10:
        this.path4 = (Path) target;
        break;
      case 11:
        this.path5 = (Path) target;
        break;
      case 12:
        this.path6 = (Path) target;
        break;
      case 13:
        this.path6_Copy = (Path) target;
        break;
      case 14:
        this.path7 = (Path) target;
        break;
      case 15:
        this.path8 = (Path) target;
        break;
      case 16 /*0x10*/:
        this.path9 = (Path) target;
        break;
      case 17:
        this.path10 = (Path) target;
        break;
      case 18:
        this.path11 = (Path) target;
        break;
      case 19:
        this.path12 = (Path) target;
        break;
      case 20:
        this.ellipse = (Ellipse) target;
        break;
      case 21:
        this.path13 = (Path) target;
        break;
      case 22:
        this.path14 = (Path) target;
        break;
      case 23:
        this.Main_Monitor_Art = (Viewbox) target;
        break;
      case 24:
        this.Monitor1 = (Viewbox) target;
        break;
      case 25:
        this.Monitor1Display = (Canvas) target;
        break;
      case 26:
        this.CustomerLogo = (Border) target;
        break;
      case 27:
        this.Expanders = (StackPanel) target;
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
      case 34:
        this.Tutorials = (GroupBox) target;
        break;
      default:
        this._contentLoaded = true;
        break;
    }
  }
}
