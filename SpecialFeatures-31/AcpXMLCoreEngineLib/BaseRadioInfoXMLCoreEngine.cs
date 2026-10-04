// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.ACPXMLCoreEngineLib.BaseRadioInfoXMLCoreEngine
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using AcpBusinessLayer;
using AcpCommonLib;
using CommonResources;
using SpecialFeatures.AcpReportManagerLib;
using SpecialFeatures.AcpXMLCoreEngineLib;
using SpecialFeatures.Flashport;
using SpecialFeatures.RadioFeatureSet;
using System;
using System.Collections.Generic;
using System.Globalization;

#nullable disable
namespace SpecialFeatures.ACPXMLCoreEngineLib;

public class BaseRadioInfoXMLCoreEngine : AcpBaseXMLCoreEngine
{
  protected virtual void AddGeneral(ref _XMLData RptXMLData)
  {
    int A_1 = 1;
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
            break;
          default:
            while (true)
            {
              IAcpField iacpField1;
              IAcpField iacpField2;
              switch (num1)
              {
                case 0:
                  num2 = (short) 0;
                  recSet = new _RecSet();
                  obj = new _Value();
                  uiFields = new _UIFields();
                  iacpField1 = (IAcpField) null;
                  recSet.RecTitle = RptMgrErrorHandler.b("욃", A_1);
                  recSet.RecNo = RptMgrErrorHandler.b("떃", A_1);
                  iacpField2 = (IAcpField) radioInformation.General.RadInfoGeneralSerialNumber_A9122;
                  num2 = (short) 14;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 1:
                  obj.FieldValue = iacpField2.ToString();
                  uiFields.values.Add(obj);
                  uiFields.UIFieldName = iacpField2.Name;
                  uiFields.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("춃슅힇\uD989즋\uDC8D\uD98F펑\uD893\uD895춗힙\uDE9B\uDB9D\uF29F", A_1), culture);
                  recSet.UIFields.Add(uiFields);
                  table.RecSet.Add(recSet);
                  num2 = (short) 10;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 2:
                  RptXMLData.tables.Add(table);
                  num2 = (short) 5;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 3:
                  num2 = (short) 30773;
                  int num3 = (int) num2;
                  num2 = (short) 30773;
                  int num4 = (int) num2;
                  switch (num3 == num4 ? 1 : 0)
                  {
                    case 0:
                    case 2:
                      goto label_4;
                    default:
                      num2 = (short) 0;
                      if (num2 == (short) 0)
                        ;
                      recSet.RecTitle = RptMgrErrorHandler.b("얃", A_1);
                      recSet.RecNo = RptMgrErrorHandler.b("뒃", A_1);
                      obj.FieldValue = iacpField2.ToString();
                      uiFields.values.Add(obj);
                      uiFields.UIFieldName = iacpField2.Name;
                      uiFields.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("춃슅힇잉쎋쪍햏\uDE91\uDA93쎕햗\uD899\uD99B첝", A_1), culture);
                      recSet.UIFields.Add(uiFields);
                      table.RecSet.Add(recSet);
                      num2 = (short) 0;
                      num1 = (int) (IntPtr) num2;
                      continue;
                  }
                case 4:
                  obj.FieldValue = iacpField2.ToString();
                  uiFields.values.Add(obj);
                  uiFields.UIFieldName = iacpField2.Name;
                  uiFields.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("춃슅힇첉삋쾍쎏\uDA91힓\uD995\uDC97\uDF99", A_1), culture);
                  recSet.UIFields.Add(uiFields);
                  table.RecSet.Add(recSet);
                  num2 = (short) 12;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 5:
                  goto label_24;
                case 6:
                  table.TableTitle = RptMgrErrorHandler.b("쎃\uE385\uE687\uEF89ﺋ\uEF8Dﲏ\uDA91ﶓ\uF295ﲗﾙ\uF29B", A_1);
                  table.ColTitle.Add(AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("춃슅힇춉즋삍햏삑햓\uDA95", A_1), culture));
                  iacpField1 = (IAcpField) null;
                  iacpField2 = (IAcpField) radioInformation.General.RadInfoGeneralModelNumber_A8539;
                  num2 = (short) 11;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 7:
                  if (iacpField2 != null)
                  {
                    num2 = (short) 9;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 2;
                case 8:
                  if (iacpField2 != null)
                  {
                    num2 = (short) 4;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 12;
                case 9:
                  num2 = (short) 1;
                  if (num2 == (short) 0)
                    ;
                  obj.FieldValue = iacpField2.ToString();
                  uiFields.values.Add(obj);
                  uiFields.UIFieldName = iacpField2.Name;
                  uiFields.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("춃슅힇즉쎋쪍햏슑\uD893쎕\uDF97\uDB99킛힝\uE19F\uF1A1", A_1), culture);
                  recSet.UIFields.Add(uiFields);
                  table.RecSet.Add(recSet);
                  num2 = (short) 2;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 10:
                  recSet = new _RecSet();
                  obj = new _Value();
                  uiFields = new _UIFields();
                  iacpField1 = (IAcpField) null;
                  recSet.RecTitle = RptMgrErrorHandler.b("잃", A_1);
                  recSet.RecNo = RptMgrErrorHandler.b("뚃", A_1);
                  iacpField2 = (IAcpField) radioInformation.FLASHport.RadInfoFLASHportFLASHcode_A8132;
                  num2 = (short) 8;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 11:
                  if (iacpField2 != null)
                  {
                    num2 = (short) 3;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 0;
                case 12:
                  recSet = new _RecSet();
                  obj = new _Value();
                  uiFields = new _UIFields();
                  iacpField1 = (IAcpField) null;
                  recSet.RecTitle = RptMgrErrorHandler.b("삃", A_1);
                  recSet.RecNo = RptMgrErrorHandler.b("랃", A_1);
                  iacpField2 = (IAcpField) radioInformation.General.RadInfoGeneralCodeplugAlias_A7684;
                  num2 = (short) 7;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 13:
                  if (radioInformation != null)
                  {
                    num2 = (short) 6;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_28;
                case 14:
                  if (iacpField2 != null)
                  {
                    num2 = (short) 1;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 10;
                default:
                  goto label_3;
              }
label_2:;
            }
label_24:
            return;
label_28:
            return;
        }
label_4:
        num2 = (short) 13;
        num1 = (int) (IntPtr) num2;
        goto label_2;
    }
  }

  protected virtual void AddTracking(ref _XMLData RptXMLData)
  {
    int A_1 = 19;
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
            num2 = (short) 7;
            num1 = (int) (IntPtr) num2;
            goto default;
          default:
            _Value obj;
            IAcpField iacpField1;
            _UIFields uiFields;
            CultureInfo culture;
            _RecSet recSet;
            Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation radioInformation;
            string str1;
            IAcpField iacpField2;
            string str2;
            while (true)
            {
              switch (num1)
              {
                case 0:
                  obj.FieldValue = iacpField1.ToString();
                  uiFields.values.Add(obj);
                  uiFields.UIFieldName = iacpField1.Name;
                  uiFields.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDF95\uDC97얙킛\uDF9D\uF39F\uF6A1\uF4A3\uF4A5\uE7A7\uEDA9ﺫ\uEFADﶯﾱ\uF1B3\uF2B5\uF1B7\uF4B9請\uF1BD銿迁藃鋅臇藉苋鷍鿏蟑蛓闕鷗", A_1), culture);
                  recSet.UIFields.Add(uiFields);
                  table.RecSet.Add(recSet);
                  num2 = (short) 17;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 1:
                  if (str2 != null)
                  {
                    num2 = (short) 8;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 2;
                case 2:
                  recSet = new _RecSet();
                  obj = new _Value();
                  uiFields = new _UIFields();
                  iacpField2 = (IAcpField) null;
                  recSet.RecTitle = RptMgrErrorHandler.b("풕", A_1);
                  recSet.RecNo = RptMgrErrorHandler.b("꒕", A_1);
                  iacpField1 = (IAcpField) radioInformation.Tracking.RadInfoTrackingSource1_A9171;
                  num2 = (short) 20;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 3:
                  table.TableTitle = RptMgrErrorHandler.b("슕\uEA97ﮙﾛ\uF59D즟첡쎣\uEEA5솧캩좫쮭\uDEAF", A_1);
                  table.ColTitle.Add(AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDF95\uDC97얙좛첝\uE19F\uE1A1\uEFA3\uEFA5\uE6A7\uEDA9", A_1), culture));
                  iacpField2 = (IAcpField) null;
                  recSet = new _RecSet();
                  obj = new _Value();
                  uiFields = new _UIFields();
                  iacpField1 = (IAcpField) null;
                  recSet.RecTitle = RptMgrErrorHandler.b("힕", A_1);
                  recSet.RecNo = RptMgrErrorHandler.b("ꞕ", A_1);
                  long num3 = ((AcpField<long>) radioInformation.Tracking.RadInfoLabtoolLastProgrammedDateDBValue_A8411).Value;
                  str2 = (string) radioInformation.Tracking.RadInfoLabtoolLastProgrammedDateDBValue_A8411.Converter.Convert((object) num3, (Type) null, (object) null, culture);
                  num2 = (short) 1;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 4:
                  recSet = new _RecSet();
                  obj = new _Value();
                  uiFields = new _UIFields();
                  iacpField2 = (IAcpField) null;
                  recSet.RecTitle = RptMgrErrorHandler.b("펕", A_1);
                  recSet.RecNo = RptMgrErrorHandler.b("ꎕ", A_1);
                  iacpField1 = (IAcpField) radioInformation.Tracking.RadInfoTrackingSource2_A8625;
                  num2 = (short) 5;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 5:
                  if (iacpField1 != null)
                  {
                    num2 = (short) 18;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 14;
                case 6:
                  goto label_31;
                case 7:
                  if (name == RptMgrErrorHandler.b("\uF795\uEA97", A_1))
                  {
                    num2 = (short) 19;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 16 /*0x10*/;
                case 8:
                  obj.FieldValue = str2;
                  uiFields.values.Add(obj);
                  uiFields.UIFieldName = ((AcpFieldBase) radioInformation.Tracking.RadInfoLabtoolLastProgrammedDateDBValue_A8411).Name;
                  uiFields.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDF95\uDC97얙킛\uDF9D\uF39F\uF6A1\uF4A3\uF4A5\uE7A7\uEDA9ﺫ\uEFADﶯﾱ\uF1B3\uF2B5\uF1B7\uF4B9請\uF1BD銿迁藃鋅臇藉苋苍量臑胓蛕諗闙鯛賝ꇟ꿡ꧣꏥ곧뻩ꗫꏭ뗯돱뫳답볷믹ꣻ믽", A_1), culture);
                  recSet.UIFields.Add(uiFields);
                  table.RecSet.Add(recSet);
                  num2 = (short) 2;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 9:
                  obj.FieldValue = iacpField1.ToString();
                  uiFields.values.Add(obj);
                  uiFields.UIFieldName = iacpField1.Name;
                  uiFields.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDF95\uDC97얙펛첝\uE99F\uE5A1\uEDA3\uE8A5\uE9A7\uE6A9ﲫﲭﾯ\uF5B1\uE6B3\uF7B5\uF5B7\uF7B9僚諾覿賁苃觅髇蟉跋髍駏鷑髓闕韗黙駛軝곟럡ꏣ냥귧룩뿫\uA7ED뿯볱", A_1), culture);
                  recSet.UIFields.Add(uiFields);
                  table.RecSet.Add(recSet);
                  num2 = (short) 4;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 10:
                  if (iacpField1 != null)
                  {
                    num2 = (short) 9;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 4;
                case 11:
                  if (radioInformation != null)
                  {
                    num2 = (short) 3;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_36;
                case 12:
                  recSet = new _RecSet();
                  obj = new _Value();
                  uiFields = new _UIFields();
                  iacpField2 = (IAcpField) null;
                  recSet.RecTitle = RptMgrErrorHandler.b("튕", A_1);
                  recSet.RecNo = RptMgrErrorHandler.b("ꊕ", A_1);
                  iacpField1 = (IAcpField) radioInformation.Tracking.RadInfoTrackingCodeplugVersion_A7688;
                  num2 = (short) 10;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 13:
                  if (str1 != null)
                  {
                    num2 = (short) 15;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 12;
                case 14:
                  RptXMLData.tables.Add(table);
                  num2 = (short) 6;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 15:
                  num2 = (short) 24034;
                  int num4 = (int) num2;
                  num2 = (short) 24034;
                  int num5 = (int) num2;
                  switch (num4 == num5 ? 1 : 0)
                  {
                    case 0:
                    case 2:
                      goto label_13;
                    case 1:
                      num2 = (short) 0;
                      if (num2 == (short) 0)
                        ;
                      obj.FieldValue = str1;
                      uiFields.values.Add(obj);
                      uiFields.UIFieldName = ((AcpFieldBase) radioInformation.Tracking.RadInfoLabtoolBornOnDateDBValue_A7568).Name;
                      uiFields.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDF95\uDC97얙펛첝\uE99F\uE5A1\uEDA3\uE8A5\uE9A7\uE6A9ﲫﲭﾯ\uF5B1\uE6B3\uF7B5\uF5B7\uF7B9僚諾覿賁苃觅髇蟉跋髍駏鷑髓铕韗裙鋛針껟뛡귣ꯥ귧ꯩꋫꫭ듯돱ꃳ돵", A_1), culture);
                      recSet.UIFields.Add(uiFields);
                      table.RecSet.Add(recSet);
                      num2 = (short) 12;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    default:
                      num2 = (short) 0;
                      goto case 1;
                  }
                case 16 /*0x10*/:
                  culture = new CultureInfo(name);
                  radioInformation = FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation;
                  num2 = (short) 11;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 17:
                  recSet = new _RecSet();
                  obj = new _Value();
                  uiFields = new _UIFields();
                  iacpField1 = (IAcpField) null;
                  recSet.RecTitle = RptMgrErrorHandler.b("햕", A_1);
                  recSet.RecNo = RptMgrErrorHandler.b("ꖕ", A_1);
                  long num6 = ((AcpField<long>) radioInformation.Tracking.RadInfoLabtoolBornOnDateDBValue_A7568).Value;
                  str1 = (string) radioInformation.Tracking.RadInfoLabtoolBornOnDateDBValue_A7568.Converter.Convert((object) num6, (Type) null, (object) null, culture);
                  num2 = (short) 13;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 18:
label_13:
                  obj.FieldValue = iacpField1.ToString();
                  uiFields.values.Add(obj);
                  uiFields.UIFieldName = iacpField1.Name;
                  uiFields.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDF95\uDC97얙펛첝\uE99F\uE5A1\uEDA3\uE8A5\uE9A7\uE6A9ﲫﲭﾯ\uF5B1\uE6B3\uF7B5\uF5B7\uF7B9僚諾覿賁苃觅髇蟉跋髍駏鷑髓藕韗这軛鷝ꗟ", A_1), culture);
                  recSet.UIFields.Add(uiFields);
                  table.RecSet.Add(recSet);
                  num2 = (short) 14;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 19:
                  name = RptMgrErrorHandler.b("\uF795\uEA97랙힛증", A_1);
                  num2 = (short) 16 /*0x10*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 20:
                  num2 = (short) 1;
                  if (num2 == (short) 0)
                    ;
                  if (iacpField1 != null)
                  {
                    num2 = (short) 0;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 17;
                default:
                  goto label_3;
              }
            }
label_31:
            return;
label_36:
            return;
        }
    }
  }

  protected virtual void AddFlashPort(ref _XMLData RptXMLData)
  {
    int A_1 = 9;
    int num1 = 0;
    switch (num1)
    {
      default:
        short num2;
        _table table;
        CultureInfo culture;
        Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation radioInformation;
        switch (0)
        {
          case 0:
label_4:
            table = new _table();
            culture = new CultureInfo(AppInfoManager.ReportsLangSelection);
            radioInformation = FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation;
            num2 = (short) 9;
            num1 = (int) (IntPtr) num2;
            goto default;
          default:
            while (true)
            {
              num2 = (short) 1;
              if (num2 == (short) 0)
                ;
              _RecSet recSet;
              _Value obj;
              _UIFields uiFields;
              IAcpField iacpField1;
              IAcpField iacpField2;
              switch (num1)
              {
                case 0:
                  num2 = (short) 0;
                  obj.FieldValue = iacpField2.ToString();
                  uiFields.values.Add(obj);
                  uiFields.UIFieldName = iacpField2.Name;
                  uiFields.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("얋쪍쾏\uDB91횓쎕첗캙펛킝", A_1), culture);
                  recSet.UIFields.Add(uiFields);
                  table.RecSet.Add(recSet);
                  num2 = (short) 5;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 1:
                  if (iacpField2 != null)
                  {
                    num2 = (short) 11;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 3;
                case 2:
                  recSet = new _RecSet();
                  obj = new _Value();
                  uiFields = new _UIFields();
                  iacpField1 = (IAcpField) null;
                  recSet.RecTitle = RptMgrErrorHandler.b("캋", A_1);
                  recSet.RecNo = RptMgrErrorHandler.b("뺋", A_1);
                  iacpField2 = (IAcpField) radioInformation.FLASHport.RadInfoFLASHportIButton_A8217;
                  num2 = (short) 7;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 3:
                  RptXMLData.tables.Add(table);
                  num2 = (short) 4;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 4:
                  goto label_17;
                case 5:
label_7:
                  recSet = new _RecSet();
                  obj = new _Value();
                  uiFields = new _UIFields();
                  iacpField1 = (IAcpField) null;
                  recSet.RecTitle = RptMgrErrorHandler.b("쾋", A_1);
                  recSet.RecNo = RptMgrErrorHandler.b("뾋", A_1);
                  iacpField2 = (IAcpField) radioInformation.FLASHport.RadInfoFLASHportLastUpgradeSource_A8387;
                  num2 = (short) 1;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 6:
                  if (iacpField2 != null)
                  {
                    num2 = (short) 10;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 2;
                case 7:
                  num2 = (short) -165;
                  int num3 = (int) num2;
                  num2 = (short) -165;
                  int num4 = (int) num2;
                  switch (num3 == num4 ? 1 : 0)
                  {
                    case 0:
                    case 2:
                      goto label_13;
                    default:
                      num2 = (short) 0;
                      if (num2 == (short) 0)
                        ;
                      if (iacpField2 != null)
                      {
                        num2 = (short) 0;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto label_7;
                  }
                case 8:
label_13:
                  table.TableTitle = RptMgrErrorHandler.b("쪋\uE28D\uF18F\uE191ﲓ욕\uF797\uE899\uE89B횝즟욡삣쎥욧", A_1);
                  table.ColTitle.Add(AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("얋쪍쾏풑\uD893힕쮗튙첛톝\uF29F\uF6A1", A_1), culture));
                  iacpField1 = (IAcpField) null;
                  recSet = new _RecSet();
                  obj = new _Value();
                  uiFields = new _UIFields();
                  iacpField1 = (IAcpField) null;
                  recSet.RecTitle = RptMgrErrorHandler.b("춋", A_1);
                  recSet.RecNo = RptMgrErrorHandler.b("붋", A_1);
                  iacpField2 = (IAcpField) radioInformation.FLASHport.RadInfoFLASHportNumberofTimesFlashed_A8581;
                  num2 = (short) 6;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 9:
                  if (radioInformation != null)
                  {
                    num2 = (short) 8;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_23;
                case 10:
                  obj.FieldValue = iacpField2.ToString();
                  uiFields.values.Add(obj);
                  uiFields.UIFieldName = iacpField2.Name;
                  uiFields.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("얋쪍쾏\uDC91솓\uDB95\uDA97\uDF99캛톝\uE69F\uF6A1\uEDA3\uEBA5\uEDA7囹\uEAAB\uE2AD\uF1AF\uE1B1ﲳ\uF3B5ﲷ", A_1), culture);
                  recSet.UIFields.Add(uiFields);
                  table.RecSet.Add(recSet);
                  num2 = (short) 2;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 11:
                  obj.FieldValue = iacpField2.ToString();
                  uiFields.values.Add(obj);
                  uiFields.UIFieldName = iacpField2.Name;
                  uiFields.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("얋쪍쾏\uDE91햓얕첗쾙첛\uD99D\uF29F\uE3A1\uE0A3\uE3A5ﮧ\uE5A9嶺ﲭ\uF3AF\uF7B1", A_1), culture);
                  recSet.UIFields.Add(uiFields);
                  table.RecSet.Add(recSet);
                  num2 = (short) 3;
                  num1 = (int) (IntPtr) num2;
                  continue;
                default:
                  goto label_4;
              }
            }
label_17:
            return;
label_23:
            return;
        }
    }
  }

  protected void AddFeatureSet(ref _XMLData RptXMLData)
  {
    int A_1 = 15;
    int num1 = 0;
    switch (num1)
    {
      default:
        CultureInfo culture;
        PageRadioFeatureSet pageRadioFeatureSet;
        short num2;
        switch (0)
        {
          case 0:
label_3:
            culture = new CultureInfo(AppInfoManager.ReportsLangSelection);
            pageRadioFeatureSet = new PageRadioFeatureSet();
            num2 = (short) 8;
            num1 = (int) (IntPtr) num2;
            goto default;
          default:
            _table table;
            int num3;
            SpecialFeatures.RadioFeatureSet.RadioFeatureSet radioFeatureSet;
            IEnumerator<FeatureNode> enumerator;
            int index;
            FeatureNode featSetRec;
            while (true)
            {
              switch (num1)
              {
                case 0:
                  try
                  {
                    num2 = (short) 2;
                    int num4 = (int) (IntPtr) num2;
                    while (true)
                    {
                      switch (num4)
                      {
                        case 0:
                          goto label_13;
                        case 1:
                          if (enumerator.MoveNext())
                          {
                            FeatureNode current = enumerator.Current;
                            string featureNameValue = (current as ExtendedFeatureSetInner).ExtendedFeatureSetInnerSection.ExtendedFeatureSetFeatureNameValue;
                            string featureSetEnabledValue = (current as ExtendedFeatureSetInner).ExtendedFeatureSetInnerSection.ExtendedFeatureSetEnabledValue;
                            this.rptRec = new _RecSet();
                            this.rptRec.RecTitle = num3++.ToString();
                            this.rptRec.RecNo = num3.ToString();
                            this.rptValue = new _Value();
                            this.rptFields = new _UIFields();
                            this.rptFields.UIFieldDes = featureNameValue;
                            this.rptValue.FieldValue = featureSetEnabledValue;
                            this.rptFields.values.Add(this.rptValue);
                            this.rptFields.UIFieldName = featureNameValue;
                            this.rptRec.UIFields.Add(this.rptFields);
                            table.RecSet.Add(this.rptRec);
                            num2 = (short) 4;
                            num4 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 3;
                          num4 = (int) (IntPtr) num2;
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
                          num2 = (short) 0;
                          num4 = (int) (IntPtr) num2;
                          continue;
                      }
                      num2 = (short) 1;
                      num4 = (int) (IntPtr) num2;
                    }
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
                          goto label_33;
                        case 1:
                          enumerator.Dispose();
                          num5 = (short) 0;
                          num6 = (int) (IntPtr) num5;
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
                      if (enumerator != null)
                      {
                        num5 = (short) 1;
                        num6 = (int) (IntPtr) num5;
                      }
                      else
                        break;
                    }
label_33:;
                  }
label_13:
                  RptXMLData.tables.Add(table);
                  num2 = (short) 9;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 1:
                  radioFeatureSet = featSetRec as SpecialFeatures.RadioFeatureSet.RadioFeatureSet;
                  table = new _table();
                  table.TableTitle = RptMgrErrorHandler.b("풑\uF193\uF795\uEC97\uEF99\uEE9Bﮝ\uF39F잡킣\uEEA5솧캩좫쮭\uDEAF", A_1);
                  table.ColTitle.Add(AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("톑ﮓ\uF295ﶗ\uEA99\uF09B\uEB9D잟ﶡ\uE2A3쎥즧\uDEA9\uD9AB\uDCAD햯\uEDB1\uE7B3펵첷", A_1), culture));
                  num3 = 0;
                  enumerator = radioFeatureSet.FeatureSet.EmbeddedRecset.GetEnumerator();
                  num2 = (short) 4;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 2:
                  if (index < pageRadioFeatureSet.FeatSetRecSet.Count)
                  {
                    featSetRec = pageRadioFeatureSet.FeatSetRecSet[index];
                    num2 = (short) 10;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 6;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 3:
                case 5:
                  num2 = (short) 2;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 4:
                  num2 = (short) 0;
                  try
                  {
                    num2 = (short) 2;
                    int num7 = (int) (IntPtr) num2;
                    while (true)
                    {
                      switch (num7)
                      {
                        case 0:
                          goto label_7;
                        case 1:
                          if (enumerator.MoveNext())
                          {
                            FeatureNode current = enumerator.Current;
                            string featureNameValue = (current as FeatureSetInner).FeatureSetInnerSection.FeatureSetPurchasedFeatureNameValue;
                            string usedFlashcodeValue = (current as FeatureSetInner).FeatureSetInnerSection.FeatureSetEnabledInUsedFlashcodeValue;
                            this.rptRec = new _RecSet();
                            this.rptRec.RecTitle = num3++.ToString();
                            this.rptRec.RecNo = num3.ToString();
                            this.rptValue = new _Value();
                            this.rptFields = new _UIFields();
                            this.rptFields.UIFieldDes = featureNameValue;
                            this.rptValue.FieldValue = usedFlashcodeValue;
                            this.rptFields.values.Add(this.rptValue);
                            this.rptFields.UIFieldName = featureNameValue;
                            this.rptRec.UIFields.Add(this.rptFields);
                            table.RecSet.Add(this.rptRec);
                            num2 = (short) 4;
                            num7 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 3;
                          num7 = (int) (IntPtr) num2;
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
                          num2 = (short) 0;
                          num7 = (int) (IntPtr) num2;
                          continue;
                      }
                      num2 = (short) 1;
                      num7 = (int) (IntPtr) num2;
                    }
                  }
                  finally
                  {
                    short num8 = 2;
                    int num9 = (int) (IntPtr) num8;
                    while (true)
                    {
                      switch (num9)
                      {
                        case 0:
                          goto label_52;
                        case 1:
                          enumerator.Dispose();
                          num8 = (short) 0;
                          num9 = (int) (IntPtr) num8;
                          continue;
                        case 2:
                          goto label_43;
                        default:
                          goto label_45;
                      }
label_44:;
                    }
label_43:
                    switch (0)
                    {
                      case 0:
                        break;
                      default:
                        goto label_44;
                    }
                    while (enumerator != null)
                    {
                      num8 = (short) 13290;
                      int num10 = (int) num8;
                      num8 = (short) 13290;
                      int num11 = (int) num8;
                      switch (num10 == num11 ? 1 : 0)
                      {
                        case 0:
                        case 2:
                          continue;
                        default:
                          num8 = (short) 0;
                          if (num8 == (short) 0)
                            ;
                          num8 = (short) 1;
                          num9 = (int) (IntPtr) num8;
                          goto label_44;
                      }
label_45:;
                    }
label_52:;
                  }
label_7:
                  RptXMLData.tables.Add(table);
                  table = new _table();
                  table.TableTitle = RptMgrErrorHandler.b("힑\uEC93\uE295ﶗ\uF499\uF89Bﮝ쒟\uE4A1솣장\uDCA7\uDFA9\uDEAB쮭\uE3AFힱ삳ﺵ톷\uDEB9\uD8BB\uDBBD꺿", A_1);
                  table.ColTitle.Add(AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("힑\uEC93\uE295ﶗ\uF499\uF89Bﮝ쒟ﶡ\uE2A3쎥즧\uDEA9\uD9AB\uDCAD햯\uEDB1\uE7B3펵첷", A_1), culture));
                  num3 = 0;
                  enumerator = radioFeatureSet.ExtendedFeatureSet.EmbeddedRecset.GetEnumerator();
                  num2 = (short) 0;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 6:
                  goto label_49;
                case 7:
                  index = 0;
                  num2 = (short) 5;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 8:
                  num2 = (short) 1;
                  if (num2 == (short) 0)
                    ;
                  if (pageRadioFeatureSet.FeatSetRecSet != null)
                  {
                    num2 = (short) 7;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_51;
                case 9:
                  ++index;
                  num2 = (short) 3;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 10:
                  if (featSetRec is SpecialFeatures.RadioFeatureSet.RadioFeatureSet)
                  {
                    num2 = (short) 1;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 9;
                default:
                  goto label_3;
              }
            }
label_49:
            return;
label_51:
            return;
        }
    }
  }

  protected virtual void AddVersion(ref _XMLData RptXMLData)
  {
    int A_1 = 15;
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
            num2 = (short) 15;
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
                  table.TableTitle = RptMgrErrorHandler.b("쒑\uF193\uE495\uEB97\uF399\uF39B\uF09D肟\uEBA1쪣삥잧\uD8A9솫쾭쒯\uDBB1\uDBB3\uD8B5颷\uF2B9햻\uDABD꒿\uA7C1\uAAC3", A_1);
                  iacpField2 = (IAcpField) null;
                  recSet = new _RecSet();
                  obj = new _Value();
                  uiFields = new _UIFields();
                  recSet.RecTitle = RptMgrErrorHandler.b("펑", A_1);
                  recSet.RecNo = RptMgrErrorHandler.b("ꎑ", A_1);
                  iacpField1 = (IAcpField) radioInformation.General.RadInfoGeneralCodeplugVersion_A7683;
                  num2 = (short) 7;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 1:
                  if (iacpField1 != null)
                  {
                    num2 = (short) 10;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 14;
                case 2:
                  goto label_30;
                case 3:
                  if (iacpField1 != null)
                  {
                    num2 = (short) 16 /*0x10*/;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 12;
                case 4:
                  obj.FieldValue = iacpField1.ToString();
                  uiFields.values.Add(obj);
                  uiFields.UIFieldName = iacpField1.Name;
                  uiFields.UIFieldDes = iacpField1.UIName;
                  recSet.UIFields.Add(uiFields);
                  table.RecSet.Add(recSet);
                  break;
                case 5:
                  recSet = new _RecSet();
                  obj = new _Value();
                  uiFields = new _UIFields();
                  iacpField2 = (IAcpField) null;
                  recSet.RecTitle = RptMgrErrorHandler.b("킑", A_1);
                  recSet.RecNo = RptMgrErrorHandler.b("ꂑ", A_1);
                  iacpField1 = (IAcpField) radioInformation.General.RadInfoGeneralDSPVersion_A7892;
                  num2 = (short) 9;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 6:
                  obj.FieldValue = iacpField1.ToString();
                  uiFields.values.Add(obj);
                  uiFields.UIFieldName = iacpField1.Name;
                  uiFields.UIFieldDes = iacpField1.UIName;
                  recSet.UIFields.Add(uiFields);
                  table.RecSet.Add(recSet);
                  num2 = (short) 17;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 7:
                  if (iacpField1 != null)
                  {
                    num2 = (short) 4;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 5;
                case 8:
                  recSet = new _RecSet();
                  obj = new _Value();
                  uiFields = new _UIFields();
                  iacpField2 = (IAcpField) null;
                  recSet.RecTitle = RptMgrErrorHandler.b("톑", A_1);
                  recSet.RecNo = RptMgrErrorHandler.b("ꆑ", A_1);
                  iacpField1 = (IAcpField) radioInformation.General.RadInfoGeneralFirmwareVersion_A8124;
                  num2 = (short) 3;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 9:
                  if (iacpField1 != null)
                  {
                    num2 = (short) 13;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 8;
                case 10:
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
                  if (iacpField1 != null)
                  {
                    num2 = (short) 6;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_18;
                case 12:
                  num2 = (short) -25;
                  int num3 = (int) num2;
                  num2 = (short) -25;
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
                      recSet = new _RecSet();
                      obj = new _Value();
                      uiFields = new _UIFields();
                      iacpField2 = (IAcpField) null;
                      recSet.RecTitle = RptMgrErrorHandler.b("횑", A_1);
                      recSet.RecNo = RptMgrErrorHandler.b("ꚑ", A_1);
                      iacpField1 = (IAcpField) radioInformation.General.RadInfoGeneralUCMVersion_A9591;
                      num2 = (short) 1;
                      num1 = (int) (IntPtr) num2;
                      continue;
                  }
                  break;
                case 13:
                  obj.FieldValue = iacpField1.ToString();
                  uiFields.values.Add(obj);
                  uiFields.UIFieldName = iacpField1.Name;
                  uiFields.UIFieldDes = iacpField1.UIName;
                  recSet.UIFields.Add(uiFields);
                  table.RecSet.Add(recSet);
                  num2 = (short) 0;
                  num2 = (short) 8;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 14:
                  recSet = new _RecSet();
                  obj = new _Value();
                  uiFields = new _UIFields();
                  iacpField2 = (IAcpField) null;
                  recSet.RecTitle = RptMgrErrorHandler.b("힑", A_1);
                  recSet.RecNo = RptMgrErrorHandler.b("ꞑ", A_1);
                  iacpField1 = (IAcpField) radioInformation.General.RadInfoGeneralTuningVersion_A9509;
                  num2 = (short) 11;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 15:
                  if (radioInformation != null)
                  {
                    num2 = (short) 0;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_32;
                case 16 /*0x10*/:
                  obj.FieldValue = iacpField1.ToString();
                  uiFields.values.Add(obj);
                  uiFields.UIFieldName = iacpField1.Name;
                  uiFields.UIFieldDes = iacpField1.UIName;
                  recSet.UIFields.Add(uiFields);
                  table.RecSet.Add(recSet);
                  num2 = (short) 12;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 17:
                  num2 = (short) 1;
                  if (num2 == (short) 0)
                    goto label_18;
                  goto label_18;
                default:
                  goto label_3;
              }
              num2 = (short) 5;
              num1 = (int) (IntPtr) num2;
              continue;
label_18:
              RptXMLData.tables.Add(table);
              num2 = (short) 2;
              num1 = (int) (IntPtr) num2;
            }
label_30:
            return;
label_32:
            return;
        }
    }
  }

  protected virtual void AddFeatures(ref _XMLData RptXMLData)
  {
    short num1 = -5632;
    int num2 = (int) num1;
    num1 = (short) -5632;
    int num3 = (int) num1;
    switch (num2 == num3)
    {
      case true:
        short num4 = 0;
        if (num4 == (short) 0)
          ;
        num4 = (short) 1;
        if (num4 == (short) 0)
          ;
        num4 = (short) 0;
        break;
      default:
        goto case 1;
    }
  }

  public override void BuildDataTables(ref _XMLData XMLRptDataObj)
  {
    short num1 = -10443;
    int num2 = (int) num1;
    num1 = (short) -10443;
    int num3 = (int) num1;
    switch (num2 == num3)
    {
      case true:
        short num4 = 1;
        if (num4 == (short) 0)
          ;
        num4 = (short) 0;
        if (num4 == (short) 0)
          ;
        num4 = (short) 0;
        this.AddGeneral(ref XMLRptDataObj);
        this.AddTracking(ref XMLRptDataObj);
        this.AddFlashPort(ref XMLRptDataObj);
        this.AddFeatureSet(ref XMLRptDataObj);
        break;
      default:
        goto case 1;
    }
  }
}
