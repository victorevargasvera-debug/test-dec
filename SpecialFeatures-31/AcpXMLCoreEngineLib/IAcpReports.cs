// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.AcpXMLCoreEngineLib.IAcpReports
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using AcpCommonLib;

#nullable disable
namespace SpecialFeatures.AcpXMLCoreEngineLib;

public interface IAcpReports
{
  void GetFeatureSectionName(ref string sectionName, int FeatureID, int SectionID, int index);

  void GetfieldsCollection(
    ref IAcpFeatureSection featuresection,
    int FeatureID,
    int SectionID,
    int index);

  void GetfieldFromPath(ref IAcpField field, int FeatureID, string fieldPath);

  void GetfieldsCollectionFromName(
    ref IAcpField field,
    int FeatureID,
    int SectionID,
    int index,
    string fieldName);
}
