// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.ACPXMLCoreEngineLib.E5XMLCoreEngine
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using AcpBusinessLayer;
using AcpCommonLib;
using CommonResources;
using ConstraintHelper;
using Motorola.MackinawCPS.CoreFeatures.ControlHeadE5;
using Motorola.MackinawCPS.CoreFeatures.KeypadMicAndAccessories;
using SpecialFeatures.AcpReportManagerLib;
using SpecialFeatures.AcpXMLCoreEngineLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;

#nullable disable
namespace SpecialFeatures.ACPXMLCoreEngineLib;

public class E5XMLCoreEngine : BaseHandOutXMLCoreEngine
{
  private ControlHeadE5Recset a;
  private E5NavigationControlsTableInnerRecset b;
  private E5InnerRecset c;
  private E5BottomFunctionButtonInnerRecset d;
  private KMButtonInnerRecset e;
  private KeypadMicAndAccessoriesRecset f;
  private DataButtonInnerRecset g;

  public E5XMLCoreEngine()
  {
    this.a = FeatureManager.GetFeature(4236) as ControlHeadE5Recset;
    if (this.a != null)
      goto label_4;
label_3:
    this.f = FeatureManager.GetFeature(2128) as KeypadMicAndAccessoriesRecset;
    if (this.f == null)
      return;
    this.e = ((Recordset) this.f)[0][10231].EmbeddedRecset as KMButtonInnerRecset;
    this.g = ((Recordset) this.f)[0][10228].EmbeddedRecset as DataButtonInnerRecset;
    return;
label_4:
    this.c = ((Recordset) this.a)[0][10902].EmbeddedRecset as E5InnerRecset;
    this.d = ((Recordset) this.a)[0][10903].EmbeddedRecset as E5BottomFunctionButtonInnerRecset;
    this.b = ((Recordset) this.a)[0][10896].EmbeddedRecset as E5NavigationControlsTableInnerRecset;
    goto label_3;
  }

  private void e(ref _table A_0)
  {
    int A_1 = 12;
    switch (0)
    {
      default:
        int num1 = 1;
        short num2;
        IEnumerator<FeatureNode> enumerator;
        while (true)
        {
          num2 = (short) 0;
          switch (num1)
          {
            case 0:
              goto label_6;
            case 1:
              switch (0)
              {
                case 0:
                  break;
                default:
                  continue;
              }
              break;
            case 2:
              enumerator = ((Collection<FeatureNode>) this.c).GetEnumerator();
              num2 = (short) 0;
              num1 = (int) (IntPtr) num2;
              continue;
          }
          if (this.c != null)
          {
            num2 = (short) 2;
            num1 = (int) (IntPtr) num2;
          }
          else
            break;
        }
        break;
label_6:
        try
        {
          num2 = (short) 0;
          int num3 = (int) (IntPtr) num2;
          while (true)
          {
            switch (num3)
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
                num2 = (short) 1;
                if (num2 == (short) 0)
                  break;
                break;
              case 2:
                num2 = (short) 3;
                num3 = (int) (IntPtr) num2;
                continue;
              case 3:
                goto label_21;
              case 4:
                if (!enumerator.MoveNext())
                {
                  num2 = (short) 2;
                  num3 = (int) (IntPtr) num2;
                  continue;
                }
                IAcpFeatureNode current = (IAcpFeatureNode) enumerator.Current;
                this.rptRec = new _RecSet();
                this.rptFields = new _UIFields();
                int num4 = this.count++;
                _RecSet rptRec1 = this.rptRec;
                string noprintId = AppResources.NOPRINT_Id;
                num4 = this.count;
                string str1 = num4.ToString();
                string str2 = noprintId + str1;
                rptRec1.RecTitle = str2;
                _RecSet rptRec2 = this.rptRec;
                num4 = this.count;
                string str3 = num4.ToString();
                rptRec2.RecNo = str3;
                E5InnerSection e5InnerSection = current[10901] as E5InnerSection;
                string str4 = ((AcpFieldX<int, string>) e5InnerSection.CHE5EmergencyButtonFeature_43768).Converter.Convert((object) e5InnerSection.CHE5EmergencyButtonFeature_43768Value, (Type) null, (object) null, this.ci).ToString();
                this.AddMultiValueByRTL(new bool?(!((FeatureNode) this.refTrunking).Parent.HiddenStatic), new bool?(), str4, str4, ref this.rptFields);
                this.rptFields.UIFieldName = (current as E5Inner).E5InnerSection.CHE5EmergencyButtonName_43766Value.ToString();
                this.rptFields.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("욎햐첒\uDA94얖\uD898햚\uDA9C\uDA9E\uE3A0\uF6A2\uF1A4\uF3A6\uE6A8\uE5AA", A_1), this.ci);
                this.rptRec.UIFields.Add(this.rptFields);
                A_0.RecSet.Add(this.rptRec);
                num2 = (short) 1;
                num3 = (int) (IntPtr) num2;
                continue;
            }
            num2 = (short) 4;
            num3 = (int) (IntPtr) num2;
          }
label_21:
          break;
        }
        finally
        {
label_15:
          short num5 = 1;
          int num6 = (int) (IntPtr) num5;
          while (true)
          {
            switch (num6)
            {
              case 0:
                goto label_22;
              case 1:
                switch (0)
                {
                  case 0:
                    break;
                  default:
                    continue;
                }
                break;
              case 2:
                enumerator.Dispose();
                num5 = (short) 0;
                num6 = (int) (IntPtr) num5;
                continue;
            }
            if (enumerator != null)
            {
              num5 = (short) 2;
              num6 = (int) (IntPtr) num5;
            }
            else
              break;
          }
label_22:
          num5 = (short) 20908;
          int num7 = (int) num5;
          num5 = (short) 20908;
          int num8 = (int) num5;
          switch (num7 == num8 ? 1 : 0)
          {
            case 0:
            case 2:
              goto label_15;
            default:
              num5 = (short) 0;
              if (num5 == (short) 0)
                ;
          }
        }
    }
  }

  private void d(ref _table A_0)
  {
    int A_1 = 17;
    switch (0)
    {
      default:
        short num1 = 2;
        int num2 = (int) (IntPtr) num1;
        while (true)
        {
          IEnumerator<FeatureNode> enumerator;
          switch (num2)
          {
            case 0:
              num1 = (short) 0;
              try
              {
                num1 = (short) 2;
                int num3 = (int) (IntPtr) num1;
                while (true)
                {
                  string str1;
                  E5BottomFunctionButtonInnerSection buttonInnerSection;
                  string str2;
                  string index43759UiValue;
                  switch (num3)
                  {
                    case 0:
                      this.AddFieldValue(ref this.rptFields, str1.ToString());
                      num1 = (short) 9;
                      num3 = (int) (IntPtr) num1;
                      continue;
                    case 1:
                      goto label_48;
                    case 2:
                      switch (0)
                      {
                        case 0:
                          break;
                        default:
                          continue;
                      }
                      break;
                    case 3:
                      if (!buttonInnerSection.E5BottomFunctionButtonIndex_43759_Applicable)
                      {
                        this.AddFieldValue(ref this.rptFields, "");
                        num1 = (short) 19;
                        num3 = (int) (IntPtr) num1;
                        continue;
                      }
                      num1 = (short) 10;
                      num3 = (int) (IntPtr) num1;
                      continue;
                    case 4:
                      num1 = (short) 1;
                      num3 = (int) (IntPtr) num1;
                      continue;
                    case 5:
                      if (string.IsNullOrEmpty(this.rptFields.UIFieldDes))
                      {
                        num1 = (short) 15;
                        num3 = (int) (IntPtr) num1;
                        continue;
                      }
                      goto case 6;
                    case 6:
                      this.rptRec.UIFields.Add(this.rptFields);
                      num1 = (short) 11;
                      num3 = (int) (IntPtr) num1;
                      continue;
                    case 7:
                    case 8:
                    case 19:
                      num1 = (short) 16 /*0x10*/;
                      num3 = (int) (IntPtr) num1;
                      continue;
                    case 9:
                      num1 = (short) 3;
                      num3 = (int) (IntPtr) num1;
                      continue;
                    case 10:
                      str2 = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDD93튕잗쾙튛\uDF9D\uF39F\uF1A1\uEDA3\uE1A5\uE6A7\uEFA9\uE8AB", A_1), Thread.CurrentThread.CurrentCulture);
                      str2 = RptMgrErrorHandler.b("ꢓ", A_1) + str2 + RptMgrErrorHandler.b("ꪓ", A_1);
                      index43759UiValue = buttonInnerSection.E5BottomFunctionButtonIndex_43759_UIValue;
                      num1 = (short) 14;
                      num3 = (int) (IntPtr) num1;
                      continue;
                    case 12:
                      this.rptFields.UIFieldName = ((AcpFieldBase) buttonInnerSection.E5BottomFunctionButtonName_43756).UIName;
                      this.AddUiFieldDescByCondition(ref this.rptFields, buttonInnerSection.E5BottomFunctionButtonName_43756_UIValue, AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDD93튕잗쪙", A_1), Thread.CurrentThread.CurrentCulture), AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDD93튕잗쪙", A_1), this.ci));
                      num1 = (short) 5;
                      num3 = (int) (IntPtr) num1;
                      continue;
                    case 13:
                      if (!enumerator.MoveNext())
                      {
                        num1 = (short) 4;
                        num3 = (int) (IntPtr) num1;
                        continue;
                      }
                      FeatureNode current = enumerator.Current;
                      this.rptFields = new _UIFields();
                      buttonInnerSection = ((IAcpFeatureNode) current)[10904] as E5BottomFunctionButtonInnerSection;
                      int feature43758Value = buttonInnerSection.E5BottomFunctionButtonFeature_43758Value;
                      str1 = ((AcpFieldX<int, string>) buttonInnerSection.E5BottomFunctionButtonFeature_43758).Converter.Convert((object) feature43758Value, (Type) null, (object) null, this.ci).ToString();
                      num1 = (short) 17;
                      num3 = (int) (IntPtr) num1;
                      continue;
                    case 14:
                      if (index43759UiValue == str2)
                      {
                        num1 = (short) 20;
                        num3 = (int) (IntPtr) num1;
                        continue;
                      }
                      this.AddFieldValue(ref this.rptFields, buttonInnerSection.E5BottomFunctionButtonIndex_43759_UIValue);
                      num1 = (short) 7;
                      num3 = (int) (IntPtr) num1;
                      continue;
                    case 15:
                      this.rptFields.UIFieldDes = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("횓秊\uEC97\uEE99\uF39B\uF39Dﾟ\uE0A1톣튥\uDCA7얩슫\uF1AD羚\uF6B1", A_1), this.ci);
                      num1 = (short) 6;
                      num3 = (int) (IntPtr) num1;
                      continue;
                    case 16 /*0x10*/:
                      if (this.isRTL)
                      {
                        num1 = (short) 18;
                        num3 = (int) (IntPtr) num1;
                        continue;
                      }
                      goto case 12;
                    case 17:
                      if (!this.isRTL)
                      {
                        num1 = (short) 0;
                        num3 = (int) (IntPtr) num1;
                        continue;
                      }
                      goto case 9;
                    case 18:
                      this.AddFieldValue(ref this.rptFields, str1.ToString());
                      num1 = (short) 12;
                      num3 = (int) (IntPtr) num1;
                      continue;
                    case 20:
                      index43759UiValue = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDD93튕잗쾙튛\uDF9D\uF39F\uF1A1\uEDA3\uE1A5\uE6A7\uEFA9\uE8AB", A_1), this.ci);
                      this.AddFieldValue(ref this.rptFields, index43759UiValue);
                      num1 = (short) 8;
                      num3 = (int) (IntPtr) num1;
                      continue;
                  }
                  num1 = (short) 13;
                  num3 = (int) (IntPtr) num1;
                }
              }
              finally
              {
label_36:
                short num4 = 1;
                int num5 = (int) (IntPtr) num4;
                while (true)
                {
                  switch (num5)
                  {
                    case 0:
                      goto label_42;
                    case 1:
                      switch (0)
                      {
                        case 0:
                          break;
                        default:
                          continue;
                      }
                      break;
                    case 2:
                      enumerator.Dispose();
                      num4 = (short) 0;
                      num5 = (int) (IntPtr) num4;
                      continue;
                  }
                  if (enumerator != null)
                  {
                    num4 = (short) 2;
                    num5 = (int) (IntPtr) num4;
                  }
                  else
                    break;
                }
label_42:
                num4 = (short) -2235;
                int num6 = (int) num4;
                num4 = (short) -2235;
                int num7 = (int) num4;
                switch (num6 == num7 ? 1 : 0)
                {
                  case 0:
                  case 2:
                    goto label_36;
                  default:
                    num4 = (short) 0;
                    if (num4 == (short) 0)
                      ;
                }
              }
label_48:
              A_0.RecSet.Add(this.rptRec);
              num1 = (short) 1;
              num2 = (int) (IntPtr) num1;
              continue;
            case 1:
              goto label_47;
            case 2:
              switch (0)
              {
                case 0:
                  break;
                default:
                  continue;
              }
              break;
            case 3:
              this.rptRec = new _RecSet();
              int num8 = this.count++;
              this.rptRec.RecTitle = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("횓秊\uEC97\uEE99\uF39B\uF39Dﾟ\uE0A1톣튥\uDCA7얩슫\uDDAD", A_1), this.ci);
              _RecSet rptRec = this.rptRec;
              num8 = this.count;
              string str = num8.ToString();
              rptRec.RecNo = str;
              enumerator = ((Collection<FeatureNode>) this.d).GetEnumerator();
              num1 = (short) 0;
              num2 = (int) (IntPtr) num1;
              continue;
          }
          if (this.d != null)
          {
            num1 = (short) 1;
            if (num1 == (short) 0)
              ;
            num1 = (short) 3;
            num2 = (int) (IntPtr) num1;
          }
          else
            goto label_49;
        }
label_47:
        break;
label_49:
        break;
    }
  }

  private void c(ref _table A_0)
  {
    int A_1 = 19;
    switch (0)
    {
      default:
        short num1 = 1;
        int num2 = (int) (IntPtr) num1;
        IEnumerator<FeatureNode> enumerator;
        while (true)
        {
          switch (num2)
          {
            case 0:
              goto label_7;
            case 1:
              switch (0)
              {
                case 0:
                  break;
                default:
                  continue;
              }
              break;
            case 2:
              enumerator = ((Collection<FeatureNode>) this.e).GetEnumerator();
              num1 = (short) 0;
              num2 = (int) (IntPtr) num1;
              continue;
          }
          num1 = (short) 1;
          if (num1 == (short) 0)
            ;
          num1 = (short) 0;
          if (this.e != null)
          {
            num1 = (short) 2;
            num2 = (int) (IntPtr) num1;
          }
          else
            break;
        }
        break;
label_7:
        try
        {
          num1 = (short) 2;
          int num3 = (int) (IntPtr) num1;
          while (true)
          {
            switch (num3)
            {
              case 0:
                this.rptRec.UIFields.Add(this.rptFields);
                A_0.RecSet.Add(this.rptRec);
                num1 = (short) 5;
                num3 = (int) (IntPtr) num1;
                continue;
              case 1:
                goto label_25;
              case 2:
                switch (0)
                {
                  case 0:
                    break;
                  default:
                    continue;
                }
                break;
              case 3:
                this.rptFields.UIFieldDes = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDF95\uDC97얙\uD99Bꮝ\uE29F\uF7A1\uF0A3\uF2A5\uE7A7\uE4A9", A_1), this.ci);
                num1 = (short) 0;
                num3 = (int) (IntPtr) num1;
                continue;
              case 4:
                if (string.IsNullOrEmpty(this.rptFields.UIFieldDes))
                {
                  num1 = (short) 3;
                  num3 = (int) (IntPtr) num1;
                  continue;
                }
                goto case 0;
              case 6:
                if (!enumerator.MoveNext())
                {
                  num1 = (short) 7;
                  num3 = (int) (IntPtr) num1;
                  continue;
                }
                IAcpFeatureNode current = (IAcpFeatureNode) enumerator.Current;
                this.rptRec = new _RecSet();
                this.rptFields = new _UIFields();
                int num4 = this.count++;
                _RecSet rptRec1 = this.rptRec;
                string noprintId = AppResources.NOPRINT_Id;
                num4 = this.count;
                string str1 = num4.ToString();
                string str2 = noprintId + str1;
                rptRec1.RecTitle = str2;
                _RecSet rptRec2 = this.rptRec;
                num4 = this.count;
                string str3 = num4.ToString();
                rptRec2.RecNo = str3;
                KMButtonInnerSection buttonInnerSection = current[10239] as KMButtonInnerSection;
                int featureA19646Value = buttonInnerSection.RadErgoCfgKMConventionalKMButtonFeature_A19646Value;
                int featureA19746Value = buttonInnerSection.RadErgoCfgKMTrunkingKMButtonFeature_A19746Value;
                string str4 = (string) ((AcpFieldX<int, string>) buttonInnerSection.RadErgoCfgKMConventionalKMButtonFeature_A19646).Converter.Convert((object) featureA19646Value, (Type) null, (object) null, this.ci);
                string str5 = (string) ((AcpFieldX<int, string>) buttonInnerSection.RadErgoCfgKMTrunkingKMButtonFeature_A19746).Converter.Convert((object) featureA19746Value, (Type) null, (object) null, this.ci);
                this.AddMultiValueByRTL(new bool?(!((AcpFieldBase) buttonInnerSection.RadErgoCfgKMTrunkingKMButtonFeature_A19746).HiddenStatic), new bool?(!((AcpFieldBase) buttonInnerSection.RadErgoCfgKMConventionalKMButtonFeature_A19646).HiddenDynamic), str5.ToString(), str4.ToString(), ref this.rptFields);
                this.rptFields.UIFieldName = ((AcpFieldBase) ((KMButtonInner) current).KMButtonInnerSection.RadErgoCfgKMButtonName_A22561).UIName.ToString();
                string uiName = ((KMButtonInner) current).KMButtonInnerSection.RadErgoCfgKMButtonName_A22561_UIValue.ToString();
                this.AddUiFieldDescByCondition(ref this.rptFields, uiName, AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDF95\uDC97얙쾛힝\uE49F\uE7A1\uF0A3\uE9A5\uF8A7\uE8A9嶺節\uE4AFﶱ荒", A_1), Thread.CurrentThread.CurrentCulture), AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDF95\uDC97얙쾛힝\uE49F\uE7A1\uF0A3\uE9A5\uF8A7\uE8A9嶺節\uE4AFﶱ荒", A_1), this.ci));
                this.AddUiFieldDescByCondition(ref this.rptFields, uiName, AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDF95\uDC97얙쾛힝\uE49F\uE7A1\uE9A3\uEFA5\uECA7\uEEA9\uE0AB\uEBAD\uF2AF\uE7B1\uE0B3\uE2B5\uF7B7\uF4B9", A_1), Thread.CurrentThread.CurrentCulture), AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDF95\uDC97얙쾛힝\uE49F\uE7A1\uE9A3\uEFA5\uECA7\uEEA9\uE0AB\uEBAD\uF2AF\uE7B1\uE0B3\uE2B5\uF7B7\uF4B9", A_1), this.ci));
                this.AddUiFieldDescByCondition(ref this.rptFields, uiName, AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDF95\uDC97얙쾛힝\uE49F\uE7A1\uE6A3\uE9A5ﲧﺩ\uE3AB\uE3AD\uF2AF\uE7B1\uE0B3\uE2B5\uF7B7\uF4B9", A_1), Thread.CurrentThread.CurrentCulture), AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDF95\uDC97얙쾛힝\uE49F\uE7A1\uE6A3\uE9A5ﲧﺩ\uE3AB\uE3AD\uF2AF\uE7B1\uE0B3\uE2B5\uF7B7\uF4B9", A_1), this.ci));
                num1 = (short) 4;
                num3 = (int) (IntPtr) num1;
                continue;
              case 7:
                num1 = (short) 1;
                num3 = (int) (IntPtr) num1;
                continue;
            }
            num1 = (short) 6;
            num3 = (int) (IntPtr) num1;
          }
label_25:
          break;
        }
        finally
        {
label_19:
          short num5 = 1;
          int num6 = (int) (IntPtr) num5;
          while (true)
          {
            switch (num6)
            {
              case 0:
                goto label_26;
              case 1:
                switch (0)
                {
                  case 0:
                    break;
                  default:
                    continue;
                }
                break;
              case 2:
                enumerator.Dispose();
                num5 = (short) 0;
                num6 = (int) (IntPtr) num5;
                continue;
            }
            if (enumerator != null)
            {
              num5 = (short) 2;
              num6 = (int) (IntPtr) num5;
            }
            else
              break;
          }
label_26:
          num5 = (short) -3607;
          int num7 = (int) num5;
          num5 = (short) -3607;
          int num8 = (int) num5;
          switch (num7 == num8 ? 1 : 0)
          {
            case 0:
            case 2:
              goto label_19;
            default:
              num5 = (short) 0;
              if (num5 == (short) 0)
                ;
          }
        }
    }
  }

  private void b(ref _table A_0)
  {
    int A_1 = 18;
    switch (0)
    {
      default:
        short num1 = 2;
        int num2 = (int) (IntPtr) num1;
        while (true)
        {
          IEnumerator<FeatureNode> enumerator;
          switch (num2)
          {
            case 0:
              num1 = (short) 0;
              try
              {
                num1 = (short) 0;
                int num3 = (int) (IntPtr) num1;
                while (true)
                {
                  switch (num3)
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
                      num1 = (short) 3;
                      num3 = (int) (IntPtr) num1;
                      continue;
                    case 2:
                      if (enumerator.MoveNext())
                      {
                        FeatureNode current = enumerator.Current;
                        this.rptFields = new _UIFields();
                        E5NavigationControlsTableInnerSection tableInnerSection = ((IAcpFeatureNode) current)[10897] as E5NavigationControlsTableInnerSection;
                        int button43752Value = tableInnerSection.RadErgoControlE5UpDownButton_43752Value;
                        string str = ((AcpFieldX<int, string>) tableInnerSection.RadErgoControlE5UpDownButton_43752).Converter.Convert((object) button43752Value, (Type) null, (object) null, this.ci).ToString();
                        this.AddMultiValueByRTL(new bool?(!((FeatureNode) this.refTrunking).Parent.HiddenStatic), new bool?(), str.ToString(), str.ToString(), ref this.rptFields);
                        this.rptFields.UIFieldName = ((AcpFieldBase) tableInnerSection.RadErgoControlE5UpDownButton_43752).UIName.ToString();
                        string uiName = tableInnerSection.E5UpDownButtonName_43753_UIValue.ToString();
                        this.AddUiFieldDescByCondition(ref this.rptFields, uiName, AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDC94펖욘캚출\uDD9E\uF4A0\uF7A2\uF1A4\uE8A6\uE7A8", A_1), Thread.CurrentThread.CurrentCulture), AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDC94펖욘캚출\uDD9E\uF4A0\uF7A2\uF1A4\uE8A6\uE7A8", A_1), this.ci));
                        this.AddUiFieldDescByCondition(ref this.rptFields, uiName, AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("톔\uF896\uEE98\uF59A슜\uDD9E풠힢톤좦잨", A_1), Thread.CurrentThread.CurrentCulture), AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("톔\uF896\uEE98\uF59A슜\uDD9E풠힢톤좦잨", A_1), this.ci));
                        this.rptRec.UIFields.Add(this.rptFields);
                        num1 = (short) 4;
                        num3 = (int) (IntPtr) num1;
                        continue;
                      }
                      num1 = (short) 1;
                      num3 = (int) (IntPtr) num1;
                      continue;
                    case 3:
                      goto label_27;
                  }
                  num1 = (short) 2;
                  num3 = (int) (IntPtr) num1;
                }
              }
              finally
              {
label_14:
                short num4 = 1;
                int num5 = (int) (IntPtr) num4;
                while (true)
                {
                  switch (num5)
                  {
                    case 0:
                      goto label_21;
                    case 1:
                      switch (0)
                      {
                        case 0:
                          break;
                        default:
                          continue;
                      }
                      break;
                    case 2:
                      num4 = (short) 1;
                      if (num4 == (short) 0)
                        ;
                      enumerator.Dispose();
                      num4 = (short) 0;
                      num5 = (int) (IntPtr) num4;
                      continue;
                  }
                  if (enumerator != null)
                  {
                    num4 = (short) 2;
                    num5 = (int) (IntPtr) num4;
                  }
                  else
                    break;
                }
label_21:
                num4 = (short) 785;
                int num6 = (int) num4;
                num4 = (short) 785;
                int num7 = (int) num4;
                switch (num6 == num7 ? 1 : 0)
                {
                  case 0:
                  case 2:
                    goto label_14;
                  default:
                    num4 = (short) 0;
                    if (num4 == (short) 0)
                      ;
                }
              }
label_27:
              A_0.RecSet.Add(this.rptRec);
              num1 = (short) 1;
              num2 = (int) (IntPtr) num1;
              continue;
            case 1:
              goto label_26;
            case 2:
              switch (0)
              {
                case 0:
                  break;
                default:
                  continue;
              }
              break;
            case 3:
              this.rptRec = new _RecSet();
              int num8 = this.count++;
              this.rptRec.RecTitle = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDC94펖욘햚\uDC9C즞\uE8A0\uE4A2\uE4A4\uF3A6\uE0A8\uE4AA\uE3AC\uECAEﺰﶲ\uE1B4\uE5B6\uF6B8\uF7BA\uEEBC", A_1), this.ci);
              _RecSet rptRec = this.rptRec;
              num8 = this.count;
              string str1 = num8.ToString();
              rptRec.RecNo = str1;
              enumerator = ((Collection<FeatureNode>) this.b).GetEnumerator();
              num1 = (short) 0;
              num2 = (int) (IntPtr) num1;
              continue;
          }
          if (this.b != null)
          {
            num1 = (short) 3;
            num2 = (int) (IntPtr) num1;
          }
          else
            goto label_28;
        }
label_26:
        break;
label_28:
        break;
    }
  }

  private void a(ref _table A_0)
  {
    int A_1 = 12;
    switch (0)
    {
      default:
        short num1 = 20763;
        int num2 = (int) num1;
        num1 = (short) 20763;
        int num3 = (int) num1;
        int num4;
        string str1;
        string indexA41424UiValue;
        IAcpFeatureNode iacpFeatureNode;
        DataButtonInnerSection buttonInnerSection;
        string str2;
        string indexA41423UiValue;
        switch (num2 == num3 ? 1 : 0)
        {
          case 0:
          case 2:
label_13:
            this.rptRec = new _RecSet();
            this.rptFields = new _UIFields();
            ++this.count;
            this.rptRec.RecTitle = AppResources.NOPRINT_Id + this.count.ToString();
            this.rptRec.RecNo = this.count.ToString();
            iacpFeatureNode = ((Recordset) this.g)[0];
            buttonInnerSection = iacpFeatureNode[10209] as DataButtonInnerSection;
            int featureA22603Value = buttonInnerSection.RadErgoCfgKMConventionalKMDatatButtonFeature_A22603Value;
            int featureA22605Value = buttonInnerSection.RadErgoCfgKMTrunkingKMDatatButtonFeature_A22605Value;
            str2 = (string) ((AcpFieldX<int, string>) buttonInnerSection.RadErgoCfgKMConventionalKMDatatButtonFeature_A22603).Converter.Convert((object) featureA22603Value, (Type) null, (object) null, this.ci);
            str1 = (string) ((AcpFieldX<int, string>) buttonInnerSection.RadErgoCfgKMTrunkingKMDatatButtonFeature_A22605).Converter.Convert((object) featureA22605Value, (Type) null, (object) null, this.ci);
            indexA41423UiValue = buttonInnerSection.RadErgoCfgKMConventionalKMDatatButtonIndex_A41423_UIValue;
            indexA41424UiValue = buttonInnerSection.RadErgoCfgKMTrunkingKMDatatButtonIndex_A41424_UIValue;
            num1 = (short) 0;
            num4 = (int) (IntPtr) num1;
            break;
          default:
            num1 = (short) 0;
            num1 = (short) 0;
            if (num1 == (short) 0)
              ;
            num1 = (short) 3;
            num4 = (int) (IntPtr) num1;
            break;
        }
        while (true)
        {
          switch (num4)
          {
            case 0:
              if (str2 == AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("욎햐첒풔풖춘튚튜톞\uE2A0\uECA2\uEBA4\uF4A6\uE6A8\uE7AA\uE4AC\uEBAE\uF0B0\uE7B2ﲴ\uF8B6\uF7B8", A_1), this.ci))
              {
                num1 = (short) 6;
                num4 = (int) (IntPtr) num1;
                continue;
              }
              goto case 4;
            case 1:
              goto label_17;
            case 2:
              goto label_13;
            case 3:
              num1 = (short) 1;
              if (num1 == (short) 0)
                ;
              switch (0)
              {
                case 0:
                  break;
                default:
                  continue;
              }
              break;
            case 4:
              num1 = (short) 8;
              num4 = (int) (IntPtr) num1;
              continue;
            case 5:
              str1 = str1 + this.indexSeparator + indexA41424UiValue;
              num1 = (short) 7;
              num4 = (int) (IntPtr) num1;
              continue;
            case 6:
              str2 = str2 + this.indexSeparator + indexA41423UiValue;
              num1 = (short) 4;
              num4 = (int) (IntPtr) num1;
              continue;
            case 7:
              this.AddMultiValueByRTL(new bool?(!((AcpFieldBase) buttonInnerSection.RadErgoCfgKMTrunkingKMDatatButtonFeature_A22605).HiddenStatic), new bool?(!((AcpFieldBase) buttonInnerSection.RadErgoCfgKMConventionalKMDatatButtonFeature_A22603).HiddenStatic), str1.ToString(), str2.ToString(), ref this.rptFields);
              this.rptFields.UIFieldName = ((AcpFieldBase) (iacpFeatureNode[10209] as DataButtonInnerSection).RadErgoCfgKMDataButtonName_A22601).UIName.ToString();
              this.rptFields.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("욎햐첒톔횖춘\uDA9A\uDF9C쪞\uF5A0\uF7A2\uEAA4\uE9A6\uF6A8骪", A_1), this.ci);
              this.rptRec.UIFields.Add(this.rptFields);
              A_0.RecSet.Add(this.rptRec);
              num1 = (short) 1;
              num4 = (int) (IntPtr) num1;
              continue;
            case 8:
              if (str1 == AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("욎햐첒풔풖춘튚튜톞\uE2A0\uECA2\uEBA4\uF4A6\uE6A8\uE7AA\uE4AC\uEBAE\uF0B0\uE7B2ﲴ\uF8B6\uF7B8", A_1), this.ci))
              {
                num1 = (short) 5;
                num4 = (int) (IntPtr) num1;
                continue;
              }
              goto case 7;
          }
          if (this.g != null)
          {
            num1 = (short) 2;
            num4 = (int) (IntPtr) num1;
          }
          else
            goto label_19;
        }
label_17:
        break;
label_19:
        break;
    }
  }

  public override void BuildDataTables(ref _XMLData XMLRptDataObj)
  {
label_0:
    int num1;
    short num2;
    switch (0)
    {
      case 0:
label_2:
        this.AddGeneral(ref XMLRptDataObj);
        this.rptTable = new _table();
        this.acpr = new AcpReports();
        this.CreateTableHeader(ref this.rptTable);
        num2 = (short) 12998;
        int num3 = (int) num2;
        num2 = (short) 12998;
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
            goto label_1;
        }
      default:
        while (true)
        {
          switch (num1)
          {
            case 0:
              goto label_8;
            case 1:
              if (UtilityMack.IsMobile())
              {
                num2 = (short) 2;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_8;
            case 2:
              num2 = (short) 0;
              this.e(ref this.rptTable);
              this.d(ref this.rptTable);
              this.c(ref this.rptTable);
              this.b(ref this.rptTable);
              this.a(ref this.rptTable);
              this.AddKeypadButton(ref this.rptTable);
              num2 = (short) 0;
              num1 = (int) (IntPtr) num2;
              continue;
            default:
              goto label_2;
          }
label_1:;
        }
label_8:
        num2 = (short) 1;
        if (num2 == (short) 0)
          ;
        XMLRptDataObj.tables.Add(this.rptTable);
        this.AddZonesAndChannels(ref XMLRptDataObj);
        break;
    }
  }
}
