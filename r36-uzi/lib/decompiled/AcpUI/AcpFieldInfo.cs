// Decompiled with JetBrains decompiler
// Type: AcpUI.AcpFieldInfo
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

#nullable disable
namespace AcpUI;

internal class AcpFieldInfo
{
  private int recsetID;
  private int sectionID;
  private string fieldName;

  internal AcpFieldInfo(int recsetID, int sectionID, string fieldName)
  {
    this.recsetID = recsetID;
    this.sectionID = sectionID;
    this.fieldName = fieldName;
  }

  internal int RecsetID => this.recsetID;

  internal int SectionID => this.sectionID;

  internal string FieldName => this.fieldName;
}
