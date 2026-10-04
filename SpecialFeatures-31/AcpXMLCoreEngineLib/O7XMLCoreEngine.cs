// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.ACPXMLCoreEngineLib.O7XMLCoreEngine
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using AcpBusinessLayer;
using AcpCommonLib;
using CommonResources;
using ConstraintHelper;
using Motorola.MackinawCPS.CoreFeatures.ControlHeadO7;
using Motorola.MackinawCPS.CoreFeatures.KeypadMicAndAccessories;
using SpecialFeatures.AcpReportManagerLib;
using SpecialFeatures.AcpXMLCoreEngineLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;

#nullable disable
namespace SpecialFeatures.ACPXMLCoreEngineLib;

public class O7XMLCoreEngine : BaseHandOutXMLCoreEngine
{
  private Motorola.MackinawCPS.CoreFeatures.ControlHeadO7.ControlHeadO7 a;
  private Motorola.MackinawCPS.CoreFeatures.KeypadMicAndAccessories.KeypadMicAndAccessories b;
  private O7InnerRecset c;
  private KMButtonInnerRecset d;
  private O7DataButtonInnerRecset e;
  private ControlHeadO7Recset f;
  private O7NavigationControlsTableInnerRecset g;
  private KeypadMicAndAccessoriesRecset h;

  public O7XMLCoreEngine()
  {
    this.a = FeatureManager.GetFeature(4114)[0] as Motorola.MackinawCPS.CoreFeatures.ControlHeadO7.ControlHeadO7;
    this.b = FeatureManager.GetFeature(2128)[0] as Motorola.MackinawCPS.CoreFeatures.KeypadMicAndAccessories.KeypadMicAndAccessories;
    this.f = FeatureManager.GetFeature(4114) as ControlHeadO7Recset;
    if (this.f != null)
      goto label_4;
label_3:
    this.h = FeatureManager.GetFeature(2128) as KeypadMicAndAccessoriesRecset;
    if (this.h == null)
      return;
    this.d = ((Recordset) this.h)[0][10231].EmbeddedRecset as KMButtonInnerRecset;
    return;
label_4:
    this.c = ((Recordset) this.f)[0][10719].EmbeddedRecset as O7InnerRecset;
    this.g = ((Recordset) this.f)[0][10727].EmbeddedRecset as O7NavigationControlsTableInnerRecset;
    this.e = ((Recordset) this.f)[0][10717].EmbeddedRecset as O7DataButtonInnerRecset;
    goto label_3;
  }

  private void e(ref _table A_0)
  {
    int A_1 = 13;
    switch (0)
    {
      default:
        int num1 = 0;
        short num2;
        IEnumerator<FeatureNode> enumerator;
        while (true)
        {
          switch (num1)
          {
            case 0:
label_2:
              num2 = (short) 0;
              switch (0)
              {
                case 0:
                  break;
                default:
                  continue;
              }
              break;
            case 1:
              goto label_6;
            case 2:
              num2 = (short) -20906;
              int num3 = (int) num2;
              num2 = (short) -20906;
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
                  enumerator = ((Collection<FeatureNode>) this.c).GetEnumerator();
                  num2 = (short) 1;
                  num1 = (int) (IntPtr) num2;
                  continue;
              }
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
          int num5 = (int) (IntPtr) num2;
          while (true)
          {
            switch (num5)
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
                goto label_20;
              case 2:
                if (!enumerator.MoveNext())
                {
                  num2 = (short) 4;
                  num5 = (int) (IntPtr) num2;
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
                O7InnerSection o7InnerSection = current[10715] as O7InnerSection;
                string str4 = (string) ((AcpFieldX<int, string>) o7InnerSection.CHO7EmergencyButtonFeature_A41291).Converter.Convert((object) o7InnerSection.CHO7EmergencyButtonFeature_A41291Value, (Type) null, (object) null, this.ci);
                this.AddMultiValueByRTL(new bool?(!((FeatureNode) this.refTrunking).Parent.HiddenStatic), new bool?(), str4.ToString(), str4.ToString(), ref this.rptFields);
                this.rptFields.UIFieldName = ((O7Inner) current).O7InnerSection.CHO7EmergencyButtonName_A41289Value.ToString();
                this.rptFields.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uD98F횑쮓\uD995쪗\uDB99튛\uD99D\uE59F\uE0A1\uF1A3\uF2A5ﲧ\uE5A9\uE2AB", A_1), this.ci);
                this.rptRec.UIFields.Add(this.rptFields);
                A_0.RecSet.Add(this.rptRec);
                num2 = (short) 3;
                num5 = (int) (IntPtr) num2;
                continue;
              case 4:
                num2 = (short) 1;
                num5 = (int) (IntPtr) num2;
                continue;
            }
            num2 = (short) 2;
            num5 = (int) (IntPtr) num2;
          }
label_20:
          break;
        }
        finally
        {
          short num7 = 0;
          int num8 = (int) (IntPtr) num7;
          while (true)
          {
            switch (num8)
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
                goto label_21;
              case 2:
                enumerator.Dispose();
                num7 = (short) 1;
                num8 = (int) (IntPtr) num7;
                continue;
            }
            if (enumerator != null)
            {
              num7 = (short) 2;
              num8 = (int) (IntPtr) num7;
            }
            else
              break;
          }
label_21:;
        }
    }
  }

  private void d(ref _table A_0)
  {
    int A_1 = 14;
    int num1 = 0;
    switch (num1)
    {
      default:
        O7MFKAssignmentControlInnerRecset controlInnerRecset;
        O7MFKAssignmentControlInnerSection controlInnerSection1;
        O7MFKAssignmentControlInnerSection controlInnerSection2;
        Motorola.MackinawCPS.CoreFeatures.ControlHeadO7.ControlHeadO7 controlHeadO7;
        short num2;
        switch (0)
        {
          case 0:
label_3:
            this.rptRec = new _RecSet();
            int num3 = this.count++;
            this.rptRec.RecTitle = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uD890힒쪔\uDA96처힚즜횞\uE7A0\uF6A2\uEBA4\uE4A6ﶨ\uE2AA\uE2AC\uE1AE練ﶲ華\uF5B6", A_1), this.ci);
            _RecSet rptRec = this.rptRec;
            num3 = this.count;
            string str1 = num3.ToString();
            rptRec.RecNo = str1;
            controlInnerRecset = (O7MFKAssignmentControlInnerRecset) null;
            controlInnerSection1 = (O7MFKAssignmentControlInnerSection) null;
            controlInnerSection2 = (O7MFKAssignmentControlInnerSection) null;
            controlHeadO7 = FeatureManager.GetFeature(4114)[0] as Motorola.MackinawCPS.CoreFeatures.ControlHeadO7.ControlHeadO7;
            num2 = (short) 4;
            num1 = (int) (IntPtr) num2;
            goto default;
          default:
            while (true)
            {
              switch (num1)
              {
                case 0:
                  if (!((AcpFieldBase) controlHeadO7.O7MultiFunctionKnob.RadErgoControlO7MFKButtonPress_A42218).HiddenStatic)
                  {
                    num2 = (short) 8;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 5;
                case 1:
                  num2 = (short) 1;
                  if (num2 == (short) 0)
                    ;
                  num2 = (short) 0;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 2:
                  goto label_20;
                case 3:
                  num2 = (short) -15321;
                  int num4 = (int) num2;
                  num2 = (short) -15321;
                  int num5 = (int) num2;
                  switch (num4 == num5 ? 1 : 0)
                  {
                    case 0:
                    case 2:
                      goto label_20;
                    default:
                      num2 = (short) 0;
                      if (num2 == (short) 0)
                        ;
                      if (controlInnerRecset != null)
                      {
                        num2 = (short) 6;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto label_20;
                  }
                case 4:
                  if (controlHeadO7 != null)
                  {
                    num2 = (short) 1;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 5;
                case 5:
                  num2 = (short) 7;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 6:
                  controlInnerSection1 = ((Recordset) controlInnerRecset)[0][10724] as O7MFKAssignmentControlInnerSection;
                  controlInnerSection2 = ((Recordset) controlInnerRecset)[1][10724] as O7MFKAssignmentControlInnerSection;
                  num2 = (short) 2;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 7:
                  if (controlHeadO7 != null)
                  {
                    num2 = (short) 0;
                    num2 = (short) 9;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_20;
                case 8:
                  this.rptFields = new _UIFields();
                  int num6 = ((AcpField<int>) controlHeadO7.O7MultiFunctionKnob.RadErgoControlO7MFKButtonPress_A42218).Value;
                  string str2 = (string) ((AcpFieldX<int, string>) controlHeadO7.O7MultiFunctionKnob.RadErgoControlO7MFKButtonPress_A42218).Converter.Convert((object) num6, (Type) null, (object) null, this.ci);
                  this.AddMultiValueByRTL(new bool?(!((FeatureNode) this.refTrunking).Parent.HiddenStatic), new bool?(), str2, str2, ref this.rptFields);
                  this.rptFields.UIFieldName = RptMgrErrorHandler.b("\uDC90햒\uDE94잖\uEB98ﺚ\uEE9C\uEC9E\uE3A0욢춤욦\uDFA8슪슬\uDDAE", A_1);
                  this.rptFields.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uD890힒쪔\uDA96\uDF98킚출춞\uE4A0\uF0A2\uF6A4\uE5A6\uECA8\uE3AA\uECAC瑩\uF8B0ﲲ\uE7B4", A_1), this.ci);
                  this.rptRec.UIFields.Add(this.rptFields);
                  num2 = (short) 5;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 9:
                  controlInnerRecset = ((FeatureNode) controlHeadO7)[10718].EmbeddedRecset as O7MFKAssignmentControlInnerRecset;
                  num2 = (short) 3;
                  num1 = (int) (IntPtr) num2;
                  continue;
                default:
                  goto label_3;
              }
            }
label_20:
            this.rptFields = new _UIFields();
            int num7 = ((AcpField<int>) controlInnerSection1.RadErgoControlO7MFKFeatureAssignment_A41295).Value;
            string str3 = (string) ((AcpFieldX<int, string>) controlInnerSection1.RadErgoControlO7MFKFeatureAssignment_A41295).Converter.Convert((object) num7, (Type) null, (object) null, this.ci);
            this.AddMultiValueByRTL(new bool?(!((FeatureNode) this.refTrunking).Parent.HiddenStatic), new bool?(), str3, str3, ref this.rptFields);
            this.rptFields.UIFieldName = RptMgrErrorHandler.b("손\uE192ﲔ殺\uF898\uE99A\uE49C\uD99E풠춢욤펦삨쒪쎬", A_1);
            this.rptFields.UIFieldDes = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("손\uE192ﲔ殺\uF898\uE99A\uE49C삞\uE7A0횢쮤쒦\uDDA8슪슬솮", A_1), this.ci);
            this.rptRec.UIFields.Add(this.rptFields);
            this.rptFields = new _UIFields();
            int num8 = ((AcpField<int>) controlInnerSection2.RadErgoControlO7MFKFeatureAssignment_A41295).Value;
            string str4 = (string) ((AcpFieldX<int, string>) controlInnerSection2.RadErgoControlO7MFKFeatureAssignment_A41295).Converter.Convert((object) num8, (Type) null, (object) null, this.ci);
            this.AddMultiValueByRTL(new bool?(!((FeatureNode) this.refTrunking).Parent.HiddenStatic), new bool?(), str4, str4, ref this.rptFields);
            this.rptFields.UIFieldName = RptMgrErrorHandler.b("슐\uF692\uF694\uF896\uF798ﾚﲜ\uED9E\uD8A0\uE5A2키즦쪨\uDFAA쒬삮\uDFB0", A_1);
            this.rptFields.UIFieldDes = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("슐\uF692\uF694\uF896\uF798ﾚﲜ\uED9E\uD8A0ﲢ\uE3A4튦잨좪\uD9AC욮\uDEB0\uDDB2", A_1), this.ci);
            this.rptRec.UIFields.Add(this.rptFields);
            A_0.RecSet.Add(this.rptRec);
            return;
        }
    }
  }

  private void c(ref _table A_0)
  {
    int A_1 = 3;
    switch (0)
    {
      default:
        short num1 = 1;
        if (num1 == (short) 0)
          ;
        num1 = (short) 0;
        num1 = (short) 0;
        int num2 = (int) (IntPtr) num1;
        IEnumerator<FeatureNode> enumerator;
        while (true)
        {
          switch (num2)
          {
            case 0:
label_3:
              switch (0)
              {
                case 0:
                  break;
                default:
                  continue;
              }
              break;
            case 1:
              goto label_7;
            case 2:
              num1 = (short) -30444;
              int num3 = (int) num1;
              num1 = (short) -30444;
              int num4 = (int) num1;
              switch (num3 == num4 ? 1 : 0)
              {
                case 0:
                case 2:
                  goto label_3;
                default:
                  num1 = (short) 0;
                  if (num1 == (short) 0)
                    ;
                  enumerator = ((Collection<FeatureNode>) this.d).GetEnumerator();
                  num1 = (short) 1;
                  num2 = (int) (IntPtr) num1;
                  continue;
              }
          }
          if (this.d != null)
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
          int num5 = (int) (IntPtr) num1;
          while (true)
          {
            switch (num5)
            {
              case 0:
                goto label_25;
              case 1:
                if (!enumerator.MoveNext())
                {
                  num1 = (short) 4;
                  num5 = (int) (IntPtr) num1;
                  continue;
                }
                IAcpFeatureNode current = (IAcpFeatureNode) enumerator.Current;
                this.rptRec = new _RecSet();
                this.rptFields = new _UIFields();
                ++this.count;
                this.rptRec.RecTitle = AppResources.NOPRINT_Id + this.count.ToString();
                this.rptRec.RecNo = this.count.ToString();
                KMButtonInnerSection buttonInnerSection = current[10239] as KMButtonInnerSection;
                int featureA19646Value = buttonInnerSection.RadErgoCfgKMConventionalKMButtonFeature_A19646Value;
                int featureA19746Value = buttonInnerSection.RadErgoCfgKMTrunkingKMButtonFeature_A19746Value;
                string str1 = (string) ((AcpFieldX<int, string>) buttonInnerSection.RadErgoCfgKMConventionalKMButtonFeature_A19646).Converter.Convert((object) featureA19646Value, (Type) null, (object) null, this.ci);
                string str2 = (string) ((AcpFieldX<int, string>) buttonInnerSection.RadErgoCfgKMTrunkingKMButtonFeature_A19746).Converter.Convert((object) featureA19746Value, (Type) null, (object) null, this.ci);
                this.AddMultiValueByRTL(new bool?(!((AcpFieldBase) buttonInnerSection.RadErgoCfgKMTrunkingKMButtonFeature_A19746).HiddenStatic), new bool?(!((AcpFieldBase) buttonInnerSection.RadErgoCfgKMConventionalKMButtonFeature_A19646).HiddenDynamic), str2.ToString(), str1.ToString(), ref this.rptFields);
                this.rptFields.UIFieldName = ((AcpFieldBase) ((KMButtonInner) current).KMButtonInnerSection.RadErgoCfgKMButtonName_A22561).UIName.ToString();
                string uiName = ((KMButtonInner) current).KMButtonInnerSection.RadErgoCfgKMButtonName_A22561_UIValue.ToString();
                this.AddUiFieldDescByCondition(ref this.rptFields, uiName, AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("쾅첇행\uDF8B잍풏힑삓\uD995좗\uD899즛쪝\uF49F\uEDA1\uEAA3", A_1), Thread.CurrentThread.CurrentCulture), AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("쾅첇행\uDF8B잍풏힑삓\uD995좗\uD899즛쪝\uF49F\uEDA1\uEAA3", A_1), this.ci));
                this.AddUiFieldDescByCondition(ref this.rptFields, uiName, AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("쾅첇행\uDF8B잍풏힑\uD993\uDF95\uDC97\uDE99킛\uDB9D\uE29F\uF7A1\uF0A3\uF2A5\uE7A7\uE4A9", A_1), Thread.CurrentThread.CurrentCulture), AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("쾅첇행\uDF8B잍풏힑\uD993\uDF95\uDC97\uDE99킛\uDB9D\uE29F\uF7A1\uF0A3\uF2A5\uE7A7\uE4A9", A_1), this.ci));
                this.AddUiFieldDescByCondition(ref this.rptFields, uiName, AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("쾅첇행\uDF8B잍풏힑횓\uD995첗캙펛펝\uE29F\uF7A1\uF0A3\uF2A5\uE7A7\uE4A9", A_1), Thread.CurrentThread.CurrentCulture), AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("쾅첇행\uDF8B잍풏힑횓\uD995첗캙펛펝\uE29F\uF7A1\uF0A3\uF2A5\uE7A7\uE4A9", A_1), this.ci));
                num1 = (short) 5;
                num5 = (int) (IntPtr) num1;
                continue;
              case 2:
                switch (0)
                {
                  case 0:
                    break;
                  default:
                    continue;
                }
                break;
              case 4:
                num1 = (short) 0;
                num5 = (int) (IntPtr) num1;
                continue;
              case 5:
                if (string.IsNullOrEmpty(this.rptFields.UIFieldDes))
                {
                  num1 = (short) 7;
                  num5 = (int) (IntPtr) num1;
                  continue;
                }
                goto case 6;
              case 6:
                this.rptRec.UIFields.Add(this.rptFields);
                A_0.RecSet.Add(this.rptRec);
                num1 = (short) 3;
                num5 = (int) (IntPtr) num1;
                continue;
              case 7:
                this.rptFields.UIFieldDes = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("쾅첇행쎋뮍튏작삓슕힗풙", A_1), this.ci);
                num1 = (short) 6;
                num5 = (int) (IntPtr) num1;
                continue;
            }
            num1 = (short) 1;
            num5 = (int) (IntPtr) num1;
          }
label_25:
          break;
        }
        finally
        {
          short num6 = 0;
          int num7 = (int) (IntPtr) num6;
          while (true)
          {
            switch (num7)
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
                goto label_26;
              case 2:
                enumerator.Dispose();
                num6 = (short) 1;
                num7 = (int) (IntPtr) num6;
                continue;
            }
            if (enumerator != null)
            {
              num6 = (short) 2;
              num7 = (int) (IntPtr) num6;
            }
            else
              break;
          }
label_26:;
        }
    }
  }

  private void b(ref _table A_0)
  {
    int A_1 = 17;
label_1:
    short num1 = 0;
    switch (num1)
    {
      default:
        num1 = (short) 0;
        int num2 = (int) (IntPtr) num1;
        while (true)
        {
          IEnumerator<FeatureNode> enumerator;
          switch (num2)
          {
            case 0:
              num1 = (short) 1;
              if (num1 == (short) 0)
                ;
              num1 = (short) -29196;
              int num3 = (int) num1;
              num1 = (short) -29196;
              int num4 = (int) num1;
              switch (num3 == num4 ? 1 : 0)
              {
                case 0:
                case 2:
                  goto label_1;
                default:
                  num1 = (short) 0;
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
              }
            case 1:
              num1 = (short) 0;
              this.rptRec = new _RecSet();
              int num5 = this.count++;
              this.rptRec.RecTitle = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDD93튕잗풙\uDD9B좝\uE99F\uE5A1\uE5A3\uF2A5\uE1A7\uE5A9\uE2AB\uEDADﾯﲱ\uE0B3\uE4B5\uF7B7\uF6B9\uEFBB", A_1), this.ci);
              _RecSet rptRec = this.rptRec;
              num5 = this.count;
              string str1 = num5.ToString();
              rptRec.RecNo = str1;
              enumerator = ((Collection<FeatureNode>) this.g).GetEnumerator();
              num1 = (short) 3;
              num2 = (int) (IntPtr) num1;
              continue;
            case 2:
              goto label_26;
            case 3:
              try
              {
                num1 = (short) 0;
                int num6 = (int) (IntPtr) num1;
                while (true)
                {
                  switch (num6)
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
                      goto label_27;
                    case 3:
                      num1 = (short) 1;
                      num6 = (int) (IntPtr) num1;
                      continue;
                    case 4:
                      if (enumerator.MoveNext())
                      {
                        FeatureNode current = enumerator.Current;
                        this.rptFields = new _UIFields();
                        O7NavigationControlsTableInnerSection tableInnerSection = ((IAcpFeatureNode) current)[10728] as O7NavigationControlsTableInnerSection;
                        int buttonA41293Value = tableInnerSection.RadErgoControlO7UpDownButton_A41293Value;
                        string str2 = (string) ((AcpFieldX<int, string>) tableInnerSection.RadErgoControlO7UpDownButton_A41293).Converter.Convert((object) buttonA41293Value, (Type) null, (object) null, this.ci);
                        this.AddMultiValueByRTL(new bool?(!((FeatureNode) this.refTrunking).Parent.HiddenStatic), new bool?(), str2.ToString(), str2.ToString(), ref this.rptFields);
                        this.rptFields.UIFieldName = ((AcpFieldBase) tableInnerSection.RadErgoControlO7UpDownButton_A41293).UIName.ToString();
                        string uiName = tableInnerSection.O7UpDownButtonName_A41292_UIValue.ToString();
                        this.AddUiFieldDescByCondition(ref this.rptFields, uiName, AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDD93튕잗쾙첛\uDC9D\uF59F\uF6A1\uF0A3\uE9A5\uE6A7", A_1), Thread.CurrentThread.CurrentCulture), AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDD93튕잗쾙첛\uDC9D\uF59F\uF6A1\uF0A3\uE9A5\uE6A7", A_1), this.ci));
                        this.AddUiFieldDescByCondition(ref this.rptFields, uiName, AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("킓秊\uEF97\uF499쎛\uDC9D햟횡킣즥욧", A_1), Thread.CurrentThread.CurrentCulture), AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("킓秊\uEF97\uF499쎛\uDC9D햟횡킣즥욧", A_1), this.ci));
                        this.rptRec.UIFields.Add(this.rptFields);
                        num1 = (short) 2;
                        num6 = (int) (IntPtr) num1;
                        continue;
                      }
                      num1 = (short) 3;
                      num6 = (int) (IntPtr) num1;
                      continue;
                  }
                  num1 = (short) 4;
                  num6 = (int) (IntPtr) num1;
                }
              }
              finally
              {
                int num7 = 0;
                while (true)
                {
                  short num8;
                  switch (num7)
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
                      goto label_25;
                    case 2:
                      enumerator.Dispose();
                      num8 = (short) 1;
                      num7 = (int) (IntPtr) num8;
                      continue;
                  }
                  if (enumerator != null)
                  {
                    num8 = (short) 2;
                    num7 = (int) (IntPtr) num8;
                  }
                  else
                    break;
                }
label_25:;
              }
label_27:
              A_0.RecSet.Add(this.rptRec);
              num1 = (short) 2;
              num2 = (int) (IntPtr) num1;
              continue;
          }
          if (this.g != null)
          {
            num1 = (short) 1;
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
    int A_1 = 18;
    switch (0)
    {
      default:
        int num1 = 3;
        short num2;
        while (true)
        {
          string str1;
          string indexA41418UiValue;
          IAcpFeatureNode iacpFeatureNode;
          O7DataButtonInnerSection buttonInnerSection;
          string str2;
          string indexA41417UiValue;
          switch (num1)
          {
            case 0:
              this.rptRec = new _RecSet();
              this.rptFields = new _UIFields();
              ++this.count;
              this.rptRec.RecTitle = AppResources.NOPRINT_Id + this.count.ToString();
              this.rptRec.RecNo = this.count.ToString();
              iacpFeatureNode = ((Recordset) this.e)[0];
              buttonInnerSection = iacpFeatureNode[10713] as O7DataButtonInnerSection;
              int num3 = ((AcpField<int>) buttonInnerSection.RadErgCtrlHeadO7DataButtonCnvFeature_A41299).Value;
              int num4 = ((AcpField<int>) buttonInnerSection.RadErgCtrlHeadO7DataButtonTrkFeature_A41297).Value;
              str2 = (string) ((AcpFieldX<int, string>) buttonInnerSection.RadErgCtrlHeadO7DataButtonCnvFeature_A41299).Converter.Convert((object) num3, (Type) null, (object) null, this.ci);
              str1 = (string) ((AcpFieldX<int, string>) buttonInnerSection.RadErgCtrlHeadO7DataButtonTrkFeature_A41297).Converter.Convert((object) num4, (Type) null, (object) null, this.ci);
              indexA41417UiValue = buttonInnerSection.CHO7DataButtonConvIndex_A41417_UIValue;
              indexA41418UiValue = buttonInnerSection.CHO7DataButtonTrkIndex_A41418_UIValue;
              num2 = (short) 1;
              num1 = (int) (IntPtr) num2;
              continue;
            case 1:
              if (str2 == AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDC94펖욘\uDA9A\uDE9C쮞\uE8A0\uECA2\uEBA4\uE4A6\uE6A8\uE5AAﺬ\uE0AEﶰ者\uF1B4\uF6B6\uEDB8\uF2BA\uF2BC\uF1BE", A_1), this.ci))
              {
                num2 = (short) 5;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 4;
            case 2:
              num2 = (short) 1;
              if (num2 == (short) 0)
                break;
              break;
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
              str2 = str2 + this.indexSeparator + indexA41417UiValue;
              goto label_18;
            case 6:
              if (str1 == AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDC94펖욘\uDA9A\uDE9C쮞\uE8A0\uECA2\uEBA4\uE4A6\uE6A8\uE5AAﺬ\uE0AEﶰ者\uF1B4\uF6B6\uEDB8\uF2BA\uF2BC\uF1BE", A_1), this.ci))
              {
                num2 = (short) 8;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              break;
            case 7:
              goto label_19;
            case 8:
              str1 = str1 + this.indexSeparator + indexA41418UiValue;
              num2 = (short) 19090;
              int num5 = (int) num2;
              num2 = (short) 19090;
              int num6 = (int) num2;
              switch (num5 == num6 ? 1 : 0)
              {
                case 0:
                case 2:
                  goto label_18;
                default:
                  num2 = (short) 0;
                  if (num2 == (short) 0)
                    ;
                  num2 = (short) 2;
                  num1 = (int) (IntPtr) num2;
                  continue;
              }
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
          this.AddMultiValueByRTL(new bool?(!((AcpFieldBase) buttonInnerSection.RadErgCtrlHeadO7DataButtonTrkFeature_A41297).HiddenStatic), new bool?(!((AcpFieldBase) buttonInnerSection.RadErgCtrlHeadO7DataButtonCnvFeature_A41299).HiddenStatic), str1, str2, ref this.rptFields);
          this.rptFields.UIFieldName = ((AcpFieldBase) (iacpFeatureNode[10713] as O7DataButtonInnerSection).RadErgCtrlHeadO7DataButtonName_A41296).UIName.ToString();
          this.rptFields.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDC94펖욘\uDF9A\uDC9C쮞\uE0A0\uE1A2\uF0A4\uF3A6ﶨ\uE4AA\uE3AC\uF0AE肰", A_1), this.ci);
          this.rptRec.UIFields.Add(this.rptFields);
          A_0.RecSet.Add(this.rptRec);
          num2 = (short) 7;
          num1 = (int) (IntPtr) num2;
          continue;
label_18:
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
              num2 = (short) -28192;
              int num3 = (int) num2;
              num2 = (short) -28192;
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
                  this.e(ref this.rptTable);
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
