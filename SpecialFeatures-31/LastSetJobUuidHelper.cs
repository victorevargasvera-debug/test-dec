// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.LastSetJobUuidHelper
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using AcpCommonLib;
using SpecialFeatures.AcpReportManagerLib;
using System;

#nullable disable
namespace SpecialFeatures;

public class LastSetJobUuidHelper
{
  public static void SetLastSetJobUuidField(string guidToSet = null)
  {
    int A_1 = 2;
    int num1 = 1;
    short num2;
    Guid result;
    while (true)
    {
      switch (num1)
      {
        case 0:
          num2 = (short) 4;
          num1 = (int) (IntPtr) num2;
          continue;
        case 1:
          num2 = (short) 0;
          num2 = (short) 30257;
          int num3 = (int) num2;
          num2 = (short) 30257;
          int num4 = (int) num2;
          switch (num3 == num4 ? 1 : 0)
          {
            case 0:
            case 2:
              goto label_7;
            default:
              num2 = (short) 0;
              if (num2 == (short) 0)
                ;
              switch (0)
              {
                case 0:
                  goto label_5;
                default:
                  continue;
              }
          }
        case 2:
label_7:
          num2 = (short) 1;
          if (num2 == (short) 0)
            ;
          result = Guid.NewGuid();
          guidToSet = result.ToString(RptMgrErrorHandler.b("쮄", A_1)).ToUpper();
          num2 = (short) 3;
          num1 = (int) (IntPtr) num2;
          continue;
        case 3:
          goto label_12;
        case 4:
          if (!Guid.TryParse(guidToSet, out result))
          {
            num2 = (short) 2;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto label_12;
        default:
label_5:
          if (guidToSet != null)
          {
            num2 = (short) 0;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto case 2;
      }
    }
label_12:
    (FeatureManager.GetFeature(2045)[0] as Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide).Labtool.RadWideLabtoolRCLastJobSetUUIDValue = guidToSet;
  }
}
