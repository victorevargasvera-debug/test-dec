// Decompiled with JetBrains decompiler
// Type: AcpBusinessLayer.FeatureNode
// Assembly: AcpBusinessLayer, Version=23.1.0.23, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 44CF2A76-4418-422B-9DDD-B27A71BAF20C
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpBusinessLayer.dll

using AcpCommonLib;
using AcpCommonLib.UndoRedo;
using AcpCommonResources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.XPath;

#nullable disable
namespace AcpBusinessLayer;

[DebuggerDisplay("Node = {FeatureName}, RefKey = {ReferenceKey}, NodeID = {NodeId}")]
[Serializable]
public abstract class FeatureNode : 
  IAcpFeatureNode,
  IAcpConstraints,
  IAcpCommon,
  IDisposable,
  ISerializable,
  INotifyPropertyChanged
{
  private Recordset parent;
  private int id;
  private DifferenceCount diffCount;
  internal List<IAcpField> fieldsAll = new List<IAcpField>();
  internal List<IAcpField> fieldsWithValidity = new List<IAcpField>();
  internal List<IAcpField> fieldsWithApplicability = new List<IAcpField>();
  internal List<IAcpField> fieldsWithEditability = new List<IAcpField>();
  internal List<IAcpField> fieldsWithVisibility = new List<IAcpField>();
  private List<AcpRecRefField> recRefFields = new List<AcpRecRefField>();
  private Dictionary<int, FeatureSection> sections;
  private SortedDictionary<int, FeatureSection> sectionsByOrder;
  internal static int NodeIdCounter;
  private string uiName;
  private bool deleted;
  private bool valid = true;
  private bool disposedValue;
  private bool isDisposeInProgress;

  public AcpKeyField KeyField { get; private set; }

  public bool HasEmbeddedRecset { get; private set; }

  internal bool bAddCurrentOnParent { get; private set; }

  public bool Deleted
  {
    get => this.deleted;
    internal set
    {
      this.deleted = value;
      if (this.Parent == null || this.Parent.IsEmbeddedRecset)
        return;
      foreach (Collection<FeatureNode> embeddedRecordset in this.EmbeddedRecordsets)
      {
        foreach (FeatureNode featureNode in embeddedRecordset)
          featureNode.Deleted = value;
      }
    }
  }

  public FeatureNodeConstraint NodeDeleted { get; set; }

  private FeatureNode()
  {
    this.id = ++FeatureNode.NodeIdCounter;
    this.diffCount = new DifferenceCount();
    this.diffCount.CountChanged += new DifferenceCountChangedEventHandler(this.OnSectionDifferenceCountChanged);
  }

  protected FeatureNode(Recordset parent)
    : this()
  {
    this.sections = new Dictionary<int, FeatureSection>();
    this.sectionsByOrder = new SortedDictionary<int, FeatureSection>();
    this.parent = parent;
  }

  internal FeatureNode DeepCopy(Dictionary<IAcpField, string> RecRefsToRepair)
  {
    return this.DeepCopy(true, RecRefsToRepair);
  }

  internal void RegisterValidity(IAcpField field) => this.fieldsWithValidity.Add(field);

  internal void RegisterApplicability(IAcpField field) => this.fieldsWithApplicability.Add(field);

  internal void RegisterVisibility(IAcpField field) => this.fieldsWithVisibility.Add(field);

  internal void RegisterEditability(IAcpField field) => this.fieldsWithEditability.Add(field);

  private FeatureNode DeepCopy(
    bool checkDuplicateKey,
    Dictionary<IAcpField, string> RecRefsToRepair)
  {
    bool flag1 = UndoManager.StopUndoRedo();
    bool flag2 = ConstraintManager.Suspend();
    FeatureNode defaultRecordHelper = ((Recordset) this.Parent).CreateDefaultRecordHelper();
    defaultRecordHelper.FeatureName = this.FeatureName;
    defaultRecordHelper.UIPagePath = this.UIPagePath;
    defaultRecordHelper.TreeNodeLabel = this.TreeNodeLabel;
    defaultRecordHelper.HasEmbeddedRecset = this.HasEmbeddedRecset;
    foreach (FeatureSection featureSection1 in this.FeatureSectionsCollectionByOrder)
    {
      FeatureSection featureSection2 = defaultRecordHelper[featureSection1.FeatureSectionId] as FeatureSection;
      featureSection2.FeatureSectionName = featureSection1.FeatureSectionName;
      if (featureSection2.HasEmbeddedRecset)
      {
        Recordset embeddedRecset = featureSection2.EmbeddedRecset as Recordset;
        int count = embeddedRecset.Count;
        embeddedRecset.lastId = 0;
        foreach (FeatureNode featureNode in (Collection<FeatureNode>) featureSection1.EmbeddedRecset)
          embeddedRecset.AddRecord(featureNode.DeepCopyEmbedded(false, embeddedRecset));
        embeddedRecset.lastId = ((Recordset) featureSection1.EmbeddedRecset).Count;
        while (count-- > 0)
          embeddedRecset.RemoveRecordAt(0);
      }
      foreach (AcpFieldBase acpFieldBase in featureSection2.FieldsCollectionByOrder)
      {
        acpFieldBase.DeepCopy(featureSection1[acpFieldBase.UIName]);
        if (acpFieldBase is AcpRecRefField key)
          RecRefsToRepair[(IAcpField) key] = ((AcpFieldX<int, string>) featureSection1[acpFieldBase.UIName]).UIValue;
      }
    }
    if (flag2)
      ConstraintManager.Resume();
    if (checkDuplicateKey && defaultRecordHelper.KeyField != null && this.ReferenceKey == defaultRecordHelper.ReferenceKey)
      defaultRecordHelper.KeyField.ForceValid = false;
    if (flag1)
      UndoManager.StartUndoRedo();
    return defaultRecordHelper;
  }

  private FeatureNode DeepCopyEmbedded(bool checkDuplicateKey, Recordset newRecset)
  {
    bool flag1 = UndoManager.StopUndoRedo();
    bool flag2 = ConstraintManager.Suspend();
    FeatureNode defaultRecordHelper = ((Recordset) this.Parent).CreateDefaultRecordHelper();
    defaultRecordHelper.Parent = (IAcpRecordset) newRecset;
    if (!newRecset.HasKeyField && defaultRecordHelper.KeyField != null)
      newRecset.InitKeysToNode();
    defaultRecordHelper.FeatureName = this.FeatureName;
    defaultRecordHelper.UIPagePath = this.UIPagePath;
    defaultRecordHelper.TreeNodeLabel = this.TreeNodeLabel;
    defaultRecordHelper.HasEmbeddedRecset = this.HasEmbeddedRecset;
    defaultRecordHelper.bAddCurrentOnParent = true;
    foreach (FeatureSection featureSection1 in this.FeatureSectionsCollectionByOrder)
    {
      FeatureSection featureSection2 = defaultRecordHelper[featureSection1.FeatureSectionId] as FeatureSection;
      featureSection2.FeatureSectionName = featureSection1.FeatureSectionName;
      foreach (AcpFieldBase acpFieldBase in featureSection2.FieldsCollectionByOrder)
        acpFieldBase.DeepCopy(featureSection1[acpFieldBase.UIName]);
    }
    defaultRecordHelper.bAddCurrentOnParent = false;
    if (flag2)
      ConstraintManager.Resume();
    if (flag1)
      UndoManager.StartUndoRedo();
    return defaultRecordHelper;
  }

  internal void InvokeRecRefValidities()
  {
    foreach (FeatureNode referencingNode in this.ReferencingNodes)
      referencingNode.CallConstraints();
  }

  internal void CalculateValidityWithoutDependencies()
  {
    foreach (FeatureSection featureSection in this.sections.Values)
      featureSection.CalculateValidityWithoutDependencies();
  }

  public override string ToString() => this.ReferenceKey;

  internal void SetupDependencies()
  {
    foreach (FeatureSection featureSection in this.sections.Values)
    {
      featureSection.SetupDependencies();
      if (featureSection.HasEmbeddedRecset)
        ((Recordset) featureSection.EmbeddedRecset).SetupDependencies();
    }
  }

  internal void SetConstraints()
  {
    foreach (FeatureSection featureSection in this.sections.Values)
    {
      featureSection.SetConstraints();
      if (featureSection.HasEmbeddedRecset)
        ((Recordset) featureSection.EmbeddedRecset).SetConstraints();
    }
  }

  internal void Initialize()
  {
    this.SetupDependencies();
    this.PopulateReferences();
    this.SetConstraints();
  }

  internal bool AddToXml(XmlNode node, XmlFileType fileType)
  {
    XmlElement element = node.OwnerDocument.CreateElement(this.Parent.IsEmbeddedRecset ? "EmbeddedNode" : "Node");
    element.SetAttribute("Name", this.UIName);
    element.SetAttribute("ReferenceKey", this.ReferenceKey);
    foreach (IAcpFeatureSection featureSections in this.FeatureSectionsCollection)
    {
      if (featureSections.HasVisibleObjects || featureSections.HasEmbeddedRecset && featureSections.EmbeddedRecset.Count == 0)
        ((FeatureSection) featureSections).AddToXml((XmlNode) element, fileType);
    }
    node.AppendChild((XmlNode) element);
    return true;
  }

  internal bool ReadFromXml(
    XmlNode node,
    ContainerTask task,
    XmlFileType fileType,
    bool importCopyOper,
    Dictionary<IAcpField, string> RecRefsToRepair,
    Dictionary<IAcpField, string> RecRefFieldsOfEmbedRecset)
  {
    XmlAttribute attribute1 = node.Attributes["Name"];
    if (attribute1 == null)
      return false;
    bool flag = true;
    this.FeatureName = attribute1.Value;
    SortedDictionary<int, int> sortedDictionary = new SortedDictionary<int, int>();
    foreach (XmlNode childNode in node.ChildNodes)
    {
      XmlAttribute attribute2 = childNode.Attributes["id"];
      if (attribute2 != null)
      {
        int result;
        if (int.TryParse(attribute2.Value, out result))
        {
          FeatureSection featureSection = (FeatureSection) this[result];
          if (featureSection != null)
          {
            if (featureSection.DataTransferOrder > 0)
              sortedDictionary.Add(featureSection.DataTransferOrder, result);
          }
          else if (fileType == XmlFileType.ImpExp)
            Utility.LogMissingXmlNode((IXPathNavigable) childNode);
        }
      }
      else
      {
        flag = false;
        break;
      }
    }
    foreach (KeyValuePair<int, int> keyValuePair in sortedDictionary)
    {
      if (flag)
      {
        foreach (XmlNode childNode in node.ChildNodes)
        {
          int result;
          if (int.TryParse(childNode.Attributes["id"].Value, out result))
          {
            if (keyValuePair.Value == result)
            {
              FeatureSection featureSection = (FeatureSection) this[result];
              AppInfoManager.DndAndImportSection.Add(featureSection.GetType());
              if (featureSection != null)
              {
                if (!featureSection.ReadFromXml(childNode, task, fileType, importCopyOper, RecRefsToRepair, RecRefFieldsOfEmbedRecset))
                {
                  flag = false;
                  break;
                }
                break;
              }
              if (fileType == XmlFileType.ImpExp)
              {
                Utility.LogMissingXmlNode((IXPathNavigable) childNode);
                break;
              }
              break;
            }
          }
          else
          {
            flag = false;
            break;
          }
        }
      }
    }
    return flag;
  }

  internal IAcpField FieldFromPathHelper(string path, bool absolute, string delimiter)
  {
    IAcpField acpField = (IAcpField) null;
    foreach (FeatureSection featureSections in this.FeatureSectionsCollection)
    {
      acpField = featureSections.FieldFromPathHelper(path, absolute, delimiter);
      if (acpField != null)
        break;
    }
    return acpField;
  }

  [XmlIgnore]
  public IAcpRecordset Parent
  {
    get => (IAcpRecordset) this.parent;
    set => this.parent = (Recordset) value;
  }

  public string FeatureName { get; set; }

  public bool Valid
  {
    get => this.valid;
    internal set
    {
      if (this.valid == value)
        return;
      this.valid = value;
      if (this.PropertyChanged != null)
        this.PropertyChanged((object) this, new PropertyChangedEventArgs(nameof (Valid)));
      if (value)
      {
        if (AppInfoManager.DragOperation || AppInfoManager.BackgroundDeserializeOpertaion)
          return;
        AppInfoManager.InvalidFieldsReport.UnregisterFieldInReport((IAcpFeatureNode) this);
        AppInfoManager.InvalidFieldsReport.PostFieldsReport();
      }
      else
      {
        if (AppInfoManager.DragOperation || AppInfoManager.BackgroundDeserializeOpertaion || AppInfoManager.InvalidFieldsReport.ContainsField((IAcpFeatureNode) this))
          return;
        AppInfoManager.InvalidFieldsReport.RegisterFieldInReport((IAcpFeatureNode) this, AcpResources.Extra_Record);
        AppInfoManager.InvalidFieldsReport.PostFieldsReport();
      }
    }
  }

  public virtual string ReferenceKey
  {
    get => this.KeyField == null ? this.FeatureName : this.KeyField.DisplayText;
  }

  public int NodeId => this.id;

  public string UIPagePath { get; protected set; }

  public string TreeNodeLabel { get; set; }

  public IAcpFeatureSection this[int id]
  {
    get
    {
      return this.sections.ContainsKey(id) ? (IAcpFeatureSection) this.sections[id] : (IAcpFeatureSection) null;
    }
  }

  public void AddFeatureSection(IAcpFeatureSection section)
  {
    section.Parent = (IAcpFeatureNode) this;
    foreach (IAcpField fields in section.FieldsCollection)
    {
      this.fieldsAll.Add(fields);
      if (fields is AcpRecRefField)
        this.recRefFields.Add((AcpRecRefField) fields);
      if (fields is AcpKeyField && this.KeyField == null)
        this.KeyField = (AcpKeyField) fields;
    }
    if (!this.HasEmbeddedRecset)
      this.HasEmbeddedRecset = section.HasEmbeddedRecset;
    this.sections[section.FeatureSectionId] = (FeatureSection) section;
    if (section.DataTransferOrder <= 0)
      return;
    this.sectionsByOrder.Add(section.DataTransferOrder, (FeatureSection) section);
  }

  public IEnumerable<IAcpFeatureSection> FeatureSectionsCollection
  {
    get
    {
      foreach (IAcpFeatureSection featureSections in this.sections.Values)
        yield return featureSections;
    }
  }

  public IEnumerable<IAcpFeatureSection> FeatureSectionsCollectionByOrder
  {
    get
    {
      foreach (IAcpFeatureSection acpFeatureSection in this.sectionsByOrder.Values)
        yield return acpFeatureSection;
    }
  }

  public void PopulateReferences()
  {
    foreach (FeatureSection featureSection in this.sections.Values)
    {
      featureSection.PopulateReferences();
      if (featureSection.HasEmbeddedRecset)
        ((Recordset) featureSection.EmbeddedRecset).PopulateReferences();
    }
  }

  public void DropReferences()
  {
    foreach (FeatureSection featureSection in this.sections.Values)
      featureSection.DropReferences();
  }

  public virtual void CalculateValidity()
  {
    foreach (AcpFieldBase acpFieldBase in this.fieldsWithValidity)
      acpFieldBase.CalculateValidity();
    foreach (IAcpConstraints embeddedRecordset in this.EmbeddedRecordsets)
      embeddedRecordset.CalculateValidity();
  }

  public virtual void CalculateApplicability()
  {
    foreach (IAcpConstraints acpConstraints in this.fieldsWithApplicability)
      acpConstraints.CalculateApplicability();
    foreach (IAcpConstraints embeddedRecordset in this.EmbeddedRecordsets)
      embeddedRecordset.CalculateApplicability();
  }

  public void CalculateVisibility()
  {
    foreach (IAcpConstraints acpConstraints in this.fieldsWithVisibility)
      acpConstraints.CalculateVisibility();
    foreach (IAcpConstraints embeddedRecordset in this.EmbeddedRecordsets)
      embeddedRecordset.CalculateVisibility();
  }

  public void CalculateEditability()
  {
    foreach (IAcpConstraints acpConstraints in this.fieldsWithEditability)
      acpConstraints.CalculateEditability();
    foreach (IAcpConstraints embeddedRecordset in this.EmbeddedRecordsets)
      embeddedRecordset.CalculateEditability();
  }

  public void CalculateVisibility(bool allFields)
  {
    foreach (IAcpConstraints featureSections in this.FeatureSectionsCollection)
      featureSections.CalculateVisibility(allFields);
  }

  public void CalculateEditability(bool allFields)
  {
    foreach (IAcpConstraints featureSections in this.FeatureSectionsCollection)
      featureSections.CalculateEditability(allFields);
  }

  private void OnSectionDifferenceCountChanged(object sender, DifferenceCountChangedEventArgs e)
  {
    if (e.Action == DifferenceCountChangedAction.Increment && this.DiffCount.Value == 1)
    {
      ((Recordset) this.Parent).DiffCount.Increment(this.FeatureName);
      this.FirePropertyChanged("_HasDiffs");
    }
    else
    {
      if (e.Action != DifferenceCountChangedAction.Decrement || this.DiffCount.Value != 0)
        return;
      ((Recordset) this.Parent).DiffCount.Decrement(this.FeatureName);
      this.FirePropertyChanged("_HasDiffs");
    }
  }

  internal DifferenceCount DiffCount => this.diffCount;

  public bool _HasDiffs => this.DiffCount.Value > 0;

  public void ClearHasDiffs()
  {
    foreach (IAcpFeatureSection featureSections in this.FeatureSectionsCollection)
      featureSections.ClearHasDiffs();
    this.DiffCount.Reset(this.FeatureName);
  }

  public bool HasVisibleObjects
  {
    get
    {
      foreach (IAcpFeatureSection featureSections in this.FeatureSectionsCollection)
      {
        if (featureSections.HasVisibleObjects)
          return true;
      }
      return false;
    }
  }

  public virtual void CallConstraints()
  {
    this.CalculateVisibility(true);
    this.CalculateEditability();
    this.CalculateApplicability();
    this.CalculateValidity();
  }

  public IEnumerable<IAcpField> Search(string token) => this.SearchConditionally(token, false);

  public IEnumerable<IAcpField> SearchAll(string token) => this.SearchConditionally(token, true);

  private IEnumerable<IAcpField> SearchConditionally(string token, bool searchHiddenStatic)
  {
    foreach (IAcpFeatureSection featureSections in this.FeatureSectionsCollection)
    {
      if (searchHiddenStatic)
      {
        foreach (IAcpField acpField in featureSections.SearchAll(token))
          yield return acpField;
      }
      else
      {
        foreach (IAcpField acpField in featureSections.Search(token))
          yield return acpField;
      }
    }
  }

  public string UIName
  {
    get => this.uiName == null ? this.FeatureName : this.uiName;
    set => this.uiName = value;
  }

  public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
  {
    info.AddValue("FeatureName", (object) this.FeatureName);
    info.AddValue("SectionCount", this.sections.Count);
    FeatureSection[] array = new FeatureSection[this.sections.Count];
    this.sections.Values.CopyTo(array, 0);
    for (int index = 0; index < this.sections.Count; ++index)
      info.AddValue("Section" + index.ToString(), (object) array[index], typeof (FeatureSection));
  }

  protected FeatureNode(SerializationInfo info, StreamingContext context)
    : this((Recordset) null)
  {
    this.FeatureName = info != null ? info.GetString(nameof (FeatureName)) : throw new ArgumentNullException(nameof (info));
    int int32 = info.GetInt32(nameof (SectionCount));
    for (int index = 0; index < int32; ++index)
    {
      try
      {
        this.AddFeatureSection((IAcpFeatureSection) info.GetValue("Section" + index.ToString(), typeof (FeatureSection)));
      }
      catch (InvalidCastException ex)
      {
      }
      catch (SerializationException ex)
      {
      }
    }
  }

  public void ResetToDefault()
  {
    foreach (IAcpCommon acpCommon in this.sections.Values)
      acpCommon.ResetToDefault();
  }

  public string Path(string delimiter)
  {
    if (this.Parent == null)
      return this.ReferenceKey;
    return !this.Parent.SingleInstance ? this.Parent.Path(delimiter) + delimiter + this.ReferenceKey : this.Parent.Path(delimiter);
  }

  public IEnumerable<IAcpField> AllFields
  {
    get
    {
      foreach (IAcpField allField in this.fieldsAll)
        yield return allField;
    }
  }

  public IEnumerable<IAcpRecordset> EmbeddedRecordsets
  {
    get
    {
      if (this.HasEmbeddedRecset)
      {
        foreach (FeatureSection featureSection in this.sections.Values)
        {
          if (featureSection.HasEmbeddedRecset)
            yield return featureSection.EmbeddedRecset;
        }
      }
    }
  }

  internal int FieldsCount => this.fieldsAll.Count;

  public IEnumerable<FeatureNode> ReferencingNodes
  {
    get
    {
      if (this.KeyField != null)
      {
        foreach (FeatureNode referencingNode in this.KeyField.ReferencingNodes)
          yield return referencingNode;
      }
    }
  }

  public int SectionCount => this.sections.Count;

  public void RepairRecRefs()
  {
    foreach (FeatureSection featureSection in this.sections.Values)
      featureSection.RepairRecRefs();
  }

  public int Position
  {
    get
    {
      if (this.Parent == null)
        return 0;
      int num = ((Recordset) this.Parent).IndexOf((IAcpFeatureNode) this);
      if (num < 0)
        num = ((Recordset) this.Parent).Count;
      return num + 1;
    }
    set
    {
      if (this.Parent == null || value == this.Position)
        return;
      if (value <= 0)
      {
        this.RaisePositionChanged();
      }
      else
      {
        int count = ((Recordset) this.Parent).Count;
        if (value > count)
        {
          this.RaisePositionChanged();
        }
        else
        {
          if (!UndoManager.MarkForUndo)
            return;
          int newIndex = value - 1;
          if (newIndex >= this.Parent.Count)
            newIndex = this.Parent.Count - 1;
          this.parent.MoveRecord(this.Position - 1, newIndex);
        }
      }
    }
  }

  private void FirePropertyChanged(string name)
  {
    if (this.PropertyChanged == null)
      return;
    this.PropertyChanged((object) this, new PropertyChangedEventArgs(name));
  }

  internal void RaisePositionChanged()
  {
    this.FirePropertyChanged("Position");
    this.OnPositionChanged();
  }

  protected virtual void OnPositionChanged() => this.InvokeRecRefValidities();

  internal void BareRaisePositionChanged() => this.FirePropertyChanged("Position");

  public IEnumerable<AcpRecRefField> RecRefFields
  {
    get
    {
      foreach (AcpRecRefField recRefField in this.recRefFields)
        yield return recRefField;
    }
  }

  public event PropertyChangedEventHandler PropertyChanged;

  public Permissions Permissions { get; set; }

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
        this.diffCount?.Dispose();
        this.KeyField?.Dispose();
      }
      this.disposedValue = true;
    }
    this.isDisposeInProgress = false;
  }

  private void DisposeRecords()
  {
    if (this.sections != null)
    {
      foreach (KeyValuePair<int, FeatureSection> section in this.sections)
        section.Value?.Dispose();
    }
    if (this.EmbeddedRecordsets == null)
      return;
    foreach (IAcpRecordset embeddedRecordset in this.EmbeddedRecordsets)
      embeddedRecordset?.Dispose();
  }

  public void Dispose()
  {
    this.Dispose(true);
    GC.SuppressFinalize((object) this);
  }
}
