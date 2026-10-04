// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.ACPXMLCoreEngineLib.XMLCoreEngineFactory
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using SpecialFeatures.AcpReportManagerLib;
using System;

#nullable disable
namespace SpecialFeatures.ACPXMLCoreEngineLib;

public class XMLCoreEngineFactory
{
  public AcpBaseXMLCoreEngine MakeXMLCoreObj(reportType reporytype)
  {
    int num1 = 0;
    short num2;
    while (true)
    {
      switch (num1)
      {
        case 0:
          switch (0)
          {
            case 0:
              break;
            default:
              continue;
          }
          break;
        case 1:
          num2 = (short) 0;
          num2 = (short) 2;
          num1 = (int) (IntPtr) num2;
          continue;
        case 2:
          goto label_17;
      }
      switch (reporytype)
      {
        case reportType.RadioInfo:
          num2 = (short) 14566;
          int num3 = (int) num2;
          num2 = (short) 14566;
          int num4 = (int) num2;
          switch (num3 == num4 ? 1 : 0)
          {
            case 0:
            case 2:
              break;
            default:
              goto label_13;
          }
          break;
        case reportType.HandOut:
          goto label_8;
        case reportType.HandOutO2:
          goto label_16;
        case reportType.HandOutO3:
          goto label_15;
        case reportType.HandOutO7:
          goto label_5;
        case reportType.HandOutO5:
          goto label_11;
        case reportType.HandOutO9:
          goto label_9;
        case reportType.Choices:
          goto label_17;
        case reportType.HandOutE5:
          goto label_6;
      }
      num2 = (short) 1;
      num1 = (int) (IntPtr) num2;
    }
label_5:
    return (AcpBaseXMLCoreEngine) new O7XMLCoreEngine();
label_6:
    num2 = (short) 1;
    if (num2 == (short) 0)
      ;
    return (AcpBaseXMLCoreEngine) new E5XMLCoreEngine();
label_8:
    return (AcpBaseXMLCoreEngine) new HandOutXMLCoreEngine();
label_9:
    return (AcpBaseXMLCoreEngine) new O9XMLCoreEngine();
label_11:
    return (AcpBaseXMLCoreEngine) new O5XMLCoreEngine();
label_13:
    num2 = (short) 0;
    if (num2 == (short) 0)
      ;
    return (AcpBaseXMLCoreEngine) new BaseRadioInfoXMLCoreEngine();
label_15:
    return (AcpBaseXMLCoreEngine) new O3XMLCoreEngine();
label_16:
    return (AcpBaseXMLCoreEngine) new O2XMLCoreEngine();
label_17:
    return (AcpBaseXMLCoreEngine) null;
  }
}
