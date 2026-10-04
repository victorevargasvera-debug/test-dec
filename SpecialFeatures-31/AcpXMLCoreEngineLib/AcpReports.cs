// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.AcpXMLCoreEngineLib.AcpReports
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using AcpCommonLib;
using SpecialFeatures.AcpReportManagerLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;

#nullable disable
namespace SpecialFeatures.AcpXMLCoreEngineLib;

public class AcpReports : IAcpReports
{
  public void GetFeatureSectionName(
    ref string sectionName,
    int FeatureID,
    int SectionID,
    int index)
  {
    int A_1 = 10;
    short num1 = 0;
    int num2;
    IAcpRecordset feature;
    switch (0)
    {
      case 0:
label_2:
        sectionName = RptMgrErrorHandler.b("\uDE8C\uEA8E\uF290\uE792ﲔ\uF896\uF798뮚펜ﺞ철욢", A_1);
        feature = FeatureManager.GetFeature(FeatureID);
        num1 = (short) 4;
        num2 = (int) (IntPtr) num1;
        goto default;
      default:
        IAcpFeatureSection iacpFeatureSection;
        IAcpFeatureNode iacpFeatureNode;
        while (true)
        {
          switch (num2)
          {
            case 0:
              if (iacpFeatureSection != null)
              {
                num1 = (short) 1;
                if (num1 == (short) 0)
                  ;
                num1 = (short) 1;
                num2 = (int) (IntPtr) num1;
                continue;
              }
              goto label_14;
            case 1:
              sectionName = "";
              sectionName = iacpFeatureSection.UIName;
              num1 = (short) 5;
              num2 = (int) (IntPtr) num1;
              continue;
            case 2:
              if (iacpFeatureNode != null)
              {
                num1 = (short) 3;
                num2 = (int) (IntPtr) num1;
                continue;
              }
              goto label_9;
            case 3:
              iacpFeatureSection = iacpFeatureNode[SectionID];
              num1 = (short) 0;
              num2 = (int) (IntPtr) num1;
              continue;
            case 4:
              num1 = (short) -19858;
              int num3 = (int) num1;
              num1 = (short) -19858;
              int num4 = (int) num1;
              switch (num3 == num4 ? 1 : 0)
              {
                case 0:
                case 2:
                  goto label_15;
                default:
                  num1 = (short) 0;
                  if (num1 == (short) 0)
                    ;
                  if (feature != null)
                  {
                    num1 = (short) 6;
                    num2 = (int) (IntPtr) num1;
                    continue;
                  }
                  goto label_18;
              }
            case 5:
              goto label_7;
            case 6:
label_15:
              iacpFeatureNode = feature[index];
              num1 = (short) 2;
              num2 = (int) (IntPtr) num1;
              continue;
            default:
              goto label_2;
          }
        }
label_7:
        break;
label_18:
        break;
label_14:
        break;
label_9:
        break;
    }
  }

  public void GetfieldsCollection(
    ref IAcpFeatureSection featureSection,
    int FeatureID,
    int SectionID,
    int index)
  {
label_0:
    int num1;
    IAcpRecordset feature;
    short num2;
    switch (0)
    {
      case 0:
label_2:
        feature = FeatureManager.GetFeature(FeatureID);
        num2 = (short) 2;
        num1 = (int) (IntPtr) num2;
        goto default;
      default:
        IAcpFeatureNode iacpFeatureNode;
        while (true)
        {
          switch (num1)
          {
            case 0:
              if (iacpFeatureNode != null)
              {
                num2 = (short) 3;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_10;
            case 1:
              goto label_9;
            case 2:
              if (feature != null)
              {
                num2 = (short) 4;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_14;
            case 3:
              featureSection = iacpFeatureNode[SectionID];
              num2 = (short) 12485;
              int num3 = (int) num2;
              num2 = (short) 12485;
              int num4 = (int) num2;
              switch (num3 == num4 ? 1 : 0)
              {
                case 0:
                case 2:
                  goto label_0;
                default:
                  num2 = (short) 0;
                  if (num2 == (short) 0)
                    ;
                  num2 = (short) 1;
                  num1 = (int) (IntPtr) num2;
                  continue;
              }
            case 4:
              num2 = (short) 1;
              if (num2 == (short) 0)
                ;
              iacpFeatureNode = feature[index];
              num2 = (short) 0;
              num1 = (int) (IntPtr) num2;
              continue;
            default:
              goto label_2;
          }
        }
label_14:
        break;
label_9:
        num2 = (short) 0;
        break;
label_10:
        break;
    }
  }

  public void GetfieldFromPath(ref IAcpField field, int FeatureID, string fieldPath)
  {
    int A_1 = 9;
    int num1;
    IAcpRecordset feature;
    short num2;
    switch (0)
    {
      case 0:
label_2:
        feature = FeatureManager.GetFeature(FeatureID);
        num2 = (short) 2;
        num1 = (int) (IntPtr) num2;
        goto default;
      default:
        while (true)
        {
          switch (num1)
          {
            case 0:
label_5:
              num2 = (short) -13425;
              int num3 = (int) num2;
              num2 = (short) -13425;
              int num4 = (int) num2;
              switch (num3 == num4 ? 1 : 0)
              {
                case 0:
                case 2:
                  goto label_5;
                default:
                  num2 = (short) 0;
                  num2 = (short) 1;
                  if (num2 == (short) 0)
                    ;
                  num2 = (short) 0;
                  if (num2 == (short) 0)
                    ;
                  field = feature.FieldFromPath(fieldPath, RptMgrErrorHandler.b("㞋", A_1));
                  num2 = (short) 1;
                  num1 = (int) (IntPtr) num2;
                  continue;
              }
            case 1:
              goto label_6;
            case 2:
              if (feature != null)
              {
                num2 = (short) 0;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_10;
            default:
              goto label_2;
          }
        }
label_6:
        break;
label_10:
        break;
    }
  }

  public void GetfieldsCollectionFromName(
    ref IAcpField field,
    int FeatureID,
    int SectionID,
    int index,
    string fieldName)
  {
    int A_1 = 6;
    short num1 = 0;
    int num2 = (int) num1;
    switch (num2)
    {
      default:
        IAcpRecordset feature;
        switch (0)
        {
          case 0:
label_3:
            feature = FeatureManager.GetFeature(FeatureID);
            num1 = (short) 4;
            num2 = (int) (IntPtr) num1;
            goto default;
          default:
            IEnumerator<IAcpField> enumerator;
            IAcpFeatureSection iacpFeatureSection;
            IAcpFeatureNode iacpFeatureNode;
            while (true)
            {
              switch (num2)
              {
                case 0:
                  num1 = (short) 1;
                  if (num1 == (short) 0)
                    ;
                  if (iacpFeatureNode != null)
                  {
                    num1 = (short) 1;
                    num2 = (int) (IntPtr) num1;
                    continue;
                  }
                  goto label_37;
                case 1:
                  iacpFeatureSection = iacpFeatureNode[SectionID];
                  num1 = (short) 2;
                  num2 = (int) (IntPtr) num1;
                  continue;
                case 2:
                  if (iacpFeatureSection != null)
                  {
                    num1 = (short) 3;
                    num2 = (int) (IntPtr) num1;
                    continue;
                  }
                  goto label_32;
                case 3:
                  enumerator = iacpFeatureSection.FieldsCollection.GetEnumerator();
                  num1 = (short) 5;
                  num2 = (int) (IntPtr) num1;
                  continue;
                case 4:
                  if (feature != null)
                  {
                    num1 = (short) 6;
                    num2 = (int) (IntPtr) num1;
                    continue;
                  }
                  goto label_41;
                case 5:
                  goto label_6;
                case 6:
                  iacpFeatureNode = feature[index];
                  num1 = (short) 0;
                  num2 = (int) (IntPtr) num1;
                  continue;
                default:
                  goto label_3;
              }
            }
label_41:
            return;
label_6:
            try
            {
              num1 = (short) 6;
              int num3 = (int) (IntPtr) num1;
              while (true)
              {
                IAcpField current;
                switch (num3)
                {
                  case 0:
                    goto label_29;
                  case 1:
                    field = current;
                    num1 = (short) 0;
                    num3 = (int) (IntPtr) num1;
                    continue;
                  case 2:
                    if (fieldName == current.Name)
                    {
                      num1 = (short) 1;
                      num3 = (int) (IntPtr) num1;
                      continue;
                    }
                    break;
                  case 3:
                    if (current != null)
                    {
                      num1 = (short) 4;
                      num3 = (int) (IntPtr) num1;
                      continue;
                    }
                    break;
                  case 4:
label_15:
                    num1 = (short) 2;
                    num3 = (int) (IntPtr) num1;
                    continue;
                  case 5:
                    goto label_27;
                  case 6:
                    switch (0)
                    {
                      case 0:
                        break;
                      default:
                        continue;
                    }
                    break;
                  case 7:
                    num1 = (short) 4270;
                    int num4 = (int) num1;
                    num1 = (short) 4270;
                    int num5 = (int) num1;
                    switch (num4 == num5 ? 1 : 0)
                    {
                      case 0:
                      case 2:
                        goto label_15;
                      default:
                        num1 = (short) 0;
                        if (num1 == (short) 0)
                          ;
                        num1 = (short) 5;
                        num3 = (int) (IntPtr) num1;
                        continue;
                    }
                  case 8:
                    if (!enumerator.MoveNext())
                    {
                      num1 = (short) 7;
                      num3 = (int) (IntPtr) num1;
                      continue;
                    }
                    current = enumerator.Current;
                    Trace.WriteLine(string.Format(RptMgrErrorHandler.b("있놊\uF68C뾎\uEC90뾒떔솖\uF898\uF79A\uE89C爵\uDAA0銢\uD8A4讦覨ﮪ첬\uDBAE\uD9B0좲螴쪶馸", A_1), (object) current.Name, (object) current.ToString(), (object) current.Path(RptMgrErrorHandler.b("했", A_1))));
                    num1 = (short) 3;
                    num3 = (int) (IntPtr) num1;
                    continue;
                }
                num1 = (short) 8;
                num3 = (int) (IntPtr) num1;
              }
label_29:
              return;
label_27:
              return;
            }
            finally
            {
              short num6 = 2;
              int num7 = (int) (IntPtr) num6;
              while (true)
              {
                switch (num7)
                {
                  case 0:
                    enumerator.Dispose();
                    num6 = (short) 1;
                    num7 = (int) (IntPtr) num6;
                    continue;
                  case 1:
                    goto label_30;
                  case 2:
                    switch (0)
                    {
                      case 0:
                        break;
                      default:
                        continue;
                    }
                    break;
                }
                if (enumerator != null)
                {
                  num6 = (short) 0;
                  num7 = (int) (IntPtr) num6;
                }
                else
                  break;
              }
label_30:;
            }
label_37:
            return;
label_32:
            return;
        }
    }
  }
}
