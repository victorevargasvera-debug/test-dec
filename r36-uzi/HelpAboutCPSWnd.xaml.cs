// Decompiled with JetBrains decompiler
// Type: MackinawCPS.HelpAboutCPSWnd
// Assembly: APXFamilyCPS, Version=36.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 9359335E-041C-4B12-9409-F4E6E7D93299
// Assembly location: C:\Program Files (x86)\Motorola\ApxFamilyCPS R36.00\APXFamilyCPS1.exe

using AcpUI.Common;
using Common;
using CommonResources;
using Microsoft.Win32;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
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
  internal Grid LayoutRoot;
  internal Image Motorola_Icon_Copy;
  internal Image Motorola_Icon_Vertex;
  internal Viewbox APX;
  internal Label label3;
  internal Label label2;
  internal Label Copyright;
  internal StackPanel ModelSupported_APX;
  internal TextBlock VXP949;
  internal StackPanel ModelSupported_Vertex;
  internal Label copyrightlbl;
  internal Label licensed_to;
  internal Label licensed_to_Per;
  internal Label licensed_to_Company;
  internal Label Version;
  internal Rectangle top_line_L;
  internal Rectangle top_line_R;
  internal StackPanel _3_line_right;
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
    this.Version.Content = (object) (AppResources.Version_ID + HelpAboutCPSWnd.productVersion);
    try
    {
      using (RegistryKey registryKey1 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey("SOFTWARE")?.OpenSubKey("Microsoft")?.OpenSubKey("Windows NT")?.OpenSubKey("CurrentVersion"))
      {
        if (registryKey1 != null)
        {
          HelpAboutCPSWnd.productLicensedToPerson = registryKey1.GetValue("RegisteredOwner").ToString();
          HelpAboutCPSWnd.productLicensedToCompany = registryKey1.GetValue("RegisteredOrganization").ToString();
        }
        else
        {
          using (RegistryKey registryKey2 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey("SOFTWARE")?.OpenSubKey("Microsoft")?.OpenSubKey("Windows NT")?.OpenSubKey("CurrentVersion"))
          {
            if (registryKey2 != null)
            {
              HelpAboutCPSWnd.productLicensedToPerson = registryKey2.GetValue("RegisteredOwner").ToString();
              HelpAboutCPSWnd.productLicensedToCompany = registryKey2.GetValue("RegisteredOrganization").ToString();
            }
          }
        }
      }
    }
    catch (Exception ex)
    {
      Trace.WriteLine("Getting Owner or Company Name threw an exception, error: " + ex.Message);
    }
    this.licensed_to_Per.Content = (object) HelpAboutCPSWnd.productLicensedToPerson.Replace("_", "__");
    this.licensed_to_Company.Content = (object) HelpAboutCPSWnd.productLicensedToCompany.Replace("_", "__");
    if (Product.IsVertex())
    {
      this.ModelSupported_Vertex.Visibility = Visibility.Visible;
      this.ModelSupported_APX.Visibility = Visibility.Collapsed;
      this.label2.Content = (object) AppResources.VERTEX_STANDARD_CPS;
      this.label2.FontSize = 40.0;
      this.label3.Content = (object) AppResources.VERTEX_STANDARD_CPS;
      this.label3.FontSize = 40.0;
      this.Motorola_Icon_Copy.Visibility = Visibility.Hidden;
      this.Motorola_Icon_Vertex.Visibility = Visibility.Visible;
      this.copyrightlbl.Content = (object) AppResources.Copyright_2017_Vertex_Standard_LMR_Incoporated;
    }
    else
    {
      if (!Product.IsAll())
        return;
      this.VXP949.Visibility = Visibility.Visible;
    }
  }

  private void OnOkClick(object sender, RoutedEventArgs e) => this.Close();

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "8.0.8.0")]
  public void InitializeComponent()
  {
    if (this._contentLoaded)
      return;
    this._contentLoaded = true;
    Application.LoadComponent((object) this, new Uri("/APXFamilyCPS;component/helpaboutcpswnd.xaml", UriKind.Relative));
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "8.0.8.0")]
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
        this.Motorola_Icon_Vertex = (Image) target;
        break;
      case 4:
        this.APX = (Viewbox) target;
        break;
      case 5:
        this.label3 = (Label) target;
        break;
      case 6:
        this.label2 = (Label) target;
        break;
      case 7:
        this.Copyright = (Label) target;
        break;
      case 8:
        this.ModelSupported_APX = (StackPanel) target;
        break;
      case 9:
        this.VXP949 = (TextBlock) target;
        break;
      case 10:
        this.ModelSupported_Vertex = (StackPanel) target;
        break;
      case 11:
        this.copyrightlbl = (Label) target;
        break;
      case 12:
        this.licensed_to = (Label) target;
        break;
      case 13:
        this.licensed_to_Per = (Label) target;
        break;
      case 14:
        this.licensed_to_Company = (Label) target;
        break;
      case 15:
        this.Version = (Label) target;
        break;
      case 16 /*0x10*/:
        this.top_line_L = (Rectangle) target;
        break;
      case 17:
        this.top_line_R = (Rectangle) target;
        break;
      case 18:
        ((ButtonBase) target).Click += new RoutedEventHandler(this.OnOkClick);
        break;
      case 19:
        this._3_line_right = (StackPanel) target;
        break;
      case 20:
        this._3_line_left = (StackPanel) target;
        break;
      default:
        this._contentLoaded = true;
        break;
    }
  }
}
