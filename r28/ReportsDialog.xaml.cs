// Decompiled with JetBrains decompiler
// Type: MackinawCPS.ReportsDialog
// Assembly: APXFamilyCPS, Version=15.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 7983BD42-76AB-479D-8966-B7B635E0E28A
// Assembly location: C:\Program Files (x86)\Motorola\ApxFamilyDepot R28\APXdepotR28.exe

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
using System.Diagnostics.CodeAnalysis;
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
  private bool is_RadioInfo_Clicked = false;
  private bool is_PorHandout_Clicked = false;
  private bool is_O2Handout_Clicked = false;
  private bool is_O3Handout_Clicked = false;
  private bool is_O7Handout_Clicked = false;
  private bool is_O5Handout_Clicked = false;
  private bool is_O9Handout_Clicked = false;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal Label LblReportsLanguage;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ComboBox reportLangChoice;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal Button buttonOK;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal Button buttonCancel;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal Button buttonHelp;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
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
      AcpUI.Help.Utility.CloseHelpWindowIfOpen();
      AcpUI.Help.Utility.DisplayCPSHelp("zzCPSOptions\\Language\\Select_Reports_Language_Window_Options.htm");
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

  [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
  [DebuggerNonUserCode]
  public void InitializeComponent()
  {
    if (this._contentLoaded)
      return;
    this._contentLoaded = true;
    Application.LoadComponent((object) this, new Uri("/APXFamilyCPS;component/reportsdialog.xaml", UriKind.Relative));
  }

  [DebuggerNonUserCode]
  [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
  [EditorBrowsable(EditorBrowsableState.Never)]
  [SuppressMessage("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
  [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
  [SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
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
