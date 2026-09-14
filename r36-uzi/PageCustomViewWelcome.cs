// Decompiled with JetBrains decompiler
// Type: MackinawCPS.PageCustomViewWelcome
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
using System.Windows.Documents;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

#nullable disable
namespace MackinawCPS;

public class PageCustomViewWelcome : Page, IComponentConnector
{
  private string CustomBackgroudPath = string.Empty;
  private string VertexBackgroundPath = string.Empty;
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
  internal System.Windows.Controls.Frame Monitor1ClientFrame;
  internal Border CustomerLogo;
  internal StackPanel Expanders;
  internal Expander HowToExp;
  internal Hyperlink HowTo_CreateCustomView;
  internal Hyperlink HowTo_ModifyCustomView;
  internal Hyperlink HowTo_ExitCustomView;
  private bool _contentLoaded;

  public PageCustomViewWelcome()
  {
    this.InitializeComponent();
    AcpUI.Common.Utility.SetDirection((FrameworkElement) this);
  }

  private void OnLoaded(object sender, RoutedEventArgs e)
  {
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

  private void OnExpanderCollapsed(object sender, RoutedEventArgs e)
  {
    if (this.HowToExp.IsExpanded || this.Monitor1ClientFrame == null)
      return;
    this.Monitor1ClientFrame.Visibility = Visibility.Collapsed;
    this.CustomerLogo.Visibility = Visibility.Visible;
  }

  private void OnHowToItemClick(object sender, RoutedEventArgs e)
  {
    Hyperlink hyperlink = (Hyperlink) sender;
    string uriString = (string) null;
    if (hyperlink.Name == "HowTo_CreateCustomView")
      uriString = "CustomView\\NewCustomView.xaml";
    else if (hyperlink.Name == "HowTo_ModifyCustomView")
      uriString = "CustomView\\ModifyCustomView.xaml";
    else if (hyperlink.Name == "HowTo_ExitCustomView")
      uriString = "CustomView\\ExitingCustomView.xaml";
    if (uriString == null)
      return;
    this.Monitor1ClientFrame.Navigate(new Uri(uriString, UriKind.RelativeOrAbsolute));
    this.Monitor1ClientFrame.Visibility = Visibility.Visible;
    this.CustomerLogo.Visibility = Visibility.Collapsed;
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "8.0.8.0")]
  public void InitializeComponent()
  {
    if (this._contentLoaded)
      return;
    this._contentLoaded = true;
    Application.LoadComponent((object) this, new Uri("/APXFamilyCPS;component/customview/pagecustomviewwelcome.xaml", UriKind.Relative));
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "8.0.8.0")]
  [EditorBrowsable(EditorBrowsableState.Never)]
  void IComponentConnector.Connect(int connectionId, object target)
  {
    switch (connectionId)
    {
      case 1:
        ((FrameworkElement) target).Loaded += new RoutedEventHandler(this.OnLoaded);
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
        this.Monitor1ClientFrame = (System.Windows.Controls.Frame) target;
        break;
      case 26:
        this.CustomerLogo = (Border) target;
        break;
      case 27:
        this.Expanders = (StackPanel) target;
        break;
      case 28:
        this.HowToExp = (Expander) target;
        this.HowToExp.Collapsed += new RoutedEventHandler(this.OnExpanderCollapsed);
        break;
      case 29:
        this.HowTo_CreateCustomView = (Hyperlink) target;
        this.HowTo_CreateCustomView.Click += new RoutedEventHandler(this.OnHowToItemClick);
        break;
      case 30:
        this.HowTo_ModifyCustomView = (Hyperlink) target;
        this.HowTo_ModifyCustomView.Click += new RoutedEventHandler(this.OnHowToItemClick);
        break;
      case 31 /*0x1F*/:
        this.HowTo_ExitCustomView = (Hyperlink) target;
        this.HowTo_ExitCustomView.Click += new RoutedEventHandler(this.OnHowToItemClick);
        break;
      default:
        this._contentLoaded = true;
        break;
    }
  }
}
