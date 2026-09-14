// Decompiled with JetBrains decompiler
// Type: MackinawCPS.PageTreeView
// Assembly: APXFamilyCPS, Version=36.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 9359335E-041C-4B12-9409-F4E6E7D93299
// Assembly location: C:\Program Files (x86)\Motorola\ApxFamilyCPS R36.00\APXFamilyCPS1.exe

using AcpBusinessLayer;
using AcpCommonLib;
using AcpCommonLib.UndoRedo;
using AcpCommonResources;
using AcpFileHandlerLib;
using AcpUI;
using AcpUI.DragDrop;
using AllFeatures;
using CommonResources;
using ConstraintHelper;
using Motorola.MackinawCPS.CoreFeatures.ControlHeadO9;
using Motorola.MackinawCPS.CoreFeatures.DEK;
using Motorola.MackinawCPS.CoreFeatures.RadioInformation;
using Motorola.MackinawCPS.CoreFeatures.SecureKMFProfile;
using SpecialFeatures.DVRSFiles;
using SpecialFeatures.DVRSFiles.List;
using SpecialFeatures.SystemCertificates.List;
using SpecialFeatures.VoiceAnnouncements.List;
using System;
using System.CodeDom.Compiler;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;

#nullable disable
namespace MackinawCPS;

public partial class PageTreeView : Page, IComponentConnector
{
  private WindowMain winMain = (WindowMain) Application.Current.MainWindow;
  private bool PgLoaded;
  private IAcpFeatureNode copyNode;
  private ContextMenu cntxMenu;
  private MenuItem mItemAdd;
  private MenuItem mItemDelete;
  private MenuItem mItemCopy;
  private MenuItem mItemPaste;
  private bool mCanPaste;
  private bool bRecordOpPerformed;
  internal AcpTreeViewItem preSelectedItem;
  private string[] voiceAnnFiles;
  private string[] systemCertificateFiles;
  internal AppTreeView MyTreeView;
  internal AcpTreeViewItem myTreeViewItemRoot;
  private bool _contentLoaded;

  public Func<SelectionMode, System.Collections.Generic.List<string>> SelectVAFileDialog { get; set; }

  public PageTreeView()
  {
    this.InitializeComponent();
    this.InitializePageTreeView();
    AcpUI.Common.Utility.SetDirection((FrameworkElement) this);
    DragDropManager.SetDnDProcess((IAcpBatchOperation) this.winMain);
    if (AppInfoManager.AppMode == ApplicationMode.CodeplugConfigurationMode && this.MyTreeView.SelectedItem == null)
      this.MyTreeView.FindChildTreeViewItem((FeatureManager.GetFeature(2049) as RadioInformationRecset).RecsetId, 0).IsSelected = true;
    this.preSelectedItem = this.MyTreeView.SelectedItem as AcpTreeViewItem;
    this.PreviewMouseRightButtonUp += new MouseButtonEventHandler(this.TreeView_PreviewMouseRightButtonUp);
  }

  private void TreeViewRecordOperationEventHandler(
    object sender,
    NotifyCollectionChangedEventArgs e)
  {
    this.MyTreeView.OnTreeViewRecordOperation(sender as IAcpRecordset, e, (TreeView) this.MyTreeView);
  }

  private void ReferenceKeyChangedEventHandler(object sender, EventArgs e)
  {
    this.MyTreeView.OnReferenceKeyChanged(sender as IAcpFeatureNode, (TreeView) this.MyTreeView);
  }

  private void PageTreeView_KeyDown(object sender, KeyEventArgs e)
  {
    if (AppInfoManager.AppMode != ApplicationMode.CodeplugConfigurationMode)
      return;
    AcpTreeViewItem source = e.Source as AcpTreeViewItem;
    IAcpRecordset feature = FeatureManager.GetFeature(source.RecsetId);
    if (source.NodeId == -1 || source == this.myTreeViewItemRoot || feature.SingleInstance)
      return;
    if (source.NodeId != 0 && !feature.SingleInstance)
    {
      IAcpFeatureNode record = feature.NodeFromId(source.NodeId);
      if (e.Key == Key.Delete && feature.Count > 1)
        feature.RemoveRecordAt(feature.IndexOf(record));
      if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.C)
        this.copyNode = this.MyTreeView.CurrentRecord;
      if (Keyboard.Modifiers != ModifierKeys.Control || e.Key != Key.V)
        return;
      AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Info, string.Format(AppResources.Paste_Operation, (object) ((Recordset) this.copyNode.Parent).UIName));
    }
    else
    {
      if (source.NodeId != 0 || feature.SingleInstance || Keyboard.Modifiers != ModifierKeys.Control || e.Key != Key.V || this.copyNode == null)
        return;
      Recordset parent = (Recordset) this.copyNode.Parent;
      if (this.CanPaste(this.copyNode))
      {
        int num = ((Recordset) feature).AddCopyOf(feature.IndexOf(this.copyNode)) ? 1 : 0;
        this.FixForAstroOtarProfileGUID(feature);
        if (num == 0)
          AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Info, string.Format(AppResources.Paste_Operation, (object) parent.UIName));
        else
          this.MyTreeView.Focus();
      }
      else
        AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Info, string.Format(AcpResources.Unable_to_Add_Recs, (object) parent.UIName));
    }
  }

  private void PageTreeView_Loaded(object sender, RoutedEventArgs e)
  {
    this.PgLoaded = true;
    this.TriggerDEKAndO9TopButtonsConstraints();
  }

  private void TriggerDEKAndO9TopButtonsConstraints()
  {
    try
    {
      ((FeatureManager.GetFeature(2129) as DEKRecset)[0][10232].EmbeddedRecset as DEKButtonInnerRecset).CallConstraints();
      ControlHeadO9Recset feature = FeatureManager.GetFeature(4003) as ControlHeadO9Recset;
      (feature[0][10616].EmbeddedRecset as TopFunctionProgrammableButtonListInnerRecset).CallConstraints();
      if (feature[0][10618].EmbeddedRecset is BottomFunctionProgrammableButtonInnerRecset embeddedRecset1)
        embeddedRecset1.CalculateApplicability();
      if (!(feature[0][10609].EmbeddedRecset is DirectionalButtonsListInnerRecset embeddedRecset2))
        return;
      embeddedRecset2.CalculateApplicability();
    }
    catch (Exception ex)
    {
    }
  }

  private void PageTreeView_Unloaded(object sender, RoutedEventArgs e)
  {
    if (this.PgLoaded)
    {
      WindowMain mainWindow = (WindowMain) Application.Current.MainWindow;
      if (!mainWindow.CpgOpenFlag && !mainWindow.CustomViewOpenFlag)
        this.myTreeViewItemRoot.Items.Clear();
      this.PgLoaded = false;
    }
    this.DetachMenuItems();
  }

  private void AddFeatureNodeItems(AcpTreeViewItem treeViewItem, int featureId, string displayText)
  {
    IAcpRecordset feature;
    if (AppInfoManager.AppMode == ApplicationMode.CustomViewConfigurationMode)
    {
      feature = AppInfoManager.DefaultDocument.GetFeature(featureId);
      if (featureId == 2200)
        this.winMain.DocumentOperations.UclTemplateNodeInit();
    }
    else
      feature = FeatureManager.GetFeature(featureId);
    if (feature == null || feature.HiddenStatic)
      return;
    AcpTreeViewItem newItem1 = new AcpTreeViewItem();
    newItem1.Header = (object) displayText;
    newItem1.RecsetId = featureId;
    treeViewItem.Items.Add((object) newItem1);
    if (feature.SingleInstance || feature.HideRecordsFromTree)
    {
      newItem1.NodeId = 0;
    }
    else
    {
      newItem1.NodeId = 0;
      for (int index = 0; index < feature.Count; ++index)
      {
        AcpTreeViewItem newItem2 = new AcpTreeViewItem();
        newItem2.Header = (object) feature[index].ReferenceKey;
        if (feature.HasKeyField)
          newItem2.ReferenceKey = feature[index].ReferenceKey;
        newItem2.RecsetId = featureId;
        newItem2.NodeId = feature[index].NodeId;
        newItem1.Items.Add((object) newItem2);
      }
    }
    Recordset source = (Recordset) feature;
    CollectionView defaultView = (CollectionView) CollectionViewSource.GetDefaultView((object) source);
    source.CollectionChanged += new NotifyCollectionChangedEventHandler(this.TreeViewRecordOperationEventHandler);
    source.ReferenceKeyChanged += new EventHandler(this.ReferenceKeyChangedEventHandler);
    defaultView.CurrentChanged += new EventHandler(this.OnCollectionCurrentViewChanged);
    this.MyTreeView.RootNodes.Add(featureId, newItem1);
  }

  private void OnCollectionCurrentViewChanged(object sender, EventArgs e)
  {
    CollectionView collectionView = (CollectionView) sender;
    IAcpFeatureNode currentItem = (IAcpFeatureNode) collectionView.CurrentItem;
    if (currentItem == null)
      return;
    if (this.preSelectedItem.NodeId != 0)
      this.MyTreeView.CurrentRecord = currentItem;
    else
      this.MyTreeView.CurrentRecord = (IAcpFeatureNode) null;
    AcpTreeViewItem childTreeViewItem = this.MyTreeView.FindChildTreeViewItem(currentItem.Parent.RecsetId, currentItem.NodeId);
    if (childTreeViewItem == null)
      return;
    AcpPageFeature content = (AcpPageFeature) this.winMain.FrameCenterTop.NavigationService.Content;
    if (!(this.MyTreeView.SelectedItem is AcpTreeViewItem selectedItem) || selectedItem.NodeId == 0)
      return;
    this.MyTreeView.CurrentRecord = currentItem;
    childTreeViewItem.Focus();
    if (!(content.ToString() == "Motorola.MackinawCPS.CoreFeatures.ZoneChannelAssignment.PageZoneChannelAssignment"))
      return;
    AppMultiInstanceManager.ParentRecsetPosition = collectionView.CurrentPosition;
  }

  private void DetachMenuItems()
  {
    this.mItemAdd = (MenuItem) null;
    this.mItemDelete = (MenuItem) null;
    this.mItemCopy = (MenuItem) null;
    this.mItemPaste = (MenuItem) null;
    this.cntxMenu = (ContextMenu) null;
  }

  private void TreeView_PreviewMouseRightButtonUp(object sender, MouseButtonEventArgs e)
  {
    if (AppInfoManager.AppMode == ApplicationMode.CodeplugConfigurationMode)
    {
      if (e.Source is AcpTreeViewItem source)
        this.OnContextMenuOpening(source);
    }
    else
      this.DetachMenuItems();
    e.Handled = true;
  }

  private void OnContextMenuOpening(AcpTreeViewItem treeViewItem)
  {
    if (this.preSelectedItem == null)
      this.preSelectedItem = treeViewItem;
    IAcpRecordset feature = FeatureManager.GetFeature(treeViewItem.RecsetId);
    if (treeViewItem.NodeId == -1 || treeViewItem == this.myTreeViewItemRoot || feature.SingleInstance)
    {
      this.ContextMenu = (ContextMenu) null;
      this.DetachMenuItems();
    }
    else if (treeViewItem.NodeId == 0 && !feature.SingleInstance)
    {
      treeViewItem.IsSelected = true;
      treeViewItem.Focus();
      this.mItemAdd = new MenuItem();
      this.mItemAdd.Header = (object) AppResources.Add_ID;
      this.mItemDelete = (MenuItem) null;
      this.mItemCopy = (MenuItem) null;
      this.mItemPaste = new MenuItem();
      this.mItemPaste.Header = (object) AcpResources.Paste_Id;
      this.cntxMenu = new ContextMenu();
      this.cntxMenu.Items.Add((object) this.mItemAdd);
      this.cntxMenu.Items.Add((object) this.mItemPaste);
      if (feature.CounterToMax <= 0)
        this.mItemAdd.IsEnabled = false;
      else
        this.mItemAdd.IsEnabled = true;
      if (this.copyNode != null)
        this.mCanPaste = this.copyNode.Parent.RecsetId == treeViewItem.RecsetId && this.CanPaste(this.copyNode);
      if (!this.mCanPaste)
        ((UIElement) this.cntxMenu.Items[1]).IsEnabled = false;
      this.ContextMenu = this.cntxMenu;
      this.cntxMenu.IsOpen = true;
      this.mItemAdd.Click += new RoutedEventHandler(this.mItemAdd_Click);
      this.mItemPaste.Click += new RoutedEventHandler(this.mItemPaste_Click);
      this.cntxMenu.Closed += new RoutedEventHandler(this.OnContextMenuClosed);
    }
    else
    {
      if (treeViewItem.NodeId <= 0)
        return;
      treeViewItem.IsSelected = true;
      treeViewItem.Focus();
      this.mItemDelete = new MenuItem();
      this.mItemDelete.Header = (object) AcpResources.Delete_Id;
      this.mItemCopy = new MenuItem();
      this.mItemCopy.Header = (object) AcpResources.Copy_Id;
      this.mItemPaste = (MenuItem) null;
      this.cntxMenu = new ContextMenu();
      this.cntxMenu.Items.Add((object) this.mItemDelete);
      this.cntxMenu.Items.Add((object) this.mItemCopy);
      if (!this.CanDelete(treeViewItem))
        ((UIElement) this.cntxMenu.Items[0]).IsEnabled = false;
      if (!this.CanCopy(treeViewItem))
        ((UIElement) this.cntxMenu.Items[1]).IsEnabled = false;
      this.ContextMenu = this.cntxMenu;
      this.cntxMenu.IsOpen = true;
      this.mItemDelete.Click += new RoutedEventHandler(this.mItemDelete_Click);
      this.mItemCopy.Click += new RoutedEventHandler(this.mItemCopy_Click);
      this.cntxMenu.Closed += new RoutedEventHandler(this.OnContextMenuClosed);
    }
  }

  private void mItemAdd_Click(object sender, RoutedEventArgs e)
  {
    AcpTreeViewItem selectedItem = this.MyTreeView.SelectedItem as AcpTreeViewItem;
    IAcpRecordset feature1 = FeatureManager.GetFeature(selectedItem.RecsetId);
    VoiceAnnouncementListRecSet feature2 = FeatureManager.GetFeature(2300) as VoiceAnnouncementListRecSet;
    SystemCertificateListRecSet feature3 = FeatureManager.GetFeature(4228) as SystemCertificateListRecSet;
    DVRSFileListRecSet feature4 = FeatureManager.GetFeature(4234) as DVRSFileListRecSet;
    if (feature1 != null && feature1.RecsetId != feature2.RecsetId && feature1.RecsetId != feature3.RecsetId && feature1.RecsetId != feature4.RecsetId)
      ((Recordset) feature1).AddDefaultRecord();
    else if (feature1 != null && feature1.RecsetId == feature2.RecsetId)
    {
      AppInfoManager.LoadingVoiceData = true;
      string[] sourceArray = (string[]) null;
      try
      {
        if (this.SelectVAFileDialog != null)
        {
          System.Collections.Generic.List<string> stringList = this.SelectVAFileDialog(SelectionMode.Extended);
          if (stringList != null && stringList.Count > 0)
            sourceArray = stringList.ToArray();
        }
        else
        {
          AcpOpenFileDialog acpOpenFileDialog = new AcpOpenFileDialog();
          acpOpenFileDialog.Filter = "Motorola Voice Announcement files (*.mva)|*.mva";
          acpOpenFileDialog.MultiSelect = true;
          if (acpOpenFileDialog.ShowDialog().GetValueOrDefault())
            sourceArray = acpOpenFileDialog.FileNames;
        }
        if (sourceArray != null)
        {
          if (sourceArray.Length != 0)
          {
            this.voiceAnnFiles = new string[sourceArray.Length];
            Array.Copy((Array) sourceArray, (Array) this.voiceAnnFiles, sourceArray.Length);
            VoiceAnnouncementListRecSet.vaCount = 0;
            VoiceAnnouncementListRecSet.voiceFiles = (string[]) null;
            VoiceAnnouncementListRecSet.voiceFiles = new string[this.voiceAnnFiles.Length];
            Array.Copy((Array) this.voiceAnnFiles, (Array) VoiceAnnouncementListRecSet.voiceFiles, sourceArray.Length);
            CollectionView defaultView = (CollectionView) CollectionViewSource.GetDefaultView((object) feature1);
            if (this.voiceAnnFiles.Length == 1)
            {
              feature1.AddDefaultRecord();
            }
            else
            {
              int counterToMax = feature1.CounterToMax;
              if (this.voiceAnnFiles.Length <= counterToMax)
                feature1.AddMultipleDefaultRecords(this.voiceAnnFiles.Length);
              else
                feature1.AddMultipleDefaultRecords(counterToMax);
            }
          }
        }
      }
      finally
      {
        AppInfoManager.LoadingVoiceData = false;
      }
    }
    else if (feature1 != null && feature1.RecsetId == feature3.RecsetId)
    {
      AppInfoManager.LoadingVoiceData = true;
      string[] sourceArray = (string[]) null;
      try
      {
        if (this.SelectVAFileDialog != null)
        {
          System.Collections.Generic.List<string> stringList = this.SelectVAFileDialog(SelectionMode.Extended);
          if (stringList != null && stringList.Count > 0)
            sourceArray = stringList.ToArray();
        }
        else
        {
          AcpOpenFileDialog acpOpenFileDialog = new AcpOpenFileDialog();
          acpOpenFileDialog.Filter = "Certificate files (*.*)|*.*";
          acpOpenFileDialog.MultiSelect = true;
          if (acpOpenFileDialog.ShowDialog().GetValueOrDefault())
            sourceArray = acpOpenFileDialog.FileNames;
        }
        if (sourceArray != null)
        {
          if (sourceArray.Length != 0)
          {
            this.systemCertificateFiles = new string[sourceArray.Length];
            Array.Copy((Array) sourceArray, (Array) this.systemCertificateFiles, sourceArray.Length);
            SystemCertificateListRecSet.systemCertificateCount = 0;
            SystemCertificateListRecSet.systemCertificateFiles = (string[]) null;
            SystemCertificateListRecSet.systemCertificateFiles = new string[this.systemCertificateFiles.Length];
            Array.Copy((Array) this.systemCertificateFiles, (Array) SystemCertificateListRecSet.systemCertificateFiles, sourceArray.Length);
            CollectionView defaultView = (CollectionView) CollectionViewSource.GetDefaultView((object) feature1);
            if (this.systemCertificateFiles.Length == 1)
            {
              feature1.AddDefaultRecord();
            }
            else
            {
              int counterToMax = feature1.CounterToMax;
              if (this.systemCertificateFiles.Length <= counterToMax)
                feature1.AddMultipleDefaultRecords(this.systemCertificateFiles.Length);
              else
                feature1.AddMultipleDefaultRecords(counterToMax);
            }
          }
        }
      }
      finally
      {
        AppInfoManager.LoadingVoiceData = false;
      }
    }
    else if (feature1 != null && feature1.RecsetId == feature4.RecsetId)
    {
      bool flag = UndoManager.StopUndoRedo();
      AppInfoManager.LoadingVoiceData = true;
      string dvrsFilePath = string.Empty;
      try
      {
        AcpOpenFileDialog acpOpenFileDialog = new AcpOpenFileDialog();
        acpOpenFileDialog.Filter = "DVRS files (*.dcd)|*.dcd";
        acpOpenFileDialog.MultiSelect = false;
        if (acpOpenFileDialog.ShowDialog().GetValueOrDefault())
          dvrsFilePath = acpOpenFileDialog.FileName;
        if (!string.IsNullOrEmpty(dvrsFilePath))
        {
          if (feature1.Count < 1)
            feature1.AddDefaultRecord();
          DVRSFilesHelper.populateDvrsFileDbRecords(feature1[0][10893] as DVRSFileLabtoolSection, dvrsFilePath);
        }
      }
      finally
      {
        AppInfoManager.LoadingVoiceData = false;
        if (flag)
          UndoManager.StartUndoRedo();
      }
    }
    if (this.preSelectedItem.RecsetId != selectedItem.RecsetId)
    {
      this.MyTreeView.LaunchPage(feature1.UIPagePath);
      ((CollectionView) CollectionViewSource.GetDefaultView((object) feature1)).MoveCurrentToLast();
      this.preSelectedItem = selectedItem;
    }
    else if (this.preSelectedItem.NodeId != 0)
    {
      selectedItem.IsSelected = false;
      AcpTreeViewItem childTreeViewItem = this.MyTreeView.FindChildTreeViewItem(feature1.RecsetId, feature1[feature1.Count - 1].NodeId);
      childTreeViewItem.IsSelected = true;
      this.preSelectedItem = childTreeViewItem;
    }
    else
      this.preSelectedItem = selectedItem;
    this.bRecordOpPerformed = true;
  }

  private void mItemDelete_Click(object sender, RoutedEventArgs e)
  {
    AcpTreeViewItem selectedItem = this.MyTreeView.SelectedItem as AcpTreeViewItem;
    IAcpRecordset feature = FeatureManager.GetFeature(selectedItem.RecsetId);
    feature.RemoveRecordAt(feature.IndexOf(feature.NodeFromId(selectedItem.NodeId)));
    if (this.preSelectedItem.RecsetId != selectedItem.RecsetId)
      this.MyTreeView.NavigateToContentPage((TreeView) this.MyTreeView);
    this.preSelectedItem = this.MyTreeView.SelectedItem as AcpTreeViewItem;
    this.bRecordOpPerformed = true;
  }

  private void mItemCopy_Click(object sender, RoutedEventArgs e)
  {
    AcpTreeViewItem selectedItem = this.MyTreeView.SelectedItem as AcpTreeViewItem;
    this.copyNode = FeatureManager.GetFeature(selectedItem.RecsetId).NodeFromId(selectedItem.NodeId);
    if (this.preSelectedItem.RecsetId != selectedItem.RecsetId)
    {
      this.MyTreeView.NavigateToContentPage((TreeView) this.MyTreeView);
      this.preSelectedItem = selectedItem;
    }
    else
    {
      selectedItem.IsSelected = false;
      this.preSelectedItem.IsSelected = true;
    }
    this.bRecordOpPerformed = true;
  }

  private void mItemPaste_Click(object sender, RoutedEventArgs e)
  {
    AcpTreeViewItem selectedItem = this.MyTreeView.SelectedItem as AcpTreeViewItem;
    IAcpRecordset feature = FeatureManager.GetFeature(selectedItem.RecsetId);
    int num = ((Recordset) feature).AddCopyOf(feature.IndexOf(this.copyNode)) ? 1 : 0;
    this.FixForAstroOtarProfileGUID(feature);
    if (num == 0)
    {
      AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Info, AppResources.Paste_Operation);
    }
    else
    {
      if (this.preSelectedItem.RecsetId != selectedItem.RecsetId)
      {
        this.MyTreeView.LaunchPage(feature.UIPagePath);
        ((CollectionView) CollectionViewSource.GetDefaultView((object) feature)).MoveCurrentToLast();
        this.preSelectedItem = selectedItem;
      }
      else if (this.preSelectedItem.NodeId != 0)
      {
        selectedItem.IsSelected = false;
        AcpTreeViewItem childTreeViewItem = this.MyTreeView.FindChildTreeViewItem(feature.RecsetId, feature[feature.Count - 1].NodeId);
        childTreeViewItem.IsSelected = true;
        this.preSelectedItem = childTreeViewItem;
      }
      else
        this.preSelectedItem = selectedItem;
      this.bRecordOpPerformed = true;
    }
  }

  private void FixForAstroOtarProfileGUID(IAcpRecordset recset)
  {
    if (!(this.copyNode.FeatureName == AcgResources.ID_ASTROOTARPROFILE))
      return;
    int index1 = (recset as SecureKMFProfileRecset).Count - 1;
    string str = (recset[index1] as Motorola.MackinawCPS.CoreFeatures.SecureKMFProfile.SecureKMFProfile).General.SecKmfProfileSecureProfileGUID_43662.Value;
    (recset[index1] as Motorola.MackinawCPS.CoreFeatures.SecureKMFProfile.SecureKMFProfile).General.SecKmfProfileSecureProfileGUID_43662.Value = CodeplugGuid.NewGuid();
    for (int index2 = 0; index2 <= index1; ++index2)
    {
      if ((recset[index2] as Motorola.MackinawCPS.CoreFeatures.SecureKMFProfile.SecureKMFProfile).General.SecKmfProfileSecureProfileGUID_43662.Value == str)
      {
        (recset[index2] as Motorola.MackinawCPS.CoreFeatures.SecureKMFProfile.SecureKMFProfile).General.SecKmfProfileSecureProfileGUID_43662.CalculateValidity();
        break;
      }
    }
  }

  private bool CanDelete(AcpTreeViewItem item)
  {
    bool flag = true;
    IAcpRecordset feature = FeatureManager.GetFeature(item.RecsetId);
    foreach (IAcpFeatureNode acpFeatureNode in (Collection<FeatureNode>) (feature as Recordset))
    {
      if (acpFeatureNode.ReferenceKey == item.ReferenceKey)
      {
        if (Permission.Have(Permissions.Undeletable, acpFeatureNode.Permissions))
          flag = false;
        else
          break;
      }
    }
    if (feature.Count == feature.Min)
      flag = false;
    return flag;
  }

  private bool CanPaste(IAcpFeatureNode node)
  {
    bool flag = false;
    IAcpRecordset parent = node.Parent;
    if (parent.IndexOf(node) >= 0 && !Permission.Have(Permissions.CopyDisabled, node.Permissions))
      flag = parent.GetCounterToMaxCopiesOf(parent.IndexOf(node)) > 0;
    return flag;
  }

  private bool CanCopy(AcpTreeViewItem item)
  {
    bool flag = true;
    foreach (IAcpFeatureNode acpFeatureNode in (Collection<FeatureNode>) (FeatureManager.GetFeature(item.RecsetId) as Recordset))
    {
      if (acpFeatureNode.ReferenceKey == item.ReferenceKey)
      {
        if (Permission.Have(Permissions.CopyDisabled, acpFeatureNode.Permissions))
          flag = false;
        else
          break;
      }
    }
    return flag;
  }

  private void OnContextMenuClosed(object sender, RoutedEventArgs e)
  {
    if (this.bRecordOpPerformed)
    {
      this.bRecordOpPerformed = false;
    }
    else
    {
      (this.MyTreeView.SelectedItem as AcpTreeViewItem).IsSelected = false;
      if (this.preSelectedItem == null)
        return;
      this.preSelectedItem.IsSelected = true;
    }
  }

  protected override void OnPreviewKeyDown(KeyEventArgs e)
  {
    if (e.Key == Key.Apps)
      e.Handled = true;
    else
      base.OnPreviewKeyDown(e);
  }

  protected override void OnPreviewKeyUp(KeyEventArgs e)
  {
    if (e.Key == Key.Apps)
      e.Handled = true;
    else
      base.OnPreviewKeyUp(e);
  }

  private void InitializePageTreeView()
  {
    if (AppInfoManager.AppMode == ApplicationMode.CustomViewConfigurationMode)
      this.myTreeViewItemRoot.DataContext = (object) ((AppInfoManager.DefaultDocument.GetFeature(2049) as RadioInformationRecset)[0][10108] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.General);
    else
      this.myTreeViewItemRoot.DataContext = (object) ((FeatureManager.GetFeature(2049) as RadioInformationRecset)[0][10108] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.General);
    this.myTreeViewItemRoot.RecsetId = 0;
    this.myTreeViewItemRoot.NodeId = 0;
    this.myTreeViewItemRoot.IsExpanded = true;
    this.AddFeatureNodeItems(this.myTreeViewItemRoot, 2049, AcgResources.ID_RADIOINFORMATION);
    this.AddFeatureNodeItems(this.myTreeViewItemRoot, 2045, AcgResources.ID_RADIOWIDE);
    this.AddFeatureNodeItems(this.myTreeViewItemRoot, 2003, AcgResources.ID_FACTORYOVERRIDES);
    if (AppInfoManager.AppMode == ApplicationMode.CustomViewConfigurationMode)
    {
      if (AppInfoManager.DefaultDocument.GetFeature(2033) != null && !AppInfoManager.DefaultDocument.GetFeature(2033).HiddenStatic || AppInfoManager.DefaultDocument.GetFeature(4176) != null && !AppInfoManager.DefaultDocument.GetFeature(4176).HiddenStatic || AppInfoManager.DefaultDocument.GetFeature(4008) != null && !AppInfoManager.DefaultDocument.GetFeature(4008).HiddenStatic || AppInfoManager.DefaultDocument.GetFeature(4174) != null && !AppInfoManager.DefaultDocument.GetFeature(4174).HiddenStatic || AppInfoManager.DefaultDocument.GetFeature(2042) != null && !AppInfoManager.DefaultDocument.GetFeature(2042).HiddenStatic || AppInfoManager.DefaultDocument.GetFeature(2038) != null && !AppInfoManager.DefaultDocument.GetFeature(2038).HiddenStatic || AppInfoManager.DefaultDocument.GetFeature(4115) != null && !AppInfoManager.DefaultDocument.GetFeature(4115).HiddenStatic || AppInfoManager.DefaultDocument.GetFeature(2127) != null && !AppInfoManager.DefaultDocument.GetFeature(2127).HiddenStatic || AppInfoManager.DefaultDocument.GetFeature(2130) != null && !AppInfoManager.DefaultDocument.GetFeature(2130).HiddenStatic || AppInfoManager.DefaultDocument.GetFeature(4114) != null && !AppInfoManager.DefaultDocument.GetFeature(4114).HiddenStatic || AppInfoManager.DefaultDocument.GetFeature(4003) != null && !AppInfoManager.DefaultDocument.GetFeature(4003).HiddenStatic || AppInfoManager.DefaultDocument.GetFeature(4236) != null && !AppInfoManager.DefaultDocument.GetFeature(4236).HiddenStatic || AppInfoManager.DefaultDocument.GetFeature(2088) != null && !AppInfoManager.DefaultDocument.GetFeature(2088).HiddenStatic || AppInfoManager.DefaultDocument.GetFeature(2128) != null && !AppInfoManager.DefaultDocument.GetFeature(2128).HiddenStatic || AppInfoManager.DefaultDocument.GetFeature(4109) != null && !AppInfoManager.DefaultDocument.GetFeature(4109).HiddenStatic || AppInfoManager.DefaultDocument.GetFeature(2129) != null && !AppInfoManager.DefaultDocument.GetFeature(2129).HiddenStatic || AppInfoManager.DefaultDocument.GetFeature(2036) != null && !AppInfoManager.DefaultDocument.GetFeature(2036).HiddenStatic || AppInfoManager.DefaultDocument.GetFeature(4130) != null && !AppInfoManager.DefaultDocument.GetFeature(4130).HiddenStatic || AppInfoManager.DefaultDocument.GetFeature(2125) != null && !AppInfoManager.DefaultDocument.GetFeature(2125).HiddenStatic || AppInfoManager.DefaultDocument.GetFeature(4145) != null && !AppInfoManager.DefaultDocument.GetFeature(4145).HiddenStatic || AppInfoManager.DefaultDocument.GetFeature(2300) != null && !AppInfoManager.DefaultDocument.GetFeature(2300).HiddenStatic || AppInfoManager.DefaultDocument.GetFeature(2013) != null && !AppInfoManager.DefaultDocument.GetFeature(2013).HiddenStatic || AppInfoManager.DefaultDocument.GetFeature(2010) != null && !AppInfoManager.DefaultDocument.GetFeature(2010).HiddenStatic || AppInfoManager.DefaultDocument.GetFeature(2086) != null && !AppInfoManager.DefaultDocument.GetFeature(2086).HiddenStatic || AppInfoManager.DefaultDocument.GetFeature(2087) != null && !AppInfoManager.DefaultDocument.GetFeature(2087).HiddenStatic || AppInfoManager.DefaultDocument.GetFeature(2131) != null && !AppInfoManager.DefaultDocument.GetFeature(2131).HiddenStatic || AppInfoManager.DefaultDocument.GetFeature(2077) != null && !AppInfoManager.DefaultDocument.GetFeature(2077).HiddenStatic || AppInfoManager.DefaultDocument.GetFeature(4156) != null && !AppInfoManager.DefaultDocument.GetFeature(4156).HiddenStatic || AppInfoManager.DefaultDocument.GetFeature(4231) != null && !AppInfoManager.DefaultDocument.GetFeature(4231).HiddenStatic)
      {
        AcpTreeViewItem acpTreeViewItem1 = new AcpTreeViewItem();
        acpTreeViewItem1.Header = (object) AcgResources.ID_RADIOERGONOMICSCONFIGURATION;
        this.myTreeViewItemRoot.Items.Add((object) acpTreeViewItem1);
        this.AddFeatureNodeItems(acpTreeViewItem1, 2033, AcgResources.ID_RADIOERGONOMICSWIDE);
        this.AddFeatureNodeItems(acpTreeViewItem1, 4176, AcgResources.ID_PERSONNELACCOUNTABILITY);
        this.AddFeatureNodeItems(acpTreeViewItem1, 4008, AcgResources.ID_ACTIONCONSOLIDATION);
        this.AddFeatureNodeItems(acpTreeViewItem1, 4174, AcgResources.ID_MISSIONCRITICALGEOFENCE);
        if (AppInfoManager.DefaultDocument.GetFeature(2042) != null && !AppInfoManager.DefaultDocument.GetFeature(2042).HiddenStatic || AppInfoManager.DefaultDocument.GetFeature(2038) != null && !AppInfoManager.DefaultDocument.GetFeature(2038).HiddenStatic || AppInfoManager.DefaultDocument.GetFeature(4115) != null && !AppInfoManager.DefaultDocument.GetFeature(4115).HiddenStatic || AppInfoManager.DefaultDocument.GetFeature(2127) != null && !AppInfoManager.DefaultDocument.GetFeature(2127).HiddenStatic || AppInfoManager.DefaultDocument.GetFeature(2130) != null && !AppInfoManager.DefaultDocument.GetFeature(2130).HiddenStatic || AppInfoManager.DefaultDocument.GetFeature(4114) != null && !AppInfoManager.DefaultDocument.GetFeature(4114).HiddenStatic || AppInfoManager.DefaultDocument.GetFeature(4003) != null && !AppInfoManager.DefaultDocument.GetFeature(4003).HiddenStatic || AppInfoManager.DefaultDocument.GetFeature(4236) != null && !AppInfoManager.DefaultDocument.GetFeature(4236).HiddenStatic || AppInfoManager.DefaultDocument.GetFeature(2088) != null && !AppInfoManager.DefaultDocument.GetFeature(2088).HiddenStatic || AppInfoManager.DefaultDocument.GetFeature(2128) != null && !AppInfoManager.DefaultDocument.GetFeature(2128).HiddenStatic || AppInfoManager.DefaultDocument.GetFeature(4109) != null && !AppInfoManager.DefaultDocument.GetFeature(4109).HiddenStatic || AppInfoManager.DefaultDocument.GetFeature(2129) != null && !AppInfoManager.DefaultDocument.GetFeature(2129).HiddenStatic || AppInfoManager.DefaultDocument.GetFeature(2036) != null && !AppInfoManager.DefaultDocument.GetFeature(2036).HiddenStatic || AppInfoManager.DefaultDocument.GetFeature(4130) != null && !AppInfoManager.DefaultDocument.GetFeature(4130).HiddenStatic || AppInfoManager.DefaultDocument.GetFeature(2125) != null && !AppInfoManager.DefaultDocument.GetFeature(2125).HiddenStatic)
        {
          AcpTreeViewItem acpTreeViewItem2 = new AcpTreeViewItem();
          acpTreeViewItem2.Header = (object) AcgResources.ID_CONTROLS;
          acpTreeViewItem1.Items.Add((object) acpTreeViewItem2);
          this.AddFeatureNodeItems(acpTreeViewItem2, 2042, AcgResources.ID_BUTTONS);
          this.AddFeatureNodeItems(acpTreeViewItem2, 2038, AcgResources.ID_SWITCHES);
          this.AddFeatureNodeItems(acpTreeViewItem2, 4115, AcgResources.ID_CONTROLHEADO2);
          this.AddFeatureNodeItems(acpTreeViewItem2, 2127, AcgResources.ID_CONTROLHEADO3);
          this.AddFeatureNodeItems(acpTreeViewItem2, 2130, AcgResources.ID_CONTROLHEADO5);
          this.AddFeatureNodeItems(acpTreeViewItem2, 4114, AcgResources.ID_CONTROLHEADO7);
          this.AddFeatureNodeItems(acpTreeViewItem2, 4003, AcgResources.ID_CONTROLHEADO9);
          this.AddFeatureNodeItems(acpTreeViewItem2, 4236, AcgResources.ID_CONTROLHEADE5);
          this.AddFeatureNodeItems(acpTreeViewItem2, 2088, AcgResources.ID_MENUITEMS);
          this.AddFeatureNodeItems(acpTreeViewItem2, 2128, AcgResources.ID_KEYPADMICANDACCESSORIES);
          this.AddFeatureNodeItems(acpTreeViewItem2, 4109, AcgResources.ID_KEYPAD);
          this.AddFeatureNodeItems(acpTreeViewItem2, 2129, AcgResources.ID_DEK);
          this.AddFeatureNodeItems(acpTreeViewItem2, 2036, AcgResources.ID_ACCESSORYBUTTONS);
          this.AddFeatureNodeItems(acpTreeViewItem2, 4130, AcgResources.ID_SMARTKEYFOBBUTTONS);
          this.AddFeatureNodeItems(acpTreeViewItem2, 2125, AcgResources.ID_RADIOVIPS);
        }
        this.AddFeatureNodeItems(acpTreeViewItem1, 2010, AcgResources.ID_DISPLAY);
        if (AppInfoManager.DefaultDocument.GetFeature(2086) != null && !AppInfoManager.DefaultDocument.GetFeature(2086).HiddenStatic || AppInfoManager.DefaultDocument.GetFeature(2087) != null && !AppInfoManager.DefaultDocument.GetFeature(2087).HiddenStatic || AppInfoManager.DefaultDocument.GetFeature(2131) != null && !AppInfoManager.DefaultDocument.GetFeature(2131).HiddenStatic)
        {
          AcpTreeViewItem acpTreeViewItem3 = new AcpTreeViewItem();
          acpTreeViewItem3.Header = (object) AcgResources.ID_NOISEREDUCTIONCONFIGURATION;
          acpTreeViewItem1.Items.Add((object) acpTreeViewItem3);
          this.AddFeatureNodeItems(acpTreeViewItem3, 2086, AcgResources.ID_RADIONOISEREDUCTIONPROFILE);
          this.AddFeatureNodeItems(acpTreeViewItem3, 2087, AcgResources.ID_ACCESSORYNOISEREDUCTIONPROFILE);
          this.AddFeatureNodeItems(acpTreeViewItem3, 2131, AcgResources.ID_GLOBALNOISEREDUCTIONLIST);
        }
        this.AddFeatureNodeItems(acpTreeViewItem1, 2077, AcgResources.ID_RADIOPROFILES);
        if (AppInfoManager.DefaultDocument.GetFeature(4156) != null && !AppInfoManager.DefaultDocument.GetFeature(4156).HiddenStatic)
        {
          AcpTreeViewItem acpTreeViewItem4 = new AcpTreeViewItem();
          acpTreeViewItem4.Header = (object) AcgResources.ID_TONESIGNALINGCONFIGURATION;
          acpTreeViewItem1.Items.Add((object) acpTreeViewItem4);
          this.AddFeatureNodeItems(acpTreeViewItem4, 4156, AcgResources.ID_TONESIGNALINGLIST);
        }
        this.AddFeatureNodeItems(acpTreeViewItem1, 4231, AcgResources.ID_VIRTUALPARTNERALERT);
        if (AppInfoManager.DefaultDocument.GetFeature(2301) != null && !AppInfoManager.DefaultDocument.GetFeature(2301).HiddenStatic || AppInfoManager.DefaultDocument.GetFeature(4145) != null && !FeatureManager.GetFeature(4145).HiddenStatic || AppInfoManager.DefaultDocument.GetFeature(2300) != null && !AppInfoManager.DefaultDocument.GetFeature(2300).HiddenStatic)
        {
          AcpTreeViewItem acpTreeViewItem5 = new AcpTreeViewItem();
          acpTreeViewItem5.Header = (object) AcgResources.ID_VOICEANNOUNCEMENTS;
          acpTreeViewItem1.Items.Add((object) acpTreeViewItem5);
          this.AddFeatureNodeItems(acpTreeViewItem5, 2301, AcgResources.ID_VOICEANNOUNCEMENTWIDE);
          this.AddFeatureNodeItems(acpTreeViewItem5, 4145, AppResources.ID_SITESELECTABLEALERTLIST);
          this.AddFeatureNodeItems(acpTreeViewItem5, 2300, AcgResources.ID_VOICEANNOUNCEMENTLIST);
        }
      }
    }
    else if (FeatureManager.GetFeature(2033) != null && !FeatureManager.GetFeature(2033).HiddenStatic || FeatureManager.GetFeature(4176) != null && !FeatureManager.GetFeature(4176).HiddenStatic || FeatureManager.GetFeature(4008) != null && !FeatureManager.GetFeature(4008).HiddenStatic || FeatureManager.GetFeature(4174) != null && !FeatureManager.GetFeature(4174).HiddenStatic || FeatureManager.GetFeature(2042) != null && !FeatureManager.GetFeature(2042).HiddenStatic || FeatureManager.GetFeature(2038) != null && !FeatureManager.GetFeature(2038).HiddenStatic || FeatureManager.GetFeature(4115) != null && !FeatureManager.GetFeature(4115).HiddenStatic || FeatureManager.GetFeature(2127) != null && !FeatureManager.GetFeature(2127).HiddenStatic || FeatureManager.GetFeature(2130) != null && !FeatureManager.GetFeature(2130).HiddenStatic || FeatureManager.GetFeature(4114) != null && !FeatureManager.GetFeature(4114).HiddenStatic || FeatureManager.GetFeature(4003) != null && !FeatureManager.GetFeature(4003).HiddenStatic || FeatureManager.GetFeature(4236) != null && !FeatureManager.GetFeature(4236).HiddenStatic || FeatureManager.GetFeature(2088) != null && !FeatureManager.GetFeature(2088).HiddenStatic || FeatureManager.GetFeature(2128) != null && !FeatureManager.GetFeature(2128).HiddenStatic || FeatureManager.GetFeature(4109) != null && !FeatureManager.GetFeature(4109).HiddenStatic || FeatureManager.GetFeature(2129) != null && !FeatureManager.GetFeature(2129).HiddenStatic || FeatureManager.GetFeature(2036) != null && !FeatureManager.GetFeature(2036).HiddenStatic || FeatureManager.GetFeature(4130) != null && !FeatureManager.GetFeature(4130).HiddenStatic || FeatureManager.GetFeature(2125) != null && !FeatureManager.GetFeature(2125).HiddenStatic || FeatureManager.GetFeature(4145) != null && !FeatureManager.GetFeature(4145).HiddenStatic || FeatureManager.GetFeature(2300) != null && !FeatureManager.GetFeature(2300).HiddenStatic || FeatureManager.GetFeature(2013) != null && !FeatureManager.GetFeature(2013).HiddenStatic || FeatureManager.GetFeature(2010) != null && !FeatureManager.GetFeature(2010).HiddenStatic || FeatureManager.GetFeature(2086) != null && !FeatureManager.GetFeature(2086).HiddenStatic || FeatureManager.GetFeature(2087) != null && !FeatureManager.GetFeature(2087).HiddenStatic || FeatureManager.GetFeature(2131) != null && !FeatureManager.GetFeature(2131).HiddenStatic || FeatureManager.GetFeature(2077) != null && !FeatureManager.GetFeature(2077).HiddenStatic || FeatureManager.GetFeature(4156) != null && !FeatureManager.GetFeature(4156).HiddenStatic || FeatureManager.GetFeature(4231) != null && !FeatureManager.GetFeature(4231).HiddenStatic)
    {
      AcpTreeViewItem acpTreeViewItem6 = new AcpTreeViewItem();
      acpTreeViewItem6.Header = (object) AcgResources.ID_RADIOERGONOMICSCONFIGURATION;
      this.myTreeViewItemRoot.Items.Add((object) acpTreeViewItem6);
      this.AddFeatureNodeItems(acpTreeViewItem6, 2033, AcgResources.ID_RADIOERGONOMICSWIDE);
      this.AddFeatureNodeItems(acpTreeViewItem6, 4176, AcgResources.ID_PERSONNELACCOUNTABILITY);
      this.AddFeatureNodeItems(acpTreeViewItem6, 4008, AcgResources.ID_ACTIONCONSOLIDATION);
      this.AddFeatureNodeItems(acpTreeViewItem6, 4174, AcgResources.ID_MISSIONCRITICALGEOFENCE);
      if (FeatureManager.GetFeature(2042) != null && !FeatureManager.GetFeature(2042).HiddenStatic || FeatureManager.GetFeature(2038) != null && !FeatureManager.GetFeature(2038).HiddenStatic || FeatureManager.GetFeature(4115) != null && !FeatureManager.GetFeature(4115).HiddenStatic || FeatureManager.GetFeature(2127) != null && !FeatureManager.GetFeature(2127).HiddenStatic || FeatureManager.GetFeature(2130) != null && !FeatureManager.GetFeature(2130).HiddenStatic || FeatureManager.GetFeature(4114) != null && !FeatureManager.GetFeature(4114).HiddenStatic || FeatureManager.GetFeature(4003) != null && !FeatureManager.GetFeature(4003).HiddenStatic || FeatureManager.GetFeature(4236) != null && !FeatureManager.GetFeature(4236).HiddenStatic || FeatureManager.GetFeature(2088) != null && !FeatureManager.GetFeature(2088).HiddenStatic || FeatureManager.GetFeature(2128) != null && !FeatureManager.GetFeature(2128).HiddenStatic || FeatureManager.GetFeature(4109) != null && !FeatureManager.GetFeature(4109).HiddenStatic || FeatureManager.GetFeature(2129) != null && !FeatureManager.GetFeature(2129).HiddenStatic || FeatureManager.GetFeature(2036) != null && !FeatureManager.GetFeature(2036).HiddenStatic || FeatureManager.GetFeature(4130) != null && !FeatureManager.GetFeature(4130).HiddenStatic || FeatureManager.GetFeature(2125) != null && !FeatureManager.GetFeature(2125).HiddenStatic)
      {
        AcpTreeViewItem acpTreeViewItem7 = new AcpTreeViewItem();
        acpTreeViewItem7.Header = (object) AcgResources.ID_CONTROLS;
        acpTreeViewItem6.Items.Add((object) acpTreeViewItem7);
        this.AddFeatureNodeItems(acpTreeViewItem7, 2042, AcgResources.ID_BUTTONS);
        this.AddFeatureNodeItems(acpTreeViewItem7, 2038, AcgResources.ID_SWITCHES);
        this.AddFeatureNodeItems(acpTreeViewItem7, 4115, AcgResources.ID_CONTROLHEADO2);
        this.AddFeatureNodeItems(acpTreeViewItem7, 2127, AcgResources.ID_CONTROLHEADO3);
        this.AddFeatureNodeItems(acpTreeViewItem7, 2130, AcgResources.ID_CONTROLHEADO5);
        this.AddFeatureNodeItems(acpTreeViewItem7, 4114, AcgResources.ID_CONTROLHEADO7);
        this.AddFeatureNodeItems(acpTreeViewItem7, 4003, AcgResources.ID_CONTROLHEADO9);
        this.AddFeatureNodeItems(acpTreeViewItem7, 4236, AcgResources.ID_CONTROLHEADE5);
        this.AddFeatureNodeItems(acpTreeViewItem7, 2088, AcgResources.ID_MENUITEMS);
        this.AddFeatureNodeItems(acpTreeViewItem7, 2128, AcgResources.ID_KEYPADMICANDACCESSORIES);
        this.AddFeatureNodeItems(acpTreeViewItem7, 4109, AcgResources.ID_KEYPAD);
        this.AddFeatureNodeItems(acpTreeViewItem7, 2129, AcgResources.ID_DEK);
        this.AddFeatureNodeItems(acpTreeViewItem7, 2036, AcgResources.ID_ACCESSORYBUTTONS);
        this.AddFeatureNodeItems(acpTreeViewItem7, 4130, AcgResources.ID_SMARTKEYFOBBUTTONS);
        this.AddFeatureNodeItems(acpTreeViewItem7, 2125, AcgResources.ID_RADIOVIPS);
      }
      this.AddFeatureNodeItems(acpTreeViewItem6, 2010, AcgResources.ID_DISPLAY);
      if (FeatureManager.GetFeature(2086) != null && !FeatureManager.GetFeature(2086).HiddenStatic || FeatureManager.GetFeature(2087) != null && !FeatureManager.GetFeature(2087).HiddenStatic || FeatureManager.GetFeature(2131) != null && !FeatureManager.GetFeature(2131).HiddenStatic)
      {
        AcpTreeViewItem acpTreeViewItem8 = new AcpTreeViewItem();
        acpTreeViewItem8.Header = (object) AcgResources.ID_NOISEREDUCTIONCONFIGURATION;
        acpTreeViewItem6.Items.Add((object) acpTreeViewItem8);
        this.AddFeatureNodeItems(acpTreeViewItem8, 2086, AcgResources.ID_RADIONOISEREDUCTIONPROFILE);
        this.AddFeatureNodeItems(acpTreeViewItem8, 2087, AcgResources.ID_ACCESSORYNOISEREDUCTIONPROFILE);
        this.AddFeatureNodeItems(acpTreeViewItem8, 2131, AcgResources.ID_GLOBALNOISEREDUCTIONLIST);
      }
      this.AddFeatureNodeItems(acpTreeViewItem6, 2077, AcgResources.ID_RADIOPROFILES);
      if (FeatureManager.GetFeature(4156) != null && !FeatureManager.GetFeature(4156).HiddenStatic)
      {
        AcpTreeViewItem acpTreeViewItem9 = new AcpTreeViewItem();
        acpTreeViewItem9.Header = (object) AcgResources.ID_TONESIGNALINGCONFIGURATION;
        acpTreeViewItem6.Items.Add((object) acpTreeViewItem9);
        this.AddFeatureNodeItems(acpTreeViewItem9, 4156, AcgResources.ID_TONESIGNALINGLIST);
      }
      this.AddFeatureNodeItems(acpTreeViewItem6, 4231, AcgResources.ID_VIRTUALPARTNERALERT);
      if (FeatureManager.GetFeature(2301) != null && !FeatureManager.GetFeature(2301).HiddenStatic || FeatureManager.GetFeature(4145) != null && !FeatureManager.GetFeature(4145).HiddenStatic || FeatureManager.GetFeature(2300) != null && !FeatureManager.GetFeature(2300).HiddenStatic)
      {
        AcpTreeViewItem acpTreeViewItem10 = new AcpTreeViewItem();
        acpTreeViewItem10.Header = (object) AcgResources.ID_VOICEANNOUNCEMENTS;
        acpTreeViewItem6.Items.Add((object) acpTreeViewItem10);
        this.AddFeatureNodeItems(acpTreeViewItem10, 2301, AcgResources.ID_VOICEANNOUNCEMENTWIDE);
        this.AddFeatureNodeItems(acpTreeViewItem10, 4145, AppResources.ID_SITESELECTABLEALERTLIST);
        this.AddFeatureNodeItems(acpTreeViewItem10, 2300, AcgResources.ID_VOICEANNOUNCEMENTLIST);
      }
    }
    if (AppInfoManager.AppMode == ApplicationMode.CustomViewConfigurationMode)
    {
      if (AppInfoManager.DefaultDocument.GetFeature(2021) != null && !AppInfoManager.DefaultDocument.GetFeature(2021).HiddenStatic || AppInfoManager.DefaultDocument.GetFeature(2055) != null && !AppInfoManager.DefaultDocument.GetFeature(2055).HiddenStatic || AppInfoManager.DefaultDocument.GetFeature(4228) != null && !AppInfoManager.DefaultDocument.GetFeature(4228).HiddenStatic)
      {
        AcpTreeViewItem acpTreeViewItem = new AcpTreeViewItem();
        acpTreeViewItem.Header = (object) AcgResources.ID_SECURECONFIGURATION;
        this.myTreeViewItemRoot.Items.Add((object) acpTreeViewItem);
        this.AddFeatureNodeItems(acpTreeViewItem, 2021, AcgResources.ID_SECUREWIDE);
        this.AddFeatureNodeItems(acpTreeViewItem, 2055, AcgResources.ID_ASTROOTARPROFILE);
        this.AddFeatureNodeItems(acpTreeViewItem, 4228, AppResources.System_Cerfiticate_List_ID);
      }
    }
    else if (FeatureManager.GetFeature(2021) != null && !FeatureManager.GetFeature(2021).HiddenStatic || FeatureManager.GetFeature(2055) != null && !FeatureManager.GetFeature(2055).HiddenStatic || FeatureManager.GetFeature(4228) != null && !FeatureManager.GetFeature(4228).HiddenStatic)
    {
      AcpTreeViewItem acpTreeViewItem = new AcpTreeViewItem();
      acpTreeViewItem.Header = (object) AcgResources.ID_SECURECONFIGURATION;
      this.myTreeViewItemRoot.Items.Add((object) acpTreeViewItem);
      this.AddFeatureNodeItems(acpTreeViewItem, 2021, AcgResources.ID_SECUREWIDE);
      this.AddFeatureNodeItems(acpTreeViewItem, 2055, AcgResources.ID_ASTROOTARPROFILE);
      this.AddFeatureNodeItems(acpTreeViewItem, 4228, AppResources.System_Cerfiticate_List_ID);
    }
    if (AppInfoManager.AppMode == ApplicationMode.CustomViewConfigurationMode)
    {
      if (AppInfoManager.DefaultDocument.GetFeature(2032) != null && !AppInfoManager.DefaultDocument.GetFeature(2032).HiddenStatic || AppInfoManager.DefaultDocument.GetFeature(2075) != null && !AppInfoManager.DefaultDocument.GetFeature(2075).HiddenStatic || AppInfoManager.DefaultDocument.GetFeature(2076) != null && !AppInfoManager.DefaultDocument.GetFeature(2076).HiddenStatic)
      {
        AcpTreeViewItem acpTreeViewItem = new AcpTreeViewItem();
        acpTreeViewItem.Header = (object) AcgResources.ID_EMERGENCYCONFIGURATION;
        this.myTreeViewItemRoot.Items.Add((object) acpTreeViewItem);
        this.AddFeatureNodeItems(acpTreeViewItem, 2032, AcgResources.ID_EMERGENCYWIDE);
        this.AddFeatureNodeItems(acpTreeViewItem, 2075, AcgResources.ID_CONVENTIONALEMERGENCYPROFILES);
        this.AddFeatureNodeItems(acpTreeViewItem, 2076, AcgResources.ID_TRUNKINGEMERGENCYPROFILES);
      }
    }
    else if (FeatureManager.GetFeature(2032) != null && !FeatureManager.GetFeature(2032).HiddenStatic || FeatureManager.GetFeature(2075) != null && !FeatureManager.GetFeature(2075).HiddenStatic || FeatureManager.GetFeature(2076) != null && !FeatureManager.GetFeature(2076).HiddenStatic)
    {
      AcpTreeViewItem acpTreeViewItem = new AcpTreeViewItem();
      acpTreeViewItem.Header = (object) AcgResources.ID_EMERGENCYCONFIGURATION;
      this.myTreeViewItemRoot.Items.Add((object) acpTreeViewItem);
      this.AddFeatureNodeItems(acpTreeViewItem, 2032, AcgResources.ID_EMERGENCYWIDE);
      this.AddFeatureNodeItems(acpTreeViewItem, 2075, AcgResources.ID_CONVENTIONALEMERGENCYPROFILES);
      this.AddFeatureNodeItems(acpTreeViewItem, 2076, AcgResources.ID_TRUNKINGEMERGENCYPROFILES);
    }
    if (AppInfoManager.AppMode == ApplicationMode.CustomViewConfigurationMode)
    {
      if (AppInfoManager.DefaultDocument.GetFeature(2028) != null && !AppInfoManager.DefaultDocument.GetFeature(2028).HiddenStatic || AppInfoManager.DefaultDocument.GetFeature(2054) != null && !AppInfoManager.DefaultDocument.GetFeature(2054).HiddenStatic || AppInfoManager.DefaultDocument.GetFeature(4148) != null && !AppInfoManager.DefaultDocument.GetFeature(4148).HiddenStatic)
      {
        AcpTreeViewItem acpTreeViewItem = new AcpTreeViewItem();
        acpTreeViewItem.Header = (object) AcgResources.ID_DATACONFIGURATION;
        this.myTreeViewItemRoot.Items.Add((object) acpTreeViewItem);
        this.AddFeatureNodeItems(acpTreeViewItem, 2028, AcgResources.ID_DATAWIDE);
        this.AddFeatureNodeItems(acpTreeViewItem, 2054, AcgResources.ID_DATAPROFILES);
        this.AddFeatureNodeItems(acpTreeViewItem, 4148, AcgResources.ID_ENHANCEDDATAPORTLIST);
      }
    }
    else if (FeatureManager.GetFeature(2028) != null && !FeatureManager.GetFeature(2028).HiddenStatic || FeatureManager.GetFeature(2054) != null && !FeatureManager.GetFeature(2054).HiddenStatic || FeatureManager.GetFeature(4148) != null && !FeatureManager.GetFeature(4148).HiddenStatic)
    {
      AcpTreeViewItem acpTreeViewItem = new AcpTreeViewItem();
      acpTreeViewItem.Header = (object) AcgResources.ID_DATACONFIGURATION;
      this.myTreeViewItemRoot.Items.Add((object) acpTreeViewItem);
      this.AddFeatureNodeItems(acpTreeViewItem, 2028, AcgResources.ID_DATAWIDE);
      this.AddFeatureNodeItems(acpTreeViewItem, 2054, AcgResources.ID_DATAPROFILES);
      this.AddFeatureNodeItems(acpTreeViewItem, 4148, AcgResources.ID_ENHANCEDDATAPORTLIST);
    }
    this.AddFeatureNodeItems(this.myTreeViewItemRoot, 2000, AcgResources.ID_PHONEWIDE);
    if (AppInfoManager.AppMode == ApplicationMode.CustomViewConfigurationMode)
    {
      if (AppInfoManager.DefaultDocument.GetFeature(4142) != null && !AppInfoManager.DefaultDocument.GetFeature(4142).HiddenStatic || AppInfoManager.DefaultDocument.GetFeature(4143) != null && !AppInfoManager.DefaultDocument.GetFeature(4143).HiddenStatic)
      {
        AcpTreeViewItem acpTreeViewItem = new AcpTreeViewItem();
        acpTreeViewItem.Header = (object) AcgResources.ID_DVRSCONFIGURATION;
        this.myTreeViewItemRoot.Items.Add((object) acpTreeViewItem);
        this.AddFeatureNodeItems(acpTreeViewItem, 4142, AcgResources.ID_DVRSWIDE);
        this.AddFeatureNodeItems(acpTreeViewItem, 4143, AcgResources.ID_DVRSPROFILES);
      }
    }
    else if (FeatureManager.GetFeature(4142) != null && !FeatureManager.GetFeature(4142).HiddenStatic || FeatureManager.GetFeature(4143) != null && !FeatureManager.GetFeature(4143).HiddenStatic || FeatureManager.GetFeature(4234) != null && !FeatureManager.GetFeature(4234).HiddenStatic)
    {
      AcpTreeViewItem acpTreeViewItem = new AcpTreeViewItem();
      acpTreeViewItem.Header = (object) AcgResources.ID_DVRSCONFIGURATION;
      this.myTreeViewItemRoot.Items.Add((object) acpTreeViewItem);
      this.AddFeatureNodeItems(acpTreeViewItem, 4142, AcgResources.ID_DVRSWIDE);
      this.AddFeatureNodeItems(acpTreeViewItem, 4143, AcgResources.ID_DVRSPROFILES);
    }
    if (AppInfoManager.AppMode == ApplicationMode.CustomViewConfigurationMode)
    {
      if (AppInfoManager.DefaultDocument.GetFeature(2024) != null && !AppInfoManager.DefaultDocument.GetFeature(2024).HiddenStatic || AppInfoManager.DefaultDocument.GetFeature(2078) != null && !AppInfoManager.DefaultDocument.GetFeature(2078).HiddenStatic || AppInfoManager.DefaultDocument.GetFeature(2007) != null && !AppInfoManager.DefaultDocument.GetFeature(2007).HiddenStatic || AppInfoManager.DefaultDocument.GetFeature(2034) != null && !AppInfoManager.DefaultDocument.GetFeature(2034).HiddenStatic || AppInfoManager.DefaultDocument.GetFeature(2062) != null && !AppInfoManager.DefaultDocument.GetFeature(2062).HiddenStatic || AppInfoManager.DefaultDocument.GetFeature(2053) != null && !AppInfoManager.DefaultDocument.GetFeature(2053).HiddenStatic || AppInfoManager.DefaultDocument.GetFeature(2059) != null && !AppInfoManager.DefaultDocument.GetFeature(2059).HiddenStatic)
      {
        AcpTreeViewItem acpTreeViewItem = new AcpTreeViewItem();
        acpTreeViewItem.Header = (object) AcgResources.ID_CONVENTIONALCONFIGURATION;
        this.myTreeViewItemRoot.Items.Add((object) acpTreeViewItem);
        this.AddFeatureNodeItems(acpTreeViewItem, 2024, AcgResources.ID_CONVENTIONALWIDE);
        this.AddFeatureNodeItems(acpTreeViewItem, 2078, AcgResources.ID_MPLCONFIGURATION);
        this.AddFeatureNodeItems(acpTreeViewItem, 2007, AcgResources.ID_CONVENTIONALALIASLISTS);
        this.AddFeatureNodeItems(acpTreeViewItem, 2034, AcgResources.ID_REPEATERIDLIST);
        this.AddFeatureNodeItems(acpTreeViewItem, 2062, AcgResources.ID_ASTROTALKGROUPLIST);
        this.AddFeatureNodeItems(acpTreeViewItem, 2053, AcgResources.ID_CONVENTIONALSYSTEM);
        this.AddFeatureNodeItems(acpTreeViewItem, 2059, AcgResources.ID_CONVENTIONALPERSONALITY);
      }
    }
    else if (FeatureManager.GetFeature(2024) != null && !FeatureManager.GetFeature(2024).HiddenStatic || FeatureManager.GetFeature(2078) != null && !FeatureManager.GetFeature(2078).HiddenStatic || FeatureManager.GetFeature(2007) != null && !FeatureManager.GetFeature(2007).HiddenStatic || FeatureManager.GetFeature(2034) != null && !FeatureManager.GetFeature(2034).HiddenStatic || FeatureManager.GetFeature(2062) != null && !FeatureManager.GetFeature(2062).HiddenStatic || FeatureManager.GetFeature(2053) != null && !FeatureManager.GetFeature(2053).HiddenStatic || FeatureManager.GetFeature(2059) != null && !FeatureManager.GetFeature(2059).HiddenStatic)
    {
      AcpTreeViewItem acpTreeViewItem = new AcpTreeViewItem();
      acpTreeViewItem.Header = (object) AcgResources.ID_CONVENTIONALCONFIGURATION;
      this.myTreeViewItemRoot.Items.Add((object) acpTreeViewItem);
      this.AddFeatureNodeItems(acpTreeViewItem, 2024, AcgResources.ID_CONVENTIONALWIDE);
      this.AddFeatureNodeItems(acpTreeViewItem, 2078, AcgResources.ID_MPLCONFIGURATION);
      this.AddFeatureNodeItems(acpTreeViewItem, 2007, AcgResources.ID_CONVENTIONALALIASLISTS);
      this.AddFeatureNodeItems(acpTreeViewItem, 2034, AcgResources.ID_REPEATERIDLIST);
      this.AddFeatureNodeItems(acpTreeViewItem, 2062, AcgResources.ID_ASTROTALKGROUPLIST);
      this.AddFeatureNodeItems(acpTreeViewItem, 2053, AcgResources.ID_CONVENTIONALSYSTEM);
      this.AddFeatureNodeItems(acpTreeViewItem, 2059, AcgResources.ID_CONVENTIONALPERSONALITY);
    }
    if (AppInfoManager.AppMode == ApplicationMode.CustomViewConfigurationMode)
    {
      if (AppInfoManager.DefaultDocument.GetFeature(2027) != null && !AppInfoManager.DefaultDocument.GetFeature(2027).HiddenStatic || AppInfoManager.DefaultDocument.GetFeature(2064) != null && !AppInfoManager.DefaultDocument.GetFeature(2064).HiddenStatic || AppInfoManager.DefaultDocument.GetFeature(2072) != null && !AppInfoManager.DefaultDocument.GetFeature(2072).HiddenStatic)
      {
        AcpTreeViewItem acpTreeViewItem = new AcpTreeViewItem();
        acpTreeViewItem.Header = (object) AcgResources.ID_TRUNKINGCONFIGURATION;
        this.myTreeViewItemRoot.Items.Add((object) acpTreeViewItem);
        this.AddFeatureNodeItems(acpTreeViewItem, 2027, AcgResources.ID_TRUNKINGWIDE);
        this.AddFeatureNodeItems(acpTreeViewItem, 2064, AcgResources.ID_TRUNKINGSYSTEM);
        this.AddFeatureNodeItems(acpTreeViewItem, 2072, AcgResources.ID_TRUNKINGPERSONALITY);
      }
    }
    else if (FeatureManager.GetFeature(2027) != null && !FeatureManager.GetFeature(2027).HiddenStatic || FeatureManager.GetFeature(2064) != null && !FeatureManager.GetFeature(2064).HiddenStatic || FeatureManager.GetFeature(2072) != null && !FeatureManager.GetFeature(2072).HiddenStatic)
    {
      AcpTreeViewItem acpTreeViewItem = new AcpTreeViewItem();
      acpTreeViewItem.Header = (object) AcgResources.ID_TRUNKINGCONFIGURATION;
      this.myTreeViewItemRoot.Items.Add((object) acpTreeViewItem);
      this.AddFeatureNodeItems(acpTreeViewItem, 2027, AcgResources.ID_TRUNKINGWIDE);
      this.AddFeatureNodeItems(acpTreeViewItem, 2064, AcgResources.ID_TRUNKINGSYSTEM);
      this.AddFeatureNodeItems(acpTreeViewItem, 2072, AcgResources.ID_TRUNKINGPERSONALITY);
    }
    if (AppInfoManager.AppMode == ApplicationMode.CustomViewConfigurationMode)
    {
      if (AppInfoManager.DefaultDocument.GetFeature(2222) != null && !AppInfoManager.DefaultDocument.GetFeature(2222).HiddenStatic || AppInfoManager.DefaultDocument.GetFeature(2200) != null && !AppInfoManager.DefaultDocument.GetFeature(2200).HiddenStatic || AppInfoManager.DefaultDocument.GetFeature(2208) != null && !AppInfoManager.DefaultDocument.GetFeature(2208).HiddenStatic || AppInfoManager.DefaultDocument.GetFeature(2214) != null && !AppInfoManager.DefaultDocument.GetFeature(2214).HiddenStatic || AppInfoManager.DefaultDocument.GetFeature(2210) != null && !AppInfoManager.DefaultDocument.GetFeature(2210).HiddenStatic || AppInfoManager.DefaultDocument.GetFeature(2212) != null && !AppInfoManager.DefaultDocument.GetFeature(2212).HiddenStatic || AppInfoManager.DefaultDocument.GetFeature(2220) != null && !AppInfoManager.DefaultDocument.GetFeature(2220).HiddenStatic)
      {
        AcpTreeViewItem acpTreeViewItem = new AcpTreeViewItem();
        acpTreeViewItem.Header = (object) AcgResources.ID_CALLLISTCONFIGURATION;
        this.myTreeViewItemRoot.Items.Add((object) acpTreeViewItem);
        this.AddFeatureNodeItems(acpTreeViewItem, 2222, AcgResources.ID_CALLLISTWIDE);
        this.AddFeatureNodeItems(acpTreeViewItem, 2200, AcgResources.ID_UNIFIEDCALLLIST);
        this.AddFeatureNodeItems(acpTreeViewItem, 2208, AcgResources.ID_ASTRO25TRUNKINGHOTLIST);
        this.AddFeatureNodeItems(acpTreeViewItem, 2214, AcgResources.ID_TYPEIITRUNKINGHOTLIST);
        this.AddFeatureNodeItems(acpTreeViewItem, 2210, AcgResources.ID_ASTROCONVENTIONALHOTLIST);
        this.AddFeatureNodeItems(acpTreeViewItem, 2212, AcgResources.ID_MDCCONVENTIONALHOTLIST);
        this.AddFeatureNodeItems(acpTreeViewItem, 2220, AcgResources.ID_PHONEHOTLIST);
      }
    }
    else if (FeatureManager.GetFeature(2222) != null && !FeatureManager.GetFeature(2222).HiddenStatic || FeatureManager.GetFeature(2200) != null && !FeatureManager.GetFeature(2200).HiddenStatic || FeatureManager.GetFeature(2208) != null && !FeatureManager.GetFeature(2208).HiddenStatic || FeatureManager.GetFeature(2214) != null && !FeatureManager.GetFeature(2214).HiddenStatic || FeatureManager.GetFeature(2210) != null && !FeatureManager.GetFeature(2210).HiddenStatic || FeatureManager.GetFeature(2212) != null && !FeatureManager.GetFeature(2212).HiddenStatic || FeatureManager.GetFeature(2220) != null && !FeatureManager.GetFeature(2220).HiddenStatic)
    {
      AcpTreeViewItem acpTreeViewItem = new AcpTreeViewItem();
      acpTreeViewItem.Header = (object) AcgResources.ID_CALLLISTCONFIGURATION;
      this.myTreeViewItemRoot.Items.Add((object) acpTreeViewItem);
      this.AddFeatureNodeItems(acpTreeViewItem, 2222, AcgResources.ID_CALLLISTWIDE);
      this.AddFeatureNodeItems(acpTreeViewItem, 2200, AcgResources.ID_UNIFIEDCALLLIST);
      this.AddFeatureNodeItems(acpTreeViewItem, 2208, AcgResources.ID_ASTRO25TRUNKINGHOTLIST);
      this.AddFeatureNodeItems(acpTreeViewItem, 2214, AcgResources.ID_TYPEIITRUNKINGHOTLIST);
      this.AddFeatureNodeItems(acpTreeViewItem, 2210, AcgResources.ID_ASTROCONVENTIONALHOTLIST);
      this.AddFeatureNodeItems(acpTreeViewItem, 2212, AcgResources.ID_MDCCONVENTIONALHOTLIST);
      this.AddFeatureNodeItems(acpTreeViewItem, 2220, AcgResources.ID_PHONEHOTLIST);
    }
    this.AddFeatureNodeItems(this.myTreeViewItemRoot, 2051, AcgResources.ID_ZONECHANNELASSIGNMENT);
    if (AppInfoManager.AppMode == ApplicationMode.CustomViewConfigurationMode)
    {
      if ((AppInfoManager.DefaultDocument.GetFeature(2023) == null || AppInfoManager.DefaultDocument.GetFeature(2023).HiddenStatic) && (AppInfoManager.DefaultDocument.GetFeature(2057) == null || AppInfoManager.DefaultDocument.GetFeature(2057).HiddenStatic))
        return;
      AcpTreeViewItem acpTreeViewItem = new AcpTreeViewItem();
      acpTreeViewItem.Header = (object) AcgResources.ID_SCANCONFIGURATION;
      this.myTreeViewItemRoot.Items.Add((object) acpTreeViewItem);
      this.AddFeatureNodeItems(acpTreeViewItem, 2023, AcgResources.ID_SCANWIDE);
      this.AddFeatureNodeItems(acpTreeViewItem, 2057, AcgResources.ID_SCANLIST);
    }
    else
    {
      if ((FeatureManager.GetFeature(2023) == null || FeatureManager.GetFeature(2023).HiddenStatic) && (FeatureManager.GetFeature(2057) == null || FeatureManager.GetFeature(2057).HiddenStatic))
        return;
      AcpTreeViewItem acpTreeViewItem = new AcpTreeViewItem();
      acpTreeViewItem.Header = (object) AcgResources.ID_SCANCONFIGURATION;
      this.myTreeViewItemRoot.Items.Add((object) acpTreeViewItem);
      this.AddFeatureNodeItems(acpTreeViewItem, 2023, AcgResources.ID_SCANWIDE);
      this.AddFeatureNodeItems(acpTreeViewItem, 2057, AcgResources.ID_SCANLIST);
    }
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "8.0.8.0")]
  public void InitializeComponent()
  {
    if (this._contentLoaded)
      return;
    this._contentLoaded = true;
    Application.LoadComponent((object) this, new Uri("/APXFamilyCPS;component/pagetreeview.xaml", UriKind.Relative));
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "8.0.8.0")]
  internal Delegate _CreateDelegate(Type delegateType, string handler)
  {
    return Delegate.CreateDelegate(delegateType, (object) this, handler);
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "8.0.8.0")]
  [EditorBrowsable(EditorBrowsableState.Never)]
  void IComponentConnector.Connect(int connectionId, object target)
  {
    switch (connectionId)
    {
      case 1:
        ((FrameworkElement) target).Loaded += new RoutedEventHandler(this.PageTreeView_Loaded);
        ((FrameworkElement) target).Unloaded += new RoutedEventHandler(this.PageTreeView_Unloaded);
        break;
      case 2:
        this.MyTreeView = (AppTreeView) target;
        break;
      case 3:
        this.myTreeViewItemRoot = (AcpTreeViewItem) target;
        break;
      default:
        this._contentLoaded = true;
        break;
    }
  }
}
