// Decompiled with JetBrains decompiler
// Type: MackinawCPS.Options
// Assembly: APXFamilyCPS, Version=36.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 9359335E-041C-4B12-9409-F4E6E7D93299
// Assembly location: C:\Program Files (x86)\Motorola\ApxFamilyCPS R36.00\APXFamilyCPS1.exe

using AcpCommonLib;
using AcpUI;
using AcpUI.Common;
using AcpUtility;
using CommonResources;
using ConstraintHelper;
using MackinawCPS.HomeBase;
using MackinawCPS.Properties;
using Microsoft.Win32;
using Motorola.Common.Communication.CommonUtil;
using Motorola.CommonCPS.Server.EntityModel;
using SpecialFeatures.RadioLanguagePack;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Navigation;
using System.Xml;

#nullable disable
namespace MackinawCPS;

public partial class Options : PageFunction<string>, INotifyPropertyChanged, IComponentConnector
{
  private WindowMain _parent;
  private string initialLanguageSelection = string.Empty;
  private string reportLanguageSelection = string.Empty;
  private string initialSysKeysLocation = string.Empty;
  private string initialHomeScreenLogoPath = string.Empty;
  private Settings parentWindowSettings;
  private string m_ARSAppInstallPath = string.Empty;
  private string m_AKAAppInstallPath = string.Empty;
  private const string SSLAdminTool = "SSLAdminTool.exe";
  private const string ASKAdminTool = "ASKAdminTool.exe";
  private Dictionary<string, AcpExpander> expanderlist = new Dictionary<string, AcpExpander>();
  internal AcpThemeBase ThemeBaseObj;
  internal Hyperlink HLinkOptionsGeneral;
  internal Hyperlink HLinkOptionsLanguage;
  internal Hyperlink HLinkOptionsAdmin;
  internal System.Windows.Controls.Button buttonOK;
  internal System.Windows.Controls.Button buttonCancel;
  internal System.Windows.Controls.Button buttonHelp;
  internal StackPanel MyStackPanel;
  internal AcpExpander ExpanderOptionsGeneral;
  internal AcpLabel LblSystemKeysLocation;
  internal AcpTextBox TxtDefKeyFileLocation;
  internal System.Windows.Controls.Button SysKeyLocationBrowse;
  internal AcpLabel LblDVRSExportLocation;
  internal AcpTextBox txtDefDVRSExportLocation;
  internal System.Windows.Controls.Button DVRSExportLocationBrowse;
  internal System.Windows.Controls.GroupBox GrpBoxOptionsApplicationLogo;
  internal System.Windows.Controls.Button AppLogoChange;
  internal System.Windows.Controls.Button AppLogoRestore;
  internal System.Windows.Controls.Label LblSkipCloneExpressSysTypeCheck;
  internal System.Windows.Controls.CheckBox SkipCloneExpressSysTypeCheck;
  internal System.Windows.Controls.Label LblUploadLogToRemoteServer;
  internal System.Windows.Controls.CheckBox UploadLogToRemoteServerCheckBox;
  internal AcpExpander ExpanderOptionsLanguage;
  internal AcpLabel LblOptionsCPSLanguage;
  internal AcpComboBox comboLanguageChoices;
  internal AcpLabel LblOptionsReportsLanguage;
  internal AcpComboBox reportLanguageChoices;
  internal AcpLabel LblOptionsUpgradeRadioLanguage;
  internal AcpComboBox comboUpgradeRadioLanguageChoices;
  internal AcpExpander ExpanderOptionsAdmin;
  internal System.Windows.Controls.Button ButtonLaunchAKA;
  internal System.Windows.Controls.Button ButtonLaunchARSDataAdminApp;
  private bool _contentLoaded;

  internal Options(WindowMain parent)
  {
    this.InitializeComponent();
    AcpUI.Common.Utility.SetDirection((FrameworkElement) this);
    this._parent = parent;
    this.parentWindowSettings = this._parent.settingsSavedOnAppExit;
    this.DataContext = (object) this;
    if (Thread.CurrentThread.CurrentUICulture.TextInfo.IsRightToLeft)
      this.FlowDirection = System.Windows.FlowDirection.RightToLeft;
    else
      this.FlowDirection = System.Windows.FlowDirection.LeftToRight;
    if (Thread.CurrentThread.CurrentCulture.Name.ToLower().StartsWith("ar"))
    {
      this.TxtDefKeyFileLocation.FlowDirection = System.Windows.FlowDirection.LeftToRight;
      this.TxtDefKeyFileLocation.TextAlignment = TextAlignment.Right;
      this.txtDefDVRSExportLocation.FlowDirection = System.Windows.FlowDirection.LeftToRight;
      this.txtDefDVRSExportLocation.TextAlignment = TextAlignment.Right;
    }
    this.SkipCloneExpressSysTypeCheck.IsChecked = new bool?(this.parentWindowSettings.BlockNewSysCheck);
    this.UploadLogToRemoteServerCheckBox.IsChecked = new bool?(this.parentWindowSettings.UploadToServer);
  }

  private void OnLoad(object sender, RoutedEventArgs e)
  {
    this.comboLanguageChoices.SelectionChanged -= new SelectionChangedEventHandler(this.comboLanguageChoices_SelectionChanged);
    this.PopulateComboBox();
    foreach (UIElement child in this.MyStackPanel.Children)
    {
      if (child is AcpExpander acpExpander)
        this.expanderlist.Add(acpExpander.Name, acpExpander);
    }
    this.ExpanderOptionsGeneral.Focus();
    this.initialLanguageSelection = string.IsNullOrEmpty(this.parentWindowSettings.UserSelectedApplicationLanguage) ? (AppResources.Culture.Name.Contains("es") || AppResources.Culture.Name.Contains("ar") ? AppResources.Culture.Name.Substring(0, 2) : AppResources.Culture.Name) : this.parentWindowSettings.UserSelectedApplicationLanguage;
    this.reportLanguageSelection = string.IsNullOrEmpty(this.parentWindowSettings.UserSelectedReportsLanguage) ? "en" : this.parentWindowSettings.UserSelectedReportsLanguage;
    bool flag1 = false;
    bool flag2 = false;
    foreach (KeyValuePair<string, string> additionalCpsLanguage in (IEnumerable) App.AdditionalCPSLanguages)
    {
      if (additionalCpsLanguage.Value == this.initialLanguageSelection)
      {
        this.comboLanguageChoices.SelectedItem = (object) additionalCpsLanguage.Key;
        flag1 = true;
        break;
      }
    }
    if (this.reportLanguageSelection == "Prompt")
    {
      this.reportLanguageChoices.SelectedIndex = 0;
      flag2 = true;
    }
    else
    {
      foreach (KeyValuePair<string, string> additionalCpsLanguage in (IEnumerable) App.AdditionalCPSLanguages)
      {
        if (additionalCpsLanguage.Value == this.reportLanguageSelection)
        {
          this.reportLanguageChoices.SelectedItem = (object) additionalCpsLanguage.Key;
          flag2 = true;
          break;
        }
      }
    }
    if (!flag1)
      this.comboLanguageChoices.SelectedItem = (object) new CultureInfo(App.mainAssemblyCulture).NativeName;
    if (!flag2)
      this.reportLanguageChoices.SelectedItem = (object) new CultureInfo(App.mainAssemblyCulture).NativeName;
    this.initialLanguageSelection = (string) this.comboLanguageChoices.SelectedItem;
    this.initialSysKeysLocation = this._parent.defaultKeyFilesLocation;
    this.UpdateKeyFilesLocationCtrl();
    this.txtDefDVRSExportLocation.Text = this.setDefaultDVRSExportLocation();
    this.txtDefDVRSExportLocation.ToolTip = (object) this.txtDefDVRSExportLocation.Text;
    this.initialHomeScreenLogoPath = Settings.Default.CustomBackgroudPath;
    if (this.parentWindowSettings.UpgradeRadioLang > -1 && this.parentWindowSettings.UpgradeRadioLang < 3)
      this.comboUpgradeRadioLanguageChoices.SelectedIndex = this.parentWindowSettings.UpgradeRadioLang;
    else
      this.comboUpgradeRadioLanguageChoices.SelectedIndex = 0;
    this.comboLanguageChoices.SelectionChanged += new SelectionChangedEventHandler(this.comboLanguageChoices_SelectionChanged);
  }

  public static Visibility IsAdditionalLanguageCountGTEOne
  {
    get => App.AdditionalCPSLanguages.Count >= 1 ? Visibility.Visible : Visibility.Collapsed;
  }

  public WindowMain MainFrame
  {
    get => this._parent;
    set
    {
      this._parent = value;
      if (this.PropertyChanged == null)
        return;
      this.PropertyChanged((object) this, new PropertyChangedEventArgs(nameof (MainFrame)));
    }
  }

  private void HomeScreenButton_click(object sender, RoutedEventArgs e)
  {
    this._parent.OnAppCustomizeOpen(sender, e);
  }

  private void HomeScreenRestoreDefault_click(object sender, RoutedEventArgs e)
  {
    this._parent.OnAppRestoreToDefault(sender, e);
  }

  private void buttonOK_Click(object sender, RoutedEventArgs e)
  {
    string empty = string.Empty;
    bool flag = false;
    string selectedItem = (string) this.comboLanguageChoices.SelectedItem;
    if (this.initialLanguageSelection != selectedItem || this.initialLanguageSelection != AppResources.Culture.NativeName)
    {
      CultureInfo cultureInfo = new CultureInfo(App.mainAssemblyCulture);
      string str = "en";
      if (selectedItem.Contains(cultureInfo.NativeName))
      {
        this.parentWindowSettings.SelectedHelpLanguage_RootDir = string.Format("Help{0}{1}{0}", (object) Path.DirectorySeparatorChar, (object) str);
        this.parentWindowSettings.UserSelectedApplicationLanguage = str;
      }
      else
      {
        this.parentWindowSettings.SelectedHelpLanguage_RootDir = string.Format("Help{0}{1}{0}", (object) Path.DirectorySeparatorChar, (object) App.AdditionalCPSLanguages[selectedItem]);
        this.parentWindowSettings.UserSelectedApplicationLanguage = App.AdditionalCPSLanguages[selectedItem];
      }
      flag = true;
      empty += AppResources.CPS_Language_changes_will_go_into;
    }
    if (this.reportLanguageChoices.SelectedIndex == 0)
    {
      this.parentWindowSettings.ReportLangDia = true;
      this.parentWindowSettings.UserSelectedReportsLanguage = "Prompt";
    }
    else
    {
      this.parentWindowSettings.ReportLangDia = false;
      this.parentWindowSettings.UserSelectedReportsLanguage = App.AdditionalCPSLanguages[(string) this.reportLanguageChoices.SelectedItem];
    }
    if (this.parentWindowSettings.UpgradeRadioLang != this.comboUpgradeRadioLanguageChoices.SelectedIndex)
    {
      this.parentWindowSettings.UpgradeRadioLang = this.comboUpgradeRadioLanguageChoices.SelectedIndex;
      LanguagePackHelper.UpgradRadioLangSetting = this.comboUpgradeRadioLanguageChoices.SelectedIndex;
    }
    if (this._parent.defaultDVRSFileLocation != this.txtDefDVRSExportLocation.Text)
    {
      this._parent.defaultDVRSFileLocation = this.txtDefDVRSExportLocation.Text;
      this.parentWindowSettings.DVRS_Export_Default_Folder = this.txtDefDVRSExportLocation.Text;
      UtilityMack.DVRSExportPath = this.txtDefDVRSExportLocation.Text;
    }
    if (this.initialSysKeysLocation != this._parent.defaultKeyFilesLocation)
    {
      if (flag)
        empty += "\n";
      else
        flag = true;
      empty += AppResources.System_Key_Files_Location_changes_will_go;
    }
    bool? isChecked = this.SkipCloneExpressSysTypeCheck.IsChecked;
    if (isChecked.HasValue)
    {
      isChecked = this.SkipCloneExpressSysTypeCheck.IsChecked;
      this.parentWindowSettings.BlockNewSysCheck = isChecked.Value;
    }
    isChecked = this.UploadLogToRemoteServerCheckBox.IsChecked;
    if (isChecked.HasValue)
    {
      isChecked = this.UploadLogToRemoteServerCheckBox.IsChecked;
      this.parentWindowSettings.UploadToServer = isChecked.Value;
      if (flag)
        empty += "\n";
      else
        flag = true;
      empty += AppResources.APXCPS_Logging_Change_Notification;
    }
    if (flag)
    {
      int num = (int) System.Windows.MessageBox.Show(empty, AppResources.CPS_Options, MessageBoxButton.OK, MessageBoxImage.Asterisk);
    }
    Settings.Default.Save();
    try
    {
      this.SaveUserConfig();
    }
    catch (Exception ex)
    {
    }
    ((Window) this.Parent).Close();
  }

  private void buttonCancel_Click(object sender, RoutedEventArgs e)
  {
    if (this.initialHomeScreenLogoPath != Settings.Default.CustomBackgroudPath)
    {
      if (this._parent.FrameCenterTop.Content is PageWelcome)
        ((PageWelcome) this._parent.FrameCenterTop.Content).SetBackground(this.initialHomeScreenLogoPath);
      else if (this._parent.FrameCenterTop.Content is PageCustomViewWelcome)
      {
        ((PageCustomViewWelcome) this._parent.FrameCenterTop.Content).SetBackground(this.initialHomeScreenLogoPath);
      }
      else
      {
        Settings.Default.CustomBackgroudPath = this.initialHomeScreenLogoPath;
        Settings.Default.Save();
      }
    }
    if (this.initialSysKeysLocation != this._parent.defaultKeyFilesLocation)
      this._parent.defaultKeyFilesLocation = this.initialSysKeysLocation;
    ((Window) this.Parent).Close();
  }

  private void SaveUserConfig()
  {
    string str1 = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Motorola_Solutions,_Inc";
    string empty1 = string.Empty;
    string empty2 = string.Empty;
    string empty3 = string.Empty;
    object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof (AssemblyInformationalVersionAttribute), false);
    string str2 = customAttributes.Length != 0 ? ((AssemblyInformationalVersionAttribute) customAttributes[0]).InformationalVersion.Substring(1, 2) : string.Empty;
    string path = $"{str1}\\{str2}";
    if (!Directory.Exists(path))
      Directory.CreateDirectory(path);
    string str3 = path + "\\userapp.config";
    if (File.Exists(str3))
    {
      XmlDocument xmlDocument = new XmlDocument();
      xmlDocument.Load(str3);
      XmlNode xmlNode1 = xmlDocument.SelectSingleNode("/configuration/userSettings/MackinawCPS.Properties.Settings/setting[@name='UserSelectedApplicationLanguage']/value");
      if (xmlNode1 == null)
      {
        XmlNode xmlNode2 = xmlDocument.SelectSingleNode("/configuration/userSettings/MackinawCPS.Properties.Settings");
        XmlElement element1 = xmlDocument.CreateElement("setting");
        element1.SetAttribute("name", "UserSelectedApplicationLanguage");
        element1.SetAttribute("serializeAs", "String");
        XmlElement element2 = xmlDocument.CreateElement("value");
        element2.InnerText = this.parentWindowSettings.UserSelectedApplicationLanguage;
        element1.AppendChild((XmlNode) element2);
        xmlNode2.AppendChild((XmlNode) element1);
      }
      else
        xmlNode1.InnerText = this.parentWindowSettings.UserSelectedApplicationLanguage;
      xmlDocument.Save(str3);
    }
    else
    {
      XmlDocument xmlDocument = new XmlDocument();
      xmlDocument.AppendChild((XmlNode) xmlDocument.CreateXmlDeclaration("1.0", "utf-8", (string) null));
      XmlNode element3 = (XmlNode) xmlDocument.CreateElement("configuration");
      XmlElement element4 = xmlDocument.CreateElement("userSettings");
      XmlElement element5 = xmlDocument.CreateElement("MackinawCPS.Properties.Settings");
      XmlElement element6 = xmlDocument.CreateElement("setting");
      element6.SetAttribute("name", "UserSelectedApplicationLanguage");
      element6.SetAttribute("serializeAs", "String");
      XmlElement element7 = xmlDocument.CreateElement("value");
      element7.InnerText = this.parentWindowSettings.UserSelectedApplicationLanguage;
      element6.AppendChild((XmlNode) element7);
      element5.AppendChild((XmlNode) element6);
      element4.AppendChild((XmlNode) element5);
      element3.AppendChild((XmlNode) element4);
      xmlDocument.AppendChild(element3);
      xmlDocument.Save(str3);
    }
  }

  private void PopulateComboBox()
  {
    if (!VersionInfoHelper.IsDFlagExisted(DFlagType.DASTRO))
    {
      CultureInfo cultureInfo = new CultureInfo(App.mainAssemblyCulture);
      this.comboLanguageChoices.Items.Add((object) cultureInfo.NativeName);
      this.reportLanguageChoices.Items.Add((object) cultureInfo.NativeName);
      if (App.AdditionalCPSLanguages.Count <= 0)
        return;
      foreach (KeyValuePair<string, string> additionalCpsLanguage in (IEnumerable) App.AdditionalCPSLanguages)
      {
        if (additionalCpsLanguage.Key != null)
        {
          this.comboLanguageChoices.Items.Add((object) additionalCpsLanguage.Key);
          this.reportLanguageChoices.Items.Add((object) additionalCpsLanguage.Key);
        }
      }
    }
    else
    {
      int removeIndex = 0;
      for (int index = 0; index < this.reportLanguageChoices.Items.Count; ++index)
      {
        if ((this.reportLanguageChoices.Items[index] as ComboBoxItem).Content.ToString().Contains(AppResources.Prompt_Id))
        {
          removeIndex = index;
          break;
        }
      }
      this.reportLanguageChoices.Items.RemoveAt(removeIndex);
      CultureInfo cultureInfo = new CultureInfo(App.mainAssemblyCulture);
      this.comboLanguageChoices.Items.Add((object) cultureInfo.NativeName);
      this.reportLanguageChoices.Items.Add((object) cultureInfo.NativeName);
    }
  }

  private void OnSetDefKeyFileLocation(object sender, RoutedEventArgs e)
  {
    FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
    folderBrowserDialog.ShowNewFolderButton = true;
    folderBrowserDialog.RootFolder = Environment.SpecialFolder.MyComputer;
    if (Directory.Exists(this._parent.defaultKeyFilesLocation))
      folderBrowserDialog.SelectedPath = this._parent.defaultKeyFilesLocation;
    folderBrowserDialog.Description = AppResources.Select_the_directory_that_contains_key_files;
    if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
      return;
    this.TxtDefKeyFileLocation.Text = folderBrowserDialog.SelectedPath;
    this.TxtDefKeyFileLocation.ToolTip = (object) folderBrowserDialog.SelectedPath;
    this._parent.defaultKeyFilesLocation = folderBrowserDialog.SelectedPath;
  }

  private void UpdateKeyFilesLocationCtrl()
  {
    this.TxtDefKeyFileLocation.Text = this._parent.defaultKeyFilesLocation;
    this.TxtDefKeyFileLocation.ToolTip = (object) this._parent.defaultKeyFilesLocation;
  }

  private void F1HelpCommandCanExcute(object sender, CanExecuteRoutedEventArgs e)
  {
    e.CanExecute = true;
  }

  private void onHelpButton_Click(object sender, RoutedEventArgs e)
  {
    try
    {
      ACPBrowser.Utility.CloseHelpWindowIfOpen();
      ACPBrowser.Utility.DisplayCPSHelpDITA("#d9fcbcd8");
    }
    catch (Exception ex)
    {
    }
  }

  private void ButtonLaunchARSDataAdminApp_click(object sender, RoutedEventArgs e)
  {
    string arsAppInstallPath = this.m_ARSAppInstallPath;
    Process process = new Process();
    process.StartInfo.FileName = arsAppInstallPath;
    try
    {
      process.Start();
    }
    catch (Exception ex)
    {
      this.ButtonLaunchARSDataAdminApp.IsEnabled = false;
      AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, AppResources.Failed_To_Launch_ARS_Data_Administrator.AcpStringFormat((object) ex.Message.ToString()));
    }
    process.Dispose();
  }

  private void ButtonLaunchAKA_Click(object sender, RoutedEventArgs e)
  {
    string akaAppInstallPath = this.m_AKAAppInstallPath;
    Process process = new Process();
    process.StartInfo.FileName = akaAppInstallPath;
    try
    {
      process.Start();
    }
    catch (Exception ex)
    {
      this.ButtonLaunchAKA.IsEnabled = false;
      AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, AppResources.Failed_To_Launch_Advanced_Keys_Administrator.AcpStringFormat((object) ex.Message.ToString()));
    }
    process.Dispose();
  }

  public bool IsAdminButtonVisible => this.IsUserAdmin();

  public bool IsAKAAdminLauncherVisible => this.IsAKAAdminAppInstalled;

  public bool IsLanguageButtonVisible => true;

  public bool IsARSAdminLauncherVisible => this.IsARSAdminAppInstalled;

  public bool IsCloudNativeMode => Startup.IsCloudNativeMode;

  private bool IsUserAdmin()
  {
    bool flag = true;
    try
    {
      if (!new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator))
        flag = false;
    }
    catch (Exception ex)
    {
      flag = false;
    }
    return flag;
  }

  private bool SearchARSApplication(RegistryKey key)
  {
    if (key == null)
      return false;
    foreach (RegistryKey registryKey in ((IEnumerable<string>) key.GetSubKeyNames()).Select<string, RegistryKey>((Func<string, RegistryKey>) (keyName => key.OpenSubKey(keyName))))
    {
      if (registryKey.GetValue("Path") is string str && str.Contains("ARS Data Administrator Application"))
      {
        this.m_ARSAppInstallPath = registryKey.GetValue("Path", (object) string.Empty).ToString() + "SSLAdminTool.exe";
        break;
      }
    }
    return !string.IsNullOrEmpty(this.m_ARSAppInstallPath) && File.Exists(this.m_ARSAppInstallPath);
  }

  internal bool IsARSAdminAppInstalled
  {
    get
    {
      bool adminAppInstalled = true;
      try
      {
        using (RegistryKey key1 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey("SOFTWARE")?.OpenSubKey("Microsoft")?.OpenSubKey("Windows")?.OpenSubKey("CurrentVersion")?.OpenSubKey("App Paths"))
        {
          adminAppInstalled = this.SearchARSApplication(key1);
          if (!adminAppInstalled)
          {
            using (RegistryKey key2 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey("SOFTWARE")?.OpenSubKey("Microsoft")?.OpenSubKey("Windows")?.OpenSubKey("CurrentVersion")?.OpenSubKey("App Paths"))
              adminAppInstalled = this.SearchARSApplication(key2);
          }
        }
      }
      catch (Exception ex)
      {
        Trace.WriteLine("IsARSAdminAppInstalled threw an exception, error: " + ex.Message);
        adminAppInstalled = false;
      }
      return adminAppInstalled;
    }
  }

  private bool SearchAKSApplication(RegistryKey key)
  {
    if (key == null)
      return false;
    foreach (RegistryKey registryKey in ((IEnumerable<string>) key.GetSubKeyNames()).Select<string, RegistryKey>((Func<string, RegistryKey>) (keyName => key.OpenSubKey(keyName))))
    {
      if (registryKey.GetValue("Path") is string str && str.Contains("Advanced Keys Administrator"))
      {
        this.m_AKAAppInstallPath = registryKey.GetValue("Path", (object) string.Empty).ToString() + "ASKAdminTool.exe";
        break;
      }
    }
    return !string.IsNullOrEmpty(this.m_AKAAppInstallPath) && File.Exists(this.m_AKAAppInstallPath);
  }

  internal bool IsAKAAdminAppInstalled
  {
    get
    {
      bool adminAppInstalled = true;
      try
      {
        using (RegistryKey key1 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey("SOFTWARE")?.OpenSubKey("Microsoft")?.OpenSubKey("Windows")?.OpenSubKey("CurrentVersion")?.OpenSubKey("App Paths"))
        {
          adminAppInstalled = this.SearchAKSApplication(key1);
          if (!adminAppInstalled)
          {
            using (RegistryKey key2 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey("SOFTWARE")?.OpenSubKey("Microsoft")?.OpenSubKey("Windows")?.OpenSubKey("CurrentVersion")?.OpenSubKey("App Paths"))
              adminAppInstalled = this.SearchAKSApplication(key2);
          }
        }
      }
      catch (Exception ex)
      {
        Trace.WriteLine("IsAKAAdminAppInstalled threw an exception, error: " + ex.Message);
        adminAppInstalled = false;
      }
      return adminAppInstalled;
    }
  }

  private string setDefaultDVRSExportLocation()
  {
    string dvrsFileLocation = this._parent.defaultDVRSFileLocation;
    if (!Directory.Exists(dvrsFileLocation) && this.txtDefDVRSExportLocation.Visibility == Visibility.Visible && this.txtDefDVRSExportLocation.IsEnabled)
      AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Warning, string.Format(AppResources.The_DVRS_Location_Does_Not_Exist_Or_Is_Not_Reachable, (object) dvrsFileLocation));
    return dvrsFileLocation;
  }

  private void OnUpdateDefDVRSExportLocation(object sender, RoutedEventArgs e)
  {
    FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
    folderBrowserDialog.ShowNewFolderButton = true;
    folderBrowserDialog.RootFolder = Environment.SpecialFolder.MyComputer;
    if (Directory.Exists(this.txtDefDVRSExportLocation.Text))
      folderBrowserDialog.SelectedPath = this.txtDefDVRSExportLocation.Text;
    folderBrowserDialog.Description = AppResources.Select_DVRS_Export_Storage_Location;
    if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
      return;
    this.txtDefDVRSExportLocation.Text = folderBrowserDialog.SelectedPath;
    this.txtDefDVRSExportLocation.ToolTip = (object) folderBrowserDialog.SelectedPath;
  }

  private void comboLanguageChoices_SelectionChanged(object sender, RoutedEventArgs e)
  {
    this.reportLanguageChoices.SelectedIndex = 0;
  }

  public event PropertyChangedEventHandler PropertyChanged;

  private void HLinkOptionsClick(object sender, RoutedEventArgs e)
  {
    string tag = (string) ((FrameworkContentElement) sender).Tag;
    try
    {
      AcpExpander acpExpander = this.expanderlist[tag];
      if (!acpExpander.IsExpanded)
        acpExpander.IsExpanded = true;
      acpExpander.BringIntoView();
      acpExpander.Focus();
    }
    catch (Exception ex)
    {
    }
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "8.0.8.0")]
  public void InitializeComponent()
  {
    if (this._contentLoaded)
      return;
    this._contentLoaded = true;
    System.Windows.Application.LoadComponent((object) this, new Uri("/APXFamilyCPS;component/options.xaml", UriKind.Relative));
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "8.0.8.0")]
  [EditorBrowsable(EditorBrowsableState.Never)]
  void IComponentConnector.Connect(int connectionId, object target)
  {
    switch (connectionId)
    {
      case 1:
        ((FrameworkElement) target).Loaded += new RoutedEventHandler(this.OnLoad);
        break;
      case 2:
        ((CommandBinding) target).Executed += new ExecutedRoutedEventHandler(this.onHelpButton_Click);
        ((CommandBinding) target).CanExecute += new CanExecuteRoutedEventHandler(this.F1HelpCommandCanExcute);
        break;
      case 3:
        this.ThemeBaseObj = (AcpThemeBase) target;
        break;
      case 4:
        this.HLinkOptionsGeneral = (Hyperlink) target;
        this.HLinkOptionsGeneral.Click += new RoutedEventHandler(this.HLinkOptionsClick);
        break;
      case 5:
        this.HLinkOptionsLanguage = (Hyperlink) target;
        this.HLinkOptionsLanguage.Click += new RoutedEventHandler(this.HLinkOptionsClick);
        break;
      case 6:
        this.HLinkOptionsAdmin = (Hyperlink) target;
        this.HLinkOptionsAdmin.Click += new RoutedEventHandler(this.HLinkOptionsClick);
        break;
      case 7:
        this.buttonOK = (System.Windows.Controls.Button) target;
        this.buttonOK.Click += new RoutedEventHandler(this.buttonOK_Click);
        break;
      case 8:
        this.buttonCancel = (System.Windows.Controls.Button) target;
        this.buttonCancel.Click += new RoutedEventHandler(this.buttonCancel_Click);
        break;
      case 9:
        this.buttonHelp = (System.Windows.Controls.Button) target;
        this.buttonHelp.Click += new RoutedEventHandler(this.onHelpButton_Click);
        break;
      case 10:
        this.MyStackPanel = (StackPanel) target;
        break;
      case 11:
        this.ExpanderOptionsGeneral = (AcpExpander) target;
        break;
      case 12:
        this.LblSystemKeysLocation = (AcpLabel) target;
        break;
      case 13:
        this.TxtDefKeyFileLocation = (AcpTextBox) target;
        break;
      case 14:
        this.SysKeyLocationBrowse = (System.Windows.Controls.Button) target;
        this.SysKeyLocationBrowse.Click += new RoutedEventHandler(this.OnSetDefKeyFileLocation);
        break;
      case 15:
        this.LblDVRSExportLocation = (AcpLabel) target;
        break;
      case 16 /*0x10*/:
        this.txtDefDVRSExportLocation = (AcpTextBox) target;
        break;
      case 17:
        this.DVRSExportLocationBrowse = (System.Windows.Controls.Button) target;
        this.DVRSExportLocationBrowse.Click += new RoutedEventHandler(this.OnUpdateDefDVRSExportLocation);
        break;
      case 18:
        this.GrpBoxOptionsApplicationLogo = (System.Windows.Controls.GroupBox) target;
        break;
      case 19:
        this.AppLogoChange = (System.Windows.Controls.Button) target;
        this.AppLogoChange.Click += new RoutedEventHandler(this.HomeScreenButton_click);
        break;
      case 20:
        this.AppLogoRestore = (System.Windows.Controls.Button) target;
        this.AppLogoRestore.Click += new RoutedEventHandler(this.HomeScreenRestoreDefault_click);
        break;
      case 21:
        this.LblSkipCloneExpressSysTypeCheck = (System.Windows.Controls.Label) target;
        break;
      case 22:
        this.SkipCloneExpressSysTypeCheck = (System.Windows.Controls.CheckBox) target;
        break;
      case 23:
        this.LblUploadLogToRemoteServer = (System.Windows.Controls.Label) target;
        break;
      case 24:
        this.UploadLogToRemoteServerCheckBox = (System.Windows.Controls.CheckBox) target;
        break;
      case 25:
        this.ExpanderOptionsLanguage = (AcpExpander) target;
        break;
      case 26:
        this.LblOptionsCPSLanguage = (AcpLabel) target;
        break;
      case 27:
        this.comboLanguageChoices = (AcpComboBox) target;
        this.comboLanguageChoices.SelectionChanged += new SelectionChangedEventHandler(this.comboLanguageChoices_SelectionChanged);
        break;
      case 28:
        this.LblOptionsReportsLanguage = (AcpLabel) target;
        break;
      case 29:
        this.reportLanguageChoices = (AcpComboBox) target;
        break;
      case 30:
        this.LblOptionsUpgradeRadioLanguage = (AcpLabel) target;
        break;
      case 31 /*0x1F*/:
        this.comboUpgradeRadioLanguageChoices = (AcpComboBox) target;
        break;
      case 32 /*0x20*/:
        this.ExpanderOptionsAdmin = (AcpExpander) target;
        break;
      case 33:
        this.ButtonLaunchAKA = (System.Windows.Controls.Button) target;
        this.ButtonLaunchAKA.Click += new RoutedEventHandler(this.ButtonLaunchAKA_Click);
        break;
      case 34:
        this.ButtonLaunchARSDataAdminApp = (System.Windows.Controls.Button) target;
        this.ButtonLaunchARSDataAdminApp.Click += new RoutedEventHandler(this.ButtonLaunchARSDataAdminApp_click);
        break;
      default:
        this._contentLoaded = true;
        break;
    }
  }
}
