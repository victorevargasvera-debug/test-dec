// Decompiled with JetBrains decompiler
// Type: MackinawCPS.ReportsDialog
// Assembly: APXFamilyCPS, Version=36.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 9359335E-041C-4B12-9409-F4E6E7D93299
// Assembly location: C:\Program Files (x86)\Motorola\ApxFamilyCPS R36.00\APXFamilyCPS1.exe

using AcpCommonLib;
using CommonResources;
using MackinawCPS.Properties;
using SpecialFeatures.AcpReportManagerLib;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;

#nullable disable
namespace MackinawCPS;

public partial class ReportsDialog : Window, IComponentConnector
{
  private WindowMain _parent;
  private string reportsLanguageSelection = string.Empty;
  private string locale = string.Empty;
  private Settings repDiaSettings;
  private bool is_RadioInfo_Clicked;
  private bool is_PorHandout_Clicked;
  private bool is_O2Handout_Clicked;
  private bool is_O3Handout_Clicked;
  private bool is_O7Handout_Clicked;
  private bool is_E5Handout_Clicked;
  private bool is_O5Handout_Clicked;
  private bool is_O9Handout_Clicked;
  internal Label LblReportsLanguage;
  internal ComboBox reportLangChoice;
  internal Button buttonOK;
  internal Button buttonCancel;
  internal Button buttonHelp;
  internal CheckBox reportDiaChkbox;
  private bool _contentLoaded;

  internal bool Is_RadioInfo_Clicked
  {
    get => this.is_RadioInfo_Clicked;
    set => this.is_RadioInfo_Clicked = value;
  }

  internal bool Is_PorHandout_Clicked
  {
    get => this.is_PorHandout_Clicked;
    set => this.is_PorHandout_Clicked = value;
  }

  internal bool Is_O2Handout_Clicked
  {
    get => this.is_O2Handout_Clicked;
    set => this.is_O2Handout_Clicked = value;
  }

  internal bool Is_O3Handout_Clicked
  {
    get => this.is_O3Handout_Clicked;
    set => this.is_O3Handout_Clicked = value;
  }

  internal bool Is_O7Handout_Clicked
  {
    get => this.is_O7Handout_Clicked;
    set => this.is_O7Handout_Clicked = value;
  }

  internal bool Is_E5Handout_Clicked
  {
    get => this.is_E5Handout_Clicked;
    set => this.is_E5Handout_Clicked = value;
  }

  internal bool Is_O5Handout_Clicked
  {
    get => this.is_O5Handout_Clicked;
    set => this.is_O5Handout_Clicked = value;
  }

  internal bool Is_O9Handout_Clicked
  {
    get => this.is_O9Handout_Clicked;
    set => this.is_O9Handout_Clicked = value;
  }

  internal ReportsDialog(WindowMain parent)
  {
    this.InitializeComponent();
    AcpUI.Common.Utility.SetDirection((FrameworkElement) this);
    this._parent = parent;
    this.repDiaSettings = this._parent.settingsSavedOnAppExit;
  }

  private void OnLoad(object sender, RoutedEventArgs e)
  {
    this.PopulateComboBox();
    this.reportsLanguageSelection = this.repDiaSettings.UserSelectedReportsLanguage == null ? "en" : this.repDiaSettings.UserSelectedReportsLanguage;
    this.reportLangChoice.SelectedItem = (object) this.reportsLanguageSelection;
    bool flag = false;
    foreach (KeyValuePair<string, string> additionalCpsLanguage in (IEnumerable) App.AdditionalCPSLanguages)
    {
      if (additionalCpsLanguage.Value == this.reportsLanguageSelection)
      {
        this.reportLangChoice.SelectedItem = (object) additionalCpsLanguage.Key;
        flag = true;
        break;
      }
    }
    if (flag)
      return;
    this.reportLangChoice.SelectedItem = (object) new CultureInfo(App.mainAssemblyCulture).NativeName;
  }

  private void F1HelpCommandCanExcute(object sender, CanExecuteRoutedEventArgs e)
  {
    e.CanExecute = true;
  }

  private void buttonHelp_Click(object sender, RoutedEventArgs e)
  {
    try
    {
      ACPBrowser.Utility.CloseHelpWindowIfOpen();
      ACPBrowser.Utility.DisplayCPSHelpDITA("#cafb296b");
    }
    catch (Exception ex)
    {
    }
  }

  private void buttonOK_Click(object sender, RoutedEventArgs e)
  {
    try
    {
      AcpReportMgrLib acpReportMgrLib = new AcpReportMgrLib();
      string selectedItem = (string) this.reportLangChoice.SelectedItem;
      if (this.reportsLanguageSelection != selectedItem)
      {
        AppInfoManager.ReportsLangSelection = App.AdditionalCPSLanguages[selectedItem];
        this.repDiaSettings.UserSelectedReportsLanguage = AppInfoManager.ReportsLangSelection;
      }
      if (this.reportDiaChkbox.IsChecked.Value)
      {
        this.repDiaSettings.ReportLangDia = false;
        this.repDiaSettings.UserSelectedReportsLanguage = App.AdditionalCPSLanguages[selectedItem];
        AppInfoManager.ReportsLangSelection = this.repDiaSettings.UserSelectedReportsLanguage;
      }
      else
        this.repDiaSettings.ReportLangDia = true;
      if (string.IsNullOrEmpty(AppInfoManager.ReportsLangSelection))
        AppInfoManager.ReportsLangSelection = "en";
      Settings.Default.Save();
      this.Close();
      if (this.Is_RadioInfo_Clicked)
        acpReportMgrLib.GenerateReport(reportType.RadioInfo);
      else if (this.Is_PorHandout_Clicked)
        acpReportMgrLib.GenerateReport(reportType.HandOut);
      else if (this.Is_O2Handout_Clicked)
        acpReportMgrLib.GenerateReport(reportType.HandOutO2);
      else if (this.Is_O3Handout_Clicked)
        acpReportMgrLib.GenerateReport(reportType.HandOutO3);
      else if (this.Is_E5Handout_Clicked)
        acpReportMgrLib.GenerateReport(reportType.HandOutE5);
      else if (this.Is_O5Handout_Clicked)
        acpReportMgrLib.GenerateReport(reportType.HandOutO5);
      else if (this.Is_O7Handout_Clicked)
      {
        acpReportMgrLib.GenerateReport(reportType.HandOutO7);
      }
      else
      {
        if (!this.Is_O9Handout_Clicked)
          return;
        acpReportMgrLib.GenerateReport(reportType.HandOutO9);
      }
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show(AppResources.Report_Gen_Failed);
    }
  }

  private void PopulateComboBox()
  {
    this.reportLangChoice.Items.Add((object) new CultureInfo(App.mainAssemblyCulture).NativeName);
    if (App.AdditionalCPSLanguages.Count <= 0)
      return;
    foreach (KeyValuePair<string, string> additionalCpsLanguage in (IEnumerable) App.AdditionalCPSLanguages)
    {
      if (additionalCpsLanguage.Key != null)
        this.reportLangChoice.Items.Add((object) additionalCpsLanguage.Key);
    }
  }

  private void buttonCancel_Click(object sender, RoutedEventArgs e) => this.Close();

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "8.0.8.0")]
  public void InitializeComponent()
  {
    if (this._contentLoaded)
      return;
    this._contentLoaded = true;
    Application.LoadComponent((object) this, new Uri("/APXFamilyCPS;component/reportsdialog.xaml", UriKind.Relative));
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
        ((CommandBinding) target).Executed += new ExecutedRoutedEventHandler(this.buttonHelp_Click);
        ((CommandBinding) target).CanExecute += new CanExecuteRoutedEventHandler(this.F1HelpCommandCanExcute);
        break;
      case 3:
        this.LblReportsLanguage = (Label) target;
        break;
      case 4:
        this.reportLangChoice = (ComboBox) target;
        break;
      case 5:
        this.buttonOK = (Button) target;
        this.buttonOK.Click += new RoutedEventHandler(this.buttonOK_Click);
        break;
      case 6:
        this.buttonCancel = (Button) target;
        this.buttonCancel.Click += new RoutedEventHandler(this.buttonCancel_Click);
        break;
      case 7:
        this.buttonHelp = (Button) target;
        this.buttonHelp.Click += new RoutedEventHandler(this.buttonHelp_Click);
        break;
      case 8:
        this.reportDiaChkbox = (CheckBox) target;
        break;
      default:
        this._contentLoaded = true;
        break;
    }
  }
}
