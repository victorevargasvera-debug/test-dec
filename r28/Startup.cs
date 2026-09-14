// Decompiled with JetBrains decompiler
// Type: MackinawCPS.Startup
// Assembly: APXFamilyCPS, Version=15.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 7983BD42-76AB-479D-8966-B7B635E0E28A
// Assembly location: C:\Program Files (x86)\Motorola\ApxFamilyDepot R28\APXdepotR28.exe

using AcpKeyValidatorLib;
using CommonResources;
using Motorola.CommonCPS.RadioManagement.CommonBase;
using SpecialFeatures.Utilities;
using System;
using System.Configuration;
using System.Reflection;
using System.Security.Cryptography;
using System.Security.Principal;
using System.ServiceModel.Configuration;
using System.Threading;
using System.Windows;

#nullable disable
namespace MackinawCPS;

internal class Startup
{
  private static MackinawCPS.InitializationScreen.SplashScreen splash;
  private static AutoResetEvent threadWait;
  internal static bool IsGuest;

  [STAThread]
  public static void Main(string[] args)
  {
    bool flag = true;
    if (args.Length > 0)
    {
      string lower = args[0].Trim().ToLower();
      if (lower.Length > 0 && (lower.CompareTo("-init") == 0 || lower.CompareTo("/cruncher") == 0))
        flag = false;
    }
    try
    {
      WindowsPrincipal windowsPrincipal = new WindowsPrincipal(WindowsIdentity.GetCurrent());
      if (flag)
        Startup.IsGuest = windowsPrincipal.IsInRole(WindowsBuiltInRole.Guest);
      if (!new AcpKeyValidator().IsDepotKeyAttached())
      {
        if (!flag)
          return;
        Startup.ShowStartupErrorDialog(AppResources.You_do_not_have_again, AppResources.APX_Depot_Access_Denied);
        return;
      }
    }
    catch (Exception ex)
    {
    }
    SHA256 shA256 = (SHA256) null;
    try
    {
      shA256 = (SHA256) new SHA256CryptoServiceProvider();
    }
    catch (Exception ex)
    {
    }
    if (shA256 == null)
    {
      if (!flag)
        return;
      Startup.ShowStartupErrorDialog(AppResources.Unable_to_start_the_APX_DEPOT, AppResources.APX_DEPOT);
    }
    else
    {
      shA256?.Dispose();
      try
      {
        if (!Startup.ValidateDeviceCommunicationServiceHost())
        {
          int num = (int) MessageBox.Show(AppResources.Unable_to_start_the_APX_CPS, AppResources.APX_CPS);
          return;
        }
      }
      catch (Exception ex)
      {
      }
      try
      {
        SpecialFeatures.FCCExceptionHandler.FCCExceptionHandler.Instance.InitExceptionList();
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(AppResources.Unable_to_start_APX_CPS_Critical_file_missing, AppResources.APX_CPS);
        return;
      }
      Global.RMClientVersion = RMVersioningUtilities.GetClientVersion();
      App app = new App();
      app.Properties[(object) "splashScreen"] = (object) null;
      if (flag)
      {
        try
        {
          Startup.threadWait = new AutoResetEvent(false);
          Thread thread = new Thread(new ThreadStart(Startup.ShowSplashScreen));
          thread.SetApartmentState(ApartmentState.STA);
          thread.Start();
          Startup.threadWait.WaitOne();
          app.Properties[(object) "splashScreen"] = (object) Startup.splash;
          Startup.splash = (MackinawCPS.InitializationScreen.SplashScreen) null;
        }
        catch
        {
        }
      }
      app.Run();
    }
  }

  private static void ShowStartupErrorDialog(string error_message, string dialog_title)
  {
    int num = (int) MessageBox.Show(error_message, dialog_title, MessageBoxButton.OK, MessageBoxImage.Hand);
  }

  private static void ShowSplashScreen()
  {
    string productVersionText = "";
    try
    {
      productVersionText = "R15.00.01";
      object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof (AssemblyDescriptionAttribute), false);
      if (customAttributes != null && customAttributes.Length > 0)
      {
        if (customAttributes[0] is AssemblyDescriptionAttribute descriptionAttribute && descriptionAttribute.Description != null && descriptionAttribute.Description.Length > 0)
          productVersionText = descriptionAttribute.Description;
      }
    }
    catch (Exception ex)
    {
    }
    MackinawCPS.InitializationScreen.SplashScreen splashScreen = new MackinawCPS.InitializationScreen.SplashScreen(new TimeSpan(0, 0, 5), new TimeSpan(0, 0, 45), 5, productVersionText);
    Startup.splash = splashScreen;
    Startup.threadWait.Set();
    int num = (int) splashScreen.ShowDialog();
  }

  private static bool ValidateDeviceCommunicationServiceHost()
  {
    try
    {
      if (ConfigurationManager.GetSection("system.serviceModel/client") is ClientSection section)
      {
        ChannelEndpointElementCollection endpoints = section.Endpoints;
        if (endpoints != null)
        {
          foreach (ChannelEndpointElement channelEndpointElement in (ConfigurationElementCollection) endpoints)
          {
            if ((channelEndpointElement.Contract == "DeviceService.IDeviceService" || channelEndpointElement.Contract == "DeviceDiscovery.IDeviceDiscovery") && channelEndpointElement.Address != (Uri) null && string.Compare(channelEndpointElement.Address.Host, "localhost", true) != 0)
              return false;
          }
        }
      }
    }
    catch (ConfigurationErrorsException ex)
    {
      return false;
    }
    return true;
  }
}
