// Decompiled with JetBrains decompiler
// Type: AcpBusinessLayer.FeatureSection
// Assembly: AcpBusinessLayer, Version=23.1.0.23, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 44CF2A76-4418-422B-9DDD-B27A71BAF20C
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpBusinessLayer.dll

using AcpCommonLib;
using AcpCommonLib.UndoRedo;
using AcpCommonResources;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.XPath;

#nullable disable
namespace AcpBusinessLayer;

[Serializable]
public abstract class FeatureSection : 
  IAcpFeatureSection,
  IAcpConstraints,
  IAcpCommon,
  IDisposable,
  ISerializable,
  INotifyPropertyChanged,
  INotifyPropertyChanging
{
  private Dictionary<string, AcpFieldBase> fieldsByUIName;
  private Dictionary<string, AcpFieldBase> fieldsByName;
  private SortedDictionary<int, AcpFieldBase> sortedFields;
  private List<AcpFieldBase> fieldsBlocked;
  private Recordset embeddedRecset;
  private string uiName;
  private DifferenceCount diffCount;
  internal static Dictionary<Guid, IAcpFeatureSection> InitializedSections = new Dictionary<Guid, IAcpFeatureSection>();
  private int dataXferOrder;
  private bool disposedValue;
  private bool isDisposeInProgress;

  public abstract void PopulateReferences();

  public abstract void DropReferences();

  public abstract void SetupDependencies();

  public abstract void SetConstraints();

  public abstract void Init(List<string> producerFields);

  public abstract void Init();

  public virtual void UpdateKey()
  {
  }

  public virtual bool CanFill(IAcpField myField) => true;

  protected int Id { get; set; }

  internal bool HasListItemsToSerialize { get; set; }

  internal void RegisterForDataTransfer(AcpFieldBase field, int order)
  {
    if (this.sortedFields == null)
      this.sortedFields = new SortedDictionary<int, AcpFieldBase>();
    if (this.fieldsBlocked == null)
      this.fieldsBlocked = new List<AcpFieldBase>();
    if (order > 0)
    {
      this.sortedFields.Add(order, field);
    }
    else
    {
      if (this.fieldsBlocked.Contains(field))
        return;
      this.fieldsBlocked.Add(field);
    }
  }

  protected FeatureSection()
    : this((FeatureNode) null)
  {
  }

  protected FeatureSection(FeatureNode parent)
  {
    this.Parent = (IAcpFeatureNode) parent;
    this.fieldsByUIName = new Dictionary<string, AcpFieldBase>();
    this.fieldsByName = new Dictionary<string, AcpFieldBase>();
    this.CreateDifferenceCount();
  }

  private void CreateDifferenceCount()
  {
    this.diffCount = new DifferenceCount();
    this.diffCount.CountChanged += new DifferenceCountChangedEventHandler(this.OnFieldDifferenceCountChanged);
  }

  public void FirePropertyChanged(string name)
  {
    if (this.PropertyChanged == null)
      return;
    this.PropertyChanged((object) this, new PropertyChangedEventArgs(name));
  }

  internal void FirePropertyChanging(string name)
  {
    if (this.PropertyChanging == null)
      return;
    this.PropertyChanging((object) this, new PropertyChangingEventArgs(name));
  }

  internal void InvokeRecRefValidities() => ((FeatureNode) this.Parent).InvokeRecRefValidities();

  internal bool AddToXml(XmlNode node, XmlFileType fileType)
  {
    XmlElement element1 = node.OwnerDocument.CreateElement(this.ParentRecset.IsEmbeddedRecset ? "EmbeddedSection" : "Section");
    element1.SetAttribute("Name", this.UIName);
    element1.SetAttribute("id", this.Id.ToString((IFormatProvider) CultureInfo.InvariantCulture));
    if (this.HasEmbeddedRecset && !this.EmbeddedRecset.HiddenStatic && (this.EmbeddedRecset.HasVisibleObjects || this.embeddedRecset.Count == 0))
    {
      element1.SetAttribute("Embedded", "True");
      this.EmbeddedRecset.AddToXml((XmlNode) element1, fileType);
    }
    if (fileType == XmlFileType.CustomView)
    {
      foreach (AcpFieldBase fields in this.FieldsCollection)
      {
        if (!fields.HiddenStatic)
        {
          XmlElement element2 = node.OwnerDocument.CreateElement("Field");
          element2.SetAttribute("Name", fields.UIName);
          element2.InnerText = fields.CustomViewVisibility.ToString();
          element1.AppendChild((XmlNode) element2);
        }
      }
    }
    else if (this.sortedFields != null)
    {
      foreach (AcpFieldBase acpFieldBase in this.sortedFields.Values)
      {
        if (!acpFieldBase.HiddenStatic)
        {
          XmlElement element3 = node.OwnerDocument.CreateElement("Field");
          element3.SetAttribute("Name", acpFieldBase.UIName);
          if (this.HasListItemsToSerialize)
          {
            if (acpFieldBase is AcpListField acpListField && acpListField.SerializeItems)
              acpListField.BuildItemsXml(element3);
            else
              element3.InnerText = acpFieldBase.ToString();
          }
          else
            element3.InnerText = acpFieldBase.ToString();
          element1.AppendChild((XmlNode) element3);
        }
      }
    }
    node.AppendChild((XmlNode) element1);
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
    SortedDictionary<int, string> sortedDictionary = new SortedDictionary<int, string>();
    List<string> stringList1 = new List<string>();
    foreach (XmlNode childNode in node.ChildNodes)
    {
      XmlAttribute attribute = childNode.Attributes["Name"];
      if (attribute != null)
      {
        try
        {
          AcpFieldBase acpFieldBase1 = (AcpFieldBase) this[attribute.Value];
          if (acpFieldBase1 == null)
          {
            foreach (string key in AppInfoManager.GetInternalNamesByUIName(attribute.Value))
            {
              AcpFieldBase acpFieldBase2 = this.fieldsByName[key];
              if (acpFieldBase2 != null)
              {
                acpFieldBase1 = acpFieldBase2;
                break;
              }
            }
          }
          if (acpFieldBase1 != null)
          {
            if (acpFieldBase1.DataTransferOrder > 0)
              sortedDictionary.Add(acpFieldBase1.DataTransferOrder, attribute.Value);
            else if (!stringList1.Contains(attribute.Value))
              stringList1.Add(attribute.Value);
          }
        }
        catch (ArgumentException ex)
        {
        }
        catch (KeyNotFoundException ex)
        {
        }
      }
    }
    List<string> stringList2 = new List<string>();
    foreach (KeyValuePair<int, string> keyValuePair in sortedDictionary)
      stringList2.Add(keyValuePair.Value);
    foreach (string str in stringList1)
      stringList2.Add(str);
    foreach (string strA in stringList2)
    {
      IEnumerator enumerator = node.ChildNodes.GetEnumerator();
      try
      {
        while (enumerator.MoveNext())
        {
          XmlNode current = (XmlNode) enumerator.Current;
          XmlAttribute attribute = current.Attributes["Name"];
          if (attribute != null)
          {
            try
            {
              AcpFieldBase acpFieldBase3 = (AcpFieldBase) this[attribute.Value];
              if (acpFieldBase3 == null)
              {
                foreach (string key in AppInfoManager.GetInternalNamesByUIName(attribute.Value))
                {
                  AcpFieldBase acpFieldBase4 = this.fieldsByName[key];
                  if (acpFieldBase4 != null)
                  {
                    acpFieldBase3 = acpFieldBase4;
                    break;
                  }
                }
              }
              if (acpFieldBase3 != null)
              {
                if (string.Compare(strA, acpFieldBase3.UIName) != 0)
                {
                  if (!acpFieldBase3.LegacyUINames.Contains(strA))
                    continue;
                }
                if (acpFieldBase3.Name == "TrkSysGeneralAskRequired_A44909" && current?.FirstChild?.Value == bool.TrueString)
                  acpFieldBase3.Editable = true;
                switch (fileType)
                {
                  case XmlFileType.ImpExp:
                    if (acpFieldBase3.AllowsDataTransfer())
                    {
                      string newValue1 = current.FirstChild == null ? (string) null : current.FirstChild.Value;
                      bool flag = true;
                      if (acpFieldBase3 is AcpRecRefField key)
                      {
                        RecRefFieldsOfEmbedRecset.Remove((IAcpField) key);
                        if (key.SlaveRecRef && !key.Applicable && key.HasSiblingRecset)
                          flag = false;
                        else if (key.SlaveRecRef)
                          RecRefsToRepair[(IAcpField) acpFieldBase3] = newValue1;
                      }
                      if (flag)
                      {
                        UndoableTask task1 = (UndoableTask) null;
                        if (acpFieldBase3 is AcpListField acpListField)
                        {
                          if (acpListField.SerializeItems)
                            task1 = acpListField.CopyValuesFromXml(current);
                          else if (acpFieldBase3 is AcpSparseLOVField acpSparseLovField)
                          {
                            try
                            {
                              acpFieldBase3.UnsupportedValue = false;
                              int newValue2 = (int) acpSparseLovField.Converter.ConvertBack((object) newValue1, (Type) null, acpSparseLovField.ConverterParameterObject, (CultureInfo) null);
                              task1 = acpSparseLovField.GetModifyDataTask(newValue2);
                            }
                            catch
                            {
                              acpFieldBase3.UnsupportedValue = true;
                            }
                          }
                          else
                            task1 = acpFieldBase3.CreateSetValueTask(newValue1);
                        }
                        else
                          task1 = acpFieldBase3.CreateSetValueTask(newValue1);
                        try
                        {
                          task.AddTask(task1);
                          if (acpFieldBase3.UnsupportedValue)
                          {
                            acpFieldBase3.UnsupportedValue = false;
                            AppInfoManager.ImportExportFieldsReport.RegisterFieldInReport((IAcpField) acpFieldBase3, AcpResources.Value_Not_Copied_Unsupported_Value, false);
                            goto label_87;
                          }
                          goto label_87;
                        }
                        catch (Exception ex)
                        {
                          AppInfoManager.ImportExportFieldsReport.RegisterFieldInReport((IAcpField) acpFieldBase3, AcpResources.Value_Not_Copied_Unsupported_Value, false);
                          goto label_87;
                        }
                      }
                      else
                        goto label_87;
                    }
                    else
                    {
                      if (!acpFieldBase3.HiddenStatic)
                      {
                        if (acpFieldBase3.BlockDataTransfer)
                        {
                          AppInfoManager.ImportExportFieldsReport.RegisterFieldInReport((IAcpField) acpFieldBase3, AcpResources.Value_Not_Copied_Unsupported_DataTransfer, false);
                          goto label_87;
                        }
                        if (!acpFieldBase3.Editable)
                        {
                          AppInfoManager.ImportExportFieldsReport.RegisterFieldInReport((IAcpField) acpFieldBase3, AcpResources.Value_Not_Copied_Uneditable_Destination, false);
                          goto label_87;
                        }
                        goto label_87;
                      }
                      goto label_87;
                    }
                  case XmlFileType.CustomView:
                    acpFieldBase3.CustomViewVisibility = Convert.ToBoolean(current.FirstChild.Value, (IFormatProvider) CultureInfo.InvariantCulture);
                    goto label_87;
                  default:
                    goto label_87;
                }
              }
              else if (fileType == XmlFileType.ImpExp)
              {
                if (current.Name != "EmbeddedRecset")
                  Utility.LogMissingXmlNode((IXPathNavigable) current);
              }
            }
            catch (KeyNotFoundException ex)
            {
            }
          }
        }
        continue;
      }
      finally
      {
        if (enumerator is IDisposable disposable)
          disposable.Dispose();
      }
label_87:;
    }
    if (this.HasEmbeddedRecset)
    {
      XmlAttribute attribute = node.Attributes["Embedded"];
      Dictionary<string, List<IAcpField>> ConsumerNodes = new Dictionary<string, List<IAcpField>>();
      List<string> xmlEmbedRecsetFieldNameList = new List<string>();
      if (attribute != null)
      {
        if (this.EmbeddedRecset != null)
        {
          if (!this.EmbeddedRecset.HiddenStatic)
          {
            if (fileType != XmlFileType.CustomView && !importCopyOper)
            {
              FeatureNode featureNode1 = (FeatureNode) this.EmbeddedRecset[0];
              if (featureNode1 != null && this.EmbeddedRecset.Count > 0 && featureNode1.KeyField != null && !featureNode1.KeyField.BlockDataTransfer && featureNode1.KeyField.Editable && this.EmbeddedRecset.Min != this.EmbeddedRecset.Max)
              {
                foreach (FeatureNode featureNode2 in (Collection<FeatureNode>) this.EmbeddedRecset)
                {
                  if (featureNode2.KeyField.ReferencingFields != null)
                  {
                    foreach (AcpRecRefField referencingField in featureNode2.KeyField.ReferencingFields)
                      RecRefFieldsOfEmbedRecset[(IAcpField) referencingField] = referencingField.UIValue;
                  }
                }
                this.GetEmbedRecsetFieldsListFromXML(node.FirstChild, xmlEmbedRecsetFieldNameList);
                ((Recordset) this.EmbeddedRecset).FindNewFieldsInEmbeddedRecset_ImpExp(xmlEmbedRecsetFieldNameList, ConsumerNodes);
                this.EmbeddedRecset.ClearRecordset(this.EmbeddedRecset, task);
              }
              else if (featureNode1 != null && this.EmbeddedRecset.Count > 0 && featureNode1.KeyField == null && this.EmbeddedRecset.Min != this.EmbeddedRecset.Max)
              {
                this.GetEmbedRecsetFieldsListFromXML(node.FirstChild, xmlEmbedRecsetFieldNameList);
                ((Recordset) this.EmbeddedRecset).FindNewFieldsInEmbeddedRecset_ImpExp(xmlEmbedRecsetFieldNameList, ConsumerNodes);
                this.EmbeddedRecset.ClearRecordset(this.EmbeddedRecset, task);
              }
            }
            ((Recordset) this.EmbeddedRecset).ReadFromXml(node.FirstChild, task, fileType, true, RecRefsToRepair, RecRefFieldsOfEmbedRecset);
            ((Recordset) this.EmbeddedRecset).UpdateNewFieldsInEmbeddedRecset_ImpExpDnD(task, ConsumerNodes);
          }
        }
        else if (fileType == XmlFileType.ImpExp)
          Utility.LogMissingXmlNode((IXPathNavigable) node);
      }
      xmlEmbedRecsetFieldNameList.Clear();
      ConsumerNodes.Clear();
    }
    return true;
  }

  private void GetEmbedRecsetFieldsListFromXML(
    XmlNode node,
    List<string> xmlEmbedRecsetFieldNameList)
  {
    XmlNode firstChild = node.FirstChild;
    if (firstChild == null)
      return;
    XmlAttribute attribute1 = firstChild.Attributes["id"];
    foreach (XmlNode childNode1 in firstChild.ChildNodes)
    {
      foreach (XmlNode childNode2 in childNode1.ChildNodes)
      {
        XmlAttribute attribute2 = childNode2.Attributes["Name"];
        if (attribute2 != null)
          xmlEmbedRecsetFieldNameList.Add(attribute2.Value);
      }
    }
  }

  internal IAcpField FieldFromPathHelper(string path, bool absolute, string delimiter)
  {
    IAcpField acpField = (IAcpField) null;
    string[] strArray = path.Split(new string[1]
    {
      delimiter
    }, 2, StringSplitOptions.None);
    if (strArray[0] == this.UIName)
    {
      acpField = this[strArray[1]];
      if (acpField == null)
      {
        foreach (IAcpFeatureSection featureSections in this.Parent.FeatureSectionsCollection)
        {
          bool flag = false;
          foreach (IAcpField fields in featureSections.FieldsCollection)
          {
            if (fields.NewUIName == strArray[1])
            {
              acpField = fields;
              flag = true;
              break;
            }
          }
          if (flag)
            break;
        }
      }
      if (acpField == null && this.HasEmbeddedRecset)
        acpField = this.embeddedRecset.FieldFromPathHelper(strArray[1], absolute, delimiter);
    }
    return acpField;
  }

  public IAcpFeatureNode Parent { get; set; }

  public IAcpRecordset ParentRecset
  {
    get => this.Parent != null ? this.Parent.Parent : (IAcpRecordset) null;
  }

  public int FeatureSectionId => this.Id;

  public string FeatureSectionName { get; set; }

  internal IAcpField this[string name, bool isName]
  {
    get
    {
      if (!isName)
        return this[name];
      return this.fieldsByName.ContainsKey(name) ? (IAcpField) this.fieldsByName[name] : (IAcpField) null;
    }
    set
    {
      if (isName)
      {
        AcpFieldBase acpFieldBase = (AcpFieldBase) value;
        this.fieldsByName[name] = acpFieldBase;
      }
      else
        this[name] = value;
    }
  }

  public IAcpField this[string uiName]
  {
    get
    {
      return this.fieldsByUIName.ContainsKey(uiName) ? (IAcpField) this.fieldsByUIName[uiName] : (IAcpField) null;
    }
    set
    {
      AcpFieldBase acpFieldBase = (AcpFieldBase) value;
      Guid guid = this.GetType().GUID;
      if (FeatureSection.InitializedSections.ContainsKey(guid))
      {
        IAcpFeatureSection initializedSection = FeatureSection.InitializedSections[guid];
        if (initializedSection == this)
          acpFieldBase.CreateFieldData(uiName);
        else
          acpFieldBase.FieldData = ((AcpFieldBase) initializedSection[uiName]).FieldData;
      }
      else
      {
        FeatureSection.InitializedSections[guid] = (IAcpFeatureSection) this;
        acpFieldBase.CreateFieldData(uiName);
      }
      this.fieldsByUIName[uiName] = acpFieldBase;
    }
  }

  public IEnumerable<IAcpField> FieldsCollection
  {
    get
    {
      foreach (IAcpField fields in this.fieldsByUIName.Values)
        yield return fields;
    }
  }

  public IEnumerable<IAcpField> FieldsCollectionByOrder
  {
    get
    {
      if (this.sortedFields != null || this.fieldsBlocked != null)
      {
        foreach (IAcpField acpField in this.sortedFields.Values)
          yield return acpField;
        foreach (IAcpField acpField in this.fieldsBlocked)
          yield return acpField;
      }
    }
  }

  public int FieldsCount => this.fieldsByUIName.Count;

  public bool HasEmbeddedRecset => this.EmbeddedRecset != null;

  public IAcpRecordset EmbeddedRecset
  {
    get => (IAcpRecordset) this.embeddedRecset;
    set
    {
      this.embeddedRecset = (Recordset) value;
      if (this.embeddedRecset == null)
        return;
      this.embeddedRecset.ParentSection = (IAcpFeatureSection) this;
      this.embeddedRecset.IsEmbeddedRecset = true;
    }
  }

  internal void CalculateValidityWithoutDependencies()
  {
    foreach (AcpFieldBase acpFieldBase in this.fieldsByUIName.Values)
    {
      if (acpFieldBase.ForceValid)
        acpFieldBase.ValidityHelper();
    }
    if (!this.HasEmbeddedRecset || this.EmbeddedRecset.Count <= 0)
      return;
    foreach (FeatureNode featureNode in (Collection<FeatureNode>) this.EmbeddedRecset)
      featureNode.CalculateValidityWithoutDependencies();
  }

  public IEnumerable<IAcpField> Search(string token) => this.SearchConditionally(token, false);

  public IEnumerable<IAcpField> SearchAll(string token) => this.SearchConditionally(token, true);

  private IEnumerable<IAcpField> SearchConditionally(string token, bool searchHiddenStatic)
  {
    if (this.HasEmbeddedRecset)
    {
      foreach (IAcpField acpField in this.EmbeddedRecset.Search(token))
        yield return acpField;
    }
    foreach (AcpFieldBase acpFieldBase in this.fieldsByUIName.Values)
    {
      AcpFieldBase field = acpFieldBase;
      if (searchHiddenStatic || !field.HiddenStatic)
      {
        bool isNameFound = false;
        if (!string.IsNullOrEmpty(field.NewUIName) && field.NewUIName.ToLower().Contains(token.ToLower()))
        {
          isNameFound = true;
          yield return (IAcpField) field;
        }
        if (!isNameFound && field.UIName.ToLower().Contains(token.ToLower()))
        {
          isNameFound = true;
          yield return (IAcpField) field;
        }
        if (!isNameFound)
        {
          bool flag = false;
          foreach (string legacyUiName in (IEnumerable<string>) field.LegacyUINames)
          {
            if (legacyUiName.ToLower().Contains(token.ToLower()))
            {
              flag = true;
              break;
            }
          }
          if (flag)
            yield return (IAcpField) field;
        }
        if (Document.SearchMode == SearchMode.UINamesAndUIValues)
        {
          if (field.ToString().ToLower().Contains(token.ToLower()))
            yield return (IAcpField) field;
          if (field is IAcpRangeField acpRangeField && acpRangeField.ShowHexValue && acpRangeField.HexUIValue.ToLower().Contains(token.ToLower()))
            yield return (IAcpField) field;
          if (field is AcpListField acpListField && acpListField.SerializeItems)
          {
            bool flag = false;
            foreach (ListItem listItem in (Collection<ListItem>) acpListField.Items)
            {
              if (listItem.ItemName.ToLower().Contains(token.ToLower()))
              {
                flag = true;
                break;
              }
            }
            if (flag)
              yield return (IAcpField) field;
          }
        }
        field = (AcpFieldBase) null;
      }
    }
  }

  public string UIName
  {
    get => this.uiName == null ? this.FeatureSectionName : this.uiName;
    set => this.uiName = value;
  }

  public string Path(string delimiter)
  {
    return this.Parent != null ? this.Parent.Path(delimiter) + delimiter + this.UIName : this.UIName;
  }

  public IAcpField CurrentField { get; internal set; }

  public void SetCurrentField(IAcpField fieldName) => this.CurrentField = fieldName;

  public void CallConstraints()
  {
    foreach (IAcpConstraints acpConstraints in this.fieldsByUIName.Values)
      acpConstraints.CallConstraints();
    if (!this.HasEmbeddedRecset)
      return;
    this.EmbeddedRecset.CallConstraints();
  }

  public void CalculateValidity()
  {
    foreach (IAcpConstraints acpConstraints in this.fieldsByUIName.Values)
      acpConstraints.CalculateValidity();
    if (!this.HasEmbeddedRecset)
      return;
    this.EmbeddedRecset.CalculateValidity();
  }

  public void CalculateApplicability()
  {
    foreach (IAcpConstraints acpConstraints in this.fieldsByUIName.Values)
      acpConstraints.CalculateApplicability();
    if (!this.HasEmbeddedRecset)
      return;
    this.EmbeddedRecset.CalculateApplicability();
  }

  public void CalculateVisibility()
  {
    foreach (IAcpConstraints acpConstraints in this.fieldsByUIName.Values)
      acpConstraints.CalculateVisibility();
    if (!this.HasEmbeddedRecset)
      return;
    this.EmbeddedRecset.CalculateVisibility();
  }

  public void CalculateEditability()
  {
    foreach (IAcpConstraints acpConstraints in this.fieldsByUIName.Values)
      acpConstraints.CalculateEditability();
    if (!this.HasEmbeddedRecset)
      return;
    this.EmbeddedRecset.CalculateEditability();
  }

  public void CalculateVisibility(bool allFields)
  {
    foreach (IAcpConstraints acpConstraints in this.fieldsByUIName.Values)
      acpConstraints.CalculateVisibility();
    if (!this.HasEmbeddedRecset)
      return;
    this.EmbeddedRecset.CalculateVisibility(allFields);
  }

  public void CalculateEditability(bool allFields)
  {
    foreach (IAcpConstraints acpConstraints in this.fieldsByUIName.Values)
      acpConstraints.CalculateEditability();
    if (!this.HasEmbeddedRecset)
      return;
    this.EmbeddedRecset.CalculateEditability(allFields);
  }

  private void OnFieldDifferenceCountChanged(object sender, DifferenceCountChangedEventArgs e)
  {
    this.FirePropertyChanged(e.Name + "_HasDiffs");
    if (e.Action == DifferenceCountChangedAction.Increment && this.DiffCount.Value == 1)
    {
      ((FeatureNode) this.Parent).DiffCount.Increment(this.FeatureSectionName);
      this.FirePropertyChanged("HasDiffs");
    }
    else
    {
      if (e.Action != DifferenceCountChangedAction.Decrement || this.DiffCount.Value != 0)
        return;
      ((FeatureNode) this.Parent).DiffCount.Decrement(this.FeatureSectionName);
      this.FirePropertyChanged("HasDiffs");
    }
  }

  internal DifferenceCount DiffCount => this.diffCount;

  public bool _HasDiffs => this.DiffCount.Value > 0;

  public void ClearHasDiffs()
  {
    foreach (IAcpField acpField in this.fieldsByUIName.Values)
      acpField._HasDiffs = false;
    if (this.HasEmbeddedRecset)
      this.EmbeddedRecset.ClearHasDiffs();
    this.DiffCount.Reset(this.FeatureSectionName);
  }

  public bool HasVisibleObjects
  {
    get
    {
      foreach (AcpFieldBase acpFieldBase in this.fieldsByUIName.Values)
      {
        if (!acpFieldBase.HiddenStatic)
          return true;
      }
      return this.HasEmbeddedRecset && this.EmbeddedRecset.HasVisibleObjects;
    }
  }

  public int DataTransferOrder
  {
    get => this.dataXferOrder;
    set => this.dataXferOrder = value;
  }

  public event PropertyChangedEventHandler PropertyChanged;

  public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
  {
    info.AddValue("FeatureSectionName", (object) this.FeatureSectionName);
    info.AddValue("UIName", (object) this.UIName);
    info.AddValue("EmbeddedRecset", (object) this.embeddedRecset);
    info.AddValue("HasListItemsToSerialize", this.HasListItemsToSerialize);
    if (this.HasListItemsToSerialize)
    {
      foreach (IAcpField fields in this.FieldsCollection)
      {
        if (fields is AcpSparseLOVField acpSparseLovField && acpSparseLovField.SerializeItems && acpSparseLovField.Items != null)
        {
          int count = acpSparseLovField.Items.Count;
          info.AddValue(acpSparseLovField.Name + "_Count", count);
          for (int index = 0; index < count; ++index)
          {
            string name = acpSparseLovField.Name + index.ToString();
            int num;
            try
            {
              num = (int) acpSparseLovField.Converter.ConvertBack((object) acpSparseLovField.Items[index].ItemName, (Type) null, acpSparseLovField.ConverterParameterObject, (CultureInfo) null);
            }
            catch
            {
              continue;
            }
            info.AddValue(name, num);
            info.AddValue(name + "_ItemVisibility", acpSparseLovField.Items[index].ItemVisibility);
          }
        }
      }
    }
    foreach (KeyValuePair<string, AcpFieldBase> keyValuePair in this.fieldsByName)
    {
      if (!AppInfoManager.DndOperation && keyValuePair.Value is AcpRecRefField)
      {
        ((AcpRecRefField) keyValuePair.Value).UpdateValue();
        info.AddValue(keyValuePair.Key, ((AcpField<int>) keyValuePair.Value).Value);
      }
      else if (keyValuePair.Value.UIInvalid)
        info.AddValue(keyValuePair.Key, (object) keyValuePair.Value.ToString());
      else if (keyValuePair.Value is AcpRecRefField)
      {
        if (((AcpRecRefField) keyValuePair.Value).IsExactPrepend)
        {
          info.AddValue(keyValuePair.Key + "_isExactPrepend", ((AcpRecRefField) keyValuePair.Value).IsExactPrepend);
          info.AddValue(keyValuePair.Key, (object) keyValuePair.Value.ValueString);
        }
        else
          info.AddValue(keyValuePair.Key, (object) keyValuePair.Value.ToString());
      }
      else
        info.AddValue(keyValuePair.Key, (object) keyValuePair.Value.ValueString);
      info.AddValue(keyValuePair.Key + "_flag", keyValuePair.Value.GetFlags());
    }
    if (!AppInfoManager.DndOperation)
      return;
    foreach (KeyValuePair<string, AcpFieldBase> keyValuePair in this.fieldsByName)
      info.AddValue(keyValuePair.Key + "_HiddenStatic", keyValuePair.Value.HiddenStatic);
    info.AddValue("FieldCount", this.FieldsCount);
    int num1 = 0;
    foreach (AcpFieldBase fields in this.FieldsCollection)
    {
      info.AddValue("FieldName" + num1.ToString(), (object) fields.Name);
      ++num1;
    }
  }

  protected FeatureSection(SerializationInfo info, StreamingContext context)
    : this()
  {
    bool flag = false;
    if (!string.IsNullOrEmpty(Document.CodePlugVersionNumber))
      flag = int.Parse(Document.CodePlugVersionNumber.Substring(1, 2)) >= AppInfoManager.LOCALIZED_VERSION_NUMBER;
    if (AppInfoManager.DndOperation && AppInfoManager.ProducerVersion >= AppInfoManager.LOCALIZED_VERSION_NUMBER)
      flag = true;
    this.FeatureSectionName = info != null ? info.GetString(nameof (FeatureSectionName)) : throw new ArgumentNullException(nameof (info));
    try
    {
      this.EmbeddedRecset = (IAcpRecordset) info.GetValue(nameof (EmbeddedRecset), typeof (Recordset));
    }
    catch (Exception ex)
    {
    }
    this.HasListItemsToSerialize = info.GetBoolean(nameof (HasListItemsToSerialize));
    if (AppInfoManager.DndOperation)
    {
      List<string> producerFields = (List<string>) null;
      try
      {
        int int32 = info.GetInt32("FieldCount");
        if (producerFields == null)
          producerFields = new List<string>();
        for (int index = 0; index < int32; ++index)
          producerFields.Add(info.GetString("FieldName" + index.ToString()));
        this.Init(producerFields);
        producerFields?.Clear();
      }
      catch (Exception ex)
      {
        this.Init();
      }
    }
    else
      this.Init();
    if (this.HasListItemsToSerialize)
    {
      foreach (IAcpField fields in this.FieldsCollection)
      {
        if (fields is AcpSparseLOVField sparseField && sparseField.SerializeItems && sparseField.Items != null)
        {
          sparseField.Items.Clear();
          try
          {
            if (flag)
            {
              if (AppInfoManager.DndOperation)
              {
                if (AppInfoManager.ProducerVersion < AppInfoManager.LOCALIZED_VERSION_NUMBER)
                  this.LoadSparseLOVFieldDataUIName(info, sparseField);
                else
                  this.LoadSparseLOVFieldDataName(info, sparseField);
              }
              else
                this.LoadSparseLOVFieldDataName(info, sparseField);
            }
            else
              this.LoadSparseLOVFieldDataUIName(info, sparseField);
          }
          catch (SerializationException ex)
          {
          }
          catch (FormatException ex)
          {
          }
        }
      }
    }
    if (flag)
    {
      if (AppInfoManager.DndOperation)
      {
        if (AppInfoManager.ProducerVersion < AppInfoManager.LOCALIZED_VERSION_NUMBER)
        {
          AppInfoManager.IsOldCodeplug = true;
          this.LoadFieldData(info, this.fieldsByUIName);
        }
        else
        {
          AppInfoManager.IsOldCodeplug = false;
          this.LoadFieldData(info, this.fieldsByName);
        }
      }
      else
      {
        AppInfoManager.IsOldCodeplug = false;
        this.LoadFieldData(info, this.fieldsByName);
      }
    }
    else
    {
      AppInfoManager.IsOldCodeplug = true;
      this.LoadFieldData(info, this.fieldsByUIName);
    }
  }

  private void LoadSparseLOVFieldDataName(SerializationInfo info, AcpSparseLOVField sparseField)
  {
    int int32 = info.GetInt32(sparseField.Name + "_Count");
    for (int index = 0; index < int32; ++index)
    {
      string name = sparseField.Name + index.ToString();
      sparseField.AddValue(info.GetInt32(name));
      try
      {
        sparseField[index].ItemVisibility = info.GetBoolean(name + "_ItemVisibility");
      }
      catch (SerializationException ex)
      {
      }
    }
  }

  private void LoadSparseLOVFieldDataUIName(SerializationInfo info, AcpSparseLOVField sparseField)
  {
    int int32 = info.GetInt32(sparseField.UIName + "_Count");
    for (int index = 0; index < int32; ++index)
    {
      string name = sparseField.UIName + index.ToString();
      sparseField.AddItemHelper(info.GetString(name));
      try
      {
        sparseField[index].ItemVisibility = info.GetBoolean(name + "_ItemVisibility");
      }
      catch (SerializationException ex)
      {
      }
    }
  }

  private void LoadFieldData(SerializationInfo info, Dictionary<string, AcpFieldBase> fields)
  {
    foreach (KeyValuePair<string, AcpFieldBase> field in fields)
    {
      try
      {
        int? flag = new int?(0);
        string name = field.Key;
        int? intValueNoThrow1 = info.GetIntValueNoThrow(name + "_flag");
        if (intValueNoThrow1.HasValue)
        {
          flag = intValueNoThrow1;
        }
        else
        {
          foreach (string legacyUiName in AppInfoManager.GetLegacyUINames(field.Value.Name))
          {
            name = legacyUiName;
            intValueNoThrow1 = info.GetIntValueNoThrow(name + "_flag");
            if (intValueNoThrow1.HasValue)
              flag = intValueNoThrow1;
          }
        }
        int? nullable1 = flag;
        int? nullable2 = nullable1.HasValue ? new int?(nullable1.GetValueOrDefault() & 32768 /*0x8000*/) : new int?();
        int num = 0;
        bool fieldUIInvalid = !(nullable2.GetValueOrDefault() == num & nullable2.HasValue);
        bool? nullable3 = new bool?(false);
        if (field.Value is AcpRecRefField)
        {
          try
          {
            bool? boolValueNoThrow = info.GetBoolValueNoThrow(name + "_isExactPrepend");
            nullable3 = !boolValueNoThrow.HasValue ? new bool?(false) : boolValueNoThrow;
          }
          catch (FormatException ex)
          {
            nullable3 = new bool?(false);
          }
        }
        if (!AppInfoManager.DndOperation && field.Value is AcpRecRefField)
        {
          int? intValueNoThrow2 = info.GetIntValueNoThrow(name);
          if (intValueNoThrow2.HasValue)
          {
            ((AcpField<int>) field.Value).DefaultValue = intValueNoThrow2.Value;
            ((AcpField<int>) field.Value).ResetToDefaultNoConstraints();
            this.AssignValues(field.Value, flag, fieldUIInvalid);
          }
        }
        else
        {
          if (!fieldUIInvalid && !AppInfoManager.IsOldCodeplug)
          {
            if (field.Value is AcpRecRefField)
            {
              bool? nullable4 = nullable3;
              if ((nullable4.HasValue ? new bool?(!nullable4.GetValueOrDefault()) : new bool?()).Value)
                goto label_22;
            }
            string stringValueNoThrow = info.GetStringValueNoThrow(name);
            if (stringValueNoThrow != null)
            {
              field.Value.ParseValueHelper(stringValueNoThrow);
              this.AssignValues(field.Value, flag, fieldUIInvalid);
              continue;
            }
            continue;
          }
label_22:
          string stringValueNoThrow1 = info.GetStringValueNoThrow(name);
          if (stringValueNoThrow1 != null)
          {
            field.Value.ParseValueFrom(stringValueNoThrow1);
            this.AssignValues(field.Value, flag, fieldUIInvalid);
          }
        }
      }
      catch (FormatException ex)
      {
      }
    }
    if (!AppInfoManager.DndOperation)
      return;
    foreach (KeyValuePair<string, AcpFieldBase> field in fields)
    {
      try
      {
        field.Value.HiddenStatic = info.GetBoolean(field.Key + "_HiddenStatic");
      }
      catch (SerializationException ex1)
      {
        field.Value.HiddenStatic = true;
        foreach (string legacyUiName in AppInfoManager.GetLegacyUINames(field.Value.Name))
        {
          try
          {
            field.Value.HiddenStatic = info.GetBoolean(legacyUiName + "_HiddenStatic");
            break;
          }
          catch (SerializationException ex2)
          {
          }
        }
      }
      catch (FormatException ex)
      {
      }
    }
  }

  private void AssignValues(AcpFieldBase acpFieldBaseValue, int? flag, bool fieldUIInvalid)
  {
    AcpFieldBase acpFieldBase1 = acpFieldBaseValue;
    int? nullable1 = flag;
    int? nullable2 = nullable1.HasValue ? new int?(nullable1.GetValueOrDefault() & 8) : new int?();
    int num1 = 0;
    int num2 = !(nullable2.GetValueOrDefault() == num1 & nullable2.HasValue) ? 1 : 0;
    acpFieldBase1.Valid = num2 != 0;
    AcpFieldBase acpFieldBase2 = acpFieldBaseValue;
    nullable1 = flag;
    nullable2 = nullable1.HasValue ? new int?(nullable1.GetValueOrDefault() & 256 /*0x0100*/) : new int?();
    int num3 = 0;
    int num4 = !(nullable2.GetValueOrDefault() == num3 & nullable2.HasValue) ? 1 : 0;
    acpFieldBase2.ForceValid = num4 != 0;
    acpFieldBaseValue.UIInvalid = fieldUIInvalid;
    AcpFieldBase acpFieldBase3 = acpFieldBaseValue;
    nullable1 = flag;
    nullable2 = nullable1.HasValue ? new int?(nullable1.GetValueOrDefault() & 16 /*0x10*/) : new int?();
    int num5 = 0;
    int num6 = !(nullable2.GetValueOrDefault() == num5 & nullable2.HasValue) ? 1 : 0;
    acpFieldBase3.Applicable = num6 != 0;
  }

  public void ResetToDefault()
  {
    foreach (IAcpCommon acpCommon in this.fieldsByUIName.Values)
      acpCommon.ResetToDefault();
  }

  public void RepairRecRefs()
  {
    foreach (AcpFieldBase acpFieldBase in this.fieldsByUIName.Values)
    {
      if (acpFieldBase is AcpRecRefField acpRecRefField)
        acpRecRefField.ResetToDefaultNoConstraints();
    }
    this.PopulateReferences();
    if (!this.HasEmbeddedRecset)
      return;
    ((Recordset) this.EmbeddedRecset).RepairRecRefs();
  }

  public event PropertyChangingEventHandler PropertyChanging;

  protected virtual void Dispose(bool disposing)
  {
    if (this.isDisposeInProgress)
      return;
    if (!this.disposedValue)
    {
      if (disposing)
      {
        this.isDisposeInProgress = true;
        this.CurrentField?.Dispose();
        this.diffCount?.Dispose();
        this.DisposeRecords();
      }
      this.disposedValue = true;
    }
    this.isDisposeInProgress = false;
  }

  private void DisposeRecords()
  {
    if (this.fieldsByName == null)
      return;
    foreach (KeyValuePair<string, AcpFieldBase> keyValuePair in this.fieldsByName)
      keyValuePair.Value?.Dispose();
  }

  public void Dispose()
  {
    this.Dispose(true);
    GC.SuppressFinalize((object) this);
  }
}
