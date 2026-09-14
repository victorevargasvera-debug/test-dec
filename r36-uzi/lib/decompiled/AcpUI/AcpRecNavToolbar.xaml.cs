// Decompiled with JetBrains decompiler
// Type: AcpUI.AcpRecNavToolbar
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

using AcpBusinessLayer;
using AcpCommonLib;
using AcpCommonResources;
using AcpUILib;
using AcpUtility;
using Infragistics.Windows.DataPresenter;
using Infragistics.Windows.DataPresenter.Events;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;

#nullable disable
namespace AcpUI;

public partial class AcpRecNavToolbar : 
  UserControl,
  IAcpRecNavToolbar,
  IDisposable,
  INotifyPropertyChanged,
  IComponentConnector
{
  public static readonly DependencyProperty IsAcpVisibleProperty = DependencyProperty.Register(nameof (IsAcpVisible), typeof (bool), typeof (AcpRecNavToolbar), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty IsAddMultQtyEnProperty = DependencyProperty.Register(nameof (IsAddMultQtyEn), typeof (bool), typeof (AcpRecNavToolbar), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty IsDefaultMaskTypeEnProperty = DependencyProperty.Register(nameof (IsDefaultMaskTypeEn), typeof (bool), typeof (AcpRecNavToolbar), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty IsMaskMaxLengthEnProperty = DependencyProperty.Register(nameof (IsMaskMaxLengthEn), typeof (bool), typeof (AcpRecNavToolbar), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty MySecondaryRecordsetDataSourceProperty = DependencyProperty.Register(nameof (MySecondaryRecordsetDataSource), typeof (IAcpRecordset), typeof (AcpRecNavToolbar), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty GoToRecNumProperty = DependencyProperty.Register(nameof (GoToRecNum), typeof (int), typeof (AcpRecNavToolbar), (PropertyMetadata) new FrameworkPropertyMetadata((object) 1, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty TableModeProperty = DependencyProperty.Register(nameof (TableMode), typeof (bool), typeof (AcpRecNavToolbar), (PropertyMetadata) new FrameworkPropertyMetadata((object) false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty MyRecordsetDataSourceProperty = DependencyProperty.Register(nameof (MyRecordsetDataSource), typeof (IAcpRecordset), typeof (AcpRecNavToolbar), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly RoutedEvent ModeClickEvent = EventManager.RegisterRoutedEvent("ModeClick", RoutingStrategy.Bubble, typeof (RoutedEventHandler), typeof (AcpRecNavToolbar));
  private AcpXamDataPresenter dataPresenter;
  private bool deferToolbarUpdate;
  private int addMultQty = 1;
  private string defaultMaskType = "nnnn";
  private string maskMaxLength = "4";
  private int recordTypeToAdd;
  private string sMaxVal = "";
  internal StackPanel GrpNavigationToolBar;
  internal AcpLabel RecNavLbl;
  internal AcpButton RecNavBtnFirst;
  internal AcpButton RecNavBtnPrevious;
  internal AcpButton RecNavBtnNext;
  internal AcpButton RecNavBtnLast;
  internal AcpButton RecNavBtnGoTo;
  internal StackPanel GrpOperationToolBar;
  internal ContentControl DefCurrentRec;
  internal AcpButton RecNavAddMultiple;
  internal AcpButton RecNavBtnDelete;
  internal StackPanel GrpModeSelection;
  internal AcpButton RecNavChangeMode;
  private bool _contentLoaded;

  public AcpRecNavToolbar()
  {
    this.InitializeComponent();
    this.DataContextChanged += new DependencyPropertyChangedEventHandler(this.OnDataContextChanged);
  }

  ~AcpRecNavToolbar() => this.Dispose(false);

  protected virtual void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
  {
    if (e.OldValue != null && e.NewValue != null)
    {
      this.UnsubscribeFromRecordsetEvents((Recordset) e.OldValue);
      this.SubscribeToRecordsetEvents((Recordset) e.NewValue);
      this.Update();
    }
    else if (e.OldValue == null && e.NewValue != null)
    {
      this.SubscribeToRecordsetEvents((Recordset) e.NewValue);
      this.Update();
    }
    else
    {
      if (e.OldValue == null || e.NewValue != null)
        return;
      this.UnsubscribeFromRecordsetEvents((Recordset) e.OldValue);
    }
  }

  protected virtual void OnRecordsetPropertyChanged(object sender, PropertyChangedEventArgs e)
  {
    if (!(e.PropertyName == "CanAdd"))
      return;
    this.UpdateRecordOperationButtons();
  }

  public AcpXamDataPresenter MyDataPresenter
  {
    get => this.dataPresenter;
    set
    {
      if (this.dataPresenter == null && value != null)
      {
        this.SubscribeToDataPresenterEvents(value);
        this.dataPresenter = value;
        this.SelectAndActivateCurrentViewRecord();
      }
      else if (this.dataPresenter != null && value == null)
      {
        this.UnsubscribeFromDataPresenterEvents(this.dataPresenter);
        this.dataPresenter = (AcpXamDataPresenter) null;
      }
      else
      {
        if (this.dataPresenter == null || value == null)
          return;
        this.UnsubscribeFromDataPresenterEvents(this.dataPresenter);
        this.SubscribeToDataPresenterEvents(value);
        this.dataPresenter = value;
        this.SelectAndActivateCurrentViewRecord();
      }
    }
  }

  public bool IsAcpVisible
  {
    get => (bool) this.GetValue(AcpRecNavToolbar.IsAcpVisibleProperty);
    set => this.SetValue(AcpRecNavToolbar.IsAcpVisibleProperty, (object) value);
  }

  public bool IsAddMultQtyEn
  {
    get => (bool) this.GetValue(AcpRecNavToolbar.IsAddMultQtyEnProperty);
    set => this.SetValue(AcpRecNavToolbar.IsAddMultQtyEnProperty, (object) value);
  }

  public bool IsDefaultMaskTypeEn
  {
    get => (bool) this.GetValue(AcpRecNavToolbar.IsDefaultMaskTypeEnProperty);
    set => this.SetValue(AcpRecNavToolbar.IsDefaultMaskTypeEnProperty, (object) value);
  }

  public bool IsMaskMaxLengthEn
  {
    get => (bool) this.GetValue(AcpRecNavToolbar.IsMaskMaxLengthEnProperty);
    set => this.SetValue(AcpRecNavToolbar.IsMaskMaxLengthEnProperty, (object) value);
  }

  public IAcpRecordset MyRecordsetDataSource
  {
    get => (IAcpRecordset) this.DataContext;
    set => this.SetValue(AcpRecNavToolbar.MyRecordsetDataSourceProperty, (object) value);
  }

  public virtual IAcpRecordset MySecondaryRecordsetDataSource
  {
    get => (IAcpRecordset) this.GetValue(AcpRecNavToolbar.MySecondaryRecordsetDataSourceProperty);
    set
    {
      this.SetValue(AcpRecNavToolbar.MySecondaryRecordsetDataSourceProperty, (object) value);
      this.Update();
      this.SyncDataSources();
    }
  }

  public int GoToRecNum
  {
    get => (int) this.GetValue(AcpRecNavToolbar.GoToRecNumProperty);
    set => this.SetValue(AcpRecNavToolbar.GoToRecNumProperty, (object) value);
  }

  public int AddMultQty
  {
    get => this.addMultQty;
    set
    {
      this.addMultQty = value;
      this.RaisePropertyChanged(nameof (AddMultQty));
    }
  }

  public string DefaultMaskType
  {
    get => this.defaultMaskType;
    set
    {
      this.defaultMaskType = value;
      this.RaisePropertyChanged(nameof (DefaultMaskType));
    }
  }

  public string MaskMaxLength
  {
    get => this.maskMaxLength;
    set
    {
      this.maskMaxLength = value;
      this.RaisePropertyChanged(nameof (MaskMaxLength));
    }
  }

  public int RecordTypeToAdd
  {
    get => this.recordTypeToAdd;
    set
    {
      this.recordTypeToAdd = value;
      this.RaisePropertyChanged(nameof (RecordTypeToAdd));
    }
  }

  public bool TableMode
  {
    get => (bool) this.GetValue(AcpRecNavToolbar.TableModeProperty);
    set
    {
      if (this.TableMode && !value && this.dataPresenter != null)
      {
        this.UnsubscribeFromDataPresenterEvents(this.dataPresenter);
        if (this is AcpChildRecNavToolbar || this.MyRecordsetDataSource.IsEmbeddedRecset || this.MyRecordsetDataSource.HideRecordsFromTree || this.MyRecordsetDataSource.GetType().Name.Equals("URLTableRecset"))
        {
          this.GrpNavigationToolBar.Visibility = Visibility.Visible;
          this.GrpOperationToolBar.Visibility = Visibility.Collapsed;
        }
      }
      else if (!this.TableMode & value && this.dataPresenter != null)
      {
        this.SubscribeToDataPresenterEvents(this.dataPresenter);
        this.SelectAndActivateCurrentViewRecord();
        if (this is AcpChildRecNavToolbar || this.MyRecordsetDataSource.IsEmbeddedRecset || this.MyRecordsetDataSource.HideRecordsFromTree || this.MyRecordsetDataSource.GetType().Name.Equals("URLTableRecset"))
        {
          this.GrpNavigationToolBar.Visibility = Visibility.Collapsed;
          this.GrpOperationToolBar.Visibility = Visibility.Visible;
        }
      }
      this.SetValue(AcpRecNavToolbar.TableModeProperty, (object) value);
      if (!(this.TableMode & value) || this.dataPresenter == null)
        return;
      RecordPresenter recordPresenter = (RecordPresenter) null;
      if (this.dataPresenter.Records.Count > 0)
        recordPresenter = RecordPresenter.FromRecord(this.dataPresenter.ActiveRecord);
      if (recordPresenter != null)
        recordPresenter.Focus();
      else
        ((UIElement) this.dataPresenter).Focus();
    }
  }

  public string SMaxVal
  {
    get => this.sMaxVal;
    set
    {
      this.sMaxVal = value;
      this.RaisePropertyChanged(nameof (SMaxVal));
    }
  }

  public event RoutedEventHandler ModeClick
  {
    add => this.AddHandler(AcpRecNavToolbar.ModeClickEvent, (Delegate) value);
    remove => this.RemoveHandler(AcpRecNavToolbar.ModeClickEvent, (Delegate) value);
  }

  protected CollectionView GetCollectionViewForDataSource()
  {
    Recordset dataSource = this.GetDataSource();
    return dataSource == null ? (CollectionView) null : (CollectionView) CollectionViewSource.GetDefaultView((object) dataSource);
  }

  protected Recordset GetDataSource() => (Recordset) this.DataContext;

  protected bool DeferToolbarUpdate
  {
    get => this.deferToolbarUpdate;
    set => this.deferToolbarUpdate = value;
  }

  protected void SubscribeToRecordsetEvents(Recordset recset)
  {
    CollectionView defaultView = (CollectionView) CollectionViewSource.GetDefaultView((object) recset);
    recset.CollectionChanged += new NotifyCollectionChangedEventHandler(this.OnRecsetCollectionChanged);
    EventHandler eventHandler = new EventHandler(this.OnCollectionViewCurrentChanged);
    defaultView.CurrentChanged += eventHandler;
    recset.SubscribeToPropertyChangedEvent(new PropertyChangedEventHandler(this.OnRecordsetPropertyChanged));
  }

  protected void UnsubscribeFromRecordsetEvents(Recordset recset)
  {
    recset.CollectionChanged -= new NotifyCollectionChangedEventHandler(this.OnRecsetCollectionChanged);
    ((CollectionView) CollectionViewSource.GetDefaultView((object) recset)).CurrentChanged -= new EventHandler(this.OnCollectionViewCurrentChanged);
    recset.UnSubscribeFromPropertyChangedEvent(new PropertyChangedEventHandler(this.OnRecordsetPropertyChanged));
  }

  protected void SubscribeToDataPresenterEvents(AcpXamDataPresenter dataPresenter)
  {
    dataPresenter.SelectedItemsChanged += new EventHandler<SelectedItemsChangedEventArgs>(this.OnDataPresenterSelectedItemsChanged);
    dataPresenter.Records.CollectionChanged += new NotifyCollectionChangedEventHandler(this.OnDataPresenterRecordsChanged);
    dataPresenter.CellActivated += new EventHandler<CellActivatedEventArgs>(this.OnDataPresenterCellActivated);
  }

  protected void UnsubscribeFromDataPresenterEvents(AcpXamDataPresenter dataPresenter)
  {
    dataPresenter.SelectedItemsChanged -= new EventHandler<SelectedItemsChangedEventArgs>(this.OnDataPresenterSelectedItemsChanged);
    dataPresenter.Records.CollectionChanged -= new NotifyCollectionChangedEventHandler(this.OnDataPresenterRecordsChanged);
    dataPresenter.CellActivated -= new EventHandler<CellActivatedEventArgs>(this.OnDataPresenterCellActivated);
  }

  protected virtual bool CanMoveToFirst
  {
    get
    {
      if (AppInfoManager.AppMode == ApplicationMode.CustomViewConfigurationMode)
        return false;
      CollectionView viewForDataSource = this.GetCollectionViewForDataSource();
      return viewForDataSource.CurrentPosition != 0 && !viewForDataSource.IsCurrentBeforeFirst;
    }
  }

  protected virtual bool CanMoveToLast
  {
    get
    {
      if (AppInfoManager.AppMode == ApplicationMode.CustomViewConfigurationMode)
        return false;
      CollectionView viewForDataSource = this.GetCollectionViewForDataSource();
      return viewForDataSource.CurrentPosition != viewForDataSource.Count - 1 && !viewForDataSource.IsCurrentAfterLast;
    }
  }

  protected virtual bool CanAdd
  {
    get
    {
      if (AppInfoManager.AppMode == ApplicationMode.CustomViewConfigurationMode || AppInfoManager.AppMode == ApplicationMode.CodeplugComparisonMode)
        return false;
      Recordset dataSource = this.GetDataSource();
      if (this.RecordTypeToAdd == 0 && Permission.Have(Permissions.AddDefaultDisabled, dataSource.Permissions))
        return false;
      if (this.RecordTypeToAdd == 1)
      {
        CollectionView viewForDataSource = this.GetCollectionViewForDataSource();
        if (viewForDataSource != null && viewForDataSource.CurrentPosition >= 0)
          return dataSource.GetCounterToMaxCopiesOf(viewForDataSource.CurrentPosition) > 0;
        if (Permission.Have(Permissions.AddCurrentDisabled, dataSource.Permissions))
          return false;
      }
      return dataSource.CanAdd;
    }
  }

  protected virtual bool CanDelete
  {
    get
    {
      if (AppInfoManager.AppMode == ApplicationMode.CustomViewConfigurationMode || AppInfoManager.AppMode == ApplicationMode.CodeplugComparisonMode)
        return false;
      Recordset dataSource = this.GetDataSource();
      if (!dataSource.CanDelete)
        return false;
      if (this.MyDataPresenter == null)
        return true;
      if (!dataSource.CanBeEmpty && this.MyDataPresenter.SelectedItems.Records.Count == dataSource.Count || this.MyDataPresenter.Records.Count - this.MyDataPresenter.SelectedItems.Records.Count < dataSource.Min || this.MyDataPresenter.SelectedItems.Records.Count <= 0)
        return false;
      foreach (DataRecord record in this.MyDataPresenter.SelectedItems.Records)
      {
        IAcpFeatureNode dataItem = record.DataItem as IAcpFeatureNode;
        if ((!AppInfoManager.SkipValueSetter || !AppInfoManager.DropOperation) && !AppInfoManager.UndoRedoInProgress && Permission.Have(Permissions.Undeletable, dataItem.Permissions))
          return false;
      }
      return true;
    }
  }

  protected virtual bool CanGoTo
  {
    get
    {
      return AppInfoManager.AppMode != ApplicationMode.CustomViewConfigurationMode && this.GetCollectionViewForDataSource().Count > 1;
    }
  }

  protected virtual bool CanAddMultiple
  {
    get
    {
      if (AppInfoManager.AppMode == ApplicationMode.CustomViewConfigurationMode || AppInfoManager.AppMode == ApplicationMode.CodeplugComparisonMode)
        return false;
      Recordset dataSource = this.GetDataSource();
      if (this.RecordTypeToAdd == 1)
      {
        CollectionView viewForDataSource = this.GetCollectionViewForDataSource();
        if (viewForDataSource != null && viewForDataSource.CurrentPosition >= 0)
        {
          if (dataSource.GetCounterToMaxCopiesOf(viewForDataSource.CurrentPosition) <= 0)
            return false;
          if (this.MyDataPresenter.ActiveRecord != null && this.MyDataPresenter.ActiveRecord.Index != -1 && dataSource.Count > this.MyDataPresenter.ActiveRecord.Index)
          {
            IAcpFeatureNode acpFeatureNode = dataSource[this.MyDataPresenter.ActiveRecord.Index];
            if (acpFeatureNode != null && Permission.Have(Permissions.AddCurrentDisabled, acpFeatureNode.Permissions))
              return false;
          }
          return true;
        }
      }
      return dataSource.CanAdd;
    }
  }

  protected virtual bool CanSelectAddMode
  {
    get
    {
      if (AppInfoManager.AppMode == ApplicationMode.CustomViewConfigurationMode || AppInfoManager.AppMode == ApplicationMode.CodeplugComparisonMode)
        return false;
      if (this.GetCollectionViewForDataSource().Count != 0)
        return this.GetDataSource().CanAdd;
      this.RecordTypeToAdd = 0;
      return false;
    }
  }

  protected virtual bool CanEnableCurrentRecord
  {
    get
    {
      return AppInfoManager.AppMode != ApplicationMode.CustomViewConfigurationMode && AppInfoManager.AppMode != ApplicationMode.CodeplugComparisonMode;
    }
  }

  protected virtual bool CanChangeMode
  {
    get => AppInfoManager.AppMode != ApplicationMode.CustomViewConfigurationMode;
  }

  internal virtual void OnRecNavChangeModeClick(object sender, RoutedEventArgs e)
  {
    this.UpdateChangeModeButton();
    this.RaiseEvent(new RoutedEventArgs(AcpRecNavToolbar.ModeClickEvent));
  }

  protected virtual void OnClick(object sender, RoutedEventArgs e)
  {
    string name = ((FrameworkElement) sender).Name;
    if (name == null)
      return;
    switch (name.Length)
    {
      case 13:
        switch (name[9])
        {
          case 'G':
            if (!(name == "RecNavBtnGoTo"))
              return;
            this.OnRecNavBtnGoToClick(sender, e);
            return;
          case 'L':
            if (!(name == "RecNavBtnLast"))
              return;
            this.OnRecNavBtnLastClick(sender, e);
            return;
          case 'N':
            if (!(name == "RecNavBtnNext"))
              return;
            this.OnRecNavBtnNextClick(sender, e);
            return;
          default:
            return;
        }
      case 14:
        if (!(name == "RecNavBtnFirst"))
          break;
        this.OnRecNavBtnFirstClick(sender, e);
        break;
      case 15:
        if (!(name == "RecNavBtnDelete"))
          break;
        this.OnRecNavBtnDeleteClick(sender, e);
        break;
      case 17:
        switch (name[6])
        {
          case 'A':
            if (!(name == "RecNavAddMultiple"))
              return;
            this.OnRecNavBtnAddMultipleClick(sender, e);
            return;
          case 'B':
            if (!(name == "RecNavBtnPrevious"))
              return;
            this.OnRecNavBtnPreviousClick(sender, e);
            return;
          default:
            return;
        }
    }
  }

  protected virtual void OnRecNavBtnFirstClick(object sender, RoutedEventArgs e)
  {
    CollectionView viewForDataSource = this.GetCollectionViewForDataSource();
    viewForDataSource.MoveCurrentToFirst();
    if (this.MyDataPresenter == null)
      return;
    this.MyDataPresenter.BringRecordIntoView(viewForDataSource.CurrentPosition);
  }

  protected virtual void OnRecNavBtnPreviousClick(object sender, RoutedEventArgs e)
  {
    CollectionView viewForDataSource = this.GetCollectionViewForDataSource();
    viewForDataSource.MoveCurrentToPrevious();
    if (this.MyDataPresenter == null)
      return;
    this.MyDataPresenter.BringRecordIntoView(viewForDataSource.CurrentPosition);
  }

  protected virtual void OnRecNavBtnNextClick(object sender, RoutedEventArgs e)
  {
    CollectionView viewForDataSource = this.GetCollectionViewForDataSource();
    viewForDataSource.MoveCurrentToNext();
    if (this.MyDataPresenter == null)
      return;
    this.MyDataPresenter.BringRecordIntoView(viewForDataSource.CurrentPosition);
  }

  protected virtual void OnRecNavBtnLastClick(object sender, RoutedEventArgs e)
  {
    CollectionView viewForDataSource = this.GetCollectionViewForDataSource();
    viewForDataSource.MoveCurrentToLast();
    if (this.MyDataPresenter == null)
      return;
    this.MyDataPresenter.BringRecordIntoView(viewForDataSource.CurrentPosition);
  }

  protected virtual void OnRecNavBtnGoToClick(object sender, RoutedEventArgs e)
  {
    int goToRecNum = this.GoToRecNum;
    CollectionView viewForDataSource = this.GetCollectionViewForDataSource();
    int count = viewForDataSource.Count;
    if (goToRecNum < 1 || goToRecNum > count)
    {
      AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, AcpResources.Please_Enter_Number.AcpStringFormat((object) count));
    }
    else
    {
      int num = goToRecNum - 1;
      viewForDataSource.MoveCurrentToPosition(num);
      if (this.MyDataPresenter == null)
        return;
      this.MyDataPresenter.BringRecordIntoView(num);
    }
  }

  protected virtual void OnRecNavBtnAddMultipleClick(object sender, RoutedEventArgs e)
  {
    CollectionView viewForDataSource = this.GetCollectionViewForDataSource();
    Recordset dataSource = this.GetDataSource();
    int addMultQty = this.AddMultQty;
    if (addMultQty == 1)
    {
      if (this.RecordTypeToAdd == 0)
        dataSource.AddDefaultRecord();
      else
        dataSource.AddCopyOf(viewForDataSource.CurrentPosition);
    }
    else
    {
      int count;
      if (this.RecordTypeToAdd == 0)
      {
        count = dataSource.CounterToMax;
        if (addMultQty == 0)
        {
          AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, AcpResources.Please_Enter_Number.AcpStringFormat((object) count));
          return;
        }
        if (addMultQty <= count)
          dataSource.AddMultipleDefaultRecords(addMultQty);
        else
          dataSource.AddMultipleDefaultRecords(count);
      }
      else
      {
        int currentPosition = viewForDataSource.CurrentPosition;
        count = currentPosition < 0 ? dataSource.CounterToMax : dataSource.GetCounterToMaxCopiesOf(currentPosition);
        if (addMultQty == 0)
        {
          AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, AcpResources.Please_Enter_Number.AcpStringFormat((object) count));
          return;
        }
        if (addMultQty <= count)
          dataSource.AddMultipleCopiesOf(addMultQty, currentPosition);
        else
          dataSource.AddMultipleCopiesOf(count, currentPosition);
      }
      if (addMultQty <= count)
        return;
      AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, AcpResources.Unable_to_Add_Recs.AcpStringFormat((object) dataSource.UIName));
    }
  }

  protected virtual void OnTableModeDeleteClick(object sender, RoutedEventArgs e)
  {
    Recordset dataSource = this.GetDataSource();
    if (this.MyDataPresenter.SelectedItems.Records.Count > 1)
    {
      FeatureNode[] records = new FeatureNode[this.MyDataPresenter.SelectedItems.Records.Count];
      SortedList<int, FeatureNode> sortedList = new SortedList<int, FeatureNode>(records.Length);
      foreach (Record record in this.MyDataPresenter.SelectedItems.Records)
        sortedList.Add(record.Index, (FeatureNode) dataSource[record.Index]);
      for (int index = 0; index < sortedList.Values.Count; ++index)
        records[index] = sortedList.Values[sortedList.Values.Count - index - 1];
      dataSource.RemoveMultipleRecords(records);
    }
    else
    {
      Record record = this.MyDataPresenter.SelectedItems.Records[0];
      dataSource.RemoveRecordAt(record.Index);
    }
    if (this.MyDataPresenter.Records.Count != 0)
      return;
    this.Update(UpdateToolbarEventType.RecordOperation);
  }

  protected virtual void OnSingleRecordModeDeleteClick(object sender, RoutedEventArgs e)
  {
    this.GetDataSource().RemoveRecordAt(this.GetCollectionViewForDataSource().CurrentPosition);
  }

  protected virtual void OnRecNavBtnDeleteClick(object sender, RoutedEventArgs e)
  {
    if (this.TableMode)
      this.OnTableModeDeleteClick(sender, e);
    else
      this.OnSingleRecordModeDeleteClick(sender, e);
    if (!this.TableMode)
      return;
    this.SelectAndActivateCurrentViewRecord();
  }

  public void SyncDataSources()
  {
    if (AppInfoManager.AppMode != ApplicationMode.CodeplugComparisonMode || this.GetDataSource() == null || this.MySecondaryRecordsetDataSource == null)
      return;
    CollectionView defaultView1 = (CollectionView) CollectionViewSource.GetDefaultView((object) this.GetDataSource());
    CollectionView defaultView2 = (CollectionView) CollectionViewSource.GetDefaultView((object) this.MySecondaryRecordsetDataSource);
    IAcpFeatureNode currentItem = (IAcpFeatureNode) defaultView1.CurrentItem;
    if (currentItem != null)
    {
      if (currentItem.Parent.HasKeyField)
      {
        IAcpFeatureNode acpFeatureNode = (IAcpFeatureNode) null;
        if (this.MySecondaryRecordsetDataSource.Count > 0)
          acpFeatureNode = this.MySecondaryRecordsetDataSource.NodeFromKey(currentItem.ReferenceKey);
        if (acpFeatureNode != null)
          defaultView2.MoveCurrentTo((object) acpFeatureNode);
        else
          defaultView2.MoveCurrentToPosition(-1);
      }
      else
      {
        int position = defaultView1.IndexOf((object) currentItem);
        if (position < defaultView2.Count)
          defaultView2.MoveCurrentToPosition(position);
        else
          defaultView2.MoveCurrentToPosition(-1);
      }
    }
    else
    {
      if (!this.GetDataSource().CanBeEmpty || defaultView2 == null)
        return;
      defaultView2.MoveCurrentToPosition(-1);
    }
  }

  protected virtual void OnLoaded(object sender, RoutedEventArgs e)
  {
    if (this.DataContext != null)
      this.Update();
    this.GrpNavigationToolBar.Visibility = Visibility.Collapsed;
    this.GrpOperationToolBar.Visibility = Visibility.Visible;
    this.GrpModeSelection.Visibility = Visibility.Visible;
  }

  protected virtual void OnUnloaded(object sender, RoutedEventArgs e)
  {
    if (this.DataContext != null)
    {
      this.DataContextChanged -= new DependencyPropertyChangedEventHandler(this.OnDataContextChanged);
      this.UnsubscribeFromRecordsetEvents(this.GetDataSource());
    }
    this.MyDataPresenter = (AcpXamDataPresenter) null;
  }

  private void OnLostFocus(object sender, RoutedEventArgs e)
  {
    AcpTextBox acpTextBox = (AcpTextBox) sender;
    if (acpTextBox.Name == "TxtNumToAdd" && acpTextBox.Value == "")
    {
      acpTextBox.Value = "1";
      this.addMultQty = 0;
      this.addMultQty = 1;
    }
    else
    {
      if (!(acpTextBox.Name == "TxtGoTo") || !(acpTextBox.Value == ""))
        return;
      this.GoToRecNum = 0;
      this.GoToRecNum = 1;
    }
  }

  protected void UpdateCurrentRecordLabel()
  {
    CollectionView viewForDataSource = this.GetCollectionViewForDataSource();
    this.RecNavLbl.Content = (object) AcpResources.Of_Id.AcpStringFormat((object) (viewForDataSource.CurrentPosition + 1), (object) viewForDataSource.Count);
  }

  protected void UpdateNavigationButtons()
  {
    this.RecNavBtnFirst.IsEnabled = this.CanMoveToFirst;
    this.RecNavBtnPrevious.IsEnabled = this.RecNavBtnFirst.IsEnabled;
    this.RecNavBtnLast.IsEnabled = this.CanMoveToLast;
    this.RecNavBtnNext.IsEnabled = this.RecNavBtnLast.IsEnabled;
  }

  protected void UpdateRecordOperationButtons()
  {
    this.RecNavBtnGoTo.IsEnabled = this.CanGoTo;
    this.RecNavBtnDelete.IsEnabled = this.CanDelete;
    this.RecNavAddMultiple.IsEnabled = this.CanAddMultiple;
    this.DefCurrentRec.IsEnabled = this.CanSelectAddMode;
  }

  protected void UpdateChangeModeButton() => this.RecNavChangeMode.IsEnabled = this.CanChangeMode;

  internal void Update()
  {
    if (this.DeferToolbarUpdate)
      return;
    this.Update(UpdateToolbarEventType.ForcedUpdate);
  }

  internal virtual void Update(UpdateToolbarEventType eventType)
  {
    switch (eventType)
    {
      case UpdateToolbarEventType.Navigation:
        this.UpdateCurrentRecordLabel();
        this.UpdateNavigationButtons();
        break;
      case UpdateToolbarEventType.RecordOperation:
        this.UpdateCurrentRecordLabel();
        this.UpdateNavigationButtons();
        this.UpdateRecordOperationButtons();
        break;
      case UpdateToolbarEventType.ModeChange:
        this.UpdateChangeModeButton();
        break;
      case UpdateToolbarEventType.ForcedUpdate:
        this.UpdateCurrentRecordLabel();
        this.UpdateNavigationButtons();
        this.UpdateRecordOperationButtons();
        this.UpdateChangeModeButton();
        break;
    }
  }

  protected virtual void OnRecordAdded(object sender, NotifyCollectionChangedEventArgs e)
  {
    bool deferToolbarUpdate = this.DeferToolbarUpdate;
    this.UpdateViewCurrentPosition(e);
    this.DeferToolbarUpdate = deferToolbarUpdate;
  }

  protected virtual void OnRecordDeleted(object sender, NotifyCollectionChangedEventArgs e)
  {
    bool deferToolbarUpdate = this.DeferToolbarUpdate;
    this.UpdateViewCurrentPosition(e);
    this.DeferToolbarUpdate = deferToolbarUpdate;
  }

  protected virtual void OnRecordPositionMoved(object sender, NotifyCollectionChangedEventArgs e)
  {
    bool deferToolbarUpdate = this.DeferToolbarUpdate;
    this.UpdateViewCurrentPosition(e);
    this.DeferToolbarUpdate = deferToolbarUpdate;
  }

  protected virtual void UpdateViewCurrentPosition(NotifyCollectionChangedEventArgs e)
  {
    NotifyCollectionChangedAction action = e.Action;
    Recordset dataSource = this.GetDataSource();
    CollectionView viewForDataSource = this.GetCollectionViewForDataSource();
    int position;
    switch (action)
    {
      case NotifyCollectionChangedAction.Add:
        position = e.NewStartingIndex == -1 ? dataSource.Count - 1 : e.NewStartingIndex;
        break;
      case NotifyCollectionChangedAction.Remove:
        position = dataSource.Count <= 0 ? -1 : (e.OldStartingIndex < dataSource.Count ? e.OldStartingIndex : dataSource.Count - 1);
        break;
      case NotifyCollectionChangedAction.Move:
        position = e.NewStartingIndex;
        break;
      default:
        position = -1;
        break;
    }
    viewForDataSource.MoveCurrentToPosition(position);
  }

  protected virtual void OnRecsetCollectionChanged(
    object sender,
    NotifyCollectionChangedEventArgs e)
  {
    if (!this.TableMode)
    {
      if (e.Action == NotifyCollectionChangedAction.Add)
        this.OnRecordAdded(sender, e);
      else if (e.Action == NotifyCollectionChangedAction.Remove)
        this.OnRecordDeleted(sender, e);
      else if (e.Action == NotifyCollectionChangedAction.Move)
        this.OnRecordPositionMoved(sender, e);
    }
    else if (e.Action == NotifyCollectionChangedAction.Move)
      this.OnRecordPositionMoved(sender, e);
    if (this.DeferToolbarUpdate)
      return;
    this.Update(UpdateToolbarEventType.RecordOperation);
  }

  protected virtual void OnCollectionViewCurrentChanged(object sender, EventArgs e)
  {
    if (this.DeferToolbarUpdate)
      return;
    this.SyncDataSources();
    this.Update(UpdateToolbarEventType.Navigation);
    if (!this.TableMode)
      return;
    this.DeferToolbarUpdate = true;
    this.SelectAndActivateCurrentViewRecord();
    this.DeferToolbarUpdate = false;
  }

  protected internal virtual void OnUpdate(object sender, ToolbarUpdateEventArgs e)
  {
    if (this.DeferToolbarUpdate)
      return;
    this.Update(e.Event);
  }

  protected virtual void OnDataPresenterRecordsChanged(
    object sender,
    NotifyCollectionChangedEventArgs e)
  {
    if (this.DeferToolbarUpdate)
      return;
    if (e.Action == NotifyCollectionChangedAction.Add)
      this.OnRecordAdded(sender, e);
    else if (e.Action == NotifyCollectionChangedAction.Remove)
      this.OnRecordDeleted(sender, e);
    else if (e.Action == NotifyCollectionChangedAction.Move)
      this.OnRecordPositionMoved(sender, e);
    else if (e.Action == NotifyCollectionChangedAction.Reset && this.CanUpdate && ((RecordCollectionBase) sender).Count > 0)
    {
      CollectionView viewForDataSource = this.GetCollectionViewForDataSource();
      if (viewForDataSource.CurrentPosition != -1)
        this.SelectAndActivateCurrentViewRecord();
      else if (viewForDataSource.Count > 0)
        viewForDataSource.MoveCurrentToPosition(0);
    }
    if (!this.CanUpdate)
      return;
    this.Update(UpdateToolbarEventType.RecordOperation);
  }

  private void OnDataPresenterSelectedItemsChanged(object sender, SelectedItemsChangedEventArgs e)
  {
    if (this.DeferToolbarUpdate)
      return;
    CollectionView viewForDataSource = this.GetCollectionViewForDataSource();
    this.DeferToolbarUpdate = true;
    if (this.MyDataPresenter.ActiveRecord != null)
      viewForDataSource.MoveCurrentToPosition(this.MyDataPresenter.ActiveRecord.Index);
    this.DeferToolbarUpdate = false;
    this.Update(UpdateToolbarEventType.RecordOperation);
  }

  private void OnDataPresenterCellActivated(object sender, CellActivatedEventArgs e)
  {
    if (this.DeferToolbarUpdate)
      return;
    CollectionView viewForDataSource = this.GetCollectionViewForDataSource();
    this.DeferToolbarUpdate = true;
    if (this.MyDataPresenter.ActiveRecord != null)
      viewForDataSource.MoveCurrentToPosition(this.MyDataPresenter.ActiveRecord.Index);
    this.DeferToolbarUpdate = false;
    this.Update(UpdateToolbarEventType.RecordOperation);
  }

  protected bool CanUpdate
  {
    get => this.GetDataSource() != null && this.GetCollectionViewForDataSource() != null;
  }

  public void Dispose()
  {
    this.Dispose(true);
    GC.SuppressFinalize((object) this);
  }

  protected virtual void Dispose(bool disposing)
  {
    int num = disposing ? 1 : 0;
  }

  private void OnAddModeSelectionChanged(object sender, SelectionChangedEventArgs e)
  {
    if ((bool) DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof (DependencyObject)).DefaultValue)
      return;
    this.Update(UpdateToolbarEventType.RecordOperation);
  }

  protected void SelectAndActivateCurrentViewRecord()
  {
    CollectionView viewForDataSource = this.GetCollectionViewForDataSource();
    if (viewForDataSource.Count <= 0)
      return;
    if (viewForDataSource.CurrentPosition == -1)
      viewForDataSource.MoveCurrentToFirst();
    this.SelectAndActivateRecord(viewForDataSource.CurrentPosition);
  }

  protected void SelectAndActivateRecord(int index)
  {
    this.MyDataPresenter.SelectedItems.Records.Clear();
    if (index >= this.MyDataPresenter.Records.Count)
    {
      if (this.MyDataPresenter.Records.Count == 0)
        return;
      index = this.MyDataPresenter.Records.Count - 1;
    }
    Record record = this.MyDataPresenter.Records[index];
    record.IsActive = true;
    record.IsSelected = true;
    RecordPresenter.FromRecord(record)?.Focus();
    if (this.MyDataPresenter.MyExpander == null || this.MyDataPresenter.MyExpander.Visibility == Visibility.Collapsed)
      return;
    Recordset dataSource = this.GetDataSource();
    if (dataSource == null || !dataSource.LastRecordInOperation)
      return;
    this.MyDataPresenter.BringRecordIntoView(this.MyDataPresenter.Records[index]);
  }

  public event PropertyChangedEventHandler PropertyChanged;

  protected void RaisePropertyChanged(string propertyName)
  {
    if (this.PropertyChanged == null)
      return;
    this.PropertyChanged((object) this, new PropertyChangedEventArgs(propertyName));
  }

  private void TxtGoToTxtNumToAdd_TextChanged(object sender, TextChangedEventArgs e)
  {
    AcpTextBox acpTextBox = (AcpTextBox) sender;
    BindingExpression bindingExpression = acpTextBox.GetBindingExpression(TextBox.TextProperty);
    if (int.TryParse(acpTextBox.Value, out int _))
      return;
    e.Handled = true;
    bindingExpression.UpdateTarget();
  }

  private void TxtNumToAdd_MouseMove(object sender, MouseEventArgs e)
  {
    Recordset dataSource = this.GetDataSource();
    if (dataSource == null)
      return;
    if (this.RecordTypeToAdd == 0)
    {
      this.SMaxVal = AcpResources.ResourceManager.GetString("Add_Multiple_Counter_to_MAX", AcpResources.Culture) + dataSource.CounterToMax.ToString();
    }
    else
    {
      CollectionView viewForDataSource = this.GetCollectionViewForDataSource();
      this.SMaxVal = AcpResources.ResourceManager.GetString("Add_Multiple_Counter_to_MAX", AcpResources.Culture) + dataSource.GetCounterToMaxCopiesOf(viewForDataSource.CurrentPosition).ToString();
    }
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "8.0.3.0")]
  public void InitializeComponent()
  {
    if (this._contentLoaded)
      return;
    this._contentLoaded = true;
    Application.LoadComponent((object) this, new Uri("/AcpUI;component/acprecnavtoolbar.xaml", UriKind.Relative));
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "8.0.3.0")]
  internal Delegate _CreateDelegate(Type delegateType, string handler)
  {
    return Delegate.CreateDelegate(delegateType, (object) this, handler);
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "8.0.3.0")]
  [EditorBrowsable(EditorBrowsableState.Never)]
  void IComponentConnector.Connect(int connectionId, object target)
  {
    switch (connectionId)
    {
      case 1:
        ((FrameworkElement) target).Loaded += new RoutedEventHandler(this.OnLoaded);
        ((FrameworkElement) target).Unloaded += new RoutedEventHandler(this.OnUnloaded);
        break;
      case 2:
        this.GrpNavigationToolBar = (StackPanel) target;
        break;
      case 3:
        this.RecNavLbl = (AcpLabel) target;
        break;
      case 4:
        this.RecNavBtnFirst = (AcpButton) target;
        break;
      case 5:
        this.RecNavBtnPrevious = (AcpButton) target;
        break;
      case 6:
        this.RecNavBtnNext = (AcpButton) target;
        break;
      case 7:
        this.RecNavBtnLast = (AcpButton) target;
        break;
      case 8:
        this.RecNavBtnGoTo = (AcpButton) target;
        break;
      case 9:
        this.GrpOperationToolBar = (StackPanel) target;
        break;
      case 10:
        this.DefCurrentRec = (ContentControl) target;
        break;
      case 11:
        this.RecNavAddMultiple = (AcpButton) target;
        break;
      case 12:
        this.RecNavBtnDelete = (AcpButton) target;
        break;
      case 13:
        this.GrpModeSelection = (StackPanel) target;
        break;
      case 14:
        this.RecNavChangeMode = (AcpButton) target;
        break;
      default:
        this._contentLoaded = true;
        break;
    }
  }
}
