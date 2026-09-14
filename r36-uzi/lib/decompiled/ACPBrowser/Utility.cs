// Decompiled with JetBrains decompiler
// Type: ACPBrowser.Utility
// Assembly: ACPBrowser, Version=1.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 8594EB5B-A9B7-4EA3-AB9A-BDF8416D55ED
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\ACPBrowser.dll

using CefSharp;
using CefSharp.Wpf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Runtime.CompilerServices;

#nullable disable
namespace ACPBrowser;

public static class Utility
{
  private static HelpWindow helpWnd;
  private static HelpFilePathProvider pathProvider;
  public static string HelpRootDirRelative = ConfigurationManager.AppSettings[nameof (HelpRootDir)];
  public static string HelpRootDir = AppDomain.CurrentDomain.BaseDirectory + Utility.HelpRootDirRelative;
  public static string TutorialRootDirRelative = ConfigurationManager.AppSettings[nameof (TutorialRootDir)];
  public static string TutorialRootDir = AppDomain.CurrentDomain.BaseDirectory + Utility.HelpRootDirRelative + Utility.TutorialRootDirRelative;
  public static string HelpCacheFolder = ConfigurationManager.AppSettings[nameof (HelpCacheFolder)];

  static Utility()
  {
    Utility.pathProvider = new HelpFilePathProvider((IFileService) new FileService());
  }

  internal static HelpWindow GetHelpWindow()
  {
    if (Utility.helpWnd != null && !Utility.helpWnd.IsClosed)
      return Utility.helpWnd;
    Utility.helpWnd = new HelpWindow();
    return Utility.helpWnd;
  }

  public static void CloseHelpWindowIfOpen()
  {
    if (Utility.helpWnd == null || !Utility.helpWnd.IsWindowBeingDisplayed)
      return;
    Utility.helpWnd.CloseWindow();
    Utility.helpWnd = (HelpWindow) null;
  }

  public static void DisplayHelpByFragment(string fragment)
  {
    Utility.DisplayHelpByPath(Utility.pathProvider.BuildPathForCPSHelp(fragment));
  }

  public static void DisplayHelpByFile(string fileName)
  {
    Utility.DisplayHelpByPath(Utility.pathProvider.BuildPathForHelpByFileName(fileName));
  }

  public static void DisplayHelpByPath(string path)
  {
    Utility.helpWnd = Utility.GetHelpWindow();
    if (Utility.helpWnd == null || path == null)
      return;
    Utility.helpWnd.Go(path);
    Utility.helpWnd.Show();
    Utility.helpWnd.Focus();
  }

  public static void DisplayMovie(string fragment)
  {
    Utility.helpWnd = Utility.GetHelpWindow();
    string url = Utility.pathProvider.BuildPathForMovies(fragment);
    if (Utility.helpWnd == null || url == null)
      return;
    Utility.helpWnd.NavigationGrid.Height = 0.0;
    Utility.helpWnd.Height = 684.0;
    Utility.helpWnd.Width = 851.0;
    Utility.helpWnd.Go(url);
    Utility.helpWnd.Show();
    Utility.helpWnd.Focus();
  }

  internal static void DisplayCPSTutorials(string tutorialName)
  {
    Utility.helpWnd = Utility.GetHelpWindow();
    string url = Utility.pathProvider.BuildPathForCPSTutorials(tutorialName);
    if (Utility.helpWnd == null)
      return;
    if (url != null)
    {
      Utility.helpWnd.Go(url);
      Utility.helpWnd.Show();
      Utility.helpWnd.Focus();
    }
    else
      Utility.DisplayHelpByFragment((string) null);
  }

  public static bool DisplayCPSHelpDITA(string fragment)
  {
    Utility.helpWnd = Utility.GetHelpWindow();
    string url = Utility.pathProvider.BuildPathForCPSHelpDITA(fragment);
    if (Utility.helpWnd == null || url == null)
      return false;
    Utility.helpWnd.Go(url);
    Utility.helpWnd.Show();
    Utility.helpWnd.Focus();
    return true;
  }

  internal static string PrepareCachePath()
  {
    return Utility.HelpCacheFolder == null ? (string) null : Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Motorola", Utility.HelpCacheFolder, "CefSharpCache");
  }

  internal static void SubscribeAnyCpuAssemblyResolver()
  {
    try
    {
      CefRuntime.SubscribeAnyCpuAssemblyResolver((string) null);
      Utility.LoadApp();
    }
    catch (Exception ex)
    {
      if (ex.Message.Equals("UseAnyCpuAssemblyResolver has already been called, call "))
        return;
      throw;
    }
  }

  [MethodImpl(MethodImplOptions.NoInlining)]
  private static void LoadApp()
  {
    CefSettings cefSettings = new CefSettings();
    ((CefSettingsBase) cefSettings).CachePath = Utility.PrepareCachePath();
    ((Dictionary<string, string>) ((CefSettingsBase) cefSettings).CefCommandLineArgs).Add("disable-application-cache", "1");
    ((Dictionary<string, string>) ((CefSettingsBase) cefSettings).CefCommandLineArgs).Add("disable-gpu-shader-disk-cache", "1");
    ((CefSettingsBase) cefSettings).LogSeverity = (LogSeverity) 99;
    Cef.Initialize((CefSettingsBase) cefSettings, true, (IBrowserProcessHandler) null);
  }
}
