// Decompiled with JetBrains decompiler
// Type: MackinawCPS.App
// Assembly: APXFamilyCPS, Version=15.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 7983BD42-76AB-479D-8966-B7B635E0E28A
// Assembly location: C:\Program Files (x86)\Motorola\ApxFamilyDepot R28\APXdepotR28.exe

using AcpBusinessLayer;
using AcpCommonLib;
using AcpCommonResources;
using AcpUI;
using CommonResources;
using ControlHeadGraphicView.acpcontrol;
using MackinawCPS.CommandLineCPS;
using MackinawCPS.Properties;
using Motorola.Common.CustomException;
using SpecialFeatures;
using SpecialFeatures.Flashport;
using SpecialFeatures.Model_Configuration;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Configuration;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Threading;

#nullable disable
namespace MackinawCPS;

public partial class App : Application
{
  internal string[] FPSCommandLineArgs = new string[100];
  internal string FPSOwnerSysIDArg = (string) null;
  internal static readonly string mainAssemblyCulture = "en";
  private AcpDocument document;
  private FlashDocument flashdoc;
  public static bool ExportXMLCommandMode = false;
  public static string ExportSourceMCPath = string.Empty;
  private bool _contentLoaded;

  public AcpDocument TheDocument => this.document;

  internal FlashDocument FlashDoc => this.flashdoc;

  internal static CPS_Languages AdditionalCPSLanguages { get; private set; }

  static App() => App.AdditionalCPSLanguages = new CPS_Languages();

  public App()
  {
    string[] commandLineArgs = Environment.GetCommandLineArgs();
    try
    {
      if (commandLineArgs.Length > 1 && commandLineArgs[1].ToLower() == "/cruncher")
        this.Properties[(object) "CommandLineCPS"] = (object) true;
      else
        this.Properties[(object) "CommandLineCPS"] = (object) false;
      AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(this.CurrentDomain_UnhandledException);
      this.DispatcherUnhandledException += new DispatcherUnhandledExceptionEventHandler(this.App_DispatcherUnhandledException);
      TaskScheduler.UnobservedTaskException += new EventHandler<UnobservedTaskExceptionEventArgs>(this.TaskScheduler_UnobservedTaskException);
      this.Deactivated += new EventHandler(this.App_Deactivated);
      this.document = (AcpDocument) new MackCPSDocument();
      this.flashdoc = new FlashDocument();
      string name = App.mainAssemblyCulture;
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      Settings settings = new Settings();
      if (!string.IsNullOrEmpty(settings.UserSelectedApplicationLanguage))
        name = settings.UserSelectedApplicationLanguage;
      else if (!string.IsNullOrEmpty(App.AdditionalCPSLanguages.DefaultCPSLanguage))
        name = App.AdditionalCPSLanguages.DefaultCPSLanguage;
      if (name != "en")
      {
        AcpTextBox.DisableMask = true;
        AcpTextBoxSpinner_G.DisableMask = true;
      }
      if (name == "pt")
        AcpTextBox.DisableIPMask = true;
      CultureInfo cultureInfo;
      try
      {
        switch (name)
        {
          case "zh-TW":
            cultureInfo = new CultureInfo(197636);
            break;
          case "es":
            cultureInfo = new CultureInfo("es-MX");
            break;
          case "ar":
            cultureInfo = new CultureInfo("ar-KW");
            cultureInfo.NumberFormat.DigitSubstitution = DigitShapes.None;
            break;
          default:
            cultureInfo = new CultureInfo(name);
            break;
        }
      }
      catch (CultureNotFoundException ex)
      {
        cultureInfo = new CultureInfo(App.mainAssemblyCulture);
      }
      Thread.CurrentThread.CurrentCulture = cultureInfo;
      Thread.CurrentThread.CurrentUICulture = cultureInfo;
      CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
      CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
      AppResources.Culture = cultureInfo;
      AcgResources.Culture = cultureInfo;
      MTFResources.Culture = cultureInfo;
      AcpResources.Culture = cultureInfo;
      Motorola.CommonCPS.ResourceRepository.Resources.Culture = cultureInfo;
      using (ModelTiering modelTiering = new ModelTiering("H97TGD9PW1AN", ModelTiering.ActionTypes.NONE, ModelTiering.TargetTypes.NONE))
        modelTiering.LoadAliasList();
      FrameworkElement.LanguageProperty.OverrideMetadata(typeof (FrameworkElement), (PropertyMetadata) new FrameworkPropertyMetadata((object) XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));
      this.document.SetModificationLogPath(Environment.CurrentDirectory + "\\Log\\modification.log", false);
      this.document.ModificationLogEnabled = false;
      if (MackinawCPS.Startup.IsGuest)
      {
        int num = (int) MessageBox.Show(AppResources.The_Windows_Guest_Account, AppResources.APX_CPS_Access_Denied, MessageBoxButton.OK, MessageBoxImage.Hand);
        Environment.Exit(0);
      }
      AppInfoManager.AppType = ApplicationType.DEPOT;
      this.InitializeComponent();
    }
    catch (ConfigurationErrorsException ex1)
    {
      string path = "";
      if (!string.IsNullOrEmpty(ex1.Filename))
        path = ex1.Filename;
      else if (ex1.InnerException is ConfigurationErrorsException innerException && !string.IsNullOrEmpty(innerException.Filename))
        path = innerException.Filename;
      if (commandLineArgs.Length > 1 && commandLineArgs[1].ToLower() == "/cruncher")
      {
        try
        {
          if (File.Exists(path))
            File.Delete(path);
        }
        catch
        {
        }
        Environment.Exit(-18);
      }
      if (!File.Exists(path))
        return;
      if (MessageBox.Show(AppResources.User_Config_File_Delete, AppResources.Confirm_Deleting, MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
      {
        try
        {
          File.Delete(path);
          Environment.Exit(0);
        }
        catch (IOException ex2)
        {
          Environment.Exit(1212);
        }
      }
      else
        Environment.Exit(0);
    }
  }

  private void TaskScheduler_UnobservedTaskException(
    object sender,
    UnobservedTaskExceptionEventArgs e)
  {
    e.SetObserved();
    if ((bool) Application.Current.Properties[(object) "CommandLineCPS"])
      Environment.Exit(-15);
    if (e.Exception.InnerException is CommonException)
    {
      CommonException innerException = e.Exception.InnerException as CommonException;
      if (innerException.ErrorCode == CommonExceptionHelper.DirectMsgCode && !(bool) Application.Current.Properties[(object) "CommandLineCPS"])
      {
        int num1 = (int) MessageBox.Show(innerException.Message, AppResources.error_Id, MessageBoxButton.OK, MessageBoxImage.Hand);
      }
      else
      {
        if ((bool) Application.Current.Properties[(object) "CommandLineCPS"])
          return;
        int num2 = (int) MessageBox.Show(Motorola.CommonCPS.ResourceRepository.ResourceHelper.GetCommonErrorMessageByID(innerException.ErrorCode.ToString()), AppResources.error_Id, MessageBoxButton.OK, MessageBoxImage.Hand);
      }
    }
    else
    {
      if (!(e.Exception.Source == "SpecialFeatures") || (bool) Application.Current.Properties[(object) "CommandLineCPS"])
        return;
      int num = (int) MessageBox.Show(AppResources.Unkown_Error, AppResources.error_Id, MessageBoxButton.OK, MessageBoxImage.Hand);
    }
  }

  private void App_DispatcherUnhandledException(
    object sender,
    DispatcherUnhandledExceptionEventArgs e)
  {
    e.Handled = true;
    if ((bool) Application.Current.Properties[(object) "CommandLineCPS"])
      Environment.Exit(-15);
    if (e.Exception is CommonException)
    {
      CommonException exception = e.Exception as CommonException;
      if (exception.ErrorCode == CommonExceptionHelper.DirectMsgCode && !(bool) Application.Current.Properties[(object) "CommandLineCPS"])
      {
        int num1 = (int) MessageBox.Show(exception.Message, AppResources.error_Id, MessageBoxButton.OK, MessageBoxImage.Hand);
      }
      else
      {
        if ((bool) Application.Current.Properties[(object) "CommandLineCPS"])
          return;
        int num2 = (int) MessageBox.Show(Motorola.CommonCPS.ResourceRepository.ResourceHelper.GetCommonErrorMessageByID(exception.ErrorCode.ToString()), AppResources.error_Id, MessageBoxButton.OK, MessageBoxImage.Hand);
      }
    }
    else
    {
      if (!(e.Exception.Source == "SpecialFeatures") || (bool) Application.Current.Properties[(object) "CommandLineCPS"])
        return;
      int num = (int) MessageBox.Show(AppResources.Unkown_Error, AppResources.error_Id, MessageBoxButton.OK, MessageBoxImage.Hand);
    }
  }

  private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
  {
    if ((e.ExceptionObject as Exception).Source == "SpecialFeatures" && !(bool) Application.Current.Properties[(object) "CommandLineCPS"])
    {
      int num = (int) MessageBox.Show(AppResources.Unkown_Error, AppResources.error_Id, MessageBoxButton.OK, MessageBoxImage.Hand);
    }
    else
    {
      if (!(bool) Application.Current.Properties[(object) "CommandLineCPS"])
        return;
      Environment.Exit(-15);
    }
  }

  private void App_Deactivated(object sender, EventArgs e) => AcpUI.Common.Utility.SaveFieldWithFocus();

  internal string CommandLineArgument { get; private set; }

  private void Application_Startup(object sender, StartupEventArgs e)
  {
    if (File.Exists("c:\\Let_me_help_you_debug_commandline_CPS_123"))
      Debugger.Launch();
    if (e.Args.Length == 0)
      return;
    this.CommandLineArgument = e.Args[0].ToLower();
    if (!(this.CommandLineArgument == "/cruncher") || e.Args.Length <= 1)
      return;
    Cruncher.Instance.ParseCommandLineParameters(e.Args);
  }

  private void WalkDictionary(ResourceDictionary resources)
  {
    foreach (DictionaryEntry resource in resources)
      ;
    foreach (ResourceDictionary mergedDictionary in resources.MergedDictionaries)
      this.WalkDictionary(mergedDictionary);
  }

  [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
  [DebuggerNonUserCode]
  public void InitializeComponent()
  {
    if (this._contentLoaded)
      return;
    this._contentLoaded = true;
    this.Startup += new StartupEventHandler(this.Application_Startup);
    this.StartupUri = new Uri("WindowMain.xaml", UriKind.Relative);
    Application.LoadComponent((object) this, new Uri("/APXFamilyCPS;component/app.xaml", UriKind.Relative));
  }

  [DebuggerNonUserCode]
  [STAThread]
  [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
  public static void Main()
  {
    App app = new App();
    app.InitializeComponent();
    app.Run();
  }
}
