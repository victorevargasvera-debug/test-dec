// Decompiled with JetBrains decompiler
// Type: AcpASKLib.FeatureCategory
// Assembly: AcpASKLib, Version=23.1.0.5, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: D65BC533-E9D0-49A5-8218-5CB2B5C70E2D
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpASKLib.dll

using System;
using System.Collections.ObjectModel;
using System.Xml.Serialization;

#nullable disable
namespace AcpASKLib;

[Serializable]
public class FeatureCategory
{
  private string name;
  private FeatureCategoryType type;
  private FeatureCategoryRadioType radioType;
  private Collection<AccessNode> features;
  private Collection<AccessNode> functions;

  public FeatureCategory()
  {
    this.type = FeatureCategoryType.UNKNOWN;
    this.features = new Collection<AccessNode>();
    this.functions = new Collection<AccessNode>();
    this.radioType = FeatureCategoryRadioType.XTSXTLRadios;
  }

  public FeatureCategory(string sName, FeatureCategoryType catType)
  {
    this.name = sName;
    this.features = new Collection<AccessNode>();
    this.functions = new Collection<AccessNode>();
    this.type = catType;
    this.radioType = FeatureCategoryRadioType.XTSXTLRadios;
  }

  public FeatureCategory(
    string sName,
    FeatureCategoryType catType,
    FeatureCategoryRadioType radType)
  {
    this.name = sName;
    this.features = new Collection<AccessNode>();
    this.functions = new Collection<AccessNode>();
    this.type = catType;
    this.radioType = radType;
  }

  [XmlAttribute]
  public string Name
  {
    get => this.name;
    set => this.name = value;
  }

  [XmlAttribute]
  public FeatureCategoryType Type
  {
    get => this.type;
    set => this.type = value;
  }

  [XmlElement("Feature")]
  public Collection<AccessNode> Features => this.features;

  [XmlElement("Function")]
  public Collection<AccessNode> Functions => this.functions;

  [XmlAttribute("RadioType")]
  public FeatureCategoryRadioType RadioType
  {
    get => this.radioType;
    set => this.radioType = value;
  }
}
