// Decompiled with JetBrains decompiler
// Type: AcpASKLib.AccessElement
// Assembly: AcpASKLib, Version=23.1.0.5, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: D65BC533-E9D0-49A5-8218-5CB2B5C70E2D
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpASKLib.dll

using System;
using System.Xml.Serialization;

#nullable disable
namespace AcpASKLib;

[Serializable]
public class AccessElement
{
  private string name;
  private string uiName;
  private int bitID;
  private AccessElementIDType elementID;

  public AccessElement()
  {
    this.name = (string) null;
    this.uiName = (string) null;
    this.bitID = 0;
    this.elementID = AccessElementIDType.UNDEFINED;
  }

  public AccessElement(string strName, string strUiName, int id, AccessElementIDType elemId)
  {
    this.name = strName;
    this.uiName = strUiName;
    this.bitID = id;
    this.elementID = elemId;
  }

  [XmlAttribute]
  public int ID
  {
    get => this.bitID;
    set => this.bitID = value;
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
  public AccessElementIDType ElemID
  {
    get => this.elementID;
    set => this.elementID = value;
  }
}
