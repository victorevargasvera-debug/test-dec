// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.AcpXMLCoreEngineLib.IAddRadHandouttables
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using SpecialFeatures.AcpReportManagerLib;

#nullable disable
namespace SpecialFeatures.AcpXMLCoreEngineLib;

public interface IAddRadHandouttables
{
  void AddGeneral(ref _XMLData RptXMLData);

  void AddButtonsAndControl(ref _XMLData RptXMLData);

  void AddButtonsAndControlO2(ref _XMLData RptXMLData, reportType rptType);

  void AddButtonsAndControlO3(ref _XMLData RptXMLData, reportType rptType);

  void AddButtonsAndControlO7(ref _XMLData RptXMLData, reportType rptType);

  void AddButtonsAndControlO5(ref _XMLData RptXMLData, reportType rptType);

  void AddButtonsAndControlO9(ref _XMLData RptXMLData, reportType rptType);

  void AddZonesAndChannels(ref _XMLData RptXMLData);
}
