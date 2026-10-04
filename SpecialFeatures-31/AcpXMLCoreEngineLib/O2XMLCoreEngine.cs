// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.ACPXMLCoreEngineLib.O2XMLCoreEngine
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using AcpBusinessLayer;
using AcpCommonLib;
using CommonResources;
using ConstraintHelper;
using Motorola.MackinawCPS.CoreFeatures.ControlHeadO2;
using Motorola.MackinawCPS.CoreFeatures.Keypad;
using Motorola.MackinawCPS.CoreFeatures.KeypadMicAndAccessories;
using SpecialFeatures.AcpReportManagerLib;
using SpecialFeatures.AcpXMLCoreEngineLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;

#nullable disable
namespace SpecialFeatures.ACPXMLCoreEngineLib;

public class O2XMLCoreEngine : BaseHandOutXMLCoreEngine
{
  private Motorola.MackinawCPS.CoreFeatures.ControlHeadO2.ControlHeadO2 a;
  private Motorola.MackinawCPS.CoreFeatures.KeypadMicAndAccessories.KeypadMicAndAccessories b;
  private O2InnerRecset c;
  private KMButtonInnerRecset d;
  private DataButtonInnerRecset e;
  private ControlHeadO2Recset f;
  private O2NavigationControlsTableInnerRecset g;
  private KeypadMicAndAccessoriesRecset h;
  private KeypadRecset i;
  private KeypadButtonInnerRecset j;

  public O2XMLCoreEngine()
  {
    this.a = FeatureManager.GetFeature(4115)[0] as Motorola.MackinawCPS.CoreFeatures.ControlHeadO2.ControlHeadO2;
    this.b = FeatureManager.GetFeature(2128)[0] as Motorola.MackinawCPS.CoreFeatures.KeypadMicAndAccessories.KeypadMicAndAccessories;
    this.f = FeatureManager.GetFeature(4115) as ControlHeadO2Recset;
    if (this.f != null)
    {
      this.c = ((Recordset) this.f)[0][10723].EmbeddedRecset as O2InnerRecset;
      this.g = ((Recordset) this.f)[0][10722].EmbeddedRecset as O2NavigationControlsTableInnerRecset;
    }
    this.h = FeatureManager.GetFeature(2128) as KeypadMicAndAccessoriesRecset;
    if (this.h != null)
      goto label_2;
label_1:
    this.i = FeatureManager.GetFeature(4109) as KeypadRecset;
    if (this.i == null)
      return;
    this.j = ((Recordset) this.i)[0][10710].EmbeddedRecset as KeypadButtonInnerRecset;
    return;
label_2:
    this.d = ((Recordset) this.h)[0][10231].EmbeddedRecset as KMButtonInnerRecset;
    this.e = ((Recordset) this.h)[0][10228].EmbeddedRecset as DataButtonInnerRecset;
    goto label_1;
  }

  private void e(ref _table A_0)
  {
    int A_1 = 8;
    switch (0)
    {
      default:
        short num1 = 2;
        int num2 = (int) (IntPtr) num1;
        IEnumerator<FeatureNode> enumerator;
        while (true)
        {
          switch (num2)
          {
            case 0:
              goto label_6;
            case 1:
              enumerator = ((Collection<FeatureNode>) this.c).GetEnumerator();
              num1 = (short) 1;
              if (num1 == (short) 0)
                ;
              num1 = (short) 0;
              num2 = (int) (IntPtr) num1;
              continue;
            case 2:
              num1 = (short) 0;
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
            num1 = (short) 1;
            num2 = (int) (IntPtr) num1;
          }
          else
            break;
        }
        break;
label_6:
        try
        {
          num1 = (short) 4;
          int num3 = (int) (IntPtr) num1;
          while (true)
          {
            switch (num3)
            {
              case 0:
                goto label_20;
              case 2:
                if (!enumerator.MoveNext())
                {
                  num1 = (short) 3;
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
                O2InnerSection o2InnerSection = current[10716] as O2InnerSection;
                string str4 = (string) ((AcpFieldX<int, string>) o2InnerSection.CHO2EmergencyButtonFeature_A41272).Converter.Convert((object) o2InnerSection.CHO2EmergencyButtonFeature_A41272Value, (Type) null, (object) null, this.ci);
                this.AddMultiValueByRTL(new bool?(!((FeatureNode) this.refTrunking).Parent.HiddenStatic), new bool?(), str4.ToString(), str4.ToString(), ref this.rptFields);
                this.rptFields.UIFieldName = ((O2Inner) current).O2InnerSection.CHO2EmergencyButtonName_A41270.ToString();
                this.rptFields.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("슊즌킎\uDE90솒풔\uD996\uDE98\uDE9A\uDF9C쪞\uF5A0\uF7A2\uEAA4\uE9A6", A_1), this.ci);
                this.rptRec.UIFields.Add(this.rptFields);
                A_0.RecSet.Add(this.rptRec);
                num1 = (short) 1;
                num3 = (int) (IntPtr) num1;
                continue;
              case 3:
                num1 = (short) 0;
                num3 = (int) (IntPtr) num1;
                continue;
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
            num1 = (short) 2;
            num3 = (int) (IntPtr) num1;
          }
label_20:
          break;
        }
        finally
        {
          int num5 = 2;
          short num6;
          while (true)
          {
            switch (num5)
            {
              case 0:
                num6 = (short) 14893;
                int num7 = (int) num6;
                num6 = (short) 14893;
                int num8 = (int) num6;
                switch (num7 == num8 ? 1 : 0)
                {
                  case 0:
                  case 2:
                    break;
                  default:
                    goto label_22;
                }
                break;
              case 1:
                enumerator.Dispose();
                num6 = (short) 0;
                num5 = (int) (IntPtr) num6;
                continue;
              case 2:
                switch (0)
                {
                  case 0:
                    goto label_17;
                  default:
                    continue;
                }
              default:
label_17:
                if (enumerator == null)
                  goto case 0;
                break;
            }
            num6 = (short) 1;
            num5 = (int) (IntPtr) num6;
          }
label_22:
          num6 = (short) 0;
          if (num6 == (short) 0)
            ;
        }
    }
  }

  private void d(ref _table A_0)
  {
    int A_1 = 15;
    short num1 = 0;
    num1 = (short) 0;
    int num2 = (int) num1;
    switch (num2)
    {
      default:
        O2MFKAssignmentControlInnerRecset controlInnerRecset;
        O2MFKAssignmentControlInnerSection controlInnerSection1;
        O2MFKAssignmentControlInnerSection controlInnerSection2;
        Motorola.MackinawCPS.CoreFeatures.ControlHeadO2.ControlHeadO2 controlHeadO2;
        switch (0)
        {
          case 0:
label_3:
            this.rptRec = new _RecSet();
            ++this.count;
            this.rptRec.RecTitle = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDB91킓즕햗쾙킛쪝\uE99F\uE4A1\uF1A3\uE8A5\uEBA7ﺩ\uE5AB\uE1ADﺯ鈴荒例覆", A_1), this.ci);
            this.rptRec.RecNo = this.count.ToString();
            controlInnerRecset = (O2MFKAssignmentControlInnerRecset) null;
            controlInnerSection1 = (O2MFKAssignmentControlInnerSection) null;
            controlInnerSection2 = (O2MFKAssignmentControlInnerSection) null;
            controlHeadO2 = FeatureManager.GetFeature(4115)[0] as Motorola.MackinawCPS.CoreFeatures.ControlHeadO2.ControlHeadO2;
            num1 = (short) 5;
            num2 = (int) (IntPtr) num1;
            goto default;
          default:
            while (true)
            {
              switch (num2)
              {
                case 0:
                  num1 = (short) 1;
                  num2 = (int) (IntPtr) num1;
                  continue;
                case 1:
                  if (controlHeadO2 != null)
                  {
                    num1 = (short) 8;
                    num2 = (int) (IntPtr) num1;
                    continue;
                  }
                  goto label_20;
                case 2:
                  if (!((AcpFieldBase) controlHeadO2.O2MultiFunctionKnob.RadErgoControlO2MFKButtonPress_A42217).HiddenStatic)
                  {
                    num1 = (short) 4;
                    num2 = (int) (IntPtr) num1;
                    continue;
                  }
                  goto case 0;
                case 3:
                  if (controlInnerRecset != null)
                  {
                    num1 = (short) 7;
                    num2 = (int) (IntPtr) num1;
                    continue;
                  }
                  goto label_20;
                case 4:
                  this.rptFields = new _UIFields();
                  int num3 = ((AcpField<int>) controlHeadO2.O2MultiFunctionKnob.RadErgoControlO2MFKButtonPress_A42217).Value;
                  string str1 = (string) ((AcpFieldX<int, string>) controlHeadO2.O2MultiFunctionKnob.RadErgoControlO2MFKButtonPress_A42217).Converter.Convert((object) num3, (Type) null, (object) null, this.ci);
                  this.AddMultiValueByRTL(new bool?(!((FeatureNode) this.refTrunking).Parent.HiddenStatic), new bool?(), str1, str1, ref this.rptFields);
                  this.rptFields.UIFieldName = RptMgrErrorHandler.b("\uDF91튓\uDD95좗\uE899鍊\uED9D펟\uE0A1솣캥즧\uDCA9얫솭슯", A_1);
                  this.rptFields.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDB91킓즕햗\uDC99힛캝\uF29F\uE7A1\uF7A3\uF5A5\uEAA7\uEFA9\uE4AB\uEFAD\uE6AFﮱ﮳\uE4B5", A_1), this.ci);
                  this.rptRec.UIFields.Add(this.rptFields);
                  num1 = (short) 0;
                  num2 = (int) (IntPtr) num1;
                  continue;
                case 5:
label_4:
                  if (controlHeadO2 != null)
                  {
                    num1 = (short) 9;
                    num2 = (int) (IntPtr) num1;
                    continue;
                  }
                  goto case 0;
                case 6:
                  goto label_20;
                case 7:
                  controlInnerSection1 = ((Recordset) controlInnerRecset)[0][10726] as O2MFKAssignmentControlInnerSection;
                  controlInnerSection2 = ((Recordset) controlInnerRecset)[1][10726] as O2MFKAssignmentControlInnerSection;
                  num1 = (short) 6;
                  num2 = (int) (IntPtr) num1;
                  continue;
                case 8:
                  num1 = (short) -26630;
                  int num4 = (int) num1;
                  num1 = (short) -26630;
                  int num5 = (int) num1;
                  switch (num4 == num5 ? 1 : 0)
                  {
                    case 0:
                    case 2:
                      goto label_4;
                    default:
                      num1 = (short) 0;
                      if (num1 == (short) 0)
                        ;
                      controlInnerRecset = ((FeatureNode) controlHeadO2)[10721].EmbeddedRecset as O2MFKAssignmentControlInnerRecset;
                      num1 = (short) 1;
                      if (num1 == (short) 0)
                        ;
                      num1 = (short) 3;
                      num2 = (int) (IntPtr) num1;
                      continue;
                  }
                case 9:
                  num1 = (short) 2;
                  num2 = (int) (IntPtr) num1;
                  continue;
                default:
                  goto label_3;
              }
            }
label_20:
            this.rptFields = new _UIFields();
            int num6 = ((AcpField<int>) controlInnerSection1.RadErgoControlO2MFKFeatureAssignment_A41275).Value;
            string str2 = (string) ((AcpFieldX<int, string>) controlInnerSection1.RadErgoControlO2MFKFeatureAssignment_A41275).Converter.Convert((object) num6, (Type) null, (object) null, this.ci);
            this.AddMultiValueByRTL(new bool?(!((FeatureNode) this.refTrunking).Parent.HiddenStatic), new bool?(), str2, str2, ref this.rptFields);
            this.rptFields.UIFieldName = RptMgrErrorHandler.b("슑\uE693ﾕ\uF597ﮙ\uEE9B\uE79D\uE69F힡쪣얥\uDCA7쎩쎫삭", A_1);
            this.rptFields.UIFieldDes = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("슑\uE693ﾕ\uF597ﮙ\uEE9B\uE79Dﾟ\uE4A1톣좥쮧\uDEA9얫솭\uDEAF", A_1), this.ci);
            this.rptRec.UIFields.Add(this.rptFields);
            this.rptFields = new _UIFields();
            int num7 = ((AcpField<int>) controlInnerSection2.RadErgoControlO2MFKFeatureAssignment_A41275).Value;
            string str3 = (string) ((AcpFieldX<int, string>) controlInnerSection2.RadErgoControlO2MFKFeatureAssignment_A41275).Converter.Convert((object) num7, (Type) null, (object) null, this.ci);
            this.AddMultiValueByRTL(new bool?(!((FeatureNode) this.refTrunking).Parent.HiddenStatic), new bool?(), str3, str3, ref this.rptFields);
            this.rptFields.UIFieldName = RptMgrErrorHandler.b("솑\uF193\uF595\uF797\uF499\uF89Bﾝ튟\uDBA1\uE2A3펥욧즩\uD8AB잭\uDFAF\uDCB1", A_1);
            this.rptFields.UIFieldDes = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("솑\uF193\uF595\uF797\uF499\uF89Bﾝ튟\uDBA1ﮣ\uE0A5\uDDA7쒩쾫\uDAAD\uD9AF\uDDB1\uDAB3", A_1), this.ci);
            this.rptRec.UIFields.Add(this.rptFields);
            A_0.RecSet.Add(this.rptRec);
            return;
        }
    }
  }

  private void c(ref _table A_0)
  {
    int A_1 = 8;
    switch (0)
    {
      default:
        short num1 = 2;
        int num2 = (int) (IntPtr) num1;
        IEnumerator<FeatureNode> enumerator;
        while (true)
        {
          switch (num2)
          {
            case 0:
              goto label_25;
            case 1:
              enumerator = ((Collection<FeatureNode>) this.d).GetEnumerator();
              num1 = (short) 0;
              num2 = (int) (IntPtr) num1;
              continue;
            case 2:
              num1 = (short) 0;
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
            num1 = (short) 1;
            num2 = (int) (IntPtr) num1;
          }
          else
            break;
        }
        break;
label_25:
        num1 = (short) 1;
        if (num1 == (short) 0)
          ;
        try
        {
          num1 = (short) 4;
          int num3 = (int) (IntPtr) num1;
          while (true)
          {
            switch (num3)
            {
              case 0:
                goto label_20;
              case 2:
                if (!enumerator.MoveNext())
                {
                  num1 = (short) 3;
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
                this.AddUiFieldDescByCondition(ref this.rptFields, uiName, AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("슊즌킎슐\uDA92톔튖춘풚출\uDD9E\uF4A0\uF7A2\uF1A4\uE8A6\uE7A8", A_1), Thread.CurrentThread.CurrentCulture), AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("슊즌킎슐\uDA92톔튖춘풚출\uDD9E\uF4A0\uF7A2\uF1A4\uE8A6\uE7A8", A_1), this.ci));
                this.AddUiFieldDescByCondition(ref this.rptFields, uiName, AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("슊즌킎슐\uDA92톔튖풘튚\uD99C\uDB9E\uEDA0\uE6A2\uE7A4\uF2A6ﶨﾪ\uE2AC\uE1AE", A_1), Thread.CurrentThread.CurrentCulture), AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("슊즌킎슐\uDA92톔튖풘튚\uD99C\uDB9E\uEDA0\uE6A2\uE7A4\uF2A6ﶨﾪ\uE2AC\uE1AE", A_1), this.ci));
                this.AddUiFieldDescByCondition(ref this.rptFields, uiName, AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("슊즌킎슐\uDA92톔튖\uDB98풚즜쮞\uEEA0\uEEA2\uE7A4\uF2A6ﶨﾪ\uE2AC\uE1AE", A_1), Thread.CurrentThread.CurrentCulture), AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("슊즌킎슐\uDA92톔튖\uDB98풚즜쮞\uEEA0\uEEA2\uE7A4\uF2A6ﶨﾪ\uE2AC\uE1AE", A_1), this.ci));
                this.AddUiFieldDescByCondition(ref this.rptFields, uiName, (string) null, AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("슊즌킎\uDE90Ꚓ힔슖춘쾚튜톞", A_1), this.ci));
                this.rptRec.UIFields.Add(this.rptFields);
                A_0.RecSet.Add(this.rptRec);
                num1 = (short) 1;
                num3 = (int) (IntPtr) num1;
                continue;
              case 3:
                num1 = (short) 0;
                num3 = (int) (IntPtr) num1;
                continue;
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
            num1 = (short) 2;
            num3 = (int) (IntPtr) num1;
          }
label_20:
          break;
        }
        finally
        {
          short num5 = 2;
          int num6 = (int) (IntPtr) num5;
          while (true)
          {
            switch (num6)
            {
              case 0:
                num5 = (short) 12343;
                int num7 = (int) num5;
                num5 = (short) 12343;
                int num8 = (int) num5;
                switch (num7 == num8 ? 1 : 0)
                {
                  case 0:
                  case 2:
                    break;
                  default:
                    goto label_22;
                }
                break;
              case 1:
                enumerator.Dispose();
                num5 = (short) 0;
                num6 = (int) (IntPtr) num5;
                continue;
              case 2:
                switch (0)
                {
                  case 0:
                    goto label_17;
                  default:
                    continue;
                }
              default:
label_17:
                if (enumerator == null)
                  goto case 0;
                break;
            }
            num5 = (short) 1;
            num6 = (int) (IntPtr) num5;
          }
label_22:
          num5 = (short) 0;
          if (num5 == (short) 0)
            ;
        }
    }
  }

  private void b(ref _table A_0)
  {
    int A_1 = 2;
    switch (0)
    {
      default:
        short num1 = 3;
        int num2 = (int) (IntPtr) num1;
        while (true)
        {
          num1 = (short) 1;
          if (num1 == (short) 0)
            ;
          IEnumerator<FeatureNode> enumerator;
          switch (num2)
          {
            case 0:
              try
              {
                num1 = (short) 4;
                int num3 = (int) (IntPtr) num1;
                while (true)
                {
                  switch (num3)
                  {
                    case 0:
                      goto label_25;
                    case 1:
                      num1 = (short) 0;
                      num3 = (int) (IntPtr) num1;
                      continue;
                    case 3:
                      if (enumerator.MoveNext())
                      {
                        FeatureNode current = enumerator.Current;
                        this.rptFields = new _UIFields();
                        O2NavigationControlsTableInnerSection tableInnerSection = ((IAcpFeatureNode) current)[10725] as O2NavigationControlsTableInnerSection;
                        int buttonA41278Value = tableInnerSection.RadErgoControlO2UpDownButton_A41278Value;
                        string str = (string) ((AcpFieldX<int, string>) tableInnerSection.RadErgoControlO2UpDownButton_A41278).Converter.Convert((object) buttonA41278Value, (Type) null, (object) null, this.ci);
                        this.AddMultiValueByRTL(new bool?(!((FeatureNode) this.refTrunking).Parent.HiddenStatic), new bool?(), str.ToString(), str.ToString(), ref this.rptFields);
                        this.rptFields.UIFieldName = ((AcpFieldBase) tableInnerSection.RadErgoControlO2UpDownButton_A41278).UIName.ToString();
                        string uiName = tableInnerSection.O2UpDownButtonName_A41277_UIValue.ToString();
                        this.AddUiFieldDescByCondition(ref this.rptFields, uiName, AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("첄쎆횈\uDE8A\uDD8C춎쒐잒솔\uD896힘", A_1), Thread.CurrentThread.CurrentCulture), AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("첄쎆횈\uDE8A\uDD8C춎쒐잒솔\uD896힘", A_1), this.ci));
                        this.AddUiFieldDescByCondition(ref this.rptFields, uiName, AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("솄\uE886ﺈ\uE58A튌춎\uE490\uE792\uE194\uF896\uF798", A_1), Thread.CurrentThread.CurrentCulture), AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("솄\uE886ﺈ\uE58A튌춎\uE490\uE792\uE194\uF896\uF798", A_1), this.ci));
                        this.rptRec.UIFields.Add(this.rptFields);
                        num1 = (short) 2;
                        num3 = (int) (IntPtr) num1;
                        continue;
                      }
                      num1 = (short) 1;
                      num3 = (int) (IntPtr) num1;
                      continue;
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
                  num1 = (short) 3;
                  num3 = (int) (IntPtr) num1;
                }
              }
              finally
              {
                int num4 = 2;
                short num5;
                while (true)
                {
                  switch (num4)
                  {
                    case 0:
                      num5 = (short) 2402;
                      int num6 = (int) num5;
                      num5 = (short) 2402;
                      int num7 = (int) num5;
                      switch (num6 == num7 ? 1 : 0)
                      {
                        case 0:
                        case 2:
                          break;
                        default:
                          goto label_22;
                      }
                      break;
                    case 1:
                      enumerator.Dispose();
                      num5 = (short) 0;
                      num4 = (int) (IntPtr) num5;
                      continue;
                    case 2:
                      switch (0)
                      {
                        case 0:
                          goto label_18;
                        default:
                          continue;
                      }
                    default:
label_18:
                      if (enumerator == null)
                        goto case 0;
                      break;
                  }
                  num5 = (short) 1;
                  num4 = (int) (IntPtr) num5;
                }
label_22:
                num5 = (short) 0;
                if (num5 == (short) 0)
                  ;
              }
label_25:
              A_0.RecSet.Add(this.rptRec);
              num1 = (short) 1;
              num2 = (int) (IntPtr) num1;
              continue;
            case 1:
              goto label_26;
            case 2:
              this.rptRec = new _RecSet();
              ++this.count;
              this.rptRec.RecTitle = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("첄쎆횈얊첌\uD98E\uD890풒풔쎖킘풚펜\uDC9E\uEEA0\uEDA2\uF1A4\uF5A6\uE6A8\uE7AAﺬ", A_1), this.ci);
              this.rptRec.RecNo = this.count.ToString();
              enumerator = ((Collection<FeatureNode>) this.g).GetEnumerator();
              num1 = (short) 0;
              num2 = (int) (IntPtr) num1;
              continue;
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
            num1 = (short) 2;
            num2 = (int) (IntPtr) num1;
          }
          else
            break;
        }
        break;
label_26:
        num1 = (short) 0;
        break;
    }
  }

  private void a(ref _table A_0)
  {
    int A_1 = 0;
label_1:
    short num1 = 0;
    num1 = (short) 0;
    switch (num1)
    {
      default:
        num1 = (short) 4;
        int num2 = (int) (IntPtr) num1;
        while (true)
        {
          string str1;
          string indexA41424UiValue;
          IAcpFeatureNode iacpFeatureNode;
          DataButtonInnerSection buttonInnerSection;
          string str2;
          string indexA41423UiValue;
          switch (num2)
          {
            case 0:
              str2 = str2 + this.indexSeparator + indexA41423UiValue;
              num1 = (short) 2;
              num2 = (int) (IntPtr) num1;
              continue;
            case 1:
              if (str2 == AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("쪂솄\uD886좈좊\uD98C욎\uDE90\uDD92횔\uD896힘좚튜펞\uE8A0\uE7A2\uE4A4\uF3A6\uE0A8\uE4AA\uE3AC", A_1), this.ci))
              {
                num1 = (short) 0;
                num2 = (int) (IntPtr) num1;
                continue;
              }
              goto case 2;
            case 2:
              num1 = (short) 6;
              num2 = (int) (IntPtr) num1;
              continue;
            case 3:
              this.AddMultiValueByRTL(new bool?(!((AcpFieldBase) buttonInnerSection.RadErgoCfgKMTrunkingKMDatatButtonFeature_A22605).HiddenStatic), new bool?(!((AcpFieldBase) buttonInnerSection.RadErgoCfgKMConventionalKMDatatButtonFeature_A22603).HiddenStatic), str1.ToString(), str2.ToString(), ref this.rptFields);
              this.rptFields.UIFieldName = ((AcpFieldBase) (iacpFeatureNode[10209] as DataButtonInnerSection).RadErgoCfgKMDataButtonName_A22601).UIName.ToString();
              this.rptFields.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("쪂솄\uD886춈쪊\uD98C캎펐욒솔쎖횘햚슜꺞", A_1), this.ci);
              this.rptRec.UIFields.Add(this.rptFields);
              A_0.RecSet.Add(this.rptRec);
              num1 = (short) 5;
              num2 = (int) (IntPtr) num1;
              continue;
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
              goto label_20;
            case 6:
              if (str1 == AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("쪂솄\uD886좈좊\uD98C욎\uDE90\uDD92횔\uD896힘좚튜펞\uE8A0\uE7A2\uE4A4\uF3A6\uE0A8\uE4AA\uE3AC", A_1), this.ci))
              {
                num1 = (short) 7;
                num2 = (int) (IntPtr) num1;
                continue;
              }
              goto case 3;
            case 7:
              num1 = (short) -26145;
              int num3 = (int) num1;
              num1 = (short) -26145;
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
                  str1 = str1 + this.indexSeparator + indexA41424UiValue;
                  num1 = (short) 3;
                  num2 = (int) (IntPtr) num1;
                  continue;
              }
            case 8:
              this.rptRec = new _RecSet();
              this.rptFields = new _UIFields();
              int num5 = this.count++;
              _RecSet rptRec1 = this.rptRec;
              string noprintId = AppResources.NOPRINT_Id;
              num5 = this.count;
              string str3 = num5.ToString();
              string str4 = noprintId + str3;
              rptRec1.RecTitle = str4;
              _RecSet rptRec2 = this.rptRec;
              num5 = this.count;
              string str5 = num5.ToString();
              rptRec2.RecNo = str5;
              iacpFeatureNode = ((Recordset) this.e)[0];
              buttonInnerSection = iacpFeatureNode[10209] as DataButtonInnerSection;
              int featureA22603Value = buttonInnerSection.RadErgoCfgKMConventionalKMDatatButtonFeature_A22603Value;
              int featureA22605Value = buttonInnerSection.RadErgoCfgKMTrunkingKMDatatButtonFeature_A22605Value;
              str2 = (string) ((AcpFieldX<int, string>) buttonInnerSection.RadErgoCfgKMConventionalKMDatatButtonFeature_A22603).Converter.Convert((object) featureA22603Value, (Type) null, (object) null, this.ci);
              str1 = (string) ((AcpFieldX<int, string>) buttonInnerSection.RadErgoCfgKMTrunkingKMDatatButtonFeature_A22605).Converter.Convert((object) featureA22605Value, (Type) null, (object) null, this.ci);
              indexA41423UiValue = buttonInnerSection.RadErgoCfgKMConventionalKMDatatButtonIndex_A41423_UIValue;
              indexA41424UiValue = buttonInnerSection.RadErgoCfgKMTrunkingKMDatatButtonIndex_A41424_UIValue;
              num1 = (short) 1;
              num2 = (int) (IntPtr) num1;
              continue;
          }
          if (this.e != null)
          {
            num1 = (short) 8;
            num2 = (int) (IntPtr) num1;
          }
          else
            break;
        }
label_20:
        num1 = (short) 1;
        if (num1 == (short) 0)
          break;
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
        this.AddGeneral(ref XMLRptDataObj);
        this.rptTable = new _table();
        this.acpr = new AcpReports();
        this.CreateTableHeader(ref this.rptTable);
        num2 = (short) 2;
        num1 = (int) (IntPtr) num2;
        goto default;
      default:
        while (true)
        {
          switch (num1)
          {
            case 0:
              goto label_9;
            case 1:
label_8:
              this.e(ref this.rptTable);
              this.d(ref this.rptTable);
              this.c(ref this.rptTable);
              this.b(ref this.rptTable);
              this.a(ref this.rptTable);
              this.AddKeypadButton(ref this.rptTable);
              num2 = (short) 0;
              num1 = (int) (IntPtr) num2;
              continue;
            case 2:
              if (UtilityMack.IsMobile())
              {
                num2 = (short) 1;
                if (num2 == (short) 0)
                  ;
                num2 = (short) 1265;
                int num3 = (int) num2;
                num2 = (short) 1265;
                int num4 = (int) num2;
                switch (num3 == num4 ? 1 : 0)
                {
                  case 0:
                  case 2:
                    goto label_8;
                  default:
                    num2 = (short) 0;
                    if (num2 == (short) 0)
                      ;
                    num2 = (short) 1;
                    num1 = (int) (IntPtr) num2;
                    continue;
                }
              }
              else
                goto label_10;
            default:
              goto label_2;
          }
        }
label_9:
        num2 = (short) 0;
label_10:
        XMLRptDataObj.tables.Add(this.rptTable);
        this.AddZonesAndChannels(ref XMLRptDataObj);
        break;
    }
  }
}
