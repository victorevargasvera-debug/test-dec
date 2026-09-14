// Decompiled with JetBrains decompiler
// Type: MackinawCPS.HelpAboutCPSWnd
// Assembly: APXFamilyCPS, Version=15.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 7983BD42-76AB-479D-8966-B7B635E0E28A
// Assembly location: C:\Program Files (x86)\Motorola\APX Dpt 25\APXFamilyCPS.exe

using AcpUI.Common;
using CommonResources;
using Microsoft.Win32;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;
using System.Windows.Shapes;

#nullable disable
namespace MackinawCPS;

public partial class HelpAboutCPSWnd : Window, IComponentConnector
{
  private static string productVersion = "";
  private static string productLicensedToCompany = AppResources.Unregistered_ID;
  private static string productLicensedToPerson = AppResources.Unregistered_ID;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal Grid LayoutRoot;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal Image Motorola_Icon_Copy;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal Viewbox APX;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal Label label3;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal Label label2;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal Label Copyright;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal Label licensed_to;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal Label licensed_to_Per;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal Label licensed_to_Company;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal Label Version;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal Rectangle top_line_L;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal Rectangle top_line_R;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal StackPanel _3_line_right;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal StackPanel _3_line_left;
  private bool _contentLoaded;

  internal static string CPS_Version
  {
    set => HelpAboutCPSWnd.productVersion = value;
  }

  public HelpAboutCPSWnd()
  {
    this.InitializeComponent();
    Utility.SetDirection((FrameworkElement) this);
    this.Version.Content = (object) (AppResources.DEPOT_colon + HelpAboutCPSWnd.productVersion);
    try
    {
      if (Environment.Is64BitOperatingSystem)
      {
        HelpAboutCPSWnd.productLicensedToPerson = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey("SOFTWARE").OpenSubKey("Microsoft").OpenSubKey("Windows NT").OpenSubKey("CurrentVersion").GetValue("RegisteredOwner").ToString();
        HelpAboutCPSWnd.productLicensedToCompany = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey("SOFTWARE").OpenSubKey("Microsoft").OpenSubKey("Windows NT").OpenSubKey("CurrentVersion").GetValue("RegisteredOrganization").ToString();
      }
      else
      {
        HelpAboutCPSWnd.productLicensedToPerson = Registry.LocalMachine.OpenSubKey("SOFTWARE").OpenSubKey("Microsoft").OpenSubKey("Windows NT").OpenSubKey("CurrentVersion").GetValue("RegisteredOwner").ToString();
        HelpAboutCPSWnd.productLicensedToCompany = Registry.LocalMachine.OpenSubKey("SOFTWARE").OpenSubKey("Microsoft").OpenSubKey("Windows NT").OpenSubKey("CurrentVersion").GetValue("RegisteredOrganization").ToString();
      }
    }
    catch (Exception ex)
    {
      Console.WriteLine("Get License InfoError" + ex.ToString());
    }
    this.licensed_to_Per.Content = (object) HelpAboutCPSWnd.productLicensedToPerson.Replace("_", "__");
    this.licensed_to_Company.Content = (object) HelpAboutCPSWnd.productLicensedToCompany.Replace("_", "__");
  }

  private void OnOkClick(object sender, RoutedEventArgs e) => this.Close();

  [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
  [DebuggerNonUserCode]
  public void InitializeComponent()
  {
    if (this._contentLoaded)
      return;
    this._contentLoaded = true;
    Application.LoadComponent((object) this, new Uri("/APXFamilyCPS;component/helpaboutcpswnd.xaml", UriKind.Relative));
  }

  [SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
  [DebuggerNonUserCode]
  [SuppressMessage("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
  [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
  [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
  [EditorBrowsable(EditorBrowsableState.Never)]
  void IComponentConnector.Connect(int connectionId, object target)
  {
    switch (connectionId)
    {
      case 1:
        this.LayoutRoot = (Grid) target;
        break;
      case 2:
        this.Motorola_Icon_Copy = (Image) target;
        break;
      case 3:
        this.APX = (Viewbox) target;
        break;
      case 4:
        this.label3 = (Label) target;
        break;
      case 5:
        this.label2 = (Label) target;
        break;
      case 6:
        this.Copyright = (Label) target;
        break;
      case 7:
        this.licensed_to = (Label) target;
        break;
      case 8:
        this.licensed_to_Per = (Label) target;
        break;
      case 9:
        this.licensed_to_Company = (Label) target;
        break;
      case 10:
        this.Version = (Label) target;
        break;
      case 11:
        this.top_line_L = (Rectangle) target;
        break;
      case 12:
        this.top_line_R = (Rectangle) target;
        break;
      case 13:
        ((ButtonBase) target).Click += new RoutedEventHandler(this.OnOkClick);
        break;
      case 14:
        this._3_line_right = (StackPanel) target;
        break;
      case 15:
        this._3_line_left = (StackPanel) target;
        break;
      default:
        this._contentLoaded = true;
        break;
    }
  }
}
