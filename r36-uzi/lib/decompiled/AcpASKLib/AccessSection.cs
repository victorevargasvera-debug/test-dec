// Decompiled with JetBrains decompiler
// Type: AcpASKLib.AccessSection
// Assembly: AcpASKLib, Version=23.1.0.5, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: D65BC533-E9D0-49A5-8218-5CB2B5C70E2D
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpASKLib.dll

using System;
using System.Collections.ObjectModel;
using System.Xml.Serialization;

#nullable disable
namespace AcpASKLib;

[Serializable]
public class AccessSection : IAcpSecurity
{
  private ushort uId;
  private string name;
  private string uiName;
  private Collection<AccessElement> items;

  public AccessSection(string strName, string strUiName, ushort id)
  {
    this.uId = id;
    this.name = strName;
    this.uiName = strUiName;
    this.items = new Collection<AccessElement>();
  }

  public AccessSection()
  {
    this.uId = (ushort) 0;
    this.name = (string) null;
    this.uiName = (string) null;
    this.items = new Collection<AccessElement>();
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
  public ushort ID
  {
    get => this.uId;
    set => this.uId = value;
  }

  [XmlElement]
  [XmlElement(typeof (AccessField))]
  [XmlElement(typeof (AccessRangeField))]
  [XmlElement(typeof (AccessOperation))]
  public Collection<AccessElement> Items => this.items;

  public AccessElement this[int id]
  {
    get
    {
      AccessElement accessElement1 = (AccessElement) null;
      foreach (AccessElement accessElement2 in this.items)
      {
        if ((int) this.uId == (int) (ushort) accessElement2.ID)
        {
          accessElement1 = accessElement2;
          break;
        }
      }
      return accessElement1;
    }
  }

  public AccessElement this[string name]
  {
    get
    {
      AccessElement accessElement1 = (AccessElement) null;
      foreach (AccessElement accessElement2 in this.items)
      {
        if (name == accessElement2.Name)
        {
          accessElement1 = accessElement2;
          break;
        }
      }
      return accessElement1;
    }
  }

  [XmlIgnore]
  public AccessLevelType AccessLevel
  {
    get
    {
      AccessLevelType accessLevel = AccessLevelType.Editable;
      foreach (AccessElement accessElement in this.items)
      {
        if (accessElement is AccessField)
        {
          if (((AccessField) accessElement).AccessLevel == AccessLevelType.Editable)
          {
            accessLevel = AccessLevelType.Editable;
            break;
          }
          if (((AccessField) accessElement).AccessLevel == AccessLevelType.ReadOnly)
            accessLevel = AccessLevelType.ReadOnly;
        }
      }
      return accessLevel;
    }
    set
    {
      if (!AcpSecurity.CanChangeAccessSettings())
        throw new AcpSecurityException();
      foreach (AccessElement accessElement in this.items)
      {
        if (accessElement is AccessField)
          ((AccessField) accessElement).AccessLevel = value;
        else if (accessElement is AccessOperation)
        {
          if (value == AccessLevelType.Editable)
            ((AccessOperation) accessElement).AccessLevel = true;
          else
            ((AccessOperation) accessElement).AccessLevel = false;
        }
      }
    }
  }
}
