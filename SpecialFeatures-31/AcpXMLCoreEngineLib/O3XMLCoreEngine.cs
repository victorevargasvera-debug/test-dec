// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.ACPXMLCoreEngineLib.O3XMLCoreEngine
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using AcpBusinessLayer;
using AcpCommonLib;
using CommonResources;
using ConstraintHelper;
using Motorola.MackinawCPS.CoreFeatures.ControlHeadO3;
using SpecialFeatures.AcpReportManagerLib;
using SpecialFeatures.AcpXMLCoreEngineLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;

#nullable disable
namespace SpecialFeatures.ACPXMLCoreEngineLib;

public class O3XMLCoreEngine : BaseHandOutXMLCoreEngine
{
  private Motorola.MackinawCPS.CoreFeatures.ControlHeadO3.ControlHeadO3 a;
  private O3HHCHButtonInnerRecset b;
  private DataButtonInnerRecset c;
  private ControlHeadO3Recset d;
  private O3NavigationControlsTableInnerRecset e;

  public O3XMLCoreEngine()
  {
    this.a = FeatureManager.GetFeature(2127)[0] as Motorola.MackinawCPS.CoreFeatures.ControlHeadO3.ControlHeadO3;
    this.d = FeatureManager.GetFeature(2127) as ControlHeadO3Recset;
    if (this.d == null)
      return;
    this.b = ((Recordset) this.d)[0][10235].EmbeddedRecset as O3HHCHButtonInnerRecset;
    this.c = ((Recordset) this.d)[0][10234].EmbeddedRecset as DataButtonInnerRecset;
    this.e = ((Recordset) this.d)[0][10732].EmbeddedRecset as O3NavigationControlsTableInnerRecset;
  }

  private void c(ref _table A_0)
  {
    int A_1 = 7;
    switch (0)
    {
      default:
        if (false)
          ;
        short num1 = 2;
        int num2 = (int) (IntPtr) num1;
        IEnumerator<FeatureNode> enumerator;
        while (true)
        {
          switch (num2)
          {
            case 0:
              goto label_7;
            case 1:
              enumerator = ((Collection<FeatureNode>) this.b).GetEnumerator();
              num1 = (short) 0;
              num2 = (int) (IntPtr) num1;
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
          }
          if (this.b != null)
          {
            num1 = (short) 1;
            num2 = (int) (IntPtr) num1;
          }
          else
            break;
        }
        break;
label_7:
        try
        {
          num1 = (short) 4;
          int num3 = (int) (IntPtr) num1;
          while (true)
          {
            switch (num3)
            {
              case 0:
                goto label_21;
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
                O3HHCHButtonInnerSection buttonInnerSection = current[10210] as O3HHCHButtonInnerSection;
                int featureA19650Value = buttonInnerSection.CntrlHeadO3ConventionalO3HHCHButtonFeature_A19650Value;
                int featureA19750Value = buttonInnerSection.CntrlHeadO3TrunkingO3HHCHButtonFeature_A19750Value;
                string str4 = (string) ((AcpFieldX<int, string>) buttonInnerSection.CntrlHeadO3ConventionalO3HHCHButtonFeature_A19650).Converter.Convert((object) featureA19650Value, (Type) null, (object) null, this.ci);
                string str5 = (string) ((AcpFieldX<int, string>) buttonInnerSection.CntrlHeadO3TrunkingO3HHCHButtonFeature_A19750).Converter.Convert((object) featureA19750Value, (Type) null, (object) null, this.ci);
                this.AddMultiValueByRTL(new bool?(!((AcpFieldBase) buttonInnerSection.CntrlHeadO3TrunkingO3HHCHButtonFeature_A19750).HiddenStatic), new bool?(!((AcpFieldBase) buttonInnerSection.CntrlHeadO3ConventionalO3HHCHButtonFeature_A19650).HiddenStatic), str5.ToString(), str4.ToString(), ref this.rptFields);
                this.rptFields.UIFieldName = ((AcpFieldBase) ((O3HHCHButtonInner) current).O3HHCHButtonInnerSection.CntrlHeadO3HHCHButtonName_A22523).UIName.ToString();
                string uiName = ((O3HHCHButtonInner) current).O3HHCHButtonInnerSection.CntrlHeadO3HHCHButtonName_A22523_UIValue.ToString();
                this.AddUiFieldDescByCondition(ref this.rptFields, uiName, AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("쎉좋톍쒏\uDD91쒓쒕톗\uDD99풛쪝\uE29F\uF7A1\uF0A3\uF2A5\uE7A7\uE4A9", A_1), Thread.CurrentThread.CurrentCulture), AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("쎉좋톍쒏\uDD91쒓쒕톗\uDD99풛쪝\uE29F\uF7A1\uF0A3\uF2A5\uE7A7\uE4A9", A_1), this.ci));
                this.AddUiFieldDescByCondition(ref this.rptFields, uiName, AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("쎉좋톍쒏\uDD91쒓\uDB95톗\uDE99\uD89B튝\uE59F\uE0A1\uF1A3\uF2A5ﲧ\uE5A9\uE2AB", A_1), Thread.CurrentThread.CurrentCulture), AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("쎉좋톍쒏\uDD91쒓\uDB95톗\uDE99\uD89B튝\uE59F\uE0A1\uF1A3\uF2A5ﲧ\uE5A9\uE2AB", A_1), this.ci));
                this.AddUiFieldDescByCondition(ref this.rptFields, uiName, AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("쎉좋톍쎏\uDB91킓펕첗햙첛\uDC9D\uF59F\uF6A1\uF0A3\uE9A5\uE6A7", A_1), Thread.CurrentThread.CurrentCulture), AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("쎉좋톍쎏\uDB91킓펕첗햙첛\uDC9D\uF59F\uF6A1\uF0A3\uE9A5\uE6A7", A_1), this.ci));
                this.AddUiFieldDescByCondition(ref this.rptFields, uiName, AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("쎉좋톍쎏\uDB91킓펕햗펙\uD89B\uDA9D\uEC9F\uE7A1\uE6A3\uF3A5ﲧﺩ\uE3AB\uE0AD", A_1), Thread.CurrentThread.CurrentCulture), AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("쎉좋톍쎏\uDB91킓펕햗펙\uD89B\uDA9D\uEC9F\uE7A1\uE6A3\uF3A5ﲧﺩ\uE3AB\uE0AD", A_1), this.ci));
                this.AddUiFieldDescByCondition(ref this.rptFields, uiName, AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("쎉좋톍쎏\uDB91킓펕\uDA97햙좛쪝\uEF9F\uEFA1\uE6A3\uF3A5ﲧﺩ\uE3AB\uE0AD", A_1), Thread.CurrentThread.CurrentCulture), AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("쎉좋톍쎏\uDB91킓펕\uDA97햙좛쪝\uEF9F\uEFA1\uE6A3\uF3A5ﲧﺩ\uE3AB\uE0AD", A_1), this.ci));
                this.AddUiFieldDescByCondition(ref this.rptFields, uiName, (string) null, AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("쎉좋톍\uDF8Fꆑ횓쎕첗캙펛킝", A_1), this.ci));
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
label_21:
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
                num6 = (short) 5879;
                int num7 = (int) num6;
                num6 = (short) 5879;
                int num8 = (int) num6;
                switch (num7 == num8 ? 1 : 0)
                {
                  case 0:
                  case 2:
                    break;
                  default:
                    goto label_23;
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
            num6 = (short) 1;
            num5 = (int) (IntPtr) num6;
          }
label_23:
          num6 = (short) 0;
          if (num6 == (short) 0)
            ;
        }
    }
  }

  private void b(ref _table A_0)
  {
    int A_1 = 10;
    switch (0)
    {
      default:
        short num1 = 1;
        if (num1 == (short) 0)
          ;
        num1 = (short) 3;
        int num2 = (int) (IntPtr) num1;
        while (true)
        {
          IEnumerator<FeatureNode> enumerator;
          switch (num2)
          {
            case 0:
              this.rptRec = new _RecSet();
              int num3 = this.count++;
              this.rptRec.RecTitle = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("쒌쮎캐\uDD92풔솖킘\uDC9A\uDC9C쮞\uE8A0\uECA2\uEBA4\uE4A6\uE6A8\uE5AA怜ﶮﺰﾲ\uE6B4", A_1), this.ci);
              _RecSet rptRec = this.rptRec;
              num3 = this.count;
              string str1 = num3.ToString();
              rptRec.RecNo = str1;
              enumerator = ((Collection<FeatureNode>) this.e).GetEnumerator();
              num1 = (short) 1;
              num2 = (int) (IntPtr) num1;
              continue;
            case 1:
              try
              {
                num1 = (short) 4;
                int num4 = (int) (IntPtr) num1;
                while (true)
                {
                  switch (num4)
                  {
                    case 1:
                      if (enumerator.MoveNext())
                      {
label_10:
                        FeatureNode current = enumerator.Current;
                        this.rptFields = new _UIFields();
                        O3NavigationControlsTableInnerSection tableInnerSection = ((IAcpFeatureNode) current)[10733] as O3NavigationControlsTableInnerSection;
                        int featureA41375Value = tableInnerSection.RadErgoControlO3NaviControlFeature_A41375Value;
                        string str2 = (string) ((AcpFieldX<int, string>) tableInnerSection.RadErgoControlO3NaviControlFeature_A41375).Converter.Convert((object) featureA41375Value, (Type) null, (object) null, this.ci);
                        this.AddMultiValueByRTL(new bool?(!((FeatureNode) this.refTrunking).Parent.HiddenStatic), new bool?(), str2.ToString(), str2.ToString(), ref this.rptFields);
                        this.rptFields.UIFieldName = ((AcpFieldBase) tableInnerSection.RadErgoControlO3NaviControlName_A41374).UIName.ToString();
                        string uiName = tableInnerSection.RadErgoControlO3NaviControlName_A41374_UIValue.ToString();
                        this.AddUiFieldDescByCondition(ref this.rptFields, uiName, AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("쒌쮎캐욒얔햖처쾚즜킞\uEFA0", A_1), Thread.CurrentThread.CurrentCulture), AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("쒌쮎캐욒얔햖처쾚즜킞\uEFA0", A_1), this.ci));
                        this.AddUiFieldDescByCondition(ref this.rptFields, uiName, AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("즌\uE08E\uE690ﶒ쪔햖\uEC98\uEF9A\uE99C\uF09E쾠", A_1), Thread.CurrentThread.CurrentCulture), AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("즌\uE08E\uE690ﶒ쪔햖\uEC98\uEF9A\uE99C\uF09E쾠", A_1), this.ci));
                        this.rptRec.UIFields.Add(this.rptFields);
                        num1 = (short) 18500;
                        int num5 = (int) num1;
                        num1 = (short) 18500;
                        int num6 = (int) num1;
                        switch (num5 == num6 ? 1 : 0)
                        {
                          case 0:
                          case 2:
                            goto label_10;
                          default:
                            num1 = (short) 0;
                            if (num1 == (short) 0)
                              ;
                            num1 = (short) 0;
                            num4 = (int) (IntPtr) num1;
                            continue;
                        }
                      }
                      else
                      {
                        num1 = (short) 2;
                        num4 = (int) (IntPtr) num1;
                        continue;
                      }
                    case 2:
                      num1 = (short) 3;
                      num4 = (int) (IntPtr) num1;
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
                  num1 = (short) 1;
                  num4 = (int) (IntPtr) num1;
                }
              }
              finally
              {
                int num7 = 2;
                while (true)
                {
                  switch (num7)
                  {
                    case 0:
                      enumerator.Dispose();
                      num7 = 1;
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
                    num7 = 0;
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
          if (this.e != null)
          {
            num1 = (short) 0;
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

  private void a(ref _table A_0)
  {
    int A_1 = 15;
    switch (0)
    {
      default:
        int num1 = 5;
        while (true)
        {
          short num2;
          string str1;
          string indexA41420UiValue;
          IAcpFeatureNode iacpFeatureNode;
          DataButtonInnerSection buttonInnerSection;
          string str2;
          string indexA41419UiValue;
          switch (num1)
          {
            case 0:
              num2 = (short) 0;
              str2 = str2 + this.indexSeparator + indexA41419UiValue;
              num2 = (short) 7;
              num1 = (int) (IntPtr) num2;
              continue;
            case 1:
              str1 = str1 + this.indexSeparator + indexA41420UiValue;
              num2 = (short) 20899;
              int num3 = (int) num2;
              num2 = (short) 20899;
              int num4 = (int) num2;
              switch (num3 == num4 ? 1 : 0)
              {
                case 0:
                case 2:
                  goto label_9;
                default:
                  num2 = (short) 0;
                  if (num2 == (short) 0)
                    ;
                  num2 = (short) 6;
                  num1 = (int) (IntPtr) num2;
                  continue;
              }
            case 2:
              goto label_18;
            case 3:
              if (str2 == AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDB91킓즕\uD997\uD999좛힝\uEF9F\uECA1\uE7A3\uE9A5\uE6A7囹\uE3AB\uE2AD羚\uF6B1\uF5B3\uE2B5\uF1B7\uF5B9\uF2BB", A_1), this.ci))
              {
                num2 = (short) 0;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 7;
            case 4:
              if (str1 == AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDB91킓즕\uD997\uD999좛힝\uEF9F\uECA1\uE7A3\uE9A5\uE6A7囹\uE3AB\uE2AD羚\uF6B1\uF5B3\uE2B5\uF1B7\uF5B9\uF2BB", A_1), this.ci))
              {
                num2 = (short) 1;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 6;
            case 5:
              switch (0)
              {
                case 0:
                  break;
                default:
                  continue;
              }
              break;
            case 6:
              this.AddMultiValueByRTL(new bool?(!((AcpFieldBase) buttonInnerSection.CntrlHeadO3TrunkingO3DatatButtonFeature_A22597).HiddenStatic), new bool?(!((AcpFieldBase) buttonInnerSection.CntrlHeadO3ConventionalO3DatatButtonFeature_A22595).HiddenStatic), str1, str2, ref this.rptFields);
              this.rptFields.UIFieldName = ((AcpFieldBase) (iacpFeatureNode[10212] as DataButtonInnerSection).CntrlHeadO3DataButtonName_A22591).UIName.ToString();
              this.rptFields.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDB91킓즕\uDC97\uDB99좛\uDF9D\uE29F\uF7A1\uF0A3\uF2A5\uE7A7\uE4A9\uF3AB龭", A_1), this.ci);
              this.rptRec.UIFields.Add(this.rptFields);
              A_0.RecSet.Add(this.rptRec);
              num2 = (short) 1;
              if (num2 == (short) 0)
                ;
              num2 = (short) 2;
              num1 = (int) (IntPtr) num2;
              continue;
            case 7:
label_9:
              num2 = (short) 4;
              num1 = (int) (IntPtr) num2;
              continue;
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
              iacpFeatureNode = ((Recordset) this.c)[0];
              buttonInnerSection = iacpFeatureNode[10212] as DataButtonInnerSection;
              int num6 = ((AcpField<int>) buttonInnerSection.CntrlHeadO3ConventionalO3DatatButtonFeature_A22595).Value;
              int num7 = ((AcpField<int>) buttonInnerSection.CntrlHeadO3TrunkingO3DatatButtonFeature_A22597).Value;
              str2 = (string) ((AcpFieldX<int, string>) buttonInnerSection.CntrlHeadO3ConventionalO3DatatButtonFeature_A22595).Converter.Convert((object) num6, (Type) null, (object) null, this.ci);
              str1 = (string) ((AcpFieldX<int, string>) buttonInnerSection.CntrlHeadO3TrunkingO3DatatButtonFeature_A22597).Converter.Convert((object) num7, (Type) null, (object) null, this.ci);
              indexA41419UiValue = buttonInnerSection.CHO3DataButtonConvIndex_A41419_UIValue;
              indexA41420UiValue = buttonInnerSection.CHO3DataButtonTrkIndex_A41420_UIValue;
              num2 = (short) 3;
              num1 = (int) (IntPtr) num2;
              continue;
          }
          if (this.c != null)
          {
            num2 = (short) 8;
            num1 = (int) (IntPtr) num2;
          }
          else
            goto label_19;
        }
label_18:
        break;
label_19:
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
        num2 = (short) 24776;
        int num3 = (int) num2;
        num2 = (short) 24776;
        int num4 = (int) num2;
        switch (num3 == num4 ? 1 : 0)
        {
          case 0:
          case 2:
            break;
          default:
            num2 = (short) 0;
            if (num2 == (short) 0)
              ;
            num2 = (short) 0;
            num2 = (short) 2;
            num1 = (int) (IntPtr) num2;
            goto label_1;
        }
        break;
      default:
        while (true)
        {
          switch (num1)
          {
            case 0:
              this.c(ref this.rptTable);
              this.b(ref this.rptTable);
              this.a(ref this.rptTable);
              this.AddKeypadButton(ref this.rptTable);
              num2 = (short) 1;
              num1 = (int) (IntPtr) num2;
              continue;
            case 1:
              goto label_8;
            case 2:
              goto label_5;
            default:
              goto label_2;
          }
label_1:;
        }
    }
label_5:
    if (UtilityMack.IsMobile())
    {
      num2 = (short) 0;
      num1 = (int) (IntPtr) num2;
      goto label_1;
    }
label_8:
    num2 = (short) 1;
    if (num2 == (short) 0)
      ;
    XMLRptDataObj.tables.Add(this.rptTable);
    this.AddZonesAndChannels(ref XMLRptDataObj);
  }
}
