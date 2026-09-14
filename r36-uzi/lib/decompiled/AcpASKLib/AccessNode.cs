// Decompiled with JetBrains decompiler
// Type: AcpASKLib.AccessNode
// Assembly: AcpASKLib, Version=23.1.0.5, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: D65BC533-E9D0-49A5-8218-5CB2B5C70E2D
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpASKLib.dll

using System;
using System.Collections.ObjectModel;
using System.Xml.Serialization;

#nullable disable
namespace AcpASKLib;

[Serializable]
public class AccessNode : IAcpSecurity
{
  private AccessNodeIDType uId;
  private string name;
  private string uiName;
  private Collection<AccessSection> sections;

  public AccessNode(string strName, string strUiName, AccessNodeIDType id)
  {
    this.uId = id;
    this.name = strName;
    this.uiName = strUiName;
    this.sections = new Collection<AccessSection>();
  }

  public AccessNode()
  {
    this.uId = AccessNodeIDType.UNDEFINED;
    this.name = (string) null;
    this.uiName = (string) null;
    this.sections = new Collection<AccessSection>();
  }

  [XmlAttribute]
  public string Name
  {
    get => this.name;
    set => this.name = value;
  }

  [XmlAttribute]
  public string UIName
  {
    get => this.uiName;
    set => this.uiName = value;
  }

  [XmlAttribute]
  public AccessNodeIDType ID
  {
    get => this.uId;
    set => this.uId = value;
  }

  [XmlElement("Section")]
  public Collection<AccessSection> Sections => this.sections;

  public AccessSection this[int id]
  {
    get
    {
      AccessSection accessSection = (AccessSection) null;
      foreach (AccessSection section in this.sections)
      {
        if (id == (int) section.ID)
        {
          accessSection = section;
          break;
        }
      }
      return accessSection;
    }
  }

  public AccessSection this[string name]
  {
    get
    {
      AccessSection accessSection = (AccessSection) null;
      foreach (AccessSection section in this.sections)
      {
        if (name == section.Name)
        {
          accessSection = section;
          break;
        }
      }
      return accessSection;
    }
  }

  [XmlIgnore]
  public AccessLevelType AccessLevel
  {
    get
    {
      AccessLevelType accessLevel = AccessLevelType.Editable;
      foreach (AccessSection section in this.sections)
      {
        if (section.AccessLevel == AccessLevelType.Editable)
        {
          accessLevel = AccessLevelType.Editable;
          break;
        }
        if (section.AccessLevel == AccessLevelType.ReadOnly)
          accessLevel = AccessLevelType.ReadOnly;
      }
      return accessLevel;
    }
    set
    {
      if (!AcpSecurity.CanChangeAccessSettings())
        throw new AcpSecurityException();
      foreach (AccessSection section in this.sections)
        section.AccessLevel = value;
    }
  }
}
