// Decompiled with JetBrains decompiler
// Type: AcpASKLib.AccessField
// Assembly: AcpASKLib, Version=23.1.0.5, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: D65BC533-E9D0-49A5-8218-5CB2B5C70E2D
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpASKLib.dll

using System;
using System.ComponentModel;
using System.Xml.Serialization;

#nullable disable
namespace AcpASKLib;

[XmlType("Field")]
[Serializable]
public class AccessField : AccessElement, IAcpSecurity, INotifyPropertyChanged
{
  private AccessLevelType accessLevel;
  private string mapID;

  public AccessField()
  {
    this.mapID = "A000";
    this.accessLevel = AccessLevelType.ReadOnly;
  }

  public AccessField(
    string name,
    string uiName,
    int id,
    AccessElementIDType elemId,
    AccessLevelType value)
    : base(name, uiName, id, elemId)
  {
    this.mapID = "A000";
    this.accessLevel = value;
  }

  public AccessField(
    string name,
    string uiName,
    int id,
    string mapId,
    AccessElementIDType elemId,
    AccessLevelType value)
    : base(name, uiName, id, elemId)
  {
    this.mapID = mapId;
    this.accessLevel = value;
  }

  [XmlAttribute]
  public string MapID
  {
    get => this.mapID;
    set => this.mapID = value;
  }

  [XmlIgnore]
  public AccessLevelType AccessLevel
  {
    get => this.accessLevel;
    set
    {
      this.accessLevel = value;
      this.NotifyPropertyChanged(nameof (AccessLevel));
    }
  }

  public event PropertyChangedEventHandler PropertyChanged;

  private void NotifyPropertyChanged(string propertyName)
  {
    if (this.PropertyChanged == null)
      return;
    this.PropertyChanged((object) this, new PropertyChangedEventArgs(propertyName));
  }
}
