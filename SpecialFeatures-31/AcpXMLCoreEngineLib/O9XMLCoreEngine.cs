// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.ACPXMLCoreEngineLib.O9XMLCoreEngine
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using AcpBusinessLayer;
using AcpCommonLib;
using CommonResources;
using ConstraintHelper;
using Motorola.MackinawCPS.CoreFeatures.ControlHeadO9;
using SpecialFeatures.AcpReportManagerLib;
using SpecialFeatures.AcpXMLCoreEngineLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;

#nullable disable
namespace SpecialFeatures.ACPXMLCoreEngineLib;

public class O9XMLCoreEngine : BaseHandOutXMLCoreEngine
{
  private ResponseSelectorListInnerRecset a;
  private DirectionalButtonsListInnerRecset b;
  private O9InnerRecset c;
  private O9DataButtonInnerRecset d;
  private O9NavigationControlsTableInnerRecset e;
  private BottomFunctionProgrammableButtonInnerRecset f;
  private PASirenButtonsListInnerRecset g;

  protected override void KeypadButtonSequenceRTL(
    bool? condition1,
    bool? condition2,
    string value1,
    string value2,
    ref _UIFields rptField)
  {
    short num1 = 0;
    num1 = (short) 22775;
    int num2 = (int) num1;
    num1 = (short) 22775;
    int num3 = (int) num1;
    switch (num2 == num3)
    {
      case true:
        num1 = (short) 1;
        if (num1 == (short) 0)
          ;
        num1 = (short) 0;
        if (num1 == (short) 0)
          ;
        base.KeypadButtonSequenceRTL(new bool?(false), condition2, value1, value2, ref rptField);
        break;
      default:
        goto case 1;
    }
  }

  public O9XMLCoreEngine()
  {
    IAcpFeatureNode iacpFeatureNode = FeatureManager.GetFeature(4003)[0];
    if (!(FeatureManager.GetFeature(4003) is ControlHeadO9Recset feature))
      return;
    this.a = ((Recordset) feature)[0][10624].EmbeddedRecset as ResponseSelectorListInnerRecset;
    this.b = ((Recordset) feature)[0][10609].EmbeddedRecset as DirectionalButtonsListInnerRecset;
    this.c = ((Recordset) feature)[0][10626].EmbeddedRecset as O9InnerRecset;
    this.d = ((Recordset) feature)[0][10611].EmbeddedRecset as O9DataButtonInnerRecset;
    this.e = ((Recordset) feature)[0][10731].EmbeddedRecset as O9NavigationControlsTableInnerRecset;
    this.f = ((Recordset) feature)[0][10618].EmbeddedRecset as BottomFunctionProgrammableButtonInnerRecset;
    this.g = ((Recordset) feature)[0][10743].EmbeddedRecset as PASirenButtonsListInnerRecset;
  }

  private void g(ref _table A_0)
  {
    int A_1 = 7;
    switch (0)
    {
      default:
        int num1 = 1;
        while (true)
        {
          short num2;
          IEnumerator<FeatureNode> enumerator;
          switch (num1)
          {
            case 0:
              num2 = (short) -27415;
              int num3 = (int) num2;
              num2 = (short) -27415;
              int num4 = (int) num2;
              switch (num3 == num4 ? 1 : 0)
              {
                case 0:
                case 2:
                  continue;
                default:
                  num2 = (short) 0;
                  if (num2 == (short) 0)
                    ;
                  this.rptRec = new _RecSet();
                  int num5 = this.count++;
                  this.rptRec.RecTitle = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uD889\uE98Bﶍ\uE08F\uFD91望\uE595ﶗ얙쾛ﮝ첟잡잣튥잧\uD8A9", A_1), this.ci);
                  _RecSet rptRec = this.rptRec;
                  num5 = this.count;
                  string str1 = num5.ToString();
                  rptRec.RecNo = str1;
                  enumerator = ((Collection<FeatureNode>) this.a).GetEnumerator();
                  num2 = (short) 3;
                  num1 = (int) (IntPtr) num2;
                  continue;
              }
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
              goto label_33;
            case 3:
              try
              {
                num2 = (short) 1;
                int num6 = (int) (IntPtr) num2;
                while (true)
                {
                  ResponseSelectorListInnerSection listInnerSection;
                  string str2;
                  string indexA36685UiValue;
                  string str3;
                  switch (num6)
                  {
                    case 0:
                      if (enumerator.MoveNext())
                      {
                        FeatureNode current = enumerator.Current;
                        this.rptFields = new _UIFields();
                        listInnerSection = ((IAcpFeatureNode) current)[10625] as ResponseSelectorListInnerSection;
                        int actionA36684Value = listInnerSection.CHO9PursuitKnobAction_A36684Value;
                        int indexA36685Value = listInnerSection.CHO9PursuitKnobIndex_A36685Value;
                        str2 = (string) ((AcpFieldX<int, string>) listInnerSection.CHO9PursuitKnobAction_A36684).Converter.Convert((object) actionA36684Value, (Type) null, (object) null, this.ci);
                        indexA36685UiValue = listInnerSection.CHO9PursuitKnobIndex_A36685_UIValue;
                        str3 = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("쎉좋톍얏\uDC91햓얕쮗펙\uDB9B킝\uE59F\uE6A1", A_1), Thread.CurrentThread.CurrentCulture);
                        str3 = RptMgrErrorHandler.b("뚉", A_1) + str3 + RptMgrErrorHandler.b("뒉", A_1);
                        num2 = (short) 8;
                        num6 = (int) (IntPtr) num2;
                        continue;
                      }
                      num2 = (short) 2;
                      num6 = (int) (IntPtr) num2;
                      continue;
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
                      num2 = (short) 7;
                      num6 = (int) (IntPtr) num2;
                      continue;
                    case 3:
                      indexA36685UiValue = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("쎉좋톍얏\uDC91햓얕쮗펙\uDB9B킝\uE59F\uE6A1", A_1), this.ci);
                      num2 = (short) 10;
                      num6 = (int) (IntPtr) num2;
                      continue;
                    case 5:
                      this.rptFields.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("쎉좋톍\uDD8F\uDD91킓펕", A_1), this.ci);
                      num2 = (short) 9;
                      num6 = (int) (IntPtr) num2;
                      continue;
                    case 6:
                      if (string.IsNullOrEmpty(this.rptFields.UIFieldDes))
                      {
                        num2 = (short) 5;
                        num6 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 9;
                    case 7:
                      goto label_34;
                    case 8:
                      if (indexA36685UiValue == str3)
                      {
                        num2 = (short) 3;
                        num6 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 10;
                    case 9:
                      this.rptRec.UIFields.Add(this.rptFields);
                      num2 = (short) 4;
                      num6 = (int) (IntPtr) num2;
                      continue;
                    case 10:
                      this.AddMultiValueByRTL(new bool?(listInnerSection.CHO9PursuitKnobIndex_A36685_Applicable), new bool?(), indexA36685UiValue.ToString(), str2.ToString(), ref this.rptFields);
                      this.rptFields.UIFieldName = ((AcpFieldBase) listInnerSection.CHO9PursuitKnobMode_A36683).UIName.ToString();
                      string uiName = listInnerSection.CHO9PursuitKnobMode_A36683_UIValue.ToString();
                      this.AddUiFieldDescByCondition(ref this.rptFields, uiName, AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("쎉좋톍\uDD8F\uDD91킓펕ꢗ", A_1), Thread.CurrentThread.CurrentCulture), AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("쎉좋톍\uDD8F\uDD91킓펕ꢗ", A_1), this.ci));
                      this.AddUiFieldDescByCondition(ref this.rptFields, uiName, AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("쎉좋톍\uDD8F\uDD91킓펕ꦗ", A_1), Thread.CurrentThread.CurrentCulture), AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("쎉좋톍\uDD8F\uDD91킓펕ꦗ", A_1), this.ci));
                      this.AddUiFieldDescByCondition(ref this.rptFields, uiName, AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("쎉좋톍\uDD8F\uDD91킓펕ꪗ", A_1), Thread.CurrentThread.CurrentCulture), AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("쎉좋톍\uDD8F\uDD91킓펕ꪗ", A_1), this.ci));
                      this.AddUiFieldDescByCondition(ref this.rptFields, uiName, AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("쎉좋톍\uDD8F\uDD91킓펕ꮗ", A_1), Thread.CurrentThread.CurrentCulture), AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("쎉좋톍\uDD8F\uDD91킓펕ꮗ", A_1), this.ci));
                      num2 = (short) 6;
                      num6 = (int) (IntPtr) num2;
                      continue;
                  }
                  num2 = (short) 0;
                  num6 = (int) (IntPtr) num2;
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
                      enumerator.Dispose();
                      num8 = (short) 2;
                      num7 = (int) (IntPtr) num8;
                      continue;
                    case 2:
                      goto label_31;
                  }
                  if (enumerator != null)
                  {
                    num8 = (short) 1;
                    num7 = (int) (IntPtr) num8;
                  }
                  else
                    break;
                }
label_31:;
              }
label_34:
              A_0.RecSet.Add(this.rptRec);
              num2 = (short) 2;
              num1 = (int) (IntPtr) num2;
              continue;
          }
          num2 = (short) 1;
          if (num2 == (short) 0)
            ;
          num2 = (short) 0;
          if (this.a != null)
          {
            num2 = (short) 0;
            num1 = (int) (IntPtr) num2;
          }
          else
            goto label_35;
        }
label_33:
        break;
label_35:
        break;
    }
  }

  private void f(ref _table A_0)
  {
    int A_1 = 2;
    switch (0)
    {
      default:
        int num1 = 1;
        while (true)
        {
          short num2;
          IEnumerator<FeatureNode> enumerator;
          switch (num1)
          {
            case 0:
              num2 = (short) 1;
              if (num2 == (short) 0)
                ;
              num2 = (short) 31707;
              int num3 = (int) num2;
              num2 = (short) 31707;
              int num4 = (int) num2;
              switch (num3 == num4 ? 1 : 0)
              {
                case 0:
                case 2:
                  continue;
                default:
                  num2 = (short) 0;
                  if (num2 == (short) 0)
                    ;
                  this.rptRec = new _RecSet();
                  ++this.count;
                  this.rptRec.RecTitle = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("솄\uEE86ﮈ\uEE8A\uEE8Cﮎ\uF890ﲒﮔ\uF696\uF598쒚\uDF9C\uEA9E햠힢쪤즦\uDAA8", A_1), this.ci);
                  this.rptRec.RecNo = this.count.ToString();
                  enumerator = ((Collection<FeatureNode>) this.b).GetEnumerator();
                  num2 = (short) 3;
                  num1 = (int) (IntPtr) num2;
                  continue;
              }
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
              goto label_33;
            case 3:
              try
              {
                num2 = (short) 1;
                int num5 = (int) (IntPtr) num2;
                while (true)
                {
                  DirectionalButtonsListInnerSection listInnerSection;
                  string str1;
                  string indexA36601UiValue;
                  string str2;
                  switch (num5)
                  {
                    case 0:
                      if (enumerator.MoveNext())
                      {
                        FeatureNode current = enumerator.Current;
                        this.rptFields = new _UIFields();
                        listInnerSection = ((IAcpFeatureNode) current)[10610] as DirectionalButtonsListInnerSection;
                        int featureA36597Value = listInnerSection.RadErgCtrlHeadO9DirLightBarFeature_A36597Value;
                        int indexA36601Value = listInnerSection.RadErgCtrlHeadO9DirLightBarIndex_A36601Value;
                        str1 = (string) ((AcpFieldX<int, string>) listInnerSection.RadErgCtrlHeadO9DirLightBarFeature_A36597).Converter.Convert((object) featureA36597Value, (Type) null, (object) null, this.ci);
                        indexA36601UiValue = listInnerSection.RadErgCtrlHeadO9DirLightBarIndex_A36601_UIValue;
                        str2 = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("첄쎆횈\uDE8A쎌캎슐삒\uDC94킖힘\uDE9A\uD99C", A_1), Thread.CurrentThread.CurrentCulture);
                        str2 = RptMgrErrorHandler.b("름", A_1) + str2 + RptMgrErrorHandler.b("뮄", A_1);
                        num2 = (short) 8;
                        num5 = (int) (IntPtr) num2;
                        continue;
                      }
                      num2 = (short) 2;
                      num5 = (int) (IntPtr) num2;
                      continue;
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
                      num2 = (short) 7;
                      num5 = (int) (IntPtr) num2;
                      continue;
                    case 3:
                      indexA36601UiValue = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("첄쎆횈\uDE8A쎌캎슐삒\uDC94킖힘\uDE9A\uD99C", A_1), this.ci);
                      num2 = (short) 10;
                      num5 = (int) (IntPtr) num2;
                      continue;
                    case 5:
                      this.rptFields.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("첄쎆횈쾊쒌\uDD8E풐킒솔\uDE96횘햚\uDC9C펞\uE3A0\uF6A2\uF1A4\uF3A6\uE6A8\uE5AAﺬ", A_1), this.ci);
                      num2 = (short) 9;
                      num5 = (int) (IntPtr) num2;
                      continue;
                    case 6:
                      if (string.IsNullOrEmpty(this.rptFields.UIFieldDes))
                      {
                        num2 = (short) 5;
                        num5 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 9;
                    case 7:
                      goto label_34;
                    case 8:
                      if (indexA36601UiValue == str2)
                      {
                        num2 = (short) 3;
                        num5 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 10;
                    case 9:
                      this.rptRec.UIFields.Add(this.rptFields);
                      num2 = (short) 4;
                      num5 = (int) (IntPtr) num2;
                      continue;
                    case 10:
                      this.AddMultiValueByRTL(new bool?(), new bool?(), indexA36601UiValue.ToString(), str1.ToString(), ref this.rptFields);
                      this.rptFields.UIFieldName = ((AcpFieldBase) listInnerSection.RadErgCtrlHeadO9DirLightBarName_A36558).UIName.ToString();
                      string uiName = listInnerSection.RadErgCtrlHeadO9DirLightBarName_A36558_UIValue.ToString();
                      this.AddUiFieldDescByCondition(ref this.rptFields, uiName, AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("첄쎆횈\uDF8A슌\uDF8E튐횒\uDB94쎖\uDC98즚", A_1), Thread.CurrentThread.CurrentCulture), AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("첄쎆횈\uDF8A슌\uDF8E튐횒\uDB94쎖\uDC98즚", A_1), this.ci));
                      this.AddUiFieldDescByCondition(ref this.rptFields, uiName, AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("첄쎆횈잊좌즎얐", A_1), Thread.CurrentThread.CurrentCulture), AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("첄쎆횈잊좌즎얐", A_1), this.ci));
                      this.AddUiFieldDescByCondition(ref this.rptFields, uiName, AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("첄쎆횈\uD98A쒌좎\uD990잒", A_1), Thread.CurrentThread.CurrentCulture), AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("첄쎆횈\uD98A쒌좎\uD990잒", A_1), this.ci));
                      num2 = (short) 6;
                      num5 = (int) (IntPtr) num2;
                      continue;
                  }
                  num2 = (short) 0;
                  num5 = (int) (IntPtr) num2;
                }
              }
              finally
              {
                int num6 = 0;
                while (true)
                {
                  short num7;
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
                      enumerator.Dispose();
                      num7 = (short) 2;
                      num6 = (int) (IntPtr) num7;
                      continue;
                    case 2:
                      goto label_31;
                  }
                  if (enumerator != null)
                  {
                    num7 = (short) 1;
                    num6 = (int) (IntPtr) num7;
                  }
                  else
                    break;
                }
label_31:;
              }
label_34:
              A_0.RecSet.Add(this.rptRec);
              num2 = (short) 2;
              num1 = (int) (IntPtr) num2;
              continue;
          }
          if (this.b != null)
          {
            num2 = (short) 0;
            num2 = (short) 0;
            num1 = (int) (IntPtr) num2;
          }
          else
            goto label_35;
        }
label_33:
        break;
label_35:
        break;
    }
  }

  private void e(ref _table A_0)
  {
    int A_1 = 9;
label_1:
    short num1 = 0;
    switch (num1)
    {
      default:
        num1 = (short) 0;
        int num2 = (int) (IntPtr) num1;
        while (true)
        {
          switch (num2)
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
              this.rptRec = new _RecSet();
              this.rptFields = new _UIFields();
              int num3 = this.count++;
              _RecSet rptRec1 = this.rptRec;
              string noprintId = AppResources.NOPRINT_Id;
              num3 = this.count;
              string str1 = num3.ToString();
              string str2 = noprintId + str1;
              rptRec1.RecTitle = str2;
              _RecSet rptRec2 = this.rptRec;
              num3 = this.count;
              string str3 = num3.ToString();
              rptRec2.RecNo = str3;
              O9InnerSection o9InnerSection = ((Recordset) this.c)[0][10627] as O9InnerSection;
              int featureA36682Value = o9InnerSection.CHO9EmergencyButtonFeature_A36682Value;
              string str4 = (string) ((AcpFieldX<int, string>) o9InnerSection.CHO9EmergencyButtonFeature_A36682).Converter.Convert((object) featureA36682Value, (Type) null, (object) null, this.ci);
              this.AddFieldValue(ref this.rptFields, str4.ToString());
              this.AddFieldValue(ref this.rptFields, str4.ToString());
              this.rptFields.UIFieldName = ((AcpFieldBase) o9InnerSection.CHO9EmergencyButtonName_A36680).UIName.ToString();
              this.rptFields.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("얋쪍쾏\uDD91욓힕횗\uDD99\uD99B\uDC9D\uF59F\uF6A1\uF0A3\uE9A5\uE6A7", A_1), this.ci);
              this.rptRec.UIFields.Add(this.rptFields);
              A_0.RecSet.Add(this.rptRec);
              num1 = (short) 2;
              num2 = (int) (IntPtr) num1;
              continue;
            case 2:
              goto label_10;
          }
          num1 = (short) 0;
          num1 = (short) -19050;
          int num4 = (int) num1;
          num1 = (short) -19050;
          int num5 = (int) num1;
          switch (num4 == num5 ? 1 : 0)
          {
            case 0:
            case 2:
              goto label_1;
            default:
              num1 = (short) 0;
              if (num1 == (short) 0)
                ;
              if (this.c != null)
              {
                num1 = (short) 1;
                if (num1 == (short) 0)
                  ;
                num1 = (short) 1;
                num2 = (int) (IntPtr) num1;
                continue;
              }
              goto label_12;
          }
        }
label_10:
        break;
label_12:
        break;
    }
  }

  private void d(ref _table A_0)
  {
    int A_1 = 13;
    switch (0)
    {
      default:
        short num1 = 1;
        int num2 = (int) (IntPtr) num1;
        while (true)
        {
          IEnumerator<FeatureNode> enumerator;
          switch (num2)
          {
            case 0:
              num1 = (short) -16144;
              int num3 = (int) num1;
              num1 = (short) -16144;
              int num4 = (int) num1;
              switch (num3 == num4 ? 1 : 0)
              {
                case 0:
                case 2:
                  continue;
                default:
                  num1 = (short) 0;
                  if (num1 == (short) 0)
                    ;
                  this.rptRec = new _RecSet();
                  int num5 = this.count++;
                  this.rptRec.RecTitle = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("튏\uFD91\uE093\uE295\uF797\uF799쎛\uDC9D햟횡킣즥욧\uD9A9", A_1), this.ci);
                  _RecSet rptRec = this.rptRec;
                  num5 = this.count;
                  string str1 = num5.ToString();
                  rptRec.RecNo = str1;
                  enumerator = ((Collection<FeatureNode>) this.f).GetEnumerator();
                  num1 = (short) 3;
                  num2 = (int) (IntPtr) num1;
                  continue;
              }
            case 1:
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
            case 2:
              goto label_51;
            case 3:
              try
              {
                num1 = (short) 0;
                int num6 = (int) (IntPtr) num1;
                while (true)
                {
                  string str2;
                  BottomFunctionProgrammableButtonInnerSection buttonInnerSection;
                  string fieldValue1;
                  string str3;
                  string fieldValue2;
                  string str4;
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
                      this.rptRec.UIFields.Add(this.rptFields);
                      num1 = (short) 22;
                      num6 = (int) (IntPtr) num1;
                      continue;
                    case 2:
                      if (buttonInnerSection.CHO9BottomFunctionButtonIndex_A36665_Applicable)
                      {
                        num1 = (short) 18;
                        num6 = (int) (IntPtr) num1;
                        continue;
                      }
                      this.AddFieldValue(ref this.rptFields, "");
                      num1 = (short) 3;
                      num6 = (int) (IntPtr) num1;
                      continue;
                    case 3:
                    case 12:
                    case 23:
                      this.AddFieldValue(ref this.rptFields, str3.ToString());
                      num1 = (short) 15;
                      num6 = (int) (IntPtr) num1;
                      continue;
                    case 4:
                      str2 = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uD98F횑쮓쎕횗\uDB99쾛춝\uE99F\uE5A1\uEAA3\uE3A5\uECA7", A_1), Thread.CurrentThread.CurrentCulture);
                      str2 = RptMgrErrorHandler.b("겏", A_1) + str2 + RptMgrErrorHandler.b("꺏", A_1);
                      fieldValue1 = buttonInnerSection.CHO9BottomFunctionButtonIndex_A36665_UIValue.ToString();
                      num1 = (short) 14;
                      num6 = (int) (IntPtr) num1;
                      continue;
                    case 5:
                    case 15:
                    case 16 /*0x10*/:
                    case 19:
                      this.rptFields.UIFieldName = ((AcpFieldBase) buttonInnerSection.CHO9BottomFunctionButtonName_A36657).UIName.ToString();
                      string uiName = buttonInnerSection.CHO9BottomFunctionButtonName_A36657_UIValue.ToString();
                      this.AddUiFieldDescByCondition(ref this.rptFields, uiName, AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uD98F횑쮓욕ꦗ", A_1), Thread.CurrentThread.CurrentCulture), AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uD98F횑쮓욕ꦗ", A_1), this.ci));
                      this.AddUiFieldDescByCondition(ref this.rptFields, uiName, AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("삏ꂑ쮓\uDF95ﲗ", A_1), Thread.CurrentThread.CurrentCulture), AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("삏ꂑ쮓\uDF95ﲗ", A_1), this.ci));
                      this.AddUiFieldDescByCondition(ref this.rptFields, uiName, AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("삏ꆑ쮓\uDF95ﲗ", A_1), Thread.CurrentThread.CurrentCulture), AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("삏ꆑ쮓\uDF95ﲗ", A_1), this.ci));
                      this.AddUiFieldDescByCondition(ref this.rptFields, uiName, AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("삏ꚑ쮓\uDF95ﲗ", A_1), Thread.CurrentThread.CurrentCulture), AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("삏ꚑ쮓\uDF95ﲗ", A_1), this.ci));
                      this.AddUiFieldDescByCondition(ref this.rptFields, uiName, AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("삏ꞑ쮓\uDF95ﲗ", A_1), Thread.CurrentThread.CurrentCulture), AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("삏ꞑ쮓\uDF95ﲗ", A_1), this.ci));
                      num1 = (short) 9;
                      num6 = (int) (IntPtr) num1;
                      continue;
                    case 6:
                      if (buttonInnerSection.CHO9BottomFunctionButtonIndex_A36665_Applicable)
                      {
                        num1 = (short) 4;
                        num6 = (int) (IntPtr) num1;
                        continue;
                      }
                      this.AddFieldValue(ref this.rptFields, "");
                      num1 = (short) 19;
                      num6 = (int) (IntPtr) num1;
                      continue;
                    case 7:
                      if (fieldValue2 == str4)
                      {
                        num1 = (short) 24;
                        num6 = (int) (IntPtr) num1;
                        continue;
                      }
                      this.AddFieldValue(ref this.rptFields, buttonInnerSection.CHO9BottomFunctionButtonIndex_A36665_UIValue.ToString());
                      num1 = (short) 23;
                      num6 = (int) (IntPtr) num1;
                      continue;
                    case 8:
                      num1 = (short) 11;
                      num6 = (int) (IntPtr) num1;
                      continue;
                    case 9:
                      if (string.IsNullOrEmpty(this.rptFields.UIFieldDes))
                      {
                        num1 = (short) 20;
                        num6 = (int) (IntPtr) num1;
                        continue;
                      }
                      goto case 1;
                    case 10:
                      this.AddFieldValue(ref this.rptFields, str3.ToString());
                      num1 = (short) 6;
                      num6 = (int) (IntPtr) num1;
                      continue;
                    case 11:
                      goto label_52;
                    case 13:
                      if (!enumerator.MoveNext())
                      {
                        num1 = (short) 8;
                        num6 = (int) (IntPtr) num1;
                        continue;
                      }
                      FeatureNode current = enumerator.Current;
                      this.rptFields = new _UIFields();
                      buttonInnerSection = ((IAcpFeatureNode) current)[10619] as BottomFunctionProgrammableButtonInnerSection;
                      int featureA36664Value = buttonInnerSection.CHO9BottomFunctionButtonFeature_A36664Value;
                      str3 = (string) ((AcpFieldX<int, string>) buttonInnerSection.CHO9BottomFunctionButtonFeature_A36664).Converter.Convert((object) featureA36664Value, (Type) null, (object) null, this.ci);
                      num1 = (short) 17;
                      num6 = (int) (IntPtr) num1;
                      continue;
                    case 14:
                      if (fieldValue1 == str2)
                      {
                        num1 = (short) 21;
                        num6 = (int) (IntPtr) num1;
                        continue;
                      }
                      this.AddFieldValue(ref this.rptFields, buttonInnerSection.CHO9BottomFunctionButtonIndex_A36665_UIValue.ToString());
                      num1 = (short) 5;
                      num6 = (int) (IntPtr) num1;
                      continue;
                    case 17:
                      if (this.isRTL)
                      {
                        num1 = (short) 2;
                        num6 = (int) (IntPtr) num1;
                        continue;
                      }
                      num1 = (short) 10;
                      num6 = (int) (IntPtr) num1;
                      continue;
                    case 18:
                      str4 = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uD98F횑쮓쎕횗\uDB99쾛춝\uE99F\uE5A1\uEAA3\uE3A5\uECA7", A_1), Thread.CurrentThread.CurrentCulture);
                      str4 = RptMgrErrorHandler.b("겏", A_1) + str4 + RptMgrErrorHandler.b("꺏", A_1);
                      fieldValue2 = buttonInnerSection.CHO9BottomFunctionButtonIndex_A36665_UIValue.ToString();
                      num1 = (short) 7;
                      num6 = (int) (IntPtr) num1;
                      continue;
                    case 20:
                      this.rptFields.UIFieldDes = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("튏\uFD91\uE093\uE295\uF797\uF799쎛\uDC9D햟횡킣즥욧\uF5A9\uE5AB\uEAAD", A_1), this.ci);
                      num1 = (short) 1;
                      num6 = (int) (IntPtr) num1;
                      continue;
                    case 21:
                      fieldValue1 = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uD98F횑쮓쎕횗\uDB99쾛춝\uE99F\uE5A1\uEAA3\uE3A5\uECA7", A_1), this.ci);
                      this.AddFieldValue(ref this.rptFields, fieldValue1);
                      num1 = (short) 16 /*0x10*/;
                      num6 = (int) (IntPtr) num1;
                      continue;
                    case 24:
                      fieldValue2 = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uD98F횑쮓쎕횗\uDB99쾛춝\uE99F\uE5A1\uEAA3\uE3A5\uECA7", A_1), this.ci);
                      this.AddFieldValue(ref this.rptFields, fieldValue2);
                      num1 = (short) 12;
                      num6 = (int) (IntPtr) num1;
                      continue;
                  }
                  num1 = (short) 13;
                  num6 = (int) (IntPtr) num1;
                }
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
                      enumerator.Dispose();
                      num7 = (short) 2;
                      num8 = (int) (IntPtr) num7;
                      continue;
                    case 2:
                      goto label_49;
                  }
                  if (enumerator != null)
                  {
                    num7 = (short) 1;
                    num8 = (int) (IntPtr) num7;
                  }
                  else
                    break;
                }
label_49:;
              }
label_52:
              A_0.RecSet.Add(this.rptRec);
              num1 = (short) 2;
              num2 = (int) (IntPtr) num1;
              continue;
          }
          num1 = (short) 0;
          if (this.f != null)
          {
            num1 = (short) 0;
            num2 = (int) (IntPtr) num1;
          }
          else
            goto label_53;
        }
label_51:
        break;
label_53:
        break;
    }
  }

  private void c(ref _table A_0)
  {
    int A_1 = 8;
    short num1 = 1;
    if (num1 == (short) 0)
      ;
    num1 = (short) 0;
    switch (num1)
    {
      default:
        num1 = (short) 1;
        int num2 = (int) (IntPtr) num1;
        while (true)
        {
          IEnumerator<FeatureNode> enumerator;
          switch (num2)
          {
            case 0:
              num1 = (short) 4141;
              int num3 = (int) num1;
              num1 = (short) 4141;
              int num4 = (int) num1;
              switch (num3 == num4 ? 1 : 0)
              {
                case 0:
                case 2:
                  continue;
                default:
                  num1 = (short) 0;
                  if (num1 == (short) 0)
                    ;
                  this.rptRec = new _RecSet();
                  int num5 = this.count++;
                  this.rptRec.RecTitle = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("슊즌킎\uDF90튒쎔\uDE96\uDE98\uDA9A즜횞\uEEA0\uEDA2\uE6A4\uE8A6\uE7A8ﾪﾬ\uE0AEﶰ\uE0B2", A_1), this.ci);
                  _RecSet rptRec = this.rptRec;
                  num5 = this.count;
                  string str1 = num5.ToString();
                  rptRec.RecNo = str1;
                  enumerator = ((Collection<FeatureNode>) this.e).GetEnumerator();
                  num1 = (short) 3;
                  num2 = (int) (IntPtr) num1;
                  continue;
              }
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
              goto label_25;
            case 3:
              try
              {
                num1 = (short) 2;
                int num6 = (int) (IntPtr) num1;
                while (true)
                {
                  switch (num6)
                  {
                    case 1:
                      if (enumerator.MoveNext())
                      {
                        FeatureNode current = enumerator.Current;
                        this.rptFields = new _UIFields();
                        O9NavigationControlsTableInnerSection tableInnerSection = ((IAcpFeatureNode) current)[10734] as O9NavigationControlsTableInnerSection;
                        int featureA41371Value = tableInnerSection.RadErgoControlO9NaviControlFeature_A41371Value;
                        string str2 = (string) ((AcpFieldX<int, string>) tableInnerSection.RadErgoControlO9NaviControlFeature_A41371).Converter.Convert((object) featureA41371Value, (Type) null, (object) null, this.ci);
                        this.AddMultiValueByRTL(new bool?(!((FeatureNode) this.refTrunking).Parent.HiddenStatic), new bool?(), str2.ToString(), str2.ToString(), ref this.rptFields);
                        this.rptFields.UIFieldName = ((AcpFieldBase) tableInnerSection.RadErgoControlO9NaviControlName_A41370).UIName.ToString();
                        string uiName = tableInnerSection.RadErgoControlO9NaviControlName_A41370_UIValue.ToString();
                        this.AddUiFieldDescByCondition(ref this.rptFields, uiName, AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("슊즌킎쒐쎒힔슖춘쾚튜톞", A_1), Thread.CurrentThread.CurrentCulture), AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("슊즌킎쒐쎒힔슖춘쾚튜톞", A_1), this.ci));
                        this.AddUiFieldDescByCondition(ref this.rptFields, uiName, AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("쾊\uE28C\uF88Eﾐ첒힔\uE296\uED98\uEF9A\uF29C\uF19E", A_1), Thread.CurrentThread.CurrentCulture), AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("쾊\uE28C\uF88Eﾐ첒힔\uE296\uED98\uEF9A\uF29C\uF19E", A_1), this.ci));
                        this.rptRec.UIFields.Add(this.rptFields);
                        num1 = (short) 0;
                        num6 = (int) (IntPtr) num1;
                        continue;
                      }
                      num1 = (short) 4;
                      num6 = (int) (IntPtr) num1;
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
                    case 3:
                      goto label_26;
                    case 4:
                      num1 = (short) 3;
                      num6 = (int) (IntPtr) num1;
                      continue;
                  }
                  num1 = (short) 1;
                  num6 = (int) (IntPtr) num1;
                }
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
                      enumerator.Dispose();
                      num7 = (short) 2;
                      num8 = (int) (IntPtr) num7;
                      continue;
                    case 2:
                      goto label_23;
                  }
                  if (enumerator != null)
                  {
                    num7 = (short) 1;
                    num8 = (int) (IntPtr) num7;
                  }
                  else
                    break;
                }
label_23:;
              }
label_26:
              A_0.RecSet.Add(this.rptRec);
              num1 = (short) 2;
              num2 = (int) (IntPtr) num1;
              continue;
          }
          num1 = (short) 0;
          if (this.e != null)
          {
            num1 = (short) 0;
            num2 = (int) (IntPtr) num1;
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

  private void b(ref _table A_0)
  {
    int A_1 = 14;
    switch (0)
    {
      default:
        int num1 = 1;
        while (true)
        {
          short num2;
          O9DataButtonInnerSection buttonInnerSection;
          string str1;
          string indexA41416UiValue;
          string str2;
          string indexA41414UiValue;
          switch (num1)
          {
            case 0:
              if (!((AcpFieldBase) buttonInnerSection.RadErgCtrlHeadO9DataButtonCnvFeature_A36528).HiddenStatic)
              {
                num2 = (short) 9;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              break;
            case 1:
              switch (0)
              {
                case 0:
                  goto label_4;
                default:
                  continue;
              }
            case 2:
              num2 = (short) 19;
              num1 = (int) (IntPtr) num2;
              continue;
            case 3:
              this.rptRec = new _RecSet();
              this.rptFields = new _UIFields();
              ++this.count;
              this.rptRec.RecTitle = AppResources.NOPRINT_Id + this.count.ToString();
              this.rptRec.RecNo = this.count.ToString();
              buttonInnerSection = ((Recordset) this.d)[0][10608] as O9DataButtonInnerSection;
              int featureA36528Value = buttonInnerSection.RadErgCtrlHeadO9DataButtonCnvFeature_A36528Value;
              int featureA36526Value = buttonInnerSection.RadErgCtrlHeadO9DataButtonTrkFeature_A36526Value;
              str2 = (string) ((AcpFieldX<int, string>) buttonInnerSection.RadErgCtrlHeadO9DataButtonCnvFeature_A36528).Converter.Convert((object) featureA36528Value, (Type) null, (object) null, this.ci);
              str1 = (string) ((AcpFieldX<int, string>) buttonInnerSection.RadErgCtrlHeadO9DataButtonTrkFeature_A36526).Converter.Convert((object) featureA36526Value, (Type) null, (object) null, this.ci);
              indexA41414UiValue = buttonInnerSection.CHO9DataButtonConvIndex_A41414_UIValue;
              indexA41416UiValue = buttonInnerSection.CHO9DataButtonTrkIndex_A41416_UIValue;
              num2 = (short) 10;
              num1 = (int) (IntPtr) num2;
              continue;
            case 4:
              num2 = (short) 1;
              if (num2 == (short) 0)
                ;
              if (!((AcpFieldBase) buttonInnerSection.RadErgCtrlHeadO9DataButtonCnvFeature_A36528).HiddenStatic)
              {
                num2 = (short) 6;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_13;
            case 5:
              this.AddFieldValue(ref this.rptFields, str2.ToString());
              this.AddFieldValue(ref this.rptFields, str1.ToString());
              num2 = (short) 25;
              num1 = (int) (IntPtr) num2;
              continue;
            case 6:
              num2 = (short) 26;
              num1 = (int) (IntPtr) num2;
              continue;
            case 7:
            case 17:
            case 20:
            case 25:
              this.rptFields.UIFieldName = ((AcpFieldBase) buttonInnerSection.RadErgCtrlHeadO9DataButtonName_A36523).UIName.ToString();
              this.rptFields.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uD890힒쪔펖\uD898쾚\uDC9C\uDD9E\uF4A0\uF7A2\uF1A4\uE8A6\uE7A8\uF4AA鲬", A_1), this.ci);
              this.rptRec.UIFields.Add(this.rptFields);
              A_0.RecSet.Add(this.rptRec);
              num2 = (short) 23;
              num1 = (int) (IntPtr) num2;
              continue;
            case 8:
              if (!((AcpFieldBase) buttonInnerSection.RadErgCtrlHeadO9DataButtonTrkFeature_A36526).HiddenStatic)
              {
                num2 = (short) 15;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              break;
            case 9:
              num2 = (short) 8;
              num1 = (int) (IntPtr) num2;
              continue;
            case 10:
              num2 = (short) 0;
              if (str2 == AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uD890힒쪔횖\uDA98쾚풜킞\uEFA0\uE0A2\uEAA4\uE9A6直\uE4AA\uE1AC\uE6AE\uF5B0\uF2B2\uE1B4ﺶ\uF6B8\uF5BA", A_1), this.ci))
              {
                num2 = (short) 13;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 2;
            case 11:
              num2 = (short) -14998;
              int num3 = (int) num2;
              num2 = (short) -14998;
              int num4 = (int) num2;
              switch (num3 == num4 ? 1 : 0)
              {
                case 0:
                case 2:
                  goto label_27;
                default:
                  num2 = (short) 0;
                  if (num2 == (short) 0)
                    ;
                  this.AddFieldValue(ref this.rptFields, "");
                  this.AddFieldValue(ref this.rptFields, str2.ToString());
                  num2 = (short) 17;
                  num1 = (int) (IntPtr) num2;
                  continue;
              }
            case 12:
              num2 = (short) 0;
              num1 = (int) (IntPtr) num2;
              continue;
            case 13:
              str2 = str2 + this.indexSeparator + indexA41414UiValue;
              num2 = (short) 2;
              num1 = (int) (IntPtr) num2;
              continue;
            case 14:
              num2 = (short) 21;
              num1 = (int) (IntPtr) num2;
              continue;
            case 15:
              this.AddFieldValue(ref this.rptFields, str1.ToString());
              this.AddFieldValue(ref this.rptFields, str2.ToString());
              num2 = (short) 7;
              num1 = (int) (IntPtr) num2;
              continue;
            case 16 /*0x10*/:
              str1 = str1 + this.indexSeparator + indexA41416UiValue;
              num2 = (short) 14;
              num1 = (int) (IntPtr) num2;
              continue;
            case 18:
              if (!((AcpFieldBase) buttonInnerSection.RadErgCtrlHeadO9DataButtonCnvFeature_A36528).HiddenStatic)
              {
                num2 = (short) 24;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 7;
            case 19:
              if (str1 == AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uD890힒쪔횖\uDA98쾚풜킞\uEFA0\uE0A2\uEAA4\uE9A6直\uE4AA\uE1AC\uE6AE\uF5B0\uF2B2\uE1B4ﺶ\uF6B8\uF5BA", A_1), this.ci))
              {
                num2 = (short) 16 /*0x10*/;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 14;
            case 21:
              if (!this.isRTL)
              {
                num2 = (short) 4;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              num2 = (short) 12;
              num1 = (int) (IntPtr) num2;
              continue;
            case 22:
              if (!((AcpFieldBase) buttonInnerSection.RadErgCtrlHeadO9DataButtonCnvFeature_A36528).HiddenStatic)
              {
                num2 = (short) 11;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 7;
            case 23:
              goto label_41;
            case 24:
              this.AddFieldValue(ref this.rptFields, str2.ToString());
              this.AddFieldValue(ref this.rptFields, "");
              goto label_27;
            case 26:
              if (!((AcpFieldBase) buttonInnerSection.RadErgCtrlHeadO9DataButtonTrkFeature_A36526).HiddenStatic)
              {
                num2 = (short) 5;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_13;
            default:
label_4:
              if (this.d != null)
              {
                num2 = (short) 3;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_45;
          }
          num2 = (short) 22;
          num1 = (int) (IntPtr) num2;
          continue;
label_13:
          num2 = (short) 18;
          num1 = (int) (IntPtr) num2;
          continue;
label_27:
          num2 = (short) 20;
          num1 = (int) (IntPtr) num2;
        }
label_41:
        break;
label_45:
        break;
    }
  }

  private void a(ref _table A_0)
  {
    int A_1 = 3;
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
              try
              {
                num2 = (short) 7;
                int num3 = (int) (IntPtr) num2;
                while (true)
                {
                  PASirenButtonsListInnerSection listInnerSection;
                  string str;
                  switch (num3)
                  {
                    case 0:
                      this.rptFields.UIFieldName = ((AcpFieldBase) listInnerSection.CHO9PASirenButtonsName_A41537).UIName;
                      string uiName = listInnerSection.CHO9PASirenButtonsName_A41537_UIValue.ToString();
                      this.AddUiFieldDescByCondition(ref this.rptFields, uiName, AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("쾅첇행\uDF8B잍슏힑\uDA93힕톗좙풛톝\uF29F\uECA1", A_1), Thread.CurrentThread.CurrentCulture), AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("쾅첇행\uDF8B잍슏힑\uDA93힕톗좙풛톝\uF29F\uECA1", A_1), this.ci));
                      this.AddUiFieldDescByCondition(ref this.rptFields, uiName, AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("쾅첇행\uDF8B잍슏힑\uDA93\uDB95\uD997풙즛\uDF9D\uEC9F", A_1), Thread.CurrentThread.CurrentCulture), AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("쾅첇행\uDF8B잍슏힑\uDA93\uDB95\uD997풙즛\uDF9D\uEC9F", A_1), this.ci));
                      this.AddUiFieldDescByCondition(ref this.rptFields, uiName, AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("쾅첇행\uDF8B잍슏힑\uDA93솕\uD997펙킛", A_1), Thread.CurrentThread.CurrentCulture), AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("쾅첇행\uDF8B잍슏힑\uDA93솕\uD997펙킛", A_1), this.ci));
                      this.AddUiFieldDescByCondition(ref this.rptFields, uiName, AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("쾅첇행\uDF8B잍슏힑\uDA93쾕\uDD97횙첛", A_1), Thread.CurrentThread.CurrentCulture), AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("쾅첇행\uDF8B잍슏힑\uDA93쾕\uDD97횙첛", A_1), this.ci));
                      this.AddUiFieldDescByCondition(ref this.rptFields, uiName, AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("즅놇행\uDF8B\uE78D\uE28F\uF791望즕킗\uF399\uF09B\uF19D", A_1), Thread.CurrentThread.CurrentCulture), AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("즅놇행\uDF8B\uE78D\uE28F\uF791望즕킗\uF399\uF09B\uF19D", A_1), this.ci));
                      this.AddUiFieldDescByCondition(ref this.rptFields, uiName, AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("즅놇행\uDF8B\uE78D\uE28F\uF791望즕좗\uDB99", A_1), Thread.CurrentThread.CurrentCulture), AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("즅놇행\uDF8B\uE78D\uE28F\uF791望즕좗\uDB99", A_1), this.ci));
                      this.rptRec.UIFields.Add(this.rptFields);
                      num2 = (short) 4;
                      num3 = (int) (IntPtr) num2;
                      continue;
                    case 1:
                      if (!((AcpFieldBase) listInnerSection.CHO9PASirenButtonsFeature_A41540).HiddenStatic)
                      {
                        num2 = (short) 5;
                        num3 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 0;
                    case 2:
                      if (enumerator.MoveNext())
                      {
                        FeatureNode current = enumerator.Current;
                        this.rptFields = new _UIFields();
                        listInnerSection = ((IAcpFeatureNode) current)[10744] as PASirenButtonsListInnerSection;
                        int featureA41540Value = listInnerSection.CHO9PASirenButtonsFeature_A41540Value;
                        str = (string) ((AcpFieldX<int, string>) listInnerSection.CHO9PASirenButtonsFeature_A41540).Converter.Convert((object) featureA41540Value, (Type) null, (object) null, this.ci);
                        num2 = (short) 1;
                        num3 = (int) (IntPtr) num2;
                        continue;
                      }
                      num2 = (short) 6;
                      num3 = (int) (IntPtr) num2;
                      continue;
                    case 3:
                      goto label_30;
                    case 5:
                      this.AddMultiValueByRTL(new bool?(), new bool?(), string.Empty, str.ToString(), ref this.rptFields);
                      num2 = (short) 0;
                      num3 = (int) (IntPtr) num2;
                      continue;
                    case 6:
                      num2 = (short) 3;
                      num3 = (int) (IntPtr) num2;
                      continue;
                    case 7:
                      switch (0)
                      {
                        case 0:
                          break;
                        default:
                          continue;
                      }
                      break;
                  }
                  num2 = (short) 2;
                  num3 = (int) (IntPtr) num2;
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
                      num5 = (short) -4283;
                      int num6 = (int) num5;
                      num5 = (short) -4283;
                      int num7 = (int) num5;
                      switch (num6 == num7 ? 1 : 0)
                      {
                        case 0:
                        case 2:
                          break;
                        default:
                          goto label_26;
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
                          goto label_22;
                        default:
                          continue;
                      }
                    default:
label_22:
                      if (enumerator == null)
                        goto label_27;
                      break;
                  }
                  num5 = (short) 1;
                  num4 = (int) (IntPtr) num5;
                }
label_26:
                num5 = (short) 0;
                if (num5 == (short) 0)
                  ;
label_27:;
              }
label_30:
              num2 = (short) 0;
              A_0.RecSet.Add(this.rptRec);
              num2 = (short) 1;
              num1 = (int) (IntPtr) num2;
              continue;
            case 1:
              goto label_29;
            case 2:
              num2 = (short) 1;
              if (num2 == (short) 0)
                ;
              this.rptRec = new _RecSet();
              int num8 = this.count++;
              this.rptRec.RecTitle = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("쾅첇행\uDC8B쾍쎏\uDB91욓펕횗\uD899즛쪝\uF49F\uEDA1\uEAA3\uF5A5", A_1), this.ci);
              _RecSet rptRec = this.rptRec;
              num8 = this.count;
              string str1 = num8.ToString();
              rptRec.RecNo = str1;
              enumerator = ((Collection<FeatureNode>) this.g).GetEnumerator();
              num2 = (short) 0;
              num1 = (int) (IntPtr) num2;
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
            num2 = (short) 2;
            num1 = (int) (IntPtr) num2;
          }
          else
            goto label_31;
        }
label_29:
        break;
label_31:
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
              num2 = (short) -11724;
              int num3 = (int) num2;
              num2 = (short) -11724;
              int num4 = (int) num2;
              switch (num3 == num4 ? 1 : 0)
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
                  this.g(ref this.rptTable);
                  this.f(ref this.rptTable);
                  this.e(ref this.rptTable);
                  this.d(ref this.rptTable);
                  this.c(ref this.rptTable);
                  this.b(ref this.rptTable);
                  this.AddKeypadButton(ref this.rptTable);
                  this.a(ref this.rptTable);
                  num2 = (short) 0;
                  num1 = (int) (IntPtr) num2;
                  continue;
              }
            case 2:
              if (UtilityMack.IsMobile())
              {
                num2 = (short) 1;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_9;
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
