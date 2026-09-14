// Decompiled with JetBrains decompiler
// Type: MackinawCPS.PageCustomViewWelcome
// Assembly: APXFamilyCPS, Version=15.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 7983BD42-76AB-479D-8966-B7B635E0E28A
// Assembly location: C:\Program Files (x86)\Motorola\APX Dpt 25\APXFamilyCPS.exe

using AcpCommonLib;
using MackinawCPS.Properties;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
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
  internal System.Windows.Controls.Frame Monitor1ClientFrame;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal Border CustomerLogo;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal StackPanel Expanders;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal Expander HowToExp;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal Hyperlink HowTo_CreateCustomView;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal Hyperlink HowTo_ModifyCustomView;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
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
  [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
  public void InitializeComponent()
  {
    if (this._contentLoaded)
      return;
    this._contentLoaded = true;
    Application.LoadComponent((object) this, new Uri("/APXFamilyCPS;component/customview/pagecustomviewwelcome.xaml", UriKind.Relative));
  }

  [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
  [DebuggerNonUserCode]
  [SuppressMessage("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
  [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
  [EditorBrowsable(EditorBrowsableState.Never)]
  [SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
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
        this.Monitor1ClientFrame = (System.Windows.Controls.Frame) target;
        break;
      case 25:
        this.CustomerLogo = (Border) target;
        break;
      case 26:
        this.Expanders = (StackPanel) target;
        break;
      case 27:
        this.HowToExp = (Expander) target;
        this.HowToExp.Collapsed += new RoutedEventHandler(this.OnExpanderCollapsed);
        break;
      case 28:
        this.HowTo_CreateCustomView = (Hyperlink) target;
        this.HowTo_CreateCustomView.Click += new RoutedEventHandler(this.OnHowToItemClick);
        break;
      case 29:
        this.HowTo_ModifyCustomView = (Hyperlink) target;
        this.HowTo_ModifyCustomView.Click += new RoutedEventHandler(this.OnHowToItemClick);
        break;
      case 30:
        this.HowTo_ExitCustomView = (Hyperlink) target;
        this.HowTo_ExitCustomView.Click += new RoutedEventHandler(this.OnHowToItemClick);
        break;
      default:
        this._contentLoaded = true;
        break;
    }
  }
}
