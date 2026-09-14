// Decompiled with JetBrains decompiler
// Type: MackinawCPS.Startup
// Assembly: APXFamilyCPS, Version=36.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 9359335E-041C-4B12-9409-F4E6E7D93299
// Assembly location: C:\Program Files (x86)\Motorola\ApxFamilyCPS R36.00\APXFamilyCPS1.exe

using CommonResources;
using MackinawCPS.WcfServiceForRmcTemplateTest;
using Motorola.CommonCPS.RadioManagement.CommonBase;
using SpecialFeatures.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Security.Principal;
using System.ServiceModel;
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
  private static ServiceHost _cpsRmcServiceForTests;
  public static bool IsCloudNativeMode = ((IEnumerable<string>) Environment.GetCommandLineArgs()).Select<string, string>((Func<string, string>) (i => i.ToLower())).Any<string>((Func<string, bool>) (i => i == "/rc"));

  [STAThread]
  public static void Main(string[] args)
  {
    bool flag1 = true;
    bool flag2 = false;
    if (args.Length != 0)
    {
      string lower = args[0].Trim().ToLower();
      if (lower.Length > 0 && (lower.CompareTo("-init") == 0 || lower.CompareTo("/cruncher") == 0 || Startup.IsCloudNativeMode))
        flag1 = false;
      if (lower.Length > 0 && lower.CompareTo("/running_rmc_template_tests") == 0)
      {
        Startup._cpsRmcServiceForTests = new ServiceHost(typeof (MackinawOperationContract), Array.Empty<Uri>());
        Startup._cpsRmcServiceForTests.Open();
        flag2 = true;
      }
    }
    try
    {
      WindowsPrincipal windowsPrincipal = new WindowsPrincipal(WindowsIdentity.GetCurrent());
      if (flag1)
        Startup.IsGuest = windowsPrincipal.IsInRole(WindowsBuiltInRole.Guest);
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
      if (!flag1)
        return;
      Startup.ShowStartupErrorDialog(AppResources.Unable_to_start_the_APX_CPS, AppResources.APX_CPS);
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
      app.Properties[(object) "AutoTestMode"] = (object) flag2;
      app.Properties[(object) "splashScreen"] = (object) null;
      if (flag1)
      {
        try
        {
          Startup.threadWait = new AutoResetEvent(false);
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          Thread thread = new Thread(Startup.\u003C\u003EO.\u003C0\u003E__ShowSplashScreen ?? (Startup.\u003C\u003EO.\u003C0\u003E__ShowSplashScreen = new ThreadStart(Startup.ShowSplashScreen)));
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
    string str = "";
    try
    {
      str = "R36.00.01";
      object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof (AssemblyDescriptionAttribute), false);
      if (customAttributes != null)
      {
        if (customAttributes.Length != 0)
        {
          if (customAttributes[0] is AssemblyDescriptionAttribute descriptionAttribute)
          {
            if (descriptionAttribute.Description != null)
            {
              if (descriptionAttribute.Description.Length > 0)
                str = descriptionAttribute.Description;
            }
          }
        }
      }
    }
    catch (Exception ex)
    {
    }
    TimeSpan min = new TimeSpan(0, 0, 5);
    TimeSpan max = new TimeSpan(0, 0, 45);
    string productVersionText = str;
    string Year = DateTime.Now.Year.ToString();
    MackinawCPS.InitializationScreen.SplashScreen splashScreen;
    Startup.splash = splashScreen = new MackinawCPS.InitializationScreen.SplashScreen(min, max, 5, productVersionText, Year);
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
