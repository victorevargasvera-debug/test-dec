// Decompiled with JetBrains decompiler
// Type: AcpASKLib.FieldValueRangeRecSet
// Assembly: AcpASKLib, Version=23.1.0.5, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: D65BC533-E9D0-49A5-8218-5CB2B5C70E2D
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpASKLib.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml;

#nullable disable
namespace AcpASKLib;

[Serializable]
public class FieldValueRangeRecSet : ObservableCollection<AccessFieldValueRange>
{
  private ushort m_ownerId;

  public FieldValueRangeRecSet(ushort ownerId) => this.m_ownerId = ownerId;

  internal bool IsEqual(FieldValueRangeRecSet s)
  {
    bool flag = true;
    if ((int) this.m_ownerId != (int) s.m_ownerId || this.Count != s.Count)
    {
      flag = false;
    }
    else
    {
      for (int index = 0; index < this.Count; ++index)
      {
        AccessFieldValueRange accessFieldValueRange1 = this.Items[index];
        AccessFieldValueRange accessFieldValueRange2 = s.Items[index];
        if (accessFieldValueRange1.FieldID == accessFieldValueRange2.FieldID)
        {
          uint? nullable1 = accessFieldValueRange1.Minimum;
          uint? nullable2 = accessFieldValueRange2.Minimum;
          if ((int) nullable1.GetValueOrDefault() == (int) nullable2.GetValueOrDefault() & nullable1.HasValue == nullable2.HasValue)
          {
            nullable2 = accessFieldValueRange1.Maximum;
            nullable1 = accessFieldValueRange2.Maximum;
            if ((int) nullable2.GetValueOrDefault() == (int) nullable1.GetValueOrDefault() & nullable2.HasValue == nullable1.HasValue)
              continue;
          }
        }
        flag = false;
        break;
      }
    }
    return flag;
  }

  public FieldValueRangeRecSet(XmlNode node)
  {
    AccessFieldValueRange accessFieldValueRange = (AccessFieldValueRange) null;
    short num1 = 0;
    int num2 = 0;
    int num3 = 0;
    int num4 = 0;
    for (XmlNode xmlNode = node.FirstChild; xmlNode != null; xmlNode = xmlNode.NextSibling)
    {
      string name = xmlNode.Name;
      string innerText = xmlNode.InnerText;
      if ("RangeNum" == name)
      {
        num2 = (int) short.Parse(innerText);
        if (num2 <= 0)
          throw new Exception("Invalid Range Count.");
      }
      if ("FieldTag" == name)
      {
        num1 = short.Parse(innerText);
        this.m_ownerId = (ushort) num1;
      }
      if ("DataMin" == name)
      {
        uint num5 = uint.Parse(innerText);
        accessFieldValueRange = new AccessFieldValueRange();
        accessFieldValueRange.FieldID = (int) num1;
        accessFieldValueRange.Minimum = new uint?(num5);
        ++num3;
      }
      if ("DataMax" == name)
      {
        uint num6 = uint.Parse(innerText);
        if (accessFieldValueRange != null)
        {
          accessFieldValueRange.Maximum = new uint?(num6);
          uint? minimum = accessFieldValueRange.Minimum;
          uint? maximum = accessFieldValueRange.Maximum;
          if (minimum.GetValueOrDefault() > maximum.GetValueOrDefault() & minimum.HasValue & maximum.HasValue)
            throw new Exception("FieldValueRangeRecSet: Range Error - Mininmum cannot be less than Maximum");
          this.Add(accessFieldValueRange);
        }
        accessFieldValueRange = (AccessFieldValueRange) null;
        ++num4;
      }
    }
    if (num2 != num3)
      throw new Exception("FieldValueRangeRecSet: Range Error - RangeCount is not equal to DataMin");
    if (num2 != num4)
      throw new Exception("FieldValueRangeRecSet: Range Error - RangeCount is not equal to DataMax");
  }

  internal string ToXMLStr(int nTabs)
  {
    string str1 = "";
    string str2 = "";
    for (int index = 0; index < nTabs; ++index)
      str2 += "\t";
    string str3 = str1 + str2 + "<LimitedDataRecord>\n" + str2 + "\t<FieldTag>" + $"{this.m_ownerId}" + "</FieldTag>";
    int count = this.Count;
    string str4 = str3 + str2 + "\t<RangeNum>" + $"{count}" + "</RangeNum>";
    foreach (AccessFieldValueRange accessFieldValueRange in (Collection<AccessFieldValueRange>) this)
    {
      uint? minimum = accessFieldValueRange.Minimum;
      uint? maximum = accessFieldValueRange.Maximum;
      str4 += str2;
      str4 += "\t<DataMin>";
      string str5 = $"{minimum}";
      str4 += str5;
      str4 += "</DataMin>";
      str4 += str2;
      str4 += "\t<DataMax>";
      string str6 = $"{maximum}";
      str4 += str6;
      str4 += "</DataMax>";
    }
    return str4 + str2 + "</LimitedDataRecord>\n";
  }

  internal byte[] PackedData
  {
    get
    {
      ArrayList arrayList = new ArrayList();
      int count = this.Count;
      if (count > 0)
      {
        byte ownerId = (byte) this.m_ownerId;
        arrayList.Add((object) ownerId);
        arrayList.Add((object) (byte) count);
        foreach (AccessFieldValueRange accessFieldValueRange in (IEnumerable<AccessFieldValueRange>) this.Items)
        {
          uint? minimum = accessFieldValueRange.Minimum;
          uint? maximum = accessFieldValueRange.Maximum;
          uint? nullable1 = minimum;
          uint? nullable2;
          uint? nullable3;
          if (!nullable1.HasValue)
          {
            nullable2 = new uint?();
            nullable3 = nullable2;
          }
          else
            nullable3 = new uint?(nullable1.GetValueOrDefault() >> 24);
          nullable2 = nullable3;
          byte num1 = (byte) nullable2.Value;
          arrayList.Add((object) num1);
          nullable1 = minimum;
          uint? nullable4;
          if (!nullable1.HasValue)
          {
            nullable2 = new uint?();
            nullable4 = nullable2;
          }
          else
            nullable4 = new uint?(nullable1.GetValueOrDefault() >> 16 /*0x10*/);
          nullable2 = nullable4;
          byte num2 = (byte) nullable2.Value;
          arrayList.Add((object) num2);
          nullable1 = minimum;
          uint? nullable5;
          if (!nullable1.HasValue)
          {
            nullable2 = new uint?();
            nullable5 = nullable2;
          }
          else
            nullable5 = new uint?(nullable1.GetValueOrDefault() >> 8);
          nullable2 = nullable5;
          byte num3 = (byte) nullable2.Value;
          arrayList.Add((object) num3);
          nullable1 = minimum;
          uint maxValue1 = (uint) byte.MaxValue;
          uint? nullable6;
          if (!nullable1.HasValue)
          {
            nullable2 = new uint?();
            nullable6 = nullable2;
          }
          else
            nullable6 = new uint?(nullable1.GetValueOrDefault() & maxValue1);
          nullable2 = nullable6;
          byte num4 = (byte) nullable2.Value;
          arrayList.Add((object) num4);
          nullable1 = maximum;
          uint? nullable7;
          if (!nullable1.HasValue)
          {
            nullable2 = new uint?();
            nullable7 = nullable2;
          }
          else
            nullable7 = new uint?(nullable1.GetValueOrDefault() >> 24);
          nullable2 = nullable7;
          byte num5 = (byte) nullable2.Value;
          arrayList.Add((object) num5);
          nullable1 = maximum;
          uint? nullable8;
          if (!nullable1.HasValue)
          {
            nullable2 = new uint?();
            nullable8 = nullable2;
          }
          else
            nullable8 = new uint?(nullable1.GetValueOrDefault() >> 16 /*0x10*/);
          nullable2 = nullable8;
          byte num6 = (byte) nullable2.Value;
          arrayList.Add((object) num6);
          nullable1 = maximum;
          uint? nullable9;
          if (!nullable1.HasValue)
          {
            nullable2 = new uint?();
            nullable9 = nullable2;
          }
          else
            nullable9 = new uint?(nullable1.GetValueOrDefault() >> 8);
          nullable2 = nullable9;
          byte num7 = (byte) nullable2.Value;
          arrayList.Add((object) num7);
          nullable1 = maximum;
          uint maxValue2 = (uint) byte.MaxValue;
          uint? nullable10;
          if (!nullable1.HasValue)
          {
            nullable2 = new uint?();
            nullable10 = nullable2;
          }
          else
            nullable10 = new uint?(nullable1.GetValueOrDefault() & maxValue2);
          nullable2 = nullable10;
          byte num8 = (byte) nullable2.Value;
          arrayList.Add((object) num8);
        }
      }
      return (byte[]) arrayList.ToArray(typeof (byte));
    }
  }

  public ushort OwnerID => this.m_ownerId;
}
