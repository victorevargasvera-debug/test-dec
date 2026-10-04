// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.ACPXMLCoreEngineLib.O5XMLCoreEngine
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using AcpBusinessLayer;
using AcpCommonLib;
using CommonResources;
using ConstraintHelper;
using Motorola.MackinawCPS.CoreFeatures.ControlHeadO5;
using Motorola.MackinawCPS.CoreFeatures.KeypadMicAndAccessories;
using SpecialFeatures.AcpReportManagerLib;
using SpecialFeatures.AcpXMLCoreEngineLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;

#nullable disable
namespace SpecialFeatures.ACPXMLCoreEngineLib;

public class O5XMLCoreEngine : BaseHandOutXMLCoreEngine
{
  private Motorola.MackinawCPS.CoreFeatures.ControlHeadO5.ControlHeadO5 a;
  private Motorola.MackinawCPS.CoreFeatures.KeypadMicAndAccessories.KeypadMicAndAccessories b;
  private O5InnerRecset c;
  private KMButtonInnerRecset d;
  private DataButtonInnerRecset e;
  private ControlHeadO5Recset f;
  private O5NavigationControlsTableInnerRecset g;
  private KeypadMicAndAccessoriesRecset h;

  public O5XMLCoreEngine()
  {
    this.a = FeatureManager.GetFeature(2130)[0] as Motorola.MackinawCPS.CoreFeatures.ControlHeadO5.ControlHeadO5;
    this.b = FeatureManager.GetFeature(2128)[0] as Motorola.MackinawCPS.CoreFeatures.KeypadMicAndAccessories.KeypadMicAndAccessories;
    this.f = FeatureManager.GetFeature(2130) as ControlHeadO5Recset;
    if (this.f != null)
      goto label_4;
label_3:
    this.h = FeatureManager.GetFeature(2128) as KeypadMicAndAccessoriesRecset;
    if (this.h == null)
      return;
    this.d = ((Recordset) this.h)[0][10231].EmbeddedRecset as KMButtonInnerRecset;
    this.e = ((Recordset) this.h)[0][10228].EmbeddedRecset as DataButtonInnerRecset;
    return;
label_4:
    this.c = ((Recordset) this.f)[0][10227].EmbeddedRecset as O5InnerRecset;
    this.g = ((Recordset) this.f)[0][10735].EmbeddedRecset as O5NavigationControlsTableInnerRecset;
    goto label_3;
  }

  private void d(ref _table A_0)
  {
    int A_1 = 1;
    switch (0)
    {
      default:
        int num1 = 2;
        short num2;
        IEnumerator<FeatureNode> enumerator;
        while (true)
        {
          num2 = (short) 0;
          switch (num1)
          {
            case 0:
              enumerator = ((Collection<FeatureNode>) this.c).GetEnumerator();
              num2 = (short) 1;
              num1 = (int) (IntPtr) num2;
              continue;
            case 1:
              goto label_6;
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
          if (this.c != null)
          {
            num2 = (short) 0;
            num1 = (int) (IntPtr) num2;
          }
          else
            break;
        }
        break;
label_6:
        try
        {
          num2 = (short) 4;
          int num3 = (int) (IntPtr) num2;
          while (true)
          {
            switch (num3)
            {
              case 0:
                num2 = (short) -29397;
                int num4 = (int) num2;
                num2 = (short) -29397;
                int num5 = (int) num2;
                switch (num4 == num5 ? 1 : 0)
                {
                  case 0:
                  case 2:
                    break;
                  default:
                    num2 = (short) 0;
                    if (num2 == (short) 0)
                      ;
                    if (!enumerator.MoveNext())
                    {
                      num2 = (short) 1;
                      num3 = (int) (IntPtr) num2;
                      continue;
                    }
                    IAcpFeatureNode current = (IAcpFeatureNode) enumerator.Current;
                    this.rptRec = new _RecSet();
                    this.rptFields = new _UIFields();
                    ++this.count;
                    this.rptRec.RecTitle = AppResources.NOPRINT_Id + this.count.ToString();
                    this.rptRec.RecNo = this.count.ToString();
                    O5InnerSection o5InnerSection = current[10211] as O5InnerSection;
                    string str = (string) ((AcpFieldX<int, string>) o5InnerSection.CntrlHeadO5SignalIndependentO5M5MXChiefCHButtonButtonFeature_A19754).Converter.Convert((object) o5InnerSection.CntrlHeadO5SignalIndependentO5M5MXChiefCHButtonButtonFeature_A19754Value, (Type) null, (object) null, this.ci);
                    this.AddMultiValueByRTL(new bool?(!((FeatureNode) this.refTrunking).Parent.HiddenStatic), new bool?(), str.ToString(), str.ToString(), ref this.rptFields);
                    this.rptFields.UIFieldName = ((AcpFieldBase) ((O5Inner) current).O5InnerSection.CntrlHeadO5SignalIndependentO5M5MXChiefCHButtonName_A22520).UIName.ToString();
                    this.rptFields.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("춃슅힇얉\uDE8B쾍\uDE8F햑톓풕춗캙좛톝\uEE9F", A_1), this.ci);
                    this.rptRec.UIFields.Add(this.rptFields);
                    A_0.RecSet.Add(this.rptRec);
                    num2 = (short) 2;
                    num3 = (int) (IntPtr) num2;
                    continue;
                }
                break;
              case 1:
                num2 = (short) 3;
                num3 = (int) (IntPtr) num2;
                continue;
              case 3:
                goto label_23;
              case 4:
                switch (0)
                {
                  case 0:
                    break;
                  default:
                    continue;
                }
                break;
            }
            num2 = (short) 0;
            num3 = (int) (IntPtr) num2;
          }
label_23:
          break;
        }
        finally
        {
          int num6 = 2;
          while (true)
          {
            switch (num6)
            {
              case 0:
                if (false)
                  ;
                enumerator.Dispose();
                num6 = 1;
                continue;
              case 1:
                goto label_24;
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
              num6 = 0;
            else
              break;
          }
label_24:;
        }
    }
  }

  private void c(ref _table A_0)
  {
    int A_1 = 12;
    switch (0)
    {
      default:
        int num1 = 2;
        short num2;
        IEnumerator<FeatureNode> enumerator;
        while (true)
        {
          num2 = (short) 1;
          if (num2 == (short) 0)
            ;
          switch (num1)
          {
            case 0:
              enumerator = ((Collection<FeatureNode>) this.d).GetEnumerator();
              num2 = (short) 1;
              num1 = (int) (IntPtr) num2;
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
          if (this.d != null)
          {
            num2 = (short) 0;
            num1 = (int) (IntPtr) num2;
          }
          else
            break;
        }
        break;
label_30:
        num2 = (short) 0;
        try
        {
          num2 = (short) 4;
          int num3 = (int) (IntPtr) num2;
          while (true)
          {
            switch (num3)
            {
              case 0:
                num2 = (short) 6;
                num3 = (int) (IntPtr) num2;
                continue;
              case 2:
label_19:
                this.rptFields.UIFieldDes = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("욎햐첒\uDA94ꊖ\uDB98캚즜쮞\uEEA0\uEDA2", A_1), this.ci);
                num2 = (short) 5;
                num3 = (int) (IntPtr) num2;
                continue;
              case 3:
                if (string.IsNullOrEmpty(this.rptFields.UIFieldDes))
                {
                  num2 = (short) 2;
                  num3 = (int) (IntPtr) num2;
                  continue;
                }
                goto case 5;
              case 4:
                switch (0)
                {
                  case 0:
                    break;
                  default:
                    continue;
                }
                break;
              case 5:
                this.rptRec.UIFields.Add(this.rptFields);
                A_0.RecSet.Add(this.rptRec);
                num2 = (short) 24019;
                int num4 = (int) num2;
                num2 = (short) 24019;
                int num5 = (int) num2;
                switch (num4 == num5 ? 1 : 0)
                {
                  case 0:
                  case 2:
                    goto label_19;
                  default:
                    num2 = (short) 0;
                    if (num2 == (short) 0)
                      ;
                    num2 = (short) 1;
                    num3 = (int) (IntPtr) num2;
                    continue;
                }
              case 6:
                goto label_29;
              case 7:
                if (!enumerator.MoveNext())
                {
                  num2 = (short) 0;
                  num3 = (int) (IntPtr) num2;
                  continue;
                }
                IAcpFeatureNode current = (IAcpFeatureNode) enumerator.Current;
                this.rptRec = new _RecSet();
                this.rptFields = new _UIFields();
                int num6 = this.count++;
                _RecSet rptRec1 = this.rptRec;
                string noprintId = AppResources.NOPRINT_Id;
                num6 = this.count;
                string str1 = num6.ToString();
                string str2 = noprintId + str1;
                rptRec1.RecTitle = str2;
                _RecSet rptRec2 = this.rptRec;
                num6 = this.count;
                string str3 = num6.ToString();
                rptRec2.RecNo = str3;
                KMButtonInnerSection buttonInnerSection = current[10239] as KMButtonInnerSection;
                int featureA19646Value = buttonInnerSection.RadErgoCfgKMConventionalKMButtonFeature_A19646Value;
                int featureA19746Value = buttonInnerSection.RadErgoCfgKMTrunkingKMButtonFeature_A19746Value;
                string str4 = (string) ((AcpFieldX<int, string>) buttonInnerSection.RadErgoCfgKMConventionalKMButtonFeature_A19646).Converter.Convert((object) featureA19646Value, (Type) null, (object) null, this.ci);
                string str5 = (string) ((AcpFieldX<int, string>) buttonInnerSection.RadErgoCfgKMTrunkingKMButtonFeature_A19746).Converter.Convert((object) featureA19746Value, (Type) null, (object) null, this.ci);
                this.AddMultiValueByRTL(new bool?(!((AcpFieldBase) buttonInnerSection.RadErgoCfgKMTrunkingKMButtonFeature_A19746).HiddenStatic), new bool?(!((AcpFieldBase) buttonInnerSection.RadErgoCfgKMConventionalKMButtonFeature_A19646).HiddenDynamic), str5.ToString(), str4.ToString(), ref this.rptFields);
                this.rptFields.UIFieldName = ((AcpFieldBase) ((KMButtonInner) current).KMButtonInnerSection.RadErgoCfgKMButtonName_A22561).UIName.ToString();
                string uiName = ((KMButtonInner) current).KMButtonInnerSection.RadErgoCfgKMButtonName_A22561_UIValue.ToString();
                this.AddUiFieldDescByCondition(ref this.rptFields, uiName, AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("욎햐첒요\uDE96\uDD98\uDE9A즜킞\uF1A0\uE1A2\uF0A4\uF3A6ﶨ\uE4AA\uE3AC", A_1), Thread.CurrentThread.CurrentCulture), AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("욎햐첒요\uDE96\uDD98\uDE9A즜킞\uF1A0\uE1A2\uF0A4\uF3A6ﶨ\uE4AA\uE3AC", A_1), this.ci));
                this.AddUiFieldDescByCondition(ref this.rptFields, uiName, AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("욎햐첒요\uDE96\uDD98\uDE9A킜횞\uE5A0\uE7A2\uE9A4\uE2A6\uEBA8ﺪ怜ﮮﺰﶲ", A_1), Thread.CurrentThread.CurrentCulture), AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("욎햐첒요\uDE96\uDD98\uDE9A킜횞\uE5A0\uE7A2\uE9A4\uE2A6\uEBA8ﺪ怜ﮮﺰﶲ", A_1), this.ci));
                this.AddUiFieldDescByCondition(ref this.rptFields, uiName, AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("욎햐첒요\uDE96\uDD98\uDE9A\uDF9C킞\uF5A0\uF7A2\uEAA4\uEAA6\uEBA8ﺪ怜ﮮﺰﶲ", A_1), Thread.CurrentThread.CurrentCulture), AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("욎햐첒요\uDE96\uDD98\uDE9A\uDF9C킞\uF5A0\uF7A2\uEAA4\uEAA6\uEBA8ﺪ怜ﮮﺰﶲ", A_1), this.ci));
                num2 = (short) 3;
                num3 = (int) (IntPtr) num2;
                continue;
            }
            num2 = (short) 7;
            num3 = (int) (IntPtr) num2;
          }
label_29:
          break;
        }
        finally
        {
          short num7 = 2;
          int num8 = (int) (IntPtr) num7;
          while (true)
          {
            switch (num8)
            {
              case 0:
                enumerator.Dispose();
                num7 = (short) 1;
                num8 = (int) (IntPtr) num7;
                continue;
              case 1:
                goto label_27;
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
              num7 = (short) 0;
              num8 = (int) (IntPtr) num7;
            }
            else
              break;
          }
label_27:;
        }
    }
  }

  private void b(ref _table A_0)
  {
    int A_1 = 9;
    switch (0)
    {
      default:
        int num1 = 3;
        while (true)
        {
          short num2;
          IEnumerator<FeatureNode> enumerator;
          switch (num1)
          {
            case 0:
              this.rptRec = new _RecSet();
              ++this.count;
              this.rptRec.RecTitle = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("얋쪍쾏\uDC91햓삕톗\uDD99\uDD9B쪝\uE99F\uEDA1\uEAA3\uE5A5\uE7A7\uE4A9\uF8ABﲭﾯﺱ\uE7B3", A_1), this.ci);
              this.rptRec.RecNo = this.count.ToString();
              enumerator = ((Collection<FeatureNode>) this.g).GetEnumerator();
              num2 = (short) 1;
              num1 = (int) (IntPtr) num2;
              continue;
            case 1:
              try
              {
                num2 = (short) 4;
                int num3 = (int) (IntPtr) num2;
                while (true)
                {
                  switch (num3)
                  {
                    case 1:
                      if (enumerator.MoveNext())
                      {
label_9:
                        FeatureNode current = enumerator.Current;
                        this.rptFields = new _UIFields();
                        O5NavigationControlsTableInnerSection tableInnerSection = ((IAcpFeatureNode) current)[10736] as O5NavigationControlsTableInnerSection;
                        int featureA41379Value = tableInnerSection.RadErgoControlO5NaviControlFeature_A41379Value;
                        string str = (string) ((AcpFieldX<int, string>) tableInnerSection.RadErgoControlO5NaviControlFeature_A41379).Converter.Convert((object) featureA41379Value, (Type) null, (object) null, this.ci);
                        this.AddMultiValueByRTL(new bool?(!((FeatureNode) this.refTrunking).Parent.HiddenStatic), new bool?(), str.ToString(), str.ToString(), ref this.rptFields);
                        this.rptFields.UIFieldName = ((AcpFieldBase) tableInnerSection.RadErgoControlO5NaviControlName_A41378).UIName.ToString();
                        string uiName = tableInnerSection.RadErgoControlO5NaviControlName_A41378_UIValue.ToString();
                        this.AddUiFieldDescByCondition(ref this.rptFields, uiName, AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("얋쪍쾏작쒓풕춗캙좛톝\uEE9F", A_1), Thread.CurrentThread.CurrentCulture), AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("얋쪍쾏작쒓풕춗캙좛톝\uEE9F", A_1), this.ci));
                        this.AddUiFieldDescByCondition(ref this.rptFields, uiName, AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("좋\uE18D\uE78Fﲑ쮓풕\uED97\uEE99\uE89B\uF19D캟", A_1), Thread.CurrentThread.CurrentCulture), AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("좋\uE18D\uE78Fﲑ쮓풕\uED97\uEE99\uE89B\uF19D캟", A_1), this.ci));
                        this.rptRec.UIFields.Add(this.rptFields);
                        num2 = (short) -12510;
                        int num4 = (int) num2;
                        num2 = (short) -12510;
                        int num5 = (int) num2;
                        switch (num4 == num5 ? 1 : 0)
                        {
                          case 0:
                          case 2:
                            goto label_9;
                          default:
                            num2 = (short) 1;
                            if (num2 == (short) 0)
                              ;
                            num2 = (short) 0;
                            if (num2 == (short) 0)
                              ;
                            num2 = (short) 0;
                            num3 = (int) (IntPtr) num2;
                            continue;
                        }
                      }
                      else
                      {
                        num2 = (short) 2;
                        num3 = (int) (IntPtr) num2;
                        continue;
                      }
                    case 2:
                      num2 = (short) 3;
                      num3 = (int) (IntPtr) num2;
                      continue;
                    case 3:
                      goto label_26;
                    case 4:
                      switch (0)
                      {
                        case 0:
                          break;
                        default:
                          continue;
                      }
                      break;
                  }
                  num2 = (short) 1;
                  num3 = (int) (IntPtr) num2;
                }
              }
              finally
              {
                int num6 = 2;
                while (true)
                {
                  switch (num6)
                  {
                    case 0:
                      enumerator.Dispose();
                      num6 = 1;
                      continue;
                    case 1:
                      goto label_23;
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
                    num6 = 0;
                  else
                    break;
                }
label_23:;
              }
label_26:
              A_0.RecSet.Add(this.rptRec);
              num2 = (short) 2;
              num1 = (int) (IntPtr) num2;
              continue;
            case 2:
              goto label_25;
            case 3:
              switch (0)
              {
                case 0:
                  break;
                default:
                  continue;
              }
              break;
          }
          if (this.g != null)
          {
            num2 = (short) 0;
            num2 = (short) 0;
            num1 = (int) (IntPtr) num2;
          }
          else
            goto label_27;
        }
label_25:
        break;
label_27:
        break;
    }
  }

  private void a(ref _table A_0)
  {
    int A_1 = 1;
    switch (0)
    {
      default:
        int num1 = 3;
        short num2;
        while (true)
        {
          string str1;
          string indexA41424UiValue;
          IAcpFeatureNode iacpFeatureNode;
          DataButtonInnerSection buttonInnerSection;
          string str2;
          string indexA41423UiValue;
          switch (num1)
          {
            case 0:
              this.rptRec = new _RecSet();
              this.rptFields = new _UIFields();
              int num3 = this.count++;
              _RecSet rptRec1 = this.rptRec;
              string noprintId = AppResources.NOPRINT_Id;
              num3 = this.count;
              string str3 = num3.ToString();
              string str4 = noprintId + str3;
              rptRec1.RecTitle = str4;
              _RecSet rptRec2 = this.rptRec;
              num3 = this.count;
              string str5 = num3.ToString();
              rptRec2.RecNo = str5;
              iacpFeatureNode = ((Recordset) this.e)[0];
              buttonInnerSection = iacpFeatureNode[10209] as DataButtonInnerSection;
              int featureA22603Value = buttonInnerSection.RadErgoCfgKMConventionalKMDatatButtonFeature_A22603Value;
              int featureA22605Value = buttonInnerSection.RadErgoCfgKMTrunkingKMDatatButtonFeature_A22605Value;
              str2 = (string) ((AcpFieldX<int, string>) buttonInnerSection.RadErgoCfgKMConventionalKMDatatButtonFeature_A22603).Converter.Convert((object) featureA22603Value, (Type) null, (object) null, this.ci);
              str1 = (string) ((AcpFieldX<int, string>) buttonInnerSection.RadErgoCfgKMTrunkingKMDatatButtonFeature_A22605).Converter.Convert((object) featureA22605Value, (Type) null, (object) null, this.ci);
              indexA41423UiValue = buttonInnerSection.RadErgoCfgKMConventionalKMDatatButtonIndex_A41423_UIValue;
              indexA41424UiValue = buttonInnerSection.RadErgoCfgKMTrunkingKMDatatButtonIndex_A41424_UIValue;
              num2 = (short) 1;
              num1 = (int) (IntPtr) num2;
              continue;
            case 1:
              if (str2 == AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("춃슅힇쮉쾋\uDA8D\uD98F\uDD91\uDA93햕힗풙쾛톝\uEC9F\uEBA1\uE0A3\uE7A5ﲧ\uE3A9\uE3AB\uE0AD", A_1), this.ci))
              {
                num2 = (short) 5;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 4;
            case 2:
              this.AddMultiValueByRTL(new bool?(!((AcpFieldBase) buttonInnerSection.RadErgoCfgKMTrunkingKMDatatButtonFeature_A22605).HiddenStatic), new bool?(!((AcpFieldBase) buttonInnerSection.RadErgoCfgKMConventionalKMDatatButtonFeature_A22603).HiddenStatic), str1.ToString(), str2.ToString(), ref this.rptFields);
              this.rptFields.UIFieldName = ((AcpFieldBase) (iacpFeatureNode[10209] as DataButtonInnerSection).RadErgoCfgKMDataButtonName_A22601).UIName.ToString();
              this.rptFields.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("춃슅힇캉춋\uDA8D톏킑솓슕첗햙튛솝醟", A_1), this.ci);
              this.rptRec.UIFields.Add(this.rptFields);
              A_0.RecSet.Add(this.rptRec);
              num2 = (short) 7;
              num1 = (int) (IntPtr) num2;
              continue;
            case 3:
              switch (0)
              {
                case 0:
                  goto label_4;
                default:
                  continue;
              }
            case 4:
              num2 = (short) 6;
              num1 = (int) (IntPtr) num2;
              continue;
            case 5:
              str2 = str2 + this.indexSeparator + indexA41423UiValue;
              break;
            case 6:
              if (str1 == AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("춃슅힇쮉쾋\uDA8D\uD98F\uDD91\uDA93햕힗풙쾛톝\uEC9F\uEBA1\uE0A3\uE7A5ﲧ\uE3A9\uE3AB\uE0AD", A_1), this.ci))
              {
                num2 = (short) 8;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 2;
            case 7:
              goto label_19;
            case 8:
              str1 = str1 + this.indexSeparator + indexA41424UiValue;
              num2 = (short) -11281;
              int num4 = (int) num2;
              num2 = (short) -11281;
              int num5 = (int) num2;
              switch (num4 == num5 ? 1 : 0)
              {
                case 0:
                case 2:
                  break;
                default:
                  num2 = (short) 1;
                  if (num2 == (short) 0)
                    ;
                  num2 = (short) 0;
                  if (num2 == (short) 0)
                    ;
                  num2 = (short) 2;
                  num1 = (int) (IntPtr) num2;
                  continue;
              }
              break;
            default:
label_4:
              if (this.e != null)
              {
                num2 = (short) 0;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_19;
          }
          num2 = (short) 4;
          num1 = (int) (IntPtr) num2;
        }
label_19:
        num2 = (short) 0;
        break;
    }
  }

  public override void BuildDataTables(ref _XMLData XMLRptDataObj)
  {
    int num1;
    short num2;
    switch (0)
    {
      case 0:
label_2:
        num2 = (short) 0;
        this.AddGeneral(ref XMLRptDataObj);
        this.rptTable = new _table();
        this.acpr = new AcpReports();
        this.CreateTableHeader(ref this.rptTable);
        num2 = (short) 0;
        num1 = (int) (IntPtr) num2;
        goto default;
      default:
        while (true)
        {
          switch (num1)
          {
            case 0:
              if (UtilityMack.IsMobile())
              {
                num2 = (short) 2;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_9;
            case 1:
              goto label_9;
            case 2:
              num2 = (short) -1559;
              int num3 = (int) num2;
              num2 = (short) -1559;
              int num4 = (int) num2;
              switch (num3 == num4 ? 1 : 0)
              {
                case 0:
                case 2:
                  goto label_2;
                default:
                  num2 = (short) 1;
                  if (num2 == (short) 0)
                    ;
                  num2 = (short) 0;
                  if (num2 == (short) 0)
                    ;
                  this.d(ref this.rptTable);
                  this.c(ref this.rptTable);
                  this.b(ref this.rptTable);
                  this.a(ref this.rptTable);
                  this.AddKeypadButton(ref this.rptTable);
                  num2 = (short) 1;
                  num1 = (int) (IntPtr) num2;
                  continue;
              }
            default:
              goto label_2;
          }
        }
label_9:
        XMLRptDataObj.tables.Add(this.rptTable);
        this.AddZonesAndChannels(ref XMLRptDataObj);
        break;
    }
  }
}
