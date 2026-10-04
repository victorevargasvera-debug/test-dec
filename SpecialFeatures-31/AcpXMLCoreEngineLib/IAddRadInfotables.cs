// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.AcpXMLCoreEngineLib.IAddRadInfotables
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

#nullable disable
namespace SpecialFeatures.AcpXMLCoreEngineLib;

public interface IAddRadInfotables
{
  void AddGeneral(ref _XMLData RptXMLData);

  void AddTracking(ref _XMLData RptXMLData);

  void AddFlashPort(ref _XMLData RptXMLData);

  void AddVersion(ref _XMLData RptXMLData);

  void AddFeatures(ref _XMLData RptXMLData);
}
