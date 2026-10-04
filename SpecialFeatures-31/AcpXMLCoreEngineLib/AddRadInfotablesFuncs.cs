// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.AcpXMLCoreEngineLib.AddRadInfotablesFuncs
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using AcpBusinessLayer;
using AcpCommonLib;
using CommonResources;
using SpecialFeatures.AcpReportManagerLib;
using System;
using System.Globalization;

#nullable disable
namespace SpecialFeatures.AcpXMLCoreEngineLib;

public class AddRadInfotablesFuncs : IAddRadInfotables
{
  public void AddGeneral(ref _XMLData RptXMLData)
  {
    int A_1 = 4;
    int num1 = 0;
    switch (num1)
    {
      default:
        _table table;
        _RecSet recSet;
        _Value obj;
        _UIFields uiFields;
        CultureInfo culture;
        Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation radioInformation;
        short num2;
        switch (0)
        {
          case 0:
label_3:
            table = new _table();
            recSet = new _RecSet();
            obj = new _Value();
            uiFields = new _UIFields();
            culture = new CultureInfo(AppInfoManager.ReportsLangSelection);
            radioInformation = FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation;
            num2 = (short) 1;
            num1 = (int) (IntPtr) num2;
            goto default;
          default:
            while (true)
            {
              IAcpField iacpField1;
              IAcpField iacpField2;
              switch (num1)
              {
                case 0:
                  recSet = new _RecSet();
                  obj = new _Value();
                  uiFields = new _UIFields();
                  iacpField1 = (IAcpField) null;
                  recSet.RecTitle = RptMgrErrorHandler.b("얆", A_1);
                  recSet.RecNo = RptMgrErrorHandler.b("뚆", A_1);
                  iacpField2 = (IAcpField) radioInformation.General.RadInfoGeneralSerialNumber_A9122;
                  num2 = (short) 8;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 1:
                  if (radioInformation != null)
                  {
                    num2 = (short) 11;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_28;
                case 2:
                  obj.FieldValue = iacpField2.ToString();
                  uiFields.values.Add(obj);
                  uiFields.UIFieldName = iacpField2.Name;
                  uiFields.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("캆춈풊캌삎햐횒얔\uDB96처\uDC9A\uDC9C펞\uE8A0\uE2A2\uF6A4", A_1), culture);
                  recSet.UIFields.Add(uiFields);
                  table.RecSet.Add(recSet);
                  num2 = (short) 5;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 3:
                  if (iacpField2 != null)
                  {
                    num2 = (short) 1;
                    if (num2 == (short) 0)
                      ;
                    num2 = (short) 14;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  break;
                case 4:
                  if (iacpField2 != null)
                  {
                    num2 = (short) 2;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 5;
                case 5:
                  RptXMLData.tables.Add(table);
                  num2 = (short) 12;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 6:
                  if (iacpField2 != null)
                  {
                    num2 = (short) -878;
                    int num3 = (int) num2;
                    num2 = (short) -878;
                    int num4 = (int) num2;
                    switch (num3 == num4 ? 1 : 0)
                    {
                      case 0:
                      case 2:
                        goto label_3;
                      default:
                        num2 = (short) 0;
                        if (num2 == (short) 0)
                          ;
                        num2 = (short) 10;
                        num1 = (int) (IntPtr) num2;
                        continue;
                    }
                  }
                  else
                    goto case 0;
                case 7:
                  recSet = new _RecSet();
                  obj = new _Value();
                  uiFields = new _UIFields();
                  iacpField1 = (IAcpField) null;
                  recSet.RecTitle = RptMgrErrorHandler.b("쒆", A_1);
                  recSet.RecNo = RptMgrErrorHandler.b("떆", A_1);
                  iacpField2 = (IAcpField) radioInformation.FLASHport.RadInfoFLASHportFLASHcode_A8132;
                  num2 = (short) 3;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 8:
                  if (iacpField2 != null)
                  {
                    num2 = (short) 9;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 7;
                case 9:
                  obj.FieldValue = iacpField2.ToString();
                  uiFields.values.Add(obj);
                  uiFields.UIFieldName = iacpField2.Name;
                  uiFields.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("캆춈풊\uDE8C쪎쎐\uDA92풔\uDB96힘캚킜\uDD9E\uE4A0\uF1A2", A_1), culture);
                  recSet.UIFields.Add(uiFields);
                  table.RecSet.Add(recSet);
                  num2 = (short) 7;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 10:
                  recSet.RecTitle = RptMgrErrorHandler.b("욆", A_1);
                  recSet.RecNo = RptMgrErrorHandler.b("랆", A_1);
                  obj.FieldValue = iacpField2.ToString();
                  uiFields.values.Add(obj);
                  uiFields.UIFieldName = iacpField2.Name;
                  uiFields.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("캆춈풊삌삎햐횒\uD994\uD996처횚\uDF9C\uDA9E\uF3A0", A_1), culture);
                  recSet.UIFields.Add(uiFields);
                  table.RecSet.Add(recSet);
                  num2 = (short) 0;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 11:
                  table.TableTitle = RptMgrErrorHandler.b("삆\uEC88\uE58A\uE88Cﶎ\uF090ﾒ\uDD94ﺖﶘﾚ\uF89C\uF19E", A_1);
                  table.ColTitle.Add(AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("캆춈풊쪌쪎\uDF90횒잔횖햘", A_1), culture));
                  iacpField1 = (IAcpField) null;
                  iacpField2 = (IAcpField) radioInformation.General.RadInfoGeneralModelNumber_A8539;
                  num2 = (short) 6;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 12:
                  goto label_24;
                case 13:
                  num2 = (short) 0;
                  break;
                case 14:
                  obj.FieldValue = iacpField2.ToString();
                  uiFields.values.Add(obj);
                  uiFields.UIFieldName = iacpField2.Name;
                  uiFields.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("캆춈풊쮌쎎킐삒\uDD94풖횘\uDF9A\uD89C", A_1), culture);
                  recSet.UIFields.Add(uiFields);
                  table.RecSet.Add(recSet);
                  num2 = (short) 13;
                  num1 = (int) (IntPtr) num2;
                  continue;
                default:
                  goto label_3;
              }
              recSet = new _RecSet();
              obj = new _Value();
              uiFields = new _UIFields();
              iacpField1 = (IAcpField) null;
              recSet.RecTitle = RptMgrErrorHandler.b("쎆", A_1);
              recSet.RecNo = RptMgrErrorHandler.b("뒆", A_1);
              iacpField2 = (IAcpField) radioInformation.General.RadInfoGeneralCodeplugAlias_A7684;
              num2 = (short) 4;
              num1 = (int) (IntPtr) num2;
            }
label_24:
            return;
label_28:
            return;
        }
    }
  }

  public void AddTracking(ref _XMLData RptXMLData)
  {
    int A_1 = 5;
    int num1 = 0;
    switch (num1)
    {
      default:
        _table table;
        string name;
        short num2;
        switch (0)
        {
          case 0:
label_3:
            table = new _table();
            name = AppInfoManager.ReportsLangSelection;
            num2 = (short) 1;
            num1 = (int) (IntPtr) num2;
            goto default;
          default:
            while (true)
            {
              _Value obj;
              IAcpField iacpField1;
              _UIFields uiFields;
              CultureInfo culture;
              _RecSet recSet;
              Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation radioInformation;
              string str1;
              IAcpField iacpField2;
              string str2;
              switch (num1)
              {
                case 0:
                  obj.FieldValue = str1;
                  uiFields.values.Add(obj);
                  uiFields.UIFieldName = ((AcpFieldBase) radioInformation.Tracking.RadInfoLabtoolBornOnDateDBValue_A7568).Name;
                  uiFields.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("솇캉펋속슏\uDB91펓\uDF95횗\uDB99킛캝\uF29F\uEDA1\uE3A3\uF4A5\uE9A7\uE7A9\uE1AB\uEBAD\uF4AFﮱ荒\uF0B5\uF7B7\uE8B9\uF1BBﾽ钿证诃装談藉黋胍鿏鳑胓鿕闗\u9FD9鷛郝ꓟꛡꗣ닥귧", A_1), culture);
                  recSet.UIFields.Add(uiFields);
                  table.RecSet.Add(recSet);
                  num2 = (short) 18;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 1:
                  if (name == RptMgrErrorHandler.b("\uE987\uF889", A_1))
                  {
                    num2 = (short) 6;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 13;
                case 2:
                  if (iacpField1 != null)
                  {
                    num2 = (short) 4;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 7;
                case 3:
                  obj.FieldValue = str2;
                  uiFields.values.Add(obj);
                  uiFields.UIFieldName = ((AcpFieldBase) radioInformation.Tracking.RadInfoLabtoolLastProgrammedDateDBValue_A8411).Name;
                  uiFields.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("솇캉펋슍톏솑삓욕쪗햙\uDB9B첝\uE19F\uEFA1\uE9A3\uE3A5\uECA7\uE3A9\uE2AB\uE8ADﾯ\uE0B1靈\uF7B5\uECB7\uF3B9\uF3BB\uF0BD貿菁韃鋅飇飉菋觍苏鏑駓鯕鷗黙裛韝귟\uA7E1ꗣ꣥곧껩귫뫭뗯", A_1), culture);
                  recSet.UIFields.Add(uiFields);
                  table.RecSet.Add(recSet);
                  num2 = (short) 22008;
                  int num3 = (int) num2;
                  num2 = (short) 22008;
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
                      num2 = (short) 19;
                      num1 = (int) (IntPtr) num2;
                      continue;
                  }
                  break;
                case 4:
                  obj.FieldValue = iacpField1.ToString();
                  uiFields.values.Add(obj);
                  uiFields.UIFieldName = iacpField1.Name;
                  uiFields.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("솇캉펋슍톏솑삓욕쪗햙\uDB9B첝\uE19F\uEFA1\uE9A3\uE3A5\uECA7\uE3A9\uE2AB\uE8ADﾯ\uE0B1靈\uF7B5\uECB7\uF3B9\uF3BB\uF0BD鎿跁釃铅诇迉", A_1), culture);
                  recSet.UIFields.Add(uiFields);
                  table.RecSet.Add(recSet);
                  num2 = (short) 7;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 5:
                  obj.FieldValue = iacpField1.ToString();
                  uiFields.values.Add(obj);
                  uiFields.UIFieldName = iacpField1.Name;
                  uiFields.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("솇캉펋속슏\uDB91펓\uDF95횗\uDB99킛캝\uF29F\uEDA1\uE3A3\uF4A5\uE9A7\uE7A9\uE1AB\uEBAD\uF4AFﮱ荒\uF0B5\uF7B7\uE8B9\uF1BBﾽ钿证诃装诇藉裋词胏黑臓釕軗\u9FD9軛距꧟귡ꫣ", A_1), culture);
                  recSet.UIFields.Add(uiFields);
                  table.RecSet.Add(recSet);
                  num2 = (short) 17;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 6:
                  name = RptMgrErrorHandler.b("\uE987\uF889ꆋ얍잏", A_1);
                  num2 = (short) 13;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 7:
                  recSet = new _RecSet();
                  obj = new _Value();
                  uiFields = new _UIFields();
                  iacpField1 = (IAcpField) null;
                  recSet.RecTitle = RptMgrErrorHandler.b("쮇", A_1);
                  recSet.RecNo = RptMgrErrorHandler.b("뮇", A_1);
                  long num5 = ((AcpField<long>) radioInformation.Tracking.RadInfoLabtoolBornOnDateDBValue_A7568).Value;
                  str1 = (string) radioInformation.Tracking.RadInfoLabtoolBornOnDateDBValue_A7568.Converter.Convert((object) num5, (Type) null, (object) null, culture);
                  num2 = (short) 11;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 8:
                  if (radioInformation != null)
                  {
                    num2 = (short) 15;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_35;
                case 9:
                  goto label_31;
                case 10:
                  if (str2 == null)
                    goto case 19;
                  break;
                case 11:
                  num2 = (short) 1;
                  if (num2 == (short) 0)
                    ;
                  if (str1 != null)
                  {
                    num2 = (short) 0;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 18;
                case 12:
                  if (iacpField1 != null)
                  {
                    num2 = (short) 5;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 17;
                case 13:
                  culture = new CultureInfo(name);
                  radioInformation = FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation;
                  num2 = (short) 8;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 14:
                  obj.FieldValue = iacpField1.ToString();
                  uiFields.values.Add(obj);
                  uiFields.UIFieldName = iacpField1.Name;
                  uiFields.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("솇캉펋속슏\uDB91펓\uDF95횗\uDB99킛캝\uF29F\uEDA1\uE3A3\uF4A5\uE9A7\uE7A9\uE1AB\uEBAD\uF4AFﮱ荒\uF0B5\uF7B7\uE8B9\uF1BBﾽ钿证诃装鯇藉駋鳍鏏韑", A_1), culture);
                  recSet.UIFields.Add(uiFields);
                  table.RecSet.Add(recSet);
                  num2 = (short) 20;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 15:
                  table.TableTitle = RptMgrErrorHandler.b("\uDC87\uF889\uED8B\uED8Dﮏﮑ望\uF195킗\uF399\uF89B瞧얟첡", A_1);
                  table.ColTitle.Add(AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("솇캉펋\uDA8D슏펑힓\uDD95톗풙\uDB9B", A_1), culture));
                  iacpField2 = (IAcpField) null;
                  recSet = new _RecSet();
                  obj = new _Value();
                  uiFields = new _UIFields();
                  iacpField1 = (IAcpField) null;
                  recSet.RecTitle = RptMgrErrorHandler.b("즇", A_1);
                  recSet.RecNo = RptMgrErrorHandler.b("릇", A_1);
                  long num6 = ((AcpField<long>) radioInformation.Tracking.RadInfoLabtoolLastProgrammedDateDBValue_A8411).Value;
                  str2 = (string) radioInformation.Tracking.RadInfoLabtoolLastProgrammedDateDBValue_A8411.Converter.Convert((object) num6, (Type) null, (object) null, culture);
                  num2 = (short) 10;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 16 /*0x10*/:
                  if (iacpField1 != null)
                  {
                    num2 = (short) 14;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 20;
                case 17:
                  num2 = (short) 0;
                  recSet = new _RecSet();
                  obj = new _Value();
                  uiFields = new _UIFields();
                  iacpField2 = (IAcpField) null;
                  recSet.RecTitle = RptMgrErrorHandler.b("춇", A_1);
                  recSet.RecNo = RptMgrErrorHandler.b("붇", A_1);
                  iacpField1 = (IAcpField) radioInformation.Tracking.RadInfoTrackingSource2_A8625;
                  num2 = (short) 16 /*0x10*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 18:
                  recSet = new _RecSet();
                  obj = new _Value();
                  uiFields = new _UIFields();
                  iacpField2 = (IAcpField) null;
                  recSet.RecTitle = RptMgrErrorHandler.b("첇", A_1);
                  recSet.RecNo = RptMgrErrorHandler.b("벇", A_1);
                  iacpField1 = (IAcpField) radioInformation.Tracking.RadInfoTrackingCodeplugVersion_A7688;
                  num2 = (short) 12;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 19:
                  recSet = new _RecSet();
                  obj = new _Value();
                  uiFields = new _UIFields();
                  iacpField2 = (IAcpField) null;
                  recSet.RecTitle = RptMgrErrorHandler.b("쪇", A_1);
                  recSet.RecNo = RptMgrErrorHandler.b("몇", A_1);
                  iacpField1 = (IAcpField) radioInformation.Tracking.RadInfoTrackingSource1_A9171;
                  num2 = (short) 2;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 20:
                  RptXMLData.tables.Add(table);
                  num2 = (short) 9;
                  num1 = (int) (IntPtr) num2;
                  continue;
                default:
                  goto label_3;
              }
              num2 = (short) 3;
              num1 = (int) (IntPtr) num2;
            }
label_31:
            return;
label_35:
            return;
        }
    }
  }

  public void AddFlashPort(ref _XMLData RptXMLData)
  {
    int A_1 = 14;
    int num1 = 0;
    switch (num1)
    {
      default:
        _table table;
        CultureInfo culture;
        Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation radioInformation;
        short num2;
        switch (0)
        {
          case 0:
label_3:
            table = new _table();
            culture = new CultureInfo(AppInfoManager.ReportsLangSelection);
            radioInformation = FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation;
            num2 = (short) 4;
            num1 = (int) (IntPtr) num2;
            goto default;
          default:
            while (true)
            {
              _RecSet recSet;
              _Value obj;
              _UIFields uiFields;
              IAcpField iacpField1;
              IAcpField iacpField2;
              switch (num1)
              {
                case 0:
                  if (iacpField2 != null)
                  {
                    num2 = (short) 6;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 11;
                case 1:
                  if (iacpField2 != null)
                  {
                    num2 = (short) 1;
                    if (num2 == (short) 0)
                      ;
                    num2 = (short) 5;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 9;
                case 2:
                  goto label_20;
                case 3:
                  recSet = new _RecSet();
                  obj = new _Value();
                  uiFields = new _UIFields();
                  iacpField1 = (IAcpField) null;
                  recSet.RecTitle = RptMgrErrorHandler.b("펐", A_1);
                  recSet.RecNo = RptMgrErrorHandler.b("ꎐ", A_1);
                  iacpField2 = (IAcpField) radioInformation.FLASHport.RadInfoFLASHportIButton_A8217;
                  num2 = (short) 0;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 4:
                  if (radioInformation != null)
                  {
                    num2 = (short) 8;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_24;
                case 5:
                  num2 = (short) 0;
                  obj.FieldValue = iacpField2.ToString();
                  uiFields.values.Add(obj);
                  uiFields.UIFieldName = iacpField2.Name;
                  uiFields.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uD890힒쪔\uDB96\uD898좚즜쪞\uF1A0\uE4A2\uF7A4\uE6A6\uEDA8\uEEAAﺬ\uE0AE\uE4B0\uE1B2\uF6B4\uF2B6", A_1), culture);
                  recSet.UIFields.Add(uiFields);
                  table.RecSet.Add(recSet);
                  num2 = (short) 9;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 6:
                  obj.FieldValue = iacpField2.ToString();
                  uiFields.values.Add(obj);
                  uiFields.UIFieldName = iacpField2.Name;
                  uiFields.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uD890힒쪔\uDE96\uDB98캚즜쮞\uEEA0\uEDA2", A_1), culture);
                  recSet.UIFields.Add(uiFields);
                  table.RecSet.Add(recSet);
                  break;
                case 7:
                  if (iacpField2 != null)
                  {
                    num2 = (short) 10;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 3;
                case 8:
                  table.TableTitle = RptMgrErrorHandler.b("힐ﾒ\uF494\uE496\uF198쮚\uF29C\uED9E햠\uEBA2첤쎦춨캪쎬", A_1);
                  table.ColTitle.Add(AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uD890힒쪔톖햘\uDA9A캜힞\uF1A0\uECA2\uF7A4\uF3A6", A_1), culture));
                  iacpField1 = (IAcpField) null;
                  recSet = new _RecSet();
                  obj = new _Value();
                  uiFields = new _UIFields();
                  iacpField1 = (IAcpField) null;
                  recSet.RecTitle = RptMgrErrorHandler.b("킐", A_1);
                  recSet.RecNo = RptMgrErrorHandler.b("ꂐ", A_1);
                  iacpField2 = (IAcpField) radioInformation.FLASHport.RadInfoFLASHportNumberofTimesFlashed_A8581;
                  num2 = (short) 7866;
                  int num3 = (int) num2;
                  num2 = (short) 7866;
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
                      num2 = (short) 7;
                      num1 = (int) (IntPtr) num2;
                      continue;
                  }
                  break;
                case 9:
                  RptXMLData.tables.Add(table);
                  num2 = (short) 2;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 10:
                  obj.FieldValue = iacpField2.ToString();
                  uiFields.values.Add(obj);
                  uiFields.UIFieldName = iacpField2.Name;
                  uiFields.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uD890힒쪔\uD996처횚\uDF9C\uDA9E\uF3A0\uECA2\uE3A4\uF3A6\uE0A8\uE6AA\uE8ACﲮ\uF7B0ﾲ\uF4B4\uE4B6\uF1B8ﺺ寮", A_1), culture);
                  recSet.UIFields.Add(uiFields);
                  table.RecSet.Add(recSet);
                  num2 = (short) 3;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 11:
                  recSet = new _RecSet();
                  obj = new _Value();
                  uiFields = new _UIFields();
                  iacpField1 = (IAcpField) null;
                  recSet.RecTitle = RptMgrErrorHandler.b("튐", A_1);
                  recSet.RecNo = RptMgrErrorHandler.b("ꊐ", A_1);
                  iacpField2 = (IAcpField) radioInformation.FLASHport.RadInfoFLASHportLastUpgradeSource_A8387;
                  num2 = (short) 1;
                  num1 = (int) (IntPtr) num2;
                  continue;
                default:
                  goto label_3;
              }
              num2 = (short) 11;
              num1 = (int) (IntPtr) num2;
            }
label_20:
            return;
label_24:
            return;
        }
    }
  }

  public void AddVersion(ref _XMLData RptXMLData)
  {
    int A_1 = 3;
    int num1 = 0;
    switch (num1)
    {
      default:
        _table table;
        Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation radioInformation;
        short num2;
        switch (0)
        {
          case 0:
label_3:
            table = new _table();
            radioInformation = FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation;
            num2 = (short) 4;
            num1 = (int) (IntPtr) num2;
            goto default;
          default:
            while (true)
            {
              _Value obj;
              IAcpField iacpField1;
              _UIFields uiFields;
              _RecSet recSet;
              IAcpField iacpField2;
              switch (num1)
              {
                case 0:
                  obj.FieldValue = iacpField1.ToString();
                  uiFields.values.Add(obj);
                  uiFields.UIFieldName = iacpField1.Name;
                  uiFields.UIFieldDes = iacpField1.UIName;
                  recSet.UIFields.Add(uiFields);
                  table.RecSet.Add(recSet);
                  num2 = (short) 17;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 1:
                  RptXMLData.tables.Add(table);
                  num2 = (short) 8;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 2:
                  recSet = new _RecSet();
                  obj = new _Value();
                  uiFields = new _UIFields();
                  iacpField2 = (IAcpField) null;
                  recSet.RecTitle = RptMgrErrorHandler.b("얅", A_1);
                  recSet.RecNo = RptMgrErrorHandler.b("떅", A_1);
                  iacpField1 = (IAcpField) radioInformation.General.RadInfoGeneralFirmwareVersion_A8124;
                  num2 = (short) 7;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 3:
                  obj.FieldValue = iacpField1.ToString();
                  uiFields.values.Add(obj);
                  uiFields.UIFieldName = iacpField1.Name;
                  uiFields.UIFieldDes = iacpField1.UIName;
                  recSet.UIFields.Add(uiFields);
                  table.RecSet.Add(recSet);
                  num2 = (short) 16 /*0x10*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 4:
                  if (radioInformation != null)
                  {
                    num2 = (short) 6;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_32;
                case 5:
                  if (iacpField1 != null)
                  {
                    num2 = (short) 11;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 2;
                case 6:
                  table.TableTitle = RptMgrErrorHandler.b("킅\uED87\uF889ﾋ\uE78Dﾏﲑ뒓\uDF95\uF697ﲙ\uF39B\uEC9D춟쎡킣쾥잧쒩貫\uE6AD\uD9AF횱킳펵횷", A_1);
                  iacpField2 = (IAcpField) null;
                  recSet = new _RecSet();
                  obj = new _Value();
                  uiFields = new _UIFields();
                  recSet.RecTitle = RptMgrErrorHandler.b("입", A_1);
                  recSet.RecNo = RptMgrErrorHandler.b("랅", A_1);
                  iacpField1 = (IAcpField) radioInformation.General.RadInfoGeneralCodeplugVersion_A7683;
                  num2 = (short) 0;
                  num2 = (short) 15;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 7:
                  if (iacpField1 != null)
                  {
                    num2 = (short) 0;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 17;
                case 8:
                  goto label_30;
                case 9:
                  num2 = (short) -30469;
                  int num3 = (int) num2;
                  num2 = (short) -30469;
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
                      if (iacpField1 != null)
                      {
                        num2 = (short) 3;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto label_15;
                  }
                  break;
                case 10:
                  num2 = (short) 1;
                  if (num2 == (short) 0)
                    ;
                  obj.FieldValue = iacpField1.ToString();
                  uiFields.values.Add(obj);
                  uiFields.UIFieldName = iacpField1.Name;
                  uiFields.UIFieldDes = iacpField1.UIName;
                  recSet.UIFields.Add(uiFields);
                  table.RecSet.Add(recSet);
                  num2 = (short) 14;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 11:
                  obj.FieldValue = iacpField1.ToString();
                  uiFields.values.Add(obj);
                  uiFields.UIFieldName = iacpField1.Name;
                  uiFields.UIFieldDes = iacpField1.UIName;
                  recSet.UIFields.Add(uiFields);
                  table.RecSet.Add(recSet);
                  num2 = (short) 2;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 12:
                  if (iacpField1 != null)
                  {
                    num2 = (short) 13;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 1;
                case 13:
                  obj.FieldValue = iacpField1.ToString();
                  uiFields.values.Add(obj);
                  uiFields.UIFieldName = iacpField1.Name;
                  uiFields.UIFieldDes = iacpField1.UIName;
                  recSet.UIFields.Add(uiFields);
                  table.RecSet.Add(recSet);
                  break;
                case 14:
                  recSet = new _RecSet();
                  obj = new _Value();
                  uiFields = new _UIFields();
                  iacpField2 = (IAcpField) null;
                  recSet.RecTitle = RptMgrErrorHandler.b("쒅", A_1);
                  recSet.RecNo = RptMgrErrorHandler.b("뒅", A_1);
                  iacpField1 = (IAcpField) radioInformation.General.RadInfoGeneralDSPVersion_A7892;
                  num2 = (short) 5;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 15:
                  if (iacpField1 != null)
                  {
                    num2 = (short) 10;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 14;
                case 16 /*0x10*/:
label_15:
                  recSet = new _RecSet();
                  obj = new _Value();
                  uiFields = new _UIFields();
                  iacpField2 = (IAcpField) null;
                  recSet.RecTitle = RptMgrErrorHandler.b("쎅", A_1);
                  recSet.RecNo = RptMgrErrorHandler.b("뎅", A_1);
                  iacpField1 = (IAcpField) radioInformation.General.RadInfoGeneralTuningVersion_A9509;
                  num2 = (short) 12;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 17:
                  recSet = new _RecSet();
                  obj = new _Value();
                  uiFields = new _UIFields();
                  iacpField2 = (IAcpField) null;
                  recSet.RecTitle = RptMgrErrorHandler.b("슅", A_1);
                  recSet.RecNo = RptMgrErrorHandler.b("늅", A_1);
                  iacpField1 = (IAcpField) radioInformation.General.RadInfoGeneralUCMVersion_A9591;
                  num2 = (short) 9;
                  num1 = (int) (IntPtr) num2;
                  continue;
                default:
                  goto label_3;
              }
              num2 = (short) 1;
              num1 = (int) (IntPtr) num2;
            }
label_30:
            return;
label_32:
            return;
        }
    }
  }

  public void AddFeatures(ref _XMLData RptXMLData)
  {
    short num1 = -14698;
    int num2 = (int) num1;
    num1 = (short) -14698;
    int num3 = (int) num1;
    switch (num2 == num3)
    {
      case true:
        short num4 = 0;
        num4 = (short) 0;
        if (num4 == (short) 0)
          ;
        num4 = (short) 1;
        if (num4 == (short) 0)
          break;
        break;
      default:
        goto case 1;
    }
  }
}
