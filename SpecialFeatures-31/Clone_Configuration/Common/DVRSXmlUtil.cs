// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.Clone_Configuration.Common.DVRSXmlUtil
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using AcpCommonLib;
using ConstraintHelper;
using SpecialFeatures.AcpReportManagerLib;
using SpecialFeatures.DVRSXML;
using System;

#nullable disable
namespace SpecialFeatures.Clone_Configuration.Common;

public class DVRSXmlUtil
{
  public static int ExportDVRSAfterClone(string serialNumber)
  {
    int A_1 = 17;
    int num1 = 0;
    switch (num1)
    {
      default:
        if (false)
          ;
        int num2;
        DvrsMsuDataSync dvrsMsuDataSync;
        Motorola.MackinawCPS.CoreFeatures.DVRSWide.DVRSWide dvrsWide;
        short num3;
        switch (0)
        {
          case 0:
label_4:
            num2 = -1;
            dvrsMsuDataSync = (DvrsMsuDataSync) null;
            dvrsWide = FeatureManager.GetFeature(4142)[0] as Motorola.MackinawCPS.CoreFeatures.DVRSWide.DVRSWide;
            num3 = (short) 4;
            num1 = (int) (IntPtr) num3;
            goto default;
          default:
            while (true)
            {
              string xmlFullPath;
              int num4;
              switch (num1)
              {
                case 0:
                  num4 = 1;
                  goto label_13;
                case 1:
                  if (dvrsMsuDataSync != null)
                  {
                    num3 = (short) 6;
                    num1 = (int) (IntPtr) num3;
                    continue;
                  }
                  goto label_21;
                case 2:
                  num3 = (short) 1;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 3:
                  if (!dvrsMsuDataSync.ExportToXmlDoc(xmlFullPath))
                  {
                    num3 = (short) 5;
                    num1 = (int) (IntPtr) num3;
                    continue;
                  }
                  break;
                case 4:
                  if (dvrsWide.General.RadErgoWideDigitalVehicularRepeaterSystemDVRSHardwareEnable_A7911.Value)
                  {
                    num3 = (short) 7;
                    num1 = (int) (IntPtr) num3;
                    continue;
                  }
                  goto case 2;
                case 5:
                  num3 = (short) 8;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 6:
                  xmlFullPath = string.Format(RptMgrErrorHandler.b("\uEF93ꚕ\uE597욙\uE79B꾝\uDD9F", A_1), (object) UtilityMack.DVRSExportPath, (object) dvrsMsuDataSync.BuildFileName(serialNumber));
                  num3 = (short) 3;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 7:
                  dvrsMsuDataSync = new DvrsMsuDataSync();
                  uint hashCode = dvrsMsuDataSync.CalculateHashCode();
                  dvrsWide.General.DVRSWideLabtoolDVRSSyncFieldsHash_A41811.SetValue((long) hashCode);
                  num3 = (short) 2;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 8:
                  num3 = (short) 24097;
                  int num5 = (int) num3;
                  num3 = (short) 24097;
                  int num6 = (int) num3;
                  switch (num5 == num6 ? 1 : 0)
                  {
                    case 0:
                    case 2:
                      break;
                    default:
                      num3 = (short) 0;
                      if (num3 == (short) 0)
                        ;
                      num4 = 0;
                      goto label_13;
                  }
                  break;
                case 9:
                  goto label_21;
                default:
                  goto label_4;
              }
              num3 = (short) 0;
              num1 = (int) (IntPtr) num3;
              continue;
label_13:
              num2 = num4;
              num3 = (short) 9;
              num1 = (int) (IntPtr) num3;
            }
label_21:
            return num2;
        }
    }
  }
}
