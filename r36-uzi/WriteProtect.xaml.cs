// Decompiled with JetBrains decompiler
// Type: MackinawCPS.WriteProtect
// Assembly: APXFamilyCPS, Version=36.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 9359335E-041C-4B12-9409-F4E6E7D93299
// Assembly location: C:\Program Files (x86)\Motorola\ApxFamilyCPS R36.00\APXFamilyCPS1.exe

using AcpASKLib;
using AcpBusinessLayer;
using AcpCommonLib;
using AcpCommonLib.UndoRedo;
using AcpSecurityLib;
using AcpUI;
using AcpUI.Common;
using CommonResources;
using Motorola.CommonCPS.RadioManagement.SharedServices;
using Motorola.CommonCPS.RadioManagement.UIModels;
using Motorola.CommonCPS.Server.CommonDBConstants;
using Motorola.CommonCPS.Server.EntityModel;
using SpecialFeatures.Comms;
using SpecialFeatures.Security;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Navigation;
using System.Windows.Threading;

#nullable disable
namespace MackinawCPS;

public partial class WriteProtect : PageFunction<string>, INotifyPropertyChanged, IComponentConnector
{
  private WindowMain _parent;
  private string initialLanguageSelection = string.Empty;
  private MackinawCPS.Properties.Settings parentWindowSettings;
  protected RadioSecurityData radSecData;
  private ObservableCollection<SystemKeyData> attachedASKs = new ObservableCollection<SystemKeyData>();
  private Collection<SystemKeyData> attachedKeys = new Collection<SystemKeyData>();
  private Collection<SystemKeyData> keysFromRadio = new Collection<SystemKeyData>();
  private SystemKeyData sysKeyDataFromRadio = new SystemKeyData(KeySource.HARDWARE, "0", 0, KeyType.NONE, false, false, (AccessRecord) null);
  private WindowMain accessReadWriteDevice = (WindowMain) Application.Current.MainWindow;
  public static bool readInProgress;
  private bool queryRadioBtnWasClicked;
  private bool updateRadioDataBtnWasClicked;
  private int readTransportValue;
  private Dictionary<string, AcpExpander> expanderlist = new Dictionary<string, AcpExpander>();
  private bool openFromRMC;
  private ObservableCollection<bool> isOwnerSystemIDSupported;
  private ObservableCollection<ASTRORadio> devices;
  internal AcpThemeBase ThemeBaseObj;
  internal Hyperlink HLinkGeneral;
  internal Grid MyGrid;
  internal Button ribbonBarQueryRadio;
  internal Button ribbonBarUpdateRadio;
  internal Button buttonExit;
  internal Button buttonHelp;
  internal StackPanel MyStackPanel;
  internal AcpExpander ExpanderGeneral;
  internal AcpLabel label1;
  internal AcpLabel label3;
  internal AcpLabel LblGeneralKeyType;
  internal ComboBox SelectedKeyType;
  internal AcpLabel LblDlgOwnerSystemID;
  internal ComboBox comboDlgOwnerSystemIDChoices;
  internal AcpLabel LblDlgWriteProtect;
  internal AcpCheckBox boolDlgWriteProtect;
  internal AcpLabel acplblWarning;
  internal TextBlock TxtBlkOutput;
  private bool _contentLoaded;

  internal WriteProtect(
    WindowMain parent,
    Collection<SystemKeyData> loadedAndAttachedASKs,
    bool openFromRMC = false,
    ObservableCollection<ASTRORadio> devices = null,
    ObservableCollection<bool> isOwnerSystemIDSupported = null)
  {
    this.InitializeComponent();
    AcpUI.Common.Utility.SetDirection((FrameworkElement) this);
    this._parent = parent;
    this.parentWindowSettings = this._parent.settingsSavedOnAppExit;
    this.DataContext = (object) this;
    this.openFromRMC = openFromRMC;
    this.devices = devices;
    this.isOwnerSystemIDSupported = isOwnerSystemIDSupported;
    if (this.openFromRMC)
    {
      this.Title = AppResources.Set_Radio;
      this.label1.Content = (object) "";
      this.ribbonBarQueryRadio.Opacity = 0.0;
      this.MyGrid.ColumnDefinitions.Add(new ColumnDefinition());
      this.ribbonBarUpdateRadio.SetValue(Grid.ColumnProperty, (object) 0);
      this.buttonExit.SetValue(Grid.ColumnProperty, (object) 2);
      this.buttonExit.Width = 125.0;
      this.buttonHelp.SetValue(Grid.ColumnProperty, (object) 4);
      this.buttonHelp.Width = 125.0;
    }
    this.accessReadWriteDevice.readRadioComplete += new WindowMain.ReadRadioCompleted(this.accessReadWriteDevice_readRadioComplete);
    AccessRecord systemAccessLevel = SecurityManager.GetSystemAccessLevel(1, KeyType.ADVANCED_SYSTEM_KEY);
    SystemKeyData systemKeyData1 = new SystemKeyData(KeySource.HARDWARE, "0", 0, KeyType.NONE, false, false, (AccessRecord) null);
    SystemKeyData systemKeyData2 = new SystemKeyData(KeySource.HARDWARE, "0", 1, KeyType.ADVANCED_SYSTEM_KEY, false, false, systemAccessLevel);
    SystemKeyData systemKeyData3 = new SystemKeyData(KeySource.HARDWARE, "0", 0, KeyType.ADVANCED_WACN_KEY, false, false, (AccessRecord) null);
    this.attachedKeys = loadedAndAttachedASKs;
    foreach (SystemKeyData loadedAndAttachedAsK in loadedAndAttachedASKs)
    {
      if (loadedAndAttachedAsK.Type == KeyType.ADVANCED_SYSTEM_KEY && loadedAndAttachedAsK.SystemID == 1)
      {
        this.attachedKeys.Remove(loadedAndAttachedAsK);
        break;
      }
    }
    this.attachedASKs.Insert(0, systemKeyData3);
    this.attachedASKs.Insert(0, systemKeyData2);
    this.attachedASKs.Insert(0, systemKeyData1);
    foreach (SystemKeyData attachedKey in this.attachedKeys)
      this.attachedASKs.Add(attachedKey);
    if (Thread.CurrentThread.CurrentUICulture.TextInfo.IsRightToLeft)
      this.FlowDirection = FlowDirection.RightToLeft;
    else
      this.FlowDirection = FlowDirection.LeftToRight;
  }

  private void OnLoad(object sender, RoutedEventArgs e)
  {
    foreach (UIElement child in this.MyStackPanel.Children)
    {
      if (child is AcpExpander acpExpander)
        this.expanderlist.Add(acpExpander.Name, acpExpander);
    }
    this.ExpanderGeneral.Focus();
    this.SelectedKeyType.SelectedValue = (object) AppResources.None_Id;
    this.comboDlgOwnerSystemIDChoices.SelectedValue = (object) this.attachedASKs[0];
    this.boolDlgWriteProtect.IsEnabled = false;
    this.ribbonBarUpdateRadio.IsEnabled = false;
    if (!string.IsNullOrEmpty(this.parentWindowSettings.UserSelectedApplicationLanguage))
      this.initialLanguageSelection = this.parentWindowSettings.UserSelectedApplicationLanguage;
    else if (AppResources.Culture.Name.Contains("es"))
      this.initialLanguageSelection = AppResources.Culture.Name.Substring(0, 2);
    else
      this.initialLanguageSelection = AppResources.Culture.Name;
  }

  public ObservableCollection<SystemKeyData> AttachedSystemKeys
  {
    get => this.attachedASKs;
    set => this.attachedASKs = value;
  }

  public event PropertyChangedEventHandler PropertyChanged;

  internal void FireDataSourcePropertyChanged(string systemKeyData)
  {
    if (this.PropertyChanged == null)
      return;
    this.PropertyChanged((object) this, new PropertyChangedEventArgs(systemKeyData));
  }

  private void buttonQuery_Click(object sender, RoutedEventArgs e)
  {
    if (WriteProtect.readInProgress)
      return;
    this.UpdateControls(string.Empty, string.Empty, false);
    this.queryRadioBtnWasClicked = true;
    if (this.keysFromRadio != null)
      this.keysFromRadio.Clear();
    if (this.attachedKeys != null)
      this.attachedKeys.Clear();
    try
    {
      this.attachedKeys = SecurityManager.GetSysKeysFromLoadedAndAttachedASKs();
      AccessRecord systemAccessLevel = SecurityManager.GetSystemAccessLevel(1, KeyType.ADVANCED_SYSTEM_KEY);
      if (this.attachedKeys != null && this.attachedKeys.Count > 0)
      {
        SystemKeyData systemKeyData1 = new SystemKeyData(KeySource.HARDWARE, "0", 0, KeyType.NONE, false, false, (AccessRecord) null);
        SystemKeyData systemKeyData2 = new SystemKeyData(KeySource.HARDWARE, "0", 1, KeyType.ADVANCED_SYSTEM_KEY, false, false, systemAccessLevel);
        this.attachedKeys.Insert(0, new SystemKeyData(KeySource.HARDWARE, "0", 0, KeyType.ADVANCED_WACN_KEY, false, false, (AccessRecord) null));
        this.attachedKeys.Insert(0, systemKeyData2);
        this.attachedKeys.Insert(0, systemKeyData1);
        if (this.attachedASKs != null)
          this.attachedASKs.Clear();
        foreach (SystemKeyData attachedKey in this.attachedKeys)
          this.attachedASKs.Add(attachedKey);
        if (this.attachedASKs == null || this.attachedASKs.Count <= 0)
          return;
        if (this.openFromRMC)
        {
          this.getRadioDataForQueryRadioOperationFromRMC();
        }
        else
        {
          this.readTransportValue = this.accessReadWriteDevice.ReadWriteTransport;
          this.accessReadWriteDevice.ReadWriteTransport = 0;
          AppInfoManager.StatusMsgReport.Clear();
          this.accessReadWriteDevice.ReadWriteInProgress = true;
          if (!this.accessReadWriteDevice.progressPage.bCommSuccess)
          {
            this.accessReadWriteDevice.progressPage.Hide();
            this.accessReadWriteDevice.progressPage.Close();
          }
          this.accessReadWriteDevice.progressPage = new ProgressUpdate();
          this.accessReadWriteDevice.progressPage.ClearStatus();
          this.accessReadWriteDevice.progressPage.Title = AppResources.Read_Radio;
          if (!(bool) Application.Current.Properties[(object) "CommandLineCPS"])
            this.accessReadWriteDevice.progressPage.Show();
          if (AppInfoManager.AppView == DifferentiatedUserViewType.Custom)
          {
            this.accessReadWriteDevice.SavedCurrentViewType = DifferentiatedUserViewType.Custom;
            AppInfoManager.AppView = DifferentiatedUserViewType.Full;
          }
          this.accessReadWriteDevice.DocumentOperations.InitDocument();
          ((App) Application.Current).TheDocument.FileNew();
          UndoManager.StopUndoRedo();
          UndoManager.Reset();
          ConstraintManager.Suspend();
          this.accessReadWriteDevice.bgReadWorker = new BackgroundWorker();
          this.accessReadWriteDevice.bgReadWorker.DoWork += (DoWorkEventHandler) ((s, arg) => this.accessReadWriteDevice.LaunchReadRadio((int) arg.Argument));
          this.accessReadWriteDevice.bgReadWorker.RunWorkerAsync((object) 0);
        }
      }
      else
      {
        this.UpdateControls(string.Empty, AppResources.Advanced_key_not_loaded_and_attached, true);
        this.queryRadioBtnWasClicked = false;
      }
    }
    catch
    {
      this.UpdateControls(string.Empty, AppResources.Query_radio_data_failed, true);
      this.queryRadioBtnWasClicked = false;
    }
    finally
    {
      if (this.accessReadWriteDevice.CpgOpenFlag && !this.openFromRMC)
        this.accessReadWriteDevice.OnAppMenuClose((object) null, (RoutedEventArgs) null);
    }
  }

  private void buttonExit_Click(object sender, RoutedEventArgs e) => ((Window) this.Parent).Close();

  private void buttonUpdate_Click(object sender, RoutedEventArgs e)
  {
    if (WriteProtect.readInProgress)
      return;
    if (!this.openFromRMC)
      this.UpdateControls(AppResources.ID_UPDATING, AppResources.ID_DONOTDISCONNECT, false);
    else
      this.UpdateControls(string.Empty, string.Empty, false);
    this.updateRadioDataBtnWasClicked = true;
    try
    {
      this.attachedKeys = SecurityManager.GetSysKeysFromLoadedAndAttachedASKs();
      this.attachedKeys.Add(new SystemKeyData(KeySource.HARDWARE, "0", 1, KeyType.ADVANCED_SYSTEM_KEY, false, false, SecurityManager.GetSystemAccessLevel(1, KeyType.ADVANCED_SYSTEM_KEY)));
      if (this.attachedKeys != null && this.attachedKeys.Count > 0)
      {
        bool flag = false;
        foreach (SystemKeyData attachedKey in this.attachedKeys)
        {
          if (attachedKey.SystemID == ((SystemKeyData) this.comboDlgOwnerSystemIDChoices.SelectedItem).SystemID && attachedKey.Type == ((SystemKeyData) this.comboDlgOwnerSystemIDChoices.SelectedItem).Type)
            flag = true;
        }
        if (flag)
        {
          if (this.openFromRMC)
          {
            this.writeDataForUpdateRadioDataOperationFromRMC();
          }
          else
          {
            this.readTransportValue = this.accessReadWriteDevice.ReadWriteTransport;
            this.accessReadWriteDevice.ReadWriteTransport = 0;
            AppInfoManager.StatusMsgReport.Clear();
            this.accessReadWriteDevice.ReadWriteInProgress = true;
            if (!this.accessReadWriteDevice.progressPage.bCommSuccess)
            {
              this.accessReadWriteDevice.progressPage.Hide();
              this.accessReadWriteDevice.progressPage.Close();
            }
            this.accessReadWriteDevice.progressPage = new ProgressUpdate();
            this.accessReadWriteDevice.progressPage.ClearStatus();
            this.accessReadWriteDevice.progressPage.Title = AppResources.Read_Radio;
            if (!(bool) Application.Current.Properties[(object) "CommandLineCPS"])
              this.accessReadWriteDevice.progressPage.Show();
            if (AppInfoManager.AppView == DifferentiatedUserViewType.Custom)
            {
              this.accessReadWriteDevice.SavedCurrentViewType = DifferentiatedUserViewType.Custom;
              AppInfoManager.AppView = DifferentiatedUserViewType.Full;
            }
            this.accessReadWriteDevice.DocumentOperations.InitDocument();
            ((App) Application.Current).TheDocument.FileNew();
            UndoManager.StopUndoRedo();
            UndoManager.Reset();
            ConstraintManager.Suspend();
            this.accessReadWriteDevice.bgReadWorker = new BackgroundWorker();
            this.accessReadWriteDevice.bgReadWorker.DoWork += (DoWorkEventHandler) ((s, arg) => this.accessReadWriteDevice.LaunchReadRadio((int) arg.Argument));
            this.accessReadWriteDevice.bgReadWorker.RunWorkerAsync((object) 0);
          }
        }
        else
        {
          this.UpdateControls(string.Empty, AppResources.Key_check_for_owner_system_ID, true);
          this.updateRadioDataBtnWasClicked = false;
        }
      }
      else
      {
        this.UpdateControls(string.Empty, AppResources.Advanced_key_not_loaded_and_attached, true);
        this.updateRadioDataBtnWasClicked = false;
      }
    }
    catch
    {
      this.UpdateControls(string.Empty, AppResources.Update_radio_data_failed, true);
      this.updateRadioDataBtnWasClicked = false;
    }
    finally
    {
      if (this.accessReadWriteDevice.CpgOpenFlag && !this.openFromRMC)
        this.accessReadWriteDevice.OnAppMenuClose((object) null, (RoutedEventArgs) null);
    }
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
      ACPBrowser.Utility.DisplayCPSHelpDITA("#950dc49d");
    }
    catch (Exception ex)
    {
    }
  }

  private void SelectedKeyType_SelectionChanged(object sender, SelectionChangedEventArgs e)
  {
    string str = "";
    if (this.SelectedKeyType.SelectedValue != null)
      str = this.SelectedKeyType.SelectedValue.ToString();
    if (str == AppResources.None_Id)
      this.comboDlgOwnerSystemIDChoices.SelectedValue = (object) this.attachedASKs[0];
    else if (str == AppResources.Adv_System_Key_Column_Header_ID)
      this.comboDlgOwnerSystemIDChoices.SelectedValue = (object) this.attachedASKs[1];
    else if (str == AppResources.Adv_WACN_Key_Column_Header_ID)
      this.comboDlgOwnerSystemIDChoices.SelectedValue = (object) this.attachedASKs[2];
    if (!this.accessReadWriteDevice.CpgOpenFlag && !this.queryRadioBtnWasClicked)
    {
      this.attachedASKs.Remove(this.sysKeyDataFromRadio);
      this.keysFromRadio.Remove(this.sysKeyDataFromRadio);
      this.FireDataSourcePropertyChanged("AttachedSystemKeys");
    }
    if (!this.accessReadWriteDevice.CpgOpenFlag && !this.queryRadioBtnWasClicked)
    {
      this.attachedASKs.Remove(this.sysKeyDataFromRadio);
      this.keysFromRadio.Remove(this.sysKeyDataFromRadio);
      this.FireDataSourcePropertyChanged("AttachedSystemKeys");
    }
    if (str == AppResources.Adv_System_Key_Column_Header_ID)
    {
      this.boolDlgWriteProtect.IsEnabled = false;
      this.ribbonBarUpdateRadio.IsEnabled = true;
    }
    else
    {
      this.boolDlgWriteProtect.IsEnabled = false;
      this.ribbonBarUpdateRadio.IsEnabled = false;
    }
  }

  private void OwnerSystemID_SelectionChanged(object sender, SelectionChangedEventArgs e)
  {
    if (this.comboDlgOwnerSystemIDChoices.SelectedValue != null)
    {
      if (!this.queryRadioBtnWasClicked)
        this.boolDlgWriteProtect.Value = false;
      if (((SystemKeyData) this.comboDlgOwnerSystemIDChoices.SelectedValue).SystemID == 0)
      {
        this.boolDlgWriteProtect.IsEnabled = false;
        this.ribbonBarUpdateRadio.IsEnabled = false;
      }
      else if (((SystemKeyData) this.comboDlgOwnerSystemIDChoices.SelectedValue).SystemID == 1)
      {
        this.boolDlgWriteProtect.IsEnabled = false;
        this.ribbonBarUpdateRadio.IsEnabled = true;
      }
      else
      {
        this.boolDlgWriteProtect.IsEnabled = true;
        this.ribbonBarUpdateRadio.IsEnabled = true;
      }
    }
    else
    {
      this.boolDlgWriteProtect.IsEnabled = false;
      this.ribbonBarUpdateRadio.IsEnabled = false;
    }
  }

  private void accessReadWriteDevice_readRadioComplete(bool status)
  {
    this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Delegate) new WindowMain.ReadRadioCompleted(this.getRadioDataForQueryRadioOperation), (object) status);
    this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Delegate) new WindowMain.ReadRadioCompleted(this.writeDataForUpdateRadioDataOperation), (object) status);
  }

  private void getRadioDataForQueryRadioOperation(bool status)
  {
    string strFooterMessage = string.Empty;
    if (!this.queryRadioBtnWasClicked)
      return;
    try
    {
      if (status)
      {
        this.accessReadWriteDevice.ReadWriteTransport = this.readTransportValue;
        Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation radioInformation = FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation;
        if (!RadioOperationValidator.IsRadioConvOnly(radioInformation.General.RadInfoGeneralModelNumber_A8539Value, radioInformation.FLASHport.RadInfoFLASHportFLASHcode_A8132Value, false))
        {
          if (radioInformation.Labtool.RadInfoLabtoolQA01648ASKEnable_A37150Value)
          {
            Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide radioWide = FeatureManager.GetFeature(2045)[0] as Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide;
            string uiValue = radioWide.General.RadWideGeneralOwnerAdvancedKeyType_A38663.UIValue;
            this.boolDlgWriteProtect.IsChecked = new bool?(radioWide.Depot.AdvancedExternalMicOnlyValue && radioWide.General.RadWideGeneralASKRequired_A37152Value);
            if (uiValue == AcgResources.ID_ADVANCEDSYSTEMKEY)
              this.sysKeyDataFromRadio = new SystemKeyData(KeySource.HARDWARE, "0", radioWide.General.RadWideGeneralOwnerSystemID_A37153Value, KeyType.ADVANCED_SYSTEM_KEY, false, false, (AccessRecord) null);
            else if (uiValue == AcgResources.ID_ADVANCEDWACNKEY)
              this.sysKeyDataFromRadio = new SystemKeyData(KeySource.HARDWARE, "0", radioWide.General.RadWideGeneralOwnerWACNID_A38656Value, KeyType.ADVANCED_WACN_KEY, false, false, (AccessRecord) null);
            bool flag = false;
            SystemKeyData systemKeyData1 = new SystemKeyData(KeySource.HARDWARE, "0", 0, KeyType.NONE, false, false, (AccessRecord) null);
            foreach (SystemKeyData attachedAsK in (Collection<SystemKeyData>) this.attachedASKs)
            {
              if (attachedAsK.Type == this.sysKeyDataFromRadio.Type && attachedAsK.SystemIDHex == this.sysKeyDataFromRadio.SystemIDHex)
              {
                flag = true;
                systemKeyData1 = attachedAsK;
                break;
              }
            }
            if (!flag)
            {
              this.attachedASKs.Add(this.sysKeyDataFromRadio);
              this.keysFromRadio.Add(this.sysKeyDataFromRadio);
              this.FireDataSourcePropertyChanged("AttachedSystemKeys");
              if (this.sysKeyDataFromRadio.Type == KeyType.ADVANCED_SYSTEM_KEY)
                this.SelectedKeyType.SelectedValue = (object) AppResources.Adv_System_Key_Column_Header_ID;
              else if (this.sysKeyDataFromRadio.Type == KeyType.ADVANCED_WACN_KEY)
                this.SelectedKeyType.SelectedValue = (object) AppResources.Adv_WACN_Key_Column_Header_ID;
              this.comboDlgOwnerSystemIDChoices.SelectedIndex = this.comboDlgOwnerSystemIDChoices.Items.Count - 1;
            }
            else
            {
              if (systemKeyData1.Type == KeyType.ADVANCED_SYSTEM_KEY)
                this.SelectedKeyType.SelectedValue = (object) AppResources.Adv_System_Key_Column_Header_ID;
              else if (systemKeyData1.Type == KeyType.ADVANCED_WACN_KEY)
                this.SelectedKeyType.SelectedValue = (object) AppResources.Adv_WACN_Key_Column_Header_ID;
              int num = -1;
              foreach (SystemKeyData systemKeyData2 in (IEnumerable) this.comboDlgOwnerSystemIDChoices.Items)
              {
                if (systemKeyData2.SystemID == systemKeyData1.SystemID && systemKeyData2.Type == systemKeyData1.Type)
                  num = this.comboDlgOwnerSystemIDChoices.Items.IndexOf((object) systemKeyData2);
              }
              this.comboDlgOwnerSystemIDChoices.SelectedIndex = num;
            }
          }
          else
            strFooterMessage = AppResources.Legacy_check_for_owner_system_ID;
        }
        else
          strFooterMessage = AppResources.Cnv_check_for_owner_system_ID;
      }
      else
        strFooterMessage = AppResources.Query_radio_data_failed;
    }
    catch
    {
      strFooterMessage = AppResources.Query_radio_data_failed;
    }
    finally
    {
      if (this.accessReadWriteDevice.CpgOpenFlag)
        this.accessReadWriteDevice.OnAppMenuClose((object) null, (RoutedEventArgs) null);
      this.UpdateControls(string.Empty, strFooterMessage, true);
      this.queryRadioBtnWasClicked = false;
    }
  }

  private void getRadioDataForQueryRadioOperationFromRMC()
  {
    string strFooterMessage = string.Empty;
    if (!this.queryRadioBtnWasClicked)
      return;
    try
    {
      ASTRORadio device = this.devices[0];
      if (!RadioOperationValidator.IsRadioConvOnly(device.ModelNumber, device.AstroPurchasedFlashCode, false))
      {
        string empty = string.Empty;
        Radio radioByDeviceUuid = ServerAccessor.GetInstance().GetRadioByDeviceUuid(device.DeviceUuid);
        APXCodeplug codeplug = ServerAccessor.GetInstance().GetCodeplug(radioByDeviceUuid.WorkingCodeplugUuid.Value) as APXCodeplug;
        int? ownerAdvKeyType = codeplug.OwnerAdvKeyType;
        int num1 = 0;
        string str = !(ownerAdvKeyType.GetValueOrDefault() == num1 & ownerAdvKeyType.HasValue) ? AcgResources.ID_ADVANCEDWACNKEY : AcgResources.ID_ADVANCEDSYSTEMKEY;
        this.boolDlgWriteProtect.IsChecked = codeplug.DisableWriteProtect;
        if (str == AcgResources.ID_ADVANCEDSYSTEMKEY)
          this.sysKeyDataFromRadio = new SystemKeyData(KeySource.HARDWARE, "0", codeplug.HomeSystemId.Value, KeyType.ADVANCED_SYSTEM_KEY, false, false, (AccessRecord) null);
        else if (str == AcgResources.ID_ADVANCEDWACNKEY)
          this.sysKeyDataFromRadio = new SystemKeyData(KeySource.HARDWARE, "0", codeplug.OwnerWacnId.Value, KeyType.ADVANCED_WACN_KEY, false, false, (AccessRecord) null);
        bool flag = false;
        SystemKeyData systemKeyData1 = new SystemKeyData(KeySource.HARDWARE, "0", 0, KeyType.NONE, false, false, (AccessRecord) null);
        foreach (SystemKeyData attachedAsK in (Collection<SystemKeyData>) this.attachedASKs)
        {
          if (attachedAsK.Type == this.sysKeyDataFromRadio.Type && attachedAsK.SystemIDHex == this.sysKeyDataFromRadio.SystemIDHex)
          {
            flag = true;
            systemKeyData1 = attachedAsK;
            break;
          }
        }
        if (!flag)
        {
          this.attachedASKs.Add(this.sysKeyDataFromRadio);
          this.keysFromRadio.Add(this.sysKeyDataFromRadio);
          this.FireDataSourcePropertyChanged("AttachedSystemKeys");
          if (this.sysKeyDataFromRadio.Type == KeyType.ADVANCED_SYSTEM_KEY)
            this.SelectedKeyType.SelectedValue = (object) AppResources.Adv_System_Key_Column_Header_ID;
          else if (this.sysKeyDataFromRadio.Type == KeyType.ADVANCED_WACN_KEY)
            this.SelectedKeyType.SelectedValue = (object) AppResources.Adv_WACN_Key_Column_Header_ID;
          this.comboDlgOwnerSystemIDChoices.SelectedIndex = this.comboDlgOwnerSystemIDChoices.Items.Count - 1;
        }
        else
        {
          if (systemKeyData1.Type == KeyType.ADVANCED_SYSTEM_KEY)
            this.SelectedKeyType.SelectedValue = (object) AppResources.Adv_System_Key_Column_Header_ID;
          else if (systemKeyData1.Type == KeyType.ADVANCED_WACN_KEY)
            this.SelectedKeyType.SelectedValue = (object) AppResources.Adv_WACN_Key_Column_Header_ID;
          int num2 = -1;
          foreach (SystemKeyData systemKeyData2 in (IEnumerable) this.comboDlgOwnerSystemIDChoices.Items)
          {
            if (systemKeyData2.SystemID == systemKeyData1.SystemID && systemKeyData2.Type == systemKeyData1.Type)
              num2 = this.comboDlgOwnerSystemIDChoices.Items.IndexOf((object) systemKeyData2);
          }
          this.comboDlgOwnerSystemIDChoices.SelectedIndex = num2;
        }
      }
      else
        strFooterMessage = AppResources.Cnv_check_for_owner_system_ID;
    }
    catch (Exception ex)
    {
      strFooterMessage = $"{AppResources.Query_Radio_Failed}  {ex.Message}";
    }
    finally
    {
      this.UpdateControls(string.Empty, strFooterMessage, true);
      this.queryRadioBtnWasClicked = false;
    }
  }

  private void writeDataForUpdateRadioDataOperation(bool status)
  {
    string strFooterMessage = string.Empty;
    bool flag = false;
    if (!this.updateRadioDataBtnWasClicked)
      return;
    try
    {
      if (status)
      {
        this.accessReadWriteDevice.ReadWriteTransport = this.readTransportValue;
        Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation radioInformation = FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation;
        if (!RadioOperationValidator.IsRadioConvOnly(radioInformation.General.RadInfoGeneralModelNumber_A8539Value, radioInformation.FLASHport.RadInfoFLASHportFLASHcode_A8132Value, false))
        {
          if (radioInformation.Labtool.RadInfoLabtoolQA01648ASKEnable_A37150Value)
          {
            Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide radioWide = FeatureManager.GetFeature(2045)[0] as Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide;
            SystemKeyData outASK = new SystemKeyData(KeySource.HARDWARE, "0", 0, KeyType.NONE, false, false, (AccessRecord) null);
            KeyType keyTypeA38663Value = (KeyType) radioWide.General.RadWideGeneralOwnerAdvancedKeyType_A38663Value;
            int homeSysId = 0;
            switch (keyTypeA38663Value)
            {
              case KeyType.ADVANCED_SYSTEM_KEY:
                homeSysId = radioWide.General.RadWideGeneralOwnerSystemID_A37153Value;
                break;
              case KeyType.ADVANCED_WACN_KEY:
                homeSysId = radioWide.General.RadWideGeneralOwnerWACNID_A38656Value;
                break;
            }
            if (RadioAccessValidatorBase.CheckIfOwnerASKIsAttached(homeSysId, keyTypeA38663Value, this.attachedKeys, out outASK))
            {
              if (outASK.AccessLevelType == KeyAccessLevelType.UNLM_ACC || outASK.AccessLevelType == KeyAccessLevelType.UNLM_ACC_WITHOUT_WP)
              {
                if (this.SelectedKeyType.SelectedValue.ToString() == AppResources.Adv_System_Key_Column_Header_ID)
                {
                  radioWide.General.RadWideGeneralOwnerAdvancedKeyType_A38663.SetValue(0);
                  radioWide.General.RadWideGeneralOwnerSystemID_A37153.SetValue(((SystemKeyData) this.comboDlgOwnerSystemIDChoices.SelectedValue).SystemID);
                }
                else if (this.SelectedKeyType.SelectedValue.ToString() == AppResources.Adv_WACN_Key_Column_Header_ID)
                {
                  radioWide.General.RadWideGeneralOwnerAdvancedKeyType_A38663.SetValue(1);
                  radioWide.General.RadWideGeneralOwnerWACNID_A38656.SetValue(((SystemKeyData) this.comboDlgOwnerSystemIDChoices.SelectedValue).SystemID);
                }
                bool? isChecked;
                if (!radioWide.Depot.AdvancedExternalMicOnly.Value)
                {
                  isChecked = this.boolDlgWriteProtect.IsChecked;
                  if (isChecked.Value)
                  {
                    AcpField<bool> advancedExternalMicOnly = radioWide.Depot.AdvancedExternalMicOnly;
                    isChecked = this.boolDlgWriteProtect.IsChecked;
                    int num = isChecked.Value ? 1 : 0;
                    advancedExternalMicOnly.SetValue(num != 0);
                  }
                }
                AcpField<bool> askRequiredA37152 = radioWide.General.RadWideGeneralASKRequired_A37152;
                isChecked = this.boolDlgWriteProtect.IsChecked;
                int num1 = isChecked.Value ? 1 : 0;
                askRequiredA37152.SetValue(num1 != 0);
                if (!this.accessReadWriteDevice.SaveCodeplug())
                  return;
                this.accessReadWriteDevice.bgWriteWorker = new BackgroundWorker();
                this.accessReadWriteDevice.bgWriteWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bgWriteWorker_RunWorkerCompleted);
                int nTxPort = this.accessReadWriteDevice.ReadWriteTransport;
                this.accessReadWriteDevice.bgWriteWorker.DoWork += (DoWorkEventHandler) ((s, arg) =>
                {
                  Thread.Sleep(10000);
                  this.accessReadWriteDevice.LaunchWriteRadio(nTxPort, true);
                });
                this.accessReadWriteDevice.bgWriteWorker.RunWorkerAsync((object) 0);
              }
              else
              {
                strFooterMessage = AppResources.Unlimited_key_check_for_radio_owner_system_ID;
                flag = true;
              }
            }
            else
            {
              strFooterMessage = AppResources.Unlimited_key_check_for_radio_owner_system_ID;
              flag = true;
            }
          }
          else
          {
            strFooterMessage = AppResources.Legacy_check_for_owner_system_ID;
            flag = true;
          }
        }
        else
        {
          strFooterMessage = AppResources.Cnv_check_for_owner_system_ID;
          flag = true;
        }
      }
      else
      {
        strFooterMessage = AppResources.Update_radio_data_failed;
        flag = true;
      }
    }
    catch
    {
      strFooterMessage = AppResources.Update_radio_data_failed;
      flag = true;
    }
    finally
    {
      if (flag)
      {
        if (this.accessReadWriteDevice.CpgOpenFlag)
          this.accessReadWriteDevice.OnAppMenuClose((object) null, (RoutedEventArgs) null);
        this.UpdateControls(string.Empty, strFooterMessage, true);
      }
      this.updateRadioDataBtnWasClicked = false;
    }
  }

  private void writeDataForUpdateRadioDataOperationFromRMC()
  {
    string strFooterMessage = string.Empty;
    bool flag = false;
    ASTRORadio astroRadio1 = (ASTRORadio) null;
    if (!this.updateRadioDataBtnWasClicked)
      return;
    try
    {
      for (int index = 0; index < this.devices.Count; ++index)
      {
        astroRadio1 = this.devices[index];
        if (!RadioOperationValidator.IsRadioConvOnly(astroRadio1.ModelNumber, astroRadio1.AstroPurchasedFlashCode, false))
        {
          SystemKeyData outASK = new SystemKeyData(KeySource.HARDWARE, "0", 0, KeyType.NONE, false, false, (AccessRecord) null);
          Radio radioByDeviceUuid = ServerAccessor.GetInstance().GetRadioByDeviceUuid(astroRadio1.DeviceUuid);
          APXCodeplug codeplug = ServerAccessor.GetInstance().GetCodeplug(radioByDeviceUuid.WorkingCodeplugUuid.Value) as APXCodeplug;
          int? nullable1 = codeplug.OwnerAdvKeyType;
          KeyType homeKeyType = (KeyType) nullable1.Value;
          int homeSysId = 0;
          switch (homeKeyType)
          {
            case KeyType.ADVANCED_SYSTEM_KEY:
              nullable1 = codeplug.HomeSystemId;
              homeSysId = nullable1.Value;
              break;
            case KeyType.ADVANCED_WACN_KEY:
              nullable1 = codeplug.OwnerWacnId;
              homeSysId = nullable1.Value;
              break;
          }
          if (RadioAccessValidatorBase.CheckIfOwnerASKIsAttached(homeSysId, homeKeyType, this.attachedKeys, out outASK))
          {
            if (outASK.AccessLevelType == KeyAccessLevelType.UNLM_ACC || outASK.AccessLevelType == KeyAccessLevelType.UNLM_ACC_WITHOUT_WP)
            {
              if (this.SelectedKeyType.SelectedValue.ToString() == AppResources.Adv_System_Key_Column_Header_ID)
              {
                codeplug.OwnerAdvKeyType = new int?(0);
                codeplug.HomeSystemId = new int?(((SystemKeyData) this.comboDlgOwnerSystemIDChoices.SelectedValue).SystemID);
              }
              else if (this.SelectedKeyType.SelectedValue.ToString() == AppResources.Adv_WACN_Key_Column_Header_ID)
              {
                codeplug.OwnerAdvKeyType = new int?(1);
                codeplug.OwnerWacnId = new int?(((SystemKeyData) this.comboDlgOwnerSystemIDChoices.SelectedValue).SystemID);
              }
              bool? nullable2 = codeplug.DisableWriteProtect;
              if (!nullable2.Value)
              {
                nullable2 = this.boolDlgWriteProtect.IsChecked;
                if (nullable2.Value)
                {
                  APXCodeplug apxCodeplug = codeplug;
                  nullable2 = this.boolDlgWriteProtect.IsChecked;
                  bool? nullable3 = new bool?(nullable2.Value);
                  apxCodeplug.DisableWriteProtect = nullable3;
                }
              }
              APXCodeplug apxCodeplug1 = codeplug;
              nullable2 = this.boolDlgWriteProtect.IsChecked;
              bool? nullable4 = new bool?(nullable2.Value);
              apxCodeplug1.AskRequired = nullable4;
              ASTRORadio astroRadio2 = astroRadio1;
              nullable2 = codeplug.AskRequired;
              int num = nullable2.Value ? 1 : 0;
              astroRadio2.AskRequired = num != 0;
            }
            else
            {
              strFooterMessage = AppResources.Unlimited_key_check_for_radio_owner_system_ID;
              flag = true;
            }
          }
          else
          {
            strFooterMessage = AppResources.Unlimited_key_check_for_radio_owner_system_ID;
            flag = true;
          }
        }
        else
        {
          strFooterMessage = AppResources.Cnv_check_for_owner_system_ID;
          flag = true;
        }
      }
    }
    catch (Exception ex)
    {
      strFooterMessage = $"{AppResources.Update_Radio_Failed}  {ex.Message}";
      flag = true;
    }
    finally
    {
      if (!flag)
      {
        strFooterMessage = AppResources.Changes_Saved;
        astroRadio1.ChangeIndicator = 1;
        astroRadio1.RadioStatus = RadioStatus.Modified;
      }
      this.UpdateControls(string.Empty, strFooterMessage, true);
      this.updateRadioDataBtnWasClicked = false;
    }
  }

  private void bgWriteWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
  {
    if (this.accessReadWriteDevice.CpgOpenFlag)
      this.accessReadWriteDevice.OnAppMenuClose((object) null, (RoutedEventArgs) null);
    this.UpdateControls(string.Empty, string.Empty, true);
  }

  private void UpdateControls(string strLblMessage, string strFooterMessage, bool bEnable)
  {
    this.ribbonBarQueryRadio.IsEnabled = bEnable;
    this.ribbonBarUpdateRadio.IsEnabled = bEnable;
    this.buttonExit.IsEnabled = bEnable;
    WriteProtect.readInProgress = !bEnable;
    this.acplblWarning.Content = (object) strLblMessage;
    this.TxtBlkOutput.Text = strFooterMessage;
  }

  private void HLinkGeneralClick(object sender, RoutedEventArgs e)
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
    Application.LoadComponent((object) this, new Uri("/APXFamilyCPS;component/writeprotect.xaml", UriKind.Relative));
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
        this.HLinkGeneral = (Hyperlink) target;
        this.HLinkGeneral.Click += new RoutedEventHandler(this.HLinkGeneralClick);
        break;
      case 5:
        this.MyGrid = (Grid) target;
        break;
      case 6:
        this.ribbonBarQueryRadio = (Button) target;
        this.ribbonBarQueryRadio.Click += new RoutedEventHandler(this.buttonQuery_Click);
        break;
      case 7:
        this.ribbonBarUpdateRadio = (Button) target;
        this.ribbonBarUpdateRadio.Click += new RoutedEventHandler(this.buttonUpdate_Click);
        break;
      case 8:
        this.buttonExit = (Button) target;
        this.buttonExit.Click += new RoutedEventHandler(this.buttonExit_Click);
        break;
      case 9:
        this.buttonHelp = (Button) target;
        this.buttonHelp.Click += new RoutedEventHandler(this.onHelpButton_Click);
        break;
      case 10:
        this.MyStackPanel = (StackPanel) target;
        break;
      case 11:
        this.ExpanderGeneral = (AcpExpander) target;
        break;
      case 12:
        this.label1 = (AcpLabel) target;
        break;
      case 13:
        this.label3 = (AcpLabel) target;
        break;
      case 14:
        this.LblGeneralKeyType = (AcpLabel) target;
        break;
      case 15:
        this.SelectedKeyType = (ComboBox) target;
        this.SelectedKeyType.SelectionChanged += new SelectionChangedEventHandler(this.SelectedKeyType_SelectionChanged);
        break;
      case 16 /*0x10*/:
        this.LblDlgOwnerSystemID = (AcpLabel) target;
        break;
      case 17:
        this.comboDlgOwnerSystemIDChoices = (ComboBox) target;
        this.comboDlgOwnerSystemIDChoices.SelectionChanged += new SelectionChangedEventHandler(this.OwnerSystemID_SelectionChanged);
        break;
      case 18:
        this.LblDlgWriteProtect = (AcpLabel) target;
        break;
      case 19:
        this.boolDlgWriteProtect = (AcpCheckBox) target;
        break;
      case 20:
        this.acplblWarning = (AcpLabel) target;
        break;
      case 21:
        this.TxtBlkOutput = (TextBlock) target;
        break;
      default:
        this._contentLoaded = true;
        break;
    }
  }
}
