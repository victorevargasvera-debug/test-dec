// Decompiled with JetBrains decompiler
// Type: AcpBusinessLayer.AcpListField
// Assembly: AcpBusinessLayer, Version=23.1.0.23, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 44CF2A76-4418-422B-9DDD-B27A71BAF20C
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpBusinessLayer.dll

using AcpBusinessLayer.Impl;
using AcpBusinessLayer.UndoRedo;
using AcpCommonLib;
using AcpCommonLib.UndoRedo;
using AcpCommonResources;
using AcpUtility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using System.Xml;

#nullable disable
namespace AcpBusinessLayer;

[Serializable]
public class AcpListField : AcpFieldX<int, string>, IAcpListField
{
  private NotifyCollectionChangedEventHandler _collectionChangedHandler;

  public AcpListField BuddyList
  {
    get => ((AcpListFieldImpl) this.FieldData).BuddyList;
    set => ((AcpListFieldImpl) this.FieldData).BuddyList = value;
  }

  public virtual ObservableCollection<ListItem> Items { get; internal set; }

  public virtual ObservableCollection<ListItem> UnsupportedItems { get; internal set; }

  internal ListItem this[int index]
  {
    get => index >= this.Items.Count ? (ListItem) null : this.Items[index];
  }

  internal int IndexOf(ListItem item) => this.Items.IndexOf(item);

  public bool SerializeItems
  {
    get => ((AcpListFieldImpl) this.FieldData).SerializeItems;
    private set => ((AcpListFieldImpl) this.FieldData).SerializeItems = value;
  }

  public bool UndoIgnoresSelection
  {
    get => ((AcpListFieldImpl) this.FieldData).UndoIgnoresSelection;
    set => ((AcpListFieldImpl) this.FieldData).UndoIgnoresSelection = value;
  }

  protected AcpListField()
  {
  }

  public AcpListField(FeatureSection parent, string name, string uiLabel, string[] items)
    : this(parent, name, uiLabel)
  {
    foreach (string name1 in items)
      this.AddItemHelper(name1);
  }

  public AcpListField(
    FeatureSection parent,
    string name,
    string uiLabel,
    string[] items,
    string[] legacyUILabels)
    : this(parent, name, legacyUILabels, uiLabel)
  {
    foreach (string name1 in items)
      this.AddItemHelper(name1);
  }

  public AcpListField(
    int value,
    FeatureSection parent,
    string name,
    string uiLabel,
    string[] items)
    : this(value, parent, name, uiLabel)
  {
    foreach (string name1 in items)
      this.AddItemHelper(name1);
  }

  public AcpListField(
    int value,
    FeatureSection parent,
    string name,
    string uiLabel,
    string[] items,
    string[] legacyUILabels)
    : base(value, parent, name, uiLabel, legacyUILabels)
  {
    this.Items = new ObservableCollection<ListItem>();
    this._collectionChangedHandler = new NotifyCollectionChangedEventHandler(this.ItemsCollectionChanged);
    this.HandleItemsCollectionChanged();
    foreach (string name1 in items)
      this.AddItemHelper(name1);
  }

  public AcpListField(
    int value,
    FeatureSection parent,
    string name,
    string uiLabel,
    bool sortItems,
    string[] items)
    : this(value, parent, name, uiLabel)
  {
    if (sortItems)
      Array.Sort<string>(items);
    foreach (string name1 in items)
      this.AddItemHelper(name1);
  }

  public AcpListField(
    int value,
    FeatureSection parent,
    string name,
    string uiLabel,
    bool sortItems,
    string[] items,
    string[] legacyUILabels)
    : this(value, parent, name, uiLabel, legacyUILabels)
  {
    if (sortItems)
      Array.Sort<string>(items);
    foreach (string name1 in items)
      this.AddItemHelper(name1);
  }

  protected AcpListField(FeatureSection parent, string name, string uiLabel, bool serializeItems)
    : this(parent, name, uiLabel)
  {
    this.SerializeItems = serializeItems;
    this.UnsupportedItems = new ObservableCollection<ListItem>();
    if (parent.HasListItemsToSerialize)
      return;
    parent.HasListItemsToSerialize = serializeItems;
  }

  protected AcpListField(
    int value,
    FeatureSection parent,
    string name,
    string uiLabel,
    bool serializeItems)
    : this(value, parent, name, uiLabel)
  {
    this.SerializeItems = serializeItems;
    this.UnsupportedItems = new ObservableCollection<ListItem>();
    if (parent.HasListItemsToSerialize)
      return;
    parent.HasListItemsToSerialize = serializeItems;
  }

  protected AcpListField(
    FeatureSection parent,
    string name,
    string uiLabel,
    string[] items,
    bool serializeItems)
    : this(parent, name, uiLabel, items)
  {
    this.SerializeItems = serializeItems;
    this.UnsupportedItems = new ObservableCollection<ListItem>();
    if (parent.HasListItemsToSerialize)
      return;
    parent.HasListItemsToSerialize = serializeItems;
  }

  protected AcpListField(
    FeatureSection parent,
    string name,
    string uiLabel,
    string[] items,
    bool serializeItems,
    string[] legacyUILabels)
    : this(parent, name, legacyUILabels, uiLabel)
  {
    foreach (string name1 in items)
      this.AddItemHelper(name1);
    this.SerializeItems = serializeItems;
    this.UnsupportedItems = new ObservableCollection<ListItem>();
    if (parent.HasListItemsToSerialize)
      return;
    parent.HasListItemsToSerialize = serializeItems;
  }

  protected AcpListField(
    int value,
    FeatureSection parent,
    string name,
    string uiLabel,
    string[] items,
    bool serializeItems)
    : this(value, parent, name, uiLabel, items)
  {
    this.SerializeItems = serializeItems;
    this.UnsupportedItems = new ObservableCollection<ListItem>();
    if (parent.HasListItemsToSerialize)
      return;
    parent.HasListItemsToSerialize = serializeItems;
  }

  protected AcpListField(FeatureSection parent, string name, string uiLabel)
    : base(parent, name, uiLabel)
  {
    this.Items = new ObservableCollection<ListItem>();
    this._collectionChangedHandler = new NotifyCollectionChangedEventHandler(this.ItemsCollectionChanged);
    this.HandleItemsCollectionChanged();
  }

  protected AcpListField(
    FeatureSection parent,
    string name,
    string[] legacyUILabels,
    string uiLabel)
    : base(parent, name, uiLabel, legacyUILabels)
  {
    this.Items = new ObservableCollection<ListItem>();
    this._collectionChangedHandler = new NotifyCollectionChangedEventHandler(this.ItemsCollectionChanged);
    this.HandleItemsCollectionChanged();
  }

  protected AcpListField(int value, FeatureSection parent, string name, string uiLabel)
    : base(value, parent, name, uiLabel)
  {
    this.Items = new ObservableCollection<ListItem>();
    this._collectionChangedHandler = new NotifyCollectionChangedEventHandler(this.ItemsCollectionChanged);
    this.HandleItemsCollectionChanged();
  }

  public virtual void AddItem(string name)
  {
    if (UndoManager.MarkForUndo)
      UndoManager.AddTask((UndoableTask) new AddListItemTask(this, name));
    else
      this.AddItemHelper(name);
  }

  internal int AddItemHelper(string name)
  {
    if (this.Items.Count >= ((AcpListFieldImpl) this.FieldData).ItemCount)
      ((AcpListFieldImpl) this.FieldData).DoubleItems();
    int count = this.Items.Count;
    this.Items.Add(new ListItem(this, name));
    return count;
  }

  internal void InsertItem(int index, string name)
  {
    this.Items.Insert(index, new ListItem(this, name));
  }

  internal void RemoveItem(string name)
  {
    foreach (ListItem listItem in (Collection<ListItem>) this.Items)
    {
      if (listItem.ItemName == name)
      {
        this.Items.Remove(listItem);
        break;
      }
    }
  }

  public string RemoveItemAt(int index)
  {
    string str = (string) null;
    if (UndoManager.MarkForUndo)
    {
      UndoManager.AddTask((UndoableTask) new RemoveListItemTask(this, index));
    }
    else
    {
      str = this.Items[index].ItemName;
      this.Items.RemoveAt(index);
    }
    return str;
  }

  public void MoveItem(int oldIndex, int newIndex)
  {
    if (UndoManager.MarkForUndo)
      UndoManager.AddTask((UndoableTask) new MoveListItemTask(this, oldIndex, newIndex));
    else
      this.MoveItemHelper(oldIndex, newIndex);
  }

  internal void MoveItemHelper(int oldIndex, int newIndex) => this.Items.Move(oldIndex, newIndex);

  public override void ParseDefaultValueFrom(string value) => this.DefaultValue = this.Parse(value);

  private int Parse(string value)
  {
    this.UnsupportedValue = false;
    int result;
    if (int.TryParse(value, out result))
      return result;
    for (int index = 0; index < this.Items.Count; ++index)
    {
      if (this.Items[index].ItemName == value)
        return index;
    }
    this.UnsupportedValue = true;
    return this.Value;
  }

  public override string UIValue
  {
    get => this.Items[this.Value].ItemName;
    set
    {
      if (value == null)
        return;
      bool flag = true;
      int num = -1;
      for (int index = 0; index < this.Items.Count; ++index)
      {
        string itemName = this.Items[index].ItemName;
        bool itemVisibility = this.Items[index].ItemVisibility;
        if (itemName == value && (AppInfoManager.DragOperation || AppInfoManager.BackgroundDeserializeOpertaion || ((AppInfoManager.DragOperation ? 0 : (!AppInfoManager.BackgroundDeserializeOpertaion ? 1 : 0)) & (itemVisibility ? 1 : 0)) != 0))
        {
          this.Value = index;
          this.UnsupportedValue = false;
          return;
        }
        if (itemVisibility)
          flag = false;
        if (itemName == value && index == this.DefaultValue)
          num = index;
      }
      if (flag && num != -1)
      {
        this.Value = num;
        this.UnsupportedValue = false;
      }
      else
      {
        this.UnsupportedValue = true;
        throw new ArgumentException(AcpResources.Cannot_Be_Set.AcpStringFormat((object) this.Name, (object) value));
      }
    }
  }

  public override int Value
  {
    get => base.Value;
    set
    {
      if (value < 0 || this.Items != null && value >= this.Items.Count)
        return;
      if (this.UndoIgnoresSelection)
        this.SetValue(value);
      else
        base.Value = value;
    }
  }

  internal override int CompareToHelper(AcpFieldBase otherField)
  {
    if (!this.SerializeItems)
      return base.CompareToHelper(otherField);
    AcpListField acpListField = (AcpListField) otherField;
    if (this.Items.Count < acpListField.Items.Count)
      return -1;
    if (this.Items.Count > acpListField.Items.Count)
      return 1;
    for (int index = 0; index < this.Items.Count; ++index)
    {
      ListItem listItem1 = this.Items[index];
      ListItem listItem2 = acpListField.Items[index];
      int helper = listItem1.ItemName.CompareTo(listItem2.ItemName);
      if (helper != 0)
        return helper;
      if (listItem1.ItemVisibility != listItem2.ItemVisibility)
        return !listItem1.ItemVisibility ? -1 : 1;
    }
    return 0;
  }

  public override StateConstraint IsValid
  {
    get
    {
      throw new InvalidOperationException("AcpListField does not support this property.  Use IsIndexValid instead.");
    }
    set
    {
      throw new InvalidOperationException("AcpListField does not support this property.  Use IsIndexValid instead.");
    }
  }

  public ListItemStateConstraint IsIndexValid
  {
    get => ((AcpListFieldImpl) this.FieldData).IsIndexValid;
    set
    {
      ((FeatureNode) this.Parent.Parent).RegisterValidity((IAcpField) this);
      ((AcpListFieldImpl) this.FieldData).IsIndexValid = value;
    }
  }

  internal override void ValidityHelper()
  {
    if (AcpDocument.PageOnLoading)
    {
      ListItemStateConstraint isIndexValid = this.IsIndexValid;
      bool flag = false;
      if (isIndexValid != null && isIndexValid.Method != (MethodInfo) null)
      {
        foreach (object customAttribute in isIndexValid.Method.GetCustomAttributes(true))
        {
          if (customAttribute != null && customAttribute.ToString().Equals("ConstraintHelper.TriggerValidOnLoading"))
            flag = true;
        }
      }
      if (!flag)
        return;
    }
    if (!this.Applicable)
      return;
    bool flag1 = AcpConstraints.AcpValidilityRules((IAcpField) this);
    if (this.IsIndexValid != null && this.Value >= 0)
    {
      ((FeatureSection) this.Parent).CurrentField = (IAcpField) this;
      this.Valid = flag1 && this.IsIndexValid(this.Parent, this.Value);
    }
    else
      this.Valid = flag1;
  }

  public virtual void CalculateItemsValidity()
  {
    if (this.IsIndexValid == null)
      return;
    ((FeatureSection) this.Parent).CurrentField = (IAcpField) this;
    for (int index = 0; index < this.Items.Count; ++index)
      this.Items[index].ItemValidity = this.IsIndexValid(this.Parent, index);
  }

  internal ListItemImageConstraint IndexImage
  {
    get => ((AcpListFieldImpl) this.FieldData).IndexImage;
    private set => ((AcpListFieldImpl) this.FieldData).IndexImage = value;
  }

  protected override void VisibilityHelper()
  {
    if (this.IndexImage == null)
      return;
    this.IndexImage(this.Parent, (IAcpField) this);
  }

  public override UndoableTask CopyValueOf(IAcpField source)
  {
    AcpListField acpListField = source as AcpListField;
    if (this.SerializeItems)
    {
      if (this.BuddyList == null)
        this.BuddyList = this;
      if (this.UnsupportedItems != null)
        this.UnsupportedItems.Clear();
      List<AddListItemTask> addListItemTaskList = new List<AddListItemTask>();
      int index = 0;
      foreach (ListItem listItem1 in (Collection<ListItem>) acpListField.Items)
      {
        ListItem sourceItem = listItem1;
        ListItem listItem2 = this.BuddyList.Items.FirstOrDefault<ListItem>((Func<ListItem, bool>) (buddy => buddy.ItemName == sourceItem.ItemName));
        if (listItem2 != null)
        {
          if (listItem2.ItemVisibility)
          {
            addListItemTaskList.Add(new AddListItemTask(this, sourceItem.ItemName, index));
            ++index;
          }
          else
          {
            this.UnsupportedItems.Add(listItem2);
            this.UnsupportedValue = true;
          }
        }
        else
        {
          this.UnsupportedItems.Add(new ListItem(this, sourceItem.ItemName));
          this.UnsupportedValue = true;
        }
      }
      ContainerTask containerTask = new ContainerTask(AcpResources.Copy_List_Item);
      if (addListItemTaskList != null && addListItemTaskList.Count > 0)
      {
        while (this.Items.Count > 0)
          containerTask.AddTask((UndoableTask) new RemoveListItemTask(this, 0));
        foreach (AddListItemTask task in addListItemTaskList)
          containerTask.AddTask((UndoableTask) task);
      }
      return (UndoableTask) containerTask;
    }
    string uiValue = acpListField.UIValue;
    if (this.UIValue != null && this.UIValue.Equals(uiValue))
    {
      this.UnsupportedValue = false;
      return (UndoableTask) null;
    }
    foreach (ListItem listItem in (Collection<ListItem>) this.Items)
    {
      if (listItem.ItemName.CompareTo(uiValue) == 0 && listItem.ItemVisibility)
      {
        this.UnsupportedValue = false;
        return this.GetModifyDataTask(((AcpField<int>) source).Value);
      }
    }
    this.UnsupportedValue = true;
    return (UndoableTask) null;
  }

  public UndoableTask GetModifyDataTask(int newValue)
  {
    ModifyDataTask<int> task = new ModifyDataTask<int>((AcpField<int>) this, newValue);
    if (this.ValueSetter == null)
      return (UndoableTask) task;
    ContainerTask containerTask = new ContainerTask(task.ToString());
    containerTask.AddTask((UndoableTask) task);
    this.CallValueSetter(containerTask);
    return (UndoableTask) containerTask;
  }

  internal void BuildItemsXml(XmlElement element)
  {
    foreach (ListItem listItem in (Collection<ListItem>) this.Items)
    {
      XmlElement element1 = element.OwnerDocument.CreateElement("Item");
      element1.InnerText = listItem.ItemName;
      element.AppendChild((XmlNode) element1);
    }
  }

  internal UndoableTask CopyValuesFromXml(XmlNode node)
  {
    if (this.BuddyList == null)
      this.BuddyList = this;
    if (this.UnsupportedItems != null)
      this.UnsupportedItems.Clear();
    List<AddListItemTask> addListItemTaskList = new List<AddListItemTask>();
    int index = 0;
    foreach (XmlNode childNode1 in node.ChildNodes)
    {
      XmlNode childNode = childNode1;
      ListItem listItem = this.BuddyList.Items.FirstOrDefault<ListItem>((Func<ListItem, bool>) (buddy => buddy.ItemName == childNode.InnerText));
      if (listItem != null)
      {
        if (listItem.ItemVisibility)
        {
          addListItemTaskList.Add(new AddListItemTask(this, childNode.InnerText, index));
          ++index;
        }
        else
        {
          this.UnsupportedItems.Add(listItem);
          this.UnsupportedValue = true;
        }
      }
      else
      {
        this.UnsupportedItems.Add(new ListItem(this, childNode.InnerText));
        this.UnsupportedValue = true;
      }
    }
    ContainerTask containerTask = new ContainerTask(AcpResources.Copy_Values);
    if (addListItemTaskList != null && addListItemTaskList.Count > 0)
    {
      while (this.Items.Count > 0)
        containerTask.AddTask((UndoableTask) new RemoveListItemTask(this, 0));
      foreach (AddListItemTask task in addListItemTaskList)
        containerTask.AddTask((UndoableTask) task);
    }
    return (UndoableTask) containerTask;
  }

  internal override void CreateFieldData(string uiName)
  {
    this.FieldData = (AcpFieldImplBase) new AcpListFieldImpl(uiName);
  }

  internal bool GetItemVisibility(ListItem item)
  {
    return this.Items.Contains(item) && ((AcpListFieldImpl) this.FieldData).GetItemVisibility(this.IndexOf(item));
  }

  internal void SetItemVisibility(ListItem item, bool value)
  {
    if (!this.Items.Contains(item))
      return;
    ((AcpListFieldImpl) this.FieldData).SetItemVisibility(this.IndexOf(item), value);
  }

  private void ItemsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
  {
    this.UpdateComparison();
  }

  private void HandleItemsCollectionChanged()
  {
    INotifyCollectionChanged items = (INotifyCollectionChanged) this.Items;
    if (items == null)
      return;
    items.CollectionChanged += this._collectionChangedHandler;
  }

  public string BuildReportString()
  {
    if (this.UnsupportedItems == null || this.UnsupportedItems.Count <= 0)
      return string.Join(", ", this.Items.Take<ListItem>(this.Items.Count > 5 ? 5 : this.Items.Count).Select<ListItem, string>((Func<ListItem, string>) (x => x.ItemName)).ToArray<string>()) + (this.Items.Count > 5 ? "..." : "");
    int count = this.UnsupportedItems.Count > 5 ? 5 : this.UnsupportedItems.Count;
    return string.Join(", ", this.UnsupportedItems.Distinct<ListItem>().Take<ListItem>(count).Select<ListItem, string>((Func<ListItem, string>) (x => x.ItemName)).ToArray<string>()) + (this.UnsupportedItems.Count > 5 ? "..." : "");
  }
}
