// Decompiled with JetBrains decompiler
// Type: AcpUI.AcpXamDataPresenter
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

using AcpBusinessLayer;
using AcpBusinessLayer.UndoRedo;
using AcpCommonLib;
using AcpCommonLib.FieldsReport;
using AcpCommonLib.UndoRedo;
using AcpCommonResources;
using AcpUILib;
using AcpUtility;
using Infragistics.Windows.DataPresenter;
using Infragistics.Windows.DataPresenter.Events;
using Infragistics.Windows.Editors;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows.Media;
using System.Windows.Media.Media3D;

#nullable disable
namespace AcpUI;

public class AcpXamDataPresenter : 
  XamDataPresenter,
  IAcpUICtrlBase,
  IAcpUIParentCtrlBase,
  IAcpUICommon
{
  private MouseButton lastMouseButtonChanged;
  private MouseButtonState lastMouseButtonChangedState;
  private static RoutedCommand RoutedCopyCommand = new RoutedCommand();
  private static RoutedCommand RoutedPasteCommand = new RoutedCommand();
  private string clipboardCellSeparator = "\t";
  private string clipboardRecordSeparator = "\r\n";
  private AcpExpander expander;
  private IAcpField myField;
  private IAcpFeatureSection mySection;
  private System.Windows.Controls.ContextMenu cntxMenu;
  private System.Windows.Controls.MenuItem mItemFillUp;
  private System.Windows.Controls.MenuItem mItemFillDown;
  private System.Windows.Controls.MenuItem mItemCopy;
  private System.Windows.Controls.MenuItem mItemPaste;
  private System.Windows.Controls.MenuItem mItemGoto;
  private System.Windows.Controls.MenuItem mItemDelete;
  public static readonly DependencyProperty IsAcpValidProperty = DependencyProperty.Register(nameof (IsAcpValid), typeof (bool), typeof (AcpXamDataPresenter), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty IsAcpApplicableProperty = DependencyProperty.Register(nameof (IsAcpApplicable), typeof (bool), typeof (AcpXamDataPresenter), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty IsAcpEditableProperty = DependencyProperty.Register(nameof (IsAcpEditable), typeof (bool), typeof (AcpXamDataPresenter), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty IsAcpVisibleProperty = DependencyProperty.Register(nameof (IsAcpVisible), typeof (bool), typeof (AcpXamDataPresenter), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty MyLabelCtrlProperty = DependencyProperty.RegisterAttached(nameof (MyLabelCtrl), typeof (IAcpUIChildCtrlBase), typeof (AcpXamDataPresenter), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty MyCopyButtonProperty = DependencyProperty.RegisterAttached(nameof (MyCopyButtonCtrl), typeof (IAcpUIChildCtrlBase), typeof (AcpXamDataPresenter), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty MyBLObjectProperty = DependencyProperty.RegisterAttached(nameof (MyBLObject), typeof (AcpFieldBase), typeof (AcpXamDataPresenter), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty AreValuesEqualProperty = DependencyProperty.Register(nameof (AreValuesEqual), typeof (bool), typeof (AcpXamDataPresenter), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty MyExpanderProperty = DependencyProperty.RegisterAttached(nameof (MyExpander), typeof (Expander), typeof (AcpXamDataPresenter), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty ShowDiffIconProperty = DependencyProperty.RegisterAttached(nameof (ShowDiffIcon), typeof (bool), typeof (AcpXamDataPresenter), (PropertyMetadata) new FrameworkPropertyMetadata((object) false, FrameworkPropertyMetadataOptions.AffectsRender));
  private XamDataGridDragDropBehavior xb;
  public static readonly DependencyProperty HeaderProperty = DependencyProperty.Register(nameof (Header), typeof (string), typeof (AcpXamDataPresenter), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

  public static RoutedCommand CopyCommand => AcpXamDataPresenter.RoutedCopyCommand;

  public static RoutedCommand PasteCommand => AcpXamDataPresenter.RoutedPasteCommand;

  public bool IsAcpValid
  {
    get => (bool) ((DependencyObject) this).GetValue(AcpXamDataPresenter.IsAcpValidProperty);
    set
    {
      ((DependencyObject) this).SetValue(AcpXamDataPresenter.IsAcpValidProperty, (object) value);
    }
  }

  public bool IsAcpApplicable
  {
    get => (bool) ((DependencyObject) this).GetValue(AcpXamDataPresenter.IsAcpApplicableProperty);
    set
    {
      ((DependencyObject) this).SetValue(AcpXamDataPresenter.IsAcpApplicableProperty, (object) value);
    }
  }

  public bool IsAcpEditable
  {
    get => (bool) ((DependencyObject) this).GetValue(AcpXamDataPresenter.IsAcpEditableProperty);
    set
    {
      ((DependencyObject) this).SetValue(AcpXamDataPresenter.IsAcpEditableProperty, (object) value);
    }
  }

  public bool IsAcpVisible
  {
    get => (bool) ((DependencyObject) this).GetValue(AcpXamDataPresenter.IsAcpVisibleProperty);
    set
    {
      ((DependencyObject) this).SetValue(AcpXamDataPresenter.IsAcpVisibleProperty, (object) value);
    }
  }

  public IAcpUIChildCtrlBase MyLabelCtrl
  {
    get
    {
      return (IAcpUIChildCtrlBase) ((DependencyObject) this).GetValue(AcpXamDataPresenter.MyLabelCtrlProperty);
    }
    set
    {
      ((DependencyObject) this).SetValue(AcpXamDataPresenter.MyLabelCtrlProperty, (object) value);
    }
  }

  public IAcpUIChildCtrlBase MyCopyButtonCtrl
  {
    get
    {
      return (IAcpUIChildCtrlBase) ((DependencyObject) this).GetValue(AcpXamDataPresenter.MyCopyButtonProperty);
    }
    set
    {
      ((DependencyObject) this).SetValue(AcpXamDataPresenter.MyCopyButtonProperty, (object) value);
    }
  }

  public AcpFieldBase MyBLObject
  {
    get
    {
      return (AcpFieldBase) ((DependencyObject) this).GetValue(AcpXamDataPresenter.MyBLObjectProperty);
    }
    set
    {
      ((DependencyObject) this).SetValue(AcpXamDataPresenter.MyBLObjectProperty, (object) value);
    }
  }

  public bool AreValuesEqual
  {
    get => (bool) ((DependencyObject) this).GetValue(AcpXamDataPresenter.AreValuesEqualProperty);
    set
    {
      ((DependencyObject) this).SetValue(AcpXamDataPresenter.AreValuesEqualProperty, (object) value);
    }
  }

  public Expander MyExpander
  {
    get => (Expander) ((DependencyObject) this).GetValue(AcpXamDataPresenter.MyExpanderProperty);
    set
    {
      ((DependencyObject) this).SetValue(AcpXamDataPresenter.MyExpanderProperty, (object) value);
    }
  }

  public bool ShowDiffIcon
  {
    get => (bool) ((DependencyObject) this).GetValue(AcpXamDataPresenter.ShowDiffIconProperty);
    set
    {
      ((DependencyObject) this).SetValue(AcpXamDataPresenter.ShowDiffIconProperty, (object) value);
    }
  }

  public AcpXamDataPresenter()
  {
    this.FieldSettings.CellClickAction = CellClickAction.SelectCell;
    this.InitializeMenuItems();
    if (this.xb == null)
    {
      this.xb = new XamDataGridDragDropBehavior();
      ((Behavior) this.xb).Attach((DependencyObject) this);
    }
    ((System.Windows.Controls.Control) this).Background = (Brush) Brushes.Transparent;
    this.GroupByAreaLocation = GroupByAreaLocation.None;
    if ((bool) DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof (DependencyObject)).DefaultValue)
      return;
    this.InitializeRecord += new EventHandler<InitializeRecordEventArgs>(this.OnInitializeRecord);
    this.mItemFillUp.Click += new RoutedEventHandler(this.mItemFillUp_Click);
    this.mItemFillDown.Click += new RoutedEventHandler(this.mItemFillDown_Click);
    this.mItemCopy.Click += new RoutedEventHandler(this.OnContextMenuItemCopyClick);
    this.mItemPaste.Click += new RoutedEventHandler(this.OnContextMenuItemPasteClick);
    this.mItemGoto.Click += new RoutedEventHandler(this.OnContextMenuItemGoto);
    this.mItemDelete.Click += new RoutedEventHandler(this.OnContextMenuItemDelete);
    ((FrameworkElement) this).Loaded += new RoutedEventHandler(this.OnLoaded);
    ((FrameworkElement) this).Unloaded += new RoutedEventHandler(this.OnUnloaded);
  }

  public string Header
  {
    get => (string) ((DependencyObject) this).GetValue(AcpXamDataPresenter.HeaderProperty);
    set => ((DependencyObject) this).SetValue(AcpXamDataPresenter.HeaderProperty, (object) value);
  }

  protected new string ClipboardCellSeparator
  {
    get => this.clipboardCellSeparator;
    set => this.clipboardCellSeparator = value;
  }

  protected new string ClipboardRecordSeparator
  {
    get => this.clipboardRecordSeparator;
    set => this.clipboardRecordSeparator = value;
  }

  protected virtual void OnContextMenuItemDelete(object sender, RoutedEventArgs e)
  {
    Recordset dataSource = (Recordset) this.DataSource;
    if (this.SelectedItems.Records.Count == 1)
    {
      Record record = this.SelectedItems.Records[0];
      dataSource.RemoveRecordAt(record.Index);
    }
    else
    {
      FeatureNode[] records = new FeatureNode[this.SelectedItems.Records.Count];
      SortedList<int, FeatureNode> sortedList = new SortedList<int, FeatureNode>(records.Length);
      foreach (Record record in this.SelectedItems.Records)
        sortedList.Add(record.Index, (FeatureNode) dataSource[record.Index]);
      for (int index = 0; index < sortedList.Values.Count; ++index)
        records[index] = sortedList.Values[sortedList.Values.Count - index - 1];
      dataSource.RemoveMultipleRecords(records);
    }
    CollectionView defaultView = (CollectionView) CollectionViewSource.GetDefaultView((object) dataSource);
    if (defaultView.Count <= 0)
      return;
    this.Records[defaultView.CurrentPosition].IsActive = true;
    this.Records[defaultView.CurrentPosition].IsSelected = true;
  }

  protected virtual void OnContextMenuItemGoto(object sender, RoutedEventArgs e)
  {
    if (!(this.myField is AcpRecRefField))
      return;
    FeatureNode featureNode = ((AcpRecRefField) this.myField).ReferencedNode;
    if (featureNode == null)
      return;
    Recordset parent = featureNode.Parent as Recordset;
    AcpKeyField keyField = featureNode.KeyField;
    if (parent.IsEmbeddedRecset && parent.Contains(featureNode))
    {
      featureNode = parent.ParentSection.Parent as FeatureNode;
      parent = featureNode.Parent as Recordset;
    }
    AcpCommonLib.FieldInfo info = new AcpCommonLib.FieldInfo((IAcpField) keyField);
    if (!parent.Contains(featureNode))
      return;
    AcpUI.Common.Utility.FieldReportSelectionChanged(sender, info);
  }

  protected virtual void OnContextMenuItemCopyClick(object sender, RoutedEventArgs e)
  {
    this.DoClipboardCopy();
  }

  protected virtual void OnContextMenuItemPasteClick(object sender, RoutedEventArgs e)
  {
    this.DoClipboardPaste();
  }

  private void OnExecuteCopyCommand(object sender, ExecutedRoutedEventArgs e)
  {
    this.DoClipboardCopy();
  }

  private void CanExecuteCopyCommand(object sender, CanExecuteRoutedEventArgs e)
  {
    e.CanExecute = this.CanEnableClipboardCopy;
  }

  private void OnExecutePasteCommand(object sender, ExecutedRoutedEventArgs e)
  {
    this.DoClipboardPaste();
  }

  private void CanExecutePasteCommand(object sender, CanExecuteRoutedEventArgs e)
  {
    e.CanExecute = this.CanEnableClipboardPaste;
  }

  private void PasteFieldValue(IAcpField targetField, string newValue, ContainerTask containerTask)
  {
    UndoableTask task = (UndoableTask) null;
    object sourcevalue = (object) null;
    PropertyInfo propertyInfo = (PropertyInfo) null;
    switch (targetField)
    {
      case AcpRecRefField _:
        AcpRecRefField acpRecRefField = (AcpRecRefField) targetField;
        sourcevalue = (object) newValue;
        task = (UndoableTask) new ModifyRecRefDataTask((AcpRecRefField) targetField, newValue);
        propertyInfo = acpRecRefField.GetType().GetProperty("UIValue");
        break;
      case AcpSparseLOVField _:
        AcpSparseLOVField acpSparseLovField = (AcpSparseLOVField) targetField;
        sourcevalue = (object) newValue;
        int newValue1 = (int) acpSparseLovField.Converter.ConvertBack((object) newValue, (System.Type) null, (object) acpSparseLovField.Parent, (CultureInfo) null);
        task = acpSparseLovField.GetModifyDataTask(newValue1);
        propertyInfo = acpSparseLovField.GetType().GetProperty("UIValue");
        break;
      case AcpCustomRangeField _:
        AcpCustomRangeField parameter = (AcpCustomRangeField) targetField;
        propertyInfo = parameter.GetType().GetProperty("UIValue");
        if (int.TryParse(newValue, out int _))
        {
          try
          {
            int num = (int) parameter.Converter.ConvertBack((object) newValue, (System.Type) null, (object) parameter, (CultureInfo) null);
            sourcevalue = (object) parameter.GetSpecialValue(num);
          }
          catch
          {
          }
        }
        else
          sourcevalue = (object) parameter.GetSpecialValue(newValue);
        if (sourcevalue == null)
          sourcevalue = (object) newValue;
        task = (UndoableTask) new ModifyUIValueTask<string>((AcpFieldBase) targetField, newValue);
        break;
      default:
        System.Type type1 = (System.Type) null;
        System.Type conversionType = (System.Type) null;
        System.Type type2 = targetField.GetType();
        if (this.IsSubclassOfGenericDeclaration(typeof (AcpFieldX<,>), type2))
        {
          type1 = typeof (ModifyUIValueTask<>);
          conversionType = this.GetUIValueTypeFrom(type2);
          propertyInfo = type2.GetProperty("UIValue");
        }
        else if (this.IsSubclassOfGenericDeclaration(typeof (AcpField<>), type2))
        {
          type1 = typeof (ModifyDataTask<>);
          conversionType = this.GetValueTypeFrom(type2);
          propertyInfo = type2.GetProperty("Value");
        }
        if (conversionType != (System.Type) null)
        {
          System.Type type3 = type1.MakeGenericType(conversionType);
          if (targetField.Name.Equals("BookmarkURL"))
          {
            AcpVoiceFileStruct acpVoiceFileStruct = new AcpVoiceFileStruct();
            byte[] numArray = Convert.FromBase64String(newValue);
            string str = Encoding.ASCII.GetString(numArray);
            acpVoiceFileStruct.voiceData = new MemoryStream(numArray, 0, numArray.Length, true, true);
            acpVoiceFileStruct.voicefile = str;
            sourcevalue = (object) acpVoiceFileStruct;
          }
          else
            sourcevalue = Convert.ChangeType((object) newValue, conversionType);
          if (this.IsSubclassOfGenericDeclaration(typeof (AcpFieldX<,>), type2))
          {
            if (targetField is AcpFrequencyField)
            {
              task = ((AcpFieldX<int, string>) targetField).CopyUIValue(sourcevalue);
              break;
            }
            task = (UndoableTask) Activator.CreateInstance(type3, (object) targetField, sourcevalue);
            break;
          }
          task = targetField.CopyValue(sourcevalue);
          break;
        }
        break;
    }
    if (task == null)
      throw new InvalidOperationException("Target field type not handled");
    containerTask.AddTask(task);
    if (!this.AreObjectValuesEqual(propertyInfo.GetValue((object) targetField, (object[]) null), sourcevalue))
      throw new InvalidOperationException("Target field value is not supported");
  }

  private bool AreObjectValuesEqual(object value1, object value2)
  {
    double result1;
    double result2;
    return double.TryParse(Convert.ToString(value1), out result1) && double.TryParse(Convert.ToString(value2), out result2) ? result1 == result2 : object.Equals(value1, value2);
  }

  private System.Type GetUIValueTypeFrom(System.Type fieldType)
  {
    for (System.Type type = fieldType; type != typeof (object); type = type.BaseType)
    {
      if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof (AcpFieldX<,>))
        return type.GetGenericArguments()[1];
    }
    return (System.Type) null;
  }

  private System.Type GetValueTypeFrom(System.Type fieldType)
  {
    for (System.Type type = fieldType; type != typeof (object); type = type.BaseType)
    {
      if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof (AcpField<>))
        return type.GetGenericArguments()[0];
    }
    return (System.Type) null;
  }

  private bool IsSubclassOfGenericDeclaration(System.Type baseType, System.Type derivedType)
  {
    for (System.Type type = derivedType; type != typeof (object); type = type.BaseType)
    {
      if (type.IsGenericType)
        type = type.GetGenericTypeDefinition();
      if (type == baseType)
        return true;
    }
    return false;
  }

  public bool CanDragDrop
  {
    get
    {
      bool flag = true;
      if (AppInfoManager.AppMode != ApplicationMode.CodeplugConfigurationMode)
        return false;
      Recordset dataSource = (Recordset) this.DataSource;
      if (dataSource.IsEmbeddedRecset && dataSource.ParentSection != null && dataSource[0] is FeatureNode featureNode)
      {
        foreach (IAcpField allField in featureNode.AllFields)
        {
          string str = allField.DifferentiatedUserView.ToString();
          if (!(str == "Labtool") && !(str == "Depot"))
          {
            flag = true;
            break;
          }
          flag = false;
        }
      }
      return !(dataSource.RecordsetName == "Unified Call List") && (dataSource.CanAdd || dataSource.CanDelete) && flag;
    }
  }

  protected virtual bool CanEnableDelete
  {
    get
    {
      if (AppInfoManager.AppMode == ApplicationMode.CustomViewConfigurationMode || AppInfoManager.AppMode == ApplicationMode.CodeplugComparisonMode)
        return false;
      Recordset dataSource = (Recordset) this.DataSource;
      return dataSource.CanDelete && (dataSource.CanBeEmpty || this.SelectedItems.Records.Count != dataSource.Count) && this.Records.Count - this.SelectedItems.Records.Count >= dataSource.Min && this.SelectedItems.Records.Count > 0;
    }
  }

  protected virtual bool CanEnableClipboardCopy
  {
    get
    {
      bool flag1 = this.SelectedItems.Records.Count > 0;
      bool flag2 = true;
      if (flag1)
      {
        Recordset dataSource = (Recordset) this.DataSource;
        for (int index = 0; index < this.SelectedItems.Records.Count; ++index)
        {
          if (Permission.Have(Permissions.CopyDisabled, ((FeatureNode) dataSource[this.SelectedItems.Records[index].Index]).Permissions))
          {
            flag2 = false;
            break;
          }
        }
      }
      return this.IsDataRecordView & flag1 & flag2;
    }
  }

  protected virtual bool CanEnableClipboardPaste
  {
    get
    {
      bool flag1 = this.SelectedItems.Records.Count == 1;
      bool flag2 = true;
      if (flag1 && Permission.Have(Permissions.CopyDisabled, ((FeatureNode) ((Recordset) this.DataSource)[this.SelectedItems.Records[0].Index]).Permissions))
        flag2 = false;
      return ((!this.IsDataRecordView || !System.Windows.Clipboard.ContainsText() ? 0 : (this.Records.Count > 0 ? 1 : 0)) & (flag1 ? 1 : 0) & (flag2 ? 1 : 0)) != 0;
    }
  }

  private int GetPasteRowsCount(List<string[]> clipboardRecords, int pasteRowsCount)
  {
    int rowIndex = CellPosition.GetRowIndex(this.ActiveCell);
    int count = this.Records.Count;
    return pasteRowsCount + rowIndex > count ? count - rowIndex : pasteRowsCount;
  }

  private int GetPasteColumnsCount(List<string[]> clipboardRecords, int pasteColumnsCount)
  {
    int columnIndex = CellPosition.GetColumnIndex(this.ActiveCell);
    int columnsGenerated = this.FieldLayouts[0].TotalColumnsGenerated;
    return pasteColumnsCount + columnIndex > columnsGenerated ? columnsGenerated - columnIndex : pasteColumnsCount;
  }

  private List<bool?> GetDataRecordAvailableCellsLayout()
  {
    bool flag = false;
    List<bool?> availableCellsLayout = (List<bool?>) null;
    foreach (DataRecord record in (IEnumerable<Record>) this.Records)
    {
      CellCollection cells = record.Cells;
      availableCellsLayout = new List<bool?>(cells.Count);
      foreach (Cell cell in (IEnumerable<Cell>) cells)
      {
        if (cell.Field.Visibility == Visibility.Visible)
        {
          if (cell.Value != null)
          {
            CellValuePresenter cellValuePresenter = CellValuePresenter.FromCell(cell);
            if (cellValuePresenter != null && cellValuePresenter.Value is IAcpField)
            {
              availableCellsLayout.Add(new bool?(true));
              flag = true;
            }
            else
              availableCellsLayout.Add(new bool?(false));
          }
          else
            availableCellsLayout.Add(new bool?(false));
        }
        else
          availableCellsLayout.Add(new bool?());
      }
      if (flag)
        break;
    }
    return availableCellsLayout;
  }

  private List<AcpFieldToTableCellPairingInfo> GetAcpFieldToTableCellPairings(DataRecord dataRecord)
  {
    List<AcpFieldToTableCellPairingInfo> tableCellPairings = new List<AcpFieldToTableCellPairingInfo>();
    foreach (Cell cell in (IEnumerable<Cell>) dataRecord.Cells)
    {
      if (cell.Field.Visibility == Visibility.Visible)
      {
        CellValuePresenter cellValuePresenter = CellValuePresenter.FromCell(cell);
        AcpFieldToTableCellPairingInfo tableCellPairingInfo = cellValuePresenter == null || !(cellValuePresenter.Value is IAcpField) ? AcpFieldToTableCellPairingInfo.CreateFrom((IAcpField) null, cell) : AcpFieldToTableCellPairingInfo.CreateFrom((IAcpField) cellValuePresenter.Value, cell);
        tableCellPairings.Add(tableCellPairingInfo);
      }
    }
    return tableCellPairings;
  }

  protected SortedList<int, Record> GetSortedSelectedRecords()
  {
    SortedList<int, Record> sortedSelectedRecords = new SortedList<int, Record>(this.SelectedItems.Records.Count);
    foreach (Record record in this.SelectedItems.Records)
      sortedSelectedRecords.Add(record.Index, record);
    return sortedSelectedRecords;
  }

  protected HitTestResultBehavior HitTestResultFunc(HitTestResult result)
  {
    DependencyObject parent = VisualTreeHelper.GetParent(result.VisualHit);
    if (parent == null || !(parent is RecordSelector recordSelector))
      return HitTestResultBehavior.Continue;
    Record record = recordSelector.Record;
    if (record.IsActive)
      record.DataPresenter.ActiveCell = (Cell) null;
    RecordPresenter.FromRecord(record).Focus();
    return HitTestResultBehavior.Stop;
  }

  internal HitTestFilterBehavior HitTestFilterFunc(DependencyObject hitTestTarget)
  {
    return HitTestFilterBehavior.Continue;
  }

  protected virtual void DoClipboardCopy()
  {
    try
    {
      SortedList<int, Record> sortedSelectedRecords = this.GetSortedSelectedRecords();
      StringBuilder stringBuilder = new StringBuilder();
      int num = 0;
      List<bool?> availableCellsLayout = this.GetDataRecordAvailableCellsLayout();
      if (availableCellsLayout == null)
        throw new InvalidOperationException("Cannot retrieve cell values.");
      foreach (DataRecord dataRecord in (IEnumerable<Record>) sortedSelectedRecords.Values)
      {
        bool flag = true;
        CellCollection cells = dataRecord.Cells;
        int count = cells.Count;
        for (int index = 0; index < count; ++index)
        {
          bool? nullable = availableCellsLayout[index];
          if (nullable.HasValue)
          {
            string empty;
            if (nullable.Value)
            {
              Cell cell = cells[index];
              switch (TableCellInfo.GetCellUIElement(cell))
              {
                case AcpPasswordBox _:
label_9:
                  empty = string.Empty;
                  goto label_12;
                case AcpPasswordEyeBox acpPasswordEyeBox:
                  if (acpPasswordEyeBox.IsCopyEnabled)
                    break;
                  goto label_9;
              }
              empty = cell.ConvertedValue.ToString();
            }
            else
              empty = string.Empty;
label_12:
            if (flag)
            {
              stringBuilder.Append(empty);
              flag = false;
            }
            else
              stringBuilder.AppendFormat("{0}{1}", (object) this.ClipboardCellSeparator, (object) empty);
          }
        }
        stringBuilder.Append(this.ClipboardRecordSeparator);
        ++num;
      }
      System.Windows.Clipboard.Clear();
      System.Windows.Clipboard.SetText(stringBuilder.ToString());
      AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Info, AcpResources.Num_Recs_Copied_to_Clipboard.AcpStringFormat((object) num));
    }
    catch (Exception ex)
    {
      AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, AcpResources.Clipboard_Copy_Aborted);
    }
  }

  private bool CanFieldAcceptValue(IAcpField acpField, string value, TableCellInfo cellInfo)
  {
    if (acpField.Name == "TrkSysGeneralAskRequired_A44909" && value == bool.TrueString)
      return true;
    if (!acpField.Editable || !acpField.Applicable || !acpField.Visible)
      return false;
    if (!(cellInfo is MaskedTableCellInfo))
      return true;
    XamMaskedEditor xamMaskedEditor = new XamMaskedEditor();
    xamMaskedEditor.Mask = ((MaskedTableCellInfo) cellInfo).Mask;
    xamMaskedEditor.PadChar = ' ';
    xamMaskedEditor.PromptChar = '_';
    xamMaskedEditor.DisplayMode = (MaskMode) 1;
    if (acpField is AcpFrequencyField)
      xamMaskedEditor.Mask = xamMaskedEditor.Mask.Replace("3.5", "3.6");
    Exception exception;
    return ((ValueEditor) xamMaskedEditor).ValidateValue((object) value, ref exception);
  }

  private int PasteRecords(
    List<string[]> clipboardRecords,
    Cell anchorCell,
    int pasteRowsCount,
    int pasteColumnsCount)
  {
    ContainerTask containerTask = (ContainerTask) null;
    int num1 = 0;
    try
    {
      List<AcpFieldToTableCellPairingInfo> tableCellPairings = this.GetAcpFieldToTableCellPairings(anchorCell.Record);
      if (!(this.DataSource is Recordset dataSource))
        return 0;
      int count = tableCellPairings.Count;
      containerTask = new ContainerTask(AcpResources.Paste_Id);
      CellPosition cellPosition = CellPosition.FromCell(anchorCell);
      int columnIndex = cellPosition.ColumnIndex;
      StringBuilder stringBuilder = new StringBuilder();
      int rowIndex = cellPosition.RowIndex;
      int index1 = rowIndex;
      for (int index2 = index1 + pasteRowsCount - 1; index1 <= index2; ++index1)
      {
        IAcpFeatureNode acpFeatureNode = dataSource[index1];
        if (Permission.Have(Permissions.CopyDisabled, acpFeatureNode.Permissions))
        {
          stringBuilder.Clear().Append(AcpResources.Paste_Not_Allowed.AcpStringFormat((object) (index1 + 1)));
          AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Warning, stringBuilder.ToString());
        }
        else
        {
          int index3 = index1 - rowIndex;
          string[] clipboardRecord = clipboardRecords[index3];
          int num2 = 0;
          IAcpField acpField1 = (IAcpField) null;
          string newValue1 = (string) null;
          AcpFieldToTableCellPairingInfo tableCellPairingInfo1 = (AcpFieldToTableCellPairingInfo) null;
          for (int index4 = 0; index4 < pasteColumnsCount; ++index4)
          {
            string newValue2 = clipboardRecord[index4];
            if (newValue2 != null)
            {
              AcpFieldToTableCellPairingInfo tableCellPairingInfo2 = tableCellPairings[columnIndex + index4];
              try
              {
                if (tableCellPairingInfo2.FieldInfo == null)
                  throw new InvalidOperationException(AcpResources.Field_Cannot_Accept_Value);
                IAcpField acpField2 = acpFeatureNode[tableCellPairingInfo2.FieldInfo.SectionID][tableCellPairingInfo2.FieldInfo.FieldName];
                if (acpField2.Name == "TrkSysGeneralAskRequired_A44909" && newValue2 == bool.TrueString)
                {
                  acpField1 = acpField2;
                  newValue1 = newValue2;
                  tableCellPairingInfo1 = tableCellPairingInfo2;
                }
                else
                {
                  if (!this.CanFieldAcceptValue(acpField2, newValue2, tableCellPairingInfo2.CellInfo))
                    throw new InvalidOperationException(AcpResources.Field_Cannot_Accept_Value);
                  this.PasteFieldValue(acpField2, newValue2, containerTask);
                  ++num2;
                }
              }
              catch (Exception ex)
              {
                stringBuilder.Clear().Append(AcpResources.Value_Not_Pasted.AcpStringFormat((object) tableCellPairingInfo2.CellInfo.ColumnName, (object) (index1 + 1)));
                stringBuilder.Append(" ");
                stringBuilder.Append(ex.Message);
                AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Warning, stringBuilder.ToString());
              }
            }
          }
          if (acpField1 != null && newValue1 != null)
          {
            if (tableCellPairingInfo1 != null)
            {
              try
              {
                if (!this.CanFieldAcceptValue(acpField1, newValue1, tableCellPairingInfo1.CellInfo))
                  throw new InvalidOperationException(AcpResources.Field_Cannot_Accept_Value);
                this.PasteFieldValue(acpField1, newValue1, containerTask);
                ++num2;
              }
              catch (Exception ex)
              {
                stringBuilder.Clear().Append(AcpResources.Value_Not_Pasted.AcpStringFormat((object) tableCellPairingInfo1.CellInfo.ColumnName, (object) (index1 + 1)));
                stringBuilder.Append(" ");
                stringBuilder.Append(ex.Message);
                AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Warning, stringBuilder.ToString());
              }
            }
          }
          if (num2 > 0)
            ++num1;
        }
      }
      UndoManager.AddTask((UndoableTask) containerTask);
    }
    catch (Exception ex)
    {
      containerTask?.Undo();
      throw ex;
    }
    return num1;
  }

  private void CheckActiveCell()
  {
    if (this.ActiveCell != null)
      return;
    (this.SelectedItems.Records[0] as DataRecord).Cells[0].IsActive = true;
  }

  protected virtual void DoClipboardPaste()
  {
    try
    {
      List<string[]> clipboardData = this.GetClipboardData();
      if (clipboardData.Count == 0)
      {
        AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Info, AcpResources.No_Records_Clipboard.AcpStringFormat());
      }
      else
      {
        this.CheckActiveCell();
        int pasteRowsCount = this.GetPasteRowsCount(clipboardData, clipboardData.Count);
        if (clipboardData.Count > pasteRowsCount)
          AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Warning, AcpResources.Insufficient_Num_Rows.AcpStringFormat((object) (clipboardData.Count - pasteRowsCount)));
        int pasteColumnsCount = this.GetPasteColumnsCount(clipboardData, clipboardData[0].Length);
        if (clipboardData[0].Length > pasteColumnsCount)
          AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Warning, AcpResources.Insufficient_Num_Columns.AcpStringFormat((object) (clipboardData[0].Length - pasteColumnsCount)));
        AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Info, AcpResources.Recs_Pasted_Clipboard.AcpStringFormat((object) this.PasteRecords(clipboardData, this.ActiveCell, pasteRowsCount, pasteColumnsCount)));
      }
    }
    catch (Exception ex)
    {
      AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, ex.Message);
      AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, AcpResources.Paste_Opn_Abort);
    }
  }

  protected virtual List<string[]> GetClipboardData()
  {
    if (!System.Windows.Clipboard.ContainsText())
      return new List<string[]>();
    string[] strArray1 = System.Windows.Clipboard.GetText().Split(new string[1]
    {
      this.ClipboardRecordSeparator
    }, StringSplitOptions.RemoveEmptyEntries);
    if (strArray1.Length == 0)
      return new List<string[]>();
    int length = strArray1.Length;
    List<string[]> clipboardData = new List<string[]>(length);
    string[] separator = new string[1]
    {
      this.ClipboardCellSeparator
    };
    int num = -1;
    for (int index = 0; index < length; ++index)
    {
      string[] strArray2 = strArray1[index].Split(separator, StringSplitOptions.None);
      if (num == -1)
        num = strArray2.Length;
      if (num != strArray2.Length)
        throw new RankException("Records must all have the same number of fields.");
      clipboardData.Add(strArray2);
    }
    return clipboardData;
  }

  private void SetActiveCell(CellValuePresenter cvp) => this.ActiveCell = this.GetCellFrom(cvp);

  private Cell GetCellFrom(CellValuePresenter cvp) => cvp.Record.Cells[cvp.Field];

  private CellPosition GetActiveCellPosition() => CellPosition.FromCell(this.ActiveCell);

  internal bool IsDataRecordView => this.Records is DataRecordCollection;

  protected override void OnRecordAdded(RecordAddedEventArgs args)
  {
    base.OnRecordAdded(args);
    // ISSUE: explicit non-virtual call
    // ISSUE: explicit non-virtual call
    __nonvirtual (((FrameworkElement) this).Height) = __nonvirtual (((FrameworkElement) this).Height) + RecordPresenter.FromRecord((Record) args.Record).ActualHeight;
    ((UIElement) this).InvalidateVisual();
  }

  protected override void OnRecordsDeleted(RecordsDeletedEventArgs args)
  {
    base.OnRecordsDeleted(args);
  }

  protected override void OnRecordsInViewChanged(RecordsInViewChangedEventArgs args)
  {
    base.OnRecordsInViewChanged(args);
    foreach (DataRecord dataRecord in this.GetRecordsInView(false))
    {
      foreach (Cell cell in (IEnumerable<Cell>) dataRecord.Cells)
      {
        if (cell.Field.Visibility == Visibility.Visible)
        {
          CellValuePresenter reference1 = CellValuePresenter.FromCell(cell);
          if (reference1 != null)
          {
            object child1 = (object) VisualTreeHelper.GetChild((DependencyObject) reference1, 0);
            if (VisualTreeHelper.GetChild((DependencyObject) reference1, 0) is System.Windows.Controls.Panel child3)
            {
              reference2 = (ContentPresenter) null;
              foreach (UIElement child2 in child3.Children)
              {
                if (child2 is ContentPresenter reference2)
                  break;
              }
              if (reference2 != null)
                child1 = (object) (VisualTreeHelper.GetChild((DependencyObject) reference2, 0) as UIElement);
            }
            if (child1 is AcpTableComboBox acpTableComboBox)
              acpTableComboBox.GetBindingExpression(Selector.SelectedValueProperty).UpdateTarget();
          }
        }
      }
    }
  }

  private void AdjustColumnWidths(FieldCollection fields)
  {
    if (!(this.DataSource is Recordset dataSource) || !dataSource.IsEmbeddedRecset)
      return;
    int count = fields.Count;
    Field field = count > 1 ? fields[count - 2] : fields[count - 1];
    field.PerformAutoSize(field.CalculateAutoSizeExtent(FieldAutoSizeOptions.DataCells, FieldAutoSizeScope.RecordsInView) < field.CalculateAutoSizeExtent(FieldAutoSizeOptions.Label, FieldAutoSizeScope.RecordsInView) ? FieldAutoSizeOptions.DataCells : FieldAutoSizeOptions.Label, FieldAutoSizeScope.RecordsInView);
    field.PerformAutoSize(FieldAutoSizeOptions.All, FieldAutoSizeScope.RecordsInView);
  }

  protected virtual void OnPreviewMouseRightButtonDown(MouseButtonEventArgs e)
  {
    this.ActiveRecord.IsSelected = true;
    this.SaveLastMouseButtonChangedInfo(e);
    // ISSUE: explicit non-virtual call
    __nonvirtual (((UIElement) this).OnPreviewMouseRightButtonDown(e));
  }

  protected override void OnCellActivated(CellActivatedEventArgs args)
  {
    base.OnCellActivated(args);
    if (!args.Cell.Record.IsSelected || this.lastMouseButtonChanged == MouseButton.Left && this.lastMouseButtonChangedState == MouseButtonState.Pressed)
      this.SelectedItems.Records.Clear();
    if (this.lastMouseButtonChanged == MouseButton.Right)
      this.ActiveRecord.IsSelected = true;
    Cell cell = args.Cell;
    if (cell == null)
      return;
    DependencyObject reference1 = (DependencyObject) CellValuePresenter.FromCell(cell);
    if (reference1 == null)
      return;
    object child1 = (object) VisualTreeHelper.GetChild(reference1, 0);
    if (VisualTreeHelper.GetChild(reference1, 0) is System.Windows.Controls.Panel child3)
    {
      reference2 = (ContentPresenter) null;
      foreach (UIElement child2 in child3.Children)
      {
        if (child2 is ContentPresenter reference2)
          break;
      }
      if (reference2 != null)
        child1 = (object) (VisualTreeHelper.GetChild((DependencyObject) reference2, 0) as UIElement);
    }
    UIElement uiElement = (UIElement) child1;
    if (!(child1 is IAcpUICtrlBase) || !uiElement.IsVisible || !uiElement.IsEnabled || !uiElement.Focusable || !((IAcpUICtrlBase) child1).IsAcpApplicable)
      return;
    uiElement.Focus();
  }

  protected override void OnInitializeRecord(InitializeRecordEventArgs args)
  {
    base.OnInitializeRecord(args);
    args.Record.ExpansionIndicatorVisibility = Visibility.Collapsed;
  }

  protected override void OnSelectedItemsChanging(SelectedItemsChangingEventArgs args)
  {
    if (args.Type != typeof (Record) && args.Type != typeof (DataRecord) && args.Type != typeof (GroupByRecord))
      args.Cancel = true;
    else
      base.OnSelectedItemsChanging(args);
  }

  protected override void OnSelectedItemsChanged(SelectedItemsChangedEventArgs args)
  {
    if (args == null)
      return;
    base.OnSelectedItemsChanged(args);
  }

  protected override void OnRecordActivated(RecordActivatedEventArgs args)
  {
    base.OnRecordActivated(args);
  }

  private void OnLoaded(object sender, RoutedEventArgs e)
  {
    ((UIElement) this).InputBindings.Add((InputBinding) new KeyBinding((ICommand) AcpXamDataPresenter.CopyCommand, new KeyGesture(Key.C, ModifierKeys.Control)));
    ((UIElement) this).InputBindings.Add((InputBinding) new KeyBinding((ICommand) AcpXamDataPresenter.PasteCommand, new KeyGesture(Key.V, ModifierKeys.Control)));
    ((UIElement) this).CommandBindings.Add(new CommandBinding((ICommand) AcpXamDataPresenter.CopyCommand, new ExecutedRoutedEventHandler(this.OnExecuteCopyCommand), new CanExecuteRoutedEventHandler(this.CanExecuteCopyCommand)));
    ((UIElement) this).CommandBindings.Add(new CommandBinding((ICommand) AcpXamDataPresenter.PasteCommand, new ExecutedRoutedEventHandler(this.OnExecutePasteCommand), new CanExecuteRoutedEventHandler(this.CanExecutePasteCommand)));
    this.FieldLayoutSettings.HighlightAlternateRecords = new bool?(true);
    this.expander = this.FindPageExpander(this);
    this.GroupByAreaLocation = GroupByAreaLocation.None;
    this.FieldSettings.LabelClickAction = LabelClickAction.Nothing;
    if (this.DataSource is Recordset dataSource && dataSource.IsEmbeddedRecset)
    {
      int height = Screen.PrimaryScreen.WorkingArea.Height;
      if (height > 0)
      {
        double d = (double) (30 * height / 994);
        if (height < 900)
          d -= 2.0;
        ((FrameworkElement) this).MaxHeight = 25.0 * Math.Floor(d) + 1.0;
      }
    }
    ((FrameworkElement) this).Loaded -= new RoutedEventHandler(this.OnLoaded);
  }

  private void OnUnloaded(object sender, RoutedEventArgs e)
  {
    if (this.xb != null)
    {
      ((Behavior) this.xb).Detach();
      this.xb = (XamDataGridDragDropBehavior) null;
    }
    this.FieldLayoutSettings = (FieldLayoutSettings) null;
    ((FrameworkElement) this).Loaded -= new RoutedEventHandler(this.OnLoaded);
    ((FrameworkElement) this).Unloaded -= new RoutedEventHandler(this.OnUnloaded);
    this.expander = (AcpExpander) null;
    this.mItemCopy.Click -= new RoutedEventHandler(this.OnContextMenuItemCopyClick);
    this.mItemPaste.Click -= new RoutedEventHandler(this.OnContextMenuItemPasteClick);
    KeyBinding keyBinding1 = (KeyBinding) null;
    KeyBinding keyBinding2 = (KeyBinding) null;
    foreach (InputBinding inputBinding in ((UIElement) this).InputBindings)
    {
      if (inputBinding is KeyBinding)
      {
        if (inputBinding.Command == AcpXamDataPresenter.CopyCommand)
          keyBinding1 = (KeyBinding) inputBinding;
        else if (inputBinding.Command == AcpXamDataPresenter.PasteCommand)
          keyBinding2 = (KeyBinding) inputBinding;
      }
    }
    ((UIElement) this).InputBindings.Remove((InputBinding) keyBinding1);
    ((UIElement) this).InputBindings.Remove((InputBinding) keyBinding2);
    CommandBinding commandBinding1 = (CommandBinding) null;
    CommandBinding commandBinding2 = (CommandBinding) null;
    foreach (CommandBinding commandBinding3 in ((UIElement) this).CommandBindings)
    {
      if (commandBinding3.Command == AcpXamDataPresenter.CopyCommand)
        commandBinding1 = commandBinding3;
      else if (commandBinding3.Command == AcpXamDataPresenter.PasteCommand)
        commandBinding2 = commandBinding3;
    }
    ((UIElement) this).CommandBindings.Remove(commandBinding1);
    ((UIElement) this).CommandBindings.Remove(commandBinding2);
    this.mItemGoto.Click -= new RoutedEventHandler(this.OnContextMenuItemGoto);
    this.mItemFillUp.Click -= new RoutedEventHandler(this.mItemFillUp_Click);
    this.mItemFillDown.Click -= new RoutedEventHandler(this.mItemFillDown_Click);
    this.FieldSettings = (FieldSettings) null;
    this.myField = (IAcpField) null;
    this.mySection = (IAcpFeatureSection) null;
    this.DetachMenuItems();
  }

  private void DisableCntxMenuItems()
  {
    foreach (UIElement uiElement in (IEnumerable) this.cntxMenu.Items)
      uiElement.IsEnabled = false;
  }

  private CellValuePresenter GetCellValuePresenter(object obj)
  {
    CellValuePresenter cellValuePresenter = (CellValuePresenter) null;
    if (obj is DependencyObject)
    {
      DependencyObject reference = (DependencyObject) obj;
      if (reference is CellValuePresenter)
      {
        cellValuePresenter = (CellValuePresenter) reference;
      }
      else
      {
        DependencyObject parent = VisualTreeHelper.GetParent(reference);
        if (parent != null)
          cellValuePresenter = this.GetCellValuePresenter((object) parent);
      }
    }
    return cellValuePresenter;
  }

  private void FillHelper(ContainerTask task, IAcpFeatureNode node)
  {
    if (node == null)
      return;
    IAcpFeatureSection acpFeatureSection = node[this.mySection.FeatureSectionId];
    if (acpFeatureSection == null)
      return;
    IAcpField field = acpFeatureSection[this.myField.UIName];
    if (field == null)
      return;
    if (field.Editable && field.Applicable && field.Visible)
    {
      task.AddTask(field.CopyValueOf(this.myField));
      if (!((AcpFieldBase) field).UnsupportedValue)
        return;
      AppInfoManager.FillUpFillDownFieldsReport.RegisterFieldInReport(field, AcpResources.Value_Not_Copied_Unsupported_Value, false);
    }
    else
      AppInfoManager.FillUpFillDownFieldsReport.RegisterFieldInReport(field, AcpResources.Value_Not_Copied_Unacceptable_Destination, false);
  }

  private void Fill(FillOperation operation)
  {
    if (this.mySection == null)
      return;
    IAcpFeatureNode parent = this.mySection.Parent;
    if (parent == null)
      return;
    Recordset parentRecset = (Recordset) this.mySection.ParentRecset;
    if (parentRecset == null)
      return;
    if (AppInfoManager.FillUpFillDownFieldsReport == null)
      AppInfoManager.FillUpFillDownFieldsReport = new FieldsReportManager();
    else
      AppInfoManager.FillUpFillDownFieldsReport.Clear();
    ContainerTask task;
    switch (operation)
    {
      case FillOperation.FillUp:
        task = new ContainerTask(AcpResources.Fill_Up.AcpStringFormat((object) this.myField.UIName));
        break;
      case FillOperation.FillDown:
        task = new ContainerTask(AcpResources.Fill_Down.AcpStringFormat((object) this.myField.UIName));
        break;
      default:
        AppInfoManager.FillUpFillDownFieldsReport.RegisterFieldInReport((IAcpField) null, AcpResources.Unsupported_Opn, false);
        AcpUI.Common.Utility.FieldsReportChanged((object) this, FieldReportType.FillUpFillDown);
        return;
    }
    int num = parentRecset.IndexOf(parent);
    switch (operation)
    {
      case FillOperation.FillUp:
        for (int index = num - 1; index >= 0; --index)
        {
          IAcpFeatureNode node = parentRecset[index];
          this.FillHelper(task, node);
        }
        break;
      case FillOperation.FillDown:
        for (int index = num + 1; index < parentRecset.Count; ++index)
        {
          IAcpFeatureNode node = parentRecset[index];
          this.FillHelper(task, node);
        }
        break;
    }
    if (task != null)
      UndoManager.AddTask((UndoableTask) task);
    AppInfoManager.FillUpFillDownFieldsReport.RegisterFieldInReport((IAcpField) null, AcpResources.Fill_Opn_Complete, false);
    AcpUI.Common.Utility.FieldsReportChanged((object) this, FieldReportType.FillUpFillDown);
  }

  private void mItemFillUp_Click(object sender, RoutedEventArgs e)
  {
    this.Fill(FillOperation.FillUp);
  }

  private void mItemFillDown_Click(object sender, RoutedEventArgs e)
  {
    this.Fill(FillOperation.FillDown);
  }

  private void InitializeMenuItems()
  {
    this.mItemFillUp = new System.Windows.Controls.MenuItem();
    this.mItemFillUp.Header = (object) AcpResources.Fill_Up.AcpStringFormat((object) string.Empty);
    this.mItemFillDown = new System.Windows.Controls.MenuItem();
    this.mItemFillDown.Header = (object) AcpResources.Fill_Down.AcpStringFormat((object) string.Empty);
    this.mItemCopy = new System.Windows.Controls.MenuItem();
    this.mItemCopy.Header = (object) AcpResources.Copy_Id;
    this.mItemPaste = new System.Windows.Controls.MenuItem();
    this.mItemPaste.Header = (object) AcpResources.Paste_Id;
    this.mItemGoto = new System.Windows.Controls.MenuItem();
    this.mItemGoto.Header = (object) AcpResources.GoToItem_Id;
    this.mItemDelete = new System.Windows.Controls.MenuItem();
    this.mItemDelete.Header = (object) AcpResources.Delete_Id;
    this.cntxMenu = new System.Windows.Controls.ContextMenu();
    this.cntxMenu.Items.Add((object) this.mItemFillUp);
    this.cntxMenu.Items.Add((object) this.mItemFillDown);
    this.cntxMenu.Items.Add((object) this.mItemCopy);
    this.cntxMenu.Items.Add((object) this.mItemPaste);
    this.cntxMenu.Items.Add((object) this.mItemGoto);
    this.cntxMenu.Items.Add((object) this.mItemDelete);
    ((FrameworkElement) this).ContextMenu = this.cntxMenu;
  }

  private void DetachMenuItems()
  {
    this.mItemFillUp = (System.Windows.Controls.MenuItem) null;
    this.mItemFillDown = (System.Windows.Controls.MenuItem) null;
    this.mItemCopy = (System.Windows.Controls.MenuItem) null;
    this.mItemPaste = (System.Windows.Controls.MenuItem) null;
    this.mItemGoto = (System.Windows.Controls.MenuItem) null;
    this.mItemDelete = (System.Windows.Controls.MenuItem) null;
    this.cntxMenu = (System.Windows.Controls.ContextMenu) null;
  }

  private AcpExpander FindPageExpander(AcpXamDataPresenter dataPresenter)
  {
    if (dataPresenter != null)
    {
      DependencyObject pageExpander = (DependencyObject) dataPresenter;
      while (true)
      {
        switch (pageExpander)
        {
          case null:
            goto label_6;
          case AcpExpander _:
            goto label_2;
          case Visual _:
          case Visual3D _:
            pageExpander = VisualTreeHelper.GetParent(pageExpander);
            continue;
          default:
            pageExpander = LogicalTreeHelper.GetParent(pageExpander);
            continue;
        }
      }
label_2:
      return pageExpander as AcpExpander;
    }
label_6:
    return (AcpExpander) null;
  }

  private void OnInitializeRecord(object sender, InitializeRecordEventArgs e)
  {
    if (e.Record.HasChildren)
      return;
    e.Record.ExpansionIndicatorVisibility = Visibility.Hidden;
  }

  protected internal void BringRecordIntoView(int index)
  {
    IScrollInfo scrollInfo = this.ScrollInfo;
    if (scrollInfo == null)
      return;
    double offset = scrollInfo.ExtentHeight * (double) index / (double) this.Records.Count;
    scrollInfo.SetVerticalOffset(offset);
  }

  protected override void OnPreviewMouseLeftButtonDown(MouseButtonEventArgs e)
  {
    this.SaveLastMouseButtonChangedInfo(e);
    HitTestResult hitTestResult = VisualTreeHelper.HitTest((Visual) this, e.GetPosition((IInputElement) e.Source));
    if (hitTestResult != null)
    {
      for (DependencyObject reference = hitTestResult.VisualHit; reference != null; reference = VisualTreeHelper.GetParent(reference))
      {
        if (reference is RecordSelector recordSelector)
        {
          Record record = recordSelector.Record;
          if (record.IsActive)
            record.DataPresenter.ActiveCell = (Cell) null;
          RecordPresenter.FromRecord(record).Focus();
          break;
        }
      }
    }
    base.OnPreviewMouseLeftButtonDown(e);
  }

  protected virtual void OnPreviewMouseRightButtonUp(MouseButtonEventArgs e)
  {
    this.SaveLastMouseButtonChangedInfo(e);
    HitTestResult hitTestResult = VisualTreeHelper.HitTest((Visual) this, e.GetPosition((IInputElement) e.Source));
    if (hitTestResult != null)
    {
      for (DependencyObject reference = hitTestResult.VisualHit; reference != null; reference = VisualTreeHelper.GetParent(reference))
      {
        if (reference is CellValuePresenter cvp)
        {
          ((UIElement) cvp).Focus();
          ((FrameworkElement) this).ContextMenu = this.cntxMenu;
          this.OnContextMenuOpening(cvp);
          ((FrameworkElement) this).ContextMenu.PlacementTarget = (UIElement) cvp;
          ((FrameworkElement) this).ContextMenu.IsOpen = true;
          break;
        }
      }
    }
    if (((FrameworkElement) this).ContextMenu != null && !((FrameworkElement) this).ContextMenu.IsOpen)
      ((FrameworkElement) this).ContextMenu = (System.Windows.Controls.ContextMenu) null;
    // ISSUE: explicit non-virtual call
    __nonvirtual (((UIElement) this).OnPreviewMouseRightButtonUp(e));
  }

  protected void SaveLastMouseButtonChangedInfo(MouseButtonEventArgs e)
  {
    this.lastMouseButtonChanged = e.ChangedButton;
    this.lastMouseButtonChangedState = e.ButtonState;
  }

  private void OnContextMenuOpening(CellValuePresenter cvp)
  {
    foreach (UIElement uiElement in (IEnumerable) this.cntxMenu.Items)
      uiElement.IsEnabled = false;
    bool enableClipboardCopy = this.CanEnableClipboardCopy;
    bool enableClipboardPaste = this.CanEnableClipboardPaste;
    ((UIElement) this.cntxMenu.Items[2]).IsEnabled = enableClipboardCopy;
    ((UIElement) this.cntxMenu.Items[3]).IsEnabled = enableClipboardPaste;
    if (!this.IsAllowDelete(cvp))
      ((UIElement) this.cntxMenu.Items[5]).IsEnabled = false;
    else
      ((UIElement) this.cntxMenu.Items[5]).IsEnabled = this.IsDataRecordView && this.CanEnableDelete;
    if (enableClipboardCopy | enableClipboardPaste)
      this.SetActiveCell(cvp);
    this.myField = (IAcpField) null;
    this.mySection = (IAcpFeatureSection) null;
    this.myField = cvp.Value as IAcpField;
    if (this.myField == null)
      return;
    this.mySection = this.myField.Parent;
    if (this.mySection == null || !((FeatureSection) this.mySection).CanFill(this.myField))
      return;
    Recordset parentRecset = (Recordset) this.mySection.ParentRecset;
    if (parentRecset == null)
      return;
    IAcpFeatureNode parent = this.mySection.Parent;
    if (parent == null)
      return;
    if (this.myField is AcpRecRefField)
    {
      bool flag = true;
      if (!(this.myField is AcpRecRefField field))
        flag = false;
      else if (field.UIValue == field.InvalidText)
        flag = false;
      else if (field.Value == -1)
        flag = false;
      else if (field.PrependValues != null)
      {
        foreach (int prependValue in field.PrependValues)
        {
          if (prependValue == field.Value)
            flag = false;
        }
      }
      ((UIElement) this.cntxMenu.Items[4]).IsEnabled = flag;
    }
    if (!((AcpFieldBase) this.myField).AllowFillUpFillDown())
      return;
    int num = parentRecset.IndexOf(parent);
    ((UIElement) this.cntxMenu.Items[0]).IsEnabled = num > 0;
    ((UIElement) this.cntxMenu.Items[1]).IsEnabled = num < parentRecset.Count - 1;
  }

  private bool IsAllowDelete(CellValuePresenter cvp)
  {
    this.myField = (IAcpField) null;
    this.mySection = (IAcpFeatureSection) null;
    try
    {
      this.myField = cvp.Value as IAcpField;
      if (this.myField == null)
      {
        if (cvp.Value is IAcpFeatureSection)
        {
          this.mySection = cvp.Value as IAcpFeatureSection;
          IAcpFeatureNode parent = this.mySection.Parent;
          if (parent != null)
          {
            if (this.SelectedItems.Records.Count <= 1)
              return !Permission.Have(Permissions.Undeletable, parent.Permissions);
            Recordset dataSource = (Recordset) this.DataSource;
            if (dataSource == null)
              return true;
            foreach (Record record in this.SelectedItems.Records)
            {
              if (Permission.Have(Permissions.Undeletable, ((FeatureNode) dataSource[record.Index]).Permissions))
                return false;
            }
          }
        }
      }
      else
      {
        this.mySection = this.myField.Parent;
        if (this.mySection == null || !((FeatureSection) this.mySection).CanFill(this.myField))
          return true;
        IAcpFeatureNode parent = this.mySection.Parent;
        if (parent != null)
        {
          if (this.SelectedItems.Records.Count <= 1)
            return !Permission.Have(Permissions.Undeletable, parent.Permissions);
          Recordset dataSource = (Recordset) this.DataSource;
          if (dataSource == null)
            return true;
          foreach (Record record in this.SelectedItems.Records)
          {
            if (Permission.Have(Permissions.Undeletable, ((FeatureNode) dataSource[record.Index]).Permissions))
              return false;
          }
        }
      }
    }
    catch (Exception ex)
    {
    }
    return true;
  }

  protected virtual void OnPreviewKeyDown(System.Windows.Input.KeyEventArgs e)
  {
    if (e.Key == Key.Apps)
    {
      e.Handled = true;
    }
    else
    {
      // ISSUE: explicit non-virtual call
      __nonvirtual (((UIElement) this).OnPreviewKeyDown(e));
    }
  }

  protected virtual void OnPreviewKeyUp(System.Windows.Input.KeyEventArgs e)
  {
    if (e.Key == Key.Apps)
    {
      e.Handled = true;
    }
    else
    {
      // ISSUE: explicit non-virtual call
      __nonvirtual (((UIElement) this).OnPreviewKeyUp(e));
    }
  }

  ~AcpXamDataPresenter()
  {
    try
    {
    }
    finally
    {
      // ISSUE: explicit finalizer call
      // ISSUE: explicit non-virtual call
      __nonvirtual (((object) this).Finalize());
    }
  }
}
