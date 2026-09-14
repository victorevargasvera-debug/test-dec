// Decompiled with JetBrains decompiler
// Type: AcpBusinessLayer.Recordset
// Assembly: AcpBusinessLayer, Version=23.1.0.23, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 44CF2A76-4418-422B-9DDD-B27A71BAF20C
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpBusinessLayer.dll

using AcpBusinessLayer.UndoRedo;
using AcpCommonLib;
using AcpCommonLib.UndoRedo;
using AcpCommonResources;
using AcpUtility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml;

#nullable disable
namespace AcpBusinessLayer;

[DebuggerDisplay("Name={RecordsetName}, Count={Count}")]
public abstract class Recordset : 
  ObservableCollection<FeatureNode>,
  IAcpRecordset,
  IAcpConstraints,
  IAcpCommon,
  IDisposable,
  ISerializable
{
  private DifferenceCount diffCount;
  private static Dictionary<Guid, int> MaxPools = new Dictionary<Guid, int>();
  public static bool ParentNodeBeingAdded = false;
  private Guid typeGuid;
  protected internal int lastId;
  private bool singleInstance;
  private bool isEmpty = true;
  private int dataXferOrder;
  private Document containerDoc;
  private bool positionBased;
  private bool hiddenStatic;
  private Permissions permissions;
  private bool disposedValue;
  private bool isDisposeInProgress;

  static Recordset() => AssemblyValidator.IsCallerAuthorized();

  public abstract FeatureNode CreateDefaultRecord();

  public FeatureNode CreateDefaultRecordHelper()
  {
    int num = ConstraintManager.Suspend() ? 1 : 0;
    FeatureNode defaultRecord = this.CreateDefaultRecord();
    if (num != 0)
      ConstraintManager.Resume();
    return defaultRecord;
  }

  internal DifferenceCount DiffCount => this.diffCount;

  protected Recordset() => this.CreateDifferenceCount();

  protected Recordset(string name)
    : this(name, false, false, (string) null)
  {
  }

  protected Recordset(string name, string keySeed)
    : this(name, false, false, keySeed)
  {
  }

  protected Recordset(string name, bool canBeEmpty, bool positionBased)
    : this(name, canBeEmpty, positionBased, (string) null)
  {
  }

  protected Recordset(string name, bool canBeEmpty, bool positionBased, string keySeed)
    : this(name, canBeEmpty, positionBased, false, keySeed)
  {
  }

  protected Recordset(string name, bool canBeEmpty, bool positionBased, bool hasTemplateNode)
    : this(name, canBeEmpty, positionBased, hasTemplateNode, (string) null)
  {
  }

  protected Recordset(
    string name,
    bool canBeEmpty,
    bool positionBased,
    bool hasTemplateNode,
    string keySeed)
  {
    this.RecordsetName = this.UIName = name;
    this.CanBeEmpty = canBeEmpty;
    this.PositionBased = positionBased;
    this.Max = 1024 /*0x0400*/;
    this.typeGuid = this.GetType().GUID;
    this.KeySeed = keySeed;
    this.lastId = 0;
    this.CumulativeMax = 0;
    if (!FeatureManager.IsInitialized)
      this.DefaultRecordCount = 0;
    if (this.CanBeEmpty && !AppInfoManager.InitializingDefaultDoc)
    {
      this.Min = 0;
    }
    else
    {
      this.Min = 1;
      this.AddRecord(this.CreateDefaultRecordHelper());
      this._IsEmpty = false;
    }
    while (this.Count < this.DefaultRecordCount)
      this.AddRecord(this.CreateDefaultRecordHelper());
    if (hasTemplateNode || this.Count == 0)
    {
      this.CalculateHiddenStatic = true;
      this.TemplateNode = this.CreateDefaultRecord();
    }
    this.CreateDifferenceCount();
  }

  private void CreateDifferenceCount()
  {
    this.diffCount = new DifferenceCount();
    this.diffCount.CountChanged += new DifferenceCountChangedEventHandler(this.OnNodeDiffCountChanged);
  }

  private void OnNodeDiffCountChanged(object sender, DifferenceCountChangedEventArgs e)
  {
    this.OnPropertyChanged(new PropertyChangedEventArgs("HasDiffs"));
    if (e.Action == DifferenceCountChangedAction.Increment && this.DiffCount.Value == 1 && this.ParentSection != null)
    {
      ((FeatureSection) this.ParentSection).DiffCount.Increment(e.Name);
    }
    else
    {
      if (e.Action != DifferenceCountChangedAction.Decrement || this.DiffCount.Value != 0 || this.ParentSection == null)
        return;
      ((FeatureSection) this.ParentSection).DiffCount.Decrement(e.Name);
    }
  }

  internal static void ResetMaxPools() => Recordset.MaxPools.Clear();

  public bool LastRecordInOperation { get; internal set; }

  public bool NotFirstNoLastAddOnMultiAddOperation { get; internal set; }

  protected int Id { get; set; }

  public ReferencedNodeCollection KeysToNode { get; private set; }

  internal void InitKeysToNode()
  {
    this.HasKeyField = true;
    this.KeysToNode = new ReferencedNodeCollection(this);
  }

  public string KeySeed { get; set; }

  public event EventHandler ReferenceKeyChanged;

  internal void RaiseReferenceKeyChanged(FeatureNode node)
  {
    if (this.Count <= 0 || this.ReferenceKeyChanged == null || !this.Contains(node))
      return;
    this.ReferenceKeyChanged((object) node, new EventArgs());
  }

  internal FeatureNode InternalAddRecord()
  {
    FeatureNode defaultRecordHelper = this.CreateDefaultRecordHelper();
    this.AddRecord(defaultRecordHelper);
    return defaultRecordHelper;
  }

  internal bool CheckKeyFieldForDup(string key)
  {
    bool flag = false;
    foreach (FeatureNode featureNode in (Collection<FeatureNode>) this)
    {
      if (featureNode.KeyField != null && featureNode.ReferenceKey == key)
      {
        flag = true;
        break;
      }
    }
    return flag;
  }

  internal void ValidateReferenceKey(string key)
  {
    bool flag = false;
    foreach (FeatureNode featureNode in (Collection<FeatureNode>) this)
    {
      if (featureNode.KeyField != null && featureNode.ReferenceKey == key)
      {
        if (flag)
        {
          featureNode.KeyField.ForceValid = false;
          break;
        }
        featureNode.KeyField.ForceValid = key.Length <= featureNode.KeyField.MaxLength;
        featureNode.KeyField.CalculateValidity();
        if (!this.KeysToNode.Contains(featureNode))
          this.KeysToNode.Add(featureNode);
        flag = true;
      }
    }
  }

  private void AddNodeHelper(FeatureNode rec)
  {
    if (rec == null)
      throw new ArgumentNullException(nameof (rec));
    rec.Parent = (IAcpRecordset) this;
    if (!this.HasKeyField && rec.KeyField != null && this.KeysToNode == null)
    {
      this.HasKeyField = true;
      this.KeysToNode = new ReferencedNodeCollection(this);
    }
    foreach (IAcpField allField in rec.AllFields)
    {
      if (allField is AcpRecRefField field && field.ReferencedNode != null && field.ReferencedNode.KeyField != null)
        field.ReferencedNode.KeyField.AddRecordReference(field);
    }
    if (this.HasKeyField && (rec.KeyField is AcpNumericKeyField keyField && keyField.NumericValue == 0 || rec.KeyField.Value == null))
    {
      bool markForUndo = UndoManager.MarkForUndo;
      bool flag = this.ContainerDoc != null && this.ContainerDoc.ModificationLogEnabled;
      if (markForUndo)
        UndoManager.StopUndoRedo();
      if (flag)
        this.ContainerDoc.ModificationLogEnabled = false;
      string keyValue = this.GenerateKeyValue(rec);
      while (this.KeysToNode.Contains(keyValue))
        keyValue = this.GenerateKeyValue(rec);
      rec.KeyField.SetValueNoConstraints(keyValue);
      if (markForUndo)
        UndoManager.StartUndoRedo();
      if (flag)
        this.ContainerDoc.ModificationLogEnabled = true;
    }
    if (!this.HasEmbeddedRecset)
      this.HasEmbeddedRecset = rec.HasEmbeddedRecset;
    rec.Deleted = false;
    if ((this.ContainerDoc != null || FeatureManager.ActiveDocument != null && !FeatureManager.ActiveDocument.IsOpen) && !AppInfoManager.DragOperation && AppInfoManager.AppMode == ApplicationMode.CodeplugConfigurationMode)
    {
      this.IncrementMaxPoolEntry(1);
      this.IncrementCumulativeMax((IAcpFeatureNode) rec);
    }
    AcpDocument containerDoc = this.ContainerDoc as AcpDocument;
    if (this.ContainerDoc != null && FeatureManager.ActiveDocument != null && FeatureManager.ActiveDocument.IsOpen)
      containerDoc.OpenFromFileNew = false;
    if (containerDoc != null && !containerDoc.OpenFromFileNew)
    {
      foreach (Recordset embeddedRecordset in rec.EmbeddedRecordsets)
      {
        embeddedRecordset.ContainerDoc = this.ContainerDoc;
        if (!Recordset.ParentNodeBeingAdded)
          embeddedRecordset.IncrementMaxPoolEntry(embeddedRecordset.Count);
      }
      if (this.ContainerDoc.ModificationLogEnabled)
        this.ContainerDoc.AddToModificationLog(this.BuildAddRecordLog(rec.FeatureName));
    }
    if (!rec.Parent.CanBeEmpty || rec.Parent.Count != 0)
      return;
    rec.Parent._IsEmpty = false;
  }

  protected virtual void OnFinishedAddRecord()
  {
  }

  protected virtual void OnFinishedRemoveRecord()
  {
  }

  public virtual void OnFinishedMoveRecord()
  {
  }

  protected virtual void OnFinishedAddRecord(IAcpFeatureNode record)
  {
  }

  protected virtual void OnFinishedRemoveRecord(IAcpFeatureNode record)
  {
  }

  protected virtual void OnFinishedMoveRecord(
    IAcpFeatureNode draggedRecord,
    IAcpFeatureNode targetRecord)
  {
  }

  public void FinishedMoveRecord(int oldIndex, int newIndex)
  {
    this.OnFinishedMoveRecord(this[oldIndex], this[newIndex]);
  }

  public virtual void IncrementCumulativeMax(IAcpFeatureNode record)
  {
  }

  public virtual void DecrementCumulativeMax(IAcpFeatureNode record)
  {
  }

  private void IncrementMaxPoolEntry(int number)
  {
    if (this.MaxPool <= 0)
      return;
    if (!Recordset.MaxPools.ContainsKey(this.typeGuid))
      Recordset.MaxPools[this.typeGuid] = number;
    else
      Recordset.MaxPools[this.typeGuid] = Recordset.MaxPools[this.typeGuid] + number;
  }

  public virtual string GenerateKeyValue(FeatureNode node)
  {
    return AppInfoManager.DndOrImportOperation && node.KeyField != null && !node.KeyField.BlockDataTransfer && node.KeyField.Editable && this.Max != this.Min ? this.GenerateRandomKeyValue(node) : (!this.SingleInstance ? (!(node.KeyField is AcpNumericKeyField) ? (string.IsNullOrEmpty(this.KeySeed) ? (string.IsNullOrEmpty(this.UIName) ? $"{this.RecordsetName} {(++this.lastId).ToString()}" : $"{this.UIName} {(++this.lastId).ToString()}") : $"{this.KeySeed} {(++this.lastId).ToString()}") : (++this.lastId).ToString()) : node.FeatureName);
  }

  public void ResetNamingScheme() => this.lastId = 0;

  public virtual string GenerateRandomKeyValue(FeatureNode node)
  {
    string randomKeyValue = "";
    int length = 1;
    if (node.KeyField is AcpNumericKeyField)
      randomKeyValue = new Random().Next().ToString();
    else
      length = string.IsNullOrEmpty(this.KeySeed) ? (string.IsNullOrEmpty(this.UIName) ? this.RecordsetName.Length : this.UIName.Length) : this.KeySeed.Length;
    if (string.IsNullOrEmpty(randomKeyValue))
    {
      randomKeyValue = Guid.NewGuid().ToString();
      if (length < randomKeyValue.Length)
        randomKeyValue = randomKeyValue.Substring(0, length);
    }
    return randomKeyValue;
  }

  private void RemoveNodeHelper(FeatureNode rec)
  {
    if (this.HasKeyField)
    {
      this.KeysToNode.DeleteItem(rec);
      if (!AcpDocument.Closing)
        rec.KeyField.NodeDeleted();
    }
    foreach (IAcpField allField in rec.AllFields)
    {
      if (allField is AcpRecRefField field && field.ReferencedNode != null)
        field.ReferencedNode.KeyField.RemoveRecordReference(field);
    }
    if (this.ContainerDoc != null && this.ContainerDoc.ModificationLogEnabled)
      this.ContainerDoc.AddToModificationLog(this.BuildDeleteRecordLog(rec.FeatureName));
    if (AppInfoManager.AppMode != ApplicationMode.CodeplugComparisonMode)
    {
      if (!Recordset.ParentNodeBeingAdded)
      {
        this.DecrementMaxPoolEntry(1);
        this.DecrementCumulativeMax((IAcpFeatureNode) rec);
      }
      if (rec.HasEmbeddedRecset)
      {
        foreach (IAcpFeatureSection featureSections in rec.FeatureSectionsCollection)
        {
          if (featureSections.HasEmbeddedRecset)
            ((Recordset) featureSections.EmbeddedRecset).DecrementMaxPoolEntry(featureSections.EmbeddedRecset.Count);
        }
      }
    }
    if (!rec.Parent.CanBeEmpty || rec.Parent.Count != 0)
      return;
    rec.Parent._IsEmpty = true;
  }

  private void HandlePositionChanges(int index)
  {
    HashSet<FeatureNode> featureNodeSet = new HashSet<FeatureNode>();
    if (index < 0)
      return;
    for (int index1 = this.Count - 1; index1 >= index; --index1)
    {
      FeatureNode featureNode = (FeatureNode) this[index1];
      this.KeysToNode.UpdateKey(featureNode);
      if (featureNode?.ReferencingNodes != null)
      {
        foreach (FeatureNode referencingNode in featureNode.ReferencingNodes)
          featureNodeSet.Add(referencingNode);
      }
    }
    foreach (FeatureNode featureNode in featureNodeSet)
      featureNode.CallConstraints();
    for (int index2 = index; index2 < this.Count; ++index2)
      ((FeatureNode) this[index2]).BareRaisePositionChanged();
  }

  private void DecrementMaxPoolEntry(int number)
  {
    if (this.MaxPool == int.MaxValue || this.MaxPool <= 0 || !Recordset.MaxPools.ContainsKey(this.typeGuid))
      return;
    Recordset.MaxPools[this.typeGuid] = Recordset.MaxPools[this.typeGuid] - number;
  }

  private string BuildAddRecordLog(string nodeName)
  {
    string str = DateTime.Now.ToString() + AcpResources.Added_To_RS_Info.AcpStringFormat((object) $"\"{nodeName}\"", (object) $"\"{this.RecordsetName}\"");
    if (this.IsEmbeddedRecset)
      str = $"{str} {AcpResources.At_Id}\"{this.ParentSection.Path("\\")}\"";
    return str;
  }

  private string BuildDeleteRecordLog(string nodeName)
  {
    string str = DateTime.Now.ToString() + AcpResources.Deleted_To_RS_Info.AcpStringFormat((object) $"\"{nodeName}\"", (object) $"\"{this.RecordsetName}\"");
    if (this.IsEmbeddedRecset)
      str = $"{str} {AcpResources.At_Id}\"{this.ParentSection.Path("\\")}\"";
    return str;
  }

  internal void InsertRecord(int index, IAcpFeatureNode record)
  {
    if (record == null)
      throw new ArgumentNullException(AcpResources.Record_Id);
    this.AddNodeHelper((FeatureNode) record);
    this.Insert(index, (FeatureNode) record);
    if (this.HasKeyField)
    {
      if (!this.KeysToNode.Contains(record.ReferenceKey))
        this.KeysToNode.Add((FeatureNode) record);
      this.HandlePositionChanges(index);
    }
    record.PopulateReferences();
    this.OnFinishedAddRecord();
    this.OnFinishedAddRecord(record);
    this.CanAdd = true;
    this.CanDelete = true;
  }

  internal void SetupDependencies()
  {
    foreach (FeatureNode featureNode in (Collection<FeatureNode>) this)
      featureNode.SetupDependencies();
  }

  internal void SetConstraints()
  {
    foreach (FeatureNode featureNode in (Collection<FeatureNode>) this)
      featureNode.SetConstraints();
  }

  internal void PopulateReferences()
  {
    foreach (FeatureNode featureNode in (Collection<FeatureNode>) this)
      featureNode.PopulateReferences();
  }

  public void Initialize()
  {
    foreach (IAcpFeatureNode acpFeatureNode in (Collection<FeatureNode>) this)
      acpFeatureNode.Parent = (IAcpRecordset) this;
    foreach (FeatureNode featureNode in (Collection<FeatureNode>) this)
    {
      featureNode.PopulateReferences();
      featureNode.SetupDependencies();
      featureNode.SetConstraints();
    }
  }

  public void CallConstraints()
  {
    foreach (FeatureNode featureNode in (Collection<FeatureNode>) this)
      featureNode.CallConstraints();
  }

  public IAcpFeatureNode AddDefaultRecord()
  {
    AppInfoManager.AddDefaultRecord = true;
    Stopwatch.StartNew();
    int num1 = UndoManager.StopUndoRedo() ? 1 : 0;
    int num2 = ConstraintManager.Suspend() ? 1 : 0;
    FeatureNode defaultRecordHelper = this.CreateDefaultRecordHelper();
    if (num2 != 0)
      ConstraintManager.Resume();
    if (num1 != 0)
      UndoManager.StartUndoRedo();
    UndoManager.AddTask((UndoableTask) new AddRecordTask(defaultRecordHelper));
    AppInfoManager.AddDefaultRecord = false;
    return (IAcpFeatureNode) defaultRecordHelper;
  }

  public void AddRecord(FeatureNode record)
  {
    if (record == null)
      throw new ArgumentNullException(nameof (record));
    this.AddNodeHelper(record);
    try
    {
      this.Add(record);
    }
    catch (ArgumentOutOfRangeException ex)
    {
    }
    if (this.HasKeyField && !this.KeysToNode.Contains(record.ReferenceKey))
      this.KeysToNode.Add(record);
    if (this.PositionBased)
      this.MoveNodeBasedOnKey(record);
    this.OnFinishedAddRecord();
    this.OnFinishedAddRecord((IAcpFeatureNode) record);
    this.CanAdd = true;
    this.CanDelete = true;
  }

  internal void MoveNodeBasedOnKey(FeatureNode node)
  {
    if (!this.Contains(node))
      return;
    int positionForNode = this.GetPositionForNode(node);
    int oldIndex = this.IndexOf((IAcpFeatureNode) node);
    if (positionForNode == oldIndex)
      return;
    this.Move(oldIndex, positionForNode);
  }

  public int AddMultipleDefaultRecords(int count)
  {
    AppInfoManager.AddDefaultRecord = true;
    int num1 = 0;
    Stopwatch.StartNew();
    bool flag1 = UndoManager.StopUndoRedo();
    bool flag2 = ConstraintManager.Suspend();
    FeatureNode[] records = new FeatureNode[count];
    this.NotFirstNoLastAddOnMultiAddOperation = false;
    while (num1 < count)
      records[num1++] = this.CreateDefaultRecordHelper();
    if (flag2)
      ConstraintManager.Resume();
    if (flag1)
    {
      UndoManager.StartUndoRedo();
      UndoManager.AddTask((UndoableTask) new AddMultipleRecordsTask(records));
    }
    else
    {
      int num2 = 0;
      foreach (FeatureNode record in records)
      {
        this.NotFirstNoLastAddOnMultiAddOperation = num2 != 0 && num2 != count - 1;
        this.AddRecord(record);
        record.Initialize();
        record.CallConstraints();
        ++num2;
      }
    }
    AppInfoManager.AddDefaultRecord = false;
    this.NotFirstNoLastAddOnMultiAddOperation = false;
    return num1;
  }

  internal void RemoveRecord(IAcpFeatureNode record)
  {
    if (this.Count == this.Min)
      throw new InvalidOperationException("Cannot delete past the Min number of records.");
    if ((!AppInfoManager.SkipValueSetter || !AppInfoManager.DropOperation) && !AppInfoManager.UndoRedoInProgress && Permission.Have(Permissions.Undeletable, record.Permissions))
      return;
    if (UndoManager.MarkForUndo)
    {
      UndoManager.AddTask((UndoableTask) new DeleteRecordTask((FeatureNode) record));
    }
    else
    {
      int index = this.IndexOf(record);
      this.Remove((FeatureNode) record);
      this.RemoveNodeHelper((FeatureNode) record);
      if (this.HasKeyField)
        this.HandlePositionChanges(index);
      if (this.MustCalculateValidityAcross && this.Count > 0)
        this[0].CalculateValidity();
      this.ValidateReferenceKey(record.ReferenceKey);
      this.OnFinishedRemoveRecord(record);
      this.CanAdd = true;
      this.CanDelete = true;
    }
  }

  public virtual void RemoveRecordAt(int index)
  {
    if (this.Count == this.Min)
      throw new InvalidOperationException("Cannot delete past the Min number of records.");
    this.RemoveRecordInternal(index);
  }

  internal void RemoveRecordAtNoMin(int index) => this.RemoveRecordInternal(index);

  public int RemoveMultipleRecords(FeatureNode[] records)
  {
    if (!UndoManager.MarkForUndo)
      return 0;
    UndoManager.AddTask((UndoableTask) new DeleteMultipleRecordsTask(records));
    return records.Length;
  }

  internal void RemoveRecordInternal(int index, bool? CheckPermission = true)
  {
    FeatureNode featureNode1 = (FeatureNode) this[index];
    bool? nullable = CheckPermission;
    bool flag = true;
    if (nullable.GetValueOrDefault() == flag & nullable.HasValue && (!AppInfoManager.SkipValueSetter || !AppInfoManager.DropOperation) && !AppInfoManager.UndoRedoInProgress && Permission.Have(Permissions.Undeletable, featureNode1.Permissions))
      return;
    if (UndoManager.MarkForUndo)
    {
      UndoManager.AddTask((UndoableTask) new DeleteRecordTask(featureNode1));
    }
    else
    {
      this.RemoveAt(index);
      if (this.HasKeyField)
      {
        foreach (FeatureNode featureNode2 in (Collection<FeatureNode>) this)
          this.KeysToNode.UpdateKey(featureNode2);
      }
      this.RemoveNodeHelper(featureNode1);
      if (this.HasKeyField)
        this.HandlePositionChanges(index);
      if (this.MustCalculateValidityAcross && this.Count > 0)
        this[0].CalculateValidity();
      this.CanAdd = true;
      this.CanDelete = true;
    }
    this.OnFinishedRemoveRecord((IAcpFeatureNode) featureNode1);
  }

  public void RefreshKeyMap()
  {
    if (this.KeysToNode == null)
      return;
    this.KeysToNode.Clear();
    foreach (FeatureNode featureNode in (Collection<FeatureNode>) this)
    {
      try
      {
        this.KeysToNode.Add(featureNode);
      }
      catch (ArgumentException ex)
      {
      }
    }
  }

  public void RefreshKeyForNode(FeatureNode node)
  {
    if (this.KeysToNode.Contains(node))
      this.KeysToNode.Remove(node);
    if (this.KeysToNode.Contains(node.ReferenceKey))
      return;
    this.KeysToNode.Add(node);
  }

  public void MoveRecord(int oldIndex, int newIndex)
  {
    if (!this.IsPermissionMoveRecord(oldIndex, newIndex))
      return;
    UndoManager.AddTask((UndoableTask) new MoveRecordTask((FeatureNode) this[oldIndex], newIndex));
  }

  public void MoveRecord(int oldIndex, int newIndex, ContainerTask task)
  {
    if (!this.IsPermissionMoveRecord(oldIndex, newIndex))
      return;
    task.AddTask((UndoableTask) new MoveRecordTask((FeatureNode) this[oldIndex], newIndex));
  }

  private bool IsPermissionMoveRecord(int oldIndex, int newIndex)
  {
    if (oldIndex < newIndex)
    {
      if (Permission.Have(Permissions.InsertAfterDisabled, this[newIndex].Permissions))
        return false;
    }
    else if (Permission.Have(Permissions.InsertBeforeDisabeled, this[newIndex].Permissions))
      return false;
    return !Permission.Have(Permissions.DragDisabled | Permissions.DropBeforeDisabled, this[oldIndex].Permissions) && !Permission.Have(Permissions.DragDisabled | Permissions.DropBeforeDisabled, this[newIndex].Permissions);
  }

  public string RecordsetName { get; private set; }

  public int RecsetId => this.Id;

  public new void Clear()
  {
    while (this.Count > 0)
      this.RemoveRecordInternal(this.Count - 1, new bool?(false));
  }

  public new int Count => base.Count;

  public IAcpFeatureNode this[int index]
  {
    get => index < base.Count ? (IAcpFeatureNode) base[index] : (IAcpFeatureNode) null;
  }

  public int IndexOf(IAcpFeatureNode record)
  {
    return this.Contains(record as FeatureNode) ? this.IndexOf((FeatureNode) record) : -1;
  }

  public void CalculateValidity()
  {
    foreach (IAcpConstraints acpConstraints in (Collection<FeatureNode>) this)
      acpConstraints.CalculateValidity();
  }

  public void CalculateApplicability()
  {
    foreach (IAcpConstraints acpConstraints in (Collection<FeatureNode>) this)
      acpConstraints.CalculateApplicability();
  }

  public void CalculateVisibility()
  {
    foreach (IAcpConstraints acpConstraints in (Collection<FeatureNode>) this)
      acpConstraints.CalculateVisibility();
    if (this.TemplateNode == null)
      return;
    this.TemplateNode.CalculateVisibility();
  }

  public void CalculateEditability()
  {
    foreach (IAcpConstraints acpConstraints in (Collection<FeatureNode>) this)
      acpConstraints.CalculateEditability();
  }

  public void CalculateVisibility(bool allFields)
  {
    foreach (FeatureNode featureNode in (Collection<FeatureNode>) this)
      featureNode.CalculateVisibility(allFields);
    if (this.TemplateNode == null)
      return;
    this.TemplateNode.CalculateVisibility(allFields);
  }

  public void CalculateEditability(bool allFields)
  {
    foreach (FeatureNode featureNode in (Collection<FeatureNode>) this)
      featureNode.CalculateEditability(allFields);
  }

  public bool _HasDiffs => this.DiffCount.Value > 0;

  public void ClearHasDiffs()
  {
    foreach (IAcpFeatureNode acpFeatureNode in (Collection<FeatureNode>) this)
      acpFeatureNode.ClearHasDiffs();
    this.DiffCount.Reset(this.RecordsetName);
  }

  public bool HasVisibleObjects
  {
    get
    {
      foreach (IAcpFeatureNode acpFeatureNode in (Collection<FeatureNode>) this)
      {
        if (acpFeatureNode.HasVisibleObjects)
          return true;
      }
      return false;
    }
  }

  public bool _IsEmpty
  {
    get => this.isEmpty;
    set
    {
      if (this.isEmpty == value)
        return;
      this.isEmpty = value;
      this.OnPropertyChanged(new PropertyChangedEventArgs("IsEmpty"));
    }
  }

  public bool SingleInstance
  {
    get => this.singleInstance;
    protected set
    {
      this.singleInstance = value;
      if (!this.singleInstance)
        return;
      this.Max = 1;
      this.Min = 1;
    }
  }

  public string UIPagePath { get; protected set; }

  public IAcpFeatureNode NodeFromId(int nodeId)
  {
    foreach (IAcpFeatureNode acpFeatureNode in (Collection<FeatureNode>) this)
    {
      if (acpFeatureNode.NodeId == nodeId)
        return acpFeatureNode;
    }
    throw new ArgumentException(AcpResources.Not_Have_Node.AcpStringFormat((object) this.RecordsetName, (object) nodeId));
  }

  public IAcpFeatureNode NodeFromKey(string key)
  {
    return (IAcpFeatureNode) this.KeysToNode.LookupHelper(key);
  }

  public bool HasEmbeddedRecset { get; private set; }

  public bool IsEmbeddedRecset { get; internal set; }

  public bool HasKeyField { get; private set; }

  public IAcpFeatureSection ParentSection { get; set; }

  public IEnumerable<IAcpField> Search(string token) => this.SearchConditionally(token, false);

  public IEnumerable<IAcpField> SearchAll(string token) => this.SearchConditionally(token, true);

  private IEnumerable<IAcpField> SearchConditionally(string token, bool searchHiddenStatic)
  {
    Recordset recordset = this;
    // ISSUE: explicit non-virtual call
    if (searchHiddenStatic || !__nonvirtual (recordset.HiddenStatic))
    {
      foreach (IAcpFeatureNode acpFeatureNode in (Collection<FeatureNode>) recordset)
      {
        if (searchHiddenStatic)
        {
          foreach (IAcpField acpField in acpFeatureNode.SearchAll(token))
            yield return acpField;
        }
        else
        {
          foreach (IAcpField acpField in acpFeatureNode.Search(token))
            yield return acpField;
        }
      }
    }
  }

  public bool AddToXml(XmlNode node, XmlFileType fileType)
  {
    XmlElement element = node.OwnerDocument.CreateElement(this.IsEmbeddedRecset ? "EmbeddedRecset" : "Recset");
    element.SetAttribute("Name", this.UIName);
    element.SetAttribute("Id", this.Id.ToString((IFormatProvider) CultureInfo.InvariantCulture));
    bool flag = true;
    if (element.GetAttribute("Id") == "2064")
    {
      flag = this.AddTrunkingSystemToXml(element, fileType);
    }
    else
    {
      foreach (FeatureNode featureNode in (IEnumerable<FeatureNode>) this.Items)
      {
        if (featureNode.HasVisibleObjects)
          featureNode.AddToXml((XmlNode) element, fileType);
      }
    }
    node.AppendChild((XmlNode) element);
    if (!flag)
      TrunkingSystemData.PartialXmlExport = true;
    return true;
  }

  public bool AddTrunkingSystemToXml(XmlElement recsetElement, XmlFileType fileType)
  {
    bool xml = true;
    foreach (FeatureNode featureNode in this.Items.Where<FeatureNode>((Func<FeatureNode, bool>) (item => item.HasVisibleObjects)))
    {
      bool? nullable1 = featureNode.AllFields.Single<IAcpField>((Func<IAcpField, bool>) (field => field.Name == "TrkSysGeneralAskRequired_A44909")) is AcpField<bool> acpField ? new bool?(acpField.Value) : new bool?();
      int? nullable2 = featureNode.AllFields.Single<IAcpField>((Func<IAcpField, bool>) (field => field.Name == "TrkSysGeneralSystemID_A9239")) is AcpSimpleRangeField simpleRangeField ? new int?(simpleRangeField.Value) : new int?();
      if (nullable1.HasValue && nullable2.HasValue && nullable1.Value)
      {
        if (TrunkingSystemData.SystemKeyManager.IsUnLimitedASKLoaded(nullable2.Value, (byte) 0, false))
          featureNode.AddToXml((XmlNode) recsetElement, fileType);
        else if (xml)
          xml = false;
      }
      else
        featureNode.AddToXml((XmlNode) recsetElement, fileType);
    }
    return xml;
  }

  public bool ReadFromXml(
    XmlNode node,
    ContainerTask task,
    XmlFileType fileType,
    bool importCopyOper,
    Dictionary<IAcpField, string> RecRefsToRepair,
    Dictionary<IAcpField, string> RecRefFieldsOfEmbedRecset)
  {
    switch (fileType)
    {
      case XmlFileType.ImpExp:
        int count = node.ChildNodes.Count;
        if (importCopyOper)
        {
          if (this.PreDataTransferClearRecordset)
            this.ClearRecordset((IAcpRecordset) this, task);
          int num1 = count - this.Count;
          if (num1 >= 0)
          {
            for (int index = 0; index < count; ++index)
            {
              if (index < this.Count)
              {
                ((FeatureNode) this[index]).ReadFromXml(node.ChildNodes[index], task, fileType, importCopyOper, RecRefsToRepair, RecRefFieldsOfEmbedRecset);
              }
              else
              {
                if (this.CounterToMax == 0)
                {
                  AppInfoManager.ImportExportFieldsReport.RegisterFieldInReport((IAcpField) null, AcpResources.Max_Rec_Reached_Add.AcpStringFormat((object) this.Path("\\")), false);
                  break;
                }
                FeatureNode defaultRecordHelper = this.CreateDefaultRecordHelper();
                defaultRecordHelper.CalculateVisibility(true);
                defaultRecordHelper.CalculateEditability(true);
                task.AddTask((UndoableTask) new AddRecordTask(defaultRecordHelper));
                ((FeatureNode) this.NodeFromId(defaultRecordHelper.NodeId)).ReadFromXml(node.ChildNodes[index], task, fileType, importCopyOper, RecRefsToRepair, RecRefFieldsOfEmbedRecset);
              }
            }
            break;
          }
          int num2 = Math.Abs(num1);
          if (num2 > this.CounterToMin)
          {
            num2 = this.CounterToMin;
            AppInfoManager.ImportExportFieldsReport.RegisterFieldInReport((IAcpField) null, AcpResources.Min_Rec_Reached_Delete.AcpStringFormat((object) this.Path("\\")), false);
          }
          for (int index = 0; index < num2; ++index)
            task.AddTask((UndoableTask) new DeleteRecordTask((FeatureNode) this[this.Count - 1]));
          for (int index = 0; index < count; ++index)
            ((FeatureNode) this[index]).ReadFromXml(node.ChildNodes[index], task, fileType, importCopyOper, RecRefsToRepair, RecRefFieldsOfEmbedRecset);
          break;
        }
        if (this.HasKeyField)
        {
          List<string> stringList = new List<string>();
          for (int i = 0; i < count; ++i)
          {
            FeatureNode featureNode = (FeatureNode) null;
            string key = node.ChildNodes[i].Attributes["ReferenceKey"].Value;
            if (this.Count > 0 && !stringList.Contains(key))
              featureNode = (FeatureNode) this.NodeFromKey(key);
            if (featureNode == null)
            {
              if (this.CounterToMax == 0)
              {
                AppInfoManager.ImportExportFieldsReport.RegisterFieldInReport((IAcpField) null, AcpResources.Max_Rec_Reached_Add.AcpStringFormat((object) this.Path("\\")), false);
              }
              else
              {
                FeatureNode defaultRecordHelper = this.CreateDefaultRecordHelper();
                defaultRecordHelper.CalculateVisibility(true);
                defaultRecordHelper.CalculateEditability(true);
                AddRecordTask task1 = new AddRecordTask(defaultRecordHelper);
                task.AddTask((UndoableTask) task1);
                featureNode = (FeatureNode) this.NodeFromId(defaultRecordHelper.NodeId);
              }
            }
            if (featureNode != null)
            {
              if (this.PreDataTransferClearRecordset)
                this.ClearMyEmbeddedRecsets((IAcpFeatureNode) featureNode, task, RecRefFieldsOfEmbedRecset);
              featureNode.ReadFromXml(node.ChildNodes[i], task, fileType, importCopyOper, RecRefsToRepair, RecRefFieldsOfEmbedRecset);
              stringList.Add(featureNode.ReferenceKey);
            }
          }
          stringList.Clear();
          break;
        }
        if (!this.SingleInstance)
        {
          for (int index = 0; index < count; ++index)
          {
            if (index < this.Count)
            {
              ((FeatureNode) this[index]).ReadFromXml(node.ChildNodes[index], task, fileType, importCopyOper, RecRefsToRepair, RecRefFieldsOfEmbedRecset);
            }
            else
            {
              if (this.CounterToMax == 0)
              {
                AppInfoManager.ImportExportFieldsReport.RegisterFieldInReport((IAcpField) null, AcpResources.Max_Rec_Reached_Add.AcpStringFormat((object) this.Path("\\")), false);
                break;
              }
              FeatureNode defaultRecordHelper = this.CreateDefaultRecordHelper();
              defaultRecordHelper.CalculateVisibility(true);
              defaultRecordHelper.CalculateEditability(true);
              task.AddTask((UndoableTask) new AddRecordTask(defaultRecordHelper));
              ((FeatureNode) this.NodeFromId(defaultRecordHelper.NodeId)).ReadFromXml(node.ChildNodes[index], task, fileType, importCopyOper, RecRefsToRepair, RecRefFieldsOfEmbedRecset);
            }
          }
          break;
        }
        ((FeatureNode) this[0]).ReadFromXml(node.ChildNodes[0], task, fileType, importCopyOper, RecRefsToRepair, RecRefFieldsOfEmbedRecset);
        break;
      case XmlFileType.CustomView:
        if (this.Count > 0)
        {
          ((FeatureNode) this[0]).ReadFromXml(node.ChildNodes[0], task, fileType, importCopyOper, RecRefsToRepair, RecRefFieldsOfEmbedRecset);
          break;
        }
        if (this.Count <= 0 && this.TemplateNode != null)
        {
          XmlNode childNode = node.ChildNodes[0];
          if (childNode != null)
          {
            this.TemplateNode.ReadFromXml(childNode, task, fileType, importCopyOper, RecRefsToRepair, RecRefFieldsOfEmbedRecset);
            break;
          }
          break;
        }
        break;
    }
    return true;
  }

  public void ClearMyEmbeddedRecsets(
    IAcpFeatureNode featureNode,
    ContainerTask task,
    Dictionary<IAcpField, string> RecRefFieldsOfEmbedRecset)
  {
    if (featureNode == null)
      return;
    foreach (FeatureSection featureSection in featureNode.FeatureSectionsCollectionByOrder)
    {
      if (featureSection.HasEmbeddedRecset && featureSection.EmbeddedRecset != null && featureSection.EmbeddedRecset.Count > 0)
      {
        IAcpRecordset embeddedRecset = featureSection.EmbeddedRecset;
        FeatureNode featureNode1 = (FeatureNode) embeddedRecset[0];
        if (embeddedRecset.Count > 0 && featureNode1.KeyField != null && featureNode1.KeyField.ReferencingFields != null)
        {
          foreach (FeatureNode featureNode2 in (Collection<FeatureNode>) embeddedRecset)
          {
            foreach (AcpRecRefField referencingField in featureNode2.KeyField.ReferencingFields)
              RecRefFieldsOfEmbedRecset[(IAcpField) referencingField] = referencingField.UIValue;
          }
        }
        embeddedRecset.ClearRecordset(embeddedRecset, task);
      }
    }
  }

  public void ClearRecordset(IAcpRecordset recset, ContainerTask task)
  {
    for (int index = recset.Count - 1; index >= 0; --index)
    {
      if (AppInfoManager.SkipValueSetter && AppInfoManager.DropOperation || !Permission.Have(Permissions.Undeletable, recset[index].Permissions) || AppInfoManager.UndoRedoInProgress)
        task.AddTask((UndoableTask) new DeleteRecordTask((FeatureNode) recset[index], AppInfoManager.DndOrImportOperation));
    }
  }

  public string UIName { get; set; }

  public IAcpField FieldFromPath(string path, string delimiter)
  {
    return this.FieldFromPathHelper(path, true, delimiter);
  }

  public IAcpField FieldFromFavoritePath(string path, string delimiter)
  {
    return this.FieldFromPathHelper(path, false, delimiter);
  }

  public void CopyNodesFrom(IAcpRecordset source)
  {
    if (source == null)
      throw new ArgumentNullException("The source recset is null.");
    if (this.GetType() != source.GetType())
      throw new ArgumentException(AcpResources.RS_InCompatible);
  }

  public int DataTransferOrder
  {
    get => this.dataXferOrder;
    set => this.dataXferOrder = value;
  }

  public Document ContainerDoc
  {
    get
    {
      return this.IsEmbeddedRecset && this.ParentSection != null && this.ParentSection.ParentRecset != null ? this.ParentSection.ParentRecset.ContainerDoc : this.containerDoc;
    }
    set
    {
      if (this.IsEmbeddedRecset)
        return;
      this.containerDoc = value;
    }
  }

  public virtual int Min { get; set; }

  public virtual int Max { get; set; }

  public void SetMax(int newMax)
  {
    bool flag = false;
    int num1 = 0;
    int num2 = 0;
    if (this.Count > this.Max)
    {
      if (newMax > this.Count)
      {
        num1 = this.Max;
        num2 = this.Count;
        flag = true;
      }
      else if (newMax > this.Max)
      {
        num1 = this.Max;
        num2 = newMax;
        flag = true;
      }
      else
      {
        num1 = newMax;
        num2 = this.Max;
        flag = false;
      }
    }
    for (int index = num1; index < num2; ++index)
      ((FeatureNode) this[index]).Valid = flag;
    if (this.Count > newMax)
    {
      for (int index = newMax; index < this.Count; ++index)
        ((FeatureNode) this[index]).Valid = false;
    }
    this.Max = newMax;
    this.CanAdd = true;
  }

  public void SetRecordValidity(IAcpFeatureNode record, bool value)
  {
    if (record == null)
      return;
    ((FeatureNode) record).Valid = value;
  }

  public virtual int CounterToMax
  {
    get
    {
      int counterToMax = this.Max - this.Count;
      int counterToMaxPool1 = this.CounterToMaxPool;
      if (counterToMaxPool1 < counterToMax)
        counterToMax = counterToMaxPool1;
      if (this.Count > 0 && this.HasEmbeddedRecset && counterToMax > 0)
      {
        foreach (IAcpFeatureSection featureSections in (this[0] as FeatureNode).FeatureSectionsCollection)
        {
          if (featureSections.HasEmbeddedRecset)
          {
            int counterToMaxPool2 = (featureSections.EmbeddedRecset as Recordset).CounterToMaxPool;
            if (counterToMaxPool2 < counterToMax)
              counterToMax = counterToMaxPool2;
          }
        }
      }
      return counterToMax;
    }
  }

  public virtual int GetCounterToMaxCopiesOf(int index)
  {
    int counterToMaxCopiesOf = this.Max - this.Count;
    int counterToMaxPool = this.CounterToMaxPool;
    if (counterToMaxPool < counterToMaxCopiesOf)
      counterToMaxCopiesOf = counterToMaxPool;
    if (this.HasEmbeddedRecset && counterToMaxCopiesOf > 0)
    {
      foreach (Recordset embeddedRecordset in (this[index] as FeatureNode).EmbeddedRecordsets)
      {
        if (embeddedRecordset.Count != 0)
        {
          int num = embeddedRecordset.CounterToMaxPool / embeddedRecordset.Count;
          if (num < counterToMaxCopiesOf)
            counterToMaxCopiesOf = num;
        }
      }
    }
    return counterToMaxCopiesOf;
  }

  public int CounterToMaxPool
  {
    get
    {
      if (!this.IsEmbeddedRecset || this.MaxPool == int.MaxValue)
        return int.MaxValue;
      return this.MaxPool > 0 && Recordset.MaxPools.ContainsKey(this.typeGuid) ? this.MaxPool - Recordset.MaxPools[this.typeGuid] : 0;
    }
  }

  public int CounterToMin => this.Count - this.Min;

  public bool CanBeEmpty { get; private set; }

  public bool PositionBased
  {
    get => this.positionBased;
    private set
    {
      this.positionBased = value;
      this.PreDataTransferClearRecordset = value;
    }
  }

  public string Path(string delimiter)
  {
    return this.IsEmbeddedRecset ? this.ParentSection.Path(delimiter) + delimiter + this.UIName : this.UIName;
  }

  public bool HideRecordsFromTree { get; set; }

  public bool HiddenStatic
  {
    get
    {
      if (this.hiddenStatic || this.TemplateNode == null || !this.CalculateHiddenStatic)
        return this.hiddenStatic;
      this.TemplateNode.CalculateVisibility(true);
      foreach (AcpFieldBase allField in this.TemplateNode.AllFields)
      {
        if (!allField.HiddenStatic)
        {
          this.CalculateHiddenStatic = false;
          return false;
        }
      }
      this.HiddenStatic = true;
      this.CalculateHiddenStatic = false;
      return true;
    }
    set => this.hiddenStatic = value;
  }

  public bool CalculateHiddenStatic { get; set; }

  public bool PreDataTransferClearRecordset { get; set; }

  public virtual int MaxPool => int.MaxValue;

  public virtual int CumulativeMax { get; set; }

  public bool AddCopyOf(int index)
  {
    if (!UndoManager.MarkForUndo || index < 0 || index >= this.Count)
      return false;
    AppInfoManager.AddDefaultRecord = false;
    AppInfoManager.AddCopyOperation = true;
    Recordset.ParentNodeBeingAdded = true;
    Dictionary<IAcpField, string> RecRefsToRepair = new Dictionary<IAcpField, string>();
    UndoManager.StopUndoRedo();
    AddCurrentRecordContainerTask task = new AddCurrentRecordContainerTask(((FeatureNode) this[index]).DeepCopy(RecRefsToRepair));
    foreach (KeyValuePair<IAcpField, string> keyValuePair in RecRefsToRepair)
    {
      AcpRecRefField key = keyValuePair.Key as AcpRecRefField;
      task.AddTask((UndoableTask) new ModifyRecRefDataTask(key, keyValuePair.Value));
      if (key.ValueSetter != null)
        key.ValueSetter(key.Parent, (ContainerTask) task);
    }
    UndoManager.AddTask((UndoableTask) task);
    Recordset.ParentNodeBeingAdded = false;
    AppInfoManager.AddCopyOperation = false;
    return true;
  }

  private void RefreshChildPools()
  {
    for (int index = 0; index < this.Count; ++index)
    {
      foreach (Recordset embeddedRecordset in (this[index] as FeatureNode).EmbeddedRecordsets)
      {
        if (index == 0)
          Recordset.MaxPools[embeddedRecordset.typeGuid] = 0;
        Recordset.MaxPools[embeddedRecordset.typeGuid] = Recordset.MaxPools[embeddedRecordset.typeGuid] + embeddedRecordset.Count;
      }
    }
  }

  public bool AddMultipleCopiesOf(int count, int index)
  {
    AppInfoManager.AddDefaultRecord = false;
    AppInfoManager.AddCopyOperation = true;
    if (count <= 0)
      return false;
    int index1 = -1;
    DateTime now = DateTime.Now;
    FeatureNode[] records = new FeatureNode[count];
    this.NotFirstNoLastAddOnMultiAddOperation = false;
    Recordset.ParentNodeBeingAdded = true;
    Dictionary<IAcpField, string> RecRefsToRepair = new Dictionary<IAcpField, string>();
    UndoManager.StopUndoRedo();
    while (++index1 < count)
    {
      this.NotFirstNoLastAddOnMultiAddOperation = index1 != 0 && index1 != count - 1;
      records[index1] = ((FeatureNode) this[index]).DeepCopy(RecRefsToRepair);
      if (records[index1] == null)
        return false;
    }
    AddMultipleCurrRecordsContainerTask task = new AddMultipleCurrRecordsContainerTask(records);
    foreach (KeyValuePair<IAcpField, string> keyValuePair in RecRefsToRepair)
    {
      AcpRecRefField key = keyValuePair.Key as AcpRecRefField;
      task.AddTask((UndoableTask) new ModifyRecRefDataTask(key, keyValuePair.Value));
      if (key.ValueSetter != null)
        key.ValueSetter(key.Parent, (ContainerTask) task);
    }
    UndoManager.AddTask((UndoableTask) task);
    Recordset.ParentNodeBeingAdded = false;
    this.NotFirstNoLastAddOnMultiAddOperation = false;
    AppInfoManager.AddCopyOperation = false;
    return true;
  }

  internal IAcpField FieldFromPathHelper(string path, bool absolute, string delimiter)
  {
    IAcpField field = (IAcpField) null;
    IAcpFeatureNode node = (IAcpFeatureNode) null;
    if (this.Count >= 1)
      node = (IAcpFeatureNode) (this[0] as FeatureNode);
    else if (this.TemplateNode != null)
    {
      node = (IAcpFeatureNode) this.TemplateNode;
      node.Parent = (IAcpRecordset) this;
    }
    return this.RetrieveFieldFromPath(path, absolute, delimiter, field, (FeatureNode) node);
  }

  private IAcpField RetrieveFieldFromPath(
    string path,
    bool absolute,
    string delimiter,
    IAcpField field,
    FeatureNode node)
  {
    string[] strArray1 = path.Split(new string[1]
    {
      delimiter
    }, 2, StringSplitOptions.None);
    if (strArray1[0] == this.UIName)
    {
      if (this.SingleInstance)
      {
        field = node.FieldFromPathHelper(strArray1[1], absolute, delimiter);
      }
      else
      {
        string[] strArray2 = strArray1[1].Split(new string[1]
        {
          delimiter
        }, 2, StringSplitOptions.None);
        if (absolute)
          node = (FeatureNode) this.NodeFromKey(strArray2[0]);
        if (node != null)
          field = node.FieldFromPathHelper(strArray2[1], absolute, delimiter);
      }
    }
    return field;
  }

  private int GetPositionForNode(FeatureNode node)
  {
    int positionForNode = 0;
    for (int index = 0; index < this.Count; ++index)
    {
      if (node.KeyField.DisplayText.CompareTo(((FeatureNode) this[index]).KeyField.DisplayText) < 0)
      {
        if (index > 0 && node.Parent.IndexOf((IAcpFeatureNode) node) > index)
        {
          ++positionForNode;
          break;
        }
        break;
      }
      positionForNode = index;
    }
    return positionForNode;
  }

  public void GetObjectData(SerializationInfo info, StreamingContext context)
  {
    info.AddValue("RecsetName", (object) this.RecordsetName);
    info.AddValue("RecordCount", this.Count);
    info.AddValue("RecsetID", this.Id);
    info.AddValue("CanBeEmpty", this.CanBeEmpty);
    info.AddValue("PositionBased", this.PositionBased);
    info.AddValue("Min", this.Min);
    info.AddValue("Max", this.Max);
    info.AddValue("LastId", this.lastId);
    info.AddValue("HasTemplate", this.TemplateNode != null);
    info.AddValue("PreDataTransferClearRecordset", this.PreDataTransferClearRecordset);
    info.AddValue("HiddenStatic", this.HiddenStatic);
    info.AddValue("CalculateHiddenStatic", this.CalculateHiddenStatic);
    if (this.TemplateNode != null)
      info.AddValue("TemplateNode", (object) this.TemplateNode, typeof (FeatureNode));
    for (int index = 0; index < this.Count; ++index)
      info.AddValue("Feature" + index.ToString(), (object) this[index], typeof (FeatureNode));
  }

  protected Recordset(SerializationInfo info, StreamingContext context)
  {
    this.RecordsetName = info != null ? info.GetString("RecsetName") : throw new ArgumentNullException(nameof (info));
    int int32 = info.GetInt32("RecordCount");
    this.Id = info.GetInt32("RecsetID");
    this.CanBeEmpty = info.GetBoolean(nameof (CanBeEmpty));
    this.PositionBased = info.GetBoolean(nameof (PositionBased));
    this.Min = info.GetInt32(nameof (Min));
    this.Max = info.GetInt32(nameof (Max));
    this.lastId = info.GetInt32("LastId");
    bool boolean = info.GetBoolean("HasTemplate");
    this.PreDataTransferClearRecordset = info.GetBoolean(nameof (PreDataTransferClearRecordset));
    this.HiddenStatic = info.GetBoolean(nameof (HiddenStatic));
    try
    {
      this.CalculateHiddenStatic = info.GetBoolean(nameof (CalculateHiddenStatic));
    }
    catch (SerializationException ex)
    {
      if (!boolean)
      {
        if (int32 != 0)
          goto label_7;
      }
      this.CalculateHiddenStatic = true;
    }
label_7:
    if (boolean || int32 == 0)
    {
      try
      {
        this.TemplateNode = (FeatureNode) info.GetValue(nameof (TemplateNode), typeof (FeatureNode));
      }
      catch
      {
        this.TemplateNode = this.CreateDefaultRecord();
      }
    }
    this.typeGuid = this.GetType().GUID;
    for (int index = 0; index < int32; ++index)
    {
      FeatureNode record = (FeatureNode) info.GetValue("Feature" + index.ToString(), typeof (FeatureNode));
      this.AddRecord(record);
      if (this.KeysToNode != null && !this.KeysToNode.Contains(record.ReferenceKey))
        this.KeysToNode.Add(record);
    }
    this.CreateDifferenceCount();
  }

  public void ResetToDefault()
  {
    foreach (IAcpCommon acpCommon in (Collection<FeatureNode>) this)
      acpCommon.ResetToDefault();
  }

  public void RepairRecRefs()
  {
    foreach (FeatureNode featureNode in (Collection<FeatureNode>) this)
      featureNode.RepairRecRefs();
  }

  public void SubscribeToPropertyChangedEvent(PropertyChangedEventHandler eventHandler)
  {
    this.PropertyChanged += eventHandler;
  }

  public void UnSubscribeFromPropertyChangedEvent(PropertyChangedEventHandler eventHandler)
  {
    this.PropertyChanged -= eventHandler;
  }

  public FeatureNode TemplateNode { get; private set; }

  internal bool MustCalculateValidityAcross { get; set; }

  internal void CalculateValidityAcrossFor(int sectionId, string uIName)
  {
    foreach (FeatureNode featureNode in (Collection<FeatureNode>) this)
      ((AcpFieldBase) featureNode[sectionId][uIName]).CalculateValidity();
  }

  public bool CanAdd
  {
    get
    {
      return !Permission.Have(Permissions.AddCurrentDisabled, this.Permissions) && !Permission.Have(Permissions.AddDefaultDisabled, this.Permissions) && this.CounterToMax > 0;
    }
    private set => this.OnPropertyChanged(new PropertyChangedEventArgs(nameof (CanAdd)));
  }

  public bool CanDelete
  {
    get => this.CounterToMin > 0;
    private set => this.OnPropertyChanged(new PropertyChangedEventArgs(nameof (CanDelete)));
  }

  public virtual int DefaultRecordCount { get; set; }

  public IEnumerable<AcpRecRefField> RecRefFields
  {
    get
    {
      foreach (FeatureNode featureNode in (Collection<FeatureNode>) this)
      {
        foreach (AcpRecRefField recRefField in featureNode.RecRefFields)
          yield return recRefField;
      }
    }
  }

  internal void FindNewFieldsInEmbeddedRecset_ImpExp(
    List<string> xmlEmbedRecsetFieldNameList,
    Dictionary<string, List<IAcpField>> ConsumerNodes)
  {
    if (xmlEmbedRecsetFieldNameList.Count == 0)
      return;
    bool flag1 = false;
    foreach (FeatureNode featureNode in (Collection<FeatureNode>) this)
    {
      List<IAcpField> acpFieldList = new List<IAcpField>();
      foreach (FeatureSection featureSection in featureNode.FeatureSectionsCollectionByOrder)
      {
        foreach (IAcpField acpField in featureSection.FieldsCollectionByOrder)
        {
          if (!xmlEmbedRecsetFieldNameList.Contains(acpField.UIName))
          {
            bool flag2 = false;
            foreach (string legacyUiName in (IEnumerable<string>) (acpField as AcpFieldBase).LegacyUINames)
            {
              if (xmlEmbedRecsetFieldNameList.Contains(legacyUiName))
              {
                flag2 = true;
                break;
              }
            }
            if (!flag2)
            {
              flag1 = true;
              acpFieldList.Add(acpField);
            }
          }
        }
      }
      if (!flag1)
        break;
      if (featureNode.KeyField != null)
        ConsumerNodes.Add(featureNode.ReferenceKey, acpFieldList);
    }
  }

  public void UpdateNewFieldsInEmbeddedRecset_ImpExpDnD(
    ContainerTask task,
    Dictionary<string, List<IAcpField>> ConsumerNodes)
  {
    IAcpFeatureNode acpFeatureNode = (IAcpFeatureNode) null;
    foreach (KeyValuePair<string, List<IAcpField>> consumerNode in ConsumerNodes)
    {
      List<IAcpField> acpFieldList = consumerNode.Value;
      if (this.Count > 0)
        acpFeatureNode = this.NodeFromKey(consumerNode.Key);
      if (acpFeatureNode != null)
      {
        foreach (FeatureSection featureSection in acpFeatureNode.FeatureSectionsCollectionByOrder)
        {
          foreach (IAcpField source in acpFieldList)
          {
            if (featureSection[source.UIName] is AcpFieldBase acpFieldBase)
              task.AddTask(acpFieldBase.CopyValueOf(source));
            if (acpFieldBase is AcpRecRefField acpRecRefField && acpRecRefField.ValueSetter != null)
              acpRecRefField.ValueSetter(acpRecRefField.Parent, task);
          }
        }
      }
    }
  }

  public void FindNewFieldsInEmbeddedRecset_DnD(
    IAcpRecordset producerEmbedddedRecset,
    Dictionary<string, List<IAcpField>> ConsumerFields)
  {
    IAcpFeatureNode acpFeatureNode = (IAcpFeatureNode) null;
    bool flag = false;
    foreach (FeatureNode featureNode in (Collection<FeatureNode>) producerEmbedddedRecset)
    {
      if (featureNode.KeyField != null && this.Count > 0)
        acpFeatureNode = this.NodeFromKey(featureNode.ReferenceKey);
      if (acpFeatureNode != null)
      {
        List<IAcpField> acpFieldList = new List<IAcpField>();
        foreach (FeatureSection featureSection in acpFeatureNode.FeatureSectionsCollectionByOrder)
        {
          IAcpFeatureSection acpFeatureSection = featureNode[featureSection.FeatureSectionId];
          if (acpFeatureSection != null)
          {
            foreach (IAcpField acpField in featureSection.FieldsCollectionByOrder)
            {
              if (!(acpFeatureSection[acpField.UIName] is AcpFieldBase acpFieldBase) || acpFieldBase != null && acpFieldBase.HiddenStatic)
              {
                flag = true;
                acpFieldList.Add(acpField);
              }
            }
          }
        }
        if (!flag)
          break;
        if (acpFeatureNode.ReferenceKey != null)
          ConsumerFields.Add(acpFeatureNode.ReferenceKey, acpFieldList);
      }
    }
  }

  public Permissions Permissions
  {
    get => this.permissions;
    set
    {
      this.permissions = value;
      this.CanAdd = true;
      this.CanDelete = true;
    }
  }

  protected virtual void Dispose(bool disposing)
  {
    if (this.isDisposeInProgress)
      return;
    if (!this.disposedValue)
    {
      if (disposing)
      {
        this.isDisposeInProgress = true;
        this.DisposeRecords();
        this.DiffCount?.Dispose();
        this.TemplateNode?.Dispose();
      }
      this.disposedValue = true;
    }
    this.isDisposeInProgress = false;
  }

  private void DisposeRecords()
  {
    if (this.Items == null)
      return;
    foreach (FeatureNode featureNode in (IEnumerable<FeatureNode>) this.Items)
      featureNode?.Dispose();
  }

  public void Dispose()
  {
    this.Dispose(true);
    GC.SuppressFinalize((object) this);
  }
}
