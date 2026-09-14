// Decompiled with JetBrains decompiler
// Type: AcpASKLib.AccessRecord
// Assembly: AcpASKLib, Version=23.1.0.5, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: D65BC533-E9D0-49A5-8218-5CB2B5C70E2D
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpASKLib.dll

using AcpCommonResources;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Xml;

#nullable disable
namespace AcpASKLib;

[Serializable]
public class AccessRecord : INotifyPropertyChanged
{
  private AccessRecordSetX<AccessNode> accessNodes;
  private int m_id;
  private int primaryKey;
  private string m_name;
  private FeatureCategoryType m_recType;
  private byte[] m_FieldCodeArr;
  private bool m_bOTAPState;
  private bool m_bInUseFlag;
  private Dictionary<ushort, FieldValueRangeRecSet> m_ranges;
  private FeatureCategoryRadioType m_radioType;

  internal AccessRecord(
    string name,
    int pk,
    FeatureCategoryType recType,
    byte[] fieldCode,
    Dictionary<ushort, FieldValueRangeRecSet> ranges,
    FeatureCategoryRadioType radioType,
    bool bOTAP)
  {
    this.accessNodes = new AccessRecordSetX<AccessNode>(AcpResources.Codeplug_Field);
    this.m_ranges = new Dictionary<ushort, FieldValueRangeRecSet>();
    this.primaryKey = pk;
    this.m_name = name;
    this.m_recType = recType;
    this.m_radioType = radioType;
    this.m_bOTAPState = bOTAP;
    this.m_bInUseFlag = false;
    this.m_FieldCodeArr = new byte[24];
    this.ZeroFieldCodeArray();
    if (fieldCode != null)
    {
      Array.Copy((Array) fieldCode, 0, (Array) this.m_FieldCodeArr, 0, fieldCode.Length);
      this.m_bOTAPState = this.GetFieldCodeValue(193);
    }
    if (ranges != null)
    {
      foreach (KeyValuePair<ushort, FieldValueRangeRecSet> range in ranges)
        this.m_ranges.Add(range.Key, range.Value);
    }
    this.Init();
  }

  public AccessRecord(string name, int pk, FeatureCategoryType recType)
    : this(name, pk, recType, (byte[]) null, (Dictionary<ushort, FieldValueRangeRecSet>) null, FeatureCategoryRadioType.XTSXTLRadios, false)
  {
  }

  public AccessRecord(string name, FeatureCategoryType recType)
    : this(name, 0, recType, (byte[]) null, (Dictionary<ushort, FieldValueRangeRecSet>) null, FeatureCategoryRadioType.XTSXTLRadios, false)
  {
  }

  public AccessRecord(
    int pk,
    FeatureCategoryType recType,
    byte[] fieldCode,
    Dictionary<ushort, FieldValueRangeRecSet> ranges,
    bool bOTAP)
    : this((string) null, pk, recType, fieldCode, ranges, FeatureCategoryRadioType.XTSXTLRadios, bOTAP)
  {
  }

  public AccessRecord(AccessRecord copy)
  {
    this.accessNodes = new AccessRecordSetX<AccessNode>(AcpResources.Codeplug_Field);
    this.m_ranges = new Dictionary<ushort, FieldValueRangeRecSet>();
    this.primaryKey = copy.primaryKey;
    this.m_id = copy.m_id;
    this.m_name = copy.m_name;
    this.m_bOTAPState = copy.m_bOTAPState;
    this.m_bInUseFlag = copy.m_bInUseFlag;
    this.m_recType = copy.m_recType;
    this.m_FieldCodeArr = new byte[24];
    Array.Copy((Array) copy.m_FieldCodeArr, 0, (Array) this.m_FieldCodeArr, 0, copy.m_FieldCodeArr.Length);
    foreach (KeyValuePair<ushort, FieldValueRangeRecSet> range in copy.m_ranges)
    {
      FieldValueRangeRecSet valueRangeRecSet = new FieldValueRangeRecSet(range.Value.OwnerID);
      foreach (AccessFieldValueRange accessFieldValueRange in (Collection<AccessFieldValueRange>) range.Value)
        valueRangeRecSet.Add(new AccessFieldValueRange()
        {
          FieldID = accessFieldValueRange.FieldID,
          Minimum = accessFieldValueRange.Minimum,
          Maximum = accessFieldValueRange.Maximum
        });
      this.m_ranges.Add(range.Key, valueRangeRecSet);
    }
    foreach (AccessNode accessNode in (Collection<AccessNode>) copy.AccessNodes)
      this.accessNodes.Add(this.CopyNodeAccess(accessNode));
  }

  private void Init()
  {
    foreach (FeatureCategory featureCategory in FeatureSchemaManager.FeatureCategories)
    {
      if (featureCategory.Type == this.m_recType && featureCategory.RadioType == this.m_radioType)
      {
        foreach (AccessNode feature in featureCategory.Features)
          this.accessNodes.Add(this.CreateNodeAccess(feature));
        foreach (AccessNode function in featureCategory.Functions)
          this.accessNodes.Add(this.CreateNodeAccess(function));
      }
    }
  }

  private AccessNode CreateNodeAccess(AccessNode nodeTemplate)
  {
    AccessNode nodeAccess = new AccessNode(nodeTemplate.Name, nodeTemplate.UIName, nodeTemplate.ID);
    foreach (AccessSection section in nodeTemplate.Sections)
    {
      AccessSection accessSection = new AccessSection(section.Name, section.UIName, section.ID);
      foreach (AccessElement accessElement1 in section.Items)
      {
        AccessElement accessElement2 = (AccessElement) null;
        switch (accessElement1)
        {
          case AccessRangeField _:
            accessElement2 = (AccessElement) new AccessRangeField(accessElement1.Name, accessElement1.UIName, accessElement1.ID, ((AccessField) accessElement1).MapID, accessElement1.ElemID, AccessLevelType.ReadOnly);
            if (this.m_ranges != null && this.m_ranges.ContainsKey((ushort) accessElement1.ID))
              ((AccessRangeField) accessElement2).Ranges = this.m_ranges[(ushort) accessElement1.ID];
            if (this.m_FieldCodeArr != null)
            {
              ((AccessField) accessElement2).AccessLevel = this.GetAclFromFieldCode((ushort) accessElement2.ID);
              break;
            }
            break;
          case AccessField _:
            accessElement2 = (AccessElement) new AccessField(accessElement1.Name, accessElement1.UIName, accessElement1.ID, ((AccessField) accessElement1).MapID, accessElement1.ElemID, AccessLevelType.ReadOnly);
            if (this.m_FieldCodeArr != null)
            {
              ((AccessField) accessElement2).AccessLevel = this.GetAclFromFieldCode((ushort) accessElement2.ID);
              break;
            }
            break;
          case AccessOperation _:
            accessElement2 = (AccessElement) new AccessOperation(accessElement1.Name, accessElement1.UIName, accessElement1.ID, accessElement1.ElemID, false);
            ((AccessOperation) accessElement2).AccessLevel = this.GetFieldCodeValue(accessElement2.ID);
            break;
        }
        if (accessElement2 != null)
          accessSection.Items.Add(accessElement2);
      }
      nodeAccess.Sections.Add(accessSection);
    }
    return nodeAccess;
  }

  private AccessNode CopyNodeAccess(AccessNode nodeAccCopy)
  {
    AccessNode accessNode = new AccessNode(nodeAccCopy.Name, nodeAccCopy.UIName, nodeAccCopy.ID);
    foreach (AccessSection section in nodeAccCopy.Sections)
    {
      AccessSection accessSection = new AccessSection(section.Name, section.UIName, section.ID);
      foreach (AccessElement accessElement1 in section.Items)
      {
        AccessElement accessElement2 = (AccessElement) null;
        switch (accessElement1)
        {
          case AccessRangeField _:
            AccessRangeField accessRangeField = (AccessRangeField) accessElement1;
            accessElement2 = (AccessElement) new AccessRangeField(accessRangeField.Name, accessRangeField.UIName, accessRangeField.ID, accessRangeField.MapID, accessRangeField.ElemID, accessRangeField.AccessLevel);
            using (IEnumerator<AccessFieldValueRange> enumerator = accessRangeField.Ranges.GetEnumerator())
            {
              while (enumerator.MoveNext())
              {
                AccessFieldValueRange current = enumerator.Current;
                AccessFieldValueRange accessFieldValueRange = new AccessFieldValueRange(current.FieldID, current.Minimum, current.Maximum);
                ((AccessRangeField) accessElement2).Ranges.Add(accessFieldValueRange);
              }
              break;
            }
          case AccessField _:
            AccessField accessField = (AccessField) accessElement1;
            accessElement2 = (AccessElement) new AccessField(accessField.Name, accessField.UIName, accessField.ID, accessField.MapID, accessField.ElemID, accessField.AccessLevel);
            break;
          case AccessOperation _:
            AccessOperation accessOperation = (AccessOperation) accessElement1;
            accessElement2 = (AccessElement) new AccessOperation(accessOperation.Name, accessOperation.UIName, accessOperation.ID, accessOperation.ElemID, accessOperation.AccessLevel);
            break;
        }
        accessSection.Items.Add(accessElement2);
      }
      accessNode.Sections.Add(accessSection);
    }
    return accessNode;
  }

  public void UpdateFieldCode(AccessNode nodeAccess)
  {
    foreach (AccessSection section in nodeAccess.Sections)
    {
      foreach (AccessElement accessElement in section.Items)
      {
        if (accessElement is AccessField)
        {
          AccessField accessField = (AccessField) accessElement;
          if (accessField.AccessLevel == AccessLevelType.Editable)
            this.SetFieldAccessLevel(accessField.ID);
        }
        else if (accessElement is AccessOperation)
        {
          AccessOperation accessOperation = (AccessOperation) accessElement;
          if (accessOperation.AccessLevel)
            this.SetFieldAccessLevel(accessOperation.ID);
        }
      }
    }
  }

  internal byte[] PackedData
  {
    get
    {
      ArrayList arrayList1 = new ArrayList();
      ArrayList arrayList2 = new ArrayList();
      if (this.primaryKey > 5)
      {
        this.ZeroFieldCodeArray();
        foreach (AccessNode accessNode in (Collection<AccessNode>) this.accessNodes)
          this.UpdateFieldCode(accessNode);
      }
      arrayList1.Add((object) (byte) this.primaryKey);
      arrayList1.Add((object) (byte) this.m_FieldCodeArr.Length);
      for (int index = 0; index < this.m_FieldCodeArr.Length; ++index)
        arrayList1.Add((object) this.m_FieldCodeArr[index]);
      arrayList1.Add((object) (byte) this.m_ranges.Count);
      byte checkSum1 = Global.CalculateCheckSum((byte[]) arrayList1.ToArray(typeof (byte)));
      arrayList1.Add((object) checkSum1);
      if (this.m_ranges.Count > 0)
      {
        ArrayList arrayList3 = new ArrayList();
        foreach (KeyValuePair<ushort, FieldValueRangeRecSet> range in this.m_ranges)
        {
          FieldValueRangeRecSet valueRangeRecSet = range.Value;
          if (valueRangeRecSet.Count > 0)
          {
            byte[] packedData = valueRangeRecSet.PackedData;
            if (packedData != null && packedData.Length != 0)
            {
              arrayList1.AddRange((ICollection) packedData);
              arrayList3.AddRange((ICollection) packedData);
            }
          }
        }
        byte checkSum2 = Global.CalculateCheckSum((byte[]) arrayList3.ToArray(typeof (byte)));
        arrayList1.Add((object) checkSum2);
      }
      return (byte[]) arrayList1.ToArray(typeof (byte));
    }
  }

  public void SetAccessLevel(AccessLevelType fldAccLvl, bool opAccLvl)
  {
    foreach (AccessNode accessNode in (Collection<AccessNode>) this.accessNodes)
    {
      this.SetFeatureAccessLevel(accessNode, fldAccLvl, opAccLvl);
      this.UpdateFieldCode(accessNode);
    }
  }

  private void SetFeatureAccessLevel(
    AccessNode nodeAccess,
    AccessLevelType fldAccLvl,
    bool opAccLvl)
  {
    foreach (AccessSection section in nodeAccess.Sections)
    {
      foreach (AccessElement accessElement in section.Items)
      {
        if (accessElement is AccessField)
          ((AccessField) accessElement).AccessLevel = fldAccLvl;
        else if (accessElement is AccessOperation)
          ((AccessOperation) accessElement).AccessLevel = opAccLvl;
      }
    }
  }

  public void UnPackFeatures()
  {
    foreach (AccessNode accessNode in (Collection<AccessNode>) this.accessNodes)
      this.UnPackNode(accessNode);
  }

  private void UnPackNode(AccessNode nodeAcc)
  {
    foreach (AccessSection section in nodeAcc.Sections)
    {
      foreach (AccessElement accessElement in section.Items)
      {
        if (accessElement is AccessField)
          ((AccessField) accessElement).AccessLevel = this.GetAclFromFieldCode((ushort) accessElement.ID);
        else if (accessElement is AccessOperation)
          ((AccessOperation) accessElement).AccessLevel = this.GetFieldCodeValue(accessElement.ID);
      }
    }
  }

  private void PackNode(AccessNode nodeAcc)
  {
    foreach (AccessSection section in nodeAcc.Sections)
    {
      foreach (AccessElement accessElement in section.Items)
      {
        if (accessElement is AccessField)
        {
          AccessField accessField = (AccessField) accessElement;
          if (accessField.AccessLevel == AccessLevelType.Editable)
            this.SetFieldAccessLevel(accessField.ID);
          if (accessElement is AccessRangeField && ((AccessRangeField) accessElement).Ranges.Count > 0)
            this.m_ranges[(ushort) accessElement.ID] = ((AccessRangeField) accessElement).Ranges;
        }
        else if (accessElement is AccessOperation)
        {
          AccessOperation accessOperation = (AccessOperation) accessElement;
          if (accessOperation.AccessLevel)
            this.SetFieldAccessLevel(accessOperation.ID);
        }
      }
    }
  }

  private void PackFeatures()
  {
    this.ZeroFieldCodeArray();
    foreach (AccessNode accessNode in (Collection<AccessNode>) this.accessNodes)
      this.PackNode(accessNode);
  }

  public override string ToString() => this.m_name;

  private bool GetFieldCodeValue(int id)
  {
    bool fieldCodeValue = true;
    if (id != 193)
    {
      if (id <= 192 /*0xC0*/)
      {
        int num = id - 1;
        fieldCodeValue = ((int) this.m_FieldCodeArr[num / 8] & 1 << num % 8) > 0;
      }
    }
    else
      fieldCodeValue = this.m_bOTAPState;
    return fieldCodeValue;
  }

  private AccessLevelType GetAclFromFieldCode(ushort id)
  {
    return !this.GetFieldCodeValue((int) id) ? AccessLevelType.ReadOnly : AccessLevelType.Editable;
  }

  public bool IsRangeValueValid(AccessElementIDType id, int value)
  {
    bool flag = false;
    if (this.m_ranges.ContainsKey((ushort) id))
    {
      foreach (AccessFieldValueRange accessFieldValueRange in (Collection<AccessFieldValueRange>) this.m_ranges[(ushort) id])
      {
        long num1 = (long) value;
        uint? nullable1 = accessFieldValueRange.Minimum;
        long? nullable2 = nullable1.HasValue ? new long?((long) nullable1.GetValueOrDefault()) : new long?();
        if (num1 >= nullable2.GetValueOrDefault() & nullable2.HasValue)
        {
          long num2 = (long) value;
          nullable1 = accessFieldValueRange.Maximum;
          nullable2 = nullable1.HasValue ? new long?((long) nullable1.GetValueOrDefault()) : new long?();
          long valueOrDefault = nullable2.GetValueOrDefault();
          if (num2 <= valueOrDefault & nullable2.HasValue)
          {
            flag = true;
            break;
          }
        }
      }
    }
    else
      flag = true;
    return flag;
  }

  public bool IsAccessElementEnabled(AccessElementIDType id) => this.GetFieldCodeValue((int) id);

  internal bool IsWriteProtected() => this.GetFieldCodeValue(76);

  public bool IsCloningEnabled() => this.GetFieldCodeValue(75);

  public KeyAccessLevelType GetKeyAccessLevelType()
  {
    KeyAccessLevelType keyAccessLevelType = KeyAccessLevelType.UNLM_ACC;
    for (int id = 1; id <= 80 /*0x50*/; ++id)
    {
      if (id != 76 && !this.GetFieldCodeValue(id))
      {
        keyAccessLevelType = KeyAccessLevelType.LIMITED_ACC;
        break;
      }
    }
    if (keyAccessLevelType != KeyAccessLevelType.LIMITED_ACC)
    {
      if (this.RangeCount != (ushort) 0)
        keyAccessLevelType = KeyAccessLevelType.LIMITED_ACC;
      else if (!this.GetFieldCodeValue(76))
        keyAccessLevelType = KeyAccessLevelType.UNLM_ACC_WITHOUT_WP;
    }
    return keyAccessLevelType;
  }

  private void ZeroFieldCodeArray()
  {
    for (int index = 0; index < 24; ++index)
      this.m_FieldCodeArr[index] = (byte) 0;
  }

  private void SetFieldAccessLevel(int id)
  {
    if (id == 193)
      return;
    int num = id - 1;
    this.m_FieldCodeArr[(int) (byte) (num / 8)] += (byte) (1U << (int) (byte) (num % 8));
  }

  internal string ToXMLString()
  {
    this.PackFeatures();
    string str1 = "" + "\t<Record>\n" + "\t\t<AccessName> " + this.m_name + " </AccessName>\n" + "\t\t<FieldCode> ";
    for (int index = 0; index < 24; ++index)
    {
      string str2 = $"{this.m_FieldCodeArr[23 - index]:x2}";
      str1 += str2;
    }
    string str3 = str1 + " </FieldCode>\n" + "\t\t<LimitedDataRecordNum> " + $"{this.Ranges.Count}" + " </LimitedDataRecordNum>\n" + "\t\t<OTAPStatus> ";
    string str4 = (!this.m_bOTAPState ? str3 + "false" : str3 + "true") + " </OTAPStatus>\n";
    if (this.RangeCount > (ushort) 0)
    {
      foreach (KeyValuePair<ushort, FieldValueRangeRecSet> range in this.m_ranges)
      {
        FieldValueRangeRecSet valueRangeRecSet = range.Value;
        str4 += valueRangeRecSet.ToXMLStr(2);
      }
    }
    return str4 + "\t</Record>\n";
  }

  public AccessRecord(XmlNode node)
  {
    this.accessNodes = new AccessRecordSetX<AccessNode>(AcpResources.Codeplug_Field);
    this.m_ranges = new Dictionary<ushort, FieldValueRangeRecSet>();
    this.m_FieldCodeArr = new byte[24];
    this.ZeroFieldCodeArray();
    this.m_id = -1;
    this.m_recType = FeatureCategoryType.TRUNKING;
    this.m_bInUseFlag = false;
    for (XmlNode node1 = node.FirstChild; node1 != null; node1 = node1.NextSibling)
    {
      string name = node1.Name;
      string str1 = node1.InnerText.Trim();
      if ("AccessName" == name)
      {
        if (string.IsNullOrEmpty(str1))
          throw new Exception("Access Name cannot be empty");
        if (str1 == AcpResources.Enter_Access_Level)
          throw new Exception("Default Access Name not allowed.");
        if (str1.Length > Constants.MAX_LENGTH)
          throw new Exception("Access Name too long.");
        this.m_name = str1;
      }
      if ("OTAPStatus" == name)
      {
        switch (str1)
        {
          case "true":
            this.m_bOTAPState = true;
            break;
          case "false":
            this.m_bOTAPState = false;
            break;
          default:
            throw new Exception("Invalid OTAPStatus");
        }
      }
      if (nameof (FieldCode) == name)
      {
        string str2 = str1;
        for (int index = 0; index < str2.Length; ++index)
        {
          if (!Global.IsDigitOrHexChar(str2[index]))
            throw new Exception("Invalid FieldCode - wrong value");
        }
        if (str2.Length / 2 != 24 && str2.Length / 2 != 12)
          throw new Exception("Invalid FieldCode - out of range");
        bool flag = true;
        byte[] numArray = new byte[str2.Length / 2];
        byte[] sourceArray = new byte[24];
        for (int index = 0; index < str2.Length / 2; ++index)
        {
          int num1 = str2.Length / 2 - 1 - index;
          byte num2 = byte.Parse(str2.Substring(2 * num1, 2), NumberStyles.HexNumber);
          numArray[index] = num2;
          if (numArray[index] != (byte) 0)
            flag = false;
        }
        numArray.CopyTo((Array) sourceArray, 0);
        if (flag)
          throw new Exception("Invalid FieldCode - value not set");
        Array.Copy((Array) sourceArray, 0, (Array) this.m_FieldCodeArr, 0, 24);
      }
      if ("LimitedDataRecord" == name)
      {
        FieldValueRangeRecSet valueRangeRecSet = new FieldValueRangeRecSet(node1);
        this.m_ranges.Add(valueRangeRecSet.OwnerID, valueRangeRecSet);
      }
    }
    this.Init();
  }

  public AccessRecord(
    string name,
    string strFieldCode,
    bool bOTAP,
    Dictionary<ushort, FieldValueRangeRecSet> Range)
  {
    this.accessNodes = new AccessRecordSetX<AccessNode>(AcpResources.Codeplug_Field);
    this.m_ranges = new Dictionary<ushort, FieldValueRangeRecSet>();
    this.m_FieldCodeArr = new byte[24];
    this.ZeroFieldCodeArray();
    this.m_id = -1;
    this.m_recType = FeatureCategoryType.TRUNKING;
    this.m_bInUseFlag = false;
    this.m_name = name;
    this.m_bOTAPState = bOTAP;
    for (int index = 0; index < strFieldCode.Length; ++index)
    {
      if (!Global.IsDigitOrHexChar(strFieldCode[index]))
        throw new Exception("Invalid FieldCode - wrong value");
    }
    if (strFieldCode.Length / 2 != 24)
      throw new Exception("Invalid FieldCode - out of range");
    bool flag = true;
    byte[] sourceArray = new byte[24];
    for (int index = 0; index < 24; ++index)
      sourceArray[index] = (byte) 0;
    for (int index = 0; index < 24; ++index)
    {
      int num1 = 23 - index;
      byte num2 = byte.Parse(strFieldCode.Substring(2 * num1, 2), NumberStyles.HexNumber);
      sourceArray[index] = num2;
      if (sourceArray[index] != (byte) 0)
        flag = false;
    }
    if (flag)
      throw new Exception("Invalid FieldCode - value not set");
    Array.Copy((Array) sourceArray, 0, (Array) this.m_FieldCodeArr, 0, 24);
    if (Range != null)
    {
      foreach (KeyValuePair<ushort, FieldValueRangeRecSet> keyValuePair in Range)
        this.m_ranges.Add(keyValuePair.Key, keyValuePair.Value);
    }
    this.Init();
  }

  public AccessRecordSetX<AccessNode> AccessNodes => this.accessNodes;

  public int PrimaryKey
  {
    get => this.primaryKey;
    set => this.primaryKey = value;
  }

  public int ID
  {
    get => this.m_id;
    set => this.m_id = value;
  }

  public string Name
  {
    get => this.m_name;
    set
    {
      this.m_name = value;
      this.NotifyPropertyChanged(nameof (Name));
    }
  }

  internal FeatureCategoryType RecordType
  {
    get => this.m_recType;
    set => this.m_recType = value;
  }

  public byte[] FieldCode
  {
    get => this.m_FieldCodeArr;
    set
    {
      this.m_FieldCodeArr = value;
      this.UnPackFeatures();
    }
  }

  public bool OPTAPState
  {
    get => this.m_bOTAPState;
    set => this.m_bOTAPState = value;
  }

  internal bool InUse
  {
    get => this.m_bInUseFlag;
    set => this.m_bInUseFlag = value;
  }

  public Dictionary<ushort, FieldValueRangeRecSet> Ranges
  {
    get => this.m_ranges;
    set
    {
      this.m_ranges = value;
      this.NotifyPropertyChanged(nameof (Ranges));
    }
  }

  public ushort RangeCount
  {
    get
    {
      ushort rangeCount = 0;
      foreach (KeyValuePair<ushort, FieldValueRangeRecSet> range in this.m_ranges)
      {
        FieldValueRangeRecSet valueRangeRecSet = range.Value;
        rangeCount += (ushort) valueRangeRecSet.Count;
      }
      return rangeCount;
    }
  }

  internal AccessNode GetNodeAccess(int id)
  {
    AccessNode nodeAccess = (AccessNode) null;
    foreach (AccessNode accessNode in (Collection<AccessNode>) this.accessNodes)
    {
      if (accessNode.ID == (AccessNodeIDType) id)
      {
        nodeAccess = accessNode;
        break;
      }
    }
    return nodeAccess;
  }

  public bool IsEqual(AccessRecord inRec)
  {
    bool flag = true;
    for (int index = 0; index < 24; ++index)
    {
      if ((int) this.m_FieldCodeArr[index] != (int) inRec.m_FieldCodeArr[index])
      {
        flag = false;
        break;
      }
    }
    if (flag)
    {
      if (this.m_bOTAPState != inRec.m_bOTAPState)
      {
        flag = false;
      }
      else
      {
        Dictionary<ushort, FieldValueRangeRecSet> actualRangesSorted1 = this.GetActualRangesSorted(this);
        Dictionary<ushort, FieldValueRangeRecSet> actualRangesSorted2 = this.GetActualRangesSorted(inRec);
        if (actualRangesSorted1 == null && actualRangesSorted2 != null && actualRangesSorted2.Count != 0 || actualRangesSorted2 == null && actualRangesSorted1 != null && actualRangesSorted1.Count != 0)
          flag = false;
        if (actualRangesSorted1 != null && actualRangesSorted2 != null)
        {
          if (actualRangesSorted1.Count != actualRangesSorted2.Count)
          {
            flag = false;
          }
          else
          {
            foreach (KeyValuePair<ushort, FieldValueRangeRecSet> keyValuePair in actualRangesSorted1)
            {
              FieldValueRangeRecSet valueRangeRecSet = keyValuePair.Value;
              if (actualRangesSorted2.ContainsKey(keyValuePair.Key))
              {
                FieldValueRangeRecSet s = actualRangesSorted2[keyValuePair.Key];
                if (!valueRangeRecSet.IsEqual(s))
                {
                  flag = false;
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
      }
    }
    return flag;
  }

  private Dictionary<ushort, FieldValueRangeRecSet> GetActualRangesSorted(AccessRecord rec)
  {
    Dictionary<ushort, FieldValueRangeRecSet> actualRangesSorted = new Dictionary<ushort, FieldValueRangeRecSet>();
    foreach (AccessNode accessNode in (Collection<AccessNode>) rec.AccessNodes)
    {
      foreach (AccessSection section in accessNode.Sections)
      {
        foreach (AccessElement accessElement in section.Items)
        {
          if (accessElement is AccessRangeField && ((AccessField) accessElement).AccessLevel == AccessLevelType.Editable && ((AccessRangeField) accessElement).Ranges.Count > 0)
          {
            List<List<uint>> uintListList = new List<List<uint>>();
            foreach (AccessFieldValueRange range in (Collection<AccessFieldValueRange>) ((AccessRangeField) accessElement).Ranges)
            {
              uint? nullable = range.Maximum;
              if (nullable.HasValue)
              {
                nullable = range.Minimum;
                if (nullable.HasValue)
                {
                  List<uint> uintList = new List<uint>();
                  nullable = range.Minimum;
                  uint num1 = nullable.Value;
                  uintList.Add(num1);
                  nullable = range.Maximum;
                  uint num2 = nullable.Value;
                  uintList.Add(num2);
                  uintListList.Add(uintList);
                }
              }
            }
            uintListList.Sort(new Comparison<List<uint>>(AccessRecord.CompareListsByMin));
            FieldValueRangeRecSet valueRangeRecSet = new FieldValueRangeRecSet(((AccessRangeField) accessElement).Ranges.OwnerID);
            foreach (List<uint> uintList in uintListList)
              valueRangeRecSet.Add(new AccessFieldValueRange()
              {
                Minimum = new uint?(uintList[0]),
                Maximum = new uint?(uintList[1]),
                FieldID = (int) ((AccessRangeField) accessElement).Ranges.OwnerID
              });
            actualRangesSorted.Add(((AccessRangeField) accessElement).Ranges.OwnerID, valueRangeRecSet);
          }
        }
      }
    }
    return actualRangesSorted;
  }

  public static int CompareListsByMin(List<uint> x, List<uint> y)
  {
    return x != null ? (y != null ? x[0].CompareTo(y[0]) : 1) : (y != null ? -1 : 0);
  }

  public event PropertyChangedEventHandler PropertyChanged;

  private void NotifyPropertyChanged(string propertyName)
  {
    if (this.PropertyChanged == null)
      return;
    this.PropertyChanged((object) this, new PropertyChangedEventArgs(propertyName));
  }
}
