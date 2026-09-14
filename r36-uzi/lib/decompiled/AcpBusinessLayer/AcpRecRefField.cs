// Decompiled with JetBrains decompiler
// Type: AcpBusinessLayer.AcpRecRefField
// Assembly: AcpBusinessLayer, Version=23.1.0.23, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 44CF2A76-4418-422B-9DDD-B27A71BAF20C
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpBusinessLayer.dll

using AcpBusinessLayer.Impl;
using AcpBusinessLayer.UndoRedo;
using AcpCommonLib;
using AcpCommonLib.UndoRedo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

#nullable disable
namespace AcpBusinessLayer;

[Serializable]
public class AcpRecRefField : AcpListField, IEnumerable<string>, IEnumerable
{
  private int defaultValue;
  public const int NullReference = -1;
  private int IndexOfDeepCopy;
  private FeatureNode referencedNode;
  private List<AcpRecRefSlaveItem> slaveFields;
  private bool disposedValue;
  private bool isDisposeInProgress;

  public Recordset RefRecset { get; internal set; }

  public override int DefaultValue
  {
    get => this.defaultValue;
    set => this.defaultValue = value;
  }

  public int ReferencedIndex
  {
    get => this.Value;
    set
    {
      if (value == -1)
      {
        if (this.PrependCount > 0)
          this.DefaultValue = this.PrependValue;
        else
          this.DefaultValue = this.indexBase;
      }
      else if (this.OneBased && this.PrependCount == 0 && value == 0)
        this.DefaultValue = 1;
      else
        this.DefaultValue = value;
    }
  }

  public int ReferencedName
  {
    get => this.Value;
    set
    {
      if (value == -1)
      {
        if (this.PrependCount > 0)
          this.DefaultValue = this.PrependValue;
        else
          this.DefaultValue = this.indexBase;
      }
      else
        this.DefaultValue = value + this.indexBase;
    }
  }

  public void SetRecset(IAcpRecordset recset)
  {
    if (recset == this.RefRecset)
      return;
    if (this.RefRecset != null)
    {
      this.RefRecset.CollectionChanged -= new NotifyCollectionChangedEventHandler(this.OnReferencedCollectionChanged);
      this.RefRecset.ReferenceKeyChanged -= new EventHandler(this.OnReferencedRecsetKeyChanged);
    }
    if (this.ReferencedNode != null)
      this.ReferencedNode.KeyField.RemoveRecordReference(this);
    this.RefRecset = recset as Recordset;
    if (this.RefRecset == null)
      this.ReferencedNode = (FeatureNode) null;
    if (this.Parent != null && this.Parent.ParentRecset != null)
    {
      if (this.Parent.ParentRecset.ContainerDoc != null && this.Parent.ParentRecset.ContainerDoc.IsOpen)
        this.CalculateAndResetToDefault();
      else
        this.ResetToDefaultNoConstraints();
    }
    else
      this.ResetToDefaultNoConstraints();
    if (this.RefRecset != null)
    {
      this.RefRecset.CollectionChanged += new NotifyCollectionChangedEventHandler(this.OnReferencedCollectionChanged);
      this.RefRecset.ReferenceKeyChanged += new EventHandler(this.OnReferencedRecsetKeyChanged);
    }
    this.UpdateItems();
    this.SetUITimer();
  }

  private void OnReferencedRecsetKeyChanged(object sender, EventArgs e)
  {
    if (!(sender is FeatureNode) || this.RefRecset == null || this.Items.Count <= 0)
      return;
    int prependCount = this.PrependCount;
    if (this.Items[0].Temporary)
      ++prependCount;
    for (int index = 0; index < this.RefRecset.Count; ++index)
    {
      if (index >= this.Items.Count)
        return;
      this.Items[index + prependCount].ItemName = this.RefRecset[index].ReferenceKey;
    }
    this.CleanupDuplicates();
  }

  internal int PrependCount
  {
    get
    {
      if (this.PrependUIValue == null)
        return 0;
      return this.PrependUIValue2 != null ? 2 : 1;
    }
  }

  private void MoveRecRefItem(NotifyCollectionChangedEventArgs e)
  {
    int oldIndex = e.OldStartingIndex + this.PrependCount;
    int newIndex = e.NewStartingIndex + this.PrependCount;
    FeatureNode oldItem = (FeatureNode) e.OldItems[0];
    if (this.Items.Count > 0 && this.Items[0].Temporary)
    {
      if (this.Items[0].ItemName == oldItem.ReferenceKey)
      {
        this.HandleReferencedTempItemRemove(oldItem);
      }
      else
      {
        ++oldIndex;
        ++newIndex;
      }
    }
    this.Items.Move(oldIndex, newIndex);
    this.UpdateValue();
  }

  private void OnReferencedCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
  {
    switch (e.Action)
    {
      case NotifyCollectionChangedAction.Add:
        this.AddRecRefItem((FeatureNode) e.NewItems[0], e.NewStartingIndex);
        break;
      case NotifyCollectionChangedAction.Remove:
        if (AcpDocument.Closing)
          break;
        bool flag = false;
        foreach (ListItem listItem in (Collection<ListItem>) this.Items)
        {
          if (listItem is AcpRecRefItem acpRecRefItem && acpRecRefItem.Node == (FeatureNode) e.OldItems[0])
          {
            this.Items.Remove(listItem);
            flag = acpRecRefItem.Node == this.ReferencedNode;
            break;
          }
        }
        if (flag)
          break;
        this.UpdateValue();
        break;
      case NotifyCollectionChangedAction.Move:
        this.MoveRecRefItem(e);
        break;
    }
  }

  private void AddRecRefItem(FeatureNode node, int position)
  {
    AcpRecRefItem acpRecRefItem = new AcpRecRefItem(this, node);
    int index = position + this.PrependCount;
    if (this.Items.Count > 0 && this.Items[0].Temporary)
    {
      if (this.Items[0].ItemName == node.ReferenceKey)
        this.HandleReferencedTempItemRemove(node);
      else
        ++index;
    }
    if (this.Items.Count <= index)
    {
      this.Items.Add((ListItem) acpRecRefItem);
      this.FirePropertyChangedEvent();
    }
    else
    {
      this.Items.Insert(index, (ListItem) acpRecRefItem);
      this.UpdateValue();
    }
  }

  private void HandleReferencedTempItemRemove(FeatureNode node)
  {
    this.Items.RemoveAt(0);
    string[] strArray = new string[this.SlaveFieldCount];
    int index1 = 0;
    foreach (AcpRecRefSlaveItem slaveField in this.SlaveFields)
    {
      strArray[index1] = slaveField.SlaveField.UIValue;
      ++index1;
    }
    this.ReferencedNode = node;
    int index2 = 0;
    foreach (AcpRecRefSlaveItem slaveField in this.SlaveFields)
    {
      slaveField.SlaveField.UIValue = strArray[index2];
      ++index2;
    }
    if (this.ReferencedNode != null && this.ReferencedNode.KeyField != null)
      this.ReferencedNode.KeyField.AddRecordReference(this);
    this.ForceValid = true;
    this.CallConstraintsX();
  }

  private void RefreshItems(int start, int end)
  {
    int prependCount = this.PrependCount;
    if (this.Items[0].Temporary)
      ++prependCount;
    for (int index = start; index <= end; ++index)
    {
      this.Items[index + prependCount].ItemName = this.RefRecset[index].ReferenceKey;
      if (this.Applicable && this.IsIndexValid != null)
        this.Items[index + prependCount].ItemValidity = this.IsIndexValid(this.Parent, index + this.indexBase);
    }
  }

  internal void UpdateItems()
  {
    int prependCount = this.PrependCount;
    if (this.Items.Count > 0 && this.Items[0].Temporary)
      this.Items.RemoveAt(0);
    while (this.Items.Count > prependCount)
      this.Items.RemoveAt(prependCount);
    if (this.RefRecset != null)
    {
      int count = this.RefRecset.Count;
      if (((Recordset) this.Parent.ParentRecset).NotFirstNoLastAddOnMultiAddOperation)
      {
        int index = ((Recordset) this.Parent.ParentRecset).IndexOf(this.ParentNode) - 1;
        if (index < 0)
          index = this.IndexOfDeepCopy;
        AcpRecRefField acpRecRefField = this.Parent.ParentRecset[index][this.Parent.FeatureSectionId][this.UIName] as AcpRecRefField;
        ListItem[] listItemArray = new ListItem[acpRecRefField.Items.Count];
        try
        {
          acpRecRefField.Items.CopyTo(listItemArray, 0);
        }
        catch (Exception ex)
        {
        }
        ObservableCollection<ListItem> observableCollection = new ObservableCollection<ListItem>((IEnumerable<ListItem>) listItemArray);
        foreach (ListItem listItem in (Collection<ListItem>) observableCollection)
        {
          if (listItem is AcpRecRefItem)
            listItem.parent = (AcpListField) this;
        }
        this.Items = observableCollection;
      }
      else
      {
        for (int index = 0; index < count; ++index)
          this.Items.Add((ListItem) new AcpRecRefItem(this, (FeatureNode) this.RefRecset[index], true, true));
      }
    }
    if (this.Applicable)
      this.CalculateItemsValidity();
    if (this.RefRecset == null)
      return;
    if (this.Value >= this.indexBase && this.RefRecset.Count > this.Value - this.indexBase)
    {
      this.ReferencedNode = (FeatureNode) this.RefRecset[this.Value - this.indexBase];
      this.ReferencedNode.KeyField.AddRecordReference(this);
      this.ForceValid = true;
    }
    else
    {
      if (this.PrependUIValue != null && (this.Value == this.PrependValue || this.Value == this.PrependValue2))
        return;
      if (this.Items.Count == 0 || this.Items[0].ItemName != this.InvalidText)
        this.Items.Insert(0, new ListItem((AcpListField) this, this.InvalidText, false, true, true));
      this.UIValue = this.InvalidText;
      this.DirectUIValue = this.InvalidText;
      this.ForceValid = false;
    }
  }

  internal void UpdateValue()
  {
    if (this.RefRecset == null || this.ReferencedNode == null || (this.Value == this.PrependValue || this.Value == this.PrependValue2) && this.PrependCount != 0)
      return;
    int num1 = ConstraintManager.Suspend() ? 1 : 0;
    int num2 = this.RefRecset.IndexOf((IAcpFeatureNode) this.ReferencedNode);
    if (this.Parent != null)
    {
      IAcpFeatureNode parent = this.Parent.Parent;
    }
    if (num2 >= 0)
      this.SetValue(num2 + this.indexBase);
    if (num1 == 0)
      return;
    ConstraintManager.Resume();
  }

  public string InvalidText => ((AcpRecRefFieldImpl) this.FieldData).InvalidText;

  public AcpRecRefField(FeatureSection parent, string name, string uiLabel)
    : base(parent, name, uiLabel)
  {
  }

  public AcpRecRefField(
    FeatureSection parent,
    string name,
    string uiLabel,
    string[] prependStrings,
    int[] prependValues)
    : this(parent, name, uiLabel, prependStrings, prependValues, false)
  {
  }

  public AcpRecRefField(
    FeatureSection parent,
    string name,
    string uiLabel,
    string[] prependStrings,
    int[] prependValues,
    bool oneBased)
    : this(parent, name, uiLabel, prependStrings, prependValues, oneBased, false)
  {
  }

  public AcpRecRefField(
    FeatureSection parent,
    string name,
    string uiLabel,
    string[] prependStrings,
    int[] prependValues,
    bool oneBased,
    bool defaultToFirst)
    : base(parent, name, uiLabel)
  {
    this.IsFirstRecDefault = defaultToFirst;
    this.indexBase = oneBased ? 1 : 0;
    if (prependStrings != null)
      this.InitPrependEntries(prependStrings, prependValues);
    int num = oneBased ? 1 : 0;
    this.CalculateAndResetToDefault();
  }

  public AcpRecRefField(
    FeatureSection parent,
    string name,
    string uiLabel,
    string[] prependStrings,
    int[] prependValues,
    bool oneBased,
    bool defaultToFirst,
    string[] legacyUILabels)
    : base(parent, name, legacyUILabels, uiLabel)
  {
    this.IsFirstRecDefault = defaultToFirst;
    this.indexBase = oneBased ? 1 : 0;
    if (prependStrings != null)
      this.InitPrependEntries(prependStrings, prependValues);
    int num = oneBased ? 1 : 0;
    this.CalculateAndResetToDefault();
  }

  public bool IsFirstRecDefault
  {
    get => ((AcpRecRefFieldImpl) this.FieldData).IsFirstRecDefault;
    set => ((AcpRecRefFieldImpl) this.FieldData).IsFirstRecDefault = value;
  }

  private void InitPrependEntries(string[] prependStrings, int[] prependValues)
  {
    this.PrependValue = prependValues[0];
    this.PrependUIValue = $"<{prependStrings[0]}>";
    this.Items.Add(new ListItem((AcpListField) this, this.PrependUIValue, true, true));
    if (prependValues.Length <= 1)
      return;
    this.PrependValue2 = prependValues[1];
    this.PrependUIValue2 = $"<{prependStrings[1]}>";
    this.Items.Add(new ListItem((AcpListField) this, this.PrependUIValue2, true, true));
  }

  internal int PrependValue
  {
    get => ((AcpRecRefFieldImpl) this.FieldData).PrependValue;
    set => ((AcpRecRefFieldImpl) this.FieldData).PrependValue = value;
  }

  internal string PrependUIValue
  {
    get => ((AcpRecRefFieldImpl) this.FieldData).PrependUIValue;
    set => ((AcpRecRefFieldImpl) this.FieldData).PrependUIValue = value;
  }

  internal int PrependValue2
  {
    get => ((AcpRecRefFieldImpl) this.FieldData).PrependValue2;
    set => ((AcpRecRefFieldImpl) this.FieldData).PrependValue2 = value;
  }

  internal string PrependUIValue2
  {
    get => ((AcpRecRefFieldImpl) this.FieldData).PrependUIValue2;
    set => ((AcpRecRefFieldImpl) this.FieldData).PrependUIValue2 = value;
  }

  internal bool IsExactPrepend
  {
    get => this.UIValue == this.PrependUIValue || this.UIValue == this.PrependUIValue2;
  }

  public IEnumerable<int> PrependValues
  {
    get
    {
      if (this.PrependUIValue != null)
      {
        yield return this.PrependValue;
        if (this.PrependUIValue2 != null)
          yield return this.PrependValue2;
      }
    }
  }

  public override int Value
  {
    get => base.Value;
    set => this.SetValue(value);
  }

  public override void SetValue(int newValue)
  {
    int num = ConstraintManager.Suspend() ? 1 : 0;
    base.SetValue(newValue);
    if (this.DefaultValue == -1 && newValue != -1)
      this.RefreshDefaultValue();
    if (num == 0)
      return;
    ConstraintManager.Resume();
    this.CallConstraintsX();
  }

  public override string UIValue
  {
    get
    {
      if (!this.ForceValid)
        return this.DirectUIValue;
      if (this.PrependUIValue != null)
      {
        if (this.PrependValue == this.Value)
          return this.PrependUIValue;
        if (this.PrependUIValue2 != null && this.PrependValue2 == this.Value)
          return this.PrependUIValue2;
      }
      return this.ReferencedNode == null ? this.DirectUIValue : this.ReferencedNode.ReferenceKey;
    }
    set
    {
      if (value == null || value == this.UIValue && this.ForceValid)
        return;
      if (UndoManager.MarkForUndo)
      {
        UndoableTask task = (UndoableTask) new ModifyRecRefDataTask(this, value);
        if (this.ValueSetter != null)
        {
          ContainerTask containerTask = new ContainerTask(task.ToString());
          containerTask.AddTask(task);
          this.CallValueSetter(containerTask);
          UndoManager.AddTask((UndoableTask) containerTask);
        }
        else
          UndoManager.AddTask(task);
      }
      else
      {
        this.FirePropertyChangingEvent();
        if (this.ReferencedNode != null && this.ReferencedNode.KeyField != null)
          this.ReferencedNode.KeyField.RemoveRecordReference(this);
        this.ForceValid = true;
        this.ReferencedNode = this.RefRecset == null || this.RefRecset.Count <= 0 ? (FeatureNode) null : (FeatureNode) this.RefRecset.NodeFromKey(value);
        if (this.ReferencedNode != null)
        {
          if (this.ReferencedNode.KeyField != null)
            this.ReferencedNode.KeyField.AddRecordReference(this);
          if (this.Items.Count > 0 && this.Items[0].Temporary)
            this.Items.RemoveAt(0);
          this.SetValue(this.RefRecset.IndexOf((IAcpFeatureNode) this.ReferencedNode) + this.indexBase);
        }
        else if (this.PrependUIValue == value)
        {
          if (this.Items.Count > 0 && this.Items[0].Temporary)
            this.Items.RemoveAt(0);
          this.SetValue(this.PrependValue);
        }
        else if (this.PrependUIValue2 == value)
        {
          if (this.Items.Count > 0 && this.Items[0].Temporary)
            this.Items.RemoveAt(0);
          this.SetValue(this.PrependValue2);
        }
        else
        {
          if (this.Items.Count > 0 && this.Items[0].Temporary)
            this.Items.RemoveAt(0);
          if ((this.Items.Count == 0 || !this.Items[0].Temporary) && (this.Parent == null || this.Parent.FeatureSectionId != 10501) && this.Name != "ZoneVoiceAnnouncementID_A21514" && this.Name != "ChannelAnnouncementID_A20175")
            this.Items.Insert(0, new ListItem((AcpListField) this, value, false, true, true));
          int num = ConstraintManager.Suspend() ? 1 : 0;
          this.DirectUIValue = value;
          this.SetValue(-1);
          if (num != 0)
            ConstraintManager.Resume();
          if (!ConstraintManager.Suspended)
            this.CallConstraintsX();
          this.SetUITimer();
        }
        this.FirePropertyChangedEvent();
      }
    }
  }

  protected internal override void FirePropertyChangingEvent()
  {
    this.FirePropertyChangedEvent();
    ((FeatureSection) this.Parent).FirePropertyChanging(this.Name + "_UIValue");
  }

  public FeatureNode ReferencedNode
  {
    get => this.referencedNode;
    private set
    {
      string uiValue1 = this.UIValue;
      this.referencedNode = value;
      this.UpdateValue();
      foreach (AcpRecRefSlaveItem slaveField in this.SlaveFields)
      {
        if (this.referencedNode != null && this.referencedNode[slaveField.ChildSectionId] != null)
        {
          Recordset embeddedRecset = (Recordset) this.referencedNode[slaveField.ChildSectionId].EmbeddedRecset;
          if (AppInfoManager.DndOrImportOperation && embeddedRecset != null && this.referencedNode.Parent == embeddedRecset.ParentSection.ParentRecset && this.referencedNode != null && this.referencedNode.ReferenceKey == uiValue1)
          {
            string uiValue2 = slaveField.SlaveField.UIValue;
            slaveField.SlaveField.ResetToDefaultNoConstraints();
            slaveField.SlaveField.SetRecset((IAcpRecordset) embeddedRecset);
            if (!string.IsNullOrEmpty(uiValue2) && embeddedRecset.KeysToNode != null && embeddedRecset.KeysToNode.Contains(uiValue2))
              slaveField.SlaveField.UIValue = uiValue2;
          }
          else
          {
            if (slaveField.SlaveField.KeyNameField)
              slaveField.SlaveField.SetValue(slaveField.SlaveField.defaultValue);
            else
              slaveField.SlaveField.ResetToDefaultNoConstraints();
            slaveField.SlaveField.SetRecset((IAcpRecordset) embeddedRecset);
          }
          slaveField.SlaveField.SetUITimer();
        }
        else
        {
          slaveField.SlaveField.RefreshDefaultValue();
          slaveField.SlaveField.SetRecset((IAcpRecordset) null);
          if (AppInfoManager.AppMode == ApplicationMode.CodeplugComparisonMode && this.Parent.ParentRecset.ContainerDoc != null && this.Parent.ParentRecset.ContainerDoc.IsOpen && slaveField.SlaveField.PrependUIValue == null)
          {
            if (slaveField.SlaveField.DirectUIValue != null)
              slaveField.SlaveField.DirectUIValue = (string) null;
            slaveField.SlaveField.UIValue = slaveField.SlaveField.DirectUIValue;
          }
        }
        slaveField.SlaveField.CalculateApplicability();
        slaveField.SlaveField.CalculateValidity();
      }
    }
  }

  internal override void DeepCopy(IAcpField source)
  {
    bool flag = false;
    AcpRecRefField acpRecRefField = (AcpRecRefField) source;
    this.IndexOfDeepCopy = ((Recordset) this.Parent.ParentRecset).IndexOf(source.ParentNode);
    int num1 = 0;
    foreach (Recordset embeddedRecordset in acpRecRefField.ParentNode.EmbeddedRecordsets)
    {
      if (acpRecRefField.RefRecset == embeddedRecordset)
      {
        flag = true;
        break;
      }
      ++num1;
    }
    if (flag)
    {
      int num2 = 0;
      foreach (Recordset embeddedRecordset in this.ParentNode.EmbeddedRecordsets)
      {
        if (num2 == num1)
        {
          this.SetRecset((IAcpRecordset) embeddedRecordset);
          break;
        }
        ++num2;
      }
    }
    else
      this.SetRecset((IAcpRecordset) acpRecRefField.RefRecset);
    this.DefaultValue = acpRecRefField.Value;
    if (this.KeyNameField)
      this.UIValue = acpRecRefField.UIValue;
    base.DeepCopy(source);
    this.RefRecset = !flag ? acpRecRefField.RefRecset : this.RefRecset;
    this.UpdateItems();
  }

  private int indexBase
  {
    get => ((AcpRecRefFieldImpl) this.FieldData).IndexBase;
    set => ((AcpRecRefFieldImpl) this.FieldData).IndexBase = value;
  }

  public bool OneBased => this.indexBase == 1;

  public void AddSlaveField(AcpRecRefField slave, int sectionID)
  {
    if (this.slaveFields == null)
    {
      this.slaveFields = new List<AcpRecRefSlaveItem>();
      this.slaveFields.Add(new AcpRecRefSlaveItem(slave, sectionID));
    }
    else
    {
      foreach (AcpRecRefSlaveItem slaveField in this.slaveFields)
      {
        if (slaveField.SlaveField == slave)
        {
          slave.SlaveRecRef = true;
          if (this.ReferencedNode == null || this.ReferencedNode[sectionID] == null)
            return;
          slave.SetRecset((IAcpRecordset) (this.ReferencedNode[sectionID].EmbeddedRecset as Recordset));
          return;
        }
      }
      this.slaveFields.Add(new AcpRecRefSlaveItem(slave, sectionID));
    }
    slave.SlaveRecRef = true;
    if (this.ReferencedNode == null || this.ReferencedNode[sectionID] == null)
      return;
    slave.SetRecset((IAcpRecordset) (this.ReferencedNode[sectionID].EmbeddedRecset as Recordset));
  }

  internal IEnumerable<AcpRecRefSlaveItem> SlaveFields
  {
    get
    {
      if (this.slaveFields != null)
      {
        foreach (AcpRecRefSlaveItem slaveField in this.slaveFields)
          yield return slaveField;
      }
    }
  }

  internal int SlaveFieldCount => this.slaveFields == null ? 0 : this.slaveFields.Count;

  public bool HasSiblingRecset { get; internal set; }

  internal void ReferencedNodeDeleted()
  {
    this.ReferencedNode = (FeatureNode) null;
    if (!this.Applicable || this.IsEditable == new StateConstraint(AcpConstraints.AcpAlwaysNonEditable))
    {
      this.CalculateAndResetToDefault();
      this.SetUITimer();
    }
    else
    {
      this.ForceValid = false;
      if (this.Items.Count == 0 || !this.Items[0].Temporary)
        this.Items.Insert(0, new ListItem((AcpListField) this, this.InvalidText, false, true, true));
      this.UIValue = this.InvalidText;
      this.DirectUIValue = this.InvalidText;
    }
    foreach (AcpRecRefSlaveItem slaveField in this.SlaveFields)
    {
      if (slaveField.SlaveField.ReferencedNode != null)
        slaveField.SlaveField.CalculateAndResetToDefault();
    }
  }

  private void CalculateAndResetToDefault()
  {
    if (this.PrependUIValue == null || this.IsFirstRecDefault)
    {
      this.DefaultValue = this.indexBase;
      if (this.RefRecset != null && this.RefRecset.Count > 0)
      {
        this.ReferencedNode = this.RefRecset[0] as FeatureNode;
        this.ReferencedNode.KeyField.AddRecordReference(this);
      }
    }
    else
      this.DefaultValue = this.PrependValue;
    this.ForceValid = true;
    base.ResetToDefaultNoConstraints();
  }

  internal override void ResetToDefaultNoConstraints()
  {
    if (this.RefRecset != null)
    {
      bool flag = true;
      if (this.PrependUIValue != null)
      {
        if (this.DefaultValue == this.PrependValue)
          flag = false;
        else if (this.PrependUIValue2 != null && this.DefaultValue == this.PrependValue2)
          flag = false;
      }
      if (flag)
      {
        if (this.DefaultValue == -1)
        {
          if (this.Items.Count == 0 || this.Items[0].ItemName != this.InvalidText)
            this.Items.Insert(0, new ListItem((AcpListField) this, this.InvalidText, false, true, true));
          this.UIValue = this.InvalidText;
          this.DirectUIValue = this.InvalidText;
        }
        else
          this.ReferencedNode = this.RefRecset[this.DefaultValue - this.indexBase] as FeatureNode;
      }
    }
    base.ResetToDefaultNoConstraints();
  }

  public override void ResetToDefaultWithUndo()
  {
    string str = string.Empty;
    if (this.PrependUIValue == null || this.IsFirstRecDefault)
    {
      if (this.RefRecset != null && this.RefRecset.Count > 0)
        str = this.RefRecset[0].ReferenceKey;
    }
    else if (this.UIValue != this.PrependUIValue)
      str = this.PrependUIValue;
    if (this.UIValue != null && this.UIValue.CompareTo(str) != 0 && str != string.Empty)
      UndoManager.AddTask(this.CreateSetValueTask(str));
    this.SetUITimer();
  }

  public override void ResetToDefaultWithUndo(ContainerTask taskContainer)
  {
    string str = string.Empty;
    if (this.PrependUIValue == null || this.IsFirstRecDefault)
    {
      if (this.RefRecset != null && this.RefRecset.Count > 0)
        str = this.RefRecset[0].ReferenceKey;
    }
    else if (this.UIValue != this.PrependUIValue)
      str = this.PrependUIValue;
    if (this.UIValue != null && this.UIValue.CompareTo(str) != 0 && str != string.Empty)
      taskContainer.AddTask(this.CreateSetValueTask(str));
    this.SetUITimer();
  }

  internal override void CreateFieldData(string uiName)
  {
    this.FieldData = (AcpFieldImplBase) new AcpRecRefFieldImpl(uiName);
  }

  public override UndoableTask CopyValueOf(IAcpField source)
  {
    if (source is AcpRecRefField acpRecRefField)
    {
      this.DefaultValue = acpRecRefField.DefaultValue;
      string uiValue = acpRecRefField.UIValue;
      if (this.UIValue == null || !this.UIValue.Equals(uiValue))
        return this.CreateSetValueTask(uiValue);
    }
    return (UndoableTask) null;
  }

  public void CleanupDuplicates()
  {
    if (this.Items.Count == 0 || !this.Items[0].Temporary || !(this.Items[0].ItemName != this.InvalidText))
      return;
    foreach (ListItem listItem in (Collection<ListItem>) this.Items)
    {
      if (this.Items[0] != listItem && this.Items[0].ItemName == listItem.ItemName)
      {
        this.Items.RemoveAt(0);
        this.UIValue = listItem.ItemName;
        break;
      }
    }
  }

  public override void CalculateItemsValidity()
  {
    if (this.Items.Count == 0)
      return;
    if (this.IsIndexValid == null)
    {
      foreach (ListItem listItem in (Collection<ListItem>) this.Items)
      {
        if (listItem is AcpRecRefItem acpRecRefItem)
          acpRecRefItem.ItemValidity = true;
      }
    }
    else
    {
      int index1 = this.Items[0].Temporary ? 1 : 0;
      ((FeatureSection) this.Parent).CurrentField = (IAcpField) this;
      if (this.PrependUIValue != null && index1 < this.Items.Count)
        this.Items[index1].ItemValidity = this.IsIndexValid(this.Parent, this.PrependValue);
      if (this.PrependUIValue2 != null && index1 + 1 < this.Items.Count)
        this.Items[index1 + 1].ItemValidity = this.IsIndexValid(this.Parent, this.PrependValue2);
      for (int index2 = this.PrependCount + index1; index2 < this.Items.Count; ++index2)
        this.Items[index2].ItemValidity = this.IsIndexValid(this.Parent, index2 + this.indexBase - this.PrependCount - index1);
    }
  }

  private void RefreshDefaultValue()
  {
    if (this.PrependUIValue == null || this.IsFirstRecDefault)
      this.DefaultValue = this.indexBase;
    else
      this.DefaultValue = this.PrependValue;
  }

  internal override UndoableTask CreateSetValueTask(string newValue)
  {
    ModifyRecRefDataTask task = new ModifyRecRefDataTask(this, newValue);
    if (this.ValueSetter == null)
      return (UndoableTask) task;
    ContainerTask containerTask = new ContainerTask(task.ToString());
    containerTask.AddTask((UndoableTask) task);
    this.CallValueSetter(containerTask);
    return (UndoableTask) containerTask;
  }

  internal override int CompareToHelper(AcpFieldBase otherField)
  {
    int helper = 0;
    if (!(otherField is AcpRecRefField acpRecRefField))
      helper = 1;
    else if (this.UIValue != null && this.UIValue != this.InvalidText)
      helper = acpRecRefField.UIValue == null || !(acpRecRefField.UIValue != this.InvalidText) ? 1 : this.UIValue.CompareTo(acpRecRefField.UIValue);
    else if (acpRecRefField.UIValue != null && acpRecRefField.UIValue != this.InvalidText)
      helper = -1;
    return helper;
  }

  public void RefreshRecRefItems()
  {
    foreach (ListItem listItem in (Collection<ListItem>) this.Items)
    {
      if (listItem is AcpRecRefItem acpRecRefItem)
        acpRecRefItem.ItemName = acpRecRefItem.Node.ReferenceKey;
    }
  }

  public IEnumerator<string> GetEnumerator()
  {
    foreach (ListItem listItem in (Collection<ListItem>) this.Items)
      yield return listItem.ItemName;
  }

  IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.GetEnumerator();

  protected override void Dispose(bool disposing)
  {
    if (this.isDisposeInProgress)
      return;
    if (!this.disposedValue)
    {
      if (disposing)
      {
        this.isDisposeInProgress = true;
        this.DisposeRecords();
      }
      this.disposedValue = true;
    }
    this.isDisposeInProgress = false;
    base.Dispose(disposing);
  }

  private void DisposeRecords()
  {
    if (this.RefRecset == null)
      return;
    this.RefRecset.CollectionChanged -= new NotifyCollectionChangedEventHandler(this.OnReferencedCollectionChanged);
    this.RefRecset.ReferenceKeyChanged -= new EventHandler(this.OnReferencedRecsetKeyChanged);
    this.RefRecset.Dispose();
  }
}
