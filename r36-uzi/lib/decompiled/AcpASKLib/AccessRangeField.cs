// Decompiled with JetBrains decompiler
// Type: AcpASKLib.AccessRangeField
// Assembly: AcpASKLib, Version=23.1.0.5, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: D65BC533-E9D0-49A5-8218-5CB2B5C70E2D
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpASKLib.dll

using System;
using System.ComponentModel;
using System.Xml.Serialization;

#nullable disable
namespace AcpASKLib;

[XmlType("RangeField")]
[Serializable]
public class AccessRangeField : AccessField, INotifyPropertyChanged
{
  private FieldValueRangeRecSet m_Ranges;

  public AccessRangeField() => this.m_Ranges = new FieldValueRangeRecSet((ushort) 0);

  public AccessRangeField(
    string name,
    string uiName,
    int id,
    AccessElementIDType elemId,
    AccessLevelType value)
    : base(name, uiName, id, elemId, value)
  {
    this.m_Ranges = new FieldValueRangeRecSet((ushort) id);
  }

  public AccessRangeField(
    string name,
    string uiName,
    int id,
    string mapId,
    AccessElementIDType elemId,
    AccessLevelType value)
    : base(name, uiName, id, mapId, elemId, value)
  {
    this.m_Ranges = new FieldValueRangeRecSet((ushort) id);
  }

  [XmlIgnore]
  public FieldValueRangeRecSet Ranges
  {
    get => this.m_Ranges;
    set
    {
      this.m_Ranges = value;
      this.NotifyPropertyChanged(nameof (Ranges));
    }
  }

  public new event PropertyChangedEventHandler PropertyChanged;

  private void NotifyPropertyChanged(string propertyName)
  {
    if (this.PropertyChanged == null)
      return;
    this.PropertyChanged((object) this, new PropertyChangedEventArgs(propertyName));
  }
}
